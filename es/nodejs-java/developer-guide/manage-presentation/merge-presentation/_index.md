---
title: Fusionar presentaciones de forma eficiente en JavaScript
linktitle: Fusionar presentaciones
type: docs
weight: 40
url: /es/nodejs-java/merge-presentation/
keywords:
- fusionar PowerPoint
- fusionar presentaciones
- fusionar diapositivas
- fusionar PPT
- fusionar PPTX
- fusionar ODP
- combinar PowerPoint
- combinar presentaciones
- combinar diapositivas
- combinar PPT
- combinar PPTX
- combinar ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "Fusiona sin esfuerzo presentaciones PowerPoint (PPT, PPTX) y OpenDocument (ODP) en JavaScript con Aspose.Slides para Node.js, optimizando tu flujo de trabajo."
---

## **Fusión de presentaciones**

Cuando fusionas una presentación con otra, combinas efectivamente sus diapositivas en una única presentación para obtener un solo archivo. 

{{% alert title="Información" color="info" %}}

La mayoría de los programas de presentación (PowerPoint o OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de este modo. 

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/) permite fusionar presentaciones de diferentes maneras. Puedes fusionar presentaciones con todas sus formas, estilos, textos, formatos, comentarios, animaciones, etc., sin preocuparte por la pérdida de calidad o datos.

**Ver también**

[Clone Slides](https://docs.aspose.com/slides/nodejs-java/clone-slides/).

{{% /alert %}}

### **Qué se puede fusionar**

Con Aspose.Slides, puedes fusionar 

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una sola presentación
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación
* presentaciones en un mismo formato (PPT a PPT, PPTX a PPTX, etc.) y en formatos diferentes (PPT a PPTX, PPTX a ODP, etc.) entre sí. 

### **Opciones de fusión**

Puedes aplicar opciones que determinan si

* cada diapositiva en la presentación de salida conserva un estilo único
* se utiliza un estilo específico para todas las diapositivas en la presentación de salida. 

Para fusionar presentaciones, Aspose.Slides proporciona los métodos [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) (de la clase [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection)). Existen varias implementaciones de los métodos `addClone` que definen los parámetros del proceso de fusión de presentaciones. Cada objeto Presentation tiene una colección [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) , por lo que puedes llamar a un método `addClone` desde la presentación a la que deseas fusionar diapositivas.

El método `addClone` devuelve un objeto `Slide`, que es una copia de la diapositiva de origen. Las diapositivas en una presentación de salida son simplemente una copia de las diapositivas de origen. Por lo tanto, puedes modificar las diapositivas resultantes (por ejemplo, aplicar estilos, opciones de formato o diseños) sin que las presentaciones de origen se vean afectadas. 

## **Fusionar presentaciones** 

Aspose.Slides proporciona el método [**AddClone(ISlide)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) que permite combinar diapositivas mientras estas conservan sus diseños y estilos (parámetros predeterminados).

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


## **Fusionar presentaciones con maestro de diapositivas** 

Aspose.Slides proporciona el método [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) que permite combinar diapositivas aplicando una plantilla de maestro de diapositivas. De este modo, si es necesario, puedes cambiar el estilo de las diapositivas en la presentación de salida.

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


{{% alert title="Nota" color="warning" %}} 

El diseño de diapositiva del maestro se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `addClone` se establece en true, se utiliza el diseño de la diapositiva de origen. De lo contrario, se lanzará una [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException). 

{{% /alert %}}

Si deseas que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, utiliza el método [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) en su lugar al fusionar.

## **Fusionar diapositivas específicas de presentaciones** 

Fusionar diapositivas específicas de varias presentaciones es útil para crear paquetes de diapositivas personalizados. Aspose.Slides for Node.js via Java permite seleccionar e importar solo las diapositivas que necesitas. La API conserva el formato, el diseño y el estilo de las diapositivas originales.

El siguiente código JavaScript crea una nueva presentación, añade diapositivas de título de dos presentaciones distintas y guarda el resultado en un archivo:
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


## **Fusionar presentaciones con diseño de diapositiva** 

Este código JavaScript muestra cómo combinar diapositivas de presentaciones mientras se aplica tu diseño de diapositiva preferido para obtener una única presentación de salida:
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


## **Fusionar presentaciones con tamaños de diapositiva diferentes** 

{{% alert title="Nota" color="warning" %}} 

No puedes fusionar presentaciones con tamaños de diapositiva diferentes. 

{{% /alert %}}

Para fusionar 2 presentaciones con tamaños de diapositiva diferentes, debes redimensionar una de las presentaciones para que su tamaño coincida con el de la otra presentación. 

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


## **Fusionar diapositivas a una sección de presentación** 

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


La diapositiva se añade al final de la sección. 

## **Preguntas frecuentes** 

**¿Se conservan las notas del orador al fusionar?** 

Sí. Al clonar diapositivas, Aspose.Slides traslada todos los elementos de la diapositiva, incluidas las notas, el formato y las animaciones. 

**¿Se transfieren los comentarios y sus autores?** 

Los comentarios, como parte del contenido de la diapositiva, se copian con la diapositiva. Las etiquetas de autor de los comentarios se conservan como objetos de comentario en la presentación resultante. 

**¿Qué ocurre si la presentación de origen está protegida con contraseña?** 

Debe [abrirse con la contraseña](/slides/es/nodejs-java/password-protected-presentation/) mediante [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setpassword/); tras la carga, esas diapositivas pueden clonarse de forma segura en un archivo de destino sin protección (o también protegido). 

**¿Qué tan segura es la operación de fusión en cuanto a subprocesos?** 

No utilices la misma instancia de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) desde [múltiples subprocesos](/slides/es/nodejs-java/multithreading/). La regla recomendada es “un documento — un subproceso”; diferentes archivos pueden procesarse en paralelo en subprocesos separados. 

## **Ver también** 

Aspose ofrece un [Creador de Collages ONLINE GRATUITO](https://products.aspose.app/slides/collage). Con este servicio online, puedes fusionar [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/collage/photo-grid) y mucho más. 

Prueba el [MERGER ONLINE GRATUITO DE ASPose](https://products.aspose.app/slides/merger). Permite fusionar presentaciones de PowerPoint en el mismo formato (p. ej., PPT a PPT, PPTX a PPTX) o entre formatos diferentes (p. ej., PPT a PPTX, PPTX a ODP). 

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)