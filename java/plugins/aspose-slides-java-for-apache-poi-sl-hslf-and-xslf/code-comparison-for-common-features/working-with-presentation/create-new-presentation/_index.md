---
title: Create New Presentation using Apache POI and Aspose.Slides
type: docs
weight: 30
url: /java/slides-poi/create-new-presentation/
---

## **Aspose.Slides - New Presentation**
The [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class holds a presentation's content. Whether creating a presentation from scratch or modifying an existing one, when finished, you want to save the presentation. With Aspose.Slides for Java, it can be saved as a **file** or **stream**.

```java
//Instantiate a Presentation object that represents a PPT file
Presentation pres = new Presentation();

//Writing the presentation as a PPT file
pres.write("NewPPT_Aspose.ppt");
```

## **Apache POI SL - HSLF XSLF - New Presentation**
SlideShow class create new presentation using Apache POI SL - HSLF and XSLF

```java
//create a new empty slide show
SlideShow ppt = new SlideShow();

//add first slide
Slide s1 = ppt.createSlide();

//save changes in a file
FileOutputStream out = new FileOutputStream("NewPPT_Apache.ppt");
ppt.write(out);
out.close();
```

## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)

## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/presentation/createnewpresentation)

{{% alert color="primary" %}} 

For more details, visit [Saving a Presentation](https://docs.aspose.com/slides/java/save-presentation/).

{{% /alert %}}
