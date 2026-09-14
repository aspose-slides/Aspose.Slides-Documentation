---
title: Zastosuj lub zmień układy slajdów w Pythonie za pośrednictwem Java
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/python-java/slide-layout/
keywords:
- układ slajdu
- układ zawartości
- znacznik
- projekt prezentacji
- projekt slajdu
- nieużywany układ
- widoczność stopki
- slajd tytułowy
- tytuł i zawartość
- nagłówek sekcji
- dwa elementy zawartości
- porównanie
- tylko tytuł
- pusty układ
- zawartość z podpisem
- obraz z podpisem
- tytuł i pionowy tekst
- pionowy tytuł i tekst
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zastosuj, twórz i modyfikuj układy slajdów w Aspose.Slides dla Pythona za pośrednictwem Java, dodawaj znaczniki, usuwaj nieużywane układy oraz kontroluj widoczność stopki."
---
## **Przegląd**

Układ slajdu określa pozycje i formatowanie znaczników, takich jak tytuły, tekst, obrazy, wykresy i tabele. Zastosowanie układu zapewnia slajdom spójną strukturę, umożliwiając jednocześnie, aby każdy slajd zawierał własną treść.

Najczęściej używane układy to:

- **Title Slide**: Zawiera znaczniki tytułu i podtytułu.
- **Title and Content**: Zawiera znacznik tytułu oraz ogólny znacznik zawartości.
- **Blank**: Nie zawiera znaczników treści i jest przydatny, gdy każdy kształt będzie rozmieszczany ręcznie.

## **Zrozumienie dziedziczenia układu**

Prezentacja ma trzy powiązane poziomy:

1. A [slajd master](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslide/) definiuje motyw, współdzielone formatowanie, tła i wspólne obiekty.
1. A [slajd układu](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/) należy do slajdu master i definiuje określone rozmieszczenie znaczników.
1. A [slajd normalny](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/) używa jednego układu i przechowuje wprowadzoną dla niego treść.

Slajd normalny dziedziczy motyw i formatowanie z swojego układu, a układ dziedziczy z mastera. Wartość ustawiona bezpośrednio na slajdzie normalnym nadpisuje odziedziczoną wartość na tym poziomie. Gdy tworzony jest slajd normalny, jego kształty znaczników są generowane na podstawie wybranego układu, a treść wprowadzona do tych znaczników należy do slajdu normalnego.

Dodaj wymagane znaczniki do układu przed tworzeniem z niego slajdów. Dodanie kolejnego znacznika do układu później nie powoduje automatycznego dodania odpowiadającego kształtu znacznika do istniejących slajdów normalnych.

Ta zależność ma dwa ważne konsekwencje:

- Zmiana odziedziczonego formatowania lub istniejącej geometrii znacznika w układzie może zaktualizować każdy slajd, który od niego zależy. Przed edycją układu, który jest już używany, sprawdź jego zależne slajdy i przejrzyj powstałą prezentację.
- Układ, który jest nadal używany przez slajd, nie może być usunięty. Przypisz najpierw jego zależne slajdy do innego układu lub usuń tylko nieużywane układy.

Aby uzyskać więcej informacji o najwyższym poziomie tej hierarchii, zobacz [Slajd master](/slides/pl/python-java/slide-master/).

## **Wybierz i zastosuj układ slajdu**

Używaj typu układu, gdy prezentacja korzysta ze standardowych definicji układów PowerPoint. Nazwy układów są edytowalne przez użytkownika i mogą być lokalizowane, więc wybór oparty na nazwie jest mniej wiarygodny, chyba że kontrolujesz szablon źródłowy.

Poniższy przykład wyszukuje **Title and Content** w pierwszym masterze. Jeśli ten układ nie jest dostępny, celowo przełącza się na **Blank**. Drugi warunek sprawdzający `None` jest potrzebny, ponieważ prezentacja może zawierać wyłącznie własne układy. Wybrany układ jest następnie zastosowany do pierwszego slajdu normalnego przy pomocy metody [Slide.setLayoutSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#setLayoutSlide).

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

Zmiana układu slajdu nie usuwa zwykłych kształtów dodanych bezpośrednio do slajdu. Jednak pozycje znaczników, odziedziczone formatowanie oraz powiązania między istniejącymi znacznikami a nowym układem mogą się zmienić, dlatego warto sprawdzić wynik przy przełączaniu między wyraźnie odmiennymi układami.

## **Dodaj układ slajdu**

Wybór i tworzenie to odrębne operacje. Wcześniejszy przykład wybiera istniejący układ; nie tworzy go. Aby utworzyć układ, wywołaj metodę [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterlayoutslidecollection/#add) na kolekcji układów docelowego mastera.

Poniższy przykład zawsze dodaje nowy układ **Title and Content** o nazwie `Report Title and Content`, a następnie dodaje slajd normalny oparty na nim. Nazwy układów muszą być unikalne w obrębie kolekcji.

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

Dodawaj układ tylko wtedy, gdy szablon naprawdę potrzebuje kolejnej wielokrotnego użytku struktury. Jeśli odpowiedni układ już istnieje, wybierz go i użyj ponownie zamiast tworzyć duplikat.

## **Dodaj znaczniki do układu slajdu**

Metoda [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/#getPlaceholderManager) udostępnia [LayoutPlaceholderManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/) do dodawania kształtów znaczników do układu.

| Znacznik PowerPoint                | Metoda LayoutPlaceholderManager |
| ----------------------------------- | -------------------------------- |
| ![Content](content.png)             | [addContentPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [addTextPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)       | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)             | [addPicturePlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                 | [addChartPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                 | [addTablePlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [addSmartArtPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [addMediaPlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)    | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Poniższy przykład weryfikuje istnienie układu **Blank**, dodaje do niego cztery znaczniki, a następnie tworzy slajd normalny korzystający z zmodyfikowanego układu. Kolejność jest zamierzona: znaczniki są dodawane przed utworzeniem slajdu normalnego, więc Aspose.Slides może wygenerować odpowiadające kształty znaczników na tym slajdzie.

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

![Znaczniki na slajdzie układu](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}

Changing inherited formatting or the geometry of existing layout placeholders can affect dependent slides. A newly added layout placeholder is not backfilled into existing normal slides. Test layout changes on a copy of the presentation and inspect every dependent slide.

{{% /alert %}}

## **Usuń nieużywane układy slajdów**

Użyj metody [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compress/#removeUnusedLayoutSlides), aby usunąć układy, które nie są referencjonowane przez żaden slajd normalny. Metoda pozostawia nienaruszone układy, które są nadal używane.

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

Aby usunąć konkretny układ, najpierw użyj jego metody [hasDependingSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/#hasDependingSlides) lub [getDependingSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/#getDependingSlides). Przypisz najpierw wszystkie zależne slajdy, a dopiero potem wywołaj [LayoutSlide.remove](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/#remove). Próba usunięcia używanego układu powoduje zgłoszenie [PptxEditException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxeditexception/).

## **Kontrola widoczności stopki w układzie slajdu**

Układ posiada własne znaczniki stopki, numeru slajdu i daty/czasu. Użyj metody [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/#getHeaderFooterManager), aby sterować tymi znacznikami dla jednego układu. Jest to przydatne, gdy na przykład układy zawartości powinny wyświetlać stopki, a układy tytułów nie powinny.

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

## **Kontrola widoczności stopki w slajdzie master i jego układach potomnych**

Aby zastosować spójne ustawienia stopki w całej hierarchii mastera, użyj metody [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Metody propagacji z [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslideheaderfootermanager/) działają na masterze oraz jego zależnych układach i slajdach normalnych; nie są skierowane wyłącznie do jednego slajdu normalnego.

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

Slajd master definiuje motyw prezentacji i współdzielone formatowanie. Slajd układu należy do mastera i określa jedną wielokrotnego użytku konfigurację znaczników. Slajdy normalne korzystają z tych układów i przechowują treść specyficzną dla slajdu.

**Czy mogę skopiować slajd układu z jednej prezentacji do drugiej?**

Tak. Dodaj kopię do docelowej kolekcji przy pomocy metody [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/globallayoutslidecollection/#addClone). Kopiując między prezentacjami, sprawdź także czcionki, motywy, obrazy i inne zasoby użyte przez źródłowy układ.

**Co się dzieje, gdy modyfikuję układ, który jest już używany?**

Zależne slajdy dziedziczą zmiany w układzie, chyba że nadpisują dotknięte formatowanie lub obiekty lokalnie. Geometria znaczników i odziedziczony styl mogą więc zmienić się na wielu slajdach jednocześnie. Użyj [getDependingSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/#getDependingSlides), aby zidentyfikować dotknięte slajdy przed edycją układu.

**Co się stanie, jeśli usunę układ, który jest nadal używany?**

Aspose.Slides zgłasza [PptxEditException](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pptxeditexception/). Najpierw przypisz zależne slajdy do innego układu lub użyj [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/compress/#removeUnusedLayoutSlides), aby usunąć tylko nieodwołane układy.