---
title: Configurar la sustitución de fuentes en presentaciones usando PHP
linktitle: Sustitución de fuentes
type: docs
weight: 70
url: /es/php-java/font-substitution/
keywords:
- fuente
- fuente sustituta
- sustitución de fuentes
- reemplazar fuente
- reemplazo de fuentes
- regla de sustitución
- regla de reemplazo
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Habilite la sustitución óptima de fuentes en Aspose.Slides para PHP mediante Java al convertir presentaciones de PowerPoint y OpenDocument a otros formatos de archivo."
---

## **Establecer reglas de sustitución de fuentes**

Aspose.Slides le permite establecer reglas para las fuentes que determinan qué se debe hacer en determinadas condiciones (por ejemplo, cuando no se puede acceder a una fuente) de la siguiente manera:

1. Cargue la presentación correspondiente.  
2. Cargue la fuente que será reemplazada.  
3. Cargue la nueva fuente.  
4. Añada una regla para el reemplazo.  
5. Añada la regla a la colección de reglas de reemplazo de fuentes de la presentación.  
6. Genere la imagen de la diapositiva para observar el efecto.

Este código PHP muestra el proceso de sustitución de fuentes:
```php
  # Carga una presentación
  $pres = new Presentation("Fonts.pptx");
  try {
    # Carga la fuente origen que será reemplazada
    $sourceFont = new FontData("SomeRareFont");
    # Carga la nueva fuente
    $destFont = new FontData("Arial");
    # Añade una regla de fuente para el reemplazo de fuentes
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # Añade la regla a la colección de reglas de sustitución de fuentes
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # Añade la colección de reglas de fuentes a la lista de reglas
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # La fuente Arial se usará en lugar de SomeRareFont cuando esta última sea inaccesible
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Guarda la imagen en disco en formato JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{%  alert title="NOTE"  color="warning"   %}} 
Es posible que desee ver [**Reemplazo de fuentes**](/slides/es/php-java/font-replacement/).
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre el reemplazo de fuentes y la sustitución de fuentes?**

[Replacement](/slides/es/php-java/font-replacement/) es una sobrescritura forzada de una fuente por otra en toda la presentación. La sustitución es una regla que se activa bajo una condición específica, por ejemplo cuando la fuente original no está disponible, y entonces se utiliza una fuente de respaldo designada.

**¿Cuándo se aplican exactamente las reglas de sustitución?**

Las reglas participan en la secuencia estándar de [selección de fuentes](/slides/es/php-java/font-selection-sequence/) que se evalúa durante la carga, el renderizado y la conversión; si la fuente seleccionada no está disponible, se aplica el reemplazo o la sustitución.

**¿Cuál es el comportamiento predeterminado si no se configura ni el reemplazo ni la sustitución y la fuente falta en el sistema?**

La biblioteca intentará elegir la fuente del sistema más cercana disponible, de manera similar a como lo haría PowerPoint.

**¿Puedo adjuntar fuentes externas personalizadas en tiempo de ejecución para evitar la sustitución?**

Sí. Puede [añadir fuentes externas](/slides/es/php-java/custom-font/) en tiempo de ejecución para que la biblioteca las tenga en cuenta para la selección y el renderizado, incluidas las conversiones posteriores.

**¿Distribuye Aspose alguna fuente con la biblioteca?**

No. Aspose no distribuye fuentes, sean de pago o gratuitas; usted añade y utiliza fuentes bajo su propia discreción y responsabilidad.

**¿Existen diferencias en el comportamiento de sustitución en Windows, Linux y macOS?**

Sí. La detección de fuentes comienza en los directorios de fuentes del sistema operativo. El conjunto de fuentes predeterminadas disponibles y las rutas de búsqueda difieren entre plataformas, lo que afecta la disponibilidad y la necesidad de sustitución.

**¿Cómo debo preparar el entorno para minimizar la sustitución inesperada durante conversiones por lotes?**

Sincronice el conjunto de fuentes entre máquinas o contenedores, [añada las fuentes externas](/slides/es/php-java/custom-font/) necesarias para los documentos de salida y [incorpore fuentes](/slides/es/php-java/embedded-font/) en las presentaciones cuando sea posible, de modo que las fuentes elegidas estén disponibles durante el renderizado.