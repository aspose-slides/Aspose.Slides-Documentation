---
title: Konwertuj prezentacje do HTML5 w C++
linktitle: Prezentacja do HTML5
type: docs
weight: 40
url: /pl/cpp/export-to-html5/
keywords:
- PowerPoint do HTML5
- OpenDocument do HTML5
- prezentacja do HTML5
- slajd do HTML5
- PPT do HTML5
- PPTX do HTML5
- ODP do HTML5
- zapisz PPT jako HTML5
- zapisz PPTX jako HTML5
- zapisz ODP jako HTML5
- eksportuj PPT do HTML5
- eksportuj PPTX do HTML5
- eksportuj ODP do HTML5
- C++
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do responsywnego HTML5 przy użyciu Aspose.Slides dla C++. Zachowaj formatowanie, animacje i interaktywność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na HTML5 przy użyciu Aspose.Slides. Omówiono podstawowy eksport HTML5 bez dodatków sieciowych ani dodatkowych zależności, a także opcje kontrolujące animacje kształtów i przejścia slajdów. Artykuł przedstawia także standardowy proces eksportu PowerPoint‑to‑HTML, wyjaśnia, jak generować wyjście HTML5 w trybie widoku slajdów oraz demonstruje, jak uwzględnić komentarze w wyeksportowanym dokumencie, konfigurując ich układ.

## **Eksport PowerPoint do HTML5**

Ten kod C++ pokazuje, jak wyeksportować prezentację do HTML5.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
W tym przypadku otrzymujesz czysty kod HTML. 
{{% /alert %}}

Możesz w ten sposób określić ustawienia animacji kształtów i przejść slajdów:

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

## **Eksport PowerPoint do HTML**

Ten kod C++ demonstruje standardowy proces eksportu PowerPoint do HTML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

W tym przypadku zawartość prezentacji jest renderowana przy użyciu SVG w następującej formie:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Uwaga" color="warning" %}} 
Gdy używasz tej metody do eksportu PowerPoint do HTML, z powodu renderowania SVG nie będziesz mógł zastosować stylów ani animować poszczególnych elementów. 
{{% /alert %}}

## **Eksport PowerPoint do HTML5 w trybie widoku slajdów**

**Aspose.Slides** umożliwia konwersję prezentacji PowerPoint na dokument HTML5, w którym slajdy są wyświetlane w trybie widoku slajdów. W tym przypadku, po otwarciu wygenerowanego pliku HTML5 w przeglądarce, prezentacja jest wyświetlana w trybie widoku slajdów na stronie internetowej.

Ten kod C++ demonstruje proces eksportu PowerPoint do HTML5 w trybie widoku slajdów:

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

## **Konwersja prezentacji na dokument HTML5 z komentarzami**

Komentarze w PowerPoint są narzędziem umożliwiającym użytkownikom pozostawianie notatek lub uwag na slajdach prezentacji. Są szczególnie przydatne w projektach zespołowych, gdzie wiele osób może dodawać swoje sugestie lub uwagi do konkretnych elementów slajdu bez modyfikacji głównej treści. Każdy komentarz zawiera nazwę autora, co ułatwia śledzenie, kto zostawił daną uwagę.

Załóżmy, że mamy następującą prezentację PowerPoint zapisaną w pliku „sample.pptx”.

![Dwa komentarze na slajdzie prezentacji](two_comments_pptx.png)

Podczas konwersji prezentacji PowerPoint na dokument HTML5 możesz łatwo określić, czy komentarze z prezentacji mają być uwzględnione w dokumencie wyjściowym. Aby to zrobić, musisz określić parametry wyświetlania komentarzy w metodzie `get_NotesCommentsLayouting` klasy [Html5Options](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/html5options/).

Poniższy przykład kodu konwertuje prezentację na dokument HTML5 z komentarzami wyświetlanymi po prawej stronie slajdów.
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

Dokument „output.html” jest pokazany na poniższym obrazie.

![Komentarze w wyjściowym dokumencie HTML5](two_comments_html5.png)

## **FAQ**

### Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?

Tak, HTML5 udostępnia oddzielne opcje włączania lub wyłączania [animacji kształtów](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/html5options/set_animateshapes/) oraz [przejść slajdów](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/html5options/set_animatetransitions/).

### Czy obsługa komentarzy jest dostępna i gdzie można je umieścić względem slajdu?

Tak, komentarze mogą być dodane w HTML5 i rozmieszczone (na przykład po prawej stronie slajdu) za pomocą ustawień układu notatek i komentarzy.

### Czy mogę pominąć linki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?

Tak, istnieje [ustawienie](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/), które pozwala pominąć hiperłącza z wywołaniami JavaScript podczas zapisywania. Pomaga to spełnić rygorystyczne polityki bezpieczeństwa.