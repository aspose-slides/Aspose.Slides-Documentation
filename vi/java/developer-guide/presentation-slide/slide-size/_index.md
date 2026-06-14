---
title: Thay đổi kích thước slide trong bài thuyết trình Java
linktitle: Kích thước Slide
type: docs
weight: 70
url: /vi/java/slide-size/
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
- kích thước slide độc đáo
- slide kích thước đầy đủ
- loại màn hình
- không thu phóng
- đảm bảo vừa
- tối đa hoá
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
descriptions: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng Java và Aspose.Slides, tối ưu hoá bài thuyết trình cho mọi loại màn hình mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bản trình bày PowerPoint, rất quan trọng cho cả việc in ấn và hiển thị trên màn hình.

Kích thước và tỷ lệ slide phổ biến:

- **Standard (4:3 Aspect Ratio)**: Lý tưởng cho các màn hình và thiết bị cổ điển.
- **Widescreen (16:9 Aspect Ratio)**: Được khuyên dùng cho các máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bài thuyết trình vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để đạt kết quả tối ưu, hãy đặt kích thước slide ngay từ đầu quá trình tạo bài thuyết trình để tránh các vấn đề phát sinh.

{{% alert color="primary" %}} 
Mặc định, các bài thuyết trình được tạo bằng Aspose.Slides sử dụng tỷ lệ 4:3 tiêu chuẩn.
{{% /alert %}}

## **Thay đổi kích thước slide trong bài thuyết trình**

Mẫu mã sau đây cho bạn thấy cách thay đổi kích thước slide trong một bài thuyết trình bằng Java sử dụng Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xác định kích thước slide tùy chỉnh trong bài thuyết trình**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide ở kích thước đầy đủ từ bài thuyết trình trên một bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bài thuyết trình trên một số loại màn hình nhất định, việc sử dụng cài đặt kích thước tùy chỉnh cho bài thuyết trình sẽ mang lại lợi ích.

Mẫu mã dưới đây cho bạn thấy cách sử dụng Aspose.Slides for Java để chỉ định kích thước slide tùy chỉnh cho một bài thuyết trình bằng Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // kích thước giấy A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi bạn thay đổi kích thước slide cho một bài thuyết trình, nội dung của các slide (hình ảnh hoặc đối tượng, ví dụ) có thể bị biến dạng. Mặc định, các đối tượng sẽ tự động được điều chỉnh kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của một bài thuyết trình, bạn có thể chỉ định một cài đặt xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu bạn muốn đạt được, bạn có thể sử dụng bất kỳ cài đặt nào sau đây:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng cài đặt này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ kích thước slide và cần Aspose.Slides thu nhỏ các đối tượng trên slide để chúng đều vừa vào slide (điều này giúp tránh mất nội dung), hãy sử dụng cài đặt này.

- `Maximize`

  Nếu bạn muốn phóng to kích thước slide và cần Aspose.Slides phóng đại các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng cài đặt này.

Mẫu mã dưới đây cho bạn thấy cách sử dụng cài đặt `Maximize` khi thay đổi kích thước slide của một bài thuyết trình:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Tôi có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác ngoài inch (ví dụ, điểm hoặc milimet)?**

Có. Aspose.Slides sử dụng đơn vị điểm nội bộ, trong đó 1 điểm bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang điểm và sử dụng các giá trị đã chuyển đổi để xác định chiều rộng và chiều cao slide.

**Kích thước slide tùy chỉnh rất lớn có ảnh hưởng đến hiệu năng và mức tiêu thụ bộ nhớ khi render không?**

Có. Kích thước slide lớn hơn (theo điểm) kết hợp với tỷ lệ render cao sẽ làm tăng mức tiêu thụ bộ nhớ và thời gian xử lý. Hãy lựa chọn kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi thực sự cần để đạt chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn và sau đó hợp nhất các slide từ các bài thuyết trình có kích thước khác nhau không?**

Bạn không thể [hợp nhất các bài thuyết trình](/slides/vi/java/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước của một bài thuyết trình sao cho khớp với bài còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidesizescaletype/). Sau khi đồng bộ kích thước, bạn có thể hợp nhất các slide mà vẫn bảo toàn định dạng.

**Tôi có thể tạo ảnh thu nhỏ cho các hình dạng riêng lẻ hoặc các vùng cụ thể của một slide, và chúng có tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể render ảnh thu nhỏ cho [toàn bộ slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) cũng như cho [các hình dạng đã chọn](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getImage-int-float-float-). Các hình ảnh tạo ra sẽ phản ánh kích thước slide và tỷ lệ khung hình hiện tại, đảm bảo khung hình và hình học nhất quán.