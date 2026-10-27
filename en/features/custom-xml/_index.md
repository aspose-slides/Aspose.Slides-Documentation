---
title: Work with custom XML parts
description: Store and edit custom XML data within a presentation.
type: docs
url: /features/custom-xml/
weight: 540
feature_id: custom-xml
feature_group: slides
translationKey: slides-feature-custom-xml
feature_catalogue_version: 3
feature_guides:
- /slides/net/managing-tags-and-custom-data/
---

## **Overview**

Attach application-specific XML to a presentation or slide and read it back later. Custom XML parts can hold structured data that your workflow needs without placing that data in visible slide text. You can update the XML payload or remove a part when it is no longer needed.

## **Usage example (C# / .NET)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example.

This C# example stores an application record as a presentation-level XML part. The data is saved inside the PPTX without adding visible text or shapes; your application can read it again when reopening the file.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var xml = "<report xmlns=\"urn:example:report\"><recordId>R-42</recordId></report>";
presentation.CustomData.CustomXmlParts.Add(xml);
presentation.Save("custom-xml.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Does custom XML appear on the slide?**

It is stored as document data. Your application decides whether to use it to create visible text, shapes or other content.

### **How are custom XML parts different from presentation tags?**

Tags store simple name/value metadata. Custom XML parts hold a structured XML payload, which is useful for nested records or data governed by an XML schema.

### **Can I attach custom XML to an individual shape?**

Yes. Add the part to the shape’s custom-data collection when the data belongs to one shape. The presentation, slide and shape scopes have separate associations.

## **Guides**

- [Manage Tags and Custom Data in Presentations in .NET](/slides/net/managing-tags-and-custom-data/)

Related feature: [Add custom document properties](/slides/features/custom-properties/).
