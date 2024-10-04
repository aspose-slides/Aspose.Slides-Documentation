---
title: Licenciamiento Medido
type: docs
weight: 100
url: /es/androidjava/metered-licensing/
---

{{% alert color="primary" %}} 

Aspose.Slides permite a los desarrolladores aplicar una clave medida. Es un nuevo mecanismo de licencia. El nuevo mecanismo de licencia se utilizará junto con los métodos de licencia existentes. Los clientes que prefieren ser facturados según su uso de las características de la API pueden utilizar el licenciamiento medido. Para más detalles, consulte la sección de [Preguntas Frecuentes sobre Licenciamiento Medido](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 
## **Licenciamiento Medido**
Siga estos sencillos pasos para usar la clase Metered:

1. Cree una instancia de la clase Metered.

1. Pase las claves públicas y privadas al método setMeteredKey.

1. Realice el procesamiento (ejecute la tarea).

1. Llame al método getConsumptionQuantity de la clase Metered.

   Esto devolverá la cantidad de solicitudes de API que ha consumido hasta ahora.

Este código de ejemplo le muestra cómo establecer las claves públicas y privadas medidas:

```java
com.aspose.slides.Metered metered=new com.aspose.slides.Metered();
try {
    // Acceda a la propiedad setMeteredKey y pase las claves pública y privada como parámetros
    metered.setMeteredKey("<valid pablic key>", "<valid private key>");

    // Obtenga el valor de cantidad consumida antes de acceder a la API
    double quantityOld = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Cantidad de consumo" + quantityOld);


    // Obtenga el valor de cantidad consumida después de acceder a la API
    double quantity = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Cantidad de consumo" + quantity);


} catch (Exception ex) {
    ex.printStackTrace();
}
```