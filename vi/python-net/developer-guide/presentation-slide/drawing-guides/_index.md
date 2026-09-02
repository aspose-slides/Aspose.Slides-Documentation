---
title: Quản lý Hướng Dẫn Vẽ trong Bản Trình Bày bằng Python
linktitle: Hướng Dẫn Vẽ
type: docs
weight: 85
url: /vi/python-net/drawing-guides/
keywords:
- hướng dẫn vẽ
- hướng dẫn ngang
- hướng dẫn dọc
- hướng dẫn căn chỉnh
- chế độ xem slide
- slide master
- slide layout
- master ghi chú
- master handout
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Thêm, truy cập và xóa các hướng dẫn vẽ ngang và dọc trong bản trình bày PowerPoint bằng Aspose.Slides cho Python thông qua .NET."
---
## **Tổng quan**

Hướng dẫn vẽ là các đường ngang và dọc có thể điều chỉnh, giúp người dùng căn chỉnh các hình dạng một cách nhất quán khi chỉnh sửa bản trình bày trong PowerPoint. Chúng đặc biệt hữu ích khi một ứng dụng tạo ra bản trình bày sẽ được tinh chỉnh thủ công sau này: ứng dụng có thể lưu các công cụ căn chỉnh mà tác giả nên tuân theo khi thêm hoặc di chuyển nội dung.

Hướng dẫn vẽ là công cụ hỗ trợ chỉnh sửa, không phải nội dung slide. Chúng không xuất hiện trong trình chiếu hoặc kết quả render. Aspose.Slides cho Python thông qua .NET cung cấp chúng qua giao diện [IDrawingGuidesCollection](https://reference.aspose.com/slides/vi/python-net/aspose.slides/idrawingguidescollection/). Một hướng dẫn được biểu diễn bằng [IDrawingGuide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/idrawingguide/) và có hướng, vị trí và màu sắc.

Vị trí được đo bằng điểm (points) từ góc trên‑trái của slide hoặc master liên quan. Một hướng dẫn dọc sử dụng tọa độ ngang, thường nằm trong khoảng từ 0 đến độ rộng của slide. Một hướng dẫn ngang sử dụng tọa độ dọc, thường nằm trong khoảng từ 0 đến độ cao của slide.

## **Thêm Hướng Dẫn Vẽ vào Chế Độ Xem Slide**

Sử dụng [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) để quản lý các hướng dẫn hiển thị khi chỉnh sửa các slide bình thường. Gọi [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/vi/python-net/aspose.slides/idrawingguidescollection/add/) với một giá trị [Orientation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/orientation/) và một vị trí tính bằng điểm.

Ví dụ sau thêm một hướng dẫn dọc ở phía bên phải của trung tâm slide và một hướng dẫn ngang bên dưới nó:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy Cập Hướng Dẫn Vẽ**

Thuộc tính và chỉ mục [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/vi/python-net/aspose.slides/idrawingguidescollection/count/) cung cấp khả năng truy cập các hướng dẫn hiện có. Các thuộc tính [IDrawingGuide.orientation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/vi/python-net/aspose.slides/idrawingguide/position/) và [IDrawingGuide.color](https://reference.aspose.com/slides/vi/python-net/aspose.slides/idrawingguide/color/) có thể được đọc hoặc thay đổi.

Ví dụ dưới đây đọc các hướng dẫn chế độ xem slide từ bản trình bày đã tạo ở trên:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Thêm Hướng Dẫn Vẽ vào Slide Master và Layout**

Một slide master và mỗi slide layout của nó có thể có bộ sưu tập hướng dẫn vẽ riêng. Sử dụng [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imasterslide/drawing_guides/) cho slide master và [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ilayoutslide/drawing_guides/) cho slide layout.

Ví dụ sau thêm một hướng dẫn dọc vào slide master đầu tiên và một hướng dẫn ngang vào slide layout đầu tiên:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Hướng Dẫn Vẽ vào Master Ghi chú và Handout**

Master ghi chú và master handout cũng hỗ trợ hướng dẫn vẽ. Sử dụng [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imasternotesslide/drawing_guides/) và [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) để truy cập các bộ sưu tập của chúng. Nếu một bản trình bày không chứa một trong các master này, [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) hoặc [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/vi/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) sẽ tạo master mặc định và trả về nó.

Ví dụ sau thêm một hướng dẫn ngang vào master ghi chú và một hướng dẫn dọc vào master handout:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Xóa Hướng Dẫn Vẽ**

Gọi [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/vi/python-net/aspose.slides/idrawingguidescollection/clear/) để xóa mọi hướng dẫn khỏi một bộ sưu tập cụ thể. Việc xóa một bộ sưu tập không ảnh hưởng đến các hướng dẫn được lưu trong phạm vi khác.

Ví dụ sau xóa các hướng dẫn chế độ xem slide và tất cả các hướng dẫn trên slide master, layout slide, master ghi chú và master handout mà không tạo các master còn thiếu:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Hướng dẫn vẽ có xuất hiện trong trình chiếu hoặc hình ảnh đã xuất không?**

Không. Hướng dẫn vẽ là công cụ hỗ trợ căn chỉnh khi chỉnh sửa và không được hiển thị như nội dung của bản trình bày.

**Có thể thêm một hướng dẫn vẽ trực tiếp vào một slide bình thường riêng lẻ không?**

Các hướng dẫn chỉnh sửa cho slide bình thường được lưu trong thuộc tính chế độ xem slide của bản trình bày. Các bộ sưu tập hướng dẫn riêng biệt có sẵn cho slide master, layout slide, master ghi chú và master handout.

**Đơn vị nào được sử dụng cho vị trí của hướng dẫn?**

Vị trí được chỉ định bằng điểm (points), trong đó 72 điểm tương đương một inch. Vị trí dọc được đo từ cạnh trái, và vị trí ngang được đo từ cạnh trên.

**Việc xóa các hướng dẫn vẽ có làm mất hình dạng hoặc thay đổi nội dung slide không?**

Không. Phương thức `clear` chỉ xóa các hướng dẫn trong bộ sưu tập đã chọn. Các hình dạng và nội dung slide khác vẫn giữ nguyên.