---
title: Chuyển đổi bản trình bày PowerPoint sang Markdown trong PHP
linktitle: PowerPoint sang Markdown
type: docs
weight: 140
url: /vi/php-java/convert-powerpoint-to-markdown/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang MD
- bản trình bày sang MD
- slide sang MD
- PPT sang MD
- PPTX sang MD
- lưu PowerPoint dưới dạng Markdown
- lưu bản trình bày dưới dạng Markdown
- lưu slide dưới dạng Markdown
- lưu PPT dưới dạng MD
- lưu PPTX dưới dạng MD
- xuất PPT sang MD
- xuất PPTX sang MD
- xuất ảnh Markdown
- liên kết ảnh CDN
- PowerPoint
- bản trình bày
- Markdown
- PHP
- Aspose.Slides
description: Chuyển đổi các bản trình bày PPT và PPTX sang Markdown trong PHP và kiểm soát nơi lưu và tham chiếu các ảnh bitmap, metafile và SVG đã xuất.
---
## **Tổng quan**

Aspose.Slides for PHP qua Java có thể chuyển đổi các bản trình bày PPT và PPTX sang Markdown cho tài liệu, trang tĩnh, di chuyển nội dung và quy trình kiểm soát phiên bản. Bạn có thể chọn kiểu Markdown, kiểm soát cách nội dung slide được hiển thị và quyết định nơi lưu ảnh đã xuất và cách Markdown được tạo tham chiếu chúng.

Mặc định, xuất Markdown chỉ sử dụng đầu ra dạng văn bản. Để xuất nội dung trực quan, đặt kiểu xuất bằng phương thức [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownsaveoptions/) thành giá trị `Sequential` hoặc `Visual` từ enumeration [MarkdownExportType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownexporttype/). `Sequential` render các mục slide riêng biệt và theo thứ tự, trong khi `Visual` giữ các mục được nhóm lại với nhau để bảo toàn mối quan hệ trực quan. Giá trị `TextOnly` không tạo ra tài nguyên ảnh, vì vậy các callback lưu ảnh sẽ không được gọi trong chế độ này.

## **Chuyển đổi bản trình bày sang Markdown**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/), sau đó gọi phương thức [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) với giá trị `Md` từ enumeration [SaveFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Chọn kiểu Markdown**

Phương thức [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownsaveoptions/) kiểm soát chuẩn Markdown được dùng cho đầu ra. Enumeration [Flavor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/flavor/) bao gồm CommonMark, GitHub Flavored Markdown và các biến thể hỗ trợ khác.

Ví dụ sau xuất bản trình bày dưới dạng CommonMark:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **Xuất ảnh bằng hành vi lưu cục bộ mặc định**

Lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownsaveoptions/) cung cấp hai phương thức để cấu hình việc lưu ảnh cục bộ:

- [setBasePath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownsaveoptions/) chỉ định thư mục gốc cho tài liệu Markdown và các tài nguyên của nó.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownsaveoptions/) chỉ định thư mục con cho ảnh. Giá trị mặc định là `Images`.

Ví dụ sau render nội dung trực quan, ghi ảnh vào `output/assets` và tạo các tham chiếu ảnh tương đối trong tài liệu Markdown:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Hành vi này cũng được dùng làm dự phòng khi trình xử lý lưu ảnh tùy chỉnh trả về `false`.

## **Tùy chỉnh việc lưu ảnh và liên kết Markdown**

Sử dụng phương thức [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownsaveoptions/) để đăng ký callback cho các tài nguyên bitmap và metafile không phải SVG được tạo ra trong quá trình xuất Markdown. Callback `MarkdownImageSavingHandler` nhận đối tượng [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/), giá trị [ImageFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imageformat/) và liên kết Markdown được tạo dưới dạng một mảng Java string một phần tử. Lưu hoặc tải lên ảnh với định dạng được cung cấp, và thay thế `$link[0]` bằng tham chiếu cần xuất hiện trong đầu ra Markdown.

Các tài nguyên được xuất dưới dạng SVG được xử lý riêng. Đăng ký callback với phương thức [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownsaveoptions/). Callback `MarkdownSvgImageSavingHandler` nhận một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/isvgimage/) và mảng Java string một phần tử `$link`. SVG không có đối số `ImageFormat`; thay vào đó ghi hoặc tải lên dữ liệu XML của nó từ phương thức [ISvgImage::getSvgData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/isvgimage/). Tùy thuộc vào chế độ xuất và việc nhóm trực quan, một SVG trong bản trình bày nguồn có thể được raster hoá hoặc kết hợp với nội dung khác; tài nguyên không phải SVG kết quả sẽ được chuyển tới callback lưu ảnh. Đăng ký cả hai callback khi mỗi tài nguyên trực quan được xuất cần xử lý tùy chỉnh.

Trong PHP qua Java, triển khai mỗi callback trong một lớp PHP và sử dụng `java_closure` để mở rộng đối tượng đó dưới dạng giao diện Java tương ứng.

{{% alert color="info" title="Note" %}}
Khởi tạo PHP/Java Bridge với `JAVA_PREFER_VALUES` được bật trước khi tải `Java.inc`. Phương thức [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) trả về `void`, và chế độ luồng mặc định của bridge không thể gọi callback PHP trong cuộc gọi được xếp hàng. Ví dụ đầy đủ dưới đây bao gồm việc khởi tạo cần thiết.
{{% /alert %}}

Giá trị trả về của handler quyết định ai sẽ xử lý ảnh:

- Trả về `true` sau khi handler đã lưu, tải lên, biến đổi hoặc xử lý ảnh theo cách nào đó và đã gán giá trị hợp lệ cho `$link[0]`. Aspose.Slides sẽ ghi giá trị đó vào tài liệu Markdown và không thực hiện lưu cục bộ mặc định.
- Trả về `false` để để Aspose.Slides lưu ảnh cục bộ và tạo liên kết dựa trên các giá trị được thiết lập bởi [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownsaveoptions/) và [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Một handler trả về `true` sẽ chịu trách nhiệm cho ảnh. Nếu trả về `true` mà không gán một liên kết hợp lệ, không rỗng, việc xuất sẽ thất bại với `InvalidOperationException`.
{{% /alert %}}

### **Lưu ảnh vào thư mục gốc CDN và sử dụng URL bên ngoài**

Ví dụ sau coi `cdn-origin/presentations/quarterly-report` là một thư mục gốc CDN đã được gắn kết hoặc đồng bộ. Mỗi handler trích xuất tên tệp đã tạo, lưu ảnh vào thư mục tùy chỉnh đó, và thay thế tham chiếu cục bộ đã tạo bằng một URL CDN công cộng. Mẫu này không thực hiện tải lên mạng: URL chỉ hợp lệ sau khi thư mục được gắn làm nguồn CDN hoặc các tệp được xuất bản lên CDN. Đối với lưu trữ đối tượng, thay thế việc ghi file hệ thống bằng thao tác tải lên của SDK lưu trữ và gán `$link[0]` chỉ sau khi tải lên thành công.

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Handler bitmap cố ý trả về `false` cho các ảnh nhỏ hơn 128 × 128 pixel, vì vậy Aspose.Slides sẽ lưu những ảnh này vào `output/fallback-images` theo hành vi mặc định. Các tài nguyên bitmap và metafile lớn hơn, cũng như tài nguyên SVG, được xử lý bằng mã tùy chỉnh. Ví dụ, một tham chiếu cục bộ tạo ra như `fallback-images/image1.png` sẽ trở thành `https://cdn.example.com/presentations/quarterly-report/image1.png`. Các handler chỉ sử dụng đường dẫn hệ điều hành khi ghi file; các liên kết ghi vào Markdown dùng dấu gạch chéo `/` và tên tệp đã được mã hóa URL. Áp dụng quy tắc tương tự khi xây dựng liên kết tương đối: dùng `/`, không dùng dấu phân tách thư mục đặc thù của nền tảng.

## **Câu hỏi thường gặp**

**Một handler có thể xử lý cả ảnh raster và ảnh SVG không?**

Không. Sử dụng [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownsaveoptions/) cho các tài nguyên bitmap và metafile được xuất ra và [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownsaveoptions/) cho các tài nguyên xuất dưới dạng SVG. Phương thức đầu tiên cung cấp một đối tượng [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/) và giá trị [ImageFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imageformat/); phương thức thứ hai cung cấp một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/isvgimage/) mà dữ liệu SVG có thể đọc bằng [ISvgImage::getSvgData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/isvgimage/). Một SVG nguồn bị raster hoá trong quá trình xuất sẽ được xử lý bởi callback lưu ảnh thay vì callback SVG.

**Điều gì xảy ra khi một handler lưu ảnh trả về `false`?**

Aspose.Slides sẽ sử dụng hành vi lưu cục bộ mặc định. Vị trí ảnh và tham chiếu được tạo ra được điều khiển bởi các giá trị được đặt bằng [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownsaveoptions/) và [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/vi/php-java/aspose.slides/markdownsaveoptions/).

**Handler có thể cung cấp URL mà không lưu ảnh cục bộ không?**

Có. Handler có thể tải ảnh lên lưu trữ đối tượng hoặc chuyển cho dịch vụ khác, gán URL nhận được cho `$link[0]`, và trả về `true`. Handler phải tự hoàn thành việc xử lý; trả về `true` sẽ ngăn hành vi lưu cục bộ mặc định.

**Tại sao xuất Markdown gây ra `InvalidOperationException` từ một handler?**

Ngoại lệ này xuất hiện khi handler trả về `true` nhưng không cung cấp một liên kết hợp lệ. Gán đường dẫn tương đối hoặc URL bên ngoài mà sẽ được ghi vào Markdown trước khi trả về `true`.

**Ký tự phân tách đường dẫn nào nên được dùng cho liên kết ảnh?**

Sử dụng dấu gạch chéo `/` trong các liên kết Markdown và URL. Dùng `DIRECTORY_SEPARATOR` chỉ cho các đường dẫn hệ thống, sau đó xây dựng hoặc chuẩn hoá tham chiếu Markdown riêng.

**Liên kết siêu văn bản có được giữ lại khi xuất Markdown không?**

Có. Văn bản [siêu liên kết](/slides/vi/php-java/manage-hyperlinks/) được giữ lại dưới dạng liên kết Markdown tiêu chuẩn. [Chuyển tiếp](/slides/vi/php-java/slide-transition/) và [hoạt ảnh](/slides/vi/php-java/powerpoint-animation/) của slide không được chuyển đổi.

**Có thể chuyển đổi nhiều bản trình bày sang Markdown đồng thời không?**

Bạn có thể xử lý các tệp bản trình bày khác nhau song song, nhưng không chia sẻ cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) giữa các luồng. Tuân theo [hướng dẫn đa luồng](/slides/vi/php-java/multithreading/) và sử dụng một thể hiện riêng cho mỗi tệp.