---
title: Tùy chỉnh biểu đồ bong bóng trong bài thuyết trình bằng C++
linktitle: Biểu đồ bong bóng
type: docs
url: /vi/cpp/bubble-chart/
keywords:
- biểu đồ bong bóng
- kích thước bong bóng
- tỉ lệ kích thước
- biểu diễn kích thước
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tạo và tùy chỉnh các biểu đồ bong bóng mạnh mẽ trong PowerPoint với Aspose.Slides cho C++ để nâng cao việc trực quan hoá dữ liệu một cách dễ dàng."
---
## **Tổng quan**

Bài viết này hướng dẫn cách làm việc với biểu đồ bong bóng trong Aspose.Slides. Nó bao gồm hai tùy chọn tùy chỉnh cụ thể: thay đổi tỉ lệ kích thước bong bóng bằng phương thức `set_BubbleSizeScale` và kiểm soát cách các giá trị kích thước bong bóng được biểu diễn bằng phương thức `set_BubbleSizeRepresentation`.

Các ví dụ minh họa cách tạo biểu đồ bong bóng, điều chỉnh tỉ lệ kích thước, và chuyển đổi cách biểu diễn kích thước bong bóng sang sử dụng chiều rộng. Bài viết cũng bao gồm phần FAQ ngắn giải thích hỗ trợ loại biểu đồ “Bubble with 3-D”, lưu ý rằng giới hạn thực tế của biểu đồ phụ thuộc vào hiệu năng và phiên bản PowerPoint mục tiêu, và giải thích việc xuất ra giữ nguyên giao diện biểu đồ thông qua engine render của Aspose.Slides.

## **Tỉ lệ kích thước biểu đồ bong bóng**
Aspose.Slides for C++ cung cấp hỗ trợ tỉ lệ kích thước biểu đồ Bong bóng. Trong Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** và **IChartSeriesGroup.BubbleSizeScale** đã được thêm. Dưới đây là ví dụ mẫu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Biểu diễn dữ liệu dưới dạng kích thước bong bóng**
Phương thức **get_BubbleSizeRepresentation()** mới đã được thêm vào các lớp **IChartSeries** và **ChartSeries**. **BubbleSizeRepresentation** chỉ định cách các giá trị kích thước bong bóng được biểu diễn trong biểu đồ bong bóng. Các giá trị có thể là: **BubbleSizeRepresentationType.Area** và **BubbleSizeRepresentationType.Width**. Vì vậy, enum **BubbleSizeRepresentationType** đã được thêm để chỉ định các cách biểu diễn dữ liệu dưới dạng kích thước bong bóng. Mã mẫu được đưa ra bên dưới.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Biểu đồ “bubble chart with 3-D effect” có được hỗ trợ không, và nó khác gì so với biểu đồ thường?**

Có. Có một loại biểu đồ riêng, “Bubble with 3-D.” Nó áp dụng kiểu dáng 3-D cho các bong bóng nhưng không thêm trục phụ; dữ liệu vẫn là X-Y-S (kích thước). Loại này có trong liệt kê [chart type](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/charttype/).

**Có giới hạn về số lượng series và points trong biểu đồ bong bóng không?**

Không có giới hạn cứng ở mức API; các ràng buộc được quyết định bởi hiệu năng và phiên bản PowerPoint mục tiêu. Đề nghị giữ số lượng điểm ở mức hợp lý để đảm bảo khả năng đọc và tốc độ render.

**Việc xuất ra sẽ ảnh hưởng như thế nào đến giao diện của biểu đồ bong bóng (PDF, hình ảnh)?**

Xuất ra các định dạng được hỗ trợ sẽ giữ nguyên giao diện của biểu đồ; quá trình render được thực hiện bởi engine Aspose.Slides. Đối với các định dạng raster/vector, các quy tắc chung về render đồ họa biểu đồ áp dụng (độ phân giải, khử răng cưa), vì vậy hãy chọn DPI đủ cho việc in ấn.