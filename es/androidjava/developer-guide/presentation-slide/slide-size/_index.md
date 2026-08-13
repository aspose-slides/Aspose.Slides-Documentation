---
title: Cambiar el tamaño de la diapositiva de la presentación en Android
linktitle: Tamaño de diapositiva
type: docs
weight: 70
url: /es/androidjava/slide-size/
keywords:
  - tamaño de diapositiva
  - proporción de aspecto
  - estándar
  - pantalla panorámica
  - 4:3
  - 16:9
  - establecer tamaño de diapositiva
  - cambiar tamaño de diapositiva
  - tamaño de diapositiva personalizado
  - tamaño de diapositiva especial
  - tamaño de diapositiva único
  - diapositiva a tamaño completo
  - tipo de pantalla
  - no escalar
  - asegurar ajuste
  - maximizar
  - PowerPoint
  - OpenDocument
  - presentación
  - Android
  - Java
  - Aspose.Slides
description: "Redimensione rápidamente diapositivas en archivos PPT, PPTX y ODP con Java y Aspose.Slides para Android, optimice presentaciones para cualquier pantalla sin perder calidad."
---
## **Introducción**

Aspose.Slides proporciona herramientas completas para ajustar el tamaño de la diapositiva y la proporción de aspecto en presentaciones de PowerPoint, lo que es fundamental tanto para la impresión como para la visualización en pantalla. 

Tamaños de diapositiva y relaciones de aspecto más comunes:

- **Estándar (relación de aspecto 4:3)**: Ideal para pantallas y dispositivos antiguos.
- **Panorámico (relación de aspecto 16:9)**: Recomendado para proyectores y pantallas modernas.

Asegúrese de mantener la coherencia en toda su presentación, ya que un único tamaño de diapositiva y una única relación de aspecto se aplican a todas las diapositivas. Para obtener resultados óptimos, establezca las dimensiones de sus diapositivas al comienzo del proceso de creación de la presentación para evitar complicaciones.

{{% alert color="info" %}} 
Por defecto, las presentaciones creadas con Aspose.Slides utilizan la relación de aspecto estándar 4:3.
{{% /alert %}}

## **Cambiar el tamaño de la diapositiva en presentaciones**

Este fragmento de código muestra cómo cambiar el tamaño de la diapositiva en una presentación en Java utilizando Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Especificar tamaños de diapositiva personalizados en presentaciones**

Si considera que los tamaños de diapositiva habituales (4:3 y 16:9) no son adecuados para su trabajo, puede decidir utilizar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas a tamaño completo de su presentación en un diseño de página personalizado o si pretende mostrar su presentación en ciertos tipos de pantalla, probablemente se beneficie de usar una configuración de tamaño personalizado para su presentación. 

Este fragmento de código muestra cómo usar Aspose.Slides para Android mediante Java para especificar un tamaño de diapositiva personalizado para una presentación en Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Tamaño de papel A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestionar el contenido de la diapositiva después de redimensionar**

Después de cambiar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede distorsionarse. Por defecto, los objetos se redimensionan automáticamente para adaptarse al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puede especificar una configuración que determina cómo Aspose.Slides maneja el contenido de las diapositivas.

Según lo que pretenda hacer o conseguir, puede utilizar cualquiera de estas configuraciones:

- `DoNotScale`

  Si NO desea que los objetos de las diapositivas se redimensionen, use esta configuración.

- `EnsureFit`

  Si desea escalar a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de las diapositivas para asegurarse de que todos caben en ellas (de este modo, evita perder contenido), use esta configuración. 

- `Maximize`

  Si desea escalar a un tamaño de diapositiva más grande y necesita que Aspose.Slides amplíe los objetos de las diapositivas para que sean proporcionales al nuevo tamaño, use esta configuración. 

Este fragmento de código muestra cómo usar la configuración `Maximize` al cambiar el tamaño de la diapositiva de una presentación:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Preguntas frecuentes**

### ¿Puedo establecer un tamaño de diapositiva personalizado usando unidades diferentes a pulgadas (por ejemplo, puntos o milímetros)?

Sí. Aspose.Slides utiliza puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.

### ¿Afectará un tamaño de diapositiva personalizado muy grande al rendimiento y al uso de memoria durante el renderizado?

Sí. Dimensiones de diapositiva mayores (en puntos) combinadas con una escala de renderizado más alta conllevan un mayor consumo de memoria y tiempos de procesamiento más largos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado solo según sea necesario para lograr la calidad de salida deseada.

### ¿Puedo definir un tamaño de diapositiva no estándar y luego combinar diapositivas de presentaciones que tienen diferentes tamaños?

No es posible [fusionar presentaciones](/slides/es/androidjava/merge-presentation/) mientras tengan tamaños de diapositiva diferentes; primero, redimensione una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se maneja el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slidesizescaletype/). Después de alinear los tamaños, puede combinar diapositivas conservando el formato.

### ¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de la diapositiva?

Sí. Aspose.Slides puede generar miniaturas para [diapositivas completas](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) así como para [formas seleccionadas](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Las imágenes resultantes reflejan el tamaño y la relación de aspecto actuales de la diapositiva, garantizando un encuadre y una geometría consistentes.