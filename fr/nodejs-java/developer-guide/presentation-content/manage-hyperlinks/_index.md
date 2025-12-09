---
title: Gérer les hyperliens
type: docs
weight: 20
url: /fr/nodejs-java/manage-hyperlinks/
keywords: "Hyperlien PowerPoint, hyperlien texte, hyperlien diapositive, hyperlien forme, hyperlien image, hyperlien vidéo, Java"
description: "Comment ajouter un hyperlien à une présentation PowerPoint en JavaScript"
---

Un hyperlien est une référence à un objet ou à des données ou à un emplacement dans quelque chose. Voici des hyperliens courants dans les présentations PowerPoint :

* Liens vers des sites Web dans du texte, des formes ou des médias
* Liens vers des diapositives

Aspose.Slides for Node.js via Java vous permet d’effectuer de nombreuses tâches impliquant des hyperliens dans les présentations.

{{% alert color="primary" %}} 
Vous voudrez peut‑être essayer Aspose simple, [éditeur PowerPoint gratuit en ligne.](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **Ajout d’hyperliens URL**

### **Ajout d’hyperliens URL à du texte**

Ce code JavaScript vous montre comment ajouter un hyperlien vers un site Web à un texte :
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


### **Ajout d’hyperliens URL à des formes ou des cadres**

Ce code d’exemple en JavaScript vous montre comment ajouter un hyperlien vers un site Web à une forme :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Ajout d’hyperliens URL à des médias**

Aspose.Slides vous permet d’ajouter des hyperliens à des images, des fichiers audio et vidéo. 

Ce code d’exemple vous montre comment ajouter un hyperlien à une **image** :
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ajoute une image à la présentation
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Crée un cadre d'image sur la diapositive 1 à partir de l'image précédemment ajoutée
    var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pictureFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Ce code d’exemple vous montre comment ajouter un hyperlien à un **fichier audio** :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var audio = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.mp3")));
    var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
    audioFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Ce code d’exemple vous montre comment ajouter un hyperlien à une **vidéo** :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var video = pres.getVideos().addVideo(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "video.avi")));
    var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    videoFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Astuce" color="primary" %}} 
Vous voudrez peut‑être voir *[Gérer OLE](/slides/fr/nodejs-java/manage-ole/)*.
{{% /alert %}}

## **Utilisation des hyperliens pour créer une table des matières**

Comme les hyperliens vous permettent d’ajouter des références à des objets ou à des emplacements, vous pouvez les utiliser pour créer une table des matières. 

Ce code d’exemple vous montre comment créer une table des matières avec des hyperliens :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var firstSlide = pres.getSlides().get_Item(0);
    var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
    var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getTextFrame().getParagraphs().clear();
    var paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");
    var linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
    paragraph.getPortions().add(linkPortion);
    contentTable.getTextFrame().getParagraphs().add(paragraph);
    pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Mise en forme des hyperliens**

### **Couleur**

Avec la méthode [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) de la classe [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink), vous pouvez définir la couleur des hyperliens et également obtenir l’information de couleur des hyperliens. La fonctionnalité a été introduite pour la première fois dans PowerPoint 2019, de sorte que les changements concernant cette propriété ne s’appliquent pas aux versions antérieures de PowerPoint.

Ce code d’exemple montre une opération où des hyperliens de couleur différente ont été ajoutés à la même diapositive :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Suppression des hyperliens dans les présentations**

### **Suppression des hyperliens du texte**

Ce code JavaScript vous montre comment supprimer l’hyperlien d’un texte dans une diapositive de présentation :
```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // Vérifie si la forme prend en charge le cadre texte (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // Parcourt les paragraphes du cadre texte
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // Parcourt chaque portion du paragraphe
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// Modifie le texte
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Modifie la mise en forme
                    }
                }
            }
        }
    }
    // Enregistre la présentation modifiée
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Suppression des hyperliens des formes ou des cadres**

Ce code JavaScript vous montre comment supprimer l’hyperlien d’une forme dans une diapositive de présentation :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        shape.getHyperlinkManager().removeHyperlinkClick();
    }
    pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Hyperlien mutable**

La classe [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) est mutable. Avec cette classe, vous pouvez modifier les valeurs de ces propriétés :

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

L’extrait de code vous montre comment ajouter un hyperlien à une diapositive et modifier son info-bulle plus tard :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Propriétés prises en charge dans IHyperlinkQueries**

Vous pouvez accéder à [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) depuis une présentation, une diapositive ou un texte pour lequel l’hyperlien est défini.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

La classe [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) prend en charge ces méthodes et propriétés :

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**Comment créer une navigation interne non seulement vers une diapositive, mais vers une « section » ou la première diapositive d’une section ?**

Les sections dans PowerPoint sont des groupements de diapositives ; la navigation cible techniquement une diapositive spécifique. Pour « naviguer vers une section », vous liez généralement à sa première diapositive.

**Puis‑je attacher un hyperlien aux éléments de la diapositive maîtresse afin qu’il fonctionne sur toutes les diapositives ?**

Oui. Les éléments de la diapositive maîtresse et des mises en page prennent en charge les hyperliens. Ces liens apparaissent sur les diapositives enfants et sont cliquables pendant le diaporama.

**Les hyperliens seront‑ils conservés lors de l’exportation vers PDF, HTML, images ou vidéo ?**

Dans [PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/) et [HTML](/slides/fr/nodejs-java/convert-powerpoint-to-html/), oui — les liens sont généralement conservés. Lors de l’exportation vers [images](/slides/fr/nodejs-java/convert-powerpoint-to-png/) et [vidéo](/slides/fr/nodejs-java/convert-powerpoint-to-video/), la possibilité de cliquer ne sera pas conservée en raison de la nature de ces formats (les images raster/vidéos ne prennent pas en charge les hyperliens).