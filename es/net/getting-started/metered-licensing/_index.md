---
title: Licenciamiento con Facturación por Uso
type: docs
weight: 90
url: /es/net/metered-licensing/
keywords:
- licencia
- licenciamiento con facturación por uso
- C#
- Aspose.Slides para .NET
---

## **Aplicar claves con facturación por uso**

{{% alert color="primary" %}} 

La licencia con facturación por uso es un nuevo mecanismo de licenciamiento que puede usarse junto con los métodos de licenciamiento existentes. Si desea que se le cobre según el uso que haga de las funcionalidades de la API AspAspose.Slides, elija la licencia con facturación por uso.

Al comprar una licencia con facturación por uso, obtiene claves (no un archivo de licencia). Esta clave con facturación por uso puede aplicarse mediante la clase [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) que Aspose proporciona para operaciones de medición. Para más detalles, consulte [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Cree una instancia de la clase [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/).
2. Pase sus claves públicas y privadas al método [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/).
3. Realice algún procesamiento (ejecute tareas).
4. Llame al método [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) de la clase `Metered`.

Debería ver la cantidad de solicitudes a la API que ha consumido hasta el momento.

Este ejemplo de código muestra cómo usar la licencia con facturación por uso:

```cs
// Creates an instance of the Metered class
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Passes the public and private keys to the Metered object
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Gets the metered data quantity before API call
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Do something with Aspose.Slides API here
// ...

// Gets the metered data amount after API call
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTA"  %}} 

Para usar la licencia con facturación por uso, necesita una conexión a Internet estable porque el mecanismo de licenciamiento utiliza Internet para interactuar constantemente con nuestros servicios y realizar cálculos.

{{% /alert %}} 

## **Preguntas frecuentes**

**¿Puedo usar una licencia con facturación por uso junto con una licencia regular (perpetua o temporal) en la misma aplicación?**

Sí. La facturación por uso es un mecanismo de licenciamiento adicional que puede usarse junto con los [métodos de licenciamiento](/slides/es/net/licensing/). Usted decide qué mecanismo aplicar cuando la aplicación se inicia.

**¿Qué se cuenta exactamente como consumo bajo una licencia con facturación por uso: operaciones o archivos?**

Se cuenta el uso de la API, es decir, el número de solicitudes u operaciones. Puede obtener el consumo actual mediante los [métodos de seguimiento de consumo](https://reference.aspose.com/slides/net/aspose.slides/metered/).

**¿Es la facturación por uso adecuada para microservicios y entornos sin servidor donde las instancias se reinician con frecuencia?**

Sí. Dado que la contabilidad se realiza a nivel de llamada a la API, los escenarios con reinicios frecuentes son compatibles, siempre que exista acceso de red estable para los cálculos de facturación por uso.

**¿La funcionalidad de la biblioteca difiere al usar una licencia con facturación por uso en comparación con una licencia perpetua?**

No. Esto solo afecta al mecanismo de licenciamiento y facturación; las capacidades del producto son las mismas.

**¿Cómo se relaciona la facturación por uso con la versión de prueba y la licencia temporal?**

La versión de prueba tiene limitaciones y marcas de agua, la [licencia temporal](https://purchase.aspose.com/temporary-license/) elimina las limitaciones durante 30 días, y la facturación por uso elimina las limitaciones y cobra según el uso real.

**¿Puedo controlar el presupuesto reaccionando automáticamente cuando se supera un umbral de consumo?**

Sí. Una práctica común es leer periódicamente el consumo actual mediante los [métodos de seguimiento](https://reference.aspose.com/slides/net/aspose.slides/metered/) e implementar sus propios límites o alertas a nivel de aplicación o de monitorización.