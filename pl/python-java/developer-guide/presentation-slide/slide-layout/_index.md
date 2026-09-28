---
title: Zastosuj lub zmień układy slajdów w Pythonie przy użyciu Javy
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/python-java/slide-layout/
keywords:
- układ slajdu
- układ treści
- symbol zastępczy
- projektowanie prezentacji
- projektowanie slajdu
- nieużywany układ
- widoczność stopki
- slajd tytułowy
- tytuł i treść
- nagłówek sekcji
- dwie treści
- porównanie
- tylko tytuł
- pusty układ
- treść z podpisem
- obraz z podpisem
- tytuł i pionowy tekst
- pionowy tytuł i tekst
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zastosuj, twórz i modyfikuj układy slajdów w Aspose.Slides for Python via Java, dodawaj symbole zastępcze, usuwaj nieużywane układy i kontroluj widoczność stopki."
---
## **Przegląd**

Układ slajdu określa pozycje i formatowanie symboli zastępczych, takich jak tytuły, tekst, obrazy, wykresy i tabele. Zastosowanie układu nadaje slajdom spójną strukturę, jednocześnie pozwalając każdemu slajdowi zawierać własną treść.

Najbardziej powszechne układy to:

- **Slajd tytułowy**: Zawiera symbole zastępcze tytułu i podtytułu.
- **Tytuł i treść**: Zawiera symbol zastępczy tytułu oraz ogólny symbol zastępczy treści.
- **Pusty**: Nie zawiera symboli zastępczych i jest przydatny, gdy każdy kształt będzie pozycjonowany ręcznie.

## **Zrozumienie dziedziczenia układu**

Prezentacja ma trzy powiązane poziomy:

1. [slajd wzorcowy](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslide/) definiuje motyw, wspólne formatowanie, tła i wspólne obiekty.
1. [slajd układu](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/) należy do wzorca i określa konkretny układ symbolów zastępczych.
1. [zwykły slajd](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/) używa jednego układu i przechowuje wprowadzoną treść dla tego slajdu.

Zwykły slajd dziedziczy motyw i formatowanie z układu, a układ dziedziczy z wzorca. Wartość ustawiona bezpośrednio na zwykłym slajdzie zastępuje wartość odziedziczoną na tym poziomie. Gdy tworzy się zwykły slajd, kształty symboli zastępczych są generowane z wybranego układu, a treść wprowadzona w tych symbolach należy do zwykłego slajdu.

Dodaj wymagane symbole zastępcze do układu przed tworzeniem z niego slajdów. Dodanie kolejnego symbolu zastępczego do układu później nie dodaje automatycznie odpowiadającego kształtu symbolu do istniejących zwykłych slajdów.

Ta zależność ma dwa ważne konsekwencje:

- Zmiana odziedziczonego formatowania lub istniejącej geometrii symboli zastępczych w układzie może zaktualizować każdy slajd, który od niego zależy. Przed edycją układu już używanego, sprawdź jego zależne slajdy i przejrzyj wynikową prezentację.
- Układ, który jest nadal używany przez slajd, nie może zostać usunięty. Przypisz najpierw jego zależne slajdy do innego układu lub usuń tylko nieużywane układy.

Po więcej informacji o najwyższym poziomie tej hierarchii zobacz [Slide Master](/slides/pl/python-java/slide-master/).

Aby ukryć odziedziczone logo lub dekoracyjne kształty wzorca na jednym slajdzie lub poprzez współdzielony układ, zobacz [Control the Visibility of Master Graphics](/slides/pl/python-java/slide-master/). Przykład porównuje dwa slajdy używające tego samego wzorca.

## **Wybierz i zastosuj układ slajdu**

Używaj typu układu, gdy prezentacja podąża za standardowymi definicjami układów PowerPoint. Nazwy układów można edytować i lokalizować, więc wybór oparty na nazwie jest mniej niezawodny, chyba że kontrolujesz szablon źródłowy.

Poniższy przykład szuka **Tytuł i treść** w pierwszym wzorcu. Jeśli ten układ jest niedostępny, celowo przechodzi do **Pusty**. Drugi warunek sprawdzający `None` jest konieczny, ponieważ prezentacja może zawierać wyłącznie układy niestandardowe. Wybrany układ jest następnie stosowany do pierwszego zwykłego slajdu za pomocą metody [Slide.setLayoutSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#setLayoutSlide).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Zmiana układu slajdu nie usuwa zwykłych kształtów dodanych bezpośrednio do slajdu. Jednak pozycje symboli zastępczych, odziedziczone formatowanie i zależność między istniejącymi symbolami a nowym układem mogą się zmienić, więc sprawdź wynik przy przełączaniu między znacznie różnymi układami.

## **Dodaj układ slajdu**

Wybór i tworzenie to odrębne operacje. Poprzedni przykład wybiera istniejący układ; nie tworzy go. Aby utworzyć układ, wywołaj metodę [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterlayoutslidecollection/#add) na kolekcji układów docelowego wzorca.

Poniższy przykład zawsze dodaje nowy układ **Tytuł i treść** o nazwie `Report Title and Content`, a następnie dodaje zwykły slajd oparty na nim. Nazwy układów muszą być unikatowe w kolekcji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dodawaj układ tylko wtedy, gdy szablon naprawdę potrzebuje kolejnej struktury wielokrotnego użytku. Jeśli odpowiedni układ już istnieje, wybierz go i użyj ponownie zamiast tworzyć duplikat.

## **Dodaj symbole zastępcze do układu slajdu**

Metoda [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/#getPlaceholderManager) udostępnia [LayoutPlaceholderManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/) do dodawania kształtów symboli zastępczych do układu.

| Symbol zastępczy PowerPoint | [LayoutPlaceholderManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/) Metoda |
| --------------------------- | ---------------------------------- |
| ![Zawartość](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Zawartość (pionowa)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Tekst](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Tekst (pionowy)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Obraz](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Wykres](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabela](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Multimedia](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Obraz online](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Poniższy przykład sprawdza, czy układ **Pusty** istnieje, dodaje do niego cztery symbole zastępcze, a następnie tworzy zwykły slajd korzystający z zmodyfikowanego układu. Kolejność jest zamierzona: symbole zastępcze są dodawane przed utworzeniem zwykłego slajdu, dzięki czemu Aspose.Slides może wygenerować odpowiadające im kształty symboli na tym slajdzie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Symbole zastępcze na slajdzie układu](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Zmiana odziedziczonego formatowania lub geometrii istniejących symboli zastępczych w układzie może wpływać na zależne slajdy. Nowo dodany symbol zastępczy układu nie jest automatycznie wstawiany do istniejących zwykłych slajdów. Testuj zmiany układu na kopii prezentacji i sprawdzaj każdy zależny slajd.
{{% /alert %}}

## **Usuń nieużywane układy slajdów**

Użyj metody [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compress/#removeUnusedLayoutSlides), aby usunąć układy, do których nie odnosi się żaden zwykły slajd. Metoda pozostawia nienaruszone układy nadal używane.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aby usunąć konkretny układ, najpierw użyj jego metody [hasDependingSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/#hasDependingSlides) lub [getDependingSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/#getDependingSlides). Przypisz wszystkie zależne slajdy przed wywołaniem [LayoutSlide.remove](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/#remove). Próba usunięcia używanego układu powoduje wyrzucenie [PptxEditException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxeditexception/).

## **Kontrola widoczności stopki na układzie slajdu**

Układ ma własne symbole zastępcze stopki, numeru slajdu i daty/czasu. Użyj metody [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/#getHeaderFooterManager), aby kontrolować te symbole w jednym układzie. Jest to przydatne, gdy np. układy treści mają wyświetlać stopki, a układy tytułowe nie.

Poniższy przykład bezpiecznie wybiera układ i ustawia jego elementy stopki jako widoczne:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kontrola widoczności stopki w masterze i jego układach potomnych**

Aby zastosować spójne ustawienia stopki w całej hierarchii mastera, użyj metody [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Metody propagacji [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslideheaderfootermanager/) działają na masterze oraz jego zależnych układach i zwykłych slajdach; nie celują w pojedynczy zwykły slajd.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Jaka jest różnica między slajdem master a slajdem układu?**

Slajd master definiuje motyw prezentacji i wspólne formatowanie. Slajd układu należy do mastera i definiuje jedną wielokrotnego użytku konfigurację symbolów zastępczych. Zwykłe slajdy używają tych układów i przechowują treść specyficzną dla slajdu.

**Czy mogę skopiować slajd układu z jednej prezentacji do drugiej?**

Tak. Dodaj kopię do docelowej kolekcji metodą [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/globallayoutslidecollection/#addClone). Przy kopiowaniu między prezentacjami sprawdź także czcionki, motywy, obrazy i inne zasoby użyte przez źródłowy układ.

**Co się stanie, gdy zmodyfikuję układ już używany?**

Zależne slajdy dziedziczą zmiany układu, chyba że nadpiszą dotknięte formatowanie lub obiekty lokalnie. Geometria symboli zastępczych i odziedziczony styl mogą więc zmienić się jednocześnie na wielu slajdach. Użyj [getDependingSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/#getDependingSlides), aby zidentyfikować dotknięte slajdy przed edycją układu.

**Co się stanie, jeśli usunę układ, który jest nadal używany?**

Aspose.Slides wyrzuca [PptxEditException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxeditexception/). Najpierw przypisz zależne slajdy lub użyj [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compress/#removeUnusedLayoutSlides), aby usunąć tylko nieodwoływane układy.