---
title: Cambiar el tamaño de la diapositiva de la presentación en Java
linktitle: Tamaño de diapositiva
type: docs
weight: 70
url: /es/java/slide-size/
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
- diapositiva a tamaño completo
- tipo de pantalla
- no escalar
- ajustar para encajar
- maximizar
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Aprenda a cambiar rápidamente el tamaño de las diapositivas en archivos PPT, PPTX y ODP con Java y Aspose.Slides, y optimice presentaciones para cualquier pantalla sin perder calidad."
---
## **Introducción**

Aspose.Slides ofrece herramientas completas para ajustar el tamaño y la relación de aspecto de las diapositivas en presentaciones de PowerPoint, esenciales tanto para la impresión como para la visualización en pantalla.

Tamaños y relaciones de diapositivas populares:

- **Estándar (relación de aspecto 4:3)**: Ideal para pantallas y dispositivos antiguos.
- **Panorámico (relación de aspecto 16:9)**: Recomendado para proyectores y pantallas modernas.

Asegúrese de mantener la coherencia en toda su presentación, ya que un único tamaño y relación de aspecto se aplican a todas las diapositivas. Para obtener resultados óptimos, establezca las dimensiones de sus diapositivas al comienzo del proceso de creación de la presentación para evitar complicaciones.

{{% alert color="primary" %}} 
Por defecto, las presentaciones creadas con Aspose.Slides usan la relación de aspecto estándar 4:3.
{{% /alert %}}

## **Cambiar el tamaño de la diapositiva en presentaciones**

Este fragmento de código muestra cómo cambiar el tamaño de la diapositiva en una presentación en Java usando Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Especificar tamaños de diapositiva personalizados en presentaciones**

Si los tamaños de diapositiva comunes (4:3 y 16:9) no se adaptan a su trabajo, puede decidir utilizar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas a tamaño completo desde su presentación en un diseño de página personalizado o si desea mostrar su presentación en ciertos tipos de pantalla, probablemente le beneficie usar una configuración de tamaño personalizada para su presentación.

Este fragmento de código muestra cómo usar Aspose.Slides para Java para especificar un tamaño de diapositiva personalizado para una presentación en Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // tamaño de papel A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestionar el contenido de la diapositiva después de redimensionar**

Después de cambiar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede deformarse. Por defecto, los objetos se redimensionan automáticamente para ajustarse al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puede especificar una configuración que determina cómo Aspose.Slides trata el contenido de las diapositivas.

Según lo que pretenda hacer o lograr, puede usar cualquiera de estas configuraciones:

- `DoNotScale`

  Si NO desea que los objetos en las diapositivas sean redimensionados, use esta configuración.

- `EnsureFit`

  Si desea escalar a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de las diapositivas para asegurarse de que todos encajen en las diapositivas (de este modo, evita perder contenido), use esta configuración.

- `Maximize`

  Si desea escalar a un tamaño de diapositiva más grande y necesita que Aspose.Slides aumente los objetos de las diapositivas para que sean proporcionales al nuevo tamaño, use esta configuración.

Este fragmento de código muestra cómo usar la configuración `Maximize` al cambiar el tamaño de la diapositiva de una presentación:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo establecer un tamaño de diapositiva personalizado usando unidades distintas a pulgadas (por ejemplo, puntos o milímetros)?**

Sí. Aspose.Slides usa puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.

**¿Afectará un tamaño de diapositiva personalizado muy grande al rendimiento y al uso de memoria durante la renderización?**

Sí. Dimensiones de diapositiva mayores (en puntos) combinadas con una escala de renderizado más alta provocan un mayor consumo de memoria y tiempos de procesamiento más extensos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado solo cuando sea necesario para lograr la calidad de salida deseada.

**¿Puedo definir un tamaño de diapositiva no estándar y luego fusionar diapositivas de presentaciones que tienen tamaños diferentes?**

No puede [fusionar presentaciones](/slides/es/java/merge-presentation/) mientras tengan diferentes tamaños de diapositiva — primero, redimensione una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se manejan los contenidos existentes mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/es/java/com.aspose.slides/slidesizescaletype/). Después de alinear los tamaños, puede fusionar diapositivas conservando el formato.

**¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de la diapositiva?**

Sí. Aspose.Slides puede generar miniaturas para [diapositivas completas](https://reference.aspose.com/slides/es/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) así como para [formas seleccionadas](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/#getImage-int-float-float-). Las imágenes resultantes reflejan el tamaño y la relación de aspecto actuales de la diapositiva, garantizando un encuadre y una geometría coherentes.