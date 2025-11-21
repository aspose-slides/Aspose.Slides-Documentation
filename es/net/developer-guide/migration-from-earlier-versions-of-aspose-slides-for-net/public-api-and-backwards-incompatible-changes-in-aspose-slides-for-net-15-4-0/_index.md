---
title: API pública y cambios incompatibles con versiones anteriores en Aspose.Slides para .NET 15.4.0
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
description: "Revise las actualizaciones de la API pública y los cambios críticos en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página lista todos los [agregados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) clases, métodos, propiedades y demás, y otros cambios introducidos con la API de Aspose.Slides para .NET 15.4.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **Se ha añadido el enum OrganizationChartLayoutType**
El enum Aspose.Slides.SmartArt.OrganizationChartLayoutType representa el tipo de formato de los nodos hijo en un organigrama.
#### **Se ha añadido el método IBulletFormat.ApplyDefaultParagraphIndentsShifts**
El método Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts establece desplazamientos predeterminados distintos de cero para la sangría de párrafo y el margen izquierdo cuando los viñetas están habilitados (como hace PowerPoint al habilitar viñetas/numeración de párrafo). Si los viñetas están deshabilitados, simplemente restablece la sangría de párrafo y el margen izquierdo (como hace PowerPoint al deshabilitar viñetas/numeración de párrafo).

See examples [here](/slides/es/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Se ha añadido el método IConnector.Reroute**
El método Aspose.Slides.IConnector.Reroute redirige el conector para que tome la ruta más corta posible entre las formas que conecta. Para ello, el método Reroute() puede cambiar los índices StartShapeConnectionSiteIndex y EndShapeConnectionSiteIndex.

``` csharp

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
#### **Se ha añadido el método IPresentation.GetSlideById**
El método Aspose.Slides.IPresentation.GetSlideById(System.UInt32) devuelve una Slide, MasterSlide o LayoutSlide mediante el Id de la diapositiva.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Se ha añadido la propiedad IShape.ConnectionSiteCount**
La propiedad Aspose.Slides.IShape.ConnectionSiteCount devuelve el número de puntos de conexión en la forma.

``` csharp

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
#### **Se ha añadido la propiedad ISmartArt.IsReversed**
La propiedad Aspose.Slides.SmartArt.ISmartArt.IsReversed permite obtener o establecer el estado del diagrama SmartArt respecto a (izquierda a derecha) LTR o (derecha a izquierda) RTL, si el diagrama admite la inversión.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Se ha añadido la propiedad ISmartArt.Nodes**
La propiedad Aspose.Slides.SmartArt.ISmartArt.Nodes devuelve la colección de nodos raíz en el objeto SmartArt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // select second root node

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Se ha añadido la propiedad ISmartArtNode.IsHidden**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.IsHidden devuelve true si este nodo es un nodo oculto en el modelo de datos.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //returns true

  if(hidden)

  {

    //do some actions or notifications

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Se ha añadido la propiedad ISmartArtNode.OrganizationChartLayout**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout permite obtener o establecer el tipo de organigrama asociado con el nodo actual.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Se ha añadido el método set para la propiedad ISmartArt.Layout**
Se ha añadido el método set para la propiedad Aspose.Slides.SmartArt.ISmartArt.Layout. Permite cambiar el tipo de diseño de un diagrama existente.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Cambios menores en la API**
**Esta es la lista de cambios menores en la API:**

|Enum Aspose.Slides.BevelColorMode |eliminado, enum no usado |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |eliminado, propiedad no usada |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |agregado |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |eliminado |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |eliminado como obsoleto |