---
title: Personalizar Pontos de Dados em Gráficos Treemap e Sunburst Usando С++
linktitle: Pontos de Dados em Gráficos Treemap e Sunburst
type: docs
url: /pt/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- gráfico treemap
- gráfico sunburst
- ponto de dados
- cor do rótulo
- cor do ramo
- PowerPoint
- apresentação
- С++
- Aspose.Slides
description: "Aprenda como gerenciar pontos de dados em gráficos treemap e sunburst com Aspose.Slides para С++, compatível com formatos PowerPoint."
---
## **Introdução**

Entre outros tipos de gráficos do PowerPoint, existem dois tipos “hierárquicos” – **Treemap** e **Sunburst** (também conhecidos como Gráfico Sunburst, Diagrama Sunburst, Gráfico Radial, Gráfico Radial ou Gráfico de Pizza Multi‑Nível). Esses gráficos exibem dados hierárquicos organizados como uma árvore – dos nós folhas até o topo do ramo. As folhas são definidas pelos pontos de dados da série, e cada nível de agrupamento aninhado subsequente é definido pela categoria correspondente. Aspose.Slides for C++ permite formatar pontos de dados dos gráficos Sunburst e Treemap em C++.

Este é um gráfico Sunburst, onde os dados na coluna Series1 definem os nós folha, enquanto as outras colunas definem pontos de dados hierárquicos:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Vamos começar adicionando um novo gráfico Sunburst à apresentação:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
// ...
```

{{% alert color="primary" title="Veja também" %}} 
- [**Criando Gráfico Sunburst**](/slides/pt/cpp/create-chart/#create-sunburst-chart)
{{% /alert %}}

Se houver necessidade de formatar pontos de dados do gráfico, devemos usar o seguinte:

as classes [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/), [**IChartDataPointLevel**](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatapointlevel/) e o método [**IChartDataPoint::get_DataPointLevels()**](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) fornecem acesso para formatar pontos de dados dos gráficos Treemap e Sunburst.  
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) é usado para acessar categorias de múltiplos níveis – representa o contêiner de objetos [**IChartDataPointLevel**](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatapointlevel/).  
Basicamente, ele é um wrapper para [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartcategorylevelsmanager/) com propriedades adicionadas específicas para pontos de dados.  
A classe [**IChartDataPointLevel**](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatapointlevel/) possui dois métodos: [**get_Format()**](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatapointlevel/get_format/) e [**get_Label()**](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatapointlevel/get_label/) que fornecem acesso às configurações correspondentes.

## **Exibir o Valor de um Ponto de Dados**
Exibir o valor do ponto de dados “Leaf 4”:

``` cpp
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();
dataPoints->idx_get(3)->get_DataPointLevels()->idx_get(0)->get_Label()->get_DataLabelFormat()->set_ShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Definir Rótulo e Cor de um Ponto de Dados**
Defina o rótulo de dados de “Branch 1” para exibir o nome da série (“Series1”) ao invés do nome da categoria. Em seguida, defina a cor do texto para amarelo:

``` cpp
auto branch1Label = dataPoints->idx_get(0)->get_DataPointLevels()->idx_get(2)->get_Label();
branch1Label->get_DataLabelFormat()->set_ShowCategoryName(false);
branch1Label->get_DataLabelFormat()->set_ShowSeriesName(true);

branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
branch1Label->get_DataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Definir a Cor do Ramo do Ponto de Dados**
Alterar a cor do ramo “Stem 4”:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Sunburst, 100.0f, 100.0f, 450.0f, 400.0f);
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

auto stem4branch = dataPoints->idx_get(9)->get_DataPointLevels()->idx_get(1);
stem4branch->get_Format()->get_Fill()->set_FillType(FillType::Solid);
stem4branch->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Perguntas Frequentes**

**Posso mudar a ordem (classificação) dos segmentos em Sunburst/Treemap?**  
Não. O PowerPoint ordena os segmentos automaticamente (geralmente por valores decrescentes, no sentido horário). O Aspose.Slides reproduz esse comportamento: não é possível mudar a ordem diretamente; isso é feito pré‑processando os dados.

**Como o tema da apresentação afeta as cores dos segmentos e rótulos?**  
As cores do gráfico herdam o [tema/paleta](/slides/pt/cpp/presentation-theme/) da apresentação, a menos que você defina explicitamente preenchimentos/fonte. Para resultados consistentes, fixe preenchimentos sólidos e formatação de texto nos níveis necessários.

**A exportação para PDF/PNG preserva cores personalizadas de ramos e configurações de rótulo?**  
Sim. Ao exportar a apresentação, as configurações do gráfico (preenchimentos, rótulos) são preservadas nos formatos de saída porque o Aspose.Slides renderiza com a formatação do gráfico aplicada.

**Posso calcular as coordenadas reais de um rótulo/elemento para posicionamento personalizado de sobreposição sobre o gráfico?**  
Sim. Após a disposição do gráfico ser validada, os valores reais de X e Y estão disponíveis para os elementos (por exemplo, um [DataLabel](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/datalabel/)), o que auxilia no posicionamento preciso de sobreposições.