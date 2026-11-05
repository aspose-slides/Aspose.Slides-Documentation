---
title: Cambiar el tamaño de la diapositiva de la presentación en PHP
linktitle: Tamaño de diapositiva
type: docs
weight: 70
url: /es/php-java/slide-size/
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
- PHP
- Aspose.Slides
description: "Aprenda a redimensionar rápidamente diapositivas en archivos PPT, PPTX y ODP con PHP y Aspose.Slides, optimice presentaciones para cualquier pantalla sin perder calidad."
---
## **Introducción**

Aspose.Slides ofrece herramientas completas para ajustar el tamaño y la relación de aspecto de las diapositivas en presentaciones de PowerPoint, lo que resulta crítico tanto para la impresión como para la visualización en pantalla. 

Tamaños y relaciones de diapositiva populares:

- **Estándar (relación de aspecto 4:3)**: Ideal para pantallas y dispositivos más antiguos.
- **Panorámico (relación de aspecto 16:9)**: Recomendado para proyectores y pantallas modernos.

Asegúrese de mantener la consistencia en toda la presentación, ya que un único tamaño y relación de aspecto de diapositiva se aplica a todas las diapositivas. Para obtener resultados óptimos, establezca las dimensiones de sus diapositivas al comienzo del proceso de creación de la presentación y evite complicaciones.

{{% alert color="info" title="Note" %}}
Por defecto, las presentaciones creadas con Aspose.Slides utilizan la relación de aspecto estándar 4:3.
{{% /alert %}}

Las páginas de notas y de folletos tienen dimensiones distintas de las diapositivas normales. Consulte [Tamaño de la página de notas](/slides/es/php-java/notes-size/) para cambiar su tamaño y orientación.

## **Cambiar el tamaño de la diapositiva en presentaciones**

Este fragmento de código muestra cómo cambiar el tamaño de la diapositiva en una presentación usando Aspose.Slides:

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Especificar tamaños de diapositiva personalizados en presentaciones**

Si considera que los tamaños de diapositiva habituales (4:3 y 16:9) no se adaptan a su trabajo, puede decidir usar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas a tamaño completo de su presentación en un diseño de página personalizado o si pretende mostrar su presentación en ciertos tipos de pantalla, es probable que le resulte ventajoso utilizar una configuración de tamaño personalizado para su presentación. 

Este fragmento de código muestra cómo usar Aspose.Slides para PHP a través de Java para especificar un tamaño de diapositiva personalizado para una presentación:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// tamaño de papel A4

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Manejar el contenido de la diapositiva después de cambiar el tamaño**

Después de cambiar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede distorsionarse. Por defecto, los objetos se redimensionan automáticamente para ajustarse al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puede especificar una configuración que determina cómo Aspose.Slides gestiona el contenido de las diapositivas.

Según lo que pretenda hacer o lograr, puede usar cualquiera de estas configuraciones:

- `DoNotScale`

  Si NO desea que los objetos en las diapositivas se redimensionen, utilice esta configuración.

- `EnsureFit`

  Si desea escalar a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de las diapositivas para asegurarse de que todos caben en ellas (de este modo, evita perder contenido), use esta configuración. 

- `Maximize`

  Si desea escalar a un tamaño de diapositiva más grande y necesita que Aspose.Slides aumente los objetos de las diapositivas para que sean proporcionales al nuevo tamaño, use esta configuración. 

Este fragmento de código muestra cómo usar la configuración `Maximize` al cambiar el tamaño de la diapositiva de una presentación:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Preguntas frecuentes**

**¿Puedo establecer un tamaño de diapositiva personalizado usando unidades distintas a pulgadas (por ejemplo, puntos o milímetros)?**

Sí. Aspose.Slides utiliza puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.

**¿Afectará un tamaño de diapositiva personalizado muy grande al rendimiento y al uso de memoria durante el renderizado?**

Sí. Dimensiones de diapositiva más grandes (en puntos) combinadas con una escala de renderizado mayor provocan un mayor consumo de memoria y tiempos de procesamiento más largos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado solo cuando sea necesario para obtener la calidad de salida deseada.

**¿Puedo definir un tamaño de diapositiva no estándar y luego combinar diapositivas de presentaciones que tengan tamaños diferentes?**

No puede [combinar presentaciones](/slides/es/php-java/merge-presentation/) mientras tengan diferentes tamaños de diapositiva; primero, redimensione una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se trata el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidesizescaletype/). Después de alinear los tamaños, puede combinar diapositivas conservando el formato.

**¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de la diapositiva?**

Sí. Aspose.Slides puede generar miniaturas para [diapositivas completas](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#getImage) así como para [formas seleccionadas](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/#getImage). Las imágenes resultantes reflejan el tamaño y la relación de aspecto actuales de la diapositiva, garantizando un encuadre y geometría coherentes.