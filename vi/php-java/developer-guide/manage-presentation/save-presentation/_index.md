---
title: Lưu bản trình chiếu trong PHP
linktitle: Lưu Bản trình chiếu
type: docs
weight: 80
url: /vi/php-java/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bản trình chiếu
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bản trình chiếu thành tệp
- bản trình chiếu thành luồng
- kiểu xem đã định nghĩa trước
- Định dạng Office Open XML Strict
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến trình lưu
- PHP
- Aspose.Slides
description: "Lưu các bản trình chiếu PowerPoint và OpenDocument thành tệp hoặc luồng trong PHP với Aspose.Slides, và cấu hình đầu ra PPTX cùng báo cáo tiến độ."
---
## **Tổng quan**

Sau khi bạn tạo một bản trình chiếu hoặc [mở một bản hiện có](/slides/vi/php-java/open-presentation/), sử dụng phương thức [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save) để ghi kết quả. Aspose.Slides cho PHP thông qua Java có thể lưu một bản trình chiếu vào tệp hoặc luồng dưới định dạng PowerPoint, OpenDocument, PDF và các định dạng khác. Các phần sau đây đề cập đến các thao tác lưu tiêu chuẩn và các tùy chọn có sẵn cho đầu ra PPTX.

## **Lưu bản trình chiếu vào tệp**

Để lưu một bản trình chiếu vào tệp, truyền đường dẫn đầu ra và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/) vào phương thức [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save). Giá trị định dạng xác định loại tệp mà Aspose.Slides tạo.

Ví dụ sau tạo một bản trình chiếu và lưu nó dưới dạng tệp PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Thêm hoặc sửa nội dung bản trình chiếu ở đây.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lưu bản trình chiếu ở định dạng gốc**

Đối với các ví dụ phát hiện tệp và luồng, hành vi của các bản trình chiếu mới tạo và sự phân biệt giữa định dạng nguồn và đầu ra, xem [Determine the Original Presentation Format](/slides/vi/php-java/detect-presentation-source-format/).

Trong một ứng dụng xử lý hàng loạt, định dạng đầu vào có thể không được biết trước. Sau khi tải một tệp, đọc định dạng gốc của nó từ phương thức [Presentation::getSourceFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSourceFormat). Truyền giá trị [SourceFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sourceformat/) đã thu được vào [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideutil/#toSaveFormat) để nhận giá trị [SaveFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/) tương ứng, sau đó sử dụng [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save) để ghi bản trình chiếu đã chỉnh sửa.

Ví dụ hoàn chỉnh sau xử lý mỗi tệp trong thư mục đầu vào, cập nhật tiêu đề của nó và lưu vào thư mục đầu ra ở định dạng mà nó đã được tải:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideutil/#toSaveFormat) ánh xạ PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP và PowerPoint XML tới các định dạng lưu bản trình chiếu tương ứng. Nó chỉ ánh xạ các định dạng nguồn của bản trình chiếu; không nhằm mục đích chọn các định dạng xuất như PDF, HTML, TIFF hoặc hình ảnh. Truyền một giá trị [SourceFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sourceformat/) không được hỗ trợ hoặc không hợp lệ sẽ gây ra một [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Các tệp PPT, PPS và POT cổ điển sử dụng cùng một container nhị phân. Khi một bản trình chiếu như vậy được tải từ luồng mà không có phần mở rộng tệp, một tệp PPS hoặc POT có thể được xác định là PPT. Nếu cần bảo tồn các phụ loại cổ điển này, hãy giữ lại tên tệp gốc hoặc siêu dữ liệu định dạng riêng và sử dụng chúng khi chọn tên tệp và định dạng đầu ra.

## **Lưu bản trình chiếu vào luồng**

Để ghi một bản trình chiếu mà không dựa vào đường dẫn tệp cuối cùng, truyền một luồng có thể ghi và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/) vào phương thức [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save). Cách tiếp cận này hữu ích khi đầu ra phải được trả về từ dịch vụ web, lưu trong cơ sở dữ liệu hoặc xử lý trong bộ nhớ.

Ví dụ sau lưu một bản trình chiếu mới vào luồng tệp:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Lưu bản trình chiếu với Kiểu xem đã định nghĩa trước**

Bạn có thể chỉ định chế độ xem mà PowerPoint sẽ mở bản trình chiếu đã lưu ban đầu. Sử dụng phương thức [ViewProperties::setLastView](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/#setLastView) với một giá trị [ViewType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewtype/) trước khi lưu.

Ví dụ sau cấu hình chế độ xem Slide Master làm chế độ xem ban đầu:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lưu bản trình chiếu ở Định dạng Office Open XML Strict**

Để tạo một tệp PPTX tuân thủ hồ sơ Strict của Office Open XML, tạo một thể hiện [PptxOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxoptions/) và sử dụng phương thức [PptxOptions::setConformance](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxoptions/#setConformance) với [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/vi/php-java/aspose.slides/conformance/#Iso29500-2008-Strict). Sau đó truyền các tùy chọn này vào phương thức [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save).

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Lưu bản trình chiếu ở Định dạng Office Open XML ở chế độ Zip64**

Một tệp ZIP tiêu chuẩn giới hạn kích thước nén và không nén của mỗi mục, tổng kích thước lưu trữ và số lượng mục. Vì tệp PPTX là một tệp ZIP, một bản trình chiếu rất lớn có thể vượt qua những giới hạn này. Các phần mở rộng ZIP64 nâng cao các giới hạn kích thước và số mục áp dụng.

Sử dụng phương thức [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxoptions/#setZip64Mode) để kiểm soát việc Aspose.Slides có ghi các phần mở rộng ZIP64 hay không:

- [IfNecessary](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zip64mode/#IfNecessary) chỉ sử dụng ZIP64 khi bản trình chiếu vượt quá giới hạn ZIP tiêu chuẩn. Đây là chế độ mặc định.
- [Never](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zip64mode/#Never) tắt các phần mở rộng ZIP64.
- [Always](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zip64mode/#Always) luôn ghi các phần mở rộng ZIP64.

Ví dụ sau luôn bật phần mở rộng ZIP64 cho bản trình chiếu đầu ra:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Nếu sử dụng [Zip64Mode::Never](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zip64mode/#Never) và bản trình chiếu không thể vừa trong giới hạn ZIP tiêu chuẩn, thao tác lưu sẽ ném ra một [PptxException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Lưu bản trình chiếu ở Định dạng Office Open XML với Các mức nén**

Đối với đầu ra PPTX, bạn có thể cân bằng tốc độ lưu và kích thước tệp bằng cách sử dụng phương thức [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxoptions/#setCompressionLevel). Lớp [CompressionLevel](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/) cung cấp các giá trị sau:

- [None](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#None) lưu dữ liệu mà không nén.
- [Level1](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level1) cung cấp nén nhanh nhất và đầu ra nén lớn nhất.
- [Level2](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level2), [Level3](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level3), [Level4](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level4), [Level5](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level5) dần ưu tiên đầu ra nhỏ hơn so với tốc độ lưu.
- [Level6](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level6) cân bằng tốc độ lưu và kích thước tệp. Đây là mức mặc định.
- [Level7](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level7) và [Level8](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level8) ưu tiên đầu ra nhỏ hơn hơn nữa so với tốc độ lưu.
- [Level9](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level9) cung cấp mức nén mạnh nhất và yêu cầu thời gian xử lý lâu nhất.

Ví dụ sau lưu một bản trình chiếu mà không nén:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

Ví dụ sau sử dụng mức nén tối đa:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Lưu bản trình chiếu mà không làm mới hình thu nhỏ**

Khi một bản trình chiếu được lưu dưới dạng PPTX, phương thức [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) kiểm soát hình thu nhỏ tài liệu:

- `true` tạo lại hình thu nhỏ trong quá trình lưu. Đây là giá trị mặc định.
- `false` giữ nguyên hình thu nhỏ hiện có. Nếu bản trình chiếu không có hình thu nhỏ, Aspose.Slides sẽ không tạo mới.

Ví dụ sau lưu một bản trình chiếu mà không làm mới hình thu nhỏ:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Tắt việc làm mới hình thu nhỏ có thể giảm thời gian cần thiết để lưu tệp PPTX.
{{% /alert %}}

## **Cập nhật tiến trình lưu theo phần trăm**

Để giám sát một thao tác lưu, cung cấp một proxy Java thực hiện giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprogresscallback/) và truyền proxy này vào phương thức [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides sau đó sẽ gọi phương thức [IProgressCallback::reporting](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprogresscallback/#reporting-double-) với các giá trị tiến độ trong quá trình xuất.

Ví dụ sau báo cáo tiến độ xuất PDF tới console:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose cung cấp một công cụ [PowerPoint Splitter](https://products.aspose.app/slides/vi/splitter) miễn phí được xây dựng bằng API Aspose.Slides. Nó lưu các slide đã chọn từ một bản trình chiếu thành các tệp PPT hoặc PPTX riêng biệt.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Aspose.Slides có hỗ trợ lưu tăng dần hay “lưu nhanh” không?**

Không. Mỗi thao tác lưu ghi toàn bộ tệp đầu ra thay vì chỉ cập nhật các phần đã thay đổi.

**Nhiều luồng có thể lưu cùng một thể hiện Presentation không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) ([không an toàn với đa luồng](/slides/vi/php-java/multithreading/)). Chỉ cho phép truy cập và lưu mỗi thể hiện từ một luồng tại một thời điểm.

**Điều gì xảy ra với siêu liên kết và các tệp được liên kết bên ngoài khi tôi lưu một bản trình chiếu?**

[Hyperlinks](/slides/vi/php-java/manage-hyperlinks/) vẫn còn trong bản trình chiếu. Aspose.Slides không sao chép các tệp được liên kết bên ngoài, do đó bản trình chiếu đã lưu vẫn phải có khả năng truy cập vị trí của chúng.

**Tôi có thể lưu siêu dữ liệu tài liệu như tác giả, tiêu đề, công ty và ngày tạo không?**

Có. Đặt các [đặc tính tài liệu](/slides/vi/php-java/presentation-properties/) thích hợp trước khi lưu, và Aspose.Slides sẽ ghi chúng vào tệp đầu ra.