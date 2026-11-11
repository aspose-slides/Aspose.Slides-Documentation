---
title: Alterar Tamanho e Orientação da Página de Notas em Python
linktitle: Tamanho da Página de Notas
type: docs
weight: 10
url: /pt/python-net/notes-size/
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
- Python
- Aspose.Slides
description: "Leia e altere as dimensões da página de notas no Aspose.Slides para Python via .NET, altere a orientação, verifique os tamanhos salvos e exporte notas ou folhetos para PDF e imagens."
---
## **Visão geral**

Use [Presentation.notes_size](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/notes_size/) para acessar as configurações da página de notas da apresentação. Ele retorna um objeto [NotesSize](https://reference.aspose.com/slides/pt/python-net/aspose.slides/notessize/) cujo a propriedade [size](https://reference.aspose.com/slides/pt/python-net/aspose.slides/notessize/size/) pode ser escrita. Embora o próprio objeto de configurações seja somente leitura, você pode atribuir novas dimensões à sua propriedade size.

A largura e a altura são especificadas em **pontos**, com 72 pontos por polegada. Por exemplo, 900 × 600 pontos correspondem a 12,5 × 8⅓ polegadas. Essas configurações se aplicam à apresentação, e não às notas de um slide individual.

| Configuração | Finalidade |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/notes_size/) | Controla as dimensões da página de notas e as dimensões da página usadas na exportação de folhetos. |
| [Presentation.slide_size](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/slide_size/) | Controla as dimensões dos slides regulares da apresentação através de [SlideSize](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidesize/). |

Alterar uma das configurações não altera automaticamente a outra. Alterar a orientação da página de notas também não gira os slides regulares. Consulte [Tamanho do Slide](/slides/pt/python-net/slide-size/) para redimensionar os slides regulares.

Os exemplos abaixo utilizam um `sample.pptx` existente. Para os exemplos de exportação, use uma apresentação que contenha ao menos um slide com notas do apresentador. Cada exemplo pode ser executado independentemente.

## **Leia o Tamanho e a Orientação da Página de Notas**

Leia a largura e a altura e compare-as para determinar a orientação: uma página mais larga é paisagem, uma página mais alta é retrato, e dimensões iguais descrevem uma página quadrada. Este exemplo imprime as dimensões reais em pontos, sem assumir um tamanho de papel padrão.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **Mudar para Paisagem sem Alterar o Tamanho do Papel**

Para mudar apenas a orientação, troque a largura e a altura existentes. Isso preserva o comprimento de ambos os lados, inclusive de um tamanho de papel personalizado. A condição abaixo impede que uma página já em paisagem seja trocada de volta para retrato e deixa uma página quadrada inalterada.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

Para orientação retrato, use a mesma atribuição quando `size.width > size.height`. Não substitua as dimensões A4 ou Letter a menos que você também queira alterar o tamanho do papel.

## **Defina e Verifique um Tamanho Personalizado da Página de Notas**

Atribua ambas as dimensões juntas, então use [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/) para gravar a apresentação. Este exemplo define uma página paisagem de 900 × 600 pontos, salva-a como PPTX e abre o arquivo salvo novamente para verificar os valores persistidos. A comparação permite uma tolerância de 0,01 ponto para valores de ponto flutuante; isso não garante precisão para todos os formatos de arquivo.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

O resultado esperado é `900 x 600 points` e `Size preserved: True`. Verificar uma apresentação recém‑aberta confirma o arquivo salvo, em vez de apenas as configurações em memória.

## **Exportar Notas e Folhetos**

As dimensões da página definem a área disponível para layouts de notas ou folhetos. Elas não habilitam esses layouts por si só: configure também as opções de exportação. A exportação de slides regulares continua a usar as dimensões dos slides.

### **Exportar Notas para PDF e PNG**

Atribua [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/notescommentslayoutingoptions/) a [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) para incluir notas no PDF. Este exemplo também renderiza o primeiro slide com notas para PNG usando [Slide.get_image](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/) e [RenderingOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/renderingoptions/).

O modo [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/notespositions/) mantém as notas em uma única página; notas que não cabem podem ser truncadas. O PDF usa páginas de 900 × 600 pontos. Na escala de imagem de 1 × 1 usada abaixo, o PNG tem 900 × 600 pixels. Pontos descrevem a geometria da página; pixels descrevem a saída raster, cujas dimensões também dependem da escala de renderização.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

Para exportação de PDF com notas longas, [BOTTOM_FULL](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/notespositions/) permite páginas adicionais conforme necessário. Não use esse modo com a chamada de imagem de slide único acima, que não o suporta. Após redimensionar, inspecione a saída para notas cortadas e o posicionamento dos objetos notes‑master existentes; mudar apenas as dimensões da página não deve ser considerado uma garantia de que todo o conteúdo caberá. Consulte [Converter PowerPoint para PDF com Notas](/slides/pt/python-net/convert-powerpoint-to-pdf-with-notes/) para mais detalhes sobre exportação de notas.

### **Exportar Folhetos para PDF**

Use [HandoutLayoutingOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/handoutlayoutingoptions/) para múltiplas miniaturas de slides em uma página. O exemplo a seguir define uma página de 900 × 600 pontos e usa [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/handouttype/) para organizar até quatro slides por página. A predefinição horizontal controla a ordem dos slides; a orientação da página vem de sua largura e altura.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Alterar o tamanho da página muda a área disponível para a grade de folhetos sem mudar as dimensões dos slides de origem. Para imagens de folhetos, use [Presentation.get_images](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/get_images/) com o layout de folheto, em vez do método de imagem de um slide individual. No Aspose.Slides, a renderização de folhetos em nível de apresentação usa as dimensões da página de notas, enquanto a chamada de imagem de slide individual não produz a página de folheto. Consulte [Modo Folheto](/slides/pt/python-net/convert-powerpoint-in-handout-mode/) para opções de layout.

## **Tamanho da Página em Visualizadores, Exportação e Impressão**

Mantenha distintos o tamanho da apresentação armazenado, o tamanho da página exportada e o tamanho do papel impresso:

- **Presentation viewers:** Um visualizador pode exibir ou imprimir notas usando suas próprias regras de layout. Se outro aplicativo salvar o arquivo, reabra‑o e verifique as dimensões novamente; a conversão de formato desse aplicativo pode normalizá‑las.
- **Export formats:** Os exemplos de PDF de notas e folhetos acima usam as dimensões de página configuradas. Imagens raster utilizam dimensões de pixel inteiras e uma escala de renderização, portanto valores fracionais de pontos podem ser arredondados na saída da imagem. Exportar slides regulares não aplica o tamanho da página de notas.
- **Printer drivers:** A seleção de papel, rotação automática e configurações de ajuste à página podem mudar a saída física sem alterar as dimensões armazenadas na apresentação ou no PDF. Para um tamanho de papel específico, ajuste as configurações da impressora e verifique a pré‑visualização de impressão.

## **FAQ**

**Posso definir o tamanho das notas apenas para um slide?**

O tamanho da página de notas é uma configuração em nível de apresentação. Slides individuais podem ter conteúdo de notas diferente, mas essa propriedade não fornece um tamanho de página separado para cada slide.

**Por que mudar a orientação das notas não mudou meus slides?**

As páginas de notas e os slides regulares têm dimensões independentes. Use as configurações de tamanho de slide regular quando quiser redimensionar os próprios slides.

**Por que meu resultado salvo ou impresso tem um tamanho diferente?**

Primeiro reabra a apresentação salva e compare as dimensões das notas. Se elas mudaram, verifique se salvar ou converter o arquivo em outro aplicativo alterou as configurações da página. Se não, verifique o layout de exportação, a escala da imagem, as configurações do visualizador e a seleção de papel da impressora.