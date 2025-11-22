---
title: Visor de presentaciones
type: docs
weight: 50
url: /es/nodejs-java/presentation-viewer/
keywords:
- ver presentación
- visor de presentaciones
- ver PPT
- ver PPTX
- ver ODP
- PowerPoint
- OpenDocument
- Node.js
- Java
- Aspose.Slides for Node.js via Java
description: "Visor de presentaciones PowerPoint en JavaScript"
---

Aspose.Slides para Node.js a través de Java se utiliza para crear archivos de presentación con diapositivas. Estas diapositivas pueden verse abriendo presentaciones en Microsoft PowerPoint, por ejemplo. Sin embargo, a veces los desarrolladores pueden necesitar ver las diapositivas como imágenes en su visor de imágenes preferido o crear su propio visor de presentaciones. En esos casos, Aspose.Slides permite exportar una diapositiva individual como una imagen. Este artículo describe cómo hacerlo.

## **Generar una imagen SVG a partir de una diapositiva**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva por su índice.
1. Abra un flujo de archivo.
1. Guarde la diapositiva como una imagen SVG en el flujo de archivo.
```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **Generar un SVG con un ID de forma personalizado**

Aspose.Slides se puede usar para generar un [SVG](https://docs.fileformat.com/page-description-language/svg/) a partir de una diapositiva con un ID de forma personalizado. Para ello, use el método `setId` de [SvgShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` se puede utilizar para establecer el ID de la forma.
```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```

```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```


## **Crear una imagen miniatura de una diapositiva**

Aspose.Slides le ayuda a generar imágenes en miniatura de diapositivas. Para generar una miniatura de una diapositiva usando Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva por su índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada a una escala definida.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.
```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Crear una miniatura de diapositiva con dimensiones definidas por el usuario**

Para crear una imagen en miniatura de diapositiva con dimensiones definidas por el usuario, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva por su índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con las dimensiones definidas.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.
```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **Crear una miniatura de diapositiva con notas del orador**

Para generar la miniatura de una diapositiva con notas del orador usando Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la clase [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/).
1. Utilice el método `RenderingOptions.setSlidesLayoutOptions` para establecer la posición de las notas del orador.
1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva por su índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con las opciones de renderizado.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.
```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```


## **Ejemplo en vivo**

Puede probar la aplicación gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) para ver lo que puede implementar con la API de Aspose.Slides:

![Visor de PowerPoint en línea](online-PowerPoint-viewer.png)

## **Preguntas frecuentes**

**¿Puedo incrustar un visor de presentaciones en una aplicación web Node.js?**

Sí. Puede usar Aspose.Slides en el servidor para renderizar diapositivas como imágenes o HTML y mostrarlas en el navegador. Las funciones de navegación y zoom pueden implementarse con JavaScript para una experiencia interactiva.

**¿Cuál es la mejor manera de mostrar diapositivas dentro de un visor personalizado?**

El enfoque recomendado es renderizar cada diapositiva como una imagen (p. ej., PNG o SVG) o convertirla a HTML usando Aspose.Slides, y luego mostrar el resultado dentro de un cuadro de imagen (para escritorio) o un contenedor HTML (para web).

**¿Cómo manejo presentaciones grandes con muchas diapositivas?**

Para presentaciones extensas, considere cargar perezosamente o renderizar las diapositivas bajo demanda. Esto significa generar el contenido de una diapositiva solo cuando el usuario navega a ella, reduciendo la memoria y el tiempo de carga.