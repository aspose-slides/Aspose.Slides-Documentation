---
title: Quản lý các hiệu ứng biến đổi hình ảnh trong bản trình bày bằng Java
linktitle: Các hiệu ứng biến đổi hình ảnh
type: docs
weight: 11
url: /vi/java/image-transform-effects/
keywords:
- biến đổi hình ảnh
- hiệu ứng hình ảnh
- độ sáng
- độ tương phản
- màu xám
- đôi màu
- tô màu
- HSL
- thay thế màu
- làm mờ
- độ trong suốt
- hiệu ứng alpha
- chuỗi hiệu ứng
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Áp dụng, xâu chuỗi, kiểm tra, xóa và xác minh các hiệu ứng biến đổi hình ảnh cho khung hình ảnh bằng Aspose.Slides cho Java."
---
## **Tổng quan**

Aspose.Slides đại diện cho việc điều chỉnh hình ảnh dưới dạng một bộ sưu tập có thứ tự của các thao tác biến đổi hình ảnh. Đối với một khung hình ảnh, bắt đầu với [ISlidesPicture](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidespicture/) của khung và truy cập [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidespicture/#getImageTransform--). Bộ [IImageTransformOperationCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xóa và xóa toàn bộ các hiệu ứng mà không cần ghi lại lại các byte ảnh gốc.

Bài viết này trình bày quy trình làm việc đầy đủ cho độ sáng/độ tương phản, chuyển đổi màu, làm mờ, trong suốt, chuỗi hiệu ứng có thứ tự, giá trị hiệu quả, xóa bỏ và xác minh vòng quay PPTX.

## **Hiểu quyền sở hữu hiệu ứng và việc tái sử dụng ảnh**

Một tài nguyên ảnh và hình ảnh hiển thị nó là các đối tượng khác nhau:

- [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) lưu trữ hoặc tham chiếu dữ liệu ảnh nguồn thuộc bản trình bày.
- [ISlidesPicture](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidespicture/) thuộc về một hình ảnh nền và tham chiếu tài nguyên ảnh đồng thời lưu trữ bộ sưu tập biến đổi ảnh.
- [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) là hình dạng trên slide sở hữu phần nền hình ảnh, hình học, cài đặt cắt và các định dạng cấp khung khác.

Do đó, các thao tác biến đổi ảnh không thay đổi các byte trong [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/). Khi cùng một `IPPImage` được truyền vào [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) hơn một lần, mỗi khung hình mới sẽ nhận được `ISlidesPicture` và bộ sưu tập biến đổi riêng. Áp dụng chuyển đổi màu xám cho một khung sẽ không làm các khung khác cũng chuyển sang màu xám, ngay cả khi tất cả chúng đều sử dụng chung tài nguyên ảnh đã nhúng.

Mô hình `ISlidesPicture.getImageTransform` tương tự cũng được sử dụng cho các nền ảnh khác, chẳng hạn như hình dạng hoặc nền slide. Các ví dụ dưới đây tập trung vào khung hình ảnh.

## **Sử dụng phạm vi tham số và đơn vị hợp lệ**

Các phương pháp được minh họa sử dụng các phạm vi và đơn vị ngữ nghĩa sau. Giữ các giá trị trong phạm vi này ngay cả khi một phiên bản thư viện cụ thể không từ chối ngay lập tức các giá trị ngoài phạm vi; định dạng bản trình bày đích có thể chuẩn hoá, bỏ qua hoặc từ chối dữ liệu không hợp lệ khi lưu hoặc khi PowerPoint mở tệp.

| Hoạt động | Tham số | Phạm vi và đơn vị hợp lệ |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` đến `100`, phần trăm; `0` giữ nguyên thành phần. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Không có | Không có tham số số. Alpha không thay đổi. |
| [addDuotoneEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Hai màu cho các pixel tối và sáng. Các kênh RGB và alpha trong `java.awt.Color` sử dụng giá trị `0` đến `255`. |
| [addTintEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Hue từ `0` (bao gồm) đến `360` (không bao gồm), đơn vị độ; amount từ `-100` đến `100`, phần trăm. |
| [addHSLEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Hue từ `0` (bao gồm) đến `360` (không bao gồm), đơn vị độ; saturation và luminance từ `-100` đến `100`, phần trăm. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | Màu thay thế sử dụng các giá trị kênh từ `0` đến `255`. Giá trị alpha hiện có không thay đổi. |
| [addBlurEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Radius không âm và đo bằng điểm; `grow` là Boolean điều khiển liệu nội dung bị làm mờ có thể mở rộng ra ngoài giới hạn gốc hay không. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Phần trăm không âm. Dùng `0` đến `100` cho việc điều chỉnh độ mờ thông thường: `0` là hoàn toàn trong suốt và `100` giữ nguyên alpha hiện có. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` đến `100`, phần trăm độ mờ. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` đến `100`, phần trăm ngưỡng alpha. Giá trị dưới ngưỡng trở nên trong suốt; giá trị bằng hoặc trên ngưỡng trở nên mờ. |

Đối với việc điều chỉnh alpha cố định, trong suốt và độ mờ là hai khái niệm bổ sung nhau. Ví dụ, độ trong suốt 35 % tương đương với mức điều chỉnh alpha 65 %.

## **Áp dụng độ sáng và độ tương phản**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) trả về một thao tác [IBrightnessContrast](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibrightnesscontrast/). Các thiết lập vô hướng của nó được cung cấp khi tạo thao tác. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) trả về các giá trị chỉ đọc đã được tính toán mà có thể kiểm tra hoặc ghi lại.

Ví dụ sau tăng độ sáng lên 15 % và độ tương phản lên 20 %, sau đó hiển thị bản xem trước mà không thay đổi ảnh đã nhúng:

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

[BrightnessContrast](https://reference.aspose.com/slides/vi/java/com.aspose.slides/brightnesscontrast/) là một phần mở rộng hiệu ứng ảnh Office 2010 và không di động bằng hiệu ứng luminance chuẩn DrawingML. Khi cần giữ khả năng chỉnh sửa độ sáng/độ tương phản sau vòng quay PPTX, hãy sử dụng [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) và xác minh kết quả sau khi mở lại tệp. Phần giới hạn định dạng giải thích chi tiết hơn về sự khác biệt này.

## **Áp dụng chuyển đổi màu**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung hình ảnh khác nhau sử dụng chung một tài nguyên ảnh. Ví dụ dưới đây tạo năm khung và áp dụng các hiệu ứng màu xám, duotone, tint, điều chỉnh HSL và thay thế màu.

[IDuotone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iduotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `color1` gán cho các pixel tối, trong khi `color2` gán cho các pixel sáng. Điều này làm cho nó trở thành một ví dụ hữu ích về một hiệu ứng có cài đặt phức tạp hơn một giá trị vô hướng duy nhất.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) thay thế màu của mọi pixel bằng một màu cố định trong khi giữ nguyên alpha. Nó khác với [addColorChangeEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), thứ mà ánh xạ một màu nguồn sang màu đích và cho phép cả hai định dạng màu nguồn và đích.

## **Thêm làm mờ, trong suốt và hiệu ứng Alpha**

[addBlurEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) ảnh hưởng đến tất cả các kênh màu, bao gồm cả alpha. Đặt `grow` thành `true` khi cạnh bị làm mờ có thể mở rộng ra ngoài giới hạn hình ảnh gốc.

Đối với độ trong suốt đồng nhất, sử dụng [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Nó nhân mỗi giá trị alpha hiện có, vì vậy các pixel bán trong suốt vẫn giữ tỷ lệ khác nhau. [addAlphaReplaceEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) thay vào đó gán một giá trị alpha duy nhất cho tất cả các pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) chuyển đổi alpha thành hai mức dựa trên ngưỡng.

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

Các thao tác alpha không có tham số khác bao gồm [addAlphaCeilingEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), làm cho mọi alpha khác không bằng 0 trở nên hoàn toàn mờ; [addAlphaFloorEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), làm cho mọi alpha dưới 100 % hoàn toàn trong suốt; và [addAlphaInverseEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), chuyển đổi alpha thành `100% - alpha`.

## **Xây dựng chuỗi hiệu ứng có thứ tự**

Mỗi phương thức `add...Effect` thêm một thao tác mới vào cuối bộ sưu tập. Bộ dựng hình sử dụng bộ sưu tập như một pipeline có thứ tự: đầu ra của thao tác 0 trở thành đầu vào của thao tác 1, cứ như vậy. Vì vậy, cùng một tập hợp các thao tác nhưng sắp xếp khác nhau có thể tạo ra hình ảnh khác nhau.

Ví dụ, chuyển đổi màu xám rồi tint sẽ đầu tiên loại bỏ thông tin sắc màu và sau đó tái tạo màu cho kết quả luminance. Tint rồi màu xám lại loại bỏ tint. Tương tự, việc thay thế alpha có thể ghi đè các giá trị alpha được tính bởi các thao tác trước, trong khi điều chỉnh alpha bảo tồn các chênh lệch tương đối của chúng.

Ví dụ dưới đây xây dựng một chuỗi bốn thao tác, lưu dưới dạng PPTX, mở lại bản trình bày, kiểm tra cả kiểu thao tác và thứ tự của chúng, và hiển thị kết quả đã mở lại:

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

Bộ sưu tập không áp đặt ma trận tương thích nào buộc các thao tác màu, alpha và làm mờ phải nằm trong các chuỗi riêng biệt. Chúng có thể được kết hợp, nhưng không phải lúc nào cũng hữu ích. Việc thay thế màu cố định sẽ xóa bỏ sự biến đổi RGB do các hiệu ứng màu trước đó tạo ra; màu xám sau duotone sẽ xóa bỏ hai màu đã chọn; và các thao tác alpha ceiling, floor, replacement hoặc bi‑level có thể loại bỏ chi tiết alpha được tạo ra trước đó. Hãy xây dựng chuỗi dựa trên trình tự xử lý pixel mong muốn thay vì coi các mục trong đó là các cờ định dạng không có thứ tự.

## **Kiểm tra giá trị có thể chỉnh sửa và giá trị hiệu quả**

Một thao tác có thể chỉnh sửa là đối tượng được lưu trong `ISlidesPicture.getImageTransform`. Tùy vào hiệu ứng, nó có thể trực tiếp phơi bày các thành viên có thể ghi. Ví dụ, [IBlur](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iblur/) phơi bày các giá trị `radius` và `grow` có thể ghi, [IAlphaModulateFixed](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ialphamodulatefixed/) phơi bày `amount` có thể ghi, và [IAlphaBiLevel](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ialphabilevel/) phơi bày `threshold` có thể ghi. Các hiệu ứng màu như [IDuotone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iduotone/) phơi bày các đối tượng [IColorFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icolorformat/) có thể thay đổi.

Một số giao diện thao tác, bao gồm [IBrightnessContrast](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itint/), và [IAlphaReplace](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ialphareplace/), không phơi bày các tham số tạo dưới dạng thuộc tính có thể ghi. Để thay đổi các cài đặt này, hãy xóa thao tác và thêm một thao tác thay thế tại vị trí mong muốn.

Dữ liệu hiệu quả trả về bởi `getEffective()` được tính toán và chỉ đọc. Nó hữu ích cho việc giải quyết các màu phụ thuộc vào chủ đề và đọc các giá trị đã chuẩn hoá mà bộ dựng hình sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ dưới đây liệt kê chuỗi và kiểm tra các giá trị hiệu quả ở nơi API cung cấp chúng:

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

Các hiệu ứng không có tham số như grayscale, alpha ceiling và alpha inverse vẫn có đối tượng dữ liệu hiệu quả, nhưng không có cài đặt vô hướng nào để in ra. Sự hiện diện và vị trí của chúng trong bộ sưu tập là thông tin quan trọng.

## **Xóa hoặc xóa toàn bộ các biến đổi ảnh**

Sử dụng [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) để xóa một thao tác theo chỉ mục. Vì các chỉ mục sẽ dịch chuyển sau khi xóa, hãy tìm mục tiêu trước và xóa nó sau khi liệt kê. Sử dụng [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imagetransformoperationcollection/#clear--) để xóa toàn bộ chuỗi.

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

Xóa hoặc xóa toàn bộ các biến đổi chỉ thay đổi định dạng của hình ảnh. Nó không xóa, nén lại hoặc thay đổi tài nguyên [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) đã được tái sử dụng.

## **Xem xét định dạng bản trình bày và các mục tiêu xuất**

Biến đổi ảnh bắt nguồn từ DrawingML, vì vậy PPTX là định dạng chỉnh sửa ưa thích cho các chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi thao tác đều có tính di động giống nhau:

- Các thao tác DrawingML chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các thao tác alpha chung có khả năng tồn tại tốt nhất sau vòng quay PPTX. Luôn mở lại tệp đã tạo và kiểm tra bộ sưu tập khi yêu cầu bảo toàn.
- [BrightnessContrast](https://reference.aspose.com/slides/vi/java/com.aspose.slides/brightnesscontrast/) là một phần mở rộng Office 2010 chứ không phải thao tác luminance DrawingML chuẩn. Nó có thể dùng để dựng hình trong bộ nhớ, nhưng không được đảm bảo sẽ vẫn là một [IBrightnessContrast](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibrightnesscontrast/) có thể chỉnh sửa sau khi lưu và mở lại PPTX. Nên dùng [addLuminanceEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) cho các điều chỉnh độ sáng/độ tương phản bền vững.
- Định dạng PPT nhị phân xuất hiện trước mô hình hiệu ứng DrawingML đầy đủ. Lưu dưới dạng PPT có thể bỏ qua các thao tác không hỗ trợ, giảm chuỗi xuống một tập hợp con được hỗ trợ, hoặc xấp xỉ hình ảnh. Không nên dùng PPT làm định dạng xác minh cho một chuỗi chỉnh sửa phức tạp.
- Kết xuất sang PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các định dạng hình ảnh khác áp dụng chuỗi đã hỗ trợ vào hình ảnh cuối cùng. Các đầu ra này không chứa một `IImageTransformOperationCollection` có thể chỉnh sửa; các định dạng raster làm phẳng kết quả thành pixel, và các xuất tài liệu/vector lưu trữ đại diện dựng hình riêng của chúng.
- Hiệu ứng không làm cho một ảnh được liên kết tự chứa. Việc dựng hình một ảnh liên kết vẫn phụ thuộc vào việc tài nguyên liên kết còn khả dụng khi trình bày được tải.

Các nền tảng trình bày khác nhau có thể dựng các trường hợp biên khác nhau, đặc biệt khi nhiều thao tác alpha hoặc giảm màu được kết hợp. Đối với đầu ra quan trọng, hãy thử cả vòng quay chỉnh sửa và định dạng xuất cuối cùng bằng cùng một phiên bản Aspose.Slides đang dùng trong sản xuất.

## **Câu hỏi thường gặp**

**Các hiệu ứng biến đổi ảnh có thay đổi dữ liệu ảnh đã nhúng không?**

Không. Các thao tác thuộc về `ISlidesPicture` được dùng cho nền ảnh. Các byte `IPPImage` nền tảng vẫn không thay đổi.

**Hai khung hình ảnh sử dụng cùng một ảnh có cùng chia sẻ hiệu ứng không?**

Không. Tái sử dụng một `IPPImage` giúp tránh trùng lặp dữ liệu ảnh, nhưng mỗi khung hình thường có một `ISlidesPicture` và bộ sưu tập biến đổi ảnh riêng.

**Có thể kết hợp các hiệu ứng màu, làm mờ và alpha không?**

Có. Bộ sưu tập cho phép chúng trong một chuỗi có thứ tự. Hãy cân nhắc tác động của mỗi thao tác lên kết quả của thao tác trước, vì các thao tác thay thế và ngưỡng có thể loại bỏ chi tiết màu hoặc alpha đã tạo ra trước đó.

**Tại sao các giá trị hiệu quả lại chỉ đọc?**

Dữ liệu hiệu quả đại diện cho các giá trị đã tính toán dùng để dựng hình, bao gồm các màu đã giải quyết. Chỉnh sửa thao tác lưu trong bộ sưu tập nơi có thành viên có thể ghi; nếu không, hãy xóa nó và thêm một thao tác thay thế với các tham số tạo mới.

**Định dạng nào nên dùng để bảo toàn một chuỗi biến đổi?**

Sử dụng PPTX và xác minh tệp bằng cách mở lại. PPT cũ không thể biểu diễn đầy đủ mô hình hiệu ứng DrawingML, và các định dạng xuất hình ảnh chỉ bảo toàn ngoại hình chứ không giữ lại các thao tác biến đổi có thể chỉnh sửa.