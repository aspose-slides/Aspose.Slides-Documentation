---
title: Thêm Slides vào Bản Trình Bày trong C++
linktitle: Thêm Slide
type: docs
weight: 10
url: /vi/cpp/add-slide-to-presentation/
keywords:
- thêm slide
- tạo slide
- slide trống
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Dễ dàng thêm slides vào các bản trình bày PowerPoint và OpenDocument của bạn bằng Aspose.Slides cho C++ — chèn slide liền mạch, hiệu quả trong vài giây."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thêm slide vào bản trình bày PowerPoint một cách lập trình. Một bản trình bày chứa các slide master/layout và các slide bình thường, và các slide bình thường được sắp xếp theo chỉ mục bắt đầu từ 0. Mỗi slide có một ID duy nhất, và các tệp bản trình bày không có slide không được hỗ trợ.

Bài viết này giải thích cách tạo đối tượng `Presentation`, truy cập bộ sưu tập slide của nó, thêm một slide trống, làm việc với slide mới được thêm, và lưu bản trình bày đã cập nhật. Nó cũng bao gồm các điểm liên quan như chèn slide vào vị trí cụ thể, sử dụng layout, và hiểu slide trống có trong bản trình bày mới tạo.

## **Thêm slide vào bản trình bày**
Trước khi nói về việc thêm slide vào các tệp bản trình bày, hãy thảo luận một số thực tế về các slide. Mỗi tệp bản trình bày PowerPoint chứa slide Master / Layout và các slide Normal khác. Điều này có nghĩa là một tệp bản trình bày chứa ít nhất một hoặc nhiều slide. Điều quan trọng là biết rằng các tệp bản trình bày không có slide không được Aspose.Slides for C++ hỗ trợ. Mỗi slide có Id duy nhất và tất cả các Normal Slide được sắp xếp theo thứ tự được chỉ định bởi chỉ mục bắt đầu từ 0. Aspose.Slides for C++ cho phép các nhà phát triển thêm slide trống vào bản trình bày của họ. Để thêm slide trống vào bản trình bày, vui lòng làm theo các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
- Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/islidecollection/) bằng cách thiết lập tham chiếu tới thuộc tính Slides (tập hợp các đối tượng Slide nội dung) được công bố bởi đối tượng Presentation.
- Thêm một slide trống vào cuối tập hợp các slide nội dung bằng cách gọi phương thức AddEmptySlide được công bố bởi đối tượng ISlideCollection
- Thực hiện một số công việc với slide trống mới được thêm.
- Cuối cùng, ghi tệp bản trình bày bằng đối tượng [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **Câu hỏi thường gặp**

**Tôi có thể chèn một slide mới vào vị trí cụ thể, không chỉ ở cuối không?**

Có. Thư viện hỗ trợ các bộ sưu tập slide và các thao tác [insert](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidecollection/insertclone/), vì vậy bạn có thể thêm slide ở chỉ mục yêu cầu thay vì chỉ ở cuối.

**Các theme/style có được giữ nguyên khi thêm slide dựa trên layout không?**

Có. Một layout kế thừa định dạng từ master của nó, và slide mới kế thừa từ layout đã chọn và master tương ứng của nó.

**Slide nào có trong một bản trình bày "trống" mới tạo trước khi thêm slide?**

Một bản trình bày mới tạo đã chứa một slide trống với chỉ mục zero. Điều này quan trọng khi tính toán chỉ mục chèn.

**Làm sao tôi chọn "layout" phù hợp cho slide mới nếu master có nhiều tùy chọn?**

Thông thường chọn [LayoutSlide](https://reference.aspose.com/slides/vi/cpp/aspose.slides/layoutslide/) phù hợp với cấu trúc yêu cầu ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/vi/cpp/aspose.slides/slidelayouttype/)). Nếu không có layout như vậy, bạn có thể [add it to the master](/slides/vi/cpp/slide-layout/) và sau đó sử dụng nó.