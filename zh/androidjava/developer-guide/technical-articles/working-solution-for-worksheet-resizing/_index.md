---
title: 工作表缩放的可行解决方案
type: docs
weight: 20
url: /zh/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 预览图像
- 图像缩放
- Excel
- 工作表
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在演示文稿中修复 Excel 工作表 OLE 缩放问题：提供两种方法保持对象框一致——缩放框架或缩放工作表——适用于 PPT 和 PPTX 格式。"
---
{{% alert color="info" %}}
已观察到，通过 Aspose 组件将 Excel 工作表作为 OLE 对象嵌入 PowerPoint 演示文稿后，在第一次激活后会被缩放到未知比例。这会导致 OLE 对象在激活前后的外观出现明显差异。我们对该问题进行了深入分析并提供了解决方案，本文对此进行说明。
{{% /alert %}}

## **Background**
在文章[管理 OLE](/slides/zh/androidjava/manage-ole/)中，我们说明了如何使用 Aspose.Slides for Android via Java 向 PowerPoint 演示文稿添加 OLE 框。为了解决[对象预览问题](/slides/zh/androidjava/object-preview-issue-when-adding-oleobjectframe/)，我们为 OLE 对象框分配了所选工作表区域的图像。在生成的演示文稿中，双击显示工作表图像的 OLE 对象框会激活 Excel 工作簿。最终用户可以对实际的 Excel 工作簿进行任意修改，然后点击激活的 Excel 工作簿之外的区域返回幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化。缩放比例取决于 OLE 对象框的尺寸以及嵌入的 Excel 工作簿的尺寸。

## **Cause of Resizing**
由于 Excel 工作簿拥有自己的窗口大小，它会尝试在首次激活时保留原始尺寸。另一方面，OLE 对象框也有自己的尺寸。根据 Microsoft 的说明，Excel 工作簿激活时，Excel 与 PowerPoint 会协商尺寸，以确保在嵌入过程中保持正确的比例。缩放发生在 Excel 窗口大小与 OLE 对象框的大小及位置之间的差异基础上。

## **Working Solution**
有两种可能的解决方案可以避免缩放效果。

- 将 PowerPoint 演示文稿中的 OLE 框尺寸缩放至与 OLE 框中所需的行数和列数的高度宽度匹配。
- 保持 OLE 框尺寸不变，缩放参与的行列尺寸以适配选定的 OLE 框尺寸。

### **Scale the OLE Frame Size**
在此方法中，我们将学习如何将嵌入的 Excel 工作簿的 OLE 框尺寸设置为与 Excel 工作表中参与的行高和列宽的累计尺寸相匹配。

假设我们有一个模板 Excel 表，需要将其作为 OLE 框添加到演示文稿中。此情况下，OLE 对象框的尺寸将首先根据工作簿中参与行的累计行高和参与列的累计列宽进行计算。然后，我们将 OLE 框的尺寸设置为该计算值。为避免 PowerPoint 中 OLE 框显示红色“EMBEDDED OLE OBJECT”提示，我们还会捕获工作簿中所需行列的图像并将其设为 OLE 框的图像。

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

// 设置工作簿文件作为 PowerPoint 中 OLE 对象使用时的显示尺寸。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// 获取 OLE 图像的宽度和高度（单位为点）。
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// 我们需要使用已修改的工作簿。
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 将 OLE 图像添加到演示文稿资源中。
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// 创建 OLE 对象框。
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
    imageOptions.setOnlyArea(true;

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **Scale the Cell Range Size**
在此方法中，我们将学习如何将参与行的高度和参与列的宽度缩放至匹配自定义 OLE 框尺寸。

假设我们有一个模板 Excel 表，需要将其作为 OLE 框添加到演示文稿中。此情况下，我们将设置 OLE 框的尺寸，并缩放参与 OLE 框区域的行列尺寸。随后将工作簿保存到流中以应用更改，并将其转换为字节数组以添加到 OLE 框中。为避免 PowerPoint 中 OLE 框显示红色“EMBEDDED OLE OBJECT”提示，我们同样会捕获工作簿中所需行列的图像并将其设为 OLE 框的图像。

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

// 设置工作簿文件作为 PowerPoint 中 OLE 对象使用时的显示尺寸。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// 缩放单元格范围以适配框架尺寸。
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// 我们需要使用已修改的工作簿。
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// 将 OLE 图像添加到演示文稿资源中。
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// 创建 OLE 对象框。
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
 * @param width     单元格范围的预期宽度（单位为点）。
 * @param height    单元格范围的预期高度（单位为点）。
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

## **Conclusion**
{{% alert color="info" %}} 
有两种方法可以解决工作表缩放问题。选择合适的方法取决于具体需求和使用场景。无论演示文稿是基于模板创建还是从零创建，这两种方法都可行。此外，此方案对 OLE 对象框的尺寸没有限制。
{{% /alert %}}

## **FAQ**

### 为什么嵌入的 Excel 工作表在 PowerPoint 中首次激活时会改变大小？
因为 Excel 在激活时尝试保持原始窗口尺寸，而 PowerPoint 中的 OLE 对象框有自己的尺寸。PowerPoint 与 Excel 会协商尺寸以保持纵横比，从而导致缩放。

### 能否彻底防止此缩放问题？
可以。通过将 OLE 框缩放至匹配 Excel 单元格范围尺寸，或将单元格范围缩放至匹配所需的 OLE 框尺寸，可防止不希望的缩放。

### 应该使用哪种缩放方式：OLE 框缩放还是单元格范围缩放？
如果希望保持原始的 Excel 行列尺寸，请选择 **OLE 框缩放**。如果希望在演示文稿中拥有固定的 OLE 框尺寸，请选择 **单元格范围缩放**。

### 如果演示文稿基于模板，这些解决方案还能使用吗？
可以。两种解决方案均适用于基于模板创建的演示文稿以及从头创建的演示文稿。

### 使用这些方法时 OLE 框的尺寸是否有限制？
没有限制。只要适当设置缩放比例，OLE 对象框可以任意大小。

### 如何避免 PowerPoint 中显示“EMBEDDED OLE OBJECT”占位文字？
可以通过对目标 Excel 单元格范围进行快照，并将其设置为 OLE 框的占位图像，从而显示自定义预览图像，取代默认占位文字。