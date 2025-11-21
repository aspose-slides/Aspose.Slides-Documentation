---
title: Gérer les paramètres d'AutoFit
type: docs
weight: 30
url: /fr/nodejs-java/manage-autofit-settings/
keywords: "Zone de texte, AutoFit, Présentation PowerPoint, Java, Aspose.Slides pour Node.js via Java"
description: "Définir les paramètres d'AutoFit pour la zone de texte dans PowerPoint en JavaScript"
---

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le paramètre **Resize shape to fix text** pour la zone de texte — il redimensionne automatiquement la zone de texte pour garantir que son texte y tient toujours. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Lorsque le texte de la zone de texte devient plus long ou plus grand, PowerPoint agrandit automatiquement la zone de texte—augmente sa hauteur—pour lui permettre de contenir plus de texte. 
* Lorsque le texte de la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte—diminue sa hauteur—pour éliminer l’espace redondant. 

Dans PowerPoint, voici les 4 paramètres ou options importants qui contrôlent le comportement d’auto‑ajustement d’une zone de texte : 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java propose des options similaires—certaines propriétés de la classe [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat)—qui vous permettent de contrôler le comportement d’auto‑ajustement des zones de texte dans les présentations.

## **Redimensionner la forme pour faire tenir le texte**

Si vous souhaitez que le texte d’une zone de texte s’adapte toujours à son cadre après des modifications, vous devez utiliser l’option **Resize shape to fix text**. Pour spécifier ce paramètre, appelez la méthode [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) de la classe [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) avec la valeur `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Si le texte devient plus long ou plus grand, la zone de texte sera automatiquement redimensionnée (augmentation de la hauteur) pour garantir que tout le texte y tienne. Si le texte devient plus court, l’inverse se produit. 

## **Ne pas auto‑ajuster**

Si vous souhaitez qu’une zone de texte ou une forme conserve ses dimensions quels que soient les changements apportés au texte qu’elle contient, vous devez utiliser l’option **Do not Autofit**. Pour spécifier ce paramètre, appelez la méthode [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) de la classe [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) avec la valeur `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Lorsque le texte devient trop long pour son cadre, il déborde. 

## **Réduire le texte en cas de débordement**

Si le texte devient trop long pour son cadre, grâce à l’option **Shrink text on overflow**, vous pouvez spécifier que la taille et l’interligne du texte doivent être réduits pour qu’il tienne dans son cadre. Pour spécifier ce paramètre, appelez la méthode [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) de la classe [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) avec la valeur `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Info" color="info" %}}
Lorsque l’option **Shrink text on overflow** est utilisée, le paramètre est appliqué uniquement lorsque le texte devient trop long pour son cadre. 
{{% /alert %}}

## **Wrap Text**

Si vous souhaitez que le texte d’une forme soit renvoyé à l’intérieur de celle‑ci lorsque le texte dépasse le bord de la forme (largeur uniquement), vous devez utiliser le paramètre **Wrap text in shape**. Pour spécifier ce paramètre, vous devez appeler la méthode [setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) de la classe [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) avec la valeur `true`.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 
Si vous appelez la méthode `setWrapText` avec la valeur `False` pour une forme, lorsque le texte à l’intérieur de la forme devient plus long que la largeur de la forme, le texte s’étend au‑delà des bordures de la forme sur une seule ligne. 
{{% /alert %}}

## **FAQ**

**Les marges internes du cadre de texte affectent-elles l’AutoFit ?**

Oui. Le remplissage (marges internes) réduit la zone utilisable pour le texte, de sorte que l’AutoFit s’active plus tôt—en réduisant la police ou en redimensionnant la forme plus tôt. Vérifiez et ajustez les marges avant de régler l’AutoFit.

**Comment l’AutoFit interagit‑il avec les sauts de ligne manuels et souples ?**

Les sauts forcés restent en place, et l’AutoFit adapte la taille de la police et l’interligne autour d’eux. Supprimer les sauts inutiles réduit souvent l’agressivité du rétrécissement du texte par AutoFit.

**La modification de la police du thème ou le déclenchement d’une substitution de police affecte‑t‑elle les résultats de l’AutoFit ?**

Oui. Substituer par une police aux métriques de glyphes différentes modifie la largeur/hauteur du texte, ce qui peut changer la taille finale de la police et le retour à la ligne. Après toute modification ou substitution de police, revérifiez les diapositives.