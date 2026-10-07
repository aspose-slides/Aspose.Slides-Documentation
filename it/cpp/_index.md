---
title: Aspose.Slides per C++
second_title: Aspose.Slides per C++
type: docs
weight: 30
url: /it/cpp/
keywords:
- documentazione
- elaborazione di presentazioni
- conversione di presentazioni
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Inizia qui: installa Aspose.Slides per C++, crea una prima presentazione e trova le guide per le attività comuni, il riferimento API e il supporto."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ è una libreria C++ nativa per creare, leggere, modificare e convertire presentazioni PowerPoint e OpenDocument, senza Microsoft PowerPoint o automazione di Office.

Carica e salva file PPT, PPTX, PPS, POT e ODP, incluse le varianti con macro e i modelli, ed esporta in PDF, XPS, HTML, SVG, TIFF, Markdown e immagini.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Inizia</b></p>
<hr>
<p>INIZIO</p>
<ul>
<li><a href="/slides/it/cpp/installation/">Installazione</a></li>
<li><a href="/slides/it/cpp/create-presentation/">Crea la tua prima presentazione</a></li>
<li><a href="/slides/it/cpp/getting-started/">Guida introduttiva</a></li>
</ul>
<p>VALUTAZIONE</p>
<ul>
<li><a href="/slides/it/cpp/supported-file-formats/">Formati di file supportati</a></li>
<li><a href="/slides/it/cpp/evaluate-aspose-slides/">Limitazioni della versione di prova</a></li>
<li><a href="/slides/it/cpp/licensing/">Licenza</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crea con Slides</b></p>
<hr>
<p>ATTIVITÀ COMUNI</p>
<ul>
<li><a href="/slides/it/cpp/open-presentation/">Apri una presentazione</a></li>
<li><a href="/slides/it/cpp/save-presentation/">Salva una presentazione</a></li>
<li><a href="/slides/it/cpp/convert-powerpoint-to-pdf/">Converti in PDF</a></li>
<li><a href="/slides/it/cpp/convert-slide/">Renderizza diapositive come immagini</a></li>
<li><a href="/slides/it/cpp/manage-text/">Modifica testo e forme</a></li>
</ul>
<p>FLUSSI DI LAVORO SLIDES</p>
<ul>
<li><a href="/slides/it/cpp/powerpoint-charts/">Grafici</a></li>
<li><a href="/slides/it/cpp/powerpoint-animation/">Animazioni</a></li>
<li><a href="/slides/it/cpp/manage-media-files/">Audio e video</a></li>
<li><a href="/slides/it/cpp/presentation-design/">Progettazione diapositiva</a></li>
<li><a href="/slides/it/cpp/merge-presentation/">Unisci presentazioni</a></li>
</ul>
<p>ESEMPI</p>
<ul>
<li><a href="/slides/it/cpp/examples/">Esempi per elemento della diapositiva</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">Esempi su GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Riferimento &amp; Supporto</b></p>
<hr>
<p>RIFERIMENTO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">Riferimento API</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">Note di rilascio</a></li>
<li><a href="/slides/it/cpp/known-issues/">Problemi noti</a></li>
<li><a href="https://products.aspose.com/slides/cpp/">Pagina prodotto</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">Download</a></li>
</ul>
<p>SUPPORTO</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum di supporto gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk di supporto a pagamento</a></li>
</ul>
</div>
</div>

------

## **La tua prima presentazione**

Su Windows, crea un progetto C++ **Console App** in Visual Studio e installa il pacchetto NuGet nella Console di Package Manager (**Tools** > **NuGet Package Manager** > **Package Manager Console**):

```powershell
Install-Package Aspose.Slides.Cpp
```

Su Linux, scarica il pacchetto ZIP per Linux e configura il progetto CMake descritto nella pagina [Installazione](/slides/it/cpp/installation/#linux).

Quindi utilizza questo codice come file sorgente principale del tuo programma. Crea una presentazione con un unico riquadro di testo e la salva:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Per eseguirlo su Windows, seleziona la piattaforma **x64** nella barra degli strumenti e premi **Ctrl+F5**. Su Linux, salvalo come *main.cpp* nella cartella del progetto, quindi compilalo ed eseguilo lì:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

Il programma salva *hello.pptx* con una diapositiva contenente un riquadro di testo. Senza licenza, il file salvato presenta una filigrana di valutazione — vedi [Licenza](/slides/it/cpp/licensing/). Per ulteriori modalità di creare e compilare una presentazione, vedi [Crea presentazioni](/slides/it/cpp/create-presentation/).