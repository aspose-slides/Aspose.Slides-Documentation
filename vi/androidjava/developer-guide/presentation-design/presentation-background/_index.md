---
title: Quản lý Nền Trình bày trên Android
linktitle: Nền Slide
type: docs
weight: 20
url: /vi/androidjava/presentation-background/
keywords:
- nền trình bày
- nền slide
- màu đồng nhất
- màu gradient
- nền hình ảnh
- độ trong suốt nền
- thuộc tính nền
- PowerPoint
- OpenDocument
- trình bày
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách thiết lập nền động trong các tệp PowerPoint và OpenDocument bằng Aspose.Slides cho Android qua Java, kèm các mẹo mã để nâng cao bài thuyết trình của bạn."
---
## **Giới thiệu**

Màu nền đồng nhất, gradient và hình ảnh thường được sử dụng làm nền cho slide. Bạn có thể đặt nền cho một **slide bình thường** (một slide duy nhất) hoặc một **slide mẫu** (áp dụng cho nhiều slide cùng lúc).

![Nền PowerPoint](powerpoint-background.png)

## **Đặt nền màu đồng nhất cho Slide bình thường**

Aspose.Slides cho phép bạn đặt màu đồng nhất làm nền cho một slide cụ thể trong bản trình bày—ngay cả khi bản trình bày sử dụng slide mẫu. Thay đổi chỉ áp dụng cho slide đã chọn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) của nền slide thành `Solid`.
4. Sử dụng phương thức [getSolidFillColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) trên [FillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/) để chỉ định màu nền đồng nhất.
5. Lưu bản trình bày đã sửa đổi.

Ví dụ Java sau cho thấy cách đặt màu xanh đồng nhất làm nền cho một slide bình thường:

```java
// Tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Đặt màu nền của slide thành màu xanh.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Lưu bản trình bày vào đĩa.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt nền màu đồng nhất cho Slide mẫu**

Aspose.Slides cho phép bạn đặt màu đồng nhất làm nền cho slide mẫu trong một bản trình bày. Slide mẫu đóng vai trò là mẫu kiểm soát định dạng cho tất cả các slide, vì vậy khi bạn chọn một màu đồng nhất cho nền của slide mẫu, nó sẽ áp dụng cho mọi slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/backgroundtype/) của slide mẫu (qua `getMasters`) thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) của nền slide mẫu thành `Solid`.
4. Sử dụng phương thức [getSolidFillColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) để chỉ định màu nền đồng nhất.
5. Lưu bản trình bày đã sửa đổi.

Ví dụ Java sau cho thấy cách đặt một màu đồng nhất (xanh lá) làm nền cho slide mẫu:

```java
// Tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Đặt màu nền cho slide Master thành màu Xanh Rừng.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Lưu bản trình bày vào đĩa.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt nền Gradient cho Slide**

Gradient là một hiệu ứng đồ họa được tạo ra nhờ sự thay đổi màu dần dần. Khi được sử dụng làm nền cho slide, gradient có thể làm cho bài thuyết trình trông nghệ thuật và chuyên nghiệp hơn. Aspose.Slides cho phép bạn đặt màu gradient làm nền cho các slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) của nền slide thành `Gradient`.
4. Sử dụng phương thức [getGradientFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) trên [FillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/) để cấu hình các thiết lập gradient mong muốn.
5. Lưu bản trình bày đã sửa đổi.

Ví dụ Java sau cho thấy cách đặt màu gradient làm nền cho một slide:

```java
// Tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Áp dụng hiệu ứng gradient lên nền.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Lưu bản trình bày vào đĩa.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt hình ảnh làm nền cho Slide**

Ngoài các loại nền đồng nhất và gradient, Aspose.Slides cho phép bạn sử dụng hình ảnh làm nền cho slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/filltype/) của nền slide thành `Picture`.
4. Tải hình ảnh mà bạn muốn sử dụng làm nền cho slide.
5. Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình bày.
6. Sử dụng phương thức [getPictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) trên [FillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/) để gán hình ảnh làm nền.
7. Lưu bản trình bày đã sửa đổi.

Ví dụ Java sau cho thấy cách đặt hình ảnh làm nền cho một slide:

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
    // Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình bày.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Lưu bản trình bày vào đĩa.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mẫu mã sau cho thấy cách đặt kiểu nền thành hình ảnh lặp và chỉnh sửa các thuộc tính lặp:

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

    // Đặt hình ảnh được sử dụng cho việc lấp nền.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Đặt chế độ lấp ảnh thành Tile và điều chỉnh các thuộc tính lặp.
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
Đọc thêm: [**Tile Picture As Texture**](/slides/vi/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Thay đổi độ trong suốt của hình nền**

Bạn có thể muốn điều chỉnh độ trong suốt của hình nền slide để làm nổi bật nội dung của slide. Mã Java sau cho thấy cách thay đổi độ trong suốt cho hình nền slide:

```java
int transparencyValue = 30; // Ví dụ.

// Lấy bộ sưu tập các thao tác biến đổi hình ảnh.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Tìm hiệu ứng trong suốt phần trăm cố định hiện có.
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

## **Lấy giá trị nền của Slide**

Aspose.Slides cung cấp giao diện [IBackgroundEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibackgroundeffectivedata/) để lấy các giá trị nền thực tế của slide. Giao diện này cung cấp [FillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) và [EffectFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) thực tế. Sử dụng phương thức `getBackground` của lớp [BaseSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseslide/) , bạn có thể lấy nền thực tế của một slide.

Ví dụ Java sau cho thấy cách lấy giá trị nền thực tế của một slide:

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

**Tôi có thể đặt lại nền tùy chỉnh và khôi phục nền chủ đề/bố cục không?**

Có. Loại bỏ phần fill tùy chỉnh của slide, và nền sẽ được kế thừa lại từ slide [layout](/slides/vi/androidjava/slide-layout/)/[master](/slides/vi/androidjava/slide-master/) tương ứng (tức là [theme background](/slides/vi/androidjava/presentation-theme/)).

**Điều gì sẽ xảy ra với nền nếu tôi thay đổi chủ đề của bản trình bày sau này?**

Nếu một slide có phần fill riêng, nó sẽ không thay đổi. Nếu nền được kế thừa từ [layout](/slides/vi/androidjava/slide-layout/)/[master](/slides/vi/androidjava/slide-master/), nó sẽ được cập nhật để khớp với [new theme](/slides/vi/androidjava/presentation-theme/).