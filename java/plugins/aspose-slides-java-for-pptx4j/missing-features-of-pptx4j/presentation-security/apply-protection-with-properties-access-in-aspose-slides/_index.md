---
title: Apply Protection with Properties Access in Aspose.Slides
type: docs
weight: 20
url: /java/apply-protection-with-properties-access-in-aspose-slides/
---

## **Aspose.Slides - Apply Protection with Properties Access**
It's possible to save presentations with password protection. But in that case access to the presentation's document properties is also prohibited. Aspose.Slides offers a mechanism for password protecting a presentation but still being able to access the document properties in PowerPoint.

The [Presentation](http://docs.aspose.com:8082/docs/display/slidesjava/com.aspose.slides.Presentation+class) exposes the EncryptDocumentProperties property that takes a Boolean value to allow or disallow access to the document properties in password protected mode. By default, its value is set to true. The Presentation class also exposes the Encrypt method which sets the presentation's password. To do this, simply pass the password to the Encrypt method and then use the Save method exposed by the Presentation class as a string to save the presentation method.

**Java**

``` java

 //Instantiate a Presentation object that represents a PPT file

Presentation pres = new Presentation();

//Setting access to document properties in password protected mode

pres.getProtectionManager().setEncryptDocumentProperties ( false);

//Setting Password

pres.getProtectionManager().encrypt("pass");

```
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/releases)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java)
- [CodePlex](https://asposeslidesjavapptx4j.codeplex.com/)

{{% alert color="primary" %}} 

For more details, visit [Saving a Password Protected Presentation with Read Access to Document Properties](http://docs.aspose.com:8082/docs/display/slidesjava/Saving+a+Presentation#SavingaPresentation-documentproperties).

{{% /alert %}}
