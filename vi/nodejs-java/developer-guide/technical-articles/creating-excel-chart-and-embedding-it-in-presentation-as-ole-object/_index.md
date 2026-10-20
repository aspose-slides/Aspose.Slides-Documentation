---
title: Tạo biểu đồ Excel và nhúng chúng vào bản trình chiếu dưới dạng đối tượng OLE
type: docs
weight: 30
url: /vi/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Biểu đồ Excel
- Nhúng biểu đồ
- Đối tượng OLE
- PowerPoint
- Bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo một biểu đồ Excel bằng Aspose.Cells cho Node.js thông qua Java và nhúng workbook vào bản trình chiếu PowerPoint với Aspose.Slides, bao gồm preview biểu đồ."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo biểu đồ cột Excel với Aspose.Cells cho Node.js thông qua Java và nhúng workbook của nó vào một bản trình chiếu PowerPoint với Aspose.Slides cho Node.js thông qua Java. Workbook được nhúng chứa cả dữ liệu nguồn và biểu đồ. Một ảnh PNG preview riêng biệt hiển thị biểu đồ trên slide trước khi đối tượng OLE được kích hoạt.

Kết quả là một đối tượng Excel được nhúng, không phải là một biểu đồ PowerPoint gốc. Việc chỉnh sửa workbook qua OLE yêu cầu một ứng dụng desktop hỗ trợ kích hoạt OLE và cài đặt Excel tương thích.

## **Yêu cầu**

Cài đặt các gói Node.js `aspose.cells`, `aspose.slides.via.java` và `java`. Chạy các ví dụ dưới dạng hai script CommonJS trong các tiến trình Node.js riêng biệt: đầu tiên `create-chart.js`, sau đó `embed-chart.js`, sử dụng cùng một thư mục làm việc. Cả hai gói Aspose đều khởi tạo cầu Java khi tải, vì vậy các ví dụ này giữ chúng trong các tiến trình riêng. Microsoft Office không bắt buộc để tạo bản trình chiếu với các thư viện này.

Không cần workbook hay hình ảnh nào có sẵn. Script đầu tiên tạo `ChartWorkbook.xlsx` và `ChartPreview.png`; script thứ hai đọc các tệp này và ghi `OutputChart.pptx` vào thư mục làm việc hiện tại. Áp dụng giấy phép cho cả hai sản phẩm khi chạy ngoài chế độ đánh giá.

## **Cách hoạt động của việc nhúng**

1. Tạo một workbook với một worksheet dữ liệu và một chart sheet.  
2. Đặt chart sheet làm sheet hoạt động để workbook mở ở chart.  
3. Đặt phạm vi hiển thị OLE của workbook và render chart sang PNG.  
4. Lưu workbook dưới dạng XLSX và nhúng các byte của nó vào một slide trong một tiến trình Node.js riêng.  
5. Gán PNG làm preview cho đối tượng OLE và lưu bản trình chiếu dưới dạng PPTX.  

Workbook display range và khung trên slide có vai trò khác nhau. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) lấy các chỉ số dòng và cột bắt đầu/kết thúc dựa trên chỉ số không. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) thay vào đó lấy dòng trên, cột trái, dòng dưới và cột phải. Ví dụ sử dụng chỉ số dòng 55 và chỉ số cột 25 làm giới hạn dưới‑phải; các giá trị này là lựa chọn bố cục, không phải số lượng dòng hay cột dữ liệu.

Khung slide sử dụng đơn vị điểm. Ví dụ này điều chỉnh nó để vừa trong slide và căn giữa trong khi giữ tỷ lệ khung hình của PNG, thay vì kéo dài preview để lấp đầy slide.

## **Tạo và Nhúng Biểu đồ**

Lưu ví dụ đầu tiên dưới tên `create-chart.js`. Nó điền `DataSheet` với bốn dòng và năm cột giá trị. Mỗi dòng trở thành một series cho biểu đồ. `ChartSheet` được chọn làm sheet hoạt động trước khi workbook được lưu.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // Tạo preview biểu đồ và tuần tự hoá workbook có thể chỉnh sửa riêng biệt.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// Mọi công việc đồng bộ đã hoàn thành; dừng tiến trình cầu Java.
process.exit(0);
```

Lưu ví dụ sau dưới tên `embed-chart.js`. Chạy nó sau khi `create-chart.js` đã tạo cả hai tệp đầu vào. Nó căn giữa khung OLE và giữ tỷ lệ khung hình của ảnh preview.

Script thứ hai nhúng workbook đã lưu và sử dụng PNG làm preview. Workbook được lưu rõ ràng dưới dạng XLSX, khớp với phần mở rộng `xlsx` được truyền cho [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/). PNG được tải trực tiếp từ các byte mà không qua chuyển đổi bitmap trung gian. Cầu Java yêu cầu mảng byte Java rõ ràng cho hình ảnh và dữ liệu workbook, và giá trị float Java cho tọa độ khung slide. Gán nó thông qua [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) thay thế placeholder OLE mặc định.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // Đặt preview vào trong slide mà không thay đổi tỷ lệ khung hình.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// Tất cả công việc đồng bộ đã hoàn thành; dừng tiến trình cầu Java.
process.exit(0);
```

## **Kết quả mong đợi**

`OutputChart.pptx` chứa một slide với một workbook Excel được nhúng và một preview biểu đồ. Workbook chứa dữ liệu gốc và một biểu đồ cột với bốn series. Preview được căn giữa trên slide và giữ nguyên tỷ lệ.

![Biểu đồ cột Excel hiển thị như preview của workbook được nhúng](excel-chart-ole-preview.png)

Trong môi trường PowerPoint desktop tương thích có sẵn Excel, nhấp đúp vào đối tượng để kích hoạt và chỉnh sửa workbook được nhúng. Việc kích hoạt và chỉnh sửa phụ thuộc vào hỗ trợ OLE và cài đặt bảo mật của ứng dụng host.

## **Câu hỏi thường gặp**

**Tại sao cần ảnh preview?**

Workbook được nhúng và preview trên slide là hai nội dung riêng biệt. Cung cấp ảnh biểu đồ để slide hiển thị biểu đồ thay vì placeholder mặc định “EMBEDDED OLE OBJECT”. Xem [Vấn đề preview đối tượng khi thêm OleObjectFrame](/slides/vi/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**Ảnh preview có tự động cập nhật khi tôi thay đổi workbook trong mã không?**

Xem preview như một ảnh chụp. Khi cập nhật dữ liệu workbook bằng mã, cần tạo lại ảnh biểu đồ và thay thế preview cũng như dữ liệu workbook được nhúng.

**Tôi có thể dùng XLS thay vì XLSX không?**

Có. Lưu workbook ở định dạng XLS và sử dụng `xls` làm phần mở rộng dữ liệu nhúng. Phần mở rộng phải khớp với định dạng workbook thực tế; chỉ thay đổi phần mở rộng mà không chuyển đổi dữ liệu sẽ không hiệu quả.

**Tại sao đối tượng có thể thay đổi kích thước sau khi kích hoạt?**

Ứng dụng host có thể cập nhật cách trình bày của đối tượng OLE khi nó kích hoạt workbook. Cả phạm vi hiển thị OLE của workbook và kích thước khung slide đều quan trọng. Xem [Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX](/slides/vi/java/working-solution-for-chart-resizing-in-pptx/).

## **Các phần liên quan**

- [Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX](/slides/vi/java/working-solution-for-chart-resizing-in-pptx/)
- [Vấn đề preview đối tượng khi thêm OleObjectFrame](/slides/vi/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)