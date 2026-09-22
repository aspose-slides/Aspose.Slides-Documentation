---
title: Pobieranie i aktualizacja właściwości widoku prezentacji w Javie
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/java/presentation-view-properties/
keywords: 
- właściwości widoku
- normalny widok
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
- Java
- Aspose.Slides
description: "Odkryj właściwości widoku Aspose.Slides dla Javy, aby dostosować formaty slajdów PPT, PPTX i ODP — zmień układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Normalny widok składa się z trzech obszarów zawartości: samego slajdu, bocznego regionu zawartości oraz dolnego regionu zawartości. Właściwości dotyczące pozycjonowania różnych regionów zawartości. Informacje te pozwalają aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok znajdował się w tym samym stanie, w jakim prezentacja została ostatnio zapisana.

Metoda [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) została dodana w celu udostępnienia właściwości normalnego widoku prezentacji.

Interfejsy [INormalViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewRestoredProperties) oraz ich pochodne, enum [SplitterBarStateType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SplitterBarStateType) zostały dodane.

## **O INormalViewProperties**

Reprezentuje właściwości normalnego widoku.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) określają, czy aplikacja powinna wyświetlać ikony przy wyświetlaniu zawartości konspektu w którymkolwiek z regionów zawartości trybu normalnego widoku.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) określają, czy pionowy podział powinien przełączać się do stanu zminimalizowanego, gdy boczny region jest wystarczająco mały.

Właściwość [getPreferSingleView](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) i [setPreferSingleView](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) określają, czy użytkownik woli pełnookienny pojedynczy region zawartości zamiast standardowego widoku normalnego z trzema regionami zawartości. Jeśli włączone, aplikacja może wyświetlić jeden z regionów zawartości w całym oknie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) określają stan, w jakim powinna być wyświetlana pozioma lub pionowa belka podziału. Pozioma belka podziału oddziela slajd od regionu zawartości pod slajdem, pionowa belka podziału oddziela slajd od bocznego regionu zawartości. Możliwe wartości to: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SplitterBarStateType#Maximized) i [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) i [getRestoredTop](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) określają rozmiar górnego lub bocznego regionu slajdu w normalnym widoku, gdy zastosowano wartość [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SplitterBarStateType#Restored) dla [getVerticalBarState](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) odpowiednio.

## **O przywracaniu INormalViewProperties**

Określa rozmiar regionu slajdu (szerokość, gdy jest elementem [getRestoredTop](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), wysokość, gdy jest elementem [getRestoredLeft](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) w normalnym widoku, gdy region ma zmienny przywrócony rozmiar (ani zminimalizowany, ani zmaksymalizowany).

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) określa rozmiar regionu slajdu (szerokość, gdy jest elementem restoredTop, wysokość, gdy jest elementem restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) określa, czy rozmiar bocznego regionu zawartości powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniższy przykład pokazuje, jak uzyskać dostęp do właściwości [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) dla prezentacji.

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

Aspose.Slides for Java teraz obsługuje ustawianie domyślnej wartości powiększenia prezentacji, tak aby po jej otwarciu powiększenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties) prezentacji. Metody [getSlideViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) mogą być ustawione programowo. W tym artykule zobaczymy na przykładzie, jak ustawić [View Properties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties) [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation) w Aspose.Slides.

{{% /alert %}} 

Aby ustawić właściwości widoku, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
1. Ustaw [View Properties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
1. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   W podanym poniżej przykładzie ustawiliśmy wartość powiększenia zarówno dla widoku slajdu, jak i widoku notatek.

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

Użyj [Presentation.getViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getViewProperties--) aby uzyskać dostęp do ustawień widoku obowiązujących w całej prezentacji. Metody [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iviewproperties/#getGridSpacing--) i [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) odczytują lub zmieniają interwał podstawowej siatki edycji. To ustawienie dotyczy całej prezentacji, a nie pojedynczego slajdu. Odstępy siatki podawane są w punktach, gdzie 72 punkty to jeden cal. Użyj wartości dodatniej, zgodnie z dokumentacją API.

Poniższy przykład otwiera istniejący plik `demo.pptx`, wyświetla bieżący odstęp siatki, ustawia interwał ćwierć cala i zapisuje wynik.

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

Siatka różni się od [drawing guides](/slides/pl/java/drawing-guides/). Odstęp siatki kontroluje regularny interwał, podczas gdy prowadnice są indywidualnie pozycjonowanymi liniami wyrównania poziomego lub pionowego. Dodawanie, przesuwanie lub usuwanie prowadnic nie zmienia odstępu siatki.

Zarówno siatka, jak i prowadnice są narzędziami pomocniczymi edycji. Nie są renderowane jako zawartość slajdu w PDF, obrazach, SVG ani podczas pokazu slajdów. Przechowywanie odstępu siatki nie gwarantuje, że edytor wyświetli siatkę: jej widoczność zależy także od preferencji przeglądarki lub edytora.

## **FAQ**

**Dlaczego siatka nie jest widoczna po ponownym otwarciu prezentacji?**

Plik przechowuje odstęp siatki, ale to edytor decyduje, czy siatka jest wyświetlana. Sprawdź ustawienia widoczności siatki w edytorze.

**Czy usunięcie prowadnic zmienia odstęp siatki?**

Nie. Prowadnice i odstęp siatki to niezależne ustawienia. Usunięcie prowadnic nie zmienia zapisanego interwału siatki.

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[Ustawienia widoku](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getViewProperties--) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nie per sekcja, więc jeden zestaw parametrów obowiązuje dla całego dokumentu przy otwarciu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą respektować preferencje użytkownika, ale sam plik zawiera jeden zestaw właściwości widoku.

**Czy mogę przygotować szablon z predefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [właściwości widoku](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getViewProperties--) są przechowywane na poziomie prezentacji, możesz je osadzić w szablonie i tworzyć z niego nowe dokumenty z taką samą początkową konfiguracją widoku.