---
title: Thay đổi kích thước slide trong bài thuyết trình bằng JavaScript
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
- kích thước slide độc đáo
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
description: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng Node.js và Aspose.Slides, tối ưu hóa bài thuyết trình cho bất kỳ màn hình nào mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bài thuyết trình PowerPoint, rất quan trọng cho cả việc in ấn và hiển thị trên màn hình. 

Kích thước slide phổ biến và tỷ lệ:

- **Tiêu chuẩn (Tỷ lệ 4:3)**: Lý tưởng cho các màn hình và thiết bị cũ.
- **Màn hình rộng (Tỷ lệ 16:9)**: Được đề xuất cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong suốt bài thuyết trình vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để có kết quả tối ưu, hãy đặt kích thước slide ngay từ đầu quá trình tạo bài thuyết trình để tránh các vấn đề.

{{% alert color="info" title="Note" %}}
Mặc định, các bài thuyết trình được tạo bằng Aspose.Slides sử dụng tỷ lệ chuẩn 4:3.
{{% /alert %}}

Các trang ghi chú và tài liệu phát tay có kích thước riêng biệt so với các slide thông thường. Xem [Kích thước trang ghi chú](/slides/vi/nodejs-java/notes-size/) để thay đổi kích thước và hướng của chúng.

## **Thay đổi kích thước slide trong bài thuyết trình**

Đoạn mã mẫu này cho bạn thấy cách thay đổi kích thước slide trong một bài thuyết trình bằng JavaScript sử dụng Aspose.Slides:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Chỉ định kích thước slide tùy chỉnh trong bài thuyết trình**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide kích thước đầy đủ từ bài thuyết trình trên một bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bài thuyết trình trên một số loại màn hình nhất định, bạn có thể hưởng lợi từ việc sử dụng cài đặt kích thước tùy chỉnh cho bài thuyết trình.

Đoạn mã mẫu này cho bạn thấy cách sử dụng Aspose.Slides cho Node.js thông qua Java để chỉ định kích thước slide tùy chỉnh cho một bài thuyết trình trong JavaScript:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// kích thước giấy A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xử lý các vấn đề khi thay đổi kích thước slide trong bài thuyết trình**

Sau khi bạn thay đổi kích thước slide cho một bài thuyết trình, nội dung các slide (hình ảnh hoặc đối tượng, chẳng hạn) có thể bị biến dạng. Mặc định, các đối tượng sẽ tự động được thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bài thuyết trình, bạn có thể chỉ định một cài đặt xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tuỳ thuộc vào mục tiêu của bạn, bạn có thể sử dụng bất kỳ cài đặt nào trong số sau:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng cài đặt này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ lên một kích thước slide nhỏ hơn và cần Aspose.Slides thu nhỏ các đối tượng trên slide để đảm bảo chúng tất cả vừa trên slide (cách này giúp tránh mất nội dung), hãy sử dụng cài đặt này.

- `Maximize`

  Nếu bạn muốn mở rộng lên một kích thước slide lớn hơn và cần Aspose.Slides phóng to các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng cài đặt này.

Đoạn mã mẫu này cho bạn thấy cách sử dụng cài đặt `Maximize` khi thay đổi kích thước slide của một bài thuyết trình:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

**Có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác ngoài inch (ví dụ, point hoặc milimet) không?**

Có. Aspose.Slides sử dụng đơn vị point phía trong, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang point và sử dụng các giá trị đã chuyển để xác định chiều rộng và chiều cao của slide.

**Kích thước slide tùy chỉnh rất lớn sẽ ảnh hưởng đến hiệu năng và mức sử dụng bộ nhớ khi render không?**

Có. Kích thước slide lớn hơn (theo point) kết hợp với tỷ lệ render cao sẽ làm tăng mức tiêu thụ bộ nhớ và thời gian xử lý. Hãy hướng tới một kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn và sau đó ghép các slide từ các bài thuyết trình có kích thước khác nhau không?**

Bạn không thể [ghép bài thuyết trình](/slides/vi/nodejs-java/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bài thuyết trình để khớp với cái còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesizescaletype/). Sau khi đồng bộ kích thước, bạn có thể ghép các slide mà vẫn giữ nguyên định dạng.

**Tôi có thể tạo ảnh thu nhỏ cho các hình dạng riêng lẻ hoặc các khu vực cụ thể của một slide không, và chúng có tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể render ảnh thu nhỏ cho [toàn bộ slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#getImage) cũng như cho [các hình dạng đã chọn](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getImage). Các hình ảnh tạo ra phản ánh kích thước slide và tỷ lệ khung hình hiện tại, đảm bảo khung hình và hình học nhất quán.