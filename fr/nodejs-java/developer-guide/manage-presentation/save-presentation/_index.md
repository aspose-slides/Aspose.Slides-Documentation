---
title: Enregistrer des présentations en JavaScript
linktitle: Enregistrer la présentation
type: docs
weight: 80
url: /fr/nodejs-java/save-presentation/
keywords:
- enregistrer PowerPoint
- enregistrer OpenDocument
- enregistrer présentation
- enregistrer diapositive
- enregistrer PPT
- enregistrer PPTX
- enregistrer ODP
- présentation vers fichier
- présentation vers flux
- type de vue prédéfini
- format Strict Office Open XML
- mode Zip64
- rafraîchissement de la miniature
- progression de l'enregistrement
- Node.js
- JavaScript
- Aspose.Slides
description: "Découvrez comment enregistrer des présentations avec Aspose.Slides pour Node.js via Java - exportation vers PowerPoint ou OpenDocument tout en conservant les mises en page, les polices et les effets."
---
## **Vue d'ensemble**

[Ouvrir des présentations en JavaScript](/slides/fr/nodejs-java/open-presentation/) décrit comment utiliser la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) pour ouvrir une présentation. Cet article explique comment créer et enregistrer des présentations. La classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) contient le contenu d’une présentation. Que vous créiez une présentation à partir de zéro ou que vous modifiiez une existante, vous voudrez l’enregistrer une fois terminé. Avec Aspose.Slides pour Node.js, vous pouvez enregistrer dans un **fichier** ou un **flux**. Cet article décrit les différentes façons d’enregistrer une présentation.

## **Enregistrer des présentations dans des fichiers**

Enregistrez une présentation dans un fichier en appelant la méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/). Passez le nom du fichier et le format d’enregistrement à la méthode. L’exemple suivant montre comment enregistrer une présentation avec Aspose.Slides.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Effectuer des opérations ici...

    // Enregistrer la présentation dans un fichier.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Enregistrer des présentations dans des flux**

Vous pouvez enregistrer une présentation dans un flux en passant un flux de sortie à la méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/). Une présentation peut être écrite vers de nombreux types de flux. Dans l’exemple ci‑dessous, nous créons une nouvelle présentation et l’enregistrons dans un flux de fichier.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Enregistrer la présentation dans le flux.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Enregistrer des présentations avec un type de vue prédéfini**

Aspose.Slides vous permet de définir la vue initiale que PowerPoint utilise lorsque la présentation générée s’ouvre via la classe [ViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewproperties/). Utilisez la méthode [setLastView](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewproperties/#setLastView) avec une valeur de l’énumération [ViewType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewtype/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Enregistrer des présentations au format Strict Office Open XML**

Aspose.Slides vous permet d’enregistrer une présentation au format Strict Office Open XML. Utilisez la classe [PptxOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxoptions/) et définissez sa propriété `conformance` lors de l’enregistrement. Si vous définissez [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), le fichier de sortie est enregistré au format Strict Office Open XML.

L’exemple ci‑dessous crée une présentation et l’enregistre au format Strict Office Open XML.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation();
try {
    // Enregistrer la présentation au format Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Enregistrer des présentations au format Office Open XML en mode Zip64**

Un fichier Office Open XML est une archive ZIP qui impose des limites de 4 Go (2^32 octets) sur la taille non compressée d’un fichier, la taille compressée d’un fichier et la taille totale de l’archive, et limite l’archive à 65 535 (2^16‑1) fichiers. Les extensions de format ZIP64 augmentent ces limites à 2^64.

La méthode [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) vous permet de choisir quand utiliser les extensions de format ZIP64 lors de l’enregistrement d’un fichier Office Open XML.

Cette méthode peut être utilisée avec les modes suivants :

- [IfNecessary](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/zip64mode/#IfNecessary) utilise les extensions ZIP64 uniquement si la présentation dépasse les limites ci‑dessus. C’est le mode par défaut.
- [Never](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/zip64mode/#Never) n’utilise jamais les extensions ZIP64.
- [Always](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/zip64mode/#Always) utilise toujours les extensions ZIP64.

Le code suivant montre comment enregistrer une présentation en tant que fichier PPTX avec les extensions ZIP64 activées :

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Lorsque vous enregistrez avec [Zip64Mode.Never](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/zip64mode/#Never), une [PptxException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxexception/) est levée si la présentation ne peut pas être enregistrée au format ZIP32.
{{% /alert %}}

## **Enregistrer des présentations au format Office Open XML avec niveaux de compression**

Lorsque vous travaillez avec de grandes présentations, vous pouvez ajuster le niveau de compression pour équilibrer la taille du fichier et le temps de traitement. En fonction de vos besoins, vous pouvez privilégier un traitement plus rapide ou des fichiers de sortie plus petits.

Aspose.Slides fournit la méthode [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel), qui vous permet de spécifier le niveau de compression utilisé lors de l’enregistrement d’une présentation au format Office Open XML.

Les niveaux de compression disponibles sont :

- [**None**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#None) : aucune compression n’est appliquée. Les fichiers sont stockés tels quels.
- [**Level1**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level1) : la compression la plus rapide avec le taux de compression le plus faible.
- [**Level2**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level2) : compression plus rapide avec un léger meilleur taux que **Level1**.
- [**Level3**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level3) : meilleure compression que **Level2** avec un impact modéré sur le temps de traitement.
- [**Level4**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level4) : meilleure compression que **Level3**.
- [**Level5**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level5) : amélioration de la compression par rapport à **Level4** avec un temps de traitement supplémentaire.
- [**Level6**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level6) : compression standard offrant un bon équilibre entre vitesse de traitement et taille du fichier. C’est le *niveau de compression par défaut*.
- [**Level7**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level7) : meilleure compression que **Level6** avec un traitement plus lent.
- [**Level8**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level8) : meilleure compression que **Level7**.
- [**Level9**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level9) : compression maximale. Produit la plus petite taille de fichier au prix du temps de traitement le plus long.

L’exemple suivant montre comment enregistrer une présentation en tant que fichier PPTX *sans compression* :

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Cet exemple montre comment enregistrer une présentation en tant que fichier PPTX avec *compression maximale* :

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Enregistrer des présentations sans rafraîchir la miniature**

La méthode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) contrôle la génération de la miniature lors de l’enregistrement d’une présentation au format PPTX :

- Si la valeur est `true`, la miniature est rafraîchie lors de l’enregistrement. C’est la valeur par défaut.
- Si la valeur est `false`, la miniature actuelle est conservée. Si la présentation n’a pas de miniature, aucune n’est générée.

Dans le code ci‑dessous, la présentation est enregistrée au format PPTX sans rafraîchir sa miniature.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Cette option permet de réduire le temps nécessaire pour enregistrer une présentation au format PPTX.
{{% /alert %}}

## **Mise à jour de la progression d’enregistrement en pourcentage**

Le reporting de la progression d’enregistrement est configuré via la méthode [setProgressCallback](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) sur [SaveOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveoptions/) et ses sous‑classes. Fournissez un proxy Java qui implémente l’interface [IProgressCallback](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprogresscallback/) ; pendant l’export, le rappel reçoit des mises à jour périodiques en pourcentage.

Les extraits de code suivants montrent comment utiliser `IProgressCallback`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Utilisez la valeur du pourcentage de progression ici.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose a développé une [application gratuite PowerPoint Splitter](https://products.aspose.app/slides/fr/splitter) utilisant sa propre API. L’application vous permet de diviser une présentation en plusieurs fichiers en enregistrant les diapositives sélectionnées en tant que nouveaux fichiers PPTX ou PPT.
{{% /alert %}}

## **FAQ**

**La « sauvegarde rapide » (sauvegarde incrémentielle) est‑elle prise en charge afin que seules les modifications soient écrites ?**

Non. Chaque sauvegarde crée le fichier cible complet ; la « sauvegarde rapide » incrémentielle n’est pas prise en charge.

**Est‑il sûr d’enregistrer la même instance de Presentation depuis plusieurs threads ?**

Non. Une instance de [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) [n’est pas thread‑safe](/slides/fr/nodejs-java/multithreading/) ; enregistrez‑la depuis un seul thread.

**Que se passe‑t‑il avec les hyperliens et les fichiers liés externement lors de l’enregistrement ?**

Les [hyperliens](/slides/fr/nodejs-java/manage-hyperlinks/) sont préservés. Les fichiers liés externement (par ex. : vidéos via des chemins relatifs) ne sont pas copiés automatiquement — assurez‑vous que les chemins référencés restent accessibles.

**Puis‑je définir/enregistrer les métadonnées du document (Auteur, Titre, Société, Date) ?**

Oui. Les [propriétés de document](/slides/fr/nodejs-java/presentation-properties/) standard sont prises en charge et seront écrites dans le fichier lors de l’enregistrement.