---
title: Aplicar ou Alterar Layouts de Slide em PHP
linktitle: Layout de Slide
type: docs
weight: 60
url: /pt/php-java/slide-layout/
keywords:
- layout de slide
- layout de conteúdo
- marcador de posição
- design de apresentação
- design de slide
- layout não utilizado
- visibilidade do rodapé
- slide de título
- título e conteúdo
- cabeçalho de seção
- dois conteúdos
- comparação
- apenas título
- layout em branco
- conteúdo com legenda
- imagem com legenda
- título e texto vertical
- título vertical e texto
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Aplicar, criar e modificar layouts de slide no Aspose.Slides para PHP via Java, adicionar marcadores de posição, remover layouts não utilizados e controlar a visibilidade do rodapé."
---
## **Visão geral**

Um layout de slide define as posições e a formatação de marcadores de posição, como títulos, texto, imagens, gráficos e tabelas. Aplicar um layout fornece uma estrutura consistente aos slides, permitindo que cada slide contenha seu próprio conteúdo.

Os layouts mais comuns são:

- **Title Slide**: contém marcadores de posição de título e subtítulo.  
- **Title and Content**: contém um marcador de posição de título e um marcador de posição de conteúdo de uso geral.  
- **Blank**: não contém marcadores de posição de conteúdo e é útil quando todas as formas serão posicionadas manualmente.

## **Entender a herança de layout**

Uma apresentação possui três níveis relacionados:

1. Um [master slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslide/) define o tema, a formatação compartilhada, os fundos e os objetos comuns.  
1. Um [layout slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/) pertence a um master e define um arranjo específico de marcadores de posição.  
1. Um [normal slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/) usa um layout e armazena o conteúdo inserido naquele slide.

Um slide normal herda o tema e a formatação do seu layout, e o layout herda do seu master. Um valor definido diretamente em um slide normal substitui o valor herdado naquele nível. Quando um slide normal é criado, suas formas de marcador de posição são geradas a partir do layout selecionado, enquanto o conteúdo inserido nesses marcadores pertence ao slide normal.

Adicione os marcadores de posição necessários a um layout antes de criar slides a partir dele. Adicionar outro marcador de posição a um layout posteriormente não cria automaticamente a forma correspondente nos slides normais já existentes.

Essa relação tem duas consequências importantes:

- Alterar a formatação herdada ou a geometria de marcadores de posição existentes em um layout pode atualizar todos os slides que dependem dele. Antes de editar um layout que já está em uso, verifique seus slides dependentes e reveja a apresentação resultante.  
- Um layout que ainda está sendo usado por um slide não pode ser removido. Reatribua seus slides dependentes a outro layout primeiro, ou remova apenas os layouts não utilizados.

Para mais informações sobre o nível superior desta hierarquia, veja [Slide Master](/slides/pt/php-java/slide-master/).

Para ocultar logos herdados ou formas decorativas do master em um slide ou por meio de um layout compartilhado, veja [Control the Visibility of Master Graphics](/slides/pt/php-java/slide-master/). O exemplo compara dois slides que usam o mesmo master.

## **Selecionar e aplicar um layout de slide**

Use um tipo de layout quando a apresentação segue definições padrão de layout do PowerPoint. Os nomes dos layouts são editáveis pelo usuário e podem ser localizados, portanto a seleção baseada em nome é menos confiável, a menos que você controle o modelo de origem.

O exemplo a seguir procura **Title and Content** no primeiro master. Se esse layout não estiver disponível, ele recorre deliberadamente a **Blank**. A segunda verificação de nulidade é necessária porque uma apresentação pode conter apenas layouts personalizados. O layout selecionado é então aplicado ao primeiro slide normal através do método [Slide.setLayoutSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#setLayoutSlide).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Alterar o layout de um slide não remove as formas normais adicionadas diretamente ao slide. Contudo, as posições dos marcadores de posição, a formatação herdada e a correspondência entre marcadores de posição existentes e o novo layout podem mudar, portanto examine a saída ao alternar entre layouts substancialmente diferentes.

## **Adicionar um Layout Slide**

Seleção e criação são operações separadas. O exemplo anterior seleciona um layout existente; ele não o cria. Para criar um layout, chame o método [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterlayoutslidecollection/#add) na coleção de layouts do master de destino.

O exemplo a seguir sempre adiciona um novo layout **Title and Content** chamado `Report Title and Content`, depois adiciona um slide normal baseado nele. Os nomes dos layouts devem ser exclusivos dentro da coleção.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Adicione um layout somente quando o modelo realmente precisar de outra estrutura reutilizável. Se já existir um layout adequado, selecione‑o e reutilize‑lo em vez de criar um duplicado.

## **Adicionar marcadores de posição a um Layout Slide**

O método [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/#getPlaceholderManager) fornece um [LayoutPlaceholderManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutplaceholdermanager/) para adicionar formas de marcador de posição a um layout.

| PowerPoint Placeholder              | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![Content](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                 | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

O exemplo a seguir verifica se o layout **Blank** existe, adiciona quatro marcadores de posição a ele e então cria um slide normal que usa o layout modificado. A ordem é intencional: os marcadores de posição são adicionados antes da criação do slide normal, para que o Aspose.Slides possa gerar as formas de marcador correspondentes naquele slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Alterar a formatação herdada ou a geometria dos marcadores de posição existentes em um layout pode afetar slides dependentes. Um marcador de posição de layout recém‑adicionado não é retroativo em slides normais existentes. Teste alterações de layout em uma cópia da apresentação e inspecione cada slide dependente.
{{% /alert %}}

## **Remover Layout Slides não utilizados**

Use o método [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) para remover layouts que nenhum slide normal referencia. O método mantém intactos os layouts que ainda estão em uso.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para remover um layout específico, primeiro use seu método [hasDependingSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/#hasDependingSlides) ou [getDependingSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/#getDependingSlides). Reatribua quaisquer slides dependentes antes de chamar [LayoutSlide.remove](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/#remove). Tentar remover um layout em uso gera uma [PptxEditException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxeditexception/).

## **Controlar a visibilidade do rodapé em um Layout Slide**

Um layout tem seus próprios marcadores de posição de rodapé, número do slide e data/hora. Use o método [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) para controlar esses marcadores em um layout. Isso é útil, por exemplo, quando layouts de conteúdo devem exibir rodapés, mas layouts de título não.

O exemplo a seguir seleciona um layout de forma segura e torna seus elementos de rodapé visíveis:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Controlar a visibilidade do rodapé em um Master e em seus Layouts filhos**

Para aplicar configurações de rodapé consistentes em toda a hierarquia de masters, use o método [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Os métodos de propagação de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/php-java/aspose.slides/masterslideheaderfootermanager/) atuam no master e em seus slides de layout dependentes e slides normais; eles não visam apenas um slide normal.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Qual a diferença entre um Master Slide e um Layout Slide?**

Um master slide define o tema da apresentação e a formatação compartilhada. Um layout slide pertence a um master e define um arranjo reutilizável de marcadores de posição. Slides normais usam esses layouts e armazenam o conteúdo específico de cada slide.

**Posso copiar um Layout Slide de uma apresentação para outra?**

Sim. Adicione uma cópia à coleção de destino com o método [addClone](https://reference.aspose.com/slides/pt/php-java/aspose.slides/globallayoutslidecollection/#addClone). Ao copiar entre apresentações, verifique também fontes, temas, imagens e outros recursos usados pelo layout de origem.

**O que acontece se eu modificar um layout que já está em uso?**

Slides dependentes herdam as alterações do layout, a menos que sobrescrevam a formatação ou os objetos afetados localmente. A geometria dos marcadores de posição e o estilo herdado podem, portanto, mudar em muitos slides de uma vez. Use [getDependingSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/#getDependingSlides) para identificar os slides afetados antes de editar o layout.

**O que acontece se eu remover um layout que ainda está em uso?**

O Aspose.Slides lança uma [PptxEditException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxeditexception/). Reatribua primeiro os slides dependentes ou use [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) para remover apenas layouts não referenciados.