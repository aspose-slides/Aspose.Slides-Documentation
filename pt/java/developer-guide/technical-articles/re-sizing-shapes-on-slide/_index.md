---
title: Redimensionar formas em slides de apresentação em Java
type: docs
weight: 130
url: /pt/java/resizing-shapes-on-slide/
aliases:
  - /pt/java/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- alterar tamanho da forma
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Redimensione facilmente formas em slides PowerPoint e OpenDocument com Aspose.Slides for Java — automatize ajustes de layout de slides e aumente a produtividade."
---
## **Visão geral**

Quando você altera o tamanho do slide de uma apresentação, pode também precisar redimensionar e reposicionar suas formas para se ajustarem às novas dimensões. Este artigo mostra como dimensionar manualmente as formas e como lidar com tabelas em slides, mestres e layouts.

## **Redimensionar formas**

Para preservar a posição e o tamanho relativos de cada forma, multiplique suas coordenadas horizontais e largura pela razão da nova largura do slide em relação à largura original. Aplique a razão de altura correspondente às coordenadas verticais e altura.

O primeiro exemplo carrega uma apresentação cujos slides não contêm tabelas, altera o tamanho do slide para A4 e salva o resultado. Ele usa [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) com [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) para que o loop subsequente controle o dimensionamento. As razões são adimensionais; as posições e dimensões das formas são medidas em pontos. Diferentes razões de largura e altura podem distorcer as formas, e mudar as dimensões de uma forma não dimensiona seus tamanhos de fonte.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Calcule fatores de escala horizontais e verticais independentes.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

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
As tabelas requerem tratamento separado: dimensione suas larguras de coluna e alturas de linha em vez de atribuir a largura e altura gerais da tabela. As alturas de linha podem permanecer maiores que o solicitado se o conteúdo da célula exigir mais espaço.
{{% /alert %}}

O segundo exemplo suporta tabelas e processa formas em mestres e layouts, bem como slides individuais, antes de salvar a apresentação redimensionada. Seu auxiliar manipula cada [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) redimensionando as larguras das colunas com [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) e as alturas mínimas das linhas com [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-). Em seguida, dimensiona a posição da tabela sem dimensionar separadamente suas dimensões gerais.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

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
    // Calcule fatores de escala horizontais e verticais independentes.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // Redimensione formas definidas em mestres e layouts, bem como em slides individuais.
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

## **Perguntas Frequentes**

**Por que as formas ficam distorcidas ou cortadas após redimensionar um slide?**

Se você mudar o tamanho do slide sem dimensionar as formas, elas mantêm suas posições e dimensões originais e podem ultrapassar o slide. Dimensionar largura e altura por razões diferentes também pode distorcer as formas.

**O código fornecido funciona para todos os tipos de forma?**

O primeiro exemplo altera os limites das formas diretamente e destina-se a slides sem tabelas. O segundo exemplo trata as tabelas separadamente. Verifique o layout resultante, particularmente textos e tabelas, pois esses exemplos não dimensionam os tamanhos de fonte e o conteúdo da tabela pode restringir as alturas das linhas.

**Como redimensionar tabelas ao redimensionar um slide?**

Dimensione as larguras das colunas pela razão de largura e as alturas mínimas das linhas pela razão de altura, então dimensione a posição da tabela, como mostrado no segundo exemplo.

**Esse redimensionamento funciona para slides mestre e slides de layout?**

Sim. O segundo exemplo itera através de [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) e de cada [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) de cada mestre e aplica a mesma lógica de redimensionamento às suas formas.

**Posso mudar a orientação de um slide (retrato/paisagem) junto com o redimensionamento?**

Sim. Chame [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) após mudar o tamanho do slide e antes de ler as dimensões alvo, para que os fatores de escala reflitam a orientação final.

**Existe um limite para o tamanho do slide que eu posso definir?**

Você pode especificar dimensões personalizadas do slide com [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-). As dimensões suportadas também dependem do formato da apresentação e da aplicação usada para abrir o arquivo.

**Como impedir que formas com proporção fixa fiquem distorcidas?**

Use o mesmo fator de escala para largura e altura. Para que o layout original caiba nas novas dimensões do slide, use a menor das razões de largura e altura para ambas as dimensões e posições. Isso preserva as proporções, mas pode deixar espaço não usado ao longo de uma das bordas.