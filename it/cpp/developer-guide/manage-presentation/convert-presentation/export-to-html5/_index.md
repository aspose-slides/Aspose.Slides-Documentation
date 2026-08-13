---
title: Convertire le presentazioni in HTML5 in C++
linktitle: Presentazione in HTML5
type: docs
weight: 40
url: /it/cpp/export-to-html5/
keywords:
- PowerPoint in HTML5
- OpenDocument in HTML5
- presentazione in HTML5
- diapositiva in HTML5
- PPT in HTML5
- PPTX in HTML5
- ODP in HTML5
- salva PPT come HTML5
- salva PPTX come HTML5
- salva ODP come HTML5
- esporta PPT in HTML5
- esporta PPTX in HTML5
- esporta ODP in HTML5
- C++
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML5 responsivo con Aspose.Slides per C++. Mantieni formattazione, animazioni e interattività."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in HTML5 utilizzando Aspose.Slides. Copre l'esportazione di base in HTML5 senza estensioni web o dipendenze aggiuntive, oltre alle opzioni per controllare le animazioni delle forme e le transizioni delle diapositive. L'articolo mostra anche il processo standard di esportazione da PowerPoint a HTML, spiega come generare output HTML5 in modalità visualizzazione diapositiva e dimostra come includere i commenti nel documento esportato configurandone il layout.

## **Esporta PowerPoint in HTML5**

Questo codice C++ mostra come esportare una presentazione in HTML5.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
In questo caso, ottieni HTML pulito. 
{{% /alert %}}

Potresti voler specificare le impostazioni per le animazioni delle forme e le transizioni delle diapositive in questo modo:

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Esporta PowerPoint in HTML**

Questo C++ dimostra il processo standard di esportazione da PowerPoint a HTML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

In questo caso, il contenuto della presentazione viene renderizzato tramite SVG in una forma come questa:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
Quando utilizzi questo metodo per esportare PowerPoint in HTML, a causa del rendering SVG, non potrai applicare stili o animare elementi specifici. 
{{% /alert %}}

## **Esporta PowerPoint in Visualizzazione Diapositiva HTML5**

**Aspose.Slides** consente di convertire una presentazione PowerPoint in un documento HTML5 in cui le diapositive vengono presentate in modalità visualizzazione diapositiva. In questo caso, quando apri il file HTML5 risultante in un browser, visualizzi la presentazione in modalità visualizzazione diapositiva su una pagina web. 

Questo codice C++ dimostra il processo di esportazione da PowerPoint a Visualizzazione Diapositiva HTML5:

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Converti una presentazione in un documento HTML5 con commenti**

I commenti in PowerPoint sono uno strumento che consente agli utenti di lasciare note o feedback sulle diapositive della presentazione. Sono particolarmente utili nei progetti collaborativi, dove più persone possono aggiungere suggerimenti o osservazioni a specifici elementi della diapositiva senza modificare il contenuto principale. Ogni commento mostra il nome dell'autore, facilitando l'identificazione di chi ha lasciato l'osservazione.

Supponiamo di avere la seguente presentazione PowerPoint salvata nel file "sample.pptx".

![Due commenti sulla diapositiva della presentazione](two_comments_pptx.png)

Quando converti una presentazione PowerPoint in un documento HTML5, puoi specificare facilmente se includere i commenti della presentazione nel documento di output. Per fare ciò, è necessario specificare i parametri di visualizzazione per i commenti nel metodo `get_NotesCommentsLayouting` della classe [Html5Options](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/html5options/).

Il seguente esempio di codice converte una presentazione in un documento HTML5 con i commenti visualizzati a destra delle diapositive.
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Il documento "output.html" è mostrato nell'immagine seguente.

![I commenti nel documento HTML5 di output](two_comments_html5.png)

## **FAQ**

### Posso controllare se le animazioni degli oggetti e le transizioni delle diapositive verranno riprodotte in HTML5?

Sì, HTML5 offre opzioni separate per abilitare o disabilitare [animazioni delle forme](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/html5options/set_animateshapes/) e [transizioni delle diapositive](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/html5options/set_animatetransitions/).

### È supportata l'esportazione dei commenti e dove possono essere posizionati rispetto alla diapositiva?

Sì, i commenti possono essere aggiunti in HTML5 e posizionati (ad esempio, a destra della diapositiva) tramite le impostazioni di layout per note e commenti.

### Posso ignorare i collegamenti che invocano JavaScript per motivi di sicurezza o CSP?

Sì, esiste una [impostazione](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) che consente di ignorare i collegamenti ipertestuali con chiamate JavaScript durante il salvataggio. Questo aiuta a rispettare rigide politiche di sicurezza.