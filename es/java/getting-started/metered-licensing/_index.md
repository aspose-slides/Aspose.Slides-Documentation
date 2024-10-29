---
title: Licencia Medida
type: docs
weight: 100
url: /es/java/metered-licensing/
---

{{% alert color="primary" %}} 

La licencia medida es un nuevo mecanismo de licencia que se puede utilizar junto con los métodos de licencia existentes. Si deseas ser facturado en función de tu uso de las funciones de la API de Aspose.Slides, debes elegir la licencia medida.

Cuando compras una licencia medida, obtienes claves (y no un archivo de licencia). Esta clave medida se puede aplicar utilizando la clase [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) que Aspose proporcionó para operaciones de medición. Para más detalles, consulta las [Preguntas Frecuentes sobre Licencias Medidas](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 
1. Crea una instancia de la clase [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/).

1. Pasa tus claves pública y privada al método [setMeteredKey](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Realiza algún procesamiento (realiza tareas).

1. Llama al método [getConsumptionQuantity](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#getConsumptionQuantity--) de la clase Metered.

   Deberías ver la cantidad de solicitudes de API que has consumido hasta ahora.

Este código Java te muestra cómo establecer las claves pública y privada medidas:

```java
com.aspose.slides.Metered metered=new com.aspose.slides.Metered();
try {
    // Accede a la propiedad setMeteredKey y pasa claves pública y privada como parámetros
    metered.setMeteredKey("<clave pública válida>", "<clave privada válida>");

    // Obtiene el valor de cantidad consumida antes de acceder a la API
    double quantityOld = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Cantidad de consumo" + quantityOld);


    // Obtiene el valor de cantidad consumida después de acceder a la API
    double quantity = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Cantidad de consumo" + quantity);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTA"  %}} 

Para utilizar la licencia medida, necesitas una conexión a internet estable porque el mecanismo de licencia utiliza internet para interactuar constantemente con nuestros servicios y realizar cálculos.

{{% /alert %}} 