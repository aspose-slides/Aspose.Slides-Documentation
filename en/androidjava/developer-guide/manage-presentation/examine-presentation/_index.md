---
title: Retrieve and Update Presentation Information on Android
linktitle: Presentation Information
type: docs
weight: 30
url: /androidjava/examine-presentation/
keywords:
- presentation format
- presentation properties
- document properties
- get properties
- read properties
- change properties
- modify properties
- update properties
- examine PPTX
- examine PPT
- examine ODP
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Explore slides, structure and metadata in PowerPoint and OpenDocument presentations using Java for faster insights and smarter content audits."
---

Aspose.Slides for Android via Java allows you to examine a presentation to find out its properties and understand its behavior.

{{% alert title="Info" color="info" %}} 

The [PresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo) and [DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/) classes contain the properties and methods used in operations here.

{{% /alert %}} 

## **Check a Presentation Format**

Before working on a presentation, you may want to find out what format (PPT, PPTX, ODP, and others) the presentation is in at the moment.

You can check a presentation's format without loading the presentation. See this Java code:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Get Presentation Properties**

This Java code shows you how to get presentation properties (information about the presentation):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

You may want to see the [properties under the DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) class.

## **Update Presentation Properties**

Aspose.Slides provides the [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) method that allows you to make changes to presentation properties.

Let's say we have a PowerPoint presentation with the document properties shown below.

![Original document properties of the PowerPoint presentation](input_properties.png)

This code example shows you how to edit some presentation properties:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

The results of changing the document properties are shown below.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Useful Links**

To get more information about a presentation and its security attributes, you may find these links useful:

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Checking whether a Presentation is Password Protected Before Loading it](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).