---
title: Récupérer et mettre à jour les informations de présentation en .NET
linktitle: Informations de présentation
type: docs
weight: 30
url: /fr/net/examine-presentation/
keywords:
- format de présentation
- propriétés de présentation
- propriétés du document
- obtenir les propriétés
- lire les propriétés
- modifier les propriétés
- ajuster les propriétés
- mettre à jour les propriétés
- examiner PPTX
- examiner PPT
- examiner ODP
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument en .NET pour obtenir des informations plus rapides et des audits de contenu plus intelligents."
---
## **Vue d'ensemble**

Cet article montre comment inspecter les informations d’une présentation dans Aspose.Slides. Il explique comment déterminer le format actuel d’une présentation sans charger le fichier complet, lire ses propriétés de document et mettre à jour ces propriétés si nécessaire.

Les exemples sont basés sur les API [PresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/presentationinfo/) et [DocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/documentproperties/) et illustrent les opérations typiques de gestion des métadonnées d’une présentation.

## **Vérifier le format d’une présentation**

Avant de travailler sur une présentation, vous pouvez vouloir connaître le format (PPT, PPTX, ODP, etc.) de la présentation à l’instant présent.

Vous pouvez vérifier le format d’une présentation sans la charger. Voir ce code C# :

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Obtenir les propriétés de la présentation**

Ce code C# montre comment obtenir les propriétés de la présentation (informations sur la présentation) :

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

Vous pouvez également consulter les [propriétés de la classe DocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/documentproperties/#properties).

## **Mettre à jour les propriétés de la présentation**

Aspose.Slides propose la méthode [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) qui permet de modifier les propriétés d’une présentation.

Supposons que nous ayons une présentation PowerPoint avec les propriétés de document ci‑dessous.

![Propriétés de document d’origine de la présentation PowerPoint](input_properties.png)

Cet exemple de code montre comment modifier certaines propriétés de la présentation :

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Les résultats de la modification des propriétés de document sont affichés ci‑dessous.

![Propriétés de document modifiées de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour obtenir plus d’informations sur une présentation et ses attributs de sécurité, vous pouvez consulter les liens suivants :

- [Présentations protégées par mot de passe](/slides/fr/net/password-protected-presentation/)
- [Présentations protégées en écriture](/slides/fr/net/write-protected-presentation/)

## **FAQ**

**Comment vérifier si les polices sont incorporées et quelles sont‑elles ?**

Recherchez les informations sur les [polices incorporées](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsmanager/getembeddedfonts/) au niveau de la présentation, puis comparez ces entrées avec l’ensemble des [polices réellement utilisées dans le contenu](https://reference.aspose.com/slides/fr/net/aspose.slides/fontsmanager/getfonts/) pour identifier les polices critiques pour le rendu.

**Comment déterminer rapidement si le fichier contient des diapositives masquées et combien ?**

Parcourez la [collection de diapositives](https://reference.aspose.com/slides/fr/net/aspose.slides/slidecollection/) et examinez le [drapeau de visibilité](https://reference.aspose.com/slides/fr/net/aspose.slides/slide/hidden/) de chaque diapositive.

**Puis‑je détecter si une taille ou une orientation de diapositive personnalisée est utilisée, et si elle diffère des valeurs par défaut ?**

Oui. Comparez la [taille de diapositive](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/slidesize/) et l’orientation actuelles avec les préréglages standard ; cela aide à anticiper le comportement lors de l’impression ou de l’exportation.

**Existe‑t‑il un moyen rapide de voir si des graphiques font référence à des sources de données externes ?**

Oui. Parcourez tous les [graphiques](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chart/), vérifiez leur [source de données](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chartdata/datasourcetype/) et notez si les données sont internes ou basées sur un lien, y compris les liens rompus.

**Comment évaluer les diapositives « lourdes » qui pourraient ralentir le rendu ou l’exportation PDF ?**

Pour chaque diapositive, comptez les objets et recherchez les images volumineuses, la transparence, les ombres, les animations et les médias ; attribuez un score de complexité approximatif afin d’identifier les points chauds de performance potentiels.