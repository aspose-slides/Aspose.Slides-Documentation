---
title: Converter PPT e PPTX para PDF em Python | Opções avançadas
linktitle: PowerPoint para PDF
type: docs
weight: 40
url: /pt/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
- converter PowerPoint
- apresentação
- PowerPoint para PDF
- PPT para PDF
- PPTX para PDF
- salvar PowerPoint como PDF
- anexo
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Guia passo a passo para converter PPT, PPTX e ODP em PDFs de alta qualidade e compatíveis com WCAG em Python com Aspose.Slides — inclui proteção por senha, seleção de slides e controle de qualidade de imagem."
showReadingTime: true
---
## **Visão geral**

Converter apresentações do PowerPoint (PPT, PPTX, ODP) para PDF em Python oferece várias vantagens, incluindo garantir compatibilidade entre diferentes dispositivos e preservar o layout e a formatação da sua apresentação. Este guia demonstra como converter apresentações para documentos PDF, utilizar diversas opções para controlar a qualidade de imagem, incluir slides ocultos, proteger PDFs com senha, detectar substituições de fontes, selecionar slides específicos para conversão e aplicar padrões de conformidade aos documentos de saída.

## **Conversões de PowerPoint para PDF**

Usando Aspose.Slides, você pode converter apresentações nesses formatos para PDF:

* **PPT**
* **PPTX**
* **ODP**

Para converter uma apresentação para PDF em Python, basta passar o nome do arquivo como argumento para a classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) e então salvar a apresentação como PDF usando o método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). A classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expõe o método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) que normalmente é usado para converter uma apresentação para PDF.

{{% alert color="info" title="Nota" %}}

Aspose.Slides for Python insere suas informações de API e número da versão nos documentos de saída. Por exemplo, ao converter uma apresentação para PDF, Aspose.Slides for Python preenche o campo Application com o valor '*Aspose.Slides*' e o campo PDF Producer com um valor no formato '*Aspose.Slides v XX.XX*'. **Nota** que não é possível instruir o Aspose.Slides for Python a alterar ou remover essas informações dos documentos de saída.

{{% /alert %}}

Aspose.Slides permite que você converta:

* Apresentações inteiras para PDF
* Slides específicos em uma apresentação para PDF

Aspose.Slides exporta apresentações para PDF, garantindo que o conteúdo dos PDFs resultantes corresponda de perto às apresentações originais. Elementos e atributos são renderizados com precisão na conversão, incluindo:

* Imagens
* Caixas de texto e formas
* Formatação de texto
* Formatação de parágrafo
* Hiperlinks
* Cabeçalhos e rodapés
* Marcadores
* Tabelas

## **Converter PowerPoint para PDF**

O processo padrão de conversão de PowerPoint para PDF usa opções padrão. Nesse caso, o Aspose.Slides tenta converter a apresentação fornecida para PDF usando configurações ideais nos níveis máximos de qualidade.

O exemplo a seguir carrega uma apresentação e salva todos os slides visíveis para PDF usando as configurações de exportação padrão.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Nota" %}}

A Aspose oferece um [**conversor de PowerPoint para PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratuito online que demonstra o processo de conversão de apresentação para PDF. Para uma implementação ao vivo do procedimento descrito aqui, você pode fazer um teste com o conversor.

{{% /alert %}}

## **Converter PowerPoint para PDF com Opções**

Aspose.Slides fornece opções personalizadas — propriedades da classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) — que permitem personalizar o PDF (resultado do processo de conversão), bloquear o PDF com senha ou até mesmo especificar como o processo de conversão deve ser executado.

### **Converter PowerPoint para PDF com Opções Personalizadas**

Usando opções de conversão personalizadas, você pode definir sua configuração de qualidade preferida para imagens raster, especificar como metafiles devem ser tratados, definir um nível de compressão para texto, definir DPI para imagens etc.

O exemplo a seguir exporta uma apresentação para PDF 1.5 com qualidade JPEG definida em 90, resolução de imagem em 300 DPI, metafiles salvos como PNG e compressão de texto Flate.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Preservar Arquivos OLE Incorporados como Anexos PDF**

Se uma apresentação contém uma pasta de trabalho Excel incorporada, você pode querer que os destinatários do PDF acessem os dados da pasta de trabalho além de visualizar os slides. Defina [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) como `True` para preservar arquivos OLE incorporados como anexos no PDF resultante.

O valor padrão é `False`: a imagem de visualização ou ícone do objeto OLE é renderizado na página PDF, mas seu arquivo incorporado não é incluído como anexo. Definir a opção como `True` inclui adicionalmente os dados do arquivo. A visualização permanece uma representação visual; o anexo permite que os destinatários abram ou salvem o arquivo incorporado separadamente. O objeto OLE não se torna uma planilha Excel interativa na página PDF.

O exemplo a seguir carrega uma apresentação que já contém uma pasta de trabalho Excel incorporada e a exporta para PDF com a pasta de trabalho anexada.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Para verificar o resultado:

1. Abra o PDF exportado em um visualizador que suporte anexos de arquivo, como o Adobe Acrobat Reader.
2. Abra o painel **Attachments** do visualizador e localize a pasta de trabalho incorporada.
3. Salve o anexo e abra-o no Excel para inspecionar seus dados, ou abra-o diretamente se o visualizador permitir. A visualização na página PDF é separada do anexo.

{{% alert color="info" title="Nota" %}}

Os padrões PDF/A impõem restrições sobre anexos: PDF/A‑1 proíbe arquivos incorporados, PDF/A‑2 permite apenas anexos PDF/A e PDF/A‑3 permite outros tipos de arquivo, incluindo pastas de trabalho Excel. Essas são exigências dos padrões, não restrições específicas do Aspose.Slides. Este exemplo usa a configuração padrão de conformidade PDF e não demonstra exportação PDF/A.

{{% /alert %}}

### **Converter PowerPoint para PDF com Slides Ocultos**

Se uma apresentação contém slides ocultos, você pode usar uma opção personalizada — a propriedade [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) da classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) — para instruir o Aspose.Slides a incluir os slides ocultos como páginas no PDF resultante.

O exemplo a seguir exporta uma apresentação para PDF, incluindo quaisquer slides ocultos.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Converter PowerPoint para um PDF Protegido por Senha**

O exemplo a seguir exporta uma apresentação para um PDF que exige a senha `password` para ser aberto. As permissões de acesso permitem impressão, incluindo impressão de alta qualidade.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Manipular Fontes sem Tipo de Letra Negrito Dedicado**

Uma apresentação pode aplicar formatação em negrito a um texto mesmo quando sua fonte não possui um tipo de letra negrito dedicado. O texto ainda pode aparecer em negrito por meio de negrito sintético, que engrossa artificialmente os glifos regulares. Quando esse texto parece muito pesado ou diferente da aparência pretendida no PDF, tente definir [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) como `True`. Essa opção renderiza o texto afetado como bitmap durante a exportação para PDF e pode melhorar sua aparência para certas fontes. Seu valor padrão é `False`.

A apresentação de exemplo contém duas caixas de texto: uma com texto normal e outra com formatação em negrito aplicada à mesma fonte, que não possui tipo de letra negrito dedicado. O exemplo a seguir carrega a apresentação, habilita a rasterização de estilos de fonte não suportados e a exporta para PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

As pré‑visualizações a seguir mostram a saída desativada e a saída ativada. Neste exemplo, o texto em negrito tem traços mais espessos com a opção desativada. Com a opção ativada, seus traços são mais leves; o texto regular permanece inalterado. Compare os resultados antes de escolher a configuração para sua apresentação.

| Opção desativada (`False`, o padrão) | Opção ativada (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Neste exemplo, habilitar a opção converte apenas o texto em negrito em bitmap: ele não pode ser selecionado, copiado ou pesquisado como texto sem OCR, e suas bordas parecem mais suaves em zoom de 800 %. O texto regular permanece pesquisável. Com a opção desativada, ambas as cadeias permanecem como texto.

Esta opção rasteriza texto formatado como negrito quando sua fonte não tem tipo de letra negrito dedicado. [Font substitution](/slides/pt/python-net/font-substitution/) em vez disso seleciona outra fonte quando a original não está disponível.

## **Converter Slides Selecionados do PowerPoint para PDF**

O exemplo a seguir exporta os slides 1 e 3 de uma apresentação para PDF. Os números dos slides neste array são baseados em 1, e a apresentação de entrada deve conter ao menos três slides.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Converter PowerPoint para PDF com Tamanho de Slide Personalizado**

O exemplo a seguir copia o primeiro slide de uma apresentação para uma nova apresentação com tamanho de slide de 612 × 792 pontos (8,5 × 11 polegadas). Ele escala o conteúdo do slide para caber e exporta o slide único para PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Remover o slide em branco criado na nova apresentação.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Converter PowerPoint para PDF no modo de Notas de Slide**

O exemplo a seguir exporta uma apresentação para PDF, colocando as notas do apresentador de cada slide abaixo do slide. Use uma apresentação que contenha notas do apresentador para ver o resultado.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Acessibilidade e Padrões de Conformidade para PDF**

Aspose.Slides permite que você use um procedimento de conversão que esteja em conformidade com as [Diretrizes de Acessibilidade de Conteúdo Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Você pode exportar um documento PowerPoint para PDF usando qualquer um desses padrões de conformidade: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Este código Python demonstra uma operação de conversão de PowerPoint para PDF na qual vários PDFs baseados em diferentes padrões de conformidade são obtidos:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert color="info" title="Nota" %}}

O suporte do Aspose.Slides para operações de conversão de PDF permite que você converta PDF para os formatos de arquivo mais populares. Você pode fazer [PDF to HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) e [PDF to PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) conversões. Outras operações de conversão de PDF para formatos especializados — [PDF to SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), e [PDF to XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) — também são suportadas.

{{% /alert %}}

> **Nota:** Ao exportar para PDF/UA, o Aspose.Slides trata gráficos complexos como SmartArt, diagramas e fórmulas como uma única figura. Elementos individuais de caminho não são preservados como conteúdo separado e podem ser marcados como artefatos; texto alternativo é fornecido apenas para a figura completa.

## **FAQ**

**O Aspose.Slides for Python pode remover as informações da aplicação do PDF?**

Não, o Aspose.Slides for Python inclui automaticamente informações da API e o número da versão no PDF de saída. Essas informações não podem ser modificadas ou removidas.

**Como incluir apenas slides específicos na conversão para PDF?**

Você pode especificar os índices dos slides que deseja converter passando um array de posições de slides para o método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**É possível proteger o PDF com senha durante a conversão?**

Sim, você pode definir uma senha e definir permissões de acesso usando a classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) antes de salvar a apresentação como PDF.

**O Aspose.Slides suporta a conversão de PDF para outros formatos?**

Sim, o Aspose.Slides suporta a conversão de PDFs para formatos como HTML, formatos de imagem (JPG, PNG), SVG, TIFF e XML.

**Como garantir que meu PDF esteja em conformidade com padrões de acessibilidade?**

Defina a propriedade [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) em [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) para padrões como `PDF_A1A`, `PDF_A1B` ou `PDF_UA` para garantir a conformidade com as diretrizes de acessibilidade.

**Posso incluir slides ocultos na saída PDF?**

Sim, definindo a propriedade [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) em [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) como `True`, os slides ocultos serão incluídos no PDF.

**Como ajustar a qualidade e a resolução de imagem durante a conversão?**

Use as propriedades [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) e [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) em [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) para controlar a qualidade e a resolução da imagem no PDF resultante.

**O Aspose.Slides lida automaticamente com substituições de fontes?**

O Aspose.Slides detecta substituições de fontes durante a conversão, e você pode tratá‑las usando a propriedade `warning_callback` em `SaveOptions` (atualmente limitado).

## **Recursos adicionais**

- [Aspose.Slides for Python via .NET Documentation](/slides/pt/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)