---
title: Convertir PowerPoint a XPS 
type: docs
weight: 70
url: /net/convert-powerpoint-to-xps
keywords: "Convertir presentación de PowerPoint, PowerPoint a XPS, PPT a XPS, PPTX a XPS, Conversión, C#, Csharp, .NET, Aspose.Slides"
description: "Convierte presentación de PowerPoint a XPS en C# o .NET."
---

## **Acerca de XPS**
Microsoft desarrolló [XPS](https://docs.fileformat.com/page-description-language/xps/) como una alternativa a [PDF](https://docs.fileformat.com/pdf/). Permite imprimir contenido generando un archivo muy similar a un PDF. El formato XPS se basa en XML. El diseño o la estructura de un archivo XPS permanece igual en todos los sistemas operativos e impresoras. 

## Cuándo usar el formato Microsoft XPS

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte una presentación PPT o PPTX al formato XPS, puedes consultar [esta aplicación convertidora gratuita en línea](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si deseas reducir los costos de almacenamiento, puedes convertir tu presentación de Microsoft PowerPoint al formato XPS. De esta manera, te resultará más fácil guardar, compartir e imprimir tus documentos. 

Microsoft continúa implementando un fuerte soporte para XPS en Windows (incluso en Windows 10), por lo que podrías considerar guardar archivos en este formato. Si estás utilizando Windows 8.1, Windows 8, Windows 7 y Windows Vista, entonces XPS podría ser en realidad tu mejor opción para ciertas operaciones. 

- **Windows 8** utiliza el formato OXPS (Open XPS) para archivos XPS. OXPS es una versión estandarizada del formato XPS original. Windows 8 ofrece mejor soporte para archivos XPS que para archivos PDF. 
  - **XPS:** Visor/lector XPS integrado y función de impresión a XPS disponible.
  - **PDF**: Lector de PDF disponible, pero no hay función de impresión a PDF. 

-  **Windows 7 y Windows Vista** utilizan el formato XPS original. Estos sistemas operativos también ofrecen mejor soporte para archivos XPS que para PDF. 
  - **XPS**: Visor XPS integrado y función de impresión a XPS disponible.
  - **PDF**: No hay lector de PDF. No hay función de impresión a PDF. 

|<p>**Entrada PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Salida XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft finalmente implementó soporte para operaciones de impresión en PDF a través de la función Imprimir a PDF en Windows 10. Anteriormente, se esperaba que los usuarios imprimieran documentos a través del formato XPS. 

## Conversión a XPS con Aspose.Slides

En [**Aspose.Slides**](https://products.aspose.com/slides/net/) para .NET, puedes usar el método [**Guardar**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) expuesto por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) para convertir toda la presentación en un documento XPS. 

Al convertir una presentación a XPS, debes guardar la presentación utilizando una de estas configuraciones:

- Configuraciones predeterminadas (sin [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- Configuraciones personalizadas (con [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **Convirtiendo presentaciones a XPS usando configuraciones predeterminadas**

Este código de ejemplo en C# te muestra cómo convertir una presentación a un documento XPS utilizando configuraciones estándar:

```c#
// Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Guardar la presentación en un documento XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **Convirtiendo presentaciones a XPS usando configuraciones personalizadas**
Este código de ejemplo te muestra cómo convertir una presentación a un documento XPS utilizando configuraciones personalizadas en C#:

```c#
// Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Instanciar la clase XpsOptions
    XpsOptions options = new XpsOptions();

    // Guardar MetaFiles como PNG
    options.SaveMetafilesAsPng = true;

    // Guardar la presentación en un documento XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```