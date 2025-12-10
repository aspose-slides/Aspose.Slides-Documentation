---
title: Licenciamiento medido
type: docs
weight: 100
url: /es/java/metered-licensing/
keywords:
- licencia
- licencia con medida
- claves de licencia
- clave pública
- clave privada
- cantidad de consumo
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Aprenda cómo el licenciamiento con medida de Aspose.Slides para Java le permite procesar archivos PowerPoint y OpenDocument de forma flexible, pagando solo por lo que usa."
---

## **Aplicar claves con medida**

{{% alert color="primary" %}} 

La licencia con medida es un nuevo mecanismo de licenciamiento que se puede usar junto con los métodos de licenciamiento existentes. Si deseas que se te facture según el uso de las funciones de la API Aspose.Slides, eliges la licencia con medida.

Cuando compras una licencia con medida, obtienes claves (y no un archivo de licencia). Esta clave con medida se puede aplicar mediante la clase [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) que Aspose proporciona para operaciones de medición. Para más detalles, consulta [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Crea una instancia de la clase [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/).

1. Pasa tus claves pública y privada al método [setMeteredKey](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) .

1. Realiza algún procesamiento (ejecuta tareas).

1. Llama al método [getConsumptionQuantity](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#getConsumptionQuantity--) de la clase `Metered`.

Deberías ver la cantidad de solicitudes a la API que has consumido hasta el momento.

Este código de ejemplo muestra cómo usar la licencia con medida:

```java
// Crea una instancia de la clase Metered
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Pasa las claves pública y privada al objeto Metered
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Obtiene el valor de cantidad consumida antes de las llamadas a la API
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Realiza alguna operación con la API Aspose.Slides aquí
    // ...

    // Obtiene el valor de cantidad consumida después de las llamadas a la API
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Para usar la licencia con medida, necesitas una conexión a Internet estable porque el mecanismo de licenciamiento utiliza Internet para interactuar constantemente con nuestros servicios y realizar cálculos.

{{% /alert %}} 

## **FAQ**

**¿Puedo usar una licencia con medida junto con una licencia regular (perpetua o temporal) en la misma aplicación?**

Sí. La licencia con medida es un mecanismo adicional que puede usarse junto con los [métodos de licenciamiento](/slides/es/java/licensing/). Tú eliges qué mecanismo aplicar cuando la aplicación se inicia.

**¿Qué se cuenta exactamente como consumo bajo una licencia con medida: ¿operaciones o archivos?**

Se cuenta el uso de la API, es decir, el número de solicitudes u operaciones. Puedes obtener el consumo actual mediante los [métodos de seguimiento de consumo](https://reference.aspose.com/slides/java/com.aspose.slides/metered/).

**¿Es la licencia con medida adecuada para microservicios y entornos sin servidor donde las instancias se reinician con frecuencia?**

Sí. Como la contabilización se realiza a nivel de llamada a la API, los escenarios con arranques en frío frecuentes son compatibles, siempre que haya acceso a la red estable para los cálculos de medida.

**¿La funcionalidad de la biblioteca difiere al usar una licencia con medida en comparación con una licencia perpetua?**

No. Esto solo afecta al mecanismo de licenciamiento y facturación; las capacidades del producto son las mismas.

**¿Cómo se relaciona la licencia con medida con la versión de prueba y la licencia temporal?**

La versión de prueba tiene limitaciones y marcas de agua, la [licencia temporal](https://purchase.aspose.com/temporary-license/) elimina las limitaciones durante 30 días, y la licencia con medida elimina las limitaciones y cobra según el uso real.

**¿Puedo controlar el presupuesto reaccionando automáticamente cuando se supera un umbral de consumo?**

Sí. Una práctica común es leer periódicamente el consumo actual mediante los [métodos de seguimiento](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) e implementar tus propios límites o alertas a nivel de aplicación o monitorización.