---
title: Nâng cao bài thuyết trình của bạn với AutoFit trong JavaScript
linktitle: Cài đặt Autofit
type: docs
weight: 30
url: /vi/nodejs-java/manage-autofit-settings/
keywords:
- hộp văn bản
- autofit
- không tự động điều chỉnh
- vừa văn bản
- thu nhỏ văn bản
- bọc văn bản
- thay đổi kích thước hình
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các cài đặt AutoFit trong Aspose.Slides cho Node.js để tối ưu hiển thị văn bản trong các bản trình chiếu PowerPoint và OpenDocument và cải thiện khả năng đọc nội dung."
---
## **Giới thiệu**

Mặc định, khi bạn thêm một hộp văn bản, Microsoft PowerPoint sử dụng cài đặt **Resize shape to fix text** cho hộp văn bản — nó tự động thay đổi kích thước hộp văn bản để đảm bảo văn bản luôn vừa vào trong.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Khi văn bản trong hộp văn bản trở nên dài hơn hoặc lớn hơn, PowerPoint tự động mở rộng hộp văn bản — tăng chiều cao — để cho phép chứa thêm văn bản. 
* Khi văn bản trong hộp văn bản trở nên ngắn hơn hoặc nhỏ hơn, PowerPoint tự động thu nhỏ hộp văn bản — giảm chiều cao — để loại bỏ không gian thừa. 

Trong PowerPoint, có 4 tham số hoặc tùy chọn quan trọng điều khiển hành vi autofit cho hộp văn bản:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java cung cấp các tùy chọn tương tự — một số thuộc tính trong lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat) — cho phép bạn điều khiển hành vi autofit cho các hộp văn bản trong bản trình chiếu.

## **Thay đổi kích thước hình để vừa văn bản**

Nếu bạn muốn văn bản trong một hộp luôn vừa với hộp đó sau khi thay đổi nội dung, bạn phải sử dụng tùy chọn **Resize shape to fix text**. Để chỉ định cài đặt này, gọi phương thức [setAutofitType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat) với giá trị `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Đoạn mã JavaScript sau cho bạn thấy cách chỉ định rằng văn bản luôn phải vừa trong hộp của nó trong một bản trình chiếu PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Nếu văn bản trở nên dài hơn hoặc lớn hơn, hộp văn bản sẽ tự động thay đổi kích thước (tăng chiều cao) để đảm bảo toàn bộ văn bản vừa vào trong. Nếu văn bản trở nên ngắn hơn, quá trình ngược lại sẽ diễn ra.

## **Không tự động điều chỉnh**

Nếu bạn muốn một hộp văn bản hoặc hình dạng giữ nguyên kích thước bất kể các thay đổi nội dung, bạn phải sử dụng tùy chọn **Do not Autofit**. Để chỉ định cài đặt này, gọi phương thức [setAutofitType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat) với giá trị `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Đoạn mã JavaScript sau cho bạn thấy cách chỉ định rằng một hộp văn bản luôn phải giữ nguyên kích thước trong một bản trình chiếu PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Khi văn bản quá dài so với hộp, nó sẽ tràn ra ngoài.

## **Thu nhỏ văn bản khi tràn**

Nếu một đoạn văn bản trở nên quá dài so với hộp, thông qua tùy chọn **Shrink text on overflow**, bạn có thể chỉ định kích thước và khoảng cách của văn bản phải được giảm xuống để vừa với hộp. Để chỉ định cài đặt này, gọi phương thức [setAutofitType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat) với giá trị `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Đoạn mã JavaScript sau cho bạn thấy cách chỉ định rằng văn bản phải được thu nhỏ khi tràn trong một bản trình chiếu PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
Khi sử dụng tùy chọn **Shrink text on overflow**, cài đặt chỉ được áp dụng khi văn bản trở nên quá dài so với hộp của nó.
{{% /alert %}}

## **Bọc văn bản**

Nếu bạn muốn văn bản trong một hình dạng được bọc bên trong hình khi văn bản vượt ra ngoài viền (chỉ chiều rộng) của hình, bạn phải sử dụng tham số **Wrap text in shape**. Để chỉ định cài đặt này, bạn cần gọi phương thức [setWrapText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrameFormat) với giá trị `true`.

Đoạn mã JavaScript sau cho bạn thấy cách sử dụng cài đặt Wrap Text trong một bản trình chiếu PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
Nếu bạn gọi phương thức `setWrapText` với giá trị `False` cho một hình, khi văn bản bên trong hình dài hơn chiều rộng của hình, văn bản sẽ kéo dài ra ngoài biên của hình trên một dòng duy nhất. 
{{% /alert %}}

## **Câu hỏi thường gặp**

**Do the text frame’s internal margins affect AutoFit?**  
Có. Khoảng đệm (margin nội bộ) làm giảm diện tích sử dụng cho văn bản, do đó AutoFit sẽ kích hoạt sớm hơn — thu nhỏ phông chữ hoặc thay đổi kích thước hình sớm hơn. Kiểm tra và điều chỉnh margin trước khi tinh chỉnh AutoFit.

**How does AutoFit interact with manual and soft line breaks?**  
Các ngắt dòng bắt buộc vẫn được giữ nguyên, và AutoFit sẽ điều chỉnh kích thước phông chữ và khoảng cách xung quanh chúng. Loại bỏ các ngắt không cần thiết thường giảm độ mạnh của việc AutoFit phải thu nhỏ văn bản.

**Does changing the theme font or triggering font substitution affect AutoFit results?**  
Có. Thay thế bằng một phông chữ có các chỉ số glyph khác nhau làm thay đổi chiều rộng/chiều cao của văn bản, điều này có thể thay đổi kích thước phông chữ cuối cùng và cách bọc dòng. Sau bất kỳ thay đổi hoặc thay thế phông chữ nào, hãy kiểm tra lại các slide.