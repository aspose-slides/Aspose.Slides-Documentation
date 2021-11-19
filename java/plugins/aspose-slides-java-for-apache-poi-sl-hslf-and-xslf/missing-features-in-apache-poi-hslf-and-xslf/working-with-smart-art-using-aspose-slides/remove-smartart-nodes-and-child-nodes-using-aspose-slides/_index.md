---
title: Remove SmartArt Nodes and Child Nodes using Aspose.Slides
type: docs
weight: 40
url: /java/remove-smartart-nodes-and-child-nodes-using-aspose-slides/
---

## **Aspose.Slides - Remove SmartArt Nodes and Child Nodes**
Aspose.Slides for Java has provided the simplest API to manage the SmartArt shapes in an easiest way.

The following sample code will help to remove node and child node inside SmartArt shape.

- Create an instance of Presentation
- Obtain the reference of first slide
- Traverse through every shape inside first slide
- Check if shape is of SmartArt type
- Check if the SmartArt has more than 0 nodes
- Select the SmartArt node to be deleted
- Now, remove the selected node using RemoveNode() method
- Save the Presentation

**Removing Smart Art**

**Java**

{{< highlight java >}}

 // Load the desired the presentation

Presentation pres = new Presentation(dataDir + "AsposeAddSmartArtNode.pptx");

// Traverse through every shape inside first slide

for (IShape shape : pres.getSlides().get_Item(0).getShapes())

{

	// Check if shape is of SmartArt type

	if (shape instanceof ISmartArt)

	{

		// Typecast shape to SmartArtEx

		ISmartArt smart = (ISmartArt) shape;

		if (smart.getAllNodes().getCount() > 0)

		{

			// Accessing SmartArt node at index 0

			ISmartArtNode node = smart.getAllNodes().get_Item(0);

			// Removing the selected node

			smart.getAllNodes().removeNode(node);

		}

	}

}

// Save Presentation

pres.save(dataDir + "AsposeRemoveSmartArtNode.pptx", SaveFormat.Pptx);

{{< /highlight >}}

**Removing Smart Art from Specific Location**

**Java**

{{< highlight java >}}

 // Load the desired the presentation

Presentation pres1 = new Presentation(

		dataDir + "AsposeAddSmartArtNodeByPosition.pptx");

// Traverse through every shape inside first slide

for (IShape shape : pres1.getSlides().get_Item(0).getShapes())

{

	// Check if shape is of SmartArt type

	if (shape instanceof SmartArt)

	{

		// Typecast shape to SmartArt

		SmartArt smart = (SmartArt) shape;

		if (smart.getAllNodes().getCount() > 0)

		{

			// Accessing SmartArt node at index 0

			ISmartArtNode node = smart.getAllNodes().get_Item(0);

			if (node.getChildNodes().getCount() >= 2)

			{

				// Removing the child node at position 1

				((SmartArtNodeCollection) node.getChildNodes())

						.removeNodeByPosition(1);

			}

		}

	}

}

// Save Presentation

pres1.save(dataDir + "AsposeRemoveSmartArtNodeByPosition.pptx",	SaveFormat.Pptx);

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/smartart/removenodes/AsposeRemoveSmartArtNodes.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/smartart/removenodes/AsposeRemoveSmartArtNodes.java)

{{% alert color="primary" %}} 

For more details, visit [Add and Remove SmartArt Nodes and Child Nodes](http://docs.aspose.com:8082/docs/display/slidesjava/Add+and+Remove+SmartArt+Nodes+and+Child+Nodes).

{{% /alert %}}
