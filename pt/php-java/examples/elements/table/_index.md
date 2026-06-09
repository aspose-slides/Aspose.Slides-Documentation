---
title: Tabela
type: docs
weight: 120
url: /pt/php-java/examples/elements/table/
keywords:
- tabela
- adicionar tabela
- acessar tabela
- remover tabela
- mesclar células
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Crie e formate tabelas em PHP com Aspose.Slides: insira dados, mescle células, estilize bordas, alinhe o conteúdo e importe/exporte para PPT, PPTX e ODP."
---
Exemplos de como adicionar tabelas, acessá-las, removê-las e mesclar células usando **Aspose.Slides for PHP via Java**.

## **Adicionar Tabela**

Crie uma tabela simples com duas linhas e duas colunas.

```php
function addTable() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $widths = [80, 80];
        $heights = [30, 30];
        $table = $slide->getShapes()->addTable(50, 50, $widths, $heights);

        $presentation->save("table.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acessar Tabela**

Recupere a primeira forma de tabela no slide.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acesse a primeira tabela no slide.
        $firstTable = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Table"))) {
                $firstTable = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Remover Tabela**

Exclua uma tabela de um slide.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Pressupondo que a tabela seja a primeira forma no slide.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Mesclar Células da Tabela**

Mescle células adjacentes de uma tabela em uma única célula.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Pressupondo que a tabela seja a primeira forma no slide.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```