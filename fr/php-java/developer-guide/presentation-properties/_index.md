---
title: Propriétés de Présentation
type: docs
weight: 70
url: /php-java/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPoint fournit une fonctionnalité pour ajouter des propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux types de propriétés de document comme suit :

- Propriétés définies par le système (intégrées)
- Propriétés définies par l'utilisateur (personnalisées)

Les propriétés **intégrées** contiennent des informations générales sur le document telles que le titre du document, le nom de l'auteur, les statistiques du document, etc. Les propriétés **personnalisées** sont celles qui sont définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont tous deux définis par l'utilisateur. En utilisant Aspose.Slides pour PHP via Java, les développeurs peuvent accéder et modifier les valeurs des propriétés intégrées ainsi que des propriétés personnalisées.

{{% /alert %}} 

## **Propriétés de Document dans PowerPoint**
Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Tout ce que vous avez à faire est de cliquer sur l'icône Office puis sur l'élément de menu **Préparer | Propriétés | Propriétés avancées** de Microsoft PowerPoint 2007 comme illustré ci-dessous :

{{% alert color="primary" %}} 

Veuillez noter que vous ne pouvez pas définir de valeurs pour les champs **Application** et **Producer**, car Aspose Ltd. et Aspose.Slides pour PHP via Java x.x.x seront affichés dans ces champs.

{{% /alert %}} 

|**Sélection d'un élément de menu Propriétés avancées**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Après avoir sélectionné l'élément de menu **Propriétés avancées**, une boîte de dialogue apparaîtra vous permettant de gérer les propriétés de document du fichier PowerPoint comme montré ci-dessous dans l'illustration :

|**Boîte de dialogue Propriétés**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Dans la **Boîte de dialogue Propriétés** ci-dessus, vous pouvez voir qu'il y a plusieurs onglets tels que **Général**, **Résumé**, **Statistiques**, **Contenu** et **Personnalisé**. Tous ces onglets permettent de configurer différents types d'informations liées aux fichiers PowerPoint. L'onglet **Personnalisé** est utilisé pour gérer les propriétés personnalisées des fichiers PowerPoint.

Travailler avec les Propriétés de Document en utilisant Aspose.Slides pour PHP via Java

Comme nous l'avons décrit plus tôt, Aspose.Slides pour PHP via Java prend en charge deux types de propriétés de document, qui sont les propriétés **intégrées** et **personnalisées**. Ainsi, les développeurs peuvent accéder aux deux types de propriétés en utilisant l'API d'Aspose.Slides pour PHP via Java. Aspose.Slides pour PHP via Java fournit une classe [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties) qui représente les propriétés de document associées à un fichier de présentation via la propriété **Presentation.DocumentProperties**.

Les développeurs peuvent utiliser la propriété **IDocumentProperties** exposée par l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) pour accéder aux propriétés de document des fichiers de présentation comme décrit ci-dessous :

## **Accéder aux Propriétés Intégrées**
Ces propriétés exposées par l'objet [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties) incluent : **Creator** (Auteur), **Description**, **Keywords**, **Created** (Date de Création), **Modified** (Date de Modification), **Printed** (Date de Dernière Impression), **LastModifiedBy**, **Keywords**, **SharedDoc** (Est partagé entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**.

```php
  # Instancier la classe Presentation qui représente la présentation
  $pres = new Presentation("Presentation.pptx");
  try {
    # Créer une référence à l'objet IDocumentProperties associé à la Présentation
    $dp = $pres->getDocumentProperties();
    # Afficher les propriétés intégrées
    echo("Catégorie : " . $dp->getCategory());
    echo("État Actuel : " . $dp->getContentStatus());
    echo("Date de Création : " . $dp->getCreatedTime());
    echo("Auteur : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("Mots-clés : " . $dp->getKeywords());
    echo("Dernier Modificateur : " . $dp->getLastSavedBy());
    echo("Superviseur : " . $dp->getManager());
    echo("Date de Modification : " . $dp->getLastSavedTime());
    echo("Format de Présentation : " . $dp->getPresentationFormat());
    echo("Date de Dernière Impression : " . $dp->getLastPrinted());
    echo("Est Partagé entre producteurs : " . $dp->getSharedDoc());
    echo("Sujet : " . $dp->getSubject());
    echo("Titre : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modifier les Propriétés Intégrées**
Modifier les propriétés intégrées des fichiers de présentation est aussi simple que d'y accéder. Vous pouvez simplement assigner une valeur chaîne à n'importe quelle propriété désirée et la valeur de la propriété serait modifiée. Dans l'exemple donné ci-dessous, nous avons démontré comment nous pouvons modifier les propriétés de document intégrées du fichier de présentation en utilisant Aspose.Slides pour PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Créer une référence à l'objet IDocumentProperties associé à la Présentation
    $dp = $pres->getDocumentProperties();
    # Définir les propriétés intégrées
    $dp->setAuthor("Aspose.Slides pour PHP via Java");
    $dp->setTitle("Modification des Propriétés de Présentation");
    $dp->setSubject("Sujet Aspose");
    $dp->setComments("Description Aspose");
    $dp->setManager("Gestionnaire Aspose");
    # Enregistrer votre présentation dans un fichier
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Cet exemple modifie les propriétés intégrées de la présentation qui peuvent être visualisées comme indiqué ci-dessous :

|**Propriétés intégrées du document après modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Ajouter des Propriétés Documentaires Personnalisées**
Aspose.Slides pour PHP via Java permet également aux développeurs d'ajouter des valeurs personnalisées pour les propriétés Document de présentation. Un exemple est donné ci-dessous qui montre comment définir les propriétés personnalisées pour une présentation.

```php
  $pres = new Presentation();
  try {
    # Obtenir les Propriétés de Document
    $dProps = $pres->getDocumentProperties();
    # Ajouter des propriétés personnalisées
    $dProps->set_Item("Nouvelle Personnalisée", 12);
    $dProps->set_Item("Mon Nom", "Mudassir");
    $dProps->set_Item("Personnalisée", 124);
    # Obtenir le nom de la propriété à un index particulier
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Supprimer la propriété sélectionnée
    $dProps->removeCustomProperty($getPropertyName);
    # Enregistrer la présentation
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Propriétés Documentaires Personnalisées Ajoutées**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accéder et Modifier les Propriétés Personnalisées**
Aspose.Slides pour PHP via Java permet également aux développeurs d'accéder aux valeurs des propriétés personnalisées. Un exemple est donné ci-dessous qui montre comment vous pouvez accéder et modifier toutes ces propriétés personnalisées pour une présentation.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Créer une référence à l'objet DocumentProperties associé à la Présentation
    $dp = $pres->getDocumentProperties();
    # Accéder et modifier les propriétés personnalisées
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Afficher les noms et valeurs des propriétés personnalisées
      echo("Nom de la Propriété Personnalisée : " . $dp->getCustomPropertyName($i));
      echo("Valeur de la Propriété Personnalisée : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Modifier les valeurs des propriétés personnalisées
      $dp->set_Item($dp->getCustomPropertyName($i), "Nouvelle Valeur " . $i + 1);
    }
    # Enregistrer votre présentation dans un fichier
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Cet exemple modifie les propriétés personnalisées de la présentation [PPTX](https://docs.fileformat.com/presentation/pptx/). Les figures suivantes montrent les propriétés personnalisées de la présentation avant et après la modification :

|**Propriétés Personnalisées avant Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Propriétés Personnalisées après Modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriétés Documentaires Avancées**
{{% alert color="primary" %}} 

De nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) et [WriteBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) ont été ajoutées à l'interface [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo), la logique du setter de la propriété [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) a été modifiée.

{{% /alert %}} 

Les deux nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--) et [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ont été ajoutées à l'interface [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo). Elles offrent un accès rapide aux propriétés de documents et permettent de modifier et mettre à jour les propriétés sans charger une présentation entière.

Le scénario typique consiste à charger les propriétés, modifier certaines valeurs et mettre à jour le document de la manière suivante :

```php
  # lire les informations de présentation
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # obtenir les propriétés actuelles
  $props = $info->readDocumentProperties();
  # définir les nouvelles valeurs des champs Auteur et Titre
  $props->setAuthor("Nouvel Auteur");
  $props->setTitle("Nouveau Titre");
  # mettre à jour la présentation avec de nouvelles valeurs
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");

```

Il existe une autre façon d'utiliser les propriétés d'une présentation particulière comme modèle pour mettre à jour les propriétés d'autres présentations :

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Auteur du Modèle");
  $template->setTitle("Titre du Modèle");
  $template->setCategory("Catégorie du Modèle");
  $template->setKeywords("MotClé1, MotClé2, MotClé3");
  $template->setCompany("Notre Entreprise");
  $template->setComments("Créé à partir du modèle");
  $template->setContentType("Contenu du Modèle");
  $template->setSubject("Sujet du Modèle");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

Un nouveau modèle peut être créé à partir de zéro puis utilisé pour mettre à jour plusieurs présentations :

```php
  $template = new DocumentProperties();
  $template->setAuthor("Auteur du Modèle");
  $template->setTitle("Titre du Modèle");
  $template->setCategory("Catégorie du Modèle");
  $template->setKeywords("MotClé1, MotClé2, MotClé3");
  $template->setCompany("Notre Entreprise");
  $template->setComments("Créé à partir du modèle");
  $template->setContentType("Contenu du Modèle");
  $template->setSubject("Sujet du Modèle");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

## **Vérifier si la Présentation est Modifiée ou Créée**
Aspose.Slides pour PHP via Java fournit la possibilité de vérifier si une présentation est modifiée ou créée. Un exemple est donné ci-dessous qui montre comment vérifier si la présentation est créée ou modifiée.

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("props.pptx");
  $props = $info->readDocumentProperties();
  $app = $props->getNameOfApplication();
  $ver = $props->getAppVersion();
  echo("Nom de l'Application : " . $app);
  echo("Version de l'Application : " . $ver);

```

## **Définir la Langue de Correction**

Aspose.Slides fournit la propriété LanguageId (exposée par la classe PortionFormat) pour vous permettre de définir la langue de correction pour un document PowerPoint. La langue de correction est la langue pour laquelle les orthographes et la grammaire dans PowerPoint sont vérifiées.

Ce code PHP vous montre comment définir la langue de correction pour un PowerPoint : xxx Pourquoi LanguageId est-il absent de la classe PortionFormat de Java ?

```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// définir l'Id d'une langue de correction

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir la Langue par Défaut**

Ce code PHP vous montre comment définir la langue par défaut pour l'ensemble d'une présentation PowerPoint :

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Ajoute une nouvelle forme rectangulaire avec du texte
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("Nouveau Texte");
    # Vérifie la langue de la première portion
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```