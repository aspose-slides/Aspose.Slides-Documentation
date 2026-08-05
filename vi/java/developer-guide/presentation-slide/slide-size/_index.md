---
title: Thay đổi kích thước slide của bản trình chiếu trong Java
linktitle: Kích thước slide
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
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng Java và Aspose.Slides, tối ưu hóa bản trình chiếu cho mọi loại màn hình mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bản trình chiếu PowerPoint, quan trọng cả trong việc in ấn và hiển thị trên màn hình.

Các kích thước và tỷ lệ slide phổ biến:

- **Standard (4:3 Aspect Ratio)**: Thích hợp cho các màn hình và thiết bị cũ.
- **Widescreen (16:9 Aspect Ratio)**: Được khuyến nghị cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong suốt bản trình chiếu vì một kích thước và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để đạt kết quả tối ưu, hãy đặt kích thước slide ngay từ đầu quá trình tạo bản trình chiếu để tránh các vấn đề phát sinh.

{{% alert color="primary" %}} 
Mặc định, các bản trình chiếu được tạo bằng Aspose.Slides sử dụng tỷ lệ khung hình chuẩn 4:3.
{{% /alert %}}

## **Thay đổi kích thước slide trong bản trình chiếu**

Mã mẫu này cho bạn thấy cách thay đổi kích thước slide trong một bản trình chiếu bằng Java sử dụng Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xác định kích thước slide tùy chỉnh trong bản trình chiếu**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide kích thước đầy đủ từ bản trình chiếu trên bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bản trình chiếu trên một số loại màn hình nhất định, bạn có thể hưởng lợi từ việc thiết lập kích thước tùy chỉnh cho bản trình chiếu.

Mã mẫu này cho bạn thấy cách sử dụng Aspose.Slides cho Java để chỉ định kích thước slide tùy chỉnh cho một bản trình chiếu bằng Java:

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

Sau khi bạn thay đổi kích thước slide cho một bản trình chiếu, nội dung của các slide (ví dụ như hình ảnh hoặc đối tượng) có thể bị biến dạng. Mặc định, các đối tượng sẽ tự động được thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bản trình chiếu, bạn có thể chỉ định một cài đặt xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu hoặc nhu cầu của bạn, bạn có thể sử dụng bất kỳ cài đặt nào trong số này:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng cài đặt này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ tới kích thước slide nhỏ hơn và cần Aspose.Slides thu nhỏ các đối tượng trên slide để đảm bảo chúng vừa trên slide (như vậy bạn tránh mất nội dung), hãy sử dụng cài đặt này.

- `Maximize`

  Nếu bạn muốn phóng to tới kích thước slide lớn hơn và cần Aspose.Slides phóng to các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng cài đặt này.

Mã mẫu này cho bạn thấy cách sử dụng cài đặt `Maximize` khi thay đổi kích thước slide của bản trình chiếu:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Bạn có thể đặt kích thước slide tùy chỉnh bằng đơn vị khác ngoài inch (ví dụ: point hoặc milimet) không?**

Có. Aspose.Slides sử dụng đơn vị point nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang point và sử dụng các giá trị đã chuyển để xác định chiều rộng và chiều cao slide.

**Kích thước slide tùy chỉnh rất lớn sẽ ảnh hưởng đến hiệu suất và mức tiêu thụ bộ nhớ khi render không?**

Có. Kích thước slide lớn hơn (tính bằng point) kết hợp với tỷ lệ render cao hơn sẽ làm tăng mức tiêu thụ bộ nhớ và thời gian xử lý. Hãy lựa chọn kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn và sau đó hợp nhất các slide từ các bản trình chiếu có kích thước khác nhau không?**

Bạn không thể [hợp nhất các bản trình chiếu](/slides/vi/java/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bản trình chiếu để khớp với bản còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidesizescaletype/). Sau khi đồng bộ kích thước, bạn có thể hợp nhất các slide mà vẫn giữ định dạng.

**Tôi có thể tạo ảnh thu nhỏ cho các hình dạng riêng lẻ hoặc các vùng cụ thể của một slide và chúng sẽ tôn trọng kích thước slide mới không?**

Bạn có thể. Aspose.Slides có thể tạo ảnh thu nhỏ cho [toàn bộ slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) cũng như cho [các hình dạng được chọn](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getImage-int-float-float-). Các hình ảnh đầu ra phản ánh kích thước và tỷ lệ khung hình hiện tại của slide, đảm bảo khung hình và hình học nhất quán.