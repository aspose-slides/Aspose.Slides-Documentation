---
title: Thay đổi kích thước slide trong bài thuyết trình bằng Python
linktitle: Kích thước slide
type: docs
weight: 70
url: /vi/python-net/slide-size/
keywords:
- kích thước slide
- tỉ lệ khung hình
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
- bài thuyết trình
- Python
- Aspose.Slides
description: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng Python và Aspose.Slides, tối ưu hóa bài thuyết trình cho mọi loại màn hình mà không làm mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bài thuyết trình PowerPoint, rất quan trọng đối với việc in ấn và hiển thị trên màn hình. 

Các kích thước slide phổ biến và tỷ lệ:

- **Standard (Tỷ lệ 4:3)**: Phù hợp với các màn hình và thiết bị cũ.
- **Widescreen (Tỷ lệ 16:9)**: Được khuyến nghị cho máy chiếu và màn hình hiện đại.

Hãy đảm bảo tính nhất quán trong toàn bộ bài thuyết trình vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để đạt kết quả tối ưu, hãy đặt kích thước slide ngay từ đầu quá trình tạo bài thuyết trình để tránh các phức tạp.

{{% alert color="primary" %}} 
Mặc định, các bài thuyết trình được tạo bằng Aspose.Slides sử dụng tỷ lệ chuẩn 4:3.
{{% /alert %}}

## **Thay đổi kích thước slide trong một bài thuyết trình**

Mã mẫu này cho bạn thấy cách thay đổi kích thước slide trong một bài thuyết trình bằng Python sử dụng Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Xác định kích thước slide tùy chỉnh**

Nếu bạn thấy các kích thước slide phổ biến (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide toàn kích thước từ bài thuyết trình trên một bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bài thuyết trình trên một số loại màn hình nhất định, bạn có khả năng hưởng lợi từ việc sử dụng cài đặt kích thước tùy chỉnh cho bài thuyết trình.

Mã mẫu này cho bạn thấy cách sử dụng Aspose.Slides cho Python thông qua .NET để chỉ định kích thước slide tùy chỉnh cho một bài thuyết trình trong Python:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # Kích thước giấy A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi bạn thay đổi kích thước slide cho một bài thuyết trình, nội dung các slide (hình ảnh hoặc đối tượng, ví dụ) có thể bị biến dạng. Mặc định, các đối tượng sẽ tự động được thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của một bài thuyết trình, bạn có thể chỉ định một cài đặt xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu của bạn, bạn có thể sử dụng bất kỳ cài đặt nào sau:

- `DO_NOT_SCALE`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng thiết lập này.

- `ENSURE_FIT`

  Nếu bạn muốn thu nhỏ đến kích thước slide nhỏ hơn và cần Aspose.Slides thu nhỏ các đối tượng trên slide để đảm bảo chúng tất cả vừa trên slide (như vậy, bạn tránh mất nội dung), hãy sử dụng thiết lập này. 

- `MAXIMIZE`

  Nếu bạn muốn mở rộng đến kích thước slide lớn hơn và cần Aspose.Slides phóng to các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng thiết lập này. 

Mã mẫu này cho bạn thấy cách sử dụng cài đặt `MAXIMIZE` khi thay đổi kích thước slide của một bài thuyết trình:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác ngoài inch (ví dụ, điểm hoặc milimet) không?**

Có. Aspose.Slides sử dụng đơn vị điểm (point) nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang point và sử dụng các giá trị đã chuyển đổi để xác định chiều rộng và chiều cao của slide.

**Kích thước slide tùy chỉnh rất lớn sẽ ảnh hưởng đến hiệu năng và mức tiêu thụ bộ nhớ khi render không?**

Có. Kích thước slide lớn hơn (tính bằng point) cộng với tỷ lệ render cao hơn sẽ làm tăng mức tiêu thụ bộ nhớ và thời gian xử lý. Hãy hướng tới một kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt chất lượng đầu ra mong muốn.

**Tôi có thể xác định một kích thước slide không chuẩn và sau đó hợp nhất các slide từ các bài thuyết trình có kích thước khác nhau không?**

Bạn không thể [merge presentations](/slides/vi/python-net/merge-presentation/) khi chúng có kích thước slide khác nhau — trước hết, hãy thay đổi kích thước của một bài thuyết trình cho khớp với bài còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesizescaletype/). Sau khi cân chỉnh kích thước, bạn có thể hợp nhất các slide mà vẫn giữ nguyên định dạng.

**Tôi có thể tạo thumbnail cho các hình dạng riêng lẻ hoặc các vùng cụ thể của slide không, và chúng có sẽ tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể render thumbnail cho [entire slides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/) cũng như cho [selected shapes](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_image/). Các hình ảnh tạo ra phản ánh kích thước slide và tỷ lệ khung hình hiện tại, đảm bảo khung hình và hình học nhất quán.