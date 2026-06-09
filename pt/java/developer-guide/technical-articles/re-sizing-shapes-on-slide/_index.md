---
title: Redimensionar formas em slides de apresentação
type: docs
weight: 110
url: /pt/java/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- alterar tamanho da forma
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Redimensione facilmente formas em slides PowerPoint e OpenDocument com Aspose.Slides para Java — automatize ajustes de layout de slides e aumente a produtividade."
---
## **Visão geral**

Uma das perguntas mais comuns dos clientes do Aspose.Slides for Java é como redimensionar formas de modo que, quando o tamanho do slide mudar, os dados não sejam cortados. Este breve artigo técnico mostra como fazer isso.

## **Redimensionar formas**

Para evitar que as formas fiquem desalinhadas quando o tamanho do slide mudar, atualize a posição e as dimensões de cada forma para que elas se adequem ao novo layout do slide.

```java
// Carregue o arquivo de apresentação.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Obtenha o tamanho original do slide.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Altere o tamanho do slide sem dimensionar as formas existentes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Obtenha o novo tamanho do slide.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Redimensione e reposicione as formas em cada slide.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Dimensione o tamanho da forma.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Dimensione a posição da forma.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}} 
Se um slide contém uma tabela, o código acima não funcionará corretamente. Nesse caso, cada célula da tabela deve ser redimensionada.
{{% /alert %}} 

Use o código a seguir para redimensionar slides que contêm tabelas. Para tabelas, definir a largura ou altura é um caso especial: é necessário ajustar as alturas das linhas individuais e as larguras das colunas para alterar o tamanho geral da tabela.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Obtenha o tamanho original do slide.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Altere o tamanho do slide sem escalar as formas existentes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Obtenha o novo tamanho do slide.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Dimensione o tamanho da forma.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Dimensione a posição da forma.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Dimensione o tamanho da forma.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Dimensione a posição da forma.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Dimensione o tamanho da forma.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Dimensione a posição da forma.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Perguntas frequentes**

**Por que as formas ficam distorcidas ou cortadas após redimensionar um slide?**

Ao redimensionar um slide, as formas mantêm sua posição e tamanho originais, a menos que a escala seja alterada explicitamente. Isso pode fazer com que o conteúdo seja recortado ou que as formas fiquem desalinhadas.

**O código fornecido funciona para todos os tipos de forma?**

O exemplo básico funciona para a maioria dos tipos de forma (caixas de texto, imagens, gráficos etc.). Contudo, para tabelas, é necessário tratar linhas e colunas separadamente, pois a altura e a largura de uma tabela são determinadas pelas dimensões das células individuais.

**Como redimensionar tabelas ao redimensionar um slide?**

É preciso percorrer todas as linhas e colunas da tabela e redimensionar suas alturas e larguras proporcionalmente, como demonstrado no segundo exemplo de código.

**Esse redimensionamento funciona para slides mestres e slides de layout?**

Sim, mas você também deve percorrer os [Masters](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getMasters--) e os [Layout slides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getLayoutSlides--) e aplicar a mesma lógica de escala às suas formas para garantir consistência em toda a apresentação.

**Posso mudar a orientação de um slide (retrato/paisagem) juntamente com o redimensionamento?**

Sim. Você pode usar [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islidesize/#setOrientation-int-) para alterar a orientação. Certifique‑se de ajustar a lógica de escala adequadamente para preservar o layout.

**Existe um limite para o tamanho de slide que posso definir?**

O Aspose.Slides suporta tamanhos personalizados, mas tamanhos muito grandes podem afetar o desempenho ou a compatibilidade com algumas versões do PowerPoint.

**Como impedir que formas com proporção fixa fiquem distorcidas?**

Você pode verificar o método `getAspectRatioLocked` da forma antes de escalá‑la. Se estiver bloqueado, ajuste a largura ou a altura proporcionalmente em vez de escalá‑las individualmente.