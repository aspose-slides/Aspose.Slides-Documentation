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
description: "Redimensione facilmente formas em slides do PowerPoint e OpenDocument com Aspose.Slides para Java — automatize ajustes de layout de slides e aumente a produtividade."
---
## **Visão geral**

Uma das perguntas mais frequentes dos clientes do Aspose.Slides para Java é como redimensionar formas de modo que, ao mudar o tamanho do slide, os dados não sejam cortados. Este breve artigo técnico mostra como fazer isso.

## **Redimensionar formas**

Para impedir que as formas fiquem desalinhadas quando o tamanho do slide mudar, atualize a posição e as dimensões de cada forma para que se adequem ao novo layout do slide.

```java
import com.aspose.slides.*;

// Carregar o arquivo de apresentação.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Obter o tamanho original do slide.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Alterar o tamanho do slide sem escalar as formas existentes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Obter o novo tamanho do slide.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Redimensionar e reposicionar as formas em cada slide.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Escalar o tamanho da forma.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Escalar a posição da forma.
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

{{% alert color="info" %}} 

Tabelas não precisam de tratamento especial: definir a largura e a altura de uma tabela redimensiona suas colunas e linhas proporcionalmente, portanto redimensionar novamente as alturas das linhas e as larguras das colunas aplicaria a proporção duas vezes.

{{% /alert %}} 

O código acima altera apenas as formas nos slides. Slides mestres e slides de layout mantêm suas próprias formas, portanto escale‑as também quando desejar que toda a apresentação siga o novo tamanho do slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Obter o tamanho original do slide.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Alterar o tamanho do slide sem escalar as formas existentes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Obter o novo tamanho do slide.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Escalar o tamanho da forma.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Escalar a posição da forma.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Escalar o tamanho da forma.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Escalar a posição da forma.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Escalar o tamanho da forma.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Escalar a posição da forma.
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

## **FAQ**

### Por que as formas ficam distorcidas ou cortadas após redimensionar um slide?

Ao redimensionar um slide, as formas mantêm sua posição e tamanho originais, a menos que a escala seja alterada explicitamente. Isso pode fazer com que o conteúdo seja recortado ou as formas fiquem desalinhadas.

### O código fornecido funciona para todos os tipos de forma?

Sim. Definir a altura e a largura funciona para caixas de texto, imagens, gráficos e tabelas igualmente.

### Como redimensionar tabelas ao redimensionar um slide?

Escale a própria forma da tabela, exatamente como qualquer outra forma. suas linhas e colunas são ajustadas proporcionalmente, portanto não as redimensione novamente depois.

### Esse redimensionamento funciona para slides mestres e de layout?

Sim, mas você também deve percorrer [Masters](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getMasters--) e [Layout slides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getLayoutSlides--) e aplicar a mesma lógica de escala às suas formas para garantir consistência em toda a apresentação.

### Posso mudar a orientação de um slide (retrato/paisagem) juntamente com o redimensionamento?

Sim. Você pode usar [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islidesize/#setOrientation-int-) para mudar a orientação. Certifique‑se de ajustar a lógica de escala adequadamente para preservar o layout.

### Existe um limite para o tamanho de slide que eu posso definir?

O Aspose.Slides suporta tamanhos personalizados, mas tamanhos muito grandes podem afetar o desempenho ou a compatibilidade com algumas versões do PowerPoint.

### Como impedir que formas com proporção fixa fiquem distorcidas?

Você pode verificar o método `getAspectRatioLocked` da forma antes de escalar. Se estiver bloqueado, ajuste a largura ou a altura proporcionalmente em vez de escalá‑las individualmente.