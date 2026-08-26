---
title: Quản lý Chủ đề Bản trình chiếu trên Android
linktitle: Chủ đề Bản trình chiếu
type: docs
weight: 10
url: /vi/androidjava/presentation-theme/
keywords:
- Chủ đề PowerPoint
- chủ đề bản trình chiếu
- chủ đề slide
- đặt chủ đề
- thay đổi chủ đề
- quản lý chủ đề
- chủ đề ngoại vi
- THMX
- màu chủ đề
- bảng màu bổ sung
- phông chữ chủ đề
- kiểu chủ đề
- hiệu ứng chủ đề
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Quản lý các chủ đề bản trình chiếu trong Aspose.Slides cho Android qua Java để tạo, tùy chỉnh và chuyển đổi tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề bản trình chiếu xác định một bộ phối hợp các màu, phông chữ, kiểu nền, màu nền, đường nét và hiệu ứng. Các đối tượng nhận thức chủ đề tham chiếu đến các định nghĩa chia sẻ này thay vì lưu trữ mỗi thuộc tính trực quan dưới dạng giá trị cố định, vì vậy việc thay đổi chủ đề có thể cập nhật nhiều đối tượng cùng một lúc.

Trong Aspose.Slides, chủ đề cấp trình chiếu có sẵn thông qua [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/). Một bản trình chiếu cũng có thể chứa các ghi đè chủ đề ở các mức thấp hơn. Một master có thể ghi đè chủ đề trình chiếu thông qua [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/masterthememanager/), trong khi một layout hoặc một slide riêng lẻ có thể ghi đè chủ đề được kế thừa thông qua [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseoverridethememanager/). Thực tế, chủ đề hiệu quả cho một slide được giải quyết thông qua chuỗi kế thừa này: chủ đề trình chiếu, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần của chủ đề: màu sắc, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần dưới đây trình bày những quy trình làm việc phổ biến nhất với chủ đề: kiểm tra chủ đề, thay đổi màu và phông chữ, sao chép hoặc áp dụng chủ đề, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu quả sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra Chủ đề**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/) cung cấp các sơ đồ màu, sơ đồ phông chữ và sơ đồ định dạng của chủ đề thông qua [MasterTheme.getColorScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/) và [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/). Việc kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi bản trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính chủ đề chính và báo cáo số lượng kiểu nền, màu nền, đường nét và hiệu ứng được lưu trong chủ đề:

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

Nếu tệp sử dụng nhiều master, đừng giả định rằng mọi slide đều có cùng một chủ đề hiệu quả. Kiểm tra master được liên kết với slide, và sử dụng quy trình làm việc chủ đề hiệu quả được mô tả sau trong bài viết khi có khả năng tồn tại ghi đè ở layout hoặc slide.

## **Thay đổi Màu Chủ đề**

Các màu nền, đường nét và văn bản nhận thức chủ đề có thể tham chiếu đến một màu logic từ enumeration [SchemeColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [IColorScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icolorscheme/), mọi đối tượng vẫn tham chiếu đến màu chủ đề đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu chủ đề.

Ví dụ end-to-end sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của chủ đề thành màu đỏ, lưu bản trình chiếu, mở lại và in màu nền hiệu quả:

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

Vì hình chữ nhật vẫn được liên kết với `Accent4`, màu hiển thị của nó trở thành màu đỏ sau khi chủ đề được thay đổi. Nếu bạn thay thế màu scheme bằng màu trực tiếp trên hình dạng, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng đến màu nền đó.

### **Sử dụng Màu từ Bảng màu Bổ sung**

PowerPoint tạo các biến thể nhạt hơn và đậm hơn từ một màu chủ đề bằng cách áp dụng các phép biến đổi màu. Aspose.Slides cung cấp các phép biến đổi này thông qua enumeration [ColorTransformOperation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/colortransformoperation/).

![Màu chủ đề chính và các màu nhạt hơn, đậm hơn được tạo từ bảng màu bổ sung](additional-palette-colors.png)

**1** - Màu chủ đề chính.

**2** - Các biến thể nhạt hơn và đậm hơn được tạo từ các màu chủ đề chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các phép biến đổi độ sáng cho năm trong số chúng, và lưu kết quả:

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

### **Ánh xạ Giá trị `SchemeColor` sang Các vị trí `IColorScheme`**

Enumeration [SchemeColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [IColorScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icolorscheme/) cung cấp cùng các vị trí chủ đề dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Ánh xạ này cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên gọi thay thế cho cùng các vị trí chủ đề; chúng không phải là giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi Phông chữ Chủ đề**

Sơ đồ phông chữ chủ đề chứa một bộ phông chữ chính cho tiêu đề và một bộ phụ cho nội dung. Các phương thức [IFontScheme.getMajor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontscheme/) và [IFontScheme.getMinor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontscheme/) cung cấp các bộ này.

Các định danh phông chữ chủ đề tương thích PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` - Phông chữ thân bài Latin (Minor Latin Font)
* `+mj-lt` - Phông chữ tiêu đề Latin (Major Latin Font)
* `+mn-ea` - Phông chữ thân bài Đông Á (Minor East Asian Font)
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

Tiêu đề tuân theo phông chữ chính và nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh chủ đề sẽ không tự động chuyển khi sơ đồ phông chữ chủ đề thay đổi.

Các bộ phông chữ chính và phụ cũng có thể chứa các ánh xạ phông chữ cho các hệ thống viết riêng lẻ, chẳng hạn như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc xóa các ánh xạ này, xem [Script-Specific Theme Fonts](/slides/vi/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Mẹo" %}}
Để biết thêm thông tin về phông chữ trong bản trình chiếu, xem [PowerPoint Fonts](/slides/vi/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc Áp dụng Chủ đề**

Các quy trình bên dưới giải quyết các vấn đề liên quan đến chủ đề khác nhau.

### **Áp dụng Chủ đề Ngoại vi cho Các Slide Phụ Thuộc vào Master**

Sử dụng [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslide/) khi bạn có tệp chủ đề PowerPoint (`.thmx`) và muốn tái thiết kế mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation.getMasters](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) thực thi [IMasterSlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslidecollection/), và truyền đường dẫn tệp chủ đề vào phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một master slide mới dựa trên master đã chọn.
1. Áp dụng chủ đề ngoại vi vào master mới.
1. Gán master mới cho tất cả các slide trước đây phụ thuộc vào master đã chọn.
1. Trả về [IMasterSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslide/) vừa được tạo.

Ví dụ sau áp dụng chủ đề ngoại vi vào các slide phụ thuộc vào master đầu tiên và lưu bản trình chiếu:

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

Một chủ đề không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxReadException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxreadexception/). Hãy xác thực các đường dẫn do người dùng cung cấp, xử lý các lỗi truy cập hệ thống tệp, và chỉ lưu bản trình chiếu sau khi chủ đề đã được áp dụng thành công.

Chỉ các slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với các master khác vẫn giữ nguyên master và chủ đề hiện tại. Các màu, phông chữ, màu nền, đường nét và hiệu ứng nhận thức chủ đề sẽ được giải quyết dựa trên chủ đề ngoại vi. Các màu, phông chữ, màu nền và các định dạng rõ ràng được gán trực tiếp có thể không thay đổi. Các ghi đè ở mức layout và slide cũng có thể có ưu tiên hơn các giá trị kế thừa từ master mới.

Chủ đề có thể tham chiếu đến các phông chữ không có sẵn trong môi trường runtime. Để đảm bảo việc hiển thị và xuất khẩu nhất quán, hãy cài đặt các phông chữ cần thiết, cung cấp chúng qua [custom font sources](/slides/vi/androidjava/custom-font/), hoặc cấu hình [font substitution](/slides/vi/androidjava/font-substitution/).

Đây là một quy trình làm việc trực tiếp ở mức master: phương thức nhận đường dẫn tệp `.thmx` và không yêu cầu tạo thủ công các ghi đè chủ đề ở mức slide hoặc layout.

### **Áp dụng Các Chủ đề Ngoại vi Khác nhau trong Bản Trình chiếu Nhiều Master**

Khi master liên quan không được biết trước, lấy nó từ một slide đại diện thông qua [ISlide.getLayoutSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/) và [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/). Lưu lại các tham chiếu master gốc trước khi áp dụng bất kỳ chủ đề nào vì mỗi lần gọi sẽ tạo một master mới trong bản trình chiếu.

Ví dụ sau sử dụng slide từ hai phần để xác định master của chúng và áp dụng một chủ đề ngoại vi khác nhau cho mỗi nhóm:

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

Lần gọi đầu tiên chỉ ảnh hưởng tới các slide phụ thuộc vào `firstGroupMaster`, và lần gọi thứ hai chỉ ảnh hưởng tới các slide phụ thuộc vào `secondGroupMaster`. Các slide thuộc bất kỳ master nào khác sẽ không được thay đổi giao diện.

### **Bảo tồn Chủ đề Nguồn Khi Di chuyển Slide**

Nếu bạn muốn di chuyển một slide sang bản trình chiếu khác và bảo tồn thiết kế gốc, hãy sao chép master nguồn vào bản trình chiếu đích bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslidecollection/), sau đó sao chép slide bằng [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/) và master đã sao chép. Điều này mang theo master, các layout và chủ đề liên quan cùng nhau.

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

Đây là quy trình làm việc được ưu tiên khi slide nguồn phải giữ nguyên giao diện ở đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể thay đổi các màu, phông chữ, nền và hiệu ứng dựa trên chủ đề.

### **Áp dụng Giá trị Chủ đề cho Slide hiện có**

Nếu slide đích phải ở trên master và layout hiện tại, hãy khởi tạo một ghi đè cấp slide từ chủ đề nguồn. Các phương thức [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/), và [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/) sao chép ba thành phần chính của chủ đề vào ghi đè.

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

Điều này thay đổi chủ đề được slide đó sử dụng mà không thay đổi chủ đề mà các slide khác kế thừa. Để xóa ghi đè cục bộ và quay lại các giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/).

### **Áp dụng Ghi đè Chủ đề cho Layout**

Một ghi đè cấp layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Sử dụng một chủ đề cấp master hoặc trình chiếu khi nhiều layout và slide cần chia sẻ cùng một thiết kế cơ bản, sử dụng ghi đè layout khi một nhóm layout cần phong cách khác, và sử dụng ghi đè slide chỉ cho các ngoại lệ thực sự. Quá nhiều ghi đè cấp slide sẽ làm cho các thay đổi chủ đề toàn cục sau này khó dự đoán.

## **Cập nhật Kiểu nền Chủ đề**

Các màu nền của chủ đề được lưu trong [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/). PowerPoint có thể trình bày nhiều lựa chọn nền hơn trong giao diện người dùng so với số định nghĩa màu nền thực tế được lưu trong bộ sưu tập này vì giao diện có thể kết hợp màu nền chủ đề với màu chủ đề và các tham chiếu kiểu khác.

![Bộ sưu tập kiểu nền PowerPoint cho một chủ đề bản trình chiếu](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, hãy kiểm tra bộ sưu tập đã lưu và [Background.getStyleIndex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/) hiện tại. Chỉ số kiểu `0` có nghĩa là không có màu nền chủ đề; các giá trị dương là các tham chiếu kiểu nền chủ đề. Điều này khác với việc đánh chỉ số trực tiếp vào bộ sưu tập Java, trong đó `get_Item(0)` nghĩa là mục đầu tiên được lưu. Đừng giả định rằng mọi bản trình chiếu đều chứa cùng số lượng kiểu nền.

Ví dụ sau báo cáo số lượng màu nền có sẵn, gán một tham chiếu nền chủ đề cho master đầu tiên, và lưu bản trình chiếu:

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

Kết quả hiển thị phụ thuộc vào mục chủ đề mà master tham chiếu và bất kỳ ghi đè nền nào ở mức layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không thay đổi slide đó. Sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/) khi bạn cần biết nền cuối cùng sau khi đã áp dụng kế thừa.

{{% alert color="warning" title="Cảnh báo" %}}
Đừng coi chỉ số kiểu như một chỉ số bộ sưu tập bắt đầu từ 0. Cũng tránh việc mã cứng một số kiểu từ một tệp và cho rằng nó sẽ có cùng giao diện trong tệp khác; các định nghĩa kiểu chủ đề là riêng cho từng bản trình chiếu.
{{% /alert %}}

{{% alert color="info" title="Mẹo" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/androidjava/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Chủ đề**

Một sơ đồ định dạng chủ đề chứa các bộ sưu tập riêng biệt cho màu nền, đường nét và hiệu ứng được mở ra qua [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/), và [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/). Các chủ đề Office thông thường thường chứa ba mục kiểu chính tương ứng trực quan với định dạng nhẹ, vừa và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Hiệu ứng chủ đề nhẹ, vừa và mạnh được áp dụng cho cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong Java, chỉ số bộ sưu tập bắt đầu từ 0: `get_Item(0)` là kiểu đầu tiên được lưu và `get_Item(2)` là kiểu thứ ba. Các chỉ số tham chiếu kiểu của hình dạng là một khái niệm riêng, được mở ra qua [IShapeStyle](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapestyle/). Việc sửa đổi một kiểu chủ đề ảnh hưởng đến các hình dạng tham chiếu tới kiểu đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục kiểu cần thiết, thay đổi kiểu đường nét đầu tiên, thay đổi kiểu màu nền thứ ba, bật bóng đổ bên ngoài trong kiểu hiệu ứng thứ ba, và lưu kết quả:

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

Đối với các hình dạng tham chiếu các vị trí này, kiểu đường nét chủ đề đầu tiên sẽ trở thành màu đỏ, kiểu màu nền chủ đề thứ ba sẽ trở thành màu xanh rừng đặc, và kiểu hiệu ứng thứ ba sẽ có một bóng đổ bên ngoài với khoảng cách 10 điểm. Kết quả hình ảnh cuối cùng vẫn phụ thuộc vào vị trí kiểu mà mỗi hình dạng tham chiếu và liệu định dạng trực tiếp có ghi đè lên chủ đề hay không.

![Các kiểu hiệu ứng chủ đề sau khi thay đổi đường nét, màu nền và cài đặt bóng đổ](presentation-design_11.png)

## **Đọc Giá trị Chủ đề Hiệu quả**

Các đối tượng chủ đề thô cho bạn biết những gì được định nghĩa ở mức cụ thể. Các giá trị hiệu quả cho bạn biết một slide hoặc hình dạng thực tế sử dụng gì sau khi kế thừa và ghi đè cục bộ đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseoverridethememanager/). Đối với nền, dùng [Background.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/), và đối với màu nền, dùng [FillFormat.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/).

Ví dụ sau đọc chủ đề hiệu quả, nền và màu nền của hình dạng đầu tiên từ một slide:

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

Sử dụng dữ liệu hiệu quả cho chẩn đoán hiển thị, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/), bạn có thể bỏ lỡ một master, layout, slide hoặc ghi đè hình dạng làm thay đổi giao diện cuối cùng.

## **Câu hỏi thường gặp**

**Áp dụng một chủ đề ngoại vi có ảnh hưởng tới mọi slide trong bản trình chiếu không?**

Không. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslide/) chỉ gán lại các slide phụ thuộc vào master đã chọn. Các slide sử dụng các master khác vẫn giữ nguyên chủ đề hiện tại.

**Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidethememanager/) của slide và khởi tạo ghi đè chủ đề của nó. Thay đổi sẽ chỉ áp dụng cục bộ cho slide đó; các slide khác vẫn kế thừa chủ đề hiện tại.

**Cách an toàn nhất để mang một chủ đề từ bản trình chiếu này sang bản khác là gì?**

Khi di chuyển một slide và muốn giữ nguyên giao diện nguồn, hãy sao chép master nguồn vào bản đích và sao chép slide với master đó bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslidecollection/) và [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/). Điều này giữ nguyên master, layout và chủ đề cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu quả sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseoverridethememanager/) cho một slide hoặc layout và các phương thức dữ liệu hiệu quả tương ứng cho các đối tượng định dạng như [Background.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/) và [FillFormat.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/). Những API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.