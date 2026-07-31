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
description: "Veja por que Aspose.Slides é uma escolha melhor que o gratuito Open XML SDK: compare recursos, conversão sem automação e amplo suporte para PPT, PPTX e ODP."
---
## **Visão geral**

Este artigo explica quando os desenvolvedores podem escolher o Open XML SDK ou o Aspose.Slides para trabalhar com documentos de apresentação. Ele descreve o Open XML SDK como uma biblioteca para manipular pacotes OOXML e seus elementos XML subjacentes, enquanto o Aspose.Slides é apresentado como uma biblioteca de processamento de apresentações com um modelo de objetos de alto nível e suporte a muitas tarefas relacionadas ao PowerPoint.

O artigo compara ambas as opções por formatos suportados, modelo de programação, capacidades de renderização e impressão, suporte de plataforma e casos de uso comuns. Também esclarece que o Open XML SDK pode ser adequado para operações básicas de PPTX ou acesso direto a elementos OOXML, enquanto o Aspose.Slides é mais apropriado para tarefas complexas de apresentação, como trabalhar com múltiplos formatos PowerPoint, copiar ou clonar formas, substituir texto, aplicar animações e converter apresentações para PDF, TIFF ou XPS.

## **O que é Open XML SDK?**
Às vezes, recebemos esta pergunta: *Por que devemos usar produtos Aspose em vez do Open XML SDK gratuito?* 

Achamos fácil responder a essa pergunta em termos de recursos e funcionalidades. 

De acordo com a [Biblioteca MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), o Open XML SDK é definido desta forma: 

> "O Open XML SDK 2.0 simplifica a tarefa de manipular pacotes Open XML e os elementos de esquema Open XML subjacentes dentro de um pacote. O Open XML SDK 2.0 encapsula muitas tarefas comuns que os desenvolvedores executam em pacotes Open XML, de modo que você pode realizar operações complexas com apenas algumas linhas de código. Documentos OOXML são essencialmente arquivos XML compactados e o Open XML SDK é uma coleção de classes que permite trabalhar com o conteúdo de documentos OOXML de forma fortemente tipada. Isso significa que, em vez de descompactar um arquivo para extrair XML, carregar esse XML em uma árvore DOM e trabalhar diretamente com elementos e atributos XML, o Open XML SDK fornece classes para fazer isso."

## **O que é Aspose.Slides?**
Aspose.Slides é uma biblioteca de classes que permite que aplicativos realizem estas tarefas de processamento de apresentações: 

- Programação com um modelo de objeto de apresentação.  

- Conversões de alta qualidade envolvendo todos os formatos de apresentação PowerPoint suportados, incluindo conversão para PDF, XPS, TIFF e impressão.  

- Geração de miniaturas de slides em formatos bem‑conhecidos como PNG, JPEG e BMP, além de exportação de slides para SVG.  

- Criação de apresentações do zero ou combinando elementos de um ou vários documentos.  

- Adição de animações, OLE Frames, tabelas, criação e gerenciamento de gráficos.  

- Controle (controle extensivo) e gerenciamento da formatação de texto em níveis de TextFrames, Paragraphs e Portions.  

  Para mais detalhes sobre os recursos disponíveis, consulte a página de [Recursos do Aspose.Slides](/slides/pt/net/product-overview/).

## **Comparar Open XML SDK com Aspose.Slides**
Esta tabela compara as capacidades e recursos do Open XML SDK com o Aspose.Slides.

|**Recurso ou Categoria de Recurso**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Formatos de apresentação suportados|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversão de PPT para PPTX|Não|Sim|
|<p>Programação de alto nível com um Modelo de Objeto de Documento de Apresentação (DOM): </p><p>- Localizar e substituir textos.</p><p>- Montar slides em apresentações.</p>|Não|Sim|
|Programação detalhada com um modelo de objeto de documento; acesso a elementos individuais e formatação como TextHolders, TextFrames, Paragraphs e Portions.|Sim|Sim|
|Acesso direto e completo de baixo nível aos elementos e atributos XML subjacentes, como identificadores de relacionamento, identificadores de lista de um documento OOXML.|Sim|Não|
|<p>Renderização e impressão:</p><p>- Renderizar apresentações para PDF, PDF Notes, XPS, imagens TIFF.</p><p>- Renderizar miniaturas de slides para PNG, JPEG, BMP, SVG e TIFF.</p><p>- Especificar resolução da imagem, qualidade, compressão e outras opções.</p><p>- Imprimir apresentações usando a infraestrutura de impressão .NET. O componente tem método de impressão incorporado para imprimir as apresentações como exibido na Pré‑visualização de Impressão do MS PowerPoint.</p>|Não|Sim|
|Plataformas suportadas|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Conclusão**
Open XML SDK e Aspose.Slides não competem diretamente porque atendem a necessidades consideravelmente diferentes e têm públicos-alvo distintos. 

{{% alert color="primary" %}} 

Open XML SDK é uma biblioteca de classes que oferece uma forma fortemente tipada de trabalhar com documentos OOXML, enquanto Aspose.Slides é uma biblioteca de processamento de apresentações incrivelmente útil que fornece grande suporte para quase todos os formatos de arquivos Microsoft PowerPoint. 

{{% /alert %}} 

Se seu fluxo de trabalho consiste em uma operação de programação básica em um documento PPTX, então o Open XML SDK pode ser uma boa escolha. Com o Open XML SDK, você deve se sentir confortável realizando tarefas simples como gerar um documento PPTX simples ou remover comentários, cabeçalhos/rodapés, extrair imagens ou outros. Certas tarefas podem ser realizadas com o Open XML SDK mas não podem ser realizadas com o Aspose.Slides. Por exemplo, se precisar acessar diretamente os elementos e atributos XML de um documento OOXML, então deve usar o Open XML SDK. 

Se precisar executar tarefas complexas em documentos — como as listadas abaixo — então o Aspose.Slides é a melhor opção. 

- Operações que envolvem formatos PowerPoint mais antigos (e PPTX também).  
- Copiar ou clonar formas dentro de slides de maneira que combine objetos, estilos e outros elementos de formatação de forma adequada.  
- Substituir texto formatado ou não formatado.  
- Aplicar animações e usar conectores com formas.  
- Converter um documento para PDF, TIFF ou XPS de modo que pareça ter sido convertido pelo Microsoft PowerPoint.  
- Desenvolver um aplicativo .NET ou Java em ambientes desktop e web.