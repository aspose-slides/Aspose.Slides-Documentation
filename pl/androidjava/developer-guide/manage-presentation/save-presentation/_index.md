---
title: "Zapisz prezentacje na Androidzie"
linktitle: "Zapisz prezentację"
type: docs
weight: 80
url: /pl/androidjava/save-presentation/
keywords:
- "zapisz PowerPoint"
- "zapisz OpenDocument"
- "zapisz prezentację"
- "zapisz slajd"
- "zapisz PPT"
- "zapisz PPTX"
- "zapisz ODP"
- "prezentacja do pliku"
- "prezentacja do strumienia"
- "wstępnie określony typ widoku"
- "ścisły format Office Open XML"
- "tryb Zip64"
- "odświeżanie miniatury"
- "postęp zapisywania"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Dowiedz się, jak zapisywać prezentacje w języku Java przy użyciu Aspose.Slides dla Androida — eksportuj do PowerPoint lub OpenDocument, zachowując układy, czcionki i efekty."
---
## **Przegląd**

[Open Presentations on Android](/slides/pl/androidjava/open-presentation/) opisuje, jak używać klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) do otwierania prezentacji. Ten artykuł wyjaśnia, jak tworzyć i zapisywać prezentacje. Klasa [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) zawiera zawartość prezentacji. Niezależnie od tego, czy tworzysz prezentację od podstaw, czy modyfikujesz istniejącą, będziesz chciał ją zapisać po zakończeniu. Dzięki Aspose.Slides for Android możesz zapisać do **pliku** lub **strumienia**. Ten artykuł wyjaśnia różne sposoby zapisywania prezentacji.

## **Zapisz prezentacje do plików**

Zapisz prezentację do pliku, wywołując metodę `save` klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/). Przekaż nazwę pliku i format zapisu do metody. Poniższy przykład pokazuje, jak zapisać prezentację przy użyciu Aspose.Slides.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Wykonaj tutaj pewne operacje...

    // Zapisz prezentację do pliku.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje do strumieni**

Możesz zapisać prezentację do strumienia, przekazując strumień wyjściowy do metody `save` klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/). Prezentację można zapisać do wielu typów strumieni. W poniższym przykładzie tworzymy nową prezentację i zapisujemy ją do strumienia pliku.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Zapisz prezentację do strumienia.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje z określonym typem widoku**

Aspose.Slides umożliwia ustawienie początkowego widoku, którego PowerPoint używa po otwarciu wygenerowanej prezentacji, za pomocą klasy [ViewProperties](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewproperties/). Użyj metody [setLastView](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) z wartością z wyliczenia [ViewType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/viewtype/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje w ścisłym formacie Office Open XML**

Aspose.Slides umożliwia zapisanie prezentacji w ścisłym formacie Office Open XML. Użyj klasy [PptxOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxoptions/) i ustaw jej właściwość conformance podczas zapisywania. Jeśli ustawisz [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), plik wyjściowy zostanie zapisany w ścisłym formacie Office Open XML.

Poniższy przykład tworzy prezentację i zapisuje ją w ścisłym formacie Office Open XML.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Zapisz prezentację w ścisłym formacie Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje w formacie Office Open XML w trybie Zip64**

Plik Office Open XML jest archiwum ZIP, które narzuca limity 4 GB (2^32 bajtów) na nieskompresowany rozmiar dowolnego pliku, skompresowany rozmiar dowolnego pliku oraz całkowity rozmiar archiwum, a także ogranicza liczbę plików w archiwum do 65 535 (2^16‑1). Rozszerzenia formatu ZIP64 podnoszą te limity do 2^64.

Metoda [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) pozwala wybrać, kiedy używać rozszerzeń formatu ZIP64 podczas zapisywania pliku Office Open XML.

Ta metoda może być używana z następującymi trybami:

- [IfNecessary](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/zip64mode/#IfNecessary) używa rozszerzeń formatu ZIP64 tylko wtedy, gdy prezentacja przekracza powyższe ograniczenia. To jest domyślny tryb.
- [Never](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/zip64mode/#Never) nigdy nie używa rozszerzeń formatu ZIP64.
- [Always](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/zip64mode/#Always) zawsze używa rozszerzeń formatu ZIP64.

Poniższy kod pokazuje, jak zapisać prezentację jako plik PPTX z włączonymi rozszerzeniami formatu ZIP64:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Kiedy zapisujesz z [Zip64Mode.Never](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/zip64mode/#Never), rzucany jest [PptxException](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxexception/), jeśli prezentacji nie można zapisać w formacie ZIP32.
{{% /alert %}}

## **Zapisz prezentacje w formacie Office Open XML z poziomami kompresji**

Podczas pracy z dużymi prezentacjami możesz dostosować poziom kompresji, aby zrównoważyć rozmiar pliku i czas przetwarzania. W zależności od wymagań możesz preferować szybsze przetwarzanie lub mniejsze pliki wyjściowe.

Aspose.Slides udostępnia metodę [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-), która pozwala określić poziom kompresji używany przy zapisywaniu prezentacji w formacie Office Open XML.

Dostępne są następujące poziomy kompresji:

- [**None**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compressionlevel/#None): Nie stosuje się kompresji. Pliki są przechowywane w oryginalnej formie.
- [**Level1**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compressionlevel/#Level1): Najszybsza kompresja przy najniższym współczynniku kompresji.
- [**Level2**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compressionlevel/#Level2): Szybsza kompresja z nieco lepszym współczynnikiem kompresji niż **Level1**.
- [**Level3**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compressionlevel/#Level3): Lepsza kompresja niż **Level2**, przy umiarkowanym wpływie na czas przetwarzania.
- [**Level4**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compressionlevel/#Level4): Lepsza kompresja niż **Level3**.
- [**Level5**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compressionlevel/#Level5): Ulepszona kompresja w porównaniu do **Level4**, przy dodatkowym czasie przetwarzania.
- [**Level6**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compressionlevel/#Level6): Standardowa kompresja oferująca dobry balans między szybkością przetwarzania a rozmiarem pliku. To jest *domyślny poziom kompresji*.
- [**Level7**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compressionlevel/#Level7): Lepsza kompresja niż **Level6**, przy wolniejszym przetwarzaniu.
- [**Level8**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compressionlevel/#Level8): Lepsza kompresja niż **Level7**.
- [**Level9**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/compressionlevel/#Level9): Maksymalna kompresja. Produkuje najmniejszy rozmiar pliku kosztem najdłuższego czasu przetwarzania.

Poniższy przykład demonstruje, jak zapisać prezentację jako plik PPTX *bez kompresji*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Ten przykład pokazuje, jak zapisać prezentację jako plik PPTX z *maksymalną kompresją*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje bez odświeżania miniatury**

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) kontroluje generowanie miniatury przy zapisywaniu prezentacji do PPTX:

- Jeśli ustawione na `true`, miniatura jest odświeżana podczas zapisu. To jest domyślne.
- Jeśli ustawione na `false`, bieżąca miniatura jest zachowywana. Jeśli prezentacja nie ma miniatury, nie zostanie wygenerowana.

W poniższym kodzie prezentacja jest zapisywana do PPTX bez odświeżania jej miniatury.

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Ta opcja pomaga skrócić czas potrzebny na zapisanie prezentacji w formacie PPTX.
{{% /alert %}}

## **Zapisz aktualizacje postępu w procentach**

Interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprogresscallback/) jest używany poprzez metodę `setProgressCallback` udostępnioną przez interfejs [ISaveOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isaveoptions/) oraz klasę abstrakcyjną [SaveOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/saveoptions/). Przypisz implementację [IProgressCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iprogresscallback/) przy pomocy `setProgressCallback`, aby otrzymywać aktualizacje postępu zapisu w procentach.

Poniższe fragmenty kodu pokazują, jak używać `IProgressCallback`.

```java
import com.aspose.slides.*;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Użyj tutaj wartości procentowej postępu.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose opracowało [darmową aplikację PowerPoint Splitter](https://products.aspose.app/slides/pl/splitter) wykorzystującą własne API. Aplikacja pozwala podzielić prezentację na wiele plików, zapisując wybrane slajdy jako nowe pliki PPTX lub PPT.
{{% /alert %}}

## **FAQ**

**Czy obsługiwane jest „szybkie zapisywanie” (zapis przyrostowy), tak aby zapisywane były tylko zmiany?**

Nie. Zapisywanie tworzy pełny plik docelowy za każdym razem; przyrostowy „szybki zapis” nie jest obsługiwany.

**Czy zapisywanie tej samej instancji Presentation z wielu wątków jest bezpieczne w kontekście wątków?**

Nie. Instancja [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) [nie jest bezpieczna wątkowo](/slides/pl/androidjava/multithreading/); zapisuj ją z jednego wątku.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami przy zapisywaniu?**

[Hiperłącza](/slides/pl/androidjava/manage-hyperlinks/) są zachowane. Zewnętrznie powiązane pliki (np. wideo podane ścieżkami względnymi) nie są kopiowane automatycznie — upewnij się, że odwołane ścieżki pozostają dostępne.

**Czy mogę ustawić/zapisać metadane dokumentu (Autor, Tytuł, Firma, Data)?**

Tak. Standardowe [właściwości dokumentu](/slides/pl/androidjava/presentation-properties/) są obsługiwane i zostaną zapisane w pliku przy zapisie.