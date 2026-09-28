---
title: Định dạng văn bản trình chiếu trên Android
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/androidjava/text-formatting/
keywords:
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
- đánh tab văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Định dạng và tạo kiểu văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Android qua Java. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và nhiều hơn nữa."
---
## **Tổng quan**

Bài viết này trình bày cách định dạng văn bản trong các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Android thông qua Java. Nó bao gồm màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn, hành vi tự động vừa, neo văn bản, vị trí tab và cài đặt ngôn ngữ.

Trừ khi có ghi chú khác, các ví dụ sử dụng [sample.pptx](sample.pptx). Hình dạng đầu tiên trên slide đầu tiên là một hộp văn bản, và đoạn văn đầu tiên chứa văn bản được hiển thị bên dưới. Cả chỉ số slide và hình dạng đều tính từ không. Các ví dụ đánh dấu phần in đậm sử dụng định dạng hiệu quả, bao gồm cả định dạng in đậm được kế thừa:

![Sample text](sample_text.png)

Để tìm và làm nổi bật văn bản nguyên dạng hoặc các khớp biểu thức chính quy, xem [Search and Replace Text](/slides/vi/androidjava/search-and-replace-text/).

## **Đặt màu nền cho Văn bản**

Sử dụng [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) để đặt màu nền mặc định cho một đoạn, hoặc sử dụng [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) cho các phần văn bản riêng lẻ.

Ví dụ sau đặt màu nền xám nhạt làm mặc định cho đoạn đầu tiên. Các màu nền cụ thể trên các phần riêng lẻ sẽ có ưu tiên hơn mặc định này:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt màu nền cho toàn bộ đoạn.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The gray paragraph](gray_paragraph.png)

Ví dụ mã dưới đây minh họa cách đặt màu nền cho **các phần văn bản có phông chữ in đậm**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

![The gray text portions](gray_text_portions.png)

## **Căn chỉnh Đoạn Văn bản**

Sử dụng [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) để đặt căn chỉnh đoạn trong một khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, căn đều, v.v.

Mã sau cho thấy cách căn đoạn **ở giữa**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt căn chỉnh của đoạn văn bản thành giữa.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The aligned paragraph](aligned_paragraph.png)

## **Đặt Độ Trong Suốt cho Văn bản**

Độ trong suốt của văn bản được kiểm soát thông qua thành phần alpha của màu được gán cho [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0–255, không phải là tỷ lệ phần trăm độ trong suốt.

Mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

![The transparent paragraph](transparent_paragraph.png)

Ví dụ sau cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông chữ in đậm**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả:

![The transparent text portions](transparent_text_portions.png)

## **Đặt Khoảng Cách Ký tự cho Văn bản**

Sử dụng [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản. Các ví dụ thêm 3 điểm vào khoảng cách; giá trị âm sẽ thu hẹp văn bản.

Mã Java sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn**:

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

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Mã dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông chữ in đậm**:

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

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Vô hiệu hóa Kerning cho Các Phông chữ Cụ thể**

Trong một số trường hợp, văn bản được render bởi Aspose.Slides có thể trông hơi chặt hơn so với cùng văn bản hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chữ đó chứa thông tin kerning hợp lệ và kerning đã được bật trong cài đặt PowerPoint.

Để đưa kết quả render gần hơn với PowerPoint trong những trường hợp như vậy, bạn có thể vô hiệu hóa kerning cho các phần văn bản sử dụng phông chữ bị ảnh hưởng. Đặt [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) thành giá trị lớn hơn kích thước thực tế của phông chữ. Ví dụ này yêu cầu "presentation.pptx" có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Nó kiểm tra tên phông chữ hiệu quả, bao gồm các phông chữ được kế thừa, và đặt ngưỡng 100 điểm cho các phần sử dụng Roboto. Điều này vô hiệu hóa kerning cho các phần phù hợp có kích thước phông chữ dưới 100 điểm:

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

Đối với văn bản khớp ngưỡng, cài đặt này ngăn kerning và có thể giúp kết quả render của Aspose.Slides gần hơn với đầu ra trực quan của PowerPoint cho các phông chữ bị ảnh hưởng bởi hành vi đặc thù này của PowerPoint.

## **Quản lý Thuộc tính Phông chữ cho Văn bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) hoặc trên các phần riêng lẻ thông qua [IPortionFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iportionformat/).

Ví dụ sau đặt phông chữ mặc định cho đoạn đầu tiên là Times New Roman 12 điểm với in đậm, in nghiêng và gạch chân chấm. Định dạng cụ thể trên các phần riêng lẻ sẽ có ưu tiên hơn các mặc định này:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Đặt thuộc tính phông chữ cho đoạn văn.
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

![The font properties for the paragraph](font_properties_for_paragraph.png)

Ví dụ sau áp dụng Times New Roman 13 điểm, định dạng in nghiêng và gạch chân chấm cho các phần có định dạng hiệu quả là in đậm:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Đặt thuộc tính phông chữ cho phần văn bản.
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

![The font properties for text portions](font_properties_for_text_portions.png)

## **Đặt Xoay Văn bản**

Sử dụng [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) để đặt hướng văn bản định trước trong một hình dạng.

Mã sau thiết lập hướng văn bản trong hình dạng thành [TextVerticalType.Vertical270](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textverticaltype/), xoay văn bản **90 độ ngược chiều kim đồng hồ**:

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

![The text rotation](text_rotation.png)

## **Đặt Xoay Tùy chỉnh cho Khung Văn bản**

Sử dụng [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) để đặt góc xoay tùy chỉnh cho một [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/).

Mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình dạng:

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

![The custom text rotation](custom_text_rotation.png)

## **Đặt Khoảng Cách Dòng cho Các Đoạn**

Aspose.Slides cung cấp [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) và [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) để kiểm soát khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Sử dụng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm của chiều cao dòng.
* Sử dụng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Ví dụ sau đặt khoảng cách trong đoạn đầu tiên là 200% chiều cao dòng (gấp đôi):

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

![The line spacing within the paragraph](line_spacing.png)

## **Kiểm soát Ngắt Dòng**

Quy tắc ngắt dòng của đoạn hữu ích trong các khối văn bản hẹp và các bản trình bày kết hợp văn bản Latin và Đông Á. Các phương thức sau thuộc về [IParagraphFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/), vì vậy chúng áp dụng cho toàn bộ đoạn:

- [setLatinLineBreak](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) kiểm soát quy tắc ngắt dòng Latin. Trong văn bản hỗn hợp, việc thay đổi nó cũng có thể thay đổi vị trí ngắt của văn bản và dấu câu Đông Á liền kề.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) kiểm soát quy tắc ngắt dòng Đông Á, bao gồm các hạn chế về ký tự ở đầu và cuối dòng.

Các quy tắc này không thay thế [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-), cho phép tự động ngắt trong một khung văn bản. Chúng ảnh hưởng đến bố cục khi ngắt xảy ra; chúng không chèn ký tự ngắt dòng. Một ký tự ngắt dòng tường minh buộc tạo dòng mới trong đoạn mà không phụ thuộc vào độ rộng hiện có.

Ví dụ tự chứa sau tạo một khối văn bản hẹp chứa cả tiếng Trung và Latin. Nó đặt cả hai tùy chọn ngắt dòng một cách rõ ràng và lưu "line_breaking.pptx". Để thử nghiệm một trong các quy tắc, thay đổi giá trị tương ứng trong khi giữ các cài đặt khác không đổi. Ví dụ sử dụng Arial 24 điểm và SimSun với chiều rộng khung 160 điểm và lề ngang khung bằng 0. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) được gọi với [TextAutofitType.None](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textautofittype/) để kích thước văn bản và kích thước khung giữ cố định.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Kiểm soát Dấu câu Treo**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) cho phép các dấu câu đủ điều kiện mở rộng qua cạnh phải của dòng văn bản thay vì chiếm dòng tiếp theo. Nó áp dụng cho toàn bộ đoạn và khác với thụt lề treo.

Ví dụ tự chứa sau bật dấu câu treo trong một khung văn bản rộng 100 điểm và lưu "hanging_punctuation.pptx". Với Arial 24 điểm và lề ngang khung bằng 0, dấu chấm cuối cùng vẫn nằm sau "sentence" và mở rộng qua cạnh phải. Đặt thuộc tính thành [NullableBool.False](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/nullablebool/) để so sánh: với các cài đặt này, dấu chấm chiếm một dòng riêng. Việc ngắt được bật và autofit bị tắt để giữ độ rộng khả dụng cố định.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Không phải mọi dấu câu đều có thể treo. Kết quả hiển thị phụ thuộc vào khả năng có sẵn của phông chữ và bố cục: thay đổi phông chữ, độ rộng khả dụng, lề hoặc cài đặt autofit có thể làm mất sự khác biệt hiển thị.

## **Đặt Kiểu Autofit cho Khung Văn bản**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) xác định cách văn bản hành xử khi vượt quá giới hạn của vùng chứa. Sử dụng để kiểm soát việc văn bản co, tràn hoặc tự động thay đổi kích thước hình dạng. Ví dụ sau cấu hình hình dạng để thay đổi kích thước phù hợp với văn bản và lưu kết quả vào "autofit_type.pptx".

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

Để đếm số dòng sau khi tự động ngắt và xem cách văn bản hoặc độ rộng hình dạng thay đổi kết quả, xem [Count Rendered Lines](/slides/vi/androidjava/manage-paragraph/). Số dòng chỉ không cho biết liệu văn bản có tràn vùng chứa hay không.

## **Đặt Neo cho Khung Văn bản**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) xác định cách văn bản được định vị theo chiều dọc bên trong một hình dạng, ví dụ ở trên, giữa hoặc dưới. Ví dụ sau neo văn bản vào đáy của hình dạng đầu tiên và lưu kết quả vào "text_anchor.pptx".

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

## **Đặt Tab cho Văn bản**

Sử dụng [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) và [IParagraphFormat.getTabs](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) để cấu hình vị trí tab trong một đoạn. Ví dụ sau đặt khoảng cách tab mặc định là 100 điểm và thêm một vị trí tab căn trái tại 30 điểm. Các cài đặt này ảnh hưởng đến văn bản chứa ký tự tab.

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

![The paragraph tabs](paragraph_tabs.png)

## **Đặt Ngôn ngữ Kiểm tra Chính tả**

Aspose.Slides cung cấp [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ kiểm tra quyết định ngôn ngữ được sử dụng cho kiểm tra chính tả và ngữ pháp trong PowerPoint.

Ví dụ sau yêu cầu "presentation.pptx" có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên và ít nhất một đoạn. Nó thay thế nội dung của đoạn đầu tiên bằng "1。", đặt SimSun làm phông chữ và gán ngôn ngữ kiểm tra tiếng Trung giản thể (`zh-CN`). Kết quả được lưu vào "proofing_language.pptx":

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

## **Đặt Ngôn ngữ Mặc định**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) để xác định ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo một bản trình bày. Ví dụ sau tạo một bản trình bày với tiếng Anh Mỹ làm ngôn ngữ văn bản mặc định, thêm một hộp văn bản và in `en-US` cho phần văn bản đầu tiên của nó.

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

## **Đặt Kiểu Văn bản Mặc định**

Để áp dụng định dạng văn bản mặc định ở mức bản trình bày, sử dụng [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Ví dụ sau đặt phông chữ in đậm 14 điểm làm mặc định cho các đoạn cấp cao nhất trong một bản trình bày mới và lưu nó vào "default_text_style.pptx". Văn bản có thể kế thừa các mặc định này trừ khi có định dạng cụ thể hơn ghi đè lên chúng.

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

## **Trích xuất Văn bản với Hiệu ứng All-Caps**

Trong PowerPoint, áp dụng hiệu ứng phông chữ **All Caps** làm cho văn bản hiển thị ở dạng chữ hoa trên slide ngay cả khi nó được gõ bằng chữ thường. Khi bạn lấy một phần văn bản như vậy với Aspose.Slides, thư viện trả về văn bản chính xác như đã nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textcaptype/) và chuyển chuỗi trả về thành chữ hoa khi giá trị là `All`.

Ví dụ này yêu cầu "sample2.pptx" có một hộp văn bản là hình dạng đầu tiên trên slide đầu tiên. Phần đầu tiên của đoạn đầu tiên chứa "Hello, Aspose!" với hiệu ứng All Caps được áp dụng, như hình dưới.

![The All Caps effect](all_caps_effect.png)

Mã dưới đây cho thấy cách trích xuất văn bản với hiệu ứng **All Caps** đã áp dụng:

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

**Làm thế nào để chỉnh sửa văn bản trong bảng trên một slide?**

Để chỉnh sửa văn bản trong bảng trên một slide, sử dụng [ITable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itable/). Duyệt qua các ô và cập nhật mỗi ô thông qua [ICell.getTextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icell/#getTextFrame--) và định dạng đoạn qua [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Làm thế nào để áp dụng màu chuyển gradient cho văn bản trên slide PowerPoint?**

Để áp dụng màu chuyển gradient cho văn bản, sử dụng [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Đặt [IFillFormat.setFillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) thành [FillType.Gradient](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) và cấu hình các điểm gradient, hướng và độ trong suốt.