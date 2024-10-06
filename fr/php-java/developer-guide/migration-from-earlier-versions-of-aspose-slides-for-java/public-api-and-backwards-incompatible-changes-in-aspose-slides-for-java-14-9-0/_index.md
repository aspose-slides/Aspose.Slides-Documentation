---
title: API public et modifications incompatibles avec les versions précédentes dans Aspose.Slides pour PHP via Java 14.9.0
type: docs
weight: 80
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [ajouts](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) de classes, méthodes, propriétés, etc., ainsi que toute nouvelle restriction et d'autres [modifications](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) introduites avec l'API Aspose.Slides pour PHP via Java 14.9.0.

{{% /alert %}} 
## **Modifications de l'API publique**
### **Méthodes ajoutées pour remplacer l'image dans PPImage, IPPImage**
Méthodes ajoutées :

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

```php
  $presentation = new Presentation("presentation.pptx");
  # La première méthode
  # ...
  $imageData = $presentation->getImages()->get_Item(0)->replaceImage($imageData);
  # La seconde méthode
  $presentation->getImages()->get_Item(1)->replaceImage($presentation->getImages()->get_Item(0));
  $presentation->save("presentation_out.pptx", SaveFormat::Pptx);

```
### **Méthodes ajoutées pour sauvegarder des diapositives en conservant les numéros de page**
Les méthodes suivantes ont été ajoutées :

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Ces méthodes permettent de sauvegarder les diapositives de présentation spécifiées au format PDF, XPS, TIFF, HTML. Le tableau 'slides' permet de spécifier les numéros de pages, en commençant par 1.

```php
  save($string, $slides, SaveFormat);

```




```php
  $presentation = new Presentation($presentationFileName);
  $slides = array(2, 3, 5 );// Tableau de positions de diapositives

  $presentation->save($outFileName, $slides, SaveFormat::Pdf);

```
### **Ajout de la valeur d'énumération SmartArtLayoutType::Custom**
Ce type de mise en page SmartArt représente un diagramme avec un modèle personnalisé. Les diagrammes personnalisés ne peuvent être chargés que depuis un fichier de présentation et ne peuvent pas être créés via la méthode ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType::Custom)
### **Ajout de la classe SmartArtShape et de l'interface ISmartArtShape**
La classe Aspose.Slides.SmartArt.SmartArtShape (et son interface Aspose.Slides.SmartArt.ISmartArtShape) donne accès aux formes individuelles à l'intérieur du diagramme SmartArt. SmartArtShape peut être utilisé pour changer FillFormat, LineFormat, ajouter des Hyperliens, etc.

{{% alert color="primary" %}} 

SmartArtShape ne prend pas en charge les propriétés IShape RawFrame, Frame, Rotation, X, Y, Width, Height et lance System.NotSupportedException lorsqu'on tente d'y accéder.

{{% /alert %}} 

Exemple d'utilisation :

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $node = $smart->getAllNodes()->get_Item(0);
  foreach($node->getShapes() as $shape) {
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
  }
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **La classe SmartArtShapeCollection, l'interface ISmartArtShapeCollection et la méthode ISmartArtNode.getShapes() ont été ajoutées**
La classe Aspose.Slides.SmartArt.SmartArtShapeCollection (et son interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) donne accès aux formes individuelles à l'intérieur du diagramme SmartArt. La collection contient des formes associées à SmartArtNode. La propriété SmartArtNode.Shapes renvoie des collections de toutes les formes associées au nœud.

{{% alert color="primary" %}} 

Selon SmartArtLayoutType, une SmartArtShape peut être partagée entre plusieurs nœuds.

{{% /alert %}} 

﻿

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $node = $smart->getAllNodes()->get_Item(0);
  foreach($node->getShapes() as $shape) {
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
  }
  $pres->save("out.pptx", SaveFormat::Pptx);

```