---
title: Convertir presentaciones de PowerPoint a XPS en PHP
linktitle: PowerPoint a XPS
type: docs
weight: 70
url: /es/php-java/convert-powerpoint-to-xps/
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
- PHP
- Aspose.Slides
description: "Convertir PowerPoint PPT/PPTX a XPS de alta calidad e independiente de plataforma usando Aspose.Slides para PHP a través de Java. Obtén guía paso a paso y código de ejemplo."
---

## **Acerca de XPS**
Microsoft desarrolló [XPS](https://docs.fileformat.com/page-description-language/xps/) como una alternativa a [PDF](https://docs.fileformat.com/pdf/). Permite imprimir contenido generando un archivo muy similar a un PDF. El formato XPS se basa en XML. El diseño o la estructura de un archivo XPS permanece igual en todos los sistemas operativos e impresoras. 

## **Cuándo usar el formato XPS de Microsoft**

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte una presentación PPT o PPTX al formato XPS, puedes consultar [esta aplicación gratuita de conversión en línea](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si deseas reducir los costos de almacenamiento, puedes convertir tu presentación de Microsoft PowerPoint al formato XPS. De esta manera, te resultará más fácil guardar, compartir e imprimir tus documentos. 

Microsoft sigue implementando un fuerte soporte para XPS en Windows (incluso en Windows 10), por lo que quizá quieras considerar guardar archivos en este formato. Si estás trabajando con Windows 8.1, Windows 8, Windows 7 y Windows Vista, entonces XPS podría ser tu mejor opción para ciertas operaciones. 

- **Windows 8** usa el formato OXPS (Open XPS) para archivos XPS. OXPS es una versión estandarizada del formato XPS original. Windows 8 ofrece mejor soporte para archivos XPS que para archivos PDF. 
  - **XPS:** Visor/lector XPS incorporado y función de impresión a XPS disponible. 
  - **PDF:** Lector PDF disponible pero sin función de impresión a PDF. 

- **Windows 7 y Windows Vista** usan el formato XPS original. Estos sistemas operativos también proveen mejor soporte para archivos XPS que para PDFs. 
  - **XPS:** Visor XPS incorporado y función de impresión a XPS disponible. 
  - **PDF:** No hay lector PDF. No hay función de impresión a PDF. 

|<p>**Entrada PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Salida XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft implementó finalmente el soporte para operaciones de impresión en PDF mediante la función Imprimir a PDF en Windows 10. Anteriormente, se esperaba que los usuarios imprimieran documentos a través del formato XPS. 

## **Conversión a XPS con Aspose.Slides**

En [**Aspose.Slides**](https://products.aspose.com/slides/php-java/) para Java, puedes usar el método [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) expuesto por la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) para convertir toda la presentación en un documento XPS.

Al convertir una presentación a XPS, debes guardar la presentación usando una de estas configuraciones:
- Configuración predeterminada (sin [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))
- Configuración personalizada (con [**XPSOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions))

### **Convertir presentaciones a XPS usando la configuración predeterminada**

Este fragmento de código muestra cómo convertir una presentación a un documento XPS usando la configuración estándar:
```php
  # Instanciar un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # Guardar la presentación en un documento XPS
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Convertir presentaciones a XPS usando configuración personalizada**
Este fragmento de código muestra cómo convertir una presentación a un documento XPS usando configuraciones personalizadas:
```php
  # Instanciar un objeto Presentation que representa un archivo de presentación
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # Instanciar la clase XpsOptions
    $options = new XpsOptions();
    # Guardar los MetaFiles como PNG
    $options->setSaveMetafilesAsPng(true);
    # Guardar la presentación en un documento XPS
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Puedo guardar en XPS en un flujo en lugar de un archivo?**

Sí—Aspose.Slides permite exportar directamente a un flujo, lo cual es ideal para API web, canalizaciones del lado del servidor o cualquier escenario en que desees enviar el XPS sin tocar el sistema de archivos.

**¿Se transfieren las diapositivas ocultas a XPS y puedo excluirlas?**

Por defecto, solo se renderizan las diapositivas regulares (visibles). Puedes [incluir o excluir diapositivas ocultas](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) mediante los [ajustes de exportación](https://reference.aspose.com/slides/php-java/aspose.slides/xpsoptions/) antes de guardar en XPS, asegurando que la salida contenga exactamente las páginas que deseas.