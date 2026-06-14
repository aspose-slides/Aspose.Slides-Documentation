---
title: Áp dụng công thức trang tính biểu đồ trong bản trình chiếu với Python
linktitle: Công thức trang tính
type: docs
weight: 70
url: /vi/python-net/chart-worksheet-formulas/
keywords:
- bảng tính biểu đồ
- trang tính biểu đồ
- công thức biểu đồ
- công thức trang tính
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
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Áp dụng công thức kiểu Excel trong Aspose.Slides cho Python thông qua các trang tính biểu đồ .NET và tự động hoá báo cáo trên các tệp PPT, PPTX và ODP."
---
## **Tổng quan**

Một trang tính biểu đồ là nguồn dữ liệu phía sau một biểu đồ trong bản trình chiếu. Nó lưu trữ tên danh mục và chuỗi cùng với các giá trị số được biểu đồ hiển thị. Trong Aspose.Slides, trang tính này có sẵn thông qua workbook dữ liệu biểu đồ, cho phép bạn làm việc với dữ liệu biểu đồ một cách chương trình.

Bài viết này giải thích cách sử dụng công thức trang tính trong dữ liệu biểu đồ sao cho giá trị ô có thể được tính toán và cập nhật tự động thay vì nhập tay. Nó cho thấy cách gán công thức, sử dụng tham chiếu kiểu A1 và R1C1, tính lại công thức workbook và làm việc với các hằng số, toán tử, tham chiếu ô và hàm chuẩn có sẵn cho trang tính biểu đồ trong bản trình chiếu.

## **Về công thức bảng tính biểu đồ trong bản trình chiếu**
**Chart spreadsheet** (hoặc chart worksheet) trong bản trình chiếu là nguồn dữ liệu của biểu đồ. Chart spreadsheet chứa dữ liệu, được biểu diễn trên biểu đồ dưới dạng đồ họa. Khi bạn tạo một biểu đồ trong PowerPoint, trang tính liên kết với biểu đồ này cũng được tạo tự động. Trang tính biểu đồ được tạo cho tất cả các loại biểu đồ: biểu đồ đường, biểu đồ cột, biểu đồ sunburst, biểu đồ tròn, v.v. Để xem chart spreadsheet trong PowerPoint bạn nên nhấp đôi vào biểu đồ:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Chart spreadsheet chứa tên các thành phần của biểu đồ (Category Name: *Category1*, Serie Name) và một bảng dữ liệu số phù hợp với các danh mục và chuỗi này. Theo mặc định, khi bạn tạo một biểu đồ mới - dữ liệu chart spreadsheet được đặt với dữ liệu mặc định. Sau đó bạn có thể thay đổi dữ liệu bảng tính trong trang tính một cách thủ công.

Thông thường, biểu đồ thể hiện dữ liệu phức tạp (ví dụ: nhà phân tích tài chính, nhà phân tích khoa học), có các ô được tính toán từ giá trị của các ô khác hoặc từ dữ liệu động khác. Việc tính giá trị ô bằng tay và mã cứng vào ô khiến việc thay đổi trong tương lai trở nên khó khăn. Nếu bạn thay đổi giá trị của một ô nào đó, tất cả các ô phụ thuộc vào nó sẽ cần được cập nhật. Hơn nữa, dữ liệu bảng có thể phụ thuộc vào dữ liệu từ các bảng khác, tạo ra một lược đồ dữ liệu bản trình chiếu phức tạp cần được cập nhật một cách dễ dàng và linh hoạt.

**Chart spreadsheet formula** trong bản trình chiếu là một biểu thức để tự động tính toán và cập nhật dữ liệu chart spreadsheet. Công thức bảng tính định nghĩa logic tính toán dữ liệu cho một ô hoặc một tập hợp các ô. Công thức bảng tính là công thức toán học hoặc công thức logic, sử dụng: tham chiếu ô, hàm toán học, toán tử logic, toán tử số học, hàm chuyển đổi, hằng số chuỗi, v.v. Định nghĩa công thức được viết vào một ô, và ô này không chứa một giá trị đơn giản. Công thức bảng tính tính giá trị và trả lại, sau đó giá trị này được gán cho ô. Công thức chart spreadsheet trong bản trình chiếu thực chất là cùng một công thức excel, và chúng hỗ trợ cùng các hàm mặc định, toán tử và hằng số để triển khai.

Trong [**Aspose.Slides** ](https://products.aspose.com/slides/vi/python-net/) chart spreadsheet được đại diện bằng 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdata/) thuộc tính của
[**IChartDataWorkbook**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdataworkbook/) kiểu. 
Công thức bảng tính có thể được gán và thay đổi bằng 
[**formula**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdatacell/) thuộc tính. 
Các chức năng sau được hỗ trợ cho công thức trong Aspose.Slides:

- Hằng số logic
- Hằng số số
- Hằng số chuỗi
- Hằng số lỗi
- Toán tử số học
- Toán tử so sánh
- Tham chiếu ô kiểu A1
- Tham chiếu ô kiểu R1C1
- Các hàm chuẩn



Thông thường, bảng tính lưu trữ các giá trị công thức đã tính cuối cùng. Nếu sau khi tải bản trình chiếu, dữ liệu biểu đồ không bị thay đổi - **IChartDataCell.Value** thuộc tính sẽ trả về các giá trị đó khi đọc. Nhưng, nếu dữ liệu bảng tính đã được thay đổi, khi đọc **ChartDataCell.Value** thuộc tính nó sẽ ném ra **CellUnsupportedDataException** cho các công thức không được hỗ trợ. Điều này vì khi công thức được phân tích thành công, các phụ thuộc ô được xác định và tính đúng đắn của các giá trị cuối cùng được xác nhận. Nhưng, nếu công thức không thể phân tích, tính đúng đắn của giá trị ô không thể được đảm bảo.
## **Thêm công thức chart spreadsheet vào bản trình chiếu**
Đầu tiên, thêm một biểu đồ với một số dữ liệu mẫu vào slide đầu tiên của bản trình chiếu mới bằng 
[add_chart](https://reference.aspose.com/slides/vi/python-net/aspose.slides/ishapecollection/). 
Trang tính của biểu đồ được tạo tự động và có thể truy cập bằng 
[**chart_data_workbook**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdata/) thuộc tính:



```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```



Hãy ghi một số giá trị vào các ô bằng 
[**value**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdatacell/) thuộc tính 
của kiểu **Object**, có nghĩa là bạn có thể đặt bất kỳ giá trị nào cho thuộc tính này:



```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```



Bây giờ để viết công thức vào ô, bạn có thể sử dụng 
[**formula**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdatacell/) thuộc tính:

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Note*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdatacell/) thuộc tính được dùng để đặt tham chiếu ô kiểu A1. 



Để đặt tham chiếu ô [r1c1_formula](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdatacell/) , bạn có thể sử dụng thuộc tính [**r1c1_formula**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/ichartdatacell/):

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Sau đó sử dụng phương thức [**calculate_formulas**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdataworkbook/) để tính tất cả công thức trong workbook và cập nhật giá trị các ô tương ứng:



```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```


## **Hằng số logic**
Bạn có thể sử dụng hằng số logic như *FALSE* và *TRUE* trong công thức ô:




## **Hằng số số**
Số có thể được sử dụng ở dạng thường hoặc dạng khoa học để tạo công thức chart spreadsheet:




## **Hằng số chuỗi**
Hằng số chuỗi (hoặc hằng literal) là một giá trị cụ thể được sử dụng nguyên trạng và không thay đổi. Hằng số chuỗi có thể là: ngày, văn bản, số, v.v.:




## **Hằng số lỗi**
Đôi khi không thể tính toán kết quả bằng công thức. Trong trường hợp đó, mã lỗi sẽ hiển thị trong ô thay vì giá trị của nó. Mỗi loại lỗi có một mã cụ thể:

- #DIV/0! - công thức cố gắng chia cho zero.
- #GETTING_DATA - có thể hiển thị trên một ô, trong khi giá trị của nó vẫn đang được tính toán.
- #N/A - thông tin thiếu hoặc không khả dụng. Một số nguyên nhân có thể là: các ô được sử dụng trong công thức rỗng, có ký tự khoảng trắng thừa, lỗi chính tả, v.v.
- #NAME? - không tìm thấy một ô nào đó hoặc đối tượng công thức khác theo tên của nó. 
- #NULL! - có thể xuất hiện khi có lỗi trong công thức, như:  (,) hoặc ký tự khoảng trắng được dùng thay cho dấu hai chấm (:).
- #NUM! - số trong công thức có thể không hợp lệ, quá dài hoặc quá ngắn, v.v.
- #REF! - tham chiếu ô không hợp lệ.
- #VALUE! - kiểu giá trị không mong đợi. Ví dụ, giá trị chuỗi được đặt vào ô số.



## **Toán tử số học**
Bạn có thể sử dụng tất cả các toán tử số học trong công thức trang tính biểu đồ:



|**Toán tử**|**Ý nghĩa**|**Ví dụ**|
| :- | :- | :- |
|+ (dấu cộng)|Cộng hoặc dấu cộng một phần tử|2 + 3|
|- (dấu trừ)|Trừ hoặc phủ định|2 - 3<br>-3|
|* (dấu sao)|Nhân|2 * 3|
|/ (dấu gạch chéo)|Chia|2 / 3|
|% (dấu phần trăm)|Phần trăm|30%|
|^ (dấu mũ)|Lũy thừa|2 ^ 3|


*Note*: Để thay đổi thứ tự tính toán, đặt trong dấu ngoặc phần của công thức cần tính trước.


## **Toán tử so sánh**
Bạn có thể so sánh giá trị của các ô bằng các toán tử so sánh. Khi hai giá trị được so sánh bằng các toán tử này, kết quả là một giá trị logic là *TRUE* hoặc FALSE:



|**Toán tử**|**Ý nghĩa**|**Ý nghĩa**|
| :- | :- | :- |
|= (dấu bằng)|Bằng|A2 = 3|
|<> (dấu không bằng)|Không bằng|A2 <> 3|
|> (dấu lớn hơn)|Lớn hơn|A2 > 3|
|>= (dấu lớn hơn hoặc bằng)|Lớn hơn hoặc bằng|A2 >= 3|
|< (dấu nhỏ hơn)|Nhỏ hơn|A2 < 3|
|<= (dấu nhỏ hơn hoặc bằng)|Nhỏ hơn hoặc bằng|A2 <= 3|

## **Tham chiếu ô kiểu A1**
**Tham chiếu ô kiểu A1** được sử dụng cho các trang tính, trong đó cột có định danh bằng chữ (ví dụ: "*A*") và hàng có định danh bằng số (ví dụ: "*1*"). Tham chiếu ô kiểu A1 có thể được sử dụng theo cách sau:



|**Tham chiếu ô**|**Ví dụ**|||
| :- | :- | :- | :- |
||Tuyệt đối|Tương đối|Kết hợp|
|Ô|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Hàng|$2:$2|2:2|-
|Cột|$A:$A|A:A|-
|Phạm vi|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


Dưới đây là một ví dụ cách sử dụng tham chiếu ô kiểu A1 trong công thức:




## **Tham chiếu ô kiểu R1C1**
**Tham chiếu ô kiểu R1C1** được sử dụng cho các trang tính, trong đó cả hàng và cột đều có định danh số. Tham chiếu ô kiểu R1C1 có thể được sử dụng theo cách sau:



|**Tham chiếu ô**|**Ví dụ**|||
| :- | :- | :- | :- |
||Tuyệt đối|Tương đối|Kết hợp|
|Ô|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Hàng|R2|R[2]|-
|Cột|C3|C[3]|-
|Phạm vi|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Dưới đây là một ví dụ cách sử dụng tham chiếu ô kiểu A1 trong công thức:




## **Các hàm chuẩn**
Có các hàm chuẩn, có thể được sử dụng trong công thức để đơn giản hoá việc triển khai. Các hàm này bao gồm các thao tác thường dùng nhất, như: 

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

**Biểu đồ có hỗ trợ các tệp Excel bên ngoài làm nguồn dữ liệu cho công thức không?**

Có. Aspose.Slides hỗ trợ workbook bên ngoài như một [chart's data source](https://reference.aspose.com/slides/vi/python-net/aspose.slides.charts/chartdatasourcetype/), cho phép bạn sử dụng công thức từ một tệp XLSX bên ngoài bản trình chiếu.

**Công thức biểu đồ có thể tham chiếu các sheet trong cùng workbook bằng tên sheet không?**

Có. Công thức tuân theo mô hình tham chiếu chuẩn của Excel, vì vậy bạn có thể tham chiếu các sheet khác trong cùng workbook hoặc workbook bên ngoài. Đối với tham chiếu bên ngoài, bao gồm đường dẫn và tên workbook sử dụng cú pháp Excel.

---
title: Áp dụng công thức trang tính biểu đồ trong bản trình chiếu với Python
linktitle: Công thức trang tính
type: docs
weight: 70
url: /vi/python-net/chart-worksheet-formulas/
keywords:
- bảng tính biểu đồ
- trang tính biểu đồ
- công thức biểu đồ
- công thức trang tính
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
- OpenDocument
- bản trình chiếu
- Python
- Aspose.Slides
description: "Áp dụng công thức kiểu Excel trong Aspose.Slides cho Python thông qua các trang tính biểu đồ .NET và tự động hoá báo cáo trên các tệp PPT, PPTX và ODP."
---