---
title: Alterar Tamanho e Orientação da Página de Notas no Android
linktitle: Tamanho da Página de Notas
type: docs
weight: 10
url: /pt/androidjava/notes-size/
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
- Android
- Java
- Aspose.Slides
description: "Leia e altere as dimensões da página de notas no Aspose.Slides para Android via Java, altere a orientação, verifique os tamanhos salvos e exporte notas ou folhetos para PDF e imagens."
---
## **Visão geral**

Use [Presentation.getNotesSize](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getNotesSize--) para acessar as configurações da página de notas da apresentação. Ele devolve um objeto [INotesSize](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/inotessize/) cujo método [setSize](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) define as dimensões da página. Embora o objeto de configurações não possa ser substituído, você pode atribuir novas dimensões através desse método.

Largura e altura são especificadas em **pontos**, com 72 pontos por polegada. Por exemplo, 900 × 600 pontos correspondem a 12,5 × 8⅓ polegadas. Essas configurações se aplicam à apresentação, e não a notas de um slide individual.

| Configuração | Finalidade |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getNotesSize--) | Controla as dimensões da página de notas e as dimensões usadas na exportação de folhetos. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getSlideSize--) | Controla as dimensões regulares dos slides da apresentação por meio de [ISlideSize](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/islidesize/). |

Alterar uma das configurações não altera automaticamente a outra. Alterar a orientação da página de notas também não gira os slides normais. Consulte [Slide Size](/slides/pt/androidjava/slide-size/) para redimensionar os slides regulares.

Os exemplos abaixo utilizam um arquivo `sample.pptx` existente. Para os exemplos de exportação, use uma apresentação que contenha ao menos um slide com anotações de apresentador. Cada exemplo pode ser executado de forma independente.

## **Ler o Tamanho e Orientação da Página de Notas**

Leia a largura e a altura e compare-as para determinar a orientação: uma página mais larga é paisagem, uma página mais alta é retrato, e dimensões iguais descrevem uma página quadrada. Este exemplo imprime as dimensões reais em pontos, sem assumir um tamanho de papel padrão.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Alterar para Paisagem sem Modificar o Tamanho do Papel**

Para mudar apenas a orientação, troque a largura e a altura existentes. Isso preserva o comprimento de ambos os lados, inclusive de um tamanho de papel personalizado. A condição abaixo impede que uma página já em paisagem seja revertida para retrato e deixa uma página quadrada inalterada.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para orientação retrato, use a mesma atribuição quando `size.getWidth() > size.getHeight()`. Não substitua as dimensões A4 ou Letter a menos que também deseje mudar o tamanho do papel.

## **Definir e Verificar um Tamanho Personalizado da Página de Notas**

Atribua ambas as dimensões simultaneamente e, em seguida, use [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) para gravar a apresentação. Este exemplo define uma página paisagem de 900 × 600 pontos, salva-a como PPTX e abre o arquivo salvo novamente para verificar os valores persistidos. A comparação permite uma tolerância de 0,01 ponto para valores de ponto flutuante; isso não garante precisão para todos os formatos de arquivo.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

O resultado esperado é `900.0 x 600.0 points` e `Size preserved: true`. Verificar uma apresentação recém‑aberta confirma o arquivo salvo, e não apenas as configurações em memória.

## **Exportar Notas e Folhetos**

As dimensões da página definem a área disponível para layouts de notas ou folhetos. Elas não habilitam esses layouts por si só: configure também as opções de exportação. A exportação de slides regulares continua a usar as dimensões dos slides.

### **Exportar Notas para PDF e PNG**

Atribua [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/notescommentslayoutingoptions/) a [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) para incluir notas no PDF. Este exemplo também renderiza o primeiro slide com notas em PNG usando [Slide.getImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) e [RenderingOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/renderingoptions/).

O modo [BottomTruncated](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/notespositions/) mantém as notas em uma única página; notas que não couberem podem ser truncadas. O PDF usa páginas de 900 × 600 pontos. Na escala de imagem 1 × 1 usada abaixo, o PNG tem 900 × 600 pixels. Pontos descrevem a geometria da página; pixels descrevem a saída raster, cujas dimensões também dependem da escala de renderização.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Para exportação em PDF com notas longas, [BottomFull](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/notespositions/) permite páginas adicionais conforme necessário. Não use esse modo com a chamada de imagem de slide único acima, que não o suporta. Após redimensionar, inspecione a saída para notas cortadas e a posicionamento de objetos de mestre de notas existentes; mudar apenas as dimensões da página não garante que todo o conteúdo caberá. Consulte [Convert PowerPoint to PDF with Notes](/slides/pt/androidjava/convert-powerpoint-to-pdf-with-notes/) para mais informações sobre exportação de notas.

### **Exportar Folhetos para PDF**

Use [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/handoutlayoutingoptions/) para múltiplas miniaturas de slides em uma página. O exemplo a seguir define uma página de 900 × 600 pontos e usa [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/handouttype/) para organizar até quatro slides por página. O predefinido horizontal controla a ordem dos slides; a orientação da página vem de sua largura e altura.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Alterar o tamanho da página muda a área disponível para a grade de folhetos sem alterar as dimensões dos slides de origem. Para imagens de folhetos, use [Presentation.getImages](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) com o layout de folheto, em vez do método de imagem de slide individual. No Aspose.Slides, a renderização de folhetos em nível de apresentação usa as dimensões da página de notas, enquanto a chamada de imagem de slide individual não produz a página de folheto. Consulte [Handout Mode](/slides/pt/androidjava/convert-powerpoint-in-handout-mode/) para opções de layout.

## **Tamanho da Página em Visualizadores, Exportação e Impressão**

Mantenha distintos o tamanho armazenado da apresentação, o tamanho da página exportada e o tamanho do papel impresso:

- **Visualizadores de apresentação:** Um visualizador pode exibir ou imprimir notas usando suas próprias regras de layout. Se outro aplicativo salvar o arquivo, reabra‑o e verifique as dimensões novamente; a conversão de formato desse aplicativo pode normalizá‑las.
- **Formatos de exportação:** Os exemplos de PDF de notas e folhetos acima usam as dimensões de página configuradas. Imagens raster usam dimensões de pixel inteiras e uma escala de renderização, de modo que valores fracionários de ponto podem ser arredondados na saída da imagem. Exportar slides regulares não aplica o tamanho da página de notas.
- **Drivers de impressora:** A seleção de papel, rotação automática e configurações de ajustar‑à‑página podem mudar a saída física sem alterar as dimensões armazenadas na apresentação ou no PDF. Para um tamanho de papel específico, combine as configurações da impressora e inspecione a visualização de impressão.

## **FAQ**

**Posso definir o tamanho das notas para apenas um slide?**

O tamanho da página de notas é uma configuração de nível de apresentação. Slides individuais podem ter conteúdos de notas diferentes, mas essa propriedade não fornece um tamanho de página separado para cada slide.

**Por que mudar a orientação das notas não alterou meus slides?**

Páginas de notas e slides regulares têm dimensões independentes. Use as configurações de tamanho de slide regular quando desejar redimensionar os próprios slides.

**Por que o resultado salvo ou impresso tem tamanho diferente?**

Primeiro, reabra a apresentação salva e compare suas dimensões de notas. Se elas mudaram, verifique se salvar ou converter o arquivo em outro aplicativo alterou as configurações da página. Se não, verifique o layout de exportação, a escala da imagem, as configurações do visualizador e a seleção de papel da impressora.