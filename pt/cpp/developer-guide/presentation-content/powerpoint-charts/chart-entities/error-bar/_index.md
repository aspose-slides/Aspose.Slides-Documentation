---
title: Personalizar Barras de Erro em Gráficos de Apresentação usando C++
linktitle: Barra de Erro
type: docs
url: /pt/cpp/error-bar/
keywords:
- barra de erro
- valor personalizado
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda como adicionar e personalizar barras de erro em gráficos com Aspose.Slides para C++ — otimize visualizações de dados em apresentações PowerPoint."
---
## **Visão geral**

Este artigo explica como trabalhar com barras de erro em gráficos de apresentação usando Aspose.Slides. Ele mostra como adicionar barras de erro a uma série de gráfico, configurar as definições de barras de erro X e Y e aplicar diferentes tipos de valor, como fixo, percentual e valores personalizados.

Também demonstra como atribuir valores personalizados de barra de erro para pontos de dados individuais em uma série usando a coleção de pontos de dados correspondente. Além disso, o artigo inclui notas breves sobre como as barras de erro se comportam durante a exportação, sua compatibilidade com marcadores e rótulos de dados, e onde encontrar as classes e enums de referência da API relacionados.

## **Adicionar barras de erro**
O Aspose.Slides for C++ fornece uma API simples para gerenciar valores de barras de erro. O código de exemplo se aplica ao usar um tipo de valor personalizado. Para especificar um valor, use a propriedade **ErrorBarCustomValues** de um ponto de dados específico na coleção **DataPoints** da série:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Adicione um gráfico de bolhas no slide desejado.
1. Acesse a primeira série de gráfico e defina o formato da barra de erro X.
1. Acesse a primeira série de gráfico e defina o formato da barra de erro Y.
1. Definindo os valores e o formato das barras.
1. Grave a apresentação modificada em um arquivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Adicionar barras de erro personalizadas**
O Aspose.Slides for C++ fornece uma API simples para gerenciar valores personalizados de barras de erro. O código de exemplo se aplica quando a propriedade **IErrorBarsFormat.ValueType** é igual a **Custom**. Para especificar um valor, use a propriedade **ErrorBarCustomValues** de um ponto de dados específico na coleção **DataPoints** da série:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Adicione um gráfico de bolhas no slide desejado.
1. Acesse a primeira série de gráfico e defina o formato da barra de erro X.
1. Acesse a primeira série de gráfico e defina o formato da barra de erro Y.
1. Acesse os pontos de dados individuais da série de gráfico e defina os valores da barra de erro para um ponto de dados individual da série.
1. Definindo os valores e o formato das barras.
1. Grave a apresentação modificada em um arquivo PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **Perguntas frequentes**

**O que acontece com as barras de erro ao exportar uma apresentação para PDF ou imagens?**

Elas são renderizadas como parte do gráfico e preservadas durante a conversão juntamente com o restante da formatação do gráfico, assumindo uma versão ou renderizador compatível.

**As barras de erro podem ser combinadas com marcadores e rótulos de dados?**

Sim. As barras de erro são um elemento separado e são compatíveis com marcadores e rótulos de dados; se os elementos se sobreporem, pode ser necessário ajustar a formatação.

**Onde posso encontrar a lista de propriedades e enums para trabalhar com barras de erro na API?**

Na referência da API: a classe [ErrorBarsFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/errorbarsformat/) e os enums relacionados [ErrorBarType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/errorbartype/) e [ErrorBarValueType](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/errorbarvaluetype/).