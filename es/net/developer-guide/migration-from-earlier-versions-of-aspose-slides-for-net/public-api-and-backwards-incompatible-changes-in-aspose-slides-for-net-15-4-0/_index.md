---
title: API Pública y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para .NET 15.4.0
type: docs
weight: 150
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
---

{{% alert color="primary" %}} 

Esta página lista todas las clases, métodos, propiedades, etc., [agregados](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) o [eliminados](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/), y otros cambios introducidos con la API de Aspose.Slides para .NET 15.4.0.

{{% /alert %}} 
## **Cambios en la API Pública**
#### **Se ha agregado el Enum OrganizationChartLayoutType**
El enum Aspose.Slides.SmartArt.OrganizationChartLayoutType representa el tipo de formato de los nodos secundarios en un organigrama.
#### **Se ha agregado el método IBulletFormat.ApplyDefaultParagraphIndentsShifts**
El método Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts establece desplazamientos predeterminados no nulos para el sangrado y el margen izquierdo efectivos cuando se habilitan viñetas (como lo hace PowerPoint si se habilitan las viñetas/numeración de párrafos en él). Si las viñetas están desactivadas, entonces simplemente restablece el sangrado y el margen izquierdo del párrafo (como lo hace PowerPoint si deshabilita las viñetas/numeración de párrafos en él).

Ver ejemplos [aquí](/slides/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Se ha agregado el método IConnector.Reroute**
El método Aspose.Slides.IConnector.Reroute redirige el conector de modo que tome el camino más corto posible entre las formas que conecta. Para hacer esto, el método Reroute() puede cambiar el StartShapeConnectionSiteIndex y EndShapeConnectionSiteIndex.

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
#### **Se ha agregado el método IPresentation.GetSlideById**
El método Aspose.Slides.IPresentation.GetSlideById(System.UInt32) devuelve una diapositiva, MasterSlide o LayoutSlide por ID de diapositiva.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Se ha agregado la propiedad IShape.ConnectionSiteCount**
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
#### **Se ha agregado la propiedad ISmartArt.IsReversed**
La propiedad Aspose.Slides.SmartArt.ISmartArt.IsReversed permite obtener o establecer el estado del diagrama SmartArt con respecto a (de izquierda a derecha) LTR o (de derecha a izquierda) RTL, si el diagrama admite reversión.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Se ha agregado la propiedad ISmartArt.Nodes**
La propiedad Aspose.Slides.SmartArt.ISmartArt.Nodes devuelve la colección de nodos raíz en el objeto SmartArt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // seleccionar el segundo nodo raíz

  node.TextFrame.Text = "Segundo nodo raíz";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Se ha agregado la propiedad ISmartArtNode.IsHidden**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.IsHidden devuelve verdadero si este nodo es un nodo oculto en el modelo de datos.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //devuelve verdadero

  if(hidden)

  {

    //realizar algunas acciones o notificaciones

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Se ha agregado la propiedad ISmartArtNode.OrganizationChartLayout**
La propiedad Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout permite obtener o establecer el tipo de organigrama asociado con el nodo actual.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Se ha agregado el método set para la propiedad ISmartArt.Layout**
Se ha agregado el método set para la propiedad Aspose.Slides.SmartArt.ISmartArt.Layout. Permite cambiar el tipo de diseño de un diagrama existente.

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

|Enum Aspose.Slides.BevelColorMode |eliminado, enum no utilizado |
| :- | :- |
|Propiedad ThreeDFormatEffectiveData.BevelColorMode |eliminada, propiedad no utilizada |
|Propiedad Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Propiedad Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |agregada |
|Propiedad Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Herencia de IParagraphFormatEffectiveData de ISlideComponent <br>Propiedad Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Herencia de IThreeDFormat de ISlideComponent |eliminada |
|Propiedad Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Propiedad Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Propiedad Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Propiedad Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Propiedad Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Propiedad Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |eliminadas como obsoletas |