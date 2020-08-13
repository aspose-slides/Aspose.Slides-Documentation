---
title: Manage Smart Art in Aspose.Slides
type: docs
weight: 20
url: /java/manage-smart-art-in-aspose-slides/
---

## **Aspose.Slides - Manage Smart Art**
Aspose.Slides for Java now facilitates to add custom SmartArt shapes in their slides from scratch. In this topic, we will explain how developers can create and access SmartArt shapes using Aspose.Slides for Java.

**Java**

``` java

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

```
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Add and Access the SmartArt shape](http://docs.aspose.com:8082/docs/display/slidesjava/Add+and+Access+the+SmartArt+shape).

{{% /alert %}}
