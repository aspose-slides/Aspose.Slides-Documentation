---
title: Importar apresentações de PDF ou HTML em Java
linktitle: Importar apresentação
type: docs
weight: 60
url: /pt/java/import-presentation/
keywords:
- importação de apresentação
- importação de slide
- importação de PDF
- importação de HTML
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
- Java
- Aspose.Slides
description: "Importe documentos PDF e HTML para apresentações PowerPoint e OpenDocument em Java com Aspose.Slides de forma simples, com processamento de slides de alto desempenho."
---
## **Introdução**

Usando o Aspose.Slides, você pode importar apresentações a partir de arquivos em outros formatos. O Aspose.Slides fornece a classe [SlideCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slidecollection/) que permite importar apresentações de documentos PDF e HTML.

## **Importar PowerPoint a partir de PDF**

Neste caso, você converte um PDF para uma apresentação PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/). 
2. Chame o método [addFromPdf()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) e passe o arquivo PDF. 
3. Use o método [save()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation#save-java.lang.String-int-) para salvar o arquivo no formato PowerPoint.

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
Você pode querer experimentar o aplicativo web **Aspose free** [PDF para PowerPoint](https://products.aspose.app/slides/pt/import/pdf-to-powerpoint) porque é uma implementação ao vivo do processo descrito aqui. 
{{% /alert %}} 

## **Importar PowerPoint a partir de HTML**

Neste caso, você converte um documento HTML para uma apresentação PowerPoint.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/). 
2. Chame o método [addFromHtml()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) e passe o arquivo HTML. 
3. Use o método [save()](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation#save-java.lang.String-int-) para salvar o arquivo no formato PowerPoint.

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

## **Perguntas Frequentes**

**As tabelas são preservadas ao importar um PDF e a detecção pode ser aprimorada?**

As tabelas podem ser detectadas durante a importação; [PdfImportOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pdfimportoptions/) inclui um método [setDetectTables](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) que habilita o reconhecimento de tabelas. A eficácia depende da estrutura do PDF.

{{% alert title="Note" color="warning" %}} 
Você também pode usar o Aspose.Slides para converter HTML para outros formatos de arquivo populares: 

* [HTML para imagem](https://products.aspose.com/slides/pt/java/conversion/html-to-image/)
* [HTML para JPG](https://products.aspose.com/slides/pt/java/conversion/html-to-jpg/)
* [HTML para XML](https://products.aspose.com/slides/pt/java/conversion/html-to-xml/)
* [HTML para TIFF](https://products.aspose.com/slides/pt/java/conversion/html-to-tiff/)

{{% /alert %}}