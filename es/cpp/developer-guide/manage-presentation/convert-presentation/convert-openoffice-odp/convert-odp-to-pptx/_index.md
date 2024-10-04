---
title: Convertir ODP a PPTX
type: docs
weight: 10
url: /cpp/convert-odp-to-pptx/
---

Aspose.Slides para .NET ofrece la clase Presentation que representa un archivo de presentación. La clase [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) ahora también puede acceder a ODP a través del constructor de Presentation cuando se instancia el objeto. El siguiente ejemplo muestra cómo convertir una Presentación ODP en una Presentación PPTX.

``` cpp
// La ruta al directorio de documentos.
String dataDir = GetDataPath();

// Abrir el archivo ODP
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// Guardar la presentación ODP en formato PPTX
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```



## **Ejemplo en Vivo**
Puedes visitar la aplicación web [**Conversión Aspose.Slides**](https://products.aspose.app/slides/conversion/), que está construida con la **API Aspose.Slides.** La aplicación demuestra cómo se puede implementar la conversión de ODP a PPTX con la API Aspose.Slides.