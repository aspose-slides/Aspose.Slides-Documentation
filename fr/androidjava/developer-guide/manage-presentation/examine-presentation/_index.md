---
title: Examiner la Présentation
type: docs
weight: 30
url: /androidjava/examine-presentation/
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
- Android
- Java
description: "Lire et modifier les propriétés de présentation PowerPoint sur Android via Java"
---

Aspose.Slides pour Android via Java vous permet d'examiner une présentation pour découvrir ses propriétés et comprendre son comportement.

{{% alert title="Info" color="info" %}} 

Les classes [PresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo) et [DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/) contiennent les propriétés et méthodes utilisées dans les opérations ici.

{{% /alert %}} 

## **Vérifier un Format de Présentation**

Avant de travailler sur une présentation, vous voudrez peut-être savoir dans quel format (PPT, PPTX, ODP, et autres) se trouve actuellement la présentation.

Vous pouvez vérifier le format d'une présentation sans la charger. Voir ce code Java :

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Obtenir les Propriétés de Présentation**

Ce code Java vous montre comment obtenir les propriétés de présentation (informations sur la présentation) :

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

Vous voudrez peut-être voir les [propriétés sous la classe DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--).

## **Mettre à Jour les Propriétés de Présentation**

Aspose.Slides fournit la méthode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) qui vous permet de modifier les propriétés de présentation.

Disons que nous avons une présentation PowerPoint avec les propriétés de document indiquées ci-dessous.

![Propriétés de document originales de la présentation PowerPoint](input_properties.png)

Cet exemple de code vous montre comment éditer certaines propriétés de présentation :

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("Mon titre");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Les résultats de la modification des propriétés de document sont indiqués ci-dessous.

![Propriétés de document modifiées de la présentation PowerPoint](output_properties.png)

## **Liens Utiles**

Pour obtenir plus d'informations sur une présentation et ses attributs de sécurité, vous pourriez trouver ces liens utiles :

- [Vérifier si une Présentation est Chiffrée](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Vérifier si une Présentation est Protégée en Écriture (lecture seule)](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Vérifier si une Présentation est Protégée par Mot de Passe Avant de la Charger](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmer le Mot de Passe Utilisé pour Protéger une Présentation](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).