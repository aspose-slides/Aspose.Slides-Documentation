---
title: AndroidでAutoFitを使用してプレゼンテーションを強化する
linktitle: AutoFit 設定
type: docs
weight: 30
url: /ja/androidjava/manage-autofit-settings/
keywords:
- テキストボックス
- AutoFit
- AutoFitしない
- テキストに合わせる
- テキストを縮小する
- テキストを折り返す
- シェイプのサイズ変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android（Java）でAutoFit設定を管理し、PowerPoint および OpenDocument のプレゼンテーションでテキスト表示を最適化し、コンテンツの可読性を向上させます。"
---

デフォルトでは、テキストボックスを追加すると、Microsoft PowerPoint はそのテキストボックスに対して **Resize shape to fix text** 設定を使用します。テキストが常に収まるように、テキストボックスのサイズが自動的に調整されます。 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* テキストボックス内のテキストが長くまたは大きくなると、PowerPoint はテキストボックスを自動的に拡大（高さを増加）して、より多くのテキストを収められるようにします。 
* テキストボックス内のテキストが短くまたは小さくなると、PowerPoint はテキストボックスを自動的に縮小（高さを減少）し、余分な空間を取り除きます。 

PowerPoint では、テキストボックスの自動調整動作を制御する重要な 4 つのパラメータまたはオプションがあります：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java でも同様のオプションが提供されており、[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) クラスのいくつかのプロパティを使用して、プレゼンテーション内のテキストボックスの自動調整動作を制御できます。

## **テキストに合わせてシェイプのサイズを変更**

テキストが変更された後も常にボックスに収まるようにしたい場合は、**Resize shape to fix text** オプションを使用する必要があります。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) クラスの [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) プロパティを `Shape` に設定します。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

この Java コードは、PowerPoint プレゼンテーションでテキストが常にボックスに収まるように指定する方法を示しています:
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


テキストが長くまたは大きくなると、テキストボックスは自動的にサイズが変更され（高さが増加）すべてのテキストが収まるようになります。テキストが短くなると、逆の動作が行われます。 

## **Do Not Autofit**

テキストボックスやシェイプのサイズを、内部テキストの変更に関係なく保持したい場合は、**Do not Autofit** オプションを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) クラスの [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) プロパティを `None` に設定します。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

この Java コードは、PowerPoint プレゼンテーションでテキストボックスが常にそのサイズを保持するように指定する方法を示しています:
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


テキストがボックスに対して長すぎると、はみ出して表示されます。 

## **Shrink Text on Overflow**

テキストがボックスに対して長くなると、**Shrink text on overflow** オプションを使用して、テキストのサイズと間隔を縮小し、ボックスに収めることができます。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) クラスの [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) プロパティを `Normal` に設定します。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

この Java コードは、PowerPoint プレゼンテーションでテキストがオーバーフローしたときに縮小するように指定する方法を示しています:
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
**Shrink text on overflow** オプションが使用されると、テキストがボックスに対して長くなった時だけ設定が適用されます。 
{{% /alert %}}

## **Wrap Text**

テキストがシェイプの幅を超えたときに、シェイプ内部で折り返したい場合は、**Wrap text in shape** パラメータを使用します。この設定を指定するには、[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) クラスの [WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) プロパティを `true` に設定します。

この Java コードは、PowerPoint プレゼンテーションで Wrap Text 設定を使用する方法を示しています:
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
シェイプの `WrapText` プロパティを `False` に設定すると、シェイプ内のテキストがシェイプの幅を超えたときに、テキストは単一行でシェイプの境界を超えて伸びます。 
{{% /alert %}}

## **FAQ**

**Do the text frame’s internal margins affect AutoFit?**  
テキストフレームの内部余白は AutoFit に影響しますか？  

はい。パディング（内部余白）はテキストの使用可能領域を減らすため、AutoFit が早めに作動し、フォントが縮小したりシェイプがリサイズされたりします。AutoFit を調整する前に余白を確認し、必要に応じて調整してください。  

**How does AutoFit interact with manual and soft line breaks?**  
AutoFit は手動およびソフト改行とどのように連携しますか？  

強制改行はそのまま残り、AutoFit はそれらの周囲でフォントサイズと間隔を調整します。不要な改行を削除すると、AutoFit がテキストを縮小する必要性が低減します。  

**Does changing the theme font or triggering font substitution affect AutoFit results?**  
テーマフォントの変更やフォント置換は AutoFit の結果に影響しますか？  

はい。異なるグリフメトリックを持つフォントに置換すると、テキストの幅や高さが変わり、最終的なフォントサイズや改行に影響します。フォントを変更または置換した後は、スライドを再確認してください。