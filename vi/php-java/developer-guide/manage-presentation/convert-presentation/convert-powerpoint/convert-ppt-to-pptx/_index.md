---
title: Chuyển đổi PPT sang PPTX trong PHP
linktitle: PPT sang PPTX
type: docs
weight: 20
url: /vi/php-java/convert-ppt-to-pptx/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình bày
- chuyển đổi slide
- chuyển đổi PPT
- PPT sang PPTX
- lưu PPT dưới dạng PPTX
- xuất PPT sang PPTX
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Chuyển đổi các tệp PPT kế thừa sang PPTX trong PHP bằng Aspose.Slides. Bao gồm các ví dụ PHP cho việc chuyển đổi một tệp và hàng loạt, xử lý lỗi và ghi chú về độ trung thực."
---
## **Tổng quan**

PPT là định dạng PowerPoint nhị phân cổ, trong khi PPTX là định dạng Open XML mới hơn. Aspose.Slides for PHP via Java có thể tải tệp PPT và lưu nó dưới dạng PPTX mà không cần Microsoft PowerPoint. Bài viết này hướng dẫn cách chuyển đổi một tệp hoặc một thư mục các tệp và giải thích những gì cần kiểm tra sau khi chuyển đổi.

## **Chuyển đổi tệp PPT sang PPTX**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) , sau đó gọi [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save) với [SaveFormat::Pptx](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/#Pptx) . Khối `finally` sẽ giải phóng presentation và giải phóng các tài nguyên của nó.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Tải bản trình chiếu PPT kế thừa.
$presentation = new Presentation("presentation.ppt");
try {
    // Lưu bản trình chiếu dưới định dạng PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Phần mở rộng tệp không tự động chọn định dạng đầu ra; đối số [SaveFormat::Pptx](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/#Pptx) làm việc đó. Giữ đường dẫn đầu vào và đầu ra khác nhau nếu bạn cần giữ lại tệp PPT gốc.

## **Chuyển đổi nhiều tệp PPT**

Ví dụ sau chuyển đổi mọi tệp `.ppt` trong một thư mục. Mỗi tệp được xử lý độc lập, vì vậy một lỗi chuyển đổi sẽ không làm dừng phần còn lại của lô.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

Đối với môi trường sản xuất, ghi lại toàn bộ ngoại lệ, quyết định liệu có được ghi đè tệp đầu ra hiện có hay không, và ghi các tên tệp thất bại vào hàng đợi thử lại hoặc xem xét. Các tệp hỏng, tệp được bảo vệ bằng mật khẩu mà mở mà không có mật khẩu cần thiết, các đường dẫn không thể truy cập và nội dung không được hỗ trợ đều có thể gây chuyển đổi thất bại. Xem [Password-Protected Presentations](/php-java/password-protected-presentation/) để tải các tệp được mã hóa.

## **Độ trung thực và các tính năng kế thừa**

Quá trình chuyển đổi thường giữ nguyên các slide, master, layout, văn bản, hình dạng, hình ảnh, bảng và biểu đồ. Tuy nhiên, PPT và PPTX không đại diện cho mọi tính năng theo cùng một cách chính xác. Một tính năng kế thừa không có tương đương PPTX, hoặc không được thư viện hỗ trợ, có thể được chuẩn hoá, bỏ qua hoặc hiển thị khác nhau.

Kiểm tra tệp đã chuyển đổi khi nó chứa hoạt ảnh, chuyển đổi, các đối tượng OLE được nhúng hoặc liên kết, điều khiển ActiveX, phương tiện nhúng, phông chữ không phổ biến, hoặc macro VBA. Tệp PPTX thông thường không phải là định dạng hỗ trợ macro, vì vậy hãy sử dụng quy trình làm việc hỗ trợ macro phù hợp khi cần giữ lại VBA. Đồng thời xác minh rằng các phông chữ cần thiết và tài nguyên bên ngoài có mặt trong môi trường nơi bản trình bày đã chuyển đổi sẽ được mở hoặc render.

Đối với các tài liệu quan trọng, hãy mở lại PPTX được tạo một cách lập trình và kiểm tra số lượng slide và nội dung chính, sau đó so sánh giao diện và hành vi trình chiếu trong trình xem dự định. Không nên coi một lời gọi [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save) thành công là bằng chứng rằng mọi tính năng kế thừa đều có đại diện PPTX chính xác.

## **Khi nào nên sử dụng PPTX**

Sử dụng PPTX khi bản trình bày sẽ được chỉnh sửa trong các phiên bản PowerPoint hiện tại, trao đổi với các hệ thống làm việc với gói Open XML, hoặc lưu trữ ở định dạng dễ kiểm tra và khôi phục hơn so với PPT nhị phân kế thừa. Giữ lại tệp PPT gốc như bản lưu trữ hoặc sao lưu cho đến khi bản trình bày đã chuyển đổi vượt qua các kiểm tra độ trung thực của bạn.

Nếu bạn cần PDF, HTML, hình ảnh, XPS hoặc định dạng đầu ra khác, hãy sử dụng hướng dẫn theo định dạng trong [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) thay vì giả định rằng mọi mục tiêu đều giữ lại các tính năng PowerPoint có thể chỉnh sửa.

## **Trình chuyển đổi trực tuyến**

Đối với một tệp cá nhân hoặc so sánh nhanh, bạn có thể sử dụng [online PPT to PPTX converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx) . Đối với các chuyển đổi lặp lại, xử lý hàng loạt hoặc xử lý lỗi ở mức ứng dụng, hãy sử dụng PHP API.

## **Bài viết liên quan**

- [PPT vs PPTX](/php-java/ppt-vs-pptx/)
- [Lưu bản trình bày trong PHP](/php-java/save-presentation/)
- [Định dạng tệp được hỗ trợ](/php-java/supported-file-formats/)
- [Mở bản trình bày trong PHP](/php-java/open-presentation/)

## **Câu hỏi thường gặp**

**Có thể chuyển đổi PPT sang PPTX mà không cài đặt Microsoft PowerPoint không?**

Có. Aspose.Slides for PHP via Java tải và lưu các tệp bản trình bày mà không cần Microsoft PowerPoint.

**Quá trình chuyển đổi PPT sang PPTX có giữ nguyên toàn bộ nội dung một cách chính xác không?**

Nó giữ nguyên nội dung trình bày phổ biến, nhưng độ trung thực chính xác không được đảm bảo cho mọi tính năng kế thừa hoặc không được hỗ trợ. Kiểm tra tệp đã tạo khi nó chứa macro, đối tượng OLE hoặc ActiveX, phương tiện, hoạt ảnh chuyên biệt, hoặc phông chữ không phổ biến.

**Có thể chuyển đổi tệp PPT được bảo vệ bằng mật khẩu không?**

Có, nếu bạn cung cấp mật khẩu đúng khi tải tệp. Thiếu hoặc sai mật khẩu sẽ khiến thao tác tải thất bại.

**Có nên xóa tệp PPT sau khi chuyển đổi không?**

Giữ lại tệp gốc cho đến khi bạn đã xác minh PPTX trong các trình xem và quy trình làm việc quan trọng đối với bạn. Điều này cung cấp bản sao dự phòng nếu một tính năng kế thừa được chuyển đổi khác nhau.