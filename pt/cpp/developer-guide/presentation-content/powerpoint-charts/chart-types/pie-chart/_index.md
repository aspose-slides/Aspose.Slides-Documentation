---
title: Personalizar Gráficos de Pizza em Apresentações Usando С++
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
- С++
- Aspose.Slides
description: "Aprenda a criar e personalizar gráficos de pizza em С++ com Aspose.Slides, exportáveis para PowerPoint, impulsionando a narrativa dos seus dados em segundos."
---
## **Visão geral**

Este artigo explica como trabalhar com gráficos de pizza no Aspose.Slides. Ele mostra como configurar opções de gráfico secundário para gráficos Pie of Pie e Bar of Pie, e como habilitar a coloração automática de fatias para um gráfico de pizza padrão.

Os exemplos focam em etapas práticas de personalização de gráficos, como adicionar um gráfico a um slide, ajustar configurações de séries e rótulos, substituir os dados padrão do gráfico por categorias e valores personalizados, e salvar a apresentação atualizada.

## **Opções de Gráfico Secundário para Gráficos Pie of Pie e Bar of Pie**

Aspose.Slides for C++ agora suporta opções de gráfico secundário para gráficos Pie of Pie ou Bar of Pie. Neste tópico, veremos com um exemplo como especificar essas opções usando Aspose.Slides. Para especificar as propriedades, siga os passos abaixo:

1. Instanciar o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Adicionar gráfico ao slide.
1. Especificar as opções de gráfico secundário do gráfico.
1. Gravar a apresentação no disco.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Definir Cores Automáticas das Fatias do Gráfico de Pizza**

Aspose.Slides for C++ fornece uma API simples para definir cores automáticas das fatias de gráficos de pizza. O código de exemplo aplica a configuração das propriedades mencionadas acima.

1. Crie uma instância da classe Presentation.
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Defina o título do gráfico.
1. Defina a primeira série para Mostrar Valores.
1. Defina o índice da planilha de dados do gráfico.
1. Obtenha a planilha de dados do gráfico.
1. Exclua as séries e categorias geradas por padrão.
1. Adicione novas categorias.
1. Adicione novas séries.

Grave a apresentação modificada em um arquivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**As variações 'Pie of Pie' e 'Bar of Pie' são suportadas?**

Sim, a biblioteca [suporta](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/charttype/) um gráfico secundário para gráficos de pizza, incluindo os tipos 'Pie of Pie' e 'Bar of Pie'.

**Posso exportar apenas o gráfico como imagem (por exemplo, PNG)?**

Sim, você pode [exportar o próprio gráfico como uma imagem](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/getimage/) (como PNG) sem a apresentação completa.