---
title: Gérer le texte de la présentation dans Node.js via .NET
linktitle: Gérer le texte
type: docs
weight: 50
url: /fr/nodejs-net/manage-text/
keywords:
- texte
- zone de texte
- ajouter du texte
- modifier le texte
- formater le texte
- taille de police
- texte gras
- cadre de texte
- paragraphe
- portion
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Ajoutez une zone de texte à une diapositive, puis modifiez son texte, sa taille de police et son style gras en JavaScript avec Aspose.Slides for Node.js via .NET."
---
## **Vue d'ensemble**

Dans Aspose.Slides, le texte d’une diapositive appartient à une forme. Une forme automatique, telle qu’un rectangle, possède un cadre de texte ; le cadre de texte contient des paragraphes, et chaque paragraphe contient des portions, qui sont des fragments de texte avec le même formatage. Vous modifiez le texte via le cadre de texte et la police via le format d’une portion.

Cet article ajoute une zone de texte à une diapositive et enregistre la présentation. Il ouvre ensuite le fichier enregistré et modifie le texte, la taille de police et le style gras de la zone de texte.

Les exemples nécessitent un projet configuré comme décrit dans [Installation](/slides/fr/nodejs-net/installation/). Enregistrez chaque exemple comme fichier `.js` dans le dossier du projet et exécutez‑le depuis ce dossier avec `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET n’a pas de référence d’API propre. Il reflète l’API Aspose.Slides for .NET avec des noms camelCase, de sorte que les liens API de cet article renvoient aux classes et membres correspondants dans la [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Ajouter une zone de texte**

Pour ajouter une zone de texte, ajoutez une forme automatique à une diapositive avec la méthode [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) et donnez‑lui du texte avec la méthode [addTextFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/addtextframe/). L’exemple suivant ajoute un rectangle à la première diapositive d’une nouvelle présentation et enregistre la présentation sous le nom `text-box.pptx` :

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // La position (x, y) et la taille (largeur, hauteur) sont exprimées en points.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

La diapositive dans `text-box.pptx` contient un rectangle de 500 points de largeur et 80 points de hauteur, avec le texte « Quarterly report » dans la police et la taille par défaut. L’exemple suivant modifie cette zone de texte.

## **Modifier le texte et son formatage**

L’exemple suivant ouvre `text-box.pptx`, créé par l’exemple précédent, et récupère la première forme de la première diapositive. Les formes telles que les images et les tableaux n’ont pas de cadre de texte, c’est pourquoi l’exemple vérifie que la forme est une [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) avant d’utiliser le [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/) de la forme. Il effectue ensuite les opérations suivantes :

1. Il remplace le texte via la propriété [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) du cadre de texte. Après cela, le cadre de texte contient un paragraphe avec une seule portion.  
2. Il récupère cette portion à partir des collections [paragraphs](https://reference.aspose.com/slides/net/aspose.slides/textframe/paragraphs/) et [portions](https://reference.aspose.com/slides/net/aspose.slides/paragraph/portions/) et lit son [portionFormat](https://reference.aspose.com/slides/net/aspose.slides/portion/portionformat/).  
3. Il définit [fontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/), la taille de police en points, et [fontBold](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontbold/), qui prend une valeur [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/).

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

Dans `text-box-updated.pptx`, la zone de texte affiche « Quarterly report: third quarter » en gras avec une taille de 32 points. Comme le nouveau texte constitue une unique portion, les deux propriétés de formatage s’appliquent à l’ensemble. Sans licence, chaque enregistrement ajoute un filigrane d’évaluation. Étant donné que `text-box.pptx` a été enregistré en mode d’évaluation, `text-box-updated.pptx` en contient deux ; voir [Evaluate Aspose.Slides](/slides/fr/nodejs-net/evaluate-aspose-slides/).

## **FAQ**

**Pourquoi `fontBold` prend‑il une valeur `NullableBool` au lieu de `true` ou `false` ?**

Une portion peut laisser une propriété non définie et l’hériter du paragraphe, de la forme ou de la disposition et du maître de la diapositive. `NullableBool.NotDefined` signifie « hériter », tandis que `NullableBool.True` et `NullableBool.False` remplacent la valeur héritée. Affecter `true` ou `false` génère une erreur. Pour la même raison, `fontHeight` renvoie `NaN` lorsque la portion hérite de sa taille de police.

**Comment changer la couleur du texte ?**

Définissez le remplissage du format de la portion : affectez `FillType.Solid` à `portionFormat.fillFormat.fillType`, puis attribuez une couleur comme `"#FF0000"` à `portionFormat.fillFormat.solidFillColor.color`. Ajoutez `FillType` aux noms que vous importez depuis le package.

**Comment mettre en forme uniquement une partie du texte ?**

Le formatage appartient aux portions, donc placez cette partie du texte dans une portion distincte. Créez la portion avec `Portion.CreatePortionFromText`, ajoutez‑la à un paragraphe avec la méthode `add` de la collection `portions` du paragraphe, puis définissez le `portionFormat` de la nouvelle portion. Ajoutez `Portion` aux noms que vous importez depuis le package.

**Pourquoi la lecture du texte renvoie‑t‑elle « ... text has been truncated due to evaluation version limitation » ?**

Sans licence, Aspose.Slides ne renvoie que les cinq premiers caractères de tout texte plus long que vous lisez, comme `textFrame.text`, suivi de cet avis. Le texte que vous écrivez est enregistré en totalité. Appliquez une licence comme décrit dans [Licensing](/slides/fr/nodejs-net/licensing/) pour lire le texte complet.