---
title: Giải pháp thực tế cho việc thay đổi kích thước trang tính
type: docs
weight: 20
url: /vi/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
  - OLE
  - hình ảnh xem trước
  - thay đổi kích thước hình ảnh
  - Excel
  - trang tính
  - PowerPoint
  - bản trình chiếu
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Sửa lỗi thay đổi kích thước OLE của trang tính Excel trong bản trình chiếu: hai cách để giữ khung đối tượng đồng nhất—điều chỉnh kích thước khung hoặc trang tính—trong các định dạng PPT và PPTX."
---
{{% alert color="info" title="Note" %}}
Các trang tính Excel được nhúng dưới dạng đối tượng OLE trong bản trình chiếu PowerPoint bằng các thành phần Aspose có thể thay đổi kích thước một cách không mong muốn sau lần kích hoạt đầu tiên. Hành vi này tạo ra sự khác biệt trực quan đáng chú ý giữa đối tượng OLE trước và sau khi kích hoạt. Bài viết này giải thích vấn đề và mô tả hai cách khắc phục.
{{% /alert %}}

## **Bối cảnh**

Trong bài viết [Quản lý OLE](/slides/vi/nodejs-java/manage-ole/), chúng tôi đã giải thích cách thêm khung OLE vào bản trình chiếu PowerPoint bằng Aspose.Slides for Node.js via Java. Để giải quyết [vấn đề xem trước đối tượng](/slides/vi/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), chúng tôi gán một hình ảnh của khu vực trang tính được chọn cho khung đối tượng OLE. Trong bản trình chiếu đầu ra, khi bạn nhấp đúp vào khung OLE hiển thị hình ảnh trang tính, sổ làm việc Excel sẽ được kích hoạt. Người dùng cuối có thể thực hiện bất kỳ thay đổi nào mong muốn trên sổ làm việc Excel thực tế và sau đó quay lại slide bằng cách nhấp ra ngoài sổ Excel đã kích hoạt. Kích thước của khung OLE sẽ thay đổi khi người dùng quay lại slide. Hệ số thay đổi kích thước sẽ khác nhau tùy thuộc vào kích thước của khung OLE và sổ Excel được nhúng.

## **Nguyên nhân của việc thay đổi kích thước**

Vì sổ làm việc Excel có kích thước cửa sổ riêng, nó cố gắng giữ nguyên kích thước ban đầu khi được kích hoạt lần đầu. Ngược lại, khung đối tượng OLE có kích thước riêng. Theo Microsoft, khi sổ làm việc Excel được kích hoạt, Excel và PowerPoint sẽ đàm phán kích thước để đảm bảo duy trì tỷ lệ đúng như một phần của quá trình nhúng. Việc thay đổi kích thước xảy ra dựa trên sự khác biệt giữa kích thước cửa sổ Excel và kích thước cùng vị trí của khung OLE.

## **Giải pháp**

Có hai giải pháp khả thi để tránh hiệu ứng thay đổi kích thước.

- Điều chỉnh khung OLE trong bản trình chiếu PowerPoint sao cho khớp với tổng chiều cao và chiều rộng của các hàng và cột đã chọn.
- Giữ kích thước khung OLE cố định và điều chỉnh các hàng và cột đã chọn để vừa khít trong khung.

### **Điều chỉnh kích thước khung OLE**

Cách tiếp cận này đặt kích thước khung OLE sao cho khớp với tổng chiều cao và chiều rộng của các hàng và cột đã chọn trong trang tính Excel được nhúng.

Ví dụ tải một sổ Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của trang tính đầu tiên bằng chỉ mục bắt đầu từ 0. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) xác định phạm vi hiển thị. Bản xem trước được render ở 96 DPI, và kích thước pixel của nó được chuyển đổi sang điểm bằng 72 điểm mỗi inch. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) nhúng sổ đã chỉnh sửa vào một khung có kích thước đó. Bản xem trước được gán qua [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) để thay thế chỗ giữ chỗ "EMBEDDED OLE OBJECT" trong bản trình chiếu đã lưu.

Cài đặt các gói `aspose.cells`, `aspose.slides.via.java` và `java` và đặt `sample.xlsx` trong thư mục làm việc. Đối với mỗi cách tiếp cận, chạy script chuẩn bị trước, sau đó chạy script nhúng trong một tiến trình Node.js riêng trong cùng thư mục. Hai gói Aspose khởi tạo cầu nối Java riêng biệt.

Lưu script chuẩn bị này thành `prepare-frame-scaled.js` và chạy bằng `node prepare-frame-scaled.js`. Nó sẽ ghi `frame-scaled.xlsx` và `frame-scaled.png`.

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// Tất cả công việc đồng bộ đã hoàn thành; dừng tiến trình cầu nối Java.
process.exit(0);
```

Lưu script nhúng này thành `embed-frame-scaled.js` và chạy bằng `node embed-frame-scaled.js`. Nó sẽ đọc các file đó và ghi `frame-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// Tất cả công việc đồng bộ đã hoàn thành; dừng tiến trình cầu nối Java.
process.exit(0);
```

Trợ giúp xem trước thiết lập [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) cho phạm vi đã chọn và loại bỏ lề, đầu trang và chân trang. Khi bật [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea), [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) sẽ render phạm vi dưới dạng ảnh PNG. Trợ giúp lưu ảnh PNG vào file để sử dụng trong bản trình chiếu.

### **Điều chỉnh kích thước phạm vi ô**

Cách tiếp cận này điều chỉnh chiều cao của các hàng đã chọn và chiều rộng của các cột đã chọn để khớp với kích thước khung OLE tùy chỉnh.

Ví dụ tải một sổ Excel hiện có và chọn 10 hàng đầu tiên và 13 cột đầu tiên của trang tính đầu tiên bằng chỉ mục bắt đầu từ 0. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) xác định phạm vi hiển thị, và trợ giúp điều chỉnh phạm vi đó để vừa khít một khung rộng 400 điểm và cao 100 điểm. Sau khi lưu sổ đã chỉnh sửa vào file, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) nhúng nó với kích thước đã chỉ định. Bản xem trước được render ở 96 DPI và được gán qua [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), vì vậy bản trình chiếu đã lưu hiển thị các ô đã chọn thay vì chỗ giữ chỗ mặc định.

Lưu script chuẩn bị này thành `prepare-cells-scaled.js` và chạy bằng `node prepare-cells-scaled.js`. Nó sẽ ghi `cells-scaled.xlsx` và `cells-scaled.png`.

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// Tất cả công việc đồng bộ đã hoàn thành; dừng tiến trình cầu nối Java.
process.exit(cellsPrepared ? 0 : 1);
```

Lưu script nhúng này thành `embed-cells-scaled.js` và chạy bằng `node embed-cells-scaled.js`. Nó sẽ đọc các file đó và ghi `cells-scaled.pptx`.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// Tất cả công việc đồng bộ đã hoàn thành; dừng tiến trình cầu nối Java.
process.exit(0);
```

Trợ giúp scaling tính toán các tỷ lệ chiều rộng và chiều cao riêng cho phạm vi đã chọn, duy trì tỷ lệ tương đối của các cột và hàng. Nó chuyển đổi các kích thước tính được từ điểm sang inch trước khi áp dụng chúng bằng [Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) và [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch). Phạm vi đã chọn phải có chiều rộng và chiều cao khác không.

Trợ giúp xem trước này render phạm vi đã thay đổi kích thước bằng [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage). Nó giới hạn [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) cho phạm vi đó, loại bỏ lề, đầu trang và chân trang, và lưu ảnh PNG vào file.

## **Kết luận**

{{% alert color="info" title="Note" %}}
Có hai cách tiếp cận để khắc phục vấn đề thay đổi kích thước trang tính. Chọn cách tiếp cận phù hợp nhất với yêu cầu và trường hợp sử dụng của bạn. Cả hai cách đều hoạt động giống nhau, bất kể bản trình chiếu được tạo từ mẫu hay từ đầu. Ngoài ra, không có giới hạn nào về kích thước khung OLE trong giải pháp này.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Tại sao một trang tính Excel được nhúng lại thay đổi kích thước khi lần đầu tiên kích hoạt trong PowerPoint?**

Điều này xảy ra vì Excel cố gắng duy trì kích thước cửa sổ gốc khi được kích hoạt, trong khi khung OLE trong PowerPoint có kích thước riêng. PowerPoint và Excel sẽ đàm phán để duy trì tỷ lệ aspect, điều này có thể gây ra việc thay đổi kích thước.

**Liệu có thể ngăn hoàn toàn vấn đề thay đổi kích thước này không?**

Có. Bằng cách điều chỉnh khung OLE để phù hợp với kích thước phạm vi ô Excel hoặc điều chỉnh phạm vi ô để phù hợp với kích thước khung OLE mong muốn, bạn có thể ngăn ngừa việc thay đổi kích thước không mong muốn.

**Nên dùng phương pháp scaling nào, scaling khung OLE hay scaling phạm vi ô?**

Chọn **scaling khung OLE** nếu bạn muốn giữ nguyên kích thước hàng và cột Excel gốc. Chọn **scaling phạm vi ô** nếu bạn muốn khung OLE có kích thước cố định trong bản trình chiếu.

**Các giải pháp này có hoạt động nếu bản trình chiếu của tôi dựa trên mẫu không?**

Có. Cả hai giải pháp đều hoạt động cho các bản trình chiếu được tạo từ mẫu và từ đầu.

**Có giới hạn nào về kích thước khung OLE khi sử dụng các phương pháp này không?**

Không. Bạn có thể đặt khung OLE ở bất kỳ kích thước nào miễn là bạn thiết lập tỷ lệ phù hợp.

**Có cách nào tránh văn bản chỗ giữ chỗ "EMBEDDED OLE OBJECT" trong PowerPoint không?**

Có. Bằng cách chụp ảnh phạm vi ô Excel mục tiêu và đặt nó làm ảnh chỗ giữ chỗ cho khung OLE, bạn có thể hiển thị ảnh xem trước tùy chỉnh thay cho chỗ giữ chỗ mặc định.

## **Bài viết liên quan**

[​Tạo biểu đồ Excel và nhúng nó vào bản trình chiếu dưới dạng OLE Object](/slides/vi/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[​Cập nhật OLE Objects tự động bằng Add‑In PowerPoint của MS](/slides/vi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)