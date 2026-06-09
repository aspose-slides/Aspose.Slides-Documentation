---
title: Converter PPT para PPTX em .NET
linktitle: PPT para PPTX
type: docs
weight: 20
url: /pt/net/convert-ppt-to-pptx/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- PPT para PPTX
- salvar PPT como PPTX
- exportar PPT para PPTX
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Converta apresentações PPT legadas para PPTX modernos rapidamente em .NET com Aspose.Slides — tutorial claro, exemplos de código C# gratuitos, sem dependência do Microsoft Office."
---
## **Visão geral**

Este artigo explica como converter apresentações PowerPoint no formato PPT para o formato PPTX usando C# e um aplicativo online de conversão de PPT para PPTX. O tópico a seguir é abordado.

- [Converter PPT para PPTX em C#](#convert-ppt-to-pptx)

## **Converter PPT para PPTX em .NET**

Para obter código de exemplo em C# que converte PPT para PPTX, consulte a seção abaixo, ou seja, [Convert PPT to PPTX](#convert-ppt-to-pptx). Ele simplesmente carrega o arquivo PPT e o salva no formato PPTX. Ao especificar diferentes formatos de salvamento, você também pode salvar o arquivo PPT em muitos outros formatos, como PDF, XPS, ODP, HTML etc., conforme discutido nesses artigos.

- [Converter PPT para PDF em .NET](/slides/pt/net/convert-powerpoint-to-pdf/)
- [Converter PPT para XPS em .NET](/slides/pt/net/convert-powerpoint-to-xps/)
- [Converter PPT para HTML em .NET](/slides/pt/net/convert-powerpoint-to-html/)
- [Converter PPT para ODP em .NET](/slides/pt/net/save-presentation/)
- [Converter PPT para PNG em .NET](/slides/pt/net/convert-powerpoint-to-png/)

## **Sobre a conversão de PPT para PPTX**
Converta o antigo formato PPT para PPTX usando a API Aspose.Slides. Se você precisar converter milhares de apresentações PPT para o formato PPTX, a melhor solução é fazê-lo programaticamente. Com a API Aspose.Slides é possível fazer isso em poucas linhas de código. A API oferece compatibilidade total para converter apresentações PPT em PPTX e permite:

- Converter estruturas complexas de mestres, layouts e slides.
- Converter apresentações com gráficos.
- Converter apresentações com formas agrupadas, autoformas (como retângulos e elipses), formas com geometria personalizada.
- Converter apresentações que possuem texturas e estilos de preenchimento de imagens para autoformas.
- Converter apresentações com marcadores de posição, quadros de texto e contêineres de texto.

{{% alert color="primary" %}} 

Dê uma olhada no aplicativo [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx)

Este aplicativo foi desenvolvido com base na **Aspose.Slides API**, portanto você pode ver um exemplo ativo das capacidades básicas de conversão de PPT para PPTX. O Aspose.Slides Conversion é um aplicativo web que permite arrastar um arquivo de apresentação no formato PPT e baixá-lo convertido para PPTX.

Encontre outros exemplos ao vivo de [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pt/conversion/) .
{{% /alert %}} 


## **Converter PPT para PPTX**
Para converter um PPT para PPTX, basta passar o nome do arquivo e o formato de salvamento para o método [**Save**](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/methods/save/index) da classe [**Presentation**](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation). O exemplo de código C# abaixo converte uma apresentação de PPT para PPTX usando as opções padrão.

```c#
// Instanciar um objeto Presentation que representa um arquivo PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// Salvando a apresentação PPTX no formato PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

Leia mais sobre os formatos de apresentação [**PPT vs PPTX**](/slides/pt/net/ppt-vs-pptx/) e como [**Aspose.Slides suporta conversão de PPT para PPTX**](/slides/pt/net/convert-ppt-to-pptx/).

## **FAQ**

**Qual é a diferença entre os formatos PPT e PPTX?**

PPT é o formato binário mais antigo usado pelo Microsoft PowerPoint, enquanto PPTX é o formato mais recente baseado em XML introduzido no Microsoft Office 2007. Arquivos PPTX oferecem melhor desempenho, tamanho de arquivo reduzido e recuperação de dados aprimorada.

**Posso converter PPT para PPTX usando .NET?**

Sim, usando a biblioteca Aspose.Slides para .NET, você pode carregar facilmente um arquivo PPT e salvá-lo no formato PPTX com apenas algumas linhas de código.

**O Aspose.Slides suporta conversão em lote de vários arquivos PPT para PPTX?**

Sim, você pode usar o Aspose.Slides em um loop para converter vários arquivos PPT em PPTX programaticamente, tornando-o adequado para cenários de conversão em lote.

**O conteúdo e a formatação serão preservados após a conversão?**

Aspose.Slides mantém alta fidelidade ao converter apresentações. Layouts de slides, animações, formas, gráficos e outros elementos de design são preservados durante a conversão de PPT para PPTX.

**Posso converter outros formatos como PDF ou HTML a partir de arquivos PPT?**

Sim, o Aspose.Slides suporta a conversão de arquivos PPT para vários formatos, incluindo PDF, XPS, HTML, ODP e formatos de imagem como PNG e JPEG.

**É possível converter PPT para PPTX sem o Microsoft PowerPoint instalado?**

Sim, o Aspose.Slides para .NET é uma API independente e não requer o Microsoft PowerPoint ou qualquer software de terceiros para executar a conversão.

**Existe uma ferramenta online disponível para conversão de PPT para PPTX?**

Sim, você pode usar o gratuito [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx) aplicação web para realizar a conversão diretamente no seu navegador sem escrever nenhum código.