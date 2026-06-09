---
title: Importar apresentações de PDF ou HTML em PHP
linktitle: Importar apresentação
type: docs
weight: 60
url: /pt/php-java/import-presentation/
keywords:
- importar apresentação
- importar slide
- importar PDF
- importar HTML
- PDF para apresentação
- PDF para PPT
- PDF para PPTX
- PDF para ODP
- HTML para apresentação
- HTML para PPT
- HTML para PPTX
- HTML para ODP
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Importe documentos PDF e HTML em apresentações PowerPoint e OpenDocument em PHP com Aspose.Slides para um processamento de slides contínuo e de alto desempenho."
---
## **Introdução**

Usando [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/pt/php-java/), você pode importar apresentações de arquivos em outros formatos. Aspose.Slides fornece a classe [SlideCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/) para permitir a importação de apresentações a partir de PDFs, documentos HTML, etc.

## **Importar PowerPoint a partir de PDF**

Neste caso, você converte um PDF em uma apresentação PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/).
2. Chame o método [addFromPdf()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) e passe o arquivo PDF.
3. Use o método [save()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation#save-java.lang.String-int-) para salvar o arquivo no formato PowerPoint.

Este código PHP demonstra a operação de PDF para PowerPoint:

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->addFromPdf("InputPDF.pdf");
    $pres->save("OutputPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Dica" color="primary" %}} 
Você pode querer conferir o aplicativo web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/pt/import/pdf-to-powerpoint) porque ele é uma implementação ao vivo do processo descrito aqui. 
{{% /alert %}} 

## **Importar PowerPoint a partir de HTML**

Neste caso, você converte um documento HTML em uma apresentação PowerPoint.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/).
2. Chame o método [addFromHtml()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) e passe o arquivo HTML.
3. Use o método [save()](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation#save-java.lang.String-int-) para salvar o arquivo no formato PowerPoint.

Este código PHP demonstra a operação de HTML para PowerPoint:

```php
  $presentation = new Presentation();
  try {
    $htmlStream = new Java("java.io.FileInputStream", "page.html");
    try {
      $presentation->getSlides()->addFromHtml($htmlStream);
    } finally {
      if (!java_is_null($htmlStream)) {
        $htmlStream->close();
      }
    }
    $presentation->save("MyPresentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Perguntas Frequentes**

**As tabelas são preservadas ao importar um PDF e a detecção pode ser aprimorada?**

As tabelas podem ser detectadas durante a importação; [PdfImportOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pdfimportoptions/) inclui um método [setDetectTables](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pdfimportoptions/#setDetectTables) que habilita o reconhecimento de tabelas. A eficácia depende da estrutura do PDF.

{{% alert title="Observação" color="warning" %}} 
Você também pode usar Aspose.Slides para converter HTML em outros formatos de arquivo populares: 

* [HTML para imagem](https://products.aspose.com/slides/pt/php-java/conversion/html-to-image/)
* [HTML para JPG](https://products.aspose.com/slides/pt/php-java/conversion/html-to-jpg/)
* [HTML para XML](https://products.aspose.com/slides/pt/php-java/conversion/html-to-xml/)
* [HTML para TIFF](https://products.aspose.com/slides/pt/php-java/conversion/html-to-tiff/)
{{% /alert %}}