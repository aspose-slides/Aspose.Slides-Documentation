---
title: Thay đổi kích thước slide trong bản trình bày bằng Java
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
- bản trình bày
- Java
- Aspose.Slides
description: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng Java và Aspose.Slides, tối ưu hóa bản trình bày cho mọi loại màn hình mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bản trình bày PowerPoint, rất quan trọng cho cả việc in ấn và hiển thị trên màn hình. 

Các kích thước slide và tỷ lệ phổ biến:

- **Standard (4:3 Aspect Ratio)**: Lý tưởng cho các màn hình và thiết bị cũ.
- **Widescreen (16:9 Aspect Ratio)**: Được khuyến nghị cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bản trình bày vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để đạt kết quả tối ưu, hãy đặt kích thước slide ngay từ đầu quá trình tạo bản trình bày để tránh những phức tạp.

{{% alert color="info" title="Note" %}}
Mặc định, các bản trình bày được tạo bằng Aspose.Slides sử dụng tỷ lệ khung hình tiêu chuẩn 4:3.
{{% /alert %}}

Các trang Ghi chú và tài liệu phát tay có kích thước riêng so với các slide thường. Xem [Notes Page Size](/slides/vi/java/notes-size/) để thay đổi kích thước và hướng của chúng.

## **Thay đổi kích thước slide trong bản trình bày**

 Đoạn mã mẫu này cho bạn cách thay đổi kích thước slide trong một bản trình bày bằng Java sử dụng Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xác định kích thước slide tùy chỉnh trong bản trình bày**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide kích thước đầy đủ từ bản trình bày trên bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bản trình bày trên một số loại màn hình nhất định, bạn có thể hưởng lợi từ việc sử dụng cài đặt kích thước tùy chỉnh cho bản trình bày. 

Đoạn mã mẫu này cho bạn cách sử dụng Aspose.Slides cho Java để chỉ định kích thước slide tùy chỉnh cho một bản trình bày bằng Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // kích thước giấy A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi bạn thay đổi kích thước slide cho một bản trình bày, nội dung của các slide (hình ảnh hoặc đối tượng, ví dụ) có thể bị biến dạng. Mặc định, các đối tượng được tự động thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bản trình bày, bạn có thể chỉ định một cài đặt xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu của bạn, bạn có thể sử dụng bất kỳ cài đặt nào sau đây:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng cài đặt này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ kích thước slide và cần Aspose.Slides giảm kích thước các đối tượng trên slide để đảm bảo chúng全部 vừa trong slide (cách này, bạn tránh mất nội dung), hãy sử dụng cài đặt này. 

- `Maximize`

  Nếu bạn muốn mở rộng kích thước slide và cần Aspose.Slides phóng to các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng cài đặt này. 

Đoạn mã mẫu này cho bạn cách sử dụng cài đặt `Maximize` khi thay đổi kích thước slide của một bản trình bày:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Tôi có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác nhau ngoài inch (ví dụ, point hoặc milimet)?**

Có. Aspose.Slides sử dụng đơn vị point nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang point và sử dụng các giá trị đã chuyển đổi để xác định chiều rộng và chiều cao của slide.

**Kích thước slide tùy chỉnh quá lớn sẽ ảnh hưởng đến hiệu suất và việc sử dụng bộ nhớ khi render không?**

Có. Kích thước slide lớn hơn (theo point) kết hợp với tỷ lệ render cao hơn sẽ dẫn đến việc tiêu tốn bộ nhớ tăng và thời gian xử lý lâu hơn. Hãy hướng tới một kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn rồi sau đó hợp nhất các slide từ các bản trình bày có kích thước khác nhau không?**

Bạn không thể [merge presentations](/slides/vi/java/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bản trình bày để khớp với bản kia. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidesizescaletype/). Sau khi căn chỉnh kích thước, bạn có thể hợp nhất các slide đồng thời giữ nguyên định dạng.

**Tôi có thể tạo thumbnail cho các shape riêng lẻ hoặc các khu vực cụ thể của slide không, và chúng có tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể render thumbnail cho [entire slides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) cũng như cho [selected shapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getImage-int-float-float-). Các hình ảnh kết quả phản ánh kích thước slide và tỷ lệ khung hình hiện tại, đảm bảo khung và hình học nhất quán.