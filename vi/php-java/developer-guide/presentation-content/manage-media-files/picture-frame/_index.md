---
title: Quản lý khung hình trong các bài thuyết trình bằng PHP
linktitle: Khung Hình
type: docs
weight: 10
url: /vi/php-java/picture-frame/
keywords:
- khung hình
- thêm khung hình
- tạo khung hình
- thêm hình ảnh
- tạo hình ảnh
- trích xuất hình ảnh
- hình ảnh raster
- hình ảnh vector
- cắt hình ảnh
- vùng đã cắt
- thuộc tính StretchOff
- định dạng khung hình
- thuộc tính khung hình
- tỉ lệ tương đối
- hiệu ứng hình ảnh
- tỷ lệ khung hình
- độ trong suốt hình ảnh
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Thêm khung hình vào các bản thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho PHP qua Java. Tối ưu quy trình làm việc và cải thiện thiết kế slide."
---
## **Giới thiệu**

Khung hình là một hình dạng chứa một hình ảnh—giống như một bức tranh trong khung.

Bạn có thể thêm một hình ảnh vào slide thông qua khung hình. Bằng cách này, bạn có thể định dạng hình ảnh bằng cách định dạng khung hình.

{{% alert title="Tip" color="primary" %}} 
Aspose cung cấp các công cụ chuyển đổi miễn phí—[JPEG sang PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG sang PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—giúp người dùng tạo bản thuyết trình nhanh chóng từ hình ảnh. 
{{% /alert %}} 

## **Tạo khung hình**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) bằng cách thêm một hình ảnh vào [ImageCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagecollection/) liên kết với đối tượng presentation sẽ được sử dụng để điền vào hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức `addPictureFrame` được cung cấp bởi đối tượng shape liên kết với slide đã tham chiếu.
6. Thêm một khung hình (chứa hình ảnh) vào slide.
7. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP này cho bạn thấy cách tạo một khung hình:

```php
  # Khởi tạo lớp Presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Khởi tạo lớp Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Thêm một khung hình với chiều cao và chiều rộng tương đương của hình ảnh
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Ghi tệp PPTX ra ổ đĩa
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
Khung hình cho phép bạn nhanh chóng tạo các slide thuyết trình dựa trên hình ảnh. Khi kết hợp khung hình với các tùy chọn lưu của Aspose.Slides, bạn có thể thao tác các hoạt động nhập/xuất để chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Bạn có thể muốn xem các trang sau: chuyển đổi [hình ảnh sang JPG](https://products.aspose.com/slides/vi/php-java/conversion/image-to-jpg/); chuyển đổi [JPG sang hình ảnh](https://products.aspose.com/slides/vi/php-java/conversion/jpg-to-image/); chuyển đổi [JPG sang PNG](https://products.aspose.com/slides/vi/php-java/conversion/jpg-to-png/), chuyển đổi [PNG sang JPG](https://products.aspose.com/slides/vi/php-java/conversion/png-to-jpg/); chuyển đổi [PNG sang SVG](https://products.aspose.com/slides/vi/php-java/conversion/png-to-svg/), chuyển đổi [SVG sang PNG](https://products.aspose.com/slides/vi/php-java/conversion/svg-to-png/). 
{{% /alert %}}

## **Tạo khung hình với tỉ lệ tương đối**

Bằng cách thay đổi tỉ lệ tương đối của hình ảnh, bạn có thể tạo một khung hình phức tạp hơn. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Thêm một hình ảnh vào bộ sưu tập hình ảnh của bản trình bày.
4. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) bằng cách thêm một hình ảnh vào [ImageCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagecollection/) liên kết với đối tượng presentation sẽ được sử dụng để điền vào hình dạng.
5. Xác định chiều rộng và chiều cao tương đối của hình ảnh trong khung hình.
6. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP này cho bạn thấy cách tạo khung hình với tỉ lệ tương đối:

```php
  # Khởi tạo lớp Presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Khởi tạo lớp Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Thêm khung hình với chiều cao và chiều rộng tương đương của hình ảnh
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Thiết lập tỉ lệ chiều cao và chiều rộng tương đối
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Ghi tệp PPTX ra đĩa
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Trích xuất hình ảnh raster từ khung hình**

Bạn có thể trích xuất hình ảnh raster từ các đối tượng [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) và lưu chúng dưới dạng PNG, JPG và các định dạng khác. Ví dụ mã dưới đây minh họa cách trích xuất một hình ảnh từ tài liệu “sample.pptx” và lưu nó dưới dạng PNG.

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **Trích xuất hình ảnh SVG từ khung hình**

Khi một bản trình bày chứa đồ họa SVG được đặt bên trong các hình dạng [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/), Aspose.Slides for PHP via Java cho phép bạn truy xuất các hình ảnh vector gốc với độ chính xác đầy đủ. Bằng cách duyệt bộ sưu tập hình dạng của slide, bạn có thể xác định mỗi [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/), kiểm tra xem [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) nền có chứa nội dung SVG hay không, và sau đó lưu hình ảnh đó vào đĩa hoặc luồng ở định dạng SVG gốc.

Ví dụ mã sau cho thấy cách trích xuất một hình ảnh SVG từ một khung hình:

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Lấy độ trong suốt của hình ảnh**

Aspose.Slides cho phép bạn lấy hiệu ứng trong suốt được áp dụng cho một hình ảnh. Mã PHP này minh họa thao tác:

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **Định dạng khung hình**

Aspose.Slides cung cấp nhiều tùy chọn định dạng có thể áp dụng cho một khung hình. Bằng cách sử dụng các tùy chọn này, bạn có thể thay đổi khung hình để đáp ứng các yêu cầu cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) bằng cách thêm một hình ảnh vào [ImageCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagecollection/) liên kết với đối tượng presentation sẽ được sử dụng để điền vào hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một `PictureFrame` dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức [addPictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addpictureframe/) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/) liên kết với slide đã tham chiếu.
6. Thêm khung hình (chứa hình ảnh) vào slide.
7. Đặt màu đường viền cho khung hình.
8. Đặt độ rộng đường viền cho khung hình.
9. Xoay khung hình bằng cách cung cấp một giá trị dương hoặc âm. 
   * Giá trị dương xoay hình ảnh theo chiều kim đồng hồ. 
   * Giá trị âm xoay hình ảnh ngược chiều kim đồng hồ.
10. Thêm khung hình (chứa hình ảnh) vào slide.
11. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP này minh họa quy trình định dạng khung hình:

```php
  # Khởi tạo lớp Presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Khởi tạo lớp Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Thêm khung hình với chiều cao và chiều rộng tương đương của hình ảnh
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Áp dụng một số định dạng cho PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Ghi tệp PPTX ra đĩa
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}} 
Aspose mới đây đã phát triển một [công cụ Collage Maker miễn phí](https://products.aspose.app/slides/vi/collage). Nếu bạn cần [ghép JPG/JPEG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG, hoặc [tạo lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), bạn có thể sử dụng dịch vụ này. 
{{% /alert %}}

## **Thêm hình ảnh dưới dạng liên kết**

Để tránh kích thước bản trình bày quá lớn, bạn có thể thêm hình ảnh (hoặc video) thông qua liên kết thay vì nhúng tệp trực tiếp vào bản trình bày. Mã PHP này cho bạn thấy cách thêm hình ảnh và video vào một placeholder:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Cắt hình ảnh**

Mã PHP này cho bạn thấy cách cắt một hình ảnh hiện có trên slide:

```php
  $pres = new Presentation();
  # Tạo đối tượng hình ảnh mới
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Thêm PictureFrame vào slide
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Cắt hình ảnh (giá trị phần trăm)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Lưu kết quả
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Xóa vùng đã cắt của khung hình**

Nếu bạn muốn xóa các vùng đã cắt của hình ảnh nằm trong khung, bạn có thể sử dụng phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Phương thức này trả về hình ảnh đã cắt hoặc hình ảnh gốc nếu không cần cắt.

Mã PHP này minh họa thao tác:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Lấy PictureFrame từ slide đầu tiên
    $picFrame = $slide->getShapes()->get_Item(0);
    # Xóa các vùng đã cắt của hình ảnh PictureFrame và trả về hình ảnh đã cắt
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Lưu kết quả
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
Phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) sẽ thêm hình ảnh đã cắt vào bộ sưu tập hình ảnh của bản trình bày. Nếu hình ảnh chỉ được sử dụng trong [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) đã xử lý, cấu hình này có thể giảm kích thước bản trình bày. Ngược lại, số lượng hình ảnh trong bản trình bày kết quả sẽ tăng.

Phương thức này chuyển các tập tin metafile WMF/EMF thành hình ảnh PNG raster trong quá trình cắt. 
{{% /alert %}}

## **Nén hình ảnh**

Bạn có thể nén một hình ảnh trong bản trình bày bằng phương thức [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_). Phương thức này nén hình ảnh bằng cách giảm kích thước dựa trên kích thước hình dạng và độ phân giải đã chỉ định, với tùy chọn xóa các vùng đã cắt.

Nó điều chỉnh kích thước và độ phân giải của hình tương tự như tính năng **Picture Format -> Compress Pictures -> Resolution** của PowerPoint.

Các ví dụ PHP dưới đây minh họa cách nén hình ảnh trong bản trình bày bằng cách chỉ định độ phân giải mục tiêu và tùy chọn xóa các vùng đã cắt:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Nén hình ảnh với độ phân giải mục tiêu 150 DPI (độ phân giải Web) và xóa các vùng đã cắt.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Kiểm tra kết quả nén.
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hoặc sử dụng trực tiếp một giá trị DPI tùy chỉnh:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Nén hình ảnh tới 150 DPI (độ phân giải web), xóa các vùng đã cắt.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Phương thức chuyển đổi hình ảnh sang độ phân giải thấp hơn dựa trên kích thước hình dạng và DPI cung cấp. Các khu vực đã cắt cũng có thể bị xóa để tối ưu kích thước tệp. 
Nếu hình ảnh là metafile (WMF/EMF) hoặc SVG, việc nén sẽ không được áp dụng. Ngoài ra, chất lượng JPEG được giữ nguyên hoặc giảm nhẹ dựa trên độ phân giải, tương tự như cách PowerPoint xử lý JPEG độ phân giải cao. 
{{% /alert %}}

## **Khóa tỉ lệ khung hình**

Nếu bạn muốn một hình dạng chứa hình ảnh giữ tỉ lệ khung hình ngay cả khi thay đổi kích thước hình ảnh, bạn có thể sử dụng phương thức [setAspectRatioLocked](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) để đặt cài đặt *Lock Aspect Ratio*.

Mã PHP này cho bạn thấy cách khóa tỉ lệ khung hình:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # Đặt hình dạng để bảo toàn tỷ lệ khung hình khi thay đổi kích thước
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
Cài đặt *Lock Aspect Ratio* này chỉ giữ tỉ lệ của hình dạng mà không ảnh hưởng tới hình ảnh bên trong. 
{{% /alert %}}

## **Sử dụng thuộc tính StretchOff**

Bằng cách sử dụng các phương thức [setStretchOffsetLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) và [setStretchOffsetBottom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) từ lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/), bạn có thể chỉ định một hình chữ nhật lấp đầy.

Khi được chỉ định kéo dài cho một hình ảnh, một hình chữ nhật nguồn sẽ được tỷ lệ để vừa với hình chữ nhật lấp đầy đã chỉ định. Mỗi cạnh của hình chữ nhật lấp đầy được xác định bằng một phần trăm offset từ cạnh tương ứng của hộp bao quanh hình dạng. Phần trăm dương xác định một chèn vào trong khi phần trăm âm xác định một mở rộng ra ngoài.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm một hình chữ nhật `AutoShape`. 
4. Tạo một hình ảnh.
5. Đặt loại lấp đầy cho hình dạng.
6. Đặt chế độ lấp đầy hình ảnh cho hình dạng.
7. Thêm một hình ảnh để lấp đầy hình dạng.
8. Xác định offset của hình ảnh từ cạnh tương ứng của hộp bao quanh hình dạng
9. Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Mã PHP này minh họa quy trình sử dụng thuộc tính StretchOff:

```php
  # Khởi tạo lớp Presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $slide = $pres->getSlides()->get_Item(0);
    # Khởi tạo lớp ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Thêm một AutoShape được đặt thành Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Đặt loại tô màu cho hình dạng
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Đặt chế độ tô ảnh cho hình dạng
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Đặt hình ảnh để lấp đầy hình dạng
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Xác định độ lệch của hình ảnh từ cạnh tương ứng của hộp bao quanh hình dạng
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # Ghi tệp PPTX ra đĩa
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Làm cách nào để tôi biết các định dạng hình ảnh nào được hỗ trợ cho PictureFrame?**

Aspose.Slides hỗ trợ cả hình ảnh raster (PNG, JPEG, BMP, GIF, v.v.) và hình ảnh vector (ví dụ, SVG) thông qua đối tượng hình ảnh được gán cho một [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/). Danh sách các định dạng được hỗ trợ thường trùng khớp với khả năng của engine chuyển đổi slide và hình ảnh.

**Việc thêm hàng chục hình ảnh lớn sẽ ảnh hưởng như thế nào đến kích thước và hiệu năng của PPTX?**

Nhúng hình ảnh lớn làm tăng kích thước tệp và mức sử dụng bộ nhớ; liên kết hình ảnh giúp giảm kích thước bản trình bày nhưng yêu cầu các tệp bên ngoài phải luôn có sẵn. Aspose.Slides cung cấp khả năng thêm hình ảnh bằng liên kết để giảm kích thước tệp.

**Làm sao tôi có thể khóa một đối tượng hình ảnh để tránh di chuyển/đổi kích thước vô tình?**

Sử dụng [shape locks](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/getpictureframelock/) cho một [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) (ví dụ, vô hiệu hoá di chuyển hoặc thay đổi kích thước). Cơ chế khóa này được hỗ trợ cho nhiều loại hình dạng, bao gồm cả [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/).

**Độ chính xác vector SVG có được giữ nguyên khi xuất bản trình bày sang PDF/hình ảnh không?**

Aspose.Slides cho phép trích xuất SVG từ một [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) dưới dạng vector gốc. Khi [xuất sang PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/) hoặc [các định dạng raster](/slides/vi/php-java/convert-powerpoint-to-png/), kết quả có thể được raster hóa tùy thuộc vào cài đặt xuất; thực tế rằng SVG gốc được lưu dưới dạng vector được xác nhận qua hành vi trích xuất.