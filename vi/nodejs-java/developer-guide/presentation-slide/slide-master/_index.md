---
title: Quản lý Bố cục Slide trong JavaScript
linktitle: Bố cục Slide
type: docs
weight: 70
url: /vi/nodejs-java/slide-master/
keywords:
- bố cục slide
- slide mẫu
- slide mẫu PPT
- nhiều slide mẫu
- so sánh slide mẫu
- nền
- trình giữ chỗ
- sao chép slide mẫu
- chép slide mẫu
- nhân bản slide mẫu
- slide mẫu không dùng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các bố cục slide trong Aspose.Slides cho Node.js qua Java: truy cập, chỉnh sửa, sao chép, so sánh và xóa các slide mẫu trong bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Một **bố cục slide** xác định các thiết lập thiết kế chung cho một nhóm các slide. Nó có thể chứa các hình dạng chung, logo, nền, kiểu chữ, thiết lập chủ đề và thiết lập chân trang. Trong PowerPoint, việc chỉnh sửa một bố cục slide là cách thường dùng để duy trì tính nhất quán của bản trình chiếu mà không phải lặp lại cùng một định dạng trên mỗi slide.

Aspose.Slides for Node.js via Java hỗ trợ cùng mô hình này. Một bản trình chiếu có thể chứa một hoặc nhiều bố cục slide, và mỗi bố cục slide có thể chứa một số slide bố cục. Các slide bình thường thường không tham chiếu trực tiếp tới một bố cục slide. Thay vào đó, một slide bình thường sử dụng một slide bố cục, và slide bố cục đó thuộc về một bố cục slide.

Cấu trúc phân cấp là:

1. **Bố cục slide** – xác định thiết kế và chủ đề chung.
1. **Slide bố cục** – xác định cách sắp xếp cụ thể của các placeholder và định dạng mức bố cục.
1. **Slide bình thường** – chứa nội dung thực tế của bản trình chiếu và sử dụng một slide bố cục.

![Cấu trúc phân cấp của bố cục slide, slide bố cục và slide bình thường](slide-master_2.jpg)

Trong Aspose.Slides, một bố cục slide được biểu diễn bởi lớp [MasterSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/). Tất cả các bố cục slide trong một bản trình chiếu có thể truy cập qua bộ sưu tập `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Khi cùng một thuộc tính được định nghĩa ở nhiều mức, mức cụ thể hơn sẽ thắng. Ví dụ, nếu một bố cục slide và một slide bố cục đều định nghĩa nền, các slide dựa trên bố cục đó sẽ sử dụng nền của slide bố cục. Để biết thêm thông tin về slide bố cục, xem [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Truy cập Bố cục Slide**

Trong PowerPoint, bạn có thể mở chế độ xem Bố cục Slide từ **View** > **Slide Master**.

![Lệnh Slide Master trên thẻ View của PowerPoint](slide-master_3.jpg)

Trong Aspose.Slides, sử dụng bộ sưu tập `getMasters()` để truy cập các bố cục slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể lấy bố cục slide được sử dụng bởi một slide bình thường thông qua bố cục của nó:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Nội dung của một Bố cục Slide**

Một bố cục slide là một đối tượng giống slide. Nó kế thừa hành vi chung của slide từ [BaseSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/), do đó nó cung cấp nhiều thuộc tính slide giống như các slide bình thường và slide bố cục. Các thành viên đặc thù của bố cục slide được liệt kê trên trang API [MasterSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/).

Các thành viên bố cục slide thường dùng bao gồm:

| Thành viên | Mô tả |
| --- | --- |
| `getBackground()` | Đặt nền slide ở mức bố cục slide. |
| `getShapes()` | Lưu trữ các hình dạng được đặt trên bố cục, chẳng hạn logo, khung ảnh và văn bản chung. |
| `getLayoutSlides()` | Lưu trữ các slide bố cục thuộc về bố cục này. |
| `getThemeManager()` | Cung cấp quyền truy cập vào các API chủ đề của bố cục. |
| `getHeaderFooterManager()` | Điều khiển tiêu đề, chân trang, ngày tháng và số slide cho bố cục và các bố cục con của nó. |
| `getDependingSlides()` | Trả về các slide bình thường phụ thuộc vào bố cục thông qua các bố cục của chúng. |

## **Thêm Hình Ảnh vào Bố Cục Slide**

Khi bạn thêm một hình ảnh vào bố cục slide, nó sẽ xuất hiện trên các slide sử dụng bố cục từ bố cục đó. Điều này hữu ích cho logo, watermark, dải trang trí và các yếu tố hình ảnh lặp lại khác.

Ví dụ sau thêm một logo vào bố cục slide đầu tiên:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để biết thêm thông tin về khung ảnh, xem [Picture Frame](/nodejs-java/picture-frame/).

## **Làm việc với Placeholder**

Placeholder thường được định nghĩa trên các slide bố cục. Bố cục slide cung cấp kiểu dáng và chủ đề chung mà các bố cục này kế thừa, trong khi mỗi bố cục quyết định placeholder nào khả dụng và chúng được đặt ở đâu.

Trong PowerPoint, các lệnh placeholder có sẵn trong chế độ xem Bố cục Slide.

![Lệnh Insert Placeholder trong chế độ xem Bố cục Slide của PowerPoint](slide-master_5.png)

Để thêm placeholder mới với Aspose.Slides, làm việc với slide bố cục thuộc về bố cục:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể định dạng các hình dạng placeholder đã tồn tại trên bố cục slide. Ví dụ sau tìm placeholder tiêu đề và áp dụng gradient màu tuyến tính:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Placeholder tiêu đề đã định dạng kế thừa bởi các slide bình thường](slide-master_8.png)

Để biết thêm các tùy chọn định dạng placeholder và văn bản, xem [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) và [Text Formatting](/nodejs-java/text-formatting/).

## **Thay Đổi Nền Bố Cục Slide**

Nền của bố cục được kế thừa bởi các bố cục và slide không ghi đè nó. Ví dụ sau thiết lập màu nền đồng nhất cho bố cục slide đầu tiên:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để biết các chủ đề liên quan, xem [Presentation Background](/nodejs-java/presentation-background/) và [Presentation Theme](/nodejs-java/presentation-theme/).

## **Sao Chép Bố Cục Slide sang Bản Trình Chiếu Khác**

Sử dụng `MasterSlideCollection.addClone` để sao chép một bố cục slide vào bản trình chiếu khác. Bố cục đã sao chép sau đó có thể được các bố cục và slide trong bản đích sử dụng.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Nếu bạn cần sao chép các slide bình thường cùng với bố cục của chúng, xem [Clone Slides](/nodejs-java/clone-slides/).

## **Thêm Nhiều Bố Cục Slide**

Một bản trình chiếu có thể chứa nhiều bố cục slide. Điều này hữu ích khi các phần khác nhau cần thương hiệu, cấu trúc trang hoặc thiết lập chủ đề riêng.

![Các lệnh PowerPoint để chèn và quản lý bố cục slide](slide-master_9.jpg)

Ví dụ sau sao chép bố cục mặc định, đặt nền khác cho bản sao, tạo một bố cục dưới bố cục đã sao chép và thêm một slide mới dựa trên bố cục đó:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **So Sánh Bố Cục Slide**

Bố cục slide có thể được so sánh bằng phương thức `equals` được kế thừa từ [BaseSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/). Việc so sánh kiểm tra cấu trúc và nội dung tĩnh, chẳng hạn hình dạng, văn bản, định dạng, hoạt ảnh và các thiết lập slide khác. Nó không so sánh các định danh duy nhất như ID slide hay giá trị placeholder động như ngày hiện tại.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Để biết thêm thông tin, xem [Compare Presentation Slides](/slides/vi/nodejs-java/compare-slides/).

## **Đặt Chế Độ Xem Bố Cục Slide Là Chế Độ Mặc Định**

Sử dụng phương thức `setLastView` trên [ViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/) để điều khiển chế độ mà PowerPoint mở đầu tiên. Ví dụ sau mở bản trình chiếu ở chế độ xem Bố cục Slide:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để biết thêm các thiết lập chế độ xem, xem [Save Presentation](/slides/vi/nodejs-java/save-presentation/).

## **Xóa Các Bố Cục Slide Không Sử Dụng**

Một số bản trình chiếu đôi khi chứa các bố cục slide không còn được bất kỳ slide bình thường nào sử dụng. Xóa các bố cục không dùng có thể giảm kích thước tệp và đơn giản hóa việc bảo trì mẫu.

Sử dụng `removeUnused` để loại bỏ các bố cục không dùng khỏi bộ sưu tập `getMasters()`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể dùng phương thức low-code `Compress.removeUnusedMasterSlides`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

### Sự khác biệt giữa slide master và layout slide là gì?

Slide master xác định các thiết lập thiết kế chung như chủ đề, nền, hình dạng chung và kiểu chữ. Layout slide thuộc về một slide master và xác định cách sắp xếp cụ thể của các placeholder. Slide bình thường sử dụng một layout slide, vì vậy nó kế thừa cả từ layout và từ master.

### Một bản trình chiếu có thể chứa nhiều slide master không?

Có. Một bản trình chiếu có thể chứa nhiều slide master. Sử dụng nhiều master khi các phần khác nhau cần hệ thống hình ảnh hoặc thương hiệu riêng.

### Nên thêm placeholder vào slide master hay layout slide?

Trong hầu hết các trường hợp, thêm placeholder vào layout slide. Đặt các yếu tố hình ảnh và định dạng chung trên slide master, sau đó đặt các placeholder nội dung trên layout mà các slide bình thường sẽ sử dụng.

### Tôi có thể xóa một slide master mà vẫn còn được sử dụng không?

Không. Một slide master có các slide phụ thuộc không thể xóa một cách an toàn. Đầu tiên chuyển các slide đó sang layout thuộc master khác, hoặc sử dụng phương pháp dọn dẹp các master không dùng chỉ loại bỏ những master không được bất kỳ slide nào sử dụng.