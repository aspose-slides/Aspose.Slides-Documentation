---
title: Thay đổi kích thước slide trong bản trình bày bằng PHP
linktitle: Kích thước slide
type: docs
weight: 70
url: /vi/php-java/slide-size/
keywords:
- kích thước slide
- tỷ lệ khung hình
- chuẩn
- màn hình rộng
- 4:3
- 16:9
- đặt kích thước slide
- thay đổi kích thước slide
- kích thước slide tùy chỉnh
- kích thước slide đặc biệt
- kích thước slide duy nhất
- slide kích thước đầy đủ
- loại màn hình
- không thu phóng
- đảm bảo vừa
- tối đa hoá
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng PHP và Aspose.Slides, tối ưu hóa bản trình bày cho bất kỳ màn hình nào mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bản trình bày PowerPoint, quan trọng cho cả việc in ấn và hiển thị trên màn hình. 

Các kích thước slide phổ biến và tỷ lệ:

- **Tiêu chuẩn (Tỷ lệ 4:3)**: Thích hợp cho các màn hình và thiết bị cũ.
- **Màn hình rộng (Tỷ lệ 16:9)**: Được khuyến nghị cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bản trình bày vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để có kết quả tối ưu, hãy đặt kích thước slide ngay từ đầu quá trình tạo bản trình bày để tránh các vấn đề phát sinh.

{{% alert color="info" title="Note" %}}
Mặc định, các bản trình bày được tạo bằng Aspose.Slides sử dụng tỷ lệ chuẩn 4:3.
{{% /alert %}}

Các trang Ghi chú và tài liệu phát tay có kích thước riêng so với các slide thường. Xem [Notes Page Size](/slides/vi/php-java/notes-size/) để thay đổi kích thước và hướng của chúng.

## **Thay đổi kích thước slide trong bản trình bày**

Đoạn mã mẫu này cho bạn thấy cách thay đổi kích thước slide trong một bản trình bày bằng cách sử dụng Aspose.Slides:

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Xác định kích thước slide tùy chỉnh trong bản trình bày**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide kích thước đầy đủ từ bản trình bày trên một bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bản trình bày trên một số loại màn hình nhất định, bạn có thể hưởng lợi từ việc sử dụng thiết lập kích thước tùy chỉnh cho bản trình bày.

Đoạn mã mẫu này cho bạn thấy cách sử dụng Aspose.Slides cho PHP qua Java để chỉ định kích thước slide tùy chỉnh cho một bản trình bày:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// Kích thước giấy A4

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi bạn thay đổi kích thước slide cho một bản trình bày, nội dung các slide (hình ảnh hoặc đối tượng, ví dụ) có thể bị biến dạng. Mặc định, các đối tượng sẽ được tự động thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bản trình bày, bạn có thể chỉ định một thiết lập để quyết định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục đích hoặc kết quả bạn mong muốn, bạn có thể sử dụng bất kỳ thiết lập nào trong số này:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng thiết lập này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ kích thước slide và cần Aspose.Slides thu nhỏ các đối tượng trên slide để đảm bảo chúng đều vừa trên slide (điều này giúp tránh mất nội dung), hãy sử dụng thiết lập này. 

- `Maximize`

  Nếu bạn muốn phóng to kích thước slide và cần Aspose.Slides phóng lớn các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng thiết lập này. 

Đoạn mã mẫu này cho bạn thấy cách sử dụng thiết lập `Maximize` khi thay đổi kích thước slide của một bản trình bày:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác nhau ngoài inch (ví dụ: điểm hoặc milimét) không?**

Có. Aspose.Slides sử dụng đơn vị điểm nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimét hoặc centimet) sang điểm và sử dụng các giá trị đã chuyển để xác định chiều rộng và chiều cao của slide.

**Kích thước slide tùy chỉnh rất lớn có ảnh hưởng đến hiệu năng và việc sử dụng bộ nhớ khi render không?**

Có. Kích thước slide lớn hơn (theo điểm) cộng với tỷ lệ render cao hơn sẽ dẫn đến tiêu thụ bộ nhớ tăng và thời gian xử lý lâu hơn. Hãy hướng tới một kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt được chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn và sau đó hợp nhất các slide từ các bản trình bày có kích thước khác nhau không?**

Bạn không thể [merge presentations](/slides/vi/php-java/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bản trình bày để phù hợp với bản còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidesizescaletype/). Sau khi cân chỉnh kích thước, bạn có thể hợp nhất các slide trong khi vẫn giữ nguyên định dạng.

**Tôi có thể tạo thumbnail cho các hình dạng riêng lẻ hoặc các vùng cụ thể của một slide không, và chúng có tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể tạo thumbnail cho [entire slides](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage) cũng như cho [selected shapes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getImage). Các hình ảnh tạo ra phản ánh kích thước và tỷ lệ khung hình hiện tại của slide, đảm bảo khung hình và hình học nhất quán.