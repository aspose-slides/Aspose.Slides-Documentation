---
title: Định dạng văn bản trình chiếu trên Android
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/androidjava/text-formatting/
keywords:
- làm nổi bật văn bản
- biểu thức chính quy
- căn đoạn
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
- tab văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Định dạng và tạo kiểu cho văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Android thông qua Java. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và nhiều hơn nữa."
---
## **Tổng quan**

Bài viết này mô tả cách định dạng văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Android thông qua Java. Nội dung bao gồm làm nổi bật, màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn, hành vi tự động vừa, neo văn bản, tab stops và cài đặt ngôn ngữ.

Trong các ví dụ dưới đây, chúng tôi sẽ sử dụng một tệp có tên “sample.pptx”, trong đó có một hộp văn bản đơn trên slide đầu tiên với nội dung sau:

![Văn bản mẫu](sample_text.png)

## **Đánh dấu văn bản**

Sử dụng phương thức [ITextFrame.highlightText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.lang.Integer-) khi bạn cần làm nổi bật văn bản khớp với một mẫu cụ thể trong một khung văn bản. Phương thức này áp dụng màu nền cho các đoạn văn bản khớp và có thể được sử dụng cùng với [ITextSearchOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextSearchOptions) để kiểm soát cách tìm kiếm, ví dụ như chỉ khớp toàn bộ từ.

Đoạn mã dưới đây làm nổi bật tất cả các lần xuất hiện của ký tự **"try"** và sau đó chỉ làm nổi bật toàn bộ từ **"to"**.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Lấy hình dạng đầu tiên từ slide đầu tiên.
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Làm nổi bật từ "try" trong hình dạng.
    shape.getTextFrame().highlightText("try", Color.rgb(173, 216, 230));

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Làm nổi bật từ "to" trong hình dạng.
    int violetColor = Color.rgb(238, 130, 238);
    shape.getTextFrame().highlightText("to", violetColor, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Văn bản đã được đánh dấu](highlighted_text.png)

## **Đánh dấu văn bản bằng biểu thức chính quy**

Phương thức [ITextFrame.highlightRegex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) làm nổi bật các kết quả khớp tìm được bằng biểu thức chính quy.

Đoạn mã dưới đây làm nổi bật tất cả các từ có **bảy ký tự trở lên**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // Làm nổi bật tất cả các từ có bảy ký tự hoặc nhiều hơn.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Văn bản đã được đánh dấu bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Đặt màu nền cho văn bản**

Sử dụng [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) để đặt màu nền mặc định cho một đoạn, hoặc sử dụng [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IBasePortionFormat#getHighlightColor--) cho các phần văn bản riêng lẻ.

Đoạn mã sau cho thấy cách đặt màu nền cho **toàn bộ đoạn**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt màu nền cho toàn bộ đoạn.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Đoạn văn màu xám](gray_paragraph.png)

Đoạn mã dưới đây minh họa cách đặt màu nền cho **các phần văn bản có phông đậm**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Đặt màu nền cho phần văn bản.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các phần văn bản màu xám](gray_text_portions.png)

## **Căn chỉnh các đoạn văn bản**

Sử dụng [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IParagraphFormat#setAlignment-byte-) để đặt căn chỉnh đoạn trong một khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, căn đều, v.v.

Đoạn mã sau cho thấy cách căn đoạn về **giữa**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt căn chỉnh của đoạn văn thành trung tâm.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Đoạn văn đã được căn chỉnh](aligned_paragraph.png)

## **Đặt độ trong suốt cho văn bản**

Độ trong suốt của văn bản được kiểm soát thông qua thành phần alpha của màu được gán cho [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0‑255, không phải phần trăm độ trong suốt.

Đoạn mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt màu nền của văn bản thành màu trong suốt.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Đoạn văn trong suốt](transparent_paragraph.png)

Đoạn mã sau cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông đậm**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Đặt độ trong suốt của phần văn bản.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các phần văn bản trong suốt](transparent_text_portions.png)

## **Đặt khoảng cách ký tự cho văn bản**

Sử dụng [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IBasePortionFormat#setSpacing-float-) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản.

Đoạn mã Java sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Mở rộng khoảng cách ký tự.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Khoảng cách ký tự trong đoạn văn](character_spacing_in_paragraph.png)

Đoạn mã dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông đậm**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
            portion.getPortionFormat().setSpacing(3); // Mở rộng khoảng cách ký tự.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Khoảng cách ký tự trong các phần văn bản](character_spacing_in_text_portions.png)

### **Tắt kerning cho các phông chữ cụ thể**

Trong một số trường hợp, văn bản được render bởi Aspose.Slides có thể trông hơi chặt hơn so với cùng văn bản hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chữ chứa thông tin kerning hợp lệ và kerning được bật trong cài đặt PowerPoint.

Để làm cho kết quả render gần hơn với PowerPoint trong các trường hợp này, bạn có thể tắt kerning cho các phần văn bản sử dụng phông chữ bị ảnh hưởng. Đặt [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IBasePortionFormat#setKerningMinimalSize-float-) thành giá trị lớn hơn đáng kể so với kích thước phông chữ thực tế:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (int paragraphIndex = 0; paragraphIndex < autoShape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

        for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            IFontData latinFont = portion.getPortionFormat().getLatinFont();
            IFontData eastAsianFont = portion.getPortionFormat().getEastAsianFont();
            IFontData complexScriptFont = portion.getPortionFormat().getComplexScriptFont();

            boolean usesTargetFont =
                    latinFont != null && targetFont.equals(latinFont.getFontName()) ||
                    eastAsianFont != null && targetFont.equals(eastAsianFont.getFontName()) ||
                    complexScriptFont != null && targetFont.equals(complexScriptFont.getFontName());

            if (usesTargetFont) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Cài đặt này ngăn kerning được áp dụng cho các phần văn bản khớp và có thể giúp đồng nhất việc render của Aspose.Slides với đầu ra trực quan của PowerPoint đối với các phông chữ bị ảnh hưởng bởi hành vi đặc thù này của PowerPoint.

## **Quản lý thuộc tính phông chữ văn bản**

Các thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) hoặc trên từng phần thông qua [IPortionFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPortionFormat).

Đoạn mã sau đặt phông chữ và kiểu văn bản cho toàn bộ đoạn: nó áp dụng kích thước phông, in đậm, in nghiêng, gạch chân chấm và phông Times New Roman cho tất cả các phần trong đoạn.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt các thuộc tính phông chữ cho đoạn văn.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Thuộc tính phông chữ cho đoạn văn](font_properties_for_paragraph.png)

Đoạn mã dưới đây áp dụng các thuộc tính tương tự cho **các phần văn bản có phông đậm**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Đặt các thuộc tính phông chữ cho phần văn bản.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Thuộc tính phông chữ cho các phần văn bản](font_properties_for_text_portions.png)

## **Đặt xoay văn bản**

Sử dụng [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-) để đặt hướng văn bản định sẵn trong một hình dạng.

Đoạn mã sau đặt hướng văn bản trong hình dạng thành `Vertical270`, làm cho văn bản quay **90 độ ngược chiều kim đồng hồ**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Xoay văn bản](text_rotation.png)

## **Đặt xoay tùy chỉnh cho khung văn bản**

Sử dụng [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) để đặt góc xoay tùy chỉnh cho một [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrame).

Đoạn mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình dạng:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Xoay văn bản tùy chỉnh](custom_text_rotation.png)

## **Đặt khoảng cách dòng cho các đoạn văn**

Aspose.Slides cung cấp các phương thức [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IParagraphFormat#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IParagraphFormat#setSpaceBefore-float-) và [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IParagraphFormat#setSpaceWithin-float-) để kiểm soát khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Sử dụng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm của chiều cao dòng.
* Sử dụng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Đoạn mã sau cho thấy cách chỉ định khoảng cách dòng trong đoạn:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Khoảng cách dòng trong đoạn văn](line_spacing.png)

## **Đặt loại tự động vừa cho khung văn bản**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) xác định cách văn bản hành xử khi vượt quá giới hạn của container. Sử dụng nó để kiểm soát việc văn bản co lại, tràn hoặc tự động thay đổi kích thước hình dạng.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt neo cho khung văn bản**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) xác định cách văn bản được đặt vị trí theo chiều dọc bên trong một hình dạng, ví dụ ở trên, giữa hoặc dưới.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt tabulation cho văn bản**

Sử dụng [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IParagraphFormat#setDefaultTabSize-float-) và [IParagraphFormat.getTabs](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IParagraphFormat#getTabs--) để cấu hình các vị trí tab trong một đoạn.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các tab trong đoạn văn](paragraph_tabs.png)

## **Đặt ngôn ngữ kiểm tra chính tả**

Aspose.Slides cung cấp [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ này xác định ngôn ngữ được dùng cho việc kiểm tra chính tả và ngữ pháp trong PowerPoint.

Đoạn mã sau cho thấy cách đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Đặt ID của ngôn ngữ kiểm tra chính tả.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt ngôn ngữ mặc định**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/LoadOptions#setDefaultTextLanguage-java.lang.String-) để xác định ngôn ngữ mặc định cho văn bản được tạo trong khi tải hoặc tạo một bản trình chiếu.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một hình chữ nhật mới với văn bản.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Kiểm tra ngôn ngữ của phần đầu tiên.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Đặt kiểu văn bản mặc định**

Để áp dụng định dạng văn bản mặc định ở mức bản trình chiếu, sử dụng [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IPresentation#getDefaultTextStyle--).

Đoạn mã dưới đây cho thấy cách đặt phông chữ đậm mặc định với kích thước 14 pt cho tất cả văn bản trên các slide trong một bản trình chiếu mới.

```java
Presentation presentation = new Presentation();
try {
    // Lấy định dạng đoạn văn cấp cao nhất.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trích xuất văn bản với hiệu ứng chữ HOA**

Trong PowerPoint, áp dụng hiệu ứng **All Caps** khiến văn bản hiển thị dưới dạng chữ hoa trên slide ngay cả khi nó được gõ bằng chữ thường. Khi bạn lấy phần văn bản như vậy bằng Aspose.Slides, thư viện sẽ trả về văn bản chính xác như khi nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/TextCapType) và chuyển chuỗi trả về thành chữ hoa khi giá trị là `All`.

Giả sử chúng ta có hộp văn bản sau trên slide đầu tiên của tệp sample2.pptx.

![Hiệu ứng All Caps](all_caps_effect.png)

Đoạn mã dưới đây cho thấy cách trích xuất văn bản có hiệu ứng **All Caps** được áp dụng:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
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

**Làm thế nào để chỉnh sửa văn bản trong bảng trên một slide?**

Để chỉnh sửa văn bản trong bảng trên một slide, sử dụng [ITable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITable). Duyệt qua các ô và cập nhật mỗi ô thông qua [ICell.getTextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ICell#getTextFrame--) và định dạng đoạn qua [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IParagraph#getParagraphFormat--).

**Làm thế nào để áp dụng màu gradient cho văn bản trong một slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--). Đặt [IFillFormat.setFillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IFillFormat#setFillType-int-) thành [FillType.Gradient](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FillType) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.