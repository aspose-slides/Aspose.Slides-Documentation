---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w PHP
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/php-java/presentation-view-properties/
keywords:
- właściwości widoku
- widok normalny
- zawartość konspektu
- ikony konspektu
- przyciąganie pionowego podziału
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczne dopasowanie
- domyślne powiększenie
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Użyj Aspose.Slides dla PHP przez Java, aby skonfigurować układ widoku normalnego, powiększenie slajdu i notatek, odstępy siatki oraz widoczność komentarzy w prezentacjach PowerPoint."
---
## **Wprowadzenie**

W widoku normalnym programu PowerPoint slajd pojawia się pomiędzy bocznym panelem miniatur lub konspektem a panelem notatek poniżej. Aspose.Slides dla PHP przez Java udostępnia zapisane preferencje edycji prezentacji za pośrednictwem [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/). Obejmują one układ paneli, poziomy powiększenia, odstępy siatki i widoczność komentarzy.

## **O NormalViewProperties**

Użyj [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) aby uzyskać dostęp do klasy [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) kontroluje, czy ikony pojawiają się obok tytułów slajdów w konspekcie. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) pozwala bocznemu panelowi przyciągać się do stanu zminimalizowanego, gdy użytkownik go zwęża. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) wskazuje preferencję wyświetlania jednego panelu w pełnym oknie.

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) kontroluje separator pomiędzy bocznym panelem a slajdem. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) kontroluje separator powyżej panelu notatek. Oba akceptują wartość [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) `Minimized`, `Maximized` lub `Restored`.

## **O przywracaniu NormalViewProperties**

Gdy separator zostaje przywrócony, [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) dostarcza zapisaną szerokość bocznego panelu, a [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) dostarcza zapisaną wysokość górnego obszaru slajdu. Oba udostępniają [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/). Jego metoda [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) przyjmuje procent od 0 do 100, a [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) kontroluje, czy edytor dostosowuje rozmiar przy zmianie rozmiaru okna.

Ten przykład aktualizuje istniejącą prezentację. Przywraca poziomy separator, ustawia rozmiar zwrócony przez [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) na 80 % z włączonym automatycznym dopasowaniem oraz maksymalizuje pionowy separator. Wywołuje także [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/), aby wyświetlić ikony w widoku konspektu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustaw domyślną wartość powiększenia**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) i [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) przechowują niezależne ustawienia powiększenia dla edytora. Ustawienia te nie wpływają na wymiary slajdu, odtwarzanie pokazu slajdów ani rozdzielczość eksportu obrazu.

Ten przykład otwiera istniejącą prezentację i wywołuje [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/), aby dopasować slajd do okna edycji. Dla strony notatek wyłącza automatyczne skalowanie i wywołuje [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/), aby ustawić stałe powiększenie 80 %.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustaw odstęp siatki**

Metoda `setGridSpacing` klasy [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) ustawia odległość między liniami siatki edycji w całej prezentacji. Przyjmuje dodatnią wartość w punktach, przy 72 punktach na cal. Ten przykład wyświetla bieżący odstęp w istniejącej prezentacji i zapisuje siatkę o ćwiartce cala, ustawiając interwał na 18 punktów.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Siatka powtarza się w stałym interwale. [Przewodniki rysunkowe](/slides/pl/php-java/drawing-guides/) oznaczają poszczególne pozycje poziome lub pionowe. Oba są pomocy edycyjnymi i pojawiają się tylko w edytorach, które je wyświetlają. Pokazy slajdów oraz eksporty do PDF, obrazów lub SVG ich nie zawierają.

## **Pokaż lub ukryj komentarze przy otwieraniu prezentacji**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) przechowuje preferencję, której zgodni edytorzy używają przy otwieraniu prezentacji. Dla istniejącej prezentacji z komentarzami ten przykład wyświetla bieżące ustawienie i zapisuje kopię z ukrytymi komentarzami. Wywołuje także [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) z [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView), aby kopia otworzyła się w widoku slajdu.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ukrywanie komentarzy zachowuje ich tekst, autorów, pozycje, odpowiedzi i statusy. Aby zmienić same komentarze, zobacz [Komentarze prezentacji](/slides/pl/php-java/presentation-comments/). Ustawienia eksportu kontrolują, czy komentarze pojawiają się w PDF, HTML, obrazach, notatkach lub materiałach rozdawniczych.

## **FAQ**

**Dlaczego siatka jest ukryta po ponownym otwarciu prezentacji?**

Prezentacja zapisuje interwał siatki. Aby zobaczyć siatkę, włącz widoczność siatki w edytorze.

**Czy usunięcie przewodników rysunkowych zmienia odstęp siatki?**

Nie. Dodanie, przesunięcie lub usunięcie przewodnika nie zmienia interwału siatki.

**Czy różne sekcje prezentacji mogą mieć różne ustawienia widoku?**

Nie. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) dotyczy całej prezentacji.

**Czy mogę zapisać różne ustawienia widoku dla różnych użytkowników?**

Plik przechowuje jeden zestaw właściwości widoku dla wszystkich. Edytor może również zastosować lokalne preferencje użytkownika.

**Czy mogę zapisać ustawienia widoku w szablonie?**

Tak. Prezentacje utworzone z szablonu dziedziczą zapisane ustawienia widoku.