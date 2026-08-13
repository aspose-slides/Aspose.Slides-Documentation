---
title: Nâng cao bản trình bày PowerPoint với các hoạt hình trong C++
linktitle: Hoạt hình PowerPoint
type: docs
weight: 150
url: /vi/cpp/powerpoint-animation/
keywords:
- thêm hoạt hình
- cập nhật hoạt hình
- thay đổi hoạt hình
- xóa hoạt hình
- quản lý hoạt hình
- kiểm soát hoạt hình
- hiệu ứng hoạt hình
- hoạt hình PowerPoint
- dòng thời gian hoạt hình
- hoạt hình tương tác
- hoạt hình tùy chỉnh
- hoạt hình hình dạng
- biểu đồ hoạt hình
- văn bản hoạt hình
- hình dạng hoạt hình
- đối tượng OLE hoạt hình
- hình ảnh hoạt hình
- bảng hoạt hình
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Tìm hiểu cách thêm và kiểm soát các hiệu ứng hoạt hình nâng cao trong Aspose.Slides cho C++ để tạo các bản trình bày PowerPoint và OpenDocument động."
---
## **Giới thiệu**

Vì các bản trình bày nhằm mục đích trình bày một nội dung, nên giao diện trực quan và hành vi tương tác luôn được cân nhắc khi tạo chúng.

**PowerPoint animation** đóng một vai trò quan trọng để làm cho bản trình bày thu hút và hấp dẫn đối với người xem. Aspose.Slides for C++ cung cấp một loạt các tùy chọn để **thêm hoạt hình** vào bản trình bày PowerPoint:

- áp dụng các loại hiệu ứng hoạt hình PowerPoint khác nhau cho các hình dạng, biểu đồ, bảng, Đối tượng OLE và các thành phần khác của bản trình bày.  
- sử dụng nhiều hiệu ứng hoạt hình PowerPoint cho một hình dạng.  
- sử dụng dòng thời gian hoạt hình để kiểm soát các hiệu ứng hoạt hình.  
- tạo hoạt hình tùy chỉnh.

Trong Aspose.Slides for C++, các hiệu ứng hoạt hình khác nhau có thể được áp dụng cho các hình dạng. Vì mọi thành phần trên slide bao gồm văn bản, hình ảnh, Đối tượng OLE, bảng, v.v. đều được coi là một hình dạng, nên chúng ta có thể áp dụng hiệu ứng hoạt hình cho mọi thành phần của slide.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides.animation) **namespace** cung cấp các lớp để làm việc với hoạt hình PowerPoint.

## **Hiệu ứng hoạt hình**

Aspose.Slides hỗ trợ **hơn 150 hiệu ứng hoạt hình**, bao gồm các hiệu ứng cơ bản như Bounce, PathFootball, Zoom và các hiệu ứng đặc thù như OLEObjectShow, OLEObjectOpen. Bạn có thể xem danh sách đầy đủ các hiệu ứng hoạt hình trong [**EffectType**](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31)enumeration.

Ngoài ra, các hiệu ứng hoạt hình này có thể được sử dụng kết hợp với nhau:

- [ColorEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.set_effect)

## **Hoạt hình tùy chỉnh**

Bạn có thể tạo **hoạt hình tùy chỉnh** của riêng mình trong Aspose.Slides.  
Điều này có thể đạt được nếu bạn kết hợp một số hành vi lại với nhau thành một hoạt hình tùy chỉnh mới.

[**Behavior**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.behavior) là một đơn vị cấu thành của bất kỳ hiệu ứng hoạt hình PowerPoint nào. Tất cả các hiệu ứng hoạt hình thực tế là một tập hợp các hành vi được hợp thành một chiến lược. Bạn có thể kết hợp các hành vi thành một hoạt hình tùy chỉnh một lần và tái sử dụng nó trong các bản trình bày khác. Nếu bạn thêm một hành vi mới vào một hiệu ứng hoạt hình PowerPoint tiêu chuẩn – nó sẽ trở thành một hoạt hình tùy chỉnh khác. Ví dụ, bạn có thể thêm hành vi lặp lại vào một hoạt hình để nó lặp lại vài lần.

[**Animation Point**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.point) là một điểm nơi hành vi sẽ được áp dụng.

## **Dòng thời gian hoạt hình**

[**Sequence**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.sequence) là một tập hợp các hiệu ứng hoạt hình, được áp dụng trên một hình dạng cụ thể.

[**AnimationTimeLine**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.animation_time_line) là một tập hợp các Sequence được sử dụng trong một slide cụ thể. Đây là một engine hoạt hình được giới thiệu từ PowerPoint 2002. Trong các phiên bản PowerPoint trước đó, việc thêm hiệu ứng hoạt hình vào bản trình bày khá khó khăn và chỉ có thể thực hiện được qua các cách giải quyết khác nhau. Dòng thời gian này thay thế lớp AnimationSettings cũ và cung cấp mô hình đối tượng rõ ràng hơn cho hoạt hình PowerPoint. Một slide chỉ có **một** dòng thời gian hoạt hình.

## **Hoạt hình tương tác**

[**EffectTriggerType**](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) cho phép định nghĩa các hành động người dùng (ví dụ: nhấp nút) sẽ làm cho một hoạt hình nhất định bắt đầu. Triggers chỉ được thêm vào phiên bản PowerPoint mới nhất.

## **Hoạt hình hình dạng**

Aspose.Slides cho phép áp dụng hoạt hình cho các hình dạng, có thể là văn bản, hình chữ nhật, đường thẳng, khung, Đối tượng OLE, v.v.

{{% alert color="info" %}} 
Đọc thêm [**Về Hoạt hình Hình dạng**](/slides/vi/cpp/shape-animation/).
{{% /alert %}}

## **Biểu đồ hoạt hình**

Để tạo biểu đồ hoạt hình, bạn nên sử dụng các lớp tương tự như với các hình dạng. Tuy nhiên, bạn chỉ có thể áp dụng hoạt hình PowerPoint cho các danh mục biểu đồ hoặc các chuỗi biểu đồ. Bạn cũng có thể áp dụng hiệu ứng hoạt hình cho một phần tử danh mục hoặc một phần tử chuỗi.

{{% alert color="info" %}} 
Đọc thêm [**Về Biểu đồ Hoạt hình**](/slides/vi/cpp/animated-charts/).
{{% /alert %}}

## **Văn bản hoạt hình**

Ngoài văn bản hoạt hình, bạn cũng có thể áp dụng hoạt hình cho một đoạn văn.

{{% alert color="info" %}} 
Đọc thêm [**Về Văn bản Hoạt hình**](/slides/vi/cpp/animated-text/).
{{% /alert %}}

## **Câu hỏi thường gặp**

### Hoạt hình có được giữ lại khi xuất ra PDF không?

Không. PDF là định dạng tĩnh, vì vậy hoạt hình và [slide transitions](/slides/vi/cpp/slide-transition/) không được phát. Nếu bạn cần chuyển động, hãy xuất sang [HTML5](/slides/vi/cpp/export-to-html5/), [animated GIF](/slides/vi/cpp/convert-powerpoint-to-animated-gif/) hoặc [video](/slides/vi/cpp/convert-powerpoint-to-video/) thay thế.

### Tôi có thể chuyển bản trình bày hoạt hình thành video và kiểm soát tốc độ khung hình và kích thước khung hình không?

Có. Bạn có thể [render the presentation as frames](/slides/vi/cpp/convert-powerpoint-to-video/) và mã hoá chúng thành video (ví dụ: bằng ffmpeg), chọn FPS và độ phân giải. Các hoạt hình và chuyển đổi slide sẽ được phát trong quá trình render.

### Hoạt hình có giữ nguyên khi làm việc với ODP (không chỉ PPTX) không?

PPT, PPTX và ODP được hỗ trợ để [reading](/slides/vi/cpp/open-presentation/) và [writing](/slides/vi/cpp/save-presentation/), nhưng sự khác biệt về định dạng có nghĩa là một số hiệu ứng có thể hiển thị hoặc hoạt động hơi khác nhau. Hãy kiểm tra các trường hợp quan trọng bằng các mẫu thực tế.