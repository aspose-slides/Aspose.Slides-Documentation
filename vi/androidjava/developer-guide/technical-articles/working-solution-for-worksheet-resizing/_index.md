---
title: Giải pháp hoạt động cho việc thay đổi kích thước bảng tính
type: docs
weight: 20
url: /vi/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- hình ảnh xem trước
- thay đổi kích thước hình ảnh
- Excel
- bảng tính
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Khắc phục việc thay đổi kích thước OLE của bảng tính Excel trong bản trình bày: hai cách để giữ khung đối tượng nhất quán—điều chỉnh kích thước khung hoặc bảng tính—trên các định dạng PPT và PPTX."
---
{{% alert color="info" %}}
Đã được ghi nhận rằng các bảng tính Excel được nhúng dưới dạng đối tượng OLE trong bản trình bày PowerPoint thông qua các thành phần Aspose bị thay đổi kích thước thành một tỉ lệ không xác định sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt về hình ảnh đáng chú ý trong bản trình bày giữa trạng thái trước và sau khi kích hoạt đối tượng OLE. Chúng tôi đã nghiên cứu chi tiết vấn đề này và đưa ra giải pháp, được trình bày trong bài viết này.
{{% /alert %}}

## **Bối cảnh**

Trong bài viết [Quản lý OLE](/slides/vi/androidjava/manage-ole/), chúng tôi đã giải thích cách thêm một khung OLE vào bản trình bày PowerPoint bằng Aspose.Slides for Android via Java. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/androidjava/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán một hình ảnh của vùng bảng tính được chọn cho khung đối tượng OLE. Trong bản trình bày đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh bảng tính, workbook Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào cho workbook Excel thực tế và sau đó quay lại slide bằng cách nhấp ra ngoài workbook Excel đã kích hoạt. Kích thước của khung đối tượng OLE sẽ thay đổi khi người dùng quay lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy thuộc vào kích thước của khung OLE và workbook Excel được nhúng.

## **Nguyên nhân gây thay đổi kích thước**

Vì workbook Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước gốc khi lần kích hoạt đầu tiên. Ngược lại, khung đối tượng OLE có kích thước của riêng nó. Theo Microsoft, khi workbook Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước để đảm bảo duy trì tỷ lệ đúng như một phần của quá trình nhúng. Việc thay đổi kích thước xảy ra dựa trên sự khác biệt giữa kích thước cửa sổ Excel và kích thước cùng vị trí của khung đối tượng OLE.

## **Giải pháp hoạt động**

Có hai giải pháp khả thi để tránh hiệu ứng thay đổi kích thước.

- Điều chỉnh kích thước khung OLE trong bản trình bày PowerPoint để phù hợp với chiều cao và chiều rộng của số dòng và cột mong muốn trong khung OLE.
- Giữ kích thước khung OLE không thay đổi và điều chỉnh kích thước của các dòng và cột tham gia để phù hợp với kích thước khung OLE đã chọn.

### **Điều chỉnh kích thước khung OLE**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước khung OLE của workbook Excel đã nhúng sao cho khớp với kích thước tổng hợp của các dòng và cột tham gia trong bảng tính Excel.

Giả sử chúng ta có một bảng tính Excel mẫu và muốn thêm nó vào bản trình bày dưới dạng khung OLE. Trong trường hợp này, kích thước của khung đối tượng OLE sẽ được tính toán đầu tiên dựa trên tổng chiều cao các dòng và chiều rộng các cột của các dòng và cột tham gia trong workbook. Sau đó, chúng ta sẽ đặt kích thước khung OLE thành giá trị đã tính. Để tránh thông báo màu đỏ "EMBEDDED OLE OBJECT" cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp ảnh các phần mong muốn của các dòng và cột trong workbook và đặt nó làm hình ảnh khung OLE.

```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Đặt kích thước hiển thị khi tệp workbook được sử dụng làm đối tượng OLE trong PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Lấy chiều rộng và chiều cao của hình ảnh OLE tính bằng điểm.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// Chúng ta cần sử dụng workbook đã được chỉnh sửa.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Thêm hình ảnh OLE vào tài nguyên của bản trình bày.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Tạo khung đối tượng OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **Điều chỉnh kích thước phạm vi ô**

Trong cách tiếp cận này, chúng ta sẽ học cách điều chỉnh chiều cao của các dòng tham gia và chiều rộng của các cột tham gia sao cho phù hợp với kích thước khung OLE tùy chỉnh.

Giả sử chúng ta có một bảng tính Excel mẫu và muốn thêm nó vào bản trình bày dưới dạng khung OLE. Trong trường hợp này, chúng ta sẽ đặt kích thước khung OLE và điều chỉnh kích thước của các dòng và cột tham gia trong khu vực khung OLE. Sau đó, chúng ta sẽ lưu workbook vào một luồng để áp dụng các thay đổi và chuyển đổi nó thành mảng byte để thêm vào khung OLE. Để tránh thông báo màu đỏ "EMBEDDED OLE OBJECT" cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp ảnh các phần mong muốn của các dòng và cột trong workbook và đặt nó làm hình ảnh khung OLE.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Đặt kích thước hiển thị khi tệp workbook được sử dụng làm đối tượng OLE trong PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Điều chỉnh phạm vi ô để phù hợp với kích thước khung.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Chúng ta cần sử dụng workbook đã được chỉnh sửa.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Thêm hình ảnh OLE vào tài nguyên của bản trình bày.
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Tạo khung đối tượng OLE.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     Độ rộng mong muốn của phạm vi ô tính bằng điểm.
 * @param height    Độ cao mong muốn của phạm vi ô tính bằng điểm.
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true;

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **Kết luận**

{{% alert color="info" %}} 
Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước bảng tính. Việc lựa chọn cách tiếp cận phù hợp phụ thuộc vào yêu cầu và trường hợp sử dụng cụ thể. Cả hai cách đều hoạt động tương tự, bất kể bản trình bày được tạo từ mẫu hay từ đầu. Ngoài ra, không có giới hạn nào về kích thước khung đối tượng OLE trong giải pháp này.
{{% /alert %}}

## **Câu hỏi thường gặp**

### Why does an embedded Excel worksheet change size when first activated in PowerPoint?

Điều này xảy ra vì Excel cố gắng duy trì kích thước cửa sổ gốc khi được kích hoạt, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel thương lượng kích thước để duy trì tỷ lệ ngang, điều này có thể gây ra việc thay đổi kích thước.

### Is it possible to prevent this resizing issue entirely?

Có. Bằng cách điều chỉnh khung OLE sao cho phù hợp với kích thước phạm vi ô Excel hoặc điều chỉnh phạm vi ô sao cho phù hợp với kích thước khung OLE mong muốn, bạn có thể ngăn chặn việc thay đổi kích thước không mong muốn.

### Which scaling method should I use, OLE frame scaling or cell range scaling?

Chọn **OLE frame scaling** nếu bạn muốn giữ nguyên kích thước hàng và cột gốc của Excel. Chọn **cell range scaling** nếu bạn muốn có một kích thước cố định cho khung OLE trong bản trình bày của mình.

### Will these solutions work if my presentation is based on a template?

Có. Cả hai giải pháp đều hoạt động cho các bản trình bày được tạo từ mẫu và từ đầu.

### Is there a limit to the size of the OLE frame when using these methods?

Không. Bạn có thể đặt khung đối tượng OLE ở bất kỳ kích thước nào miễn là bạn thiết lập tỉ lệ một cách thích hợp.

### Is there a way to avoid the "EMBEDDED OLE OBJECT" placeholder text in PowerPoint?

Có. Bằng cách chụp lại phạm vi ô Excel mục tiêu và đặt nó làm hình ảnh giữ chỗ của khung OLE, bạn có thể hiển thị ảnh xem trước tùy chỉnh thay cho ảnh giữ chỗ mặc định.