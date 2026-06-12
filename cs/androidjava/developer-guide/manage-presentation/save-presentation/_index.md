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
- formát Strict Office Open XML
- režim Zip64
- obnovení náhledu
- ukládání postupu
- Android
- Java
- Aspose.Slides
description: "Objevte, jak ukládat prezentace v Javě pomocí Aspose.Slides pro Android — exportovat do PowerPointu nebo OpenDocumentu při zachování rozvržení, písem a efektů."
---
## **Přehled**

[Open Presentations on Android](/slides/cs/androidjava/open-presentation/) popisuje, jak použít třídu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) k otevření prezentace. Tento článek vysvětluje, jak vytvořit a uložit prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) obsahuje obsah prezentace. Ať už vytváříte prezentaci od nuly nebo upravujete existující, budete ji chtít po dokončení uložit. S Aspose.Slides pro Android můžete uložit do **souboru** nebo **proudu**. Tento článek popisuje různé způsoby uložení prezentace.

## **Uložit prezentace do souborů**

Uložit prezentaci do souboru zavoláním metody `save` třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/). Do metody předáte název souboru a formát uložení. Následující příklad ukazuje, jak uložit prezentaci pomocí Aspose.Slides.

```java
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

## **Uložit prezentace do proudů**

Můžete uložit prezentaci do proudu předáním výstupního proudu metodě `save` třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/). Prezentaci lze zapsat do různých typů proudů. V níže uvedeném příkladu vytvoříme novou prezentaci a uložíme ji do souborového proudu.

```java
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

## **Uložit prezentace s předdefinovaným typem zobrazení**

Aspose.Slides vám umožňuje nastavit počáteční zobrazení, které PowerPoint použije při otevření vygenerované prezentace, prostřednictvím třídy [ViewProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/viewproperties/). Použijte metodu [setLastView](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) s hodnotou z výčtu [ViewType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/viewtype/).

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Uložit prezentace ve formátu Strict Office Open XML**

Aspose.Slides vám umožňuje uložit prezentaci ve formátu Strict Office Open XML. Použijte třídu [PptxOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxoptions/) a při ukládání nastavte její vlastnost conformance. Pokud nastavíte [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), výstupní soubor bude uložen ve formátu Strict Office Open XML.

Níže uvedený příklad vytvoří prezentaci a uloží ji ve formátu Strict Office Open XML.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation();
try {
    // Uložte prezentaci ve formátu Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Uložit prezentace ve formátu Office Open XML v režimu Zip64**

Soubor Office Open XML je archiv ZIP, který omezuje nekomprimovanou velikost libovolného souboru, komprimovanou velikost libovolného souboru i celkovou velikost archivu na 4 GB (2^32 bajtů) a také omezuje archiv na 65 535 (2^16‑1) souborů. Rozšíření formátu ZIP64 tato omezení zvyšují na 2^64.

Metoda [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) vám umožňuje zvolit, kdy použít rozšíření ZIP64 při ukládání souboru Office Open XML.

Tuto metodu lze použít s následujícími režimy:

- [IfNecessary](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/zip64mode/#IfNecessary) používá rozšíření ZIP64 pouze pokud prezentace překročí výše uvedená omezení. Toto je výchozí režim.
- [Never](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/zip64mode/#Never) nikdy nepoužívá rozšíření ZIP64.
- [Always](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/zip64mode/#Always) vždy používá rozšíření ZIP64.

Níže uvedený kód ukazuje, jak uložit prezentaci jako PPTX s povolenými rozšířeními formátu ZIP64:

```java
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
Když ukládáte s Zip64Mode.Never, je vyvolána výjimka [PptxException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxexception/), pokud prezentaci nelze uložit ve formátu ZIP32.
{{% /alert %}}

## **Uložit prezentace bez aktualizace náhledu**

Metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) řídí generování náhledu při ukládání prezentace do PPTX:

- Pokud je nastavena na `true`, náhled je při ukládání obnoven. Toto je výchozí nastavení.
- Pokud je nastavena na `false`, aktuální náhled je zachován. Pokud prezentace nemá náhled, žádný není vytvořen.

V níže uvedeném kódu je prezentace uložena do PPTX bez obnovení náhledu.

```java
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

## **Ukládat průběžné aktualizace v procentech**

Rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprogresscallback/) se používá prostřednictvím metody `setProgressCallback` vystavené rozhraním [ISaveOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isaveoptions/) a abstraktní třídy [SaveOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveoptions/). Přiřaďte implementaci [IProgressCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprogresscallback/) pomocí `setProgressCallback`, abyste dostávali aktualizace postupu ukládání v procentech.

Níže uvedené úryvky kódu ukazují, jak používat `IProgressCallback`.

```java
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
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Použijte zde hodnotu procenta postupu.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose vyvinulo bezplatnou aplikaci PowerPoint Splitter využívající své vlastní API. Aplikace vám umožní rozdělit prezentaci do několika souborů uložením vybraných snímků jako nové soubory PPTX nebo PPT.
{{% /alert %}}

## **Často kladené otázky**

**Je podporováno „rychlé ukládání“ (inkrementální ukládání), takže se zapisují jen změny?**

Ne. Ukládání při každém zápisu vytvoří celý cílový soubor; inkrementální „rychlé ukládání“ není podporováno.

**Je bezpečné z hlediska vláken ukládat stejnou instanci Presentation z více vláken?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) není thread‑safe; ukládejte ji z jednoho vlákna.

**Co se stane s hypertextovými odkazy a externě odkazovanými soubory při ukládání?**

[Hyperlinks](/slides/cs/androidjava/manage-hyperlinks/) jsou zachovány. Externě odkazované soubory (např. videa pomocí relativních cest) nejsou automaticky zkopírovány – zajistěte, aby referencované cesty zůstaly dostupné.

**Mohu nastavit/uložit metadata dokumentu (Autor, Název, Společnost, Datum)?**

Ano. Standardní [document properties](/slides/cs/androidjava/presentation-properties/) jsou podporovány a při ukládání budou zapsány do souboru.