---
title: Hello World Presentation in Aspose.Slides vs pptx4j
type: docs
weight: 50
url: /java/hello-world-presentation-in-aspose-slides-vs-pptx4j/
---

## **Aspose.Slides - Hello World Presentation**
Below sample shows how new presentation is created and saved after adding simple text using Aspose.Slides.

**Java**

{{< highlight java >}}

 // Instantiate Presentation class that represents the PPTX

Presentation pres = new Presentation();

//Get the first slide

ISlide sld = (ISlide)pres.getSlides().get_Item(0);

//Add an AutoShape of Rectangle type

IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

//Add ITextFrame to the Rectangle

ashp.addTextFrame("Hello World");

{{< /highlight >}}
## **pptx4j - Hello World Presentation**
Below sample shows how new presentation is created and saved after adding simple text using pptx4j.

**Java**

{{< highlight java >}}

 // Where will we save our new .ppxt?

String outputfilepath = dataDir + "Pptx4jHelloWorld.pptx";

if (MACRO_ENABLE) outputfilepath += "m";

// Create skeletal package, including a MainPresentationPart and a SlideLayoutPart

PresentationMLPackage presentationMLPackage = PresentationMLPackage.createPackage();

if (MACRO_ENABLE) {

	ContentTypeManager ctm = presentationMLPackage.getContentTypeManager();

	ctm.removeContentType(new PartName("/ppt/presentation.xml") );

	ctm.addOverrideContentType(new URI("/ppt/presentation.xml"), ContentTypes.PRESENTATIONML_MACROENABLED);

}

// Need references to these parts to create a slide

// Please note that these parts *already exist* - they are

// created by createPackage() above.  See that method

// for instruction on how to create and add a part.

MainPresentationPart pp = (MainPresentationPart)presentationMLPackage.getParts().getParts().get(

		new PartName("/ppt/presentation.xml"));

SlideLayoutPart layoutPart = (SlideLayoutPart)presentationMLPackage.getParts().getParts().get(

		new PartName("/ppt/slideLayouts/slideLayout1.xml"));

// OK, now we can create a slide

SlidePart slidePart = new SlidePart(new PartName("/ppt/slides/slide1.xml"));

slidePart.setContents( SlidePart.createSld() );

pp.addSlide(0, slidePart);

// Slide layout part

slidePart.addTargetPart(layoutPart);


// Create and add shape

Shape sample = ((Shape)XmlUtils.unmarshalString(SAMPLE_SHAPE, Context.jcPML) );

slidePart.getContents().getCSld().getSpTree().getSpOrGrpSpOrGraphicFrame().add(sample);

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Opening a Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Opening+a+Presentation) and [Saving a Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Saving+a+Presentation).

{{% /alert %}}
