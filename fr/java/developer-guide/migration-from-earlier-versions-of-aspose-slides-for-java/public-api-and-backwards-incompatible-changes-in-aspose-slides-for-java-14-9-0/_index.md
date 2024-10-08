---
title: API Public et Changements Incompatibles Retrospectivement dans Aspose.Slides pour Java 14.9.0
type: docs
weight: 80
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [ajouts](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) de classes, méthodes, propriétés, etc., ainsi que toute nouvelle restriction et d'autres [changements](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) introduits avec l'API Aspose.Slides pour Java 14.9.0.

{{% /alert %}} 
## **Changements de l'API Public**
### **Méthodes Ajoutées pour Remplacer des Images dans PPImage, IPPImage**
Nouvelles méthodes ajoutées :

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Présentation présentation = new Présentation("presentation.pptx");

//La première manière

byte[] imageData = // ...

présentation.getImages().get_Item(0).replaceImage(imageData);

//La seconde manière

présentation.getImages().get_Item(1).replaceImage(

    présentation.getImages().get_Item(0));

présentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Méthodes Ajoutées pour Sauvegarder des Diapositives en Conservant les Numéros de Page**
Les méthodes suivantes ont été ajoutées :

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Ces méthodes permettent de sauvegarder des diapositives de présentation spécifiées au formats PDF, XPS, TIFF, HTML. Le tableau 'slides' permet de spécifier des numéros de page, en commençant par 1.

``` java

 save(string fname, int[] slides, SaveFormat format);

```




``` java

 Présentation présentation = new Présentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array de positions de diapositives

présentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **Ajout de la Valeur Enum SmartArtLayoutType.Custom**
Ce type de mise en page SmartArt représente un diagramme avec un modèle personnalisé. Les diagrammes personnalisés ne peuvent être chargés que depuis un fichier de présentation et ne peuvent pas être créés via la méthode ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Ajout de la Classe SmartArtShape et de l'Interface ISmartArtShape**
La classe Aspose.Slides.SmartArt.SmartArtShape (et son interface Aspose.Slides.SmartArt.ISmartArtShape) ajoute un accès à des formes individuelles à l'intérieur du diagramme SmartArt. SmartArtShape peut être utilisé pour changer FillFormat, LineFormat, ajouter des Hyperliens, etc.

{{% alert color="primary" %}} 

SmartArtShape ne supporte pas les propriétés IShape RawFrame, Frame, Rotation, X, Y, Width, Height et lance une System.NotSupportedException lors de l'accès à ces propriétés.

{{% /alert %}} 

Exemple d'utilisation :

``` java

 Présentation pres = new Présentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Ajout de la classe SmartArtShapeCollection, de l'interface ISmartArtShapeCollection et de la méthode ISmartArtNode.getShapes()**
La classe Aspose.Slides.SmartArt.SmartArtShapeCollection (et son interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) additionne l'accès à des formes individuelles à l'intérieur du diagramme SmartArt. La collection contient des formes associées à SmartArtNode. La propriété SmartArtNode.Shapes retourne des collections de toutes les formes associées au nœud.

{{% alert color="primary" %}} 

Selon le SmartArtLayoutType, une SmartArtShape peut être partagée entre plusieurs nœuds.

{{% /alert %}} 

﻿

``` java

 Présentation pres = new Présentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```