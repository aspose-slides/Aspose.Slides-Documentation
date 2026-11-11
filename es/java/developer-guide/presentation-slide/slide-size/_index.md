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
- diapositiva a tamaño completo
- tipo de pantalla
- no escalar
- garantizar ajuste
- maximizar
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Aprenda a redimensionar rápidamente diapositivas en archivos PPT, PPTX y ODP con Java y Aspose.Slides, y a optimizar presentaciones para cualquier pantalla sin perder calidad."
---
## **Introducción**

Aspose.Slides ofrece herramientas completas para ajustar el tamaño de la diapositiva y la relación de aspecto en presentaciones de PowerPoint, lo que es fundamental tanto para la impresión como para la visualización en pantalla.

Tamaños de diapositiva y relaciones de aspecto populares:

- **Estándar (relación de aspecto 4:3)**: Ideal para pantallas y dispositivos más antiguos.
- **Pantalla ancha (relación de aspecto 16:9)**: Recomendado para proyectores y pantallas modernas.

Asegúrese de mantener la coherencia en toda su presentación, ya que un único tamaño de diapositiva y una única relación de aspecto se aplican a todas las diapositivas. Para obtener resultados óptimos, establezca las dimensiones de la diapositiva al comienzo del proceso de creación de la presentación y evite complicaciones posteriores.

{{% alert color="info" title="Note" %}}
Por defecto, las presentaciones creadas con Aspose.Slides utilizan la relación de aspecto estándar 4:3.
{{% /alert %}}

Las páginas de notas y de folletos tienen dimensiones distintas a las diapositivas normales. Consulte [Tamaño de página de notas](/slides/es/java/notes-size/) para cambiar su tamaño y orientación.

## **Cambiar el tamaño de la diapositiva en presentaciones**

Este código de ejemplo muestra cómo cambiar el tamaño de la diapositiva en una presentación en Java usando Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Especificar tamaños de diapositiva personalizados en presentaciones**

Si los tamaños de diapositiva comunes (4:3 y 16:9) no se adaptan a su trabajo, puede decidir utilizar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas a tamaño completo desde su presentación en un diseño de página personalizado o si pretende mostrar su presentación en ciertos tipos de pantalla, probablemente se beneficiará de usar una configuración de tamaño personalizada para su presentación.

Este código de ejemplo muestra cómo usar Aspose.Slides para Java para especificar un tamaño de diapositiva personalizado en una presentación en Java:

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

Después de cambiar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede deformarse. Por defecto, los objetos se redimensionan automáticamente para ajustarse al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puede especificar una configuración que determine cómo Aspose.Slides trata el contenido de las diapositivas.

Según lo que pretenda hacer o conseguir, puede usar cualquiera de estas configuraciones:

- `DoNotScale`

  Si NO desea que los objetos de las diapositivas se redimensionen, utilice esta configuración.

- `EnsureFit`

  Si desea escalar a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de las diapositivas para garantizar que todos encajen (evitando así la pérdida de contenido), utilice esta configuración.

- `Maximize`

  Si desea escalar a un tamaño de diapositiva mayor y necesita que Aspose.Slides aumente los objetos de las diapositivas para que sean proporcionales al nuevo tamaño, utilice esta configuración.

Este código de ejemplo muestra cómo usar la configuración `Maximize` al cambiar el tamaño de la diapositiva de una presentación:

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

**¿Puedo establecer un tamaño de diapositiva personalizado usando unidades distintas a pulgadas (por ejemplo, puntos o milímetros)?**

Sí. Aspose.Slides utiliza puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.

**¿Un tamaño de diapositiva personalizado muy grande afectará al rendimiento y al uso de memoria durante el renderizado?**

Sí. Dimensiones de diapositiva mayores (en puntos) combinadas con una escala de renderizado más alta generan un mayor consumo de memoria y tiempos de procesamiento más largos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado solo cuando sea necesario para lograr la calidad de salida deseada.

**¿Puedo definir un tamaño de diapositiva no estándar y luego combinar diapositivas de presentaciones que tengan tamaños diferentes?**

No puede [merge presentations](/slides/es/java/merge-presentation/) mientras tengan tamaños de diapositiva distintos; primero, cambie el tamaño de una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se maneja el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/es/java/com.aspose.slides/slidesizescaletype/). Después de alinear los tamaños, puede combinar diapositivas conservando el formato.

**¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de la diapositiva?**

Sí. Aspose.Slides puede generar miniaturas para [diapositivas completas](https://reference.aspose.com/slides/es/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) así como para [formas seleccionadas](https://reference.aspose.com/slides/es/java/com.aspose.slides/shape/#getImage-int-float-float-). Las imágenes resultantes reflejan el tamaño y la relación de aspecto actuales de la diapositiva, garantizando un encuadre y una geometría consistentes.