---
title: 使用 PHP 管理簡報中的表格儲存格
linktitle: 管理儲存格
type: docs
weight: 30
url: /zh-hant/php-java/manage-cells/
keywords:
- 表格儲存格
- 合併儲存格
- 移除邊框
- 分割儲存格
- 儲存格內圖片
- 背景顏色
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides for PHP 在 PowerPoint 中管理表格儲存格。快速掌握存取、修改與樣式設定，實現流暢的投影片自動化。"
---
## **概觀**

Aspose.Slides 允許您在 PowerPoint 簡報中存取與修改表格儲存格。本文說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景顏色，以及在表格儲存格內加入圖片。示例展示了如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

## **識別合併的表格儲存格**
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 從第一張投影片取得表格。  
3. 遍歷表格的列與欄，以尋找合併的儲存格。  
4. 當找到合併的儲存格時列印訊息。  

以下 PHP 程式碼示範如何在簡報中識別合併的表格儲存格：

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// 假設 Slide#0.Shape#0 是一個表格

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **移除表格儲存格邊框**
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 定義具有寬度的欄位陣列。  
4. 定義具有高度的列陣列。  
5. 使用 [addTable](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#addTable) 方法將表格加入投影片。  
6. 遍歷每個儲存格，清除上、下、右、左邊框。  
7. 將修改後的簡報儲存為 PPTX 檔案。  

以下 PHP 程式碼示範如何移除表格儲存格的邊框：

```php
  # 實例化代表 PPTX 檔案的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 定義具有寬度的欄位與具有高度的列
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # 將表格形狀新增至投影片
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 為每個儲存格設定邊框格式
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # 將 PPTX 寫入磁碟
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **合併儲存格的編號**
如果我們合併兩組儲存格 (1, 1) x (2, 1) 與 (1, 2) x (2, 2)，則產生的表格會被編號。以下 PHP 程式碼示範此過程：

```php
  # 實例化代表 PPTX 檔案的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 定義具有寬度的欄位與具有高度的列
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # 將表格形狀新增至投影片
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 為每個儲存格設定邊框格式
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # 合併儲存格 (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # 合併儲存格 (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

接著我們進一步合併 (1, 1) 與 (1, 2) 兩個儲存格。結果是表格中心出現一個大型合併儲存格：

```php
  # 實例化代表 PPTX 檔案的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 定義具有寬度的欄位與具有高度的列
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # 將表格形狀新增至投影片
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 為每個儲存格設定邊框格式
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # 合併儲存格 (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # 合併儲存格 (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # 合併儲存格 (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # 將 PPTX 檔案寫入磁碟
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **分割儲存格的編號**
在先前的範例中，當表格儲存格合併時，其他儲存格的編號系統不會改變。  
這次，我們使用一個普通表格（未包含合併儲存格的表格），然後嘗試將儲存格 (1,1) 拆分，得到一個特殊的表格。您可能需要注意此表格的編號方式，這看起來可能有點奇怪。然而，這正是 Microsoft PowerPoint 為表格儲存格編號的方式，Aspose.Slides 亦然。  

以下 PHP 程式碼示範我們所描述的過程：

```php
  # 實例化代表 PPTX 檔案的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 定義具有寬度的欄位與具有高度的列
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # 將表格形狀新增至投影片
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 為每個儲存格設定邊框格式
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # 合併儲存格 (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # 合併儲存格 (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # 分割儲存格 (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # 將 PPTX 檔案寫入磁碟
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **變更表格儲存格背景顏色**

以下 PHP 程式碼示範如何變更表格儲存格的背景顏色：

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # 建立新表格
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # 為儲存格設定背景顏色
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **在表格儲存格內加入圖片**
1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 定義具有寬度的欄位陣列。  
4. 定義具有高度的列陣列。  
5. 使用 [AddTable](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#addTable) 方法將表格加入投影片。  
6. 建立一個 `Images` 物件以保存圖片檔案。  
7. 將 `IImage` 圖像加入 `IPPImage` 物件。  
8. 將表格儲存格的 `FillFormat` 設定為 `Picture`。  
9. 將圖片加入表格的第一個儲存格。  
10. 將修改後的簡報儲存為 PPTX 檔案。  

以下 PHP 程式碼示範在建立表格時如何將圖片放置於表格儲存格內：

```php
  # 實例化代表 PPTX 檔案的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $islide = $pres->getSlides()->get_Item(0);
    # 定義具有寬度的欄位與具有高度的列
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # 將表格形狀新增至投影片
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # 使用圖像檔建立 IPPImage 物件
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 將影像加入表格的第一個儲存格
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # 將 PPTX 檔案儲存至磁碟
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**我能為單一儲存格的不同邊設定不同的線寬與樣式嗎？**  
可以。儲存格的 [上](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellformat/getbordertop/)/[下](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellformat/getborderbottom/)/[左](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellformat/getborderleft/)/[右](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cellformat/getborderright/) 邊框各自擁有獨立的屬性，因此每一側的線寬與樣式都可以不同。這與本文示範的儲存格逐側邊框控制邏輯相符。

**如果在將圖片設定為儲存格背景後，變更欄或列的大小，圖片會發生什麼情況？**  
其行為取決於 [fill mode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillmode/)（伸展/平鋪）。若使用伸展，圖片會依新儲存格調整大小；若使用平鋪，圖塊會重新計算。本文有提到儲存格內圖片的顯示模式。

**我能為儲存格的所有內容指派超連結嗎？**  
[Hyperlinks](/slides/zh-hant/php-java/manage-hyperlinks/) 可設定於儲存格文字框內的文字（段落）層級，或整個表格/形狀層級。實務上，您可以將連結指派給某段文字或整個儲存格的所有文字。

**我能在單一儲存格內設定不同的字型嗎？**  
可以。儲存格的文字框支援 [portions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/)（文字片段），可獨立設定格式——字型、樣式、大小與顏色。