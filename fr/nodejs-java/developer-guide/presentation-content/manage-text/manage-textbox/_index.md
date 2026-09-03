---
title: Gérer les zones de texte dans les présentations avec JavaScript
linktitle: Gérer la zone de texte
type: docs
weight: 20
url: /fr/nodejs-java/manage-textbox/
keywords:
- zone de texte
- cadre de texte
- ajouter du texte
- mettre à jour le texte
- créer une zone de texte
- vérifier la zone de texte
- ajouter une colonne de texte
- ajouter un hyperlien
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer, identifier, mettre en forme et mettre à jour les zones de texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Node.js via Java."
---
## **Introduction**

Dans Aspose.Slides pour Node.js via Java, le texte des diapositives est stocké dans des cadres de texte qui appartiennent aux formes. La classe [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) représente la forme porteuse de texte la plus répandue et expose son texte via la méthode [AutoShape.getTextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Toute forme auto dérive de [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/), mais toutes les formes ne sont pas des formes auto ou ne prennent pas en charge un cadre de texte. Lors du traitement d’une présentation existante, vérifiez qu’une forme est une instance de [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) avant d’accéder à son texte.
{{% /alert %}}

## **Créer une zone de texte sur une diapositive**

Pour créer une zone de texte, ajoutez une forme auto à une diapositive, ajoutez du texte à son cadre de texte, puis enregistrez la présentation. L’exemple suivant crée une zone de texte rectangulaire :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Les coordonnées et dimensions transmises à [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/#addAutoShape) sont mesurées en points. [AutoShape.addTextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/#addTextFrame) initialise le cadre de texte avec le texte fourni.

## **Vérifier une forme de zone de texte**

Utilisez la méthode [AutoShape.isTextBox](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/#isTextBox) pour déterminer si une forme auto est traitée comme une zone de texte. Cela est utile lorsqu’une présentation contient à la fois des formes auto portant du texte et des formes purement graphiques.

![A text box and a shape](istextbox.png)

L’exemple suivant examine chaque forme auto d’une présentation :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Une forme auto nouvellement ajoutée n’est pas considérée comme une zone de texte tant qu’elle ne contient pas de texte non vide. Vous pouvez fournir ce texte via [AutoShape.addTextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/#addTextFrame) ou [TextFrame.setText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#setText). Ajouter ou attribuer une chaîne vide entraîne [AutoShape.isTextBox](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/#isTextBox) renvoyant `false` :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Les deux premiers appels affichent `true` ; les deux derniers affichent `false`.

## **Trouver la forme qui possède un cadre de texte**

Un code générique de traitement de texte peut recevoir un [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) sans connaître l’objet de présentation qui le contient. Utilisez la méthode en lecture seule [TextFrame.getParentShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#getParentShape) pour revenir à sa forme propriétaire [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/).

Pour un cadre de texte détenu par une forme auto ou une autre forme porteuse de texte, [TextFrame.getParentShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#getParentShape) renvoie le propriétaire et [TextFrame.getParentCell](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#getParentCell) renvoie `null`. Vérifiez la valeur renvoyée avant de l’utiliser. Pour identifier à la fois les propriétaires de forme et de cellule de tableau, y compris les formes associées aux nœuds SmartArt, consultez [Search and Replace Text](/slides/fr/nodejs-java/search-and-replace-text/).

## **Ajouter des colonnes à une zone de texte**

La méthode [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/#setColumnCount) divise le cadre de texte en colonnes, tandis que [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) définit l’écart entre les colonnes en points. Les deux réglages appartiennent à [TextFrameFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/) et peuvent être modifiés via le cadre de texte d’une zone de texte existante. Le texte se redistribue entre les colonnes à l’intérieur de la même forme ; il ne continue pas dans une autre forme.

L’exemple suivant crée une zone de texte à trois colonnes avec un espacement de 10 points entre les colonnes, enregistre la présentation, puis lit les paramètres enregistrés depuis le fichier de sortie :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Extraire le texte de colonnes individuelles**

Utilisez [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/#splitTextByColumns) pour récupérer le texte attribué à chaque colonne visuelle d’un cadre de texte existant. La méthode renvoie une chaîne pour chaque colonne, dans l’ordre de lecture basé sur les colonnes. Un cadre de texte à une seule colonne produit un tableau contenant un seul élément, et une colonne vide est représentée par une chaîne vide. Les chaînes contiennent uniquement du texte brut ; la mise en forme au niveau des portions n’est pas conservée.

Ceci est utile lorsque vous devez :

- Extraire le texte tout en préservant son ordre de lecture basé sur les colonnes.
- Indexer ou comparer le contenu de diapositives à colonnes multiples.
- Exporter chaque colonne vers un fichier distinct, un champ de base de données ou une autre destination.
- Inspecter comment le texte est redistribué après modification du nombre de colonnes avec [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/#setColumnCount), de l’espacement avec [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), de la police ou de la taille du cadre de texte.

La méthode rapporte le texte réparti à l’intérieur du [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) actuel ; elle ne fait pas circuler automatiquement le texte entre des formes ou zones de texte séparées. La distribution des colonnes peut dépendre des polices disponibles et d’autres paramètres de mise en page du texte, assurez‑vous donc que les polices requises sont présentes lorsque des résultats cohérents sont essentiels.

L’exemple suivant charge une présentation, trouve la première forme auto à colonnes multiples avec un cadre de texte, lit le nombre de colonnes configuré, puis écrit le texte de chaque colonne dans un fichier séparé. Les formes ne disposant pas d’un cadre de texte sont ignorées.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Mettre à jour le texte**

Pour mettre à jour le texte dans l’ensemble d’une présentation, parcourez les diapositives et les formes, sélectionnez les formes auto, puis modifiez leurs portions de texte. Travailler au niveau des portions vous permet de changer à la fois le texte et la mise en forme des caractères.

L’exemple suivant remplace chaque occurrence de `years` par `months` dans le texte des formes auto et rend chaque portion affectée en gras :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ce parcours met à jour le texte uniquement dans les formes auto. Le texte stocké dans les tableaux, graphiques, SmartArt ou formes groupées nécessite de parcourir les collections propres à ces objets.

## **Ajouter une zone de texte avec un hyperlien**

Un hyperlien peut être attribué à une portion de texte précise, de sorte que seul ce texte agit comme lien cliquable. Utilisez [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) pour associer la portion à une URL externe.

L’exemple suivant crée du texte lié et l’enregistre dans une présentation :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Quelle est la différence entre une zone de texte et un espace réservé de texte sur une diapositive maître ou un modèle ?**

Un [placeholder](/slides/fr/nodejs-java/manage-placeholder/) peut hériter de sa position et de son formatage depuis une [master slide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslide/) ou une [layout slide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/). Une zone de texte ordinaire est une forme indépendante sur la diapositive où elle a été créée et n’acquiert pas le comportement de l’espace réservé lorsque la disposition change.

**Comment remplacer du texte sans modifier le texte dans les graphiques, tableaux ou SmartArt ?**

Limitez le parcours aux formes qui sont des instances de [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/), comme illustré dans l’exemple Mettre à jour le texte. Les graphiques, tableaux et SmartArt stockent le texte dans leurs propres modèles d’objet, ils ne sont donc pas modifiés par cette boucle.