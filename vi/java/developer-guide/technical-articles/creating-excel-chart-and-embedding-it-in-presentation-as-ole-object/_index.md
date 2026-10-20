---
title: Tạo biểu đồ Excel và nhúng chúng vào bản trình bày dưới dạng OLE Object
type: docs
weight: 30
url: /vi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Biểu đồ Excel
- Nhúng biểu đồ
- Đối tượng OLE
- PowerPoint
- Bản trình bày
- Java
- Aspose.Slides
description: "Tạo một biểu đồ Excel bằng Aspose.Cells for Java và nhúng sổ làm việc vào bản trình bày PowerPoint với Aspose.Slides, bao gồm ảnh xem trước biểu đồ."
---
## **Tổng quan**

Bài viết này hướng dẫn cách tạo biểu đồ cột Excel bằng Aspose.Cells for Java và nhúng sổ làm việc của nó vào bản trình bày PowerPoint bằng Aspose.Slides for Java. Sổ làm việc được nhúng chứa cả dữ liệu nguồn và biểu đồ. Một ảnh xem trước dạng PNG riêng biệt hiển thị biểu đồ trên slide trước khi đối tượng OLE được kích hoạt.

Kết quả là một đối tượng Excel được nhúng, không phải là biểu đồ PowerPoint gốc. Việc chỉnh sửa sổ làm việc thông qua OLE yêu cầu một ứng dụng desktop hỗ trợ kích hoạt OLE và cài đặt Excel tương thích.

## **Yêu cầu trước**

Thêm Aspose.Cells for Java và Aspose.Slides for Java vào các phụ thuộc dự án của bạn. Chạy ví dụ trong một phương thức Java. Microsoft Office không cần thiết để tạo bản trình bày với các thư viện này.

Không cần tệp đầu vào: ví dụ tạo dữ liệu và biểu đồ trong bộ nhớ, sau đó ghi `OutputChart.pptx` vào thư mục làm việc hiện tại. Áp dụng giấy phép cho cả hai sản phẩm khi chạy ngoài chế độ đánh giá.

## **Cách nhúng hoạt động**

1. Tạo một sổ làm việc với một worksheet dữ liệu và một worksheet biểu đồ.  
2. Đặt worksheet biểu đồ làm hoạt động để sổ làm việc mở ở biểu đồ.  
3. Đặt phạm vi hiển thị OLE của sổ làm việc và vẽ biểu đồ thành PNG.  
4. Lưu sổ làm việc dưới dạng XLSX trong bộ nhớ và nhúng các byte đó vào một slide.  
5. Gán PNG làm ảnh xem trước của đối tượng OLE và lưu bản trình bày dưới dạng PPTX.

Phạm vi hiển thị của sổ làm việc và khung trên slide có vai trò khác nhau. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) nhận các chỉ số dòng và cột bắt đầu/kết thúc dựa trên chỉ số không. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) lại nhận dòng trên cùng, cột trái, dòng dưới cùng và cột phải. Ví dụ sử dụng chỉ số dòng 55 và chỉ số cột 25 làm giới hạn phía dưới‑phải; các giá trị này là lựa chọn bố cục, không phải số lượng dòng hoặc cột dữ liệu.

Khung slide sử dụng đơn vị point. Ví dụ điều chỉnh nó để vừa trong slide và căn giữa đồng thời giữ tỷ lệ khung hình của PNG, thay vì kéo căng ảnh xem trước để lấp đầy slide.

## **Tạo và nhúng biểu đồ**

Ví dụ hoàn chỉnh bên dưới điền `DataSheet` với bốn dòng và năm cột giá trị. Mỗi dòng trở thành một series biểu đồ. `ChartSheet` được chọn làm worksheet hoạt động trước khi sổ làm việc được lưu.

Sổ làm việc được lưu rõ ràng dưới dạng XLSX, phù hợp với phần mở rộng `xlsx` được truyền vào [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/). PNG được tải trực tiếp từ các byte của nó mà không qua bước chuyển đổi bitmap trung gian. Gán nó thông qua [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) thay thế cho hình giữ chỗ OLE mặc định.

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

        // Kết xuất ảnh xem trước biểu đồ và tuần tự hóa sổ làm việc có thể chỉnh sửa riêng biệt.
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

                // Điều chỉnh ảnh xem trước vừa trong slide mà không thay đổi tỷ lệ khung hình.
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
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
```
## **Kết quả mong đợi**

`OutputChart.pptx` chứa một slide với sổ làm việc Excel được nhúng và ảnh xem trước biểu đồ. Sổ làm việc chứa dữ liệu gốc và một biểu đồ cột với bốn series. Ảnh xem trước được căn giữa trên slide và giữ nguyên tỷ lệ của nó.

![Biểu đồ cột Excel hiển thị dưới dạng ảnh xem trước của sổ làm việc được nhúng](excel-chart-ole-preview.png)

Trong môi trường PowerPoint desktop tương thích có sẵn Excel, nhấp đúp vào đối tượng để kích hoạt và chỉnh sửa sổ làm việc được nhúng. Việc kích hoạt và chỉnh sửa phụ thuộc vào hỗ trợ OLE và cài đặt bảo mật của ứng dụng chủ.

## **Câu hỏi thường gặp**

**Tại sao cần hình ảnh xem trước?**

Sổ làm việc được nhúng và ảnh xem trước trên slide là nội dung riêng biệt. Cung cấp một hình ảnh biểu đồ để slide hiển thị biểu đồ thay vì hình giữ chỗ mặc định "EMBEDDED OLE OBJECT". Xem [Vấn đề xem trước đối tượng khi thêm OleObjectFrame](/slides/vi/java/object-preview-issue-when-adding-oleobjectframe/).

**Ảnh xem trước có tự động cập nhật khi tôi thay đổi sổ làm việc trong mã không?**

Xem ảnh xem trước như một bản chụp. Khi cập nhật dữ liệu sổ làm việc bằng chương trình, cần tạo lại hình ảnh biểu đồ và thay thế ảnh xem trước cùng với dữ liệu sổ làm việc được nhúng.

**Tôi có thể dùng XLS thay vì XLSX không?**

Có. Lưu sổ làm việc ở định dạng XLS và sử dụng `xls` làm phần mở rộng dữ liệu được nhúng. Phần mở rộng phải khớp với định dạng thực tế của sổ làm việc; chỉ thay đổi phần mở rộng mà không chuyển đổi dữ liệu sẽ không có hiệu quả.

**Tại sao đối tượng có thể thay đổi kích thước sau khi kích hoạt?**

Ứng dụng chủ có thể cập nhật cách trình bày của đối tượng OLE khi nó kích hoạt sổ làm việc. Cả phạm vi hiển thị OLE của sổ làm việc và kích thước khung slide đều quan trọng. Xem [Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX](/slides/vi/java/working-solution-for-chart-resizing-in-pptx/).

## **Các mục liên quan**

- [Giải pháp hoạt động cho việc thay đổi kích thước biểu đồ trong PPTX](/slides/vi/java/working-solution-for-chart-resizing-in-pptx/)
- [Vấn đề xem trước đối tượng khi thêm OleObjectFrame](/slides/vi/java/object-preview-issue-when-adding-oleobjectframe/)
- [Cập nhật tự động các đối tượng OLE bằng Add-In PowerPoint](/slides/vi/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)