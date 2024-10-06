---
title: Examiner la présentation
type: docs
weight: 30
url: /java/examine-presentation/
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
- Java
description: "Lire et modifier les propriétés des présentations PowerPoint en Java"
---

Aspose.Slides pour Java vous permet d'examiner une présentation pour découvrir ses propriétés et comprendre son comportement. 

{{% alert title="Info" color="info" %}} 

Les classes [PresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/PresentationInfo) et [DocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/) contiennent les propriétés et méthodes utilisées dans les opérations ici.

{{% /alert %}} 

## **Vérifier un format de présentation**

Avant de travailler sur une présentation, vous pouvez vouloir savoir dans quel format (PPT, PPTX, ODP, et autres) se trouve actuellement la présentation.

Vous pouvez vérifier le format d'une présentation sans charger la présentation. Voir ce code Java :

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Obtenir les propriétés de la présentation**

Ce code Java vous montre comment obtenir des propriétés de présentation (informations sur la présentation) :

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

Vous pouvez vouloir voir les [propriétés sous la classe DocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Mettre à jour les propriétés de la présentation**

Aspose.Slides fournit la méthode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) qui vous permet de modifier les propriétés de présentation.

Disons que nous avons une présentation PowerPoint avec les propriétés de document montrées ci-dessous.

![Propriétés originales du document de la présentation PowerPoint](input_properties.png)

Cet exemple de code vous montre comment modifier certaines propriétés de présentation :

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("Mon titre");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Les résultats de la modification des propriétés du document sont montrés ci-dessous.

![Propriétés modifiées du document de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour obtenir plus d'informations sur une présentation et ses attributs de sécurité, vous pouvez trouver ces liens utiles :

- [Vérifier si une présentation est chiffrée](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Vérifier si une présentation est protégée en écriture (lecture seule)](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Vérifier si une présentation est protégée par mot de passe avant de la charger](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmer le mot de passe utilisé pour protéger une présentation](https://docs.aspose.com/slides/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).