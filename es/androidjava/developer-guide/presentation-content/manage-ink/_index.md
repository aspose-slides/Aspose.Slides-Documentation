---
title: Gestionar objetos de tinta de PowerPoint en Android
linktitle: Gestionar tinta
type: docs
weight: 95
url: /es/androidjava/manage-ink/
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
- Android
- Java
- Aspose.Slides
description: "Gestionar objetos de tinta de PowerPoint, editar trazos y propiedades del pincel, y controlar la apariencia de la tinta durante la exportación a PDF, HTML, SVG, TIFF y de imágenes con Aspose.Slides para Android."
---
## **Introducción**

PowerPoint incluye una función de tinta que permite dibujar trazos libres. La tinta se puede usar para resaltar otros objetos, mostrar conexiones y procesos, y atraer la atención a elementos específicos en una diapositiva.

Aspose.Slides proporciona los tipos necesarios para trabajar con objetos de tinta. Por ejemplo, la interfaz [IInk](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iink/) representa un objeto de tinta en una diapositiva.

## **Diferencias entre objetos normales y objetos de tinta**

Los objetos en una diapositiva de PowerPoint normalmente se representan mediante objetos de forma. En su forma más simple, una forma es un contenedor que define el área del propio objeto (su marco) junto con propiedades como el tamaño del contenedor, la forma y el fondo. Para obtener más información, consulte el [Formato de diseño de forma](https://docs.aspose.com/slides/es/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Sin embargo, cuando PowerPoint trata un objeto de tinta, ignora todas las propiedades del marco del objeto (contenedor) salvo su tamaño. El tamaño del área del contenedor se determina mediante los métodos estándar [IShape.getWidth](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#getWidth--) y [IShape.getHeight](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Rastros de tinta**

Un rastro de tinta es un elemento básico que se utiliza para registrar la trayectoria de un lápiz mientras el usuario escribe tinta digital. Un rastro almacena una secuencia de puntos conectados.

La forma más simple de codificación especifica las coordenadas X e Y de cada punto de muestra. Cuando se renderizan todos los puntos conectados, producen una imagen como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propiedades del pincel para dibujar**

Un pincel se usa para dibujar líneas que conectan los puntos de un rastro de tinta. El pincel tiene su propio color y tamaño, representados por los métodos [IInkBrush.getColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinkbrush/#getColor--) y [IInkBrush.getSize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinkbrush/#getSize--) .

### **Establecer el color del pincel de tinta**

Este código Java muestra cómo establecer el color de un pincel de tinta:

```java
import android.graphics.Color;
import com.aspose.slides.*;

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
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

En general, el ancho y la altura de un pincel no coinciden, por lo que PowerPoint no muestra el tamaño del pincel (la sección de datos correspondiente aparece atenuada). Cuando el ancho y la altura del pincel coinciden, PowerPoint muestra su tamaño de esta manera:

![ink_powerpoint3](ink_powerpoint3.png)

Para mayor claridad, aumentemos la altura del objeto de tinta y revisemos las dimensiones importantes:

![ink_powerpoint4](ink_powerpoint4.png)

El contenedor (marco) no tiene en cuenta el tamaño de los pinceles; siempre asume que el grosor de la línea es cero (ver la imagen anterior).

Por lo tanto, para determinar el área visible de todo el objeto de tinta, se debe tener en cuenta el tamaño del pincel de sus rastros. Aquí, el objeto objetivo (el rastro de texto manuscrito) se ha escalado al tamaño del contenedor (marco). Cuando el tamaño del contenedor cambia, el tamaño del pincel permanece constante, y viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utiliza un comportamiento similar para los objetos de texto:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controlar la apariencia de la tinta durante la exportación y el renderizado**

Aspose.Slides proporciona la interfaz [IInkOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinkoptions/) para controlar cómo aparecen los objetos de tinta en la salida exportada o renderizada. Puede usar sus propiedades para ocultar la tinta por completo o cambiar la forma en que se interpretan las operaciones de máscara del pincel de tinta.

Las opciones de tinta están disponibles a través de las opciones de exportación o renderizado para varios tipos de salida:

| Salida | Propiedad de opciones de tinta |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Imagen de diapositiva | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

Los siguientes métodos de [IInkOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinkoptions/) exponen los mismos dos ajustes:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) determina si los objetos de tinta se incluyen en la salida. Su valor predeterminado es `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) determina si una operación de máscara se interpreta como opacidad al renderizar un pincel de tinta. Su valor predeterminado es `true`; llame a [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) con `false` para usar la operación ROP en su lugar.

### **Ocultar objetos de tinta en la salida PDF**

De manera predeterminada, los objetos de tinta siguen visibles durante la exportación. Para crear una salida limpia sin anotaciones manuscritas u otro contenido de tinta, llame a [IInkOptions.setHideInk](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) con `true`.

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

Para ocultar objetos de tinta al renderizar diapositivas como imágenes bitmap, configure [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) y pase las opciones de renderizado a [ISlide.getImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

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

El ajuste [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) controla cómo se interpretan las operaciones de máscara al renderizar pinceles de tinta. El valor predeterminado es `true`, lo que utiliza opacidad. Para usar la operación ROP en su lugar, llame a [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) con `false`.

El siguiente ejemplo Java exporta una diapositiva a SVG y usa renderizado basado en ROP para las operaciones de máscara de tinta:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

El mismo ajuste puede aplicarse a través de [TiffOptions.getInkOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) al exportar una presentación o al renderizar una diapositiva a TIFF.

### **Elegir si ocultar o conservar la tinta**

Cuando necesita una versión limpia de una presentación anotada para distribución sin marcas de revisión, llame a [IInkOptions.setHideInk](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) con `true` durante la exportación.

Mantenga [IInkOptions.getHideInk](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) en su valor predeterminado `false` cuando las anotaciones de tinta formen parte del contenido previsto, como comentarios de revisión, notas manuscritas, resaltados o dibujos que deben permanecer visibles en el resultado exportado. Esto permite a las aplicaciones generar salidas de revisión y finales separadas a partir de la misma presentación sin modificar los objetos de tinta originales.

## **Preguntas frecuentes**

**¿Puedo cambiar el color o el tamaño de un trazo de tinta existente?**

Sí. Obtenga el rastro mediante [IInk.getTraces](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iink/#getTraces--), luego cambie su [IInkTrace.getBrush](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinktrace/#getBrush--). Llame a [IInkBrush.setColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) o a [IInkBrush.setSize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) para modificar el pincel.

**¿Ocultar la tinta modifica la presentación original?**

No. Llamar a [IInkOptions.setHideInk](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) afecta solo al resultado renderizado o exportado; no elimina ni modifica los objetos de tinta en la presentación fuente.

**¿Qué formatos de exportación admiten opciones de tinta?**

Puede configurar las opciones de tinta para PDF, HTML, SVG, TIFF y imágenes bitmap de diapositivas mediante las opciones de exportación o renderizado correspondientes mostradas arriba.

**Lecturas adicionales**

* Para leer sobre formas en general, consulte la sección [Formas de PowerPoint](https://docs.aspose.com/slides/es/androidjava/powerpoint-shapes/).
* Para obtener más información sobre valores efectivos, vea [Propiedades efectivas de forma](https://docs.aspose.com/slides/es/androidjava/shape-effective-properties/#get-effective-font-height-value).
* Para obtener detalles sobre la exportación a PDF, consulte [Convertir PPT y PPTX a PDF](https://docs.aspose.com/slides/es/androidjava/convert-powerpoint-to-pdf/).
* Para obtener detalles sobre la exportación a HTML, consulte [Convertir presentaciones de PowerPoint a HTML](https://docs.aspose.com/slides/es/androidjava/convert-powerpoint-to-html/).
* Para obtener detalles sobre la exportación a SVG, consulte [Renderizar diapositivas de presentación como imágenes SVG](https://docs.aspose.com/slides/es/androidjava/render-a-slide-as-an-svg-image/).
* Para obtener detalles sobre la exportación a TIFF, consulte [Convertir presentaciones de PowerPoint a TIFF](https://docs.aspose.com/slides/es/androidjava/convert-powerpoint-to-tiff/).
* Para obtener detalles sobre el renderizado de diapositivas a imágenes, consulte [Convertir diapositivas de presentación a imágenes](https://docs.aspose.com/slides/es/androidjava/convert-slide/).