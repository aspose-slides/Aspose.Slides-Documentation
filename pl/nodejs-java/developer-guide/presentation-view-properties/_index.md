---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w JavaScript
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/nodejs-java/presentation-view-properties/
keywords:
- właściwości widoku
- widok normalny
- zawartość konspektu
- ikony konspektu
- przyciąganie pionowego podziałnika
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczna regulacja
- domyślne przybliżenie
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Odkryj Aspose.Slides for Node.js via Java, aby dostosować właściwości widoku w formatach PPT, PPTX i ODP – regulując układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Widok normalny składa się z trzech obszarów zawartości: samego slajdu, bocznego obszaru zawartości oraz dolnego obszaru zawartości. Właściwości dotyczące pozycjonowania różnych obszarów zawartości. Informacje te pozwalają aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok był w takim samym stanie, w jakim prezentacja była ostatnio zapisana.

Dodano metodę [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) umożliwiającą dostęp do właściwości widoku normalnego prezentacji.  

Dodano klasy [NormalViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewRestoredProperties) oraz ich pochodne, a także wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SplitterBarStateType).

## **O NormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) określają, czy aplikacja powinna wyświetlać ikony przy wyświetlaniu treści konspektu w którymkolwiek z obszarów zawartości trybu widoku normalnego.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) określają, czy pionowy podziałnik powinien przełączać się do stanu zminimalizowanego, gdy boczny obszar jest wystarczająco mały.

Właściwość [getPreferSingleView](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) oraz [setPreferSingleView](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) określają, czy użytkownik preferuje wyświetlanie pojedynczego obszaru zawartości na pełnym oknie zamiast standardowego widoku normalnego z trzema obszarami. Jeśli włączone, aplikacja może wyświetlić jeden z obszarów w całym oknie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) określają stan, w jakim powinien być wyświetlany poziomy lub pionowy podziałnik. Poziomy podziałnik oddziela slajd od obszaru zawartości poniżej slajdu, pionowy podziałnik oddziela slajd od bocznego obszaru zawartości. Dostępne wartości to: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) oraz [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) i [getRestoredTop](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) określają rozmiar górnego lub bocznego obszaru slajdu w widoku normalnym, gdy zastosowano wartość [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SplitterBarStateType#Restored) dla [getVerticalBarState](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) odpowiednio.

## **O przywracaniu NormalViewProperties**

Określa rozmiar obszaru slajdu (szerokość, gdy jest elementem potomnym [getRestoredTop](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), wysokość, gdy jest elementem potomnym [getRestoredLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) w widoku normalnym, gdy obszar ma zmienny rozmiar przywrócony (niezminimalizowany ani niezmaksymalizowany).  

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) określa rozmiar obszaru slajdu (szerokość, gdy jest elementem potomnym restoredTop, wysokość, gdy jest elementem potomnym restoredLeft).  

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) określa, czy rozmiar bocznego obszaru zawartości powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.  

Poniżej podany przykład pokazuje, jak uzyskać dostęp do właściwości [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) prezentacji.

```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Przywróć właściwości widoku prezentacji
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ustaw wartość domyślnego przybliżenia**

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java obsługuje teraz ustawianie domyślnej wartości przybliżenia dla prezentacji, tak aby po otwarciu prezentacji przybliżenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties) prezentacji. [getSlideViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) mogą być ustawione programowo. W tym artykule pokażemy na przykładzie, jak ustawić [View Properties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) w [Aspose.Slides](/slides/pl/).

{{% /alert %}} 

Aby ustawić właściwości widoku, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
1. Ustaw [View Properties](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
1. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).
   W poniższym przykładzie ustawiliśmy wartość przybliżenia zarówno dla widoku slajdu, jak i widoku notatek.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Ustawianie właściwości widoku prezentacji
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Wartość powiększenia w procentach dla widoku slajdu
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Wartość powiększenia w procentach dla widoku notatek
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[Ustawienia widoku](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getviewproperties/) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), a nie dla poszczególnych sekcji, więc pojedynczy zestaw parametrów ma zastosowanie do całego dokumentu po jego otwarciu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą respektować preferencje użytkownika, ale sam plik zawiera jeden zestaw właściwości widoku.

**Czy mogę przygotować szablon z predefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [właściwości widoku](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getviewproperties/) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z taką samą początkową konfiguracją widoku.