---
title: Gerenciar parágrafos de texto do PowerPoint em PHP
linktitle: Gerenciar Parágrafo
type: docs
weight: 40
url: /pt/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- adicionar texto
- adicionar parágrafo
- gerenciar texto
- gerenciar parágrafo
- gerenciar marcador
- recuo de parágrafo
- recuo suspenso
- marcador de parágrafo
- lista numerada
- lista com marcadores
- propriedades do parágrafo
- importar HTML
- texto para HTML
- parágrafo para HTML
- parágrafo para imagem
- texto para imagem
- exportar parágrafo
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como criar e formatar parágrafos, porções, marcadores, listas numeradas, recuos, conteúdo HTML e imagens de parágrafos com Aspose.Slides para PHP via Java."
---
## **Visão geral**

Aspose.Slides for PHP via Java representa texto como uma hierarquia de quadros de texto, parágrafos e porções:

* [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) representa o contêiner de texto em uma forma e fornece acesso à sua coleção de parágrafos.
* [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/) representa um parágrafo em um quadro de texto e fornece acesso às suas porções e formatação ao nível do parágrafo.
* [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/) representa uma execução de texto dentro de um parágrafo. Cada porção pode ter seu próprio texto e formatação ao nível de caractere.

Um parágrafo, portanto, pode conter texto com diferentes fontes, cores, tamanhos e outras formatações usando várias porções.

## **Criar e formatar parágrafos**

### **Criar parágrafos com várias porções**

As etapas a seguir criam um quadro de texto com três parágrafos, cada um contendo três porções:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Acesse o slide relevante através de seu índice.
3. Adicione uma [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) retangular ao slide.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) da forma.
5. Use o parágrafo padrão e adicione dois objetos [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/) adicionais ao quadro de texto.
6. Adicione objetos [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/) suficientes para que cada parágrafo contenha três porções. O parágrafo padrão já contém uma porção vazia.
7. Defina o texto de cada porção.
8. Aplique formatação ao nível de caractere através de [Portion::getPortionFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/#getPortionFormat--).
9. Salve a apresentação modificada.

Este exemplo PHP implementa as etapas:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Criar listas com marcadores e numeradas**

### **Criar uma lista com marcadores ou numerada**

Marcadores e numeração facilitam a visualização de itens relacionados. No Aspose.Slides, as configurações de lista são definidas através de [BulletFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/bulletformat/).

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Acesse o slide relevante através de seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) ao slide selecionado.
4. Acesse o [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) da forma.
5. Remova o parágrafo padrão do quadro de texto.
6. Crie um [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/) para um marcador de símbolo.
7. Defina [BulletFormat::setType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/bulletformat/#setType-int-) como [BulletType::Symbol](https://reference.aspose.com/slides/pt/php-java/aspose.slides/bullettype/) e especifique o caractere do marcador.
8. Defina o texto do parágrafo, recuo, cor do marcador e altura do marcador.
9. Adicione o parágrafo ao quadro de texto.
10. Crie um segundo parágrafo e defina [BulletFormat::setType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/bulletformat/#setType-int-) como [BulletType::Numbered](https://reference.aspose.com/slides/pt/php-java/aspose.slides/bullettype/).
11. Configure o estilo de marcador numerado e adicione o parágrafo ao quadro de texto.
12. Salve a apresentação.

Este exemplo PHP cria um marcador de símbolo e um marcador numerado:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Usar marcadores de imagem**

Marcadores de imagem permitem usar uma imagem personalizada em vez de um símbolo ou número.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Acesse o slide relevante através de seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) e acesse seu [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/).
4. Remova o parágrafo padrão do quadro de texto.
5. Carregue a imagem do marcador e adicione-a à coleção de imagens da apresentação como um [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/).
6. Crie um [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/) e defina seu texto.
7. Defina [BulletFormat::setType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/bulletformat/#setType-int-) como [BulletType::Picture](https://reference.aspose.com/slides/pt/php-java/aspose.slides/bullettype/).
8. Atribua a imagem através de [BulletFormat::getPicture](https://reference.aspose.com/slides/pt/php-java/aspose.slides/bulletformat/#getPicture--) e defina a altura do marcador.
9. Adicione o parágrafo ao quadro de texto.
10. Salve a apresentação modificada.

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **Criar uma lista multinível**

Defina [ParagraphFormat::setDepth](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/#setDepth-short-) para posicionar parágrafos em diferentes níveis de uma lista. O nível superior tem profundidade `0`.

1. Crie um [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e acesse um slide.
2. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) e limpe o parágrafo padrão de seu quadro de texto.
3. Crie quatro parágrafos e configure seus símbolos de marcador.
4. Defina seus valores de [ParagraphFormat::setDepth] para `0`, `1`, `2` e `3`.
5. Adicione os parágrafos ao quadro de texto e salve a apresentação.

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Iniciar itens de lista numerada com valores personalizados**

Use [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/pt/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) para definir o número inicial exibido para um parágrafo numerado.

1. Crie um [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) a um slide.
2. Limpe o parágrafo padrão do quadro de texto da forma.
3. Crie três parágrafos numerados.
4. Defina [BulletFormat::setNumberedBulletStartWith] para `2`, `3` e `7` para os respectivos parágrafos.
5. Adicione os parágrafos ao quadro de texto e salve a apresentação.

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Controlar layout de parágrafo e propriedades de fim**

### **Definir recuo da primeira linha**

Use [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/#setIndent-float-) para controlar o recuo da primeira linha de um parágrafo. Este método move apenas a primeira linha em relação à margem esquerda do parágrafo. Um valor positivo desloca a primeira linha para a direita, enquanto as linhas restantes permanecem alinhadas ao corpo do parágrafo.

Use [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) quando precisar mover todo o parágrafo. Use [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/#setIndent-float-) quando precisar mover apenas a primeira linha.

O exemplo abaixo cria vários parágrafos e aplica diferentes valores de [ParagraphFormat::setIndent] para demonstrar como o recuo da primeira linha afeta o layout do parágrafo.

1. Crie uma instância da classe [Presentation].
2. Acesse o slide de destino.
3. Adicione um [AutoShape] retangular ao slide.
4. Acesse o [TextFrame] da forma e remova o parágrafo padrão.
5. Crie vários parágrafos e defina diferentes valores de [ParagraphFormat::setIndent] para eles.
6. Adicione os parágrafos ao quadro de texto.
7. Salve a apresentação modificada.

Este código PHP mostra como definir um recuo de parágrafo:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![O recuo da primeira linha dos parágrafos](first_line_indent.png)

### **Definir recuo suspenso**

Um recuo suspenso é um layout de parágrafo em que a primeira linha começa à esquerda das linhas restantes. No Aspose.Slides, você cria esse efeito com [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/#setIndent-float-). Passe um valor negativo para mover a primeira linha para a esquerda em relação ao corpo do parágrafo.

Na prática, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) define a posição esquerda do corpo do parágrafo, e [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/#setIndent-float-) define a posição da primeira linha em relação a essa margem. Para criar um recuo suspenso, passe um valor positivo para `setMarginLeft` e um valor negativo para `setIndent`.

Essa formatação é útil para bibliografias, referências, entradas de glossário e outros parágrafos onde as linhas com quebra de linha devem alinhar-se sob o corpo do parágrafo em vez de sob o primeiro caractere da primeira linha.

1. Crie uma instância da classe [Presentation].
2. Acesse o slide de destino.
3. Adicione um [AutoShape] retangular ao slide.
4. Acesse o [TextFrame] da forma e remova o parágrafo padrão.
5. Crie parágrafos e passe um valor positivo para [ParagraphFormat::setMarginLeft] para cada parágrafo.
6. Passe um valor negativo para [ParagraphFormat::setIndent] para criar o efeito de recuo suspenso.
7. Adicione os parágrafos ao quadro de texto.
8. Salve a apresentação modificada.

Este código PHP mostra como definir um recuo suspenso para um parágrafo:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![O recuo suspenso dos parágrafos](hanging_indent.png)

### **Definir propriedades de execução de final de parágrafo**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) controla a formatação da marca de final de parágrafo. O exemplo PHP a seguir atribui um tamanho de fonte e fonte latina à marca de final do segundo parágrafo:

1. Carregue um [Presentation] e acesse um slide.
2. Adicione um [AutoShape] e limpe seu parágrafo padrão.
3. Crie dois parágrafos e adicione porções de texto a eles.
4. Crie um [PortionFormat] para a marca de final do segundo parágrafo.
5. Defina [BasePortionFormat::setFontHeight] e [BasePortionFormat::setLatinFont].
6. Atribua o formato com [Paragraph::setEndParagraphPortionFormat] e salve a apresentação.

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Importar e exportar conteúdo de parágrafo**

### **Importar texto HTML em parágrafos**

Use [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) para converter marcação HTML em parágrafos e porções em um quadro de texto.

1. Crie uma instância da classe [Presentation].
2. Acesse um slide e adicione um [AutoShape].
3. Acesse o [TextFrame] da forma e limpe o parágrafo padrão.
4. Leia o arquivo HTML de origem.
5. Passe a string HTML para [ParagraphCollection::addFromHtml].
6. Salve a apresentação modificada.

Este exemplo PHP importa HTML em um quadro de texto:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **Exportar texto de parágrafo para HTML**

Use [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) para exportar um intervalo selecionado de parágrafos como HTML.

1. Crie uma instância da classe [Presentation] e carregue a apresentação desejada.
2. Acesse o slide e encontre o [AutoShape] que contém o texto.
3. Acesse o [TextFrame] da forma.
4. Chame [ParagraphCollection::exportToHtml] com o índice do parágrafo inicial e o número de parágrafos a exportar.
5. Escreva a string HTML retornada em um arquivo.

Este exemplo PHP exporta todos os parágrafos da primeira forma de texto:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **Renderizar um parágrafo como imagem**

[Paragraph::getImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/#getImage--) renderiza um parágrafo individual diretamente e retorna um [IImage]. Salve o resultado em um arquivo ou stream com [IImage::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/#save-java.lang.String-int-). Você não precisa renderizar a forma que contém ou recortar um bitmap manualmente.

[Paragraph::getImage] pode retornar `null` se o parágrafo não for encontrado em sua coleção pai, não tiver limites de renderização válidos ou não puder ser renderizado. Verifique o resultado antes de salvá-lo e descarte a imagem retornada após o uso.

#### **Renderizar um parágrafo na escala padrão**

Vamos supor que temos um arquivo de apresentação chamado sample.pptx com um slide, onde a primeira forma é uma caixa de texto contendo três parágrafos.

![A caixa de texto com três parágrafos](paragraph_to_image_input.png)

O exemplo PHP a seguir renderiza o segundo parágrafo em uma forma de texto regular na escala padrão e salva a imagem retornada em formato PNG. O bloco `finally` garante que a imagem seja descartada corretamente.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

O resultado:

![A imagem do parágrafo](paragraph_to_image_output.png)

#### **Renderizar um parágrafo em uma célula de tabela com dimensionamento**

Use a sobrecarga de [Paragraph::getImage] que aceita os parâmetros `$scaleX` e `$scaleY` para definir os fatores de escala horizontal e vertical. O exemplo PHP a seguir cria uma tabela, renderiza o parágrafo em sua primeira célula com o dobro da largura e altura padrão, e salva o resultado como uma imagem PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

Um fator de escala de `1` mantém esse eixo no tamanho de pixel padrão. Por exemplo, `2` para ambos os fatores produz uma imagem cuja largura e altura são aproximadamente o dobro das dimensões padrão, resultando em quatro vezes mais pixels. Fatores maiores geralmente produzem texto mais nítido para zoom ou saída de alta resolução, mas também aumentam o uso de memória e o tamanho do arquivo. Fatores abaixo de `1` produzem imagens menores com menos detalhes. Use fatores iguais para preservar a proporção do parágrafo; fatores diferentes horizontal e vertical esticam a saída independentemente.

Renderizar uma forma inteira com [Shape::getImage] continua útil quando a saída deve incluir o preenchimento, a borda ou outro contexto visual da forma. Para uma imagem somente do parágrafo, use [Paragraph::getImage].

## **Perguntas frequentes**

**Posso desativar completamente a quebra de linha dentro de um quadro de texto?**

Sim. Defina [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/#setWrapText-byte-) para desativar a quebra, de modo que as linhas não se interrompam nas bordas do quadro de texto.

**Como posso obter os limites exatos no slide de um parágrafo específico?**

Use [Paragraph::getRect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/#getRect--) para recuperar o retângulo delimitador do parágrafo. [Portion::getRect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/#getRect--) fornece os limites de uma porção individual.

**Onde o alinhamento de parágrafo (esquerda, direita, centro ou justificar) é controlado?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/#setAlignment-int-) é uma configuração ao nível do parágrafo e se aplica a todo o parágrafo, independentemente da formatação de porções individuais.

**Posso definir o idioma de revisão para parte de um parágrafo?**

Sim. Defina [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) para porções individuais, de modo que um parágrafo possa conter texto em vários idiomas.