---
title: Načíst a aktualizovat informace o prezentaci v Java
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
- modifikovat vlastnosti
- aktualizovat vlastnosti
- prozkoumat PPTX
- prozkoumat PPT
- prozkoumat ODP
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí Javy pro rychlejší přehledy a inteligentnější audity obsahu."
---
## **Přehled**

Tento článek ukazuje, jak prověřit informace o prezentaci v Aspose.Slides. Vysvětluje, jak určit aktuální formát prezentace, aniž byste načítali celý soubor, jak přečíst její vlastnosti dokumentu a jak tyto vlastnosti aktualizovat podle potřeby.

Příklady jsou založeny na API [PresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationinfo/) a [DocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/documentproperties/) a demonstrují typické operace pro práci s metadaty prezentace.

## **Zkontrolujte formát prezentace**

Před prací s prezentací možná chcete zjistit, v jakém formátu (PPT, PPTX, ODP a další) se prezentace momentálně nachází.

Formát prezentace můžete zkontrolovat, aniž byste ji načítali. Podívejte se na tento kód v jazyce Java:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Získat vlastnosti prezentace**

Tento kód v jazyce Java vám ukazuje, jak získat vlastnosti prezentace (informace o prezentaci):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Možná budete chtít zobrazit [vlastnosti ve třídě DocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Aktualizovat vlastnosti prezentace**

Aspose.Slides poskytuje metodu [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), která vám umožní provést změny ve vlastnostech prezentace.

Předpokládejme, že máme prezentaci PowerPoint s následujícími vlastnostmi dokumentu.

![Původní vlastnosti dokumentu PowerPointové prezentace](input_properties.png)

Tento příklad kódu vám ukazuje, jak upravit některé vlastnosti prezentace:

```java
import com.aspose.slides.*;
import java.util.Date;

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

- [Prezentace chráněné heslem](/slides/cs/java/password-protected-presentation/)
- [Prezentace chráněné proti zápisu](/slides/cs/java/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Vyhledejte informace o [vložených písmech](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) na úrovni prezentace a poté porovnejte tyto položky s množinou [skutečně použitých písem v obsahu](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsmanager/#getFonts--) a identifikujte, která písma jsou pro vykreslování kritická.

**Jak mohu rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Projděte [kolekci snímků](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidecollection/) a zkontrolujte [indikátor viditelnosti](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#getHidden--) každého snímku.

**Mohu zjistit, zda jsou použity vlastní velikost a orientace snímku, a zda se liší od výchozích hodnot?**

Ano. Porovnejte aktuální [velikost snímku](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSlideSize--) a orientaci s přednastavenými standardy; to pomáhá předvídat chování při tisku a exportu.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí zdroje dat?**

Ano. Procházejte všechny [grafy](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chart/), zkontrolujte jejich [datový zdroj](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chartdata/#getDataSourceType--) a zaznamenejte, zda jsou data interní nebo založená na odkazu, včetně případných nefunkčních odkazů.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalovat vykreslování nebo export do PDF?**

Pro každý snímek spočítejte počet objektů a hledejte velké obrázky, průhlednost, stíny, animace a multimédia; přiřaďte přibližné skóre složitosti, abyste označili potenciální úzká místa výkonu.