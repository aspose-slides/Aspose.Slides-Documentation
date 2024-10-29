---
title: API Público y Cambios Incompatibles en Aspose.Slides para Java 15.4.0
type: docs
weight: 120
url: /es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las [clases añadidas](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/), métodos, propiedades, etc., cualquier nueva restricción y otros [cambios](/slides/es/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) introducidos con la API Aspose.Slides para Java 15.4.0.

{{% /alert %}} 
## **Cambios en la API Pública**
### **Se ha añadido el Enum OrganizationChartLayoutType**
El enum com.aspose.slides.OrganizationChartLayoutType representa el tipo de formato de los nodos hijos en un organigrama.
### **Se ha añadido el método IBulletFormat.applyDefaultParagraphIndentsShifts()**
El método com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts establece desplazamientos predeterminados distintos de cero para el sangrado y el margen izquierdo efectivos cuando se habilitan los viñetas (como lo hace PowerPoint si se habilitan las viñetas/numeración de párrafos en él). Si las viñetas están deshabilitadas, simplemente restablece el sangrado y el margen izquierdo del párrafo (como lo hace PowerPoint si se deshabilitan las viñetas/numeración de párrafos en él).
### **Se ha añadido el método IConnector.reroute()**
El método com.aspose.slides.IConnector.reroute() reorienta el conector para que tome la ruta más corta posible entre las formas que conecta. Para hacer esto, el método reroute() puede cambiar el StartShapeConnectionSiteIndex y el EndShapeConnectionSiteIndex.

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
### **Se ha añadido el método IPresentation.getSlideById(long)**
El método Aspose.Slides.IPresentation.getSlideById(int) devuelve un Slide, MasterSlide o LayoutSlide por id de slide.

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Se ha añadido el método ISmartArt.getNodes()**
El método com.aspose.slides.ISmartArt.getNodes() devuelve una colección de nodos raíz en un objeto SmartArt.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // seleccionar el segundo nodo raíz

node.getTextFrame().setText("Segundo nodo raíz");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Se ha añadido el método ISmartArt.setLayout(int)**
Se ha añadido el método para la propiedad com.aspose.slides.ISmartArt.setLayout(int). Permite cambiar el tipo de diseño de un diagrama existente.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Se ha añadido el método ISmartArtNode.isHidden()**
El método com.aspose.slides.ISmartArtNode.isHidden() devuelve verdadero si este nodo es un nodo oculto en el modelo de datos.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //devuelve verdadero

if(hidden) {

    //realizar algunas acciones o notificaciones

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Se han añadido los métodos ISmartArt.isReversed(), setReserved()**
La propiedad com.aspose.slides.ISmartArt.IsReversed permite obtener o establecer el estado del diagrama SmartArt con respecto a (de izquierda a derecha) LTR o (de derecha a izquierda) RTL, si el diagrama admite inversión.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Se han añadido los métodos ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)**
Los métodos com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) permiten obtener o establecer el tipo de organigrama asociado con el nodo actual.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Se ha añadido la propiedad IShape.getConnectionSiteCount()**
La propiedad com.aspose.slides.getConnectionSiteCount() devuelve el número de sitios de conexión en la forma.

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
### **Cambios Menores**
Esta es la lista de cambios menores en la API:

|Enum com.aspose.slides.BevelColorMode |eliminado, enum no utilizado |
| :- | :- |
|Método ThreeDFormatEffectiveData.getBevelColorMode() |eliminado, propiedad no utilizada |
|Método com.aspose.slides.ChartSeriesGroup.getChart() |añadido |
|Herencia de IParagraphFormatEffectiveData de ISlideComponent <br>Herencia de IThreeDFormat de ISlideComponent |eliminado |
|Método com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Método com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Método com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Método com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Método com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Método com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |eliminado por obsoleto |