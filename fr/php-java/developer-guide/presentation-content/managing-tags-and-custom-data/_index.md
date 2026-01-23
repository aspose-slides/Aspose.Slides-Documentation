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

Les fichiers PPTX — les éléments portant l'extension .pptx — sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations. 

Une *diapositive* étant l'un des éléments des présentations, une *partie de diapositive* contient le contenu d'une seule diapositive. Une partie de diapositive est autorisée à avoir des relations explicites avec de nombreuses parties — telles que les balises définies par l'utilisateur — définies par ISO/IEC 29500. 

Les données personnalisées (spécifiques à une présentation) ou l'utilisateur peuvent exister sous forme de balises ([TagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/)) et de CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}} 
Les balises sont essentiellement des paires clé‑valeur de chaînes. 
{{% /alert %}} 

## **Obtenir les valeurs des balises**

Dans les diapositives, une balise correspond aux méthodes [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getKeywords) et [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setKeywords). Ce code d'exemple montre comment obtenir la valeur d'une balise avec Aspose.Slides for PHP via Java pour [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) :
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

Aspose.Slides permet d'ajouter des balises aux présentations. Une balise se compose généralement de deux éléments :

- le nom d'une propriété personnalisée - `MyTag` 
- la valeur de la propriété personnalisée - `My Tag Value`

Si vous devez classer certaines présentations selon une règle ou une propriété spécifique, vous pouvez bénéficier de l'ajout de balises à ces présentations. Par exemple, si vous voulez regrouper toutes les présentations provenant des pays d'Amérique du Nord, vous pouvez créer une balise « North American » puis attribuer les pays concernés (les États‑Unis, le Mexique et le Canada) comme valeurs. 

Ce code d'exemple montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) en utilisant Aspose.Slides for PHP via Java :
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


Les balises peuvent également être définies pour [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) :
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


Ou toute [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) individuelle :
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

**Puis-je supprimer toutes les balises d'une présentation, d'une diapositive ou d'une forme en une seule opération ?**

Oui. La [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) prend en charge une opération [clear](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/clear/) qui supprime toutes les paires clé‑valeur d'un coup.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez l'opération [remove(name)](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/remove/) sur la [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) pour supprimer la balise par sa clé.

**Comment récupérer la liste complète des noms de balises pour l'analyse ou le filtrage ?**

Utilisez [getNamesOfTags](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/getnamesoftags/) sur la [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) ; elle renvoie un tableau contenant tous les noms de balises.