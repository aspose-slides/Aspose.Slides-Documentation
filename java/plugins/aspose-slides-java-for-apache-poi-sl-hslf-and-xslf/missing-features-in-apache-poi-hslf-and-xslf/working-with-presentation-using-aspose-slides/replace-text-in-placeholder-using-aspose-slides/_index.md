---
title: Replace Text in Placeholder using Aspose.Slides
type: docs
weight: 20
url: /java/replace-text-in-placeholder-using-aspose-slides/
---

## **Aspose.Slides - Replace Text in Placeholder**
Using Aspose.Slides for Java , developers can also find and modify a specific **Placeholder** present in a slide. In this topic, we are going to demonstrate with the help of an example that how the text contained inside a **Placeholder** can be replaced or modified using Aspose.Slides for Java.

**Java**

{{< highlight java >}}

 //Instantiate Presentation class that represents PPTX

Presentation pres = new Presentation(dataDir + "demo.pptx");

//Access first slide

ISlide slide = pres.getSlides().get_Item(0);

IShape shape= null;

//Iterate through the shapes and set a reference to the table found

for (int i = 0 ; i < slide.getShapes().size() ; i++)

{

    shape = slide.getShapes().get_Item(i);

    if (shape.getPlaceholder() != null)

    {

        //Change the text of each placeholder

        ((IAutoShape)shape).getTextFrame().setText("This is Placeholder");

    }

}

//Write the PPTX to Disk

pres.save(dataDir + "AsposeReplaceTxt.pptx",SaveFormat.Pptx);

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/presentation/replacetxtinplaceholders/AsposeReplaceTxtInPlaceHolders.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/presentation/replacetxtinplaceholders/AsposeReplaceTxtInPlaceHolders.java)

{{% alert color="primary" %}} 

For more details, visit [Replacing Text in a Placeholder](http://docs.aspose.com:8082/docs/display/slidesjava/Replacing+Text+in+a+Placeholder).

{{% /alert %}}
