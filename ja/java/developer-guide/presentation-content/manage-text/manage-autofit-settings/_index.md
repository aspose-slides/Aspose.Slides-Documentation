---
title: Java の AutoFit でプレゼンテーションを強化する
linktitle: AutoFit 設定
type: docs
weight: 30
url: /ja/java/manage-autofit-settings/
keywords:
- テキストボックス
- AutoFit
- 自動調整しない
- テキストをフィットさせる
- テキストを縮小する
- テキストを折り返す
- シェイプのサイズ変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java で AutoFit 設定を管理し、PowerPoint および OpenDocument プレゼンテーションのテキスト表示を最適化してコンテンツの可読性を向上させる方法を学びます。"
---

デフォルトでは、テキストボックスを追加すると、Microsoft PowerPoint はテキストボックスに対して **Resize shape to fix text** 設定を使用します。テキストが常に収まるようにテキストボックスのサイズが自動的に調整されます。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* テキストが長くなるまたは大きくなると、PowerPoint はテキストボックスの高さを増やして自動的に拡大し、より多くのテキストを収められるようにします。  
* テキストが短くなるまたは小さくなると、PowerPoint はテキストボックスの高さを減らして自動的に縮小し、余分なスペースを削除します。

PowerPoint では、テキストボックスの自動調整動作を制御する 4 つの重要なパラメータまたはオプションがあります。

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java は、プレゼンテーション内のテキストボックスの自動調整動作を制御できる、[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) クラスのいくつかのプロパティという形で、同様のオプションを提供します。

## **Resize Shape to Fit Text**

テキストが変更された後も常にテキストがボックスに収まるようにしたい場合は、**Resize shape to fix text** オプションを使用する必要があります。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) クラスの [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) プロパティを `Shape` に設定します。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

この Java コードは、PowerPoint プレゼンテーションでテキストが常にボックスに収まるように指定する方法を示しています：
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


テキストが長くなるまたは大きくなると、テキストボックスは自動的に高さが増えてリサイズされ、すべてのテキストが収まります。テキストが短くなると、逆の動作が行われます。

## **Do Not Autofit**

テキストの変更にかかわらずテキストボックスまたはシェイプのサイズを保持したい場合は、**Do not Autofit** オプションを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) クラスの [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) プロパティを `None` に設定します。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

この Java コードは、PowerPoint プレゼンテーションでテキストボックスが常にサイズを保持するように指定する方法を示しています：
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


テキストがボックスに対して長すぎる場合、はみ出します。

## **Shrink Text on Overflow**

テキストがボックスに対して長すぎる場合、**Shrink text on overflow** オプションを使用して、テキストのサイズと間隔を縮小し、ボックスに収めることができます。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) クラスの [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) プロパティを `Normal` に設定します。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

この Java コードは、PowerPoint プレゼンテーションでテキストが溢れたときに縮小されるように指定する方法を示しています：
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Info" color="info" %}}
**Shrink text on overflow** オプションが使用されると、設定はテキストがボックスに対して長すぎるときにのみ適用されます。
{{% /alert %}}

## **Wrap Text**

テキストがシェイプの幅を超えたときに、シェイプ内でテキストを折り返したい場合は、**Wrap text in shape** パラメータを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) クラスの [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) プロパティを `true` に設定します。

この Java コードは、PowerPoint プレゼンテーションで Wrap Text 設定を使用する方法を示しています：
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Note" color="warning" %}}
シェイプの `WrapText` プロパティを `False` に設定すると、シェイプ内のテキストがシェイプの幅より長くなった場合でも、テキストは単一行でシェイプの境界を超えて伸びます。
{{% /alert %}}

## **FAQ**

**テキストフレームの内部余白は AutoFit に影響しますか？**

はい。パディング（内部余白）はテキストの使用可能領域を減らすため、AutoFit が早期に作動し、フォントが縮小されたりシェイプがリサイズされたりします。AutoFit を調整する前に余白を確認・調整してください。

**AutoFit は手動改行やソフト改行とどのように連動しますか？**

強制改行はそのまま保持され、AutoFit はそれらの周囲でフォントサイズと間隔を調整します。不要な改行を削除すると、AutoFit がテキストを縮小する頻度が減少します。

**テーマフォントの変更やフォント置換は AutoFit の結果に影響しますか？**

はい。異なる字形メトリクスを持つフォントに置換するとテキストの幅・高さが変わり、最終的なフォントサイズや改行が変化します。フォントを変更または置換した後は、スライドを再確認してください。