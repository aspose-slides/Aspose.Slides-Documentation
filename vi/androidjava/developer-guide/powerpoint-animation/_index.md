---
title: Nâng cao Bài thuyết trình PowerPoint với Hoạt ảnh trên Android
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
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Khám phá khả năng của Aspose.Slides cho Android thông qua Java trong việc xử lý hoạt ảnh PowerPoint. Tổng quan chung này nêu bật các tính năng chính."
---
## **Giới thiệu**

Vì các bản trình bày được tạo ra để trình bày một nội dung, hình thức trực quan và hành vi tương tác luôn được xem xét khi tạo.

**PowerPoint animation** đóng vai trò quan trọng trong việc làm cho bản trình bày thu hút và lôi cuốn người xem. Aspose.Slides cung cấp nhiều tùy chọn để thêm hoạt ảnh vào các bản trình chiếu PowerPoint:

- Áp dụng các loại hiệu ứng hoạt ảnh PowerPoint khác nhau cho các hình dạng, biểu đồ, bảng, đối tượng OLE và các thành phần trình bày khác.
- Sử dụng nhiều hiệu ứng hoạt ảnh PowerPoint trên một hình dạng duy nhất.
- Sử dụng dòng thời gian hoạt ảnh để kiểm soát các hiệu ứng hoạt ảnh.
- Tạo hoạt ảnh tùy chỉnh.

Trong Aspose.Slides, có thể áp dụng nhiều hiệu ứng hoạt ảnh cho các hình dạng. Vì mọi thành phần trên một slide, bao gồm văn bản, hình ảnh, đối tượng OLE và bảng, đều được xem là một hình dạng, các hiệu ứng hoạt ảnh có thể được áp dụng cho bất kỳ thành phần nào trên slide.

## **Hiệu ứng hoạt ảnh**

Aspose.Slides hỗ trợ **hơn 150 hiệu ứng hoạt ảnh**, bao gồm các hiệu ứng cơ bản như Bounce, PathFootball và Zoom, và các hiệu ứng đặc thù như OLEObjectShow và OLEObjectOpen. Bạn có thể xem danh sách đầy đủ trong lớp [EffectType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/effecttype/).

Ngoài ra, các hiệu ứng hoạt ảnh này có thể được kết hợp với các hành vi sau:

- [ColorEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SetEffect)

## **Hoạt ảnh tùy chỉnh**

Đối với các ví dụ Java đầy đủ về việc tạo, kiểm tra và chỉnh sửa hành vi cũng như các đường chuyển động có thể chỉnh sửa, xem [Hoạt ảnh tùy chỉnh](/slides/vi/java/custom-animation/).

Bạn có thể tạo **hoạt ảnh tùy chỉnh** của riêng mình trong Aspose.Slides. Điều này có thể thực hiện bằng cách kết hợp một số hành vi thành một hoạt ảnh tùy chỉnh mới.

[Behavior](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/behavior/) là khối xây dựng của một hiệu ứng hoạt ảnh PowerPoint. Kết hợp các hành vi để tùy chỉnh một hiệu ứng, hoặc thêm một hành vi để mở rộng một hiệu ứng đã được định nghĩa trước. Việc lặp lại được cấu hình thông qua cài đặt thời gian thay vì một hành vi lặp riêng.

[Animation Point](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/point/) là một điểm mà tại đó một hành vi nên được áp dụng.

## **Dòng thời gian hoạt ảnh**

[Sequence](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/sequence/) là một tập hợp các hiệu ứng hoạt ảnh có thể nhắm vào các hình dạng khác nhau.

[Timeline](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/animationtimeline/) là một tập hợp các chuỗi được sử dụng trong một slide cụ thể. Đây là một động cơ hoạt ảnh được giới thiệu trong PowerPoint 2002. Trong các phiên bản PowerPoint trước đó, việc thêm hiệu ứng hoạt ảnh vào bản trình bày rất khó và chỉ có thể thực hiện bằng nhiều cách khắc phục khác nhau. Dòng thời gian cung cấp một mô hình đối tượng rõ ràng hơn cho các hoạt ảnh PowerPoint. Một slide chỉ có thể có một dòng thời gian hoạt ảnh duy nhất.

## **Hoạt ảnh tương tác**

[Trigger](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/effecttriggertype/) cho phép bạn định nghĩa các hành động của người dùng, chẳng hạn như nhấp nút, để khởi động một hoạt ảnh cụ thể.

## **Hoạt ảnh hình dạng**

Aspose.Slides cho phép bạn áp dụng hoạt ảnh cho các hình dạng, bao gồm văn bản, hình chữ nhật, đường thẳng, khung, đối tượng OLE và nhiều hơn nữa.

{{% alert color="info" title="Lưu ý" %}}
Read more [**Về hoạt ảnh hình dạng**](/slides/vi/androidjava/shape-animation/).
{{% /alert %}}

## **Biểu đồ động**

Để tạo biểu đồ động, bạn nên sử dụng cùng các lớp như với các hình dạng. Tuy nhiên, các hoạt ảnh PowerPoint chỉ có thể áp dụng cho các danh mục biểu đồ hoặc các chuỗi biểu đồ. Bạn cũng có thể áp dụng hiệu ứng hoạt ảnh cho một phần tử danh mục hoặc một phần tử chuỗi.

{{% alert color="info" title="Lưu ý" %}}
Read more [**Về biểu đồ động**](/slides/vi/androidjava/animated-charts/).
{{% /alert %}}

## **Văn bản động**

Ngoài việc tạo hoạt ảnh cho văn bản, bạn cũng có thể áp dụng hoạt ảnh cho một đoạn văn.

{{% alert color="info" title="Lưu ý" %}}
Read more [**Về văn bản động**](/slides/vi/androidjava/animated-text/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các hoạt ảnh có được bảo tồn khi xuất sang PDF không?**

Không. PDF là định dạng tĩnh, do đó các hoạt ảnh và [slide transitions](/slides/vi/androidjava/slide-transition/) không được phát. Nếu bạn cần chuyển động, hãy xuất sang [HTML5](/slides/vi/androidjava/export-to-html5/), [animated GIF](/slides/vi/androidjava/convert-powerpoint-to-animated-gif/), hoặc [video](/slides/vi/androidjava/convert-powerpoint-to-video/) thay thế.

**Tôi có thể chuyển đổi bản trình bày động thành video và kiểm soát tốc độ khung hình và kích thước khung hình không?**

Có. Bạn có thể [render the presentation as frames](/slides/vi/androidjava/convert-powerpoint-to-video/) và mã hoá chúng thành video (ví dụ, bằng ffmpeg), chọn FPS và độ phân giải. Các hoạt ảnh và chuyển đổi slide được phát trong quá trình render.

**Các hoạt ảnh có vẫn nguyên vẹn khi làm việc với ODP (không chỉ PPTX) không?**

PPT, PPTX và ODP được hỗ trợ để [reading](/slides/vi/androidjava/open-presentation/) và [writing](/slides/vi/androidjava/save-presentation/), nhưng điều này không đảm bảo việc bảo tồn hoạt ảnh. Dữ liệu hoạt ảnh tùy chỉnh có thể bị mất khi chuyển đổi sang ODP. Xem [Custom Animation for Java](/slides/vi/java/custom-animation/) để biết ví dụ và hướng dẫn kiểm tra tính tương thích định dạng.