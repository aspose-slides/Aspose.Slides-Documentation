---
title: 在 Android 上管理 PowerPoint 表格的列與欄
linktitle: 列與欄
type: docs
weight: 20
url: /zh-hant/androidjava/manage-rows-and-columns/
keywords:
- 表格列
- 表格欄
- 第一列
- 表格標題列
- 複製列
- 複製欄
- 拷貝列
- 拷貝欄
- 移除列
- 移除欄
- 列文字格式化
- 欄文字格式化
- 表格樣式
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 搭配 Java，在 PowerPoint 中管理表格的列與欄，並加速簡報編輯與資料更新。"
---
## **簡介**

為了讓您在 PowerPoint 簡報中管理表格的行與列，Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/table/) 類別、[ITable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ITable) 介面，以及許多其他類型。

## **將第一列設定為標題列**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例並載入簡報。  
2. 透過索引取得投影片的參照。  
3. 建立 [ITable] 物件，並將其設為 null。  
4. 遍歷所有 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 物件以找到相關的表格。  
5. 將表格的第一列設定為標題列。  

以下 Java 程式碼示範如何將表格的第一列設定為標題列：

```java
// 實例化 Presentation 類別
Presentation pres = new Presentation("table.pptx");
try {
    // 存取第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 初始化 null TableEx
    ITable tbl = null;

    // 遍歷形狀並設定對表格的參考
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Sets將表格的第一列設定為標題列
            tbl.setFirstRow(true);
        }
    }
    
    // 將簡報儲存到磁碟
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **複製表格列或欄**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例並載入簡報，  
2. 透過索引取得投影片的參照。  
3. 定義 `columnWidth` 陣列。  
4. 定義 `rowHeight` 陣列。  
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 方法將 [ITable] 物件加入投影片。  
6. 複製表格列。  
7. 複製表格欄。  
8. 儲存已修改的簡報。  

以下 Java 程式碼示範如何複製 PowerPoint 表格的列或欄：

```java
 // 實例化 Presentation 類別
Presentation pres = new Presentation("Test.pptx");
try {
    // 存取第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 定義欄寬與列高
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // 將表格形狀加入投影片
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // 在第 1 列第 1 格加入文字
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // 在第 1 列第 2 格加入文字
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // 在表格末端複製第 1 列
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // 在第 2 列第 1 格加入文字
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // 在第 2 列第 2 格加入文字
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // 將第 2 列複製為表格的第 4 列
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // 在末端複製第一欄
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // 在第 4 欄索引處複製第 2 欄
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // 將簡報儲存至磁碟
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **從表格中移除列或欄**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例並載入簡報，  
2. 透過索引取得投影片的參照。  
3. 定義 `columnWidth` 陣列。  
4. 定義 `rowHeight` 陣列。  
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) 方法將 [ITable] 物件加入投影片。  
6. 移除表格列。  
7. 移除表格欄。  
8. 儲存已修改的簡報。  

以下 Java 程式碼示範如何從表格中移除列或欄：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在表格列層級設定文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例並載入簡報，  
2. 透過索引取得投影片的參照。  
3. 從投影片取得相關的 [ITable] 物件。  
4. 設定第一列儲存格的 [setFontHeight(float value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-)。  
5. 設定第一列儲存格的 [setAlignment(int value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) 與 [setMarginRight(float value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-)。  
6. 設定第二列儲存格的 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)。  
7. 儲存已修改的簡報。  

以下 Java 程式碼示範此操作。

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    // 假設第一張投影片的第一個形狀是一個表格
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // 設定第一列儲存格的字型高度
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // 設定第一列儲存格的文字對齊方式與右側邊距
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // 設定第二列儲存格的文字垂直方向類型
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // 將簡報儲存至磁碟
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在表格欄層級設定文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例並載入簡報，  
2. 透過索引取得投影片的參照。  
3. 從投影片取得相關的 [ITable] 物件。  
4. 設定第一欄儲存格的 [setFontHeight(float value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-)。  
5. 設定第一欄儲存格的 [setAlignment(int value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) 與 [setMarginRight(float value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-)。  
6. 設定第二欄儲存格的 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-)。  
7. 儲存已修改的簡報。  

以下 Java 程式碼示範此操作：

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    // 假設第一張投影片的第一個形狀是一個表格
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // 設定第一欄儲存格的字型高度
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // 在一次呼叫中設定第一欄儲存格的文字對齊方式與右側邊距
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // 設定第二欄儲存格的文字垂直類型
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **取得表格樣式屬性**

Aspose.Slides 允許您取得表格的樣式屬性，以便將這些資訊用於其他表格或其他地方。以下 Java 程式碼示範如何從表格預設樣式取得樣式屬性：

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

## **常見問題**

**我可以將已建立的表格套用 PowerPoint 主題/樣式嗎？**

可以。表格會繼承投影片/版面/母片的主題，且您仍可在此主題上覆寫填充、邊框和文字顏色。

**我可以像在 Excel 中一樣對表格列進行排序嗎？**

不行，Aspose.Slides 的表格沒有內建的排序或篩選功能。請先在記憶體中排序資料，然後依該順序重新填入表格列。

**我可以在保留特定儲存格自訂顏色的同時，使用條紋欄位嗎？**

可以。開啟條紋欄位後，再以局部格式覆寫特定儲存格；儲存格層級的格式會優先於表格樣式。