---
title: "Konwertowanie prezentacji do HTML5 w JavaScript"
linktitle: "Prezentacja do HTML5"
type: docs
weight: 40
url: /pl/nodejs-java/export-to-html5/
keywords:
- "PowerPoint do HTML5"
- "OpenDocument do HTML5"
- "prezentacja do HTML5"
- "slajd do HTML5"
- "PPT do HTML5"
- "PPTX do HTML5"
- "ODP do HTML5"
- "zapisz PPT jako HTML5"
- "zapisz PPTX jako HTML5"
- "zapisz ODP jako HTML5"
- "eksportuj PPT do HTML5"
- "eksportuj PPTX do HTML5"
- "eksportuj ODP do HTML5"
- Node.js
- JavaScript
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do responsywnego HTML5 przy użyciu Aspose.Slides dla Node.js. Zachowaj formatowanie, animacje i interaktywność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na HTML5 przy użyciu Aspose.Slides. Omówiono podstawowy eksport HTML5 bez rozszerzeń internetowych ani dodatkowych zależności, a także opcje kontrolowania animacji kształtów i przejść slajdów. Artykuł przedstawia także standardowy proces eksportu PowerPoint do HTML, wyjaśnia, jak generować wyjście HTML5 w trybie widoku slajdu, oraz demonstruje, jak włączyć komentarze w wyeksportowanym dokumencie poprzez skonfigurowanie ich układu.

## **Eksportuj PowerPoint do HTML5**

Ten kod JavaScript pokazuje, jak wyeksportować prezentację do HTML5 bez rozszerzeń internetowych i zależności:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
W tym przypadku otrzymujesz czysty kod HTML. 
{{% /alert %}}

Możesz w ten sposób określić ustawienia animacji kształtów i przejść slajdów:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Eksportuj PowerPoint do HTML**

Ten kod JavaScript demonstruje standardowy proces konwersji PowerPoint do HTML:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

W tym przypadku zawartość prezentacji jest renderowana jako SVG w formie takiej jak poniżej:

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
Kiedy używasz tej metody do eksportu PowerPoint do HTML, ze względu na renderowanie SVG nie będziesz mógł stosować stylów ani animować konkretnych elementów. 
{{% /alert %}}

## **Eksportuj PowerPoint do widoku slajdów HTML5**

**Aspose.Slides** umożliwia konwersję prezentacji PowerPoint na dokument HTML5, w którym slajdy są wyświetlane w trybie widoku slajdu. W takim przypadku, po otwarciu powstałego pliku HTML5 w przeglądarce, zobaczysz prezentację w trybie widoku slajdu na stronie internetowej.

Ten kod JavaScript demonstruje proces eksportu PowerPoint do widoku slajdów HTML5:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konwertuj prezentację na dokument HTML5 z komentarzami**

Komentarze w PowerPoint są narzędziem, które pozwala użytkownikom zostawiać notatki lub opinie na slajdach prezentacji. Są szczególnie przydatne w projektach zespołowych, gdzie wiele osób może dodawać własne sugestie lub uwagi do konkretnych elementów slajdu bez zmieniania głównej treści. Każdy komentarz wyświetla nazwę autora, co ułatwia śledzenie, kto zostawił daną uwagę.

Załóżmy, że mamy następującą prezentację PowerPoint zapisaną w pliku „sample.pptx”.

![Dwa komentarze na slajdzie prezentacji](two_comments_pptx.png)

Podczas konwersji prezentacji PowerPoint na dokument HTML5 możesz łatwo określić, czy uwzględnić komentarze z prezentacji w wyjściowym dokumencie. Aby to zrobić, należy określić parametry wyświetlania komentarzy w właściwości `notes_comments_layouting` klasy [Html5Options](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/html5options/).

Poniższy przykład kodu konwertuje prezentację na dokument HTML5 z komentarzami wyświetlanymi po prawej stronie slajdów.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```

Dokument „output.html” jest pokazany na obrazku poniżej.

![Komentarze w wyjściowym dokumencie HTML5](two_comments_html5.png)

## **FAQ**

**Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?**

Tak, HTML5 udostępnia oddzielne opcje włączania lub wyłączania [animacji kształtów](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/html5options/setanimateshapes/) oraz [przejść slajdów](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/html5options/setanimatetransitions/).

**Czy obsługa komentarzy jest dostępna i gdzie można je umieścić względem slajdu?**

Tak, komentarze mogą być dodane w HTML5 i pozycjonowane (na przykład po prawej stronie slajdu) poprzez [ustawienia układu](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) dla notatek i komentarzy.

**Czy mogę pominąć linki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?**

Tak, istnieje [ustawienie](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks), które pozwala pominąć hiperłącza zawierające wywołania JavaScript podczas zapisywania. Pomaga to spełnić rygorystyczne polityki bezpieczeństwa.