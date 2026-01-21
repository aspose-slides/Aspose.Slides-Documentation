---
title: Diferentes formatos de archivo y conversiones
type: docs
weight: 50
url: /es/cpp/different-file-formats-and-conversions/
---

## **Microsoft PowerPoint (PPT)**
### **Acerca de PPT**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) es el formato de archivo de documento de presentación que puede ser creado, leído, manipulado y escrito por diferentes versiones de Microsoft PowerPoint. Este es el formato binario para documentos de presentación desarrollado por Microsoft.
### **PPT en Aspose.Slides for C++**
Aspose.Slides for C++ puede leer archivos PPT creados por el software enumerado a continuación.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

De manera similar, los archivos PPT creados por Aspose.Slides for C++ pueden ser leídos por el conjunto de software anterior.
### **Soporte integral para PPT**
Aspose.Slides for C++ ofrece soporte para casi todas las características relacionadas con el formato de archivo de documento PPT. No sólo cubre las funciones básicas/avanzadas proporcionadas por diferentes versiones de Microsoft PowerPoint para la manipulación de documentos PPT, sino también algunas funcionalidades que ni siquiera son compatibles con Microsoft PowerPoint. La principal ventaja de usar la biblioteca API de Aspose.Slides for C++ es la facilidad de uso para manejar dichas funciones.

Además de las tareas básicas relacionadas con crear, leer y escribir archivos de documentos PPT, hay varias características que ofrece Aspose.Slides for C++ como:

- Importar otros formatos de archivo MS Office como objetos OLE en documentos PPT.
- Exportar documentos PPT a formatos PDF, TIFF, XPS.
- Exportar diapositivas en los documentos PPT a formatos SVG.
- Renderizar diapositiva a cualquier formato de imagen compatible con el Framework C++.
- Establecer el tamaño de las diapositivas en el documento PPT.
- Gestionar animaciones en formas.
- Gestionar presentaciones de diapositivas.
- Formatear texto en diapositivas.
- Escanear texto de los documentos PPT.
- Manipular tablas en diapositivas.
- Copia automática de masters mediante la función de clonación.

Un archivo PPT generado por Aspose.Slides for C++ y abierto en Microsoft PowerPoint
## **PresentationML (PPTX, XML)**
### **Acerca de PresentationML**
PresentationML es el nombre de una familia de formatos basados en XML para documentos de presentación. Office OpenXML (OOXML) es el formato basado en XML introducido en las aplicaciones de Microsoft Office 2007. Office OpenXML es un formato contenedor para varios lenguajes de marcado basados en XML especializados. PresentationML es el lenguaje de marcado utilizado por Microsoft Office PowerPoint 2007 para almacenar sus documentos.
### **PresentationML en Aspose.Slides for C++**
Los documentos OOXML PresentationML aparecen como archivos PPTX que son paquetes XML comprimidos siguiendo las especificaciones [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for C++ soporta extensamente la creación, lectura, manipulación y escritura de documentos PresentationML. Además, Aspose.Slides for C++ es capaz de exportar documentos PresentationML a diferentes formatos de documento ampliamente usados como PDF, TIFF y XPS. Esto es posible porque Aspose.Slides for C++ fue diseñado con el objetivo de gestionar de forma integral los documentos de presentación y PresentationML básicamente contiene la presentación interna de los documentos como paquetes XML comprimidos.

Un documento PPTX generado por Aspose.Slides for C++ y abierto en Microsoft PowerPoint

Visualizando documento PPTX generado por Aspose.Slides for C++ en aplicación Zip
### **PresentationML es abierto, ¿por qué usar Aspose.Slides for C++**
Dado que PresentationML está basado en XML, es perfectamente posible crear aplicaciones para procesar y generar documentos PresentationML usando clases XML sin depender de bibliotecas de clases de terceros como Aspose.Slides for C++. Sin embargo, existen varias ventajas de usar Aspose.Slides for C++ sobre las clases XML al trabajar con documentos PresentationML.

La especificación OOXML tiene varias miles de páginas. Esto significa que, para manejar adecuadamente los documentos PresentationML, tendrás que invertir mucho tiempo y esfuerzo en comprender el formato de dichos documentos. Por otro lado, al usar Aspose.Slides for C++, simplemente utilizas las clases relevantes y sus respectivos métodos/propiedades para realizar operaciones que parecen bastante complejas si se llevan a cabo mediante clases XML.

A continuación se enumeran algunas de las funcionalidades que ni siquiera están disponibles al tratar documentos PresentationML mediante clases XML:

- Exportar documentos PPT a formatos PDF, TIFF, XPS
- Exportar diapositivas en los documentos PPT a formatos SVG
- Renderizar diapositiva a cualquier formato de imagen compatible con el Framework C++
- Copia automática de masters de presentaciones origen mediante la función de clonación
- Aplicar protección a formas

Tomemos como ejemplo un documento PresentationML que contiene una sola diapositiva con un cuadro de texto que incluye el texto “Hello World”. Para leer el texto mediante clases XML, tendrás que escribir un programa que pueda analizar este texto sencillo a partir del siguiente fragmento:
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
Aspose.Slides ahora también admite la conversión de PPT a PPTX.
### **Funciones compatibles en la conversión**
Aspose.Slides for C++ proporciona soporte parcial para convertir presentaciones en formato de archivo PPT a presentaciones en formato PPTX. Como la compatibilidad con la característica de conversión de presentaciones acaba de introducirse en Aspose.Slides for C++, en este momento tiene una capacidad limitada y solo funciona para formas simples de presentaciones. La principal ventaja que la biblioteca API de Aspose.Slides for C++ ofrece para convertir presentaciones PPT al formato PPTX es la facilidad de uso de la API para lograr el objetivo deseado. Por favor, diríjase a this[link]() para la sección de fragmentos de código para obtener más detalles. La siguiente sección ilustra claramente qué funciones son compatibles y cuáles no al convertir presentaciones en formato PPT a presentaciones en formato PPTX.
### **Funciones compatibles**
Las siguientes funciones son compatibles durante la conversión:

- Conversión de la estructura de masters, diseños y diapositivas
- Conversión de la estructura de masters, diseños y diapositivas
- Conversión de gráficos
- Agrupar formas
- Conversión de Autoformas, incluidas Rectángulos y Elipses. Sin embargo, es posible que las Autoformas tengan valores de ajustes incorrectos
- Formas con geometría personalizada. A veces pueden no convertirse
- Estilo de relleno de Texturas e Imágenes para Autoformas. A veces pueden no convertirse
- Conversión de Marcadores de posición
- Conversión de texto en marcos de texto y contenedores de texto. Sin embargo, viñetas, alineación y tabulaciones no están implementadas completamente
### **Funciones no compatibles**
Las siguientes funciones no son compatibles durante la conversión:

- Diapositiva con notas, ya que la lectura de notas no está implementada en PPTX. En caso de que PPT la contenga, aún no puede guardarse como PPTX* Conversión de Líneas y Polilíneas
- Formatos de línea y relleno
- Estilos de relleno degradado
- Marcos OLE, Tablas, Vídeo y Marcos de audio, etc.
- Animación y otras propiedades de la presentación se omiten
  Nuevas o faltantes funciones se añadirán posteriormente en próximas versiones de Aspose.Slides for C++.

Presentación PPT origen

Presentación PPTX convertida
## **Formato de documento portátil (PDF)**
### **Acerca del PDF**
El [Formato de Documento Portátil](https://en.wikipedia.org/wiki/PDF) es un formato de archivo creado por Adobe System para el intercambio de documentos entre diferentes organizaciones. El propósito de este formato era permitir que el contenido de los documentos pudiera representarse de manera que su apariencia visual no dependiera de la plataforma en la que se visualiza.
### **PDF en Aspose.Slides for C++**
Cualquier documento de presentación que pueda cargarse en Aspose.Slides for C++ puede convertirse a documento PDF que puede ajustarse a [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) o [PDF /A-1b](https://en.wikipedia.org/wiki/PDF/A) según tu elección. Aspose.Slides for C++ exporta los documentos de presentación a PDF de tal forma que, la mayor parte del tiempo, el documento PDF exportado se asemeja mucho al documento de presentación original. La solución Aspose admite las siguientes funciones de los documentos de presentación al convertir a documentos PDF:

- Imágenes, Cuadros de texto y otras Formas
- Texto y Formato
- Párrafos y Formato
- Hipervínculos
- Encabezados y pies de página
- Viñetas
- Tablas

Puedes exportar los documentos de presentación a PDF directamente usando solo el componente Aspose.Slides for C++. Es decir, no necesitas ningún otro tercero ni el componente Aspose.Pdf para este fin. Además, puedes personalizar la exportación de presentación a PDF con diferentes opciones como se explica en [este tema](/slides/es/cpp/convert-powerpoint-to-pdf/).

Un documento de presentación convertido a documento PDF mediante Aspose.Slides for C++
## **Especificación del analizador XML (XPS)**
### **Acerca del XPS**
La [Especificación del Analizador XML](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) es un lenguaje de descripción de página y un formato de documento fijo desarrollado originalmente por Microsoft. Al igual que PDF, XPS es un formato de documento de diseño fijo diseñado para preservar la fidelidad del documento y proporcionar una apariencia independiente del dispositivo.
### **XPS en Aspose.Slides for C++**
Cualquier documento de presentación que pueda cargarse con Aspose.Slides for C++ puede convertirse al formato XPS. Aspose.Slides for C++ utiliza el motor de disposición y renderizado de alta fidelidad para producir salida en formato de documento XPS de diseño fijo. Vale la pena mencionar que Aspose.Slides for C++ genera XPS directamente sin depender de las clases Windows Presentation Foundation (WPF) que se empaquetan con el Framework C++ 3.5, lo que permite a Aspose.Slides for C++ producir documentos XPS en máquinas con versiones del Framework C++ anteriores a la 3.5. Puedes aprender sobre la exportación de documentos de presentación a documentos XPS mediante Aspose.Slides for C++ en [este tema](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/).

Un documento de presentación convertido a documento XPS mediante Aspose.Slides for C++