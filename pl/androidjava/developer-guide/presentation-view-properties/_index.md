---
title: Pobierz i zaktualizuj właściwości widoku prezentacji na Androidzie
linktitle: Właściwości widoku
type: docs
weight: 80
url: /pl/androidjava/presentation-view-properties/
keywords:
- właściwości widoku
- normalny widok
- zawartość konspektu
- ikony konspektu
- przyciąganie pionowego rozdzielacza
- pojedynczy widok
- stan paska
- rozmiar wymiaru
- automatyczna regulacja
- domyślne powiększenie
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Odkryj właściwości widoku Aspose.Slides dla Androidu w Java, aby dostosować formaty slajdów PPT, PPTX i ODP - regulować układy, poziomy powiększenia i ustawienia wyświetlania."
---
## **Wprowadzenie**

Normalny widok składa się z trzech regionów zawartości: samego slajdu, bocznego regionu zawartości oraz dolnego regionu zawartości. Właściwości dotyczące pozycjonowania różnych regionów zawartości. Informacje te pozwalają aplikacji zapisać stan widoku do pliku, tak aby po ponownym otwarciu widok znajdował się w takim samym stanie, w jakim był zapisany przy ostatnim zapisie prezentacji.

Metoda [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) została dodana, aby umożliwić dostęp do właściwości normalnego widoku prezentacji. 

Interfejsy [INormalViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewRestoredProperties) oraz ich pochodne, enum [SplitterBarStateType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType) zostały dodane.

## **O INormalViewProperties**

Reprezentuje właściwości normalnego widoku.

Metody [getShowOutlineIcons](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) i [setShowOutlineIcons](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) określają, czy aplikacja powinna wyświetlać ikony przy wyświetlaniu treści konspektu w którymkolwiek z regionów zawartości trybu normalnego widoku.

Metody [getSnapVerticalSplitter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) i [setSnapVerticalSplitter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) określają, czy pionowy rozdzielacz powinien przełączyć się do stanu zminimalizowanego, gdy boczny region jest wystarczająco mały.

Właściwość [getPreferSingleView](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) i [setPreferSingleView](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) określają, czy użytkownik preferuje wyświetlanie jednej pełnoekranowej sekcji zawartości zamiast standardowego widoku normalnego z trzema regionami zawartości. Jeśli jest włączona, aplikacja może wyświetlić jeden z regionów zawartości w całym oknie.

Metody [getVerticalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) określają stan, w jakim ma być wyświetlany pionowy lub poziomy pasek rozdzielający. Poziomy pasek rozdzielający oddziela slajd od regionu zawartości pod slajdem, pionowy pasek rozdzielający oddziela slajd od bocznego regionu zawartości. Możliwe wartości to: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) i [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Metody [getRestoredLeft](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) i [getRestoredTop](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) określają rozmiar górnego lub bocznego regionu slajdu w normalnym widoku, gdy dla [getVerticalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) i [getHorizontalBarState](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) zastosowano wartość [SplitterBarStateType.Restored](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

## **O przywracaniu INormalViewProperties**

Określa rozmiar regionu slajdu (szerokość, gdy jest dzieckiem [getRestoredTop](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), wysokość, gdy jest dzieckiem [getRestoredLeft](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) w normalnym widoku, gdy region ma zmienny przywrócony rozmiar (niezminimalizowany ani niezmaksymalizowany). 

Metoda [getDimensionSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) określa rozmiar regionu slajdu (szerokość, gdy jest dzieckiem restoredTop, wysokość, gdy jest dzieckiem restoredLeft).

Metoda [getAutoAdjust](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) określa, czy rozmiar bocznego regionu zawartości powinien kompensować nowy rozmiar przy zmianie rozmiaru okna zawierającego widok w aplikacji.

Poniższy przykład pokazuje, jak można uzyskać dostęp do właściwości [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) w prezentacji.

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

Aspose.Slides for Android via Java obsługuje teraz ustawianie domyślnej wartości powiększenia prezentacji, tak aby po otwarciu prezentacji powiększenie było już ustawione. Można to zrobić, ustawiając [ViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties) prezentacji. [getSlideViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) oraz [getNotesViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) można ustawić programowo. W tym temacie pokażemy na przykładzie, jak ustawić [View Properties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties) prezentacji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) w [Aspose.Slides](/slides/pl/).

{{% /alert %}} 

Aby ustawić właściwości widoku, proszę wykonać poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Ustaw [View Properties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ViewProperties) prezentacji.
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

## **FAQ**

### Czy mogę ustawić różne ustawienia widoku dla różnych sekcji prezentacji?

[Ustawienia widoku](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getViewProperties--) są definiowane na poziomie prezentacji ([Normal View](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), a nie dla poszczególnych sekcji, więc jeden zestaw parametrów obowiązuje dla całego dokumentu po jego otwarciu.

### Czy mogę zdefiniować różne stany widoku dla różnych użytkowników?

Nie. Ustawienia są przechowywane w pliku i są współdzielone. Aplikacje przeglądające mogą honorować preferencje użytkownika, ale sam plik zawiera jeden zestaw właściwości widoku.

### Czy mogę przygotować szablon z wstępnie zdefiniowanymi właściwościami widoku, aby nowe prezentacje otwierały się w ten sam sposób?

Tak. Ponieważ [właściwości widoku](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getViewProperties--) są przechowywane na poziomie prezentacji, możesz osadzić je w szablonie i tworzyć z niego nowe dokumenty z taką samą początkową konfiguracją widoku.