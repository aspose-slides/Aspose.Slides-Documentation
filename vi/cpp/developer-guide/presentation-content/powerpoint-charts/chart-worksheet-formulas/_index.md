---
title: Áp dụng công thức worksheet biểu đồ trong bản trình bày bằng C++
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
- C++
- Aspose.Slides
description: "Áp dụng công thức kiểu Excel trong Aspose.Slides cho worksheet biểu đồ C++ và tự động hoá báo cáo trên các tệp PPT và PPTX."
---
## **Tổng quan**

Một worksheet biểu đồ là nguồn dữ liệu phía sau một biểu đồ trong bản trình bày. Nó lưu trữ tên danh mục và chuỗi cùng với các giá trị số được hiển thị bởi biểu đồ. Trong Aspose.Slides, worksheet này có sẵn thông qua workbook dữ liệu biểu đồ, cho phép bạn làm việc với dữ liệu biểu đồ một cách lập trình.

Bài viết này giải thích cách sử dụng công thức worksheet trong dữ liệu biểu đồ để các giá trị ô có thể được tính toán và cập nhật tự động thay vì nhập thủ công. Nó chỉ ra cách gán công thức, sử dụng tham chiếu kiểu A1 và R1C1, tính lại công thức workbook và làm việc với các hằng số, toán tử, tham chiếu ô và hàm được hỗ trợ cho worksheet biểu đồ trong bản trình bày.

## **Về công thức bảng tính biểu đồ trong bản trình bày**
**Chart spreadsheet** (hoặc chart worksheet) trong bản trình bày là nguồn dữ liệu của biểu đồ. Chart spreadsheet chứa dữ liệu, được biểu diễn trên biểu đồ dưới dạng đồ họa. Khi bạn tạo một biểu đồ trong PowerPoint, worksheet liên kết với biểu đồ này cũng được tạo tự động. Chart worksheet được tạo cho mọi loại biểu đồ: biểu đồ đường, biểu đồ cột, biểu đồ sunburst, biểu đồ tròn, v.v. Để xem chart spreadsheet trong PowerPoint, bạn nên nhấp đúp vào biểu đồ:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Chart spreadsheet chứa tên các thành phần biểu đồ (Category Name: *Category1*, Serie Name) và một bảng dữ liệu số tương ứng với các danh mục và chuỗi này. Mặc định, khi bạn tạo một biểu đồ mới – dữ liệu chart spreadsheet được thiết lập với dữ liệu mặc định. Sau đó bạn có thể thay đổi dữ liệu spreadsheet trong worksheet một cách thủ công.

Thông thường, biểu đồ đại diện cho dữ liệu phức tạp (ví dụ: phân tích tài chính, phân tích khoa học), có các ô được tính toán từ giá trị của các ô khác hoặc từ dữ liệu động khác. Tính giá trị ô một cách thủ công và ghi cứng vào ô khiến việc thay đổi sau này trở nên khó khăn. Nếu bạn thay đổi giá trị của một ô nào đó, tất cả các ô phụ thuộc vào nó cũng phải được cập nhật. Hơn nữa, dữ liệu bảng có thể phụ thuộc vào dữ liệu từ các bảng khác, tạo ra một sơ đồ dữ liệu bản trình bày phức tạp cần được cập nhật một cách dễ dàng và linh hoạt.

**Chart spreadsheet formula** trong bản trình bày là một biểu thức để tự động tính toán và cập nhật dữ liệu chart spreadsheet. Công thức spreadsheet định nghĩa logic tính toán dữ liệu cho một ô hoặc một tập hợp các ô. Công thức spreadsheet là một công thức toán học hoặc logic, sử dụng: tham chiếu ô, hàm toán học, toán tử logic, toán tử số học, hàm chuyển đổi, hằng số chuỗi, v.v. Định nghĩa công thức được viết vào một ô, ô này không chứa giá trị đơn giản. Công thức spreadsheet tính toán giá trị và trả lại, sau đó giá trị này được gán cho ô. Công thức chart spreadsheet trong bản trình bày thực chất giống với công thức excel, và hỗ trợ cùng các hàm, toán tử và hằng số mặc định.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/cpp/) chart spreadsheet được biểu diễn bằng phương thức 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) của kiểu 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.charts.i_chart_data_workbook). 
Công thức spreadsheet có thể được gán và thay đổi bằng 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692). 
Các chức năng sau được hỗ trợ cho công thức trong Aspose.Slides:

- Logical constants
- Numerical constants
- String constants
- Error constants
- Arithmetic operators
- Comparison operators
- A1-style cell references
- R1C1-style cell references
- Predefined functions

Thông thường, spreadsheet lưu trữ các giá trị công thức đã tính toán cuối cùng. Nếu sau khi tải bản trình bày, dữ liệu biểu đồ không thay đổi – phương thức **IChartDataCell.get_Value()** sẽ trả về các giá trị đó khi đọc. Tuy nhiên, nếu dữ liệu spreadsheet đã bị thay đổi, khi đọc phương thức **ChartDataCell.get_Value()** sẽ ném ra **CellUnsupportedDataException** cho các công thức không được hỗ trợ. Điều này là do khi công thức được phân tích thành công, các phụ thuộc ô được xác định và tính đúng đắn của các giá trị cuối cùng được quyết định. Ngược lại, nếu công thức không thể phân tích, tính đúng đắn của giá trị ô không thể được bảo đảm.

## **Thêm công thức chart spreadsheet vào bản trình bày**
Đầu tiên, thêm một biểu đồ vào slide đầu tiên của bản trình bày mới bằng 
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). 
Worksheet của biểu đồ được tạo tự động và có thể truy cập bằng 
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

Bây giờ để ghi công thức vào ô, bạn có thể sử dụng 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) method:

*Note*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) method được sử dụng để đặt tham chiếu ô kiểu A1. 

Để đặt tham chiếu ô R1C1Formula, bạn có thể sử dụng phương thức [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7):

Sau đó nếu bạn đọc giá trị từ các ô B2 và C2, chúng sẽ được tính toán:

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```

## **Logical Constants**
Bạn có thể sử dụng các hằng số logic như *FALSE* và *TRUE* trong công thức ô:

## **Numerical Constants**
Số có thể được sử dụng ở dạng thông thường hoặc khoa học để tạo công thức chart spreadsheet:

## **String Constants**
Hằng số chuỗi (hoặc literal) là giá trị cụ thể được sử dụng nguyên trạng và không thay đổi. Hằng số chuỗi có thể là: ngày tháng, văn bản, số, v.v.:

## **Error Constants**
Đôi khi không thể tính kết quả bằng công thức. Trong trường hợp đó, mã lỗi sẽ được hiển thị trong ô thay vì giá trị. Mỗi loại lỗi có một mã cụ thể:

- #DIV/0! - công thức cố gắng chia cho zero.
- #GETTING_DATA - có thể hiển thị trên ô khi giá trị của nó vẫn đang được tính.
- #N/A - thông tin thiếu hoặc không có. Một số nguyên nhân có thể là: các ô được dùng trong công thức rỗng, có ký tự khoảng trắng thừa, lỗi chính tả, v.v.
- #NAME? - không tìm thấy một ô hoặc đối tượng công thức nào đó theo tên.
- #NULL! - có thể xuất hiện khi công thức có lỗi, như:  (,) hoặc ký tự khoảng trắng thay cho dấu hai chấm (:).
- #NUM! - số trong công thức có thể không hợp lệ, quá lớn hoặc quá nhỏ, v.v.
- #REF! - tham chiếu ô không hợp lệ.
- #VALUE! - kiểu giá trị không mong đợi. Ví dụ, giá trị chuỗi được đặt vào ô số.

## **Arithmetic Operators**
Bạn có thể sử dụng tất cả các toán tử số học trong công thức worksheet biểu đồ:

|**Toán tử**|**Ý nghĩa**|**Ví dụ**|
| :- | :- | :- |
|+ (plus sign)|Cộng hoặc dấu cộng một chiều|2 + 3|
|- (minus sign)|Trừ hoặc phép phủ định|2 - 3<br>-3|
|* (asterisk)|Nhân|2 * 3|
|/ (forward slash)|Chia|2 / 3|
|% (percent sign)|Phần trăm|30%|
|^ (caret)|Lũy thừa|2 ^ 3|

*Note*: Để thay đổi thứ tự tính, đặt phần công thức cần tính trước trong dấu ngoặc.

## **Comparison Operators**
Bạn có thể so sánh giá trị của các ô bằng các toán tử so sánh. Khi hai giá trị được so sánh bằng các toán tử này, kết quả là giá trị logic *TRUE* hoặc FALSE:

|**Toán tử**|**Ý nghĩa**|**Ví dụ**|
| :- | :- | :- |
|= (equal sign)|Bằng|A2 = 3|
|<> (not equal sign)|Không bằng|A2 <> 3|
|> (greater than sign)|Lớn hơn|A2 > 3|
|>= (greater than or equal to sign)|Lớn hơn hoặc bằng|A2 >= 3|
|< (less than sign)|Nhỏ hơn|A2 < 3|
|<= (less than or equal to sign)|Nhỏ hơn hoặc bằng|A2 <= 3|

## **A1-Style Cell References**
**A1-style cell references** được sử dụng cho các worksheet, trong đó cột có định danh chữ cái (ví dụ "*A*") và hàng có định danh số (ví dụ "*1*"). Tham chiếu ô kiểu A1 có thể được sử dụng như sau:

|**Tham chiếu ô**|**Ví dụ**| | |
| :- | :- | :- | :- |
| |Absolute|Relative|Mixed|
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Row|$2:$2|2:2|-|
|Column|$A:$A|A:A|-|
|Range|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Dưới đây là một ví dụ cách sử dụng tham chiếu ô A1-style trong công thức:

## **R1C1-Style Cell References**
**R1C1-style cell references** được sử dụng cho các worksheet, trong đó cả hàng và cột đều có định danh số. Tham chiếu ô kiểu R1C1 có thể được sử dụng như sau:

|**Tham chiếu ô**|**Ví dụ**| | |
| :- | :- | :- | :- |
| |Absolute|Relative|Mixed|
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row|R2|R[2]|-|
|Column|C3|C[3]|-|
|Range|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Dưới đây là một ví dụ cách sử dụng tham chiếu ô R1C1-style trong công thức:

## **Predefined Functions**
Có các hàm được định nghĩa trước, có thể được sử dụng trong công thức để đơn giản hoá việc triển khai. Các hàm này bao gồm các thao tác thường dùng nhất, như:

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
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**Biểu đồ có hỗ trợ các tệp Excel bên ngoài làm nguồn dữ liệu cho công thức không?**

Có. Aspose.Slides hỗ trợ workbook bên ngoài như một [chart's data source](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chartdatasourcetype/), cho phép bạn sử dụng công thức từ một tệp XLSX bên ngoài bản trình bày.

**Công thức biểu đồ có thể tham chiếu các sheet trong cùng một workbook bằng tên sheet không?**

Có. Công thức tuân theo mô hình tham chiếu chuẩn của Excel, vì vậy bạn có thể tham chiếu các sheet khác trong cùng một workbook hoặc một workbook bên ngoài. Đối với tham chiếu bên ngoài, bao gồm đường dẫn và tên workbook theo cú pháp Excel.