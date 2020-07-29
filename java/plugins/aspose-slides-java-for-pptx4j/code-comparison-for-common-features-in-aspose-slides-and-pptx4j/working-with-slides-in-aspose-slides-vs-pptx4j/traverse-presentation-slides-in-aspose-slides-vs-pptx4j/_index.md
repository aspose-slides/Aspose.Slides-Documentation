---
title: Traverse Presentation Slides in Aspose.Slides vs pptx4j
type: docs
weight: 70
url: /java/traverse-presentation-slides-in-aspose-slides-vs-pptx4j/
---

## **Aspose.Slides - Traverse Presentation Slides**
Slides can be traversed on the collection that can be collected using Presentation.getSlides().

**Java**

{{< highlight java >}}

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(dataDir + "presentation.pptx");

//Accessing slides

for (ISlide slide : pres.getSlides())

{

	System.out.println(slide.getSlideNumber());

}

{{< /highlight >}}
## **pptx4j - Traverse Presentation Slides**
This sample is useful if you want to see what objects are used in your document.xml.
This shows a general approach for traversing the JAXB object tree in the Main Document part.
It can also be applied to headers, footers etc.

It is an alternative to XSLT, and doesn't require marshalling/unmarshalling.

**Java**

{{< highlight java >}}

 try

{

	getInputFilePath(args);

}

catch (IllegalArgumentException e)

{

	inputfilepath = dataDir + "pptx-basic.xml";

}

PresentationMLPackage pMLPackage = (PresentationMLPackage) OpcPackage

		.load(new java.io.File(inputfilepath));

SlidePart slide = (SlidePart) pMLPackage.getParts().get(

		new PartName("/ppt/slides/slide1.xml"));

new TraversalUtil(slide.getJaxbElement().getCSld().getSpTree()

		.getSpOrGrpSpOrGraphicFrame(),

new Callback()

{

	String indent = "";

	// @Override

	public List<Object> apply(Object o)

	{

		String text = "";

		try

		{

			System.out.println(indent

					+ o.getClass().getName()

					+ "\n\n"

					+ XmlUtils.marshaltoString(o, true,

							org.pptx4j.jaxb.Context.jcPML));

		}

		catch (RuntimeException me)

		{

			System.out.println(indent + o.getClass().getName());

		}

		if (o instanceof org.pptx4j.pml.Shape)

		{

			CTTextBody txBody = ((org.pptx4j.pml.Shape) o).getTxBody();

			if (txBody != null)

			{

				for (CTTextParagraph tp : txBody.getP())

				{

					System.out.println(indent

							+ tp.getClass().getName()

							+ "\n\n"

							+ XmlUtils

									.marshaltoString(

											tp,

											true,

											true,

											org.pptx4j.jaxb.Context.jcPML,

											"http://schemas.openxmlformats.org/presentationml/2006/main",

											"txBody",

											CTTextParagraph.class));

				}

			}

		}

		return null;

	}

	// @Override

	public boolean shouldTraverse(Object o)

	{

		return true;

	}

	// Depth first

	// @Override

	public void walkJAXBElements(Object parent)

	{

		indent += "    ";

		List children = getChildren(parent);

		if (children != null)

		{

			for (Object o : children)

			{

				// if its wrapped in javax.xml.bind.JAXBElement, get its

				// value

				o = XmlUtils.unwrap(o);

				this.apply(o);

				if (this.shouldTraverse(o))

				{

					walkJAXBElements(o);

				}

			}

		}

		indent = indent.substring(0, indent.length() - 4);

	}

	// @Override

	public List<Object> getChildren(Object o)

	{

		return TraversalUtil.getChildrenImpl(o);

	}

}

);

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Accessing Slides of a Presentation](http://www.aspose.com/docs/display/slidesjava/Accessing+Slides+of+a+Presentation).

{{% /alert %}}
