---
title: Examine Presentation
type: docs
weight: 30
url: /cpp/examine-presentation/

---

Aspose.Slides for C++ allows you to examine a presentation to find out its properties and understand its behavior. 

{{% alert title="Info" color="info" %}}

The [PresentationInfo](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation_info) class contains most of the methods needed for operations here. 

{{% /alert %}} 

## **Checking a Presentation Format**

Before working on a presentation, you may want to find out what format (PPT, PPTX, ODP, and others) the presentation is in at the moment.

You can check a presentation's format without loading the presentation. See this sample code:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Getting the Properties of a Presentation**

This sample code in C++ shows you how to get a presentation’s properties (information about the presentation):

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **Updating the Properties of a Presentation**

Aspose.Slides provides the [PresentationInfo::UpdateDocumentProperties()](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation_info#ac9fce3667003cdb8bf05816c589a6f88) method that allows you to make changes to a presentation’s properties.

This sample code shows you how to edit the properties for a presentation in C++:

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");

auto props = info->ReadDocumentProperties();
props->set_Title(u"My title");
info->UpdateDocumentProperties(props);
```

### **Useful Links**

To get more information about a presentation and its security attributes, you may find these links useful:

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)