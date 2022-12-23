---
title: Examine Presentation
type: docs
weight: 30
url: /net/examine-presentation/
keywords: "Check PowerPoint, PPTX, PPT, Check Presentation, PowerPoint Properties, Presentation Properties, C#, Csharp, .NET"
description: "Check and get PowerPoint Presentation Properties in C# or .NET"
---

Aspose.Slides for .NET allows you to examine a presentation to find out its properties and understand its behavior. 

{{% alert title="Info" color="info" %}} 

The [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) and [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) classes contains most of the properties and methods needed for operations here. 

{{% /alert %}} 

## **Check a Presentation Format**

Before working on a presentation, you may want to find out what format (PPT, PPTX, ODP, and others) the presentation is in at the moment.

You can check a presentation's format without loading the presentation. See this C# code:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Get a Presentation Properties**

This C# code shows you how to get a presentation’s properties (information about the presentation):

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

You may want to see the [properties under the DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties) class.

## **Update a Presentation Properties**

Aspose.Slides provides the [PresentationInfoUpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) method that allows you to make changes to a presentation’s properties.

This C# code shows you how to edit a presentation's properties:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");

IDocumentProperties props = info.ReadDocumentProperties();
props.Title = "My title";
info.UpdateDocumentProperties(props);
```

### **Useful Links**

To get more information about a presentation and its security attributes, you may find these links useful:

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Checking whether a presentation is password protected before loading it](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).