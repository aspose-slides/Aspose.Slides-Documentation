---
title: Gerenciar marcadores de dados de gráfico em apresentações usando С++
linktitle: Marcador de Dados
type: docs
url: /pt/cpp/chart-data-marker/
keywords:
- gráfico
- ponto de dados
- marcador
- opções de marcador
- tamanho do marcador
- tipo de preenchimento
- PowerPoint
- apresentação
- С++
- Aspose.Slides
description: "Aprenda a personalizar marcadores de dados de gráfico no Aspose.Slides para С++, aumentando o impacto das apresentações nos formatos PPT e PPTX com exemplos claros de código С++."
---
## **Visão geral**

Este artigo explica como trabalhar com marcadores de dados de gráfico no Aspose.Slides. Ele mostra como criar um gráfico, acessar uma série e seus pontos de dados, aplicar preenchimentos de imagem aos marcadores no nível do ponto de dados, ajustar o tamanho do marcador e salvar a apresentação atualizada. Também observa que formas padrão de marcadores estão disponíveis por meio da enumeração `MarkerStyleType` e que a aparência dos marcadores é preservada ao exportar gráficos para formatos raster ou SVG.

## **Definir marcadores de gráfico**
Aspose.Slides para C++ fornece uma API simples para definir automaticamente o marcador da série do gráfico. No recurso a seguir, cada série de gráfico receberá automaticamente um símbolo de marcador padrão diferente.

O exemplo de código abaixo mostra como definir automaticamente o marcador da série do gráfico.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Definir opções de marcador de gráfico**
Os marcadores podem ser definidos nos pontos de dados do gráfico dentro de uma série específica. Para definir opções de marcador de gráfico, siga as etapas abaixo:

- Instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
- Criar o gráfico padrão.
- Definir a imagem.
- Selecionar a primeira série do gráfico.
- Adicionar um novo ponto de dados.
- Gravar a apresentação no disco.

No exemplo abaixo, definimos as opções de marcador de gráfico no nível dos pontos de dados.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Definir marcadores de gráfico no nível do ponto de dados da série**
Agora, os marcadores podem ser definidos nos pontos de dados do gráfico dentro de uma série específica. Para definir opções de marcador de gráfico, siga as etapas abaixo:

- Instanciar a classe Presentation.
- Criar o gráfico padrão.
- Definir a imagem.
- Selecionar a primeira série do gráfico.
- Adicionar um novo ponto de dados.
- Gravar a apresentação no disco.

No exemplo abaixo, definimos as opções de marcador de gráfico no nível dos pontos de dados.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instanciar a classe Presentation que representa um arquivo PPTX
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Acessar o primeiro slide
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Adicionar gráfico com dados padrão
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Definir o índice da planilha de dados do gráfico
int defaultWorksheetIndex = 0;

// Obter a planilha de dados do gráfico
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Excluir séries e categorias geradas por padrão
chart->get_ChartData()->get_Series()->Clear();

// Agora, adicionando uma nova série
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Obter a imagem
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Adicionar imagem à coleção de imagens da apresentação
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Adicionar novo ponto (1:3) aqui.
SharedPtr<IChartDataPoint> point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

// Changing the chart series marker
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **Aplicar cor aos pontos de dados**
Você pode aplicar cor aos pontos de dados no gráfico usando Aspose.Slides para C++. As classes **[IChartDataPointLevelsManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/)** e **[IChartDataPointLevel](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/ichartdatapointlevel/)** foram adicionadas para acessar as propriedades dos níveis de ponto de dados. Este artigo demonstra como acessar e aplicar cor aos pontos de dados em um gráfico.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**Quais formas de marcador estão disponíveis prontas para uso?**

Formas padrão estão disponíveis (círculo, quadrado, diamante, triângulo etc.); a lista é definida pela enumeração [MarkerStyleType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/markerstyletype/). Se precisar de uma forma não padrão, use um marcador com preenchimento de imagem para emular visuais personalizados.

**Os marcadores são preservados ao exportar um gráfico para uma imagem ou SVG?**

Sim. Ao renderizar gráficos para [formatos raster](/slides/pt/cpp/convert-powerpoint-to-png/) ou salvar [formas como SVG](/slides/pt/cpp/render-a-slide-as-an-svg-image/), os marcadores mantêm sua aparência e configurações, incluindo tamanho, preenchimento e contorno.