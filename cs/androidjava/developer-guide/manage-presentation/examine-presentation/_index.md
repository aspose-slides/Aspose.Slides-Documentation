---
title: Načíst a aktualizovat informace o prezentaci na Androidu
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/androidjava/examine-presentation/
keywords:
- formát prezentace
- vlastnosti prezentace
- vlastnosti dokumentu
- získat vlastnosti
- číst vlastnosti
- změnit vlastnosti
- upravit vlastnosti
- aktualizovat vlastnosti
- prozkoumat PPTX
- prozkoumat PPT
- prozkoumat ODP
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí Javy pro rychlejší poznatky a chytřejší audity obsahu."
---
## **Přehled**

Tento článek ukazuje, jak prozkoumat informace o prezentaci v Aspose.Slides. Vysvětluje, jak určit aktuální formát prezentace bez načtení celé souboru, přečíst její vlastnosti dokumentu a v případě potřeby tyto vlastnosti aktualizovat.

Příklady jsou založeny na API [PresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationinfo/) a [DocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/documentproperties/) a demonstrují typické operace pro práci s metadaty prezentace.

## **Zkontrolovat formát prezentace**

Před prací s prezentací možná budete chtít zjistit, v jakém formátu (PPT, PPTX, ODP a dalších) je prezentace momentálně uložena.

Formát prezentace můžete zkontrolovat bez načítání samotné prezentace. Viz následující Java kód:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Získat vlastnosti prezentace**

Tento Java kód ukazuje, jak získat vlastnosti prezentace (informace o prezentaci):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

Můžete se také podívat na [vlastnosti ve třídě DocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Aktualizovat vlastnosti prezentace**

Aspose.Slides poskytuje metodu [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) , která umožňuje provádět změny ve vlastnostech prezentace.

Předpokládejme, že máme PowerPointovou prezentaci s následujícími vlastnostmi dokumentu.

![Původní vlastnosti dokumentu PowerPointové prezentace](input_properties.png)

Tento příklad kódu ukazuje, jak upravit některé vlastnosti prezentace:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

Výsledky změny vlastností dokumentu jsou zobrazeny níže.

![Změněné vlastnosti dokumentu PowerPointové prezentace](output_properties.png)

## **Užitečné odkazy**

Pro získání dalších informací o prezentaci a jejích bezpečnostních atributech vám mohou být užitečné následující odkazy:

- [Kontrola, zda je prezentace šifrována](https://docs.aspose.com/slides/cs/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Kontrola, zda je prezentace chráněna před zápisem (pouze ke čtení)](https://docs.aspose.com/slides/cs/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Kontrola, zda je prezentace chráněna heslem před načtením](https://docs.aspose.com/slides/cs/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Potvrzení hesla použitého k ochraně prezentace](https://docs.aspose.com/slides/cs/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Vyhledejte [informace o vložených písmech](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) na úrovni prezentace a porovnejte je se seznamem [písmen skutečně použitých v obsahu](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsmanager/#getFonts--) pro určení, která písma jsou klíčová pro vykreslování.

**Jak mohu rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Procházejte [kolekci snímků](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidecollection/) a kontrolujte u každého snímku jeho [vlajku viditelnosti](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slide/#getHidden--).

**Mohu zjistit, zda je použita vlastní velikost a orientace snímku a zda se liší od výchozích hodnot?**

Ano. Porovnejte aktuální [velikost snímku](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSlideSize--) a orientaci se standardními předvolbami; to pomáhá předvídat chování při tisku a exportu.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí datové zdroje?**

Ano. Procházejte všechny [grafy](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chart/), zkontrolujte jejich [datový zdroj](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) a zaznamenejte, zda jsou data interní nebo založená na odkazu, včetně případných poškozených odkazů.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalit vykreslování nebo export do PDF?**

Pro každý snímek spočítejte počet objektů a hledejte velké obrázky, průhlednost, stíny, animace a multimédia; přiřaďte přibližné skóre složitosti a označte potenciální úzká místa výkonu.