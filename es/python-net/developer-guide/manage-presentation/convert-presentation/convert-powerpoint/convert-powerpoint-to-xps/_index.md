---
title: Convertir presentaciones de PowerPoint a XPS en Python
linktitle: PowerPoint a XPS
type: docs
weight: 70
url: /es/python-net/convert-powerpoint-to-xps/
keywords:
- convertir PowerPoint
- convertir presentación
- PowerPoint a XPS
- presentación a XPS
- PPT a XPS
- PPTX a XPS
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Convertir PowerPoint PPT/PPTX a XPS de alta calidad e independiente de la plataforma en Python usando Aspose.Slides. Obtén una guía paso a paso y código de ejemplo."
---

## **Acerca de XPS**
Microsoft desarrolló [XPS](https://docs.fileformat.com/page-description-language/xps/) como una alternativa a [PDF](https://docs.fileformat.com/pdf/). Permite imprimir contenido generando un archivo muy similar a un PDF. El formato XPS se basa en XML. El diseño o la estructura de un archivo XPS permanece igual en todos los sistemas operativos e impresoras. 

## Cuándo usar el formato Microsoft XPS

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte presentaciones PPT o PPTX al formato XPS, puedes consultar [esta aplicación de conversión en línea gratuita](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si deseas reducir los costos de almacenamiento, puedes convertir tu presentación de Microsoft PowerPoint al formato XPS. De esta manera, te resultará más fácil guardar, compartir e imprimir tus documentos. 

Microsoft sigue implementando un soporte sólido para XPS en Windows (incluso en Windows 10), por lo que podrías considerar guardar los archivos en este formato. Si trabajas con Windows 8.1, Windows 8, Windows 7 y Windows Vista, XPS podría ser tu mejor opción para ciertas operaciones. 

- **Windows 8** usa el formato OXPS (Open XPS) para archivos XPS. OXPS es una versión estandarizada del formato XPS original. Windows 8 ofrece mejor soporte para archivos XPS que para archivos PDF. 
  - **XPS:** Visor/lector XPS incorporado y función de impresión a XPS disponible. 
  - **PDF**: Lector PDF disponible pero sin función de impresión a PDF. 

- **Windows 7 y Windows Vista** usan el formato XPS original. Estos sistemas operativos también ofrecen mejor soporte para archivos XPS que para PDFs. 
  - **XPS**: Visor XPS incorporado y función de impresión a XPS disponible. 
  - **PDF**: No hay lector PDF. No hay función de impresión a PDF. 

|<p>**Entrada PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Salida XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft finalmente implementó soporte para operaciones de impresión en PDF mediante la función Imprimir a PDF en Windows 10. Anteriormente, se esperaba que los usuarios imprimieran documentos a través del formato XPS. 

## Conversión a XPS con Aspose.Slides

En [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) para .NET, puedes usar el método [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expuesto por la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para convertir toda la presentación en un documento XPS. 

Al convertir una presentación a XPS, debes guardar la presentación usando una de estas configuraciones:

- Configuraciones predeterminadas (sin [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))
- Configuraciones personalizadas (con [**XPSOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/))

### **Convertir presentaciones a XPS usando configuraciones predeterminadas**

Este código de ejemplo en Python muestra cómo convertir una presentación a un documento XPS usando configuraciones estándar:
```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación
pres = slides.Presentation("Convert_XPS.pptx")

# Guardar la presentación en un documento XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```


### **Convertir presentaciones a XPS usando configuraciones personalizadas**
Este código de ejemplo muestra cómo convertir una presentación a un documento XPS usando configuraciones personalizadas en Python:
```py
import aspose.slides as slides

# Instanciar un objeto Presentation que representa un archivo de presentación
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Instanciar la clase TiffOptions
options = slides.export.XpsOptions()

# Guardar los MetaFiles como PNG
options.save_metafiles_as_png = True

# Guardar la presentación en un documento XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```


## **Preguntas frecuentes**

**¿Puedo guardar XPS en un flujo en lugar de un archivo?**

Sí—Aspose.Slides permite exportar directamente a un flujo, lo que es ideal para APIs web, canalizaciones del lado del servidor o cualquier escenario en el que desees enviar el XPS sin tocar el sistema de archivos.

**¿Se transfieren las diapositivas ocultas a XPS y puedo excluirlas?**

De forma predeterminada, solo se renderizan las diapositivas normales (visibles). Puedes [incluir o excluir diapositivas ocultas](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) a través de los [ajustes de exportación](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/) antes de guardar a XPS, garantizando que la salida contenga exactamente las páginas que deseas.