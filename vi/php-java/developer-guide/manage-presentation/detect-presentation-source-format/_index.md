---
title: Xác định Định dạng Bản trình chiếu Gốc trong PHP
linktitle: Định dạng Nguồn
type: docs
weight: 35
url: /vi/php-java/detect-presentation-source-format/
keywords:
- định dạng nguồn
- phát hiện định dạng bản trình chiếu
- PowerPoint
- OpenDocument
- bản trình chiếu
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Đọc định dạng gốc của một bản trình chiếu đã tải trong PHP với Aspose.Slides cho PHP qua Java, so sánh các API phát hiện, và xử lý tệp, luồng và các định dạng legacy."
---
## **Tổng quan**

Sau khi tải một bản trình chiếu, gọi phương thức [Presentation::getSourceFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSourceFormat) để xác định định dạng gốc của nó. Sử dụng nó khi việc xử lý tiếp theo phụ thuộc vào định dạng mà thể hiện hiện tại đã được tải.

Định dạng nguồn khác với [SaveFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/) được chọn cho tệp đầu ra. Lưu sang định dạng khác không thay đổi định dạng nguồn của thể hiện hiện có.

## **Đọc Định dạng Nguồn của Tệp**

Ví dụ này yêu cầu một tệp `sample.pptx` hiện có. Nó tải tệp và chọn chính sách xử lý ứng dụng bằng cách sử dụng [Presentation::getSourceFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSourceFormat), thay vì dựa vào tên tệp. Thay đổi đường dẫn đầu vào để thử các định dạng khác. Ví dụ in ra chính sách đã chọn; hãy thay thế các thông báo bằng logic ứng dụng của bạn.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **Nhận dạng Các Giá trị Được Hỗ trợ**

Lớp [SourceFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sourceformat/) định nghĩa các hằng số nguyên phân biệt các định dạng bản trình chiếu sau. Các phần mở rộng dưới đây là các phần mở rộng thông thường, không phải là việc tái tạo tên tệp gốc.

| Giá trị SourceFormat | Phần mở rộng | Định dạng |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 presentation |
| `Pptx` | `.pptx` | Office Open XML presentation |
| `Pptm` | `.pptm` | Macro-enabled Office Open XML presentation |
| `Pps` | `.pps` | PowerPoint 97–2003 slide show |
| `Ppsx` | `.ppsx` | Office Open XML slide show |
| `Ppsm` | `.ppsm` | Macro-enabled Office Open XML slide show |
| `Pot` | `.pot` | PowerPoint 97–2003 template |
| `Potx` | `.potx` | Office Open XML template |
| `Potm` | `.potm` | Macro-enabled Office Open XML template |
| `Odp` | `.odp` | OpenDocument presentation |
| `Otp` | `.otp` | OpenDocument presentation template |
| `Fodp` | `.fodp` | Flat XML ODF presentation |
| `Xml` | `.xml` | PowerPoint XML presentation |

## **Đọc Định dạng Nguồn của Luồng**

Ví dụ này yêu cầu một tệp `sample.pps` hiện có. Đọc các byte của nó vào một luồng bộ nhớ mô phỏng đầu vào nhận được mà không có tên tệp, chẳng hạn như giá trị trong cơ sở dữ liệu hoặc một mảng byte đã tải lên. Hàm tạo [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) chỉ nhận luồng.

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT, PPS và POT sử dụng cùng một định dạng nhị phân nền. Khi tải bằng đường dẫn tệp, phần mở rộng có thể giúp phân biệt một trình chiếu slide hoặc mẫu. Khi không có tên tệp, nội dung PPS và POT cũ có thể được báo cáo là `SourceFormat::Ppt`; ví dụ PPS ở trên in ra giá trị nguyên của `SourceFormat::Ppt`.

Nếu ứng dụng của bạn phải giữ sự phân biệt này, hãy lưu tên tệp gốc hoặc siêu dữ liệu phụ loại riêng biệt. Phần mở rộng là một gợi ý hữu ích cho các phụ loại cũ này, nhưng không nên là cơ sở duy nhất để xác định nội dung bản trình chiếu bất kỳ.

## **So sánh Phát hiện Trước và Sau Khi Tải**

Sử dụng [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) và [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationinfo/#getLoadFormat) khi bạn cần kiểm tra một tệp trước khi tải toàn bộ mô hình đối tượng bản trình chiếu. Sử dụng [Presentation::getSourceFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSourceFormat) khi thể hiện đã tồn tại.

Ví dụ này yêu cầu `sample.pptx` và in ra các giá trị nguyên của `LoadFormat::Pptx` và `SourceFormat::Pptx`, tương ứng. Trong môi trường thực tế, chọn API phù hợp với giai đoạn xử lý của bạn; một bản trình chiếu đã được tải không cần kiểm tra lại chỉ để lấy định dạng nguồn.

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Kết quả sử dụng các hằng số từ các lớp khác nhau: [LoadFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadformat/) và [SourceFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sourceformat/). Đừng so sánh giá trị số của chúng hoặc cho rằng mọi định dạng có kết quả phát hiện giống nhau. PowerPoint XML có thể được báo cáo là `LoadFormat::Unknown` trước khi tải và `SourceFormat::Xml` sau khi tải.

## **Giữ Định dạng Nguồn và Đầu ra Riêng biệt**

Ví dụ này yêu cầu `sample.pptx` và ghi `converted.odp`. Nó in ra giá trị nguyên của `SourceFormat::Pptx` cả trước và sau khi lưu thể hiện gốc. Chỉ thể hiện mới được tải từ đầu ra ODP mới báo cáo `Odp`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Một bản trình chiếu được tạo từ đầu bằng `new Presentation()` báo cáo `SourceFormat::Pptx`. Nó không có tệp đầu vào: đây là giá trị mặc định cho một thể hiện mới tạo, không phải bằng chứng rằng một tệp PPTX đã được tải. Theo dõi xem ứng dụng của bạn đã tạo hay tải thể hiện một cách riêng biệt nếu sự phân biệt này quan trọng.

## **Ánh xạ Định dạng Nguồn sang Phần mở rộng**

Ví dụ sau yêu cầu `sample.pptx`. Nó ánh xạ mỗi giá trị [SourceFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sourceformat/) hiện được hỗ trợ sang một phần mở rộng thông thường, mà không phân tích tên tệp đầu vào. Cơ chế dự phòng tránh việc gán phần mở rộng một cách im lặng cho giá trị không nhận diện được.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Ánh xạ này không chuyển đổi tệp hoặc khôi phục phụ loại PPS/POT cũ bị mất trong quá trình tải luồng. Đối với việc lưu thực tế, hãy chọn một [SaveFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/) một cách rõ ràng, hoặc sử dụng cách chuyển đổi được mô tả trong [Save Presentations in Their Original Format](/slides/vi/php-java/save-presentation/#save-presentations-in-their-original-format).

## **Xác minh Định dạng bằng cách Lưu và Mở lại**

Ví dụ tự chứa này tạo một bản trình chiếu và ghi ba tệp trong thư mục làm việc, ghi đè các tệp cùng tên. Nó mở lại mỗi đầu ra cả bằng đường dẫn và qua luồng bộ nhớ. Đối với PPTX và ODP, cả hai cách đều báo cáo định dạng đã lưu. Đối với PPS, tải bằng đường dẫn báo cáo `Pps`, trong khi tải cùng các byte mà không có tên tệp báo cáo `Ppt`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

| Định dạng đã lưu | SourceFormat từ đường dẫn tệp | SourceFormat từ luồng không tên |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` tương ứng | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` tương ứng | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` tương ứng | Same as file path |
| ODP, OTP | `Odp`, `Otp` tương ứng | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Nội dung PPS/POT được nhận dạng là `Ppt` cho các luồng không tên. Bảng mô tả việc xác định định dạng, không phải việc bảo lưu mọi tính năng của bản trình chiếu trong quá trình chuyển đổi.

## **Câu hỏi thường gặp**

**Lưu dưới dạng ODP có làm thay đổi định dạng nguồn của bản trình chiếu đã tải từ PPTX không?**

Không. Thể hiện hiện tại vẫn báo cáo `Pptx`. Một thể hiện được tải từ tệp ODP đã lưu sẽ báo cáo `Odp`.

**Luồng có luôn phân biệt được bản trình chiếu, trình chiếu slide và mẫu cũ không?**

Không. PPT, PPS và POT chia sẻ cùng một định dạng nhị phân. Giữ tên tệp hoặc siêu dữ liệu phụ loại riêng biệt khi sự phân biệt này cần thiết.

**Tôi nên sử dụng API nào nếu bản trình chiếu đã được tải?**

Đọc [Presentation::getSourceFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getSourceFormat). Sử dụng [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationfactory/#getPresentationInfo) để kiểm tra trước khi tải.