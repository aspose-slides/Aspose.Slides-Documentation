---
title: Tạo biểu đồ Excel và nhúng chúng vào bản trình bày dưới dạng đối tượng OLE
type: docs
weight: 30
url: /vi/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Biểu đồ Excel
- Nhúng biểu đồ
- Đối tượng OLE
- PowerPoint
- Bản trình bày
- Android
- Java
- Aspose.Slides
description: "Tạo một biểu đồ Excel bằng Aspose.Cells cho Android qua Java và nhúng sổ làm việc vào bản trình bày PowerPoint bằng Aspose.Slides cho Android qua Java, bao gồm một ảnh xem trước biểu đồ."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo biểu đồ cột Excel bằng Aspose.Cells for Android qua Java và nhúng sổ làm việc của nó vào một bản trình bày PowerPoint bằng Aspose.Slides for Android qua Java. Sổ làm việc được nhúng chứa cả dữ liệu nguồn và biểu đồ. Một ảnh xem trước PNG riêng biệt hiển thị biểu đồ trên slide trước khi đối tượng OLE được kích hoạt.

Kết quả là một đối tượng Excel được nhúng, không phải là biểu đồ PowerPoint gốc. Việc chỉnh sửa sổ làm việc qua OLE yêu cầu một ứng dụng desktop hỗ trợ kích hoạt OLE và cài đặt Excel tương thích.

## **Yêu cầu trước**

Thêm Aspose.Cells for Android qua Java và Aspose.Slides for Android qua Java vào các phụ thuộc dự án của bạn. Gọi `ExcelChartEmbedding.createPresentation(getFilesDir())` từ một activity Android. Microsoft Office không cần thiết để tạo bản trình bày với các thư viện này.

Không cần tệp đầu vào nào: ví dụ tạo dữ liệu và biểu đồ trong bộ nhớ, sau đó ghi `OutputChart.pptx` vào thư mục tệp nội bộ của ứng dụng. Áp dụng giấy phép cho cả hai sản phẩm khi chạy ngoài chế độ đánh giá.

## **Cách hoạt động của việc nhúng**

1. Tạo một workbook với một worksheet dữ liệu và một chart sheet.  
2. Đặt chart sheet làm sheet hoạt động để workbook mở trên biểu đồ.  
3. Đặt phạm vi hiển thị OLE của workbook và vẽ biểu đồ thành PNG.  
4. Lưu workbook dưới dạng XLSX trong bộ nhớ và nhúng các byte đó vào một slide.  
5. Gán PNG làm ảnh xem trước của đối tượng OLE và lưu bản trình bày dưới dạng PPTX.

Phạm vi hiển thị của workbook và khung trên slide có vai trò khác nhau. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) nhận các chỉ số hàng và cột bắt đầu/kết thúc dựa trên chỉ số 0. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) thay vào đó nhận hàng trên cùng, cột trái, hàng dưới và cột phải. Ví dụ sử dụng chỉ số hàng 55 và chỉ số cột 25 làm ranh giới dưới‑phải; các giá trị này là lựa chọn bố cục, không phải số lượng hàng hoặc cột dữ liệu.

Khung slide sử dụng đơn vị point. Ví dụ điều chỉnh nó vừa trong slide và căn giữa trong khi duy trì tỷ lệ khung hình của PNG, thay vì kéo dài ảnh xem trước để lấp đầy slide.

## **Tạo và nhúng biểu đồ**

Ví dụ đầy đủ dưới đây tạo dữ liệu cho `DataSheet` với bốn hàng và năm cột giá trị. Mỗi hàng trở thành một series cho biểu đồ. `ChartSheet` được chọn làm sheet hoạt động trước khi workbook được lưu.

Workbook được lưu rõ ràng dưới dạng XLSX, khớp với phần mở rộng `xlsx` được truyền vào [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/). PNG được tải trực tiếp từ các byte mà không qua chuyển đổi bitmap trung gian. Gán PNG thông qua [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) thay thế hình giữ chỗ OLE mặc định.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
        try {
            Workbook workbook = new Workbook();
            try {
                Worksheet dataSheet = workbook.getWorksheets().get(0);
                dataSheet.setName("DataSheet");

                int[][] values = {
                    { 67, 44, 46, 43, 24 },
                    { 86, 64, 97, 29, 40 },
                    { 68, 89, 78, 69, 38 },
                    { 91, 48, 60, 26, 25 }
                };

                for (int row = 0; row < values.length; row++) {
                    for (int column = 0; column < values[row].length; column++) {
                        dataSheet.getCells().get(row, column).putValue(values[row][column]);
                    }
                }

                int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
                Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
                chartSheet.setName("ChartSheet");

                int lastChartRow = 55;
                int lastChartColumn = 25;
                int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
                Chart chart = chartSheet.getCharts().get(chartIndex);
                for (int row = 1; row <= values.length; row++) {
                    chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
                }

                workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
                workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

                // Kết xuất bản xem trước biểu đồ và tuần tự hoá sổ làm việc có thể chỉnh sửa riêng biệt.
                ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
                imageOptions.setImageType(ImageType.PNG);
                ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
                chart.toImage(chartImageStream, imageOptions);
                byte[] chartImageBytes = chartImageStream.toByteArray();

                ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                workbook.save(workbookStream, XLSX);
                byte[] workbookBytes = workbookStream.toByteArray();

                IImage chartImage = Images.fromData(chartImageBytes);
                try {
                    Presentation presentation = new Presentation();
                    try {
                        ISlide slide = presentation.getSlides().get_Item(0);
                        double slideWidth = presentation.getSlideSize().getSize().getWidth();
                        double slideHeight = presentation.getSlideSize().getSize().getHeight();

                        // Điều chỉnh bản xem trước để vừa trong slide mà không thay đổi tỉ lệ khung hình.
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
                    } finally {
                        presentation.dispose();
                    }
                } finally {
                    chartImage.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Could not create the presentation: " + exception.getMessage());
        }
    }
}
```

## **Kết quả mong đợi**

`OutputChart.pptx` chứa một slide với một workbook Excel được nhúng và một ảnh xem trước biểu đồ. Workbook chứa dữ liệu gốc và một biểu đồ cột với bốn series. Ảnh xem trước được căn giữa trên slide và giữ nguyên tỉ lệ.

![Biểu đồ cột Excel được hiển thị làm ảnh xem trước của một workbook được nhúng](excel-chart-ole-preview.png)

Trong môi trường PowerPoint desktop tương thích có cài đặt Excel, nhấp đúp vào đối tượng để kích hoạt và chỉnh sửa workbook được nhúng. Việc kích hoạt và chỉnh sửa phụ thuộc vào hỗ trợ OLE và cài đặt bảo mật của ứng dụng host.

## **Câu hỏi thường gặp**

**Tại sao cần một ảnh xem trước?**

Workbook được nhúng và ảnh xem trước trên slide là hai nội dung riêng biệt. Cung cấp một ảnh biểu đồ để slide hiển thị biểu đồ thay vì hình giữ chỗ mặc định "EMBEDDED OLE OBJECT". Xem [Vấn đề ảnh xem trước đối tượng khi thêm OleObjectFrame](/slides/vi/androidjava/object-preview-issue-when-adding-oleobjectframe/).

**Ảnh xem trước có tự động cập nhật khi tôi thay đổi workbook trong mã không?**

Xem ảnh xem trước như một ảnh chụp nhanh. Khi cập nhật dữ liệu workbook bằng chương trình, hãy tạo lại ảnh biểu đồ và thay thế ảnh xem trước cũng như dữ liệu workbook được nhúng.

**Tôi có thể dùng XLS thay cho XLSX không?**

Có. Lưu workbook dưới định dạng XLS và sử dụng `xls` làm phần mở rộng dữ liệu được nhúng. Phần mở rộng phải khớp với định dạng workbook thực tế; chỉ thay đổi phần mở rộng mà không chuyển đổi dữ liệu sẽ không hiệu quả.

**Tại sao đối tượng có thể thay đổi kích thước sau khi kích hoạt?**

Ứng dụng host có thể cập nhật cách hiển thị của đối tượng OLE khi nó kích hoạt workbook. Cả phạm vi hiển thị OLE của workbook và kích thước khung slide đều quan trọng. Xem [Giải pháp hoạt động cho việc thay đổi kích thước Worksheet](/slides/vi/androidjava/working-solution-for-worksheet-resizing/).

## **Các phần liên quan**

- [Giải pháp hoạt động cho việc thay đổi kích thước Worksheet](/slides/vi/androidjava/working-solution-for-worksheet-resizing/)
- [Vấn đề ảnh xem trước đối tượng khi thêm OleObjectFrame](/slides/vi/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [Quản lý OLE](/slides/vi/androidjava/manage-ole/)