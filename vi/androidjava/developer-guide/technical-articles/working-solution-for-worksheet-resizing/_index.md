---
title: Giải pháp hoạt động cho việc thay đổi kích thước bảng tính
type: docs
weight: 20
url: /vi/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- hình ảnh xem trước
- điều chỉnh kích thước hình ảnh
- Excel
- bảng tính
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Khắc phục việc thay đổi kích thước OLE của bảng tính Excel trong bản trình chiếu: hai cách để giữ khung đối tượng nhất quán—điều chỉnh tỷ lệ khung hoặc bảng—trên các định dạng PPT và PPTX."
---
{{% alert color="primary" %}}

Đã được quan sát thấy rằng các bảng tính Excel được nhúng dưới dạng đối tượng OLE trong bản trình chiếu PowerPoint thông qua các thành phần Aspose bị thay đổi kích thước thành một tỷ lệ không xác định sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt về hình ảnh đáng chú ý trong bản trình chiếu giữa trạng thái trước và sau khi kích hoạt đối tượng OLE. Chúng tôi đã điều tra chi tiết vấn đề này và cung cấp một giải pháp, được trình bày trong bài viết này.

{{% /alert %}}

## **Bối cảnh**

Trong bài viết [Manage OLE](/slides/vi/androidjava/manage-ole/), chúng tôi đã giải thích cách thêm khung OLE vào bản trình chiếu PowerPoint bằng Aspose.Slides cho Android qua Java. Để giải quyết vấn đề [object preview issue](/slides/vi/androidjava/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán một hình ảnh của vùng bảng tính đã chọn cho khung đối tượng OLE. Trong bản trình chiếu đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh bảng tính, sổ làm việc Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn trên sổ làm việc Excel thực tế và sau đó trở lại slide bằng cách nhấp ra bên ngoài sổ làm việc Excel đã kích hoạt. Kích thước của khung đối tượng OLE sẽ thay đổi khi người dùng trở lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy thuộc vào kích thước của khung đối tượng OLE và sổ làm việc Excel được nhúng.

## **Nguyên nhân gây thay đổi kích thước**

Vì sổ làm việc Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước ban đầu khi kích hoạt lần đầu. Ngược lại, khung đối tượng OLE cũng có kích thước riêng. Theo Microsoft, khi sổ làm việc Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước để đảm bảo duy trì tỷ lệ đúng như một phần của quá trình nhúng. Việc thay đổi kích thước diễn ra dựa trên sự khác biệt giữa kích thước cửa sổ Excel và kích thước cũng như vị trí của khung đối tượng OLE.

## **Giải pháp hoạt động**

Có hai giải pháp khả thi để tránh hiệu ứng thay đổi kích thước.

- Điều chỉnh tỷ lệ kích thước khung OLE trong bản trình chiếu PowerPoint để phù hợp với chiều cao và chiều rộng của số lượng hàng và cột mong muốn trong khung OLE.
- Giữ kích thước khung OLE cố định và điều chỉnh tỷ lệ kích thước của các hàng và cột tham gia để vừa với kích thước khung OLE đã chọn.

### **Điều chỉnh tỷ lệ kích thước khung OLE**

Trong cách tiếp cận này, chúng ta sẽ học cách đặt kích thước khung OLE của sổ làm việc Excel được nhúng sao cho khớp với kích thước tổng hợp của các hàng và cột tham gia trong bảng tính Excel.

Giả sử chúng ta có một bảng tính Excel mẫu và muốn thêm nó vào bản trình chiếu dưới dạng khung OLE. Trong trường hợp này, kích thước của khung đối tượng OLE sẽ được tính toán trước tiên dựa trên tổng chiều cao các hàng và chiều rộng các cột của các hàng và cột tham gia trong sổ làm việc. Sau đó, chúng ta sẽ đặt kích thước khung OLE bằng giá trị đã tính. Để tránh thông báo màu đỏ "EMBEDDED OLE OBJECT" cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp một hình ảnh của các phần mong muốn của các hàng và cột trong sổ làm việc và đặt nó làm hình ảnh khung OLE.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Đặt kích thước hiển thị khi tệp sổ làm việc được sử dụng làm đối tượng OLE trong PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Lấy chiều rộng và chiều cao của hình ảnh OLE tính bằng điểm.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// Chúng ta cần sử dụng sổ làm việc đã được sửa đổi.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Thêm hình ảnh OLE vào tài nguyên bản trình chiếu.
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

### **Điều chỉnh tỷ lệ kích thước vùng ô**

Trong cách tiếp cận này, chúng ta sẽ học cách điều chỉnh chiều cao của các hàng tham gia và chiều rộng của các cột tham gia để phù hợp với kích thước khung OLE tùy chỉnh.

Giả sử chúng ta có một bảng tính Excel mẫu và muốn thêm nó vào bản trình chiếu dưới dạng khung OLE. Trong trường hợp này, chúng ta sẽ đặt kích thước khung OLE và điều chỉnh kích thước của các hàng và cột tham gia vào khu vực khung OLE. Sau đó, chúng ta sẽ lưu sổ làm việc vào một luồng để áp dụng các thay đổi và chuyển đổi nó thành mảng byte để thêm vào khung OLE. Để tránh thông báo màu đỏ "EMBEDDED OLE OBJECT" cho khung OLE trong PowerPoint, chúng ta cũng sẽ chụp một hình ảnh của các phần mong muốn của các hàng và cột trong sổ làm việc và đặt nó làm hình ảnh khung OLE.

```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// Đặt kích thước hiển thị khi tệp sổ làm việc được sử dụng làm đối tượng OLE trong PowerPoint.
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// Điều chỉnh tỷ lệ vùng ô để vừa với kích thước khung.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Chúng ta cần sử dụng sổ làm việc đã được sửa đổi.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Thêm hình ảnh OLE vào tài nguyên bản trình chiếu.
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
 * @param width     Độ rộng mong đợi của vùng ô tính bằng điểm.
 * @param height    Độ cao mong đợi của vùng ô tính bằng điểm.
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

{{% alert color="primary" %}} 

Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước bảng tính. Việc lựa chọn cách tiếp cận phù hợp phụ thuộc vào yêu cầu và trường hợp sử dụng cụ thể. Cả hai cách đều hoạt động tương tự, bất kể bản trình chiếu được tạo từ mẫu hay từ đầu. Ngoài ra, không có giới hạn nào về kích thước khung đối tượng OLE trong giải pháp này.

{{% /alert %}}

## **Câu hỏi thường gặp**

**Tại sao một bảng tính Excel được nhúng lại thay đổi kích thước khi lần đầu được kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng giữ nguyên kích thước cửa sổ ban đầu khi được kích hoạt, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel thương lượng kích thước để duy trì tỉ lệ, điều này có thể gây ra việc thay đổi kích thước.

**Có thể ngăn chặn hoàn toàn vấn đề thay đổi kích thước này không?**

Có. Bằng cách điều chỉnh tỷ lệ khung OLE để phù hợp với kích thước vùng ô Excel hoặc điều chỉnh tỷ lệ của vùng ô để phù hợp với kích thước khung OLE mong muốn, bạn có thể ngăn ngừa việc thay đổi kích thước không mong muốn.

**Tôi nên sử dụng phương pháp điều chỉnh nào, điều chỉnh khung OLE hay điều chỉnh vùng ô?**

Chọn **OLE frame scaling** nếu bạn muốn giữ nguyên kích thước hàng và cột gốc của Excel. Chọn **cell range scaling** nếu bạn muốn có kích thước cố định cho khung OLE trong bản trình chiếu của mình.

**Các giải pháp này có hoạt động nếu bản trình chiếu của tôi dựa trên mẫu không?**

Có. Cả hai giải pháp đều hoạt động cho các bản trình chiếu được tạo từ mẫu và từ đầu.

**Có giới hạn nào về kích thước khung OLE khi sử dụng các phương pháp này không?**

Không. Bạn có thể đặt khung đối tượng OLE ở bất kỳ kích thước nào miễn là bạn thiết lập tỷ lệ một cách phù hợp.

**Có cách nào tránh văn bản chỗ trống "EMBEDDED OLE OBJECT" trong PowerPoint không?**

Có. Bằng cách chụp ảnh vùng ô Excel mục tiêu và đặt nó làm hình ảnh chỗ trống của khung OLE, bạn có thể hiển thị một hình ảnh xem trước tùy chỉnh thay cho chỗ trống mặc định.