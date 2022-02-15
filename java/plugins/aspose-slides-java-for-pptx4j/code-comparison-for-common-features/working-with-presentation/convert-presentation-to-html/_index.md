---
title: Convert Presentation to HTML in Aspose.Slides vs pptx4j
type: docs
weight: 10
url: /java/convert-presentation-to-html-in-aspose-slides-vs-pptx4j/
---

## **Aspose.Slides - Convert Presentation to HTML**
HTML is one of several widely used format for exchanging data. Aspose.Slides for Java provides support for converting a presentation to HTML which is an embedded SVG.

The Save method exposed by the [Presentation](http://www.aspose.com/docs/display/slidesjava/com.aspose.slides.Presentation+class) class can be used to convert the whole presentation into a HTML document.

Saving a PowerPoint presentation to HTML is a two-line process with Aspose.Slides for Java. Simply open the presentation and save it out to HTML.

**Java**

{{< highlight java >}}

 //Instantiate Presentation class that represents PPTX file

Presentation pres = new Presentation(dataDir + "presentation.pptx");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("",false));

//Saving the presentation to HTML

pres.save(dataDir + "AsposeHTML.html", SaveFormat.Html, htmlOpt);

{{< /highlight >}}
## **pptx4j - Convert Presentation to HTML**
pptx4j module of docx4j allows to convert presentations to HTML format. Below available is the sample to show the method.

**Java**

{{< highlight java >}}

 String inputfilepath = dataDir + "pptx-basic.xml";

// Where to save images

SvgExporter.setImageDirPath(dataPath);

PresentationMLPackage presentationMLPackage =

	(PresentationMLPackage)PresentationMLPackage.load(new java.io.File(inputfilepath));

// TODO - render slides in document order!

Iterator partIterator = presentationMLPackage.getParts().getParts().entrySet().iterator();

while (partIterator.hasNext()) {

    Map.Entry pairs = (Map.Entry)partIterator.next();

    Part p = (Part)pairs.getValue();

    if (p instanceof SlidePart) {

    	System.out.println(

    			SvgExporter.svg(presentationMLPackage, (SlidePart)p)

    			);

    }

}

// NB: file suffix must end with .xhtml in order to see the SVG in a browser

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://archive.codeplex.com/?p=asposeslidesjavapptx4j)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://archive.codeplex.com/?p=asposeslidesjavapptx4j)

{{% alert color="primary" %}} 

For more details, visit [Converting Presentation to HTML](/slides/java/convert-presentation/#converting-presentation-to-html).

{{% /alert %}}
