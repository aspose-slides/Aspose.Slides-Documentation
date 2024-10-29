---
title: オートフィット設定の管理
type: docs
weight: 30
url: /ja/androidjava/manage-autofit-settings/
keywords: "テキストボックス, オートフィット, PowerPointプレゼンテーション, Java, Aspose.Slides for Android via Java"
description: "JavaでPowerPointのテキストボックスのオートフィット設定を行います"
---

通常、テキストボックスを追加すると、Microsoft PowerPointはテキストボックスに対して**テキストに合わせて形状をサイズ変更**設定を使用します。これは、テキストボックスが常にテキストに適合するように自動的にサイズを変更することを意味します。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* テキストボックスのテキストが長くなるまたは大きくなると、PowerPointは自動的にテキストボックスを拡大します—その高さが増加し、より多くのテキストを保持できるようにします。
* テキストボックスのテキストが短くなるまたは小さくなると、PowerPointは自動的にテキストボックスを縮小します—その高さが減少し、余分なスペースをクリアします。

PowerPointでは、テキストボックスのオートフィット動作を制御するための4つの重要なパラメーターまたはオプションがあります：

* **自動調整しない**
* **オーバーフロー時にテキストを縮小**
* **テキストに合わせて形状をサイズ変更**
* **形状内のテキストを折り返す。**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Javaも同様のオプションを提供しています—プレゼンテーション内のテキストボックスのオートフィット動作を制御するための[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)クラスのいくつかのプロパティがあります。

## **テキストに合わせて形状をサイズ変更**

テキストが変更された後も常にボックスに収まるようにする場合は、**テキストに合わせて形状をサイズ変更**オプションを使用する必要があります。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--)プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)クラスから）を`Shape`に設定します。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

次のJavaコードは、PowerPointプレゼンテーション内でテキストが常にボックスに収まるように指定する方法を示しています：

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

テキストが長くなるまたは大きくなると、テキストボックスは自動的にサイズ変更され（高さが増加し）、すべてのテキストが収まるようになります。テキストが短くなると、逆の操作が行われます。

## **自動調整しない**

テキストボックスや形状が含んでいるテキストの変更に関係なく、その寸法を保持するようにする場合は、**自動調整しない**オプションを使用する必要があります。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--)プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)クラスから）を`None`に設定します。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

次のJavaコードは、PowerPointプレゼンテーション内でテキストボックスが常に寸法を保持するように指定する方法を示しています：

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

テキストがボックスよりも長くなると、テキストがあふれ出します。

## **オーバーフロー時にテキストを縮小**

テキストがボックスの長さに対して長すぎる場合、**オーバーフロー時にテキストを縮小**オプションを使用して、テキストのサイズと間隔を減少させてボックスに収めることができます。この設定を指定するには、[AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--)プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)クラスから）を`Normal`に設定します。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

次のJavaコードは、PowerPointプレゼンテーション内でテキストをオーバーフロー時に縮小するように指定する方法を示しています：

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

**オーバーフロー時にテキストを縮小**オプションを使用すると、設定はテキストがボックスに対して長くなったときのみ適用されます。

{{% /alert %}}

## **テキストを折り返す**

テキストが形状の境界（幅のみ）を超えた時に、形状内でテキストを折り返したい場合は、**形状内のテキストを折り返す**パラメーターを使用します。この設定を指定するには、[WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--)プロパティ（[TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)クラスから）を`true`に設定する必要があります。

次のJavaコードは、PowerPointプレゼンテーションで折り返しテキスト設定を使用する方法を示しています：

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

形状の`WrapText`プロパティを`False`に設定した場合、形状内のテキストが形状の幅を超えると、テキストは単一行で形状の境界を超えて延びます。

{{% /alert %}}