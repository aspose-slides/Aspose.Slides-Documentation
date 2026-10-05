---
title: "Converti le presentazioni in HTML5 in C++"
linktitle: "Presentazione in HTML5"
type: docs
weight: 40
url: /it/cpp/export-to-html5/
keywords:
- "PowerPoint in HTML5"
- "OpenDocument in HTML5"
- "presentazione in HTML5"
- "diapositiva in HTML5"
- "PPT in HTML5"
- "PPTX in HTML5"
- "ODP in HTML5"
- "salva PPT come HTML5"
- "salva PPTX come HTML5"
- "salva ODP come HTML5"
- "esporta PPT in HTML5"
- "esporta PPTX in HTML5"
- "esporta ODP in HTML5"
- "C++"
- "Aspose.Slides"
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML5 reattivo con Aspose.Slides per C++. Conserva formattazione, animazioni e interattività."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in HTML5 utilizzando Aspose.Slides per C++. Copre l'esportazione di base, il controllo delle animazioni delle forme e delle transizioni delle diapositive, e il layout dei commenti. Confronta inoltre l'output HTML5 con l'output basato su SVG dell'esportazione HTML standard.

## **Esporta PowerPoint in HTML5**

L'esempio seguente carica una presentazione dalla directory di lavoro e la salva in formato HTML5. Utilizza le impostazioni predefinite di esportazione; l'esempio successivo mostra come controllare esplicitamente la riproduzione delle animazioni. Sostituire il percorso di input con il percorso della propria presentazione.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Nota" %}}
Oltre al documento HTML, l'esportazione genera file CSS e JavaScript di supporto per lo stile delle diapositive, le animazioni, gli effetti e la navigazione. Conservare questi file con il documento HTML quando si sposta o si pubblica l'output. La pagina generata carica inoltre jQuery e Anime.js da CDN pubblici; senza di essi la navigazione delle diapositive e le animazioni non funzionano.
{{% /alert %}}

Per esportare senza riprodurre le animazioni delle forme o le transizioni delle diapositive, passare `false` a [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) e [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) in [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Queste impostazioni sono indipendenti, quindi è possibile abilitare una e disabilitare l'altra. L'esempio esporta la presentazione con entrambi i tipi di animazione disabilitati nella pagina generata.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Esporta PowerPoint in HTML**

L'esportazione HTML standard utilizza un approccio di rendering diverso: il contenuto delle diapositive è rappresentato da SVG all'interno di una pagina HTML. L'esempio seguente converte una presentazione in un documento HTML utilizzando questo approccio di rendering.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

Il markup semplificato di seguito illustra la struttura della pagina generata. L'elemento SVG contiene il contenuto della diapositiva renderizzato; il testo segnaposto rappresenta quel contenuto e non è l'output reale dell'esportazione.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Attenzione" color="warning" %}}
L'esportazione basata su SVG non espone le forme di PowerPoint come elementi HTML individuali. Utilizzare l'esportazione HTML5 quando sono necessarie le opzioni di animazione delle forme e di transizione delle diapositive illustrate in questo articolo.
{{% /alert %}}

## **Esporta PowerPoint in visualizzazione diapositiva HTML5**

L'esportazione HTML5 produce una pagina per visualizzare e navigare le diapositive della presentazione in un browser. Questo esempio passa `true` sia a [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) sia a [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) in modo che la visualizzazione della diapositiva esportata possa riprodurre gli effetti della presentazione originale.

Utilizzare una presentazione che contiene già animazioni di forme e transizioni diapositive per vedere l'effetto di queste impostazioni. Abilitarle non aggiunge nuovi effetti alle diapositive che non ne hanno. Dopo l'esportazione, aprire il documento HTML5 generato in un browser con i file di supporto disponibili.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Converti una presentazione in un documento HTML5 con commenti**

È possibile includere i commenti delle diapositive esistenti nell'output HTML5 affinché i lettori possano vedere il feedback accanto al contenuto della diapositiva. L'esempio in questa sezione si aspetta che la presentazione di origine contenga commenti, come illustrato di seguito. Esporta tali commenti; non crea nuovi commenti.

![Due commenti sulla diapositiva della presentazione](two_comments_pptx.png)

Passare un oggetto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) al metodo [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) di [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Chiamare [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) con `CommentsPositions::Right` dall'enumerazione [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) per posizionare i commenti a destra di ogni diapositiva.

L'esempio seguente esporta la presentazione in HTML5 con questo layout dei commenti. Una presentazione senza commenti non avrà testo di commento da visualizzare.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

![I commenti nel documento HTML5 di output](two_comments_html5.png)

## **Escludi i collegamenti ipertestuali JavaScript durante l'esportazione**

Supponiamo che `hyperlinks.pptx` contenga testo collegato con un target `javascript:alert('Hello')` e un normale collegamento `https://example.com/`. Per escludere il collegamento ipertestuale JavaScript durante l'esportazione, chiamare [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) con `true`. Il valore predefinito è `false`, quindi questi collegamenti non vengono filtrati a meno che non si abiliti l'opzione.

L'esempio seguente carica la presentazione dalla directory di lavoro e la esporta utilizzando [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/):

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Il file esportato omette il collegamento ipertestuale JavaScript mantenendo il suo testo e il normale collegamento HTTPS. La presentazione di origine rimane invariata.

Questa opzione filtra i collegamenti ipertestuali JavaScript; non rimuove tutti gli script o altro contenuto attivo, né garantisce la conformità CSP. Ad esempio, l'output HTML5 include ancora script per la navigazione delle diapositive e le animazioni.

## **FAQ**

**Posso controllare se le animazioni degli oggetti e le transizioni delle diapositive verranno riprodotte in HTML5?**  
Sì, l'esportazione HTML5 offre opzioni separate per abilitare o disabilitare le [animazioni delle forme](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) e le [transizioni delle diapositive](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**I commenti sono supportati e dove possono essere posizionati rispetto alla diapositiva?**  
Sì, i commenti esistenti possono essere inclusi nell'output HTML5 e posizionati (ad esempio, a destra della diapositiva) tramite le [impostazioni di layout](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) per note e commenti.

**Posso ignorare i collegamenti che invocano JavaScript per motivi di sicurezza o CSP?**  
Sì, il metodo [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) consente di saltare i collegamenti ipertestuali con chiamate JavaScript durante il salvataggio. Il valore predefinito è `false`. Vedere [Escludi i collegamenti ipertestuali JavaScript durante l'esportazione](/slides/it/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) per un esempio di esportazione HTML5 e l'ambito del filtro. Questa impostazione non rimuove il JavaScript usato dal visualizzatore HTML5 per la navigazione e le animazioni.