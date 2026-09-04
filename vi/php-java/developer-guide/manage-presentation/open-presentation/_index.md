---
title: Mở Bản Trình Bày trong PHP
linktitle: Mở Bản Trình Bày
type: docs
weight: 20
url: /vi/php-java/open-presentation/
keywords:
- mở PowerPoint
- mở bản trình bày
- mở PPTX
- mở PPT
- mở ODP
- tải bản trình bày
- tải PPTX
- tải PPT
- tải ODP
- bản trình bày được bảo vệ
- bản trình bày lớn
- tài nguyên bên ngoài
- đối tượng nhị phân
- PHP
- Aspose.Slides
description: "Tìm hiểu cách mở các bản trình bày PowerPoint và OpenDocument trong PHP, cung cấp mật khẩu mở, kiểm soát việc tải tài nguyên và giảm sử dụng bộ nhớ với Aspose.Slides cho PHP qua Java."
---
## **Giới thiệu**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/vi/php-java/) có thể tải các bản trình bày PowerPoint và OpenDocument từ tệp và luồng. Sau khi tải một bản trình bày, bạn có thể kiểm tra cấu trúc của nó, chỉnh sửa các slide, quản lý tài nguyên và lưu nó ở định dạng gốc hoặc định dạng hỗ trợ khác.

Hành vi tải có thể được tùy chỉnh thông qua lớp [LoadOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/). Ví dụ, bạn có thể cung cấp mật khẩu mở, giữ các đối tượng nhị phân lớn bên ngoài bộ nhớ heap của Java, kiểm soát tài nguyên ngoài, hoặc bỏ qua dữ liệu nhị phân được nhúng.

## **Mở Bản Trình Bày**

Để mở một bản trình bày hiện có, truyền đường dẫn tệp của nó vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/). Giải phóng (dispose) bản trình bày sau khi sử dụng để các tay cầm tệp, dữ liệu tạm thời và các tài nguyên khác được giải phóng kịp thời.

Ví dụ PHP sau cho thấy cách mở một bản trình bày và lấy số lượng slide của nó:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Mở Bản Trình Bày Được Bảo Vệ Bằng Mật Khẩu**

Mật khẩu mở mã hoá nội dung của bản trình bày. Để tải đầy đủ bản trình bày, truyền mật khẩu đúng vào [LoadOptions::setPassword](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setPassword) và cung cấp các tùy chọn cho hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/). Quá trình tải sẽ thất bại nếu mật khẩu bị thiếu hoặc không chính xác.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

Để biết cách phát hiện mật khẩu, xác thực và quy trình mã hoá, xem [Password-Protect Presentations](/slides/vi/php-java/password-protected-presentation/). Nếu một bản trình bày đã được mã hoá nhưng được lưu có các thuộc tính tài liệu công khai, các thuộc tính đó có thể được đọc mà không cần mật khẩu; xem [Manage Presentation Properties](/slides/vi/php-java/presentation-properties/).

## **Mở Bản Trình Bày Lớn**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) trả về các tùy chọn kiểm soát cách Aspose.Slides xử lý các đối tượng nhị phân lớn (BLOB) như hình ảnh, âm thanh và video. Bạn có thể giữ tệp nguồn bị khóa, cho phép tệp tạm thời và giới hạn lượng dữ liệu BLOB được giữ trong bộ nhớ.

Mã PHP sau minh hoạ cách tải một bản trình bày lớn (ví dụ, 2 GB):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Với [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked), tệp nguồn sẽ vẫn bị khóa cho đến khi đối tượng Presentation được giải phóng. Không được di chuyển, ghi đè hoặc xóa tệp nguồn trong khi đối tượng còn tồn tại.

Aspose.Slides có thể sao chép nội dung của một luồng đầu vào trong quá trình tải. Đối với các bản trình bày lớn, đường dẫn tệp thường hiệu quả hơn so với luồng. Xem [Manage BLOBs](/slides/vi/php-java/manage-blob/) để biết thêm các tùy chọn lưu trữ và quản lý bộ nhớ.
{{% /alert %}}

## **Kiểm Soát Tài Nguyên Bên Ngoài**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) chấp nhận một triển khai của giao diện Java [IResourceLoadingCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iresourceloadingcallback/) thông qua PHP/Java Bridge. Callback có thể cung cấp dữ liệu thay thế, chuyển hướng tài nguyên, sử dụng bộ tải mặc định, hoặc bỏ qua tài nguyên. Điều này hữu ích khi bản trình bày chứa các hình ảnh bên ngoài cần được giải quyết theo các quy tắc bảo mật hoặc lưu trữ của ứng dụng.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Tải Bản Trình Bày Không Có Đối Tượng Nhị Phân Nhúng**

Một bản trình bày có thể chứa dữ liệu nhị phân nhúng mà một ứng dụng không cần hoặc không muốn giữ lại. Các ví dụ bao gồm:

- Dự án VBA, có sẵn qua [Presentation::getVbaProject](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getVbaProject);
- dữ liệu OLE nhúng, có sẵn qua [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- dữ liệu điều khiển ActiveX, có sẵn qua [Control::getActiveXControlBinary](https://reference.aspose.com/slides/vi/php-java/aspose.slides/control/#getActiveXControlBinary).

Thiết lập [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) thành `true` để loại bỏ dữ liệu nhị phân này khi tải. Lưu bản trình bày đã tải để lưu lại kết quả đã được làm sạch.

Tùy chọn này giảm thiểu nguy cơ tiếp xúc với các payload nhúng không mong muốn, nhưng nó không phải là một hệ thống phát hiện phần mềm độc hại hoặc làm sạch nội dung hoàn chỉnh.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Câu Hỏi Thường Gặp**

**Làm thế nào tôi biết một tệp bị hỏng và không thể mở được?**

Aspose.Slides ném ra một ngoại lệ phân tích hoặc định dạng trong quá trình tải. Xử lý lỗi này riêng biệt so với lỗi mật khẩu không đúng để ứng dụng có thể báo cáo nguyên nhân một cách chính xác.

**Điều gì xảy ra nếu các phông chữ cần thiết bị thiếu?**

Bản trình bày vẫn có thể được tải, nhưng việc hiển thị và xuất có thể thay thế phông chữ. Bạn có thể [configure font substitution](/slides/vi/php-java/font-substitution/) hoặc [provide custom fonts](/slides/vi/php-java/custom-font/) để làm cho đầu ra dự đoán được hơn.

**Việc tải một bản trình bày có đồng thời tải các phương tiện nhúng không?**

Âm thanh và video nhúng trở nên khả dụng thông qua mô hình đối tượng của bản trình bày. Các tài nguyên bên ngoài được giải quyết theo hành vi tải tài nguyên đã cấu hình và có thể không khả dụng nếu không thể truy cập vị trí của chúng.