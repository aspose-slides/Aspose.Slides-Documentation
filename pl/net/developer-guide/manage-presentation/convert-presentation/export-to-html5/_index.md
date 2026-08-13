---
title: Konwertuj prezentacje do HTML5 w .NET
linktitle: Prezentacja do HTML5
type: docs
weight: 40
url: /pl/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do responsywnego HTML5 przy użyciu Aspose.Slides dla .NET. Zachowaj formatowanie, animacje i interaktywność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na HTML5 przy użyciu Aspose.Slides. Obejmuje podstawowy eksport HTML5, a także opcje kontroli animacji kształtów i przejść slajdów. Artykuł pokazuje również standardowy proces eksportu PowerPoint‑to‑HTML, wyjaśnia, jak generować wyjście HTML5 w trybie widoku slajdów oraz demonstruje, jak uwzględnić komentarze w eksportowanym dokumencie, konfigurując ich układ.

## **Eksport PowerPoint do HTML5**

Ten kod C# pokazuje, jak wyeksportować prezentację do HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 

Oprócz dokumentu HTML, eksport zapisuje pliki pomocnicze, do których odnosi się: `pres.css`, `master.css`, `animation.js`, `effects.js` i `navigation.js`. Wygenerowana strona ładuje także jQuery i Anime.js z publicznych CDN‑ów; bez nich nawigacja slajdów i animacje nie działają. 

{{% /alert %}}

Możesz określić ustawienia animacji kształtów i przejść slajdów w następujący sposób:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **Eksport PowerPoint do HTML**

Ten kod C# demonstruje standardowy proces konwersji PowerPoint do HTML:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

W tym przypadku zawartość prezentacji jest renderowana przy użyciu SVG w postaci takiej jak poniżej:

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

Gdy używasz tej metody do eksportu PowerPoint do HTML, ze względu na renderowanie SVG nie będziesz mógł stosować stylów ani animować konkretnych elementów. 

{{% /alert %}}

## **Eksport PowerPoint do widoku slajdów HTML5**

**Aspose.Slides** umożliwia konwersję prezentacji PowerPoint na dokument HTML5, w którym slajdy są wyświetlane w trybie widoku slajdów. W takim przypadku, po otwarciu wygenerowanego pliku HTML5 w przeglądarce, zobaczysz prezentację w trybie widoku slajdów na stronie internetowej. 

Ten kod C# demonstruje proces eksportu PowerPoint do widoku slajdów HTML5:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **Konwersja prezentacji do dokumentu HTML5 z komentarzami**

Komentarze w PowerPoint są narzędziem pozwalającym użytkownikom zostawiać notatki lub opinie na slajdach prezentacji. Są szczególnie przydatne w projektach współpracy, gdzie wiele osób może dodawać swoje sugestie lub uwagi do konkretnych elementów slajdu bez zmieniania głównej treści. Każdy komentarz wyświetla nazwę autora, co ułatwia śledzenie, kto dodał daną uwagę.

Załóżmy, że mamy następującą prezentację PowerPoint zapisaną w pliku „sample.pptx”.

![Dwa komentarze na slajdzie prezentacji](two_comments_pptx.png)

Podczas konwersji prezentacji PowerPoint do dokumentu HTML5 możesz łatwo określić, czy uwzględnić komentarze z prezentacji w dokumencie wyjściowym. Aby to zrobić, należy określić parametry wyświetlania komentarzy w właściwości `NotesCommentsLayouting` klasy [Html5Options](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/).

Poniższy przykład kodu konwertuje prezentację na dokument HTML5 z komentarzami wyświetlanymi po prawej stronie slajdów.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Dokument „output.html” przedstawiono na poniższym obrazku.

![Komentarze w wygenerowanym dokumencie HTML5](two_comments_html5.png)

## **FAQ**

### Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?

Tak, HTML5 udostępnia oddzielne opcje włączania lub wyłączania [animacji kształtów](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/animateshapes/) oraz [przejść slajdów](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/animatetransitions/).

### Czy obsługa komentarzy jest dostępna i gdzie mogą być umieszczone względem slajdu?

Tak, komentarze mogą być dodawane w HTML5 i pozycjonowane (na przykład po prawej stronie slajdu) poprzez [ustawienia układu](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/notescommentslayouting/) dla notatek i komentarzy.

### Czy mogę pominąć linki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?

Tak, istnieje [ustawienie](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveoptions/skipjavascriptlinks/), które pozwala pominąć hiperłącza z wywołaniami JavaScript podczas zapisywania. Pomaga to spełnić rygorystyczne polityki bezpieczeństwa.