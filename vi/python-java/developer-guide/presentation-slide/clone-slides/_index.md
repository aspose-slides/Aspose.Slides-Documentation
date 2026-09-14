---
title: Sao chép các Slide Bản trình chiếu trong Python
linktitle: Sao chép Slides
type: docs
weight: 35
url: /vi/python-java/clone-slides/
keywords:
- sao chép slide
- chép slide
- lưu slide
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Nhanh chóng sao chép các slide PowerPoint bằng Aspose.Slides cho Python qua Java. Tham khảo các ví dụ mã rõ ràng của chúng tôi để tự động tạo PPT trong vài giây và loại bỏ công việc thủ công."
---
## **Giới thiệu**

Sao chép (cloning) là quá trình tạo một bản sao chính xác hoặc bản sao của một đối tượng. Aspose.Slides for Python qua Java cũng cho phép tạo một bản sao hoặc sao chép của bất kỳ slide nào và sau đó chèn slide đã sao chép đó vào bản trình chiếu hiện tại hoặc bất kỳ bản trình chiếu mở nào khác. Quá trình sao chép slide tạo ra một slide mới mà các nhà phát triển có thể chỉnh sửa mà không làm thay đổi slide gốc. Có một số cách để sao chép một slide:

- Sao chép vào cuối trong cùng một bản trình chiếu.
- Sao chép vào vị trí khác trong cùng một bản trình chiếu.
- Sao chép vào cuối trong một bản trình chiếu khác.
- Sao chép vào vị trí khác trong một bản trình chiếu khác.
- Sao chép cùng với slide master của nó vào một bản trình chiếu khác.

Trong Aspose.Slides for Python qua Java, bộ sưu tập slide (một tập hợp các đối tượng [Slide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slide/) ) do đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) cung cấp, có các phương thức [addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addClone) và [insertClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#insertClone) để thực hiện các kiểu sao chép slide nêu trên.

## **Sao chép một Slide ở Cuối Bản Trình Chiếu**

Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu ở cuối các slide hiện có, hãy sử dụng phương thức [addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addClone) theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/) bằng cách tham chiếu tới bộ Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
3. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addClone) do đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/) cung cấp và truyền slide cần sao chép làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addClone).
4. Ghi tệp bản trình chiếu đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (nằm ở vị trí đầu tiên – chỉ số không – của bản trình chiếu) tới cuối bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # Sao chép slide mong muốn tới cuối bộ sưu tập slide trong cùng một bản trình chiếu
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # Ghi bản trình chiếu đã sửa đổi ra đĩa
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sao chép một Slide đến Vị trí Khác trong cùng một Bản Trình Chiếu**

Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu nhưng ở vị trí khác, hãy sử dụng phương thức [insertClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#insertClone):

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
2. Lấy tham chiếu đến bộ slide được trả về bởi [getSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSlides) trên đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
3. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#insertClone) do đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/) cung cấp và truyền slide cần sao chép cùng với chỉ số vị trí mới làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#insertClone).
4. Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (nằm ở chỉ số 1 – vị trí 2 – của bản trình chiếu) tới chỉ số 2 – vị trí 3 – của bản trình chiếu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Lấy bộ sưu tập các slide trong bản trình chiếu
    slides = presentation.getSlides()

    # Sao chép slide mong muốn tới chỉ mục được chỉ định trong cùng một bản trình chiếu
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Ghi bản trình chiếu đã sửa đổi ra đĩa
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sao chép một Slide ở Cuối Bản Trình Chiếu Khác**

Nếu bạn cần sao chép một slide từ một bản trình chiếu và sử dụng nó trong một bản trình chiếu khác, ở cuối các slide hiện có:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) chứa bản trình chiếu mà slide sẽ được sao chép từ đó.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) chứa bản trình chiếu đích mà slide sẽ được thêm vào.
3. Lấy đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/) bằng cách tham chiếu tới bộ slide được trả về bởi [getSlides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getSlides) trên đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) của bản trình chiếu đích.
4. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addClone) do đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/) cung cấp và truyền slide từ bản trình chiếu nguồn làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addClone).
5. Ghi tệp bản trình chiếu đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (từ chỉ số 0 của bản trình chiếu nguồn) tới cuối bản trình chiếu đích.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    destination_presentation = Presentation()
    try:
        # Sao chép slide mong muốn từ bản trình chiếu nguồn tới cuối bộ sưu tập slide trong bản trình chiếu đích
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # Ghi bản trình chiếu đích ra đĩa
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Sao chép một Slide đến Vị trí Khác trong Bản Trình Chiếu Khác**

Nếu bạn cần sao chép một slide từ một bản trình chiếu và sử dụng nó trong một bản trình chiếu khác, ở một vị trí cụ thể:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) chứa bản trình chiếu nguồn mà slide sẽ được sao chép từ đó.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) chứa bản trình chiếu mà slide sẽ được thêm vào.
3. Lấy đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/) bằng cách tham chiếu tới bộ Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) của bản trình chiếu đích.
4. Gọi phương thức [insertClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#insertClone) do đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/) cung cấp và truyền slide từ bản trình chiếu nguồn cùng với vị trí mong muốn làm tham số cho phương thức [insertClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#insertClone).
5. Ghi tệp bản trình chiếu đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide (từ chỉ số không của bản trình chiếu nguồn) tới chỉ số 1 (vị trí 2) của bản trình chiếu đích.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Khởi tạo lớp Presentation cho PPTX đích (nơi slide sẽ được sao chép)
    destination_presentation = Presentation()
    try:
        # Sao chép slide mong muốn từ bản trình chiếu nguồn tới chỉ mục được chỉ định trong bản trình chiếu đích
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # Ghi bản trình chiếu đích ra đĩa
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Sao chép một Slide cùng với Slide Master của nó vào Bản Trình Chiếu Khác**

Nếu bạn cần sao chép một slide cùng với slide master từ một bản trình chiếu và sử dụng nó trong một bản trình chiếu khác, trước tiên bạn phải sao chép slide master mong muốn từ bản trình chiếu nguồn sang bản trình chiếu đích. Sau đó sử dụng slide master đã sao chép khi sao chép slide. Phương thức [addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addClone) yêu cầu một slide master từ bản trình chiếu đích chứ không phải từ bản trình chiếu nguồn. Để sao chép slide có master, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) chứa bản trình chiếu nguồn mà slide sẽ được sao chép từ đó.
2. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) chứa bản trình chiếu đích mà slide sẽ được sao chép tới.
3. Truy cập slide cần sao chép cùng với master slide của nó.
4. Lấy đối tượng [MasterSlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslidecollection/) bằng cách tham chiếu tới bộ Masters được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) của bản trình chiếu đích.
5. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslidecollection/#addClone) do đối tượng [MasterSlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslidecollection/) cung cấp và truyền master từ PPTX nguồn cần sao chép làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslidecollection/#addClone).
6. Lấy đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/) bằng cách tham chiếu tới bộ Slides được cung cấp bởi đối tượng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) của bản trình chiếu đích.
7. Gọi phương thức [addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addClone) do đối tượng [SlideCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/) cung cấp và truyền slide từ bản trình chiếu nguồn cần sao chép cùng với master slide làm tham số cho phương thức [addClone](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addClone).
8. Ghi tệp bản trình chiếu đích đã sửa đổi.

Trong ví dụ dưới đây, chúng tôi đã sao chép một slide có master (nằm ở chỉ số không của bản trình chiếu nguồn) tới cuối bản trình chiếu đích bằng cách sử dụng master của slide nguồn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Khởi tạo lớp Presentation cho bản trình chiếu đích (nơi slide sẽ được sao chép)
    destination_presentation = Presentation()
    try:
        # Khởi tạo Slide từ bộ sưu tập các slide trong bản trình chiếu nguồn cùng với
        # Slide master
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # Sao chép slide master mong muốn từ bản trình chiếu nguồn vào bộ sưu tập các master trong
        # bản trình chiếu đích
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # Sao chép slide mong muốn từ bản trình chiếu nguồn với master mong muốn tới cuối
        # Bộ sưu tập các slide trong bản trình chiếu đích
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Lưu bản trình chiếu đích ra đĩa
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Sao chép một Slide ở Cuối Phần Được Xác Định**

Nếu bạn muốn sao chép một slide và sau đó sử dụng nó trong cùng một tệp bản trình chiếu nhưng ở một phần khác, hãy sử dụng phương thức [**addClone**](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/#addClone) do lớp [**SlideCollection**](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidecollection/) cung cấp. Aspose.Slides for Python qua Java cho phép sao chép một slide từ phần đầu tiên và sau đó chèn slide đã sao chép vào phần thứ hai của cùng một bản trình chiếu.

Đoạn mã dưới đây cho bạn thấy cách sao chép một slide và chèn slide đã sao chép vào một phần được chỉ định.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Lưu bản trình chiếu đích ra đĩa
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đảm Bảo Kích Thước Slide Khớp Nhau**

Khi sao chép slide vào một bản trình chiếu khác, hãy chắc chắn rằng bản trình chiếu đích có cùng kích thước slide với bản nguồn. Nếu kích thước slide khác nhau, Aspose.Slides sẽ không tự động thay đổi kích thước các hình dạng đã sao chép – tọa độ và kích thước gốc của chúng sẽ được giữ nguyên, có thể khiến nội dung bị lệch hoặc vượt ra ngoài giới hạn slide.

Bạn có thể đặt kích thước slide của bản trình chiếu đích sao cho khớp với bản nguồn trước khi sao chép master và slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Thực hiện việc này trước khi sao chép master và slide.

## **Câu Hỏi Thường Gặp**

**Ghi chú người thuyết trình và bình luận đánh giá có được sao chép không?**

Có. Trang ghi chú và các bình luận đánh giá được bao gồm trong bản sao. Nếu bạn không muốn chúng, hãy [xóa chúng](/slides/vi/python-java/presentation-notes/) sau khi chèn.

**Biểu đồ và nguồn dữ liệu của chúng được xử lý như thế nào?**

Đối tượng biểu đồ, định dạng và dữ liệu nhúng đều được sao chép. Nếu biểu đồ được liên kết tới nguồn bên ngoài (ví dụ: một sổ làm việc OLE được nhúng), liên kết đó sẽ được giữ lại dưới dạng [đối tượng OLE](/slides/vi/python-java/manage-ole/). Sau khi chuyển giữa các tệp, hãy xác minh tính khả dụng của dữ liệu và hành vi làm mới.

**Tôi có thể kiểm soát vị trí chèn và phần cho bản sao không?**

Có. Bạn có thể chèn bản sao tại một chỉ số slide cụ thể và đặt nó vào một [phần](/slides/vi/python-java/slide-section/) đã chọn. Nếu phần đích không tồn tại, hãy tạo nó trước rồi sau đó di chuyển slide vào đó.