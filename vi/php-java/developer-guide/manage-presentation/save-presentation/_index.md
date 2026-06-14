---
title: Lưu Bài Trình Chiếu trong PHP
linktitle: Lưu Bài Trình Chiếu
type: docs
weight: 80
url: /vi/php-java/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bài trình chiếu
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bài trình chiếu thành tệp
- bài trình chiếu thành luồng
- kiểu xem được định nghĩa trước
- định dạng Strict Office Open XML
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến độ lưu
- PHP
- Aspose.Slides
description: "Khám phá cách lưu các bài trình chiếu bằng Aspose.Slides cho PHP thông qua Java — xuất sang PowerPoint hoặc OpenDocument đồng thời giữ nguyên bố cục, phông chữ và hiệu ứng."
---
## **Tổng quan**

[Open Presentations in PHP](/slides/vi/php-java/open-presentation/) đã mô tả cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) để mở một bài trình chiếu. Bài viết này giải thích cách tạo và lưu các bài trình chiếu. Lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) chứa nội dung của một bài trình chiếu. Cho dù bạn đang tạo một bài trình chiếu từ đầu hay chỉnh sửa một bài hiện có, bạn sẽ muốn lưu nó khi đã hoàn thành. Với Aspose.Slides cho PHP, bạn có thể lưu dưới dạng **tệp** hoặc **luồng**. Bài viết này giải thích các cách khác nhau để lưu một bài trình chiếu.

## **Lưu Bài Trình Chiếu vào Tệp**

Lưu một bài trình chiếu vào tệp bằng cách gọi phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/). Truyền tên tệp và định dạng lưu cho phương thức. Ví dụ sau cho thấy cách lưu một bài trình chiếu bằng Aspose.Slides.

```php
// Tạo một thể hiện của lớp Presentation đại diện cho tệp bài trình chiếu.
$presentation = new Presentation();
try {
    // Thực hiện một số công việc ở đây...

    // Lưu bài trình chiếu vào tệp.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lưu Bài Trình Chiếu vào Luồng**

Bạn có thể lưu một bài trình chiếu vào luồng bằng cách truyền một luồng đầu ra cho phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/). Một bài trình chiếu có thể được ghi vào nhiều loại luồng. Trong ví dụ dưới đây, chúng tôi tạo một bài trình chiếu mới và lưu nó vào một luồng tệp.

```php
// Tạo một thể hiện của lớp Presentation đại diện cho tệp bài trình chiếu.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Lưu bài trình chiếu vào luồng.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Lưu Bài Trình Chiếu với Kiểu Xem Được Định Nghĩa Trước**

Aspose.Slides cho phép bạn đặt chế độ xem ban đầu mà PowerPoint sử dụng khi bài trình chiếu được tạo mở thông qua lớp [ViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/). Sử dụng phương thức [setLastView](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/#setLastView) với một giá trị từ liệt kê [ViewType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewtype/).

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lưu Bài Trình Chiếu ở Định Dạng Strict Office Open XML**

Aspose.Slides cho phép bạn lưu một bài trình chiếu ở định dạng Strict Office Open XML. Sử dụng lớp [PptxOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxoptions/) và đặt thuộc tính conformance khi lưu. Nếu bạn đặt [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/vi/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), tệp đầu ra sẽ được lưu ở định dạng Strict Office Open XML.

Ví dụ dưới đây tạo một bài trình chiếu và lưu nó ở định dạng Strict Office Open XML.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Tạo một thể hiện của lớp Presentation đại diện cho tệp bài trình chiếu.
$presentation = new Presentation();
try {
    // Lưu bài trình chiếu ở định dạng Strict Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Lưu Bài Trình Chiếu ở Định Dạng Office Open XML ở Chế Độ Zip64**

Một tệp Office Open XML là một kho lưu ZIP áp đặt giới hạn 4 GB (2^32 byte) cho kích thước không nén của bất kỳ tệp nào, kích thước nén của bất kỳ tệp nào và tổng kích thước của kho lưu, đồng thời giới hạn số tệp trong kho lưu là 65 535 (2^16‑1). Các phần mở rộng định dạng ZIP64 nâng các giới hạn này lên 2^64.

Phương thức [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxoptions/#setZip64Mode) cho phép bạn chọn khi nào sử dụng các phần mở rộng định dạng ZIP64 khi lưu một tệp Office Open XML.

Phương thức này có thể được sử dụng với các chế độ sau:

- [IfNecessary](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zip64mode/#IfNecessary) sử dụng phần mở rộng ZIP64 chỉ khi bài trình chiếu vượt quá các hạn chế trên. Đây là chế độ mặc định.
- [Never](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zip64mode/#Never) không bao giờ sử dụng phần mở rộng ZIP64.
- [Always](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zip64mode/#Always) luôn luôn sử dụng phần mở rộng ZIP64.

Đoạn mã sau minh họa cách lưu một bài trình chiếu dưới dạng PPTX với các phần mở rộng định dạng ZIP64 được bật:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Khi bạn lưu với [Zip64Mode.Never](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zip64mode/#Never), một [PptxException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxexception/) sẽ được ném nếu bài trình chiếu không thể được lưu ở định dạng ZIP32.
{{% /alert %}}

## **Lưu Bài Trình Chiếu mà Không Làm Mới Hình Thu Nhỏ**

Phương thức [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) kiểm soát việc tạo hình thu nhỏ khi lưu một bài trình chiếu sang PPTX:

- Nếu đặt thành `true`, hình thu nhỏ sẽ được làm mới trong quá trình lưu. Đây là mặc định.
- Nếu đặt thành `false`, hình thu nhỏ hiện tại sẽ được giữ nguyên. Nếu bài trình chiếu không có hình thu nhỏ, sẽ không có hình nào được tạo.

Trong đoạn mã dưới đây, bài trình chiếu được lưu dưới dạng PPTX mà không làm mới hình thu nhỏ.

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Tùy chọn này giúp giảm thời gian cần thiết để lưu một bài trình chiếu ở định dạng PPTX.
{{% /alert %}}

## **Cập Nhật Tiến Trình Lưu theo Phần Trăm**

Báo cáo tiến độ lưu được cấu hình thông qua phương thức [setProgressCallback](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveoptions/#setProgressCallback) trên [SaveOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveoptions/) và các lớp con của nó. Cung cấp một proxy Java thực hiện giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprogresscallback/); trong quá trình xuất, callback sẽ nhận các cập nhật phần trăm định kỳ.

Các đoạn mã sau cho thấy cách sử dụng `IProgressCallback`.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Sử dụng giá trị phần trăm tiến độ ở đây.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose đã phát triển một [ứng dụng PowerPoint Splitter miễn phí](https://products.aspose.app/slides/vi/splitter) sử dụng API riêng của mình. Ứng dụng cho phép bạn tách một bài trình chiếu thành nhiều tệp bằng cách lưu các slide đã chọn dưới dạng tệp PPTX hoặc PPT mới.
{{% /alert %}}

## **Câu Hỏi Thường Gặp**

**"Lưu nhanh" (lưu tăng dần) có được hỗ trợ để chỉ ghi các thay đổi không?**

Không. Việc lưu luôn tạo ra tệp đích đầy đủ mỗi lần; tính năng “lưu nhanh” tăng dần không được hỗ trợ.

**Có an toàn với đa luồng khi lưu cùng một thể hiện Presentation từ nhiều luồng không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) [không an toàn với đa luồng](/slides/vi/php-java/multithreading/); hãy lưu nó từ một luồng duy nhất.

**Điều gì xảy ra với siêu liên kết và các tệp liên kết bên ngoài khi lưu?**

[Hyperlinks](/slides/vi/php-java/manage-hyperlinks/) được giữ nguyên. Các tệp liên kết ngoài (ví dụ, video qua đường dẫn tương đối) không được sao chép tự động — hãy đảm bảo các đường dẫn tham chiếu vẫn có thể truy cập.

**Tôi có thể đặt/lưu siêu dữ liệu tài liệu (Tác giả, Tiêu đề, Công ty, Ngày) không?**

Có. Các [thuộc tính tài liệu](/slides/vi/php-java/presentation-properties/) tiêu chuẩn được hỗ trợ và sẽ được ghi vào tệp khi lưu.