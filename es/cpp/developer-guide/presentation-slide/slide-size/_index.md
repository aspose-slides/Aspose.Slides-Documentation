---
title: Cambiar el tamaño de diapositiva de la presentación en C++
linktitle: Tamaño de diapositiva
type: docs
weight: 70
url: /es/cpp/slide-size/
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
- C++
- Aspose.Slides
descriptions: "Aprenda a redimensionar rápidamente diapositivas en archivos PPT, PPTX y ODP con C++ y Aspose.Slides, optimice presentaciones para cualquier pantalla sin perder calidad."
---

## **Tamaños de diapositiva en presentaciones de PowerPoint**

Aspose.Slides for C++ le permite cambiar el tamaño de la diapositiva o la relación de aspecto en presentaciones de PowerPoint. Si planea imprimir su presentación o mostrar sus diapositivas en una pantalla, debe prestar atención al tamaño de la diapositiva o a la relación de aspecto. 

Estos son los tamaños de diapositiva y relaciones de aspecto más comunes:

- **Estándar (relación de aspecto 4:3)**

  Si su presentación se mostrará o visualizará en dispositivos o pantallas relativamente más antiguos, es posible que desee usar esta configuración. 

- **Pantalla ancha (relación de aspecto 16:9)** 

  Si su presentación se verá en proyectores o pantallas modernas, es posible que desee usar esta configuración. 

No puede usar varios ajustes de tamaño de diapositiva en una sola presentación. Cuando selecciona un tamaño de diapositiva para una presentación, ese ajuste se aplica a todas las diapositivas de la presentación. 

Si prefiere usar un tamaño de diapositiva especial para sus presentaciones, le recomendamos encarecidamente hacerlo pronto. Idealmente, debe especificar su tamaño de diapositiva preferido al principio, es decir, cuando apenas está configurando la presentación—antes de añadir cualquier contenido. De esta manera, evita complicaciones derivadas de cambios (futuros) en el tamaño de las diapositivas. 

{{% alert color="primary" %}} 
 Cuando usa Aspose.Slides para crear una presentación, todas las diapositivas de la presentación obtienen automáticamente el tamaño estándar o la relación de aspecto 4:3. 
{{% /alert %}} 

## **Cambiar el tamaño de la diapositiva en presentaciones**

Este fragmento de código muestra cómo cambiar el tamaño de la diapositiva en una presentación en C++ usando Aspose.Slides:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```


## **Especificar tamaños de diapositiva personalizados en presentaciones**

Si los tamaños de diapositiva habituales (4:3 y 16:9) no son adecuados para su trabajo, puede decidir usar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas a tamaño completo de su presentación en un diseño de página personalizado o si pretende mostrar su presentación en ciertos tipos de pantalla, probablemente se beneficie al usar una configuración de tamaño personalizado para su presentación. 

Este fragmento de código muestra cómo usar Aspose.Slides for C++ para especificar un tamaño de diapositiva personalizado para una presentación en C++:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Tamaño de papel A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```


## **Manejar el contenido de la diapositiva después del cambio de tamaño**

Después de cambiar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede distorsionarse. Por defecto, los objetos se redimensionan automáticamente para ajustarse al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puede especificar un ajuste que determine cómo Aspose.Slides gestiona el contenido de las diapositivas.

Según lo que pretenda hacer o lograr, puede usar cualquiera de estos ajustes:

- `DoNotScale`

  Si NO desea que los objetos en las diapositivas se redimensionen, use esta configuración.

- `EnsureFit`

  Si desea escalar a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de las diapositivas para asegurarse de que todos quepan en las diapositivas (de esta forma evita perder contenido), use esta configuración. 

- `Maximize`

  Si desea escalar a un tamaño de diapositiva más grande y necesita que Aspose.Slides aumente los objetos de las diapositivas para que sean proporcionales al nuevo tamaño, use esta configuración. 

Este fragmento de código muestra cómo usar el ajuste `Maximize` al cambiar el tamaño de la diapositiva de una presentación:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```


## **Preguntas frecuentes**

**¿Puedo establecer un tamaño de diapositiva personalizado usando unidades distintas de pulgadas (por ejemplo, puntos o milímetros)?**

Sí. Aspose.Slides usa puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.

**¿Un tamaño de diapositiva personalizado muy grande afectará al rendimiento y al uso de memoria durante el renderizado?**

Sí. Dimensiones de diapositiva mayores (en puntos) combinadas con una escala de renderizado alta provocan un mayor consumo de memoria y tiempos de procesamiento más largos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado solo cuando sea necesario para lograr la calidad de salida deseada.

**¿Puedo definir un solo tamaño de diapositiva no estándar y luego combinar diapositivas de presentaciones que tengan tamaños diferentes?**

No puede [merge presentations](/slides/es/cpp/merge-presentation/) mientras tengan tamaños de diapositiva diferentes; primero, cambie el tamaño de una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se maneja el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/). Después de alinear los tamaños, puede combinar diapositivas manteniendo el formato.

**¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de la diapositiva?**

Sí. Aspose.Slides puede renderizar miniaturas para [entire slides](https://reference.aspose.com/slides/cpp/aspose.slides/slide/getimage/) así como para [selected shapes](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/). Las imágenes resultantes reflejan el tamaño de diapositiva y la relación de aspecto actuales, garantizando un encuadre y una geometría consistentes.