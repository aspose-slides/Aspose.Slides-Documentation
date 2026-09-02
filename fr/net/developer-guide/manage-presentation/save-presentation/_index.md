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
- format Strict Office Open XML
- mode Zip64
- rafraîchissement de la miniature
- progression de l'enregistrement
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment enregistrer des présentations en .NET avec Aspose.Slides — exportez vers PowerPoint ou OpenDocument tout en conservant les mises en page, les polices et les effets."
---
## **Vue d'ensemble**

[Ouvrir des présentations en C#](/slides/fr/net/open-presentation/) décrit comment utiliser la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) pour ouvrir une présentation. Cet article explique comment créer et enregistrer des présentations. La classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) contient le contenu d’une présentation. Que vous créiez une présentation à partir de zéro ou que vous modifiiez une existante, vous souhaiterez l’enregistrer une fois terminé. Avec Aspose.Slides pour .NET, vous pouvez enregistrer dans un **fichier** ou un **flux**. Cet article explique les différentes manières d’enregistrer une présentation.

## **Enregistrer les présentations dans des fichiers**

Enregistrez une présentation dans un fichier en appelant la méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/). Passez le nom du fichier et le format d’enregistrement à la méthode. L’exemple suivant montre comment enregistrer une présentation avec Aspose.Slides.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Effectuez du travail ici...

    // Enregistre la présentation dans un fichier.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Enregistrer les présentations dans des flux**

Vous pouvez enregistrer une présentation dans un flux en transmettant un flux de sortie à la méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/). Une présentation peut être écrite vers de nombreux types de flux. Dans l’exemple ci‑dessous, nous créons une nouvelle présentation et l’enregistrons dans un flux de fichier.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancie la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Enregistre la présentation dans le flux.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Enregistrer les présentations avec un type de vue prédéfini**

Aspose.Slides vous permet de définir la vue initiale que PowerPoint utilise lorsque la présentation générée s’ouvre via la classe [ViewProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/viewproperties/). Définissez la propriété [LastView](https://reference.aspose.com/slides/fr/net/aspose.slides/viewproperties/lastview/) sur une valeur de l’énumération [ViewType](https://reference.aspose.com/slides/fr/net/aspose.slides/viewtype/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Enregistrer les présentations au format Strict Office Open XML**

Aspose.Slides vous permet d’enregistrer une présentation au format Strict Office Open XML. Utilisez la classe [PptxOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pptxoptions/) et définissez sa propriété de conformité lors de l’enregistrement. Si vous définissez `Conformance.Iso29500_2008_Strict`, le fichier de sortie est enregistré au format Strict Office Open XML.

L’exemple ci‑dessous crée une présentation et l’enregistre au format Strict Office Open XML.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instancie la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Enregistre la présentation au format Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Enregistrer les présentations au format Office Open XML en mode Zip64**

Un fichier Office Open XML est une archive ZIP qui impose des limites de 4 Go (2^32 octets) sur la taille décompressée de tout fichier, la taille compressée de tout fichier et la taille totale de l’archive, ainsi qu’une limite de 65 535 (2^16‑1) fichiers. Les extensions de format ZIP64 élèvent ces limites à 2^64.

La propriété [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ipptxoptions/zip64mode/) vous permet de choisir quand utiliser les extensions de format ZIP64 lors de l’enregistrement d’un fichier Office Open XML.

Cette propriété propose les modes suivants :

- `IfNecessary` utilise les extensions de format ZIP64 uniquement si la présentation dépasse les limitations ci‑dessus. C’est le mode par défaut.
- `Never` n’utilise jamais les extensions de format ZIP64.
- `Always` utilise toujours les extensions de format ZIP64.

Le code suivant montre comment enregistrer une présentation au format PPTX avec les extensions ZIP64 activées :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
Lorsque vous enregistrez avec `Zip64Mode.Never`, une [PptxException](https://reference.aspose.com/slides/fr/net/aspose.slides/pptxexception/) est levée si la présentation ne peut pas être enregistrée au format ZIP32.
{{% /alert %}}

## **Enregistrer les présentations au format Office Open XML avec niveaux de compression**

Lorsque vous travaillez avec de grandes présentations, vous pouvez ajuster le niveau de compression afin d’équilibrer la taille du fichier et le temps de traitement. Selon vos besoins, vous pouvez privilégier un traitement plus rapide ou des fichiers de sortie plus petits.

Aspose.Slides fournit la propriété [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ipptxoptions/compressionlevel/), qui vous permet de spécifier le niveau de compression utilisé lors de l’enregistrement d’une présentation au format Office Open XML.

Les niveaux de compression disponibles sont :

- **None** : Aucune compression n’est appliquée. Les fichiers sont stockés tels quels.
- **Level1** : La compression la plus rapide avec le taux de compression le plus bas.
- **Level2** : Compression plus rapide avec un taux de compression légèrement meilleur que **Level1**.
- **Level3** : Offre une meilleure compression que **Level2** avec un impact modéré sur le temps de traitement.
- **Level4** : Offre une meilleure compression que **Level3**.
- **Level5** : Offre une compression améliorée par rapport à **Level4** avec un temps de traitement supplémentaire.
- **Level6** : Compression standard qui offre un bon équilibre entre vitesse de traitement et taille de fichier. C’est le *niveau de compression par défaut*.
- **Level7** : Offre une meilleure compression que **Level6** avec un traitement plus lent.
- **Level8** : Offre une meilleure compression que **Level7**.
- **Level9** : Compression maximale. Produit la plus petite taille de fichier au prix du temps de traitement le plus long.

L’exemple suivant montre comment enregistrer une présentation au format PPTX *sans compression* :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Cet exemple montre comment enregistrer une présentation au format PPTX avec *la compression maximale* :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Enregistrer les présentations sans rafraîchir la miniature**

La propriété [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) contrôle la génération de la miniature lors de l’enregistrement d’une présentation au format PPTX :

- Si elle est définie sur `true`, la miniature est rafraîchie pendant l’enregistrement. C’est la valeur par défaut.
- Si elle est définie sur `false`, la miniature actuelle est conservée. Si la présentation ne possède pas de miniature, aucune n’est générée.

Dans le code ci‑dessous, la présentation est enregistrée au format PPTX sans rafraîchir sa miniature.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Cette option permet de réduire le temps nécessaire à l’enregistrement d’une présentation au format PPTX.
{{% /alert %}}

## **Enregistrer les mises à jour de progression en pourcentage**

L’interface [IProgressCallback](https://reference.aspose.com/slides/fr/net/aspose.slides/iprogresscallback/) est utilisée via la propriété `ProgressCallback` exposée par l’interface [ISaveOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/isaveoptions/) et la classe abstraite [SaveOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveoptions/). Assignez une implémentation de [IProgressCallback](https://reference.aspose.com/slides/fr/net/aspose.slides/iprogresscallback/) à `ProgressCallback` pour recevoir les mises à jour de progression de l’enregistrement sous forme de pourcentage.

Les extraits de code suivants montrent comment utiliser `IProgressCallback`.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Utilisez la valeur du pourcentage de progression ici.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose a développé une [application gratuite de découpe de PowerPoint](https://products.aspose.app/slides/fr/splitter) utilisant sa propre API. L’application vous permet de diviser une présentation en plusieurs fichiers en enregistrant les diapositives sélectionnées en nouveaux fichiers PPTX ou PPT.
{{% /alert %}}

## **FAQ**

**La sauvegarde rapide (enregistrement incrémentiel) est‑elle prise en charge afin que seules les modifications soient écrites ?**

Non. L’enregistrement crée le fichier complet cible à chaque fois ; la sauvegarde incrémentielle « fast save » n’est pas prise en charge.

**Est‑il sûr d’enregistrer la même instance Presentation depuis plusieurs threads ?**

Non. Une instance [Presentation] n’est pas thread‑safe (/slides/fr/net/multithreading/) ; enregistrez‑la depuis un seul thread.

**Que se passe‑t‑il avec les hyperliens et les fichiers liés externement lors de l’enregistrement ?**

Les [Hyperlinks](/slides/fr/net/manage-hyperlinks/) sont conservés. Les fichiers liés externement (p. ex. des vidéos via des chemins relatifs) ne sont pas copiés automatiquement — veuillez vous assurer que les chemins référencés restent accessibles.

**Puis‑je définir/enregistrer les métadonnées du document (Auteur, Titre, Société, Date) ?**

Oui. Les [document properties](/slides/fr/net/presentation-properties/) standard sont pris en charge et seront écrits dans le fichier lors de l’enregistrement.