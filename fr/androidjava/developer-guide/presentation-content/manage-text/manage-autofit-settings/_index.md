---
title: Améliorez vos présentations avec AutoFit sur Android
linktitle: Paramètres Autofit
type: docs
weight: 30
url: /fr/androidjava/manage-autofit-settings/
keywords:
- zone de texte
- ajustement automatique
- ne pas ajuster automatiquement
- adapter le texte
- réduire le texte
- renvoyer le texte
- redimensionner forme
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Gérez les paramètres AutoFit dans Aspose.Slides pour Android via Java afin d'optimiser l'affichage du texte dans vos présentations PowerPoint et OpenDocument et d'améliorer la lisibilité du contenu."
---

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le paramètre **Resize shape to fix text** pour la zone de texte — il redimensionne automatiquement la zone de texte pour s’assurer que son texte y rentre toujours. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Lorsque le texte de la zone de texte devient plus long ou plus grand, PowerPoint agrandit automatiquement la zone de texte—augmente sa hauteur—pour lui permettre de contenir plus de texte. 
* Lorsque le texte de la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte—diminue sa hauteur—pour éliminer l’espace redondant. 

Dans PowerPoint, voici les 4 paramètres ou options importants qui contrôlent le comportement d'auto‑ajustement pour une zone de texte :

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java propose des options similaires—certaines propriétés de la classe [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) —qui vous permettent de contrôler le comportement d'auto‑ajustement des zones de texte dans les présentations.

## **Redimensionner une forme pour ajuster le texte**

Si vous souhaitez que le texte d’une zone s’ajuste toujours à celle‑ci après des modifications, vous devez utiliser l’option **Resize shape to fix text**. Pour spécifier ce réglage, définissez la propriété [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) sur `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ce code Java vous montre comment spécifier qu’un texte doit toujours tenir dans sa zone dans une présentation PowerPoint :
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


Si le texte devient plus long ou plus grand, la zone de texte sera automatiquement redimensionnée (augmentation de la hauteur) pour que tout le texte y tienne. Si le texte devient plus court, l’inverse se produit. 

## **Ne pas ajuster automatiquement**

Si vous souhaitez qu’une zone de texte ou une forme conserve ses dimensions quel que soit le texte qu’elle contient, vous devez utiliser l’option **Do not Autofit**. Pour spécifier ce réglage, définissez la propriété [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) sur `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ce code Java vous montre comment spécifier qu’une zone de texte doit toujours conserver ses dimensions dans une présentation PowerPoint :
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


Lorsque le texte devient trop long pour sa zone, il déborde. 

## **Réduire le texte en cas de dépassement**

Si un texte devient trop long pour sa zone, l’option **Shrink text on overflow** vous permet de spécifier que la taille et l’espacement du texte doivent être réduits pour qu’il tienne dans la zone. Pour définir ce réglage, attribuez à la propriété [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) la valeur `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ce code Java vous montre comment spécifier qu’un texte doit être réduit en cas de dépassement dans une présentation PowerPoint :
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
Lorsque l’option **Shrink text on overflow** est utilisée, le réglage n’est appliqué que lorsque le texte devient trop long pour sa zone. 
{{% /alert %}}

## **Renvoyer le texte**

Si vous souhaitez que le texte d’une forme se renvoie à l’intérieur de celle‑ci lorsque le texte dépasse la bordure de la forme (largeur uniquement), vous devez utiliser le paramètre **Wrap text in shape**. Pour définir ce réglage, vous devez fixer la propriété [WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) sur `true`.

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


{{% alert title="Note" color="warning" %}} 
Si vous définissez la propriété `WrapText` sur `False` pour une forme, lorsque le texte à l’intérieur de la forme devient plus long que la largeur de la forme, le texte s’étend au‑delà des bordures de la forme sur une seule ligne. 
{{% /alert %}}

## **FAQ**

**Les marges internes du cadre de texte affectent-elles l’AutoFit ?**  
Oui. Le remplissage (marges internes) réduit la zone utilisable pour le texte, de sorte que l’AutoFit se déclenche plus tôt—en réduisant la police ou en redimensionnant la forme plus rapidement. Vérifiez et ajustez les marges avant de régler l’AutoFit.  

**Comment l’AutoFit interagit‑il avec les sauts de ligne manuels et souples ?**  
Les sauts forcés restent en place, et l’AutoFit adapte la taille de la police et l’espacement autour d’eux. Supprimer les sauts inutiles réduit souvent l’agressivité avec laquelle l’AutoFit doit réduire le texte.  

**Le changement de police du thème ou le déclenchement d’une substitution de police affecte‑t‑il les résultats de l’AutoFit ?**  
Oui. Remplacer une police par une autre avec des métriques de glyphe différentes modifie la largeur/hauteur du texte, ce qui peut changer la taille finale de la police et le retour à la ligne. Après tout changement ou substitution de police, revérifiez les diapositives.