---
title: Visor de Presentaciones
type: docs
weight: 50
url: /es/net/presentation-viewer/
keywords: 
- ver presentación de PowerPoint
- ver ppt
- ver PPTX
- C#
- Csharp
- Aspose.Slides para .NET
description: "Ver presentación de PowerPoint en C# o .NET "
---



Aspose.Slides para .NET se utiliza para crear archivos de presentación, completos con diapositivas. Estas diapositivas pueden ser vistas abriendo presentaciones con Microsoft PowerPoint. Pero a veces, los desarrolladores también pueden necesitar ver diapositivas como imágenes en su visor de imágenes favorito o crear su propio visor de presentaciones. En tales casos, Aspose.Slides para .NET le permite exportar una diapositiva individual a una imagen. Este artículo describe cómo hacerlo. 
## **Ejemplo en Vivo**
Puede probar la aplicación gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) para ver lo que puede implementar con la API de Aspose.Slides:

![powerpoint-in-aspose-viewer](powerpoint-in-aspose-viewer.png)

## **Generar Imagen SVG desde Diapositiva**
Para generar una imagen SVG desde cualquier diapositiva deseada con Aspose.Slides.PPTX para .NET, siga los pasos a continuación:

- Cree una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
- Obtenga la referencia de la diapositiva deseada utilizando su ID o índice.
- Obtenga la imagen SVG en un flujo de memoria.
- Guarde el flujo de memoria en un archivo.

```c#
// Instanciar una clase Presentation que representa el archivo de presentación

using (Presentation pres = new Presentation("CreateSlidesSVGImage.pptx"))
{

    // Acceder a la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Crear un objeto de flujo de memoria
    MemoryStream SvgStream = new MemoryStream();

    // Generar imagen SVG de la diapositiva y guardar en el flujo de memoria
    sld.WriteAsSvg(SvgStream);
    SvgStream.Position = 0;

    // Guardar el flujo de memoria en un archivo
    using (Stream fileStream = System.IO.File.OpenWrite("Aspose_out.svg"))
    {
        byte[] buffer = new byte[8 * 1024];
        int len;
        while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
        {
            fileStream.Write(buffer, 0, len);
        }

    }
    SvgStream.Close();
}
```


## **Generar SVG con IDs de Forma Personalizados**
Aspose.Slides para .NET se puede utilizar para generar [SVG ](https://docs.fileformat.com/page-description-language/svg/)desde diapositivas con un ID de forma personalizado. Para eso, use la propiedad ID de [ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape), que representa el ID personalizado de las formas en el SVG generado. CustomSvgShapeFormattingController se puede usar para establecer el ID de forma.

```c#
using (Presentation pres = new Presentation("pptxFileName.pptx"))
{
    using (FileStream stream = new FileStream(outputPath, FileMode.OpenOrCreate))
    {
        SVGOptions svgOptions = new SVGOptions
        {
            ShapeFormattingController = new CustomSvgShapeFormattingController()
        };

        pres.Slides[0].WriteAsSvg(stream, svgOptions);
    }
}
```



```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
	private int m_shapeIndex;
	
	public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
	{
		m_shapeIndex = shapeStartIndex;
	}

	public void FormatShape(ISvgShape svgShape, IShape shape)
	{
		svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
	}
}
```


## **Crear Imagen Miniatura de Diapositivas**
Aspose.Slides para .NET le ayuda a generar imágenes en miniatura de las diapositivas. Para generar la miniatura de cualquier diapositiva deseada utilizando Aspose.Slides para .NET:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
1. Obtenga la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada en una escala especificada.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

```c#
// Instanciar una clase Presentation que representa el archivo de presentación
using (Presentation pres = new Presentation("ThumbnailFromSlide.pptx"))
{
    // Acceder a la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Crear una imagen a escala completa
    using (IImage image = sld.GetImage(1f, 1f))
    {
        // Guardar la imagen en disco en formato JPEG
        image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    }
}
```


## **Crear Miniatura con Dimensiones Definidas por el Usuario**
1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
1. Obtenga la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada en una escala especificada.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

```c#
// Instanciar una clase Presentation que representa el archivo de presentación
using (Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx"))
{

    // Acceder a la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Dimensiones definidas por el usuario
    int desiredX = 1200;
    int desiredY = 800;

    // Obtener el valor escalado de X e Y
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;


    // Crear una imagen a escala completa
    using (IImage image = sld.GetImage(ScaleX, ScaleY))
    {
        // Guardar la imagen en disco en formato JPEG
        image.Save("Thumbnail2_out.jpg", ImageFormat.Jpeg);
    }
}
```


## **Crear Miniatura desde Diapositiva en Vista de Diapositivas de Notas**
Para generar la miniatura de cualquier diapositiva deseada en Vista de Diapositivas de Notas utilizando Aspose.Slides para .NET:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) clase.
1. Obtenga la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada en una escala especificada en vista de Diapositivas de Notas.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

El fragmento de código a continuación produce una miniatura de la primera diapositiva de una presentación en Vista de Diapositivas de Notas.

```c#
// Instanciar una clase Presentation que representa el archivo de presentación
using (Presentation pres = new Presentation("ThumbnailFromSlideInNotes.pptx"))
{
    // Acceder a la primera diapositiva
    ISlide sld = pres.Slides[0];

    // Dimensiones definidas por el usuario
    int desiredX = 1200;
    int desiredY = 800;

    // Obtener el valor escalado de X e Y
    float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    // Crear una imagen a escala completa                
    using (IImage image = sld.GetImage(ScaleX, ScaleY))
    {
        // Guardar la imagen en disco en formato JPEG
        image.Save("Notes_tnail_out.jpg", ImageFormat.Jpeg);
    }
}
```