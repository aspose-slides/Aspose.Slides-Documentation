---
title: Por que não Open XML SDK
type: docs
weight: 120
url: /pt/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- comparação
- modelo de objeto de apresentação
- conversão de alta qualidade
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Veja por que Aspose.Slides é uma escolha melhor que o gratuito Open XML SDK: compare recursos, conversão sem automação e amplo suporte para PPT, PPTX e ODP."
---
## **Visão geral**

Este artigo explica quando os desenvolvedores podem escolher o Open XML SDK ou o Aspose.Slides para trabalhar com documentos de apresentação. Ele descreve o Open XML SDK como uma biblioteca para manipular pacotes OOXML e seus elementos XML subjacentes, enquanto o Aspose.Slides é apresentado como uma biblioteca de processamento de apresentações com um modelo de objeto de alto nível e suporte para muitas tarefas relacionadas ao PowerPoint.

O artigo compara ambas as opções por formatos suportados, modelo de programação, recursos de renderização e impressão, suporte a plataformas e casos de uso comuns. Também esclarece que o Open XML SDK pode ser adequado para operações básicas de PPTX ou acesso direto aos elementos OOXML, enquanto o Aspose.Slides é mais apropriado para tarefas complexas de apresentação, como trabalhar com vários formatos do PowerPoint, copiar ou clonar formas, substituir texto, aplicar animações e converter apresentações para PDF, TIFF ou XPS.

## **O que é Open XML SDK?**

De acordo com a [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), o Open XML SDK é definido como: 

O Open XML SDK 2.0 simplifica a tarefa de manipular pacotes Open XML e os elementos do esquema Open XML subjacentes dentro de um pacote. O Open XML SDK 2.0 encapsula muitas tarefas comuns que os desenvolvedores realizam em pacotes Open 
XML, de modo que você pode executar operações complexas com apenas algumas linhas de código.

Os documentos OOXML são essencialmente arquivos XML compactados e o Open XML SDK é uma coleção de classes que permite trabalhar com o conteúdo de documentos OOXML de forma fortemente tipada. Ou seja, em vez de descompactar um arquivo para 
extrair XML, carregar esse XML em uma árvore DOM e trabalhar diretamente com elementos e atributos XML, o Open XML SDK fornece classes para fazer isso.

## **O que é Aspose.Slides?**

O Aspose.Slides é uma biblioteca de classes que permite que sua aplicação execute as seguintes tarefas de processamento de apresentações:

- Programação com um modelo de objeto **Presentation**.
- Conversões de alta qualidade entre todos os formatos de apresentação do PowerPoint suportados, incluindo conversão para PDF, XPS e TIFF.
- Capacidade de gerar miniaturas de slides em formatos conhecidos, como PNG, JPEG e BMP, junto com exportação de slides para SVG.
- Capacidade de criar apresentações do zero ou combinando um ou múltiplos documentos.
- Suporte para adicionar animações, Ole Frames, tabelas, criar e gerenciar gráficos.
- Disponibilidade de controle extensivo para gerenciar a formatação de texto em TextFrames, Parágrafos e Porções.

Para mais detalhes sobre os recursos suportados, visite [Aspose.Slides Features](/slides/pt/java/product-overview/).

## **Comparar Open XML SDK com Aspose.Slides**
{{% alert color="primary" %}} 

A tabela a seguir compara os recursos do Open XML SDK e do Aspose.Slides.

{{% /alert %}} 

|**Recurso ou Categoria de Recurso**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formatos de apresentações suportados|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversão de PPT para PPTX|Não|Sim|
|<p>Programação de alto nível com um Modelo de Objeto de Documento de Apresentação (DOM):</p><p>- Encontrar e substituir texto.</p><p>- Montar slides em apresentações.</p>|Não|Sim|
|Programação detalhada com um modelo de objeto de documento, acesso a elementos individuais e formatação como TextHolders, TextFrames, Paragraphs e Portions.|Sim|Sim|
|Acesso direto e completo de baixo nível aos elementos XML subjacentes e atributos, como identificadores de relacionamento, identificadores de lista de um documento OOXML.|Sim|Não|
|<p>Renderização:</p><p>- Renderizar apresentações para PDF, PDF Notes, XPS, imagens TIFF.</p><p>- Renderizar miniaturas de slides para PNG, JPEG, BMP, SVG e TIFF.</p><p>- Especificar resolução da imagem, qualidade, compressão e outras opções.</p>|Não|Sim |
|Plataformas suportadas|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Conclusão**
{{% alert color="primary" %}} 

O Open XML SDK e o Aspose.Slides não competem diretamente, pois atendem a necessidades e públicos bastante diferentes. O Open XML SDK é uma biblioteca de classes que fornece uma forma tipada para trabalhar com documentos OOXML. O Aspose.Slides é uma biblioteca de processamento de apresentações muito útil que oferece ótimo suporte para quase todos os formatos de arquivos do Microsoft PowerPoint.

Se tudo o que você precisa fazer é uma operação de programação bastante básica em um documento PPTX, então o Open XML SDK pode ser uma escolha adequada. Com o Open XML SDK você ficará bastante confortável realizando tarefas simples, como gerar um documento PPTX simples ou remover comentários, cabeçalhos/rodapés, extrair imagens ou outros. Algumas tarefas podem ser realizadas com o Open XML SDK, mas não podem ser realizadas com o Aspose.Slides. Por exemplo, se você precisar acessar diretamente os elementos XML e atributos de um documento OOXML, então deve usar o Open XML SDK. No entanto, se precisar executar operações complexas em documentos, como algumas das tarefas a seguir, então usar o Aspose.Slides é a melhor opção:

- Suportar formatos antigos do PowerPoint além do PPTX.
- Copiar ou clonar formas dentro de slides de maneira que combine objetos, estilos e outras formatações de forma adequada.
- Substituir texto formatado ou não formatado.
- Aplicar animações e usar conectores com as formas utilizadas.
- Converter um documento para PDF, TIFF ou XPS para que ele apareça exatamente como o Microsoft PowerPoint faria a conversão.
- Desenvolver uma aplicação .NET ou Java tanto em ambientes desktop quanto baseados na web.

{{% /alert %}}