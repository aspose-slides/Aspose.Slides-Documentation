---
title: Správa vlastností prezentace v Java
linktitle: Vlastnosti prezentace
type: docs
weight: 70
url: /cs/java/presentation-properties/
keywords:
- Vlastnosti PowerPoint
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
- Prezentace
- Java
- Aspose.Slides
description: "Spravujte vlastnosti prezentací v Aspose.Slides pro Java a zefektivněte vyhledávání, branding a pracovní postup ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Built-in** a **Custom**. Oba tyto typy vlastností lze snadno získat a spravovat pomocí API Aspose.Slides.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím rozhraní [IDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/) . Instance tohoto rozhraní je vrácena metodou [Presentation.getDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getDocumentProperties--) . Následující příklady ukazují, jak číst, upravovat a spravovat tyto vlastnosti.

{{% alert color="primary" %}} 

Upozorňujeme, že pole **Application** a **Producer** nelze upravit, protože tato pole budou vždy zobrazovat "Aspose Ltd." a "Aspose.Slides for Java x.x.x".

{{% /alert %}} 

## **Vlastnosti dokumentu v PowerPointu**

Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentů souborů prezentace. Stačí kliknout na ikonu Office a poté na položku nabídky **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007, jak je znázorněno níže:

|**Výběr položky nabídky Advanced Properties**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Po výběru položky **Advanced Properties** se zobrazí dialogové okno, které umožňuje spravovat vlastnosti dokumentu PowerPointu, jak je ukázáno níže na obrázku:

|**Dialog Vlastností**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
V výše uvedeném **Dialogu Vlastností** můžete vidět, že obsahuje mnoho záložek, jako jsou **General**, **Summary**, **Statistics**, **Contents** a **Custom**. Všechny tyto záložky umožňují konfigurovat různé typy informací souvisejících se soubory PowerPoint. Záložka **Custom** slouží ke správě vlastních (custom) vlastností souborů PowerPoint.

### Práce s vlastnostmi dokumentu pomocí Aspose.Slides pro Java

Jak jsme již popisovali, Aspose.Slides pro Java podporuje dva druhy vlastností dokumentu, což jsou **Built-in** a **Custom** vlastnosti. Vývojáři tak mohou přistupovat k oběma druhům vlastností pomocí API Aspose.Slides pro Java. Aspose.Slides pro Java poskytuje třídu [IDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties) , která představuje vlastnosti dokumentu spojené se souborem prezentace prostřednictvím vlastnosti **Presentation.DocumentProperties**.

Vývojáři mohou použít vlastnost **IDocumentProperties** vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) k přístupu k vlastnostem dokumentu souborů prezentace, jak je popsáno níže:

## **Přístup k vestavěným vlastnostem**

Tyto vlastnosti, které jsou poskytovány objektem [IDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties) , zahrnují: **Creator** (Autor), **Description**, **Keywords**, **Created** (Datum vytvoření), **Modified** (Datum úpravy), **Printed** (Datum posledního tisku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Je sdílen mezi různými tvůrci?), **PresentationFormat**, **Subject** a **Title**.

```java
// Vytvořte instanci třídy Presentation, která představuje prezentaci
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt IDocumentProperties spojený s prezentací
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Zobrazte vestavěné vlastnosti
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

## **Upravit vestavěné vlastnosti**

Úprava vestavěných vlastností souborů prezentace je stejně snadná jako jejich získání. Stačí přiřadit řetězcovou hodnotu požadované vlastnosti a hodnota se změní. V níže uvedeném příkladu jsme ukázali, jak lze pomocí Aspose.Slides pro Java upravit vestavěné vlastnosti dokumentu prezentace.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt IDocumentProperties spojený s prezentací
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Nastavte vestavěné vlastnosti
    dp.setAuthor("Aspose.Slides for Java");
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

Tento příklad upravuje vestavěné vlastnosti prezentace, jak lze vidět níže:

|**Vestavěné vlastnosti dokumentu po úpravě**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Přidat vlastní vlastnosti dokumentu**

Aspose.Slides pro Java také umožňuje vývojářům přidávat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže je uveden příklad, který ukazuje, jak nastavit vlastní vlastnosti pro prezentaci.

```java
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
    
    // Odebrání vybrané vlastnosti
    dProps.removeCustomProperty(getPropertyName);
    
    // Uložení prezentace
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Přidány vlastní vlastnosti dokumentu**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Přístup a úprava vlastních vlastností**

Aspose.Slides pro Java také umožňuje vývojářům získat hodnoty vlastních vlastností. Níže je uveden příklad, který ukazuje, jak můžete získat a upravit všechny tyto vlastní vlastnosti pro prezentaci.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt DocumentProperties spojený s prezentací
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Přístup a úprava vlastních vlastností
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Zobrazení názvů a hodnot vlastních vlastností
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Úprava hodnot vlastních vlastností
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Uložte prezentaci do souboru
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Tento příklad upravuje vlastní vlastnosti [PPTX ](https://docs.fileformat.com/presentation/pptx/) prezentace. Následující obrázky ukazují vlastní vlastnosti prezentace před a po úpravě:

|**Vlastní vlastnosti před úpravou**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Vlastní vlastnosti po úpravě**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Rozšířené vlastnosti dokumentu**

{{% alert color="primary" %}} 

Byly přidány nové metody [ReadDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), a [WriteBindedPresentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) do [IPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentationInfo) , logika nastavení vlastnosti [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) byla změněna.

{{% /alert %}} 

Tyto dvě nové metody [ReadDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) a [UpdateDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) byly přidány do rozhraní [IPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentationInfo). Poskytují rychlý přístup k vlastnostem dokumentu a umožňují změnit a aktualizovat vlastnosti bez načítání celé prezentace.

Typický scénář načtení vlastností, změna hodnoty a aktualizace dokumentu lze implementovat následovně:

```java
// přečtěte informace o prezentaci
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// získejte aktuální vlastnosti
IDocumentProperties props = info.readDocumentProperties();

// nastavte nové hodnoty polí Author a Title
props.setAuthor("New Author");
props.setTitle("New Title");

// aktualizujte prezentaci s novými hodnotami
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Existuje další způsob, jak použít vlastnosti konkrétní prezentace jako šablonu pro aktualizaci vlastností v jiných prezentacích:

```java
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
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Nová šablona může být vytvořena od nuly a poté použita k aktualizaci více prezentací:

```java
DocumentProperties template = new DocumentProperties();\

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
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Nastavit jazyk kontroly pravopisu**

Aspose.Slides poskytuje vlastnost LanguageId (poskytnutou třídou PortionFormat), která umožňuje nastavit jazyk kontroly pravopisu pro dokument PowerPoint. Jazyk kontroly pravopisu je jazyk, pro který jsou v PowerPointu kontrolovány pravopis a gramatika.

Tento Java kód ukazuje, jak nastavit jazyk kontroly pravopisu pro PowerPoint: xxx Proč chybí LanguageId ve třídě Java PortionFormat?

```java
Presentation pres = new Presentation(pptxFileName);
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

    portionFormat.setLanguageId("zh-CN"); // nastavte ID jazyka pro kontrolu pravopisu

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavit výchozí jazyk**

Tento Java kód ukazuje, jak nastavit výchozí jazyk pro celou PowerPoint prezentaci:

```java
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

## **Živý příklad**

Vyzkoušejte online aplikaci [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata) a podívejte se, jak pracovat s vlastnostmi dokumentu pomocí Aspose.Slides API:

[![Zobrazit a upravit metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## ***FAQ**

**Jak mohu odstranit vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, pokud přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost předtím odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu získat vlastnosti prezentace bez úplného načtení prezentace?**

Ano, můžete získat vlastnosti prezentace bez úplného načtení prezentace pomocí metody `getPresentationInfo` ze třídy [PresentationFactory](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/) . Pak využijte metodu `readDocumentProperties` poskytovanou rozhraním [IPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/) k efektivnímu načtení vlastností, čímž šetříte paměť a zvyšujete výkon.