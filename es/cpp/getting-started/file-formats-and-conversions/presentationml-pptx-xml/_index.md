---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /cpp/presentationml-pptx-xml/
---

## **Acerca de PresentationML**
PresentationML es un nombre para una familia de formatos basados en XML para documentos de presentación. Office OpenXML (OOXML) es el formato basado en XML introducido en las aplicaciones de Microsoft Office 2007. Office OpenXML es un formato contenedor para varios lenguajes de marcado especializados basados en XML. PresentationML es el lenguaje de marcado utilizado por Microsoft Office PowerPoint 2007 para almacenar sus documentos.
## **PresentationML en Aspose.Slides para C++**
Los documentos PresentaionML de OOXML vienen como archivos PPTX que son paquetes XML comprimidos que siguen las especificaciones de [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides para C++ admite extensamente la creación, lectura, manipulación y escritura de documentos PresentationML. Además, Aspose.Slides para C++ es capaz de exportar documentos PresentationML a diferentes formatos de documentos ampliamente utilizados como PDF, TIFF y XPS. Esto es posible porque Aspose.Slides para C++ fue diseñado con el objetivo de manejar integralmente documentos de presentación y PresentationML en esencia mantiene la presentación interna de documentos como un paquete XML comprimido.

## **PresentationML es Abierto, ¿Por Qué Usar Aspose.Slides para C++?**
Dado que PresentationML es basado en XML, es bastante posible construir aplicaciones para procesar y generar documentos PresentationML utilizando clases XML sin depender de bibliotecas de clases de terceros como Aspose.Slides para C++. Sin embargo, hay varias ventajas de usar Aspose.Slides para C++ sobre las clases XML al trabajar con documentos PresentationML.

La especificación de OOXML es demasiado larga, con varios miles de páginas. Esto significa que, para manejar adecuadamente los documentos PresentationML, tendrás que gastar mucho tiempo y esfuerzo para comprender el formato de tales documentos. Por otro lado, al usar Aspose.Slides para C++, simplemente tienes que utilizar las clases relevantes y sus respectivos métodos / propiedades para realizar operaciones que parecen bastante complejas si se realizan a través de clases XML.

Las siguientes son algunas de las características que incluso están ausentes al tratar documentos PresentationML a través de clases XML:

- Exportar documentos PPT a formatos PDF, TIFF, XPS
- Exportar diapositivas en los documentos PPT a formatos SVG
- Renderizar diapositivas a cualquier formato de imagen compatible con C++ Framework
- Copia automática de maquetas desde presentaciones fuente utilizando la función de clonación
- Aplicar protección en formas

Tomemos un ejemplo de un documento PresentationML que tiene una única diapositiva con un cuadro de texto que contiene el texto "Hola Mundo". Para leer el texto a través de clases XML, tendrás que escribir un programa que pueda analizar este texto simple del siguiente fragmento:
## **Ejemplo**


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

          <p:nvSpPr><p:cNvPr id="4" name="Cuadro de Texto 3"/>

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

                <a:t>Hola Mundo

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