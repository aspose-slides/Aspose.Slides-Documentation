---
title: Gerenciar Pastas de Trabalho de Gráficos em Apresentações Usando PHP
linktitle: Pasta de Trabalho de Gráfico
type: docs
weight: 70
url: /pt/php-java/chart-workbook/
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
  - PHP
  - Aspose.Slides
description: "Descubra Aspose.Slides para PHP via Java: gerencie facilmente pastas de trabalho de gráficos em formatos PowerPoint e OpenDocument para simplificar os dados da sua apresentação."
---
## **Visão Geral**

Este artigo explica como trabalhar com pastas de trabalho de gráficos no Aspose.Slides. Ele mostra como ler e gravar dados de gráficos por meio de streams de pasta de trabalho, usar células da pasta de trabalho como rótulos de dados do gráfico, acessar coleções de planilhas e especificar o tipo de fonte de dados para os valores do gráfico.

Também aborda o trabalho com pastas de trabalho externas como fontes de dados de gráficos. Os exemplos demonstram como criar e atribuir uma pasta de trabalho externa, recuperar o caminho de uma pasta de trabalho externa vinculada a um gráfico e editar os dados do gráfico quando a pasta de trabalho está disponível.

## **Ler e Gravar Dados de Gráficos a partir de uma Pasta de Trabalho**
Aspose.Slides fornece os métodos [readWorkbookStream](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/#readWorkbookStream) e [writeWorkbookStream](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/#writeWorkbookStream) que permitem ler e gravar pastas de trabalho de dados de gráficos (contendo dados de gráficos editados com Aspose.Cells). **Note** que os dados do gráfico precisam estar organizados da mesma forma ou ter uma estrutura semelhante à fonte.

Este código PHP demonstra uma operação de exemplo:

```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Validar o Layout do Gráfico após a Modificação da Pasta de Trabalho**

Ao substituir uma pasta de trabalho incorporada por uma modificada, o gráfico mantém suas coleções originais de séries e categorias. Essa incompatibilidade pode fazer com que [Chart::validateChartLayout](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/validatechartlayout/) falhe com um erro de índice fora do intervalo. Limpe as séries e categorias existentes antes de gravar a pasta de trabalho atualizada de volta no gráfico.

```php
// Após modificar o stream da pasta de trabalho (por exemplo, usando Aspose.Cells)
$updatedWorkbook = $chartData->readWorkbookStream();

// Limpar referências de dados existentes.
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

Limpar as coleções garante que a estrutura dos dados do gráfico seja consistente com a nova pasta de trabalho, permitindo que `validateChartLayout` seja concluído sem erros.

## **Definir uma Célula de Pasta de Trabalho como Rótulo de Dados do Gráfico**

1. Crie uma instância da classe [Presentation](https://apireference.aspose.com/slides/pt/php-java/aspose.slides/presentation) .
2. Obtenha a referência de um slide por seu índice.
3. Adicione um gráfico do tipo Bubble com alguns dados.
4. Acesse as séries do gráfico.
5. Defina a célula da pasta de trabalho como um rótulo de dados.
6. Salve a apresentação.

Este código PHP mostra como definir uma célula de pasta de trabalho como rótulo de dados do gráfico:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # Instancia uma classe de apresentação que representa um arquivo de apresentação
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gerenciar Planilhas**

Este código PHP demonstra uma operação onde o método [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdataworkbook/#getWorksheets) é usado para acessar uma coleção de planilhas:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Especificar o Tipo de Fonte de Dados**

Este código PHP mostra como especificar um tipo para uma fonte de dados:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Detectar Formatos de Pasta de Trabalho Incorporados Não Suportados**

Aspose.Slides não suporta o formato de pasta de trabalho binária do Excel (.xlsb) que pode ser incorporado em alguns gráficos. Você pode usar o método `getEmbeddedWorkbookType` em [ChartData](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/) junto com a enumeração [WorkbookType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/workbooktype/) para detectar formatos não suportados e pular esses gráficos.

```php
$presentation = new Presentation("sample.pptx");
try {
  $slide = $presentation->getSlides()->get_Item(0);
  $shapes = $slide->getShapes();

  for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
    $shape = $shapes->get_Item($shapeIndex);

    if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
      continue;
    }

    $chart = $shape;
    $chartData = $chart->getChartData();

    if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook &&
        java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro) {
      # A pasta de trabalho incorporada está no formato .xlsb, que não é suportado.
      continue;
    }

    # Leia ou modifique os dados da pasta de trabalho do gráfico aqui.
  }
} finally {
  $presentation->dispose();
}
```

## **Pasta de Trabalho Externa**

Aspose.Slides suporta pastas de trabalho externas como fonte de dados para gráficos.

### **Criar uma Pasta de Trabalho Externa**

Usando os métodos **`readWorkbookStream`** e **`setExternalWorkbook`**, você pode criar uma pasta de trabalho externa do zero ou tornar uma pasta de trabalho interna externa.

Este código PHP demonstra o processo de criação da pasta de trabalho externa:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Definir uma Pasta de Trabalho Externa**

Usando o método **`setExternalWorkbook`**, você pode atribuir uma pasta de trabalho externa a um gráfico como sua fonte de dados. Esse método também pode ser usado para atualizar o caminho da pasta de trabalho externa (se esta última tiver sido movida).

Embora você não possa editar os dados em pastas de trabalho armazenadas em locais remotos ou recursos, ainda pode usá‑las como fonte de dados externa. Se for fornecido um caminho relativo para uma pasta de trabalho externa, ele será convertido automaticamente para um caminho completo.

Este código PHP mostra como definir uma pasta de trabalho externa:

```php
  # Cria uma instância da classe Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

O parâmetro `ChartData` (baixo do método `setExternalWorkbook`) é usado para especificar se uma pasta de trabalho Excel será carregada ou não.

* Quando o valor de `ChartData` é definido como `false`, apenas o caminho da pasta de trabalho é atualizado – os dados do gráfico não serão carregados nem atualizados a partir da pasta de trabalho de destino. Use essa configuração quando a pasta de trabalho de destino não existir ou estiver indisponível.  
* Quando o valor de `ChartData` é definido como `true`, os dados do gráfico são atualizados a partir da pasta de trabalho de destino.

```php
  # Cria uma instância da classe Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Obter o Caminho da Pasta de Trabalho da Fonte de Dados Externa de um Gráfico**

1. Crie uma instância da classe [Presentation](https://apireference.aspose.com/slides/pt/php-java/aspose.slides/presentation) .
2. Obtenha a referência de um slide por seu índice.
3. Crie um objeto para a forma do gráfico.
4. Crie um objeto para o tipo de fonte (`ChartDataSourceType`) que representa a fonte de dados do gráfico.
5. Especifique a condição relevante com base no tipo de fonte que seja o mesmo que o tipo de fonte da pasta de trabalho externa.

Este código PHP demonstra a operação:

```php
  # Cria uma instância da classe Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # Salva a apresentação
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Editar Dados do Gráfico**

Você pode editar os dados em pastas de trabalho externas da mesma forma que altera o conteúdo de pastas de trabalho internas. Quando uma pasta de trabalho externa não pode ser carregada, uma exceção é lançada.

Este código PHP é uma implementação do processo descrito:

```php
  # Cria uma instância da classe Presentation
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Recuperar uma Pasta de Trabalho do Cache do Gráfico**

Se um gráfico usa uma pasta de trabalho externa que está ausente ou indisponível, Aspose.Slides pode recriar a pasta de trabalho do gráfico a partir dos dados armazenados em cache na apresentação. Crie [LoadOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/), configure-o com [SpreadsheetOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/spreadsheetoptions/), e chame [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/pt/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) com `true` antes de abrir a apresentação.

O exemplo PHP a seguir abre uma apresentação cujo gráfico faz referência a uma pasta de trabalho externa indisponível e acessa os dados recuperados por meio de [Chart::getChartData](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chart/#getChartData) e [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/#getChartDataWorkbook):

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # Leia ou modifique os dados da pasta de trabalho recuperada aqui.
} finally {
    $presentation->dispose();
}
```

Se a pasta de trabalho externa estiver indisponível e a recuperação estiver desativada, Aspose.Slides lança uma exceção. Habilite a recuperação apenas quando o uso dos dados de gráfico em cache for uma alternativa aceitável, pois o cache pode não conter alterações feitas na pasta de trabalho externa após a última atualização da apresentação.

## **FAQ**

**Posso determinar se um gráfico específico está vinculado a uma pasta de trabalho externa ou incorporada?**  
Sim. Um gráfico possui um [tipo de fonte de dados](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/getdatasourcetype/) e um [caminho para uma pasta de trabalho externa](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/getexternalworkbookpath/); se a fonte for uma pasta de trabalho externa, você pode ler o caminho completo para garantir que um arquivo externo está sendo usado.

**Os caminhos relativos para pastas de trabalho externas são suportados, e como eles são armazenados?**  
Sim. Se você especificar um caminho relativo, ele será convertido automaticamente para um caminho absoluto. Isso facilita a portabilidade do projeto; entretanto, o caminho absoluto será armazenado no arquivo PPTX.

**Posso usar pastas de trabalho localizadas em recursos ou compartilhamentos de rede?**  
Sim, essas pastas de trabalho podem ser usadas como fonte de dados externa. Porém, a edição direta de pastas de trabalho remotas a partir do Aspose.Slides não é suportada – elas podem ser usadas apenas como fonte.

**O Aspose.Slides sobrescreve o XLSX externo ao salvar a apresentação?**  
Não. A apresentação armazena um [link para o arquivo externo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartdata/getexternalworkbookpath/) e o usa para leitura dos dados. O arquivo externo em si não é modificado ao salvar a apresentação.

**O que fazer se o arquivo externo estiver protegido por senha?**  
Aspose.Slides não aceita senha ao criar o vínculo. Uma abordagem comum é remover a proteção previamente ou preparar uma cópia descriptografada (por exemplo, usando [Aspose.Cells](/cells/php-java/)) e vincular a essa cópia.

**Vários gráficos podem referenciar a mesma pasta de trabalho externa?**  
Sim. Cada gráfico armazena seu próprio link. Se todos apontarem para o mesmo arquivo, a atualização desse arquivo será refletida em cada gráfico na próxima vez que os dados forem carregados.