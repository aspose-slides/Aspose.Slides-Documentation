---
title: Nâng cao Bản trình bày PowerPoint bằng Hoạt ảnh trong .NET
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
  - điều khiển hoạt ảnh
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
  - bản trình bày PowerPoint
  - .NET
  - C#
  - Aspose.Slides
description: "Khám phá khả năng của Aspose.Slides cho .NET trong việc xử lý hoạt ảnh PowerPoint. Tổng quan chung này nêu bật các tính năng chính và cung cấp những hiểu biết để nâng cao các bản trình bày của bạn."
---
## **Giới thiệu**

Vì các bản trình bày được tạo ra để trình bày nội dung, nên diện mạo trực quan và hành vi tương tác của chúng luôn được cân nhắc khi thiết kế.

Hoạt ảnh PowerPoint đóng vai trò quan trọng trong việc làm cho bản trình bày thu hút ánh nhìn và gây hứng thú cho người xem. Aspose.Slides cho .NET cung cấp nhiều tùy chọn để thêm hoạt ảnh vào các bản trình bày PowerPoint:

- Áp dụng các loại hiệu ứng hoạt ảnh PowerPoint khác nhau cho hình dạng, biểu đồ, bảng, đối tượng OLE và các thành phần khác của bản trình bày.
- Sử dụng nhiều hiệu ứng hoạt ảnh PowerPoint trên một hình dạng.
- Sử dụng dòng thời gian hoạt ảnh để kiểm soát các hiệu ứng hoạt ảnh.
- Tạo hoạt ảnh tùy chỉnh.

Trong Aspose.Slides cho .NET, nhiều hiệu ứng hoạt ảnh có thể được áp dụng cho hình dạng. Vì mọi thành phần trên một slide, bao gồm văn bản, hình ảnh, đối tượng OLE và bảng, đều được coi là hình dạng, các hiệu ứng hoạt ảnh có thể được áp dụng cho bất kỳ thành phần nào trên slide.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/) namespace cung cấp các lớp để làm việc với hoạt ảnh PowerPoint.

## **Hiệu ứng hoạt ảnh**

Aspose.Slides hỗ trợ **hơn 150 hiệu ứng hoạt ảnh**, bao gồm các hiệu ứng cơ bản như Bounce, PathFootball và Zoom, cũng như các hiệu ứng đặc thù như OLEObjectShow và OLEObjectOpen. Bạn có thể xem danh sách đầy đủ các hiệu ứng hoạt ảnh trong enum [EffectType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttype).

Thêm vào đó, các hiệu ứng hoạt ảnh này có thể được sử dụng kết hợp với các loại sau:

- [ColorEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/seteffect)

## **Hoạt ảnh tùy chỉnh**

Để xem các ví dụ C# đầy đủ về việc tạo, kiểm tra và sửa đổi hành vi và các đường chuyển động có thể chỉnh sửa, hãy xem [Custom Animation](/slides/vi/net/custom-animation/).

Bạn có thể tạo **hoạt ảnh tùy chỉnh** của riêng mình trong Aspose.Slides. Điều này có thể thực hiện bằng cách kết hợp nhiều hành vi lại thành một hoạt ảnh tùy chỉnh mới.

[Behavior](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/behavior) là khối xây dựng của một hiệu ứng hoạt ảnh PowerPoint. Kết hợp các hành vi để tùy chỉnh một hiệu ứng, hoặc thêm một hành vi để mở rộng một hiệu ứng đã định nghĩa. Việc lặp lại được cấu hình qua cài đặt thời gian chứ không phải qua một hành vi lặp riêng.

[Animation Point](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/point) là một điểm mà tại đó một hành vi nên được áp dụng.

## **Dòng thời gian hoạt ảnh**

[Sequence](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/sequence) là một tập hợp các hiệu ứng hoạt ảnh có thể nhắm mục tiêu các hình dạng khác nhau.

[Timeline](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/animationtimeline) là một tập hợp các Sequence được sử dụng trong một slide cụ thể. Nó là một engine hoạt ảnh được giới thiệu trong PowerPoint 2002. Trong các phiên bản PowerPoint trước đó, việc thêm hiệu ứng hoạt ảnh vào bản trình bày gặp nhiều khó khăn và chỉ có thể thực hiện bằng các giải pháp vòng quanh. Dòng thời gian thay thế lớp AnimationSettings cũ và cung cấp mô hình đối tượng rõ ràng hơn cho các hoạt ảnh PowerPoint. Một slide chỉ có thể có một dòng thời gian hoạt ảnh.

## **Hoạt ảnh tương tác**

[Trigger](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttriggertype) cho phép bạn định nghĩa các hành động của người dùng (ví dụ: nhấn nút) sẽ kích hoạt một hoạt ảnh cụ thể. Triggers được giới thiệu trong phiên bản mới nhất của PowerPoint.

## **Hoạt ảnh hình dạng**

Aspose.Slides cho phép bạn áp dụng hoạt ảnh cho các hình dạng, bao gồm văn bản, hình chữ nhật, đường thẳng, khung, đối tượng OLE và nhiều hơn nữa.

{{% alert color="info" title="Note" %}}
Đọc thêm [**About Shape Animation**](/slides/vi/net/shape-animation/).
{{% /alert %}}

## **Biểu đồ hoạt ảnh**

Để tạo biểu đồ hoạt ảnh, bạn nên sử dụng các lớp tương tự như với các hình dạng. Tuy nhiên, hoạt ảnh PowerPoint chỉ có thể được áp dụng cho các danh mục biểu đồ hoặc chuỗi biểu đồ. Bạn cũng có thể áp dụng hiệu ứng hoạt ảnh cho một phần tử danh mục hoặc một phần tử chuỗi.

{{% alert color="info" title="Note" %}}
Đọc thêm [**About Animated Charts**](/slides/vi/net/animated-charts/).
{{% /alert %}}

## **Văn bản hoạt ảnh**

Ngoài việc hoạt ảnh cho văn bản, bạn còn có thể áp dụng hoạt ảnh cho một đoạn văn.

{{% alert color="info" title="Note" %}}
Đọc thêm [**About Animated Text**](/slides/vi/net/animated-text/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các hoạt ảnh có được giữ lại khi xuất sang PDF không?**

Không. PDF là định dạng tĩnh, vì vậy các hoạt ảnh và [slide transitions](/slides/vi/net/slide-transition/) không được phát. Nếu bạn cần chuyển động, hãy xuất sang [HTML5](/slides/vi/net/export-to-html5/), [animated GIF](/slides/vi/net/convert-powerpoint-to-animated-gif/), hoặc [video](/slides/vi/net/convert-powerpoint-to-video/) thay thế.

**Tôi có thể chuyển bản trình bày hoạt ảnh thành video và kiểm soát tốc độ khung và kích thước khung hình không?**

Có. Bạn có thể [render the presentation as frames](/slides/vi/net/convert-powerpoint-to-video/) và mã hoá chúng thành video (ví dụ: bằng ffmpeg), chọn FPS và độ phân giải. Các hoạt ảnh và chuyển tiếp slide sẽ được phát trong quá trình render.

**Các hoạt ảnh có vẫn giữ nguyên khi làm việc với ODP (không chỉ PPTX) không?**

PPT, PPTX và ODP được hỗ trợ để [reading](/slides/vi/net/open-presentation/) và [writing](/slides/vi/net/save-presentation/), nhưng điều này không bảo đảm việc giữ lại hoạt ảnh. Dữ liệu hoạt ảnh tùy chỉnh có thể bị mất khi chuyển đổi sang ODP. Xem [Custom Animation](/slides/vi/net/custom-animation/) để biết ví dụ đã được kiểm nghiệm và các hạn chế định dạng.