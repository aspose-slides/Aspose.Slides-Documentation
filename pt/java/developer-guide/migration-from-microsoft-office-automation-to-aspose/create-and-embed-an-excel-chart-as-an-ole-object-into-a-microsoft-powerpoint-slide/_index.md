---
title: Criar e Incorporar Gráficos do Excel como Objetos OLE usando VSTO e Aspose.Slides para Java
linktitle: Criar e Incorporar Gráficos do Excel como Objetos OLE
type: docs
weight: 60
url: /pt/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- criar gráfico
- incorporar gráfico do Excel
- objeto OLE
- migração
- VSTO
- automação do Office
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Migre da automação do Microsoft Office para Aspose.Slides para Java e incorpore gráficos do Excel como objetos OLE em slides do PowerPoint (PPT, PPTX) em Java."
---
{{% alert color="info" %}} 

 Gráficos são representações visuais dos seus dados e amplamente utilizados em slides de apresentação. Este artigo mostrará o código para criar e incorporar um Gráfico do Excel como um Objeto OLE em um slide do PowerPoint programaticamente usando [VSTO](/slides/pt/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) e [Aspose.Slides for Java](/slides/pt/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Criando e Incorporando um Gráfico do Excel**
Os dois exemplos de código abaixo são longos e detalhados porque a tarefa que descrevem é complexa. Você cria uma pasta de trabalho do Microsoft Excel, cria um gráfico e então cria a apresentação do Microsoft PowerPoint na qual incorporará o gráfico. Objetos OLE contêm links para o documento original, de modo que um usuário que dê duplo clique no arquivo incorporado abrirá o arquivo e seu aplicativo.
### **Exemplo VSTO**
Usando VSTO, as etapas a seguir são realizadas:

1. Crie uma instância do objeto Microsoft Excel ApplicationClass.
1. Crie uma nova pasta de trabalho com uma planilha.
1. Adicione um gráfico à planilha.
1. Salve a pasta de trabalho.
1. Abra a pasta de trabalho do Excel que contém a planilha com os dados do gráfico.
1. Obtenha a coleção ChartObjects da planilha.
1. Obtenha o gráfico a ser copiado.
1. Crie uma apresentação do Microsoft PowerPoint.
1. Adicione um slide em branco à apresentação.
1. Copie o gráfico da planilha do Excel para a área de transferência.
1. Cole o gráfico na apresentação do PowerPoint.
1. Posicione o gráfico no slide.
1. Salve a apresentação.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Exemplo Aspose.Slides for Java**
Usando Aspose.Slides para .NET, as etapas a seguir são realizadas:

1. Crie uma pasta de trabalho usando Aspose.Cells para Java.
1. Crie um gráfico do Microsoft Excel.
1. Defina o tamanho OLE do Gráfico do Excel.
1. Obtenha uma imagem do gráfico.
1. Incorpore o gráfico do Excel como um Objeto OLE dentro da apresentação PPTX usando Aspose.Slides para Java.
1. Substitua a imagem do objeto alterado pela imagem obtida no passo 3 para lidar com o problema de objeto alterado.
1. Grave a apresentação de saída no disco no formato PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}