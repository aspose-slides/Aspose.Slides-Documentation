---
title: Optimiser la gestion des images dans les présentations avec JavaScript
linktitle: Gestion des images
type: docs
weight: 10
url: /fr/nodejs-java/image/
keywords:
- ajouter image
- ajouter illustration
- ajouter bitmap
- remplacer image
- remplacer illustration
- depuis le web
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- ressources SVG externes
- résolveur SVG
- images SVG liées
- polices SVG
- ajouter EMF
- ajouter WMF
- ajouter TIFF
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Simplifiez la gestion des images dans PowerPoint et OpenDocument avec Aspose.Slides pour Node.js via Java, en optimisant les performances et en automatisant votre flux de travail."
---
## **Introduction**

Les images rendent les présentations plus attrayantes et visuellement intéressantes. Dans Microsoft PowerPoint, vous pouvez insérer des images dans les diapositives à partir de fichiers, d’Internet ou d’autres sources. De même, Aspose.Slides vous permet d’ajouter des images aux diapositives de présentation de plusieurs manières.

{{% alert  title="Astuce" color="primary" %}} 

Aspose propose des convertisseurs gratuits—[JPEG to PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt)—qui vous permettent de créer rapidement des présentations à partir d’images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si vous souhaitez ajouter une image sous forme de cadre d’image—en particulier si vous prévoyez de la redimensionner, d’appliquer des effets ou d’utiliser d’autres options de mise en forme standard—voir [Picture Frame](/slides/fr/nodejs-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Remarque" color="warning" %}}

Vous pouvez convertir des images d’un format à un autre. Consultez les pages suivantes : convertissez [image to JPG](https://products.aspose.com/slides/fr/nodejs-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/fr/nodejs-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/fr/nodejs-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/fr/nodejs-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/fr/nodejs-java/conversion/png-to-svg/), et [SVG to PNG](https://products.aspose.com/slides/fr/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides prend en charge les images aux formats populaires tels que JPEG, PNG, BMP, GIF et d’autres. 

## **Add Images Stored Locally to Slides**

Vous pouvez ajouter une ou plusieurs images stockées sur votre ordinateur à une diapositive de présentation. Le code JavaScript d’exemple suivant montre comment ajouter une image à une diapositive :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Add Images from the Web to Slides**

Si l’image que vous souhaitez ajouter à une diapositive n’est pas stockée sur votre ordinateur, vous pouvez l’ajouter directement depuis le Web. 

Le code JavaScript d’exemple suivant montre comment ajouter une image depuis le Web à une diapositive :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Add Images to Slide Masters**

Un masque de diapositive stocke et contrôle des informations telles que le thème et la disposition pour les diapositives qui l’utilisent. Lorsque vous ajoutez une image à un masque de diapositive, l’image apparaît sur chaque diapositive basée sur ce masque. 

Le code JavaScript d’exemple suivant montre comment ajouter une image à un masque de diapositive :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Add Images as Slide Backgrounds**

Vous pouvez utiliser une image comme arrière‑plan pour une ou plusieurs diapositives. Pour plus de détails, voir *[Setting Images as Backgrounds for Slides](/slides/fr/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Add SVG to Presentations**

Le contenu SVG peut être ajouté à une présentation à l’aide de la classe [SvgImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/svgimage/). L’objet image SVG résultant peut ensuite être ajouté à la collection d’images de la présentation et utilisé pour créer un cadre d’image.

Le code JavaScript suivant importe une chaîne SVG autonome. Toutes les images, styles et autres ressources utilisés par ce SVG sont incorporés directement dans le contenu SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Import SVG Content with External Resources**

Les fichiers SVG exportés depuis des outils de conception, des éditeurs de diagrammes, des systèmes d’icônes et des pipelines Web peuvent référencer des ressources stockées à l’extérieur du document SVG. Par exemple, un SVG peut contenir un lien d’image tel que `images/photo.png`, une valeur CSS `url(...)` ou une URL de police.

Pour importer ce type de contenu SVG, fournissez un résolveur de ressources externes et transmettez‑le, avec une URI de base, à un constructeur approprié de [SvgImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/svgimage/). L’URI de base identifie l’emplacement du document SVG et est utilisée pour résoudre les liens relatifs.

La classe `SvgImage` donne accès aux informations sur le SVG importé :

- `getSvgContent()` renvoie le balisage SVG sous forme de chaîne.
- `getSvgData()` renvoie le contenu SVG sous forme de tableau d’octets.
- `getBaseUri()` renvoie l’URI de base utilisée pour les liens relatifs.
- `getExternalResourceResolver()` renvoie le résolveur assigné à l’image SVG.

### **Implement an External Resource Resolver**

Le résolveur possède deux méthodes :

- `resolveUri` combine l’URI de base et un lien de ressource relatif et renvoie une URI absolue. Retournez `null` lorsque le lien ne peut pas être résolu ou n’est pas autorisé.
- `getEntity` renvoie un flux Java lisible pour une URI de ressource absolue. Retournez `null` lorsque la ressource est manquante, bloquée ou indisponible. Un flux de secours peut également être renvoyé lorsque cela est approprié.

L’assistant suivant crée un résolveur qui charge les ressources liées uniquement depuis un répertoire local autorisé. Les ressources réseau et les chemins en dehors du répertoire autorisé sont bloqués. Une image de secours optionnelle est renvoyée pour les liens d’image non résolus.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // Ce resolueur autorise intentionnellement uniquement les fichiers locaux.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // Utilisez une solution de secours uniquement pour les ressources image. Le retour d'un flux d'image
                // pour une police ou une feuille de style manquante ne serait pas valide.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **Resolve Linked Resources During SVG Import**

Supposons que `assets/diagram.svg` contienne une référence relative telle que :

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Le code JavaScript suivant passe l’URI du fichier SVG comme URI de base et fournit un résolveur personnalisé. Le résolveur convertit le lien d’image relatif en une URI absolue et renvoie un flux contenant la ressource liée pendant qu’Aspose.Slides traite le SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// L'URI de base représente l'emplacement du document SVG.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage exposes the source content, binary data, base URI, and resolver.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La classe `SvgImage` propose également des surcharges qui acceptent les données SVG sous forme de tableau d’octets, ainsi que des méthodes de création basées sur des flux, avec un résolveur de ressources externes et une URI de base.

{{% alert title="Important" color="warning" %}}

Le résolveur de ressources rend les ressources externes disponibles pendant qu’Aspose.Slides traite et rend le SVG. Il ne modifie pas le balisage SVG d’origine ni n’incorpore automatiquement les ressources résolues dans celui‑ci.

Lorsqu’une image SVG est ajoutée à la collection d’images de la présentation, le fichier PPTX peut contenir à la fois la représentation SVG d’origine et une image raster de secours. Une ressource liée peut apparaître dans l’image de secours générée tandis qu’un lien relatif tel que `images/photo.png` reste inchangé dans le SVG stocké. Une application qui rend la représentation SVG native peut donc omettre le contenu lié lorsque la ressource externe d’origine n’est pas disponible.

{{% /alert %}}

### **Create a Portable SVG Picture**

Pour créer une image SVG qui ne dépend pas de fichiers externes, rendez le SVG autonome avant de créer le `SvgImage`. Par exemple, remplacez les URL d’images liées par des URI `data:` contenant les données de l’image :

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Après avoir incorporé toutes les ressources requises dans le contenu SVG, créez le `SvgImage`, ajoutez‑le à la collection d’images de la présentation et insérez‑le dans un cadre d’image comme montré dans l’exemple précédent.

### **Handle Missing or Blocked Resources**

Retournez `null` depuis `resolveUri` lorsqu’une URI de ressource est invalide, interdite ou ne peut pas être résolue. Retournez `null` depuis `getEntity` lorsque la ressource ne peut pas être lue. Aspose.Slides poursuit le traitement du SVG sans cette ressource lorsqu’il le peut.

Un flux de secours peut être renvoyé pour une ressource manquante, mais son contenu doit être compatible avec le type de ressource demandé. Par exemple, renvoyez un flux d’image uniquement pour une image manquante, pas pour une police ou une feuille de style.

{{% alert title="Sécurité" color="warning" %}}

Ne résolvez pas de chemins de fichiers arbitraires ou d’URL réseau non restreints provenant de fichiers SVG non fiables. Restreignez les schémas, répertoires et hôtes autorisés. Pour les ressources réseau, appliquez également des délais d’attente de connexion, des limites de taille de réponse et une validation du contenu.

{{% /alert %}}

## **Convert SVG to a Set of Shapes**

Aspose.Slides peut convertir un SVG en un ensemble de formes, de façon similaire à la fonctionnalité correspondante dans PowerPoint :

![PowerPoint Popup Menu](img_01_01.png)

Cette fonctionnalité est fournie par une surcharge de la méthode [addGroupShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) de la classe [ShapeCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ShapeCollection) qui accepte un objet image SVG en premier argument.

Le code JavaScript d’exemple suivant montre comment utiliser cette méthode pour convertir un fichier SVG en un ensemble de formes :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Nom du fichier SVG source.
const svgFileName = "sample.svg";

// Nom du fichier de présentation en sortie.
const outPptxPath = "presentation.pptx";

// Créer une nouvelle présentation.
const presentation = new aspose.slides.Presentation();
try {
    // Lire le contenu du fichier SVG.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // Créer un objet SvgImage.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // Obtenir la taille de la diapositive.
    const slideSize = presentation.getSlideSize().getSize();

    // Convertir l'image SVG en un groupe de formes et l'adapter à la taille de la diapositive.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // Enregistrer la présentation au format PPTX.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Add Images as EMF to Slides**

Aspose.Slides for Node.js via Java vous permet de générer des images EMF à partir de feuilles de calcul Excel avec Aspose.Cells et de les ajouter aux diapositives de présentation.

Le code JavaScript d’exemple suivant montre comment procéder :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// Enregistrer le classeur dans un flux.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Ajouter le fichier tel quel afin que l'image reste un EMF vectoriel au lieu d'être rasterisée.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Replace Images in the Image Collection**

Aspose.Slides vous permet de remplacer les images stockées dans la collection d’images d’une présentation, y compris les images utilisées par les formes de diapositive. Cette section décrit plusieurs façons de mettre à jour les images de la collection. Vous pouvez remplacer une image à l’aide de données brutes d’octets, d’une instance [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/) ou d’une autre image déjà présente dans la collection.

Suivez les étapes ci‑dessous :

1. Chargez le fichier de présentation contenant les images à l’aide de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
1. Chargez une nouvelle image depuis un fichier dans un tableau d’octets.
1. Remplacez l’image cible par la nouvelle image en utilisant le tableau d’octets.
1. Dans la deuxième approche, chargez l’image dans un objet [IImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/iimage/) et remplacez l’image cible par cet objet.
1. Dans la troisième approche, remplacez l’image cible par une image déjà existante dans la collection d’images de la présentation.
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Instancie la classe Presentation qui représente un fichier de présentation.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Première méthode.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Deuxième méthode.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // Troisième méthode.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Enregistrer la présentation dans un fichier.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Avec le convertisseur gratuit [Text to GIF](https://products.aspose.app/slides/fr/text-to-gif) d’Aspose, vous pouvez facilement animer du texte et créer des GIF à partir de texte. 

{{% /alert %}}

## **FAQ**

**La résolution d’image d’origine reste‑t‑elle intacte après l’insertion ?**

Oui. Les pixels source sont conservés, mais l’apparence finale dépend de la façon dont le [picture](/slides/fr/nodejs-java/picture-frame/) est redimensionné sur la diapositive et de toute compression appliquée lors de l’enregistrement.

**Quelle est la meilleure façon de remplacer le même logo sur des dizaines de diapositives en une fois ?**

Placez le logo sur le masque de diapositive ou sur une disposition et remplacez‑le dans la collection d’images de la présentation ; les mises à jour se propageront à tous les éléments qui utilisent cette ressource.

**Un SVG inséré peut‑il être converti en formes éditables ?**

Oui. Vous pouvez convertir un SVG en un groupe de formes, puis chaque partie devient éditable avec les propriétés de forme standard.

**Comment définir une image comme arrière‑plan pour plusieurs diapositives à la fois ?**

[Assignez l’image comme arrière‑plan](/slides/fr/nodejs-java/presentation-background/) sur le masque de diapositive ou la disposition concernée ; toutes les diapositives utilisant ce masque/disposition hériteront de l’arrière‑plan.

**Comment empêcher une présentation de devenir trop volumineuse à cause de trop d’images ?**

Réutilisez une même ressource d’image au lieu de la dupliquer, choisissez des résolutions raisonnables, appliquez une compression lors de l’enregistrement et conservez les graphiques répétés sur le masque lorsque cela est approprié.