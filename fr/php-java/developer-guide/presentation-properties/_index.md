---
title: Gérer les propriétés de présentation en PHP
linktitle: Propriétés de présentation
type: docs
weight: 70
url: /fr/php-java/presentation-properties/
keywords:
- Propriétés PowerPoint
- Propriétés de présentation
- Propriétés de document
- Propriétés intégrées
- Propriétés personnalisées
- Propriétés avancées
- Gérer les propriétés
- Modifier les propriétés
- Métadonnées de document
- Modifier les métadonnées
- Langue de vérification
- Langue par défaut
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides pour PHP via Java et rationalisez la recherche, le branding et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---

{{% alert color="primary" %}} 

Microsoft PowerPoint propose une fonctionnalité permettant d’ajouter certaines propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux types de propriétés de document comme suit :

- Propriétés définies par le système (intégrées)
- Propriétés définies par l'utilisateur (personnalisées)

**Intégrées** les propriétés contiennent des informations générales sur le document telles que le titre du document, le nom de l’auteur, les statistiques du document, etc. **Personnalisées** les propriétés sont celles qui sont définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont définis par l’utilisateur. Avec Aspose.Slides for PHP via Java, les développeurs peuvent accéder et modifier les valeurs des propriétés intégrées ainsi que des propriétés personnalisées.

{{% /alert %}} 

## **Propriétés du document dans PowerPoint**

Microsoft PowerPoint 2007 permet de gérer les propriétés du document des fichiers de présentation. Il suffit de cliquer sur l’icône Office puis sur le menu **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007 comme illustré ci‑dessous :

{{% alert color="primary" %}} 

Veuillez noter que vous ne pouvez pas définir de valeurs pour les champs **Application** et **Producer**, car Aspose Ltd. et Aspose.Slides for PHP via Java x.x.x seront affichés dans ces champs.

{{% /alert %}} 

|**Sélection de l'élément de menu Propriétés avancées**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Après avoir sélectionné **Advanced Properties**, une boîte de dialogue apparaît vous permettant de gérer les propriétés du document du fichier PowerPoint comme le montre la figure suivante :

|**Boîte de dialogue Propriétés**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Dans la **Boîte de dialogue Propriétés** ci‑dessus, vous pouvez voir qu’il existe plusieurs onglets tels que **General**, **Summary**, **Statistics**, **Contents** et **Custom**. Tous ces onglets permettent de configurer différents types d’informations liées aux fichiers PowerPoint. L’onglet **Custom** est utilisé pour gérer les propriétés personnalisées des fichiers PowerPoint.

### Travailler avec les propriétés de document à l’aide d'Aspose.Slides pour PHP via Java

Comme indiqué précédemment, Aspose.Slides for PHP via Java prend en charge deux types de propriétés de document, les propriétés **intégrées** et **personnalisées**. Ainsi, les développeurs peuvent accéder aux deux types de propriétés grâce à l’API Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java fournit la classe [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties) qui représente les propriétés du document associées à un fichier de présentation via la propriété **Presentation.DocumentProperties**.

Les développeurs peuvent utiliser la propriété **IDocumentProperties** exposée par l’objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) pour accéder aux propriétés du document des fichiers de présentation comme décrit ci‑dessous :

## **Accéder aux propriétés intégrées**

Ces propriétés exposées par l’objet [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties) comprennent : **Creator** (Auteur), **Description**, **Keywords**, **Created** (Date de création), **Modified** (Date de modification), **Printed** (Date du dernier impression), **LastModifiedBy**, **SharedDoc** (Le document est‑il partagé entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**.
```php
  # Instancier la classe Presentation qui représente la présentation
  $pres = new Presentation("Presentation.pptx");
  try {
    # Créer une référence à l'objet IDocumentProperties associé à la présentation
    $dp = $pres->getDocumentProperties();
    # Afficher les propriétés intégrées
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Modifier les propriétés intégrées**

Modifier les propriétés intégrées des fichiers de présentation est aussi simple que de les accéder. Vous pouvez simplement assigner une chaîne de caractères à la propriété souhaitée et la valeur sera modifiée. Dans l’exemple ci‑dessous, nous montrons comment modifier les propriétés de document intégrées du fichier de présentation à l’aide d’Aspose.Slides for PHP via Java.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Créer une référence à l'objet IDocumentProperties associé à la présentation
    $dp = $pres->getDocumentProperties();
    # Définir les propriétés intégrées
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Enregistrer votre présentation dans un fichier
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Cet exemple modifie les propriétés intégrées de la présentation, comme illustré ci‑dessous :

|**Propriétés du document intégrées après modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Ajouter des propriétés de document personnalisées**

Aspose.Slides for PHP via Java permet également aux développeurs d’ajouter des valeurs personnalisées aux propriétés du document d’une présentation. Un exemple est présenté ci‑dessous montrant comment définir les propriétés personnalisées d’une présentation.
```php
  $pres = new Presentation();
  try {
    # Obtention des propriétés du document
    $dProps = $pres->getDocumentProperties();
    # Ajout de propriétés personnalisées
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Obtention du nom de propriété à un indice particulier
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Suppression de la propriété sélectionnée
    $dProps->removeCustomProperty($getPropertyName);
    # Enregistrement de la présentation
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|**Propriétés de document personnalisées ajoutées**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accéder et modifier les propriétés personnalisées**

Aspose.Slides for PHP via Java permet aussi aux développeurs d’accéder aux valeurs des propriétés personnalisées. Un exemple ci‑dessous montre comment accéder et modifier toutes ces propriétés personnalisées d’une présentation.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Créer une référence à l'objet DocumentProperties associé à la présentation
    $dp = $pres->getDocumentProperties();
    # Accéder et modifier les propriétés personnalisées
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Afficher les noms et les valeurs des propriétés personnalisées
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Modifier les valeurs des propriétés personnalisées
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Enregistrer votre présentation dans un fichier
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Cet exemple modifie les propriétés personnalisées du [PPTX](https://docs.fileformat.com/presentation/pptx/) : les figures suivantes affichent les propriétés personnalisées de la présentation avant et après la modification :

|**Propriétés personnalisées avant modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propriétés personnalisées après modification**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriétés de document avancées**

{{% alert color="primary" %}} 

De nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), et [WriteBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) ont été ajoutées à [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo). La logique du setteur de la propriété [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) a été modifiée.

{{% /alert %}} 

Les deux nouvelles méthodes [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--) et [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) ont été ajoutées à l’interface [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo). Elles offrent un accès rapide aux propriétés du document et permettent de les modifier sans charger l’ensemble de la présentation.

Le scénario typique : charger les propriétés, modifier une valeur et mettre à jour le document peut être implémenté de la manière suivante :
```php
  # lire les informations de la présentation
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # obtenir les propriétés actuelles
  $props = $info->readDocumentProperties();
  # définir les nouvelles valeurs des champs Auteur et Titre
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # mettre à jour la présentation avec de nouvelles valeurs
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```


Il existe une autre façon d’utiliser les propriétés d’une présentation donnée comme modèle pour mettre à jour les propriétés d’autres présentations :
```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```


Un nouveau modèle peut être créé à partir de zéro, puis utilisé pour mettre à jour plusieurs présentations :
```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```


## **Définir la langue de vérification**

Aspose.Slides fournit la propriété **LanguageId** (exposée par la classe **PortionFormat**) afin de vous permettre de définir la langue de vérification pour un document PowerPoint. La langue de vérification est la langue selon laquelle l’orthographe et la grammaire du PowerPoint sont contrôlées.

Ce code PHP montre comment définir la langue de vérification pour un PowerPoint : xxx Pourquoi **LanguageId** est‑il absent de la classe Java **PortionFormat** ?
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
    $portionFormat::setLanguageId("zh-CN");// définir l'Id de la langue de vérification

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir la langue par défaut**

Ce code PHP montre comment définir la langue par défaut pour l’ensemble d’une présentation PowerPoint :
```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Ajoute une nouvelle forme rectangulaire avec texte
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Vérifie la langue de la première portion
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Exemple en direct**

Essayez l’application en ligne [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) pour voir comment travailler avec les propriétés de document via l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Comment puis‑je supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées complètement. Vous pouvez toutefois modifier leurs valeurs ou les laisser vides si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété personnalisée qui existe déjà ?**

Si vous ajoutez une propriété personnalisée qui existe déjà, sa valeur existante sera écrasée par la nouvelle. Vous n’avez pas besoin de la supprimer ou de la vérifier au préalable, car Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés d’une présentation sans charger complètement la présentation ?**

Oui, vous pouvez accéder aux propriétés d’une présentation sans la charger entièrement en utilisant la méthode `getPresentationInfo` de la classe [PresentationFactory](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/). Puis, utilisez la méthode `readDocumentProperties` de la classe [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/) pour lire les propriétés de façon efficace, économisant ainsi de la mémoire et améliorant les performances.