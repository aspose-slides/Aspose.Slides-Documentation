---
title: Thêm Hình Dạng Đường Vào Bản Trình Bày trong C++
linktitle: Đường
type: docs
weight: 50
url: /vi/cpp/line/
keywords:
- đường
- tạo đường
- thêm đường
- đường đơn
- cấu hình đường
- tùy chỉnh đường
- kiểu gạch
- đầu mũi tên
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Tìm hiểu cách thao tác định dạng đường trong các bản trình bày PowerPoint với Aspose.Slides cho C++. Khám phá các thuộc tính, phương thức và ví dụ."
---
## **Tổng quan**

Aspose.Slides cho phép bạn thêm các hình dạng đường vào các slide PowerPoint một cách lập trình. Bài viết này hướng dẫn cách tạo một đường đơn giản và cách tùy chỉnh một đường sao cho nó xuất hiện dưới dạng mũi tên.

Bạn sẽ học cách thêm một hình dạng đường vào một slide, điều chỉnh giao diện của nó, và lưu bản trình bày đã cập nhật. Các ví dụ tập trung vào các cài đặt định dạng đường thực tế như kiểu dáng, độ rộng, mẫu gạch, tùy chọn đầu mũi tên và màu nền.

## **Tạo một Đường Thẳng Đơn Giản**
Để thêm một đường thẳng đơn giản vào slide đã chọn trong bản trình bày, vui lòng làm theo các bước dưới đây:

- Create an instance of [lớp Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một AutoShape loại Line bằng cách sử dụng phương thức [AddAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/addautoshape/) được cung cấp bởi đối tượng Shapes.
- Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một đường vào slide đầu tiên của bản trình bày.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **Tạo một Đường Dạng Mũi Tên**
Aspose.Slides cho C++ cũng cho phép các nhà phát triển cấu hình một số thuộc tính của đường để làm cho nó trông hấp dẫn hơn. Hãy thử cấu hình một vài thuộc tính của đường để nó trông giống như một mũi tên. Vui lòng làm theo các bước dưới đây để thực hiện:

- Create an instance of [lớp Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
- Thêm một AutoShape loại Line bằng phương thức AddAutoShape được cung cấp bởi đối tượng Shapes.
- Đặt Line Style thành một trong các kiểu được Aspose.Slides cho C++ cung cấp.
- Đặt Width của đường.
- Đặt [Kiểu Dash](https://reference.aspose.com/slides/vi/cpp/aspose.slides/linedashstyle/) của đường thành một trong các kiểu được Aspose.Slides cho C++ cung cấp.
- Đặt [Kiểu Đầu Mũi Tên](https://reference.aspose.com/slides/vi/cpp/aspose.slides/lineformat/) và Độ dài của điểm bắt đầu của đường.
- Đặt Kiểu Đầu Mũi Tên và Độ dài của điểm cuối của đường.
- Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **FAQ**

**Tôi có thể chuyển một đường thông thường thành connector để nó "bám" vào các hình dạng không?**

Không. Một đường thông thường (một [AutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/autoshape/) loại [Line](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapetype/)) không tự động trở thành connector. Để nó bám vào các hình dạng, hãy sử dụng loại [Connector](https://reference.aspose.com/slides/vi/cpp/aspose.slides/connector/) chuyên dụng và các [các API tương ứng](/slides/vi/cpp/connector/) cho việc kết nối.

**Tôi nên làm gì nếu các thuộc tính của một đường được kế thừa từ theme và khó xác định giá trị cuối cùng?**

[Đọc các thuộc tính hiệu quả](/slides/vi/cpp/shape-effective-properties/) thông qua các giao diện [ILineFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ilinefillformateffectivedata/) — những giao diện này đã tính đến sự kế thừa và kiểu theme.

**Tôi có thể khóa một đường khỏi việc chỉnh sửa (di chuyển, thay đổi kích thước) không?**

Có. Shapes cung cấp [đối tượng khóa](https://reference.aspose.com/slides/vi/cpp/aspose.slides/autoshape/get_autoshapelock/) cho phép bạn [không cho phép các thao tác chỉnh sửa](/slides/vi/cpp/applying-protection-to-presentation/).