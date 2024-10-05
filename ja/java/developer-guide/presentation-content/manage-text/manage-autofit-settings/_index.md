---
title: オートフィット設定の管理
type: docs
weight: 30
url: /java/manage-autofit-settings/
keywords: "テキストボックス, オートフィット, PowerPointプレゼンテーション, Java, Aspose.Slides for Java"
description: "JavaにおけるPowerPointのテキストボックスに対するオートフィット設定を行います"
---

デフォルトでは、テキストボックスを追加すると、Microsoft PowerPointはテキストボックスに対して**テキストに合わせて図形をリサイズ**設定を使用します。つまり、テキストボックスは常にその中にテキストが収まるように自動的にサイズが変更されます。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* テキストボックス内のテキストが長くなったり大きくなったりした場合、PowerPointは自動的にテキストボックスを拡大し（高さを増加させ）、より多くのテキストを収めることができるようにします。
* テキストボックス内のテキストが短くなったり小さくなったりした場合、PowerPointは自動的にテキストボックスを減少させ（高さを減少させ）、余分なスペースをクリアします。

PowerPointでは、テキストボックスのオートフィット動作を制御するための4つの重要なパラメーターまたはオプションがあります：

* **オートフィットしない**
* **オーバーフロー時にテキストを縮小**
* **テキストに合わせて図形をリサイズ**
* **形状内でテキストを折り返す**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Javaは、プレゼンテーション内のテキストボックスに対するオートフィット動作を制御するための同様のオプションを提供します—[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)クラスのいくつかのプロパティです。 

## **テキストに合わせて図形をリサイズ**

テキストが変更された後も、ボックス内のテキストが常にそのボックスに収まるようにするには、**テキストに合わせて図形をリサイズ**オプションを使用する必要があります。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--)プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)クラスの）を`Shape`に設定します。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

このJavaコードは、PowerPointプレゼンテーション内のテキストが常にそのボックスに収まるように指定する方法を示しています：

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

テキストが長くなったり大きくなったりすると、テキストボックスは自動的にサイズが変更され（高さが増加する）、すべてのテキストが収まることを確保します。テキストが短くなると、逆のことが起こります。

## **オートフィットしない**

テキストボックスや図形がその内容にかかわらず、その寸法を維持するようにしたい場合は、**オートフィットしない**オプションを使用しなければなりません。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--)プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)クラスの）を`None`に設定します。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

このJavaコードは、PowerPointプレゼンテーション内のテキストボックスが常にその寸法を維持するように指定する方法を示しています：

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

テキストがボックス内で長すぎる場合、テキストははみ出します。

## **オーバーフロー時にテキストを縮小**

テキストがボックス内で長すぎる場合、**オーバーフロー時にテキストを縮小**オプションを使用すると、テキストのサイズと間隔を減少させてボックスに収めることができます。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--)プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)クラスの）を`Normal`に設定します。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

このJavaコードは、PowerPointプレゼンテーション内のテキストがオーバーフロー時に縮小されるように指定する方法を示しています：

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

{{% alert title="情報" color="info" %}}

**オーバーフロー時にテキストを縮小**オプションが使用されるとき、設定はテキストがボックス内で長すぎるときのみ適用されます。 

{{% /alert %}}

## **テキストを折り返す**

テキストが形状の境界を超えたときに、その形状内でテキストが折り返されるようにしたい場合は、**形状内でテキストを折り返す**パラメーターを使用する必要があります。この設定を指定するには、[WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--)プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)クラスの）を`true`に設定する必要があります。

このJavaコードは、PowerPointプレゼンテーション内でテキストを折り返す設定を使用する方法を示しています：

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

{{% alert title="注意" color="warning" %}} 

形状に対して`WrapText`プロパティを`False`に設定した場合、形状内のテキストが形状の幅より長くなると、テキストは単一行で形状の境界を超えて延長されます。 

{{% /alert %}}