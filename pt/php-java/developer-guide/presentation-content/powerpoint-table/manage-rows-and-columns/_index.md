---
title: Gerenciar Linhas e Colunas em Tabelas do PowerPoint Usando PHP
linktitle: Linhas e Colunas
type: docs
weight: 20
url: /pt/php-java/manage-rows-and-columns/
keywords:
- linha de tabela
- coluna de tabela
- primeira linha
- cabeçalho da tabela
- clonar linha
- clonar coluna
- copiar linha
- copiar coluna
- remover linha
- remover coluna
- formatação de texto da linha
- formatação de texto da coluna
- estilo da tabela
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Gerencie linhas e colunas de tabelas no PowerPoint com Aspose.Slides para PHP via Java e acelere a edição de apresentações e atualizações de dados."
---
## **Introdução**

Para permitir que você gerencie as linhas e colunas de uma tabela em uma apresentação do PowerPoint, o Aspose.Slides fornece a classe [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/table/) e muitos outros tipos.

## **Definir a Primeira Linha como Cabeçalho**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e carregue a apresentação.  
2. Obtenha a referência de um slide por meio do seu índice.  
3. Crie um objeto [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Table) e defina-o como null.  
4. Percorra todos os objetos [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) para encontrar a tabela relevante.  
5. Defina a primeira linha da tabela como seu cabeçalho.  

Este código PHP mostra como definir a primeira linha de uma tabela como seu cabeçalho:

```php
  # Instancia a classe Presentation
  $pres = new Presentation("table.pptx");
  try {
    # Acessa o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Inicializa o TableEx nulo
    $tbl = null;
    # Percorre as formas e define uma referência para a tabela
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Define a primeira linha da tabela como cabeçalho
        $tbl->setFirstRow(true);
      }
    }
    # Salva a apresentação no disco
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Clonar uma Linha ou Coluna da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e carregue a apresentação,  
2. Obtenha a referência de um slide por meio do seu índice.  
3. Defina um array de `columnWidth`.  
4. Defina um array de `rowHeight`.  
5. Adicione um objeto [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Table) ao slide usando o método [addTable](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addtable/).  
6. Clone a linha da tabela.  
7. Clone a coluna da tabela.  
8. Salve a apresentação modificada.  

Este código PHP mostra como clonar a linha ou a coluna de uma tabela do PowerPoint:

```php
  # Instancia a classe Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # Acessa o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Define colunas com larguras e linhas com alturas
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Adiciona uma forma de tabela ao slide
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Adiciona texto à célula linha 1 coluna 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Adiciona texto à célula linha 1 coluna 2
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Clona a Linha 1 no final da tabela
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Adiciona texto à célula linha 2 coluna 1
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Adiciona texto à célula linha 2 coluna 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Clona a Linha 2 como a quarta linha da tabela
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Clona a primeira coluna no final
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Clona a segunda coluna no índice da quarta coluna
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Salva a apresentação no disco
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remover uma Linha ou Coluna de uma Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e carregue a apresentação,  
2. Obtenha a referência de um slide por meio do seu índice.  
3. Defina um array de `columnWidth`.  
4. Defina um array de `rowHeight`.  
5. Adicione um objeto [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Table) ao slide usando o método [addTable](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addtable/).  
6. Remova a linha da tabela.  
7. Remova a coluna da tabela.  
8. Salve a apresentação modificada.  

Este código PHP mostra como remover uma linha ou coluna de uma tabela:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir Formatação de Texto no Nível de Linha da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e carregue a apresentação,  
2. Obtenha a referência de um slide por meio do seu índice.  
3. Acesse o objeto [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Table) relevante a partir do slide.  
4. Defina a altura da fonte das células da primeira linha com [setFontHeight(float value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Defina o alinhamento das células da primeira linha com [setAlignment(int value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setalignment/) e a margem direita com [setMarginRight(float value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. Defina o tipo de texto vertical das células da segunda linha com [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Salve a apresentação modificada.  

Este código PHP demonstra a operação.

```php
  # Cria uma instância da classe Presentation
  $pres = new Presentation();
  try {
    # Vamos supor que a primeira forma no primeiro slide seja uma tabela
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Define a altura da fonte das células da primeira linha
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # Define o alinhamento de texto e a margem direita das células da primeira linha
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # Define o tipo de texto vertical das células da segunda linha
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Salva a apresentação no disco
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir Formatação de Texto no Nível de Coluna da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e carregue a apresentação,  
2. Obtenha a referência de um slide por meio do seu índice.  
3. Acesse o objeto [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Table) relevante a partir do slide.  
4. Defina a altura da fonte das células da primeira coluna com [setFontHeight(float value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Defina o alinhamento das células da primeira coluna com [setAlignment(int value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setalignment/) e a margem direita com [setMarginRight(float value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. Defina o tipo de texto vertical das células da segunda coluna com [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Salve a apresentação modificada.  

Este código PHP demonstra a operação:

```php
  # Cria uma instância da classe Presentation
  $pres = new Presentation();
  try {
    # Vamos supor que a primeira forma no primeiro slide seja uma tabela
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Define a altura da fonte das células da primeira coluna
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # Define o alinhamento de texto e a margem direita das células da primeira coluna em uma única chamada
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # Define o tipo de texto vertical das células da segunda coluna
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obter Propriedades de Estilo da Tabela**

O Aspose.Slides permite que você recupere as propriedades de estilo de uma tabela para que possa usar esses detalhes em outra tabela ou em outro local. Este código PHP mostra como obter as propriedades de estilo de um estilo predefinido de tabela:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// altera o tema padrão do preset de estilo

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso aplicar temas/estilos do PowerPoint a uma tabela que já foi criada?**

Sim. A tabela herda o tema do slide/layout/master e ainda é possível substituir preenchimentos, bordas e cores de texto sobre esse tema.

**Posso ordenar linhas de tabela como no Excel?**

Não, as tabelas do Aspose.Slides não possuem classificação ou filtros integrados. Ordene os dados na memória primeiro e, em seguida, preencha as linhas da tabela nessa ordem.

**Posso ter colunas listradas (banda) mantendo cores personalizadas em células específicas?**

Sim. Ative colunas listradas e, depois, substitua células específicas com formatação local; a formatação ao nível da célula tem precedência sobre o estilo da tabela.