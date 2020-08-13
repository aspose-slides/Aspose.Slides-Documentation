---
title: Remove SmartArt Nodes and Child Nodes in Aspose.Slides
type: docs
weight: 30
url: /java/remove-smartart-nodes-and-child-nodes-in-aspose-slides/
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

``` java

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

```

**Removing Smart Art from Specific Location**

**Java**

``` java

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

pres1.save(datadir + "AsposeRemoveSmartArtNodeByPosition.pptx",	SaveFormat.Pptx);

```
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Add and Remove SmartArt Nodes and Child Nodes](http://docs.aspose.com:8082/docs/display/slidesjava/Add+and+Remove+SmartArt+Nodes+and+Child+Nodes).

{{% /alert %}}
