---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 14.2.0
linktitle: Aspose.Slides cho .NET 14.2.0
type: docs
weight: 40
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- di chuyển
- mã legacy
- mã hiện đại
- phương pháp legacy
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và các thay đổi không tương thích trong Aspose.Slides cho .NET để di chuyển suôn sẻ các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
## **API công khai và các thay đổi không tương thích ngược**
{{% alert color="primary" %}} 

Chúng tôi đã thực hiện một số thay đổi trong API Aspose.Slides cho .NET 14.2.0. Một số thuộc tính và phương thức đã bị loại bỏ và một số đã được chuyển sang không gian tên khác.

{{% /alert %}} 
### **Các phương thức Aspose.Slides.IPresentation.Write(…) đã bị loại bỏ**
Các phương thức này chỉ ghi các đối tượng Presentation thành tệp định dạng PPTX. Trong API mới, lớp Presentation được dùng để làm việc với mọi định dạng. Có thể sử dụng các phương thức Presentation.Save(…) để lưu các đối tượng Presentation sang mọi định dạng được hỗ trợ.
### **Các lớp liên quan đến kiểu Theme đã được chuyển sang không gian tên Aspose.Slides.Theme**
Các lớp sau đã được chuyển từ không gian tên Aspose.Slides sang không gian tên Aspose.Slides.Theme.

- Kiểu ColorScheme
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
### **Thay đổi so với Aspose.Slides cho .NET 8.X.0**
Các tính năng Aspose.Slides cho .NET 8.4 đã được thêm vào Aspose.Slides cho .NET 14.2.0