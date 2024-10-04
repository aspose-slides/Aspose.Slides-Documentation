---
title: Convertir PowerPoint a XPS 
type: docs
weight: 70
url: /python-net/convert-powerpoint-to-xps
keywords: "Convertir presentación de PowerPoint, PowerPoint a XPS, PPT a XPS, PPTX a XPS, Conversión, Python, Aspose.Slides"
description: "Convierte presentación de PowerPoint a XPS en Python."
---

## **Acerca de XPS**
Microsoft desarrolló [XPS](https://docs.fileformat.com/page-description-language/xps/) como una alternativa a [PDF](https://docs.fileformat.com/pdf/). Permite imprimir contenido generando un archivo muy similar a un PDF. El formato XPS se basa en XML. El diseño o estructura de un archivo XPS permanece igual en todos los sistemas operativos e impresoras.

## Cuándo usar el formato Microsoft XPS

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte una presentación PPT o PPTX al formato XPS, puedes consultar [esta aplicación de conversión en línea gratuita](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si deseas reducir costos de almacenamiento, puedes convertir tu presentación de Microsoft PowerPoint al formato XPS. De esta manera, te será más fácil guardar, compartir e imprimir tus documentos. 

Microsoft sigue implementando un fuerte soporte para XPS en Windows (incluso en Windows 10), por lo que puede que quieras considerar guardar archivos en este formato. Si estás utilizando Windows 8.1, Windows 8, Windows 7 y Windows Vista, entonces XPS podría ser tu mejor opción para ciertas operaciones. 

- **Windows 8** utiliza el formato OXPS (Open XPS) para archivos XPS. OXPS es una versión estandarizada del formato XPS original. Windows 8 proporciona mejor soporte para archivos XPS que para archivos PDF. 
  - **XPS:** Visor/lector XPS incorporado y característica de impresión a XPS disponible. 
  - **PDF**: Lector de PDF disponible, pero sin característica de impresión a PDF. 

-  **Windows 7 y Windows Vista** utilizan el formato XPS original. Estos sistemas operativos también proporcionan mejor soporte para archivos XPS que para PDF. 
  - **XPS**: Visor XPS incorporado y característica de impresión a XPS disponible. 
  - **PDF**: Sin lector de PDF. Sin característica de impresión a PDF. 

|<p>**Entrada PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Salida XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft eventualmente implementó soporte para operaciones de impresión en PDF a través de la característica Imprimir a PDF en Windows 10. Anteriormente, se esperaba que los usuarios imprimieran documentos a través del formato XPS. 

## Conversión XPS con Aspose.Slides

En [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) para .NET, puedes utilizar el método [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expuesto por la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para convertir toda la presentación en un documento XPS. 

Al convertir una presentación a XPS, debes guardar la presentación utilizando alguna de estas configuraciones:

- Configuraciones predeterminadas (sin [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))
- Configuraciones personalizadas (con [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))

### **Convertir presentaciones a XPS utilizando configuraciones predeterminadas**

Este código de ejemplo en Python te muestra cómo convertir una presentación a un documento XPS usando configuraciones estándar:

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación
pres = slides.Presentation("Convert_XPS.pptx")

# Guardar la presentación en un documento XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```


### **Convertir presentaciones a XPS utilizando configuraciones personalizadas**
Este código de ejemplo te muestra cómo convertir una presentación a un documento XPS usando configuraciones personalizadas en Python:

```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Instanciar la clase TiffOptions
options = slides.export.XpsOptions()

# Guardar MetaFiles como PNG
options.save_metafiles_as_png = True

# Guardar la presentación en un documento XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```