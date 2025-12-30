---
title: Licencia Medida
type: docs
weight: 100
url: /es/php-java/metered-licensing/
keywords:
- licencia
- licencia medida
- claves de licencia
- clave pública
- clave privada
- cantidad de consumo
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Aprende cómo Aspose.Slides para PHP a través de licenciamiento medido permite procesar archivos PowerPoint y OpenDocument de forma flexible, pagando solo por lo que utilizas."
---

## **Aplicar claves medida**

{{% alert color="primary" %}} 

La licencia medida es un nuevo mecanismo de licencia que puede usarse junto a los métodos de licencia existentes. Si quieres que se te facture en función de tu uso de las características de la API Aspose.Slides, eliges la licencia medida.

Cuando compras una licencia medida, obtienes claves (y no un archivo de licencia). Esta clave medida puede aplicarse usando la clase [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) que Aspose proporciona para operaciones de medición. Para más detalles, consulta las [Preguntas frecuentes de licencias medida](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Crea una instancia de la clase [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/).

1. Pasa tus claves pública y privada al método [setMeteredKey](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) .

1. Realiza algún procesamiento (ejecuta tareas).

1. Llama al método [getConsumptionQuantity](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#getConsumptionQuantity--) de la clase `Metered`.

Deberías ver la cantidad/cantidad de solicitudes de API que has consumido hasta ahora.

Este código de muestra muestra cómo usar la licencia medida:
```php
// Crea una instancia de la clase Metered
$metered = new Metered();

try {
    // Pasa las claves pública y privada al objeto Metered
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // Obtiene el valor de la cantidad consumida antes de las llamadas a la API
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // Realiza alguna operación con la API Aspose.Slides aquí
    // ...

    // Obtiene el valor de la cantidad consumida después de las llamadas a la API
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```


{{% alert color="warning" title="NOTE"  %}} 

Para usar la licencia medida, necesitas una conexión a Internet estable porque el mecanismo de licencia usa Internet para interactuar constantemente con nuestros servicios y realizar cálculos.

{{% /alert %}} 

## **Preguntas frecuentes**

**¿Puedo usar una licencia medida junto con una regular (perpetua o temporal) en la misma aplicación?**

Sí. La medida es un mecanismo de licencia adicional que puede usarse junto a los [métodos de licencia](/slides/es/php-java/licensing/). Elegirás qué mecanismo aplicar cuando la aplicación se inicie.

**¿Qué cuenta exactamente como consumo bajo una licencia medida: ¿operaciones o archivos?**

Se cuenta el uso de la API, es decir, el número de solicitudes u operaciones. Puedes obtener el consumo actual mediante los [métodos de seguimiento de consumo](https://reference.aspose.com/slides/php-java/aspose.slides/metered/).

**¿Es la medida adecuada para microservicios y entornos sin servidor donde las instancias se reinician con frecuencia?**

Sí. Dado que la contabilización se hace a nivel de llamada a la API, los escenarios con arranques fríos frecuentes son compatibles, siempre que haya acceso de red estable para los cálculos de medida.

**¿La funcionalidad de la biblioteca difiere al usar una licencia medida en comparación con una licencia perpetua?**

No. Esto solo afecta al mecanismo de licencia y facturación; las capacidades del producto son las mismas.

**¿Cómo se relaciona la medida con la versión de prueba y la licencia temporal?**

La versión de prueba tiene limitaciones y marcas de agua, la [licencia temporal](https://purchase.aspose.com/temporary-license/) elimina las limitaciones durante 30 días, y la medida elimina limitaciones y cobra según el uso real.

**¿Puedo controlar el presupuesto reaccionando automáticamente cuando se supera un umbral de consumo?**

Sí. Una práctica común es leer periódicamente el consumo actual mediante los [métodos de seguimiento](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) e implementar tus propios límites o alertas a nivel de aplicación o monitorización.