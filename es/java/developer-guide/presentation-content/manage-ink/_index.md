---
title: Gestionar objetos de tinta de presentación en Java
linktitle: Gestionar tinta
type: docs
weight: 95
url: /es/java/manage-ink/
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
- IInkOptions
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Gestionar objetos de tinta de PowerPoint, editar trazos y propiedades del pincel, y controlar la apariencia de la tinta durante la exportación a PDF, HTML, SVG, TIFF y como imagen con Aspose.Slides para Java."
---
## **Introducción**

PowerPoint incluye una función de tinta que permite dibujar trazos libres. La tinta se puede usar para resaltar otros objetos, mostrar conexiones y procesos, y llamar la atención sobre elementos específicos en una diapositiva.

Aspose.Slides proporciona los tipos necesarios para trabajar con objetos de tinta. Por ejemplo, la interfaz [IInk](https://reference.aspose.com/slides/es/java/com.aspose.slides/iink/) representa un objeto de tinta en una diapositiva.

## **Diferencias entre objetos normales y objetos de tinta**

Los objetos en una diapositiva de PowerPoint se representan normalmente mediante objetos de forma. En su forma más simple, una forma es un contenedor que define el área del propio objeto (su marco) junto con propiedades como el tamaño del contenedor, la forma y el fondo. Para más información, consulte [Shape Layout Format](https://docs.aspose.com/slides/es/java/shape-manipulations/#access-layout-formats-for-shape).

Sin embargo, cuando PowerPoint maneja un objeto de tinta, ignora todas las propiedades del marco del objeto (contenedor) excepto su tamaño. El tamaño del área del contenedor se determina mediante los métodos estándar [IShape.getWidth](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getWidth--) y [IShape.getHeight](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getHeight--):

![ink_powerpoint1](ink_powerpoint1.png)

## **Trazos de tinta**

Un trazo de tinta es un elemento básico usado para registrar la trayectoria de un lápiz mientras el usuario escribe tinta digital. Un trazo almacena una secuencia de puntos conectados.

La forma más simple de codificación especifica las coordenadas X e Y de cada punto de muestra. Cuando se renderizan todos los puntos conectados, producen una imagen como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propiedades del pincel para dibujar**

Un pincel se usa para dibujar líneas que conectan los puntos de un trazo de tinta. El pincel tiene su propio color y tamaño, representados por los métodos [IInkBrush.getColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinkbrush/#getColor--) y [IInkBrush.getSize](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinkbrush/#getSize--) .

### **Establecer el color del pincel de tinta**

Este código Java muestra cómo establecer el color de un pincel de tinta:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Establecer el tamaño del pincel de tinta**

Este código Java muestra cómo establecer el tamaño de un pincel de tinta:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

En general, la anchura y la altura de un pincel no coinciden, por lo que PowerPoint no muestra el tamaño del pincel (la sección de datos correspondiente está atenuada). Cuando la anchura y la altura del pincel coinciden, PowerPoint muestra su tamaño de esta forma:

![ink_powerpoint3](ink_powerpoint3.png)

Para mayor claridad, aumentemos la altura del objeto de tinta y revisemos las dimensiones importantes:

![ink_powerpoint4](ink_powerpoint4.png)

El contenedor (marco) no tiene en cuenta el tamaño de los pinceles; siempre asume que el grosor de la línea es cero (ver la imagen anterior).

Por lo tanto, para determinar el área visible de todo el objeto de tinta, se debe considerar el tamaño del pincel de sus trazos. Aquí, el objeto objetivo (el trazo de texto manuscrito) se ha escalado al tamaño del contenedor (marco). Cuando el tamaño del contenedor cambia, el tamaño del pincel permanece constante, y viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utiliza un comportamiento similar para los objetos de texto:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controlar la apariencia de la tinta durante la exportación y el renderizado**

Aspose.Slides proporciona la interfaz [IInkOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinkoptions/) para controlar cómo aparecen los objetos de tinta en la salida exportada o renderizada. Puede usar sus propiedades para ocultar la tinta por completo o cambiar la forma en que se interpretan las operaciones de máscara del pincel de tinta.

Las opciones de tinta están disponibles a través de las opciones de exportación o renderizado para varios tipos de salida:

| Salida | Propiedad de opciones de tinta |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/es/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/es/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/es/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/es/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Imagen de diapositiva | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/es/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

Los siguientes métodos de [IInkOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinkoptions/) exponen los mismos dos ajustes:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinkoptions/#getHideInk--) determina si los objetos de tinta se incluyen en la salida. Su valor predeterminado es `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) determina si una operación de máscara se interpreta como opacidad al renderizar un pincel de tinta. Su valor predeterminado es `true`; llame a [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) con `false` para usar la operación ROP en su lugar.

### **Ocultar objetos de tinta en la salida PDF**

De forma predeterminada, los objetos de tinta siguen visibles durante la exportación. Para crear una salida limpia sin anotaciones manuscritas u otro contenido de tinta, llame a [IInkOptions.setHideInk](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) con `true`.

El siguiente ejemplo Java exporta una presentación a PDF ocultando todos los objetos de tinta:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Ocultar objetos de tinta al renderizar una diapositiva como imagen**

Para ocultar los objetos de tinta al renderizar diapositivas como imágenes bitmap, configure [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/renderingoptions/#getInkOptions--) y pase las opciones de renderizado a [ISlide.getImage](https://reference.aspose.com/slides/es/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

El siguiente ejemplo Java renderiza la primera diapositiva como una imagen PNG sin objetos de tinta:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Controlar el renderizado de la máscara de tinta**

El ajuste [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) controla cómo se interpretan las operaciones de máscara al renderizar pinceles de tinta. El valor predeterminado es `true`, lo que usa opacidad. Para usar la operación ROP en su lugar, llame a [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) con `false`.

El siguiente ejemplo Java exporta una diapositiva a SVG y usa renderizado basado en ROP para las operaciones de máscara de tinta:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

El mismo ajuste puede aplicarse a través de [TiffOptions.getInkOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/tiffoptions/#getInkOptions--) al exportar una presentación o renderizar una diapositiva a TIFF.

### **Elegir si ocultar o conservar la tinta**

Cuando necesite una versión limpia de una presentación anotada para distribución sin marcas de revisión, llame a [IInkOptions.setHideInk](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) con `true` durante la exportación.

Deje [IInkOptions.getHideInk](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinkoptions/#getHideInk--) con su valor predeterminado `false` cuando las anotaciones de tinta formen parte del contenido previsto, como comentarios de revisión, notas manuscritas, resaltados o dibujos que deben permanecer visibles en el resultado exportado. Esto permite a las aplicaciones generar salidas de revisión y finales por separado a partir de la misma presentación sin modificar los objetos de tinta originales.

## **Preguntas frecuentes**

**¿Puedo cambiar el color o el tamaño de un trazo de tinta existente?**

Sí. Obtenga el trazo mediante [IInk.getTraces](https://reference.aspose.com/slides/es/java/com.aspose.slides/iink/#getTraces--), luego modifique su [IInkTrace.getBrush](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinktrace/#getBrush--). Llame a [IInkBrush.setColor](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) o a [IInkBrush.setSize](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) para cambiar el pincel.

**¿Ocultar la tinta modifica la presentación original?**

No. Llamar a [IInkOptions.setHideInk](https://reference.aspose.com/slides/es/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) solo afecta al resultado renderizado o exportado; no elimina ni modifica los objetos de tinta en la presentación fuente.

**¿Qué formatos de exportación admiten opciones de tinta?**

Puede configurar las opciones de tinta para PDF, HTML, SVG, TIFF y imágenes bitmap de diapositivas mediante las opciones de exportación o renderizado correspondientes mostradas arriba.

**Lecturas adicionales**

* Para información general sobre formas, consulte la sección [PowerPoint Shapes](https://docs.aspose.com/slides/es/java/powerpoint-shapes/).
* Para más información sobre valores efectivos, vea [Shape Effective Properties](https://docs.aspose.com/slides/es/java/shape-effective-properties/#get-effective-font-height-value).
* Para detalles sobre la exportación a PDF, consulte [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/es/java/convert-powerpoint-to-pdf/).
* Para detalles sobre la exportación a HTML, consulte [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/es/java/convert-powerpoint-to-html/).
* Para detalles sobre la exportación a SVG, consulte [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/es/java/render-a-slide-as-an-svg-image/).
* Para detalles sobre la exportación a TIFF, consulte [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/es/java/convert-powerpoint-to-tiff/).
* Para detalles sobre el renderizado de diapositiva a imagen, consulte [Convert Presentation Slides to Images](https://docs.aspose.com/slides/es/java/convert-slide/).