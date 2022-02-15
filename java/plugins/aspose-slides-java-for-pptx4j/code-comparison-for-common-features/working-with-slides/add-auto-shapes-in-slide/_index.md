---
title: Add Auto Shapes in Slide in Aspose.Slides vs pptx4j
type: docs
weight: 10
url: /java/add-auto-shapes-in-slide-in-aspose-slides-vs-pptx4j/
---

## **Aspose.Slides - Add Auto Shapes in Slide**
Aspose.Slides for Java supports adding different kinds of shapes to the slides. Using Aspose.Slides for Java , developers can not only create simple lines , but some fancy lines can also be drawn on the slides.

**Java**

{{< highlight java >}}

 //Get the first slide

ISlide sld = pres.getSlides().get_Item(0);

for (int i = 1 ; i <= ShapeType.ChartPlus ; i++)

{

	System.out.println(i + ". Done.");

	//Add an auto shape of type line

	sld.getShapes().addAutoShape(i, 50, 100, 150, 100);

	sld = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

}

{{< /highlight >}}
## **pptx4j - Add Auto Shapes in Slide**
Below sample shows how autoshapes can be added in slide of presentation using pptx4j.

**Java**

{{< highlight java >}}

 public static void main(String[] args) throws Exception

{

	// Where will we save our new .ppxt?

	String outputfilepath = dataDir + "Pptx4jAutoShapes.pptx";

	// Create skeletal package

	PresentationMLPackage presentationMLPackage = PresentationMLPackage.createPackage();

	MainPresentationPart pp = (MainPresentationPart)presentationMLPackage.getParts().getParts().get(

			new PartName("/ppt/presentation.xml"));

	SlideLayoutPart layoutPart = (SlideLayoutPart)presentationMLPackage.getParts().getParts().get(

			new PartName("/ppt/slideLayouts/slideLayout1.xml"));

	boolean noLine = false;

	/* ST_ShapeType has 203 values

	 *

	 * Create a slide for each shape */

	int i = 1;

	for (STShapeType st : STShapeType.values() ) {

		System.out.println("Adding slide for shape: " + st.value() );

		SlidePart slidePart = createSlidePart(pp, layoutPart, i);

		// Create and add shapes

		Shape title = ((Shape)XmlUtils.unmarshalString(

				getSlideTitle(st.value()), Context.jcPML) );

		slidePart.getJaxbElement().getCSld().getSpTree().getSpOrGrpSpOrGraphicFrame().add(title);


		Shape sample = ((Shape)XmlUtils.unmarshalString(

				getPresetShape(st.value(), noLine), Context.jcPML) );

		slidePart.getJaxbElement().getCSld().getSpTree().getSpOrGrpSpOrGraphicFrame().add(sample);

		i++;

	}

	// All done: save it

	presentationMLPackage.save(new java.io.File(outputfilepath));

	System.out.println("\n\n done .. saved " + outputfilepath);

}


/**

 * Create a slide and add it to the package

 *

 * @param pp

 * @param layoutPart

 * @param i

 * @return the slide

 * @throws InvalidFormatException

 * @throws JAXBException

 */

private static SlidePart createSlidePart(MainPresentationPart pp, SlideLayoutPart layoutPart, int i)

	throws InvalidFormatException, JAXBException {

	// Slide part

	SlidePart slidePart = new SlidePart(new PartName("/ppt/slides/slide" + i +".xml") );

	pp.addSlideIdListEntry(slidePart);

	slidePart.setJaxbElement( SlidePart.createSld() );

	// Slide layout part

	slidePart.addTargetPart(layoutPart);

	return slidePart;

}


/**

 * get XML for the specified present shape

 *

 * @param preset

 * @param noLine

 * @return

 */

private static String getPresetShape(String preset, boolean noLine) {

	String txBody = "";

	String ln = "";

	// Shape will say "click here to add title"

	// if txBody is not present.

	// If txBody is present, shape will be invisible

	// unless a:ln is present

	if (!noLine) {

//			txBody = "<p:txBody>"

//				+ "<a:bodyPr />"

//				+ "<a:lstStyle />"

//				+ "<a:p>"

//					+ "<a:r>"

//						+ "<a:rPr lang=\"en-US\" smtClean=\"0\" />"

//						+ "<a:t> </a:t>"

//					+ "</a:r>"

//					+ "<a:endParaRPr lang=\"en-US\" />"

//				+ "</a:p>"

//			+ "</p:txBody>";

		ln = "<a:ln>"

	            +"<a:solidFill>"

	            	+"<a:srgbClr val=\"FF0000\"/>"

	            +"</a:solidFill>"

            +"</a:ln>";

	}

	/*

	 * If you don't have a:ln, there will be no lines,

	 * so the shape will be invisible.

	 *

	 * If you add <p:ph type=\"title\" />, you'll get

	 * a title (and the dotted outline of the shape

	 * will be visible).

	 *

	 * Without a p:txBody, the words "Click to

	 * add title" will appear. (maybe title because

	 * of our p:ph/@type?)

	 *

	 */


	return

		"<p:sp   xmlns:a=\"http://schemas.openxmlformats.org/drawingml/2006/main\" xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\" xmlns:p=\"http://schemas.openxmlformats.org/presentationml/2006/main\">"

			+ "<p:nvSpPr>"

				+ "<p:cNvPr id=\"4\" name=\"My Preset Shape\" />"

				+ "<p:cNvSpPr/>"

					//+ "<a:spLocks noGrp=\"1\" />"

				//+ "</p:cNvSpPr>"

				+ "<p:nvPr/>"

//						+ "<p:ph type=\"title\" />"

//					+ "</p:nvPr>"

			+ "</p:nvSpPr>"

			+ "<p:spPr>"

				+ "<a:xfrm>"

					+ "<a:off x=\"1981200\" y=\"533400\"/>"

					+ "<a:ext cx=\"1143000\" cy=\"1066800\"/>"

				+ "</a:xfrm>"

				+ "<a:prstGeom prst=\"" + preset + "\">"

				+ "<a:avLst/>"

				+ "</a:prstGeom>"

				+ ln

			+ "</p:spPr>"

			+ txBody

	+ "</p:sp>";

}

private static String getSlideTitle(String preset) {

	return "<p:sp   xmlns:a=\"http://schemas.openxmlformats.org/drawingml/2006/main\" xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\" xmlns:p=\"http://schemas.openxmlformats.org/presentationml/2006/main\">"

	+ "<p:nvSpPr>"

	+ "<p:cNvPr id=\"4\" name=\"Title 3\" />"

	+ "<p:cNvSpPr>"

		+ "<a:spLocks noGrp=\"1\" />"

	+ "</p:cNvSpPr>"

	+ "<p:nvPr>"

		+ "<p:ph type=\"title\" />"

	+ "</p:nvPr>"

\+ "</p:nvSpPr>"

\+ "<p:spPr />"

\+ "<p:txBody>"

	+ "<a:bodyPr />"

	+ "<a:lstStyle />"

	+ "<a:p>"

		+ "<a:r>"

			+ "<a:rPr lang=\"en-US\" smtClean=\"0\" />"

			+ "<a:t>" + preset + "</a:t>"

		+ "</a:r>"

		+ "<a:endParaRPr lang=\"en-US\" />"

	+ "</a:p>"

\+ "</p:txBody>"

\+ "</p:sp>";

}

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
