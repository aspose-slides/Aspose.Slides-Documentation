---
title: Convertir PowerPoint a XPS
type: docs
weight: 70
url: /es/php-java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX a XPS"
description: "Convertir PowerPoint PPT(X) a XPS "
---

## **Acerca de XPS**
Microsoft desarrolló [XPS](https://docs.fileformat.com/page-description-language/xps/) como una alternativa a [PDF](https://docs.fileformat.com/pdf/). Permite imprimir contenido generando un archivo muy similar a un PDF. El formato XPS se basa en XML. El diseño o la estructura de un archivo XPS permanece igual en todos los sistemas operativos e impresoras.

## Cuándo usar el formato Microsoft XPS

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte presentaciones PPT o PPTX al formato XPS, puedes consultar [esta aplicación de conversión en línea gratuita](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si deseas reducir los costos de almacenamiento, puedes convertir tu presentación de Microsoft PowerPoint al formato XPS. De esta manera, te resultará más fácil guardar, compartir e imprimir tus documentos.

Microsoft continúa implementando un sólido soporte para XPS en Windows (incluso en Windows 10), por lo que puede que quieras considerar guardar archivos en este formato. Si estás utilizando Windows 8.1, Windows 8, Windows 7 y Windows Vista, entonces XPS podría ser en realidad tu mejor opción para ciertas operaciones.

- **Windows 8** utiliza el formato OXPS (Open XPS) para los archivos XPS. OXPS es una versión estandarizada del formato XPS original. Windows 8 proporciona mejor soporte para archivos XPS que para archivos PDF. 
  - **XPS:** Visor/lector XPS incorporado y características de impresión a XPS disponibles. 
  - **PDF**: Lector PDF disponible, pero sin características de impresión a PDF. 

-  **Windows 7 y Windows Vista** utilizan el formato XPS original. Estos sistemas operativos también proporcionan mejor soporte para archivos XPS que para PDFs. 
  - **XPS**: Visor XPS incorporado y características de impresión a XPS disponibles. 
  - **PDF**: Sin lector PDF. Sin características de impresión a PDF. 

|<p>**Entrada PPT(X):</p><p>**![todo:texto alternativo de la imagen](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Salida XPS:</p><p>**![todo:texto alternativo de la imagen](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft eventualmente implementó soporte para operaciones de impresión en PDF a través de la característica Imprimir a PDF en Windows 10. Anteriormente, se esperaba que los usuarios imprimieran documentos a través del formato XPS. 

## Conversión de XPS con Aspose.Slides

En [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) para Java, puedes usar el método [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) expuesto por la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) para convertir toda la presentación en un documento XPS.

Al convertir una presentación a XPS, debes guardar la presentación utilizando uno de estos ajustes:

- Ajustes predeterminados (sin [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))
- Ajustes personalizados (con [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))

### **Convertir presentaciones a XPS utilizando ajustes predeterminados**

Este código de muestra te muestra cómo convertir una presentación en un documento XPS utilizando ajustes estándar:

```php
  # Crear un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # Guardar la presentación como documento XPS
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Convertir presentaciones a XPS utilizando ajustes personalizados**
Este código de muestra te muestra cómo convertir una presentación en un documento XPS utilizando ajustes personalizados:

```php
  # Crear un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # Crear la clase TiffOptions
    $options = new XpsOptions();
    # Guardar Metafiles como PNG
    $options->setSaveMetafilesAsPng(true);
    # Guardar la presentación como documento XPS
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```