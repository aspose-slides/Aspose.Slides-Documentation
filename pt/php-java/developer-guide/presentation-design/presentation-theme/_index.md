---
title: Gerenciar Temas de Apresentação em PHP
linktitle: Tema da Apresentação
type: docs
weight: 10
url: /pt/php-java/presentation-theme/
keywords:
- tema do PowerPoint
- tema de apresentação
- tema de slide
- definir tema
- alterar tema
- gerenciar tema
- tema externo
- THMX
- cor do tema
- paleta adicional
- fonte do tema
- estilo do tema
- efeito do tema
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Domine temas de apresentação no Aspose.Slides para PHP via Java para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define um conjunto coordenado de cores, fontes, estilos de plano de fundo, preenchimentos, linhas e efeitos. Objetos sensíveis ao tema referem‑se a essas definições compartilhadas em vez de armazenar cada propriedade visual como um valor fixo, de modo que uma mudança de tema pode atualizar muitos objetos de uma só vez.

No Aspose.Slides, o tema ao nível da apresentação está disponível através de [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Uma apresentação também pode conter substituições de tema em níveis inferiores. Um mestre pode substituir o tema da apresentação através de [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/), enquanto um layout ou um slide individual pode substituir seu tema herdado através de [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). Na prática, o tema efetivo para um slide é resolvido por esta cadeia de herança: tema da apresentação, substituição do mestre, substituição do layout e substituição do slide.

![Componentes do tema: cores, fontes, estilos de plano de fundo e efeitos](theme-constituents.png)

As seções abaixo mostram os fluxos de trabalho de tema mais comuns: inspecionar um tema, alterar cores e fontes, copiar ou aplicar um tema, atualizar estilos de plano de fundo e efeitos, e ler valores efetivos após a herança e substituições terem sido resolvidas.

## **Inspecionar um Tema**

O objeto [MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) expõe o esquema de cores, o esquema de fontes e o esquema de formatos do tema através de [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), [MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) e [MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/). Inspecionar essas coleções antes de alterá‑las é especialmente útil quando uma apresentação vem de uma fonte externa, pois o número e o conteúdo das entradas de estilo podem variar.

O exemplo a seguir lê as propriedades principais do tema e relata quantos estilos de plano de fundo, preenchimento, linha e efeito estão armazenados no tema:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();

    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Se um arquivo usar múltiplos mestres, não presuma que cada slide tenha o mesmo tema efetivo. Inspecione o mestre associado ao slide e use o fluxo de trabalho de tema efetivo mostrado mais adiante neste artigo quando substituições de layout ou slide puderem estar presentes.

## **Alterar Cores do Tema**

Preenchimentos, linhas e texto sensíveis ao tema podem referir‑se a uma cor lógica da enumeração [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/). Quando você altera a entrada correspondente no [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/), todos os objetos que ainda referenciam aquela cor do tema são resolvidos contra o novo valor. Objetos que usam uma cor RGB direta não são alterados por uma atualização de cor do tema.

O exemplo completo a seguir cria uma forma que usa `Accent4`, altera a cor `Accent4` do tema para vermelho, salva a apresentação, reabre‑a e imprime a cor de preenchimento efetiva:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);

    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);

    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

Como o retângulo continua ligado a `Accent4`, sua cor visível torna‑se vermelha após a mudança do tema. Se você substituir a cor do esquema por uma cor direta na forma, alterações posteriores em `Accent4` não afetarão mais esse preenchimento.

### **Usar Cores da Paleta Adicional**

O PowerPoint gera variantes mais claras e mais escuras a partir de uma cor do tema aplicando transformações de cor. O Aspose.Slides expõe essas transformações através da enumeração [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/).

![Cores principais do tema e cores mais claras e mais escuras geradas a partir da paleta adicional](additional-palette-colors.png)

**1** – Cores principais do tema.

**2** – Variantes mais claras e mais escuras produzidas a partir das cores principais do tema.

O exemplo a seguir cria seis retângulos baseados em `Accent4`, aplica transformações de luminância a cinco deles e salva o resultado:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Essas variantes permanecem baseadas na cor do tema. Se `Accent4` mudar posteriormente, as cores transformadas são recalculadas a partir do novo valor de `Accent4`.

### **Mapear Valores de `SchemeColor` para Slots de `ColorScheme`**

A enumeração [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) usa `Text1`, `Background1`, `Text2` e `Background2`, enquanto o [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) expõe os mesmos slots do tema como `Dark1`, `Light1`, `Dark2` e `Light2`. O mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Esses são nomes alternativos para os mesmos slots do tema; não são valores que são convertidos dinamicamente de uma forma para outra.

## **Alterar Fontes do Tema**

Um esquema de fontes do tema contém um conjunto principal de fontes para títulos e um conjunto secundário para o corpo do texto. Os métodos [FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) e [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) expõem esses conjuntos.

Identificadores de fontes de tema compatíveis com PowerPoint podem ser usados na formatação de texto:

* `+mn-lt` – Fonte do Corpo Latino (Minor Latin Font)
* `+mj-lt` – Fonte do Título Latino (Major Latin Font)
* `+mn-ea` – Fonte do Corpo Leste‑Asiático (Minor East Asian Font)
* `+mj-ea` – Fonte do Título Leste‑Asiático (Major East Asian Font)
* `+mn-cs` – Fonte do Corpo Script Complexo (Minor Complex Script Font)
* `+mj-cs` – Fonte do Título Script Complexo (Major Complex Script Font)

O exemplo a seguir cria um título que usa a fonte latina principal do tema e uma linha de corpo que usa a fonte latina secundária do tema. Em seguida, altera as fontes do tema e salva o resultado:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O título segue a fonte principal e o texto do corpo segue a fonte secundária. Texto que tem um nome de fonte explícito em vez de um identificador de tema não será trocado automaticamente quando o esquema de fontes do tema mudar.

As coleções de fontes principal e secundária também podem conter mapeamentos de fonte para sistemas de escrita individuais, como cirílico, árabe, japonês, georgiano e thaana. Para inspecionar, adicionar, substituir ou remover esses mapeamentos, veja [Script-Specific Theme Fonts](/slides/pt/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Para mais informações sobre fontes de apresentação, consulte [PowerPoint Fonts](/slides/pt/php-java/powerpoint-fonts/).
{{% /alert %}}

### **Resolver Referências de Fontes do Tema**

Ao inspecionar texto, [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) pode devolver uma referência de tema como `+mn-lt` em vez de um nome de família de fonte. Chame [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) com os dados de tema efetivo apropriados para resolver essa referência. Os prefixos `+mj` e `+mn` selecionam os conjuntos de fontes principal e secundário; os sufixos `-lt`, `-ea` e `-cs` selecionam, respectivamente, as fontes Latina, Leste‑Asiática e Script Complexo.

Obtenha o tema efetivo através de [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) no objeto cujo tema se aplica ao texto inspecionado. Para texto comum em um slide, chame esse método no slide para que o contexto inclua o tema herdado desse slide e as substituições locais. Ao inspecionar um layout ou um mestre, use o seu próprio tema efetivo. Não presuma que o tema do primeiro mestre se aplica a todos os slides.

O exemplo a seguir cria uma porção de texto que referencia explicitamente a fonte latina secundária. Ele inicializa um esquema de fontes de slide através de [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) e define as famílias latinas principal e secundária para `Arial` e `Calibri`, tornando o resultado reprodutível sem um arquivo de entrada.

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

A saída é `+mn-lt -> Calibri` seguida de `Verdana -> Verdana`. A referência armazenada permanece inalterada, enquanto um nome de família explícito é devolvido como está. Se a porção usasse `+mj-lt`, ela seria resolvida para `Arial` neste tema.

Resolver uma referência de tema identifica a família de fonte especificada pelo tema. Não verifica a disponibilidade da fonte nem determina o arquivo de fonte realmente usado após substituição ou fallback de glifos durante a renderização. Consulte [Font Selection Sequence](/slides/pt/php-java/font-selection-sequence/) e [Font Substitution](/slides/pt/php-java/font-substitution/) para essas etapas separadas.

## **Copiar ou Aplicar um Tema**

Os fluxos de trabalho abaixo resolvem diferentes problemas relacionados a temas.

### **Aplicar um Tema Externo aos Slides Dependentes de um Mestre**

Use [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) quando você possui um arquivo de tema do PowerPoint (`.thmx`) e deseja restilizar todos os slides que dependem de um determinado mestre. Selecione o mestre da coleção [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), que é representada por [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), e passe o caminho do arquivo de tema ao método.

O método executa as seguintes operações:

1. Cria um novo slide mestre baseado no mestre selecionado.
1. Aplica o tema externo ao novo mestre.
1. Atribui o novo mestre a todos os slides que anteriormente dependiam do mestre selecionado.
1. Retorna o [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) recém‑criado.

O exemplo a seguir aplica um tema externo aos slides que dependem do primeiro mestre e salva a apresentação:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;

    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Um tema inválido, corrompido ou não suportado pode causar [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/). Valide os caminhos fornecidos pelos usuários, trate falhas de acesso ao sistema de arquivos e salve a apresentação somente após o tema ter sido aplicado com sucesso.

Somente os slides que dependiam do mestre selecionado são reasignados. Slides associados a outros mestres mantêm seus mestres e temas existentes. Cores, fontes, preenchimentos, linhas, planos de fundo e efeitos sensíveis ao tema são resolvidos contra o tema externo. Cores, fontes, preenchimentos e outras formatações diretamente atribuídas podem permanecer inalteradas. Substituições ao nível de layout e slide também podem ter precedência sobre valores herdados do novo mestre.

O tema pode referenciar fontes que não estão disponíveis no ambiente de tempo de execução. Para renderização e exportação consistentes, instale as fontes necessárias, forneça‑as através de [fontes personalizadas](/slides/pt/php-java/custom-font/), ou configure [substituição de fontes](/slides/pt/php-java/font-substitution/).

Este é um fluxo de trabalho direto ao nível do mestre: o método aceita um caminho de arquivo `.thmx` e não requer a criação manual de substituições de tema ao nível de slide ou layout.

### **Aplicar Temas Externos Diferentes em uma Apresentação Multi‑Mestre**

Quando o mestre relevante não é conhecido antecipadamente, obtenha‑o a partir de um slide representativo via [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) e [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/). Armazene as referências originais dos mestres antes de aplicar quaisquer temas, pois cada chamada cria outro mestre na apresentação.

O exemplo a seguir usa slides de duas seções para localizar seus mestres e aplica um tema externo diferente a cada grupo:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;

            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

A primeira chamada afeta somente os slides que dependiam de `$firstGroupMaster`, e a segunda chamada afeta somente os slides que dependiam de `$secondGroupMaster`. Slides pertencentes a qualquer outro mestre não são restilizados.

### **Preservar o Tema de Origem ao Mover Slides**

Se você deseja mover um slide para outra apresentação e preservar seu design original, clone o mestre de origem na apresentação de destino com [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), então clone o slide com [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) e o mestre clonado. Isso transporta o mestre, seus layouts e o tema associado juntos.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);

        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);

        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);

        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Este é o fluxo de trabalho preferido quando o slide de origem deve permanecer igual no destino. Clonar apenas o conteúdo para um mestre de destino não relacionado pode mudar cores, fontes, planos de fundo e efeitos controlados pelo tema.

### **Aplicar Valores de Tema a um Slide Existente**

Se o slide de destino deve permanecer no seu mestre e layout atuais, inicialize uma substituição ao nível do slide a partir do tema de origem. Os métodos [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), [OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) e [OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) copiam os três principais componentes do tema para a substituição.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);

        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());

        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Isso altera o tema usado por aquele slide sem mudar o tema herdado por outros slides. Para remover a substituição local e voltar aos valores herdados, chame [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/).

### **Aplicar uma Substituição de Tema a um Layout**

Uma substituição ao nível de layout aplica‑se a slides que usam esse layout, a menos que um slide específico tenha sua própria substituição. Os mesmos métodos de inicialização podem ser usados através de [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());

        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Use um tema ao nível do mestre ou da apresentação quando muitos layouts e slides devem compartilhar o mesmo design base, uma substituição de layout quando uma família de layouts precisa de estilo diferente, e uma substituição de slide apenas para exceções reais. Substituições excessivas ao nível de slide tornam alterações globais de tema posteriores mais difíceis de prever.

## **Atualizar Estilos de Plano de Fundo do Tema**

Os preenchimentos de plano de fundo do tema são armazenados em [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). O PowerPoint pode apresentar mais opções de plano de fundo na UI do que o número de definições de preenchimento realmente armazenadas nessa coleção, pois a UI pode combinar preenchimentos de tema com cores de tema e outras referências de estilo.

![Galeria de estilos de plano de fundo do PowerPoint para um tema de apresentação](presentation-design_8.png)

Antes de usar um estilo de plano de fundo, inspecione a coleção armazenada e o índice de estilo atual de [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/). Um índice de estilo `0` significa que não há preenchimento temático; valores positivos são referências a estilos de plano de fundo do tema. Isso difere da indexação direta da coleção PHP, onde `get_Item(0)` indica o primeiro item armazenado. Não presuma que toda apresentação contenha o mesmo número de estilos de preenchimento de plano de fundo.

O exemplo a seguir relata a contagem de preenchimentos de plano de fundo disponíveis, atribui uma referência de plano de fundo temático ao primeiro mestre e salva a apresentação:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);

    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado visível depende da entrada de tema referenciada pelo mestre e de quaisquer substituições de plano de fundo no nível de layout ou slide. Se um slide usar seu próprio plano de fundo, mudar apenas o plano de fundo do mestre pode não alterar esse slide. Use [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) quando precisar saber o plano de fundo final após a aplicação da herança.

{{% alert color="warning" title="Warning" %}}
Não trate o índice de estilo como um índice de coleção base‑zero. Também evite codificar um número de estilo de um arquivo e presumir que ele tenha a mesma aparência em outro arquivo; as definições de estilo de tema são específicas da apresentação.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Para formatação direta de plano de fundo e herança de plano de fundo, veja [Presentation Background](/slides/pt/php-java/presentation-background/).
{{% /alert %}}

## **Atualizar Efeitos do Tema**

Um esquema de formatos de tema contém coleções distintas de preenchimento, linha e efeito expostas através de [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), [FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) e [FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). Temas típicos do Office costumam conter três entradas principais que correspondem visualmente a formatações sutil, moderada e intensa, mas o código deve inspecionar cada coleção em vez de assumir uma contagem fixa.

![Efeitos de tema sutil, moderado e intenso aplicados à mesma forma](presentation-design_10.png)

Ao acessar essas coleções em PHP, o índice da coleção é base‑zero: `get_Item(0)` é o primeiro estilo armazenado e `get_Item(2)` é o terceiro. Os índices de referência de estilo de uma forma são um conceito separado, exposto por [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/). Modificar um estilo de tema afeta formas que referenciam esse estilo; formas com formatação direta podem permanecer inalteradas.

O exemplo a seguir verifica se as entradas de estilo necessárias existem, altera o primeiro estilo de linha, altera o terceiro estilo de preenchimento, habilita uma sombra externa no terceiro estilo de efeito e salva o resultado:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);

    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para formas que referenciam esses slots, o primeiro estilo de linha do tema torna‑se vermelho, o terceiro estilo de preenchimento do tema torna‑se verde floresta sólido, e o terceiro estilo de efeito ganha uma sombra externa com distância de 10 pontos. O resultado visual exato ainda depende de quais slots de estilo cada forma referencia e se a formatação direta sobrescreve o tema.

![Estilos de efeito do tema após alterar linha, preenchimento e sombra](presentation-design_11.png)

## **Selecionar Estilos de Preenchimento e Linha do Tema para uma Forma**

Uma forma pode selecionar seu preenchimento e contorno independentemente através de [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) e [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex). Para ambos os métodos, o índice `1` seleciona a primeira entrada na coleção de tema correspondente (`get_Item(0)`), e o índice `2` seleciona a segunda (`get_Item(1)`).

O exemplo a seguir define dois estilos de preenchimento (ouro e azul‑celeste) e dois estilos de linha (azul escuro a 6 pt e vermelho escuro a 12 pt) no tema padrão de uma nova apresentação. Ele salva o slide em três estágios para que você possa comparar os resultados no PowerPoint.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Estilos iniciais | Alterar o contorno da direita | Editar o primeiro preenchimento do tema |
|:---:|:---:|:---:|
| ![Retângulos ouro e azul‑celeste com contornos finos azul escuro correspondentes](theme-style-initial.png) | ![O retângulo azul‑celeste agora tem um contorno vermelho escuro espesso](theme-style-line-changed.png) | ![O retângulo esquerdo agora está verde e ambos os contornos permanecem inalterados](theme-style-fill-changed.png) |

Selecionar um estilo de linha diferente altera somente o contorno do retângulo da direita. Editar o primeiro preenchimento do tema atualiza todas as formas que o utilizam. Aqui, apenas o retângulo esquerdo fica verde.

Em uma forma existente, uma cor de preenchimento local, cor de linha ou espessura de linha pode sobrescrever aquela parte do estilo de tema. Se mudar um índice de estilo não produzir efeito visível, verifique a [formatação direta](/slides/pt/php-java/shape-formatting/) da forma.

## **Determinar se um Preenchimento Sólido Efetivo Usa uma Cor de Tema**

Um preenchimento pode ser armazenado diretamente em um objeto ou herdado de um parágrafo, layout, mestre, estilo de tema ou outro nível de formatação. Chame [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) para resolver essa hierarquia em dados de preenchimento efetivo imutáveis. Primeiro verifique o resultado de `getFillType`. Só quando for `FillType::Solid` você deve ler as propriedades de preenchimento sólido.

Para um preenchimento sólido, `getSolidFillColor` devolve o valor RGB final renderizado após herança, busca no tema e aplicação de transformações de cor. O método `getSolidFillSchemeColor` devolve o slot lógico correspondente da [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/), como `Text1` ou `Accent6`. Um valor de `SchemeColor::NotDefined` significa que o preenchimento sólido efetivo não se baseia em uma cor de esquema. Em um fluxo onde preenchimentos são ou cores de tema ou cores RGB diretas, esse valor identifica um preenchimento RGB direto.

Não use somente o valor local de [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) para classificar um preenchimento. Por exemplo, uma porção de texto pode não ter cor de esquema definida localmente, então seu valor local é `NotDefined`, enquanto seu preenchimento efetivo herda uma cor de tema e resolve para `Text1` ou `Accent6`. Por outro lado, `getSolidFillSchemeColor` indica qual slot lógico de tema produziu a cor efetiva, mas não informa se esse slot veio do objeto, parágrafo, layout, mestre ou outro nível da hierarquia.

O exemplo a seguir carrega uma apresentação, audita preenchimentos de formas e de porções de texto, imprime cada valor RGB final e o esquema associado, e sinaliza preenchimentos sólidos que não acompanharão alterações nas cores do tema:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

O ramo `NotDefined` fornece uma lista de auditoria de preenchimentos sólidos que não responderão a mudanças nos slots de cor do tema. Revise esses objetos quando uma apresentação precisar seguir uma nova paleta de marca. O valor RGB reportado ainda mostra a aparência atual, enquanto o valor de esquema explica se essa aparência está conectada ao tema.

Objetos de formato efetivo são instantâneos. Após mudar o tema da apresentação, uma substituição de tema ou qualquer formatação herdada, chame `getEffective` novamente e leia os novos dados de preenchimento efetivo antes de comparar ou relatar cores.

## **Ler Valores Efetivos do Tema**

Objetos de tema bruto informam o que está definido em um nível específico. Valores efetivos mostram o que um slide ou forma realmente usa após a herança e substituições locais serem resolvidas. Para um slide, chame [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). Para um plano de fundo, use [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/), e para um preenchimento, use [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/).

O exemplo a seguir lê o tema efetivo, o plano de fundo e o primeiro preenchimento de forma de um slide:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();

    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;

    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Use dados efetivos para diagnóstico de renderização, validação e comparações. Se você inspecionar apenas [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), pode perder um mestre, layout, slide ou substituição de forma que altere a aparência final.

## **FAQ**

**Aplicar um tema externo afeta todos os slides da apresentação?**

Não. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) reatribui apenas os slides que dependem do mestre selecionado. Slides que usam outros mestres mantêm seus temas existentes.

**Posso aplicar um tema a um único slide sem mudar o mestre?**

Sim. Use o [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) do slide e inicialize sua substituição de tema. A alteração permanece local a esse slide; os demais slides continuam a herdar seus temas atuais.

**Qual é a maneira mais segura de transportar um tema de uma apresentação para outra?**

Ao mover um slide e preservar sua aparência de origem, clone o mestre de origem no destino e clone o slide com esse mestre usando [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) e [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/). Isso mantém o mestre, os layouts e o tema juntos.

**Como posso ver os valores efetivos após herança e substituições?**

Use [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) para um slide ou tema de layout e os métodos de dados efetivos correspondentes para objetos de formato, como [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) e [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/). Essas APIs retornam os valores resolvidos após a aplicação de herança e substituições.