---
title: Licenciamiento por consumo
type: docs
weight: 100
url: /es/nodejs-java/metered-licensing/
keywords:
- licencia
- licenciamiento por consumo
- Node.js
- Java
- Aspose.Slides para Node.js via Java
---

## **Aplicar claves de consumo**

{{% alert color="primary" %}} 

El licenciamiento por consumo es un nuevo mecanismo de licencia que puede usarse junto con los métodos de licencia existentes. Si deseas que se te facture según tu uso de las funciones de la API Aspose.Slides, eliges el licenciamiento por consumo.

Cuando compras una licencia por consumo, recibes claves (y no un archivo de licencia). Esta clave por consumo puede aplicarse usando la clase [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) que Aspose proporciona para operaciones de medición. Para más detalles, consulta [Preguntas frecuentes sobre licenciamiento por consumo](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Crea una instancia de la clase [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/).

2. Pasa tus claves públicas y privadas al método [setMeteredKey](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#setMeteredKey).

3. Realiza algún procesamiento (ejecuta tareas).

4. Llama al método [getConsumptionQuantity](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) de la clase `Metered`.

Deberías ver la cantidad/cuantía de solicitudes de API que has consumido hasta ahora.

Este código de ejemplo muestra cómo usar el licenciamiento por consumo:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crea una instancia de la clase Metered
var metered = new aspose.slides.Metered();

// Pasa las claves públicas y privadas al objeto Metered
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Obtiene el valor de la cantidad consumida antes de las llamadas a la API
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Haz algo con la API Aspose.Slides aquí
// ...

// Obtiene el valor de la cantidad consumida después de las llamadas a la API
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 

Para usar el licenciamiento por consumo, necesitas una conexión a internet estable porque el mecanismo de licencia utiliza internet para interactuar constantemente con nuestros servicios y realizar cálculos.

{{% /alert %}} 

## **Preguntas frecuentes**

**¿Puedo usar una licencia por consumo junto con una licencia regular (perpetua o temporal) en la misma aplicación?**

Sí. El licenciamiento por consumo es un mecanismo adicional que puede usarse junto con los [métodos de licencia](/slides/es/nodejs-java/licensing/). Tú decides qué mecanismo aplicar cuando la aplicación se inicia.

**¿Qué se cuenta exactamente como consumo bajo una licencia por consumo: ¿operaciones o archivos?**

Se cuenta el uso de la API, es decir, el número de solicitudes u operaciones. Puedes obtener el consumo actual mediante los [métodos de seguimiento de consumo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/).

**¿Es el licenciamiento por consumo adecuado para microservicios y entornos serverless donde las instancias se reinician con frecuencia?**

Sí. Como la contabilidad se realiza a nivel de llamadas a la API, los escenarios con reinicios frecuentes (cold starts) son compatibles, siempre que haya acceso de red estable para los cálculos de consumo.

**¿Difiere la funcionalidad de la biblioteca al usar una licencia por consumo en comparación con una licencia perpetua?**

No. Esto solo afecta al mecanismo de licencia y facturación; las capacidades del producto son las mismas.

**¿Cómo se relaciona el licenciamiento por consumo con la versión de prueba y la licencia temporal?**

La versión de prueba tiene limitaciones y marcas de agua, la [licencia temporal](https://purchase.aspose.com/temporary-license/) elimina limitaciones durante 30 días, y el licenciamiento por consumo elimina limitaciones y cobra según el uso real.

**¿Puedo controlar el presupuesto reaccionando automáticamente cuando se supera un umbral de consumo?**

Sí. Una práctica común es leer periódicamente el consumo actual mediante los [métodos de seguimiento](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) e implementar tus propios límites o alertas a nivel de aplicación o monitorización.