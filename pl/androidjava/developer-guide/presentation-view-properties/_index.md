---
title: "Pobieranie i aktualizacja właściwości widoku prezentacji na Androidzie"
linktitle: "Właściwości widoku"
type: docs
weight: 80
url: /pl/androidjava/presentation-view-properties/
keywords:
- "właściwości widoku"
- "normalny widok"
- "zawartość konspektu"
- "ikony konspektu"
- "przyciąganie pionowego podziału"
- "pojedynczy widok"
- "stan paska"
- "rozmiar wymiaru"
- "automatyczne dopasowanie"
- "domyślne powiększenie"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Odkryj właściwości widoku Aspose.Slides for Android via Java, aby dostosować formaty slajdów PPT, PPTX i ODP - regulować układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Normalny widok składa się z trzech regionów treści: samego slajdu, bocznego regionu treści oraz dolnego regionu treści. Właściwości dotyczące pozycjonowania różnych regionów treści. Informacje te pozwalają aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok znajdował się w takim samym stanie, w jakim został zapisany przy ostatnim zapisie prezentacji.

Metoda [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) została dodana w celu udostępnienia dostępu do właściwości normalnego widoku prezentacji.  

[INormalViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewRestoredProperties) interfejsy oraz ich potomkowie, a także enum [SplitterBarStateType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType) zostały dodane.

## **O INormalViewProperties**

Reprezentuje właściwości normalnego widoku.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) określają, czy aplikacja powinna wyświetlać ikony przy wyświetlaniu zawartości konspektu w dowolnym z regionów treści trybu normalnego widoku.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) określają, czy pionowy podziałka powinna przeskoczyć do stanu zminimalizowanego, gdy boczny region jest wystarczająco mały.

Właściwości [getPreferSingleView](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) i [setPreferSingleView](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) określają, czy użytkownik woli zobaczyć pełnoekranowy jednopodstawowy region treści zamiast standardowego normalnego widoku z trzema regionami treści. Jeśli włączone, aplikacja może wyświetlić jeden z regionów treści na całym oknie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) określają stan, w jakim powinna być wyświetlana pozioma lub pionowa podziałka. Pozioma podziałka oddziela slajd od regionu treści pod slajdem, pionowa podziałka oddziela slajd od bocznego regionu treści. Możliwe wartości to: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) oraz [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) i [getRestoredTop](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) określają rozmiar górnego lub bocznego regionu slajdu w normalnym widoku, gdy wartość [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Restored) jest zastosowana dla [getVerticalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) odpowiednio.

## **O przywracaniu INormalViewProperties**

Określa rozmiar regionu slajdu (szerokość, gdy jest dzieckiem [getRestoredTop](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), wysokość, gdy jest dzieckiem [getRestoredLeft](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) w normalnym widoku, gdy region ma zmienny przywrócony rozmiar (nie jest zminimalizowany ani zmaksymalizowany).  

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) określa rozmiar regionu slajdu (szerokość, gdy jest dzieckiem restoredTop, wysokość, gdy jest dzieckiem restoredLeft).  

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) określa, czy rozmiar bocznego regionu treści powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.  

Poniżej podany przykład pokazuje, jak uzyskać dostęp do właściwości [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) prezentacji.

```java
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

## **Ustaw domyślną wartość zoom**

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java obsługuje teraz ustawianie domyślnej wartości zoom dla prezentacji, tak aby po otwarciu prezentacji zoom był już ustawiony. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties) prezentacji. [getSlideViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) można ustawić programowo. W tym temacie zobaczymy na przykładzie, jak ustawić [View Properties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) w [Aspose.Slides](/slides/pl/).

{{% /alert %}} 

Aby ustawić właściwości widoku, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
2. Ustaw [View Properties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties) dla [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
3. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/). W poniższym przykładzie ustawiliśmy wartość zoom zarówno dla widoku slajdu, jak i widoku notatek.

```java
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

## **FAQ**

**Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?**

[View settings](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getViewProperties--) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), a nie dla poszczególnych sekcji, więc pojedynczy zestaw parametrów obowiązuje w całym dokumencie po jego otwarciu.

**Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?**

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą uwzględniać preferencje użytkownika, ale sam plik zawiera jeden zestaw właściwości widoku.

**Czy mogę przygotować szablon z wstępnie zdefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?**

Tak. Ponieważ [view properties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getViewProperties--) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z taką samą początkową konfiguracją widoku.