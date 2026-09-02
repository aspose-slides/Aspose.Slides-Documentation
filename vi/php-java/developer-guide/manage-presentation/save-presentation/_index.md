---
title: Lưu Bản Trình Chiếu trong PHP
linktitle: Lưu Bản Trình Chiếu
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
- định dạng Office Open XML nghiêm ngặt
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến độ lưu
- PHP
- Aspose.Slides
description: "Khám phá cách lưu bản trình chiếu bằng Aspose.Slides cho PHP thông qua Java — xuất ra PowerPoint hoặc OpenDocument đồng thời giữ nguyên bố cục, phông chữ và hiệu ứng."
---
## **Tổng quan**

[Open Presentations in PHP](/slides/vi/php-java/open-presentation/) mô tả cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) để mở một bản trình chiếu. Bài viết này giải thích cách tạo và lưu các bản trình chiếu. Lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) chứa nội dung của bản trình chiếu. Cho dù bạn đang tạo một bản trình chiếu từ đầu hay chỉnh sửa một bản hiện có, bạn sẽ muốn lưu lại khi hoàn thành. Với Aspose.Slides cho PHP, bạn có thể lưu thành **file** hoặc **stream**. Bài viết này giải thích các cách khác nhau để lưu một bản trình chiếu.

## **Lưu Bản Trình Chiếu vào Tập Tin**

Lưu một bản trình chiếu thành một tập tin bằng cách gọi phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/). Cung cấp tên tập tin và định dạng lưu cho phương thức. Ví dụ dưới đây cho thấy cách lưu một bản trình chiếu bằng Aspose.Slides.

```php
// Tạo một đối tượng lớp Presentation đại diện cho một tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Thực hiện một số công việc ở đây...

    // Lưu bản trình chiếu vào tệp.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lưu Bản Trình Chiếu vào Luồng**

Bạn có thể lưu một bản trình chiếu vào luồng bằng cách truyền một luồng đầu ra cho lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/). Một bản trình chiếu có thể được ghi vào nhiều loại luồng. Trong ví dụ dưới đây, chúng tôi tạo một bản trình chiếu mới và lưu nó vào một luồng tập tin.

```php
// Tạo một đối tượng lớp Presentation đại diện cho một tệp bản trình chiếu.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Lưu bản trình chiếu vào luồng.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Lưu Bản Trình Chiếu với Kiểu Xem Được Định Nghĩa Trước**

Aspose.Slides cho phép bạn thiết lập chế độ xem ban đầu mà PowerPoint sử dụng khi bản trình chiếu được tạo mở ra thông qua lớp [ViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/). Sử dụng phương thức [setLastView](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/#setLastView) với một giá trị từ liệt kê [ViewType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewtype/).

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lưu Bản Trình Chiếu ở Định Dạng Office Open XML Nghiêm Ngặt**

Aspose.Slides cho phép bạn lưu một bản trình chiếu ở định dạng Office Open XML Nghiêm Ngặt. Sử dụng lớp [PptxOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxoptions/) và đặt thuộc tính conformance khi lưu. Nếu bạn đặt [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/vi/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), tệp đầu ra sẽ được lưu ở định dạng Office Open XML Nghiêm Ngặt.

Ví dụ dưới đây tạo một bản trình chiếu và lưu nó ở định dạng Office Open XML Nghiêm Ngặt.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Tạo một đối tượng lớp Presentation đại diện cho một tệp bản trình chiếu.
$presentation = new Presentation();
try {
    // Lưu bản trình chiếu ở định dạng Office Open XML nghiêm ngặt.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Lưu Bản Trình Chiếu ở Định Dạng Office Open XML ở Chế Độ Zip64**

Tệp Office Open XML là một kho lưu trữ ZIP áp đặt các giới hạn 4 GB (2^32 byte) cho kích thước chưa nén của bất kỳ tệp nào, kích thước nén của bất kỳ tệp nào và tổng kích thước của kho lưu trữ, và cũng giới hạn số tệp trong kho lên 65 535 (2^16‑1) tệp. Các phần mở rộng định dạng ZIP64 nâng các giới hạn này lên 2^64.

Phương thức [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxoptions/#setZip64Mode) cho phép bạn chọn khi nào sử dụng các phần mở rộng định dạng ZIP64 khi lưu một tệp Office Open XML.

Phương thức này có thể được sử dụng với các chế độ sau:

- [IfNecessary](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zip64mode/#IfNecessary) sử dụng các phần mở rộng định dạng ZIP64 chỉ khi bản trình chiếu vượt quá các giới hạn trên. Đây là chế độ mặc định.
- [Never](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zip64mode/#Never) không bao giờ sử dụng các phần mở rộng định dạng ZIP64.
- [Always](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zip64mode/#Always) luôn luôn sử dụng các phần mở rộng định dạng ZIP64.

Đoạn mã dưới đây minh họa cách lưu một bản trình chiếu dưới dạng tệp PPTX với các phần mở rộng định dạng ZIP64 được bật:

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
Khi bạn lưu với [Zip64Mode.Never](https://reference.aspose.com/slides/vi/php-java/aspose.slides/zip64mode/#Never), một [PptxException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxexception/) sẽ được ném nếu bản trình chiếu không thể được lưu ở định dạng ZIP32.
{{% /alert %}}

## **Lưu Bản Trình Chiếu ở Định Dạng Office Open XML với Các Mức Nén**

Khi làm việc với các bản trình chiếu lớn, bạn có thể điều chỉnh mức nén để cân bằng giữa kích thước tệp và thời gian xử lý. Tùy theo yêu cầu, bạn có thể ưu tiên xử lý nhanh hơn hoặc tệp đầu ra nhỏ hơn.

Aspose.Slides cung cấp phương thức [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxoptions/#setCompressionLevel), cho phép bạn chỉ định mức nén được sử dụng khi lưu một bản trình chiếu ở định dạng Office Open XML.

Các mức nén sau đây có sẵn:

- [**None**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#None): Không áp dụng nén. Các tệp được lưu nguyên trạng.
- [**Level1**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level1): Nén nhanh nhất với tỷ lệ nén thấp nhất.
- [**Level2**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level2): Nén nhanh hơn với tỷ lệ nén hơi tốt hơn so với **Level1**.
- [**Level3**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level3): Cung cấp nén tốt hơn so với **Level2** với ảnh hưởng vừa phải đến thời gian xử lý.
- [**Level4**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level4): Cung cấp nén tốt hơn so với **Level3**.
- [**Level5**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level5): Cải thiện nén so với **Level4** với thời gian xử lý bổ sung.
- [**Level6**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level6): Nén tiêu chuẩn cung cấp cân bằng tốt giữa tốc độ xử lý và kích thước tệp. Đây là *mức nén mặc định*.
- [**Level7**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level7): Cung cấp nén tốt hơn so với **Level6** nhưng chậm hơn trong quá trình xử lý.
- [**Level8**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level8): Cung cấp nén tốt hơn so với **Level7**.
- [**Level9**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compressionlevel/#Level9): Nén tối đa. Tạo kích thước tệp nhỏ nhất với chi phí thời gian xử lý lâu nhất.

Ví dụ dưới đây minh họa cách lưu một bản trình chiếu dưới dạng tệp PPTX *không có nén*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

Ví dụ này cho thấy cách lưu một bản trình chiếu dưới dạng tệp PPTX với *nén tối đa*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **Lưu Bản Trình Chiếu mà Không Làm Mới Hình Thu Nhỏ**

Phương thức [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) kiểm soát việc tạo hình thu nhỏ khi lưu một bản trình chiếu thành PPTX:

- Nếu được đặt thành `true`, hình thu nhỏ sẽ được làm mới trong quá trình lưu. Đây là mặc định.
- Nếu được đặt thành `false`, hình thu nhỏ hiện tại sẽ được giữ nguyên. Nếu bản trình chiếu không có hình thu nhỏ, sẽ không tạo mới.

Trong đoạn mã dưới đây, bản trình chiếu được lưu dưới dạng PPTX mà không làm mới hình thu nhỏ của nó.

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
Tùy chọn này giúp giảm thời gian cần thiết để lưu một bản trình chiếu ở định dạng PPTX.
{{% /alert %}}

## **Lưu Cập Nhật Tiến Trình theo Phần Trăm**

Báo cáo tiến độ lưu được cấu hình qua phương thức [setProgressCallback](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveoptions/#setProgressCallback) trên [SaveOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveoptions/) và các lớp con của nó. Cung cấp một proxy Java thực hiện giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprogresscallback/); trong quá trình xuất, callback sẽ nhận các cập nhật phần trăm theo định kỳ.

Đoạn mã dưới đây cho thấy cách sử dụng `IProgressCallback`.

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
Aspose đã phát triển một ứng dụng [PowerPoint Splitter miễn phí](https://products.aspose.app/slides/vi/splitter) sử dụng API của mình. Ứng dụng cho phép bạn tách một bản trình chiếu thành nhiều tệp bằng cách lưu các slide đã chọn dưới dạng tệp PPTX hoặc PPT mới.
{{% /alert %}}

## **Câu hỏi thường gặp**

**"Lưu nhanh" (lưu tăng) có được hỗ trợ để chỉ ghi các thay đổi không?**

Không. Khi lưu luôn tạo ra toàn bộ tệp đích mỗi lần; "lưu nhanh" tăng dần không được hỗ trợ.

**Có an toàn đa luồng khi lưu cùng một thể hiện Presentation từ nhiều luồng không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) [không an toàn đa luồng](/slides/vi/php-java/multithreading/); hãy lưu nó từ một luồng duy nhất.

**Điều gì xảy ra với siêu liên kết và các tệp liên kết ngoại khi lưu?**

[Hyperlinks](/slides/vi/php-java/manage-hyperlinks/) được giữ nguyên. Các tệp liên kết ngoại (ví dụ, video qua đường dẫn tương đối) không được sao chép tự động — hãy đảm bảo các đường dẫn tham chiếu vẫn có thể truy cập.

**Tôi có thể đặt/lưu siêu dữ liệu tài liệu (Tác giả, Tiêu đề, Công ty, Ngày) không?**

Có. Các [document properties](/slides/vi/php-java/presentation-properties/) tiêu chuẩn được hỗ trợ và sẽ được ghi vào tệp khi lưu.