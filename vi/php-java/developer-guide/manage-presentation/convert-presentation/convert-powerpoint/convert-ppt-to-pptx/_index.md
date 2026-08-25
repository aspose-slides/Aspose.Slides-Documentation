---
title: Chuyển đổi PPT sang PPTX trong PHP
linktitle: PPT sang PPTX
type: docs
weight: 20
url: /vi/php-java/convert-ppt-to-pptx/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- PPT sang PPTX
- lưu PPT dưới dạng PPTX
- xuất PPT sang PPTX
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Chuyển đổi các tệp PPT kế thừa sang PPTX trong PHP bằng Aspose.Slides. Bao gồm các ví dụ PHP cho chuyển đổi tệp đơn và chuyển đổi hàng loạt, xử lý lỗi và ghi chú độ chính xác."
---
## **Tổng quan**

PPT là định dạng nhị phân PowerPoint kế thừa, trong khi PPTX là định dạng Open XML mới hơn. Aspose.Slides for PHP qua Java có thể tải tệp PPT và lưu nó dưới dạng PPTX mà không cần Microsoft PowerPoint. Bài viết này trình bày cách chuyển đổi một tệp hoặc một thư mục các tệp và giải thích những gì cần kiểm tra sau khi chuyển đổi.

## **Chuyển đổi tệp PPT sang PPTX**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/), sau đó gọi [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save) với [SaveFormat::Pptx](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/#Pptx). Khối `finally` sẽ giải phóng bản trình chiếu và giải phóng các tài nguyên của nó.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Tải bản trình chiếu PPT kế thừa.
$presentation = new Presentation("presentation.ppt");
try {
    // Lưu bản trình chiếu ở định dạng PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Phần mở rộng tệp không tự động chọn định dạng đầu ra; đối số [SaveFormat::Pptx](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/#Pptx) làm điều đó. Giữ các đường dẫn đầu vào và đầu ra khác nhau nếu bạn cần giữ lại tệp PPT gốc.

## **Chuyển đổi nhiều tệp PPT**

Ví dụ sau chuyển đổi mọi tệp `.ppt` trong một thư mục. Mỗi tệp được xử lý độc lập, vì vậy một lỗi chuyển đổi sẽ không làm dừng lại phần còn lại của lô.

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

Đối với môi trường sản xuất, ghi lại toàn bộ ngoại lệ, quyết định liệu có cho phép ghi đè tệp đầu ra đã tồn tại hay không, và ghi tên các tệp thất bại vào hàng đợi thử lại hoặc xem xét. Các tệp bị hỏng, tệp được bảo vệ bằng mật khẩu mở mà không có mật khẩu đúng, các đường dẫn không thể truy cập và nội dung không được hỗ trợ đều có thể gây lỗi chuyển đổi. Xem [Password-Protected Presentations](/slides/vi/php-java/password-protected-presentation/) để tải các tệp đã mã hóa.

## **Độ chính xác và tính năng kế thừa**

Quá trình chuyển đổi thường giữ nguyên các slide, master, layout, văn bản, hình dạng, hình ảnh, bảng và biểu đồ. Tuy nhiên, PPT và PPTX không đại diện cho mọi tính năng theo cùng một cách. Một tính năng kế thừa không có tương đương PPTX, hoặc không được thư viện hỗ trợ, có thể được chuẩn hoá, bỏ qua hoặc hiển thị khác đi.

Kiểm tra tệp đã chuyển đổi khi nó chứa hoạt ảnh, chuyển tiếp, các đối tượng OLE được nhúng hoặc liên kết, điều khiển ActiveX, phương tiện nhúng, phông chữ không phổ biến, hoặc macro VBA. Tệp PPTX thông thường không phải là định dạng hỗ trợ macro, vì vậy hãy sử dụng quy trình làm việc hỗ trợ macro thích hợp khi VBA cần phải còn khả dụng. Đồng thời xác minh rằng các phông chữ và tài nguyên bên ngoài cần thiết có sẵn trong môi trường mà bản trình chiếu đã chuyển đổi sẽ được mở hoặc render.

Đối với các tài liệu quan trọng, hãy mở lại PPTX đã tạo bằng mã và kiểm tra số lượng slide và nội dung chính, sau đó so sánh giao diện và hành vi trình chiếu trong trình xem dự kiến. Không coi một lời gọi thành công của [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save) là bằng chứng rằng mọi tính năng kế thừa đều có đại diện PPTX chính xác.

## **Khi nào nên sử dụng PPTX**

Sử dụng PPTX khi bản trình chiếu sẽ được chỉnh sửa trong các phiên bản PowerPoint hiện đại, trao đổi với các hệ thống làm việc với gói Open XML, hoặc lưu trữ ở định dạng dễ kiểm tra và khôi phục hơn so với định dạng nhị phân PPT kế thừa. Giữ tệp PPT gốc làm bản lưu trữ hoặc sao lưu cho đến khi bản trình chiếu đã chuyển đổi vượt qua các kiểm tra độ chính xác của bạn.

Nếu bạn cần PDF, HTML, hình ảnh, XPS hoặc một định dạng đầu ra khác, hãy sử dụng hướng dẫn theo định dạng trong [Convert Presentations to Multiple Formats](/slides/vi/php-java/convert-presentation/) thay vì cho rằng mọi mục tiêu đều bảo tồn các tính năng PowerPoint có thể chỉnh sửa.

## **Trình chuyển đổi trực tuyến**

Đối với một tệp thỉnh thoảng hoặc so sánh nhanh, bạn có thể sử dụng [online PPT to PPTX converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx). Đối với các chuyển đổi lặp lại, xử lý hàng loạt hoặc xử lý lỗi ở mức ứng dụng, hãy sử dụng API PHP.

## **Bài viết liên quan**

- [PPT vs PPTX](/slides/vi/php-java/ppt-vs-pptx/)
- [Lưu bản trình chiếu trong PHP](/slides/vi/php-java/save-presentation/)
- [Các định dạng tệp được hỗ trợ](/slides/vi/php-java/supported-file-formats/)
- [Mở bản trình chiếu trong PHP](/slides/vi/php-java/open-presentation/)

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi PPT sang PPTX mà không cần cài đặt Microsoft PowerPoint không?**

Có. Aspose.Slides for PHP qua Java tải và lưu các tệp bản trình chiếu mà không cần Microsoft PowerPoint.

**Việc chuyển đổi PPT sang PPTX có giữ nguyên toàn bộ nội dung một cách chính xác không?**

Nó giữ lại nội dung trình chiếu thông thường, nhưng độ chính xác tuyệt đối không được đảm bảo cho mọi tính năng kế thừa hoặc không được hỗ trợ. Kiểm tra tệp đã tạo khi nó chứa macro, đối tượng OLE hoặc ActiveX, phương tiện, hoạt ảnh đặc biệt, hoặc phông chữ không phổ biến.

**Tôi có thể chuyển đổi tệp PPT được bảo vệ bằng mật khẩu không?**

Có, nếu bạn cung cấp mật khẩu đúng khi tải tệp. Thiếu mật khẩu hoặc mật khẩu không đúng sẽ làm cho thao tác tải thất bại.

**Tôi có nên xóa tệp PPT sau khi chuyển đổi không?**

Giữ bản gốc cho đến khi bạn đã xác minh PPTX trong các trình xem và quy trình làm việc quan trọng với bạn. Điều này cung cấp một bản sao dự phòng nếu một tính năng kế thừa được chuyển đổi khác nhau.