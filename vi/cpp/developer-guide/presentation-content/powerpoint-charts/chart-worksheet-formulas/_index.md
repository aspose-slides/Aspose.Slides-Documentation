---
title: Áp dụng công thức Worksheet biểu đồ trong bản trình bày bằng С++
linktitle: Công thức Worksheet
type: docs
weight: 70
url: /vi/cpp/chart-worksheet-formulas/
keywords:
- bảng tính biểu đồ
- worksheet biểu đồ
- công thức biểu đồ
- công thức worksheet
- công thức bảng tính
- nguồn dữ liệu
- hằng số logic
- hằng số số
- hằng số chuỗi
- hằng số lỗi
- hằng số số học
- toán tử so sánh
- kiểu A1
- kiểu R1C1
- hàm định nghĩa trước
- PowerPoint
- bản trình bày
- С++
- Aspose.Slides
description: "Áp dụng công thức kiểu Excel trong Aspose.Slides cho worksheet biểu đồ bằng С++ và tự động hoá báo cáo trên các tệp PPT và PPTX."
---
## **Tổng quan**

Worksheet biểu đồ là nguồn dữ liệu phía sau một biểu đồ trong bản trình bày. Nó lưu trữ tên danh mục và chuỗi cùng với các giá trị số được biểu đồ hiển thị. Trong Aspose.Slides, worksheet này có sẵn thông qua chart data workbook, cho phép bạn làm việc với dữ liệu biểu đồ bằng cách lập trình.

Bài viết này giải thích cách sử dụng công thức worksheet trong dữ liệu biểu đồ để giá trị ô có thể được tính toán và cập nhật tự động thay vì nhập thủ công. Nó cho thấy cách gán công thức, sử dụng cả tham chiếu kiểu A1 và R1C1, tính lại các công thức workbook và làm việc với các hằng số, toán tử, tham chiếu ô và các hàm được định nghĩa trước được hỗ trợ cho worksheet biểu đồ trong bản trình bày.

## **Về công thức bảng tính biểu đồ trong bản trình bày**
**Bảng tính biểu đồ** (hoặc worksheet biểu đồ) trong bản trình bày là nguồn dữ liệu của biểu đồ. Bảng tính biểu đồ chứa dữ liệu, được biểu diễn trên biểu đồ dưới dạng đồ họa. Khi bạn tạo một biểu đồ trong PowerPoint, worksheet liên quan đến biểu đồ này cũng được tạo tự động. Worksheet biểu đồ được tạo cho mọi loại biểu đồ: biểu đồ đường, biểu đồ cột, biểu đồ sunburst, biểu đồ tròn, v.v. Để xem bảng tính biểu đồ trong PowerPoint, bạn chỉ cần nhấp đúp vào biểu đồ:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Bảng tính biểu đồ chứa tên các thành phần biểu đồ (Category Name: *Category1*, Serie Name) và một bảng dữ liệu số phù hợp với các danh mục và chuỗi này. Theo mặc định, khi bạn tạo một biểu đồ mới – dữ liệu bảng tính biểu đồ được thiết lập với dữ liệu mặc định. Sau đó bạn có thể thay đổi dữ liệu bảng tính trong worksheet một cách thủ công.

Thông thường, biểu đồ đại diện cho dữ liệu phức tạp (ví dụ: nhà phân tích tài chính, nhà phân tích khoa học), có các ô được tính toán từ giá trị của các ô khác hoặc từ dữ liệu động khác. Tính giá trị ô bằng tay và ghi cứng vào ô khiến việc thay đổi sau này trở nên khó khăn. Nếu bạn thay đổi giá trị của một ô nào đó, tất cả các ô phụ thuộc vào nó đều cần được cập nhật. Hơn nữa, dữ liệu bảng có thể phụ thuộc vào dữ liệu từ các bảng khác, tạo ra một sơ đồ dữ liệu bản trình bày phức tạp cần được cập nhật một cách dễ dàng và linh hoạt.

**Công thức bảng tính biểu đồ** trong bản trình bày là một biểu thức để tự động tính toán và cập nhật dữ liệu bảng tính biểu đồ. Công thức bảng tính xác định logic tính toán dữ liệu cho một ô hoặc một tập hợp ô. Công thức bảng tính là một công thức toán học hoặc logic, sử dụng: tham chiếu ô, hàm toán học, toán tử logic, toán tử số học, hàm chuyển đổi, hằng số chuỗi, v.v. Định nghĩa công thức được ghi vào một ô, và ô này không chứa giá trị đơn giản. Công thức bảng tính tính toán giá trị và trả về, sau đó giá trị này được gán cho ô. Công thức bảng tính trong bản trình bày thực chất giống với công thức Excel, và hỗ trợ cùng các hàm, toán tử và hằng số mặc định.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/cpp/) chart spreadsheet được biểu diễn bằng phương thức 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) của kiểu 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.charts.i_chart_data_workbook). 
Công thức bảng tính có thể được gán và thay đổi bằng phương thức 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692). 
Các chức năng sau được hỗ trợ cho công thức trong Aspose.Slides:

- Các hằng số logic
- Các hằng số số
- Các hằng số chuỗi
- Các hằng số lỗi
- Các toán tử số học
- Các toán tử so sánh
- Tham chiếu ô kiểu A1
- Tham chiếu ô kiểu R1C1
- Các hàm được định nghĩa trước

Thông thường, các bảng tính lưu trữ giá trị công thức đã tính toán cuối cùng. Nếu sau khi tải bản trình bày, dữ liệu biểu đồ không thay đổi – phương thức **IChartDataCell.get_Value()** sẽ trả về các giá trị đó khi đọc. Nhưng nếu dữ liệu bảng tính đã bị thay đổi, khi đọc **ChartDataCell.get_Value()** phương thức sẽ ném **CellUnsupportedDataException** cho các công thức không được hỗ trợ. Điều này bởi vì khi công thức được phân tích thành công, các phụ thuộc ô được xác định và tính đúng đắn của các giá trị cuối cùng được kiểm tra. Ngược lại, nếu công thức không thể phân tích, tính đúng đắn của giá trị ô không thể được bảo đảm.

## **Thêm công thức bảng tính biểu đồ vào bản trình bày**
Đầu tiên, thêm một biểu đồ vào slide đầu tiên của bản trình bày mới bằng 
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). 
Worksheet của biểu đồ sẽ được tạo tự động và có thể truy cập bằng 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) method:

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

Hãy ghi một số giá trị vào các ô bằng phương thức 
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) của kiểu **Object**, nghĩa là bạn có thể truyền bất kỳ giá trị nào vào phương thức:

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

Bây giờ để ghi công thức vào ô, bạn có thể sử dụng phương thức 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692):

*Ghi chú*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) được dùng để đặt tham chiếu ô kiểu A1. 

Để đặt tham chiếu ô R1C1Formula, bạn có thể dùng phương thức [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7):

Sau khi đó nếu bạn đọc giá trị từ các ô B2 và C2, chúng sẽ được tính toán:

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```

## **Các hằng số logic**
Bạn có thể sử dụng các hằng số logic như *FALSE* và *TRUE* trong công thức ô:

## **Các hằng số số**
Các số có thể được sử dụng ở dạng thập phân thông thường hoặc ký hiệu khoa học để tạo công thức bảng tính biểu đồ:

## **Các hằng số chuỗi**
Hằng số chuỗi (hoặc literal) là một giá trị cụ thể được sử dụng nguyên nguyên và không thay đổi. Các hằng số chuỗi có thể là: ngày tháng, văn bản, số, v.v.:

## **Các hằng số lỗi**
Đôi khi không thể tính toán kết quả bằng công thức. Trong trường hợp đó, mã lỗi sẽ hiển thị trong ô thay vì giá trị. Mỗi loại lỗi có một mã cụ thể:

- #DIV/0! – công thức cố gắng chia cho không.
- #GETTING_DATA – có thể xuất hiện trên ô khi giá trị của nó vẫn đang được tính.
- #N/A – thông tin thiếu hoặc không khả dụng. Một số nguyên nhân có thể là: các ô được dùng trong công thức rỗng, có ký tự khoảng trắng thừa, sai chính tả, v.v.
- #NAME? – không tìm thấy ô hoặc đối tượng công thức nào đó theo tên.
- #NULL! – có thể xuất hiện khi có lỗi trong công thức, ví dụ: (,) hoặc ký tự khoảng trắng được dùng thay cho dấu hai chấm (:).
- #NUM! – số trong công thức không hợp lệ, quá lớn hoặc quá nhỏ, v.v.
- #REF! – tham chiếu ô không hợp lệ.
- #VALUE! – kiểu giá trị không mong đợi. Ví dụ, giá trị chuỗi được gán cho ô số.

## **Các toán tử số học**
Bạn có thể sử dụng tất cả các toán tử số học trong công thức worksheet biểu đồ:

|**Toán tử**|**Ý nghĩa**|**Ví dụ**|
| :- | :- | :- |
|+ (dấu cộng)|Cộng hoặc dấu cộng một ngôi|2 + 3|
|- (dấu trừ)|Trừ hoặc phủ định|- 3|
|* (dấu sao)|Nhân|2 * 3|
|/ (dấu gạch chéo)|Chia|2 / 3|
|% (dấu phần trăm)|Phần trăm|30%|
|^ (dấu mũ)|Lũy thừa|2 ^ 3|

*Ghi chú*: Để thay đổi thứ tự tính, bao quanh phần công thức cần tính trước bằng dấu ngoặc đơn.

## **Các toán tử so sánh**
Bạn có thể so sánh giá trị các ô bằng các toán tử so sánh. Khi hai giá trị được so sánh bằng các toán tử này, kết quả là một giá trị logic *TRUE* hoặc *FALSE*:

|**Toán tử**|**Ý nghĩa**|**Ví dụ**|
| :- | :- | :- |
|= (dấu bằng)|Bằng|A2 = 3|
|<> (dấu không bằng)|Không bằng|A2 <> 3|
|> (dấu lớn hơn)|Lớn hơn|A2 > 3|
|>= (dấu lớn hơn hoặc bằng)|Lớn hơn hoặc bằng|A2 >= 3|
|< (dấu nhỏ hơn)|Nhỏ hơn|A2 < 3|
|<= (dấu nhỏ hơn hoặc bằng)|Nhỏ hơn hoặc bằng|A2 <= 3|

## **Tham chiếu ô kiểu A1**
**Tham chiếu ô kiểu A1** được sử dụng cho các worksheet, trong đó cột có định danh là chữ (ví dụ “*A*”) và hàng có định danh là số (ví dụ “*1*”). Tham chiếu ô kiểu A1 có thể được dùng như sau:

|**Tham chiếu ô**|**Ví dụ**|||
| :- | :- | :- | :- |
||**Tuyệt đối**|**Tương đối**|**Hỗn hợp**|
|Ô|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Hàng|$2:$2|2:2|-|
|Cột|$A:$A|A:A|-|
|Phạm vi|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Dưới đây là một ví dụ cách sử dụng tham chiếu ô kiểu A1 trong công thức:

## **Tham chiếu ô kiểu R1C1**
**Tham chiếu ô kiểu R1C1** được sử dụng cho các worksheet, trong đó cả hàng và cột đều có định danh là số. Tham chiếu ô kiểu R1C1 có thể được dùng như sau:

|**Tham chiếu ô**|**Ví dụ**|||
| :- | :- | :- | :- |
||**Tuyệt đối**|**Tương đối**|**Hỗn hợp**|
|Ô|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Hàng|R2|R[2]|-|
|Cột|C3|C[3]|-|
|Phạm vi|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Dưới đây là một ví dụ cách sử dụng tham chiếu ô kiểu A1 trong công thức:

## **Các hàm được định nghĩa trước**
Có các hàm được định nghĩa trước, có thể được dùng trong công thức để đơn giản hoá việc triển khai. Các hàm này bao gồm các thao tác thường dùng nhất, chẳng hạn:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (hệ thống ngày 1900)
- DAYS
- FIND
- FINDB
- IF
- INDEX (dạng tham chiếu)
- LOOKUP (dạng vector)
- MATCH (dạng vector)
- MAX
- SUM
- VLOOKUP

## **Câu hỏi thường gặp**

**Các tệp Excel bên ngoài có được hỗ trợ làm nguồn dữ liệu cho biểu đồ có công thức không?**

Có. Aspose.Slides hỗ trợ workbooks bên ngoài như một [nguồn dữ liệu của biểu đồ](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdatasourcetype/), cho phép bạn sử dụng các công thức từ một tệp XLSX ngoài bản trình bày.

**Công thức biểu đồ có thể tham chiếu đến các sheet trong cùng workbook bằng tên sheet không?**

Có. Công thức tuân theo mô hình tham chiếu chuẩn của Excel, vì vậy bạn có thể tham chiếu các sheet khác trong cùng workbook hoặc một workbook bên ngoài. Đối với tham chiếu bên ngoài, bao gồm đường dẫn và tên workbook theo cú pháp của Excel.