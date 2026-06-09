---
title: Personalizar legendas de gráficos em apresentações usando C++
linktitle: Legenda do Gráfico
type: docs
url: /pt/cpp/chart-legend/
keywords:
- legenda de gráfico
- posição da legenda
- tamanho da fonte
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Personalize legendas de gráficos com Aspose.Slides para C++ para otimizar apresentações do PowerPoint com formatação de legenda personalizada."
---
## **Visão geral**

Aspose.Slides oferece opções para personalizar legendas de gráficos em apresentações do PowerPoint. Este artigo mostra como posicionar e dimensionar uma legenda, definir o tamanho da fonte para toda a legenda e aplicar formatação a uma entrada individual da legenda.

Ele também aborda vários comportamentos relacionados nas Perguntas Frequentes, incluindo o uso do modo sem sobreposição para que a área do gráfico reserve espaço para a legenda, permitir que rótulos longos de legenda quebrem em linhas ou utilizem quebras de linha, e fazer com que a formatação da legenda herde do tema da apresentação quando configurações explícitas de texto e preenchimento não são aplicadas.

## **Posicionamento da legenda**
Para definir as propriedades da legenda, siga as etapas abaixo:

- Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) classe.
- Obtenha a referência do slide.
- Adicione um gráfico ao slide.
- Defina as propriedades da legenda.
- Grave a apresentação como um arquivo PPTX.

No exemplo abaixo, definimos a posição e o tamanho da legenda do gráfico.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Definir o tamanho da fonte de uma legenda**
O Aspose.Slides para C++ permite que os desenvolvedores definam o tamanho da fonte da legenda. Siga as etapas abaixo:

- Instancie a classe Presentation.
- Crie o gráfico padrão.
- Defina o tamanho da fonte.
- Defina o valor mínimo do eixo.
- Defina o valor máximo do eixo.
- Grave a apresentação no disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Definir o tamanho da fonte de uma legenda individual**
O Aspose.Slides para C++ permite que os desenvolvedores definam o tamanho da fonte de entradas individuais da legenda. Siga as etapas abaixo:

- Instancie a classe Presentation.
- Crie o gráfico padrão.
- Acesse a entrada da legenda.
- Defina o tamanho da fonte.
- Defina o valor mínimo do eixo.
- Defina o valor máximo do eixo.
- Grave a apresentação no disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **Perguntas Frequentes**

**Posso ativar a legenda para que o gráfico reserve espaço automaticamente para ela ao invés de sobrepor?**

Sim. Use o modo sem sobreposição ([set_Overlay(false)](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/legend/set_overlay/)); nesse caso, a área do gráfico será reduzida para acomodar a legenda.

**Posso criar rótulos de legenda com várias linhas?**

Sim. Rótulos longos são quebrados automaticamente quando o espaço é insuficiente; quebras de linha forçadas são suportadas por meio de caracteres de nova linha no nome da série.

**Como faço a legenda seguir o esquema de cores do tema da apresentação?**

Não defina cores, preenchimentos ou fontes explícitas para a legenda ou seu texto. Eles herdarão do tema e serão atualizados corretamente quando o design mudar.