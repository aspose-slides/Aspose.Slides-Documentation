---
title: Định dạng Văn bản Trình chiếu trong Java
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/java/text-formatting/
keywords:
- căn đoạn văn
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
description: "Định dạng và tạo kiểu văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Java. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và nhiều hơn nữa."
---
## **Tổng quan**

Bài viết này trình bày cách định dạng văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides for Java. Nó bao gồm màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn văn, hành vi tự động vừa, neo văn bản, vị trí tab và cài đặt ngôn ngữ.

Trừ khi có ghi chú khác, các ví dụ sử dụng [sample.pptx](sample.pptx). Đối tượng hình đầu tiên trên slide đầu tiên là một hộp văn bản, và đoạn văn đầu tiên chứa văn bản được hiển thị bên dưới. Cả chỉ số slide và hình đều bắt đầu từ 0. Các ví dụ đánh dấu phần in đậm sử dụng định dạng hiệu ứng, bao gồm cả định dạng in đậm được kế thừa:

![Văn bản mẫu](sample_text.png)

Để tìm và làm nổi bật văn bản nguyên mẫu hoặc các khớp biểu thức chính quy, xem [Search and Replace Text](/slides/vi/java/search-and-replace-text/).

## **Đặt Màu Nền cho Văn Bản**

Sử dụng [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) để đặt màu đánh dấu mặc định cho một đoạn văn, hoặc sử dụng [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) cho các phần văn bản riêng lẻ.

Ví dụ sau đặt màu nền xám nhạt làm màu mặc định cho đoạn văn đầu tiên. Màu nền được chỉ định rõ ràng cho các phần riêng lẻ sẽ ưu tiên hơn màu mặc định này:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt màu nền cho toàn bộ đoạn văn.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Đoạn văn xám](gray_paragraph.png)

Ví dụ mã dưới đây cho thấy cách đặt màu nền cho **các phần văn bản có phông chữ in đậm**:

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
            // Đặt màu nền cho phần văn bản.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Các phần văn bản xám](gray_text_portions.png)

## **Căn Lề Đoạn Văn Bản**

Sử dụng [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) để đặt căn chỉnh đoạn văn trong khung văn bản. Giá trị có thể là căn giữa, căn lề trái, căn lề phải, căn đều, v.v.

Ví dụ mã sau cho thấy cách căn đoạn văn **ở giữa**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt căn chỉnh của đoạn văn thành trung tâm.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![Đoạn văn đã căn chỉnh](aligned_paragraph.png)

## **Đặt Độ Trong Suốt cho Văn Bản**

Độ trong suốt văn bản được kiểm soát thông qua thành phần alpha của màu được gán cho [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0–255, không phải là phần trăm trong suốt.

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

Ví dụ mã sau cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông chữ in đậm**:

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

## **Đặt Khoảng Cách Ký Tự cho Văn Bản**

Sử dụng [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản. Các ví dụ thêm 3 điểm khoảng cách; giá trị âm sẽ làm văn bản chèn lại.

Ví dụ Java sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn văn**:

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

Ví dụ mã dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông chữ in đậm**:

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

### **Vô Hiệu Hóa Kerning cho Các Phông Cụ Cụ Thể**

Trong một số trường hợp, văn bản được Render bằng Aspose.Slides có thể trông hơi chặt hơn so với cùng văn bản hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chứa thông tin kerning hợp lệ và kerning đã được bật trong cài đặt PowerPoint.

Để làm cho đầu ra Render gần hơn với PowerPoint trong các trường hợp này, bạn có thể vô hiệu hoá kerning cho các phần văn bản sử dụng phông bị ảnh hưởng. Đặt [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) thành giá trị lớn hơn kích thước phông thực tế. Ví dụ này yêu cầu "presentation.pptx" với một hộp văn bản là hình đầu tiên trên slide đầu tiên. Nó kiểm tra tên phông hiệu lực, bao gồm các phông được kế thừa, và đặt ngưỡng 100 điểm cho các phần sử dụng Roboto. Điều này vô hiệu hoá kerning cho các phần khớp có kích thước phông dưới 100 điểm:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với các văn bản khớp dưới ngưỡng, cài đặt này ngăn kerning và có thể giúp đồng bộ hóa việc render của Aspose.Slides với kết quả hiển thị trong PowerPoint đối với các phông chữ bị ảnh hưởng bởi hành vi đặc thù của PowerPoint này.

## **Quản Lý Thuộc Tính Phông Chữ Văn Bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn văn thông qua [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) hoặc trên các phần riêng lẻ qua [IPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportionformat/).

Ví dụ sau đặt phông mặc định cho đoạn văn đầu tiên là Times New Roman 12 pt với in đậm, in nghiêng và gạch dưới chấm. Định dạng rõ ràng trên các phần riêng lẻ sẽ ưu tiên hơn các mặc định này:

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

Ví dụ sau áp dụng Times New Roman 13 pt, định dạng in nghiêng và gạch dưới chấm cho các phần có định dạng hiệu lực là in đậm:

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

## **Đặt Xoay Văn Bản**

Sử dụng [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) để đặt hướng văn bản chuẩn trong một hình.

Ví dụ mã dưới đây đặt hướng văn bản trong hình thành [TextVerticalType.Vertical270](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textverticaltype/), xoay văn bản **90 độ ngược chiều kim đồng hồ**:

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

## **Đặt Xoay Tùy Chỉnh cho Khung Văn Bản**

Sử dụng [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) để đặt góc xoay tùy chỉnh cho một [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/).

Ví dụ mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình:

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

## **Đặt Khoảng Cách Dòng của Đoạn Văn**

Aspose.Slides cung cấp [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) và [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) để kiểm soát khoảng cách đoạn văn. Các thuộc tính này được sử dụng như sau:

* Sử dụng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm chiều cao dòng.
* Sử dụng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Ví dụ sau đặt khoảng cách trong đoạn văn đầu tiên thành 200% chiều cao dòng (gấp đôi):

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

## **Kiểm Soát Ngắt Dòng**

Quy tắc ngắt dòng của đoạn văn hữu ích trong các khối văn bản hẹp và các bản trình chiếu kết hợp văn bản Latin và Đông Á. Các phương thức sau thuộc về [IParagraphFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/), do đó chúng áp dụng cho toàn bộ đoạn văn:

- [setLatinLineBreak](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) kiểm soát quy tắc ngắt dòng Latin. Trong văn bản hỗn hợp, thay đổi nó cũng có thể thay đổi vị trí ngắt của văn bản và dấu câu Đông Á liền kề.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) kiểm soát quy tắc ngắt dòng Đông Á, bao gồm các giới hạn về ký tự ở đầu và cuối dòng.

Các quy tắc này không thay thế [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), cái cho phép tự động ngắt trong khung văn bản. Chúng ảnh hưởng tới bố cục khi ngắt xảy ra; chúng không chèn ký tự ngắt dòng. Một ngắt dòng rõ ràng buộc tạo ra một dòng mới trong đoạn văn bất kể độ rộng khả dụng.

Ví dụ tự chứa sau tạo một khối văn bản hẹp chứa tiếng Trung và Latin. Nó đặt cả hai tùy chọn ngắt dòng một cách rõ ràng và lưu "line_breaking.pptx". Để thử nghiệm mỗi quy tắc, thay đổi giá trị tương ứng trong khi giữ các cài đặt khác không đổi. Ví dụ sử dụng Arial 24 pt và SimSun với độ rộng khung 160 pt và lề ngang khung bằng 0. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) được gọi với [TextAutofitType.None](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textautofittype/) để kích thước văn bản và khung giữ cố định:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm Soát Dấu Câu Treo**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) cho phép các dấu câu đủ điều kiện mở rộng ra ngoài cạnh phải của dòng văn bản thay vì chiếm dòng tiếp theo. Nó áp dụng cho toàn bộ đoạn văn và khác với thụt lề treo.

Ví dụ tự chứa dưới đây bật dấu câu treo trong một khung văn bản rộng 100 điểm và lưu "hanging_punctuation.pptx". Với Arial 24 pt và lề ngang khung bằng 0, dấu chấm cuối cùng vẫn ở sau từ "sentence" và mở rộng ra ngoài cạnh phải. Đặt thuộc tính thành [NullableBool.False](https://reference.aspose.com/slides/vi/java/com.aspose.slides/nullablebool/) để so sánh: với các cài đặt này, dấu chấm chiếm một dòng riêng. Việc ngắt dòng được bật và autofit bị tắt để giữ độ rộng khả dụng cố định:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Không phải mọi dấu câu đều có thể treo. Kết quả hiển thị phụ thuộc vào sự khả dụng của phông và bố cục: thay đổi phông, độ rộng khả dụng, lề hoặc cài đặt autofit có thể làm mất sự khác biệt nhìn thấy.

## **Đặt Kiểu Tự Động Vừa cho Khung Văn Bản**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) xác định cách văn bản hành xử khi vượt quá giới hạn của vùng chứa. Sử dụng nó để điều khiển liệu văn bản có thu nhỏ, tràn ra ngoài, hoặc tự động thay đổi kích thước hình hay không. Ví dụ sau cấu hình hình để thay đổi kích thước sao cho vừa với văn bản và lưu kết quả thành "autofit_type.pptx":

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

Để đếm số dòng sau khi tự động ngắt và xem cách thay đổi độ rộng văn bản hoặc hình ảnh ảnh hưởng tới kết quả, xem [Count Rendered Lines](/slides/vi/java/manage-paragraph/). Số dòng chỉ cho biết số lượng dòng, không phản ánh việc văn bản có tràn ra khỏi vùng chứa hay không.

## **Đặt Neo cho Khung Văn Bản**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) xác định vị trí dọc của văn bản bên trong một hình, ví dụ ở trên, giữa hoặc dưới. Ví dụ sau neo văn bản vào đáy của hình đầu tiên và lưu kết quả thành "text_anchor.pptx":

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

## **Đặt Tab cho Văn Bản**

Sử dụng [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) và [IParagraphFormat.getTabs](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraphformat/#getTabs--) để cấu hình các vị trí tab trong một đoạn văn. Ví dụ sau đặt khoảng cách tab mặc định là 100 điểm và thêm một vị trí tab căn trái tại 30 điểm. Các cài đặt này ảnh hưởng tới văn bản có chứa ký tự tab:

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

## **Đặt Ngôn Ngữ Kiểm Tra Chính Tả**

Aspose.Slides cung cấp [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ kiểm tra quyết định ngôn ngữ được dùng cho việc kiểm tra chính tả và ngữ pháp trong PowerPoint.

Ví dụ sau yêu cầu "presentation.pptx" với hộp văn bản là hình đầu tiên trên slide đầu tiên và ít nhất một đoạn văn. Nó thay thế nội dung của đoạn văn đầu tiên bằng "1。", đặt SimSun làm phông và gán ngôn ngữ kiểm tra tiếng Trung giản thể (`zh-CN`). Kết quả được lưu thành "proofing_language.pptx":

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

## **Đặt Ngôn Ngữ Mặc Định**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) để xác định ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo một bản trình chiếu. Ví dụ sau tạo một bản trình chiếu với tiếng Anh Mỹ làm ngôn ngữ văn bản mặc định, thêm một hộp văn bản và in ra `en-US` cho phần văn bản đầu tiên:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Thêm một hình chữ nhật mới với văn bản.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Kiểm tra ngôn ngữ của phần văn bản đầu tiên.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Đặt Kiểu Văn Bản Mặc Định**

Để áp dụng định dạng văn bản mặc định ở mức bản trình chiếu, sử dụng [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Ví dụ sau đặt phông chữ 14 điểm, in đậm làm mặc định cho các đoạn văn cấp cao nhất trong một bản trình chiếu mới và lưu thành "default_text_style.pptx". Văn bản có thể kế thừa các giá trị mặc định này trừ khi có định dạng cụ thể hơn ghi đè lên chúng.

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

## **Trích Xuất Văn Bản với Hiệu Ứng All-Caps**

Trong PowerPoint, áp dụng hiệu ứng phông **All Caps** làm cho văn bản hiển thị dưới dạng chữ hoa trên slide ngay cả khi gốc nhập dưới dạng chữ thường. Khi bạn lấy phần văn bản như vậy bằng Aspose.Slides, thư viện sẽ trả về văn bản đúng như khi nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textcaptype/) và chuyển chuỗi trả về thành chữ hoa khi giá trị là `All`.

Ví dụ này yêu cầu "sample2.pptx" với một hộp văn bản là hình đầu tiên trên slide đầu tiên. Phần đầu tiên của đoạn văn đầu tiên chứa "Hello, Aspose!" với hiệu ứng All Caps đã được áp dụng, như hiển thị bên dưới.

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

## **Câu Hỏi Thường Gặp**

**Làm thế nào để chỉnh sửa văn bản trong một bảng trên slide?**

Để chỉnh sửa văn bản trong một bảng trên slide, sử dụng [ITable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itable/). Duyệt qua các ô và cập nhật từng ô thông qua [ICell.getTextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icell/#getTextFrame--) và định dạng đoạn văn thông qua [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Làm thế nào để áp dụng màu gradient cho văn bản trên slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Đặt [IFillFormat.setFillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifillformat/#setFillType-byte-) thành [FillType.Gradient](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.