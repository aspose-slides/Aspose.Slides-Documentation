---
title: Converter PPT e PPTX para PDF em PHP [Recursos Avançados Incluídos]
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
- anexo
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Converta PowerPoint PPT/PPTX em PDFs de alta qualidade e pesquisáveis em PHP usando Aspose.Slides, com exemplos de código rápidos e opções avançadas de conversão."
---
## **Visão geral**

Converter apresentações do PowerPoint (PPT, PPTX, ODP, etc.) para o formato PDF em PHP oferece diversas vantagens, incluindo compatibilidade entre diferentes dispositivos e preservação do layout e da formatação da sua apresentação. Este guia demonstra como converter apresentações para documentos PDF, usar várias opções para controlar a qualidade de imagem, incluir slides ocultos, proteger PDFs com senha, detectar substituições de fontes, selecionar slides específicos para conversão e aplicar padrões de conformidade aos documentos de saída.

## **Conversões de PowerPoint para PDF**

Usando Aspose.Slides, você pode converter apresentações nos seguintes formatos para PDF:

* **PPT**
* **PPTX**
* **ODP**

Para converter uma apresentação para PDF, passe o nome do arquivo como argumento para a classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) e, em seguida, salve a apresentação como PDF usando o método [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). A classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) expõe o método [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) que normalmente é usado para converter uma apresentação para PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java insere suas informações de API e número da versão nos documentos de saída. Por exemplo, ao converter uma apresentação para PDF, Aspose.Slides preenche o campo Application com "*Aspose.Slides*" e o campo PDF Producer com um valor no formato "*Aspose.Slides v XX.XX*". **Note** que você não pode instruir o Aspose.Slides a alterar ou remover essas informações dos documentos de saída.
{{% /alert %}}

Aspose.Slides permite que você converta:

* Apresentações inteiras para PDF
* Slides específicos de uma apresentação para PDF

Aspose.Slides exporta apresentações para PDF, garantindo que os PDFs resultantes correspondam estreitamente às apresentações originais. Elementos e atributos são renderizados com precisão na conversão, incluindo:

* Imagens
* Caixas de texto e formas
* Formatação de texto
* Formatação de parágrafo
* Hiperlinks
* Cabeçalhos e rodapés
* Marcadores
* Tabelas

## **Converter PowerPoint para PDF**

O processo padrão de conversão de PowerPoint para PDF usa opções padrão. Nesse caso, Aspose.Slides tenta converter a apresentação fornecida para PDF usando configurações ideais nos níveis máximos de qualidade.

O exemplo a seguir carrega uma apresentação e salva todos os slides visíveis para PDF usando as configurações de exportação padrão.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose oferece um [**conversor de PowerPoint para PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) online gratuito que demonstra o processo de conversão de apresentação para PDF. Você pode executar um teste com este conversor para uma implementação ao vivo do procedimento descrito aqui.
{{% /alert %}}

## **Converter PowerPoint para PDF com Opções**

Aspose.Slides fornece opções personalizadas — propriedades na classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) — que permitem personalizar o PDF resultante, bloquear o PDF com senha ou especificar como o processo de conversão deve prosseguir.

### **Converter PowerPoint para PDF com Opções Personalizadas**

Usando opções de conversão personalizadas, você pode definir sua configuração preferida de qualidade para imagens raster, especificar como metafiles devem ser tratados, definir um nível de compressão para texto, configurar DPI para imagens e muito mais.

O exemplo a seguir exporta uma apresentação para PDF 1.5 com qualidade JPEG definida em 90, resolução de imagem definida em 300 DPI, metafiles salvos como PNG e compressão Flate de texto.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Preservar Arquivos OLE Incorporados como Anexos PDF**

Se uma apresentação contém uma pasta de trabalho do Excel incorporada, você pode desejar que os destinatários do PDF acessem os dados da pasta de trabalho além de visualizar os slides. Chame [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) com `true` para preservar arquivos OLE incorporados como anexos no PDF resultante.

O valor padrão é `false`: a imagem de visualização ou ícone do objeto OLE é renderizado na página PDF, mas seu arquivo incorporado não é incluído como anexo. Definir a opção como `true` inclui adicionalmente os dados do arquivo. A pré‑visualização permanece uma representação visual; o anexo permite que os destinatários abram ou salvem o arquivo incorporado separadamente. O objeto OLE não se torna uma planilha Excel interativa na página PDF.

O exemplo a seguir carrega uma apresentação que já contém uma pasta de trabalho do Excel incorporada e a exporta para PDF com a pasta de trabalho anexada.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Para verificar o resultado:

1. Abra o PDF exportado em um visualizador que suporte anexos de arquivo, como o Adobe Acrobat Reader.
2. Abra o painel **Attachments** do visualizador e localize a pasta de trabalho incorporada.
3. Salve o anexo e abra-o no Excel para inspecionar os dados, ou abra-o diretamente se o visualizador permitir. A pré‑visualização na página PDF é separada do anexo.

{{% alert color="info" title="Note" %}}
Os padrões PDF/A impõem restrições sobre anexos: PDF/A‑1 proíbe arquivos incorporados, PDF/A‑2 permite apenas anexos PDF/A e PDF/A‑3 permite outros tipos de arquivo, incluindo pastas de trabalho do Excel. Estas são exigências dos padrões, não restrições específicas do Aspose.Slides. Este exemplo usa a configuração padrão de conformidade PDF e não demonstra exportação PDF/A.
{{% /alert %}}

### **Converter PowerPoint para PDF com Slides Ocultos**

Se uma apresentação contém slides ocultos, você pode usar o método [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) da classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para incluir os slides ocultos como páginas no PDF resultante.

O exemplo a seguir exporta uma apresentação para PDF, incluindo quaisquer slides ocultos.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Converter PowerPoint para um PDF Protegido por Senha**

O exemplo a seguir exporta uma apresentação para um PDF que requer a senha `password` para ser aberto. As permissões de acesso permitem impressão, inclusive impressão de alta qualidade.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Detectar Substituições de Fonte**

Aspose.Slides fornece o método [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) na classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), permitindo detectar substituições de fontes durante o processo de conversão de apresentação para PDF.

O exemplo a seguir exporta uma apresentação para PDF e imprime avisos de substituição de fontes no console. Um aviso é impresso somente quando uma fonte indisponível é substituída durante a exportação.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Para mais informações sobre substituição de fontes, consulte o artigo [Substituição de Fonte](/slides/pt/php-java/font-substitution/).
{{% /alert %}} 

### **Manipular Fontes sem um Tipo de Letra Negrito Dedicado**

Uma apresentação pode aplicar formatação negrito ao texto mesmo quando sua fonte não possui um tipo de letra negrito dedicado. O texto ainda pode aparecer negrito por meio de negrito sintético, que engrossa artificialmente os glifos regulares. Quando esse texto parece muito pesado ou difere da aparência pretendida no PDF, tente chamar [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) com `true`. Essa opção renderiza o texto afetado como bitmap durante a exportação para PDF e pode melhorar sua aparência para certas fontes. Seu valor padrão é `false`.

A apresentação de exemplo contém duas caixas de texto: uma com texto normal e outra com formatação negrito aplicada à mesma fonte, que não tem tipo de letra negrito dedicado. O exemplo a seguir carrega a apresentação, habilita a rasterização de estilos de fonte não suportados e a exporta para PDF:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

A seguir, pré‑visualizações mostram a saída desativada e a saída ativada. Neste exemplo, o texto negrito tem traços mais pesados com a opção desativada. Com a opção ativada, seus traços são mais leves; o texto normal permanece inalterado. Compare os resultados antes de escolher a configuração para sua apresentação.

| Opção desativada (`false`, o padrão) | Opção ativada (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Neste exemplo, habilitar a opção transforma apenas o texto negrito em bitmap: ele não pode ser selecionado, copiado ou pesquisado como texto sem OCR, e suas bordas aparecem mais suaves em zoom de 800 %. O texto normal permanece pesquisável. Com a opção desativada, ambas as cadeias permanecem como texto.

Esta opção rasteriza texto formatado como negrito quando sua fonte não tem um tipo de letra negrito dedicado. A [Substituição de Fonte](/slides/pt/php-java/font-substitution/) em vez disso seleciona outra fonte quando a original está indisponível.

## **Converter Slides Selecionados de PowerPoint para PDF**

O exemplo a seguir exporta os slides 1 e 3 de uma apresentação para PDF. Os números de slide neste array são baseados em 1, e a apresentação de entrada deve conter ao menos três slides.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Converter PowerPoint para PDF com Tamanho de Slide Personalizado**

O exemplo a seguir copia o primeiro slide de uma apresentação para uma nova apresentação com tamanho de slide de 612 × 792 pontos (8,5 × 11 polegadas). Ele escala o conteúdo do slide para caber e exporta o slide único para PDF.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // Remova o slide vazio que a nova apresentação foi criada com.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Converter PowerPoint para PDF em Visualização de Slides com Notas**

O exemplo a seguir exporta uma apresentação para PDF, colocando as notas do apresentador de cada slide abaixo do slide. Use uma apresentação que contenha notas do apresentador para ver o resultado.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Acessibilidade e Padrões de Conformidade para PDF**

Aspose.Slides permite que você use um procedimento de conversão que esteja em conformidade com as [Diretrizes de Acessibilidade de Conteúdo Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Você pode exportar um documento PowerPoint para PDF usando quaisquer destes padrões de conformidade: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

Este código demonstra um processo de conversão de PowerPoint para PDF que produz múltiplos PDFs com base em diferentes padrões de conformidade:

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

{{% alert color="info" title="Note" %}}
Aspose.Slides suporta operações de conversão de PDF, permitindo que você converta arquivos PDF para formatos de arquivo populares. Você pode executar [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), e [PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) conversões. Outras operações de conversão de PDF para formatos especializados — [PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), e [PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — também são suportadas.
{{% /alert %}}

> **Nota:** Ao exportar para PDF/UA, Aspose.Slides trata gráficos complexos como SmartArt, gráficos e fórmulas como uma única figura. Os elementos de caminho individuais não são preservados como conteúdo separado e podem ser marcados como artefatos; o texto alternativo é fornecido apenas para a figura inteira.

## **Perguntas Frequentes**

**Posso converter vários arquivos PowerPoint para PDF em lote?**

Sim, Aspose.Slides suporta conversão em lote de vários arquivos PPT ou PPTX para PDF. Você pode iterar pelos seus arquivos e aplicar o processo de conversão programaticamente.

**É possível proteger o PDF convertido com senha?**

Sim. Use a classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para definir uma senha e definir permissões de acesso durante o processo de conversão.

**Como incluo slides ocultos no PDF?**

Chame [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) com `true` na classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para incluir slides ocultos no PDF resultante.

**Aspose.Slides pode manter alta qualidade de imagem no PDF?**

Sim, você pode controlar a qualidade da imagem usando métodos como [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) e [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) na classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para garantir imagens de alta qualidade no seu PDF.

**Aspose.Slides suporta padrões de conformidade PDF/A?**

Sim, Aspose.Slides permite que você exporte PDFs que estejam em conformidade com [vários padrões](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), incluindo PDF/A1a, PDF/A1b e PDF/UA, garantindo que seus documentos atendam aos requisitos de acessibilidade e arquivamento.

## **Recursos Adicionais**

- [Documentação do Aspose.Slides para PHP via Java](/slides/pt/php-java/)
- [Referência da API do Aspose.Slides para PHP via Java](https://reference.aspose.com/slides/php-java/)
- [Conversores Online Gratuitos da Aspose](https://products.aspose.app/slides/conversion)