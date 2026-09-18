---
title: Nâng cao bản thuyết trình PowerPoint với hoạt ảnh trong JavaScript
linktitle: Hoạt ảnh PowerPoint
type: docs
weight: 150
url: /vi/nodejs-java/powerpoint-animation/
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
- bản thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Sử dụng Aspose.Slides cho Node.js qua Java để xử lý hoạt ảnh PowerPoint. Tổng quan này nêu bật các tính năng chính và cung cấp những hiểu biết để nâng cao bản thuyết trình của bạn."
---
## **Giới thiệu**

Vì các bản thuyết trình được tạo ra để trình bày nội dung, nên hình thức trực quan và hành vi tương tác của chúng luôn được cân nhắc trong quá trình tạo.

**Hoạt ảnh PowerPoint** đóng vai trò quan trọng trong việc làm cho bản thuyết trình hấp dẫn và thu hút người xem. Aspose.Slides for Node.js via Java cung cấp nhiều tùy chọn để thêm hoạt ảnh vào các bản trình chiếu PowerPoint:

- Áp dụng các loại hiệu ứng hoạt ảnh PowerPoint khác nhau cho hình dạng, biểu đồ, bảng, đối tượng OLE và các yếu tố khác của bản thuyết trình.  
- Sử dụng nhiều hiệu ứng hoạt ảnh PowerPoint trên một hình dạng duy nhất.  
- Sử dụng dòng thời gian hoạt ảnh để kiểm soát các hiệu ứng hoạt ảnh.  
- Tạo hoạt ảnh tùy chỉnh.

Trong Aspose.Slides for Node.js via Java, có thể áp dụng các hiệu ứng hoạt ảnh khác nhau cho các hình dạng. Vì mọi yếu tố trên một slide, bao gồm văn bản, hình ảnh, đối tượng OLE và bảng, đều được coi là một hình dạng, nên các hiệu ứng hoạt ảnh có thể được áp dụng cho bất kỳ yếu tố nào trên slide.

## **Animation Effects**
Aspose.Slides hỗ trợ **150+ animation effects**, bao gồm các hiệu ứng cơ bản như Bounce, PathFootball và Zoom, và các hiệu ứng đặc biệt như OLEObjectShow và OLEObjectOpen. Bạn có thể xem danh sách đầy đủ trong [EffectType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effecttype/) enumeration.

Ngoài ra, các hiệu ứng hoạt ảnh này có thể được sử dụng kết hợp với các hành vi sau:

- [ColorEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SetEffect)

## **Hoạt ảnh tùy chỉnh**
Đối với các ví dụ JavaScript đầy đủ về tạo, kiểm tra và sửa đổi hành vi và đường chuyển động có thể chỉnh sửa, xem [Hoạt ảnh tùy chỉnh](/slides/vi/nodejs-java/custom-animation/).

Bạn có thể tạo **hoạt ảnh tùy chỉnh** trong Aspose.Slides. Điều này có thể thực hiện bằng cách kết hợp nhiều hành vi thành một hoạt ảnh tùy chỉnh mới.

[Behavior](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/behavior/) là khối xây dựng của một hiệu ứng hoạt ảnh PowerPoint. Kết hợp các hành vi để tùy chỉnh một hiệu ứng, hoặc thêm một hành vi để mở rộng một hiệu ứng đã định nghĩa trước. Việc lặp lại được cấu hình thông qua cài đặt thời gian chứ không phải một hành vi lặp riêng.

[Animation Point](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/point/) là điểm mà một hành vi nên được áp dụng.

## **Dòng thời gian hoạt ảnh**
[Sequence](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sequence/) là tập hợp các hiệu ứng hoạt ảnh có thể nhắm tới các hình dạng khác nhau.

[Timeline](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/animationtimeline/) là một tập hợp các chuỗi được sử dụng trong một slide cụ thể. Đó là một động cơ hoạt ảnh được giới thiệu trong PowerPoint 2002. Trong các phiên bản PowerPoint trước đó, việc thêm hiệu ứng hoạt ảnh vào bản thuyết trình gặp nhiều khó khăn và chỉ có thể thực hiện thông qua các cách khắc phục khác nhau. Dòng thời gian cung cấp một mô hình đối tượng rõ ràng hơn cho các hoạt ảnh PowerPoint. Một slide chỉ có thể có một dòng thời gian hoạt ảnh.

## **Hoạt ảnh tương tác**
[Trigger](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effecttriggertype/) cho phép bạn định nghĩa các hành động của người dùng, chẳng hạn như nhấp chuột vào nút, để khởi động một hoạt ảnh cụ thể.

## **Hoạt ảnh hình dạng**
Aspose.Slides cho phép bạn áp dụng hoạt ảnh cho các hình dạng, bao gồm văn bản, hình chữ nhật, đường thẳng, khung, đối tượng OLE và hơn thế nữa.

{{% alert color="info" title="Note" %}}
Đọc thêm [**Về hoạt ảnh hình dạng**](/slides/vi/nodejs-java/shape-animation/).
{{% /alert %}}

## **Biểu đồ động**
Để tạo biểu đồ động, bạn nên sử dụng cùng các lớp như đối với hình dạng. Tuy nhiên, các hoạt ảnh PowerPoint chỉ có thể được áp dụng cho các danh mục biểu đồ hoặc các chuỗi biểu đồ. Bạn cũng có thể áp dụng hiệu ứng hoạt ảnh cho một yếu tố danh mục hoặc một yếu tố chuỗi.

{{% alert color="info" title="Note" %}}
Đọc thêm [**Về biểu đồ động**](/slides/vi/nodejs-java/animated-charts/).
{{% /alert %}}

## **Văn bản động**
Ngoài việc hoạt ảnh văn bản, bạn cũng có thể áp dụng hoạt ảnh cho một đoạn văn.

{{% alert color="info" title="Note" %}}
Đọc thêm [**Về văn bản động**](/slides/vi/nodejs-java/animated-text/).
{{% /alert %}}

## **Câu hỏi thường gặp**

**Các hoạt ảnh có được giữ lại khi xuất sang PDF không?**

Không. PDF là định dạng tĩnh, vì vậy các hoạt ảnh và [slide transitions](/slides/vi/nodejs-java/slide-transition/) không phát. Nếu bạn cần chuyển động, hãy xuất sang [HTML5](/slides/vi/nodejs-java/export-to-html5/), [animated GIF](/slides/vi/nodejs-java/convert-powerpoint-to-animated-gif/) hoặc [video](/slides/vi/nodejs-java/convert-powerpoint-to-video/) thay thế.

**Tôi có thể chuyển bản trình chiếu động sang video và điều chỉnh tốc độ khung hình và kích thước khung hình không?**

Có. Bạn có thể [render the presentation as frames](/slides/vi/nodejs-java/convert-powerpoint-to-video/) và mã hoá chúng thành một video (ví dụ: bằng ffmpeg), chọn FPS và độ phân giải. Các hoạt ảnh và chuyển đổi slide sẽ được phát trong quá trình render.

**Các hoạt ảnh có vẫn được giữ nguyên khi làm việc với ODP (không chỉ PPTX) không?**

PPT, PPTX và ODP đều được hỗ trợ cho [reading](/slides/vi/nodejs-java/open-presentation/) và [writing](/slides/vi/nodejs-java/save-presentation/), nhưng điều này không đảm bảo việc bảo tồn hoạt ảnh. Dữ liệu hoạt ảnh tùy chỉnh có thể bị mất khi chuyển đổi sang ODP. Xem [Hoạt ảnh tùy chỉnh](/slides/vi/nodejs-java/custom-animation/) để biết ví dụ và hướng dẫn kiểm tra tính tương thích của định dạng.