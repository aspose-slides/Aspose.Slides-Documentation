---
title: Redimensionar formas em slides de apresentação no Android
type: docs
weight: 130
url: /pt/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/redimensionar-formas-no-slide/
  - /pt/androidjava/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- alterar tamanho da forma
- PowerPoint
- OpenDocument
- apresentação
- Android
- Aspose.Slides
description: "Redimensione facilmente formas em slides PowerPoint e OpenDocument com Aspose.Slides para Android via Java—automatize ajustes de layout de slides e aumente a produtividade."
---
## **Visão geral**

Ao mudar o tamanho dos slides de uma apresentação, você também pode precisar redimensionar e reposicionar suas formas para que se ajustem às novas dimensões. Este artigo mostra como dimensionar as formas manualmente e como lidar com tabelas em slides, mestres e layouts.

## **Redimensionar formas**

Para preservar a posição e o tamanho relativos de cada forma, multiplique suas coordenadas horizontais e a largura pela proporção entre a nova largura do slide e a largura original. Aplique a proporção de altura correspondente às coordenadas verticais e à altura.

O primeiro exemplo carrega uma apresentação cujos slides não contêm tabelas, altera o tamanho do slide para A4 e salva o resultado. Ele usa [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) com [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) para que o loop subsequente controle a dimensionação. As proporções são adimensionais; as posições e dimensões das formas são medidas em pontos. Proporções diferentes de largura e altura podem distorcer as formas, e alterar as dimensões de uma forma não dimensiona os tamanhos de fonte.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Calcular fatores de escala horizontais e verticais independentes.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
As tabelas exigem tratamento separado: dimensione suas larguras de coluna e alturas de linha em vez de atribuir a largura e altura geral da tabela. As alturas das linhas podem permanecer maiores que o solicitado se o conteúdo da célula exigir mais espaço.
{{% /alert %}}

O segundo exemplo oferece suporte a tabelas e processa formas em mestres e layouts, bem como em slides individuais, antes de salvar a apresentação redimensionada. Seu auxiliar manipula cada [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) dimensionando as larguras das colunas com [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) e as alturas mínimas das linhas com [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). Em seguida, dimensiona a posição da tabela sem dimensionar separadamente suas dimensões gerais.

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // As dimensões da tabela são controladas pelas larguras das colunas e alturas das linhas.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Calcular fatores de escala horizontais e verticais independentes.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Redimensionar formas definidas em mestres e layouts, bem como em slides individuais.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Perguntas frequentes**

**Por que as formas ficam distorcidas ou cortadas após redimensionar um slide?**

Se você mudar o tamanho do slide sem dimensionar as formas, elas mantêm suas posições e dimensões originais e podem se estender além do slide. Dimensionar a largura e a altura por proporções diferentes também pode distorcer as formas.

**O código fornecido funciona para todos os tipos de forma?**

O primeiro exemplo altera os limites da forma diretamente e destina‑se a slides sem tabelas. O segundo exemplo trata as tabelas separadamente. Verifique o layout resultante, particularmente o texto e as tabelas, pois esses exemplos não dimensionam os tamanhos de fonte e o conteúdo das tabelas pode restringir as alturas das linhas.

**Como redimensionar tabelas ao redimensionar um slide?**

Dimensione as larguras das colunas pela proporção de largura e as alturas mínimas das linhas pela proporção de altura, então dimensione a posição da tabela, conforme mostrado no segundo exemplo.

**Esse redimensionamento funciona para slides mestres e slides de layout?**

Sim. O segundo exemplo itera através de [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) e das [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) de cada mestre e aplica a mesma lógica de redimensionamento às suas formas.

**Posso mudar a orientação de um slide (retrato/paisagem) junto com o redimensionamento?**

Sim. Chame [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) após mudar o tamanho do slide e antes de ler as dimensões alvo, para que os fatores de escala reflitam a orientação final.

**Existe um limite para o tamanho do slide que eu posso definir?**

Você pode especificar dimensões de slide personalizadas com [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). As dimensões suportadas também dependem do formato da apresentação e do aplicativo usado para abrir o arquivo.

**Como impedir que formas com proporção fixa fiquem distorcidas?**

Use o mesmo fator de escala para largura e altura. Para encaixar o layout original nas novas dimensões do slide, use a menor das proporções de largura e altura para ambas as dimensões e posições. Isso preserva as proporções, mas pode deixar espaço inutilizado ao longo de uma das bordas.