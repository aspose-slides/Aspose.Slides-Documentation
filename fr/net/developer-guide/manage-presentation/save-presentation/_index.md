---
title: Enregistrer des présentations dans .NET
linktitle: Enregistrer des présentations
type: docs
weight: 80
url: /fr/net/save-presentation/
keywords:
- sauvegarder PowerPoint
- sauvegarder OpenDocument
- sauvegarder une présentation
- sauvegarder une diapositive
- sauvegarder PPT
- sauvegarder PPTX
- sauvegarder ODP
- présentation vers fichier
- présentation vers flux
- type de vue prédéfini
- format Strict Office Open XML
- mode Zip64
- rafraîchissement de la miniature
- progression de la sauvegarde
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment enregistrer des présentations dans .NET avec Aspose.Slides — exportez vers PowerPoint ou OpenDocument tout en conservant la mise en page, les polices et les effets."
---

## **Vue d'ensemble**

[Open Presentations in C#](/slides/fr/net/open-presentation/) décrit comment utiliser la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) pour ouvrir une présentation. Cet article explique comment créer et enregistrer des présentations. La classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) contient le contenu d’une présentation. Que vous créiez une présentation à partir de zéro ou que vous modifiiez une existante, vous voudrez l’enregistrer une fois terminé. Avec Aspose.Slides pour .NET, vous pouvez enregistrer dans un **fichier** ou un **flux**. Cet article explique les différentes manières d’enregistrer une présentation.

## **Enregistrer les présentations dans des fichiers**

Enregistrez une présentation dans un fichier en appelant la méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Passez le nom du fichier et le format d’enregistrement à la méthode. L’exemple suivant montre comment enregistrer une présentation avec Aspose.Slides.
```cs
// Instanciez la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Effectuez des opérations ici...

    // Enregistrez la présentation dans un fichier.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **Enregistrer les présentations dans des flux**

Vous pouvez enregistrer une présentation dans un flux en transmettant un flux de sortie à la méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Une présentation peut être écrite vers de nombreux types de flux. Dans l’exemple ci‑dessous, nous créons une nouvelle présentation et l’enregistrons dans un flux de fichier.
```cs
// Instanciez la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Enregistrez la présentation dans le flux.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```


## **Enregistrer les présentations avec un type de vue prédéfini**

Aspose.Slides vous permet de définir la vue initiale que PowerPoint utilise lorsque la présentation générée s’ouvre via la classe [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/). Définissez la propriété [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/lastview/) sur une valeur de l’énumération [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype/).
```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```


## **Enregistrer les présentations au format Strict Office Open XML**

Aspose.Slides vous permet d’enregistrer une présentation au format Strict Office Open XML. Utilisez la classe [PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/) et définissez sa propriété de conformité lors de l’enregistrement. Si vous définissez `Conformance.Iso29500_2008_Strict`, le fichier de sortie est enregistré au format Strict Office Open XML.

L’exemple ci‑dessous crée une présentation et l’enregistre au format Strict Office Open XML.
```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instanciez la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation())
{
    // Enregistrez la présentation au format Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```


## **Enregistrer les présentations au format Office Open XML en mode Zip64**

Un fichier Office Open XML est une archive ZIP qui impose des limites de 4 Go (2^32 octets) sur la taille non compressée de tout fichier, la taille compressée de tout fichier et la taille totale de l’archive, ainsi que 65 535 (2^16‑1) fichiers. Les extensions du format ZIP64 élèvent ces limites à 2^64.

La propriété [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) vous permet de choisir quand utiliser les extensions du format ZIP64 lors de l’enregistrement d’un fichier Office Open XML.

Cette propriété propose les modes suivants :

- `IfNecessary` utilise les extensions de format ZIP64 uniquement si la présentation dépasse les limitations ci‑above. C’est le mode par défaut.
- `Never` n’utilise jamais les extensions de format ZIP64.
- `Always` utilise toujours les extensions de format ZIP64.

Le code suivant montre comment enregistrer une présentation au format PPTX avec les extensions ZIP64 activées :
```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```


{{% alert title="NOTE" color="warning" %}}
Lorsque vous enregistrez avec `Zip64Mode.Never`, une [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) est levée si la présentation ne peut pas être enregistrée au format ZIP32.
{{% /alert %}}

## **Enregistrer les présentations sans actualiser la miniature**

La propriété [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) contrôle la génération de la miniature lors de l’enregistrement d’une présentation au format PPTX :

- Si la valeur est `true`, la miniature est actualisée lors de l’enregistrement. C’est la valeur par défaut.
- Si la valeur est `false`, la miniature actuelle est conservée. Si la présentation n’a pas de miniature, aucune n’est générée.

Dans le code ci‑dessous, la présentation est enregistrée au format PPTX sans actualiser sa miniature.
```cs
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

L’interface [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) est utilisée via la propriété `ProgressCallback` exposée par l’interface [ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions/) et la classe abstraite [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/). Assignez une implémentation de [IProgressCallback](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback/) à `ProgressCallback` pour recevoir les mises à jour de progression d’enregistrement en pourcentage.

Les extraits de code suivants montrent comment utiliser `IProgressCallback`.
```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
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
Aspose a développé une [application gratuite PowerPoint Splitter](https://products.aspose.app/slides/splitter) utilisant sa propre API. L’application vous permet de diviser une présentation en plusieurs fichiers en enregistrant les diapositives sélectionnées comme nouveaux fichiers PPTX ou PPT.
{{% /alert %}}

## **FAQ**

**La sauvegarde rapide (sauvegarde incrémentielle) est-elle prise en charge afin que seules les modifications soient écrites ?**

Non. L’enregistrement crée le fichier complet cible à chaque fois ; la « sauvegarde rapide » incrémentielle n’est pas prise en charge.

**Est‑il sûr d’enregistrer la même instance Presentation depuis plusieurs threads ?**

Non. Une instance [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) n’est pas thread‑safe ; enregistrez‑la depuis un seul thread.

**Que se passe‑t‑il pour les hyperliens et les fichiers liés externement lors de l’enregistrement ?**

[Hyperlinks](/slides/fr/net/manage-hyperlinks/) sont conservés. Les fichiers liés externes (par ex. vidéos via des chemins relatifs) ne sont pas copiés automatiquement — assurez‑vous que les chemins référencés restent accessibles.

**Puis‑je définir/enregistrer les métadonnées du document (Auteur, Titre, Société, Date) ?**

Oui. Les propriétés standard du document sont prises en charge et seront écrites dans le fichier lors de l’enregistrement.