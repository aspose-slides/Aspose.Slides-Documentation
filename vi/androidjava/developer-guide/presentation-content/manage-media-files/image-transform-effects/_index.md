---
title: Quản lý các hiệu ứng biến đổi ảnh trong bài thuyết trình trên Android
linktitle: Hiệu ứng biến đổi ảnh
type: docs
weight: 11
url: /vi/androidjava/image-transform-effects/
keywords:
- biến đổi ảnh
- hiệu ứng hình ảnh
- độ sáng
- độ tương phản
- xám
- đôi tone
- tông màu
- HSL
- thay thế màu
- làm mờ
- độ trong suốt
- hiệu ứng alpha
- chuỗi hiệu ứng
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Áp dụng, chuỗi, kiểm tra, xóa và xác minh các hiệu ứng biến đổi ảnh cho khung hình ảnh với Aspose.Slides cho Android qua Java."
---
## **Tổng quan**

Aspose.Slides biểu diễn các điều chỉnh hình ảnh dưới dạng một tập hợp có thứ tự của các hoạt động biến đổi hình ảnh. Đối với một khung hình ảnh, bắt đầu với [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) của khung và truy cập [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xóa và xóa sạch các hiệu ứng mà không cần ghi lại lại các byte ảnh gốc.

Bài viết này trình bày một quy trình hoàn chỉnh cho độ sáng và độ tương phản, các biến đổi màu, làm mờ, độ trong suốt, chuỗi hiệu ứng có thứ tự, giá trị thực tế, việc xóa bỏ, và xác minh vòng quay PPTX.

## **Hiểu Quyền Sở Hữu Hiệu Ứng và Việc Tái Sử Dụng Hình Ảnh**

Một tài nguyên ảnh và hình ảnh hiển thị nó là các đối tượng khác nhau:

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) lưu trữ hoặc tham chiếu dữ liệu ảnh nguồn thuộc bài thuyết trình.
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) thuộc về một nền ảnh và tham chiếu tài nguyên ảnh đồng thời lưu trữ tập hợp các biến đổi ảnh.
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) là hình dạng trên slide sở hữu nền ảnh liên quan, hình học, thiết lập cắt và các định dạng mức khung khác.

Do đó, các hoạt động biến đổi ảnh không làm thay đổi các byte trong [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/). Khi cùng một `IPPImage` được truyền cho [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) hơn một lần, mỗi khung ảnh mới sẽ nhận được `ISlidesPicture` và tập hợp biến đổi riêng. Áp dụng chuyển đổi xám cho một khung không làm các khung khác cũng trở nên xám, dù chúng đều tái sử dụng cùng một tài nguyên ảnh nhúng.

Mô hình `ISlidesPicture.getImageTransform` cũng được sử dụng cho các nền ảnh khác, như nền hình dạng hoặc nền slide. Các ví dụ dưới đây tập trung vào các khung ảnh.

## **Sử Dụng Phạm Vi Tham Số và Đơn Vị Hợp Lệ**

Các phương thức được minh họa sử dụng các phạm vi ngữ nghĩa và đơn vị sau. Giữ các giá trị trong phạm vi này ngay cả khi một phiên bản thư viện cụ thể không từ chối ngay các giá trị vượt phạm vi; định dạng bài thuyết trình đích có thể chuẩn hoá, bỏ qua hoặc từ chối dữ liệu không hợp lệ trong quá trình lưu hoặc khi PowerPoint mở tệp.

| Hoạt động | Tham số | Phạm vi và đơn vị hợp lệ |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` tới `100`, phần trăm; `0` giữ thành phần không đổi. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Không có | Không có tham số số. Alpha không thay đổi. |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Hai màu cho các pixel tối và sáng. Giá trị kênh RGB và alpha do `android.graphics.Color` sử dụng nằm trong khoảng `0` tới `255`. |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Hue từ `0` (bao gồm) tới `360` (không bao gồm), đơn vị độ; amount từ `-100` tới `100`, phần trăm. |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Hue từ `0` (bao gồm) tới `360` (không bao gồm), đơn vị độ; saturation và luminance từ `-100` tới `100`, phần trăm. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Màu thay thế sử dụng các giá trị kênh từ `0` tới `255`. Giá trị alpha hiện tại không thay đổi. |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Bán kính không âm và đo bằng điểm; `grow` là Boolean điều khiển việc nội dung bị làm mờ có thể mở rộng ra ngoài giới hạn gốc hay không. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Phần trăm không âm. Dùng `0` tới `100` cho việc thay đổi độ mờ thông thường: `0` là hoàn toàn trong suốt và `100` giữ nguyên alpha hiện có. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` tới `100`, phần trăm độ mờ. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` tới `100`, phần trăm ngưỡng alpha. Giá trị dưới ngưỡng trở nên trong suốt; giá trị bằng hoặc trên ngưỡng trở nên không trong suốt. |

Đối với việc điều chế alpha cố định, độ trong suốt và độ mờ là các khái niệm bổ trợ nhau. Ví dụ, độ trong suốt 35 % tương ứng với mức điều chế alpha là 65 %.

## **Áp Dụng Độ Sáng và Độ Tương Phản**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) trả về một đối tượng thao tác [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/). Các thiết lập vô hướng được cung cấp khi tạo thao tác. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) trả về các giá trị chỉ đọc đã được tính toán mà có thể kiểm tra hoặc ghi log.

Ví dụ dưới đây tăng độ sáng lên 15 % và độ tương phản lên 20 %, sau đó hiển thị bản xem trước mà không thay đổi ảnh nhúng:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
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

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) là một phần mở rộng hiệu ứng hình ảnh của Office 2010 và ít di động hơn so với hiệu ứng luminance chuẩn DrawingML. Khi cần giữ độ sáng và độ tương phản có thể chỉnh sửa sau một vòng quay PPTX, hãy dùng [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) và xác minh kết quả sau khi mở lại tệp. Phần giới hạn định dạng giải thích sự khác biệt này chi tiết hơn.

## **Áp Dụng Các Biến Đổi Màu**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung ảnh khác nhau mà cùng tái sử dụng một tài nguyên ảnh. Ví dụ dưới đây tạo năm khung và áp dụng chuyển đổi xám, duotone, tint, điều chỉnh HSL và thay thế màu.

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `color1` ánh xạ các pixel tối, trong khi `color2` ánh xạ các pixel sáng. Điều này làm cho nó trở thành một ví dụ hữu ích của một hiệu ứng có cài đặt phức tạp hơn một giá trị vô hướng đơn.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) thay thế màu của mọi pixel bằng một màu cố định trong khi giữ nguyên alpha. Nó khác với [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), cái mà ánh xạ một màu nguồn sang màu đích và cho phép cả định dạng màu nguồn và đích.

### **Áp Dụng Ngưỡng Luminance**

Một ngưỡng luminance có thể làm cho các dấu nhẹ trên trang quét dễ phân biệt hơn so với nền. [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) giữ lại các sắc thái xám trung gian. [addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) ánh xạ luminance thành màu đen hoặc trắng, trong khi [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) áp dụng ngưỡng lên độ trong suốt.

Ngưỡng luminance nằm trong khoảng từ 0 % tới 100 %, bao gồm cả hai đầu. Các pixel dưới ngưỡng trở thành màu đen. Các pixel bằng hoặc trên ngưỡng trở thành màu trắng. Tăng ngưỡng sẽ làm nhiều sắc thái hơn chuyển thành màu đen vì chúng rơi xuống dưới mức cắt.

Tải về [grayscale-swatches.png](grayscale-swatches.png) vào thư mục làm việc. Mỗi nhãn cho biết mức xám gốc trên thang từ 0 tới 255. Ví dụ đặt bản gốc cạnh hai bản sao và lưu ngưỡng của mỗi bản sao vào bài thuyết trình.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

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

Mở bài thuyết trình đầu ra trong PowerPoint để so sánh ba khung. Bản mẫu có nhãn 96 có khoảng 38 % luminance (96 trên 255). Nó chuyển thành trắng ở ngưỡng 20 % và thành đen ở ngưỡng 60 %.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Thêm Hiệu Ứng Làm Mờ, Độ Trong Suốt và Alpha**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) ảnh hưởng đến tất cả các kênh màu, bao gồm cả alpha. Đặt `grow` thành `true` khi cạnh bị làm mờ có thể mở rộng ra ngoài giới hạn hình ảnh gốc.

Đối với độ trong suốt đồng nhất, sử dụng [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Nó nhân mỗi giá trị alpha hiện có, vì vậy các pixel bán trong suốt vẫn giữ tỷ lệ khác nhau. [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) thay vào đó gán một giá trị alpha cho mọi pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) chuyển đổi alpha thành hai mức dựa trên một ngưỡng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

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

Các thao tác alpha không có tham số khác bao gồm [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) (đặt mọi alpha khác 0 thành hoàn toàn không trong suốt), [addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) (đặt mọi alpha dưới 100 % thành hoàn toàn trong suốt), và [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) (đổi alpha thành `100% - alpha`).

## **Xây Dựng Chuỗi Hiệu Ứng Có Thứ Tự**

Mỗi phương thức `add...Effect` thêm một thao tác mới vào cuối tập hợp. Bộ dựng hình sử dụng tập hợp như một đường ống có thứ tự: đầu ra của thao tác 0 trở thành đầu vào của thao tác 1, và cứ tiếp tục như vậy. Do đó, cùng các thao tác nhưng sắp xếp khác nhau có thể tạo ra hình ảnh khác.

Ví dụ, chuyển đổi xám rồi tint sẽ đầu tiên loại bỏ thông tin màu và sau đó tái màu kết quả luminance. Tint rồi chuyển đổi xám sẽ lại loại bỏ tint. Tương tự, thay thế alpha có thể ghi đè các giá trị alpha đã tính bởi các thao tác trước, trong khi điều chế alpha giữ lại sự khác biệt tương đối của chúng.

Ví dụ dưới đây xây dựng một chuỗi bốn thao tác, lưu dưới dạng PPTX, mở lại bài thuyết trình, kiểm tra cả kiểu thao tác và thứ tự của chúng, và hiển thị kết quả đã mở lại:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
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

Tập hợp không áp đặt một ma trận tương thích hạn chế các thao tác màu, alpha và làm mờ thành các chuỗi riêng biệt. Chúng có thể được kết hợp, nhưng không phải lúc nào cũng hữu ích. Thay thế màu cố định loại bỏ sự biến đổi RGB do các hiệu ứng màu trước tạo ra; chuyển đổi xám sau duotone loại bỏ hai màu đã chọn; các thao tác alpha ceiling, floor, replace hoặc bi‑level có thể loại bỏ chi tiết alpha được tạo ra trước. Hãy xây dựng chuỗi theo thứ tự xử lý pixel mong muốn thay vì xem các mục như những cờ định dạng không thứ tự.


<!-- visual-explanation:image-transform-effects:start -->
[![Cùng một hình ảnh đi qua chuyển đổi xám rồi tint, và tint rồi chuyển đổi xám. Hai hình ảnh xám cuối cùng có tông màu khác nhau.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Trong minh họa này của Aspose.Slides for .NET 26.11, một tint 220° ở mức 25 % không làm thay đổi hình ảnh xám. Áp dụng cùng một tint trước khi chuyển đổi xám tạo ra các tông màu khác nhau.*
<!-- visual-explanation:image-transform-effects:end -->

## **Kiểm Tra Các Giá Trị Có Thể Chỉnh Sửa và Giá Trị Thực Tế**

Một thao tác có thể chỉnh sửa là đối tượng được lưu trong `ISlidesPicture.getImageTransform`. Tùy thuộc vào hiệu ứng, nó có thể mở ra các thành viên ghi được trực tiếp. Ví dụ, [IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) cho phép ghi các giá trị `radius` và `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) cho phép ghi `amount`, và [IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) cho phép ghi `threshold`. Các hiệu ứng màu như [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) cung cấp các đối tượng [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) có thể thay đổi.

Một số giao diện thao tác, bao gồm [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/), và [IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/), không công khai các tham số khởi tạo dưới dạng thuộc tính ghi được. Để thay đổi các thiết lập này, hãy xóa thao tác và thêm một thao tác mới ở vị trí mong muốn.

Dữ liệu thực tế trả về bởi `getEffective()` được tính toán và chỉ đọc. Nó hữu ích để giải quyết các màu phụ thuộc vào chủ đề và đọc các giá trị đã chuẩn hoá mà bộ dựng sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ dưới đây liệt kê chuỗi và kiểm tra các giá trị thực tế nơi API cung cấp chúng:

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

Các hiệu ứng không có tham số như chuyển đổi xám, alpha ceiling và alpha inverse vẫn có đối tượng dữ liệu thực tế, nhưng không có cài đặt vô hướng nào để in ra. Sự hiện diện và vị trí của chúng trong tập hợp là thông tin quan trọng.

## **Xóa Hoặc Xóa Sạch Các Biến Đổi Ảnh**

Sử dụng [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) để xóa một thao tác theo chỉ mục. Vì các chỉ mục thay đổi sau khi xóa, hãy tìm mục tiêu trước và xóa sau khi liệt kê. Dùng [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) để xóa toàn bộ chuỗi.

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

Việc xóa hoặc xóa sạch các biến đổi chỉ thay đổi định dạng ảnh. Nó không xóa, nén lại, hay thay đổi tài nguyên [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) đã được tái sử dụng.

## **Xem Xét Định Dạng Bài Thuyết Trình và Đích Xuất**

Các biến đổi ảnh xuất phát từ DrawingML, vì vậy PPTX là định dạng chỉnh sửa ưu tiên cho các chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi thao tác đều có cùng mức độ di động:

- Các thao tác DrawingML chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các thao tác alpha phổ biến có khả năng tồn tại cao nhất sau một vòng quay PPTX. Luôn mở lại tệp đã tạo và kiểm tra tập hợp khi việc bảo tồn là yêu cầu.
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) là một phần mở rộng của Office 2010 thay vì thao tác luminance DrawingML chuẩn. Nó có thể dùng cho việc dựng hình trong bộ nhớ, nhưng không được đảm bảo vẫn tồn tại dưới dạng [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) có thể chỉnh sửa sau khi lưu và mở lại PPTX. Nên ưu tiên [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) cho các điều chỉnh độ sáng và độ tương phản bền vững.
- Định dạng PPT nhị phân tồn tại trước mô hình hiệu ứng DrawingML đầy đủ. Lưu sang PPT có thể bỏ qua các thao tác không hỗ trợ, giảm chuỗi về một tập con được hỗ trợ, hoặc xấp xỉ hình ảnh. Không nên dùng PPT làm định dạng xác minh cho một chuỗi chỉnh sửa phức tạp.
- Đầu ra hình ảnh như PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các định dạng trực quan khác áp dụng chuỗi đã hỗ trợ vào kết quả hiển thị. Những đầu ra này không chứa `IImageTransformOperationCollection` có thể chỉnh sửa; các định dạng raster làm phẳng kết quả thành pixel, và các xuất khẩu tài liệu/vector lưu trữ biểu diễn dựng hình riêng của chúng.
- Các hiệu ứng không làm cho ảnh liên kết tự chứa. Việc dựng một hình ảnh liên kết vẫn phụ thuộc vào tài nguyên liên kết có sẵn khi bài thuyết trình được tải.

Các trình đọc bài thuyết trình khác nhau có thể dựng các trường hợp biên khác nhau, đặc biệt khi kết hợp nhiều thao tác alpha hoặc giảm màu. Đối với đầu ra quan trọng, hãy kiểm tra cả vòng quay chỉnh sửa và định dạng xuất cuối cùng bằng cùng một phiên bản Aspose.Slides được dùng trong môi trường sản xuất.

## **Câu Hỏi Thường Gặp**

**Các hiệu ứng biến đổi ảnh có thay đổi dữ liệu ảnh nhúng không?**

Không. Các thao tác thuộc về `ISlidesPicture` được sử dụng bởi nền ảnh. Các byte `IPPImage` cơ sở không bị thay đổi.

**Hai khung ảnh tái sử dụng cùng một ảnh có chia sẻ hiệu ứng không?**

Không. Tái sử dụng một `IPPImage` tránh trùng lặp dữ liệu ảnh, nhưng mỗi khung ảnh thường có một `ISlidesPicture` và tập hợp biến đổi ảnh riêng.

**Có thể kết hợp các hiệu ứng màu, làm mờ và alpha không?**

Có. Tập hợp cho phép chúng trong một chuỗi có thứ tự. Hãy cân nhắc ảnh hưởng của mỗi thao tác lên đầu ra của thao tác trước, vì các thao tác thay thế và ngưỡng có thể loại bỏ chi tiết màu hoặc alpha đã có.

**Tại sao các giá trị thực tế chỉ đọc?**

Dữ liệu thực tế đại diện cho các giá trị đã tính toán dùng cho việc dựng hình, bao gồm cả màu đã giải quyết. Chỉnh sửa thao tác lưu trong tập hợp biến đổi tại nơi có thành viên ghi được; nếu không, hãy xóa và thêm một thao tác mới với các tham số khởi tạo mới.

**Định dạng nào nên dùng để giữ nguyên chuỗi biến đổi?**

Sử dụng PPTX và xác minh tệp bằng cách mở lại. PPT cổ không thể biểu diễn mô hình hiệu ứng DrawingML đầy đủ, và các định dạng xuất hình chỉ giữ lại giao diện chứ không giữ lại các thao tác biến đổi có thể chỉnh sửa.