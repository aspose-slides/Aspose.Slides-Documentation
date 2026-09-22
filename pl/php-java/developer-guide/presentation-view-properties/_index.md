---
title: "Pobieranie i aktualizowanie właściwości widoku prezentacji w PHP"
linktitle: "Właściwości widoku"
type: docs
weight: 80
url: /pl/php-java/presentation-view-properties/
keywords:
- "właściwości widoku"
- "widok normalny"
- "zawartość konspektu"
- "ikony konspektu"
- "przyciąganie pionowego rozdzielacza"
- "widok pojedynczy"
- "stan belki"
- "rozmiar wymiaru"
- "automatyczne dopasowanie"
- "domyślne powiększenie"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "PHP"
- "Aspose.Slides"
description: "Odkryj właściwości widoku Aspose.Slides for PHP via Java, aby dostosować formaty slajdów PPT, PPTX i ODP — modyfikuj układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Introduction**

Widok normalny składa się z trzech regionów zawartości: samego slajdu, bocznego regionu zawartości i dolnego regionu zawartości. Właściwości dotyczące pozycjonowania poszczególnych regionów zawartości. Informacje te pozwalają aplikacji zapisać stan widoku w pliku, tak aby po ponownym otwarciu widok znajdował się w takim samym stanie, w jakim prezentacja została ostatnio zapisana.

Dodano metodę [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties/#getNormalViewProperties), aby umożliwić dostęp do właściwości widoku normalnego prezentacji.

Dodano klasy [NormalViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewRestoredProperties) oraz ich pochodne, a także wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SplitterBarStateType).

## **About INormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) określają, czy aplikacja powinna wyświetlać ikony przy wyświetlaniu zawartości konspektu w którymkolwiek z regionów zawartości w trybie widoku normalnego.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) określają, czy pionowy rozdzielacz powinien przejść w stan zminimalizowany, gdy boczny region jest wystarczająco mały.

Właściwość [getPreferSingleView](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) i [setPreferSingleView](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) określają, czy użytkownik woli widzieć pojedynczy region zawartości na pełnym oknie zamiast standardowego widoku normalnego z trzema regionami zawartości. Jeśli włączone, aplikacja może wyświetlić jeden z regionów zawartości w całym oknie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) określają stan, w którym powinna być wyświetlana pozioma lub pionowa belka rozdzielacza. Pozioma belka rozdzielacza oddziela slajd od regionu zawartości poniżej slajdu, pionowa belka rozdzielacza oddziela slajd od bocznego regionu zawartości. Możliwe wartości to: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SplitterBarStateType/#Maximized) oraz [SplitterBarStateType::Restored](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SplitterBarStateType/#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) i [getRestoredTop](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties#getRestoredTop) określają rozmiar górnego lub bocznego regionu slajdu w widoku normalnym, gdy wartość [SplitterBarStateType::Restored](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SplitterBarStateType/#Restored) jest zastosowana odpowiednio dla [getVerticalBarState](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState).

## **About Restoring INormalViewProperties**

Określa rozmiar regionu slajdu (szerokość, gdy jest potomkiem [getRestoredTop](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), wysokość, gdy jest potomkiem [getRestoredLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) w widoku normalnym, gdy region ma zmienny rozmiar przywrócony (nie zminimalizowany ani zmaksymalizowany).

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) określa rozmiar regionu slajdu (szerokość, gdy jest potomkiem restoredTop, wysokość, gdy jest potomkiem restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) określa, czy rozmiar bocznego regionu zawartości powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniżej podany jest przykład, który pokazuje, jak uzyskać dostęp do właściwości [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) dla prezentacji.

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

## **Set the Default Zoom Value**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java obsługuje teraz ustawianie domyślnego poziomu powiększenia dla prezentacji, tak aby po otwarciu prezentacji powiększenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties) prezentacji. [getSlideViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) mogą być ustawiane programowo. W tym temacie pokażemy na przykładzie, jak ustawić [View Properties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation) w Aspose.Slides.

{{% /alert %}} 

Aby ustawić właściwości widoku, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
1. Ustaw [View Properties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
1. Zapisz prezentację jako plik [PPTX ](https://docs.fileformat.com/presentation/pptx/). W podanym poniżej przykładzie ustawiliśmy wartość powiększenia zarówno dla widoku slajdu, jak i widoku notatek.

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

## **Set the Grid Spacing**

Użyj [Presentation::getViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getViewProperties), aby uzyskać dostęp do ustawień widoku obowiązujących w całej prezentacji. Metody [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/#getGridSpacing) i [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/#setGridSpacing) odczytują lub zmieniają interwał podstawowej siatki edycji. To ustawienie ma zastosowanie do całej prezentacji, a nie do pojedynczego slajdu. Odległość siatki jest podawana w punktach, gdzie 72 punkty to jeden cal. Użyj wartości dodatniej, zgodnie z wymaganiami dokumentacji API.

Poniższy przykład otwiera istniejący plik `demo.pptx`, wyświetla bieżącą odległość siatki, ustawia interwał jednej czwartej cala i zapisuje wynik.

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

Siatka różni się od [drawing guides](/slides/pl/php-java/drawing-guides/). Odległość siatki kontroluje regularny interwał, podczas gdy prowadnice rysunkowe są indywidualnie rozmieszczonymi liniami wyrównania poziomymi lub pionowymi. Dodawanie, przesuwanie lub usuwanie prowadnic rysunkowych nie zmienia odległości siatki.

Zarówno siatka, jak i prowadnice rysunkowe są pomocnikami edycji. Nie są renderowane jako zawartość slajdu w formatach PDF, obrazach, SVG ani podczas pokazu slajdów. Przechowywanie odległości siatki nie gwarantuje, że edytor wyświetli siatkę: jej widoczność zależy również od preferencji przeglądarki lub edytora.

## **FAQ**

**Dlaczego siatka nie jest widoczna po ponownym otwarciu prezentacji?**

Plik przechowuje odległość siatki, ale to edytor decyduje, czy siatka jest wyświetlana. Sprawdź ustawienia widoczności siatki w edytorze.

**Czy usunięcie prowadnic rysunkowych zmienia odległość siatki?**

Nie. Prowadnice rysunkowe i odległość siatki to niezależne ustawienia. Usunięcie prowadnic nie zmienia przechowywanego interwału siatki.

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[Ustawienia widoku](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/getviewproperties/) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pl/php-java/aspose.slides/viewproperties/getslideviewproperties/)), a nie na poziomie sekcji, więc pojedynczy zestaw parametrów obowiązuje dla całego dokumentu po jego otwarciu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą respektować preferencje użytkownika, ale sam plik zawiera jeden zestaw właściwości widoku.

**Czy mogę przygotować szablon z wstępnie zdefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [właściwości widoku](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/getviewproperties/) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z taką samą początkową konfiguracją widoku.