---
title: Thay đổi API công khai và không tương thích ngược trong Aspose.Slides cho Java 15.1.0
linktitle: Aspose.Slides cho Java 15.1.0
type: docs
weight: 100
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- cách tiếp cận kế thừa
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi gây lỗi trong Aspose.Slides cho Java để di chuyển suôn sẻ các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

This page lists all [được thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) classes, methods, properties and so on, any new restrictions and other [thay đổi](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) introduced with the Aspose.Slides for Java 15.1.0 API.

{{% /alert %}} {{% alert color="primary" %}} 

Có một số vấn đề đã biết với một số ký hiệu hình ảnh và đối tượng WordArt sẽ được sửa trong Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Thay đổi API công khai**
### **Chức năng thay thế phông chữ đã được thêm vào**
Đã thêm khả năng thay thế phông chữ trên toàn bộ bản trình chiếu và tạm thời cho quá trình render.

Phương thức mới getFontsManager() của lớp Presentation đã được giới thiệu. Lớp FontsManager có các thành viên sau:

**IFontSubstRuleCollection getFontSubstRuleList**() method

Đây là tập hợp các thể hiện IFontSubstRule được sử dụng để thay thế phông chữ trong quá trình render. IFontSubstRule có các phương thức getSourceFont() và getDestFont() triển khai giao diện IFontData và phương thức getReplaceFontCondition() cho phép chọn điều kiện thay thế ("WhenInaccessible" hoặc "Always").

**IFontData[] getFonts()** method có thể được sử dụng để lấy tất cả phông chữ được sử dụng trong bản trình chiếu hiện tại.

Các phương thức **replaceFont(...)** có thể được sử dụng để thay thế một phông chữ một cách cố định trong bản trình chiếu.

Ví dụ sau cho thấy cách thay thế một phông chữ trong bản trình chiếu:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Một ví dụ khác, cho thấy việc thay thế phông chữ khi render nếu phông chữ không khả dụng:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// Phông chữ Arial sẽ được sử dụng thay vì SomeRareFont khi không khả dụng

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```