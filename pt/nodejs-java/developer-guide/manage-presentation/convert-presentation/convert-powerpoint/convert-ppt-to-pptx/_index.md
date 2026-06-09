---
title: Converter PPT para PPTX em JavaScript
linktitle: PPT para PPTX
type: docs
weight: 20
url: /pt/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converta apresentações PPT legadas para PPTX moderno rapidamente com Aspose.Slides para Node.js — tutorial claro, exemplos de código gratuitos, sem dependência do Microsoft Office."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint no formato PPT para o formato PPTX usando JavaScript e um aplicativo online de conversão de PPT para PPTX. O tópico a seguir é abordado.

- Converter PPT para PPTX em JavaScript

## **JavaScript Converte PPT para PPTX**

Para o código de exemplo em JavaScript que converte PPT para PPTX, consulte a seção abaixo, ou seja, [Converter PPT para PPTX](#convert-ppt-to-pptx). Ele simplesmente carrega o arquivo PPT e salva no formato PPTX. Ao especificar diferentes formatos de salvamento, você também pode salvar o arquivo PPT em muitos outros formatos, como PDF, XPS, ODP, HTML etc., conforme discutido nesses artigos.

- [Converter PPT para PDF em JavaScript](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/)
- [Converter PPT para XPS em JavaScript](/slides/pt/nodejs-java/convert-powerpoint-to-xps/)
- [Converter PPT para HTML em JavaScript](/slides/pt/nodejs-java/convert-powerpoint-to-html/)
- [Converter PPT para ODP em JavaScript](/slides/pt/nodejs-java/save-presentation/)
- [Converter PPT para PNG em JavaScript](/slides/pt/nodejs-java/convert-powerpoint-to-png/)

## **Sobre a Conversão de PPT para PPTX**
Converta o formato antigo PPT para PPTX com a API Aspose.Slides. Se você precisar converter milhares de apresentações PPT para o formato PPTX, a melhor solução é fazê‑lo programaticamente. Com a API Aspose.Slides, isso é possível em apenas algumas linhas de código. A API oferece compatibilidade total para converter apresentações PPT para PPTX e permite:

- Converter estruturas complexas de mestres, layouts e slides.
- Converter apresentações com gráficos.
- Converter apresentações com formas agrupadas, autoformas (como retângulos e elipses), formas com geometria personalizada.
- Converter apresentações que possuem texturas e estilos de preenchimento de imagens para autoformas.
- Converter apresentações com marcadores de posição, quadros de texto e contêineres de texto.

{{% alert color="primary" %}} 

Dê uma olhada no aplicativo [**Aspose.Slides PPT para Conversão PPTX**](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx)

Este aplicativo foi criado com base na [**API Aspose.Slides**](https://products.aspose.com/slides/pt/nodejs-java/), portanto você pode ver um exemplo ativo das capacidades básicas de conversão de PPT para PPTX. Aspose.Slides Conversion é um aplicativo web que permite arrastar um arquivo de apresentação no formato PPT e baixá‑lo convertido para PPTX.

Encontre outros exemplos ao vivo de [**Conversão Aspose.Slides**](https://products.aspose.app/slides/pt/conversion/).
{{% /alert %}} 

## **Converter PPT para PPTX**
Aspose.Slides para Node.js via Java agora facilita aos desenvolvedores o acesso ao PPT usando a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation) e a conversão para o respectivo formato [PPTX](https://docs.fileformat.com/presentation/pptx/). Atualmente, ele suporta conversão parcial de [PPT](https://docs.fileformat.com/presentation/ppt/) para PPTX.

Aspose.Slides para Node.js via Java oferece a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation) que representa um arquivo de apresentação **PPTX**. A classe Presentation agora também pode acessar **PPT** através de Presentation quando o objeto é instanciado. O exemplo a seguir mostra como converter uma apresentação PPT em uma apresentação PPTX.

```javascript
// Instanciar um objeto Presentation que representa um arquivo PPTX
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // Salvando a apresentação PPTX no formato PPTX
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figura : Apresentação PPT de origem**|

O trecho de código acima gera a seguinte apresentação PPTX após a conversão

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figura: Apresentação PPTX gerada após a conversão**|

## **FAQ**

**Qual é a diferença entre os formatos PPT e PPTX?**

PPT é o formato binário antigo usado pelo Microsoft PowerPoint, enquanto PPTX é o formato mais recente baseado em XML introduzido com o Microsoft Office 2007. Arquivos PPTX oferecem melhor desempenho, tamanho de arquivo reduzido e recuperação de dados aprimorada.

**O Aspose.Slides suporta conversão em lote de vários arquivos PPT para PPTX?**

Sim, você pode usar o Aspose.Slides em um loop para converter vários arquivos PPT para PPTX programaticamente, tornando‑o adequado para cenários de conversão em lote.

**O conteúdo e a formatação serão preservados após a conversão?**

Aspose.Slides mantém alta fidelidade ao converter apresentações. Disposições de slides, animações, formas, gráficos e outros elementos de design são preservados durante a conversão de PPT para PPTX.

**Posso converter outros formatos, como PDF ou HTML, a partir de arquivos PPT?**

Sim, o Aspose.Slides suporta a conversão de arquivos PPT para vários formatos, incluindo PDF, XPS, HTML, ODP e formatos de imagem como PNG e JPEG.

**É possível converter PPT para PPTX sem o Microsoft PowerPoint instalado?**

Sim, o Aspose.Slides é uma API autônoma e não requer o Microsoft PowerPoint nem nenhum software de terceiros para realizar a conversão.

**Existe uma ferramenta online disponível para conversão de PPT para PPTX?**

Sim, você pode usar o aplicativo web gratuito [Conversor Aspose.Slides PPT para PPTX](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx) para realizar a conversão diretamente no seu navegador sem escrever código.