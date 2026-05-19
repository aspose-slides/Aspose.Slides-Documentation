---
title: Gérer les balises et les données personnalisées dans les présentations avec PHP
linktitle: Balises et données personnalisées
type: docs
weight: 300
url: /fr/php-java/managing-tags-and-custom-data/
keywords:
- propriétés du document
- balise
- données personnalisées
- ajouter une balise
- valeurs de paires
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez comment ajouter, lire, mettre à jour et supprimer les balises et les données personnalisées dans Aspose.Slides pour PHP via Java, avec des exemples pour les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Cet article explique comment Aspose.Slides fonctionne avec les balises et les données personnalisées dans les présentations PowerPoint. Il décrit brièvement comment les données sont stockées dans les fichiers PPTX, indique que des données spécifiques à la présentation peuvent exister sous forme de balises et de parties XML personnalisées, et décrit les balises comme des paires clé-valeur de chaînes.

Il montre également comment lire les valeurs des balises et comment ajouter des balises à une présentation, à une diapositive individuelle ou à une forme. De plus, l'article couvre les tâches courantes de gestion des balises telles que la suppression de toutes les balises, la suppression d'une balise par son nom et la récupération de la liste des noms de balises.

## **Stockage des données dans les fichiers de présentation**

Les fichiers PPTX — éléments avec l'extension .pptx — sont stockés au format PresentationML, qui fait partie de la spécification Office Open XML. Le format Office Open XML définit la structure des données contenues dans les présentations.

Une *diapositive* étant l'un des éléments des présentations, une *partie de diapositive* contient le contenu d'une seule diapositive. Une partie de diapositive peut avoir des relations explicites avec de nombreuses parties — comme les User Defined Tags — définies par la norme ISO/IEC 29500.

Les données personnalisées (spécifiques à une présentation) ou l'utilisateur peuvent exister sous forme de balises ([TagCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tagcollection/)) et de CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}} 
Les balises sont essentiellement des paires clé-valeur de chaînes. 
{{% /alert %}} 

## **Obtenir les valeurs des balises**

Dans les diapositives, une balise correspond aux méthodes [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#getKeywords) et [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#setKeywords). Cet exemple de code montre comment obtenir la valeur d'une balise avec Aspose.Slides pour PHP via Java pour [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation) :

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

Si vous devez classer certaines présentations en fonction d'une règle ou d'une propriété spécifique, vous pouvez tirer parti de l'ajout de balises à ces présentations. Par exemple, si vous voulez regrouper ou catégoriser toutes les présentations provenant des pays d'Amérique du Nord, vous pouvez créer une balise Amérique du Nord et attribuer aux pays concernés (les États‑Unis, le Mexique et le Canada) comme valeurs.

Cet exemple de code montre comment ajouter une balise à une [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation) en utilisant Aspose.Slides pour PHP via Java :

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

Les balises peuvent également être définies pour [Slide](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/) :

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

Ou toute [Shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/) individuelle :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Limites**

Les balises ajoutées via la collection de balises de données personnalisées en utilisant `getCustomData()->getTags()` sont stockées uniquement dans le fichier PowerPoint. Elles **ne sont pas** transférées vers la structure de balises PDF lorsque la présentation est exportée en PDF. Par conséquent, un identifiant personnalisé assigné comme balise ne peut pas être récupéré depuis le PDF balisé.

**Solution de contournement** : vous pouvez stocker un identifiant personnalisé dans le **texte alternatif** de l'objet (par ex., `$shape->setAlternativeText("MyId")`). Après l'exportation en PDF, le texte alternatif peut apparaître dans la structure de balises du PDF.

## **FAQ**

**Puis-je supprimer toutes les balises d'une présentation, d'une diapositive ou d'une forme en une seule opération ?**

Oui. La [collection de balises](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tagcollection/) prend en charge l'opération [clear](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tagcollection/clear/) qui supprime toutes les paires clé‑valeur en une fois.

**Comment supprimer une seule balise par son nom sans parcourir toute la collection ?**

Utilisez l'opération [remove(name)](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tagcollection/remove/) sur la [collection de balises](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tagcollection/) pour supprimer la balise par sa clé.

**Comment puis-je récupérer la liste complète des noms de balises pour l'analyse ou le filtrage ?**

Utilisez [getNamesOfTags](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tagcollection/getnamesoftags/) sur la [collection de balises](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tagcollection/) ; elle renvoie un tableau contenant tous les noms de balises.