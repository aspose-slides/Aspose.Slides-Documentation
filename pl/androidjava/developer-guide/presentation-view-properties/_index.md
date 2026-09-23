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
- przyciąganie pionowego podziału
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczna regulacja
- domyślne przybliżenie
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Odkryj właściwości widoku Aspose.Slides dla Androida przy użyciu Java, aby dostosować formaty slajdów PPT, PPTX i ODP — regulować układy, poziomy przybliżenia i ustawienia wyświetlania."
---
## **Wstęp**

Widok normalny składa się z trzech regionów zawartości: samego slajdu, bocznego regionu zawartości oraz dolnego regionu zawartości. Właściwości dotyczące rozmieszczenia poszczególnych regionów zawartości. Informacje te pozwalają aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok był w tym samym stanie, w jakim prezentacja była ostatnio zapisana.

Metoda [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) została dodana, aby zapewnić dostęp do właściwości widoku normalnego prezentacji.

Dodano interfejsy [INormalViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewRestoredProperties) oraz ich pochodne, a także wyliczenie [SplitterBarStateType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType).

## **O INormalViewProperties**

Reprezentuje właściwości widoku normalnego.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) określają, czy aplikacja powinna wyświetlać ikony przy wyświetlaniu zawartości konspektu w którymkolwiek z regionów zawartości trybu widoku normalnego.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) określają, czy pionowy dzielnik powinien przełączać się do stanu zminimalizowanego, gdy boczny region jest wystarczająco mały.

Właściwości [getPreferSingleView](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) i [setPreferSingleView](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) określają, czy użytkownik preferuje pełnoekranowy jednorodny region zawartości zamiast standardowego widoku normalnego z trzema regionami zawartości. Jeśli jest włączone, aplikacja może wyświetlić jeden z regionów zawartości na całym ekranie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) określają stan, w jakim powinien być wyświetlany odpowiednio pionowy lub poziomy pasek dzielnika. Poziomy pasek dzielnika oddziela slajd od regionu zawartości pod slajdem, pionowy pasek dzielnika oddziela slajd od bocznego regionu zawartości. Możliwe wartości to: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) oraz [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) i [getRestoredTop](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) określają rozmiar górnego lub bocznego regionu slajdu w widoku normalnym, gdy wartość [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Restored) jest zastosowana dla [getVerticalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) odpowiednio.

## **O przywracaniu INormalViewProperties**

Określa rozmiar regionu slajdu (szerokość, gdy jest potomkiem [getRestoredTop](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), wysokość, gdy jest potomkiem [getRestoredLeft](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) w widoku normalnym, gdy region ma zmienny rozmiar przywrócony (niezminimalizowany ani niezmaksymalizowany).

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) określa rozmiar regionu slajdu (szerokość, gdy jest potomkiem restoredTop, wysokość, gdy jest potomkiem restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) określa, czy rozmiar bocznego regionu zawartości powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniżej podany przykład pokazuje, jak uzyskać dostęp do właściwości [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) dla prezentacji.

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

## **Ustaw domyślną wartość przybliżenia**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java obsługuje teraz ustawianie domyślnej wartości przybliżenia dla prezentacji, tak aby po otwarciu prezentacji przybliżenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties) prezentacji. [getSlideViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) mogą być ustawione programowo. W tym temacie zobaczymy na przykładzie, jak ustawić [View Properties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) w Aspose.Slides.

{{% /alert %}} 

Aby ustawić właściwości widoku, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Ustaw [View Properties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   W poniższym przykładzie ustawiliśmy wartość przybliżenia dla widoku slajdu oraz widoku notatek.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Ustawianie właściwości widoku prezentacji
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Wartość przybliżenia w procentach dla widoku slajdu
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Wartość przybliżenia w procentach dla widoku notatek 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw odstęp siatki**

Użyj [Presentation.getViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getViewProperties--) aby uzyskać dostęp do ustawień widoku obowiązujących w całej prezentacji. Metody [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) i [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) odczytują lub zmieniają interwał podstawowej siatki edycji. To ustawienie obowiązuje całą prezentację, a nie pojedynczy slajd. Odstęp siatki jest podawany w punktach, gdzie 72 punkty równa się jednemu calowi. Używaj wartości dodatniej, zgodnie z dokumentacją API.

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

Siatka różni się od [drawing guides](/slides/pl/androidjava/drawing-guides/). Odstęp siatki kontroluje regularny interwał, podczas gdy prowadnice są indywidualnie rozmieszczonymi liniami wyrównania poziomymi lub pionowymi. Dodawanie, przenoszenie lub usuwanie prowadnic nie zmienia odstępu siatki.

Zarówno siatka, jak i prowadnice są pomocnikami edycji. Nie są renderowane jako zawartość slajdu w PDF, obrazach, SVG ani pokazie slajdów. Przechowywanie odstępu siatki nie gwarantuje, że edytor wyświetli siatkę: jej widoczność zależy również od ustawień widza lub edytora.

## **Pokaż lub ukryj komentarze przy otwieraniu prezentacji**

Użyj [Presentation.getViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getViewProperties--) aby uzyskać dostęp do ustawień widoku obowiązujących w całej prezentacji. Użyj [IViewProperties.getShowComments](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) i [IViewProperties.setShowComments](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) aby odczytać lub zmienić przechowywaną preferencję dotyczącą wyświetlania komentarzy przy otwieraniu prezentacji w PowerPoint lub innym kompatybilnym edytorze.

To nastawienie kontroluje jedynie przechowywaną preferencję widoku. Nie dodaje, nie usuwa, nie edytuje ani nie rozwiązuje komentarzy. Ukrywanie komentarzy zachowuje ich treść, autorów, pozycje, odpowiedzi i statusy. Zobacz [Presentation Comments](/slides/pl/androidjava/presentation-comments/) aby poznać operacje zmieniające same komentarze.

Poniższy przykład wymaga istniejącego pliku `comments.pptx` zawierającego komentarze. Wyświetla bieżące ustawienie widoczności, żąda ukrycia komentarzy i zapisuje nowy plik PPTX bez usuwania jakichkolwiek komentarzy. Używa również [IViewProperties.setLastView](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) wraz z [ViewType.SlideView](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewtype/#SlideView) aby skonfigurować początkowy widok edycji wraz z widocznością komentarzy.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

To ustawienie nie określa, czy komentarze są uwzględniane w eksportach do PDF, HTML, obrazów, notatek czy materiałów rozdawniczych. Konfiguruj odpowiednie opcje specyficzne dla eksportu osobno.

## **FAQ**

**Dlaczego siatka nie jest widoczna po ponownym otwarciu prezentacji?**

Plik przechowuje odstęp siatki, ale to edytor decyduje o tym, czy siatka jest wyświetlana. Sprawdź ustawienia widoczności siatki w edytorze.

**Czy usunięcie prowadnic zmienia odstęp siatki?**

Nie. Prowadnice i odstęp siatki to niezależne ustawienia. Usunięcie prowadnic pozostawia przechowywany interwał siatki niezmieniony.

**Czy mogę ustawić różne ustawienia widoku dla poszczególnych sekcji prezentacji?**

Ustawienia [View settings](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getViewProperties--) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), nie per sekcja, więc pojedynczy zestaw parametrów obowiązuje dla całego dokumentu po otwarciu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą uwzględniać preferencje użytkownika, ale sam plik zawiera jeden zestaw właściwości widoku.

**Czy mogę przygotować szablon z wstępnie określonymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [view properties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getViewProperties--) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z taką samą początkową konfiguracją widoku.