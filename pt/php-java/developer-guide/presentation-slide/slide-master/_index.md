---
title: Gerenciar Slides Mestres de Apresentação em PHP
linktitle: Mestre de Slides
type: docs
weight: 70
url: /pt/php-java/slide-master/
keywords:
- slide mestre
- slide mestre
- slide mestre PPT
- vários slides mestres
- comparar slides mestres
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
description: "Gerencie slides mestres no Aspose.Slides para PHP via Java: acesse, edite, clone, compare e remova slides mestres em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Um **slide master** define configurações de design compartilhadas para um grupo de slides. Ele pode conter formas comuns, logotipos, planos de fundo, estilos de texto, configurações de tema e de rodapé. No PowerPoint, editar um slide master é a forma usual de manter uma apresentação coerente sem repetir a mesma formatação em cada slide.

Aspose.Slides para PHP via Java oferece o mesmo modelo. Uma apresentação pode conter um ou mais slides mestres, e cada slide mestre pode conter vários slides de layout. Slides normais normalmente não se referem a um slide mestre diretamente. Em vez disso, um slide normal usa um slide de layout, e esse slide de layout pertence a um slide mestre.

A hierarquia é:

1. **Slide master** – define o design e o tema compartilhados.  
1. **Layout slide** – define um arranjo específico de marcadores de posição e formatação ao nível do layout.  
1. **Normal slide** – contém o conteúdo real da apresentação e usa um layout slide.

![A hierarquia de slides mestre, slides de layout e slides normais](slide-master_2.jpg)

No Aspose.Slides, um slide master é representado pela classe [MasterSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslide/). Todos os slides mestres em uma apresentação estão disponíveis através do método [Presentation.getMasters](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#getMasters), que devolve um objeto [MasterSlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Herança" %}}

Quando a mesma propriedade é definida em mais de um nível, o nível mais específico prevalece. Por exemplo, se um slide master e um slide de layout ambos definirem um plano de fundo, os slides baseados nesse layout usarão o plano de fundo do layout. Para mais informações sobre slides de layout, veja [Apply or Change Slide Layouts](/slides/pt/php-java/slide-layout/).

{{% /alert %}}

## **Acessar Slides Mestres**

No PowerPoint, você pode abrir a visualização Slide Master em **Exibir** > **Slide Master**.

![O comando Slide Master na guia Exibir do PowerPoint](slide-master_3.jpg)

No Aspose.Slides, use o método `getMasters` para acessar slides mestres:

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

Você também pode obter o slide mestre usado por um slide normal através de seu layout:

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

## **O que um Slide Master Contém**

Um slide master é um objeto semelhante a um slide. Ele estende [BaseSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/), portanto expõe muitas das mesmas propriedades de slide usadas por slides normais e de layout. Os membros específicos do master estão listados na página da API [MasterSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslide/).

Membros de slide master usados com frequência incluem:

| Membro | Propósito |
| --- | --- |
| `getBackground` | Define o plano de fundo ao nível do master. |
| `getShapes` | Armazena formas colocadas no master, como logotipos, quadros de imagem e texto compartilhado. |
| `getLayoutSlides` | Armazena os slides de layout que pertencem ao master. |
| `getThemeManager` | Fornece acesso às APIs de tema do master. |
| `getHeaderFooterManager` | Controla cabeçalhos, rodapés, datas e números de slide para o master e seus layouts filhos. |
| `getDependingSlides` | Retorna slides normais que dependem do master por meio de seus layouts. |

## **Adicionar uma Imagem a um Slide Master**

Quando você adiciona uma imagem a um slide master, ela aparece nos slides que utilizam layouts desse master. Isso é útil para logotipos, marcas d'água, faixas decorativas e outros elementos visuais repetidos.

O exemplo a seguir adiciona um logotipo ao primeiro slide master:

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

Para mais informações sobre quadros de imagem, veja [Picture Frame](/slides/pt/php-java/picture-frame/).

## **Controlar a Visibilidade de Gráficos do Master**

Use [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/#setShowMasterShapes) para ocultar gráficos herdados do master, como logotipos ou formas decorativas, sem excluí‑los do master. Passe `false` para [Slide::setShowMasterShapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#setShowMasterShapes) no slide que deve omitir esses gráficos e mantenha `true` nos slides que devem exibí‑los.

O exemplo autônomo a seguir cria uma faixa decorativa azul em um master e dois slides que utilizam o mesmo layout em branco. A faixa está visível no primeiro slide e oculta no segundo. Nenhuma apresentação ou imagem de entrada é necessária.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O exemplo usa o layout **Blank** fornecido com uma nova apresentação e remove os marcadores de posição próprios do slide inicial.

### **Escolher o Escopo da Configuração**

Um slide normal usa seu master por meio de [Slide::getLayoutSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#getLayoutSlide) e [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/#getMasterSlide). Definir a propriedade em um slide individual afeta somente esse slide. Passar `false` para [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/#setShowMasterShapes) oculta os gráficos do master para slides que utilizam aquele layout compartilhado, mesmo que a configuração própria deles seja `true`. Para ocultar gráficos em apenas um slide, altere a propriedade do slide e deixe o layout compartilhado inalterado.

A configuração não é suportada como controle de visibilidade no próprio slide master. Em um master, [getShowMasterShapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslide/#getShowMasterShapes) sempre devolve `false`, e passar `true` para [setShowMasterShapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslide/#setShowMasterShapes) gera uma exceção. Aplique-a a um slide normal ou a um layout.

### **Diferenciar Gráficos do Plano de Fundo**

| Operação | Efeito |
| --- | --- |
| Ocultar gráficos do master | Controla a visibilidade de formas herdadas do master sem excluí‑las ou alterar as próprias formas do slide. |
| Alterar o preenchimento de fundo do slide | Altera a cor, gradiente ou imagem de fundo. Gráficos do master são formas separadas e podem permanecer visíveis sobre esse fundo. Veja [Presentation Background](/slides/pt/php-java/presentation-background/). |
| Excluir uma forma do master | Remove a forma fonte compartilhada, de modo que não fique mais disponível para nenhum slide que use esse master. |

## **Trabalhar com Marcadores de Posição**

Marcadores de posição normalmente são definidos em slides de layout. O slide master fornece o estilo e o tema compartilhados que esses layouts herdam, enquanto cada layout decide quais marcadores de posição estão disponíveis e onde são posicionados.

No PowerPoint, os comandos de marcador de posição estão disponíveis na visualização Slide Master.

![O comando Inserir Marcador de Posição na visualização Slide Master do PowerPoint](slide-master_5.png)

Para adicionar novos marcadores de posição com Aspose.Slides, trabalhe com o slide de layout que pertence ao master:

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

Você também pode formatar formas de marcador de posição que já existam em um slide master. O exemplo a seguir localiza o marcador de posição de título e aplica um preenchimento gradiente linear:

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

![Marcador de posição de título formatado herdado por slides normais](slide-master_8.png)

Para mais opções de formatação de marcadores de posição e texto, veja [Set Prompt Text in Placeholder](/slides/pt/php-java/manage-placeholder/) e [Text Formatting](/slides/pt/php-java/text-formatting/).

## **Alterar o Plano de Fundo de um Slide Master**

Um plano de fundo de master é herdado por layouts e slides que não o sobrescrevem. O exemplo a seguir define uma cor de fundo sólida para o primeiro slide master:

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

Para tópicos relacionados, veja [Presentation Background](/slides/pt/php-java/presentation-background/) e [Presentation Theme](/slides/pt/php-java/presentation-theme/).

## **Clonar um Slide Master para Outra Apresentação**

Use `addClone` da [MasterSlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslidecollection/) para copiar um slide master para outra apresentação. O master copiado pode então ser usado por layouts e slides na apresentação de destino.

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

Se precisar clonar slides normais junto com seu master, veja [Clone Slides](/slides/pt/php-java/clone-slides/).

## **Adicionar Vários Slides Mestres**

Uma apresentação pode conter vários slides mestres. Isso é útil quando seções diferentes exigem diferentes identidades visuais, estruturas de página ou configurações de tema.

![Comandos do PowerPoint para inserir e gerenciar slides mestres](slide-master_9.jpg)

O exemplo a seguir clona o master padrão, atribui ao clone um fundo diferente, cria um layout sob esse master clonado e adiciona um novo slide baseado nesse layout:

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

## **Comparar Slides Mestres**

Slides mestres podem ser comparados com o método `equals` herdado de [BaseSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/). A comparação verifica estrutura e conteúdo estático, como formas, texto, formatação, animações e outras configurações de slide. Não compara identificadores exclusivos, como IDs de slide, ou valores dinâmicos de marcadores de posição, como a data atual.

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

Para mais informações, veja [Compare Presentation Slides](/slides/pt/php-java/compare-slides/).

## **Definir a Visualização de Slide Master como Visualização Padrão**

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

Para mais configurações de visualização, veja [Save Presentation](/slides/pt/php-java/save-presentation/).

## **Remover Slides Mestres Não Utilizados**

Apresentações às vezes contêm slides mestres que não são mais usados por nenhum slide normal. Remover masters não utilizados pode reduzir o tamanho do arquivo e simplificar a manutenção de templates.

Use `removeUnused` da [MasterSlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslidecollection/) para remover masters não utilizados da coleção `getMasters`:

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

**Qual é a diferença entre um slide master e um slide de layout?**

Um slide master define configurações de design compartilhadas, como tema, plano de fundo, formas comuns e estilos de texto. Um slide de layout pertence a um slide master e define um arranjo específico de marcadores de posição. Um slide normal usa um slide de layout, portanto herda tanto do layout quanto do master.

**Uma apresentação pode conter vários slides mestres?**

Sim. Uma apresentação pode conter vários slides mestres. Use múltiplos masters quando seções diferentes precisarem de sistemas visuais ou identidades de marca distintas.

**Devo adicionar marcadores de posição a um slide master ou a um slide de layout?**

Na maioria dos casos, adicione marcadores de posição aos slides de layout. Coloque elementos visuais compartilhados e formatação comum no slide master e coloque os marcadores de conteúdo nos layouts que os slides normais utilizarão.

**Posso excluir um slide master que ainda está em uso?**

Não. Um slide master que possui slides dependentes não pode ser removido com segurança diretamente. Primeiro mova esses slides para layouts sob outro master ou use um método de limpeza que remova somente masters que não estejam em uso.