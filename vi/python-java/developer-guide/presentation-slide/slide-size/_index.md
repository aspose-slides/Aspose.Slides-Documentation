---
title: Thay đổi kích thước slide trong bài thuyết trình bằng Python qua Java
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
- Java
- Aspose.Slides
description: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng Python qua Java và Aspose.Slides, và tối ưu hóa bài thuyết trình cho bất kỳ màn hình nào mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bài thuyết trình PowerPoint, rất quan trọng cho cả việc in ấn và hiển thị trên màn hình.

Các kích thước slide phổ biến và tỷ lệ:

- **Standard (4:3 Aspect Ratio)**: Lý tưởng cho các màn hình và thiết bị cũ.
- **Widescreen (16:9 Aspect Ratio)**: Được khuyến nghị cho các máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong suốt bài thuyết trình vì một kích thước slide và tỷ lệ khung hình duy nhất áp dụng cho tất cả các slide. Để có kết quả tốt nhất, hãy đặt kích thước slide ngay từ đầu quá trình tạo bài thuyết trình để tránh các vấn đề.

{{% alert color="info" title="Note" %}}
Theo mặc định, các bài thuyết trình được tạo bằng Aspose.Slides sử dụng tỷ lệ khung hình chuẩn 4:3.
{{% /alert %}}

## **Thay đổi kích thước slide trong bài thuyết trình**

Mã mẫu này cho bạn thấy cách thay đổi kích thước slide trong một bài thuyết trình bằng Python qua Java sử dụng Aspose.Slides:

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

## **Xác định kích thước slide tùy chỉnh trong bài thuyết trình**

Nếu bạn thấy các kích thước slide thông thường (4:3 và 16:9) không phù hợp với công việc của mình, bạn có thể quyết định sử dụng một kích thước slide cụ thể hoặc độc đáo. Ví dụ, nếu bạn dự định in các slide kích thước đầy đủ từ bài thuyết trình trên một bố cục trang tùy chỉnh hoặc nếu bạn muốn hiển thị bài thuyết trình trên một số loại màn hình nhất định, bạn có thể hưởng lợi từ việc sử dụng thiết lập kích thước tùy chỉnh cho bài thuyết trình.

Mã mẫu này cho bạn thấy cách sử dụng Aspose.Slides cho Python qua Java để chỉ định kích thước slide tùy chỉnh cho một bài thuyết trình:

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

Sau khi bạn thay đổi kích thước slide cho một bài thuyết trình, nội dung các slide (hình ảnh hoặc đối tượng, ví dụ) có thể bị biến dạng. Theo mặc định, các đối tượng sẽ tự động được thay đổi kích thước để phù hợp với kích thước slide mới. Tuy nhiên, khi thay đổi kích thước slide của bài thuyết trình, bạn có thể chỉ định một cài đặt xác định cách Aspose.Slides xử lý nội dung trên các slide.

Tùy thuộc vào mục tiêu hoặc kết quả bạn muốn đạt được, bạn có thể sử dụng bất kỳ cài đặt nào sau đây:

- [DoNotScale](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesizescaletype/#DoNotScale)
  
  Nếu bạn KHÔNG muốn các đối tượng trên slide được thay đổi kích thước, hãy sử dụng cài đặt này.

- [EnsureFit](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesizescaletype/#EnsureFit)
  
  Nếu bạn muốn thu nhỏ đến một kích thước slide nhỏ hơn và cần Aspose.Slides thu nhỏ các đối tượng trên slide để đảm bảo chúng tất cả vừa trên slide (cách này giúp bạn tránh mất nội dung), hãy sử dụng cài đặt này.

- [Maximize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesizescaletype/#Maximize)
  
  Nếu bạn muốn phóng to đến một kích thước slide lớn hơn và cần Aspose.Slides mở rộng các đối tượng trên slide để chúng tỷ lệ với kích thước slide mới, hãy sử dụng cài đặt này.

Mã mẫu này cho bạn thấy cách sử dụng cài đặt [Maximize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesizescaletype/#Maximize) khi thay đổi kích thước slide của một bài thuyết trình:

```python
import jpype
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

Có. Aspose.Slides sử dụng đơn vị point bên trong, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang point và sử dụng các giá trị đã chuyển đổi để xác định chiều rộng và chiều cao của slide.

**Kích thước slide tùy chỉnh rất lớn có ảnh hưởng đến hiệu năng và việc sử dụng bộ nhớ trong quá trình render không?**

Có. Kích thước slide lớn hơn (tính bằng point) cộng với tỷ lệ render cao hơn sẽ gây tăng tiêu thụ bộ nhớ và thời gian xử lý lâu hơn. Hãy hướng tới một kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt chất lượng đầu ra mong muốn.

**Tôi có thể xác định một kích thước slide không tiêu chuẩn rồi sau đó hợp nhất các slide từ các bài thuyết trình có kích thước khác nhau không?**

Bạn không thể [merge presentations](/slides/vi/python-java/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bài thuyết trình để khớp với bài còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesizescaletype/). Sau khi đồng nhất kích thước, bạn có thể hợp nhất các slide đồng thời bảo toàn định dạng.

**Tôi có thể tạo thumbnail cho các shape riêng lẻ hoặc khu vực cụ thể của một slide không, và chúng có tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể tạo thumbnail cho [entire slides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/#getImage) cũng như cho [selected shapes](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getImage). Các hình ảnh kết quả phản ánh kích thước slide và tỷ lệ khung hình hiện tại, đảm bảo khung hình và hình học nhất quán.