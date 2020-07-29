---
title: Get Shapes from Presentation Slide using Apache POI and Aspose.Slides
type: docs
weight: 10
url: /java/get-shapes-from-presentation-slide-using-apache-poi-and-aspose-slides/
---

## **Aspose.Slides - Get Shapes from Presentation Slide**
Aspose.Slides for Java supports adding different kinds of shapes to the slides. Using Aspose.Slides for Java , developers can not only create simple lines , but some fancy lines can also be drawn on the slides. These shapes can be obtained using Slide.getShapes in ShapeCollection class.

**Java**

{{< highlight java >}}

 ISlide slide =  pres.getSlides().get_Item(0);

//Accessing source slide shape collection

IShapeCollection sourceShapes = slide.getShapes();

//Iterating through all shapes inside the slide

for (int i = 0; i < sourceShapes.size(); i++)

{

	System.out.println(sourceShapes.get_Item(i).getWidth() +  " x " +

			sourceShapes.get_Item(i).getHeight());

}

{{< /highlight >}}
## **Apache POI SL - HSLF XSLF - Get Shapes from Presentation Slide**
XSLFSlide.getShapes can return all shapes available in the slide of presentation using Apache POI SL - HSLF XSLF.

**Java**

{{< highlight java >}}

 XSLFSlide[] slide = ppt.getSlides();

for (int i = 0; i < slide.length; i++)

{

	XSLFShape[] sh = slide[i].getShapes();

	for (int j = 0; j < sh.length; j++)

	{

		// name of the shape

		String name = sh[j].getShapeName();

		// shapes's anchor which defines the position of this shape in

		// the slide

		java.awt.geom.Rectangle2D anchor = sh[j].getAnchor();

		if (sh[j] instanceof XSLFConnectorShape)

		{

			XSLFConnectorShape line = (XSLFConnectorShape) sh[j];

			System.out.println("Connector Shape.");

			// work with Line

		}

		else if (sh[j] instanceof XSLFTextShape)

		{

			XSLFTextShape shape = (XSLFTextShape) sh[j];

			System.out.println("Text Shape.");

			// work with a shape that can hold text

		}

		else if (sh[j] instanceof XSLFPictureShape)

		{

			XSLFPictureShape shape = (XSLFPictureShape) sh[j];

			System.out.println("Picture Shape.");

			// work with Picture

		}

	}

}

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/featurescomparison/presentation/getshapesfromslides/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/presentation/getshapesfromslides)

{{% alert color="primary" %}} 

For more details, visit [Working with Shapes](http://docs.aspose.com:8082/docs/display/slidesjava/Working+with+Shapes).

{{% /alert %}}
