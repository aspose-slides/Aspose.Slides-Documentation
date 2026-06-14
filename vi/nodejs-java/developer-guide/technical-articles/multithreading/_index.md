---
title: Đa luồng trong Aspose.Slides cho Node.js qua Java
linktitle: Đa luồng
type: docs
weight: 310
url: /vi/nodejs-java/multithreading/
keywords:
- đa luồng
- nhiều luồng
- công việc song song
- chuyển đổi slide
- slide thành hình ảnh
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Đa luồng trong Aspose.Slides cho Node.js qua Java tăng cường xử lý PowerPoint và OpenDocument. Khám phá các phương pháp tốt nhất cho quy trình làm việc bản trình chiếu hiệu quả."
---
## **Giới thiệu**

Trong khi việc làm việc song song với các bản trình chiếu là khả thi (ngoài việc phân tích/tải/sao chép) và hầu hết thời gian mọi thứ diễn ra tốt, vẫn có khả năng nhỏ bạn sẽ nhận được kết quả không đúng khi sử dụng thư viện trong nhiều luồng.

Chúng tôi mạnh mẽ khuyến nghị bạn **không** sử dụng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) duy nhất trong môi trường đa luồng vì nó có thể gây ra lỗi hoặc sự cố không thể dự đoán và khó phát hiện.

Không **an toàn** để tải, lưu và/hoặc sao chép một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) trong nhiều luồng. Các thao tác như vậy **không** được hỗ trợ. Nếu bạn cần thực hiện các tác vụ này, bạn phải thực hiện song song bằng cách sử dụng nhiều tiến trình đơn luồng — và mỗi tiến trình đó nên dùng một thể hiện bản trình chiếu riêng.

## **Chuyển đổi các slide bản trình chiếu thành hình ảnh một cách song song**

Giả sử chúng ta muốn chuyển đổi tất cả các slide từ một bản trình chiếu PowerPoint thành ảnh PNG một cách song song. Vì không an toàn khi sử dụng một thể hiện `Presentation` duy nhất trong nhiều luồng, chúng ta sẽ chia các slide thành các bản trình chiếu riêng và chuyển đổi chúng thành ảnh một cách song song, mỗi bản trình chiếu được sử dụng trong một luồng riêng. Đoạn mã mẫu dưới đây minh họa cách thực hiện.

```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // Trích xuất slide i vào một bản trình chiếu riêng.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // Đợi cho tất cả các tác vụ hoàn thành.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```

## **Câu hỏi thường gặp**

**Tôi có cần gọi thiết lập giấy phép trong mỗi luồng không?**

Không. Chỉ cần thực hiện một lần duy nhất cho mỗi tiến trình/một miền ứng dụng trước khi các luồng bắt đầu. Nếu [license setup](/slides/vi/nodejs-java/licensing/) có thể được gọi đồng thời (ví dụ, trong quá trình khởi tạo lười), hãy đồng bộ cuộc gọi này vì phương thức thiết lập giấy phép không an toàn với đa luồng.

**Tôi có thể truyền các đối tượng `Presentation` hoặc `Slide` giữa các luồng không?**

Việc truyền các đối tượng bản trình chiếu "đang hoạt động" giữa các luồng không được khuyến nghị: hãy sử dụng các thể hiện độc lập cho mỗi luồng hoặc tạo trước các bản trình chiếu/containers slide riêng cho mỗi luồng. Cách tiếp cận này phù hợp với khuyến nghị chung là không chia sẻ một thể hiện bản trình chiếu duy nhất giữa các luồng.

**Có an toàn không khi song song hóa việc xuất ra các định dạng khác nhau (PDF, HTML, hình ảnh) với điều kiện mỗi luồng có một thể hiện `Presentation` riêng?**

Có. Với các thể hiện độc lập và các đường dẫn đầu ra riêng biệt, các tác vụ này thường được thực hiện song song đúng cách; tránh sử dụng bất kỳ đối tượng bản trình chiếu chung nào và tránh chia sẻ luồng I/O.

**Tôi nên làm gì với các cài đặt phông chữ toàn cục (thư mục, thay thế) trong môi trường đa luồng?**

Khởi tạo tất cả các cài đặt phông chữ toàn cục trước khi khởi động các luồng và không thay đổi chúng trong quá trình làm việc song song. Điều này loại bỏ các tranh chấp khi truy cập các tài nguyên phông chữ chung.