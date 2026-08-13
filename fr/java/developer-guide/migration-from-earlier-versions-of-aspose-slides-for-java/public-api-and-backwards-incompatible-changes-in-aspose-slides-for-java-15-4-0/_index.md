---
title: API publique et modifications incompatibles rétroactives dans Aspose.Slides pour Java 15.4.0
linktitle: Aspose.Slides pour Java 15.4.0
type: docs
weight: 120
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- migration
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Examinez les mises à jour de l'API publique et les changements majeurs dans Aspose.Slides pour Java afin de migrer en douceur vos solutions de présentations PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 
Cette page répertorie toutes les classes, méthodes, propriétés, etc., [added](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) ainsi que les nouvelles restrictions et d'autres [changes](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) introduites avec l'API Aspose.Slides for Java 15.4.0.
{{% /alert %}} 
## **Modifications de l'API publique**
### **Enum OrganizationChartLayoutType a été ajouté**
L'énumération com.aspose.slides.OrganizationChartLayoutType représente le type de formatage des nœuds enfants dans un organigramme.
### **La méthode IBulletFormat.applyDefaultParagraphIndentsShifts() a été ajoutée**
La méthode com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts définit les décalages non nuls par défaut pour le retrait de paragraphe effectif et la marge gauche lorsque les puces sont activées (comme PowerPoint le fait lorsqu’on active les puces/numérotation de paragraphe). Si les puces sont désactivées, elle réinitialise simplement le retrait de paragraphe et la marge gauche (comme PowerPoint le fait lorsqu’on désactive les puces/numérotation de paragraphe).
### **La méthode IConnector.reroute() a été ajoutée**
La méthode com.aspose.slides.IConnector.reroute() re-route le connecteur afin qu'il prenne le chemin le plus court possible entre les formes qu'il relie. Pour ce faire, la méthode reroute() peut modifier les propriétés StartShapeConnectionSiteIndex et EndShapeConnectionSiteIndex.
``` java
import com.aspose.slides.*;


 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

connector.reroute();

input.save("output.pptx", SaveFormat.Pptx);

```
### **La méthode IPresentation.getSlideById(long) a été ajoutée**
La méthode Aspose.Slides.IPresentation.getSlideById(long) renvoie une Slide, MasterSlide ou LayoutSlide à partir de l'identifiant de la diapositive.
``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **La méthode ISmartArt.getNodes() a été ajoutée**
La méthode com.aspose.slides.ISmartArt.getNodes() renvoie une collection de nœuds racines dans l'objet SmartArt.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // sélectionner le deuxième nœud racine

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **La méthode ISmartArt.setLayout(int) a été ajoutée**
La méthode pour la propriété com.aspose.slides.ISmartArt.setLayout(int) a été ajoutée. Elle permet de changer le type de mise en page d'un diagramme existant.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **La méthode ISmartArtNode.isHidden() a été ajoutée**
La méthode com.aspose.slides.ISmartArtNode.isHidden() renvoie true si ce nœud est un nœud masqué dans le modèle de données.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //renvoie true

if(hidden) {

    //effectuer des actions ou des notifications

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Les méthodes ISmartArt.isReversed() et setReversed() ont été ajoutées**
La propriété com.aspose.slides.ISmartArt.IsReversed permet d'obtenir ou de définir l'état du diagramme SmartArt par rapport à la direction (de gauche à droite) LTR ou (de droite à gauche) RTL, si le diagramme prend en charge l'inversion.
``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Les méthodes ISmartArtNode.getOrganizationChartLayout() et setOrganizationChartLayout(int) ont été ajoutées**
Les méthodes com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() et setOrganizationChartLayout(int) permettent d'obtenir ou de définir le type d'organigramme associé au nœud actuel.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);
```
### **La propriété IShape.getConnectionSiteCount() a été ajoutée**
La propriété com.aspose.slides.getConnectionSiteCount() renvoie le nombre de points de connexion sur la forme.
``` java
import com.aspose.slides.*;


 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

long wantedIndex = 6;

if (ellipse.getConnectionSiteCount() > wantedIndex) {

  connector.setStartShapeConnectionSiteIndex(wantedIndex);

}

input.save("output.pptx", SaveFormat.Pptx);

```
### **Modifications mineures**
Voici la liste des modifications mineures de l'API :

|Énumération com.aspose.slides.BevelColorMode |supprimée, énumération inutilisée |
| :- | :- |
|Méthode ThreeDFormatEffectiveData.getBevelColorMode() |supprimée, propriété inutilisée |
|Méthode com.aspose.slides.ChartSeriesGroup.getChart() |ajoutée |
|Héritage de IParagraphFormatEffectiveData à partir de ISlideComponent <br>Héritage de IThreeDFormat à partir de ISlideComponent |supprimé |
|Méthode com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Méthode com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Méthode com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Méthode com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Méthode com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Méthode com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |supprimée comme obsolète |