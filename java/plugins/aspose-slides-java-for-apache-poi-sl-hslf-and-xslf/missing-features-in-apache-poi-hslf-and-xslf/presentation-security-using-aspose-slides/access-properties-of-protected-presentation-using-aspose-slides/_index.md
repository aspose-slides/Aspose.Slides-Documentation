---
title: Access Properties of Protected Presentation using Aspose.Slides
type: docs
weight: 10
url: /java/access-properties-of-protected-presentation-using-aspose-slides/
---

## **Aspose.Slides - Access Properties of Protected Presentation**
Aspose.Slides for Java provides facility to access the **Document Properties** of the presentation in password protected presentation without supplying password using **Presentation** class. It offers few overloaded constructors and we can make use of one of the suitable constructors of **Presentation** class to create its object based on an existing presentation.In the example given below, we are accessing the Document Properties of a password protected presentation. We will using **LoadOptions** class object to set the presentation access properties.

**Java**

{{< highlight java >}}

 //Accessing the Document Properties of a Password Protected Presentation without Password

//creating instance of load options to set the presentation access password

com.aspose.slides.LoadOptions loadOptions = new com.aspose.slides.LoadOptions();

//Setting the access password to null

loadOptions.setPassword (null);

//Setting the access to document properties

loadOptions.setOnlyLoadDocumentProperties (true);

//Opening the presentation file by passing the file path and load options to the constructor of Presentation class

Presentation pres = new Presentation(dataDir + "AsposeProtection-PropAccess.pptx", loadOptions);

//Getting Document Properties

IDocumentProperties docProps = pres.getDocumentProperties();

System.out.println("Properties Count: " + docProps.getCount());

{{< /highlight >}}
## **Download Running Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/releases/view/618722)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/releases/tag/Aspose.Slides_Java_for_Apache_POI-v1.0.0)
## **Download Sample Code**
- [CodePlex](https://asposeslidesjavaapachepoi.codeplex.com/SourceControl/latest#src/main/java/com/aspose/slides/examples/asposefeatures/presentationsecurity/accesspropertiesofprotectedpresentation/AsposeAccessPropertiesOfProtectedFile.java)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/tree/master/Plugins/Aspose_Slides_for_Apache_POI/src/main/java/com/aspose/slides/examples/asposefeatures/presentationsecurity/accesspropertiesofprotectedpresentation/AsposeAccessPropertiesOfProtectedFile.java)

{{% alert color="primary" %}} 

For more details, visit [Accessing the Document Properties of a Password Protected Presentation without Password](http://docs.aspose.com:8082/docs/display/slidesjava/Opening+a+Presentation#OpeningaPresentation-DocumentProperties).

{{% /alert %}}
