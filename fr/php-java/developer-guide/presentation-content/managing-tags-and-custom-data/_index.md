---
title: Gestion des balises et des données personnalisées dans les présentations avec PHP
linktitle: Balises et données personnalisées
type: docs
weight: 300
url: /fr/php-java/managing-tags-and-custom-data/
keywords:
- propriétés du document
- balise
- données personnalisées
- ajouter une balise
- paires de valeurs
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez comment ajouter, lire, mettre à jour et supprimer les balises et les données personnalisées dans Aspose.Slides pour PHP via Java, avec des exemples pour les présentations PowerPoint et OpenDocument."
---

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX—éléments avec l'extension .pptx—sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations. 

Avec une *diapositive* étant l’un des éléments des présentations, une *partie de diapositive* contient le contenu d’une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec de nombreuses parties—comme les balises définies par l'utilisateur—définies par la norme ISO/IEC 29500. 

Les données personnalisées (spécifiques à une présentation) ou l'utilisateur peuvent exister sous forme de balises ([ITagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ITagCollection)) et de CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

Les balises sont essentiellement des paires clé‑valeur de chaînes. 

{{% /alert %}} 

## **Obtenir les valeurs des balises**

Dans les diapositives, une balise correspond aux méthodes [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#getKeywords--) et [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . Ce code d'exemple vous montre comment récupérer la valeur d'une balise avec Aspose.Slides pour PHP via Java pour la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) :
```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ajouter des balises aux présentations**

Aspose.Slides vous permet d'ajouter des balises aux présentations. Une balise se compose généralement de deux éléments :

- le nom d'une propriété personnalisée - `MyTag` 
- la valeur de la propriété personnalisée - `My Tag Value`

Si vous devez classer certaines présentations selon une règle ou une propriété spécifique, vous pouvez tirer parti de l'ajout de balises à ces présentations. Par exemple, si vous souhaitez catégoriser ou regrouper toutes les présentations provenant des pays d'Amérique du Nord, vous pouvez créer une balise « Amérique du Nord » puis attribuer les pays concernés (États‑Unis, Mexique et Canada) comme valeurs. 

Ce code d'exemple vous montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) en utilisant Aspose.Slides pour PHP via Java :
```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Les balises peuvent également être définies pour [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) :
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Ou tout [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) :
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Puis-je supprimer toutes les balises d’une présentation, d’une diapositive ou d’une forme en une seule opération ?**

Oui. La [collection de balises](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) prend en charge une opération [clear](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/clear/) qui supprime toutes les paires clé‑valeur d’un coup.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez l’opération [Remove(name)](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/remove/) sur la [collection de balises](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) pour supprimer la balise par sa clé.

**Comment récupérer la liste complète des noms de balises pour l’analyse ou le filtrage ?**

Utilisez [getNamesOfTags](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/getnamesoftags/) sur la [collection de balises](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/); elle renvoie un tableau contenant tous les noms de balises.