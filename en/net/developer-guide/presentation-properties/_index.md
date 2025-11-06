---
title: Manage PowerPoint Presentation Properties in C#
linktitle: Presentation Properties
type: docs
weight: 70
url: /net/presentation-properties/
keywords:
- PowerPoint properties
- presentation properties
- document properties
- built-in properties
- custom properties
- advanced properties
- access properties
- modify properties
- manage properties
- document metadata
- edit metadata
- proofing language
- PowerPoint
- presentation
- C#
- Csharp
- Aspose.Slides for .NET
description: "Learn how to easily manage, read, and edit PowerPoint document properties using Aspose.Slides for .NET in C#. Enhance productivity and automate your workflow!"
---

## **Overview**

Aspose.Slides for .NET supports two types of document properties: **Built-in** and **Custom**. Both of these property types can easily be accessed and managed using the Aspose.Slides for .NET API.

To handle document properties, Aspose.Slides provides the [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) interface, accessible through the [Presentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/documentproperties/) property. Developers can leverage the `Presentation` object's [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) interface to seamlessly read, modify, and manage presentation properties, as shown in the examples below.

{{% alert color="primary" %}} 

Please note that the **Application** and **Producer** fields cannot be modified, as these fields will always display "Aspose Ltd." and "Aspose.Slides for .NET x.x.x".

{{% /alert %}} 

## **Manage Presentation Properties**

Microsoft PowerPoint provides a feature for adding properties to presentation files. These document properties allow useful information to be stored along with the files. There are two types of document properties:

- System-defined (built-in) properties
- User-defined (custom) properties

**Built-in** properties contain general information about the document, such as the document title, author's name, document statistics, and more.

**Custom** properties are defined by users as **Name/Value** pairs, where both the name and the value are user-specified.

Using Aspose.Slides for .NET, developers can access and modify both built-in and custom properties.

Microsoft PowerPoint allows users to manage document properties by clicking the Office icon, then selecting **File → Info → Properties**. After choosing **Advanced Properties**, a dialog appears where you can manage all document properties of the presentation file.

In the **Properties** dialog, there are several tabs, such as **General**, **Summary**, **Statistics**, **Contents**, and **Custom**.
Each tab provides options for configuring specific types of information related to the PowerPoint file. The **Custom** tab is used to manage user-defined properties.

## **Access Built-in Properties**

These properties, as exposed by the [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) interface, include: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (indicates whether the document is shared between different producers), **PresentationFormat**, **Subject**,  **Title**, and more.

```cs
// Instantiate the Presentation class that represents a presentation file.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **Modify Built-in Properties**

Modifying the built-in properties of presentation files is just as easy as accessing them. You can simply assign a string value to any desired property, and the property's value will be updated. In the example below, we demonstrate how to modify the built-in document properties of a presentation file.

```cs
// Instantiate the Presentation class that represents the a presentation file.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Set the Built-in properties.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// Save the presentation to a file.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Add Custom Presentation Properties**

Custom presentation properties enable developers to store additional metadata or specific information within a presentation file. Aspose.Slides makes it easy to create and manage these custom properties programmatically. The following examples demonstrate how to add custom properties to your presentations.

```cs
// Instantiate the Presentation class.
using Presentation presentation = new Presentation();

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Add custom properties.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// Save the presentation to a file.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **Access and Modify Custom Properties**

Aspose.Slides also allows developers to access existing custom properties and modify their values easily. This functionality helps maintain accurate metadata and supports dynamic updates based on user input or business logic. The examples below illustrate how to retrieve and update custom property values within a presentation.

```cs
// Instantiate the Presentation class that represents a PPTX file.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // Display the name and value of the custom property.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // Modify the value of the custom property.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// Save the presentation to a file.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **Live Example**

Try the [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) online app to see how to work with document properties using the Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**How can I remove a built-in property from a presentation?**

Built-in properties are an integral part of the presentation and cannot be removed entirely. However, you can either change their values or set them to empty if allowed by the specific property.

**What happens if I add a custom property that already exists?**

If you add a custom property that already exists, its existing value will be overwritten with the new one. You do not need to remove or check the property beforehand, as Aspose.Slides automatically updates the property's value.

**Can I access presentation properties without fully loading the presentation?**

Yes, you can access presentation properties without fully loading the presentation by using the `GetPresentationInfo` method from the [PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) class. Then, utilize the `ReadDocumentProperties` method provided by the [IPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/) interface to read the properties efficiently, saving memory and improving performance.
