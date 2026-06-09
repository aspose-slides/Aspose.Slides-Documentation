---
title: Tabela
type: docs
weight: 120
url: /pt/nodejs-java/examples/elements/table/
keywords:
- exemplo de código
- tabela
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Trabalhe com tabelas no Aspose.Slides for Node.js: crie, formate, mescle células, aplique estilos, importe dados e exporte com exemplos para PPT, PPTX e ODP."
---
Exemplos de adição de tabelas, acesso a elas, remoção delas e mesclagem de células usando **Aspose.Slides for Node.js via Java**.

## **Adicionar Tabela**

Crie uma tabela simples com duas linhas e duas colunas.

```js
function addTable() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let widths = java.newArray("double", [80, 80]);
        let heights = java.newArray("double", [30, 30]);
        let table = slide.getShapes().addTable(50, 50, widths, heights);

        presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar Tabela**

Recupere a primeira forma de tabela do slide.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Acesse a primeira tabela no slide.
        let firstTable = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
                firstTable = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remover Tabela**

Exclua uma tabela de um slide.

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Presuma que a primeira forma seja uma tabela.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Mesclar Células da Tabela**

Mescle células adjacentes de uma tabela em uma única célula.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Presuma que a primeira forma seja uma tabela.
        let table = slide.getShapes().get_Item(0);

        // Mesclar células.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```