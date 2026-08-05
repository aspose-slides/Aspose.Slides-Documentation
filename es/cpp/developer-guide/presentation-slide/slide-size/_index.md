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
- diapositiva de tamaño completo
- tipo de pantalla
- no escalar
- ajustar para encajar
- maximizar
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aprenda a redimensionar rápidamente diapositivas en archivos PPT, PPTX y ODP con C++ y Aspose.Slides, y optimice presentaciones para cualquier pantalla sin perder calidad."
---
## **Introducción**

Aspose.Slides ofrece herramientas completas para ajustar el tamaño y la relación de aspecto de las diapositivas en presentaciones PowerPoint, lo cual es crucial tanto para la impresión como para la visualización en pantalla. 

Tamaños y relaciones de diapositiva más comunes:

- **Estándar (relación de aspecto 4:3)**: Ideal para pantallas y dispositivos más antiguos.
- **Panorámico (relación de aspecto 16:9)**: Recomendado para proyectores y pantallas modernas.

Asegúrese de mantener la consistencia en toda la presentación, ya que un único tamaño y relación de aspecto de diapositiva se aplican a todas ellas. Para obtener resultados óptimos, establezca las dimensiones de sus diapositivas al comienzo del proceso de creación de la presentación y así evitará complicaciones.

{{% alert color="primary" %}} 
Por defecto, las presentaciones creadas con Aspose.Slides utilizan la relación de aspecto estándar 4:3.
{{% /alert %}}

## **Cambiar el tamaño de la diapositiva en presentaciones**

Este fragmento de código muestra cómo cambiar el tamaño de la diapositiva en una presentación en C++ utilizando Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Especificar tamaños de diapositiva personalizados en presentaciones**

Si encuentra que los tamaños de diapositiva comunes (4:3 y 16:9) no se adaptan a su trabajo, puede decidir usar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas a tamaño completo de su presentación en un diseño de página personalizado o si pretende mostrar su presentación en ciertos tipos de pantalla, probablemente le resulte útil utilizar una configuración de tamaño personalizado para su presentación. 

Este fragmento de código muestra cómo usar Aspose.Slides para C++ para especificar un tamaño de diapositiva personalizado para una presentación en C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Tamaño de papel A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Gestionar el contenido de la diapositiva después de cambiar el tamaño**

Después de cambiar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede distorsionarse. Por defecto, los objetos se redimensionan automáticamente para adaptarse al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puede especificar una configuración que determina cómo Aspose.Slides trata el contenido de las diapositivas.

Según lo que pretenda hacer o conseguir, puede usar cualquiera de estas configuraciones:

- `DoNotScale`

  Si NO desea que los objetos de las diapositivas se redimensionen, use esta configuración.

- `EnsureFit`

  Si desea reducir a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de las diapositivas para asegurarse de que todos quepan en ellas (de este modo, evita perder contenido), use esta configuración. 

- `Maximize`

  Si desea ampliar a un tamaño de diapositiva mayor y necesita que Aspose.Slides aumente los objetos de las diapositivas para que sean proporcionales al nuevo tamaño, use esta configuración. 

Este fragmento de código muestra cómo usar la configuración `Maximize` al cambiar el tamaño de la diapositiva de una presentación:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **Preguntas frecuentes**

**¿Puedo establecer un tamaño de diapositiva personalizado usando unidades distintas a pulgadas (por ejemplo, puntos o milímetros)?**

Sí. Aspose.Slides utiliza puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.

**¿Afectará un tamaño de diapositiva personalizado muy grande al rendimiento y al uso de memoria durante el renderizado?**

Sí. Dimensiones de diapositiva más grandes (en puntos) combinadas con una escala de renderizado mayor provocan un mayor consumo de memoria y tiempos de procesamiento más largos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado sólo cuando sea necesario para lograr la calidad de salida deseada.

**¿Puedo definir un tamaño de diapositiva no estándar y luego combinar diapositivas de presentaciones que tienen tamaños diferentes?**

No puede [fusionar presentaciones](/slides/es/cpp/merge-presentation/) cuando tienen diferentes tamaños de diapositiva; primero, cambie el tamaño de una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se maneja el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/es/cpp/aspose.slides/slidesizescaletype/). Después de alinear los tamaños, podrá combinar diapositivas manteniendo el formato.

**¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de la diapositiva?**

Sí. Aspose.Slides puede generar miniaturas para [todas las diapositivas](https://reference.aspose.com/slides/es/cpp/aspose.slides/slide/getimage/) así como para [formas seleccionadas](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/getimage/). Las imágenes resultantes reflejan el tamaño y la relación de aspecto actuales de la diapositiva, garantizando un encuadre y una geometría coherentes.