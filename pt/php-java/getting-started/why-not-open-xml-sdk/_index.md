---
title: Por que não Open XML SDK
type: docs
weight: 120
url: /pt/php-java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- comparando
- modelo de objeto de apresentação
- conversão de alta qualidade
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Veja por que Aspose.Slides é uma escolha melhor do que o gratuito Open XML SDK: compare recursos, conversão sem automação e amplo suporte para PPT, PPTX e ODP."
---
## **Visão geral**

Este artigo explica quando os desenvolvedores podem escolher o Open XML SDK ou o Aspose.Slides para trabalhar com documentos de apresentação. Ele descreve o Open XML SDK como uma biblioteca para manipular pacotes OOXML e seus elementos XML subjacentes, enquanto o Aspose.Slides é apresentado como uma biblioteca de processamento de apresentações com um modelo de objetos de alto nível e suporte a muitas tarefas relacionadas ao PowerPoint.

O artigo compara ambas as opções por formatos suportados, modelo de programação, capacidades de renderização e impressão, suporte a plataformas e casos de uso comuns. Também esclarece que o Open XML SDK pode ser adequado para operações básicas em PPTX ou acesso direto aos elementos OOXML, enquanto o Aspose.Slides é mais apropriado para tarefas complexas de apresentação, como trabalhar com múltiplos formatos PowerPoint, copiar ou clonar formas, substituir texto, aplicar animações e converter apresentações para PDF, TIFF ou XPS.

## **O que é o Open XML SDK?**
De acordo com a [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), o Open XML SDK é definido como:

O Open XML SDK 2.0 simplifica a tarefa de manipular pacotes Open XML e os elementos do esquema Open XML subjacentes dentro de um pacote. O Open XML SDK 2.0 encapsula muitas tarefas comuns que os desenvolvedores realizam em pacotes Open XML, de modo que você pode executar operações complexas com apenas algumas linhas de código.

Documentos OOXML são essencialmente arquivos XML compactados e o Open XML SDK é uma coleção de classes que permite trabalhar com o conteúdo de documentos OOXML de forma fortemente tipada. Em vez de descompactar um arquivo para extrair XML, carregar esse XML em uma árvore DOM e trabalhar diretamente com elementos e atributos XML, o Open XML SDK fornece classes para fazer isso.

## **O que é o Aspose.Slides?**
Aspose.Slides é uma biblioteca de classes que permite que sua aplicação realize as seguintes tarefas de processamento de apresentações:

- Programação com um modelo de objeto **Presentation**.
- Conversões de alta qualidade entre todos os formatos populares de apresentação PowerPoint suportados, incluindo conversão para PDF, XPS e TIFF.
- Capacidade de gerar miniaturas de slides em formatos bem conhecidos como PNG, JPEG e BMP, além de exportar slides para SVG.
- Capacidade de criar apresentações do zero ou combinando um ou múltiplos documentos.
- Suporte para adicionar animações, Ole Frames, Tabelas, criar e gerenciar gráficos.
- Disponibilidade de controle extensivo para gerenciar a formatação de texto em níveis de TextFrames, Parágrafos e Porções.

Para mais detalhes sobre os recursos suportados, visite [Aspose.Slides Features](/slides/pt/php-java/product-overview/).

## **Comparar Open XML SDK com Aspose.Slides**
{{% alert color="primary" %}} 

A tabela a seguir compara os recursos do Open XML SDK e do Aspose.Slides.

{{% /alert %}} 

|**Recurso ou Categoria de Recurso**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formatos de Apresentação Compatíveis|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversão de PPT para PPTX|Não|Sim|
|<p>Programação de alto nível com um Presentation Document Object Model (DOM):</p><p>- Localizar e substituir texto.</p><p>- Montar slides em apresentações.</p>|Não|Sim|
|Programação detalhada com um modelo de objeto de documento, acesso a elementos individuais e formatação como TextHolders, TextFrames, Parágrafos e Porções.|Sim|Sim|
|Acesso direto e completo de baixo nível aos elementos e atributos XML subjacentes, como identificadores de relacionamento, identificadores de lista de um documento OOXML.|Sim|Não|
|<p>Renderização:</p><p>- Renderizar apresentações para PDF, PDF Notes, XPS, imagens TIFF.</p><p>- Renderizar miniaturas de slides para PNG, JPEG, BMP, SVG e TIFF.</p><p>- Especificar resolução da imagem, qualidade, compressão e outras opções.</p>|Não|Sim|
|Plataformas suportadas|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Conclusão**
{{% alert color="primary" %}} 

Open XML SDK e Aspose.Slides não competem diretamente porque atendem a necessidades e públicos bastante diferentes. O Open XML SDK é uma biblioteca de classes que fornece uma forma fortemente tipada de trabalhar com documentos OOXML. O Aspose.Slides é uma biblioteca de processamento de apresentações muito útil que oferece grande suporte para quase todos os formatos de arquivo Microsoft PowerPoint.

Se tudo o que você precisa fazer é uma operação de programação bastante básica em um documento PPTX, então o Open XML SDK pode ser uma escolha adequada. Com o Open XML SDK você ficará confortável realizando tarefas simples, como gerar um documento PPTX simples ou remover comentários, cabeçalhos/rodapés, extrair imagens ou outras. Algumas tarefas podem ser alcançadas com o Open XML SDK, mas não podem ser realizadas com o Aspose.Slides. Por exemplo, se você precisar acessar diretamente os elementos e atributos XML de um documento OOXML, então deve usar o Open XML SDK. No entanto, se precisar executar operações complexas em documentos, como algumas das tarefas a seguir, usar o Aspose.Slides é a melhor opção:

- Suporte a formatos PowerPoint mais antigos além do PPTX.
- Copiar ou clonar formas dentro de slides de maneira que combine objetos, estilos e outras formatações de forma apropriada.
- Substituir texto formatado ou não formatado.
- Aplicar animações e usar conectores com formas utilizadas.
- Converter um documento para PDF, TIFF ou XPS de modo que ele apareça exatamente como o Microsoft PowerPoint converteria.
- Desenvolver uma aplicação .NET ou Java em ambientes desktop e web.

{{% /alert %}}