'Justin Stachofsky
'Binary search tree sort written for MIS 350
'Used two sources as guidelines/references:
'   https://msdn.microsoft.com/en-us/library/aa227540(v=vs.60).aspx
'   https://www.codeproject.com/Articles/4647/A-simple-binary-tree-implementation-with-VB-NET

Public Class treeNode 'Datatype that tree is built from

    Public randomValue As Integer
    Public leftChild As treeNode
    Public rightChild As treeNode

End Class

Public Class tree 'Datatype of a tree, which is built from treeNode objects

    Private root As treeNode

    Sub New(rootValue As Integer) 'Class constructor, creates root
        root = getNode(rootValue)
    End Sub

    Private Function getNode(numberToAdd As Integer) As treeNode 'Function that actually stores value in tree
        Dim node As New treeNode()
        node.randomValue = numberToAdd
        Return node
    End Function

    Public Sub addNode(generatedNumber As Integer) 'Public function to add node. generatedNumber randomly generated value
        Dim currentNode As treeNode = root
        Dim nextNode As treeNode = root

        While currentNode.randomValue <> generatedNumber And Not nextNode Is Nothing 'Traverses tree to find where to add node
            currentNode = nextNode
            If nextNode.randomValue < generatedNumber Then
                nextNode = nextNode.rightChild
            ElseIf nextNode.randomValue > generatedNumber Then
                nextNode = nextNode.leftChild
            Else
                nextNode = nextNode.leftChild 'Duplicate value, just assign to left
            End If
        End While
        If currentNode.randomValue < generatedNumber Then 'If conditional for calling private node creation function
            currentNode.rightChild = getNode(generatedNumber)
        ElseIf currentNode.randomValue > generatedNumber Then
            currentNode.leftChild = getNode(generatedNumber)
        Else
            currentNode.leftChild = getNode(generatedNumber) 'Duplicate value, just assign to left
        End If
    End Sub

    Public Sub printTree() 'Public sub for printing tree, calls private printInOrder traversal function
        Call printInOrder(root)
    End Sub

    Private Sub printInOrder(node As treeNode) 'In order traversal of tree
        If Not node Is Nothing Then
            Call printInOrder(node.leftChild)
            Console.WriteLine(node.randomValue)
            Call printInOrder(node.rightChild)
        End If
    End Sub

End Class

Module binarySearchTreeSort

    'Main subroutine for program
    Sub Main()

        Dim dataTree = New tree(Int(Rnd() * 100) + 0) 'Tree where data is stored, constructed with random value
        Dim userInput 'Stores user action

        Console.WriteLine("Unsorted Values:")
        Call generateValues(dataTree)

        userInput = "a"
        While (userInput <> "q" Or userInput <> "s") 'Loop used to continually prompt menu if invalid command is given
            Console.WriteLine("Press 's' to sort or 'q' to exit program")
            userInput = Console.ReadLine()

            If userInput = "q" Then
                End
            ElseIf userInput = "s" Then
                dataTree.printTree()
                Console.ReadLine()
                End
            Else
                Console.WriteLine("Invalid command")
            End If
        End While

    End Sub

    'Subroutine used to fill tree with values
    Sub generateValues(ByRef dataTree)

        Dim randomValue 'Value to be passed to tree

        For i = 0 To 99 'First value already exists
            randomValue = Int(Rnd() * 100) + 0 'Generates number between 0 and 100
            Console.WriteLine(randomValue) 'Print them as generated since they are sorted as placed in tree
            dataTree.addNode(randomValue) 'Calls public addNode method
        Next

    End Sub

End Module
