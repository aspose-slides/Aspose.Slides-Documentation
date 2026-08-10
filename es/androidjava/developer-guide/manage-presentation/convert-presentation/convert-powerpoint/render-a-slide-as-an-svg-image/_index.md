---
title: Renderizar diapositivas de presentación como imágenes SVG en Android
linktitle: Diapositiva a SVG
type: docs
weight: 50
url: /es/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint a SVG
- presentación a SVG
- diapositiva a SVG
- PPT a SVG
- PPTX a SVG
- opciones de exportación SVG
- SVG interactivo
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Exporta diapositivas de PowerPoint como imágenes SVG en Android y controla fuentes, texto, imágenes, IDs y eventos con Aspose.Slides."
---
## **Visión general**

SVG es un formato de imagen escalable basado en XML que funciona bien para la publicación web, visores de diapositivas, flujos de trabajo de accesibilidad y procesamiento posterior automatizado. Aspose.Slides for Android a través de Java exporta cada diapositiva a un archivo SVG separado y le permite controlar cómo se escriben el texto, las fuentes, las imágenes y los elementos SVG.

Utilice [SVGOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgoptions/) cuando el SVG exportado deba ser compacto, predecible en distintos navegadores o estar listo para su uso interactivo.

## **Exportar una diapositiva como SVG**

Cree una [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/), seleccione una diapositiva y escríbala en un flujo con [ISlide.writeAsSvg](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). El siguiente ejemplo exporta cada diapositiva de una presentación como un archivo SVG independiente.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

El nombre de archivo usa [ISlide.getSlideNumber](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islide/#getSlideNumber--) en lugar del índice del bucle. También puede exportar una forma individual con [IShape.writeAsSvg](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) cuando un visor de diapositivas o una página web necesite sólo esa forma.

## **Configurar la salida SVG**

[SVGOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgoptions/) controla la representación SVG. Para marcos de texto, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) incluye el marco de texto en el área de representación, y [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) determina si se aplica la rotación del marco. Establezca [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) a `true` cuando el texto deba renderizarse sin ligaduras.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Controlar texto y fuentes**

### **Vectorizar todo el texto**

Establezca [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) a `true` para escribir todo el texto de la diapositiva como gráficos vectoriales. Esto elimina las dependencias de fuentes y hace que el resultado visual sea más coherente entre navegadores, pero el texto ya no es seleccionable ni buscable como texto SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **Elegir cómo se gestionan las fuentes externas**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) utiliza un valor [SvgExternalFontsHandling](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgexternalfontshandling/) para las fuentes que se cargan externamente. Elija [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgexternalfontshandling/) para hacer referencia a archivos de fuentes separados, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgexternalfontshandling/) para incluir los datos de la fuente en el SVG, o [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgexternalfontshandling/) para renderizar sólo el texto que utiliza fuentes externas como gráficos. Verifique la licencia de las fuentes antes de incrustarlas.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Reducir el tamaño de imágenes incrustadas**

Utilice [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) para reducir la resolución de las imágenes incrustadas, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) para omitir áreas de origen recortadas y [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) para controlar la calidad de codificación JPEG. Estas configuraciones reducen el tamaño del archivo a costa de la fidelidad de la imagen o de los datos de imagen retenidos.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Asignar IDs estables a formas y texto**

Utilice [ISvgShapeFormattingController](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) para establecer [ISvgShape.setId](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) para cada forma SVG. Para establecer valores [ISvgTSpan.setId](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) en los elementos `tspan` de texto también, implemente [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Asigne cualquiera de los controladores con [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

El siguiente controlador utiliza [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) , que es estable durante la vida útil de la forma, y un contador repetible para sus `tspan` de texto. Esto hace que los IDs generados sean adecuados para el post‑procesado de una presentación que no haya cambiado.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Añadir manejadores de eventos SVG**

En un [ISvgShapeFormattingController](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), llame a [ISvgShape.setEventHandler](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) con un valor [SvgEvent](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgevent/) para añadir un manejador de evento JavaScript a una forma exportada. Asigne el controlador con [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) y defina la función JavaScript en la página o el documento SVG que aloje el resultado.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

La página anfitriona puede definir la función JavaScript a la que hace referencia el manejador. Asignar IDs y manejadores de eventos permite visores de diapositivas, mejoras de accesibilidad y otros flujos de trabajo interactivos con SVG.

## **Preguntas frecuentes**

**¿Cuándo debería usar [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) en lugar de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Utilice [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) cuando todo el texto deba ser independiente de las fuentes. Utilice [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/svgexternalfontshandling/) cuando sólo el texto que usa fuentes externas deba convertirse en gráficos.

**¿Cuál es la mejor manera de reducir el tamaño de un SVG?**

Comience comprimiendo las imágenes incrustadas, eliminando áreas de imagen recortadas y eligiendo archivos de fuentes enlazados cuando el entorno de destino pueda servirlos. Pruebe el resultado porque una menor resolución de imagen, una calidad JPEG más baja y el texto vectorizado tienen diferentes compromisos entre calidad y tamaño.

**¿Puedo modificar los elementos SVG exportados después de la exportación?**

Sí. Asigne IDs mediante un controlador de formato y luego seleccione los elementos SVG correspondientes en su herramienta de post‑procesado o script del navegador.