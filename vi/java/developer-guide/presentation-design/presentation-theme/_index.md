---
title: Quản lý Giao diện Bản trình bày trong Java
linktitle: Giao diện Bản trình bày
type: docs
weight: 10
url: /vi/java/presentation-theme/
keywords:
- giao diện PowerPoint
- giao diện bản trình bày
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
- bản trình bày
- Java
- Aspose.Slides
description: "Quản lý các giao diện bản trình bày trong Aspose.Slides cho Java để tạo, tùy chỉnh và chuyển đổi các tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một giao diện bản trình bày định nghĩa một tập hợp phối hợp các màu sắc, phông chữ, kiểu nền, độ đậm, đường kẻ và hiệu ứng. Các đối tượng nhận thức giao diện tham chiếu tới các định nghĩa chung này thay vì lưu trữ mỗi thuộc tính trực quan dưới dạng giá trị cố định, do đó việc thay đổi giao diện có thể cập nhật nhiều đối tượng cùng lúc.

Trong Aspose.Slides, giao diện ở mức bản trình bày có sẵn qua [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/). Một bản trình bày cũng có thể chứa các ghi đè giao diện ở các cấp thấp hơn. Một master có thể ghi đè giao diện bản trình bày thông qua [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/masterthememanager/), trong khi một layout hoặc một slide riêng lẻ có thể ghi đè giao diện được kế thừa thông qua [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseoverridethememanager/). Thực tế, giao diện hiệu lực cho một slide được xác định qua chuỗi kế thừa này: giao diện bản trình bày, ghi đè master, ghi đè layout và ghi đè slide.

![Thành phần giao diện: màu sắc, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần dưới đây trình bày các quy trình làm việc với giao diện phổ biến nhất: kiểm tra giao diện, thay đổi màu sắc và phông chữ, sao chép hoặc áp dụng giao diện, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu lực sau khi kế thừa và ghi đè được giải quyết.

## **Kiểm tra Giao diện**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mastertheme/) cung cấp lược đồ màu, lược đồ phông chữ và lược đồ định dạng của giao diện thông qua [MasterTheme.getColorScheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mastertheme/) và [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/mastertheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi một bản trình bày đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính chính của giao diện và báo cáo số lượng kiểu nền, độ đậm, đường kẻ và hiệu ứng được lưu trữ trong giao diện:

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

Nếu một tệp sử dụng nhiều master, đừng giả định rằng mọi slide đều có cùng giao diện hiệu lực. Kiểm tra master được liên kết với slide, và sử dụng quy trình giao diện hiệu lực được mô tả phía sau trong bài viết khi có thể có ghi đè ở mức layout hoặc slide.

## **Thay đổi Màu sắc Giao diện**

Các độ đậm, đường kẻ và văn bản nhận thức giao diện có thể tham chiếu tới một màu logic từ enum [SchemeColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [IColorScheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icolorscheme/), tất cả các đối tượng vẫn tham chiếu tới màu giao diện đó sẽ được giải quyết lại dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu giao diện.

Ví dụ toàn diện sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của giao diện thành màu đỏ, lưu bản trình bày, mở lại và in ra màu độ đậm hiệu lực:

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

Vì hình chữ nhật vẫn liên kết với `Accent4`, màu hiển thị của nó sẽ trở thành màu đỏ sau khi giao diện được thay đổi. Nếu bạn thay thế màu scheme bằng màu trực tiếp trên hình dạng, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng đến độ đậm đó.

### **Sử dụng Màu sắc từ Bảng màu Bổ sung**

PowerPoint sinh các biến thể nhạt hơn và đậm hơn từ một màu giao diện bằng cách áp dụng các phép biến đổi màu. Aspose.Slides cung cấp các phép biến đổi này qua enum [ColorTransformOperation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/colortransformoperation/).

![Màu sắc giao diện chính và các màu nhạt hơn, đậm hơn được tạo từ bảng màu bổ sung](additional-palette-colors.png)

**1** – Màu sắc giao diện chính.  
**2** – Các biến thể nhạt hơn và đậm hơn được tạo ra từ các màu giao diện chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các phép biến đổi độ sáng cho năm trong số chúng và lưu kết quả:

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

Các biến thể này vẫn dựa trên màu giao diện. Nếu `Accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại dựa trên giá trị `Accent4` mới.

### **Ánh xạ giá trị `SchemeColor` vào các vị trí `IColorScheme`**

Enum [SchemeColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [IColorScheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icolorscheme/) mở ra cùng các vị trí giao diện dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Sự ánh xạ là cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng các vị trí giao diện; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi Phông chữ Giao diện**

Một lược đồ phông chữ giao diện chứa một bộ phông chính cho tiêu đề và một bộ phông phụ cho nội dung. Các phương pháp [IFontScheme.getMajor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontscheme/) và [IFontScheme.getMinor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontscheme/) cung cấp các bộ này.

Các định danh phông chữ giao diện tương thích với PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` – Phông chữ Thân (Latin) phụ (Minor Latin Font)
* `+mj-lt` – Phông chữ Tiêu đề (Latin) chính (Major Latin Font)
* `+mn-ea` – Phông chữ Thân (East Asian) phụ (Minor East Asian Font)
* `+mj-ea` – Phông chữ Tiêu đề (East Asian) chính (Major East Asian Font)

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

Tiêu đề theo phông chính và nội dung theo phông phụ. Văn bản có tên phông chữ cụ thể thay vì định danh giao diện sẽ không tự động chuyển đổi khi lược đồ phông chữ giao diện thay đổi.

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ bản trình bày, xem [PowerPoint Fonts](/slides/vi/java/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc Áp dụng Giao diện**

Có hai quy trình làm việc phổ biến, và chúng giải quyết các vấn đề khác nhau.

### **Bảo tồn Giao diện Nguồn Khi Di chuyển Slides**

Nếu bạn muốn di chuyển một slide sang bản trình bày khác và giữ nguyên thiết kế gốc, sao chép (clone) master nguồn vào bản trình bày đích bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslidecollection/), sau đó sao chép slide bằng [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/) và master đã sao chép. Điều này mang theo master, các layout và giao diện liên quan.

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

Đây là quy trình được ưu tiên khi slide nguồn phải trông giống hệt ở nơi đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể làm thay đổi các màu, phông chữ, nền và hiệu ứng được điều khiển bởi giao diện.

### **Áp dụng Giá trị Giao diện cho Slide hiện có**

Nếu slide đích phải giữ nguyên master và layout hiện tại, khởi tạo một ghi đè cấp slide từ giao diện nguồn. Các phương pháp [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/overridetheme/) và [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/vi/java/com.aspose.slides/overridetheme/) sao chép ba thành phần chính của giao diện vào ghi đè.

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

Điều này thay đổi giao diện được slide đó sử dụng mà không làm thay đổi giao diện được các slide khác kế thừa. Để xóa ghi đè cục bộ và quay lại giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/overridetheme/).

### **Áp dụng Ghi đè Giao diện cho Layout**

Ghi đè cấp layout áp dụng cho các slide dùng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương pháp khởi tạo tương tự có thể được dùng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/layoutslidethememanager/):

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

Sử dụng giao diện ở mức master hoặc bản trình bày khi nhiều layout và slide cần chia sẻ cùng thiết kế nền, ghi đè layout khi một nhóm layout cần kiểu dáng khác, và ghi đè slide chỉ cho những ngoại lệ thực sự. Việc sử dụng quá nhiều ghi đè cấp slide sẽ làm cho các thay đổi giao diện toàn cục sau này khó dự đoán.

## **Cập nhật Kiểu Nền Giao diện**

Các độ đậm nền của giao diện được lưu trong [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iformatscheme/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện người dùng so với số lượng định nghĩa độ đậm thực tế trong bộ sưu tập này vì UI có thể kết hợp độ đậm giao diện với màu giao diện và các tham chiếu kiểu khác.

![Bộ sưu tập kiểu nền PowerPoint cho giao diện bản trình bày](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, kiểm tra bộ sưu tập đã lưu và [Background.getStyleIndex](https://reference.aspose.com/slides/vi/java/com.aspose.slides/background/) hiện tại. Chỉ số kiểu `0` có nghĩa là không có độ đậm theo giao diện; các giá trị dương là các tham chiếu kiểu nền giao diện. Điều này khác với việc chỉ mục trực tiếp vào bộ sưu tập Java, nơi `get_Item(0)` là mục đầu tiên được lưu. Đừng giả định rằng mọi bản trình bày đều có cùng số lượng kiểu độ đậm nền.

Ví dụ sau báo cáo số lượng độ đậm nền có sẵn, gán một tham chiếu nền giao diện cho master đầu tiên và lưu bản trình bày:

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

Kết quả hiển thị phụ thuộc vào mục giao diện được master tham chiếu và bất kỳ ghi đè nền nào ở mức layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không ảnh hưởng đến slide đó. Sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/background/) khi bạn cần biết nền cuối cùng sau khi đã áp dụng kế thừa.

{{% alert color="warning" title="Warning" %}}
Đừng xem chỉ số kiểu như là chỉ mục bộ sưu tập dựa trên zero. Cũng tránh mã cứng một số kiểu từ một tệp và giả định nó sẽ có cùng giao diện trong tệp khác; các định nghĩa kiểu giao diện là riêng biệt cho mỗi bản trình bày.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/java/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Giao diện**

Một lược đồ định dạng giao diện chứa các bộ sưu tập độ đậm, đường kẻ và hiệu ứng riêng biệt được mở ra qua [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iformatscheme/), và [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iformatscheme/). Các giao diện Office điển hình thường có ba mục kiểu chính tương ứng với định dạng tinh tế, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Hiệu ứng giao diện tinh tế, trung bình và mạnh được áp dụng cho cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong Java, chỉ mục bộ sưu tập là zero‑based: `get_Item(0)` là kiểu đầu tiên được lưu và `get_Item(2)` là kiểu thứ ba. Các chỉ mục tham chiếu kiểu của hình dạng là một khái niệm riêng, được mở ra qua [IShapeStyle](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapestyle/). Việc sửa đổi một kiểu giao diện sẽ ảnh hưởng tới các hình dạng tham chiếu tới kiểu đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục kiểu yêu cầu, thay đổi kiểu đường kẻ đầu tiên, thay đổi kiểu độ đậm thứ ba, bật bóng đổ bên ngoài trong kiểu hiệu ứng thứ ba, và lưu kết quả:

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

Đối với các hình dạng tham chiếu các vị trí này, kiểu đường kẻ giao diện đầu tiên sẽ trở thành màu đỏ, kiểu độ đậm thứ ba sẽ thành màu xanh rừng đặc, và kiểu hiệu ứng thứ ba sẽ có một bóng đổ bên ngoài với khoảng cách 10 điểm. Kết quả trực quan cuối cùng vẫn phụ thuộc vào mỗi hình dạng tham chiếu vị trí nào và liệu định dạng trực tiếp có ghi đè giao diện hay không.

![Các kiểu hiệu ứng giao diện sau khi thay đổi đường kẻ, độ đậm và cài đặt bóng đổ](presentation-design_11.png)

## **Đọc Giá trị Giao diện Hiệu lực**

Các đối tượng giao diện thô cho bạn biết những gì được định nghĩa ở mức cụ thể. Các giá trị hiệu lực cho bạn biết slide hoặc hình dạng thực sự sử dụng gì sau khi kế thừa và ghi đè cục bộ được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseoverridethememanager/). Đối với nền, sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/background/), và đối với độ đậm, sử dụng [FillFormat.getEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/).

Ví dụ sau đọc giao diện hiệu lực, nền và độ đậm của hình dạng đầu tiên từ một slide:

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

Sử dụng dữ liệu hiệu lực để chẩn đoán việc render, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/), bạn có thể bỏ qua một master, layout, slide hoặc ghi đè hình dạng làm thay đổi giao diện cuối cùng.

## **Câu hỏi thường gặp**

**Tôi có thể áp dụng một giao diện cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidethememanager/) của slide và khởi tạo ghi đè giao diện cho nó. Thay đổi sẽ chỉ tồn tại cục bộ trên slide đó; các slide khác vẫn kế thừa giao diện hiện tại.

**Cách an toàn nhất để chuyển giao một giao diện từ bản trình bày này sang bản trình bày khác là gì?**

Khi di chuyển một slide và muốn giữ nguyên diện mạo nguồn, sao chép (clone) master nguồn vào bản đích và sao chép slide với master đó bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imasterslidecollection/) và [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecollection/). Điều này giữ lại master, các layout và giao diện cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu lực sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseoverridethememanager/) cho một slide hoặc layout và các phương thức dữ liệu‑hiệu lực tương ứng cho các đối tượng định dạng như [Background.getEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/background/) và [FillFormat.getEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/). Những API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.