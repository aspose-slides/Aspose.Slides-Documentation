---
title: Apply Protection with Properties Access using Aspose.Slides
type: docs
weight: 30
url: /java/apply-protection-with-properties-access-using-aspose-slides/
---

## **Aspose.Slides - Apply Protection with Properties Access**
t's possible to save presentations with password protection. But in that case access to the presentation's document properties is also prohibited. Aspose.Slides offers a mechanism for password protecting a presentation but still being able to access the document properties in PowerPoint.

The [Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/com.aspose.slides.Presentation+class) exposes the EncryptDocumentProperties property that takes a Boolean value to allow or disallow access to the document properties in password protected mode. By default, its value is set to true. The Presentation class also exposes the Encrypt method which sets the presentation's password. To do this, simply pass the password to the Encrypt method and then use the Save method exposed by the Presentation class as a string to save the presentation method.

**Java**

{{< highlight java >}}

 //Instantiate a Presentation object that represents a PPT file

Presentation pres = new Presentation();

//Setting access to document properties in password protected mode

pres.getProtectionManager().setEncryptDocumentProperties ( false);

//Setting Password

pres.getProtectionManager().encrypt("pass");


{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/presentationsecurity/protectionwithpropertiesaccess/AsposeApplyProtectionwithPropertiesAccess.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/presentationsecurity/protectionwithpropertiesaccess/AsposeApplyProtectionwithPropertiesAccess.java)

{{% alert color="primary" %}} 

For more details, visit [Saving a Password Protected Presentation with Read Access to Document Properties](http://docs.aspose.com:8082/docs/display/slidesjava/Saving+a+Presentation#SavingaPresentation-documentproperties).

{{% /alert %}}
