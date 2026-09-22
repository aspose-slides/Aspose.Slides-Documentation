---
title: Enregistrer les présentations sur Android
linktitle: Enregistrer la présentation
type: docs
weight: 80
url: /fr/androidjava/save-presentation/
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
- format Strict Office Open XML
- mode Zip64
- actualisation de la vignette
- progression de l'enregistrement
- Android
- Java
- Aspose.Slides
description: "Enregistrez des présentations PowerPoint et OpenDocument en fichiers ou flux sur Android avec Aspose.Slides, et configurez la sortie PPTX ainsi que le reporting de progression."
---
## **Vue d'ensemble**

Après avoir créé une présentation ou [ouvrir une présentation existante](/slides/fr/androidjava/open-presentation/), utilisez la méthode [Presentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) pour écrire le résultat. Aspose.Slides for Android via Java peut enregistrer une présentation dans un fichier ou un flux aux formats PowerPoint, OpenDocument, PDF et d'autres formats. Les sections suivantes couvrent les opérations d'enregistrement standard et les options disponibles pour la sortie PPTX.

## **Enregistrer des présentations dans des fichiers**

Pour enregistrer une présentation dans un fichier, transmettez le chemin de sortie et une valeur [SaveFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveformat/) à la méthode [Presentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). La valeur du format détermine le type de fichier créé par Aspose.Slides.

L'exemple suivant crée une présentation et l'enregistre au format PPTX :

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Ajoutez ou modifiez le contenu de la présentation ici.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Enregistrer les présentations dans leur format d'origine**

Pour des exemples de détection de fichiers et de flux, le comportement des présentations nouvellement créées et la distinction entre les formats source et de sortie, voir [Determine the Original Presentation Format](/slides/fr/androidjava/detect-presentation-source-format/).

Dans une application de traitement par lots, le format d'entrée peut ne pas être connu à l'avance. Après avoir chargé un fichier, lisez son format d'origine avec la méthode [IPresentation.getSourceFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) . Transmettez la valeur [SourceFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/sourceformat/) obtenue à [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) pour obtenir la valeur [SaveFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveformat/) correspondante, puis utilisez [Presentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) pour écrire la présentation modifiée.

L'exemple complet suivant traite chaque fichier d'un répertoire d'entrée, met à jour son titre et l'enregistre dans un répertoire de sortie au même format que celui dans lequel il a été chargé :

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

SlideUtil.toSaveFormat mappe PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP et PowerPoint XML vers leurs formats d'enregistrement de présentation correspondants. Il ne mappe que les formats source de présentation ; il n'est pas destiné à sélectionner des formats d'exportation tels que PDF, HTML, TIFF ou des images. Transmettre une valeur [SourceFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/sourceformat/) non prise en charge ou invalide entraîne une [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException).

Les fichiers PPT, PPS et POT hérités utilisent le même conteneur binaire. Lorsqu'une telle présentation est chargée depuis un flux sans extension de fichier, un fichier PPS ou POT peut donc être identifié comme PPT. Si la conservation de ces sous-types hérités est requise, conservez le nom de fichier original ou les métadonnées de format séparément et utilisez‑les lors du choix du nom de fichier et du format de sortie.

## **Enregistrer des présentations dans des flux**

Pour écrire une présentation sans dépendre d'un chemin de fichier final, transmettez un flux writable et une valeur [SaveFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveformat/) à la méthode [Presentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Cette approche est utile lorsque la sortie doit être renvoyée depuis un service web, stockée dans une base de données ou traitée en mémoire.

L'exemple suivant enregistre une nouvelle présentation dans un flux de fichier :

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Enregistrer des présentations avec un type de vue prédéfini**

Vous pouvez spécifier la vue dans laquelle PowerPoint ouvre initialement une présentation enregistrée. Utilisez la méthode [ViewProperties.setLastView](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) avec une valeur [ViewType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/viewtype/) avant l'enregistrement.

L'exemple suivant configure la vue Slide Master comme vue initiale :

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Enregistrer des présentations au format Strict Office Open XML**

Pour créer un fichier PPTX conforme au profil Strict d'Office Open XML, créez une instance [PptxOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxoptions/) et utilisez sa méthode [setConformance](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) avec [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict). Transmettez ensuite les options à la méthode [Presentation.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) .

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Enregistrer des présentations au format Office Open XML en mode Zip64**

Une archive ZIP standard limite la taille compressée et non compressée de chaque entrée, la taille totale de l'archive et le nombre d'entrées. Comme un fichier PPTX est une archive ZIP, une présentation très volumineuse peut dépasser ces limites. Les extensions ZIP64 élèvent les limites de taille et de nombre d'entrées applicables.

Utilisez la méthode [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) pour contrôler si Aspose.Slides écrit les extensions ZIP64 :

- [IfNecessary](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/zip64mode/#IfNecessary) utilise ZIP64 uniquement lorsque la présentation dépasse les limites ZIP standard. C’est le mode par défaut.
- [Never](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/zip64mode/#Never) désactive les extensions ZIP64.
- [Always](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/zip64mode/#Always) écrit toujours les extensions ZIP64.

L'exemple suivant active toujours les extensions ZIP64 pour la présentation de sortie :

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Si [Zip64Mode.Never](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/zip64mode/#Never) est utilisé et que la présentation ne peut pas tenir dans les limites ZIP standard, l'opération d'enregistrement lève une [PptxException](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Enregistrer des présentations au format Office Open XML avec niveaux de compression**

Pour la sortie PPTX, vous pouvez équilibrer la vitesse d'enregistrement et la taille du fichier en utilisant la méthode [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-). La classe [CompressionLevel](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/) fournit les valeurs suivantes :

- [None](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#None) stocke les données sans compression.
- [Level1](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level1) offre la compression la plus rapide et la sortie compressée la plus volumineuse.
- [Level2](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level2) à [Level5](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level5) favorisent progressivement une sortie plus petite au détriment de la vitesse d'enregistrement.
- [Level6](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level6) équilibre vitesse d'enregistrement et taille du fichier. C’est le niveau par défaut.
- [Level7](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level7) et [Level8](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level8) privilégient encore davantage une sortie plus petite.
- [Level9](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/compressionlevel/#Level9) fournit la compression la plus forte et nécessite le plus de temps de traitement.

L'exemple suivant enregistre une présentation sans compression :

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

L'exemple suivant utilise le niveau de compression maximal :

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Enregistrer des présentations sans actualiser la vignette**

Lorsqu'une présentation est enregistrée au format PPTX, la méthode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) contrôle sa vignette de document :

- `true` régénère la vignette pendant l'opération d'enregistrement. C’est la valeur par défaut.
- `false` conserve la vignette existante. Si la présentation n'a pas de vignette, Aspose.Slides n'en génère pas.

L'exemple suivant enregistre une présentation sans actualiser sa vignette :

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Désactiver le rafraîchissement de la vignette peut réduire le temps nécessaire à l'enregistrement d'un fichier PPTX.
{{% /alert %}}

## **Mises à jour de la progression de l'enregistrement en pourcentage**

Pour suivre une opération d'enregistrement, implémentez l'interface [IProgressCallback](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iprogresscallback/) et transmettez l'implémentation à la méthode [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-). Aspose.Slides appelle alors la méthode [IProgressCallback.reporting](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) avec des valeurs de progression pendant l'exportation.

L'exemple suivant signale la progression d'une exportation PDF dans la console :

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose propose un [PowerPoint Splitter](https://products.aspose.app/slides/fr/splitter) gratuit, développé avec l'API Aspose.Slides. Il enregistre les diapositives sélectionnées d'une présentation en tant que fichiers PPT ou PPTX séparés.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑il en charge l'enregistrement incrémentiel ou « fast save » ?**  
Non. Chaque opération d'enregistrement écrit un fichier complet plutôt que de ne mettre à jour que les parties modifiées.

**Plusieurs threads peuvent‑ils enregistrer la même instance de Presentation ?**  
Non. Une instance de [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) n'est pas thread‑safe. Accédez et enregistrez chaque instance à partir d'un seul thread à la fois.

**Que se passe‑t‑il pour les hyperliens et les fichiers liés externement lors de l'enregistrement d'une présentation ?**  
Les [hyperliens](/slides/fr/androidjava/manage-hyperlinks/) restent dans la présentation. Aspose.Slides ne copie pas les fichiers liés externement, donc la présentation enregistrée doit toujours pouvoir accéder à leurs emplacements.

**Puis‑je enregistrer les métadonnées du document telles que l'auteur, le titre, l'entreprise et la date de création ?**  
Oui. Définissez les [propriétés du document](/slides/fr/androidjava/presentation-properties/) appropriées avant l'enregistrement, et Aspose.Slides les écrit dans le fichier de sortie.