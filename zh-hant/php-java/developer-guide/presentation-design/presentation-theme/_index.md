---
title: 在 PHP 中管理簡報主題
linktitle: 簡報主題
type: docs
weight: 10
url: /zh-hant/php-java/presentation-theme/
keywords:
- PowerPoint 主題
- 簡報主題
- 投影片主題
- 設定主題
- 變更主題
- 管理主題
- 主題顏色
- 額外調色盤
- 主題字型
- 主題樣式
- 主題效果
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "透過 Java 使用 Aspose.Slides for PHP 來管理簡報主題，建立、客製化並轉換具一致品牌形象的 PowerPoint 檔案。"
---
## **簡介**

簡報主題定義設計元素的屬性。當您選擇簡報主題時，實際上就是在挑選一組特定的視覺元素及其屬性。

在 PowerPoint 中，主題包含顏色、[字型](/slides/zh-hant/php-java/powerpoint-fonts/)、[背景樣式](/slides/zh-hant/php-java/presentation-background/)以及效果。

![主題構成要素](theme-constitituents.png)

## **變更主題顏色**

PowerPoint 主題為投影片上的不同元素使用一組特定的顏色。如果您不喜歡這些顏色，可以透過套用新顏色來變更主題顏色。為了讓您選取新的主題顏色，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SchemeColor) 列舉中提供了相應的值。

以下 PHP 程式碼示範如何變更主題的重點色彩：

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

您可以透過以下方式取得結果顏色的實際值：

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

為了更進一步示範顏色變更的操作，我們會建立另一個元素，並將先前作業中的重點色彩指派給它。接著在主題中變更顏色：

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```

新顏色會自動套用到兩個元素上。

### **從額外調色盤設定主題顏色**

當您對主要主題顏色(1)套用亮度變換時，會產生來自額外調色盤(2)的顏色。之後您即可設定與取得這些主題顏色。

![額外調色盤顏色](additional-palette-colors.png)

**1** - 主要主題顏色

**2** - 來自額外調色盤的顏色。

以下 PHP 程式碼示範一個操作，從主要主題顏色取得額外調色盤的顏色，並在圖形中使用它們：

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 強調色 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # 強調色 4，亮度提升 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # 強調色 4，亮度提升 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # 強調色 4，亮度提升 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # 強調色 4，較暗 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # 強調色 4，較暗 50%
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **將 `SchemeColor` 映射到 `ColorScheme` 顏色**

當您使用 [SchemeColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/schemecolor/) 時，可能會注意到它包含以下主題顏色值：

`Background1`, `Background2`, `Text1`, and `Text2`.

然而，`Presentation::getMasterTheme()::getColorScheme()` 會回傳 [ColorScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/colorscheme/)，其以以下方式揭露對應的顏色：

`Dark1`, `Dark2`, `Light1`, and `Light2`.

這個差異僅在於命名。這些值指向相同的主題顏色槽，且映射是固定的：

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

在 `Text`/`Background` 與 `Dark`/`Light` 之間沒有動態轉換。它們僅是相同主題顏色的替代名稱。

此命名差異源自 Microsoft Office 的術語。較舊的 Office 版本使用 `Dark 1`、`Light 1`、`Dark 2`、`Light 2`，而較新的 UI 版本則將相同的槽位顯示為 `Text 1`、`Background 1`、`Text 2`、`Background 2`。

## **變更主題字型**

為了讓您為主題及其他用途選取字型，Aspose.Slides 使用以下特殊識別碼（類似 PowerPoint 中的使用方式）：

* **+mn-lt** - 內文字型 Latin（次要 Latin 字型）
* **+mj-lt** - 標題字型 Latin（主要 Latin 字型）
* **+mn-ea** - 內文字型 東亞（次要 東亞 字型）
* **+mj-ea** - 內文字型 東亞（主要 東亞 字型）

以下 PHP 程式碼示範如何將 Latin 字型指派給主題元素：

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

以下 PHP 程式碼示範如何變更簡報主題字型：

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

所有文字方塊中的字型都會更新。

{{% alert color="primary" title="TIP" %}} 您可能想看看 [PowerPoint 字型](/slides/zh-hant/php-java/powerpoint-fonts/)。 {{% /alert %}}

## **變更主題背景樣式**

預設情況下，PowerPoint 應用程式提供 12 種預定義背景，但在一般簡報中僅會保存其中的 3 種背景。

![todo:image_alt_text](presentation-design_8.png)

例如，當您在 PowerPoint 應用程式中儲存簡報後，您可以執行以下 PHP 程式碼來查詢簡報中預定義背景的數量：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 使用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FormatScheme) 類別的 [BackgroundFillStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) 屬性，您可以在 PowerPoint 主題中新增或存取背景樣式。 {{% /alert %}}

以下 PHP 程式碼示範如何為簡報設定背景：

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**索引說明**：0 表示無填充。索引從 1 開始。

{{% alert color="primary" title="TIP" %}} 您可能想看看 [PowerPoint 背景](/slides/zh-hant/php-java/presentation-background/)。 {{% /alert %}}

## **變更主題效果**

PowerPoint 主題通常為每個樣式陣列包含 3 個值。這些陣列會結合成 3 種效果：細膩、適中與強烈。例如，將效果套用至特定圖形時的結果如下：

![todo:image_alt_text](presentation-design_10.png)

使用來自 [FormatScheme](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FormatScheme) 類別的 3 個屬性（[FillStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FormatScheme#getEffectStyles--)），您可以變更主題中的元素（比 PowerPoint 的選項更具彈性）。

以下 PHP 程式碼示範如何透過變更元素的部分屬性來調整主題效果：

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

結果會在填色、填充類型、陰影效果等方面產生變化：

![todo:image_alt_text](presentation-design_11.png)

## **常見問題**

**我可以在不更改母片的情況下將主題套用到單一投影片嗎？**

可以。Aspose.Slides 支援投影片層級的主題覆寫，您可以僅在該投影片上套用本地主題，同時保持母片主題不變（透過 [SlideThemeManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidethememanager/)）。

**將主題從一個簡報安全地搬移到另一個簡報的最佳方式是什麼？**

[Clone slides](/slides/zh-hant/php-java/clone-slides/) 與其母片一起複製至目標簡報。這樣可保留原始母片、版面配置以及相關的主題，確保外觀保持一致。

**如何在所有繼承與覆寫之後查看「實際」值？**

使用 API 的[「實際」檢視](/slides/zh-hant/php-java/shape-effective-properties/)（主題/顏色/字型/效果），可取得套用母片及任何本地覆寫後解析出的最終屬性。