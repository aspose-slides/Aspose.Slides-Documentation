---
title: 自動サイズ設定の管理
type: docs
weight: 30
url: /php-java/manage-autofit-settings/
keywords: "テキストボックス, 自動サイズ, PowerPoint プレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPoint のテキストボックスの自動サイズ設定を設定する"
---

デフォルトでは、テキストボックスを追加すると、Microsoft PowerPointはテキストボックスに対して**テキストに合わせて形状をサイズ変更**設定を使用します。これにより、テキストボックスが自動的にサイズ変更され、テキストが常に収まるようになります。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* テキストボックス内のテキストが長くなるか大きくなると、PowerPointは自動的にテキストボックスを拡大し、高さを増加させてより多くのテキストを保持できるようにします。
* テキストボックス内のテキストが短くなるか小さくなると、PowerPointは自動的にテキストボックスを縮小し、高さを減少させて余分なスペースをクリアします。

PowerPointでは、テキストボックスの自動サイズ動作を制御するための4つの重要なパラメータまたはオプションがあります：

* **自動サイズしない**
* **オーバーフロー時にテキストを縮小**
* **テキストに合わせて形状をサイズ変更**
* **形状内でテキストを折り返す。**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Javaは、プレゼンテーション内のテキストボックスの自動サイズ動作を制御するための類似のオプションを提供します。これには、[TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)クラスのいくつかのプロパティが含まれます。

## **テキストに合わせて形状をサイズ変更**

テキストが変更された後も、常にテキストがボックスに収まるようにしたい場合は、**テキストに合わせて形状をサイズ変更**オプションを使用する必要があります。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--)プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)クラスから）を`Shape`に設定します。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

このPHPコードは、PowerPointプレゼンテーション内でテキストが常にボックスに収まるように指定する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

テキストが長くなるか大きくなると、テキストボックスは自動的にサイズが変更され（高さが増加）、すべてのテキストがその中に収まります。テキストが短くなると、その逆が起こります。

## **自動サイズしない**

テキストボックスまたは形状の内部にあるテキストに変更が加えられてもその寸法を維持したい場合は、**自動サイズしない**オプションを使用する必要があります。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--)プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)クラスから）を`None`に設定します。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

このPHPコードは、PowerPointプレゼンテーション内でテキストボックスが常にその寸法を維持するように指定する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

テキストがボックスに対して長すぎる場合、テキストは溢れ出します。

## **オーバーフロー時にテキストを縮小**

テキストがボックスに対して長すぎる場合、**オーバーフロー時にテキストを縮小**オプションを使用することで、テキストのサイズと間隔を減少させてボックスに収まるように指定できます。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--)プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)クラスから）を`Normal`に設定します。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

このPHPコードは、PowerPointプレゼンテーション内でテキストがオーバーフロー時に縮小されるように指定する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="情報" color="info" %}}

**オーバーフロー時にテキストを縮小**オプションが使用されると、設定はテキストがボックスに対して長すぎる場合にのみ適用されます。

{{% /alert %}}

## **テキストを折り返す**

テキストが形状の境界（幅）の外に出た場合に、形状の内部にテキストを折り返したい場合は、**形状内でテキストを折り返す**パラメータを使用する必要があります。この設定を指定するには、[WrapText](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getWrapText--)プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)クラスから）を`true`に設定する必要があります。

このPHPコードは、PowerPointプレゼンテーション内でテキストを折り返す設定を使用する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}}

形状に対して`WrapText`プロパティを`False`に設定すると、形状内のテキストが形状の幅よりも長くなると、テキストは単一行で形状の境界を超えて拡張されます。

{{% /alert %}}