---
title: Criar e Incorporar Gráficos do Excel como Objetos OLE Usando VSTO e Aspose.Slides para Java
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
- automação Office
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Migrar da automação Microsoft Office para Aspose.Slides para Java e incorporar gráficos do Excel como objetos OLE em slides do PowerPoint (PPT, PPTX) em Java."
---
{{% alert color="primary" %}} 

 Gráficos são representações visuais dos seus dados e são amplamente usados em apresentações. Este artigo mostrará o código para criar e incorporar um Gráfico do Excel como um Objeto OLE em um slide do PowerPoint programaticamente usando [VSTO](/slides/pt/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) e [Aspose.Slides for Java](/slides/pt/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Criando e Incorporando um Gráfico do Excel**
Os dois exemplos de código abaixo são extensos e detalhados porque a tarefa que descrevem é complexa. Você cria uma pasta de trabalho do Microsoft Excel, cria um gráfico e, em seguida, cria a apresentação do Microsoft PowerPoint na qual incorporará o gráfico. Objetos OLE contêm links para o documento original, de modo que um usuário que clicar duas vezes no arquivo incorporado abrirá o arquivo e seu aplicativo.
### **Exemplo VSTO**
Usando VSTO, os passos a seguir são realizados:

1. Criar uma instância do objeto Microsoft Excel ApplicationClass.
1. Criar uma nova pasta de trabalho com uma planilha.
1. Adicionar gráfico à planilha.
1. Salvar a pasta de trabalho.
1. Abrir a pasta de trabalho do Excel que contém a planilha com os dados do gráfico.
1. Obter a coleção ChartObjects para a planilha.
1. Obter o gráfico a ser copiado.
1. Criar uma apresentação do Microsoft PowerPoint.
1. Adicionar um slide em branco à apresentação.
1. Copiar o gráfico da planilha do Excel para a área de transferência.
1. Colar o gráfico na apresentação do PowerPoint.
1. Posicionar o gráfico no slide.
1. Salvar a apresentação.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Exemplo Aspose.Slides for Java**
Usando Aspose.Slides for .NET, os passos a seguir são realizados:

1. Criar uma pasta de trabalho usando Aspose.Cells for Java.
1. Criar um gráfico do Microsoft Excel.
1. Definir o tamanho OLE do Gráfico do Excel.
1. Obter uma imagem do gráfico.
1. Incorporar o gráfico do Excel como um Objeto OLE dentro da apresentação PPTX usando Aspose.Slides for Java.
1. Substituir a imagem do objeto alterado pela imagem obtida na etapa 3 para contornar o problema de objeto alterado.
1. Gravar a apresentação de saída no disco no formato PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}