---
title: PHP で AutoFit を使用してプレゼンテーションを強化する
linktitle: AutoFit 設定
type: docs
weight: 30
url: /ja/php-java/manage-autofit-settings/
keywords:
- テキストボックス
- AutoFit
- AutoFit なし
- テキストに合わせる
- テキストを縮小
- テキストを折り返す
- 図形のサイズ変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP の AutoFit 設定を管理し、PowerPoint および OpenDocument プレゼンテーションでテキスト表示を最適化し、コンテンツの可読性を向上させます。"
---

既定では、テキストボックスを追加すると、Microsoft PowerPoint はテキストボックスに対して **Resize shape to fix text** 設定を使用します。テキストボックスは自動的にサイズが変更され、テキストが常に収まるようになります。 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* テキストボックス内のテキストが長くまたは大きくなると、PowerPoint はテキストボックスの高さを増やして自動的に拡大し、より多くのテキストを保持できるようにします。 
* テキストボックス内のテキストが短くまたは小さくなると、PowerPoint はテキストボックスの高さを減らして自動的に縮小し、余分なスペースを除去します。 

PowerPoint では、テキストボックスの自動調整動作を制御する重要なパラメーターまたはオプションが 4 つあります: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Java は、[TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) クラスのいくつかのプロパティとして、プレゼンテーション内のテキストボックスの自動調整動作を制御できる同様のオプションを提供します。

## **Resize a Shape to Fit Text**

テキストが変更された後も常にボックスに収まるようにするには、**Resize shape to fix text** オプションを使用する必要があります。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) クラスの [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) プロパティを `Shape` に設定します。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

この PHP コードは、PowerPoint プレゼンテーションでテキストが常にボックスに収まるように指定する方法を示しています:
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


テキストが長くまたは大きくなると、テキストボックスは自動的に高さが増えてリサイズされ、すべてのテキストが収まります。テキストが短くなると、その逆が行われます。 

## **Do Not Autofit**

テキストボックスまたは図形がテキストの変更に関係なくサイズを保持するようにするには、**Do not Autofit** オプションを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) クラスの [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) プロパティを `None` に設定します。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

この PHP コードは、PowerPoint プレゼンテーションでテキストボックスが常にサイズを保持するように指定する方法を示しています:
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


テキストがボックスに対して長すぎると、テキストははみ出します。 

## **Shrink Text on Overflow**

テキストがボックスに対して長すぎる場合、**Shrink text on overflow** オプションを使用して、テキストのサイズと行間を縮小し、ボックスに収めることができます。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) クラスの [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) プロパティを `Normal` に設定します。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

この PHP コードは、PowerPoint プレゼンテーションでテキストが溢れたときに縮小されるように指定する方法を示しています:
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


{{% alert title="Info" color="info" %}}
**Shrink text on overflow** オプションが使用されると、テキストがボックスに対して長くなったときのみ設定が適用されます。 
{{% /alert %}}

## **Wrap Text**

テキストが図形の幅を超えたときに、その図形内で折り返すようにしたい場合は、**Wrap text in shape** パラメーターを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) クラスの [WrapText](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getWrapText--) プロパティを `true` に設定します。

この PHP コードは、PowerPoint プレゼンテーションで Wrap Text 設定を使用する方法を示しています:
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


{{% alert title="Note" color="warning" %}} 
`WrapText` プロパティを `False` に設定した図形では、テキストが図形の幅を超えると、テキストは単一行で図形の枠を超えて伸びます。 
{{% /alert %}}

## **FAQ**

**テキストフレームの内部余白は AutoFit に影響しますか？**

はい。余白（内部マージン）はテキストの使用可能領域を減らすため、AutoFit がより早く発動し、フォントが縮小されたり図形がリサイズされたりします。AutoFit を調整する前に余白を確認し、必要に応じて調整してください。

**AutoFit は手動改行やソフト改行とどのように連動しますか？**

強制改行はそのまま残り、AutoFit はそれらの周囲でフォントサイズや行間を調整します。不要な改行を削除すると、AutoFit がテキストを縮小する必要が減少することがあります。

**テーマフォントの変更やフォント置換は AutoFit の結果に影響しますか？**

はい。異なる字形メトリクスを持つフォントに置換すると、テキストの幅や高さが変わり、最終的なフォントサイズや行折り返しが変わる可能性があります。フォントを変更または置換した後は、スライドを再確認してください。