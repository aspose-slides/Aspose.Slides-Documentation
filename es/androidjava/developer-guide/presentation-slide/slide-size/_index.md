---
title: Cambiar el tamaño de la diapositiva de la presentación en Android
linktitle: Tamaño de diapositiva
type: docs
weight: 70
url: /es/androidjava/slide-size/
keywords:
  - tamaño de diapositiva
  - relación de aspecto
  - estándar
  - panorámico
  - 4:3
  - 16:9
  - establecer tamaño de diapositiva
  - cambiar tamaño de diapositiva
  - tamaño de diapositiva personalizado
  - tamaño de diapositiva especial
  - tamaño de diapositiva único
  - diapositiva de tamaño completo
  - tipo de pantalla
  - no escalar
  - ajustar
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

Aspose.Slides ofrece herramientas completas para ajustar el tamaño y la relación de aspecto de la diapositiva en presentaciones de PowerPoint, crucial tanto para la impresión como para la visualización en pantalla.

Tamaños y relaciones de aspecto más habituales:

- **Estándar (relación 4:3)**: Ideal para pantallas y dispositivos antiguos.
- **Panorámico (relación 16:9)**: Recomendado para proyectores y pantallas modernas.

Asegúrese de mantener la coherencia en toda la presentación, ya que un único tamaño y relación de aspecto se aplican a todas las diapositivas. Para obtener resultados óptimos, establezca las dimensiones de la diapositiva al inicio del proceso de creación de la presentación y evite complicaciones.

{{% alert color="info" title="Nota" %}}
Por defecto, las presentaciones creadas con Aspose.Slides utilizan la relación de aspecto estándar 4:3.
{{% /alert %}}

Las páginas de notas y de folletos tienen dimensiones distintas a las diapositivas habituales. Consulte [Tamaño de la página de notas](/slides/es/androidjava/notes-size/) para cambiar su tamaño y orientación.

## **Cambiar el tamaño de la diapositiva en presentaciones**

 Este fragmento de código muestra cómo cambiar el tamaño de la diapositiva en una presentación en Java mediante Aspose.Slides:

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

Si los tamaños de diapositiva habituales (4:3 y 16:9) no se adaptan a su trabajo, puede optar por un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas a tamaño completo desde su presentación en un diseño de página personalizado o si desea mostrar la presentación en ciertos tipos de pantalla, probablemente le resulte útil establecer un tamaño personalizado para la presentación.

Este fragmento de código muestra cómo usar Aspose.Slides para Android mediante Java para especificar un tamaño de diapositiva personalizado en una presentación en Java:

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

## **Manejar el contenido de la diapositiva después de cambiar el tamaño**

Después de modificar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede distorsionarse. Por defecto, los objetos se redimensionan automáticamente para ajustarse al nuevo tamaño. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puede especificar una configuración que determine cómo Aspose.Slides trata el contenido de las diapositivas.

Según lo que pretenda hacer o conseguir, puede usar cualquiera de estas configuraciones:

- `DoNotScale`

  Si NO desea que los objetos de las diapositivas se redimensionen, utilice esta configuración.

- `EnsureFit`

  Si desea escalar a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de la diapositiva para que todos quepan (de este modo evita perder contenido), utilice esta configuración.

- `Maximize`

  Si desea escalar a un tamaño de diapositiva mayor y necesita que Aspose.Slides agrande los objetos de la diapositiva para que sean proporcionales al nuevo tamaño, utilice esta configuración.

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

**¿Puedo establecer un tamaño de diapositiva personalizado utilizando unidades distintas a pulgadas (por ejemplo, puntos o milímetros)?**

Sí. Aspose.Slides usa puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.

**¿Un tamaño de diapositiva personalizado muy grande afectará al rendimiento y al uso de memoria durante el renderizado?**

Sí. Dimensiones de diapositiva mayores (en puntos) combinadas con una escala de renderizado más alta provocan un mayor consumo de memoria y tiempos de procesamiento más largos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado solo cuando sea necesario para lograr la calidad de salida deseada.

**¿Puedo definir un tamaño de diapositiva no estándar y luego combinar diapositivas de presentaciones que tengan tamaños diferentes?**

No puede [fusionar presentaciones](/slides/es/androidjava/merge-presentation/) mientras tengan tamaños de diapositiva distintos; primero, redimensione una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se trata el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slidesizescaletype/). Tras alinear los tamaños, puede combinar diapositivas conservando el formato.

**¿Puedo generar miniaturas de formas individuales o de regiones específicas de una diapositiva, y respetarán el nuevo tamaño de la diapositiva?**

Sí. Aspose.Slides puede generar miniaturas para [diapositivas completas](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) así como para [formas seleccionadas](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Las imágenes resultantes reflejan el tamaño y la relación de aspecto actuales de la diapositiva, asegurando un encuadre y una geometría coherentes.