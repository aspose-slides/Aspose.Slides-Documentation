---
title: Nâng cao bài thuyết trình PowerPoint với hoạt ảnh trong PHP
linktitle: Hoạt Ảnh PowerPoint
type: docs
weight: 150
url: /vi/php-java/powerpoint-animation/
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
- PHP
- Aspose.Slides
description: "Khám phá khả năng của Aspose.Slides for PHP via Java trong việc xử lý các hoạt ảnh PowerPoint. Các tính năng chính và những hiểu biết để nâng cao bài thuyết trình của bạn."
---
## **Giới thiệu**

Vì các bài thuyết trình được tạo ra để trình bày một nội dung nào đó, hình thức trực quan và hành vi tương tác luôn được cân nhắc khi tạo chúng.

**PowerPoint animation** đóng một vai trò quan trọng để làm cho bài thuyết trình thu hút và hấp dẫn người xem. Aspose.Slides for PHP via Java cung cấp một loạt các tùy chọn để **thêm hoạt ảnh** vào bài thuyết trình PowerPoint:

- áp dụng các loại hiệu ứng hoạt ảnh PowerPoint khác nhau cho **shapes**, biểu đồ, bảng, OLE Object và các thành phần khác của bài thuyết trình.  
- sử dụng nhiều hiệu ứng hoạt ảnh PowerPoint trên một **shape**.  
- sử dụng **animation timeline** để kiểm soát các hiệu ứng hoạt ảnh.  
- tạo **custom animation**.

Trong Aspose.Slides for PHP via Java, các hiệu ứng hoạt ảnh khác nhau có thể được áp dụng trên **shapes**. Vì mỗi thành phần trên slide bao gồm văn bản, hình ảnh, OLE Object, bảng... đều được coi là một **shape**, chúng ta có thể áp dụng hiệu ứng hoạt ảnh cho mọi thành phần của slide.

## **Hiệu Ứng Hoạt Ảnh**
Aspose.Slides hỗ trợ **hơn 150+ hiệu ứng hoạt ảnh**, bao gồm các hiệu ứng cơ bản như Bounce, PathFootball, hiệu ứng Zoom và các hiệu ứng đặc biệt như OLEObjectShow, OLEObjectOpen. Bạn có thể xem danh sách đầy đủ các hiệu ứng hoạt ảnh trong liệt kê [**EffectType**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effecttype/) .

Ngoài ra, các hiệu ứng hoạt ảnh này có thể được kết hợp với:

- [ColorEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SetEffect)

## **Hoạt Ảnh Tùy Chỉnh**
Bạn có thể tạo **hoạt ảnh tuỳ chỉnh** của riêng mình trong Aspose.Slides.  
Điều này có thể thực hiện được khi bạn kết hợp nhiều **behaviours** lại thành một **custom animation** mới.

[**Behavior**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Behavior) là đơn vị xây dựng của bất kỳ hiệu ứng hoạt ảnh PowerPoint nào. Tất cả các hiệu ứng hoạt ảnh thực chất là một tập hợp các **behaviours** được ghép lại thành một chiến lược. Bạn có thể kết hợp các **behaviours** thành một **custom animation** một lần và tái sử dụng nó trong các bài thuyết trình khác. Nếu bạn thêm một **behaviour** mới vào một hiệu ứng hoạt ảnh PowerPoint tiêu chuẩn – đó sẽ trở thành một **custom animation** khác. Ví dụ, bạn có thể thêm **repeat behaviour** vào một hoạt ảnh để nó lặp lại một vài lần.

[**Animation Point**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Point) là điểm mà **behaviour** sẽ được áp dụng.

## **Dòng Thời Gian Hoạt Ảnh**
[**Sequence**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Sequence) là một tập hợp các hiệu ứng hoạt ảnh, áp dụng trên một **shape** cụ thể.

[**Timeline**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/AnimationTimeLine) là một tập hợp các **Sequences** được sử dụng trong một slide cụ thể. Đây là động cơ hoạt ảnh được giới thiệu kể từ PowerPoint 2002. Trong các phiên bản PowerPoint trước đây, việc thêm hiệu ứng hoạt ảnh vào bài thuyết trình rất khó khăn và chỉ có thể thực hiện thông qua các cách giải quyết khác nhau. **Timeline** đã thay thế lớp **AnimationSettings** cũ và cung cấp mô hình đối tượng rõ ràng hơn cho hoạt ảnh PowerPoint. Mỗi slide chỉ có **một** dòng thời gian hoạt ảnh.

## **Hoạt Ảnh Tương Tác**
[**Trigger**](https://reference.aspose.com/slides/vi/php-java/aspose.slides/EffectTriggerType) cho phép định nghĩa các hành động của người dùng (ví dụ: nhấn nút) để khởi động một hoạt ảnh nhất định. **Triggers** chỉ được thêm vào trong phiên bản PowerPoint mới nhất.

## **Hoạt Ảnh Hình Dạng**
Aspose.Slides cho phép áp dụng hoạt ảnh cho **shapes**, có thể là văn bản, hình chữ nhật, đường thẳng, khung, OLE Object, v.v.

{{% alert color="primary" %}} 
Đọc thêm [**Về Hoạt Ảnh Hình Dạng**](/slides/vi/php-java/shape-animation/).
{{% /alert %}}

## **Biểu Đồ Được Hoạt Ảnh**
Để tạo **biểu đồ được hoạt ảnh**, bạn nên sử dụng cùng các lớp như với các **shapes**. Tuy nhiên, bạn chỉ có thể áp dụng hoạt ảnh PowerPoint cho các **category** của biểu đồ hoặc **series** của biểu đồ. Bạn cũng có thể áp dụng hiệu ứng hoạt ảnh cho một phần tử **category** hoặc **series**.

{{% alert color="primary" %}} 
Đọc thêm [**Về Biểu Đồ Được Hoạt Ảnh**](/slides/vi/php-java/animated-charts/).
{{% /alert %}}

## **Văn Bản Được Hoạt Ảnh**
Bên cạnh văn bản được hoạt ảnh, bạn cũng có thể áp dụng hoạt ảnh cho một đoạn văn.

{{% alert color="primary" %}} 
Đọc thêm [**Về Văn Bản Được Hoạt Ảnh**](/slides/vi/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Các hiệu ứng hoạt ảnh có được giữ lại khi xuất sang PDF không?**

Không. PDF là định dạng tĩnh, vì vậy các hiệu ứng hoạt ảnh và [slide transitions](/slides/vi/php-java/slide-transition/) sẽ không phát. Nếu bạn cần chuyển động, hãy xuất sang [HTML5](/slides/vi/php-java/export-to-html5/), [animated GIF](/slides/vi/php-java/convert-powerpoint-to-animated-gif/) hoặc [video](/slides/vi/php-java/convert-powerpoint-to-video/) thay thế.

**Tôi có thể chuyển một bài thuyết trình hoạt ảnh thành video và điều chỉnh tốc độ khung hình và kích thước khung hình không?**

Có. Bạn có thể [render the presentation as frames](/slides/vi/php-java/convert-powerpoint-to-video/) và mã hoá chúng thành video (ví dụ: qua ffmpeg), chọn FPS và độ phân giải. Các hoạt ảnh và **slide transitions** sẽ được phát trong quá trình render.

**Các hiệu ứng hoạt ảnh có giữ nguyên khi làm việc với ODP (không chỉ PPTX) không?**

PPT, PPTX và ODP đều được hỗ trợ để [reading](/slides/vi/php-java/open-presentation/) và [writing](/slides/vi/php-java/save-presentation/), nhưng sự khác biệt về định dạng có nghĩa là một số hiệu ứng có thể hiển thị hoặc hoạt động hơi khác nhau. Hãy kiểm chứng các trường hợp quan trọng bằng các mẫu thực tế.