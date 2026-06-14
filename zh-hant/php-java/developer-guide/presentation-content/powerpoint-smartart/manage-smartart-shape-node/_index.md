---
title: 使用 PHP 管理簡報中的 SmartArt 形狀節點
linktitle: SmartArt 形狀節點
type: docs
weight: 30
url: /zh-hant/php-java/manage-smartart-shape-node/
keywords:
- SmartArt 節點
- 子節點
- 新增節點
- 節點位置
- 存取節點
- 移除節點
- 自訂位置
- 助理節點
- 填充格式
- 渲染節點
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 管理 PPT 與 PPTX 中的 SmartArt 形狀節點。取得清晰的程式碼範例和技巧，讓您的簡報更流暢。"
---
## **概述**

PowerPoint 簡報中的 SmartArt 圖形透過包含文字的節點來組織，並定義圖表的結構。Aspose.Slides 允許您以程式方式操作這些 SmartArt 節點：新增節點與子節點、在特定位置插入子節點、存取現有節點，並讀取它們的文字、層級與位置。

本文說明如何管理 SmartArt 形狀節點。它展示如何移除節點、依索引或位置操作子節點、將助理節點變更為普通節點、調整 SmartArt 節點形狀的位置、大小與旋轉、設定節點的填充格式，以及為 SmartArt 子節點產生縮圖影像。

## **新增 SmartArt 節點**
Aspose.Slides for PHP via Java 提供了最簡易的 API，可以最簡單的方式管理 SmartArt 形狀。以下範例程式碼將說明如何在 SmartArt 形狀中新增節點與子節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例，並載入含 SmartArt 形狀的簡報。
2. 使用索引取得第一張投影片的參照。
3. 遍歷第一張投影片內的所有形狀。
4. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/) 類型，若是則將選取的形狀類型轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/)。
5. 在 SmartArt 形狀的 [**NodeCollection**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/#getAllNodes) 中[新增節點](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartnodecollection/#addNode) 並在 TextFrame 中設定文字。
6. 現在，在剛新增的 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/) 節點中[新增](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartnodecollection/#addNode) [**子節點**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartnode/#getChildNodes) 並在 TextFrame 中設定文字。
7. 儲存簡報。

```php
  # 載入所需的簡報
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 遍歷第一張投影片內的所有形狀
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # 檢查形狀是否為 SmartArt 類型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 將形狀類型轉換為 SmartArt
        $smart = $shape;
        # 新增一個 SmartArt 節點
        $TemNode = $smart->getAllNodes()->addNode();
        # 新增文字
        $TemNode->getTextFrame()->setText("Test");
        # 在父節點中新增子節點。它將被加入至集合的末端
        $newNode = $TemNode->getChildNodes()->addNode();
        # 新增文字
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # 儲存簡報
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **在特定位置新增 SmartArt 節點**
以下範例程式碼說明如何在特定位置為 SmartArt 形狀的各節點新增子節點。

1. 建立 Presentation 類別的實例。
2. 使用索引取得第一張投影片的參照。
3. 在取得的投影片中新增一個 [**StackedList**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SmartArtLayoutType#StackedList) 類型的 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SmartArt) 形狀。
4. 存取新增的 SmartArt 形狀中的第一個節點。
5. 現在，為所選的 [**Node**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SmartArtNode) 在位置 2 加入[**子節點**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartnode/#getChildNodes) 並設定其文字。
6. 儲存簡報。

```php
  # 建立簡報實例
  $pres = new Presentation();
  try {
    # 存取簡報投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 加入 Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # 存取索引 0 的 SmartArt 節點
    $node = $smart->getAllNodes()->get_Item(0);
    # 在父節點的第 2 個位置新增子節點
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # 加入文字
    $chNode->getTextFrame()->setText("Sample Text Added");
    # 儲存簡報
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **存取 SmartArt 節點**
以下範例程式碼可協助存取 SmartArt 形狀內的節點。請注意，SmartArt 的 LayoutType 為唯讀，僅在新增 SmartArt 形狀時設定，無法更改。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例並載入含 SmartArt 形狀的簡報。
2. 使用索引取得第一張投影片的參照。
3. 遍歷第一張投影片內的所有形狀。
4. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/) 類型，若是則將選取的形狀類型轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/)。
5. 遍歷 SmartArt 形狀內的所有[**Nodes**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SmartArt#getAllNodes--)。
6. 存取並顯示資訊，如 SmartArt 節點的位置、層級與文字。

```php
  # 實例化 Presentation 類別
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # 取得第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 遍歷第一張投影片內的所有形狀
    foreach($slide->getShapes() as $shape) {
      # 檢查形狀是否為 SmartArt 類型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 將形狀類型轉換為 SmartArt
        $smart = $shape;
        # 遍歷 SmartArt 內的所有節點
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # 存取索引 i 的 SmartArt 節點
          $node = $smart->getAllNodes()->get_Item($i);
          # 輸出 SmartArt 節點參數
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **存取 SmartArt 子節點**
以下範例程式碼可協助存取屬於 SmartArt 形狀各節點的子節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例並載入含 SmartArt 形狀的簡報。
2. 使用索引取得第一張投影片的參照。
3. 遍歷第一張投影片內的所有形狀。
4. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/) 類型，若是則將選取的形狀類型轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/)。
5. 遍歷 SmartArt 形狀內的所有[**Nodes**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SmartArt#getAllNodes--)。
6. 對每個所選的 SmartArt 形狀[**Node**]，遍歷該節點內的所有[**Child Nodes**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SmartArtNode#getChildNodes--)。
7. 存取並顯示[**Child Node**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartnode/#getChildNodes)的位置、層級與文字。

```php
  # 實例化 Presentation 類別
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # 取得第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 遍歷第一張投影片內的所有形狀
    foreach($slide->getShapes() as $shape) {
      # 檢查形狀是否為 SmartArt 類型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 將形狀類型轉換為 SmartArt
        $smart = $shape;
        # 遍歷 SmartArt 內的所有節點
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # 存取索引 i 的 SmartArt 節點
          $node0 = $smart->getAllNodes()->get_Item($i);
          # 遍歷索引 i 的 SmartArt 節點中的子節點
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # 存取 SmartArt 節點中的子節點
            $node = $node0->getChildNodes()->get_Item($j);
            # 輸出 SmartArt 子節點參數
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **在特定位置存取 SmartArt 子節點**
本範例說明如何在特定位置存取屬於 SmartArt 形狀各節點的子節點。

1. 建立 Presentation 類別的實例。
2. 使用索引取得第一張投影片的參照。
3. 新增一個 [**StackedList**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SmartArtLayoutType#StackedList) 類型的 SmartArt 形狀。
4. 存取已新增的 SmartArt 形狀。
5. 取得該 SmartArt 形狀中索引為 0 的節點。
6. 現在，使用 **get_Item()** 方法，取得該 SmartArt 節點在位置 1 的[**Child Node**]。
7. 存取並顯示[**Child Node**]的位置、層級與文字。

```php
  # 實例化簡報
  $pres = new Presentation();
  try {
    # 存取第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 在第一張投影片中加入 SmartArt 形狀
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # 存取索引 0 的 SmartArt 節點
    $node = $smart->getAllNodes()->get_Item(0);
    # 在父節點中存取位置 1 的子節點
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # 輸出 SmartArt 子節點參數
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **移除 SmartArt 節點**
本範例說明如何移除 SmartArt 形狀內的節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例並載入含 SmartArt 形狀的簡報。
2. 使用索引取得第一張投影片的參照。
3. 遍歷第一張投影片內的所有形狀。
4. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/) 類型，若是則將選取的形狀類型轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/)。
5. 檢查該 [SmartArt] 是否有超過 0 個節點。
6. 選取要刪除的 SmartArt 節點。
7. 現在，使用 [**removeNode**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartnodecollection/#removeNode) 方法移除選取的節點。
8. 儲存簡報。

```php
  # 載入所需的簡報
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # 遍歷第一張投影片內的所有形狀
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # 檢查形狀是否為 SmartArt 類型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 將形狀類型轉換為 SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # 存取索引 0 的 SmartArt 節點
          $node = $smart->getAllNodes()->get_Item(0);
          # 移除所選的節點
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # 儲存簡報
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **從特定位置移除 SmartArt 節點**
本範例說明如何從特定位置移除 SmartArt 形狀內的節點。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例並載入含 SmartArt 形狀的簡報。
2. 使用索引取得第一張投影片的參照。
3. 遍歷第一張投影片內的所有形狀。
4. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/) 類型，若是則將選取的形狀類型轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/)。
5. 選取索引為 0 的 SmartArt 形狀節點。
6. 現在，檢查所選的 SmartArt 節點是否有超過 2 個子節點。
7. 現在，使用 [**removeNode**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartnodecollection/#removeNode) 方法移除 **位置 1** 的節點。
8. 儲存簡報。

```php
  # 載入所需的簡報
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # 遍歷第一張投影片內的所有形狀
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # 檢查形狀是否為 SmartArt 類型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 將形狀類型轉換為 SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # 存取索引 0 的 SmartArt 節點
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # 移除位置 1 的子節點
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # 儲存簡報
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **為 SmartArt 物件的子節點設定自訂位置**
Aspose.Slides for PHP via Java 支援設定 [SmartArtShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SmartArtShape) 的 X 與 Y 屬性。以下程式碼片段示範如何設定自訂的 SmartArtShape 位置、大小與旋轉，亦請注意新增節點會重新計算所有節點的位置與大小。透過自訂位置設定，使用者可以依需求安排節點。

```php
  # 實例化 Presentation 類別
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # 移動 SmartArt 形狀至新位置
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # 變更 SmartArt 形狀的寬度
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # 變更 SmartArt 形狀的高度
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # 變更 SmartArt 形狀的旋轉角度
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **檢查助理節點**
{{% alert color="primary" %}} 
在本篇文章中，我們將進一步探討使用 Aspose.Slides for PHP via Java 以程式方式在簡報投影片中新增的 SmartArt 形狀功能。 
{{% /alert %}} 

我們將在本文的不同章節中使用以下來源 SmartArt 形狀進行測試。

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure: Source SmartArt shape in slide**|

以下範例程式碼將說明如何辨識 SmartArt 節點集合中的 **Assistant Nodes**，以及如何變更它們。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例並載入含 SmartArt 形狀的簡報。
2. 使用索引取得第二張投影片的參照。
3. 遍歷第一張投影片內的所有形狀。
4. 檢查形狀是否為 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/) 類型，若是則將選取的形狀類型轉換為 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/)。
5. 遍歷 SmartArt 形狀內的所有節點，並檢查它們是否為[**Assistant Nodes**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SmartArtNode#isAssistant-- )。
6. 將 Assistant Node 的狀態變更為普通節點。
7. 儲存簡報。

```php
  # 建立簡報實例
  $pres = new Presentation("AddNodes.pptx");
  try {
    # 遍歷第一張投影片內的所有形狀
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # 檢查形狀是否為 SmartArt 類型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 將形狀類型轉換為 SmartArt
        $smart = $shape;
        # 遍歷 SmartArt 形狀的所有節點
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # 檢查節點是否為助理節點
          if ($node->isAssistant()) {
            # 設定助理節點為 false 並將其變為普通節點
            $node->isAssistant();
          }
        }
      }
    }
    # 儲存簡報
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure: Assistant Nodes Changed in SmartArt shape inside slide**|

## **設定節點的填充格式**
Aspose.Slides for PHP via Java 使得新增自訂 SmartArt 形狀並設定其填充格式成為可能。本文說明如何建立與存取 SmartArt 形狀，並使用 Aspose.Slides for PHP via Java 設定其填充格式。

請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。
2. 使用索引取得投影片的參照。
3. 透過設定其 [**LayoutType**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) 來新增一個 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/) 形狀。
4. 設定 SmartArt 形狀節點的 [**Fill Format**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getFillFormat)。
5. 將修改後的簡報寫入為 PPTX 檔案。

```php
  # 實例化簡報
  $pres = new Presentation();
  try {
    # 取得投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 新增 SmartArt 形狀與節點
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # 設定節點填充顏色
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # 儲存簡報
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **產生 SmartArt 子節點的縮圖**
開發人員可依照以下步驟產生 SmartArt 子節點的縮圖：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。
2. [Add SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartnodecollection/#addNode)。
3. 使用索引取得節點的參照。
4. 取得縮圖影像。
5. 將縮圖影像儲存為任意所需的圖片格式。

```php
  # 實例化代表 PPTX 檔案的 Presentation 類別
  $pres = new Presentation();
  try {
    # 新增 SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # 透過索引取得節點的參照
    $node = $smart->getNodes()->get_Item(1);
    # 取得縮圖
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # 儲存縮圖
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**是否支援 SmartArt 動畫？**

是的。SmartArt 被視為一般形狀，因此您可以[套用標準動畫](/slides/zh-hant/php-java/shape-animation/)（進入、退出、強調、移動路徑）並調整時間。必要時也能為 SmartArt 節點內的形狀加入動畫。

**如果不知道內部 ID，如何可靠地在投影片上定位特定的 SmartArt？**

可透過指派並搜尋[替代文字](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getalternativetext/)，在 SmartArt 上設定唯一的 AltText，即可在程式中不依賴內部識別碼而找到它。

**將簡報轉換為 PDF 時，SmartArt 的外觀會被保留嗎？**

是的。Aspose.Slides 在[PDF 匯出](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/) 時以高視覺相容度渲染 SmartArt，保留其版面配置、顏色與效果。

**我能擷取整個 SmartArt 的影像（用於預覽或報告）嗎？**

可以。您可以將 SmartArt 形狀渲染為[點陣格式](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getImage)或[SVG](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/writeassvg/)，以取得可用於縮圖、報告或網路的可縮放向量輸出。