---
title: Cambiar el tamaño de la diapositiva en presentaciones con Python
linktitle: Tamaño de diapositiva
type: docs
weight: 70
url: /es/python-net/slide-size/
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
- ajustar
- maximizar
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprende a cambiar rápidamente el tamaño de las diapositivas en archivos PPT, PPTX y ODP con Python y Aspose.Slides, optimiza presentaciones para cualquier pantalla sin perder calidad."
---
## **Introducción**

Aspose.Slides ofrece herramientas completas para ajustar el tamaño de la diapositiva y la relación de aspecto en presentaciones de PowerPoint, lo que es fundamental tanto para la impresión como para la visualización en pantalla.

Tamaños y relaciones de aspecto de diapositivas más habituales:

- **Estándar (relación de aspecto 4:3)**: Ideal para pantallas y dispositivos más antiguos.
- **Panorámico (relación de aspecto 16:9)**: Recomendado para proyectores y pantallas modernas.

Asegúrese de mantener la coherencia en toda la presentación, ya que un único tamaño de diapositiva y relación de aspecto se aplican a todas las diapositivas. Para obtener resultados óptimos, establezca las dimensiones de su diapositiva al comienzo del proceso de creación de la presentación para evitar complicaciones.

{{% alert color="info" title="Note" %}}
Por defecto, las presentaciones creadas con Aspose.Slides utilizan la relación de aspecto estándar 4:3.
{{% /alert %}}

Las páginas de notas y de folletos tienen dimensiones distintas de las diapositivas normales. Consulte [Tamaño de la página de notas](/slides/es/python-net/notes-size/) para cambiar su tamaño y orientación.

## **Cambiar el tamaño de la diapositiva en una presentación**

Este fragmento de código muestra cómo cambiar el tamaño de la diapositiva en una presentación en Python mediante Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Especificar tamaños de diapositiva personalizados**

Si considera que los tamaños de diapositiva habituales (4:3 y 16:9) no se adaptan a su trabajo, puede decidir utilizar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas a tamaño completo de su presentación en un diseño de página personalizado o si pretende mostrar su presentación en ciertos tipos de pantalla, probablemente se beneficie de usar una configuración de tamaño personalizada para su presentación.

Este fragmento de código muestra cómo usar Aspose.Slides para Python a través de .NET para especificar un tamaño de diapositiva personalizado para una presentación en Python:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # Tamaño de papel A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestionar el contenido de la diapositiva después de cambiar el tamaño**

Después de cambiar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede distorsionarse. Por defecto, los objetos se redimensionan automáticamente para ajustarse al nuevo tamaño de la diapositiva. No obstante, al cambiar el tamaño de la diapositiva de una presentación, puede especificar una configuración que determina cómo Aspose.Slides gestiona el contenido de las diapositivas.

Según lo que pretenda hacer o conseguir, puede utilizar cualquiera de estas configuraciones:

- `DO_NOT_SCALE`

  Si NO desea que los objetos en las diapositivas se redimensionen, utilice esta configuración.

- `ENSURE_FIT`

  Si desea reducir a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de las diapositivas para garantizar que todos quepan en ellas (de este modo, evita la pérdida de contenido), utilice esta configuración.

- `MAXIMIZE`

  Si desea ampliar a un tamaño de diapositiva mayor y necesita que Aspose.Slides aumente los objetos de las diapositivas para que sean proporcionales al nuevo tamaño, utilice esta configuración.

Este fragmento de código muestra cómo usar la configuración `MAXIMIZE` al cambiar el tamaño de la diapositiva de una presentación:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **Preguntas frecuentes**

**¿Puedo establecer un tamaño de diapositiva personalizado usando unidades distintas a pulgadas (por ejemplo, puntos o milímetros)?**

Sí. Aspose.Slides utiliza puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.

**¿Afectará un tamaño de diapositiva personalizado muy grande al rendimiento y al uso de memoria durante la renderización?**

Sí. Dimensiones de diapositiva mayores (en puntos) combinadas con una escala de renderizado más alta provocan un mayor consumo de memoria y tiempos de procesamiento más largos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado solo cuando sea necesario para conseguir la calidad de salida deseada.

**¿Puedo definir un único tamaño de diapositiva no estándar y luego combinar diapositivas de presentaciones que tengan diferentes tamaños?**

No puede [fusionar presentaciones](/slides/es/python-net/merge-presentation/) mientras tengan diferentes tamaños de diapositiva — primero, redimensione una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se gestiona el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidesizescaletype/). Después de alinear los tamaños, puede combinar diapositivas manteniendo el formato.

**¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de la diapositiva?**

Sí. Aspose.Slides puede generar miniaturas tanto para [diapositivas completas](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/get_image/) como para [formas seleccionadas](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/get_image/). Las imágenes resultantes reflejan el tamaño y la relación de aspecto actuales de la diapositiva, garantizando un encuadre y una geometría consistentes.