---
title: "Améliorez vos présentations avec l'AutoFit en Java"
linktitle: "Paramètres Autofit"
type: docs
weight: 30
url: /fr/java/manage-autofit-settings/
keywords:
  - "zone de texte"
  - "autofit"
  - "ne pas ajuster automatiquement"
  - "adapter le texte"
  - "réduire le texte"
  - "envelopper le texte"
  - "redimensionner la forme"
  - "PowerPoint"
  - "OpenDocument"
  - "présentation"
  - "Java"
  - "Aspose.Slides"
description: "Apprenez à gérer les paramètres AutoFit dans Aspose.Slides pour Java afin d'optimiser l'affichage du texte dans vos présentations PowerPoint et OpenDocument et d'améliorer la lisibilité du contenu."
---

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le paramètre **Redimensionner la forme pour ajuster le texte** ; il redimensionne automatiquement la zone de texte pour que son texte y tienne toujours.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Lorsque le texte de la zone de texte devient plus long ou plus grand, PowerPoint agrandit automatiquement la zone de texte — augmente sa hauteur — pour lui permettre de contenir davantage de texte.  
* Lorsque le texte de la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte — diminue sa hauteur — pour éliminer l’espace superflu.

Dans PowerPoint, voici les 4 paramètres ou options importants qui contrôlent le comportement d’ajustement automatique d’une zone de texte :

* **Ne pas ajuster automatiquement**
* **Réduire le texte en cas de dépassement**
* **Redimensionner la forme pour ajuster le texte**
* **Envelopper le texte dans la forme**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java propose des options similaires—certaines propriétés de la classe [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)—qui vous permettent de contrôler le comportement d’ajustement automatique des zones de texte dans les présentations.

## **Redimensionner la forme pour ajuster le texte**

Si vous voulez que le texte d’une boîte s’ajuste toujours à cette boîte après toute modification, vous devez utiliser l’option **Redimensionner la forme pour ajuster le texte**. Pour spécifier ce paramètre, définissez la propriété [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) sur `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ce code Java montre comment spécifier qu’un texte doit toujours s’ajuster à sa boîte dans une présentation PowerPoint :
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


Si le texte devient plus long ou plus grand, la zone de texte sera redimensionnée automatiquement (augmentation de la hauteur) afin que tout le texte y tienne. Si le texte devient plus court, l’effet inverse se produit.

## **Ne pas ajuster automatiquement**

Si vous voulez qu’une zone de texte ou une forme conserve ses dimensions quel que soit le texte qu’elle contient, vous devez utiliser l’option **Ne pas ajuster automatiquement**. Pour spécifier ce paramètre, définissez la propriété [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) sur `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ce code Java montre comment spécifier qu’une zone de texte doit toujours conserver ses dimensions dans une présentation PowerPoint :
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

## **Réduire le texte en cas de dépassement**

Si un texte devient trop long pour sa boîte, l’option **Réduire le texte en cas de dépassement** vous permet de spécifier que la taille et l’interligne du texte doivent être réduits pour qu’il tienne dans la boîte. Pour spécifier ce paramètre, définissez la propriété [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) sur `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ce code Java montre comment spécifier qu’un texte doit être réduit en cas de dépassement dans une présentation PowerPoint :
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
Lorsque l’option **Réduire le texte en cas de dépassement** est utilisée, le paramètre s’applique uniquement lorsque le texte devient trop long pour sa boîte.
{{% /alert %}}

## **Envelopper le texte**

Si vous voulez que le texte d’une forme s’enveloppe à l’intérieur de cette forme lorsque le texte dépasse la bordure de la forme (largeur uniquement), vous devez utiliser le paramètre **Envelopper le texte dans la forme**. Pour spécifier ce paramètre, définissez la propriété [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) sur `true`.

Ce code Java montre comment utiliser le paramètre Envelopper le texte dans une présentation PowerPoint :
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
Si vous définissez la propriété `WrapText` sur `False` pour une forme, lorsque le texte à l’intérieur de la forme devient plus long que la largeur de la forme, le texte s’étend au‑delà des bordures de la forme sur une seule ligne.
{{% /alert %}}

## **FAQ**

**Les marges internes du cadre de texte affectent-elles l’AutoFit ?**

Oui. Le remplissage (marges internes) réduit la zone utilisable pour le texte, de sorte que l’AutoFit s’active plus tôt—en réduisant la police ou en redimensionnant la forme plus tôt. Vérifiez et ajustez les marges avant d’affiner l’AutoFit.

**Comment l’AutoFit interagit‑il avec les sauts de ligne manuels et souples ?**

Les sauts imposés restent en place, et l’AutoFit adapte la taille de la police et l’interligne autour d’eux. Supprimer les sauts inutiles réduit souvent l’agressivité de la réduction de texte par l’AutoFit.

**Le changement de police du thème ou le déclenchement d’une substitution de police affecte‑t‑il les résultats de l’AutoFit ?**

Oui. Remplacer une police par une autre dont les métriques diffèrent modifie la largeur/hauteur du texte, ce qui peut changer la taille finale de la police et le passage à la ligne. Après tout changement ou substitution de police, revérifiez les diapositives.