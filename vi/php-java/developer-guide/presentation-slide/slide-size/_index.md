---
title: Thay đổi kích thước slide trong bản trình chiếu bằng PHP
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
- bài thuyết trình
- PHP
- Aspose.Slides
descriptions: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng PHP và Aspose.Slides, tối ưu hoá bài thuyết trình cho mọi loại màn hình mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bản PowerPoint, quan trọng cho cả việc in và hiển thị trên màn hình.  

Kích thước slide phổ biến và tỷ lệ:

- **Standard (4:3 Aspect Ratio)**: Lý tưởng cho các màn hình và thiết bị cũ.  
- **Widescreen (16:9 Aspect Ratio)**: Được khuyến nghị cho máy chiếu và màn hình hiện đại.  

Đảm bảo tính nhất quán trong toàn bộ bài thuyết trình vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho mọi slide. Để có kết quả tối ưu, hãy đặt kích thước slide ngay từ đầu quá trình tạo bài thuyết trình để tránh các phức tạp.

{{% alert color="primary" %}} 
Mặc định, các bài thuyết trình được tạo bằng Aspose.Slides sử dụng tỷ lệ khung hình chuẩn 4:3. 
{{% /alert %}}

## **Thay đổi kích thước slide trong bài thuyết trình**

This sample code shows you how to change the slide size in a presentation using Aspose.Slides:

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

## **Xác định kích thước slide tùy chỉnh trong bài thuyết trình**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn muốn in các slide kích thước đầy đủ từ bài thuyết trình trên một bố cục trang tùy chỉnh hoặc nếu bạn dự định hiển thị bài thuyết trình trên một số loại màn hình nhất định, bạn có thể hưởng lợi từ việc sử dụng thiết lập kích thước tùy chỉnh cho bài thuyết trình.

This sample code shows you how to use Aspose.Slides for PHP via Java to specify a custom slide size for a presentation :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// kích thước giấy A4

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi bạn thay đổi kích thước slide cho một bài thuyết trình, nội dung của các slide (hình ảnh hoặc đối tượng, chẳng hạn) có thể bị biến dạng. Mặc định, các đối tượng sẽ tự động được thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của một bài thuyết trình, bạn có thể chỉ định một thiết lập xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu của bạn, bạn có thể sử dụng bất kỳ thiết lập nào sau đây:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng thiết lập này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ kích thước slide và cần Aspose.Slides thu nhỏ các đối tượng trên slide để đảm bảo chúng đều vừa vào slide (điều này giúp tránh mất nội dung), hãy sử dụng thiết lập này.

- `Maximize`

  Nếu bạn muốn phóng to kích thước slide và cần Aspose.Slides phóng đại các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng thiết lập này.

This sample code shows you how to use the `Maximize` setting when changing the size of a presentation’s slide:

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

## **FAQ**

**Tôi có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác ngoài inch (ví dụ, điểm hoặc milimet) không?**

Có. Aspose.Slides sử dụng đơn vị điểm nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang điểm và sử dụng các giá trị đã chuyển đổi để xác định chiều rộng và chiều cao slide.

**Một kích thước slide tùy chỉnh rất lớn có ảnh hưởng đến hiệu năng và mức tiêu thụ bộ nhớ khi render không?**

Có. Kích thước slide lớn hơn (tính bằng điểm) kết hợp với tỷ lệ render cao hơn sẽ làm tăng mức tiêu thụ bộ nhớ và thời gian xử lý. Hãy hướng đến một kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt được chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn rồi sau đó hợp nhất các slide từ các bài thuyết trình có kích thước khác nhau không?**

Bạn không thể [hợp nhất bài thuyết trình](/slides/vi/php-java/merge-presentation/) khi chúng có kích thước slide khác nhau — đầu tiên, hãy thay đổi kích thước một bài thuyết trình để khớp với bài kia. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slidesizescaletype/). Sau khi đồng bộ kích thước, bạn có thể hợp nhất các slide mà vẫn giữ nguyên định dạng.

**Tôi có thể tạo ảnh thu nhỏ cho các hình riêng lẻ hoặc các vùng cụ thể của slide, và chúng có tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể render ảnh thu nhỏ cho [toàn bộ slide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slide/#getImage) cũng như cho [các hình đã chọn](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getImage). Các hình ảnh kết quả phản ánh kích thước slide và tỷ lệ khung hình hiện tại, đảm bảo khung hình và hình học nhất quán.