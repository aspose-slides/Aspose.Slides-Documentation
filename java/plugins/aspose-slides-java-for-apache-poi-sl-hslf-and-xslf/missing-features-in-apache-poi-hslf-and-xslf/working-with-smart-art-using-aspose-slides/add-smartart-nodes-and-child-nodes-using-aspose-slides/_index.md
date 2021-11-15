---
title: Add SmartArt Nodes and Child Nodes using Aspose.Slides
type: docs
weight: 10
url: /java/add-smartart-nodes-and-child-nodes-using-aspose-slides/
---

## **Aspose.Slides - Add SmartArt Nodes and Child Nodes**
Aspose.Slides for Java has provided the simplest API to manage the SmartArt shapes in an easiest way. The following sample code will help to add node and child node inside SmartArt shape.

- Create an instance of Presentation
- Obtain the reference of first slide by using its Index
- Traverse through every shape inside first slide
- Check if shape is of SmartArt type
- Add a new Node in SmartArt shape
- Now, Add a Child Node in newly added SmartArt Node
- Save the Presentation

**Adding Smart Art**

**Java**

{{< highlight java >}}

 // Load the desired the presentation

Presentation pres = new Presentation(dataDir + "AsposeSmartArt.pptx");

// Traverse through every shape inside first slide

for (IShape shape : pres.getSlides().get_Item(0).getShapes())

{

	// Check if shape is of SmartArt type

	if (shape instanceof SmartArt)

	{

		// Typecast shape to SmartArt

		SmartArt smart = (SmartArt) shape;

		// Adding a new SmartArt Node

		SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();

		// Adding text

		TemNode.getTextFrame().setText("Test");

		// Adding new child node in parent node. It will be added in the end of collection

		SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();

		// Adding text

		newNode.getTextFrame().setText("New Node Added");

	}

}

// Saving Presentation

pres.save(dataDir + "AsposeAddSmartArtNode.pptx", SaveFormat.Pptx);

{{< /highlight >}}

**Adding Smart Art to Specific Location**

**Java**

{{< highlight java >}}

 //Creating a presentation instance

Presentation pres1 = new Presentation();

//Access the presentation slide

ISlide slide = pres1.getSlides().get_Item(0);

//Add Smart Art IShape

ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

//Accessing the SmartArt node at index 0

ISmartArtNode node = smart.getAllNodes().get_Item(0);

//Adding new child node at position 2 in parent node

SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.getChildNodes()).addNodeByPosition(2);

//Add Text

chNode.getTextFrame().setText("Sample Text Added");

//Save Presentation

pres1.save(dataDir + "AsposeAddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);


{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/smartart/addnodes/AsposeAddSmartArtNodes.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/smartart/addnodes/AsposeAddSmartArtNodes.java)

{{% alert color="primary" %}} 

For more details, visit [Add and Remove SmartArt Nodes and Child Nodes](http://docs.aspose.com:8082/docs/display/slidesjava/Add+and+Remove+SmartArt+Nodes+and+Child+Nodes).

{{% /alert %}}
