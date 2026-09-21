---
title: Thay đổi kích thước slide của bản trình chiếu bằng Python qua Java
linktitle: Kích thước slide
type: docs
weight: 70
url: /vi/python-java/slide-size/
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
- đảm bảo vừa
- tối đa hoá
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng Python qua Java và Aspose.Slides, đồng thời tối ưu hóa bản trình chiếu cho bất kỳ màn hình nào mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bản trình chiếu PowerPoint, rất quan trọng cho cả việc in ấn và hiển thị trên màn hình.

Các kích thước slide và tỷ lệ phổ biến:

- **Standard (4:3 Aspect Ratio)**: Thích hợp cho các màn hình và thiết bị cũ.
- **Widescreen (16:9 Aspect Ratio)**: Được khuyến nghị cho các máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong suốt bài thuyết trình của bạn vì một kích thước slide và tỷ lệ khung hình duy nhất áp dụng cho tất cả các slide. Để có kết quả tối ưu, hãy thiết lập kích thước slide ngay từ đầu quá trình tạo bài thuyết trình để tránh các phức tạp.

{{% alert color="info" title="Note" %}}
Mặc định, các bản trình chiếu được tạo bằng Aspose.Slides sử dụng tỷ lệ khung hình chuẩn 4:3.
{{% /alert %}}

Các trang Ghi chú và tài liệu phát tay có kích thước riêng so với các slide thông thường. Xem [Notes Page Size](/slides/vi/python-java/notes-size/) để thay đổi kích thước và hướng của chúng.

## **Thay đổi kích thước slide trong bản trình chiếu**

Đoạn mã mẫu này cho bạn thấy cách thay đổi kích thước slide trong một bản trình chiếu bằng Python thông qua Java sử dụng Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Xác định kích thước slide tùy chỉnh trong bản trình chiếu**

Nếu bạn thấy các kích thước slide phổ biến (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in slide kích thước đầy đủ từ bản trình chiếu trên một bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bản trình chiếu trên một số loại màn hình nhất định, bạn có thể hưởng lợi từ việc sử dụng cài đặt kích thước tùy chỉnh cho bản trình chiếu.

Đoạn mã mẫu này cho bạn thấy cách sử dụng Aspose.Slides cho Python thông qua Java để chỉ định kích thước slide tùy chỉnh cho một bản trình chiếu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi bạn thay đổi kích thước slide cho một bản trình chiếu, nội dung các slide (ví dụ như hình ảnh hoặc đối tượng) có thể bị biến dạng. Mặc định, các đối tượng sẽ tự động được thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bản trình chiếu, bạn có thể chỉ định một cài đặt xác định cách Aspose.Slides xử lý nội dung trên các slide.

Dựa trên mục tiêu hoặc nhu cầu của bạn, bạn có thể sử dụng bất kỳ cài đặt nào sau đây:

- [DoNotScale](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  Nếu bạn KHÔNG muốn các đối tượng trên slide được thay đổi kích thước, hãy sử dụng cài đặt này.

- [EnsureFit](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  Nếu bạn muốn thu nhỏ kích thước slide và cần Aspose.Slides thu nhỏ các đối tượng trên slide để đảm bảo chúng đều vừa trên slide (cách này giúp tránh mất nội dung), hãy sử dụng cài đặt này.

- [Maximize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesizescaletype/#Maximize)

  Nếu bạn muốn phóng to kích thước slide và cần Aspose.Slides phóng to các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng cài đặt này.

Đoạn mã mẫu này cho bạn thấy cách sử dụng cài đặt [Maximize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesizescaletype/#Maximize) khi thay đổi kích thước slide của một bản trình chiếu:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác ngoài inch (ví dụ, point hoặc milimet) không?**

Có. Aspose.Slides sử dụng đơn vị point nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang point và sử dụng các giá trị đã chuyển đổi để xác định chiều rộng và chiều cao của slide.

**Kích thước slide tùy chỉnh rất lớn sẽ ảnh hưởng đến hiệu năng và việc sử dụng bộ nhớ trong quá trình render không?**

Có. Kích thước slide lớn hơn (tính bằng point) cùng với tỷ lệ render cao hơn sẽ gây ra việc tiêu thụ bộ nhớ tăng và thời gian xử lý lâu hơn. Hãy hướng tới một kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn rồi sau đó hợp nhất các slide từ các bản trình chiếu có kích thước khác nhau không?**

Bạn không thể [merge presentations](/slides/vi/python-java/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bản trình chiếu để khớp với bản còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesizescaletype/). Sau khi đồng nhất kích thước, bạn có thể hợp nhất các slide trong khi vẫn giữ định dạng.

**Tôi có thể tạo ảnh thu nhỏ cho các hình dạng riêng lẻ hoặc các vùng cụ thể của slide và chúng có tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể tạo ảnh thu nhỏ cho [entire slides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) cũng như cho [selected shapes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage). Các hình ảnh tạo ra phản ánh kích thước slide và tỷ lệ khung hình hiện tại, đảm bảo khung và hình học nhất quán.