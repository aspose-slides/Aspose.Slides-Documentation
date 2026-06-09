---
title: Importar apresentações de PDF ou HTML no Android
linktitle: Importar apresentação
type: docs
weight: 60
url: /pt/androidjava/import-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Importe documentos PDF e HTML para apresentações PowerPoint e OpenDocument em Java com Aspose.Slides para Android, proporcionando processamento de slides contínuo e de alto desempenho."
---
## **Introdução**

Usando [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/pt/androidjava/), você pode importar apresentações a partir de arquivos em outros formatos. O Aspose.Slides fornece a classe [SlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slidecollection/) para permitir que você importe apresentações de PDFs, documentos HTML, etc.

## **Importar PowerPoint de PDF**

Neste caso, você converte um PDF em uma apresentação PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/).
2. Chame o método [addFromPdf()](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) e passe o arquivo PDF.
3. Use o método [save()](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) para salvar o arquivo no formato PowerPoint.

Este código Java demonstra a operação de PDF para PowerPoint:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="primary" %}} 
Você pode querer conferir o aplicativo web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/pt/import/pdf-to-powerpoint) porque ele é uma implementação ao vivo do processo descrito aqui. 
{{% /alert %}} 

## **Importar PowerPoint de HTML**

Neste caso, você converte um documento HTML em uma apresentação PowerPoint.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/) .
2. Chame o método [addFromHtml()](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) e passe o arquivo PDF.
3. Use o método [save()](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) para salvar o arquivo no formato PowerPoint.

Este código Java demonstra a operação de HTML para PowerPoint: 

```java
Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**As tabelas são preservadas ao importar um PDF e a detecção pode ser aprimorada?**

As tabelas podem ser detectadas durante a importação; [PdfImportOptions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pdfimportoptions/) inclui um método [setDetectTables](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) que habilita o reconhecimento de tabelas. A eficácia depende da estrutura do PDF.