---
title: Định dạng Văn bản Bản trình chiếu trong Java
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/java/text-formatting/
keywords:
- đánh dấu văn bản
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
- tab văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Định dạng và tạo kiểu cho văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Java. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và nhiều hơn nữa."
---
## **Tổng quan**

Bài viết này trình bày cách định dạng văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Java. Nội dung bao gồm việc đánh dấu, màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn văn, hành vi tự động vừa, neo văn bản, vị trí tab và cài đặt ngôn ngữ.

Trong các ví dụ dưới đây, chúng ta sẽ sử dụng tệp có tên “sample.pptx”, chứa một hộp văn bản duy nhất trên slide đầu tiên với nội dung sau:

![Văn bản mẫu](sample_text.png)

## **Đánh dấu văn bản**

Sử dụng phương thức [ITextFrame.highlightText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-) khi bạn cần đánh dấu văn bản trùng với một mẫu cụ thể trong khung văn bản. Phương thức áp dụng màu đánh dấu cho các đoạn văn bản khớp và có thể được dùng cùng với [TextSearchOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textsearchoptions/) để kiểm soát cách tìm kiếm, ví dụ chỉ khớp toàn từ.

Ví dụ mã dưới đây đánh dấu tất cả các lần xuất hiện của chuỗi **"try"** và sau đó chỉ đánh dấu từ đầy đủ **"to"**.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Lấy hình dạng đầu tiên từ slide đầu tiên.
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Đánh dấu từ "try" trong hình dạng.
    shape.getTextFrame().highlightText("try", Color.LIGHT_GRAY);

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Đánh dấu từ "to" trong hình dạng.
    shape.getTextFrame().highlightText("to", Color.MAGENTA, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Văn bản đã được đánh dấu](highlighted_text.png)

## **Đánh dấu văn bản bằng biểu thức chính quy**

Phương thức [ITextFrame.highlightRegex](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) đánh dấu các khớp văn bản được tìm thấy bằng một biểu thức chính quy. Trong Java, API này được khai báo trên [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/).

Ví dụ mã dưới đây đánh dấu tất cả các từ có **bảy ký tự hoặc nhiều hơn**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // Đánh dấu tất cả các từ có bảy ký tự hoặc nhiều hơn.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Văn bản đã được đánh dấu bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Đặt màu nền cho văn bản**

Sử dụng [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) để đặt màu nền mặc định cho một đoạn, hoặc [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) cho các phần văn bản riêng lẻ.

Ví dụ mã sau cho biết cách đặt màu nền cho **toàn đoạn**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt màu nền đánh dấu cho toàn đoạn.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Đoạn màu xám](gray_paragraph.png)

Ví dụ mã dưới đây cho biết cách đặt màu nền cho **các phần văn bản có phông chữ đậm**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Đặt màu nền đánh dấu cho phần văn bản.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các phần văn bản màu xám](gray_text_portions.png)

## **Căn chỉnh đoạn văn bản**

Sử dụng [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) để đặt căn chỉnh đoạn trong một khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, căn đều, v.v.

Ví dụ mã sau cho biết cách căn đoạn **ở giữa**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt căn chỉnh của đoạn thành giữa.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Đoạn đã được căn chỉnh](aligned_paragraph.png)

## **Đặt độ trong suốt cho văn bản**

Độ trong suốt của văn bản được điều khiển thông qua thành phần alpha của màu được gán cho [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Trong các ví dụ dưới đây, `alpha = 50` là giá trị alpha ARGB trên thang 0‑255, không phải phần trăm độ trong suốt.

Ví dụ mã sau cho biết cách áp dụng độ trong suốt cho **toàn đoạn**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt màu nền của văn bản thành màu trong suốt.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Đoạn trong suốt](transparent_paragraph.png)

Ví dụ mã dưới đây cho biết cách áp dụng độ trong suốt cho **các phần văn bản có phông chữ đậm**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Đặt độ trong suốt cho phần văn bản.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
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

Sử dụng [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản.

Ví dụ Java sau cho biết cách mở rộng khoảng cách ký tự trong **toàn đoạn**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Lưu ý: Sử dụng giá trị âm để giảm khoảng cách ký tự.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Mở rộng khoảng cách ký tự.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Khoảng cách ký tự trong đoạn](character_spacing_in_paragraph.png)

Ví dụ mã dưới đây cho biết cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông chữ đậm**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Lưu ý: Sử dụng giá trị âm để giảm khoảng cách ký tự.
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

### **Vô hiệu hoá kerning cho các phông chữ cụ thể**

Trong một số trường hợp, văn bản được render bằng Aspose.Slides có thể trông hơi chặt hơn so với cùng văn bản hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chữ đó chứa thông tin kerning hợp lệ và kerning được bật trong cài đặt PowerPoint.

Để làm cho kết quả render gần hơn với PowerPoint trong những trường hợp này, bạn có thể vô hiệu hoá kerning cho các phần văn bản sử dụng phông chữ bị ảnh hưởng. Đặt [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) thành một giá trị lớn hơn đáng kể so với kích thước phông chữ thực tế:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Cài đặt này ngăn kerning được áp dụng cho các phần văn bản khớp và có thể giúp đồng bộ việc render của Aspose.Slides với đầu ra hình ảnh của PowerPoint đối với các phông chữ bị ảnh hưởng bởi hành vi đặc thù này của PowerPoint.

## **Quản lý thuộc tính phông chữ của văn bản**

Các thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) hoặc ở mức phần riêng lẻ thông qua [IPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportionformat/).

Mã sau đặt phông chữ và kiểu văn bản cho toàn đoạn: áp dụng cỡ phông, in đậm, in nghiêng, gạch chân chấm và phông Times New Roman cho tất cả các phần trong đoạn.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt các thuộc tính phông chữ cho đoạn.
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

![Thuộc tính phông chữ cho đoạn](font_properties_for_paragraph.png)

Ví dụ mã dưới đây áp dụng các thuộc tính tương tự cho **các phần văn bản có phông chữ đậm**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

## **Đặt góc xoay cho văn bản**

Sử dụng [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) để đặt hướng văn bản được định sẵn trong một hình.

Mã sau đặt hướng văn bản trong hình thành `Vertical270`, xoay văn bản **90 độ ngược chiều kim đồng hồ**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Góc xoay văn bản](text_rotation.png)

## **Đặt góc xoay tùy chỉnh cho khung văn bản**

Sử dụng [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) để đặt góc xoay tùy chỉnh cho một [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/).

Mã sau xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Góc xoay tùy chỉnh cho văn bản](custom_text_rotation.png)

## **Đặt khoảng cách dòng cho các đoạn**

Aspose.Slides cung cấp [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) và [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) để điều khiển khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Dùng giá trị dương để chỉ định khoảng cách dòng theo phần trăm chiều cao dòng.
* Dùng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Mã sau cho biết cách chỉ định khoảng cách dòng trong đoạn:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Khoảng cách dòng trong đoạn](line_spacing.png)

## **Đặt kiểu tự động vừa cho khung văn bản**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) xác định cách văn bản xử lý khi vượt quá giới hạn của vùng chứa. Sử dụng nó để điều khiển việc văn bản co lại, tràn hay tự động thay đổi kích thước hình.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt neo cho khung văn bản**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) xác định cách văn bản được định vị theo chiều dọc bên trong một hình, ví dụ ở trên, giữa hoặc dưới.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt tab cho văn bản**

Sử dụng [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) và [IParagraphFormat.getTabs](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#getTabs--) để cấu hình các vị trí tab trong một đoạn.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các tab trong đoạn](paragraph_tabs.png)

## **Đặt ngôn ngữ kiểm tra chính tả**

Aspose.Slides cung cấp [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ này quyết định ngôn ngữ được sử dụng cho kiểm tra chính tả và ngữ pháp trong PowerPoint.

Mã sau cho biết cách đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Đặt Id của ngôn ngữ kiểm tra chính tả.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt ngôn ngữ mặc định**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) để xác định ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo một bản trình chiếu.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một hình chữ nhật mới có văn bản.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Kiểm tra ngôn ngữ của phần văn bản đầu tiên.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Đặt kiểu văn bản mặc định**

Để áp dụng định dạng văn bản mặc định ở cấp độ bản trình chiếu, sử dụng [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Mã sau cho biết cách đặt phông chữ đậm mặc định kích thước 14 pt cho tất cả văn bản trên các slide trong một bản trình chiếu mới.

```java
Presentation presentation = new Presentation();
try {
    // Lấy định dạng đoạn cấp cao nhất.
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

## **Trích xuất văn bản với hiệu ứng All‑Caps**

Trong PowerPoint, áp dụng hiệu ứng phông **All Caps** làm cho văn bản hiển thị bằng chữ hoa trên slide ngay cả khi ban đầu nhập bằng chữ thường. Khi bạn lấy phần văn bản như vậy bằng Aspose.Slides, thư viện sẽ trả về văn bản đúng như khi nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textcaptype/) và chuyển chuỗi trả về sang chữ hoa khi giá trị là `All`.

Giả sử chúng ta có hộp văn bản sau trên slide đầu tiên của tệp sample2.pptx.

![Hiệu ứng All Caps](all_caps_effect.png)

Mã sau cho biết cách trích xuất văn bản với hiệu ứng **All Caps** đã được áp dụng:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

**Làm sao để chỉnh sửa văn bản trong bảng trên slide?**

Để chỉnh sửa văn bản trong bảng trên slide, sử dụng [ITable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itable/). Duyệt qua các ô và cập nhật mỗi ô qua [ICell.getTextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icell/#getTextFrame--) và định dạng đoạn qua [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Làm sao để áp dụng màu gradient cho văn bản trong slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Đặt [IFillFormat.setFillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifillformat/#setFillType-byte-) thành [FillType.Gradient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.