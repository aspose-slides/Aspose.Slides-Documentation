---
title: 在 Android 上管理簡報表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh-hant/androidjava/manage-table/
keywords:
- 新增表格
- 建立表格
- 存取表格
- 長寬比
- 對齊文字
- 文字格式化
- 表格樣式
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 PowerPoint 投影片中建立與編輯表格。探索簡單的 Java 程式碼範例，以簡化您的表格工作流程。"
---
## **簡介**

PowerPoint 中的表格是顯示和呈現資訊的有效方式。以行與列排列的儲存格格子中的資訊直觀且易於理解。

Aspose.Slides 提供 [Table](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Table) 類別、[ITable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITable) 介面、[Cell](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/cell/) 類別、[ICell](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icell/) 介面，以及其他類型，以便您在各種簡報中建立、更新和管理表格。

## **從頭建立表格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 定義 `columnWidth` 陣列。  
4. 定義 `rowHeight` 陣列。  
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) 方法將 [ITable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITable) 物件新增至投影片。  
6. 遍歷每個 [ICell](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icell/) 以套用上、下、右、左邊框的格式設定。  
7. 合併表格第一列的前兩個儲存格。  
8. 存取 [ICell](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icell) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframe/)。  
9. 向 [TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframe/) 中加入文字。  
10. 儲存已修改的簡報。

以下 Java 程式碼示範如何在簡報中建立表格：

```java
// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 存取第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定義欄寬與列高
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // 在投影片上加入表格形狀
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 設定每個儲存格的邊框格式
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // 合併第1行的第1與第2個儲存格
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // 在合併的儲存格中加入文字
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // 將簡報儲存至磁碟
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **標準表格中的編號**

在標準表格中，儲存格的編號方式簡單且以 0 為起點。表格的第一個儲存格編號為 0,0（第 0 欄，第 0 行）。

例如，具有 4 欄 4 行的表格，其儲存格編號如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下 Java 程式碼示範如何為表格中的儲存格指定編號：

```java
// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 存取第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定義欄寬與列高
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // 在投影片上加入表格形狀
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 為每個儲存格設定邊框格式
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // 將簡報儲存至磁碟
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **存取現有的表格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。  
2. 透過索引取得包含表格的投影片參考。  
3. 建立 [ITable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITable) 物件並將其設為 null。  
4. 遍歷所有 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 物件，直到找到表格。  
   如果您懷疑目前的投影片只有一個表格，您可以直接檢查其所有形狀。當形狀被辨識為表格時，您可以將其類型轉換為 [Table](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Table) 物件。但如果投影片包含多個表格，則最好透過其 [setAlternativeText(String value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) 來搜尋所需的表格。  
5. 使用 [ITable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITable) 物件來操作表格。以下範例中，我們向表格新增了一列。  
6. 儲存已修改的簡報。

以下 Java 程式碼示範如何存取並操作現有的表格：

```java
// 實例化代表 PPTX 檔案的 Presentation 類別
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // 存取第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 初始化為 null 的 TableEx
    ITable tbl = null;

    // 遍歷形狀並設定對找到的表格的參考
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // 設定第二行第一欄的文字
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // 將修改後的簡報儲存至磁碟
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **對齊表格內文字**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 將 [ITable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITable) 物件新增至投影片。  
4. 從表格存取 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 物件。  
5. 存取 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/) 的 [IParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraph/)。  
6. 垂直對齊文字。  
7. 儲存已修改的簡報。

以下 Java 程式碼示範如何對齊表格內的文字：

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    // 取得第一張投影片 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 定義欄寬與列高
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // 將表格形狀加入投影片
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // 取得文字框
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // 為文字框建立 Paragraph 物件
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // 為段落建立 Portion 物件
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // 垂直對齊文字
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // 將簡報儲存至磁碟
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在表格層級設定文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 從投影片存取 [ITable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITable) 物件。  
4. 設定文字的 [setFontHeight(float value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-)。  
5. 設定 [setAlignment(int value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) 以及 [setMarginRight(float value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-)。  
6. 設定 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)。  
7. 儲存已修改的簡報。

以下 Java 程式碼示範如何將您偏好的格式套用於表格內的文字：

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation("simpletable.pptx");
try {
    // 假設第一張投影片上的第一個形狀是表格
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // 設定表格儲存格的字體高度
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // 在一次呼叫中設定表格儲存格的文字對齊方式與右側邊距
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // 設定表格儲存格的文字垂直類型
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **取得表格樣式屬性**

Aspose.Slides 讓您取得表格的樣式屬性，以便將這些資訊用於其他表格或其他地方。以下 Java 程式碼示範如何從表格預設樣式取得樣式屬性：

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // 更改預設樣式預設主題
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **鎖定表格的長寬比**

幾何形狀的長寬比是其在不同維度上的尺寸比例。Aspose.Slides 提供了 [**setAspectRatioLocked**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) 屬性，讓您能鎖定表格及其他形狀的長寬比設定。

以下 Java 程式碼示範如何鎖定表格的長寬比：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // 反轉

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以為整個表格及其儲存格內的文字啟用從右到左 (RTL) 閱讀方向嗎？**

可以。表格提供了 [setRightToLeft](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) 方法，段落則有 [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-)。同時使用兩者即可確保儲存格內的 RTL 順序與呈現正確。

**如何防止使用者在最終檔案中移動或調整表格大小？**

使用形狀鎖定可停用移動、調整大小、選取等功能。這些鎖定同樣適用於表格。

**是否支援在儲存格內插入圖片作為背景？**

可以。您可以為儲存格設定 [picture fill](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/picturefillformat/)，圖片會依所選模式（伸展或平鋪）覆蓋整個儲存格區域。