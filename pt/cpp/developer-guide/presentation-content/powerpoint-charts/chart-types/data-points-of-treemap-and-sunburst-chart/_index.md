---
title: Personalizar pontos de dados em gráficos Treemap e Sunburst em C++
linktitle: Pontos de dados em gráficos Treemap e Sunburst
type: docs
url: /pt/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- gráfico treemap
- gráfico sunburst
- gráfico hierárquico
- ponto de dados
- rótulo de dados
- cor de ramo
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a criar dados hierárquicos e personalizar níveis, rótulos e cores em gráficos Treemap e Sunburst com Aspose.Slides para C++."
---
## **Visão geral**

Os gráficos Treemap e Sunburst exibem o mesmo tipo de dados hierárquicos, porém utilizam layouts diferentes. Um Treemap desenha a hierarquia como retângulos aninhados cujas áreas representam os valores das folhas. Um Sunburst desenha-a como anéis concêntricos: os grupos de nível superior ficam próximos ao centro e as categorias folhas ficam no anel externo.

No Aspose.Slides for C++, cada valor numérico é um [IChartDataPoint](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatapoint/). Seu método [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) fornece acesso à folha e aos seus grupos pai. Este artigo explica esse mapeamento e mostra como criar e formatar ambos os tipos de gráfico a partir dos mesmos dados de exemplo.

![Um gráfico Treemap com ramos Consumer e Business](treemap-hierarchy.png)

![Um gráfico Sunburst com a mesma hierarquia Consumer e Business](sunburst-hierarchy.png)

## **Entender categorias, pontos de dados e níveis**

O exemplo usado abaixo possui três níveis de categoria e uma série numérica:

| Branch | Stem | Leaf | Revenue |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Cada linha cria uma categoria folha e um ponto de dados. Os níveis de agrupamento de categoria descrevem o caminho dessa folha até seus pais. Para a primeira linha, o caminho é `Consumer > Computers > Laptops`.

Os índices retornados por [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) vão da folha para cima:

| `get_DataPointLevels()` index | Logical level | Representação Treemap | Representação Sunburst |
| ---: | --- | --- | --- |
| `0` | Leaf | Retângulo de valor | Segmento do anel externo |
| `1` | Stem | Retângulo ou cabeçalho pai | Segmento do anel médio |
| `2` | Branch | Retângulo ou cabeçalho de nível superior | Segmento do anel interno |

Essa ordem é a mesma para ambos os tipos de gráfico, embora seus layouts visuais difiram. Um segmento pai é compartilhado por várias folhas. Para formatá‑lo, use o nível correspondente do primeiro ponto de dados naquele grupo. Por exemplo, o ramo `Consumer` começa com o ponto `Laptops`, enquanto o tronco `Software` começa com o ponto `Licenses`. Manter referências a esses pontos é mais claro e seguro do que usar expressões não explicadas como `dataPoints->idx_get(0)` ou `dataPoints->idx_get(6)`.

## **Criar e personalizar ambos os tipos de gráfico**

O exemplo completo a seguir cria um Treemap no primeiro slide e um Sunburst no segundo slide. Ele constrói a hierarquia, exibe o valor para `Tablets`, aplica cores fixas a níveis selecionados, formata um rótulo de ramo e salva a apresentação.

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // Adicionar as categorias folha. Um item de agrupamento é definido somente quando um novo grupo começa;
    // as categorias seguintes permanecem nesse grupo até que outro item seja definido.
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // Exibir a categoria e o valor na folha Tablets.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Formatar o ramo Consumer através da primeira folha desse ramo.
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // Formatar o tronco Software através da primeira folha desse tronco.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout afeta os rótulos pai do Treemap; Sunburst usa segmentos de anel.
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

As células de categoria e as células de valor usam a mesma linha da planilha, de modo que suas posições nas coleções permanecem alinhadas. Quando você trabalha com um gráfico existente em vez de criar um novo, inspecione primeiro as linhas de categoria e armazene referências nomeadas aos pontos de dados e níveis que pretende formatar.

## **Comportamento e considerações práticas**

### **Diferenças entre Treemap e Sunburst**

- Um Treemap usa área para comunicar valor e retângulos aninhados para comunicar hierarquia. O método [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) controla como os rótulos pai aparecem nesse tipo de gráfico.
- Um Sunburst usa ângulo para comunicar valor e profundidade dos anéis para comunicar hierarquia. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) não controla os rótulos dos anéis.
- Ambos os tipos de gráfico utilizam os mesmos níveis de agrupamento de categoria e a mesma ordem folha‑para‑pai retornada por [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/), portanto o código de construção de dados e de formatação de níveis pode ser compartilhado.
- Valores dos pais são calculados a partir de suas folhas descendentes. Não adicione pontos numéricos separados para ramos ou troncos.

### **Ordenação e ordem dos segmentos**

O mecanismo de layout do gráfico determina a posição final dos retângulos e dos segmentos de anel. Agrupe linhas de categoria relacionadas antes de adicioná‑las, mas não dependa de uma posição de retângulo ou ângulo inicial específicos. Se a sequência tiver significado, inclua‑a nos rótulos ou use um tipo de gráfico com eixo de categoria explícito.

### **Tema e cores fixas**

Níveis de gráfico não formatados herdam cores do tema da apresentação. O exemplo usa preenchimentos RGB explícitos para saída previsível. Se o gráfico precisar seguir alterações de tema, use cores de esquema em vez de valores RGB fixos e evite sobrescrever todos os níveis. Também verifique o contraste dos rótulos após mudar o preenchimento de um ramo ou tronco.

### **Rótulos e espaço disponível**

O PowerPoint pode ocultar ou truncar rótulos quando um segmento é muito pequeno. Aumentar o tamanho do gráfico, abreviar nomes de categoria ou exibir menos campos de rótulo costuma gerar um resultado mais claro. Um rótulo pode combinar o nome da categoria, o nome da série e o valor através de [IDataLabelFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/idatalabelformat/), porém habilitar todos os campos frequentemente torna gráficos hierárquicos difíceis de ler.

### **Exportação e renderização**

Salvar em PPTX mantém o gráfico editável. Quando o Aspose.Slides renderiza a apresentação para PDF ou imagem, os preenchimentos e configurações de rótulo suportados são renderizados com o gráfico. Substituição de fontes e pequenas diferenças no espaço de layout disponível podem alterar quebras de linha ou a visibilidade de rótulos, portanto instale as fontes necessárias e verifique os principais alvos de exportação.

## **FAQ**

**Por que alterar um nível pai afeta várias folhas?**

Um ramo ou tronco é um segmento visual compartilhado. Seu [IChartDataPointLevel](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatapointlevel/) pode ser alcançado através de uma folha descendente, porém a formatação pertence ao segmento pai compartilhado, não apenas àquela folha.

**Por que um rótulo de dados está ausente?**

Primeiro habilite os campos necessários no objeto [IDataLabelFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/idatalabelformat/) do rótulo. Em seguida, verifique se o segmento possui espaço suficiente. Layout de rótulo pai do Treemap, dimensões do gráfico, comprimento do rótulo, tamanho da fonte e número de campos habilitados afetam se um rótulo pode ser exibido.

**Posso definir a ordem exata ou as coordenadas dos segmentos?**

É possível controlar a ordem das linhas de origem e manter cada grupo contíguo, mas não é possível atribuir retângulos de Treemap ou ângulos de Sunburst exatos. O mecanismo de layout do gráfico os calcula a partir da hierarquia, dos valores e do espaço disponível.

**Por que as cores mudam após a mudança do tema da apresentação?**

Preenchimentos baseados em tema são projetados para seguir a paleta da apresentação. Aplique cores RGB explícitas aos níveis que precisam permanecer fixos ou mantenha cores de esquema quando a adaptação a um novo tema for preferida.

**A formatação personalizada será preservada em exportações para PDF e imagem?**

Sim, preenchimentos de gráfico e configurações de rótulo suportados são incluídos durante a renderização. Para resultados consistentes entre sistemas, disponibilize as fontes necessárias e teste o tamanho final da exportação, pois o ajuste de rótulo depende do layout.

## **Veja também**

- [Create Treemap charts](/slides/pt/cpp/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/pt/cpp/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/pt/cpp/export-chart/)
- [Manage presentation themes](/slides/pt/cpp/presentation-theme/)