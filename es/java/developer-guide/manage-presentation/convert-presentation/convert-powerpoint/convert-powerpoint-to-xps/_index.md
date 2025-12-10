---
title: Convertir presentaciones de PowerPoint a XPS en Java
linktitle: PowerPoint a XPS
type: docs
weight: 70
url: /es/java/convert-powerpoint-to-xps/
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
- Java
- Aspose.Slides
description: "Convertir PowerPoint PPT/PPTX a XPS de alta calidad e independiente de la plataforma en Java usando Aspose.Slides. Obtén una guía paso a paso y código de ejemplo."
---

## **Acerca de XPS**
Microsoft desarrolló [XPS](https://docs.fileformat.com/page-description-language/xps/) como una alternativa a [PDF](https://docs.fileformat.com/pdf/). Permite imprimir contenido generando un archivo muy similar a un PDF. El formato XPS se basa en XML. El diseño o la estructura de un archivo XPS permanece igual en todos los sistemas operativos e impresoras. 

## **Cuándo usar el formato Microsoft XPS**

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte presentaciones PPT o PPTX al formato XPS, puedes probar [esta aplicación de conversión en línea gratuita](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si deseas reducir los costos de almacenamiento, puedes convertir tu presentación de Microsoft PowerPoint al formato XPS. De esta manera, te resultará más fácil guardar, compartir e imprimir tus documentos. 

Microsoft sigue implementando un soporte sólido para XPS en Windows (incluso en Windows 10), por lo que podrías considerar guardar archivos en este formato. Si trabajas con Windows 8.1, Windows 8, Windows 7 y Windows Vista, XPS podría ser en realidad tu mejor alternativa para ciertas operaciones. 

- **Windows 8** utiliza el formato OXPS (Open XPS) para los archivos XPS. OXPS es una versión estandarizada del formato XPS original. Windows 8 ofrece un mejor soporte para archivos XPS que para archivos PDF. 
  - **XPS:** Visor/lector XPS incorporado y función de impresión a XPS disponible. 
  - **PDF**: Lector de PDF disponible pero no hay función de impresión a PDF. 

- **Windows 7 y Windows Vista** utilizan el formato XPS original. Estos sistemas operativos también ofrecen un mejor soporte para archivos XPS que para PDF. 
  - **XPS**: Visor XPS incorporado y función de impresión a XPS disponible. 
  - **PDF**: No hay lector de PDF. No hay función de impresión a PDF. 

|<p>**Entrada PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Salida XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft finalmente implementó soporte para operaciones de impresión en PDF mediante la función Imprimir en PDF en Windows 10. Anteriormente, se esperaba que los usuarios imprimieran documentos a través del formato XPS. 

## **Conversión a XPS con Aspose.Slides**

En [**Aspose.Slides**](https://products.aspose.com/slides/java/) para Java, puedes utilizar el método [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) expuesto por la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) para convertir toda la presentación en un documento XPS. 

Al convertir una presentación a XPS, debes guardar la presentación usando una de estas configuraciones:

- Configuración predeterminada (sin [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions))
- Configuración personalizada (con [**XPSOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions))

### **Convertir presentaciones a XPS usando la configuración predeterminada**

Este código de ejemplo en Java muestra cómo convertir una presentación a un documento XPS usando configuraciones estándar:
```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Guardar la presentación en un documento XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Convertir presentaciones a XPS usando configuración personalizada**
Este código de ejemplo muestra cómo convertir una presentación a un documento XPS usando configuraciones personalizadas en Java:
```java
// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Instanciar la clase TiffOptions
    XpsOptions options = new XpsOptions();

    // Guardar MetaFiles como PNG
    options.setSaveMetafilesAsPng(true);

    // Guardar la presentación en un documento XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Puedo guardar XPS en un flujo en lugar de un archivo?**

Sí—Aspose.Slides permite exportar directamente a un flujo, lo cual es ideal para APIs web, canalizaciones del lado del servidor o cualquier escenario en el que desees enviar el XPS sin tocar el sistema de archivos.

**¿Se trasladan las diapositivas ocultas a XPS y puedo excluirlas?**

De forma predeterminada, solo se renderizan las diapositivas regulares (visibles). Puedes [incluir o excluir diapositivas ocultas](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) mediante [configuraciones de exportación](https://reference.aspose.com/slides/java/com.aspose.slides/xpsoptions/) antes de guardar a XPS, garantizando que la salida contenga exactamente las páginas que deseas.