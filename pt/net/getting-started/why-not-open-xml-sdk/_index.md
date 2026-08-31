---
title: Por que não Open XML SDK
type: docs
weight: 50
url: /pt/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- comparação
- modelo de objeto de apresentação
- conversão de alta qualidade
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Veja por que Aspose.Slides é uma escolha melhor que o Open XML SDK gratuito: compare recursos, conversão sem automação e amplo suporte para PPT, PPTX e ODP."
---
## **Visão geral**

Este artigo explica quando os desenvolvedores podem escolher o Open XML SDK ou o Aspose.Slides para trabalhar com documentos de apresentação. Ele descreve o Open XML SDK como uma biblioteca para manipular pacotes OOXML e seus elementos XML subjacentes, enquanto o Aspose.Slides é apresentado como uma biblioteca de processamento de apresentações com um modelo de objetos de alto nível e suporte para muitas tarefas relacionadas ao PowerPoint.

O artigo compara ambas as opções por formatos suportados, modelo de programação, renderização, suporte de plataforma e casos de uso comuns. Também esclarece que o Open XML SDK pode ser adequado para operações básicas de PPTX ou acesso direto aos elementos OOXML, enquanto o Aspose.Slides é mais apropriado para tarefas complexas de apresentação, como trabalhar com vários formatos do PowerPoint, copiar ou clonar formas, substituir texto, aplicar animações e converter apresentações para PDF, TIFF ou XPS.

## **O que é Open XML SDK?**
Às vezes, recebemos esta pergunta: *Por que devemos usar produtos Aspose em vez do Open XML SDK gratuito?* 

Achamos fácil responder a essa pergunta em termos de recursos e funcionalidades. 

De acordo com a [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), o Open XML SDK é definido da seguinte forma: 

> "O Open XML SDK 2.0 simplifica a tarefa de manipular pacotes Open XML e os elementos de esquema Open XML subjacentes dentro de um pacote. O Open XML SDK 2.0 encapsula muitas tarefas comuns que os desenvolvedores realizam em pacotes Open XML, de modo que você pode executar operações complexas com apenas algumas linhas de código. Documentos OOXML são essencialmente arquivos XML compactados e o Open XML SDK é uma coleção de classes que permite trabalhar com o conteúdo de documentos OOXML de forma fortemente tipada. Isso significa que, em vez de descompactar um arquivo para extrair XML, carregar esse XML em uma árvore DOM e trabalhar diretamente com elementos e atributos XML, o Open XML SDK fornece classes para fazer isso."

## **O que é Aspose.Slides?**
Aspose.Slides é uma biblioteca de classes que permite que aplicações executem estas tarefas de processamento de apresentações: 

- Programação com um modelo de objeto de apresentação.
- Conversões de alta qualidade envolvendo todos os formatos de apresentação PowerPoint suportados, incluindo conversão para PDF, XPS e TIFF.
- Geração de miniaturas de slides em formatos bem conhecidos como PNG, JPEG e BMP, além da exportação de slides para SVG.
- Criação de apresentações do zero ou combinando elementos de um ou vários documentos.
- Adição de animações, quadros OLE, tabelas, criação e gerenciamento de gráficos.
- Controle (controle extensivo) e gerenciamento da formatação de texto em níveis de TextFrames, Parágrafos e Porções. 

  Para mais detalhes sobre os recursos disponíveis, consulte a página [Aspose.Slides Features](/slides/pt/net/product-overview/).

## **Comparar Open XML SDK com Aspose.Slides**
Esta tabela compara as capacidades e recursos do Open XML SDK com o Aspose.Slides.

|**Recurso ou Categoria de Recurso**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formatos de apresentação suportados|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversão de PPT para PPTX |Não|Sim|
|<p>Programação de alto nível com um Modelo de Objeto de Documento de Apresentação (DOM): </p><p>- Encontrar e substituir textos.</p><p>- Montar slides em apresentações.</p>|Não|Sim|
|Programação detalhada com um modelo de objeto de documento; acesso a elementos individuais e formatação como TextHolders, TextFrames, Paragraphs e Portions.|Sim|Sim|
|Acesso direto e completo de baixo nível aos elementos XML subjacentes e atributos, como identificadores de relacionamento, identificadores de lista de um documento OOXML.|Sim|Não|
|<p>Renderização de Apresentação:</p><p>- Renderizar apresentações para PDF, PDF Notes, XPS, imagens TIFF.</p><p>- Renderizar miniaturas de slides para PNG, JPEG, BMP, SVG e TIFF.</p><p>- Especificar resolução de imagem, qualidade, compressão e outras opções.</p>|Não|Sim|
|Plataformas suportadas|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Conclusão**
Open XML SDK e Aspose.Slides não competem diretamente porque atendem a necessidades consideravelmente diferentes e visam públicos diferentes. 

{{% alert color="info" %}} 

Open XML SDK é uma biblioteca de classes que fornece uma forma tipada para trabalhar com documentos OOXML, enquanto Aspose.Slides é uma biblioteca de processamento de apresentações incrivelmente útil que oferece excelente suporte para quase todos os formatos de arquivo Microsoft PowerPoint. 

{{% /alert %}} 

Se seu fluxo de trabalho consiste em uma operação de programação básica em um documento PPTX, então o Open XML SDK pode ser uma boa escolha. Com o Open XML SDK, você deve se sentir confortável ao executar tarefas simples como gerar um documento PPTX simples ou remover comentários, cabeçalhos/rodapés, extrair imagens ou outros. Certas tarefas podem ser realizadas com o Open XML SDK mas não podem ser realizadas com o Aspose.Slides. Por exemplo, se precisar acessar diretamente os elementos XML e atributos de um documento OOXML, então você deve usar o Open XML SDK. 

Se precisar executar tarefas complexas em documentos—como as tarefas listadas abaixo—então o Aspose.Slides é sua melhor opção. 

- Operações envolvendo formatos antigos do PowerPoint (e PPTX também).
- Copiar ou clonar formas dentro de slides de maneira que combine objetos, estilos e outros elementos de formatação de forma apropriada.
- Substituir texto formatado ou não formatado.
- Aplicar animações e usar conectores com formas.
- Converter um documento para PDF, TIFF ou XPS de modo que pareça que o Microsoft PowerPoint fez a conversão.
- Desenvolver uma aplicação .NET ou Java em ambientes desktop e baseados na web.