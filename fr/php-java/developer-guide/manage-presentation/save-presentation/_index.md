---
title: Enregistrer la présentation
type: docs
weight: 80
url: /fr/php-java/save-presentation/
---

## **Aperçu**
{{% alert color="primary" %}} 

[L'ouverture de la présentation](/slides/fr/php-java/open-presentation/) a décrit comment utiliser la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) pour ouvrir une présentation. Cet article explique comment créer et enregistrer des présentations.

{{% /alert %}} 

La classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) contient le contenu d'une présentation. Que vous créiez une présentation à partir de zéro ou que vous modifiez une présentation existante, une fois terminé, vous souhaitez enregistrer la présentation. Avec Aspose.Slides pour PHP via Java, elle peut être enregistrée en tant que **fichier** ou **flux**. Cet article explique comment enregistrer une présentation de différentes manières :

## **Enregistrer la présentation dans un fichier**
Enregistrez une présentation dans un fichier en appelant la méthode [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). Il suffit de passer le nom de fichier et le [**SaveFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/SaveFormat) à la méthode [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-).

Les exemples suivants montrent comment enregistrer une présentation avec Aspose.Slides pour PHP via Java.

```php
  # Instancier un objet Presentation représentant un fichier PPT
  $pres = new Presentation();
  try {
    # ...faire un travail ici...
    # Enregistrer votre présentation dans un fichier
    $pres->save("demoPass.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Enregistrer la présentation dans un flux**
Il est possible d'enregistrer une présentation dans un flux en passant un flux de sortie à la méthode [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.io.OutputStream-int-) de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). Il existe plusieurs types de flux dans lesquels une présentation peut être enregistrée. Dans l'exemple ci-dessous, nous avons créé un nouveau fichier de présentation, ajouté du texte dans une forme et enregistré la présentation dans le flux.

```php
  # Instancier un objet Presentation représentant un fichier PPT
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 200, 200);
    # Ajouter du texte à la forme
    $shape->getTextFrame()->setText("Cette démo montre comment créer un fichier PowerPoint et l'enregistrer dans un flux.");
    $os = new Java("java.io.FileOutputStream", "Save_As_Stream_out.pptx");
    $pres->save($os, SaveFormat::Pptx);
    $os->close();
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Enregistrer la présentation avec un type de vue prédéfini**
Aspose.Slides pour PHP via Java offre la possibilité de définir le type de vue pour la présentation générée lorsqu'elle est ouverte dans PowerPoint via la classe [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties). La propriété [**setLastView**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#setLastView-int-) est utilisée pour définir le type de vue en utilisant l'énumérateur [**ViewType**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewType).

```php
  # Ouverture du fichier de présentation
  $pres = new Presentation();
  try {
    # Définir le type de vue
    $pres->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # Enregistrer la présentation
    $pres->save("newDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Enregistrer des présentations au format strict Office Open XML**
Aspose.Slides vous permet d'enregistrer la présentation au format strict Office Open XML. À cette fin, il fournit la classe [**PptxOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions) dans laquelle vous pouvez définir la propriété Conformance lors de l'enregistrement du fichier de présentation. Si vous définissez sa valeur comme [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/php-java/aspose.slides/Conformance#Iso29500_2008_Strict), alors le fichier de présentation de sortie sera enregistré au format strict Open XML.

Le code d'exemple suivant crée une présentation et l'enregistre au format strict Office Open XML. Lors de l'appel à la méthode [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) pour la présentation, l'objet [**PptxOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions) est passé avec la propriété Conformance définie comme [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/php-java/aspose.slides/Conformance#Iso29500_2008_Strict).

```php
  # Instancier un objet Presentation représentant un fichier PPT
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter une autoshape de type ligne
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Définir les options d'enregistrement au format strict Office Open XML
    $options = new PptxOptions();
    $options->setConformance(Conformance->Iso29500_2008_Strict);
    # Enregistrer votre présentation dans un fichier
    $pres->save("demoPass.pptx", SaveFormat::Pptx, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Enregistrer des présentations au format Office Open XML en mode Zip64**
Un fichier Office Open XML est une archive ZIP qui a une limite de 4 Go (2^32 octets) sur la taille non compressée d'un fichier, la taille compressée d'un fichier et la taille totale de l'archive, ainsi qu'une limite de 65 535 (2^16-1) fichiers dans l'archive. Les extensions de format ZIP64 augmentent les limites à 2^64.

La nouvelle propriété [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/) vous permet de choisir quand utiliser les extensions de format ZIP64 pour le fichier Office Open XML enregistré.

Cette propriété fournit les modes suivants :

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#IfNecessary) signifie que les extensions de format ZIP64 ne seront utilisées que si la présentation dépasse les limitations ci-dessus. C'est le mode par défaut.
- [Zip64Mode.Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) signifie que les extensions de format ZIP64 ne seront pas utilisées.
- [Zip64Mode.Always](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Always) signifie que les extensions de format ZIP64 seront toujours utilisées.

Le code suivant montre comment enregistrer la présentation au format PPTX avec les extensions de format ZIP64 :

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $pptxOptions = new PptxOptions();
    $pptxOptions->setZip64Mode(Zip64Mode::Always);
    
    $pres->save("Sample-zip64.pptx", SaveFormat::Pptx, $pptxOptions);
  } finally {
    $pres->dispose();
  }
```

{{% alert title="REMARQUE" color="warning" %}}

L'enregistrement en mode Zip64Mode.Never déclenchera une [PptxException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxexception/) si la présentation ne peut pas être enregistrée au format ZIP32.

{{% /alert %}}

## **Enregistrer les mises à jour de progression en pourcentage**
Une nouvelle interface [**IProgressCallback**](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback) a été ajoutée à l'interface [**ISaveOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISaveOptions) et à la classe abstraite [**SaveOptions** ](https://reference.aspose.com/slides/php-java/aspose.slides/SaveOptions). L'interface [**IProgressCallback**](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback) représente un objet de rappel pour enregistrer les mises à jour de progression en pourcentage.  

Les extraits de code suivants montrent comment utiliser l'interface [IProgressCallback](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback) :

```php
  class ExportProgressHandler {
    function reporting($progressValue) {
      # Utiliser ici la valeur de pourcentage de progression
      $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
      echo($progress . "% fichier converti");
    }
  }

  # Ouverture du fichier de présentation
  $pres = new Presentation("ConvertToPDF.pptx");
  try {
    $saveOptions = new PdfOptions();
    $progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));
    $saveOptions->setProgressCallback($progressHandler);
    $pres->save("ConvertToPDF.pdf", SaveFormat::Pdf, $saveOptions);
  } finally {
    $pres->dispose();
  }
```

{{% alert title="Info" color="info" %}}

En utilisant sa propre API, Aspose a développé une [application de séparation PowerPoint gratuite](https://products.aspose.app/slides/splitter) qui permet aux utilisateurs de diviser leurs présentations en plusieurs fichiers. Essentiellement, l'application enregistre des diapositives sélectionnées d'une présentation donnée sous forme de nouveaux fichiers PowerPoint (PPTX ou PPT). 

{{% /alert %}}