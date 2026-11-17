---
title: Quản lý các hiệu ứng biến đổi hình ảnh trong bản trình chiếu với Java
linktitle: Các hiệu ứng biến đổi hình ảnh
type: docs
weight: 11
url: /vi/java/image-transform-effects/
keywords:
- biến đổi hình ảnh
- hiệu ứng hình ảnh
- độ sáng
- độ tương phản
- xám
- đôi màu
- tô màu
- HSL
- thay thế màu
- làm mờ
- độ trong suốt
- hiệu ứng alpha
- chuỗi hiệu ứng
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Áp dụng, tạo chuỗi, kiểm tra, xóa và xác minh các hiệu ứng biến đổi hình ảnh cho khung hình với Aspose.Slides cho Java."
---
## **Tổng quan**

Aspose.Slides biểu diễn các điều chỉnh hình ảnh dưới dạng một bộ sưu tập có thứ tự của các thao tác biến đổi hình ảnh. Đối với một khung hình, bắt đầu với [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) của khung và truy cập [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--). Bộ sưu tập [IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xóa và xóa bỏ các hiệu ứng mà không cần ghi lại lại các byte hình ảnh gốc.

Bài viết này trình bày quy trình hoàn chỉnh cho độ sáng và độ tương phản, các biến đổi màu, làm mờ, độ trong suốt, chuỗi hiệu ứng có thứ tự, các giá trị hiệu quả, việc loại bỏ và xác minh vòng quay lại PPTX.

## **Hiểu Quyền Sở Hữu Hiệu Ứng và Tái Sử Dụng Hình Ảnh**

Một tài nguyên hình ảnh và hình ảnh hiển thị nó là các đối tượng khác nhau:

- [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) lưu trữ hoặc tham chiếu dữ liệu hình ảnh nguồn thuộc về bản trình chiếu.
- [ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) thuộc về một vùng điền hình ảnh và tham chiếu tới tài nguyên hình ảnh đồng thời lưu trữ bộ sưu tập biến đổi hình ảnh.
- [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) là hình dạng trên slide sở hữu vùng điền hình ảnh, hình học, cài đặt cắt và các định dạng cấp khung khác.

Do đó, các thao tác biến đổi hình ảnh không thay đổi các byte trong [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/). Khi cùng một `IPPImage` được truyền cho [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) hơn một lần, mỗi khung hình mới nhận được một `ISlidesPicture` riêng và một bộ sưu tập biến đổi riêng. Áp dụng chuyển đổi màu xám cho một khung không làm các khung khác cũng chuyển sang màu xám, dù tất cả đều tái sử dụng cùng một tài nguyên hình ảnh được nhúng.

Mô hình `ISlidesPicture.getImageTransform` cũng được sử dụng bởi các vùng điền hình ảnh khác, chẳng hạn như dạng hoặc nền slide. Các ví dụ bên dưới tập trung vào khung hình.

## **Sử Dụng Khoảng Tham Số và Đơn Vị Hợp Lệ**

Các phương thức được minh họa sử dụng các khoảng và đơn vị ngữ nghĩa sau. Giữ các giá trị trong các khoảng này ngay cả khi một phiên bản thư viện cụ thể không từ chối ngay mọi giá trị ngoài phạm vi; định dạng bản trình chiếu đích có thể chuẩn hoá, bỏ qua hoặc từ chối dữ liệu không hợp lệ trong quá trình lưu hoặc khi PowerPoint mở tệp.

| Hoạt động | Tham số | Khoảng hợp lệ và đơn vị |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` tới `100`, phần trăm; `0` giữ thành phần không thay đổi. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | Không có tham số số. Alpha không thay đổi. |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Hai màu cho pixel tối và sáng. Các kênh RGB và alpha trong `java.awt.Color` dùng `0` tới `255`. |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Hue từ `0` (đã bao gồm) tới `360` (không bao gồm), đơn vị độ; amount từ `-100` tới `100`, phần trăm. |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Hue từ `0` tới `360` độ; saturation và luminance từ `-100` tới `100`, phần trăm. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Màu thay thế sử dụng các giá trị kênh từ `0` tới `255`. Giá trị alpha hiện có không thay đổi. |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Bán kính không âm và đo bằng điểm; `grow` là Boolean điều khiển nội dung mờ có thể mở rộng ra ngoài giới hạn gốc hay không. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Phần trăm không âm. Dùng `0` tới `100` cho việc thu phóng độ mờ thông thường: `0` hoàn toàn trong suốt và `100` giữ nguyên alpha hiện có. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` tới `100`, phần trăm độ mờ. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` tới `100`, phần trăm ngưỡng alpha. Giá trị dưới ngưỡng trở nên trong suốt; giá trị bằng hoặc trên ngưỡng trở nên mờ. |

Đối với điều chế alpha cố định, độ trong suốt và độ mờ là các khái niệm bổ sung. Ví dụ, độ trong suốt 35 % tương ứng với mức điều chế alpha là 65 %.

## **Áp Dụng Độ Sáng và Độ Tương Phản**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) trả về một thao tác [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/). Các thiết lập vô hướng được cung cấp khi tạo thao tác. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--) trả về các giá trị chỉ đọc đã được tính toán mà có thể kiểm tra hoặc ghi lại.

Ví dụ dưới đây tăng độ sáng lên 15 % và độ tương phản lên 20 %, sau đó hiển thị bản xem trước mà không thay đổi hình ảnh được nhúng:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) là một phần mở rộng hiệu ứng hình ảnh Office 2010 và ít di động hơn so với hiệu ứng luminance chuẩn DrawingML. Khi độ sáng và độ tương phản phải vẫn có thể chỉnh sửa sau một vòng quay PPTX, hãy sử dụng [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) và xác minh kết quả sau khi mở lại tệp. Phần giới hạn định dạng giải thích chi tiết hơn sự khác biệt này.

## **Áp Dụng Các Biến Đổi Màu Sắc**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung hình khác nhau mà tái sử dụng cùng một tài nguyên hình ảnh. Ví dụ dưới đây tạo năm khung và áp dụng màu xám, duotone, tint, điều chỉnh HSL và thay thế màu.

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `color1` ánh xạ các pixel tối, trong khi `color2` ánh xạ các pixel sáng. Điều này làm cho nó trở thành một ví dụ hữu ích về hiệu ứng có cài đặt phức tạp hơn một giá trị vô hướng duy nhất.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) thay thế màu của mọi pixel bằng một màu cố định trong khi bảo toàn alpha. Nó khác với [addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), thao tác này ánh xạ một màu nguồn sang một màu đích và phô bày cả định dạng màu nguồn và đích.

### **Áp Dụng Ngưỡng Độ Sáng**

Ngưỡng độ sáng có thể làm cho các dấu mờ trên trang quét dễ phân biệt hơn so với nền. [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) bảo toàn các mức xám trung gian. [addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) ánh xạ độ sáng thành đen hoặc trắng, trong khi [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) áp dụng một ngưỡng lên độ trong suốt.

Ngưỡng độ sáng dao động từ 0 % tới 100 %, bao gồm cả hai đầu. Các pixel dưới ngưỡng trở thành đen. Các pixel bằng hoặc trên ngưỡng trở thành trắng. Tăng ngưỡng sẽ làm nhiều sắc thái hơn chuyển thành màu đen vì chúng rơi dưới mức cắt.

Tải [grayscale-swatches.png](grayscale-swatches.png) về thư mục làm việc. Mỗi nhãn cho biết mức xám gốc trên thang 0 tới 255. Ví dụ đặt hình gốc cạnh hai bản sao và lưu ngưỡng của mỗi bản sao trong bản trình chiếu.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);
    
    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mở bản trình chiếu đầu ra trong PowerPoint để so sánh ba khung. Bảng mẫu mang nhãn 96 có khoảng 38 % độ sáng (96 trên 255). Nó chuyển thành trắng ở ngưỡng 20 % và thành đen ở ngưỡng 60 %.

![Các mẫu ảnh xám gốc cạnh kết quả đen-trắng ở ngưỡng độ sáng 20% và 60%](luminance-threshold.png)

## **Thêm Hiệu Ứng Làm Mờ, Độ Trong Suốt và Alpha**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) ảnh hưởng tới tất cả các kênh màu, bao gồm alpha. Đặt `grow` thành `true` khi cạnh mờ có thể mở rộng ra ngoài giới hạn hình ảnh gốc.

Đối với độ trong suốt đồng nhất, sử dụng [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Nó nhân mỗi giá trị alpha hiện có, vì vậy các pixel bán trong suốt vẫn giữ tỉ lệ khác nhau. [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) ngược lại gán một giá trị alpha cho mọi pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) chuyển đổi alpha thành hai mức dựa trên một ngưỡng.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Các thao tác alpha không có tham số khác bao gồm [addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), làm cho mọi alpha khác không trở nên hoàn toàn mờ; [addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), làm cho mọi alpha dưới 100 % trở nên hoàn toàn trong suốt; và [addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), thay đổi alpha thành `100% - alpha`.

## **Xây Dựng Chuỗi Hiệu Ứng Có Thứ Tự**

Mỗi phương thức `add...Effect` thêm một thao tác mới vào cuối bộ sưu tập. Trình render sử dụng bộ sưu tập như một pipeline có thứ tự: đầu ra của thao tác 0 trở thành đầu vào của thao tác 1, và cứ tiếp tục như vậy. Do vậy, cùng các thao tác nhưng ở thứ tự khác nhau có thể tạo ra hình ảnh khác.

Ví dụ, làm xám rồi nhuộm màu sẽ đầu tiên loại bỏ thông tin màu sắc và sau đó tô lại độ sáng đã được xử lý; nhuộm màu rồi làm xám sẽ lại loại bỏ màu nhuộm. Tương tự, thay thế alpha có thể ghi đè các giá trị alpha đã được tính bởi các thao tác trước, trong khi điều chế alpha bảo toàn sự khác biệt tương đối của chúng.

Ví dụ dưới đây xây dựng một chuỗi bốn thao tác, lưu dưới dạng PPTX, mở lại bản trình chiếu, kiểm tra cả loại thao tác và thứ tự của chúng, và render kết quả đã mở lại:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

Bộ sưu tập không áp đặt một ma trận tương thích nào giới hạn các thao tác màu, alpha và làm mờ thành các chuỗi riêng biệt. Chúng có thể được kết hợp, nhưng không phải lúc nào cũng hữu ích. Thay thế màu cố định loại bỏ biến thể RGB do các hiệu ứng màu trước tạo ra; làm xám sau duotone loại bỏ hai màu đã chọn; và các thao tác alpha ceiling, floor, replacement hoặc bi-level có thể bỏ đi chi tiết alpha được tạo ra trước. Hãy xây dựng chuỗi dựa trên trình tự xử lý pixel mong muốn thay vì coi các mục như các cờ định dạng không có thứ tự.

<!-- visual-explanation:image-transform-effects:start -->
[![Cùng một hình ảnh được chuyển qua làm xám rồi nhuộm màu, và nhuộm màu rồi làm xám. Hai hình ảnh xám cuối cùng có tông màu khác nhau.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)
<!-- visual-explanation:image-transform-effects:end -->

## **Kiểm Tra Các Giá Trị Có Thể Chỉnh Sửa và Hiệu Quả**

Một thao tác có thể chỉnh sửa là đối tượng được lưu trong `ISlidesPicture.getImageTransform`. Tùy thuộc vào hiệu ứng, nó có thể phô bày các thành viên có thể ghi trực tiếp. Ví dụ, [IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/) phô bày các giá trị `radius` và `grow` có thể ghi, [IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/) phô bày `amount` có thể ghi, và [IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/) phô bày `threshold` có thể ghi. Các hiệu ứng màu như [IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) phô bày các đối tượng [IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) có thể thay đổi.

Một số giao diện thao tác, bao gồm [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/), và [IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/), không phô bày các vô hướng tạo ra như thuộc tính có thể ghi. Để thay đổi các cài đặt đó, hãy xóa thao tác và thêm một thao tác thay thế ở vị trí cần thiết.

Dữ liệu hiệu quả trả về bởi `getEffective()` được tính toán và chỉ đọc. Nó hữu ích để giải quyết các màu phụ thuộc vào chủ đề và đọc các giá trị đã được chuẩn hoá mà trình render sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ dưới đây liệt kê chuỗi và kiểm tra các giá trị hiệu quả ở nơi API cung cấp chúng:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Các hiệu ứng không có tham số như làm xám, alpha ceiling và alpha inverse vẫn có một đối tượng dữ liệu hiệu quả, nhưng không có cài đặt vô hướng nào để in. Sự hiện diện và vị trí của chúng trong bộ sưu tập là thông tin quan trọng.

## **Xóa Hoặc Xóa Trống Các Biến Đổi Hình Ảnh**

Sử dụng [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) để xóa một thao tác theo chỉ mục. Vì các chỉ mục dịch chuyển sau khi xóa, hãy tìm mục tiêu trước và xóa nó sau khi liệt kê. Sử dụng [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--) để xóa toàn bộ chuỗi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Xóa hoặc xóa trống các biến đổi chỉ thay đổi định dạng hình ảnh. Nó không xóa, nén lại hoặc thay đổi tài nguyên [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) đã được tái sử dụng.

## **Xem Xét Định Dạng Bản Trình Chiếu và Đích Xuất**

Các biến đổi hình ảnh bắt nguồn từ DrawingML, vì vậy PPTX là định dạng chỉnh sửa ưa thích cho các chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi thao tác đều có tính di động giống nhau:

- Các thao tác DrawingML chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các thao tác alpha thông thường có khả năng tồn tại tốt nhất sau một vòng quay PPTX. Luôn mở lại tệp đã tạo và kiểm tra bộ sưu tập khi việc bảo lưu là yêu cầu.
- [BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) là một phần mở rộng Office 2010 chứ không phải thao tác luminance chuẩn DrawingML. Nó có thể được dùng cho việc render trong bộ nhớ, nhưng không được đảm bảo vẫn tồn tại dưới dạng [IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/) có thể chỉnh sửa sau khi lưu và mở lại PPTX. Ưu tiên sử dụng [addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) cho các điều chỉnh độ sáng và độ tương phản bền vững.
- Định dạng PPT nhị phân trước khi có mô hình hiệu ứng DrawingML đầy đủ. Lưu dưới dạng PPT có thể bỏ qua các thao tác không được hỗ trợ, giảm chuỗi xuống một tập hợp được hỗ trợ, hoặc xấp xỉ giao diện. Không nên dùng PPT làm định dạng xác minh cho một chuỗi chỉnh sửa phức tạp.
- Render sang PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các đầu ra hình ảnh khác áp dụng chuỗi được hỗ trợ vào giao diện render. Các đầu ra này không chứa một `IImageTransformOperationCollection` có thể chỉnh sửa; các định dạng raster làm phẳng kết quả thành pixel, và các xuất tài liệu/vector lưu trữ đại diện render riêng của chúng.
- Các hiệu ứng không làm cho một hình ảnh liên kết tự chứa. Render một hình ảnh liên kết vẫn phụ thuộc vào việc tài nguyên liên kết có sẵn khi bản trình chiếu được tải.

Các người tiêu thụ bản trình chiếu khác nhau có thể render các trường hợp biên khác nhau, đặc biệt khi kết hợp nhiều thao tác alpha hoặc lượng màu. Đối với đầu ra quan trọng, hãy kiểm tra cả vòng quay chỉnh sửa và định dạng xuất cuối cùng bằng cùng một phiên bản Aspose.Slides được dùng trong môi trường sản xuất.

## **Câu Hỏi Thường Gặp**

**Các hiệu ứng biến đổi hình ảnh có thay đổi dữ liệu hình ảnh được nhúng không?**

Không. Các thao tác thuộc về `ISlidesPicture` được dùng bởi vùng điền hình ảnh. Các byte `IPPImage` nền tảng vẫn không bị thay đổi.

**Hai khung hình sử dụng cùng một hình ảnh sẽ chia sẻ các hiệu ứng không?**

Không. Tái sử dụng một `IPPImage` tránh việc sao lập dữ liệu hình ảnh, nhưng mỗi khung hình thường có một `ISlidesPicture` và bộ sưu tập biến đổi riêng.

**Có thể kết hợp các hiệu ứng màu, làm mờ và alpha không?**

Có. Bộ sưu tập chấp nhận chúng trong một chuỗi có thứ tự. Hãy cân nhắc mỗi thao tác sẽ ảnh hưởng như thế nào tới đầu ra của thao tác trước, vì các thao tác thay thế và ngưỡng có thể loại bỏ chi tiết màu hoặc alpha đã có.

**Tại sao các giá trị hiệu quả lại chỉ đọc?**

Dữ liệu hiệu quả đại diện cho các giá trị đã được tính toán dùng cho việc render, bao gồm các màu đã được giải quyết. Chỉnh sửa thao tác lưu trong bộ sưu tập biến đổi ở nơi có thành viên có thể ghi; nếu không, hãy xóa nó và thêm một thao tác thay thế với các tham số tạo mới.

**Định dạng nào nên dùng để bảo lưu một chuỗi biến đổi?**

Sử dụng PPTX và xác minh tệp bằng cách mở lại. PPT cũ không thể biểu diễn toàn bộ mô hình hiệu ứng DrawingML, và các định dạng xuất render chỉ giữ lại giao diện chứ không có các thao tác biến đổi có thể chỉnh sửa.