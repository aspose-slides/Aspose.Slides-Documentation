---
title: Giải pháp hoạt động cho việc thay đổi kích thước bảng tính
type: docs
weight: 20
url: /vi/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- ảnh xem trước
- thay đổi kích thước ảnh
- Excel
- bảng tính
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Sửa đổi kích thước OLE của bảng tính Excel trong bản trình chiếu: hai cách để giữ khung đối tượng nhất quán—thu phóng khung hoặc trang tính—trong các định dạng PPT và PPTX."
---
{{% alert color="info" title="Note" %}}
Các bảng tính Excel được nhúng dưới dạng đối tượng OLE trong bản trình chiếu PowerPoint bằng các thành phần Aspose có thể thay đổi kích thước một cách không mong muốn sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt rõ rệt về hình ảnh giữa đối tượng OLE trước và sau khi kích hoạt. Bài viết này giải thích vấn đề và mô tả hai cách khắc phục.
{{% /alert %}}

## **Bối cảnh**

Trong bài viết [Quản lý OLE](/slides/vi/androidjava/manage-ole/), chúng tôi đã giải thích cách thêm khung OLE vào bản trình chiếu PowerPoint bằng Aspose.Slides cho Android thông qua Java. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/androidjava/object-preview-issue-when-adding-oleobjectframe/), chúng tôi đã gán một hình ảnh của khu vực worksheet đã chọn cho khung đối tượng OLE. Trong bản trình chiếu đầu ra, khi bạn nhấp đúp vào khung OLE hiển thị hình ảnh worksheet, workbook Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn trên workbook Excel thực tế và sau đó quay lại slide bằng cách nhấp ra ngoài workbook Excel đã kích hoạt. Kích thước khung OLE sẽ thay đổi khi người dùng quay lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy vào kích thước của khung OLE và workbook Excel được nhúng.

## **Nguyên nhân của việc thay đổi kích thước**

Vì workbook Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước gốc khi kích hoạt lần đầu. Mặt khác, khung đối tượng OLE có kích thước của riêng nó. Theo Microsoft, khi workbook Excel được kích hoạt, Excel và PowerPoint sẽ thương lượng kích thước để đảm bảo duy trì tỷ lệ đúng như một phần của quá trình nhúng. Việc thay đổi kích thước xảy ra dựa trên sự khác biệt giữa kích thước cửa sổ Excel và kích thước và vị trí của khung đối tượng OLE.

## **Giải pháp hoạt động**

Có hai giải pháp khả thi để tránh hiệu ứng thay đổi kích thước.

- Thu phóng khung OLE trong bản trình chiếu PowerPoint để khớp với tổng chiều cao và chiều rộng của các hàng và cột được chọn.
- Giữ kích thước khung OLE cố định và thu phóng các hàng và cột đã chọn để vừa vào trong đó.

### **Thu phóng Kích thước Khung OLE**

Cách tiếp cận này đặt kích thước khung OLE sao cho khớp với tổng chiều cao và chiều rộng của các hàng và cột được chọn trong bảng tính Excel được nhúng.

Ví dụ tải một workbook Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của worksheet đầu tiên bằng chỉ số bắt đầu từ 0. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) định nghĩa phạm vi hiển thị. Bản xem trước được vẽ ở 96 DPI, và kích thước pixel của nó được chuyển đổi sang điểm bằng cách sử dụng 72 điểm mỗi inch. [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) nhúng workbook đã sửa đổi vào một khung với các kích thước đó. Bản xem trước được gán thông qua [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) để thay thế chỗ giữ chỗ "EMBEDDED OLE OBJECT" trong bản trình chiếu đã lưu.

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

// Lấy độ rộng và độ cao của hình ảnh OLE tính bằng điểm.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// Chúng ta cần sử dụng workbook đã được sửa đổi.
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

Trợ giúp xem trước thiết lập [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) cho phạm vi đã chọn và loại bỏ lề, tiêu đề và chân trang. Khi [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) được bật, [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) vẽ phạm vi thành hình ảnh PNG. Trợ giúp trả về một luồng nhập mới chứa hình ảnh PNG, được đặt ở đầu để sử dụng trong bản trình chiếu.

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

### **Thu phóng Kích thước Phạm vi Ô**

Cách tiếp cận này thu phóng chiều cao của các hàng đã chọn và chiều rộng của các cột đã chọn để khớp với kích thước khung OLE tùy chỉnh.

Ví dụ tải một workbook Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của worksheet đầu tiên bằng chỉ số bắt đầu từ 0. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) định nghĩa phạm vi hiển thị, và trợ giúp dưới đây thu phóng phạm vi đó để vừa với một khung rộng 400 điểm và cao 100 điểm. Sau khi lưu workbook đã sửa đổi vào một luồng, [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) nhúng nó ở kích thước đã chỉ định. Một bản xem trước được vẽ ở 96 DPI được gán thông qua [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--), vì vậy bản trình chiếu đã lưu hiển thị các ô đã chọn thay vì chỗ giữ chỗ mặc định.

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

// Thu phóng phạm vi ô để vừa với kích thước khung.
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Chúng ta cần sử dụng workbook đã được sửa đổi.
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

Trợ giúp thu phóng tính toán các tỷ lệ chiều rộng và chiều cao riêng biệt cho phạm vi đã chọn, giữ nguyên tỉ lệ chiều rộng tương đối của các cột và chiều cao tương đối của các hàng. Nó chuyển đổi các kích thước đã tính từ điểm sang inch trước khi áp dụng chúng bằng [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) và [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-). Phạm vi đã chọn phải có chiều rộng và chiều cao khác 0.

```java
/**
 * @param width     Độ rộng mong đợi của phạm vi ô tính bằng điểm.
 * @param height    Độ cao mong đợi của phạm vi ô tính bằng điểm.
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

Trợ giúp xem trước này vẽ lại phạm vi đã thay đổi kích thước bằng [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-). Nó giới hạn [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) cho phạm vi đó, loại bỏ lề, tiêu đề và chân trang, và trả về một luồng PNG được đặt ở đầu.

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
Có hai cách để khắc phục vấn đề thay đổi kích thước bảng tính. Chọn cách phù hợp nhất với yêu cầu và trường hợp sử dụng của bạn. Cả hai cách đều hoạt động giống nhau, bất kể bản trình chiếu được tạo từ mẫu hay từ đầu. Ngoài ra, không có giới hạn nào về kích thước khung đối tượng OLE trong giải pháp này.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tại sao một bảng tính Excel được nhúng lại thay đổi kích thước khi lần đầu tiên kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng giữ kích thước cửa sổ gốc khi được kích hoạt, trong khi khung đối tượng OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel thương lượng kích thước để duy trì tỷ lệ, điều này có thể gây ra việc thay đổi kích thước.

**Có thể ngăn hoàn toàn vấn đề thay đổi kích thước này không?**

Có. Bằng cách thu phóng khung OLE để vừa với kích thước phạm vi ô Excel hoặc thu phóng phạm vi ô để vừa với kích thước khung OLE mong muốn, bạn có thể ngăn chặn việc thay đổi kích thước không mong muốn.

**Tôi nên sử dụng phương pháp thu phóng nào, thu phóng khung OLE hay thu phóng phạm vi ô?**

Chọn **thu phóng khung OLE** nếu bạn muốn duy trì kích thước hàng và cột gốc của Excel. Chọn **thu phóng phạm vi ô** nếu bạn muốn khung OLE có kích thước cố định trong bản trình chiếu của mình.

**Các giải pháp này có hoạt động nếu bản trình chiếu của tôi dựa trên một mẫu không?**

Có. Cả hai giải pháp đều hoạt động cho các bản trình chiếu được tạo từ mẫu và từ đầu.

**Có giới hạn nào về kích thước khung OLE khi sử dụng các phương pháp này không?**

Không. Bạn có thể đặt khung đối tượng OLE ở bất kỳ kích thước nào miễn là bạn thiết lập tỉ lệ một cách phù hợp.

**Có cách nào để tránh văn bản chỗ giữ chỗ "EMBEDDED OLE OBJECT" trong PowerPoint không?**

Có. Bằng cách chụp ảnh nhanh phạm vi ô Excel mục tiêu và đặt nó làm hình ảnh chỗ giữ chỗ cho khung OLE, bạn có thể hiển thị một hình ảnh xem trước tùy chỉnh thay cho chỗ giữ chỗ mặc định.

## **Các bài viết liên quan**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/vi/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/vi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)