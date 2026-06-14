---
title: Nâng cao bản trình chiếu PowerPoint bằng hoạt ảnh trong C++
linktitle: Hoạt ảnh PowerPoint
type: docs
weight: 150
url: /vi/cpp/powerpoint-animation/
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
- biểu đồ động
- văn bản động
- hình dạng động
- đối tượng OLE động
- hình ảnh động
- bảng động
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách thêm và điều khiển các hiệu ứng hoạt ảnh nâng cao trong Aspose.Slides cho C++ để tạo các bản trình chiếu PowerPoint và OpenDocument động."
---
## **Giới thiệu**

Vì bản thuyết trình được tạo ra để trình bày một nội dung nào đó, nên hình ảnh trực quan và hành vi tương tác luôn được xem xét khi tạo chúng.

**PowerPoint animation** đóng vai trò quan trọng để làm cho bản thuyết trình thu hút mắt và hấp dẫn người xem. Aspose.Slides for C++ cung cấp một loạt các tùy chọn để **thêm hoạt ảnh** vào bản thuyết trình PowerPoint:

- áp dụng các loại hiệu ứng hoạt ảnh PowerPoint khác nhau lên các shape, biểu đồ, bảng, OLE Object và các phần tử khác của bản thuyết trình.
- sử dụng nhiều hiệu ứng hoạt ảnh PowerPoint trên một shape.
- sử dụng timeline hoạt ảnh để điều khiển các hiệu ứng hoạt ảnh.
- tạo hoạt ảnh tùy chỉnh.

Trong Aspose.Slides for C++, có thể áp dụng các hiệu ứng hoạt ảnh khác nhau lên các shape. Vì mọi thành phần trên slide bao gồm văn bản, hình ảnh, OLE Object, bảng, v.v. đều được xem là một shape, nên chúng ta có thể áp dụng hiệu ứng hoạt ảnh lên mọi thành phần của một slide.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides.animation) **namespace** cung cấp các lớp để làm việc với hoạt ảnh PowerPoint.

## **Hiệu ứng hoạt ảnh**

Aspose.Slides hỗ trợ **hơn 150 hiệu ứng hoạt ảnh**, bao gồm các hiệu ứng cơ bản như Bounce, PathFootball, hiệu ứng Zoom và các hiệu ứng cụ thể như OLEObjectShow, OLEObjectOpen. Bạn có thể tìm danh sách đầy đủ các hiệu ứng hoạt ảnh trong liệt kê [**EffectType**](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31).

Ngoài ra, các hiệu ứng hoạt ảnh này có thể được sử dụng kết hợp với nhau:
- [ColorEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.set_effect)

## **Hoạt ảnh tùy chỉnh**

Bạn có thể tạo **hoạt ảnh tùy chỉnh** của riêng mình trong Aspose.Slides.  
Điều này có thể đạt được nếu bạn kết hợp một số hành vi lại với nhau thành một hoạt ảnh tùy chỉnh mới.

[**Behavior**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.behavior) là đơn vị cấu thành của bất kỳ hiệu ứng hoạt ảnh PowerPoint nào. Tất cả các hiệu ứng hoạt ảnh thực chất là một tập hợp các behaviour được ghép lại thành một chiến lược. Bạn có thể kết hợp các behaviour thành một hoạt ảnh tùy chỉnh một lần và tái sử dụng nó trong các bản thuyết trình khác. Nếu bạn thêm một behaviour mới vào một hiệu ứng hoạt ảnh PowerPoint tiêu chuẩn - đó sẽ là một hoạt ảnh tùy chỉnh khác. Ví dụ, bạn có thể thêm behaviour lặp lại vào một hoạt ảnh để nó lặp lại vài lần.

[**Animation Point**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.point) là điểm mà behaviour sẽ được áp dụng.

## **Dòng thời gian hoạt ảnh**

[**Sequence**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.sequence) là một tập hợp các hiệu ứng hoạt ảnh, được áp dụng trên một shape cụ thể.

[**AnimationTimeLine**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.animation_time_line) là một tập hợp các Sequence được sử dụng trong một slide cụ thể. Đây là một engine hoạt ảnh được giới thiệu từ PowerPoint 2002. Trong các phiên bản PowerPoint trước, việc thêm hiệu ứng hoạt ảnh vào bản thuyết trình gặp khó khăn và chỉ có thể thực hiện bằng các phương pháp thay thế khác nhau. Timeline thay thế lớp AnimationSettings cũ và cung cấp mô hình đối tượng rõ ràng hơn cho hoạt ảnh PowerPoint. Mỗi slide chỉ có một timeline hoạt ảnh.

## **Hoạt ảnh tương tác**

[**EffectTriggerType**](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) cho phép định nghĩa các hành động người dùng (ví dụ: nhấp chuột), sẽ làm cho một hoạt ảnh nhất định bắt đầu. Triggers chỉ được thêm vào phiên bản PowerPoint mới nhất.

## **Hoạt ảnh hình dạng**

Aspose.Slides cho phép áp dụng hoạt ảnh cho các shape, có thể là văn bản, hình chữ nhật, đường thẳng, khung, OLE Object, v.v.

{{% alert color="primary" %}} 
Đọc thêm [**Về hoạt ảnh hình dạng**](/slides/vi/cpp/shape-animation/).
{{% /alert %}}

## **Biểu đồ hoạt ảnh**

Để tạo biểu đồ hoạt ảnh, bạn nên sử dụng cùng các lớp như với các shape. Tuy nhiên, có thể áp dụng hoạt ảnh PowerPoint chỉ trên các danh mục hoặc chuỗi của biểu đồ. Bạn cũng có thể áp dụng hiệu ứng hoạt ảnh cho một phần tử danh mục hoặc phần tử chuỗi.

{{% alert color="primary" %}} 
Đọc thêm [**Về biểu đồ hoạt ảnh**](/slides/vi/cpp/animated-charts/).
{{% /alert %}}

## **Văn bản hoạt ảnh**

Ngoài văn bản hoạt ảnh, cũng có thể áp dụng hoạt ảnh cho một đoạn văn.

{{% alert color="primary" %}} 
Đọc thêm [**Về văn bản hoạt ảnh**](/slides/vi/cpp/animated-text/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các hoạt ảnh có được giữ lại khi xuất sang PDF không?**

Không. PDF là định dạng tĩnh, vì vậy các hoạt ảnh và [slide transitions](/slides/vi/cpp/slide-transition/) không được phát. Nếu bạn cần chuyển động, hãy xuất sang [HTML5](/slides/vi/cpp/export-to-html5/), [animated GIF](/slides/vi/cpp/convert-powerpoint-to-animated-gif/), hoặc [video](/slides/vi/cpp/convert-powerpoint-to-video/) thay thế.

**Tôi có thể chuyển bản thuyết trình hoạt ảnh thành video và kiểm soát tốc độ khung hình và kích thước khung hình không?**

Có. Bạn có thể [render the presentation as frames](/slides/vi/cpp/convert-powerpoint-to-video/) và mã hoá chúng thành video (ví dụ, bằng ffmpeg), lựa chọn FPS và độ phân giải. Các hoạt ảnh và slide transitions được phát trong quá trình render.

**Các hoạt ảnh có vẫn giữ nguyên khi làm việc với ODP (không chỉ PPTX) không?**

PPT, PPTX và ODP được hỗ trợ để [đọc](/slides/vi/cpp/open-presentation/) và [ghi](/slides/vi/cpp/save-presentation/), nhưng sự khác biệt về định dạng có nghĩa là một số hiệu ứng có thể hiển thị hoặc hoạt động hơi khác nhau. Hãy kiểm tra các trường hợp quan trọng với mẫu thực.