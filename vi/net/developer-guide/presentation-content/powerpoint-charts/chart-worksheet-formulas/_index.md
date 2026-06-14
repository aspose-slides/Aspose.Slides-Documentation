---
title: Áp dụng công thức worksheet biểu đồ trong bài thuyết trình bằng .NET
linktitle: Công thức Worksheet
type: docs
weight: 70
url: /vi/net/chart-worksheet-formulas/
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
- hàm dựng sẵn
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Áp dụng công thức kiểu Excel trong Aspose.Slides cho worksheet biểu đồ .NET và tự động hoá báo cáo trên các tệp PPT và PPTX."
---
## **Tổng quan**

Bảng tính biểu đồ là nguồn dữ liệu phía sau một biểu đồ trong bài thuyết trình. Nó lưu trữ tên danh mục và chuỗi cùng với các giá trị số được biểu đồ hiển thị. Trong Aspose.Slides, bảng tính này có sẵn thông qua chart data workbook, cho phép bạn làm việc với dữ liệu biểu đồ một cách lập trình.

Bài viết này giải thích cách sử dụng công thức bảng tính trong dữ liệu biểu đồ để các giá trị ô có thể được tính và cập nhật tự động thay vì nhập thủ công. Nó cho thấy cách gán công thức, sử dụng cả tham chiếu kiểu A1 và kiểu R1C1, tính lại công thức trong workbook và làm việc với các hằng số, toán tử, tham chiếu ô và các hàm dựng sẵn được hỗ trợ cho bảng tính biểu đồ trong bài thuyết trình.

## **Về công thức bảng tính biểu đồ trong bài thuyết trình**
**Bảng tính biểu đồ** (hoặc worksheet biểu đồ) trong bài thuyết trình là nguồn dữ liệu của biểu đồ. Bảng tính biểu đồ chứa dữ liệu, được biểu diễn trên biểu đồ dưới dạng đồ họa. Khi bạn tạo một biểu đồ trong PowerPoint, worksheet liên quan đến biểu đồ này cũng được tự động tạo. Worksheet biểu đồ được tạo cho tất cả các loại biểu đồ: biểu đồ đường, biểu đồ cột, biểu đồ sunburst, biểu đồ tròn, v.v. Để xem bảng tính biểu đồ trong PowerPoint, bạn chỉ cần nhấp đúp vào biểu đồ:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Bảng tính biểu đồ chứa tên các yếu tố của biểu đồ (Tên danh mục: *Category1*, Tên chuỗi) và một bảng dữ liệu số phù hợp với các danh mục và chuỗi này. Theo mặc định, khi bạn tạo một biểu đồ mới – dữ liệu bảng tính biểu đồ được đặt với dữ liệu mặc định. Sau đó bạn có thể thay đổi dữ liệu bảng tính trong worksheet một cách thủ công.

Thường thì biểu đồ biểu thị dữ liệu phức tạp (ví dụ: các nhà phân tích tài chính, nhà phân tích khoa học), có các ô được tính dựa trên giá trị của các ô khác hoặc từ dữ liệu động khác. Tính giá trị ô một cách thủ công và gắn giá trị cố định vào ô khiến việc thay đổi trong tương lai trở nên khó khăn. Nếu bạn thay đổi giá trị của một ô nào đó, tất cả các ô phụ thuộc vào nó cũng sẽ cần được cập nhật. Hơn nữa, dữ liệu bảng có thể phụ thuộc vào dữ liệu từ các bảng khác, tạo ra một sơ đồ dữ liệu bài thuyết trình phức tạp cần được cập nhật một cách dễ dàng và linh hoạt.

**Công thức bảng tính biểu đồ** trong bài thuyết trình là một biểu thức để tự động tính và cập nhật dữ liệu bảng tính biểu đồ. Công thức bảng tính định nghĩa logic tính toán dữ liệu cho một ô hoặc một tập hợp các ô. Công thức bảng tính là một công thức toán học hoặc công thức logic, sử dụng: tham chiếu ô, hàm toán học, toán tử logic, toán tử số học, hàm chuyển đổi, hằng số chuỗi, v.v. Định nghĩa công thức được viết vào một ô, và ô này không chứa giá trị đơn giản. Công thức bảng tính tính giá trị và trả lại, sau đó giá trị này được gán cho ô. Công thức bảng tính trong bài thuyết trình thực chất giống như công thức Excel, và chúng hỗ trợ cùng các hàm, toán tử và hằng số mặc định để thực hiện.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/net/) bảng tính biểu đồ được biểu diễn bằng thuộc tính 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) của 
kiểu [**IChartDataWorkbook**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdataworkbook). 
Công thức bảng tính có thể được gán và thay đổi bằng thuộc tính 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/properties/formula). 
Chức năng sau được hỗ trợ cho công thức trong Aspose.Slides:

- Hằng số logic
- Hằng số số
- Hằng số chuỗi
- Hằng số lỗi
- Toán tử số học
- Toán tử so sánh
- Tham chiếu ô kiểu A1
- Tham chiếu ô kiểu R1C1
- Các hàm dựng sẵn

Thông thường, các bảng tính lưu trữ các giá trị công thức đã tính cuối cùng. Nếu sau khi tải bài thuyết trình, dữ liệu biểu đồ không thay đổi – thuộc tính **IChartDataCell.Value** sẽ trả về các giá trị đó khi đọc. Nhưng nếu dữ liệu bảng tính đã được thay đổi, khi đọc thuộc tính **ChartDataCell.Value** nó sẽ ném **CellUnsupportedDataException** cho các công thức không được hỗ trợ. Điều này xảy ra vì khi công thức được phân tích thành công, các phụ thuộc ô được xác định và tính đúng đắn của các giá trị cuối cùng được xác nhận. Ngược lại, nếu công thức không thể phân tích, không thể đảm bảo tính đúng đắn của giá trị ô.

## **Thêm công thức bảng tính biểu đồ vào bài thuyết trình**
Đầu tiên, thêm một biểu đồ với một số dữ liệu mẫu vào slide đầu tiên của bài thuyết trình mới bằng 
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/vi/net/aspose.slides.ishapecollection/addchart/methods/1). 
Worksheet của biểu đồ được tạo tự động và có thể truy cập bằng thuộc tính 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook):

``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}

```

Hãy ghi một số giá trị vào các ô bằng thuộc tính 
[**IChartDataCell.Value**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/properties/value) 
của kiểu **Object**, nghĩa là bạn có thể đặt bất kỳ giá trị nào cho thuộc tính này:

``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```

Bây giờ để ghi công thức vào ô, bạn có thể sử dụng thuộc tính 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/properties/formula):

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*Lưu ý*: Thuộc tính [**IChartDataCell.Formula**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/properties/formula) được dùng để đặt tham chiếu ô kiểu A1. 

Để đặt tham chiếu ô [R1C1Formula](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula), bạn có thể sử dụng thuộc tính [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula):

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

Sau đó sử dụng phương thức [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) để tính tất cả công thức trong workbook và cập nhật các giá trị ô tương ứng:

``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```

## **Hằng số logic**
Bạn có thể sử dụng các hằng số logic như *FALSE* và *TRUE* trong công thức ô:

## **Hằng số số**
Các số có thể được dùng ở dạng thập phân hoặc ký hiệu khoa học để tạo công thức bảng tính biểu đồ:

## **Hằng số chuỗi**
Hằng số chuỗi (hoặc literal) là một giá trị cụ thể được sử dụng nguyên vẹn và không thay đổi. Hằng số chuỗi có thể là: ngày, văn bản, số, v.v.:

## **Hằng số lỗi**
Đôi khi không thể tính toán kết quả bằng công thức. Trong trường hợp đó, mã lỗi sẽ hiển thị trong ô thay vì giá trị của nó. Mỗi loại lỗi có một mã cụ thể:

- #DIV/0! – công thức cố gắng chia cho 0.
- #GETTING_DATA – có thể xuất hiện trên một ô khi giá trị của nó vẫn đang được tính.
- #N/A – thông tin thiếu hoặc không khả dụng. Một số nguyên nhân có thể là: các ô được dùng trong công thức trống, có ký tự khoảng cách thừa, lỗi chính tả, v.v.
- #NAME? – không tìm thấy một ô hoặc đối tượng công thức nào đó theo tên.
- #NULL! – có thể xuất hiện khi công thức có lỗi, ví dụ: (,) hoặc ký tự khoảng cách được dùng thay cho dấu hai chấm (:).
- #NUM! – số trong công thức không hợp lệ, quá lớn hoặc quá nhỏ, v.v.
- #REF! – tham chiếu ô không hợp lệ.
- #VALUE! – kiểu giá trị không mong đợi. Ví dụ, giá trị chuỗi được đặt vào ô số.

## **Toán tử số học**
Bạn có thể sử dụng tất cả các toán tử số học trong công thức worksheet biểu đồ:

|**Toán tử**|**Ý nghĩa**|**Ví dụ**|
| :- | :- | :- |
|+ (dấu cộng)|Cộng hoặc dấu cộng một ngôi|2 + 3|
|- (dấu trừ)|Trừ hoặc phủ định|2 - 3<br>-3|
|* (dấu sao)|Nhân|2 * 3|
|/ (dấu gạch chéo)|Chia|2 / 3|
|% (dấu phần trăm)|Phần trăm|30%|
|^ (dấu mũ)|Lũy thừa|2 ^ 3|

*Lưu ý*: Để thay đổi thứ tự tính, đặt phần công thức cần tính trước trong dấu ngoặc đơn.

## **Toán tử so sánh**
Bạn có thể so sánh các giá trị của ô bằng các toán tử so sánh. Khi hai giá trị được so sánh bằng các toán tử này, kết quả là một giá trị logic *TRUE* hoặc FALSE:

|**Toán tử**|**Ý nghĩa**|**Ví dụ**|
| :- | :- | :- |
|= (dấu bằng)|Bằng|A2 = 3|
|<> (dấu không bằng)|Không bằng|A2 <> 3|
|> (dấu lớn hơn)|Lớn hơn|A2 > 3|
|>= (dấu lớn hơn hoặc bằng)|Lớn hơn hoặc bằng|A2 >= 3|
|< (dấu nhỏ hơn)|Nhỏ hơn|A2 < 3|
|<= (dấu nhỏ hơn hoặc bằng)|Nhỏ hơn hoặc bằng|A2 <= 3|

## **Tham chiếu ô kiểu A1**
**Tham chiếu ô kiểu A1** được dùng cho các worksheet, trong đó cột có định danh bằng chữ (ví dụ: "*A*") và hàng có định danh bằng số (ví dụ: "*1*"). Tham chiếu ô kiểu A1 có thể được sử dụng như sau:

|**Tham chiếu ô**|**Ví dụ**|||
| :- | :- | :- | :- |
||Tuyệt đối|Tương đối|Kết hợp|
|Ô|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Hàng|$2:$2|2:2|-|
|Cột|$A:$A|A:A|-|
|Phạm vi|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Dưới đây là một ví dụ cách sử dụng tham chiếu ô kiểu A1 trong công thức:

## **Tham chiếu ô kiểu R1C1**
**Tham chiếu ô kiểu R1C1** được dùng cho các worksheet, trong đó cả hàng và cột đều có định danh số. Tham chiếu ô kiểu R1C1 có thể được sử dụng như sau:

|**Tham chiếu ô**|**Ví dụ**|||
| :- | :- | :- | :- |
||Tuyệt đối|Tương đối|Kết hợp|
|Ô|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Hàng|R2|R[2]|-|
|Cột|C3|C[3]|-|
|Phạm vi|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Dưới đây là một ví dụ cách sử dụng tham chiếu ô kiểu A1 trong công thức:

## **Các hàm dựng sẵn**
Có một số hàm dựng sẵn, có thể được sử dụng trong công thức để đơn giản hoá việc triển khai. Các hàm này gói gọn các thao tác thường dùng nhất, chẳng hạn:

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

**Có hỗ trợ tệp Excel bên ngoài làm nguồn dữ liệu cho biểu đồ có công thức không?**

Có. Aspose.Slides hỗ trợ workbook bên ngoài làm [nguồn dữ liệu của biểu đồ](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdatasourcetype/), cho phép bạn sử dụng công thức từ một tệp XLSX ngoài bài thuyết trình.

**Công thức biểu đồ có thể tham chiếu các sheet trong cùng một workbook bằng tên sheet không?**

Có. Công thức tuân theo mô hình tham chiếu chuẩn của Excel, vì vậy bạn có thể tham chiếu các sheet khác trong cùng một workbook hoặc một workbook bên ngoài. Đối với tham chiếu bên ngoài, bao gồm đường dẫn và tên workbook theo cú pháp của Excel.