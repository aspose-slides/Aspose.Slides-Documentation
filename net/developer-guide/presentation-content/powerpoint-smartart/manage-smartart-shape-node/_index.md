---
title: Manage SmartArt Shape Node
type: docs
weight: 30
url: /net/manage-smartart-shape-node/
keywords: "SmartArt node, SmartArt child node, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Smart node and child node in PowerPoint presentations in C# or .NET"
---


## **Add SmartArt Node**
Aspose.Slides for .NET has provided the simplest API to manage the SmartArt shapes in an easiest way. The following sample code will help to add node and child node inside SmartArt shape.

- Create an instance of [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Add a new Node in SmartArt shape NodeCollection and set the text in TextFrame.
- Now, Add a Child Node in newly added SmartArt Node and set the text in TextFrame.
- Save the Presentation.

```c#
// Load the desired the presentation
Presentation pres = new Presentation("AddNodes.pptx");

// Traverse through every shape inside first slide
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Check if shape is of SmartArt type
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Typecast shape to SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Adding a new SmartArt Node
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Adding text
        TemNode.TextFrame.Text = "Test";

        // Adding new child node in parent node. It  will be added in the end of collection
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Adding text
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Saving Presentation
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **Add SmartArt Node at Specific Position**
In the following sample code we have explained how to add the child nodes belonging to respective nodes of SmartArt shape at particular position.

- Create an instance of `Presentation` class.
- Obtain the reference of first slide by using its Index.
- Add a StackedList type SmartArt shape in accessed slide.
- Access the first node in added SmartArt shape.
- Now, add the Child Node for selected Node at position 2 and set its text.
- Save the Presentation.

```c#
// Creating a presentation instance
Presentation pres = new Presentation();

// Access the presentation slide
ISlide slide = pres.Slides[0];

// Add Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Accessing the SmartArt node at index 0
ISmartArtNode node = smart.AllNodes[0];

// Adding new child node at position 2 in parent node
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Add Text
chNode.TextFrame.Text = "Sample Text Added";

// Save Presentation
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **Access SmartArt Node**
The following sample code will help to access nodes inside SmartArt shape. Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the SmartArt shape is added.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.

- Obtain the reference of first slide by using its Index.

- Traverse through every shape inside first slide.

- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.

- Traverse through all Nodes inside SmartArt Shape.

- Access and display information like SmartArt Node position, level and Text.

  ```c#
  // Load the desired the presentation
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Traverse through every shape inside first slide
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Check if shape is of SmartArt type
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Typecast shape to SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Traverse through all nodes inside SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Accessing SmartArt node at index i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Printing the SmartArt node parameters
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```

  


## **Access SmartArt Child Node**
The following sample code will help to access the child nodes belonging to respective nodes of SmartArt shape.

- Create an instance of PresentationEx class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArtEx if it is SmartArt.
- Traverse through all Nodes inside SmartArt Shape.
- For every selected SmartArt shape Node, traverse through all Child Nodes inside particular node.
- Access and display information like Child Node position, level and Text.

```c#
// Load the desired the presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Traverse through every shape inside first slide
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Check if shape is of SmartArt type
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Typecast shape to SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Traverse through all nodes inside SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Accessing SmartArt node at index i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Traversing through the child nodes in SmartArt node at index i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Accessing the child node in SmartArt node
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Printing the SmartArt child node parameters
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```



## **Access SmartArt Child Node at Specific Position**
In this example, we will learn to access the child nodes at some particular position belonging to respective nodes of SmartArt shape.

- Create an instance of `Presentation` class.
- Obtain the reference of first slide by using its Index.
- Add a StackedList type SmartArt shape.
- Access the added SmartArt shape.
- Access the node at index 0 for accessed SmartArt shape.
- Now, access the Child Node at position 1 for accessed SmartArt node using GetNodeByPosition() method.
- Access and display information like Child Node position, level and Text.

```c#
// Instantiate the presentation
Presentation pres = new Presentation();

// Accessing the first slide
ISlide slide = pres.Slides[0];

// Adding the SmartArt shape in first slide
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Accessing the SmartArt  node at index 0
ISmartArtNode node = smart.AllNodes[0];

// Accessing the child node at position 1 in parent node
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// Printing the SmartArt child node parameters
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```



## **Remove SmartArt Node**
In this example, we will learn to remove the nodes inside SmartArt shape.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Check if the SmartArt has more than 0 nodes.
- Select the SmartArt node to be deleted.
- Now, remove the selected node using RemoveNode() method* Save the Presentation.

```c#
// Load the desired the presentation
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Traverse through every shape inside first slide
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Check if shape is of SmartArt type
        if (shape is ISmartArt)
        {
            // Typecast shape to SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Accessing SmartArt node at index 0
                ISmartArtNode node = smart.AllNodes[0];

                // Removing the selected node
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Save Presentation
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Remove SmartArt Node at Specific Position**
In this example, we will learn to remove the nodes inside SmartArt shape at particular position.

- Create an instance of `Presentation` class and load the presentation with SmartArt Shape.
- Obtain the reference of first slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt.
- Select the SmartArt shape node at index 0.
- Now, check if the selected SmartArt node has more than 2 child nodes.
- Now, remove the node at Position 1 using RemoveNodeByPosition() method.
- Save the Presentation.

```c#
// Load the desired the presentation             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Traverse through every shape inside first slide
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Check if shape is of SmartArt type
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Typecast shape to SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Accessing SmartArt node at index 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Removing the child node at position 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Save Presentation
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **Set Custom Position for Child Node in SmartArt**
Now Aspose.Slides for .NET support for setting SmartArtShape X and Y properties. The code snippet below shows how to set custom SmartArtShape position, size and rotation also please note that adding new nodes causes a recalculation of the positions and sizes of all nodes.

```c#
// Load the desired the presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Move SmartArt shape to new position
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Change SmartArt shape's widths
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Change SmartArt shape's height
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Change SmartArt shape's rotation
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```



## **Check Assistant Node**
In the following sample code we will investigate how to identify Assistant Nodes in the SmartArt nodes collection and changing them.

- Create an instance of PresentationEx class and load the presentation with SmartArt Shape.
- Obtain the reference of second slide by using its Index.
- Traverse through every shape inside first slide.
- Check if shape is of SmartArt type and Typecast selected shape to SmartArtEx if it is SmartArt.
- Traverse through all nodes inside SmartArt shape and check if they are Assistant Nodes.
- Change the status of Assistant Node to normal node.
- Save the Presentation.

```c#
// Creating a presentation instance
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Traverse through every shape inside first slide
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Check if shape is of SmartArt type
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Typecast shape to SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Traversing through all nodes of SmartArt shape

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Check if node is Assitant node
                if (node.IsAssistant)
                {
                    // Setting Assitant node to false and making it normal node
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Save Presentation
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Set Node's Fill Format**
Aspose.Slides for .NET makes it possible to add custom SmartArt shapes and set their fill formats. This article explains how to create and access SmartArt shapes and set their fill format using Aspose.Slides for .NET.

Please follow the steps below:

- Create an instance of the `Presentation` class.
- Obtain the reference of a slide using its index.
- Add a SmartArt shape by setting its LayoutType.
- Set the FillFormat for the SmartArt shape nodes.
- Write the modified presentation as a PPTX file.

```c#
using (Presentation presentation = new Presentation())
{
    // Accessing the slide
    ISlide slide = presentation.Slides[0];

    // Adding SmartArt shape and nodes
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Setting node fill color
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Saving Presentation
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```



## **Generate Thumbnail of SmartArt Child Node**
Developers can generate a thumbnail of Child node of a SmartArt by following the steps below:

1. Instantiate `Presentation` class that represents the PPTX file.
1. Add SmartArt.
1. Obtain the reference of a node by using its Index
1. Get the thumbnail image.
1. Save the thumbnail image in any desired image format.

The example below generating a thumbnail of SmartArt child node

```c#
// Instantiate Presentation class that represents the PPTX file 
Presentation pres = new Presentation();

// Add SmartArt 
ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

// Obtain the reference of a node by using its Index  
ISmartArtNode node = smart.Nodes[1];

// Get thumbnail
Bitmap bmp = node.Shapes[0].GetThumbnail();

// Save thumbnail
bmp.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
```



