---
title: Mở bài thuyết trình trong PHP
linktitle: Mở bài thuyết trình
type: docs
weight: 20
url: /vi/php-java/open-presentation/
keywords:
- mở PowerPoint
- mở OpenDocument
- mở bài thuyết trình
- mở PPTX
- mở PPT
- mở ODP
- tải bài thuyết trình
- tải PPTX
- tải PPT
- tải ODP
- bài thuyết trình được bảo vệ
- bài thuyết trình lớn
- tài nguyên bên ngoài
- đối tượng nhị phân
- PHP
- Aspose.Slides
description: "Mở các bài thuyết trình PowerPoint (.pptx, .ppt) và OpenDocument (.odp) một cách dễ dàng với Aspose.Slides cho PHP qua Java — nhanh, đáng tin cậy, đầy đủ tính năng."
---
## **Giới thiệu**

Ngoài việc tạo bài thuyết trình PowerPoint từ đầu, Aspose.Slides còn cho phép bạn mở các bài thuyết trình đã tồn tại. Sau khi tải một bài thuyết trình, bạn có thể truy xuất thông tin về nó, chỉnh sửa nội dung slide, thêm slide mới, xóa các slide hiện có và nhiều hơn nữa.

## **Mở Bài Thuyết Trình**

Để mở một bài thuyết trình đã tồn tại, khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) và truyền đường dẫn tệp vào hàm tạo của nó.

Ví dụ PHP sau cho thấy cách mở một bài thuyết trình và lấy số slide của nó:

```php
// Khởi tạo lớp Presentation và truyền đường dẫn tệp vào hàm tạo của nó.
$presentation = new Presentation("Sample.pptx");
try {
    // In ra tổng số slide trong bài thuyết trình.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **Mở Bài Thuyết Trình Được Bảo Vệ Bằng Mật Khẩu**

Khi cần mở một bài thuyết trình được bảo vệ bằng mật khẩu, truyền mật khẩu qua phương thức [setPassword](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setPassword) của lớp [LoadOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/) để giải mã và tải nó. Đoạn mã PHP dưới đây minh họa thao tác này:

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // Thực hiện các thao tác trên bài thuyết trình đã giải mã.
} finally {
    $presentation->dispose();
}
```

## **Mở Bài Thuyết Trình Lớn**

Aspose.Slides cung cấp các tùy chọn — đặc biệt là phương thức [getBlobManagementOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) trong lớp [LoadOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/) — để giúp bạn tải các bài thuyết trình lớn.

Đoạn mã PHP dưới đây minh họa việc tải một bài thuyết trình lớn (ví dụ, 2 GB):

```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of
// the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // Bài thuyết trình lớn đã được tải và có thể sử dụng, trong khi mức tiêu thụ bộ nhớ vẫn thấp.

    // Thực hiện các thay đổi cho bài thuyết trình.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Lưu bài thuyết trình thành tệp khác. Mức tiêu thụ bộ nhớ vẫn thấp trong quá trình này.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// Đừng làm điều này! Một ngoại lệ I/O sẽ được ném vì tệp vẫn bị khóa cho đến khi đối tượng Presentation được giải phóng.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// Có thể thực hiện ở đây. Tệp nguồn không còn bị khóa bởi đối tượng Presentation.
unlink($filePath);
```

{{% alert color="info" title="Info" %}}

Để khắc phục một số hạn chế khi làm việc với stream, Aspose.Slides có thể sao chép nội dung của stream. Tải một bài thuyết trình lớn từ stream sẽ khiến bài thuyết trình bị sao chép và có thể làm chậm quá trình tải. Vì vậy, khi cần tải một bài thuyết trình lớn, chúng tôi mạnh mẽ khuyến nghị sử dụng đường dẫn tệp thay vì stream.

Khi tạo một bài thuyết trình chứa các đối tượng lớn (video, audio, hình ảnh độ phân giải cao, v.v.), bạn có thể sử dụng [BLOB management](/slides/vi/php-java/manage-blob/) để giảm tiêu thụ bộ nhớ.

{{%/alert %}}

## **Kiểm Soát Tài Nguyên Bên Ngoài**

Aspose.Slides cung cấp giao diện [IResourceLoadingCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iresourceloadingcallback/) cho phép bạn quản lý tài nguyên bên ngoài. Đoạn mã PHP dưới đây cho thấy cách sử dụng giao diện `IResourceLoadingCallback`:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // Tải một hình ảnh thay thế.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // Đặt URL thay thế.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // Bỏ qua tất cả các hình ảnh khác.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **Tải Bài Thuyết Trình Không Có Đối Tượng Nhị Phân Nhúng**

Một bài thuyết trình PowerPoint có thể chứa các loại đối tượng nhị phân nhúng sau:

- Dự án VBA (có thể truy cập qua [Presentation.getVbaProject](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getVbaProject));
- Dữ liệu OLE nhúng (có thể truy cập qua [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- Dữ liệu nhị phân điều khiển ActiveX (có thể truy cập qua [Control.getActiveXControlBinary](https://reference.aspose.com/slides/vi/php-java/aspose.slides/control/#getActiveXControlBinary)).

Bằng cách sử dụng phương thức [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects), bạn có thể tải một bài thuyết trình mà không có bất kỳ đối tượng nhị phân nhúng nào.

Phương thức này hữu ích để loại bỏ nội dung nhị phân có khả năng độc hại. Đoạn mã PHP dưới đây minh họa cách tải một bài thuyết trình mà không có bất kỳ nội dung nhị phân nhúng nào:

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // Thực hiện các thao tác trên bài thuyết trình.
} finally {
    $presentation->dispose();
}
```

## **Câu Hỏi Thường Gặp**

**Làm sao tôi biết một tệp bị hỏng và không thể mở được?**

Bạn sẽ nhận được ngoại lệ xác thực/định dạng khi tải. Các lỗi này thường đề cập đến cấu trúc ZIP không hợp lệ hoặc các bản ghi PowerPoint bị hỏng.

**Điều gì sẽ xảy ra nếu thiếu phông chữ bắt buộc khi mở?**

Tệp sẽ mở được, nhưng sau này khi [rendering/export](/slides/vi/php-java/convert-presentation/) có thể thay thế phông chữ. Hãy [cấu hình thay thế phông chữ](/slides/vi/php-java/font-substitution/) hoặc [thêm các phông chữ cần thiết](/slides/vi/php-java/custom-font/) vào môi trường chạy.

**Còn về media nhúng (video/audio) khi mở thì sao?**

Chúng sẽ được cung cấp như tài nguyên của bài thuyết trình. Nếu media được tham chiếu qua đường dẫn bên ngoài, hãy đảm bảo các đường dẫn đó có thể truy cập trong môi trường của bạn; nếu không, [rendering/export](/slides/vi/php-java/convert-presentation/) có thể bỏ qua media.