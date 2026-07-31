---
title: Personalizar Gráficos 3D em Apresentações Usando C++
linktitle: Gráfico 3D
type: docs
url: /pt/cpp/3d-chart/
keywords:
- gráfico 3D
- rotação
- profundidade
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a criar e personalizar gráficos 3D no Aspose.Slides para C++, com suporte a arquivos PPT e PPTX — melhore suas apresentações hoje."
---
## **Visão geral**

Este artigo explica como personalizar um gráfico 3D no Aspose.Slides configurando as definições `Rotation3D` como `RotationX`, `RotationY`, `DepthPercents` e `RightAngleAxes`. Ele demonstra a criação de uma apresentação, a adição de um gráfico 3D com dados padrão, a aplicação das configurações de visualização 3D necessárias e a gravação da apresentação modificada como um arquivo PPTX.

## **Definir as propriedades RotationX, RotationY e DepthPercents de um Gráfico 3D**
O Aspose.Slides para C++ fornece uma API simples para definir essas propriedades. O artigo a seguir ajudará você a definir diferentes propriedades como rotação em X,Y, **DepthPercents** etc. O código de exemplo aplica a configuração das propriedades mencionadas acima.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Adicione um gráfico com dados padrão.
4. Defina as propriedades Rotation3D.
5. Grave a apresentação modificada em um arquivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Quais tipos de gráfico suportam o modo 3D no Aspose.Slides?**

O Aspose.Slides oferece variantes 3D de gráficos de colunas, incluindo Column 3D, Clustered Column 3D, Stacked Column 3D e 100% Stacked Column 3D, além de tipos 3D relacionados expostos por meio da enumeração [ChartType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/charttype/). Para obter a lista exata e atualizada, consulte os membros da enumeração [ChartType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/charttype/) na referência da API da sua versão instalada.

**Posso obter uma imagem raster de um gráfico 3D para um relatório ou para a web?**

Sim. Você pode exportar um gráfico para uma imagem por meio da [chart API](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/getimage/) ou [renderizar o slide inteiro](/slides/pt/cpp/convert-powerpoint-to-png/) em formatos como PNG ou JPEG. Isso é útil quando você precisa de uma pré‑visualização pixel‑perfeita ou deseja incorporar o gráfico em documentos, painéis ou páginas da web sem a necessidade do PowerPoint.

**Qual é o desempenho ao criar e renderizar gráficos 3D grandes?**

O desempenho depende do volume de dados e da complexidade visual. Para obter os melhores resultados, mantenha os efeitos 3D ao mínimo, evite texturas pesadas nas paredes e áreas de plotagem, limite a quantidade de pontos de dados por série quando possível e renderize para uma saída com tamanho adequado (resolução e dimensões) que corresponda à exibição ou às necessidades de impressão do destino.