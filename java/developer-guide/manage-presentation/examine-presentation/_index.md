---
title: Examine Presentation
type: docs
weight: 30
url: /java/examine-presentation/

---

Aspose.Slides for Java allows you to examine a presentation to find out its properties and understand its behavior. 

{{% alert title="TIP" color="dark" %}} 

The [PresentationInfo](https://apireference.aspose.com/slides/java/com.aspose.slides/PresentationInfo) class contains most of the properties and methods needed for operations here. 

{{% /alert %}} 

## **Checking a Presentation Format**

Before working on a presentation, you may want to find out what format (PPT, PPTX, ODP, and others) the presentation is in at the moment.

You can check a presentation's format without loading the presentation. See this sample code:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Getting the Properties of a Presentation**

This sample code in Java shows you how to get a presentation’s properties (information about the presentation):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

## **Updating the Properties of a Presentation**

Aspose.Slides provides the [PresentationInfo.updateDocumentProperties](https://apireference.aspose.com/slides/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) method that allows you to make changes to a presentation’s properties.

This sample code shows you how to edit the properties for a presentation in Java:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");

IDocumentProperties props = info.readDocumentProperties();
props.setTitle("My title");
info.updateDocumentProperties(props);
```

### **Useful Links**

To get more information about a presentation and its security attributes, you may find these links useful:

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)