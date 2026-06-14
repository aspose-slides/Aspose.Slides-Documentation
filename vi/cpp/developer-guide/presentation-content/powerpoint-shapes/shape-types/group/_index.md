---
title: Các hình dạng nhóm trong bản trình bày C++
linktitle: Nhóm Hình
type: docs
weight: 40
url: /vi/cpp/group/
keywords:
- hình dạng nhóm
- nhóm hình dạng
- thêm nhóm
- văn bản thay thế
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Học cách nhóm và tách nhóm các hình dạng trong bản trình chiếu PowerPoint bằng Aspose.Slides cho C++ — hướng dẫn nhanh, từng bước với mã C++ miễn phí."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với các hình dạng nhóm trong Aspose.Slides. Nó cho thấy cách thêm một hình dạng nhóm vào một slide, đặt các hình dạng bên trong và lưu bản trình bày đã cập nhật. Ngoài ra, nó còn minh họa cách truy cập các hình dạng được lưu trong một nhóm và đọc các giá trị `AlternativeText` của chúng. Thêm nữa, bài viết ngắn gọn đề cập đến các tính năng liên quan đến hình dạng nhóm như nhóm lồng nhau, thứ tự z và các tùy chọn khóa.

## **Thêm một Hình Nhóm**
Aspose.Slides hỗ trợ làm việc với các hình dạng nhóm trên slide. Tính năng này giúp các nhà phát triển tạo ra các bản trình bày phong phú hơn. Aspose.Slides cho C++ hỗ trợ việc thêm hoặc truy cập các hình dạng nhóm. Có thể thêm các hình dạng vào một hình dạng nhóm đã thêm để lấp đầy nó hoặc truy cập bất kỳ thuộc tính nào của hình dạng nhóm. Để thêm một hình dạng nhóm vào slide bằng Aspose.Slides cho C++:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu của một slide bằng cách sử dụng Index của nó
3. Thêm một hình dạng nhóm vào slide.
4. Thêm các hình dạng vào hình dạng nhóm đã thêm.
5. Lưu bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Ví dụ dưới đây thêm một hình dạng nhóm vào slide.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **Truy cập Thuộc tính AltText**
Chủ đề này trình bày các bước đơn giản, kèm theo ví dụ mã, để thêm một hình dạng nhóm và truy cập thuộc tính AltText của các hình dạng nhóm trên slide. Để truy cập AltText của một hình dạng nhóm trong slide bằng Aspose.Slides cho C++:

1. Khởi tạo lớp `Presentation` đại diện cho tệp PPTX.
2. Lấy tham chiếu của một slide bằng cách sử dụng Index của nó.
3. Truy cập bộ sưu tập shape của slide.
4. Truy cập hình dạng nhóm.
5. Truy cập thuộc tính AltText.

Ví dụ dưới đây truy cập văn bản thay thế của hình dạng nhóm.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **Câu hỏi thường gặp**

**Liệu có hỗ trợ nhóm lồng nhau (một nhóm bên trong một nhóm) không?**

Có. [GroupShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/groupshape/) có phương thức [get_ParentGroup](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/get_parentgroup/) cho biết trực tiếp hỗ trợ cấu trúc phân cấp (một nhóm có thể là con của một nhóm khác).

**Làm thế nào để kiểm soát thứ tự z của nhóm so với các đối tượng khác trên slide?**

Sử dụng [GroupShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/groupshape/)’s [Z-Order position](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/get_zorderposition/) để kiểm tra vị trí của nó trong ngăn xếp hiển thị.

**Tôi có thể ngăn việc di chuyển/chỉnh sửa/bỏ nhóm không?**

Có. Phần khóa của nhóm được hiển thị qua [get_GroupShapeLock](https://reference.aspose.com/slides/vi/cpp/aspose.slides/groupshape/get_groupshapelock/), cho phép bạn hạn chế các thao tác trên đối tượng.