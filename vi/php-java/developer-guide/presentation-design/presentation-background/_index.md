---
title: Quản lý nền bài thuyết trình trong PHP
linktitle: Nền Slide
type: docs
weight: 20
url: /vi/php-java/presentation-background/
keywords:
- nền bài thuyết trình
- nền slide
- màu đặc
- màu gradient
- nền ảnh
- độ trong suốt nền
- thuộc tính nền
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tìm hiểu cách đặt nền động trong các tệp PowerPoint và OpenDocument bằng Aspose.Slides cho PHP qua Java, kèm các mẹo mã giúp nâng cao bài thuyết trình của bạn."
---
## **Giới thiệu**

Màu nền đặc, gradient và hình ảnh thường được sử dụng cho nền của slide. Bạn có thể đặt nền cho một **slide thường** (một slide riêng lẻ) hoặc một **slide mẫu** (áp dụng cho nhiều slide cùng lúc).

![Nền PowerPoint](powerpoint-background.png)

## **Đặt nền màu đặc cho một Slide Thông thường**

Aspose.Slides cho phép bạn đặt một màu đặc làm nền cho một slide cụ thể trong bản trình chiếu — ngay cả khi bản trình chiếu sử dụng slide mẫu. Thay đổi chỉ áp dụng cho slide đã chọn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của nền slide thành `Solid`.
4. Sử dụng phương thức [getSolidFillColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/#getSolidFillColor) trên [FillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/) để chỉ định màu nền đặc.
5. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ PHP sau cho thấy cách đặt màu xanh đậm làm nền cho một slide thường:

```php
// Tạo một thể hiện của lớp Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Đặt màu nền của slide thành màu xanh.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // Lưu bản trình chiếu vào đĩa.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt nền màu đặc cho Slide Mẫu**

Aspose.Slides cho phép bạn đặt một màu đặc làm nền cho slide mẫu trong bản trình chiếu. Slide mẫu hoạt động như một mẫu kiểm soát định dạng cho tất cả các slide, vì vậy khi bạn chọn màu đặc cho nền slide mẫu, nó sẽ áp dụng cho mọi slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/backgroundtype/) của slide mẫu (qua `getMasters`) thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của nền slide mẫu thành `Solid`.
4. Sử dụng phương thức [getSolidFillColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/#getSolidFillColor) để chỉ định màu nền đặc.
5. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ PHP sau cho thấy cách đặt màu xanh lá làm nền cho slide mẫu:

```php
// Tạo một thể hiện của lớp Presentation.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // Đặt màu nền cho slide Master thành màu Xanh Rừng.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // Lưu bản trình chiếu vào đĩa.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt nền Gradient cho Slide**

Gradient là hiệu ứng đồ họa được tạo ra bằng cách thay đổi màu sắc dần dần. Khi được sử dụng làm nền slide, gradient có thể làm cho bài thuyết trình trông nghệ thuật và chuyên nghiệp hơn. Aspose.Slides cho phép bạn đặt màu gradient làm nền cho các slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của nền slide thành `Gradient`.
4. Sử dụng phương thức [getGradientFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/#getGradientFormat) trên [FillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/) để cấu hình các thiết lập gradient mong muốn.
5. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ PHP sau cho thấy cách đặt màu gradient làm nền cho một slide:

```php
// Tạo một thể hiện của lớp Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Áp dụng hiệu ứng gradient cho nền.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // Lưu bản trình chiếu vào đĩa.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt hình ảnh làm nền cho Slide**

Ngoài các màu nền đặc và gradient, Aspose.Slides cho phép bạn sử dụng hình ảnh làm nền cho slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) của nền slide thành `Picture`.
4. Tải hình ảnh bạn muốn dùng làm nền cho slide.
5. Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu.
6. Sử dụng phương thức [getPictureFillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/#getPictureFillFormat) trên [FillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/) để gán hình ảnh làm nền.
7. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ PHP sau cho thấy cách đặt hình ảnh làm nền cho một slide:

```php
// Tạo một thể hiện của lớp Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Đặt các thuộc tính hình ảnh nền.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // Tải hình ảnh.
    $image = Images::fromFile("Tulips.jpg");
    // Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // Lưu bản trình chiếu vào đĩa.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Đoạn mã sau cho thấy cách đặt loại nền thành ảnh lát và chỉnh sửa các thuộc tính lật:

```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // Đặt hình ảnh được sử dụng cho việc tô nền.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // Đặt chế độ tô ảnh thành Lát và điều chỉnh các thuộc tính lát.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Đọc thêm: [**Hình ảnh lát làm Texture**](/slides/vi/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Thay đổi độ trong suốt của hình ảnh nền**

Bạn có thể muốn điều chỉnh độ trong suốt của hình ảnh nền slide để nội dung slide nổi bật hơn. Đoạn code PHP sau cho bạn thấy cách thay đổi độ trong suốt cho hình ảnh nền slide:

```php
$transparencyValue = 30; // Ví dụ.

// Lấy bộ sưu tập các phép biến đổi ảnh.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Tìm hiệu ứng trong suốt tỉ lệ cố định hiện có.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Đặt giá trị trong suốt mới.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```

## **Lấy giá trị nền của Slide**

Aspose.Slides cung cấp lớp `BackgroundEffectiveData` để lấy các giá trị nền thực tế của một slide. Lớp này cung cấp thông tin về [FillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/) và [EffectFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effectformat/) thực tế.

Bằng cách sử dụng phương thức `getBackground` của lớp [BaseSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslide/), bạn có thể lấy nền thực tế của một slide.

Ví dụ PHP sau cho thấy cách lấy giá trị nền thực tế của một slide:

```php
// Tạo một thể hiện của lớp Presentation.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Lấy nền hiệu quả, tính đến master, layout và theme.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt lại nền tùy chỉnh và khôi phục nền giao diện/bố cục không?**

Có. Loại bỏ phần fill tùy chỉnh của slide, và nền sẽ được kế thừa lại từ slide [layout](/slides/vi/php-java/slide-layout/)/[master](/slides/vi/php-java/slide-master/) tương ứng (tức là [theme background](/slides/vi/php-java/presentation-theme/)).

**Điều gì sẽ xảy ra với nền nếu tôi thay đổi giao diện của bản trình chiếu sau này?**

Nếu một slide có fill riêng, nó sẽ không thay đổi. Nếu nền được kế thừa từ [layout](/slides/vi/php-java/slide-layout/)/[master](/slides/vi/php-java/slide-master/), nó sẽ cập nhật để phù hợp với [new theme](/slides/vi/php-java/presentation-theme/).