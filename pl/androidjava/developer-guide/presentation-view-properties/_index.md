---
title: Pobieranie i aktualizacja właściwości widoku prezentacji na Androidzie
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/androidjava/presentation-view-properties/
keywords:
- właściwości widoku
- widok normalny
- zawartość konspektu
- ikony konspektu
- przyciąganie pionowego podziałnika
- widok pojedynczy
- stan paska
- rozmiar wymiaru
- automatyczne dostosowanie
- domyślne powiększenie
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Odkryj właściwości widoku Aspose.Slides dla Androida via Java, aby dostosować formaty slajdów PPT, PPTX i ODP — zmieniać układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Introduction**

Widok normalny składa się z trzech obszarów zawartości: samego slajdu, bocznego obszaru zawartości oraz dolnego obszaru zawartości. Właściwości dotyczące pozycjonowania poszczególnych obszarów zawartości. Informacje te umożliwiają aplikacji zapisanie stanu widoku do pliku, tak aby po ponownym otwarciu widok znajdował się w takim samym stanie, w jakim był ostatnio zapisany.

Dodano metodę [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) umożliwiającą dostęp do właściwości widoku normalnego prezentacji.

Dodano interfejsy [INormalViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewRestoredProperties) oraz ich pochodne, a także wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType) enum.

## **O INormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) określają, czy aplikacja ma wyświetlać ikony podczas wyświetlania zawartości konspektu w którymkolwiek z obszarów widoku normalnego.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) określają, czy pionowy podziałnik ma przełączać się do stanu zminimalizowanego, gdy boczny obszar jest wystarczająco mały.

Właściwość [getPreferSingleView](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) i [setPreferSingleView](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) określa, czy użytkownik woli widzieć jedną, pełnoekranową sekcję zawartości zamiast standardowego widoku normalnego z trzema obszarami zawartości. Jeśli włączone, aplikacja może wyświetlić jeden z obszarów w całym oknie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) określają stan, w jakim ma być wyświetlany odpowiednio pionowy lub poziomy pasek podziałnika. Poziomy pasek podziałnika oddziela slajd od obszaru zawartości pod slajdem, pionowy pasek podziałnika oddziela slajd od bocznego obszaru zawartości. Dostępne wartości to: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) oraz [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) i [getRestoredTop](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) określają rozmiar górnego lub bocznego obszaru slajdu w widoku normalnym, gdy dla [getVerticalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) zastosowano wartość [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

## **O przywracaniu INormalViewProperties**

Określa rozmiar obszaru slajdu (szerokość, gdy jest potomkiem [getRestoredTop](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), wysokość, gdy jest potomkiem [getRestoredLeft](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) w widoku normalnym, gdy obszar ma zmienny przywrócony rozmiar (ani zminimalizowany, ani zmaksymalizowany).

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) określa rozmiar obszaru slajdu (szerokość, gdy jest potomkiem restoredTop, wysokość, gdy jest potomkiem restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) określa, czy rozmiar bocznego obszaru zawartości ma się automatycznie dostosować do nowego rozmiaru przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniżej podano przykład, który pokazuje, jak uzyskać dostęp do właściwości [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) w prezentacji.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Przywróć właściwości widoku prezentacji
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```
## **Ustaw domyślną wartość powiększenia**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java obsługuje teraz ustawianie domyślnej wartości powiększenia prezentacji, tak aby po otwarciu prezentacji powiększenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties) prezentacji. [getSlideViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) mogą być ustawione programowo. W tym temacie pokażemy na przykładzie, jak ustawić [View Properties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties) prezentacji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) w Aspose.Slides.

{{% /alert %}} 

Aby ustawić właściwości widoku, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Ustaw [View Properties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties) prezentacji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).
   W poniższym przykładzie ustawiliśmy wartość powiększenia zarówno dla widoku slajdu, jak i widoku notatek.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Ustawianie właściwości widoku prezentacji
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Wartość powiększenia w procentach dla widoku slajdu
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Wartość powiększenia w procentach dla widoku notatek 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Ustaw odstępy siatki**

Użyj [Presentation.getViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getViewProperties--) aby uzyskać dostęp do ustawień widoku obowiązujących w całej prezentacji. Metody [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) i [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) odczytują lub zmieniają odstęp podstawowej siatki edycji. To ustawienie dotyczy całej prezentacji, a nie pojedynczego slajdu. Odstęp siatki podawany jest w punktach, gdzie 72 punkty to jeden cal. Użyj wartości dodatniej, zgodnie z dokumentacją API.

Poniższy przykład otwiera istniejący plik `demo.pptx`, wypisuje bieżący odstęp siatki, ustawia interwał ćwierćcala i zapisuje wynik.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Siatka różni się od [drawing guides](/slides/pl/androidjava/drawing-guides/). Odstęp siatki kontroluje regularny interwał, natomiast prowadnice rysunkowe to indywidualnie umieszczone linie wyrównania poziome lub pionowe. Dodawanie, przesuwanie lub usuwanie prowadnic rysunkowych nie zmienia odstępu siatki.

Zarówno siatka, jak i prowadnice rysunkowe są narzędziami pomocniczymi edycji. Nie są renderowane jako zawartość slajdu w plikach PDF, obrazach, SVG ani w pokazie slajdów. Przechowywanie odstępu siatki nie gwarantuje, że edytor wyświetli siatkę: jej widoczność zależy również od preferencji przeglądarki lub edytora.

## **FAQ**

**Dlaczego siatka nie jest widoczna po ponownym otwarciu prezentacji?**

Plik przechowuje informacje o odstępie siatki, ale to edytor decyduje, czy siatka jest wyświetlana. Sprawdź ustawienia widoczności siatki w edytorze.

**Czy usunięcie prowadnic rysunkowych zmienia odstęp siatki?**

Nie. Prowadnice rysunkowe i odstęp siatki to niezależne ustawienia. Usunięcie prowadnic nie zmienia zapisanego odstępu siatki.

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[View settings](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getViewProperties--) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), a nie dla poszczególnych sekcji, więc jeden zestaw parametrów obowiązuje dla całego dokumentu po jego otwarciu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą uwzględniać preferencje użytkownika, ale sam plik zawiera jedną zestaw właściwości widoku.

**Czy mogę przygotować szablon z zdefiniowanymi wcześniej właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [view properties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getViewProperties--) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z taką samą początkową konfiguracją widoku.