---
title: Giải pháp hoạt động cho việc thay đổi kích thước bảng tính
type: docs
weight: 20
url: /vi/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- hình ảnh xem trước
- thay đổi kích thước ảnh
- Excel
- bảng tính
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Khắc phục việc thay đổi kích thước OLE của bảng tính Excel trong bản trình bày: hai cách để giữ khung đối tượng nhất quán—cân chỉnh khung hoặc bảng tính—trên các định dạng PPT và PPTX."
---
{{% alert color="info" title="Note" %}}
Các bảng tính Excel được nhúng dưới dạng đối tượng OLE trong bản trình bày PowerPoint bằng các thành phần Aspose có thể thay đổi kích thước một cách không mong muốn sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt hình ảnh đáng chú ý giữa đối tượng OLE trước và sau khi kích hoạt. Bài viết này giải thích vấn đề và mô tả hai cách để khắc phục.
{{% /alert %}}

## **Bối cảnh**

Trong bài viết [Manage OLE](/slides/vi/java/manage-ole/), chúng tôi đã giải thích cách thêm khung OLE vào bản trình bày PowerPoint bằng Aspose.Slides for Java. Để giải quyết [object preview issue](/slides/vi/java/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán một hình ảnh của khu vực bảng tính đã chọn cho khung đối tượng OLE. Trong bản trình bày đầu ra, khi bạn nhấp đúp vào khung đối tượng OLE hiển thị hình ảnh bảng tính, sổ làm việc Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn đối với sổ làm việc Excel thực tế và sau đó quay lại slide bằng cách nhấp ra ngoài sổ làm việc Excel đã kích hoạt. Kích thước của khung đối tượng OLE sẽ thay đổi khi người dùng quay lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy thuộc vào kích thước của khung OLE và sổ làm việc Excel được nhúng.

## **Nguyên nhân của việc thay đổi kích thước**

Vì sổ làm việc Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước gốc khi được kích hoạt lần đầu. Ngược lại, khung đối tượng OLE có kích thước riêng của nó. Theo Microsoft, khi sổ làm việc Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước để đảm bảo duy trì tỷ lệ chính xác như một phần của quá trình nhúng. Việc thay đổi kích thước xảy ra dựa trên sự chênh lệch giữa kích thước cửa sổ Excel và kích thước và vị trí của khung đối tượng OLE.

## **Giải pháp hoạt động**

Có hai giải pháp khả thi để tránh hiệu ứng thay đổi kích thước.

- Cân chỉnh khung OLE trong bản trình bày PowerPoint để khớp với tổng chiều cao và chiều rộng của các hàng và cột đã chọn.
- Giữ kích thước khung OLE cố định và cân chỉnh các hàng và cột đã chọn để vừa trong khung.

### **Cân chỉnh kích thước khung OLE**

Cách tiếp cận này đặt kích thước khung OLE sao cho khớp với tổng chiều cao và chiều rộng của các hàng và cột đã chọn trong bảng tính Excel được nhúng.

Ví dụ tải một sổ làm việc Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của bảng tính đầu tiên bằng chỉ mục bắt đầu từ 0. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) xác định phạm vi hiển thị. Bản xem trước được render ở 96 DPI, và kích thước pixel của nó được chuyển đổi sang điểm bằng 72 điểm mỗi inch. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) nhúng sổ làm việc đã chỉnh sửa vào một khung với các kích thước đó. Bản xem trước được gán thông qua [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) để thay thế chỗ giữ chỗ "EMBEDDED OLE OBJECT" trong bản trình bày đã lưu.

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

// Lấy chiều rộng và chiều cao của hình ảnh OLE tính bằng điểm.
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

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

Trợ giúp preview thiết lập [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) cho phạm vi đã chọn và loại bỏ lề, tiêu đề và chân trang. Khi [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) được bật, [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) render phạm vi dưới dạng ảnh PNG. Trợ giúp trả về một luồng đầu vào mới chứa ảnh PNG, đặt tại đầu để sử dụng trong bản trình bày.

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

### **Cân chỉnh kích thước phạm vi ô**

Cách tiếp cận này cân chỉnh chiều cao của các hàng đã chọn và chiều rộng của các cột đã chọn để khớp với kích thước khung OLE tùy chỉnh.

Ví dụ tải một sổ làm việc Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của bảng tính đầu tiên bằng chỉ mục bắt đầu từ 0. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) xác định phạm vi hiển thị, và trợ giúp dưới đây cân chỉnh phạm vi đó để vừa vào khung rộng 400 điểm và cao 100 điểm. Sau khi lưu sổ làm việc đã chỉnh sửa vào một luồng, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) nhúng nó ở kích thước đã chỉ định. Một bản xem trước được render ở 96 DPI được gán thông qua [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--), vì vậy bản trình bày đã lưu hiển thị các ô đã chọn thay vì chỗ giữ chỗ mặc định.

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

// Cân chỉnh phạm vi ô để vừa với kích thước khung.
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

Trợ giúp cân chỉnh tính toán tỷ lệ chiều rộng và chiều cao riêng biệt cho phạm vi đã chọn, bảo tồn độ rộng tương đối của các cột và độ cao tương đối của các hàng. Nó chuyển đổi các kích thước đã tính từ điểm sang inch trước khi áp dụng chúng bằng [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) và [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). Phạm vi đã chọn phải có chiều rộng và chiều cao khác không.

```java
/**
 * @param width     Chiều rộng mong đợi của phạm vi ô tính tính bằng điểm.
 * @param height    Chiều cao mong đợi của phạm vi ô tính tính bằng điểm.
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

Trợ giúp preview này render phạm vi đã thay đổi kích thước bằng cách sử dụng [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Nó giới hạn [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) chỉ trong phạm vi đó, loại bỏ lề, tiêu đề và chân trang, và trả về một luồng PNG đặt tại đầu.

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

{{% alert color="info" title="Note" %}}
Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước bảng tính. Chọn cách tiếp cận phù hợp nhất với yêu cầu và trường hợp sử dụng của bạn. Cả hai cách đều hoạt động giống nhau, bất kể bản trình bày được tạo từ mẫu hay từ đầu. Ngoài ra, không có giới hạn nào về kích thước của khung đối tượng OLE trong giải pháp này.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tại sao một bảng tính Excel được nhúng lại thay đổi kích thước khi lần đầu được kích hoạt trong PowerPoint?**  
Điều này xảy ra vì Excel cố gắng duy trì kích thước cửa sổ gốc khi được kích hoạt, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel thương lượng kích thước để duy trì tỷ lệ, điều này có thể gây ra việc thay đổi kích thước.

**Liệu có thể ngăn hoàn toàn vấn đề thay đổi kích thước này không?**  
Có. Bằng cách cân chỉnh khung OLE để vừa với kích thước phạm vi ô Excel hoặc cân chỉnh phạm vi ô để vừa với kích thước khung OLE mong muốn, bạn có thể ngăn ngừa việc thay đổi kích thước không mong muốn.

**Phương pháp cân chỉnh nào nên dùng, cân chỉnh khung OLE hay cân chỉnh phạm vi ô?**  
Select **OLE frame scaling** nếu bạn muốn giữ nguyên kích thước hàng và cột gốc của Excel. Chọn **cell range scaling** nếu bạn muốn có một kích thước cố định cho khung OLE trong bản trình bày.

**Liệu các giải pháp này có hoạt động nếu bản trình bày của tôi dựa trên mẫu không?**  
Có. Cả hai giải pháp đều hoạt động cho các bản trình bày được tạo từ mẫu và từ đầu.

**Có giới hạn nào về kích thước của khung OLE khi sử dụng các phương pháp này không?**  
Không. Bạn có thể đặt khung đối tượng OLE ở bất kỳ kích thước nào miễn là bạn thiết lập tỷ lệ một cách phù hợp.

**Có cách nào để tránh văn bản giữ chỗ "EMBEDDED OLE OBJECT" trong PowerPoint không?**  
Có. Bằng cách chụp ảnh nhanh của phạm vi ô Excel mục tiêu và đặt nó làm hình ảnh giữ chỗ cho khung OLE, bạn có thể hiển thị một ảnh preview tùy chỉnh thay cho chỗ giữ chỗ mặc định.

## **Bài viết liên quan**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/vi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/vi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)