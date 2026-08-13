---
title: Thay đổi kích thước slide của bản trình chiếu trong Java
linktitle: Kích thước slide
type: docs
weight: 70
url: /vi/java/slide-size/
keywords:
- kích thước slide
- tỷ lệ khung hình
- tiêu chuẩn
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
- không tỷ lệ
- đảm bảo vừa
- tối đa
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng Java và Aspose.Slides, tối ưu bản trình chiếu cho bất kỳ màn hình nào mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bản trình chiếu PowerPoint, rất quan trọng cho cả việc in ấn và hiển thị trên màn hình. 

Các kích thước slide phổ biến và tỷ lệ:

- **Standard (4:3 Aspect Ratio)**: Lý tưởng cho các màn hình và thiết bị cũ.
- **Widescreen (16:9 Aspect Ratio)**: Đề xuất cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bản trình chiếu vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để có kết quả tốt nhất, hãy đặt kích thước slide của bạn ngay từ đầu quá trình tạo bản trình chiếu để tránh các rắc rối.

{{% alert color="info" %}} 
Mặc định, các bản trình chiếu được tạo bằng Aspose.Slides sử dụng tỷ lệ khung hình tiêu chuẩn 4:3.
{{% /alert %}}

## **Thay đổi kích thước slide trong bản trình chiếu**

Mã mẫu này cho bạn cách thay đổi kích thước slide trong một bản trình chiếu bằng Java sử dụng Aspose.Slides:

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

## **Xác định kích thước slide tùy chỉnh trong bản trình chiếu**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide kích thước đầy đủ từ bản trình chiếu của mình trên một bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bản trình chiếu trên một số loại màn hình nhất định, việc sử dụng cài đặt kích thước tùy chỉnh cho bản trình chiếu sẽ mang lại lợi ích.

Mã mẫu này cho bạn cách sử dụng Aspose.Slides cho Java để xác định kích thước slide tùy chỉnh cho một bản trình chiếu bằng Java:

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

Sau khi bạn thay đổi kích thước slide cho một bản trình chiếu, nội dung của các slide (hình ảnh hoặc đối tượng, ví dụ) có thể bị biến dạng. Mặc định, các đối tượng sẽ tự động thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bản trình chiếu, bạn có thể chỉ định một cài đặt quyết định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu của bạn, bạn có thể sử dụng bất kỳ cài đặt nào sau đây:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng cài đặt này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ kích thước slide và cần Aspose.Slides giảm kích thước các đối tượng trên slide sao cho chúng đều vừa trên slide (điều này giúp tránh mất nội dung), hãy sử dụng cài đặt này. 

- `Maximize`

  Nếu bạn muốn phóng to kích thước slide và cần Aspose.Slides tăng kích thước các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng cài đặt này. 

Mã mẫu này cho bạn cách sử dụng cài đặt `Maximize` khi thay đổi kích thước slide của một bản trình chiếu:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

### Tôi có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác ngoài inch (ví dụ, điểm hoặc milimét) không?

Có. Aspose.Slides sử dụng đơn vị điểm nội bộ, trong đó 1 điểm bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimét hoặc centimét) sang điểm và sử dụng các giá trị đã chuyển để xác định chiều rộng và chiều cao của slide.

### Kích thước slide tùy chỉnh rất lớn có ảnh hưởng đến hiệu suất và tiêu thụ bộ nhớ khi render không?

Có. Kích thước slide lớn hơn (tính bằng điểm) cùng với tỷ lệ render cao hơn sẽ làm tăng lượng bộ nhớ tiêu thụ và thời gian xử lý. Hãy hướng tới một kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt được chất lượng đầu ra mong muốn.

### Tôi có thể định nghĩa một kích thước slide không chuẩn và sau đó hợp nhất các slide từ các bản trình chiếu có kích thước khác nhau không?

Bạn không thể [hợp nhất các bản trình chiếu](/slides/vi/java/merge-presentation/) khi chúng có kích thước slide khác nhau — đầu tiên, hãy thay đổi kích thước một bản trình chiếu để phù hợp với bản kia. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slidesizescaletype/). Sau khi đồng bộ kích thước, bạn có thể hợp nhất các slide mà vẫn giữ nguyên định dạng.

### Tôi có thể tạo thumbnail cho các hình dạng riêng lẻ hoặc các khu vực cụ thể của một slide không, và chúng có tuân theo kích thước slide mới không?

Có. Aspose.Slides có thể render thumbnail cho [toàn bộ slide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) cũng như cho [các hình dạng đã chọn](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getImage-int-float-float-). Các hình ảnh tạo ra phản ánh kích thước và tỷ lệ khung hình hiện tại của slide, đảm bảo khung hình và hình học nhất quán.