---
title: Converter PPT para PPTX em Python
linktitle: PPT para PPTX
type: docs
weight: 20
url: /pt/python-net/convert-ppt-to-pptx/
keywords:
- converter PPT
- PPT para PPTX
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Converta apresentações PPT legadas para PPTX modernos rapidamente em Python com Aspose.Slides — tutorial claro, exemplos de código gratuitos, sem dependência do Microsoft Office."
---
## **Visão geral**

Este artigo explica como converter uma apresentação do PowerPoint no formato PPT para PPTX usando Python e um aplicativo online de conversão de PPT para PPTX. O tópico a seguir é abordado:

- Converter PPT para PPTX em Python

## **Python - Converter PPT para PPTX**

Para o código de exemplo em Python que converte PPT para PPTX, veja a seção abaixo, ou seja, [Convert PPT to PPTX](#convert-ppt-to-pptx). Ele simplesmente carrega o arquivo PPT e o salva no formato PPTX. Ao especificar diferentes formatos de salvamento, você também pode salvar um arquivo PPT em muitos outros formatos, como PDF, XPS, ODP, HTML, etc., conforme discutido nesses artigos:

- [Convert PPT to PDF in Python](/slides/pt/python-net/convert-powerpoint-to-pdf/)
- [Convert PPT to XPS in Python](/slides/pt/python-net/convert-powerpoint-to-xps/)
- [Convert PPT to HTML in Python](/slides/pt/python-net/convert-powerpoint-to-html/)
- [Convert PPT to ODP in Python](/slides/pt/python-net/save-presentation/)
- [Convert PPT to PNG in Python](/slides/pt/python-net/convert-powerpoint-to-png/)

## **Sobre a conversão de PPT para PPTX**
Converta o formato antigo PPT para PPTX com a API Aspose.Slides. Se você precisar converter milhares de apresentações PPT para o formato PPTX, a melhor solução é fazê‑lo programaticamente. Com a API Aspose.Slides, isso é possível em apenas algumas linhas de código. A API oferece compatibilidade total para converter uma apresentação PPT para PPTX, e permite:

- Converter estruturas complexas de mestres, layouts e slides.
- Converter uma apresentação com gráficos.
- Converter uma apresentação com formas agrupadas, autoformas (como retângulos e elipses) e formas com geometria personalizada.
- Converter uma apresentação que possui texturas e estilos de preenchimento de imagem em autoformas.
- Converter uma apresentação com marcadores de posição, quadros de texto e contêineres de texto.

{{% alert color="primary" %}}

Dê uma olhada no aplicativo **Conversão Aspose.Slides de PPT para PPTX**:

[](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx)

Este aplicativo foi construído com base na **Aspose.Slides API**, portanto você pode ver um exemplo ao vivo das capacidades básicas de conversão de PPT para PPTX. Aspose.Slides Conversion é um aplicativo web que permite arrastar um arquivo de apresentação no formato PPT e baixá‑lo convertido para PPTX.

Encontre outras demonstrações ao vivo de **Aspose.Slides Conversion**[https://products.aspose.app/slides/pt/conversion/](https://products.aspose.app/slides/pt/conversion/).

{{% /alert %}}

## **Converter PPT para PPTX**
Para converter um PPT para PPTX, basta passar o nome do arquivo e o formato de salvamento ao método [**Save**](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) da classe [**Presentation**](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). O exemplo de código Python abaixo converte uma apresentação de PPT para PPTX usando as opções padrão.

```python
import aspose.slides as slides

# Instanciar um objeto Presentation que representa um arquivo PPT
pres = slides.Presentation("PPTtoPPTX.ppt")

# Salvar a apresentação no formato PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

Leia mais sobre os formatos de apresentação [**PPT vs PPTX**](/slides/pt/python-net/ppt-vs-pptx/) e como a [**Aspose.Slides suporta a conversão de PPT para PPTX**](/slides/pt/python-net/convert-ppt-to-pptx/).

## **Perguntas frequentes**

**Qual é a diferença entre os formatos PPT e PPTX?**

PPT é o formato binário mais antigo usado pelo Microsoft PowerPoint, enquanto PPTX é o formato mais novo baseado em XML introduzido com o Microsoft Office 2007. Arquivos PPTX oferecem melhor desempenho, tamanho de arquivo reduzido e recuperação de dados aprimorada.

**Posso converter PPT para PPTX usando Python?**

Sim, usando a biblioteca Aspose.Slides for Python via .NET, você pode carregar facilmente um arquivo PPT e salvá‑lo no formato PPTX com apenas algumas linhas de código.

**O Aspose.Slides suporta conversão em lote de vários arquivos PPT para PPTX?**

Sim, você pode usar o Aspose.Slides em um loop para converter programaticamente vários arquivos PPT para PPTX, tornando‑o adequado para cenários de conversão em lote.

**O conteúdo e a formatação serão preservados após a conversão?**

Aspose.Slides mantém alta fidelidade ao converter apresentações. Layouts de slides, animações, formas, gráficos e outros elementos de design são preservados durante a conversão de PPT para PPTX.

**Posso converter outros formatos, como PDF ou HTML, a partir de arquivos PPT?**

Sim, o Aspose.Slides suporta a conversão de arquivos PPT para vários formatos, incluindo PDF, XPS, HTML, ODP e formatos de imagem como PNG e JPEG.

**É possível converter PPT para PPTX sem o Microsoft PowerPoint instalado?**

Sim, o Aspose.Slides for Python via .NET é uma API autônoma e não requer o Microsoft PowerPoint ou qualquer software de terceiros para realizar a conversão.

**Existe uma ferramenta online disponível para conversão de PPT para PPTX?**

Sim, você pode usar o gratuito [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx) aplicativo web para realizar a conversão diretamente no seu navegador sem escrever nenhum código.