---
title: Gerenciar Tabelas de Apresentação em PHP
linktitle: Gerenciar Tabela
type: docs
weight: 10
url: /pt/php-java/manage-table/
keywords:
- adicionar tabela
- criar tabela
- acessar tabela
- proporção de aspecto
- alinhar texto
- formatação de texto
- estilo de tabela
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Criar e editar tabelas em slides do PowerPoint com Aspose.Slides para PHP via Java. Descubra exemplos de código simples para simplificar seus fluxos de trabalho com tabelas."
---
## **Introdução**

Uma tabela no PowerPoint é uma forma eficiente de exibir e representar informações. A informação em uma grade de células (dispostas em linhas e colunas) é simples e fácil de entender.

Aspose.Slides fornece a classe [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Table) , a classe [Cell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cell/) , e outros tipos para permitir que você crie, atualize e gerencie tabelas em todos os tipos de apresentações.

## **Criar uma Tabela do Zero**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) .
2. Obtenha a referência de um slide através de seu índice. 
3. Defina um array de `columnWidth` .
4. Defina um array de `rowHeight` .
5. Adicione um objeto [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/table/) ao slide através do método [addTable](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addtable/) .
6. Percorra cada [Cell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cell/) para aplicar formatação às bordas superior, inferior, direita e esquerda.
7. Mescle as duas primeiras células da primeira linha da tabela. 
8. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) de um [Cell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cell/) .
9. Adicione algum texto ao [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) .
10. Salve a apresentação modificada.

```php
  # Instancia uma classe Presentation que representa um arquivo PPTX
  $pres = new Presentation();
  try {
    # Acessa o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Define colunas com larguras e linhas com alturas
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Adiciona uma forma de tabela ao slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Define o formato de borda para cada célula
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # Mescla as células 1 e 2 da linha 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Adiciona algum texto à célula mesclada
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Salva a apresentação no disco
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numeração em uma Tabela Padrão**

Em uma tabela padrão, a numeração das células é simples e baseada em zero. A primeira célula de uma tabela tem o índice 0,0 (coluna 0, linha 0). 

Por exemplo, as células em uma tabela com 4 colunas e 4 linhas são numeradas assim:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código PHP mostra como especificar a numeração das células em uma tabela:

```php
  # Instancia uma classe Presentation que representa um arquivo PPTX
  $pres = new Presentation();
  try {
    # Acessa o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Define colunas com larguras e linhas com alturas
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Adiciona uma forma de tabela ao slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Define o formato de borda para cada célula
    $rows = $tbl->getRows();
    foreach($rows as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Salva a apresentação no disco
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acessar uma Tabela Existente**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) .
2. Obtenha uma referência ao slide que contém a tabela através de seu índice. 
3. Crie um objeto [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Table) e atribua null a ele.
4. Percorra todos os objetos [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) até encontrar a tabela.

   Se você suspeitar que o slide em questão contém uma única tabela, pode simplesmente verificar todas as formas que ele contém. Quando uma forma é identificada como uma tabela, você pode convertê‑la para um objeto [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Table). Mas se o slide contiver várias tabelas, é melhor procurar a tabela desejada através de seu [setAlternativeText(String value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/setalternativetext/) .
5. Use o objeto [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Table) para trabalhar com a tabela. No exemplo abaixo, adicionamos uma nova linha à tabela.
6. Salve a apresentação modificada.

```php
  # Instancia a classe Presentation que representa um arquivo PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Acessa o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Inicializa TableEx nulo
    $tbl = null;
    # Percorre as formas e define uma referência para a tabela encontrada
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Define o texto para a primeira coluna da segunda linha
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Salva a apresentação modificada no disco
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Encontrar a Célula que Possui um Quadro de Texto**

Quando um código genérico de processamento de texto recebe um [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) de uma tabela, use o método [TextFrame::getParentCell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#getParentCell) para recuperar a [Cell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cell/) proprietária. Para um quadro de texto de célula de tabela, [TextFrame::getParentCell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#getParentCell) devolve o proprietário e [TextFrame::getParentShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#getParentShape) devolve `null`, apesar de a própria tabela ser uma forma.

As coordenadas da célula estão disponíveis através dos métodos somente leitura [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cell/#getFirstColumnIndex) e [Cell::getFirstRowIndex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cell/#getFirstRowIndex) . [TextFrame::getParentCell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#getParentCell) também fornece navegação somente leitura: ele devolve o proprietário mas não altera a propriedade. Sempre verifique a célula retornada com `java_is_null` antes de usá‑la.

Para um exemplo completo que identifica proprietários de células de tabela e formas, incluindo formas associadas a nós de SmartArt, veja [Search and Replace Text](/slides/pt/php-java/search-and-replace-text/) .

## **Alinhar Texto em uma Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) .
2. Obtenha a referência de um slide através de seu índice. 
3. Adicione um objeto [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Table) ao slide.
4. Acesse um objeto [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) da tabela.
5. Acesse o [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/) .
6. Alinhe o texto verticalmente.
7. Salve a apresentação modificada.

```php
  # Cria uma instância da classe Presentation
  $pres = new Presentation();
  try {
    # Obtém o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);
    # Define colunas com larguras e linhas com alturas
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Adiciona a forma de tabela ao slide
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Acessa o quadro de texto
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Cria o objeto Paragraph para o quadro de texto
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Cria o objeto Portion para o parágrafo
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Alinha o texto verticalmente
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Salva a apresentação no disco
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir Formatação de Texto no Nível da Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) .
2. Obtenha a referência de um slide através de seu índice. 
3. Acesse um objeto [Table](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Table) do Slide.
4. Defina o [setFontHeight(float value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setFontHeight) para o texto.
5. Defina o [setAlignment(int value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setalignment/) e o [setMarginRight(float value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setmarginright/) .
6. Defina o [setTextVerticalType(byte value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/settextverticaltype/) .
7. Salve a apresentação modificada. 

```php
  # Cria uma instância da classe Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # Vamos supor que a primeira forma no primeiro slide é uma tabela
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Define a altura da fonte das células da tabela
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Define o alinhamento de texto e a margem direita das células da tabela em uma única chamada
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Define o tipo vertical de texto das células da tabela
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obter Propriedades de Estilo da Tabela**

Aspose.Slides permite recuperar as propriedades de estilo de uma tabela para que você possa usar esses detalhes em outra tabela ou em outro lugar. Este código PHP mostra como obter as propriedades de estilo de um estilo predefinido de tabela:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// alterar o tema padrão do estilo predefinido

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bloquear Proporção da Tabela**

A proporção de aspecto de uma forma geométrica é a razão entre seus tamanhos em diferentes dimensões. Aspose.Slides fornece o método [setAspectRatioLocked](https://reference.aspose.com/slides/pt/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) para permitir que você bloqueie a configuração de proporção de aspecto para tabelas e outras formas.

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// inverter

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso habilitar a direção de leitura da direita para a esquerda (RTL) para uma tabela inteira e o texto em suas células?**

Sim. A tabela expõe o método [setRightToLeft](https://reference.aspose.com/slides/pt/php-java/aspose.slides/table/setrighttoleft/) e os parágrafos possuem [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setrighttoleft/). Usar ambos garante a ordem RTL correta e a renderização adequada dentro das células.

**Como posso impedir que os usuários movam ou redimensionem uma tabela no arquivo final?**

Use os bloqueios de forma para desativar mover, redimensionar, selecionar, etc. Esses bloqueios também se aplicam às tabelas.

**É suportado inserir uma imagem dentro de uma célula como plano de fundo?**

Sim. Você pode definir um [picture fill](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/) para uma célula; a imagem cobrirá a área da célula de acordo com o modo escolhido (esticar ou repetir).