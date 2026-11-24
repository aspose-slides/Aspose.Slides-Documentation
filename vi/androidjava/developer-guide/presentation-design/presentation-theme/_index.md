---
title: Quản lý Theme Bản trình chiếu trên Android
linktitle: Theme Bản trình chiếu
type: docs
weight: 10
url: /vi/androidjava/presentation-theme/
keywords:
- Theme PowerPoint
- theme bản trình chiếu
- theme slide
- đặt theme
- thay đổi theme
- quản lý theme
- theme bên ngoài
- THMX
- màu theme
- bảng màu bổ sung
- phông chữ theme
- kiểu theme
- hiệu ứng theme
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Quản lý các theme bản trình chiếu chính trong Aspose.Slides cho Android bằng Java để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu đồng nhất."
---
## **Giới thiệu**

Một theme bản trình chiếu xác định một bộ màu, phông chữ, kiểu nền, màu nền, đường kẻ và hiệu ứng phối hợp. Các đối tượng nhận biết theme tham chiếu tới các định nghĩa chung này thay vì lưu trữ mỗi thuộc tính hình ảnh dưới dạng giá trị cố định, vì vậy việc thay đổi theme có thể cập nhật nhiều đối tượng cùng lúc.

Trong Aspose.Slides, theme ở cấp độ bản trình chiếu có sẵn thông qua [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Một bản trình chiếu cũng có thể chứa các ghi đè theme ở các cấp thấp hơn. Một master có thể ghi đè theme bản trình chiếu thông qua [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/), trong khi một layout hoặc một slide riêng lẻ có thể ghi đè theme được kế thừa thông qua [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). Trong thực tế, theme thực tế cho một slide được xác định qua chuỗi kế thừa này: theme bản trình chiếu, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần của Theme: màu sắc, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần dưới đây trình bày các quy trình làm việc với theme thường gặp nhất: kiểm tra theme, thay đổi màu và phông chữ, sao chép hoặc áp dụng theme, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị thực tế sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Theme**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) cung cấp lược đồ màu, lược đồ phông chữ và lược đồ định dạng của theme thông qua [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) và [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi bản trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính chính của theme và báo cáo số lượng kiểu nền, màu nền, đường kẻ và hiệu ứng được lưu trong theme:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Nếu một tệp sử dụng nhiều master, đừng cho rằng mọi slide đều có cùng theme thực tế. Kiểm tra master liên quan tới slide, và sử dụng quy trình theme‑effective được mô tả sau trong bài viết khi có thể có ghi đè layout hoặc slide.

## **Thay đổi màu Theme**

Các màu nền, đường kẻ và văn bản nhận biết theme có thể tham chiếu tới một màu logic từ enumeration [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/), mọi đối tượng vẫn tham chiếu tới màu theme đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi việc cập nhật màu theme.

Ví dụ end‑to‑end sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của theme thành màu đỏ, lưu bản trình chiếu, mở lại và in màu nền thực tế:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);

    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);

    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

Vì hình chữ nhật vẫn liên kết với `Accent4`, màu hiển thị của nó sẽ trở thành đỏ sau khi theme được thay đổi. Nếu bạn thay thế màu scheme bằng màu trực tiếp trên hình dạng, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng tới màu nền đó.

### **Sử dụng màu từ Bảng màu bổ sung**

PowerPoint tạo các biến thể sáng hơn và tối hơn từ một màu theme bằng cách áp dụng các phép biến đổi màu. Aspose.Slides cung cấp các phép biến đổi này qua enumeration [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/).

![Các màu theme chính và các màu sáng hơn, tối hơn được tạo từ bảng màu bổ sung](additional-palette-colors.png)

**1** – Các màu theme chính.

**2** – Các biến thể sáng hơn và tối hơn được tạo từ các màu theme chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các phép biến đổi độ sáng cho năm hình và lưu kết quả:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Các biến thể này vẫn dựa trên màu theme. Nếu `Accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại dựa trên giá trị `Accent4` mới.

### **Ánh xạ giá trị `SchemeColor` tới các khe `IColorScheme`**

Enumeration [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) công khai các khe theme tương tự dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Ánh xạ được cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng các khe theme; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi phông chữ Theme**

Một lược đồ phông chữ theme chứa một bộ phông chữ chính cho tiêu đề và một bộ phụ cho nội dung. Các phương thức [IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) và [IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) công khai các bộ này.

Các định danh phông chữ theme tương thích PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn‑lt` – Phông chữ nội dung Latin (Minor Latin Font)
* `+mj‑lt` – Phông chữ tiêu đề Latin (Major Latin Font)
* `+mn‑ea` – Phông chữ nội dung Đông Á (Minor East Asian Font)
* `+mj‑ea` – Phông chữ tiêu đề Đông Á (Major East Asian Font)
* `+mn‑cs` – Phông chữ nội dung Script phức hợp (Minor Complex Script Font)
* `+mj‑cs` – Phông chữ tiêu đề Script phức hợp (Major Complex Script Font)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi phông chữ theme và lưu kết quả:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));

    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tiêu đề tuân theo phông chữ chính và nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh theme sẽ không tự động chuyển khi lược đồ phông chữ theme thay đổi.

Các bộ phông chữ chính và phụ cũng có thể chứa các ánh xạ phông chữ cho từng hệ thống viết, chẳng hạn như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc loại bỏ các ánh xạ này, xem mục [Script‑Specific Theme Fonts](/slides/vi/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Mẹo" %}}

Để biết thêm thông tin về phông chữ trong bản trình chiếu, xem mục [PowerPoint Fonts](/slides/vi/androidjava/powerpoint-fonts/).

{{% /alert %}}

### **Giải quyết tham chiếu phông chữ Theme**

Khi kiểm tra văn bản, [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) có thể trả về một tham chiếu theme như `+mn‑lt` thay vì tên họ phông chữ. Gọi [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) cùng với [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) thích hợp để giải quyết tham chiếu đó. Các tiền tố `+mj` và `+mn` chọn bộ phông chữ chính và phụ; các hậu tố `-lt`, `-ea` và `-cs` chọn phông chữ Latin, Đông Á và Script phức hợp tương ứng.

Lấy theme thực tế thông qua [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--) trên đối tượng mà theme áp dụng cho văn bản đang kiểm tra. Đối với văn bản thường trên một slide, gọi phương thức này trên slide để ngữ cảnh bao gồm theme được kế thừa của slide và các ghi đè cục bộ. Khi kiểm tra một layout hoặc master, hãy sử dụng theme thực tế của chúng. Đừng cho rằng theme của master đầu tiên áp dụng cho mọi slide.

Ví dụ sau tạo một đoạn văn bản tham chiếu rõ ràng tới phông chữ Latin phụ. Nó khởi tạo lược đồ phông chữ slide thông qua [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) và đặt họ Latin chính và phụ thành `Arial` và `Calibri`, giúp kết quả có thể tái tạo mà không cần tệp đầu vào.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

Kết quả là `+mn‑lt -> Calibri` tiếp theo là `Verdana -> Verdana`. Tham chiếu đã lưu vẫn không thay đổi, trong khi tên họ cụ thể được trả về như nguyên. Nếu đoạn văn bản dùng `+mj‑lt`, nó sẽ giải quyết thành `Arial` trong theme này.

Giải quyết một tham chiếu theme xác định họ phông chữ được theme chỉ định. Nó không kiểm tra tính sẵn có của phông chữ hay xác định tệp phông chữ thực tế được sử dụng sau khi thay thế hoặc fallback glyph trong quá trình render. Xem mục [Font Selection Sequence](/slides/vi/androidjava/font-selection-sequence/) và [Font Substitution](/slides/vi/androidjava/font-substitution/) cho các bước riêng biệt đó.

## **Sao chép hoặc Áp dụng một Theme**

Các quy trình dưới đây giải quyết các vấn đề khác nhau liên quan tới theme.

### **Áp dụng Theme bên ngoài cho các Slide phụ thuộc vào Master**

Sử dụng [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) khi bạn có một tệp theme PowerPoint (`.thmx`) và muốn thay đổi kiểu dáng của mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) thực thi [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), và truyền đường dẫn tệp theme vào phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một master slide mới dựa trên master đã chọn.
1. Áp dụng theme bên ngoài cho master mới.
1. Gán master mới cho tất cả các slide trước đây phụ thuộc vào master đã chọn.
1. Trả về đối tượng [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) mới được tạo.

Ví dụ sau áp dụng một theme bên ngoài cho các slide phụ thuộc vào master đầu tiên và lưu bản trình chiếu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());

    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Một theme không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/). Hãy xác thực các đường dẫn do người dùng cung cấp, xử lý các lỗi truy cập hệ thống tệp, và chỉ lưu bản trình chiếu sau khi theme đã được áp dụng thành công.

Chỉ các slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với các master khác giữ nguyên master và theme hiện tại. Các màu, phông chữ, màu nền, đường kẻ và hiệu ứng nhận biết theme được giải quyết dựa trên theme bên ngoài. Các màu, phông chữ, màu nền và định dạng rõ ràng được gán trực tiếp có thể không thay đổi. Các ghi đè ở cấp layout và slide cũng có thể ưu tiên hơn các giá trị kế thừa từ master mới.

Theme có thể tham chiếu tới các phông chữ không có sẵn trong môi trường runtime. Để đảm bảo render và xuất khẩu nhất quán, hãy cài đặt các phông chữ cần thiết, cung cấp chúng qua [nguồn phông chữ tùy chỉnh](/slides/vi/androidjava/custom-font/), hoặc cấu hình [thay thế phông chữ](/slides/vi/androidjava/font-substitution/).

Đây là quy trình làm việc trực tiếp ở cấp master: phương thức nhận một đường dẫn tới tệp `.thmx` và không yêu cầu phải tạo các ghi đè theme ở cấp slide hay layout một cách thủ công.

### **Áp dụng các Theme bên ngoài khác nhau trong một Bản trình chiếu đa‑Master**

Khi master liên quan không được biết trước, lấy nó từ một slide đại diện qua [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) và [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/). Lưu các tham chiếu master gốc trước khi áp dụng bất kỳ theme nào vì mỗi lần gọi sẽ tạo thêm một master mới trong bản trình chiếu.

Ví dụ sau sử dụng slide từ hai phần để xác định master của chúng và áp dụng một theme bên ngoài khác nhau cho mỗi nhóm:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());

            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Lệnh gọi đầu tiên chỉ ảnh hưởng tới các slide phụ thuộc vào `firstGroupMaster`, và lệnh gọi thứ hai chỉ ảnh hưởng tới các slide phụ thuộc vào `secondGroupMaster`. Các slide thuộc bất kỳ master nào khác sẽ không bị thay đổi kiểu.

### **Bảo tồn Theme nguồn khi di chuyển Slide**

Nếu bạn muốn di chuyển một slide sang bản trình chiếu khác và bảo tồn thiết kế gốc, hãy sao chép master nguồn vào bản trình chiếu đích bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/), sau đó sao chép slide bằng [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) cùng với master đã sao chép. Điều này mang theo master, các layout và theme liên quan.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);

        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);

        target.getSlides().addClone(sourceSlide, clonedMaster, true);

        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Đây là quy trình ưu tiên khi slide nguồn phải giữ nguyên giao diện ở đích. Chỉ sao chép nội dung vào một master đích không liên quan có thể làm thay đổi màu, phông chữ, nền và hiệu ứng dựa trên theme.

### **Áp dụng giá trị Theme cho một Slide hiện có**

Nếu slide đích phải ở lại master và layout hiện tại, khởi tạo một ghi đè cấp slide từ theme nguồn. Các phương thức [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) và [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) sao chép ba thành phần chính của theme vào ghi đè.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);

        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());

        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Điều này thay đổi theme được sử dụng bởi slide đó mà không thay đổi theme được kế thừa bởi các slide khác. Để xóa ghi đè cục bộ và trở lại giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/).

### **Áp dụng một Ghi đè Theme cho Layout**

Một ghi đè cấp layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);

        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());

        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Sử dụng theme ở cấp master hoặc bản trình chiếu khi nhiều layout và slide cần chia sẻ cùng một thiết kế cơ bản, sử dụng ghi đè layout khi một họ layout cần kiểu dáng khác, và chỉ dùng ghi đè slide cho những ngoại lệ thực sự. Quá nhiều ghi đè cấp slide sẽ làm cho các thay đổi theme toàn cục sau này khó dự đoán.

<!-- visual-explanation:presentation-theme:start -->
[![Một theme master cung cấp hai layout; một ghi đè layout ảnh hưởng tới các slide của nó ngoại trừ một slide có ghi đè cục bộ hơn.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Một ghi đè layout áp dụng cho các slide sử dụng layout đó trừ khi một slide cung cấp ghi đè riêng. Các giá trị dựa trên theme tuân theo lược đồ đã giải quyết; các đối tượng được định dạng thủ công có thể giữ nguyên ngoại hình cục bộ. Giữ các ghi đè hẹp như thiết kế ngoại lệ dự định.*
<!-- visual-explanation:presentation-theme:end -->

## **Cập nhật Kiểu Nền Theme**

Các màu nền của theme được lưu trong [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn so với số lượng định nghĩa màu nền thực tế trong bộ sưu tập này vì UI có thể kết hợp màu nền theme với các màu theme và các tham chiếu kiểu khác.

![Bộ sưu tập kiểu nền PowerPoint cho một theme bản trình chiếu](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, hãy kiểm tra bộ sưu tập đã lưu và [Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) hiện tại. Chỉ số kiểu `0` nghĩa là không có màu nền theme; các giá trị dương là các tham chiếu kiểu nền theme. Điều này khác với việc đánh số trực tiếp bộ sưu tập Java, trong đó `get_Item(0)` là mục đầu tiên được lưu. Đừng cho rằng mọi bản trình chiếu đều chứa cùng số lượng kiểu nền.

Ví dụ sau báo cáo số lượng màu nền có sẵn, gán một tham chiếu nền theme cho master đầu tiên, và lưu bản trình chiếu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);

    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả hiển thị phụ thuộc vào mục theme mà master tham chiếu và bất kỳ ghi đè nền nào ở cấp layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không ảnh hưởng tới slide đó. Sử dụng [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) khi bạn cần biết nền cuối cùng sau khi đã áp dụng kế thừa.

{{% alert color="warning" title="Cảnh báo" %}}

Đừng xem chỉ số kiểu như một chỉ số bộ sưu tập bắt đầu từ 0. Cũng tránh việc hard‑code một số kiểu từ một tệp và cho rằng nó sẽ có cùng ngoại hình trong tệp khác; các định nghĩa kiểu theme là riêng cho từng bản trình chiếu.

{{% /alert %}}

{{% alert color="info" title="Mẹo" %}}

Đối với định dạng nền trực tiếp và kế thừa nền, xem mục [Presentation Background](/slides/vi/androidjava/presentation-background/).

{{% /alert %}}

## **Cập nhật Hiệu Ứng Theme**

Một lược đồ định dạng theme chứa các bộ sưu tập màu nền, đường kẻ và hiệu ứng riêng biệt được công khai qua [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), và [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/). Các theme Office điển hình thường chứa ba mục kiểu chính tương ứng với định dạng nhẹ, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Hiệu ứng theme nhẹ, trung bình và mạnh được áp dụng cho cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong Java, chỉ số bộ sưu tập bắt đầu từ 0: `get_Item(0)` là kiểu đầu tiên được lưu và `get_Item(2)` là kiểu thứ ba. Các chỉ số tham chiếu kiểu của hình dạng là một khái niệm riêng, được công khai qua [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/). Thay đổi một kiểu theme ảnh hưởng tới các hình dạng tham chiếu kiểu đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục kiểu cần thiết, thay đổi kiểu đường kẻ đầu tiên, thay đổi kiểu màu nền thứ ba, bật bóng đổ ngoài trong kiểu hiệu ứng thứ ba, và lưu kết quả:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);

    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với các hình dạng tham chiếu các khe này, kiểu đường kẻ theme đầu tiên sẽ trở thành màu đỏ, kiểu màu nền theme thứ ba sẽ trở thành màu xanh rừng đặc, và kiểu hiệu ứng thứ ba sẽ có một bóng đổ ngoài với khoảng cách 10 điểm. Kết quả hình ảnh vẫn phụ thuộc vào việc mỗi hình dạng tham chiếu vào khe nào và liệu định dạng trực tiếp có ghi đè theme hay không.

![Kiểu hiệu ứng theme sau khi thay đổi đường kẻ, màu nền và thiết lập bóng đổ](presentation-design_11.png)

## **Chọn Kiểu Màu Nền và Đường Kẻ Theme cho một Hình dạng**

Một hình dạng có thể chọn màu nền và đường viền một cách độc lập qua [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) và [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). Đối với cả hai phương thức, chỉ số `1` chọn mục đầu tiên trong bộ sưu tập theme tương ứng (`get_Item(0)`), và chỉ số `2` chọn mục thứ hai (`get_Item(1)`).

Ví dụ sau thiết lập hai kiểu màu nền (vàng và xanh trời) và hai kiểu đường kẻ (xanh đậm 6 pt và đỏ đậm 12 pt) trong theme mặc định của một bản trình chiếu mới. Nó lưu slide ở ba giai đoạn để bạn có thể so sánh kết quả trong PowerPoint.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Kiểu ban đầu | Thay đổi đường viền bên phải | Chỉnh sửa màu nền theme đầu tiên |
|:---:|:---:|:---:|
| ![Hình chữ nhật vàng và xanh trời với viền xanh đậm mỏng khớp nhau](theme-style-initial.png) | ![Hình chữ nhật xanh trời giờ có viền đỏ đậm dày](theme-style-line-changed.png) | ![Hình chữ nhật bên trái giờ thành màu xanh lá và cả hai viền không thay đổi](theme-style-fill-changed.png) |

Chọn một kiểu đường kẻ khác chỉ thay đổi viền của hình chữ nhật bên phải. Chỉnh sửa kiểu màu nền theme đầu tiên cập nhật mọi hình dạng sử dụng nó. Ở đây, chỉ hình chữ nhật bên trái chuyển sang màu xanh lá.

Trên một hình dạng hiện có, một màu nền cục bộ, màu đường kẻ hoặc độ rộng đường kẻ có thể ghi đè phần đó của kiểu theme. Nếu việc thay đổi chỉ số kiểu không có ảnh hưởng nào, kiểm tra [định dạng trực tiếp](/slides/vi/androidjava/shape-formatting/) của hình dạng.

## **Xác định liệu một Màu Nền Đặc thực tế có sử dụng Màu Theme không**

Một màu nền có thể được lưu trực tiếp trên đối tượng hoặc kế thừa từ đoạn văn, layout, master, kiểu theme hoặc một cấp định dạng khác. Gọi [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/) để giải quyết thứ bậc này thành một đối tượng không thay đổi [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Đầu tiên kiểm tra [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/). Chỉ khi nó là `FillType.Solid` mới đọc các thuộc tính màu nền đặc.

Đối với màu nền đặc, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) trả về giá trị RGB cuối cùng sau khi kế thừa, tra cứu theme và áp dụng các phép biến đổi màu. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) trả về khe [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) logic tương ứng, chẳng hạn `Text1` hoặc `Accent6`. Giá trị `SchemeColor.NotDefined` có nghĩa là màu nền đặc thực tế không dựa trên một màu scheme. Trong một quy trình mà màu nền chỉ là màu theme hoặc màu RGB trực tiếp, giá trị này xác định một màu RGB trực tiếp.

Đừng chỉ dựa vào giá trị [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) cục bộ để phân loại một màu nền. Ví dụ, một đoạn văn có thể không có màu scheme được định nghĩa cục bộ, vì vậy giá trị cục bộ là `NotDefined`, trong khi màu nền thực tế kế thừa một màu theme và giải quyết thành `Text1` hoặc `Accent6`. Ngược lại, `getSolidFillSchemeColor` cho bạn biết khe theme logic nào tạo ra màu thực tế, nhưng không cho biết khe đó đến từ đối tượng, đoạn văn, layout, master hay cấp định dạng nào khác.

Ví dụ sau tải một bản trình chiếu, kiểm tra cả màu nền hình dạng và màu nền đoạn văn, in mỗi giá trị RGB cuối cùng và scheme color liên quan, và đánh dấu các màu nền đặc sẽ không theo dõi sự thay đổi màu theme:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Nhánh `NotDefined` cung cấp danh sách kiểm tra các màu nền đặc sẽ không phản hồi với các thay đổi trong các khe màu theme. Kiểm tra các đối tượng này khi bản trình chiếu phải tuân theo bảng màu thương hiệu mới. Giá trị RGB được báo vẫn hiển thị ngoại hình hiện tại, trong khi giá trị scheme giải thích liệu ngoại hình đó có liên kết với theme hay không.

Các đối tượng định dạng‑effective là ảnh chụp nhanh. Sau khi thay đổi theme bản trình chiếu, một ghi đè theme hoặc bất kỳ định dạng kế thừa nào, hãy gọi lại `getEffective` và đọc một đối tượng `IFillFormatEffectiveData` mới trước khi so sánh hoặc báo cáo màu.

## **Đọc Các Giá Trị Theme Effective**

Các đối tượng theme thô cho bạn biết những gì được xác định ở một cấp độ cụ thể. Các giá trị effective cho bạn biết slide hoặc hình dạng thực sự sử dụng gì sau khi kế thừa và ghi đè cục bộ đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). Đối với một nền, dùng [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/), và đối với một màu nền, dùng [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/).

Ví dụ sau đọc theme effective, nền và màu nền hình dạng đầu tiên từ một slide:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();

    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());

    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

Sử dụng dữ liệu effective để chẩn đoán render, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), bạn có thể bỏ lỡ một master, layout, slide hoặc ghi đè hình dạng nào đó thay đổi ngoại hình cuối cùng.

## **Câu hỏi thường gặp**

**Áp dụng một theme bên ngoài có ảnh hưởng tới mọi slide trong bản trình chiếu không?**

Không. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) chỉ gán lại các slide phụ thuộc vào master đã chọn. Các slide dùng các master khác giữ nguyên theme hiện tại.

**Tôi có thể áp dụng một theme cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) của slide và khởi tạo ghi đè theme của nó. Thay đổi sẽ chỉ ở cục bộ cho slide đó; các slide khác vẫn kế thừa theme hiện có.

**Cách an toàn nhất để chuyển theme từ bản trình chiếu này sang bản trình chiếu khác là gì?**

Khi di chuyển một slide và bảo tồn giao diện nguồn, sao chép master nguồn vào bản đích và sao chép slide với master đó bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) và [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/). Điều này giữ nguyên master, các layout và theme cùng nhau.

**Làm sao tôi có thể xem các giá trị effective sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) cho một slide hoặc layout theme và các phương thức dữ liệu effective tương ứng cho các đối tượng định dạng như [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) và [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/). Các API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.