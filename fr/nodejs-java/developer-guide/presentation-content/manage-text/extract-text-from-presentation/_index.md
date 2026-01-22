---
title: Extraction avancée de texte à partir de présentations en JavaScript
linktitle: Extraire le texte
type: docs
weight: 90
url: /fr/nodejs-java/extract-text-from-presentation/
keywords:
- extraire du texte
- extraire du texte d'une diapositive
- extraire du texte d'une présentation
- extraire du texte de PowerPoint
- extraire du texte d'OpenDocument
- extraire du texte de PPT
- extraire du texte de PPTX
- extraire du texte de ODP
- récupérer le texte
- récupérer le texte d'une diapositive
- récupérer le texte d'une présentation
- récupérer le texte de PowerPoint
- récupérer le texte d'OpenDocument
- récupérer le texte de PPT
- récupérer le texte de PPTX
- récupérer le texte de ODP
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Extrayez rapidement du texte des présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Node.js. Suivez notre guide simple, étape par étape, pour gagner du temps."
---

{{% alert color="primary" %}} 

Il n'est pas rare que les développeurs aient besoin d'extraire le texte d'une présentation. Pour ce faire, il faut extraire le texte de toutes les formes de toutes les diapositives d'une présentation. Cet article explique comment extraire le texte des présentations Microsoft PowerPoint PPTX à l'aide d'Aspose.Slides. 

{{% /alert %}} 

## **Extraire le texte d'une diapositive**

Aspose.Slides for Node.js via Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil). Cette classe expose un certain nombre de méthodes statiques surchargées pour extraire le texte complet d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive dans une présentation PPTX,
utilisez la méthode statique surchargée [getAllTextBoxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextBoxes-aspose.slides.IBaseSlide-) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil). Cette méthode accepte l'objet Slide comme paramètre.
Lors de son exécution, la méthode Slide parcourt tout le texte de la diapositive transmise en paramètre et renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame). Cela signifie que toute mise en forme du texte associée est disponible. Le fragment de code suivant extrait tout le texte de la première diapositive de la présentation :
```javascript
// Instancier la classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    for (var s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        // Obtenir un tableau d'objets ITextFrame à partir de toutes les diapositives du PPTX
        var textFramesPPTX = aspose.slides.SlideUtil.getAllTextBoxes(slide);
        // Parcourir le tableau de TextFrames
        for (var i = 0; i < textFramesPPTX.length; i++) {
            // Parcourir les paragraphes du ITextFrame actuel
            for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
                let para = textFramesPPTX[i].getParagraphs().get_Item(j);
                // Parcourir les portions du IParagraph actuel
                for (let k = 0; k < para.getPortions().getCount(); k++) {
                    let port = para.getPortions().get_Item(k);
                    // Afficher le texte de la portion actuelle
                    console.log(port.getText());
                    // Afficher la hauteur de la police du texte
                    console.log(port.getPortionFormat().getFontHeight());
                    // Afficher le nom de la police du texte
                    if (port.getPortionFormat().getLatinFont() != null) {
                        console.log(port.getPortionFormat().getLatinFont().getFontName());
                    }
                });
            }
        }
    });
} finally {
    pres.dispose();
}
```


## **Extraire le texte d'une présentation**

Pour parcourir le texte de l'ensemble de la présentation, utilisez la
[méthode statique](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextFrames-aspose.slides.IPresentation-boolean-) [getAllTextFrames](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextFrames-aspose.slides.IPresentation-boolean-) exposée par la classe SlideUtil. Elle prend deux paramètres :

1. Tout d'abord, un objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) qui représente la présentation à partir de laquelle le texte est extrait.
2. Ensuite, une valeur booléenne déterminant si la diapositive maîtresse doit être incluse lors du scan du texte de la présentation.  
   La méthode renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) complets avec les informations de mise en forme du texte. Le code ci‑dessous parcourt le texte et les informations de mise en forme d'une présentation, y compris les diapositives maîtresses.
```javascript
// Instancier la classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Obtenir un tableau d'objets ITextFrame à partir de toutes les diapositives du PPTX
    var textFramesPPTX = aspose.slides.SlideUtil.getAllTextFrames(pres, true);
    // Parcourir le tableau de TextFrames
    for (var i = 0; i < textFramesPPTX.length; i++) {
        // Parcourir les paragraphes du ITextFrame actuel
        for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
            let para = textFramesPPTX[i].getParagraphs().get_Item(j);
            // Parcourir les portions du IParagraph actuel
            for (let k = 0; k < para.getPortions().getCount(); k++) {
                let port = para.getPortions().get_Item(k);
                // Afficher le texte de la portion actuelle
                console.log(port.getText());
                // Afficher la hauteur de la police du texte
                console.log(port.getPortionFormat().getFontHeight());
                // Afficher le nom de la police du texte
                if (port.getPortionFormat().getLatinFont() != null) {
                    console.log(port.getPortionFormat().getLatinFont().getFontName());
                }
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **Extraction de texte catégorisée et rapide**

La nouvelle méthode statique getPresentationText a été ajoutée à la classe Presentation. Cette méthode possède trois surcharges :
```javascript
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[PresentationText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText#getSlidesText--) method which returns an array of `SlideText` objects. Every object represent the text on the corresponding slide. `SlideText` object have the following methods:

- `SlideText.getText` - The text on the slide's shapes
- `SlideText.getMasterText` - The text on the master page's shapes for this slide
- `SlideText.getLayoutText` - The text on the layout page's shapes for this slide
- `SlideText.getNotesText` - The text on the notes page's shapes for this slide

There is also a `SlideText` class which implements the `SlideText` class.

The new API can be used like this:

```javascript
var text1 = aspose.slides.PresentationFactory.getInstance().getPresentationText("presentation.pptx", aspose.slides.TextExtractionArrangingMode.Unarranged);
console.log(text1.getSlidesText()[0].getText());
console.log(text1.getSlidesText()[0].getLayoutText());
console.log(text1.getSlidesText()[0].getMasterText());
console.log(text1.getSlidesText()[0].getNotesText());
```


## **FAQ**

**Quelle est la rapidité d'Aspose.Slides lors de l'extraction de texte dans de grandes présentations ?**

Aspose.Slides est optimisé pour des performances élevées et traite efficacement même les présentations volumineuses, ce qui le rend adapté aux scénarios de traitement en temps réel ou par lots.

**Aspose.Slides peut‑il extraire le texte des tableaux et des graphiques au sein des présentations ?**

Oui, Aspose.Slides prend en charge l'extraction du texte des tableaux, des graphiques et d'autres éléments de diapositive complexes, vous permettant d'accéder et d'analyser facilement tout le contenu textuel.

**Ai‑je besoin d'une licence spéciale Aspose.Slides pour extraire le texte des présentations ?**

Vous pouvez extraire le texte avec la version d'essai gratuite d'Aspose.Slides, bien qu'elle comporte certaines limites, comme le traitement d'un nombre limité de diapositives. Pour une utilisation illimitée et la gestion de présentations plus grandes, l'achat d'une licence complète est recommandé.