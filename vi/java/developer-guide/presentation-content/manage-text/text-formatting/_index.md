---
title: Định dạng Văn bản Trình chiếu trong Java
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/java/text-formatting/
keywords:
- căn chỉnh đoạn văn
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
- Java
- Aspose.Slides
description: "Định dạng và tạo kiểu văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Java. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và nhiều hơn nữa."
---
## **Tổng quan**

Bài viết này trình bày cách định dạng văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides for Java. Nó bao gồm màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn văn, hành vi tự động vừa, neo văn bản, dừng tab và cài đặt ngôn ngữ.

Trong các ví dụ dưới đây, chúng tôi sẽ sử dụng tệp có tên "sample.pptx", chứa một hộp văn bản duy nhất trên slide đầu tiên với văn bản sau:

![Văn bản mẫu](sample_text.png)

Để tìm và làm nổi bật văn bản nguyên thủy hoặc các kết quả khớp biểu thức chính quy, xem [Tìm và Thay thế Văn bản](/slides/vi/java/search-and-replace-text/).

## **Đặt màu nền cho văn bản**

Sử dụng [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) để đặt màu làm nổi bật mặc định cho một đoạn văn, hoặc sử dụng [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) cho các phần văn bản riêng lẻ.

Ví dụ mã dưới đây cho thấy cách đặt màu nền cho **toàn bộ đoạn văn**:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt màu tô sáng cho toàn bộ đoạn văn.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Đoạn văn màu xám](gray_paragraph.png)

Ví dụ mã dưới đây cho thấy cách đặt màu nền cho **các phần văn bản có phông chữ đậm**:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Đặt màu tô sáng cho phần văn bản.
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

## **Căn chỉnh các đoạn văn bản**

Sử dụng [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) để đặt căn chỉnh đoạn trong khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, căn đều, v.v.

Ví dụ mã dưới đây cho thấy cách căn chỉnh đoạn văn về **giữa**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt căn chỉnh của đoạn văn về trung tâm.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Đoạn văn đã căn chỉnh](aligned_paragraph.png)

## **Đặt độ trong suốt cho văn bản**

Độ trong suốt của văn bản được điều khiển qua thành phần alpha của màu được gán cho [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Trong các ví dụ dưới đây, `alpha = 50` là giá trị alpha‑channel ARGB trên thang 0–255, không phải phần trăm độ trong suốt.

Ví dụ mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn văn**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

![Đoạn văn trong suốt](transparent_paragraph.png)

Ví dụ mã dưới đây cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông chữ đậm**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Ví dụ Java dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn văn**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Ví dụ mã dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông chữ đậm**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

### **Vô hiệu hóa Kerning cho các phông chữ cụ thể**

Trong một số trường hợp, văn bản được render bởi Aspose.Slides có thể trông chặt hơn một chút so với văn bản hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chữ chứa thông tin kerning hợp lệ và kerning đã được bật trong cài đặt PowerPoint.

Để làm cho kết quả render gần hơn với PowerPoint trong những trường hợp như vậy, bạn có thể vô hiệu hóa kerning cho các phần văn bản sử dụng phông chữ bị ảnh hưởng. Đặt [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) thành một giá trị lớn hơn đáng kể so với kích thước phông chữ thực tế:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Cài đặt này ngăn kerning được áp dụng cho các phần văn bản khớp và có thể giúp đồng bộ render của Aspose.Slides với đầu ra trực quan của PowerPoint cho các phông chữ bị ảnh hưởng bởi hành vi riêng của PowerPoint này.

## **Quản lý thuộc tính phông chữ của văn bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) hoặc trên từng phần thông qua [IPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportionformat/).

Mã dưới đây đặt phông chữ và kiểu văn bản cho toàn bộ đoạn: nó áp dụng kích thước phông, đậm, nghiêng, gạch chân chấm và phông Times New Roman cho mọi phần trong đoạn.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Ví dụ mã dưới đây áp dụng các thuộc tính tương tự cho **các phần văn bản có phông chữ đậm**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

## **Đặt xoay văn bản**

Sử dụng [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) để đặt định hướng văn bản được định nghĩa sẵn trong một hình dạng.

Ví dụ mã dưới đây đặt định hướng văn bản trong hình dạng thành `Vertical270`, xoay văn bản **90 độ ngược chiều kim đồng hồ**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Xoay văn bản](text_rotation.png)

## **Đặt xoay tùy chỉnh cho khung văn bản**

Sử dụng [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) để đặt góc xoay tùy chỉnh cho một [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/).

Ví dụ mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình dạng:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Xoay tùy chỉnh cho văn bản](custom_text_rotation.png)

## **Đặt khoảng cách dòng cho các đoạn văn**

Aspose.Slides cung cấp [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) và [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) để điều khiển khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Sử dụng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm của chiều cao dòng.
* Sử dụng giá trị âm để chỉ định khoảng cách dòng tính bằng điểm.

Ví dụ mã dưới đây cho thấy cách chỉ định khoảng cách dòng trong đoạn:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) xác định cách văn bản hành xử khi vượt quá giới hạn của vùng chứa. Sử dụng nó để kiểm soát việc văn bản thu nhỏ, tràn ra ngoài hay tự động thay đổi kích thước hình dạng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt neo cho khung văn bản**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) xác định cách văn bản được đặt vị trí theo chiều dọc bên trong một hình dạng, ví dụ ở trên, giữa hoặc dưới.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt tab cho văn bản**

Sử dụng [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) và [IParagraphFormat.getTabs](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#getTabs--) để cấu hình các vị trí dừng tab trong một đoạn.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các tab của đoạn văn](paragraph_tabs.png)

## **Đặt ngôn ngữ kiểm tra chính tả**

Aspose.Slides cung cấp [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ này quyết định ngôn ngữ được dùng cho kiểm tra chính tả và ngữ pháp trong PowerPoint.

Ví dụ mã dưới đây cho thấy cách đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Đặt Id của ngôn ngữ kiểm tra chính tả.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt ngôn ngữ mặc định**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) để xác định ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo một bản trình chiếu.

```java
import com.aspose.slides.*;

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

Ví dụ mã dưới đây cho thấy cách đặt phông chữ đậm mặc định với kích thước 14 pt cho mọi văn bản trên tất cả các slide trong một bản trình chiếu mới.

```java
import com.aspose.slides.*;

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

## **Trích xuất văn bản với hiệu ứng All Caps**

Trong PowerPoint, áp dụng hiệu ứng **All Caps** làm cho văn bản hiển thị ở dạng chữ hoa trên slide ngay cả khi nó được gõ ban đầu bằng chữ thường. Khi bạn lấy phần văn bản đó bằng Aspose.Slides, thư viện sẽ trả về văn bản đúng như khi nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textcaptype/) và chuyển chuỗi trả về sang chữ hoa khi giá trị là `All`.

Giả sử chúng ta có hộp văn bản sau trên slide đầu tiên của tệp sample2.pptx.

![Hiệu ứng All Caps](all_caps_effect.png)

Ví dụ mã dưới đây cho thấy cách trích xuất văn bản với hiệu ứng **All Caps** đã được áp dụng:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

**Làm thế nào để sửa đổi văn bản trong bảng trên một slide?**

Để sửa đổi văn bản trong bảng trên một slide, sử dụng [ITable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itable/). Duyệt qua các ô và cập nhật mỗi ô thông qua [ICell.getTextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icell/#getTextFrame--) và định dạng đoạn bằng [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Làm thế nào để áp dụng màu gradient cho văn bản trong slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Đặt [IFillFormat.setFillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifillformat/#setFillType-byte-) thành [FillType.Gradient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.