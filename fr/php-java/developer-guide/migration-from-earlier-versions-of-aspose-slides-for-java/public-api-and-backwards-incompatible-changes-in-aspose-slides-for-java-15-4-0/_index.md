---
title: API public et changements incompatibles en arrière dans Aspose.Slides pour PHP via Java 15.4.0
type: docs
weight: 120
url: /fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [classes ajoutées](/slides/fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/), méthodes, propriétés, etc., toutes les nouvelles restrictions et autres [changements](/slides/fr/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) introduits avec l'API Aspose.Slides pour PHP via Java 15.4.0.

{{% /alert %}} 
## **Changements de l'API publique**
### **Enum OrganizationChartLayoutType a été ajouté**
L'énumération com.aspose.slides.OrganizationChartLayoutType représente le type de formatage des nœuds enfants dans un organigramme.
### **La méthode IBulletFormat.applyDefaultParagraphIndentsShifts() a été ajoutée**
La méthode com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts définit les décalages par défaut non nuls pour l'indentation de paragraphe efficace et la marge gauche lorsque les puces sont activées (comme le fait PowerPoint s'il active les puces/de la numérotation de paragraphe). Si les puces sont désactivées, la méthode réinitialise simplement l'indentation de paragraphe et la marge gauche (comme le fait PowerPoint s'il désactive les puces/de la numérotation de paragraphe).
### **La méthode IConnector.reroute() a été ajoutée**
La méthode com.aspose.slides.IConnector.reroute() redirige le connecteur de manière à prendre le chemin le plus court possible entre les formes qu'il connecte. Pour ce faire, la méthode reroute() peut changer l'index du site de connexion de la forme de départ et l'index du site de connexion de la forme de fin.

```php
  $input = new Presentation();
  $shapes = $input->getSlides()->get_Item(0)->getShapes();
  $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
  $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
  $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
  $connector->setStartShapeConnectedTo($ellipse);
  $connector->setEndShapeConnectedTo($rectangle);
  $connector->reroute();
  $input->save("output.pptx", SaveFormat::Pptx);

```
### **La méthode IPresentation.getSlideById(long) a été ajoutée**
La méthode Aspose.Slides.IPresentation.getSlideById(int) renvoie un Slide, MasterSlide ou LayoutSlide par ID de diapositive.

```php
  $presentation = new Presentation();
  $id = $presentation->getSlides()->get_Item(0)->getSlideId();
  $slide = $presentation->getSlideById($id);

```
### **La méthode ISmartArt.getNodes() a été ajoutée**
La méthode com.aspose.slides.ISmartArt.getNodes() renvoie une collection de nœuds racines dans l'objet SmartArt.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::VerticalBulletList);
  $node = $smart->getNodes()->get_Item(1);// sélectionner le deuxième nœud racine

  $node->getTextFrame()->setText("Deuxième nœud racine");
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **La méthode ISmartArt.setLayout(int) a été ajoutée**
La méthode pour la propriété com.aspose.slides.ISmartArt.setLayout(int) a été ajoutée. Elle permet de changer le type de mise en page d'un diagramme existant.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $smart->setLayout(SmartArtLayoutType::BasicProcess);
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **La méthode ISmartArtNode.isHidden() a été ajoutée**
La méthode com.aspose.slides.ISmartArtNode.isHidden() renvoie vrai si ce nœud est un nœud caché dans le modèle de données.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
  $node = $smart->getAllNodes()->addNode();
  $hidden = $node->isHidden();// renvoie vrai

  if ($hidden) {
    # faire quelques actions ou notifications
  }
  $pres->Save("out.pptx", SaveFormat::Pptx);

```
### **Les méthodes ISmartArt.isReversed(), setReserved() ont été ajoutées**
La propriété com.aspose.slides.ISmartArt.IsReversed permet d'obtenir ou de définir l'état du diagramme SmartArt par rapport au (de gauche à droite) LTR ou (de droite à gauche) RTL, si le diagramme supporte la réversion.

```php
  $presentation = new Presentation();
  $smart = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
  $smart->setReversed(true);
  $presentation->save("out.pptx", SaveFormat::Pptx);

```
### **Les méthodes ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) ont été ajoutées**
Les méthodes com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) permettent d'obtenir ou de définir le type de diagramme organisationnel associé au nœud actuel.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
  $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **La propriété IShape.getConnectionSiteCount() a été ajoutée**
La propriété com.aspose.slides.getConnectionSiteCount() renvoie le nombre de sites de connexion sur la forme.

```php
  $input = new Presentation();
  $shapes = $input->getSlides()->get_Item(0)->getShapes();
  $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
  $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
  $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);
  $connector->setStartShapeConnectedTo($ellipse);
  $connector->setEndShapeConnectedTo($rectangle);
  $wantedIndex = 6;
  if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
    $connector->setStartShapeConnectionSiteIndex($wantedIndex);
  }
  $input->save("output.pptx", SaveFormat::Pptx);

```
### **Changements mineurs**
Voici la liste des changements mineurs de l'API :

|Enum com.aspose.slides.BevelColorMode |supprimé, énumération inutilisée |
| :- | :- |
|Méthode ThreeDFormatEffectiveData.getBevelColorMode() |supprimé, propriété inutilisée |
|Méthode com.aspose.slides.ChartSeriesGroup.getChart() |ajoutée |
|Hérédité de IParagraphFormatEffectiveData de ISlideComponent <br>Hérédité de IThreeDFormat de ISlideComponent |supprimée |
|Méthode com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Méthode com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Méthode com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Méthode com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Méthode com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Méthode com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |supprimées en tant qu'obsolètes |