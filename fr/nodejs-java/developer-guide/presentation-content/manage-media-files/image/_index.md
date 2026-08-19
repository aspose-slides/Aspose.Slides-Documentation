---
title: Optimiser la gestion des images dans les présentations avec JavaScript
linktitle: Gestion des images
type: docs
weight: 10
url: /fr/nodejs-java/image/
keywords:
- ajouter image
- ajouter image
- remplacer image
- collection d'images
- cadre d'image
- image liée
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- SVG en formes
- ressources SVG externes
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez comment ajouter, réutiliser, lier, remplacer et gérer les images raster et SVG dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Node.js via Java."
---
## **Introduction**

Aspose.Slides for Node.js via Java propose plusieurs façons de travailler avec les images, chacune ayant un objectif différent. Vous pouvez stocker une image dans une présentation, l'afficher dans un cadre d'image, l'utiliser comme arrière-plan de diapositive, créer un lien vers une image externe, remplacer une ressource d'image partagée ou convertir du contenu SVG en formes modifiables.

Cet article se concentre sur les ressources d'image et leur utilisation dans une présentation. Pour le recadrage, la transparence, les effets, l'étirement et d'autres formats appliqués à un cadre d'image individuel, voir [Picture Frame](/slides/fr/nodejs-java/picture-frame/).

## **Comprendre le modèle d'image**

Les concepts d'API suivants sont étroitement liés mais pas interchangeables :

- La [presentation image collection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/imagecollection/) stocke les ressources d'image utilisées par la présentation. Utilisez [ImageCollection.addImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/imagecollection/) pour ajouter des données d'image et obtenir une ressource [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/).
- Un [picture frame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/) est une forme qui affiche une image sur une diapositive, une disposition ou un maître. Utilisez [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/) pour placer une ressource d'image sur une diapositive.
- Un arrière-plan de diapositive utilise une image comme partie du remplissage de la diapositive plutôt que comme forme. Il ne se comporte donc pas comme un cadre d'image.
- [PPImage.replaceImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) remplace une ressource d'image. Si plusieurs éléments de la présentation utilisent cette ressource, ils utilisent tous le remplacement.
- La conversion d'un SVG en formes crée des formes de diapositive modifiables. Après conversion, le contenu n'est plus géré comme une seule ressource d'image.

Un flux de travail typique est donc : ajouter des données d'image à la collection d'images, recevoir un [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/), puis utiliser cette ressource dans un ou plusieurs cadres d'image ou remplissages.

## **Ajouter une image incorporée**

Pour insérer une image locale, chargez le fichier, ajoutez‑le à la collection d'images et créez un cadre d'image qui utilise la ressource [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) renvoyée.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'image ajoutée de cette façon est incorporée dans la présentation, de sorte que le fichier résultant ne dépend pas de la disponibilité continue du fichier image d'origine.

### **Ajouter une image depuis le Web**

Lorsqu'une image est disponible via HTTP ou HTTPS, téléchargez ses octets, ajoutez‑les à la collection d'images de la présentation et utilisez la ressource d'image renvoyée de la même manière qu'une image locale.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

Dans les applications de longue durée, réutilisez un client HTTP ou une stratégie de gestion de connexion adaptée à l'application plutôt que de créer à plusieurs reprises une infrastructure réseau inutile. Validez également les URL distantes, les tailles de réponse et les types de contenu lorsque la source n'est pas fiable.

## **Réutiliser les images entre les diapositives**

Si la même image est requise plusieurs fois, ajoutez‑la à la présentation une seule fois et réutilisez le [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) renvoyé lors de la création de cadres d'image supplémentaires. Cela évite de charger à plusieurs reprises les mêmes données sources et rend explicite la relation entre la ressource d'image partagée et ses utilisations.

Pour les graphiques qui doivent apparaître automatiquement sur de nombreuses diapositives, comme le logo d'une entreprise, envisagez de placer le cadre d'image sur un [slide master](/slides/fr/nodejs-java/slide-master/) ou une disposition au lieu d'ajouter une forme équivalente à chaque diapositive.

## **Utiliser une image comme arrière-plan de diapositive**

Une image d'arrière-plan est attribuée au remplissage de la diapositive ; elle n'est pas ajoutée comme forme de cadre d'image. Cela est utile lorsque l'image doit couvrir l'arrière-plan de la diapositive et ne doit pas être manipulée comme un objet de diapositive normal.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour d'autres options d'arrière-plan, y compris les arrière-plans du maître et de la disposition, voir [Presentation Background](/slides/fr/nodejs-java/presentation-background/).

## **Images incorporées et images liées**

Les images incorporées et les images liées présentent des compromis différents en termes de portabilité et de taille de fichier :

- **Image incorporée  :** les données de l'image sont stockées dans la présentation. La présentation est autonome, mais la taille du fichier comprend les données de l'image.
- **Image liée  :** la présentation stocke un chemin ou une URL vers une image externe. Cela peut réduire la taille de la présentation, mais la ressource externe doit rester accessible lorsque la présentation est ouverte ou rendue.

Une image liée peut être créée en assignant le chemin ou l'URL externes via [Picture.setLinkPathLong](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picture/) plutôt qu'en incorporant les données de l'image.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilisez des images liées uniquement lorsque l'environnement de déploiement peut accéder de manière fiable à la ressource externe. Pour les présentations qui doivent fonctionner hors ligne ou être déplacées entre systèmes, les images incorporées sont généralement plus sûres.

## **Travailler avec les images SVG**

SVG est un format vectoriel, il peut donc être utile pour les icônes, les diagrammes et autres graphiques qui doivent s’adapter sans perdre le même niveau de détail que les images raster. Aspose.Slides prend en charge SVG à la fois comme ressource d'image et comme source de formes de diapositive modifiables.

### **Ajouter un SVG en tant qu'image**

Créez un [SvgImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/svgimage/), ajoutez‑le à la collection d'images et placez la ressource d'image résultante dans un cadre d'image.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Fichiers SVG avec ressources externes**

Un SVG peut référencer des images externes, des feuilles de style ou des polices. Dans ces cas, [SvgImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/svgimage/) propose des constructeurs qui acceptent un [ExternalResourceResolver](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/externalresourceresolver/) et une URI de base. Le résolveur peut mapper une URI relative vers une URI absolue autorisée et renvoyer un flux pour la ressource demandée.

Le résolveur rend les ressources externes disponibles pendant le traitement du SVG par Aspose.Slides, mais il ne réécrit pas le SVG en un document autonome. Si le SVG doit rester portable, incorporez les ressources nécessaires dans le SVG lui‑même, par exemple en utilisant des URI `data:` pour les images liées.

Lorsque les fichiers SVG proviennent de sources non fiables, limitez les schémas, emplacements de fichiers et hôtes auxquels le résolveur peut accéder. Les résolveurs réseau doivent également appliquer des délais d’attente, des limites de taille de réponse et une validation du contenu.

### **Convertir SVG en formes modifiables**

Aspose.Slides peut convertir un SVG en un groupe de formes de diapositive modifiables, similaire à la commande PowerPoint correspondante.

![PowerPoint Popup Menu](img_01_01.png)

Utilisez la surcharge [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/) qui accepte une image SVG pour effectuer la conversion.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Utilisez la conversion SVG‑vers‑formes lorsque les éléments vectoriels individuels doivent être édités en tant que formes PowerPoint. Si le SVG doit seulement être affiché, le garder comme image est plus simple et évite de créer de nombreuses formes séparées.

## **Remplacer une ressource d'image existante**

Utilisez [PPImage.replaceImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) lorsque vous souhaitez remplacer une ressource d'image existante. Ceci est particulièrement utile pour les graphiques partagés tels que les logos.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si plusieurs cadres d'image, arrière‑plans, maîtres ou dispositions utilisent la même ressource d'image, remplacer cette ressource met à jour toutes ces utilisations. Si un seul cadre doit changer, assignez une image différente à ce cadre au lieu de remplacer la ressource partagée.

[PPImage.replaceImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) propose également des surcharges qui acceptent un tableau d'octets ou un autre [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/).

## **Guide pratique de gestion des images**

### **Contrôler la taille de la présentation**

Les grosses images raster peuvent rendre une présentation inutilement volumineuse. Utilisez des images sources dont les dimensions sont adaptées à la taille d'affichage prévue, réutilisez les ressources d'image partagées lorsque c’est possible et évitez d'incorporer plusieurs copies identiques du même graphique haute résolution.

Pour les images raster déjà placées dans des cadres d'image, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/) peut réduire les données d'image en fonction de la résolution et des paramètres de recadrage sélectionnés. Il s'agit d'un traitement de cadre d'image plutôt que d'une gestion de collection d'images, consultez donc [Picture Frame](/slides/fr/nodejs-java/picture-frame/) pour les opérations de formatage associées.

### **Choisir entre contenu incorporé et lié**

L'incorporation rend la présentation portable car toutes les données d'image nécessaires voyagent avec le fichier. Le lien peut réduire la taille du fichier, mais introduit une dépendance externe. N'utilisez les liens que lorsque cette dépendance est acceptable et stable.

### **Réutiliser la marque partagée**

Pour les logos, filigranes ou graphiques décoratifs récurrents, utilisez une seule ressource d'image et réutilisez‑la. Si le graphique fait partie du design de la présentation plutôt que du contenu des diapositives, placez‑le sur un maître ou une disposition afin qu'il soit hérité par les diapositives appropriées.

### **Conserver les ressources SVG portables**

Un SVG autonome est plus facile à déplacer et à rendre de façon cohérente qu'un SVG dépendant de fichiers externes ou de ressources réseau. Lorsque c'est possible, incorporez les ressources nécessaires avant d'importer le SVG. Convertissez le SVG en formes uniquement lorsque les éléments vectoriels individuels doivent être modifiés.

### **Utiliser l'API d'image moderne multiplateforme**

Pour le nouveau code Node.js via Java, utilisez les API Aspose.Slides [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/) et [Images](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/images/) au lieu de l'ancienne API publique basée sur `java.awt.image.BufferedImage`. Consultez [Modern API](/slides/fr/nodejs-java/modern-api/) pour les conseils de migration.

WMF et EMF nécessitent une considération particulière. Lorsque ces formats sont transmis via un [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/imagecollection/) convertit le métafichier en une représentation PNG raster avant l'insertion. Si la préservation des données du métafichier est importante, utilisez plutôt une surcharge basée sur un flux de [ImageCollection.addImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/imagecollection/). La génération de contenu EMF à partir de feuilles de calcul ou d'autres produits est un flux d'intégration séparé et ne relève pas du périmètre de cet article.

## **FAQ**

**Quelle est la différence entre la collection d'images et un cadre d'image ?**

La collection d'images stocke des ressources d'image réutilisables. Un cadre d'image est une forme de diapositive qui affiche l'une de ces ressources et offre des formats spécifiques à l'image tels que le recadrage et les effets.

**Quelle est la meilleure façon de remplacer le même logo partout ?**

Si le logo est déjà partagé comme une seule ressource d'image, remplacez cette ressource avec [PPImage.replaceImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/). Pour une identité visuelle à l’échelle de la présentation, placer le logo sur un maître ou une disposition peut également réduire le contenu dupliqué des diapositives.

**Pourquoi une image liée disparaît‑elle sur un autre ordinateur ?**

Une image liée dépend de son fichier ou de son URL externe. Si cette ressource n’est pas accessible depuis l’autre ordinateur, l'image liée peut être indisponible. Incorporez l'image lorsque la présentation doit être autonome.

**Une SVG insérée peut‑elle être modifiée en tant que formes PowerPoint ?**

Oui. Convertissez le SVG avec [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/); le groupe résultant contient des formes de diapositive modifiables plutôt qu'une seule image SVG.

**Comment garder les présentations contenant de nombreuses images plus petites ?**

Réutilisez les ressources d'image partagées, évitez les sources raster inutilement volumineuses, compressez les images raster appropriées lorsque c’est pertinent, conservez les éléments de marque répétés sur les maîtres ou les dispositions, et utilisez les images liées uniquement lorsqu’une dépendance externe est acceptable.