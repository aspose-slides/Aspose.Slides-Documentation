---
title: Správa vlastností prezentace v JavaScriptu
linktitle: Vlastnosti prezentace
type: docs
weight: 70
url: /cs/nodejs-java/presentation-properties/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Mistrně ovládejte vlastnosti prezentace v Aspose.Slides pro Node.js via Java a zefektivněte vyhledávání, značkování a pracovní postup ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Built-in** a **Custom**. Oba tyto typy vlastností lze snadno získat a spravovat pomocí API Aspose.Slides.

Aspose.Slides umožňuje pracovat s vlastnostmi dokumentu prezentace pomocí třídy [DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/) . Instance této třídy je vrácena metodou [Presentation.getDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . Následující příklady ukazují, jak číst, upravovat a spravovat tyto vlastnosti.

{{% alert color="info" title="Note" %}}
Všimněte si, že pole **Application** a **AppVersion** nelze upravit. Aspose.Slides je přepisuje při každém uložení, takže uložená prezentace vždy uvádí „Aspose.Slides for Node.js via Java“ a verzi knihovny, která ji vytvořila. Jakákoli hodnota předaná metodě `setNameOfApplication` je při zápisu prezentace zahozena.
{{% /alert %}} 

## **Správa vlastností prezentace**

Microsoft PowerPoint poskytuje funkci pro přidání některých vlastností k souborům prezentace. Tyto vlastnosti dokumentu umožňují uložit užitečné informace společně s dokumenty (soubory prezentace). Existují dva typy vlastností dokumentu, jak následuje

- Systémově definované (Built-in) vlastnosti
- Uživatelem definované (Custom) vlastnosti

**Built-in** vlastnosti obsahují obecné informace o dokumentu, jako je název dokumentu, jméno autora, statistiky dokumentu a podobně. **Custom** vlastnosti jsou ty, které jsou definovány uživateli jako páry **Name/Value**, kde jak název, tak hodnota jsou definovány uživatelem. Pomocí Aspose.Slides pro Node.js via Java mohou vývojáři získávat a upravovat hodnoty built-in i custom vlastností.

## **Vlastnosti dokumentu v PowerPointu**

Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentace. Stačí kliknout na ikonu Office a poté na položku **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007, jak je znázorněno níže:

|**Vybrání položky Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Po výběru položky **Advanced Properties** se zobrazí dialog, který umožňuje spravovat vlastnosti dokumentu souboru PowerPoint, jak je znázorněno níže na obrázku:

|**Dialog Vlastností**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

V uvedeném **Properties Dialog** můžete vidět, že existuje mnoho záložek jako **General**, **Summary**, **Statistics**, **Contents** a **Custom**. Všechny tyto záložky umožňují konfigurovat různé typy informací souvisejících se soubory PowerPoint. Záložka **Custom** se používá k řízení vlastních vlastností souborů PowerPoint.

Práce s vlastnostmi dokumentu pomocí Aspose.Slides pro Node.js via Java

Jak jsme již dříve popsali, Aspose.Slides pro Node.js via Java podporuje dva typy vlastností dokumentu, **Built-in** a **Custom**. Vývojáři tak mohou získat obě typy vlastností pomocí API Aspose.Slides pro Node.js via Java. Aspose.Slides pro Node.js via Java poskytuje třídu [DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties) která představuje vlastnosti dokumentu spojené se souborem prezentace prostřednictvím vlastnosti **Presentation.DocumentProperties**.

Vývojáři mohou použít vlastnost **DocumentProperties** vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) k získání vlastností dokumentu souborů prezentace, jak je uvedeno níže:

## **Čtení veřejných vlastností z šifrované prezentace**

Otevřovací heslo obvykle chrání jak obsah prezentace, tak vlastnosti dokumentu. Když je prezentace šifrována předáním `false` metodě [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), její vlastnosti dokumentu zůstávají veřejné. Aplikace pak může předat `true` metodě [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) a přečíst veřejná metadata bez zadání otevřovacího hesla.

Volba document-properties-only určuje, co Aspose.Slides načte; neprovádí žádné dešifrování. Pokud jsou vlastnosti zahrnuty do šifrování, načtení bez hesla selže. Pokud prezentace není šifrována, volba se ignoruje a načte se celá prezentace.

Následující příklad ověřuje režim načítání pomocí [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) a poté čte built-in vlastnosti pomocí [Presentation.getDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

V tomto režimu se nenačítá obsah snímků. Snímky, mastery, rozvržení, tvary, média a další objekty prezentace nejsou k dispozici. Aplikace by měly vždy před provedením operace, která vyžaduje kompletní model objektů prezentace, zkontrolovat [ProtectionManager.isOnlyDocumentPropertiesLoaded].

{{% alert color="warning" title="Warning" %}}
Veřejná metadata mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty. Šifrujte citlivé vlastnosti společně s prezentací. Nechte je veřejné jen v případě, že indexovací, klasifikační, vyhledávací nebo systémy pro správu dokumentů mají konkrétní požadavek na přístup k nim bez hesla.
{{% /alert %}}

## **Aktualizace vlastností šifrované prezentace**

Pro šifrovaný soubor PPTX je prezentace načtená v režimu pouze vlastnosti dokumentu určena ke čtení veřejných metadat. Aspose.Slides nemůže uložit změněné vlastnosti z tohoto objektu pouze s metadaty, protože veřejné vlastnosti musí zůstat konzistentní s odpovídajícími daty uvnitř šifrované prezentace. Aktualizace tedy vyžaduje správné otevřovací heslo a kompletní načtení.

Následující příklad otevře prezentaci pomocí [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setPassword), aktualizuje veřejné built-in vlastnosti a uloží výsledek. Poté použije [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) k ověření, že šifrování je zachováno, a znovu otevře veřejná metadata bez hesla pro ověření nových hodnot:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Pokud aplikace nemá oprávnění dešifrovat nebo načíst obsah prezentace, musí veřejné vlastnosti šifrovaného souboru PPTX považovat za pouze pro čtení.

## **Přístup k Built-in vlastnostem**

Tyto vlastnosti vystavené objektem [DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties) zahrnují: **Creator** (Autor), **Description**, **Keywords**, **Created** (Datum vytvoření), **Modified** (Datum úpravy), **Printed** (Datum posledního tisku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Je sdílen mezi různými tvůrci?), **PresentationFormat**, **Subject** a **Title**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancujte třídu Presentation, která představuje prezentaci
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt IDocumentProperties spojený s prezentací
    var dp = pres.getDocumentProperties();
    // Zobrazte vestavěné vlastnosti
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Úprava Built-in vlastností**

Upravit vestavěné vlastnosti souborů prezentace je stejně snadné jako k nim přistupovat. Stačí přiřadit řetězcovou hodnotu libovolné požadované vlastnosti a hodnota vlastnosti bude změněna. V níže uvedeném příkladu jsme ukázali, jak lze pomocí Aspose.Slides pro Node.js via Java upravit vestavěné vlastnosti dokumentu prezentace.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt IDocumentProperties spojený s prezentací
    var dp = pres.getDocumentProperties();
    // Nastavte vestavěné vlastnosti
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Uložte prezentaci do souboru
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Tento příklad upravuje vestavěné vlastnosti prezentace, které lze zobrazit níže:

|**Vestavěné vlastnosti dokumentu po úpravě**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Přidání vlastních vlastností dokumentu**

Aspose.Slides pro Node.js via Java také umožňuje vývojářům přidávat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže je uveden příklad, který ukazuje, jak nastavit vlastní vlastnosti pro prezentaci.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Získávání vlastností dokumentu
    var dProps = pres.getDocumentProperties();
    // Přidávání vlastních vlastností
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Získání názvu vlastnosti na konkrétním indexu
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Odstranění vybrané vlastnosti
    dProps.removeCustomProperty(getPropertyName);
    // Ukládání prezentace
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Vlastní vlastnosti dokumentu přidány**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Přístup a úprava vlastních vlastností**

Aspose.Slides pro Node.js via Java také umožňuje vývojářům přistupovat k hodnotám vlastních vlastností. Níže je uveden příklad, který ukazuje, jak můžete získat a upravit všechny tyto vlastní vlastnosti pro prezentaci.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt DocumentProperties spojený s prezentací
    var dp = pres.getDocumentProperties();
    // Přístup a úprava vlastních vlastností
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Zobrazte názvy a hodnoty vlastních vlastností
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Upravit hodnoty vlastních vlastností
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Uložte prezentaci do souboru
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Tento příklad upravuje vlastní vlastnosti [PPTX](https://docs.fileformat.com/presentation/pptx/) prezentace. Následující obrázky ukazují vlastní vlastnosti prezentace před a po úpravě:

|**Vlastní vlastnosti před úpravou**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Vlastní vlastnosti po úpravě**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Pokročilé vlastnosti dokumentu**

{{% alert color="info" title="Note" %}}
Byly přidány nové metody [ReadDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), a [WriteBindedPresentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) do [PresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo), logika setteru vlastnosti [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) byla změněna.
{{% /alert %}} 

Tyto dvě nové metody [ReadDocumentProperties] a [UpdateDocumentProperties] byly přidány do třídy [PresentationInfo]. Poskytují rychlý přístup k vlastnostem dokumentu a umožňují měnit a aktualizovat vlastnosti bez načítání celé prezentace.

Typický scénář načtení vlastností, změna některé hodnoty a aktualizace dokumentu lze implementovat následujícím způsobem:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// načíst informace o prezentaci
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// získat aktuální vlastnosti
var props = info.readDocumentProperties();
// nastavit nové hodnoty polí Autor a Název
props.setAuthor("New Author");
props.setTitle("New Title");
// aktualizovat prezentaci s novými hodnotami
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Existuje další způsob, jak použít vlastnosti konkrétní prezentace jako šablonu pro aktualizaci vlastností v jiných prezentacích:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
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

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Nová šablona může být vytvořena od nuly a pak použita k aktualizaci více prezentací:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
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

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Nastavení jazyka kontroly pravopisu**

Aspose.Slides poskytuje vlastnost LanguageId (vystavenou třídou PortionFormat), která vám umožní nastavit jazyk kontroly pravopisu pro dokument PowerPoint. Jazyk kontroly pravopisu je jazyk, pro který jsou v PowerPointu kontrolovány pravopis a gramatika.

Tento JavaScriptový kód ukazuje, jak nastavit jazyk kontroly pravopisu pro PowerPoint: xxx Proč v JavaScriptové třídě PortionFormat chybí LanguageId?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// nastavte Id jazykové kontroly
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení výchozího jazyka**

Tento JavaScriptový kód ukazuje, jak nastavit výchozí jazyk pro celou prezentaci PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Přidá nový obdélníkový tvar s textem
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Zkontroluje jazyk první části
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ukázkový příklad**

Vyzkoušejte online aplikaci [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata) a podívejte se, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## **FAQ**

**Jak mohu odstranit vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, pokud přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost předem odstraňovat ani kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu získat přístup k vlastnostem prezentace bez úplného načtení prezentace?**

Ano. Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) a poté [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) k přečtení uložených metadat dokumentu, aniž byste vytvářeli instanci [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) . Viz [Build a Lightweight Presentation Inventory](/slides/cs/nodejs-java/examine-presentation/) pro kompletní příklad hlášení a omezení specifických formátů.

**Mohu číst veřejné vlastnosti šifrované prezentace bez jejího otevřovacího hesla?**

Ano. Šifrování vlastnosti dokumentu muselo být vypnuto před tím, než byla prezentace zašifrována, a prezentace musí být načtena v režimu pouze vlastnosti dokumentu.

**Mohu aktualizovat šifrovaný soubor PPTX v režimu pouze vlastnosti dokumentu?**

Ne. Veřejná a šifrovaná data vlastností musí zůstat konzistentní, takže aktualizace šifrovaného souboru PPTX vyžaduje načtení celé prezentace se správným otevřeným heslem.