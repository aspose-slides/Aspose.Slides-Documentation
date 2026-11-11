---
title: Alterar tamanho e orientação da página de notas em Python via Java
linktitle: Tamanho da página de notas
type: docs
weight: 10
url: /pt/python-java/notes-size/
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
- Python
- Java
- Aspose.Slides
description: "Leia e altere as dimensões da página de notas no Aspose.Slides para Python via Java, altere a orientação, verifique os tamanhos salvos e exporte notas ou folhetos para PDF e imagens."
---
## **Visão geral**

Use [Presentation.getNotesSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getNotesSize) para acessar as configurações da página de notas da apresentação. Ele retorna um objeto [NotesSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notessize/) cujo método [setSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notessize/#setSize) define as dimensões da página. Embora o objeto de configurações não possa ser substituído, você pode atribuir novas dimensões por meio desse método.

A largura e a altura são especificadas em **pontos**, com 72 pontos por polegada. Por exemplo, 900 × 600 pontos correspondem a 12,5 × 8 ⅓ polegadas. Essas configurações se aplicam à apresentação, e não às notas de um slide individual.

| Configuração | Propósito |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getNotesSize) | Controla as dimensões da página de notas e as dimensões de página usadas na exportação de folhetos. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSlideSize) | Controla as dimensões dos slides regulares da apresentação através de [SlideSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidesize/). |

Alterar uma das configurações não altera automaticamente a outra. Alterar a orientação da página de notas também não gira os slides regulares. Consulte [Slide Size](/slides/pt/python-java/slide-size/) para redimensionar os slides regulares.

Os exemplos abaixo utilizam um `sample.pptx` existente. Para os exemplos de exportação, use uma apresentação com ao menos um slide contendo notas do apresentador. Cada exemplo pode ser executado independentemente.

## **Ler o tamanho e a orientação da página de notas**

Leia a largura e a altura e compare-as para determinar a orientação: uma página mais larga é paisagem, uma página mais alta é retrato, e dimensões iguais descrevem uma página quadrada. Este exemplo imprime as dimensões reais em pontos, sem assumir um tamanho de papel padrão.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **Mudar para paisagem sem alterar o tamanho do papel**

Para mudar apenas a orientação, troque a largura e a altura existentes. Isso preserva o comprimento de ambos os lados, incluindo os de um tamanho de papel personalizado. A condição abaixo impede que uma página já em paisagem seja revertida para retrato e deixa uma página quadrada inalterada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para orientação retrato, use a mesma atribuição quando `size.getWidth() > size.getHeight()`. Não substitua dimensões A4 ou Letter a menos que também deseje alterar o tamanho do papel.

## **Definir e verificar um tamanho de página de notas personalizado**

Atribua ambas as dimensões simultaneamente e, em seguida, use [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) para gravar a apresentação. Este exemplo define uma página paisagem de 900 × 600 pontos, salva-a como PPTX e abre o arquivo salvo novamente para verificar os valores persistidos. A comparação permite uma tolerância de 0,01 ponto para valores de ponto flutuante; isso não garante precisão para todos os formatos de arquivo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

O resultado esperado é `900.0 x 600.0 points` e `Size preserved: True`. Verificar uma apresentação recém‑aberta confirma o arquivo salvo, e não apenas as configurações em memória.

## **Exportar notas e folhetos**

As dimensões da página definem a área disponível para layouts de notas ou folhetos. Elas não habilitam esses layouts por si só: configure também as opções de exportação. A exportação de slides regulares continua a usar as dimensões dos slides.

### **Exportar notas para PDF e PNG**

Atribua [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notescommentslayoutingoptions/) a [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) para incluir notas no PDF. Este exemplo também renderiza o primeiro slide com notas para PNG usando [Slide.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage) e [RenderingOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/renderingoptions/).

O modo [BottomTruncated](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notespositions/) mantém as notas em uma única página; notas que não couberem podem ser truncadas. O PDF usa páginas de 900 × 600 pontos. Na escala de imagem 1 × 1 usada abaixo, o PNG tem 900 × 600 pixels. Pontos descrevem a geometria da página; pixels descrevem a saída raster, cujas dimensões também dependem da escala de renderização.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Para exportação de PDF com notas longas, [BottomFull](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notespositions/) permite páginas adicionais conforme necessário. Não use esse modo com a chamada de imagem de slide único acima, que não o suporta. Após redimensionar, inspecione a saída para notas cortadas e a posição dos objetos existentes de notes‑master; mudar apenas as dimensões da página não garante que todo o conteúdo se encaixará. Consulte [Convert PowerPoint to PDF with Notes](/slides/pt/python-java/convert-powerpoint-to-pdf-with-notes/) para mais informações sobre exportação de notas.

### **Exportar folhetos para PDF**

Use [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/handoutlayoutingoptions/) para múltiplas miniaturas de slides em uma página. O exemplo a seguir define uma página de 900 × 600 pontos e usa [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/pt/python-java/aspose.slides/handouttype/) para organizar até quatro slides por página. O preset horizontal controla a ordem dos slides; a orientação da página vem de sua largura e altura.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Alterar o tamanho da página muda a área disponível para a grade de folhetos sem mudar as dimensões dos slides de origem. Para imagens de folhetos, use [Presentation.getImages](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getImages) com o layout de folheto, em vez do método de imagem de um slide individual. No Aspose.Slides, a renderização de folhetos em nível de apresentação usa as dimensões da página de notas, enquanto a chamada de imagem de slide individual não produz a página de folheto. Consulte [Handout Mode](/slides/pt/python-java/convert-powerpoint-in-handout-mode/) para opções de layout.

## **Tamanho da página em visualizadores, exportação e impressão**

Mantenha distintos o tamanho da apresentação armazenado, o tamanho da página exportada e o tamanho do papel impresso:

- **Visualizadores de apresentação:** Um visualizador pode exibir ou imprimir notas usando suas próprias regras de layout. Se outro aplicativo salvar o arquivo, reabra‑o e verifique as dimensões novamente; a conversão de formato desse aplicativo pode normalizá‑las.
- **Formatos de exportação:** Os exemplos de PDF de notas e folhetos acima utilizam as dimensões de página configuradas. Imagens raster utilizam dimensões inteiras de pixels e uma escala de renderização, de modo que valores fracionados de pontos podem ser arredondados na saída da imagem. A exportação de slides regulares não aplica o tamanho da página de notas.
- **Drivers de impressora:** Seleção de papel, rotação automática e configurações de ajuste à página podem alterar a saída física sem mudar as dimensões armazenadas na apresentação ou no PDF. Para um tamanho de papel específico, combine as configurações da impressora e inspecione a visualização de impressão.

## **FAQ**

**Posso definir o tamanho das notas para apenas um slide?**

O tamanho da página de notas é uma configuração em nível de apresentação. Slides individuais podem ter conteúdo de notas diferente, mas essa propriedade não fornece um tamanho de página separado para cada slide.

**Por que mudar a orientação das notas não alterou meus slides?**

Páginas de notas e slides regulares têm dimensões independentes. Use as configurações de tamanho de slide regular quando quiser redimensionar os próprios slides.

**Por que meu resultado salvo ou impresso tem um tamanho diferente?**

Primeiro reabra a apresentação salva e compare as dimensões das notas. Se elas mudaram, verifique se salvar ou converter o arquivo em outro aplicativo alterou as configurações de página. Caso não tenham mudado, verifique o layout de exportação, a escala da imagem, as configurações do visualizador e a seleção de papel da impressora.