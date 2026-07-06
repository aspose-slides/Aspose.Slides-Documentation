---
title: Quản lý Khung Ảnh trong Bản Trình Chiếu bằng PHP
linktitle: Khung Ảnh
type: docs
weight: 10
url: /vi/php-java/picture-frame/
keywords:
- khung ảnh
- thêm khung ảnh
- tạo khung ảnh
- thêm hình ảnh
- tạo hình ảnh
- trích xuất hình ảnh
- hình ảnh raster
- hình ảnh vector
- cắt hình ảnh
- vùng đã cắt
- thuộc tính StretchOff
- định dạng khung ảnh
- thuộc tính khung ảnh
- tỷ lệ tương đối
- hiệu ứng hình ảnh
- tỷ lệ khung hình
- độ trong suốt của hình ảnh
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Thêm khung ảnh vào các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho PHP qua Java. Tối ưu quy trình làm việc và nâng cao thiết kế slide."
---
## **Giới thiệu**

Khung ảnh là một hình dạng chứa một hình ảnh—giống như một bức tranh trong khung. 

Bạn có thể thêm hình ảnh vào một slide thông qua khung ảnh. Bằng cách này, bạn có thể định dạng hình ảnh bằng cách định dạng khung ảnh.

{{% alert  title="Tip" color="primary" %}} 
Aspose cung cấp các công cụ chuyển đổi miễn phí—[JPEG sang PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG sang PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép người dùng tạo bản trình chiếu nhanh chóng từ hình ảnh. 
{{% /alert %}} 

## **Tạo khung ảnh**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) bằng cách thêm một hình ảnh vào [ImageCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagecollection/) liên kết với đối tượng presentation sẽ được dùng để làm nền cho hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức `addPictureFrame` được cung cấp bởi đối tượng shape liên kết với slide đã tham chiếu.
6. Thêm một khung ảnh (chứa hình ảnh) vào slide.
7. Ghi bản trình chiếu đã chỉnh sửa thành tệp PPTX.

Đoạn mã PHP này cho thấy cách tạo khung ảnh:

```php
  # Khởi tạo lớp Presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Khởi tạo lớp Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Thêm khung ảnh với chiều cao và chiều rộng bằng với ảnh
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Ghi tệp PPTX ra đĩa
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
Khung ảnh cho phép bạn nhanh chóng tạo các slide trình chiếu dựa trên hình ảnh. Khi bạn kết hợp khung ảnh với các tùy chọn lưu của Aspose.Slides, bạn có thể thao tác các thao tác nhập/xuất để chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Bạn có thể muốn xem các trang này: chuyển đổi [hình ảnh sang JPG](https://products.aspose.com/slides/vi/php-java/conversion/image-to-jpg/); chuyển đổi [JPG sang hình ảnh](https://products.aspose.com/slides/vi/php-java/conversion/jpg-to-image/); chuyển đổi [JPG sang PNG](https://products.aspose.com/slides/vi/php-java/conversion/jpg-to-png/), chuyển đổi [PNG sang JPG](https://products.aspose.com/slides/vi/php-java/conversion/png-to-jpg/); chuyển đổi [PNG sang SVG](https://products.aspose.com/slides/vi/php-java/conversion/png-to-svg/), chuyển đổi [SVG sang PNG](https://products.aspose.com/slides/vi/php-java/conversion/svg-to-png/).
{{% /alert %}} 

## **Tạo khung ảnh với tỷ lệ tương đối**

Bằng cách thay đổi tỷ lệ thu phóng tương đối của hình ảnh, bạn có thể tạo một khung ảnh phức tạp hơn. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Thêm một hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu.
4. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) bằng cách thêm một hình ảnh vào [ImageCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagecollection/) liên kết với đối tượng presentation sẽ được dùng để làm nền cho hình dạng.
5. Xác định chiều rộng và chiều cao tương đối của hình ảnh trong khung ảnh.
6. Ghi bản trình chiếu đã chỉnh sửa thành tệp PPTX.

Đoạn mã PHP này cho thấy cách tạo khung ảnh với tỷ lệ tương đối:

```php
  # Khởi tạo lớp Presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Khởi tạo lớp Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Thêm Khung Ảnh với chiều cao và chiều rộng tương đương với Hình ảnh
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Đặt tỷ lệ thu phóng tương đối cho chiều rộng và chiều cao
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

## **Trích xuất hình ảnh raster từ khung ảnh**

Bạn có thể trích xuất hình ảnh raster từ các đối tượng [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) và lưu chúng ở định dạng PNG, JPG và các định dạng khác. Ví dụ mã bên dưới minh họa cách trích xuất một hình ảnh từ tài liệu “sample.pptx” và lưu nó ở định dạng PNG.

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

## **Trích xuất hình ảnh SVG từ khung ảnh**

Khi một bản trình chiếu chứa đồ họa SVG đặt bên trong các hình dạng [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/), Aspose.Slides cho PHP qua Java cho phép bạn lấy lại các hình ảnh vector gốc với độ chính xác đầy đủ. Bằng cách duyệt qua bộ sưu tập hình dạng của slide, bạn có thể xác định từng [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/), kiểm tra xem [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) bên dưới có chứa nội dung SVG không, và sau đó lưu hình ảnh đó vào đĩa hoặc luồng ở định dạng SVG gốc.

Đoạn mã sau minh họa cách trích xuất một hình ảnh SVG từ khung ảnh:

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

Aspose.Slides cho phép bạn lấy hiệu ứng trong suốt được áp dụng cho một hình ảnh. Đoạn mã PHP này minh họa thao tác:

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

## **Lấy độ sáng và độ tương phản của hình ảnh**

Aspose.Slides cho phép bạn lấy độ sáng và độ tương phản được áp dụng cho một hình ảnh. Lớp [Luminance](https://reference.aspose.com/slides/vi/php-java/aspose.slides/luminance/) đại diện cho hiệu ứng biến đổi này.

Đoạn mã PHP này minh họa cách lấy cài đặt độ sáng và độ tương phản từ một khung ảnh:

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **Định dạng khung ảnh**

Aspose.Slides cung cấp nhiều tùy chọn định dạng có thể áp dụng cho một khung ảnh. Sử dụng những tùy chọn này, bạn có thể chỉnh sửa khung ảnh để phù hợp với yêu cầu cụ thể.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó. 
3. Tạo một đối tượng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) bằng cách thêm một hình ảnh vào [ImageCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagecollection/) liên kết với đối tượng presentation sẽ được dùng để làm nền cho hình dạng.
4. Xác định chiều rộng và chiều cao của hình ảnh.
5. Tạo một `PictureFrame` dựa trên chiều rộng và chiều cao của hình ảnh thông qua phương thức [addPictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addpictureframe/) được cung cấp bởi đối tượng [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/) liên kết với slide đã tham chiếu.
6. Thêm khung ảnh (chứa hình ảnh) vào slide.
7. Đặt màu đường viền cho khung ảnh.
8. Đặt độ rộng đường viền cho khung ảnh.
9. Xoay khung ảnh bằng cách cung cấp giá trị dương hoặc âm.  
   * Giá trị dương sẽ xoay hình ảnh theo chiều kim đồng hồ.  
   * Giá trị âm sẽ xoay hình ảnh ngược chiều kim đồng hồ.
10. Thêm khung ảnh (chứa hình ảnh) vào slide.
11. Ghi bản trình chiếu đã chỉnh sửa thành tệp PPTX.

Đoạn mã PHP này minh họa quy trình định dạng khung ảnh:

```php
  # Khởi tạo lớp Presentation đại diện cho file PPTX
  $pres = new Presentation();
  try {
    # Lấy slide đầu tiên
    $sld = $pres->getSlides()->get_Item(0);
    # Khởi tạo lớp Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Thêm Khung Ảnh với chiều cao và chiều rộng tương đương với Hình ảnh
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Áp dụng một số định dạng cho PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Ghi file PPTX ra đĩa
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}
Aspose gần đây đã phát triển một [trình tạo Collage miễn phí](https://products.aspose.app/slides/vi/collage). Nếu bạn cần [gộp ảnh JPG/JPEG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG, [tạo lưới từ ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), bạn có thể sử dụng dịch vụ này. 
{{% /alert %}}

## **Thêm hình ảnh dưới dạng liên kết**

Để tránh kích thước bản trình chiếu lớn, bạn có thể thêm hình ảnh (hoặc video) thông qua liên kết thay vì nhúng tệp trực tiếp vào bản trình chiếu. Đoạn mã PHP này cho thấy cách thêm hình ảnh và video vào một placeholder:

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

## **Cắt ảnh**

Đoạn mã PHP này cho thấy cách cắt một hình ảnh hiện có trên slide:

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
    # Thêm một PictureFrame vào Slide
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

## **Xóa vùng đã cắt của hình ảnh**

Nếu bạn muốn xóa các vùng đã cắt của một hình ảnh chứa trong khung, bạn có thể sử dụng phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Phương thức này trả về hình ảnh đã cắt hoặc hình ảnh gốc nếu không cần cắt.

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
Phương thức [deletePictureCroppedAreas()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) sẽ thêm hình ảnh đã cắt vào bộ sưu tập hình ảnh của bản trình chiếu. Nếu hình ảnh chỉ được sử dụng trong [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) đã xử lý, cấu hình này có thể giảm kích thước bản trình chiếu. Ngược lại, số lượng hình ảnh trong bản trình chiếu kết quả sẽ tăng.

Phương thức này chuyển đổi các tệp metafile WMF/EMF thành hình ảnh PNG raster trong quá trình cắt. 
{{% /alert %}}

## **Nén ảnh**

Bạn có thể nén một hình ảnh trong bản trình chiếu bằng cách sử dụng phương thức [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_). Phương thức này nén hình ảnh bằng cách giảm kích thước dựa trên kích thước hình dạng và độ phân giải được chỉ định, với tùy chọn xóa các vùng đã cắt.

Nó điều chỉnh kích thước và độ phân giải của hình ảnh tương tự như tính năng **Picture Format -> Compress Pictures -> Resolution** của PowerPoint.

Các ví dụ PHP sau đây minh họa cách nén một hình ảnh trong bản trình chiếu bằng cách chỉ định độ phân giải mục tiêu và tùy chọn xóa các vùng đã cắt:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Nén hình ảnh với độ phân giải mục tiêu 150 DPI (độ phân giải web) và xóa các vùng đã cắt.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Kiểm tra kết quả của quá trình nén.
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

Hoặc sử dụng giá trị DPI tùy chỉnh trực tiếp:

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
Phương thức chuyển đổi hình ảnh sang độ phân giải thấp hơn dựa trên kích thước hình dạng và DPI được cung cấp. Các vùng đã cắt cũng có thể bị xóa để tối ưu kích thước tệp.  
Nếu hình ảnh là một metafile (WMF/EMF) hoặc SVG, việc nén sẽ không được áp dụng. Ngoài ra, chất lượng JPEG được giữ nguyên hoặc giảm nhẹ dựa trên độ phân giải, tương tự như cách PowerPoint xử lý JPEG độ phân giải cao.
{{% /alert %}}

## **Khóa tỷ lệ khung hình**

Nếu bạn muốn một hình dạng chứa hình ảnh duy trì tỷ lệ khung hình ngay cả khi thay đổi kích thước hình ảnh, bạn có thể sử dụng phương thức [setAspectRatioLocked](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) để đặt cài đặt *Lock Aspect Ratio*.

Đoạn mã PHP này cho thấy cách khóa tỷ lệ khung hình của một shape:

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
    # đặt shape để duy trì tỷ lệ khung khi thay đổi kích thước
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
Cài đặt *Lock Aspect Ratio* này chỉ bảo tồn tỷ lệ của shape chứ không phải của hình ảnh bên trong. 
{{% /alert %}}

## **Sử dụng thuộc tính StretchOff**

Bằng cách sử dụng các phương thức [setStretchOffsetLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) và [setStretchOffsetBottom](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) từ lớp [PictureFillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/), bạn có thể chỉ định một hình chữ nhật đổ đầy.

Khi kéo dãn được chỉ định cho một hình ảnh, một hình chữ nhật nguồn sẽ được tỷ lệ để vừa với hình chữ nhật đổ đầy đã chỉ định. Mỗi cạnh của hình chữ nhật đổ đầy được xác định bằng một phần trăm độ lệch so với cạnh tương ứng của hộp bao của shape. Phần trăm dương chỉ ra độ lệch vào trong, phần trăm âm chỉ ra độ lệch ra ngoài.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm một hình chữ nhật `AutoShape`. 
4. Tạo một hình ảnh.
5. Đặt kiểu đổ đầy cho shape.
6. Đặt chế độ đổ đầy hình ảnh cho shape.
7. Thêm hình ảnh đã đặt để đổ đầy shape.
8. Xác định độ lệch của hình ảnh từ cạnh tương ứng của hộp bao của shape.
9. Ghi bản trình chiếu đã chỉnh sửa thành tệp PPTX.

Đoạn mã PHP này minh họa quy trình sử dụng thuộc tính StretchOff:

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
    # Thêm một AutoShape dạng Hình chữ nhật
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Đặt loại đổ đầy cho shape
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Đặt chế độ đổ đầy ảnh cho shape
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Đặt hình ảnh để đổ đầy shape
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Xác định độ lệch của hình ảnh từ cạnh tương ứng của hộp bao của shape
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

## **Câu hỏi thường gặp**

**Làm thế nào để tôi biết định dạng hình ảnh nào được hỗ trợ cho PictureFrame?**  
Aspose.Slides hỗ trợ cả hình ảnh raster (PNG, JPEG, BMP, GIF, v.v.) và hình ảnh vector (ví dụ, SVG) thông qua đối tượng hình ảnh được gán cho một [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/). Danh sách các định dạng hỗ trợ thường trùng khớp với khả năng của động cơ chuyển đổi slide và hình ảnh.

**Việc thêm hàng chục hình ảnh lớn sẽ ảnh hưởng như thế nào đến kích thước và hiệu năng của PPTX?**  
Nhúng hình ảnh lớn làm tăng kích thước tệp và mức sử dụng bộ nhớ; liên kết hình ảnh giúp giảm kích thước bản trình chiếu nhưng yêu cầu các tệp bên ngoài vẫn phải khả dụng. Aspose.Slides cung cấp khả năng thêm hình ảnh bằng liên kết để giảm kích thước tệp.

**Làm sao tôi có thể khóa một đối tượng hình ảnh tránh việc di chuyển/đổi kích thước nhầm?**  
Sử dụng [shape locks](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/getpictureframelock/) cho một [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) (ví dụ, vô hiệu hoá di chuyển hoặc đổi kích thước). Cơ chế khóa được hỗ trợ cho nhiều loại shape, bao gồm [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/).

**Độ chính xác vector SVG có được bảo toàn khi xuất bản trình chiếu ra PDF/hình ảnh không?**  
Aspose.Slides cho phép trích xuất một SVG từ một [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) dưới dạng vector gốc. Khi [xuất ra PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/) hoặc [định dạng raster](/slides/vi/php-java/convert-powerpoint-to-png/), kết quả có thể được raster hoá tùy thuộc vào cài đặt xuất; thực tế rằng SVG gốc được lưu dưới dạng vector được xác nhận bằng hành vi trích xuất.