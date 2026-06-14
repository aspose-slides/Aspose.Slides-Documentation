---
title: 在 PHP 中管理簡報佔位元
linktitle: 管理佔位元
type: docs
weight: 10
url: /zh-hant/php-java/manage-placeholder/
keywords:
- 佔位元
- 文字佔位元
- 圖片佔位元
- 圖表佔位元
- 提示文字
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "輕鬆在 Aspose.Slides for PHP via Java 中管理佔位元：取代文字、客製化提示並在 PowerPoint 與 OpenDocument 中設定圖片透明度。"
---
## **概觀**

Aspose.Slides 允許您以程式方式管理簡報中的佔位元。本文說明如何在投影片上尋找佔位元並變更其文字、為佔位元佈局設定自訂提示文字，以及調整用作佔位元背景的圖片之透明度。內容還包括簡短的 FAQ，說明基礎佔位元與投影片本地形狀的差異、如何透過佈局或母片套用佔位元變更，以及指向頁首與頁尾佔位元的管理方式。

## **變更佔位元文字**
使用 [Aspose.Slides for PHP via Java](/slides/zh-hant/php-java/)，您可以在簡報的投影片上尋找並修改佔位元。Aspose.Slides 允許您變更佔位元中的文字。

**Prerequisite**：您需要一個包含佔位元的簡報。您可以使用標準的 Microsoft PowerPoint 應用程式建立此類簡報。

以下說明如何使用 Aspose.Slides 取代該簡報中佔位元的文字：

1. 建立 [`Presentation`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例，並將簡報作為參數傳入。
2. 透過索引取得投影片的參考。
3. 迭代形狀集合以尋找佔位元。
4. 將佔位元形狀型別轉換為 [`AutoShape`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/AutoShape)，並使用與該 [`AutoShape`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/AutoShape) 相關聯的 [`TextFrame`](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/TextFrame) 變更文字。
5. 儲存已修改的簡報。

以下 PHP 程式碼示範如何變更佔位元的文字：

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 迭代形狀以尋找佔位元
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # 變更每個佔位元的文字
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # 將簡報儲存至磁碟
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定佔位元提示文字**
標準與預建佈局包含如 ***Click to add a title*** 或 ***Click to add a subtitle*** 等佔位元提示文字。使用 Aspose.Slides，您可以將自訂的提示文字插入佔位元佈局中。

以下 PHP 程式碼示範如何設定佔位元的提示文字：

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # 迭代投影片
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint 顯示「點擊此處新增標題」
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // 新增副標題
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定佔位元圖片透明度**
Aspose.Slides 允許您設定文字佔位元背景圖像的透明度。透過調整此框架中圖片的透明度，您可以使文字或圖像更加突出（取決於文字與圖片的顏色）。

以下 PHP 程式碼示範如何為圖片背景（形狀內部）設定透明度：

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **常見問題**

**什麼是基礎佔位元，它與投影片上的本地形狀有何不同？**

基礎佔位元是佈局或母片上原始的形狀，投影片的形狀會從其繼承類型、位置及部分格式。本地形狀則是獨立的；若沒有基礎佔位元，則不會套用繼承。

**如何在不遍歷每張投影片的情況下，更新整個簡報的所有標題或說明文字？**

在佈局或母片上編輯相應的佔位元。以這些佈局／母片為基礎的投影片將自動繼承此變更。

**如何控制標準的頁首/頁尾佔位元——日期與時間、投影片編號與頁尾文字？**

在適當的範圍（一般投影片、佈局、母片、備註/講義）使用 HeaderFooter 管理器，以開啟或關閉這些佔位元，並設定其內容。