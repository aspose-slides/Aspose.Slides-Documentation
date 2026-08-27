---
title: Konwertuj prezentacje PowerPoint na Markdown na Androidzie
linktitle: PowerPoint na Markdown
type: docs
weight: 140
url: /pl/androidjava/convert-powerpoint-to-markdown/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint na MD
- prezentacja na MD
- slajd na MD
- PPT na MD
- PPTX na MD
- zapisz PowerPoint jako Markdown
- zapisz prezentację jako Markdown
- zapisz slajd jako Markdown
- zapisz PPT jako MD
- zapisz PPTX jako MD
- eksportuj PPT do MD
- eksportuj PPTX do MD
- eksport obrazów Markdown
- linki do obrazów CDN
- PowerPoint
- prezentacja
- Markdown
- Android
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PPT i PPTX na Markdown na Androidzie przy użyciu Javy oraz kontroluj, gdzie zapisywane są i odwoływane wyeksportowane obrazy bitmapowe, metafile i SVG."
---
## **Przegląd**

Aspose.Slides for Android via Java może konwertować prezentacje PPT i PPTX na Markdown w celu dokumentacji, witryn statycznych, migracji treści i przepływów pracy z kontrolą wersji. Możesz wybrać odmianę Markdown, kontrolować sposób renderowania zawartości slajdów oraz zdecydować, gdzie przechowywane są wyeksportowane obrazy i jak generowany Markdown odwołuje się do nich.

Domyślnie eksport Markdown używa wyjścia tylko tekstowego. Aby wyeksportować treść wizualną, ustaw typ eksportu metodą [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownsaveoptions/) na wartość `Sequential` lub `Visual` z wyliczenia [MarkdownExportType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownexporttype/). `Sequential` renderuje elementy slajdów osobno i w kolejności, podczas gdy `Visual` utrzymuje grupowane elementy razem, aby zachować ich relację wizualną. Wartość `TextOnly` nie generuje zasobów obrazów, więc wywołania zwrotne zapisywania obrazów nie są wywoływane w tym trybie.

## **Konwertuj prezentację na Markdown**

Wczytaj plik źródłowy przy pomocy klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), a następnie wywołaj metodę [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) z wartością `Md` z wyliczenia [SaveFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveformat/).

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Wybierz odmianę Markdown**

Metoda [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownsaveoptions/) kontroluje specyfikację Markdown używaną w wyjściu. Wyliczenie [Flavor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/flavor/) zawiera CommonMark, GitHub Flavored Markdown i inne obsługiwane warianty.

Poniższy przykład eksportuje prezentację jako CommonMark:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Eksportuj obrazy używając domyślnego zachowania zapisywania lokalnego**

Klasa [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownsaveoptions/) udostępnia dwie metody konfigurowania lokalnie zapisywanych obrazów:

- [setBasePath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownsaveoptions/) określa katalog podstawowy dla dokumentu Markdown oraz jego zasobów.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownsaveoptions/) określa podkatalog obrazów. Jego domyślną wartością jest `Images`.

Poniższy przykład renderuje treść wizualną, zapisuje obrazy do `output/assets` i tworzy względne odwołania do obrazów w dokumencie Markdown:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

To zachowanie służy również jako awaryjne rozwiązanie, gdy niestandardowy obsługujący zapis obrazów zwraca `false`.

## **Dostosuj zapisywanie obrazów i linki Markdown**

Użyj metody [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownsaveoptions/) aby zarejestrować wywołanie zwrotne dla zasobów bitmap i metafili nie będących SVG emitowanych podczas eksportu Markdown. Jej wywołanie zwrotne `MarkdownImageSavingHandler` otrzymuje obiekt [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/), jego wartość [ImageFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imageformat/) oraz wygenerowany link Markdown jako jednopozcyjną tablicę `String[]`. Zapisz lub wyślij obraz w podanym formacie i zamień `link[0]` na odwołanie, które ma się pojawić w wyjściu Markdown.

Zasoby emitowane w formacie SVG są obsługiwane osobno. Zarejestruj wywołanie zwrotne metodą [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownsaveoptions/). Jej wywołanie zwrotne `MarkdownSvgImageSavingHandler` otrzymuje obiekt [ISvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/) oraz jednopozcyjną tablicę `String[] link`. SVG nie posiada argumentu `ImageFormat`; zamiast tego zapisz lub wyślij jego dane XML z metody [ISvgImage.getSvgData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/). W zależności od trybu eksportu i grupowania wizualnego, SVG w prezentacji źródłowej może być rasteryzowane lub połączone z inną zawartością; wynikowy zasób nie‑SVG jest następnie przekazywany do wywołania zwrotnego zapisu obrazu. Zarejestruj oba wywołania zwrotne, gdy każdy wyeksportowany zasób wizualny wymaga niestandardowego przetwarzania.

Wartość zwracana przez obsługujący określa, kto przetwarza obraz:

- Zwróć `true` po zapisaniu, przesłaniu, przekształceniu lub w inny sposób przetworzeniu obrazu oraz przypisaniu prawidłowej wartości do `link[0]`. Aspose.Slides zapisuje tę wartość w dokumencie Markdown i nie wykonuje domyślnego zapisu lokalnego.
- Zwróć `false`, aby pozwolić Aspose.Slides zapisać obraz lokalnie i wygenerować jego link zgodnie z wartościami ustawionymi w [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownsaveoptions/) oraz [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Obsługujący, który zwraca `true`, przejmuje odpowiedzialność za obraz. Jeśli zwróci `true` bez przypisania prawidłowego, niepustego linku, eksport zakończy się niepowodzeniem z `InvalidOperationException`.
{{% /alert %}}

### **Zapisz obrazy w katalogu pochodzenia CDN i użyj zewnętrznych adresów URL**

Poniższy przykład traktuje `cdn-origin/presentations/quarterly-report` jako zamontowany lub zsynchronizowany katalog pochodzenia CDN. Każdy obsługujący wyodrębnia wygenerowaną nazwę pliku, zapisuje obraz w tym niestandardowym katalogu i zamienia wygenerowane lokalne odwołanie na publiczny URL CDN. Sam przykład nie wykonuje żadnego przesyłania sieciowego: adres URL staje się ważny dopiero po zamontowaniu katalogu jako pochodzenia CDN lub po opublikowaniu jego plików w CDN. W przypadku przechowywania obiektowego zamień zapis systemu plików na operację przesyłania w SDK przechowywania i przypisz `link[0]` dopiero po pomyślnym przesłaniu.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Obsługujący bitmapy celowo zwraca `false` dla obrazów mniejszych niż 128 × 128 pikseli, więc Aspose.Slides zapisuje te obrazy w `output/fallback-images` używając domyślnego zachowania. Większe zasoby bitmap i metafili, a także zasoby SVG, są obsługiwane przez kod niestandardowy. Na przykład wygenerowane lokalne odwołanie takie jak `fallback-images/image1.png` staje się `https://cdn.example.com/presentations/quarterly-report/image1.png`. Obsługujący używają ścieżek systemu operacyjnego tylko przy zapisie plików; linki zapisywane w Markdown używają ukośników (`/`) i nazw plików z odpowiednim kodowaniem URL. Stosuj tę samą regułę przy budowaniu linków względnych: używaj `/`, a nie separatora katalogów specyficznego dla platformy.

## **FAQ**

**Czy jeden obsługujący może przetwarzać zarówno obrazy rastrowe, jak i SVG?**

Nie. Użyj [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownsaveoptions/) dla zasobów bitmap i metafili oraz [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownsaveoptions/) dla zasobów emitowanych jako SVG. Pierwsza metoda dostarcza obiekt [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) i wartość [ImageFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imageformat/); druga dostarcza obiekt [ISvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/), którego dane SVG można odczytać metodą [ISvgImage.getSvgData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/). Źródłowy SVG, który zostaje rasteryzowany podczas eksportu, jest przetwarzany przez wywołanie zwrotne zapisu obrazu.

**Co się dzieje, gdy obsługujący zapis obrazu zwraca `false`?**

Aspose.Slides używa domyślnego zachowania zapisu lokalnego. Lokalizacja obrazu i wygenerowane odwołanie są kontrolowane przez wartości ustawione w [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownsaveoptions/) oraz [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markdownsaveoptions/).

**Czy obsługujący może podać URL bez zapisywania obrazu lokalnie?**

Tak. Obsługujący może przesłać obraz do przechowywania obiektowego lub przekazać go innej usłudze, przypisać otrzymany URL do `link[0]` i zwrócić `true`. Obsługujący musi samodzielnie zakończyć przetwarzanie; zwrócenie `true` uniemożliwia domyślny zapis lokalny.

**Dlaczego eksport Markdown zgłasza `InvalidOperationException` z obsługującego?**

Ten wyjątek występuje, gdy obsługujący zwraca `true`, ale nie podaje prawidłowego linku. Przypisz względną ścieżkę lub zewnętrzny URL, który ma zostać zapisany w Markdown, zanim zwrócisz `true`.

**Jakiego separatora ścieżek powinny używać linki do obrazów?**

Używaj ukośników (`/`) w linkach Markdown i URL. Używaj `Path.resolve` tylko dla ścieżek systemu plików, a odniesienie w Markdown twórz lub normalizuj osobno.

**Czy odnośniki hipertekstowe są zachowywane podczas eksportu Markdown?**

Tak. Tekstowe [hyperlinki](/slides/pl/androidjava/manage-hyperlinks/) są zachowywane jako standardowe linki Markdown. [Przejścia](/slides/pl/androidjava/slide-transition/) i [animacje](/slides/pl/androidjava/powerpoint-animation/) slajdów nie są konwertowane.

**Czy prezentacje mogą być konwertowane na Markdown równolegle?**

Możesz przetwarzać różne pliki prezentacji równolegle, ale nie udostępniaj tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) między wątkami. Postępuj zgodnie z [wytycznymi wielowątkowości](/slides/pl/androidjava/multithreading/) i używaj osobnej instancji dla każdego pliku.