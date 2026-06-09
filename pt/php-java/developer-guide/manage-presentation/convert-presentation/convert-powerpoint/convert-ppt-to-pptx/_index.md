---
title: Converter PPT para PPTX em PHP
linktitle: PPT para PPTX
type: docs
weight: 20
url: /pt/php-java/convert-ppt-to-pptx/
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
- PHP
- Aspose.Slides
description: "Converta apresentações PPT legadas para PPTX modernos rapidamente com Aspose.Slides para PHP via Java — tutorial claro, amostras de código gratuitas, sem dependência do Microsoft Office."
---
## **Visão geral**

Este artigo explica como converter apresentações PowerPoint no formato PPT para o formato PPTX usando PHP e um aplicativo online de conversão de PPT para PPTX. O tópico a seguir é abordado.

- Converter PPT para PPTX

## **Converter PPT para PPTX em PHP**

Para código de exemplo em Java que converte PPT para PPTX, consulte a seção abaixo, ou seja, [Convert PPT to PPTX](#convert-ppt-to-pptx). Ele apenas carrega o arquivo PPT e o salva no formato PPTX. Ao especificar diferentes formatos de salvamento, você também pode salvar o arquivo PPT em vários outros formatos como PDF, XPS, ODP, HTML etc., conforme discutido nestes artigos.

- [Converter PPT para PDF em PHP](/slides/pt/php-java/convert-powerpoint-to-pdf/)
- [Converter PPT para XPS em PHP](/slides/pt/php-java/convert-powerpoint-to-xps/)
- [Converter PPT para HTML em PHP](/slides/pt/php-java/convert-powerpoint-to-html/)
- [Converter PPT para ODP em PHP](/slides/pt/php-java/save-presentation/)
- [Converter PPT para PNG em PHP](/slides/pt/php-java/convert-powerpoint-to-png/)

## **Sobre a Conversão de PPT para PPTX**
Converta o antigo formato PPT para PPTX com a API Aspose.Slides. Se você precisar converter milhares de apresentações PPT para o formato PPTX, a melhor solução é fazê-lo programaticamente. Com a API Aspose.Slides é possível fazer isso em apenas algumas linhas de código. A API oferece compatibilidade total para converter apresentações PPT para PPTX e permite:

- Converter estruturas complexas de mestres, layouts e slides.
- Converter apresentações com gráficos.
- Converter apresentações com formas agrupadas, autoformas (como retângulos e elipses), formas com geometria personalizada.
- Converter apresentações que possuem texturas e estilos de preenchimento de imagens para autoformas.
- Converter apresentações com placeholders, quadros de texto e contêineres de texto.

{{% alert color="primary" %}} 

Dê uma olhada no aplicativo [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx)

Este aplicativo foi desenvolvido com base na [**Aspose.Slides API**](https://products.aspose.com/slides/pt/php-java/), portanto você pode ver um exemplo ativo das capacidades básicas de conversão de PPT para PPTX. A Conversão Aspose.Slides é um aplicativo web, que permite soltar um arquivo de apresentação no formato PPT e baixá‑lo convertido para PPTX.

Encontre outros exemplos ao vivo de [**Aspose.Slides Conversion**](https://products.aspose.app/slides/pt/conversion/) .
{{% /alert %}} 

## **Converter PPT para PPTX**
Aspose.Slides para PHP via Java agora facilita aos desenvolvedores o acesso ao PPT usando a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) e convertendo‑o para o respectivo formato [PPTX](https://docs.fileformat.com/presentation/pptx/). Atualmente, ele suporta conversão parcial de [PPT ](https://docs.fileformat.com/presentation/ppt/) para PPTX. Para mais detalhes sobre quais recursos são suportados e não suportados na conversão de PPT para PPTX, acesse esta documentação [link](/slides/pt/php-java/ppt-to-pptx-conversion/).

Aspose.Slides para PHP via Java oferece a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation) que representa um arquivo de apresentação **PPTX**. A classe Presentation agora também pode acessar **PPT** por meio de Presentation quando o objeto é instanciado. O exemplo a seguir mostra como converter uma apresentação PPT em uma apresentação PPTX.

```php
  # Instanciar um objeto Presentation que representa um arquivo PPTX
  $pres = new Presentation("Aspose.ppt");
  try {
    # Salvar a apresentação PPTX no formato PPTX
    $pres->save("ConvertedAspose.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**Figura: Apresentação PPT de Origem**|

The above code snippet generated the following PPTX presentation after conversion

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figura: Apresentação PPTX gerada após a conversão**|

## **Perguntas Frequentes**

**Qual é a diferença entre os formatos PPT e PPTX?**

PPT é o formato binário mais antigo usado pelo Microsoft PowerPoint, enquanto PPTX é o formato baseado em XML introduzido com o Microsoft Office 2007. Arquivos PPTX oferecem melhor desempenho, tamanho de arquivo reduzido e recuperação de dados aprimorada.

**O Aspose.Slides suporta conversão em lote de vários arquivos PPT para PPTX?**

Sim, você pode usar o Aspose.Slides em um loop para converter vários arquivos PPT para PPTX programaticamente, tornando‑o adequado para cenários de conversão em lote.

**O conteúdo e a formatação serão preservados após a conversão?**

O Aspose.Slides mantém alta fidelidade ao converter apresentações. Layouts de slides, animações, formas, gráficos e outros elementos de design são preservados durante a conversão de PPT para PPTX.

**Posso converter outros formatos, como PDF ou HTML, a partir de arquivos PPT?**

Sim, o Aspose.Slides suporta a conversão de arquivos PPT para [vários formatos](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveformat/), incluindo PDF, XPS, HTML, ODP e formatos de imagem como PNG e JPEG.

**É possível converter PPT para PPTX sem o Microsoft PowerPoint instalado?**

Sim, o Aspose.Slides é uma API autônoma e não requer o Microsoft PowerPoint ou qualquer software de terceiros para executar a conversão.

**Existe uma ferramenta online disponível para conversão de PPT para PPTX?**

Sim, você pode usar o gratuito [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx) aplicativo web para executar a conversão diretamente no seu navegador sem escrever nenhum código.