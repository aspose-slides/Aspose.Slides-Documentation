---
title: Déterminer le format de présentation d'origine en .NET
linktitle: Format source
type: docs
weight: 35
url: /fr/net/detect-presentation-source-format/
keywords:
- "format source"
- "détecter le format de la présentation"
- PowerPoint
- OpenDocument
- présentation
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "Lire le format d'origine d'une présentation chargée en C# avec Aspose.Slides pour .NET, comparer les API de détection et gérer les fichiers, les flux et les formats hérités."
---
## **Vue d'ensemble**

Après le chargement d'une présentation, lisez la propriété en lecture seule [Presentation.SourceFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/sourceformat/) pour déterminer son format d'origine. La propriété est également disponible via [IPresentation.SourceFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/sourceformat/). Utilisez‑la lorsque le traitement ultérieur dépend du format à partir duquel l'instance actuelle a été chargée.

Le format source est distinct du [SaveFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/) sélectionné pour un fichier de sortie. Enregistrer dans un autre format ne modifie pas le format source de l'instance existante.

## **Lire le format source d'un fichier**

Cet exemple nécessite un fichier `sample.pptx` existant. Il charge le fichier et sélectionne une politique de traitement d'application en utilisant [Presentation.SourceFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/sourceformat/), plutôt que le nom de fichier. Modifiez le chemin d'entrée pour tester d'autres formats. L'exemple affiche la politique sélectionnée ; remplacez les messages par la logique de votre application.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **Reconnaître les valeurs prises en charge**

L'énumération [SourceFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/sourceformat/) distingue les formats de présentation suivants. Les extensions ci‑dessous sont des extensions conventionnelles, et non une reconstruction du nom de fichier d'origine.

| Valeur SourceFormat | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | présentation PowerPoint 97–2003 |
| `Pptx` | `.pptx` | présentation Office Open XML |
| `Pptm` | `.pptm` | présentation Office Open XML avec macros |
| `Pps` | `.pps` | diaporama PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | diaporama Office Open XML |
| `Ppsm` | `.ppsm` | diaporama Office Open XML avec macros |
| `Pot` | `.pot` | modèle PowerPoint 97–2003 |
| `Potx` | `.potx` | modèle Office Open XML |
| `Potm` | `.potm` | modèle Office Open XML avec macros |
| `Odp` | `.odp` | présentation OpenDocument |
| `Otp` | `.otp` | modèle de présentation OpenDocument |
| `Fodp` | `.fodp` | présentation ODF XML plat |
| `Xml` | `.xml` | présentation PowerPoint XML |

## **Lire le format source d'un flux**

Cet exemple nécessite un fichier `sample.pps` existant. Lire ses octets dans un flux mémoire représente une entrée reçue sans nom de fichier, par exemple une valeur provenant d'une base de données ou un tableau d'octets téléchargé. Le constructeur [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) ne reçoit que le flux.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT, PPS et POT utilisent le même format binaire sous‑jacent. Lors du chargement par chemin de fichier, l'extension peut aider à distinguer un diaporama ou un modèle. Sans nom de fichier, le contenu hérité PPS et POT peut être signalé comme `SourceFormat.Ppt` ; l'exemple PPS ci‑dessus signale `Ppt`.

Si votre application doit préserver cette distinction, conservez séparément le nom de fichier d'origine ou les métadonnées de sous‑type. Une extension constitue un indice utile pour ces sous‑types hérités, mais ne doit pas être le seul critère d'identification d'un contenu de présentation arbitraire.

## **Comparer la détection avant et après le chargement**

Utilisez [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/presentationfactory/getpresentationinfo/) et [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/loadformat/) lorsque vous devez inspecter un fichier avant de charger son modèle complet d'objet présentation. Utilisez [Presentation.SourceFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/sourceformat/) lorsque l'instance existe déjà.

Cet exemple nécessite `sample.pptx` et affiche `Pptx` pour les deux vérifications. En production, choisissez l'API appropriée à votre étape de traitement ; une présentation déjà chargée ne nécessite pas une seconde inspection uniquement pour obtenir son format source.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

Les résultats ont des types d'énumération différents : [LoadFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/loadformat/) et [SourceFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/sourceformat/). Ne les comparez pas en convertissant leurs valeurs numériques ni ne supposez pas que chaque format donne des résultats de détection identiques. Dans le contrôle sauvegarde‑reouverture décrit ci‑dessous, le XML PowerPoint était signalé comme `LoadFormat.Unknown` avant le chargement et comme `SourceFormat.Xml` après le chargement.

## **Maintenir les formats source et de sortie séparés**

Cet exemple nécessite `sample.pptx` et écrit `converted.odp`. Il affiche `Pptx` avant et après la sauvegarde de l'instance originale. Seule la nouvelle instance chargée à partir de la sortie ODP signale `Odp`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

Une présentation créée à partir de zéro avec `new Presentation()` signale `SourceFormat.Pptx`. Elle n'a pas de fichier d'entrée : il s'agit de la valeur par défaut pour une instance nouvellement créée, et non d'une preuve qu'un fichier PPTX a été chargé. Suivez séparément si votre application a créé ou chargé l'instance si cette distinction a de l'importance.

## **Mapper un format source à une extension**

L'exemple suivant nécessite `sample.pptx`. Il associe chaque valeur [SourceFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/sourceformat/) actuellement prise en charge à une extension conventionnelle, sans analyser le nom de fichier d'entrée. Le secours évite d'attribuer silencieusement une extension à une valeur non reconnue.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

Ce mappage ne convertit pas un fichier et ne récupère pas un sous‑type hérités PPS/POT perdu lors du chargement depuis un flux. Pour la sauvegarde réelle, sélectionnez explicitement un [SaveFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/) ou utilisez la conversion présentée dans [Save Presentations in Their Original Format](/slides/fr/net/save-presentation/#save-presentations-in-their-original-format).

## **Vérifier les formats en enregistrant et en rouvrant**

Cet exemple autonome crée une présentation et écrit trois fichiers dans le répertoire de travail, écrasant les fichiers portant les mêmes noms. Il rouvre chaque sortie à la fois par chemin et via un flux mémoire. Pour PPTX et ODP, les deux voies signalent le format enregistré. Pour PPS, le chargement par chemin signale `Pps`, tandis que le chargement des mêmes octets sans nom de fichier signale `Ppt`.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

| Format enregistré | SourceFormat à partir d'un chemin de fichier | SourceFormat à partir d'un flux sans nom |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectivement | Identique au chemin de fichier |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectivement | Identique au chemin de fichier |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectivement | Identique au chemin de fichier |
| ODP, OTP | `Odp`, `Otp` respectivement | Identique au chemin de fichier |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Dans ces contrôles, la seule normalisation du format source était PPS/POT → `Ppt` pour les flux sans nom. Le tableau décrit l'identification des formats, pas la préservation de chaque fonctionnalité de présentation lors de la conversion.

## **FAQ**

**L'enregistrement au format ODP modifie-t-il le format source d'une présentation chargée depuis PPTX ?**

Non. L'instance existante signale toujours `Pptx`. Une instance chargée depuis le fichier ODP enregistré signale `Odp`.

**Un flux peut-il toujours distinguer une présentation, un diaporama et un modèle hérité ?**

Non. PPT, PPS et POT partagent le même format binaire. Conservez le nom de fichier ou les métadonnées de sous‑type séparément lorsque cette distinction est requise.

**Quelle API devrais‑je utiliser si la présentation est déjà chargée ?**

Lisez [Presentation.SourceFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/sourceformat/). Utilisez [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/presentationfactory/getpresentationinfo/) pour l'inspection avant le chargement.