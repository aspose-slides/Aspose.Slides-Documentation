---
title: Quản lý BLOB trong bài thuyết trình bằng PHP để tối ưu sử dụng bộ nhớ
linktitle: Quản lý BLOB
type: docs
weight: 10
url: /vi/php-java/manage-blob/
keywords:
- đối tượng lớn
- mục lớn
- tập tin lớn
- thêm BLOB
- xuất BLOB
- thêm hình ảnh dưới dạng BLOB
- giảm bộ nhớ
- tiêu thụ bộ nhớ
- bài thuyết trình lớn
- tệp tạm thời
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Quản lý dữ liệu BLOB trong Aspose.Slides cho PHP thông qua Java để tối ưu hoá các thao tác tệp PowerPoint và OpenDocument, nhằm xử lý bài thuyết trình một cách hiệu quả."
---
## **Tổng quan**

Aspose.Slides cung cấp việc xử lý dựa trên BLOB cho dữ liệu nhị phân lớn trong các bài thuyết trình nhằm giúp giảm mức tiêu thụ bộ nhớ khi làm việc với hình ảnh, âm thanh, video và tệp bài thuyết trình kích thước lớn.

Bài viết này trình bày cách sử dụng xử lý dựa trên BLOB để thêm phương tiện lớn vào một bài thuyết trình, xuất phương tiện lớn ra khỏi bài thuyết trình và tải các bài thuyết trình lớn một cách hiệu quả hơn. Nó cũng giải thích cách sử dụng tệp tạm thời trong quá trình xử lý và cách thay đổi thư mục lưu trữ chúng.

## **Về BLOB**

**BLOB** (**Binary Large Object**) thường là một mục lớn (hình ảnh, bài thuyết trình, tài liệu hoặc phương tiện) được lưu ở định dạng nhị phân.

Aspose.Slides for PHP via Java cho phép bạn sử dụng BLOB cho các đối tượng theo cách giảm tiêu thụ bộ nhớ khi có các tệp lớn.

{{% alert title="Info" color="info" %}}
Để vượt qua một số hạn chế khi tương tác với stream, Aspose.Slides có thể sao chép nội dung của stream. Tải một bài thuyết trình lớn qua stream sẽ dẫn đến việc sao chép nội dung của bài thuyết trình và gây chậm tải. Vì vậy, khi bạn muốn tải một bài thuyết trình lớn, chúng tôi rất khuyên bạn nên sử dụng đường dẫn tệp bài thuyết trình chứ không phải stream của nó.
{{% /alert %}}

## **Sử dụng BLOB để Giảm Tiêu Thụ Bộ Nhớ**

### **Thêm Tệp Lớn qua BLOB vào Bài Thuyết Trình**

[Aspose.Slides](/slides/vi/php-java/) for Java cho phép bạn thêm các tệp lớn (trong trường hợp này là tệp video lớn) thông qua quy trình sử dụng BLOB để giảm tiêu thụ bộ nhớ.

Đoạn Java này cho thấy cách thêm tệp video lớn qua quy trình BLOB vào một bài thuyết trình:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # Tạo một bản thuyết trình mới để video sẽ được thêm vào
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # Hãy thêm video vào bản thuyết trình - chúng tôi chọn hành vi KeepLocked vì chúng tôi không
      # có ý định truy cập tệp "veryLargeVideo.avi".
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # Lưu bản thuyết trình. Khi một bản thuyết trình lớn được xuất ra, mức tiêu thụ bộ nhớ
      # vẫn thấp trong suốt vòng đời của đối tượng pres
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Xuất Tệp Lớn qua BLOB từ Bài Thuyết Trình**
Aspose.Slides for PHP via Java cho phép bạn xuất các tệp lớn (trong trường hợp này là tệp âm thanh hoặc video) thông qua quy trình sử dụng BLOB từ các bài thuyết trình. Ví dụ, bạn có thể cần trích xuất một tệp phương tiện lớn từ một bài thuyết trình nhưng không muốn tệp đó được tải vào bộ nhớ máy tính của bạn. Bằng cách xuất tệp qua quy trình BLOB, bạn giữ mức tiêu thụ bộ nhớ ở mức thấp.

Mã này minh họa hoạt động đã mô tả:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # Khóa tệp nguồn và KHÔNG tải nó vào bộ nhớ
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # tạo đối tượng Presentation, khóa tệp "hugePresentationWithAudiosAndVideos.pptx" file.
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # Hãy lưu mỗi video vào một tệp. Để ngăn ngừa việc sử dụng bộ nhớ cao, chúng ta cần một bộ đệm sẽ được sử dụng
    # để chuyển dữ liệu từ luồng video của bản thuyết trình sang một luồng cho tệp video mới được tạo.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # Duyệt qua các video
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # Mở luồng video của bản thuyết trình. Xin lưu ý rằng chúng tôi cố ý tránh truy cập các thuộc tính
      # như video.BinaryData - vì thuộc tính này trả về một mảng byte chứa toàn bộ video, vì vậy
      # làm cho các byte được tải vào bộ nhớ. Chúng tôi sử dụng video.GetStream, nó sẽ trả về Stream - và KHÔNG
      # yêu cầu chúng ta tải toàn bộ video vào bộ nhớ.
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # Tiêu thụ bộ nhớ sẽ vẫn thấp bất kể kích thước của video hay bản thuyết trình.
    }
    # Nếu cần, bạn có thể áp dụng các bước tương tự cho các tệp âm thanh.
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **Thêm Hình Ảnh dưới dạng BLOB vào Bài Thuyết Trình**
Với các phương thức từ lớp [ImageCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagecollection/), bạn có thể thêm một hình ảnh lớn dưới dạng stream để nó được xử lý như một BLOB.

Đoạn PHP này cho thấy cách thêm một hình ảnh lớn qua quy trình BLOB:

```php
  $pathToLargeImage = "large_image.jpg";
  # tạo một bản thuyết trình mới để hình ảnh sẽ được thêm vào.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # Hãy thêm hình ảnh vào bản thuyết trình - chúng tôi chọn hành vi KeepLocked vì chúng tôi
      # KHÔNG có ý định truy cập tệp "largeImage.png" file.
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # Lưu bản thuyết trình. Khi một bản thuyết trình lớn được xuất ra, mức tiêu thụ bộ nhớ
      # vẫn thấp trong suốt vòng đời của đối tượng pres
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bộ Nhớ và Các Bài Thuyết Trình Lớn**

Thông thường, để tải một bài thuyết trình lớn, máy tính cần rất nhiều bộ nhớ tạm thời. Toàn bộ nội dung của bài thuyết trình được tải vào bộ nhớ và tệp (từ đó bài thuyết trình được tải) ngừng được sử dụng.

Xem xét một bài thuyết trình PowerPoint lớn (large.pptx) chứa một tệp video 1,5 GB. Phương pháp tiêu chuẩn để tải bài thuyết trình được mô tả trong đoạn PHP này:

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Nhưng phương pháp này tiêu tốn khoảng 1,6 GB bộ nhớ tạm thời.

### **Tải Bài Thuyết Trình Lớn dưới dạng BLOB**

Thông qua quy trình sử dụng BLOB, bạn có thể tải một bài thuyết trình lớn trong khi sử dụng ít bộ nhớ. Đoạn PHP này mô tả cách triển khai nơi quy trình BLOB được dùng để tải một tệp bài thuyết trình lớn (large.pptx):

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Thay Đổi Thư Mục cho Tệp Tạm Thời**

Khi quy trình BLOB được sử dụng, máy tính của bạn tạo ra các tệp tạm thời trong thư mục mặc định cho tệp tạm thời. Nếu bạn muốn các tệp tạm thời được lưu trong một thư mục khác, bạn có thể thay đổi cài đặt lưu trữ bằng cách sử dụng `setTempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
Khi bạn sử dụng `setTempFilesRootPath`, Aspose.Slides sẽ không tự động tạo thư mục để lưu tệp tạm thời. Bạn phải tạo thư mục này theo cách thủ công.
{{% /alert %}}

### **Giải Phóng Đối Tượng Presentation để Giải Phóng Bộ Nhớ**

Khi xử lý các bài thuyết trình lớn, đảm bảo rằng thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) được giải phóng đúng cách để bộ nhớ nó chiếm được giải phóng. Gọi `dispose()` sau khi bạn hoàn thành việc sử dụng bài thuyết trình để giải phóng các tài nguyên không được quản lý.

```php
$presentation = new Presentation("large.pptx");

# ...xử lý bản thuyết trình...
$presentation->save("large.pdf", SaveFormat::Pdf);

# Giải phóng tài nguyên một cách rõ ràng.
$presentation->dispose();
```

## **Câu Hỏi Thường Gặp**

**Dữ liệu nào trong một bài thuyết trình Aspose.Slides được xem là BLOB và được kiểm soát bởi các tùy chọn BLOB?**

Các đối tượng nhị phân lớn như hình ảnh, âm thanh và video được xem là BLOB. Toàn bộ tệp bài thuyết trình cũng liên quan đến việc xử lý BLOB khi nó được tải hoặc lưu. Những đối tượng này được điều khiển bởi các chính sách BLOB cho phép bạn quản lý việc sử dụng bộ nhớ và chuyển sang tệp tạm thời khi cần.

**Tôi cấu hình quy tắc xử lý BLOB ở đâu khi tải bài thuyết trình?**

Sử dụng [LoadOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/) với [BlobManagementOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/blobmanagementoptions/). Tại đây bạn đặt giới hạn bộ nhớ trong cho BLOB, cho phép hoặc không cho phép tệp tạm thời, chọn đường dẫn gốc cho tệp tạm và chọn hành vi khóa nguồn.

**Các thiết lập BLOB có ảnh hưởng đến hiệu năng không, và làm sao cân bằng tốc độ với bộ nhớ?**

Có. Giữ BLOB trong bộ nhớ tối đa tốc độ nhưng tăng mức tiêu thụ RAM; giảm giới hạn bộ nhớ sẽ chuyển nhiều công việc sang tệp tạm thời, giảm RAM nhưng tăng I/O. Sử dụng phương thức [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/vi/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) để đạt được cân bằng phù hợp với khối lượng công việc và môi trường của bạn.

**Các tùy chọn BLOB có giúp khi mở các bài thuyết trình cực lớn (ví dụ, hàng gigabyte) không?**

Có. [BlobManagementOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/blobmanagementoptions/) được thiết kế cho các kịch bản như vậy: bật tệp tạm thời và sử dụng khóa nguồn có thể giảm đáng kể mức RAM đỉnh và ổn định quá trình xử lý cho các bộ sưu tập rất lớn.

**Tôi có thể sử dụng chính sách BLOB khi tải từ stream thay vì tệp trên đĩa không?**

Có. Các quy tắc tương tự áp dụng cho stream: thể hiện bài thuyết trình có thể sở hữu và khóa stream đầu vào (tùy thuộc vào chế độ khóa đã chọn), và tệp tạm thời sẽ được sử dụng khi cho phép, giữ mức tiêu thụ bộ nhớ dự đoán được trong quá trình xử lý.