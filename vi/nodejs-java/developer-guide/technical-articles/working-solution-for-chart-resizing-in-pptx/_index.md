---
title: Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX
type: docs
weight: 40
url: /vi/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- thay đổi kích thước biểu đồ
- biểu đồ Excel
- đối tượng OLE
- nhúng biểu đồ
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Sửa lỗi thay đổi kích thước biểu đồ không mong muốn trong PPTX khi sử dụng các đối tượng OLE Excel được nhúng với Aspose.Slides cho Node.js qua Java. Đặt kích thước biểu đồ cố định để giữ cho kích thước biểu đồ và khung OLE nhất quán."
---
## **Tổng quan**

Biểu đồ Excel được nhúng dưới dạng đối tượng OLE trong các bản trình bày PowerPoint bằng các thành phần Aspose có thể thay đổi kích thước sau lần kích hoạt đầu tiên. Điều này có thể gây ra sự khác biệt đáng chú ý về ngoại hình của biểu đồ trước và sau khi kích hoạt. Bài viết này giải thích nguyên nhân gây ra việc thay đổi kích thước và chỉ ra cách ngăn chặn bằng cách khớp các kích thước biểu đồ cố định với khung OLE.

Trong [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình bày](/slides/vi/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), chúng tôi đã giải thích cách tạo biểu đồ Excel bằng Aspose.Cells for Node.js via Java và nhúng nó vào bản trình bày PowerPoint bằng Aspose.Slides for Node.js via Java. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán ảnh biểu đồ cho khung đối tượng OLE của biểu đồ. Trong bản trình bày đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị ảnh biểu đồ, biểu đồ Excel được kích hoạt. Người dùng có thể chỉnh sửa workbook Excel được nhúng và sau đó quay lại slide bằng cách nhấp ra ngoài workbook đã kích hoạt. Kích thước của khung đối tượng OLE thay đổi khi người dùng quay lại slide, và hệ số thay đổi kích thước phụ thuộc vào kích thước ban đầu của cả khung OLE và workbook Excel được nhúng.

## **Nguyên nhân gây thay đổi kích thước**

Workbook Excel được nhúng có kích thước cửa sổ riêng, mà Excel cố gắng duy trì khi đối tượng được kích hoạt lần đầu. Khung OLE trên slide có kích thước được xác định độc lập. Khi workbook Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước của đối tượng để duy trì tỉ lệ trong quá trình nhúng. Sự khác nhau giữa cửa sổ workbook và khung OLE do đó có thể gây ra việc thay đổi kích thước.

## **Giải pháp hoạt động**

Khớp kích thước biểu đồ với khung OLE trên slide và giữ cho kích thước biểu đồ không phụ thuộc vào cửa sổ workbook. Giải pháp này hoạt động với một bản trình bày mới hoặc một mẫu hiện có.

Ví dụ yêu cầu Aspose.Cells for Node.js via Java và Aspose.Slides for Node.js via Java. Cài đặt các gói Node.js `aspose.cells`, `aspose.slides.via.java` và `java`. Chạy hai script CommonJS dưới đây trong các tiến trình Node.js riêng biệt, sử dụng cùng một thư mục làm việc, vì cả hai gói Aspose đều khởi tạo cầu nối Java khi tải. Nó tạo một biểu đồ cột đơn giản trên một sheet biểu đồ đang hoạt động và nhúng workbook dưới định dạng XLS. Không có hình ảnh xem trước biểu đồ nào được gán; biểu đồ sẽ hiển thị khi đối tượng OLE được kích hoạt trong PowerPoint.

Ví dụ tạo một bản trình bày mới với khung OLE kích thước 9,5 × 4 inch được đặt cách mép trái 0,5 inch và cách mép trên 1 inch. Các tọa độ và kích thước của slide được tính bằng điểm (72 điểm mỗi inch). Đối với bản trình bày hiện có, xem [Sử dụng mẫu](#use-a-template).

## **Đặt kích thước biểu đồ cố định**

Đặt [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) thành false để kích thước biểu đồ không phụ thuộc vào cửa sổ workbook. Đặt kích thước của [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) thông qua [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) và [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight), chuyển đổi điểm sang pixel bằng 96 pixel mỗi inch: khung 684 × 288 điểm tương đương biểu đồ 912 × 384 pixel. Đặt [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) thành giá trị CUSTOM của `PrintSizeType`. Ví dụ nhúng workbook bằng [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) và lưu bản trình bày với khung OLE 9,5 × 4 inch.

Lưu script đầu tiên này dưới tên `create-fixed-chart.js`. Nó tạo file `chart-fixed-size.xls` với biểu đồ có kích thước 912 × 384 pixel, khớp với khung 684 × 288 điểm được sử dụng bởi script thứ hai. Không cần workbook đầu vào.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // Khớp kích thước khung OLE tính bằng điểm (72 điểm mỗi inch).
    const width = 684; // 9,5 inch.
    const height = 288; // 4 inch.

    chart.setSizeWithWindow(false);
    // Chuyển đổi điểm sang pixel biểu đồ bằng 96 pixel mỗi inch.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// Tất cả công việc đồng bộ đã hoàn thành; dừng tiến trình cầu nối Java.
process.exit(0);
```

Lưu script thứ hai dưới tên `embed-fixed-chart.js` và chạy nó sau `create-fixed-chart.js`. Nó đọc workbook XLS đã tạo và lưu file `chart-fixed-size.pptx`. Cầu nối Java yêu cầu một mảng byte Java rõ ràng cho dữ liệu workbook và các giá trị float Java cho tọa độ và kích thước khung. Phần mở rộng `xls` khớp với định dạng lưu của workbook.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // Các tọa độ và kích thước slide tính bằng điểm (72 điểm mỗi inch).
    const width = 684; // 9,5 inch.
    const height = 288; // 4 inch.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Tất cả công việc đồng bộ đã hoàn thành; dừng tiến trình cầu nối Java.
process.exit(0);
```

## **Sử dụng mẫu**

Logic tính kích thước tương tự cho một bản trình bày hiện có. Để điều chỉnh ví dụ:

1. Tải bản trình bày mẫu thay vì tạo một bản trình bày trống.  
1. Kiểm tra slide đầu tiên có ít nhất ba hình dạng, sau đó sử dụng hình dạng ở chỉ số 2 làm chỗ giữ chỗ.  
1. Lấy chiều rộng và chiều cao khung từ hình dạng đó thay vì sử dụng các giá trị cố định 684 và 288. Sử dụng cùng kích thước trong script tạo workbook, giữ nguyên các phép tính kích thước, và tạo lại workbook XLS trước khi nhúng.  
1. Thêm khung OLE tại vị trí của chỗ giữ chỗ thay vì các tọa độ cố định 36 và 72.  
1. Xóa chỗ giữ chỗ trước khi lưu bản trình bày.

## **Câu hỏi thường gặp**

**Tại sao biểu đồ Excel được nhúng của tôi thay đổi kích thước sau khi kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng khôi phục kích thước cửa sổ gốc khi lần đầu tiên được kích hoạt, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel thương lượng kích thước để duy trì tỷ lệ, dẫn đến việc thay đổi kích thước.

**Làm sao tôi có thể giữ cho kích thước biểu đồ và khung OLE nhất quán?**

Đặt kích thước biểu đồ cố định phù hợp với khung OLE và sử dụng kích thước in biểu đồ tùy chỉnh trước khi nhúng workbook. Ví dụ ở trên cho thấy các cài đặt cần thiết và cách chuyển đổi đơn vị.

**Việc khớp kích thước cửa sổ workbook có đủ không?**

Chỉ khớp kích thước cửa sổ workbook không đảm bảo ngăn khung OLE thay đổi kích thước sau khi kích hoạt. Hãy sử dụng kích thước biểu đồ cố định như trong ví dụ.

**Giải pháp này có hoạt động với cả bản trình bày dựa trên mẫu và bản trình bày mới không?**

Có. Đối với mẫu, sử dụng kích thước và vị trí của chỗ giữ chỗ. Đối với bản trình bày mới, chỉ định trực tiếp kích thước và vị trí khung.

**Tôi có thể sử dụng ví dụ này với biểu đồ được tạo trong các chương trình bảng tính khác không?**

Ví dụ sử dụng workbook Excel được tạo bằng Aspose.Cells. Nó không minh họa hành vi kích hoạt cho các chương trình bảng tính khác.

## **Các mục liên quan**

- [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình bày](/slides/vi/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)