---
title: Quản lý các hiệu ứng biến đổi ảnh trong bài thuyết trình trên Android
linktitle: Hiệu ứng Biến đổi Ảnh
type: docs
weight: 11
url: /vi/androidjava/image-transform-effects/
keywords:
- biến đổi ảnh
- hiệu ứng hình ảnh
- độ sáng
- độ tương phản
- đen trắng
- đôi màu
- tô màu
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
description: "Áp dụng, tạo chuỗi, kiểm tra, xóa và xác minh các hiệu ứng biến đổi ảnh cho các khung ảnh với Aspose.Slides cho Android bằng Java."
---
## **Tổng quan**

Aspose.Slides biểu diễn việc điều chỉnh ảnh dưới dạng một bộ sưu tập có thứ tự của các thao tác biến đổi ảnh. Đối với một khung ảnh, bắt đầu với [ISlidesPicture](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidespicture/) của khung và truy cập [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). Bộ [IImageTransformOperationCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xóa và xóa sạch các hiệu ứng mà không cần ghi lại lại các byte ảnh gốc.

Bài viết này minh họa quy trình hoàn chỉnh cho độ sáng và độ tương phản, biến đổi màu, làm mờ, trong suốt, chuỗi hiệu ứng theo thứ tự, giá trị hiệu quả, xóa, và xác minh vòng quay PPTX.

## **Hiểu Quyền Sở Hữu Hiệu Ứng và Tái Sử Dụng Ảnh**

Một tài nguyên ảnh và hình ảnh hiển thị nó là các đối tượng khác nhau:

- [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) lưu hoặc tham chiếu dữ liệu ảnh nguồn thuộc bài thuyết trình.
- [ISlidesPicture](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidespicture/) thuộc về một hình ảnh nền và tham chiếu tới tài nguyên ảnh đồng thời lưu bộ sưu tập biến đổi ảnh.
- [IPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipictureframe/) là hình dạng trên slide sở hữu phần nền ảnh liên quan, hình học, cài đặt cắt và các định dạng cấp khung khác.

Do đó, các thao tác biến đổi ảnh không sửa đổi các byte trong [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/). Khi cùng một `IPPImage` được truyền cho [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) hơn một lần, mỗi khung ảnh mới nhận được `ISlidesPicture` riêng và bộ sưu tập biến đổi riêng. Áp dụng hiệu ứng trắng đen trên một khung không làm các khung khác cũng trở thành trắng đen, dù tất cả đều tái sử dụng cùng một tài nguyên ảnh được nhúng.

Mô hình `ISlidesPicture.getImageTransform` cũng được sử dụng bởi các hình ảnh nền khác, chẳng hạn như hình dạng hoặc nền slide. Các ví dụ dưới đây tập trung vào khung ảnh.

## **Sử Dụng Các Dải Tham Số và Đơn Vị Hợp Lệ**

Các phương pháp được minh họa sử dụng các dải ngữ nghĩa và đơn vị sau. Giữ các giá trị trong các dải này ngay cả khi một phiên bản thư viện nào đó không từ chối ngay lập tức các giá trị ngoài phạm vi; định dạng bài thuyết trình đích có thể chuẩn hoá, bỏ qua hoặc từ chối dữ liệu không hợp lệ khi lưu hoặc khi PowerPoint mở tệp.

| Thao tác | Tham số | Phạm vi và đơn vị hợp lệ |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` đến `100`, phần trăm; `0` giữ thành phần không thay đổi. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Không có | Không có tham số số. Alpha không thay đổi. |
| [addDuotoneEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Hai màu cho pixel tối và sáng. Giá trị RGB và kênh alpha được `android.graphics.Color` sử dụng nằm trong khoảng `0` đến `255`. |
| [addTintEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Hue từ `0` (bao gồm) đến `360` (không bao gồm), tính bằng độ; amount từ `-100` đến `100`, phần trăm. |
| [addHSLEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Hue từ `0` (bao gồm) đến `360` (không bao gồm), tính bằng độ; saturation và luminance từ `-100` đến `100`, phần trăm. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Màu thay thế sử dụng giá trị kênh từ `0` đến `255`. Giá trị alpha hiện có không thay đổi. |
| [addBlurEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Bán kính không âm và đo bằng điểm; `grow` là Boolean điều khiển việc nội dung mờ có mở rộng ra ngoài biên gốc hay không. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Phần trăm không âm. Dùng `0` đến `100` cho việc thu giảm độ trong suốt thông thường: `0` là hoàn toàn trong suốt và `100` giữ nguyên alpha hiện có. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` đến `100`, phần trăm độ trong suốt. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` đến `100`, phần trăm ngưỡng alpha. Giá trị dưới ngưỡng trở nên trong suốt; giá trị bằng hoặc trên ngưỡng trở nên đục. |

Đối với điều chế alpha cố định, trong suốt và độ đục là hai mặt của cùng một vấn đề. Ví dụ, 35% trong suốt tương đương với mức điều chế alpha 65%.

## **Áp Dụng Độ Sáng và Độ Tương Phản**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) trả về một thao tác [IBrightnessContrast](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibrightnesscontrast/). Các thiết lập vô hướng của nó được cung cấp khi tạo thao tác. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) trả về các giá trị chỉ đọc đã được tính toán mà có thể được kiểm tra hoặc ghi log.

Ví dụ sau tăng độ sáng lên 15% và độ tương phản lên 20%, sau đó hiển thị bản xem trước mà không thay đổi ảnh nhúng:

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

[BrightnessContrast](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/brightnesscontrast/) là một phần mở rộng hiệu ứng ảnh Office 2010 và ít di động hơn so với hiệu ứng luminance chuẩn DrawingML. Khi độ sáng và độ tương phản cần phải có khả năng chỉnh sửa sau một vòng quay PPTX, hãy sử dụng [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) và xác minh kết quả sau khi mở lại tệp. Phần hạn chế định dạng giải thích chi tiết hơn về sự khác biệt này.

## **Áp Dụng Biến Đổi Màu Sắc**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung ảnh khác nhau mà tái sử dụng cùng một tài nguyên ảnh. Ví dụ dưới đây tạo năm khung và áp dụng hiệu ứng trắng đen, duotone, tint, điều chỉnh HSL và thay thế màu.

[IDuotone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iduotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `color1` ánh xạ các pixel tối, trong khi `color2` ánh xạ các pixel sáng. Đây là một ví dụ hữu ích về hiệu ứng có cài đặt phức tạp hơn một giá trị vô hướng duy nhất.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) thay thế màu của mỗi pixel bằng một màu cố định trong khi giữ nguyên alpha. Nó khác với [addColorChangeEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), phương pháp này ánh xạ một màu nguồn sang màu đích và cho phép cả hai định dạng màu nguồn và đích.

## **Thêm Hiệu Ứng Làm Mờ, Trong Suốt và Alpha**

[addBlurEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) ảnh hưởng đến mọi kênh màu, bao gồm alpha. Đặt `grow` thành `true` khi cạnh mờ có thể mở rộng ra ngoài biên gốc của ảnh.

Đối với trong suốt đồng nhất, hãy dùng [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Nó nhân mỗi giá trị alpha hiện có, vì vậy các pixel bán trong suốt vẫn giữ tỷ lệ khác nhau. [addAlphaReplaceEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) ngược lại gán một giá trị alpha cho tất cả pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) chuyển đổi alpha thành hai mức dựa trên một ngưỡng.

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

Các thao tác alpha không có tham số khác bao gồm [addAlphaCeilingEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) – làm mọi alpha khác 0 trở nên hoàn toàn đục; [addAlphaFloorEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) – làm mọi alpha dưới 100% hoàn toàn trong suốt; và [addAlphaInverseEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) – thay đổi alpha thành `100% - alpha`.

## **Xây Dựng Chuỗi Hiệu Ứng Có Thứ Tự**

Mỗi phương thức `add...Effect` thêm một thao tác mới vào cuối bộ sưu tập. Trình render sử dụng bộ sưu tập như một đường ống có thứ tự: đầu ra của thao tác 0 trở thành đầu vào của thao tác 1, và cứ như vậy. Do đó, cùng các thao tác nhưng sắp xếp thứ tự khác nhau có thể tạo ra hình ảnh khác nhau.

Ví dụ, trắng đen rồi tint sẽ đầu tiên loại bỏ thông tin màu sắc và sau đó tô lại độ sáng đã được tính; tint rồi trắng đen sẽ lại loại bỏ tint. Tương tự, việc thay thế alpha có thể ghi đè các giá trị alpha được tính bởi các thao tác trước, trong khi việc điều chế alpha giữ lại sự chênh lệch tương đối của chúng.

Ví dụ sau xây dựng một chuỗi bốn thao tác, lưu dưới dạng PPTX, mở lại bản thuyết trình, kiểm tra cả loại thao tác và thứ tự của chúng, và hiển thị kết quả đã mở lại:

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

Bộ sưu tập không áp đặt ma trận tương thích nào giới hạn các thao tác màu, alpha và blur thành các chuỗi riêng biệt. Chúng có thể được kết hợp, nhưng không phải mọi sự kết hợp đều hữu ích. Việc thay thế màu cố định sẽ loại bỏ sự biến đổi RGB do các hiệu ứng màu trước đó tạo ra; trắng đen sau duotone sẽ loại bỏ hai màu đã chọn; và các thao tác alpha ceiling, floor, replace hoặc bi-level có thể loại bỏ chi tiết alpha được tạo ra trước. Hãy xây dựng chuỗi dựa trên trình tự xử lý pixel mong muốn thay vì coi các mục như các cờ định dạng không thứ tự.

## **Kiểm Tra Giá Trị Có Thể Chỉnh Sửa và Giá Trị Hiệu Quả**

Một thao tác có thể chỉnh sửa là đối tượng được lưu trong `ISlidesPicture.getImageTransform`. Tùy thuộc vào hiệu ứng, nó có thể phơi bày các thành viên ghi được trực tiếp. Ví dụ, [IBlur](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iblur/) phơi bày các giá trị `radius` và `grow` có thể ghi, [IAlphaModulateFixed](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ialphamodulatefixed/) phơi bày `amount` có thể ghi, và [IAlphaBiLevel](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ialphabilevel/) phơi bày `threshold` có thể ghi. Các hiệu ứng màu như [IDuotone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iduotone/) phơi bày các đối tượng [IColorFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icolorformat/) có thể thay đổi.

Một số giao diện thao tác, bao gồm [IBrightnessContrast](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itint/), và [IAlphaReplace](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ialphareplace/), không phơi bày các vô hướng tạo ra dưới dạng thuộc tính ghi được. Để thay đổi các cài đặt này, hãy xóa thao tác và thêm một thao tác mới ở vị trí yêu cầu.

Dữ liệu hiệu quả trả về bởi `getEffective()` được tính toán và chỉ đọc. Nó hữu ích để giải quyết các màu phụ thuộc vào theme và đọc các giá trị đã chuẩn hoá mà trình render sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ sau liệt kê chuỗi và kiểm tra các giá trị hiệu quả ở những API cung cấp chúng:

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

Các hiệu ứng không có tham số như trắng đen, alpha ceiling và alpha inverse vẫn có đối tượng dữ liệu hiệu quả, nhưng không có cài đặt vô hướng để in ra. Sự tồn tại và vị trí của chúng trong bộ sưu tập là thông tin quan trọng.

## **Xóa Hoặc Xóa Sạch Các Biến Đổi Ảnh**

Sử dụng [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) để xóa một thao tác theo chỉ mục. Vì các chỉ mục thay đổi sau khi xóa, hãy tìm mục tiêu trước và xóa nó sau khi liệt kê. Sử dụng [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) để xóa toàn bộ chuỗi.

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

Việc xóa hoặc xóa sạch các biến đổi chỉ thay đổi định dạng hình ảnh. Nó không xóa, nén lại hoặc thay đổi tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ippimage/) đã được tái sử dụng.

## **Xem Xét Định Dạng Bài Thuyết Trình và Đích Xuất**

Các biến đổi ảnh có nguồn gốc từ DrawingML, vì vậy PPTX là định dạng chỉnh sửa ưu tiên cho chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi thao tác đều có tính di động giống nhau:

- Các thao tác DrawingML chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các thao tác alpha phổ biến có khả năng tồn tại cao nhất sau một vòng quay PPTX. Luôn mở lại tệp đã tạo và kiểm tra bộ sưu tập khi việc bảo tồn là yêu cầu.
- [BrightnessContrast](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/brightnesscontrast/) là một phần mở rộng Office 2010 chứ không phải thao tác luminance DrawingML chuẩn. Nó có thể dùng cho việc render trong bộ nhớ, nhưng không được đảm bảo vẫn tồn tại dưới dạng [IBrightnessContrast](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibrightnesscontrast/) có thể chỉnh sửa sau khi lưu và mở lại PPTX. Nên ưu tiên [addLuminanceEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) cho các điều chỉnh độ sáng và độ tương phản bền vững.
- Định dạng PPT nhị phân xuất hiện trước mô hình hiệu ứng DrawingML đầy đủ. Lưu dưới dạng PPT có thể bỏ qua các thao tác không hỗ trợ, giảm chuỗi thành một tập con hỗ trợ, hoặc xấp xỉ hiển thị. Không dùng PPT làm định dạng xác minh cho một chuỗi chỉnh sửa phức tạp.
- Render ra PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các đầu ra hình ảnh khác áp dụng chuỗi được hỗ trợ lên hình ảnh cuối cùng. Các đầu ra này không chứa một `IImageTransformOperationCollection` có thể chỉnh sửa; định dạng raster làm phẳng kết quả thành các pixel, và các xuất khẩu tài liệu/vector lưu trữ biểu diễn render riêng của chúng.
- Các hiệu ứng không khiến một ảnh liên kết tự chứa. Render một ảnh liên kết vẫn phụ thuộc vào việc tài nguyên liên kết có sẵn khi bài thuyết trình được tải.

Các trình tiêu thụ bản thuyết trình khác nhau có thể render các trường hợp biên khác nhau, đặc biệt khi nhiều thao tác alpha hoặc giảm màu được kết hợp. Đối với đầu ra quan trọng, hãy kiểm tra cả vòng quay chỉnh sửa và định dạng xuất cuối cùng bằng cùng một phiên bản Aspose.Slides được dùng trong môi trường sản xuất.

## **Câu Hỏi Thường Gặp**

**Các hiệu ứng biến đổi ảnh có sửa đổi dữ liệu ảnh được nhúng không?**

Không. Các thao tác thuộc về `ISlidesPicture` được sử dụng bởi nền ảnh. Các byte `IPPImage` nền vẫn không thay đổi.

**Hai khung ảnh tái sử dụng cùng một ảnh có chia sẻ hiệu ứng không?**

Không. Tái sử dụng một `IPPImage` giúp tránh trùng lặp dữ liệu ảnh, nhưng mỗi khung ảnh thường có một `ISlidesPicture` và bộ sưu tập biến đổi ảnh riêng.

**Có thể kết hợp các hiệu ứng màu, blur và alpha không?**

Có. Bộ sưu tập cho phép chúng trong một chuỗi có thứ tự. Hãy cân nhắc mỗi thao tác ảnh hưởng như thế nào tới kết quả của thao tác trước, vì các thao tác thay thế và ngưỡng có thể loại bỏ chi tiết màu hoặc alpha đã tạo.

**Tại sao các giá trị hiệu quả lại chỉ đọc?**

Dữ liệu hiệu quả đại diện cho các giá trị đã được tính toán dùng cho việc render, bao gồm các màu đã giải quyết. Chỉnh sửa thao tác lưu trong bộ sưu tập biến đổi ở nơi có thành viên ghi được; nếu không, hãy xóa và thêm một thao tác thay thế với các tham số tạo mới.

**Định dạng nào nên dùng để bảo tồn một chuỗi biến đổi?**

Dùng PPTX và xác minh tệp bằng cách mở lại. PPT cổ không thể biểu diễn toàn bộ mô hình hiệu ứng DrawingML, và các định dạng xuất như PNG, PDF chỉ lưu giữ ngoại hình mà không giữ lại các thao tác biến đổi có thể chỉnh sửa.