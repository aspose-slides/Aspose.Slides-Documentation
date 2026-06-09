---
title: Converter PPT e PPTX para PDF em Python | Opções avançadas
linktitle: PowerPoint para PDF
type: docs
weight: 40
url: /pt/python-net/convert-powerpoint-to-pdf/
keywords:
- converter PowerPoint
- apresentação
- PowerPoint para PDF
- PPT para PDF
- PPTX para PDF
- salvar PowerPoint como PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Guia passo a passo para converter PPT, PPTX e ODP em PDFs de alta qualidade e compatíveis com WCAG em Python com Aspose.Slides — inclui proteção por senha, seleção de slides e controle de qualidade de imagem."
showReadingTime: true
---
## **Visão geral**

Converter apresentações PowerPoint (PPT, PPTX, ODP) para PDF em Python oferece várias vantagens, incluindo garantir compatibilidade entre diferentes dispositivos e preservar o layout e a formatação da sua apresentação. Este guia demonstra como converter apresentações para documentos PDF, utilizar várias opções para controlar a qualidade da imagem, incluir slides ocultos, proteger PDFs com senha, detectar substituições de fontes, selecionar slides específicos para conversão e aplicar padrões de conformidade aos documentos de saída.

## **Conversões de PowerPoint para PDF**

Usando Aspose.Slides, você pode converter apresentações nesses formatos para PDF:

* **PPT**
* **PPTX**
* **ODP**

Para converter uma apresentação para PDF em Python, basta passar o nome do arquivo como argumento na classe [Presentation](https://docs.aspose.com/slides/pt/python-net/api-reference/aspose.slides/presentation/) e então salvar a apresentação como PDF usando o método [Save](https://docs.aspose.com/slides/pt/python-net/api-reference/aspose.slides/presentation/#methods). A classe [Presentation](https://docs.aspose.com/slides/pt/python-net/api-reference/aspose.slides/presentation/) expõe o método [Save](https://docs.aspose.com/slides/pt/python-net/api-reference/aspose.slides/presentation/#methods) que normalmente é usado para converter uma apresentação para PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python grava diretamente informações da API e o número da versão em documentos de saída. Por exemplo, ao converter uma apresentação para PDF, Aspose.Slides for Python preenche o campo Aplicativo com o valor '*Aspose.Slides*' e o campo Produtor PDF com um valor no formato '*Aspose.Slides v XX.XX*'. **Observação**: não é possível instruir o Aspose.Slides for Python a alterar ou remover essas informações dos documentos de saída.

{{% /alert %}}

Aspose.Slides permite que você converta:

* Apresentações completas para PDF
* Slides específicos de uma apresentação para PDF

Aspose.Slides exporta apresentações para PDF, garantindo que o conteúdo dos PDFs resultantes corresponda estreitamente às apresentações originais. Elementos e atributos são renderizados com precisão na conversão, incluindo:

* Imagens
* Caixas de texto e formas
* Formatação de texto
* Formatação de parágrafo
* Hyperlinks
* Cabeçalhos e rodapés
* Marcadores
* Tabelas

## **Converter PowerPoint para PDF**

A operação padrão de conversão PowerPoint → PDF é executada usando opções padrão. Nesse caso, Aspose.Slides tenta converter a apresentação fornecida para PDF usando configurações ideais nos níveis máximos de qualidade. Este código Python mostra como converter um PowerPoint para PDF:

_Passos: Conversões PowerPoint → PDF em Python_

O código de exemplo a seguir explica essas conversões usando Python via .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Passos: Converter PowerPoint para PDF usando Python via .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Passos: Converter PPT para PDF usando Python via .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Passos: Converter PPTX para PDF usando Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Passos: Converter ODP para PDF usando Python via .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Passos: Converter PPS para PDF usando Python via .NET</strong></a>

_Passos de Código:_

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) e forneça a ela o arquivo PowerPoint.
  * extensão _.ppt_ para carregar o arquivo **PPT** dentro da classe _Presentation_.
  * extensão _.pptx_ para carregar o arquivo **PPTX** dentro da classe _Presentation_.
  * extensão _.odp_ para carregar o arquivo **ODP** dentro da classe _Presentation_.
  * extensão _.pps_ para carregar o arquivo **PPS** dentro da classe _Presentation_.
- Salve o _Presentation_ no formato **PDF** chamando o método **Save** e usando a enumeração **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Instancia uma classe Presentation que representa um arquivo PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Salva a apresentação como PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose fornece um conversor online gratuito de [**PowerPoint para PDF**](https://products.aspose.app/slides/pt/conversion/ppt-to-pdf) que demonstra o processo de conversão de apresentação para PDF. Para uma implementação ao vivo do procedimento descrito aqui, você pode fazer um teste com o conversor.

{{% /alert %}}

## **Converter PowerPoint para PDF com Opções**

Aspose.Slides fornece opções personalizadas — propriedades da classe [PdfOptions](https://docs.aspose.com/slides/pt/python-net/api-reference/aspose.slides.export/pdfoptions/) — que permitem personalizar o PDF (resultante do processo de conversão), bloquear o PDF com senha ou até especificar como o processo de conversão deve ocorrer.

### **Converter PowerPoint para PDF com Opções Personalizadas**

Usando opções de conversão personalizadas, você pode definir sua configuração preferida de qualidade para imagens raster, especificar como metafiles devem ser tratados, definir um nível de compressão para textos, definir DPI para imagens etc.

O exemplo de código abaixo demonstra uma operação na qual uma apresentação PowerPoint é convertida para PDF com várias opções personalizadas:

```python
import aspose.slides as slides

# Instancia a classe PdfOptions
pdf_options = slides.export.PdfOptions()

# Define a qualidade para imagens JPG
pdf_options.jpeg_quality = 90

# Define DPI para imagens
pdf_options.sufficient_resolution = 300

# Define o comportamento para metafiles
pdf_options.save_metafiles_as_png = True

# Define o nível de compressão de texto para conteúdo textual
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Define o modo de conformidade PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Instancia a classe Presentation que representa um documento PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Salva a apresentação como um documento PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Converter PowerPoint para PDF com Slides Ocultos**

Se uma apresentação contém slides ocultos, você pode usar a opção personalizada — a propriedade `show_hidden_slides` da classe [PdfOptions](https://docs.aspose.com/slides/pt/python-net/api-reference/aspose.slides.export/pdfoptions/) — para instruir o Aspose.Slides a incluir os slides ocultos como páginas no PDF resultante.

Este código Python mostra como converter uma apresentação PowerPoint para PDF com slides ocultos incluídos:

```python
import aspose.slides as slides

# Instancia uma classe Presentation que representa um arquivo PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Instancia a classe PdfOptions
pdfOptions = slides.export.PdfOptions()

# Adiciona slides ocultos
pdfOptions.show_hidden_slides = True

# Salva a apresentação como PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Converter PowerPoint para PDF Protegido por Senha**

Este código Python mostra como converter um PowerPoint para um PDF protegido por senha (usando parâmetros de proteção da classe [PdfOptions](https://docs.aspose.com/slides/pt/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Instancia um objeto Presentation que representa um arquivo PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Instancia a classe PdfOptions
pdfOptions = slides.export.PdfOptions()

# Define a senha do PDF e as permissões de acesso
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Salva a apresentação como PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Converter Slides Selecionados no PowerPoint para PDF**

Este código Python mostra como converter slides específicos em uma apresentação PowerPoint para PDF:

```python
import aspose.slides as slides

# Instancia um objeto Presentation que representa um arquivo PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Define um array de posições de slides
slides_array = [ 1, 3 ]

# Salva a apresentação como PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Converter PowerPoint para PDF com Tamanho de Slide Personalizado**

Este código Python mostra como converter um PowerPoint quando seu tamanho de slide é especificado para PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Instancia a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Cria uma nova apresentação com um tamanho de slide ajustado.
    with slides.Presentation() as resized_presentation:

        # Define o tamanho de slide personalizado.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Clona o primeiro slide da apresentação original.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Salva a apresentação redimensionada em um PDF com notas.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Converter PowerPoint para PDF em Visualização de Notas de Slide**

Este código Python mostra como converter um PowerPoint para PDF de notas:

```python
import aspose.slides as slides

# Instancia uma classe Presentation que representa um arquivo PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Salva a apresentação como PDF de notas
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Acessibilidade e Padrões de Conformidade para PDF**

Aspose.Slides permite usar um procedimento de conversão que está em conformidade com as [Diretrizes de Acessibilidade de Conteúdo Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Você pode exportar um documento PowerPoint para PDF usando qualquer um desses padrões de conformidade: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Este código Python demonstra uma operação de conversão PowerPoint → PDF na qual múltiplos PDFs baseados em diferentes padrões de conformidade são obtidos:

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

{{% alert title="Note" color="warning" %}} 

O suporte do Aspose.Slides para operações de conversão de PDF estende‑se permitindo converter PDF para os formatos de arquivo mais populares. Você pode fazer conversões de [PDF para HTML](https://products.aspose.com/slides/pt/python-net/conversion/pdf-to-html/), [PDF para imagem](https://products.aspose.com/slides/pt/python-net/conversion/pdf-to-image/), [PDF para JPG](https://products.aspose.com/slides/pt/python-net/conversion/pdf-to-jpg/), e [PDF para PNG](https://products.aspose.com/slides/pt/python-net/conversion/pdf-to-png/). Outras operações de conversão de PDF para formatos especializados — [PDF para SVG](https://products.aspose.com/slides/pt/python-net/conversion/pdf-to-svg/), [PDF para TIFF](https://products.aspose.com/slides/pt/python-net/conversion/pdf-to-tiff/), e [PDF para XML](https://products.aspose.com/slides/pt/python-net/conversion/pdf-to-xml/) — também são suportadas.

{{% /alert %}}

> **Observação:** Ao exportar para PDF/UA, Aspose.Slides trata gráficos complexos como SmartArt, gráficos e fórmulas como uma única figura. Elementos de caminho individuais não são preservados como conteúdo separado e podem ser marcados como artefatos; o texto alternativo é fornecido apenas para a figura inteira.

## **FAQ**

**O Aspose.Slides for Python pode remover as informações da aplicação do PDF?**

Não, o Aspose.Slides for Python inclui automaticamente informações da API e o número da versão no PDF de saída. Essas informações não podem ser modificadas ou removidas.

**Como incluir apenas slides específicos na conversão para PDF?**

Você pode especificar os índices dos slides que deseja converter passando um array de posições de slide para o método `save`.

**É possível proteger o PDF com senha durante a conversão?**

Sim, você pode definir uma senha e definir permissões de acesso usando a classe `PdfOptions` antes de salvar a apresentação como PDF.

**O Aspose.Slides suporta a conversão de PDF para outros formatos?**

Sim, o Aspose.Slides suporta a conversão de PDFs para formatos como HTML, formatos de imagem (JPG, PNG), SVG, TIFF e XML.

**Como garantir que meu PDF esteja em conformidade com padrões de acessibilidade?**

Defina a propriedade `compliance` em `PdfOptions` para padrões como `PDF_A1A`, `PDF_A1B` ou `PDF_UA` para garantir a conformidade com as diretrizes de acessibilidade.

**Posso incluir slides ocultos na saída PDF?**

Sim, ao definir a propriedade `show_hidden_slides` em `PdfOptions` como `True`, os slides ocultos serão incluídos no PDF.

**Como ajustar a qualidade e a resolução da imagem durante a conversão?**

Use as propriedades `jpeg_quality` e `sufficient_resolution` em `PdfOptions` para controlar a qualidade e a resolução da imagem no PDF resultante.

**O Aspose.Slides lida automaticamente com substituições de fontes?**

O Aspose.Slides detecta substituições de fontes durante a conversão, e você pode tratá‑las usando a propriedade `warning_callback` em `SaveOptions` (atualmente limitada).

## **Recursos Adicionais**

- [Documentação do Aspose.Slides para .NET](https://docs.aspose.com/slides/pt/python-net/)
- [Referência da API Aspose.Slides](https://reference.aspose.com/slides/pt/python-net/)
- [Conversores Online Gratuitos da Aspose](https://products.aspose.app/slides/pt/conversion)