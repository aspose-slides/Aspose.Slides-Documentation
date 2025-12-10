---
title: Crear un visor de presentaciones en Java
linktitle: Visor de presentaciones
type: docs
weight: 50
url: /es/java/presentation-viewer/
keywords:
- ver presentación
- visor de presentaciones
- crear visor de presentaciones
- ver PPT
- ver PPTX
- ver ODP
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Crear un visor de presentaciones personalizado en Java usando Aspose.Slides. Mostrar fácilmente archivos PowerPoint y OpenDocument sin Microsoft PowerPoint."
---

Aspose.Slides for Java se usa para crear archivos de presentación con diapositivas. Estas diapositivas pueden verse al abrir las presentaciones en Microsoft PowerPoint, por ejemplo. Sin embargo, a veces los desarrolladores pueden necesitar ver las diapositivas como imágenes en su visor de imágenes preferido o crear su propio visor de presentaciones. En esos casos, Aspose.Slides permite exportar una diapositiva individual como imagen. Este artículo describe cómo hacerlo.

## **Generar una imagen SVG a partir de una diapositiva**

Para generar una imagen SVG a partir de una diapositiva de presentación con Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) clase.
1. Obtenga la referencia de la diapositiva por su índice.
1. Abra un flujo de archivo.
1. Guarde la diapositiva como una imagen SVG en el flujo de archivo.
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **Generar un SVG con un ID de forma personalizado**

Aspose.Slides puede usarse para generar un [SVG](https://docs.fileformat.com/page-description-language/svg/) a partir de una diapositiva con un ID de forma personalizado. Para ello, utilice el método `setId` de [ISvgShape](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/). `CustomSvgShapeFormattingController` puede usarse para establecer el ID de la forma.
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```

```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```


## **Crear una miniatura de diapositiva**

Aspose.Slides le ayuda a generar miniaturas de diapositivas. Para generar una miniatura de una diapositiva usando Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) clase.
1. Obtenga la referencia de la diapositiva por su índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada a una escala definida.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.
```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Crear una miniatura de diapositiva con dimensiones definidas por el usuario**

Para crear una imagen en miniatura de una diapositiva con dimensiones definidas por el usuario, siga los pasos a continuación:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) clase.
1. Obtenga la referencia de la diapositiva por su índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con las dimensiones definidas.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.
```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Crear una miniatura de diapositiva con notas del orador**

Para generar la miniatura de una diapositiva con notas del orador usando Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) clase.
1. Utilice el método `RenderingOptions.setSlidesLayoutOptions` para establecer la posición de las notas del orador.
1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) clase.
1. Obtenga la referencia de la diapositiva por su índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con las opciones de renderizado.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.
```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```


## **Ejemplo en vivo**

Puede probar la aplicación gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) para ver lo que puede implementar con la API de Aspose.Slides:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **FAQ**

**¿Puedo incrustar un visor de presentaciones en una aplicación web?**

Sí. Puede usar Aspose.Slides del lado del servidor para renderizar diapositivas como imágenes o HTML y mostrarlas en el navegador. Las funciones de navegación y zoom pueden implementarse con JavaScript para una experiencia interactiva.

**¿Cuál es la mejor manera de mostrar diapositivas dentro de un visor personalizado?**

El enfoque recomendado es renderizar cada diapositiva como una imagen (por ejemplo, PNG o SVG) o convertirla a HTML usando Aspose.Slides, y luego mostrar el resultado dentro de un cuadro de imagen (para escritorio) o un contenedor HTML (para web).

**¿Cómo manejo presentaciones grandes con muchas diapositivas?**

Para mazos extensos, considere la carga diferida o la renderización bajo demanda de las diapositivas. Esto significa generar el contenido de una diapositiva solo cuando el usuario navega a ella, reduciendo el consumo de memoria y el tiempo de carga.