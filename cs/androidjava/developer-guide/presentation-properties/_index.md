---
title: Správa vlastností prezentace na Androidu
linktitle: Vlastnosti prezentace
type: docs
weight: 70
url: /cs/androidjava/presentation-properties/
keywords:
- Vlastnosti PowerPointu
- Vlastnosti prezentace
- Vlastnosti dokumentu
- Vestavěné vlastnosti
- Vlastní vlastnosti
- Pokročilé vlastnosti
- Správa vlastností
- Úprava vlastností
- Metadata dokumentu
- Úprava metadat
- Jazyk kontroly pravopisu
- Výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Spravujte vlastnosti prezentací v Aspose.Slides pro Android prostřednictvím Javy a zjednodušte vyhledávání, značkování a workflow ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Vestavěné** a **Vlastní**. Oba typy vlastností lze snadno získat a spravovat pomocí API Aspose.Slides.

Aspose.Slides umožňuje pracovat s vlastnostmi prezentace přes rozhraní [IDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/) . Instance tohoto rozhraní je vrácena metodou [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Následující příklady ukazují, jak číst, měnit a spravovat tyto vlastnosti.

{{% alert color="info" title="Poznámka" %}}
Upozorňujeme, že pole **Application** a **AppVersion** nelze měnit. Aspose.Slides je přepisuje při každém uložení, takže uložená prezentace vždy uvádí název produktu Aspose.Slides a verzi knihovny, která ji vytvořila. Jakákoli hodnota předaná metodě `setNameOfApplication` je při zápisu prezentace zahozena.
{{% /alert %}} 

## **Vlastnosti dokumentu v PowerPointu**

Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentace. Stačí kliknout na ikonu Office a poté na položku nabídky **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007, jak je znázorněno níže:

|**Výběr položky nabídky Advanced Properties**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Po výběru položky **Advanced Properties** se zobrazí dialogové okno, které umožňuje spravovat vlastnosti dokumentu souboru PowerPoint, jak je ukázáno na následujícím obrázku:

|**Dialog Vlastnosti**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
V tomto **Dialogu Vlastnosti** vidíte mnoho záložek, jako **General**, **Summary**, **Statistics**, **Contents** a **Custom**. Všechny tyto záložky umožňují konfigurovat různé informace související se soubory PowerPoint. Záložka **Custom** slouží k správě vlastních (custom) vlastností souborů PowerPoint.



### Práce s vlastnostmi dokumentu pomocí Aspose.Slides for Android via Java

Jak jsme již dříve popsali, Aspose.Slides for Android via Java podporuje dva druhy vlastností dokumentu – **Vestavěné** a **Vlastní**. Vývojáři tak mohou přistupovat k oběma typům vlastností pomocí API Aspose.Slides for Android via Java. Aspose.Slides for Android via Java poskytuje třídu [IDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties), která představuje vlastnosti dokumentu spojené s prezentačním souborem skrze vlastnost **Presentation.DocumentProperties**.

Vývojáři mohou použít vlastnost **IDocumentProperties**, kterou vystavuje objekt [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation), aby získali přístup k vlastnostem dokumentu prezentačních souborů, jak je popsáno níže:

## **Čtení veřejných vlastností z šifrované prezentace**

Otevírací heslo obvykle chrání jak obsah prezentace, tak i vlastnosti dokumentu. Když je prezentace šifrována předáním hodnoty `false` metodě [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), její vlastnosti dokumentu zůstávají veřejné. Aplikace pak může předat `true` metodě [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) a načíst veřejná metadata bez zadání otevíracího hesla.

Možnost načítání pouze vlastností dokumentu řídí, co Aspose.Slides načítá; dešifruje nic. Pokud byly vlastnosti zahrnuty do šifrování, načtení bez hesla selže. Pokud prezentace není šifrována, možnost se ignoruje a načte se celá prezentace.

Následující příklad ověří režim načítání pomocí [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) a poté načte vestavěné vlastnosti pomocí [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

V tomto režimu se načítá obsah snímků. Snímky, hlavní snímky, rozvržení, tvary, média a další objekty prezentace nejsou k dispozici. Aplikace by měly vždy před provedením operace vyžadující kompletní objektový model prezentace zkontrolovat [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--).

{{% alert color="warning" title="Upozornění" %}}
Veřejná metadata mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty. Šifrujte citlivé vlastnosti společně s prezentací. Nechejte je veřejné pouze tehdy, když to vyžadují indexovací, klasifikační, vyhledávací nebo systémy pro správu dokumentů.
{{% /alert %}}

## **Aktualizace vlastností šifrované prezentace**

U šifrovaného souboru PPTX je prezentace načtená v režimu pouze vlastností dokumentu určena pro čtení veřejných metadat. Aspose.Slides nemůže uložit změněné vlastnosti z tohoto objektu pouze s metadaty, protože veřejné vlastnosti musí zůstat v souladu s odpovídajícími daty uvnitř šifrované prezentace. Aktualizace proto vyžaduje správné otevírací heslo a kompletní načtení.

Následující příklad otevře prezentaci pomocí [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), aktualizuje veřejné vestavěné vlastnosti a výsledek uloží. Poté použije [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) k ověření, že šifrování zůstalo zachováno, a znovu načte veřejná metadata bez hesla pro ověření nových hodnot:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Pokud aplikace nemá povoleno dešifrovat nebo načíst obsah prezentace, musí veřejné vlastnosti šifrovaného souboru PPTX považovat za pouze ke čtení.

## **Přístup k vestavěným vlastnostem**

Tyto vlastnosti, jak je poskytuje objekt [IDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties), zahrnují: **Creator** (Autor), **Description**, **Keywords**, **Created** (Datum vytvoření), **Modified** (Datum úpravy), **Printed** (Datum posledního tisku), **LastModifiedBy**, **SharedDoc** (Je sdíleno mezi různými tvůrci?), **PresentationFormat**, **Subject** a **Title**.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje prezentaci
Presentation pres = new Presentation("Presentation.pptx");
try {
    //    Vytvořte odkaz na objekt IDocumentProperties spojený s prezentací
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Display the built-in properties
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Úprava vestavěných vlastností**

Úprava vestavěných vlastností souborů prezentace je tak snadná jako k nim přistupovat. Jednoduše přiřadíte řetězcovou hodnotu libovolné požadované vlastnosti a hodnota se změní. V níže uvedeném příkladu ukazujeme, jak lze upravit vestavěné vlastnosti dokumentu prezentace pomocí Aspose.Slides for Android via Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt IDocumentProperties spojený s prezentací
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Nastavte vestavěné vlastnosti
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Uložte prezentaci do souboru
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Tento příklad upravuje vestavěné vlastnosti prezentace, jak je zobrazeno níže:

|**Vestavěné vlastnosti dokumentu po úpravě**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Přidání vlastních vlastností dokumentu**

Aspose.Slides for Android via Java také umožňuje vývojářům přidat vlastní hodnoty pro vlastnosti dokumentu prezentace. Následující příklad přidá tři vlastní vlastnosti, poté vyhledá název uložený na indexu 2 a tuto vlastnost odstraní, takže uložená prezentace si ponechá dvě z nich. Vlastní vlastnosti jsou indexovány v abecedním pořadí, nikoli v pořadí, v jakém byly přidány.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Získání vlastností dokumentu
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Přidání vlastních vlastností
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Získání názvu vlastnosti na konkrétním indexu
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Odstranění vybrané vlastnosti
    dProps.removeCustomProperty(getPropertyName);
    
    // Ukládání prezentace
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Přidané vlastní vlastnosti dokumentu**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Přístup a úprava vlastních vlastností**

Aspose.Slides for Android via Java také umožňuje vývojářům přistupovat k hodnotám vlastních vlastností. Níže je uveden příklad, který ukazuje, jak můžete přistupovat ke všem těmto vlastním vlastnostem a upravovat je pro prezentaci.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt DocumentProperties spojený s prezentací
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Přístup a úprava vlastních vlastností
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Zobrazte názvy a hodnoty vlastních vlastností
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Upravte hodnoty vlastních vlastností
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Uložte prezentaci do souboru
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Tento příklad upravuje vlastní vlastnosti [PPTX](https://docs.fileformat.com/presentation/pptx/) prezentace. Následující obrázky ukazují vlastní vlastnosti prezentace před a po úpravě:

|**Vlastní vlastnosti před úpravou**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Vlastní vlastnosti po úpravě**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Pokročilé vlastnosti dokumentu**

{{% alert color="info" title="Poznámka" %}}
Nové metody [ReadDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), a [WriteBindedPresentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) byly přidány do [IPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo); logika setteru [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) byla změněna.
{{% /alert %}} 

Nové metody [ReadDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) a [UpdateDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) byly přidány do rozhraní [IPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo). Poskytují rychlý přístup k vlastnostem dokumentu a umožňují měnit a aktualizovat vlastnosti bez načítání celé prezentace.

Typický scénář načtení vlastností, změna některých hodnot a aktualizace dokumentu lze implementovat následujícím způsobem:

```java
import com.aspose.slides.*;

// načtěte informace o prezentaci
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// získejte aktuální vlastnosti
IDocumentProperties props = info.readDocumentProperties();

// nastavte nové hodnoty polí Autor a Název
props.setAuthor("New Author");
props.setTitle("New Title");

// aktualizujte prezentaci s novými hodnotami
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Další způsob je použít vlastnosti konkrétní prezentace jako šablonu pro aktualizaci vlastností v jiných prezentacích:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Nová šablona může být vytvořena od začátku a poté použita k aktualizaci více prezentací:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Nastavení jazykové kontroly pravopisu**

Aspose.Slides poskytuje vlastnost LanguageId (vystavovanou třídou PortionFormat), která umožňuje nastavit jazykovou kontrolu pravopisu pro dokument PowerPoint. Jazyková kontrola pravopisu je jazyk, pro který se kontrolují pravopis a gramatika v PowerPointu.

Tento Java kód ukazuje, jak nastavit jazykovou kontrolu pravopisu pro PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // nastavte ID jazyka kontroly pravopisu

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavení výchozího jazyka**

Tento Java kód ukazuje, jak nastavit výchozí jazyk pro celou prezentaci PowerPoint:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Přidá nový obdélníkový tvar s textem
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Kontroluje jazyk první části
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ukázkový živý příklad**

Vyzkoušejte online aplikaci [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata) a zjistěte, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## **Často kladené otázky**

**Jak mohu odstranit vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost předtím odstraňovat nebo kontrolovat, protože Aspose.Slides hodnotu automaticky aktualizuje.

**Mohu přistupovat k vlastnostem prezentace bez úplného načtení prezentace?**

Ano. Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) a poté [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) pro čtení uložených metadat dokumentu, aniž byste vytvářeli instanci [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/). Viz [Build a Lightweight Presentation Inventory](/slides/cs/androidjava/examine-presentation/) pro kompletní příklad reportování a omezení specifická pro formáty.

**Mohu číst veřejné vlastnosti šifrované prezentace bez jejího otevíracího hesla?**

Ano. Šifrování vlastností dokumentu muselo být před šifrováním prezentace zakázáno a prezentace musí být načtena v režimu pouze vlastností dokumentu.

**Mohu aktualizovat šifrovaný soubor PPTX v režimu pouze vlastností dokumentu?**

Ne. Veřejná a šifrovaná data vlastností musí zůstat konzistentní, takže aktualizace šifrovaného souboru PPTX vyžaduje načtení kompletní prezentace se správným otevíracím heslem.