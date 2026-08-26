---
title: Quản lý các Theme của bản trình chiếu trong Java
linktitle: Theme bản trình chiếu
type: docs
weight: 10
url: /vi/java/presentation-theme/
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
- phông theme
- kiểu theme
- hiệu ứng theme
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Quản lý các theme bản trình chiếu trong Aspose.Slides cho Java để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Theme của bản trình chiếu xác định một tập hợp phối hợp các màu, phông chữ, kiểu nền, độ phủ, đường kẻ và hiệu ứng. Các đối tượng nhận thức theme tham chiếu tới các định nghĩa chia sẻ này thay vì lưu trữ mỗi thuộc tính trực quan như một giá trị cố định, do đó việc thay đổi theme có thể cập nhật nhiều đối tượng cùng lúc.

Trong Aspose.Slides, theme ở mức bản trình chiếu có sẵn qua [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/). Bản trình chiếu cũng có thể chứa các ghi đè theme ở mức thấp hơn. Một master có thể ghi đè theme của bản trình chiếu qua [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/masterthememanager/), trong khi một layout hoặc một slide riêng lẻ có thể ghi đè theme được kế thừa qua [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseoverridethememanager/). Trong thực tế, theme hiệu lực cho một slide được giải quyết qua chuỗi kế thừa này: theme bản trình chiếu, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần của Theme: màu sắc, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần dưới đây trình bày các quy trình theme phổ biến nhất: kiểm tra theme, thay đổi màu và phông chữ, sao chép hoặc áp dụng theme, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu lực sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra Theme**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mastertheme/) mở ra sơ đồ màu, sơ đồ phông chữ và sơ đồ định dạng của theme qua [MasterTheme.getColorScheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mastertheme/), và [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mastertheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi bản trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung các mục kiểu có thể thay đổi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
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

Nếu một tệp sử dụng nhiều master, đừng cho rằng mọi slide đều có cùng theme hiệu lực. Kiểm tra master liên kết với slide, và sử dụng quy trình theme hiệu lực được trình bày sau trong bài khi có thể có ghi đè layout hoặc slide.

## **Thay đổi màu Theme**

Các độ phủ, đường kẻ và văn bản nhận thức theme có thể tham chiếu tới một màu logic từ enum [SchemeColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [IColorScheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icolorscheme/), tất cả các đối tượng vẫn tham chiếu tới màu theme đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu theme.

Ví dụ end‑to‑end dưới đây tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của theme thành màu đỏ, lưu bản trình chiếu, mở lại và in màu độ phủ hiệu lực:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Vì hình chữ nhật vẫn liên kết với `Accent4`, màu hiển thị của nó trở thành đỏ sau khi theme được thay đổi. Nếu bạn thay thế màu scheme bằng màu trực tiếp trên hình, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng tới độ phủ đó.

### **Sử dụng màu từ Bảng màu bổ sung**

PowerPoint tạo ra các biến thể sáng hơn và tối hơn từ một màu theme bằng cách áp dụng các phép biến đổi màu. Aspose.Slides cung cấp các phép biến đổi này qua enum [ColorTransformOperation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/colortransformoperation/).

![Màu chủ đề chính và các màu sáng hơn và tối hơn được tạo từ bảng màu bổ sung](additional-palette-colors.png)

**1** - Màu chủ đề chính.

**2** - Các biến thể sáng hơn và tối hơn được tạo từ màu chủ đề chính.

Ví dụ dưới đây tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các biến đổi độ sáng cho năm trong số chúng, và lưu kết quả:

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

Các biến thể này vẫn dựa trên màu theme. Nếu `Accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại từ giá trị `Accent4` mới.

### **Ánh xạ giá trị `SchemeColor` tới các slot `IColorScheme`**

Enum [SchemeColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [IColorScheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icolorscheme/) mở ra cùng các slot theme dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Ánh xạ này cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng các slot theme; chúng không phải là giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi phông chữ Theme**

Một sơ đồ phông chữ theme chứa một bộ phông chữ chính cho tiêu đề và một bộ phông chữ phụ cho nội dung. Các phương thức [IFontScheme.getMajor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontscheme/) và [IFontScheme.getMinor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontscheme/) mở ra các bộ này.

Các định danh phông chữ theme tương thích PowerPoint có thể được dùng trong định dạng văn bản:

* `+mn-lt` - Phông chữ nội dung Latin (Phông chữ Latin phụ)
* `+mj-lt` - Phông chữ tiêu đề Latin (Phông chữ Latin chính)
* `+mn-ea` - Phông chữ nội dung Đông Á (Phông chữ Đông Á phụ)
* `+mj-ea` - Phông chữ tiêu đề Đông Á (Phông chữ Đông Á chính)

Ví dụ dưới đây tạo một tiêu đề sử dụng phông chữ Latin chính của theme và một dòng nội dung sử dụng phông chữ Latin phụ của theme. Sau đó thay đổi phông chữ theme và lưu kết quả:

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

Tiêu đề tuân theo phông chữ chính và nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh theme sẽ không tự động chuyển khi sơ đồ phông chữ theme thay đổi.

Bộ phông chữ chính và phụ cũng có thể chứa các ánh xạ phông chữ cho các hệ thống viết riêng lẻ, chẳng hạn như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc loại bỏ các ánh xạ này, xem [Script-Specific Theme Fonts](/slides/vi/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong bản trình chiếu, xem [PowerPoint Fonts](/slides/vi/java/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc Áp dụng Theme**

Các quy trình dưới đây giải quyết các vấn đề liên quan đến theme khác nhau.

### **Áp dụng Theme bên ngoài cho các Slide phụ thuộc vào Master**

Sử dụng [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslide/) khi bạn có tệp theme PowerPoint (`.thmx`) và muốn thay đổi kiểu dáng của mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation.getMasters](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) thực thi [IMasterSlideCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslidecollection/), và truyền đường dẫn tệp theme vào phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một master slide mới dựa trên master đã chọn.
1. Áp dụng theme bên ngoài vào master mới.
1. Gán master mới cho tất cả các slide trước đây phụ thuộc vào master đã chọn.
1. Trả về đối tượng [IMasterSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslide/) mới tạo.

Ví dụ dưới đây áp dụng theme bên ngoài cho các slide phụ thuộc vào master đầu tiên và lưu bản trình chiếu:

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

Một theme không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxReadException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxreadexception/). Xác thực đường dẫn do người dùng cung cấp, xử lý lỗi truy cập hệ thống tập tin, và chỉ lưu bản trình chiếu sau khi theme đã được áp dụng thành công.

Chỉ những slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với các master khác giữ nguyên master và theme hiện tại. Các màu, phông chữ, độ phủ, đường kẻ, nền và hiệu ứng nhận thức theme sẽ được giải quyết dựa trên theme bên ngoài. Các màu, phông chữ, độ phủ và định dạng rõ ràng được gán trực tiếp có thể vẫn không thay đổi. Các ghi đè ở mức layout và slide cũng có thể có quyền ưu tiên hơn các giá trị kế thừa từ master mới.

Theme có thể tham chiếu tới các phông chữ không có sẵn trong môi trường chạy. Để đảm bảo hiển thị và xuất khẩu nhất quán, hãy cài đặt các phông chữ cần thiết, cung cấp chúng qua [nguồn phông chữ tùy chỉnh](/slides/vi/java/custom-font/), hoặc cấu hình [thay thế phông chữ](/slides/vi/java/font-substitution/).

Đây là quy trình trực tiếp ở mức master: phương thức nhận đường dẫn tệp `.thmx` và không yêu cầu tạo thủ công các ghi đè theme ở mức slide hay layout.

### **Áp dụng các Theme bên ngoài khác nhau trong bản trình chiếu đa Master**

Khi master liên quan không được biết trước, lấy nó từ một slide đại diện qua [ISlide.getLayoutSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islide/) và [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilayoutslide/). Lưu trữ các tham chiếu master gốc trước khi áp dụng bất kỳ theme nào vì mỗi lần gọi sẽ tạo thêm một master trong bản trình chiếu.

Ví dụ dưới đây sử dụng các slide từ hai phần để xác định master của chúng và áp dụng một theme bên ngoài khác nhau cho mỗi nhóm:

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

Lệnh gọi đầu tiên chỉ ảnh hưởng tới các slide phụ thuộc vào `firstGroupMaster`, và lệnh gọi thứ hai chỉ ảnh hưởng tới các slide phụ thuộc vào `secondGroupMaster`. Các slide thuộc bất kỳ master nào khác sẽ không bị thay đổi kiểu dáng.

### **Bảo tồn Theme nguồn khi di chuyển Slides**

Nếu bạn muốn di chuyển một slide sang bản trình chiếu khác và giữ nguyên thiết kế gốc, hãy sao chép master nguồn vào bản đích bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslidecollection/), sau đó sao chép slide bằng [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/) và master đã sao chép. Điều này mang theo master, các layout và theme liên quan cùng nhau.

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

Đây là quy trình được ưu tiên khi slide nguồn phải trông giống hệt ở đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể làm thay đổi các màu, phông chữ, nền và hiệu ứng dựa trên theme.

### **Áp dụng giá trị Theme cho một Slide hiện có**

Nếu slide đích phải ở lại master và layout hiện tại, khởi tạo một ghi đè ở mức slide từ theme nguồn. Các phương thức [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/overridetheme/), và [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/overridetheme/) sao chép ba thành phần chính của theme vào ghi đè.

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
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

Điều này thay đổi theme được sử dụng bởi slide đó mà không thay đổi theme mà các slide khác kế thừa. Để xóa ghi đè cục bộ và quay lại giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/overridetheme/).

### **Áp dụng Theme Override cho Layout**

Một ghi đè ở mức layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được dùng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/layoutslidethememanager/):

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
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

Sử dụng theme ở mức master hoặc bản trình chiếu khi nhiều layout và slide nên chia sẻ cùng một thiết kế cơ bản, sử dụng ghi đè layout khi một họ layout cần kiểu dáng khác, và chỉ dùng ghi đè slide cho các ngoại lệ thực sự. Quá nhiều ghi đè ở mức slide sẽ khiến việc thay đổi theme toàn cục sau này khó dự đoán hơn.

## **Cập nhật Kiểu nền Theme**

Các độ phủ nền của theme được lưu trong [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iformatscheme/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện người dùng so với số lượng định nghĩa độ phủ thực tế được lưu trong bộ sưu tập này vì giao diện có thể kết hợp độ phủ theme với màu theme và các tham chiếu kiểu khác.

![Bộ sưu tập kiểu nền PowerPoint cho một theme bản trình chiếu](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, kiểm tra bộ sưu tập đã lưu và giá trị hiện tại của [Background.getStyleIndex](https://reference.aspose.com/slides/vi/java/com.aspose.slides/background/). Chỉ số kiểu `0` có nghĩa là không có độ phủ theo theme; các giá trị dương là các tham chiếu kiểu nền theme. Điều này khác với việc truy cập bộ sưu tập Java trực tiếp, trong đó `get_Item(0)` nghĩa là mục đầu tiên được lưu. Đừng cho rằng mọi bản trình chiếu đều chứa cùng số lượng kiểu độ phủ nền.

Ví dụ dưới đây báo cáo số lượng độ phủ nền có sẵn, gán một tham chiếu nền theo theme cho master đầu tiên, và lưu bản trình chiếu:

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

Kết quả hiển thị phụ thuộc vào mục theme mà master tham chiếu và bất kỳ ghi đè nền nào ở mức layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không làm thay đổi slide đó. Sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/background/) khi bạn cần biết nền cuối cùng sau khi đã áp dụng kế thừa.

{{% alert color="warning" title="Warning" %}}
Không coi chỉ số kiểu như một chỉ số bộ sưu tập bắt đầu từ 0. Cũng tránh việc cứng mã một số kiểu từ một tệp và cho rằng nó sẽ có cùng giao diện trong tệp khác; các định nghĩa kiểu theme là riêng biệt cho mỗi bản trình chiếu.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/java/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Theme**

Một sơ đồ định dạng theme chứa các bộ sưu tập độ phủ, đường kẻ và hiệu ứng riêng biệt được mở ra qua [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iformatscheme/), và [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iformatscheme/). Các theme Office thông thường thường có ba mục kiểu chính tương ứng trực quan với định dạng nhẹ, vừa và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Hiệu ứng Theme nhẹ, trung bình và mạnh được áp dụng lên cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong Java, chỉ mục bộ sưu tập bắt đầu từ 0: `get_Item(0)` là kiểu đầu tiên được lưu và `get_Item(2)` là kiểu thứ ba. Các chỉ mục tham chiếu kiểu của hình dạng là một khái niệm riêng, được mở ra qua [IShapeStyle](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapestyle/). Việc sửa đổi một kiểu theme ảnh hưởng tới các hình dạng tham chiếu kiểu theme đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ dưới đây kiểm tra tồn tại các mục kiểu cần thiết, thay đổi kiểu đường đầu tiên, thay đổi kiểu độ phủ thứ ba, bật bóng ngoài trong kiểu hiệu ứng thứ ba, và lưu kết quả:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với các hình dạng tham chiếu các slot này, kiểu đường theme đầu tiên trở thành màu đỏ, kiểu độ phủ theme thứ ba trở thành màu xanh rừng đặc, và kiểu hiệu ứng thứ ba nhận bóng ngoài với khoảng cách 10 điểm. Kết quả hình ảnh chính xác vẫn phụ thuộc vào mỗi hình dạng tham chiếu slot nào và liệu định dạng trực tiếp có ghi đè theme hay không.

![Kiểu hiệu ứng Theme sau khi thay đổi cài đặt đường, độ phủ và bóng](presentation-design_11.png)

## **Đọc Giá trị Theme Hiệu lực**

Các đối tượng theme thô cho bạn biết gì đã được định nghĩa ở mức nhất định. Các giá trị hiệu lực cho bạn biết slide hoặc hình dạng thực sự sử dụng gì sau khi kế thừa và các ghi đè cục bộ đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseoverridethememanager/). Đối với nền, dùng [Background.getEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/background/), và đối với độ phủ, dùng [FillFormat.getEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/).

Ví dụ dưới đây đọc theme hiệu lực, nền và độ phủ của hình dạng đầu tiên từ một slide:

```java
import com.aspose.slides.*;

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
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Sử dụng dữ liệu hiệu lực cho việc chuẩn đoán render, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/), bạn có thể bỏ lỡ một master, layout, slide hoặc ghi đè hình dạng làm thay đổi giao diện cuối cùng.

## **FAQ**

**Áp dụng một theme bên ngoài có ảnh hưởng đến mọi slide trong bản trình chiếu không?**

Không. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslide/) chỉ gán lại các slide phụ thuộc vào master đã chọn. Các slide sử dụng các master khác giữ nguyên theme hiện tại.

**Tôi có thể áp dụng một theme cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidethememanager/) của slide và khởi tạo theme ghi đè của nó. Thay đổi sẽ chỉ áp dụng cục bộ cho slide đó; các slide khác vẫn kế thừa theme hiện tại.

**Cách an toàn nhất để mang một theme từ bản trình chiếu này sang bản khác là gì?**

Khi di chuyển một slide và muốn giữ nguyên giao diện nguồn, sao chép master nguồn vào bản đích và sao chép slide cùng master đó bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslidecollection/) và [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/). Điều này giữ lại master, các layout và theme cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu lực sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseoverridethememanager/) cho theme của slide hoặc layout và các phương thức dữ liệu hiệu lực tương ứng cho các đối tượng định dạng như [Background.getEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/background/) và [FillFormat.getEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/). Các API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.