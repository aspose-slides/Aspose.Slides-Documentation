---
title: API publique et changements incompatibles avec les versions antérieures dans Aspose.Slides pour Java 14.9.0
linktitle: Aspose.Slides pour Java 14.9.0
type: docs
weight: 80
url: /fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
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
description: "Examinez les mises à jour de l'API publique et les changements majeurs dans Aspose.Slides pour Java afin de migrer en douceur vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---
{{% alert color="info" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) et les nouvelles restrictions ainsi que les autres [modifications](/slides/fr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) introduites avec l'API Aspose.Slides for Java 14.9.0.

{{% /alert %}} 
## **Modifications de l'API publique**
### **Méthodes ajoutées pour remplacer Image par PPImage, IPPImage**
Nouvelles méthodes ajoutées :

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // La première façon
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // La deuxième façon
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Méthodes ajoutées pour enregistrer les diapositives en conservant les numéros de page**
Les méthodes suivantes ont été ajoutées :

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Ces méthodes permettent d'enregistrer des diapositives de la présentation spécifiées au format PDF, XPS, TIFF, HTML. Le tableau 'slides' permet de spécifier les numéros de page, à partir de 1.

``` java
// Surcharges ajoutées à IPresentation (les valeurs de SaveFormat sont des constantes int en Java):
//
// void save(String fname, int[] slides, int format);
// void save(String fname, int[] slides, int format, ISaveOptions options);
// void save(OutputStream stream, int[] slides, int format);
// void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // Tableau des positions des diapositives

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Ajout de la valeur d'énumération SmartArtLayoutType.Custom**
Ce type de disposition SmartArt représente un diagramme avec un modèle personnalisé. Les diagrammes personnalisés ne peuvent être chargés qu'à partir d'un fichier de présentation et ne peuvent pas être créés via la méthode ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)

### **Ajout de la classe SmartArtShape et de l'interface ISmartArtShape**
La classe Aspose.Slides.SmartArt.SmartArtShape (et son interface Aspose.Slides.SmartArt.ISmartArtShape) donne accès aux formes individuelles à l'intérieur d'un diagramme SmartArt. SmartArtShape peut être utilisé pour modifier FillFormat, LineFormat, ajouter des Hyperliens, etc.

{{% alert color="info" %}} 

SmartArtShape ne prend pas en charge les propriétés IShape RawFrame, Frame, Rotation, X, Y, Width, Height et lance System.NotSupportedException lorsqu'on tente d'y accéder.

{{% /alert %}} 

Exemple d'utilisation :

``` java
import com.aspose.slides.*;
import java.awt.Color;


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
### **Ajout de la classe SmartArtShapeCollection, de l'interface ISmartArtShapeCollection et de la méthode ISmartArtNode.getShapes()**
La classe Aspose.Slides.SmartArt.SmartArtShapeCollection (et son interface Aspose.Slides.SmartArt.ISmartArtShapeCollection) donne accès aux formes individuelles à l'intérieur d'un diagramme SmartArt. La collection contient les formes associées à SmartArtNode. La propriété SmartArtNode.Shapes renvoie les collections de toutes les formes associées au nœud.

{{% alert color="info" %}} 

Selon le SmartArtLayoutType, une SmartArtShape peut être partagée entre plusieurs nœuds.

{{% /alert %}} 

``` java
import com.aspose.slides.*;
import java.awt.Color;


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