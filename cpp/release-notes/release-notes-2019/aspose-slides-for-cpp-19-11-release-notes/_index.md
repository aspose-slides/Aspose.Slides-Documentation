---
title: Aspose.Slides for CPP 19.11 Release Notes
type: docs
weight: 20
url: /cpp/aspose-slides-for-cpp-19-11-release-notes/
---

{{% alert color="primary" %}} 

This page contains release notes for[ Aspose.Slides for C++ 19.11](https://www.nuget.org/packages/Aspose.Slides.CPP/)

{{% /alert %}} 
## **Supported Platforms**
- Aspose.Slides for C++ for Windows (Microsoft Visual C++)
- Aspose.Slides for C++ for Linux (Clang)



|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|SLIDESCPP-1821|[Use Aspose.Slides for .NET 19.11 features](https://docs.aspose.com/display/slidesnet/Aspose.Slides+for+.NET+19.11+Release+Notes)|Feature|
|SLIDESNET-39130|[Improve handling of embedded OLE objects in Presentation](/slides/cpp/shape-manipulations/#shapemanipulations-extractembeddedfilesfromoleobject)|Feature|
|SLIDESNET-41401|Text get overlapped in generated shape thumbnail|Enhancement|
|SLIDESNET-41340|Chart become image on cloning shape|Enhancement|
## **Public API Changes**

### **Obsolete methods AddFromSvg() have been deleted**
Methods **System::SharedPtr<IPPImage> AddFromSvg(System::String svgContent)** and

**System::SharedPtr<IPPImage> AddFromSvg(System::String svgContent, System::SharedPtr<Import::IExternalResourceResolver> externalResResolver, System::String baseUri)**

have been removed from **ImageCollection** class and corresponding **IImageCollection** interface.

Please use [**AddImage(System::SharedPtr<ISvgImage> svgImage)**](https://apireference.aspose.com/cpp/slides/class/aspose.slides.i_image_collection/#a6a806a0d01d16bb78e60625f3d5a6e4f) method instead.


