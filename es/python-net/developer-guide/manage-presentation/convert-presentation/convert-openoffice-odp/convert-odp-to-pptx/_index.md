---
title: Convertir ODP a PPTX
type: docs
weight: 10
url: /python-net/convert-odp-to-pptx/
keywords: "Convertir Presentación de OpenOffice, ODP, ODP a PPTX, Python"
description: "Convertir ODP de OpenOffice a Presentación de PowerPoint PPTX en Python"
---

Aspose.Slides para Python a través de .NET ofrece la clase Presentation que representa un archivo de presentación. La clase [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ahora también puede acceder a ODP a través del constructor de Presentation cuando se instancia el objeto. El siguiente ejemplo muestra cómo convertir una presentación ODP en una presentación PPTX.

```py
# Importar el módulo Aspose.Slides para Python a través de .NET
import aspose.slides as slides

# Abrir el archivo ODP
pres = slides.Presentation("AccessOpenDoc.odp")

# Guardar la presentación ODP en formato PPTX
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Ejemplo en Vivo**
Puedes visitar la aplicación web [**Conversión de Aspose.Slides**](https://products.aspose.app/slides/conversion/), que está construida con la **API de Aspose.Slides.** La aplicación demuestra cómo se puede implementar la conversión de ODP a PPTX con la API de Aspose.Slides.