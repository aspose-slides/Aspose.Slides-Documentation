---
title: Thay đổi API công khai và không tương thích ngược trong Aspose.Slides cho Java 15.1.0
linktitle: Aspose.Slides cho Java 15.1.0
type: docs
weight: 100
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- di chuyển
- mã cũ
- mã hiện đại
- cách tiếp cận truyền thống
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides cho Java để chuyển đổi mượt mà các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các [được thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) lớp, phương thức, thuộc tính và những thứ khác, bất kỳ hạn chế mới và các [thay đổi](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) được giới thiệu cùng với Aspose.Slides for Java 15.1.0 API.

{{% /alert %}} {{% alert color="info" %}} 

Có một số vấn đề đã biết với một số dấu đầu dòng hình ảnh và đối tượng WordArt sẽ được khắc phục trong Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Thay đổi API công khai**
### **Chức năng thay thế phông chữ đã được thêm**
Khả năng thay thế phông chữ trên toàn bộ bản trình chiếu và tạm thời cho việc render đã được thêm.

Phương thức mới getFontsManager() của lớp Presentation đã được giới thiệu. Lớp FontsManager có các thành viên sau:

**IFontSubstRuleCollection getFontSubstRuleList**() phương thức

Đây là tập hợp các thể hiện IFontSubstRule được sử dụng để thay thế phông chữ trong quá trình render. IFontSubstRule có các phương thức getSourceFont() và getDestFont() triển khai giao diện IFontData và phương thức getReplaceFontCondition() cho phép chọn điều kiện thay thế ("WhenInaccessible" hoặc "Always").

**IFontData[] getFonts()** phương thức có thể được sử dụng để lấy tất cả phông chữ được sử dụng trong bản trình chiếu hiện tại.

**replaceFont(...)** phương thức có thể được sử dụng để thay thế một phông chữ một cách cố định trong bản trình chiếu.

Ví dụ sau đây cho thấy cách thay thế một phông chữ trong bản trình chiếu:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Một ví dụ khác, cho thấy việc thay thế phông chữ khi render và phông chữ không khả dụng:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // Phông chữ Arial sẽ được sử dụng thay vì SomeRareFont khi không khả dụng.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```