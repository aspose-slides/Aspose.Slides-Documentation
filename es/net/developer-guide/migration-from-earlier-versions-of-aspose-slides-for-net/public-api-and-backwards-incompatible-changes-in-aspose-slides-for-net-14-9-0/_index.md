---
title: Cambios en la API pública e incompatibles hacia atrás en Aspose.Slides para .NET 14.9.0
linktitle: Aspose.Slides para .NET 14.9.0
type: docs
weight: 110
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
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
description: "Revise las actualizaciones de la API pública y los cambios incompatibles en Aspose.Slides para .NET para migrar sin problemas sus soluciones de presentaciones PowerPoint PPT, PPTX y ODP."
---
{{% alert color="info" %}} 

Esta página enumera todas las clases, métodos, propiedades, etc. [añadidos](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/), y otros cambios introducidos con la API de Aspose.Slides for .NET 14.9.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **Herencia de las interfaces ICollection e IEnumerable genérica añadida a ISmartArtNodeCollection**
La clase Aspose.Slides.SmartArt.SmartArtNodeCollection (y la interfaz relacionada Aspose.Slides.SmartArt.ISmartArtNodeCollection) heredan la interfaz genérica IEnumerable<ISmartArtNode> y la interfaz ICollection.
#### **Valor de enumeración SmartArtLayoutType.Custom añadido**
El tipo de diseño SmartArt personalizado representa un diagrama con una plantilla personalizada. Los diagramas personalizados solo pueden cargarse desde un archivo de presentación y no pueden crearse mediante el método ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Clase SmartArtShape e interfaz ISmartArtShape añadidas**
La clase Aspose.Slides.SmartArt.SmartArtShape (y su interfaz Aspose.Slides.SmartArt.ISmartArtShape) dan acceso a las formas individuales en un diagrama SmartArt. SmartArtShape puede usarse para cambiar FillFormat, LineFormat, añadir Hipervínculos y otras tareas.

{{% alert color="info" %}} 

**Nota**: SmartArtShape no admite las propiedades de IShape RawFrame, Frame, Rotation, X, Y, Width, Height y lanza una System.NotSupportedException al intentar acceder a ellas.

Ejemplo de uso:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **Clase SmartArtShapeCollection, interfaz ISmartArtShapeCollection y propiedad ISmartArtNode.Shapes añadidas**
La clase Aspose.Slides.SmartArt.SmartArtShapeCollection (y su interfaz Aspose.Slides.SmartArt.ISmartArtShapeCollection) dan acceso a las formas individuales en un diagrama SmartArt. La colección contiene formas asociadas a SmartArtNode. La propiedad SmartArtNode.Shapes devuelve colecciones de todas las formas asociadas al nodo.

{{% alert color="info" %}} 

**Nota**: dependiendo del SmartArtLayoutType, un SmartArtShape puede ser compartido entre varios nodos.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (ISmartArtShape shape in node.Shapes)
  {
    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;
  }

  pres.Save("out.pptx", SaveFormat.Pptx);
}
``` 

{{% /alert %}} 
#### **Métodos para guardar diapositivas conservando los números de página añadidos**
Se han añadido los siguientes métodos:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Estos métodos permiten a los desarrolladores guardar diapositivas específicas de la presentación en formatos PDF, XPS, TIFF, HTML. La matriz 'slides' se utiliza para especificar los números de página, comenzando desde 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    int[] slides = new int[] { 2, 3, 5 }; //Matriz de posiciones de diapositivas

    presentation.Save("output.pdf", slides, SaveFormat.Pdf);
}
``` 
#### **Métodos para reemplazar imágenes añadidos a PPImage, IPPImage**
Nuevos métodos añadidos:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("presentation.pptx"))
{
    //Primer método

    byte[] data = File.ReadAllBytes("image0.jpeg");

    IPPImage oldImage = presentation.Images[0];

    oldImage.ReplaceImage(data);

    //Segundo método

    IImage newImage = Images.FromFile("image1.png");

    oldImage = presentation.Images[1];

    oldImage.ReplaceImage(newImage);

    //Tercer método

    oldImage = presentation.Images[2];

    oldImage.ReplaceImage(presentation.Images[3]);

    presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```