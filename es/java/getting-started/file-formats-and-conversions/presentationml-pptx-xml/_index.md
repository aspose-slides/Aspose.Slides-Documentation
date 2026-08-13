---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /es/java/presentationml-pptx-xml/
---
{{% alert color="info" %}} 

PresentationML es un nombre para una familia de formatos basados en XML para documentos de presentación. Office OpenXML (OOXML) es el formato basado en XML introducido en las aplicaciones de Microsoft Office 2007. Office OpenXML es un formato contenedor para varios lenguajes de marcado especializados basados en XML. PresentationML es el lenguaje de marcado utilizado por Microsoft Office PowerPoint 2007 para almacenar documentos.

{{% /alert %}} 

## **PresentationML en Aspose.Slides for Java**
Los documentos OOXML PresentationML se presentan como archivos PPTX, paquetes XML comprimidos que siguen la especificación [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for Java soporta de forma exhaustiva la creación, lectura, manipulación y escritura de documentos PresentationML. Además, Aspose.Slides for Java es capaz de exportar documentos PresentationML a un formato de documento ampliamente usado como PDF. Esto es posible porque Aspose.Slides for Java fue diseñado con el objetivo de gestionar integralmente los documentos de presentación y PresentationML básicamente mantiene la presentación interna de los documentos como un paquete XML comprimido.

**Un documento PPTX generado por Aspose.Slides for Java y abierto en Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Visualizando el mismo documento PPTX generado por Aspose.Slides for Java en un ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML es abierto, ¿por qué usar Aspose.Slides for Java?**
Dado que PresentationML está basado en XML, es perfectamente posible crear aplicaciones para procesar y generar documentos PresentationML usando clases XML sin depender de una biblioteca de clases de terceros como Aspose.Slides for Java. Sin embargo, existen varias ventajas de usar Aspose.Slides for Java sobre las clases XML al trabajar con documentos PresentationML.

La especificación OOXML tiene varios miles de páginas, por lo que para manejar adecuadamente los documentos PresentationML tienes que invertir mucho tiempo y esfuerzo en comprender el formato. Por otro lado, con Aspose.Slides for Java, simplemente utilizas clases y sus métodos y propiedades para realizar operaciones que parecen complejas si se hacen mediante clases XML.

Algunas de las características que Aspose.Slides ofrece ni siquiera están disponibles cuando trabajas con documentos PresentationML a través de clases XML:

- Exportar documentos PPT a formato PDF.
- Renderizar una diapositiva a cualquier formato de imagen compatible con el Framework de Java.
- Copiar automáticamente masters de presentaciones origen mediante la función de clonación.
- Aplicar protección a formas.

A continuación se muestra un ejemplo de un documento PresentationML con una única diapositiva que contiene un cuadro de texto con el texto “Hello World”. Para leer el texto usando clases XML, tendrías que escribir un programa que pueda analizar este texto sencillo a partir del siguiente fragmento. Aspose.Slides lo hace por ti.

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