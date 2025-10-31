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
- asegurar ajuste
- maximizar
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
descriptions: "Aprenda cómo cambiar rápidamente el tamaño de diapositivas en archivos PPT, PPTX y ODP con Python y Aspose.Slides, optimice presentaciones para cualquier pantalla sin perder calidad."
---

## Tamaños de diapositiva en presentaciones de PowerPoint

Aspose.Slides for Python via .NET permite cambiar el tamaño o la relación de aspecto de las diapositivas en presentaciones de PowerPoint. Si planea imprimir su presentación o mostrar sus diapositivas en una pantalla, debe prestar atención al tamaño o la relación de aspecto de las diapositivas.

Estos son los tamaños y relaciones de aspecto de diapositiva más comunes:

- **Estándar (relación de aspecto 4:3)**

  Si su presentación se mostrará o visualizará en dispositivos o pantallas relativamente más antiguos, puede que desee usar esta configuración.

- **Pantalla ancha (relación de aspecto 16:9)**

  Si su presentación se verá en proyectores o pantallas modernas, puede que desee usar esta configuración.

No puede usar varias configuraciones de tamaño de diapositiva en una sola presentación. Cuando selecciona un tamaño de diapositiva para una presentación, esa configuración se aplica a todas las diapositivas de la presentación.

Si prefiere usar un tamaño de diapositiva especial para sus presentaciones, le recomendamos encarecidamente hacerlo al principio. Idealmente, debe especificar su tamaño de diapositiva preferido al inicio, es decir, cuando está configurando la presentación, antes de agregar cualquier contenido. De esta manera, evita complicaciones resultantes de cambios (futuros) en el tamaño de las diapositivas.

{{% alert color="primary" %}} 
Cuando usa Aspose.Slides para crear una presentación, todas las diapositivas se configuran automáticamente al tamaño estándar o relación de aspecto 4:3.
{{% /alert %}} 

## Cambiar el tamaño de la diapositiva en presentaciones

Este fragmento de código muestra cómo cambiar el tamaño de la diapositiva en una presentación en Python usando Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## Especificar tamaños de diapositiva personalizados en presentaciones

Si los tamaños de diapositiva comunes (4:3 y 16:9) no son adecuados para su trabajo, puede decidir usar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas a tamaño completo desde su presentación en un diseño de página personalizado o si pretende mostrar su presentación en ciertos tipos de pantalla, probablemente se beneficie de usar una configuración de tamaño personalizada para su presentación.

Este fragmento de código muestra cómo usar Aspose.Slides for Python via .NET para especificar un tamaño de diapositiva personalizado para una presentación en Python:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # Tamaño de papel A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## Tratamiento de problemas al cambiar el tamaño de las diapositivas en presentaciones

Después de cambiar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede deformarse. Por defecto, los objetos se redimensionan automáticamente para adaptarse al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puede especificar una configuración que determina cómo Aspose.Slides trata el contenido de las diapositivas.

Según lo que pretenda hacer o lograr, puede usar cualquiera de estas configuraciones:

- `DO_NOT_SCALE`

  Si NO desea que los objetos en las diapositivas se redimensionen, use esta configuración.

- `ENSURE_FIT`

  Si desea escalar a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de las diapositivas para garantizar que todos encajen (de este modo evita perder contenido), use esta configuración.

- `MAXIMIZE`

  Si desea escalar a un tamaño de diapositiva mayor y necesita que Aspose.Slides aumente los objetos de las diapositivas para que sean proporcionales al nuevo tamaño, use esta configuración.

Este fragmento de código muestra cómo usar la configuración `MAXIMIZE` al cambiar el tamaño de la diapositiva de una presentación:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**¿Puedo establecer un tamaño de diapositiva personalizado usando unidades diferentes a pulgadas (por ejemplo, puntos o milímetros)?**

Sí. Aspose.Slides usa puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.

**¿Un tamaño de diapositiva personalizado muy grande afectará el rendimiento y el uso de memoria durante la renderización?**

Sí. Dimensiones de diapositiva mayores (en puntos) combinadas con una escala de renderizado alta conducen a mayor consumo de memoria y tiempos de procesamiento más largos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado solo cuando sea necesario para lograr la calidad deseada.

**¿Puedo definir un único tamaño de diapositiva no estándar y luego combinar diapositivas de presentaciones que tienen diferentes tamaños?**

No puede [merge presentations](/slides/es/python-net/merge-presentation/) mientras tengan tamaños de diapositiva diferentes; primero, cambie el tamaño de una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se maneja el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/). Después de alinear los tamaños, puede combinar diapositivas preservando el formato.

**¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de diapositiva?**

Sí. Aspose.Slides puede generar miniaturas para [entire slides](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) así como para [selected shapes](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/). Las imágenes resultantes reflejan el tamaño y la relación de aspecto actuales de la diapositiva, asegurando un encuadre y geometría consistentes.