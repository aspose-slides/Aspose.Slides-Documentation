---
title: Gerenciar Parágrafos de Texto do PowerPoint em PHP
linktitle: Gerenciar Parágrafo
type: docs
weight: 40
url: /pt/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
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
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Domine a formatação de parágrafos com Aspose.Slides para PHP via Java — otimize alinhamento, espaçamento e estilo em apresentações PPT, PPTX e ODP."
---
## **Introdução**

Aspose.Slides fornece todas as classes necessárias para trabalhar com textos, parágrafos e partes do PowerPoint.

* Aspose.Slides fornece a classe [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) para permitir que você adicione objetos que representam um parágrafo. Um objeto `TextFame` pode ter um ou vários parágrafos (cada parágrafo é criado por meio de um retorno de carro).
* Aspose.Slides fornece a classe [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/) para permitir que você adicione objetos que representam partes. Um objeto `Paragraph` pode ter uma ou várias partes (coleção de objetos de parte).
* Aspose.Slides fornece a classe [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/) para permitir que você adicione objetos que representam textos e suas propriedades de formatação.

Um objeto `Paragraph` é capaz de manipular textos com diferentes propriedades de formatação por meio de seus objetos `Portion` subjacentes.

## **Adicionar Vários Parágrafos contendo Várias Partes**

Estas etapas mostram como adicionar um quadro de texto contendo 3 parágrafos e cada parágrafo contendo 3 partes:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [AutoShape] retangular ao slide.
4. Obtenha o ITextFrame associado ao [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/).
5. Crie dois objetos [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/) e adicione-os à coleção de parágrafos do [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/).
6. Crie três objetos [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/) para cada novo `Paragraph` (dois objetos Portion para o Parágrafo padrão) e adicione cada objeto `Portion` à coleção de partes de cada `Paragraph`.
7. Defina algum texto para cada parte.
8. Aplique os recursos de formatação de sua preferência a cada parte usando as propriedades de formatação expostas pelo objeto `Portion`.
9. Salve a apresentação modificada.

Este código PHP é uma implementação das etapas para adicionar parágrafos contendo partes:

```php
# Instanciar uma classe Presentation que representa um arquivo PPTX
$pres = new Presentation();
try {
    # Acessando o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);
    # Adicionar um AutoShape do tipo Retângulo
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Acessar o TextFrame do AutoShape
    $tf = $ashp->getTextFrame();
    # Criar Parágrafos e Partes com diferentes formatos de texto
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # Gravar PPTX no disco
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Gerenciar Marcadores de Parágrafo**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Parágrafos com marcadores são sempre mais fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) ao slide selecionado.
4. Acesse o [TextFrame] do autoshape.
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/).
7. Defina o `Type` do marcador para o parágrafo como `Symbol` e defina o caractere do marcador.
8. Defina o `Text` do parágrafo.
9. Defina o `Indent` do parágrafo para o marcador.
10. Defina uma cor para o marcador.
11. Defina a altura do marcador.
12. Adicione o novo parágrafo à coleção de parágrafos do `TextFrame`.
13. Adicione o segundo parágrafo e repita o processo descrito nas etapas 7 a 13.
14. Salve a apresentação.

Este código PHP mostra como adicionar um marcador de parágrafo:

```php
# Instancia uma classe Presentation que representa um arquivo PPTX
$pres = new Presentation();
try {
    # Acessa o primeiro slide
    $slide = $pres->getSlides()->get_Item(0);
    # Adiciona e acessa Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Acessa o quadro de texto do autoshape
    $txtFrm = $aShp->getTextFrame();
    # Remove o parágrafo padrão
    $txtFrm->getParagraphs()->removeAt(0);
    # Cria um parágrafo
    $para = new Paragraph();
    # Define o estilo de marcador de parágrafo e símbolo
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Define o texto do parágrafo
    $para->setText("Welcome to Aspose.Slides");
    # Define o recuo do marcador
    $para->getParagraphFormat()->setIndent(25);
    # Define a cor do marcador
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// define IsBulletHardColor como true para usar a própria cor do marcador

    # Define a altura do marcador
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Adiciona o parágrafo ao quadro de texto
    $txtFrm->getParagraphs()->add($para);
    # Cria o segundo parágrafo
    $para2 = new Paragraph();
    # Define o tipo e estilo de marcador de parágrafo
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Adiciona o texto do parágrafo
    $para2->setText("This is numbered bullet");
    # Define o recuo do marcador
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// define IsBulletHardColor como true para usar a própria cor do marcador

    # Define a altura do marcador
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Adiciona o parágrafo ao quadro de texto
    $txtFrm->getParagraphs()->add($para2);
    # Salva a apresentação modificada
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Gerenciar Marcadores de Imagem**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Parágrafos com marcadores de imagem são fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) ao slide.
4. Acesse o [TextFrame] do autoshape.
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo usando a classe [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/).
7. Carregue a imagem em [PPImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ppimage/).
8. Defina o tipo de marcador como [Picture](https://reference.aspose.com/slides/pt/php-java/aspose.slides/bullettype/#Picture) e defina a imagem.
9. Defina o `Text` do parágrafo.
10. Defina o `Indent` do parágrafo para o marcador.
11. Defina uma cor para o marcador.
12. Defina a altura do marcador.
13. Adicione o novo parágrafo à coleção de parágrafos do `TextFrame`.
14. Adicione o segundo parágrafo e repita o processo com base nas etapas anteriores.
15. Salve a apresentação modificada.

Este código PHP mostra como adicionar e gerenciar marcadores de imagem:

```php
# Instancia uma classe Presentation que representa um arquivo PPTX
$presentation = new Presentation();
try {
    # Acessa o primeiro slide
    $slide = $presentation->getSlides()->get_Item(0);
    # Instancia a imagem para marcadores
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Adiciona e acessa Autoshape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Acessa o quadro de texto do autoshape
    $textFrame = $autoShape->getTextFrame();
    # Remove o parágrafo padrão
    $textFrame->getParagraphs()->removeAt(0);
    # Cria um novo parágrafo
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Define o estilo de marcador de parágrafo e a imagem
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Define a altura do marcador
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Adiciona o parágrafo ao quadro de texto
    $textFrame->getParagraphs()->add($paragraph);
    # Grava a apresentação como arquivo PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Grava a apresentação como arquivo PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Gerenciar Marcadores Multinível**

Listas com marcadores ajudam a organizar e apresentar informações de forma rápida e eficiente. Marcadores multinível são fáceis de ler e entender.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Acesse a referência do slide relevante por meio de seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) no novo slide.
4. Acesse o [TextFrame] do autoshape.
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo via a classe [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/) e defina a profundidade como 0.
7. Crie a segunda instância de parágrafo via a classe `Paragraph` e defina a profundidade como 1.
8. Crie a terceira instância de parágrafo via a classe `Paragraph` e defina a profundidade como 2.
9. Crie a quarta instância de parágrafo via a classe `Paragraph` e defina a profundidade como 3.
10. Adicione os novos parágrafos à coleção de parágrafos do `TextFrame`.
11. Salve a apresentação modificada.

Este código PHP mostra como adicionar e gerenciar marcadores multinível:

```php
    # Instancia uma classe Presentation que representa um arquivo PPTX
    $pres = new Presentation();
    try {
        # Acessa o primeiro slide
        $slide = $pres->getSlides()->get_Item(0);
        # Adiciona e acessa Autoshape
        $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
        # Acessa o quadro de texto do autoshape criado
        $text = $aShp->addTextFrame("");
        # Limpa o parágrafo padrão
        $text->getParagraphs()->clear();
        # Adiciona o primeiro parágrafo
        $para1 = new Paragraph();
        $para1->setText("Content");
        $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
        $para1->getParagraphFormat()->getBullet()->setChar(8226);
        $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
        # Define o nível do marcador
        $para1->getParagraphFormat()->setDepth(0);
        # Adiciona o segundo parágrafo
        $para2 = new Paragraph();
        $para2->setText("Second Level");
        $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
        $para2->getParagraphFormat()->getBullet()->setChar('-');
        $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
        # Define o nível do marcador
        $para2->getParagraphFormat()->setDepth(1);
        # Adiciona o terceiro parágrafo
        $para3 = new Paragraph();
        $para3->setText("Third Level");
        $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
        $para3->getParagraphFormat()->getBullet()->setChar(8226);
        $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
        # Define o nível do marcador
        $para3->getParagraphFormat()->setDepth(2);
        # Adiciona o quarto parágrafo
        $para4 = new Paragraph();
        $para4->setText("Fourth Level");
        $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
        $para4->getParagraphFormat()->getBullet()->setChar('-');
        $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
        # Define o nível do marcador
        $para4->getParagraphFormat()->setDepth(3);
        # Adiciona os parágrafos à coleção
        $text->getParagraphs()->add($para1);
        $text->getParagraphs()->add($para2);
        $text->getParagraphs()->add($para3);
        $text->getParagraphs()->add($para4);
        # Grava a apresentação como arquivo PPTX
        $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
    } finally {
        if (!java_is_null($pres)) {
            $pres->dispose();
        }
    }
```

## **Gerenciar um Parágrafo com uma Lista Numerada Personalizada**

A classe [BulletFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/bulletformat/) fornece o método [setNumberedBulletStartWith](https://reference.aspose.com/slides/pt/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) e outros que permitem gerenciar parágrafos com numeração ou formatação personalizada.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Acesse o slide que contém o parágrafo.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) ao slide.
4. Acesse o [TextFrame] do autoshape.
5. Remova o parágrafo padrão no `TextFrame`.
6. Crie a primeira instância de parágrafo via a classe [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/) e defina [NumberedBulletStartWith] como 2.
7. Crie a segunda instância de parágrafo via a classe `Paragraph` e defina `NumberedBulletStartWith` como 3.
8. Crie a terceira instância de parágrafo via a classe `Paragraph` e defina `NumberedBulletStartWith` como 7.
9. Adicione os novos parágrafos à coleção de parágrafos do `TextFrame`.
10. Salve a apresentação modificada.

Este código PHP mostra como adicionar e gerenciar parágrafos com numeração ou formatação personalizada:

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Acessa o quadro de texto do autoshape criado
    $textFrame = $shape->getTextFrame();
    # Remove o parágrafo padrão existente
    $textFrame->getParagraphs()->removeAt(0);
    # Primeira lista
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Definir Recuo da Primeira Linha para um Parágrafo**

Use o método [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setindent/) para controlar o recuo da primeira linha de um parágrafo. Este método move apenas a primeira linha em relação à margem esquerda do parágrafo. Um valor positivo desloca a primeira linha para a direita, enquanto as linhas restantes permanecem alinhadas ao corpo do parágrafo.

Use [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setmarginleft/) quando precisar mover todo o parágrafo. Use [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setindent/) quando precisar mover apenas a primeira linha.

O exemplo abaixo cria vários parágrafos e aplica diferentes valores de recuo para demonstrar como o recuo da primeira linha afeta o layout do parágrafo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Acesse o slide alvo.
3. Adicione um [AutoShape] retangular ao slide.
4. Adicione um [TextFrame] vazio ao shape e remova o parágrafo padrão.
5. Crie vários parágrafos e defina diferentes valores de [Indent](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setindent/) para eles.
6. Adicione os parágrafos ao quadro de texto.
7. Salve a apresentação modificada.

Este código mostra como definir um recuo de parágrafo:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
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

## **Definir Recuo Suspenso para um Parágrafo**

Um recuo suspenso é um layout de parágrafo em que a primeira linha começa à esquerda das linhas restantes. No Aspose.Slides, você cria esse efeito com o método [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setindent/). Defina o recuo como um valor negativo para mover a primeira linha para a esquerda em relação ao corpo do parágrafo.

Na prática, [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setmarginleft/) define a posição esquerda do corpo do parágrafo, e [ParagraphFormat::setIndent](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setindent/) define a posição da primeira linha em relação a essa margem. Para criar um recuo suspenso, defina um valor positivo para `MarginLeft` e um valor negativo para `Indent`.

Essa formatação é útil para bibliografias, referências, entradas de glossário e outros parágrafos onde linhas envolvidas devem alinhar-se sob o corpo do parágrafo, e não sob o primeiro caractere da primeira linha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Acesse o slide alvo.
3. Adicione um [AutoShape] retangular ao slide.
4. Adicione um [TextFrame] vazio ao shape e remova o parágrafo padrão.
5. Crie parágrafos e defina um valor positivo de [MarginLeft](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setmarginleft/) para cada parágrafo.
6. Defina um valor negativo de [Indent](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setindent/) para criar o efeito de recuo suspenso.
7. Adicione os parágrafos ao quadro de texto.
8. Salve a apresentação modificada.

Este código mostra como definir um recuo suspenso para um parágrafo:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
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

## **Gerenciar Propriedades de Execução de Parágrafo Final**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Obtenha a referência do slide que contém o parágrafo por sua posição.
3. Adicione um [AutoShape] retangular ao slide.
4. Adicione um [TextFrame] com dois parágrafos ao retângulo.
5. Defina a altura da fonte e o tipo de fonte para os parágrafos.
6. Defina as propriedades End para os parágrafos.
7. Grave a apresentação modificada como um arquivo PPTX.

Este código PHP mostra como definir as propriedades End para parágrafos no PowerPoint:

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Importar Texto HTML em Parágrafos**

Aspose.Slides oferece suporte aprimorado para importação de texto HTML em parágrafos.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Acesse a referência do slide relevante por seu índice.
3. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) ao slide.
4. Adicione e acesse o [TextFrame] do `AutoShape`.
5. Remova o parágrafo padrão no `TextFrame`.
6. Leia o arquivo HTML fonte em um TextReader.
7. Crie a primeira instância de parágrafo via a classe [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/).
8. Adicione o conteúdo do arquivo HTML lido pelo TextReader ao [ParagraphCollection] do TextFrame.
9. Salve a apresentação modificada.

Este código PHP é uma implementação das etapas para importar textos HTML em parágrafos:

```php
# Cria uma instância vazia de apresentação
$pres = new Presentation();
try {
    # Acessa o primeiro slide padrão da apresentação
    $slide = $pres->getSlides()->get_Item(0);
    # Adiciona o AutoShape para acomodar o conteúdo HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Adiciona um quadro de texto à forma
    $ashape->addTextFrame("");
    # Limpa todos os parágrafos no quadro de texto adicionado
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Carrega o arquivo HTML usando stream reader
    $tr = new StreamReader("file.html");
    # Adiciona texto do stream reader HTML ao quadro de texto
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Salvando a apresentação
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Exportar Texto de Parágrafo para HTML**

Aspose.Slides oferece suporte aprimorado para exportar textos (contidos em parágrafos) para HTML.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e carregue a apresentação desejada.
2. Acesse a referência do slide relevante por seu índice.
3. Acesse a forma que contém o texto que será exportado para HTML.
4. Acesse o [TextFrame] da forma.
5. Crie uma instância de `StreamWriter` e adicione o novo arquivo HTML.
6. Forneça um índice inicial ao StreamWriter e exporte os parágrafos desejados.

Este código PHP mostra como exportar textos de parágrafos do PowerPoint para HTML:

```php
# Carregar o arquivo de apresentação
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Acessa o primeiro slide padrão da apresentação
    $slide = $pres->getSlides()->get_Item(0);
    # Índice desejado
    $index = 0;
    # Acessando a forma adicionada
    $ashape = $slide->getShapes()->get_Item($index);
    # Criando o arquivo HTML de saída
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Extraindo o primeiro parágrafo como HTML
    # Escrevendo os dados dos parágrafos em HTML fornecendo o índice inicial do parágrafo e o total de parágrafos a serem copiados
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Salvar um Parágrafo como Imagem**

Nesta seção, exploraremos dois exemplos que demonstram como salvar um parágrafo de texto, representado pela classe [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/), como uma imagem. Ambos os exemplos incluem a obtenção da imagem de uma forma que contém o parágrafo usando os métodos `getImage` da classe [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/), o cálculo dos limites do parágrafo dentro da forma e a exportação como uma imagem bitmap. Essas abordagens permitem extrair partes específicas do texto de apresentações PowerPoint e salvá‑las como imagens separadas, o que pode ser útil em diversos cenários.

Vamos supor que temos um arquivo de apresentação chamado sample.pptx com um slide, onde a primeira forma é uma caixa de texto contendo três parágrafos.

![A caixa de texto com três parágrafos](paragraph_to_image_input.png)

**Exemplo 1**

Neste exemplo, obtém‑se o segundo parágrafo como imagem. Para isso, extraímos a imagem da forma do primeiro slide da apresentação e, em seguida, calculamos os limites do segundo parágrafo no quadro de texto da forma. O parágrafo é então redesenhado em uma nova imagem bitmap, que é salva no formato PNG. Esse método é especialmente útil quando se precisa salvar um parágrafo específico como imagem separada, preservando as dimensões e a formatação exatas do texto.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Salvar a forma na memória como bitmap.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Criar um bitmap da forma a partir da memória.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Calcular os limites do segundo parágrafo.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Calcular as coordenadas e o tamanho da imagem de saída (tamanho mínimo - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Cortar o bitmap da forma para obter apenas o bitmap do parágrafo.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

O resultado:

![A imagem do parágrafo](paragraph_to_image_output.png)

**Exemplo 2**

Neste exemplo, ampliamos a abordagem anterior adicionando fatores de escala à imagem do parágrafo. A forma é extraída da apresentação e salva como imagem com um fator de escala de `2`. Isso permite uma saída de resolução mais alta ao exportar o parágrafo. Em seguida, os limites do parágrafo são recalculados considerando a escala. A escala pode ser particularmente útil quando se necessita de uma imagem mais detalhada, por exemplo, para uso em materiais impressos de alta qualidade.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Salvar a forma na memória como bitmap com escala.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Criar um bitmap da forma a partir da memória.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Calcular os limites do segundo parágrafo.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Calcular as coordenadas e o tamanho da imagem de saída (tamanho mínimo - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Cortar o bitmap da forma para obter apenas o bitmap do parágrafo.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Posso desativar completamente a quebra de linha dentro de um quadro de texto?**

Sim. Use a configuração de quebra de linha do quadro de texto ([setWrapText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/setwraptext/)) para desativar a quebra, de modo que as linhas não sejam quebradas nas bordas do quadro.

**Como posso obter os limites exatos no slide de um parágrafo específico?**

Você pode recuperar o retângulo delimitador do parágrafo (e até mesmo de uma única parte) para conhecer sua posição e tamanho exatos no slide.

**Onde é controlado o alinhamento do parágrafo (esquerda/direita/centralizado/justificado)?**

[Alignment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/setalignment/) é uma configuração ao nível do parágrafo em [ParagraphFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraphformat/); ela se aplica a todo o parágrafo independentemente da formatação individual das partes.

**Posso definir um idioma de verificação ortográfica apenas para parte de um parágrafo (por exemplo, uma palavra)?**

Sim. O idioma é definido ao nível da parte ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setLanguageId)), portanto, vários idiomas podem coexistir dentro de um único parágrafo.