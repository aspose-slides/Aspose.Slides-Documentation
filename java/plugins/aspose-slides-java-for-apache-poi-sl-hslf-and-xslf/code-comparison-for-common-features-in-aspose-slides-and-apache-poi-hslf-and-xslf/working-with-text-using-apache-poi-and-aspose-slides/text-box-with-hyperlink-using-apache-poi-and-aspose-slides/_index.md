---
title: Text Box with Hyperlink using Apache POI and Aspose.Slides
type: docs
weight: 30
url: /java/text-box-with-hyperlink-using-apache-poi-and-aspose-slides/
---

## **Aspose.Slides - Text Box with Hyperlink**
Please follow the steps below to create a **TextBox** with **Hyperlink** by using Aspose.Slides for Java API:

- Create an instance of Presentation.
- Obtain the reference of the first slide in the presentation.
- Add an AutoShape with ShapeType as Rectangle at a specified position of the slide and obtain the reference of that newly added AutoShape object.
- Add a TextFrame to the AutoShape.
- Instantiate the IHyperlinkManager.
- Assign the IHyperlinkManager object to the HLinkClick property associated with the desired portion of the TextFrame.
- Finally, save the PPTX file using the Presentation object

**Java**

{{< highlight java >}}

 // Add an AutoShape of Rectangle Type

IShape pptxShape = slide.getShapes().addAutoShape(ShapeType.Rectangle,

		150, 150, 150, 50);

// Cast the shape to AutoShape

IAutoShape pptxAutoShape = (IAutoShape) pptxShape;

// Access ITextFrame associated with the AutoShape

pptxAutoShape.addTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.getTextFrame();

// Add some text to the frame

ITextFrame.getParagraphs().get_Item(0).getPortions().get_Item(0)

		.setText("Aspose.Slides");

// Set Hyperlink for the portion text

IHyperlinkManager HypMan = ITextFrame.getParagraphs().get_Item(0)

		.getPortions().get_Item(0).getPortionFormat()

		.getHyperlinkManager();

HypMan.setExternalHyperlinkClick("http://www.aspose.com");


{{< /highlight >}}
## **Apache POI SL - HSLF XSLF - Text Box with Hyperlink**
XSLFTextBox and XSLFHyperlink can be used for textbox with Hyperlink as mentioned below:

**Java**

{{< highlight java >}}

 // assign a hyperlink to a text run

XSLFTextBox shape = slide.createTextBox();

XSLFTextRun r = shape.addNewTextParagraph().addNewTextRun();

r.setText("Apache POI");

XSLFHyperlink link = r.createHyperlink();

link.setAddress("http://poi.apache.org");

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/featurescomparison/text/hyperlinks/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/text/hyperlinks)

{{% alert color="primary" %}} 

For more details, visit [Creating TextBox with Hyperlink](http://docs.aspose.com:8082/docs/display/slidesjava/Creating+TextBox+with+Hyperlink).

{{% /alert %}}
