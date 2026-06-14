---
title: Đa luồng trong Aspose.Slides cho Java
linktitle: Đa luồng
type: docs
weight: 310
url: /vi/java/multithreading/
keywords:
- đa luồng
- nhiều luồng
- công việc song song
- chuyển đổi slide
- slide sang hình ảnh
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Đa luồng trong Aspose.Slides cho Java nâng cao hiệu suất xử lý PowerPoint và OpenDocument. Khám phá các thực tiễn tốt nhất cho quy trình làm việc với bản trình chiếu hiệu quả."
---
## **Giới thiệu**

Mặc dù việc làm việc song song với các bản trình chiếu là khả thi (ngoại trừ việc phân tích/tải/sao chép) và hầu hết thời gian mọi thứ diễn ra tốt, nhưng vẫn có khả năng nhỏ bạn có thể nhận được kết quả không đúng khi sử dụng thư viện trong nhiều luồng.

Chúng tôi mạnh mẽ khuyến cáo bạn **không** sử dụng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) duy nhất trong môi trường đa luồng vì nó có thể gây ra các lỗi hoặc thất bại không thể dự đoán và khó phát hiện. 

Việc tải, lưu và/hoặc sao chép một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) trong nhiều luồng là **không** an toàn. Các thao tác như vậy **không** được hỗ trợ. Nếu bạn cần thực hiện những nhiệm vụ này, bạn phải thực hiện song song các thao tác bằng cách sử dụng một số tiến trình đơn luồng — và mỗi tiến trình này nên sử dụng thể hiện bản trình chiếu riêng của nó. 

## **Chuyển Đổi Các Slide Bản Trình Chiếu Sang Hình Ảnh Một Cách Song Song**

Giả sử chúng ta muốn chuyển đổi tất cả các slide từ một bản trình chiếu PowerPoint sang hình ảnh PNG một cách song song. Vì việc sử dụng một thể hiện `Presentation` duy nhất trong nhiều luồng là không an toàn, chúng ta chia các slide thành các bản trình chiếu riêng biệt và chuyển đổi các slide sang hình ảnh một cách song song, mỗi bản trình chiếu được dùng trong một luồng riêng. Ví dụ mã sau đây cho thấy cách thực hiện.

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        // Trích xuất slide i vào một bản trình chiếu riêng.
        Presentation slidePresentation = new Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        // Chuyển đổi slide thành hình ảnh trong một tác vụ riêng.
        final int slideNumber = slideIndex + 1;
        conversionTasks.add(CompletableFuture.runAsync(() -> {
            IImage image = null;
            try {
                ISlide slide = slidePresentation.getSlides().get_Item(0);

                image = slide.getImage(imageScale, imageScale);
                String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
                image.save(imageFilePath, ImageFormat.Png);
            } finally {
                if (image != null) image.dispose();
                slidePresentation.dispose();
            }
        }));
}

// Đợi cho tất cả các tác vụ hoàn thành.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **Câu hỏi thường gặp**

**Bạn có cần gọi thiết lập giấy phép trong mỗi luồng không?**

Không. Chỉ cần thực hiện một lần cho mỗi tiến trình/miền ứng dụng trước khi các luồng khởi chạy. Nếu [license setup](/slides/vi/java/licensing/) có thể được gọi đồng thời (ví dụ, trong quá trình khởi tạo lười), hãy đồng bộ lời gọi đó vì phương thức thiết lập giấy phép không an toàn cho đa luồng.

**Tôi có thể truyền các đối tượng `Presentation` hoặc `Slide` giữa các luồng không?**

Không khuyến nghị truyền các đối tượng bản trình chiếu "live" giữa các luồng: hãy sử dụng các thể hiện độc lập cho mỗi luồng hoặc tạo trước các bản trình chiếu/rổ slide riêng biệt cho mỗi luồng. Cách tiếp cận này tuân theo khuyến cáo chung là không chia sẻ một thể hiện bản trình chiếu duy nhất giữa các luồng.

**Có an toàn để song song xuất ra các định dạng khác nhau (PDF, HTML, hình ảnh) nếu mỗi luồng có riêng thể hiện `Presentation` của nó không?**

Có. Với các thể hiện độc lập và các đường dẫn xuất riêng biệt, các tác vụ này thường được thực hiện song song một cách đúng đắn; tránh bất kỳ đối tượng bản trình chiếu nào được chia sẻ và tránh chia sẻ các luồng I/O.

**Tôi nên làm gì với cài đặt phông chữ toàn cục (thư mục, thay thế) trong đa luồng?**

Khởi tạo tất cả các [font settings](/slides/vi/java/powerpoint-fonts/) toàn cục trước khi khởi chạy các luồng và không thay đổi chúng trong quá trình làm việc song song. Điều này loại bỏ các cuộc tranh chấp khi truy cập tài nguyên phông chữ chia sẻ.