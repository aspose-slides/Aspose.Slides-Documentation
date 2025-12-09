---
title: Licenciamiento con medición
type: docs
weight: 90
url: /es/net/metered-licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo el licenciamiento con medición de Aspose.Slides para .NET le permite procesar archivos PowerPoint y OpenDocument de forma flexible, pagando solo por lo que usa."
---

## **Aplicar claves con medición**

{{% alert color="primary" %}} 

La licencia con medición es un nuevo mecanismo de licenciamiento que puede usarse junto a los métodos de licencia existentes. Si desea que se le facture según el uso que haga de las funciones de la API Aspose.Slides, elija la licencia con medición.

Cuando compra una licencia con medición, obtiene claves (no un archivo de licencia). Esta clave con medición puede aplicarse mediante la clase [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) que Aspose proporciona para operaciones de medición. Para más detalles, consulte [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Cree una instancia de la clase [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/).
1. Pase sus claves pública y privada al método [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/).
1. Realice algún procesamiento (ejecute tareas).
1. Llame al método [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) de la clase `Metered`.

Debería ver la cantidad de peticiones a la API que ha consumido hasta el momento.

Este fragmento de código muestra cómo usar la licencia con medición:

```cs
// Crea una instancia de la clase Metered
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Pasa las claves pública y privada al objeto Metered
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Obtiene la cantidad de datos medidos antes de la llamada a la API
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Realice alguna operación con la API Aspose.Slides aquí
// ...

// Obtiene la cantidad de datos medidos después de la llamada a la API
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTA"  %}} 

Para usar la licencia con medición, necesita una conexión a Internet estable porque el mecanismo de licenciamiento usa Internet para interactuar constantemente con nuestros servicios y realizar los cálculos.

{{% /alert %}} 

## **FAQ**

**¿Puedo usar una licencia con medición junto con una licencia regular (perpetua o temporal) en la misma aplicación?**

Sí. La licencia con medición es un mecanismo adicional que puede usarse junto a los [métodos de licenciamiento](/slides/es/net/licensing/). Usted elige qué mecanismo aplicar cuando la aplicación se inicia.

**¿Qué se contabiliza exactamente bajo una licencia con medición: ¿operaciones o archivos?**

Se cuenta el uso de la API, es decir, el número de solicitudes u operaciones. Puede obtener el consumo actual mediante los [métodos de seguimiento del consumo](https://reference.aspose.com/slides/net/aspose.slides/metered/).

**¿La licencia con medición es adecuada para microservicios y entornos sin servidor donde las instancias se reinician con frecuencia?**

Sí. Dado que la contabilización se realiza a nivel de llamada a la API, los escenarios con reinicios frecuentes son compatibles, siempre que exista acceso de red estable para los cálculos de medición.

**¿La funcionalidad de la biblioteca cambia al usar una licencia con medición comparada con una licencia perpetua?**

No. Esto solo afecta al mecanismo de licenciamiento y facturación; las capacidades del producto son las mismas.

**¿Cómo se relaciona la licencia con medición con la versión de prueba y la licencia temporal?**

La versión de prueba tiene limitaciones y marcas de agua, la [licencia temporal](https://purchase.aspose.com/temporary-license/) elimina las limitaciones durante 30 días, y la licencia con medición elimina las limitaciones y cobra según el uso real.

**¿Puedo controlar el presupuesto reaccionando automáticamente cuando se supera un umbral de consumo?**

Sí. Una práctica común es leer periódicamente el consumo actual mediante los [métodos de seguimiento](https://reference.aspose.com/slides/net/aspose.slides/metered/) e implementar sus propios límites o alertas a nivel de aplicación o de monitorización.