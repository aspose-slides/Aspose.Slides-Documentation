---
title: Redimensionar Formas em Slides de Apresentação em PHP
type: docs
weight: 130
url: /pt/php-java/resizing-shapes-on-slide/
aliases:
  - /php-java/re-sizing-shapes-on-slide/
  - /pt/php-java/re-sizing-shapes-on-slide/
keywords:
- redimensionar forma
- alterar tamanho da forma
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Redimensione facilmente formas em slides PowerPoint e OpenDocument com Aspose.Slides para PHP via Java—automatize ajustes de layout de slides e aumente a produtividade."
---
## **Visão geral**

Ao alterar o tamanho dos slides de uma apresentação, você também pode precisar redimensionar e reposicionar suas formas para caber nas novas dimensões. Este artigo mostra como dimensionar as formas manualmente e como lidar com tabelas em slides, mestres e layouts.

## **Redimensionar Formas**

Para preservar a posição e o tamanho relativos de cada forma, multiplique suas coordenadas horizontais e largura pela razão entre a nova largura do slide e a largura original. Aplique a razão de altura correspondente às suas coordenadas verticais e altura.

O primeiro exemplo carrega uma apresentação cujos slides não contêm tabelas, altera o tamanho do slide para A4 e salva o resultado. Ele usa [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) com [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) para que o loop subsequente controle a escala. As razões são adimensionais; as posições e dimensões das formas são medidas em pontos. Razões diferentes de largura e altura podem distorcer as formas, e alterar as dimensões de uma forma não escala seus tamanhos de fonte.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

$presentation = new Presentation("sample.pptx");
try {
    // Calcule fatores de escala horizontais e verticais independentes.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
            $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
As tabelas requerem tratamento separado: dimensione as larguras das colunas e as alturas das linhas em vez de atribuir a largura e altura geral da tabela. As alturas das linhas podem permanecer maiores que o solicitado se o conteúdo das células exigir mais espaço.
{{% /alert %}}

O segundo exemplo oferece suporte a tabelas e processa formas em mestres e layouts, bem como em slides individuais, antes de salvar a apresentação redimensionada. Seu auxiliar trata cada [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) dimensionando as larguras das colunas com [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) e as alturas mínimas das linhas com [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). Em seguida, dimensiona a posição da tabela sem dimensionar separadamente suas dimensões gerais.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SlideSizeType;

class ShapeResizer {
    public function resizeShapes($shapes, $widthRatio, $heightRatio) {
        $tableClass = new JavaClass("com.aspose.slides.Table");
        for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
            $shape = $shapes->get_Item($shapeIndex);
            if (java_instanceof($shape, $tableClass)) {
                $table = $shape;
                // As dimensões da tabela são controladas pelas larguras das colunas e alturas das linhas.
                for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
                    $column = $table->getColumns()->get_Item($columnIndex);
                    $column->setWidth(java_values($column->getWidth()) * $widthRatio);
                }

                for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
                    $row = $table->getRows()->get_Item($rowIndex);
                    $row->setMinimalHeight(java_values($row->getMinimalHeight()) * $heightRatio);
                }
            }
            else {
                $shape->setWidth(java_values($shape->getWidth()) * $widthRatio);
                $shape->setHeight(java_values($shape->getHeight()) * $heightRatio);
            }

            $shape->setX(java_values($shape->getX()) * $widthRatio);
            $shape->setY(java_values($shape->getY()) * $heightRatio);
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    // Calcule fatores de escala horizontais e verticais independentes.
    $originalSize = $presentation->getSlideSize()->getSize();
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
    $targetSize = $presentation->getSlideSize()->getSize();
    $widthRatio = java_values($targetSize->getWidth()) / java_values($originalSize->getWidth());
    $heightRatio = java_values($targetSize->getHeight()) / java_values($originalSize->getHeight());

    $resizer = new ShapeResizer();

    // Redimensione formas definidas em mestres e layouts, bem como em slides individuais.
    for ($masterIndex = 0; $masterIndex < java_values($presentation->getMasters()->size()); $masterIndex++) {
        $master = $presentation->getMasters()->get_Item($masterIndex);
        $resizer->resizeShapes($master->getShapes(), $widthRatio, $heightRatio);

        for ($layoutSlideIndex = 0; $layoutSlideIndex < java_values($master->getLayoutSlides()->size()); $layoutSlideIndex++) {
            $layoutSlide = $master->getLayoutSlides()->get_Item($layoutSlideIndex);
            $resizer->resizeShapes($layoutSlide->getShapes(), $widthRatio, $heightRatio);
        }
    }

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $resizer->resizeShapes($slide->getShapes(), $widthRatio, $heightRatio);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Perguntas frequentes**

**Por que as formas ficam distorcidas ou cortadas após redimensionar um slide?**

Se você alterar o tamanho do slide sem escalar as formas, elas manterão suas posições e dimensões originais e podem se estender além do slide. Escalar a largura e a altura por razões diferentes também pode distorcer as formas.

**O código fornecido funciona para todos os tipos de forma?**

O primeiro exemplo altera os limites das formas diretamente e destina‑se a slides sem tabelas. O segundo exemplo trata as tabelas separadamente. Verifique o layout resultante, particularmente o texto e as tabelas, pois esses exemplos não escalam os tamanhos de fonte e o conteúdo das tabelas pode limitar as alturas das linhas.

**Como redimensionar tabelas ao redimensionar um slide?**

Dimensione as larguras das colunas pela razão de largura e as alturas mínimas das linhas pela razão de altura, depois dimensione a posição da tabela, como mostrado no segundo exemplo.

**Esse redimensionamento funcionará para slides mestre e slides de layout?**

Sim. O segundo exemplo percorre [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) e os [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) de cada mestre e aplica a mesma lógica de redimensionamento às suas formas.

**Posso alterar a orientação de um slide (retrato/paisagem) junto com o redimensionamento?**

Sim. Chame [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) após mudar o tamanho do slide e antes de ler as dimensões alvo, para que os fatores de escala reflitam a orientação final.

**Existe um limite para o tamanho do slide que eu posso definir?**

Você pode especificar dimensões de slide personalizadas com [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). As dimensões suportadas também dependem do formato da apresentação e do aplicativo usado para abrir o arquivo.

**Como impedir que formas com proporção fixa fiquem distorcidas?**

Use o mesmo fator de escala para largura e altura. Para encaixar o layout original nas novas dimensões do slide, use a menor das razões de largura e altura para ambas as dimensões e posições. Isso preserva as proporções, mas pode deixar espaço não utilizado ao longo de uma borda.