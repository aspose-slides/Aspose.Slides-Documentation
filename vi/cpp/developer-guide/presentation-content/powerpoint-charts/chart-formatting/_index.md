---
title: Định dạng biểu đồ trình chiếu trong C++
linktitle: Định dạng biểu đồ
type: docs
weight: 60
url: /vi/cpp/chart-formatting/
keywords:
- định dạng biểu đồ
- định dạng biểu đồ
- thực thể biểu đồ
- thuộc tính biểu đồ
- cài đặt biểu đồ
- tùy chọn biểu đồ
- thuộc tính phông chữ
- viền bo tròn
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách định dạng biểu đồ trong Aspose.Slides cho C++ và nâng cao bản trình chiếu PowerPoint của bạn với phong cách chuyên nghiệp, bắt mắt."
---
## **Tổng quan**

Bài viết này giải thích cách định dạng biểu đồ trong các bản trình chiếu PowerPoint bằng cách sử dụng Aspose.Slides. Nó cho thấy cách tùy chỉnh các yếu tố chính của biểu đồ như trục, đường lưới, tiêu đề, chú giải, khu vực vẽ và màu nền tường để cải thiện giao diện và khả năng đọc dữ liệu biểu đồ.

Nó cũng trình bày cách thiết lập các thuộc tính phông chữ cho văn bản biểu đồ, áp dụng định dạng số có sẵn và tùy chỉnh cho dữ liệu biểu đồ, và bật góc bo tròn cho khu vực biểu đồ. Cùng nhau, các ví dụ này cho thấy cách kiểm soát cả kiểu dáng trực quan và cách trình bày dữ liệu của biểu đồ trong bản trình chiếu.

## **Định dạng các thực thể biểu đồ**
Aspose.Slides cho C++ cho phép các nhà phát triển thêm biểu đồ tùy chỉnh vào các slide của họ từ đầu. Bài viết này giải thích cách định dạng các thực thể biểu đồ khác nhau bao gồm trục danh mục và trục giá trị.

Aspose.Slides cho C++ cung cấp một API đơn giản để quản lý các thực thể biểu đồ khác nhau và định dạng chúng bằng các giá trị tùy chỉnh:

1. Tạo một thể hiện của lớp **Presentation**.
1. Lấy tham chiếu slide theo chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ loại nào mong muốn (trong ví dụ này chúng tôi sẽ sử dụng ChartType.LineWithMarkers).
1. Truy cập Trục Giá trị của biểu đồ và đặt các thuộc tính sau:
   1. Đặt **Line format** cho các đường lưới chính của Trục Giá trị
   1. Đặt **Line format** cho các đường lưới phụ của Trục Giá trị
   1. Đặt **Number Format** cho Trục Giá trị
   1. Đặt **Min, Max, Major and Minor units** cho Trục Giá trị
   1. Đặt **Text Properties** cho dữ liệu Trục Giá trị
   1. Đặt **Title** cho Trục Giá trị
   1. Đặt **Line Format** cho Trục Giá trị
1. Truy cập Trục Danh mục của biểu đồ và đặt các thuộc tính sau:
   1. Đặt **Line format** cho các đường lưới chính của Trục Danh mục
   1. Đặt **Line format** cho các đường lưới phụ của Trục Danh mục
   1. Đặt **Text Properties** cho dữ liệu Trục Danh mục
   1. Đặt **Title** cho Trục Danh mục
   1. Đặt **Label Positioning** cho Trục Danh mục
   1. Đặt **Rotation Angle** cho nhãn Trục Danh mục
1. Truy cập Legend của biểu đồ và đặt **Text Properties** cho chúng
1. Thiết lập hiển thị Legend của biểu đồ mà không chồng lên biểu đồ
1. Truy cập **Secondary Value Axis** của biểu đồ và đặt các thuộc tính sau:
   1. Bật **Value Axis** phụ
   1. Đặt **Line Format** cho Secondary Value Axis
   1. Đặt **Number Format** cho Secondary Value Axis
   1. Đặt **Min, Max, Major and Minor units** cho Secondary Value Axis
1. Bây giờ vẽ series biểu đồ đầu tiên trên Secondary Value Axis
1. Đặt màu nền tường phía sau biểu đồ
1. Đặt màu nền khu vực vẽ biểu đồ
1. Ghi bản trình chiếu đã chỉnh sửa thành tệp PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Đặt Thuộc tính Phông chữ cho Biểu đồ**
Aspose.Slides cho C++ hỗ trợ thiết lập các thuộc tính liên quan đến phông chữ cho biểu đồ. Vui lòng làm theo các bước dưới đây để thiết lập các thuộc tính phông chữ cho biểu đồ.

- Khởi tạo đối tượng lớp Presentation.
- Thêm biểu đồ vào slide.
- Đặt chiều cao phông chữ.
- Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ mẫu dưới đây được đưa ra.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Đặt Thuộc tính Phông chữ cho Bảng Dữ liệu Biểu đồ**
Aspose.Slides cho C++ cung cấp hỗ trợ để thay đổi màu của các danh mục trong màu sắc series. 

1. Khởi tạo đối tượng lớp Presentation.
1. Thêm biểu đồ vào slide.
1. đặt bảng biểu đồ.
1. Đặt chiều cao phông chữ.
1. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ mẫu dưới đây được đưa ra. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Đặt Viền Bo Tròn cho Khu vực Biểu đồ**
Aspose.Slides cho C++ cung cấp hỗ trợ để thiết lập khu vực biểu đồ. **IChart.HasRoundedCorners** và **Chart.HasRoundedCorners** đã được thêm vào Aspose.Slides. 

1. Khởi tạo đối tượng lớp Presentation.
1. Thêm biểu đồ vào slide.
1. Đặt loại và màu nền cho biểu đồ
1. Đặt thuộc tính góc bo tròn thành True.
1. Lưu bản trình chiếu đã chỉnh sửa. 

Ví dụ mẫu dưới đây được đưa ra. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Đặt Định dạng Số**
Aspose.Slides cho C++ cung cấp một API đơn giản để quản lý định dạng dữ liệu biểu đồ:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) .
1. Lấy tham chiếu slide theo chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ loại nào mong muốn (ví dụ này sử dụng **ChartType.ClusteredColumn**).
1. Đặt định dạng số preset từ các giá trị preset có thể.
1. Duyệt qua các ô dữ liệu biểu đồ trong mỗi series và đặt định dạng số cho dữ liệu biểu đồ.
1. Lưu bản trình chiếu.
1. Đặt định dạng số tùy chỉnh.
1. Duyệt qua các ô dữ liệu biểu đồ trong mỗi series và đặt một định dạng số khác cho dữ liệu biểu đồ.
1. Lưu bản trình chiếu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Các giá trị định dạng số preset có thể cùng với chỉ số preset và có thể được sử dụng được liệt kê dưới đây:**|
| :- | :- |
|**0**|Chung|
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |

## **Câu hỏi thường gặp**

**Tôi có thể đặt màu nền bán trong suốt cho các cột/khu vực trong khi giữ viền không trong suốt không?**

Có. Độ trong suốt của màu nền và đường viền được cấu hình riêng biệt. Điều này hữu ích để cải thiện khả năng đọc của lưới và dữ liệu trong các trực quan phức tạp.

**Làm thế nào để xử lý các nhãn dữ liệu khi chúng chồng lên nhau?**

Giảm kích thước phông chữ, tắt các thành phần nhãn không cần thiết (ví dụ, danh mục), đặt khoảng cách/ vị trí nhãn, chỉ hiển thị nhãn cho các điểm đã chọn nếu cần, hoặc chuyển định dạng sang "giá trị + chú giải".

**Tôi có thể áp dụng màu nền gradient hoặc họa tiết cho series không?**

Có. Cả màu nền đặc và gradient/họa tiết thường đều có sẵn. Trong thực tế, sử dụng gradient một cách hạn chế và tránh các kết hợp làm giảm độ tương phản với lưới và văn bản.