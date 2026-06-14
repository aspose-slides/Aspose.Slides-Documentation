---
title: Thêm Slides vào Bản Trình Chiếu trong .NET
linktitle: Thêm Slide
type: docs
weight: 10
url: /vi/net/add-slide-to-presentation/
keywords:
- thêm slide
- tạo slide
- slide trống
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Dễ dàng thêm slide vào các bản trình chiếu PowerPoint và OpenDocument của bạn bằng Aspose.Slides cho .NET—việc chèn slide liền mạch, hiệu quả trong vài giây."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thêm slide vào các bản trình chiếu PowerPoint một cách lập trình. Một bản trình chiếu chứa các slide Master/Layout và các slide bình thường, và các slide bình thường được sắp xếp theo chỉ mục bắt đầu từ 0. Mỗi slide có một ID duy nhất, và các tệp bản trình chiếu không có slide sẽ không được hỗ trợ.

Bài viết này mô tả cách tạo đối tượng `Presentation`, truy cập bộ sưu tập slide, thêm một slide trống, làm việc với slide mới được thêm và lưu bản trình chiếu đã cập nhật. Nó cũng đề cập đến các điểm liên quan như chèn slide vào vị trí cụ thể, sử dụng layout, và hiểu slide trống có sẵn trong một bản trình chiếu mới tạo.

## **Thêm một Slide vào Bản Trình Chiếu**
Trước khi nói về việc thêm slide vào các tệp bản trình chiếu, chúng ta hãy thảo luận một số thực tế về slide. Mỗi tệp bản trình chiếu PowerPoint chứa slide Master / Layout và các slide Normal khác. Điều này có nghĩa là một tệp bản trình chiếu chứa ít nhất một slide. Điều quan trọng là phải biết rằng các tệp bản trình chiếu không có slide không được Aspose.Slides for .NET hỗ trợ. Mỗi slide có một Id duy nhất và tất cả các Slide Normal được sắp xếp theo thứ tự được chỉ định bằng chỉ mục bắt đầu từ 0. Aspose.Slides for .NET cho phép các nhà phát triển thêm slide trống vào bản trình chiếu của họ. Để thêm một slide trống vào bản trình chiếu, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
- Khởi tạo lớp [ISlideCollection](https://reference.aspose.com/slides/vi/net/aspose.slides/islidecollection) bằng cách đặt tham chiếu tới thuộc tính Slides (tập hợp các đối tượng Slide nội dung) được cung cấp bởi đối tượng Presentation.
- Thêm một slide trống vào bản trình chiếu ở cuối tập hợp các slide nội dung bằng cách gọi các phương thức AddEmptySlide được cung cấp bởi đối tượng ISlideCollection.
- Thực hiện một số công việc với slide trống vừa được thêm.
- Cuối cùng, ghi tệp bản trình chiếu bằng đối tượng [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **Câu hỏi thường gặp**

**Tôi có thể chèn một slide mới vào vị trí cụ thể, không chỉ ở cuối không?**

Có. Thư viện hỗ trợ các bộ sưu tập slide và các thao tác [insert](https://reference.aspose.com/slides/vi/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/vi/net/aspose.slides/slidecollection/insertclone/) , vì vậy bạn có thể thêm một slide tại chỉ mục yêu cầu thay vì chỉ ở cuối.

**Các theme/style có được giữ nguyên khi thêm slide dựa trên một layout không?**

Có. Một layout kế thừa định dạng từ master của nó, và slide mới kế thừa từ layout đã chọn và master liên quan.

**Slide nào có trong một bản trình chiếu “trống” mới tạo trước khi thêm slide?**

Một bản trình chiếu mới tạo đã chứa sẵn một slide trống với chỉ mục 0. Điều này quan trọng khi tính toán chỉ số chèn.

**Làm sao chọn “layout” phù hợp cho một slide mới nếu master có nhiều tùy chọn?**

Thông thường chọn [LayoutSlide](https://reference.aspose.com/slides/vi/net/aspose.slides/layoutslide/) phù hợp với cấu trúc yêu cầu ([Title and Content, Two Content, v.v.](https://reference.aspose.com/slides/vi/net/aspose.slides/slidelayouttype/)). Nếu thiếu layout như vậy, bạn có thể [add it to the master](/slides/vi/net/slide-layout/) và sau đó sử dụng nó.