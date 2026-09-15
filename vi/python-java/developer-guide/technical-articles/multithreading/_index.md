---
title: Đa luồng trong Aspose.Slides cho Python thông qua Java
linktitle: Đa luồng
type: docs
weight: 310
url: /vi/python-java/multithreading/
keywords:
- đa luồng
- nhiều luồng
- công việc song song
- chuyển đổi slide
- slide sang hình ảnh
- PowerPoint
- OpenDocument
- bài trình chiếu
- Python
- Java
- Aspose.Slides
description: "Đa luồng trong Aspose.Slides cho Python thông qua Java tăng cường việc xử lý PowerPoint và OpenDocument. Khám phá các thực tiễn tốt nhất cho quy trình làm việc bài trình chiếu hiệu quả."
---
## **Giới thiệu**

Mặc dù việc làm việc song song với các bài trình chiếu là khả thi (ngoại trừ việc phân tích, tải và sao chép) và thường hoạt động tốt, nhưng vẫn có một khả năng nhỏ xảy ra kết quả không chính xác khi bạn sử dụng thư viện trong nhiều luồng.

Chúng tôi mạnh mẽ khuyên bạn **không** sử dụng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) duy nhất trong môi trường đa luồng vì nó có thể dẫn đến các lỗi hoặc thất bại không thể dự đoán và khó phát hiện.

Việc **không** an toàn để tải, lưu và/hoặc sao chép một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) trong nhiều luồng. Các thao tác như vậy **không** được hỗ trợ. Nếu bạn cần thực hiện các nhiệm vụ này, bạn phải song song hoá các thao tác bằng cách sử dụng một số tiến trình đơn luồng — và mỗi tiến trình này nên sử dụng thể hiện bài trình chiếu riêng của nó.

## **Chuyển đổi các slide của bài trình chiếu sang hình ảnh một cách song song**

Giả sử chúng ta muốn chuyển đổi tất cả các slide từ một bài trình chiếu PowerPoint sang hình ảnh PNG một cách song song. Vì việc sử dụng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) duy nhất trong nhiều luồng là không an toàn, chúng ta chia các slide của bài trình chiếu thành các bài trình chiếu riêng biệt và chuyển đổi các slide sang hình ảnh một cách song song, sử dụng mỗi bài trình chiếu trong một luồng riêng. Ví dụ mã sau đây cho thấy cách thực hiện.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # Trích xuất slide vào một bài trình chiếu riêng.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # Chuyển đổi slide thành hình ảnh trong một tác vụ riêng.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # Đợi cho tất cả các tác vụ hoàn thành.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có cần gọi thiết lập giấy phép trong mỗi luồng không?**

Không. Chỉ cần thực hiện một lần duy nhất cho mỗi tiến trình trước khi các luồng bắt đầu. Nếu [thiết lập giấy phép](/slides/vi/python-java/licensing/) có thể được gọi đồng thời (ví dụ, trong quá trình khởi tạo lười), hãy đồng bộ cuộc gọi đó vì phương thức thiết lập giấy phép tự nó không an toàn với đa luồng.

**Tôi có thể chuyển các đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) hoặc [Slide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/) giữa các luồng không?**

Việc chuyển các đối tượng bài trình chiếu "sống" giữa các luồng không được khuyến nghị: hãy sử dụng các thể hiện độc lập cho mỗi luồng hoặc tạo các bài trình chiếu riêng biệt hoặc các container slide cho mỗi luồng từ trước. Cách tiếp cận này tuân theo khuyến nghị chung là không chia sẻ một thể hiện bài trình chiếu duy nhất giữa các luồng.

**Việc xuất ra các định dạng khác nhau (PDF, HTML, hình ảnh) một cách song song có an toàn không, với điều kiện mỗi luồng có một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) riêng?**

Có. Với các thể hiện độc lập và các đường xuất riêng biệt, các tác vụ như vậy thường được song song hoá một cách chính xác; tránh bất kỳ đối tượng bài trình chiếu chung nào và các luồng I/O chung.

**Tôi nên làm gì với cấu hình phông chữ toàn cục (thư mục, thay thế) trong đa luồng?**

Khởi tạo tất cả các [cài đặt phông chữ](/slides/vi/python-java/powerpoint-fonts/) toàn cục trước khi khởi động các luồng và không thay đổi chúng trong quá trình làm việc song song. Điều này loại bỏ các cuộc tranh chấp khi truy cập tài nguyên phông chữ chung.