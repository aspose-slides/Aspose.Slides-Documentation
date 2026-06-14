---
title: 使用 PHP 管理簡報中的字型
linktitle: 管理字型
type: docs
weight: 10
url: /zh-hant/php-java/manage-fonts/
keywords:
- 管理字型
- 字型屬性
- 段落
- 文字格式化
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 控制字型：嵌入、取代並載入自訂字型，以確保 PPT、PPTX 與 ODP 簡報保持清晰、品牌安全且一致。"
---
## **管理字型相關屬性**
{{% alert color="primary" %}} 

簡報通常同時包含文字與圖像。文字可以以各種方式格式化，以強調特定段落與詞彙，或符合企業樣式。文字格式化可協助使用者調整簡報內容的外觀與感受。本文說明如何使用 Aspose.Slides for PHP via Java 設定投影片上段落文字的字型屬性。

{{% /alert %}} 

使用 Aspose.Slides for PHP via Java 管理段落字型屬性的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。
1. 透過索引取得投影片的參考。
1. 存取投影片中的 [Placeholder](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/placeholder/) 形狀，並將其型別轉換為 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 從由 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 所揭露的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 取得 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/)。
1. 讓段落兩端對齊。
1. 存取 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 文字的 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/)。
1. 使用 [FontData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontdata/) 定義字型，並依需求設定文字 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 的 **Font**。
   1. 設定字型為粗體。
   1. 設定字型為斜體。
1. 透過 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 物件所揭露的 [FillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/) 設定字型顏色。
1. 將修改後的簡報儲存為 PPTX 檔。

以下實作上述步驟。它以未經修飾的簡報為基礎，對其中一張投影片的字型進行格式化。下方的螢幕截圖顯示輸入檔案以及程式碼片段如何改變它。程式碼會變更字型、顏色與字型樣式。

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**圖說：輸入檔案中的文字**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**圖說：相同文字的更新格式**|

```php
  # 實例化一個代表 PPTX 檔案的 Presentation 物件
  $pres = new Presentation("FontProperties.pptx");
  try {
    # 使用投影片位置存取投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 存取投影片中的第一個與第二個占位符，並將其型別轉換為 AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # 存取第一個段落
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # 將段落設定為兩端對齊
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # 存取第一個 Portion
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # 定義新字型
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # 將新字型指派給 Portion
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # 將字型設定為粗體
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # 將字型設定為斜體
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # 設定字型顏色
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # 將 PPTX 儲存至磁碟
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定文字字型屬性**
{{% alert color="primary" %}} 

如同 **管理字型相關屬性** 中所述，[Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 用於在段落中保存具有相似格式樣式的文字。本文說明如何使用 Aspose.Slides for PHP via Java 建立文字方塊，並為其中的文字定義特定字型及字型系列的各種屬性。

{{% /alert %}} 

建立文字方塊並設定其中文字的字型屬性：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。
1. 透過索引取得投影片的參考。
1. 在投影片上加入類型為 **Rectangle** 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 移除與 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 相關的填充樣式。
1. 存取 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
1. 向 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 中加入文字。
1. 取得與 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 相關的 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 物件。
1. 定義用於 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 的字型。
1. 透過 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 物件所揭露的相關屬性，設定粗體、斜體、底線、顏色與字高等其他字型屬性。
1. 將修改後的簡報寫入為 PPTX 檔。

以下為上述步驟的實作範例。

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**圖說：由 Aspose.Slides for PHP via Java 設定的文字字型屬性**|

```php
  # 實例化一個代表 PPTX 檔案的 Presentation 物件
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 新增類型為 Rectangle 的 AutoShape
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # 移除與 AutoShape 相關的任何填充樣式
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # 存取與 AutoShape 相關的 TextFrame
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # 存取與 TextFrame 相關的 Portion
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # 為 Portion 設定字型
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # 設定字型的粗體屬性
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # 設定字型的斜體屬性
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # 設定字型的底線屬性
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # 設定字型的字高
    $port->getPortionFormat()->setFontHeight(25);
    # 設定字型的顏色
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # 將簡報儲存至磁碟
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```