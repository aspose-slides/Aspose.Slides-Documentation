---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 15.1.0
linktitle: Aspose.Slides cho .NET 15.1.0
type: docs
weight: 130
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- di chuyển
- mã lặn
- mã hiện đại
- cách tiếp cận lặn
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và các thay đổi gây lỗi trong Aspose.Slides cho .NET để di chuyển suôn sẻ các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính đã [được thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) hoặc [đã xóa](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) và các thay đổi khác được giới thiệu cùng API Aspose.Slides for .NET 15.1.0.

{{% /alert %}} 
## **Thay đổi API công khai**
#### **Chức năng Thay thế Phông chữ đã được thêm**
Đã thêm khả năng thay thế phông chữ toàn cục trong toàn bộ bản trình chiếu và tạm thời cho việc render.

Thuộc tính mới "FontsManager" của lớp Presentation đã được giới thiệu. Lớp FontsManager có các thành viên sau:

**IFontSubstRuleCollection FontSubstRuleList** Thuộc tính

Bộ sưu tập này của các thể hiện IFontSubstRule được sử dụng để thay thế phông chữ trong quá trình render. IFontSubstRule có các thuộc tính SourceFont và DestFont triển khai giao diện IFontData và thuộc tính ReplaceFontCondition cho phép chọn điều kiện thay thế ("WhenInaccessible" hoặc "Always").

**IFontData[] GetFonts()** Phương thức

Được sử dụng để lấy tất cả phông chữ được sử dụng trong bản trình chiếu hiện tại.

**ReplaceFont** Phương thức

Được sử dụng để thay thế phông chữ một cách cố định trong bản trình chiếu.

Ví dụ sau cho thấy cách thay thế phông chữ trong bản trình chiếu:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Ví dụ khác, minh họa việc thay thế phông chữ cho render khi không khả dụng:

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Phông chữ Arial sẽ được sử dụng thay vì SomeRareFont khi không khả dụng

            pres.Slides[0].GetImage();

```