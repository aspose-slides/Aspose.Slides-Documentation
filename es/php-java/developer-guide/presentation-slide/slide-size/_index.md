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
- PHP
- Aspose.Slides
descriptions: "Aprenda a cambiar rápidamente el tamaño de las diapositivas en archivos PPT, PPTX y ODP con PHP y Aspose.Slides, optimice presentaciones para cualquier pantalla sin perder calidad."
---

## **Tamaños de diapositiva en presentaciones de PowerPoint**

Aspose.Slides para PHP a través de Java le permite cambiar el tamaño de la diapositiva o la relación de aspecto en presentaciones de PowerPoint. Si planea imprimir su presentación o mostrar sus diapositivas en una pantalla, debe prestar atención al tamaño de la diapositiva o a la relación de aspecto.

Estos son los tamaños de diapositiva y relaciones de aspecto más comunes:

- **Estándar (relación de aspecto 4:3)**  

  Si su presentación se va a mostrar o ver en dispositivos o pantallas relativamente antiguos, puede que desee usar esta configuración.  

- **Panorámico (relación de aspecto 16:9)**  

  Si su presentación se va a ver en proyectores o pantallas modernos, puede que desee usar esta configuración.  

No puede usar varias configuraciones de tamaño de diapositiva en una sola presentación. Cuando selecciona un tamaño de diapositiva para una presentación, esa configuración se aplica a todas las diapositivas de la presentación.  

Si prefiere usar un tamaño de diapositiva especial para sus presentaciones, le recomendamos encarecidamente que lo haga al principio. Idealmente, debe especificar su tamaño de diapositiva preferido al inicio, es decir, cuando simplemente está configurando la presentación—antes de añadir cualquier contenido. De esta manera, evita complicaciones derivadas de cambios (futuros) en el tamaño de las diapositivas.  

{{% alert color="primary" %}} 
 Cuando usa Aspose.Slides para crear una presentación, todas las diapositivas de la presentación obtienen automáticamente el tamaño estándar o la relación de aspecto 4:3. 
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

Si considera que los tamaños de diapositiva comunes (4:3 y 16:9) no se adaptan a su trabajo, puede decidir usar un tamaño de diapositiva específico o único. Por ejemplo, si planea imprimir diapositivas a tamaño completo de su presentación en un diseño de página personalizado o si pretende mostrar su presentación en ciertos tipos de pantalla, probablemente se beneficie de usar una configuración de tamaño personalizado para su presentación. 

Este fragmento de código muestra cómo usar Aspose.Slides para PHP a través de Java para especificar un tamaño de diapositiva personalizado para una presentación: 
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


## **Manejar el contenido de la diapositiva después de redimensionar**

Después de cambiar el tamaño de la diapositiva de una presentación, el contenido de las diapositivas (imágenes u objetos, por ejemplo) puede distorsionarse. Por defecto, los objetos se redimensionan automáticamente para ajustarse al nuevo tamaño de la diapositiva. Sin embargo, al cambiar el tamaño de la diapositiva de una presentación, puede especificar una configuración que determine cómo Aspose.Slides trata el contenido de las diapositivas. 

Dependiendo de lo que pretenda hacer o lograr, puede usar cualquiera de estas configuraciones:

- `DoNotScale`  

  Si NO desea que los objetos de las diapositivas se redimensionen, use esta configuración.  

- `EnsureFit`  

  Si desea escalar a un tamaño de diapositiva más pequeño y necesita que Aspose.Slides reduzca los objetos de las diapositivas para asegurar que todos caben en ellas (evitando así la pérdida de contenido), use esta configuración.  

- `Maximize`  

  Si desea escalar a un tamaño de diapositiva mayor y necesita que Aspose.Slides agrande los objetos de las diapositivas para que sean proporcionales al nuevo tamaño, use esta configuración.  

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


## **FAQ**

**¿Puedo establecer un tamaño de diapositiva personalizado usando unidades distintas a pulgadas (por ejemplo, puntos o milímetros)?**

Sí. Aspose.Slides usa puntos internamente, donde 1 punto equivale a 1/72 de pulgada. Puede convertir cualquier unidad (como milímetros o centímetros) a puntos y usar los valores convertidos para definir el ancho y la altura de la diapositiva.  

**¿Un tamaño de diapositiva personalizado muy grande afectará el rendimiento y el uso de memoria durante el renderizado?**

Sí. Dimensiones de diapositiva mayores (en puntos) combinadas con una escala de renderizado alta provocan un mayor consumo de memoria y tiempos de procesamiento más largos. Apunte a un tamaño de diapositiva práctico y ajuste la escala de renderizado solo cuando sea necesario para obtener la calidad de salida deseada.  

**¿Puedo definir un tamaño de diapositiva no estándar y luego fusionar diapositivas de presentaciones que tienen tamaños diferentes?**

No puede [merge presentations](/slides/es/php-java/merge-presentation/) mientras tengan tamaños de diapositiva diferentes; primero, redimensione una presentación para que coincida con la otra. Al cambiar el tamaño de la diapositiva, puede elegir cómo se maneja el contenido existente mediante la opción [SlideSizeScaleType](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/). Después de alinear los tamaños, puede fusionar diapositivas conservando el formato.  

**¿Puedo generar miniaturas para formas individuales o regiones específicas de una diapositiva, y respetarán el nuevo tamaño de diapositiva?**

Sí. Aspose.Slides puede generar miniaturas tanto para [entire slides](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) como para [selected shapes](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage). Las imágenes resultantes reflejan el tamaño de diapositiva y la relación de aspecto actuales, garantizando un encuadre y una geometría consistentes.