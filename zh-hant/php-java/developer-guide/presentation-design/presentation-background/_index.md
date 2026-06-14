---
title: 管理 PHP 簡報背景
linktitle: 投影片背景
type: docs
weight: 20
url: /zh-hant/php-java/presentation-background/
keywords:
- 簡報背景
- 投影片背景
- 純色
- 漸層顏色
- 影像背景
- 背景透明度
- 背景屬性
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for PHP via Java 為 PowerPoint 與 OpenDocument 檔案設定動態背景，並提供程式碼技巧以提升您的簡報效果。"
---
## **簡介**

純色、漸層和影像通常用於投影片的背景。您可以為 **普通投影片**（單一投影片）或 **母投影片**（一次套用於多張投影片）設定背景。

![PowerPoint 背景](powerpoint-background.png)

## **設定普通投影片的純色背景**

Aspose.Slides 允許您為簡報中的特定投影片設定純色背景——即使簡報使用了母投影片。此變更僅套用於所選的投影片。

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Solid`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/) 上的 [getSolidFillColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/#getSolidFillColor) 方法來指定純色背景顏色。
5. 儲存已修改的簡報。

以下 PHP 範例示範如何將藍色純色設為普通投影片的背景：

```php
// 建立 Presentation 類別的實例。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 將投影片的背景顏色設定為藍色。
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // 將簡報儲存至磁碟。
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **設定母投影片的純色背景**

Aspose.Slides 允許您為簡報的母投影片設定純色背景。母投影片作為控制所有投影片格式的範本，因此當您為母投影片的背景選擇純色時，該顏色會套用到每一張投影片。

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 將母投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/backgroundtype/)（透過 `getMasters`）設定為 `OwnBackground`。
3. 將母投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Solid`。
4. 使用 [getSolidFillColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/#getSolidFillColor) 方法來指定純色背景顏色。
5. 儲存已修改的簡報。

以下 PHP 範例示範如何將綠色純色設為母投影片的背景：

```php
// 建立 Presentation 類別的實例。
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // 為母投影片設定背景顏色為森林綠。
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // 將簡報儲存至磁碟。
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **設定投影片的漸層背景**

漸層是透過顏色逐漸變化所產生的圖形效果。作為投影片背景使用時，漸層能讓簡報更具藝術感與專業感。Aspose.Slides 允許您為投影片設定漸層顏色作為背景。

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Gradient`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/) 上的 [getGradientFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/#getGradientFormat) 方法來設定您偏好的漸層設定。
5. 儲存已修改的簡報。

以下 PHP 範例示範如何將漸層顏色設為投影片的背景：

```php
// 建立 Presentation 類別的實例。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 為背景套用漸層效果。
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // 將簡報儲存至磁碟。
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **將影像設定為投影片背景**

除了純色與漸層填充外，Aspose.Slides 還允許您使用影像作為投影片背景。

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Picture`。
4. 載入您想用作投影片背景的影像。
5. 將影像加入簡報的影像集合中。
6. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/) 上的 [getPictureFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/#getPictureFillFormat) 方法將影像指派為背景。
7. 儲存已修改的簡報。

以下 PHP 範例示範如何將影像設定為投影片的背景：

```php
// 建立 Presentation 類別的實例。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 設定背景影像屬性。
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // 載入影像。
    $image = Images::fromFile("Tulips.jpg");
    // 將影像加入簡報的影像集合中。
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // 將簡報儲存至磁碟。
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

以下程式碼範例示範如何將背景填充類型設定為平鋪影像並修改平鋪屬性：

```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // 設定用於背景填充的影像。
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // 設定圖片填充模式為平鋪並調整平鋪屬性。
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
閱讀更多： [**平鋪影像作為紋理**](/slides/zh-hant/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **變更背景影像透明度**

您可能需要調整投影片背景影像的透明度，以便突顯投影片內容。以下 PHP 程式碼示範如何變更投影片背景影像的透明度：

```php
$transparencyValue = 30; // 例如。

// 取得圖片變換作業的集合。
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// 尋找現有的固定比例透明度效果。
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// 設定新的透明度值。
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```

## **取得投影片背景值**

Aspose.Slides 提供 `BackgroundEffectiveData` 類別，用於取得投影片的有效背景值。此類別會公開有效的 [FillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fillformat/) 與 [EffectFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/effectformat/)。

使用 [BaseSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslide/) 類別的 `getBackground` 方法，您可以取得投影片的有效背景。

以下 PHP 範例示範如何取得投影片的有效背景值：

```php
// 建立 Presentation 類別的實例。
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 取得有效的背景，考慮母投影片、版面配置與主題。
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**我可以重設自訂背景並恢復主題/版面配置背景嗎？**

是的。移除投影片的自訂填充後，背景會重新從相應的 [版面配置](/slides/zh-hant/php-java/slide-layout/)/[母投影片](/slides/zh-hant/php-java/slide-master/) 投影片（即 [主題背景](/slides/zh-hant/php-java/presentation-theme/)）繼承。

**如果我之後變更簡報的主題，背景會怎樣？**

如果投影片有自己的填充，則不會更改。若背景是從 [版面配置](/slides/zh-hant/php-java/slide-layout/)/[母投影片](/slides/zh-hant/php-java/slide-master/) 繼承的，則會更新以符合 [新主題](/slides/zh-hant/php-java/presentation-theme/)。