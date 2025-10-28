---
title: Licenciamiento Medido
type: docs
weight: 90
url: /es/python-net/metered-licensing/
keywords:
- licencia
- licencia medida
- claves de licencia
- clave pública
- clave privada
- cantidad de consumo
- Python
- Aspose.Slides
description: "Aprenda cómo el licenciamiento medido de Aspose.Slides for Python via .NET le permite procesar archivos PowerPoint y OpenDocument de forma flexible, pagando solo por lo que utiliza."
---

## **Aplicar claves de licencia medida**

{{% alert color="primary" %}} 

El licenciamiento medido es un nuevo mecanismo de licenciamiento que puede usarse junto con los métodos de licenciamiento existentes. Si desea facturarse en función de su uso de las funciones de la API de Aspose.Slides, elija el licenciamiento medido.

Cuando compra una licencia medida, recibe claves (y no un archivo de licencia). Esta clave medida puede aplicarse mediante la clase [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) que Aspose proporciona para operaciones de medición. Para más detalles, consulte las [Preguntas frecuentes sobre licenciamiento medido](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Cree una instancia de la clase [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).  
2. Pase sus claves públicas y privadas al método [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str).  
3. Realice algún procesamiento (ejecute tareas).  
4. Llame al método [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) de la clase `Metered`.

Debería ver la cantidad de solicitudes a la API que ha consumido hasta el momento.

Este fragmento de código muestra cómo usar el licenciamiento medido:

```python
import aspose.slides as slides

# Creates an instance of the Metered class
metered = slides.Metered()

# Passes the public and private keys to the Metered object
metered.set_metered_key("<valid public key>", "<valid private key>")

# Gets the consumed quantity value before API calls
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Do something with Aspose.Slides API here
# ...

# Gets the consumed quantity value after API calls
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTA"  %}} 

Para usar el licenciamiento medido, necesita una conexión a Internet estable porque el mecanismo de licenciamiento utiliza Internet para interactuar constantemente con nuestros servicios y realizar los cálculos.

{{% /alert %}} 

## **Preguntas frecuentes**

**¿Puedo usar una licencia medida junto con una licencia regular (perpetua o temporal) en la misma aplicación?**

Sí. La licencia medida es un mecanismo adicional que puede usarse junto con los [métodos de licenciamiento](/slides/es/python-net/licensing/) existentes. Usted elige qué mecanismo aplicar cuando la aplicación se inicia.

**¿Qué se contabiliza exactamente como consumo bajo una licencia medida: ¿operaciones o archivos?**

Se contabiliza el uso de la API, es decir, el número de solicitudes u operaciones. Puede obtener el consumo actual mediante los [métodos de seguimiento del consumo](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).

**¿Es la licencia medida adecuada para microservicios y entornos serverless donde las instancias se reinician con frecuencia?**

Sí. Dado que la contabilidad se realiza a nivel de llamadas a la API, los escenarios con reinicios frecuentes son compatibles, siempre que haya acceso a la red estable para los cálculos de la licencia medida.

**¿La funcionalidad de la biblioteca difiere al usar una licencia medida en comparación con una licencia perpetua?**

No. Esto solo afecta al mecanismo de licenciamiento y facturación; las capacidades del producto son las mismas.

**¿Cómo se relaciona la licencia medida con la versión de prueba y la licencia temporal?**

La versión de prueba tiene limitaciones y marcas de agua, la [licencia temporal](https://purchase.aspose.com/temporary-license/) elimina las limitaciones durante 30 días, y la licencia medida elimina las limitaciones y cobra según el uso real.

**¿Puedo controlar el presupuesto reaccionando automáticamente cuando se supera un umbral de consumo?**

Sí. Una práctica común es leer periódicamente el consumo actual mediante los [métodos de seguimiento](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) e implementar sus propios límites o alertas a nivel de aplicación o de monitorización.