---
title: Convertir des présentations PowerPoint en XML en .NET
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
description: "Convertissez les présentations PowerPoint et OpenDocument en fichiers ou flux PowerPoint XML en C# avec Aspose.Slides pour .NET."
---
## **Aperçu**

Aspose.Slides for .NET peut convertir des présentations PowerPoint au format PowerPoint XML Presentation. La sortie XML est utile lorsqu’il faut une représentation textuelle pour inspecter la structure d’une présentation, dépanner des documents générés, comparer les résultats dans des tests automatisés ou s’intégrer à un flux de travail qui consomme du XML plutôt qu’un paquet de présentation.

Utilisez la méthode [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) avec la valeur `Xml` de l’énumération [SaveFormat](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveformat/). Vous pouvez écrire le résultat directement dans un fichier ou dans un flux.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` crée une PowerPoint XML Presentation. Elle n’extrait pas les parties individuelles Office Open XML contenues dans un paquet PPTX. Si vous avez besoin des parties exactes du paquet PPTX, telles que `ppt/presentation.xml` ou les fichiers XML de diapositives individuels, examinez le paquet PPTX lui‑même.

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

Utilisez la surcharge flux de [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) lorsque le XML doit rester en mémoire ou être transmis à un autre composant, comme un service Web, un fournisseur de stockage ou une chaîne de traitement XML. L’exemple suivant écrit le résultat dans un [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) et le repositionne pour une lecture ultérieure :

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Transmettre xmlStream au composant suivant du flux de travail.
```

## **Comparer le XML avec les formats de présentation et d’exportation**

Choisissez le format de sortie en fonction de l’usage prévu :

| Format | Sortie | Utilisation typique |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Une PowerPoint XML Presentation | Inspection de la structure, dépannage, comparaison de la sortie générée et intégration basée sur XML |
| PPT (`.ppt`) | Un fichier de présentation binaire hérité | Compatibilité avec les anciens flux de travail PowerPoint |
| PPTX (`.pptx`) | Un paquet Office Open XML contenant plusieurs parties | Édition PowerPoint standard et échange de présentations |
| PDF ou TIFF | Pages à mise en page fixe ou image multipage | Visualisation, impression et archivage |
| PNG, JPEG ou SVG | Représentation rendue d’une diapositive individuelle | Vignettes, aperçus et ressources d’image |
| HTML ou HTML5 | Sortie de présentation orientée Web | Visualisation dans le navigateur et publication web |

Contrairement à PPT et PPTX, la sortie XML est principalement destinée à l’inspection et aux flux de travail orientés données. Contrairement à PDF, TIFF, HTML et aux formats d’image de diapositives, elle représente les données de la présentation plutôt que de rendre les diapositives sous forme de pages ou d’actifs visuels. Le tableau des [formats de fichiers pris en charge](/slides/fr/net/supported-file-formats/) indique que PowerPoint XML Presentation est un format « save‑only », il ne faut donc pas l’utiliser lorsqu’un flux de travail doit recharger le fichier exporté dans Aspose.Slides pour une édition ultérieure.

## **FAQ**

**`SaveFormat.Xml` est‑il identique à l’enregistrement d’un fichier PPTX ?**

Non. PPTX est un paquet contenant plusieurs parties Office Open XML, tandis que `SaveFormat.Xml` crée un fichier PowerPoint XML Presentation.

**Puis‑je enregistrer la sortie XML sans créer de fichier sur le disque ?**

Oui. Transmettez un flux writable à [Presentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/). Par exemple, utilisez un [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) pour le traitement en mémoire.

**Aspose.Slides peut‑il charger à nouveau le fichier XML exporté ?**

Non. PowerPoint XML Presentation est actuellement pris en charge uniquement pour l’enregistrement, pas pour le chargement. Utilisez PPTX ou un autre format de présentation pris en charge lorsque vous avez besoin d’un aller‑retour d’édition.

**La conversion XML rend‑elle chaque diapositive sous forme de page ou d’image ?**

Non. La conversion XML écrit des données structurées de la présentation. Utilisez PDF ou TIFF pour une sortie orientée pages, ou PNG, JPEG et SVG pour des images de diapositives individuelles.