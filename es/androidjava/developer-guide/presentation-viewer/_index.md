---
title: Visor de Presentaciones
type: docs
weight: 50
url: /androidjava/presentation-viewer/
keywords: "Visor de PPT de PowerPoint"
description: "Visor de PPT de PowerPoint en Java"
---

{{% alert color="primary" %}} 

Aspose.Slides para Android a través de Java se utiliza para crear archivos de presentación, completos con diapositivas. Estas diapositivas se pueden visualizar abriendo presentaciones con Microsoft PowerPoint. Pero a veces, los desarrolladores también pueden necesitar ver diapositivas como imágenes en su visor de imágenes favorito o crear su propio visor de presentaciones. En tales casos, Aspose.Slides para Android a través de Java te permite exportar una diapositiva individual a una imagen. Este artículo describe cómo hacerlo.

{{% /alert %}} 

## **Ejemplo en Vivo**
Puedes probar la aplicación gratuita [**Visor de Aspose.Slides**](https://products.aspose.app/slides/viewer/) para ver qué puedes implementar con la API de Aspose.Slides:

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **Generar Imagen SVG desde Diapositiva**
Para generar una imagen SVG desde cualquier diapositiva deseada con Aspose.Slides para Android a través de Java, sigue los pasos a continuación:

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Obtén la referencia de la diapositiva deseada utilizando su ID o índice.
- Obtén la imagen SVG en un flujo de memoria.
- Guarda el flujo de memoria en un archivo.

```java
// Instanciar una clase Presentation que representa el archivo de presentación
Presentation pres = new Presentation("CreateSlidesSVGImage.pptx");
try {
    // Acceder a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Crear un objeto de flujo de memoria
    FileOutputStream svgStream = new FileOutputStream("Aspose_out.svg");

    // Generar imagen SVG de la diapositiva y guardarla en el flujo de memoria
    sld.writeAsSvg(svgStream);

    svgStream.close();
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Generar SVG con ID de Forma Personalizados**
Aspose.Slides para Android a través de Java se puede utilizar para generar [SVG](https://docs.fileformat.com/page-description-language/svg/) desde una diapositiva con ID de forma personalizados. Para eso, usa la propiedad ID de [ISvgShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISvgShape), que representa el ID personalizado de las formas en el SVG generado. CustomSvgShapeFormattingController se puede utilizar para establecer el ID de forma.

```java
Presentation pres = new Presentation("pptxFileName.pptx");
try {
    FileOutputStream stream = new FileOutputStream("Aspose_out.svg");
    try {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

        pres.getSlides().get_Item(0).writeAsSvg(stream, svgOptions);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    pres.dispose();
}
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }
    
    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Crear Imagen de Miniatura de Diapositivas**
Aspose.Slides para Android a través de Java te ayuda a generar imágenes en miniatura de las diapositivas. Para generar la miniatura de cualquier diapositiva deseada utilizando Aspose.Slides para Android a través de Java:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
1. Obtén la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtén la imagen en miniatura de la diapositiva referenciada a una escala específica.
1. Guarda la imagen en miniatura en cualquier formato de imagen deseado.

```java
// Instanciar una clase Presentation que representa el archivo de presentación
Presentation pres = new Presentation("ThumbnailFromSlide.pptx");
try {
    // Acceder a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Crear una imagen a escala completa
    IImage slideImage = sld.getImage(1f, 1f);

    // Guardar la imagen en el disco en formato JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **Crear Miniatura con Dimensiones Definidas por el Usuario**

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
1. Obtén la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtén la imagen en miniatura de la diapositiva referenciada a una escala específica.
1. Guarda la imagen en miniatura en cualquier formato de imagen deseado.

```java
// Instanciar una clase Presentation que representa el archivo de presentación
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // Acceder a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Dimensión definida por el usuario
    int desiredX = 1200;
    int desiredY = 800;

    // Obtener valor escalado de X y Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;
    
    // Crear una imagen a escala completa
    IImage slideImage = sld.getImage(ScaleX, ScaleY);

    // Guardar la imagen en el disco en formato JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```

## **Crear Miniatura desde Diapositiva en Vista de Notas**
Para generar la miniatura de cualquier diapositiva deseada en Vista de Notas utilizando Aspose.Slides para Android a través de Java:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) clase.
1. Obtén la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtén la imagen en miniatura de la diapositiva referenciada a una escala específica en vista de Notas.
1. Guarda la imagen en miniatura en cualquier formato de imagen deseado.

El fragmento de código a continuación produce una miniatura de la primera diapositiva de una presentación en Vista de Notas.

```java
// Instanciar una clase Presentation que representa el archivo de presentación
Presentation pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
try {
    // Acceder a la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Dimensión definida por el usuario
    int desiredX = 1200;
    int desiredY = 800;

    // Obtener valor escalado de X y Y
    float ScaleX = (float)(1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float)(1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    RenderingOptions opts = new RenderingOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);
    
    // Crear una imagen a escala completa
    IImage slideImage = sld.getImage(opts, ScaleX, ScaleY);

    // Guardar la imagen en el disco en formato JPEG
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    pres.dispose();
}
```