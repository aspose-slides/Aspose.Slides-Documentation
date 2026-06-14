---
title: 使用 PHP 管理 PowerPoint 表格中的列與欄
linktitle: 列與欄
type: docs
weight: 20
url: /zh-hant/php-java/manage-rows-and-columns/
keywords:
- 表格列
- 表格欄
- 首列
- 表格標題列
- 複製列
- 複製欄
- 拷貝列
- 拷貝欄
- 移除列
- 移除欄
- 列文字格式設定
- 欄文字格式設定
- 表格樣式
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（透過 Java）在 PowerPoint 中管理表格的列與欄，並加速簡報的編輯與資料更新。"
---
## **簡介**

為了讓您能在 PowerPoint 簡報中管理表格的列與欄，Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/table/) 類別以及其他多種型別。

## **將首行設定為標題列**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例並載入簡報。
2. 透過索引取得投影片的參照。 
3. 建立一個 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Table) 物件，並將其設為 null。
4. 遍歷所有 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 物件以尋找相關的表格。
5. 將表格的首列設定為標題列。 

以下 PHP 程式碼示範如何將表格的首列設定為標題列：

```php
  # 實例化 Presentation 類別
  $pres = new Presentation("table.pptx");
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 初始化 null TableEx
    $tbl = null;
    # 迭代形狀並設定表格的參照
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # 將表格的第一列設定為標題列
        $tbl->setFirstRow(true);
      }
    }
    # 將簡報儲存至磁碟
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **複製表格列或欄**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例並載入簡報,
2. 透過索引取得投影片的參照。 
3. 定義 `columnWidth` 陣列。
4. 定義 `rowHeight` 陣列。
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addtable/) 方法將 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Table) 物件新增至投影片。
6. 複製表格列。
7. 複製表格欄。
8. 儲存已修改的簡報。

以下 PHP 程式碼示範如何複製 PowerPoint 表格的列或欄：

```php
  # 實例化 Presentation 類別
  $pres = new Presentation("Test.pptx");
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 定義欄寬與列高
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # 在投影片上新增表格形狀
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # 在第 1 列第 1 格加入文字
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # 在第 1 列第 2 格加入文字
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # 在表格末端複製第 1 列
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # 在第 2 列第 1 格加入文字
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # 在第 2 列第 2 格加入文字
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # 複製第 2 列為表格的第 4 列
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # 在末端複製第一欄
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # 在第 4 個欄位索引處複製第 2 欄
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # 將簡報儲存至磁碟
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **從表格中移除列或欄**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例並載入簡報,
2. 透過索引取得投影片的參照。 
3. 定義 `columnWidth` 陣列。
4. 定義 `rowHeight` 陣列。
5. 透過 [addTable](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addtable/) 方法將 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Table) 物件新增至投影片。
6. 移除表格列。
7. 移除表格欄。
8. 儲存已修改的簡報。 

以下 PHP 程式碼示範如何從表格中移除列或欄：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **在表格列層級設定文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例並載入簡報,
2. 透過索引取得投影片的參照。 
3. 從投影片中取得相關的 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Table) 物件。
4. 設定首列儲存格的 [setFontHeight(float value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setFontHeight)。
5. 設定首列儲存格的 [setAlignment(int value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setalignment/) 與 [setMarginRight(float value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setmarginright/)。
6. 設定次列儲存格的 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/settextverticaltype/)。
7. 儲存已修改的簡報。

以下 PHP 程式碼示範此操作。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    # 假設第一張投影片的第一個形狀是表格
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 設定首列儲存格的字型高度
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # 設定首列儲存格的文字對齊方式與右邊距
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # 設定第二列儲存格的文字垂直類型
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # 將簡報儲存至磁碟
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **在表格欄層級設定文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例並載入簡報,
2. 透過索引取得投影片的參照。 
3. 從投影片中取得相關的 [Table](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Table) 物件。
4. 設定首欄儲存格的 [setFontHeight(float value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setFontHeight)。
5. 設定首欄儲存格的 [setAlignment(int value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setalignment/) 與 [setMarginRight(float value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setmarginright/)。
6. 設定次欄儲存格的 [setTextVerticalType(byte value)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/settextverticaltype/)。
7. 儲存已修改的簡報。 

以下 PHP 程式碼示範此操作：

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation();
  try {
    # 假設第一張投影片的第一個形狀是表格
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 設定第一欄儲存格的字型高度
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # 一次設定第一欄儲存格的文字對齊方式與右邊距
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # 設定第二欄儲存格的文字垂直類型
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **取得表格樣式屬性**

Aspose.Slides 允許您取得表格的樣式屬性，以便將這些細節用於其他表格或其他地方。以下 PHP 程式碼示範如何從表格預設樣式取得樣式屬性：

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

## **常見問題**

**我可以將 PowerPoint 主題/樣式套用到已建立的表格嗎？**

可以。表格會繼承投影片/版面配置/母片的主題，且您仍可在此基礎上覆寫填色、邊框與文字顏色。

**我可以像 Excel 那樣排序表格列嗎？**

不行，Aspose.Slides 的表格沒有內建排序或篩選功能。請先在記憶體中排序資料，然後依排序後的順序重新填入表格列。

**我可以在保持特定儲存格自訂顏色的同時使用帶狀（條紋）欄嗎？**

可以。開啟欄帶狀樣式，然後以局部格式覆寫特定儲存格；儲存格級別的格式會優先於表格樣式。