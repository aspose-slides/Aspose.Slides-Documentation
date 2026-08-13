---
title: Quản lý nền bản trình chiếu trên Android
linktitle: Nền Slide
type: docs
weight: 20
url: /vi/androidjava/presentation-background/
keywords:
- nền bản trình chiếu
- nền slide
- màu đồng nhất
- màu gradient
- nền hình ảnh
- độ trong suốt nền
- thuộc tính nền
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách đặt nền động trong các tệp PowerPoint và OpenDocument bằng Aspose.Slides cho Android qua Java, kèm các mẹo mã để nâng cao bản trình chiếu của bạn."
---
## **Giới thiệu**

Màu đồng nhất, gradient và hình ảnh thường được sử dụng làm nền cho slide. Bạn có thể thiết lập nền cho một **slide bình thường** (một slide duy nhất) hoặc một **slide master** (áp dụng cho nhiều slide cùng lúc).

![Nền PowerPoint](powerpoint-background.png)

## **Đặt nền màu Đặc cho một Slide bình thường**

Aspose.Slides cho phép bạn đặt màu đồng nhất làm nền cho một slide cụ thể trong bản trình chiếu—ngay cả khi bản trình chiếu sử dụng slide master. Thay đổi này chỉ áp dụng cho slide đã chọn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
2. Đặt [BackgroundType] của slide thành `OwnBackground`.
3. Đặt [FillType] nền slide thành `Solid`.
4. Sử dụng phương thức [getSolidFillColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) trên [FillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/) để chỉ định màu nền đặc.
5. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ Java sau cho thấy cách đặt màu xanh đậm làm nền đặc cho một slide bình thường:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Đặt màu nền của slide thành màu xanh.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Lưu bản trình chiếu vào ổ đĩa.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt nền màu Đặc cho một Slide Master**

Aspose.Slides cho phép bạn đặt màu đồng nhất làm nền cho slide master trong bản trình chiếu. Slide master hoạt động như một mẫu kiểm soát định dạng cho tất cả các slide, vì vậy khi bạn chọn màu đồng nhất cho nền của slide master, nó sẽ áp dụng cho mọi slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
2. Đặt [BackgroundType] của slide master (thông qua `getMasters`) thành `OwnBackground`.
3. Đặt [FillType] nền slide master thành `Solid`.
4. Sử dụng phương thức [getSolidFillColor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) để chỉ định màu nền đặc.
5. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ Java sau cho thấy cách đặt màu xanh lá cây làm nền đặc cho một slide master:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Đặt màu nền cho slide master thành màu xanh lá cây.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Lưu bản trình chiếu vào ổ đĩa.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt nền Gradient cho một Slide**

Gradient là hiệu ứng đồ họa được tạo ra bằng cách thay đổi màu sắc dần dần. Khi được sử dụng làm nền slide, gradient có thể làm cho bản trình chiếu trông nghệ thuật và chuyên nghiệp hơn. Aspose.Slides cho phép bạn đặt màu gradient làm nền cho các slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
2. Đặt [BackgroundType] của slide thành `OwnBackground`.
3. Đặt [FillType] nền slide thành `Gradient`.
4. Sử dụng phương thức [getGradientFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) trên [FillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/) để cấu hình các thiết lập gradient mong muốn.
5. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ Java sau cho thấy cách đặt màu gradient làm nền cho một slide:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Áp dụng hiệu ứng gradient cho nền.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Thêm các màu gradient. Không có gradient stops, nền sẽ quay lại dải màu đen đến trắng mặc định.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Lưu bản trình chiếu vào ổ đĩa.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt hình ảnh làm nền cho Slide**

Ngoài các dạng nền đồng nhất và gradient, Aspose.Slides còn cho phép bạn sử dụng hình ảnh làm nền cho slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) .
2. Đặt [BackgroundType] của slide thành `OwnBackground`.
3. Đặt [FillType] nền slide thành `Picture`.
4. Tải hình ảnh bạn muốn sử dụng làm nền slide.
5. Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu.
6. Sử dụng phương thức [getPictureFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) trên [FillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/) để gán hình ảnh làm nền.
7. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ Java sau cho thấy cách đặt một hình ảnh làm nền cho một slide:

```java
import com.aspose.slides.*;

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
    // Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Lưu bản trình chiếu vào ổ đĩa.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mã mẫu sau cho thấy cách đặt kiểu nền đầy là hình ảnh lặp và chỉnh sửa các thuộc tính lặp:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Đặt hình ảnh được sử dụng cho nền lấp.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Đặt chế độ lấp ảnh thành Tile và điều chỉnh các thuộc tính lát.
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

{{% alert color="info" %}}
Đọc thêm: [**Tile Picture As Texture**](/slides/vi/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Thay đổi Độ trong suốt của Hình nền**

Bạn có thể muốn điều chỉnh độ trong suốt của hình nền slide để làm nổi bật nội dung của slide. Đoạn mã Java sau cho thấy cách thay đổi độ trong suốt cho hình nền của một slide:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Ví dụ.

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lấy bộ sưu tập các phép biến đổi hình ảnh.
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

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lấy Giá trị Nền Slide**

Aspose.Slides cung cấp giao diện [IBackgroundEffectiveData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibackgroundeffectivedata/) để truy xuất các giá trị nền thực tế của một slide. Giao diện này hiện ra [FillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) và [EffectFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) thực tế.

Sử dụng phương thức `getBackground` của lớp [BaseSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseslide/), bạn có thể nhận được nền thực tế của một slide.

Ví dụ Java sau cho thấy cách lấy giá trị nền thực tế của một slide:

```java
import com.aspose.slides.*;

// Tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lấy nền thực tế, tính đến master, layout và theme.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Tôi có thể đặt lại nền tùy chỉnh và khôi phục lại nền giao diện/bố cục không?

Có. Gỡ bỏ phần fill tùy chỉnh của slide, và nền sẽ lại được kế thừa từ slide [layout](/slides/vi/androidjava/slide-layout/)/[master](/slides/vi/androidjava/slide-master/) tương ứng (tức là [theme background](/slides/vi/androidjava/presentation-theme/)).

### Điều gì sẽ xảy ra với nền nếu tôi thay đổi giao diện của bản trình chiếu sau này?

Nếu một slide có phần fill riêng, nó sẽ không thay đổi. Nếu nền được kế thừa từ [layout](/slides/vi/androidjava/slide-layout/)/[master](/slides/vi/androidjava/slide-master/), nó sẽ cập nhật để phù hợp với [new theme](/slides/vi/androidjava/presentation-theme/).