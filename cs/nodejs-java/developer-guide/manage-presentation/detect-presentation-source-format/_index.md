---
title: Určete původní formát prezentace v Node.js
linktitle: Zdrojový formát
type: docs
weight: 35
url: /cs/nodejs-java/detect-presentation-source-format/
keywords:
- zdrojový formát
- detekce formátu prezentace
- PowerPoint
- OpenDocument
- prezentace
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Přečtěte původní formát načtené prezentace v Node.js pomocí Aspose.Slides pro Node.js prostřednictvím Javy, porovnejte API pro detekci a pracujte se soubory, streamy a staršími formáty."
---
## **Přehled**

Po načtení prezentace zavolejte metodu [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getSourceFormat), abyste zjistili její původní formát. Použijte ji, když další zpracování závisí na formátu, ze kterého byla aktuální instance načtena.

Zdrojový formát se liší od [SaveFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveformat/) vybraného pro výstupní soubor. Uložení do jiného formátu nemění zdrojový formát existující instance.

## **Čtení zdrojového formátu souboru**

Tento příklad vyžaduje existující soubor `sample.pptx`. Načte soubor a vybere zásadu zpracování aplikace pomocí [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getSourceFormat), místo názvu souboru. Změňte vstupní cestu, abyste vyzkoušeli jiné formáty. Příklad vypíše vybranou zásadu; nahraďte zprávy logikou vaší aplikace.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Rozpoznání podporovaných hodnot**

Třída [SourceFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sourceformat/) definuje celočíselné konstanty, které rozlišují následující formáty prezentací. Níže uvedené přípony jsou konvenční, nejedná se o rekonstrukci původního názvu souboru.

| Hodnota SourceFormat | Přípona | Formát |
| --- | --- | --- |
| `Ppt` | `.ppt` | Prezentace PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Prezentace Office Open XML |
| `Pptm` | `.pptm` | Prezentace Office Open XML s povolenými makry |
| `Pps` | `.pps` | Prezentace PowerPoint 97–2003 (prezentace) |
| `Ppsx` | `.ppsx` | Prezentace Office Open XML (prezentace) |
| `Ppsm` | `.ppsm` | Prezentace Office Open XML s povolenými makry (prezentace) |
| `Pot` | `.pot` | Šablona PowerPoint 97–2003 |
| `Potx` | `.potx` | Šablona Office Open XML |
| `Potm` | `.potm` | Šablona Office Open XML s povolenými makry |
| `Odp` | `.odp` | Prezentace OpenDocument |
| `Otp` | `.otp` | Šablona prezentace OpenDocument |
| `Fodp` | `.fodp` | Prezentace Flat XML ODF |
| `Xml` | `.xml` | Prezentace PowerPoint XML |

## **Čtení zdrojového formátu ze streamu**

Tento příklad vyžaduje existující soubor `sample.pps`. Čtení jeho bajtů do paměťového streamu simuluje vstup získaný bez názvu souboru, například jako hodnota v databázi nebo nahraný pole bajtů. Konstruktor [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) přijímá pouze stream.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS a POT používají stejný podkladový binární formát. Při načítání podle cesty souboru může přípona pomoci rozlišit prezentaci nebo šablonu. Bez názvu souboru může být starší obsah PPS a POT hlášen jako `SourceFormat.Ppt`; výše uvedený příklad PPS vypisuje celočíselnou hodnotu `SourceFormat.Ppt`.

Pokud vaše aplikace musí zachovat toto rozlišení, uchovejte původní název souboru nebo metadata podtypu odděleně. Přípona je užitečná nápověda pro tyto starší podtypy, ale neměla by být jediným základem pro identifikaci libovolného obsahu prezentace.

## **Porovnání detekce před a po načtení**

Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) a [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat), když potřebujete soubor prozkoumat před načtením úplného objektového modelu prezentace. Použijte [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getSourceFormat), pokud instance již existuje.

Tento příklad vyžaduje `sample.pptx` a vypisuje celočíselné hodnoty `LoadFormat.Pptx` a `SourceFormat.Pptx`. Ve výrobním prostředí zvolte API odpovídající vašemu stupni zpracování; již načtená prezentace nepotřebuje druhou kontrolu pouze za účelem získání jejího zdrojového formátu.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Výsledky používají konstanty z různých tříd: [LoadFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadformat/) a [SourceFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sourceformat/). Nekombinujte jejich číselné hodnoty ani neberte, že každý formát má identické výsledky detekce. PowerPoint XML může být před načtením hlášen jako `LoadFormat.Unknown` a po načtení jako `SourceFormat.Xml`.

## **Udržujte zdrojové a výstupní formáty oddělené**

Tento příklad vyžaduje `sample.pptx` a zapisuje `converted.odp`. Vypisuje celočíselnou hodnotu `SourceFormat.Pptx` jak před, tak po uložení původní instance. Pouze nová instance načtená z výstupu ODP hlásí `Odp`.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Prezentace vytvořená od nuly pomocí `new Presentation()` hlásí `SourceFormat.Pptx`. Nemá vstupní soubor: jedná se o výchozí hodnotu nově vytvořené instance, ne o důkaz, že byl načten soubor PPTX. Sledujte, zda vaše aplikace vytvořila nebo načetla instanci, pokud je toto rozlišení důležité.

## **Mapování zdrojového formátu na příponu**

Následující příklad vyžaduje `sample.pptx`. Mapuje každou aktuálně podporovanou hodnotu [SourceFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sourceformat/) na konvenční příponu, aniž by analyzoval vstupní název souboru. Náhradní řešení zabraňuje tišému přiřazení přípony neznámé hodnotě.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Toto mapování neprovádí konverzi souboru ani neobnovuje starší podtyp PPS/POT ztracený při načítání ze streamu. Pro skutečné uložení vyberte [SaveFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/saveformat/) explicitně nebo použijte konverzi uvedenou v [Uložení prezentací v jejich původním formátu](/slides/cs/nodejs-java/save-presentation/#save-presentations-in-their-original-format).

## **Ověření formátů uložením a opětovným načtením**

Tento samostatný příklad vytvoří prezentaci a zapíše tři soubory do pracovního adresáře, přepisuje soubory se stejnými názvy. Každý výstup otevře znovu jak podle cesty, tak přes paměťový stream. Pro PPTX a ODP oba způsoby hlásí uložený formát. Pro PPS načítání podle cesty hlásí `Pps`, zatímco načtení stejných bajtů bez názvu souboru hlásí `Ppt`.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Následující tabulka shrnuje identifikaci zdrojového formátu pro prezentace se shodnými příponami. Názvy představují konstanty; příklady v JavaScriptu vypisují jejich celočíselné hodnoty:

| Uložený formát | SourceFormat z cesty souboru | SourceFormat z bezejmenného streamu |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT obsah je identifikován jako `Ppt` pro bezejmenné streamy. Tabulka popisuje identifikaci formátu, nikoli zachování všech funkcí prezentace během konverze.

## **FAQ**

**Změní uložení do ODP zdrojový formát prezentace načtené z PPTX?**

Ne. Existující instance stále hlásí `Pptx`. Instance načtená z uloženého souboru ODP hlásí `Odp`.

**Umí stream vždy rozlišit starší prezentaci, prezentaci (slide show) a šablonu?**

Ne. PPT, PPS a POT sdílejí binární formát. Uchovejte název souboru nebo metadata podtypu odděleně, pokud je toto rozlišení vyžadováno.

**Které API mám použít, pokud je prezentace již načtena?**

Použijte [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getSourceFormat). Pro kontrolu před načtením použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo).