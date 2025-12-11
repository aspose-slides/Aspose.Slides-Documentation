---
title: Android での AutoFit によるプレゼンテーションの強化
linktitle: Autofit 設定
type: docs
weight: 30
url: /ja/androidjava/manage-autofit-settings/
keywords:
- テキストボックス
- オートフィット
- オートフィットしない
- テキストに合わせる
- テキストを縮小
- テキストの折り返し
- シェイプのサイズ変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java で AutoFit 設定を管理し、PowerPoint および OpenDocument のプレゼンテーションにおけるテキスト表示を最適化し、コンテンツの可読性を向上させます。"
---

デフォルトでは、テキストボックスを追加すると、Microsoft PowerPoint はテキストボックスに対して **Resize shape to fix text** 設定を使用します。テキストが常に収まるようにテキストボックスのサイズを自動的に変更します。

![PowerPoint のテキストボックス](textbox-in-powerpoint.png)

* テキストボックス内のテキストが長くまたは大きくなると、PowerPoint はテキストボックスを自動的に拡大（高さを増加）し、より多くのテキストを収められるようにします。  
* テキストボックス内のテキストが短くまたは小さくなると、PowerPoint はテキストボックスを自動的に縮小（高さを減少）し、余分なスペースを除去します。  

PowerPoint では、テキストボックスの自動調整動作を制御する重要なパラメーターまたはオプションが 4 つあります：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![PowerPoint の自動調整オプション](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java は、プレゼンテーション内のテキストボックスの自動調整動作を制御できる類似のオプション（[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) クラスの一部プロパティ）を提供します。

## **テキストに合わせてシェイプをサイズ変更**

テキストが常にボックス内に収まるようにしたい場合は、**Resize shape to fix text** オプションを使用する必要があります。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) クラスから）を `Shape` に設定します。

![常にフィットする設定 (PowerPoint)](alwaysfit-setting-powerpoint.png)

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


テキストが長くまたは大きくなると、テキストボックスは自動的にサイズ変更（高さが増加）され、すべてのテキストが収まります。テキストが短くなると、逆の動作が行われます。

## **自動調整しない**

テキストの変更に関係なくテキストボックスやシェイプのサイズを保持したい場合は、**Do not Autofit** オプションを使用する必要があります。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) クラスから）を `None` に設定します。

![自動調整しない設定 (PowerPoint)](donotautofit-setting-powerpoint.png)

この Java コードは、PowerPoint プレゼンテーションでテキストボックスが常にそのサイズを保持するように指定する方法を示しています：
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


テキストがボックスに対して長すぎると、テキストがはみ出します。

## **オーバーフロー時にテキストを縮小**

テキストがボックスに対して長すぎると、**Shrink text on overflow** オプションを使用して、テキストのサイズと間隔を縮小し、ボックスに収めることができます。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) クラスから）を `Normal` に設定します。

![オーバーフロー時にテキストを縮小設定 (PowerPoint)](shrinktextonoverflow-setting-powerpoint.png)

この Java コードは、PowerPoint プレゼンテーションでテキストがオーバーフロー時に縮小されるように指定する方法を示しています：
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
**Shrink text on overflow** オプションが使用されると、設定はテキストがボックスに対して長すぎる場合にのみ適用されます。
{{% /alert %}}

## **テキストの折り返し**

テキストがシェイプの境界（幅のみ）を超えたときに、テキストをシェイプ内部で折り返したい場合は、**Wrap text in shape** パラメーターを使用します。この設定を指定するには、[WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) クラスから）を `true` に設定します。

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
シェイプに対して `WrapText` プロパティを `False` に設定すると、シェイプ内部のテキストがシェイプの幅を超えると、テキストは単一行でシェイプの境界を超えて伸びます。 
{{% /alert %}}

## **FAQ**

**テキスト フレームの内部余白は AutoFit に影響しますか？**

はい。パディング（内部余白）によりテキストの使用可能領域が減少するため、AutoFit はより早く作動し、フォントを縮小したりシェイプのサイズを変更したりします。AutoFit を調整する前に余白を確認し、必要に応じて調整してください。

**AutoFit は手動およびソフト改行とどのように連動しますか？**

強制改行はそのまま残り、AutoFit はその周辺でフォントサイズと間隔を調整します。不要な改行を削除すると、AutoFit がテキストを縮小する力度が軽減されることが多いです。

**テーマ フォントの変更やフォント置換は AutoFit の結果に影響しますか？**

はい。異なるグリフメトリックを持つフォントに置換えると、テキストの幅・高さが変わり、最終的なフォントサイズや改行に影響します。フォント変更や置換の後は、スライドを再確認してください。