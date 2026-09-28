---
title: Tworzenie prezentacji na Androidzie
linktitle: Utwórz prezentację
type: docs
weight: 10
url: /pl/androidjava/create-presentation/
keywords:
- utwórz prezentację
- nowa prezentacja
- utwórz PPT
- nowy PPT
- utwórz PPTX
- nowy PPTX
- utwórz ODP
- nowy ODP
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Twórz prezentacje w języku Java przy użyciu Aspose.Slides dla Androida — twórz pliki PPT, PPTX i ODP, korzystaj z obsługi OpenDocument i zapisuj je programowo, aby uzyskać niezawodne rezultaty."
---
## **Overview**

Ten artykuł pokazuje, jak utworzyć prezentację w Aspose.Slides dla Androida przy użyciu Javy, dodać pole tekstowe do jej pierwszego slajdu i zapisać wynik jako plik w pamięci aplikacji. Aby otworzyć istniejącą prezentację lub zapisać ją w innym formacie, zobacz [Open Presentation](/slides/pl/androidjava/open-presentation/) i [Save Presentation](/slides/pl/androidjava/save-presentation/). Krótkie FAQ na końcu odpowiada na najczęstsze pytania dotyczące formatów, szablonów, rozmiaru slajdów, jednostek, użycia pamięci, wątków, licencjonowania, podpisów cyfrowych i obsługi VBA.

Zanim rozpoczniesz, dodaj Aspose.Slides do swojego projektu Android z repozytorium Maven Aspose. Zobacz [Installation](/slides/pl/androidjava/install-aspose-slides-for-android-via-java/).

## **Create a PowerPoint Presentation**

Aby utworzyć prezentację i umieścić pole tekstowe na jej pierwszym slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/). Nowa prezentacja już zawiera jeden pusty slajd.  
2. Uzyskaj ten slajd z [slide collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) według jego indeksu, 0.  
3. Dodaj prostokąt przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) z [shape collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) i ustaw tekst jego [text frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) metodą [setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-).  
4. Zapisz prezentację jako plik PPTX metodą [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) w formacie [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/).

Kod uruchamiany jest wewnątrz `Activity`, np. w jej metodzie `onCreate`. Zapisuje plik do katalogu zwracanego przez metodę [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) – prywatnej pamięci aplikacji, do której można zapisywać bez żądania żadnych uprawnień.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Górny lewy róg prostokąta znajduje się 50 punktów od lewej krawędzi i 50 punktów od górnej krawędzi slajdu, a prostokąt ma szerokość 400 punktów i wysokość 100 punktów. Zapisany plik zawiera jeden slajd z tym prostokątem i jego tekstem. Bez licencji Aspose.Slides również dodaje znak wodny oceny do każdego zapisanego slajdu; zobacz [Licensing](/slides/pl/androidjava/licensing/).

Aby obejrzeć plik, otwórz [Device Explorer] w Android Studio i znajdź *hello.pptx* w katalogu *data/data/*, w folderze *files* Twojej aplikacji. W rzeczywistej aplikacji przetwarzaj prezentacje w tle, aby interfejs użytkownika pozostał responsywny.

## **FAQ**

### What formats can I save a new presentation to?

Możesz zapisać do [PPTX, PPT i ODP](/slides/pl/androidjava/save-presentation/), a także wyeksportować do [PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/pl/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/pl/androidjava/convert-powerpoint-to-html/), [SVG](/slides/pl/androidjava/render-a-slide-as-an-svg-image/) i [images](/slides/pl/androidjava/convert-powerpoint-to-png/), między innymi.

### Can I start from a template (POTX/POTM) and save as a regular PPTX?

Tak. Załaduj szablon i zapisz w żądanym formacie; formaty POTX/POTM/PPTM i podobne [są obsługiwane](/slides/pl/androidjava/supported-file-formats/).

### How do I control slide size/aspect ratio when creating a presentation?

Ustaw [slide size](/slides/pl/androidjava/slide-size/) (w tym predefiniowane proporcje 4:3 i 16:9 lub własne wymiary) i wybierz sposób skalowania zawartości.

### In what units are sizes and coordinates measured?

W punktach: 1 cal to 72 jednostki.

### How do I handle very large presentations (with many media files) to reduce memory usage?

Użyj [BLOB management strategies](/slides/pl/androidjava/manage-blob/), ogranicz przechowywanie w pamięci, wykorzystując pliki tymczasowe, oraz preferuj przepływy oparte na plikach zamiast czystych strumieni w pamięci.

### Can I create/save presentations in parallel?

Nie możesz operować na tej samej instancji [Presentation] z [multiple threads](/slides/pl/androidjava/multithreading/). Uruchom osobne, izolowane instancje w każdym wątku lub procesie.

### How do I remove the trial watermark and limitations?

[Apply a license](/slides/pl/androidjava/licensing/) raz na proces. Plik XML licencji musi pozostać niezmieniony, a konfiguracja licencji powinna być synchronizowana, jeśli używane są wielowątkowe operacje.

### Can I digitally sign the PPTX I create?

Tak. [Digital signatures](/slides/pl/androidjava/digital-signature-in-powerpoint/) (dodawanie i weryfikacja) są wspierane dla prezentacji.

### Are macros (VBA) supported in created presentations?

Tak. Możesz [create/edit VBA projects](/slides/pl/androidjava/presentation-via-vba/) i zapisać pliki z włączonymi makrami, takie jak PPTM/PPSM.