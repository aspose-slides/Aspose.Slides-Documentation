---
title: "Comprendre la différence : PPT vs PPTX"
linktitle: PPT vs PPTX
type: docs
weight: 10
url: /fr/php-java/ppt-vs-pptx/
keywords:
- PPT vs PPTX
- PPT ou PPTX
- format hérité
- format moderne
- format binaire
- standard moderne
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Comparer PPT vs PPTX pour PowerPoint avec Aspose.Slides pour PHP via Java, en explorant les différences de format, les avantages, la compatibilité et les conseils de conversion."
---

## **Qu'est-ce que PPT ?**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) est un format de fichier binaire, c.-à-d. il est impossible de voir son contenu sans outils spéciaux. Les premières versions de PowerPoint 97-2003 utilisaient le format de fichier PPT, cependant son extensibilité est limitée.

## **Qu'est-ce que PPTX ?**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) est un nouveau format de présentation, basé sur la norme Office Open XML (ISO 29500:2008-2016, ECMA-376). PPTX est un ensemble archivé de fichiers XML et multimédias. Le format PPTX est facilement extensible. Par exemple, il est facile d'ajouter la prise en charge d'un nouveau type de graphique ou de forme, sans modifier le format PPTX dans chaque nouvelle version de PowerPoint. Le format PPTX est utilisé depuis PowerPoint 2007.

## **PPT vs PPTX**
Bien que le PPTX offre une fonctionnalité beaucoup plus étendue, le PPT reste assez populaire. La nécessité de convertir de PPT à PPTX et vice-versa est fortement demandée.

Cependant, la conversion entre l'ancien format PPT et le nouveau format PPTX représente le défi le plus compliqué parmi les autres formats Microsoft Office. Bien que la spécification du format PPT soit ouverte, il est difficile de travailler avec. PowerPoint peut créer des parties spéciales (MetroBlob) dans les fichiers PPT pour stocker des informations provenant du PPTX qui ne sont pas prises en charge par le format PPT et ne peuvent pas être affichées dans les anciennes versions de PowerPoint. Ces informations peuvent être restaurées lorsqu'un fichier PPT est chargé dans une version moderne de PowerPoint ou converti au format PPTX.

Aspose.Slides fournit une interface commune pour travailler avec tous les formats de présentation. Elle permet de convertir de PPT à PPTX et de PPTX à PPT de manière très simple. Aspose.Slides prend en charge entièrement la conversion de PPT à PPTX et prend également en charge la conversion de PPTX à PPT avec certaines restrictions. Nous recommandons d’utiliser le format PPTX chaque fois que possible.

{{% alert color="primary" %}} 
Vérifiez la qualité des conversions de PPT vers PPTX et de PPTX vers PPT avec l'application en ligne [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 
```php
  # Instancier un objet Presentation qui représente un fichier PPT
  $pres = new Presentation("PPTtoPPTX.ppt");
  try {
    # Enregistrement de la présentation PPT au format PPTX
    $pres->save("PPTtoPPTX_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
En savoir plus [**Comment convertir les présentations PPT en PPTX**](/slides/fr/php-java/convert-ppt-to-pptx/)
{{% /alert %}} 

## **FAQ**

**Y a-t-il un intérêt à conserver les anciennes présentations au format PPT si elles s'ouvrent sans erreur ?**

Si une présentation s'ouvre de manière fiable et n'a pas besoin de collaboration ou de nouvelles fonctionnalités, vous pouvez la conserver au format PPT. Mais pour la compatibilité et l'extensibilité futures, il vaut mieux [convertir en PPTX](/slides/fr/php-java/convert-ppt-to-pptx/) : le format repose sur la norme OOXML ouverte et est plus facilement pris en charge par les outils modernes.

**Comment puis‑je décider quels fichiers sont critiques à convertir en PPTX en premier ?**

Convertissez d'abord les présentations qui : sont éditées par plusieurs personnes ; contiennent des [graphiques](/slides/fr/php-java/create-chart/)/[formes](/slides/fr/php-java/shape-manipulations/); sont utilisées dans des communications externes ; ou déclenchent des avertissements lors de leur [ouverture](/slides/fr/php-java/open-presentation/).

**La protection par mot de passe sera‑t‑elle conservée lors de la conversion de PPT à PPTX et vice-versa ?**

La présence d'un mot de passe n'est conservée qu'avec une conversion correcte et le support du chiffrement dans l'outil utilisé. Il est plus fiable de [supprimer la protection](/slides/fr/php-java/password-protected-presentation/), [convertir](/slides/fr/php-java/convert-ppt-to-pptx/), puis de réappliquer la protection selon votre politique de sécurité.

**Pourquoi certains effets disparaissent‑ils ou sont‑ils simplifiés lors de la conversion de PPTX en PPT ?**

Parce que le PPT ne prend pas en charge certains objets/propriétés plus récents. PowerPoint et les outils peuvent stocker des « traces » de ces informations dans des blocs spéciaux pour une restauration ultérieure, mais les anciennes versions de PowerPoint ne les rendront pas.