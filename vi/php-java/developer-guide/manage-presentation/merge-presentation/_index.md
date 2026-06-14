---
title: Kết hợp hiệu quả các bài thuyết trình trong PHP
linktitle: Kết hợp các bài thuyết trình
type: docs
weight: 40
url: /vi/php-java/merge-presentation/
keywords:
- gộp PowerPoint
- gộp bài thuyết trình
- gộp slide
- gộp PPT
- gộp PPTX
- gộp ODP
- kết hợp PowerPoint
- kết hợp bài thuyết trình
- kết hợp slide
- kết hợp PPT
- kết hợp PPTX
- kết hợp ODP
- PHP
- Aspose.Slides
description: "Dễ dàng gộp các bài thuyết trình PowerPoint (PPT, PPTX) và OpenDocument (ODP) với Aspose.Slides for PHP via Java, tối ưu hoá quy trình làm việc của bạn."
---
## **Tổng quan**

Aspose.Slides cho phép bạn gộp các bài thuyết trình bằng cách sao chép các slide từ một bài thuyết trình sang bài thuyết trình khác. Bài viết này giải thích cách gộp toàn bộ bài thuyết trình hoặc các slide đã chọn, sử dụng slide master hoặc bố cục cụ thể trong quá trình gộp, xử lý các bài thuyết trình có kích thước slide khác nhau, và thêm các slide đã gộp vào một phần của bài thuyết trình. Nó cũng bao gồm các lưu ý thực tiễn liên quan đến nội dung đã gộp, bao gồm ghi chú người thuyết trình, bình luận, tệp nguồn được bảo vệ bằng mật khẩu và việc sử dụng luồng.

## **Gộp Bài Thuyết Trình**

Khi bạn gộp một bài thuyết trình vào bài khác, bạn thực tế đang kết hợp các slide của chúng trong một bài thuyết trình duy nhất để có được một tệp.

{{% alert title="Info" color="info" %}}

Hầu hết các chương trình trình chiếu (PowerPoint hoặc OpenOffice) thiếu các chức năng cho phép người dùng kết hợp các bài thuyết trình theo cách này.

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/vi/php-java/), tuy nhiên, cho phép bạn gộp các bài thuyết trình theo các cách khác nhau. Bạn có thể gộp các bài thuyết trình cùng với tất cả các hình dạng, kiểu dáng, văn bản, định dạng, bình luận, hoạt ảnh, v.v. mà không phải lo lắng về việc mất chất lượng hay dữ liệu.

**Xem thêm**

[**Sao chép Slide**](/slides/vi/php-java/clone-slides/).

{{% /alert %}}

### **Những Đối Tượng Có Thể Gộp**

Với Aspose.Slides, bạn có thể gộp 

* toàn bộ các bài thuyết trình. Tất cả các slide từ các bài thuyết trình sẽ nằm trong một bài thuyết trình duy nhất
* các slide cụ thể. Các slide đã chọn sẽ nằm trong một bài thuyết trình duy nhất
* các bài thuyết trình ở cùng một định dạng (PPT sang PPT, PPTX sang PPTX, v.v.) và ở các định dạng khác nhau (PPT sang PPTX, PPTX sang ODP, v.v.) với nhau. 

{{% alert title="Note" color="warning" %}} 

Ngoài các bài thuyết trình, Aspose.Slides cho phép bạn gộp các tệp khác:

* [Ảnh](https://products.aspose.com/slides/vi/php-java/merger/image-to-image/), chẳng hạn như [JPG sang JPG](https://products.aspose.com/slides/vi/php-java/merger/jpg-to-jpg/) hoặc [PNG sang PNG](https://products.aspose.com/slides/vi/php-java/merger/png-to-png/)
* Tài liệu, chẳng hạn như [PDF sang PDF](https://products.aspose.com/slides/vi/php-java/merger/pdf-to-pdf/) hoặc [HTML sang HTML](https://products.aspose.com/slides/vi/php-java/merger/html-to-html/)
* Và hai tệp khác nhau như [hình ảnh sang PDF](https://products.aspose.com/slides/vi/php-java/merger/image-to-pdf/) hoặc [JPG sang PDF](https://products.aspose.com/slides/vi/php-java/merger/jpg-to-pdf/) hoặc [TIFF sang PDF](https://products.aspose.com/slides/vi/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Tùy Chọn Gộp**

Bạn có thể áp dụng các tùy chọn xác định xem

* mỗi slide trong bài thuyết trình đầu ra có giữ lại một kiểu dáng duy nhất
* một kiểu dáng cụ thể được sử dụng cho tất cả các slide trong bài thuyết trình đầu ra. 

Để gộp các bài thuyết trình, Aspose.Slides cung cấp các phương thức [addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) (từ lớp [SlideCollection](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/)). Có một số triển khai của các phương thức `addClone` xác định các tham số quá trình gộp bài thuyết trình. Mỗi đối tượng Presentation có một bộ sưu tập [slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getslides/), vì vậy bạn có thể gọi phương thức `addClone` từ bài thuyết trình mà bạn muốn gộp slide vào.

Phương thức `addClone` trả về một đối tượng `Slide`, là bản sao của slide nguồn. Các slide trong bài thuyết trình đầu ra chỉ là bản sao của các slide từ nguồn. Do đó, bạn có thể thực hiện các thay đổi trên các slide kết quả (ví dụ, áp dụng kiểu dáng hoặc tùy chọn định dạng hoặc bố cục) mà không lo ảnh hưởng đến các bài thuyết trình nguồn.

## **Gộp Các Bài Thuyết Trình** 

Aspose.Slides cung cấp phương thức [addClone(Slide)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) cho phép bạn kết hợp các slide trong khi các slide vẫn giữ nguyên bố cục và kiểu dáng (các tham số mặc định).

Mã PHP này cho thấy cách gộp các bài thuyết trình:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Gộp Các Bài Thuyết Trình với Slide Master**

Aspose.Slides cung cấp phương thức [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) cho phép bạn kết hợp các slide trong khi áp dụng mẫu slide master. Bằng cách này, nếu cần, bạn có thể thay đổi kiểu dáng cho các slide trong bài thuyết trình đầu ra.

Mã này minh họa hoạt động đã mô tả:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 

Bố cục slide cho slide master được xác định tự động. Khi không thể xác định được bố cục phù hợp, nếu tham số boolean `allowCloneMissingLayout` của phương thức `addClone` được đặt thành true, sẽ sử dụng bố cục của slide nguồn. Ngược lại, sẽ ném ra ngoại lệ [PptxEditException](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PptxEditException).

{{% /alert %}}

Nếu bạn muốn các slide trong bài thuyết trình đầu ra có một bố cục slide khác, hãy sử dụng phương thức [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidecollection/addclone/) thay thế khi gộp.

## **Gộp Các Slide Cụ Thể Từ Các Bài Thuyết Trình**

Gộp các slide cụ thể từ nhiều bài thuyết trình hữu ích cho việc tạo các bộ slide tùy chỉnh. Aspose.Slides for PHP via Java cho phép bạn chọn và nhập chỉ những slide bạn cần. API giữ nguyên định dạng, bố cục và thiết kế của các slide gốc.

Mã PHP sau tạo một bài thuyết trình mới, thêm các slide tiêu đề từ hai bài thuyết trình khác, và lưu kết quả vào tệp:

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **Gộp Các Bài Thuyết Trình với Bố Cục Slide**

Mã PHP này cho thấy cách kết hợp các slide từ các bài thuyết trình trong khi áp dụng bố cục slide ưa thích của bạn để có được một bài thuyết trình đầu ra duy nhất:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Gộp Các Bài Thuyết Trình với Kích Thước Slide Khác Nhau**

{{% alert title="Note" color="warning" %}} 

Bạn không thể gộp các bài thuyết trình có kích thước slide khác nhau. 

{{% /alert %}}

Để gộp 2 bài thuyết trình có kích thước slide khác nhau, bạn phải thay đổi kích thước một trong các bài thuyết trình sao cho kích thước của nó khớp với bài thuyết trình còn lại. 

Mã mẫu này minh họa hoạt động đã mô tả:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Gộp Slide vào Section của Bài Thuyết Trình**

Mã PHP này cho thấy cách gộp một slide cụ thể vào một section trong bài thuyết trình:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

Slide được thêm vào cuối phần.

## **Xem Thêm**

Aspose cung cấp một [Công Cụ Tạo Collage Trực Tuyến MIỄN PHÍ](https://products.aspose.app/slides/vi/collage). Sử dụng dịch vụ trực tuyến này, bạn có thể gộp [JPG sang JPG](https://products.aspose.app/slides/vi/collage/jpg) hoặc PNG sang PNG, tạo [lưới ảnh](https://products.aspose.app/slides/vi/collage/photo-grid), và hơn thế nữa.

Hãy khám phá [Công Cụ Gộp Trực Tuyến MIỄN PHÍ](https://products.aspose.app/slides/vi/merger). Nó cho phép bạn gộp các bài thuyết trình PowerPoint cùng định dạng (ví dụ, PPT sang PPT, PPTX sang PPTX) hoặc giữa các định dạng khác nhau (ví dụ, PPT sang PPTX, PPTX sang ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/vi/merger)

## **Câu Hỏi Thường Gặp**

**Có bất kỳ giới hạn nào về số lượng slide khi gộp các bài thuyết trình không?**

Không có giới hạn nghiêm ngặt. Aspose.Slides có thể xử lý các tệp lớn, nhưng hiệu suất phụ thuộc vào kích thước và tài nguyên hệ thống. Đối với các bài thuyết trình rất lớn, nên sử dụng JVM 64‑bit và cấp phát đủ bộ nhớ heap.

**Tôi có thể gộp các bài thuyết trình có video hoặc âm thanh nhúng không?**

Có, Aspose.Slides giữ nguyên nội dung đa phương tiện được nhúng trong các slide, nhưng bài thuyết trình cuối cùng có thể trở nên lớn đáng kể.

**Phông chữ có được giữ nguyên khi gộp các bài thuyết trình không?**

Có. Các phông chữ được sử dụng trong các bài thuyết trình nguồn sẽ được giữ lại trong tệp đầu ra, với điều kiện chúng đã được cài đặt trên hệ thống hoặc [được nhúng](/slides/vi/php-java/embedded-font/).