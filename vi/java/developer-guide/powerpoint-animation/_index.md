---
title: Nâng cao bản trình bày PowerPoint với hoạt ảnh trong Java
linktitle: Hoạt ảnh PowerPoint
type: docs
weight: 150
url: /vi/java/powerpoint-animation/
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
- Java
- Aspose.Slides
description: "Khám phá khả năng của Aspose.Slides cho Java trong việc xử lý hoạt ảnh PowerPoint. Tổng quan chung này nêu bật các tính năng chính và cung cấp những hiểu biết để nâng cao các bản trình bày của bạn."
---
## **Giới thiệu**

Vì các bài thuyết trình được tạo ra để trình bày một nội dung nào đó, nên diện mạo trực quan và hành vi tương tác luôn được cân nhắc trong quá trình tạo.

**PowerPoint animation** đóng vai trò quan trọng trong việc làm cho bài thuyết trình thu hút và gây hứng thú cho người xem. Aspose.Slides cung cấp nhiều tùy chọn để thêm hoạt ảnh vào các bài thuyết trình PowerPoint:

- Áp dụng các loại hiệu ứng hoạt ảnh PowerPoint khác nhau cho các hình dạng, biểu đồ, bảng, đối tượng OLE và các yếu tố khác của bài thuyết trình.
- Sử dụng nhiều hiệu ứng hoạt ảnh PowerPoint trên một hình dạng duy nhất.
- Sử dụng dòng thời gian hoạt ảnh để điều khiển các hiệu ứng.
- Tạo hoạt ảnh tùy chỉnh.

## **Hiệu ứng hoạt ảnh**

Aspose.Slides hỗ trợ **hơn 150 hiệu ứng hoạt ảnh**, bao gồm các hiệu ứng cơ bản như Bounce, PathFootball và Zoom, và các hiệu ứng cụ thể như OLEObjectShow và OLEObjectOpen. Bạn có thể tìm danh sách đầy đủ trong lớp [EffectType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effecttype/).

Ngoài ra, các hiệu ứng hoạt ảnh này có thể được sử dụng kết hợp với các hành vi sau:

- [ColorEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SetEffect)

## **Hoạt ảnh tùy chỉnh**

Đối với các ví dụ Java đầy đủ tạo, kiểm tra và sửa đổi hành vi và các đường chuyển động có thể chỉnh sửa, xem [Hoạt ảnh tùy chỉnh](/slides/vi/java/custom-animation/).

Bạn có thể tạo **hoạt ảnh tùy chỉnh** của riêng mình trong Aspose.Slides. Điều này có thể thực hiện bằng cách kết hợp một số hành vi thành một hoạt ảnh tùy chỉnh mới.

[Behavior](https://reference.aspose.com/slides/vi/java/com.aspose.slides/behavior/) là khối xây dựng của một hiệu ứng hoạt ảnh PowerPoint. Kết hợp các hành vi để tùy chỉnh một hiệu ứng, hoặc thêm một hành vi để mở rộng một hiệu ứng đã định nghĩa trước. Việc lặp lại được cấu hình thông qua cài đặt thời gian thay vì một hành vi lặp riêng biệt.

[Animation Point](https://reference.aspose.com/slides/vi/java/com.aspose.slides/point/) là điểm mà tại đó một hành vi nên được áp dụng.

## **Dòng thời gian hoạt ảnh**

[Sequence](https://reference.aspose.com/slides/vi/java/com.aspose.slides/sequence/) là một tập hợp các hiệu ứng hoạt ảnh có thể nhắm mục tiêu đến các hình dạng khác nhau.

[Timeline](https://reference.aspose.com/slides/vi/java/com.aspose.slides/animationtimeline/) là một tập hợp các sequence được sử dụng trong một slide cụ thể. Đây là một động cơ hoạt ảnh được giới thiệu trong PowerPoint 2002. Trong các phiên bản PowerPoint trước đó, việc thêm hiệu ứng hoạt ảnh vào bài thuyết trình khá khó khăn và chỉ có thể thực hiện bằng nhiều cách khắc phục khác nhau. Dòng thời gian cung cấp một mô hình đối tượng rõ ràng hơn cho các hoạt ảnh PowerPoint. Một slide chỉ có thể có một dòng thời gian hoạt ảnh.

## **Hoạt ảnh tương tác**

[Trigger](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effecttriggertype/) cho phép bạn định nghĩa các hành động người dùng, chẳng hạn như nhấn nút, để bắt đầu một hoạt ảnh cụ thể.

## **Hoạt ảnh hình dạng**

Aspose.Slides cho phép bạn áp dụng hoạt ảnh cho các hình dạng, có thể bao gồm văn bản, hình chữ nhật, đường, khung, đối tượng OLE và nhiều hơn nữa.

{{% alert color="info" title="Note" %}}
Đọc thêm [**Về Hoạt ảnh Hình dạng**](/slides/vi/java/shape-animation/).
{{% /alert %}}

## **Biểu đồ động**

Để tạo biểu đồ động, bạn nên sử dụng cùng các lớp như đối với hình dạng. Tuy nhiên, hoạt ảnh PowerPoint chỉ có thể được áp dụng cho các danh mục biểu đồ hoặc chuỗi biểu đồ. Bạn cũng có thể áp dụng hiệu ứng hoạt ảnh cho một phần tử danh mục hoặc một phần tử chuỗi.

{{% alert color="info" title="Note" %}}
Đọc thêm [**Về Biểu đồ Động**](/slides/vi/java/animated-charts/).
{{% /alert %}}

## **Văn bản động**

Ngoài việc hoạt ảnh văn bản, bạn còn có thể áp dụng hoạt ảnh cho một đoạn văn.

{{% alert color="info" title="Note" %}}
Đọc thêm [**Về Văn bản Động**](/slides/vi/java/animated-text/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Hoạt ảnh có được giữ lại khi xuất sang PDF không?**

Không. PDF là định dạng tĩnh, vì vậy hoạt ảnh và [slide transitions](/slides/vi/java/slide-transition/) không được phát. Nếu bạn cần chuyển động, hãy xuất sang [HTML5](/slides/vi/java/export-to-html5/), [animated GIF](/slides/vi/java/convert-powerpoint-to-animated-gif/), hoặc [video](/slides/vi/java/convert-powerpoint-to-video/) thay vào đó.

**Tôi có thể chuyển một bài thuyết trình động thành video và kiểm soát tốc độ khung và kích thước khung hình không?**

Có. Bạn có thể [render the presentation as frames](/slides/vi/java/convert-powerpoint-to-video/) và mã hoá chúng thành video (ví dụ, bằng ffmpeg), lựa chọn FPS và độ phân giải. Các hoạt ảnh và chuyển tiếp slide được phát trong quá trình render.

**Hoạt ảnh có vẫn giữ nguyên khi làm việc với ODP (không chỉ PPTX) không?**

PPT, PPTX và ODP được hỗ trợ để [reading](/slides/vi/java/open-presentation/) và [writing](/slides/vi/java/save-presentation/), nhưng điều này không đảm bảo việc giữ lại hoạt ảnh. Dữ liệu hoạt ảnh tùy chỉnh có thể bị mất khi chuyển đổi sang ODP. Xem [Custom Animation](/slides/vi/java/custom-animation/) để biết ví dụ và hướng dẫn kiểm tra tính tương thích định dạng.