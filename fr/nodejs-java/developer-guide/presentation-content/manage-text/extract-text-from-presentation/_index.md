---
title: Extraire le texte d'une présentation
type: docs
weight: 90
url: /fr/nodejs-java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

Il n'est pas rare que les développeurs aient besoin d'extraire le texte d'une présentation. Pour ce faire, vous devez extraire le texte de toutes les formes de toutes les diapositives d'une présentation. Cet article explique comment extraire le texte des présentations Microsoft PowerPoint PPTX à l'aide d'Aspose.Slides. 

{{% /alert %}} 

## **Extraire le texte d'une diapositive**

Aspose.Slides for Node.js via Java fournit la classe [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil). Cette classe expose un certain nombre de méthodes statiques surchargées permettant d'extraire tout le texte d'une présentation ou d'une diapositive. Pour extraire le texte d'une diapositive dans une présentation PPTX, utilisez la méthode statique surchargée [getAllTextBoxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextBoxes-aspose.slides.IBaseSlide-) exposée par la classe [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil). Cette méthode accepte l'objet Slide en paramètre.
Lors de l'exécution, la méthode Slide parcourt tout le texte de la diapositive passée en paramètre et renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) . Cela signifie que toute mise en forme du texte associée au texte est disponible. Le fragment de code suivant extrait tout le texte de la première diapositive de la présentation :
```javascript
// Instancier la classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    for (var s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        // Obtenir un tableau d'objets ITextFrame provenant de toutes les diapositives du PPTX
        var textFramesPPTX = aspose.slides.SlideUtil.getAllTextBoxes(slide);
        // Boucler à travers le tableau de TextFrames
        for (var i = 0; i < textFramesPPTX.length; i++) {
            // Boucler à travers les paragraphes du ITextFrame actuel
            for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
                let para = textFramesPPTX[i].getParagraphs().get_Item(j);
                // Boucler à travers les portions du IParagraph actuel
                for (let k = 0; k < para.getPortions().getCount(); k++) {
                    let port = para.getPortions().get_Item(k);
                    // Afficher le texte dans la portion actuelle
                    console.log(port.getText());
                    // Afficher la hauteur de police du texte
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

Pour analyser le texte de l'ensemble de la présentation, utilisez la méthode statique [getAllTextFrames](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextFrames-aspose.slides.IPresentation-boolean-) exposée par la classe SlideUtil. Elle prend deux paramètres :

1. Tout d'abord, un objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) qui représente la présentation dont le texte est extrait.
2. Deuxièmement, une valeur booléenne déterminant si la diapositive maître doit être incluse lors de l'analyse du texte de la présentation.
   La méthode renvoie un tableau d'objets [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) contenant les informations de mise en forme du texte. Le code ci‑dessous analyse le texte et les informations de mise en forme d'une présentation, y compris les diapositives maîtres.
```javascript
// Instancier la classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Obtenir un tableau d'objets ITextFrame provenant de toutes les diapositives du PPTX
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
                // Afficher la hauteur de police du texte
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

La nouvelle méthode statique getPresentationText a été ajoutée à la classe Presentation. Il existe trois surcharges pour cette méthode :
```javascript
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```


## **FAQ**

**Quelle est la vitesse d'Aspose.Slides lors du traitement de grandes présentations lors de l'extraction de texte ?**

Aspose.Slides est optimisé pour des performances élevées et traite efficacement même les grandes présentations, ce qui le rend adapté aux scénarios de traitement en temps réel ou en lot.

**Aspose.Slides peut‑il extraire le texte des tableaux et graphiques dans les présentations ?**

Oui, Aspose.Slides prend entièrement en charge l'extraction du texte des tableaux, graphiques et autres éléments complexes des diapositives, vous permettant d'accéder facilement à tout le contenu textuel et de l'analyser.

**Ai‑je besoin d'une licence spéciale Aspose.Slides pour extraire le texte des présentations ?**

Vous pouvez extraire le texte avec la version d'essai gratuite d'Aspose.Slides, bien qu'elle comporte certaines limitations, comme le traitement d'un nombre limité de diapositives. Pour un usage illimité et la gestion de présentations plus volumineuses, l'achat d'une licence complète est recommandé.