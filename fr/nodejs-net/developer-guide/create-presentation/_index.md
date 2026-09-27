---
title: Créer des présentations dans Node.js via .NET
linktitle: Créer une présentation
type: docs
weight: 10
url: /fr/nodejs-net/create-presentation/
keywords:
- créer une présentation
- nouvelle présentation
- créer PowerPoint
- créer PPTX
- ajouter une zone de texte
- ajouter une diapositive
- taille de la diapositive
- grand écran
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer des présentations PowerPoint en JavaScript avec Aspose.Slides for Node.js via .NET: ajouter une zone de texte et des diapositives, définir une taille de diapositive 16:9, et enregistrer le résultat au format PPTX."
---
## **Vue d'ensemble**

Cet article montre comment créer une présentation avec Aspose.Slides for Node.js via .NET, ajouter une zone de texte à sa première diapositive et enregistrer le résultat sous forme de fichier PPTX. Il montre également comment ajouter d'autres diapositives et comment passer la présentation en mode écran large (16:9).

Les exemples nécessitent un projet configuré comme décrit dans [Installation](/slides/fr/nodejs-net/installation/). Enregistrez chaque exemple sous forme de fichier `.js` dans le dossier du projet et exécutez‑le depuis ce dossier avec `node`, par exemple `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET ne possède pas de référence d'API propre. Il reflète l'API Aspose.Slides for .NET avec des noms camelCase, de sorte que les liens d'API de cet article mènent aux classes et membres correspondants dans la [référence d'API Aspose.Slides for .NET](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Créer une présentation avec une zone de texte**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Une nouvelle présentation contient déjà une diapositive vide.  
2. Récupérez cette diapositive à partir de la collection [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). Les collections de ce package sont lues avec `get(index)`, et les index commencent à 0.  
3. Ajoutez un rectangle avec la méthode [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) et définissez le [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) de son [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/).  
4. Enregistrez la présentation avec la méthode [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) et la valeur `SaveFormat.Pptx`.  
5. Appelez `dispose` dans un bloc `finally` pour libérer les ressources .NET qui sous-tendent la présentation.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // La position (x, y) et la taille (largeur, hauteur) sont en points.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

Le script crée `new-presentation.pptx` dans le dossier du projet. Le fichier contient une diapositive avec un rectangle rempli dont le coin supérieur gauche se trouve à 50 points du bord gauche et du bord supérieur de la diapositive. Le rectangle fait 400 points de largeur et 100 points de hauteur, et son texte est centré. Un point correspond à 1/72 pouce. Sans licence, Aspose.Slides ajoute également un filigrane d'évaluation à la diapositive ; voir la page [Licence](/slides/fr/nodejs-net/licensing/).

## **Ajouter des diapositives**

Une nouvelle présentation possède une diapositive. Pour en ajouter d’autres, transmettez une diapositive de mise en page à la méthode [addEmptySlide](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addemptyslide/) de la collection `slides`. La méthode [getByType](https://reference.aspose.com/slides/net/aspose.slides/layoutslidecollection/getbytype/) de la collection [layoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) renvoie la première mise en page d’un type donné [SlideLayoutType](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/).

L'exemple suivant ajoute deux diapositives avec la mise en page Blank :

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le script affiche `Slide count: 3` et crée `three-slides.pptx`. Les nouvelles diapositives sont ajoutées après la première et ne contiennent aucune forme. Une nouvelle présentation possède toujours une mise en page Blank, mais une présentation ouverte à partir d’un fichier peut ne pas disposer d’une mise en page du type demandé ; dans ce cas `getByType` renvoie `null`, il faut donc vérifier le résultat avant de le transmettre.

## **Définir la taille de la diapositive**

Une nouvelle présentation utilise des diapositives 4:3 mesurant 720 × 540 points (10 × 7,5 pouces). Pour créer des diapositives grand écran à la place, appelez la méthode [setSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) de la [slideSize](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) de la présentation avec une valeur [SlideSizeType](https://reference.aspose.com/slides/net/aspose.slides/slidesizetype/) et une valeur [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/). Le type d'échelle indique à Aspose.Slides comment traiter les formes déjà présentes sur les diapositives ; `DoNotScale` les laisse telles quelles, ce qui est le bon choix pour une présentation qui ne contient encore aucun contenu.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le script affiche `Slide size: 960 x 540 points`, soit 13,33 × 7,5 pouces, et crée `widescreen.pptx`. `SlideSizeType.OnScreen16x9` a le même rapport d’aspect 16:9 mais est plus petit : 720 × 405 points.

## **FAQ**

**Dans quelles unités les positions et les tailles sont‑elles mesurées ?**

En points. Un pouce correspond à 72 points, ainsi la diapositive 4:3 par défaut mesure 720 × 540 points, et une diapositive grand écran 16:9 mesure 960 × 540 points.

**Quels formats puis‑je utiliser pour enregistrer une nouvelle présentation ?**

Toute valeur de l’enum [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/), par exemple `SaveFormat.Ppt` pour PowerPoint 97–2003, `SaveFormat.Odp` pour OpenDocument, ou `SaveFormat.Pdf`. Pour la sortie PDF, voir [Convertir PowerPoint en PDF](/slides/fr/nodejs-net/convert-powerpoint-to-pdf/).

**Pourquoi la présentation enregistrée contient‑elle le texte « Evaluation only » ?**

Sans licence, Aspose.Slides ajoute un filigrane d'évaluation aux diapositives qu’il enregistre. Appliquez une licence comme décrit dans [Licence](/slides/fr/nodejs-net/licensing/) pour le supprimer.

**Pourquoi devrais‑je appeler `dispose` ?**

Un objet `Presentation` repose sur un objet .NET qui détient de la mémoire et d’autres ressources. Appeler `dispose` les libère dès que vous n’avez plus besoin de la présentation, et l’appeler dans un bloc `finally` les libère même en cas d’erreur.