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
- przyciąganie pionowego podziałnika
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
description: "Odkryj właściwości widoku Aspose.Slides dla PHP via Java, aby dostosować formaty slajdów PPT, PPTX i ODP — modyfikuj układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Normalny widok składa się z trzech regionów zawartości: samego slajdu, bocznego regionu zawartości oraz dolnego regionu zawartości. Właściwości dotyczące pozycjonowania różnych regionów zawartości. Ta informacja pozwala aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok był w takim samym stanie, w jakim prezentacja była ostatnio zapisana.

Dodano metodę [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) umożliwiającą dostęp do właściwości normalnego widoku prezentacji. 

Dodano klasy [NormalViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewRestoredProperties) oraz ich pochodne, a także wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SplitterBarStateType) enum have been added.

## **O INormalViewProperties**

Reprezentuje właściwości normalnego widoku.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) określają, czy aplikacja powinna wyświetlać ikony podczas wyświetlania treści konspektu w którymkolwiek z regionów zawartości trybu normalnego widoku.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) określają, czy pionowy podziałnik powinien przełączać się w stan zminimalizowany, gdy boczny region jest wystarczająco mały.

Właściwość [getPreferSingleView](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) i [setPreferSingleView](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) określa, czy użytkownik preferuje widok jednoregionowy na pełnym oknie zamiast standardowego normalnego widoku z trzema regionami zawartości. Jeśli jest włączona, aplikacja może wyświetlić jeden z regionów zawartości na całym oknie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) określają stan, w jakim ma być wyświetlany odpowiednio pionowy lub poziomy pasek podziałnika. Poziomy pasek podziałnika oddziela slajd od regionu zawartości pod slajdem, pionowy pasek podziałnika oddziela slajd od bocznego regionu zawartości. Możliwe wartości to: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SplitterBarStateType/#Maximized) oraz [SplitterBarStateType::Restored](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SplitterBarStateType/#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) i [getRestoredTop](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties#getRestoredTop) określają rozmiar górnego lub bocznego regionu slajdu w normalnym widoku, gdy wartość [SplitterBarStateType::Restored](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SplitterBarStateType/#Restored) jest zastosowana dla [getVerticalBarState](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) odpowiednio.

## **O przywracaniu INormalViewProperties**

Określa rozmiar regionu slajdu (szerokość gdy jest potomkiem [getRestoredTop](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), wysokość gdy jest potomkiem [getRestoredLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) w normalnym widoku, gdy region ma zmienny rozmiar przywrócony (niezminimalizowany ani niezmaksymalizowany). 

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) określa rozmiar regionu slajdu (szerokość gdy jest potomkiem restoredTop, wysokość gdy jest potomkiem restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) określa, czy rozmiar bocznego regionu zawartości powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniżej podano przykład, który pokazuje, jak uzyskać dostęp do właściwości [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) dla prezentacji.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Przywróć właściwości widoku prezentacji
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Ustaw domyślną wartość powiększenia**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java obsługuje teraz ustawianie domyślnej wartości powiększenia prezentacji, tak aby po otwarciu prezentacji powiększenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties) prezentacji. [getSlideViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) mogą być ustawione programowo. W tym temacie zobaczymy na przykładzie, jak ustawić [View Properties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation) w Aspose.Slides.

{{% /alert %}} 

Aby ustawić właściwości widoku, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
1. Ustaw [View Properties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
1. Zapisz prezentację jako plik [PPTX ](https://docs.fileformat.com/presentation/pptx/)file. W poniższym przykładzie ustawiliśmy wartość powiększenia zarówno dla widoku slajdu, jak i widoku notatek.

```php
  $presentation = new Presentation();
  try {
    # Ustawianie właściwości widoku prezentacji
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Wartość powiększenia w procentach dla widoku slajdu
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Wartość powiększenia w procentach dla widoku notatek

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Ustaw odstęp siatki**

Użyj [Presentation::getViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getViewProperties), aby uzyskać dostęp do ustawień widoku obejmujących całą prezentację. Metody [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/#getGridSpacing) i [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/#setGridSpacing) odczytują lub zmieniają odstęp podstawowej siatki edycji. To ustawienie dotyczy całej prezentacji, a nie pojedynczego slajdu. Odstęp siatki podawany jest w punktach, gdzie 72 punkty równa się jednemu calowi. Użyj wartości dodatniej, zgodnie z dokumentacją API.

Poniższy przykład otwiera istniejący plik `demo.pptx`, wyświetla bieżący odstęp siatki, ustawia interwał ćwierć cala i zapisuje wynik.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Siatka różni się od [drawing guides](/slides/pl/php-java/drawing-guides/). Odstęp siatki kontroluje regularny interwał, podczas gdy prowadnice rysunkowe są indywidualnie pozycjonowanymi poziomymi lub pionowymi liniami wyrównania. Dodawanie, przesuwanie lub usuwanie prowadnic rysunkowych nie zmienia odstępu siatki.

Zarówno siatka, jak i prowadnice rysunkowe są pomocnikami edycji. Nie są renderowane jako zawartość slajdu w PDF, obrazach, SVG ani w pokazie slajdów. Przechowywanie odstępu siatki nie gwarantuje, że edytor wyświetli siatkę: jej widoczność zależy również od preferencji przeglądarki lub edytora.

## **Pokaż lub ukryj komentarze przy otwieraniu prezentacji**

Użyj [Presentation::getViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/getviewproperties/) aby uzyskać dostęp do ustawień widoku obejmujących całą prezentację. Użyj [ViewProperties::getShowComments](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/getshowcomments/) i [ViewProperties::setShowComments](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/setshowcomments/) aby odczytać lub zmienić zapisaną preferencję dotyczącą wyświetlania komentarzy podczas otwierania prezentacji w PowerPoint lub innym zgodnym edytorze.

To ustawienie kontroluje tylko zapisaną preferencję widoku. Nie dodaje, nie usuwa, nie edytuje ani nie rozwiązuje komentarzy. Ukrywanie komentarzy zachowuje ich treść, autorów, pozycje, odpowiedzi i stany. Zobacz [Presentation Comments](/slides/pl/php-java/presentation-comments/) po operacje zmieniające same komentarze.

Poniższy przykład wymaga istniejącego pliku `comments.pptx` zawierającego komentarze. Wyświetla bieżące ustawienie widoczności, żąda ukrycia komentarzy i zapisuje nowy plik PPTX bez usuwania żadnych komentarzy. Używa także [ViewProperties::setLastView](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/setlastview/) wraz z [ViewType::SlideView](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewtype/#SlideView), aby skonfigurować początkowy widok edycji wraz z widocznością komentarzy.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

To ustawienie nie określa, czy komentarze są uwzględniane w eksportach do PDF, HTML, obrazów, notatek ani materiałów rozdawniczych. Konfiguruj odpowiednie opcje specyficzne dla eksportu osobno.

## **FAQ**

**Dlaczego siatka nie jest widoczna po ponownym otwarciu prezentacji?**

Plik przechowuje odstęp siatki, ale to edytor decyduje, czy siatka jest wyświetlana. Sprawdź ustawienia widoczności siatki w edytorze.

**Czy usunięcie prowadnic rysunkowych zmienia odstęp siatki?**

Nie. Prowadnice rysunkowe i odstęp siatki są niezależnymi ustawieniami. Usunięcie prowadnic nie zmienia zapisanego interwału siatki.

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[Ustawienia widoku](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/getviewproperties/) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/getslideviewproperties/)), a nie dla poszczególnych sekcji, więc jeden zestaw parametrów obowiązuje dla całego dokumentu po jego otwarciu.

**Czy mogę predefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą respektować preferencje użytkownika, ale sam plik zawiera jedną zestaw właściwości widoku.

**Czy mogę przygotować szablon z predefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [właściwości widoku](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/getviewproperties/) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z taką samą początkową konfiguracją widoku.