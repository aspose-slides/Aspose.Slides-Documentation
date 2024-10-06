---
title: Gérer les paramètres d'Autofit
type: docs
weight: 30
url: /java/manage-autofit-settings/
keywords: "Textbox, Autofit, présentation PowerPoint, Java, Aspose.Slides pour Java"
description: "Définir les paramètres d'autofit pour la zone de texte dans PowerPoint en Java"
---

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le paramètre **Redimensionner la forme pour ajuster le texte** pour la zone de texte : il redimensionne automatiquement la zone de texte pour s'assurer que son texte s'y ajuste toujours.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Lorsque le texte dans la zone de texte devient plus long ou plus grand, PowerPoint agrandit automatiquement la zone de texte—augmente sa hauteur—pour lui permettre de contenir plus de texte.
* Lorsque le texte dans la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte—diminue sa hauteur—pour libérer de l'espace redondant.

Dans PowerPoint, voici les 4 paramètres ou options importants qui contrôlent le comportement d'autofit pour une zone de texte :

* **Ne pas Autofit**
* **Réduire le texte en cas de débordement**
* **Redimensionner la forme pour ajuster le texte**
* **Envelopper le texte dans la forme.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides pour Java fournit des options similaires—certaines propriétés sous la classe [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)—qui vous permettent de contrôler le comportement d'autofit pour les zones de texte dans les présentations.

## **Redimensionner la forme pour ajuster le texte**

Si vous souhaitez que le texte dans une boîte s'ajuste toujours dans cette boîte après des modifications apportées au texte, vous devez utiliser l'option **Redimensionner la forme pour ajuster le texte**. Pour spécifier ce paramètre, définissez la propriété [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) sur `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ce code Java vous montre comment spécifier qu'un texte doit toujours s'ajuster dans sa boîte dans une présentation PowerPoint :

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

Si le texte devient plus long ou plus grand, la zone de texte sera automatiquement redimensionnée (augmentation de hauteur) pour garantir que tout le texte s'y ajuste. Si le texte devient plus court, l'effet inverse se produit.

## **Ne pas Autofit**

Si vous souhaitez qu'une zone de texte ou une forme conserve ses dimensions peu importe les modifications apportées au texte qu'elle contient, vous devez utiliser l'option **Ne pas Autofit**. Pour spécifier ce paramètre, définissez la propriété [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) sur `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ce code Java vous montre comment spécifier qu'une zone de texte doit toujours conserver ses dimensions dans une présentation PowerPoint :

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

Lorsque le texte devient trop long pour sa boîte, il déborde.

## **Réduire le texte en cas de débordement**

Si un texte devient trop long pour sa boîte, grâce à l'option **Réduire le texte en cas de débordement**, vous pouvez spécifier que la taille et l'espacement du texte doivent être réduits pour s'adapter à sa boîte. Pour spécifier ce paramètre, définissez la propriété [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) sur `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ce code Java vous montre comment spécifier qu'un texte doit être réduit en cas de débordement dans une présentation PowerPoint :

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

Lorsque l'option **Réduire le texte en cas de débordement** est utilisée, le paramètre s'applique uniquement lorsque le texte devient trop long pour sa boîte.

{{% /alert %}}

## **Envelopper le texte**

Si vous souhaitez que le texte dans une forme soit enveloppé à l'intérieur de cette forme lorsque le texte dépasse la bordure de la forme (largeur seulement), vous devez utiliser le paramètre **Envelopper le texte dans la forme**. Pour spécifier ce paramètre, vous devez définir la propriété [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) sur `true`.

Ce code Java vous montre comment utiliser le paramètre Wrap Text dans une présentation PowerPoint :

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

{{% alert title="Remarque" color="warning" %}}

Si vous définissez la propriété `WrapText` sur `False` pour une forme, lorsque le texte à l'intérieur de la forme devient plus long que la largeur de la forme, le texte s'étend au-delà des bordures de la forme sur une seule ligne.

{{% /alert %}}