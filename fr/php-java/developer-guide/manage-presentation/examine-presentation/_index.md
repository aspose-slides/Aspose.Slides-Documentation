---
title: Récupérer et mettre à jour les informations de présentation en PHP
linktitle: Informations de présentation
type: docs
weight: 30
url: /fr/php-java/examine-presentation/
keywords:
- format de présentation
- propriétés de présentation
- propriétés du document
- obtenir les propriétés
- lire les propriétés
- modifier les propriétés
- altérer les propriétés
- mettre à jour les propriétés
- examiner PPTX
- examiner PPT
- examiner ODP
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour PHP afin d'obtenir des informations plus rapides et des audits de contenu plus intelligents."
---

Aspose.Slides for PHP via Java vous permet d’examiner une présentation pour découvrir ses propriétés et comprendre son comportement.

{{% alert title="Info" color="info" %}} 

Les classes [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) et [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) contiennent les propriétés et les méthodes utilisées dans les opérations présentées ici.

{{% /alert %}} 

## **Vérifier le format d’une présentation**

Avant de travailler sur une présentation, vous pouvez souhaiter savoir quel est le format (PPT, PPTX, ODP, etc.) de la présentation à ce moment‑là.

Vous pouvez vérifier le format d’une présentation sans la charger. Voir ce code PHP :
```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP
```


## **Obtenir les propriétés d’une présentation**

Ce code PHP montre comment obtenir les propriétés d’une présentation (informations sur la présentation) :
```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```


Vous pourrez peut‑être consulter les [propriétés de la classe DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Mettre à jour les propriétés d’une présentation**

Aspose.Slides fournit la méthode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) qui vous permet de modifier les propriétés d’une présentation.

Supposons que nous ayons une présentation PowerPoint avec les propriétés de document montrées ci‑dessous.

![Propriétés d’origine du document de la présentation PowerPoint](input_properties.png)

Cet exemple de code montre comment modifier certaines propriétés de présentation :
```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```


Les résultats du changement des propriétés de document sont présentés ci‑dessous.

![Propriétés modifiées du document de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour obtenir davantage d’informations sur une présentation et ses attributs de sécurité, vous trouverez peut‑être ces liens utiles :

- [Vérifier si une présentation est chiffrée](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Vérifier si une présentation est protégée en écriture (lecture seule)](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Vérifier si une présentation est protégée par mot de passe avant de la charger](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmer le mot de passe utilisé pour protéger une présentation](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Comment puis‑je vérifier si les polices sont incorporées et lesquelles ?**

Recherchez les informations sur les [polices incorporées](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getembeddedfonts/) au niveau de la présentation, puis comparez ces entrées avec l’ensemble des [polices réellement utilisées dans le contenu](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getfonts/) pour identifier les polices essentielles au rendu.

**Comment puis‑je rapidement savoir si le fichier contient des diapositives masquées et combien ?**

Parcourez la [collection de diapositives](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) et inspectez le [drapeau de visibilité](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) de chaque diapositive.

**Puis‑je détecter si une taille et orientation de diapositive personnalisées sont utilisées, et si elles diffèrent des valeurs par défaut ?**

Oui. Comparez la [taille de diapositive actuelle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslidesize/) et son orientation avec les paramètres standards ; cela aide à anticiper le comportement lors de l’impression ou de l’export.

**Existe‑t‑il un moyen rapide de voir si les graphiques font référence à des sources de données externes ?**

Oui. Parcourez tous les [graphiques](https://reference.aspose.com/slides/php-java/aspose.slides/chart/), vérifiez leur [source de données](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), et notez si les données sont internes ou liées, y compris les liens cassés.

**Comment évaluer les diapositives « lourdes » qui peuvent ralentir le rendu ou l’export PDF ?**

Pour chaque diapositive, comptez les objets, repérez les images volumineuses, les transparences, les ombres, les animations et les contenus multimédias ; attribuez un score de complexité approximatif afin d’identifier les points critiques de performance.