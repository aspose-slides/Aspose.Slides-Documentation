---
title: Convertir presentaciones de PowerPoint a XPS en C++
linktitle: PowerPoint a XPS
type: docs
weight: 70
url: /es/cpp/convert-powerpoint-to-xps
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a XPS
- presentación a XPS
- diapositiva a XPS
- PPT a XPS
- PPTX a XPS
- guardar PPT como XPS
- guardar PPTX como XPS
- exportar PPT a XPS
- exportar PPTX a XPS
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Convierta presentaciones PowerPoint PPT/PPTX a XPS de alta calidad e independiente de la plataforma en C++ usando Aspose.Slides. Obtenga una guía paso a paso y código de ejemplo."
---

## **Acerca de XPS**
Microsoft desarrolló [XPS](https://docs.fileformat.com/page-description-language/xps/) como una alternativa a [PDF](https://docs.fileformat.com/pdf/). Permite imprimir contenido generando un archivo muy similar a un PDF. El formato XPS se basa en XML. El diseño o la estructura de un archivo XPS se mantiene igual en todos los sistemas operativos e impresoras. 

## **Cuándo usar el formato Microsoft XPS**

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte una presentación PPT o PPTX al formato XPS, puedes visitar [esta aplicación de conversión en línea gratuita](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si deseas reducir los costos de almacenamiento, puedes convertir tu presentación de Microsoft PowerPoint al formato XPS. De esta forma, te resultará más fácil guardar, compartir e imprimir tus documentos. 

Microsoft sigue implementando un soporte sólido para XPS en Windows (incluso en Windows 10), por lo que podrías considerar guardar archivos en este formato. Si trabajas con Windows 8.1, Windows 8, Windows 7 y Windows Vista, XPS podría ser, de hecho, tu mejor opción para ciertas operaciones. 

- **Windows 8** utiliza el formato OXPS (Open XPS) para archivos XPS. OXPS es una versión estandarizada del formato XPS original. Windows 8 ofrece mejor soporte para archivos XPS que para archivos PDF. 
  - **XPS:** Visor/lector XPS integrado y función de imprimir a XPS disponible. 
  - **PDF**: Lector de PDF disponible pero sin función de imprimir a PDF. 

- **Windows 7 y Windows Vista** utilizan el formato XPS original. Estos sistemas operativos también ofrecen mejor soporte para archivos XPS que para PDFs. 
  - **XPS**: Visor XPS integrado y función de imprimir a XPS disponible. 
  - **PDF**: No hay lector de PDF. No hay función de imprimir a PDF. 

|<p>**Entrada PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)</p>|<p>**Salida XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)</p>|
| :- | :- |

Microsoft finalmente implementó soporte para operaciones de impresión en PDF mediante la función Imprimir a PDF en Windows 10. Anteriormente, se esperaba que los usuarios imprimieran documentos a través del formato XPS. 

## **Conversión a XPS con Aspose.Slides**

En [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) para C++, puedes usar el método [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) expuesto por la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) para convertir toda la presentación en un documento XPS. 

Al convertir una presentación a XPS, debes guardar la presentación usando una de estas configuraciones:

- Configuración predeterminada (sin [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))
- Configuración personalizada (con [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))

### **Convertir presentaciones a XPS usando la configuración predeterminada**

Este código de ejemplo en C++ muestra cómo convertir una presentación a un documento XPS usando la configuración estándar:
``` cpp
// Instanciar un objeto Presentation que representa un archivo de presentación
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Guardar la presentación en un documento XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **Convertir presentaciones a XPS usando configuración personalizada**
Este código de ejemplo muestra cómo convertir una presentación a un documento XPS usando configuraciones personalizadas en C++:
``` cpp
// Instanciar un objeto Presentation que representa un archivo de presentación
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Instanciar la clase TiffOptions
auto options = System::MakeObject<XpsOptions>();

// Guardar MetaFiles como PNG
options->set_SaveMetafilesAsPng(true);

// Guardar la presentación en un documento XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```


## **Preguntas frecuentes**

**¿Puedo guardar en XPS en un flujo en lugar de un archivo?**

Sí—Aspose.Slides permite exportar directamente a un flujo, lo que es ideal para API web, canalizaciones del lado del servidor, o cualquier escenario en el que desees enviar el XPS sin tocar el sistema de archivos.

**¿Se transfieren las diapositivas ocultas a XPS y puedo excluirlas?**

Por defecto, solo se renderizan las diapositivas normales (visibles). Puedes [incluir o excluir diapositivas ocultas](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) mediante la [configuración de exportación](https://reference.aspose.com/slides/cpp/aspose.slides.export/xpsoptions/) antes de guardar en XPS, asegurando que la salida contenga exactamente las páginas que deseas.