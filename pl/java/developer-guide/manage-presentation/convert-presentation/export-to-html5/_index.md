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

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na HTML5 przy użyciu Aspose.Slides. Obejmuje podstawowy eksport HTML5 bez rozszerzeń sieciowych ani dodatkowych zależności, a także opcje kontrolowania animacji kształtów i przejść slajdów. Artykuł pokazuje również standardowy proces eksportu PowerPoint‑do‑HTML, wyjaśnia, jak generować wyjście HTML5 w trybie widoku slajdów oraz demonstruje, jak uwzględnić komentarze w wyeksportowanym dokumencie, konfigurując ich układ.

## **Eksportuj PowerPoint do HTML5**

Ten kod Java pokazuje, jak wyeksportować prezentację do HTML5 bez rozszerzeń sieciowych i zależności:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
W tym przypadku otrzymujesz czysty HTML. 
{{% /alert %}}

Możesz w ten sposób określić ustawienia animacji kształtów i przejść slajdów:

```java
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

## **Eksportuj PowerPoint do HTML**

Ten przykład Java demonstruje standardowy proces konwersji PowerPoint do HTML:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
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

{{% alert title="Note" color="warning" %}} 
Kiedy używasz tej metody do eksportu PowerPoint do HTML, z powodu renderowania SVG nie będziesz w stanie stosować stylów ani animować poszczególnych elementów. 
{{% /alert %}}

## **Eksportuj PowerPoint do widoku slajdów HTML5**

**Aspose.Slides** umożliwia konwersję prezentacji PowerPoint na dokument HTML5, w którym slajdy są wyświetlane w trybie widoku slajdów. W takim przypadku, po otwarciu wygenerowanego pliku HTML5 w przeglądarce, zobaczysz prezentację w trybie widoku slajdów na stronie internetowej.

Ten kod Java demonstruje proces eksportu PowerPoint do widoku slajdów HTML5:

```java
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

## **Konwertuj prezentacje na dokumenty HTML5 z komentarzami**

Komentarze w PowerPoint są narzędziem, które pozwala użytkownikom zostawiać notatki lub opinię na slajdach prezentacji. Są szczególnie przydatne w projektach współpracy, gdzie wiele osób może dodawać sugestie lub uwagi do konkretnych elementów slajdu, nie zmieniając głównej treści. Każdy komentarz pokazuje nazwę autora, co ułatwia śledzenie, kto dodał daną uwagę.

Załóżmy, że mamy następującą prezentację PowerPoint zapisaną w pliku „sample.pptx”.

![Two comments on the presentation slide](two_comments_pptx.png)

Podczas konwersji prezentacji PowerPoint na dokument HTML5 możesz łatwo określić, czy uwzględnić komentarze z prezentacji w dokumencie wyjściowym. Aby to zrobić, należy podać parametry wyświetlania komentarzy w metodzie `getNotesCommentsLayouting` klasy [Html5Options](https://reference.aspose.com/slides/pl/java/com.aspose.slides/html5options/).

Poniższy przykład kodu konwertuje prezentację na dokument HTML5 z komentarzami wyświetlanymi po prawej stronie slajdów.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

Dokument „output.html” jest przedstawiony na poniższym obrazie.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?**

Tak, HTML5 oferuje osobne opcje włączania lub wyłączania [animacji kształtów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) oraz [przejść slajdów](https://reference.aspose.com/slides/pl/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).

**Czy obsługa wyjścia komentarzy jest dostępna i gdzie można je umieścić względem slajdu?**

Tak, komentarze można dodać w HTML5 i umieścić (na przykład po prawej stronie slajdu) za pomocą [ustawień układu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) dla notatek i komentarzy.

**Czy mogę pominąć linki wywołujące JavaScript ze względów bezpieczeństwa lub CSP?**

Tak, istnieje [ustawienie](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) umożliwiające pomijanie hiperłączy z wywołaniami JavaScript podczas zapisywania. Pomaga to spełnić rygorystyczne polityki bezpieczeństwa.