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

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do formatu HTML5 przy użyciu Aspose.Slides. Obejmuje podstawowy eksport HTML5 bez rozszerzeń internetowych ani dodatkowych zależności, a także opcje kontrolowania animacji kształtów i przejść slajdów. Artykuł pokazuje także standardowy proces eksportu z PowerPoint do HTML, wyjaśnia, jak generować wynik HTML5 w trybie podglądu slajdów, oraz demonstruje, jak uwzględnić komentarze w wyeksportowanym dokumencie poprzez skonfigurowanie ich układu.

## **Eksportuj PowerPoint do HTML5**

Ten kod C# pokazuje, jak wyeksportować prezentację do HTML5 bez rozszerzeń internetowych i zależności:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 
W tym przypadku otrzymujesz czysty kod HTML. 
{{% /alert %}}

Można również określić ustawienia animacji kształtów i przejść slajdów w następujący sposób:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **Eksportuj PowerPoint do HTML**

Ten kod C# demonstruje standardowy proces konwersji PowerPoint do HTML:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

W tym przypadku zawartość prezentacji jest renderowana jako SVG w formie przedstawionej poniżej:

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
Kiedy używasz tej metody eksportu PowerPoint do HTML, ze względu na renderowanie SVG nie będziesz w stanie zastosować stylów ani animować konkretnych elementów. 
{{% /alert %}}

## **Eksportuj PowerPoint do HTML5 w trybie podglądu slajdów**

**Aspose.Slides** umożliwia konwersję prezentacji PowerPoint do dokumentu HTML5, w którym slajdy są wyświetlane w trybie podglądu slajdów. W takim przypadku, po otwarciu powstałego pliku HTML5 w przeglądarce, prezentacja jest widoczna w trybie podglądu slajdów na stronie internetowej. 

Ten kod C# demonstruje proces eksportu PowerPoint do HTML5 w trybie podglądu slajdów:

```c#
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

Komentarze w PowerPoint są narzędziem, które pozwala użytkownikom zostawiać notatki lub uwagi do slajdów prezentacji. Są szczególnie przydatne w projektach współpracy, gdzie wiele osób może dodawać swoje sugestie lub uwagi do konkretnych elementów slajdu bez zmieniania głównej treści. Każdy komentarz wyświetla nazwę autora, co ułatwia śledzenie, kto zostawił daną uwagę.

Załóżmy, że mamy następującą prezentację PowerPoint zapisaną w pliku „sample.pptx”.

![Two comments on the presentation slide](two_comments_pptx.png)

Podczas konwersji prezentacji PowerPoint do dokumentu HTML5 można łatwo określić, czy włączyć komentarze z prezentacji w dokumencie wyjściowym. Aby to zrobić, należy określić parametry wyświetlania komentarzy w właściwości `NotesCommentsLayouting` klasy [Html5Options](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/).

Poniższy przykład kodu konwertuje prezentację do dokumentu HTML5 z komentarzami wyświetlanymi po prawej stronie slajdów.
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

Dokument „output.html” jest przedstawiony na poniższym obrazku.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?**

Tak, HTML5 udostępnia oddzielne opcje włączania lub wyłączania [animacji kształtów](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/animateshapes/) oraz [przejść slajdów](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/animatetransitions/).

**Czy obsługa wyjścia komentarzy jest dostępna i gdzie można je umieścić względem slajdu?**

Tak, komentarze mogą być dodane w HTML5 i pozycjonowane (na przykład po prawej stronie slajdu) poprzez [ustawienia układu](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/notescommentslayouting/) dla notatek i komentarzy.

**Czy mogę pominąć linki wywołujące JavaScript ze względów bezpieczeństwa lub polityki CSP?**

Tak, istnieje [ustawienie](https://reference.aspose.com/slides/pl/net/aspose.slides.export/saveoptions/skipjavascriptlinks/), które pozwala pominąć hiperłącza z wywołaniami JavaScript podczas zapisywania. Pomaga to spełnić rygorystyczne zasady bezpieczeństwa.