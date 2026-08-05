---
title: Thay đổi kích thước slide trình chiếu trong JavaScript
linktitle: Kích thước slide
type: docs
weight: 70
url: /vi/nodejs-java/slide-size/
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
- không thu phóng
- đảm bảo vừa
- tối đa hoá
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng Node.js và Aspose.Slides, tối ưu hóa bài thuyết trình cho mọi loại màn hình mà không làm giảm chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bài thuyết trình PowerPoint, rất quan trọng cho cả việc in ấn và hiển thị trên màn hình.

Các kích thước slide và tỷ lệ thường dùng:

- **Standard (Tỷ lệ 4:3)**: Lý tưởng cho các màn hình và thiết bị cũ.
- **Widescreen (Tỷ lệ 16:9)**: Được khuyên dùng cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bài thuyết trình vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để có kết quả tối ưu, hãy đặt kích thước slide ngay khi bắt đầu tạo bài thuyết trình để tránh các vấn đề phát sinh.

{{% alert color="primary" %}} 
Mặc định, các bài thuyết trình được tạo bằng Aspose.Slides sử dụng tỷ lệ 4:3 tiêu chuẩn.
{{% /alert %}}

## **Thay đổi kích thước slide trong bài thuyết trình**

Mã mẫu này cho thấy cách thay đổi kích thước slide trong một bài thuyết trình bằng JavaScript sử dụng Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xác định kích thước slide tùy chỉnh trong bài thuyết trình**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide toàn kích thước từ bài thuyết trình trên một bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bài thuyết trình trên một số loại màn hình nhất định, việc sử dụng cài đặt kích thước tùy chỉnh sẽ mang lại lợi ích cho bạn.

Mã mẫu này cho thấy cách sử dụng Aspose.Slides cho Node.js thông qua Java để chỉ định kích thước slide tùy chỉnh cho một bài thuyết trình bằng JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// Kích thước giấy A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xử lý vấn đề khi thay đổi kích thước slide trong bài thuyết trình**

Sau khi bạn thay đổi kích thước slide cho một bài thuyết trình, nội dung của các slide (hình ảnh hoặc đối tượng, chẳng hạn) có thể bị biến dạng. Mặc định, các đối tượng sẽ tự động được thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bài thuyết trình, bạn có thể chỉ định một cài đặt xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu của bạn, bạn có thể sử dụng bất kỳ cài đặt nào sau đây:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng cài đặt này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ kích thước slide và cần Aspose.Slides thu giảm các đối tượng trên slide để đảm bảo chúng đều vừa trên slide (điều này giúp tránh mất nội dung), hãy sử dụng cài đặt này.

- `Maximize`

  Nếu bạn muốn phóng to kích thước slide và cần Aspose.Slides mở rộng các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng cài đặt này.

Mã mẫu này cho thấy cách sử dụng cài đặt `Maximize` khi thay đổi kích thước slide của một bài thuyết trình:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt kích thước slide tùy chỉnh bằng đơn vị khác ngoài inch (ví dụ, point hoặc milimet) không?**

Có. Aspose.Slides sử dụng đơn vị point nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang point và sử dụng các giá trị đã chuyển đổi để xác định chiều rộng và chiều cao slide.

**Kích thước slide tùy chỉnh rất lớn có ảnh hưởng đến hiệu năng và mức tiêu thụ bộ nhớ khi rendering không?**

Có. Kích thước slide lớn hơn (theo point) kết hợp với tỷ lệ rendering cao sẽ làm tăng mức tiêu thụ bộ nhớ và thời gian xử lý. Hãy chọn kích thước slide thực tế và chỉ điều chỉnh tỷ lệ rendering khi cần để đạt chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không tiêu chuẩn rồi sau đó hợp nhất các slide từ các bài thuyết trình có kích thước khác nhau không?**

Bạn không thể [merge presentations](/slides/vi/nodejs-java/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bài thuyết trình để khớp với bài còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesizescaletype/). Sau khi đồng bộ kích thước, bạn có thể hợp nhất các slide mà vẫn giữ định dạng.

**Tôi có thể tạo ảnh thu nhỏ cho các hình dạng riêng lẻ hoặc vùng cụ thể của một slide và chúng sẽ tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể render ảnh thu nhỏ cho [entire slides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#getImage) cũng như cho [selected shapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getImage). Các hình ảnh kết quả phản ánh kích thước slide và tỷ lệ khung hình hiện tại, đảm bảo khung hình và hình học nhất quán.