---
title: Diferentes formatos de arquivo e conversões
type: docs
weight: 50
url: /pt/cpp/different-file-formats-and-conversions/
---
## **Microsoft PowerPoint (PPT)**
### **Sobre o PPT**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) é o formato de arquivo de documento de apresentação que pode ser criado, lido, manipulado e gravado por diferentes versões do Microsoft PowerPoint. Este é o formato binário para documentos de apresentação desenvolvido pela Microsoft.
### **PPT no Aspose.Slides for C++**
Aspose.Slides for C++ pode ler arquivos PPT criados pelo software listado abaixo.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

Da mesma forma, arquivos PPT criados pelo Aspose.Slides for C++ podem ser lidos pelo conjunto de softwares acima.
### **Suporte abrangente para PPT**
Aspose.Slides for C++ fornece suporte para quase todos os recursos relacionados ao formato de arquivo de documento PPT. Ele cobre não apenas os recursos básicos/avançados fornecidos por diferentes versões do Microsoft PowerPoint para manipulação de documentos PPT, mas também alguns recursos que nem mesmo o Microsoft PowerPoint suporta. A principal vantagem de usar a biblioteca de API Aspose.Slides for C++ é a facilidade de uso ao lidar com esses recursos.

Além das tarefas básicas relacionadas à criação, leitura e gravação de arquivos de documento PPT, há vários recursos fornecidos pelo Aspose.Slides for C++ como:

- Importar outros formatos de arquivo do MS Office como objetos OLE em documentos PPT.
- Exportar documentos PPT para formatos PDF, TIFF, XPS.
- Exportar slides nos documentos PPT para formatos SVG.
- Renderizar slide para qualquer formato de imagem suportado pelo C++ Framework.
- Definir o tamanho dos slides no documento PPT.
- Gerenciar animações em formas.
- Gerenciar apresentações de slides.
- FormatAR texto nos slides.
- Digitalizar texto dos documentos PPT.
- Manipular tabelas nos slides.
- Cópia automática de masters usando o recurso de clonagem.

Um arquivo PPT gerado pelo Aspose.Slides for C++ e aberto no Microsoft PowerPoint
## **PresentationML (PPTX, XML)**
### **Sobre o PresentationML**
PresentationML é o nome de uma família de formatos baseados em XML para documentos de apresentação. Office OpenXML (OOXML) é o formato baseado em XML introduzido nos aplicativos Microsoft Office 2007. Office OpenXML é um formato contêiner para várias linguagens de marcação baseadas em XML especializadas. PresentationML é a linguagem de marcação usada pelo Microsoft Office PowerPoint 2007 para armazenar seus documentos.
### **PresentationML no Aspose.Slides for C++**
Documentos OOXML PresentationML aparecem como arquivos PPTX que são pacotes XML compactados seguindo as especificações do [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for C++ suporta amplamente a criação, leitura, manipulação e gravação de documentos PresentationML. Além disso, Aspose.Slides for C++ pode exportar documentos PresentationML para diferentes formatos de documento amplamente usados, como PDF, TIFF e XPS. Isso é possível porque o Aspose.Slides for C++ foi projetado com o objetivo de lidar de forma abrangente com documentos de apresentação e o PresentationML basicamente mantém a apresentação interna dos documentos como pacote XML compactado.

Um documento PPTX gerado pelo Aspose.Slides for C++ e aberto no Microsoft PowerPoint

Visualizando documento PPTX gerado pelo Aspose.Slides for C++ em aplicativo Zip
### **PresentationML é aberto, por que usar o Aspose.Slides for C++**
Como o PresentationML é baseado em XML, é perfeitamente possível criar aplicações para processar e gerar documentos PresentationML usando classes XML sem depender de bibliotecas de terceiros, como o Aspose.Slides for C++. No entanto, há várias vantagens em usar o Aspose.Slides for C++ em relação às classes XML ao trabalhar com documentos PresentationML.

A especificação OOXML tem milhares de páginas. Isso significa que, para lidar adequadamente com os documentos PresentationML, você terá que gastar muito tempo e esforço para entender o formato desses documentos. Por outro lado, ao usar o Aspose.Slides for C++, você simplesmente usa as classes relevantes e seus respectivos métodos/propriedades para realizar operações que parecem bastante complexas se feitas via classes XML.

Os seguintes recursos nem estão disponíveis ao lidar com documentos PresentationML através de classes XML:

- Exportar documentos PPT para formatos PDF, TIFF, XPS
- Exportar slides nos documentos PPT para formatos SVG
- Renderizar slide para qualquer formato de imagem suportado pelo C++ Framework
- Cópia automática de masters de apresentações de origem usando recurso de clonagem
- Aplicar proteção em formas

Vamos tomar como exemplo um documento PresentationML contendo um único slide com uma caixa de texto contendo o texto “Hello World”. Para ler o texto via classes XML, você precisará escrever um programa que analise esse texto simples a partir do fragmento a seguir:

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
## **Conversão de PPT para PPTX**
### **Sobre a conversão**
Aspose.Slides agora também oferece suporte à conversão de PPT para PPTX.
### **Recursos suportados na conversão**
Aspose.Slides for C++ fornece suporte parcial para converter apresentações no formato de arquivo PPT para apresentações no formato de arquivo PPTX. Como o suporte ao recurso de conversão mencionado foi recém‑introduzido no Aspose.Slides for C++, no momento ele possui capacidade limitada e funciona apenas para formas simples de apresentações. A principal vantagem que a biblioteca de API Aspose.Slides for C++ oferece para converter apresentações PPT para o formato PPTX é a facilidade de uso da API para alcançar o objetivo desejado. Por favor, vá para este[link]() seção de trechos de código para mais detalhes. A seção a seguir ilustra claramente quais recursos são suportados e quais não são suportados ao converter apresentações no formato PPT para o formato PPTX.
### **Recursos suportados**
Os seguintes recursos são suportados durante a conversão:

- Conversão da estrutura de masters, layouts e slides
- Conversão da estrutura de masters, layouts e slides
- Conversão de gráficos
- Formas agrupadas
- Conversão de Auto‑shapes incluindo Retângulos e Elipses. No entanto, é possível que Auto‑shapes tenham valores de ajustes incorretos
- Formas com geometria personalizada. Às vezes podem não ser convertidas
- Estilo de preenchimento de Texturas e Imagens para Auto‑shapes. Às vezes podem não ser convertidos
- Conversão de Placeholders
- Conversão de texto em quadros de texto e holders de texto. No entanto, marcadores, alinhamento e tabulações não são totalmente implementados
### **Recursos não suportados**
Os seguintes recursos não são suportados durante a conversão:

- Slide com notas, pois a leitura de Notas não está implementada no PPTX. Caso o PPT as possua, ainda não podem ser salvas como PPTX* Conversão de Linhas e Polilinhas
- Formatos de linha e preenchimento
- Estilos de preenchimento degradê
- Frames OLE, Tabelas, Frames de Vídeo e Áudio etc.
- Animações e outras propriedades de slideshow são ignoradas
  Novos ou ausentes recursos serão adicionados posteriormente nas próximas versões do Aspose.Slides for C++.

Apresentação PPT de origem

Apresentação PPTX convertida
## **Portable Document Format (PDF)**
### **Sobre o PDF**
O [Portable Document Format](https://en.wikipedia.org/wiki/PDF) é um formato de arquivo criado pela Adobe Systems para troca de documentos entre diferentes organizações. O objetivo desse formato era possibilitar que o conteúdo dos documentos fosse representado de modo que sua aparência visual não dependesse da plataforma em que fosse visualizado.
### **PDF no Aspose.Slides for C++**
Qualquer documento de apresentação que possa ser carregado no Aspose.Slides for C++ pode ser convertido para documento PDF, que pode estar em conformidade com [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) ou [PDF /A-1b](https://en.wikipedia.org/wiki/PDF/A), conforme sua escolha. Aspose.Slides for C++ exporta os documentos de apresentação para PDF de forma que, na maioria das vezes, o documento PDF exportado se assemelha bastante ao documento de apresentação original. A solução Aspose suporta os seguintes recursos dos documentos de apresentação ao converter para documentos PDF:

- Imagens, Caixas de Texto e outras Formas
- Texto e Formatação
- Parágrafos e Formatação
- Hiperlinks
- Cabeçalhos e Rodapés
- Marcadores
- Tabelas

Você pode exportar os documentos de apresentação diretamente para documentos PDF usando apenas o componente Aspose.Slides for C++. Ou seja, não é necessário nenhum outro componente de terceiros ou o Aspose.Pdf para esse fim. Além disso, você pode personalizar a exportação da apresentação para PDF com diferentes opções, conforme explicado neste[tópico](/slides/pt/cpp/convert-powerpoint-to-pdf/).

Um documento de apresentação convertido para documento PDF através do Aspose.Slides for C++
## **XML Parser Specification (XPS)**
### **Sobre o XPS**
A [XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) é uma linguagem de descrição de página e um formato de documento fixo originalmente desenvolvido pela Microsoft. Assim como o PDF, o XPS é um formato de documento de layout fixo projetado para preservar a fidelidade do documento e proporcionar aparência independente de dispositivo.
### **XPS no Aspose.Slides for C++**
Qualquer documento de apresentação que possa ser carregado pelo Aspose.Slides for C++ pode ser convertido para formato XPS. Aspose.Slides for C++ usa o motor de layout de página e renderização de alta fidelidade para produzir saída no formato de documento XPS de layout fixo. Vale mencionar que o Aspose.Slides for C++ gera XPS diretamente, sem depender das classes do Windows Presentation Foundation (WPF) que são empacotadas com o C++ Framework 3.5, permitindo assim que o Aspose.Slides for C++ produza documentos XPS em máquinas que executam versões do C++ Framework anteriores à 3.5. Você pode aprender sobre a exportação dos documentos de apresentação para documentos XPS através do Aspose.Slides for C++ neste[tópico](https://docs.aspose.com/slides/pt/cpp/convert-powerpoint-to-xps/).

Um documento de apresentação convertido para documento XPS através do Aspose.Slides for C++