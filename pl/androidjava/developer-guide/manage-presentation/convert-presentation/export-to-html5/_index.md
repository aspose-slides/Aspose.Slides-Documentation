---
title: Konwertuj prezentacje do HTML5 na Androidzie
linktitle: Prezentacja do HTML5
type: docs
weight: 40
url: /pl/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do responsywnego HTML5 przy użyciu Aspose.Slides dla Androida w Javie. Zachowaj formatowanie, animacje i interaktywność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na HTML5 przy użyciu Aspose.Slides. Obejmuje podstawowy eksport HTML5 bez rozszerzeń internetowych ani dodatkowych zależności, a także opcje kontrolowania animacji kształtów i przejść slajdów. Artykuł pokazuje również standardowy proces eksportu PowerPoint do HTML, opisuje, jak generować wyjście HTML5 w trybie widoku slajdów, oraz demonstruje, jak włączyć komentarze w wyeksportowanym dokumencie poprzez skonfigurowanie ich układu.

## **Eksport PowerPoint do HTML5**

Ten kod w Java pokazuje, jak wyeksportować prezentację do HTML5 bez rozszerzeń internetowych i zależności:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
W tym przypadku otrzymujesz czysty kod HTML. 
{{% /alert %}}

Możesz w ten sposób określić ustawienia animacji kształtów i przejść slajdów:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eksport PowerPoint do HTML**

Ten kod w Java demonstruje standardowy proces konwersji PowerPoint do HTML:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

W tym przypadku treść prezentacji jest renderowana przy użyciu SVG w formie takiej jak poniżej:

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
Kiedy używasz tej metody do eksportu PowerPoint do HTML, ze względu na renderowanie SVG nie będziesz w stanie stosować stylów ani animować konkretnych elementów. 
{{% /alert %}}

## **Eksport PowerPoint do widoku slajdów HTML5**

**Aspose.Slides** umożliwia konwersję prezentacji PowerPoint do dokumentu HTML5, w którym slajdy są wyświetlane w trybie widoku slajdów. W tym przypadku, po otwarciu wygenerowanego pliku HTML5 w przeglądarce, zobaczysz prezentację w trybie widoku slajdów na stronie internetowej. 

Ten kod w Java demonstruje proces eksportu PowerPoint do widoku slajdów HTML5:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konwersja prezentacji do dokumentu HTML5 z komentarzami**

Komentarze w PowerPoint są narzędziem, które umożliwia użytkownikom zostawianie notatek lub opinii na slajdach prezentacji. Są szczególnie przydatne w projektach zespołowych, gdy wiele osób może dodawać swoje sugestie lub uwagi do konkretnych elementów slajdu, nie zmieniając głównej treści. Każdy komentarz wyświetla imię i nazwisko autora, co ułatwia śledzenie, kto dodał uwagę.

Załóżmy, że mamy następującą prezentację PowerPoint zapisaną w pliku "sample.pptx".

![Dwa komentarze na slajdzie prezentacji](two_comments_pptx.png)

Podczas konwertowania prezentacji PowerPoint na dokument HTML5, możesz łatwo określić, czy komentarze z prezentacji mają być uwzględnione w dokumencie wyjściowym. Aby to zrobić, należy przekazać parametry wyświetlania komentarzy do metody `setSlidesLayoutOptions` klasy [Html5Options](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/html5options/).

Poniższy przykład kodu konwertuje prezentację na dokument HTML5 z komentarzami wyświetlanymi po prawej stronie slajdów.
```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Dokument "output.html" jest pokazany na obrazku poniżej.

![Komentarze w wyjściowym dokumencie HTML5](two_comments_html5.png)

## **FAQ**

### Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?

Tak, HTML5 udostępnia odrębne opcje włączania lub wyłączania [animacji kształtów](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) oraz [przejść slajdów](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

### Czy obsługiwany jest eksport komentarzy i gdzie można je umieścić względem slajdu?

Tak, komentarze mogą być dodawane w HTML5 i pozycjonowane (na przykład po prawej stronie slajdu) za pomocą [ustawień układu](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-).

### Czy mogę pominąć linki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?

Tak, istnieje [ustawienie](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) które pozwala pominąć hiperlinki wywołujące JavaScript podczas zapisywania. Pomaga to spełnić rygorystyczne polityki bezpieczeństwa.