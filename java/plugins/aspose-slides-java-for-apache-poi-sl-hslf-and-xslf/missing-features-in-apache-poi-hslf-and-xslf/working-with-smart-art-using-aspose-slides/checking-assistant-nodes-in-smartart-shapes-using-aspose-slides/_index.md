---
title: Checking Assistant Nodes in SmartArt Shapes using Aspose.Slides
type: docs
weight: 20
url: /java/checking-assistant-nodes-in-smartart-shapes-using-aspose-slides/
---

## **Aspose.Slides - Checking Assistant Nodes in SmartArt Shapes**
In the following sample code we will investigate how to identify **Assistant Nodes** in the SmartArt nodes collection and changing them.

- Create an instance of Presentation class and load the presentation with SmartArt Shape
- Obtain the reference of second slide by using its Index
- Traverse through every shape inside first slide
- Check if shape is of SmartArt type and Typecast selected shape to SmartArt if it is SmartArt
- Traverse through all nodes inside SmartArt shape and check if they are Assistant Nodes
- Change the status of Assistant Node to normal node
- Save the Presentation

**Java**

{{< highlight java >}}

 // Creating a presentation instance

Presentation pres = new Presentation(dataDir + "presentation.pptx");

// Traverse through every shape inside first slide

for (IShape shape : pres.getSlides().get_Item(0).getShapes())

{

    // Check if shape is of SmartArt type

    if (shape instanceof ISmartArt)

    {

	// Typecast shape to SmartArtEx

	ISmartArt smart = (SmartArt) shape;

	// Traversing through all nodes of SmartArt shape

	for (int i = 0; i < smart.getAllNodes().size(); i++)

	{

	    ISmartArtNode node = smart.getAllNodes().get_Item(i);

	    String tc = node.getTextFrame().getText();

	    // Check if node is Assistant node

	    if (node.isAssistant())

	    {

		System.out.println(tc + " - true");

		// Setting Assistant node to false and making it normal

		// node

		node.setAssistant(false);

	    }

	    else

	    {

		System.out.println(tc + " - false");

	    }

	}

    }

}

// Save Presentation

pres.save(dataDir + "AsposeChangeAssitantNode.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/smartart/checkingassistantnodes/AsposeCheckAssistantNodesInSmartArtShapes.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/smartart/checkingassistantnodes/AsposeCheckAssistantNodesInSmartArtShapes.java)

{{% alert color="primary" %}} 

For more details, visit [Checking Assistant Nodes In SmartArt Shapes](http://www.aspose.com/docs/display/slidesjava/Checking+Assistant+Nodes+in+SmartArt+Shapes).

{{% /alert %}}
