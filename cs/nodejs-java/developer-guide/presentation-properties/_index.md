---
title: Správa vlastností prezentace v JavaScriptu
linktitle: Vlastnosti prezentace
type: docs
weight: 70
url: /cs/nodejs-java/presentation-properties/
keywords:
- Vlastnosti PowerPointu
- vlastnosti prezentace
- vlastnosti dokumentu
- vestavěné vlastnosti
- vlastní vlastnosti
- pokročilé vlastnosti
- správa vlastností
- úprava vlastností
- metadata dokumentu
- úprava metadat
- jazyk korektury
- výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Ovládejte vlastnosti prezentace v Aspose.Slides for Node.js via Java a zjednodušte vyhledávání, značkování a workflow ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Vestavěné** a **Vlastní**. Oba typy vlastností lze snadno přistupovat a spravovat pomocí API Aspose.Slides.

Aspose.Slides umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím třídy [DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties/). Instance této třídy je vrácena metodou [Presentation.getDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getDocumentProperties). Následující příklady ukazují, jak číst, upravovat a spravovat tyto vlastnosti.

{{% alert color="primary" %}} 

Všimněte si, že hodnoty polí **Application** a **Producer** nelze nastavit, protože v těchto polích budou zobrazeny údaje Aspose Ltd. a Aspose.Slides for Node.js via Java x.x.x.

{{% /alert %}} 

## **Správa vlastností prezentace**

Microsoft PowerPoint nabízí možnost přidávat některé vlastnosti k souborům prezentace. Tyto vlastnosti dokumentu umožňují uložit užitečné informace spolu s dokumenty (soubory prezentace). Existují dva druhy vlastností dokumentu:

- Systémově definované (Vestavěné) vlastnosti
- Uživatelem definované (Vlastní) vlastnosti

**Vestavěné** vlastnosti obsahují obecné informace o dokumentu, jako je název dokumentu, jméno autora, statistiky dokumentu atd. **Vlastní** vlastnosti jsou definovány uživateli jako páry **Název/Hodnota**, kde jak název, tak hodnota jsou určeny uživatelem. Pomocí Aspose.Slides for Node.js via Java mohou vývojáři přistupovat a upravovat hodnoty vestavěných i vlastních vlastností.

## **Vlastnosti dokumentu v PowerPointu**

Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentace. Stačí kliknout na ikonu Office a poté na položku nabídky **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007, jak je znázorněno níže:

|**Výběr položky nabídky Pokročilé vlastnosti**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Po výběru položky **Advanced Properties** se zobrazí dialogové okno, které umožňuje spravovat vlastnosti dokumentu souboru PowerPoint, jak je vidět na obrázku:

|**Dialog vlastností**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

V dialogu **Properties Dialog** můžete vidět mnoho záložek, jako **General**, **Summary**, **Statistics**, **Contents** a **Custom**. Všechny tyto záložky umožňují konfigurovat různé typy informací souvisejících se soubory PowerPoint. Záložka **Custom** slouží k správě vlastních vlastností souborů PowerPoint.

### Práce s vlastnostmi dokumentu pomocí Aspose.Slides for Node.js via Java

Jak jsme již zmínili, Aspose.Slides for Node.js via Java podporuje dva typy vlastností dokumentu: **Vestavěné** a **Vlastní**. Vývojáři tedy mohou přistupovat k oběma typům vlastností pomocí API Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java poskytuje třídu [DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties), která představuje vlastnosti dokumentu spojené s souborem prezentace prostřednictvím vlastnosti **Presentation.DocumentProperties**.

Vývojáři mohou použít vlastnost **DocumentProperties** vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) k přístupu k vlastnostem dokumentu souborů prezentace, jak je popsáno níže:

## **Přístup k vestavěným vlastnostem**

Tyto vlastnosti vystavené objektem [DocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties) zahrnují: **Creator** (Autor), **Description**, **Keywords**, **Created** (Datum vytvoření), **Modified** (Datum úpravy), **Printed** (Datum posledního tisku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Je sdílen mezi různými producenty?), **PresentationFormat**, **Subject** a **Title**

```javascript
// Vytvořte instanci třídy Presentation, která představuje prezentaci
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt IDocumentProperties přidružený k prezentaci
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

Úprava vestavěných vlastností souborů prezentace je tak snadná, jako jejich čtení. Jednoduše přiřadíte řetězcovou hodnotu libovolné požadované vlastnosti a hodnota se upraví. V níže uvedeném příkladu jsme ukázali, jak lze upravit vestavěné vlastnosti dokumentu prezentace pomocí Aspose.Slides for Node.js via Java.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt IDocumentProperties přidružený k prezentaci
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

Tento příklad upravuje vestavěné vlastnosti prezentace, jak je znázorněno níže:

|**Vestavěné vlastnosti dokumentu po úpravě**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Přidání vlastních vlastností dokumentu**

Aspose.Slides for Node.js via Java také umožňuje vývojářům přidávat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže je uveden příklad, který ukazuje, jak nastavit vlastní vlastnosti pro prezentaci.

```javascript
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

|**Přidané vlastní vlastnosti dokumentu**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Přístup a úprava vlastních vlastností**

Aspose.Slides for Node.js via Java také umožňuje vývojářům přistupovat k hodnotám vlastních vlastností. Níže je uveden příklad, který ukazuje, jak můžete přistupovat a upravovat všechny tyto vlastní vlastnosti pro prezentaci.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt DocumentProperties přidružený k prezentaci
    var dp = pres.getDocumentProperties();
    // Přístup k vlastním vlastnostem a jejich úprava
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Zobrazte názvy a hodnoty vlastních vlastností
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Upravte hodnoty vlastních vlastností
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

Tento příklad upravuje vlastní vlastnosti [PPTX ](https://docs.fileformat.com/presentation/pptx/)prezentace. Následující obrázky ukazují vlastní vlastnosti prezentace před a po úpravě:

|**Vlastní vlastnosti před úpravou**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Vlastní vlastnosti po úpravě**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Rozšířené vlastnosti dokumentu**

{{% alert color="primary" %}} 

Nové metody [ReadDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) a [WriteBindedPresentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) byly přidány do třídy [PresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo); logika setteru vlastnosti [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) byla změněna.

{{% /alert %}} 

Obě nové metody [ReadDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) a [UpdateDocumentProperties](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) byly přidány do třídy [PresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PresentationInfo). Poskytují rychlý přístup k vlastnostem dokumentu a umožňují měnit a aktualizovat vlastnosti bez načítání celé prezentace.

Typický scénář načíst vlastnosti, změnit některou hodnotu a aktualizovat dokument lze implementovat následujícím způsobem:

```javascript
// načíst informace o prezentaci
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// získat aktuální vlastnosti
var props = info.readDocumentProperties();
// nastavit nové hodnoty polí Author a Title
props.setAuthor("New Author");
props.setTitle("New Title");
// aktualizovat prezentaci s novými hodnotami
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Existuje další způsob, jak použít vlastnosti konkrétní prezentace jako šablonu pro aktualizaci vlastností v jiných prezentacích:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Nová šablona může být vytvořena od začátku a poté použita k aktualizaci více prezentací:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Nastavení jazykové korektury**

Aspose.Slides poskytuje vlastnost LanguageId (vystavenou třídou PortionFormat) pro nastavení jazyka korektury pro dokument PowerPoint. Jazyk korektury je jazyk, pro který jsou kontrolovány pravopis a gramatika v PowerPointu.

Tento JavaScriptový kód ukazuje, jak nastavit jazyk korektury pro PowerPoint: xxx Why is LanguageId missing from JavaScript PortionFormat class?

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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
    portionFormat.setLanguageId("zh-CN"); // nastavte Id jazykové korektury
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

## **Živý příklad**

Vyzkoušejte online aplikaci [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata) a zjistěte, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## ***FAQ**

**Jak mohu odstranit vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete je však změnit nebo nastavit na prázdnou hodnotu, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte ji předtím odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu přistupovat k vlastnostem prezentace bez úplného načtení prezentace?**

Ano, můžete přistupovat k vlastnostem prezentace bez úplného načtení prezentace pomocí metody `getPresentationInfo` ze třídy [PresentationFactory](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/). Poté využijte metodu `readDocumentProperties` poskytnutou třídou [PresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/) k efektivnímu načtení vlastností, čímž ušetříte paměť a zvýšíte výkon.