---
title: Začínáme
type: docs
weight: 10
url: /cs/java/getting-started/
keywords:
- začínání
- systémové požadavky
- instalace
- první prezentace
- Maven
- zpracování PPT
- zpracování PPTX
- zpracování ODP
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Cesta od nového Java projektu k první uložené prezentaci s Aspose.Slides: zkontrolujte požadavky, přidejte knihovnu z Maven repozitáře Aspose, spusťte první program a pokračujte běžnými úkoly."
---
## **Přehled**

Projděte čtyřmi níže uvedenými kroky v pořadí. Každý krok uvádí, co je třeba udělat, a odkazuje na článek s podrobnostmi. Hodnocení, licencování a podpora jsou popsány po krocích.

## **Krok 1: Zkontrolujte systémové požadavky**

Aspose.Slides for Java je jediný soubor JAR bez nativního kódu, takže běží na libovolném operačním systému, který má podporované prostředí Java. [Systémové požadavky](/slides/cs/java/system-requirements/) uvádí podporované operační systémy a verze Javy. Projekt a příkazy v následujících krocích vyžadují JDK 11 nebo novější a pro cestu Maven i [Apache Maven](https://maven.apache.org/install.html).

## **Krok 2: Přidejte knihovnu do svého projektu**

Aspose.Slides for Java je publikována v Maven repozitáři společnosti Aspose, nikoli v Maven Central. Zvolte jednu z těchto cest:

- S Maven: deklarujte repozitář `https://releases.aspose.com/java/repo/` ve svém *pom.xml* a přidejte závislost `com.aspose:aspose-slides` s klasifikátorem `jdk16`.
- Bez Maven: stáhněte soubor JAR, jehož název končí na *-jdk16.jar*, z repozitáře a umístěte jej na class path.

V Linuxu také nainstalujte knihovnu fontconfig a alespoň jedno písmo. Bez nich selže ukládání prezentace s chybou "Fontconfig head is null, check your fonts or fonts configuration".

[Instalace](/slides/cs/java/installation/) poskytuje položky *pom.xml*, stažení JAR a linuxový příkaz.

## **Krok 3: Vytvořte svou první prezentaci**

[rychlý start na domovské stránce Aspose.Slides for Java](/slides/cs/java/#your-first-presentation) je kompletní Maven projekt: soubor *pom.xml* a program, který přidá tvar mraku s textem do snímku a uloží prezentaci jako soubor PPTX. Spustíte jej pomocí `mvn compile exec:java`. [Vytvořit prezentace](/slides/cs/java/create-presentation/) vysvětluje stejný program krok za krokem. Pro otevření existující prezentace a uložení v jiném formátu viz [Otevřít prezentace](/slides/cs/java/open-presentation/) a [Uložit prezentace](/slides/cs/java/save-presentation/).

## **Krok 4: Pokračujte s běžnými úkoly**

- [Otevřít prezentaci](/slides/cs/java/open-presentation/)
- [Uložit prezentaci](/slides/cs/java/save-presentation/)
- [Převést prezentaci do PDF](/slides/cs/java/convert-powerpoint-to-pdf/)
- [Vykreslit snímky jako obrázky](/slides/cs/java/convert-slide/)
- [Upravit text v prezentaci](/slides/cs/java/manage-text/)
- [Příklady podle prvku snímku](/slides/cs/java/examples/)

## **Vyhodnocení a licence**

Bez licence Aspose.Slides běží v režimu hodnocení: přidá vodoznak ke každému snímku, který uloží, a zkrátí text, který váš kód načítá z prezentací.

- [Vyhodnotit Aspose.Slides](/slides/cs/java/evaluate-aspose-slides/) popisuje omezení hodnocení a jak požádat o dočasnou licenci.
- [Licencování](/slides/cs/java/licensing/) ukazuje, jak použít licenci ze souboru nebo proudu.
- [Měřené licencování](/slides/cs/java/metered-licensing/) popisuje licencování, které je účtováno na základě využití.
- [Podporované formáty souborů](/slides/cs/java/supported-file-formats/) uvádí formáty, které Aspose.Slides může načíst a uložit.

## **Získat pomoc**

[Technická podpora](/slides/cs/java/technical-support/) vysvětluje, jak položit otázku na [bezplatné fórum podpory](https://forum.aspose.com/c/slides/cs/11) a co zahrnout při hlášení problému.

## **Často kladené otázky**

**Potřebuji mít nainstalovaný Microsoft PowerPoint?**

Ne. Aspose.Slides čte a zapisuje soubory prezentací samostatně a nepoužívá PowerPoint, takže běží i na serverech a v Linuxu.

**Proč Maven nenajde Aspose.Slides for Java?**

Knihovna není v Maven Central. Deklarujte repozitář Aspose ve svém *pom.xml*, jak je ukázáno v [Instalace](/slides/cs/java/installation/), a Maven si knihovnu stáhne odtud.

**Znamená klasifikátor `jdk16`, že knihovna potřebuje Java 16?**

Ne. Klasifikátor vybírá Java SE verzi knihovny; druhá verze je pro Android. Stejná verze běží na aktuálních JDK, například JDK 21.