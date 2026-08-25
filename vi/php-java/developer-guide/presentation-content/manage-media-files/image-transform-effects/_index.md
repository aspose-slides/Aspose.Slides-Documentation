---
title: Quản lý các hiệu ứng biến đổi ảnh trong bản trình chiếu bằng PHP
linktitle: Hiệu ứng biến đổi ảnh
type: docs
weight: 11
url: /vi/php-java/image-transform-effects/
keywords:
- biến đổi ảnh
- hiệu ứng hình ảnh
- độ sáng
- độ tương phản
- thang độ xám
- đôi sắc
- tô màu
- HSL
- thay thế màu
- làm mờ
- độ trong suốt
- hiệu ứng alpha
- chuỗi hiệu ứng
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Áp dụng, tạo chuỗi, kiểm tra, xóa và xác minh các hiệu ứng biến đổi ảnh cho khung hình ảnh bằng Aspose.Slides cho PHP thông qua Java."
---
## **Tổng quan**

Aspose.Slides biểu diễn các điều chỉnh hình ảnh dưới dạng một bộ sưu tập có thứ tự của các thao tác biến đổi ảnh. Đối với một khung ảnh, bắt đầu với [Picture](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picture/) của khung và truy cập [Picture::getImageTransform](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picture/getimagetransform/). Bộ [ImageTransformOperationCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/) trả về cho phép bạn thêm, liệt kê, kiểm tra, xóa và xóa sạch các hiệu ứng mà không cần ghi lại lại dữ liệu byte ảnh gốc.

Bài viết này trình bày một quy trình làm việc hoàn chỉnh cho độ sáng và độ tương phản, biến đổi màu sắc, làm mờ, trong suốt, chuỗi hiệu ứng có thứ tự, giá trị thực tế, loại bỏ và xác minh vòng quay PPTX.

## **Hiểu về quyền sở hữu hiệu ứng và việc tái sử dụng ảnh**

Một tài nguyên ảnh và hình ảnh hiển thị nó là các đối tượng khác nhau:

- [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) lưu trữ hoặc tham chiếu dữ liệu ảnh nguồn do bản trình chiếu sở hữu.
- [Picture](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picture/) thuộc về một phần nền ảnh và tham chiếu tới tài nguyên ảnh trong khi lưu trữ bộ sưu tập biến đổi ảnh.
- [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) là hình dạng trên slide sở hữu phần nền ảnh, hình học, cài đặt cắt và các định dạng cấp khung khác.

Do đó, các thao tác biến đổi ảnh không thay đổi các byte trong [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/). Khi cùng một `PPImage` được truyền cho [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addpictureframe/) nhiều hơn một lần, mỗi khung ảnh mới sẽ nhận một `Picture` và một bộ sưu tập biến đổi riêng. Áp dụng thang độ xám cho một khung không làm các khung khác cũng trở thành thang độ xám, mặc dù tất cả chúng đều tái sử dụng cùng một tài nguyên ảnh được nhúng.

Mô hình `Picture::getImageTransform` tương tự cũng được sử dụng bởi các phần nền ảnh khác, chẳng hạn như nền hình dạng hoặc nền slide. Các ví dụ dưới đây tập trung vào khung ảnh.

## **Sử dụng phạm vi và đơn vị tham số hợp lệ**

Các phương thức được minh họa sử dụng các phạm vi ngữ nghĩa và đơn vị sau. Giữ các giá trị trong các phạm vi này ngay cả khi một phiên bản thư viện cụ thể không từ chối ngay mọi giá trị ngoài phạm vi; định dạng bản trình chiếu đích có thể chuẩn hoá, bỏ qua hoặc từ chối dữ liệu không hợp lệ trong quá trình lưu hoặc khi PowerPoint mở tệp.

| Hoạt động | Tham số | Phạm vi hợp lệ và đơn vị |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` tới `100`, phần trăm; `0` giữ thành phần không thay đổi. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | Không có | Không có tham số số. Alpha không thay đổi. |
| [addDuotoneEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Hai màu cho các pixel tối và sáng. Kênh RGB và alpha trong `java.awt.Color` dùng giá trị từ `0` tới `255`. |
| [addTintEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue là `0` bao gồm tới `360` không bao gồm, tính bằng độ; amount là `-100` tới `100`, phần trăm. |
| [addHSLEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue là `0` bao gồm tới `360` không bao gồm, tính bằng độ; saturation và luminance là `-100` tới `100`, phần trăm. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | Màu thay thế dùng các giá trị kênh từ `0` tới `255`. Các giá trị alpha hiện có không thay đổi. |
| [addBlurEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius không âm và đo bằng points; `grow` là Boolean điều khiển ảnh mờ có thể mở rộng ra ngoài giới hạn gốc hay không. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Phần trăm không âm. Dùng `0` tới `100` cho việc thu nhỏ độ mờ thông thường: `0` hoàn toàn trong suốt và `100` giữ nguyên alpha hiện có. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` tới `100`, phần trăm độ mờ. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` tới `100`, phần trăm ngưỡng alpha. Giá trị dưới ngưỡng trở thành trong suốt; giá trị bằng hoặc trên ngưỡng trở thành không trong suốt. |

Đối với điều chỉnh alpha cố định, độ trong suốt và độ mờ là các khái niệm đối lập. Ví dụ, độ trong suốt 35 % tương đương với mức điều chỉnh alpha 65 %.

## **Áp dụng độ sáng và độ tương phản**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) trả về một thao tác [Luminance](https://reference.aspose.com/slides/vi/php-java/aspose.slides/luminance/). Các thiết lập vô hướng được cung cấp khi tạo thao tác. [Luminance::getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/luminance/geteffective/) trả về các giá trị chỉ đọc đã tính toán mà có thể kiểm tra hoặc ghi log.

Ví dụ sau tăng độ sáng lên 15 % và độ tương phản lên 20 %, sau đó hiển thị bản xem trước mà không thay đổi ảnh được nhúng:

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

`Luminance` là hiệu ứng độ sáng và độ tương phản chuẩn của DrawingML. Khi các thiết lập này phải vẫn có thể chỉnh sửa sau một vòng quay PPTX, hãy mở lại bản trình chiếu đã lưu và xác minh cả kiểu thao tác và các giá trị thực tế của nó.

## **Áp dụng biến đổi màu sắc**

Các hiệu ứng màu có thể được áp dụng độc lập cho các khung ảnh khác nhau mà tái sử dụng cùng một tài nguyên ảnh. Ví dụ dưới đây tạo năm khung và áp dụng thang độ xám, duotone, tint, điều chỉnh HSL và thay thế màu.

[Duotone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/duotone/) chứa hai tham số màu có thể chỉnh sửa độc lập: `color1` ánh xạ các pixel tối, trong khi `color2` ánh xạ các pixel sáng. Điều này làm cho nó trở thành một ví dụ hữu ích về một hiệu ứng có cài đặt phức tạp hơn một giá trị vô hướng duy nhất.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) thay thế màu của mỗi pixel bằng một màu cố định trong khi bảo toàn alpha. Nó khác với [addColorChangeEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), thao tác này ánh xạ một màu nguồn sang màu đích và hiển thị cả định dạng màu nguồn và đích.

## **Thêm hiệu ứng làm mờ, trong suốt và alpha**

[addBlurEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) ảnh hưởng đến mọi kênh màu, bao gồm cả alpha. Đặt `grow` thành `true` khi cạnh mờ có thể mở rộng ra ngoài giới hạn ảnh gốc.

Đối với độ trong suốt đồng nhất, sử dụng [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Nó nhân mỗi giá trị alpha hiện có, vì vậy các pixel bán trong suốt vẫn giữ tỷ lệ khác nhau. [addAlphaReplaceEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) thay vào đó gán một giá trị alpha cho mọi pixel. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) chuyển đổi alpha thành hai mức dựa trên một ngưỡng.

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

Các thao tác alpha không có tham số khác bao gồm [addAlphaCeilingEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), làm cho mọi alpha khác 0 trở nên hoàn toàn không trong suốt; [addAlphaFloorEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), làm cho mọi alpha dưới 100 % trở nên hoàn toàn trong suốt; và [addAlphaInverseEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), đổi alpha thành `100% - alpha`.

## **Xây dựng chuỗi hiệu ứng có thứ tự**

Mỗi phương thức `add...Effect` thêm một thao tác mới vào cuối bộ sưu tập. Bộ render sử dụng bộ sưu tập như một pipeline có thứ tự: đầu ra của phép toán 0 trở thành đầu vào của phép toán 1, và cứ thế tiếp tục. Do đó, cùng một tập hợp thao tác nhưng theo thứ tự khác có thể tạo ra ảnh khác nhau.

Ví dụ, thang độ xám rồi tint đầu tiên loại bỏ thông tin màu và sau đó tô lại kết quả độ sáng. Tint rồi thang độ xám lại loại bỏ tint. Tương tự, thay thế alpha có thể ghi đè các giá trị alpha được tính bởi các thao tác trước, trong khi điều chỉnh alpha bảo toàn sự khác biệt tương đối của chúng.

Ví dụ sau xây dựng một chuỗi bốn thao tác, lưu dưới dạng PPTX, mở lại bản trình chiếu, kiểm tra cả kiểu thao tác và thứ tự của chúng, và hiển thị kết quả đã mở lại:

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

Bộ sưu tập không áp đặt một ma trận tương thích hạn chế các thao tác màu, alpha và làm mờ vào các chuỗi riêng biệt. Chúng có thể được kết hợp, nhưng không phải lúc nào cũng hữu ích. Thay thế màu cố định sẽ xóa các biến thể RGB được tạo bởi các hiệu ứng màu trước; thang độ xám sau duotone sẽ xóa hai màu đã chọn; và các thao tác alpha ceiling, floor, replacement hoặc bi‑level có thể loại bỏ chi tiết alpha được tạo ra trước. Hãy xây dựng chuỗi theo trình tự xử lý pixel mong muốn thay vì coi các mục là các cờ định dạng không có thứ tự.

## **Kiểm tra giá trị có thể chỉnh sửa và giá trị thực tế**

Một thao tác có thể chỉnh sửa là đối tượng lưu trong `Picture::getImageTransform`. Tùy thuộc vào hiệu ứng, nó có thể trực tiếp khai báo các thành viên ghi được. Ví dụ, [Blur](https://reference.aspose.com/slides/vi/php-java/aspose.slides/blur/) cung cấp các giá trị ghi được `radius` và `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/vi/php-java/aspose.slides/alphamodulatefixed/) cung cấp `amount` ghi được, và [AlphaBiLevel](https://reference.aspose.com/slides/vi/php-java/aspose.slides/alphabilevel/) cung cấp `threshold` ghi được. Các hiệu ứng màu như [Duotone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/duotone/) cung cấp các đối tượng [ColorFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/colorformat/) có thể thay đổi.

Một số thao tác, bao gồm [Luminance](https://reference.aspose.com/slides/vi/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/vi/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/vi/php-java/aspose.slides/tint/) và [AlphaReplace](https://reference.aspose.com/slides/vi/php-java/aspose.slides/alphareplace/), không khai báo các tham số tạo dưới dạng thuộc tính ghi được. Để thay đổi các cài đặt này, cần xóa thao tác và thêm một thao tác thay thế tại vị trí yêu cầu.

Dữ liệu thực tế trả về bởi `getEffective()` được tính toán và chỉ đọc. Nó hữu ích để giải quyết các màu phụ thuộc chủ đề và đọc các giá trị đã chuẩn hoá mà bộ render sử dụng, nhưng không phải là một bề mặt chỉnh sửa khác. Ví dụ sau liệt kê chuỗi và kiểm tra các giá trị thực tế khi API tương ứng cung cấp chúng:

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

Các hiệu ứng không có tham số như thang độ xám, alpha ceiling và alpha inverse vẫn có một đối tượng dữ liệu thực tế, nhưng không có cài đặt vô hướng để in ra. Sự hiện diện và vị trí của chúng trong bộ sưu tập là thông tin quan trọng.

## **Xóa hoặc xóa sạch các biến đổi ảnh**

Sử dụng [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/removeat/) để xóa một thao tác theo chỉ mục. Vì các chỉ mục sẽ dịch chuyển sau khi xóa, hãy tìm kiếm mục tiêu trước và xóa nó sau khi đã liệt kê. Sử dụng [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagetransformoperationcollection/clear/) để xóa toàn bộ chuỗi.

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

Xóa hoặc xóa sạch các biến đổi chỉ thay đổi định dạng hình ảnh. Nó không xóa, nén lại hoặc thay đổi tài nguyên [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) được tái sử dụng.

## **Cân nhắc định dạng bản trình chiếu và mục tiêu xuất**

Các biến đổi ảnh bắt nguồn từ DrawingML, vì vậy PPTX là định dạng chỉnh sửa ưu tiên cho các chuỗi hiệu ứng. Ngay cả với PPTX, không phải mọi thao tác đều có tính di động tương đương:

- Các thao tác DrawingML tiêu chuẩn như luminance, grayscale, duotone, tint, HSL, blur và các thao tác alpha thông thường có khả năng tồn tại cao nhất sau một vòng quay PPTX. Luôn mở lại tệp đã tạo và kiểm tra bộ sưu tập khi việc bảo tồn là yêu cầu.
- Định dạng PPT nhị phân xuất hiện trước mô hình hiệu ứng DrawingML đầy đủ. Lưu thành PPT có thể bỏ qua các thao tác không được hỗ trợ, giảm chuỗi xuống một tập con được hỗ trợ, hoặc xấp xỉ giao diện. Không nên dùng PPT làm định dạng xác minh cho một chuỗi chỉnh sửa phức tạp.
- Kết xuất sang PNG, JPEG, TIFF, PDF, SVG, HTML hoặc các đầu ra hình ảnh khác áp dụng chuỗi đã hỗ trợ lên giao diện kết xuất. Các đầu ra này không chứa một `ImageTransformOperationCollection` có thể chỉnh sửa; định dạng raster làm phẳng kết quả thành các pixel, và các xuất tài liệu hoặc vector lưu trữ biểu diễn render riêng của chúng.
- Hiệu ứng không làm cho một ảnh được liên kết tự chứa. Việc render một hình ảnh liên kết vẫn phụ thuộc vào việc tài nguyên liên kết có sẵn khi bản trình chiếu được tải.

Các trình duyệt bản trình chiếu khác nhau có thể render các trường hợp biên khác nhau, đặc biệt khi nhiều thao tác alpha hoặc lượng màu được kết hợp. Đối với đầu ra quan trọng, hãy kiểm tra cả vòng quay chỉnh sửa và định dạng xuất cuối cùng bằng cùng phiên bản Aspose.Slides được sử dụng trong môi trường sản xuất.

## **Câu hỏi thường gặp**

**Các hiệu ứng biến đổi ảnh có thay đổi dữ liệu ảnh được nhúng không?**

Không. Các thao tác thuộc về `Picture` được sử dụng bởi phần nền ảnh. Các byte `PPImage` nền tảng vẫn không bị thay đổi.

**Hai khung ảnh tái sử dụng cùng một ảnh có chia sẻ các hiệu ứng không?**

Không. Tái sử dụng một `PPImage` tránh trùng lặp dữ liệu ảnh, nhưng mỗi khung ảnh thường có một `Picture` và một bộ sưu tập biến đổi ảnh riêng.

**Có thể kết hợp các hiệu ứng màu, làm mờ và alpha không?**

Có. Bộ sưu tập chấp nhận chúng trong một chuỗi có thứ tự. Hãy cân nhắc mỗi thao tác sẽ ảnh hưởng như thế nào tới kết quả của thao tác trước vì các thao tác thay thế và ngưỡng có thể loại bỏ chi tiết màu hoặc alpha đã tạo trước.

**Tại sao các giá trị thực tế là chỉ đọc?**

Dữ liệu thực tế đại diện cho các giá trị đã tính toán dùng cho render, bao gồm các màu đã được giải quyết. Hãy chỉnh sửa thao tác lưu trong bộ sưu tập biến đổi nơi các thành viên ghi được tồn tại; nếu không, hãy xóa nó và thêm một thao tác thay thế với các tham số tạo mới.

**Định dạng nào nên dùng để bảo tồn một chuỗi biến đổi?**

Sử dụng PPTX và xác minh tệp bằng cách mở lại. PPT cũ không thể biểu diễn đầy đủ mô hình hiệu ứng DrawingML, và các định dạng xuất render chỉ bảo tồn giao diện chứ không phải các thao tác biến đổi có thể chỉnh sửa.