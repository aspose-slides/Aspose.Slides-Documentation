---
title: Quản lý Nền Bài Trình Chiếu trong Java
linktitle: Nền Slide
type: docs
weight: 20
url: /vi/java/presentation-background/
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
- Java
- Aspose.Slides
description: "Tìm hiểu cách thiết lập nền động trong các tệp PowerPoint và OpenDocument bằng Aspose.Slides cho Java, kèm các mẹo mã giúp nâng cao bản trình chiếu của bạn."
---
## **Giới thiệu**

Màu nền đồng nhất, gradient và hình ảnh thường được sử dụng cho nền của slide. Bạn có thể đặt nền cho một **slide thường** (một slide duy nhất) hoặc một **slide chủ** (áp dụng cho nhiều slide cùng lúc).

![PowerPoint background](powerpoint-background.png)

## **Đặt Nền Màu Đồng Nhất cho Slide Thông Thường**

Aspose.Slides cho phép bạn đặt một màu đồng nhất làm nền cho một slide cụ thể trong bản trình bày — ngay cả khi bản trình bày sử dụng slide chủ. Thay đổi chỉ áp dụng cho slide được chọn.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) nền slide thành `Solid`.
4. Sử dụng phương thức [getSolidFillColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/#getSolidFillColor--) trên [FillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/) để chỉ định màu nền đồng nhất.
5. Lưu bản trình bày đã chỉnh sửa.

Ví dụ Java sau đây cho thấy cách đặt màu đồng nhất màu xanh làm nền cho một slide thường:

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
    
    // Lưu bản trình chiếu vào đĩa.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Nền Màu Đồng Nhất cho Slide Chủ**

Aspose.Slides cho phép bạn đặt một màu đồng nhất làm nền cho slide chủ trong bản trình bày. Slide chủ hoạt động như một mẫu điều khiển định dạng cho tất cả các slide, vì vậy khi bạn chọn một màu đồng nhất cho nền của slide chủ, nó sẽ áp dụng cho mọi slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/backgroundtype/) của slide chủ (qua `getMasters`) thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) nền slide chủ thành `Solid`.
4. Sử dụng phương thức [getSolidFillColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/#getSolidFillColor--) để chỉ định màu nền đồng nhất.
5. Lưu bản trình bày đã chỉnh sửa.

Ví dụ Java sau đây cho thấy cách đặt màu đồng nhất (xanh lá) làm nền cho một slide chủ:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Tạo một thể hiện của lớp Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Đặt màu nền cho slide chủ thành màu xanh lá.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Lưu bản trình chiếu vào đĩa.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Nền Gradient cho Slide**

Gradient là một hiệu ứng đồ họa được tạo ra bằng sự thay đổi dần dần về màu sắc. Khi được sử dụng làm nền slide, gradient có thể làm cho bản trình bày trông nghệ thuật và chuyên nghiệp hơn. Aspose.Slides cho phép bạn đặt màu gradient làm nền cho các slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) nền slide thành `Gradient`.
4. Sử dụng phương thức [getGradientFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/#getGradientFormat--) trên [FillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/) để cấu hình các thiết lập gradient mong muốn.
5. Lưu bản trình bày đã chỉnh sửa.

Ví dụ Java sau đây cho thấy cách đặt màu gradient làm nền cho một slide:

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

    // Thêm các màu gradient. Nếu không có các điểm dừng gradient, nền sẽ sử dụng dải màu đen‑trắng mặc định.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Lưu bản trình chiếu vào đĩa.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Hình Ảnh làm Nền Slide**

Ngoài việc sử dụng màu nền đồng nhất và gradient, Aspose.Slides cho phép bạn sử dụng hình ảnh làm nền cho slide.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
2. Đặt [BackgroundType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/backgroundtype/) của slide thành `OwnBackground`.
3. Đặt [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) nền slide thành `Picture`.
4. Tải hình ảnh bạn muốn sử dụng làm nền slide.
5. Thêm hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu.
6. Sử dụng phương thức [getPictureFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/#getPictureFillFormat--) trên [FillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/) để gán hình ảnh làm nền.
7. Lưu bản trình bày đã chỉnh sửa.

Ví dụ Java sau đây cho thấy cách đặt hình ảnh làm nền cho một slide:

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
    
    // Lưu bản trình chiếu vào đĩa.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mã mẫu sau đây cho thấy cách đặt loại tô nền thành ảnh lặp và chỉnh sửa các thuộc tính lặp:

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

    // Đặt hình ảnh được sử dụng cho việc tô nền.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Đặt chế độ tô hình ảnh thành Lặp và điều chỉnh các thuộc tính lặp.
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
Read more: [**Tile Picture As Texture**](/slides/vi/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Thay Đổi Độ Trong Suốt của Hình Nền**

Bạn có thể muốn điều chỉnh độ trong suốt của hình nền slide để làm nổi bật nội dung của slide. Mã Java sau đây cho bạn thấy cách thay đổi độ trong suốt cho hình nền của slide:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Ví dụ.

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

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

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lấy Giá Trị Nền Slide**

Aspose.Slides cung cấp giao diện [IBackgroundEffectiveData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibackgroundeffectivedata/) để truy xuất các giá trị nền hiệu quả của một slide. Giao diện này cung cấp các [FillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) và [EffectFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) hiệu quả.

Bằng cách sử dụng phương thức `getBackground` của lớp [BaseSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseslide/), bạn có thể lấy nền hiệu quả cho một slide.

Ví dụ Java sau đây cho thấy cách lấy giá trị nền hiệu quả của một slide:

```java
import com.aspose.slides.*;

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

## **FAQ**

### **Tôi có thể đặt lại nền tùy chỉnh và khôi phục nền của giao diện/bố cục không?**

Có. Xóa phần tô tùy chỉnh của slide, nền sẽ được kế thừa lại từ slide [layout](/slides/vi/java/slide-layout/)/[master](/slides/vi/java/slide-master/) tương ứng (tức là [nền giao diện](/slides/vi/java/presentation-theme/)).

### **Điều gì sẽ xảy ra với nền nếu tôi đổi giao diện của bản trình bày sau này?**

Nếu một slide có phần tô riêng, nó sẽ không thay đổi. Nếu nền được kế thừa từ [layout](/slides/vi/java/slide-layout/)/[master](/slides/vi/java/slide-master/), nó sẽ được cập nhật để khớp với [giao diện mới](/slides/vi/java/presentation-theme/).