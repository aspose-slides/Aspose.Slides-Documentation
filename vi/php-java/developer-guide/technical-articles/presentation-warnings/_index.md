---
title: Xử lý Cảnh báo Bản trình chiếu trong PHP
type: docs
weight: 90
url: /vi/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback cảnh báo
- chính sách cảnh báo
- mất dữ liệu
- hỏng nguồn
- vấn đề tương thích
- thay thế phông chữ
- chữ ký kỹ thuật số
- tải bản trình chiếu
- kết xuất bản trình chiếu
- chuyển đổi bản trình chiếu
- lưu bản trình chiếu
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Tìm hiểu cách thu thập, phân loại và xử lý các cảnh báo khi tải, render, chuyển đổi và lưu bản trình chiếu với Aspose.Slides cho PHP thông qua Java."
---
## **Tổng quan**

Aspose.Slides có thể báo cáo các vấn đề có thể khôi phục được khi nó tải, render, chuyển đổi hoặc lưu một bản trình chiếu. Ví dụ bao gồm các bản ghi nguồn bị hỏng, nội dung không thể bảo tồn, thay thế phông chữ và các hạn chế của định dạng đích. Một callback cảnh báo cho phép ứng dụng ghi lại các điều kiện này và quyết định liệu hoạt động hiện tại có thể tiếp tục hay không.

Tạo một lớp PHP với phương thức công khai `warning` và exposé nó qua PHP Java Bridge dưới dạng giao diện Java [IWarningCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarningcallback/) bằng `java_closure`. Kiểm tra các giá trị [getWarningType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/#getWarningType--) và [getDescription](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/#getDescription--) được cung cấp qua [IWarningInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/). Trả về [ReturnAction::Continue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/returnaction/#Continue) để chấp nhận cảnh báo hoặc [ReturnAction::Abort](https://reference.aspose.com/slides/vi/php-java/aspose.slides/returnaction/#Abort) để dừng hoạt động.

Sử dụng [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setWarningCallback) cho các cảnh báo được phát sinh khi mở bản trình chiếu. Các lớp tùy chọn render và xuất kế thừa [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveoptions/#setWarningCallback), nhận cảnh báo từ việc render slide, chuyển đổi và lưu. Vì cảnh báo tự nó không xác định hoạt động của ứng dụng, hãy liên kết mỗi thể hiện callback với một giai đoạn hoạt động khi bạn xây dựng báo cáo hợp nhất.

## **Cảnh báo và Ngoại lệ**

Các ngoại lệ Java được exposé tới PHP thông qua PHP Java Bridge; bắt chúng ở ranh giới hoạt động, như trong ví dụ bên dưới. Các liên kết giao diện Java trong bài này mô tả hợp đồng callback được bridge sử dụng.

Một cảnh báo mô tả một điều kiện mà Aspose.Slides có thể khôi phục nếu callback trả về `ReturnAction::Continue`. Một ngoại lệ có nghĩa là hoạt động yêu cầu không thể hoàn thành bình thường; ngoại lệ không được chuyển đổi thành cảnh báo và không thể được xử lý bằng chính sách cảnh báo.

Trả về `ReturnAction::Abort` yêu cầu bộ phân phối cảnh báo chấm dứt hoạt động hiện tại bằng cách ném một ngoại lệ. Ngoại lệ công khai phụ thuộc vào hoạt động và định dạng bản trình chiếu. Ví dụ, quá trình tải có thể phát sinh một [PptxReadException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxreadexception/) hoặc [PptReadException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptreadexception/), trong khi lưu hoặc xuất có thể phát sinh một [PptxException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pptxexception/). Xử lý ngoại lệ tại ranh giới của hoạt động và dùng báo cáo cảnh báo để xác định liệu chính sách ứng dụng đã gây ra việc chấm dứt hay không, thay vì dựa vào một kiểu con ngoại lệ hay thông điệp duy nhất. Callback ghi lại cảnh báo trước khi trả về `ReturnAction::Abort`, đảm bảo lý do vẫn có sẵn cho ứng dụng.

## **Danh mục Cảnh báo**

Lớp [WarningType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/warningtype/) cung cấp các hằng số nguyên cho các danh mục sau:

| Loại cảnh báo | Ý nghĩa | Chính sách điển hình |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/vi/php-java/aspose.slides/warningtype/#SourceFileCorruption) | Bản trình chiếu nguồn chứa lỗi có thể làm cho tài liệu được lưu ở định dạng gốc không sử dụng được. | Abort. |
| [DataLoss](https://reference.aspose.com/slides/vi/php-java/aspose.slides/warningtype/#DataLoss) | Văn bản, biểu đồ, hình ảnh hoặc dữ liệu khác có thể bị thiếu sau khi tải hoặc lưu. | Abort. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/vi/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | Bản trình chiếu có thể mất định dạng quan trọng. | Abort trong chế độ kiểm tra nghiêm ngặt; nếu không, ghi lại và tiếp tục. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/vi/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | Có thể xảy ra một sự khác biệt định dạng hạn chế. | Ghi lại để chẩn đoán và tiếp tục. |
| [CompatibilityIssue](https://reference.aspose.com/slides/vi/php-java/aspose.slides/warningtype/#CompatibilityIssue) | Kết quả có thể không mở hoặc hoạt động đúng trong một số ứng dụng hoặc phiên bản cũ. | Ghi log và tiếp tục trừ khi tính tương thích là bắt buộc. |
| [UnexpectedContent](https://reference.aspose.com/slides/vi/php-java/aspose.slides/warningtype/#UnexpectedContent) | Nguồn chứa nội dung không được hỗ trợ hoặc không nhận dạng được, ảnh hưởng chưa biết. | Ghi lại và tiếp tục, hoặc xem như lỗi trong chính sách nghiêm ngặt. |

Danh mục nên quyết định chính sách. Lưu giá trị trả về bởi [getDescription](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/#getDescription--) cho mục đích chẩn đoán, nhưng không dựa vào nội dung của nó cho logic ứng dụng vì văn bản thông điệp có thể thay đổi giữa các kịch bản cảnh báo và các phiên bản sản phẩm.

## **Thu thập và Phân loại Cảnh báo**

Ví dụ sau sử dụng một báo cáo cấp ứng dụng cho toàn bộ pipeline xử lý. Một thể hiện callback riêng biệt gắn nhãn cảnh báo từ tải, render, chuyển đổi PDF và lưu PPTX. Chính sách abort khi có lỗi nguồn hoặc mất dữ liệu, tùy chọn abort khi có mất định dạng nghiêm trọng, và tiếp tục cho các cảnh báo khác. Callback chuyển các giá trị cảnh báo sang kiểu PHP gốc bằng `java_values` trước khi ghi lại và so sánh chúng.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

Truyền `false` cho `abortOnMajorFormattingLoss` khi khởi tạo `WarningPolicy` nếu chấp nhận sự khác biệt định dạng lớn. Các vấn đề tương thích, mất định dạng nhẹ và nội dung không mong đợi vẫn được giữ trong báo cáo ngay cả khi hoạt động tiếp tục. Mở rộng `WarningPolicy::getAction` nếu ứng dụng phải từ chối bất kỳ danh mục nào trong số đó.

## **Kịch bản Cảnh báo Thông thường**

Cảnh báo có thể xuất hiện ở các giai đoạn khác nhau của quy trình làm việc:

- **Chữ ký kỹ thuật số:** Một bản trình chiếu đã ký có thể tạo ra cảnh báo khi tải rằng chữ ký sẽ bị mất trong quá trình xử lý. Aspose.Slides báo cáo điều kiện `DataLoss` này qua [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentationsignedwarninginfo/). Callback ở giai đoạn tải cho phép ứng dụng từ chối tệp hoặc chấp nhận mất mát đã báo cáo.
- **Thay thế phông chữ:** Một phông chữ không có sẵn có thể được thay thế khi slide được render hoặc xuất. Cảnh báo thay thế phông chữ được báo cáo là `DataLoss`, vì vậy chính sách nghiêm ngặt ở trên sẽ abort ngay cả khi ứng dụng cho rằng một thay thế cụ thể là chấp nhận được về mặt thị giác. Để quan sát hành vi này, sử dụng bản trình chiếu đầu vào có văn bản bằng phông chữ không có trong môi trường chạy. Mô tả cảnh báo xác định việc thay thế; cấu hình các phông chữ cần thiết hoặc [font substitution rules](/slides/vi/php-java/font-substitution/) trước khi thử lại.
- **Nội dung không được hỗ trợ hoặc không mong đợi:** Trình tải có thể gặp các bản ghi hoặc tính năng mà nó không nhận dạng. Các cảnh báo này có thể dùng `UnexpectedContent`, hoặc một danh mục nghiêm trọng hơn khi dữ liệu hoặc định dạng bị ảnh hưởng.
- **Tương thích định dạng:** Lưu sang một định dạng bản trình chiếu khác có thể bỏ qua tính năng hoặc tạo ra kết quả hoạt động khác trong một số ứng dụng. Ví dụ, lưu một bản trình chiếu có hơn tám hướng dẫn vẽ ngang hoặc dọc vào PPT cổ điển sẽ báo cáo một `CompatibilityIssue`. Callback ở giai đoạn lưu có thể ghi lại mất mát và tiếp tục, hoặc từ chối nếu yêu cầu bảo toàn tất cả các hướng dẫn.
- **Hành vi tải:** Các tùy chọn tải và hành vi legacy cũng có thể tạo ra cảnh báo. Ví dụ, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) xác định việc sử dụng hành vi khóa bản trình chiếu lỗi thời như một `CompatibilityIssue`.

Cảnh báo phụ thuộc vào tài liệu nguồn, định dạng đích, hoạt động và phiên bản Aspose.Slides. Đừng cho rằng mọi tệp sẽ tạo ra cảnh báo hoặc một kịch bản luôn chỉ thuộc một danh mục duy nhất.

## **Xử lý An toàn Khi Hoạt động Bị Hủy**

Khi một callback trả về `ReturnAction::Abort`, đừng sử dụng đối tượng đã thất bại khi tải và đừng giả định rằng đầu ra render hoặc lưu đã hoàn thành. Hoạt động có thể chấm dứt sau khi tạo tệp đầu ra nhưng trước khi hoàn tất.

Lưu kết quả đã xác thực vào một đường dẫn riêng như `validated-output.pptx`. Thay thế bản trình chiếu hiện có chỉ sau khi hoạt động kết thúc thành công, báo cáo cảnh báo đáp ứng chính sách ứng dụng, và đầu ra có thể mở và kiểm tra. Điều này tránh việc ghi đè lên tệp nguồn hợp lệ bằng một kết quả một phần hoặc bị từ chối.

Báo cáo cảnh báo trống không đảm bảo mọi tính năng nguồn đã được bảo tồn. Áp dụng các kiểm tra nội dung và hình ảnh bổ sung theo yêu cầu của ứng dụng. Xem thêm [Open Presentations](/slides/vi/php-java/open-presentation/) và [Save Presentations](/slides/vi/php-java/save-presentation/).

## **Câu hỏi Thường gặp**

**Callback cảnh báo có thể xử lý mọi lỗi Aspose.Slides không?**

Không. Nó chỉ xử lý các điều kiện có thể khôi phục được và được báo cáo dưới dạng cảnh báo. Các ngoại lệ xảy ra độc lập với callback phải được ứng dụng xử lý quanh các lệnh tải, render, chuyển đổi hoặc lưu.

**Việc trả về `ReturnAction::Continue` có đảm bảo đầu ra giống hệt không?**

Không. Nó chỉ cho phép quá trình tiếp tục. Điều kiện đã báo cáo vẫn có thể gây ra sự khác biệt về dữ liệu, định dạng hoặc tương thích, vì vậy hãy xem xét các loại và mô tả cảnh báo đã thu thập.

**Ứng dụng có thể xác định hoạt động nào đã tạo ra cảnh báo như thế nào?**

Tạo một thể hiện callback cho mỗi hoạt động và lưu một giai đoạn do ứng dụng định nghĩa cùng với các giá trị trả về bởi [getWarningType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/#getWarningType--) và [getDescription](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iwarninginfo/#getDescription--), như trong ví dụ.