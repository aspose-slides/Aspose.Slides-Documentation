---
title: Xuất trình chiếu sang XAML trong PHP
linktitle: Trình chiếu sang XAML
type: docs
weight: 30
url: /vi/php-java/export-to-xaml/
keywords:
- xuất PowerPoint
- xuất OpenDocument
- xuất trình chiếu
- chuyển đổi PowerPoint
- chuyển đổi OpenDocument
- chuyển đổi trình chiếu
- PowerPoint sang XAML
- OpenDocument sang XAML
- trình chiếu sang XAML
- PPT sang XAML
- PPTX sang XAML
- ODP sang XAML
- lưu PPT dưới dạng XAML
- lưu PPTX dưới dạng XAML
- lưu ODP dưới dạng XAML
- xuất PPT sang XAML
- xuất PPTX sang XAML
- xuất ODP sang XAML
- PHP
- Aspose.Slides
description: "Chuyển đổi các slide PowerPoint và OpenDocument sang XAML bằng Aspose.Slides cho PHP qua Java — giải pháp nhanh, không cần Office, giữ nguyên bố cục của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách xuất bản trình chiếu PowerPoint sang XAML bằng Aspose.Slides. Nó bao gồm một giới thiệu ngắn về XAML, chỉ ra cách lưu một bản trình chiếu dưới dạng XAML với các cài đặt mặc định, và trình bày cách tùy chỉnh việc xuất thông qua [XamlOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/xamloptions/), bao gồm xuất các slide được ẩn. Bài viết cũng trả lời một vài câu hỏi thường gặp liên quan đến phông chữ dự phòng, tính tương thích của ngăn xếp XAML, và hành vi xuất slide ẩn.

## **Về XAML**

XAML là một ngôn ngữ đánh dấu dựa trên XML được sử dụng để mô tả giao diện người dùng trong các khung như WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), và Xamarin.Forms.

Bạn có thể làm việc với các tệp XAML trong công cụ thiết kế trực quan hoặc viết và chỉnh sửa markup trực tiếp.

## **Xuất bản trình chiếu sang XAML với các tùy chọn mặc định**

Ví dụ PHP dưới đây cho thấy cách xuất một bản trình chiếu sang XAML với các cài đặt mặc định. Khởi tạo PHP Java Bridge và tải `aspose.slides.php` trước khi chạy các ví dụ trong bài viết này. Đặt `pres.pptx` vào thư mục làm việc của máy chủ Java Bridge, hoặc cung cấp một đường dẫn tuyệt đối có thể truy cập được bởi máy chủ đó.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

Mặc định, các slide đã xuất sẽ được lưu trong một thư mục con `pres` của thư mục làm việc hiện tại của máy chủ Java Bridge. Thư mục này được tạo tự động, và bất kỳ hình ảnh nào cần thiết cũng được lưu ở đó.

Tên thư mục đầu ra được lấy từ tên tệp nguồn mà không có phần mở rộng. Đối với `pres.pptx`, các tệp đầu ra sẽ được đặt tên là `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, và tiếp tục như vậy. Ngay cả khi bạn cung cấp một đường dẫn tuyệt đối tới bản trình chiếu đầu vào, thư mục đầu ra vẫn được tạo tương đối với thư mục làm việc hiện tại của máy chủ Java Bridge, thay vì bên cạnh tệp đầu vào.

## **Xuất bản trình chiếu sang XAML với các tùy chọn tùy chỉnh**

Sử dụng giao diện IXamlOptions để kiểm soát cách Aspose.Slides xuất một bản trình chiếu sang XAML.

Để lưu đầu ra vào vị trí tùy chỉnh, cung cấp một proxy Java triển khai IXamlOutputSaver và truyền một thể hiện của triển khai của bạn vào phương thức setOutputSaver của XamlOptions.

Để bao gồm các slide ẩn trong đầu ra XAML, gọi setExportHiddenSlides với `true`, như được minh họa trong ví dụ PHP dưới đây:

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **Ghi lại tất cả các đối tượng XAML được tạo**

Quá trình xuất XAML có thể tạo một tài liệu XAML cho mỗi slide đã xuất cộng với các hình ảnh và tài nguyên hỗ trợ riêng biệt. Gán một IXamlOutputSaver tùy chỉnh vào XamlOptions::setOutputSaver để nhận các đối tượng này thay vì sử dụng bộ lưu mặc định của hệ thống tệp. Bắt đầu xuất bằng phương thức overload Presentation::save chuyên dành cho XAML chấp nhận các tùy chọn XAML.

Hàm `java_closure` của PHP Java Bridge khai thác một đối tượng PHP dưới dạng giao diện Java. Giữ cả bộ lưu PHP và proxy của nó tồn tại cho đến khi quá trình xuất hoàn tất. Các liên kết giao diện trỏ tới API Java được proxy triển khai.

### **Hiểu vòng đời Callback**

Trình xuất sẽ gọi IXamlOutputSaver::save riêng biệt cho mỗi đối tượng được tạo:

- `path` xác định đối tượng và có thể bao gồm các thư mục tương đối. Giữ lại thông tin này vì XAML có thể tham chiếu tài nguyên bằng các đường dẫn tương đối.
- `data` chứa các byte của đối tượng. Hình ảnh và các tài nguyên nhị phân khác không được giải mã thành văn bản.
- Bộ lưu chịu trách nhiệm giữ lại hoặc lưu trữ dữ liệu trước khi trả về. Các ví dụ chuyển mỗi mảng byte Java thành một chuỗi nhị phân PHP do ứng dụng sở hữu.
- Xem việc xuất là thành công chỉ khi thao tác lưu bản trình chiếu trả về và mọi callback đã hoàn thành thành công. Không được bỏ qua các lỗi lưu trữ hoặc khởi động các ghi nền không được giám sát. Nếu việc lưu trữ diễn ra sau đó, chỉ báo cáo thành công tổng thể sau khi bước đó cũng thành công.

XamlOptions::setExportHiddenSlides cũng áp dụng cho bộ lưu tùy chỉnh. Cài đặt mặc định, `false`, loại bỏ các tài liệu XAML của slide ẩn. Truyền `true` sẽ bao gồm chúng và bất kỳ tài nguyên nào cần thiết cho việc xuất. Số lượng tài nguyên phụ thuộc vào bản trình chiếu; không giả định một callback cho mỗi slide hoặc một thứ tự callback cố định.

### **Xuất ra bộ nhớ và kiểm tra các đối tượng**

Ví dụ đầy đủ này tải `pres.pptx`, thu thập mọi đối tượng vào một mảng kết hợp PHP gồm các chuỗi nhị phân, và in ra tên, kiểu và số byte của chúng. Nó giữ nguyên các tên được cung cấp. Các tên trùng lặp sẽ đánh dấu bộ sưu tập là không hợp lệ thay vì ghi đè âm thầm một đối tượng. Ví dụ kiểm tra điều này trước khi sử dụng kết quả.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // Chỉ XAML được xử lý như văn bản UTF-8 cho việc kiểm tra tùy chọn.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

Kiểm tra phần mở rộng rất hữu ích cho việc kiểm tra; giữ lại tất cả các đối tượng, bao gồm cả các loại tài nguyên không quen thuộc. Để nguyên các byte khi lưu hoặc truyền chúng. Các chuỗi PHP có thể giữ dữ liệu nhị phân, bao gồm cả byte zero. Xem một chuỗi là văn bản UTF-8 chỉ khi kiểm tra XAML; không chuyển mã các byte hình ảnh hoặc tài nguyên.

### **Đóng gói các đối tượng đã thu thập vào tệp ZIP**

Ví dụ độc lập này thu thập quá trình xuất, xác thực các tên của nó, và ghi các byte gốc vào một tệp ZIP. Một thư mục công việc được tạo riêng biệt tách các công việc xuất đồng thời. Ví dụ này yêu cầu phần mở rộng PHP Phar có hỗ trợ ZIP. Các mục ZIP sử dụng dấu gạch chéo xuôi và giữ lại các thư mục tương đối. Các tên không an toàn hoặc các tên trùng nhau sau khi chuẩn hoá sẽ bị từ chối toàn bộ gói trước khi ghi.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

Ví dụ sử dụng PharData để ghi một tệp ZIP cục bộ trong thư mục làm việc của quá trình PHP; trình xuất bản thân nó không ghi các tệp XAML hoặc hình ảnh rời rạc. Đối với lưu trữ từ xa, thay thế giai đoạn ghi archive bằng việc tải lên các chuỗi nhị phân đã thu thập. Sử dụng một định danh export-job cộng với tên đối tượng tương đối đầy đủ làm khóa blob, hoặc lưu định danh công việc, tên tương đối và dữ liệu nhị phân trong một dòng cơ sở dữ liệu. Công bố công việc chỉ sau khi tất cả các tải lên hoàn tất hoặc giao dịch cơ sở dữ liệu đã commit. Dọn dẹp đầu ra một phần nếu việc lưu trữ thất bại.

Đối với các bản trình chiếu lớn, một bộ lưu tùy chỉnh có thể lưu trữ mỗi đối tượng trực tiếp vào bộ nhớ ứng dụng để tránh việc giữ một bản sao bổ sung của toàn bộ xuất trong bộ nhớ ứng dụng. Giữ mỗi callback đồng bộ từ quan điểm của trình xuất: chỉ trả về sau khi đích đã nhận được các byte, và cho phép các lỗi truyền tới người gọi.

### **Bảo tồn tên tài nguyên và xác minh các tham chiếu**

- Chuẩn hoá dấu phân cách đường dẫn khi đích yêu cầu, nhưng bảo tồn các thư mục tương đối. Không chỉ sử dụng basename trừ khi mọi tên được tạo ra đều biết là duy nhất và các tham chiếu tài nguyên vẫn hợp lệ.
- Áp dụng kiểm tra tên theo đặc thù của đích. Khi ghi các tệp rời rạc, từ chối các đường dẫn gốc và các đoạn traversal, giải quyết đích thành một đường dẫn tuyệt đối, và xác minh nó nằm dưới thư mục xuất dự định, bao gồm dấu phân cách thư mục trong kiểm tra chứa. Sử dụng một thư mục do ứng dụng kiểm soát mà không có liên kết tượng trưng có thể chuyển hướng ghi.
- Sử dụng một bộ lưu và không gian tên lưu trữ riêng cho mỗi công việc xuất. Phát hiện các va chạm sau khi chuẩn hoá dấu phân cách và theo quy tắc phân biệt chữ hoa chữ thường của đích.
- Trước khi công bố, phân tích mỗi tài liệu XAML dưới dạng XML và kiểm tra các tham chiếu tài nguyên dựa trên tệp, chẳng hạn thuộc tính `Source` hoặc `ImageSource` của hình ảnh. Giải quyết mỗi URI tương đối dựa trên thư mục chứa đối tượng XAML, chuẩn hoá tên lưu trữ thu được, và xác nhận rằng khóa bản đồ, mục ZIP, hoặc đối tượng lưu trữ tương ứng tồn tại. Xử lý các URI bên ngoài và các biểu thức markup XAML riêng biệt so với các tên tệp tương đối.

Ví dụ, nếu `pres/Slide_1.xaml` tham chiếu tới `images/image1.png`, tài nguyên đã lưu phải có sẵn dưới dạng `pres/images/image1.png`. Chỉ giữ `image1.png` sẽ phá vỡ mối quan hệ đó. Đối với lưu trữ đối tượng, bảo tồn cùng một cấu trúc dưới tiền tố công việc và làm cho các URL tài nguyên đó có thể truy cập được cho người tiêu dùng XAML. Mở lại ZIP đã hoàn thành để xác minh tên mục và byte tài nguyên, và tải các slide tiêu biểu trong môi trường XAML đích để xác nhận rằng các hình ảnh được giải quyết đúng.

## **Câu hỏi thường gặp**

**Làm thế nào để tôi đảm bảo phông chữ dự đoán được nếu phông chữ gốc không có trên máy?**

Gọi setDefaultRegularFont trong XamlOptions — nó được sử dụng làm phông chữ dự phòng trong quá trình xuất khi phông chữ gốc thiếu. Điều này không đảm bảo rằng XAML được tạo sẽ tham chiếu đến phông chữ dự phòng hoặc phông chữ đó có sẵn trên máy đích. Đảm bảo rằng các phông chữ mà XAML tham chiếu đều có sẵn trong môi trường nơi nó được hiển thị.

**XAML xuất ra chỉ dành cho WPF hay có thể dùng trong các ngăn xếp XAML khác không?**

Aspose.Slides xuất XAML WPF thông qua API công cộng của nó. Tính tương thích với các ngăn xếp XAML khác, như UWP và Xamarin.Forms, không được đảm bảo. Hãy kiểm thử markup đã tạo trong môi trường mục tiêu của bạn.

**Các slide ẩn có được hỗ trợ không, và làm sao để ngăn chúng được xuất mặc định?**

Mặc định, các slide ẩn không được bao gồm. Bạn có thể kiểm soát hành vi này qua setExportHiddenSlides trong XamlOptions — giữ nó tắt nếu bạn không cần xuất chúng.