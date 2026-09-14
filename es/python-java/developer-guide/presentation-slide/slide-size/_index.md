---
title: Cambiar el tamaño de la diapositiva de la presentación en Python a través de Java
linktitle: Tamaño de diapositiva
type: docs
weight: 70
url: /es/python-java/slide-size/
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
- ajustar
- maximizar
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda a cambiar rápidamente el tamaño de las diapositivas en archivos PPT, PPTX y ODP con Python a través de Java y Aspose.Slides, y optimice presentaciones para cualquier pantalla sin perder calidad."
---
## **Introducción**

Aspose.Slides proporciona herramientas completas para ajustar el tamaño de la diapositiva y la relación de aspecto en presentaciones de PowerPoint, esencial tanto para la impresión como para la visualización en pantalla.

Tamaños y relaciones de diapositiva populares:

- **Estándar (relación 4:3)**: Ideal para pantallas y dispositivos más antiguos.
- **Pantalla ancha (relación 16:9)**: Recomendado para proyectores y pantallas modernos.

Asegúrese de mantener la consistencia en toda su presentación, ya que un único tamaño de diapositiva y relación de aspecto se aplica a todas las diapositivas. Para obtener resultados óptimos, establezca las dimensiones de sus diapositivas al inicio del proceso de creación de la presentación para evitar complicaciones.

{{% alert color="info" title="Note" %}}
Por defecto, las presentaciones creadas con Aspose.Slides utilizan la relación de aspecto estándar 4:3.
{{% /alert %}}

## **Cambiar el tamaño de la diapositiva en presentaciones**

Este fragmento de código muestra cómo cambiar el tamaño de la diapositiva en una presentación en Python a través de Java usando Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Especificar tamaños de diapositiva personalizados en presentaciones**

Si encuentra que los tamaños de diapositiva comunes (4:3 y 16:9) no son adecuados para su trabajo, puede decidir usar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas a tamaño completo de su presentación en un diseño de página personalizado o si pretende mostrar su presentación en ciertos tipos de pantalla, probablemente se beneficie de usar una configuración de tamaño personalizado para su presentación.

Este fragmento de código muestra cómo usar Aspose.Slides para Python a través de Java para especificar un tamaño de diapositiva personalizado para una presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gestionar el contenido de la diapositiva después de redimensionar**

Después de cambiar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (por ejemplo, imágenes u objetos) puede distorsionarse. Por defecto, los objetos se redimensionan automáticamente para ajustarse al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puede especificar una configuración que determine cómo Aspose.Slides trata el contenido de las diapositivas.

Según lo que pretenda hacer o lograr, puede usar cualquiera de estas configuraciones:

- [DoNotScale](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  Si NO desea que los objetos en las diapositivas se redimensionen, use esta configuración.

- [EnsureFit](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  Si desea escalar a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de las diapositivas para asegurarse de que todos caben en ellas (de este modo, evita perder contenido), use esta configuración.

- [Maximize](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesizescaletype/#Maximize)

  Si desea escalar a un tamaño de diapositiva más grande y necesita que Aspose.Slides amplíe los objetos de las diapositivas para que sean proporcionales al nuevo tamaño, use esta configuración.

Este fragmento de código muestra cómo usar la [Maximize](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesizescaletype/#Maximize) configuración al cambiar el tamaño de la diapositiva de una presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo establecer un tamaño de diapositiva personalizado usando unidades distintas a pulgadas (por ejemplo, puntos o milímetros)?**

Sí. Aspose.Slides usa puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y alto de la diapositiva.

**¿Afectará un tamaño de diapositiva personalizado muy grande al rendimiento y al uso de memoria durante el renderizado?**

Sí. Dimensiones de diapositiva mayores (en puntos) combinadas con una escala de renderizado más alta provocan un mayor consumo de memoria y tiempos de procesamiento más largos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado solo cuando sea necesario para lograr la calidad de salida deseada.

**¿Puedo definir un tamaño de diapositiva no estándar y luego combinar diapositivas de presentaciones que tengan tamaños diferentes?**

No puede [merge presentations](/slides/es/python-java/merge-presentation/) mientras tengan diferentes tamaños de diapositiva — primero, cambie el tamaño de una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se maneja el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesizescaletype/). Después de alinear los tamaños, puede combinar diapositivas conservando el formato.

**¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de la diapositiva?**

Sí. Aspose.Slides puede generar miniaturas para [entire slides](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage) así como para [selected shapes](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage). Las imágenes resultantes reflejan el tamaño y la relación de aspecto actuales de la diapositiva, garantizando un encuadre y geometría consistentes.