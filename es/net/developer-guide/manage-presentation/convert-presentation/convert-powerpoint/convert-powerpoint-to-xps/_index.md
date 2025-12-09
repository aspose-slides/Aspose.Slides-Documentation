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
description: "Convertir presentaciones PowerPoint PPT/PPTX a XPS de alta calidad e independiente de la plataforma en .NET usando Aspose.Slides. Obtén una guía paso a paso y un ejemplo de código C#."
---

## **Acerca de XPS**
Microsoft desarrolló [XPS](https://docs.fileformat.com/page-description-language/xps/) como una alternativa a [PDF](https://docs.fileformat.com/pdf/). Permite imprimir contenido generando un archivo muy similar a un PDF. El formato XPS se basa en XML. El diseño o la estructura de un archivo XPS permanece igual en todos los sistemas operativos e impresoras. 

## **Cuándo usar el formato Microsoft XPS**

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte presentaciones PPT o PPTX al formato XPS, puede visitar [esta aplicación convertidora en línea gratuita](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si desea reducir los costos de almacenamiento, puede convertir su presentación de Microsoft PowerPoint al formato XPS. De esta manera, le resultará más fácil guardar, compartir e imprimir sus documentos. 

Microsoft sigue implementando un fuerte soporte para XPS en Windows (incluso en Windows 10), por lo que puede considerar guardar los archivos en este formato. Si está trabajando con Windows 8.1, Windows 8, Windows 7 y Windows Vista, XPS podría ser su mejor opción para ciertas operaciones. 

- **Windows 8** usa el formato OXPS (Open XPS) para los archivos XPS. OXPS es una versión estandarizada del formato XPS original. Windows 8 ofrece mejor soporte para archivos XPS que para archivos PDF. 
  - **XPS:** Visor/lector XPS incorporado y función de impresión a XPS disponible. 
  - **PDF:** Lector PDF disponible pero sin función de impresión a PDF. 

- **Windows 7 y Windows Vista** usan el formato XPS original. Estos sistemas operativos también proporcionan mejor soporte para archivos XPS que para PDFs. 
  - **XPS:** Visor XPS incorporado y función de impresión a XPS disponible. 
  - **PDF:** No hay lector PDF. No hay función de impresión a PDF. 

|<p>**Entrada PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Salida XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft finalmente implementó soporte para operaciones de impresión en PDF mediante la función Imprimir a PDF en Windows 10. Anteriormente, se esperaba que los usuarios imprimieran documentos a través del formato XPS. 

## **Conversión a XPS con Aspose.Slides**

En [**Aspose.Slides**](https://products.aspose.com/slides/net/) para .NET, puede usar el método [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) expuesto por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) para convertir toda la presentación en un documento XPS. 

Al convertir una presentación a XPS, debe guardar la presentación usando una de estas configuraciones:

- Configuración predeterminada (sin [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- Configuración personalizada (con [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **Convertir presentaciones a XPS usando la configuración predeterminada**

Este código de ejemplo en C# muestra cómo convertir una presentación a un documento XPS usando la configuración estándar:
```c#
// Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Guardar la presentación en un documento XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **Convertir presentaciones a XPS usando configuración personalizada**
Este código de ejemplo muestra cómo convertir una presentación a un documento XPS usando configuración personalizada en C#:
```c#
// Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Instanciar la clase TiffOptions
    XpsOptions options = new XpsOptions();

    // Guardar Metafiles como PNG
    options.SaveMetafilesAsPng = true;

    // Guardar la presentación en un documento XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```


## **Preguntas frecuentes**

**¿Puedo guardar XPS en un flujo en lugar de un archivo?**

Sí, Aspose.Slides le permite exportar directamente a un flujo, lo que es ideal para API web, pipelines del lado del servidor o cualquier escenario en el que desee enviar el XPS sin tocar el sistema de archivos.

**¿Se transfieren las diapositivas ocultas a XPS y puedo excluirlas?**

Por defecto, solo se renderizan las diapositivas normales (visibles). Puede [incluir o excluir diapositivas ocultas](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/) a través de los [ajustes de exportación](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) antes de guardar a XPS, asegurando que la salida contenga exactamente las páginas que desea.