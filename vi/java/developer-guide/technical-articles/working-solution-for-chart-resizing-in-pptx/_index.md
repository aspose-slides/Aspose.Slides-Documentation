---
title: Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX
type: docs
weight: 40
url: /vi/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- thay đổi kích thước biểu đồ
- biểu đồ Excel
- đối tượng OLE
- nhúng biểu đồ
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Sửa lỗi thay đổi kích thước biểu đồ không mong muốn trong PPTX khi sử dụng các đối tượng OLE Excel được nhúng với Aspose.Slides cho Java. Đặt kích thước biểu đồ cố định để giữ cho kích thước biểu đồ và khung OLE luôn nhất quán."
---
## **Bối cảnh**

Biểu đồ Excel được nhúng dưới dạng đối tượng OLE trong các bản thuyết trình PowerPoint bằng các thành phần Aspose có thể thay đổi kích thước sau lần kích hoạt đầu tiên. Điều này có thể gây ra sự khác biệt đáng chú ý trong giao diện của biểu đồ trước và sau khi kích hoạt. Bài viết này giải thích tại sao lại xảy ra việc thay đổi kích thước và chỉ ra cách ngăn ngừa bằng cách khớp kích thước biểu đồ cố định với khung OLE.

Trong [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình bày](/slides/vi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), chúng tôi đã giải thích cách tạo biểu đồ Excel bằng Aspose.Cells cho Java và nhúng nó vào bản trình bày PowerPoint bằng Aspose.Slides cho Java. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/java/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán hình ảnh biểu đồ cho khung đối tượng OLE của biểu đồ. Trong bản trình bày đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh biểu đồ, biểu đồ Excel sẽ được kích hoạt. Người dùng có thể chỉnh sửa workbook Excel nhúng và sau đó quay lại slide bằng cách nhấp ra ngoài workbook đã kích hoạt. Kích thước của khung đối tượng OLE thay đổi khi người dùng quay lại slide, và hệ số thay đổi kích thước khác nhau tùy thuộc vào kích thước gốc của cả khung OLE và workbook Excel nhúng.

## **Nguyên nhân của việc thay đổi kích thước**

Workbook Excel được nhúng có kích thước cửa sổ riêng, mà Excel cố gắng giữ lại khi đối tượng được kích hoạt lần đầu. Khung OLE trên slide có kích thước được định nghĩa độc lập. Khi workbook Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước của đối tượng để duy trì tỷ lệ của nó như một phần của quá trình nhúng. Sự khác biệt giữa cửa sổ workbook và khung OLE do đó có thể gây ra việc thay đổi kích thước của đối tượng.

## **Giải pháp hoạt động**

Khớp kích thước biểu đồ với khung OLE trên slide và giữ cho kích thước biểu đồ độc lập với cửa sổ workbook. Giải pháp này hoạt động với bản trình bày mới hoặc mẫu hiện có.

Ví dụ yêu cầu Aspose.Cells cho Java và Aspose.Slides cho Java. Nó tạo một biểu đồ cột đơn giản trên một sheet biểu đồ đang hoạt động và nhúng workbook ở định dạng XLS. Không có hình ảnh xem trước biểu đồ được gán; biểu đồ sẽ hiển thị khi đối tượng OLE được kích hoạt trong PowerPoint.

Ví dụ tạo một bản trình bày mới với khung OLE kích thước 9.5 × 4-inch được đặt cách mép trái 0.5 inch và cách mép trên 1 inch. Các tọa độ và kích thước slide được tính bằng điểm (72 điểm mỗi inch). Đối với bản trình bày hiện có, xem [Sử dụng mẫu](#use-a-template).

## **Đặt kích thước biểu đồ cố định**

Đặt [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) thành false để kích thước biểu đồ không phụ thuộc vào cửa sổ workbook. Đặt kích thước của [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) thông qua [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) và [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), chuyển đổi điểm sang pixel bằng 96 pixel mỗi inch: khung có kích thước 684 × 288 điểm tương ứng với biểu đồ có kích thước 912 × 384 pixel. Đặt [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) thành giá trị CUSTOM của [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). Ví dụ nhúng workbook bằng [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) và lưu bản trình bày với khung OLE kích thước 9.5 × 4-inch.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Workbook workbook = new Workbook();
try {
    Worksheet dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Tọa độ và kích thước slide được tính bằng điểm (72 điểm mỗi inch).
        float width = 684f; // 9,5 inch.
        float height = 288f; // 4 inch.

        chart.setSizeWithWindow(false);
        // Chuyển đổi điểm sang pixel cho biểu đồ bằng 96 pixel mỗi inch.
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **Sử dụng mẫu**

Luật tính kích thước giống nhau đối với bản trình bày hiện có. Để áp dụng ví dụ:

1. Tải bản trình bày mẫu thay vì tạo một bản trình bày trống.
1. Kiểm tra rằng slide đầu tiên chứa ít nhất ba hình dạng, sau đó sử dụng hình dạng ở chỉ mục 2 làm chỗ giữ chỗ.
1. Lấy chiều rộng và chiều cao của khung từ hình dạng đó thay vì sử dụng các giá trị cố định 684 và 288. Giữ nguyên các phép tính kích thước.
1. Thêm khung OLE tại vị trí của chỗ giữ chỗ thay vì các tọa độ cố định 36 và 72.
1. Xóa chỗ giữ chỗ trước khi lưu bản trình bày.

## **Câu hỏi thường gặp**

**Tại sao biểu đồ Excel được nhúng của tôi lại thay đổi kích thước sau khi kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng khôi phục kích thước cửa sổ gốc khi lần đầu tiên được kích hoạt, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel sẽ thương lượng kích thước để duy trì tỷ lệ khung hình, điều này có thể gây ra việc thay đổi kích thước.

**Làm thế nào để tôi giữ kích thước biểu đồ và khung OLE nhất quán?**

Đặt kích thước biểu đồ cố định phù hợp với khung OLE và sử dụng kích thước in biểu đồ tùy chỉnh trước khi nhúng workbook. Ví dụ trên cho thấy các cài đặt cần thiết và cách chuyển đổi đơn vị.

**Việc khớp kích thước cửa sổ workbook có đủ không?**

Chỉ khớp kích thước cửa sổ workbook không đảm bảo ngăn khung OLE thay đổi kích thước sau khi kích hoạt. Hãy sử dụng kích thước biểu đồ cố định như trong ví dụ.

**Giải pháp này có hoạt động với cả bản trình bày dựa trên mẫu và bản trình bày mới không?**

Có. Đối với mẫu, sử dụng kích thước và vị trí của chỗ giữ chỗ. Đối với bản trình bày mới, chỉ định trực tiếp kích thước và vị trí của khung.

**Tôi có thể sử dụng ví dụ này với các biểu đồ được tạo bằng các chương trình bảng tính khác không?**

Ví dụ sử dụng một workbook Excel được tạo bằng Aspose.Cells. Nó không minh họa hành vi kích hoạt cho các chương trình bảng tính khác.

## **Các phần liên quan**

- [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình bày](/slides/vi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)