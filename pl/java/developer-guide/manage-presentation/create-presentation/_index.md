---
title: Tworzenie prezentacji w języku Java
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/java/create-presentation/
keywords:
- tworzenie prezentacji
- nowa prezentacja
- tworzenie PPT
- nowy PPT
- tworzenie PPTX
- nowy PPTX
- tworzenie ODP
- nowy ODP
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Twórz prezentacje w języku Java przy użyciu Aspose.Slides — twórz pliki PPT, PPTX i ODP, korzystaj ze wsparcia OpenDocument i zapisuj je programowo, aby uzyskać niezawodne wyniki."
---
## **Przegląd**

Ten artykuł pokazuje, jak utworzyć prezentację w Aspose.Slides, dodać kształt z tekstem do jej pierwszego slajdu i zapisać wynik jako plik PPTX. Aby otworzyć istniejącą prezentację i zapisać ją w innym formacie, zobacz [Otwieranie prezentacji](/slides/pl/java/open-presentation/) i [Zapisywanie prezentacji](/slides/pl/java/save-presentation/). Krótkie FAQ na końcu obejmuje typowe pytania dotyczące formatów, szablonów, rozmiaru slajdów, jednostek, zużycia pamięci, wielowątkowości, licencjonowania, podpisów cyfrowych i obsługi VBA.

Zanim rozpoczniesz, dodaj Aspose.Slides for Java do swojego projektu z repozytorium Maven firmy Aspose. Zobacz [Instalacja](/slides/pl/java/installation/) dla konfiguracji Maven i dodatkowych wymagań systemu Linux.

## **Utworzenie prezentacji**

Tworzenie pliku PowerPoint od podstaw w Aspose.Slides for Java rozpoczyna się od instancji klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/). Konstruktor dostarcza pustą prezentację z jednym slajdem, gotową do dodania kształtów, tekstu, wykresów lub innej treści, której potrzebuje Twoja aplikacja. Po zmodyfikowaniu tego slajdu lub dodaniu nowych, możesz zapisać wynik w formatach PPTX, starszym PPT lub OpenDocument.

Aby utworzyć prezentację i umieścić na jej pierwszym slajdzie kształt z tekstem, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/). Nowa prezentacja już zawiera jeden pusty slajd.  
2. Pobierz ten slajd po jego indeksie 0 z kolekcji zwracanej przez [getSlides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#getSlides--).  
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) typu `Cloud` przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) i ustaw jego tekst za pomocą [setText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#setText-java.lang.String-).  
4. Zapisz prezentację jako plik PPTX przy użyciu metody [save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-).

Poniższy przykład jest kompletnym programem. W projekcie Maven z [Instalacja](/slides/pl/java/installation/), zapisz go jako *src/main/java/HelloSlides.java* i uruchom `mvn compile exec:java`.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Utwórz prezentację. Zawiera już jeden pusty slajd.
        Presentation presentation = new Presentation();
        try {
            // Pobierz pierwszy slajd.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Dodaj kształt chmury i umieść w nim tekst.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Zapisz prezentację jako plik PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Górny lewy róg chmury znajduje się 20 punktów od lewej krawędzi i 20 punktów od górnej krawędzi slajdu, a kształt ma szerokość 200 punktów i wysokość 80 punktów. Program zapisuje *new_presentation.pptx* z jednym slajdem zawierającym chmurę i jej tekst. Bez licencji Aspose.Slides dodaje także znak wodny oceny do każdego zapisanego slajdu; zobacz [Licencjonowanie](/slides/pl/java/licensing/).

Wynik:

![Nowa prezentacja](new_presentation.png)

## **FAQ**

### Jakie formaty mogę zapisać nową prezentację?

Możesz zapisać w formatach [PPTX, PPT i ODP](/slides/pl/java/save-presentation/), oraz wyeksportować do [PDF](/slides/pl/java/convert-powerpoint-to-pdf/), [XPS](/slides/pl/java/convert-powerpoint-to-xps/), [HTML](/slides/pl/java/convert-powerpoint-to-html/), [SVG](/slides/pl/java/render-a-slide-as-an-svg-image/), i [images](/slides/pl/java/convert-powerpoint-to-png/), między innymi.

### Czy mogę rozpocząć od szablonu (POTX/POTM) i zapisać jako zwykły PPTX?

Tak. Załaduj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/java/supported-file-formats/).

### Jak kontrolować rozmiar i proporcje slajdu podczas tworzenia prezentacji?

Ustaw [rozmiar slajdu](/slides/pl/java/slide-size/) (w tym predefiniowane 4:3 i 16:9 lub własne wymiary) i wybierz, jak treść ma być skalowana.

### W jakich jednostkach mierzone są rozmiary i współrzędne?

W punktach: 1 cal to 72 jednostki.

### Jak obsługiwać bardzo duże prezentacje (z wieloma plikami multimedialnymi), aby zmniejszyć zużycie pamięci?

Użyj [BLOB management strategies](/slides/pl/java/manage-blob/), ogranicz przechowywanie w pamięci, wykorzystując pliki tymczasowe, i preferuj przepływy pracy oparte na plikach zamiast wyłącznie strumieni w pamięci.

### Czy mogę tworzyć/zapisywać prezentacje równolegle?

Nie możesz operować na tej samej [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) z [wieloma wątkami](/slides/pl/java/multithreading/). Uruchom oddzielne, izolowane instancje na każdy wątek lub proces.

### Jak usunąć znak wodny trial i ograniczenia?

[Zastosuj licencję](/slides/pl/java/licensing/) raz na proces. Plik XML licencji musi pozostać niezmieniony, a konfiguracja licencji powinna być synchronizowana, jeśli zaangażowane są wielokrotne wątki.

### Czy mogę cyfrowo podpisać tworzoną przeze mnie PPTX?

Tak. [Podpisy cyfrowe](/slides/pl/java/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są obsługiwane w prezentacjach.

### Czy makra (VBA) są obsługiwane w tworzonych prezentacjach?

Tak. Możesz [tworzyć/edytować projekty VBA](/slides/pl/java/presentation-via-vba/) i zapisać pliki z włączonymi makrami, takie jak PPTM/PPSM.