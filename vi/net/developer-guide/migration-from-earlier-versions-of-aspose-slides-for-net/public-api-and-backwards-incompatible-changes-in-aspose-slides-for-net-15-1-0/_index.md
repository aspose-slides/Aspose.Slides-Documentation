---
title: API công cộng và các thay đổi không tương thích ngược trong Aspose.Slides for .NET 15.1.0
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- di chuyển
- mã legacy
- mã hiện đại
- cách tiếp cận legacy
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xem xét các cập nhật API công cộng và các thay đổi gây gián đoạn trong Aspose.Slides cho .NET để dễ dàng di chuyển các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 
Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các thành phần khác đã được [added](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) hoặc [removed](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/), và các thay đổi khác được giới thiệu trong API Aspose.Slides for .NET 15.1.0.
{{% /alert %}} 
## **Thay đổi API công cộng**
#### **Chức năng Thay thế Phông chữ đã được bổ sung**
Đã thêm khả năng thay thế phông chữ toàn cầu trên toàn bộ bản trình chiếu và tạm thời khi render.

Đã giới thiệu thuộc tính mới "FontsManager" của lớp Presentation. Lớp FontsManager có các thành viên sau:

**IFontSubstRuleCollection FontSubstRuleList** Property
Bộ sưu tập này gồm các thực thể IFontSubstRule được dùng để thay thế phông chữ khi render. IFontSubstRule có các thuộc tính SourceFont và DestFont triển khai giao diện IFontData và thuộc tính ReplaceFontCondition cho phép chọn điều kiện thay thế ("WhenInaccessible" hoặc "Always").

**IFontData[] GetFonts()** Method
Được sử dụng để lấy tất cả phông chữ đang được sử dụng trong bản trình chiếu hiện tại.

**ReplaceFont** Methods
Được sử dụng để thay thế phông chữ một cách cố định trong bản trình chiếu.

Ví dụ sau cho thấy cách thay thế phông chữ trong bản trình chiếu:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Một ví dụ khác, minh họa việc thay thế phông chữ khi render và phông chữ không khả dụng:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Phông chữ Arial sẽ được sử dụng thay cho SomeRareFont khi không khả dụng

            pres.Slides[0].GetThumbnail();

```