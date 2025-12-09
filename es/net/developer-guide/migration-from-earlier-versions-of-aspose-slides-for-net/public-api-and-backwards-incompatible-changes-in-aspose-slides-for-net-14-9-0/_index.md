---
title: Cambios de API pública y de incompatibilidad retroactiva en Aspose.Slides para .NET 14.9.0
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

{{% alert color="primary" %}} 

Esta página enumera todos los [added](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) o [removed](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) clases, métodos, propiedades, etc., y otros cambios introducidos con la API de Aspose.Slides para .NET 14.9.0.

{{% /alert %}} 
## **Cambios en la API pública**
#### **Herencia de las interfaces ICollection e IEnumerable genéricas añadida a ISmartArtNodeCollection**
La clase Aspose.Slides.SmartArt.SmartArtNodeCollection (y la interfaz relacionada Aspose.Slides.SmartArt.ISmartArtNodeCollection) heredan la interfaz genérica IEnumerable<ISmartArtNode> y la interfaz ICollection.
#### **Valor de enumeración SmartArtLayoutType.Custom añadido**
El tipo de diseño SmartArt Custom representa un diagrama con una plantilla personalizada. Los diagramas personalizados solo pueden cargarse desde un archivo de presentación y no pueden crearse mediante el método ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Clase SmartArtShape e interfaz ISmartArtShape añadidas**
La clase Aspose.Slides.SmartArt.SmartArtShape (y su interfaz Aspose.Slides.SmartArt.ISmartArtShape) brinda acceso a formas individuales en un diagrama SmartArt. SmartArtShape puede usarse para cambiar FillFormat, LineFormat, añadir Hipervínculos y otras tareas.

{{% alert color="primary" %}} 

**Nota**: SmartArtShape no admite las propiedades IShape RawFrame, Frame, Rotation, X, Y, Width, Height y lanza una System.NotSupportedException al intentar acceder a ellas.

Ejemplo de uso:

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Clase SmartArtShapeCollection, interfaz ISmartArtShapeCollection y propiedad ISmartArtNode.Shapes añadidas**
La clase Aspose.Slides.SmartArt.SmartArtShapeCollection (y su interfaz Aspose.Slides.SmartArt.ISmartArtShapeCollection) brindan acceso a formas individuales en un diagrama SmartArt. La colección contiene las formas asociadas con SmartArtNode. La propiedad SmartArtNode.Shapes devuelve colecciones de todas las formas asociadas al nodo.

{{% alert color="primary" %}} 

**Nota**: dependiendo del SmartArtLayoutType, una SmartArtShape puede compartirse entre varios nodos.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Métodos para guardar diapositivas con números de página añadidos**
Se han añadido los siguientes métodos:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Estos métodos permiten a los desarrolladores guardar diapositivas específicas de la presentación en formatos PDF, XPS, TIFF, HTML. El arreglo 'slides' se usa para especificar los números de página, comenzando desde 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Arreglo de posiciones de diapositivas

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Métodos para reemplazar imágenes añadidos a PPImage, IPPImage**
Nuevos métodos añadidos:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//Primer método

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//Segundo método

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//Tercer método

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```