---
title: 使用 PHP 管理簡報中的文字方塊
linktitle: 管理文字方塊
type: docs
weight: 20
url: /zh-hant/php-java/manage-textbox/
keywords:
- 文字方塊
- 文字框
- 新增文字
- 更新文字
- 建立文字方塊
- 檢查文字方塊
- 新增文字欄位
- 新增超連結
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP 讓您能輕鬆在 PowerPoint 和 OpenDocument 檔案中建立、編輯與複製文字方塊，提升簡報自動化的效率。"
---
## **簡介**

投影片上的文字通常位於文字方塊或圖形中。因此，要在投影片上加入文字，必須先新增文字方塊，然後將文字放入該文字方塊中。Aspose.Slides for PHP via Java 提供了 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 類別，可讓您新增包含文字的圖形。

{{% alert title="資訊" color="info" %}}
Aspose.Slides 也提供了 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 類別，可讓您在投影片上新增圖形。然而，透過 `Shape` 類別加入的並非所有圖形都能容納文字。但透過 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 類別加入的圖形可能包含文字。
{{% /alert %}}

{{% alert title="注意" color="warning" %}} 
因此，當處理想要加入文字的圖形時，您可能需要檢查並確認它是透過 `AutoShape` 類別轉型的。只有這樣才能使用 `AutoShape` 之下的屬性 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。請參閱本頁面的 [Update Text](/slides/zh-hant/php-java/manage-textbox/#update-text) 章節。
{{% /alert %}}

## **在投影片上建立文字方塊**

建立投影片上的文字方塊，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。  
2. 取得新建立的簡報中第一張投影片的參考。  
3. 在投影片的指定位置新增一個形狀類型為 [Rectangle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapetype/#Rectangle) 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 物件，並取得新加入的 `AutoShape` 物件的參考。  
4. 為 `AutoShape` 物件加入 `TextFrame`，其中將包含文字。以下範例中，我們加入的文字為 *Aspose TextBox*。  
5. 最後，透過 `Presentation` 物件寫入 PPTX 檔案。  

以下 PHP 程式碼展示了上述步驟，說明如何在投影片上加入文字：

```php
  # 實例化 Presentation
  $pres = new Presentation();
  try {
    # 取得簡報中的第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 新增類型設定為 Rectangle 的 AutoShape
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # 在 Rectangle 中加入 TextFrame
    $ashp->addTextFrame(" ");
    # 存取文字框
    $txtFrame = $ashp->getTextFrame();
    # 為文字框建立 Paragraph 物件
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # 為段落建立 Portion 物件
    $portion = $para->getPortions()->get_Item(0);
    # 設定文字
    $portion->setText("Aspose TextBox");
    # 將簡報儲存至磁碟
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **檢查文字方塊形狀**

Aspose.Slides 透過 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 類別提供了 [isTextBox](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/istextbox/) 方法，讓您能檢測形狀並辨識是否為文字方塊。

![文字方塊與圖形](istextbox.png)

以下 PHP 程式碼示範如何檢查形狀是否是以文字方塊建立：

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

請注意，若您僅使用 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/) 類別的 `addAutoShape` 方法新增自動圖形，該自動圖形的 `isTextBox` 方法會回傳 `false`。但若您使用 `addTextFrame` 方法或 `setText` 方法為自動圖形加入文字後，`isTextBox` 屬性會回傳 `true`。

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() 傳回 false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() 傳回 true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() 傳回 false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() 傳回 true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() 傳回 false
$shape3->addTextFrame("");
// shape3->isTextBox() 傳回 false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() 傳回 false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() 傳回 false
```

## **找出擁有 TextFrame 的形狀**

在通用文字處理程式碼中，您可能只拿到一個 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)，卻不知道它屬於哪個簡報物件。使用 [TextFrame::getParentShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#getParentShape) 方法即可回溯至擁有它的 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/)。

對於屬於 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 或其他可容納文字的圖形的文字框，`TextFrame::getParentShape` 會回傳其擁有者，而 `TextFrame::getParentCell` 會回傳 `null`。這兩個方法皆為唯讀導向，呼叫它們不會改變所有權。存取圖形前請務必先以 `java_is_null` 檢查回傳值。

欲取得完整範例，說明如何辨識形狀與表格儲存格的擁有者（包括與 SmartArt 節點相關的形狀），請參閱 [Search and Replace Text](/slides/zh-hant/php-java/search-and-replace-text/)。

## **為文字方塊新增欄位**

Aspose.Slides 提供了 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/) 類別的 [setColumnCount](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/setcolumncount/) 與 [setColumnSpacing](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/setcolumnspacing/) 方法，讓您能在文字方塊中加入欄位。您可以指定文字方塊的欄位數量，並設定欄位之間的點數間距。

以下程式碼示範上述操作：

```php
  $pres = new Presentation();
  try {
    # 取得簡報中的第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 新增類型設定為 Rectangle 的 AutoShape
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # 在 Rectangle 中加入 TextFrame
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # 取得 TextFrame 的文字格式
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # 指定 TextFrame 中的欄位數量
    $format->setColumnCount(3);
    # 指定欄位之間的間距
    $format->setColumnSpacing(10);
    # 儲存簡報
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **為 TextFrame 新增欄位**
Aspose.Slides for PHP via Java 提供了 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/) 類別的 [setColumnCount](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/setcolumncount/) 方法，讓您能在文字框中新增欄位。透過此屬性，您可以指定文字框中想要的欄位數量。

以下 PHP 程式碼示範如何在文字框內新增欄位：

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **更新文字**

Aspose.Slides 允許您變更或更新文字方塊中的文字，或整份簡報中所有文字。

以下 PHP 程式碼示範一次更新簡報中所有文字的操作：

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # 檢查形狀是否支援文字框 (IAutoShape)。
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # 迭代文字框中的段落
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # 迭代段落中的每個 Portion
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// 更改文字

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// 更改格式設定

            }
          }
        }
      }
    }
    # 儲存已修改的簡報
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **新增帶有超連結的文字方塊** 

您可以在文字方塊內插入連結。點擊文字方塊時，使用者會被導向開啟該連結。

要新增包含連結的文字方塊，請依照以下步驟：

1. 建立 `Presentation` 類別的實例。  
2. 取得新建立的簡報中第一張投影片的參考。  
3. 在投影片的指定位置新增一個 `ShapeType` 為 `Rectangle` 的 `AutoShape` 物件，並取得新加入的 AutoShape 物件的參考。  
4. 為 `AutoShape` 物件加入 `TextFrame`，其預設文字為 *Aspose TextBox*。  
5. 實例化 `HyperlinkManager` 類別。  
6. 使用 [setExternalHyperlinkClick](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) 方法，將超連結指派給 `TextFrame` 中您選擇的文字區段。  
7. 最後，透過 `Presentation` 物件寫入 PPTX 檔案。  

以下 PHP 程式碼展示上述步驟，說明如何在投影片上新增帶有超連結的文字方塊：

```php
  # 實例化代表 PPTX 的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得簡報中的第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 新增類型設定為 Rectangle 的 AutoShape 物件
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # 將形狀轉型為 AutoShape
    $pptxAutoShape = $shape;
    # 存取與 AutoShape 相關的 ITextFrame 屬性
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # 在框中加入一些文字
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # 設定 Portion 文字的超連結
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # 儲存 PPTX 簡報
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**在使用母片時，文字方塊與文字佔位符有何差異？**

[placeholder](/slides/zh-hant/php-java/manage-placeholder/) 會從 [master](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/) 繼承樣式/位置，且可在 [layouts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/) 上被覆寫，而一般的文字方塊則是特定投影片上的獨立物件，切換版面配置時不會改變。

**如何在整份簡報中大量取代文字，同時避免影響圖表、表格與 SmartArt 內的文字？**

將迭代範圍限制在具有文字框的自動圖形上，並排除內嵌物件（[charts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/)、[tables](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/)），可分別遍歷它們的集合或直接跳過這些物件類型。