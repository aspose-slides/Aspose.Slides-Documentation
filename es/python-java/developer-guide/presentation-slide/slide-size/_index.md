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
description: "Aprenda a redimensionar rápidamente diapositivas en archivos PPT, PPTX y ODP con Python a través de Java y Aspose.Slides, y optimice presentaciones para cualquier pantalla sin perder calidad."
---
## **Introducción**

Aspose.Slides proporciona herramientas completas para ajustar el tamaño de la diapositiva y la relación de aspecto en presentaciones de PowerPoint, algo esencial tanto para la impresión como para la visualización en pantalla.

Tamaños de diapositiva y relaciones de aspecto más habituales:

- **Estándar (relación de aspecto 4:3)**: Ideal para pantallas y dispositivos antiguos.
- **Pantalla ancha (relación de aspecto 16:9)**: Recomendada para proyectores y pantallas modernos.

Garantice la coherencia a lo largo de toda la presentación, ya que un único tamaño de diapositiva y una única relación de aspecto se aplican a todas las diapositivas. Para obtener resultados óptimos, establezca las dimensiones de la diapositiva al comienzo del proceso de creación de la presentación y evite complicaciones posteriores.

{{% alert color="info" title="Nota" %}}Por defecto, las presentaciones creadas con Aspose.Slides utilizan la relación de aspecto estándar 4:3.{{% /alert %}}

Las páginas de notas y de folletos tienen dimensiones distintas de las diapositivas normales. Consulte [Tamaño de la página de notas](/slides/es/python-java/notes-size/) para cambiar su tamaño y orientación.

## **Cambiar el tamaño de la diapositiva en presentaciones**

Este fragmento de código muestra cómo cambiar el tamaño de la diapositiva en una presentación en Python a través de Java utilizando Aspose.Slides:

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

Si los tamaños de diapositiva habituales (4:3 y 16:9) no se adaptan a su trabajo, puede optar por usar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas a tamaño completo a partir de su presentación en un diseño de página personalizado o si pretende mostrar la presentación en ciertos tipos de pantalla, probablemente se beneficiará de definir un ajuste de tamaño personalizado para su presentación.

Este fragmento de código muestra cómo utilizar Aspose.Slides para Python a través de Java para especificar un tamaño de diapositiva personalizado en una presentación:

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

## **Gestionar el contenido de la diapositiva después de cambiar el tamaño**

Después de modificar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede quedar distorsionado. Por defecto, los objetos se redimensionan automáticamente para adaptarse al nuevo tamaño de la diapositiva. No obstante, al cambiar el tamaño de la diapositiva de una presentación, puede especificar una configuración que determina cómo Aspose.Slides gestiona el contenido de las diapositivas.

Según lo que pretenda hacer o conseguir, puede utilizar cualquiera de estas configuraciones:

- [DoNotScale](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  Si NO desea que los objetos de las diapositivas se redimensionen, utilice esta configuración.

- [EnsureFit](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  Si desea reducir el tamaño de la diapositiva y necesita que Aspose.Slides reduzca los objetos de las diapositivas para garantizar que todos caben (de este modo, evita la pérdida de contenido), utilice esta configuración.

- [Maximize](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesizescaletype/#Maximize)

  Si desea ampliar el tamaño de la diapositiva y necesita que Aspose.Slides aumente los objetos de las diapositivas para que sean proporcionales al nuevo tamaño, utilice esta configuración.

Este fragmento de código muestra cómo usar la configuración [Maximize](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesizescaletype/#Maximize) al cambiar el tamaño de la diapositiva de una presentación:

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

Sí. Aspose.Slides utiliza puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.

**¿Afectará un tamaño de diapositiva personalizado muy grande al rendimiento y al uso de memoria durante el renderizado?**

Sí. Dimensiones de diapositiva mayores (en puntos) combinadas con una escala de renderizado más alta provocan un mayor consumo de memoria y tiempos de procesamiento más largos. Procure seleccionar un tamaño de diapositiva práctico y ajuste la escala de renderizado solo cuando sea necesario para lograr la calidad de salida deseada.

**¿Puedo definir un tamaño de diapositiva no estándar y luego combinar diapositivas de presentaciones que tengan tamaños diferentes?**

No puede [combinar presentaciones](/slides/es/python-java/merge-presentation/) mientras tengan tamaños de diapositiva diferentes; primero, redimensione una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se maneja el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesizescaletype/). Después de alinear los tamaños, puede combinar diapositivas conservando el formato.

**¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de diapositiva?**

Sí. Aspose.Slides puede generar miniaturas tanto de [diapositivas completas](/slides/es/python-java/aspose.slides/slide/#getImage) como de [formas seleccionadas](/slides/es/python-java/aspose.slides/shape/#getImage). Las imágenes resultantes reflejan el tamaño de diapositiva y la relación de aspecto actuales, garantizando un encuadre y una geometría consistentes.