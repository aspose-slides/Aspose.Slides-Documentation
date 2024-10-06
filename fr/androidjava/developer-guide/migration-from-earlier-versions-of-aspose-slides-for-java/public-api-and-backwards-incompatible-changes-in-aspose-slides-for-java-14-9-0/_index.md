---
title: API Public et Changements Incompatibles dans Aspose.Slides pour Java 14.9.0
type: docs
weight: 80
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les [classes ajoutées](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/), méthodes, propriétés, etc., ainsi que toutes les nouvelles restrictions et autres [changements](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) introduits avec l'API Aspose.Slides pour Java 14.9.0.

{{% /alert %}} 
## **Changements de l'API Publique**
### **Méthodes Ajoutées pour Remplacer l'Image à PPImage, IPPImage**
Nouvelles méthodes ajoutées :

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//La première méthode

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//La deuxième méthode

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Méthodes Ajoutées pour Sauvegarder les Diapositives en Conservant les Numéros de Page**
Les méthodes suivantes ont été ajoutées :

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Ces méthodes permettent de sauvegarder les diapositives spécifiées d'une présentation au format PDF, XPS, TIFF, HTML. Le tableau 'slides' permet de spécifier les numéros de page, en commençant à 1.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Tableau des positions de diapositives

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **Ajout de la Valeur Enum SmartArtLayoutType.Custom**
Ce type de mise en page SmartArt représente un diagramme avec un modèle personnalisé. Les diagrammes personnalisés ne peuvent être chargés qu'à partir d'un fichier de présentation et ne peuvent pas être créés via la méthode ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Ajout de la Classe SmartArtShape et de l'Interface ISmartArtShape**
La classe Aspose.Slides.SmartArt.SmartArtShape (et son interface Aspose.Slides.SmartArt.ISmartArtShape) ajoute l'accès à des formes individuelles à l'intérieur d'un diagramme SmartArt. SmartArtShape peut être utilisé pour changer le FillFormat, le LineFormat, ajouter des Hyperliens, etc.

{{% alert color="primary" %}} 

SmartArtShape ne prend pas en charge les propriétés IShape RawFrame, Frame, Rotation, X, Y, Width, Height et lance une System.NotSupportedException lors de l'accès à celles-ci.

{{% /alert %}} 

Exemple d'utilisation :

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **La classe SmartArtShapeCollection, l'interface ISmartArtShapeCollection et la méthode ISmartArtNode.getShapes() ont été ajoutées**
La classe Aspose.Slides.SmartArt.SmartArtShapeCollection (et son interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) ajoute l'accès à des formes individuelles à l'intérieur d'un diagramme SmartArt. La collection contient des formes associées à SmartArtNode. La propriété SmartArtNode.Shapes retourne des collections de toutes les formes associées au nœud.

{{% alert color="primary" %}} 

Selon le SmartArtLayoutType, une SmartArtShape peut être partagée entre plusieurs nœuds.

{{% /alert %}} 

﻿

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```