---
title: Nhân bản các slide bản trình chiếu trong PHP
linktitle: Sao chép Slide
type: docs
weight: 35
url: /vi/php-java/clone-slides/
keywords:
- sao chép slide
- sao chép slide
- lưu slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Nhanh chóng sao chép các slide PowerPoint bằng Aspose.Slides cho PHP. Thực hiện các ví dụ mã rõ ràng của chúng tôi để tự động tạo PPT trong vài giây và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Cloning là quá trình tạo một bản sao chính xác hoặc bản sao của một đối tượng. Aspose.Slides for PHP via Java cũng cho phép tạo một bản sao hoặc clone của bất kỳ slide nào và sau đó chèn slide đã clone vào bản trình bày hiện tại hoặc bất kỳ bản trình bày nào khác đang mở. Quá trình clone slide tạo ra một slide mới có thể được nhà phát triển chỉnh sửa mà không thay đổi slide gốc. Có một số cách để clone một slide:

- Clone at End within a Presentation.
- Clone at Another Position within Presentation.
- Clone at End in another Presentation.
- Clone at Another Position in another Presentation.
- Clone at a specific position in another Presentation.

Trong Aspose.Slides for PHP via Java, (một bộ sưu tập của [Slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Slide) objects) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) cung cấp các phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone) và [insertClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#insertClone) để thực hiện các kiểu clone slide ở trên

## **Clone một Slide ở Cuối Presentation**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp presentation ở cuối các slide hiện có, hãy dùng phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone) theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Lấy đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides) bằng cách tham chiếu đến bộ sưu tập slide được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides) và truyền slide cần clone làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone).
1. Ghi lại tệp presentation đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (nằm ở vị trí đầu tiên – chỉ mục zero – của presentation) đến cuối presentation.

```php
  # Tạo một thể hiện của lớp Presentation đại diện cho một tệp bản trình chiếu
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Clone slide mong muốn tới cuối bộ sưu tập slide trong cùng một bản trình chiếu
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Ghi bản trình chiếu đã chỉnh sửa ra đĩa
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Clone một Slide đến Vị trí Khác trong Presentation**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp presentation nhưng ở vị trí khác, hãy dùng phương thức [insertClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#insertClone):

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Lấy đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection) bằng cách tham chiếu tới bộ sưu tập [**Slides**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
1. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#insertClone) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides) và truyền slide cần clone cùng với chỉ mục cho vị trí mới làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#insertClone).
1. Ghi lại presentation đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (nằm ở chỉ mục zero – vị trí 1 – của presentation) tới chỉ mục 1 – Vị trí 2 – của presentation.

```php
  # Tạo một thể hiện của lớp Presentation đại diện cho một tệp bản trình chiếu
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Clone slide mong muốn tới cuối bộ sưu tập các slide trong cùng một bản trình chiếu
    $slds = $pres->getSlides();
    # Clone slide mong muốn tới chỉ mục được chỉ định trong cùng một bản trình chiếu
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Ghi bản trình chiếu đã chỉnh sửa ra đĩa
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Clone một Slide ở Cuối Presentation Khác**
Nếu bạn cần clone một slide từ một presentation và sử dụng nó trong một presentation khác, ở cuối các slide hiện có:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) chứa presentation mà slide sẽ được clone từ.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) chứa destination presentation mà slide sẽ được thêm vào.
1. Lấy đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection) bằng cách tham chiếu tới bộ sưu tập [**Slides**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides) được cung cấp bởi đối tượng Presentation của destination presentation.
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides) và truyền slide từ source presentation làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone).
1. Ghi lại tệp destination presentation đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (từ chỉ mục đầu tiên của source presentation) đến cuối destination presentation.

```php
  # Tạo một thể hiện của lớp Presentation để tải tệp bản trình chiếu nguồn
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Tạo một thể hiện của lớp Presentation cho PPTX đích (nơi slide sẽ được clone)
    $destPres = new Presentation();
    try {
      # Clone slide mong muốn từ bản trình chiếu nguồn tới cuối bộ sưu tập các slide trong bản trình chiếu đích
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Ghi bản trình chiếu đích ra đĩa
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Clone một Slide đến Vị trí Khác trong Presentation Khác**
Nếu bạn cần clone một slide từ một presentation và sử dụng nó trong một presentation khác, ở một vị trí cụ thể:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) chứa source presentation mà slide sẽ được clone từ.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) chứa presentation mà slide sẽ được thêm vào.
1. Lấy lớp [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides) bằng cách tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng Presentation của destination presentation.
1. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#insertClone) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides) và truyền slide từ source presentation cùng với vị trí mong muốn làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#insertClone).
1. Ghi lại tệp destination presentation đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide (từ chỉ mục zero của source presentation) tới chỉ mục 1 (vị trí 2) của destination presentation.

```php
  # Tạo một thể hiện của lớp Presentation để tải tệp bản trình chiếu nguồn
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Tạo một thể hiện của lớp Presentation cho PPTX đích (nơi slide sẽ được clone)
    $destPres = new Presentation();
    try {
      # Clone slide mong muốn từ bản trình chiếu nguồn tới cuối bộ sưu tập các slide trong bản trình chiếu đích
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Ghi bản trình chiếu đích ra đĩa
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Clone một Slide ở Vị trí Cụ thể trong Presentation Khác**
Nếu bạn cần clone một slide có master slide từ một presentation và sử dụng nó trong một presentation khác, trước tiên bạn phải clone master slide mong muốn từ source presentation sang destination presentation. Sau đó bạn cần sử dụng master slide đó để clone slide có master. Phương thức [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) yêu cầu một master slide từ destination presentation chứ không phải từ source presentation. Để clone slide có master, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) chứa source presentation mà slide sẽ được clone từ.
1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) chứa destination presentation mà slide sẽ được clone tới.
1. Truy cập slide cần clone cùng với master slide.
1. Khởi tạo lớp [MasterSlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/MasterSlideCollection) bằng cách tham chiếu tới bộ sưu tập Masters được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) của destination presentation.
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone) được cung cấp bởi đối tượng [MasterSlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/MasterSlideCollection) và truyền master từ source PPTX cần clone làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone).
1. Khởi tạo lớp [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides) bằng cách thiết lập tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) của destination presentation.
1. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides) và truyền slide từ source presentation cần clone và master slide làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone).
1. Ghi lại tệp destination presentation đã chỉnh sửa.

Trong ví dụ dưới đây, chúng tôi đã clone một slide có master (nằm ở chỉ mục zero của source presentation) đến cuối destination presentation bằng master từ slide nguồn.

```php
  # Tạo một thể hiện của lớp Presentation để tải tệp bản trình chiếu nguồn
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Tạo một thể hiện của lớp Presentation cho bản trình chiếu đích (nơi slide sẽ được clone)
    $destPres = new Presentation();
    try {
      # Tạo ISlide từ bộ sưu tập các slide trong bản trình chiếu nguồn cùng với
      # slide master
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clone slide master mong muốn từ bản trình chiếu nguồn vào bộ sưu tập master trong
      # bản trình chiếu đích
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Clone slide master mong muốn từ bản trình chiếu nguồn vào bộ sưu tập master trong
      # bản trình chiếu đích
      $iSlide = $masters->addClone($SourceMaster);
      # Clone slide mong muốn từ bản trình chiếu nguồn với master mong muốn tới cuối
      # bộ sưu tập các slide trong bản trình chiếu đích
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Lưu bản trình chiếu đích ra đĩa
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Clone một Slide ở Cuối Phần Được Xác Định**
Nếu bạn muốn clone một slide và sau đó sử dụng nó trong cùng một tệp presentation nhưng ở phần khác, thì hãy sử dụng phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone) được cung cấp bởi lớp [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection). Aspose.Slides for PHP via Java cho phép clone một slide từ phần đầu tiên và sau đó chèn slide đã clone vào phần thứ hai của cùng một presentation.

Đoạn mã sau cho thấy cách clone một slide và chèn slide đã clone vào một phần được chỉ định.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Lưu bản trình chiếu đích ra đĩa
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Đảm Bảo Kích Thước Slide Khớp Nhau**

Khi clone slide vào một presentation khác, hãy chắc chắn rằng presentation đích có cùng kích thước slide với nguồn. Nếu kích thước slide khác nhau, Aspose.Slides sẽ không tự động thay đổi kích thước các hình dạng đã clone — tọa độ và kích thước gốc của chúng sẽ được giữ nguyên, điều này có thể làm cho nội dung bị lệch hoặc vượt ra ngoài giới hạn slide.

Bạn có thể đặt kích thước slide của presentation đích để khớp với nguồn trước khi clone master và slide:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

Thực hiện việc này trước khi clone master và slide.

## **Câu Hỏi Thường Gặp**

**Các ghi chú người nói và bình luận của người xem có được clone không?**

Có. Trang ghi chú và các bình luận đánh giá được bao gồm trong bản clone. Nếu bạn không muốn chúng, hãy [remove them](/slides/vi/php-java/presentation-notes/) sau khi chèn.

**Biểu đồ và nguồn dữ liệu của chúng được xử lý như thế nào?**

Đối tượng biểu đồ, định dạng và dữ liệu nhúng đều được sao chép. Nếu biểu đồ được liên kết tới nguồn bên ngoài (ví dụ, một workbook được nhúng OLE), liên kết đó sẽ được giữ dưới dạng một [OLE object](/slides/vi/php-java/manage-ole/). Sau khi di chuyển giữa các tệp, hãy xác minh tính khả dụng của dữ liệu và hành vi làm mới.

**Tôi có thể kiểm soát vị trí chèn và các phần cho bản clone không?**

Có. Bạn có thể chèn bản clone vào một chỉ mục slide cụ thể và đặt nó vào một [section](/slides/vi/php-java/slide-section/) đã chọn. Nếu phần mục tiêu chưa tồn tại, hãy tạo nó trước và sau đó di chuyển slide vào đó.