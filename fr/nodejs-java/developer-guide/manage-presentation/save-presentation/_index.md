---
title: Enregistrer des présentations en JavaScript
linktitle: Enregistrer la présentation
type: docs
weight: 80
url: /fr/nodejs-java/save-presentation/
keywords:
- enregistrer PowerPoint
- enregistrer OpenDocument
- enregistrer la présentation
- enregistrer la diapositive
- enregistrer PPT
- enregistrer PPTX
- enregistrer ODP
- présentation vers fichier
- présentation vers flux
- type de vue prédéfini
- format Office Open XML strict
- mode Zip64
- rafraîchissement de la vignette
- progression de l’enregistrement
- Node.js
- JavaScript
- Aspose.Slides
description: "Enregistrez des présentations PowerPoint et OpenDocument dans des fichiers ou des flux en JavaScript avec Aspose.Slides, et configurez la sortie PPTX ainsi que le suivi de la progression."
---
## **Vue d'ensemble**

Après avoir créé une présentation ou [ouvrir une présentation existante](/slides/fr/nodejs-java/open-presentation/), utilisez la méthode [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save) pour écrire le résultat. Aspose.Slides for Node.js via Java peut enregistrer une présentation dans un fichier ou un flux au format PowerPoint, OpenDocument, PDF et d’autres formats. Les sections suivantes couvrent les opérations d’enregistrement standard et les options disponibles pour la sortie PPTX.

## **Enregistrer les présentations dans des fichiers**

Pour enregistrer une présentation dans un fichier, transmettez le chemin de sortie et une valeur [SaveFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveformat/) à la méthode [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save). La valeur du format détermine le type de fichier créé par Aspose.Slides.

L’exemple suivant crée une présentation et l’enregistre sous forme de fichier PPTX :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // Ajouter ou modifier le contenu de la présentation ici.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Enregistrer les présentations dans leur format d’origine**

Pour des exemples de détection de fichiers et de flux, le comportement des présentations nouvellement créées et la distinction entre les formats source et de sortie, voir [Déterminer le format d’origine de la présentation](/slides/fr/nodejs-java/detect-presentation-source-format/).

Dans une application de traitement par lots, le format d’entrée peut ne pas être connu à l’avance. Après avoir chargé un fichier, lisez son format d’origine à l’aide de la méthode [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getSourceFormat). Transmettez la valeur [SourceFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sourceformat/) obtenue à [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideutil/#toSaveFormat) pour obtenir la valeur correspondante [SaveFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveformat/), puis utilisez [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save) pour écrire la présentation modifiée.

L’exemple complet suivant traite chaque fichier d’un répertoire d’entrée, met à jour son titre et l’enregistre dans un répertoire de sortie dans le format à partir duquel il a été chargé :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideutil/#toSaveFormat) fait correspondre PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP et PowerPoint XML à leurs formats d’enregistrement de présentation correspondants. Il ne mappe que les formats source des présentations ; il ne sert pas à sélectionner des formats d’exportation tels que PDF, HTML, TIFF ou des images. Transmettre une valeur [SourceFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sourceformat/) non prise en charge ou invalide entraîne une erreur.

Les fichiers PPT, PPS et POT hérités utilisent le même conteneur binaire. Lorsqu’une telle présentation est chargée à partir d’un flux sans extension de fichier, un fichier PPS ou POT peut donc être identifié comme PPT. Si la conservation de ces sous‑types hérités est nécessaire, conservez le nom de fichier ou les métadonnées de format d’origine séparément et utilisez‑les lors du choix du nom de fichier et du format de sortie.

## **Enregistrer les présentations dans des flux**

Pour écrire une présentation sans dépendre d’un chemin de fichier final, transmettez un flux inscriptible et une valeur [SaveFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveformat/) à la méthode [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save). Cette approche est utile lorsque la sortie doit être renvoyée depuis un service Web, stockée dans une base de données ou traitée en mémoire.

L’exemple suivant enregistre une nouvelle présentation dans un flux de fichier :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Enregistrer les présentations avec un type de vue prédéfini**

Vous pouvez spécifier la vue dans laquelle PowerPoint ouvre initialement une présentation enregistrée. Utilisez la méthode [ViewProperties.setLastView](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewproperties/#setLastView) avec une valeur [ViewType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewtype/) avant l’enregistrement.

L’exemple suivant configure la vue Maître des diapositives comme vue initiale :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Enregistrer les présentations au format Office Open XML strict**

Pour créer un fichier PPTX conforme au profil Strict d’Office Open XML, créez une instance [PptxOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxoptions/) et utilisez sa méthode [setConformance](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxoptions/#setConformance) avec [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict). Transmettez ensuite les options à la méthode [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Enregistrer les présentations au format Office Open XML en mode Zip64**

Une archive ZIP standard limite la taille compressée et non compressée de chaque entrée, la taille totale de l’archive et le nombre d’entrées. Comme un fichier PPTX est une archive ZIP, une présentation très volumineuse peut dépasser ces limites. Les extensions ZIP64 augmentent les limites de taille et de nombre d’entrées applicables.

Utilisez la méthode [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) pour contrôler si Aspose.Slides écrit les extensions ZIP64 :

- [IfNecessary](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/zip64mode/#IfNecessary) utilise ZIP64 uniquement lorsque la présentation dépasse les limites ZIP standard. C’est le mode par défaut.
- [Never](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/zip64mode/#Never) désactive les extensions ZIP64.
- [Always](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/zip64mode/#Always) écrit toujours les extensions ZIP64.

L’exemple suivant active toujours les extensions ZIP64 pour la présentation de sortie :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Si [Zip64Mode.Never](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/zip64mode/#Never) est utilisé et que la présentation ne peut pas tenir dans les limites ZIP standard, l’opération d’enregistrement lève une [PptxException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Enregistrer les présentations au format Office Open XML avec des niveaux de compression**

Pour la sortie PPTX, vous pouvez équilibrer la rapidité d’enregistrement et la taille du fichier en utilisant la méthode [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel). La classe [CompressionLevel](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/) fournit ces valeurs :

- [None](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#None) stocke les données sans compression.
- [Level1](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level1) offre la compression la plus rapide et la sortie compressée la plus volumineuse.
- [Level2](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level2) à [Level5](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level5) favorisent progressivement une sortie plus petite au détriment de la vitesse d’enregistrement.
- [Level6](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level6) équilibre vitesse d’enregistrement et taille du fichier. C’est le niveau par défaut.
- [Level7](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level7) et [Level8](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level8) privilégient davantage une sortie plus petite.
- [Level9](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compressionlevel/#Level9) offre la compression la plus forte et nécessite le plus de temps de traitement.

L’exemple suivant enregistre une présentation sans compression :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

L’exemple suivant utilise le niveau de compression maximal :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Enregistrer les présentations sans rafraîchir la vignette**

Lorsque une présentation est enregistrée au format PPTX, la méthode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) contrôle sa vignette de document :

- `true` régénère la vignette pendant l’opération d’enregistrement. C’est la valeur par défaut.
- `false` conserve la vignette existante. Si la présentation n’a pas de vignette, Aspose.Slides n’en crée pas.

L’exemple suivant enregistre une présentation sans rafraîchir sa vignette :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Désactiver le rafraîchissement de la vignette peut réduire le temps nécessaire à l’enregistrement d’un fichier PPTX.
{{% /alert %}}

## **Mise à jour de la progression de l’enregistrement en pourcentage**

Pour surveiller une opération d’enregistrement, implémentez l’interface [IProgressCallback](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprogresscallback/) avec un proxy Java et transmettez l’implémentation à la méthode [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides appelle alors la méthode [IProgressCallback.reporting](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iprogresscallback/#reporting-double-) avec les valeurs de progression pendant l’exportation.

L’exemple suivant signale la progression d’une exportation PDF dans la console :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose propose un [PowerPoint Splitter](https://products.aspose.app/slides/fr/splitter) gratuit, construit avec l’API Aspose.Slides. Il enregistre les diapositives sélectionnées d’une présentation en fichiers PPT ou PPTX distincts.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑t‑il en charge l’enregistrement incrémental ou le « fast save » ?**

Non. Chaque opération d’enregistrement écrit un fichier de sortie complet plutôt que de ne mettre à jour que les parties modifiées.

**Plusieurs threads peuvent‑ils enregistrer la même instance Presentation ?**

Non. Une instance [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) [n’est pas thread‑safe](/slides/fr/nodejs-java/multithreading/). Accédez et enregistrez chaque instance depuis un seul thread à la fois.

**Que se passe‑t‑il pour les hyperliens et les fichiers liés externement lorsque j’enregistre une présentation ?**

Les [hyperliens](/slides/fr/nodejs-java/manage-hyperlinks/) restent dans la présentation. Aspose.Slides ne copie pas les fichiers liés externement, la présentation enregistrée doit donc toujours pouvoir accéder à leurs emplacements.

**Puis‑je enregistrer les métadonnées du document telles que l’auteur, le titre, l’entreprise et la date de création ?**

Oui. Définissez les [propriétés du document](/slides/fr/nodejs-java/presentation-properties/) appropriées avant l’enregistrement, et Aspose.Slides les écrit dans le fichier de sortie.