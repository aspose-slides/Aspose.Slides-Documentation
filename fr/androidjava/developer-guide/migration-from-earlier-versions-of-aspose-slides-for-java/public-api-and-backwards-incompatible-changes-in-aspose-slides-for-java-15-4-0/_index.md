---
title: API publique et changements incompatibles avec les versions précédentes dans Aspose.Slides pour Java 15.4.0
type: docs
weight: 120
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/), toutes nouvelles restrictions et autres [changements](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) introduits avec l'API Aspose.Slides pour Java 15.4.0.

{{% /alert %}} 
## **Changements de l'API publique**
### **L'énumération OrganizationChartLayoutType a été ajoutée**
L'énumération com.aspose.slides.OrganizationChartLayoutType représente le type de formatage des nœuds enfants dans un organigramme.
### **La méthode IBulletFormat.applyDefaultParagraphIndentsShifts() a été ajoutée**
La méthode com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts définit des décalages par défaut non nuls pour l'Indentation de paragraphe et la MargenGauche effectives lorsqu'on active les puces (comme PowerPoint le fait si les puces/numerotations de paragraphes sont activées). Si les puces sont désactivées, réinitialise simplement l'Indentation de paragraphe et la MargenGauche (comme PowerPoint le fait si les puces/numerotations de paragraphes sont désactivées).
### **La méthode IConnector.reroute() a été ajoutée**
La méthode com.aspose.slides.IConnector.reroute() redirige le connecteur de sorte qu'il prenne le chemin le plus court possible entre les formes qu'il connecte. Pour cela, la méthode reroute() peut modifier le StartShapeConnectionSiteIndex et EndShapeConnectionSiteIndex.

``` java

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
La méthode Aspose.Slides.IPresentation.getSlideById(int) retourne une diapositive, MasterSlide ou LayoutSlide par ID de diapositive.

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **La méthode ISmartArt.getNodes() a été ajoutée**
La méthode com.aspose.slides.ISmartArt.getNodes() retourne la collection de nœuds racines dans l'objet SmartArt.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // sélectionner le deuxième nœud racine

node.getTextFrame().setText("Deuxième nœud racine");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **La méthode ISmartArt.setLayout(int) a été ajoutée**
La méthode pour la propriété com.aspose.slides.ISmartArt.setLayout(int) a été ajoutée. Elle permet de changer le type de mise en page d'un diagramme existant.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **La méthode ISmartArtNode.isHidden() a été ajoutée**
La méthode com.aspose.slides.ISmartArtNode.isHidden() retourne vrai si ce nœud est un nœud caché dans le modèle de données.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //retourne vrai

if(hidden) {

    //effectuer certaines actions ou notifications

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Les méthodes ISmartArt.isReversed(), setReserved() ont été ajoutées**
La propriété com.aspose.slides.ISmartArt.IsReversed permet d'obtenir ou de définir l'état du diagramme SmartArt en ce qui concerne (gauche à droite) LTR ou (droite à gauche) RTL, si le diagramme prend en charge la réversibilité.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Les méthodes ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) ont été ajoutées**
Les méthodes com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) permettent d'obtenir ou de définir le type d'organigramme associé au nœud actuel.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **La propriété IShape.getConnectionSiteCount() a été ajoutée**
La propriété com.aspose.slides.getConnectionSiteCount() retourne le nombre de sites de connexion sur la forme.

``` java

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
### **Changements mineurs**
Voici la liste des changements mineurs de l'API :

|Énumération com.aspose.slides.BevelColorMode |supprimée, énumération inutilisée |
| :- | :- |
|Méthode ThreeDFormatEffectiveData.getBevelColorMode() |supprimée, propriété inutilisée |
|Méthode com.aspose.slides.ChartSeriesGroup.getChart() |ajoutée |
|Héritage de IParagraphFormatEffectiveData depuis ISlideComponent <br>Héritage de IThreeDFormat depuis ISlideComponent |supprimé |
|Méthode com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Méthode com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Méthode com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Méthode com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Méthode com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Méthode com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |supprimées en tant qu'obsolètes |