---
title: Tùy chỉnh biểu đồ bong bóng trong bài thuyết trình bằng C++
linktitle: Biểu đồ bong bóng
type: docs
url: /vi/cpp/bubble-chart/
keywords:
- biểu đồ bong bóng
- kích thước bong bóng
- điều chỉnh tỉ lệ kích thước
- biểu diễn kích thước
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tạo và tùy chỉnh các biểu đồ bong bóng mạnh mẽ trong PowerPoint với Aspose.Slides cho C++ để nâng cao việc trực quan hoá dữ liệu của bạn một cách dễ dàng."
---
## **Tổng quan**

Bài viết này trình bày cách làm việc với biểu đồ bong bóng trong Aspose.Slides. Nó bao gồm hai tùy chọn tùy chỉnh cụ thể: thay đổi kích thước bong bóng bằng phương thức `set_BubbleSizeScale` và kiểm soát cách các giá trị kích thước bong bóng được biểu diễn bằng phương thức `set_BubbleSizeRepresentation`.

Các ví dụ minh họa cách tạo biểu đồ bong bóng, điều chỉnh tỷ lệ kích thước và chuyển đổi biểu diễn kích thước bong bóng sang sử dụng chiều rộng. Bài viết cũng bao gồm một phần FAQ ngắn giải thích việc hỗ trợ loại biểu đồ “Bubble with 3-D”, lưu ý rằng giới hạn thực tế của biểu đồ phụ thuộc vào hiệu năng và phiên bản PowerPoint mục tiêu, và giải thích rằng quá trình xuất sẽ giữ nguyên giao diện của biểu đồ thông qua engine render của Aspose.Slides.

## **Điều chỉnh tỉ lệ kích thước biểu đồ bong bóng**
Aspose.Slides cho C++ cung cấp hỗ trợ cho việc điều chỉnh tỉ lệ kích thước biểu đồ bong bóng. Trong Aspose.Slides cho **C++ IChartSeries.BubbleSizeScale** và **IChartSeriesGroup.BubbleSizeScale** đã được thêm vào. Dưới đây là ví dụ mẫu được cung cấp. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Biểu diễn dữ liệu dưới dạng kích thước biểu đồ bong bóng**
Phương thức mới **get_BubbleSizeRepresentation()** đã được thêm vào các lớp **IChartSeries** và **ChartSeries**. **BubbleSizeRepresentation** chỉ định cách các giá trị kích thước bong bóng được biểu diễn trong biểu đồ bong bóng. Các giá trị khả dụng là: **BubbleSizeRepresentationType.Area** và **BubbleSizeRepresentationType.Width**. Do đó, enum **BubbleSizeRepresentationType** đã được thêm vào để chỉ ra các cách biểu diễn dữ liệu dưới dạng kích thước biểu đồ bong bóng. Mã mẫu được cung cấp bên dưới.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Biểu đồ bong bóng có hiệu ứng 3-D có được hỗ trợ không, và nó khác gì so với biểu đồ thông thường?**

Có. Có một loại biểu đồ riêng, “Bubble with 3-D”. Nó áp dụng kiểu dáng 3-D cho các bong bóng nhưng không thêm trục bổ sung; dữ liệu vẫn là X-Y-S (kích thước). Loại này có trong enumeration [chart type](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/charttype/).

**Có giới hạn nào về số lượng series và điểm trong biểu đồ bong bóng không?**

Không có giới hạn nghiêm ngặt ở mức API; các ràng buộc được quyết định bởi hiệu năng và phiên bản PowerPoint mục tiêu. Bạn nên giữ số lượng điểm ở mức hợp lý để đảm bảo khả năng đọc và tốc độ render.

**Quá trình xuất sẽ ảnh hưởng như thế nào đến giao diện của biểu đồ bong bóng (PDF, hình ảnh)?**

Xuất sang các định dạng được hỗ trợ sẽ giữ nguyên giao diện của biểu đồ; quá trình render được thực hiện bởi engine Aspose.Slides. Đối với các định dạng raster/vector, các quy tắc render đồ họa biểu đồ chung áp dụng (độ phân giải, khử răng cưa), vì vậy hãy chọn DPI đủ lớn cho việc in.