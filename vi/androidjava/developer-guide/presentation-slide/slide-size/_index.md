---
title: Thay đổi kích thước slide của bản trình bày trên Android
linktitle: Kích thước slide
type: docs
weight: 70
url: /vi/androidjava/slide-size/
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
- Android
- Java
- Aspose.Slides
description: "Nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng Java và Aspose.Slides cho Android, tối ưu hoá bản trình bày cho mọi màn hình mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước và tỉ lệ khung hình của slide trong bài thuyết trình PowerPoint, rất quan trọng cho cả việc in ấn và hiển thị trên màn hình. 

Các kích thước và tỉ lệ slide phổ biến:

- **Standard (4:3 Aspect Ratio)**: Phù hợp cho các màn hình và thiết bị cũ.
- **Widescreen (16:9 Aspect Ratio)**: Được khuyến nghị cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bài thuyết trình vì một kích thước và tỉ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để có kết quả tối ưu, hãy đặt kích thước slide ngay từ đầu quá trình tạo bài thuyết trình để tránh các vấn đề.

{{% alert color="info" title="Note" %}}
Mặc định, các bài thuyết trình được tạo bằng Aspose.Slides sử dụng tỉ lệ chuẩn 4:3.
{{% /alert %}}

Các trang Ghi chú và tài liệu phát tay có kích thước riêng so với các slide thường. Xem [Notes Page Size](/slides/vi/androidjava/notes-size/) để thay đổi kích thước và định hướng của chúng.

## **Thay đổi kích thước slide trong bài thuyết trình**

Mã mẫu này minh họa cách thay đổi kích thước slide trong một bài thuyết trình bằng Java sử dụng Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Chỉ định kích thước slide tùy chỉnh trong bài thuyết trình**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide riêng biệt hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide kích thước đầy đủ từ bài thuyết trình trên một bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bài thuyết trình trên một số loại màn hình nhất định, việc sử dụng cài đặt kích thước tùy chỉnh cho bài thuyết trình sẽ mang lại lợi ích.

Mã mẫu này minh họa cách sử dụng Aspose.Slides cho Android qua Java để chỉ định kích thước slide tùy chỉnh cho một bài thuyết trình trong Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Kích thước giấy A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi bạn thay đổi kích thước slide cho một bài thuyết trình, nội dung các slide (hình ảnh hoặc đối tượng, chẳng hạn) có thể bị biến dạng. Mặc định, các đối tượng sẽ tự động được thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của một bài thuyết trình, bạn có thể chỉ định một cài đặt xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu của bạn, bạn có thể sử dụng bất kỳ cài đặt nào sau đây:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng cài đặt này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ kích thước slide và cần Aspose.Slides thu nhỏ các đối tượng trên slide để đảm bảo chúng đều vừa vào slide (điều này giúp tránh mất nội dung), hãy sử dụng cài đặt này.

- `Maximize`

  Nếu bạn muốn phóng to kích thước slide và cần Aspose.Slides phóng đại các đối tượng trên slide để chúng tương ứng tỷ lệ với kích thước slide mới, hãy sử dụng cài đặt này.

Mã mẫu này minh họa cách sử dụng cài đặt `Maximize` khi thay đổi kích thước slide của một bài thuyết trình:

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

**Tôi có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác ngoài inch (ví dụ, point hoặc milimet) không?**

Có. Aspose.Slides sử dụng đơn vị point nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang point và sử dụng các giá trị đã chuyển để xác định chiều rộng và chiều cao của slide.

**Kích thước slide tùy chỉnh rất lớn có ảnh hưởng đến hiệu năng và mức tiêu thụ bộ nhớ trong quá trình render không?**

Có. Kích thước slide lớn hơn (tính bằng point) kết hợp với tỉ lệ render cao hơn sẽ làm tăng mức tiêu thụ bộ nhớ và thời gian xử lý. Hãy hướng tới một kích thước slide thực tế và chỉ điều chỉnh tỉ lệ render khi cần thiết để đạt được chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn và sau đó hợp nhất các slide từ các bài thuyết trình có kích thước khác nhau không?**

Bạn không thể [merge presentations](/slides/vi/androidjava/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bài thuyết trình để khớp với bài còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidesizescaletype/). Sau khi đồng nhất kích thước, bạn có thể hợp nhất các slide mà vẫn giữ nguyên định dạng.

**Tôi có thể tạo thumbnail cho các shape riêng lẻ hoặc vùng cụ thể của slide không, và chúng có tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể tạo thumbnail cho [toàn bộ slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) cũng như cho [các shape đã chọn](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Các hình ảnh đầu ra phản ánh kích thước và tỉ lệ khung hình hiện tại của slide, đảm bảo khung và hình học nhất quán.