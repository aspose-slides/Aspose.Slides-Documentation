---
title: Đa luồng trong Aspose.Slides cho .NET
linktitle: Đa luồng
type: docs
weight: 310
url: /vi/net/multithreading/
keywords:
- đa luồng
- nhiều luồng
- công việc song song
- chuyển đổi slide
- slide sang hình ảnh
- PowerPoint
- OpenDocument
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides cho .NET đa luồng tăng tốc xử lý PowerPoint và OpenDocument. Khám phá các thực tiễn tốt nhất cho quy trình làm việc bản trình bày hiệu quả."
---
## **Giới thiệu**

Trong khi việc làm việc song song với các bản trình bày là khả thi (ngoài việc phân tích/tải/sao chép) và hầu hết thời gian mọi thứ diễn ra tốt, vẫn có một khả năng nhỏ bạn có thể nhận được kết quả không chính xác khi sử dụng thư viện trong nhiều luồng.

Chúng tôi mạnh mẽ khuyến cáo bạn **không** sử dụng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) duy nhất trong môi trường đa luồng vì nó có thể gây ra các lỗi hoặc sự cố không thể dự đoán và khó phát hiện.

Việc tải, lưu và/hoặc sao chép một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) trong nhiều luồng **không** an toàn. Các hoạt động như vậy **không** được hỗ trợ. Nếu bạn cần thực hiện các tác vụ này, bạn phải song song hoá chúng bằng cách sử dụng một số tiến trình đơn luồng—và mỗi tiến trình này nên sử dụng một thể hiện bản trình bày riêng.

## **Chuyển đổi các slide bản trình bày sang hình ảnh một cách song song**

Giả sử chúng ta muốn chuyển đổi tất cả các slide từ một bản PowerPoint sang hình ảnh PNG một cách song song. Vì việc sử dụng một thể hiện `Presentation` duy nhất trong nhiều luồng là không an toàn, chúng ta chia các slide của bản trình bày thành các bản trình bày riêng và chuyển đổi các slide sang hình ảnh song song, mỗi bản trình bày được sử dụng trong một luồng riêng. Đoạn mã ví dụ dưới đây cho thấy cách thực hiện.

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // Trích xuất slide i vào một bản trình bày riêng.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Chuyển đổi slide sang hình ảnh trong một tác vụ riêng.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```

## **Câu hỏi thường gặp**

**Tôi có cần gọi thiết lập giấy phép trong mỗi luồng không?**

Không. Chỉ cần thực hiện một lần cho mỗi tiến trình/miền ứng dụng trước khi các luồng bắt đầu. Nếu [license setup](/slides/vi/net/licensing/) có thể được gọi đồng thời (ví dụ, trong quá trình khởi tạo lười), hãy đồng bộ hóa lời gọi đó vì phương thức thiết lập giấy phép không an toàn trong đa luồng.

**Tôi có thể truyền các đối tượng `Presentation` hoặc `Slide` giữa các luồng không?**

Việc truyền các đối tượng bản trình bày "đang hoạt động" giữa các luồng không được khuyến nghị: hãy sử dụng các thể hiện độc lập cho mỗi luồng hoặc tạo trước các bản trình bày/containers slide riêng cho mỗi luồng. Cách tiếp cận này tuân theo khuyến cáo chung là không chia sẻ một thể hiện bản trình bày duy nhất giữa các luồng.

**Việc song song hoá xuất ra các định dạng khác nhau (PDF, HTML, hình ảnh) có an toàn không, với điều kiện mỗi luồng có một thể hiện `Presentation` riêng?**

Có. Với các thể hiện độc lập và các đường dẫn xuất riêng biệt, các tác vụ này thường có thể song song hoá một cách đúng đắn; tránh bất kỳ đối tượng bản trình bày chung và các luồng I/O chung nào.

**Tôi nên làm gì với cài đặt phông chữ toàn cục (thư mục, thay thế) trong đa luồng?**

Khởi tạo tất cả cài đặt phông chữ toàn cục trước khi khởi động các luồng và không thay đổi chúng trong quá trình làm việc song song. Điều này loại bỏ các cuộc tranh chấp khi truy cập vào tài nguyên phông chữ chung.