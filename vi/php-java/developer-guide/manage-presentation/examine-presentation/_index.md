---
title: Truy xuất và Cập nhật Thông tin Bản trình bày trong PHP
linktitle: Thông tin Bản trình bày
type: docs
weight: 30
url: /vi/php-java/examine-presentation/
keywords:
- định dạng bản trình bày
- thuộc tính bản trình bày
- thuộc tính tài liệu
- lấy thuộc tính
- đọc thuộc tính
- thay đổi thuộc tính
- sửa đổi thuộc tính
- cập nhật thuộc tính
- kiểm tra PPTX
- kiểm tra PPT
- kiểm tra ODP
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho PHP để có những hiểu biết nhanh hơn và kiểm toán nội dung thông minh hơn."
---
## **Tổng quan**

Aspose.Slides có thể xác định định dạng của một bản trình bày và đọc siêu dữ liệu tài liệu mà không cần tạo mô hình đối tượng bản trình bày đầy đủ. Điều này hữu ích khi bạn cần phân loại tệp, xây dựng một danh sách kiểm kê, hoặc kiểm tra các thuộc tính trước khi quyết định có tải và xử lý nội dung bản trình bày hay không.

Bài viết này minh họa việc kiểm tra nhẹ nhàng thông qua [PresentationFactory](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/) và [PresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/), cũng như các cập nhật có mục tiêu thông qua [DocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/).

## **Kiểm tra định dạng bản trình bày**

Sử dụng [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/) để kiểm tra một tệp mà không tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/). Phương thức [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#getLoadFormat) báo cáo định dạng được phát hiện, chẳng hạn PPTX, PPT hoặc ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **Xây dựng một danh sách kiểm kê bản trình bày nhẹ**

Khi bạn xử lý nhiều tệp bản trình bày, bạn có thể cần một danh sách kiểm kê gọn nhẹ để xác thực, lập chỉ mục, hoặc cho hệ thống quản lý tài liệu. Trong trường hợp này, sử dụng [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/) để lấy một đối tượng [PresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/), sau đó gọi [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#readDocumentProperties) để đọc siêu dữ liệu tài liệu. Cách tiếp cận này không tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) và không yêu cầu bạn duyệt toàn bộ mô hình đối tượng bản trình bày.

Các thuộc tính mở rộng được cung cấp bởi [DocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/) cung cấp các giá trị kiểm kê sau:

| Phương thức | Giá trị kiểm kê |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#getSlides) | Tổng số slide. |
| [getHiddenSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#getHiddenSlides) | Số slide ẩn. |
| [getNotes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#getNotes) | Số slide có ghi chú. |
| [getParagraphs](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#getParagraphs) | Tổng số đoạn, nếu có. |
| [getWords](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#getWords) | Tổng số từ. |
| [getMultimediaClips](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#getMultimediaClips) | Tổng số clip âm thanh và video. |

Ví dụ dưới đây đọc các giá trị này mà không tạo một đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) và in ra một danh sách kiểm kê gọn nhẹ. Nó cũng kết hợp [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#getHeadingPairs) với [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#getTitlesOfParts) để hiển thị các nhóm nội dung như phông chữ, giao diện và tiêu đề slide.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

Mỗi [HeadingPair](https://reference.aspose.com/slides/vi/php-java/aspose.slides/headingpair/) cung cấp tên nhóm và số mục trong nhóm đó. [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#getTitlesOfParts) trả về một mảng phẳng, có thứ tự, vì vậy hãy tiêu thụ số lượng tiêu đề liên tiếp được chỉ định bởi mỗi heading pair.

### **Siêu dữ liệu lưu trữ và hạn chế định dạng**

Các thuộc tính kiểm kê được trả về bởi [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#readDocumentProperties) phản ánh siêu dữ liệu có sẵn trong tài liệu nguồn. Aspose.Slides không tải và duyệt mô hình đối tượng bản trình bày để tính lại các giá trị này cho lời gọi này. Các thuộc tính bị thiếu được biểu thị bằng các giá trị mặc định, và các giá trị đã lưu có thể lỗi thời nếu ứng dụng đã lưu file lần cuối không cập nhật các thuộc tính tài liệu.

- **PPTX:** Định dạng này cung cấp các thuộc tính tài liệu mở rộng cho số lượng slide, ghi chú, slide ẩn, đoạn, từ và đa phương tiện, cũng như các heading pair và tiêu đề phần. Tính khả dụng phụ thuộc vào các thuộc tính mà nhà sản xuất tài liệu đã ghi.
- **PPT:** Định dạng nhị phân có thể lưu các thuộc tính tóm tắt tài liệu tương ứng. Nếu một thuộc tính vắng mặt hoặc không được nhà sản xuất tài liệu làm mới, Aspose.Slides sẽ trả về giá trị đã lưu hoặc giá trị mặc định thay vì tính toán từ các slide.
- **ODP:** Siêu dữ liệu OpenDocument cung cấp các thống kê tổng quan của tài liệu, chẳng hạn số trang, đoạn và từ, nhưng các giá trị này không tương ứng với mọi thuộc tính mở rộng đặc thù của PowerPoint. Siêu dữ liệu slide ẩn, slide ghi chú, đa phương tiện, heading-pair và tiêu đề phần có thể không có, và các thuộc tính kiểm kê có thể trả về giá trị mặc định. Đừng coi giá trị zero hoặc mảng rỗng là bằng chứng chắc chắn rằng nội dung tương ứng không tồn tại.

Sử dụng cách tiếp cận siêu dữ liệu nhẹ cho các danh sách kiểm kê và kiểm tra sơ bộ. Tải bản trình bày và kiểm tra mô hình đối tượng trực tiếp khi kết quả phải phản ánh các thay đổi trong bộ nhớ hoặc khi bạn cần xác minh nội dung thực tế của bản trình bày.

## **Cập nhật thuộc tính bản trình bày**

Các thuộc tính trả về bởi [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#readDocumentProperties) cũng có thể được thay đổi mà không tạo một thể hiện của [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/). Áp dụng các thay đổi bằng [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#updateDocumentProperties), rồi ghi bản trình bày đã liên kết bằng [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Hình ảnh dưới đây hiển thị các thuộc tính tài liệu gốc.

![Thuộc tính tài liệu gốc của bản trình bày PowerPoint](input_properties.png)

Ví dụ dưới đây thay đổi tiêu đề và thời gian lưu lần cuối và ghi kết quả vào một tệp mới:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

Hình ảnh dưới đây hiển thị các thuộc tính tài liệu đã cập nhật.

![Thuộc tính tài liệu đã thay đổi của bản trình bày PowerPoint](output_properties.png)

## **Liên kết hữu ích**

Đối với các kiểm tra bảo mật liên quan và cài đặt bảo vệ, xem các bài viết sau:

- [Bảo vệ bản trình bày bằng mật khẩu](/slides/vi/php-java/password-protected-presentation/)
- [Bảo vệ bản trình bày khi ghi](/slides/vi/php-java/write-protected-presentation/)

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể kiểm tra xem phông chữ có được nhúng hay không và chúng là những phông chữ nào?**

Tải bản trình bày và sử dụng [Presentation::getFontsManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getFontsManager). Gọi [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) để lấy các phông chữ đã nhúng và [FontsManager::getFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/#getFonts) để lấy các phông chữ được sử dụng trong bản trình bày. So sánh hai kết quả để tìm các phông chữ cần thiết cho việc hiển thị nhưng chưa được nhúng.

**Làm thế nào tôi có thể nhanh chóng xác định tệp có slide ẩn hay không và có bao nhiêu?**

Khi siêu dữ liệu tài liệu được lưu trữ đủ, đọc [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/documentproperties/#getHiddenSlides) thông qua [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/) và [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#readDocumentProperties). Cách này phù hợp cho một danh sách kiểm kê nhẹ. Nếu bản trình bày đã được sửa đổi trong bộ nhớ, siêu dữ liệu đã lưu có thể thiếu hoặc lỗi thời, hoặc bạn cần xác minh các giá trị trực tiếp, hãy duyệt qua [Presentation::getSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSlides) và kiểm tra phương thức [Slide::getHidden](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getHidden) của mỗi slide.

**Tôi có thể phát hiện liệu kích thước và hướng slide tùy chỉnh có được sử dụng hay không, và chúng có khác so với mặc định không?**

Có. Tải bản trình bày và gọi [Presentation::getSlideSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSlideSize). Sử dụng [SlideSize::getType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidesize/#getSize) và [SlideSize::getOrientation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidesize/#getOrientation) để so sánh các cài đặt hiện tại với các thiết lập và kích thước mặc định dự kiến.

**Có cách nhanh chóng để xem biểu đồ có tham chiếu nguồn dữ liệu bên ngoài không?**

Có. Tìm mỗi [Chart](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chart/) và gọi [ChartData::getDataSourceType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/#getDataSourceType). Đối với một workbook bên ngoài, gọi [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). Loại nguồn dữ liệu và đường dẫn xác định một tham chiếu bên ngoài, nhưng việc xác minh xem mục tiêu có khả dụng hay không cần kiểm tra tài nguyên riêng.

**Làm thế nào tôi có thể đánh giá các slide 'nặng' có thể làm chậm việc render hoặc xuất PDF?**

Không có một thuộc tính độ phức tạp duy nhất. Duyệt [Presentation::getSlides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSlides) và bộ sưu tập [BaseSlide::getShapes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslide/#getShapes) của mỗi slide. Sử dụng số lượng hình dạng và sự hiện diện của hình ảnh lớn, hiệu ứng, hoạt ảnh hoặc đa phương tiện như các tín hiệu sàng lọc, và đo một lần render hoặc xuất mẫu trước khi coi một slide là nút thắt hiệu năng đã được xác nhận.