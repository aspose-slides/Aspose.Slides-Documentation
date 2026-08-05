---
title: Thêm Đường Xu Hướng vào Biểu Đồ Trình Chiếu trong C++
linktitle: Đường Xu Hướng
type: docs
url: /vi/cpp/trend-line/
keywords:
- biểu đồ
- đường xu hướng
- đường xu hướng hàm mũ
- đường xu hướng tuyến tính
- đường xu hướng logarit
- đường xu hướng trung bình động
- đường xu hướng đa thức
- đường xu hướng lũy thừa
- đường xu hướng tùy chỉnh
- PowerPoint
- bản trình bày
- C++
- Aspose.Slides
description: "Nhanh chóng thêm và tùy chỉnh các đường xu hướng trong biểu đồ PowerPoint với Aspose.Slides cho C++ — một hướng dẫn thực tế để thu hút khán giả của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách thêm các đường xu hướng vào biểu đồ trong bản trình bày bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tạo biểu đồ, thêm đường xu hướng vào các chuỗi biểu đồ và làm việc với một số loại đường xu hướng, bao gồm hàm mũ, tuyến tính, logarit, trung bình động, đa thức và lũy thừa.

Nó cũng mô tả cách thêm một đường tùy chỉnh vào biểu đồ bằng cách chèn một hình dạng đường thẳng, và bao gồm một phần FAQ ngắn về giá trị chiếu phía trước và phía sau của đường xu hướng cũng như việc các đường xu hướng có được giữ lại khi xuất ra PDF hoặc SVG và khi render biểu đồ dưới dạng hình ảnh hay không.

## **Thêm Đường Xu Hướng**
Aspose.Slides for C++ cung cấp một API đơn giản để quản lý các Đường Xu Hướng của biểu đồ:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
1. Lấy tham chiếu của một slide bằng chỉ số của nó.
1. Thêm biểu đồ với dữ liệu mặc định cùng với bất kỳ loại nào mong muốn (ví dụ này sử dụng ChartType.ClusteredColumn).
1. Thêm đường xu hướng hàm mũ cho chuỗi biểu đồ 1.
1. Thêm đường xu hướng tuyến tính cho chuỗi biểu đồ 1.
1. Thêm đường xu hướng logarit cho chuỗi biểu đồ 2.
1. Thêm đường xu hướng trung bình động cho chuỗi biểu đồ 2.
1. Thêm đường xu hướng đa thức cho chuỗi biểu đồ 3.
1. Thêm đường xu hướng lũy thừa cho chuỗi biểu đồ 3.
1. Ghi bản trình bày đã sửa đổi ra file PPTX.

Mã sau được sử dụng để tạo biểu đồ với các Đường Xu Hướng.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Thêm Đường Tùy Chỉnh**
Aspose.Slides for C++ cung cấp một API đơn giản để thêm các đường tùy chỉnh vào biểu đồ. Để thêm một đường thẳng đơn giản vào slide được chọn trong bản trình bày, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp Presentation
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ số của nó
- Tạo một biểu đồ mới bằng phương thức AddChart được cung cấp bởi đối tượng Shapes
- Thêm một AutoShape loại Line bằng phương thức AddAutoShape được cung cấp bởi đối tượng Shapes
- Đặt Color cho các đường của hình dạng.
- Ghi bản trình bày đã sửa đổi dưới dạng file PPTX

Mã sau được sử dụng để tạo biểu đồ với Đường Tùy Chỉnh.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**‘forward’ và ‘backward’ có nghĩa là gì đối với một đường xu hướng?**

Chúng là độ dài của đường xu hướng được chiếu xa phía trước hoặc phía sau: đối với biểu đồ scatter (XY) — tính bằng đơn vị trục; đối với các biểu đồ không phải scatter — tính bằng số danh mục. Chỉ cho phép giá trị không âm.

**Đường xu hướng có được giữ lại khi xuất bản trình bày sang PDF hoặc SVG, hoặc khi render một slide thành hình ảnh không?**

Có. Aspose.Slides chuyển đổi bản trình bày sang [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/vi/cpp/render-a-slide-as-an-svg-image/) và render biểu đồ thành hình ảnh; các đường xu hướng, như một phần của biểu đồ, được giữ lại trong các thao tác này. Một phương thức cũng có sẵn để [xuất hình ảnh của biểu đồ](/slides/vi/cpp/create-shape-thumbnails/) riêng biệt.