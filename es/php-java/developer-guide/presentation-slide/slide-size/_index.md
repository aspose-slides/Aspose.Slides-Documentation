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
- pantalla panorámica
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
- PHP
- Aspose.Slides
description: "Aprenda a redimensionar rápidamente diapositivas en archivos PPT, PPTX y ODP con PHP y Aspose.Slides, optimice presentaciones para cualquier pantalla sin perder calidad."
---
## **Introducción**

Aspose.Slides ofrece herramientas completas para ajustar el tamaño de la diapositiva y la relación de aspecto en presentaciones de PowerPoint, lo que es fundamental tanto para la impresión como para la visualización en pantalla.  

Tamaños y relaciones de diapositivas más comunes:

- **Standard (relación de aspecto 4:3)**: Ideal para pantallas y dispositivos antiguos.  
- **Widescreen (relación de aspecto 16:9)**: Recomendado para proyectores y pantallas modernas.  

Asegúrese de mantener la coherencia en toda su presentación, ya que un único tamaño de diapositiva y una única relación de aspecto se aplican a todas las diapositivas. Para obtener resultados óptimos, establezca las dimensiones de la diapositiva al comienzo del proceso de creación de la presentación para evitar complicaciones.

{{% alert color="primary" %}} 
De forma predeterminada, las presentaciones creadas con Aspose.Slides utilizan la relación de aspecto estándar 4:3.
{{% /alert %}}

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

Si considera que los tamaños de diapositiva habituales (4:3 y 16:9) no se adaptan a su trabajo, puede decidir utilizar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas de tamaño completo desde su presentación en un diseño de página personalizado o si desea mostrar su presentación en ciertos tipos de pantalla, probablemente se beneficie de usar una configuración de tamaño personalizado para su presentación.  

Este fragmento de código muestra cómo usar Aspose.Slides para PHP a través de Java para especificar un tamaño de diapositiva personalizado para una presentación :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// Tamaño de papel A4

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gestionar el contenido de la diapositiva después de cambiar el tamaño**

Después de cambiar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede distorsionarse. De forma predeterminada, los objetos se redimensionan automáticamente para ajustarse al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puede especificar una opción que determina cómo Aspose.Slides gestiona el contenido de las diapositivas.  

Según lo que pretenda hacer o conseguir, puede usar cualquiera de estas opciones:

- `DoNotScale`

  Si NO desea que los objetos en las diapositivas se redimensionen, utilice esta opción.

- `EnsureFit`

  Si desea escalar a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de las diapositivas para que todos quepan (de esta forma evita perder contenido), utilice esta opción.

- `Maximize`

  Si desea escalar a un tamaño de diapositiva mayor y necesita que Aspose.Slides aumente los objetos de las diapositivas para que sean proporcionales al nuevo tamaño, utilice esta opción.

Este fragmento de código muestra cómo usar la opción `Maximize` al cambiar el tamaño de la diapositiva de una presentación:

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

**¿Puedo establecer un tamaño de diapositiva personalizado usando unidades diferentes a pulgadas (por ejemplo, puntos o milímetros)?**

Sí. Aspose.Slides utiliza puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.

**¿Afectará un tamaño de diapositiva personalizado muy grande al rendimiento y al uso de memoria durante el renderizado?**

Sí. Dimensiones de diapositiva más grandes (en puntos) combinadas con una escala de renderizado mayor provocan un mayor consumo de memoria y tiempos de procesamiento más largos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado solo cuando sea necesario para lograr la calidad de salida deseada.

**¿No puedo definir un tamaño de diapositiva no estándar y luego fusionar diapositivas de presentaciones que tienen tamaños diferentes?**

No puede [fusionar presentaciones](/slides/es/php-java/merge-presentation/) mientras tengan tamaños de diapositiva diferentes; primero, redimensione una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se maneja el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidesizescaletype/). Después de alinear los tamaños, puede fusionar diapositivas conservando el formato.

**¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de la diapositiva?**

Sí. Aspose.Slides puede generar miniaturas para [diapositivas completas](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#getImage) así como para [formas seleccionadas](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/#getImage). Las imágenes resultantes reflejan el tamaño y la relación de aspecto actuales de la diapositiva, garantizando un encuadre y una geometría coherentes.