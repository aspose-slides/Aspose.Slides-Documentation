---
title: Gérer les paramètres d'ajustement automatique
type: docs
weight: 30
url: /androidjava/manage-autofit-settings/
keywords: "Textbox, Autofit, Présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Définir les paramètres d'ajustement automatique pour la zone de texte dans PowerPoint en Java"
---

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le paramètre **Ajuster la forme au texte** pour la zone de texte—il redimensionne automatiquement la zone de texte pour s'assurer que son texte y tient toujours.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Lorsque le texte dans la zone de texte devient plus long ou plus grand, PowerPoint agrandit automatiquement la zone de texte—augmente sa hauteur—pour lui permettre de contenir plus de texte.
* Lorsque le texte dans la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte—diminue sa hauteur—pour supprimer l'espace redondant.

Dans PowerPoint, voici les 4 paramètres ou options importants qui contrôlent le comportement d'ajustement automatique pour une zone de texte :

* **Ne pas ajuster automatiquement**
* **Réduire le texte en cas de débordement**
* **Ajuster la forme au texte**
* **Enrouler le texte dans la forme.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides pour Android via Java fournit des options similaires—certaines propriétés sous la classe [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)—qui vous permettent de contrôler le comportement d'ajustement automatique pour les zones de texte dans les présentations.

## **Ajuster la forme au texte**

Si vous souhaitez que le texte dans une boîte s'adapte toujours à cette boîte après modification du texte, vous devez utiliser l'option **Ajuster la forme au texte**. Pour spécifier ce paramètre, définissez la propriété [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) sur `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ce code Java vous montre comment spécifier qu'un texte doit toujours s'adapter à sa boîte dans une présentation PowerPoint :

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

Si le texte devient plus long ou plus grand, la zone de texte sera automatiquement redimensionnée (augmentation de la hauteur) pour s'assurer que tout le texte y tient. Si le texte devient plus court, l'inverse se produit.

## **Ne Pas Ajuster Automatiquement**

Si vous souhaitez qu'une zone de texte ou une forme conserve ses dimensions, peu importe les modifications apportées au texte qu'elle contient, vous devez utiliser l'option **Ne pas ajuster automatiquement**. Pour spécifier ce paramètre, définissez la propriété [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) sur `None`.

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

## **Réduire le Texte en Cas de Débordement**

Si un texte devient trop long pour sa boîte, grâce à l'option **Réduire le texte en cas de débordement**, vous pouvez spécifier que la taille et l'espacement du texte doivent être réduits pour le faire tenir dans sa boîte. Pour spécifier ce paramètre, définissez la propriété [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) sur `Normal`.

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

Lorsque l'option **Réduire le texte en cas de débordement** est utilisée, le paramètre est appliqué uniquement lorsque le texte devient trop long pour sa boîte.

{{% /alert %}}

## **Enrouler le Texte**

Si vous souhaitez que le texte dans une forme soit enroulé à l'intérieur de cette forme lorsque le texte dépasse la bordure de la forme (largeur uniquement), vous devez utiliser le paramètre **Enrouler le texte dans la forme**. Pour spécifier ce paramètre, vous devez définir la propriété [WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) sur `true`.

Ce code Java vous montre comment utiliser le paramètre Enrouler le Texte dans une présentation PowerPoint :

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

Si vous définissez la propriété `WrapText` sur `False` pour une forme, lorsque le texte à l'intérieur de la forme devient plus long que la largeur de la forme, le texte s'étend au-delà des bordures de la forme sur une seule ligne. 

{{% /alert %}}