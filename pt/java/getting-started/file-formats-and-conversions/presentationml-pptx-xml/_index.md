---
title: PresentationML (PPTX, XML) (Histórico)
type: docs
weight: 20
url: /pt/java/presentationml-pptx-xml/
keywords:
- PresentationML
- PPTX
- Office Open XML
- histórico
- Java
- Aspose.Slides
description: "Histórico: uma visão geral mais antiga do formato PresentationML (PPTX) no Aspose.Slides for Java, mantida para links existentes. A lista atual de formatos suportados está em Formatos de Arquivo Suportados."
---
{{% alert color="info" title="Note" %}}

Esta é uma página histórica, mantida para links existentes. Não descreve a versão atual do Aspose.Slides for Java. Para os formatos que o Aspose.Slides for Java carrega, importa, salva e renderiza, e a API de cada um, veja [Supported File Formats](/slides/pt/java/supported-file-formats/). Para comparar PPTX com PPT, veja [Understanding the Difference: PPT vs PPTX](/slides/pt/java/ppt-vs-pptx/).

{{% /alert %}}

{{% alert color="info" title="Note" %}}

PresentationML é um nome para uma família de formatos baseados em XML para documentos de apresentação. Office OpenXML (OOXML) é o formato baseado em XML introduzido nas aplicações Microsoft Office 2007. Office OpenXML é um formato contêiner para várias linguagens de marcação baseadas em XML especializadas. PresentationML é a linguagem de marcação usada pelo Microsoft Office PowerPoint 2007 para armazenar documentos.

{{% /alert %}}

## **PresentationML no Aspose.Slides for Java**
Os documentos OOXML PresentationML são fornecidos como arquivos PPTX, pacotes XML compactados que seguem a especificação [OOXML ECMA-376](https://ecma-international.org/publications-and-standards/standards/ecma-376/). O Aspose.Slides for Java oferece amplo suporte à criação, leitura, manipulação e gravação de documentos PresentationML. Além disso, o Aspose.Slides for Java pode exportar documentos PresentationML para um formato de documento amplamente utilizado, como PDF. Isso é possível porque o Aspose.Slides for Java foi projetado com o objetivo de lidar de forma abrangente com documentos de apresentação, e o PresentationML basicamente mantém a apresentação interna dos documentos como um pacote XML compactado.

**Um documento PPTX gerado pelo Aspose.Slides for Java e aberto no Microsoft PowerPoint**

![Um documento PPTX gerado pelo Aspose.Slides for Java e aberto no Microsoft PowerPoint](presentationml-pptx-xml_1.png)


**Visualizando o mesmo documento PPTX gerado pelo Aspose.Slides for Java em um ZIP**

![O mesmo documento PPTX visualizado como um pacote ZIP](presentationml-pptx-xml_2.jpg)


## **PresentationML é aberto, por que usar o Aspose.Slides for Java?**
Como o PresentationML é baseado em XML, é perfeitamente possível criar aplicativos para processar e gerar documentos PresentationML usando classes XML sem depender de uma biblioteca de classes de terceiros como o Aspose.Slides for Java. No entanto, há várias vantagens em usar o Aspose.Slides for Java em vez de classes XML ao trabalhar com documentos PresentationML.

A especificação OOXML tem várias milhares de páginas, portanto, para lidar adequadamente com os documentos PresentationML, você precisa gastar muito tempo e esforço para entender o formato. Por outro lado, com o Aspose.Slides for Java, você simplesmente usa classes e seus métodos e propriedades para executar operações que parecem complexas se realizadas via classes XML.

Alguns dos recursos que o Aspose.Slides oferece nem sequer estão disponíveis quando você trabalha com documentos PresentationML por meio de classes XML:

- Exportar documentos PPT para o formato PDF.
- Renderizar um slide para qualquer formato de imagem suportado pelo Java Framework.
- Copiar automaticamente mestres de uma apresentação de origem usando o recurso de clonagem.
- Aplicar proteção a formas.

Abaixo está um exemplo de um documento PresentationML com um único slide contendo uma caixa de texto com o texto “Hello World”. Para ler o texto usando classes XML, você precisa escrever um programa que possa analisar esse texto simples a partir do fragmento a seguir. O Aspose.Slides faz isso por você.

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