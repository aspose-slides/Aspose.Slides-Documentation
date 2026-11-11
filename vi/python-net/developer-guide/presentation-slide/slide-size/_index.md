---
title: Thay đổi Kích thước Slide trong Bản trình bày bằng Python
linktitle: Kích thước Slide
type: docs
weight: 70
url: /vi/python-net/slide-size/
keywords:
- kích thước slide
- tỷ lệ khung hình
- chuẩn
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
- đảm bảo phù hợp
- tối đa hoá
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng Python và Aspose.Slides, tối ưu hóa bản trình bày cho mọi màn hình mà không làm giảm chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bản trình bày PowerPoint, rất quan trọng cho cả việc in ấn và hiển thị trên màn hình. 

Các kích thước slide phổ biến và tỷ lệ:

- **Chuẩn (Tỷ lệ 4:3)**: Phù hợp với các màn hình và thiết bị cũ.
- **Màn hình rộng (Tỷ lệ 16:9)**: Được đề xuất cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bản trình bày vì một kích thước slide và tỷ lệ khối hình duy nhất sẽ áp dụng cho tất cả các slide. Để có kết quả tối ưu, hãy thiết lập kích thước slide ngay từ đầu quá trình tạo bản trình bày để tránh các vấn đề.

{{% alert color="info" title="Note" %}}
Mặc định, các bản trình bày được tạo bằng Aspose.Slides sử dụng tỷ lệ chuẩn 4:3.
{{% /alert %}}

Các trang ghi chú và tài liệu phát tay có kích thước riêng so với các slide thường. Xem [Kích thước Trang Ghi chú](/slides/vi/python-net/notes-size/) để thay đổi kích thước và hướng của chúng.

## **Thay đổi Kích thước Slide trong Bản trình bày**

Mã mẫu này cho bạn thấy cách thay đổi kích thước slide trong một bản trình bày bằng Python sử dụng Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Xác định Kích thước Slide Tùy chỉnh**

Nếu bạn thấy các kích thước slide phổ biến (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide kích thước đầy đủ từ bản trình bày trên bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bản trình bày trên một số loại màn hình nhất định, bạn có thể hưởng lợi từ việc sử dụng cài đặt kích thước tùy chỉnh cho bản trình bày.

Mã mẫu này cho bạn thấy cách sử dụng Aspose.Slides cho Python thông qua .NET để chỉ định kích thước slide tùy chỉnh cho một bản trình bày bằng Python:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # kích thước giấy A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Xử lý Nội dung Slide Sau Khi Thay Đổi Kích Thước**

Sau khi bạn thay đổi kích thước slide cho một bản trình bày, nội dung các slide (hình ảnh hoặc đối tượng, ví dụ) có thể bị biến dạng. Mặc định, các đối tượng sẽ tự động được điều chỉnh kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide, bạn có thể chỉ định một cài đặt xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu của bạn, bạn có thể sử dụng bất kỳ cài đặt nào sau đây:

- `DO_NOT_SCALE`
  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng cài đặt này.

- `ENSURE_FIT`
  Nếu bạn muốn thu nhỏ kích thước slide và cần Aspose.Slides thu nhỏ các đối tượng trên slide để chúng đều vừa trên slide (điều này giúp tránh mất nội dung), hãy sử dụng cài đặt này.

- `MAXIMIZE`
  Nếu bạn muốn phóng to kích thước slide và cần Aspose.Slides phóng đại các đối tượng trên slide để chúng tỉ lệ với kích thước slide mới, hãy sử dụng cài đặt này.

Mã mẫu này cho bạn thấy cách sử dụng cài đặt `MAXIMIZE` khi thay đổi kích thước slide của một bản trình bày:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt kích thước slide tùy chỉnh bằng đơn vị khác ngoài inch (ví dụ, điểm hoặc milimét) không?**

Có. Aspose.Slides sử dụng đơn vị điểm bên trong, trong đó 1 điểm bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimét hoặc centimet) sang điểm và sử dụng các giá trị đã chuyển để định nghĩa chiều rộng và chiều cao của slide.

**Kích thước slide tùy chỉnh rất lớn có ảnh hưởng tới hiệu năng và việc sử dụng bộ nhớ trong quá trình render không?**

Có. Kích thước slide lớn hơn (theo điểm) kết hợp với tỉ lệ render cao hơn sẽ làm tăng lượng bộ nhớ tiêu thụ và thời gian xử lý. Hãy hướng tới một kích thước slide thực tế và chỉ điều chỉnh tỉ lệ render khi cần thiết để đạt chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn và sau đó hợp nhất các slide từ các bản trình bày có kích thước khác nhau không?**

Bạn không thể [hợp nhất các bản trình bày](/slides/vi/python-net/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bản trình bày để khớp với bản còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesizescaletype/). Sau khi cân chỉnh kích thước, bạn có thể hợp nhất các slide mà vẫn giữ nguyên định dạng.

**Tôi có thể tạo ảnh thu nhỏ cho các hình dạng riêng lẻ hoặc vùng cụ thể của một slide và chúng có tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể render ảnh thu nhỏ cho [toàn bộ slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/) cũng như cho [các hình dạng được chọn](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_image/). Các ảnh kết quả phản ánh kích thước và tỷ lệ khung hình hiện tại của slide, đảm bảo khung hình và hình học nhất quán.