---
title: Gerenciar Células de Tabela em Apresentações Usando PHP
linktitle: Gerenciar Células
type: docs
weight: 30
url: /pt/php-java/manage-cells/
keywords:
- célula de tabela
- mesclar células
- remover borda
- dividir célula
- imagem na célula
- cor de fundo
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Gerencie facilmente células de tabela no PowerPoint com Aspose.Slides para PHP. Domine o acesso, modificação e estilo de células rapidamente para automação de slides perfeita."
---
## **Visão geral**

Aspose.Slides permite acessar e modificar células de tabela em apresentações do PowerPoint. Este artigo explica como identificar células de tabela mescladas, remover bordas de células, trabalhar com numeração de células após mesclar ou dividir células, alterar a cor de fundo de uma célula e adicionar uma imagem dentro de uma célula de tabela. Os exemplos mostram como criar ou abrir uma apresentação, obter uma tabela de um slide, atualizar a formatação da célula através das propriedades da célula e salvar a apresentação modificada como um arquivo PPTX.

## **Identificar uma Célula de Tabela Mesclada**
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a tabela do primeiro slide.
3. Itere pelas linhas e colunas da tabela para encontrar células mescladas.
4. Exiba uma mensagem quando células mescladas forem encontradas.

Este código PHP mostra como identificar células de tabela mescladas em uma apresentação:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// assumindo que Slide#0.Shape#0 seja uma tabela

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remover Bordas de Células de Tabela**
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide por seu índice.
3. Defina um array de colunas com largura.
4. Defina um array de linhas com altura.
5. Adicione uma tabela ao slide através do método [addTable](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/#addTable).
6. Itere por cada célula para limpar as bordas superior, inferior, direita e esquerda.
7. Salve a apresentação modificada como um arquivo PPTX.

Este código PHP mostra como remover as bordas das células de tabela:

```php
  # Instancia a classe Presentation que representa um arquivo PPTX
  $pres = new Presentation();
  try {
    # Acessa o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Define colunas com larguras e linhas com alturas
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Adiciona a forma de tabela ao slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Define o formato de borda para cada célula
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # Grava o PPTX no disco
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numeração em Células Mescladas**
Se mesclarmos 2 pares de células (1, 1) x (2, 1) e (1, 2) x (2, 2), a tabela resultante será numerada. Este código PHP demonstra o processo:

```php
  # Instancia a classe Presentation que representa um arquivo PPTX
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
    foreach($tbl->getRows() as $row) {
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
    # Mescla células (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Mescla células (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Em seguida, mesclamos ainda mais as células ao mesclar (1, 1) e (1, 2). O resultado é uma tabela contendo uma grande célula mesclada em seu centro:

```php
  # Instancia a classe Presentation que representa um arquivo PPTX
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
    foreach($tbl->getRows() as $row) {
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
    # Mescla células (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Mescla células (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Mescla células (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # Grava o arquivo PPTX no disco
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numeração em uma Célula Dividida**
Nos exemplos anteriores, quando as células da tabela eram mescladas, a numeração ou o sistema de numeração nas outras células não mudava.

Desta vez, usamos uma tabela regular (uma tabela sem células mescladas) e então tentamos dividir a célula (1,1) para obter uma tabela especial. Você pode querer prestar atenção à numeração desta tabela, que pode parecer estranha. No entanto, esse é o modo como o Microsoft PowerPoint numera as células de tabela e o Aspose.Slides faz o mesmo.

Este código PHP demonstra o processo descrito:

```php
  # Instancia a classe Presentation que representa um arquivo PPTX
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
    foreach($tbl->getRows() as $row) {
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
    # Mescla células (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Mescla células (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Divide a célula (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # Grava o arquivo PPTX no disco
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alterar a Cor de Fundo da Célula da Tabela**

Este código PHP mostra como alterar a cor de fundo de uma célula de tabela:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # cria uma nova tabela
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # define a cor de fundo para uma célula
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Adicionar uma Imagem Dentro de uma Célula de Tabela**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide por seu índice.
3. Defina um array de colunas com largura.
4. Defina um array de linhas com altura.
5. Adicione uma tabela ao slide através do método [AddTable](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/#addTable).
6. Crie um objeto `Images` para armazenar o arquivo de imagem.
7. Adicione a imagem `IImage` ao objeto `IPPImage`.
8. Defina o `FillFormat` da Célula da Tabela como `Picture`.
9. Adicione a imagem à primeira célula da tabela.
10. Salve a apresentação modificada como um arquivo PPTX

Este código PHP mostra como colocar uma imagem dentro de uma célula de tabela ao criar uma tabela:

```php
  # Instancia a classe Presentation que representa um arquivo PPTX
  $pres = new Presentation();
  try {
    # Acessa o primeiro slide
    $islide = $pres->getSlides()->get_Item(0);
    # Define colunas com larguras e linhas com alturas
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Adiciona uma forma de tabela ao slide
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # Cria um objeto IPPImage usando o arquivo de imagem
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Adiciona a imagem à primeira célula da tabela
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Salva o arquivo PPTX no disco
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso definir diferentes espessuras e estilos de linha para diferentes lados de uma única célula?**

Sim. As bordas [top](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cellformat/getborderright/) possuem propriedades separadas, de modo que a espessura e o estilo de cada lado podem ser diferentes. Isso decorre logicamente do controle de bordas por lado para uma célula demonstrado no artigo.

**O que acontece com a imagem se eu alterar o tamanho da coluna/linha depois de definir uma imagem como fundo da célula?**

O comportamento depende do [fill mode](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillmode/) (stretch/tile). Com estiramento, a imagem ajusta-se à nova célula; com ladrilho, os ladrilhos são recalculados. O artigo menciona os modos de exibição da imagem em uma célula.

**Posso atribuir um hyperlink a todo o conteúdo de uma célula?**

[Hyperlinks](/slides/pt/php-java/manage-hyperlinks/) são definidos no nível do texto (porção) dentro do quadro de texto da célula ou ao nível de toda a tabela/forma. Na prática, você atribui o link a uma porção ou a todo o texto da célula.

**Posso definir fontes diferentes dentro de uma única célula?**

Sim. O quadro de texto de uma célula suporta [portions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/) (runs) com formatação independente — família de fonte, estilo, tamanho e cor.