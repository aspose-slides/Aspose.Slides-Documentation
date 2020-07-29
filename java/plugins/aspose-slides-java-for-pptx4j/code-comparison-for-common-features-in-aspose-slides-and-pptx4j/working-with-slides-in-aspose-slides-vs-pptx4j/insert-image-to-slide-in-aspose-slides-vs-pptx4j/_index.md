---
title: Insert Image to Slide in Aspose.Slides vs pptx4j
type: docs
weight: 50
url: /java/insert-image-to-slide-in-aspose-slides-vs-pptx4j/
---

## **Aspose.Slides - Insert Image to Slide**
Below example shows how different images and autoshapes can be added to presentation slides using Aspose.Slides.

**Java**

{{< highlight java >}}

 //Instantiate Presentation class that represents the PPTX

Presentation pres = new Presentation();

//Get the first slide

ISlide sld = pres.getSlides().get_Item(0);

//Instantiate the Image class

IPPImage imgx = null;

try{

    imgx = pres.getImages().addImage(new FileInputStream(new File(dataDir + "greentick.png")));

}

catch(IOException e){}

//Add Picture Frame with height and width equivalent of Picture

sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);

//Write the PPTX file to disk

pres.save(dataDir + "ImageInSlide-Aspose.pptx", SaveFormat.Pptx);

{{< /highlight >}}
## **pptx4j - Insert Image to Slide**
Below mentioned example shows how different images and autoshapes can be added to presentation slides using Aspose.Slides.

**Java**

{{< highlight java >}}

 public static void main(String[] args) throws Exception {

	final Logger log = LoggerFactory.getLogger(Pptx4jAddImageToSlide.class);

	// Where will we save our new .pptx?

	String outputfilepath = dataDir + "ImageInSlide-Pptx4j.pptx";

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

	// Add image part

	File file = new File(dataDir + "greentick.png" );

    BinaryPartAbstractImage imagePart

    	= BinaryPartAbstractImage.createImagePart(presentationMLPackage, slidePart, file);


    // Add p:pic to slide

	slidePart.getJaxbElement().getCSld().getSpTree().getSpOrGrpSpOrGraphicFrame().add(

			createPicture(imagePart.getSourceRelationship().getId()));


	// Do it again on another slide

	SlidePart slidePart2 = presentationMLPackage.createSlidePart(pp, layoutPart,

			new PartName("/ppt/slides/slide2.xml"));

	Relationship rel = slidePart2.addTargetPart(imagePart);

	slidePart2.getJaxbElement().getCSld().getSpTree().getSpOrGrpSpOrGraphicFrame().add(

			createPicture(rel.getId()));

	// All done: save it

	presentationMLPackage.save(new java.io.File(outputfilepath));

	System.out.println("\n\n done .. saved " + outputfilepath);

}

private static Object createPicture(String relId) throws JAXBException {

	// Create p:pic

    java.util.HashMap<String, String>mappings = new java.util.HashMap<String, String>();

    mappings.put("id1", "4");

    mappings.put("name", "Picture 3");

    mappings.put("descr", "greentick.png");

    mappings.put("rEmbedId", relId );

    mappings.put("offx", Long.toString(4214812));

    mappings.put("offy", Long.toString(3071812));

    mappings.put("extcx", Long.toString(714375));

    mappings.put("extcy", Long.toString(714375));

    return org.docx4j.XmlUtils.unmarshallFromTemplate(SAMPLE_PICTURE,

    		mappings, Context.jcPML, Pic.class ) ;


}


private static String SAMPLE_PICTURE =

      "<p:pic xmlns:a=\"http://schemas.openxmlformats.org/drawingml/2006/main\" xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\" xmlns:p=\"http://schemas.openxmlformats.org/presentationml/2006/main\"> "

        + "<p:nvPicPr>"

          + "<p:cNvPr id=\"${id1}\" name=\"${name}\" descr=\"${descr}\"/>"

          + "<p:cNvPicPr>"

            + "<a:picLocks noChangeAspect=\"1\"/>"

          + "</p:cNvPicPr>"

          + "<p:nvPr/>"

        + "</p:nvPicPr>"

        + "<p:blipFill>"

          + "<a:blip r:embed=\"${rEmbedId}\" cstate=\"print\"/>"

          + "<a:stretch>"

            + "<a:fillRect/>"

          + "</a:stretch>"

        + "</p:blipFill>"

        + "<p:spPr>"

          + "<a:xfrm>"

            + "<a:off x=\"${offx}\" y=\"${offy}\"/>"

            + "<a:ext cx=\"${extcx}\" cy=\"${extcy}\"/>"

          + "</a:xfrm>"

          + "<a:prstGeom prst=\"rect\">"

            + "<a:avLst/>"

          + "</a:prstGeom>"

        + "</p:spPr>"

      + "</p:pic>";


{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Working with Shapes](http://docs.aspose.com:8082/docs/display/slidesjava/Working+with+Shapes).

{{% /alert %}}
