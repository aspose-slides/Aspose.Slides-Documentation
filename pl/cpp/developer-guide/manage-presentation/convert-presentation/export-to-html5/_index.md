---
title: Konwertowanie prezentacji do HTML5 w C++
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

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do formatu HTML5 przy użyciu Aspose.Slides for C++. Omówiono podstawowy eksport, kontrolę animacji kształtów i przejść slajdów oraz układ komentarzy. Ponadto porównano wyjście HTML5 z wyjściem opartym na SVG, generowanym przy standardowym eksporcie HTML.

## **Eksportowanie prezentacji PowerPoint do HTML5**

Poniższy przykład ładuje prezentację z bieżącego katalogu i zapisuje ją w formacie HTML5. Używa domyślnych ustawień eksportu; kolejny przykład pokazuje, jak jawnie kontrolować odtwarzanie animacji. Zastąp ścieżkę wejściową ścieżką do własnej prezentacji.

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

{{% alert color="info" title="Note" %}}
Oprócz dokumentu HTML, eksport zapisuje dodatkowe pliki CSS i JavaScript potrzebne do stylizacji slajdów, animacji, efektów i nawigacji. Przechowuj te pliki razem z dokumentem HTML przy przenoszeniu lub publikowaniu wyniku. Wygenerowana strona ładuje także jQuery i Anime.js z publicznych CDN‑ów; bez nich nawigacja slajdów i animacje nie działają.
{{% /alert %}}

Aby wyeksportować bez odtwarzania animacji kształtów lub przejść slajdów, przekaż `false` do [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) i [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) w [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Ustawienia te są niezależne, więc można włączyć jedno, wyłączając drugie. Przykład eksportuje prezentację z wyłączonymi oboma typami animacji w wygenerowanej stronie.

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
## **Eksportowanie prezentacji PowerPoint do HTML**

Standardowy eksport HTML wykorzystuje inne podejście renderowania: zawartość slajdu jest reprezentowana jako SVG wewnątrz strony HTML. Poniższy przykład konwertuje prezentację do dokumentu HTML przy użyciu tego podejścia renderowania.

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

Uproszczony znacznik poniżej ilustruje strukturę wygenerowanej strony. Element SVG zawiera wyrenderowaną zawartość slajdu; tekst zastępczy reprezentuje tę zawartość i nie jest dosłownym wynikiem eksportu.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
Eksport oparty na SVG nie udostępnia kształtów PowerPoint jako oddzielnych elementów HTML. Użyj eksportu HTML5, gdy potrzebne są opcje animacji kształtów i przejść slajdów przedstawione w tym artykule.
{{% /alert %}}

## **Eksportowanie prezentacji PowerPoint do widoku slajdów HTML5**

Eksport HTML5 generuje stronę do przeglądania i nawigacji po slajdach prezentacji w przeglądarce. Ten przykład przekazuje `true` zarówno do [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) jak i [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/), aby wyeksportowany widok slajdów mógł odtwarzać efekty z oryginalnej prezentacji.  
Użyj prezentacji, która już zawiera animacje kształtów i przejścia slajdów, aby zobaczyć efekt tych ustawień. Włączenie ich nie dodaje nowych efektów do slajdów, które ich nie posiadają. Po eksporcie otwórz wygenerowany dokument HTML5 w przeglądarce, mając dostępne pliki pomocnicze.

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
## **Konwertowanie prezentacji do dokumentu HTML5 z komentarzami**

Możesz uwzględnić istniejące komentarze slajdów w wyjściu HTML5, aby czytelnicy mogli zobaczyć uwagi wraz z zawartością slajdu. Przykład w tej sekcji zakłada, że źródłowa prezentacja zawiera komentarze, jak pokazano poniżej. Eksportuje te komentarze; nie tworzy nowych.

![Two comments on the presentation slide](two_comments_pptx.png)

Przekaż obiekt [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) do metody [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) klasy [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). Wywołaj [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) z wartością `CommentsPositions::Right` z wyliczenia [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/), aby umieścić komentarze po prawej stronie każdego slajdu.

Poniższy przykład eksportuje prezentację do HTML5 z tym układem komentarzy. Prezentacja bez komentarzy nie będzie zawierała tekstu komentarza do wyświetlenia.

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

Poniższy obrazek pokazuje wyeksportowany dokument HTML5 z komentarzami wyświetlanymi obok slajdu.

![The comments in the output HTML5 document](two_comments_html5.png)

## **Wykluczanie hiperłączy JavaScript podczas eksportu**

Załóżmy, że `hyperlinks.pptx` zawiera tekst z odnośnikiem o docelowym `javascript:alert('Hello')` oraz zwykły link `https://example.com/`. Aby wykluczyć hiperłącze JavaScript podczas eksportu, wywołaj [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) z wartością `true`. Domyślnie jest to `false`, więc te linki nie są filtrowane, chyba że włączysz tę opcję.

Poniższy przykład ładuje prezentację z bieżącego katalogu i eksportuje ją przy użyciu [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/):

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

Wyeksportowany plik pomija hiperłącze JavaScript, zachowując jego tekst oraz zwykły link HTTPS. Źródłowa prezentacja pozostaje niezmieniona.

Opcja ta filtruje hiperłącza JavaScript; nie usuwa wszystkich skryptów ani innej aktywnej zawartości, ani nie gwarantuje zgodności z CSP. Na przykład wyjście HTML5 wciąż zawiera skrypty odpowiedzialne za nawigację slajdów i animacje.

## **FAQ**

**Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?**

Tak, eksport HTML5 oferuje oddzielne opcje włączania lub wyłączania [animacje kształtów](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) i [przejścia slajdów](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Czy komentarze są obsługiwane i gdzie można je umieścić względem slajdu?**

Tak, istniejące komentarze mogą być uwzględnione w wyjściu HTML5 i umieszczone (na przykład po prawej stronie slajdu) przy użyciu [ustawienia układu](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/).

**Czy mogę pominąć linki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?**

Tak, metoda [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) pozwala pominąć hiperłącza wywołujące JavaScript podczas zapisywania. Domyślnie jest to `false`. Zobacz [Exclude JavaScript Hyperlinks During Export](/slides/pl/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) po przykład eksportu HTML5 i zakres filtru. To ustawienie nie usuwa JavaScript używanego przez przeglądarkę HTML5 do nawigacji i animacji.