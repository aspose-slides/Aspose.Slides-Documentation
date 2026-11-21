---
title: Cambiar el tamaño de la diapositiva de la presentación en C++
linktitle: Tamaño de diapositiva
type: docs
weight: 70
url: /es/cpp/slide-size/
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
- asegurar ajuste
- maximizar
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aprenda a redimensionar rápidamente diapositivas en archivos PPT, PPTX y ODP con C++ y Aspose.Slides, optimice presentaciones para cualquier pantalla sin perder calidad."
---
## **Introducción**

Aspose.Slides ofrece herramientas completas para ajustar el tamaño y la relación de aspecto de las diapositivas en presentaciones de PowerPoint, algo crítico tanto para la impresión como para la visualización en pantalla. 

Tamaños y relaciones de aspecto más habituales:

- **Standard (4:3 Aspect Ratio)**: Ideal para pantallas y dispositivos más antiguos.  
- **Widescreen (16:9 Aspect Ratio)**: Recomendado para proyectores y pantallas modernos.  

Asegúrese de mantener la consistencia en toda su presentación, ya que un único tamaño y relación de aspecto se aplican a todas las diapositivas. Para obtener resultados óptimos, establezca las dimensiones de sus diapositivas al comienzo del proceso de creación de la presentación y evite complicaciones posteriores.

{{% alert color="info" %}} 
Por defecto, las presentaciones creadas con Aspose.Slides utilizan la relación de aspecto estándar 4:3. 
{{% /alert %}}

Las páginas de notas y de folletos tienen dimensiones distintas a las diapositivas habituales. Consulte [Tamaño de página de notas](/slides/es/cpp/notes-size/) para cambiar su tamaño y orientación.

## **Cambiar el tamaño de la diapositiva en presentaciones**

Este fragmento de código muestra cómo cambiar el tamaño de la diapositiva en una presentación en C++ usando Aspose.Slides:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Especificar tamaños de diapositiva personalizados en presentaciones**

Si los tamaños habituales (4:3 y 16:9) no se ajustan a sus necesidades, puede decidir usar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas a tamaño completo en un diseño de página personalizado o si desea mostrar su presentación en ciertos tipos de pantalla, probablemente le beneficie definir una configuración de tamaño personalizada para su presentación. 

Este fragmento de código muestra cómo usar Aspose.Slides para C++ para especificar un tamaño de diapositiva personalizado en C++:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Tamaño de papel A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Gestionar el contenido de la diapositiva después de redimensionar**

Tras cambiar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede distorsionarse. Por defecto, los objetos se redimensionan automáticamente para ajustarse al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva, puede especificar una opción que determina cómo Aspose.Slides trata el contenido de las diapositivas.

Según lo que pretenda hacer o conseguir, puede usar cualquiera de estas opciones:

- `DoNotScale`

  Si NO desea que los objetos de las diapositivas se redimensionen, utilice esta opción.

- `EnsureFit`

  Si quiere escalar a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de las diapositivas para que todos quepan (evitando así la pérdida de contenido), utilice esta opción. 

- `Maximize`

  Si quiere escalar a un tamaño de diapositiva mayor y necesita que Aspose.Slides aumente los objetos de las diapositivas para que sean proporcionales al nuevo tamaño, utilice esta opción. 

Este fragmento de código muestra cómo usar la opción `Maximize` al cambiar el tamaño de la diapositiva de una presentación:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **Preguntas frecuentes**

### ¿Puedo establecer un tamaño de diapositiva personalizado usando unidades distintas a pulgadas (por ejemplo, puntos o milímetros)?

Sí. Aspose.Slides utiliza puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.

### ¿Afectará a rendimiento y uso de memoria una diapositiva personalizada muy grande durante el renderizado?

Sí. Dimensiones de diapositiva mayores (en puntos) combinadas con una escala de renderizado alta incrementan el consumo de memoria y los tiempos de procesamiento. Procure un tamaño de diapositiva práctico y ajuste la escala de renderizado solo cuando sea necesario para obtener la calidad deseada.

### ¿Puedo definir un tamaño de diapositiva no estándar y luego combinar diapositivas de presentaciones que tengan tamaños diferentes?

No puede [combinar presentaciones](/slides/es/cpp/merge-presentation/) mientras sus tamaños de diapositiva sean diferentes; primero redimensione una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se maneja el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/es/cpp/aspose.slides/slidesizescaletype/). Tras alinear los tamaños, podrá combinar diapositivas conservando el formato.

### ¿Puedo generar miniaturas de formas individuales o de regiones específicas de una diapositiva, y respetarán el nuevo tamaño de diapositiva?

Sí. Aspose.Slides puede generar miniaturas para [diapositivas completas](https://reference.aspose.com/slides/es/cpp/aspose.slides/slide/getimage/) así como para [formas seleccionadas](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/getimage/). Las imágenes resultantes reflejan el tamaño y la relación de aspecto actuales de la diapositiva, garantizando un encuadre y geometría consistentes.