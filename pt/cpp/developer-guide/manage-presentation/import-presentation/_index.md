---
title: Importar Apresentações de PDF ou HTML em C++
linktitle: Importar Apresentação
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
description: "Importe documentos PDF e HTML para apresentações PowerPoint e OpenDocument em C++ com Aspose.Slides, garantindo processamento de slides rápido e sem esforço."
---
## **Introdução**

Usando [**Aspose.Slides for C++**](https://products.aspose.com/slides/pt/cpp/), você pode importar apresentações a partir de arquivos em outros formatos. Aspose.Slides fornece a classe [SlideCollection](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.slide_collection) que permite importar apresentações de PDF, documentos HTML, etc.

## **Importar PowerPoint a partir de PDF**

Neste caso, você converte um PDF em uma apresentação PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Instancie um objeto da classe Presentation.  
2. Chame o método [AddFromPdf()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) e passe o arquivo PDF.  
3. Use o método [Save()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) para salvar o arquivo no formato PowerPoint.

Este código C++ demonstra a operação de PDF para PowerPoint:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="info" %}} 

Você pode querer conferir o aplicativo web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/pt/import/pdf-to-powerpoint) porque ele é uma implementação ao vivo do processo descrito aqui. 

{{% /alert %}} 

## **Importar PowerPoint a partir de HTML**

Neste caso, você converte um documento HTML em uma apresentação PowerPoint.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation/) .  
2. Chame o método [AddFromHtml()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) e passe o arquivo HTML.  
3. Use o método [Save()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) para salvar o arquivo no formato PowerPoint.

Este código C++ demonstra a operação de HTML para PowerPoint:

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

Você também pode usar o Aspose.Slides para converter HTML para outros formatos populares de arquivos: 

* [HTML para imagem](https://products.aspose.com/slides/pt/cpp/conversion/html-to-image/)
* [HTML para JPG](https://products.aspose.com/slides/pt/cpp/conversion/html-to-jpg/)
* [HTML para XML](https://products.aspose.com/slides/pt/cpp/conversion/html-to-xml/)
* [HTML para TIFF](https://products.aspose.com/slides/pt/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

### As tabelas são preservadas ao importar um PDF, e sua detecção pode ser aprimorada?

As tabelas podem ser detectadas durante a importação; [PdfImportOptions](https://reference.aspose.com/slides/pt/cpp/aspose.slides.import/pdfimportoptions/) inclui o método [set_DetectTables](https://reference.aspose.com/slides/pt/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) que habilita o reconhecimento de tabelas. A eficácia depende da estrutura do PDF.