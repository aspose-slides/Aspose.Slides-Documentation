---
title: API pública y cambios incompatibles hacia atrás en Aspose.Slides para .NET 15.4.0
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
description: "Revisa las actualizaciones de la API pública y los cambios disruptivos en Aspose.Slides para .NET para migrar sin problemas tus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---

{{% alert color="primary" %}} 

Esta página lista todas las clases, métodos, propiedades y demás elementos [añadidos](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) y otros cambios introducidos con la API de Aspose.Slides for .NET 15.4.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **Enum OrganizationChartLayoutType ha sido añadido**
El enum Aspose.Slides.SmartArt.OrganizationChartLayoutType representa el tipo de formato de los nodos hijos en un organigrama.
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts ha sido añadido**
El método Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts establece desplazamientos predeterminados distintos de cero para la sangría y margen izquierdo efectivos del párrafo cuando los viñetas están habilitados (como hace PowerPoint al habilitar viñetas/numeración de párrafo). Si los viñetas están deshabilitados, simplemente restablece la sangría y el margen izquierdo del párrafo (como hace PowerPoint al desactivar viñetas/numeración de párrafo).

Ver ejemplos [aquí](/slides/es/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Method IConnector.Reroute ha sido añadido**
El método Aspose.Slides.IConnector.Reroute vuelve a enrutar el conector para que tome la ruta más corta posible entre las formas que conecta. Para ello, el método Reroute() puede cambiar los índices StartShapeConnectionSiteIndex y EndShapeConnectionSiteIndex.

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
#### **Method IPresentation.GetSlideById ha sido añadido**
El método Aspose.Slides.IPresentation.GetSlideById(System.UInt32) devuelve una Slide, MasterSlide o LayoutSlide según el ID de la diapositiva.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Property IShape.ConnectionSiteCount ha sido añadido**
La propiedad Aspose.Slides.IShape.ConnectionSiteCount devuelve el número de sitios de conexión en la forma.

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
#### **Property ISmartArt.IsReversed ha sido añadido**
La propiedad Aspose.Slides.SmartArt.ISmartArt.IsReversed permite obtener o establecer el estado del diagrama SmartArt con respecto a LTR (izquierda a derecha) o RTL (derecha a izquierda), si el diagrama admite inversión.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.Nodes ha sido añadido**
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
#### **Property ISmartArtNode.IsHidden ha sido añadido**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.IsHidden devuelve true si este nodo está oculto en el modelo de datos.

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
#### **Property ISmartArtNode.OrganizationChartLayout ha sido añadido**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout permite obtener o establecer el tipo de organigrama asociado al nodo actual.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Set method for property ISmartArt.Layout ha sido añadido**
El método set para la propiedad Aspose.Slides.SmartArt.ISmartArt.Layout ha sido añadido. Permite cambiar el tipo de diseño de un diagrama existente.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Minor API changes**
**Esta es la lista de cambios menores en la API:**

|Enum Aspose.Slides.BevelColorMode |eliminado, enum no usado |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |eliminado, propiedad no usada |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |añadido |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |eliminado |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |eliminado como obsoleto |