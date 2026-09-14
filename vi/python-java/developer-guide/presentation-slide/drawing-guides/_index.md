---
title: Quản lý Đường Hướng Dẫn Vẽ trong Bản Trình Chiếu bằng Python
linktitle: Đường Hướng Dẫn Vẽ
type: docs
weight: 85
url: /vi/python-java/drawing-guides/
keywords:
- đường hướng dẫn
- đường ngang
- đường dọc
- đường căn chỉnh
- chế độ xem slide
- slide master
- slide bố cục
- master ghi chú
- master phát tay
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Thêm, truy cập và xóa các đường hướng dẫn ngang và dọc trong bản trình chiếu PowerPoint bằng Aspose.Slides for Python via Java."
---
## **Tổng quan**

Các đường hướng dẫn vẽ là các đường ngang và dọc có thể điều chỉnh, giúp người dùng căn chỉnh các hình dạng một cách nhất quán khi chỉnh sửa bản trình chiếu trong PowerPoint. Chúng đặc biệt hữu ích khi một ứng dụng tạo bản trình chiếu sẽ được tinh chỉnh thủ công sau này: ứng dụng có thể lưu các công cụ căn chỉnh giống như những gì tác giả nên tuân theo khi thêm hoặc di chuyển nội dung.

Các đường hướng dẫn vẽ là công cụ hỗ trợ chỉnh sửa, không phải là nội dung của slide. Chúng không xuất hiện trong chế độ trình chiếu hoặc đầu ra đã render. Aspose.Slides for Python via Java cung cấp chúng thông qua lớp [DrawingGuidesCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/drawingguidescollection/). Một đường hướng dẫn được biểu diễn bằng [DrawingGuide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/drawingguide/) và có hướng, vị trí và màu sắc.

Vị trí được đo bằng điểm từ góc trên‑trái của slide hoặc master tương ứng. Đường dọc sử dụng tọa độ ngang, thường nằm trong khoảng từ 0 đến chiều rộng slide. Đường ngang sử dụng tọa độ dọc, thường nằm trong khoảng từ 0 đến chiều cao slide.

## **Thêm Đường Hướng Dẫn vào Chế Độ Xem Slide**

Sử dụng [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) để quản lý các đường hướng dẫn hiển thị khi chỉnh sửa các slide bình thường. Gọi [DrawingGuidesCollection.add](https://reference.aspose.com/slides/vi/python-java/aspose.slides/drawingguidescollection/#add) với một giá trị [Orientation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/orientation/) và một vị trí tính bằng điểm.

Ví dụ sau thêm một đường dọc ở phía bên phải của trung tâm slide và một đường ngang phía dưới nó:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Truy Cập Các Đường Hướng Dẫn Vẽ**

Các phương thức [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/vi/python-java/aspose.slides/drawingguidescollection/#getCount) và [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/vi/python-java/aspose.slides/drawingguidescollection/#get_Item) cung cấp khả năng truy cập các đường hiện có. Các phương thức [DrawingGuide.getOrientation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/vi/python-java/aspose.slides/drawingguide/#getPosition) và [DrawingGuide.getColor](https://reference.aspose.com/slides/vi/python-java/aspose.slides/drawingguide/#getColor) trả về các giá trị có thể thay đổi thông qua các phương thức setter tương ứng.

Ví dụ sau đọc các đường hướng dẫn trong chế độ xem slide từ bản trình chiếu được tạo ở trên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **Thêm Đường Hướng Dẫn vào Master và Layout Slides**

Một slide master và mỗi layout slide của nó có thể có bộ sưu tập đường hướng dẫn riêng. Sử dụng [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterslide/#getDrawingGuides) cho slide master và [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/layoutslide/#getDrawingGuides) cho layout slide.

Ví dụ sau thêm một đường dọc vào slide master đầu tiên và một đường ngang vào layout slide đầu tiên:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thêm Đường Hướng Dẫn vào Notes và Handout Masters**

Notes master và handout master cũng hỗ trợ đường hướng dẫn. Sử dụng [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masternotesslide/#getDrawingGuides) và [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/vi/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) để truy cập các bộ sưu tập của chúng. Nếu một bản trình chiếu không chứa một trong các master này, `MasterNotesSlideManager.setDefaultMasterNotesSlide` hoặc `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` sẽ tạo master mặc định và trả về nó.

Ví dụ sau thêm một đường ngang vào notes master và một đường dọc vào handout master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Xóa Các Đường Hướng Dẫn Vẽ**

Gọi [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/vi/python-java/aspose.slides/drawingguidescollection/#clear) để xóa mọi đường trong một bộ sưu tập nhất định. Việc xóa một bộ sưu tập không ảnh hưởng đến các đường được lưu trong phạm vi khác.

Ví dụ sau xóa các đường hướng dẫn trong chế độ xem slide và tất cả các đường trên slide master, layout slide, notes master và handout master mà không tạo các master còn thiếu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu Hỏi Thường Gặp**

**Các đường hướng dẫn vẽ có xuất hiện trong chế độ trình chiếu hoặc hình ảnh xuất khẩu không?**

Không. Các đường hướng dẫn vẽ là công cụ hỗ trợ căn chỉnh khi chỉnh sửa và không được render như nội dung bản trình chiếu.

**Có thể thêm một đường hướng dẫn trực tiếp vào một slide bình thường riêng lẻ không?**

Các đường hướng dẫn cho slide bình thường được lưu trong thuộc tính chế độ xem slide của bản trình chiếu. Các bộ sưu tập đường riêng biệt cũng có sẵn cho slide master, layout slide, notes master và handout master.

**Đơn vị nào được sử dụng cho vị trí của các đường hướng dẫn?**

Vị trí được chỉ định bằng điểm, trong đó 72 điểm bằng một inch. Vị trí dọc được đo từ cạnh trái, và vị trí ngang được đo từ cạnh trên.

**Việc xóa các đường hướng dẫn vẽ có xóa bỏ hình dạng hoặc thay đổi nội dung slide không?**

Không. Phương thức [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/vi/python-java/aspose.slides/drawingguidescollection/#clear) chỉ xóa các đường trong bộ sưu tập đã chọn. Các hình dạng và các nội dung slide khác vẫn không bị thay đổi.