---
title: Converter PPT para PPTX em Java
linktitle: PPT para PPTX
type: docs
weight: 20
url: /pt/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Converta apresentações PPT legadas para PPTX moderno rapidamente em Java com Aspose.Slides — tutorial claro, exemplos de código gratuitos, sem dependência do Microsoft Office."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint no formato PPT para o formato PPTX usando Java e com aplicativo online de conversão de PPT para PPTX. O tópico a seguir é abordado.

- Converter PPT para PPTX em Java

## **Converter PPT para PPTX em Java**

Para ver código de exemplo em Java para converter PPT para PPTX, consulte a seção abaixo, ou seja, [Converter PPT para PPTX](#convert-ppt-to-pptx). Ele apenas carrega o arquivo PPT e salva no formato PPTX. Ao especificar diferentes formatos de salvamento, você também pode salvar o arquivo PPT em muitos outros formatos, como PDF, XPS, ODP, HTML etc., conforme discutido nestes artigos.

- [Converter PPT para PDF em Java](/slides/pt/java/convert-powerpoint-to-pdf/)
- [Converter PPT para XPS em Java](/slides/pt/java/convert-powerpoint-to-xps/)
- [Converter PPT para HTML em Java](/slides/pt/java/convert-powerpoint-to-html/)
- [Converter PPT para ODP em Java](/slides/pt/java/save-presentation/)
- [Converter PPT para PNG em Java](/slides/pt/java/convert-powerpoint-to-png/)

## **Sobre a Conversão de PPT para PPTX**

Converta o formato PPT antigo para PPTX com a API Aspose.Slides. Se você precisar converter milhares de apresentações PPT para o formato PPTX, a melhor solução é fazer isso programaticamente. Com a API Aspose.Slides é possível fazê‑lo em apenas algumas linhas de código. A API oferece compatibilidade total para converter apresentações PPT para PPTX e é possível:

- Converter estruturas complexas de mestres, layouts e slides.
- Converter apresentações com gráficos.
- Converter apresentações com formas agrupadas, auto‑formas (como retângulos e elipses), formas com geometria personalizada.
- Converter apresentações que possuam texturas e estilos de preenchimento de imagens para auto‑formas.
- Converter apresentações com marcadores de posição, quadros de texto e contêineres de texto.

{{% alert color="primary" %}} 

Confira o aplicativo [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx)

Este aplicativo foi construído com base na [**Aspose.Slides API**](https://products.aspose.com/slides/pt/java/), portanto você pode ver um exemplo ativo das capacidades básicas de conversão de PPT para PPTX. Aspose.Slides Conversion é um aplicativo web, que permite arrastar um arquivo de apresentação em formato PPT e baixá‑lo convertido para PPTX.

Encontre outros exemplos ao vivo de [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pt/conversion/).

{{% /alert %}} 

## **Converter PPT para PPTX**

Aspose.Slides para Java agora facilita aos desenvolvedores o acesso ao PPT usando a instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation) e convertendo‑a para o respectivo formato [PPTX](https://docs.fileformat.com/presentation/pptx/). Atualmente, ele oferece conversão parcial de [PPT](https://docs.fileformat.com/presentation/ppt/) para PPTX. Para mais detalhes sobre quais recursos são suportados e não suportados na conversão de PPT para PPTX, consulte esta documentação [link](/slides/pt/java/ppt-to-pptx-conversion/).

Aspose.Slides para Java oferece a classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation) que representa um arquivo de apresentação **PPTX**. A classe Presentation agora também pode acessar **PPT** através de Presentation quando o objeto é instanciado. O exemplo a seguir mostra como converter uma apresentação PPT em uma apresentação PPTX.

```java
// Instanciar um objeto Presentation que representa um arquivo PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// Salvando a apresentação PPTX no formato PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figura : Apresentação PPT de origem**|

O trecho de código acima gerou a seguinte apresentação PPTX após a conversão

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figura: Apresentação PPTX gerada após a conversão**|

## **FAQ**

**Qual é a diferença entre os formatos PPT e PPTX?**

PPT é o antigo formato binário usado pelo Microsoft PowerPoint, enquanto PPTX é o novo formato baseado em XML introduzido com o Microsoft Office 2007. Arquivos PPTX oferecem melhor desempenho, tamanho de arquivo reduzido e recuperação de dados aprimorada.

**O Aspose.Slides suporta conversão em lote de vários arquivos PPT para PPTX?**

Sim, você pode usar o Aspose.Slides em um loop para converter vários arquivos PPT para PPTX programaticamente, tornando‑o adequado para cenários de conversão em lote.

**O conteúdo e a formatação serão preservados após a conversão?**

Aspose.Slides mantém alta fidelidade na conversão de apresentações. Layouts de slides, animações, formas, gráficos e outros elementos de design são preservados durante a conversão de PPT para PPTX.

**Posso converter outros formatos, como PDF ou HTML, a partir de arquivos PPT?**

Sim, o Aspose.Slides suporta a conversão de arquivos PPT para [vários formatos](https://reference.aspose.com/slides/pt/java/com.aspose.slides/saveformat/), incluindo PDF, XPS, HTML, ODP e formatos de imagem como PNG e JPEG.

**É possível converter PPT para PPTX sem o Microsoft PowerPoint instalado?**

Sim, o Aspose.Slides é uma API independente e não requer o Microsoft PowerPoint ou qualquer software de terceiros para executar a conversão.

**Existe uma ferramenta online disponível para conversão de PPT para PPTX?**

Sim, você pode usar o gratuito [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx) aplicativo web para realizar a conversão diretamente no seu navegador sem escrever código.