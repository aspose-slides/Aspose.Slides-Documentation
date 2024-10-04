---
title: Licenciamiento Medido
type: docs
weight: 90
url: /net/metered-licensing/
---

{{% alert color="primary" %}} 

El licenciamiento medido es un nuevo mecanismo de licenciamiento que se puede utilizar junto con los métodos de licenciamiento existentes. Si desea ser facturado según su uso de las características de la API de Aspose.Slides, debe elegir el licenciamiento medido.

Cuando compra una licencia medida, recibe claves (y no un archivo de licencia). Esta clave medida se puede aplicar utilizando la clase [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) que Aspose proporcionó para operaciones de medición. Para más detalles, consulte [FAQ de Licenciamiento Medido](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Cree una instancia de la clase [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/).
1. Pase sus claves públicas y privadas al método [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/).
1. Realice algún procesamiento (ejecute tareas).
1. Llamar al método [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) de la clase Metered.

   Debería ver la cantidad/cantidad de solicitudes a la API que ha consumido hasta ahora.

Este código C# le muestra cómo establecer las claves públicas y privadas medidas:

```c#
//  Crea una instancia de la clase Metered
	Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

//  Accede a la propiedad SetMeteredKey y pasa las claves pública y privada como parámetros
	metered.SetMeteredKey("*****", "*****");

//  Obtiene la cantidad de datos medidos antes de la llamada a la API
	decimal amountbefore = Aspose.Slides.Metered.GetConsumptionQuantity();

//  Muestra la información
	Console.WriteLine("Cantidad Consumida Antes: " + amountbefore.ToString());

//  Obtiene la cantidad de datos medidos después de la llamada a la API
	decimal amountafter = Aspose.Slides.Metered.GetConsumptionQuantity();

//  Muestra la información
	Console.WriteLine("Cantidad Consumida Después: " + amountafter.ToString());
```

{{% alert color="warning" title="NOTA"  %}} 

Para utilizar el licenciamiento medido, necesita una conexión a internet estable porque el mecanismo de licenciamiento utiliza internet para interactuar constantemente con nuestros servicios y realizar cálculos.

{{% /alert %}} 