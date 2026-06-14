---
title: Quản lý khung video trong bản trình bày bằng PHP
linktitle: Khung Video
type: docs
weight: 10
url: /vi/php-java/video-frame/
keywords:
- thêm video
- tạo video
- nhúng video
- trích xuất video
- lấy video
- khung video
- nguồn web
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Học cách thêm và trích xuất khung video một cách lập trình trong các slide PowerPoint và OpenDocument bằng Aspose.Slides cho PHP thông qua Java. Hướng dẫn nhanh."
---
## **Giới thiệu**

Một video được đặt hợp lý trong bản trình bày có thể làm thông điệp của bạn trở nên thuyết phục hơn và tăng mức độ tương tác với khán giả.

PowerPoint cho phép bạn thêm video vào một slide trong bản trình bày theo hai cách:

* Thêm hoặc nhúng video cục bộ (được lưu trên máy của bạn)
* Thêm video trực tuyến (từ nguồn web như YouTube).

Để cho phép bạn thêm video (đối tượng video) vào bản trình bày, Aspose.Slides cung cấp lớp [Video](https://reference.aspose.com/slides/vi/php-java/aspose.slides/video/) , lớp [VideoFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/) và các kiểu liên quan khác.

## **Tạo khung video nhúng**

Nếu tệp video bạn muốn thêm vào slide được lưu cục bộ, bạn có thể tạo một khung video để nhúng video vào bản trình bày của mình.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu của slide thông qua chỉ số của nó.
1. Thêm một đối tượng [Video](https://reference.aspose.com/slides/vi/php-java/aspose.slides/video/) và truyền đường dẫn tệp video để nhúng video vào bản trình bày.
1. Thêm một đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/) để tạo khung cho video.
1. Lưu bản trình bày đã chỉnh sửa.

Mã PHP này cho bạn thấy cách thêm video được lưu cục bộ vào bản trình bày:

```php
  # Khởi tạo lớp Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Tải video
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Lấy slide đầu tiên và thêm khung video
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Lưu bản trình bày vào đĩa
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Ngoài ra, bạn có thể thêm video bằng cách truyền trực tiếp đường dẫn tệp vào phương thức [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addvideoframe/) :

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tạo khung video với video từ nguồn web**

Microsoft [PowerPoint 2013 và mới hơn](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) hỗ trợ video YouTube trong bản trình bày. Nếu video bạn muốn sử dụng có sẵn trực tuyến (ví dụ trên YouTube), bạn có thể thêm nó vào bản trình bày qua liên kết web.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Lấy tham chiếu của slide thông qua chỉ số của nó.
1. Thêm một đối tượng [Video](https://reference.aspose.com/slides/vi/php-java/aspose.slides/video/) và truyền liên kết tới video.
1. Đặt hình thu nhỏ cho khung video.
1. Lưu bản trình bày.

Mã PHP này cho bạn thấy cách thêm video từ web vào một slide trong bản trình bày PowerPoint:

```php
  # Khởi tạo một đối tượng Presentation đại diện cho tệp trình bày
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **Quản lý phụ đề video**

Aspose.Slides cho phép bạn quản lý phụ đề đóng cho các khung video trong bản trình bày PowerPoint. Phụ đề được lưu ở định dạng WebVTT và được cung cấp thông qua phương thức [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Thêm phụ đề vào khung video**

Để thêm phụ đề vào khung video:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).
1. Thêm video vào bản trình bày.
1. Thêm một đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/) vào slide.
1. Sử dụng collection [CaptionsCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/captionscollection/) trả về bởi [getCaptionTracks](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/#getCaptionTracks) để thêm một track phụ đề WebVTT.
1. Lưu bản trình bày đã chỉnh sửa.

Mã sau cho bạn thấy cách thêm phụ đề vào khung video:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Thêm một track phụ đề mới từ tệp WebVTT.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Lớp [CaptionsCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/captionscollection/) cũng cung cấp một overload cho phép bạn thêm phụ đề từ một luồng.

**Trích xuất phụ đề từ khung video**

Để trích xuất phụ đề từ khung video:

1. Tải bản trình bày chứa video.
1. Tìm đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/) mục tiêu.
1. Duyệt qua collection [getCaptionTracks](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Lưu mỗi track phụ đề vào tệp `.vtt`.

Mã sau cho bạn thấy cách trích xuất phụ đề từ khung video:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // Lưu track phụ đề vào tệp WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Mỗi đối tượng [Captions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/captions/) cung cấp định danh phụ đề, nhãn, dữ liệu nhị phân và nội dung phụ đề dưới dạng chuỗi UTF-8.

**Xóa phụ đề khỏi khung video**

Để xóa phụ đề khỏi khung video:

1. Tải bản trình bày chứa video.
1. Lấy đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/) mục tiêu.
1. Xóa các track phụ đề khỏi collection [getCaptionTracks](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Lưu bản trình bày đã chỉnh sửa.

Mã sau cho bạn thấy cách xóa tất cả phụ đề khỏi khung video:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // loại: VideoFrame

    // Xóa tất cả phụ đề khỏi khung video.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nếu bạn chỉ cần xóa một track phụ đề, hãy sử dụng các phương thức [remove](https://reference.aspose.com/slides/vi/php-java/aspose.slides/captionscollection/#remove) hoặc [removeAt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/captionscollection/#removeAt) thay vì [clear](https://reference.aspose.com/slides/vi/php-java/aspose.slides/captionscollection/#clear).

## **Trích xuất video từ slide**

Ngoài việc thêm video vào slide, Aspose.Slides cho phép bạn trích xuất video được nhúng trong bản trình bày.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) để tải bản trình bày chứa video.
2. Duyệt qua tất cả các đối tượng [Slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/).
3. Duyệt qua tất cả các đối tượng [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) để tìm một [VideoFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/).
4. Lưu video ra đĩa.

Mã PHP này cho bạn thấy cách trích xuất video trên một slide của bản trình bày:

```php
  # Khởi tạo một đối tượng Presentation đại diện cho tệp trình bày
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Lấy phần mở rộng tệp
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **CÂU HỎI THƯỜNG GẶP**

**Tham số phát lại video nào có thể được thay đổi cho một VideoFrame?**

Bạn có thể kiểm soát [chế độ phát lại](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/setplaymode/) (tự động hoặc khi nhấn) và [lặp lại](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/setplayloopmode/). Các tùy chọn này có sẵn qua các thuộc tính của đối tượng [VideoFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/).

**Việc thêm video có ảnh hưởng đến kích thước tệp PPTX không?**

Có. Khi bạn nhúng video cục bộ, dữ liệu nhị phân được bao gồm trong tài liệu, do đó kích thước bản trình bày tăng tỷ lệ với kích thước tệp. Khi bạn thêm video trực tuyến, một liên kết và hình thu nhỏ được nhúng, vì vậy mức tăng kích thước nhỏ hơn.

**Tôi có thể thay thế video trong một VideoFrame hiện có mà không thay đổi vị trí và kích thước không?**

Có. Bạn có thể hoán đổi [nội dung video](https://reference.aspose.com/slides/vi/php-java/aspose.slides/videoframe/setembeddedvideo/) trong khung đồng thời giữ nguyên hình học của shape; đây là kịch bản phổ biến để cập nhật phương tiện trong bố cục hiện có.

**Có thể xác định loại nội dung (MIME) của video nhúng không?**

Có. Một video nhúng có một [loại nội dung](https://reference.aspose.com/slides/vi/php-java/aspose.slides/video/getcontenttype/) mà bạn có thể đọc và sử dụng, ví dụ khi lưu nó ra đĩa.