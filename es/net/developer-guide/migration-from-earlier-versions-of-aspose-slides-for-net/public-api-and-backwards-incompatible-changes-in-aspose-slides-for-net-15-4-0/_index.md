---
title: Cambios de API pública e incompatibles hacia atrás en Aspose.Slides para .NET 15.4.0
linktitle: Aspose.Slides para .NET 15.4.0
type: docs
weight: 150
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- migración
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Revisa las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas tus soluciones de presentación PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las clases, métodos, propiedades, etc. [añadidos](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) y otros cambios introducidos con la API de Aspose.Slides for .NET 15.4.0.

{{% /alert %}} 
## **Cambios de la API pública**
#### **Enum OrganizationChartLayoutType se ha añadido**
El enum Aspose.Slides.SmartArt.OrganizationChartLayoutType representa el tipo de formato de los nodos hijos en un organigrama.
#### **Método IBulletFormat.ApplyDefaultParagraphIndentsShifts se ha añadido**
El método Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts establece desplazamientos predeterminados diferentes de cero para la sangría de párrafo y el margen izquierdo cuando las viñetas están habilitadas (como hace PowerPoint al activar viñetas/numeración de párrafo). Si las viñetas están deshabilitadas, simplemente restablece la sangría de párrafo y el margen izquierdo (como hace PowerPoint al desactivar viñetas/numeración de párrafo).

Ver ejemplos [aquí](/slides/es/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Método IConnector.Reroute se ha añadido**
El método Aspose.Slides.IConnector.Reroute redirige el conector para que tome la ruta más corta posible entre las formas que conecta. Para ello, el método Reroute() puede cambiar los índices StartShapeConnectionSiteIndex y EndShapeConnectionSiteIndex.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  connector.Reroute();

  input.Save("output.pptx", SaveFormat.Pptx);

}
``` 
#### **Método IPresentation.GetSlideById se ha añadido**
El método Aspose.Slides.IPresentation.GetSlideById(System.UInt32) devuelve una Slide, MasterSlide o LayoutSlide mediante el ID de la diapositiva.

``` csharp
using System.Diagnostics;
using Aspose.Slides;


 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}
``` 
#### **Propiedad IShape.ConnectionSiteCount se ha añadido**
La propiedad Aspose.Slides.IShape.ConnectionSiteCount devuelve el número de puntos de conexión en la forma.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}
``` 
#### **Propiedad ISmartArt.IsReversed se ha añadido**
La propiedad Aspose.Slides.SmartArt.ISmartArt.IsReversed permite obtener o establecer el estado del diagrama SmartArt respecto a (de izquierda a derecha) LTR o (de derecha a izquierda) RTL, si el diagrama admite inversión.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Propiedad ISmartArt.Nodes se ha añadido**
La propiedad Aspose.Slides.SmartArt.ISmartArt.Nodes devuelve la colección de nodos raíz en el objeto SmartArt.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // seleccionar el segundo nodo raíz

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Propiedad ISmartArtNode.IsHidden se ha añadido**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.IsHidden devuelve true si este nodo está oculto en el modelo de datos.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //devuelve true

  if(hidden)

  {

    //realizar algunas acciones o notificaciones

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Propiedad ISmartArtNode.OrganizationChartLayout se ha añadido**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout permite obtener o establecer el tipo de organigrama asociado al nodo actual.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Método set para la propiedad ISmartArt.Layout se ha añadido**
El método set para la propiedad Aspose.Slides.SmartArt.ISmartArt.Layout se ha añadido. Permite cambiar el tipo de diseño de un diagrama existente.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Cambios menores de la API**
**Esta es la lista de cambios menores de la API:**

|Enum Aspose.Slides.BevelColorMode |eliminado, enum sin usar |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |eliminado, propiedad sin usar |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |añadido |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |eliminado |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |eliminado como obsoleto |