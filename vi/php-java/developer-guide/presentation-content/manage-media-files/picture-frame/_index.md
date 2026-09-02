---
title: Quản lý Khung Hình trong Bản Trình Chiếu bằng PHP
linktitle: Khung Hình
type: docs
weight: 10
url: /vi/php-java/picture-frame/
keywords:
- khung hình
- thêm khung hình
- tạo khung hình
- ảnh nhúng
- ảnh liên kết
- trích xuất ảnh
- ảnh raster
- ảnh SVG
- cắt ảnh
- xóa các vùng đã cắt
- nén ảnh
- StretchOffset
- định dạng khung hình
- tỷ lệ tương đối
- hiệu ứng ảnh
- tỷ lệ khung
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tạo, định dạng, liên kết, cắt, trích xuất và nén khung ảnh trong bản trình chiếu với Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Khung ảnh là một hình dạng trên slide hiển thị hình ảnh. Trong Aspose.Slides, tài nguyên hình ảnh và hình dạng hiển thị nó là các đối tượng riêng biệt: một [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) sở hữu các tài nguyên hình ảnh được nhúng thông qua [ImageCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagecollection/), trong khi một [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) điều khiển vị trí, kích thước, định dạng đường viền, xoay, cắt, hiệu ứng ảnh và các cài đặt cấp khung khác.

Sự tách biệt này hữu ích khi cùng một hình ảnh được hiển thị nhiều lần. Thêm hình ảnh vào bản trình chiếu một lần, giữ lại [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/), và sử dụng tài nguyên hình ảnh đó khi tạo khung ảnh.

Khung ảnh có thể chứa các hình ảnh raster như PNG hoặc JPEG và các hình ảnh vector SVG. Chúng cũng có thể tham chiếu tới ảnh liên kết thay vì lưu trữ byte ảnh trong bản trình chiếu. Lựa chọn này ảnh hưởng đến tính di động, kích thước tệp, việc trích xuất và hành vi xuất, vì vậy nên quyết định cách lưu trữ ảnh trước khi áp dụng định dạng hoặc tối ưu hóa.

## **Thêm và Định dạng Ảnh Nhúng**

Đối với một ảnh nhúng, thêm dữ liệu ảnh vào bản trình chiếu và tạo khung ảnh bằng [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addpictureframe/). Ảnh trở thành một phần của gói bản trình chiếu, vì vậy bản trình chiếu vẫn tự chứa khi được chuyển sang máy tính khác.

Ví dụ sau thêm một ảnh JPEG, tạo khung với kích thước gốc của ảnh, và áp dụng định dạng đường viền cũng như xoay:

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

Khung ảnh điều khiển hình học hiển thị; việc thay đổi kích thước khung không làm thay đổi kích thước pixel gốc được lưu trong tài nguyên ảnh nhúng. Sự khác biệt này trở nên quan trọng khi cắt hoặc nén ảnh sau này.

## **Sử dụng Tỷ lệ Tương đối**

[PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) cung cấp khả năng điều chỉnh tỷ lệ rộng và cao tương đối cho khung thông qua [setRelativeScaleWidth](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/setrelativescalewidth/) và [setRelativeScaleHeight](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Giá trị `1.0` tương đương với 100 % kích thước ảnh gốc. Tỷ lệ tương đối hữu ích khi quy trình cần giữ mối quan hệ với kích thước ảnh nguồn thay vì tính toán kích thước cuối cùng một cách thủ công.

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

Tỷ lệ tương đối thay đổi các thiết lập tỷ lệ của khung; nó không tái mẫu hoặc nén ảnh nhúng.

## **Ảnh Nhúng và Ảnh Liên kết**

Một ảnh nhúng lưu dữ liệu ảnh bên trong bản trình chiếu và do đó là lựa chọn an toàn nhất cho tính di động và việc hiển thị dự đoán được. Một ảnh liên kết lưu vị trí bên ngoài thông qua phương thức [Picture::setLinkPathLong](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picture/setlinkpathlong/) thay vì nhúng dữ liệu ảnh theo cùng cách.

Ảnh liên kết có thể giảm lượng dữ liệu ảnh lưu trong PPTX, nhưng chúng tạo ra một phụ thuộc bên ngoài. Tệp liên kết phải vẫn có thể truy cập được bởi ứng dụng mở hoặc hiển thị bản trình chiếu. Nếu đường dẫn thay đổi, tệp bị di chuyển, hoặc tài nguyên không khả dụng, ảnh liên kết có thể không hiển thị như mong đợi. Đối với các bản trình chiếu cần được gửi email, lưu trữ, hoặc hiển thị trong môi trường cô lập, ảnh nhúng thường đáng tin cậy hơn.

### **Thêm Ảnh Liên kết**

Ví dụ sau tạo một khung ảnh và trỏ tới một tệp ảnh cục bộ. Nó chỉ xử lý việc liên kết ảnh; liên kết video là một quy trình đa phương tiện riêng và không được trộn vào ví dụ này.

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

Sử dụng liên kết khi việc quản lý tệp bên ngoài là có chủ đích. Đừng dùng chúng chỉ để thay thế nén: một PPTX nhỏ với các phụ thuộc ảnh bị hỏng thường kém hữu ích hơn so với một bản trình chiếu tự chứa lớn hơn.

## **Trích xuất Ảnh từ Khung Ảnh**

Trước khi trích xuất ảnh từ một bản trình chiếu hiện có, hãy kiểm tra xem hình dạng thực sự là một [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) và nó có chứa ảnh nhúng không. Các khung ảnh liên kết có thể không chứa byte ảnh có thể trích xuất theo cùng cách.

### **Trích xuất Ảnh Raster**

API ảnh hiện đại sử dụng [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/) trực tiếp. Ví dụ sau tìm ảnh raster nhúng đầu tiên trên một slide và lưu nó dưới dạng PNG:

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

Lưu qua [IImage::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/#save) sẽ chuyển đổi ảnh đã trích xuất sang định dạng đầu ra được yêu cầu. Nếu bạn cần byte đã mã hoá lưu trong bản trình chiếu thay vì tệp raster đã chuyển đổi, hãy sử dụng dữ liệu nhị phân của tài nguyên ảnh.

### **Trích xuất Ảnh SVG**

Đối với ảnh SVG, [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) cung cấp một đối tượng [SvgImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/). Điều này cho phép bạn lấy dữ liệu SVG trực tiếp thay vì raster hoá ảnh trước.

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

Giữ nội dung SVG dưới dạng SVG bảo tồn nguồn vector bên trong bản trình chiếu. Các xuất raster như PNG hoặc JPEG buộc phải render nội dung vector thành pixel. Xuất slide dưới dạng PDF hoặc SVG cũng là một thao tác render, vì vậy đồ họa xuất không nên được coi là bản sao byte‑for‑byte của SVG nhúng gốc; sử dụng dữ liệu [SvgImage::getSvgData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/getsvgdata/) khi cần tài nguyên vector gốc.

## **Cắt Ảnh**

Cắt thay đổi phần nào của ảnh hiển thị bên trong khung. Các giá trị cắt trên [PictureFillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/) là phần trăm của kích thước ảnh nguồn. Cắt không xóa ngay các pixel ẩn khỏi ảnh nhúng; nó chỉ thay đổi vùng hiển thị.

Ví dụ sau tìm một khung ảnh một cách an toàn và áp dụng các giá trị cắt:

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

Vì dữ liệu ảnh ẩn vẫn còn tồn tại, việc cắt có thể được thay đổi sau mà không mất pixel gốc. Nếu kích thước tệp quan trọng hơn tính có thể khôi phục, các vùng đã cắt có thể được loại bỏ thực tế như mô tả trong phần tiếp theo.

## **Xóa Dữ liệu Ảnh Đã Cắt**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) loại bỏ dữ liệu ảnh nằm ngoài vùng cắt hiện tại và trả về tài nguyên ảnh kết quả. Điều này có thể giảm kích thước tệp, nhưng là một tối ưu hóa phá hủy: sau khi bản trình chiếu được lưu, các pixel đã bị xóa không còn khả dụng cho thao tác mở rộng lại.

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

Phương pháp có thể thêm một tài nguyên ảnh mới vào bản trình chiếu. Nếu ảnh gốc cũng được dùng bởi các khung ảnh khác, những khung đó vẫn cần tài nguyên hiện có, vì vậy việc xóa các vùng đã cắt không nhất thiết giảm tổng số ảnh. Cắt nội dung WMF hoặc EMF bằng phương pháp này sẽ raster hoá kết quả đã cắt thành PNG.

## **Nén Ảnh Raster**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) giảm độ phân giải ảnh raster so với kích thước mà ảnh được hiển thị. Nó cũng có thể loại bỏ các vùng đã cắt trong cùng một thao tác. Phương pháp trả về `true` khi ảnh đã được thay đổi kích thước hoặc cắt và `false` khi không cần thay đổi nào.

Sử dụng một giá trị [PicturesCompression](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturescompression/) đã định nghĩa trước khi độ phân giải mục tiêu tiêu chuẩn là đủ:

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

Một giá trị DPI dương tùy chỉnh có thể được truyền thay cho giá trị đã định nghĩa trước khi cần một mục tiêu cụ thể.

Nén được thiết kế cho ảnh raster. Nội dung SVG và metafile không bị giảm bởi quy trình nén raster này. Hãy nhớ rằng độ phân giải thấp hơn và các vùng đã cắt bị xóa không thể khôi phục từ bản trình chiếu đã tối ưu. Chọn độ phân giải mục tiêu dựa trên kích thước lớn nhất mà ảnh sẽ thực sự được xem hoặc xuất, thay vì áp dụng DPI thấp nhất trên toàn bộ.

## **Quản lý Hiệu ứng Biến đổi Ảnh**

Đối với một quy trình hoàn chỉnh bao gồm độ sáng, độ tương phản, chuyển đổi màu, làm mờ, hiệu ứng alpha, chuỗi có thứ tự, kiểm tra, loại bỏ và xác minh vòng quay, xem [Image Transform Effects](/slides/vi/php-java/image-transform-effects/).

## **Khóa Hình học Khung Ảnh**

Cài đặt [PictureFrameLock](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframelock/) kiểm soát các thao tác chỉnh sửa nào bị vô hiệu hoá cho một khung ảnh. Ví dụ, [setAspectRatioLocked](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) giữ tỉ lệ hình học của hình dạng khi nó được thay đổi kích thước.

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

Khóa áp dụng cho hình dạng khung ảnh. Nó không buộc ảnh nguồn phải được tái mẫu hoặc thay đổi vĩnh viễn theo cùng tỉ lệ.

## **Điều chỉnh Giá trị StretchOffset**

Khi chế độ lấp đầy ảnh là stretch, các giá trị stretch‑offset trên [PictureFillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/) xác định hình chữ nhật lấp đầy tương đối với hộp bao của khung ảnh. Phần trăm dương tạo một inset từ cạnh, trong khi phần trăm âm tạo một outset.

Điều này khác với cắt. Giá trị cắt chọn phần nào của ảnh nguồn hiển thị; stretch offset thay đổi hình chữ nhật mà ảnh lấp đầy được kéo dài vào.

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

Sử dụng stretch offset để định vị lấp đầy. Sử dụng thuộc tính cắt khi mục tiêu là ẩn các cạnh ảnh nguồn.

## **Lưu trữ, Kích thước Tệp và Các Xem xét Khi Xuất**

Các cân bằng chính dễ quản lý hơn khi lưu trữ ảnh và định dạng khung ảnh được tách riêng:

- **Ảnh nhúng** làm cho bản trình chiếu tự chứa và là lựa chọn đáng tin cậy nhất cho việc chia sẻ và render phía máy chủ, nhưng ảnh raster lớn làm tăng kích thước PPTX và sử dụng bộ nhớ.
- **Ảnh liên kết** có thể giữ gói nhỏ hơn, nhưng bản trình chiếu phụ thuộc vào các tệp bên ngoài vẫn còn tồn tại tại các đường dẫn hoặc vị trí đã lưu.
- **Cắt** ban đầu là không phá hủy. Các pixel ẩn vẫn được nhúng cho đến khi các vùng đã cắt được xóa rõ ràng hoặc loại bỏ trong quá trình nén.
- **Nén** có thể giảm đáng kể kích thước tệp cho các ảnh raster quá lớn, nhưng nó đánh đổi độ phân giải nguồn. Nên áp dụng sau khi biết kích thước hiển thị trên slide.
- **Ảnh SVG** nên giữ dưới dạng SVG khi việc bảo tồn vector quan trọng. Trích xuất SVG nhúng trực tiếp khi cần tài nguyên vector. Các xuất slide raster luôn chuyển đổi slide đã render thành pixel.
- **Ảnh lặp lại** nên tái sử dụng tài nguyên [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) hiện có khi có thể thay vì liên tục tải cùng một tệp vào quy trình làm việc.

Đối với các bản trình chiếu lớn, tối ưu hóa ảnh thường hiệu quả nhất khi thực hiện có chọn lọc: giữ logo và sơ đồ dưới dạng nội dung vector, nén ảnh chụp theo kích thước hiển thị thực tế, loại bỏ pixel đã cắt chỉ khi không cần chỉnh sửa sau này, và tránh liên kết bên ngoài trừ khi quản lý phụ thuộc là một phần của thiết kế triển khai.

## **Câu hỏi thường gặp**

**Khác biệt giữa khung ảnh và tài nguyên ảnh là gì?**

[PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) đại diện cho một tài nguyên ảnh liên kết với bản trình chiếu. [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) là một hình dạng trên slide hiển thị ảnh và lưu trữ các cài đặt cấp khung như kích thước, xoay, giá trị cắt, hiệu ứng và khóa.

**Nên nhúng hay liên kết ảnh?**

Nhúng ảnh khi bản trình chiếu phải di động, lưu trữ hoặc render mà không cần truy cập vào tài nguyên bên ngoài. Liên kết ảnh chỉ khi việc giữ các tệp ảnh ngoài PPTX là có chủ đích và các vị trí bên ngoài có thể được duy trì một cách đáng tin cậy.

**Cắt ảnh có giảm kích thước PPTX không?**

Không tự động. Cài đặt cắt bình thường ẩn các phần của ảnh nguồn nhưng vẫn giữ pixel nền. Sử dụng [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) hoặc nén ảnh với việc loại bỏ vùng đã cắt khi các pixel đó có thể bị loại bỏ vĩnh viễn.

**Có thể khôi phục chất lượng ảnh sau khi nén không?**

Không. Nén có thể giảm độ phân giải raster lưu trữ, và việc loại bỏ các vùng đã cắt sẽ xóa dữ liệu ảnh. Giữ ảnh nguồn gốc bên ngoài bản trình chiếu nếu có thể sẽ cần chỉnh sửa với độ phân giải cao sau này.

**Nên xử lý ảnh SVG như thế nào?**

Giữ nội dung SVG dưới dạng SVG khi độ chính xác vector quan trọng. [SvgImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/) nhúng có thể được trích xuất trực tiếp. Render slide thành định dạng raster như PNG hoặc JPEG sẽ raster hoá SVG thành phần của ảnh slide.

**Làm sao tránh lỗi ép kiểu không an toàn khi đọc slide hiện có?**

Kiểm tra kiểu hình dạng trước khi sử dụng các thành viên đặc thù của khung ảnh. Kiểm tra `java_instanceof` với [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) tránh các ép kiểu không hợp lệ và cho phép mã xử lý các slide không chứa khung ảnh.