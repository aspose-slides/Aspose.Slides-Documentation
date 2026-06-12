---
title: Ukládání prezentací v C++
linktitle: Uložit prezentaci
type: docs
weight: 80
url: /cs/cpp/save-presentation/
keywords:
- uložit PowerPoint
- uložit OpenDocument
- uložit prezentaci
- uložit snímek
- uložit PPT
- uložit PPTX
- uložit ODP
- prezentace do souboru
- prezentace do streamu
- předdefinovaný typ zobrazení
- formát Strict Office Open XML
- režim Zip64
- obnovení miniatury
- průběh ukládání
- C++
- Aspose.Slides
description: "Objevte, jak ukládat prezentace v C++ pomocí Aspose.Slides — exportovat do PowerPointu nebo OpenDocumentu při zachování rozvržení, fontů a efektů."
---
## **Přehled**

[Otevření prezentací v C++](/slides/cs/cpp/open-presentation/) popisuje, jak použít třídu [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) k otevření prezentace. Tento článek vysvětluje, jak vytvářet a ukládat prezentace. Třída [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) obsahuje obsah prezentace. Ať už vytváříte prezentaci od nuly nebo upravujete existující, budete ji chtít po dokončení uložit. S Aspose.Slides pro C++ můžete uložit do **souboru** nebo **streamu**. Tento článek popisuje různé způsoby ukládání prezentace.

## **Ukládání prezentací do souborů**

Uložte prezentaci do souboru voláním metody `Save` třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/). Předáte metodě název souboru a formát ukládání. Následující příklad ukazuje, jak uložit prezentaci pomocí Aspose.Slides.

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Proveďte zde nějakou práci...

// Uložte prezentaci do souboru.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Ukládání prezentací do streamů**

Můžete uložit prezentaci do streamu předáním výstupního streamu metodě `Save` třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/). Prezentaci lze zapisovat do mnoha typů streamů. V níže uvedeném příkladu vytvoříme novou prezentaci a uložíme ji do souborového streamu.

```cpp
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Uložte prezentaci do streamu.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Ukládání prezentací s předdefinovaným typem zobrazení**

Aspose.Slides vám umožňuje nastavit počáteční zobrazení, které PowerPoint použije při otevření vygenerované prezentace, prostřednictvím třídy [ViewProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/). Použijte metodu [set_LastView](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewproperties/set_lastview/) s hodnotou z výčtu [ViewType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/viewtype/).

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ukládání prezentací ve formátu Strict Office Open XML**

Aspose.Slides vám umožňuje uložit prezentaci ve formátu Strict Office Open XML. Použijte třídu [PptxOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pptxoptions/) a při ukládání nastavte její vlastnost conformance. Pokud nastavíte `Conformance.Iso29500_2008_Strict`, výstupní soubor bude uložen ve formátu Strict Office Open XML.

Níže uvedený příklad vytvoří prezentaci a uloží ji ve formátu Strict Office Open XML.

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
auto presentation = MakeObject<Presentation>();

// Uložte prezentaci ve formátu Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Ukládání prezentací ve formátu Office Open XML v režimu Zip64**

Soubor Office Open XML je archiv ZIP, který uvaluje limity 4 GB (2^32 bajtů) na nekomprimovanou velikost libovolného souboru, komprimovanou velikost libovolného souboru i celkovou velikost archivu a také omezuje archiv na 65 535 (2^16‑1) souborů. Rozšíření formátu ZIP64 tato omezení zvyšují na 2^64.

Metoda [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) vám umožňuje zvolit, kdy použít rozšíření ZIP64 při ukládání souboru Office Open XML.

Tato metoda může být použita s následujícími režimy:

- `IfNecessary` používá rozšíření ZIP64 pouze pokud prezentace překročí výše uvedená omezení. Toto je výchozí režim.
- `Never` nikdy nevyužívá rozšíření ZIP64.
- `Always` vždy využívá rozšíření ZIP64.

Následující kód demonstruje, jak uložit prezentaci jako PPTX s povolenými rozšířeními ZIP64:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Když ukládáte s `Zip64Mode.Never`, je vyhozena [PptxException](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pptxexception/), pokud prezentaci nelze uložit ve formátu ZIP32.
{{% /alert %}}

## **Ukládání prezentací bez obnovení miniatury**

Metoda [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) řídí generování miniatury při ukládání prezentace do PPTX:

- Pokud je nastavena na `true`, miniatura se během ukládání obnoví. Toto je výchozí nastavení.
- Pokud je nastavena na `false`, aktuální miniatura je zachována. Pokud prezentace nemá miniaturu, nebude žádná generována.

V níže uvedeném kódu je prezentace uložena do PPTX bez obnovení její miniatury.

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Tato volba pomáhá zkrátit čas potřebný k uložení prezentace ve formátu PPTX.
{{% /alert %}}

## **Získávání aktualizací průběhu ukládání v procentech**

Rozhraní [IProgressCallback](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iprogresscallback/) se používá prostřednictvím metody `set_ProgressCallback`, která je součástí rozhraní [ISaveOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/isaveoptions/) a abstraktní třídy [SaveOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveoptions/). Přiřaďte implementaci [IProgressCallback] pomocí `set_ProgressCallback`, abyste získali aktualizace průběhu ukládání v procentech.

Následující úryvky kódu ukazují, jak použít `IProgressCallback`.

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Použijte zde hodnotu procenta postupu.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose vyvinulo [bezplatnou aplikaci PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) pomocí svého vlastního API. Aplikace vám umožní rozdělit prezentaci do více souborů uložením vybraných snímků jako nové soubory PPTX nebo PPT.
{{% /alert %}}

## **Často kladené otázky**

**Je podporováno "rychlé ukládání" (inkrementální ukládání), aby se zapisovaly jen změny?**

Ne. Ukládání při každém uložení vytvoří celý cílový soubor; inkrementální "rychlé ukládání" není podporováno.

**Je bezpečné (thread‑safe) uložit stejnou instanci Presentation z více vláken?**

Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) [není thread‑safe](/slides/cs/cpp/multithreading/); ukládejte ji z jediného vlákna.

**Co se stane s hypertextovými odkazy a externě odkazovanými soubory při ukládání?**

[Hyperlinky](/slides/cs/cpp/manage-hyperlinks/) jsou zachovány. Externě odkazované soubory (např. videa pomocí relativních cest) nejsou automaticky zkopírovány – ujistěte se, že odkazované cesty zůstávají dostupné.

**Mohu nastavit/uložit metadata dokumentu (Autor, Název, Společnost, Datum)?**

Ano. Standardní [vlastnosti dokumentu](/slides/cs/cpp/presentation-properties/) jsou podporovány a budou při ukládání zapsány do souboru.