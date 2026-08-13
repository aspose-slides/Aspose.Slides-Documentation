---
title: Giải pháp hoạt động cho việc thay đổi kích thước bảng tính
type: docs
weight: 20
url: /vi/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- hình ảnh xem trước
- điều chỉnh kích thước hình ảnh
- Excel
- bảng tính
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Sửa lỗi thay đổi kích thước OLE bảng tính Excel trong bản trình chiếu: hai cách để giữ khung đối tượng nhất quán—điều chỉnh khung hoặc bảng tính—trên các định dạng PPT và PPTX."
---
{{% alert color="info" %}}
Đã được ghi nhận rằng các bảng tính Excel được nhúng dưới dạng đối tượng OLE trong một bản trình chiếu PowerPoint thông qua các thành phần Aspose bị thay đổi kích thước thành một tỉ lệ không xác định sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt về mặt hình ảnh đáng chú ý trong bản trình chiếu giữa trạng thái trước và sau khi kích hoạt đối tượng OLE. Chúng tôi đã nghiên cứu chi tiết vấn đề này và đưa ra giải pháp, được trình bày trong bài viết này.
{{% /alert %}}

## **Bối cảnh**

Trong bài viết [Manage OLE](/slides/vi/java/manage-ole/), chúng tôi đã giải thích cách thêm khung OLE vào bản trình chiếu PowerPoint bằng Aspose.Slides for Java. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/java/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán một hình ảnh của vùng bảng tính được chọn cho khung đối tượng OLE. Trong bản trình chiếu xuất ra, khi bạn nhấp đúp vào khung OLE hiển thị hình ảnh bảng tính, workbook Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn trên workbook Excel thực tế và sau đó quay lại slide bằng cách nhấp ra ngoài workbook Excel đã kích hoạt. Kích thước của khung OLE sẽ thay đổi khi người dùng trở lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy thuộc vào kích thước của khung OLE và workbook Excel được nhúng.

## **Nguyên nhân gây thay đổi kích thước**

Do workbook Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước ban đầu khi được kích hoạt lần đầu. Ngược lại, khung đối tượng OLE có kích thước của riêng mình. Theo Microsoft, khi workbook Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước để đảm bảo duy trì tỷ lệ đúng như một phần của quá trình nhúng. Việc thay đổi kích thước xảy ra dựa trên sự khác biệt giữa kích thước cửa sổ Excel và kích thước cùng vị trí của khung OLE.

## **Giải pháp hoạt động**

Có hai giải pháp khả thi để tránh hiệu ứng thay đổi kích thước.

- Điều chỉnh kích thước khung OLE trong bản trình chiếu PowerPoint sao cho phù hợp với chiều cao và chiều rộng của số hàng và cột mong muốn trong khung OLE.
- Giữ kích thước khung OLE cố định và điều chỉnh kích thước của các hàng và cột tham gia để vừa trong kích thước khung OLE đã chọn.

### **Điều chỉnh kích thước khung OLE**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước khung OLE của workbook Excel được nhúng sao cho khớp với tổng kích thước của các hàng và cột tham gia trong bảng tính Excel.

Giả sử chúng ta có một bảng tính Excel mẫu và muốn thêm nó vào bản trình chiếu dưới dạng khung OLE. Trong trường hợp này, kích thước của khung OLE sẽ được tính trước dựa trên tổng chiều cao các hàng và chiều rộng các cột tham gia trong workbook. Sau đó, chúng ta sẽ đặt kích thước khung OLE bằng giá trị đã tính. Để tránh thông báo màu đỏ "EMBEDDED OLE OBJECT" cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp một hình ảnh của các phần mong muốn của các hàng và cột trong workbook và đặt nó làm hình ảnh khung OLE.

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

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

// Lấy chiều rộng và chiều cao của hình ảnh OLE bằng đơn vị point.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Chúng ta cần sử dụng workbook đã được sửa đổi.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Thêm hình ảnh OLE vào tài nguyên của bản trình chiếu.
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

Trong cách tiếp cận này, chúng ta sẽ học cách điều chỉnh chiều cao của các hàng tham gia và chiều rộng của các cột tham gia để khớp với kích thước khung OLE tùy chỉnh.

Giả sử chúng ta có một bảng tính Excel mẫu và muốn thêm nó vào bản trình chiếu dưới dạng khung OLE. Trong trường hợp này, chúng ta sẽ đặt kích thước khung OLE và điều chỉnh kích thước của các hàng và cột tham gia trong vùng khung OLE. Sau đó chúng ta sẽ lưu workbook vào một luồng để áp dụng các thay đổi và chuyển đổi nó thành mảng byte để thêm vào khung OLE. Để tránh thông báo màu đỏ "EMBEDDED OLE OBJECT" cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp một hình ảnh của các phần mong muốn của các hàng và cột trong workbook và đặt nó làm hình ảnh khung OLE.

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

// Điều chỉnh kích thước phạm vi ô để khớp với kích thước khung.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Chúng ta cần sử dụng workbook đã được chỉnh sửa.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Thêm hình ảnh OLE vào tài nguyên của bản trình chiếu.
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
 * @param width     Chiều rộng mong muốn của phạm vi ô tính bằng điểm.
 * @param height    Chiều cao mong muốn của phạm vi ô tính bằng điểm.
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
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

## **Kết luận**

{{% alert color="info" %}} 
Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước bảng tính. Lựa chọn cách tiếp cận phù hợp phụ thuộc vào yêu cầu và trường hợp sử dụng cụ thể. Cả hai cách đều hoạt động tương tự, bất kể bản trình chiếu được tạo từ mẫu hay từ đầu. Ngoài ra, không có giới hạn nào về kích thước khung OLE trong giải pháp này.
{{% /alert %}}

## **Câu hỏi thường gặp**

### Tại sao một bảng tính Excel được nhúng lại thay đổi kích thước khi được kích hoạt lần đầu trong PowerPoint?

Điều này xảy ra vì Excel cố gắng giữ nguyên kích thước cửa sổ ban đầu khi được kích hoạt, trong khi khung OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel sẽ thương lượng kích thước để duy trì tỷ lệ khung hình, điều này có thể gây ra việc thay đổi kích thước.

### Có thể ngăn ngừa hoàn toàn vấn đề thay đổi kích thước này không?

Có. Bằng cách điều chỉnh khung OLE để phù hợp với kích thước phạm vi ô Excel hoặc điều chỉnh phạm vi ô để phù hợp với kích thước khung OLE mong muốn, bạn có thể ngăn ngừa việc thay đổi kích thước không mong muốn.

### Nên sử dụng phương pháp điều chỉnh nào, điều chỉnh khung OLE hay điều chỉnh phạm vi ô?

Chọn **điều chỉnh khung OLE** nếu bạn muốn giữ nguyên kích thước hàng và cột gốc của Excel. Chọn **điều chỉnh phạm vi ô** nếu bạn muốn khung OLE có kích thước cố định trong bản trình chiếu.

### Các giải pháp này có hoạt động nếu bản trình chiếu của tôi dựa trên mẫu không?

Có. Cả hai giải pháp đều hoạt động cho bản trình chiếu được tạo từ mẫu và từ đầu.

### Có giới hạn nào về kích thước khung OLE khi sử dụng các phương pháp này không?

Không. Bạn có thể tạo khung OLE có kích thước bất kỳ miễn là bạn thiết lập tỉ lệ một cách phù hợp.

### Có cách nào để tránh văn bản giữ chỗ "EMBEDDED OLE OBJECT" trong PowerPoint không?

Có. Bằng cách chụp ảnh nhanh của phạm vi ô Excel mục tiêu và đặt nó làm hình ảnh giữ chỗ cho khung OLE, bạn có thể hiển thị một hình ảnh xem trước tùy chỉnh thay cho hình giữ chỗ mặc định.

## **Bài viết liên quan**

[Tạo biểu đồ Excel và nhúng nó vào bản trình chiếu dưới dạng đối tượng OLE](/slides/vi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Cập nhật đối tượng OLE tự động bằng Add-In MS PowerPoint](/slides/vi/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)