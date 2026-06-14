---
title: Quản lý Siêu chỉ số và Chỉ số phụ trong Bản trình chiếu bằng C++
linktitle: Siêu chỉ số và Chỉ số phụ
type: docs
weight: 80
url: /vi/cpp/superscript-and-subscript/
keywords:
- siêu chỉ số
- chỉ số phụ
- thêm siêu chỉ số
- thêm chỉ số phụ
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Nắm vững siêu chỉ số và chỉ số phụ trong Aspose.Slides cho C++ và nâng cao bản trình chiếu của bạn với định dạng văn bản chuyên nghiệp để đạt hiệu quả tối đa."
---
## **Tổng quan**

Aspose.Slides cung cấp các tính năng để tích hợp văn bản siêu chỉ số và chỉ số phụ vào các bản thuyết trình PowerPoint (PPT, PPTX) và OpenDocument (ODP). Cho dù bạn cần làm nổi bật công thức hoá học, phương trình toán học hoặc chú thích nội dung bằng chú thích dưới, các tùy chọn định dạng chuyên biệt này giúp duy trì tính rõ ràng và chính xác. Trong bài viết này, bạn sẽ học cách áp dụng kiểu siêu chỉ số và chỉ số phụ một cách liền mạch và đảm bảo kết quả chuyên nghiệp cho mọi slide.

## **Quản lý Văn bản Siệu chỉ số và Chỉ số phụ**

Bạn có thể thêm văn bản siêu chỉ số và chỉ số phụ vào bất kỳ phần nào của đoạn văn. Để thêm văn bản Siệu chỉ số hoặc Chỉ số phụ trong khung văn bản Aspose.Slides, phải sử dụng thuộc tính **Escapement** của lớp PortionFormat.

Thuộc tính này trả về hoặc đặt văn bản siêu chỉ số hoặc chỉ số phụ (giá trị từ -100% (chỉ số phụ) đến 100% (siêu chỉ số)). Ví dụ:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ số của nó.
- Thêm một IAutoShape loại Rectangle vào slide.
- Truy cập ITextFrame liên kết với IAutoShape.
- Xóa các Paragraph hiện có
- Tạo một đối tượng paragraph mới để chứa văn bản siêu chỉ số và thêm nó vào bộ sưu tập IParagraphs của ITextFrame.
- Tạo một đối tượng portion mới
- Đặt thuộc tính Escapement cho portion trong khoảng từ 0 đến 100 để thêm siêu chỉ số. (0 nghĩa là không có siêu chỉ số)
- Đặt một đoạn văn bản cho Portion và sau đó thêm vào bộ sưu tập portion của paragraph.
- Tạo một đối tượng paragraph mới để chứa văn bản chỉ số phụ và thêm nó vào bộ sưu tập IParagraphs của ITextFrame.
- Tạo một đối tượng portion mới
- Đặt thuộc tính Escapement cho portion trong khoảng từ 0 đến -100 để thêm chỉ số phụ. (0 nghĩa là không có chỉ số phụ)
- Đặt một đoạn văn bản cho Portion và sau đó thêm vào bộ sưu tập portion của paragraph.
- Lưu bản trình bày dưới dạng tệp PPTX.

Việc thực hiện các bước trên được minh họa dưới đây.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **Câu hỏi thường gặp**

**Liệu siệu chỉ số và chỉ số phụ có được giữ nguyên khi xuất sang PDF hoặc các định dạng khác không?**

Có, Aspose.Slides giữ nguyên định dạng siêu chỉ số và chỉ số phụ một cách chính xác khi xuất bản trình chiếu sang PDF, PPT/PPTX, hình ảnh và các định dạng hỗ trợ khác. Định dạng chuyên biệt vẫn được duy trì trong tất cả các tệp xuất ra.

**Có thể kết hợp siệu chỉ số và chỉ số phụ với các kiểu định dạng khác như in đậm hoặc in nghiêng không?**

Có, Aspose.Slides cho phép bạn kết hợp các kiểu định dạng văn bản khác nhau trong một portion. Bạn có thể bật in đậm, in nghiêng, gạch chân và đồng thời áp dụng siêu chỉ số hoặc chỉ số phụ bằng cách cấu hình các thuộc tính tương ứng trong [PortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/portionformat/).

**Định dạng siệu chỉ số và chỉ số phụ có hoạt động cho văn bản trong bảng, biểu đồ hoặc SmartArt không?**

Có, Aspose.Slides hỗ trợ định dạng trong hầu hết các đối tượng, bao gồm bảng và các thành phần biểu đồ. Khi làm việc với SmartArt, bạn cần truy cập các phần tử thích hợp (chẳng hạn như [SmartArtNode](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/smartartnode/)) và các vùng chứa văn bản của chúng, sau đó cấu hình các thuộc tính của [PortionFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides/portionformat/) theo cách tương tự.