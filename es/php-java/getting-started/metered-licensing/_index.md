---
title: Licencias por Consumo
type: docs
weight: 100
url: /php-java/metered-licensing/
---

{{% alert color="primary" %}} 

La licencia por consumo es un nuevo mecanismo de licenciamiento que se puede utilizar junto con los métodos de licencia existentes. Si deseas que se te facture según tu uso de las características de la API de Aspose.Slides, eliges la licencia por consumo.

Cuando compras una licencia por consumo, recibes claves (y no un archivo de licencia). Esta clave por consumo se puede aplicar utilizando la clase [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) que Aspose proporcionó para operaciones de medición. Para más detalles, consulta las [Preguntas Frecuentes sobre Licencias por Consumo](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 
1. Crea una instancia de la clase [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/).

1. Pasa tus claves pública y privada al método [setMeteredKey](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Realiza algún procesamiento (ejecuta tareas).

1. Llama al método [getConsumptionQuantity](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#getConsumptionQuantity--) de la clase Metered.

   Deberías ver la cantidad de solicitudes de API que has consumido hasta ahora.

Este código PHP te muestra cómo establecer claves públicas y privadas por consumo:

```php
  $metered = new Metered();
  try {
    // Accede a la propiedad setMeteredKey y pasa claves públicas y privadas como parámetros
    $metered->setMeteredKey("<clave pública válida>", "<clave privada válida>");
    // Obtiene el valor de la cantidad consumida antes de acceder a la API
    $quantityOld = Metered->getConsumptionQuantity();
    echo("Cantidad de consumo" . $quantityOld);
    // Obtiene el valor de la cantidad consumida después de acceder a la API
    $quantity = Metered->getConsumptionQuantity();
    echo("Cantidad de consumo" . $quantity);
  } catch (JavaException $ex) {
    $ex->printStackTrace();
  }
```

{{% alert color="warning" title="NOTA"  %}} 

Para usar la licencia por consumo, necesitas una conexión a Internet estable porque el mecanismo de licencia utiliza Internet para interactuar constantemente con nuestros servicios y realizar cálculos.

{{% /alert %}} 