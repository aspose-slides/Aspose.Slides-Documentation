---
title: Alterar tamanho e orientação da página de notas em PHP
linktitle: Tamanho da página de notas
type: docs
weight: 10
url: /pt/php-java/notes-size/
keywords:
- tamanho da página de notas
- orientação das notas
- notas em paisagem
- notas em retrato
- tamanho de folheto
- PowerPoint
- apresentação
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Leia e altere as dimensões da página de notas no Aspose.Slides para PHP via Java, troque a orientação, verifique os tamanhos salvos e exporte notas ou folhetos para PDF e imagens."
---
## **Visão geral**

Use [Presentation::getNotesSize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getnotessize/) para acessar as configurações da página de notas da apresentação. Ele retorna um objeto [NotesSize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notessize/) cujo método [setSize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notessize/setsize/) define as dimensões da página. Embora o objeto de configurações não possa ser substituído, você pode atribuir novas dimensões através desse método.

A largura e a altura são especificadas em **pontos**, com 72 pontos por polegada. Por exemplo, 900 × 600 pontos correspondem a 12,5 × 8⅓ polegadas. Essas configurações se aplicam à apresentação, e não a uma página de notas de um slide individual.

| Configuração | Finalidade |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getnotessize/) | Controla as dimensões da página de notas e as dimensões usadas na exportação de folhetos. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getslidesize/) | Controla as dimensões regulares dos slides da apresentação através de [SlideSize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidesize/). |

Alterar uma das configurações não modifica automaticamente a outra. Alterar a orientação da página de notas também não gira os slides regulares. Consulte [Slide Size](/slides/pt/php-java/slide-size/) para redimensionar os slides regulares.

Os exemplos abaixo utilizam um `sample.pptx` existente. Para os exemplos de exportação, use uma apresentação que contenha ao menos um slide com notas do locutor. Cada exemplo pode ser executado independentemente após carregar o PHP/Java Bridge e o wrapper Aspose.Slides PHP. Valores numéricos retornados pelo Java são convertidos para valores PHP com `java_values` antes da comparação ou cálculo.

## **Ler o tamanho e a orientação da página de notas**

Leia a largura e a altura e compare-as para determinar a orientação: uma página mais larga é paisagem, uma página mais alta é retrato, e dimensões iguais descrevem uma página quadrada. Este exemplo imprime as dimensões reais em pontos, sem presumir um tamanho de papel padrão.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Alterar para paisagem sem mudar o tamanho do papel**

Para mudar apenas a orientação, troque a largura e a altura existentes. Isso preserva o comprimento de ambos os lados, inclusive os de um tamanho de papel personalizado. A condição abaixo evita que uma página já em paisagem seja revertida para retrato e deixa uma página quadrada inalterada.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para orientação retrato, use a mesma atribuição quando `java_values($size->getWidth()) > java_values($size->getHeight())`. Não substitua as dimensões A4 ou Letter a menos que você também queira mudar o tamanho do papel.

## **Definir e verificar um tamanho de página de notas personalizado**

Atribua ambas as dimensões juntas, depois use [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/save/) para gravar a apresentação. Este exemplo define uma página paisagem de 900 × 600 pontos, salva-a como PPTX e abre o arquivo salvo novamente para verificar os valores persistidos. A comparação permite uma tolerância de 0,01 ponto para valores de ponto flutuante; não é uma garantia de precisão para todos os formatos de arquivo.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

O resultado esperado é `900 x 600 points` e `Size preserved: true`. Verificar uma apresentação recém-aberta confirma o arquivo salvo, e não apenas as configurações em memória.

## **Exportar notas e folhetos**

As dimensões da página definem a área disponível para layouts de notas ou folhetos. Elas não habilitam esses layouts por si só: configure também as opções de exportação. A exportação dos slides regulares continua usando as dimensões dos slides.

### **Exportar notas para PDF e PNG**

Atribua [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notescommentslayoutingoptions/) a [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) para incluir notas no PDF. Este exemplo também renderiza o primeiro slide com notas em PNG usando [Slide::getImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#getImage) e [RenderingOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/renderingoptions/).

O modo [BottomTruncated](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notespositions/) mantém as notas em uma única página; notas que não couberem podem ser truncadas. O PDF usa páginas de 900 × 600 pontos. Na escala de imagem de 1 × 1 usada abaixo, o PNG tem 900 × 600 pixels. Pontos descrevem a geometria da página; pixels descrevem a saída raster, cujas dimensões também dependem da escala de renderização.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Para exportação PDF com notas extensas, [BottomFull](https://reference.aspose.com/slides/pt/php-java/aspose.slides/notespositions/) permite páginas adicionais conforme necessário. Não use esse modo com a chamada de imagem de slide único acima, que não o suporta. Após redimensionar, verifique a saída para notas recortadas e a posição dos objetos existentes do mestre de notas; mudar apenas as dimensões da página não deve ser considerado garantia de que todo o conteúdo caberá. Consulte [Convert PowerPoint to PDF with Notes](/slides/pt/php-java/convert-powerpoint-to-pdf-with-notes/) para mais informações sobre exportação de notas.

### **Exportar folhetos para PDF**

Use [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/handoutlayoutingoptions/) para múltiplas miniaturas de slide em uma página. O exemplo a seguir define uma página de 900 × 600 pontos e usa [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/pt/php-java/aspose.slides/handouttype/) para organizar até quatro slides por página. O preset horizontal controla a ordem dos slides; a orientação da página vem de sua largura e altura.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Alterar o tamanho da página altera a área disponível para a grade de folhetos sem mudar as dimensões dos slides de origem. Para imagens de folhetos, use [Presentation::getImages](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/getimages/) com o layout de folheto, em vez do método de imagem de um slide individual. No Aspose.Slides, a renderização de folhetos em nível de apresentação usa as dimensões da página de notas, enquanto a chamada de imagem de slide individual não produz a página de folheto. Consulte [Handout Mode](/slides/pt/php-java/convert-powerpoint-in-handout-mode/) para opções de layout.

## **Tamanho da página em visualizadores, exportação e impressão**

Mantenha distintos o tamanho armazenado da apresentação, o tamanho da página exportada e o tamanho do papel impresso:

- **Visualizadores de apresentação:** Um visualizador pode exibir ou imprimir notas usando suas próprias regras de layout. Se outro aplicativo salvar o arquivo, reabra‑o e verifique as dimensões novamente; a conversão de formato desse aplicativo pode normalizá‑las.
- **Formatos de exportação:** Os exemplos de PDF de notas e folhetos acima usam as dimensões de página configuradas. Imagens raster utilizam dimensões de pixel inteiras e uma escala de renderização, de modo que valores fracionários de ponto podem ser arredondados na saída da imagem. A exportação de slides regulares não aplica o tamanho da página de notas.
- **Drivers de impressão:** Seleção de papel, rotação automática e configurações de ajuste à página podem alterar a saída física sem mudar as dimensões armazenadas na apresentação ou no PDF. Para um tamanho de papel específico, ajuste as configurações da impressora e verifique a visualização de impressão.

## **FAQ**

**Posso definir o tamanho das notas apenas para um slide?**

O tamanho da página de notas é uma configuração a nível de apresentação. Slides individuais podem ter conteúdo de notas diferente, mas essa propriedade não fornece um tamanho de página separado para cada slide.

**Por que mudar a orientação das notas não alterou meus slides?**

Páginas de notas e slides regulares têm dimensões independentes. Use as configurações de tamanho de slide regular quando quiser redimensionar os próprios slides.

**Por que o resultado salvo ou impresso tem tamanho diferente?**

Primeiro reabra a apresentação salva e compare suas dimensões de notas. Se essas mudaram, verifique se salvar ou converter o arquivo em outro aplicativo alterou as configurações da página. Se não, verifique o layout de exportação, a escala da imagem, as configurações do visualizador e a seleção de papel da impressora.