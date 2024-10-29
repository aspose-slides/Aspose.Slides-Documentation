---
title: Convertir PowerPoint a XPS 
type: docs
weight: 70
url: /es/cpp/convert-powerpoint-to-xps
keywords: "Convertir, PowerPoint a XPS, Conversión, PPT a XPS, PPTX a XPS"
description: "Convertir PowerPoint PPT, PPTX a documento XPS con la API Aspose.Slides."
---

## **Acerca de XPS**
Microsoft desarrolló [XPS](https://docs.fileformat.com/page-description-language/xps/) como una alternativa a [PDF](https://docs.fileformat.com/pdf/). Permite imprimir contenido mediante la salida de un archivo muy similar a un PDF. El formato XPS se basa en XML. El diseño o estructura de un archivo XPS permanece igual en todos los sistemas operativos e impresoras. 

## Cuándo usar el formato XPS de Microsoft

{{% alert color="primary" %}} 

Para ver cómo Aspose.Slides convierte presentaciones PPT o PPTX al formato XPS, puedes consultar [esta aplicación convertidora en línea gratuita](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

Si deseas reducir costos de almacenamiento, puedes convertir tu presentación de Microsoft PowerPoint al formato XPS. De esta manera, te resultará más fácil guardar, compartir e imprimir tus documentos. 

Microsoft continúa implementando un sólido soporte para XPS en Windows (incluso en Windows 10), por lo que puede que quieras considerar guardar archivos en este formato. Si estás utilizando Windows 8.1, Windows 8, Windows 7 y Windows Vista, entonces XPS puede ser en realidad tu mejor opción para ciertas operaciones. 

- **Windows 8** utiliza el formato OXPS (Open XPS) para archivos XPS. OXPS es una versión estandarizada del formato XPS original. Windows 8 proporciona mejor soporte para archivos XPS que para archivos PDF. 
  - **XPS:** Visor/lector XPS integrado y función de impresión a XPS disponible. 
  - **PDF**: Lector PDF disponible, pero sin función de impresión a PDF. 

-  **Windows 7 y Windows Vista** utilizan el formato XPS original. Estos sistemas operativos también brindan mejor soporte para archivos XPS que para PDF. 
  - **XPS**: Visor XPS integrado y función de impresión a XPS disponible. 
  - **PDF**: Sin lector PDF. Sin función de impresión a PDF. 

|<p>**Entrada PPT(X):</p><p>**![todo:texto_alt_imagen](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Salida XPS:</p><p>**![todo:texto_alt_imagen](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft finalmente implementó soporte para operaciones de impresión en PDF a través de la función Imprimir a PDF en Windows 10. Anteriormente, se esperaba que los usuarios imprimieran documentos a través del formato XPS. 

## Conversión de XPS con Aspose.Slides

En [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) para C++, puedes usar el método [**Save**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) expuesto por la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) para convertir toda la presentación en un documento XPS. 

Al convertir una presentación a XPS, debes guardar la presentación utilizando cualquiera de estas configuraciones:

- Configuraciones predeterminadas (sin [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))
- Configuraciones personalizadas (con [**XPSOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options))

### **Convertir presentaciones a XPS utilizando configuraciones predeterminadas**

Este código de ejemplo en C++ te muestra cómo convertir una presentación en un documento XPS utilizando configuraciones estándar:

``` cpp
// Instanciar un objeto Presentation que representa un archivo de presentación
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Guardar la presentación en documento XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **Convertir presentaciones a XPS utilizando configuraciones personalizadas**
Este código de ejemplo te muestra cómo convertir una presentación en un documento XPS utilizando configuraciones personalizadas en C++:

``` cpp
// Instanciar un objeto Presentation que representa un archivo de presentación
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Instanciar la clase TiffOptions
auto options = System::MakeObject<XpsOptions>();

// Guardar Metafiles como PNG
options->set_SaveMetafilesAsPng(true);

// Guardar la presentación en documento XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```