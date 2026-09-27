---
title: Convertir les diapositives de présentation en images dans Node.js via .NET
linktitle: Diapositive en image
type: docs
weight: 40
url: /fr/nodejs-net/convert-slide/
keywords:
- convertir diapositive
- diapositive en image
- diapositive en PNG
- enregistrer diapositive en image
- rendu diapositive
- miniature de diapositive
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Rendre les diapositives des présentations PPTX, PPT et ODP en images PNG en JavaScript avec Aspose.Slides pour Node.js via .NET, à un facteur d'échelle ou à une taille exacte en pixels."
---
## **Vue d'ensemble**

Aspose.Slides for Node.js via .NET rend les diapositives des présentations PowerPoint et OpenDocument sous forme d'images, par exemple pour afficher des aperçus de diapositives sur une page Web. Cet article montre deux méthodes pour choisir la taille de l'image : un facteur d'échelle relatif à la taille de la diapositive, et une taille exacte en pixels. Les deux exemples enregistrent des fichiers PNG.

Les exemples supposent une présentation nommée `sample.pptx` dans le dossier du projet que vous avez configuré dans [Installation](/slides/fr/nodejs-net/installation/). Toute présentation PowerPoint convient. Enregistrez chaque exemple sous forme de fichier `.js` dans le dossier du projet et exécutez‑le depuis ce dossier avec `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET n’a pas de référence d’API propre. Elle reflète l’API Aspose.Slides for .NET avec des noms camelCase, de sorte que les liens API de cet article mènent aux classes et membres correspondants dans la [référence d’API Aspose.Slides for .NET](https://reference.aspose.com/slides/fr/net/).
{{% /alert %}}

Pour convertir une diapositive en image, suivez ces étapes :

1. Ouvrez la présentation avec le constructeur [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/presentation/).
1. Récupérez une diapositive depuis la collection [slides](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/slides/fr/) avec `get(index)`. Les index commencent à 0.
1. Rendu de la diapositive avec `getImageWithScale` ou `getImageWithImageSize`. Dans la référence d’API .NET, les deux sont des surcharges de [Slide.GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/slide/getimage/). Elles renvoient un objet image qui correspond à [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/).
1. Enregistrez l'image avec sa méthode [save](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/save/) et une valeur [ImageFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/imageformat/), puis appelez sa méthode `dispose`.

## **Convertir chaque diapositive en image PNG**

`getImageWithScale` prend un facteur d’échelle horizontal et vertical. À une échelle de 1, un point de la diapositive devient un pixel de l'image. L'exemple suivant rend chaque diapositive à une échelle de 2 :

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// Une échelle de 1 rend un pixel par point ; 2 double la largeur et la hauteur.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

Le script écrit un fichier par diapositive, `slide_1.png`, `slide_2.png`, etc., numérotés à partir de 1. Pour une présentation 16 : 9 dont les diapositives mesurent 960 × 540 points, chaque image fait 1920 × 1080 pixels. Les diapositives masquées sont également rendues ; pour les ignorer, vérifiez la propriété [hidden](https://reference.aspose.com/slides/fr/net/aspose.slides/slide/hidden/) de la diapositive. Chaque image est libérée dans son propre bloc `finally`, ce qui la libère avant que la diapositive suivante ne soit rendue. Sans licence, les images affichent également un filigrane d’évaluation ; voir [Licensing](/slides/fr/nodejs-net/licensing/).

## **Convertir une diapositive en image d’une taille donnée**

`getImageWithImageSize` prend un objet avec `width` et `height` en pixels. L'exemple suivant rend la première diapositive avec une largeur de 1280 pixels et calcule la hauteur à partir de la taille de la diapositive, de façon à conserver le rapport d’aspect :

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

La propriété [slideSize.size](https://reference.aspose.com/slides/fr/net/aspose.slides/slidesize/size/) renvoie la largeur et la hauteur de la diapositive en points. Pour une présentation 16 : 9, le script affiche `Saved a 1280 x 720 image` et écrit `slide_1_1280px.png` ; pour une présentation 4 : 3, l'image fait 1280 × 960 pixels.

## **FAQ**

**Pourquoi l'image provenant de `getImage` sans arguments est‑elle si petite ?**

Sans arguments, `getImage` rend la diapositive à 20 % de sa taille en points, de sorte qu'une diapositive de 960 × 540 points devient une image de 192 × 108 pixels. Utilisez `getImageWithScale` ou `getImageWithImageSize` pour choisir la taille.

**Comment enregistrer au format JPEG ou d'autres formats d'image ?**

Passez une autre valeur `ImageFormat` à la méthode `save` de l'image, par exemple `image.save("slide_1.jpg", ImageFormat.Jpeg)`. Le format provient de la valeur `ImageFormat`, pas de l'extension du fichier, donc gardez les deux cohérents.

**Pourquoi le texte dans les images apparaît‑il différemment sous Linux ?**

Aspose.Slides ne peut utiliser que les polices installées sur la machine qui rend les diapositives. Lorsqu'une présentation utilise une police manquante, comme Calibri sur un serveur Linux typique, Aspose.Slides remplace cette police par une police installée, ce qui peut modifier l’apparence du texte et le point de césure des lignes. Installez les polices utilisées par vos présentations pour obtenir les mêmes images qu sous Windows.

**Pourquoi `getThumbnailWithImageSize` échoue avec une TypeError ?**

Le README du package utilise `getThumbnailWithImageSize`, mais le package ne propose aucune méthode `getThumbnail`. Utilisez `getImageWithImageSize` à la place ; elle accepte le même argument `{ width, height }`.