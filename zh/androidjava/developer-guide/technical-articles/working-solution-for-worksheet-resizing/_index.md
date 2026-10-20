---
title: 工作表大小调整的可行解决方案
type: docs
weight: 20
url: /zh/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- 预览图像
- 图像大小调整
- Excel
- 工作表
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在演示文稿中修复 Excel 工作表 OLE 大小调整：提供两种保持对象框一致的方法——缩放框架或缩放工作表——适用于 PPT 和 PPTX 格式。"
---
{{% alert color="info" title="Note" %}}

将 Excel 工作表作为 OLE 对象嵌入 PowerPoint 演示文稿时，使用 Aspose 组件可能在第一次激活后出现意外的大小调整。此行为会导致 OLE 对象在激活前后出现明显的视觉差异。本文阐述了该问题并提供两种解决方案。

{{% /alert %}}

## **背景**

在文章 [管理 OLE](/slides/zh/androidjava/manage-ole/) 中，我们说明了如何使用 Aspose.Slides for Android via Java 向 PowerPoint 演示文稿添加 OLE 框。为了解决 [对象预览问题](/slides/zh/androidjava/object-preview-issue-when-adding-oleobjectframe/)，我们为 OLE 对象框分配了所选工作表区域的图像。在输出的演示文稿中，双击显示工作表图像的 OLE 对象框时，将激活 Excel 工作簿。最终用户可以对实际的 Excel 工作簿进行任意更改，然后单击激活的 Excel 工作簿外部返回幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化。调整大小的比例取决于 OLE 对象框和嵌入的 Excel 工作簿的大小。

## **调整大小的原因**

由于 Excel 工作簿拥有自己的窗口大小，它会在首次激活时尝试保持原始大小。另一方面，OLE 对象框也有自己的尺寸。根据 Microsoft 的说法，当 Excel 工作簿被激活时，Excel 与 PowerPoint 会协商尺寸，以确保在嵌入过程中保持正确的比例。大小调整基于 Excel 窗口尺寸与 OLE 对象框尺寸及位置之间的差异而产生。

## **可行的解决方案**

有两种可能的方案可以避免大小调整效果。

- 将 PowerPoint 演示文稿中的 OLE 框缩放至与选定行列的总高度和宽度匹配。
- 保持 OLE 框尺寸不变，并将选定的行列缩放以适应框内。

### **缩放 OLE 框大小**

此方法将 OLE 框的大小设置为与嵌入的 Excel 工作表中选定行列的总高度和宽度相匹配。

示例加载现有 Excel 工作簿，并使用零基索引选择其首个工作表的前 10 行和 13 列。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) 定义显示范围。预览以 96 DPI 渲染，其像素尺寸通过每英寸 72 点转换为点数。[IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) 使用这些尺寸将修改后的工作簿嵌入框中。通过 [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) 将预览分配给已保存演示文稿中的 “EMBEDDED OLE OBJECT” 占位符。

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

// 在 PowerPoint 中将工作簿文件用作 OLE 对象时设置显示尺寸。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// We need to use the modified workbook.
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Add the OLE image to the presentation resources.
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// Create the OLE object frame.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

预览帮助程序将 [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) 设置为选定范围，并移除页边距、页眉和页脚。启用 [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) 后，使用 [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) 将范围渲染为 PNG 图像。该帮助程序返回一个新输入流，包含 PNG 图像并定位在流首位，以供演示文稿使用。

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

此方法将选定行的高度和选定列的宽度缩放至匹配自定义 OLE 框大小。

示例加载现有 Excel 工作簿，并使用零基索引选择其首个工作表的前 10 行和 13 列。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) 定义显示范围，下面的帮助程序将该范围缩放至宽 400 点、高 100 点的框中。将修改后的工作簿保存到流后，使用 [IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) 按指定尺寸嵌入。通过 [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) 分配在 96 DPI 渲染的预览，使已保存的演示文稿显示选定单元格而非默认占位符。

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

// 在 PowerPoint 中将工作簿文件用作 OLE 对象时设置显示尺寸。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// 将单元格范围缩放以适应框架大小。
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// 我们需要使用修改后的工作簿。
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

缩放帮助程序为选定范围计算宽度和高度比率，保留列的相对宽度和行的相对高度。它在将计算得到的尺寸从点转换为英寸后，使用 [Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) 和 [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-) 应用这些尺寸。选定范围的宽度和高度必须均为非零。

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

此预览帮助程序使用 [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) 渲染已调整大小的范围。它将 [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) 限定为该范围，去除页边距、页眉和页脚，并返回定位在流首位的 PNG 流。

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

{{% alert color="info" title="Note" %}}

有两种方法可以解决工作表大小调整问题。请选择最符合您需求和使用场景的方法。无论演示文稿是基于模板创建还是从零开始，两种方法的实现方式相同。此外，此方案对 OLE 对象框的大小没有限制。

{{% /alert %}}

## **常见问题**

**为什么嵌入的 Excel 工作表在 PowerPoint 中首次激活时会改变大小？**

因为 Excel 在激活时尝试保持原始窗口大小，而 PowerPoint 中的 OLE 对象框拥有自己的尺寸。PowerPoint 与 Excel 会协商尺寸以保持长宽比，从而导致大小调整。

**是否可以完全防止此大小调整问题？**

可以。通过将 OLE 框缩放至匹配 Excel 单元格范围的大小，或将单元格范围缩放至匹配所需的 OLE 框大小，均可避免不想要的大小调整。

**我应该使用哪种缩放方式，OLE 框缩放还是单元格范围缩放？**

如果希望保留 Excel 行列的原始尺寸，请选择 **OLE 框缩放**。如果希望在演示文稿中获得固定的 OLE 框尺寸，请选择 **单元格范围缩放**。

**这些解决方案在基于模板的演示文稿中也有效吗？**

有效。两种方案均适用于基于模板创建的演示文稿以及从头创建的演示文稿。

**使用这些方法时 OLE 框的大小是否有限制？**

没有。只要按比例设置即可将 OLE 对象框设为任意大小。

**是否有办法避免 PowerPoint 中的 “EMBEDDED OLE OBJECT” 占位符文本？**

可以。通过对目标 Excel 单元格范围进行快照并将其设置为 OLE 框的占位符图像，您可以在默认占位符位置显示自定义预览图像。

## **相关文章**

[创建 Excel 图表并将其作为 OLE 对象嵌入演示文稿](/slides/zh/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[使用 MS PowerPoint 加载项自动更新 OLE 对象](/slides/zh/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)