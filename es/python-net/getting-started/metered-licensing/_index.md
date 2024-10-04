---
title: Licenciamiento Medido
type: docs
weight: 90
url: /python-net/metered-licensing/
---

{{% alert color="primary" %}} 

El licenciamiento medido es un nuevo mecanismo de licenciamiento que puede ser utilizado junto con los métodos de licenciamiento existentes. Si deseas ser facturado en función de tu uso de las características de la API Aspose.Slides, elige el licenciamiento medido.

Cuando compras una licencia medida, obtienes claves (y no un archivo de licencia). Esta clave medida puede aplicarse utilizando la clase [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) que Aspose proporcionó para operaciones de medición. Para más detalles, consulta [Preguntas Frecuentes sobre Licenciamiento Medido](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Crea una instancia de la clase [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).
1. Pasa tus claves públicas y privadas al método `set_metered_key`.
1. Realiza algunos procesos (ejecuta tareas).
1. Llama al método `get_consumption_quantity()` de la clase Metered.

   Deberías ver la cantidad/total de solicitudes de API que has consumido hasta ahora.

Este código Python te muestra cómo establecer claves públicas y privadas medidas:

```python
import aspose.slides as slides

# Crea una instancia de la clase CAD Metered
metered = slides.Metered()

# Accede a la propiedad set_metered_key y pasa las claves públicas y privadas como parámetros
metered.set_metered_key("*****", "*****")

# Obtiene la cantidad de datos medidos antes de llamar a la API
amountbefore = slides.metered.get_consumption_quantity()
# Muestra la información
print("Cantidad Consumida Antes: " + str(amountbefore))

# Carga el documento desde el disco.
with slides.Presentation("Presentation.pptx") as pres:
   # Obtiene la cantidad de páginas del documento
   print(len(pres.slides))
   # Guarda como PDF
   pres.save("out_pdf.pdf", slides.export.SaveFormat.PDF)

# Obtiene la cantidad de datos medidos después de llamar a la API
amountafter = slides.metered.get_consumption_quantity()
# Muestra la información
print("Cantidad Consumida Después: " + str(amountafter))
```

{{% alert color="warning" title="NOTA"  %}} 

Para usar el licenciamiento medido, necesitas una conexión a internet estable porque el mecanismo de licenciamiento utiliza internet para interactuar constantemente con nuestros servicios y realizar cálculos.

{{% /alert %}} 