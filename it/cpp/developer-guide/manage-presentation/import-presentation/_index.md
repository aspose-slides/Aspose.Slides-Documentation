---
title: Importa presentazioni da PDF o HTML in C++
linktitle: Importa presentazione
type: docs
weight: 60
url: /it/cpp/import-presentation/
keywords:
- importazione presentazione
- importazione diapositiva
- importazione PDF
- importazione HTML
- PDF a presentazione
- PDF a PPT
- PDF a PPTX
- PDF a ODP
- HTML a presentazione
- HTML a PPT
- HTML a PPTX
- HTML a ODP
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Importa facilmente documenti PDF e HTML in presentazioni PowerPoint e OpenDocument in C++ con Aspose.Slides per una gestione delle diapositive fluida e ad alte prestazioni."
---
## **Introduzione**

Utilizzando [**Aspose.Slides for C++**](https://products.aspose.com/slides/it/cpp/), è possibile importare presentazioni da file in altri formati. Aspose.Slides fornisce la classe [SlideCollection](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.slide_collection) per consentire l'importazione di presentazioni da PDF, documenti HTML, ecc.

## **Importa PowerPoint da PDF**

In questo caso, è possibile convertire un PDF in una presentazione PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Istanziare un oggetto della classe Presentation. 
2. Chiamare il metodo [AddFromPdf()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) e passare il file PDF. 
3. Utilizzare il metodo [Save()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) per salvare il file nel formato PowerPoint.

Questo codice C++ dimostra l'operazione di conversione da PDF a PowerPoint:

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

{{% alert  title="Suggerimento" color="info" %}} 

Potresti voler provare l'app web gratuita Aspose [PDF to PowerPoint](https://products.aspose.app/slides/it/import/pdf-to-powerpoint) perché è un'implementazione live del processo descritto qui. 

{{% /alert %}} 

## **Importa PowerPoint da HTML**

In questo caso, è possibile convertire un documento HTML in una presentazione PowerPoint.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation/) . 
2. Chiamare il metodo [AddFromHtml()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) e passare il file HTML. 
3. Utilizzare il metodo [Save()](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) per salvare il file nel formato PowerPoint.

Questo codice C++ dimostra l'operazione di conversione da HTML a PowerPoint:

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

{{% alert title="Nota" color="warning" %}} 

È inoltre possibile utilizzare Aspose.Slides per convertire HTML in altri formati di file popolari: 

* [HTML in immagine](https://products.aspose.com/slides/it/cpp/conversion/html-to-image/)
* [HTML in JPG](https://products.aspose.com/slides/it/cpp/conversion/html-to-jpg/)
* [HTML in XML](https://products.aspose.com/slides/it/cpp/conversion/html-to-xml/)
* [HTML in TIFF](https://products.aspose.com/slides/it/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

### Le tabelle vengono preservate durante l'importazione di un PDF e la loro rilevazione può essere migliorata?

Le tabelle possono essere rilevate durante l'importazione; [PdfImportOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.import/pdfimportoptions/) include un metodo [set_DetectTables](https://reference.aspose.com/slides/it/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) che abilita il riconoscimento delle tabelle. L'efficacia dipende dalla struttura del PDF.