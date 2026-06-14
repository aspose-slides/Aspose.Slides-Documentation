---
title: Quản lý nền bài thuyết trình trong Java
linktitle: Nền Slide
type: docs
weight: 20
url: /vi/java/presentation-background/
keywords:
- nền bài thuyết trình
- nền slide
- màu đồng nhất
- màu gradient
- nền hình ảnh
- độ trong suốt nền
- thuộc tính nền
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách đặt nền động trong tập tin PowerPoint và OpenDocument bằng Aspose.Slides cho Java, với các mẹo mã giúp nâng cao bài thuyết trình của bạn."
---
## **Giới thiệu**

Solid colors, gradients, and images are commonly used for slide backgrounds. You can set the background for a **normal slide** (a single slide) or a **master slide** (applies to multiple slides at once).

![PowerPoint background](powerpoint-background.png)

## **Đặt nền màu đồng nhất cho Slide bình thường**

Aspose.Slides cho phép bạn đặt một màu đồng nhất làm nền cho một slide cụ thể trong bài thuyết trình — ngay cả khi bài thuyết trình sử dụng slide master. Thay đổi sẽ chỉ áp dụng cho slide được chọn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của nền slide thành `Solid`.
4. Sử dụng phương thức [getSolidFillColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/#getSolidFillColor--) trên [FillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/) để chỉ định màu nền đồng nhất.
5. Lưu bài thuyết trình đã chỉnh sửa.

Ví dụ Java sau đây cho thấy cách đặt màu xanh đậm đồng nhất làm nền cho một slide bình thường:

```java
// Tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Đặt màu nền của slide thành màu xanh.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Lưu bài thuyết trình vào đĩa.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt nền màu đồng nhất cho Slide master**

Aspose.Slides cho phép bạn đặt một màu đồng nhất làm nền cho slide master trong một bài thuyết trình. Slide master hoạt động như một mẫu kiểm soát định dạng cho tất cả các slide, vì vậy khi bạn chọn một màu đồng nhất cho nền của slide master, nó sẽ áp dụng cho mọi slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/backgroundtype/) của slide master (qua `getMasters`) thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của nền slide master thành `Solid`.
4. Sử dụng phương thức [getSolidFillColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/#getSolidFillColor--) để chỉ định màu nền đồng nhất.
5. Lưu bài thuyết trình đã chỉnh sửa.

Ví dụ Java sau đây cho thấy cách đặt một màu đồng nhất (xanh lá) làm nền cho slide master:

```java
// Tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Đặt màu nền cho slide Master thành màu Xanh Rừng.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Lưu bài thuyết trình vào đĩa.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt nền Gradient cho Slide**

Gradient là hiệu ứng đồ họa tạo ra bằng sự thay đổi dần dần của màu. Khi được sử dụng làm nền slide, gradient có thể làm cho bài thuyết trình trông nghệ thuật và chuyên nghiệp hơn. Aspose.Slides cho phép bạn đặt màu gradient làm nền cho các slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của nền slide thành `Gradient`.
4. Sử dụng phương thức [getGradientFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/#getGradientFormat--) trên [FillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/) để cấu hình các thiết lập gradient mong muốn.
5. Lưu bài thuyết trình đã chỉnh sửa.

Ví dụ Java sau đây cho thấy cách đặt màu gradient làm nền cho một slide:

```java
// Tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Áp dụng hiệu ứng gradient cho nền.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Lưu bài thuyết trình vào đĩa.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt hình ảnh làm nền Slide**

Ngoài các nền đồng nhất và gradient, Aspose.Slides cho phép bạn sử dụng hình ảnh làm nền slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) của nền slide thành `Picture`.
4. Tải hình ảnh bạn muốn sử dụng làm nền slide.
5. Thêm hình ảnh vào bộ sưu tập hình ảnh của bài thuyết trình.
6. Sử dụng phương thức [getPictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/#getPictureFillFormat--) trên [FillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/) để gán hình ảnh làm nền.
7. Lưu bài thuyết trình đã chỉnh sửa.

Ví dụ Java sau đây cho thấy cách đặt hình ảnh làm nền cho một slide:

```java
// Tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Đặt các thuộc tính hình ảnh nền.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Tải hình ảnh.
    IImage image = Images.fromFile("Tulips.jpg");
    // Thêm hình ảnh vào bộ sưu tập hình ảnh của bài thuyết trình.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Lưu bài thuyết trình vào đĩa.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mẫu code sau đây cho thấy cách đặt kiểu nền thành hình ảnh lắp gạch và chỉnh sửa các thuộc tính lắp gạch:

```java
Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Đặt hình ảnh được sử dụng cho việc tô nền.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Đặt chế độ tô hình ảnh thành Tile và điều chỉnh các thuộc tính lặp.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Đọc thêm: [**Hình ảnh lặp lại làm kết cấu**](/slides/vi/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Thay đổi Độ trong suốt của Hình nền**

Bạn có thể muốn điều chỉnh độ trong suốt của hình nền slide để làm nổi bật nội dung của slide. Đoạn mã Java sau đây cho bạn thấy cách thay đổi độ trong suốt cho hình nền slide:

```java
int transparencyValue = 30; // Ví dụ.

// Lấy bộ sưu tập các thao tác biến đổi hình ảnh.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Tìm hiệu ứng trong suốt cố định phần trăm hiện có.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Đặt giá trị trong suốt mới.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Lấy Giá trị Nền Slide**

Aspose.Slides cung cấp giao diện [IBackgroundEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibackgroundeffectivedata/) để lấy các giá trị nền thực tế của một slide. Giao diện này hiển thị [FillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) và [EffectFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) thực tế.

Bằng cách sử dụng phương thức `getBackground` của lớp [BaseSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseslide/), bạn có thể lấy nền thực tế cho một slide.

Ví dụ Java sau đây cho thấy cách lấy giá trị nền thực tế của một slide:

```java
// Tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lấy nền hiệu quả, tính đến master, layout và theme.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt lại nền tùy chỉnh và khôi phục lại nền của theme/bố cục không?**

Có. Xóa phần tô nền tùy chỉnh của slide, và nền sẽ được kế thừa lại từ slide [layout](/slides/vi/java/slide-layout/)/[master](/slides/vi/java/slide-master/) tương ứng (tức là [nền theme](/slides/vi/java/presentation-theme/)).

**Điều gì xảy ra với nền nếu tôi thay đổi theme của bài thuyết trình sau này?**

Nếu một slide có nền riêng, nó sẽ không thay đổi. Nếu nền được kế thừa từ [layout](/slides/vi/java/slide-layout/)/[master](/slides/vi/java/slide-master/), nó sẽ được cập nhật để phù hợp với [theme mới](/slides/vi/java/presentation-theme/).