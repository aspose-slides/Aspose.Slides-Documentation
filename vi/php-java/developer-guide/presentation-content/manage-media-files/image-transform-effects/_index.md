---
title: Quản lý các hiệu ứng biến đổi ảnh trong bài thuyết trình với PHP
linktitle: Hiệu ứng biến đổi ảnh
type: docs
weight: 11
url: /vi/php-java/image-transform-effects/
keywords:
- biến đổi ảnh
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
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Áp dụng, xâu chuỗi, kiểm tra, xóa và xác minh các hiệu ứng biến đổi ảnh cho khung hình ảnh với Aspose.Slides cho PHP thông qua Java."
---
## **Tổng quan**

Aspose.Slides biểu diễn các điều chỉnh hình ảnh như một bộ sưu tập có thứ tự các thao tác biến đổi ảnh. Đối với một khung hình ảnh, bắt đầu với [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) của khung và truy cập [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/). Bộ sưu tập [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xóa và xóa sạch các hiệu ứng mà không cần ghi lại dữ liệu ảnh gốc.

Bài viết này minh họa quy trình làm việc đầy đủ cho độ sáng và độ tương phản, biến đổi màu, làm mờ, độ trong suốt, chuỗi hiệu ứng có thứ tự, giá trị thực tế, việc xóa, và kiểm chứng vòng quay lại PPTX.

## **Hiểu quyền sở hữu hiệu ứng và việc tái sử dụng ảnh**

Một tài nguyên ảnh và hình ảnh hiển thị nó là các đối tượng khác nhau:

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) lưu hoặc tham chiếu dữ liệu ảnh nguồn thuộc bản trình chiếu.
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) thuộc về một fill hình ảnh và tham chiếu tới tài nguyên ảnh đồng thời lưu bộ sưu tập biến đổi ảnh.
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) là hình dạng trên slide sở hữu fill hình ảnh liên quan, hình học, cài đặt cắt và các định dạng cấp khung khác.

Do đó, các thao tác biến đổi ảnh không thay đổi byte trong [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/). Khi cùng một `PPImage` được truyền vào [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) nhiều hơn một lần, mỗi khung hình ảnh mới sẽ nhận được `Picture` và bộ sưu tập biến đổi riêng. Áp dụng chuyển đổi xám cho một khung không làm cho các khung khác cũng chuyển sang xám, mặc dù tất cả chúng đều tái sử dụng cùng một tài nguyên ảnh được nhúng.

Mô hình `Picture::getImageTransform` tương tự cũng được sử dụng cho các fill hình ảnh khác, chẳng hạn như hình dạng hoặc nền slide. Các ví dụ bên dưới tập trung vào khung hình ảnh.

## **Sử dụng phạm vi và đơn vị tham số hợp lệ**

Các phương thức được minh họa sử dụng các phạm vi ngữ nghĩa và đơn vị sau. Giữ các giá trị trong các phạm vi này ngay cả khi một phiên bản thư viện cụ thể không từ chối ngay mọi giá trị ngoài phạm vi; định dạng bản trình chiếu mục tiêu có thể chuẩn hoá, bỏ qua hoặc từ chối dữ liệu không hợp lệ khi lưu hoặc khi PowerPoint mở file.

| Thao tác | Tham số | Phạm vi hợp lệ và đơn vị |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` tới `100`, phần trăm; `0` giữ thành phần không thay đổi. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | Không có | Không có tham số số. Alpha không thay đổi. |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Hai màu cho pixel tối và sáng. Kênh RGB và alpha trong `java.awt.Color` sử dụng `0` tới `255`. |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue từ `0` (bao gồm) tới `360` (không bao gồm), đơn vị độ; amount từ `-100` tới `100`, phần trăm. |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue từ `0` (bao gồm) tới `360` (không bao gồm), đơn vị độ; saturation và luminance từ `-100` tới `100`, phần trăm. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Màu thay thế sử dụng giá trị kênh từ `0` tới `255`. Giá trị alpha hiện có không thay đổi. |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Bán kính không âm và đo bằng điểm; `grow` là Boolean điều khiển việc nội dung làm mờ có thể mở rộng ra ngoài giới hạn gốc hay không. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Phần trăm không âm. Dùng `0` tới `100` cho việc tỷ lệ độ mờ thông thường: `0` hoàn toàn trong suốt và `100` giữ nguyên alpha hiện có. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` tới `100`, phần trăm độ mờ. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` tới `100`, phần trăm ngưỡng alpha. Giá trị dưới ngưỡng trở thành trong suốt; giá trị bằng hoặc trên ngưỡng trở thành không trong suốt. |

Đối với việc điều chế alpha cố định, độ trong suốt và độ mờ là các khái niệm bổ sung nhau. Ví dụ, độ trong suốt 35% tương đương với mức điều chế alpha 65%.

## **Áp dụng độ sáng và độ tương phản**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) trả về một thao tác [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/). Các cài đặt vô hướng của nó được cung cấp khi tạo thao tác. [Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/) trả về các giá trị chỉ đọc được tính toán, có thể kiểm tra hoặc ghi log.

Ví dụ sau tăng độ sáng 15% và độ tương phản 20%, sau đó hiển thị bản xem trước mà không thay đổi ảnh được nhúng:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` là hiệu ứng độ sáng và độ tương phản chuẩn DrawingML. Khi các cài đặt này phải còn có thể chỉnh sửa sau khi vòng quay PPTX, hãy mở lại bản trình chiếu đã lưu và xác minh cả loại thao tác và các giá trị thực tế của nó.

## **Áp dụng các biến đổi màu**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung hình ảnh khác nhau mà tái sử dụng cùng một tài nguyên ảnh. Ví dụ sau tạo năm khung và áp dụng chuyển đổi xám, duotone, tint, điều chỉnh HSL và thay thế màu.

[Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `color1` ánh xạ các pixel tối, trong khi `color2` ánh xạ các pixel sáng. Đây là một ví dụ hữu ích về hiệu ứng có cài đặt phức tạp hơn một giá trị vô hướng duy nhất.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) thay thế màu của mỗi pixel bằng một màu cố định trong khi giữ nguyên alpha. Nó khác với [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), cái mà ánh xạ một màu nguồn thành màu đích và phô bày cả định dạng màu nguồn và đích.

### **Áp dụng Ngưỡng Luminance**

Một ngưỡng luminance có thể làm cho các dấu hiệu mờ trên trang quét dễ phân biệt hơn so với nền. [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) giữ lại các sắc thái xám trung gian. [addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/) ánh xạ luminance thành đen hoặc trắng, trong khi [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) áp dụng ngưỡng cho độ trong suốt.

Ngưỡng luminance dao động từ 0% tới 100%, bao gồm cả hai đầu. Các pixel dưới ngưỡng trở thành đen. Các pixel ở hoặc trên ngưỡng trở thành trắng. Tăng ngưỡng sẽ làm nhiều sắc thái hơn trở thành đen vì chúng rơi dưới mức cắt.

Tải xuống [grayscale-swatches.png](grayscale-swatches.png) vào thư mục chứa script PHP. Mỗi nhãn hiển thị mức xám gốc trên thang từ 0 đến 255. Ví dụ đặt bản gốc bên cạnh hai bản sao và lưu ngưỡng của mỗi bản sao vào bản trình chiếu.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 150, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $sourceImage = Images::fromFile(__DIR__ . "/grayscale-swatches.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $captions = ["Original", "Threshold 20%", "Threshold 60%"];
    $frames = [];
    foreach ($captions as $index => $caption) {
        $x = 12 + 240 * $index;
        $label = $shapes->addAutoShape(ShapeType::Rectangle, $x, 12, 216, 36);
        $label->getTextFrame()->setText($caption);
        $frames[] = $shapes->addPictureFrame(ShapeType::Rectangle, $x, 60, 216, 72, $image);
    }

    $frames[1]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(20);
    $frames[2]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(60);

    $presentation->save(__DIR__ . "/luminance-threshold.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Mở bản trình chiếu đầu ra trong PowerPoint để so sánh ba khung. Swatch có nhãn 96 có khoảng 38% luminance (96 trên 255). Nó chuyển thành trắng ở ngưỡng 20% và thành đen ở ngưỡng 60%.

![Các mẫu xám gốc bên cạnh kết quả đen‑trắng ở ngưỡng luminance 20% và 60%](luminance-threshold.png)

## **Thêm làm mờ, độ trong suốt và hiệu ứng Alpha**

[addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) ảnh hưởng tới tất cả các kênh màu, bao gồm alpha. Đặt `grow` thành `true` khi cạnh làm mờ có thể mở rộng ra ngoài giới hạn ảnh gốc.

Đối với độ trong suốt đồng đều, dùng [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Nó nhân mỗi giá trị alpha hiện có, vì vậy các pixel bán trong suốt vẫn giữ tỉ lệ khác nhau. [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) thay vào đó gán một giá trị alpha cho tất cả các pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) chuyển alpha thành hai mức dựa trên một ngưỡng.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Các thao tác alpha không có tham số khác bao gồm [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), làm cho mọi alpha khác 0 trở nên hoàn toàn không trong suốt; [addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), làm mọi alpha dưới 100% thành hoàn toàn trong suốt; và [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), chuyển alpha thành `100% - alpha`.

## **Xây dựng chuỗi hiệu ứng có thứ tự**

Mỗi phương thức `add...Effect` thêm một thao tác mới vào cuối bộ sưu tập. Trình render sử dụng bộ sưu tập như một pipeline có thứ tự: đầu ra của thao tác 0 trở thành đầu vào của thao tác 1, và cứ tiếp tục. Do đó, cùng các thao tác nhưng thứ tự khác nhau có thể tạo ra ảnh khác.

Ví dụ, xám rồi tint đầu tiên loại bỏ thông tin màu và sau đó tô lại kết quả luminance. Tint rồi xám lại loại bỏ tint. Tương tự, việc thay thế alpha có thể ghi đè các giá trị alpha được tính bởi các thao tác trước, trong khi điều chế alpha giữ lại sự khác biệt tương đối của chúng.

Ví dụ sau xây dựng chuỗi bốn thao tác, lưu dưới dạng PPTX, mở lại bản trình chiếu, kiểm tra cả loại thao tác và thứ tự của chúng, và hiển thị kết quả đã mở lại:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Bộ sưu tập không áp đặt một ma trận tương thích hạn chế các thao tác màu, alpha và làm mờ vào các chuỗi riêng biệt. Chúng có thể được kết hợp, nhưng không phải lúc nào cũng hữu ích. Thay thế màu cố định loại bỏ biến thể RGB do các hiệu ứng màu trước đó tạo ra; xám sau duotone loại bỏ hai màu đã chọn; và các thao tác alpha ceiling, floor, replacement hoặc bi‑level có thể loại bỏ chi tiết alpha được tạo ra trước. Xây dựng chuỗi dựa trên trình tự xử lý pixel mong muốn thay vì coi các mục như các cờ định dạng không thứ tự.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Trong bản render Aspose.Slides for .NET 26.11 minh họa này, một tint 220° ở mức 25% để lại hình ảnh xám không thay đổi. Áp dụng cùng một tint trước khi chuyển sang xám tạo ra các tông màu khác nhau.*
<!-- visual-explanation:image-transform-effects:end -->

## **Kiểm tra các giá trị có thể chỉnh sửa và giá trị thực tế**

Một thao tác có thể chỉnh sửa là đối tượng được lưu trong `Picture::getImageTransform`. Tùy thuộc vào hiệu ứng, nó có thể cung cấp các thành viên ghi được trực tiếp. Ví dụ, [Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/) cung cấp các giá trị ghi được `radius` và `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/) cung cấp một `amount` ghi được, và [AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/) cung cấp một `threshold` ghi được. Các hiệu ứng màu như [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) cung cấp các đối tượng [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) có thể thay đổi.

Một số thao tác, bao gồm [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/), và [AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/), không cung cấp các vô hướng tạo ra dưới dạng thuộc tính ghi được. Để thay đổi những cài đặt này, hãy xóa thao tác và thêm một thao tác thay thế ở vị trí yêu cầu.

Dữ liệu thực tế được trả về bởi `getEffective()` được tính toán và chỉ đọc. Nó hữu ích để giải quyết các màu phụ thuộc theme và đọc các giá trị đã chuẩn hoá mà trình render sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ sau liệt kê chuỗi và kiểm tra các giá trị thực tế ở những nơi API tương ứng cung cấp chúng:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Các hiệu ứng không có tham số như xám, alpha ceiling và alpha inverse vẫn có đối tượng dữ liệu thực tế, nhưng không có cài đặt vô hướng để in. Sự tồn tại và vị trí của chúng trong bộ sưu tập là thông tin quan trọng.

## **Xóa hoặc xóa sạch các biến đổi ảnh**

Dùng [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/) để xóa một thao tác theo chỉ mục. Vì các chỉ mục thay đổi sau khi xóa, hãy tìm mục tiêu trước và xóa nó sau khi liệt kê. Dùng [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/) để xóa toàn bộ chuỗi.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Xóa hoặc xóa sạch các biến đổi chỉ thay đổi định dạng hình ảnh. Nó không xóa, nén lại hoặc thay đổi tài nguyên [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) được tái sử dụng.

## **Xem xét định dạng bản trình chiếu và mục tiêu xuất khẩu**

Các biến đổi ảnh bắt nguồn từ DrawingML, vì vậy PPTX là định dạng chỉnh sửa được ưu tiên cho các chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi thao tác đều có khả năng di chuyển tương thích hoàn toàn:

- Các thao tác DrawingML chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các thao tác alpha phổ biến có khả năng tồn tại sau một vòng quay PPTX tốt nhất. Luôn mở lại tệp đã tạo và kiểm tra bộ sưu tập khi cần bảo tồn.
- Định dạng PPT nhị phân được tạo ra trước mô hình hiệu ứng DrawingML đầy đủ. Lưu thành PPT có thể bỏ qua các thao tác không được hỗ trợ, giảm chuỗi xuống thành tập hợp được hỗ trợ, hoặc xấp xỉ giao diện. Không sử dụng PPT làm định dạng kiểm chứng cho một chuỗi chỉnh sửa phức tạp.
- Render ra PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các đầu ra trực quan khác áp dụng chuỗi được hỗ trợ vào kết quả hiển thị. Những đầu ra này không chứa `ImageTransformOperationCollection` có thể chỉnh sửa; các định dạng raster làm phẳng kết quả thành pixel, và các xuất khẩu tài liệu hoặc vector lưu đại diện render riêng của chúng.
- Các hiệu ứng không làm cho một hình ảnh được liên kết tự chứa. Render một hình ảnh liên kết vẫn phụ thuộc vào tài nguyên liên kết có sẵn khi bản trình chiếu được tải.

Các trình tiêu thụ bản trình chiếu khác nhau có thể render các trường hợp biên giới khác nhau, đặc biệt khi nhiều thao tác alpha hoặc màu được kết hợp. Đối với đầu ra quan trọng, hãy thử cả vòng quay chỉnh sửa và định dạng xuất cuối cùng với cùng phiên bản Aspose.Slides được dùng trong môi trường sản xuất.

## **Câu hỏi thường gặp**

**Các hiệu ứng biến đổi ảnh có thay đổi dữ liệu ảnh được nhúng không?**

Không. Các thao tác thuộc về `Picture` được sử dụng bởi fill hình ảnh. Các byte `PPImage` nền tảng vẫn không bị thay đổi.

**Hai khung hình ảnh tái sử dụng cùng một ảnh có chia sẻ hiệu ứng không?**

Không. Tái sử dụng `PPImage` tránh trùng lặp dữ liệu ảnh, nhưng mỗi khung hình ảnh thường có một `Picture` và bộ sưu tập biến đổi ảnh riêng.

**Có thể kết hợp các hiệu ứng màu, làm mờ và alpha không?**

Có. Bộ sưu tập cho phép chúng trong một chuỗi có thứ tự. Hãy cân nhắc tác động của mỗi thao tác lên kết quả của thao tác trước vì các thao tác thay thế và ngưỡng có thể loại bỏ chi tiết màu hoặc alpha đã có.

**Tại sao các giá trị thực tế lại chỉ đọc?**

Dữ liệu thực tế đại diện cho các giá trị đã tính toán dùng cho render, bao gồm các màu đã được giải quyết. Chỉnh sửa thao tác lưu trong bộ sưu tập biến đổi nơi có thành viên ghi được; nếu không, hãy xóa và thêm một thao tác thay thế với các tham số tạo mới.

**Định dạng nào nên dùng để bảo tồn chuỗi biến đổi?**

Sử dụng PPTX và xác minh tệp bằng cách mở lại. PPT cũ không thể biểu diễn đầy đủ mô hình hiệu ứng DrawingML, và các định dạng xuất khẩu render chỉ bảo tồn giao diện thay vì các thao tác biến đổi có thể chỉnh sửa.