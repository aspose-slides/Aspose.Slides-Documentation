---
title: 在 PHP 中管理簡報表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh-hant/php-java/manage-table/
keywords:
- 新增表格
- 建立表格
- 存取表格
- 長寬比例
- 對齊文字
- 文字格式設定
- 表格樣式
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 投影片中建立與編輯表格。探索簡易程式碼範例，簡化您的表格工作流程。"
---
## **簡介**

PowerPoint 中的表格是顯示與呈現資訊的高效方式。以行列排列的格子網格中的資訊直觀且易於理解。

Aspose.Slides 提供 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Table) 類別、[Cell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cell/) 類別以及其他類型，讓您能在各種簡報中建立、更新與管理表格。

## **從頭建立表格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 定義 `columnWidth` 陣列。  
4. 定義 `rowHeight` 陣列。  
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addtable/) 方法將 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/table/) 物件新增至投影片。  
6. 遍歷每個 [Cell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cell/) ，對上、下、右、左邊框套用格式設定。  
7. 合併表格第一行的前兩個儲存格。  
8. 存取 [Cell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。  
9. 向 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 新增文字。  
10. 儲存已修改的簡報。

以下 PHP 程式碼示範如何在簡報中建立表格：

```php
  # 實例化一個代表 PPTX 檔案的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 定義欄寬與列高
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # 在投影片上新增表格形狀
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 為每個儲存格設定邊框格式
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # 合併第 1 列的第 1 及第 2 個儲存格
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # 向合併的儲存格加入文字
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # 將簡報儲存至磁碟
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **標準表格中的編號**

在標準表格中，儲存格的編號方式簡單且以零為起始。表格的第一個儲存格索引為 0,0（第 0 欄，第 0 列）。

例如，具有 4 欄 4 列的表格，其儲存格編號如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

以下 PHP 程式碼示範如何為表格中的儲存格指定編號：

```php
  # 實例化一個代表 PPTX 檔案的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 定義欄寬與列高
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # 在投影片上新增表格形狀
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 為每個儲存格設定邊框格式
    $rows = $tbl->getRows();
    foreach($rows as $row) {
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
    # 將簡報儲存至磁碟
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **存取現有表格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得包含表格的投影片參考。  
3. 建立 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Table) 物件並設為 null。  
4. 遍歷所有 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 物件，直到找到表格。  
如果您認為目前的投影片只包含單一表格，您可以直接檢查其所有形狀。當形狀被辨識為表格時，您可以將其型別轉換為 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Table) 物件。但若投影片包含多個表格，則建議透過其 [setAlternativeText(String value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/setalternativetext/) 方法搜尋所需的表格。  
5. 使用 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Table) 物件操作表格。以下範例中，我們向表格新增了一列。  
6. 儲存已修改的簡報。

以下 PHP 程式碼示範如何存取並操作現有表格：

```php
  # 實例化代表 PPTX 檔案的 Presentation 類別
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 將 TableEx 初始化為 null
    $tbl = null;
    # 遍歷形狀並設定找到的表格參考
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # 設定第二列第一欄的文字
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # 將修改後的簡報儲存至磁碟
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **找出擁有 TextFrame 的儲存格**

當一般的文字處理程式從表格取得 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 時，請使用 [TextFrame::getParentCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#getParentCell) 方法取得其所屬的 [Cell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cell/)。對於表格儲存格的文字框，[TextFrame::getParentCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#getParentCell) 會回傳擁有者，而 [TextFrame::getParentShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#getParentShape) 會回傳 `null`，即使表格本身也是一個形狀。

儲存格座標可透過唯讀的 [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cell/#getFirstColumnIndex) 與 [Cell::getFirstRowIndex](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cell/#getFirstRowIndex) 方法取得。[TextFrame::getParentCell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#getParentCell) 亦提供唯讀的導向：它回傳擁有者但不會變更所有權。使用前請務必以 `java_is_null` 檢查回傳的儲存格是否為 null。

欲取得包含表格儲存格與形狀擁有者（包括與 SmartArt 節點相關聯的形狀）的完整範例，請參閱 [Search and Replace Text](/slides/zh-hant/php-java/search-and-replace-text/)。

## **對齊表格中的文字**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 將 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Table) 物件新增至投影片。  
4. 從表格取得 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 物件。  
5. 取得 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/)。  
6. 垂直對齊文字。  
7. 儲存已修改的簡報。

以下 PHP 程式碼示範如何對齊表格中的文字：

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 定義欄寬與列高
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # 將表格形狀新增至投影片
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # 取得文字框
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # 建立文字框的 Paragraph 物件
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # 建立段落的 Portion 物件
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 垂直對齊文字
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # 將簡報儲存至磁碟
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定表格層級的文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 從投影片存取 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Table) 物件。  
4. 設定文字的 [setFontHeight(float value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setFontHeight)。  
5. 設定 [setAlignment(int value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setalignment/) 以及 [setMarginRight(float value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setmarginright/)。  
6. 設定 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/settextverticaltype/)。  
7. 儲存已修改的簡報。

以下 PHP 程式碼示範如何將您偏好的格式選項套用至表格中的文字：

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation("simpletable.pptx");
  try {
    # 假設第一張投影片上的第一個形狀是表格
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 設定表格儲存格的字型高度
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # 一次設定表格儲存格的文字對齊方式與右邊距
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # 設定表格儲存格的文字垂直類型
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **取得表格樣式屬性**

Aspose.Slides 讓您能取得表格的樣式屬性，以便將這些資訊用於其他表格或其他地方。以下 PHP 程式碼示範如何從表格預設樣式取得樣式屬性：

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// 更改預設樣式預設主題

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **鎖定表格的長寬比例**

幾何形狀的長寬比例是指其在不同維度上的尺寸比例。Aspose.Slides 提供了 [setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) 方法，讓您能為表格及其他形狀鎖定長寬比例設定。

以下 PHP 程式碼示範如何為表格鎖定長寬比例：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invert

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**我可以為整個表格及其儲存格中的文字啟用從右至左 (RTL) 讀取方向嗎？**

可以。表格提供了 [setRightToLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/table/setrighttoleft/) 方法，段落則具有 [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setrighttoleft/)。同時使用可確保儲存格內的 RTL 順序與呈現正確。

**如何防止使用者在最終檔案中移動或調整表格大小？**

使用形狀鎖定以停用移動、調整大小、選取等功能。這些鎖定同樣適用於表格。

**是否支援在儲存格內插入影像作為背景？**

支援。您可以為儲存格設定 [picture fill](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/)，影像會依所選模式（拉伸或平鋪）覆蓋整個儲存格區域。