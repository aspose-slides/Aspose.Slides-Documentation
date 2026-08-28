---
title: Quản lý giao diện bản trình chiếu trong JavaScript
linktitle: Giao diện bản trình chiếu
type: docs
weight: 10
url: /vi/nodejs-java/presentation-theme/
keywords:
- giao diện PowerPoint
- giao diện bản trình chiếu
- giao diện slide
- đặt giao diện
- thay đổi giao diện
- quản lý giao diện
- giao diện bên ngoài
- THMX
- màu giao diện
- bảng màu bổ sung
- phông giao diện
- phong cách giao diện
- hiệu ứng giao diện
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý giao diện bản trình chiếu trong JavaScript với Aspose.Slides cho Node.js để tạo, tùy chỉnh và chuyển đổi các tệp PowerPoint với thương hiệu nhất quán."
---
## **Giới thiệu**

Một giao diện bản trình chiếu xác định một bộ phối hợp các màu sắc, phông chữ, kiểu nền, màu nền, đường kẻ và hiệu ứng. Các đối tượng nhận thức giao diện tham chiếu tới các định nghĩa chung này thay vì lưu trữ mỗi thuộc tính trực quan dưới dạng giá trị cố định, vì vậy việc thay đổi giao diện có thể cập nhật nhiều đối tượng cùng một lúc.

Trong Aspose.Slides, giao diện ở mức bản trình chiếu có sẵn qua [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getmastertheme/). Bản trình chiếu cũng có thể chứa các ghi đè giao diện ở các cấp thấp hơn. Một master có thể ghi đè giao diện của bản trình chiếu qua [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterthememanager/), trong khi một layout hoặc một slide riêng lẻ có thể ghi đè giao diện được kế thừa của nó qua [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseoverridethememanager/). Thực tế, giao diện hiệu quả cho một slide được giải quyết qua chuỗi kế thừa này: giao diện bản trình chiếu, ghi đè master, ghi đè layout và ghi đè slide.

![Thành phần giao diện: màu sắc, phông chữ, kiểu nền và hiệu ứng](theme-constituents.png)

Các phần dưới đây giới thiệu các quy trình làm việc với giao diện phổ biến nhất: kiểm tra giao diện, thay đổi màu sắc và phông chữ, sao chép hoặc áp dụng giao diện, cập nhật kiểu nền và hiệu ứng, và đọc các giá trị hiệu quả sau khi kế thừa và ghi đè đã được giải quyết.

## **Kiểm tra giao diện**

Đối tượng [MasterTheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mastertheme/) cung cấp lược đồ màu, lược đồ phông và lược đồ định dạng của giao diện thông qua [MasterTheme.getColorScheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mastertheme/) và [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/mastertheme/). Kiểm tra các bộ sưu tập này trước khi thay đổi chúng đặc biệt hữu ích khi một bản trình chiếu đến từ nguồn bên ngoài vì số lượng và nội dung của các mục style có thể khác nhau.

Ví dụ sau đọc các thuộc tính chính của giao diện và báo cáo có bao nhiêu style nền, màu nền, đường kẻ và hiệu ứng được lưu trong giao diện:

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

Nếu một tệp sử dụng nhiều master, đừng giả định rằng mọi slide đều có cùng một giao diện hiệu quả. Kiểm tra master liên kết với slide, và sử dụng quy trình làm việc giao diện‑hiệu quả được mô tả sau trong bài viết khi có khả năng tồn tại ghi đè layout hoặc slide.

## **Thay đổi màu giao diện**

Các màu nền, đường kẻ và văn bản nhận thức giao diện có thể tham chiếu tới một màu logic từ enumeration [SchemeColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/schemecolor/). Khi bạn thay đổi mục tương ứng trong [ColorScheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/colorscheme/), mọi đối tượng vẫn tham chiếu tới màu giao diện đó sẽ được giải quyết dựa trên giá trị mới. Các đối tượng sử dụng màu RGB trực tiếp sẽ không bị thay đổi bởi cập nhật màu giao diện.

Ví dụ toàn diện sau tạo một hình dạng sử dụng `Accent4`, thay đổi màu `Accent4` của giao diện thành màu đỏ, lưu bản trình chiếu, mở lại và in màu nền hiệu quả:

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

Vì hình chữ nhật vẫn liên kết với `Accent4`, màu hiển thị của nó sẽ trở thành màu đỏ sau khi giao diện được thay đổi. Nếu bạn thay thế màu scheme bằng màu trực tiếp trên hình, các thay đổi sau này đối với `Accent4` sẽ không còn ảnh hưởng tới nền đó.

### **Sử dụng màu từ Bảng màu bổ sung**

PowerPoint tạo ra các biến thể sáng hơn và tối hơn từ một màu giao diện bằng cách áp dụng các biến đổi màu. Aspose.Slides cung cấp các biến đổi này thông qua enumeration [ColorTransformOperation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/colortransformoperation/).

![Màu giao diện chính và các màu sáng hơn, tối hơn được tạo từ bảng màu bổ sung](additional-palette-colors.png)

**1** - Màu giao diện chính.

**2** - Các biến thể sáng hơn và tối hơn được tạo từ màu giao diện chính.

Ví dụ sau tạo sáu hình chữ nhật dựa trên `Accent4`, áp dụng biến đổi độ sáng cho năm hình trong số chúng, và lưu kết quả:

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

Các biến thể này vẫn dựa trên màu giao diện. Nếu `Accent4` thay đổi sau này, các màu đã biến đổi sẽ được tính lại từ giá trị `Accent4` mới.

### **Ánh xạ giá trị `SchemeColor` sang các vị trí trong `ColorScheme`**

Enumeration [SchemeColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/schemecolor/) sử dụng `Text1`, `Background1`, `Text2` và `Background2`, trong khi [ColorScheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/colorscheme/) cung cấp các vị trí giao diện tương đương dưới dạng `Dark1`, `Light1`, `Dark2` và `Light2`. Ánh xạ này cố định:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Đây là các tên thay thế cho cùng một vị trí giao diện; chúng không phải là các giá trị được chuyển đổi động từ dạng này sang dạng kia.

## **Thay đổi phông chữ giao diện**

Một lược đồ phông chữ giao diện chứa một bộ phông chữ chính cho tiêu đề và một bộ phụ cho nội dung. Các phương thức [FontScheme.getMajor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontscheme/) và [FontScheme.getMinor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontscheme/) cung cấp các bộ này.

Các định danh phông chữ giao diện tương thích PowerPoint có thể được dùng trong định dạng văn bản:

* `+mn-lt` - Phông chữ nội dung Latin (Minor Latin Font)
* `+mj-lt` - Phông chữ tiêu đề Latin (Major Latin Font)
* `+mn-ea` - Phông chữ nội dung Đông Á (Minor East Asian Font)
* `+mj-ea` - Phông chữ tiêu đề Đông Á (Major East Asian Font)

Ví dụ sau tạo một tiêu đề sử dụng phông chữ Latin chính và một dòng nội dung sử dụng phông chữ Latin phụ. Sau đó thay đổi các phông chữ giao diện và lưu kết quả:

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

Tiêu đề tuân theo phông chữ chính và nội dung tuân theo phông chữ phụ. Văn bản có tên phông chữ cụ thể thay vì định danh giao diện sẽ không tự động chuyển khi lược đồ phông chữ giao diện thay đổi.

Các bộ phông chính và phụ cũng có thể chứa các ánh xạ phông cho các hệ thống viết riêng lẻ, chẳng hạn Cyrillic, Arabic, Japanese, Georgian và Thaana. Để kiểm tra, thêm, thay thế hoặc loại bỏ các ánh xạ này, xem mục [Script-Specific Theme Fonts](/slides/vi/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Để biết thêm thông tin về phông chữ trong bản trình chiếu, xem [PowerPoint Fonts](/slides/vi/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **Sao chép hoặc áp dụng một giao diện**

Các quy trình dưới đây giải quyết các vấn đề khác nhau liên quan đến giao diện.

### **Áp dụng giao diện bên ngoài cho các slide phụ thuộc vào một Master**

Sử dụng [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/) khi bạn có một tệp giao diện PowerPoint (`.thmx`) và muốn thay đổi kiểu dáng của mọi slide phụ thuộc vào một master cụ thể. Chọn master từ bộ sưu tập [Presentation.getMasters](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) được biểu diễn bởi [MasterSlideCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslidecollection/), và truyền đường dẫn tệp giao diện vào phương thức.

Phương thức thực hiện các thao tác sau:

1. Tạo một master slide mới dựa trên master đã chọn.
1. Áp dụng giao diện bên ngoài cho master mới.
1. Gán master mới cho tất cả các slide trước đây phụ thuộc vào master đã chọn.
1. Trả về đối tượng [MasterSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/) vừa tạo.

Ví dụ sau áp dụng giao diện bên ngoài cho các slide phụ thuộc vào master thứ nhất và lưu bản trình chiếu:

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

Một giao diện không hợp lệ, bị hỏng hoặc không được hỗ trợ có thể gây ra [PptxReadException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxreadexception/). Hãy xác thực các đường dẫn do người dùng cung cấp, xử lý các lỗi truy cập hệ thống tệp, và chỉ lưu bản trình chiếu sau khi giao diện đã được áp dụng thành công.

Chỉ những slide phụ thuộc vào master đã chọn mới được gán lại. Các slide liên kết với các master khác giữ nguyên master và giao diện hiện tại. Các màu, phông chữ, màu nền, đường kẻ và hiệu ứng nhận thức giao diện sẽ được giải quyết dựa trên giao diện bên ngoài. Các màu, phông chữ, màu nền và các định dạng rõ ràng khác có thể vẫn không thay đổi. Các ghi đè ở mức layout và slide cũng có thể ưu tiên hơn các giá trị được kế thừa từ master mới.

Giao diện có thể tham chiếu tới các phông chữ không có sẵn trong môi trường chạy. Để đảm bảo việc hiển thị và xuất ra nhất quán, hãy cài đặt các phông chữ cần thiết, cung cấp chúng qua [nguồn phông tùy chỉnh](/slides/vi/nodejs-java/custom-font/), hoặc cấu hình [thay thế phông](/slides/vi/nodejs-java/font-substitution/).

Đây là một quy trình làm việc trực tiếp ở mức master: phương thức nhận đường dẫn tệp `.thmx` và không yêu cầu tạo thủ công các ghi đè giao diện ở mức slide hay layout.

### **Áp dụng các giao diện bên ngoài khác nhau trong một bản trình chiếu đa‑master**

Khi master liên quan chưa được biết trước, hãy lấy nó từ một slide tiêu biểu thông qua [Slide.getLayoutSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/) và [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslide/). Lưu trữ các tham chiếu master gốc trước khi áp dụng bất kỳ giao diện nào vì mỗi lần gọi sẽ tạo một master mới trong bản trình chiếu.

Ví dụ sau sử dụng các slide từ hai phần để xác định master của chúng và áp dụng một giao diện bên ngoài khác nhau cho mỗi nhóm:

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

Lệnh gọi đầu tiên chỉ ảnh hưởng đến các slide phụ thuộc vào `firstGroupMaster`, và lệnh gọi thứ hai chỉ ảnh hưởng đến các slide phụ thuộc vào `secondGroupMaster`. Các slide thuộc bất kỳ master nào khác sẽ không bị thay đổi kiểu dáng.

### **Bảo tồn giao diện nguồn khi di chuyển slide**

Nếu bạn muốn di chuyển một slide sang bản trình chiếu khác và giữ nguyên thiết kế gốc, hãy sao chép master nguồn vào bản trình chiếu đích bằng [MasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslidecollection/), sau đó sao chép slide bằng [SlideCollection.addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/) và master đã sao chép. Điều này sẽ mang theo master, các layout và giao diện liên quan cùng nhau.

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

Đây là quy trình ưu tiên khi slide nguồn phải hiển thị giống hệt trong đích. Chỉ sao chép nội dung lên một master đích không liên quan có thể làm thay đổi các màu, phông chữ, nền và hiệu ứng dựa trên giao diện.

### **Áp dụng các giá trị giao diện cho một slide hiện có**

Nếu slide đích phải ở lại master và layout hiện tại, hãy khởi tạo một ghi đè mức slide từ giao diện nguồn. Các phương thức [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/overridetheme/), và [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/overridetheme/) sao chép ba thành phần chính của giao diện vào ghi đè.

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

Điều này thay đổi giao diện được slide sử dụng mà không thay đổi giao diện được kế thừa bởi các slide khác. Để xóa bỏ ghi đè cục bộ và quay lại giá trị kế thừa, gọi [OverrideTheme.clear](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/overridetheme/).

### **Áp dụng ghi đè giao diện cho một layout**

Ghi đè mức layout áp dụng cho các slide sử dụng layout đó, trừ khi một slide cụ thể có ghi đè riêng. Các phương thức khởi tạo tương tự có thể được sử dụng thông qua [LayoutSlideThemeManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/layoutslidethememanager/):

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

Sử dụng giao diện ở mức master hoặc bản trình chiếu khi nhiều layout và slide cần chia sẻ cùng một thiết kế cơ bản, sử dụng ghi đè layout khi một nhóm layout cần kiểu dáng khác, và chỉ dùng ghi đè slide cho các ngoại lệ thực sự. Quá nhiều ghi đè mức slide sẽ làm cho các thay đổi giao diện toàn cục sau này khó dự đoán.

## **Cập nhật kiểu nền giao diện**

Các màu nền của giao diện được lưu trong [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/formatscheme/). PowerPoint có thể hiển thị nhiều lựa chọn nền hơn trong giao diện người dùng so với số định nghĩa màu nền thực tế trong bộ sưu tập này vì giao diện người dùng có thể kết hợp màu nền giao diện với màu giao diện và các tham chiếu style khác.

![Bộ sưu tập kiểu nền PowerPoint cho một giao diện bản trình chiếu](presentation-design_8.png)

Trước khi sử dụng một kiểu nền, hãy kiểm tra bộ sưu tập đã lưu và [Background.getStyleIndex](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/background/) hiện tại. Chỉ số kiểu `0` có nghĩa là không có màu nền giao diện; các giá trị dương là các tham chiếu kiểu nền giao diện. Điều này khác với việc đánh chỉ số trực tiếp trong bộ sưu tập JavaScript, nơi chỉ số `0` là mục đầu tiên được lưu. Đừng giả định rằng mọi bản trình chiếu đều có cùng số lượng kiểu nền.

Ví dụ sau báo cáo số lượng màu nền khả dụng, gán một tham chiếu nền giao diện cho master đầu tiên, và lưu bản trình chiếu:

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

Kết quả hiển thị phụ thuộc vào mục giao diện mà master tham chiếu và bất kỳ ghi đè nền nào ở mức layout hoặc slide. Nếu một slide sử dụng nền riêng, việc chỉ thay đổi nền master có thể không ảnh hưởng đến slide đó. Sử dụng [Background.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/background/) khi bạn cần biết nền cuối cùng sau khi kế thừa đã được áp dụng.

{{% alert color="warning" title="Warning" %}}
Đừng xem chỉ số kiểu như một chỉ số bộ sưu tập dựa trên zero. Cũng tránh mã hóa cứng một số kiểu từ một tệp và cho rằng nó sẽ có cùng giao diện trong tệp khác; các định nghĩa kiểu giao diện là đặc thù cho từng bản trình chiếu.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Đối với định dạng nền trực tiếp và kế thừa nền, xem mục [Presentation Background](/slides/vi/nodejs-java/presentation-background/).
{{% /alert %}}

## **Cập nhật hiệu ứng giao diện**

Một lược đồ định dạng giao diện chứa các bộ sưu tập riêng biệt cho màu nền, đường kẻ và hiệu ứng được mở ra qua [FormatScheme.getFillStyles](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/formatscheme/), và [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/formatscheme/). Các giao diện Office điển hình thường có ba mục style chính tương ứng với định dạng nhẹ, trung bình và mạnh, nhưng mã nên kiểm tra từng bộ sưu tập thay vì giả định một số lượng cố định.

![Hiệu ứng giao diện nhẹ, trung bình và mạnh được áp dụng cho cùng một hình dạng](presentation-design_10.png)

Khi truy cập các bộ sưu tập này trong JavaScript, chỉ số bộ sưu tập là dựa trên zero: chỉ số `0` là style đầu tiên được lưu và chỉ số `2` là style thứ ba. Các chỉ số tham chiếu style của hình dạng là một khái niệm riêng, được mở ra qua [ShapeStyle](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapestyle/). Việc sửa đổi một style giao diện sẽ ảnh hưởng đến các hình dạng tham chiếu tới style đó; các hình dạng có định dạng trực tiếp có thể không thay đổi.

Ví dụ sau kiểm tra các mục style cần thiết tồn tại, thay đổi style đường kẻ đầu tiên, thay đổi style màu nền thứ ba, bật bóng ngoài cho style hiệu ứng thứ ba, và lưu kết quả:

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

Đối với các hình dạng tham chiếu các vị trí này, style đường kẻ giao diện đầu tiên sẽ trở thành màu đỏ, style màu nền thứ ba sẽ thành màu xanh rừng đặc, và style hiệu ứng thứ ba sẽ có bóng ngoài với khoảng cách 10 điểm. Kết quả hình ảnh chính xác vẫn phụ thuộc vào mỗi hình dạng tham chiếu vị trí style nào và liệu định dạng trực tiếp có ghi đè giao diện hay không.

![Các style hiệu ứng giao diện sau khi thay đổi đường kẻ, màu nền và cài đặt bóng](presentation-design_11.png)

## **Xác định liệu một màu nền rắn hiệu quả có sử dụng màu giao diện hay không**

Một màu nền có thể được lưu trực tiếp trên một đối tượng hoặc được kế thừa từ đoạn văn, layout, master, style giao diện, hoặc mức định dạng khác. Gọi [FillFormat.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/) để giải quyết cây phân cấp này thành một ảnh chụp màu nền rắn bất biến. Đầu tiên kiểm tra giá trị `getFillType`. Chỉ khi nó là `FillType.Solid` mới nên đọc các thuộc tính màu nền rắn.

Đối với màu nền rắn, `getSolidFillColor` trả về giá trị RGB cuối cùng sau khi kế thừa, tra cứu giao diện và áp dụng các biến đổi màu. Phương thức `getSolidFillSchemeColor` trả về vị trí logic [SchemeColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/schemecolor/) tương ứng, chẳng hạn `Text1` hoặc `Accent6`. Giá trị `SchemeColor.NotDefined` có nghĩa là màu nền rắn hiệu quả không dựa trên một màu scheme. Trong một quy trình làm việc nơi các màu nền chỉ là màu giao diện hoặc màu RGB trực tiếp, giá trị này xác định một màu nền RGB trực tiếp.

Đừng chỉ sử dụng giá trị địa phương [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/colorformat/) để phân loại một màu nền. Ví dụ, một đoạn văn bản có thể không có màu scheme được định nghĩa cục bộ, vì vậy giá trị cục bộ là `NotDefined`, trong khi màu nền hiệu quả của nó kế thừa một màu giao diện và giải quyết thành `Text1` hoặc `Accent6`. Ngược lại, `getSolidFillSchemeColor` cho bạn biết vị trí logic giao diện đã tạo ra màu hiệu quả, nhưng không cho biết vị trí đó đến từ đối tượng, đoạn văn, layout, master hay mức nào khác của cây định dạng.

Ví dụ sau tải một bản trình chiếu, kiểm tra cả màu nền của hình dạng và đoạn văn bản, in mỗi giá trị RGB cuối cùng và màu scheme liên quan, và đánh dấu các màu nền rắn sẽ không theo dõi các thay đổi màu giao diện:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Nhánh `NotDefined` cung cấp danh sách kiểm tra các màu nền rắn sẽ không phản hồi với các thay đổi trong các vị trí màu giao diện. Xem lại các đối tượng này khi bản trình chiếu phải tuân theo một bảng màu thương hiệu mới. Giá trị RGB được báo cáo vẫn hiển thị ngoại hình hiện tại, trong khi giá trị scheme giải thích liệu ngoại hình đó có liên kết với giao diện hay không.

Các đối tượng định dạng hiệu quả là các ảnh chụp. Sau khi thay đổi giao diện bản trình chiếu, một ghi đè giao diện, hoặc bất kỳ định dạng kế thừa nào, hãy gọi lại `getEffective` và đọc một đối tượng màu nền rắn mới trước khi so sánh hoặc báo cáo màu.

## **Đọc các giá trị giao diện hiệu quả**

Các đối tượng giao diện thô cho bạn biết những gì được định nghĩa ở một mức cụ thể. Các giá trị hiệu quả cho bạn biết slide hoặc hình dạng thực sự sử dụng gì sau khi kế thừa và ghi đè cục bộ được giải quyết. Đối với một slide, gọi [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseoverridethememanager/). Đối với nền, dùng [Background.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/background/), và đối với màu nền, dùng [FillFormat.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/).

Ví dụ sau đọc giao diện hiệu quả, nền và màu nền hình dạng đầu tiên từ một slide:

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

Sử dụng dữ liệu hiệu quả để chuẩn đoán hiển thị, xác thực và so sánh. Nếu bạn chỉ kiểm tra [Presentation.getMasterTheme](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getmastertheme/), bạn có thể bỏ qua một master, layout, slide hoặc ghi đè hình dạng thay đổi ngoại hình cuối cùng.

## **Câu hỏi thường gặp**

**Áp dụng một giao diện bên ngoài có ảnh hưởng tới mọi slide trong bản trình chiếu không?**

Không. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/) chỉ gán lại các slide phụ thuộc vào master đã chọn. Các slide sử dụng các master khác giữ nguyên giao diện hiện tại.

**Tôi có thể áp dụng một giao diện cho một slide duy nhất mà không thay đổi master không?**

Có. Sử dụng [SlideThemeManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidethememanager/) của slide và khởi tạo ghi đè giao diện của nó. Thay đổi sẽ chỉ áp dụng cho slide đó; các slide khác vẫn kế thừa giao diện hiện tại.

**Cách an toàn nhất để chuyển giao diện từ bản trình chiếu này sang bản trình chiếu khác là gì?**

Khi di chuyển một slide và giữ nguyên ngoại hình nguồn, sao chép master nguồn vào bản đích và sao chép slide cùng master đó bằng [MasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslidecollection/) và [SlideCollection.addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidecollection/). Điều này giữ nguyên master, các layout và giao diện cùng nhau.

**Làm sao tôi có thể xem các giá trị hiệu quả sau khi kế thừa và ghi đè?**

Sử dụng [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseoverridethememanager/) cho một slide hoặc layout và các phương thức dữ liệu‑hiệu quả tương ứng cho các đối tượng định dạng như [Background.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/background/) và [FillFormat.getEffective](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/). Các API này trả về các giá trị đã được giải quyết sau khi áp dụng kế thừa và ghi đè.