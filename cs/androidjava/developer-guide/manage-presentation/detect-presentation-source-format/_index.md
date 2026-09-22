---
title: Určete původní formát prezentace na Androidu
linktitle: Zdrojový formát
type: docs
weight: 35
url: /cs/androidjava/detect-presentation-source-format/
keywords:
- zdrojový formát
- detekce formátu prezentace
- PowerPoint
- OpenDocument
- prezentace
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Přečtěte původní formát načtené prezentace na Androidu pomocí Aspose.Slides pro Android v Javě, porovnejte API pro detekci a pracujte se soubory, streamy a staršími formáty."
---
## **Přehled**

Po načtení prezentace zavolejte metodu [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSourceFormat--) a určete její původní formát. Metoda je také dostupná přes [IPresentation.getSourceFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--). Použijte ji, když další zpracování závisí na formátu, ze kterého byla aktuální instance načtena.

Cílový formát se liší od [SaveFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/) vybraného pro výstupní soubor. Uložení do jiného formátu nemění zdrojový formát existující instance.

Příklady používají Javu a cesty k souborům. Na Androidu nahraďte ukázkové cesty cestami do úložiště přístupného aplikaci, například do interního adresáře souborů vaší aplikace.

## **Načtení zdrojového formátu souboru**

Tento příklad vyžaduje existující soubor `sample.pptx`. Načte soubor a vybere politiku zpracování aplikace pomocí [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSourceFormat--), místo názvu souboru. Změňte vstupní cestu, pokud chcete vyzkoušet jiné formáty. Příklad vypíše vybranou politiku; nahraďte zprávy logikou své aplikace.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt;
        case SourceFormat.Pps;
        case SourceFormat.Pot;
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx;
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

Třída [SourceFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sourceformat/) definuje celočíselné konstanty, které rozlišují následující formáty prezentací. Níže uvedené přípony jsou konvenční, nejedná se o rekonstrukci původního názvu souboru.

| Hodnota SourceFormat | Přípona | Formát |
| --- | --- | --- |
| `Ppt` | `.ppt` | Prezentace PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Prezentace Office Open XML |
| `Pptm` | `.pptm` | Prezentace Office Open XML s makry |
| `Pps` | `.pps` | Prezentace PowerPoint 97–2003 (snímek) |
| `Ppsx` | `.ppsx` | Prezentace Office Open XML (snímek) |
| `Ppsm` | `.ppsm` | Prezentace Office Open XML s makry (snímek) |
| `Pot` | `.pot` | Šablona PowerPoint 97–2003 |
| `Potx` | `.potx` | Šablona Office Open XML |
| `Potm` | `.potm` | Šablona Office Open XML s makry |
| `Odp` | `.odp` | Prezentace OpenDocument |
| `Otp` | `.otp` | Šablona prezentace OpenDocument |
| `Fodp` | `.fodp` | Prezentace Flat XML ODF |
| `Xml` | `.xml` | Prezentace PowerPoint XML |

## **Načtení zdrojového formátu ze streamu**

Tento příklad vyžaduje existující soubor `sample.pps`. Načtení jeho bajtů do paměťového streamu simuluje vstup, který není spojen s názvem souboru, například hodnotu z databáze nebo nahraný pole bajtů. Konstruktor [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) přijímá pouze stream.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
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

PPT, PPS a POT používají stejný základní binární formát. Při načítání z cesty může přípona pomoci rozlišit snímkovou prezentaci nebo šablonu. Bez názvu souboru může být starý obsah PPS a POT hlášen jako `SourceFormat.Ppt`; příklad PPS výše vypisuje celočíselnou hodnotu `SourceFormat.Ppt`.

Pokud vaše aplikace musí zachovat toto rozlišení, uchovejte původní název souboru nebo metadata podtypu odděleně. Přípona je užitečná nápověda pro tyto starší podtypy, ale neměla by být jediným základem pro identifikaci libovolného obsahu prezentace.

## **Porovnání detekce před a po načtení**

Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) a [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) když potřebujete soubor zkontrolovat před načtením kompletního objektového modelu prezentace. Použijte [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSourceFormat--) pokud instance již existuje.

Tento příklad vyžaduje `sample.pptx` a vypisuje celočíselné hodnoty `LoadFormat.Pptx` a `SourceFormat.Pptx`. V produkci zvolte API odpovídající vašemu stupni zpracování; již načtená prezentace nepotřebuje druhou kontrolu jen kvůli získání svého zdrojového formátu.

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

Výsledky používají konstanty z různých tříd: [LoadFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadformat/) a [SourceFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sourceformat/). Neměřte jejich číselné hodnoty ani nepředpokládejte, že každý formát má identické výsledky detekce. PowerPoint XML může být před načtením hlášen jako `LoadFormat.Unknown` a po načtení jako `SourceFormat.Xml`.

## **Udržujte zdrojové a výstupní formáty oddělené**

Tento příklad vyžaduje `sample.pptx` a zapisuje `converted.odp`. Vypíše celočíselnou hodnotu `SourceFormat.Pptx` jak před, tak po uložení původní instance. Pouze nová instance načtená z výstupního ODP souboru hlásí `Odp`.

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

Prezentace vytvořená od nuly pomocí `new Presentation()` hlásí `SourceFormat.Pptx`. Nemá vstupní soubor: jde o výchozí hodnotu nově vytvořené instance, ne o důkaz, že byl načten soubor PPTX. Sledujte, zda vaše aplikace vytvořila nebo načetla instanci, pokud je toto rozlišení pro vás důležité.

## **Mapování zdrojového formátu na příponu**

Následující příklad vyžaduje `sample.pptx`. Mapuje každou aktuálně podporovanou hodnotu [SourceFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sourceformat/) na konvenční příponu, aniž by parsoval vstupní název souboru. Náhradní řešení zabraňuje tichému přiřazení přípony neznámé hodnotě.

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

Toto mapování nepřevádí soubor ani neobnovuje starý podtyp PPS/POT, který byl ztracen při načítání ze streamu. Pro skutečné ukládání vyberte explicitně [SaveFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/) nebo použijte konverzi uvedenou v [Save Presentations in Their Original Format](/slides/cs/androidjava/save-presentation/#save-presentations-in-their-original-format).

## **Ověření formátů uložením a opětovným načtením**

Tento samostatný příklad vytvoří prezentaci a zapíše tři soubory do pracovního adresáře, přepisuje soubory se stejnými názvy. Každý výstup znovu otevře jak pomocí cesty, tak přes paměťový stream. Pro PPTX a ODP oba způsoby hlásí uložený formát. Pro PPS načtení z cesty hlásí `Pps`, zatímco načtení stejných bajtů bez názvu souboru hlásí `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
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

Následující tabulka shrnuje identifikaci zdrojového formátu pro prezentace s odpovídajícími příponami. Názvy označují konstanty; příklady v Javě vypisují jejich celočíselné hodnoty:

| Uložený formát | SourceFormat z cesty k souboru | SourceFormat z bezejmenného streamu |
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

Obsah PPS/POT je pro bezejmenné streamy identifikován jako `Ppt`. Tabulka popisuje identifikaci formátů, nikoli zachování všech vlastností prezentace během konverze.

## **Často kladené otázky**

**Změní uložení do ODP zdrojový formát prezentace načtené z PPTX?**

Ne. Existující instance stále uvádí `Pptx`. Instance načtená ze souboru ODP, který byl uložen, uvádí `Odp`.

**Dokáže stream vždy rozlišit starší prezentaci, prezentaci typu snímek a šablonu?**

Ne. PPT, PPS a POT sdílejí binární formát. Uchovávejte název souboru nebo metadata podtypu odděleně, pokud je toto rozlišení vyžadováno.

**Které API mám použít, pokud je prezentace již načtena?**

Přečtěte si [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSourceFormat--). Pro kontrolu před načtením použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-).