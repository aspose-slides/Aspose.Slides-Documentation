---
title: Convertir presentaciones de PowerPoint a XPS en .NET
linktitle: PowerPoint a XPS
type: docs
weight: 70
url: /es/net/convert-powerpoint-to-xps/
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
- .NET
- C#
- Aspose.Slides
description: "Convierta archivos PowerPoint PPT/PPTX a XPS de alta calidad e independiente de la plataforma en .NET usando Aspose.Slides. Obtenga una guía paso a paso y un ejemplo de código C#."
---
## **Descripción general**

Aspose.Slides le permite convertir presentaciones de PowerPoint a XPS guardando un archivo PPT o PPTX en el formato XPS. Este artículo explica cuándo puede ser útil el formato XPS y muestra cómo realizar la conversión con Aspose.Slides utilizando la configuración predeterminada o configuraciones personalizadas de [XpsOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/xpsoptions/) .

## **Acerca de XPS**
Microsoft desarrolló [XPS](https://docs.fileformat.com/page-description-language/xps/) como alternativa a [PDF](https://docs.fileformat.com/pdf/). Permite imprimir contenido generando un archivo muy similar a un PDF. El formato XPS se basa en XML. El diseño o la estructura de un archivo XPS permanece igual en todos los sistemas operativos y en todas las impresoras. 

## **Cuándo usar el formato XPS de Microsoft**

{{% alert color="info" %}} 

Para ver cómo Aspose.Slides convierte presentaciones PPT o PPTX al formato XPS, puede consultar [esta aplicación gratuita de conversión en línea](https://products.aspose.app/slides/es/conversion). 

{{% /alert %}} 

Si desea reducir los costes de almacenamiento, puede convertir su presentación de Microsoft PowerPoint al formato XPS. De esta manera, le resultará más fácil guardar, compartir e imprimir sus documentos. 

Microsoft sigue implementando un fuerte soporte para XPS en Windows (incluso en Windows 10), por lo que puede considerar guardar los archivos en este formato. Si trabaja con Windows 8.1, Windows 8, Windows 7 y Windows Vista, XPS podría ser su mejor opción para ciertas operaciones. 

- **Windows 8** utiliza el formato OXPS (Open XPS) para los archivos XPS. OXPS es una versión estandarizada del formato XPS original. Windows 8 ofrece mejor soporte para archivos XPS que para archivos PDF. 
  - **XPS:** Visor/lector de XPS integrado y función de impresión a XPS disponible. 
  - **PDF**: Lector de PDF disponible pero sin función de impresión a PDF. 

-  **Windows 7 y Windows Vista** utilizan el formato XPS original. Estos sistemas operativos también ofrecen mejor soporte para archivos XPS que para PDFs. 
  - **XPS**: Visor de XPS integrado y función de impresión a XPS disponible. 
  - **PDF**: No hay lector de PDF. No hay función de impresión a PDF. 

|<p>**Entrada PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Salida XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft finalmente implementó soporte para operaciones de impresión en PDF mediante la función Imprimir a PDF en Windows 10. Anteriormente, se esperaba que los usuarios imprimieran documentos a través del formato XPS. 

## **Conversión a XPS con Aspose.Slides**

En [**Aspose.Slides**](https://products.aspose.com/slides/es/net/) para .NET, puede usar el método [**Save**](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/methods/save/index) expuesto por la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation) para convertir toda la presentación en un documento XPS. 

Al convertir una presentación a XPS, debe guardar la presentación usando una de estas configuraciones:

- Configuración predeterminada (sin [**XPSOptions**](https://reference.aspose.com/slides/es/net/aspose.slides.export/xpsoptions))
- Configuración personalizada (con [**XPSOptions**](https://reference.aspose.com/slides/es/net/aspose.slides.export/xpsoptions))

### **Convertir presentaciones a XPS usando la configuración predeterminada**

Este código de ejemplo en C# muestra cómo convertir una presentación a un documento XPS usando la configuración estándar:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Guardar la presentación en un documento XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **Convertir presentaciones a XPS usando configuraciones personalizadas**

Este código de ejemplo muestra cómo convertir una presentación a un documento XPS usando configuraciones personalizadas en C#:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Instanciar la clase TiffOptions
    XpsOptions options = new XpsOptions();

    // Guardar los Metafiles como PNG
    options.SaveMetafilesAsPng = true;

    // Guardar la presentación en un documento XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **Preguntas frecuentes**

### ¿Puedo guardar XPS en un flujo en lugar de un archivo?

Sí—Aspose.Slides le permite exportar directamente a un flujo, lo que resulta ideal para API web, canalizaciones del lado del servidor o cualquier escenario en el que desee enviar el XPS sin tocar el sistema de archivos.

### ¿Se transfieren las diapositivas ocultas a XPS y puedo excluirlas?

Por defecto, solo se renderizan las diapositivas normales (visibles). Puede [incluir o excluir diapositivas ocultas](https://reference.aspose.com/slides/es/net/aspose.slides.export/xpsoptions/showhiddenslides/) mediante la [configuración de exportación](https://reference.aspose.com/slides/es/net/aspose.slides.export/xpsoptions/) antes de guardar en XPS, asegurándose de que la salida contenga exactamente las páginas que desea.