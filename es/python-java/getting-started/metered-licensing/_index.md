---
title: Licenciamiento Medido
type: docs
weight: 100
url: /es/python-java/metered-licensing/
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
- Python
- Aspose.Slides
description: "Aprenda cómo el licenciamiento medido de Aspose.Slides para Python mediante Java le permite procesar archivos PowerPoint y OpenDocument de forma flexible, pagando solo por lo que utiliza."
---
## **Introducción**

La licencia medida es un mecanismo de licenciamiento que puede usarse junto a los métodos de licenciamiento existentes. Si desea que se le facture según el uso que haga de las funciones de Aspose.Slides API, elija la licencia medida.

## **Aplicar claves medidas**

{{% alert color="info" title="Nota" %}}

La licencia medida es un nuevo mecanismo de licenciamiento que puede usarse junto a los métodos de licenciamiento existentes. Si desea que se le facture según el uso que haga de las funciones de Aspose.Slides API, elija la licencia medida.

Cuando compra una licencia medida, obtiene claves (y no un archivo de licencia). Esta clave medida puede aplicarse mediante la clase [Metered](https://reference.aspose.com/slides/es/python-java/aspose.slides/metered/) que Aspose proporciona para operaciones de medición. Para más detalles, consulte [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}

1. Crear una instancia de la clase [Metered](https://reference.aspose.com/slides/es/python-java/aspose.slides/metered/).

1. Pasar sus claves públicas y privadas al método [setMeteredKey](https://reference.aspose.com/slides/es/python-java/aspose.slides/metered/#setMeteredKey).

1. Realizar algún procesamiento (ejecutar tareas).

1. Llamar al método [getConsumptionQuantity](https://reference.aspose.com/slides/es/python-java/aspose.slides/metered/#getConsumptionQuantity) de la clase [Metered](https://reference.aspose.com/slides/es/python-java/aspose.slides/metered/).

Debería ver la cantidad de peticiones a la API que ha consumido hasta el momento.

Este fragmento de código muestra cómo usar la licencia medida:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# Crear una instancia de la clase Metered.
metered = Metered()

try:
    # Pasar las claves pública y privada al objeto Metered.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # Obtener la cantidad consumida antes de las llamadas a la API.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # Hacer algo con la API de Aspose.Slides aquí.
    # ...

    # Obtener la cantidad consumida después de las llamadas a la API.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Advertencia"  %}}

Para utilizar la licencia medida necesita una conexión a Internet estable, ya que el mecanismo de licenciamiento usa Internet para interactuar continuamente con nuestros servicios y realizar cálculos.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Puedo usar una licencia medida junto con una licencia normal (perpetua o temporal) en la misma aplicación?**

Sí. La licencia medida es un mecanismo de licenciamiento adicional que puede emplearse junto a los [métodos de licenciamiento](/slides/es/python-java/licensing/). Usted decide qué mecanismo aplicar cuando la aplicación se inicia.

**¿Qué se contabiliza exactamente bajo una licencia medida: ¿operaciones o archivos?**

Se contabiliza el uso de la API, es decir, el número de peticiones o operaciones. Puede obtener el consumo actual mediante los [métodos de seguimiento de consumo](https://reference.aspose.com/slides/es/python-java/aspose.slides/metered/).

**¿Es la licencia medida adecuada para microservicios y entornos serverless donde las instancias se reinician con frecuencia?**

Sí. Dado que la contabilización se realiza a nivel de llamadas a la API, los escenarios con arranques en frío frecuentes son compatibles, siempre que exista acceso a red estable para los cálculos de la licencia medida.

**¿La funcionalidad de la biblioteca difiere al usar una licencia medida en comparación con una licencia perpetua?**

No. Esto solo afecta al mecanismo de licenciamiento y facturación; las capacidades del producto son idénticas.

**¿Cómo se relaciona la licencia medida con la versión de prueba y la licencia temporal?**

La versión de prueba tiene limitaciones y marcas de agua, la [licencia temporal](https://purchase.aspose.com/temporary-license/) elimina las limitaciones durante 30 días, y la licencia medida elimina las limitaciones y cobra en función del uso real.

**¿Puedo controlar el presupuesto reaccionando automáticamente cuando se supera un umbral de consumo?**

Sí. Una práctica común es leer periódicamente el consumo actual mediante los [métodos de seguimiento](https://reference.aspose.com/slides/es/python-java/aspose.slides/metered/) e implementar sus propios límites o alertas a nivel de la aplicación o del sistema de monitorización.