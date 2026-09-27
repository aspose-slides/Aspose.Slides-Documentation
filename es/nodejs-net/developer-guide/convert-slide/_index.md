---
title: Convertir diapositivas de presentación a imágenes en Node.js via .NET
linktitle: Diapositiva a imagen
type: docs
weight: 40
url: /es/nodejs-net/convert-slide/
keywords:
- convertir diapositiva
- diapositiva a imagen
- diapositiva a PNG
- guardar diapositiva como imagen
- renderizar diapositiva
- miniatura de diapositiva
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Renderiza diapositivas de presentaciones PPTX, PPT y ODP como imágenes PNG en JavaScript con Aspose.Slides para Node.js via .NET, con un factor de escala o con un tamaño exacto en píxeles."
---
## **Descripción general**

Aspose.Slides for Node.js via .NET renderiza diapositivas de presentaciones PowerPoint y OpenDocument como imágenes, por ejemplo para mostrar vistas previas de diapositivas en una página web. Este artículo muestra dos formas de elegir el tamaño de la imagen: un factor de escala relativo al tamaño de la diapositiva y un tamaño exacto en píxeles. Ambos ejemplos guardan archivos PNG.

Los ejemplos esperan una presentación llamada `sample.pptx` en la carpeta del proyecto que configuraste en [Installation](/slides/es/nodejs-net/installation/). Cualquier presentación PowerPoint sirve. Guarda cada ejemplo como un archivo `.js` en la carpeta del proyecto y ejecútalo desde esa carpeta con `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET no tiene su propia referencia de API. Refleja la API de Aspose.Slides for .NET con nombres camelCase, por lo que los enlaces de API en este artículo llevan a las clases y miembros correspondientes en la [referencia de API de Aspose.Slides for .NET](https://reference.aspose.com/slides/es/net/).
{{% /alert %}}

Para convertir una diapositiva a una imagen, sigue estos pasos:

1. Abre la presentación con el constructor [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/presentation/).
1. Obtén una diapositiva de la colección [slides](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/slides/es/) con `get(index)`. Los índices empiezan en 0.
1. Renderiza la diapositiva con `getImageWithScale` o `getImageWithImageSize`. En la referencia de la API .NET, ambos son sobrecargas de [Slide.GetImage](https://reference.aspose.com/slides/es/net/aspose.slides/slide/getimage/). Devuelven un objeto de imagen que corresponde a [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/).
1. Guarda la imagen con su método [save](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/save/) y un valor [ImageFormat](https://reference.aspose.com/slides/es/net/aspose.slides/imageformat/), y después llama a su método `dispose`.

## **Convertir cada diapositiva a una imagen PNG**

`getImageWithScale` recibe un factor de escala horizontal y uno vertical. Con una escala de 1, un punto de la diapositiva se convierte en un píxel de la imagen. El siguiente ejemplo renderiza cada diapositiva con una escala de 2:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// Una escala de 1 renderiza un píxel por punto; 2 duplica el ancho y la altura.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

El script escribe un archivo por diapositiva, `slide_1.png`, `slide_2.png`, etc., numerados a partir de 1. Para una presentación 16:9 con diapositivas de 960 × 540 puntos, cada imagen tiene 1920 × 1080 píxeles. Las diapositivas ocultas también se renderizan; para omitirlas, comprueba la propiedad [hidden](https://reference.aspose.com/slides/es/net/aspose.slides/slide/hidden/) de la diapositiva. Cada imagen se elimina en su propio bloque `finally`, lo que la libera antes de que se renderice la siguiente diapositiva. Sin una licencia, las imágenes también muestran una marca de agua de evaluación; consulta [Licensing](/slides/es/nodejs-net/licensing/).

## **Convertir una diapositiva a una imagen de un tamaño específico**

`getImageWithImageSize` recibe un objeto con `width` y `height` en píxeles. El siguiente ejemplo renderiza la primera diapositiva con 1280 píxeles de ancho y calcula la altura a partir del tamaño de la diapositiva, de modo que la imagen mantenga la relación de aspecto de la diapositiva:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

La propiedad [slideSize.size](https://reference.aspose.com/slides/es/net/aspose.slides/slidesize/size/) devuelve el ancho y la altura de la diapositiva en puntos. Para una presentación 16:9, el script muestra `Saved a 1280 x 720 image` y escribe `slide_1_1280px.png`; para una presentación 4:3, la imagen tiene 1280 × 960 píxeles.

## **FAQ**

**¿Por qué la imagen de `getImage` sin argumentos es tan pequeña?**

Sin argumentos, `getImage` renderiza la diapositiva al 20 % de su tamaño en puntos, por lo que una diapositiva de 960 × 540 puntos se convierte en una imagen de 192 × 108 píxeles. Utiliza `getImageWithScale` o `getImageWithImageSize` para elegir el tamaño.

**¿Cómo guardo JPEG u otros formatos de imagen?**

Pasa otro valor `ImageFormat` al método `save` de la imagen, por ejemplo `image.save("slide_1.jpg", ImageFormat.Jpeg)`. El formato se obtiene del valor `ImageFormat`, no de la extensión del archivo, así que mantén ambos consistentes.

**¿Por qué el texto en las imágenes se ve diferente en Linux?**

Aspose.Slides solo puede utilizar fuentes que estén instaladas en la máquina que renderiza las diapositivas. Cuando una presentación usa una fuente que falta, como Calibri en un servidor Linux típico, Aspose.Slides utiliza una fuente instalada en su lugar, lo que puede cambiar el aspecto del texto y la forma en que se ajustan las líneas. Instala las fuentes que tus presentaciones usan para obtener las mismas imágenes que en Windows.

**¿Por qué `getThumbnailWithImageSize` falla con un TypeError?**

El README del paquete usa `getThumbnailWithImageSize`, pero el paquete no tiene métodos `getThumbnail`. Usa `getImageWithImageSize` en su lugar; toma el mismo argumento `{ width, height }`.