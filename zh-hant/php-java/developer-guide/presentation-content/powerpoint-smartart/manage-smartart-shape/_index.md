---
title: 使用 PHP 管理簡報中的 SmartArt 圖形
linktitle: SmartArt 圖形
type: docs
weight: 20
url: /zh-hant/php-java/manage-smartart-shape/
keywords:
- SmartArt 物件
- SmartArt 圖形
- SmartArt 樣式
- SmartArt 顏色
- 建立 SmartArt
- 新增 SmartArt
- 編輯 SmartArt
- 變更 SmartArt
- 存取 SmartArt
- SmartArt 版面配置類型
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 在 PHP 中自動化 PowerPoint SmartArt 的建立、編輯與樣式設定，提供簡潔的程式碼範例與以效能為導向的指引。"
---
## **概觀**

Aspose.Slides 允許您以程式方式在 PowerPoint 簡報中建立和管理 SmartArt 圖形。本篇說明如何將 SmartArt 形狀加入投影片、存取現有的 SmartArt 形狀、依特定版面配置類型尋找 SmartArt，並透過變更 SmartArt 樣式或色彩樣式來更新其外觀。  
範例示範如何透過簡報投影片的形狀集合來操作 SmartArt 形狀，檢查形狀是否為 SmartArt，並進一步修改或檢查其屬性。

## **建立 SmartArt 形狀**
Aspose.Slides for PHP via Java 已提供建立 SmartArt 形狀的 API。若要在投影片中建立 SmartArt 形狀，請遵循下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
2. 使用索引取得投影片的參考。
3. 使用 [Add a SmartArt shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/#addSmartArt) 並設定其 [LayoutType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SmartArtLayoutType) 以新增 SmartArt 形狀。
4. 將修改後的簡報儲存為 PPTX 檔案。

```php
  # 實例化 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 新增 Smart Art 形狀
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # 儲存簡報
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**圖示：已新增至投影片的 SmartArt 形狀**|

## **在投影片上存取 SmartArt 形狀**
以下程式碼將用於存取簡報投影片中加入的 SmartArt 形狀。在範例程式碼中，我們會遍歷投影片內的每個形狀，檢查它是否為 [SmartArt] 形狀。若形狀屬於 SmartArt 類型，則會將其型別轉換為 [**SmartArt**] 實例。

```php
  # 載入所需的簡報
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # 遍歷第一張投影片內的每個形狀
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # 檢查形狀是否為 SmartArt 類型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 將形狀型別轉換為 SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **以特定版面配置類型存取 SmartArt 形狀**
以下範例程式碼可協助存取具有特定 LayoutType 的 [SmartArt] 形狀。請注意，SmartArt 的 LayoutType 為唯讀，僅在新增 [SmartArt] 形狀時設定，無法變更。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例，並載入含有 SmartArt 形狀的簡報。
2. 使用索引取得第一張投影片的參考。
3. 遍歷第一張投影片內的每個形狀。
4. 檢查形狀是否為 [SmartArt] 類型，若是則將選取的形狀型別轉換為 SmartArt。
5. 檢查具有特定 LayoutType 的 SmartArt 形狀，並執行後續所需的操作。

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # 遍歷第一張投影片內的每個形狀
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # 檢查形狀是否為 SmartArt 類型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 將形狀型別轉換為 SmartArtEx
        $smart = $shape;
        # 檢查 SmartArt 版面配置
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **變更 SmartArt 形狀樣式**
在本範例中，我們將學習如何為任意 SmartArt 形狀變更快速樣式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例，並載入含有 SmartArt 形狀的簡報。
2. 使用索引取得第一張投影片的參考。
3. 遍歷第一張投影片內的每個形狀。
4. 檢查形狀是否為 [SmartArt] 類型，若是則將選取的形狀型別轉換為 SmartArt。
5. 尋找具有特定 Style 的 SmartArt 形狀。
6. 為 SmartArt 形狀設定新的 Style。
7. 儲存簡報。

```php
  # 實例化 Presentation 類別
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 取得第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 遍歷第一張投影片內的每個形狀
    foreach($slide->getShapes() as $shape) {
      # 檢查形狀是否為 SmartArt 類型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 將形狀型別轉換為 SmartArtEx
        $smart = $shape;
        # 檢查 SmartArt 樣式
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # 變更 SmartArt 樣式
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # 儲存簡報
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**圖示：已變更 Style 的 SmartArt 形狀**|

## **變更 SmartArt 形狀色彩樣式**
在本範例中，我們將學習如何為任意 SmartArt 形狀變更色彩樣式。以下範例程式碼會存取具有特定色彩樣式的 SmartArt 形狀，並變更其樣式。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例，並載入含有 SmartArt 形狀的簡報。
2. 使用索引取得第一張投影片的參考。
3. 遍歷第一張投影片內的每個形狀。
4. 檢查形狀是否為 [SmartArt] 類型，若是則將選取的形狀型別轉換為 SmartArt。
5. 尋找具有特定 Color Style 的 SmartArt 形狀。
6. 為 SmartArt 形狀設定新的 Color Style。
7. 儲存簡報。

```php
  # 實例化 Presentation 類別
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # 取得第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 遍歷第一張投影片內的每個形狀
    foreach($slide->getShapes() as $shape) {
      # 檢查形狀是否為 SmartArt 類型
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # 將形狀型別轉換為 SmartArtEx
        $smart = $shape;
        # 檢查 SmartArt 色彩類型
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # 變更 SmartArt 色彩類型
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # 儲存簡報
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**圖示：已變更 Color Style 的 SmartArt 形狀**|

## **常見問題**

**我可以將 SmartArt 作為單一物件進行動畫設定嗎？**

可以。SmartArt 本身即為形狀，您可以像對其他形狀一樣，透過動畫 API 套用[標準動畫](/slides/zh-hant/php-java/powerpoint-animation/)（進入、退出、強調、移動路徑）。

**如果不知道內部 ID，我該如何在投影片上找到特定的 SmartArt？**

請設定並使用替代文字 (AltText)，並依該值搜尋形狀——這是定位目標形狀的建議做法。

**我可以將 SmartArt 與其他形狀群組嗎？**

可以。您可以將 SmartArt 與其他形狀（圖片、表格等）群組，然後[操作該群組](/slides/zh-hant/php-java/group/)。

**我要如何取得特定 SmartArt 的影像（例如用於預覽或報告）？**

匯出該形狀的縮圖/影像；此函式庫可將[個別形狀渲染](/slides/zh-hant/php-java/create-shape-thumbnails/)為點陣檔（PNG/JPG/TIFF）。

**將整個簡報轉換為 PDF 時，SmartArt 的外觀會被保留嗎？**

會。渲染引擎針對[PDF 匯出](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)提供高保真度，並具備多種品質與相容性選項。