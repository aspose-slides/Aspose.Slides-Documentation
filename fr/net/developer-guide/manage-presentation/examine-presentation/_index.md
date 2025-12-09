---
title: Récupérer et mettre à jour les informations de présentation dans .NET
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
- changer les propriétés
- modifier les propriétés
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
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument à l'aide de .NET pour des analyses plus rapides et des audits de contenu plus intelligents."
---

Aspose.Slides for .NET vous permet d'examiner une présentation pour connaître ses propriétés et comprendre son comportement. 

{{% alert title="Info" color="info" %}} 
Les classes [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) et [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) contiennent les propriétés et méthodes utilisées dans les opérations présentées ici.
{{% /alert %}} 

## **Vérifier le format d'une présentation**

Avant de travailler sur une présentation, vous pouvez vouloir savoir dans quel format (PPT, PPTX, ODP, etc.) la présentation se trouve actuellement.

Vous pouvez vérifier le format d'une présentation sans la charger. Voir ce code C#:
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```


## **Obtenir les propriétés d'une présentation**

Ce code C# vous montre comment obtenir les propriétés d'une présentation (informations sur la présentation) :
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```


Vous pouvez consulter les [propriétés de la classe DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties).

## **Mettre à jour les propriétés d'une présentation**

Aspose.Slides fournit la méthode [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) qui vous permet de modifier les propriétés d'une présentation.

Supposons que nous ayons une présentation PowerPoint avec les propriétés du document affichées ci-dessous.

![Propriétés originales du document de la présentation PowerPoint](input_properties.png)

Cet exemple de code vous montre comment modifier certaines propriétés de la présentation :
```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```


Les résultats de la modification des propriétés du document sont affichés ci-dessous.

![Propriétés modifiées du document de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour obtenir davantage d'informations sur une présentation et ses attributs de sécurité, vous pourriez trouver ces liens utiles :

- [Vérifier si une présentation est chiffrée](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Vérifier si une présentation est protégée en écriture (lecture seule)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Vérifier si une présentation est protégée par mot de passe avant de la charger](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmer le mot de passe utilisé pour protéger une présentation](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Comment puis-je vérifier si les polices sont incorporées et lesquelles le sont ?**

Recherchez les [informations sur les polices incorporées](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) au niveau de la présentation, puis comparez ces entrées avec l'ensemble des [polices réellement utilisées dans le contenu](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) afin d'identifier les polices essentielles pour le rendu.

**Comment puis-je rapidement savoir si le fichier contient des diapositives masquées et combien ?**

Parcourez la [collection de diapositives](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) et inspectez le [drapeau de visibilité](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) de chaque diapositive.

**Puis-je détecter si une taille et orientation de diapositive personnalisées sont utilisées et si elles diffèrent des paramètres par défaut ?**

Oui. Comparez la [taille de diapositive](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) et l'orientation actuelles avec les préréglages standards ; cela aide à anticiper le comportement lors de l'impression et de l'exportation.

**Existe-t-il un moyen rapide de voir si les graphiques font référence à des sources de données externes ?**

Oui. Parcourez tous les [graphiques](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), vérifiez leur [source de données](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/), et notez si les données sont internes ou basées sur un lien, y compris les liens cassés.

**Comment puis-je évaluer les diapositives « lourdes » qui peuvent ralentir le rendu ou l'exportation PDF ?**

Pour chaque diapositive, comptez le nombre d'objets et recherchez les images volumineuses, la transparence, les ombres, les animations et les multimédias ; attribuez un score de complexité approximatif afin de signaler les points chauds potentiels de performance.