---
title: Gerenciar balões de chamada em gráficos de apresentações usando С++
linktitle: Balão de chamada
type: docs
url: /pt/cpp/callout/
keywords:
- balão de chamada de gráfico
- usar balão de chamada
- rótulo de dados
- formato de rótulo
- PowerPoint
- apresentação
- С++
- Aspose.Slides
description: "Crie e estilize balões de chamada no Aspose.Slides para С++ com exemplos de código concisos, compatíveis com PPT e PPTX para automatizar fluxos de trabalho de apresentações."
---
## **Visão geral**

Este artigo explica como trabalhar com balões de chamada para rótulos de dados de gráficos no Aspose.Slides. Ele mostra como usar o método `set_ShowLabelAsDataCallout` para exibir os rótulos como balões de chamada, como configurar as definições de rótulo relacionadas a balões para um gráfico de rosca e observa que os balões e sua aparência são mantidos quando as apresentações são exportadas para PDF, HTML5, SVG e formatos de imagem raster.

## **Usando balões de chamada**
A nova propriedade **ShowLabelAsDataCallout** foi adicionada à classe **DataLabelFormat** e à interface **IDataLabelFormat**, que determina se o rótulo de dados de um gráfico especificado será exibido como balão de chamada ou como rótulo de dados. No exemplo abaixo, definimos os balões.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Definir um balão para um gráfico de rosca**
Aspose.Slides for C++ oferece suporte para definir a forma do balão de chamada do rótulo de dados da série para um gráfico de rosca. O exemplo a seguir ilustra isso.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **Perguntas frequentes**

**Os balões de chamada são preservados ao converter uma apresentação para PDF, HTML5, SVG ou imagens?**

Sim. Os balões fazem parte da renderização do gráfico, portanto, ao exportar para [PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/pt/cpp/export-to-html5/), [SVG](/slides/pt/cpp/render-a-slide-as-an-svg-image/) ou [imagens raster](/slides/pt/cpp/convert-powerpoint-to-png/), eles são preservados juntamente com a formatação do slide.

**Fontes personalizadas funcionam nos balões de chamada e sua aparência pode ser preservada na exportação?**

Sim. O Aspose.Slides suporta [embeddding de fontes](/slides/pt/cpp/embedded-font/) na apresentação e controla a incorporação de fontes durante exportações como [PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/), garantindo que os balões de chamada permaneçam com a mesma aparência em diferentes sistemas.