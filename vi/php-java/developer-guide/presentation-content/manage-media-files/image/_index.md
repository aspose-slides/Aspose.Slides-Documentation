---
title: Tối ưu hóa quản lý hình ảnh trong bài thuyết trình bằng PHP
linktitle: Quản lý hình ảnh
type: docs
weight: 10
url: /vi/php-java/image/
keywords:
  - thêm hình ảnh
  - thêm ảnh
  - thêm bitmap
  - thay thế hình ảnh
  - thay thế ảnh
  - từ web
  - nền
  - thêm PNG
  - thêm JPG
  - thêm SVG
  - thêm EMF
  - thêm WMF
  - thêm TIFF
  - PowerPoint
  - OpenDocument
  - bài thuyết trình
  - EMF
  - SVG
  - PHP
  - Aspose.Slides
description: "Đơn giản hoá quản lý hình ảnh trong PowerPoint và OpenDocument với Aspose.Slides cho PHP qua Java, tối ưu hiệu năng và tự động hoá quy trình làm việc của bạn."
---
## **Giới thiệu**

Hình ảnh làm cho bài thuyết trình trở nên sinh động và thú vị hơn. Trong Microsoft PowerPoint, bạn có thể chèn ảnh từ tệp, internet hoặc các vị trí khác vào các slide. Tương tự, Aspose.Slides cho phép bạn thêm hình ảnh vào các slide trong bài thuyết trình của mình qua các phương pháp khác nhau. 

{{% alert  title="Tip" color="primary" %}} 

Aspose cung cấp các công cụ chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép người dùng tạo bài thuyết trình nhanh chóng từ hình ảnh. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Nếu bạn muốn thêm một hình ảnh dưới dạng đối tượng khung—đặc biệt nếu bạn dự định sử dụng các tùy chọn định dạng tiêu chuẩn trên nó để thay đổi kích thước, thêm hiệu ứng, v.v.—hãy xem [Picture Frame](/slides/vi/php-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Bạn có thể thao tác các hoạt động nhập/xuất liên quan đến hình ảnh và bài thuyết trình PowerPoint để chuyển đổi một hình ảnh từ định dạng này sang định dạng khác. Xem các trang này: chuyển đổi [image to JPG](https://products.aspose.com/slides/vi/php-java/conversion/image-to-jpg/); chuyển đổi [JPG to image](https://products.aspose.com/slides/vi/php-java/conversion/jpg-to-image/); chuyển đổi [JPG to PNG](https://products.aspose.com/slides/vi/php-java/conversion/jpg-to-png/), chuyển đổi [PNG to JPG](https://products.aspose.com/slides/vi/php-java/conversion/png-to-jpg/); chuyển đổi [PNG to SVG](https://products.aspose.com/slides/vi/php-java/conversion/png-to-svg/), chuyển đổi [SVG to PNG](https://products.aspose.com/slides/vi/php-java/conversion/svg-to-png/). 

{{% /alert %}}

Aspose.Slides hỗ trợ các thao tác với hình ảnh trong các định dạng phổ biến này: JPEG, PNG, GIF và các định dạng khác. 

## **Thêm Hình Ảnh Được Lưu Trên Máy Vào Các Slide**

Bạn có thể thêm một hoặc nhiều hình ảnh trên máy tính của mình vào một slide trong bài thuyết trình. Đoạn mã mẫu dưới đây cho thấy cách thêm hình ảnh vào slide:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thêm Hình Ảnh Từ Web Vào Các Slide**

Nếu hình ảnh bạn muốn thêm vào slide không có trên máy tính, bạn có thể thêm hình ảnh trực tiếp từ web. 

Đoạn mã mẫu dưới đây cho thấy cách thêm hình ảnh từ web vào slide :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thêm Hình Ảnh Vào Slide Master**

Slide master là slide chính lưu trữ và kiểm soát thông tin (chủ đề, bố cục, v.v.) của tất cả các slide bên dưới nó. Do đó, khi bạn thêm một hình ảnh vào slide master, hình ảnh đó sẽ xuất hiện trên mọi slide dưới slide master đó. 

Đoạn mã mẫu Java dưới đây cho thấy cách thêm hình ảnh vào slide master:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thêm Hình Ảnh Là Nền Cho Slide**

Bạn có thể quyết định sử dụng một bức ảnh làm nền cho một slide cụ thể hoặc nhiều slide. Trong trường hợp đó, bạn cần xem cách [Set an Image as a Slide Background](/slides/vi/php-java/presentation-background/#set-an-image-as-a-slide-background). 

## **Thêm SVG Vào Bài Thuyết Trình**
Bạn có thể thêm hoặc chèn bất kỳ hình ảnh nào vào bài thuyết trình bằng cách sử dụng phương thức [addPictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addpictureframe/) thuộc lớp [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/). 

Để tạo đối tượng hình ảnh dựa trên ảnh SVG, bạn có thể làm như sau:

1. Tạo đối tượng SvgImage để chèn vào ImageShapeCollection
2. Tạo đối tượng PPImage từ ISvgImage
3. Tạo đối tượng PictureFrame bằng lớp PPImage

Đoạn mã mẫu dưới đây cho thấy cách thực hiện các bước trên để thêm hình ảnh SVG vào bài thuyết trình:
```php
  # Khởi tạo lớp Presentation đại diện cho tệp PPTX
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Chuyển Đổi SVG Thành Tập Hình Dạng**
Việc chuyển đổi SVG thành tập các hình dạng của Aspose.Slides tương tự như chức năng của PowerPoint được dùng để làm việc với hình ảnh SVG:

![PowerPoint Popup Menu](img_01_01.png)

Chức năng này được cung cấp bởi một trong các phiên bản overload của phương thức [addGroupShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addgroupshape/) của lớp [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/) nhận một đối tượng [SvgImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/) làm đối số đầu tiên.

Đoạn mã mẫu dưới đây cho thấy cách sử dụng phương pháp đã mô tả để chuyển đổi tệp SVG thành tập các hình dạng:

```php
  # Tạo bài thuyết trình mới
  $presentation = new Presentation();
  try {
    # Đọc nội dung tệp SVG
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # Tạo đối tượng SvgImage
    $svgImage = new SvgImage($svgContent);
    # Lấy kích thước slide
    $slideSize = $presentation->getSlideSize()->getSize();
    # Chuyển đổi hình ảnh SVG thành nhóm các hình dạng và co giãn nó theo kích thước slide
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Lưu bài thuyết trình ở định dạng PPTX
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Thêm Hình Ảnh Dưới Dạng EMF Vào Slide**
Aspose.Slides for PHP via Java cho phép bạn tạo hình ảnh EMF từ các bảng tính Excel và thêm các hình ảnh dưới dạng EMF vào slide bằng Aspose.Cells.  

Đoạn mã mẫu dưới đây cho thấy cách thực hiện tác vụ đã mô tả:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Lưu workbook vào luồng
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Thay Thế Hình Ảnh Trong Bộ Sưu Tập Hình Ảnh**

Aspose.Slides cho phép bạn thay thế các hình ảnh được lưu trong bộ sưu tập hình ảnh của một bài thuyết trình (bao gồm các hình ảnh được các hình dạng slide sử dụng). Phần này trình bày một số cách tiếp cận để cập nhật hình ảnh trong bộ sưu tập. API cung cấp các phương thức đơn giản để thay thế một hình ảnh bằng dữ liệu byte thô, một thể hiện của [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/), hoặc một hình ảnh khác đã tồn tại trong bộ sưu tập.

Thực hiện các bước sau:

1. Tải tệp bài thuyết trình chứa hình ảnh bằng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/). 
2. Tải một hình ảnh mới từ tệp vào một mảng byte. 
3. Thay thế hình ảnh mục tiêu bằng hình ảnh mới sử dụng mảng byte. 
4. Trong cách tiếp cận thứ hai, tải hình ảnh vào đối tượng [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/) và thay thế hình ảnh mục tiêu bằng đối tượng đó. 
5. Trong cách tiếp cận thứ ba, thay thế hình ảnh mục tiêu bằng một hình ảnh đã tồn tại trong bộ sưu tập hình ảnh của bài thuyết trình. 
6. Ghi lại bài thuyết trình đã chỉnh sửa dưới dạng tệp PPTX. 

```php
// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình.
$presentation = new Presentation("sample.pptx");
try {
    // Cách thứ nhất.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Cách thứ hai.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // Cách thứ ba.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // Lưu bài thuyết trình vào tệp.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

Sử dụng công cụ chuyển đổi FREE [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif) của Aspose, bạn có thể dễ dàng tạo hoạt hình cho văn bản, tạo GIF từ văn bản, v.v. 

{{% /alert %}}

## **Câu Hỏi Thường Gặp**

**Khi chèn, độ phân giải gốc của hình ảnh có được giữ nguyên không?**

Có. Các pixel gốc được giữ lại, nhưng hình dạng cuối cùng phụ thuộc vào cách mà [picture](/slides/vi/php-java/picture-frame/) được phóng to/thu nhỏ trên slide và bất kỳ việc nén nào được áp dụng khi lưu. 

**Cách tốt nhất để thay thế cùng một logo trên hàng chục slide cùng một lúc là gì?**

Đặt logo trên slide master hoặc một layout và thay thế nó trong bộ sưu tập hình ảnh của bài thuyết trình—các cập nhật sẽ lan tới tất cả các thành phần sử dụng tài nguyên đó. 

**Liệu SVG được chèn có thể được chuyển thành các hình dạng có thể chỉnh sửa không?**

Có. Bạn có thể chuyển đổi SVG thành một nhóm các hình dạng, sau đó các phần riêng lẻ sẽ có thể chỉnh sửa bằng các thuộc tính hình dạng tiêu chuẩn. 

**Làm sao để đặt một bức ảnh làm nền cho nhiều slide cùng lúc?**

[Assign the image as the background](/slides/vi/php-java/presentation-background/) trên slide master hoặc layout liên quan—mọi slide sử dụng master/layout đó sẽ kế thừa nền. 

**Làm sao để ngăn bài thuyết trình "phồng to" kích thước do quá nhiều hình ảnh?**

Tái sử dụng một tài nguyên hình ảnh duy nhất thay vì sao chép, chọn độ phân giải hợp lý, áp dụng nén khi lưu, và giữ các đồ họa lặp lại trên master khi cần.