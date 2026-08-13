---
title: Criar Gráficos Usando VSTO e Aspose.Slides para Java
linktitle: Criar Gráfico
type: docs
weight: 70
url: /pt/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- criar gráfico
- migração
- VSTO
- automação de Office
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda como automatizar a criação de gráficos do PowerPoint em Java. Este guia passo a passo mostra por que o Aspose.Slides for Java é uma alternativa mais rápida e poderosa ao Microsoft.Office.Interop."
---
{{% alert color="info" %}} 
Gráficos são representações visuais de dados que são amplamente usados em apresentações. Este artigo mostra o código para criar um gráfico no Microsoft PowerPoint programaticamente usando [VSTO](/slides/pt/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) e [Aspose.Slides for Java](/slides/pt/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).
{{% /alert %}} 
## **Criando um Gráfico**
Os exemplos de código abaixo descrevem o processo de adição de um gráfico de **coluna agrupada 3D** simples usando VSTO. Você cria uma instância de apresentação, adiciona um gráfico padrão a ela. Em seguida, usa uma pasta de trabalho do Microsoft Excel para acessar e modificar os dados do gráfico, além de definir as propriedades do gráfico. Por fim, salva a apresentação.
### **Exemplo VSTO**
Usando VSTO, os passos a seguir são realizados:

1. Crie uma instância de uma apresentação do Microsoft PowerPoint.
1. Adicione um slide em branco à apresentação.
1. Adicione um gráfico de **coluna agrupada 3D** e acesse-o.
1. Crie uma nova instância de pasta de trabalho do Microsoft Excel e carregue os dados do gráfico.
1. Acesse a planilha de dados do gráfico usando a instância da pasta de trabalho do Microsoft Excel.
1. Defina o intervalo do gráfico na planilha e remova as séries 2 e 3 do gráfico.
1. Modifique os dados de categorias do gráfico na planilha de dados.
1. Modifique os dados da série 1 do gráfico na planilha de dados.
1. Agora, acesse o título do gráfico e defina as propriedades relacionadas à fonte.
1. Acesse o eixo de valores do gráfico e defina a unidade principal, unidades menores, valor máximo e valores mínimos.
1. Acesse o eixo de profundidade ou de séries do gráfico e remova-o, pois neste exemplo apenas uma série é usada.
1. Agora, defina os ângulos de rotação do gráfico nas direções X e Y.
1. Salve a apresentação.
1. Feche as instâncias do Microsoft Excel e do PowerPoint.

**A apresentação resultante, criada com VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Exemplo Aspose.Slides for Java**
Usando Aspose.Slides for Java, os passos a seguir são realizados:

1. Crie uma instância de uma apresentação do Microsoft PowerPoint.
1. Adicione um slide em branco à apresentação.
1. Adicione um gráfico de **coluna agrupada 3D** e acesse-o.
1. Acesse a planilha de dados do gráfico usando uma instância da pasta de trabalho do Microsoft Excel.
1. Remova as séries não utilizadas 2 e 3.
1. Acesse as categorias do gráfico e modifique os rótulos.
1. Acesse a série 1 e modifique os valores da série.
1. Agora, acesse o título do gráfico e defina as propriedades da fonte.
1. Acesse o eixo de valores do gráfico e defina a unidade principal, unidades menores, valor máximo e valores mínimos.
1. Agora, defina os ângulos de rotação do gráfico nas direções X e Y.
1. Salve a apresentação no formato PPTX.

**A apresentação resultante, criada com Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

### Posso criar outros tipos de gráficos, como gráficos de pizza, linha ou barra, com Aspose.Slides?
Sim. Aspose.Slides suporta uma ampla variedade de [tipos de gráficos](/slides/pt/java/create-chart/), incluindo gráficos de pizza, gráficos de linha, gráficos de barra, diagramas de dispersão, gráficos de bolhas e muito mais. Você pode especificar o tipo de gráfico desejado usando a classe [ChartType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/charttype/) ao adicionar um gráfico.

### Posso aplicar estilos ou temas personalizados ao gráfico?
Sim. Você pode personalizar totalmente a aparência do gráfico, incluindo cores, fontes, preenchimentos, contornos, linhas de grade e layout. Contudo, aplicar temas do Office exatamente como visto no PowerPoint requer a definição manual de estilos individuais.

### Posso exportar o gráfico como uma imagem separadamente do slide?
Sim, Aspose.Slides permite exportar qualquer forma — incluindo gráficos — como uma imagem separada (por exemplo, PNG, JPEG) usando o método `getImage` na [shape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/) do gráfico.