---
title: Zapisz prezentacje w Javie
linktitle: Zapisz prezentację
type: docs
weight: 80
url: /pl/java/save-presentation/
keywords:
- zapisz PowerPoint
- zapisz OpenDocument
- zapisz prezentację
- zapisz slajd
- zapisz PPT
- zapisz PPTX
- zapisz ODP
- prezentacja do pliku
- prezentacja do strumienia
- zdefiniowany typ widoku
- Ścisły format Office Open XML
- tryb Zip64
- odświeżanie miniatury
- postęp zapisu
- Java
- Aspose.Slides
description: "Poznaj sposób zapisywania prezentacji w Javie przy użyciu Aspose.Slides — eksport do PowerPoint lub OpenDocument przy zachowaniu układów, czcionek i efektów."
---
## **Przegląd**

[Otwórz prezentacje w Javie](/slides/pl/java/open-presentation/) opisuje, jak używać klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) do otwierania prezentacji. Ten artykuł wyjaśnia, jak tworzyć i zapisywać prezentacje. Klasa [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) zawiera zawartość prezentacji. Niezależnie od tego, czy tworzysz prezentację od podstaw, czy modyfikujesz istniejącą, będziesz chciał ją zapisać po zakończeniu. Za pomocą Aspose.Slides dla Javy możesz zapisać do **pliku** lub **strumienia**. Ten artykuł opisuje różne sposoby zapisywania prezentacji.

## **Zapisz prezentacje do plików**

Zapisz prezentację do pliku, wywołując metodę `save` klasy Presentation. Przekaż nazwę pliku i format zapisu do metody. Poniższy przykład pokazuje, jak zapisać prezentację przy użyciu Aspose.Slides.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Wykonaj tutaj jakieś działania...

    // Zapisz prezentację do pliku.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zapisz prezentacje do strumieni**

Możesz zapisać prezentację do strumienia, przekazując strumień wyjściowy do metody `save` klasy Presentation. Prezentację można zapisać do wielu typów strumieni. W poniższym przykładzie tworzymy nową prezentację i zapisujemy ją do strumienia plikowego.

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

## **Zapisz prezentacje z zdefiniowanym typem widoku**

Aspose.Slides umożliwia ustawienie początkowego widoku, którego PowerPoint używa po otwarciu wygenerowanej prezentacji, poprzez klasę [ViewProperties](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewproperties/). Użyj metody [setLastView](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewproperties/#setLastView-int-) z wartością z wyliczenia [ViewType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/viewtype/).

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

Aspose.Slides umożliwia zapisanie prezentacji w ścisłym formacie Office Open XML. Użyj klasy [PptxOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxoptions/) i ustaw jej właściwość conformance podczas zapisu. Jeśli ustawisz [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/pl/java/com.aspose.slides/conformance/#Iso29500-2008-Strict), plik wyjściowy zostanie zapisany w ścisłym formacie Office Open XML.

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

Plik Office Open XML to archiwum ZIP, które narzuca limit 4 GB (2^32 bajtów) na nieskompresowany rozmiar dowolnego pliku, skompresowany rozmiar dowolnego pliku oraz całkowity rozmiar archiwum, a także ogranicza archiwum do 65 535 (2^16‑1) plików. Rozszerzenia formatu ZIP64 podnoszą te limity do 2^64.

Metoda [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) pozwala wybrać, kiedy używać rozszerzeń formatu ZIP64 podczas zapisywania pliku Office Open XML.

Ta metoda może być używana z następującymi trybami:

- [IfNecessary](https://reference.aspose.com/slides/pl/java/com.aspose.slides/zip64mode/#IfNecessary) używa rozszerzeń formatu ZIP64 tylko wtedy, gdy prezentacja przekracza powyższe ograniczenia. Jest to tryb domyślny.
- [Never](https://reference.aspose.com/slides/pl/java/com.aspose.slides/zip64mode/#Never) nigdy nie używa rozszerzeń formatu ZIP64.
- [Always](https://reference.aspose.com/slides/pl/java/com.aspose.slides/zip64mode/#Always) zawsze używa rozszerzeń formatu ZIP64.

Poniższy kod demonstruje, jak zapisać prezentację jako plik PPTX z włączonymi rozszerzeniami formatu ZIP64:

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
Gdy zapisujesz z Zip64Mode.Never, zostaje rzucony [PptxException](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxexception/), jeśli prezentacji nie można zapisać w formacie ZIP32.
{{% /alert %}}

## **Zapisz prezentacje w formacie Office Open XML z poziomami kompresji**

Pracując z dużymi prezentacjami, możesz dostosować poziom kompresji, aby zrównoważyć rozmiar pliku i czas przetwarzania. W zależności od wymagań możesz preferować szybsze przetwarzanie lub mniejsze pliki wyjściowe.

Aspose.Slides udostępnia metodę [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-), która pozwala określić poziom kompresji używany przy zapisywaniu prezentacji w formacie Office Open XML.

Dostępne są następujące poziomy kompresji:

- [**None**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#None): Nie stosuje się kompresji. Pliki są przechowywane w stanie niezmienionym.
- [**Level1**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level1): Najszybsza kompresja o najniższym współczynniku kompresji.
- [**Level2**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level2): Szybsza kompresja z nieco lepszym współczynnikiem niż **Level1**.
- [**Level3**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level3): Zapewnia lepszą kompresję niż **Level2**, przy umiarkowanym wpływie na czas przetwarzania.
- [**Level4**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level4): Zapewnia lepszą kompresję niż **Level3**.
- [**Level5**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level5): Oferuje lepszą kompresję niż **Level4**, przy dodatkowym czasie przetwarzania.
- [**Level6**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level6): Standardowa kompresja, zapewniająca dobrą równowagę między szybkością przetwarzania a rozmiarem pliku. To *domyślny poziom kompresji*.
- [**Level7**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level7): Zapewnia lepszą kompresję niż **Level6**, przy wolniejszym przetwarzaniu.
- [**Level8**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level8): Zapewnia lepszą kompresję niż **Level7**.
- [**Level9**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/compressionlevel/#Level9): Maksymalna kompresja. Produkuje najmniejszy rozmiar pliku kosztem najdłuższego czasu przetwarzania.

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

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) kontroluje generowanie miniatury podczas zapisywania prezentacji do PPTX:

- Jeśli ustawiona na `true`, miniatura jest odświeżana podczas zapisu. To domyślne zachowanie.
- Jeśli ustawiona na `false`, bieżąca miniatura jest zachowywana. Jeśli prezentacja nie ma miniatury, nie zostanie wygenerowana żadna.

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
Ta opcja pomaga zmniejszyć czas potrzebny na zapisanie prezentacji w formacie PPTX.
{{% /alert %}}

## **Zapisz aktualizacje postępu w procentach**

Interfejs [IProgressCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprogresscallback/) jest używany za pośrednictwem metody `setProgressCallback` udostępnionej przez interfejs [ISaveOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isaveoptions/) oraz abstrakcyjną klasę [SaveOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/saveoptions/). Przypisz implementację [IProgressCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iprogresscallback/) przy pomocy `setProgressCallback`, aby otrzymywać aktualizacje postępu zapisu w procentach.

Poniższy fragment kodu pokazuje, jak używać `IProgressCallback`.

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Użyj tutaj wartości procentowej postępu.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose opracowało darmową aplikację PowerPoint Splitter, wykorzystującą własne API. Aplikacja umożliwia podzielenie prezentacji na wiele plików, zapisując wybrane slajdy jako nowe pliki PPTX lub PPT.
{{% /alert %}}

## **FAQ**

**Czy obsługiwane jest „szybkie zapisywanie” (zapis przyrostowy), tak by zapisywać tylko zmiany?**

Nie. Zapisywanie tworzy pełny plik docelowy przy każdym zapisie; przyrostowy „szybki zapis” nie jest obsługiwany.

**Czy zapisywanie tej samej instancji Presentation z wielu wątków jest bezpieczne wątkowo?**

Nie. Instancja Presentation nie jest bezpieczna wątkowo; zapisz ją z jednego wątku.

**Co się dzieje z hiperłączami i zewnętrznie powiązanymi plikami podczas zapisywania?**

[Hyperlinks](/slides/pl/java/manage-hyperlinks/) są zachowywane. Zewnętrznie powiązane pliki (np. wideo za pomocą ścieżek względnych) nie są kopiowane automatycznie — upewnij się, że odwoływane ścieżki pozostają dostępne.

**Czy mogę ustawić/zapisać metadane dokumentu (Autor, Tytuł, Firma, Data)?**

Tak. Standardowe właściwości dokumentu są obsługiwane i zostaną zapisane w pliku podczas zapisu.