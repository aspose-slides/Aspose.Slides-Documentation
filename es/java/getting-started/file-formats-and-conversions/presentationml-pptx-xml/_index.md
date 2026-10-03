---
title: PresentationML (PPTX, XML) (Histórica)
type: docs
weight: 20
url: /es/java/presentationml-pptx-xml/
keywords:
- PresentationML
- PPTX
- Office Open XML
- histórica
- Java
- Aspose.Slides
description: "Histórica: una visión general antigua del formato PresentationML (PPTX) en Aspose.Slides for Java, conservada para enlaces existentes. La lista actual de formatos admitidos está en Formatos de Archivo Admitidos."
---
{{% alert color="info" title="Note" %}}

Esta es una página histórica, conservada para enlaces existentes. No describe la versión actual de Aspose.Slides for Java. Para los formatos que Aspose.Slides for Java carga, importa, guarda y renderiza, y la API de cada uno, consulte [Formatos de Archivo Admitidos](/slides/es/java/supported-file-formats/). Para comparar PPTX con PPT, consulte [Entendiendo la Diferencia: PPT vs PPTX](/slides/es/java/ppt-vs-pptx/).

{{% /alert %}}

{{% alert color="info" title="Note" %}}

PresentationML es un nombre para una familia de formatos basados en XML para documentos de presentación. Office OpenXML (OOXML) es el formato basado en XML introducido en las aplicaciones de Microsoft Office 2007. Office OpenXML es un formato contenedor para varios lenguajes de marcado basados en XML especializados. PresentationML es el lenguaje de marcado utilizado por Microsoft Office PowerPoint 2007 para almacenar documentos.

{{% /alert %}}

## **PresentationML en Aspose.Slides for Java**
Los documentos OOXML PresentationML se presentan como archivos PPTX, paquetes XML comprimidos que siguen la especificación [OOXML ECMA-376](https://ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for Java soporta de forma exhaustiva la creación, lectura, manipulación y escritura de documentos PresentationML. Además, Aspose.Slides for Java es capaz de exportar documentos PresentationML a un formato de documento ampliamente utilizado como PDF. Esto es posible porque Aspose.Slides for Java fue diseñado con el objetivo de manejar de forma integral los documentos de presentación y PresentationML contiene básicamente la presentación interna de los documentos como un paquete XML comprimido.

**Un documento PPTX generado por Aspose.Slides for Java y abierto en Microsoft PowerPoint**

![Un documento PPTX generado por Aspose.Slides for Java y abierto en Microsoft PowerPoint](presentationml-pptx-xml_1.png)

**Ver el mismo documento PPTX generado por Aspose.Slides for Java en un ZIP**

![Ver el mismo documento PPTX generado por Aspose.Slides for Java en un paquete ZIP](presentationml-pptx-xml_2.jpg)

## **PresentationML es abierto, ¿Por qué usar Aspose.Slides for Java?**
Dado que PresentationML se basa en XML, es bastante posible crear aplicaciones para procesar y generar documentos PresentationML utilizando clases XML sin depender de una biblioteca de clases de terceros como Aspose.Slides for Java. Sin embargo, hay varias ventajas de usar Aspose.Slides for Java sobre las clases XML al trabajar con documentos PresentationML.

La especificación OOXML tiene varios miles de páginas, por lo que para manejar adecuadamente los documentos PresentationML, debe dedicar mucho tiempo y esfuerzo a comprender el formato. Por otro lado, con Aspose.Slides for Java, simplemente usa clases y sus métodos y propiedades para realizar operaciones que parecerían complejas si se realizan mediante clases XML.

Algunas de las funciones que Aspose.Slides ofrece ni siquiera están disponibles cuando se trabaja con documentos PresentationML a través de clases XML:

- Exportar documentos PPT al formato PDF.
- Renderizar una diapositiva a cualquier formato de imagen soportado por el Framework Java.
- Copiar automáticamente maestros de una presentación origen utilizando la función de clonación.
- Aplicar protección a las formas.

A continuación se muestra un ejemplo de un documento PresentationML con una sola diapositiva que contiene un cuadro de texto con el texto “Hello World”. Para leer el texto usando clases XML, debe escribir un programa que pueda analizar este texto sencillo del siguiente fragmento. Aspose.Slides hace eso por usted.

**XML**

``` xml
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