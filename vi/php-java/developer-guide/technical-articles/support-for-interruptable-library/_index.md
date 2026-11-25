---
title: Ngắt các hoạt động trình chiếu kéo dài trong PHP
linktitle: Ngắt các hoạt động trình chiếu
type: docs
weight: 120
url: /vi/php-java/support-for-interruptable-library/
keywords:
- token gián đoạn
- hủy
- thời gian chờ chuyển đổi
- xuất slide
- PowerPoint
- PHP
- Aspose.Slides
description: "Tìm hiểu cách hủy quá trình chuyển đổi trình chiếu bằng bộ hẹn giờ và trả về các slide đã xuất trước khi hủy với Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Aspose.Slides for PHP qua Java có thể ngắt các hoạt động kéo dài như tải, lưu và hiển thị bài thuyết trình. Trong một vòng lặp xuất từng slide một, cùng một token cho phép ứng dụng của bạn dừng lại trước slide tiếp theo và trả về danh sách các xuất đã hoàn thành.

Cả hai ví dụ PHP đều giả định rằng khởi tạo của bạn gọi `define("JAVA_PREFER_VALUES", 1);` trước khi tải `Java.inc` của bridge, sau đó tải `aspose.slides.php`. Cài đặt này cho phép PHP bắt các ngoại lệ Java trong quá trình gọi. Các ví dụ kiểm tra nguyên nhân của ngoại lệ được bao bọc để các lỗi chuyển đổi khác có thể tới người gọi.

## **Ngắt một hoạt động Trình chiếu**

Tạo một [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), lấy token của nó bằng [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken), và truyền nó cho [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). Cung cấp các tùy chọn này khi khởi tạo [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Gọi [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) yêu cầu hủy. Một hoạt động đang chạy sẽ dừng khi nó phát hiện yêu cầu này.

### **Đặt thời gian chờ chuyển đổi**

Trong khi PHP chờ tải hoặc lưu đồng bộ qua PHP/Java Bridge, một bộ hẹn giờ Java có thể yêu cầu hủy trên một luồng riêng. Lưu helper sau dưới dạng `ConversionTimeout.java`, biên dịch nó với Aspose.Slides JAR trên classpath, và đưa lớp đã biên dịch sẵn có cho bridge dưới tên package của nó, `example.ConversionTimeout`.

```java
package example;

import com.aspose.slides.InterruptionTokenSource;
import java.util.Timer;
import java.util.TimerTask;

public class ConversionTimeout {
    public static Timer start(InterruptionTokenSource source, long milliseconds) {
        Timer timer = new Timer(true);
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                source.interrupt();
            }
        }, milliseconds);
        return timer;
    }
}
```

Với bridge và wrapper Aspose.Slides PHP đã được tải, chạy ví dụ sau với `sample.pptx` trong thư mục làm việc của tiến trình Java, hoặc dùng đường dẫn tuyệt đối có thể truy cập được bởi tiến trình đó. Giới hạn 20 giây bao gồm cả tải và xuất PDF. Nếu quá trình chuyển đổi kết thúc sớm, PHP sẽ hủy bộ hẹn giờ. Để chuyển đổi sang định dạng PowerPoint cũ hơn với giới hạn 10 giây, dùng `sample.ppt`, `SaveFormat::Ppt` và `10000` mili giây.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new InterruptionTokenSource();
$token = $source->getToken();
$options = new LoadOptions();
$options->setInterruptionToken($token);
$timer = java("example.ConversionTimeout")->start($source, 20000);
try {
    $presentation = new Presentation("sample.pptx", $options);
    try {
        $token->throwIfInterruptionRequested();
        $presentation->save("sample.pdf", SaveFormat::Pdf);
        $token->throwIfInterruptionRequested();
        echo "Conversion completed\n";
    } finally {
        $presentation->dispose();
    }
} catch (JavaException $error) {
    if (!java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
        throw $error;
    }
    echo "Conversion canceled\n";
} finally {
    $timer->cancel();
}
```

## **Dừng trước khi xử lý slide tiếp theo**

Kiểm tra [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) trước mỗi lần xuất. Phương thức overload của [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) cho các slide đã chọn nhận số slide bắt đầu từ 1. Chuyển một mảng một phần tử để ghi một PDF riêng cho mỗi slide.

Sử dụng một `sample.pptx` có ít nhất hai slide. Để minh họa việc hủy giữa các lần xuất, ví dụ yêu cầu hủy ngay sau khi ghi lại slide đầu tiên.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function exportSlides($path, $source) {
    $completed = [];
    $token = $source->getToken();
    $options = new LoadOptions();
    $options->setInterruptionToken($token);
    $presentation = new Presentation($path, $options);
    try {
        $count = java_values($presentation->getSlides()->size());
        for ($number = 1; $number <= $count; $number++) {
            if (java_values($token->isInterruptionRequested())) {
                break;
            }

            try {
                $presentation->save("slide-$number.pdf", [$number], SaveFormat::Pdf);
                $token->throwIfInterruptionRequested();
            } catch (JavaException $error) {
                if (java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
                    break;
                }
                throw $error;
            }

            $completed[] = $number;
            if ($number === 1) {
                $source->interrupt();
            }
        }
        return $completed;
    } finally {
        $presentation->dispose();
    }
}

$source = new InterruptionTokenSource();
$completed = exportSlides("sample.pptx", $source);
echo "Completed: " . json_encode($completed) . "\n";
```

Ví dụ viết `slide-1.pdf` và in `Completed: [1]`. Vòng lặp thứ hai thấy yêu cầu trước khi bắt đầu xuất nữa. Nếu việc hủy xảy ra trong quá trình lưu, danh sách chỉ chứa các xuất đã được xác nhận trước đó. Một lần lưu bị gián đoạn có thể để lại tệp không hoàn chỉnh trên đĩa.

Để truyền hủy tới người gọi, thay thế kiểm tra ở đầu vòng lặp bằng `$token->throwIfInterruptionRequested();` và loại bỏ `try`/`catch` bên trong, giữ lại việc lưu và kiểm tra phía sau nó. Với cùng đầu vào, [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) ném ngoại lệ trước slide 2 và người gọi không nhận được danh sách nào.

## **Câu hỏi thường gặp**

**Khi nào tôi nên yêu cầu hủy?**

Yêu cầu hủy khi thời hạn hết hoặc người gọi không còn cần kết quả. Yêu cầu được đưa ra sau khi một thao tác kết thúc sẽ không ảnh hưởng đến kết quả đã có.

**Làm thế nào nguồn và token khác nhau?**

Nguồn cho phép một ứng dụng yêu cầu hủy. Token cho phép Aspose.Slides và mã ứng dụng quan sát yêu cầu đó.

**Nhiều thao tác có thể chia sẻ một nguồn không?**

Có. Yêu cầu áp dụng cho tất cả các thao tác sử dụng token từ cùng một nguồn. Tạo các nguồn riêng cho các thao tác cần hủy độc lập.