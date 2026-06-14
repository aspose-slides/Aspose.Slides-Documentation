---
title: Xử lý đa luồng trong Aspose.Slides cho Python
linktitle: Đa luồng
type: docs
weight: 200
url: /vi/python-net/multithreading/
keywords:
- đa luồng
- nhiều luồng
- công việc song song
- chuyển đổi slide
- slide sang hình ảnh
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Aspose.Slides cho Python qua .NET đa luồng tăng tốc xử lý PowerPoint và OpenDocument. Khám phá các thực tiễn tốt nhất để tối ưu quy trình làm việc với bản trình bày."
---
## **Giới thiệu**

Mặc dù có thể thực hiện công việc song song với các bản trình bày (ngoài việc phân tích/tải/nhân bản) và mọi thứ thường diễn ra tốt (đa phần), vẫn có một khả năng nhỏ bạn có thể nhận được kết quả không chính xác khi sử dụng thư viện trong nhiều luồng.

Chúng tôi rất khuyến cáo bạn **không** sử dụng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) duy nhất trong môi trường đa luồng vì nó có thể gây ra các lỗi hoặc sự cố không thể dự đoán và khó phát hiện. 

Việc tải, lưu và/hoặc sao chép một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) trong nhiều luồng **không** an toàn. Các thao tác như vậy **không** được hỗ trợ. Nếu bạn cần thực hiện các tác vụ này, bạn phải thực hiện song song bằng cách sử dụng một số tiến trình đơn luồng—và mỗi tiến trình này nên sử dụng một thể hiện presentation riêng. 

## **Chuyển đổi các slide của Presentation thành hình ảnh một cách song song**

Giả sử chúng ta muốn chuyển đổi tất cả các slide từ một bản trình bày PowerPoint sang hình ảnh PNG một cách song song. Vì việc sử dụng một thể hiện `Presentation` duy nhất trong nhiều luồng không an toàn, chúng ta chia các slide thành các presentation riêng biệt và chuyển đổi các slide thành hình ảnh song song, sử dụng mỗi presentation trong một luồng riêng. Đoạn mã mẫu dưới đây minh họa cách thực hiện.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Trích xuất slide i vào một bản trình bày riêng.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Chuyển đổi slide thành hình ảnh.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Chờ cho tất cả các tác vụ hoàn thành.
for task in conversion_tasks:
    task.result()

del presentation
```

## **Câu hỏi thường gặp**

**Tôi có cần gọi cài đặt giấy phép trong mỗi luồng không?**

Không. Chỉ cần thực hiện một lần cho mỗi tiến trình/một miền ứng dụng trước khi các luồng khởi chạy. Nếu [license setup](/slides/vi/python-net/licensing/) có thể được gọi đồng thời (ví dụ, trong quá trình khởi tạo lười), hãy đồng bộ cuộc gọi đó vì phương thức cài đặt giấy phép không an toàn với đa luồng.

**Tôi có thể truyền các đối tượng `Presentation` hoặc `Slide` qua lại giữa các luồng không?**

Việc truyền các đối tượng presentation “trực tiếp” qua lại giữa các luồng không được khuyến nghị: hãy sử dụng các thể hiện độc lập cho mỗi luồng hoặc tạo trước các presentation/đối tượng slide riêng cho mỗi luồng. Cách tiếp cận này phù hợp với khuyến cáo chung là không chia sẻ một thể hiện presentation duy nhất giữa các luồng.

**Có an toàn khi thực hiện xuất song song sang các định dạng khác nhau (PDF, HTML, hình ảnh) với điều kiện mỗi luồng có một thể hiện `Presentation` riêng không?**

Có. Với các thể hiện độc lập và các đường dẫn đầu ra riêng biệt, các tác vụ như vậy thường được thực hiện song song một cách đúng đắn; tránh sử dụng bất kỳ đối tượng presentation nào được chia sẻ và tránh chia sẻ các luồng I/O.

**Tôi nên làm gì với các cài đặt phông chữ toàn cục (thư mục, thay thế) trong môi trường đa luồng?**

Khởi tạo tất cả các cài đặt phông chữ toàn cục trước khi bắt đầu các luồng và không thay đổi chúng trong quá trình làm việc song song. Điều này loại bỏ các tranh chấp khi truy cập tài nguyên phông chữ chung.