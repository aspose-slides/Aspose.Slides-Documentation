---
title: Správa vlastností prezentace v Javě
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
- prezentace
- Java
- Aspose.Slides
description: "Ovládněte vlastnosti prezentace v Aspose.Slides pro Java a zjednodušte vyhledávání, branding a workflow ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Built-in** a **Custom**. Oba tyto typy vlastností lze snadno přistupovat a spravovat pomocí API Aspose.Slides.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím rozhraní [IDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties/) . Instance tohoto rozhraní je vrácena metodou [Presentation.getDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getDocumentProperties--) . Následující příklady ukazují, jak číst, upravovat a spravovat tyto vlastnosti.

{{% alert color="info" title="Note" %}}
Please note that the **Application** and **AppVersion** fields cannot be modified. Aspose.Slides rewrites them on every save, so a saved presentation always reports "Aspose.Slides for Java" and the version of the library that produced it. Any value passed to `setNameOfApplication` is discarded when the presentation is written.
{{% /alert %}} 

## **Vlastnosti dokumentu v PowerPointu**

Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentace. Stačí kliknout na ikonu Office a poté na položku nabídky **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007, jak je ukázáno níže:

|**Výběr položky nabídky Pokročilé vlastnosti**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Po výběru položky **Advanced Properties** se zobrazí dialogové okno, které umožňuje spravovat vlastnosti dokumentu souboru PowerPoint, jak je znázorněno níže:

|**Dialog Vlastností**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
V tomto **Properties Dialog** můžete vidět mnoho záložek, jako **General**, **Summary**, **Statistics**, **Contents** a **Custom**. Všechny tyto záložky umožňují konfigurovat různé druhy informací souvisejících se soubory PowerPoint. Záložka **Custom** slouží k správě vlastních vlastností souborů PowerPoint.

### Práce s vlastnostmi dokumentu pomocí Aspose.Slides pro Java

Jak bylo dříve popsáno, Aspose.Slides pro Java podporuje dva druhy vlastností dokumentu, **Built-in** a **Custom**. Vývojáři tak mohou přistupovat k oběma typům vlastností pomocí API Aspose.Slides pro Java. Aspose.Slides pro Java poskytuje třídu [IDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties) , která představuje vlastnosti dokumentu spojené se souborem prezentace prostřednictvím vlastnosti **Presentation.DocumentProperties**.

Vývojáři mohou použít vlastnost **IDocumentProperties**, kterou vystavuje objekt [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation) , k přístupu k vlastnostem dokumentu souborů prezentace, jak je popsáno níže:

## **Přístup k vestavěným vlastnostem**

Tyto vlastnosti vystavené objektem [IDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties) zahrnují: **Creator** (Autor), **Description**, **Keywords**, **Created** (Datum vytvoření), **Modified** (Datum úpravy), **Printed** (Datum posledního tisku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Je sdílen mezi různými producenty?), **PresentationFormat**, **Subject** a **Title**.

```java
import com.aspose.slides.*;

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

Úprava vestavěných vlastností souborů prezentace je stejně jednoduchá jako jejich přístup. Jednoduše přiřadíte řetězcovou hodnotu libovolné požadované vlastnosti a hodnota vlastnosti bude změněna. V níže uvedeném příkladu jsme ukázali, jak lze upravit vestavěné vlastnosti dokumentu prezentace pomocí Aspose.Slides pro Java.

```java
import com.aspose.slides.*;

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

Tento příklad upravuje vestavěné vlastnosti prezentace, které lze vidět níže:

|**Vestavěné vlastnosti dokumentu po úpravě**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Přidat vlastní vlastnosti dokumentu**

Aspose.Slides pro Java také umožňuje vývojářům přidat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže uvedený příklad přidá tři vlastní vlastnosti, poté vyhledá název uložený na indexu 2 a tuto vlastnost odstraní, takže uložená prezentace si ponechá dvě z nich. Vlastní vlastnosti jsou indexovány v abecedním pořadí, nikoli v pořadí, v jakém byly přidány.

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
    
    // Uložení prezentace
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Vlastní vlastnosti dokumentu přidány**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Přístup a úprava vlastních vlastností**

Aspose.Slides pro Java také umožňuje vývojářům přistupovat k hodnotám vlastních vlastností. Níže je uveden příklad, který ukazuje, jak můžete přistupovat a upravovat všechny tyto vlastní vlastnosti pro prezentaci.

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

Tento příklad upravuje vlastní vlastnosti [PPTX ](https://docs.fileformat.com/presentation/pptx/)prezentace. Následující obrázky ukazují vlastní vlastnosti prezentace před a po úpravě:

|**Vlastní vlastnosti před úpravou**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Vlastní vlastnosti po úpravě**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Rozšířené vlastnosti dokumentu**

{{% alert color="info" title="Note" %}}
New methods [ReadDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), and [WriteBindedPresentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) have been added to [IPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentationInfo), logic of the [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/cs/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) property setter has been changed.
{{% /alert %}} 

Two new methods [ReadDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) and [UpdateDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) have been added to [IPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPresentationInfo) interface. They provide quick access to document properties and allow to change and update properties without loading a whole presentation.

The typical scenario load the properties, change some value and update the document can be implemented in the following way:

```java
import com.aspose.slides.*;

// načíst informace o prezentaci
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// získat aktuální vlastnosti
IDocumentProperties props = info.readDocumentProperties();

// nastavit nové hodnoty polí Author a Title
props.setAuthor("New Author");
props.setTitle("New Title");

// aktualizovat prezentaci s novými hodnotami
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

There is another way to use properties of a particular presentation as a template to update properties in other presentations:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
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

A new template can be created from scratch and then used to update multiple presentations:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Nastavit jazyk kontroly pravopisu**

Aspose.Slides poskytuje vlastnost LanguageId (vystavenou třídou PortionFormat), která vám umožní nastavit jazyk kontroly pravopisu pro dokument PowerPoint. Jazyk kontroly pravopisu je jazyk, pro který jsou v PowerPointu kontrolovány pravopis a gramatika.

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

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

    portionFormat.setLanguageId("zh-CN"); // nastavit Id jazyka kontroly pravopisu

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavit výchozí jazyk**

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

## **Ukázkový příklad**

Vyzkoušejte [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata) online aplikaci a podívejte se, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## **Často kladené otázky**

**Jak mohu odstranit vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete je však změnit nebo nastavit na prázdnou hodnotu, pokud to daná vlastnost umožňuje.

**Co se stane, pokud přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou hodnotou. Nemusíte vlastnost předem odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu přistupovat k vlastnostem prezentace bez úplného načtení prezentace?**

Ano. Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) a poté [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) k načtení uložených metadat dokumentu bez vytváření instance [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) . Viz [Build a Lightweight Presentation Inventory](/slides/cs/java/examine-presentation/) pro kompletní příklad výstupu a omezení specifická pro formát.