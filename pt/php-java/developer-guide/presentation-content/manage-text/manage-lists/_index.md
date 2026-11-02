---
title: Gerenciar Listas com Marcadores e Numeradas em Apresentações Usando PHP
linktitle: Gerenciar Listas
type: docs
weight: 60
url: /pt/php-java/manage-lists/
keywords:
- marcador
- lista com marcadores
- lista numerada
- marcador de símbolo
- marcador de imagem
- marcador personalizado
- lista multinível
- criar marcador
- adicionar marcador
- adicionar lista
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como criar e formatar listas com marcadores, de imagem, multiníveis e numeradas em apresentações PowerPoint e OpenDocument usando Aspose.Slides for PHP via Java."
---
## **Visão geral**

Aspose.Slides for PHP via Java permite criar e formatar listas com marcadores e numeradas em apresentações PowerPoint e OpenDocument. Um item de lista é um parágrafo cujas configurações de marcador são controladas por seu formato de parágrafo.

Use o método [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat) para acessar as configurações de lista no nível do parágrafo. O ponto de entrada principal é [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet), que retorna um objeto [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/). Com esse objeto, você pode definir o tipo de marcador, símbolo, imagem, cor, tamanho, estilo de numeração e número inicial.

Este artigo mostra como:

- criar uma lista com marcadores usando um símbolo personalizado
- criar um marcador de imagem
- criar uma lista multinível definindo a profundidade do parágrafo
- criar uma lista numerada
- inspecionar e alterar a formatação de lista em uma apresentação existente
- ler os marcadores e números reais da lista ao lado do texto do parágrafo

## **Criar uma lista com marcadores**

Para criar uma lista com marcadores, adicione objetos [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) a um [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) e defina [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) para [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol). Em seguida, você pode definir [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar), [BulletFormat::getColor](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getColor) e [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) para controlar a aparência do marcador.

O código PHP a seguir demonstra como criar uma lista com marcadores em um slide:

```php
use aspose\slides\BulletType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![Os marcadores de símbolo](symbol_bullets.png)

## **Criar uma lista numerada**

Use listas numeradas quando a ordem dos itens for importante. Defina [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) para [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Numbered). Você também pode escolher um formato de numeração com [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) ou definir [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) quando a lista deve iniciar a partir de um valor diferente de 1.

O código PHP a seguir mostra como criar uma lista numerada em um slide:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![Os marcadores numerados](numbered_bullets.png)

## **Criar um marcador de imagem**

Aspose.Slides permite substituir um símbolo de marcador regular por uma imagem. Marcadores de imagem funcionam melhor com imagens simples que permanecem legíveis em tamanho pequeno, como ícones ou arquivos PNG transparentes.

{{% alert color="info" title="Note" %}}
Idealmente, se você planeja substituir o símbolo de marcador regular por uma imagem, é melhor escolher um gráfico simples com fundo transparente. Essas imagens funcionam bem como símbolos de marcador personalizados.

Tenha em mente que a imagem será redimensionada para um tamanho muito pequeno. Por esse motivo, recomendamos fortemente selecionar uma imagem que permaneça clara e visualmente eficaz quando usada como marcador em uma lista.
{{% /alert %}}

Para criar um marcador de imagem, adicione uma imagem a [Presentation::getImages](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getImages) e atribua o objeto [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) retornado a [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture). Defina [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) para [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture) antes de atribuir a imagem.

Vamos supor que temos um “image.png”:

![Uma imagem para os marcadores](picture_for_bullets.png)

O código PHP a seguir mostra como criar marcadores de imagem em um slide:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![Os marcadores de imagem](picture_bullets.png)

## **Criar uma lista multinível**

Use [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) para colocar itens de lista em diferentes níveis. O nível 0 é o nível superior, o nível 1 está aninhado abaixo dele e assim sucessivamente.

O código PHP a seguir mostra como criar uma lista com marcadores multiníveis:

```php
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![A lista multinível](multilevel_list.png)

## **Alterar uma lista existente**

Para mudar a formatação de lista em uma apresentação existente, acesse o parágrafo-alvo e atualize suas configurações de [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet). As mesmas propriedades usadas para criar listas podem ser usadas para inspecionar ou modificar listas carregadas de um arquivo PPT, PPTX ou ODP.

O código PHP a seguir altera o primeiro parágrafo em um quadro de texto para usar um estilo de lista numerada:

```php
use aspose\slides\BulletType;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ler valores reais de marcadores**

Ao extrair conteúdo de uma apresentação, mantenha os marcadores da lista ao lado do texto do parágrafo. Chame [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getEffective) e acesse [ParagraphFormatEffectiveData::getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) para obter o formato de marcador efetivo. Verifique seu [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) antes de ler [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--).

Para listas numeradas, distinga estes três valores:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) determina o formato, como números arábicos seguidos de ponto ou letras minúsculas seguidas de ponto.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) especifica o número inicial para um grupo de parágrafos numerados.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) devolve o marcador formatado para um parágrafo específico. Por exemplo, o segundo item em uma lista iniciando em 5 devolve `6.`.

Preserve [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDepth) com cada parágrafo para manter seu nível de aninhamento. O marcador real não codifica a hierarquia completa: um item aninhado pode devolver `c.` em vez de um rótulo combinado como `6.c.`.

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 440, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20, 660, 400);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    // Criar um marcador de imagem sem um arquivo de imagem externo.
    $svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    $bulletImage = $presentation->getImages()->addImage($svg);

    $black = new Java("java.awt.Color", 0, 0, 0);
    $addParagraph = function ($text, $depth, $type, $start, $style) use ($textFrame, $bulletImage, $black) {
        $paragraph = new Paragraph();
        $paragraph->setText($text);

        $format = $paragraph->getParagraphFormat();
        $format->setDepth($depth);
        $format->setMarginLeft(30 + $depth * 40);
        $format->setIndent(-28);
        $format->setSpaceAfter(8);
        $format->getDefaultPortionFormat()->setFontHeight(22);
        $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $format->getBullet()->setType($type);
        $format->getBullet()->setBulletHardColor(NullableBool::True);
        $format->getBullet()->getColor()->setColor($black);
        if ($type == BulletType::Numbered) {
            $format->getBullet()->setNumberedBulletStyle($style);
            $format->getBullet()->setNumberedBulletStartWith($start);
        } else if ($type == BulletType::Symbol) {
            $format->getBullet()->setChar("\u{2022}");
        } else if ($type == BulletType::Picture) {
            $format->getBullet()->getPicture()->setImage($bulletImage);
        }

        $textFrame->getParagraphs()->add($paragraph);
    };

    $addParagraph("First item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Second item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Next nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Deep item", 2, BulletType::Numbered, 4, NumberedBulletStyle::BulletRomanLCPeriod);
    $addParagraph("Back to top level", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Symbol marker", 0, BulletType::Symbol, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("No bullet", 0, BulletType::None, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Picture marker", 0, BulletType::Picture, 1, NumberedBulletStyle::BulletArabicPeriod);
    $presentation->save("actual_bullet_values.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    $loadedShape = $loadedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Text | Depth | Type | Actual value\n";
    $paragraphs = $loadedShape->getTextFrame()->getParagraphs();
    for ($i = 0; $i < java_values($paragraphs->getCount()); $i++) {
        $paragraph = $paragraphs->get_Item($i);
        $bullet = $paragraph->getParagraphFormat()->getEffective()->getBullet();
        switch (java_values($bullet->getType())) {
            case BulletType::Numbered:
            case BulletType::Symbol:
                $marker = $bullet->getActualBulletValue();
                break;
            case BulletType::None:
                $marker = "null (no bullet)";
                break;
            case BulletType::Picture:
                $marker = "null (image required)";
                break;
            default:
                $marker = "unsupported bullet type";
                break;
        }
        $typeNames = [BulletType::Numbered => "Numbered", BulletType::Symbol => "Symbol", BulletType::None => "None", BulletType::Picture => "Picture"];
        $typeName = $typeNames[java_values($bullet->getType())] ?? "Unknown";
        echo $paragraph->getText() . " | " . $paragraph->getParagraphFormat()->getDepth() . " | " . $typeName . " | " . $marker . "\n";
    }
} finally {
    $loadedPresentation->dispose();
}
```

As listas de origem são mostradas abaixo.

![Listas iniciando em 5, itens aninhados com letras e números romanos, um marcador de símbolo, um parágrafo sem marcador e um marcador de imagem azul](actual_bullet_values.png)

O relatório corresponde aos marcadores exibidos no PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Para [BulletType::None and BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/), [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) devolve `null`, não uma string vazia. Trate esses tipos separadamente: o primeiro não possui marcador, enquanto o último requer a extração da imagem do marcador separadamente. Um marcador de imagem não pode ser reproduzido apenas extraindo um marcador de texto.

## **Perguntas frequentes**

**É possível exportar listas com marcadores e numeradas para PDF ou imagens?**

Sim. O Aspose.Slides preserva a formatação de listas quando o formato de destino suporta o layout de texto correspondente e os recursos de marcador.

**Posso editar listas em apresentações existentes?**

Sim. Carregue a apresentação, acesse o parágrafo-alvo, inspecione ou atualize suas configurações de [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) e salve a apresentação.

**As listas podem conter texto não‑latino?**

Sim. O texto dos itens de lista pode conter caracteres Unicode, permitindo criar listas em apresentações multilíngues. Certifique‑se de que as fontes usadas na apresentação suportam os caracteres necessários.