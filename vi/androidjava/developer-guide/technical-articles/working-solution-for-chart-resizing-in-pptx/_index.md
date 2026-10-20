---
title: Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX
type: docs
weight: 40
url: /vi/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- thay đổi kích thước biểu đồ
- biểu đồ Excel
- đối tượng OLE
- nhúng biểu đồ
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Khắc phục việc biểu đồ thay đổi kích thước không mong muốn trong PPTX khi sử dụng các đối tượng OLE Excel được nhúng với Aspose.Slides cho Android qua Java. Đặt kích thước biểu đồ cố định để giữ cho kích thước biểu đồ và khung OLE luôn đồng nhất."
---
## **Tổng quan**

Biểu đồ Excel được nhúng dưới dạng đối tượng OLE trong bản trình bày PowerPoint bằng các thành phần Aspose có thể thay đổi kích thước sau lần kích hoạt đầu tiên. Điều này có thể gây ra sự khác biệt đáng chú ý về giao diện của biểu đồ trước và sau khi kích hoạt. Bài viết này giải thích nguyên nhân gây ra việc thay đổi kích thước và chỉ ra cách ngăn ngừa bằng cách khớp kích thước biểu đồ cố định với khung OLE.

Trong [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình bày](/slides/vi/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), chúng tôi đã giải thích cách tạo một biểu đồ Excel bằng Aspose.Cells for Android qua Java và nhúng nó vào bản trình bày PowerPoint bằng Aspose.Slides for Android qua Java. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/androidjava/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán hình ảnh biểu đồ cho khung đối tượng OLE của biểu đồ. Trong bản trình bày đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh biểu đồ, biểu đồ Excel sẽ được kích hoạt. Người dùng có thể chỉnh sửa sổ làm việc Excel được nhúng và sau đó quay lại slide bằng cách nhấp ra ngoài sổ làm việc đã kích hoạt. Kích thước của khung đối tượng OLE sẽ thay đổi khi người dùng quay lại slide, và hệ số thay đổi kích thước phụ thuộc vào kích thước gốc của cả khung OLE và sổ làm việc Excel được nhúng.

## **Nguyên nhân gây thay đổi kích thước**

Sổ làm việc Excel được nhúng có kích thước cửa sổ riêng, mà Excel cố gắng giữ lại khi đối tượng được kích hoạt lần đầu. Khung OLE trên slide có kích thước được xác định độc lập. Khi sổ làm việc Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước của đối tượng để duy trì tỷ lệ trong quá trình nhúng. Sự khác biệt giữa cửa sổ sổ làm việc và khung OLE do đó có thể gây ra việc thay đổi kích thước của đối tượng.

## **Giải pháp**

Khớp kích thước biểu đồ với khung OLE trên slide và giữ cho kích thước biểu đồ độc lập với cửa sổ sổ làm việc. Giải pháp này hoạt động với bản trình bày mới hoặc với mẫu hiện có.

Ví dụ yêu cầu Aspose.Cells for Android qua Java và Aspose.Slides for Android qua Java. Nó tạo một biểu đồ cột đơn giản trên một trang biểu đồ đang hoạt động và nhúng sổ làm việc ở định dạng XLS. Gọi `FixedChartSize.createPresentation(getFilesDir())` từ một activity Android để lưu đầu ra vào thư mục tệp nội bộ của ứng dụng. Việc kích hoạt OLE yêu cầu PowerPoint trên máy tính để bàn và cài đặt Excel tương thích. Không gán hình ảnh xem trước cho biểu đồ; biểu đồ sẽ hiển thị khi đối tượng OLE được kích hoạt trong PowerPoint.

Ví dụ tạo một bản trình bày mới với khung OLE có kích thước 9.5 × 4 inch, đặt cách mép trái 0.5 inch và cách mép trên 1 inch. Tọa độ và kích thước slide được tính bằng điểm (72 điểm = 1 inch). Đối với bản trình bày hiện có, xem [Sử dụng mẫu](#use-a-template).

## **Đặt kích thước biểu đồ cố định**

Đặt [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) thành false để kích thước biểu đồ không phụ thuộc vào cửa sổ sổ làm việc. Đặt kích thước của [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) thông qua [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) và [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), chuyển đổi điểm sang pixel bằng 96 pixel mỗi inch: khung có kích thước 684 × 288 điểm tương đương với biểu đồ có kích thước 912 × 384 pixel. Đặt [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) thành giá trị CUSTOM của [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). Ví dụ nhúng sổ làm việc bằng [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) và lưu bản trình bày với khung OLE 9.5 × 4 inch.

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
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
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
                    // Chuyển đổi điểm sang pixel biểu đồ bằng 96 pixel mỗi inch.
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```

## **Sử dụng mẫu**

Logic tính kích thước giống nhau với bản trình bày hiện có. Để điều chỉnh ví dụ:

1. Tải mẫu bản trình bày thay vì tạo một bản trình bày trống.
1. Kiểm tra slide đầu tiên có ít nhất ba shape, sau đó sử dụng shape ở chỉ mục 2 làm vị trí giữ chỗ.
1. Lấy chiều rộng và chiều cao của khung từ shape đó thay vì dùng các giá trị cố định 684 và 288. Giữ nguyên các công thức tính kích thước.
1. Thêm khung OLE tại vị trí của vị trí giữ chỗ thay vì các tọa độ cố định 36 và 72.
1. Xóa vị trí giữ chỗ trước khi lưu bản trình bày.

## **FAQ**

**Tại sao biểu đồ Excel được nhúng của tôi thay đổi kích thước sau khi kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng khôi phục kích thước cửa sổ gốc khi lần đầu tiên được kích hoạt, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel sẽ thương lượng kích thước để duy trì tỉ lệ, dẫn đến việc thay đổi kích thước.

**Làm sao để giữ kích thước biểu đồ và khung OLE đồng nhất?**

Đặt kích thước biểu đồ cố định khớp với khung OLE và sử dụng kích thước in biểu đồ tùy chỉnh trước khi nhúng sổ làm việc. Ví dụ ở trên cho thấy các cài đặt cần thiết và cách chuyển đổi đơn vị.

**Chỉ khớp kích thước cửa sổ sổ làm việc có đủ không?**

Chỉ khớp kích thước cửa sổ sổ làm việc không đảm bảo ngăn khung OLE thay đổi kích thước sau khi kích hoạt. Cần sử dụng kích thước biểu đồ cố định như trong ví dụ.

**Giải pháp này có hoạt động với cả bản trình bày dựa trên mẫu và bản trình bày mới không?**

Có. Đối với mẫu, sử dụng kích thước và vị trí của vị trí giữ chỗ. Đối với bản trình bày mới, chỉ định trực tiếp kích thước và vị trí khung.

**Tôi có thể sử dụng ví dụ này với các biểu đồ được tạo bằng các chương trình bảng tính khác không?**

Ví dụ sử dụng sổ làm việc Excel được tạo bằng Aspose.Cells. Nó không minh họa hành vi kích hoạt cho các chương trình bảng tính khác.

## **Related Sections**

- [Tạo biểu đồ Excel và nhúng chúng dưới dạng đối tượng OLE trong bản trình bày](/slides/vi/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)