---
title: Načtení a aktualizace informací o prezentaci v jazyce Java
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/java/examine-presentation/
keywords:
- formát prezentace
- vlastnosti prezentace
- vlastnosti dokumentu
- získat vlastnosti
- číst vlastnosti
- změnit vlastnosti
- upravit vlastnosti
- aktualizovat vlastnosti
- prověřit PPTX
- prověřit PPT
- prověřit ODP
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí jazyka Java pro rychlejší získání poznatků a inteligentnější audit obsahu."
---
## **Přehled**

Tento článek ukazuje, jak prozkoumat informace o prezentaci v Aspose.Slides. Vysvětluje, jak určit aktuální formát prezentace, aniž by se načítal celý soubor, jak přečíst její vlastnosti dokumentu a jak tyto vlastnosti v případě potřeby aktualizovat.

Příklady jsou založeny na API [PresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationinfo/) a [DocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/documentproperties/) a demonstrují typické operace pro práci s metadaty prezentace.

## **Zkontrolovat formát prezentace**

Než začnete pracovat s prezentací, můžete chtít zjistit, v jakém formátu (PPT, PPTX, ODP a další) se prezentace momentálně nachází.

Formát prezentace můžete zkontrolovat, aniž byste ji načítali. Viz tento kód v jazyce Java:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Získat vlastnosti prezentace**

Tento kód v jazyce Java ukazuje, jak získat vlastnosti prezentace (informace o prezentaci):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Můžete se také podívat na [vlastnosti ve třídě DocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Aktualizovat vlastnosti prezentace**

Aspose.Slides poskytuje metodu [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) , která umožňuje provádět změny ve vlastnostech prezentace.

Předpokládejme, že máme PowerPoint prezentaci s následujícími vlastnostmi dokumentu.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

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

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro získání dalších informací o prezentaci a jejích bezpečnostních atributech vám mohou být následující odkazy užitečné:

- [Kontrola, zda je prezentace šifrována](https://docs.aspose.com/slides/cs/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Kontrola, zda je prezentace chráněna proti zápisu (pouze pro čtení)](https://docs.aspose.com/slides/cs/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Kontrola, zda je prezentace chráněna heslem před načtením](https://docs.aspose.com/slides/cs/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Potvrzení hesla použitého k ochraně prezentace](https://docs.aspose.com/slides/cs/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou fonty vloženy a které to jsou?**

Hledejte informace o [vložených fontech](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) na úrovni prezentace a poté porovnejte tyto položky s množinou [fontů skutečně použitých v obsahu](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsmanager/#getFonts--) a identifikujte, které fonty jsou klíčové pro vykreslování.

**Jak rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Projděte [kolekci snímků](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidecollection/) a prozkoumejte příznak [viditelnosti každého snímku](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#getHidden--).

**Mohu zjistit, zda jsou použity vlastní velikosti a orientace snímků a zda se liší od výchozích?**

Ano. Porovnejte aktuální [velikost snímku](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSlideSize--) a orientaci se standardními předvolbami; to pomáhá předvídat chování při tisku a exportu.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí zdroje dat?**

Ano. Procházejte všechny [grafy](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chart/), zkontrolujte jejich [datový zdroj](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chartdata/#getDataSourceType--) a zaznamenejte, zda jsou data interní nebo odkazována, včetně případných nefunkčních odkazů.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalovat vykreslování nebo export do PDF?**

Pro každý snímek spočítejte počet objektů a hledejte velké obrázky, průhlednost, stíny, animace a multimédia; přiřaďte přibližné skóre složitosti a označte potenciální úzká místa výkonu.