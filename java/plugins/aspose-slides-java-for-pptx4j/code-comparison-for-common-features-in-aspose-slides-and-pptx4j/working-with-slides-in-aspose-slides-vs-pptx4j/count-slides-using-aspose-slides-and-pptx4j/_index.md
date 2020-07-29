---
title: Count Slides using Aspose.Slides and pptx4j
type: docs
weight: 30
url: /java/count-slides-using-aspose-slides-and-pptx4j/
---

## **Aspose.Slides - Count Slides**
**Java**

{{< highlight java >}}

 Presentation pres = new Presentation(dataPath + "presentation.pptx");

System.out.println("Total Slides in Presentation: " + pres.getSlides().size());

{{< /highlight >}}
## **pptx4j - Count Slides**
**Java**

{{< highlight java >}}

 PresentationMLPackage presentationMLPackage = (PresentationMLPackage)OpcPackage.load(new java.io.File(inputfilepath));

System.out.println("Total Slides: " + presentationMLPackage.getMainPresentationPart().getSlideCount());

{{< /highlight >}}
## **Download Running Code**
Download running examples for **Count Slides** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Source Code**
Download source code for **Count Slides** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Working with Slides](http://www.aspose.com/docs/display/slidesjava/Working+with+Slides+in+Presentation).

{{% /alert %}}
