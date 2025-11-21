---
title: Fusionar presentación
type: docs
weight: 40
url: /es/nodejs-java/merge-presentation/
keywords: "Combinar PowerPoint, PPTX, PPT, combinar PowerPoint, fusionar presentación, combinar presentación, Java"
description: "Fusionar o combinar presentaciones de PowerPoint en JavaScript"
---

## **Fusión de Presentaciones**

Al combinar una presentación con otra, efectivamente unes sus diapositivas en una sola presentación para obtener un archivo único. 

{{% alert title="Info" color="info" %}}

La mayoría de los programas de presentaciones (PowerPoint u OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de esta manera. 

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), sin embargo, permite fusionar presentaciones de diferentes formas. Puedes fusionar presentaciones con todas sus formas, estilos, textos, formato, comentarios, animaciones, etc., sin preocuparte por la pérdida de calidad o datos.

**Ver también**

[Clonar Diapositivas](https://docs.aspose.com/slides/nodejs-java/clone-slides/).

{{% /alert %}}

### **Qué se Puede Fusionar**

Con Aspose.Slides, puedes fusionar 

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una sola presentación
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación
* presentaciones en un mismo formato (PPT a PPT, PPTX a PPTX, etc.) y en formatos diferentes (PPT a PPTX, PPTX a ODP, etc.) entre sí. 

{{% alert title="Note" color="warning" %}} 

Además de presentaciones, Aspose.Slides permite fusionar otros archivos:

* [Imágenes](https://products.aspose.com/slides/nodejs-java/merger/image-to-image/), como [JPG a JPG](https://products.aspose.com/slides/nodejs-java/merger/jpg-to-jpg/) o [PNG a PNG](https://products.aspose.com/slides/nodejs-java/merger/png-to-png/)
* Documentos, como [PDF a PDF](https://products.aspose.com/slides/nodejs-java/merger/pdf-to-pdf/) o [HTML a HTML](https://products.aspose.com/slides/nodejs-java/merger/html-to-html/)
* Y dos archivos diferentes como [imagen a PDF](https://products.aspose.com/slides/nodejs-java/merger/image-to-pdf/) o [JPG a PDF](https://products.aspose.com/slides/nodejs-java/merger/jpg-to-pdf/) o [TIFF a PDF](https://products.aspose.com/slides/nodejs-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opciones de Fusión**

Puedes aplicar opciones que determinen si

* cada diapositiva en la presentación de salida conserva un estilo único
* se utiliza un estilo específico para todas las diapositivas en la presentación de salida. 

Para fusionar presentaciones, Aspose.Slides proporciona los métodos [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) (de la clase [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection)). Existen varias implementaciones de los métodos `addClone` que definen los parámetros del proceso de fusión de presentaciones. Cada objeto Presentation tiene una colección [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) , por lo que puedes llamar a un método `addClone` desde la presentación a la que deseas fusionar diapositivas.

El método `addClone` devuelve un objeto `Slide`, que es una copia de la diapositiva origen. Las diapositivas en la presentación de salida son simplemente una copia de las diapositivas de origen. Por lo tanto, puedes modificar las diapositivas resultantes (por ejemplo, aplicar estilos, opciones de formato o diseños) sin preocuparte de que las presentaciones de origen se vean afectadas. 

## **Fusionar Presentaciones** 

Aspose.Slides proporciona el método [**AddClone(ISlide)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) que permite combinar diapositivas mientras las diapositivas conservan sus diseños y estilos (parámetros predeterminados).

Este código JavaScript muestra cómo fusionar presentaciones:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **Fusionar Presentaciones con Patrón de Diapositiva Maestra**

Aspose.Slides proporciona el método [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) que permite combinar diapositivas aplicando una plantilla de patrón de diapositiva maestra. De este modo, si es necesario, puedes cambiar el estilo de las diapositivas en la presentación de salida.

Este código JavaScript demuestra la operación descrita:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 

El diseño de diapositiva para la maestra se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `addClone` está establecido en true, se utiliza el diseño de la diapositiva origen. De lo contrario, se lanzará una [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException).

{{% /alert %}}

Si deseas que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, utiliza el método [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) en su lugar al fusionar.

## **Fusionar Diapositivas Específicas de Presentaciones**

Fusionar diapositivas específicas de varias presentaciones es útil para crear paquetes de diapositivas personalizados. Aspose.Slides for Node.js via Java te permite seleccionar e importar solo las diapositivas que necesitas. La API conserva el formato, el diseño y el estilo de las diapositivas originales.

El siguiente código JavaScript crea una nueva presentación, agrega diapositivas de título de dos presentaciones diferentes y guarda el resultado en un archivo:
```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```

```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```


## **Fusionar Presentaciones con Diseño de Diapositiva**

Este código JavaScript muestra cómo combinar diapositivas de presentaciones aplicando tu diseño de diapositiva preferido para obtener una única presentación de salida:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **Fusionar Presentaciones con Diferentes Tamaños de Diapositiva**

{{% alert title="Note" color="warning" %}} 

No puedes fusionar presentaciones con tamaños de diapositiva diferentes. 

{{% /alert %}}

Para fusionar 2 presentaciones con tamaños de diapositiva diferentes, debes redimensionar una de las presentaciones para que su tamaño coincida con el de la otra. 

Este código de ejemplo demuestra la operación descrita:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **Fusionar Diapositivas a una Sección de Presentación**

Este código JavaScript muestra cómo fusionar una diapositiva específica a una sección en una presentación:
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


La diapositiva se agrega al final de la sección. 

## **Preguntas Frecuentes**

**¿Se conservan las notas del orador durante la fusión?**

Sí. Al clonar diapositivas, Aspose.Slides transfiere todos los elementos de la diapositiva, incluidas notas, formato y animaciones.

**¿Se transfieren los comentarios y sus autores?**

Los comentarios, como parte del contenido de la diapositiva, se copian con la diapositiva. Las etiquetas de autor de los comentarios se conservan como objetos de comentario en la presentación resultante.

**¿Qué ocurre si la presentación origen está protegida con contraseña?**

Debe [abrirse con la contraseña](/slides/es/nodejs-java/password-protected-presentation/) mediante [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setpassword/); después de cargarla, esas diapositivas pueden clonarse de forma segura en un archivo de destino sin protección (o también protegido).

**¿Qué tan segura es la operación de fusión en entornos multihilo?**

No utilice la misma instancia de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) desde [múltiples hilos](/slides/es/nodejs-java/multithreading/). La regla recomendada es "un documento — un hilo"; diferentes archivos pueden procesarse en paralelo en hilos independientes.

## **Ver También**

Aspose ofrece un [Creador de Collage GRATUITO en línea](https://products.aspose.app/slides/collage). Con este servicio en línea, puedes fusionar [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/collage/photo-grid) y más.

Prueba el [MERGER GRATUITO en línea de Aspose](https://products.aspose.app/slides/merger). Permite fusionar presentaciones PowerPoint en el mismo formato (p. ej., PPT a PPT, PPTX a PPTX) o entre formatos diferentes (p. ej., PPT a PPTX, PPTX a ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)