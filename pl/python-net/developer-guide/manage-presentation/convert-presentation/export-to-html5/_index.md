---
title: "Konwertuj prezentacje do HTML5 w języku Python"
linktitle: "Eksportuj do HTML5"
type: docs
weight: 40
url: /pl/python-net/export-to-html5/
keywords:
- "PowerPoint do HTML5"
- "OpenDocument do HTML5"
- "prezentacja do HTML5"
- "slajd do HTML5"
- "PPT do HTML5"
- "PPTX do HTML5"
- "ODP do HTML5"
- "konwertuj PowerPoint"
- "konwertuj OpenDocument"
- "konwertuj prezentację"
- "konwertuj slajd"
- "eksport HTML5"
- "eksportuj prezentację"
- "eksportuj slajd"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "Python"
- "Aspose.Slides"
description: "Eksportuj prezentacje PowerPoint i OpenDocument do responsywnego HTML5 przy użyciu Aspose.Slides for Python via .NET. Zachowaj formatowanie, animacje i interaktywność."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint do HTML5 przy użyciu Aspose.Slides. Omawia podstawowy eksport HTML5 bez rozszerzeń sieciowych ani dodatkowych zależności, a także opcje kontrolowania animacji kształtów i przejść slajdów. Artykuł pokazuje również standardowy proces eksportu PowerPoint do HTML, wyjaśnia, jak generować wyjście HTML5 w trybie widoku slajdów oraz demonstruje, jak dołączyć komentarze do wyeksportowanego dokumentu, konfigurując ich układ.

## **Eksport PowerPoint do HTML5**

Ten kod w języku Python pokazuje, jak wyeksportować prezentację do HTML5 bez rozszerzeń sieciowych i zależności:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 
W tym przypadku otrzymujesz czysty HTML. 
{{% /alert %}}

Możesz w ten sposób określić ustawienia animacji kształtów i przejść slajdów:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **Eksport PowerPoint do HTML**

Ten kod w języku Python demonstruje standardowy proces konwersji PowerPoint do HTML:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

W tym przypadku zawartość prezentacji jest renderowana za pomocą SVG w formie takiej jak poniżej:

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
Kiedy używasz tej metody do eksportu PowerPoint do HTML, ze względu na renderowanie SVG, nie będziesz w stanie zastosować stylów ani animować konkretnych elementów. 
{{% /alert %}}

## **Eksport PowerPoint do widoku slajdów HTML5**

**Aspose.Slides** umożliwia konwersję prezentacji PowerPoint do dokumentu HTML5, w którym slajdy są wyświetlane w trybie widoku slajdów. W takim przypadku, po otwarciu wygenerowanego pliku HTML5 w przeglądarce, zobaczysz prezentację w trybie widoku slajdów na stronie internetowej.

Ten kod w języku Python demonstruje proces eksportu PowerPoint do widoku slajdów HTML5:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # Eksportuj prezentację zawierającą przejścia slajdów, animacje i animacje kształtów do HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # Zapisz prezentację
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **Konwersja prezentacji do dokumentu HTML5 z komentarzami**

Komentarze w PowerPoint to narzędzie, które pozwala użytkownikom zostawiać notatki lub opinie na slajdach prezentacji. Są szczególnie przydatne w projektach współpracowych, gdzie wiele osób może dodawać swoje sugestie lub uwagi do konkretnych elementów slajdu bez zmiany głównej treści. Każdy komentarz pokazuje nazwisko autora, co ułatwia śledzenie, kto zostawił daną uwagę.

Załóżmy, że mamy następującą prezentację PowerPoint zapisaną w pliku "sample.pptx".

![Dwa komentarze na slajdzie prezentacji](two_comments_pptx.png)

Podczas konwersji prezentacji PowerPoint do dokumentu HTML5 możesz łatwo określić, czy uwzględnić komentarze z prezentacji w dokumencie wyjściowym. Aby to zrobić, musisz podać parametry wyświetlania komentarzy w właściwości `notes_comments_layouting` klasy [Html5Options](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/html5options/).

Poniższy przykład kodu konwertuje prezentację do dokumentu HTML5 z komentarzami wyświetlanymi po prawej stronie slajdów.

```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

Dokument "output.html" przedstawiono na poniższym obrazie.

![Komentarze w wyjściowym dokumencie HTML5](two_comments_html5.png)

## **FAQ**

**Czy mogę kontrolować, czy animacje obiektów i przejścia slajdów będą odtwarzane w HTML5?**

Tak, HTML5 oferuje osobne opcje włączania lub wyłączania [animacji kształtów](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/html5options/animate_shapes/) i [przejść slajdów](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/html5options/animate_transitions/).

**Czy obsługiwany jest eksport komentarzy i gdzie można je umieścić względem slajdu?**

Tak, komentarze mogą być dodane w HTML5 i umieszczone (na przykład po prawej stronie slajdu) za pomocą [ustawień układu](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/html5options/notes_comments_layouting/) dla notatek i komentarzy.

**Czy mogę pominąć linki wywołujące JavaScript ze względów bezpieczeństwa lub polityki CSP?**

Tak, istnieje [ustawienie](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/html5options/skip_java_script_links/), które umożliwia pomijanie hiperłączy z wywołaniami JavaScript podczas zapisywania. Pomaga to spełnić rygorystyczne polityki bezpieczeństwa.