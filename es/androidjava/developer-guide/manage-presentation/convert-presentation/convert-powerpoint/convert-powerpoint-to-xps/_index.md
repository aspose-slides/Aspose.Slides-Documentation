---
title: Convertir presentaciones de PowerPoint a XPS en Android
linktitle: PowerPoint a XPS
type: docs
weight: 70
url: /es/androidjava/convert-powerpoint-to-xps/
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
- Android
- Java
- Aspose.Slides
description: "Convertir PowerPoint PPT/PPTX a XPS de alta calidad e independiente de la plataforma en Java usando Aspose.Slides para Android. Obtén guía paso a paso y código de ejemplo."
---
## **Visión general**

Aspose.Slides le permite convertir presentaciones de PowerPoint a XPS guardando un archivo PPT o PPTX en formato XPS. Este artículo explica cuándo puede ser útil el formato XPS y muestra cómo realizar la conversión con Aspose.Slides usando la configuración predeterminada o ajustes personalizados de [XpsOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/xpsoptions/).

## **Acerca de XPS**
Microsoft desarrolló [XPS](https://docs.fileformat.com/page-description-language/xps/) como una alternativa a [PDF](https://docs.fileformat.com/pdf/). Permite imprimir contenido generando un archivo muy similar a un PDF. El formato XPS se basa en XML. El diseño o la estructura de un archivo XPS permanece igual en todos los sistemas operativos e impresoras. 

## **Cuándo usar el formato XPS de Microsoft**

{{% alert color="info" %}} 
Para ver cómo Aspose.Slides convierte una presentación PPT o PPTX al formato XPS, puedes probar [esta aplicación de conversión en línea gratuita](https://products.aspose.app/slides/es/conversion). 
{{% /alert %}} 

Si desea reducir los costes de almacenamiento, puede convertir su presentación de Microsoft PowerPoint al formato XPS. Así le resultará más fácil guardar, compartir e imprimir sus documentos. 

Microsoft sigue implementando un fuerte soporte para XPS en Windows (incluso en Windows 10), por lo que puede considerar guardar los archivos en este formato. Si trabaja con Windows 8.1, Windows 8, Windows 7 o Windows Vista, XPS podría ser su mejor opción para ciertas operaciones. 

- **Windows 8** utiliza el formato OXPS (Open XPS) para los archivos XPS. OXPS es una versión estandarizada del formato XPS original. Windows 8 ofrece mejor soporte para archivos XPS que para archivos PDF. 
  - **XPS:** Visor/lector XPS integrado y función de impresión a XPS disponible. 
  - **PDF:** Lector PDF disponible pero sin función de impresión a PDF. 

- **Windows 7 y Windows Vista** usan el formato XPS original. Estos sistemas operativos también brindan mejor soporte para archivos XPS que para PDFs. 
  - **XPS:** Visor XPS integrado y función de impresión a XPS disponible. 
  - **PDF:** No hay lector PDF. No hay función de impresión a PDF. 

|<p>**Entrada PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Salida XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft finalmente implementó soporte para operaciones de impresión en PDF mediante la función Imprimir a PDF en Windows 10. Anteriormente, se esperaba que los usuarios imprimieran documentos a través del formato XPS. 

## **Conversión a XPS con Aspose.Slides**

En [**Aspose.Slides**](https://products.aspose.com/slides/es/androidjava/) para Java, puede usar el método [**Save**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) expuesto por la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation) para convertir toda la presentación en un documento XPS.

Al convertir una presentación a XPS, debe guardar la presentación usando una de estas configuraciones:

- Configuración predeterminada (sin [**XPSOptions**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/xpsoptions))
- Configuración personalizada (con [**XPSOptions**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/xpsoptions))

### **Convertir presentaciones a XPS usando la configuración predeterminada**

Este código de ejemplo en Java muestra cómo convertir una presentación a un documento XPS usando la configuración estándar:

```java
import com.aspose.slides.*;

// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Guardar la presentación como documento XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Convertir presentaciones a XPS usando configuración personalizada**
Este código de ejemplo muestra cómo convertir una presentación a un documento XPS usando configuraciones personalizadas en Java:

```java
import com.aspose.slides.*;

// Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Instanciar la clase XpsOptions
    XpsOptions options = new XpsOptions();

    // Guardar los Metafiles como PNG
    options.setSaveMetafilesAsPng(true);

    // Guardar la presentación como documento XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Preguntas frecuentes**

### ¿Puedo guardar en XPS en un flujo en lugar de un archivo?

Sí—Aspose.Slides le permite exportar directamente a un flujo, lo que es ideal para APIs web, canalizaciones del lado del servidor o cualquier escenario en el que desee enviar el XPS sin tocar el sistema de archivos.

### ¿Se incluyen las diapositivas ocultas en XPS y puedo excluirlas?

Por defecto, solo se renderizan las diapositivas regulares (visibles). Puede [incluir o excluir diapositivas ocultas](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) mediante la [configuración de exportación](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/xpsoptions/) antes de guardar a XPS, garantizando que la salida contenga exactamente las páginas que desea.