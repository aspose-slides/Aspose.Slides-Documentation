---
title: Manage Smart Art using Aspose.Slides
type: docs
weight: 30
url: /java/manage-smart-art-using-aspose-slides/
---

## **Aspose.Slides - Manage Smart Art**
Aspose.Slides for Java now facilitates to add custom SmartArt shapes in their slides from scratch. In this topic, we will explain how developers can create and access SmartArt shapes using Aspose.Slides for Java.

**Java**

{{< highlight java >}}

 //==================

//Adding Smart Art

//==================

//Instantiate Presentation Class

Presentation pres = new Presentation();

//Get first slide

ISlide slide = pres.getSlides().get_Item(0);

//Add Smart Art Shape

ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

//Saving presentation

pres.save(dataDir + "AsposeSmartArt.pptx", SaveFormat.Pptx);

//=====================

//Accessing Smart Art

//=====================

//Get first slide

ISlide slide0 = pres.getSlides().get_Item(0);

//Traverse through every shape inside first slide

for(IShape shape : slide0.getShapes())

{

    //Check if shape is of SmartArt type

    if (shape instanceof ISmartArt)

    {

        //Typecast shape to SmartArtEx

        ISmartArt smartArt = (ISmartArt)shape;

    }

}

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/smartart/managesmartart/AsposeSmartArt.java)

{{% alert color="primary" %}} 

For more details, visit [Add and Access the SmartArt shape](http://docs.aspose.com:8082/docs/display/slidesjava/Add+and+Access+the+SmartArt+shape).

{{% /alert %}}
