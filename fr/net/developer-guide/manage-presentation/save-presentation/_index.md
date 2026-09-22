---
title: Enregistrer des présentations en .NET
linktitle: Enregistrer la présentation
type: docs
weight: 80
url: /fr/net/save-presentation/
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
- Format Office Open XML strict
- mode Zip64
- rafraîchissement de la vignette
- progression d’enregistrement
- .NET
- C#
- Aspose.Slides
description: "Enregistrez des présentations PowerPoint et OpenDocument vers des fichiers ou des flux en C# avec Aspose.Slides pour .NET, et configurez la sortie PPTX ainsi que le suivi de progression."
---
## **Aperçu**

Après avoir créé une présentation ou [ouvrir une présentation existante](/slides/fr/net/open-presentation/), utilisez la méthode [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) pour écrire le résultat. Aspose.Slides for .NET peut enregistrer une présentation dans un fichier ou un flux aux formats PowerPoint, OpenDocument, PDF et d’autres. Les sections suivantes couvrent les opérations d’enregistrement standard ainsi que les options disponibles pour la sortie PPTX.

## **Enregistrer des présentations dans des fichiers**

Pour enregistrer une présentation dans un fichier, transmettez le chemin de sortie et une valeur [SaveFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/) à la méthode [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/). La valeur du format détermine le type de fichier créé par Aspose.Slides.

L’exemple suivant crée une présentation et l’enregistre sous forme de fichier PPTX :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Enregistrer les présentations dans leur format d’origine**

Pour les exemples de détection de fichier et de flux, le comportement des présentations nouvellement créées et la distinction entre les formats source et de sortie, consultez [Déterminer le format d’origine de la présentation](/slides/fr/net/detect-presentation-source-format/).

Dans une application de traitement par lots, le format d’entrée peut ne pas être connu à l’avance. Après avoir chargé un fichier, lisez son format d’origine à partir de la propriété [IPresentation.SourceFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/sourceformat/). Transmettez la valeur [SourceFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/sourceformat/) obtenue à [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.util/slideutil/tosaveformat/) pour obtenir la valeur correspondante de [SaveFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/), puis utilisez [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) pour écrire la présentation modifiée.

L’exemple complet suivant traite chaque fichier d’un répertoire d’entrée, met à jour son titre et l’enregistre dans un répertoire de sortie au même format que celui d’origine :

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.util/slideutil/tosaveformat/) associe PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP et PowerPoint XML à leurs formats d’enregistrement de présentation correspondants. Il ne mappe que les formats source de présentation ; il n’est pas destiné à sélectionner des formats d’exportation tels que PDF, HTML, TIFF ou images. Transmettre une valeur [SourceFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/sourceformat/) non prise en charge ou invalide entraîne une [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception).

Les fichiers PPT, PPS et POT hérités utilisent le même conteneur binaire. Lorsqu’une telle présentation est chargée à partir d’un flux sans extension de fichier, un fichier PPS ou POT peut donc être identifié comme PPT. Si la préservation de ces sous‑types hérités est requise, conservez le nom de fichier ou les métadonnées de format d’origine séparément et utilisez‑les lors du choix du nom de fichier et du format de sortie.

## **Enregistrer des présentations dans des flux**

Pour écrire une présentation sans dépendre d’un chemin de fichier final, transmettez un [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) accessible en écriture et une valeur [SaveFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/) à la méthode [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/). Cette approche est utile lorsque la sortie doit être renvoyée depuis un service Web, stockée dans une base de données ou traitée en mémoire.

L’exemple suivant enregistre une nouvelle présentation dans un flux de fichier :

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Enregistrer des présentations avec un type de vue prédéfini**

Vous pouvez spécifier la vue dans laquelle PowerPoint ouvre initialement une présentation enregistrée. Définissez la propriété [ViewProperties.LastView](https://reference.aspose.com/slides/fr/net/aspose.slides/viewproperties/lastview/) sur une valeur [ViewType](https://reference.aspose.com/slides/fr/net/aspose.slides/viewtype/) avant l’enregistrement.

L’exemple suivant configure la vue Masque des diapositives comme vue initiale :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Enregistrer des présentations au format Strict Office Open XML**

Pour créer un fichier PPTX conforme au profil Strict d’Office Open XML, créez une instance de [PptxOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pptxoptions/) et définissez sa propriété [Conformance](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pptxoptions/conformance/) sur `Conformance.Iso29500_2008_Strict`. Transmettez ensuite les options à la méthode [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Enregistrer des présentations au format Office Open XML en mode Zip64**

Une archive ZIP standard limite la taille compressée et non compressée de chaque entrée, la taille totale de l’archive et le nombre d’entrées. Étant donné qu’un fichier PPTX est une archive ZIP, une présentation très volumineuse peut dépasser ces limites. Les extensions ZIP64 augmentent les limites de taille et de nombre d’entrées applicables.

Utilisez la propriété [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pptxoptions/zip64mode/) pour contrôler si Aspose.Slides écrit les extensions ZIP64 :

- `IfNecessary` utilise ZIP64 uniquement lorsque la présentation dépasse les limites ZIP standard. C’est le mode par défaut.
- `Never` désactive les extensions ZIP64.
- `Always` écrit toujours les extensions ZIP64.

L’exemple suivant active toujours les extensions ZIP64 pour la présentation de sortie :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
Si `Zip64Mode` est défini sur `Never` et que la présentation ne tient pas dans les limites ZIP standard, l’opération d’enregistrement lève une [PptxException](https://reference.aspose.com/slides/fr/net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Enregistrer des présentations au format Office Open XML avec niveaux de compression**

Pour la sortie PPTX, vous pouvez équilibrer la vitesse d’enregistrement et la taille du fichier en définissant la propriété [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pptxoptions/compressionlevel/). L’énumération [CompressionLevel](https://reference.aspose.com/slides/fr/net/aspose.slides.export/compressionlevel/) fournit ces valeurs :

- `None` stocke les données sans compression.
- `Level1` offre la compression la plus rapide et le fichier compressé le plus volumineux.
- `Level2` à `Level5` privilégient progressivement une taille de sortie plus petite au détriment de la vitesse d’enregistrement.
- `Level6` équilibre vitesse d’enregistrement et taille du fichier. C’est le niveau par défaut.
- `Level7` et `Level8` favorisent davantage une sortie plus petite.
- `Level9` offre la compression la plus forte et nécessite le plus de temps de traitement.

L’exemple suivant enregistre une présentation sans compression :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

L’exemple suivant utilise le niveau de compression maximal :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **Enregistrer des présentations sans actualiser la vignette**

Lorsqu’une présentation est enregistrée au format PPTX, la propriété [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pptxoptions/refreshthumbnail/) contrôle la vignette du document :

- `true` régénère la vignette pendant l’opération d’enregistrement. C’est la valeur par défaut.
- `false` préserve la vignette existante. Si la présentation n’a pas de vignette, Aspose.Slides n’en crée pas.

L’exemple suivant enregistre une présentation sans actualiser sa vignette :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
Désactiver le rafraîchissement de la vignette peut réduire le temps nécessaire à l’enregistrement d’un fichier PPTX.
{{% /alert %}}

## **Mises à jour de progression d’enregistrement en pourcentage**

Pour surveiller une opération d’enregistrement, implémentez l’interface [IProgressCallback](https://reference.aspose.com/slides/fr/net/aspose.slides/iprogresscallback/) et assignez l’implémentation à la propriété [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/fr/net/aspose.slides.export/isaveoptions/progresscallback/). Aspose.Slides appelle alors la méthode [IProgressCallback.Reporting](https://reference.aspose.com/slides/fr/net/aspose.slides/iprogresscallback/reporting/) avec les valeurs de progression pendant l’exportation.

L’exemple suivant signale la progression d’une exportation PDF dans la console :

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose propose un [PowerPoint Splitter](https://products.aspose.app/slides/fr/splitter) gratuit, construit avec l’API Aspose.Slides. Il enregistre les diapositives sélectionnées d’une présentation en fichiers PPT ou PPTX séparés.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑il en charge l’enregistrement incrémental ou le « fast save » ?**

Non. Chaque opération d’enregistrement écrit un fichier de sortie complet plutôt que de ne mettre à jour que les parties modifiées.

**Plusieurs threads peuvent‑ils enregistrer la même instance de Presentation ?**

Non. Une instance de [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) [n’est pas thread‑safe](/slides/fr/net/multithreading/). Accédez‑la et enregistrez chaque instance depuis un seul thread à la fois.

**Que se passe‑t‑il avec les hyperliens et les fichiers liés externement lorsque j’enregistre une présentation ?**

Les [hyperliens](/slides/fr/net/manage-hyperlinks/) restent dans la présentation. Aspose.Slides ne copie pas les fichiers liés externement, de sorte que la présentation enregistrée doit toujours pouvoir accéder à leurs emplacements.

**Puis‑je enregistrer les métadonnées du document telles que l’auteur, le titre, l’entreprise et la date de création ?**

Oui. Définissez les [propriétés du document](/slides/fr/net/presentation-properties/) appropriées avant l’enregistrement, et Aspose.Slides les écrit dans le fichier de sortie.