---
title: Redimensionar formas em slides de apresentação em PHP
type: docs
weight: 130
url: /pt/php-java/resizing-shapes-on-slide/
aliases:
  /php-java/re-sizing-shapes-on-slide/
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

Ao alterar o tamanho dos slides de uma apresentação, você também pode precisar redimensionar e reposicionar suas formas para que caibam nas novas dimensões. Este artigo mostra como dimensionar as formas manualmente e como lidar com tabelas em slides, mestres e layouts.

## **Redimensionar Formas**

Para preservar a posição e o tamanho relativos de cada forma, multiplique as coordenadas horizontais e a largura pelo fator da nova largura do slide em relação à largura original. Aplique o fator de altura correspondente às coordenadas verticais e à altura.

O primeiro exemplo carrega uma apresentação cujos slides não contêm tabelas, altera o tamanho do slide para A4 e salva o resultado. Ele usa [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/) com [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) para que o loop subsequente controle a escala. Os fatores são sem unidade; as posições e dimensões das formas são medidas em pontos. Fatores de largura e altura diferentes podem distorcer as formas, e alterar as dimensões de uma forma não altera o tamanho da fonte.

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
As tabelas exigem tratamento separado: escale as larguras das colunas e as alturas das linhas em vez de atribuir a largura e a altura gerais da tabela. As alturas das linhas podem permanecer maiores que o solicitado se o conteúdo da célula exigir mais espaço.
{{% /alert %}}

O segundo exemplo suporta tabelas e processa formas em mestres e layouts, bem como em slides individuais, antes de salvar a apresentação redimensionada. Seu auxiliar trata cada [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) escalando as larguras das colunas com [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) e as alturas mínimas das linhas com [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/). Em seguida, escala a posição da tabela sem escalar separadamente suas dimensões gerais.

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

Se você alterou o tamanho do slide sem escalar as formas, elas mantêm suas posições e dimensões originais e podem ultrapassar o slide. Escalar largura e altura por fatores diferentes também pode distorcer as formas.

**O código fornecido funciona para todos os tipos de forma?**

O primeiro exemplo altera diretamente os limites das formas e destina‑se a slides sem tabelas. O segundo exemplo trata as tabelas separadamente. Verifique o layout resultante, especialmente texto e tabelas, pois esses exemplos não escalam tamanhos de fonte e o conteúdo da tabela pode limitar as alturas das linhas.

**Como redimensionar tabelas ao redimensionar um slide?**

Escale as larguras das colunas pelo fator de largura e as alturas mínimas das linhas pelo fator de altura, depois escale a posição da tabela, conforme mostrado no segundo exemplo.

**Esse redimensionamento funciona para slides mestres e slides de layout?**

Sim. O segundo exemplo percorre [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) e cada [MasterSlide::getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/getlayoutslides/) de um mestre, aplicando a mesma lógica de redimensionamento às suas formas.

**Posso alterar a orientação do slide (retrato/paisagem) ao redimensionar?**

Sim. Chame [SlideSize::setOrientation](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setorientation/) após mudar o tamanho do slide e antes de ler as dimensões de destino, para que os fatores de escala reflitam a orientação final.

**Existe um limite para o tamanho do slide que posso definir?**

Você pode especificar dimensões personalizadas do slide com [SlideSize::setSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/setsize/). As dimensões suportadas também dependem do formato da apresentação e da aplicação usada para abrir o arquivo.

**Como impedir que formas com proporção fixa fiquem distorcidas?**

Use o mesmo fator de escala para largura e altura. Para ajustar o layout original dentro das novas dimensões do slide, use o menor entre os fatores de largura e altura para ambas as dimensões e posições. Isso preserva as proporções, mas pode deixar espaço não utilizado em uma das bordas.