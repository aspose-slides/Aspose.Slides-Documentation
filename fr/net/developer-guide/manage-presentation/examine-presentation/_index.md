---
title: Examiner la Présentation
type: docs
weight: 30
url: /fr/net/examine-presentation/
keywords:
- PowerPoint
- présentation
- format de présentation
- propriétés de présentation
- propriétés de document
- obtenir des propriétés
- lire des propriétés
- changer des propriétés
- modifier des propriétés
- PPTX
- PPT
- C#
- Csharp
- .NET
description: "Lire et modifier les propriétés d'une présentation PowerPoint en C# ou .NET"
---

Aspose.Slides pour .NET vous permet d'examiner une présentation pour découvrir ses propriétés et comprendre son comportement.

{{% alert title="Info" color="info" %}} 

Les classes [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) et [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) contiennent les propriétés et méthodes utilisées dans les opérations ici.

{{% /alert %}} 

## **Vérifier un Format de Présentation**

Avant de travailler sur une présentation, vous voudrez peut-être savoir dans quel format (PPT, PPTX, ODP, et autres) se trouve la présentation à ce moment-là.

Vous pouvez vérifier le format d'une présentation sans la charger. Voici ce code C# :

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Obtenir les Propriétés de Présentation**

Ce code C# vous montre comment obtenir les propriétés de la présentation (informations sur la présentation) :

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

Vous voudrez peut-être voir les [propriétés de la classe DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties).

## **Mettre à Jour les Propriétés de Présentation**

Aspose.Slides fournit la méthode [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) qui vous permet de modifier les propriétés de la présentation.

Disons que nous avons une présentation PowerPoint avec les propriétés du document montrées ci-dessous.

![Propriétés de document originales de la présentation PowerPoint](input_properties.png)

Cet exemple de code vous montre comment éditer certaines propriétés de présentation :

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "Mon titre";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Les résultats du changement des propriétés du document sont montrés ci-dessous.

![Propriétés de document modifiées de la présentation PowerPoint](output_properties.png)

## **Liens Utiles**

Pour obtenir plus d'informations sur une présentation et ses attributs de sécurité, vous pouvez trouver ces liens utiles :

- [Vérifier si une Présentation est Chiffrée](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Vérifier si une Présentation est Protégée en Écriture (lecture seule)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Vérifier si une Présentation est Protégée par un Mot de Passe Avant de la Charger](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmer le Mot de Passe Utilisé pour Protéger une Présentation](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).