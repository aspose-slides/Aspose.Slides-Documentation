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
- pantalla ancha
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
- asegurar ajuste
- maximizar
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
descriptions: "Aprenda a cambiar rápidamente el tamaño de las diapositivas en archivos PPT, PPTX y ODP con Java y Aspose.Slides, optimice presentaciones para cualquier pantalla sin perder calidad."
---

## **Tamaños de diapositivas en presentaciones de PowerPoint**

Aspose.Slides for Java le permite cambiar el tamaño de la diapositiva o la relación de aspecto en presentaciones de PowerPoint. Si planea imprimir su presentación o mostrar sus diapositivas en una pantalla, debe prestar atención al tamaño de la diapositiva o a la relación de aspecto.

Estos son los tamaños de diapositiva y relaciones de aspecto más comunes:

- **Estándar (relación de aspecto 4:3)**

  Si su presentación se mostrará o visualizará en dispositivos o pantallas relativamente más antiguos, es posible que desee usar esta configuración.

- **Pantalla ancha (relación de aspecto 16:9)**

  Si su presentación se verá en proyectores o pantallas modernas, es posible que desee usar esta configuración.

No puede usar múltiples configuraciones de tamaño de diapositiva en una sola presentación. Cuando selecciona un tamaño de diapositiva para una presentación, esa configuración se aplica a todas las diapositivas de la presentación.

Si prefiere usar un tamaño de diapositiva especial para sus presentaciones, le recomendamos encarecidamente hacerlo temprano. Idealmente, debe especificar su diapositiva preferida al principio, es decir, cuando solo está configurando la presentación—antes de añadir cualquier contenido a la presentación. De esta manera, evita complicaciones derivadas de cambios (futuros) en el tamaño de las diapositivas.

{{% alert color="primary" %}} 
Cuando usa Aspose.Slides para crear una presentación, todas las diapositivas de la presentación obtienen automáticamente el tamaño estándar o la relación de aspecto 4:3.
{{% /alert %}} 

## **Cambiar el tamaño de la diapositiva en presentaciones**

Este código de ejemplo le muestra cómo cambiar el tamaño de la diapositiva en una presentación en Java usando Aspose.Slides:
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

Si considera que los tamaños de diapositiva habituales (4:3 y 16:9) no son adecuados para su trabajo, puede decidir usar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas a tamaño completo de su presentación en un diseño de página personalizado o si pretende mostrar su presentación en ciertos tipos de pantalla, probablemente se beneficie de usar una configuración de tamaño personalizado para su presentación.

Este código de ejemplo le muestra cómo usar Aspose.Slides for Java para especificar un tamaño de diapositiva personalizado para una presentación en Java:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // tamaño de papel A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Manejar el contenido de la diapositiva después de cambiar el tamaño**

Después de cambiar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede distorsionarse. De forma predeterminada, los objetos se redimensionan automáticamente para ajustarse al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puede especificar una configuración que determina cómo Aspose.Slides maneja el contenido de las diapositivas.

Dependiendo de lo que pretenda hacer o lograr, puede usar cualquiera de estas configuraciones:

- `DoNotScale`

  Si NO desea que los objetos en las diapositivas se redimensionen, use esta configuración.

- `EnsureFit`

  Si desea escalar a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de las diapositivas para garantizar que todos quepan en las diapositivas (de esta manera, evita perder contenido), use esta configuración.

- `Maximize`

  Si desea escalar a un tamaño de diapositiva mayor y necesita que Aspose.Slides agrande los objetos de las diapositivas para que sean proporcionales al nuevo tamaño de la diapositiva, use esta configuración.

Este código de ejemplo le muestra cómo usar la configuración `Maximize` al cambiar el tamaño de la diapositiva de una presentación:
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

**¿Un tamaño de diapositiva personalizado muy grande afectará el rendimiento y el uso de memoria durante el renderizado?**

Sí. Dimensiones de diapositiva mayores (en puntos) combinadas con una escala de renderizado más alta conducen a un mayor consumo de memoria y tiempos de procesamiento más largos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado solo según sea necesario para lograr la calidad de salida deseada.

**¿Puedo definir un tamaño de diapositiva no estándar y luego fusionar diapositivas de presentaciones que tienen tamaños diferentes?**

No puede [fusionar presentaciones](/slides/es/java/merge-presentation/) mientras tengan diferentes tamaños de diapositiva — primero, cambie el tamaño de una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se maneja el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/). Después de alinear los tamaños, puede fusionar diapositivas preservando el formato.

**¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de la diapositiva?**

Sí. Aspose.Slides puede renderizar miniaturas para [diapositivas completas](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) así como para [formas seleccionadas](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-). Las imágenes resultantes reflejan el tamaño y la relación de aspecto actuales de la diapositiva, asegurando un encuadre y una geometría consistentes.