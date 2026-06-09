---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /pt/php-java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 

PresentationML é o nome de uma família de formatos baseados em XML para documentos de apresentação. Office OpenXML (OOXML) é o formato baseado em XML introduzido nas aplicações Microsoft Office 2007. Office OpenXML é um formato contêiner para várias linguagens de marcação especializadas baseadas em XML. PresentationML é a linguagem de marcação usada pelo Microsoft Office PowerPoint 2007 para armazenar documentos.

{{% /alert %}} 

## **PresentationML em Aspose.Slides para PHP via Java**
Os documentos OOXML PresentationML são arquivos PPTX, pacotes XML compactados que seguem a especificação [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides para PHP via Java oferece suporte extensivo à criação, leitura, manipulação e gravação de documentos PresentationML. Além disso, Aspose.Slides para PHP via Java pode exportar documentos PresentationML para um formato de documento amplamente usado como PDF. Isso é possível porque o Aspose.Slides para PHP via Java foi projetado com o objetivo de lidar de forma abrangente com documentos de apresentação, e o PresentationML basicamente mantém a apresentação interna dos documentos como um pacote XML compactado.

**Um documento PPTX gerado pelo Aspose.Slides para PHP via Java e aberto no Microsoft PowerPoint**

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Visualizando o mesmo documento PPTX gerado pelo Aspose.Slides para PHP via Java em um ZIP**

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML é aberto, por que usar Aspose.Slides para PHP via Java?**
Como o PresentationML é baseado em XML, é perfeitamente possível criar aplicativos para processar e gerar documentos PresentationML usando classes XML sem depender de uma biblioteca de classes de terceiros como o Aspose.Slides para PHP via Java. No entanto, existem várias vantagens em usar o Aspose.Slides para PHP via Java em vez de classes XML ao trabalhar com documentos PresentationML.

A especificação OOXML possui várias milhares de páginas, portanto, para lidar adequadamente com os documentos PresentationML, você precisaria gastar muito tempo e esforço para compreender o formato. Por outro lado, com o Aspose.Slides para PHP via Java, você simplesmente usa classes e seus métodos e propriedades para executar operações que parecem complexas se realizadas via classes XML.

Alguns dos recursos que o Aspose.Slides oferece nem mesmo estão disponíveis quando se trabalha com documentos PresentationML por meio de classes XML:

- Exportar documentos PPT para formato PDF.
- Renderizar um slide para qualquer formato de imagem suportado pelo Java Framework.
- Copiar automaticamente mestres de apresentações de origem usando o recurso de clonagem.
- Aplicar proteção a formas.

Abaixo está um exemplo de um documento PresentationML com um único slide contendo uma caixa de texto com o texto “Hello World”. Para ler o texto usando classes XML, você teria que escrever um programa que analisasse esse texto simples a partir do fragmento a seguir. O Aspose.Slides faz isso por você.

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
```php

```