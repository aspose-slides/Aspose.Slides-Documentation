---
title: API Công khai và Các Thay đổi Không Tương thích Ngược trong Aspose.Slides cho .NET 14.2.0
linktitle: Aspose.Slides cho .NET 14.2.0
type: docs
weight: 40
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- phương pháp kế thừa
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và các thay đổi gây gián đoạn trong Aspose.Slides cho .NET để di chuyển một cách suôn sẻ các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
## **API Công khai và Các Thay Đổi Không Tương Thích Ngược**
{{% alert color="info" %}} 

Chúng tôi đã thực hiện một số thay đổi trong API Aspose.Slides cho .NET 14.2.0. Một số thuộc tính và phương thức đã bị loại bỏ và một số đã được chuyển sang namespace khác.

{{% /alert %}} 
### **Các phương thức Aspose.Slides.IPresentation.Write(…) đã bị loại bỏ**
Các phương thức này chỉ ghi các đối tượng Presentation vào tệp định dạng PPTX. Trong API mới, lớp Presentation được dùng để làm việc với mọi định dạng. Bạn có thể sử dụng các phương thức Presentation.Save(…) để lưu các đối tượng Presentation sang tất cả các định dạng được hỗ trợ.
### **Các lớp liên quan đến Kiểu Chủ Đề đã được chuyển sang namespace Aspose.Slides.Theme**
Các lớp sau đã được chuyển từ namespace Aspose.Slides sang namespace Aspose.Slides.Theme.

- Types ColorScheme
- EffectStyle
- EffectStyleCollection
- EffectStyleCollectionEffectiveData
- ExtraColorSchemeCollection
- ExtraColorSchemeCollection
- ExtraColorScheme
- FillFormatCollection
- FillFormatCollectionEffectiveData
- FontScheme
- FontSchemeEffectiveData
- FormatScheme
- IColorScheme
- IEffectStyle
- IEffectStyleCollection
- IEffectStyleCollectionEffectiveData
- IEffectStyleEffectiveData
- IExtraColorScheme
- IExtraColorSchemeCollection
- IFillFormatCollection
- IFillFormatCollectionEffectiveData
- IFontScheme
- IFontSchemeEffectiveData
- IFormatScheme
- ILineFormatCollection
- ILineFormatCollectionEffectiveData
### **Các thay đổi so với Aspose.Slides cho .NET 8.X.0**
Các tính năng của Aspose.Slides cho .NET 8.4 đã được thêm vào Aspose.Slides cho .NET 14.2.0