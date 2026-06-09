---
title: Importar apresentações de PDF ou HTML em C++
linktitle: Importar apresentação
type: docs
weight: 60
url: /pt/cpp/import-presentation/
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
- C++
- Aspose.Slides
description: "Importe PDFs e documentos HTML de forma fácil em apresentações PowerPoint e OpenDocument em C++ com Aspose.Slides, garantindo processamento de slides contínuo e de alto desempenho."
---
## **Introdução**

Usando [**Aspose.Slides for C++**](https://products.aspose.com/slides/pt/cpp/), você pode importar apresentações de arquivos em outros formatos. Aspose.Slides fornece a classe [SlideCollection](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.slide_collection) para permitir que você importe apresentações de PDF, documentos HTML, etc.

## **Importar PowerPoint de PDF**

Neste caso, você pode converter um PDF em uma apresentação PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Instancie um objeto da classe Presentation. 
2. Chame o método [AddFromPdf()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) e passe o arquivo PDF. 
3. Use o método [Save()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) para salvar o arquivo no formato PowerPoint.

Este código C++ demonstra a operação de PDF para PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Dica" color="primary" %}} 

Você pode querer experimentar o aplicativo web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/pt/import/pdf-to-powerpoint) porque ele é uma implementação ao vivo do processo descrito aqui. 

{{% /alert %}} 

## **Importar PowerPoint de HTML**

Neste caso, você pode converter um documento HTML em uma apresentação PowerPoint.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation/). 
2. Chame o método [AddFromHtml()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) e passe o arquivo HTML. 
3. Use o método [Save()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) para salvar o arquivo no formato PowerPoint.

Este código C++ demonstra a operação de HTML para PowerPoint:

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Nota" color="warning" %}} 

Você também pode usar o Aspose.Slides para converter HTML para outros formatos de arquivo populares: 

* [HTML to image](https://products.aspose.com/slides/pt/cpp/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/pt/cpp/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/pt/cpp/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/pt/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

**As tabelas são preservadas ao importar um PDF e sua detecção pode ser aprimorada?**

As tabelas podem ser detectadas durante a importação; [PdfImportOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.import/pdfimportoptions/) inclui um método [set_DetectTables](https://reference.aspose.com/slides/pt/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) que habilita o reconhecimento de tabelas. A eficácia depende da estrutura do PDF.