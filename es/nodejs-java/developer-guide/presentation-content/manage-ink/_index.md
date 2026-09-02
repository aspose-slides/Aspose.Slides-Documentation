---
title: Gestionar objetos de tinta de presentación en JavaScript
linktitle: Gestionar tinta
type: docs
weight: 95
url: /es/nodejs-java/manage-ink/
keywords:
- tinta
- objeto de tinta
- trazo de tinta
- gestionar tinta
- dibujar tinta
- dibujo
- exportación de tinta
- renderizado de tinta
- ocultar tinta
- InkOptions
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestionar objetos de tinta de PowerPoint, editar trazos y propiedades del pincel, y controlar la apariencia de la tinta durante la exportación a PDF, HTML, SVG, TIFF y como imagen con Aspose.Slides para Node.js mediante Java."
---
## **Introducción**

PowerPoint ofrece una función de tinta que permite dibujar trazos libres. La tinta puede usarse para resaltar otros objetos, mostrar conexiones y procesos, y llamar la atención sobre elementos específicos en una diapositiva.

Aspose.Slides proporciona los tipos necesarios para trabajar con objetos de tinta. Por ejemplo, la clase [Ink](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ink/) representa un objeto de tinta en una diapositiva.

## **Diferencias entre objetos normales y objetos de tinta**

Los objetos en una diapositiva de PowerPoint suelen representarse mediante objetos de forma. En su forma más simple, una forma es un contenedor que define el área del propio objeto (su marco) junto con propiedades como el tamaño del contenedor, la forma y el fondo. Para obtener más información, consulte [Formato de diseño de forma](https://docs.aspose.com/slides/es/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Sin embargo, cuando PowerPoint maneja un objeto de tinta, ignora todas las propiedades del marco del objeto (contenedor) excepto su tamaño. El tamaño del área del contenedor se determina mediante los métodos estándar [Shape.getWidth](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getWidth--) y [Shape.getHeight](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Trazos de tinta**

Un trazo de tinta es un elemento básico utilizado para registrar la trayectoria de un lápiz mientras un usuario escribe tinta digital. Un trazo almacena una secuencia de puntos conectados.

La forma más simple de codificación especifica las coordenadas X y Y de cada punto de muestra. Cuando se renderizan todos los puntos conectados, producen una imagen como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propiedades del pincel para dibujar**

Un pincel se utiliza para dibujar líneas que conectan los puntos de un trazo de tinta. El pincel tiene su propio color y tamaño, representados por los métodos [InkBrush.getColor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inkbrush/#getColor--) y [InkBrush.getSize](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inkbrush/#getSize--) .

### **Establecer el color del pincel de tinta**

Este código JavaScript muestra cómo establecer el color de un pincel de tinta:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **Establecer el tamaño del pincel de tinta**

Este código JavaScript muestra cómo establecer el tamaño de un pincel de tinta:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Generalmente, el ancho y el alto de un pincel no coinciden, por lo que PowerPoint no muestra el tamaño del pincel (la sección de datos correspondiente está atenuada). Cuando el ancho y el alto del pincel coinciden, PowerPoint muestra su tamaño de esta manera:

![ink_powerpoint3](ink_powerpoint3.png)

Para mayor claridad, aumentemos la altura del objeto de tinta y revisemos las dimensiones importantes:

![ink_powerpoint4](ink_powerpoint4.png)

El contenedor (marco) no tiene en cuenta el tamaño de los pinceles; siempre asume que el grosor de la línea es cero (ver la imagen anterior).

Por lo tanto, para determinar el área visible de todo el objeto de tinta, se debe tener en cuenta el tamaño del pincel de sus trazos. Aquí, el objeto objetivo (el trazo de texto manuscrito) se ha escalado al tamaño del contenedor (marco). Cuando el tamaño del contenedor cambia, el tamaño del pincel permanece constante, y viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utiliza un comportamiento similar para los objetos de texto:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controlar la apariencia de la tinta durante la exportación y renderizado**

Aspose.Slides proporciona la clase [InkOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inkoptions/) para controlar cómo aparecen los objetos de tinta en la salida exportada o renderizada. Puede usar sus propiedades para ocultar la tinta por completo o cambiar cómo se interpretan las operaciones de máscara del pincel de tinta.

Las opciones de tinta están disponibles a través de las opciones de exportación o renderizado para varios tipos de salida:

| Salida | Propiedad de opciones de tinta |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Imagen de diapositiva | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

Los siguientes métodos de [InkOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inkoptions/) exponen los mismos dos ajustes:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inkoptions/#getHideInk--) determina si los objetos de tinta se incluyen en la salida. Su valor predeterminado es `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) determina si una operación de máscara se interpreta como opacidad al renderizar un pincel de tinta. Su valor predeterminado es `true`; llame a [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) con `false` para usar la operación ROP en su lugar.

### **Ocultar objetos de tinta en la salida PDF**

De forma predeterminada, los objetos de tinta permanecen visibles durante la exportación. Para crear una salida limpia sin anotaciones manuscritas u otro contenido de tinta, llame a [InkOptions.setHideInk](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) con `true`.

El siguiente ejemplo en JavaScript exporta una presentación a PDF mientras oculta todos los objetos de tinta:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Ocultar objetos de tinta al renderizar una diapositiva como imagen**

Para ocultar los objetos de tinta al renderizar diapositivas como imágenes bitmap, configure [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) y pase las opciones de renderizado a [Slide.getImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-).

El siguiente ejemplo en JavaScript renderiza la primera diapositiva como una imagen PNG sin objetos de tinta:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Controlar el renderizado de la máscara de tinta**

La configuración [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) controla cómo se interpretan las operaciones de máscara al renderizar pinceles de tinta. El valor predeterminado es `true`, que utiliza opacidad. Para usar la operación ROP en su lugar, llame a [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) con `false`.

El siguiente ejemplo en JavaScript exporta una diapositiva a SVG y utiliza renderizado basado en ROP para las operaciones de máscara de tinta:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

La misma configuración puede aplicarse mediante [TiffOptions.getInkOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) al exportar una presentación o al renderizar una diapositiva a TIFF.

### **Elegir si ocultar o preservar la tinta**

Cuando necesite una versión limpia de una presentación anotada para su distribución sin marcas de revisión, llame a [InkOptions.setHideInk](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) con `true` durante la exportación.

Deje [InkOptions.getHideInk](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inkoptions/#getHideInk--) con su valor predeterminado `false` cuando las anotaciones de tinta forman parte del contenido previsto, como comentarios de revisión, notas manuscritas, resaltados o dibujos que deben permanecer visibles en el resultado exportado. Esto permite a las aplicaciones generar salidas de revisión y finales separadas a partir de la misma presentación sin modificar los objetos de tinta originales.

## **Preguntas frecuentes**

**¿Puedo cambiar el color o el tamaño de un trazo de tinta existente?**

Sí. Obtenga el trazo mediante [Ink.getTraces](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ink/#getTraces--) y luego modifique su [InkTrace.getBrush](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inktrace/#getBrush--). Llame a [InkBrush.setColor](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) o a [InkBrush.setSize](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) para cambiar el pincel.

**¿Ocultar la tinta modifica la presentación original?**

No. Llamar a [InkOptions.setHideInk](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) solo afecta al resultado renderizado o exportado; no elimina ni modifica los objetos de tinta en la presentación original.

**¿Qué formatos de exportación admiten opciones de tinta?**

Puede configurar las opciones de tinta para PDF, HTML, SVG, TIFF y imágenes bitmap de diapositivas mediante las correspondientes opciones de exportación o renderizado mostradas arriba.

**Lecturas adicionales**

* Para leer sobre las formas en general, consulte la sección [Formas de PowerPoint](https://docs.aspose.com/slides/es/nodejs-java/powerpoint-shapes/).
* Para obtener más información sobre valores efectivos, consulte [Propiedades efectivas de la forma](https://docs.aspose.com/slides/es/nodejs-java/shape-effective-properties/#get-effective-font-height-value).
* Para detalles sobre la exportación a PDF, consulte [Convertir PPT y PPTX a PDF](https://docs.aspose.com/slides/es/nodejs-java/convert-powerpoint-to-pdf/).
* Para detalles sobre la exportación a HTML, consulte [Convertir presentaciones de PowerPoint a HTML](https://docs.aspose.com/slides/es/nodejs-java/convert-powerpoint-to-html/).
* Para detalles sobre la exportación a SVG, consulte [Renderizar diapositivas de presentación como imágenes SVG](https://docs.aspose.com/slides/es/nodejs-java/render-a-slide-as-an-svg-image/).
* Para detalles sobre la exportación a TIFF, consulte [Convertir presentaciones de PowerPoint a TIFF](https://docs.aspose.com/slides/es/nodejs-java/convert-powerpoint-to-tiff/).
* Para detalles sobre el renderizado de diapositiva a imagen, consulte [Convertir diapositivas de presentación a imágenes](https://docs.aspose.com/slides/es/nodejs-java/convert-slide/).