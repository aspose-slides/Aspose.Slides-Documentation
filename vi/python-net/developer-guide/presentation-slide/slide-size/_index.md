---
title: Thay đổi kích thước slide trong bản trình bày bằng Python
linktitle: Kích thước slide
type: docs
weight: 70
url: /vi/python-net/slide-size/
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
- slide toàn kích thước
- loại màn hình
- không thu phóng
- đảm bảo vừa
- tối đa hoá
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
descriptions: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng Python và Aspose.Slides, tối ưu hóa bản trình bày cho bất kỳ màn hình nào mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bản PowerPoint, rất quan trọng cho cả việc in ấn và hiển thị trên màn hình. 

Các kích thước slide phổ biến và tỷ lệ:

- **Standard (4:3 Aspect Ratio)**: Lý tưởng cho các màn hình và thiết bị cũ.
- **Widescreen (16:9 Aspect Ratio)**: Được khuyến nghị cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bài thuyết trình vì một kích thước slide và tỷ lệ khung hình duy nhất áp dụng cho tất cả các slide. Để đạt kết quả tối ưu, hãy thiết lập kích thước slide ngay từ đầu quá trình tạo bài thuyết trình để tránh các vấn đề.

{{% alert color="primary" %}} 
Mặc định, các bản trình bày được tạo bằng Aspose.Slides sử dụng tỷ lệ khung hình chuẩn 4:3.
{{% /alert %}}

## **Thay đổi kích thước slide trong một bản trình bày**

Mã mẫu này cho bạn thấy cách thay đổi kích thước slide trong một bản trình bày bằng Python sử dụng Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Xác định kích thước slide tùy chỉnh**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc duy nhất. Ví dụ, nếu bạn dự định in các slide kích thước đầy đủ từ bản trình bày trên bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bản trình bày trên một số loại màn hình nhất định, bạn có thể hưởng lợi từ việc sử dụng thiết lập kích thước tùy chỉnh cho bản trình bày.

Mã mẫu này cho bạn thấy cách sử dụng Aspose.Slides cho Python qua .NET để chỉ định kích thước slide tùy chỉnh cho một bản trình bày bằng Python:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # kích thước giấy A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi bạn thay đổi kích thước slide cho một bản trình bày, nội dung của các slide (hình ảnh hoặc đối tượng, ví dụ) có thể bị biến dạng. Mặc định, các đối tượng sẽ tự động được thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bản trình bày, bạn có thể chỉ định một thiết lập xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu của bạn, bạn có thể sử dụng bất kỳ một trong các thiết lập sau:

- `DO_NOT_SCALE`

  Nếu bạn KHÔNG muốn các đối tượng trên slide bị thay đổi kích thước, hãy sử dụng thiết lập này.

- `ENSURE_FIT`

  Nếu bạn muốn thu nhỏ kích thước slide và cần Aspose.Slides giảm kích thước các đối tượng trên slide để đảm bảo chúng đều vừa vào slide (điều này giúp tránh mất nội dung), hãy sử dụng thiết lập này.

- `MAXIMIZE`

  Nếu bạn muốn phóng to kích thước slide và cần Aspose.Slides tăng kích thước các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng thiết lập này.

Mã mẫu này cho bạn thấy cách sử dụng thiết lập `MAXIMIZE` khi thay đổi kích thước slide của một bản trình bày:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác nhau ngoài inch (ví dụ, point hoặc milimet)?**

Có. Aspose.Slides sử dụng đơn vị point nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang point và sử dụng các giá trị đã chuyển để xác định chiều rộng và chiều cao của slide.

**Kích thước slide tùy chỉnh rất lớn sẽ ảnh hưởng đến hiệu suất và bộ nhớ khi dựng hình không?**

Có. Kích thước slide lớn hơn (tính bằng point) kết hợp với tỷ lệ dựng hình cao hơn sẽ làm tăng tiêu thụ bộ nhớ và thời gian xử lý. Hãy hướng tới một kích thước slide thực tế và chỉ điều chỉnh tỷ lệ dựng hình khi cần để đạt chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn và sau đó hợp nhất các slide từ các bản trình bày có kích thước khác nhau không?**

Bạn không thể [hợp nhất các bản trình bày](/slides/vi/python-net/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bản trình bày cho khớp với bản còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slidesizescaletype/). Sau khi cân chỉnh kích thước, bạn có thể hợp nhất các slide mà vẫn giữ định dạng.

**Tôi có thể tạo thumbnail cho các hình dạng riêng lẻ hoặc vùng cụ thể của một slide và chúng sẽ tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể tạo thumbnail cho [toàn bộ slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/slide/get_image/) cũng như cho [các hình dạng được chọn](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shape/get_image/). Các hình ảnh tạo ra phản ánh kích thước và tỷ lệ khung hình hiện tại của slide, đảm bảo khung hình và hình học nhất quán.