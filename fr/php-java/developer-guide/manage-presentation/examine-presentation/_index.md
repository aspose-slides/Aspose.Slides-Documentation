---
title: Examiner la Présentation
type: docs
weight: 30
url: /fr/php-java/examine-presentation/
keywords:
- PowerPoint
- présentation
- format de présentation
- propriétés de présentation
- propriétés du document
- obtenir des propriétés
- lire des propriétés
- changer des propriétés
- modifier des propriétés
- PPTX
- PPT
- PHP
- Java
description: "Lire et modifier les propriétés des présentations PowerPoint en PHP via Java"
---

Aspose.Slides pour PHP via Java vous permet d'examiner une présentation pour découvrir ses propriétés et comprendre son comportement.

{{% alert title="Info" color="info" %}} 

Les classes [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) et [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) contiennent les propriétés et méthodes utilisées dans les opérations ici.

{{% /alert %}} 

## **Vérifier un Format de Présentation**

Avant de travailler sur une présentation, vous voudrez peut-être savoir dans quel format (PPT, PPTX, ODP, et autres) la présentation se trouve actuellement.

Vous pouvez vérifier le format d'une présentation sans charger la présentation. Voir ce code PHP :

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP
```

## **Obtenir les Propriétés de la Présentation**

Ce code PHP vous montre comment obtenir les propriétés de la présentation (informations sur la présentation) :

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

Vous voudrez peut-être voir les [propriétés sous la classe DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--).

## **Mettre à Jour les Propriétés de la Présentation**

Aspose.Slides fournit la méthode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) qui vous permet d'apporter des modifications aux propriétés de la présentation.

Disons que nous avons une présentation PowerPoint avec les propriétés du document indiquées ci-dessous.

![Propriétés originales du document de la présentation PowerPoint](input_properties.png)

Cet exemple de code vous montre comment éditer certaines propriétés de présentation :

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("Mon titre");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Les résultats de la modification des propriétés du document sont montrés ci-dessous.

![Propriétés modifiées du document de la présentation PowerPoint](output_properties.png)

## **Liens Utiles**

Pour obtenir plus d'informations sur une présentation et ses attributs de sécurité, vous trouverez ces liens utiles :

- [Vérifier si une Présentation est Chiffrée](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Vérifier si une Présentation est Protégée en Écriture (lecture seule)](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Vérifier si une Présentation est Protégée par un Mot de Passe Avant de la Charger](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmer le Mot de Passe Utilisé pour Protéger une Présentation](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).