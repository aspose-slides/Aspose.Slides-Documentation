---
title: Gerenciar Callouts em Gráficos de Apresentação Usando C++
linktitle: Balão
type: docs
url: /pt/cpp/callout/
keywords:
- callout de gráfico
- usar callout
- rótulo de dados
- formato de rótulo
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Crie e estilize callouts no Aspose.Slides para C++ com exemplos de código concisos, compatíveis com PPT e PPTX para automatizar fluxos de trabalho de apresentações."
---
## **Visão geral**

Este artigo explica como trabalhar com callouts para rótulos de dados de gráfico no Aspose.Slides. Ele mostra como usar o método `set_ShowLabelAsDataCallout` para exibir rótulos como callouts, como configurar as definições de rótulo relacionadas a callout para um gráfico de rosquinha e observa que os callouts e sua aparência são preservados quando as apresentações são exportadas para PDF, HTML5, SVG e formatos de imagem raster.

## **Usando Callouts**
A nova propriedade **ShowLabelAsDataCallout** foi adicionada à classe **DataLabelFormat** e à interface **IDataLabelFormat**, que determina se o rótulo de dados do gráfico especificado será exibido como callout ou como rótulo de dados. No exemplo abaixo, definimos os Callouts.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Definir um Callout para um Gráfico de Rosca**
Aspose.Slides for C++ oferece suporte para definir a forma do callout do rótulo de dados da série para um gráfico de Rosca. O exemplo de amostra abaixo é fornecido.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**Os callouts são preservados ao converter uma apresentação para PDF, HTML5, SVG ou imagens?**

Sim. Os callouts fazem parte da renderização do gráfico, portanto, ao exportar para [PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/pt/cpp/export-to-html5/), [SVG](/slides/pt/cpp/render-a-slide-as-an-svg-image/) ou [imagens raster](/slides/pt/cpp/convert-powerpoint-to-png/), eles são preservados junto com a formatação do slide.

**As fontes personalizadas funcionam em callouts e sua aparência pode ser preservada na exportação?**

Sim. O Aspose.Slides suporta [incorporação de fontes](/slides/pt/cpp/embedded-font/) na apresentação e controla a incorporação de fontes durante exportações como [PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/), garantindo que os callouts tenham a mesma aparência em diferentes sistemas.