---
title: Tabela
type: docs
weight: 120
url: /pt/java/examples/elements/table/
keywords:
- exemplo de código
- tabela
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Trabalhe com tabelas no Aspose.Slides para Java: crie, formate, mescle células, aplique estilos, importe dados e exporte com exemplos Java para PPT, PPTX e ODP."
---
Exemplos de adição de tabelas, acesso a elas, remoção e mesclagem de células usando **Aspose.Slides for Java**.

## **Adicionar uma Tabela**

Crie uma tabela simples com duas linhas e duas colunas.

```java
static void addTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar uma Tabela**

Recupere a primeira forma de tabela no slide.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Acesse a primeira tabela no slide.
        ITable firstTable = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                firstTable = (ITable) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remover uma Tabela**

Exclua uma tabela de um slide.

```java
static void removeTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        slide.getShapes().remove(table);
    } finally {
        presentation.dispose();
    }
}
```

## **Mesclar Células da Tabela**

Mescle células adjacentes de uma tabela em uma única célula.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // Mesclar células.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```