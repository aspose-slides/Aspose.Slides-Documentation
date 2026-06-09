---
title: Personalizar tabelas de dados de gráfico em apresentações usando C++
linktitle: Tabela de Dados
type: docs
url: /pt/cpp/chart-data-table/
keywords:
- dados de gráfico
- tabela de dados
- propriedades de fonte
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Personalize tabelas de dados de gráfico em C++ para PPT e PPTX com Aspose.Slides para aumentar a eficiência e o apelo nas apresentações."
---
## **Visão geral**

Este artigo explica como trabalhar com tabelas de dados de gráficos no Aspose.Slides. Ele mostra como exibir uma tabela de dados para um gráfico e personalizar a formatação de texto definindo propriedades de fonte, como estilo negrito e altura da fonte. O exemplo demonstra como carregar uma apresentação, adicionar um gráfico, habilitar a tabela de dados do gráfico, aplicar configurações de fonte e salvar a apresentação atualizada.

## **Definir propriedades de fonte para uma tabela de dados de gráfico**
Aspose.Slides for C++ permite alterar as propriedades de fonte para uma tabela de dados de gráfico.

1. Instanciar o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
1. Adicionar um gráfico ao slide.
1. Definir a tabela do gráfico.
1. Definir a altura da fonte.
1. Salvar a apresentação modificada.

A seguir, um exemplo de código.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso mostrar pequenas chaves de legenda ao lado dos valores na tabela de dados do gráfico?**

Sim. A tabela de dados suporta [legend keys](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/datatable/set_showlegendkey/), e você pode ativá‑las ou desativá‑las.

**A tabela de dados será preservada ao exportar a apresentação para PDF, HTML ou imagens?**

Sim. Aspose.Slides renderiza o gráfico como parte do slide, de modo que o exportado [PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/pt/cpp/convert-powerpoint-to-html/)/[image](/slides/pt/cpp/convert-powerpoint-to-png/) inclui o gráfico com sua tabela de dados.

**As tabelas de dados são suportadas para gráficos que vêm de um arquivo de modelo?**

Sim. Para qualquer gráfico carregado de uma apresentação ou modelo existente, você pode verificar e alterar se uma tabela de dados [is shown](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chart/set_hasdatatable/) usando as propriedades do gráfico.

**Como posso encontrar rapidamente quais gráficos em um arquivo têm a tabela de dados habilitada?**

Inspecione a propriedade de cada gráfico que indica se a tabela de dados [is shown](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chart/get_hasdatatable/) está habilitada e percorra os slides para identificar os gráficos onde ela está ativada.