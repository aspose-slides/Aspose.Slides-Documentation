---
title: Quản lý Siêu liên kết Bản trình bày trong Python
linktitle: Quản lý Siêu liên kết
type: docs
weight: 20
url: /vi/python-net/manage-hyperlinks/
keywords:
- thêm URL
- thêm siêu liên kết
- tạo siêu liên kết
- định dạng siêu liên kết
- xóa siêu liên kết
- cập nhật siêu liên kết
- siêu liên kết văn bản
- siêu liên kết slide
- siêu liên kết hình dạng
- siêu liên kết hình ảnh
- siêu liên kết video
- siêu liên kết có thể thay đổi
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Aspose.Slides
description: "Thêm, định dạng, cập nhật và xóa siêu liên kết trong các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Python thông qua .NET, sử dụng các ví dụ Python."
---
## **Giới thiệu**

Liên kết siêu văn bản kết nối nội dung bản trình bày với một trang web hoặc một vị trí trong bản trình bày. Trong PowerPoint, các liên kết siêu văn bản thường phục vụ hai mục đích:

* Mở một trang web từ văn bản, hình dạng hoặc khung phương tiện.
* Điều hướng đến một slide khác, ví dụ, từ mục lục.

Aspose.Slides for Python via .NET cho phép bạn thêm các liên kết này, điều khiển diện mạo và âm thanh của chúng, cập nhật các thuộc tính và xóa chúng. Các ví dụ dưới đây cho thấy cách làm việc với siêu liên kết trên các yếu tố riêng lẻ và cách truy cập siêu liên kết ở mức bản trình bày, slide hoặc khung văn bản.

{{% alert color="info" title="Note" %}}
Bạn cũng có thể chỉnh sửa bản trình bày bằng [trình chỉnh sửa PowerPoint trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Thêm Liên Kết URL**

Bạn có thể gán một URL trang web cho văn bản, hình dạng hoặc khung phương tiện. Yếu tố mà bạn gán siêu liên kết sẽ quyết định khu vực có thể nhấp: một đoạn văn bản liên kết văn bản đã chọn, trong khi một hình dạng hoặc khung liên kết đối tượng slide.

Đối với các bản trình bày chứa siêu liên kết tương đối, xem [Quản lý Cơ sở Siêu liên kết](/slides/vi/python-net/presentation-properties/#manage-the-hyperlink-base) để đọc, thay đổi hoặc xóa cơ sở ở mức tài liệu.

### **Thêm Liên Kết URL vào Văn Bản**

Để liên kết văn bản với một trang web, gán một [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) cho thuộc tính [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) của đoạn văn bản, như dưới đây. Chỉ đoạn văn bản đó sẽ trở thành có thể nhấp.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Thêm Liên Kết URL vào Hình Dạng và Khung Phương Tiện**

Gán một URL cho thuộc tính [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) của hình chữ nhật để làm cho toàn bộ khu vực của nó có thể nhấp. Thuộc tính [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) cung cấp cho người đọc một gợi ý về đích đến khi họ di chuột lên hình chữ nhật. Các thuộc tính tương tự áp dụng cho khung hình ảnh, âm thanh và video.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Sử Dụng Siêu Liên Kết Để Tạo Mục Lục**

Các siêu liên kết nội bộ cho phép người đọc nhảy từ mục lục đến một slide cụ thể. Ví dụ sau sử dụng [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) để liên kết văn bản “Page 2” trên slide đầu tiên tới slide thứ hai.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Định Dạng Siêu Liên Kết**

Bạn có thể thay đổi màu sắc của văn bản có liên kết, phát hoặc dừng âm thanh khi người đọc kích hoạt một liên kết, và đặt tooltip xuất hiện khi di chuột.

### **Màu**

Thuộc tính [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) của [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) xác định liệu siêu liên kết có sử dụng màu siêu liên kết của bản trình bày hay định dạng của đoạn văn bản. Để áp dụng màu văn bản tùy chỉnh, chọn [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) và đặt màu nền cho đoạn. Tính năng này được giới thiệu trong PowerPoint 2019; các phiên bản cũ hơn không áp dụng cài đặt này.

Trong ví dụ này, việc đặt [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) cho liên kết đầu tiên làm cho văn bản của nó hiển thị màu đỏ. Liên kết thứ hai giữ màu siêu liên kết của bản trình bày.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **Âm Thanh**

Một siêu liên kết có thể phát âm thanh khi được kích hoạt hoặc dừng âm thanh đang phát. Sử dụng các thuộc tính sau để cấu hình các hành vi này:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) chỉ định âm thanh liên quan tới siêu liên kết.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) kiểm soát việc kích hoạt siêu liên kết có dừng âm thanh trước đó hay không.

#### **Thêm Âm Thanh Siêu Liên Kết**

Nút trên slide đầu tiên sử dụng [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) để phát âm thanh từ tệp WAV khi người đọc nhấp để tiến tới. Trên slide thứ hai, một nút riêng biệt sử dụng [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) để dừng phát và giữ người đọc ở slide đó.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **Trích Xuất Âm Thanh Siêu Liên Kết**

Ví dụ sau mở bản trình bày đã tạo ở trên và đọc âm thanh siêu liên kết của hình dạng đầu tiên vào bộ nhớ thông qua [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) và [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/).

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **Cài Đặt Tooltip và Tương Tác**

Bạn có thể cập nhật các thuộc tính [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) sau khi gán siêu liên kết cho văn bản hoặc hình dạng:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) đặt văn bản mà người xem có thể hiển thị dưới dạng gợi ý cho liên kết.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) chỉ định khung mục tiêu trong một tập khung HTML cha, khi áp dụng.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) kiểm soát việc kích hoạt liên kết có thêm đích đến vào danh sách các siêu liên kết đã xem hay không.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) kiểm soát việc siêu liên kết được làm nổi bật khi được nhấp.

## **Xóa Siêu Liên Kết Khỏi Bản Trình Bày**

Sử dụng [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) để thu thập các container siêu liên kết, bao gồm các liên kết đoạn văn bản, trước khi thay đổi chúng. Ví dụ sau xóa cả hai loại kích hoạt khỏi slide đầu tiên. Để xóa chỉ một loại, gọi chỉ [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) hoặc [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); xóa hành động nhấp không xóa hành động di chuột.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

Đối với việc xóa không điều kiện, [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) xóa cả hai loại kích hoạt trong phạm vi đã chọn trong một lần gọi. Đối với việc dọn dẹp có chọn lọc và bao phủ các master, layout và notes, xem [Báo Cáo, Làm Sạch và Xác Minh Siêu Liên Kết](#report-sanitize-and-verify-hyperlinks).

### **Xóa Siêu Liên Kết Trước Khi Thay Thế Văn Bản SmartArt**

Khi bạn thay thế một đoạn trong một nút SmartArt hiện có, việc xóa các đoạn văn bản có thể để lại một siêu liên kết cũ vẫn có hiệu lực. Lấy đoạn thông qua [SmartArtNode.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/text_frame/). Trước khi xóa các đoạn, gọi [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) thông qua [hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) trên khung văn bản của hình dạng nút hiển thị đoạn. Điều này xóa mọi siêu liên kết trong khung đó, bao gồm các liên kết trong các đoạn khác.

Trong `SmartArtHyperlink.pptx`, hình dạng thứ ba trên slide đầu tiên là một đồ họa SmartArt. Ví dụ thay thế đoạn đầu tiên của nút thứ tư. Trong bản trình bày này, hình dạng đầu tiên của nút hiển thị đoạn đó.

Sau khi thêm cả hai đoạn, ví dụ đọc định dạng hiệu quả của chúng bằng [get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/). Thuộc tính hiệu quả [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/iportionformateffectivedata/hyperlink_click/) trả về siêu liên kết mới cho đoạn đầu và `None` cho đoạn thứ hai.

```python
import aspose.slides as slides

with slides.Presentation("SmartArtHyperlink.pptx") as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes[2]
    node = smart_art.all_nodes[3]
    paragraph = node.text_frame.paragraphs[0]

    node.shapes[0].text_frame.hyperlink_queries.remove_all_hyperlinks()
    paragraph.portions.clear()

    link = slides.Portion("New reference")
    link.portion_format.hyperlink_click = slides.Hyperlink("https://example.com/new")
    paragraph.portions.add(link)
    text = slides.Portion(" (updated)")
    paragraph.portions.add(text)

    print(link.portion_format.get_effective().hyperlink_click.external_url)  # https://example.com/new
    print(text.portion_format.get_effective().hyperlink_click)  # None
```

## **Xây Dựng Danh Mục Siêu Liên Kết Hoàn Chỉnh**

Trước khi phân phối một bản trình bày, hãy kiểm kê các hành động tương tác cũng như các liên kết web của nó. [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) trả về các đối tượng [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/), không phải danh sách phẳng các chuỗi URL. Kiểm tra cả [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) và [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) trên mỗi container. Chúng là độc lập: cùng một container có thể hiển thị cả hai hành động, vì vậy một báo cáo hoàn chỉnh có thể cần đến hai hàng cho mỗi container.

Việc chỉ quét các siêu liên kết cấp hình dạng có thể bỏ lỡ các liên kết gắn vào các đoạn văn bản. Hãy truy vấn phạm vi thích hợp thay vì vậy, và giữ lại các container được trả về để sau này bạn có thể cập nhật hoặc xóa các hành động của chúng.

### **Truy Vấn Phạm Vi Bản Trình Bày, Slide và Khung Văn Bản**

Lớp [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) có sẵn thông qua [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/) và [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/). Mỗi phạm vi hỗ trợ các truy vấn giống nhau:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) trả về các container có hành động nhấp.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) trả về các container có hành động di chuột.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) trả về các container có một hoặc cả hai hành động.

Ví dụ này gán các hành động nhấp và di chuột cho một hình dạng và văn bản của nó, và một hành động macro cho một nút riêng. Nó so sánh các container trả về bởi [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) với số lượng cho mỗi loại kích hoạt. Một truy vấn khung văn bản chỉ đếm các liên kết trong văn bản. Các hành động riêng của hình dạng bao quanh xuất hiện trong các truy vấn slide và bản trình bày.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

Đối với ví dụ này, các truy vấn bản trình bày và slide mỗi đều báo cáo ba container nhấp, hai container di chuột, và ba container có bất kỳ hành động nào. Truy vấn khung văn bản báo cáo một container trong mỗi loại.

### **Phân Loại Hành Động và Đích Đến**

Sử dụng [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) để diễn giải một hành động trước khi diễn giải đích đến của nó. Các giá trị [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) bao phủ hơn chỉ điều hướng web:

| Giá trị | Ý nghĩa cho cuộc kiểm toán |
| --- | --- |
| `HYPERLINK` | Siêu liên kết bên ngoài; kiểm tra URL và giao thức của nó. |
| `JUMP_SPECIFIC_SLIDE` | Điều hướng nội bộ tới một slide cụ thể. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Điều hướng trình chiếu tích hợp, được giải quyết trong ngữ cảnh trình chiếu. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Kết thúc buổi chiếu hiện tại hoặc bắt đầu một buổi chiếu tùy chỉnh. |
| `START_MACRO` | Thực thi một macro. |
| `START_PROGRAM` | Khởi chạy một chương trình. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Mở một tệp hoặc bản trình bày khác; xem xét riêng biệt so với URL web. |
| `START_STOP_MEDIA` | Bắt đầu hoặc dừng phát phương tiện. |
| `NO_ACTION`, `UNKNOWN` | Không có hành động điều hướng, hoặc một hành động không xác định cần xem xét. |

Đọc các đích đến bên ngoài từ [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) và các đích đến nội bộ cụ thể từ [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/). Các hành động nội bộ và các lệnh tích hợp có thể không có URL bên ngoài; một URL trống không có nghĩa là container không có hành động. Bảo toàn [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) khi nó khác với URL đã chuẩn hoá, và bao gồm [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) khi có.

### **Báo Cáo, Làm Sạch và Xác Minh Siêu Liên Kết**

Ví dụ này mở bản trình bày từ ví dụ trước và ghi một bản ghi JSON cho mỗi hành động. Nó sử dụng [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) để thu thập các container trên các slide thường, master, layout và notes, bao gồm cả master notes và handout khi có. Nó truy vấn mỗi phạm vi một lần để tránh xử lý trùng lặp, áp dụng chính sách mô tả bên dưới, và mở lại bản trình bày đã lưu để kiểm tra cả hành động nhấp và di chuột.

Bản báo cáo ghi chỉ mục slide bắt đầu từ 1 và [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) khi có. Bộ thu thập giữ lại slide sở hữu và phạm vi cùng mỗi container trả về. Master, layout và notes không có chỉ mục slide thường và được xác định bằng phạm vi của chúng. Các container hình dạng và container định dạng đoạn văn bản được gắn nhãn riêng; các loại container khác giữ tên loại thời gian chạy. Mỗi container nhận một ID báo cáo cục bộ để hai hành động của nó có thể được liên kết.

Chính sách ứng dụng hạn chế này chỉ cho phép các URL HTTPS tuyệt đối và các đích slide nội bộ hợp lệ. Nó loại bỏ macro, chương trình, hành động tệp, các hành động trình chiếu khác, hành động không xác định và các giao thức URL khác. Những loại từ chối này là quyết định chính sách, không phải một quyết định an toàn của Aspose.Slides. HTTPS một mình không tạo nên niềm tin: hãy thêm danh sách cho phép máy chủ và các kiểm tra khác cho ứng dụng của bạn. Cả URL bên ngoài nguyên bản và đã chuẩn hoá đều được kiểm tra. Ví dụ kiểm toán siêu dữ liệu mà không theo liên kết hoặc chạy hành động.

Để khắc phục, [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) của container hỗ trợ [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) và [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Ở đây, các liên kết nhấp bên ngoài bị cấm được thay thế bằng một trang đích HTTPS cố định; các nhấp bị cấm khác và các hành động di chuột bị cấm được xóa riêng biệt. Đặt `replace_external_clicks` thành `False` để xóa tất cả các vi phạm chính sách. Chọn một trang thay thế do ứng dụng sở hữu trước khi triển khai.

Cờ xuất báo cáo sử dụng chính sách xem lại PDF thận trọng: đánh dấu các hành động di chuột và bất kỳ thứ gì khác ngoài liên kết bên ngoài hoặc chuyển slide cụ thể là có khả năng không được hỗ trợ. Đây là gợi ý xem lại, không phải một bài kiểm tra khả năng hay bảo đảm rằng các liên kết không được đánh dấu sẽ tồn tại khi xuất. Các xuất PDF [PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/) và HTML [HTML](/slides/vi/python-net/convert-powerpoint-to-html/) được hỗ trợ có thể bảo tồn siêu liên kết, tùy thuộc vào hành động, tùy chọn xuất và trình xem. Các hình ảnh raster [images](/slides/vi/python-net/convert-powerpoint-to-png/) và video [video](/slides/vi/python-net/convert-powerpoint-to-video/) không thể bảo tồn siêu liên kết tương tác; đánh dấu mọi hành động khi kiểm toán cho các đầu ra đó.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Query each slide scope once, retaining its owner with each container.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

Với đầu vào được tạo ở trên, báo cáo chứa năm hàng hành động. Liên kết di chuột của tệp và macro click bị xóa, trong khi các liên kết HTTPS và điều hướng slide nội bộ vẫn còn. Kiểm tra in ra không có hành động bị cấm. Một đầu vào chứa URL click bên ngoài bị cấm cũng thực hiện nhánh thay thế. Một container có click cho phép và di chuột bị cấm giữ lại hành động click của nó.

Việc dọn dẹp có chọn lọc này khác với [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), cái mà xóa cả hai loại kích hoạt trên toàn bộ phạm vi đã chọn bất kể chính sách. Kiểm tra ở đây chỉ kiểm tra các hành động siêu liên kết; nó không xóa các dự án VBA nhúng, đối tượng OLE hoặc nội dung hoạt động khác, và không xác thực một tệp PDF hoặc HTML đã xuất.

## **Câu Hỏi Thường Gặp**

**Làm thế nào để tôi liên kết đến một phần hoặc slide đầu tiên của nó?**

Các phần trong PowerPoint nhóm các slide lại, nhưng một siêu liên kết nội bộ nhắm tới một slide cá nhân. Để tạo điều hướng tới một phần, hãy liên kết tới slide đầu tiên trong phần đó.

**Tôi có thể gắn một siêu liên kết vào các yếu tố slide chủ để nó hoạt động trên mọi slide không?**

Có. Các yếu tố slide chủ và layout hỗ trợ siêu liên kết. Các liên kết trên các yếu tố này có sẵn trong khi chạy trình chiếu trên các slide sử dụng master hoặc layout tương ứng.

**Liên kết siêu văn bản có được bảo tồn khi xuất ra PDF, HTML, hình ảnh hoặc video không?**

Các xuất PDF và HTML được hỗ trợ có thể bảo tồn siêu liên kết; hình ảnh raster và video không thể. Xem các lưu ý xuất trong [Báo Cáo, Làm Sạch và Xác Minh Siêu Liên Kết](#report-sanitize-and-verify-hyperlinks).