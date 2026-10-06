---
title: Zabezpečení
type: docs
weight: 160
url: /cs/java/security/
keywords:
- zabezpečení
- závislosti
- komponenty třetích stran
- Maven
- podpis JAR
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Přehled toho, jak Aspose.Slides pro Java zpracovává prezentace, co přidává do závislostí vašeho projektu, jak ověřit JAR soubor a které komponenty třetích stran obsahuje."
---
## **Úvod**

Tento článek shromažďuje informace, které jsou obvykle potřeba při bezpečnostním přezkoumání aplikace používající Aspose.Slides pro Java: jak knihovna zpracovává prezentace, co přidává do závislostí vašeho projektu, jak ověřit, že JAR soubor pochází od Aspose, a které komponenty třetích stran JAR soubor obsahuje.

## **Zabezpečení v Aspose.Slides**

Aspose při vývoji svých produktů uplatňuje osvědčené postupy.

* Aspose.Slides pro Java se používá k vytváření, úpravám a konverzi prezentací. Nespouští skripty v prezentacích. Aspose.Slides parsuje strukturu prezentace a umožňuje vašemu kódu pracovat s objektovým modelem.
* Aspose.Slides funguje jako knihovna, která parsuje a interpretuje dokumenty bez spouštění vzdáleného kódu. Všechny produkty Aspose běží na vašich strojích. Nepřenášejí žádná data do Aspose. Jedinou výjimkou je [licencování na měrný základ](/slides/cs/java/metered-licensing/): pokud jej používáte, jsou zpracovány jen informace o vašem využití API.
* Komponenty Aspose běží ve stejném uživatelském kontextu jako běžné aplikace. Proto komponenty Aspose neohrožují důležité systémové zdroje. Navíc při otevření dokumentu komponentou Aspose se makra automaticky nespouští.

## **Závislosti Maven**

Maven artefakt Aspose.Slides pro Java, `com.aspose:aspose-slides`, nevyhlašuje žádné závislosti: jeho POM soubor obsahuje jen souřadnice samotného artefaktu. Když jej přidáte do projektu, Maven přidá jen tento jediný JAR soubor a nic dalšího. Pro vypsání všech artefaktů, které váš projekt řeší, včetně tranzitivních závislostí, spusťte následující příkaz v kořenovém adresáři projektu:

```bash
mvn dependency:tree
```

V projektu z [Instalace](/slides/cs/java/installation/) výstup uvádí Aspose.Slides jako jedinou závislost:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **Ověření JAR souboru**

Aspose podepisuje JAR soubor. Pro kontrolu podpisu spusťte nástroj `jarsigner` z JDK ve složce, která obsahuje JAR soubor:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

Příkaz vypíše `jar verified.` když je podpis platný a žádná položka nebyla od doby podpisu změněna. Tato zpráva neuvádí jméno podepisovatele. Pro potvrzení, že soubor podepsalo Aspose, přidejte přepínače `-verbose` a `-certs` a ověřte, že certifikát podepisovatele je vydán na `CN=ASPOSE PTY LTD`. Když Maven stáhne JAR soubor, také kontroluje kontrolní součet SHA-1, který repozitář zveřejňuje vedle souboru.

## **Komponenty třetích stran**

Aspose.Slides pro Java obsahuje kód a data od komponent třetích stran. Jsou součástí JAR souboru, nikoli samostatných artefaktů Maven, takže `mvn dependency:tree` a další nástroje čtoucí Maven závislosti je neuvádějí. JAR soubor obsahuje poznámku *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf*, která uvádí komponenty a jejich licence:

| Komponenta | Licence uvedená v poznámce |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | licence ve stylu MIT |
| Mono | MIT licence; některé části pod jinými licencemi, které jsou uvedeny v poznámce |
| RSWOP.ICM color profile | podmínky licence Microsoft |
| sRGB_v4_ICC_preference.icc color profile | povolení ICC použít, kopírovat a distribuovat nezměněný soubor |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

Pro extrahování poznámky z JAR souboru spusťte nástroj `jar` z JDK ve složce, která obsahuje JAR soubor:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **Často kladené otázky**

**Používá Aspose.Slides pro Java externí balíčky?**

Nemá Maven závislosti, jak uvádí [Závislosti Maven](#maven-dependencies), ale zahrnuje komponenty třetích stran uvedené v sekci [Komponenty třetích stran](#third-party-components). Do vašeho bezpečnostního přezkoumání zahrňte jak JAR soubor, tak tyto komponenty.

**Potřebuje Aspose.Slides pro Java přístup k síti?**

Ne. Vytváření, ukládání a renderování prezentací funguje na systému bez jakéhokoli síťového připojení. Jedinou funkcí, která odesílá data do Aspose, je [licencování na měrný základ](/slides/cs/java/metered-licensing/), které hlásí využití API.

**Obsahuje Aspose.Slides pro Java nativní kód?**

Ne. JAR soubor obsahuje jen Java třídy a zdroje, takže do vaší aplikace nepřidává žádné nativní knihovny. Na Linuxu podpora písem v Java runtime vyžaduje knihovnu fontconfig a písma z operačního systému; viz [Požadavky na systém](/slides/cs/java/system-requirements/#linux).