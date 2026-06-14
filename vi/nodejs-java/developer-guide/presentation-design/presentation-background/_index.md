---
title: Quản lý nền bài thuyết trình trong JavaScript
linktitle: Nền Slide
type: docs
weight: 20
url: /vi/nodejs-java/presentation-background/
keywords:
- nền bài thuyết trình
- nền slide
- màu đơn sắc
- màu gradient
- nền hình ảnh
- trong suốt nền
- thuộc tính nền
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách đặt nền động cho các tệp PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js, với các mẹo mã giúp nâng cao bài thuyết trình của bạn."
---
## **Giới thiệu**

Màu nền đơn sắc, gradient và hình ảnh thường được sử dụng cho nền slide. Bạn có thể đặt nền cho một **slide bình thường** (một slide duy nhất) hoặc một **slide mẫu** (áp dụng cho nhiều slide cùng lúc).

![PowerPoint background](powerpoint-background.png)

## **Đặt nền màu đơn sắc cho Slide bình thường**

Aspose.Slides cho phép bạn đặt một màu đơn sắc làm nền cho một slide cụ thể trong bài thuyết trình—ngay cả khi bài thuyết trình sử dụng slide mẫu. Thay đổi chỉ áp dụng cho slide đã chọn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của nền slide thành `Solid`.
4. Sử dụng phương thức [getSolidFillColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) trên [FillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/) để chỉ định màu nền đơn sắc.
5. Lưu bài thuyết trình đã chỉnh sửa.

Ví dụ JavaScript sau cho thấy cách đặt màu xanh lam đơn sắc làm nền cho một slide bình thường:

```js
// Tạo một thể hiện của lớp Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Đặt màu nền của slide thành màu xanh dương.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Lưu bài thuyết trình vào ổ đĩa.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt nền màu đơn sắc cho Slide mẫu**

Aspose.Slides cho phép bạn đặt một màu đơn sắc làm nền cho slide mẫu trong bài thuyết trình. Slide mẫu hoạt động như một mẫu kiểm soát định dạng cho tất cả các slide, vì vậy khi bạn chọn một màu đơn sắc cho nền của slide mẫu, nó sẽ áp dụng cho mọi slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/backgroundtype/) của slide mẫu (qua `getMasters`) thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của nền slide mẫu thành `Solid`.
4. Sử dụng phương thức [getSolidFillColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) để chỉ định màu nền đơn sắc.
5. Lưu bài thuyết trình đã chỉnh sửa.

Ví dụ JavaScript sau cho thấy cách đặt một màu xanh lá cây đơn sắc làm nền cho slide mẫu:

```js
// Tạo một thể hiện của lớp Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Đặt màu nền cho slide Master là màu xanh rừng.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Lưu bài thuyết trình vào ổ đĩa.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt nền Gradient cho Slide**

Gradient là một hiệu ứng đồ họa được tạo ra bằng cách thay đổi màu dần dần. Khi được sử dụng làm nền slide, gradient có thể làm cho bài thuyết trình trông nghệ thuật và chuyên nghiệp hơn. Aspose.Slides cho phép bạn đặt màu gradient làm nền cho các slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của nền slide thành `Gradient`.
4. Sử dụng phương thức [getGradientFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/#getGradientFormat) trên [FillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/) để cấu hình các thiết lập gradient mong muốn.
5. Lưu bài thuyết trình đã chỉnh sửa.

Ví dụ JavaScript sau cho thấy cách đặt màu gradient làm nền cho một slide:

```js
// Tạo một thể hiện của lớp Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Áp dụng hiệu ứng gradient cho nền.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Lưu bài thuyết trình vào ổ đĩa.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt hình ảnh làm Nền Slide**

Ngoài các kiểu nền đơn sắc và gradient, Aspose.Slides cho phép bạn sử dụng hình ảnh làm nền slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) của nền slide thành `Picture`.
4. Tải hình ảnh bạn muốn sử dụng làm nền slide.
5. Thêm hình ảnh vào bộ sưu tập hình ảnh của bài thuyết trình.
6. Sử dụng phương thức [getPictureFillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) trên [FillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/) để gán hình ảnh làm nền.
7. Lưu bài thuyết trình đã chỉnh sửa.

Ví dụ JavaScript sau cho thấy cách đặt một hình ảnh làm nền cho một slide:

```js
// Tạo một thể hiện của lớp Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Đặt các thuộc tính hình ảnh nền.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Tải hình ảnh.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Thêm hình ảnh vào bộ sưu tập hình ảnh của bài thuyết trình.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Lưu bài thuyết trình vào ổ đĩa.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mẫu mã sau cho thấy cách đặt kiểu nền thành hình ảnh lặp và chỉnh sửa các thuộc tính lặp:

```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Đặt hình ảnh được sử dụng cho phần nền.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Đặt chế độ điền ảnh thành Tile và điều chỉnh các thuộc tính của lớp.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

Đọc thêm: [**Tile Picture As Texture**](/slides/vi/nodejs-java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Thay đổi độ trong suốt của hình ảnh nền**

Bạn có thể muốn điều chỉnh độ trong suốt của hình ảnh nền slide để làm nổi bật nội dung slide. Đoạn mã JavaScript sau cho thấy cách thay đổi độ trong suốt cho hình ảnh nền slide:

```js
var transparencyValue = 30; // Ví dụ.

// Get the collection of picture transform operations.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Lấy Giá trị Nền Slide**

Aspose.Slides cung cấp lớp `BackgroundEffectiveData` để truy xuất các giá trị nền hiệu quả của một slide. Lớp này cung cấp [FillFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fillformat/) và [EffectFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effectformat/) hiệu quả.

Bằng cách sử dụng phương thức `getBackground` của lớp [BaseSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/), bạn có thể lấy nền hiệu quả của một slide.

Ví dụ JavaScript sau cho thấy cách lấy giá trị nền hiệu quả của một slide:

```js
// Tạo một thể hiện của lớp Presentation.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Lấy nền hiệu quả, tính đến master, layout và theme.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Tôi có thể đặt lại nền tùy chỉnh và khôi phục lại nền theme/layout không?**

Có. Xóa phần fill tùy chỉnh của slide, và nền sẽ được kế thừa lại từ slide [layout](/slides/vi/nodejs-java/slide-layout/)/[master](/slides/vi/nodejs-java/slide-master/) tương ứng (tức là [theme background](/slides/vi/nodejs-java/presentation-theme/)).

**Điều gì sẽ xảy ra với nền nếu tôi thay đổi theme của bài thuyết trình sau này?**

Nếu một slide có fill riêng, nó sẽ không thay đổi. Nếu nền được kế thừa từ [layout](/slides/vi/nodejs-java/slide-layout/)/[master](/slides/vi/nodejs-java/slide-master/), nó sẽ cập nhật để phù hợp với [theme mới](/slides/vi/nodejs-java/presentation-theme/).