---
title: Quản lý Chủ đề Bản thuyết trình trong Java
linktitle: Chủ đề Bản thuyết trình
type: docs
weight: 10
url: /vi/java/presentation-theme/
keywords:
- chủ đề PowerPoint
- chủ đề bản thuyết trình
- chủ đề slide
- đặt chủ đề
- thay đổi chủ đề
- quản lý chủ đề
- chủ đề ngoài
- THMX
- màu chủ đề
- bảng màu bổ sung
- phông chữ chủ đề
- kiểu chủ đề
- hiệu ứng chủ đề
- PowerPoint
- OpenDocument
- bản thuyết trình
- Java
- Aspose.Slides
description: "Quản lý các chủ đề bản thuyết trình trong Aspose.Slides cho Java để tạo, tùy chỉnh và chuyển đổi các tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề bản thuyết trình định nghĩa một tập hợp phối hợp các màu sắc, phông chữ, kiểu nền, màu nền, đường và hiệu ứng. Các đối tượng nhận thức chủ đề tham chiếu đến các định nghĩa chung này thay vì lưu trữ mỗi thuộc tính hình ảnh dưới dạng giá trị cố định, vì vậy việc thay đổi chủ đề có thể cập nhật nhiều đối tượng cùng một lúc.

Trong Aspose.Slides, chủ đề ở mức bản thuyết trình có sẵn thông qua [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). Một bản thuyết trình cũng có thể chứa các ghi đè chủ đề ở các cấp thấp hơn. Một master có thể ghi đè chủ đề bản thuyết trình thông qua [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/masterthememanager/), trong khi một layout hoặc một slide riêng lẻ có thể ghi đè chủ đề kế thừa của nó thông qua [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/). Thực tế, chủ đề hiệu quả cho một slide được giải quyết thông qua chuỗi kế thừa này: chủ đề bản thuyết trình, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần của chủ đề: màu sắc, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần bên dưới cho thấy các quy trình làm việc với chủ đề phổ biến nhất: kiểm tra một chủ đề, thay đổi màu sắc và phông chữ, sao chép hoặc áp dụng một chủ đề, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu quả sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Chủ đề**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) cung cấp sơ đồ màu, sơ đồ phông chữ và sơ đồ định dạng của chủ đề thông qua [MasterTheme.getColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) và [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi bản thuyết trình đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể khác nhau.

Ví dụ sau đọc các thuộc tính chủ đề chính và báo cáo có bao nhiêu kiểu nền, màu nền, đường và hiệu ứng được lưu trong chủ đề:

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

Nếu một tệp sử dụng nhiều master, đừng giả định rằng mọi slide đều có cùng một chủ đề hiệu quả. Kiểm tra master liên kết với slide, và sử dụng quy trình làm việc chủ đề hiệu quả được mô tả sau trong bài viết này khi có thể có ghi đè layout hoặc slide.

## **Thay đổi Màu sắc Chủ đề**

Các màu nền, đường và văn bản nhận thức chủ đề có thể tham chiếu đến một màu logic từ enum [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/), tất cả các đối tượng vẫn tham chiếu tới màu chủ đề đó sẽ được giải quyết theo giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu chủ đề.

Ví dụ toàn diện sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của chủ đề thành màu đỏ, lưu bản thuyết trình, mở lại và in màu nền hiệu quả:

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

Vì hình chữ nhật vẫn được liên kết với `Accent4`, màu hiển thị của nó sẽ trở thành đỏ sau khi chủ đề được thay đổi. Nếu bạn thay thế màu lược đồ bằng một màu trực tiếp trên hình dạng, các thay đổi sau này của `Accent4` sẽ không còn ảnh hưởng đến màu nền đó.

### **Sử dụng Màu từ Bảng Màu Bổ sung**

PowerPoint tạo các biến thể sáng hơn và tối hơn từ một màu chủ đề bằng cách áp dụng các biến đổi màu. Aspose.Slides cung cấp các biến đổi này qua enum [ColorTransformOperation](https://reference.aspose.com/slides/java/com.aspose.slides/colortransformoperation/).

![Các màu chủ đề chính và các màu sáng hơn, tối hơn được tạo ra từ bảng màu bổ sung](additional-palette-colors.png)

**1** - Các màu chủ đề chính.

**2** - Các biến thể sáng hơn và tối hơn được tạo ra từ các màu chủ đề chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các biến đổi độ sáng cho năm trong số chúng, và lưu kết quả:

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

### **Ánh xạ Giá trị `SchemeColor` tới Các vị trí `IColorScheme`**

Enum [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) cung cấp các vị trí chủ đề giống nhau dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Bản đồ cố định như sau:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng một vị trí chủ đề; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi Phông chữ Chủ đề**

Một sơ đồ phông chữ chủ đề chứa một bộ phông chữ lớn cho tiêu đề và một bộ phông chữ nhỏ cho nội dung. Các phương thức [IFontScheme.getMajor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) và [IFontScheme.getMinor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) cung cấp các bộ này.

Các định danh phông chữ chủ đề tương thích PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` - Phông chữ nội dung Latin (Phông chữ Latin phụ)
* `+mj-lt` - Phông chữ tiêu đề Latin (Phông chữ Latin chính)
* `+mn-ea` - Phông chữ nội dung Đông Á (Phông chữ Đông Á phụ)
* `+mj-ea` - Phông chữ tiêu đề Đông Á (Phông chữ Đông Á chính)
* `+mn-cs` - Phông chữ nội dung Kịch bản Phức hợp (Phông chữ Complex Script phụ)
* `+mj-cs` - Phông chữ tiêu đề Kịch bản Phức hợp (Phông chữ Complex Script chính)

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

Tiêu đề tuân theo phông chữ chính và nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh chủ đề sẽ không tự động chuyển khi sơ đồ phông chữ chủ đề thay đổi.

Các bộ phông chữ chính và phụ cũng có thể chứa các ánh xạ phông chữ cho các hệ thống viết riêng lẻ, chẳng hạn như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc xóa các ánh xạ này, xem [Script-Specific Theme Fonts](/slides/vi/java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong bản thuyết trình, xem [PowerPoint Fonts](/slides/vi/java/powerpoint-fonts/).
{{% /alert %}}

### **Giải quyết Tham chiếu Phông chữ Chủ đề**

Khi kiểm tra văn bản, [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName--) có thể trả về một tham chiếu chủ đề như `+mn-lt` thay vì tên họ phông chữ. Gọi [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) với [IThemeEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeeffectivedata/) thích hợp để giải quyết tham chiếu đó. Các tiền tố `+mj` và `+mn` chọn bộ phông chữ chính và phụ; các hậu tố `-lt`, `-ea` và `-cs` chọn phông chữ Latin, Đông Á và Kịch bản Phức hợp tương ứng.

Lấy chủ đề hiệu quả qua [IThemeable.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeable/#createThemeEffective--) trên đối tượng mà chủ đề áp dụng cho văn bản được kiểm tra. Đối với văn bản thông thường trên một slide, gọi phương thức này trên slide để ngữ cảnh bao gồm chủ đề kế thừa của slide và các ghi đè cục bộ. Khi kiểm tra một layout hoặc master, sử dụng chủ đề hiệu quả của chính nó. Đừng giả định rằng chủ đề của master đầu tiên áp dụng cho mọi slide.

Ví dụ sau tạo một đoạn văn bản tham chiếu rõ ràng tới phông chữ Latin phụ. Nó khởi tạo sơ đồ phông chữ slide qua [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) và đặt họ phông chữ Latin chính và phụ thành `Arial` và `Calibri`, để kết quả có thể tái tạo mà không cần tệp đầu vào.

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

Kết quả là `+mn-lt -> Calibri` tiếp theo là `Verdana -> Verdana`. Tham chiếu đã lưu vẫn không thay đổi, trong khi tên họ phông chữ cụ thể được trả về nguyên trạng. Nếu đoạn văn bản sử dụng `+mj-lt`, nó sẽ giải quyết thành `Arial` trong chủ đề này.

Giải quyết một tham chiếu chủ đề xác định họ phông chữ do chủ đề chỉ định. Nó không kiểm tra tính khả dụng của phông chữ hay xác định tệp phông chữ thực tế được sử dụng sau khi thay thế hoặc fallback glyph trong quá trình render. Xem [Font Selection Sequence](/slides/vi/java/font-selection-sequence/) và [Font Substitution](/slides/vi/java/font-substitution/) cho các bước riêng biệt đó.

## **Sao chép hoặc Áp dụng một Chủ đề**

Các quy trình dưới đây giải quyết các vấn đề liên quan đến chủ đề khác nhau.

### **Áp dụng Chủ đề Ngoài vào Các Slide Phụ thuộc vào Master**

Sử dụng [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) khi bạn có một tệp chủ đề PowerPoint (`.thmx`) và muốn thay đổi kiểu dáng mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) mà triển khai [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), và truyền đường dẫn tệp chủ đề vào phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một master slide mới dựa trên master đã chọn.
1. Áp dụng chủ đề ngoài vào master mới.
1. Gán master mới cho tất cả slide trước đây phụ thuộc vào master đã chọn.
1. Trả về đối tượng [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) mới được tạo.

Ví dụ sau áp dụng một chủ đề ngoài vào các slide phụ thuộc vào master đầu tiên và lưu bản thuyết trình:

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

Một chủ đề không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxReadException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxreadexception/). Xác thực các đường dẫn do người dùng cung cấp, xử lý các lỗi truy cập hệ thống tập tin, và chỉ lưu bản thuyết trình sau khi chủ đề đã được áp dụng thành công.

Chỉ các slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với các master khác vẫn giữ nguyên master và chủ đề hiện tại. Các màu, phông chữ, màu nền, đường và hiệu ứng nhận thức chủ đề sẽ được giải quyết theo chủ đề ngoài. Các màu, phông chữ, màu nền và định dạng rõ ràng được gán trực tiếp có thể vẫn không thay đổi. Các ghi đè cấp layout và slide cũng có thể ưu tiên so với các giá trị kế thừa từ master mới.

Chủ đề có thể tham chiếu đến các phông chữ không có sẵn trong môi trường runtime. Để đảm bảo việc render và xuất khẩu nhất quán, hãy cài đặt các phông chữ cần thiết, cung cấp chúng qua [custom font sources](/slides/vi/java/custom-font/), hoặc cấu hình [font substitution](/slides/vi/java/font-substitution/).

Đây là quy trình trực tiếp ở cấp master: phương thức nhận một đường dẫn tệp `.thmx` và không yêu cầu tạo thủ công các ghi đè chủ đề ở cấp slide hoặc layout.

### **Áp dụng Các Chủ đề Ngoài Khác nhau trong Một Bản Thuyết trình Nhiều Master**

Khi master liên quan không được biết trước, lấy nó từ một slide đại diện qua [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) và [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/). Lưu các tham chiếu master gốc trước khi áp dụng bất kỳ chủ đề nào vì mỗi lần gọi sẽ tạo một master mới trong bản thuyết trình.

Ví dụ sau sử dụng slide từ hai phần để xác định master của chúng và áp dụng một chủ đề ngoài khác nhau cho mỗi nhóm:

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

Lần gọi đầu tiên chỉ ảnh hưởng đến các slide phụ thuộc vào `firstGroupMaster`, và lần gọi thứ hai chỉ ảnh hưởng đến các slide phụ thuộc vào `secondGroupMaster`. Các slide thuộc bất kỳ master nào khác sẽ không được thay đổi kiểu.

### **Bảo tồn Chủ đề Nguồn Khi Di chuyển Slides**

Nếu bạn muốn di chuyển một slide sang bản thuyết trình khác và giữ nguyên thiết kế gốc, sao chép master nguồn vào bản thuyết trình đích bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/), sau đó sao chép slide bằng [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) và master đã sao chép. Điều này mang theo master, các layout và chủ đề liên quan cùng nhau.

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

Đây là quy trình ưu tiên khi slide nguồn phải trông giống hệt ở đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể làm thay đổi các màu, phông chữ, nền và hiệu ứng dựa trên chủ đề.

### **Áp dụng Giá trị Chủ đề cho Một Slide Đã Tồn tại**

Nếu slide đích phải ở trên master và layout hiện tại, khởi tạo một ghi đè cấp slide từ chủ đề nguồn. Các phương thức [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) và [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) sao chép ba thành phần chính của chủ đề vào ghi đè.

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

Điều này thay đổi chủ đề được slide sử dụng mà không thay đổi chủ đề mà các slide khác kế thừa. Để xóa ghi đè cục bộ và quay lại giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/).

### **Áp dụng Ghi đè Chủ đề cho Một Layout**

Ghi đè cấp layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslidethememanager/):

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

Sử dụng một chủ đề cấp master hoặc bản thuyết trình khi nhiều layout và slide nên chia sẻ cùng một thiết kế cơ bản, ghi đè layout khi một họ layout cần kiểu dáng khác, và ghi đè slide chỉ cho các ngoại lệ thực sự. Quá nhiều ghi đè cấp slide làm cho các thay đổi chủ đề toàn cục sau này khó dự đoán.

<!-- visual-explanation:presentation-theme:start -->
[![Một chủ đề master cung cấp cho hai layout; một ghi đè layout ảnh hưởng đến các slide của nó ngoại trừ một slide có ghi đè cục bộ hơn.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*Một ghi đè layout áp dụng cho các slide sử dụng layout đó trừ khi một slide cung cấp ghi đè riêng. Các giá trị dựa trên chủ đề tuân theo sơ đồ đã giải quyết; các đối tượng định dạng rõ ràng có thể giữ nguyên ngoại hình cục bộ. Giữ ghi đè càng hẹp càng tốt để phù hợp với ngoại lệ thiết kế dự định.* 
<!-- visual-explanation:presentation-theme:end -->

## **Cập nhật Kiểu nền Chủ đề**

Các màu nền của chủ đề được lưu trong [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện người dùng so với số lượng định nghĩa màu nền thực tế được lưu trong bộ sưu tập này vì UI có thể kết hợp màu nền chủ đề với màu chủ đề và các tham chiếu kiểu khác.

![Bộ sưu tập kiểu nền PowerPoint cho một chủ đề bản thuyết trình](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, kiểm tra bộ sưu tập đã lưu và [Background.getStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/background/) hiện tại. Chỉ số kiểu `0` có nghĩa là không có màu nền theo chủ đề; các giá trị dương là các tham chiếu kiểu nền chủ đề. Điều này khác với việc đánh chỉ mục trực tiếp vào bộ sưu tập Java, nơi `get_Item(0)` là mục đầu tiên được lưu. Đừng giả định rằng mọi bản thuyết trình đều chứa cùng số lượng kiểu nền.

Ví dụ sau báo cáo số lượng màu nền có sẵn, gán một tham chiếu nền chủ đề cho master đầu tiên, và lưu bản thuyết trình:

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

Kết quả hiển thị phụ thuộc vào mục nhập chủ đề mà master tham chiếu và bất kỳ ghi đè nền nào ở cấp layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không làm thay đổi slide đó. Sử dụng [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) khi bạn cần biết nền cuối cùng sau khi áp dụng kế thừa.

{{% alert color="warning" title="Warning" %}}
Đừng coi chỉ số kiểu như một chỉ số bộ sưu tập bắt đầu từ 0. Cũng tránh việc mã hoá cứng một số kiểu từ một tệp và cho rằng nó sẽ có cùng ngoại hình trong tệp khác; các định nghĩa kiểu chủ đề là riêng cho mỗi bản thuyết trình.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem [Presentation Background](/slides/vi/java/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Chủ đề**

Một sơ đồ định dạng chủ đề chứa các bộ sưu tập riêng biệt cho màu nền, đường và hiệu ứng được cung cấp qua [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) và [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/). Các chủ đề Office điển hình thường chứa ba mục kiểu chính tương ứng về mặt thị giác với định dạng nhẹ, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Hiệu ứng chủ đề nhẹ, trung bình và mạnh được áp dụng cho cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong Java, chỉ mục bộ sưu tập bắt đầu từ 0: `get_Item(0)` là kiểu đầu tiên được lưu và `get_Item(2)` là kiểu thứ ba. Các chỉ mục tham chiếu kiểu của hình dạng là một khái niệm riêng, được cung cấp qua [IShapeStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/). Thay đổi một kiểu chủ đề ảnh hưởng đến các hình dạng tham chiếu tới kiểu đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục kiểu cần thiết, thay đổi kiểu đường đầu tiên, thay đổi kiểu màu nền thứ ba, bật bóng đổ bên ngoài trong kiểu hiệu ứng thứ ba, và lưu kết quả:

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

Đối với các hình dạng tham chiếu tới các vị trí này, kiểu đường chủ đề đầu tiên trở thành đỏ, kiểu màu nền chủ đề thứ ba trở thành màu xanh rừng đặc, và kiểu hiệu ứng thứ ba có thêm bóng đổ bên ngoài với khoảng cách 10 điểm. Kết quả hình ảnh cuối cùng vẫn phụ thuộc vào mỗi hình dạng tham chiếu tới vị trí nào và liệu định dạng trực tiếp có ghi đè lên chủ đề hay không.

![Các kiểu hiệu ứng chủ đề sau khi thay đổi đường, màu nền và cài đặt bóng đổ](presentation-design_11.png)

## **Chọn Kiểu màu Nền và Đường cho Một Hình dạng**

Một hình dạng có thể chọn màu nền và viền một cách độc lập qua [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) và [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-). Đối với cả hai phương thức, chỉ số `1` chọn mục đầu tiên trong bộ sưu tập chủ đề tương ứng (`get_Item(0)`), và chỉ số `2` chọn mục thứ hai (`get_Item(1)`).

Ví dụ sau thiết lập hai kiểu màu nền (vàng và xanh da trời) và hai kiểu đường (xanh đậm 6 pt và đỏ đậm 12 pt) trong chủ đề mặc định của một bản thuyết trình mới. Nó lưu slide ở ba giai đoạn để bạn có thể so sánh kết quả trong PowerPoint.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(new Color(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(new Color(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(new Color(139, 0, 0));
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

    goldFill.getSolidFillColor().setColor(new Color(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Kiểu ban đầu | Thay đổi viền bên phải | Chỉnh sửa màu nền chủ đề đầu tiên |
|:---:|:---:|:---:|
| ![Hình chữ nhật vàng và xanh da trời với viền mỏng xanh đậm tương ứng](theme-style-initial.png) | ![Hình chữ nhật xanh da trời bây giờ có viền đỏ đậm dày](theme-style-line-changed.png) | ![Hình chữ nhật bên trái bây giờ màu xanh lá và cả hai viền không thay đổi](theme-style-fill-changed.png) |

Chọn một kiểu đường khác chỉ thay đổi viền của hình chữ nhật bên phải. Chỉnh sửa kiểu màu nền đầu tiên cập nhật mọi hình dạng sử dụng nó. Ở đây, chỉ hình chữ nhật bên trái chuyển sang màu xanh lá.

Trên một hình dạng đã tồn tại, màu nền cục bộ, màu đường hoặc độ dày đường có thể ghi đè phần đó của kiểu chủ đề. Nếu việc thay đổi chỉ số kiểu không có hiệu ứng nào thấy được, hãy kiểm tra [direct formatting](/slides/vi/java/shape-formatting/) của hình dạng.

## **Xác định Liệu Màu Nền Rắn Hiệu quả Có Sử dụng Màu Chủ đề Không**

Một màu nền có thể được lưu trực tiếp trên đối tượng hoặc kế thừa từ đoạn văn, layout, master, kiểu chủ đề hoặc một mức định dạng khác. Gọi [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/) để giải quyết chuỗi phân cấp này thành một đối tượng bất biến [IFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/). Đầu tiên kiểm tra [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/). Chỉ khi nó là `FillType.Solid` mới đọc các thuộc tính màu nền rắn.

Đối với màu nền rắn, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) trả về giá trị RGB cuối cùng sau khi kế thừa, tra cứu chủ đề và áp dụng biến đổi màu. [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) trả về vị trí logical [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) tương ứng, như `Text1` hoặc `Accent6`. Giá trị `SchemeColor.NotDefined` có nghĩa là màu nền rắn hiệu quả không dựa trên một màu lược đồ. Trong một quy trình làm việc nơi các màu nền chỉ là màu chủ đề hoặc màu RGB trực tiếp, giá trị này xác định một màu RGB trực tiếp.

Đừng chỉ dựa vào giá trị local [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) để phân loại một màu nền. Ví dụ, một đoạn văn bản có thể không có màu lược đồ được định nghĩa cục bộ, vì vậy giá trị local là `NotDefined`, trong khi màu nền hiệu quả kế thừa một màu chủ đề và giải quyết thành `Text1` hoặc `Accent6`. Ngược lại, `getSolidFillSchemeColor` cho bạn biết vị trí logical nào đã tạo ra màu hiệu quả, nhưng không cho biết vị trí đó đến từ đối tượng, đoạn văn, layout, master hay mức độ nào khác trong chuỗi định dạng.

Ví dụ sau tải một bản thuyết trình, kiểm tra cả màu nền của hình dạng và đoạn văn bản, in mỗi giá trị RGB cuối cùng và màu lược đồ liên quan, và đánh dấu các màu nền rắn sẽ không theo dõi các thay đổi màu chủ đề:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
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

Nhánh `NotDefined` cung cấp danh sách kiểm tra các màu nền rắn sẽ không phản hồi khi các vị trí màu chủ đề thay đổi. Xem xét các đối tượng này khi một bản thuyết trình phải tuân theo bảng màu thương hiệu mới. Giá trị RGB được báo vẫn hiển thị ngoại hình hiện tại, trong khi giá trị lược đồ giải thích liệu ngoại hình đó có liên kết với chủ đề hay không.

Các đối tượng định dạng hiệu quả là ảnh chụp nhanh. Sau khi thay đổi chủ đề bản thuyết trình, một ghi đè chủ đề, hoặc bất kỳ định dạng kế thừa nào, gọi lại `getEffective` và đọc một đối tượng `IFillFormatEffectiveData` mới trước khi so sánh hoặc báo cáo màu.

## **Đọc Các Giá trị Chủ đề Hiệu quả**

Các đối tượng chủ đề thô cho bạn biết những gì được định nghĩa ở một cấp độ cụ thể. Các giá trị hiệu quả cho bạn biết một slide hoặc hình dạng thực tế sử dụng gì sau khi kế thừa và ghi đè cục bộ đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/). Đối với nền, sử dụng [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/), và đối với màu nền, sử dụng [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/).

Ví dụ sau đọc chủ đề hiệu quả, nền và màu nền hình dạng đầu tiên từ một slide:

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

Sử dụng dữ liệu hiệu quả cho việc chẩn đoán render, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), bạn có thể bỏ lỡ một master, layout, slide hoặc ghi đè hình dạng làm thay đổi ngoại hình cuối cùng.

## **Câu hỏi Thường gặp**

**Áp dụng một chủ đề ngoài có ảnh hưởng đến mọi slide trong bản thuyết trình không?**

Không. [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) chỉ gán lại các slide phụ thuộc vào master đã chọn. Các slide sử dụng các master khác vẫn giữ nguyên chủ đề hiện có.

**Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/) của slide và khởi tạo ghi đè chủ đề của nó. Thay đổi sẽ chỉ tồn tại cục bộ cho slide đó; các slide khác vẫn kế thừa chủ đề hiện tại.

**Cách an toàn nhất để mang một chủ đề từ bản thuyết trình này sang bản thuyết trình khác là gì?**

Khi di chuyển một slide và giữ nguyên ngoại hình nguồn, sao chép master nguồn vào bản đích và sao chép slide với master đó bằng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) và [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/). Điều này giữ lại master, layout và chủ đề cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu quả sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) cho một slide hoặc layout và các phương thức dữ liệu hiệu quả tương ứng cho các đối tượng định dạng như [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) và [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/). Các API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.