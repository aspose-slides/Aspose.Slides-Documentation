---
title: Redimensionar formas em slides de apresentação no Node.js
type: docs
weight: 130
url: /pt/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- alterar tamanho da forma
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Redimensione facilmente formas em slides PowerPoint e OpenDocument com Aspose.Slides para Node.js via Java—automatize ajustes de layout de slides e aumente a produtividade."
---
## **Visão geral**

Ao alterar o tamanho do slide de uma apresentação, talvez seja necessário redimensionar e reposicionar suas formas para se ajustarem às novas dimensões. Este artigo mostra como dimensionar formas manualmente e como lidar com tabelas em slides, mestres e layouts.

## **Redimensionar formas**

Para preservar a posição e o tamanho relativos de cada forma, multiplique suas coordenadas horizontais e a largura pela proporção entre a nova largura do slide e a largura original. Aplique a proporção correspondente de altura às coordenadas verticais e à altura.

O primeiro exemplo carrega uma apresentação cujos slides não contêm tabelas, altera o tamanho do slide para A4 e salva o resultado. Ele usa [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) com [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) para que o loop subsequente controle a escala. As proporções são adimensionais; as posições e dimensões das formas são medidas em pontos. Proporções diferentes de largura e altura podem distorcer as formas, e alterar as dimensões de uma forma não escala o tamanho das fontes.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Calcule fatores de escala horizontais e verticais independentes.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
As tabelas requerem tratamento separado: escale as larguras das colunas e as alturas das linhas em vez de definir a largura e a altura geral da tabela. As alturas das linhas podem permanecer maiores que o solicitado se o conteúdo da célula exigir mais espaço.
{{% /alert %}}

O segundo exemplo suporta tabelas e processa formas em mestres e layouts, bem como em slides individuais, antes de salvar a apresentação redimensionada. Seu ajudante trata cada [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) escalando as larguras das colunas com [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) e as alturas mínimas das linhas com [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). Em seguida, escala a posição da tabela sem dimensionar separadamente suas dimensões gerais.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // As dimensões da tabela são controladas pelas larguras das colunas e alturas das linhas.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // Calcule fatores de escala horizontais e verticais independentes.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Redimensione formas definidas em mestres e layouts, bem como em slides individuais.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Perguntas frequentes**

**Por que as formas ficam distorcidas ou cortadas após redimensionar um slide?**

Se você alterar o tamanho do slide sem escalar as formas, elas mantêm suas posições e dimensões originais e podem se estender além do slide. Escalar largura e altura por proporções diferentes também pode distorcer as formas.

**O código fornecido funciona para todos os tipos de forma?**

O primeiro exemplo altera os limites das formas diretamente e destina‑se a slides sem tabelas. O segundo exemplo trata as tabelas separadamente. Verifique o layout resultante, particularmente o texto e as tabelas, pois esses exemplos não escalam o tamanho das fontes e o conteúdo da tabela pode limitar as alturas das linhas.

**Como redimensionar tabelas ao redimensionar um slide?**

Escale as larguras das colunas pela proporção de largura e as alturas mínimas das linhas pela proporção de altura, depois escale a posição da tabela, como mostrado no segundo exemplo.

**Esse redimensionamento funciona para slides mestres e slides de layout?**

Sim. O segundo exemplo itera através de [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) e dos [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) de cada mestre e aplica a mesma lógica de redimensionamento às suas formas.

**Posso mudar a orientação de um slide (retrato/paisagem) junto com o redimensionamento?**

Sim. Chame [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) após alterar o tamanho do slide e antes de ler as dimensões de destino, para que os fatores de escala reflitam a orientação final.

**Existe um limite para o tamanho de slide que posso definir?**

Você pode especificar dimensões de slide personalizadas com [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). As dimensões suportadas também dependem do formato da apresentação e do aplicativo usado para abrir o arquivo.

**Como evitar que formas com proporção fixa fiquem distorcidas?**

Use o mesmo fator de escala para largura e altura. Para ajustar o layout original dentro das novas dimensões do slide, use a menor das proporções de largura e altura para ambas as dimensões e posições. Isso preserva as proporções, mas pode deixar espaço não utilizado ao longo de uma borda.