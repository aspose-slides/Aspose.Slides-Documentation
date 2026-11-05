---
title: Formatar Formas PowerPoint em PHP
linktitle: Formatação de Forma
type: docs
weight: 20
url: /pt/php-java/shape-formatting/
keywords:
- formatar forma
- formatar linha
- efeito de esboço
- linha de forma esboçada
- formatar estilo de junção
- preenchimento gradiente
- preenchimento de padrão
- preenchimento de imagem
- preenchimento de textura
- preenchimento de cor sólida
- transparência de forma
- renderização de forma em preto e branco
- renderização de forma em escala de cinza
- rotacionar forma
- efeito de bisel 3D
- efeito de rotação 3D
- redefinir formatação
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a formatar formas PowerPoint em PHP usando Aspose.Slides — defina estilos de preenchimento, linha e efeito para arquivos PPT e PPTX com precisão e controle total."
---
## **Introdução**

Formate formas no PowerPoint ajustando seus contornos, preenchimentos e efeitos. Aspose.Slides para PHP via Java permite controlar essas configurações programaticamente, incluindo transparência, rotação e formatação 3D.

![Opções de formatação de forma no PowerPoint](format-shape-powerpoint.png)

Aspose.Slides para PHP via Java fornece classes e métodos que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar Linhas**

Use [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) para controlar o contorno de uma forma. Este exemplo cria um retângulo sem preenchimento com um contorno azul tracejado. [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) seleciona uma linha composta espessa‑fina, enquanto [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) define sua largura para 7 pontos e [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) seleciona o padrão de traço.

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![As linhas formatadas na apresentação](formatted-lines.png)

### **Definir Padrões de Traço de Linha Personalizados**

Use [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) quando os estilos de linha predefinidos não fornecem os comprimentos de traço e lacunas que você precisa, por exemplo para contornos de marca ou diagramas técnicos. A atribuição de um padrão altera automaticamente o estilo de traço da linha para [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/).

As entradas do array alternam entre comprimentos de traço e lacuna, começando com um traço. Cada valor é um múltiplo da largura da linha: `[4, 2]` com largura de 3 pontos produz um traço de 12 pontos seguido por uma lacuna de 6 pontos. Use pares de valores finitos e não negativos para definir segmentos completos de traço e lacuna. O exemplo usa valores positivos para manter cada traço e lacuna visíveis.

Este exemplo cria cinco linhas azuis com o mesmo comprimento e pontas planas. As três primeiras comparam padrões com largura de 3 pontos. A quarta repete o primeiro padrão em dobro da largura, dobrando tanto os comprimentos de traço quanto de lacuna. A quinta muda de um padrão personalizado para uma linha sólida.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // Retornar a última linha para um estilo sólido.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para voltar a um estilo tracejado predefinido, passe [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) para [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle). O estilo selecionado controla a aparência da linha.

O resultado no PowerPoint, de cima para baixo: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; e **Solid, 3 pt**.

![Três padrões de traço personalizados, uma linha mais larga usando o primeiro padrão e uma linha sólida no PowerPoint](custom-dash-patterns.png)

### **Definir Pontas de Linha**

Use [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) para definir as extremidades de uma linha aberta. A classe [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) fornece três estilos de ponta explícitos:

- `Flat`: O traço termina no ponto final.
- `Round`: Uma ponta semicircular estende‑se além do ponto final em metade da largura da linha.
- `Square`: Uma ponta quadrada estende‑se além do ponto final em metade da largura da linha.

A classe também inclui `NotDefined`, que significa que nenhum estilo de ponta foi explicitamente atribuído.

Pontas são diferentes de pontas de seta, que adicionam símbolos às extremidades da linha, e de junções, que controlam cantos entre segmentos de linha. Este exemplo desabilita pontas de seta através de [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) e [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) para que apenas as formas de ponta sejam comparadas.

O exemplo a seguir cria três linhas horizontais, de outra forma idênticas, com 20 pontos de largura. De cima para baixo, elas usam pontas planas, arredondadas e quadradas. Seus pontos finais têm as mesmas coordenadas horizontais; as pontas arredondadas e quadradas se estendem 10 pontos além de cada ponto final.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado no PowerPoint, de cima para baixo: **Flat**, **Round** e **Square**.

![Pontas planas, arredondadas e quadradas em linhas espessas idênticas no PowerPoint](line-caps.png)

## **Aplicar Efeitos de Esboço às Linhas de Forma**

Um efeito de esboço faz a linha de uma forma parecer desenhada à mão. Use [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) para acessar as configurações de linha, [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) para acessar as configurações de esboço e [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) para selecionar um valor da classe [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

O código PHP a seguir demonstra como aplicar um efeito [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/), ler o valor atribuído explicitamente e remover o efeito com [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

O valor retornado por [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) representa a configuração atribuída diretamente à forma. Se a formatação da linha puder ser herdada de um tema, slide mestre ou slide de layout, use [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective), acesse o método `getSketchFormat` do objeto retornado e leia seu valor `getSketchType`. O valor efetivo reflete a formatação realmente aplicada após a herança ser resolvida. Este exemplo requer uma apresentação existente com pelo menos uma forma no primeiro slide e imprime ambos os valores:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $lineFormat = $shape->getLineFormat();
    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Formatar Estilos de Junção**

Aqui estão as três opções de tipo de junção:

* Round
* Miter
* Bevel

O estilo de junção controla como dois segmentos de contorno se encontram em um canto. Use **Round** para cantos arredondados, **Miter** para cantos pontiagudos ou **Bevel** para cantos achatados.

![O estilo de junção na apresentação](join-style-powerpoint.png)

Este exemplo cria três retângulos pretos com contornos azuis de 15 pontos de largura. Ele define [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) para os valores miter, bevel e round de [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/), respectivamente, para comparar como os cantos são desenhados.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Limitar Junções Miter em Cantos Pontiagudos**

Use [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) com [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) definido como [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) para limitar até onde um canto pontiagudo pode se estender.

O limite é uma proporção entre a distância entre os cantos interno e externo da junção e a largura da linha. Por exemplo, um valor de `8` permite um comprimento de miter de até oito vezes a largura da linha; não é uma medida em pontos. Se o canto exceder o limite, o PowerPoint usa uma junção chanfrada naquele canto. Um limite maior permite pontos mais agudos. A configuração afeta apenas junções miter, e alterá‑la não tem efeito visível quando o canto permanece dentro dos limites.

Este exemplo cria dois triângulos idênticos, sem preenchimento, com contornos de 20 pontos de largura. O triângulo da esquerda usa um limite de `2` e o da direita usa `8`. Cada triângulo tem 80 pontos de largura e 160 pontos de altura, proporcionando ao seu canto superior uma proporção comprimento‑miter‑para‑largura da linha de aproximadamente `4.12`. Consequentemente, o PowerPoint chanfrar o ápice esquerdo e preservar o ápice direito.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado no PowerPoint: **Miter limit 2** à esquerda e **miter limit 8** à direita.

![Um ápice chanfrado com limite miter 2 e um ápice pontiagudo com limite miter 8 no PowerPoint](miter-limits.png)

## **Preenchimento Gradiente**

Um preenchimento gradiente mistura cores ao longo de uma forma. Este exemplo preenche uma elipse com um gradiente linear em um ângulo de 45 graus de vermelho para roxo usando [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat). O método [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) posiciona as paradas de cor em 0 e 1, o início e o fim do gradiente. Limpar as paradas existentes garante que apenas essas duas cores sejam usadas.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![A elipse com preenchimento gradiente](gradient-fill.png)

Se um gradiente parecer diferente em uma imagem exportada do que no PowerPoint, consulte [Choose a Gradient Rendering Style](/slides/pt/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Você pode selecionar um estilo de renderização sem alterar o preenchimento gradiente armazenado na apresentação.

### **Definir o Ângulo do Gradiente Linear**

Use [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) para controlar a orientação de um preenchimento [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/). O ângulo é medido em graus e aumenta no sentido horário: `0` vai da esquerda para a direita, `90` de cima para baixo, `180` da direita para a esquerda e `270` de baixo para cima. Ângulos fracionários são suportados. Ângulos finitos fora de `[0, 360)` são normalizados para uma revolução; por exemplo, `-45` torna‑se `315` e `360` torna‑se `0`.

Este exemplo cria seis retângulos com paradas de cor vermelho, verde e azul idênticas nas posições `0`, `0.5` e `1`. O dimensionamento está desativado para que o ângulo possa ser comparado independentemente das proporções dos retângulos. Os ângulos, da esquerda para a direita, são `0`, `45` e `90` na primeira linha, e `135`, `180` e `270` na segunda linha.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado no PowerPoint:

![Gradientes lineares em 0, 45 e 90 graus na linha superior, e 135, 180 e 270 graus na linha inferior](linear-gradient-angles.png)

### **Dimensionar um Gradiente Linear com a Forma**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) aceita um valor [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/). Defina‑o explicitamente como `False` para manter o ângulo geométrico do gradiente conforme as proporções da forma mudam, ou como `True` para dimensionar o gradiente com a largura e altura da forma. Com o dimensionamento ativado, o ângulo visível pode diferir do ângulo atribuído em uma forma não quadrada.

O exemplo a seguir usa um ângulo de `45` graus e as mesmas paradas de cor da comparação de ângulo. A coluna da esquerda usa `False`; a coluna da direita usa `True`. Cada coluna contém um retângulo largo acima de um retângulo alto. Ambos começam com as mesmas dimensões largas; mudar a largura e altura do segundo retângulo demonstra como o preenchimento responde ao redimensionamento sem alterar suas configurações de gradiente.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado no PowerPoint, com dimensionamento desativado à esquerda e ativado à direita:

![Retângulos largos e altos com um gradiente de 45 graus, comparando LinearGradientScaled False à esquerda com True à direita](linear-gradient-scaling.png)

Com o dimensionamento desativado, as faixas de cor diagonais mantêm a mesma orientação em ambos os retângulos. Com o dimensionamento ativado, as faixas se esticam com as proporções da forma. Isso ajuda a reproduzir o gradiente de um modelo ao adaptar uma forma a um tamanho diferente. Em um quadrado, ativar o dimensionamento não altera a aparência deste gradiente de `45` graus.

Tanto o ângulo quanto as configurações de dimensionamento se aplicam a gradientes lineares. Elas não controlam preenchimentos [GradientShape::Radial ou GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/).

### **Combinar o Ângulo com a Direção do Gradiente**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) seleciona um estilo de gradiente da classe [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/); não substitui um ângulo numérico. Para um gradiente linear, os estilos de canto podem mudar a área onde as cores são distribuídas sem mudar o ângulo atribuído através de [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle). Mantenha a direção inalterada ao comparar ângulos ou dimensionamento.

O exemplo a seguir aplica as mesmas configurações em ordens opostas. Os dois retângulos têm a mesma aparência: atribuir a direção antes ou depois do ângulo não altera o resultado.

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Preenchimento de Padrão**

Um preenchimento de padrão aplica um desenho bicolor, como pontos, listras ou quadriculados. Este exemplo usa [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) para selecionar um padrão de treliça. [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) fornece o fundo cinza claro, e [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) fornece a cor amarela do padrão.

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![O retângulo com preenchimento de padrão](pattern-fill.png)

## **Preenchimento de Imagem**

Um preenchimento de imagem usa uma imagem dentro de uma forma. Este exemplo requer uma imagem local e usa [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) para carregá‑la na coleção de imagens da apresentação. Definir [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) para o modo em mosaico repete a imagem dentro do retângulo. A imagem fonte usada aqui é mostrada abaixo:

![A imagem da flor de lótus](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![A forma com preenchimento de imagem](picture-fill.png)

### **Repetir Imagem como Textura**

Se você quiser definir uma imagem em mosaico como textura e personalizar o comportamento do mosaico, pode usar os seguintes métodos da classe [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Define o modo de preenchimento da imagem — `Tile` ou `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Especifica o alinhamento dos mosaicos dentro da forma.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Controla se o mosaico é espelhado horizontalmente, verticalmente ou em ambas as direções.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Define o deslocamento horizontal do mosaico (em pontos) a partir da origem da forma.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Define o deslocamento vertical do mosaico (em pontos) a partir da origem da forma.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Define a escala horizontal do mosaico como porcentagem.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Define a escala vertical do mosaico como porcentagem.

Este exemplo requer uma imagem local e configura [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) para repeti‑la a 50 % do tamanho original. Deslocamentos de −32 pontos movem os mosaicos horizontal e verticalmente; o alinhamento inferior‑direito e o espelhamento em ambas as direções determinam como a textura repetida é disposta.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![As opções de mosaico](tile-options.png)

## **Preenchimento Sólido**

Um preenchimento sólido dá a uma forma uma única cor uniforme. Este exemplo define [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) para o modo de preenchimento sólido e atribui amarelo através de [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor), então salva o retângulo em uma apresentação.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![A forma com preenchimento de cor sólida](solid-color-fill.png)

### **Copiar Cores Preservando Referências de Tema**

Use [ColorFormat::copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#copyFrom) para copiar uma definição de cor, incluindo seu tipo de cor, referência de tema e transformações. Isso é útil ao transferir a cor de preenchimento entre formas que devem continuar seguindo o tema da apresentação. O método copia apenas a cor: não copia o tipo de preenchimento, contorno ou outra formatação da forma. Defina o tipo de preenchimento do destino explicitamente com [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType).

Este exemplo cria três retângulos, da esquerda para a direita: a fonte, uma cópia consciente do tema e uma cópia RGB fixa. A fonte usa [ColorFormat::setSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setSchemeColor) para referenciar a primeira cor de destaque e adiciona um matiz através de [ColorOperationCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/coloroperationcollection/#add). A cópia RGB usa a cor de preenchimento efetiva da fonte, de modo que os três inicialmente pareçam idênticos. Chamar [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) define um valor RGB fixo e limpa quaisquer transformações de cor existentes.

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(660, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $initialAccent = new Java("java.awt.Color", 65, 105, 225);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($initialAccent);

    $source = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
    $themeCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
    $rgbCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

    foreach ([$source, $themeCopy, $rgbCopy] as $shape) {
        $shape->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $sourceColor = $source->getFillFormat()->getSolidFillColor();
    $sourceColor->setSchemeColor(SchemeColor::Accent1);
    $sourceColor->getColorTransform()->add(ColorTransformOperation::Tint, 0.75);

    $themeCopy->getFillFormat()->getSolidFillColor()->copyFrom($sourceColor);
    $rgbCopy->getFillFormat()->getSolidFillColor()->setColor($source->getFillFormat()->getEffective()->getSolidFillColor());

    $before = $slide->getImage(1.0, 1.0);
    try {
        $before->save("color-copy-before.png", ImageFormat::Png);
    } finally {
        $before->dispose();
    }

    // As referências ao tema acompanham a nova cor de destaque; o valor RGB fixo não.
    $updatedAccent = new Java("java.awt.Color", 255, 69, 0);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($updatedAccent);

    $after = $slide->getImage(1.0, 1.0);
    try {
        $after->save("color-copy-after.png", ImageFormat::Png);
    } finally {
        $after->dispose();
    }
    $presentation->save("copied_colors.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Antes da mudança de tema, os três preenchimentos coincidem:

![Origem, destino copyFrom e destino RGB fixo com preenchimentos azuis idênticos](color-copy-before.png)

Após a mudança de tema, a origem e a cópia consciente do tema seguem a nova cor de destaque e mantêm seu matiz. A cópia RGB fixa permanece azul:

![Origem e destino copyFrom com preenchimentos laranja, enquanto o destino RGB fixo permanece azul](color-copy-after.png)

A definição copiada é independente da origem. Alterar posteriormente a referência de tema da origem, atribuir outra cor ou adicionar ou remover suas transformações não altera o destino. Uma mudança de tema ainda afeta ambas as formas porque cada uma referencia independentemente a mesma cor de tema.

Salvar e reabrir o PPTX preserva o tipo da cor copiada retornado por [ColorFormat::getColorType](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorType), a referência de tema e a coleção de transformações retornada por [ColorFormat::getColorTransform](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorTransform); não converte a definição para RGB.

Ao copiar entre contextos de tema diferentes, como apresentações com paletas de destaque distintas, a referência copiada é resolvida contra o tema do destino. A mesma referência e transformações podem, portanto, produzir uma cor visível diferente. Consulte [Presentation Theme](/slides/pt/php-java/presentation-theme/) para saber mais sobre a configuração de cores de tema.

## **Usar o Plano de Fundo do Slide como Preenchimento de Forma**

Use [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) quando uma forma deve corresponder ao plano de fundo do slide, por exemplo em um modelo de apresentação. Defina o tipo de preenchimento com [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) para [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) primeiro para remover qualquer preenchimento explícito. Com essa combinação, a forma usa o plano de fundo do slide em vez do seu preenchimento de estilo. Habilitar apenas a flag não remove um preenchimento explícito existente.

Isso difere de [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/): o preenchimento de fundo cobre objetos atrás da forma com a área correspondente do plano de fundo do slide, enquanto sem preenchimento esses objetos permanecem visíveis. Um gradiente permanece alinhado ao slide em vez de reiniciar dentro de cada forma.

O exemplo a seguir cria um plano de fundo mestre herdado pelo slide e coloca uma faixa magenta atrás de três retângulos. O retângulo da esquerda usa o plano de fundo, o do meio não tem preenchimento e o da direita alterna do preenchimento de fundo para um preenchimento laranja explícito.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // Herda o gradiente do mestre.
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // Adicione este objeto primeiro para que ele apareça atrás dos retângulos.
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // Desabilite o preenchimento de plano de fundo antes de aplicar um preenchimento explícito.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado, da esquerda para a direita: **background fill**, **no fill**, e **explicit fill**. A faixa magenta está oculta pelos retângulos da esquerda e da direita, mas permanece visível através do retângulo do meio.

![Preenchimento de fundo, sem preenchimento e preenchimento laranja explícito sobre uma faixa magenta](background-fill.png)

O mesmo comportamento se aplica a um fundo definido diretamente no slide ou herdado de um layout. A forma usa o fundo resolvido do slide; o exemplo deixa os fundos do slide e do layout indefinidos para que o mestre o forneça.

## **Definir Transparência**

Para um preenchimento sólido, o componente alfa da cor controla a opacidade: 0 é totalmente transparente e 255 é totalmente opaco. Este exemplo usa um valor alfa de 128 para um retângulo amarelo, tornando‑o aproximadamente 50 % transparente para que o retângulo abaixo permaneça visível. A cor é atribuída através de [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor).

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![A forma transparente](shape-transparency.png)

## **Rotacionar Formas**

Use [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) para rotacionar uma forma no plano do slide. O ângulo é medido em graus; este exemplo rotaciona um retângulo 5 graus no sentido horário e salva a apresentação.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![A rotação da forma](shape-rotation.png)

## **Adicionar Efeitos de Bisel 3D**

Use [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) para dar a uma forma profundidade e bordas chanfradas. Este exemplo cria uma elipse verde com contorno laranja, define [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) para 4 pontos e aplica um bisel superior circular com largura e altura de 6 pontos através de [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop). Uma câmera ortográfica de frente e iluminação de três pontos tornam o bisel visível.

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![O efeito de bisel 3D](3D-bevel-effect.png)

## **Adicionar Efeitos de Rotação 3D**

A visualização 3D de uma forma é controlada pelas configurações da câmera. Este exemplo usa [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) com ângulos de latitude, longitude e revolução de 40, 35 e 20 graus, respectivamente. Ele seleciona uma câmera isométrica através de [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) e iluminação balanceada através de [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType), depois salva o retângulo formatado.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![O efeito de rotação 3D](3D-rotation-effect.png)

## **Controlar Renderização em Preto e Branco para Formas**

O método [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) especifica como uma forma individual é renderizada quando uma apresentação é visualizada ou processada em modo preto e branco. Ele não habilita a exibição em preto e branco por si só, nem altera o preenchimento, contorno ou outra formatação da forma no modo de cor normal.

Use um valor da classe [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) para selecionar o comportamento desejado. Por exemplo, `Automatic` deixa o aplicativo de renderização escolher a conversão, `Gray` e `LightGray` usam coloração cinza, `BlackWhite` usa apenas preto e branco, `Black` e `White` forçam uma única cor, `Color` preserva a coloração normal e `Hidden` omite a forma no modo preto e branco. `NotDefined` significa que nenhum modo a nível de forma foi atribuído.

Este exemplo cria um retângulo laranja e define [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) para cinza. A forma salva mantém seu preenchimento laranja para visualização em cor normal e solicita coloração cinza de aplicativos que respeitam as configurações de exibição em preto e branco:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Em modo de cor normal, o retângulo mantém seu preenchimento laranja. Em um fluxo de trabalho de exibição em preto e branco, ele usa coloração cinza porque seu modo está definido como `Gray`. Isso permite preservar um slide em cores completas enquanto define uma aparência distinta para impressão, visualização ou outros fluxos de trabalho que respeitam as configurações de exibição em preto e branco da apresentação.

## **Redefinir Formatação**

Use [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) para restaurar a posição, tamanho e formatação dos marcadores de posição do slide a partir dos marcadores de posição correspondentes do layout. Este exemplo requer uma apresentação existente com marcadores de posição vinculados ao layout e redefine cada slide antes de salvar. Formas sem marcadores de posição correspondentes no layout não são redefinidas.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**A formatação de formas afeta o tamanho final do arquivo da apresentação?**

Cores, estilos de linha e configurações de efeito geralmente adicionam poucos dados comparados com imagens e mídia incorporadas. Preenchimentos de imagem podem aumentar o tamanho do arquivo porque suas imagens são armazenadas na apresentação.

**Como posso detectar formas em um slide que compartilham formatação idêntica para poder agrupá‑las?**

Compare as principais propriedades de formatação de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, considere seus estilos como idênticos e agrupe logicamente essas formas, o que simplifica o gerenciamento de estilos posterior.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilizar em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um deck de slides modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas que precisar e reaplique sua formatação onde for necessário.