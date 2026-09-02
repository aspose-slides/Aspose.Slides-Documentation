---
title: Ukládání prezentací na Androidu
linktitle: Uložit prezentaci
type: docs
weight: 80
url: /cs/androidjava/save-presentation/
keywords:
- uložit PowerPoint
- uložit OpenDocument
- uložit prezentaci
- uložit snímek
- uložit PPT
- uložit PPTX
- uložit ODP
- prezentace do souboru
- prezentace do proudu
- předdefinovaný typ zobrazení
- striktní formát Office Open XML
- režim Zip64
- obnovování miniatury
- ukládání postupu
- Android
- Java
- Aspose.Slides
description: "Objevte, jak ukládat prezentace v Javě pomocí Aspose.Slides pro Android — exportovat do PowerPointu nebo OpenDocumentu při zachování rozvržení, fontů a efektů."
---
## **Přehled**

[Open Presentations on Android](/slides/cs/androidjava/open-presentation/) popisuje, jak použít třídu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) k otevření prezentace. Tento článek vysvětluje, jak vytvářet a ukládat prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) obsahuje obsah prezentace. Ať už vytváříte prezentaci od nuly nebo upravujete existující, budete ji chtít po dokončení uložit. S Aspose.Slides pro Android můžete ukládat do **souboru** nebo **proudu**. Tento článek vysvětluje různé způsoby ukládání prezentace.

## **Ukládání prezentací do souborů**

Uložte prezentaci do souboru voláním metody `save` třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/). Jako argumenty předáte název souboru a formát uložení. Následující příklad ukazuje, jak uložit prezentaci pomocí Aspose.Slides.

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

## **Ukládání prezentací do proudů**

Můžete uložit prezentaci do proudu předáním výstupního proudu metodě `save` třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/). Prezentaci lze zapisovat do různých typů proudů. V níže uvedeném příkladu vytvoříme novou prezentaci a uložíme ji do souborového proudu.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Uložte prezentaci do proudu.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Ukládání prezentací s předdefinovaným typem zobrazení**

Aspose.Slides umožňuje nastavit počáteční pohled, který PowerPoint použije při otevření vygenerované prezentace, pomocí třídy [ViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/viewproperties/). Použijte metodu [setLastView](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) s hodnotou z výčtu [ViewType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/viewtype/).

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

## **Ukládání prezentací ve striktním formátu Office Open XML**

Aspose.Slides umožňuje uložit prezentaci ve striktním formátu Office Open XML. Použijte třídu [PptxOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxoptions/) a při ukládání nastavte její vlastnost `conformance`. Pokud nastavíte [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), výstupní soubor bude uložen ve striktním formátu Office Open XML.

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

## **Ukládání prezentací ve formátu Office Open XML v režimu Zip64**

Soubor Office Open XML je archiv ZIP, který omezuje nekomprimovanou velikost libovolného souboru, komprimovanou velikost libovolného souboru i celkovou velikost archivu na 4 GB (2^32 bajtů) a maximální počet souborů na 65 535 (2^16‑1). Rozšíření formátu ZIP64 tato omezení zvyšují na 2^64.

Metoda [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) vám umožňuje zvolit, kdy při ukládání souboru Office Open XML použít rozšíření ZIP64.

Tuto metodu lze použít s následujícími režimy:

- [IfNecessary] používá rozšíření ZIP64 pouze pokud prezentace překročí výše uvedená omezení. Toto je výchozí režim.
- [Never] nikdy nepoužívá rozšíření ZIP64.
- [Always] vždy používá rozšíření ZIP64.

Následující kód ukazuje, jak uložit prezentaci jako soubor PPTX s povolenými rozšířeními ZIP64:

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
Pokud ukládáte s [Zip64Mode.Never](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/zip64mode/#Never), bude vyhozena [PptxException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxexception/), pokud není možné prezentaci uložit ve formátu ZIP32.
{{% /alert %}}

## **Ukládání prezentací ve formátu Office Open XML s úrovněmi komprese**

Při práci s velkými prezentacemi můžete upravit úroveň komprese tak, aby byl vyvážený poměr mezi velikostí souboru a dobou zpracování. V závislosti na vašich požadavcích můžete upřednostnit rychlejší zpracování nebo menší výstupní soubory.

Aspose.Slides poskytuje metodu [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-), která umožňuje specifikovat úroveň komprese používanou při ukládání prezentace ve formátu Office Open XML.

K dispozici jsou následující úrovně komprese:

- **None**: Žádná komprese není použita. Soubory jsou uloženy v původní podobě.
- **Level1**: Nejrychlejší komprese s nejnižším kompresním poměrem.
- **Level2**: Rychlejší komprese s mírně lepším poměrem než **Level1**.
- **Level3**: Lepší komprese než **Level2** s mírně vyšším dopadem na čas zpracování.
- **Level4**: Lepší komprese než **Level3**.
- **Level5**: Vylepšená komprese oproti **Level4** s dodatečným časem zpracování.
- **Level6**: Standardní komprese, která nabízí dobrý poměr mezi rychlostí zpracování a velikostí souboru. Toto je *výchozí úroveň komprese*.
- **Level7**: Lepší komprese než **Level6** při pomalejším zpracování.
- **Level8**: Lepší komprese než **Level7**.
- **Level9**: Maximální komprese. Vytvoří nejmenší velikost souboru za cenu nejdelšího času zpracování.

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

## **Ukládání prezentací bez aktualizace miniatury**

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) řídí generování miniatury při ukládání prezentace do PPTX:

- Pokud je nastaven na `true`, miniatura se při ukládání obnoví. Toto je výchozí.
- Pokud je nastaven na `false`, aktuální miniatura se zachová. Pokud prezentace nemá miniaturu, žádná není vygenerována.

V níže uvedeném kódu je prezentace uložena do PPTX bez aktualizace její miniatury.

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
Tato volba pomáhá snížit čas potřebný k uložení prezentace ve formátu PPTX.
{{% /alert %}}

## **Ukládání aktualizací postupu v procentech**

Rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprogresscallback/) se používá prostřednictvím metody `setProgressCallback`, kterou poskytuje rozhraní [ISaveOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isaveoptions/) a abstraktní třída [SaveOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveoptions/). Přidáním implementace [IProgressCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprogresscallback/) pomocí `setProgressCallback` získáte aktualizace o průběhu ukládání v procentech.

Následující úryvky kódu ukazují, jak použít `IProgressCallback`.

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
        // Použijte zde hodnotu procenta postupu.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose vyvinulo bezplatnou aplikaci PowerPoint Splitter pomocí svého API. Aplikace vám umožní rozdělit prezentaci na několik souborů tím, že vybrané snímky uloží jako nové soubory PPTX nebo PPT.
{{% /alert %}}

## **Často kladené otázky**

**Je podporováno „rychlé ukládání“ (inkrementální uložení), takže se zapisují jen změny?**

Ne. Ukládání vždy vytvoří celý cílový soubor; inkrementální „rychlé ukládání“ není podporováno.

**Je bezpečné (thread‑safe) ukládat stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) z více vláken?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) není thread‑safe; ukládejte ji z jediného vlákna.

**Co se stane s hypertextovými odkazy a externě propojenými soubory při ukládání?**

[Hyperlinks](/slides/cs/androidjava/manage-hyperlinks/) jsou zachovány. Externě propojené soubory (např. videa pomocí relativních cest) nejsou automaticky zkopírovány – ujistěte se, že odkazované cesty jsou nadále přístupné.

**Mohu nastavit/uložit metadata dokumentu (Autor, Název, Společnost, Datum)?**

Ano. Standardní [document properties](/slides/cs/androidjava/presentation-properties/) jsou podporovány a při ukládání budou zapsány do souboru.