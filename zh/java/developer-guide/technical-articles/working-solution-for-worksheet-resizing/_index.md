---
title: 工作表大小调整的可行解决方案
type: docs
weight: 20
url: /zh/java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 预览图像
- 图像大小调整
- Excel
- 工作表
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "在演示文稿中修复 Excel 工作表 OLE 大小调整：通过两种方式保持对象框一致——缩放框架或工作表——适用于 PPT 和 PPTX 格式。"
---
{{% alert color="info" %}}
已观察到，通过 Aspose 组件将 Excel 工作表作为 OLE 对象嵌入 PowerPoint 演示文稿后，在首次激活后会被缩放到未知比例。此行为导致 OLE 对象的激活前后在演示文稿中出现明显的视觉差异。我们已对该问题进行了详细调查并提供了解决方案，本文介绍了该方案。
{{% /alert %}}

## **背景**

在文章[管理 OLE](/slides/zh/java/manage-ole/)中，我们介绍了如何使用 Aspose.Slides for Java 向 PowerPoint 演示文稿添加 OLE 框。为了解决[对象预览问题](/slides/zh/java/object-preview-issue-when-adding-oleobjectframe/)，我们为 OLE 对象框分配了所选工作表区域的图像。在输出的演示文稿中，双击显示工作表图像的 OLE 对象框时，会激活 Excel 工作簿。最终用户可以对实际的 Excel 工作簿进行任意更改，然后点击激活的 Excel 工作簿之外的区域返回幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化。缩放比例取决于 OLE 对象框的尺寸和嵌入的 Excel 工作簿的尺寸。

## **导致大小调整的原因**

由于 Excel 工作簿有其自身的窗口尺寸，在首次激活时会尝试保留原始大小。另一方面，OLE 对象框也有自己的尺寸。根据 Microsoft 的说明，当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商尺寸，以确保在嵌入过程中保持正确的比例。大小调整是基于 Excel 窗口尺寸与 OLE 对象框尺寸和位置之间的差异产生的。

## **可行的解决方案**

有两种可能的解决方案可以避免大小调整效果。

- 将 PowerPoint 演示文稿中的 OLE 框尺寸缩放到与 OLE 框中所需行列的高度和宽度相匹配。
- 保持 OLE 框尺寸不变，并缩放参与的行列大小，使其适应选定的 OLE 框尺寸。

### **缩放 OLE 框大小**

在此方法中，我们将学习如何设置嵌入的 Excel 工作簿的 OLE 框大小，以匹配工作表中参与行列的累计尺寸。

假设我们有一个模板 Excel 工作表，并希望将其作为 OLE 框添加到演示文稿中。在此情形下，OLE 对象框的尺寸首先根据工作簿中参与行列的累计行高和列宽进行计算。然后，我们将 OLE 框的尺寸设置为该计算值。为避免 PowerPoint 中 OLE 框出现红色“EMBEDDED OLE OBJECT”提示，我们还将捕获工作簿中所需行列的图像，并将其设置为 OLE 框的图像。

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

// 当工作簿文件在 PowerPoint 中作为 OLE 对象使用时，设置显示尺寸。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// 获取 OLE 图像的宽度和高度（单位：点）。
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

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
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```

### **缩放单元格范围大小**

在此方法中，我们将学习如何缩放参与的行高和列宽，以匹配自定义的 OLE 框尺寸。

假设我们有一个模板 Excel 工作表，并希望将其作为 OLE 框添加到演示文稿中。在此情形下，我们将设置 OLE 框的尺寸，并缩放参与 OLE 框区域的行列大小。随后将工作簿保存到流中以应用更改，并将其转换为字节数组以添加到 OLE 框中。为避免 PowerPoint 中 OLE 框出现红色“EMBEDDED OLE OBJECT”提示，我们还将捕获工作簿中所需行列的图像，并将其设置为 OLE 框的图像。

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

// 当工作簿文件在 PowerPoint 中作为 OLE 对象使用时，设置显示尺寸。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// 缩放单元格范围以适应框架尺寸。
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
 * @param width     单元格范围的预期宽度（单位：点）。
 * @param height    单元格范围的预期高度（单位：点）。
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

## **结论**
{{% alert color="info" %}} 
有两种方法可以解决工作表大小调整问题。选择适当的方法取决于具体需求和使用场景。无论演示文稿是基于模板还是从头创建，两种方法的工作方式相同。此外，此方案对 OLE 对象框的尺寸没有限制。
{{% /alert %}}

## **常见问题**

### 为什么嵌入的 Excel 工作表在 PowerPoint 中首次激活时会改变大小？

因为 Excel 在激活时尝试保持原始窗口大小，而 PowerPoint 中的 OLE 对象框有其自身的尺寸。PowerPoint 与 Excel 会协商尺寸以保持宽高比，从而导致大小调整。

### 能否完全防止此大小调整问题？

可以。通过将 OLE 框缩放至匹配 Excel 单元格范围大小，或将单元格范围缩放至匹配所需的 OLE 框尺寸，均可防止不必要的大小调整。

### 应该使用哪种缩放方法，OLE 框缩放还是单元格范围缩放？

如果希望保持原始的 Excel 行列尺寸，请选择**OLE 框缩放**。如果希望在演示文稿中获得固定的 OLE 框尺寸，请选择**单元格范围缩放**。

### 如果我的演示文稿是基于模板创建的，这些解决方案仍然有效吗？

有效。两种解决方案均适用于基于模板创建的演示文稿以及从头创建的演示文稿。

### 使用这些方法时 OLE 框的尺寸是否有限制？

没有。只要适当地设置缩放比例，OLE 对象框可以任意大小。

### 如何避免 PowerPoint 中出现“EMBEDDED OLE OBJECT”占位文本？

可以通过对目标 Excel 单元格范围进行快照，并将其设置为 OLE 框的占位图像，从而在默认占位符位置显示自定义预览图像。

## **相关文档**

[在演示文稿中创建 Excel 图表并将其嵌入为 OLE 对象](/slides/zh/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[使用 MS PowerPoint 加载项自动更新 OLE 对象](/slides/zh/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)