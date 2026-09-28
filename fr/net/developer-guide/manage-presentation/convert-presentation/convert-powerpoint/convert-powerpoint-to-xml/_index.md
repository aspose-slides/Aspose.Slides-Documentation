---
title: Convertir des présentations PowerPoint en XML avec .NET
linktitle: PowerPoint vers XML
type: docs
weight: 145
url: /fr/net/convert-powerpoint-to-xml/
keywords:
- convertir PowerPoint en XML
- convertir la présentation en XML
- PPT en XML
- PPTX en XML
- ODP en XML
- Présentation PowerPoint XML
- SaveFormat.Xml
- enregistrer la présentation au format XML
- exporter la présentation en XML
- flux XML
- .NET
- C#
- Aspose.Slides
description: "Convertir des présentations PowerPoint et OpenDocument en fichiers ou flux PowerPoint XML en C# avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Aspose.Slides for .NET peut convertir les présentations PowerPoint au format PowerPoint XML Presentation. La sortie XML est utile lorsque vous avez besoin d’une représentation textuelle pour inspecter la structure d’une présentation, dépanner des documents générés, comparer des sorties dans des tests automatisés ou intégrer à un flux de travail qui consomme du XML plutôt qu’un paquet de présentation.

Utilisez la méthode [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) avec la valeur `Xml` de l’énumération [SaveFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/). Vous pouvez écrire le résultat directement dans un fichier ou dans un flux.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` crée une PowerPoint XML Presentation. Il n’extrait pas les parties individuelles Office Open XML stockées dans un paquet PPTX. Si vous avez besoin des parties exactes du paquet PPTX, comme `ppt/presentation.xml` ou des fichiers XML de diapositives individuels, inspectez le paquet PPTX lui‑même.
{{% /alert %}}

## **Convertir une présentation en fichier XML**

Chargez une présentation source avec la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) puis transmettez le chemin de sortie et `SaveFormat.Xml` à [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/). La source peut être n’importe quel format de présentation pris en charge pour le chargement, tel que PPT, PPTX ou ODP.

L’exemple suivant convertit une présentation PPTX en fichier XML :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Écrire la sortie XML dans un flux**

Utilisez la surcharge de flux de [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) lorsque le XML doit rester en mémoire ou être transmis à un autre composant, tel qu’un service web, un fournisseur de stockage ou un pipeline de traitement XML. L’exemple suivant écrit le résultat dans un [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) et le repositionne pour une lecture ultérieure :

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Passer xmlStream au composant suivant dans le flux de travail.
```

## **Comparer XML avec les formats de présentation et d’exportation**

Choisissez le format de sortie en fonction de l’utilisation prévue du résultat :

| Format | Sortie | Utilisation typique |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Une PowerPoint XML Presentation | Inspection de la structure, dépannage, comparaison de sorties générées et intégration basée sur XML |
| PPT (`.ppt`) | Un fichier de présentation binaire hérité | Compatibilité avec les anciens flux de travail PowerPoint |
| PPTX (`.pptx`) | Un paquet Office Open XML contenant plusieurs parties | Édition PowerPoint standard et échange de présentations |
| PDF ou TIFF | Pages à mise en page fixe ou images TIFF | Visualisation, impression et archivage |
| PNG, JPEG ou SVG | Une représentation rendue d’une diapositive individuelle | Vignettes, aperçus et ressources d’image |
| HTML ou HTML5 | Sortie de présentation orientée web | Visualisation dans un navigateur et publication web |

Contrairement aux PPT et PPTX, la sortie XML est principalement destinée à l’inspection et aux flux de travail orientés données. Contrairement aux PDF, TIFF, HTML et aux formats d’image de diapositive, elle représente les données de la présentation plutôt que de rendre les diapositives sous forme de pages ou d’assets visuels. Le tableau des [format de fichiers pris en charge](/slides/fr/net/supported-file-formats/) répertorie chaque format qu’Aspose.Slides peut charger, importer, enregistrer ou rendre.

## **FAQ**

**Le `SaveFormat.Xml` est‑il identique à l’enregistrement d’un fichier PPTX ?**

Non. PPTX est un paquet contenant plusieurs parties Office Open XML, tandis que `SaveFormat.Xml` crée un fichier PowerPoint XML Presentation.

**Puis‑je enregistrer la sortie XML sans créer de fichier sur le disque ?**

Oui. Transmettez un flux accessible en écriture à [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/). Par exemple, utilisez un [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) pour le traitement en mémoire.

**Aspose.Slides peut‑il charger à nouveau le fichier XML exporté ?**

Oui. Transmettez le fichier XML ou un flux au constructeur [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/presentation/). `Presentation.SourceFormat` renvoie alors `SourceFormat.Xml`. `PresentationFactory.GetPresentationInfo` indique `LoadFormat.Unknown` pour ce format, il ne faut donc pas l’utiliser pour décider si un fichier XML peut être ouvert.

**La conversion XML rend‑elle chaque diapositive sous forme de page ou d’image ?**

Non. La conversion XML écrit des données structurées de la présentation. Utilisez PDF ou TIFF pour une sortie orientée pages, ou PNG, JPEG et SVG pour des images de diapositives individuelles.