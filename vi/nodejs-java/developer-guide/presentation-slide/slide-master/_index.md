---
title: Quản lý Slide Master của bản trình chiếu trong JavaScript
linktitle: Slide Master
type: docs
weight: 70
url: /vi/nodejs-java/slide-master/
keywords:
- slide mẫu
- slide chính
- slide chính PPT
- nhiều slide chính
- so sánh các slide chính
- nền
- trình giữ chỗ
- sao chép slide chính
- sao chép slide chính
- nhân bản slide chính
- slide chính không sử dụng
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý slide master trong Aspose.Slides cho Node.js qua Java: truy cập, chỉnh sửa, sao chép, so sánh và xóa các slide master trong bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Một **slide master** định nghĩa các thiết lập thiết kế chia sẻ cho một nhóm các slide. Nó có thể chứa các hình dạng chung, logo, nền, kiểu văn bản, thiết lập giao diện và thiết lập chân trang. Trong PowerPoint, chỉnh sửa slide master là cách thông thường để giữ cho bản trình chiếu nhất quán mà không cần lặp lại cùng một định dạng trên mỗi slide.

Aspose.Slides for Node.js via Java hỗ trợ cùng mô hình. Một bản trình chiếu có thể chứa một hoặc nhiều master slide, và mỗi master slide có thể chứa vài layout slide. Các slide thường không tham chiếu trực tiếp tới master slide. Thay vào đó, một slide thường sử dụng một layout slide, và layout slide đó thuộc về một master slide.

The hierarchy is:

1. **Slide master** - định nghĩa thiết kế và giao diện chung.
1. **Layout slide** - định nghĩa bố cục cụ thể của các placeholder và định dạng cấp layout.
1. **Normal slide** - chứa nội dung thực tế của bản trình chiếu và sử dụng một layout slide.

![Sơ đồ phân cấp của master slides, layout slides và normal slides](slide-master_2.jpg)

Trong Aspose.Slides, slide master được đại diện bởi lớp [MasterSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/). Tất cả các master slide trong một bản trình chiếu có thể truy cập thông qua bộ sưu tập `Presentation.getMasters()`.

{{% alert color="info" title="Kế thừa" %}}
Khi cùng một thuộc tính được định nghĩa ở hơn một mức, mức cụ thể hơn sẽ thắng. Ví dụ, nếu một master slide và một layout slide đều định nghĩa nền, các slide dựa trên layout đó sẽ sử dụng nền của layout. Để biết thêm thông tin về layout slides, xem [Áp dụng hoặc Thay đổi Layout Slide](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Truy cập Slide Masters**

Trong PowerPoint, bạn có thể mở chế độ xem Slide Master từ **View** > **Slide Master**.

![Lệnh Slide Master trên tab View của PowerPoint](slide-master_3.jpg)

Trong Aspose.Slides, sử dụng bộ sưu tập `getMasters()` để truy cập master slides:

```javascript
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

Bạn cũng có thể lấy master slide được sử dụng bởi một slide thường thông qua layout của nó:

```javascript
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

## **Nội dung của Slide Master**

Một master slide là một đối tượng giống slide. Nó kế thừa hành vi chung của slide từ [BaseSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/), vì vậy nó cung cấp nhiều thuộc tính slide giống như những gì được sử dụng bởi các slide thường và layout. Các thành viên đặc thù của master được liệt kê ở trang API [MasterSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/masterslide/).

Các thành viên master slide thường được sử dụng bao gồm:

| Thành viên | Mục đích |
| --- | --- |
| `getBackground()` | Đặt nền slide cấp master. |
| `getShapes()` | Lưu trữ các shape đặt trên master, chẳng hạn logo, khung ảnh và văn bản chia sẻ. |
| `getLayoutSlides()` | Lưu trữ các layout slide thuộc về master. |
| `getThemeManager()` | Cung cấp quyền truy cập vào các API chủ đề của master. |
| `getHeaderFooterManager()` | Điều khiển tiêu đề, chân trang, ngày tháng và số slide cho master và các layout con của nó. |
| `getDependingSlides()` | Trả về các slide thường phụ thuộc vào master thông qua layout của chúng. |

## **Thêm Hình ảnh vào Slide Master**

Khi bạn thêm hình ảnh vào một master slide, nó sẽ xuất hiện trên các slide sử dụng layout từ master đó. Điều này hữu ích cho logo, watermark, dải trang trí và các yếu tố hình ảnh lặp lại khác.

Ví dụ sau thêm một logo vào master slide đầu tiên:

```javascript
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

Để biết thêm thông tin về khung ảnh, xem [Khung Ảnh](/nodejs-java/picture-frame/).

## **Làm việc với Placeholder**

Placeholder thường được định nghĩa trên layout slides. Master slide cung cấp kiểu và giao diện chung mà các layout này kế thừa, trong khi mỗi layout quyết định placeholder nào có sẵn và chúng được đặt ở đâu.

Trong PowerPoint, các lệnh placeholder có sẵn trong chế độ xem Slide Master.

![Lệnh Insert Placeholder trong chế độ xem Slide Master của PowerPoint](slide-master_5.png)

Để thêm placeholder mới với Aspose.Slides, làm việc với layout slide thuộc về master:

```javascript
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

Bạn cũng có thể định dạng các shape placeholder đã tồn tại trên master slide. Ví dụ sau tìm placeholder tiêu đề và áp dụng màu nền gradient tuyến tính:

```javascript
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Placeholder tiêu đề đã được định dạng, được thừa kế bởi các slide thường](slide-master_8.png)

Để biết thêm tùy chọn định dạng placeholder và văn bản, xem [Đặt Văn bản Gợi ý trong Placeholder](/nodejs-java/manage-placeholder/) và [Định dạng Văn bản](/nodejs-java/text-formatting/).

## **Thay đổi Nền Slide Master**

Nền master được kế thừa bởi các layout và slide không ghi đè nó. Ví dụ sau đặt màu nền đặc cho master slide đầu tiên:

```javascript
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

Để biết các chủ đề liên quan, xem [Nền Bản Trình Chiếu](/nodejs-java/presentation-background/) và [Giao diện Bản Trình Chiếu](/nodejs-java/presentation-theme/).

## **Sao chép Slide Master sang Bản Trình Chiếu Khác**

Sử dụng `MasterSlideCollection.addClone` để sao chép một master slide vào bản trình chiếu khác. Master đã sao chép sau đó có thể được sử dụng bởi các layout và slide trong bản trình chiếu đích.

```javascript
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

Nếu bạn cần sao chép các slide thường cùng với master của chúng, xem [Sao chép Slide](/nodejs-java/clone-slides/).

## **Thêm Nhiều Slide Master**

Một bản trình chiếu có thể chứa nhiều master slide. Điều này hữu ích khi các phần khác nhau yêu cầu thương hiệu, cấu trúc trang hoặc cài đặt giao diện khác nhau.

![Lệnh PowerPoint để chèn và quản lý master slides](slide-master_9.jpg)

Ví dụ sau sao chép master mặc định, đặt nền khác cho bản sao, tạo một layout dưới master đã sao chép, và thêm một slide mới dựa trên layout đó:

```javascript
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

## **So sánh Slide Masters**

Master slide có thể được so sánh bằng phương thức `equals` kế thừa từ [BaseSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/). Việc so sánh kiểm tra cấu trúc và nội dung tĩnh, chẳng hạn shape, văn bản, định dạng, hoạt ảnh và các cài đặt slide khác. Nó không so sánh các định danh duy nhất, như slide ID, hoặc giá trị placeholder động, như ngày hiện tại.

```javascript
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

Để biết thêm thông tin, xem [So sánh Slide Bản Trình Chiếu](/nodejs-java/compare-slides/).

## **Đặt chế độ xem Slide Master làm chế độ xem mặc định**

Sử dụng phương thức `setLastView` trên [ViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/) để điều khiển chế độ xem mà PowerPoint mở đầu tiên. Ví dụ sau mở bản trình chiếu ở chế độ Slide Master:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để biết thêm cài đặt chế độ xem, xem [Lưu Bản Trình Chiếu](/nodejs-java/save-presentation/).

## **Xóa các Master Slide không sử dụng**

Bản trình chiếu đôi khi chứa các master slide không còn được bất kỳ slide thường nào sử dụng. Loại bỏ các master không dùng có thể giảm kích thước tệp và đơn giản hoá việc bảo trì mẫu.

Sử dụng `removeUnused` để loại bỏ các master không dùng khỏi bộ sưu tập `getMasters()`:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể sử dụng phương thức low-code `Compress.removeUnusedMasterSlides`:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Sự khác biệt giữa slide master và layout slide là gì?**

Slide master định nghĩa các thiết lập thiết kế chia sẻ như giao diện, nền, các shape chung và kiểu văn bản. Layout slide thuộc về một master slide và định nghĩa một bố cục cụ thể của các placeholder. Slide thường sử dụng một layout slide, vì vậy nó kế thừa cả từ layout và master.

**Một bản trình chiếu có thể chứa nhiều slide master không?**

Có. Một bản trình chiếu có thể chứa nhiều slide master. Sử dụng nhiều master khi các phần khác nhau cần các hệ thống hình ảnh hoặc thương hiệu khác nhau.

**Tôi nên thêm placeholder vào master slide hay layout slide?**

Trong hầu hết các trường hợp, nên thêm placeholder vào layout slide. Đặt các yếu tố hình ảnh chung và định dạng chung trên master slide, sau đó đặt placeholder nội dung trên các layout mà các slide thường sẽ sử dụng.

**Tôi có thể xóa một master slide vẫn đang được sử dụng không?**

Không. Một master slide có các slide phụ thuộc không thể được xóa một cách an toàn trực tiếp. Đầu tiên chuyển các slide đó sang layout dưới master khác, hoặc sử dụng phương pháp dọn dẹp master không dùng để chỉ xóa các master không còn được sử dụng.