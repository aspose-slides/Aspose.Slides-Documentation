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
- obtenir des propriétés
- lire des propriétés
- changer des propriétés
- modifier des propriétés
- mettre à jour les propriétés
- examiner PPTX
- examiner PPT
- examiner ODP
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour PHP pour obtenir des analyses plus rapides et des audits de contenu plus intelligents."
---
## **Vue d'ensemble**

Cet article montre comment inspecter les informations d’une présentation dans Aspose.Slides. Il explique comment déterminer le format actuel d’une présentation sans charger le fichier complet, lire ses propriétés de document et mettre à jour ces propriétés si nécessaire.

Les exemples sont basés sur les API [PresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/) et [DocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/) et illustrent les opérations courantes de manipulation des métadonnées de présentation.

## **Vérifier le format d’une présentation**

Avant de travailler sur une présentation, vous pouvez vouloir savoir sous quel format (PPT, PPTX, ODP, etc.) elle se trouve actuellement.

Vous pouvez vérifier le format d’une présentation sans la charger. Voir ce code PHP :

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Obtenir les propriétés de la présentation**

Ce code PHP montre comment obtenir les propriétés de la présentation (informations sur la présentation) :

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

Vous pouvez consulter les [propriétés dans la classe DocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Mettre à jour les propriétés de la présentation**

Aspose.Slides fournit la méthode [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) qui permet de modifier les propriétés de la présentation.

Supposons que nous ayons une présentation PowerPoint avec les propriétés de document ci‑dessous.

![Propriétés de document originales de la présentation PowerPoint](input_properties.png)

Cet exemple de code montre comment modifier certaines propriétés de la présentation :

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Le résultat du changement des propriétés de document est illustré ci‑dessous.

![Propriétés de document modifiées de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour obtenir plus d’informations sur une présentation et ses attributs de sécurité, ces liens peuvent vous être utiles :

- [Protection par mot de passe des présentations](/slides/fr/php-java/password-protected-presentation/)
- [Protection en écriture des présentations](/slides/fr/php-java/write-protected-presentation/)

## **FAQ**

**Comment vérifier si les polices sont incorporées et lesquelles ?**

Recherchez les informations sur les [polices intégrées](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/getembeddedfonts/) au niveau de la présentation, puis comparez ces entrées avec l’ensemble des [polices réellement utilisées dans le contenu](https://reference.aspose.com/slides/fr/php-java/aspose.slides/fontsmanager/getfonts/) pour identifier les polices critiques pour le rendu.

**Comment savoir rapidement si le fichier contient des diapositives masquées et combien ?**

Parcourez la [collection de diapositives](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/) et inspectez le [drapeau de visibilité](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/gethidden/) de chaque diapositive.

**Puis‑je détecter si une taille et une orientation personnalisées de diapositive sont utilisées, et si elles diffèrent des valeurs par défaut ?**

Oui. Comparez la [taille de diapositive](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/getslidesize/) et l’orientation actuelles avec les préréglages standard ; cela aide à anticiper le comportement lors de l’impression et de l’exportation.

**Existe‑t‑il un moyen rapide de voir si les graphiques référencent des sources de données externes ?**

Oui. Parcourez tous les [graphiques](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chart/), vérifiez leur [source de données](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdata/getdatasourcetype/), et notez si les données sont internes ou basées sur un lien, y compris les liens cassés.

**Comment évaluer les diapositives « lourdes » qui peuvent ralentir le rendu ou l’exportation PDF ?**

Pour chaque diapositive, comptez le nombre d’objets et recherchez les images volumineuses, la transparence, les ombres, les animations et les contenus multimédias ; attribuez un score de complexité approximatif afin d’identifier les points chauds potentiels de performance.