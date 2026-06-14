---
title: Thay đổi kích thước slide của bài thuyết trình bằng JavaScript
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
descriptions: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng Node.js và Aspose.Slides, tối ưu hóa bài thuyết trình cho mọi loại màn hình mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bài thuyết trình PowerPoint, rất quan trọng đối với cả việc in ấn và hiển thị trên màn hình.

Các kích thước và tỷ lệ slide phổ biến:

- **Tiêu chuẩn (Tỷ lệ 4:3)**: Lý tưởng cho các màn hình và thiết bị cũ.  
- **Màn hình rộng (Tỷ lệ 16:9)**: Được khuyến nghị cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bài thuyết trình vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để có kết quả tối ưu, hãy đặt kích thước slide ngay ở đầu quá trình tạo bài thuyết trình để tránh các vấn đề sau này.

{{% alert color="primary" %}} 
Mặc định, các bài thuyết trình được tạo bằng Aspose.Slides sử dụng tỷ lệ chuẩn 4:3. 
{{% /alert %}}

## **Thay đổi kích thước slide trong bài thuyết trình**

This sample code shows you how to change the slide size in a presentation in JavaScript using Aspose.Slides:

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

Nếu bạn thấy các kích thước slide phổ biến (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn muốn in các slide ở kích thước thực tế từ bài thuyết trình trên một bố cục trang tùy chỉnh hoặc nếu bạn dự định hiển thị bài thuyết trình trên một số loại màn hình nhất định, việc sử dụng cài đặt kích thước tùy chỉnh cho bài thuyết trình sẽ mang lại lợi ích.

This sample code shows you how to use Aspose.Slides for Node.js via Java to specify a custom slide size for a presentation in JavaScript:

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

## **Xử lý các vấn đề khi thay đổi kích thước slide trong bài thuyết trình**

Sau khi bạn thay đổi kích thước slide cho một bài thuyết trình, nội dung các slide (hình ảnh hoặc đối tượng, ví dụ) có thể bị biến dạng. Mặc định, các đối tượng sẽ tự động được thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bài thuyết trình, bạn có thể chỉ định một cài đặt quyết định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu của bạn, bạn có thể sử dụng bất kỳ cài đặt nào sau đây:

- `DoNotScale`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng cài đặt này.

- `EnsureFit`

  Nếu bạn muốn thu nhỏ kích thước slide và cần Aspose.Slides giảm kích thước các đối tượng trên slide để đảm bảo chúng đều vừa vào slide (như vậy, bạn tránh mất nội dung), hãy sử dụng cài đặt này. 

- `Maximize`

  Nếu bạn muốn phóng to kích thước slide và cần Aspose.Slides tăng kích thước các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng cài đặt này. 

This sample code shows you how to use the `Maximize` setting when changing the size of a presentation’s slide:

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

**Tôi có thể đặt kích thước slide tùy chỉnh bằng đơn vị khác ngoài inch (ví dụ, điểm hoặc milimét) không?**

Có. Aspose.Slides sử dụng điểm nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimét hoặc centimet) sang điểm và sử dụng các giá trị đã chuyển đổi để xác định chiều rộng và chiều cao slide.

**Kích thước slide tùy chỉnh rất lớn sẽ ảnh hưởng đến hiệu năng và bộ nhớ khi render không?**

Có. Kích thước slide lớn hơn (tính bằng điểm) kết hợp với tỷ lệ render cao sẽ làm tăng tiêu thụ bộ nhớ và thời gian xử lý. Hãy chọn kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi thực sự cần để đạt chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn và sau đó hợp nhất các slide từ các bài thuyết trình có kích thước khác nhau không?**

Bạn không thể [hợp nhất các bài thuyết trình](/slides/vi/nodejs-java/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bài thuyết trình để khớp với bài còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slidesizescaletype/). Sau khi điều chỉnh kích thước, bạn có thể hợp nhất các slide mà vẫn giữ nguyên định dạng.

**Tôi có thể tạo thumbnail cho các hình dạng riêng lẻ hoặc các vùng cụ thể của một slide, và chúng có tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể tạo thumbnail cho [toàn bộ slide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slide/#getImage) cũng như cho [các hình dạng đã chọn](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getImage). Các hình ảnh kết quả phản ánh kích thước và tỷ lệ hiện tại của slide, đảm bảo khung và hình học nhất quán.