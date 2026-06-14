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
- 新增文字欄
- 新增超連結
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP 讓您能輕鬆在 PowerPoint 和 OpenDocument 檔案中建立、編輯與複製文字方塊，提升簡報自動化效能。"
---
## **Introduction**

投影片上的文字通常位於文字方塊或圖形中。因此，要在投影片上加入文字，必須先加入文字方塊，然後在文字方塊內放入文字。Aspose.Slides for PHP via Java 提供了 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 類別，可讓您加入包含文字的圖形。

{{% alert title="Info" color="info" %}}
Aspose.Slides 也提供了 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 類別，可讓您在投影片上加入圖形。然而，透過 `Shape` 類別加入的所有圖形並不一定能容納文字。但透過 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 類別加入的圖形可能包含文字。
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
因此，當處理想要加入文字的圖形時，您可能需要檢查並確認該圖形是透過 `AutoShape` 類別轉型的。只有這樣，您才能使用位於 `AutoShape` 下的屬性 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。請參閱本頁面的 [Update Text](/slides/zh-hant/php-java/manage-textbox/#update-text) 章節。
{{% /alert %}}

## **Create a Text Box on a Slide**

要在投影片上建立文字方塊，請執行以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。  
2. 取得新建立的簡報中第一張投影片的參考。  
3. 在投影片的指定位置加入形狀類型設定為 [Rectangle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapetype/#Rectangle) 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 物件，並取得新加入的 `AutoShape` 物件的參考。  
4. 在 `AutoShape` 物件中加入一個將容納文字的 `TextFrame`。在下方示例中，我們加入了這段文字：*Aspose TextBox*  
5. 最後，透過 `Presentation` 物件寫入 PPTX 檔案。  

以下的 PHP 程式碼—上述步驟的實作範例—示範如何在投影片中加入文字：

```php
  # 實例化 Presentation
  $pres = new Presentation();
  try {
    # 取得簡報中的第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 加入型別設定為 Rectangle 的 AutoShape
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # 為 Rectangle 新增 TextFrame
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

## **Check for a Text Box Shape**

Aspose.Slides 提供了來自 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 類別的 [isTextBox](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/istextbox/) 方法，讓您能檢查圖形並辨識文字方塊。

![Text box and shape](istextbox.png)

此 PHP 程式碼示範如何檢查圖形是否已建立為文字方塊：

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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

請注意，如果僅使用來自 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/) 類別的 `addAutoShape` 方法加入 autoShape，則該 autoShape 的 `isTextBox` 方法將回傳 `false`。然而，在使用 `addTextFrame` 方法或 `setText` 方法為 autoShape 加入文字之後，`isTextBox` 屬性會回傳 `true`。

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() 回傳 false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() 回傳 true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() 回傳 false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() 回傳 true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() 回傳 false
$shape3->addTextFrame("");
// shape3->isTextBox() 回傳 false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() 回傳 false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() 回傳 false
```

## **Add Columns to a Text Box**

Aspose.Slides 提供了來自 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/) 類別的 [setColumnCount](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/setcolumncount/) 與 [setColumnSpacing](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/setcolumnspacing/) 方法，讓您能在文字方塊中加入欄。您可以指定文字方塊的欄數，並設定欄與欄之間以點為單位的間距。

以下程式碼示範上述操作：

```php
  $pres = new Presentation();
  try {
    # 取得簡報中的第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 加入型別設定為 Rectangle 的 AutoShape
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # 為 Rectangle 新增 TextFrame
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # 取得 TextFrame 的文字格式
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # 指定 TextFrame 中的欄數
    $format->setColumnCount(3);
    # 指定欄與欄之間的間距
    $format->setColumnSpacing(10);
    # 儲存簡報
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Add Columns to a Text Frame**
Aspose.Slides for PHP via Java 提供了來自 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/) 類別的 [setColumnCount](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/setcolumncount/) 方法，讓您能在文字框中加入欄。透過此屬性，您可以指定文字框中想要的欄數。

此 PHP 程式碼示範如何在文字框內加入欄：

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

## **Update Text**

Aspose.Slides 允許您變更或更新文字方塊中或整個簡報中所有文字的內容。

以下的 PHP 程式碼示範將簡報中所有文字更新或變更的操作：

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # 檢查形狀是否支援文字框 (IAutoShape)。
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # 遍歷文字框中的段落
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # 遍歷段落中的每個 Portion
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// 變更文字

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// 變更格式

            }
          }
        }
      }
    }
    # 儲存修改後的簡報
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Add a Text Box with a Hyperlink** 

您可以在文字方塊內插入連結。當使用者點擊該文字方塊時，會導向開啟該連結。

若要新增包含連結的文字方塊，請依照以下步驟執行：

1. 建立 `Presentation` 類別的實例。  
2. 取得新建立的簡報中第一張投影片的參考。  
3. 在投影片的指定位置加入 `ShapeType` 設為 `Rectangle` 的 `AutoShape` 物件，並取得新加入的 AutoShape 物件的參考。  
4. 在 `AutoShape` 物件中加入 `TextFrame`，其預設文字為 *Aspose TextBox*。  
5. 建立 `HyperlinkManager` 類別的實例。  
6. 使用 [setExternalHyperlinkClick](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) 方法，為 `TextFrame` 中您選取的部分指定外部超連結。  
7. 最後，透過 `Presentation` 物件寫入 PPTX 檔案。  

以下的 PHP 程式碼—上述步驟的實作範例—示範如何在投影片中加入帶有超連結的文字方塊：

```php
  # 實例化代表 PPTX 的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得簡報中的第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 加入型別設定為 Rectangle 的 AutoShape 物件
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # 將形狀轉型為 AutoShape
    $pptxAutoShape = $shape;
    # 取得與 AutoShape 相關的 ITextFrame 屬性
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # 向框架新增文字
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # 為 Portion 文字設定超連結
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

## **FAQ**

**在使用母片時，文字方塊與文字佔位符有何差異？**

[placeholder](/slides/zh-hant/php-java/manage-placeholder/) 繼承自 [master](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/masterslide/) 的樣式與位置，且可在 [layouts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/) 上被覆寫；相較之下，普通的文字方塊是特定投影片上的獨立物件，切換版面配置時不會變動。

**如何在簡報中執行批次文字取代，同時不影響圖表、表格與 SmartArt 內的文字？**

將迭代僅限於具有文字框的 auto‑shape，並排除嵌入式物件（[charts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/)、[tables](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/)），可分別遍歷其集合或直接跳過這些物件類型。