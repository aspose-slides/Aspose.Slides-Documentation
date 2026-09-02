---
title: Tối ưu quản lý hình ảnh trong bài thuyết trình bằng PHP
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
- tài nguyên SVG bên ngoài
- bộ giải quyết SVG
- hình ảnh SVG được liên kết
- phông chữ SVG
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

Hình ảnh làm cho bài thuyết trình trở nên hấp dẫn hơn và sinh động hơn. Trong Microsoft PowerPoint, bạn có thể chèn ảnh vào các slide từ tệp, internet hoặc các nguồn khác. Tương tự, Aspose.Slides cho phép bạn thêm hình ảnh vào các slide của bài thuyết trình theo nhiều cách.

{{% alert  title="Tip" color="primary" %}} 

Aspose cung cấp các công cụ chuyển đổi miễn phí—[JPEG to PowerPoint](https://products.aspose.app/slides/vi/import/jpg-to-ppt) và [PNG to PowerPoint](https://products.aspose.app/slides/vi/import/png-to-ppt)—cho phép bạn nhanh chóng tạo bài thuyết trình từ hình ảnh. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Nếu bạn muốn thêm hình ảnh dưới dạng khung ảnh—đặc biệt nếu bạn dự định thay đổi kích thước, áp dụng hiệu ứng hoặc sử dụng các tùy chọn định dạng tiêu chuẩn khác—hãy xem [Picture Frame](/slides/vi/php-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Bạn có thể chuyển đổi hình ảnh từ định dạng này sang định dạng khác. Xem các trang sau: chuyển đổi [image to JPG](https://products.aspose.com/slides/vi/php-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/vi/php-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/vi/php-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/vi/php-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/vi/php-java/conversion/png-to-svg/), và [SVG to PNG](https://products.aspose.com/slides/vi/php-java/conversion/svg-to-png/). 

{{% /alert %}}

Aspose.Slides hỗ trợ hình ảnh ở các định dạng phổ biến như JPEG, PNG, BMP, GIF và các định dạng khác. 

## **Thêm Hình Ảnh Được Lưu Trên Máy Vào Các Slide**

Bạn có thể thêm một hoặc nhiều hình ảnh được lưu trên máy tính của mình vào một slide của bài thuyết trình. Đoạn mã mẫu PHP sau đây cho thấy cách thêm hình ảnh vào slide:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
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
    $pres->dispose();
}
```

## **Thêm Hình Ảnh Từ Web Vào Các Slide**

Nếu hình ảnh bạn muốn thêm vào slide không được lưu trên máy tính, bạn có thể thêm trực tiếp từ web. 

Đoạn mã mẫu PHP sau đây cho thấy cách thêm hình ảnh từ web vào slide:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
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
    $pres->dispose();
}
```

## **Thêm Hình Ảnh Vào Slide Master**

Slide master lưu trữ và kiểm soát thông tin như giao diện và bố cục cho các slide sử dụng nó. Khi bạn thêm hình ảnh vào slide master, hình ảnh sẽ xuất hiện trên mọi slide dựa trên master đó. 

Đoạn mã mẫu PHP sau đây cho thấy cách thêm hình ảnh vào slide master:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
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
    $pres->dispose();
}
```

## **Thêm Hình Ảnh Là Nền Slide**

Bạn có thể sử dụng một bức ảnh làm nền cho một hoặc nhiều slide. Để biết chi tiết, xem *[Setting Images as Backgrounds for Slides](/slides/vi/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Thêm SVG Vào Bài Thuyết Trình**

Nội dung SVG có thể được thêm vào bài thuyết trình bằng lớp [SvgImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/). Đối tượng ảnh SVG thu được sau đó có thể được thêm vào bộ sưu tập ảnh của bài thuyết trình và dùng để tạo khung ảnh.

Ví dụ PHP sau nhập một chuỗi SVG tự chứa. Tất cả hình ảnh, kiểu dáng và các tài nguyên khác được SVG sử dụng đều được nhúng trực tiếp trong nội dung SVG.

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nhập Nội Dung SVG Với Các Tài Nguyên Bên Ngoài**

Các tệp SVG xuất ra từ công cụ thiết kế, trình chỉnh sửa sơ đồ, hệ thống biểu tượng và quy trình web có thể tham chiếu tới các tài nguyên được lưu bên ngoài tài liệu SVG. Ví dụ, một SVG có thể chứa liên kết hình ảnh như `images/photo.png`, giá trị CSS `url(...)`, hoặc URL phông chữ.

Để nhập nội dung SVG như vậy, tạo một triển khai [ExternalResourceResolver](https://reference.aspose.com/slides/vi/php-java/aspose.slides/externalresourceresolver/) và truyền nó, cùng với một base URI, vào một hàm khởi tạo [SvgImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/) thích hợp. Base URI xác định vị trí của tài liệu SVG và được dùng để giải quyết các liên kết tương đối.

Đối tượng ảnh SVG cung cấp quyền truy cập thông tin về SVG đã nhập:

- ``getSvgContent()`` trả về markup SVG dưới dạng chuỗi.  
- ``getSvgData()`` trả về nội dung SVG dưới dạng mảng byte.  
- ``getBaseUri()`` trả về base URI được dùng cho các liên kết tương đối.  
- ``getExternalResourceResolver()`` trả về resolver được gán cho ảnh SVG.  

### **Triển Khai Bộ Giải Quyết Tài Nguyên Bên Ngoài**

Resolver có hai phương thức:

- `resolveUri` kết hợp base URI và một liên kết tài nguyên tương đối và trả về một URI tuyệt đối. Trả về `null` khi liên kết không thể giải quyết hoặc không được phép.  
- `getEntity` trả về một luồng đọc được cho một URI tài nguyên tuyệt đối. Trả về `null` khi tài nguyên bị thiếu, bị chặn, hoặc không khả dụng. Một luồng dự phòng cũng có thể được trả về khi thích hợp.  

Resolver sau chỉ tải các tài nguyên được liên kết từ thư mục cục bộ được phép. Các tài nguyên mạng và các đường dẫn bên ngoài thư mục cho phép sẽ bị chặn. Một hình ảnh dự phòng tùy chọn sẽ được trả về cho các liên kết hình ảnh không thể giải quyết.

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // Resolver này cố ý chỉ cho phép các tệp cục bộ.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // Chỉ sử dụng fallback cho các tài nguyên hình ảnh. Trả về một luồng hình ảnh
            // đối với phông chữ hoặc stylesheet bị thiếu sẽ không hợp lệ.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **Giải Quyết Tài Nguyên Được Liên Kết Khi Nhập SVG**

Giả sử `assets/diagram.svg` chứa một tham chiếu tương đối như sau:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Ví dụ PHP sau truyền URI của tệp SVG làm base URI và cung cấp một resolver tùy chỉnh. Resolver chuyển đổi liên kết hình ảnh tương đối thành URI tuyệt đối và trả về một luồng chứa tài nguyên được liên kết trong khi Aspose.Slides xử lý SVG.

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// URI cơ sở đại diện cho vị trí của tài liệu SVG.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// Đối tượng ảnh SVG cung cấp nội dung nguồn, dữ liệu nhị phân, URI cơ sở và bộ giải quyết.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Lớp `SvgImage` cũng cung cấp các hàm overload cho phép chấp nhận dữ liệu SVG dưới dạng mảng byte hoặc luồng đầu vào, cùng với một bộ giải quyết tài nguyên bên ngoài và một base URI.

{{% alert title="Important" color="warning" %}}

Bộ giải quyết tài nguyên cung cấp các tài nguyên bên ngoài trong khi Aspose.Slides xử lý và render SVG. Nó không thay đổi markup SVG gốc hoặc tự động nhúng các tài nguyên đã giải quyết vào trong đó.

Khi một ảnh SVG được thêm vào bộ sưu tập ảnh của bài thuyết trình, tệp PPTX có thể chứa cả biểu diễn SVG gốc và một hình raster dự phòng. Một tài nguyên được liên kết có thể xuất hiện trong hình dự phòng được tạo ra trong khi một liên kết tương đối như `images/photo.png` vẫn không thay đổi trong SVG đã lưu. Vì vậy, ứng dụng render biểu diễn SVG gốc có thể bỏ qua nội dung được liên kết khi tài nguyên bên ngoài gốc không có sẵn.

{{% /alert %}}

### **Tạo Hình Ảnh SVG Di Động**

Để tạo một hình SVG không phụ thuộc vào các tệp bên ngoài, hãy làm cho SVG tự chứa trước khi tạo `SvgImage`. Ví dụ, thay thế các URL hình ảnh được liên kết bằng URI `data:` chứa dữ liệu hình ảnh:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Sau khi tất cả các tài nguyên cần thiết đã được nhúng vào nội dung SVG, tạo `SvgImage`, thêm nó vào bộ sưu tập ảnh của bài thuyết trình và chèn nó vào khung ảnh như trong ví dụ trước.

### **Xử Lý Các Tài Nguyên Thiếu Hoặc Bị Chặn**

Trả về `null` từ `resolveUri` khi URI tài nguyên không hợp lệ, bị cấm, hoặc không thể giải quyết. Trả về `null` từ `getEntity` khi tài nguyên không thể đọc được. Aspose.Slides tiếp tục xử lý SVG mà không có tài nguyên đó khi có thể.

Có thể trả về một luồng dự phòng cho tài nguyên bị thiếu, nhưng nội dung của nó phải tương thích với loại tài nguyên được yêu cầu. Ví dụ, chỉ trả về luồng hình ảnh cho hình ảnh bị thiếu, không phải cho phông chữ hay stylesheet.

{{% alert title="Security" color="warning" %}}

Không giải quyết các đường dẫn tệp tùy ý hoặc URL mạng không giới hạn từ các tệp SVG không tin cậy. Hạn chế các scheme, thư mục và máy chủ được phép. Đối với tài nguyên mạng, cũng nên áp dụng thời gian chờ kết nối, giới hạn kích thước phản hồi và kiểm tra tính hợp lệ của nội dung.

{{% /alert %}}

## **Chuyển Đổi SVG Thành Một Bộ Hình Học**

Aspose.Slides có thể chuyển đổi SVG thành một bộ hình học, tương tự như chức năng tương ứng trong PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Chức năng này được cung cấp bởi một overload của phương thức [addGroupShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addgroupshape/) của lớp [ShapeCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/) nhận đối tượng [SvgImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/) làm đối số đầu tiên.

Đoạn mã mẫu PHP sau đây cho thấy cách sử dụng phương thức này để chuyển đổi tệp SVG thành một bộ hình học:

```php
// Tên tệp SVG nguồn.
$svgFileName = "sample.svg";

// Tên tệp bài thuyết trình đầu ra.
$outPptxPath = "presentation.pptx";

// Tạo một bài thuyết trình mới.
$presentation = new Presentation();
try {
    // Đọc nội dung tệp SVG.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // Tạo một đối tượng SvgImage.
    $svgImage = new SvgImage($svgContent);

    // Lấy kích thước slide.
    $slideSize = $presentation->getSlideSize()->getSize();

    // Chuyển đổi hình ảnh SVG thành một nhóm các hình dạng và co giãn nó theo kích thước slide.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // Lưu bài thuyết trình ở định dạng PPTX.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **Thêm Hình Ảnh Dưới Dạng EMF Vào Các Slide**

Aspose.Slides cho PHP qua Java cho phép bạn tạo ảnh EMF từ các bảng tính Excel bằng Aspose.Cells và thêm chúng vào các slide của bài thuyết trình.

Đoạn mã mẫu PHP sau đây cho thấy cách thực hiện:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Lưu workbook vào một luồng.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // Thêm tệp nguyên dạng để ảnh giữ dạng vector EMF thay vì được raster hoá.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Thay Thế Hình Ảnh Trong Bộ Sưu Tập Ảnh**

Aspose.Slides cho phép bạn thay thế các hình ảnh lưu trong bộ sưu tập ảnh của một bài thuyết trình, bao gồm các hình ảnh được các hình dạng slide sử dụng. Phần này mô tả một số cách cập nhật hình ảnh trong bộ sưu tập. Bạn có thể thay thế một hình ảnh bằng dữ liệu byte thô, một thể hiện [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/), hoặc một hình ảnh khác đã tồn tại trong bộ sưu tập.

Thực hiện các bước sau:

1. Tải tệp bài thuyết trình chứa hình ảnh bằng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).  
2. Tải một hình ảnh mới từ tệp vào một mảng byte.  
3. Thay thế hình ảnh mục tiêu bằng hình ảnh mới sử dụng mảng byte.  
4. Trong cách tiếp cận thứ hai, tải hình ảnh vào đối tượng [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/) và thay thế hình ảnh mục tiêu bằng đối tượng đó.  
5. Trong cách tiếp cận thứ ba, thay thế hình ảnh mục tiêu bằng một hình ảnh đã tồn tại trong bộ sưu tập ảnh của bài thuyết trình.  
6. Ghi bài thuyết trình đã chỉnh sửa thành tệp PPTX.  

```php
// Tạo một thể hiện của lớp Presentation đại diện cho tệp bài thuyết trình.
$presentation = new Presentation("sample.pptx");
try {
    // Cách đầu tiên.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Cách thứ hai.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

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

Với công cụ chuyển đổi miễn phí [Text to GIF](https://products.aspose.app/slides/vi/text-to-gif) của Aspose, bạn có thể dễ dàng tạo hoạt ảnh cho văn bản và tạo GIF từ văn bản. 

{{% /alert %}}

## **CÂU HỎI THƯỜNG GẶP**

**Độ phân giải gốc của hình ảnh có vẫn giữ nguyên sau khi chèn không?**

Có. Các pixel nguồn được giữ lại, nhưng giao diện cuối cùng phụ thuộc vào cách [picture](/slides/vi/php-java/picture-frame/) được thu phóng trên slide và bất kỳ việc nén nào được áp dụng khi lưu.  

**Cách tốt nhất để thay thế cùng một logo trên hàng chục slide cùng lúc là gì?**

Đặt logo trên slide master hoặc một layout và thay thế nó trong bộ sưu tập ảnh của bài thuyết trình — các cập nhật sẽ lan tới tất cả các phần tử sử dụng tài nguyên đó.  

**Một SVG đã chèn có thể được chuyển đổi thành các hình học có thể chỉnh sửa không?**

Có. Bạn có thể chuyển đổi SVG thành một nhóm các hình học, sau đó các phần riêng lẻ trở nên có thể chỉnh sửa bằng các thuộc tính hình học tiêu chuẩn.  

**Làm sao để đặt một bức ảnh làm nền cho nhiều slide cùng lúc?**

[Gán hình ảnh làm nền](/slides/vi/php-java/presentation-background/) trên slide master hoặc layout liên quan — bất kỳ slide nào sử dụng master/layout đó sẽ kế thừa nền.  

**Làm sao để ngăn một bài thuyết trình trở nên quá lớn vì có quá nhiều hình ảnh?**

Sử dụng lại một tài nguyên hình ảnh duy nhất thay vì sao chép, chọn độ phân giải hợp lý, áp dụng nén khi lưu, và giữ các hình ảnh lặp lại trên master khi phù hợp.