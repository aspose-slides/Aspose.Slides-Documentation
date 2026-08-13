---
title: API público y cambios incompatibles retroactivos en Aspose.Slides para Java 15.4.0
linktitle: Aspose.Slides para Java 15.4.0
type: docs
weight: 120
url: /es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para Java para migrar sin problemas sus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las [añadidas](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) clases, métodos, propiedades, etc., cualquier nueva restricción y otros [cambios](/slides/es/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) introducidos con la API de Aspose.Slides for Java 15.4.0.

{{% /alert %}} 
## **Cambios en la API pública**
### **Se ha añadido el enum OrganizationChartLayoutType**
El enum com.aspose.slides.OrganizationChartLayoutType representa el tipo de formato de los nodos hijos en un organigrama.
### **Se ha añadido el método IBulletFormat.applyDefaultParagraphIndentsShifts()**
El método com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts establece desplazamientos predeterminados distintos de cero para la sangría de párrafo y el margen izquierdo cuando las viñetas están activadas (como hace PowerPoint al habilitar viñetas/numeración de párrafo). Si las viñetas están desactivadas, simplemente restablece la sangría del párrafo y el margen izquierdo (como hace PowerPoint al desactivar viñetas/numeración de párrafo).
### **Se ha añadido el método IConnector.reroute()**
El método com.aspose.slides.IConnector.reroute() redirige el conector para que tome la ruta más corta posible entre las formas que conecta. Para ello, el método reroute() puede cambiar los índices StartShapeConnectionSiteIndex y EndShapeConnectionSiteIndex.

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
### **Se ha añadido el método IPresentation.getSlideById(long)**
El método Aspose.Slides.IPresentation.getSlideById(long) devuelve una Slide, MasterSlide o LayoutSlide según el Id de la diapositiva.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Se ha añadido el método ISmartArt.getNodes()**
El método com.aspose.slides.ISmartArt.getNodes() devuelve una colección de nodos raíz en el objeto SmartArt.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // seleccionar el segundo nodo raíz

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Se ha añadido el método ISmartArt.setLayout(int)**
Se ha añadido el método para la propiedad com.aspose.slides.ISmartArt.setLayout(int). Permite cambiar el tipo de diseño de un diagrama existente.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Se ha añadido el método ISmartArtNode.isHidden()**
El método com.aspose.slides.ISmartArtNode.isHidden() devuelve true si este nodo es un nodo oculto en el modelo de datos.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //devuelve true

if(hidden) {

    //realizar algunas acciones o notificaciones

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Se han añadido los métodos ISmartArt.isReversed() y setReversed()**
La propiedad com.aspose.slides.ISmartArt.IsReversed permite obtener o establecer el estado del diagrama SmartArt con respecto a (izquierda a derecha) LTR o (derecha a izquierda) RTL, si el diagrama admite inversión.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Se han añadido los métodos ISmartArtNode.getOrganizationChartLayout() y setOrganizationChartLayout(int)**
Los métodos com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() y setOrganizationChartLayout(int) permiten obtener o establecer el tipo de organigrama asociado al nodo actual.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Se ha añadido la propiedad IShape.getConnectionSiteCount()**
La propiedad com.aspose.slides.getConnectionSiteCount() devuelve el número de puntos de conexión en la forma.

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
### **Cambios menores**
Esta es la lista de cambios menores de la API:

|Enum com.aspose.slides.BevelColorMode|eliminado, enum sin usar|
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode()|eliminado, propiedad sin usar|
|Method com.aspose.slides.ChartSeriesGroup.getChart()|añadido|
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent|eliminado|
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle()|eliminado como obsoleto|