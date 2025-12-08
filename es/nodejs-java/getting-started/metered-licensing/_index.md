---
title: Licenciamiento medido
type: docs
weight: 100
url: /es/nodejs-java/metered-licensing/
keywords:
- licencia
- licenciamiento medido
- Node.js
- Java
- Aspose.Slides para Node.js mediante Java
---

## **Aplicar claves medidas**

{{% alert color="primary" %}} 

La licencia medida es un nuevo mecanismo de licenciamiento que puede usarse junto a los métodos de licenciamiento existentes. Si desea que le facturen según el uso que haga de las funcionalidades de la API Aspose.Slides, elija la licencia medida.

Al comprar una licencia medida, recibe claves (y no un archivo de licencia). Esta clave medida puede aplicarse utilizando la clase [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) que Aspose proporciona para operaciones de medición. Para obtener más detalles, consulte la [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Cree una instancia de la clase [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/).

1. Pase sus claves públicas y privadas al método [setMeteredKey](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#setMeteredKey).

1. Realice algún procesamiento (ejecute tareas).

1. Llame al método [getConsumptionQuantity](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) de la clase `Metered`.

Debería ver la cantidad de solicitudes API que ha consumido hasta el momento.

Este fragmento de código muestra cómo usar la licencia medida:
```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crea una instancia de la clase Metered
var metered = new aspose.slides.Metered();

// Pasa las claves públicas y privadas al objeto Metered
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Obtiene el valor de cantidad consumida antes de las llamadas a la API
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Haz algo con la API de Aspose.Slides aquí
// ...

// Obtiene el valor de cantidad consumida después de las llamadas a la API
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```


{{% alert color="warning" title="NOTE"  %}} 

Para usar la licencia medida, necesita una conexión a Internet estable porque el mecanismo de licenciamiento utiliza Internet para interactuar constantemente con nuestros servicios y realizar cálculos.

{{% /alert %}} 

## **FAQ**

**¿Puedo usar una licencia medida junto con una licencia regular (perpetua o temporal) en la misma aplicación?**

Sí. La licencia medida es un mecanismo de licenciamiento adicional que puede usarse junto a los [licensing methods](/slides/es/nodejs-java/licensing/). Usted decide qué mecanismo aplicar cuando la aplicación se inicia.

**¿Qué cuenta exactamente como consumo bajo una licencia medida: ¿operaciones o archivos?**

Se cuenta el uso de la API, es decir, el número de solicitudes u operaciones. Puede obtener el consumo actual mediante los [consumption-tracking methods](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/).

**¿Es la licencia medida adecuada para microservicios y entornos sin servidor donde las instancias se reinician con frecuencia?**

Sí. Como la contabilidad se realiza a nivel de llamada a la API, los escenarios con reinicios frecuentes son compatibles, siempre que haya acceso a red estable para los cálculos de la licencia medida.

**¿La funcionalidad de la biblioteca difiere al usar una licencia medida frente a una licencia perpetua?**

No. Sólo se trata del mecanismo de licenciamiento y facturación; las capacidades del producto son las mismas.

**¿Cómo se relaciona la licencia medida con la versión de prueba y la licencia temporal?**

La versión de prueba tiene limitaciones y marcas de agua, la [temporary license](https://purchase.aspose.com/temporary-license/) elimina las limitaciones durante 30 días, y la licencia medida elimina las limitaciones y cobra según el uso real.

**¿Puedo controlar el presupuesto reaccionando automáticamente cuando se supera un umbral de consumo?**

Sí. Una práctica común es leer periódicamente el consumo actual mediante los [tracking methods](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) e implementar sus propios límites o alertas a nivel de aplicación o de monitorización.