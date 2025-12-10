---
title: Java で AutoFit を使用してプレゼンテーションを強化する
linktitle: AutoFit 設定
type: docs
weight: 30
url: /ja/java/manage-autofit-settings/
keywords:
- テキストボックス
- AutoFit
- 自動サイズ調整しない
- テキストに合わせる
- テキストを縮小
- テキストを折り返す
- 図形のサイズを変更
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java で AutoFit 設定を管理し、PowerPoint および OpenDocument プレゼンテーションのテキスト表示を最適化してコンテンツの可読性を向上させる方法を学びます。"
---

既定では、テキストボックスを追加すると、Microsoft PowerPoint はテキストボックスに対して **テキストに合わせて図形のサイズを変更** 設定を使用します。テキストが常に収まるようにテキストボックスのサイズを自動的に調整します。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* テキストボックス内のテキストが長くまたは大きくなると、PowerPoint はテキストボックスを自動的に拡大（高さを増加）し、より多くのテキストを保持できるようにします。
* テキストボックス内のテキストが短くまたは小さくなると、PowerPoint はテキストボックスを自動的に縮小（高さを減少）し、余分なスペースを削除します。

PowerPoint では、テキストボックスの自動調整動作を制御する重要な 4 つのパラメータまたはオプションがあります。

* **自動サイズ調整しない**
* **オーバーフロー時にテキストを縮小**
* **テキストに合わせて図形のサイズを変更**
* **図形内でテキストを折り返す**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java は同様のオプション（[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) クラスの一部プロパティ）を提供し、プレゼンテーション内のテキストボックスに対する自動調整動作を制御できます。

## **テキストに合わせて図形のサイズを変更**

テキストを変更した後もテキストが常にボックス内に収まるようにしたい場合は、**テキストに合わせて図形のサイズを変更** オプションを使用する必要があります。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) クラス）を `Shape` に設定します。

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


テキストが長くまたは大きくなると、テキストボックスは自動的にサイズ変更（高さを増加）され、すべてのテキストが収まるようになります。テキストが短くなると、逆の動作が行われます。

## **自動サイズ調整しない**

テキストの変更に関係なくテキストボックスまたは図形のサイズを保持したい場合は、**自動サイズ調整しない** オプションを使用する必要があります。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) クラス）を `None` に設定します。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

この Java コードは、PowerPoint プレゼンテーションでテキストボックスが常にサイズを保持するように指定する方法を示しています:
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


テキストがボックスに対して長すぎると、はみ出します。

## **オーバーフロー時にテキストを縮小**

テキストがボックスに対して長すぎる場合、**オーバーフロー時にテキストを縮小** オプションにより、テキストのサイズと間隔を縮小してボックスに収めるよう指定できます。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) クラス）を `Normal` に設定します。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

この Java コードは、PowerPoint プレゼンテーションでテキストをオーバーフロー時に縮小するように指定する方法を示しています:
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
**オーバーフロー時にテキストを縮小** オプションが使用されると、テキストがボックスに対して長すぎる場合にのみ設定が適用されます。
{{% /alert %}}

## **テキストを折り返す**

テキストが形状の枠（幅）を超えたときに、形状内でテキストを折り返したい場合は、**図形内でテキストを折り返す** パラメータを使用する必要があります。この設定を指定するには、[WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) クラス）を `true` に設定します。

この Java コードは、PowerPoint プレゼンテーションでテキスト折り返し設定を使用する方法を示しています:
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
形状の `WrapText` プロパティを `False` に設定すると、形状内のテキストが幅を超えた場合、テキストは単一行で形状の境界を超えて延長されます。
{{% /alert %}}

## **FAQ**

**テキスト フレームの内部余白は AutoFit に影響しますか？**

はい。パディング（内部余白）はテキストの使用可能領域を減らすため、AutoFit が早めに作動し、フォントを縮小したり図形を再サイズしたりします。AutoFit を調整する前に余白を確認・調整してください。

**AutoFit は手動およびソフト改行とどのように連動しますか？**

強制改行はそのまま保持され、AutoFit はそれらの周囲でフォントサイズと間隔を調整します。不要な改行を削除すると、AutoFit がテキストを縮小する度合いが緩和されることが多いです。

**テーマフォントの変更やフォント置換は AutoFit の結果に影響しますか？**

はい。異なる字形メトリクスを持つフォントに置換すると、テキストの幅や高さが変わり、最終的なフォントサイズや改行に影響します。フォント変更や置換を行った後は、スライドを再確認してください。