---
title: Personalizar Gráficos 3D em Apresentações Usando С++
linktitle: Gráfico 3D
type: docs
url: /pt/cpp/3d-chart/
keywords:
- gráfico 3D
- rotação
- profundidade
- PowerPoint
- apresentação
- С++
- Aspose.Slides
description: "Saiba como criar e personalizar gráficos 3-D no Aspose.Slides para С++, com suporte a arquivos PPT e PPTX — impulsione suas apresentações hoje."
---
## **Visão geral**

Este artigo explica como personalizar um gráfico 3D no Aspose.Slides configurando as configurações `Rotation3D`, como `RotationX`, `RotationY`, `DepthPercents` e `RightAngleAxes`. Ele demonstra como criar uma apresentação, adicionar um gráfico 3D com dados padrão, aplicar as configurações de visualização 3D necessárias e salvar a apresentação modificada como um arquivo PPTX.

## **Definir as Propriedades RotationX, RotationY e DepthPercents de um Gráfico 3D**
Aspose.Slides for C++ fornece uma API simples para definir essas propriedades. O artigo a seguir ajudará você a definir diferentes propriedades, como rotação X, Y, **DepthPercents**, etc. O código de exemplo aplica a configuração das propriedades mencionadas acima.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) .
2. Acesse o primeiro slide.
3. Adicione um gráfico com dados padrão.
4. Defina as propriedades Rotation3D.
5. Grave a apresentação modificada em um arquivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Quais tipos de gráfico suportam modo 3D no Aspose.Slides?**

O Aspose.Slides suporta variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, além dos tipos 3D relacionados expostos através da enumeração [ChartType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/charttype/). Para obter uma lista exata e atualizada, verifique os membros de [ChartType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/charttype/) na referência da API da versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou a web?**

Sim. Você pode exportar um gráfico para uma imagem via a [chart API](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/getimage/) ou [render the entire slide](/slides/pt/cpp/convert-powerpoint-to-png/) para formatos como PNG ou JPEG. Isso é útil quando você precisa de uma pré‑visualização pixel‑perfeita ou deseja incorporar o gráfico em documentos, dashboards ou páginas web sem exigir o PowerPoint.

**Quão performante é a criação e renderização de grandes gráficos 3D?**

O desempenho depende do volume de dados e da complexidade visual. Para obter os melhores resultados, mantenha os efeitos 3D mínimos, evite texturas pesadas nas paredes e áreas de plotagem, limite o número de pontos de dados por série sempre que possível e renderize para uma saída com tamanho adequado (resolução e dimensões) que corresponda ao dispositivo de exibição ou impressão alvo.