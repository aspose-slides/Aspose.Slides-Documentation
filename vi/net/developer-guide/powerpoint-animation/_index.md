---
title: Nâng cao Bài thuyết trình PowerPoint với Hoạt ảnh trong .NET
linktitle: Hoạt ảnh PowerPoint
type: docs
weight: 150
url: /vi/net/powerpoint-animation/
keywords:
- thêm hoạt ảnh
- cập nhật hoạt ảnh
- thay đổi hoạt ảnh
- xóa hoạt ảnh
- quản lý hoạt ảnh
- kiểm soát hoạt ảnh
- hiệu ứng hoạt ảnh
- hoạt ảnh PowerPoint
- dòng thời gian hoạt ảnh
- hoạt ảnh tương tác
- hoạt ảnh tùy chỉnh
- hoạt ảnh hình dạng
- biểu đồ hoạt ảnh
- văn bản hoạt ảnh
- hình dạng hoạt ảnh
- đối tượng OLE hoạt ảnh
- hình ảnh hoạt ảnh
- bảng hoạt ảnh
- bài thuyết trình PowerPoint
- .NET
- C#
- Aspose.Slides
description: Khám phá khả năng của Aspose.Slides cho .NET trong việc xử lý hoạt ảnh PowerPoint. Tổng quan chung này nêu bật các tính năng chính và cung cấp những hiểu biết để nâng cao các bài thuyết trình của bạn.
---
## **Giới thiệu**

Vì các bài thuyết trình được tạo ra để trình bày nội dung, nên diện mạo trực quan và hành vi tương tác luôn được xem xét khi tạo.

**PowerPoint animation** đóng vai trò quan trọng trong việc làm cho bài thuyết trình bắt mắt và thu hút người xem. Aspose.Slides for .NET cung cấp một loạt các tùy chọn để thêm hoạt ảnh vào các bài thuyết trình PowerPoint:

- Áp dụng các loại hiệu ứng hoạt ảnh PowerPoint khác nhau cho các hình dạng, biểu đồ, bảng, đối tượng OLE và các yếu tố khác của bài thuyết trình.
- Sử dụng nhiều hiệu ứng hoạt ảnh PowerPoint trên một hình dạng duy nhất.
- Sử dụng timeline hoạt ảnh để kiểm soát các hiệu ứng hoạt ảnh.
- Tạo hoạt ảnh tùy chỉnh.

Trong Aspose.Slides for .NET, có thể áp dụng các hiệu ứng hoạt ảnh khác nhau cho các hình dạng. Vì mọi yếu tố trên một slide, bao gồm văn bản, hình ảnh, đối tượng OLE và bảng, đều được coi là một hình dạng, nên các hiệu ứng hoạt ảnh có thể được áp dụng cho bất kỳ yếu tố nào trên slide.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/) namespace cung cấp các lớp để làm việc với hoạt ảnh PowerPoint.

## **Hiệu ứng hoạt ảnh**

Aspose.Slides hỗ trợ **hơn 150 hiệu ứng hoạt ảnh**, bao gồm các hiệu ứng cơ bản như Bounce, PathFootball và Zoom, cũng như các hiệu ứng cụ thể như OLEObjectShow và OLEObjectOpen. Bạn có thể tìm danh sách đầy đủ các hiệu ứng hoạt ảnh trong enumeration [EffectType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttype).

Ngoài ra, các hiệu ứng hoạt ảnh này có thể được sử dụng kết hợp với các loại sau:

- [ColorEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/seteffect)

## **Hoạt ảnh tùy chỉnh**

Bạn có thể tạo **hoạt ảnh tùy chỉnh** của riêng mình trong Aspose.Slides. Điều này có thể đạt được bằng cách kết hợp một số behavior lại với nhau thành một hoạt ảnh tùy chỉnh mới.

[Behaviour](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/behavior) là một khối xây dựng của bất kỳ hiệu ứng hoạt ảnh PowerPoint nào. Tất cả các hiệu ứng hoạt ảnh về cơ bản là một tập hợp các behavior được kết hợp thành một chiến lược. Bạn có thể kết hợp các behavior vào một hoạt ảnh tùy chỉnh một lần và tái sử dụng nó trong các bài thuyết trình khác. Nếu bạn thêm một behavior mới vào một hiệu ứng hoạt ảnh PowerPoint tiêu chuẩn, nó sẽ trở thành một hoạt ảnh tùy chỉnh khác. Ví dụ, bạn có thể thêm một behavior lặp lại vào một hoạt ảnh để nó lặp lại vài lần.

[Animation Point](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/point) là một điểm mà behavior nên được áp dụng.

## **Dòng thời gian hoạt ảnh**

[Sequence](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/sequence) là một bộ sưu tập các hiệu ứng hoạt ảnh được áp dụng cho một hình dạng cụ thể.

[Timeline](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/animationtimeline) là một tập hợp các sequence được sử dụng trong một slide cụ thể. Đây là một engine hoạt ảnh được giới thiệu trong PowerPoint 2002. Trong các phiên bản PowerPoint trước đây, việc thêm các hiệu ứng hoạt ảnh vào bài thuyết trình rất khó khăn và chỉ có thể thực hiện thông qua nhiều cách khắc phục. Timeline thay thế lớp AnimationSettings cũ và cung cấp một mô hình đối tượng rõ ràng hơn cho hoạt ảnh PowerPoint. Một slide chỉ có thể có một timeline hoạt ảnh.

## **Hoạt ảnh tương tác**

[Trigger](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttriggertype) cho phép bạn định nghĩa các hành động của người dùng (ví dụ: nhấn nút) sẽ khởi chạy một hoạt ảnh cụ thể. Triggers được giới thiệu trong phiên bản mới nhất của PowerPoint.

## **Hoạt ảnh hình dạng**

Aspose.Slides cho phép bạn áp dụng hoạt ảnh cho các hình dạng, bao gồm văn bản, hình chữ nhật, đường, khung, đối tượng OLE và nhiều hơn nữa.

{{% alert color="primary" %}} 
Đọc thêm [**Về hoạt ảnh hình dạng**](/slides/vi/net/shape-animation/).
{{% /alert %}}

## **Biểu đồ hoạt ảnh**

Để tạo biểu đồ hoạt ảnh, bạn nên sử dụng các lớp giống như đối với các hình dạng. Tuy nhiên, hoạt ảnh PowerPoint chỉ có thể được áp dụng cho các danh mục biểu đồ hoặc chuỗi biểu đồ. Bạn cũng có thể áp dụng các hiệu ứng hoạt ảnh cho một phần tử danh mục hoặc một phần tử chuỗi.

{{% alert color="primary" %}} 
Đọc thêm [**Về biểu đồ hoạt ảnh**](/slides/vi/net/animated-charts/).
{{% /alert %}}

## **Văn bản hoạt ảnh**

Ngoài văn bản hoạt ảnh, bạn cũng có thể áp dụng hoạt ảnh cho một đoạn văn.

{{% alert color="primary" %}} 
Đọc thêm [**Về văn bản hoạt ảnh**](/slides/vi/net/animated-text/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các hoạt ảnh có được giữ lại khi xuất sang PDF không?**

Không. PDF là định dạng tĩnh, vì vậy các hoạt ảnh và [chuyển đổi slide](/slides/vi/net/slide-transition/) không phát. Nếu bạn cần chuyển động, hãy xuất sang [HTML5](/slides/vi/net/export-to-html5/), [animated GIF](/slides/vi/net/convert-powerpoint-to-animated-gif/), hoặc [video](/slides/vi/net/convert-powerpoint-to-video/) thay thế.

**Tôi có thể chuyển một bài thuyết trình hoạt ảnh thành video và kiểm soát tốc độ khung và kích thước khung hình không?**

Có. Bạn có thể [xuất bản thuyết trình thành các khung hình](/slides/vi/net/convert-powerpoint-to-video/) và mã hoá chúng thành video (ví dụ, qua ffmpeg), chọn FPS và độ phân giải. Các hoạt ảnh và chuyển đổi slide được phát trong quá trình render.

**Các hoạt ảnh có giữ nguyên khi làm việc với ODP (không chỉ PPTX) không?**

PPT, PPTX và ODP được hỗ trợ để [đọc](/slides/vi/net/open-presentation/) và [ghi](/slides/vi/net/save-presentation/), nhưng sự khác biệt về định dạng có nghĩa là một số hiệu ứng có thể hiển thị hoặc hoạt động hơi khác nhau. Hãy kiểm tra các trường hợp quan trọng bằng các mẫu thực tế.