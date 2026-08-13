---
title: Nâng cao Bản Trình Bày PowerPoint với Hoạt Ảnh trong .NET
linktitle: Hoạt Ảnh PowerPoint
type: docs
weight: 150
url: /vi/net/powerpoint-animation/
keywords:
- thêm hoạt ảnh
- cập nhật hoạt ảnh
- thay đổi hoạt ảnh
- xóa bỏ hoạt ảnh
- quản lý hoạt ảnh
- kiểm soát hoạt ảnh
- hiệu ứng hoạt ảnh
- hoạt ảnh PowerPoint
- dòng thời gian hoạt ảnh
- hoạt ảnh tương tác
- hoạt ảnh tùy chỉnh
- hoạt ảnh hình dạng
- biểu đồ được hoạt ảnh
- văn bản được hoạt ảnh
- hình dạng được hoạt ảnh
- đối tượng OLE được hoạt ảnh
- hình ảnh được hoạt ảnh
- bảng được hoạt ảnh
- bản trình bày PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Khám phá khả năng của Aspose.Slides cho .NET trong việc xử lý hoạt ảnh PowerPoint. Tổng quan chung này nêu bật các tính năng chính và cung cấp những hiểu biết để nâng cao các bản trình bày của bạn."
---
## **Giới thiệu**

Vì các bản trình bày nhằm mục đích giới thiệu một nội dung, nên hình ảnh trực quan và hành vi tương tác luôn được cân nhắc trong quá trình tạo.

**PowerPoint animation** đóng vai trò quan trọng trong việc làm cho bản trình bày thu hút mắt và hấp dẫn người xem. Aspose.Slides for .NET cung cấp một loạt các tùy chọn để thêm hoạt ảnh vào các bản PowerPoint:

- Áp dụng các loại hiệu ứng hoạt ảnh PowerPoint khác nhau cho hình dạng, biểu đồ, bảng, đối tượng OLE và các thành phần trình bày khác.
- Áp dụng nhiều hiệu ứng hoạt ảnh PowerPoint cho một hình dạng duy nhất.
- Sử dụng dòng thời gian hoạt ảnh để kiểm soát các hiệu ứng hoạt ảnh.
- Tạo các hoạt ảnh tùy chỉnh.

Trong Aspose.Slides for .NET, có thể áp dụng các hiệu ứng hoạt ảnh khác nhau cho các hình dạng. Vì mọi thành phần trên một slide, bao gồm văn bản, hình ảnh, đối tượng OLE và bảng, đều được coi là một hình dạng, các hiệu ứng hoạt ảnh có thể được áp dụng cho bất kỳ thành phần nào trên slide.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/) namespace cung cấp các lớp để làm việc với hoạt ảnh PowerPoint.

## **Hiệu Ứng Hoạt Ảnh**

Aspose.Slides hỗ trợ **hơn 150 hiệu ứng hoạt ảnh**, bao gồm các hiệu ứng cơ bản như Bounce, PathFootball và Zoom, cũng như các hiệu ứng đặc thù như OLEObjectShow và OLEObjectOpen. Bạn có thể tìm danh sách đầy đủ các hiệu ứng hoạt ảnh trong enumeration [EffectType](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttype).

Ngoài ra, các hiệu ứng hoạt ảnh này có thể được sử dụng kết hợp với các loại sau:

- [ColorEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/seteffect)

## **Hoạt Ảnh Tùy Chỉnh**

Có thể tạo **hoạt ảnh tùy chỉnh** của riêng bạn trong Aspose.Slides. Điều này đạt được bằng cách kết hợp một số hành vi lại với nhau thành một hoạt ảnh tùy chỉnh mới.

[Behaviour](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/behavior) là khối xây dựng của bất kỳ hiệu ứng hoạt ảnh PowerPoint nào. Tất cả các hiệu ứng hoạt ảnh thực chất là một tập hợp các hành vi được hợp thành một chiến lược. Bạn có thể kết hợp các hành vi thành một hoạt ảnh tùy chỉnh một lần và tái sử dụng nó trong các bản trình bày khác. Nếu bạn thêm một hành vi mới vào một hiệu ứng hoạt ảnh PowerPoint tiêu chuẩn, nó sẽ trở thành một hoạt ảnh tùy chỉnh khác. Ví dụ, bạn có thể thêm hành vi lặp lại vào một hoạt ảnh để nó lặp lại vài lần.

[Animation Point](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/point) là một điểm mà tại đó một hành vi sẽ được áp dụng.

## **Dòng Thời Gian Hoạt Ảnh**

[Sequence](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/sequence) là một tập hợp các hiệu ứng hoạt ảnh được áp dụng cho một hình dạng cụ thể.

[Timeline](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/animationtimeline) là một tập hợp các Sequence được sử dụng trong một slide cụ thể. Nó là một engine hoạt ảnh được giới thiệu trong PowerPoint 2002. Trong các phiên bản PowerPoint trước đó, việc thêm hiệu ứng hoạt ảnh vào bản trình bày gặp khó khăn và chỉ có thể thực hiện thông qua nhiều cách khắc phục. Dòng thời gian thay thế lớp AnimationSettings cũ và cung cấp mô hình đối tượng rõ ràng hơn cho hoạt ảnh PowerPoint. Một slide chỉ có thể có một dòng thời gian hoạt ảnh duy nhất.

## **Hoạt Ảnh Tương Tác**

[Trigger](https://reference.aspose.com/slides/vi/net/aspose.slides.animation/effecttriggertype) cho phép bạn định nghĩa các hành động người dùng (ví dụ: nhấn nút) sẽ khởi chạy một hoạt ảnh cụ thể. Triggers đã được giới thiệu trong phiên bản PowerPoint mới nhất.

## **Hoạt Ảnh Hình Dạng**

Aspose.Slides cho phép bạn áp dụng hoạt ảnh cho các hình dạng, bao gồm văn bản, hình chữ nhật, đường thẳng, khung, đối tượng OLE và nhiều hơn nữa.

{{% alert color="info" %}} 
Đọc thêm [**Về Hoạt Ảnh Hình Dạng**](/slides/vi/net/shape-animation/).
{{% /alert %}}

## **Biểu Đồ Được Hoạt Ảnh**

Để tạo biểu đồ được hoạt ảnh, bạn nên sử dụng cùng các lớp như với các hình dạng. Tuy nhiên, hoạt ảnh PowerPoint chỉ có thể được áp dụng cho các danh mục biểu đồ hoặc các chuỗi biểu đồ. Bạn cũng có thể áp dụng hiệu ứng hoạt ảnh cho một phần tử danh mục hoặc một phần tử chuỗi.

{{% alert color="info" %}} 
Đọc thêm [**Về Biểu Đồ Được Hoạt Ảnh**](/slides/vi/net/animated-charts/).
{{% /alert %}}

## **Văn Bản Được Hoạt Ảnh**

Ngoài văn bản được hoạt ảnh, cũng có thể áp dụng hoạt ảnh cho một đoạn văn.

{{% alert color="info" %}} 
Đọc thêm [**Về Văn Bản Được Hoạt Ảnh**](/slides/vi/net/animated-text/).
{{% /alert %}}

## **FAQ**

### Các hoạt ảnh có được giữ lại khi xuất sang PDF không?

Không. PDF là định dạng tĩnh, vì vậy các hoạt ảnh và [slide transitions](/slides/vi/net/slide-transition/) không được phát. Nếu bạn cần chuyển động, hãy xuất sang [HTML5](/slides/vi/net/export-to-html5/), [animated GIF](/slides/vi/net/convert-powerpoint-to-animated-gif/), hoặc [video](/slides/vi/net/convert-powerpoint-to-video/) thay thế.

### Tôi có thể chuyển một bản trình bày có hoạt ảnh thành video và kiểm soát tốc độ khung hình và kích thước khung hình không?

Có. Bạn có thể [render the presentation as frames](/slides/vi/net/convert-powerpoint-to-video/) và mã hoá chúng thành video (ví dụ: bằng ffmpeg), chọn FPS và độ phân giải. Các hoạt ảnh và chuyển đổi slide được phát trong quá trình render.

### Các hoạt ảnh có giữ nguyên khi làm việc với ODP (không chỉ PPTX) không?

PPT, PPTX và ODP được hỗ trợ để [reading](/slides/vi/net/open-presentation/) và [writing](/slides/vi/net/save-presentation/), nhưng sự khác biệt về định dạng có nghĩa là một số hiệu ứng có thể hiển thị hoặc hoạt động hơi khác nhau. Hãy kiểm chứng các trường hợp quan trọng với các mẫu thực tế.