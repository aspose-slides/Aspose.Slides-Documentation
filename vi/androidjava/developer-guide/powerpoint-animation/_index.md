---
title: Nâng cao Bản trình bày PowerPoint với Hoạt ảnh trên Android
linktitle: Hoạt ảnh PowerPoint
type: docs
weight: 150
url: /vi/androidjava/powerpoint-animation/
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
- biểu đồ động
- văn bản động
- hình dạng động
- đối tượng OLE động
- hình ảnh động
- bảng động
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: Khám phá khả năng của Aspose.Slides cho Android qua Java trong việc xử lý hoạt ảnh PowerPoint. Tổng quan chung này nêu bật các tính năng chính.
---
## **Giới thiệu**

Vì các bản trình bày được tạo ra để giới thiệu một thứ gì đó, nên khi tạo chúng luôn xem xét đến diện mạo trực quan và hành vi tương tác.

**PowerPoint animation** đóng một vai trò quan trọng để làm cho bản trình bày thu hút ánh nhìn và hấp dẫn đối với khán giả. Aspose.Slides for Android via Java cung cấp một loạt các tùy chọn để thêm hoạt ảnh vào bản trình bày PowerPoint:

- áp dụng các loại hiệu ứng hoạt ảnh PowerPoint khác nhau lên các hình dạng, biểu đồ, bảng, OLE Object và các thành phần trình bày khác.
- sử dụng nhiều hiệu ứng hoạt ảnh PowerPoint trên một hình dạng.
- sử dụng dòng thời gian hoạt ảnh để kiểm soát các hiệu ứng hoạt ảnh.
- tạo hoạt ảnh tùy chỉnh.

Trong Aspose.Slides for Android via Java, có thể áp dụng các hiệu ứng hoạt ảnh khác nhau lên các hình dạng. Vì mọi thành phần trên slide bao gồm văn bản, hình ảnh, OLE Object, bảng, v.v. đều được coi là một hình dạng, nên chúng ta có thể áp dụng hiệu ứng hoạt ảnh cho mọi thành phần của một slide.

## **Hiệu ứng hoạt ảnh**
Aspose.Slides hỗ trợ **hơn 150 hiệu ứng hoạt ảnh**, bao gồm các hiệu ứng cơ bản như Bounce, PathFootball, hiệu ứng Zoom và các hiệu ứng đặc thù như OLEObjectShow, OLEObjectOpen. Bạn có thể tìm danh sách đầy đủ các hiệu ứng hoạt ảnh trong liệt kê [**EffectType**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/effecttype/).

Thêm nữa, các hiệu ứng hoạt ảnh này có thể được sử dụng kết hợp với chúng:

- [ColorEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SetEffect)

## **Hoạt ảnh tùy chỉnh**
Bạn có thể tạo **hoạt ảnh tùy chỉnh** của riêng mình trong Aspose.Slides. Điều này có thể đạt được khi bạn kết hợp nhiều hành vi lại thành một hoạt ảnh tùy chỉnh mới.

[**Behavior**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Behavior) là đơn vị xây dựng của bất kỳ hiệu ứng hoạt ảnh PowerPoint nào. Tất cả các hiệu ứng hoạt ảnh thực chất là một tập hợp các hành vi được kết hợp thành một chiến lược. Bạn có thể kết hợp các hành vi thành một hoạt ảnh tùy chỉnh một lần và tái sử dụng nó trong các bản trình bày khác. Nếu bạn thêm một hành vi mới vào một hiệu ứng hoạt ảnh PowerPoint tiêu chuẩn - nó sẽ trở thành một hoạt ảnh tùy chỉnh khác. Ví dụ, bạn có thể thêm hành vi lặp lại vào một hoạt ảnh để nó lặp lại một vài lần.

[**Animation Point**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Point) là điểm mà hành vi nên được áp dụng.

## **Dòng thời gian hoạt ảnh**
[**Sequence**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Sequence) là một tập hợp các hiệu ứng hoạt ảnh, được áp dụng trên một hình dạng cụ thể.

[**Timeline**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/AnimationTimeLine) là một tập hợp các Sequence được sử dụng trong một slide cụ thể. Đó là một engine hoạt ảnh được giới thiệu từ PowerPoint 2002. Trong các phiên bản PowerPoint trước, việc thêm hiệu ứng hoạt ảnh vào bản trình bày là khá khó khăn và chỉ có thể thực hiện bằng các giải pháp thay thế khác nhau. Timeline được đưa ra để thay thế lớp AnimationSettings cũ và cung cấp mô hình đối tượng rõ ràng hơn cho hoạt ảnh PowerPoint. Mỗi slide chỉ có thể có một dòng thời gian hoạt ảnh.

## **Hoạt ảnh tương tác**
[**Trigger**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/EffectTriggerType) cho phép định nghĩa các hành động của người dùng (ví dụ: nhấn nút), khiến một hoạt ảnh nhất định bắt đầu. Triggers chỉ được thêm vào phiên bản PowerPoint mới nhất.

## **Hoạt ảnh hình dạng**
Aspose.Slides cho phép áp dụng hoạt ảnh cho các hình dạng, có thể là văn bản, hình chữ nhật, đường thẳng, khung, OLE Object, v.v.

{{% alert color="info" %}} 
Đọc thêm [**Về hoạt ảnh hình dạng**](/slides/vi/androidjava/shape-animation/).
{{% /alert %}}

## **Biểu đồ động**
Để tạo biểu đồ động, bạn nên sử dụng cùng các lớp như với các hình dạng. Tuy nhiên, có thể chỉ áp dụng hoạt ảnh PowerPoint cho các danh mục biểu đồ hoặc chuỗi biểu đồ. Bạn cũng có thể áp dụng hiệu ứng hoạt ảnh cho một phần tử danh mục hoặc phần tử chuỗi.

{{% alert color="info" %}} 
Đọc thêm [**Về biểu đồ động**](/slides/vi/androidjava/animated-charts/).
{{% /alert %}}

## **Văn bản động**
Ngoài văn bản động, bạn cũng có thể áp dụng hoạt ảnh cho một đoạn văn.

{{% alert color="info" %}} 
Đọc thêm [**Về văn bản động**](/slides/vi/androidjava/animated-text/).
{{% /alert %}}

## **Câu hỏi thường gặp**

### Các hoạt ảnh có được giữ lại khi xuất ra PDF không?
Không. PDF là định dạng tĩnh, vì vậy các hoạt ảnh và [slide transitions](/slides/vi/androidjava/slide-transition/) không được phát. Nếu bạn cần chuyển động, hãy xuất ra [HTML5](/slides/vi/androidjava/export-to-html5/), [animated GIF](/slides/vi/androidjava/convert-powerpoint-to-animated-gif/), hoặc [video](/slides/vi/androidjava/convert-powerpoint-to-video/) thay thế.

### Tôi có thể chuyển một bản trình bày động thành video và kiểm soát tốc độ khung hình và kích thước khung hình không?
Có. Bạn có thể [render the presentation as frames](/slides/vi/androidjava/convert-powerpoint-to-video/) và mã hoá chúng thành video (ví dụ, qua ffmpeg), chọn FPS và độ phân giải. Các hoạt ảnh và slide transitions được phát trong quá trình render.

### Các hoạt ảnh có giữ nguyên khi làm việc với ODP (không chỉ PPTX) không?
PPT, PPTX và ODP đều được hỗ trợ để [reading](/slides/vi/androidjava/open-presentation/) và [writing](/slides/vi/androidjava/save-presentation/), nhưng sự khác nhau về định dạng có nghĩa là một số hiệu ứng có thể trông hoặc hoạt động hơi khác nhau. Hãy kiểm tra các trường hợp quan trọng với các mẫu thực tế.