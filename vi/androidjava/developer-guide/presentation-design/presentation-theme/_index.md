---
title: "Quản lý Chủ đề Trình chiếu trên Android"
linktitle: "Chủ đề Trình chiếu"
type: docs
weight: 10
url: /vi/androidjava/presentation-theme/
keywords:
- "Chủ đề PowerPoint"
- "chủ đề trình chiếu"
- "chủ đề slide"
- "đặt chủ đề"
- "thay đổi chủ đề"
- "quản lý chủ đề"
- "màu chủ đề"
- "bảng màu bổ sung"
- "phông chữ chủ đề"
- "kiểu chủ đề"
- "hiệu ứng chủ đề"
- "PowerPoint"
- "OpenDocument"
- "trình chiếu"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Quản lý các chủ đề trình chiếu chính trong Aspose.Slides cho Android bằng Java để tạo, tùy chỉnh và chuyển đổi các tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề trình chiếu định nghĩa một bộ màu, phông chữ, kiểu nền, tô màu, đường nét và hiệu ứng được phối hợp. Các đối tượng nhận thức chủ đề tham chiếu tới những định nghĩa chung này thay vì lưu mỗi thuộc tính trực quan dưới dạng giá trị cố định, vì vậy việc thay đổi chủ đề có thể cập nhật nhiều đối tượng cùng một lúc.

Trong Aspose.Slides, chủ đề cấp trình chiếu được truy cập thông qua [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/). Một trình chiếu cũng có thể chứa các ghi đè chủ đề ở các cấp thấp hơn. Master có thể ghi đè chủ đề trình chiếu thông qua [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/masterthememanager/), trong khi layout hoặc một slide riêng lẻ có thể ghi đè chủ đề được kế thừa thông qua [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseoverridethememanager/). Thực tế, chủ đề hiệu lực cho một slide được xác định qua chuỗi kế thừa này: chủ đề trình chiếu, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần của chủ đề: màu, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần bên dưới trình bày các quy trình làm việc với chủ đề phổ biến nhất: kiểm tra một chủ đề, thay đổi màu và phông chữ, sao chép hoặc áp dụng một chủ đề, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu lực sau khi đã giải quyết kế thừa và ghi đè.

## **Kiểm tra một Chủ đề**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/) cung cấp lược đồ màu, lược đồ phông chữ và lược đồ định dạng của chủ đề qua các phương thức [MasterTheme.getColorScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/) và [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi một trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính chủ đề chính và báo cáo số lượng kiểu nền, tô màu, đường nét và hiệu ứng được lưu trong chủ đề:

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

Nếu một tệp sử dụng nhiều master, đừng giả định mọi slide đều có cùng một chủ đề hiệu lực. Kiểm tra master liên kết với slide và sử dụng quy trình làm việc chủ đề hiệu lực được mô tả sau trong bài khi có thể có ghi đè ở layout hoặc slide.

## **Thay đổi Màu Chủ đề**

Các tô màu, đường nét và văn bản nhận thức chủ đề có thể tham chiếu tới một màu logic từ enum [SchemeColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [IColorScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icolorscheme/), mọi đối tượng vẫn tham chiếu tới màu chủ đề đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu chủ đề.

Ví dụ toàn diện sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của chủ đề thành màu đỏ, lưu trình chiếu, mở lại và in ra màu tô hiệu lực:

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

Vì hình chữ nhật vẫn được liên kết tới `Accent4`, màu hiển thị của nó sẽ trở thành đỏ sau khi chủ đề được thay đổi. Nếu bạn thay thế màu lược đồ bằng màu trực tiếp trên hình dạng, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng tới tô màu đó.

### **Sử dụng Màu từ Bảng Màu Bổ Sung**

PowerPoint tạo các biến thể sáng hơn và tối hơn từ một màu chủ đề bằng cách áp dụng các phép biến đổi màu. Aspose.Slides cung cấp các phép biến đổi này thông qua enum [ColorTransformOperation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/colortransformoperation/).

![Màu chủ đề chính và các màu sáng hơn, tối hơn được tạo từ bảng màu bổ sung](additional-palette-colors.png)

**1** - Màu chủ đề chính.

**2** - Các biến thể sáng hơn và tối hơn được tạo từ màu chủ đề chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các biến đổi độ sáng cho năm trong số chúng và lưu kết quả:

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

Các biến thể này vẫn dựa trên màu chủ đề. Nếu `Accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại từ giá trị `Accent4` mới.

### **Ánh xạ Giá trị `SchemeColor` tới Các vị trí trong `IColorScheme`**

Enum [SchemeColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [IColorScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icolorscheme/) hiển thị các vị trí chủ đề tương tự dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Bảng ánh xạ cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng một vị trí chủ đề; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi Phông chữ Chủ đề**

Một lược đồ phông chữ chủ đề chứa một bộ phông chữ chính cho tiêu đề và một bộ phông chữ phụ cho nội dung. Các phương thức [IFontScheme.getMajor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontscheme/) và [IFontScheme.getMinor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontscheme/) cung cấp các bộ này.

Các định danh phông chữ chủ đề tương thích PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` - Phông chữ nội dung Latin (Minor Latin Font)
* `+mj-lt` - Phông chữ tiêu đề Latin (Major Latin Font)
* `+mn-ea` - Phông chữ nội dung Đông Á (Minor East Asian Font)
* `+mj-ea` - Phông chữ tiêu đề Đông Á (Major East Asian Font)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi phông chữ chủ đề và lưu kết quả:

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

Tiêu đề tuân theo phông chữ chính và văn bản nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh chủ đề sẽ không tự động chuyển đổi khi lược đồ phông chữ chủ đề thay đổi.

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong trình chiếu, xem [PowerPoint Fonts](/slides/vi/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc Áp dụng một Chủ đề**

Có hai quy trình làm việc phổ biến, và chúng giải quyết các vấn đề khác nhau.

### **Bảo tồn Chủ đề Nguồn Khi Di chuyển Slides**

Nếu bạn muốn di chuyển một slide sang trình chiếu khác và giữ nguyên thiết kế gốc, sao chép (clone) master nguồn vào trình chiếu đích bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslidecollection/), sau đó sao chép slide bằng [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/) và master đã sao chép. Điều này mang theo master, các layout và chủ đề liên quan cùng nhau.

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

Đây là quy trình ưu tiên khi slide nguồn phải trông giống hệt ở đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể làm thay đổi màu, phông chữ, nền và hiệu ứng được điều khiển bởi chủ đề.

### **Áp dụng Giá trị Chủ đề cho Slide Đã tồn tại**

Nếu slide đích phải ở trên master và layout hiện tại, khởi tạo một ghi đè cấp slide từ chủ đề nguồn. Các phương thức [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/) và [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/) sao chép ba thành phần chủ đề chính vào ghi đè.

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

Điều này thay đổi chủ đề được slide đó sử dụng mà không thay đổi chủ đề kế thừa bởi các slide khác. Để xóa ghi đè nội bộ và quay lại các giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/).

### **Áp dụng Ghi đè Chủ đề cho Layout**

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

Sử dụng chủ đề cấp master hoặc trình chiếu khi nhiều layout và slide cần chia sẻ cùng một thiết kế cơ bản, ghi đè layout khi một nhóm layout cần phong cách khác, và ghi đè slide chỉ cho các ngoại lệ thực sự. Quá nhiều ghi đè cấp slide sẽ làm cho các thay đổi chủ đề toàn cục sau này khó dự đoán.

## **Cập nhật Kiểu Nền Chủ đề**

Các tô nền của chủ đề được lưu trong [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện người dùng so với số lượng định nghĩa tô được lưu trong bộ sưu tập này vì UI có thể kết hợp tô chủ đề với màu chủ đề và các tham chiếu kiểu khác.

![Bộ sưu tập kiểu nền PowerPoint cho một chủ đề trình chiếu](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, kiểm tra bộ sưu tập đã lưu và giá trị hiện tại của [Background.getStyleIndex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/). Chỉ số kiểu `0` có nghĩa là không có tô chủ đề; các giá trị dương là tham chiếu tới kiểu nền chủ đề. Điều này khác với việc đánh chỉ số trực tiếp vào bộ sưu tập Java, trong đó `get_Item(0)` là mục đầu tiên được lưu. Đừng giả định mọi trình chiếu đều chứa cùng số lượng kiểu tô nền.

Ví dụ sau báo cáo số lượng tô nền khả dụng, gán một tham chiếu nền chủ đề cho master đầu tiên và lưu trình chiếu:

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

Kết quả hiển thị phụ thuộc vào mục nhập chủ đề được master tham chiếu và bất kỳ ghi đè nền nào ở cấp layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không ảnh hưởng tới slide đó. Sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/) khi bạn cần biết nền cuối cùng sau khi đã áp dụng kế thừa.

{{% alert color="warning" title="Warning" %}}
Đừng xem chỉ số kiểu như một chỉ số bộ sưu tập bắt đầu từ 0. Cũng tránh mã hoá cứng một số kiểu từ một tệp và giả định nó sẽ có cùng dạng trong tệp khác; các định nghĩa kiểu chủ đề là riêng từng trình chiếu.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/androidjava/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Chủ đề**

Một lược đồ định dạng chủ đề chứa các bộ sưu tập riêng cho tô, đường nét và hiệu ứng được khai báo qua [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/) và [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/). Các chủ đề Office thường chứa ba mục kiểu chính tương ứng với định dạng nhẹ, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Hiệu ứng chủ đề nhẹ, trung bình và mạnh được áp dụng lên cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong Java, chỉ số bộ sưu tập bắt đầu từ 0: `get_Item(0)` là kiểu đầu tiên được lưu và `get_Item(2)` là kiểu thứ ba. Các chỉ số tham chiếu kiểu của hình dạng là một khái niệm riêng, được khai báo qua [IShapeStyle](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapestyle/). Việc sửa đổi một kiểu chủ đề ảnh hưởng tới các hình dạng tham chiếu tới kiểu chủ đề đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục kiểu yêu cầu, thay đổi kiểu đường nét đầu tiên, thay đổi kiểu tô thứ ba, bật bóng đổ ngoài trong kiểu hiệu ứng thứ ba và lưu kết quả:

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

Đối với các hình dạng tham chiếu các vị trí này, kiểu đường nét chủ đề đầu tiên sẽ trở thành màu đỏ, kiểu tô chủ đề thứ ba sẽ thành màu xanh rừng đồng nhất, và kiểu hiệu ứng thứ ba sẽ có bóng đổ ngoài với khoảng cách 10 điểm. Kết quả hình ảnh cuối cùng vẫn phụ thuộc vào mỗi hình dạng tham chiếu vị trí kiểu nào và liệu định dạng trực tiếp có ghi đè lên chủ đề hay không.

![Các kiểu hiệu ứng chủ đề sau khi thay đổi đường nét, tô và cài đặt bóng đổ](presentation-design_11.png)

## **Đọc Giá trị Chủ đề Hiệu lực**

Các đối tượng chủ đề thô cho bạn biết gì đã được định nghĩa ở mức độ cụ thể. Các giá trị hiệu lực cho bạn biết slide hoặc hình dạng thực sự sử dụng gì sau khi đã giải quyết kế thừa và ghi đè nội bộ. Đối với slide, gọi [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseoverridethememanager/). Đối với nền, sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/), và đối với tô, sử dụng [FillFormat.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/).

Ví dụ sau đọc chủ đề hiệu lực, nền và tô của hình dạng đầu tiên từ một slide:

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

Sử dụng dữ liệu hiệu lực để chẩn đoán render, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/), bạn có thể bỏ qua một master, layout, slide hoặc ghi đè hình dạng thay đổi diện mạo cuối cùng.

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidethememanager/) của slide và khởi tạo ghi đè chủ đề của nó. Thay đổi sẽ chỉ áp dụng cục bộ cho slide đó; các slide khác vẫn kế thừa chủ đề hiện có.

**Cách an toàn nhất để chuyển một chủ đề từ trình chiếu này sang trình chiếu khác là gì?**

Khi di chuyển một slide và muốn bảo tồn giao diện nguồn, sao chép master nguồn vào đích và sao chép slide với master đó bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslidecollection/) và [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/). Điều này giữ nguyên master, layout và chủ đề cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu lực sau khi đã áp dụng kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseoverridethememanager/) cho một slide hoặc layout và các phương thức dữ liệu hiệu lực tương ứng cho các đối tượng định dạng như [Background.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/) và [FillFormat.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/). Các API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.