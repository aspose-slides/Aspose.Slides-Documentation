---
title: オートフィット設定を管理
type: docs
weight: 30
url: /ja/nodejs-java/manage-autofit-settings/
keywords: "テキストボックス、オートフィット、PowerPointプレゼンテーション、Java、Aspose.Slides for Node.js via Java"
description: "JavaScriptでPowerPointのテキストボックスのオートフィット設定を設定する"
---

デフォルトでは、テキストボックスを追加すると、Microsoft PowerPoint はテキストボックスに対して **Resize shape to fix text** 設定を使用します。テキストが常に収まるように、テキストボックスのサイズを自動的に変更します。 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* テキストボックス内のテキストが長くまたは大きくなると、PowerPoint は自動的にテキストボックスを拡大（高さを増やす）して、より多くのテキストを収められるようにします。 
* テキストボックス内のテキストが短くまたは小さくなると、PowerPoint は自動的にテキストボックスを縮小（高さを減らす）して、余分なスペースを取り除きます。 

PowerPoint では、テキストボックスの自動調整動作を制御する 4 つの重要なパラメータまたはオプションがあります：

* **自動調整しない**
* **溢れ時にテキストを縮小**
* **テキストに合わせてシェイプのサイズを変更**
* **シェイプ内でテキストを折り返す**.

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java は、プレゼンテーション内のテキストボックスの自動調整動作を制御できる、[TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) クラスのいくつかのプロパティなど、同様のオプションを提供します。

## **テキストに合わせてシェイプのサイズを変更**

テキストが変更された後も常にボックスに収まるようにするには、**Resize shape to fix text** オプションを使用する必要があります。この設定を指定するには、`Shape` 値で [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) メソッドを [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) クラスから呼び出します。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

以下の JavaScript コードは、PowerPoint プレゼンテーションでテキストが常にボックスに収まるように指定する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


テキストが長くまたは大きくなると、テキストボックスは自動的にサイズ変更され（高さが増加し）、すべてのテキストが収まるようになります。テキストが短くなると、その逆が行われます。

## **自動調整しない**

テキストの内容が変わってもテキストボックスやシェイプのサイズを保持したい場合は、**Do not Autofit** オプションを使用する必要があります。この設定を指定するには、`None` 値で [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) メソッドを [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) クラスから呼び出します。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

以下の JavaScript コードは、PowerPoint プレゼンテーションでテキストボックスが常に元のサイズを保持するように指定する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


テキストがボックスに対して長すぎると、テキストがはみ出します。 

## **溢れ時にテキストを縮小**

テキストがボックスに対して長すぎる場合、**Shrink text on overflow** オプションを使用して、テキストのサイズと間隔を縮小し、ボックスに収めるよう指定できます。この設定を指定するには、`Normal` 値で [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) メソッドを [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) クラスから呼び出します。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

以下の JavaScript コードは、PowerPoint プレゼンテーションでテキストが溢れたときに縮小されるよう指定する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Info" color="info" %}}
**Shrink text on overflow** オプションが使用されると、テキストがボックスに対して長すぎる場合にのみ設定が適用されます。 
{{% /alert %}}

## **テキストを折り返す**

テキストがシェイプの境界（幅）のみを超える場合に、シェイプ内部でテキストを折り返したい場合は、**Wrap text in shape** パラメータを使用する必要があります。この設定を指定するには、`true` 値で [setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) メソッドを [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) クラスから呼び出します。

以下の JavaScript コードは、PowerPoint プレゼンテーションで Wrap Text 設定を使用する方法を示しています:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 
`setWrapText` メソッドを `False` 値でシェイプに対して呼び出すと、シェイプ内のテキストがシェイプの幅を超えると、テキストは単一行でシェイプの境界を超えて伸びます。 
{{% /alert %}}

## **FAQ**

**テキストフレームの内部余白は AutoFit に影響しますか？**

はい。パディング（内部余白）はテキストの使用可能領域を減らすため、AutoFit が早期に作動し、フォントが縮小されたりシェイプが再サイズされたりします。AutoFit を調整する前に余白を確認し、必要に応じて調整してください。

**AutoFit は手動およびソフト改行とどのように相互作用しますか？**

強制改行はそのまま残り、AutoFit はそれらの周囲でフォントサイズと間隔を調整します。不要な改行を削除すると、AutoFit がテキストを縮小する度合いが緩和されることが多いです。

**テーマフォントを変更したりフォント置換をトリガーしたりすると、AutoFit の結果に影響しますか？**

はい。異なる字形メトリックを持つフォントに置換すると、テキストの幅や高さが変わり、最終的なフォントサイズや改行に影響します。フォントを変更または置換した後は、スライドを再確認してください。