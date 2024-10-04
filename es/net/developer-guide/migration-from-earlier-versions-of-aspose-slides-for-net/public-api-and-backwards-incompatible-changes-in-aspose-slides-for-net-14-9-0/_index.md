---
title: API Público y Cambios Incompatibles con Versiones Anteriores en Aspose.Slides para .NET 14.9.0
type: docs
weight: 110
url: /es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
---

{{% alert color="primary" %}} 

Esta página enumera todas las clases, métodos, propiedades, etc. [agregados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) o [eliminados](/slides/es/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) y otros cambios introducidos con la API de Aspose.Slides para .NET 14.9.0.

{{% /alert %}} 
## **Cambios en la API Pública**
#### **Herencia de ICollection y Interfaces Genéricas IEnumerable Añadidas a ISmartArtNodeCollection**
La clase Aspose.Slides.SmartArt.SmartArtNodeCollection (y la interfaz relacionada Aspose.Slides.SmartArt.ISmartArtNodeCollection) heredan de la interfaz genérica IEnumerable<ISmartArtNode> y de la interfaz ICollection.
#### **Valor de Enum SmartArtLayoutType.Custom Añadido**
El tipo de diseño SmartArt Custom representa un diagrama con una plantilla personalizada. Los diagramas personalizados solo se pueden cargar desde un archivo de presentación y no se pueden crear a través del método ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom).
#### **Clase SmartArtShape e Interfaz ISmartArtShape Añadidas**
La clase Aspose.Slides.SmartArt.SmartArtShape (y su interfaz Aspose.Slides.SmartArt.ISmartArtShape) dan acceso a formas individuales en un diagrama SmartArt. SmartArtShape se puede usar para cambiar FillFormat, LineFormat, agregar Hiperenlaces y otras tareas.

{{% alert color="primary" %}} 

**Nota**: SmartArtShape no soporta las propiedades IShape RawFrame, Frame, Rotation, X, Y, Width, Height y lanza una System.NotSupportedException al intentar acceder a ellas.

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
#### **Clase SmartArtShapeCollection, Interfaz ISmartArtShapeCollection y Propiedad ISmartArtNode.Shapes Añadidas**
La clase Aspose.Slides.SmartArt.SmartArtShapeCollection (y su interfaz Aspose.Slides.SmartArt.ISmartArtShapeCollection) añaden acceso a formas individuales en un diagrama SmartArt. La colección contiene formas asociadas con SmartArtNode. La propiedad SmartArtNode.Shapes devuelve colecciones de todas las formas asociadas con el nodo.

{{% alert color="primary" %}} 

**Nota**: dependiendo del SmartArtLayoutType, una SmartArtShape puede ser compartida entre varios nodos.

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
#### **Métodos para Guardar Diapositivas con Números de Página Añadidos**
Se han agregado los siguientes métodos:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Estos métodos permiten a los desarrolladores guardar diapositivas de presentación especificadas en formatos PDF, XPS, TIFF, HTML. El array 'slides' se usa para especificar los números de página, comenzando desde 1.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array de posiciones de diapositivas

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Métodos para Reemplazar Imágenes Añadidos a PPImage, IPPImage**
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