---
title: Pobierz i zaktualizuj właściwości widoku prezentacji w PHP
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/php-java/presentation-view-properties/
keywords:
- właściwości widoku
- widok normalny
- zawartość konspektu
- ikony konspektu
- automatyczne dopasowanie pionowego podziałnika
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczna regulacja
- domyślne powiększenie
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Poznaj właściwości widoku Aspose.Slides for PHP via Java, aby dostosować formaty slajdów PPT, PPTX i ODP — regulować układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Wstęp**

Widok normalny składa się z trzech regionów zawartości: samego slajdu, bocznego regionu zawartości oraz dolnego regionu zawartości. Właściwości dotyczące pozycjonowania różnych regionów zawartości. Ta informacja pozwala aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok był w tym samym stanie, w jakim prezentacja została ostatnio zapisana.

Dodano metodę [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) umożliwiającą dostęp do właściwości widoku normalnego prezentacji. 

Dodano klasy [NormalViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewRestoredProperties), ich pochodne oraz enum [SplitterBarStateType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SplitterBarStateType) enum have been added.

## **O INormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) określają, czy aplikacja powinna wyświetlać ikony przy wyświetlaniu treści konspektu w którymkolwiek z regionów zawartości trybu widoku normalnego.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) określają, czy pionowy podziałnik powinien przeskoczyć do stanu zminimalizowanego, gdy boczny region jest wystarczająco mały.

Właściwości [getPreferSingleView](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) i [setPreferSingleView](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) określają, czy użytkownik woli widzieć pojedynczy region zawartości na pełnym ekranie zamiast standardowego widoku normalnego z trzema regionami zawartości. Jeśli jest włączone, aplikacja może wyświetlić jeden z regionów zawartości w całym oknie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) określają stan, w jakim ma być wyświetlany pasek podziału poziomego lub pionowego. Pasek podziału poziomego oddziela slajd od regionu zawartości poniżej slajdu, pasek podziału pionowego oddziela slajd od bocznego regionu zawartości. Możliwe wartości to: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SplitterBarStateType/#Maximized) oraz [SplitterBarStateType::Restored](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SplitterBarStateType/#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) i [getRestoredTop](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties#getRestoredTop) określają wymiary górnego lub bocznego regionu slajdu w widoku normalnym, gdy wartość [SplitterBarStateType::Restored](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SplitterBarStateType/#Restored) jest zastosowana dla [getVerticalBarState](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) odpowiednio.

## **O przywracaniu INormalViewProperties**

Określa wymiary regionu slajdu (szerokość, gdy jest potomkiem [getRestoredTop](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), wysokość, gdy jest potomkiem [getRestoredLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) w widoku normalnym, gdy region ma zmienny przywrócony rozmiar (niezminimalizowany ani niezmaksymalizowany). 

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) określa rozmiar regionu slajdu (szerokość, gdy jest potomkiem restoredTop, wysokość, gdy jest potomkiem restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) określa, czy rozmiar bocznego regionu zawartości powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji

Poniżej podany jest przykład pokazujący, jak uzyskać dostęp do właściwości [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) prezentacji.

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
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java obsługuje teraz ustawianie domyślnej wartości powiększenia prezentacji, tak aby przy otwarciu prezentacji powiększenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties) prezentacji. [getSlideViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) mogą być ustawione programowo. W tym temacie pokażemy na przykładzie, jak ustawić [View Properties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation) w [Aspose.Slides](/slides/pl/).

{{% /alert %}} 

Aby ustawić właściwości widoku, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
1. Ustaw [View Properties](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
1. Zapisz prezentację jako plik [PPTX ](https://docs.fileformat.com/presentation/pptx/)file. W poniższym przykładzie ustawiono wartość powiększenia dla widoku slajdu oraz widoku notatek.

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

## **FAQ**

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

Ustawienia widoku są definiowane na poziomie prezentacji (Normal View/Slide View), a nie dla poszczególnych sekcji, więc pojedynczy zestaw parametrów ma zastosowanie do całego dokumentu po jego otwarciu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą uwzględniać preferencje użytkownika, ale sam plik zawiera jeden zestaw właściwości widoku.

**Czy mogę przygotować szablon z wstępnie zdefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ właściwości widoku są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z taką samą początkową konfiguracją widoku.