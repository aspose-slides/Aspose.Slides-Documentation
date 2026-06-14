---
title: Sao chép các slide trình chiếu trong PHP
linktitle: Sao chép Slides
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
description: "Nhanh chóng nhân bản các slide PowerPoint với Aspose.Slides cho PHP. Thực hiện các ví dụ mã rõ ràng của chúng tôi để tự động tạo PPT trong vài giây và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Sao chép (Cloning) là quá trình tạo một bản sao chính xác hoặc bản sao của một cái gì đó. Aspose.Slides for PHP via Java cũng cho phép tạo một bản sao hoặc bản sao của bất kỳ slide nào và sau đó chèn slide đã sao chép vào bản trình chiếu hiện tại hoặc bất kỳ bản trình chiếu nào khác đã mở. Quá trình sao chép slide tạo ra một slide mới có thể được các nhà phát triển chỉnh sửa mà không làm thay đổi slide gốc. Có một số cách để sao chép một slide:

- Sao chép ở cuối trong một bản trình chiếu.
- Sao chép ở vị trí khác trong bản trình chiếu.
- Sao chép ở cuối trong một bản trình chiếu khác.
- Sao chép ở vị trí khác trong một bản trình chiếu khác.
- Sao chép ở vị trí cụ thể trong một bản trình chiếu khác.

Trong Aspose.Slides for PHP via Java, (một tập hợp các đối tượng [Slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Slide)) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) cung cấp các phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone) và [insertClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#insertClone) để thực hiện các loại sao chép slide ở trên.

## **Sao chép một Slide ở Cuối của Bản trình chiếu**
Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu ở cuối các slide hiện có, hãy sử dụng phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone) theo các bước được liệt kê dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides) bằng cách tham chiếu tới bộ sưu tập slide được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
3. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides), và truyền slide cần sao chép làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone).
4. Ghi tệp bản trình chiếu đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (nằm ở vị trí đầu tiên – chỉ mục zero – của bản trình chiếu) đến cuối bản trình chiếu.

```php
  # Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Sao chép slide mong muốn tới cuối bộ sưu tập các slide trong cùng một bản trình chiếu
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Ghi bản trình chiếu đã sửa đổi vào đĩa
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Sao chép một Slide tới Vị trí Khác trong một Bản trình chiếu**
Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu nhưng ở vị trí khác, hãy sử dụng phương thức [insertClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#insertClone):

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection) bằng cách tham chiếu tới bộ sưu tập [**Slides**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides) được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
3. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#insertClone) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides), và truyền slide cần sao chép cùng với chỉ mục cho vị trí mới làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#insertClone).
4. Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (nằm ở chỉ mục zero – vị trí 1 – của bản trình chiếu) tới chỉ mục 1 – Vị trí 2 – của bản trình chiếu.

```php
  # Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Sao chép slide mong muốn tới cuối bộ sưu tập các slide trong cùng một bản trình chiếu
    $slds = $pres->getSlides();
    # Sao chép slide mong muốn tới chỉ mục đã chỉ định trong cùng một bản trình chiếu
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Ghi bản trình chiếu đã sửa đổi vào đĩa
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Sao chép một Slide ở Cuối của Bản trình chiếu Khác**
Nếu bạn cần sao chép một slide từ một bản trình chiếu và sử dụng nó trong một tệp bản trình chiếu khác, ở cuối các slide hiện có:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) chứa bản trình chiếu mà slide sẽ được sao chép từ.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) chứa bản trình chiếu đích mà slide sẽ được thêm vào.
3. Lấy đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection) bằng cách tham chiếu tới bộ sưu tập [**Slides**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides) được cung cấp bởi đối tượng Presentation của bản trình chiếu đích.
4. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides), và truyền slide từ bản trình chiếu nguồn làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone).
5. Ghi tệp bản trình chiếu đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (từ chỉ mục đầu tiên của bản trình chiếu nguồn) tới cuối bản trình chiếu đích.

```php
  # Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    $destPres = new Presentation();
    try {
      # Sao chép slide mong muốn từ bản trình chiếu nguồn tới cuối bộ sưu tập các slide trong bản trình chiếu đích
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Ghi bản trình chiếu đích vào đĩa
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Sao chép một Slide tới Vị trí Khác trong Bản trình chiếu Khác**
Nếu bạn cần sao chép một slide từ một bản trình chiếu và sử dụng nó trong một tệp bản trình chiếu khác, ở một vị trí cụ thể:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) chứa bản trình chiếu nguồn mà slide sẽ được sao chép từ.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) chứa bản trình chiếu mà slide sẽ được thêm vào.
3. Lấy lớp [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides) bằng cách tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng Presentation của bản trình chiếu đích.
4. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#insertClone) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides), và truyền slide từ bản trình chiếu nguồn cùng với vị trí mong muốn làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#insertClone).
5. Ghi tệp bản trình chiếu đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (từ chỉ mục zero của bản trình chiếu nguồn) tới chỉ mục 1 (vị trí 2) của bản trình chiếu đích.

```php
  # Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    $destPres = new Presentation();
    try {
      # Sao chép slide mong muốn từ bản trình chiếu nguồn tới cuối bộ sưu tập các slide trong bản trình chiếu đích
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Ghi bản trình chiếu đích vào đĩa
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Sao chép một Slide ở Vị trí Cụ thể trong Bản trình chiếu Khác**
Nếu bạn cần sao chép một slide có master slide từ một bản trình chiếu và sử dụng nó trong một bản trình chiếu khác, bạn phải sao chép master slide mong muốn từ bản trình chiếu nguồn sang bản trình chiếu đích trước. Sau đó bạn cần sử dụng master slide đó để sao chép slide có master. Phương thức [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) yêu cầu một master slide từ bản trình chiếu đích thay vì từ bản trình chiếu nguồn. Để sao chép slide có master, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) chứa bản trình chiếu nguồn mà slide sẽ được sao chép từ.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) chứa bản trình chiếu đích mà slide sẽ được sao chép tới.
3. Truy cập slide cần sao chép cùng với master slide.
4. Khởi tạo lớp [MasterSlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/MasterSlideCollection) bằng cách tham chiếu tới bộ sưu tập Masters được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) của bản trình chiếu đích.
5. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone) được cung cấp bởi đối tượng [MasterSlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/MasterSlideCollection), và truyền master từ PPTX nguồn cần sao chép làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone).
6. Khởi tạo lớp [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides) bằng cách thiết lập tham chiếu tới bộ sưu tập Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation) của bản trình chiếu đích.
7. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone) được cung cấp bởi đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation/#getSlides), và truyền slide từ bản trình chiếu nguồn cần sao chép cùng với master slide làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone).
8. Ghi tệp bản trình chiếu đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide có master (nằm ở chỉ mục zero của bản trình chiếu nguồn) tới cuối bản trình chiếu đích bằng cách sử dụng master từ slide nguồn.

```php
  # Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Khởi tạo lớp Presentation cho bản trình chiếu đích (nơi slide sẽ được sao chép)
    $destPres = new Presentation();
    try {
      # Khởi tạo ISlide từ bộ sưu tập các slide trong bản trình chiếu nguồn cùng với
      # Slide master
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Sao chép master slide mong muốn từ bản trình chiếu nguồn tới bộ sưu tập các master trong
      # Bản trình chiếu đích
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Sao chép master slide mong muốn từ bản trình chiếu nguồn tới bộ sưu tập các master trong
      # Bản trình chiếu đích
      $iSlide = $masters->addClone($SourceMaster);
      # Sao chép slide mong muốn từ bản trình chiếu nguồn với master đã chọn tới cuối
      # Bộ sưu tập các slide trong bản trình chiếu đích
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Lưu bản trình chiếu đích vào đĩa
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Sao chép một Slide ở Cuối của Phần Được Chỉ Định**
Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu nhưng ở một phần khác, hãy sử dụng phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection/#addClone) được cung cấp bởi lớp [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SlideCollection). Aspose.Slides for PHP via Java cho phép sao chép một slide từ phần đầu tiên và sau đó chèn slide đã sao chép vào phần thứ hai của cùng một bản trình chiếu.

Đoạn mã sau đây cho bạn thấy cách sao chép một slide và chèn slide đã sao chép vào một phần được chỉ định.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Lưu bản trình chiếu đích vào đĩa
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Có sao chép ghi chú người nói và nhận xét của người duyệt không?**

Có. Trang ghi chú và nhận xét duyệt được bao gồm trong bản sao chép. Nếu bạn không muốn chúng, [xóa chúng](/slides/vi/php-java/presentation-notes/) sau khi chèn.

**Biểu đồ và nguồn dữ liệu của chúng được xử lý như thế nào?**

Đối tượng biểu đồ, định dạng và dữ liệu nhúng được sao chép. Nếu biểu đồ được liên kết tới nguồn bên ngoài (ví dụ, một workbook nhúng OLE), liên kết đó được giữ lại dưới dạng [đối tượng OLE](/slides/vi/php-java/manage-ole/). Sau khi di chuyển giữa các tệp, hãy kiểm tra tính khả dụng của dữ liệu và hành vi làm mới.

**Tôi có thể kiểm soát vị trí chèn và các phần cho bản sao chép không?**

Có. Bạn có thể chèn bản sao chép tại một chỉ mục slide cụ thể và đặt nó vào một [phần](/slides/vi/php-java/slide-section/) đã chọn. Nếu phần đích không tồn tại, hãy tạo nó trước và sau đó di chuyển slide vào đó.