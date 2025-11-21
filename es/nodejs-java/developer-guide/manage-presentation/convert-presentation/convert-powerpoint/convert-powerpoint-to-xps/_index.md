---
title: Convertir PowerPoint a XPS
type: docs
weight: 70
url: /es/nodejs-java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX a XPS"
description: "Convertir PowerPoint PPT(X) a XPS en JavaScript"
---

## **Acerca de XPS**

Microsoft desarrolló [XPS](https://docs.fileformat.com/page-description-language/xps/) como una alternativa a [PDF](https://docs.fileformat.com/pdf/). Permite imprimir contenido generando un archivo muy parecido a un PDF. El formato XPS se basa en XML. El diseño o la estructura de un archivo XPS permanece igual en todos los sistemas operativos e impresoras. 

## **Cuándo usar el formato Microsoft XPS**

{{% alert color="primary" %}} 
Para ver cómo Aspose.Slides convierte una presentación PPT o PPTX al formato XPS, puede consultar [esta aplicación gratuita de conversión en línea](https://products.aspose.app/slides/conversion). 
{{% /alert %}} 

Si desea reducir los costos de almacenamiento, puede convertir su presentación de Microsoft PowerPoint al formato XPS. De esta forma encontrará más fácil guardar, compartir e imprimir sus documentos. 

Microsoft sigue implementando un fuerte soporte para XPS en Windows (incluso en Windows 10), por lo que puede considerar guardar archivos en este formato. Si está trabajando con Windows 8.1, Windows 8, Windows 7 y Windows Vista, XPS podría ser su mejor opción para ciertas operaciones. 

- **Windows 8** usa el formato OXPS (Open XPS) para los archivos XPS. OXPS es una versión estandarizada del formato XPS original. Windows 8 ofrece mejor compatibilidad con archivos XPS que con archivos PDF. 
  - **XPS:** Visor/lector XPS incorporado y función de impresión a XPS disponible. 
  - **PDF:** Lector PDF disponible pero sin función de impresión a PDF. 

- **Windows 7 y Windows Vista** usan el formato XPS original. Estos sistemas operativos también brindan mejor compatibilidad con archivos XPS que con PDFs. 
  - **XPS:** Visor XPS incorporado y función de impresión a XPS disponible. 
  - **PDF:** No hay lector PDF. No hay función de impresión a PDF. 

|<p>**Entrada PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Salida XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft implementó finalmente el soporte para operaciones de impresión en PDF mediante la función Imprimir a PDF en Windows 10. Anteriormente, se esperaba que los usuarios imprimieran documentos a través del formato XPS. 

## **Conversión a XPS con Aspose.Slides**

En [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), puede usar el método [**save**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) expuesto por la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) para convertir toda la presentación en un documento XPS.

Al convertir una presentación a XPS, debe guardar la presentación usando una de estas configuraciones:

- Configuración predeterminada (sin [**XPSOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions))
- Configuración personalizada (con [**XPSOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions))

### **Convertir presentaciones a XPS usando la configuración predeterminada**

Este código de muestra en JavaScript muestra cómo convertir una presentación a un documento XPS usando la configuración estándar:
```javascript
// Instanciar un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // Guardar la presentación en un documento XPS
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Convertir presentaciones a XPS usando la configuración personalizada**

Este código de muestra muestra cómo convertir una presentación a un documento XPS usando configuraciones personalizadas en JavaScript:
```javascript
// Instanciar un objeto Presentation que representa un archivo de presentación
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // Instanciar la clase TiffOptions
    var options = new aspose.slides.XpsOptions();
    // Guardar MetaFiles como PNG
    options.setSaveMetafilesAsPng(true);
    // Guardar la presentación en un documento XPS
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Puedo guardar XPS en un flujo (stream) en lugar de un archivo?**

Sí—Aspose.Slides le permite exportar directamente a un flujo, lo que es ideal para API web, canalizaciones del lado del servidor o cualquier escenario en el que necesite enviar el XPS sin tocar el sistema de archivos.

**¿Se conservan las diapositivas ocultas al exportar a XPS y puedo excluirlas?**

Por defecto, solo se renderizan las diapositivas regulares (visibles). Puede [incluir o excluir diapositivas ocultas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) mediante [configuraciones de exportación](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions/) antes de guardar a XPS, garantizando que la salida contenga exactamente las páginas que desea.