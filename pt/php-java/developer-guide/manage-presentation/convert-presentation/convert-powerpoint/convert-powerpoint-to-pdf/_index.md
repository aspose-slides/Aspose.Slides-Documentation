---
title: Converter PPT e PPTX para PDF em PHP [Recursos avançados incluídos]
linktitle: PowerPoint para PDF
type: docs
weight: 40
url: /pt/php-java/convert-powerpoint-to-pdf/
keywords:
- converter PowerPoint
- converter apresentação
- PowerPoint para PDF
- apresentação para PDF
- PPT para PDF
- converter PPT para PDF
- PPTX para PDF
- converter PPTX para PDF
- salvar PowerPoint como PDF
- salvar PPT como PDF
- salvar PPTX como PDF
- exportar PPT para PDF
- exportar PPTX para PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Converta PowerPoint PPT/PPTX para PDFs de alta qualidade e pesquisáveis em PHP usando Aspose.Slides, com exemplos de código rápidos e opções avançadas de conversão."
---
## **Visão geral**

Converter apresentações do PowerPoint (PPT, PPTX, ODP etc.) para PDF em PHP oferece várias vantagens, incluindo compatibilidade em diferentes dispositivos e preservação do layout e formatação da sua apresentação. Este guia demonstra como converter apresentações para documentos PDF, usar várias opções para controlar a qualidade da imagem, incluir slides ocultos, proteger PDFs com senha, detectar substituições de fontes, selecionar slides específicos para conversão e aplicar padrões de conformidade aos documentos de saída.

## **Conversões de PowerPoint para PDF**

Usando Aspose.Slides, você pode converter apresentações nos seguintes formatos para PDF:

* **PPT**
* **PPTX**
* **ODP**

Para converter uma apresentação para PDF, passe o nome do arquivo como argumento para a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) e depois salve a apresentação como PDF usando um método `save`. A classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation) expõe o método `save` que normalmente é usado para converter uma apresentação para PDF.

{{%  alert title="NOTA"  color="warning"   %}} 

Aspose.Slides for PHP via Java insere as informações de sua API e número da versão nos documentos de saída. Por exemplo, ao converter uma apresentação para PDF, o Aspose.Slides preenche o campo Application com "*Aspose.Slides*" e o campo PDF Producer com um valor no formato "*Aspose.Slides v XX.XX*". **Observação** que você não pode instruir o Aspose.Slides a mudar ou remover essas informações dos documentos de saída.

{{% /alert %}}

Aspose.Slides permite converter:

* Apresentações inteiras para PDF
* Slides específicos de uma apresentação para PDF

Aspose.Slides exporta apresentações para PDF, garantindo que os PDFs resultantes correspondam de perto às apresentações originais. Elementos e atributos são renderizados com precisão na conversão, incluindo:

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

Este código mostra como converter uma apresentação (PPT, PPTX, ODP etc.) para PDF:

```php
# Instanciar a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Salvar a apresentação como PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose oferece um conversor gratuito online de **PowerPoint para PDF**[https://products.aspose.app/slides/pt/conversion/ppt-to-pdf](https://products.aspose.app/slides/pt/conversion/ppt-to-pdf) que demonstra o processo de conversão de apresentação para PDF. Você pode realizar um teste com este conversor para uma implementação ao vivo do procedimento descrito aqui.

{{% /alert %}}

## **Converter PowerPoint para PDF com Opções**

Aspose.Slides fornece opções personalizadas — propriedades da classe [PdfOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PdfOptions) — que permitem personalizar o PDF resultante, bloquear o PDF com senha ou especificar como o processo de conversão deve prosseguir.

### **Converter PowerPoint para PDF com Opções Personalizadas**

Usando opções de conversão personalizadas, você pode definir sua configuração preferida de qualidade para imagens raster, especificar como arquivos metafile devem ser tratados, definir um nível de compactação para texto, configurar DPI para imagens e muito mais.

O exemplo de código abaixo demonstra como converter uma apresentação do PowerPoint para PDF com várias opções personalizadas.

```php
# Instanciar a classe PdfOptions.
$pdfOptions = new PdfOptions();

# Definir a qualidade das imagens JPG.
$pdfOptions->setJpegQuality(90);

# Definir DPI para imagens.
$pdfOptions->setSufficientResolution(300);

# Definir o comportamento para metafiles.
$pdfOptions->setSaveMetafilesAsPng(true);

# Definir o nível de compressão de texto para conteúdo textual.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# Definir o modo de conformidade PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# Instanciar a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Salvar a apresentação como um documento PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Converter PowerPoint para PDF com Slides Ocultos**

Se uma apresentação contém slides ocultos, você pode usar o método [setShowHiddenSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) da classe [PdfOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/PdfOptions) para incluir os slides ocultos como páginas no PDF resultante.

Este código mostra como converter uma apresentação do PowerPoint para PDF com slides ocultos incluídos:

```php
# Instanciar a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Instanciar a classe PdfOptions.
    $pdfOptions = new PdfOptions();

    # Adicionar slides ocultos.
    $pdfOptions->setShowHiddenSlides(true);

    # Salvar a apresentação como PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Converter PowerPoint para PDF Protegido por Senha**

Este código demonstra como converter uma apresentação do PowerPoint em um PDF protegido por senha usando os parâmetros de proteção da classe [PdfOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pdfoptions/) :

```php
# Instanciar a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Instanciar a classe PdfOptions.
    $pdfOptions = new PdfOptions();

    # Definir uma senha PDF e permissões de acesso.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Salvar a apresentação como PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Detectar Substituições de Fonte**

Aspose.Slides fornece o método [setWarningCallback](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveoptions/#setWarningCallback) na classe [PdfOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pdfoptions/) , permitindo detectar substituições de fontes durante o processo de conversão de apresentação para PDF.

Este código mostra como detectar substituições de fontes:

```php
// Definir o callback de aviso nas opções de PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Instanciar a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
$presentation = new Presentation("sample.pptx");
try {
    // Salvar a apresentação como PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 

Para mais informações sobre substituição de fontes, consulte o artigo [Font Substitution](/slides/pt/php-java/font-substitution/).

{{% /alert %}} 

## **Converter Slides Selecionados de PowerPoint para PDF**

Este código demonstra como converter apenas slides específicos de uma apresentação do PowerPoint para PDF:

```php
# Instanciar a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Definir array de números de slides.
    $slides = array(1, 3);

    # Salvar a apresentação como PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Converter PowerPoint para PDF com Tamanho de Slide Personalizado**

Este código demonstra como converter uma apresentação do PowerPoint para PDF com um tamanho de slide especificado:

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# Instanciar a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");

# Criar uma nova apresentação com um tamanho de slide ajustado.
$resizedPresentation = new Presentation();

try {
    # Definir o tamanho de slide personalizado.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Clonar o primeiro slide da apresentação original.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Salvar a apresentação redimensionada em PDF com notas.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Converter PowerPoint para PDF na Visualização de Slides com Notas**

Este código demonstra como converter uma apresentação do PowerPoint para um PDF que inclui notas:

```php
# Instanciar a classe Presentation que representa um arquivo PowerPoint ou OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Configurar as opções de PDF com layout de notas.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Salvar a apresentação em um PDF com notas.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Acessibilidade e Padrões de Conformidade para PDF**

Aspose.Slides permite usar um procedimento de conversão que está em conformidade com as Diretrizes de Acessibilidade de Conteúdo da Web (**WCAG**)[https://www.w3.org/TR/WCAG-TECHS/pdf.html](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Você pode exportar um documento PowerPoint para PDF usando quaisquer destes padrões de conformidade: **PDF/A1a**, **PDF/A1b**, e **PDF/UA**.

Este código demonstra um processo de conversão de PowerPoint para PDF que produz vários PDFs com base em diferentes padrões de conformidade:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Nota" color="warning" %}} 

Aspose.Slides suporta operações de conversão de PDF, permitindo converter arquivos PDF para formatos populares. Você pode realizar conversões de [PDF para HTML](https://products.aspose.com/slides/pt/php-java/conversion/pdf-to-html/), [PDF para image](https://products.aspose.com/slides/pt/php-java/conversion/pdf-to-image/), [PDF para JPG](https://products.aspose.com/slides/pt/php-java/conversion/pdf-to-jpg/), e [PDF para PNG](https://products.aspose.com/slides/pt/php-java/conversion/pdf-to-png/) . Outras operações de conversão de PDF para formatos especializados — [PDF para SVG](https://products.aspose.com/slides/pt/php-java/conversion/pdf-to-svg/), [PDF para TIFF](https://products.aspose.com/slides/pt/php-java/conversion/pdf-to-tiff/), e [PDF para XML](https://products.aspose.com/slides/pt/php-java/conversion/pdf-to-xml/) — também são suportadas.

{{% /alert %}}

> **Observação:** ao exportar para PDF/UA, o Aspose.Slides trata gráficos complexos como SmartArt, gráficos e fórmulas como uma única figura. Elementos de caminho individuais não são preservados como conteúdo separado e podem ser marcados como artefatos; texto alternativo é fornecido apenas para a figura inteira.

## **FAQ**

**Posso converter vários arquivos PowerPoint para PDF em lote?**

Sim, o Aspose.Slides suporta conversão em lote de vários arquivos PPT ou PPTX para PDF. Você pode iterar pelos seus arquivos e aplicar o processo de conversão programaticamente.

**É possível proteger o PDF convertido com senha?**

Absolutamente. Use a classe [PdfOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pdfoptions/) para definir uma senha e determinar permissões de acesso durante o processo de conversão.

**Como incluir slides ocultos no PDF?**

Use o método `setShowHiddenSlides` na classe [PdfOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pdfoptions/) para incluir slides ocultos no PDF resultante.

**O Aspose.Slides pode manter alta qualidade de imagem no PDF?**

Sim, você pode controlar a qualidade da imagem usando métodos como `setJpegQuality` e `setSufficientResolution` na classe [PdfOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pdfoptions/) para garantir imagens de alta qualidade no seu PDF.

**O Aspose.Slides suporta padrões de conformidade PDF/A?**

Sim, o Aspose.Slides permite exportar PDFs que cumprem vários padrões, incluindo PDF/A1a, PDF/A1b e PDF/UA, garantindo que seus documentos atendam aos requisitos de acessibilidade e arquivamento.

## **Recursos Adicionais**

- [Documentação do Aspose.Slides para PHP via Java](/slides/pt/php-java/)
- [Referência da API do Aspose.Slides para PHP via Java](https://reference.aspose.com/slides/pt/php-java/)
- [Conversores Online Gratuitos da Aspose](https://products.aspose.app/slides/pt/conversion)