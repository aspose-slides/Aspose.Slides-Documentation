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

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do HTML5 przy użyciu Aspose.Slides. Obejmuje podstawowy eksport HTML5 bez rozszerzeń internetowych ani dodatkowych zależności, a także opcje kontrolowania animacji kształtów i przejść slajdów. Artykuł pokazuje również standardowy proces eksportu z PowerPointa do HTML, wyjaśnia, jak generować wyjście HTML5 w trybie widoku slajdów, oraz demonstruje, jak dołączyć komentarze do wyeksportowanego dokumentu, konfigurując ich rozmieszczenie.

## **Eksport PowerPoint do HTML5**

Ten kod C++ pokazuje, jak wyeksportować prezentację do HTML5.

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 
W tym przypadku otrzymujesz czysty HTML. 
{{% /alert %}}

Możesz chcieć określić ustawienia animacji kształtów i przejść slajdów w ten sposób:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **Eksport PowerPoint do HTML**

Ten kod C++ demonstruje standardowy proces konwersji z PowerPoint do HTML:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

W tym przypadku zawartość prezentacji jest renderowana przy użyciu SVG w formie takiej jak poniżej:

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
Kiedy używasz tej metody do eksportu PowerPoint do HTML, ze względu na renderowanie SVG, nie będziesz mógł zastosować stylów ani animować konkretnych elementów. 
{{% /alert %}}

## **Eksport PowerPoint do widoku slajdów HTML5**

**Aspose.Slides** pozwala konwertować prezentację PowerPoint do dokumentu HTML5, w którym slajdy są wyświetlane w trybie widoku slajdów. W tym przypadku, gdy otworzysz wynikowy plik HTML5 w przeglądarce, zobaczysz prezentację w trybie widoku slajdów na stronie internetowej. 

Ten kod C++ demonstruje proces eksportu PowerPoint do widoku slajdów HTML5:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Konwersja prezentacji do dokumentu HTML5 z komentarzami**

Komentarze w PowerPoint są narzędziem, które pozwala użytkownikom zostawiać notatki lub uwagi na slajdach prezentacji. Są szczególnie przydatne w projektach współpracy, gdzie wiele osób może dodawać swoje sugestie lub uwagi do konkretnych elementów slajdu bez zmieniania głównej treści. Każdy komentarz wyświetla nazwę autora, co ułatwia śledzenie, kto dodał daną uwagę.

Załóżmy, że mamy następującą prezentację PowerPoint zapisaną w pliku "sample.pptx".

![Dwa komentarze na slajdzie prezentacji](two_comments_pptx.png)

Podczas konwertowania prezentacji PowerPoint do dokumentu HTML5 możesz łatwo określić, czy włączyć komentarze z prezentacji do dokumentu wyjściowego. Aby to zrobić, musisz określić parametry wyświetlania komentarzy w metodzie `get_NotesCommentsLayouting` klasy [Html5Options](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/html5options/) .

Poniższy przykład kodu konwertuje prezentację do dokumentu HTML5 z komentarzami wyświetlanymi po prawej stronie slajdów.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Dokument "output.html" jest pokazany na poniższym obrazie.

![Komentarze w wyjściowym dokumencie HTML5](two_comments_html5.png)

## **FAQ**

**Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?**

Tak, HTML5 udostępnia osobne opcje umożliwiające włączenie lub wyłączenie [animacji kształtów](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/html5options/set_animateshapes/) i [przejść slajdów](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**Czy obsługiwany jest eksport komentarzy i gdzie można je umieścić względem slajdu?**

Tak, komentarze można dodać w HTML5 i umieścić (na przykład po prawej stronie slajdu) za pomocą ustawień układu dla notatek i komentarzy.

**Czy mogę pominąć linki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?**

Tak, istnieje [ustawienie](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/), które pozwala pominąć hiperłącza z wywołaniami JavaScript podczas zapisywania. Pomaga to spełnić rygorystyczne zasady bezpieczeństwa.