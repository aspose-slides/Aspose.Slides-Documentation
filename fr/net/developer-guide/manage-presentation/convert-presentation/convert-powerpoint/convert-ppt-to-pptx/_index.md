---
title: Convertir les fichiers PPT en PPTX avec .NET
linktitle: PPT en PPTX
type: docs
weight: 20
url: /fr/net/convert-ppt-to-pptx/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- PPT en PPTX
- enregistrer PPT en PPTX
- exporter PPT en PPTX
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Convertissez les fichiers PPT hérités en PPTX avec .NET et Aspose.Slides. Inclut des exemples C# pour la conversion d’un fichier unique et en lot, la gestion des erreurs et des notes de fidélité."
---
## **Vue d'ensemble**

PPT est le format binaire hérité de PowerPoint, tandis que PPTX est le format Open XML plus récent. Aspose.Slides pour .NET peut charger un fichier PPT et l’enregistrer au format PPTX sans Microsoft PowerPoint. Cet article montre comment convertir un fichier ou un répertoire de fichiers et explique ce qu’il faut vérifier après la conversion.

## **Convertir un fichier PPT en PPTX**

Chargez le fichier source avec la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/), puis appelez [IPresentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/save/) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/). La déclaration `using` libère la présentation et ses ressources à la fin du bloc.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// Charger la présentation PPT héritée.
using var presentation = new Presentation("presentation.ppt");

// Enregistrer la présentation au format PPTX.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

L’extension du fichier ne sélectionne pas le format de sortie à elle seule ; c’est l’argument [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/) qui le fait. Conservez des chemins d’entrée et de sortie différents si vous devez conserver le fichier PPT original.

## **Convertir plusieurs fichiers PPT**

L’exemple suivant convertit chaque fichier `.ppt` d’un répertoire. Chaque fichier est traité indépendamment, de sorte qu’une conversion échouée n’arrête pas le reste du lot.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

Pour les charges de travail de production, consignez l’exception complète, décidez si un fichier de sortie existant peut être écrasé, et écrivez les noms de fichiers ayant échoué dans une file d’attente de réessai ou de révision. Les fichiers corrompus, les fichiers protégés par mot de passe ouverts sans le mot de passe requis, les chemins inaccessibles et le contenu non pris en charge peuvent tous entraîner un échec de conversion. Voir [Password-Protected Presentations](/slides/fr/net/password-protected-presentation/) pour le chargement des fichiers chiffrés.

## **Fidélité et fonctionnalités héritées**

La conversion préserve normalement les diapositives, les maîtres, les dispositions, le texte, les formes, les images, les tableaux et les graphiques. Cependant, PPT et PPTX ne représentent pas chaque fonctionnalité de la même manière. Une fonctionnalité héritée qui n’a pas d’équivalent PPTX, ou qui n’est pas prise en charge par la bibliothèque, peut être normalisée, omise ou affichée différemment.

Vérifiez le fichier converti lorsqu’il contient des animations, des transitions, des objets OLE incorporés ou liés, des contrôles ActiveX, des médias intégrés, des polices rares ou des macros VBA. Un fichier PPTX ordinaire n’est pas un format activé pour les macros, il faut donc utiliser un flux de travail approprié lorsqu’il faut conserver les macros VBA. Vérifiez également que les polices requises et les ressources externes sont présentes dans l’environnement où la présentation convertie sera ouverte ou rendue.

Pour les documents importants, rouvrez le PPTX généré de façon programmatique et inspectez le nombre de diapositives et le contenu clés, puis comparez son apparence et le comportement du diaporama dans le visualiseur prévu. Ne considérez pas qu’un appel réussi à [IPresentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/save/) prouve que chaque fonctionnalité héritée a une représentation PPTX exacte.

## **Quand utiliser PPTX**

Utilisez PPTX lorsque la présentation sera modifiée dans les versions actuelles de PowerPoint, échangée avec des systèmes qui travaillent avec des packages Open XML, ou stockée dans un format plus facile à inspecter et à récupérer que le PPT binaire hérité. Conservez le PPT original comme copie d’archivage ou de restauration jusqu’à ce que la présentation convertie ait passé vos contrôles de fidélité.

Si vous avez besoin de PDF, HTML, images, XPS ou d’un autre type de sortie à la place, utilisez les conseils spécifiques au format dans [Convert Presentations to Multiple Formats](/slides/fr/net/convert-presentation/) plutôt que de supposer que toutes les cibles conservent les fonctionnalités modifiables de PowerPoint.

## **Convertisseur en ligne**

Pour un fichier occasionnel ou une comparaison rapide, vous pouvez utiliser le [convertisseur PPT en PPTX en ligne](https://products.aspose.app/slides/fr/conversion/ppt-to-pptx). Pour des conversions répétables, un traitement par lots ou une gestion des erreurs au niveau de l’application, utilisez l’API .NET.

## **Articles associés**

- [PPT vs PPTX](/slides/fr/net/ppt-vs-pptx/)
- [Enregistrer des présentations en .NET](/slides/fr/net/save-presentation/)
- [Formats de fichiers pris en charge](/slides/fr/net/supported-file-formats/)
- [Ouvrir des présentations en .NET](/slides/fr/net/open-presentation/)

## **FAQ**

**Puis-je convertir PPT en PPTX sans Microsoft PowerPoint installé ?**

Oui. Aspose.Slides pour .NET charge et enregistre les fichiers de présentation sans nécessiter Microsoft PowerPoint.

**La conversion de PPT en PPTX conservera-t-elle tout le contenu exactement ?**

Elle préserve le contenu de présentation courant, mais la fidélité exacte n’est pas garantie pour chaque fonctionnalité héritée ou non prise en charge. Examinez le fichier généré lorsqu’il contient des macros, des objets OLE ou ActiveX, des médias, des animations spécialisées ou des polices rares.

**Puis-je convertir un fichier PPT protégé par mot de passe ?**

Oui, si vous fournissez le mot de passe correct lors du chargement du fichier. Un mot de passe manquant ou incorrect entraîne l’échec de l’opération de chargement.

**Dois-je supprimer le fichier PPT après la conversion ?**

Conservez l’original jusqu’à ce que vous ayez vérifié le PPTX dans les visualiseurs et les flux de travail qui vous importent. Cela fournit une copie de restauration si une fonctionnalité héritée se convertit différemment.