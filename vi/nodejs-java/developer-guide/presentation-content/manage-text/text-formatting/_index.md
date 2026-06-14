---
title: Định dạng văn bản bản trình chiếu trong JavaScript
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/nodejs-java/text-formatting/
keywords:
- làm nổi bật văn bản
- biểu thức chính quy
- căn chỉnh đoạn
- kiểu văn bản
- nền văn bản
- độ trong suốt văn bản
- khoảng cách ký tự
- thuộc tính phông chữ
- họ phông chữ
- xoay văn bản
- góc xoay
- khung văn bản
- khoảng cách dòng
- thuộc tính tự động vừa
- neo khung văn bản
- căn tab văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Định dạng và tạo kiểu văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng cách sử dụng Aspose.Slides cho Node.js qua Java. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và nhiều hơn nữa."
---
## **Tổng quan**

Bài viết này hướng dẫn cách định dạng văn bản trong các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js thông qua Java. Nội dung bao gồm làm nổi bật, màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn, hành vi tự động vừa, neo văn bản, ngắt tab và cài đặt ngôn ngữ.

Trong các ví dụ dưới đây, chúng tôi sẽ sử dụng tệp có tên “sample.pptx”, chứa một hộp văn bản duy nhất trên slide đầu tiên với nội dung sau:

![Văn bản mẫu](sample_text.png)

## **Làm nổi bật văn bản**

Sử dụng phương thức [TextFrame.highlightText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-) khi bạn cần làm nổi bật văn bản khớp với một mẫu cụ thể trong khung văn bản. Phương thức này áp dụng màu nền cho các đoạn văn bản khớp và có thể được sử dụng cùng với [TextSearchOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textsearchoptions/) để kiểm soát cách tìm kiếm, ví dụ chỉ khớp toàn từ.

Mã ví dụ dưới đây làm nổi bật tất cả các lần xuất hiện của ký tự **"try"** và sau đó chỉ làm nổi bật từ đầy đủ **"to"**.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // Làm nổi bật từ "try" trong hình dạng.
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Làm nổi bật từ "to" trong hình dạng.
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Văn bản được làm nổi bật](highlighted_text.png)

## **Làm nổi bật văn bản bằng biểu thức chính quy**

Phương thức [TextFrame.highlightRegex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-) làm nổi bật các khớp văn bản được tìm bởi một biểu thức chính quy. Trong Node.js qua Java, API này được cung cấp trên [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/).

Mã ví dụ dưới đây làm nổi bật tất cả các từ có **bảy ký tự trở lên**:

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // Làm nổi bật tất cả các từ có bảy ký tự trở lên.
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Văn bản được làm nổi bật bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Đặt màu nền cho văn bản**

Sử dụng [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) để đặt màu nền mặc định cho một đoạn, hoặc sử dụng [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portionformat/#getHighlightColor--) cho các phần văn bản riêng lẻ.

Mã ví dụ sau cho thấy cách đặt màu nền cho **toàn bộ đoạn**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt màu làm nổi bật cho toàn bộ đoạn.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Đoạn màu xám](gray_paragraph.png)

Mã ví dụ dưới đây minh họa cách đặt màu nền cho **các phần văn bản có phông chữ đậm**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Đặt màu làm nổi bật cho phần văn bản.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các phần văn bản màu xám](gray_text_portions.png)

## **Căn chỉnh các đoạn văn bản**

Sử dụng [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-) để đặt căn chỉnh đoạn trong khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, căn đều, v.v.

Mã ví dụ sau cho thấy cách căn đoạn về **giữa**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt căn chỉnh đoạn về trung tâm.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Đoạn được căn chỉnh](aligned_paragraph.png)

## **Đặt độ trong suốt cho văn bản**

Độ trong suốt của văn bản được kiểm soát qua thành phần alpha của màu được chỉ định cho [PortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portionformat/#getFillFormat--). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0‑255, không phải là phần trăm trong suốt.

Mã ví dụ dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Đặt màu nền của văn bản thành màu trong suốt.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Đoạn trong suốt](transparent_paragraph.png)

Mã ví dụ sau cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông chữ đậm**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Đặt độ trong suốt của phần văn bản.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các phần văn bản trong suốt](transparent_text_portions.png)

## **Đặt khoảng cách ký tự cho văn bản**

Sử dụng [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản.

Mã JavaScript sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Mở rộng khoảng cách ký tự.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Khoảng cách ký tự trong đoạn](character_spacing_in_paragraph.png)

Mã ví dụ dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông chữ đậm**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
            portion.getPortionFormat().setSpacing(3); // Mở rộng khoảng cách ký tự.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Khoảng cách ký tự trong các phần văn bản](character_spacing_in_text_portions.png)

### **Vô hiệu hóa Kerning cho các phông chữ cụ thể**

Trong một số trường hợp, văn bản được Aspose.Slides render có thể trông chặt hơn một chút so với cùng văn bản được hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chữ chứa thông tin kerning hợp lệ và kerning đã được bật trong cài đặt PowerPoint.

Để làm cho kết quả render gần với PowerPoint hơn trong các trường hợp này, bạn có thể vô hiệu hóa kerning cho các phần văn bản sử dụng phông chữ bị ảnh hưởng. Đặt [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) thành một giá trị lớn hơn đáng kể so với kích thước phông chữ thực tế:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Cài đặt này ngăn kerning được áp dụng cho các phần văn bản khớp và có thể giúp đồng bộ việc render của Aspose.Slides với đầu ra hình ảnh của PowerPoint cho các phông chữ bị ảnh hưởng bởi hành vi đặc thù này.

## **Quản lý thuộc tính phông chữ văn bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) hoặc trên từng phần riêng lẻ thông qua [PortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portionformat/).

Mã sau đặt phông chữ và kiểu văn bản cho toàn bộ đoạn: nó áp dụng kích thước phông chữ, in đậm, in nghiêng, gạch chân chấm và phông Times New Roman cho tất cả các phần trong đoạn.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Đặt các thuộc tính phông chữ cho đoạn.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Thuộc tính phông chữ của đoạn](font_properties_for_paragraph.png)

Mã ví dụ dưới đây áp dụng các thuộc tính tương tự cho **các phần văn bản có phông chữ đậm**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Đặt các thuộc tính phông chữ cho phần văn bản.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Thuộc tính phông chữ của các phần văn bản](font_properties_for_text_portions.png)

## **Đặt xoay văn bản**

Sử dụng [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) để đặt hướng văn bản định sẵn trong một hình dạng.

Mã ví dụ sau đặt hướng văn bản trong hình dạng thành `Vertical270`, xoay văn bản **90 độ ngược chiều kim đồng hồ**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Xoay văn bản](text_rotation.png)

## **Đặt xoay tùy chỉnh cho khung văn bản**

Sử dụng [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) để đặt góc xoay tùy chỉnh cho một [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/).

Mã ví dụ dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình dạng:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Xoay văn bản tùy chỉnh](custom_text_rotation.png)

## **Đặt khoảng cách dòng cho các đoạn**

Aspose.Slides cung cấp [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) và [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) để kiểm soát khoảng cách đoạn. Các thuộc tính này được dùng như sau:

* Sử dụng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm của chiều cao dòng.
* Sử dụng giá trị âm để chỉ định khoảng cách dòng theo điểm.

Mã ví dụ sau cho thấy cách chỉ định khoảng cách dòng trong đoạn:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Khoảng cách dòng trong đoạn](line_spacing.png)

## **Đặt loại tự động vừa cho khung văn bản**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) xác định cách văn bản hành xử khi vượt quá giới hạn của khung chứa. Sử dụng nó để kiểm soát việc văn bản co lại, tràn ra ngoài hoặc tự động thay đổi kích thước hình dạng.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt neo cho khung văn bản**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) xác định cách văn bản được đặt vị trí theo chiều dọc trong một hình dạng, ví dụ ở trên cùng, giữa hoặc dưới cùng.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt tab cho văn bản**

Sử dụng [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) và [ParagraphFormat.getTabs](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraphformat/#getTabs--) để cấu hình các điểm dừng tab trong một đoạn.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các tab của đoạn](paragraph_tabs.png)

## **Đặt ngôn ngữ kiểm tra chính tả**

Aspose.Slides cung cấp [PortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ này xác định ngôn ngữ được dùng để kiểm tra chính tả và ngữ pháp trong PowerPoint.

Mã ví dụ sau cho thấy cách đặt ngôn ngữ kiểm tra cho một phần văn bản:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Đặt Id của ngôn ngữ kiểm tra.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt ngôn ngữ mặc định**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) để xác định ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo một bài thuyết trình.

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Thêm một hình chữ nhật mới có văn bản.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Kiểm tra ngôn ngữ của phần văn bản đầu tiên.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Đặt kiểu văn bản mặc định**

Để áp dụng định dạng văn bản mặc định ở mức bài thuyết trình, sử dụng [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

Mã ví dụ dưới đây cho thấy cách đặt phông chữ đậm mặc định kích thước 14 pt cho tất cả văn bản trên các slide trong một bài thuyết trình mới.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    // Lấy định dạng đoạn cấp cao nhất.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trích xuất văn bản với hiệu ứng viết hoa toàn bộ**

Trong PowerPoint, áp dụng hiệu ứng **All Caps** khiến văn bản hiển thị ở dạng chữ hoa trên slide ngay cả khi ban đầu được gõ bằng chữ thường. Khi bạn lấy một phần văn bản như vậy bằng Aspose.Slides, thư viện sẽ trả về văn bản nguyên gốc. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textcaptype/) và chuyển chuỗi trả về sang chữ hoa khi giá trị là `All`.

Giả sử chúng ta có hộp văn bản sau trên slide đầu tiên của tệp sample2.pptx.

![Hiệu ứng All Caps](all_caps_effect.png)

Mã ví dụ dưới đây cho thấy cách trích xuất văn bản có hiệu ứng **All Caps** được áp dụng:

```javascript
const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Kết quả:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Câu hỏi thường gặp**

**Làm thế nào để sửa đổi văn bản trong bảng trên một slide?**

Để sửa đổi văn bản trong bảng trên một slide, sử dụng [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/table/). Duyệt qua các ô và cập nhật mỗi ô thông qua [Cell.getTextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cell/#getTextFrame--) và định dạng đoạn qua [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**Làm thế nào để áp dụng màu gradient cho văn bản trong slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [PortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portionformat/#getFillFormat--). Đặt [FillFormat.setFillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) thành [FillType.Gradient](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.