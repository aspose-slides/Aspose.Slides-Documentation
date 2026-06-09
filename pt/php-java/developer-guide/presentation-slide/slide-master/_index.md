---
title: Gerenciar Mestres de Slides de Apresentação em PHP
linktitle: Mestre de Slides
type: docs
weight: 70
url: /pt/php-java/slide-master/
keywords:
- master de slide
- slide mestre
- slide mestre PPT
- vários slides mestre
- comparar slides mestre
- fundo
- marcador de posição
- clonar slide mestre
- copiar slide mestre
- duplicar slide mestre
- slide mestre não usado
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Gerenciar mestres de slides no Aspose.Slides para PHP via Java: acessar, editar, clonar, comparar e remover slides mestre em apresentações PowerPoint e OpenDocument."
---
## **Visão Geral**

Um **slide master** define configurações de design compartilhadas para um grupo de slides. Ele pode conter formas comuns, logotipos, fundos, estilos de texto, configurações de tema e configurações de rodapé. No PowerPoint, editar um slide master é a maneira usual de manter uma apresentação consistente sem repetir a mesma formatação em cada slide.

Aspose.Slides for PHP via Java oferece o mesmo modelo. Uma apresentação pode conter um ou mais master slides, e cada master slide pode conter vários layout slides. Slides normais normalmente não se referem a um master slide diretamente. Em vez disso, um slide normal usa um layout slide, e esse layout slide pertence a um master slide.

A hierarquia é:

1. **Slide master** - define o design e tema compartilhados.  
1. **Layout slide** - define um arranjo específico de placeholders e formatação de nível de layout.  
1. **Normal slide** - contém o conteúdo real da apresentação e usa um layout slide.

![A hierarquia de master slides, layout slides e normal slides](slide-master_2.jpg)

No Aspose.Slides, um slide master é representado pela classe [MasterSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslide/). Todos os master slides de uma apresentação estão disponíveis através do método [Presentation.getMasters](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getMasters), que devolve um objeto [MasterSlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Herança" %}}

Quando a mesma propriedade é definida em mais de um nível, o nível mais específico tem prioridade. Por exemplo, se um master slide e um layout slide ambos definirem um fundo, os slides baseados nesse layout usam o fundo do layout. Para mais informações sobre layout slides, veja [Aplicar ou Alterar Layouts de Slides](/slides/pt/php-java/slide-layout/).

{{% /alert %}}

## **Acessar Slide Masters**

No PowerPoint, você pode abrir a visualização Slide Master em **Exibir** > **Slide Master**.

![O comando Slide Master na guia Exibir do PowerPoint](slide-master_3.jpg)

No Aspose.Slides, use o método `getMasters` para acessar master slides:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Você também pode obter o master slide usado por um slide normal através de seu layout:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **O que um Slide Master contém**

Um master slide é um objeto semelhante a um slide. Ele herda de [BaseSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/), portanto expõe muitas das mesmas propriedades de slide usadas por slides normais e de layout. Membros específicos do master são listados na página da API [MasterSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslide/).

Membros de master slide mais usados incluem:

| Membro | Propósito |
| --- | --- |
| `getBackground` | Define o plano de fundo ao nível do master. |
| `getShapes` | Armazena formas colocadas no master, como logotipos, quadros de imagens e texto compartilhado. |
| `getLayoutSlides` | Armazena os layout slides que pertencem ao master. |
| `getThemeManager` | Fornece acesso às APIs de tema do master. |
| `getHeaderFooterManager` | Controla cabeçalhos, rodapés, datas e números de slide para o master e seus layouts filhos. |
| `getDependingSlides` | Retorna slides normais que dependem do master através de seus layouts. |

## **Adicionar uma Imagem a um Slide Master**

Quando você adiciona uma imagem a um master slide, ela aparece nos slides que usam layouts desse master. Isso é útil para logotipos, marcas d'água, faixas decorativas e outros elementos visuais repetidos.

O exemplo a seguir adiciona um logotipo ao primeiro master slide:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para mais informações sobre quadros de imagens, veja [Quadro de Imagem](/slides/pt/php-java/picture-frame/).

## **Trabalhar com Placeholders**

Placeholders são normalmente definidos em layout slides. O master slide fornece o estilo e tema compartilhados que esses layouts herdam, enquanto cada layout decide quais placeholders estão disponíveis e onde são posicionados.

No PowerPoint, os comandos de placeholder estão disponíveis na visualização Slide Master.

![O comando Inserir Placeholder na visualização Slide Master do PowerPoint](slide-master_5.png)

Para adicionar novos placeholders com Aspose.Slides, trabalhe com o layout slide que pertence ao master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Você também pode formatar shapes de placeholder que já existem em um master slide. O exemplo a seguir encontra o placeholder de título e aplica um preenchimento de gradiente linear:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![Placeholder de título formatado herdado por slides normais](slide-master_8.png)

Para mais opções de formatação de placeholders e texto, veja [Definir Texto de Prompt no Placeholder](/slides/pt/php-java/manage-placeholder/) e [Formatação de Texto](/slides/pt/php-java/text-formatting/).

## **Alterar o Plano de Fundo de um Slide Master**

Um fundo de master é herdado por layouts e slides que não o substituem. O exemplo a seguir define uma cor de fundo sólida para o primeiro master slide:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para tópicos relacionados, veja [Fundo da Apresentação](/slides/pt/php-java/presentation-background/) e [Tema da Apresentação](/slides/pt/php-java/presentation-theme/).

## **Clonar um Slide Master para outra Apresentação**

Use `addClone` da [MasterSlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslidecollection/) para copiar um master slide para outra apresentação. O master copiado pode então ser usado por layouts e slides na apresentação de destino.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

Se precisar clonar slides normais junto com seu master, veja [Clonar Slides](/slides/pt/php-java/clone-slides/).

## **Adicionar Vários Slide Masters**

Uma apresentação pode conter vários master slides. Isso é útil quando seções diferentes exigem diferentes marcas, estruturas de página ou configurações de tema.

![Comandos do PowerPoint para inserir e gerenciar master slides](slide-master_9.jpg)

O exemplo a seguir clona o master padrão, dá ao clone um fundo diferente, cria um layout sob esse master clonado e adiciona um novo slide baseado nesse layout:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Comparar Slide Masters**

Master slides podem ser comparados com o método `equals` herdado de [BaseSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/). A comparação verifica estrutura e conteúdo estático, como formas, texto, formatação, animações e outras configurações de slide. Não compara identificadores únicos, como IDs de slide, ou valores dinâmicos de placeholder, como a data atual.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

Para mais informações, veja [Comparar Slides da Apresentação](/slides/pt/php-java/compare-slides/).

## **Definir a Visualização Slide Master como Visualização Padrão**

Use o método `setLastView` em [ViewProperties](https://reference.aspose.com/slides/pt/php-java/aspose.slides/viewproperties/) para controlar a visualização que o PowerPoint abre primeiro. O exemplo a seguir abre a apresentação na visualização Slide Master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para mais configurações de visualização, veja [Salvar Apresentação](/slides/pt/php-java/save-presentation/).

## **Remover Master Slides Não Utilizados**

Apresentações às vezes contêm master slides que não são mais usados por nenhum slide normal. Remover masters não utilizados pode reduzir o tamanho do arquivo e simplificar a manutenção do modelo.

Use `removeUnused` da [MasterSlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslidecollection/) para remover masters não usados da coleção `getMasters`:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Você também pode usar o método de baixo código `removeUnusedMasterSlides` da classe [Compress](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Qual é a diferença entre um slide master e um layout slide?**

Um slide master define configurações de design compartilhadas, como tema, fundo, formas comuns e estilos de texto. Um layout slide pertence a um slide master e define um arranjo específico de placeholders. Um slide normal usa um layout slide, herdando tanto do layout quanto do master.

**Uma apresentação pode conter vários slide masters?**

Sim. Uma apresentação pode conter vários slide masters. Use múltiplos masters quando seções diferentes precisam de sistemas visuais ou branding diferentes.

**Devo adicionar placeholders a um master slide ou a um layout slide?**

Na maioria dos casos, adicione placeholders a layout slides. Coloque elementos visuais compartilhados e formatação comum no master slide e coloque os placeholders de conteúdo nos layouts que os slides normais usarão.

**Posso excluir um master slide que ainda está em uso?**

Não. Um master slide que tem slides dependentes não pode ser removido com segurança. Primeiro mova esses slides para layouts sob outro master, ou use um método de limpeza que remova apenas masters que não estão em uso.