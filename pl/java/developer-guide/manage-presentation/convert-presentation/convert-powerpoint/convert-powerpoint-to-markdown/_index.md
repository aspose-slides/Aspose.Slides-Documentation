---
title: Konwertuj prezentacje PowerPoint do formatu Markdown w Javie
linktitle: PowerPoint do Markdown
type: docs
weight: 140
url: /pl/java/convert-powerpoint-to-markdown/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do MD
- prezentacja do MD
- slajd do MD
- PPT do MD
- PPTX do MD
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
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PPT i PPTX do formatu Markdown w Javie oraz kontroluj, gdzie zapisywane i odwoływane są wyeksportowane obrazy bitmapowe, metafile oraz SVG."
---
## **Przegląd**

Aspose.Slides for Java może konwertować prezentacje PPT i PPTX do formatu Markdown dla dokumentacji, witryn statycznych, migracji treści oraz przepływów pracy z kontrolą wersji. Można wybrać wariant Markdown, kontrolować sposób renderowania zawartości slajdów oraz określić, gdzie są przechowywane wyeksportowane obrazy i jak generowany Markdown odwołuje się do nich.

Domyślnie eksport Markdown używa wyjścia tylko tekstowego. Aby wyeksportować treść wizualną, ustaw typ eksportu przy pomocy metody [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownsaveoptions/) na wartość `Sequential` lub `Visual` z wyliczenia [MarkdownExportType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownexporttype/). `Sequential` renderuje elementy slajdu osobno i w kolejności, natomiast `Visual` utrzymuje pogrupowane elementy razem, aby zachować ich relację wizualną. Wartość `TextOnly` nie generuje zasobów obrazów, więc w tym trybie nie wywoływane są wywołania zwrotne zapisywania obrazów.

## **Konwertuj prezentację do Markdown**

Załaduj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i następnie wywołaj metodę [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) z wartością `Md` z wyliczenia [SaveFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/).

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

## **Wybierz wariant Markdown**

Metoda [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownsaveoptions/) kontroluje specyfikację Markdown używaną dla wyjścia. Wyliczenie [Flavor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/flavor/) zawiera CommonMark, GitHub Flavored Markdown i inne obsługiwane warianty.

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

## **Eksportuj obrazy przy użyciu domyślnego zachowania zapisu lokalnego**

Klasa [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownsaveoptions/) udostępnia dwie metody konfiguracyjne dla lokalnie zapisywanych obrazów:

- [setBasePath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownsaveoptions/) określa podstawowy katalog dla dokumentu Markdown i jego zasobów.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownsaveoptions/) określa podkatalog obrazów. Jego domyślną wartością jest `Images`.

Poniższy przykład renderuje treść wizualną, zapisuje obrazy w `output/assets` i tworzy względne odwołania do obrazów w dokumencie Markdown:

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

To zachowanie służy również jako awaryjne, gdy własny handler zapisu obrazu zwraca `false`.

## **Dostosuj zapisywanie obrazów i linki Markdown**

Użyj metody [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownsaveoptions/) aby zarejestrować wywołanie zwrotne dla zasobów bitmapowych i metafili niebędących SVG emitowanych podczas eksportu do Markdown. Jego callback `MarkdownImageSavingHandler` otrzymuje obiekt [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/), jego wartość [ImageFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imageformat/) oraz wygenerowany link Markdown jako jednopunktowy parametr `String[]`. Zapisz lub wyślij obraz w podanym formacie i zastąp `link[0]` odnośnikiem, który ma pojawić się w wyjściu Markdown.

Zasoby emitowane w formacie SVG są obsługiwane osobno. Zarejestruj wywołanie zwrotne przy użyciu metody [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownsaveoptions/). Jego callback `MarkdownSvgImageSavingHandler` otrzymuje obiekt [ISvgImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isvgimage/) oraz jednopunktowy parametr `String[] link`. SVG nie posiada argumentu `ImageFormat`; zamiast tego zapisz lub wyślij jego dane XML przy użyciu metody [ISvgImage.getSvgData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isvgimage/). W zależności od trybu eksportu i grupowania wizualnego, SVG w prezentacji źródłowej może być rastrowany lub łączony z inną zawartością; wynikowy zasób nie‑SVG jest następnie przekazywany do wywołania zwrotnego zapisu obrazu. Zarejestruj oba wywołania zwrotne, gdy każdy wyeksportowany zasób wizualny wymaga własnego przetworzenia.

Wartość zwracana przez obsługujący określa, kto przetwarza obraz:

- Zwróć `true` po tym, jak obsługujący zapisał, wgrał, przekształcił lub w inny sposób przetworzył obraz i przypisał prawidłową wartość do `link[0]`. Aspose.Slides zapisuje tę wartość w dokumencie Markdown i nie wykonuje domyślnego lokalnego zapisu.
- Zwróć `false`, aby pozwolić Aspose.Slides zapisać obraz lokalnie i wygenerować jego odnośnik zgodnie z wartościami ustawionymi w [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownsaveoptions/) i [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Obsługujący zwracający `true` przejmuje odpowiedzialność za obraz. Jeśli zwróci `true` bez przypisania prawidłowego, niepustego linku, eksport zakończy się niepowodzeniem z `InvalidOperationException`.
{{% /alert %}}

### **Zapisz obrazy w katalogu pochodzenia CDN i użyj zewnętrznych adresów URL**

Poniższy przykład traktuje `cdn-origin/presentations/quarterly-report` jako zamontowany lub zsynchronizowany katalog pochodzenia CDN. Każdy handler wyodrębnia wygenerowaną nazwę pliku, zapisuje obraz w tym niestandardowym katalogu i zamienia wygenerowane lokalne odwołanie na publiczny adres URL CDN. Sam przykładowy kod nie wykonuje przesyłania sieciowego: adres URL staje się ważny dopiero po zamontowaniu katalogu jako pochodzenia CDN lub po opublikowaniu jego plików w CDN. W przypadku przechowywania obiektowego zamień zapis do systemu plików na operację uploadu SDK przechowywania i przypisz `link[0]` dopiero po pomyślnym zakończeniu uploadu.

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

Handler bitmapowy celowo zwraca `false` dla obrazów mniejszych niż 128 × 128 pikseli, więc Aspose.Slides zapisuje te obrazy w `output/fallback-images` używając zachowania domyślnego. Większe zasoby bitmapowe i metafile, jak również zasoby SVG, są obsługiwane przez własny kod. Na przykład wygenerowane lokalne odwołanie `fallback-images/image1.png` staje się `https://cdn.example.com/presentations/quarterly-report/image1.png`. Handlery używają ścieżek systemowych wyłącznie przy zapisie plików; linki zapisane w Markdown używają ukośników (`/`) i URL‑zakodowanych nazw plików. Stosuj tę samą zasadę przy budowaniu względnych linków: używaj `/`, a nie separatora specyficznego dla platformy.

## **FAQ**

**Czy jeden obsługujący może przetwarzać zarówno obrazy rastrowe, jak i obrazy SVG?**

Nie. Użyj [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownsaveoptions/) dla bitmap i metafili oraz [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownsaveoptions/) dla zasobów emitowanych jako SVG. Pierwszy dostarcza obiekt [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/) oraz wartość [ImageFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imageformat/); drugi dostarcza obiekt [ISvgImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isvgimage/), którego dane SVG można odczytać metodą [ISvgImage.getSvgData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isvgimage/). Źródłowy SVG, który zostanie rasteryzowany podczas eksportu, jest przetwarzany przez callback zapisu obrazu.

**Co się dzieje, gdy obsługujący zapis obrazu zwraca `false`?**

Aspose.Slides używa domyślnego zachowania zapisu lokalnego. Lokalizacja obrazu i wygenerowane odwołanie są kontrolowane przez wartości ustawione w [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownsaveoptions/) i [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markdownsaveoptions/).

**Czy obsługujący może podać adres URL bez zapisywania obrazu lokalnie?**

Tak. Handler może wgrać obraz do przechowywania obiektowego lub przekazać go do innej usługi, przypisać otrzymany URL do `link[0]` i zwrócić `true`. Handler musi samodzielnie zakończyć przetwarzanie; zwrócenie `true` uniemożliwia domyślny lokalny zapis.

**Dlaczego eksport Markdown rzuca `InvalidOperationException` pochodzący z obsługującego?**

Ten wyjątek występuje, gdy handler zwraca `true`, ale nie dostarcza prawidłowego linku. Przypisz względną ścieżkę lub zewnętrzny URL, który ma zostać zapisany w Markdown, zanim zwrócisz `true`.

**Jakiego separatora ścieżek powinny używać linki do obrazów?**

Używaj ukośników (`/`) w linkach Markdown i URL. `Path.resolve` stosuj wyłącznie do ścieżek systemowych, a odwołania w Markdown buduj lub normalizuj osobno.

**Czy hiperłącza są zachowywane podczas eksportu do Markdown?**

Tak. Tekstowe [hyperlinks](/slides/pl/java/manage-hyperlinks/) są zachowywane jako standardowe linki Markdown. Przejścia slajdów [transitions](/slides/pl/java/slide-transition/) i [animations](/slides/pl/java/powerpoint-animation/) nie są konwertowane.

**Czy prezentacje mogą być konwertowane do Markdown równolegle?**

Można przetwarzać różne pliki prezentacji równolegle, ale nie udostępniać tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) pomiędzy wątkami. Postępuj zgodnie z [multithreading guidelines](/slides/pl/java/multithreading/) i używaj osobnej instancji dla każdego pliku.