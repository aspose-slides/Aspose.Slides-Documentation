---
title: Určete původní formát prezentace v Javě
linktitle: Formát zdroje
type: docs
weight: 35
url: /cs/java/detect-presentation-source-format/
keywords:
- formát zdroje
- detekce formátu prezentace
- PowerPoint
- OpenDocument
- prezentace
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Přečtěte si původní formát načtené prezentace v Javě s knihovnou Aspose.Slides pro Javu, porovnejte API pro detekci a pracujte se soubory, proudy a staršími formáty."
---
## **Přehled**

Po načtení prezentace zavolejte metodu [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSourceFormat--) k určení jejího původního formátu. Metoda je také dostupná přes [IPresentation.getSourceFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getSourceFormat--). Použijte ji, když následné zpracování závisí na formátu, ze kterého byla aktuální instance načtena.

Zdrojový formát se liší od [SaveFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/) vybraného pro výstupní soubor. Uložení do jiného formátu nemění zdrojový formát existující instance.

## **Čtení zdrojového formátu souboru**

Tento příklad vyžaduje existující soubor `sample.pptx`. Načte soubor a vybere politiku zpracování aplikace pomocí [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSourceFormat--), místo názvu souboru. Změňte vstupní cestu, abyste vyzkoušeli jiné formáty. Příklad vypisuje vybranou politiku; nahraďte zprávy logikou vaší aplikace.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Rozpoznání podporovaných hodnot**

Třída [SourceFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sourceformat/) definuje celočíselné konstanty, které rozlišují následující formáty prezentací. Níže uvedené přípony jsou konvenční, nikoli rekonstrukce původního názvu souboru.

| Hodnota SourceFormat | Přípona | Formát |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 presentation |
| `Pptx` | `.pptx` | Office Open XML presentation |
| `Pptm` | `.pptm` | Macro-enabled Office Open XML presentation |
| `Pps` | `.pps` | PowerPoint 97–2003 slide show |
| `Ppsx` | `.ppsx` | Office Open XML slide show |
| `Ppsm` | `.ppsm` | Macro-enabled Office Open XML slide show |
| `Pot` | `.pot` | PowerPoint 97–2003 template |
| `Potx` | `.potx` | Office Open XML template |
| `Potm` | `.potm` | Macro-enabled Office Open XML template |
| `Odp` | `.odp` | OpenDocument presentation |
| `Otp` | `.otp` | OpenDocument presentation template |
| `Fodp` | `.fodp` | Flat XML ODF presentation |
| `Xml` | `.xml` | PowerPoint XML presentation |

## **Čtení zdrojového formátu proudu**

Tento příklad vyžaduje existující soubor `sample.pps`. Čtení jeho bajtů do paměťového proudu modeluje vstup bez názvu souboru, například hodnotu z databáze nebo nahraný bajtový pole. Konstruktor [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) přijímá pouze proud.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS a POT používají stejný základní binární formát. Při načítání podle cesty k souboru může přípona pomoci rozlišit prezentaci, slideshow nebo šablonu. Bez názvu souboru může být starší obsah PPS a POT hlášen jako `SourceFormat.Ppt`; výše uvedený příklad PPS vypíše celočíselnou hodnotu `SourceFormat.Ppt`.

Pokud vaše aplikace musí zachovat toto rozlišení, uložte původní název souboru nebo metadata podtypu odděleně. Přípona je užitečná nápověda pro tyto starší podtypy, ale neměla by být jediným základem pro identifikaci libovolného obsahu prezentace.

## **Porovnání detekce před a po načtení**

Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) a [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) když potřebujete prověřit soubor před načtením jeho kompletního objektového modelu. Použijte [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSourceFormat--) když již instance existuje.

Tento příklad vyžaduje `sample.pptx` a vypisuje celočíselné hodnoty `LoadFormat.Pptx` a `SourceFormat.Pptx`. Ve výrobě zvolte API vhodné pro vaše zpracovatelské stadium; již načtená prezentace nepotřebuje druhou kontrolu pouze kvůli získání jejího zdrojového formátu.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Výsledky používají konstanty z různých tříd: [LoadFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadformat/) a [SourceFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sourceformat/). Nekombinujte jejich číselné hodnoty ani nepředpokládejte, že každý formát má identické detekční výsledky. PowerPoint XML může být před načtením hlášen jako `LoadFormat.Unknown` a po načtení jako `SourceFormat.Xml`.

## **Udržujte zdrojové a výstupní formáty oddělené**

Tento příklad vyžaduje `sample.pptx` a zapisuje `converted.odp`. Vypisuje celočíselnou hodnotu `SourceFormat.Pptx` jak před, tak po uložení původní instance. Pouze nová instance načtená z výstupu ODP hlásí `Odp`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Prezentace vytvořená od nuly pomocí `new Presentation()` hlásí `SourceFormat.Pptx`. Nemá vstupní soubor: toto je výchozí hodnota pro nově vytvořenou instanci, nikoli důkaz, že byl načten soubor PPTX. Sledujte, zda vaše aplikace vytvořila nebo načetla instanci, pokud je toto rozlišení důležité.

## **Mapování zdrojového formátu na příponu**

Následující příklad vyžaduje `sample.pptx`. Mapuje každou aktuálně podporovanou hodnotu [SourceFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sourceformat/) na konvenční příponu, aniž by analyzoval vstupní název souboru. Náhradní řešení zabraňuje tichému přiřazení přípony neznámé hodnotě.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Toto mapování nepřevádí soubor ani neobnovuje starý podtyp PPS/POT ztracený během načítání proudu. Pro skutečné ukládání vyberte výslovně [SaveFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/) nebo použijte konverzi ukázanou v [Save Presentations in Their Original Format](/slides/cs/java/save-presentation/#save-presentations-in-their-original-format).

## **Ověření formátů uložením a opětovným otevřením**

Tento samostatný příklad vytvoří prezentaci a zapíše tři soubory do pracovního adresáře, přepisuje soubory se stejnými názvy. Každý výstup znovu otevře jak podle cesty, tak přes paměťový proud. Pro PPTX a ODP oba způsoby hlásí uložený formát. Pro PPS načtení podle cesty hlásí `Pps`, zatímco načtení stejných bajtů bez názvu souboru hlásí `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Následující tabulka shrnuje identifikaci zdrojového formátu pro prezentace se shodnými příponami. Jména představují konstanty; Java příklady vypisují jejich celočíselné hodnoty:

| Uložený formát | SourceFormat ze cesty k souboru | SourceFormat z bezejmenného proudu |
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

Obsah PPS/POT je pro bezejmenné proudy identifikován jako `Ppt`. Tabulka popisuje identifikaci formátů, ne zachování všech vlastností prezentace během konverze.

## **Často kladené otázky**

**Mění uložení do ODP zdrojový formát prezentace načtené z PPTX?**

Ne. Existující instance stále hlásí `Pptx`. Instance načtená ze souboru ODP hlásí `Odp`.

**Dokáže proud vždy rozlišit starou prezentaci, slideshow a šablonu?**

Ne. PPT, PPS a POT sdílejí binární formát. Uchovávejte název souboru nebo metadata podtypu odděleně, pokud je toto rozlišení vyžadováno.

**Které API mám použít, pokud je prezentace již načtena?**

Přečtěte si [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSourceFormat--). Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) pro inspekci před načtením.