---
title: Quản lý các nút hình dạng SmartArt trong bản trình chiếu bằng C++
linktitle: Nút Hình dạng SmartArt
type: docs
weight: 30
url: /vi/cpp/manage-smartart-shape-node/
keywords:
- Nút SmartArt
- Nút con
- Thêm nút
- Vị trí nút
- Truy cập nút
- Xóa nút
- Vị trí tùy chỉnh
- Nút trợ lý
- Định dạng tô màu
- Kết xuất nút
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Quản lý các nút hình dạng SmartArt trong PPT và PPTX với Aspose.Slides cho C++. Nhận các mẫu mã rõ ràng và mẹo để tối ưu hoá bản trình chiếu của bạn."
---
## **Tổng quan**

Đồ họa SmartArt trong các bản trình chiếu PowerPoint được tổ chức thông qua các nút chứa văn bản và xác định cấu trúc của sơ đồ. Aspose.Slides cho phép bạn làm việc với các nút SmartArt này một cách lập trình: thêm nút và nút con mới, chèn nút con vào vị trí cụ thể, truy cập các nút hiện có và đọc văn bản, cấp độ và vị trí của chúng.

Bài viết này giải thích cách quản lý các nút hình dạng SmartArt. Nó cho thấy cách xóa nút, làm việc với nút con theo chỉ mục hoặc vị trí, chuyển một nút trợ lý thành nút bình thường, điều chỉnh vị trí, kích thước và góc quay của các hình dạng nút SmartArt, đặt định dạng tô màu cho nút và tạo ảnh thu nhỏ cho một nút con SmartArt.

## **Thêm một nút SmartArt**
Aspose.Slides for C++ đã cung cấp API đơn giản nhất để quản lý các hình dạng SmartArt một cách dễ dàng. Mã mẫu dưới đây sẽ giúp thêm nút và nút con vào trong hình dạng SmartArt.

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và tải bản trình chiếu có hình dạng SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
- Duyệt qua mọi hình dạng trong slide đầu tiên.
- Kiểm tra nếu hình dạng là loại SmartArt và ép kiểu hình dạng đã chọn sang SmartArt nếu nó là SmartArt.
- Thêm một Node mới vào NodeCollection của hình dạng SmartArt và đặt văn bản trong TextFrame.
- Bây giờ, Thêm một Child Node vào Node SmartArt vừa được thêm và đặt văn bản trong TextFrame.
- Lưu bản trình chiếu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **Thêm một nút SmartArt tại vị trí cụ thể**
Trong mã mẫu dưới đây, chúng tôi giải thích cách thêm các nút con thuộc về các nút tương ứng của hình dạng SmartArt tại vị trí cụ thể.

- Tạo một thể hiện của lớp `Presentation`.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
- Thêm một hình dạng SmartArt loại StackedList vào slide đã truy cập.
- Truy cập nút đầu tiên trong hình dạng SmartArt đã thêm.
- Bây giờ, thêm Child Node cho Node đã chọn ở vị trí 2 và đặt văn bản cho nó.
- Lưu bản trình chiếu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **Truy cập một nút SmartArt**
Mã mẫu dưới đây sẽ giúp truy cập các nút trong hình dạng SmartArt. Lưu ý rằng bạn không thể thay đổi LayoutType của SmartArt vì nó chỉ đọc được và chỉ được đặt khi hình dạng SmartArt được thêm.

- Tạo một thể hiện của lớp `Presentation` và tải bản trình chiếu có hình dạng SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
- Duyệt qua mọi hình dạng trong slide đầu tiên.
- Kiểm tra nếu hình dạng là loại SmartArt và ép kiểu hình dạng đã chọn sang SmartArt nếu nó là SmartArt.
- Duyệt qua tất cả các Node trong hình dạng SmartArt.
- Truy cập và hiển thị thông tin như vị trí Node SmartArt, cấp độ và Văn bản.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **Truy cập một nút con SmartArt**
Mã mẫu dưới đây sẽ giúp truy cập các nút con thuộc về các nút tương ứng của hình dạng SmartArt.

- Tạo một thể hiện của lớp PresentationEx và tải bản trình chiếu có hình dạng SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
- Duyệt qua mọi hình dạng trong slide đầu tiên.
- Kiểm tra nếu hình dạng là loại SmartArt và ép kiểu hình dạng đã chọn sang SmartArtEx nếu nó là SmartArt.
- Duyệt qua tất cả các Node trong hình dạng SmartArt.
- Đối với mỗi Node hình dạng SmartArt đã chọn, duyệt qua tất cả các Child Node trong nút cụ thể.
- Truy cập và hiển thị thông tin như vị trí Child Node, cấp độ và Văn bản.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **Truy cập một nút con SmartArt tại vị trí cụ thể**
Trong ví dụ này, chúng ta sẽ học cách truy cập các nút con ở một vị trí cụ thể thuộc về các nút tương ứng của hình dạng SmartArt.

- Tạo một thể hiện của lớp `Presentation`.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
- Thêm một hình dạng SmartArt loại StackedList.
- Truy cập hình dạng SmartArt đã thêm.
- Truy cập nút có chỉ mục 0 của hình dạng SmartArt đã truy cập.
- Bây giờ, truy cập Child Node ở vị trí 1 của nút SmartArt đã truy cập bằng phương thức GetNodeByPosition().
- Truy cập và hiển thị thông tin như vị trí Child Node, cấp độ và Văn bản.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **Xóa một nút SmartArt**
Trong ví dụ này, chúng ta sẽ học cách xóa các nút trong hình dạng SmartArt.

- Tạo một thể hiện của lớp `Presentation` và tải bản trình chiếu có hình dạng SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
- Duyệt qua mọi hình dạng trong slide đầu tiên.
- Kiểm tra nếu hình dạng là loại SmartArt và ép kiểu hình dạng đã chọn sang SmartArt nếu nó là SmartArt.
- Kiểm tra nếu SmartArt có hơn 0 nút.
- Chọn nút SmartArt cần xóa.
- Bây giờ, xóa nút đã chọn bằng phương thức RemoveNode()* Lưu bản trình chiếu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **Xóa một nút SmartArt tại vị trí cụ thể**
Trong ví dụ này, chúng ta sẽ học cách xóa các nút trong hình dạng SmartArt ở một vị trí cụ thể.

- Tạo một thể hiện của lớp `Presentation` và tải bản trình chiếu có hình dạng SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng Index của nó.
- Duyệt qua mọi hình dạng trong slide đầu tiên.
- Kiểm tra nếu hình dạng là loại SmartArt và ép kiểu hình dạng đã chọn sang SmartArt nếu nó là SmartArt.
- Chọn nút hình dạng SmartArt ở chỉ mục 0.
- Bây giờ, kiểm tra nếu nút SmartArt đã chọn có hơn 2 nút con.
- Bây giờ, xóa nút ở Vị trí 1 bằng phương thức RemoveNodeByPosition().
- Lưu bản trình chiếu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **Đặt vị trí tùy chỉnh cho một nút con SmartArt**
Bây giờ Aspose.Slides hỗ trợ việc đặt các thuộc tính X và Y cho SmartArtShape. Đoạn mã dưới đây cho thấy cách đặt vị trí, kích thước và góc quay tùy chỉnh cho SmartArtShape; cũng lưu ý rằng việc thêm nút mới sẽ gây tính lại vị trí và kích thước của tất cả các nút.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **Kiểm tra nút trợ lý**
Trong mã mẫu dưới đây, chúng ta sẽ khám phá cách xác định các nút trợ lý trong bộ sưu tập nút SmartArt và thay đổi chúng.

- Tạo một thể hiện của lớp PresentationEx và tải bản trình chiếu có hình dạng SmartArt.
- Lấy tham chiếu của slide thứ hai bằng cách sử dụng Index của nó.
- Duyệt qua mọi hình dạng trong slide đầu tiên.
- Kiểm tra nếu hình dạng là loại SmartArt và ép kiểu hình dạng đã chọn sang SmartArtEx nếu nó là SmartArt.
- Duyệt qua tất cả các nút trong hình dạng SmartArt và kiểm tra xem chúng có phải là Assistant Nodes không.
- Thay đổi trạng thái của Assistant Node thành nút bình thường.
- Lưu bản trình chiếu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Đặt định dạng tô màu cho nút**
Aspose.Slides for C++ cho phép thêm các hình dạng SmartArt tùy chỉnh và đặt định dạng tô màu cho chúng. Bài viết này giải thích cách tạo và truy cập các hình dạng SmartArt và đặt định dạng tô màu cho các nút của chúng bằng Aspose.Slides for C++.

Vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp `Presentation`.
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một hình dạng SmartArt bằng cách đặt LayoutType.
- Đặt FillFormat cho các nút của hình dạng SmartArt.
- Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **Tạo ảnh thu nhỏ cho một nút con SmartArt**
Các nhà phát triển có thể tạo ảnh thu nhỏ cho Child node của SmartArt bằng các bước sau:

1. Tạo một thể hiện của lớp `Presentation` đại diện cho tệp PPTX.
2. Thêm SmartArt.
3. Lấy tham chiếu của một nút bằng cách sử dụng Index của nó.
4. Lấy ảnh thu nhỏ.
5. Lưu ảnh thu nhỏ ở bất kỳ định dạng ảnh nào mong muốn.

Ví dụ dưới đây tạo ảnh thu nhỏ cho nút con SmartArt

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ hoạt hình không?**

Có. SmartArt được coi như một hình dạng thông thường, vì vậy bạn có thể [áp dụng các hoạt hình tiêu chuẩn](/slides/vi/cpp/shape-animation/) (đầu vào, kết thúc, nhấn mạnh, đường chuyển động) và điều chỉnh thời gian. Bạn cũng có thể hoạt hình các hình dạng bên trong các nút SmartArt khi cần.

**Làm sao tôi có thể định vị một SmartArt cụ thể trên slide nếu ID nội bộ của nó không được biết?**

Gán và tìm kiếm bằng [text thay thế]((https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/set_alternativetext/)). Đặt AltText đặc trưng cho SmartArt giúp bạn tìm nó một cách lập trình mà không cần dựa vào các định danh nội bộ.

**Giao diện SmartArt có được giữ nguyên khi chuyển đổi bản trình chiếu sang PDF không?**

Có. Aspose.Slides render SmartArt với độ trung thực cao trong quá trình [xuất PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/), bảo lưu bố cục, màu sắc và hiệu ứng.

**Tôi có thể trích xuất hình ảnh của toàn bộ SmartArt (để dùng làm preview hoặc báo cáo) không?**

Có. Bạn có thể render hình dạng SmartArt thành [định dạng raster]((https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/getimage/)) hoặc thành [SVG]((https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/writeassvg/)) để có đầu ra vector mở rộng, phù hợp cho ảnh thu nhỏ, báo cáo hoặc sử dụng trên web.