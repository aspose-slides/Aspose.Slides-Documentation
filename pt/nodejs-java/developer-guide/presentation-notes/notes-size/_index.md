---
title: Alterar o tamanho e a orientação da página de notas em JavaScript
linktitle: Tamanho da página de notas
type: docs
weight: 10
url: /pt/nodejs-java/notes-size/
keywords:
- tamanho da página de notas
- orientação das notas
- notas em paisagem
- notas em retrato
- tamanho do folheto
- PowerPoint
- apresentação
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Leia e altere as dimensões da página de notas no Aspose.Slides para Node.js via Java, troque a orientação, verifique os tamanhos salvos e exporte notas ou folhetos para PDF e imagens."
---
## **Visão geral**

Use [Presentation.getNotesSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getnotessize/) para acessar as configurações da página de notas da apresentação. Ele retorna um objeto [NotesSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notessize/) cujo método [setSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notessize/setsize/) define as dimensões da página. Embora o próprio objeto de configurações não possa ser substituído, você pode atribuir novas dimensões através desse método.

A largura e a altura são especificadas em **pontos**, com 72 pontos por polegada. Por exemplo, 900 × 600 pontos equivalem a 12,5 × 8⅓ polegadas. Essas configurações se aplicam à apresentação, e não às notas de um slide individual.

| Configuração | Objetivo |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getnotessize/) | Controla as dimensões da página de notas e as dimensões da página usadas para exportação de folhetos. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getslidesize/) | Controla as dimensões dos slides regulares da apresentação através de [SlideSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidesize/). |

Alterar qualquer uma das configurações não altera automaticamente a outra. Alterar a orientação da página de notas também não gira os slides regulares. Veja [Slide Size](/slides/pt/nodejs-java/slide-size/) para redimensionar os slides regulares.

Os exemplos abaixo utilizam um `sample.pptx` existente. Para os exemplos de exportação, use uma apresentação com ao menos um slide contendo notas do apresentador. Cada exemplo pode ser executado independentemente.

## **Ler o Tamanho e a Orientação da Página de Notas**

Leia a largura e a altura e compare-as para determinar a orientação: uma página mais larga é paisagem, uma página mais alta é retrato, e dimensões iguais descrevem uma página quadrada. Este exemplo exibe as dimensões reais em pontos, sem assumir um tamanho de papel padrão.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Mudar para Paisagem Sem Alterar o Tamanho do Papel**

Para mudar apenas a orientação, troque a largura e a altura existentes. Isso preserva o comprimento de ambos os lados, incluindo os de um tamanho de papel personalizado. A condição abaixo impede que uma página já em paisagem seja revertida para retrato e mantém uma página quadrada inalterada.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para orientação retrato, use a mesma atribuição quando `size.getWidth() > size.getHeight()`. Não substitua as dimensões A4 ou Letter a menos que também deseje alterar o tamanho do papel.

## **Definir e Verificar um Tamanho Personalizado da Página de Notas**

Atribua ambas as dimensões juntas e, em seguida, use [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/save/) para gravar a apresentação. Este exemplo define uma página paisagem de 900 × 600 pontos, salva-a como PPTX e abre o arquivo salvo novamente para verificar os valores persistidos. A comparação permite uma tolerância de 0,01 ponto para valores de ponto flutuante; isso não garante precisão para todos os formatos de arquivo.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

O resultado esperado é `900 x 600 points` e `Size preserved: true`. Verificar uma apresentação recém-aberta confirma o arquivo salvo, em vez de apenas as configurações em memória.

## **Exportar Notas e Folhetos**

As dimensões da página definem a área disponível para layouts de notas ou folhetos. Elas não habilitam esses layouts por si só: também configure as opções de exportação. A exportação de slides regulares continua a usar as dimensões do slide.

### **Exportar Notas para PDF e PNG**

Atribua [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notescommentslayoutingoptions/) a [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) para incluir notas no PDF. Este exemplo também renderiza o primeiro slide com notas para PNG usando [Slide.getImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#getImage) e [RenderingOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/renderingoptions/).

O modo [BottomTruncated](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notespositions/) mantém as notas em uma única página; notas que não couberem podem ser truncadas. O PDF usa páginas de 900 × 600 pontos. Na escala de imagem de 1 × 1 usada abaixo, o PNG tem 900 × 600 pixels. Pontos descrevem a geometria da página; pixels descrevem a saída raster, cujas dimensões também dependem da escala de renderização.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Para exportação de PDF com notas longas, [BottomFull](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/notespositions/) permite páginas adicionais conforme necessário. Não use esse modo com a chamada de imagem de slide único acima, que não o suporta. Após redimensionar, inspecione a saída para notas recortadas e a colocação dos objetos notes-master existentes; alterar apenas as dimensões da página não deve ser considerado uma garantia de que todo o conteúdo caberá. Veja [Convert PowerPoint to PDF with Notes](/slides/pt/nodejs-java/convert-powerpoint-to-pdf-with-notes/) para mais informações sobre exportação de notas.

### **Exportar Folhetos para PDF**

Use [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/handoutlayoutingoptions/) para múltiplas miniaturas de slides em uma página. O exemplo a seguir define uma página de 900 × 600 pontos e usa [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/handouttype/) para organizar até quatro slides por página. O preset horizontal controla a ordem dos slides; a orientação da página vem de sua largura e altura.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Alterar o tamanho da página muda a área disponível para a grade de folhetos sem alterar as dimensões dos slides de origem. Para imagens de folhetos, use [Presentation.getImages](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getimages/) com o layout de folheto, em vez do método de imagem de um slide individual. No Aspose.Slides, a renderização de folhetos em nível de apresentação usa as dimensões da página de notas, enquanto a chamada de imagem de slide individual não produz a página de folheto. Veja [Handout Mode](/slides/pt/nodejs-java/convert-powerpoint-in-handout-mode/) para opções de layout.

## **Tamanho da Página em Visualizadores, Exportação e Impressão**

Mantenha o tamanho da apresentação armazenado, o tamanho da página exportada e o tamanho do papel impresso distintos:

- **Presentation viewers:** Um visualizador pode exibir ou imprimir notas usando suas próprias regras de layout. Se outro aplicativo salvar o arquivo, reabra‑o e verifique as dimensões novamente; a conversão de formato desse aplicativo pode normalizá‑las.
- **Export formats:** Os exemplos de PDF de notas e folhetos acima usam as dimensões de página configuradas. Imagens raster usam dimensões de pixel inteiras e uma escala de renderização, de modo que valores fracionários de ponto podem ser arredondados na saída da imagem. Exportar slides regulares não aplica o tamanho da página de notas.
- **Printer drivers:** A seleção de papel, rotação automática e configurações de ajuste à página podem alterar a saída física sem mudar as dimensões armazenadas na apresentação ou no PDF. Para um tamanho de papel específico, corresponda às configurações da impressora e inspecione a visualização de impressão.

## **FAQ**

**Posso definir o tamanho das notas para apenas um slide?**

O tamanho da página de notas é uma configuração em nível de apresentação. Slides individuais podem ter conteúdo de notas diferente, mas essa propriedade não fornece um tamanho de página separado para cada slide.

**Por que mudar a orientação das notas não mudou meus slides?**

As páginas de notas e os slides regulares têm dimensões independentes. Use as configurações de tamanho de slide regular quando quiser redimensionar os próprios slides.

**Por que o resultado salvo ou impresso tem um tamanho diferente?**

Primeiro reabra a apresentação salva e compare suas dimensões de notas. Se elas mudaram, verifique se salvar ou converter o arquivo em outro aplicativo alterou as configurações de página. Se não, verifique o layout de exportação, a escala da imagem, as configurações do visualizador e a seleção de papel da impressora.