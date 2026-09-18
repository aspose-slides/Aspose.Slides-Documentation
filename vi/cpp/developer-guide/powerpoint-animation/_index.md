---
title: Nâng cao bài thuyết trình PowerPoint với hoạt ảnh trong C++
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
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tìm hiểu cách thêm và kiểm soát các hiệu ứng hoạt ảnh nâng cao trong Aspose.Slides cho C++ để tạo các bài thuyết trình PowerPoint và OpenDocument động."
---
## **Giới thiệu**

Vì các bài thuyết trình nhằm mục đích trình bày một nội dung, nên diện mạo trực quan và hành vi tương tác luôn được cân nhắc trong quá trình tạo.

**PowerPoint animation** đóng vai trò quan trọng trong việc làm cho một bài thuyết trình thu hút và lôi cuốn người xem. Aspose.Slides cung cấp nhiều tùy chọn để thêm hoạt ảnh vào các bài thuyết trình PowerPoint:

- Áp dụng các loại hiệu ứng hoạt ảnh PowerPoint khác nhau lên các hình dạng, biểu đồ, bảng, đối tượng OLE và các yếu tố khác của bài thuyết trình.
- Sử dụng nhiều hiệu ứng hoạt ảnh PowerPoint trên cùng một hình dạng.
- Sử dụng dòng thời gian hoạt ảnh để điều khiển các hiệu ứng hoạt ảnh.
- Tạo các hoạt ảnh tùy chỉnh.

Trong Aspose.Slides, có thể áp dụng các hiệu ứng hoạt ảnh khác nhau cho các hình dạng. Vì mọi yếu tố trên slide, bao gồm văn bản, hình ảnh, đối tượng OLE và bảng, đều được coi là một hình dạng, nên các hiệu ứng hoạt ảnh có thể được áp dụng cho bất kỳ yếu tố nào trên slide.

Không gian tên [Aspose::Slides::Animation](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/) cung cấp các lớp để làm việc với hoạt ảnh PowerPoint.

## **Hiệu ứng hoạt ảnh**
Aspose.Slides hỗ trợ **hơn 150 hiệu ứng hoạt ảnh**, bao gồm các hiệu ứng cơ bản như Bounce, PathFootball và Zoom, và các hiệu ứng riêng biệt như OLEObjectShow và OLEObjectOpen. Bạn có thể xem danh sách đầy đủ trong enumeration [EffectType](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/effecttype/).

Ngoài ra, các hiệu ứng hoạt ảnh này có thể được sử dụng kết hợp với các hành vi sau:

- [ColorEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/seteffect/)

## **Hoạt ảnh tùy chỉnh**

Đối với các ví dụ đầy đủ bằng C++ tạo, kiểm tra và sửa đổi hành vi và các đường chuyển động có thể chỉnh sửa, xem [Hoạt ảnh tùy chỉnh](/slides/vi/cpp/custom-animation/).

Bạn có thể tạo **hoạt ảnh tùy chỉnh** của riêng mình trong Aspose.Slides. Điều này có thể đạt được bằng cách kết hợp một số hành vi thành một hoạt ảnh tùy chỉnh mới.

[Behavior](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/behavior/) là khối xây dựng của một hiệu ứng hoạt ảnh PowerPoint. Kết hợp các hành vi để tùy chỉnh một hiệu ứng, hoặc thêm một hành vi để mở rộng hiệu ứng đã định nghĩa trước. Sự lặp lại được cấu hình thông qua cài đặt thời gian chứ không phải một hành vi lặp riêng.

[Animation Point](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/point/) là một điểm mà tại đó một hành vi nên được áp dụng.

## **Dòng thời gian hoạt ảnh**
[Sequence](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/sequence/) là một tập hợp các hiệu ứng hoạt ảnh có thể nhắm tới các hình dạng khác nhau.

[IAnimationTimeLine](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ianimationtimeline/) là một tập hợp các sequence được sử dụng trong một slide cụ thể. Đó là một động cơ hoạt ảnh được giới thiệu trong PowerPoint 2002. Trong các phiên bản PowerPoint trước đó, việc thêm hiệu ứng hoạt ảnh vào bài thuyết trình rất khó khăn và chỉ có thể thực hiện bằng nhiều cách khắc phục. Dòng thời gian cung cấp một mô hình đối tượng rõ ràng hơn cho các hoạt ảnh PowerPoint. Một slide chỉ có thể có một dòng thời gian hoạt ảnh.

## **Hoạt ảnh tương tác**
[Trigger](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/effecttriggertype/) cho phép bạn định nghĩa các hành động của người dùng, chẳng hạn như nhấp nút, để khởi động một hoạt ảnh cụ thể.

## **Hoạt ảnh hình dạng**
Aspose.Slides cho phép bạn áp dụng hoạt ảnh cho các hình dạng, có thể bao gồm văn bản, hình chữ nhật, đường thẳng, khung, đối tượng OLE và nhiều hơn nữa.

{{% alert color="info" title="Note" %}}
Đọc thêm [**Về hoạt ảnh hình dạng**](/slides/vi/cpp/shape-animation/).
{{% /alert %}}

## **Biểu đồ hoạt ảnh**
Để tạo biểu đồ hoạt ảnh, bạn nên sử dụng các lớp giống như với hình dạng. Tuy nhiên, các hoạt ảnh PowerPoint chỉ có thể được áp dụng cho các danh mục biểu đồ hoặc chuỗi biểu đồ. Bạn cũng có thể áp dụng hiệu ứng hoạt ảnh cho một phần tử danh mục hoặc một phần tử chuỗi.

{{% alert color="info" title="Note" %}}
Đọc thêm [**Về biểu đồ hoạt ảnh**](/slides/vi/cpp/animated-charts/).
{{% /alert %}}

## **Văn bản hoạt ảnh**
Ngoài việc hoạt ảnh cho văn bản, bạn cũng có thể áp dụng hoạt ảnh cho một đoạn văn.

{{% alert color="info" title="Note" %}}
Đọc thêm [**Về văn bản hoạt ảnh**](/slides/vi/cpp/animated-text/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các hoạt ảnh có được giữ lại khi xuất sang PDF không?**

Không. PDF là định dạng tĩnh, vì vậy các hoạt ảnh và [slide transitions](/slides/vi/cpp/slide-transition/) không phát. Nếu bạn cần chuyển động, hãy xuất sang [HTML5](/slides/vi/cpp/export-to-html5/), [animated GIF](/slides/vi/cpp/convert-powerpoint-to-animated-gif/) hoặc [video](/slides/vi/cpp/convert-powerpoint-to-video/) thay thế.

**Tôi có thể chuyển một bài thuyết trình hoạt ảnh thành video và điều chỉnh tỉ lệ khung hình và kích thước khung hình không?**

Có. Bạn có thể [kết xuất bài thuyết trình thành các khung](/slides/vi/cpp/convert-powerpoint-to-video/) và mã hoá chúng thành video (ví dụ, qua ffmpeg), chọn FPS và độ phân giải. Các hoạt ảnh và slide transitions được phát trong quá trình render.

**Các hoạt ảnh có vẫn giữ nguyên khi làm việc với ODP (không chỉ PPTX) không?**

PPT, PPTX và ODP được hỗ trợ để [reading](/slides/vi/cpp/open-presentation/) và [writing](/slides/vi/cpp/save-presentation/), nhưng điều này không đảm bảo việc bảo tồn các hoạt ảnh. Dữ liệu hoạt ảnh tùy chỉnh có thể bị mất khi chuyển đổi sang ODP. Xem [Custom Animation](/slides/vi/cpp/custom-animation/) để biết ví dụ và hướng dẫn kiểm tra tính tương thích định dạng.