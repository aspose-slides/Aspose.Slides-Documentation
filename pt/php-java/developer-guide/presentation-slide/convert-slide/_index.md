---
title: Converter Slides de Apresentação em Imagens em PHP
linktitle: Slide para Imagem
type: docs
weight: 35
url: /pt/php-java/convert-slide/
keywords:
- converter slide
- exportar slide
- slide para imagem
- salvar slide como imagem
- slide para EMF
- slide para PNG
- slide para JPEG
- slide para bitmap
- slide para TIFF
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Converta slides de apresentações PPT, PPTX e ODP para PNG, JPEG, GIF, TIFF, EMF e outros formatos de imagem em PHP com Aspose.Slides."
---
## **Introdução**

Aspose.Slides for PHP via Java pode renderizar slides individuais de apresentações PowerPoint e OpenDocument como PNG, JPEG, GIF, TIFF e outros formatos de imagem.

Para converter um slide em uma imagem, siga estas etapas:

1. Carregue a apresentação com a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Selecione o slide que você deseja renderizar.
3. Se necessário, configure a renderização com a classe [RenderingOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/renderingoptions/) ou [TiffOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tiffoptions/).
4. Chame o método [Slide::getImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#getImage). Ele retorna um objeto [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/).
5. Chame o método [IImage::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/#save) e especifique o formato de saída com um valor [ImageFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imageformat/).

## **Converter um Slide para Imagem PNG**

A conversão mais simples usa as configurações padrão de renderização. O objeto [IImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/iimage/) resultante pode ser processado na memória ou salvo em um arquivo.

O exemplo PHP a seguir renderiza o primeiro slide e o salva como uma imagem PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Converter Slides em Imagens com Tamanhos Personalizados**

Use a sobrecarga [Slide::getImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#getImage) que aceita um valor [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) para renderizar um slide com dimensões de pixel exatas.

O exemplo a seguir cria uma imagem JPEG de 1820 × 1040:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Converter Slides com Notas e Comentários em Imagens**

Por padrão, as imagens dos slides não incluem notas ou comentários. Passe um objeto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notescommentslayoutingoptions/) para o método [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) para controlar onde as notas e os comentários aparecem.

O exemplo a seguir coloca notas truncadas abaixo do slide e comentários à sua direita:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
Para a conversão de slide para imagem, não passe [BottomFull](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notespositions/) ao método [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). As notas podem conter mais texto do que o tamanho fixo da imagem pode acomodar. Use [BottomTruncated](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notespositions/) em vez disso.
{{% /alert %}}

## **Converter Slides em Imagens Usando Opções TIFF**

A classe [TiffOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tiffoptions/) permite controlar o tamanho, resolução e outras propriedades da imagem TIFF renderizada.

O exemplo a seguir renderiza o primeiro slide como uma imagem TIFF de 2160 × 2880 a 300 DPI:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
O suporte a TIFF não é garantido em versões do Java anteriores ao JDK 9.
{{% /alert %}}

## **Converter Todos os Slides em Imagens**

Itere pela coleção de slides para converter toda a apresentação em uma série de imagens. Slides ocultos são incluídos, a menos que você os ignore explicitamente.

O exemplo a seguir renderiza cada slide como uma imagem JPEG com fatores de escala horizontal e vertical de 2:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Criar Saída Metarquivo Avançado**

Enhanced Metafile (EMF) é útil quando gráficos baseados em vetor precisam ser trocados com o Microsoft Office ou outros aplicativos Windows que suportam metarquivos do Windows. Ao contrário de uma imagem baseada em pixels, um EMF pode preservar as operações de desenho vetorial que são escaladas sem a mesma perda de nitidez. Contudo, EMF é principalmente um formato de compatibilidade para aplicativos com suporte a metarquivos do Windows, não um formato de intercâmbio universal. Além disso, conteúdo complexo de slides, como imagens bitmap e alguns efeitos, podem ser armazenados como elementos rasterizados dentro do contêiner de metarquivo vetorial.

### **Exportar um Slide para EMF**

O método [Slide::writeAsEmf](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#writeAsEmf) grava um slide em um stream de destino no formato EMF. O exemplo a seguir carrega uma apresentação, seleciona o primeiro slide e o grava em um stream de arquivo EMF:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

O chamador possui o stream passado para [Slide::writeAsEmf](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#writeAsEmf) e é responsável por fechá‑lo, como mostrado acima.

### **Converter uma Imagem SVG para EMF e Adicioná‑la a uma Apresentação**

Use [SvgImage::writeAsEmf](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgimage/#writeAsEmf) para converter conteúdo SVG em EMF. Os bytes resultantes podem ser adicionados à apresentação através de [ImageCollection::addImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/imagecollection/#addImage) e colocados em um slide com [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/#addPictureFrame).

O exemplo a seguir cria um [SvgImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgimage/) a partir de marcação SVG, converte‑o em um EMF na memória, insere o metarquivo no primeiro slide e salva a apresentação:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[SvgImage::writeAsEmf](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgimage/#writeAsEmf) não assume a propriedade do stream de destino. Um [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) armazena todos os dados gerados na memória, portanto não é necessário redefinir a posição antes de chamar `toByteArray`. O array de bytes retornado permanece válido após o stream ser fechado.

A geração de EMF está disponível nos sistemas operacionais suportados pela configuração selecionada do Aspose.Slides for PHP via Java e do JDK, mas a renderização pode variar entre plataformas quando fontes ou dependências gráficas não estão disponíveis. Instale as fontes usadas pelo conteúdo de origem ou configure substituições adequadas, siga os [requisitos de plataforma](/slides/pt/php-java/system-requirements/) para o Aspose.Slides for PHP via Java e valide o resultado no aplicativo que consome EMF de destino. Aplicativos Linux e macOS frequentemente têm suporte limitado ou inconsistente para exibir e editar metarquivos do Windows.

## **Renderização de Emoji Colorido**

{{% alert title="Note" color="info" %}}
Para renderizar emojis coloridos corretamente ao converter slides de apresentação em imagens, as fontes de emoji usadas na apresentação devem estar instaladas e disponíveis no sistema que realiza a conversão. Por exemplo, se a apresentação usar **Segoe UI Emoji** e essa fonte estiver ausente, os emojis podem aparecer em monocromático nas imagens de saída.
{{% /alert %}}

## **Perguntas Frequentes**

**O Aspose.Slides oferece suporte à renderização de slides com animações?**

Não. O método [Slide::getImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#getImage) renderiza uma imagem estática do slide e não exporta animações.

**Slides ocultos podem ser exportados como imagens?**

Sim. Slides ocultos podem ser renderizados como slides normais. Inclua‑os no loop de processamento, como mostrado no exemplo acima.

**Sombras e outros efeitos são preservados nas imagens dos slides?**

Sim. O Aspose.Slides renderiza sombras, transparência e outros efeitos gráficos suportados nas imagens dos slides.