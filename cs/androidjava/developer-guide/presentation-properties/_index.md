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
- Rozšířené vlastnosti
- Správa vlastností
- Úprava vlastností
- Metadata dokumentu
- Úprava metadat
- Jazyk pravopisu
- Výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Zvládněte vlastnosti prezentace v Aspose.Slides pro Android přes Java a zjednodušte vyhledávání, značkování a pracovní postup ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Built-in** a **Custom**. Oba tyto typy vlastností lze snadno získat a spravovat pomocí rozhraní Aspose.Slides API.

Aspose.Slides umožňuje pracovat s vlastnostmi prezentace prostřednictvím rozhraní [IDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/) . Instance tohoto rozhraní je vrácena metodou [Presentation.getDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) . Následující příklady ukazují, jak číst, měnit a spravovat tyto vlastnosti.

{{% alert color="primary" %}} 

Všimněte si, že pole **Application** a **Producer** nelze upravit, protože tato pole vždy zobrazí „Aspose Ltd.“ a „Aspose.Slides for Android via Java x.x.x“.

{{% /alert %}} 

## **Vlastnosti dokumentu v PowerPointu**

Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentace. Stačí kliknout na ikonu Office a poté na položku nabídky **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007, jak je znázorněno níže:

|**Výběr položky Pokročilé vlastnosti**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Po výběru položky **Advanced Properties** se zobrazí dialogové okno, které umožňuje spravovat vlastnosti dokumentu souboru PowerPoint, jak je vidět na následujícím obrázku:

|**Dialog Vlastností**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
V uvedeném **Dialogu Vlastností** můžete vidět mnoho kartových stránek, jako jsou **Obecné**, **Shrnutí**, **Statistiky**, **Obsah** a **Vlastní**. Všechny tyto karty umožňují konfigurovat různé druhy informací souvisejících se soubory PowerPoint. Karta **Vlastní** slouží ke správě vlastních vlastností souborů PowerPoint.



Práce s vlastnostmi dokumentu pomocí Aspose.Slides for Android via Java

Jak jsme již dříve popsali, Aspose.Slides for Android via Java podporuje dva druhy vlastností dokumentu, a to **Built-in** a **Custom**. Vývojáři tak mohou přistupovat k oběma typům vlastností pomocí API Aspose.Slides for Android via Java. Aspose.Slides for Android via Java poskytuje třídu [IDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties), která představuje vlastnosti dokumentu spojené s prezentačním souborem prostřednictvím vlastnosti **Presentation.DocumentProperties**.

Vývojáři mohou použít vlastnost **IDocumentProperties**, kterou vystavuje objekt [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation), k získání vlastností dokumentu prezentačních souborů, jak je popsáno níže:

## **Přístup k vestavěným vlastnostem**

Tyto vlastnosti, které jsou vystaveny objektem [IDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties), zahrnují: **Creator** (Autor), **Description**, **Keywords**, **Created** (Datum vytvoření), **Modified** (Datum úpravy), **Printed** (Datum posledního tisku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Je sdíleno mezi různými producenty?), **PresentationFormat**, **Subject** a **Title**.

```java
// Instancujte třídu Presentation, která představuje prezentaci
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Vytvořte referenci na objekt IDocumentProperties spojený s prezentací
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

Úprava vestavěných vlastností prezentačních souborů je tak snadná jako jejich získání. Stačí přiřadit řetězcovou hodnotu libovolné požadované vlastnosti a hodnota vlastnosti bude změněna. V níže uvedeném příkladu jsme ukázali, jak lze upravit vestavěné vlastnosti dokumentu prezentace pomocí Aspose.Slides for Android via Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Vytvořte referenci na objekt IDocumentProperties spojený s prezentací
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Nastavte vestavěné vlastnosti
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Uložte svou prezentaci do souboru
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Tento příklad upravuje vestavěné vlastnosti prezentace, které lze zobrazit takto:

|**Vestavěné vlastnosti dokumentu po úpravě**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Přidat vlastní vlastnosti dokumentu**

Aspose.Slides for Android via Java také umožňuje vývojářům přidat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže je uvedený příklad, který ukazuje, jak nastavit vlastní vlastnosti pro prezentaci.

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
    
    // Odstranění vybrané vlastnosti
    dProps.removeCustomProperty(getPropertyName);
    
    // Uložení prezentace
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Přidány vlastní vlastnosti dokumentu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Přístup a úprava vlastních vlastností**

Aspose.Slides for Android via Java také umožňuje vývojářům přistupovat k hodnotám vlastních vlastností. Níže je uvedený příklad, který ukazuje, jak můžete získat a upravit všechny tyto vlastní vlastnosti pro prezentaci.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Vytvořte referenci na objekt DocumentProperties spojený s prezentací
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Přístup a úprava vlastních vlastností
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Zobrazení názvů a hodnot vlastních vlastností
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Úprava hodnot vlastních vlastností
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Uložte svou prezentaci do souboru
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

## **Pokročilé vlastnosti dokumentu**

{{% alert color="primary" %}} 

Nové metody [ReadDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), a [WriteBindedPresentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) byly přidány do [IPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo), logika setteru vlastnosti [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) byla změněna.

{{% /alert %}} 

Dvě nové metody [ReadDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) a [UpdateDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) byly přidány do rozhraní [IPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo). Poskytují rychlý přístup k vlastnostem dokumentu a umožňují měnit a aktualizovat vlastnosti bez načtení celé prezentace.

Typický scénář načtení vlastností, změna některé hodnoty a aktualizace dokumentu lze implementovat následujícím způsobem:

```java
// načíst informace o prezentaci
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// získat aktuální vlastnosti
IDocumentProperties props = info.readDocumentProperties();

// nastavit nové hodnoty polí Autor a Titulek
props.setAuthor("New Author");
props.setTitle("New Title");

// aktualizovat prezentaci s novými hodnotami
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

## **Nastavit jazyk pravopisu**

Aspose.Slides poskytuje vlastnost LanguageId (vystavenou třídou PortionFormat), která vám umožní nastavit jazyk pravopisu pro dokument PowerPoint. Jazyk pravopisu je jazyk, pro který jsou kontrolovány pravopis a gramatika v PowerPointu.

Tento Java kód ukazuje, jak nastavit jazyk pravopisu pro PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?

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

    portionFormat.setLanguageId("zh-CN"); // nastavit ID jazykové kontroly

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavit výchozí jazyk**

Tento Java kód ukazuje, jak nastavit výchozí jazyk pro celou prezentaci PowerPoint:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Přidá nový obdélníkový tvar s textem
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Zkontroluje jazyk první části
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Živý příklad**

Vyzkoušejte online aplikaci [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata), abyste viděli, jak pracovat s vlastnostmi dokumentu pomocí Aspose.Slides API:

[![Zobrazit a upravit metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## ***Často kladené otázky**

**Jak mohu odstranit vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odebrat. Můžete však změnit jejich hodnoty nebo je nastavit na prázdno, pokud to daná vlastnost umožňuje.

**Co se stane, pokud přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte předtím vlastnost odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu získat vlastnosti prezentace, aniž bych načetl celou prezentaci?**

Ano, můžete získat vlastnosti prezentace, aniž byste načetli celou prezentaci, pomocí metody `getPresentationInfo` ze třídy [PresentationFactory](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationfactory/) . Poté použijte metodu `readDocumentProperties` poskytovanou rozhraním [IPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/) k efektivnímu načtení vlastností, čímž šetříte paměť a zvyšujete výkon.