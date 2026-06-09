---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /pt/cpp/presentationml-pptx-xml/
---
## **Sobre PresentationML**
PresentationML é um nome para uma família de formatos baseados em XML para documentos de apresentação. Office OpenXML (OOXML) é o formato baseado em XML introduzido nas aplicações Microsoft Office 2007. Office OpenXML é um formato contêiner para várias linguagens de marcação especializadas baseadas em XML. PresentationML é a linguagem de marcação usada pelo Microsoft Office PowerPoint 2007 para armazenar seus documentos. 
## **PresentationML no Aspose.Slides for C++**
Os documentos OOXML PresentationML são entregues como arquivos PPTX que são pacotes XML compactados seguindo as especificações [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). O Aspose.Slides for C++ oferece suporte extensivo à criação, leitura, manipulação e gravação de documentos PresentationML. Além disso, o Aspose.Slides for C++ pode exportar documentos PresentationML para diferentes formatos de documento amplamente utilizados, como PDF, TIFF e XPS. Isso é possível porque o Aspose.Slides for C++ foi projetado com o objetivo de tratar de forma abrangente documentos de apresentação, e o PresentationML basicamente contém a apresentação interna dos documentos como um pacote XML compactado. 

## **PresentationML é aberto, por que usar Aspose.Slides for C++**
Como o PresentationML é baseado em XML, é perfeitamente possível criar aplicações para processar e gerar documentos PresentationML usando classes XML sem depender de bibliotecas de classes de terceiros, como o Aspose.Slides for C++. No entanto, há diversas vantagens em usar o Aspose.Slides for C++ em vez das classes XML ao trabalhar com documentos PresentationML. 

A especificação OOXML é extensa, com várias milhares de páginas. Isso significa que, para lidar adequadamente com os documentos PresentationML, você precisará dedicar muito tempo e esforço para entender o formato desses documentos. Por outro lado, ao usar o Aspose.Slides for C++, basta utilizar as classes relevantes e seus respectivos métodos / propriedades para realizar operações que parecem bastante complexas se feitas via classes XML. 

A seguir, algumas das funcionalidades que nem estão disponíveis ao lidar com documentos PresentationML por meio de classes XML: 

- Exportar documentos PPT para os formatos PDF, TIFF, XPS
- Exportar slides nos documentos PPT para formatos SVG
- Renderizar slide para qualquer formato de imagem suportado pelo Framework C++
- Copiar automaticamente mestres de apresentações de origem usando o recurso de clonagem
- Aplicar proteção em formas

Vamos tomar um exemplo de um documento PresentationML que contém um único slide com uma caixa de texto contendo o texto “Hello World”. Para ler o texto usando classes XML, você precisará escrever um programa que consiga analisar esse texto simples a partir do fragmento a seguir: 
## **Exemplo**


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