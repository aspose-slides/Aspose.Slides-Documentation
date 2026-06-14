---
title: "Quản lý Workbook Biểu đồ trong Bản trình bày bằng Java"
linktitle: "Workbook Biểu đồ"
type: docs
weight: 70
url: /vi/java/chart-workbook/
keywords:
- "workbook biểu đồ"
- "dữ liệu biểu đồ"
- "ô workbook"
- "nhãn dữ liệu"
- "bảng tính"
- "nguồn dữ liệu"
- "workbook bên ngoài"
- "dữ liệu bên ngoài"
- "PowerPoint"
- "bản trình bày"
- "Java"
- "Aspose.Slides"
description: "Khám phá Aspose.Slides cho Java: dễ dàng quản lý workbook biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hoá dữ liệu bản trình bày của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với workbook biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua luồng workbook, sử dụng các ô workbook làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet và chỉ định loại nguồn dữ liệu cho các giá trị biểu đồ.  
Nó cũng đề cập đến việc làm việc với workbook bên ngoài như nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một workbook bên ngoài, lấy đường dẫn của workbook bên ngoài được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi workbook khả dụng.

## **Đọc và Ghi Dữ liệu Biểu đồ từ Workbook**
Aspose.Slides cung cấp các phương thức [ReadWorkbookStream](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartData#readWorkbookStream--) và [WriteWorkbookStream](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) cho phép bạn đọc và ghi các workbook dữ liệu biểu đồ (chứa dữ liệu biểu đồ đã được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự như nguồn.

Đoạn mã Java này minh họa một thao tác mẫu:

```java
Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Đặt ô WorkBook làm Nhãn Dữ liệu Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Thêm biểu đồ Bubble với một số dữ liệu.
4. Truy cập series của biểu đồ.
5. Đặt ô workbook làm nhãn dữ liệu.
6. Lưu bản trình bày.

Đoạn mã Java này cho bạn cách đặt ô workbook làm nhãn dữ liệu biểu đồ:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Khởi tạo một lớp presentation đại diện cho tệp trình chiếu
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Quản lý Worksheets**

Đoạn mã Java này minh họa một thao tác trong đó phương thức [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) được sử dụng để truy cập bộ sưu tập worksheet:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Chỉ định Loại Nguồn Dữ liệu**

Đoạn mã Java này cho bạn cách chỉ định một loại cho nguồn dữ liệu:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Phát hiện Định dạng Workbook nhúng không được Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng workbook nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `getEmbeddedWorkbookType` trên [IChartData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IChartData) cùng với liệt kê [WorkbookType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/WorkbookType) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
                // Workbook nhúng ở định dạng .xlsb, không được hỗ trợ.
                continue;
        }

        // Đọc hoặc chỉnh sửa dữ liệu workbook biểu đồ ở đây.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook Bên Ngoài**

{{% alert color="primary" %}} 
Trong [Aspose.Slides 19.4](https://docs.aspose.com/slides/vi/java/aspose-slides-for-java-19-4-release-notes/), chúng tôi đã triển khai hỗ trợ cho workbook bên ngoài làm nguồn dữ liệu cho biểu đồ.
{{% /alert %}} 

### **Tạo Workbook Bên Ngoài**

Sử dụng các phương thức **`readWorkbookStream`** và **`setExternalWorkbook`**, bạn có thể tạo một workbook bên ngoài từ đầu hoặc biến một workbook nội bộ thành bên ngoài.

Đoạn mã Java này minh họa quá trình tạo workbook bên ngoài:

```java
Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Đặt Workbook Bên Ngoài**

Bạn có thể gán một workbook bên ngoài cho biểu đồ như là nguồn dữ liệu bằng phương thức **`setExternalWorkbook`**. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới workbook bên ngoài (nếu workbook đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các workbook được lưu trữ ở vị trí hoặc tài nguyên từ xa, bạn vẫn có thể sử dụng các workbook đó như nguồn dữ liệu bên ngoài. Nếu cung cấp đường dẫn tương đối cho một workbook bên ngoài, nó sẽ tự động được chuyển thành đường dẫn đầy đủ.

Đoạn mã Java này cho bạn cách đặt một workbook bên ngoài:

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Tham số `ChartData` (trong phương thức `setExternalWorkbook`) được sử dụng để chỉ định liệu một workbook excel có được tải hay không. 

* Khi giá trị `ChartData` được đặt thành `false`, chỉ đường dẫn workbook được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ workbook đích. Bạn có thể muốn sử dụng cài đặt này khi workbook đích không tồn tại hoặc không khả dụng. 
* Khi giá trị `ChartData` được đặt thành `true`, dữ liệu biểu đồ sẽ được cập nhật từ workbook đích.

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Lấy Đường Dẫn Workbook Nguồn Dữ Liệu Bên Ngoài của Biểu Đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
2. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
3. Tạo một đối tượng cho shape biểu đồ.
4. Tạo một đối tượng cho loại nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.
5. Chỉ định điều kiện liên quan dựa trên việc loại nguồn giống với loại nguồn dữ liệu workbook bên ngoài.

Đoạn mã Java này minh họa thao tác:

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// Lưu bản trình bày
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Chỉnh sửa Dữ liệu Biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong workbook bên ngoài giống như cách bạn thay đổi nội dung của workbook nội bộ. Khi một workbook bên ngoài không thể được tải, một ngoại lệ sẽ được ném.

Đoạn mã Java này là một triển khai của quá trình được mô tả:

```java
// Tạo một thể hiện của lớp Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Tôi có thể xác định xem một biểu đồ cụ thể có liên kết tới workbook bên ngoài hay workbook nhúng không?**

Có. Một biểu đồ có một [loại nguồn dữ liệu](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chartdata/#getDataSourceType--) và một [đường dẫn tới workbook bên ngoài](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); nếu nguồn là một workbook bên ngoài, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp bên ngoài đang được sử dụng.

**Các đường dẫn tương đối tới workbook bên ngoài có được hỗ trợ không, và chúng được lưu trữ như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển thành đường dẫn tuyệt đối. Điều này tiện lợi cho việc di chuyển dự án; tuy nhiên, cần lưu ý rằng bản trình bày sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng workbook nằm trên tài nguyên/mạng chia sẻ không?**

Có, các workbook như vậy có thể được sử dụng làm nguồn dữ liệu bên ngoài. Tuy nhiên, việc chỉnh sửa trực tiếp các workbook từ xa qua Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX bên ngoài khi lưu bản trình bày không?**

Không. Bản trình bày lưu một [liên kết tới tệp bên ngoài](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) và sử dụng nó để đọc dữ liệu. Tệp bên ngoài không bị sửa đổi khi bản trình bày được lưu.

**Nếu tệp bên ngoài được bảo vệ bằng mật khẩu, tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách phổ biến là gỡ bảo vệ trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, bằng cách sử dụng [Aspose.Cells](/cells/java/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một workbook bên ngoài không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ lần tiếp theo dữ liệu được tải.