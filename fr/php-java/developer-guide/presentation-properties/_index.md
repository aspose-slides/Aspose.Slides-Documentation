---
title: Gérer les propriétés de présentation en PHP
linktitle: Propriétés de présentation
type: docs
weight: 70
url: /fr/php-java/presentation-properties/
keywords:
- propriétés PowerPoint
- propriétés de présentation
- propriétés de document
- propriétés intégrées
- propriétés personnalisées
- propriétés avancées
- gérer les propriétés
- modifier les propriétés
- métadonnées du document
- éditer les métadonnées
- langue de vérification
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides pour PHP via Java et simplifiez la recherche, le branding et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---
## **Introduction**

Aspose.Slides prend en charge deux types de propriétés de document : **Intégrées** et **Personnalisées**. Ces deux types de propriétés peuvent être facilement accédés et gérés à l'aide de l'API Aspose.Slides.

Aspose.Slides vous permet de travailler avec les propriétés des présentations via la classe [DocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/) . Une instance de cette classe est renvoyée par la méthode [Presentation::getDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getDocumentProperties). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Remarque" %}}
Veuillez noter que les champs **Application** et **AppVersion** ne peuvent pas être modifiés. Aspose.Slides les réécrit à chaque sauvegarde, de sorte qu’une présentation enregistrée indique toujours « Aspose.Slides for PHP via Java » et la version de la bibliothèque qui l’a produite. Toute valeur transmise à `setNameOfApplication` est ignorée lors de l’écriture de la présentation.
{{% /alert %}} 

## **Gestion des propriétés de la présentation**

Microsoft PowerPoint propose une fonctionnalité permettant d’ajouter certaines propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux catégories de propriétés de document comme suit :

- Propriétés système (Intégrées)
- Propriétés définies par l’utilisateur (Personnalisées)

Les propriétés **Intégrées** contiennent des informations générales sur le document telles que le titre du document, le nom de l’auteur, les statistiques du document, etc. Les propriétés **Personnalisées** sont celles définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont définis par l’utilisateur. Avec Aspose.Slides pour PHP via Java, les développeurs peuvent accéder et modifier les valeurs des propriétés intégrées ainsi que des propriétés personnalisées.

## **Propriétés de document dans PowerPoint**

Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Il suffit de cliquer sur l’icône Office puis sur le menu **Préparer | Propriétés | Propriétés avancées** de Microsoft PowerPoint 2007 comme illustré ci‑dessous :

|**Sélectionner l'élément de menu Propriétés avancées**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Après avoir sélectionné l’élément de menu **Propriétés avancées**, une boîte de dialogue apparaît, vous permettant de gérer les propriétés du fichier PowerPoint comme le montre la figure suivante :

|**Boîte de dialogue Propriétés**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Dans la **Boîte de dialogue Propriétés** ci‑above, vous voyez plusieurs onglets tels que **Général**, **Résumé**, **Statistiques**, **Contenu** et **Personnalisé**. Tous ces onglets permettent de configurer différents types d’informations liées aux fichiers PowerPoint. L’onglet **Personnalisé** est utilisé pour gérer les propriétés personnalisées des fichiers PowerPoint.

### Travailler avec les propriétés de document à l’aide d’Aspose.Slides pour PHP via Java

Comme décrit précédemment, Aspose.Slides pour PHP via Java prend en charge deux types de propriétés de document, à savoir les propriétés **Intégrées** et **Personnalisées**. Ainsi, les développeurs peuvent accéder aux deux types de propriétés via l’API Aspose.Slides pour PHP via Java. Aspose.Slides pour PHP via Java fournit la classe [DocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties) qui représente les propriétés de document associées à un fichier de présentation via la propriété **Presentation.DocumentProperties**.

Les développeurs peuvent utiliser la propriété **DocumentProperties** exposée par l’objet [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation) pour accéder aux propriétés de document des fichiers de présentation comme décrit ci‑dessous :

## **Lire les propriétés publiques d’une présentation chiffrée**

Un mot de passe d’ouverture protège normalement le contenu de la présentation ainsi que les propriétés du document. Lorsque la présentation est chiffrée en passant `false` à [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), ses propriétés de document restent publiques. Une application peut alors passer `true` à [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) et lire les métadonnées publiques sans fournir le mot de passe d’ouverture.

L’option « document‑properties‑only » contrôle ce qu’Aspose.Slides charge ; elle ne décrypte rien. Si les propriétés étaient incluses dans le chiffrement, leur chargement sans le mot de passe échoue. Si la présentation n’est pas chiffrée, l’option est ignorée et la présentation complète est chargée.

L’exemple suivant vérifie le mode de chargement via [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) puis lit les propriétés intégrées via [Presentation::getDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getDocumentProperties) :

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

Dans ce mode, le contenu des diapositives n’est pas chargé. Les diapositives, maîtres, dispositions, formes, médias et autres objets de la présentation sont indisponibles. Les applications doivent toujours vérifier [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fr/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) avant d’effectuer une opération nécessitant le modèle d’objet complet de la présentation.

{{% alert color="warning" title="Avertissement" %}}
Les métadonnées publiques peuvent exposer les noms d’auteur, titres, sujets, mots‑clés, informations d’entreprise, commentaires et valeurs personnalisées. Chiffrez les propriétés sensibles avec la présentation. Ne les laissez publiques que lorsque l’indexation, la classification, la recherche ou les systèmes de gestion de documents ont une exigence spécifique d’accès sans mot de passe.
{{% /alert %}}

## **Mettre à jour les propriétés d’une présentation chiffrée**

Pour un fichier PPTX chiffré, une présentation chargée en mode « document‑properties‑only » est destinée à la lecture des métadonnées publiques. Aspose.Slides ne peut pas enregistrer les propriétés modifiées de cet objet à métadonnées‑uniques car les propriétés publiques doivent rester cohérentes avec les données correspondantes à l’intérieur de la présentation chiffrée. Leur mise à jour nécessite donc le mot de passe d’ouverture correct et un chargement complet.

L’exemple suivant ouvre la présentation avec [LoadOptions::setPassword](https://reference.aspose.com/slides/fr/php-java/aspose.slides/loadoptions/#setPassword), met à jour les propriétés intégrées publiques, puis enregistre le résultat. Il utilise ensuite [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#isEncrypted) pour vérifier que le chiffrement est préservé et rouvre les métadonnées publiques sans mot de passe afin de vérifier les nouvelles valeurs :

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Si une application n’est pas autorisée à déchiffrer ou à charger le contenu de la présentation, elle doit traiter les propriétés publiques d’un fichier PPTX chiffré comme en lecture seule.

## **Accéder aux propriétés intégrées**

Ces propriétés exposées par l’objet [DocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties) comprennent : **Creator** (Auteur), **Description**, **Keywords**, **Created** (Date de création), **Modified** (Date de modification), **Printed** (Date du dernier impression), **LastModifiedBy**, **SharedDoc** (Partagée entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**.

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

Modifier les propriétés intégrées des fichiers de présentation est aussi simple que d’y accéder. Il suffit d’assigner une chaîne de caractères à la propriété souhaitée et la valeur sera modifiée. Dans l’exemple ci‑dessous, nous montrons comment modifier les propriétés intégrées d’un fichier de présentation à l’aide d’Aspose.Slides pour PHP via Java.

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

Cet exemple modifie les propriétés intégrées de la présentation, affichées comme suit :

|**Propriétés de document intégrées après modification**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Ajouter des propriétés de document personnalisées**

Aspose.Slides pour PHP via Java permet également aux développeurs d’ajouter des valeurs personnalisées aux propriétés de document de la présentation. L’exemple ci‑dessous montre comment définir les propriétés personnalisées d’une présentation.

```php
  $pres = new Presentation();
  try {
    # Récupérer les propriétés du document
    $dProps = $pres->getDocumentProperties();
    # Ajout de propriétés personnalisées
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Récupérer le nom de la propriété à un index particulier
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

|**Propriétés de document personnalisées ajoutées**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accéder et modifier les propriétés personnalisées**

Aspose.Slides pour PHP via Java permet également aux développeurs d’accéder aux valeurs des propriétés personnalisées. L’exemple ci‑dessous montre comment accéder et modifier toutes ces propriétés personnalisées d’une présentation.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Créer une référence à l'objet DocumentProperties associé à la présentation
    $dp = $pres->getDocumentProperties();
    # Accéder et modifier les propriétés personnalisées
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Afficher les noms et valeurs des propriétés personnalisées
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

Cet exemple modifie les propriétés personnalisées de la présentation [PPTX](https://docs.fileformat.com/presentation/pptx/). Les figures suivantes montrent les propriétés personnalisées avant et après modification :

|**Propriétés personnalisées avant modification**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propriétés personnalisées après modification**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriétés de document avancées**

{{% alert color="info" title="Remarque" %}}
De nouvelles méthodes [readDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) et [writeBindedPresentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) ont été ajoutées à [PresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/PresentationInfo). La logique du setter de la propriété [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fr/php-java/aspose.slides/documentproperties/#setLastSavedTime) a été modifiée.
{{% /alert %}} 

Les deux nouvelles méthodes [readDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) et [updateDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) ont été ajoutées à la classe [PresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/PresentationInfo). Elles offrent un accès rapide aux propriétés du document et permettent de modifier et mettre à jour les propriétés sans charger toute la présentation.

Le scénario typique consiste à charger les propriétés, modifier certaines valeurs et mettre à jour le document, comme illustré ci‑dessus :

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

Il existe également une façon d’utiliser les propriétés d’une présentation particulière comme modèle pour mettre à jour les propriétés d’autres présentations :

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

Aspose.Slides fournit la propriété LanguageId (exposée par la classe PortionFormat) afin de vous permettre de définir la langue de vérification pour un document PowerPoint. La langue de vérification est la langue selon laquelle l’orthographe et la grammaire du PowerPoint sont contrôlées.

Ce code PHP montre comment définir la langue de vérification pour un PowerPoint : xxx Pourquoi LanguageId manque‑t‑il dans la classe Java PortionFormat ?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// définir l'ID d'une langue de vérification

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
    # Ajoute une nouvelle forme rectangulaire avec du texte
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

Essayez l’application en ligne [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fr/metadata) pour voir comment travailler avec les propriétés de document via l’API Aspose.Slides :

[![Voir & modifier les métadonnées PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/fr/metadata)

## **FAQ**

**Comment supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être entièrement supprimées. Vous pouvez toutefois modifier leurs valeurs ou les mettre à vide si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété personnalisée déjà existante ?**

Si vous ajoutez une propriété personnalisée qui existe déjà, sa valeur actuelle sera écrasée par la nouvelle. Vous n’avez pas besoin de supprimer ou de vérifier la propriété au préalable, Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés de la présentation sans charger complètement la présentation ?**

Oui. Utilisez [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationfactory/) puis [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentationinfo/#readDocumentProperties) pour lire les métadonnées de document stockées sans créer d’instance [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/). Voir [Build a Lightweight Presentation Inventory](/slides/fr/php-java/examine-presentation/) pour un exemple complet de rapport et les limitations spécifiques aux formats.

**Puis‑je lire les propriétés publiques d’une présentation chiffrée sans son mot de passe d’ouverture ?**

Oui. Le chiffrement des propriétés de document doit avoir été désactivé avant que la présentation ne soit chiffrée, et la présentation doit être chargée en mode « document‑properties‑only ».

**Puis‑je mettre à jour un fichier PPTX chiffré en mode « document‑properties‑only » ?**

Non. Les données publiques et chiffrées des propriétés doivent rester cohérentes, ainsi la mise à jour d’un fichier PPTX chiffré nécessite le chargement complet de la présentation avec le mot de passe d’ouverture correct.