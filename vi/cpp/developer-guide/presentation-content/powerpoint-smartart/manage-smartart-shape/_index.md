---
title: Quản lý Đồ họa SmartArt trong Bản trình bày bằng C++
linktitle: Đồ họa SmartArt
type: docs
weight: 20
url: /vi/cpp/manage-smartart-shape/
keywords:
- Đối tượng SmartArt
- Đồ họa SmartArt
- Kiểu SmartArt
- Màu SmartArt
- Tạo SmartArt
- Thêm SmartArt
- Chỉnh sửa SmartArt
- Thay đổi SmartArt
- Truy cập SmartArt
- Loại bố cục SmartArt
- PowerPoint
- Bản trình bày
- C++
- Aspose.Slides
description: "Tự động hoá việc tạo, chỉnh sửa và thiết kế SmartArt trong PowerPoint bằng C++ sử dụng Aspose.Slides, với các ví dụ mã ngắn gọn và hướng dẫn tập trung vào hiệu suất."
---
## **Tổng quan**

Aspose.Slides cho phép bạn tạo và quản lý đồ họa SmartArt trong các bản trình bày PowerPoint một cách lập trình. Bài viết này giải thích cách thêm một hình dạng SmartArt vào một slide, truy cập các hình dạng SmartArt hiện có, tìm SmartArt theo một loại bố cục cụ thể, và cập nhật giao diện của nó bằng cách thay đổi kiểu SmartArt hoặc kiểu màu.

Các ví dụ cho thấy cách làm việc với các hình dạng SmartArt thông qua bộ sưu tập hình dạng của slide, kiểm tra xem một hình dạng có phải là SmartArt hay không và sau đó chỉnh sửa hoặc kiểm tra các thuộc tính của nó.

## **Tạo hình dạng SmartArt**
Aspose.Slides for C++ hiện hỗ trợ thêm các hình dạng SmartArt tùy chỉnh vào slide từ đầu. Aspose.Slides for C++ đã cung cấp API đơn giản nhất để tạo các hình dạng SmartArt một cách dễ dàng. Để tạo một hình dạng SmartArt trong slide, vui lòng làm theo các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một hình dạng SmartArt bằng cách thiết lập LayoutType cho nó.
- Ghi bản trình bày đã sửa đổi thành tệp PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **Truy cập hình dạng SmartArt trên một Slide**
Mã sau sẽ được sử dụng để truy cập các hình dạng SmartArt đã được thêm vào slide của bản trình bày. Trong ví dụ, chúng ta sẽ duyệt qua mọi hình dạng bên trong slide và kiểm tra xem nó có phải là hình dạng SmartArt không. Nếu là SmartArt, chúng ta sẽ ép kiểu thành đối tượng SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Truy cập hình dạng SmartArt với một Loại Bố Cục Cụ Thể**
Mã mẫu sau sẽ giúp truy cập hình dạng SmartArt có LayoutType cụ thể. Lưu ý rằng bạn không thể thay đổi LayoutType của SmartArt vì nó chỉ đọc và chỉ được thiết lập khi hình dạng SmartArt được thêm vào.

- Tạo một thể hiện của lớp `Presentation` và tải bản trình bày có hình dạng SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
- Duyệt qua mọi hình dạng bên trong slide đầu tiên.
- Kiểm tra xem hình dạng có phải là SmartArt không và ép kiểu hình dạng đã chọn thành SmartArt nếu đúng.
- Kiểm tra hình dạng SmartArt có LayoutType cụ thể và thực hiện các thao tác cần thiết sau đó.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **Thay đổi Kiểu Dáng của hình dạng SmartArt**
Mã mẫu sau sẽ giúp truy cập hình dạng SmartArt có LayoutType cụ thể.

- Tạo một thể hiện của lớp `Presentation` và tải bản trình bày có hình dạng SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
- Duyệt qua mọi hình dạng bên trong slide đầu tiên.
- Kiểm tra xem hình dạng có phải là SmartArt không và ép kiểu hình dạng đã chọn thành SmartArt nếu đúng.
- Tìm hình dạng SmartArt có Kiểu Dáng (Style) cụ thể.
- Đặt Kiểu Dáng mới cho hình dạng SmartArt.
- Lưu bản trình bày.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **Thay đổi Kiểu Màu của hình dạng SmartArt**
Trong ví dụ này, chúng ta sẽ học cách thay đổi kiểu màu cho bất kỳ hình dạng SmartArt nào. Mã mẫu dưới đây sẽ truy cập hình dạng SmartArt với kiểu màu cụ thể và thay đổi kiểu của nó.

- Tạo một thể hiện của lớp `Presentation` và tải bản trình bày có hình dạng SmartArt.
- Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ mục của nó.
- Duyệt qua mọi hình dạng bên trong slide đầu tiên.
- Kiểm tra xem hình dạng có phải là SmartArt không và ép kiểu hình dạng đã chọn thành SmartArt nếu đúng.
- Tìm hình dạng SmartArt có Kiểu Màu (Color Style) cụ thể.
- Đặt Kiểu Màu mới cho hình dạng SmartArt.
- Lưu bản trình bày.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **Câu hỏi thường gặp**

**Tôi có thể hoạt hình hoá SmartArt như một đối tượng duy nhất không?**

Có. SmartArt là một hình dạng, vì vậy bạn có thể áp dụng [các hoạt hình tiêu chuẩn](/slides/vi/cpp/powerpoint-animation/) thông qua API hoạt hình (đầu vào, kết thúc, nhấn mạnh, đường di chuyển) giống như các hình dạng khác.

**Làm thế nào tôi có thể tìm một SmartArt cụ thể trên slide nếu tôi không biết ID nội bộ của nó?**

Thiết lập và sử dụng Văn bản Thay thế (AltText) rồi tìm kiếm hình dạng theo giá trị đó — đây là cách được khuyến nghị để xác định hình dạng mục tiêu.

**Tôi có thể nhóm SmartArt với các hình dạng khác không?**

Có. Bạn có thể nhóm SmartArt với các hình dạng khác (hình ảnh, bảng, v.v.) và sau đó [thao tác với nhóm](/slides/vi/cpp/group/).

**Làm sao tôi lấy được hình ảnh của một SmartArt cụ thể (ví dụ: để xem trước hoặc báo cáo)?**

Xuất thumbnail/hình ảnh của hình dạng; thư viện có thể [kết xuất các hình dạng riêng lẻ](/slides/vi/cpp/create-shape-thumbnails/) thành các tệp raster (PNG/JPG/TIFF).

**Kiểu dáng SmartArt có được giữ nguyên khi chuyển đổi toàn bộ bản trình bày sang PDF không?**

Có. Động cơ render nhằm đạt độ trung thực cao cho [xuất PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/), với nhiều tùy chọn về chất lượng và tính tương thích.