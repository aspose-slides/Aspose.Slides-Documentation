---
title: Apply Password Protection using Aspose.Slides
type: docs
weight: 20
url: /java/apply-password-protection-using-aspose-slides/
---

## **Aspose.Slides - Apply Password Protection**
It's possible to save presentations with password protection. The [Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/com.aspose.slides.Presentation+class) class exposes theEncrypt method which sets a password for the presentation. To do this, simply pass the password to the Encrypt method and then use the Save method exposed by the Presentation class as a string to save the presentation.

**Java**

{{< highlight java >}}

 //Instantiate a Presentation object that represents a PPT file

Presentation pres = new Presentation();

//Setting Password

pres.getProtectionManager().encrypt("pass");

//Save your presentation to a file

pres.save(dataDir + "AsposeProtection.pptx", com.aspose.slides.SaveFormat.Pptx);

{{< /highlight >}}
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/presentationsecurity/passwordprotection/AsposeApplyPasswordProtection.java)

{{% alert color="primary" %}} 

For more details, visit [Saving a Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/Saving+a+Presentation#SavingaPresentation-protection).

{{% /alert %}}
