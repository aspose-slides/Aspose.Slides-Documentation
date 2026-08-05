---
title: Thay đổi kích thước slide trong bản trình bày trên Android
linktitle: Kích thước slide
type: docs
weight: 70
url: /vi/androidjava/slide-size/
keywords:
- kích thước slide
- tỷ lệ khung hình
- chuẩn
- rộng màn hình
- 4:3
- 16:9
- đặt kích thước slide
- thay đổi kích thước slide
- kích thước slide tùy chỉnh
- kích thước slide đặc biệt
- kích thước slide độc đáo
- slide kích thước đầy đủ
- loại màn hình
- không co giãn
- đảm bảo vừa
- tối đa hoá
- PowerPoint
- OpenDocument
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng Java và Aspose.Slides cho Android, tối ưu hóa bản trình bày cho bất kỳ màn hình nào mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bản trình bày PowerPoint, quan trọng cả khi in và khi hiển thị trên màn hình. 

Các kích thước slide và tỷ lệ phổ biến:

- **Standard (4:3 Aspect Ratio)**: Lý tưởng cho các màn hình và thiết bị cũ.
- **Widescreen (16:9 Aspect Ratio)**: Được khuyến nghị cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bản trình bày vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để đạt kết quả tối ưu, hãy đặt kích thước slide của bạn ngay từ đầu quá trình tạo bản trình bày để tránh các vấn đề.

{{% alert color="primary" %}} 
Mặc định, các bản trình bày được tạo bằng Aspose.Slides sử dụng tỷ lệ 4:3 chuẩn.
{{% /alert %}}

## **Thay đổi kích thước slide trong bản trình bày**

Mã mẫu này cho bạn thấy cách thay đổi kích thước slide trong một bản trình bày bằng Java sử dụng Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Chỉ định kích thước slide tùy chỉnh trong bản trình bày**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide kích thước đầy đủ từ bản trình bày của mình trên bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bản trình bày trên một số loại màn hình nhất định, bạn có thể hưởng lợi từ việc sử dụng cài đặt kích thước tùy chỉnh cho bản trình bày. 

Mã mẫu này cho bạn thấy cách sử dụng Aspose.Slides cho Android qua Java để chỉ định kích thước slide tùy chỉnh cho một bản trình bày bằng Java:

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

Sau khi bạn thay đổi kích thước slide cho một bản trình bày, nội dung các slide (hình ảnh hoặc đối tượng, ví dụ) có thể bị biến dạng. Mặc định, các đối tượng sẽ tự động được thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bản trình bày, bạn có thể chỉ định một cài đặt quyết định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu hoặc kết quả bạn muốn đạt được, bạn có thể sử dụng bất kỳ cài đặt nào trong số này:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng cài đặt này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ kích thước slide và cần Aspose.Slides thu nhỏ các đối tượng trên slide để đảm bảo chúng đều vừa trong slide (bằng cách này, bạn tránh mất nội dung), hãy sử dụng cài đặt này. 

- `Maximize`

  Nếu bạn muốn mở rộng kích thước slide và cần Aspose.Slides phóng to các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng cài đặt này. 

Mã mẫu này cho bạn thấy cách sử dụng cài đặt `Maximize` khi thay đổi kích thước slide của một bản trình bày:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác ngoài inch (ví dụ, điểm hoặc milimet) không?**

Có. Aspose.Slides sử dụng đơn vị điểm nội bộ, trong đó 1 điểm bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang điểm và sử dụng các giá trị đã chuyển để xác định chiều rộng và chiều cao slide.

**Kích thước slide tùy chỉnh rất lớn sẽ ảnh hưởng đến hiệu năng và việc sử dụng bộ nhớ trong quá trình render không?**

Có. Kích thước slide lớn hơn (theo điểm) kết hợp với tỷ lệ render cao hơn sẽ làm tăng mức tiêu thụ bộ nhớ và thời gian xử lý. Hãy lựa chọn kích thước slide phù hợp và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn và sau đó ghép các slide từ các bản trình bày có kích thước khác nhau không?**

Bạn không thể [ghép bản trình bày](/slides/vi/androidjava/merge-presentation/) khi chúng có kích thước slide khác nhau — đầu tiên, hãy thay đổi kích thước một bản trình bày để khớp với bản khác. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slidesizescaletype/). Sau khi điều chỉnh kích thước, bạn có thể ghép các slide trong khi vẫn giữ định dạng.

**Tôi có thể tạo ảnh thu nhỏ cho các hình dạng riêng lẻ hoặc các vùng cụ thể của một slide không, và chúng sẽ tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể tạo ảnh thu nhỏ cho [toàn bộ slide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) cũng như cho [đối tượng đã chọn](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Các hình ảnh tạo ra phản ánh kích thước slide và tỷ lệ khung hình hiện tại, đảm bảo khung hình và hình học nhất quán.