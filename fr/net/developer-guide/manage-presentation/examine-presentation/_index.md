---
title: Examiner la présentation
type: docs
weight: 30
url: /fr/net/examine-presentation/
keywords:
- PowerPoint
- présentation
- format de présentation
- propriétés de la présentation
- propriétés du document
- obtenir les propriétés
- lire les propriétés
- changer les propriétés
- modifier les propriétés
- PPTX
- PPT
- C#
- Csharp
- .NET
description: "Lire et modifier les propriétés des présentations PowerPoint en C# ou .NET"
---

Aspose.Slides for .NET vous permet d'examiner une présentation pour en connaître les propriétés et comprendre son comportement. 

{{% alert title="Info" color="info" %}} 

Les classes [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) et [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) contiennent les propriétés et les méthodes utilisées dans les opérations présentées ici.

{{% /alert %}} 

## **Vérifier le format d'une présentation**

Avant de travailler sur une présentation, vous pouvez vouloir savoir dans quel format (PPT, PPTX, ODP, etc.) la présentation se trouve actuellement.

Vous pouvez vérifier le format d’une présentation sans la charger. Voir ce code C# :
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```


## **Obtenir les propriétés de la présentation**

Ce code C# vous montre comment obtenir les propriétés de la présentation (informations sur la présentation) :
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ...
```


Vous pouvez également consulter les [properties under the DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties) class.

## **Mettre à jour les propriétés de la présentation**

Aspose.Slides fournit la méthode [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) qui vous permet de modifier les propriétés de la présentation.

Supposons que nous disposions d’une présentation PowerPoint avec les propriétés de document affichées ci‑dessous.

![Original document properties of the PowerPoint presentation](input_properties.png)

Cet exemple de code montre comment modifier certaines propriétés de la présentation :
```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```


Les résultats du changement des propriétés de document sont affichés ci‑dessous.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Liens utiles**

Pour obtenir plus d’informations sur une présentation et ses attributs de sécurité, vous trouverez ces liens utiles :

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Checking whether a Presentation is Password Protected Before Loading it](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Comment vérifier si les polices sont incorporées et lesquelles ?**

Recherchez les informations sur les [embedded-font information](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) au niveau de la présentation, puis comparez ces entrées avec l’ensemble des [fonts actually used across content](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) pour identifier les polices essentielles au rendu.

**Comment savoir rapidement si le fichier contient des diapositives masquées et combien ?**

Parcourez la [slide collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) et inspectez le [visibility flag](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) de chaque diapositive.

**Puis‑je détecter si une taille et une orientation personnalisées de diapositive sont utilisées, et si elles diffèrent des valeurs par défaut ?**

Oui. Comparez la [slide size](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) et l’orientation actuelles avec les préréglages standard ; cela aide à anticiper le comportement lors de l’impression et de l’exportation.

**Existe‑t‑il un moyen rapide de voir si les graphiques font référence à des sources de données externes ?**

Oui. Parcourez tous les [charts](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/), vérifiez leur [data source](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/), et notez si les données sont internes ou liées, y compris les liens cassés.

**Comment évaluer les diapositives « lourdes » qui peuvent ralentir le rendu ou l’exportation PDF ?**

Pour chaque diapositive, comptez les objets et recherchez les images volumineuses, transparences, ombres, animations et multimédias ; attribuez un score de complexité approximatif afin d’identifier les éventuels points critiques de performance.