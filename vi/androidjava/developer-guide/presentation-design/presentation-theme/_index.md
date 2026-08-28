---
title: Quản lý Chủ đề Trình chiếu trên Android
linktitle: Chủ đề Trình chiếu
type: docs
weight: 10
url: /vi/androidjava/presentation-theme/
keywords:
- chủ đề PowerPoint
- chủ đề trình chiếu
- chủ đề slide
- đặt chủ đề
- thay đổi chủ đề
- quản lý chủ đề
- chủ đề bên ngoài
- THMX
- màu chủ đề
- bảng màu bổ sung
- phông chữ chủ đề
- kiểu chủ đề
- hiệu ứng chủ đề
- PowerPoint
- OpenDocument
- trình chiếu
- Android
- Java
- Aspose.Slides
description: "Quản lý các chủ đề trình chiếu trong Aspose.Slides cho Android bằng Java để tạo, tùy chỉnh và chuyển đổi các tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề trình chiếu định nghĩa một tập hợp phối hợp các màu, phông chữ, kiểu nền, màu nền, đường kẻ và hiệu ứng. Các đối tượng nhận thức chủ đề tham chiếu đến các định nghĩa chung này thay vì lưu trữ mỗi thuộc tính hình ảnh dưới dạng giá trị cố định, vì vậy việc thay đổi chủ đề có thể cập nhật nhiều đối tượng cùng một lúc.

Trong Aspose.Slides, chủ đề ở mức trình chiếu có sẵn qua [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/). Một trình chiếu cũng có thể chứa các ghi đè chủ đề ở các mức thấp hơn. Một master có thể ghi đè chủ đề trình chiếu qua [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/masterthememanager/), trong khi một layout hoặc một slide riêng lẻ có thể ghi đè chủ đề kế thừa của nó qua [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseoverridethememanager/). Thực tế, chủ đề thực tế cho một slide được giải quyết qua chuỗi kế thừa này: chủ đề trình chiếu, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần của chủ đề: màu, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần bên dưới cho thấy các quy trình làm việc với chủ đề phổ biến nhất: kiểm tra một chủ đề, thay đổi màu và phông chữ, sao chép hoặc áp dụng một chủ đề, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị thực tế sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Chủ đề**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/) cung cấp sơ đồ màu, sơ đồ phông chữ và sơ đồ định dạng của chủ đề qua [MasterTheme.getColorScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/) và [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/mastertheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi một trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung của các mục định dạng có thể khác nhau.

Ví dụ sau đọc các thuộc tính chủ đề chính và báo cáo có bao nhiêu kiểu nền, màu nền, đường kẻ và hiệu ứng được lưu trong chủ đề:

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

Nếu một tệp sử dụng nhiều master, không nên giả định rằng mọi slide có cùng một chủ đề thực tế. Kiểm tra master liên kết với slide, và sử dụng quy trình chủ đề thực tế được mô tả sau trong bài viết khi có khả năng có ghi đè layout hoặc slide.

## **Thay đổi Màu Chủ đề**

Các màu tô, đường kẻ và văn bản nhận thức chủ đề có thể tham chiếu đến một màu logic từ enumeration [SchemeColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [IColorScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icolorscheme/), tất cả các đối tượng vẫn tham chiếu tới màu chủ đề đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu chủ đề.

Ví dụ end‑to‑end sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của chủ đề thành màu đỏ, lưu trình chiếu, mở lại và in màu tô thực tế:

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

Vì hình chữ nhật vẫn được liên kết tới `Accent4`, màu hiển thị của nó sẽ trở thành màu đỏ sau khi chủ đề được thay đổi. Nếu bạn thay thế màu scheme bằng một màu trực tiếp trên hình dạng, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng đến màu tô đó.

### **Sử dụng Màu từ Bảng Màu Bổ sung**

PowerPoint tạo các biến thể sáng hơn và tối hơn từ một màu chủ đề bằng cách áp dụng các phép biến đổi màu. Aspose.Slides cung cấp các phép biến đổi này qua enumeration [ColorTransformOperation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/colortransformoperation/).

![Màu chủ đề chính và các màu sáng/tối được tạo từ bảng màu bổ sung](additional-palette-colors.png)

**1** - Màu chủ đề chính.

**2** - Các biến thể sáng hơn và tối hơn được tạo từ các màu chủ đề chính.

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

Các biến thể này vẫn dựa trên màu chủ đề. Nếu `Accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại từ giá trị `Accent4` mới.

### **Ánh xạ Giá trị `SchemeColor` tới Các Vị trí `IColorScheme`**

Enumeration [SchemeColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [IColorScheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icolorscheme/) bật ra cùng các vị trí chủ đề dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Bảng ánh xạ cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng các vị trí chủ đề; chúng không phải là giá trị được chuyển đổi động từ dạng này sang dạng kia.

## **Thay đổi Phông chữ Chủ đề**

Một sơ đồ phông chữ chủ đề chứa một bộ phông chữ chính cho tiêu đề và một bộ phông chữ phụ cho nội dung. Các phương thức [IFontScheme.getMajor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontscheme/) và [IFontScheme.getMinor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifontscheme/) cung cấp các bộ này.

Các định danh phông chữ chủ đề tương thích PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` - Phông chữ nội dung Latin (Minor Latin Font)
* `+mj-lt` - Phông chữ tiêu đề Latin (Major Latin Font)
* `+mn-ea` - Phông chữ nội dung Đông Á (Minor East Asian Font)
* `+mj-ea` - Phông chữ tiêu đề Đông Á (Major East Asian Font)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi các phông chữ chủ đề và lưu kết quả:

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

Tiêu đề sẽ theo phông chữ chính và nội dung sẽ theo phông chữ phụ. Văn bản có tên phông chữ rõ ràng thay vì định danh chủ đề sẽ không tự động chuyển khi sơ đồ phông chữ chủ đề thay đổi.

Các bộ phông chữ chính và phụ cũng có thể chứa các ánh xạ phông chữ cho các hệ thống viết riêng lẻ, chẳng hạn như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc xóa các ánh xạ này, xem mục [Script‑Specific Theme Fonts](/slides/vi/androidjava/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong trình chiếu, xem [PowerPoint Fonts](/slides/vi/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc Áp dụng một Chủ đề**

Các quy trình dưới đây giải quyết các vấn đề khác nhau liên quan tới chủ đề.

### **Áp dụng Chủ đề Bên ngoài vào Các Slide Phụ thuộc Master**

Sử dụng [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslide/) khi bạn có một tệp chủ đề PowerPoint (`.thmx`) và muốn thay đổi kiểu dáng của mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation.getMasters](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) hiện thực [IMasterSlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslidecollection/), và truyền đường dẫn tệp chủ đề vào phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một master slide mới dựa trên master đã chọn.
1. Áp dụng chủ đề bên ngoài vào master mới.
1. Gán master mới cho tất cả các slide trước đây phụ thuộc vào master đã chọn.
1. Trả về đối tượng [IMasterSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslide/) vừa tạo.

Ví dụ sau áp dụng một chủ đề bên ngoài vào các slide phụ thuộc vào master đầu tiên và lưu trình chiếu:

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

Một chủ đề không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxReadException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxreadexception/). Xác thực các đường dẫn do người dùng cung cấp, xử lý các lỗi truy cập hệ thống tệp, và chỉ lưu trình chiếu sau khi chủ đề đã được áp dụng thành công.

Chỉ các slide phụ thuộc vào master đã chọn sẽ được gán lại. Các slide liên kết với các master khác giữ nguyên master và chủ đề hiện có. Các màu, phông chữ, màu nền, đường kẻ và hiệu ứng nhận thức chủ đề sẽ được giải quyết dựa trên chủ đề bên ngoài. Các màu, phông chữ, màu nền và các định dạng rõ ràng được gán trực tiếp có thể không thay đổi. Các ghi đè ở mức layout và slide cũng có thể ưu tiên hơn các giá trị kế thừa từ master mới.

Chủ đề có thể tham chiếu đến các phông chữ không có trong môi trường runtime. Để đảm bảo việc hiển thị và xuất đúng, hãy cài đặt các phông chữ cần thiết, cung cấp chúng qua [nguồn phông chữ tùy chỉnh](/slides/vi/androidjava/custom-font/), hoặc cấu hình [thay thế phông chữ](/slides/vi/androidjava/font-substitution/).

Đây là quy trình làm việc trực tiếp ở mức master: phương thức chấp nhận một đường dẫn tệp `.thmx` và không yêu cầu tạo các ghi đè chủ đề ở mức slide hay layout một cách thủ công.

### **Áp dụng Các Chủ đề Bên ngoài Khác nhau trong Một Trình chiếu Đa‑Master**

Khi master liên quan không được biết trước, lấy nó từ một slide đại diện qua [ISlide.getLayoutSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/) và [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/). Lưu trữ các tham chiếu master gốc trước khi áp dụng bất kỳ chủ đề nào vì mỗi lần gọi sẽ tạo một master mới trong trình chiếu.

Ví dụ sau dùng các slide từ hai phần để tìm master của chúng và áp dụng một chủ đề bên ngoài khác nhau cho mỗi nhóm:

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

Lời gọi đầu tiên chỉ ảnh hưởng tới các slide phụ thuộc vào `firstGroupMaster`, và lời gọi thứ hai chỉ ảnh hưởng tới các slide phụ thuộc vào `secondGroupMaster`. Các slide thuộc bất kỳ master nào khác sẽ không bị thay đổi kiểu dáng.

### **Bảo tồn Chủ đề Nguồn Khi Di chuyển Slides**

Nếu bạn muốn di chuyển một slide sang một trình chiếu khác và giữ nguyên thiết kế gốc, hãy sao chép master nguồn vào trình chiếu đích bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslidecollection/), sau đó sao chép slide bằng [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/) cùng với master đã sao chép. Điều này mang master, các layout của nó và chủ đề liên quan cùng nhau.

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

Đây là quy trình ưu tiên khi slide nguồn phải trông giống hệt trong đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể làm thay đổi các màu, phông chữ, nền và hiệu ứng được điều khiển bởi chủ đề.

### **Áp dụng Giá trị Chủ đề cho Slide hiện có**

Nếu slide đích phải ở lại master và layout hiện tại, hãy khởi tạo một ghi đè ở mức slide từ chủ đề nguồn. Các phương thức [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/) và [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/) sao chép ba thành phần chính của chủ đề vào ghi đè.

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

Điều này thay đổi chủ đề được slide sử dụng mà không thay đổi chủ đề được kế thừa bởi các slide khác. Để xóa ghi đè cục bộ và trở về các giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/overridetheme/).

### **Áp dụng Ghi đè Chủ đề cho Layout**

Một ghi đè ở mức layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/layoutslidethememanager/):

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

Sử dụng chủ đề ở mức master hoặc trình chiếu khi nhiều layout và slide cần chia sẻ cùng một thiết kế cơ bản, sử dụng ghi đè layout khi một nhóm layout cần kiểu dáng khác, và chỉ dùng ghi đè slide cho các ngoại lệ thực sự. Việc lạm dụng ghi đè ở mức slide khiến các thay đổi chủ đề toàn cục sau này trở nên khó dự đoán.

## **Cập nhật Kiểu Nền Chủ đề**

Các màu nền của chủ đề được lưu trong [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện người dùng so với số lượng định nghĩa màu nền thực tế trong bộ sưu tập này vì UI có thể kết hợp các màu nền chủ đề với các màu chủ đề và các tham chiếu kiểu khác.

![Bộ sưu tập kiểu nền PowerPoint cho một chủ đề trình chiếu](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, hãy kiểm tra bộ sưu tập đã lưu và [Background.getStyleIndex](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/) hiện tại. Chỉ số kiểu `0` có nghĩa là không có màu nền chủ đề; các giá trị dương là các tham chiếu kiểu nền chủ đề. Điều này khác với việc đánh chỉ số trực tiếp vào bộ sưu tập Java, nơi `get_Item(0)` là mục đầu tiên được lưu. Đừng giả định rằng mọi trình chiếu có cùng số lượng kiểu nền.

Ví dụ sau báo cáo số lượng màu nền có sẵn, gán một tham chiếu nền chủ đề cho master đầu tiên và lưu trình chiếu:

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

Kết quả hiển thị sẽ phụ thuộc vào mục nhập chủ đề mà master tham chiếu và bất kỳ ghi đè nền nào ở mức layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không ảnh hưởng đến slide đó. Hãy sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/) khi cần biết nền cuối cùng sau khi đã áp dụng kế thừa.

{{% alert color="warning" title="Warning" %}}
Đừng xem chỉ số kiểu như một chỉ số bộ sưu tập bắt đầu từ 0. Cũng nên tránh việc mã cứng một số kiểu từ một tệp và giả định nó sẽ có cùng giao diện trong tệp khác; các định nghĩa kiểu chủ đề là riêng cho từng trình chiếu.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với việc định dạng nền trực tiếp và kế thừa nền, xem mục [Presentation Background](/slides/vi/androidjava/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Chủ đề**

Một sơ đồ định dạng chủ đề chứa các bộ sưu tập riêng biệt cho màu nền, đường kẻ và hiệu ứng được mở ra qua [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/) và [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iformatscheme/). Các chủ đề Office thông thường thường chứa ba mục kiểu chính tương ứng với định dạng tinh tế, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định một số cố định.

![Hiệu ứng chủ đề tinh tế, trung bình và mạnh được áp dụng cho cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong Java, chỉ số bộ sưu tập bắt đầu từ 0: `get_Item(0)` là kiểu đầu tiên được lưu và `get_Item(2)` là kiểu thứ ba. Các chỉ số tham chiếu kiểu của hình dạng là một khái niệm riêng, được mở ra qua [IShapeStyle](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapestyle/). Việc sửa đổi một kiểu chủ đề sẽ ảnh hưởng tới các hình dạng tham chiếu tới kiểu đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra tồn tại các mục kiểu cần thiết, thay đổi kiểu đường kẻ đầu tiên, thay đổi kiểu màu nền thứ ba, bật bóng đổ ngoài trong kiểu hiệu ứng thứ ba, và lưu kết quả:

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

Đối với các hình dạng tham chiếu các vị trí này, kiểu đường kẻ chủ đề đầu tiên sẽ thành màu đỏ, kiểu màu nền thứ ba sẽ thành màu xanh rừng đặc, và kiểu hiệu ứng thứ ba sẽ được thêm bóng đổ ngoài với khoảng cách 10 điểm. Kết quả hình ảnh cuối cùng vẫn phụ thuộc vào các vị trí kiểu mà mỗi hình dạng tham chiếu và liệu định dạng trực tiếp có ghi đè chủ đề hay không.

![Các kiểu hiệu ứng chủ đề sau khi thay đổi đường kẻ, màu nền và cài đặt bóng đổ](presentation-design_11.png)

## **Xác định Liệu Một Màu Đổ Rắn Thực tế Có Dùng Màu Chủ đề Hay Không**

Một màu đổ có thể được lưu trực tiếp trên một đối tượng hoặc kế thừa từ đoạn văn, layout, master, kiểu chủ đề hoặc một mức định dạng khác. Gọi [IFillFormat.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifillformat/) để giải quyết cấp độ này thành một đối tượng không thay đổi [IFillFormatEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifillformateffectivedata/). Đầu tiên kiểm tra [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifillformateffectivedata/). Chỉ khi giá trị là `FillType.Solid` mới đọc các thuộc tính màu đổ rắn.

Đối với màu đổ rắn, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifillformateffectivedata/) trả về giá trị RGB cuối cùng sau khi áp dụng kế thừa, tra cứu chủ đề và các phép biến đổi màu. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ifillformateffectivedata/) trả về vị trí logic [SchemeColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/schemecolor/) tương ứng, chẳng hạn `Text1` hoặc `Accent6`. Giá trị `SchemeColor.NotDefined` có nghĩa là màu đổ rắn không dựa trên một màu scheme. Trong quy trình nơi các màu đổ là màu chủ đề hoặc màu RGB trực tiếp, giá trị này cho biết màu đổ là RGB trực tiếp.

Đừng chỉ dùng giá trị cục bộ [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icolorformat/) để phân loại một màu đổ. Ví dụ, một đoạn văn bản có thể không có màu scheme được định nghĩa cục bộ, vì vậy giá trị cục bộ là `NotDefined`, trong khi màu đổ thực tế kế thừa một màu chủ đề và giải quyết thành `Text1` hoặc `Accent6`. Ngược lại, `getSolidFillSchemeColor` cho bạn biết vị trí logic nào của chủ đề đã tạo ra màu thực tế, nhưng không cho biết vị trí đó đến từ đối tượng, đoạn văn, layout, master hay mức định dạng nào khác.

Ví dụ sau tải một trình chiếu, kiểm tra cả màu đổ của hình dạng và màu đổ của đoạn văn bản, in ra mỗi giá trị RGB cuối cùng và màu scheme liên quan, và đánh dấu các màu đổ rắn sẽ không theo dõi thay đổi màu chủ đề:

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

Nhánh `NotDefined` cung cấp một danh sách kiểm tra các màu đổ rắn sẽ không phản hồi khi các vị trí màu chủ đề thay đổi. Xem xét các đối tượng này khi một trình chiếu phải tuân theo bảng màu thương hiệu mới. Giá trị RGB được báo vẫn hiển thị giao diện hiện tại, trong khi giá trị scheme giải thích liệu giao diện đó có liên kết với chủ đề hay không.

Các đối tượng định dạng thực tế là ảnh chụp nhanh. Sau khi thay đổi chủ đề trình chiếu, một ghi đè chủ đề, hoặc bất kỳ định dạng kế thừa nào, gọi `getEffective` một lần nữa và đọc một đối tượng `IFillFormatEffectiveData` mới trước khi so sánh hoặc báo cáo màu.

## **Đọc Các Giá trị Chủ đề Thực tế**

Các đối tượng chủ đề thô cho bạn biết những gì được định nghĩa ở một mức cụ thể. Các giá trị thực tế cho bạn biết slide hoặc hình dạng thực tế sử dụng gì sau khi kế thừa và ghi đè cục bộ đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseoverridethememanager/). Đối với nền, dùng [Background.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/), và đối với màu đổ, dùng [FillFormat.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/).

Ví dụ sau đọc chủ đề thực tế, nền và màu đổ hình dạng đầu tiên từ một slide:

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

Sử dụng dữ liệu thực tế cho chẩn đoán hiển thị, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/), bạn có thể bỏ lỡ một master, layout, slide hoặc ghi đè hình dạng làm thay đổi giao diện cuối cùng.

## **Câu Hỏi Thường Gặp**

**Áp dụng một chủ đề bên ngoài có ảnh hưởng đến mọi slide trong trình chiếu không?**

Không. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslide/) chỉ gán lại các slide phụ thuộc vào master đã chọn. Các slide sử dụng các master khác giữ nguyên chủ đề hiện có.

**Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidethememanager/) của slide và khởi tạo ghi đè chủ đề của nó. Thay đổi sẽ chỉ áp dụng cục bộ cho slide đó; các slide khác vẫn kế thừa chủ đề hiện tại.

**Cách an toàn nhất để mang một chủ đề từ trình chiếu này sang trình chiếu khác là gì?**

Khi di chuyển một slide và muốn bảo tồn thiết kế nguồn, sao chép master nguồn vào đích và sao chép slide cùng master đó bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslidecollection/) và [ISlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecollection/). Điều này giữ nguyên master, các layout và chủ đề đồng thời.

**Làm sao tôi có thể xem các giá trị thực tế sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseoverridethememanager/) cho một slide hoặc layout và các phương thức dữ liệu‑thực tế tương ứng cho các đối tượng định dạng như [Background.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/background/) và [FillFormat.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/). Các API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.