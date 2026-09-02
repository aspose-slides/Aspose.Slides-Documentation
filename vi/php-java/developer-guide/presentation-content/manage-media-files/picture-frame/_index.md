---
title: Quản lý Khung Hình trong Bài thuyết trình bằng PHP
linktitle: Khung Hình
type: docs
weight: 10
url: /vi/php-java/picture-frame/
keywords:
- khung hình
- thêm khung hình
- tạo khung hình
- hình ảnh nhúng
- hình ảnh liên kết
- trích xuất hình ảnh
- hình raster
- hình SVG
- cắt hình ảnh
- xóa các khu vực đã cắt
- nén hình ảnh
- StretchOffset
- định dạng khung hình
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỉ lệ khung hình
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung hình trong bài thuyết trình với Aspose.Slides cho PHP thông qua Java."
---
## **Tổng quan**

Khung hình là một hình dạng trên slide hiển thị hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) sở hữu các tài nguyên hình ảnh được nhúng thông qua [ImageCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagecollection/), trong khi một [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) điều khiển vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng hình ảnh và các cài đặt cấp khung khác.

Việc tách biệt này hữu ích khi cùng một hình ảnh được hiển thị nhiều lần. Thêm hình ảnh vào bản trình bày một lần, giữ lại [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) trả về và sử dụng tài nguyên hình ảnh đó khi tạo các khung hình.

Các khung hình có thể chứa hình raster như PNG hoặc JPEG và hình vector SVG. Chúng cũng có thể tham chiếu tới hình ảnh liên kết thay vì lưu trữ byte hình ảnh trong bản trình bày. Lựa chọn này ảnh hưởng đến tính di động, kích thước tệp, việc trích xuất và hành vi xuất, vì vậy nên quyết định cách lưu trữ hình ảnh trước khi áp dụng định dạng hoặc tối ưu hóa.

## **Thêm và Định dạng Hình ảnh Nhúng**

Đối với hình ảnh nhúng, thêm dữ liệu hình ảnh vào bản trình bày và tạo khung hình bằng [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addpictureframe/). Hình ảnh trở thành một phần của gói bản trình bày, do đó bản trình bày vẫn tự chứa khi được chuyển sang máy tính khác.

Ví dụ sau thêm hình JPEG, tạo khung với kích thước gốc của hình và áp dụng định dạng đường viền cùng xoay:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Khung hình kiểm soát hình học hiển thị; việc thay đổi kích thước khung không thay đổi kích thước pixel gốc được lưu trong tài nguyên hình ảnh nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén hình ảnh sau này.

## **Sử dụng Tỷ lệ Tương đối**

[PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) cung cấp khả năng điều chỉnh tỷ lệ chiều rộng và chiều cao tương đối cho khung thông qua [setRelativeScaleWidth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/setrelativescalewidth/) và [setRelativeScaleHeight](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Giá trị `1.0` tương đương 100% kích thước hình gốc. Tỷ lệ tương đối hữu ích khi quy trình làm việc cần giữ mối quan hệ với kích thước hình ảnh nguồn thay vì tính toán kích thước cuối cùng thủ công.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tỷ lệ tương đối thay đổi cài đặt tỷ lệ của khung; nó không tái mẫu hoặc nén hình ảnh nhúng.

## **Hình ảnh Nhúng và Liên kết**

Hình ảnh nhúng lưu dữ liệu hình ảnh bên trong bản trình bày và do đó là lựa chọn an toàn nhất cho tính di động và hiển thị dự đoán được. Hình ảnh liên kết lưu vị trí bên ngoài thông qua phương thức [Picture::setLinkPathLong](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picture/setlinkpathlong/) thay vì nhúng dữ liệu hình ảnh theo cùng cách.

Hình ảnh liên kết có thể giảm lượng dữ liệu hình ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải vẫn có thể truy cập được cho ứng dụng mở hoặc hiển thị bản trình bày. Nếu đường dẫn thay đổi, tệp được di chuyển hoặc tài nguyên không khả dụng, hình ảnh liên kết có thể không hiển thị như mong đợi. Đối với các bản trình bày phải được gửi email, lưu trữ hoặc hiển thị trong môi trường cô lập, hình ảnh nhúng thường đáng tin cậy hơn.

### **Thêm Hình ảnh Liên kết**

Ví dụ sau tạo một khung hình và chỉ tới một tệp hình ảnh cục bộ. Nó chỉ xử lý việc liên kết hình ảnh; liên kết video là quy trình media riêng và không được trộn vào ví dụ này.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sử dụng liên kết khi quản lý tệp bên ngoài là có chủ đích. Không sử dụng chúng chỉ để thay thế nén: một PPTX nhỏ với phụ thuộc hình ảnh bị hỏng thường kém hữu ích hơn so với một bản trình bày tự chứa lớn hơn.

## **Trích xuất Hình ảnh từ Khung Hình**

Trước khi trích xuất hình ảnh từ một bản trình bày hiện có, kiểm tra xem hình dạng thực sự là [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) và nó có chứa hình ảnh nhúng hay không. Các khung hình liên kết có thể không chứa byte hình ảnh có thể trích xuất theo cùng cách.

### **Trích xuất Hình raster**

API hình ảnh hiện đại sử dụng [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/) trực tiếp. Ví dụ dưới đây tìm hình raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Lưu qua [IImage::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/#save) chuyển đổi hình ảnh đã trích xuất sang định dạng đầu ra được yêu cầu. Nếu bạn cần byte đã mã hoá được lưu trong bản trình bày thay vì tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên hình ảnh.

### **Trích xuất Hình SVG**

Đối với hình SVG, [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) cung cấp một đối tượng [SvgImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/). Điều này cho phép bạn lấy trực tiếp dữ liệu SVG thay vì raster hoá hình ảnh trước.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Giữ nội dung SVG dưới dạng SVG bảo toàn nguồn vector bên trong bản trình bày. Các xuất raster như PNG hoặc JPEG buộc phải render nội dung vector thành pixel. Xuất slide dưới dạng PDF hoặc SVG cũng là một thao tác render, vì vậy đồ họa xuất không nên được coi là bản sao byte‑for‑byte của SVG nhúng ban đầu; hãy sử dụng dữ liệu [SvgImage::getSvgData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/getsvgdata/) khi cần tài nguyên vector gốc.

## **Cắt Hình ảnh**

Cắt thay đổi phần hình ảnh nào hiển thị trong khung. Các giá trị cắt trên [PictureFillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/) là tỷ lệ phần trăm của kích thước hình ảnh nguồn. Cắt không xóa ngay các pixel ẩn khỏi hình ảnh nhúng; nó chỉ thay đổi vùng hiển thị.

Ví dụ sau tìm một khung hình một cách an toàn và áp dụng các giá trị cắt:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
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
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Vì dữ liệu hình ảnh ẩn vẫn còn, việc cắt có thể được thay đổi sau mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn tính khả năng hoàn tác, các vùng đã cắt có thể bị loại bỏ vật lý như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Hình ảnh Đã Cắt**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) xóa dữ liệu hình ảnh ngoài vùng cắt hiện tại và trả về tài nguyên hình ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là tối ưu hoá phá hủy: sau khi lưu bản trình bày, các pixel đã xóa sẽ không còn khả dụng cho thao tác hủy cắt sau này.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
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
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Phương thức có thể thêm một tài nguyên hình ảnh mới vào bản trình bày. Nếu hình ảnh gốc cũng được các khung hình khác sử dụng, những khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các vùng đã cắt không nhất thiết làm giảm tổng số hình ảnh. Cắt nội dung WMF hoặc EMF bằng phương pháp này sẽ raster hoá kết quả đã cắt thành PNG.

## **Nén Hình raster**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) giảm độ phân giải hình raster tương đối với kích thước mà hình được hiển thị. Nó cũng có thể xóa các vùng đã cắt trong cùng một thao tác. Phương thức trả về `true` khi hình đã được thay đổi kích thước hoặc cắt và `false` khi không có thay đổi nào cần thiết.

Sử dụng giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturescompression/) có sẵn khi độ phân giải mục tiêu tiêu chuẩn là đủ:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
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
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Một giá trị DPI dương tùy chỉnh có thể được truyền vào thay cho giá trị đã định nghĩa trước khi cần mục tiêu cụ thể.

Nén chỉ áp dụng cho hình raster. Nội dung SVG và metafile không bị giảm bởi quy trình nén raster này. Ngoài ra, hãy nhớ rằng độ phân giải thấp hơn và các vùng đã cắt bị xóa không thể khôi phục từ bản trình bày đã tối ưu. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà hình sẽ thực sự được xem hoặc xuất, thay vì áp dụng DPI thấp nhất trên toàn bộ.

## **Kiểm tra Hiệu ứng Hình ảnh**

Hiệu ứng hình ảnh được lưu trên hình ảnh được khung sử dụng. Bộ sưu tập biến đổi hình ảnh có thể chứa các hiệu ứng như điều chế alpha cố định cho độ trong suốt và độ sáng cho độ sáng và độ tương phản. Ví dụ dưới đây đọc an toàn cả hai loại hiệu ứng từ khung hình đầu tiên trên một slide:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
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
            $effect = $imageTransform->get_Item($index);

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $transparency = 100 - java_values($effect->getAmount());
                echo "Transparency: " . $transparency . PHP_EOL;
            }

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
                $luminance = $effect->getEffective();
                echo "Brightness: " . java_values($luminance->getBrightness()) . PHP_EOL;
                echo "Contrast: " . java_values($luminance->getContrast()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Các hiệu ứng này thay đổi cách hình ảnh được render trong khung; chúng không ghi đè lên byte hình ảnh nhúng gốc.

## **Khóa Hình học Khung Hình**

Cài đặt [PictureFrameLock](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframelock/) kiểm soát các thao tác chỉnh sửa nào bị vô hiệu hoá cho khung hình. Ví dụ, [setAspectRatioLocked](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) bảo toàn tỉ lệ hình dạng khi nó được thay đổi kích thước.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Khóa áp dụng cho hình dạng khung hình. Nó không buộc hình ảnh nguồn phải được tái mẫu hoặc thay đổi vĩnh viễn để có cùng tỉ lệ.

## **Điều chỉnh Giá trị StretchOffset**

Khi chế độ lấp đầy hình là stretch, các giá trị stretch‑offset trên [PictureFillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/) định nghĩa hình chữ nhật lấp đầy tương đối với hộp bao của khung hình. Các phần trăm dương tạo khoảng chèn từ cạnh, trong khi các phần trăm âm tạo khoảng mở rộng.

Điều này khác với cắt. Giá trị cắt chọn phần nào của hình nguồn hiển thị; stretch offset thay đổi hình chữ nhật mà hình lấp đầy được kéo giãn vào.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
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

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sử dụng stretch offset để bố trí lấp đầy. Sử dụng thuộc tính cắt khi mục tiêu là ẩn các cạnh của hình nguồn.

## **Lưu trữ, Kích thước Tệp và Các Xem xét Khi Xuất**

Các cân bằng chính dễ quản lý hơn khi lưu trữ hình ảnh và định dạng khung hình được xử lý riêng biệt:

- **Hình ảnh nhúng** làm cho bản trình bày tự chứa và là lựa chọn đáng tin cậy nhất để chia sẻ và render phía server, nhưng các hình raster lớn làm tăng kích thước PPTX và sử dụng bộ nhớ.
- **Hình ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình bày phụ thuộc vào các tệp bên ngoài phải vẫn tồn tại ở các đường dẫn hoặc vị trí đã lưu.
- **Cắt** ban đầu là không phá hủy. Các pixel ẩn vẫn được nhúng cho đến khi các vùng đã cắt được xóa bỏ rõ ràng hoặc loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các hình raster quá lớn, nhưng sẽ mất độ phân giải nguồn. Nên áp dụng sau khi biết kích thước hiển thị trên slide.
- **Hình SVG** nên giữ dưới dạng SVG khi việc bảo toàn vector quan trọng. Trích xuất SVG nhúng trực tiếp khi bạn cần tài nguyên vector. Các xuất slide raster luôn chuyển slide đã render thành pixel.
- **Hình ảnh lặp lại** nên tái sử dụng một tài nguyên [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) hiện có khi có thể thay vì liên tục tải cùng một tệp vào quy trình làm việc của bản trình bày.

Đối với các bản trình bày lớn, tối ưu hoá hình ảnh thường hiệu quả nhất khi thực hiện có chọn lọc: giữ logo và biểu đồ dưới dạng nội dung vector, nén ảnh chụp theo kích thước hiển thị thực tế, xóa pixel đã cắt chỉ khi không cần chỉnh sửa sau này, và tránh liên kết bên ngoài trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **Câu hỏi thường gặp**

**Khác biệt giữa khung hình và tài nguyên hình ảnh là gì?**

[PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) đại diện cho một tài nguyên hình ảnh liên kết với bản trình bày. [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) là một hình dạng trên slide hiển thị hình ảnh và lưu trữ các thuộc tính cấp khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Nên nhúng hay liên kết hình ảnh?**

Nhúng hình ảnh khi bản trình bày phải di động, lưu trữ hoặc render mà không cần tài nguyên bên ngoài. Liên kết hình ảnh chỉ khi việc giữ các tệp hình ảnh bên ngoài PPTX là có chủ đích và các vị trí bên ngoài có thể được duy trì một cách đáng tin cậy.

**Cắt ảnh có giảm kích thước PPTX không?**

Không tự nó. Cài đặt cắt thông thường ẩn các phần của hình nguồn nhưng vẫn giữ pixel bên dưới. Sử dụng [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) hoặc nén hình ảnh với việc loại bỏ vùng đã cắt khi các pixel đó có thể bị loại bỏ vĩnh viễn.

**Có thể khôi phục chất lượng hình ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster lưu trữ, và việc xóa các vùng đã cắt sẽ bỏ dữ liệu hình ảnh. Giữ bản gốc hình ảnh bên ngoài bản trình bày nếu có khả năng cần chỉnh sửa với độ phân giải cao sau này.

**Cách xử lý hình SVG?**

Giữ nội dung SVG dưới dạng SVG khi độ trung thực vector quan trọng. [SvgImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/) nhúng có thể được trích xuất trực tiếp. Render slide thành định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG như một phần của hình ảnh slide.

**Làm sao tránh cast không an toàn khi đọc slide hiện có?**

Kiểm tra loại hình dạng trước khi sử dụng các thành viên riêng của khung hình. Kiểm tra `java_instanceof` đối với [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) tránh cast không hợp lệ và cho phép mã xử lý các slide không chứa khung hình.