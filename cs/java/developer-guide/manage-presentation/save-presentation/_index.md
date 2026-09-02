---
title: Ukládání prezentací v Javě
linktitle: Uložit prezentaci
type: docs
weight: 80
url: /cs/java/save-presentation/
keywords:
  - ukládat PowerPoint
  - ukládat OpenDocument
  - ukládat prezentaci
  - ukládat snímek
  - ukládat PPT
  - ukládat PPTX
  - ukládat ODP
  - prezentace do souboru
  - prezentace do streamu
  - předdefinovaný typ zobrazení
  - striktní formát Office Open XML
  - režim Zip64
  - obnovení miniatury
  - ukládání postupu
  - Java
  - Aspose.Slides
description: "Objevte, jak ukládat prezentace v Javě pomocí Aspose.Slides—export do PowerPointu nebo OpenDocumentu při zachování rozvržení, písem a efektů."
---
## **Přehled**

[Open Presentations in Java](/slides/cs/java/open-presentation/) popisuje, jak použít třídu [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) k otevření prezentace. Tento článek vysvětluje, jak vytvářet a ukládat prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) obsahuje obsah prezentace. Ať už vytváříte prezentaci od nuly nebo upravujete existující, budete ji chtít po dokončení uložit. S Aspose.Slides pro Java můžete ukládat do **souboru** nebo **streamu**. Tento článek popisuje různé způsoby ukládání prezentace.

## **Uložit prezentace do souborů**

Uložení prezentace do souboru provedete zavoláním metody `save` třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Metodě předáte název souboru a formát ukládání. Následující příklad ukazuje, jak uložit prezentaci pomocí Aspose.Slides.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Proveďte zde nějakou práci...

    // Uložte prezentaci do souboru.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Uložit prezentace do streamů**

Prezentaci můžete uložit do streamu předáním výstupního streamu metodě `save` třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Prezentaci lze zapsat do mnoha typů streamů. V níže uvedeném příkladu vytvoříme novou prezentaci a uložíme ji do souborového streamu.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Uložte prezentaci do streamu.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Uložit prezentace s předdefinovaným typem zobrazení**

Aspose.Slides umožňuje nastavit počáteční pohled, který PowerPoint použije při otevření vygenerované prezentace, pomocí třídy [ViewProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewproperties/). Použijte metodu [setLastView](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewproperties/#setLastView-int-) s hodnotou z výčtu [ViewType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/viewtype/).

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

## **Uložit prezentace ve striktním formátu Office Open XML**

Aspose.Slides umožňuje uložit prezentaci ve striktním formátu Office Open XML. Použijte třídu [PptxOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxoptions/) a nastavte její vlastnost `conformance` při ukládání. Pokud nastavíte [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/cs/java/com.aspose.slides/conformance/#Iso29500-2008-Strict), výstupní soubor bude uložen ve striktním formátu Office Open XML.

Níže uvedený příklad vytvoří prezentaci a uloží ji ve striktním formátu Office Open XML.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Uložte prezentaci ve striktním formátu Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Uložit prezentace ve formátu Office Open XML v režimu Zip64**

Soubor Office Open XML je archiv ZIP, který ukládá limity 4 GB (2^32 bajtů) na nekomprimovanou velikost libovolného souboru, komprimovanou velikost libovolného souboru a celkovou velikost archivu a také omezuje archiv na 65 535 (2^16‑1) souborů. Rozšíření formátu ZIP64 tato omezení zvyšují na 2^64.

Metoda [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) vám umožňuje zvolit, kdy při ukládání souboru Office Open XML použít rozšíření ZIP64.

Tuto metodu lze použít s následujícími režimy:

- [IfNecessary](https://reference.aspose.com/slides/cs/java/com.aspose.slides/zip64mode/#IfNecessary) používá rozšíření ZIP64 pouze v případě, že prezentace přesáhne výše zmíněná omezení. Toto je výchozí režim.
- [Never](https://reference.aspose.com/slides/cs/java/com.aspose.slides/zip64mode/#Never) nikdy nepoužívá rozšíření ZIP64.
- [Always](https://reference.aspose.com/slides/cs/java/com.aspose.slides/zip64mode/#Always) vždy používá rozšíření ZIP64.

Níže uvedený kód ukazuje, jak uložit prezentaci jako soubor PPTX s povolenými rozšířeními ZIP64:

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
Když uložíte s [Zip64Mode.Never](https://reference.aspose.com/slides/cs/java/com.aspose.slides/zip64mode/#Never), je vyvolána výjimka [PptxException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxexception/), pokud nelze prezentaci uložit ve formátu ZIP32.
{{% /alert %}}

## **Uložit prezentace ve formátu Office Open XML s úrovněmi komprese**

Při práci s velkými prezentacemi můžete upravit úroveň komprese, aby byl vyvážený poměr mezi velikostí souboru a časem zpracování. Podle vašich požadavků můžete upřednostnit rychlejší zpracování nebo menší výstupní soubory.

Aspose.Slides poskytuje metodu [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-), která umožňuje určit úroveň komprese používanou při ukládání prezentace ve formátu Office Open XML.

Dostupné úrovně komprese jsou:

- [**None**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#None): Žádná komprese není aplikována. Soubory jsou uloženy tak, jak jsou.
- [**Level1**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level1): Nejrychlejší komprese s nejnižším kompresním poměrem.
- [**Level2**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level2): Rychlejší komprese s mírně lepším poměrem než **Level1**.
- [**Level3**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level3): Lepší komprese než **Level2** s mírně vyšším dopadem na dobu zpracování.
- [**Level4**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level4): Lepší komprese než **Level3**.
- [**Level5**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level5): Vylepšená komprese oproti **Level4** s dalším zvýšením času zpracování.
- [**Level6**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level6): Standardní komprese, která nabízí dobrou rovnováhu mezi rychlostí zpracování a velikostí souboru. Toto je *výchozí úroveň komprese*.
- [**Level7**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level7): Lepší komprese než **Level6** při pomalejším zpracování.
- [**Level8**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level8): Lepší komprese než **Level7**.
- [**Level9**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/compressionlevel/#Level9): Maximální komprese. Produkuje nejmenší velikost souboru za cenu nejdelší doby zpracování.

Následující příklad ukazuje, jak uložit prezentaci jako soubor PPTX *bez komprese*:

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

Tento příklad ukazuje, jak uložit prezentaci jako soubor PPTX s *maximální kompresí*:

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

## **Uložit prezentace bez obnovení miniatury**

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) řídí generování miniatury při ukládání prezentace do PPTX:

- Pokud je nastavena na `true`, miniatura se při ukládání obnoví. Toto je výchozí nastavení.
- Pokud je nastavena na `false`, aktuální miniatura se zachová. Pokud prezentace nemá miniaturu, žádná se nevygeneruje.

V níže uvedeném kódu je prezentace uložena do PPTX bez obnovení její miniatury.

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
Tato možnost pomáhá snížit čas potřebný k uložení prezentace ve formátu PPTX.
{{% /alert %}}

## **Ukládat aktualizace postupu v procentech**

Rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprogresscallback/) se používá prostřednictvím metody `setProgressCallback`, kterou vystavuje rozhraní [ISaveOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isaveoptions/) a abstraktní třída [SaveOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveoptions/). Implementaci [IProgressCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iprogresscallback/) přiřaďte pomocí `setProgressCallback`, abyste získali aktualizace ukládání jako procenta.

Následující útržek kódu ukazuje, jak použít `IProgressCallback`.

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Použijte zde hodnotu procenta postupu.
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
Aspose vyvinulo bezplatnou aplikaci [PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) využívající vlastní API. Aplikace vám umožní rozdělit prezentaci do více souborů tím, že vybrané snímky uloží jako nové soubory PPTX nebo PPT.
{{% /alert %}}

## **Často kladené otázky**

**Je podporováno „rychlé ukládání“ (inkrementální uložení), aby se zapisovaly pouze změny?**

Ne. Ukládání vždy vytvoří celý cílový soubor; inkrementální „rychlé ukládání“ není podporováno.

**Je bezpečné pro vlákna ukládat stejnou instanci Presentation z více vláken?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) **není thread‑safe** (/slides/cs/java/multithreading/); ukládejte ji z jednoho vlákna.

**Co se stane s hypertextovými odkazy a externě odkazovanými soubory při ukládání?**

[Hypertextové odkazy](/slides/cs/java/manage-hyperlinks/) jsou zachovány. Externě odkazované soubory (např. videa pomocí relativních cest) se automaticky nekopírují – ujistěte se, že odkazy na cesty zůstávají přístupné.

**Mohu nastavit/uložit metadata dokumentu (Autor, Název, Společnost, Datum)?**

Ano. Standardní [vlastnosti dokumentu](/slides/cs/java/presentation-properties/) jsou podporovány a budou při uložení zapsány do souboru.