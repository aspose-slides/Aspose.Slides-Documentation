---
title: Quản lý các nút hình SmartArt trong bản thuyết trình bằng Python
linktitle: Nút hình SmartArt
type: docs
weight: 30
url: /vi/python-net/manage-smartart-shape-node/
keywords:
- nút SmartArt
- nút con
- thêm nút
- vị trí nút
- truy cập nút
- xóa nút
- vị trí tùy chỉnh
- nút trợ lý
- định dạng tô đầy
- render nút
- PowerPoint
- bản thuyết trình
- Python
- Aspose.Slides
description: "Quản lý các nút hình SmartArt trong PPT, PPTX và ODP với Aspose.Slides for Python via .NET. Nhận mẫu mã rõ ràng và mẹo để tối ưu hoá bản thuyết trình của bạn."
---
## **Tổng quan**

Đồ họa SmartArt trong các bản thuyết trình PowerPoint được tổ chức thông qua các nút chứa văn bản và xác định cấu trúc của sơ đồ. Aspose.Slides cho phép bạn làm việc với các nút SmartArt này một cách lập trình: thêm nút mới và nút con, chèn nút con ở vị trí cụ thể, truy cập các nút hiện có và đọc văn bản, cấp độ và vị trí của chúng.

Bài viết này giải thích cách quản lý các nút hình SmartArt. Nó trình bày cách xóa nút, làm việc với các nút con theo chỉ mục hoặc vị trí, chuyển đổi một nút trợ lý thành nút thường, điều chỉnh vị trí, kích thước và góc quay của các hình nút SmartArt, đặt định dạng tô đầy cho nút, và tạo ảnh thu nhỏ cho một nút con của SmartArt.

## **Thêm nút SmartArt**
Aspose.Slides for Python via .NET đã cung cấp API đơn giản nhất để quản lý các hình SmartArt một cách dễ dàng. Mã mẫu sau sẽ giúp bạn thêm nút và nút con vào trong hình SmartArt.

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) và tải bản thuyết trình có hình SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
- Duyệt qua mọi shape bên trong slide đầu tiên.
- Kiểm tra xem shape có phải là loại SmartArt không và ép kiểu shape đã chọn sang SmartArt nếu nó là SmartArt.
- Thêm một Node mới vào NodeCollection của shape SmartArt và đặt văn bản trong TextFrame.
- Tiếp theo, thêm một Child Node vào Node SmartArt vừa thêm và đặt văn bản trong TextFrame.
- Lưu bản thuyết trình.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Tải bản thuyết trình mong muốn
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Duyệt qua mọi shape trong slide đầu tiên
    for shape in pres.slides[0].shapes:

        # Kiểm tra xem shape có phải là loại SmartArt không
        if type(shape) is art.SmartArt:
            # Thêm một Node SmartArt mới
            node1 = shape.all_nodes.add_node()
            # Thêm văn bản
            node1.text_frame.text = "Test"

            # Thêm node con mới vào node cha. Nó sẽ được thêm vào cuối bộ sưu tập
            new_node = node1.child_nodes.add_node()

            # Thêm văn bản
            new_node.text_frame.text = "New Node Added"

    # Lưu bản thuyết trình
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm nút SmartArt tại vị trí cụ thể**
Trong mẫu mã dưới đây, chúng tôi giải thích cách thêm các nút con thuộc về các nút tương ứng của hình SmartArt tại một vị trí cụ thể.

- Tạo một thể hiện của lớp `Presentation`.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
- Thêm một shape SmartArt kiểu StackedList vào slide đã truy cập.
- Truy cập nút đầu tiên trong shape SmartArt vừa thêm.
- Tiếp theo, thêm Child Node cho Node đã chọn tại vị trí 2 và đặt văn bản cho nó.
- Lưu bản thuyết trình.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Tạo một thể hiện của bản thuyết trình
with slides.Presentation() as pres:
    # Truy cập slide của bản thuyết trình
    slide = pres.slides[0]

    # Thêm Smart Art IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Truy cập node SmartArt tại chỉ mục 0
    node = smart.all_nodes[0]

    # Thêm node con mới tại vị trí 2 trong node cha
    chNode = node.child_nodes.add_node_by_position(2)

    # Thêm văn bản
    chNode.text_frame.text = "Sample text Added"

    # Lưu bản thuyết trình
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy cập nút SmartArt**
Mã mẫu sau sẽ giúp bạn truy cập các nút bên trong shape SmartArt. Lưu ý rằng bạn không thể thay đổi LayoutType của SmartArt vì nó chỉ đọc được và chỉ được đặt khi shape SmartArt được thêm vào.

- Tạo một thể hiện của lớp `Presentation` và tải bản thuyết trình có shape SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
- Duyệt qua mọi shape bên trong slide đầu tiên.
- Kiểm tra xem shape có phải là loại SmartArt không và ép kiểu shape đã chọn sang SmartArt nếu nó là SmartArt.
- Duyệt qua tất cả các Node bên trong shape SmartArt.
- Truy cập và hiển thị thông tin như vị trí Node, cấp độ và Text.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Tải bản thuyết trình mong muốn
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Duyệt qua mọi shape trong slide đầu tiên
    for shape in pres.slides[0].shapes:
        # Kiểm tra xem shape có phải là loại SmartArt không
        if type(shape) is art.SmartArt:
            # Duyệt qua tất cả các node trong SmartArt
            for i in range(len(shape.all_nodes)):
                # Truy cập node SmartArt tại chỉ mục i
                node = shape.all_nodes[i]

                # In ra các tham số của node SmartArt
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```

## **Truy cập nút con SmartArt**
Mã mẫu sau sẽ giúp bạn truy cập các nút con thuộc về các nút tương ứng của shape SmartArt.

- Tạo một thể hiện của lớp PresentationEx và tải bản thuyết trình có shape SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
- Duyệt qua mọi shape bên trong slide đầu tiên.
- Kiểm tra xem shape có phải là loại SmartArt không và ép kiểu shape đã chọn sang SmartArtEx nếu nó là SmartArt.
- Duyệt qua tất cả các Node bên trong shape SmartArt.
- Đối với mỗi Node shape SmartArt đã chọn, duyệt qua tất cả các Child Node bên trong nút cụ thể đó.
- Truy cập và hiển thị thông tin như vị trí Child Node, cấp độ và Text.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Tải bản thuyết trình mong muốn
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Duyệt qua mọi shape trong slide đầu tiên
    for shape in pres.slides[0].shapes:
        # Kiểm tra xem shape có phải là loại SmartArt không
        if type(shape) is art.SmartArt:
            # Duyệt qua tất cả các node trong SmartArt
            for node0 in shape.all_nodes:
                # Duyệt qua các node con
                for j in range(len(node0.child_nodes)):
                    # Truy cập node con trong node SmartArt
                    node = node0.child_nodes[j]

                    # In ra các tham số của node con SmartArt
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))
```

## **Truy cập nút con SmartArt tại vị trí cụ thể**
Trong ví dụ này, chúng ta sẽ học cách truy cập các nút con ở một vị trí cụ thể thuộc về các nút tương ứng của shape SmartArt.

- Tạo một thể hiện của lớp `Presentation`.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
- Thêm một shape SmartArt kiểu StackedList.
- Truy cập shape SmartArt vừa thêm.
- Truy cập nút có chỉ mục 0 của shape SmartArt đã truy cập.
- Tiếp theo, truy cập Child Node tại vị trí 1 của nút SmartArt đã truy cập bằng phương thức GetNodeByPosition().
- Truy cập và hiển thị thông tin như vị trí Child Node, cấp độ và Text.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Tạo một thể hiện của bản thuyết trình
with slides.Presentation() as pres:
    # Truy cập slide đầu tiên
    slide = pres.slides[0]
    # Thêm shape SmartArt vào slide đầu tiên
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Truy cập node SmartArt tại chỉ mục 0
    node = smart.all_nodes[0]
    # Truy cập node con tại vị trí 1 trong node cha
    position = 1
    chNode = node.child_nodes[position] 
    # In ra các tham số của node con SmartArt
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))
```

## **Xóa nút SmartArt**
Trong ví dụ này, chúng ta sẽ học cách xóa các nút bên trong shape SmartArt.

- Tạo một thể hiện của lớp `Presentation` và tải bản thuyết trình có shape SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
- Duyệt qua mọi shape bên trong slide đầu tiên.
- Kiểm tra xem shape có phải là loại SmartArt không và ép kiểu shape đã chọn sang SmartArt nếu nó là SmartArt.
- Kiểm tra xem SmartArt có nhiều hơn 0 node không.
- Chọn node SmartArt cần xóa.
- Tiếp theo, xóa node đã chọn bằng phương thức RemoveNode() * Lưu bản thuyết trình.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Tải bản thuyết trình mong muốn
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Duyệt qua mọi shape trong slide đầu tiên
    for shape in pres.slides[0].shapes:
        # Kiểm tra xem shape có phải là loại SmartArt không
        if type(shape) is art.SmartArt:
            # Ép kiểu shape sang SmartArtEx
            if len(shape.all_nodes) > 0:
                # Truy cập node SmartArt tại chỉ mục 0
                node = shape.all_nodes[0]

                # Xóa node đã chọn
                shape.all_nodes.remove_node(node)

    # Lưu bản thuyết trình
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Xóa nút SmartArt tại vị trí cụ thể**
Trong ví dụ này, chúng ta sẽ học cách xóa các nút bên trong shape SmartArt tại một vị trí cụ thể.

- Tạo một thể hiện của lớp `Presentation` và tải bản thuyết trình có shape SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
- Duyệt qua mọi shape bên trong slide đầu tiên.
- Kiểm tra xem shape có phải là loại SmartArt không và ép kiểu shape đã chọn sang SmartArt nếu nó là SmartArt.
- Chọn node shape SmartArt có chỉ mục 0.
- Tiếp theo, kiểm tra xem node SmartArt đã chọn có nhiều hơn 2 child node không.
- Sau đó, xóa node ở vị trí 1 bằng phương thức RemoveNodeByPosition().
- Lưu bản thuyết trình.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Tải bản thuyết trình mong muốn
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Duyệt qua mọi shape trong slide đầu tiên
    for shape in pres.slides[0].shapes:
        # Kiểm tra xem shape có phải là loại SmartArt không
        if type(shape) is art.SmartArt:
            # Ép kiểu shape sang SmartArt
            if len(shape.all_nodes) > 0:
                # Truy cập node SmartArt tại chỉ mục 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Xóa node con ở vị trí 1
                    node.child_nodes.remove_node(1)

    # Lưu bản thuyết trình
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt vị trí tùy chỉnh cho Child Node trong SmartArt**
Bây giờ Aspose.Slides for Python via .NET hỗ trợ việc đặt các thuộc tính X và Y cho SmartArtShape. Đoạn mã dưới đây cho thấy cách đặt vị trí, kích thước và góc quay tùy chỉnh cho SmartArtShape; cũng lưu ý rằng việc thêm nút mới sẽ gây tính lại vị trí và kích thước của tất cả các nút.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Tải bản thuyết trình mong muốn
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# Di chuyển shape SmartArt tới vị trí mới
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# Thay đổi độ rộng của shape SmartArt
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# Thay đổi chiều cao của shape SmartArt
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# Thay đổi góc quay của shape SmartArt
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```

## **Kiểm tra nút trợ lý**
Trong mã mẫu dưới đây, chúng ta sẽ tìm hiểu cách xác định các Assistant Node trong bộ sưu tập nút SmartArt và thay đổi chúng.

- Tạo một thể hiện của lớp PresentationEx và tải bản thuyết trình có shape SmartArt.
- Lấy tham chiếu của slide thứ hai bằng cách sử dụng Index của nó.
- Duyệt qua mọi shape bên trong slide đầu tiên.
- Kiểm tra xem shape có phải là loại SmartArt không và ép kiểu shape đã chọn sang SmartArtEx nếu nó là SmartArt.
- Duyệt qua tất cả các node bên trong shape SmartArt và kiểm tra xem chúng có phải là Assistant Node không.
- Thay đổi trạng thái của Assistant Node thành node thường.
- Lưu bản thuyết trình.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Tạo một thể hiện của bản thuyết trình
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Duyệt qua mọi shape trong slide đầu tiên
    for shape in pres.slides[0].shapes:
        # Kiểm tra xem shape có phải là loại SmartArt không
        if type(shape) is art.SmartArt:
            # Duyệt qua tất cả các node của shape SmartArt
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Kiểm tra xem node có phải là node trợ lý không
                if node.is_assistant:
                    # Đặt node trợ lý thành false và chuyển nó thành node thường
                    node.is_assistant = False
    # Lưu bản thuyết trình
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt định dạng tô đầy cho Node**
Aspose.Slides for Python via .NET cho phép thêm các shape SmartArt tùy chỉnh và đặt định dạng tô đầy cho chúng. Bài viết này giải thích cách tạo và truy cập các shape SmartArt và đặt định dạng tô đầy cho các node bằng Aspose.Slides for Python via .NET.

Vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp `Presentation`.
- Lấy tham chiếu của một slide bằng cách sử dụng index của nó.
- Thêm một shape SmartArt bằng cách đặt LayoutType.
- Đặt FillFormat cho các node của shape SmartArt.
- Ghi bản thuyết trình đã sửa đổi dưới dạng tệp PPTX.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Truy cập slide
    slide = presentation.slides[0]

    # Thêm shape SmartArt và các node
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Đặt màu tô cho node
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Lưu bản thuyết trình
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tạo ảnh thu nhỏ cho Child Node của SmartArt**
Các nhà phát triển có thể tạo ảnh thu nhỏ cho Child Node của SmartArt bằng cách thực hiện các bước sau:

1. Tạo một thể hiện của lớp `Presentation` đại diện cho tệp PPTX.
2. Thêm SmartArt.
3. Lấy tham chiếu của một node bằng cách sử dụng Index của nó.
4. Lấy ảnh thu nhỏ.
5. Lưu ảnh thu nhỏ ở bất kỳ định dạng hình ảnh mong muốn nào.

Ví dụ dưới đây tạo ảnh thu nhỏ cho Child Node của SmartArt

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Tạo một thể hiện của lớp Presentation đại diện cho tệp PPTX
with slides.Presentation() as presentation: 
    # Thêm SmartArt
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Lấy tham chiếu của một node bằng cách sử dụng Index của nó
    node = smart.nodes[1]

    # Lấy ảnh thu nhỏ
    with node.shapes[0].get_image() as bmp:
        # Lưu ảnh thu nhỏ
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **FAQ**

**SmartArt có hỗ trợ hoạt ảnh không?**

Có. SmartArt được xem như một shape thông thường, vì vậy bạn có thể [apply standard animations](/slides/vi/python-net/shape-animation/) (entrance, exit, emphasis, motion paths) và điều chỉnh thời gian. Bạn cũng có thể tạo hoạt ảnh cho các shape bên trong nút SmartArt khi cần.

**Làm sao tôi có thể xác định một SmartArt cụ thể trên slide nếu không biết ID nội bộ?**

Gán và tìm kiếm bằng [alternative text](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartart/alternative_text/). Đặt AltText đặc trưng cho SmartArt giúp bạn tìm nó bằng chương trình mà không phụ thuộc vào các định danh nội bộ.

**Khi chuyển đổi bản thuyết trình sang PDF, hình dạng SmartArt có được giữ nguyên không?**

Có. Aspose.Slides render SmartArt với độ chính xác hình ảnh cao trong quá trình [PDF export](/slides/vi/python-net/convert-powerpoint-to-pdf/), bảo tồn bố cục, màu sắc và hiệu ứng.

**Tôi có thể trích xuất hình ảnh toàn bộ SmartArt (để xem trước hoặc báo cáo) không?**

Có. Bạn có thể render một shape SmartArt sang [raster formats](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartart/get_image/) hoặc sang [SVG](https://reference.aspose.com/slides/vi/python-net/aspose.slides.smartart/smartart/write_as_svg/) để xuất dạng vector mở rộng, thích hợp cho ảnh thu nhỏ, báo cáo hoặc sử dụng trên web.