---
title: Convertir PowerPoint a XPS
type: docs
weight: 70
url: /es/net/convert-powerpoint-to-xps
keywords: "Convertir presentación PowerPoint, PowerPoint a XPS, PPT a XPS, PPTX a XPS, Conversión, C#, Csharp, .NET, Aspose.Slides"
description: "Convertir una presentación PowerPoint a XPS en C# o .NET."
---

## **Acerca de XPS**
Microsoft desarrolló [XPS](https://docs.fileformat.com/page-description-language/xps/) como una alternativa a [PDF](https://docs.fileformat.com/pdf/). Permite imprimir contenido generando un archivo muy similar a un PDF. El formato XPS se basa en XML. El diseño o la estructura de un archivo XPS permanece igual en todos los sistemas operativos e impresoras. 

## **Cuándo usar el formato Microsoft XPS**

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte presentaciones PPT o PPTX al formato XPS, puedes visitar [esta aplicación gratuita de conversión en línea](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si deseas reducir los costos de almacenamiento, puedes convertir tu presentación de Microsoft PowerPoint al formato XPS. De esta manera, te resultará más fácil guardar, compartir e imprimir tus documentos. 

Microsoft sigue implementando un fuerte soporte para XPS en Windows (incluso en Windows 10), por lo que podrías considerar guardar archivos en este formato. Si trabajas con Windows 8.1, Windows 8, Windows 7 y Windows Vista, entonces XPS podría ser tu mejor opción para ciertas operaciones. 

- **Windows 8** utiliza el formato OXPS (Open XPS) para los archivos XPS. OXPS es una versión estandarizada del formato XPS original. Windows 8 ofrece mejor compatibilidad con archivos XPS que con archivos PDF. 
  - **XPS:** Visor/lector XPS incorporado y función de impresión a XPS disponible. 
  - **PDF:** Lector PDF disponible pero sin función de impresión a PDF. 

- **Windows 7 y Windows Vista** utilizan el formato XPS original. Estos sistemas operativos también ofrecen mejor compatibilidad con archivos XPS que con PDFs. 
  - **XPS:** Visor XPS incorporado y función de impresión a XPS disponible. 
  - **PDF:** No hay lector PDF. No hay función de impresión a PDF. 

|<p>**Entrada PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Salida XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft finalmente implementó soporte para operaciones de impresión en PDF mediante la función Imprimir a PDF en Windows 10. Anteriormente, se esperaba que los usuarios imprimieran documentos a través del formato XPS. 

## **Conversión a XPS con Aspose.Slides**

En [**Aspose.Slides**](https://products.aspose.com/slides/net/) para .NET, puedes usar el método [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) expuesto por la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides.presentation) para convertir toda la presentación en un documento XPS. 

Al convertir una presentación a XPS, debes guardar la presentación usando una de estas configuraciones:

- Configuración predeterminada (sin [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))
- Configuración personalizada (con [**XPSOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions))

### **Convirtiendo presentaciones a XPS usando la configuración predeterminada**

Este fragmento de código en C# muestra cómo convertir una presentación a un documento XPS usando la configuración estándar:
```c#
// Instanciar un objeto Presentation que representa un archivo de presentación
 using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Guardar la presentación en un documento XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **Convirtiendo presentaciones a XPS usando la configuración personalizada**
Este fragmento de código muestra cómo convertir una presentación a un documento XPS usando configuraciones personalizadas en C#:
```c#
// Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Instanciar la clase TiffOptions
    XpsOptions options = new XpsOptions();

    // Guardar MetaFiles como PNG
    options.SaveMetafilesAsPng = true;

    // Guardar la presentación en un documento XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```


## **Preguntas frecuentes**

**¿Puedo guardar XPS en un stream en lugar de un archivo?**

Sí—Aspose.Slides te permite exportar directamente a un stream, lo cual es ideal para API web, canalizaciones del lado del servidor o cualquier escenario donde desees enviar el XPS sin tocar el sistema de archivos.

**¿Se trasladan las diapositivas ocultas al XPS y puedo excluirlas?**

De forma predeterminada, solo se renderizan las diapositivas normales (visibles). Puedes [incluir o excluir diapositivas ocultas](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/showhiddenslides/) a través de la [configuración de exportación](https://reference.aspose.com/slides/net/aspose.slides.export/xpsoptions/) antes de guardar a XPS, garantizando que la salida contenga exactamente las páginas que deseas.