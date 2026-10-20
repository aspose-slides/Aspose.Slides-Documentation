---
title: "Converter PPT & PPTX para PDF em Python | Opções avançadas"
linktitle: "PowerPoint para PDF"
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

Converter apresentações do PowerPoint (PPT, PPTX, ODP) para formato PDF em Python oferece várias vantagens, incluindo garantir a compatibilidade entre diferentes dispositivos e preservar o layout e a formatação da sua apresentação. Este guia demonstra como converter apresentações em documentos PDF, utilizar diversas opções para controlar a qualidade de imagem, incluir slides ocultos, proteger PDFs com senha, detectar substituições de fontes, selecionar slides específicos para conversão e aplicar padrões de conformidade aos documentos de saída.

## **Conversões de PowerPoint para PDF**

Usando Aspose.Slides, você pode converter apresentações nesses formatos para PDF:

* **PPT**
* **PPTX**
* **ODP**

Para converter uma apresentação para PDF em Python, basta passar o nome do arquivo como argumento para a classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) e então salvar a apresentação como PDF usando o método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). A classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expõe o método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) que normalmente é usado para converter uma apresentação para PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python insere informações da sua API e o número da versão nos documentos de saída. Por exemplo, ao converter uma apresentação para PDF, Aspose.Slides for Python preenche o campo Application com o valor '*Aspose.Slides*' e o campo PDF Producer com um valor no formato '*Aspose.Slides v XX.XX*'. **Nota** que você não pode instruir o Aspose.Slides for Python a alterar ou remover essas informações dos documentos de saída.
{{% /alert %}}

Permite converter:

* Todas as apresentações para PDF
* Slides específicos de uma apresentação para PDF

Aspose.Slides exporta apresentações para PDF, garantindo que o conteúdo dos PDFs resultantes corresponda estreitamente às apresentações originais. Elementos e atributos são renderizados com precisão na conversão, incluindo:

* Imagens
* Caixas de texto e formas
* Formatação de texto
* Formatação de parágrafo
* Hiperlinks
* Cabeçalhos e rodapés
* Marcadores
* Tabelas

## **Converter PowerPoint para PDF**

O processo padrão de conversão de PowerPoint para PDF usa opções padrão. Nesse caso, o Aspose.Slides tenta converter a apresentação fornecida para PDF usando configurações otimizadas nos níveis máximos de qualidade.

O exemplo a seguir carrega uma apresentação e salva todos os slides visíveis em PDF usando as configurações de exportação padrão.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
A Aspose oferece um [**Conversor de PowerPoint para PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratuito online que demonstra o processo de conversão de apresentação para PDF. Para uma implementação ao vivo do procedimento descrito aqui, você pode fazer um teste com o conversor.
{{% /alert %}}

## **Converter PowerPoint para PDF com Opções**

Aspose.Slides fornece opções personalizadas — propriedades na classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) — que permitem personalizar o PDF (resultante do processo de conversão), bloquear o PDF com senha ou até especificar como o processo de conversão deve acontecer.

### **Converter PowerPoint para PDF com Opções Personalizadas**

Usando opções de conversão personalizadas, você pode definir sua configuração de qualidade preferida para imagens raster, especificar como metafiles devem ser tratados, definir um nível de compressão para texto, definir DPI para imagens, etc.

O exemplo a seguir exporta uma apresentação para PDF 1.5 com qualidade JPEG definida em 90, resolução de imagem definida em 300 DPI, metafiles salvos como PNG e compressão de texto Flate.

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

### **Selecionar Compressão de Imagem Automaticamente**

Quando uma apresentação contém muitas fotografias ou capturas de tela, reduzir o tamanho do PDF exportado pode facilitar o envio por e‑mail ou o download. Defina [PdfOptions.best_images_compression_ratio](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) como `True` para selecionar automaticamente o algoritmo de compressão mais apropriado para cada imagem durante a exportação para PDF.

O exemplo a seguir carrega uma apresentação existente, habilita a seleção automática de compressão de imagem e a salva como um documento PDF. Todas as demais configurações de exportação de PDF mantêm seus valores padrão.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.best_images_compression_ratio = True

with slides.Presentation("image-heavy.pptx") as presentation:
    presentation.save("image-heavy.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Esta opção seleciona um algoritmo de compressão para cada imagem. Reduzir [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) diminui a qualidade da imagem JPEG, enquanto reduzir [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) permite que as imagens sejam amostradas para uma resolução mais baixa, o que pode reduzir detalhes. Habilitar a seleção automática de compressão não diminui, por si só, nenhuma dessas configurações.

Selecionar algoritmos de compressão de imagem requer tempo de processamento e memória adicionais. A redução de tamanho depende das imagens da apresentação e das configurações de exportação; uma redução fixa não é garantida para todas as apresentações.

### **Preservar Arquivos OLE Incorporados como Anexos PDF**

Se uma apresentação contém uma pasta de trabalho do Excel incorporada, você pode querer que os destinatários do PDF acessem os dados da pasta de trabalho bem como visualizem os slides. Defina [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) como `True` para preservar arquivos OLE incorporados como anexos no PDF resultante.

O valor padrão é `False`: a imagem de visualização ou ícone do objeto OLE é renderizado na página PDF, mas seu arquivo incorporado não é incluído como anexo. Definir a opção como `True` inclui adicionalmente os dados do arquivo. A pré‑visualização permanece uma representação visual; o anexo permite que os destinatários abram ou salvem o arquivo incorporado separadamente. O objeto OLE não se torna uma planilha Excel interativa na página PDF.

O exemplo a seguir carrega uma apresentação que já contém uma pasta de trabalho do Excel incorporada e a exporta para PDF com a pasta de trabalho anexada.

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
3. Salve o anexo e abra-o no Excel para inspecionar seus dados, ou abra-o diretamente se o visualizador permitir. A pré‑visualização na página PDF é separada do anexo.

{{% alert color="info" title="Note" %}}
Os padrões PDF/A impõem restrições aos anexos: PDF/A-1 proíbe arquivos incorporados, PDF/A-2 permite somente anexos PDF/A, e PDF/A-3 permite outros tipos de arquivos, incluindo pastas de trabalho Excel. Estas são exigências dos padrões, não restrições específicas ao Aspose.Slides. Este exemplo usa a configuração padrão de conformidade PDF e não demonstra exportação PDF/A.
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

### **Converter PowerPoint para PDF Protegido por Senha**

O exemplo a seguir exporta uma apresentação para um PDF que requer a senha `password` para ser aberto. As permissões de acesso permitem impressão, incluindo impressão em alta qualidade.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Manipular Fontes sem um Tipo de Letra Negrito Dedicado**

Uma apresentação pode aplicar formatação em negrito a um texto mesmo quando sua fonte não possui um tipo de letra negrito dedicado. O texto ainda pode aparecer em negrito por meio de negrito sintético, que espessa artificialmente os glifos regulares. Quando esse texto parece muito pesado ou difere da aparência esperada no PDF, tente definir [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) como `True`. Essa opção renderiza o texto afetado como bitmap durante a exportação para PDF e pode melhorar sua aparência para certas fontes. Seu valor padrão é `False`.

A apresentação de exemplo contém duas caixas de texto: uma com texto normal e outra com formatação em negrito aplicada à mesma fonte, que não possui tipo de letra negrito dedicado. O exemplo a seguir carrega a apresentação, habilita a rasterização de estilos de fonte não suportados e a exporta para PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

As pré‑visualizações a seguir mostram a saída desativada e a saída ativada. Neste exemplo, o texto em negrito tem traços mais pesados com a opção desativada. Com a opção ativada, seus traços são mais leves; o texto normal permanece inalterado. Compare os resultados antes de escolher a configuração para sua apresentação.

| Opção desativada (`False`, o padrão) | Opção ativada (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Neste exemplo, ao habilitar a opção, apenas o texto em negrito se torna um bitmap: ele não pode ser selecionado, copiado ou pesquisado como texto sem OCR, e suas bordas parecem mais suaves em 800 % de zoom. O texto normal permanece pesquisável. Com a opção desativada, ambas as cadeias permanecem como texto.

Esta opção rasteriza textos formatados em negrito quando sua fonte não possui um tipo de letra negrito dedicado. [Substituição de fontes](/slides/pt/python-net/font-substitution/) seleciona outra fonte quando a original não está disponível.

## **Converter Slides Selecionados no PowerPoint para PDF**

O exemplo a seguir exporta os slides 1 e 3 de uma apresentação para PDF. Os números dos slides neste array são baseados em 1, e a apresentação de entrada deve conter pelo menos três slides.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Converter PowerPoint para PDF com Tamanho de Slide Personalizado**

O exemplo a seguir copia o primeiro slide de uma apresentação para uma nova apresentação com tamanho de slide de 612 × 792 pontos (8,5 × 11 polegadas). Ele dimensiona o conteúdo do slide para caber e exporta o slide único para PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Remova o slide em branco que a nova apresentação foi criada.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Converter PowerPoint para PDF na Visualização de Slides de Notas**

O exemplo a seguir exporta uma apresentação para PDF, colocando as notas do apresentador de cada slide abaixo do slide. Use uma apresentação contendo notas do apresentador para ver o resultado.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Acessibilidade e Padrões de Conformidade para PDF**

O Aspose.Slides permite usar um procedimento de conversão que está em conformidade com as [Diretrizes de Acessibilidade de Conteúdo Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Você pode exportar um documento PowerPoint para PDF usando qualquer um destes padrões de conformidade: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Este código Python demonstra uma operação de conversão de PowerPoint para PDF na qual múltiplos PDFs baseados em diferentes padrões de conformidade são obtidos:

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

{{% alert color="info" title="Note" %}}
O suporte do Aspose.Slides para operações de conversão de PDF permite converter PDF para os formatos de arquivo mais populares. Você pode fazer [PDF para HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF para imagem](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF para JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) e [PDF para PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) conversões. Outras operações de conversão de PDF para formatos especializados — [PDF para SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF para TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/) e [PDF para XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/) — também são suportadas.
{{% /alert %}}

> **Nota:** Ao exportar para PDF/UA, o Aspose.Slides trata gráficos complexos como SmartArt, gráficos e fórmulas como uma única figura. Elementos de caminho individuais não são preservados como conteúdo separado e podem ser marcados como artefatos; texto alternativo é fornecido apenas para a figura inteira.

## **Perguntas Frequentes**

**O Aspose.Slides for Python pode remover as informações da aplicação do PDF?**  
Não, o Aspose.Slides for Python inclui automaticamente as informações da API e o número da versão no PDF de saída. Essas informações não podem ser modificadas ou removidas.

**Como incluo apenas slides específicos na conversão para PDF?**  
Você pode especificar os índices dos slides que deseja converter passando um array de posições de slides para o método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**É possível proteger o PDF com senha durante a conversão?**  
Sim, você pode definir uma senha e definir permissões de acesso usando a classe [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) antes de salvar a apresentação como PDF.

**O Aspose.Slides oferece suporte à conversão de PDF para outros formatos?**  
Sim, o Aspose.Slides oferece suporte à conversão de PDFs para formatos como HTML, formatos de imagem (JPG, PNG), SVG, TIFF e XML.

**Como posso garantir que meu PDF esteja em conformidade com os padrões de acessibilidade?**  
Defina a propriedade [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) em [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) para padrões como `PDF_A1A`, `PDF_A1B` ou `PDF_UA` para garantir a conformidade com as diretrizes de acessibilidade.

**Posso incluir slides ocultos na saída PDF?**  
Sim, ao definir a propriedade [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) em [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) como `True`, slides ocultos serão incluídos no PDF.

**Como ajusto a qualidade e a resolução das imagens durante a conversão?**  
Use as propriedades [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) e [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) em [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) para controlar a qualidade e a resolução das imagens no PDF resultante.

**O Aspose.Slides lida com substituições de fontes automaticamente?**  
O Aspose.Slides detecta substituições de fontes durante a conversão, e você pode tratá‑las usando a propriedade `warning_callback` em `SaveOptions` (atualmente limitada).

## **Recursos Adicionais**

- [Documentação do Aspose.Slides para Python via .NET](/slides/pt/python-net/)
- [Referência da API do Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Conversores Online Gratuitos da Aspose](https://products.aspose.app/slides/conversion)