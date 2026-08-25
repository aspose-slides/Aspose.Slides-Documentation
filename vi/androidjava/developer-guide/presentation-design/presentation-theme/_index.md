---
title: Quản lý giao diện bài thuyết trình trên Android
linktitle: Giao diện bài thuyết trình
type: docs
weight: 10
url: /vi/androidjava/presentation-theme/
keywords:
- giao diện PowerPoint
- giao diện bài thuyết trình
- giao diện slide
- đặt giao diện
- thay đổi giao diện
- quản lý giao diện
- màu giao diện
- bảng màu bổ sung
- phông chữ giao diện
- kiểu giao diện
- hiệu ứng giao diện
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Quản lý giao diện bài thuyết trình trong Aspose.Slides cho Android bằng Java để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu đồng nhất."
---
## **Giới thiệu**

Một giao diện bài thuyết trình xác định một bộ màu, phông chữ, kiểu nền, tô màu, đường kẻ và hiệu ứng được phối hợp. Các đối tượng nhận thức giao diện tham chiếu tới các định nghĩa chung này thay vì lưu trữ mỗi thuộc tính trực quan dưới dạng giá trị cố định, vì vậy việc thay đổi giao diện có thể cập nhật nhiều đối tượng cùng lúc.

Trong Aspose.Slides, giao diện ở mức bài thuyết trình có sẵn thông qua [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/). Một bài thuyết trình cũng có thể chứa các ghi đè giao diện ở các mức thấp hơn. Một master có thể ghi đè giao diện bài thuyết trình thông qua [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/masterthememanager/), trong khi một layout hoặc một slide riêng lẻ có thể ghi đè giao diện kế thừa của nó thông qua [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseoverridethememanager/). Thực tế, giao diện thực tế cho một slide được giải quyết thông qua chuỗi kế thừa này: giao diện bài thuyết trình, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần giao diện: màu sắc, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần dưới đây trình bày các quy trình làm việc với giao diện phổ biến nhất: kiểm tra một giao diện, thay đổi màu và phông chữ, sao chép hoặc áp dụng một giao diện, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị thực tế sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một giao diện**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/) cung cấp sơ đồ màu, sơ đồ phông chữ và sơ đồ định dạng của giao diện thông qua [MasterTheme.getColorScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/) và [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi một bài thuyết trình đến từ nguồn bên ngoài vì số lượng và nội dung của các mục phong cách có thể khác nhau.

Ví dụ sau đọc các thuộc tính chính của giao diện và báo cáo số lượng phong cách nền, tô, đường kẻ và hiệu ứng được lưu trong giao diện:

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

Nếu một tệp sử dụng nhiều master, đừng giả định rằng mọi slide đều có cùng một giao diện thực tế. Kiểm tra master liên kết với slide, và sử dụng quy trình làm việc giao diện thực tế được mô tả sau trong bài viết khi có thể có ghi đè ở mức layout hoặc slide.

## **Thay đổi màu giao diện**

Các tô màu, đường kẻ và văn bản nhận thức giao diện có thể tham chiếu tới một màu logic từ enumeration [SchemeColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [IColorScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icolorscheme/), mọi đối tượng vẫn tham chiếu tới màu giao diện đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi việc cập nhật màu giao diện.

Ví dụ end-to-end sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của giao diện thành màu đỏ, lưu bài thuyết trình, mở lại và in màu tô thực tế:

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

Vì hình chữ nhật vẫn liên kết với `Accent4`, màu hiển thị của nó sẽ thành màu đỏ sau khi giao diện được thay đổi. Nếu bạn thay thế màu lược đồ bằng màu trực tiếp trên hình dạng, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng đến tô màu đó.

### **Sử dụng màu từ Palette bổ sung**

PowerPoint tạo ra các biến thể sáng hơn và tối hơn từ một màu giao diện bằng cách áp dụng các biến đổi màu. Aspose.Slides cung cấp các biến đổi này thông qua enumeration [ColorTransformOperation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/colortransformoperation/).

![Màu giao diện chính và các màu sáng hơn, tối hơn được tạo từ palette bổ sung](additional-palette-colors.png)

**1** - Màu giao diện chính.

**2** - Các biến thể sáng hơn và tối hơn được tạo từ màu giao diện chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các biến đổi độ sáng cho năm hình và lưu kết quả:

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

Các biến thể này vẫn dựa trên màu giao diện. Nếu `Accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại từ giá trị `Accent4` mới.

### **Ánh xạ giá trị `SchemeColor` tới các vị trí `IColorScheme`**

Enumeration [SchemeColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [IColorScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icolorscheme/) cung cấp cùng các vị trí giao diện dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Bản đồ này cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng một vị trí giao diện; chúng không phải là giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi phông chữ giao diện**

Một sơ đồ phông chữ giao diện chứa một bộ phông chữ chính cho tiêu đề và một bộ phông chữ phụ cho nội dung. Các phương thức [IFontScheme.getMajor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontscheme/) và [IFontScheme.getMinor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontscheme/) cung cấp các bộ này.

Các định danh phông chữ giao diện tương thích PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` - Body Font Latin (Phông chữ Latin phụ)
* `+mj-lt` - Heading Font Latin (Phông chữ Latin chính)
* `+mn-ea` - Body Font East Asian (Phông chữ Đông Á phụ)
* `+mj-ea` - Heading Font East Asian (Phông chữ Đông Á chính)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi phông chữ giao diện và lưu kết quả:

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

Tiêu đề tuân theo phông chữ chính và văn bản nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh giao diện sẽ không tự động chuyển khi sơ đồ phông chữ giao diện thay đổi.

Bộ sưu tập phông chữ chính và phụ cũng có thể chứa ánh xạ phông chữ cho các hệ viết riêng lẻ, chẳng hạn như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc xóa các ánh xạ này, xem [Script-Specific Theme Fonts](/slides/vi/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong bài thuyết trình, hãy xem [PowerPoint Fonts](/slides/vi/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc áp dụng một giao diện**

Có hai quy trình làm việc phổ biến, và chúng giải quyết các vấn đề khác nhau.

### **Bảo tồn giao diện nguồn khi di chuyển slide**

Nếu bạn muốn di chuyển một slide sang bài thuyết trình khác và bảo tồn thiết kế gốc, hãy sao chép master nguồn vào bài thuyết trình đích bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslidecollection/), sau đó sao chép slide bằng [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/) và master đã sao chép. Điều này mang theo master, các layout và giao diện liên quan cùng nhau.

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

Đây là quy trình được ưu tiên khi slide nguồn phải trông giống hệt ở đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể làm thay đổi các màu, phông chữ, nền và hiệu ứng dựa trên giao diện.

### **Áp dụng giá trị giao diện cho một slide hiện có**

Nếu slide đích phải ở trên master và layout hiện tại, hãy khởi tạo một ghi đè cấp slide từ giao diện nguồn. Các phương thức [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/) và [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/) sao chép ba thành phần chính của giao diện vào ghi đè.

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

Điều này thay đổi giao diện được sử dụng bởi slide đó mà không thay đổi giao diện mà các slide khác kế thừa. Để xóa ghi đè cục bộ và quay lại các giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/).

### **Áp dụng ghi đè giao diện cho một layout**

Ghi đè cấp layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Sử dụng giao diện ở mức master hoặc bài thuyết trình khi nhiều layout và slide cần chia sẻ cùng một thiết kế cơ bản, sử dụng ghi đè layout khi một nhóm layout cần kiểu dáng khác nhau, và chỉ ghi đè slide cho các ngoại lệ thực sự. Quá nhiều ghi đè cấp slide làm cho các thay đổi giao diện toàn cục sau này khó dự đoán hơn.

## **Cập nhật kiểu nền giao diện**

Các tô nền của giao diện được lưu trong [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện người dùng so với số lượng định nghĩa tô màu thực tế được lưu trong bộ sưu tập này vì UI có thể kết hợp các tô màu giao diện với màu giao diện và các tham chiếu phong cách khác.

![Bộ sưu tập kiểu nền PowerPoint cho một giao diện bài thuyết trình](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, hãy kiểm tra bộ sưu tập đã lưu và [Background.getStyleIndex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/) hiện tại. Một chỉ số kiểu `0` có nghĩa là không có tô màu giao diện; các giá trị dương là các tham chiếu kiểu nền giao diện. Điều này khác với việc đánh chỉ mục bộ sưu tập Java trực tiếp, nơi `get_Item(0)` có nghĩa là mục đầu tiên được lưu. Đừng giả định rằng mọi bài thuyết trình đều chứa cùng số lượng kiểu tô nền.

Ví dụ sau báo cáo số lượng tô nền khả dụng, gán một tham chiếu nền giao diện cho master đầu tiên và lưu bài thuyết trình:

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

Kết quả hiển thị phụ thuộc vào mục giao diện được master tham chiếu và bất kỳ ghi đè nền nào ở mức layout hoặc slide. Nếu một slide sử dụng nền riêng, việc thay đổi chỉ nền master có thể không thay đổi slide đó. Hãy sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/) khi bạn cần biết nền cuối cùng sau khi kế thừa đã được áp dụng.

{{% alert color="warning" title="Warning" %}}
Đừng xem chỉ số kiểu như một chỉ mục bộ sưu tập bắt đầu từ 0. Cũng tránh mã cứng một số kiểu từ một tệp và giả định nó có cùng giao diện trong tệp khác; các định nghĩa kiểu giao diện là riêng biệt cho mỗi bài thuyết trình.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, hãy xem [Presentation Background](/slides/vi/androidjava/presentation-background/).
{{% /alert %}}

## **Cập nhật hiệu ứng giao diện**

Một sơ đồ định dạng giao diện chứa các bộ sưu tập kiểu tô, đường kẻ và hiệu ứng riêng biệt, được cung cấp qua [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/), và [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/). Các giao diện Office thường chứa ba mục phong cách chính tương ứng với định dạng tinh tế, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Hiệu ứng giao diện tinh tế, trung bình và mạnh được áp dụng cho cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong Java, chỉ mục bộ sưu tập bắt đầu từ 0: `get_Item(0)` là phong cách đầu tiên được lưu và `get_Item(2)` là phong cách thứ ba. Các chỉ mục tham chiếu phong cách của hình dạng là một khái niệm riêng, được cung cấp qua [IShapeStyle](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapestyle/). Việc sửa đổi một phong cách giao diện ảnh hưởng đến các hình dạng tham chiếu phong cách đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục phong cách cần thiết, thay đổi phong cách đường kẻ đầu tiên, thay đổi phong cách tô thứ ba, bật bóng đổ ngoài trong phong cách hiệu ứng thứ ba, và lưu kết quả:

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

Đối với các hình dạng tham chiếu các vị trí này, phong cách đường kẻ giao diện đầu tiên sẽ thành màu đỏ, phong cách tô giao diện thứ ba sẽ thành màu xanh rừng đặc, và phong cách hiệu ứng thứ ba sẽ có bóng đổ ngoài với khoảng cách 10 điểm. Kết quả hình ảnh chính xác vẫn phụ thuộc vào mỗi hình dạng tham chiếu vị trí nào và liệu định dạng trực tiếp có ghi đè giao diện hay không.

![Các phong cách hiệu ứng giao diện sau khi thay đổi đường kẻ, tô và thiết lập bóng đổ](presentation-design_11.png)

## **Đọc các giá trị giao diện thực tế**

Các đối tượng giao diện thô cho bạn biết những gì đã được định nghĩa ở mức cụ thể. Các giá trị thực tế cho bạn biết slide hoặc hình dạng thực sự sử dụng gì sau khi kế thừa và ghi đè cục bộ đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseoverridethememanager/). Đối với nền, sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/), và đối với tô, sử dụng [FillFormat.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/).

Ví dụ sau đọc giao diện thực tế, nền và tô của hình dạng đầu tiên từ một slide:

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

Sử dụng dữ liệu thực tế cho việc chẩn đoán hiển thị, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/), bạn có thể bỏ lỡ một master, layout, slide hoặc ghi đè hình dạng thay đổi giao diện cuối cùng.

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng một giao diện cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidethememanager/) của slide và khởi tạo ghi đè giao diện cho nó. Thay đổi sẽ chỉ áp dụng cho slide đó; các slide khác vẫn kế thừa giao diện hiện tại.

**Cách an toàn nhất để mang một giao diện từ bài thuyết trình này sang bài thuyết trình khác là gì?**

Khi di chuyển một slide và bảo tồn giao diện nguồn, sao chép master nguồn vào đích và sao chép slide với master đó bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslidecollection/) và [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/). Điều này giữ nguyên master, các layout và giao diện cùng nhau.

**Làm sao tôi có thể xem các giá trị thực tế sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseoverridethememanager/) cho một slide hoặc layout và các phương thức dữ liệu thực tế tương ứng cho các đối tượng định dạng như [Background.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/) và [FillFormat.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/). Những API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.