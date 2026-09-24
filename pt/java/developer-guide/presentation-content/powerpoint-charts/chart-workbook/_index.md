---
title: Gerenciar Pastas de Trabalho de Gráficos em Apresentações Usando Java
linktitle: Pasta de Trabalho de Gráfico
type: docs
weight: 70
url: /pt/java/chart-workbook/
keywords:
- pasta de trabalho de gráfico
- dados de gráfico
- célula de pasta de trabalho
- rótulo de dados
- planilha
- fonte de dados
- pasta de trabalho externa
- dados externos
- cache de gráfico
- recuperação de pasta de trabalho
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Descubra Aspose.Slides para Java: gerencie facilmente pastas de trabalho de gráficos em formatos PowerPoint e OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão geral**

Este artigo explica como trabalhar com pastas de trabalho de gráficos no Aspose.Slides. Ele mostra como ler e gravar dados de gráficos através de streams de pastas de trabalho, usar células de pasta de trabalho como rótulos de dados de gráfico, acessar coleções de planilhas e especificar o tipo de origem de dados para os valores do gráfico.

Ele também aborda o trabalho com pastas de trabalho externas como fontes de dados de gráficos. Os exemplos demonstram como criar e atribuir uma pasta de trabalho externa, recuperar o caminho de uma pasta de trabalho externa vinculada a um gráfico e editar os dados do gráfico quando a pasta de trabalho está disponível.

Para células de pasta de trabalho que representam dados ausentes, veja [Control the Display of Empty Cells](/slides/pt/java/chart-series/) para a diferença entre uma célula vazia e zero, e uma comparação em gráfico de linhas dos modos de exibição disponíveis.

## **Ler e Gravar Dados de Gráfico a partir de uma Pasta de Trabalho**

Aspose.Slides fornece os métodos [ReadWorkbookStream](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartData#readWorkbookStream--) e [WriteWorkbookStream](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) que permitem ler e gravar pastas de trabalho de dados de gráfico (contendo dados de gráfico editados com Aspose.Cells). **Nota** que os dados do gráfico devem ser organizados da mesma forma ou ter uma estrutura semelhante à origem.

Este código Java demonstra uma operação de exemplo:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Validar Layout do Gráfico Após Modificação da Pasta de Trabalho**

Quando você substitui uma pasta de trabalho embutida por uma modificada, o gráfico mantém suas coleções originais de séries e categorias. Essa inconsistência pode fazer com que [IChart.validateChartLayout](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichart/#validateChartLayout--) lance uma `ArgumentOutOfRangeException` (parâmetro: index). Para evitar a exceção, limpe as séries e categorias existentes **antes** de gravar a pasta de trabalho atualizada de volta no gráfico.

```java
// Após modificar o stream da pasta de trabalho (por exemplo, usando Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Limpar referências de dados existentes.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Limpar as coleções garante que a estrutura de dados do gráfico esteja alinhada com a nova pasta de trabalho, permitindo que `validateChartLayout` seja concluído sem erros.

## **Definir uma Célula de Pasta de Trabalho como Rótulo de Dados do Gráfico**

1. Crie uma instância da classe [Presentation](https://apireference.aspose.com/slides/pt/java/com.aspose.slides/presentation).
2. Obtenha a referência de um slide pelo seu índice.
3. Adicione um gráfico de Bolhas com alguns dados.
4. Acesse as séries do gráfico.
5. Defina a célula da pasta de trabalho como um rótulo de dados.
6. Salve a apresentação.

Este código Java mostra como definir uma célula de pasta de trabalho como rótulo de dados do gráfico:

```java
// Instancia uma classe de apresentação que representa um arquivo de apresentação
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gerenciar Planilhas**

Este código Java demonstra uma operação onde o método [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) é usado para acessar uma coleção de planilhas:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Especificar o Tipo de Origem de Dados**

Este código Java mostra como especificar um tipo para uma origem de dados:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Detectar Formatos de Pasta de Trabalho Embutida Não Compatíveis**

Aspose.Slides não suporta o formato de pasta de trabalho binária do Excel (.xlsb) que pode ser embutido em alguns gráficos. Você pode usar o método `getEmbeddedWorkbookType` em [IChartData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IChartData) juntamente com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/WorkbookType) para detectar formatos não compatíveis e ignorar esses gráficos.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // A pasta de trabalho embutida está no formato .xlsb, que não é suportado.
            continue;
        }

        // Leia ou modifique os dados da pasta de trabalho do gráfico aqui.
    }
} finally {
    presentation.dispose();
}
```

## **Pasta de Trabalho Externa**

Aspose.Slides suporta o uso de pastas de trabalho externas como fonte de dados para gráficos.

### **Criar uma Pasta de Trabalho Externa**

Usando os métodos **`readWorkbookStream`** e **`setExternalWorkbook`**, você pode criar uma pasta de trabalho externa do zero ou tornar uma pasta de trabalho interna externa.

Este código Java demonstra o processo de criação da pasta de trabalho externa:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Definir uma Pasta de Trabalho Externa**

Usando o método **`setExternalWorkbook`**, você pode atribuir uma pasta de trabalho externa a um gráfico como sua fonte de dados. Esse método também pode ser usado para atualizar o caminho para a pasta de trabalho externa (se esta tiver sido movida).

Embora você não possa editar os dados em pastas de trabalho armazenadas em locais ou recursos remotos, ainda pode usar essas pastas de trabalho como fonte de dados externa. Se for fornecido um caminho relativo para uma pasta de trabalho externa, ele será convertido automaticamente em um caminho completo.

Este código Java mostra como definir uma pasta de trabalho externa:

```java
import com.aspose.slides.*;

// Cria uma instância da classe Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

O segundo parâmetro (`boolean`) do método `setExternalWorkbook` é usado para especificar se uma pasta de trabalho Excel será carregada ou não. 

* Quando seu valor é definido como `false`, apenas o caminho da pasta de trabalho é atualizado — os dados do gráfico não serão carregados ou atualizados a partir da pasta de trabalho de destino. Você pode usar essa configuração quando a pasta de trabalho de destino não existir ou não estiver disponível. 
* Quando seu valor é definido como `true`, os dados do gráfico são atualizados a partir da pasta de trabalho de destino.

```java
import com.aspose.slides.*;

// Cria uma instância da classe Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obter o Caminho da Pasta de Trabalho da Fonte de Dados Externa de um Gráfico**

1. Crie uma instância da classe [Presentation](https://apireference.aspose.com/slides/pt/java/com.aspose.slides/presentation).
2. Obtenha a referência de um slide pelo seu índice.
3. Crie um objeto para a forma do gráfico.
4. Crie um objeto para o tipo de origem (`ChartDataSourceType`) que representa a fonte de dados do gráfico.
5. Especifique a condição relevante com base no tipo de origem sendo o mesmo que o tipo de fonte de dados da pasta de trabalho externa.

Este código Java demonstra a operação:

```java
import com.aspose.slides.*;

// Cria uma instância da classe Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// Salva a apresentação
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Editar Dados do Gráfico**

Você pode editar os dados em pastas de trabalho externas da mesma forma que altera o conteúdo de pastas de trabalho internas. Quando uma pasta de trabalho externa não pode ser carregada, uma exceção é lançada.

Este código Java é uma implementação do processo descrito:

```java
import com.aspose.slides.*;

// Cria uma instância da classe Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Recuperar uma Pasta de Trabalho do Cache do Gráfico**

Se um gráfico usa uma pasta de trabalho externa que está ausente ou indisponível, Aspose.Slides pode reconstruir a pasta de trabalho do gráfico a partir dos dados armazenados em cache na apresentação. Crie [LoadOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/), configure-o com [SpreadsheetOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/spreadsheetoptions/), e chame [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) com `true` antes de abrir a apresentação.

O exemplo Java a seguir abre uma apresentação cujo gráfico referencia uma pasta de trabalho externa indisponível e acessa os dados recuperados através de [IChart.getChartData](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichart/#getChartData--) e [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Leia ou modifique os dados da pasta de trabalho recuperada aqui.
} finally {
    presentation.dispose();
}
```

Se a pasta de trabalho externa estiver indisponível e a recuperação estiver desativada, Aspose.Slides lança uma exceção. Habilite a recuperação somente quando usar os dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas na pasta de trabalho externa após a última atualização da apresentação.

## **FAQ**

**Posso determinar se um gráfico específico está vinculado a uma pasta de trabalho externa ou embutida?**

Sim. Um gráfico tem um [data source type](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chartdata/#getDataSourceType--) e um [path to an external workbook](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); se a origem for uma pasta de trabalho externa, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Caminhos relativos para pastas de trabalho externas são suportados, e como eles são armazenados?**

Sim. Se você especificar um caminho relativo, ele será convertido automaticamente em um caminho absoluto. Isso é conveniente para portabilidade de projetos; porém, esteja ciente de que a apresentação armazenará o caminho absoluto no arquivo PPTX.

**Posso usar pastas de trabalho localizadas em recursos/compartilhamentos de rede?**

Sim, essas pastas de trabalho podem ser usadas como fonte de dados externa. Contudo, a edição de pastas de trabalho remotas diretamente pelo Aspose.Slides não é suportada — elas podem ser usadas apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**

Não. A apresentação armazena um [link to the external file](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) e o utiliza para leitura de dados. O próprio arquivo externo não é modificado quando a apresentação é salva.

**O que devo fazer se o arquivo externo estiver protegido por senha?**

Aspose.Slides não aceita senha ao criar o vínculo. Uma abordagem comum é remover a proteção antecipadamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](/cells/java/)) e vincular a essa cópia.

**Vários gráficos podem referenciar a mesma pasta de trabalho externa?**

Sim. Cada gráfico armazena seu próprio vínculo. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima vez que os dados forem carregados.