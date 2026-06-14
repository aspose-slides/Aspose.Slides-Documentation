---
title: Quản lý Sổ làm việc Biểu đồ trong Bản trình chiếu trên Android
linktitle: Sổ làm việc Biểu đồ
type: docs
weight: 70
url: /vi/androidjava/chart-workbook/
keywords:
- sổ làm việc biểu đồ
- dữ liệu biểu đồ
- ô sổ làm việc
- nhãn dữ liệu
- bảng tính
- nguồn dữ liệu
- sổ làm việc ngoại
- dữ liệu ngoại
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Android qua Java: dễ dàng quản lý sổ làm việc biểu đồ trong các định dạng PowerPoint và OpenDocument để tối ưu hoá dữ liệu bản trình chiếu của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với sổ làm việc biểu đồ trong Aspose.Slides. Nó cho thấy cách đọc và ghi dữ liệu biểu đồ thông qua các luồng sổ làm việc, sử dụng các ô sổ làm việc làm nhãn dữ liệu biểu đồ, truy cập bộ sưu tập worksheet và chỉ định kiểu nguồn dữ liệu cho các giá trị biểu đồ.

Nó cũng đề cập đến việc làm việc với sổ làm việc ngoại như là nguồn dữ liệu cho biểu đồ. Các ví dụ minh họa cách tạo và gán một sổ làm việc ngoại, lấy đường dẫn của sổ làm việc ngoại được liên kết với biểu đồ, và chỉnh sửa dữ liệu biểu đồ khi sổ làm việc có sẵn.

## **Đọc và Ghi Dữ liệu Biểu đồ từ Sổ làm việc**
Aspose.Slides cung cấp các phương thức [ReadWorkbookStream](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) và [WriteWorkbookStream](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) cho phép bạn đọc và ghi các sổ làm việc dữ liệu biểu đồ (chứa dữ liệu biểu đồ được chỉnh sửa bằng Aspose.Cells). **Lưu ý** rằng dữ liệu biểu đồ phải được tổ chức theo cùng cách hoặc phải có cấu trúc tương tự như nguồn.

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

## **Đặt Ô WorkBook làm Nhãn Dữ liệu Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
1. Thêm một biểu đồ Bubble với một số dữ liệu.
1. Truy cập series của biểu đồ.
1. Đặt ô sổ làm việc làm nhãn dữ liệu.
1. Lưu bản trình chiếu.

Đoạn mã Java này cho bạn cách đặt ô sổ làm việc làm nhãn dữ liệu biểu đồ:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Tạo một đối tượng lớp Presentation đại diện cho một tệp bản trình chiếu
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

## **Quản lý Worksheet**

Đoạn mã Java này minh họa một thao tác trong đó phương thức [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) được sử dụng để truy cập bộ sưu tập worksheet:

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

## **Xác định Kiểu Nguồn Dữ liệu**

Đoạn mã Java này cho bạn cách chỉ định một kiểu cho nguồn dữ liệu:

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

## **Phát hiện Định dạng Sổ làm việc Nhúng Không được Hỗ trợ**

Aspose.Slides không hỗ trợ định dạng sổ làm việc nhị phân Excel (.xlsb) có thể được nhúng trong một số biểu đồ. Bạn có thể sử dụng phương thức `getEmbeddedWorkbookType` trên [IChartData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IChartData) cùng với enumeration [WorkbookType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/WorkbookType) để phát hiện các định dạng không được hỗ trợ và bỏ qua các biểu đồ đó.

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
            // Sổ làm việc nhúng ở định dạng .xlsb, không được hỗ trợ.
            continue;
        }

        // Đọc hoặc chỉnh sửa dữ liệu sổ làm việc biểu đồ tại đây.
    }
} finally {
    presentation.dispose();
}
```

## **Sổ làm việc Ngoại**

Aspose.Slides hỗ trợ sổ làm việc ngoại làm nguồn dữ liệu cho biểu đồ.

### **Tạo Sổ làm việc Ngoại**

Sử dụng các phương thức **`readWorkbookStream`** và **`setExternalWorkbook`**, bạn có thể tạo một sổ làm việc ngoại từ đầu hoặc biến một sổ làm việc nội bộ thành ngoại.

Đoạn mã Java này minh họa quy trình tạo sổ làm việc ngoại:

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

### **Đặt Sổ làm việc Ngoại**

Sử dụng phương thức **`setExternalWorkbook`**, bạn có thể gán một sổ làm việc ngoại cho biểu đồ như là nguồn dữ liệu của nó. Phương thức này cũng có thể được dùng để cập nhật đường dẫn tới sổ làm việc ngoại (nếu sổ làm việc đó đã được di chuyển).

Mặc dù bạn không thể chỉnh sửa dữ liệu trong các sổ làm việc được lưu ở vị trí từ xa hoặc trong tài nguyên, bạn vẫn có thể sử dụng những sổ làm việc đó làm nguồn dữ liệu ngoại. Nếu đường dẫn tương đối cho một sổ làm việc ngoại được cung cấp, nó sẽ tự động được chuyển đổi thành đường dẫn đầy đủ.

Đoạn mã Java này cho bạn cách đặt một sổ làm việc ngoại:

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

Tham số `ChartData` (trong phương thức `setExternalWorkbook`) được dùng để chỉ định liệu một sổ làm việc Excel có được tải hay không.

* Khi giá trị `ChartData` được đặt thành `false`, chỉ đường dẫn sổ làm việc được cập nhật — dữ liệu biểu đồ sẽ không được tải hoặc cập nhật từ sổ làm việc đích. Bạn có thể muốn dùng cài đặt này khi sổ làm việc đích không tồn tại hoặc không khả dụng. 
* Khi giá trị `ChartData` được đặt thành `true` , dữ liệu biểu đồ được cập nhật từ sổ làm việc đích.

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

### **Lấy Đường dẫn Sổ làm việc Nguồn Dữ liệu Ngoại của Biểu đồ**

1. Tạo một thể hiện của lớp [Presentation](https://apireference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Lấy tham chiếu của một slide thông qua chỉ mục của nó.
1. Tạo một đối tượng cho shape biểu đồ.
1. Tạo một đối tượng cho kiểu nguồn (`ChartDataSourceType`) đại diện cho nguồn dữ liệu của biểu đồ.
1. Chỉ định điều kiện liên quan dựa trên việc kiểu nguồn giống với kiểu nguồn dữ liệu sổ làm việc ngoại.

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
	
	// Lưu bản trình chiếu
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Chỉnh sửa Dữ liệu Biểu đồ**

Bạn có thể chỉnh sửa dữ liệu trong sổ làm việc ngoại giống như cách bạn thay đổi nội dung của sổ làm việc nội bộ. Khi một sổ làm việc ngoại không thể tải, một ngoại lệ sẽ được ném ra.

Đoạn mã Java này là triển khai của quá trình đã mô tả:

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

## **CÂU HỎI THƯỜNG GẶP**

**Tôi có thể xác định liệu một biểu đồ cụ thể có được liên kết với sổ làm việc ngoại hay nhúng không?**

Có. Một biểu đồ có một [data source type](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) và một [path to an external workbook](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); nếu nguồn là một sổ làm việc ngoại, bạn có thể đọc đường dẫn đầy đủ để chắc chắn rằng một tệp ngoại đang được sử dụng.

**Có hỗ trợ các đường dẫn tương đối đến sổ làm việc ngoại không, và chúng được lưu như thế nào?**

Có. Nếu bạn chỉ định một đường dẫn tương đối, nó sẽ tự động được chuyển đổi thành đường dẫn tuyệt đối. Điều này tiện lợi cho việc di động dự án; tuy nhiên, hãy lưu ý rằng bản trình chiếu sẽ lưu đường dẫn tuyệt đối trong tệp PPTX.

**Tôi có thể sử dụng sổ làm việc nằm trên các tài nguyên/chia sẻ mạng không?**

Có, các sổ làm việc như vậy có thể được sử dụng làm nguồn dữ liệu ngoại. Tuy nhiên, việc chỉnh sửa các sổ làm việc từ xa trực tiếp từ Aspose.Slides không được hỗ trợ — chúng chỉ có thể được dùng làm nguồn.

**Aspose.Slides có ghi đè lên file XLSX ngoại khi lưu bản trình chiếu không?**

Không. Bản trình chiếu lưu một [link to the external file](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) và sử dụng nó để đọc dữ liệu. File ngoại bản thân không bị thay đổi khi bản trình chiếu được lưu.

**Nếu file ngoại được bảo mật bằng mật khẩu thì tôi nên làm gì?**

Aspose.Slides không chấp nhận mật khẩu khi liên kết. Một cách thường gặp là gỡ bỏ bảo mật trước hoặc chuẩn bị một bản sao đã giải mã (ví dụ, sử dụng [Aspose.Cells](/cells/androidjava/)) và liên kết tới bản sao đó.

**Nhiều biểu đồ có thể tham chiếu cùng một sổ làm việc ngoại không?**

Có. Mỗi biểu đồ lưu liên kết riêng của mình. Nếu chúng đều trỏ tới cùng một tệp, việc cập nhật tệp đó sẽ được phản ánh trong mỗi biểu đồ vào lần tiếp theo dữ liệu được tải.