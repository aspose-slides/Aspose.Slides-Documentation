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
- Rozšířené vlastnosti
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
description: "Ovládejte vlastnosti prezentace v Aspose.Slides pro Node.js via Java a zefektivněte vyhledávání, značkování a pracovní postup ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Vestavěné** a **Vlastní**. Oba tyto typy vlastností lze snadno získat a spravovat pomocí API Aspose.Slides.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace pomocí třídy [DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/) . Instance této třídy je vrácena metodou [Presentation.getDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . Následující příklady ukazují, jak tyto vlastnosti číst, upravovat a spravovat.

{{% alert color="info" title="Note" %}}
Všimněte si, že pole **Application** a **AppVersion** nelze upravit. Aspose.Slides je při každém uložení přepíše, takže uložená prezentace vždy uvádí „Aspose.Slides for Node.js via Java“ a verzi knihovny, která ji vytvořila. Jakákoliv hodnota předaná metodě `setNameOfApplication` je při zápisu prezentace zahozena.
{{% /alert %}} 

## **Správa vlastností prezentace**

Microsoft PowerPoint poskytuje funkci pro přidání některých vlastností do souborů prezentací. Tyto vlastnosti dokumentu umožňují uložit užitečné informace společně s dokumenty (soubormi prezentací). Existují dva druhy vlastností dokumentu:

- Systémové (Vestavěné) vlastnosti
- Uživatelské (Vlastní) vlastnosti

**Vestavěné** vlastnosti obsahují obecné informace o dokumentu, jako je název dokumentu, jméno autora, statistiky dokumentu a podobně. **Vlastní** vlastnosti jsou ty, které uživatelé definují jako páry **Název/ Hodnota**, kde jak název, tak hodnota jsou definovány uživatelem. Pomocí Aspose.Slides pro Node.js via Java mohou vývojáři získat a upravit hodnoty vestavěných i vlastních vlastností.

## **Vlastnosti dokumentu v PowerPointu**

Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentací. Stačí kliknout na ikonu Office a poté na položku nabídky **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007, jak je znázorněno níže:

|**Výběr položky Pokročilé vlastnosti**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Po výběru položky **Advanced Properties** se objeví dialogové okno, které vám umožní spravovat vlastnosti dokumentu souboru PowerPoint, jak je znázorněno níže:

|**Dialog Vlastností**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

V tomto **Dialogu Vlastností** můžete vidět mnoho karet, jako jsou **General**, **Summary**, **Statistics**, **Contents** a **Custom**. Všechny tyto karty umožňují konfigurovat různé typy informací souvisejících se soubory PowerPoint. Karta **Custom** slouží ke správě vlastních vlastností souborů PowerPoint.

### Práce s vlastnostmi dokumentu pomocí Aspose.Slides pro Node.js via Java

Jak jsme již dříve popsali, Aspose.Slides pro Node.js via Java podporuje dva typy vlastností dokumentu, a to **Vestavěné** a **Vlastní** vlastnosti. Vývojáři tak mohou získat oba typy vlastností pomocí API Aspose.Slides pro Node.js via Java. Aspose.Slides pro Node.js via Java poskytuje třídu [DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties), která představuje vlastnosti dokumentu spojené se souborem prezentace prostřednictvím vlastnosti **Presentation.DocumentProperties**.

Vývojáři mohou použít vlastnost **DocumentProperties**, kterou vystavuje objekt [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation), k získání vlastností dokumentu souborů prezentací, jak je popsáno níže:

## **Přístup k vestavěným vlastnostem**

Tyto vlastnosti, které jsou vystaveny objektem [DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties), zahrnují: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** a **Title**.

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

## **Úprava vestavěných vlastností**

Úprava vestavěných vlastností souborů prezentací je stejně snadná jako jejich získání. Stačí přiřadit řetězcovou hodnotu libovolné požadované vlastnosti a hodnota vlastnosti bude změněna. V níže uvedeném příkladu jsme ukázali, jak lze upravit vestavěné vlastnosti dokumentu prezentace pomocí Aspose.Slides pro Node.js via Java.

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
    // Uložte vaši prezentaci do souboru
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Tento příklad upravuje vestavěné vlastnosti prezentace, jak je vidět níže:

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
    // Odstraňování vybrané vlastnosti
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

Aspose.Slides pro Node.js via Java také umožňuje vývojářům přistupovat k hodnotám vlastních vlastností. Níže je uveden příklad, který ukazuje, jak můžete přistupovat a upravovat všechny tyto vlastní vlastnosti pro prezentaci.

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
    // Uložte svou prezentaci do souboru
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

## **Rozšířené vlastnosti dokumentu**

{{% alert color="info" title="Note" %}}
Byly přidány nové metody [ReadDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), a [WriteBindedPresentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) do třídy [PresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo), logika setteru vlastnosti [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) byla změněna.
{{% /alert %}} 

Do třídy [PresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo) byly přidány dvě nové metody [ReadDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) a [UpdateDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-). Poskytují rychlý přístup k vlastnostem dokumentu a umožňují měnit a aktualizovat vlastnosti bez načítání celé prezentace.

Typický scénář načíst vlastnosti, změnit některé hodnoty a aktualizovat dokument lze realizovat následujícím způsobem:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// přečtěte informace o prezentaci
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// získání aktuálních vlastností
var props = info.readDocumentProperties();
// nastavení nových hodnot polí Author a Title
props.setAuthor("New Author");
props.setTitle("New Title");
// aktualizace prezentace s novými hodnotami
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Dalším způsobem je použít vlastnosti konkrétní prezentace jako šablonu k aktualizaci vlastností v jiných prezentacích:

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

Novou šablonu lze vytvořit od nuly a poté použít k aktualizaci více prezentací:

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

## **Nastavení jazykové kontroly**

Aspose.Slides poskytuje vlastnost LanguageId (vystavovanou třídou PortionFormat), která vám umožní nastavit jazykovou kontrolu pro dokument PowerPoint. Jazyková kontrola je jazyk, pro který jsou v PowerPointu kontrolovány pravopis a gramatika.

Tento JavaScriptový kód ukazuje, jak nastavit jazykovou kontrolu pro PowerPoint: xxx Why is LanguageId missing from JavaScript PortionFormat class?

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
    portionFormat.setLanguageId("zh-CN");// set the Id of a proofing language
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

## **Ukázkový příklad online**

Vyzkoušejte online aplikaci [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata) a podívejte se, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## **Často kladené otázky**

**Jak mohu odstranit vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdný řetězec, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost předtím odstraňovat ani kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu získat přístup k vlastnostem prezentace bez úplného načtení prezentace?**

Ano. Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) a poté [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) k načtení uložených metadat dokumentu bez vytváření instance [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/). Viz [Build a Lightweight Presentation Inventory](/slides/cs/nodejs-java/examine-presentation/) pro kompletní příklad reportování a omezení specifických formátů.