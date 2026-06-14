---
title: Cải thiện các bản trình chiếu PowerPoint với hoạt hình trong JavaScript
linktitle: Hoạt hình PowerPoint
type: docs
weight: 150
url: /vi/nodejs-java/powerpoint-animation/
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
- biểu đồ động
- văn bản động
- hình dạng động
- đối tượng OLE động
- hình ảnh động
- bảng động
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Sử dụng Aspose.Slides cho Node.js qua Java để xử lý hoạt hình PowerPoint. Tổng quan này nêu bật các tính năng chính và cung cấp những hiểu biết để cải thiện các bản trình chiếu của bạn."
---
## **Giới thiệu**

Vì các bài thuyết trình nhằm mục đích trình bày một nội dung, nên hình thức trực quan và hành vi tương tác luôn được cân nhắc khi tạo chúng.

**PowerPoint animation** đóng vai trò quan trọng để làm cho bài thuyết trình hấp dẫn và thu hút người xem. Aspose.Slides cho Node.js qua Java cung cấp nhiều tùy chọn để thêm hoạt hình vào bản trình chiếu PowerPoint:

- áp dụng các loại hiệu ứng hoạt hình PowerPoint khác nhau lên các hình dạng, biểu đồ, bảng, Đối tượng OLE và các yếu tố khác của bản trình chiếu.
- sử dụng nhiều hiệu ứng hoạt hình PowerPoint trên một hình dạng.
- sử dụng dòng thời gian hoạt hình để kiểm soát các hiệu ứng hoạt hình.
- tạo hoạt hình tùy chỉnh.

Trong Aspose.Slides cho Node.js qua Java, các hiệu ứng hoạt hình khác nhau có thể được áp dụng lên các hình dạng. Vì mọi yếu tố trên slide, bao gồm văn bản, hình ảnh, Đối tượng OLE, bảng, vv, đều được coi là một hình dạng, nên chúng ta có thể áp dụng hiệu ứng hoạt hình lên mọi yếu tố của một slide.

## **Hiệu ứng hoạt hình**
Aspose.Slides hỗ trợ **hơn 150 hiệu ứng hoạt hình**, bao gồm các hiệu ứng cơ bản như Bounce, PathFootball, Zoom và các hiệu ứng đặc biệt như OLEObjectShow, OLEObjectOpen. Bạn có thể xem danh sách đầy đủ các hiệu ứng hoạt hình trong liệt kê[**EffectType**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effecttype/) .

Ngoài ra, các hiệu ứng hoạt hình này có thể được sử dụng kết hợp với chúng:

- [ColorEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SetEffect)

## **Hoạt hình tùy chỉnh**
Bạn có thể tạo **hoạt hình tùy chỉnh** của riêng mình trong Aspose.Slides. Điều này có thể thực hiện được khi bạn kết hợp một số hành vi lại thành một hoạt hình tùy chỉnh mới.

[**Behavior**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Behavior) là đơn vị cấu thành của bất kỳ hiệu ứng hoạt hình PowerPoint nào. Tất cả các hiệu ứng hoạt hình thực chất là một tập hợp các hành vi được kết hợp thành một chiến lược. Bạn có thể kết hợp các hành vi thành một hoạt hình tùy chỉnh một lần và tái sử dụng nó trong các bản trình chiếu khác. Nếu bạn thêm một hành vi mới vào một hiệu ứng hoạt hình PowerPoint tiêu chuẩn - nó sẽ trở thành một hoạt hình tùy chỉnh khác. Ví dụ, bạn có thể thêm hành vi lặp lại vào một hoạt hình để làm cho nó lặp lại vài lần.

[**Animation Point**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Point) là điểm mà hành vi sẽ được áp dụng.

## **Dòng thời gian hoạt hình**
[**Sequence**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Sequence) là một tập hợp các hiệu ứng hoạt hình, được áp dụng lên một hình dạng cụ thể.

[**Timeline**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AnimationTimeLine) là một tập hợp các Sequence được sử dụng trong một slide cụ thể. Đây là một engine hoạt hình được giới thiệu từ PowerPoint 2002. Trong các phiên bản PowerPoint trước đây, việc thêm hiệu ứng hoạt hình vào bản trình chiếu gặp nhiều khó khăn và chỉ có thể thực hiện bằng các cách giải quyết khác nhau. Timeline được đưa ra để thay thế lớp AnimationSettings cũ và cung cấp mô hình đối tượng rõ ràng hơn cho hoạt hình PowerPoint. Một slide chỉ có thể có một dòng thời gian hoạt hình.

## **Hoạt hình tương tác**
[**Trigger**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/EffectTriggerType) cho phép định nghĩa các hành động của người dùng (ví dụ: nhấp nút), sẽ làm cho một hoạt hình nhất định bắt đầu. Triggers chỉ được bổ sung trong phiên bản PowerPoint mới nhất.

## **Hoạt hình hình dạng**
Aspose.Slides cho phép áp dụng hoạt hình cho các hình dạng, có thể là văn bản, hình chữ nhật, đường thẳng, khung, Đối tượng OLE, v.v.

{{% alert color="primary" %}} 
Đọc thêm [**Về Hoạt hình Hình dạng**](/slides/vi/nodejs-java/shape-animation/).
{{% /alert %}}

## **Biểu đồ động**
Để tạo biểu đồ động, bạn nên sử dụng cùng các lớp như với các hình dạng. Tuy nhiên, có thể áp dụng hoạt hình PowerPoint chỉ trên các danh mục biểu đồ hoặc các chuỗi biểu đồ. Bạn cũng có thể áp dụng hiệu ứng hoạt hình lên một phần tử danh mục hoặc phần tử chuỗi.

{{% alert color="primary" %}} 
Đọc thêm [**Về Biểu đồ Động**](/slides/vi/nodejs-java/animated-charts/).
{{% /alert %}}

## **Văn bản động**
Ngoài văn bản động, bạn cũng có thể áp dụng hoạt hình cho một đoạn văn.

{{% alert color="primary" %}} 
Đọc thêm [**Về Văn bản Động**](/slides/vi/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Các hoạt hình có được giữ lại khi xuất ra PDF không?**

Không. PDF là định dạng tĩnh, vì vậy các hoạt hình và [chuyển đổi slide](/slides/vi/nodejs-java/slide-transition/) không được phát. Nếu bạn cần chuyển động, hãy xuất ra [HTML5](/slides/vi/nodejs-java/export-to-html5/), [animated GIF](/slides/vi/nodejs-java/convert-powerpoint-to-animated-gif/), hoặc [video](/slides/vi/nodejs-java/convert-powerpoint-to-video/) thay thế.

**Tôi có thể chuyển một bản trình chiếu động thành video và điều chỉnh tốc độ khung và kích thước khung hình không?**

Có. Bạn có thể [kết xuất bản trình chiếu thành khung](/slides/vi/nodejs-java/convert-powerpoint-to-video/) và mã hoá chúng thành video (ví dụ: bằng ffmpeg), chọn FPS và độ phân giải. Các hoạt hình và chuyển đổi slide được phát trong quá trình render.

**Các hoạt hình có giữ nguyên khi làm việc với ODP (không chỉ PPTX) không?**

PPT, PPTX và ODP được hỗ trợ để [đọc](/slides/vi/nodejs-java/open-presentation/) và [ghi](/slides/vi/nodejs-java/save-presentation/), nhưng sự khác biệt về định dạng có nghĩa là một số hiệu ứng có thể hiển thị hoặc hoạt động hơi khác nhau. Hãy xác thực các trường hợp quan trọng bằng các mẫu thực tế.