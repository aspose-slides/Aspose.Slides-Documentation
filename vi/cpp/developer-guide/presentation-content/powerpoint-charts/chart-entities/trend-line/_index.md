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
- bản trình chiếu
- C++
- Aspose.Slides
description: "Nhanh chóng thêm và tùy chỉnh các đường xu hướng trong biểu đồ PowerPoint với Aspose.Slides cho C++ — hướng dẫn thực tế để thu hút khán giả của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách thêm các đường xu hướng vào biểu đồ trong bản trình chiếu bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tạo một biểu đồ, thêm các đường xu hướng vào các chuỗi biểu đồ và làm việc với một số loại đường xu hướng, bao gồm hàm mũ, tuyến tính, logarit, trung bình động, đa thức và lũy thừa.

Nó cũng mô tả cách thêm một đường tùy chỉnh vào biểu đồ bằng cách chèn một hình dạng đường thẳng, và bao gồm một phần Hỏi Đáp ngắn về các giá trị chiếu hướng tiến và lùi của đường xu hướng và liệu các đường xu hướng có được giữ lại khi xuất sang PDF hoặc SVG và khi hiện thị biểu đồ dưới dạng hình ảnh hay không.

## **Thêm Đường Xu Hướng**
Aspose.Slides cho C++ cung cấp một API đơn giản để quản lý các Đường Xu Hướng khác nhau của biểu đồ:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
2. Lấy tham chiếu của một slide bằng chỉ mục của nó.
3. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ loại nào mong muốn (ví dụ này sử dụng ChartType.ClusteredColumn).
4. Thêm đường xu hướng hàm mũ cho chuỗi biểu đồ 1.
5. Thêm đường xu hướng tuyến tính cho chuỗi biểu đồ 1.
6. Thêm đường xu hướng logarit cho chuỗi biểu đồ 2.
7. Thêm đường xu hướng trung bình động cho chuỗi biểu đồ 2.
8. Thêm đường xu hướng đa thức cho chuỗi biểu đồ 3.
9. Thêm đường xu hướng lũy thừa cho chuỗi biểu đồ 3.
10. Ghi bản trình chiếu đã chỉnh sửa vào tệp PPTX.

Đoạn mã sau được sử dụng để tạo một biểu đồ với các Đường Xu Hướng.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Thêm Đường Tùy Chỉnh**
Aspose.Slides cho C++ cung cấp một API đơn giản để thêm các đường tùy chỉnh vào biểu đồ. Để thêm một đường thẳng đơn giản vào slide đã chọn của bản trình chiếu, vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của lớp Presentation
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục Index của nó
- Tạo một biểu đồ mới bằng cách sử dụng phương thức AddChart được cung cấp bởi đối tượng Shapes
- Thêm một AutoShape loại Đường thẳng bằng cách sử dụng phương thức AddAutoShape được cung cấp bởi đối tượng Shapes
- Đặt màu (Color) cho các đường của hình dạng.
- Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX

Đoạn mã sau được sử dụng để tạo một biểu đồ với các Đường Tùy Chỉnh.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **Câu hỏi thường gặp**

**'Forward' và 'backward' có nghĩa là gì đối với một đường xu hướng?**

Đó là độ dài của đường xu hướng được chiếu tiến hoặc lùi: đối với biểu đồ phân tán (XY) — tính bằng đơn vị trục; đối với các biểu đồ không phải phân tán — tính bằng số danh mục. Chỉ cho phép các giá trị không âm.

**Đường xu hướng có được giữ lại khi xuất bản trình chiếu sang PDF hoặc SVG, hoặc khi hiển thị slide thành hình ảnh không?**

Có. Aspose.Slides chuyển đổi bản trình chiếu sang [PDF](/slides/vi/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/vi/cpp/render-a-slide-as-an-svg-image/) và hiển thị các biểu đồ dưới dạng hình ảnh; các đường xu hướng, như một phần của biểu đồ, sẽ được giữ lại trong các thao tác này. Ngoài ra còn có một phương thức để [xuất hình ảnh của biểu đồ](/slides/vi/cpp/create-shape-thumbnails/) ngay riêng.