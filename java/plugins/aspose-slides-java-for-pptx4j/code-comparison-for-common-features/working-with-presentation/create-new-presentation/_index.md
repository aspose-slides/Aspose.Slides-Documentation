---
title: Create New Presentation in Aspose.Slides vs pptx4j
type: docs
weight: 20
url: /java/create-new-presentation-in-aspose-slides-vs-pptx4j/
---

## **Aspose.Slides - Create New Presentation**
The [Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/com.aspose.slides.Presentation+class) class holds a presentation's content. Whether creating a presentation from scratch or modifying an existing one, when finished, you want to save the presentation. With Aspose.Slides for Java, it can be saved as a **file** or **stream**

**Java**

{{< highlight java >}}

 // Instantiate Presentation class that represents the PPTX

Presentation pres = new Presentation();

//Write the PPTX file to disk

pres.save(dataDir + "Aspose-New-Presentation.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **pptx4j - Create New Presentation**
New presentation creation procedure is shown below using pptx4j.

**Java**

{{< highlight java >}}

 // Create skeletal package, including a MainPresentationPart and a SlideLayoutPart

PresentationMLPackage presentationMLPackage = PresentationMLPackage.createPackage();

// Need references to these parts to create a slide

// Please note that these parts *already exist* - they are

// created by createPackage() above.  See that method

// for instruction on how to create and add a part.

MainPresentationPart pp = (MainPresentationPart)presentationMLPackage.getParts().getParts().get(

		new PartName("/ppt/presentation.xml"));

SlideLayoutPart layoutPart = (SlideLayoutPart)presentationMLPackage.getParts().getParts().get(

		new PartName("/ppt/slideLayouts/slideLayout1.xml"));

// OK, now we can create a slide

SlidePart slidePart = presentationMLPackage.createSlidePart(pp, layoutPart,

		new PartName("/ppt/slides/slide1.xml"));

presentationMLPackage.save(new java.io.File(dataDir + "Pptx4j-New Presentation.pptx"));

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Saving a Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Saving+a+Presentation).

{{% /alert %}}
