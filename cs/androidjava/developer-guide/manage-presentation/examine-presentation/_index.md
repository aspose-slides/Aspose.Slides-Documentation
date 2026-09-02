---
title: Načtení a aktualizace informací o prezentaci na Androidu
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
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí jazyka Java pro rychlejší poznatky a chytřejší audit obsahu."
---
## **Přehled**

Tento článek ukazuje, jak prozkoumat informace o prezentaci v Aspose.Slides. Vysvětluje, jak určit aktuální formát prezentace bez načtení celého souboru, přečíst její vlastnosti dokumentu a v případě potřeby tyto vlastnosti aktualizovat.

Příklady jsou založeny na API [PresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationinfo/) a [DocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/documentproperties/) a demonstrují typické operace při práci s metadaty prezentace.

## **Zkontrolujte formát prezentace**

Před prací s prezentací možná budete chtít zjistit, v jakém formátu (PPT, PPTX, ODP a dalších) se prezentace momentálně nachází.

Formát prezentace můžete zjistit bez načtení samotné prezentace. Viz tento Java kód:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Získejte vlastnosti prezentace**

Tento Java kód ukazuje, jak získat vlastnosti prezentace (informace o prezentaci):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Možná budete chtít zobrazit [vlastnosti ve třídě DocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Aktualizujte vlastnosti prezentace**

Aspose.Slides poskytuje metodu [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) , která umožňuje provádět změny ve vlastnostech prezentace.

Předpokládejme, že máme PowerPoint prezentaci s vlastnostmi dokumentu zobrazenými níže.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

Tento ukázkový kód ukazuje, jak upravit některé vlastnosti prezentace:

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

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro další informace o prezentaci a jejích bezpečnostních atributech mohou být následující odkazy užitečné:

- [Ochrana prezentací heslem](/slides/cs/androidjava/password-protected-presentation/)
- [Ochrana prezentací před zápisem](/slides/cs/androidjava/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Hledejte informace o [vložených písmech](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) na úrovni prezentace a poté porovnejte tyto položky se seznamem [písmen skutečně použitých v obsahu](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsmanager/#getFonts--) a identifikujte, která písma jsou kritická pro vykreslování.

**Jak rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Projděte [kolekci snímků](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidecollection/) a zkontrolujte příznak [viditelnosti každého snímku](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slide/#getHidden--).

**Mohu zjistit, zda je použita vlastní velikost a orientace snímku a zda se liší od výchozích?**

Ano. Porovnejte aktuální [velikost snímku](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSlideSize--) a orientaci se standardními předvolbami; to pomáhá předvídat chování při tisku a exportu.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí zdroje dat?**

Ano. Procházejte všechny [grafy](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chart/), zkontrolujte jejich [zdroj dat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) a zaznamenejte, zda jsou data interní nebo odkazována, včetně případných nefunkčních odkazů.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalovat vykreslování nebo export do PDF?**

U každého snímku spočítejte počet objektů a hledejte velké obrázky, průhlednost, stíny, animace a multimédia; přiřaďte přibližné skóre složitosti, abyste označili potenciální výkonnostní úzká místa.