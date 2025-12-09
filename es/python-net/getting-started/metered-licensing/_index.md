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
description: "Aprenda cómo el licenciamiento medido de Aspose.Slides para Python a través de .NET le permite procesar archivos PowerPoint y OpenDocument de forma flexible, pagando solo por lo que usa."
---

## **Aplicar claves medidoras**

{{% alert color="primary" %}} 

La licencia con medición es un nuevo mecanismo de licenciamiento que puede usarse junto a los métodos de licenciamiento existentes. Si desea que se le facture según su uso de las funciones de la API Aspose.Slides, elija la licencia con medición.

Al comprar una licencia con medición, recibe claves (y no un archivo de licencia). Esta clave medidora puede aplicarse usando la clase [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) que Aspose proporciona para operaciones de medición. Para más detalles, vea las [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Crear una instancia de la clase [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).
1. Pasar sus claves pública y privada al método [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str).
1. Realizar algún procesamiento (ejecutar tareas).
1. Llamar al método [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) de la clase `Metered`.

Debería ver la cantidad de solicitudes API que ha consumido hasta el momento.

Este código de ejemplo le muestra cómo usar la licencia con medición:
```python
import aspose.slides as slides

# Crea una instancia de la clase Metered
metered = slides.Metered()

# Pasa las claves pública y privada al objeto Metered
metered.set_metered_key("<valid public key>", "<valid private key>")

# Obtiene el valor de cantidad consumida antes de las llamadas a la API
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Haz algo con la API de Aspose.Slides aquí
# ...

# Obtiene el valor de cantidad consumida después de las llamadas a la API
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```


{{% alert color="warning" title="NOTE"  %}} 

Para usar la licencia con medición, necesita una conexión a Internet estable porque el mecanismo de licenciamiento usa Internet para interactuar constantemente con nuestros servicios y realizar cálculos.

{{% /alert %}} 

## **FAQ**

**¿Puedo usar una licencia con medición junto con una licencia regular (perpetua o temporal) en la misma aplicación?**

Sí. La licencia con medición es un mecanismo adicional que puede usarse junto a los [métodos de licenciamiento](/slides/es/python-net/licensing/) existentes. Usted elige qué mecanismo aplicar cuando la aplicación inicia.

**¿Qué se cuenta exactamente como consumo bajo una licencia con medición: ¿operaciones o archivos?**

Se contabiliza el uso de la API, es decir, el número de solicitudes u operaciones. Puede obtener el consumo actual mediante los [consumption-tracking methods](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).

**¿Es la licencia con medición adecuada para microservicios y entornos serverless donde las instancias se reinician con frecuencia?**

Sí. Como la contabilización se realiza a nivel de llamada a la API, los escenarios con arranques en frío frecuentes son compatibles, siempre que haya acceso de red estable para los cálculos de medición.

**¿La funcionalidad de la biblioteca difiere al usar una licencia con medición comparada con una licencia perpetua?**

No. Esto solo afecta al mecanismo de licenciamiento y facturación; las capacidades del producto son las mismas.

**¿Cómo se relaciona la licencia con medición con la versión de prueba y la licencia temporal?**

La versión de prueba tiene limitaciones y marcas de agua, la [temporary license](https://purchase.aspose.com/temporary-license/) elimina las limitaciones durante 30 días, y la licencia con medición elimina las limitaciones y cobra según el uso real.

**¿Puedo controlar el presupuesto reaccionando automáticamente cuando se supera un umbral de consumo?**

Sí. Una práctica común es leer periódicamente el consumo actual mediante los [tracking methods](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) e implementar sus propios límites o alertas a nivel de aplicación o monitoreo.