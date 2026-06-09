---
title: "Formatar gráficos de apresentação em C++"
linktitle: "Formatação de Gráficos"
type: docs
weight: 60
url: /pt/cpp/chart-formatting/
keywords:
- formatar gráfico
- formatação de gráfico
- entidade de gráfico
- propriedades do gráfico
- configurações do gráfico
- opções do gráfico
- propriedades de fonte
- borda arredondada
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a formatar gráficos no Aspose.Slides para C++ e eleve sua apresentação PowerPoint com um estilo profissional e atraente."
---
## **Visão geral**

Este artigo explica como formatar gráficos em apresentações do PowerPoint usando Aspose.Slides. Ele mostra como personalizar elementos chave do gráfico, como eixos, linhas de grade, títulos, legendas, a área de plotagem e preenchimentos de parede, para melhorar a aparência e a legibilidade dos dados do gráfico.

Também demonstra como definir propriedades de fonte para o texto do gráfico, aplicar formatos numéricos predefinidos e personalizados aos dados do gráfico e habilitar cantos arredondados para a área do gráfico. Juntos, esses exemplos mostram como controlar tanto o estilo visual quanto a apresentação dos dados dos gráficos em uma apresentação.

## **Formatar entidades do gráfico**
Aspose.Slides for C++ permite que os desenvolvedores adicionem gráficos personalizados aos slides do zero. Este artigo explica como formatar diferentes entidades de gráfico, incluindo o eixo de categoria e o eixo de valores.

Aspose.Slides for C++ fornece uma API simples para gerenciar diferentes entidades de gráfico e formatá‑las usando valores personalizados:

1. Crie uma instância da **Presentation** class.
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão junto com qualquer tipo desejado (neste exemplo usaremos ChartType.LineWithMarkers).
1. Acesse o eixo de Valores do gráfico e defina as seguintes propriedades:
   1. Definir **Line format** para linhas de grade principais do eixo de Valores
   1. Definir **Line format** para linhas de grade secundárias do eixo de Valores
   1. Definir **Number Format** para o eixo de Valores
   1. Definir **Min, Max, Major and Minor units** para o eixo de Valores
   1. Definir **Text Properties** para os dados do eixo de Valores
   1. Definir **Title** para o eixo de Valores
   1. Definir **Line Format** para o eixo de Valores
1. Acesse o eixo de Categoria do gráfico e defina as seguintes propriedades:
   1. Definir **Line format** para linhas de grade principais do eixo de Categoria
   1. Definir **Line format** para linhas de grade secundárias do eixo de Categoria
   1. Definir **Text Properties** para os dados do eixo de Categoria
   1. Definir **Title** para o eixo de Categoria
   1. Definir **Label Positioning** para o eixo de Categoria
   1. Definir **Rotation Angle** para os rótulos do eixo de Categoria
1. Acesse a legenda do gráfico e defina as **Text Properties** para ela
1. Exibir legendas do gráfico sem sobrepor o gráfico
1. Acesse o **Secondary Value Axis** do gráfico e defina as seguintes propriedades:
   1. Habilitar o **Value Axis** secundário
   1. Definir **Line Format** para o eixo de Valores secundário
   1. Definir **Number Format** para o eixo de Valores secundário
   1. Definir **Min, Max, Major and Minor units** para o eixo de Valores secundário
1. Agora plote a primeira série de gráfico no eixo de Valores secundário
1. Defina a parede de fundo do gráfico para cor de preenchimento
1. Defina a cor de preenchimento da área de plotagem do gráfico
1. Grave a apresentação modificada em um arquivo PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Definir propriedades de fonte para um gráfico**
Aspose.Slides for C++ oferece suporte para definir as propriedades relacionadas à fonte do gráfico. Siga os passos abaixo para definir as propriedades de fonte para o gráfico.

- Instanciar o objeto da classe Presentation.
- Adicionar um gráfico ao slide.
- Definir a altura da fonte.
- Salvar a apresentação modificada.

A seguir, um exemplo de amostra.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Definir propriedades de fonte para a tabela de dados do gráfico**
Aspose.Slides for C++ oferece suporte para alterar a cor das categorias em uma série de cores.

1. Instanciar o objeto da classe Presentation.
1. Adicionar um gráfico ao slide.
1. Definir a tabela do gráfico.
1. Definir a altura da fonte.
1. Salvar a apresentação modificada.

A seguir, um exemplo de amostra.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Definir bordas arredondadas para a área do gráfico**
Aspose.Slides for C++ oferece suporte para definir a área do gráfico. As propriedades **IChart.HasRoundedCorners** e **Chart.HasRoundedCorners** foram adicionadas ao Aspose.Slides.

1. Instanciar o objeto da classe Presentation.
1. Adicionar um gráfico ao slide.
1. Definir o tipo de preenchimento e a cor de preenchimento do gráfico
1. Definir a propriedade de canto arredondado como True.
1. Salvar a apresentação modificada.

A seguir, um exemplo de amostra.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Definir o formato numérico**
Aspose.Slides for C++ oferece uma API simples para gerenciar o formato de dados do gráfico:

1. Crie uma instância da [Apresentação](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) class.
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão junto com qualquer tipo desejado (este exemplo usa **ChartType.ClusteredColumn**).
1. Defina o formato numérico predefinido a partir dos valores predefinidos possíveis.
1. Percorra cada célula de dados do gráfico em todas as séries e defina o formato numérico dos dados do gráfico.
1. Salve a apresentação.
1. Defina o formato numérico personalizado.
1. Percorra as células de dados do gráfico em todas as séries e defina um formato numérico diferente para os dados.
1. Salve a apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Os possíveis valores de formato numérico predefinidos, juntamente com seu índice e que podem ser usados, são apresentados abaixo:**|
| :- | :- |
|**0**|Geral|
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|
|||
| :- | :- |

## **FAQ**

**Posso definir preenchimentos semitransparentes para colunas/áreas mantendo a borda opaca?**

Sim. A transparência do preenchimento e o contorno são configurados separadamente. Isso é útil para melhorar a legibilidade da grade e dos dados em visualizações densas.

**Como lidar com rótulos de dados quando eles se sobrepõem?**

Reduza o tamanho da fonte, desative componentes de rótulo não essenciais (por exemplo, categorias), ajuste o deslocamento/posição do rótulo, mostre rótulos apenas para pontos selecionados se necessário ou altere o formato para "valor + legenda".

**Posso aplicar preenchimentos de gradiente ou padrão às séries?**

Sim. Preenchimentos sólidos e gradientes/padrões geralmente estão disponíveis. Na prática, use gradientes com moderação e evite combinações que reduzam o contraste com a grade e o texto.