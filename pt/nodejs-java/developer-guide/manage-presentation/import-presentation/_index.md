---
title: Importar Apresentações de PDF ou HTML em JavaScript
linktitle: Importar Apresentação
type: docs
weight: 60
url: /pt/nodejs-java/import-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Importe documentos PDF e HTML em apresentações PowerPoint e OpenDocument com Aspose.Slides para Node.js, proporcionando processamento de slides contínuo e de alto desempenho."
---
## **Introdução**

Usando [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/pt/nodejs-java/), você pode importar apresentações de arquivos em outros formatos. Aspose.Slides fornece a classe [SlideCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/) para permitir que você importe apresentações de PDFs, documentos HTML, etc.

## **Importar PowerPoint de PDF**

Neste caso, você converte um PDF para uma apresentação PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/).
2. Chame o método [addFromPdf()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) e passe o arquivo PDF.
3. Use o método [save()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) para salvar o arquivo no formato PowerPoint.

Este código JavaScript demonstra a operação de PDF para PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert  title="Tip" color="primary" %}} 

Você pode querer conferir o aplicativo web gratuito **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/pt/import/pdf-to-powerpoint) porque ele é uma implementação ao vivo do processo descrito aqui. 

{{% /alert %}} 

## **Importar PowerPoint de HTML**

Neste caso, você converte um documento HTML para uma apresentação PowerPoint.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/).
2. Chame o método [addFromHtml()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) e passe o arquivo HTML.
3. Use o método [save()](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) para salvar o arquivo no formato PowerPoint.

Este código JavaScript demonstra a operação de HTML para PowerPoint:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var htmlStream = java.newInstanceSync("java.io.FileInputStream", "page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) {
            htmlStream.close();
        }
    }
    presentation.save("MyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Perguntas Frequentes**

**As tabelas são preservadas ao importar um PDF, e sua detecção pode ser aprimorada?**

As tabelas podem ser detectadas durante a importação; [PdfImportOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pdfimportoptions/) inclui um método [setDetectTables](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) que habilita o reconhecimento de tabelas. A eficácia depende da estrutura do PDF.