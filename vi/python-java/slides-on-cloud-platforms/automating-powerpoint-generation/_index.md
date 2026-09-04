---
title: "Tự động tạo PowerPoint trong Python: Tạo bài thuyết trình động một cách dễ dàng"
linktitle: Tự động tạo PowerPoint
type: docs
weight: 20
url: /vi/python-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- nền tảng đám mây
- tích hợp đám mây
- tự động tạo PowerPoint
- tạo bài thuyết trình bằng chương trình
- tự động hoá PowerPoint
- tạo slide động
- báo cáo kinh doanh tự động
- tự động hoá PPT
- bài thuyết trình Python
- Python
- Aspose.Slides
description: "Tự động tạo PowerPoint với Aspose.Slides cho Python thông qua Java: tạo bài thuyết trình kinh doanh với biểu đồ, bảng và các dấu đầu dòng trong các ứng dụng đám mây."
---
## **Introduction**

Tạo bài thuyết trình thủ công trở nên lặp lại khi nội dung của chúng thay đổi thường xuyên. Các báo cáo hàng tuần, tài liệu đào tạo và bài thuyết trình cho khách hàng thường có cấu trúc chung nhưng cần dữ liệu mới cho mỗi lần giao.

Aspose.Slides cho Python thông qua Java cho phép bạn tạo các bài thuyết trình này từ các ứng dụng Python. Bạn có thể tích hợp việc tạo slide vào các cổng thông tin web, công việc theo lịch và các worker trên đám mây, sử dụng dữ liệu từ cơ sở dữ liệu, API hoặc tệp tải lên.

## **Common Use Cases for PowerPoint Automation in Python**

- **Báo cáo kinh doanh và bảng điều khiển:** chuyển các con số bán hàng và chỉ số hiệu suất thành biểu đồ và bảng.
- **Bài thuyết trình bán hàng cá nhân hoá:** điền dữ liệu riêng cho từng khách hàng vào các slide đồng thời duy trì thiết kế nhất quán.
- **Nội dung giáo dục:** lắp ráp bài học, câu hỏi trắc nghiệm và tóm tắt khóa học từ tài liệu có cấu trúc.
- **Thông tin dựa trên dữ liệu và AI:** sử dụng kết quả từ phân tích hoặc dịch vụ xử lý ngôn ngữ làm nội dung cho bài thuyết trình.
- **Slide dựa trên phương tiện truyền thông:** kết hợp hình ảnh hoặc ảnh chụp màn hình tải lên với văn bản giải thích.
- **Luồng công việc tài liệu:** chuyển nội dung được trích xuất bởi các công cụ khác vào bố cục slide.
- **Công cụ cho nhà phát triển:** tạo tóm tắt bản phát hành, tổng quan kỹ thuật hoặc demo từ dữ liệu dự án.

## **Prerequisites**

Tham khảo [Cài đặt](/slides/vi/python-java/installation/) để thiết lập Python, Java, JPype và Aspose.Slides. Đối với triển khai trên đám mây, cũng xem [Slides trên nền tảng đám mây](/slides/vi/python-java/slides-on-cloud-platforms/).

Ví dụ sử dụng dữ liệu kinh doanh cố định nên có thể chạy mà không cần cơ sở dữ liệu hoặc dịch vụ bên ngoài. Thay các giá trị này bằng dữ liệu từ ứng dụng của bạn khi tích hợp vào quy trình báo cáo.

{{% alert color="info" title="Note" %}}
Bạn có thể thử ví dụ mà không có giấy phép, nhưng đầu ra đánh giá sẽ có watermark và chịu các hạn chế của phiên bản đánh giá. Xem [Đánh giá Aspose.Slides](/slides/vi/python-java/evaluate-aspose-slides/) để biết chi tiết và thông tin về giấy phép tạm thời.
{{% /alert %}}

## **Build the Presentation**

Đoạn script đầy đủ dưới đây tạo một bài thuyết trình chứa bốn slide. Mỗi bước sử dụng cùng một bài thuyết trình, và bước cuối cùng lưu nó dưới dạng `presentation.pptx`.

### **Create a Title Slide**

Sử dụng slide đầu tiên trong một [Presentation] mới và áp dụng bố cục tiêu đề. Điền các placeholder tiêu đề và phụ đề của nó với tiêu đề báo cáo và khán giả.

![Slide tiêu đề](slide_0.png)

### **Add a Slide with a Column Chart**

Thêm một slide trống và tạo biểu đồ bằng [ShapeCollection.addChart](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addChart). Điền workbook nhúng của nó với năm khu vực và một chuỗi bán hàng. Các giá trị vẫn có thể chỉnh sửa trong PowerPoint.

![Slide có biểu đồ](slide_1.png)

### **Add a Slide with a Table**

Tạo một bảng bằng [ShapeCollection.addTable](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addTable) và điền hai cột với tên chỉ số và giá trị. Ví dụ này truyền các mảng Java explicit của kiểu double cho độ rộng cột và chiều cao hàng qua JPype.

![Slide có bảng](slide_2.png)

### **Add a Summary Slide with Bullet Points**

Tạo một hình dạng văn bản và thêm một [Paragraph] cho mỗi mục hành động. Áp dụng dấu đầu dòng dạng biểu tượng và văn bản màu đen cho mỗi đoạn, và loại bỏ màu nền và viền của hình dạng.

![Slide tóm tắt](slide_3.png)

### **Save the Presentation**

Sử dụng [Presentation.save] để ghi file PowerPoint. Giải phóng bài thuyết trình bằng [Presentation.dispose] trong một khối `finally`.

### **Complete Python Example**

Lưu script này vào một thư mục có quyền ghi và chạy nó với môi trường Python đã cấu hình ở trên. Nó khởi động JVM chỉ khi cần và giữ nó hoạt động cho đến khi quá trình kết thúc. Đối với việc sử dụng notebook và dịch vụ, xem [Hướng dẫn vòng đời JVM](/slides/vi/python-java/limitations-and-api-differences/#import-the-library).

```python
import jpype
import asposeslides
from jpype.types import JArray, JDouble

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ChartType, FillType, LegendPositionType, Paragraph, Presentation, SaveFormat, ShapeType, SlideLayoutType
from java.awt import Color


def create_bullet_paragraph(text):
    paragraph = Paragraph()
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    paragraph.getParagraphFormat().setIndent(15)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText(text)
    return paragraph


presentation = Presentation()
try:
    # Tạo slide tiêu đề.
    title_slide = presentation.getSlides().get_Item(0)
    title_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Title)
    title_slide.setLayoutSlide(title_layout)
    title_shape = title_slide.getShapes().get_Item(0)
    subtitle_shape = title_slide.getShapes().get_Item(1)
    title_shape.getTextFrame().setText("Quarterly Business Review – Q1 2025")
    subtitle_shape.getTextFrame().setText("Prepared for Executive Team")

    # Thêm slide biểu đồ.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    chart_slide = presentation.getSlides().addEmptySlide(blank_layout)
    chart = chart_slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350, False)
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Data from January – March 2025")
    chart.getChartTitle().setOverlay(False)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    sales = [("North America", 480), ("Europe", 365), ("Asia Pacific", 290), ("Latin America", 150), ("Middle East", 120)]
    for row_index, (region, amount) in enumerate(sales, start=1):
        category_cell = workbook.getCell(worksheet_index, row_index, 0, region)
        chart.getChartData().getCategories().add(category_cell)

    series_cell = workbook.getCell(worksheet_index, 0, 1, "Sales ($K)")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, (region, amount) in enumerate(sales, start=1):
        value_cell = workbook.getCell(worksheet_index, row_index, 1, JDouble(amount))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # Thêm slide bảng.
    table_slide = presentation.getSlides().addEmptySlide(blank_layout)
    column_widths = JArray(JDouble)([200, 100])
    row_heights = JArray(JDouble)([40, 40, 40, 40, 40])
    table = table_slide.getShapes().addTable(200, 200, column_widths, row_heights)
    metrics = [("Metric", "Value"), ("Total Revenue", "$1.4M"), ("Gross Margin", "54%"), ("New Customers", "340"), ("Customer Retention", "87%")]
    for row_index, (metric, value) in enumerate(metrics):
        table.getColumns().get_Item(0).get_Item(row_index).getTextFrame().setText(metric)
        table.getColumns().get_Item(1).get_Item(row_index).getTextFrame().setText(value)

    # Thêm slide tóm tắt.
    summary_slide = presentation.getSlides().addEmptySlide(blank_layout)
    bullet_list = summary_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 50, 600, 200)
    bullet_list.getFillFormat().setFillType(FillType.NoFill)
    bullet_list.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    paragraphs = bullet_list.getTextFrame().getParagraphs()
    paragraphs.clear()
    action_items = ["Strong performance in North America; growth opportunity in Asia Pacific", "Improve marketing outreach in underperforming regions", "Prepare new campaign strategy for Q2", "Schedule follow-up review in early July"]
    for text in action_items:
        paragraph = create_bullet_paragraph(text)
        paragraphs.add(paragraph)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Các hình minh họa hiển thị các slide tương ứng từ ví dụ Java. Giao diện có thể thay đổi tùy theo phông chữ đã cài và chế độ đánh giá.

## **Use the Example in a Cloud Application**

Lấy dữ liệu báo cáo trước khi xây dựng bài thuyết trình, sau đó truyền nó vào các bước tạo biểu đồ, bảng và văn bản. Sử dụng đường dẫn xuất riêng cho mỗi công việc. Sau khi lưu, ứng dụng của bạn có thể tải tệp lên bộ nhớ đối tượng hoặc trả về dưới dạng tải xuống.

Giữ JVM chạy liên tục qua các công việc trong cùng một tiến trình worker và giải phóng mỗi bài thuyết trình khi công việc của nó hoàn thành. Đóng gói các phông chữ cần thiết cho thiết kế báo cáo cùng với triển khai để giảm sự khác biệt giữa các môi trường.

## **Conclusion**

Ví dụ này tạo một bài thuyết trình kinh doanh hoàn chỉnh từ Python sử dụng các biểu đồ, bảng và văn bản có thể chỉnh sửa. Thay thế dữ liệu mẫu bằng dữ liệu ứng dụng làm cho cách tiếp cận này hữu ích cho các báo cáo định kỳ, bài thuyết trình cho khách hàng và tài liệu giáo dục.

## **FAQ**

**Script có yêu cầu Microsoft PowerPoint hoặc Excel không?**

Không. Aspose.Slides tạo các slide và workbook nhúng của biểu đồ mà không cần bất kỳ ứng dụng nào.

**Tại sao ví dụ bảng lại sử dụng mảng Java?**

Phương thức nền tảng chấp nhận các mảng Java double. Việc sử dụng mảng explicit giúp làm rõ kiểu số được truyền qua JPype.

**Tôi có thể lưu cùng một bài thuyết trình dưới dạng PDF hoặc ODP không?**

Có. Trước khi giải phóng, lưu sang tên tệp đầu ra khác với giá trị [SaveFormat] tương ứng. Xem [Supported File Formats] để biết khả năng cụ thể của từng định dạng.

**Tôi có thể sử dụng mẫu có thương hiệu không?**

Có. Tải mẫu của bạn thay vì tạo một bài thuyết trình trống, sau đó điều chỉnh bố cục và lựa chọn placeholder cho mẫu đó. Ví dụ này giả định các bố cục và thứ tự placeholder của một bài thuyết trình mặc định mới.