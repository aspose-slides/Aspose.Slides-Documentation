---
title: Konwertuj prezentacje do HTML5 w Javie
linktitle: Prezentacja do HTML5
type: docs
weight: 40
url: /pl/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do responsywnego HTML5 przy użyciu Aspose.Slides dla Javy. Zachowaj formatowanie, animacje i interaktywność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do formatu HTML5 przy użyciu Aspose.Slides. Obejmuje podstawowy eksport HTML5 bez rozszerzeń internetowych ani dodatkowych zależności, a także opcje kontrolowania animacji kształtów i przejść slajdów. Artykuł przedstawia również standardowy proces eksportu PowerPoint do HTML, wyjaśnia, jak generować wyjście HTML5 w trybie widoku slajdów, oraz demonstruje, jak uwzględnić komentarze w wyeksportowanym dokumencie, konfigurując ich układ.

## **Eksport PowerPoint do HTML5**

Poniższy kod Java pokazuje, jak wyeksportować prezentację do HTML5 bez rozszerzeń internetowych i zależności:

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
W tym przypadku otrzymujesz czysty HTML. 
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

Poniższy kod Java demonstruje standardowy proces eksportu PowerPoint do HTML:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
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

{{% alert title="Note" color="warning" %}} 
Gdy używasz tej metody do eksportu PowerPoint do HTML, ze względu na renderowanie SVG, nie będziesz w stanie stosować stylów ani animować konkretnych elementów. 
{{% /alert %}}

## **Eksport PowerPoint do widoku slajdów HTML5**

**Aspose.Slides** pozwala konwertować prezentację PowerPoint na dokument HTML5, w którym slajdy są prezentowane w trybie widoku slajdów. W tym przypadku, po otwarciu powstałego pliku HTML5 w przeglądarce, zobaczysz prezentację w trybie widoku slajdów na stronie internetowej. 

Poniższy kod Java demonstruje proces eksportu PowerPoint do widoku slajdów HTML5:

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

## **Konwersja prezentacji do dokumentów HTML5 z komentarzami**

Komentarze w PowerPoint są narzędziem, które pozwala użytkownikom zostawiać notatki lub opinie na slajdach prezentacji. Są szczególnie przydatne w projektach zespołowych, gdzie wiele osób może dodawać swoje sugestie lub uwagi do określonych elementów slajdu bez zmieniania głównej treści. Każdy komentarz wyświetla nazwę autora, co ułatwia śledzenie, kto pozostawił daną uwagę.

Załóżmy, że mamy następującą prezentację PowerPoint zapisaną w pliku „sample.pptx”.

![Dwa komentarze na slajdzie prezentacji](two_comments_pptx.png)

Podczas konwersji prezentacji PowerPoint do dokumentu HTML5 możesz łatwo określić, czy uwzględnić komentarze z prezentacji w wyjściowym dokumencie. Aby to zrobić, przekaż parametry wyświetlania komentarzy do metody `setSlidesLayoutOptions` klasy [Html5Options](https://reference.aspose.com/slides/pl/java/com.aspose.slides/html5options/) .

Poniższy przykład kodu konwertuje prezentację na dokument HTML5 z komentarzami wyświetlanymi po prawej stronie slajdów.
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Dokument „output.html” jest pokazany na poniższym obrazku.

![Komentarze w wyjściowym dokumencie HTML5](two_comments_html5.png)

## **FAQ**

### Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?

Tak, HTML5 oferuje oddzielne opcje włączania lub wyłączania [animacji kształtów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) oraz [przejść slajdów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

### Czy obsługa komentarzy jest dostępna i gdzie można je umieścić względem slajdu?

Tak, komentarze można dodać w HTML5 i umieścić (na przykład po prawej stronie slajdu) za pomocą [ustawień układu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) dla notatek i komentarzy.

### Czy mogę pominąć linki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?

Tak, istnieje [ustawienie](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-), które pozwala pominąć hiperłącza wywołujące JavaScript podczas zapisywania. Pomaga to spełnić rygorystyczne zasady bezpieczeństwa.