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
- anexo
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Converter PowerPoint PPT/PPTX para PDFs de alta qualidade e pesquisáveis em PHP usando Aspose.Slides, com exemplos de código rápidos e opções avançadas de conversão."
---
## **Visão geral**

Converter apresentações PowerPoint (PPT, PPTX, ODP etc.) para formato PDF em PHP oferece várias vantagens, incluindo compatibilidade entre diferentes dispositivos e preservação do layout e da formatação da sua apresentação. Este guia demonstra como converter apresentações em documentos PDF, usar várias opções para controlar a qualidade das imagens, incluir slides ocultos, proteger PDFs com senha, detectar substituições de fontes, selecionar slides específicos para conversão e aplicar padrões de conformidade aos documentos de saída.

## **Conversões de PowerPoint para PDF**

Usando Aspose.Slides, você pode converter apresentações nos seguintes formatos para PDF:

* **PPT**
* **PPTX**
* **ODP**

Para converter uma apresentação para PDF, passe o nome do arquivo como argumento para a classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) e então salve a apresentação como PDF usando o método [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save). A classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) expõe o método [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) que normalmente é usado para converter uma apresentação em PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java insere suas informações de API e número da versão nos documentos de saída. Por exemplo, ao converter uma apresentação para PDF, Aspose.Slides preenche o campo Application com "*Aspose.Slides*" e o campo PDF Producer com um valor no formato "*Aspose.Slides v XX.XX*". **Observação** que você não pode instruir o Aspose.Slides a alterar ou remover essas informações dos documentos de saída.
{{% /alert %}}

Aspose.Slides permite converter:

* Apresentações completas para PDF
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

O processo padrão de conversão de PowerPoint para PDF usa opções padrão. Nesse caso, o Aspose.Slides tenta converter a apresentação fornecida para PDF usando configurações ótimas nos níveis máximos de qualidade.

O exemplo a seguir carrega uma apresentação e salva todos os slides visíveis em PDF usando as configurações de exportação padrão.

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
Aspose oferece um [**Conversor de PowerPoint para PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) online gratuito que demonstra o processo de conversão de apresentação para PDF. Você pode executar um teste com esse conversor para uma implementação ao vivo do procedimento descrito aqui.
{{% /alert %}}

## **Converter PowerPoint para PDF com Opções**

Aspose.Slides fornece opções personalizadas — propriedades da classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) — que permitem personalizar o PDF resultante, bloquear o PDF com senha ou especificar como o processo de conversão deve prosseguir.

### **Converter PowerPoint para PDF com Opções Personalizadas**

Usando opções de conversão personalizadas, você pode definir sua configuração de qualidade preferida para imagens raster, especificar como arquivos metafile devem ser tratados, definir um nível de compressão para texto, configurar DPI para imagens e muito mais.

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

Se uma apresentação contém uma pasta de trabalho Excel incorporada, pode ser desejável que os destinatários do PDF acessem os dados da pasta de trabalho além de visualizar os slides. Chame [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) com `true` para preservar arquivos OLE incorporados como anexos no PDF resultante.

O valor padrão é `false`: a imagem de visualização ou ícone do objeto OLE é renderizada na página do PDF, mas seu arquivo incorporado não é incluído como anexo. Definir a opção como `true` inclui adicionalmente os dados do arquivo. A visualização permanece como uma representação visual; o anexo permite que os destinatários abram ou salvem o arquivo incorporado separadamente. O objeto OLE não se torna uma planilha Excel interativa na página do PDF.

O exemplo a seguir carrega uma apresentação que já contém uma pasta de trabalho Excel incorporada e a exporta para PDF com a pasta de trabalho anexada.

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

1. Abra o PDF exportado em um visualizador que suporte anexos de arquivos, como o Adobe Acrobat Reader.
2. Abra o painel **Attachments** do visualizador e localize a pasta de trabalho incorporada.
3. Salve o anexo e abra-o no Excel para inspecionar seus dados, ou abra-o diretamente se o visualizador permitir. A visualização na página do PDF é separada do anexo.

{{% alert color="info" title="Note" %}}
Os padrões PDF/A impõem restrições aos anexos: PDF/A-1 proíbe arquivos incorporados, PDF/A-2 permite apenas anexos PDF/A e PDF/A-3 permite outros tipos de arquivo, incluindo pastas de trabalho Excel. Estas são exigências dos padrões, não restrições específicas ao Aspose.Slides. Este exemplo usa a configuração padrão de conformidade PDF e não demonstra exportação PDF/A.
{{% /alert %}}

### **Converter PowerPoint para PDF com Slides Ocultos**

Se uma apresentação contém slides ocultos, você pode usar o método [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) da classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para incluir os slides ocultos como páginas no PDF resultante.

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

O exemplo a seguir exporta uma apresentação para um PDF que requer a senha `password` para ser aberto. As permissões de acesso permitem impressão, incluindo impressão de alta qualidade.

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

### **Detectar Substituições de Fontes**

Aspose.Slides fornece o método [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) na classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), permitindo detectar substituições de fontes durante o processo de conversão de apresentação para PDF.

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
Para mais informações sobre substituição de fontes, veja o artigo [Substituição de Fontes](/slides/pt/php-java/font-substitution/).
{{% /alert %}} 

## **Converter Slides Selecionados do PowerPoint para PDF**

O exemplo a seguir exporta os slides 1 e 3 de uma apresentação para PDF. Os números dos slides neste array são baseados em 1, e a apresentação de entrada deve conter ao menos três slides.

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

    // Remova o slide vazio com o qual a nova apresentação foi criada.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Converter PowerPoint para PDF na Visualização de Slides de Notas**

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

Aspose.Slides permite que você use um procedimento de conversão que esteja em conformidade com as [Diretrizes de Acessibilidade de Conteúdo Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Você pode exportar um documento PowerPoint para PDF usando qualquer um destes padrões de conformidade: **PDF/A1a**, **PDF/A1b** e **PDF/UA**.

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

{{% alert color="info" title="Note" %}}
Aspose.Slides suporta operações de conversão PDF, permitindo converter arquivos PDF para formatos de arquivo populares. Você pode realizar [PDF para HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF para imagem](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF para JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) e [PDF para PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) conversões. Outras operações de conversão PDF para formatos especializados — [PDF para SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF para TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), e [PDF para XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) — também são suportadas.
{{% /alert %}}

> **Observação:** ao exportar para PDF/UA, o Aspose.Slides trata gráficos complexos como SmartArt, gráficos e fórmulas como uma única figura. Elementos de caminho individuais não são preservados como conteúdo separado e podem ser marcados como artefatos; texto alternativo é fornecido apenas para a figura inteira.

## **Perguntas Frequentes**

**Posso converter vários arquivos PowerPoint para PDF em lote?**

Sim, o Aspose.Slides suporta conversão em lote de vários arquivos PPT ou PPTX para PDF. Você pode percorrer seus arquivos e aplicar o processo de conversão programaticamente.

**É possível proteger o PDF convertido com senha?**

Sim. Use a classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para definir uma senha e especificar permissões de acesso durante o processo de conversão.

**Como incluir slides ocultos no PDF?**

Chame [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) com `true` na classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para incluir slides ocultos no PDF resultante.

**O Aspose.Slides pode manter alta qualidade de imagem no PDF?**

Sim, você pode controlar a qualidade das imagens usando métodos como [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setJpegQuality) e [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setSufficientResolution) na classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para garantir imagens de alta qualidade no seu PDF.

**O Aspose.Slides suporta padrões de conformidade PDF/A?**

Sim, o Aspose.Slides permite exportar PDFs que estejam em conformidade com [vários padrões](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), incluindo PDF/A1a, PDF/A1b e PDF/UA, garantindo que seus documentos atendam a requisitos de acessibilidade e arquivamento.

## **Recursos Adicionais**

- [Documentação do Aspose.Slides para PHP via Java](/slides/pt/php-java/)
- [Referência de API do Aspose.Slides para PHP via Java](https://reference.aspose.com/slides/php-java/)
- [Conversores Online Gratuitos da Aspose](https://products.aspose.app/slides/conversion)