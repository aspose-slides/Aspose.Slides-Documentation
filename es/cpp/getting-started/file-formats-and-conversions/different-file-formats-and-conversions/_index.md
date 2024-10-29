---
title: Diferentes formatos de archivo y conversiones
type: docs
weight: 50
url: /es/cpp/different-file-formats-and-conversions/
---

## **Microsoft PowerPoint (PPT)**
### **Acerca de PPT**
[PPT](https://es.wikipedia.org/wiki/Microsoft_PowerPoint) es el formato de archivo de documento de presentación que puede ser creado, leído, manipulado y escrito por diferentes versiones de Microsoft PowerPoint. Este es el formato binario para documentos de presentación desarrollado por Microsoft.
### **PPT en Aspose.Slides para C++**
Aspose.Slides para C++ puede leer archivos PPT creados por el software listado a continuación.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

De manera similar, los archivos PPT creados por Aspose.Slides para C++ pueden ser leídos por el conjunto de software anterior.
### **Soporte integral para PPT**
Aspose.Slides para C++ proporciona soporte para casi todas las características relacionadas con el formato de archivo de documento PPT. No solo cubre las características básicas / avanzadas proporcionadas por diferentes versiones de Microsoft PowerPoint para la manipulación de documentos PPT, sino también algunas características que ni siquiera son compatibles con Microsoft PowerPoint. La principal ventaja de usar la biblioteca de la API de Aspose.Slides para C++ es la facilidad de uso para manejar tales características.

Además de las tareas básicas relacionadas con la creación, lectura y escritura de archivos de documentos PPT, hay varias características que son proporcionadas por Aspose.Slides para C++ como:

- Importar otros formatos de archivo de MS Office como OLE Objects en documentos PPT.
- Exportar documentos PPT a formatos PDF, TIFF, XPS.
- Exportar diapositivas en los documentos PPT a formatos SVG.
- Renderizar diapositivas a cualquier formato de imagen soportado por el Framework C++.
- Establecer el tamaño de las diapositivas en el documento PPT.
- Gestionar animaciones en formas.
- Gestionar presentaciones.
- Formatear texto en las diapositivas.
- Escanear texto de los documentos PPT.
- Manejar tablas en las diapositivas.
- Copia automática de maestros utilizando la característica de clonación.

Un archivo PPT generado por Aspose.Slides para C++ y abierto en Microsoft PowerPoint
## **PresentationML (PPTX, XML)**
### **Acerca de PresentationML**
PresentationML es un nombre para una familia de formatos basados en XML para documentos de presentación. Office OpenXML (OOXML) es el formato basado en XML introducido en las aplicaciones de Microsoft Office 2007. Office OpenXML es un formato de contenedor para varios lenguajes de marcado especializados basados en XML. PresentationML es el lenguaje de marcado utilizado por Microsoft Office PowerPoint 2007 para almacenar sus documentos.
### **PresentationML en Aspose.Slides para C++**
Los documentos OOXML PresentationML vienen como archivos PPTX que son paquetes XML comprimidos que siguen las especificaciones de [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides para C++ ofrece un amplio soporte para crear, leer, manipular y escribir documentos PresentationML. Además, Aspose.Slides para C++ es capaz de exportar documentos PresentationML a diferentes formatos de documento ampliamente utilizados como PDF, TIFF y XPS. Esto es posible porque Aspose.Slides para C++ fue diseñado con el objetivo de manejar de manera integral documentos de presentación y PresentationML básicamente mantiene la presentación interna de los documentos como un paquete XML comprimido.

Un documento PPTX generado por Aspose.Slides para C++ y abierto en Microsoft PowerPoint

Visualización de un documento PPTX generado por Aspose.Slides para C++ en una aplicación Zip
### **PresentationML es abierto, ¿por qué usar Aspose.Slides para C++?**
Dado que PresentationML es basado en XML, es bastante posible construir aplicaciones para el procesamiento y generación de documentos PresentationML utilizando clases XML sin depender de bibliotecas de clases de terceros como Aspose.Slides para C++. Sin embargo, hay varias ventajas de usar Aspose.Slides para C++ sobre las clases XML al trabajar con documentos PresentationML.

La especificación de OOXML es demasiado larga, con varios miles de páginas. Esto significa que, para manejar adecuadamente los documentos PresentationML, tendrá que gastar mucho tiempo y esfuerzo para comprender el formato de tales documentos. Por otro lado, al usar Aspose.Slides para C++, simplemente debe usar las clases relevantes y sus respectivos métodos / propiedades para realizar operaciones que parecen bastante complejas si se realizan a través de clases XML.

Las siguientes son algunas de las características que incluso no están disponibles al tratar con documentos PresentationML a través de clases XML:

- Exportar documentos PPT a formatos PDF, TIFF, XPS
- Exportar diapositivas en los documentos PPT a formatos SVG
- Renderizar diapositivas a cualquier formato de imagen soportado por el Framework C++
- Copia automática de maestros de presentaciones fuente utilizando la característica de clonación
- Aplicar protección a las formas

Tomemos un ejemplo de un documento PresentationML que tiene una única diapositiva con un cuadro de texto que contiene el texto "Hello World". Para leer el texto a través de clases XML, deberá escribir un programa que pueda analizar este texto simple del siguiente fragmento:

``` cpp

 <?xml version="1.0" encoding="UTF-8" standalone="yes"?>

<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">

  <p:cSld>

    <p:spTree>

      <p:nvGrpSpPr>

        <p:cNvPr id="1" name=""/>

        <p:cNvGrpSpPr/>

        <p:nvPr/>

      </p:nvGrpSpPr>

      <p:grpSpPr>

        <a:xfrm>

          <a:off x="0" y="0"/>

          <a:ext cx="0" cy="0"/>

          <a:chOff x="0" y="0"/>

          <a:chExt cx="0" cy="0"/>

        </a:xfrm></p:grpSpPr><p:sp>

          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>

          <p:cNvSpPr txBox="1"/>

            <p:nvPr/>

          </p:nvSpPr>

          <p:spPr>

            <a:xfrm>

              <a:off x="2819400" y="2590800"/>

              <a:ext cx="1297086" cy="369332"/>

            </a:xfrm>

            <a:prstGeom prst="rect">

              <a:avLst/>

            </a:prstGeom>

            <a:noFill/>

          </p:spPr>

          <p:txBody>

            <a:bodyPr wrap="none" rtlCol="0">

              <a:spAutoFit/>

            </a:bodyPr>

            <a:lstStyle/>

            <a:p>

              <a:r>

                <a:rPr lang="en-US"/>

                <a:t>Hello World

                </a:t>

              </a:r>

              <a:endParaRPr lang="en-US"/>

            </a:p>

          </p:txBody>

        </p:sp>

    </p:spTree>

  </p:cSld>

  <p:clrMapOvr>

    <a:masterClrMapping/>

  </p:clrMapOvr>

</p:sld>

```
## **Conversión de PPT a PPTX**
### **Acerca de la conversión**
Aspose.Slides ahora también soporta convertir PPT a PPTX.
### **Características soportadas en la conversión**
Aspose.Slides para C++ proporciona soporte parcial para convertir presentaciones del formato de archivo de documento PPT a presentaciones del formato de archivo PPTX. Dado que el soporte para la característica de conversión de presentación mencionada acaba de ser introducido en Aspose.Slides para C++, por el momento tiene capacidades limitadas y solo funciona para la forma simple de presentaciones. La principal ventaja que proporciona la biblioteca de la API de Aspose.Slides para C++ para convertir presentaciones de PPT a formato PPTX es la facilidad de uso de la API para alcanzar el objetivo deseado. Por favor, proceda a este [enlace]() a la sección de fragmentos de código para más detalles. La siguiente sección ilustra claramente qué características son soportadas y no soportadas al convertir presentaciones del formato PPT a presentaciones del formato PPTX.
### **Características soportadas**
Las siguientes características están soportadas durante la conversión:

- Conversión de la estructura de maestros, diseños y diapositivas
- Conversión de gráficos
- Agrupar formas
- Conversión de auto-formas, incluyendo Rectángulos y Elipses. Sin embargo, es posible que las auto-formas tengan valores de ajustes incorrectos
- Formas con geometría personalizada. A veces pueden no ser convertidas
- Estilos de relleno de Texturas y Imágenes para auto-formas. A veces pueden no ser convertidas
- Conversión de marcadores de posición
- Conversión de texto en marcos de texto y titulares de texto. Sin embargo, los viñetas, alineación y tabulaciones no están completamente implementadas
### **Características no soportadas**
Las siguientes características no están soportadas durante la conversión:

- Diapositiva con notas ya que leer las notas no está implementado en PPTX. En caso de que PPT las tenga, no se puede guardar como PPTX
- Conversión de Líneas y Polilíneas
- Formatos de línea y relleno
- Estilos de relleno degradado
- Marcos OLE, Tablas, Marcos de Video y Audio, etc.
- La animación y otras propiedades de la presentación se omiten
  Nuevas características o faltantes se agregarán posteriormente en las próximas versiones de Aspose.Slides para C++.

Presentación PPT de origen

Presentación PPTX convertida
## **Formato de Documento Portátil (PDF)**
### **Acerca de PDF**
El [Formato de Documento Portátil](https://es.wikipedia.org/wiki/PDF) es un formato de archivo que fue creado por Adobe System para el intercambio de documentos entre diferentes organizaciones. El propósito de este formato era hacer posible que el contenido de los documentos pudiera ser representado de tal manera que su apariencia visual no dependiera de la plataforma en la que se estuviera viendo.
### **PDF en Aspose.Slides para C++**
Cualquier documento de presentación que puede ser cargado en Aspose.Slides para C++ puede ser convertido a documento PDF que puede ajustarse a [PDF 1.5](https://es.wikipedia.org/wiki/PDF/A) o [PDF /A-1b](https://es.wikipedia.org/wiki/PDF/A) según su elección. Aspose.Slides para C++ exporta los documentos de presentación a PDF de tal manera que la mayoría de las veces, el documento PDF exportado se ve casi similar al documento de presentación original. La solución de Aspose admite las siguientes características de los documentos de presentación al convertir a documentos PDF:

- Imágenes, Cuadros de texto y otras Formas
- Texto y Formateo
- Párrafos y Formateo
- Hipervínculos
- Encabezados y Pies de página
- Viñetas
- Tablas

Puede exportar los documentos de presentación a documentos PDF directamente utilizando solo el componente de Aspose.Slides para C++. Es decir, no necesita ningún otro componente de terceros o Aspose.Pdf para este propósito. Además, puede personalizar la exportación de la presentación a PDF con diferentes opciones como se explica en [este tema](/slides/es/cpp/converting-presentation-to-pdf/).

Un documento de presentación convertido a documento PDF a través de Aspose.Slides para C++
## **Especificación del Analizador XML (XPS)**
### **Acerca de XPS**
La [Especificación del Analizador XML](https://es.wikipedia.org/wiki/Open_XML_Paper_Specification) es un lenguaje de descripción de página y un formato de documento fijo desarrollado originalmente por Microsoft. Al igual que PDF, XPS es un formato de documento de diseño fijo diseñado para preservar la fidelidad del documento y proporcionar una apariencia de documento independiente del dispositivo.
### **XPS en Aspose.Slides para C++**
Cualquier documento de presentación que puede ser cargado por Aspose.Slides para C++ puede ser convertido a formato XPS. Aspose.Slides para C++ utiliza el motor de diseño de página y renderizado de alta fidelidad para producir salida en formato de documento XPS de diseño fijo. Vale la pena mencionar que Aspose.Slides para C++ genera directamente XPS sin depender de las clases de Windows Presentation Foundation (WPF) que están empaquetadas con el Framework C++ 3.5, permitiendo así que Aspose.Slides para C++ produzca documentos XPS en máquinas que ejecutan versiones anteriores del Framework C++ a la versión 3.5. Puede aprender sobre la exportación de documentos de presentación a documentos XPS a través de Aspose.Slides para C++ en [este tema](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/).

Un documento de presentación convertido a documento XPS a través de Aspose.Slides para C++