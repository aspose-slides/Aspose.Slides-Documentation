---
title: Zapis prezentacji w Javie
linktitle: Zapis prezentacji
type: docs
weight: 80
url: /pl/java/save-presentation/
keywords:
- zapis PowerPoint
- zapis OpenDocument
- zapis prezentacji
- zapis slajdu
- zapis PPT
- zapis PPTX
- zapis ODP
- prezentacja do pliku
- prezentacja do strumienia
- wstępnie określony typ widoku
- Ścisły format Office Open XML
- tryb Zip64
- odświeżanie miniaturki
- postęp zapisu
- Java
- Aspose.Slides
description: "Zapisz prezentacje PowerPoint i OpenDocument do plików lub strumieni w Javie przy użyciu Aspose.Slides oraz skonfiguruj wyjście PPTX i raportowanie postępu."
---
## **Przegląd**

Po utworzeniu prezentacji lub [otwórz istniejącą](/slides/pl/java/open-presentation/), użyj metody [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) aby zapisać wynik. Aspose.Slides for Java może zapisać prezentację do pliku lub strumienia w formatach PowerPoint, OpenDocument, PDF i innych. Poniższe sekcje opisują standardowe operacje zapisu oraz dostępne opcje wyjściowe PPTX.

## **Zapis prezentacji do plików**

Aby zapisać prezentację do pliku, przekaż ścieżkę wyjściową oraz wartość [SaveFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/) do metody [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Wartość formatu określa typ pliku, który tworzy Aspose.Slides.

Poniższy przykład tworzy prezentację i zapisuje ją jako plik PPTX:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // Dodaj lub zmodyfikuj zawartość prezentacji tutaj.

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zapis prezentacji w ich oryginalnym formacie**

Przykłady wykrywania formatu pliku i strumienia, zachowanie nowo utworzonych prezentacji oraz różnica między formatem źródłowym a wyjściowym znajdują się w sekcji [Determine the Original Presentation Format](/slides/pl/java/detect-presentation-source-format/).

W aplikacji przetwarzającej wsadowo format wejściowy może nie być znany z góry. Po wczytaniu pliku odczytaj jego pierwotny format przy pomocy metody [IPresentation.getSourceFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getSourceFormat--) . Przekaż uzyskaną wartość [SourceFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sourceformat/) do [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideutil/#toSaveFormat-int-) aby otrzymać odpowiadającą wartość [SaveFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/), a następnie użyj [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) aby zapisać zmodyfikowaną prezentację.

Poniższy kompletny przykład przetwarza każdy plik w katalogu wejściowym, aktualizuje jego tytuł i zapisuje go do katalogu wyjściowego w formacie, z którego został wczytany:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideutil/#toSaveFormat-int-) mapuje PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP i PowerPoint XML na ich odpowiadające formaty zapisu prezentacji. Mapuje jedynie formaty źródłowe prezentacji; nie służy do wyboru formatów eksportu takich jak PDF, HTML, TIFF czy obrazy. Przekazanie nieobsługiwanej lub nieprawidłowej wartości [SourceFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/sourceformat/) skutkuje wyrzuceniem [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Pliki starszego formatu PPT, PPS i POT używają tego samego kontenera binarnego. Gdy taka prezentacja zostanie wczytana ze strumienia bez rozszerzenia pliku, plik PPS lub POT może zostać zidentyfikowany jako PPT. Jeśli wymagana jest zachowanie tych starszych podtypów, należy zachować oryginalną nazwę pliku lub metadane formatu osobno i używać ich przy wyborze nazwy i formatu pliku wyjściowego.

## **Zapis prezentacji do strumieni**

Aby zapisać prezentację bez podawania ostatecznej ścieżki pliku, przekaż strumień zapisu oraz wartość [SaveFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveformat/) do metody [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Takie podejście jest przydatne, gdy wynik ma być zwrócony z usługi sieciowej, zapisany w bazie danych lub przetworzony w pamięci.

Poniższy przykład zapisuje nową prezentację do strumienia pliku:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Zapis prezentacji z określonym typem widoku**

Możesz określić widok, w którym PowerPoint otworzy zapisany plik. Użyj metody [ViewProperties.setLastView](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewproperties/#setLastView-int-) z wartością [ViewType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewtype/) przed zapisem.

Poniższy przykład konfiguruje widok Master Slide jako widok początkowy:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zapis prezentacji w ścisłym formacie Office Open XML**

Aby stworzyć plik PPTX zgodny z profilem Strict standardu Office Open XML, utwórz instancję [PptxOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxoptions/) i użyj jej metody [setConformance](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxoptions/#setConformance-int-) z wartością [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pl/java/com.aspose.slides/conformance/#Iso29500-2008-Strict). Następnie przekaż opcje do metody [Presentation.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Zapis prezentacji w formacie Office Open XML w trybie Zip64**

Standardowe archiwum ZIP ogranicza rozmiar skompresowanej i nieskompresowanej zawartości każdego wpisu, całkowity rozmiar archiwum oraz liczbę wpisów. Ponieważ plik PPTX jest archiwum ZIP, bardzo duża prezentacja może przekroczyć te limity. Rozszerzenia ZIP64 podnoszą obowiązujące limity rozmiaru i liczby wpisów.

Użyj metody [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-), aby kontrolować, czy Aspose.Slides zapisuje rozszerzenia ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/pl/java/com.aspose.slides/zip64mode/#IfNecessary) używa ZIP64 tylko wtedy, gdy prezentacja przekracza standardowe limity ZIP. To tryb domyślny.
- [Never](https://reference.aspose.com/slides/pl/java/com.aspose.slides/zip64mode/#Never) wyłącza rozszerzenia ZIP64.
- [Always](https://reference.aspose.com/slides/pl/java/com.aspose.slides/zip64mode/#Always) zawsze zapisuje rozszerzenia ZIP64.

Poniższy przykład zawsze włącza rozszerzenia ZIP64 dla prezentacji wyjściowej:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Jeśli użyto [Zip64Mode.Never](https://reference.aspose.com/slides/pl/java/com.aspose.slides/zip64mode/#Never) i prezentacja nie mieści się w standardowych limitach ZIP, operacja zapisu zgłasza [PptxException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxexception/).
{{% /alert %}}

## **Zapis prezentacji w formacie Office Open XML z poziomami kompresji**

Dla wyjścia PPTX możesz zrównoważyć szybkość zapisu i rozmiar pliku, używając metody [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-). Klasa [CompressionLevel](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/) udostępnia następujące wartości:

- [None](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#None) przechowuje dane bez kompresji.
- [Level1](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level1) zapewnia najszybszą kompresję i największy rozmiar skompresowanego pliku.
- [Level2](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level2) do [Level5](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level5) stopniowo faworyzują mniejszy wynik kosztem szybkości zapisu.
- [Level6](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level6) wyrównuje szybkość zapisu i rozmiar pliku. To domyślny poziom.
- [Level7](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level7) i [Level8](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level8) jeszcze bardziej faworyzują mniejszy wynik kosztem szybkości zapisu.
- [Level9](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level9) zapewnia najsilniejszą kompresję i wymaga najwięcej czasu przetwarzania.

Poniższy przykład zapisuje prezentację bez kompresji:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Poniższy przykład używa maksymalnego poziomu kompresji:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Zapis prezentacji bez odświeżania miniaturki**

Podczas zapisu prezentacji jako PPTX metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) kontroluje jej miniaturkę dokumentu:

- `true` odtwarza miniaturkę podczas zapisu. To wartość domyślna.
- `false` zachowuje istniejącą miniaturkę. Jeśli prezentacja nie ma miniaturki, Aspose.Slides jej nie generuje.

Poniższy przykład zapisuje prezentację bez odświeżania miniaturki:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Wyłączenie odświeżania miniaturki może skrócić czas potrzebny na zapis pliku PPTX.
{{% /alert %}}

## **Raportowanie postępu zapisu w procentach**

Aby monitorować operację zapisu, zaimplementuj interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprogresscallback/) i przekaż implementację do metody [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-). Aspose.Slides wywołuje metodę [IProgressCallback.reporting](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprogresscallback/#reporting-double-) z wartościami postępu podczas eksportu.

Poniższy przykład raportuje postęp eksportu PDF do konsoli:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose oferuje darmowy [PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) oparty na API Aspose.Slides. Narzędzie zapisuje wybrane slajdy z prezentacji jako oddzielne pliki PPT lub PPTX.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides obsługuje zapisy przyrostkowe lub „szybki zapis”?**

Nie. Każda operacja zapisu tworzy kompletny plik wyjściowy, a nie aktualizuje jedynie zmienione części.

**Czy wiele wątków może zapisywać tę samą instancję Presentation?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) **nie jest wątkowo‑bezpieczna** (/slides/pl/java/multithreading/). Dostęp i zapis każdej instancji powinny odbywać się z jednego wątku naraz.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami po zapisaniu prezentacji?**

[Hyperlinks](/slides/pl/java/manage-hyperlinks/) pozostają w prezentacji. Aspose.Slides nie kopiuje zewnętrznie powiązanych plików, więc zapisana prezentacja musi nadal mieć dostęp do ich lokalizacji.

**Czy mogę zapisać metadane dokumentu, takie jak autor, tytuł, firma i data utworzenia?**

Tak. Ustaw odpowiednie [document properties](/slides/pl/java/presentation-properties/) przed zapisem, a Aspose.Slides zapisze je w pliku wyjściowym.