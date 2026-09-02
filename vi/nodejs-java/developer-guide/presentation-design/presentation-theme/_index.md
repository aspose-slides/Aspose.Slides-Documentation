---
title: Quản lý Chủ đề Bản trình chiếu trong JavaScript
linktitle: Chủ đề Bản trình chiếu
type: docs
weight: 10
url: /vi/nodejs-java/presentation-theme/
keywords:
- chủ đề PowerPoint
- chủ đề bản trình chiếu
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
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các chủ đề bản trình chiếu trong JavaScript với Aspose.Slides cho Node.js để tạo, tùy chỉnh và chuyển đổi các tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một chủ đề bản trình chiếu định nghĩa một tập hợp phối hợp các màu, phông chữ, kiểu nền, kiểu tô, đường và hiệu ứng. Các đối tượng nhận thức chủ đề tham chiếu tới các định nghĩa chung này thay vì lưu trữ mỗi thuộc tính trực quan dưới dạng giá trị cố định, vì vậy việc thay đổi chủ đề có thể cập nhật nhiều đối tượng cùng một lúc.

Trong Aspose.Slides, chủ đề cấp bản trình chiếu có sẵn qua [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getmastertheme/). Một bản trình chiếu cũng có thể chứa các ghi đè chủ đề ở các cấp thấp hơn. Một master có thể ghi đè chủ đề bản trình chiếu qua [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterthememanager/), trong khi một layout hoặc một slide riêng lẻ có thể ghi đè chủ đề được kế thừa qua [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseoverridethememanager/). Thực tế, chủ đề hiệu lực cho một slide được xác định qua chuỗi kế thừa này: chủ đề bản trình chiếu, ghi đè master, ghi đè layout và ghi đè slide.

![Các thành phần của chủ đề: màu, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần dưới đây trình bày các quy trình làm việc với chủ đề phổ biến nhất: kiểm tra một chủ đề, thay đổi màu và phông chữ, sao chép hoặc áp dụng một chủ đề, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu lực sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra một Chủ đề**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mastertheme/) cung cấp sơ đồ màu, sơ đồ phông chữ và sơ đồ định dạng của chủ đề qua [MasterTheme.getColorScheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mastertheme/) và [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mastertheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi bản trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung của các mục kiểu có thể thay đổi.

Ví dụ sau đọc các thuộc tính chính của chủ đề và báo cáo số lượng kiểu nền, tô, đường và hiệu ứng được lưu trong chủ đề:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

Nếu một tệp sử dụng nhiều master, đừng giả định rằng mỗi slide đều có cùng một chủ đề hiệu lực. Kiểm tra master liên kết với slide, và sử dụng quy trình làm việc với chủ đề hiệu lực được mô tả sau trong bài viết khi có thể có ghi đè ở cấp layout hoặc slide.

## **Thay đổi Màu Chủ đề**

Các tô, đường và văn bản nhận thức chủ đề có thể tham chiếu tới một màu logic từ enum [SchemeColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [ColorScheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/colorscheme/), mọi đối tượng vẫn tham chiếu tới màu chủ đề đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu chủ đề.

Ví dụ toàn diện sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của chủ đề thành màu đỏ, lưu bản trình chiếu, mở lại và in màu tô hiệu lực:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Vì hình chữ nhật vẫn liên kết với `Accent4`, màu hiển thị của nó sẽ chuyển thành đỏ sau khi chủ đề được thay đổi. Nếu bạn thay thế màu scheme bằng màu trực tiếp trên hình dạng, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng tới tô đó.

### **Sử dụng Màu từ Bảng màu Bổ sung**

PowerPoint tạo ra các biến thể sáng hơn và tối hơn từ một màu chủ đề bằng cách áp dụng các phép biến đổi màu. Aspose.Slides cung cấp các phép biến đổi này qua enum [ColorTransformOperation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/colortransformoperation/).

![Các màu chủ đề chính và các màu sáng hơn, tối hơn được tạo từ bảng màu bổ sung](additional-palette-colors.png)

**1** - Các màu chủ đề chính.

**2** - Các biến thể sáng hơn và tối hơn được tạo từ các màu chủ đề chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng các phép biến đổi độ sáng cho năm trong số chúng, và lưu kết quả:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Các biến thể này vẫn dựa trên màu chủ đề. Nếu `Accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại dựa trên giá trị `Accent4` mới.

### **Ánh xạ Giá trị `SchemeColor` tới Các vị trí trong `ColorScheme`**

Enum [SchemeColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [ColorScheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/colorscheme/) cung cấp cùng các vị trí chủ đề dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Bảng ánh xạ là cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng các vị trí chủ đề; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng khác.

## **Thay đổi Phông chữ Chủ đề**

Một sơ đồ phông chữ chủ đề chứa một bộ phông chữ chính cho tiêu đề và một bộ phụ cho văn bản thân. Các phương thức [FontScheme.getMajor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontscheme/) và [FontScheme.getMinor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontscheme/) cung cấp các bộ này.

Các định danh phông chữ chủ đề tương thích PowerPoint có thể được sử dụng trong định dạng văn bản:

* `+mn-lt` - Phông chữ nội dung Latin (Phông chữ phụ Latin)
* `+mj-lt` - Phông chữ tiêu đề Latin (Phông chữ chính Latin)
* `+mn-ea` - Phông chữ nội dung Đông Á (Phông chữ phụ Đông Á)
* `+mj-ea` - Phông chữ tiêu đề Đông Á (Phông chữ chính Đông Á)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi phông chữ chủ đề và lưu kết quả:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tiêu đề tuân theo phông chữ chính và văn bản thân tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh chủ đề sẽ không tự động chuyển khi sơ đồ phông chữ chủ đề thay đổi.

Các bộ phông chữ chính và phụ cũng có thể chứa ánh xạ phông chữ cho các hệ thống viết riêng lẻ, chẳng hạn như Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc loại bỏ các ánh xạ này, xem phần [Script-Specific Theme Fonts](/slides/vi/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong bản trình chiếu, xem mục [PowerPoint Fonts](/slides/vi/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc Áp dụng một Chủ đề**

Các quy trình dưới đây giải quyết các vấn đề khác nhau liên quan đến chủ đề.

### **Áp dụng Chủ đề Bên ngoài cho Các Slide Phụ thuộc vào Master**

Sử dụng [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/) khi bạn có một tệp chủ đề PowerPoint (`.thmx`) và muốn thay đổi kiểu dáng của mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation.getMasters](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) được biểu diễn bởi [MasterSlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslidecollection/), và truyền đường dẫn tệp chủ đề vào phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một master slide mới dựa trên master đã chọn.
1. Áp dụng chủ đề bên ngoài cho master mới.
1. Gán master mới cho tất cả các slide trước đây phụ thuộc vào master đã chọn.
1. Trả về đối tượng [MasterSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/) mới tạo.

Ví dụ sau áp dụng chủ đề bên ngoài cho các slide phụ thuộc vào master đầu tiên và lưu bản trình chiếu:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Một chủ đề không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxReadException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxreadexception/). Hãy kiểm tra đường dẫn do người dùng cung cấp, xử lý các lỗi truy cập hệ thống tệp, và lưu bản trình chiếu chỉ sau khi chủ đề đã được áp dụng thành công.

Chỉ những slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với các master khác giữ nguyên master và chủ đề hiện tại. Các màu, phông chữ, tô, đường, nền và hiệu ứng nhận thức chủ đề sẽ được giải quyết dựa trên chủ đề bên ngoài. Các màu, phông chữ, tô và định dạng trực tiếp có thể vẫn không thay đổi. Các ghi đè ở mức layout và slide cũng có thể ưu tiên hơn các giá trị được kế thừa từ master mới.

Chủ đề có thể tham chiếu tới các phông chữ không có sẵn trong môi trường chạy. Để đảm bảo việc hiển thị và xuất khẩu nhất quán, hãy cài đặt các phông chữ cần thiết, cung cấp chúng qua [custom font sources](/slides/vi/nodejs-java/custom-font/), hoặc cấu hình [font substitution](/slides/vi/nodejs-java/font-substitution/).

Đây là quy trình làm việc trực tiếp ở cấp master: phương thức nhận đường dẫn tới tệp `.thmx` và không yêu cầu tạo thủ công các ghi đè chủ đề ở cấp slide hoặc layout.

### **Áp dụng Các Chủ đề Bên ngoài Khác nhau trong Bản Trình chiếu Nhiều Master**

Khi master liên quan không biết trước, lấy nó từ một slide đại diện thông qua [Slide.getLayoutSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/) và [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/). Lưu lại các tham chiếu master gốc trước khi áp dụng bất kỳ chủ đề nào vì mỗi lần gọi sẽ tạo thêm một master mới trong bản trình chiếu.

Ví dụ sau sử dụng các slide từ hai phần để xác định master của chúng và áp dụng một chủ đề bên ngoài khác nhau cho mỗi nhóm:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Lần gọi đầu tiên chỉ ảnh hưởng tới các slide phụ thuộc vào `firstGroupMaster`, và lần gọi thứ hai chỉ ảnh hưởng tới các slide phụ thuộc vào `secondGroupMaster`. Các slide thuộc bất kỳ master nào khác sẽ không được thay đổi kiểu.

### **Bảo tồn Chủ đề Nguồn khi Di chuyển Slide**

Nếu bạn muốn di chuyển một slide sang bản trình chiếu khác và giữ nguyên thiết kế gốc, sao chép master nguồn vào bản trình chiếu đích bằng [MasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslidecollection/), sau đó sao chép slide bằng [SlideCollection.addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/) và master đã sao chép. Điều này mang theo master, các layout và chủ đề liên quan cùng nhau.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Đây là quy trình ưu tiên khi slide nguồn phải trông giống hệt trong đích. Chỉ sao chép nội dung vào một master đích không liên quan có thể làm thay đổi màu, phông chữ, nền và hiệu ứng dựa trên chủ đề.

### **Áp dụng Giá trị Chủ đề cho Một Slide Đã Tồn tại**

Nếu slide đích phải ở lại master và layout hiện tại, khởi tạo một ghi đè cấp slide từ chủ đề nguồn. Các phương thức [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/overridetheme/) và [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/overridetheme/) sao chép ba thành phần chính của chủ đề vào ghi đè.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Điều này thay đổi chủ đề được slide đó sử dụng mà không thay đổi chủ đề được kế thừa bởi các slide khác. Để xoá ghi đè cục bộ và quay lại các giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/overridetheme/).

### **Áp dụng Ghi đè Chủ đề cho Một Layout**

Một ghi đè cấp layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng thông qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslidethememanager/):

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Sử dụng chủ đề ở cấp master hoặc bản trình chiếu khi nhiều layout và slide cần chia sẻ cùng một thiết kế cơ bản, sử dụng ghi đè layout khi một nhóm layout cần kiểu dáng khác nhau, và chỉ sử dụng ghi đè slide cho các ngoại lệ thực sự. Việc ghi đè quá nhiều ở cấp slide sẽ làm cho các thay đổi chủ đề toàn cục sau này khó dự đoán hơn.

## **Cập nhật Kiểu Nền Chủ đề**

Các kiểu nền của chủ đề được lưu trong [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/formatscheme/). PowerPoint có thể hiển thị nhiều tùy chọn nền hơn trong giao diện người dùng so với số lượng định nghĩa tô thực tế trong bộ sưu tập này vì UI có thể kết hợp các tô chủ đề với màu chủ đề và các tham chiếu kiểu khác.

![Bộ sưu tập kiểu nền PowerPoint cho một chủ đề bản trình chiếu](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, hãy kiểm tra bộ sưu tập đã lưu và giá trị hiện tại của [Background.getStyleIndex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/background/). Chỉ số kiểu `0` nghĩa là không có tô chủ đề; các giá trị dương là các tham chiếu kiểu nền chủ đề. Điều này khác với việc đánh chỉ số trực tiếp vào bộ sưu tập JavaScript, nơi chỉ số `0` là mục đầu tiên được lưu. Đừng giả định mỗi bản trình chiếu đều chứa cùng số lượng kiểu tô nền.

Ví dụ sau báo cáo số lượng tô nền khả dụng, gán một tham chiếu nền chủ đề cho master đầu tiên và lưu bản trình chiếu:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Kết quả hiển thị phụ thuộc vào mục chủ đề được master tham chiếu và bất kỳ ghi đè nền nào ở cấp layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không ảnh hưởng tới slide đó. Sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/background/) khi bạn cần biết nền cuối cùng sau khi đã áp dụng kế thừa.

{{% alert color="warning" title="Warning" %}}
Đừng coi chỉ số kiểu như một chỉ số bộ sưu tập bắt đầu từ 0. Cũng tránh mã cứng một số kiểu từ một tệp và cho rằng nó sẽ có cùng giao diện trong tệp khác; các định nghĩa kiểu chủ đề là riêng biệt cho mỗi bản trình chiếu.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem phần [Presentation Background](/slides/vi/nodejs-java/presentation-background/).
{{% /alert %}}

## **Cập nhật Hiệu ứng Chủ đề**

Một sơ đồ định dạng chủ đề chứa các bộ sưu tập riêng cho tô, đường và hiệu ứng được mở ra qua [FormatScheme.getFillStyles](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/formatscheme/), và [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/formatscheme/). Các chủ đề Office điển hình thường chứa ba mục kiểu chính tương ứng với định dạng nhẹ, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định số lượng cố định.

![Hiệu ứng chủ đề nhẹ, trung bình và mạnh được áp dụng cho cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong JavaScript, chỉ số bộ sưu tập bắt đầu từ 0: chỉ số `0` là kiểu đầu tiên được lưu và chỉ số `2` là kiểu thứ ba. Các chỉ số tham chiếu kiểu của hình dạng là một khái niệm riêng, được mở ra qua [ShapeStyle](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapestyle/). Việc sửa đổi một kiểu chủ đề sẽ ảnh hưởng tới các hình dạng tham chiếu kiểu đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra sự tồn tại của các mục kiểu cần thiết, thay đổi kiểu đường đầu tiên, thay đổi kiểu tô thứ ba, bật bóng đổ ngoài cho kiểu hiệu ứng thứ ba, và lưu kết quả:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với các hình dạng tham chiếu các vị trí này, kiểu đường chủ đề đầu tiên sẽ trở thành màu đỏ, kiểu tô chủ đề thứ ba sẽ trở thành màu xanh rừng đặc, và kiểu hiệu ứng thứ ba sẽ có bóng đổ ngoài với khoảng cách 10 điểm. Kết quả hình ảnh cuối cùng vẫn phụ thuộc vào việc mỗi hình dạng tham chiếu vị trí nào và liệu định dạng trực tiếp có ghi đè lên chủ đề hay không.

![Các kiểu hiệu ứng chủ đề sau khi thay đổi đường, tô và cài đặt bóng đổ](presentation-design_11.png)

## **Đọc Các Giá trị Chủ đề Hiệu lực**

Các đối tượng chủ đề nguyên bản chỉ cho bạn biết gì được định nghĩa ở một cấp độ nào đó. Các giá trị hiệu lực cho bạn biết slide hoặc hình dạng thực tế sử dụng gì sau khi kế thừa và các ghi đè địa phương đã được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseoverridethememanager/). Đối với nền, sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/background/), và đối với tô, sử dụng [FillFormat.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/).

Ví dụ sau đọc chủ đề hiệu lực, nền và tô của hình dạng đầu tiên từ một slide:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Sử dụng dữ liệu hiệu lực cho việc chẩn đoán hiển thị, kiểm tra và so sánh. Nếu bạn chỉ kiểm tra [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getmastertheme/), bạn có thể bỏ lỡ một ghi đè ở cấp master, layout, slide hoặc shape thay đổi diện mạo cuối cùng.

## **Câu hỏi thường gặp**

**Áp dụng một chủ đề bên ngoài có ảnh hưởng tới mọi slide trong bản trình chiếu không?**

Không. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/) chỉ gán lại các slide phụ thuộc vào master đã chọn. Các slide sử dụng các master khác vẫn giữ nguyên chủ đề hiện tại.

**Tôi có thể áp dụng một chủ đề cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidethememanager/) của slide và khởi tạo ghi đè chủ đề của nó. Thay đổi sẽ chỉ áp dụng cho slide đó; các slide khác vẫn kế thừa chủ đề hiện tại.

**Cách an toàn nhất để chuyển một chủ đề từ bản trình chiếu này sang bản trình chiếu khác là gì?**

Khi di chuyển một slide và muốn giữ nguyên diện mạo nguồn, sao chép master nguồn vào bản đích và sao chép slide với master đó bằng [MasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslidecollection/) và [SlideCollection.addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/). Điều này giữ nguyên master, các layout và chủ đề cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu lực sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseoverridethememanager/) cho một slide hoặc layout và các phương thức dữ liệu hiệu lực tương ứng cho các đối tượng định dạng như [Background.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/background/) và [FillFormat.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/). Những API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.