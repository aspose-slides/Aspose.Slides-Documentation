---
title: Create New Presentation using Apache POI and Aspose.Slides
type: docs
weight: 30
url: /java/create-new-presentation-using-apache-poi-and-aspose-slides/
---

## **Aspose.Slides - New Presentation**
The [Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/com.aspose.slides.Presentation+class) class holds a presentation's content. Whether creating a presentation from scratch or modifying an existing one, when finished, you want to save the presentation. With Aspose.Slides for Java, it can be saved as a **file** or **stream**

**Java**

{{< highlight java >}}

 //Instantiate a Presentation object that represents a PPT file

Presentation pres = new Presentation();

//Writing the presentation as a PPT file

pres.write(dataDir + "NewPPT_Aspose.ppt");

{{< /highlight >}}
## **Apache POI SL - HSLF XSLF - New Presentation**
SlideShow class create new presentation using Apache POI SL - HSLF and XSLF

**Java**

{{< highlight java >}}

 //create a new empty slide show

SlideShow ppt = new SlideShow();

//add first slide

Slide s1 = ppt.createSlide();

//save changes in a file

FileOutputStream out = new FileOutputStream(dataDir + "NewPPT_Apache.ppt");

ppt.write(out);

out.close();

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/featurescomparison/presentation/createnewpresentation/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/featurescomparison/presentation/createnewpresentation)

{{% alert color="primary" %}} 

For more details, visit [Saving a Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Saving+a+Presentation).

{{% /alert %}}
