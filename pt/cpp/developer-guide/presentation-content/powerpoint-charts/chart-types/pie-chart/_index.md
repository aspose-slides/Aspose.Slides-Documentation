---
title: Personalizar gráficos de pizza em apresentações usando C++
linktitle: Gráfico de Pizza
type: docs
url: /pt/cpp/pie-chart/
keywords:
- gráfico de pizza
- gerenciar gráfico
- personalizar gráfico
- opções de gráfico
- configurações de gráfico
- opções de plotagem
- cor da fatia
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a criar e personalizar gráficos de pizza em C++ com Aspose.Slides, exportáveis para PowerPoint, impulsionando a narrativa dos seus dados em segundos."
---
## **Visão geral**

Este artigo explica como trabalhar com gráficos de pizza no Aspose.Slides. Ele mostra como configurar opções de plotagem secundária para gráficos Pizza de Pizza e Barra de Pizza, e como habilitar a coloração automática de fatias para um gráfico de pizza padrão.

Os exemplos se concentram em etapas práticas de personalização de gráficos, como adicionar um gráfico a um slide, ajustar as configurações de séries e rótulos, substituir os dados padrão do gráfico por categorias e valores personalizados e salvar a apresentação atualizada.

## **Opções de Plotagem Secundária para Gráficos Pizza de Pizza e Barra de Pizza**
Aspose.Slides para C++ agora oferece suporte a opções de plotagem secundária para gráficos Pizza de Pizza ou Barra de Pizza. Neste tópico, veremos com um exemplo como especificar essas opções usando o Aspose.Slides. Para definir as propriedades, siga as etapas abaixo:

1. Instanciar o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Adicionar um gráfico ao slide.
1. Especificar as opções de plotagem secundária do gráfico.
1. Gravar a apresentação no disco.

No exemplo abaixo, definimos diferentes propriedades do gráfico Pizza de Pizza.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Definir Cores Automáticas das Fatias do Gráfico de Pizza**
O Aspose.Slides para C++ fornece uma API simples para definir cores automáticas das fatias de gráficos de pizza. O código de exemplo aplica a configuração das propriedades mencionadas acima.

1. Criar uma instância da classe Presentation.
1. Acessar o primeiro slide.
1. Adicionar um gráfico com dados padrão.
1. Definir o título do gráfico.
1. Definir a primeira série para Mostrar Valores.
1. Definir o índice da planilha de dados do gráfico.
1. Obter a planilha de dados do gráfico.
1. Excluir as séries e categorias geradas por padrão.
1. Adicionar novas categorias.
1. Adicionar uma nova série.

Gravar a apresentação modificada em um arquivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **Perguntas Frequentes**

**As variações 'Pizza de Pizza' e 'Barra de Pizza' são suportadas?**

Sim, a biblioteca [suporta](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/charttype/) uma plotagem secundária para gráficos de pizza, incluindo os tipos 'Pizza de Pizza' e 'Barra de Pizza'.

**Posso exportar apenas o gráfico como imagem (por exemplo, PNG)?**

Sim, você pode [exportar o próprio gráfico como imagem](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/getimage/) (por exemplo, PNG) sem a apresentação inteira.