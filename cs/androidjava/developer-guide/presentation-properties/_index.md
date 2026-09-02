---
title: Správa vlastností prezentace na Androidu
linktitle: Vlastnosti prezentace
type: docs
weight: 70
url: /cs/androidjava/presentation-properties/
keywords:
- Vlastnosti PowerPoint
- Vlastnosti prezentace
- Vlastnosti dokumentu
- Zabudované vlastnosti
- Uživatelské vlastnosti
- Pokročilé vlastnosti
- Správa vlastností
- Úprava vlastností
- Metadata dokumentu
- Úprava metadat
- Jazyk pro kontrolu pravopisu
- Výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Ovládejte vlastnosti prezentací v Aspose.Slides pro Android pomocí Javy a zefektivněte vyhledávání, brandování a workflow ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Zabudované** a **Uživatelské**. Oba typy vlastností lze snadno získat a spravovat pomocí API Aspose.Slides.

Aspose.Slides umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím rozhraní [IDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/). Instance tohoto rozhraní je vrácena metodou [Presentation.getDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getDocumentProperties--). Následující příklady ukazují, jak číst, upravovat a spravovat tyto vlastnosti.

{{% alert color="info" title="Poznámka" %}}
Všimněte si, že pole **Application** a **AppVersion** nelze upravit. Aspose.Slides je při každém uložení přepíše, takže uložená prezentace vždy uvádí název produktu Aspose.Slides a verzi knihovny, která ji vytvořila. Jakákoliv hodnota předaná `setNameOfApplication` je při zápisu prezentace zahozena.
{{% /alert %}} 

## **Vlastnosti dokumentu v PowerPointu**

Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentace. Stačí kliknout na ikonu Office a následně vybrat položku **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007, jak je ukázáno níže:

|**Výběr položky Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| ** **|

Po výběru položky **Advanced Properties** se zobrazí dialogové okno, které umožňuje spravovat vlastnosti dokumentu souboru PowerPoint, jak je uvedeno níže na obrázku:

|**Dialog Vlastností**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| ** **|

V výše uvedeném **Dialogu Vlastností** můžete vidět mnoho záložek, jako **General**, **Summary**, **Statistics**, **Contents** a **Custom**. Všechny tyto záložky umožňují konfigurovat různé typy informací souvisejících se soubory PowerPoint. Záložka **Custom** slouží k správě uživatelských vlastností souborů PowerPoint.

### Práce s vlastnostmi dokumentu pomocí Aspose.Slides pro Android via Java

Jak jsme již dříve popsali, Aspose.Slides pro Android pomocí Java podporuje dva typy vlastností dokumentu, a to **Zabudované** a **Uživatelské**. Vývojáři tak mohou přistupovat k oběma typům vlastností pomocí API Aspose.Slides pro Android pomocí Java. Aspose.Slides pro Android pomocí Java poskytuje třídu [IDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties), která představuje vlastnosti dokumentu spojené se souborem prezentace prostřednictvím vlastnosti **Presentation.DocumentProperties**.

Vývojáři mohou použít vlastnost **IDocumentProperties**, kterou vystavuje objekt [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation), k přístupu k vlastnostem dokumentu souborů prezentace, jak je uvedeno níže:

## **Přístup k zabudovaným vlastnostem**

Tyto vlastnosti, které jsou dostupné prostřednictvím objektu [IDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties), zahrnují: **Creator** (Autor), **Description**, **Keywords**, **Created** (Datum vytvoření), **Modified** (Datum úpravy), **Printed** (Datum posledního tisku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Je sdíleno mezi různými tvůrci?), **PresentationFormat**, **Subject** a **Title**.

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která reprezentuje prezentaci
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt IDocumentProperties spojený s prezentací
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Zobrazte zabudované vlastnosti
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

## **Upravit zabudované vlastnosti**

Úprava zabudovaných vlastností souborů prezentace je stejně jednoduchá jako jejich čtení. Stačí přiřadit řetězcovou hodnotu libovolné požadované vlastnosti a hodnota se upraví. V níže uvedeném příkladu jsme ukázali, jak lze pomocí Aspose.Slides pro Android pomocí Java upravit zabudované vlastnosti dokumentu prezentace.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt IDocumentProperties spojený s prezentací
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Nastavte zabudované vlastnosti
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

Tento příklad upravuje zabudované vlastnosti prezentace, jak je znázorněno níže:

|**Zabudované vlastnosti dokumentu po úpravě**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| ** **|

## **Přidat vlastní vlastnosti dokumentu**

Aspose.Slides pro Android pomocí Java také umožňuje vývojářům přidávat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže uvedený příklad přidá tři vlastní vlastnosti, poté vyhledá název uložený na indexu 2 a tuto vlastnost odstraní, takže uložená prezentace si ponechá dvě z nich. Vlastní vlastnosti jsou indexovány abecedně, nikoli v pořadí, v jakém byly přidány.

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

|**Přidané vlastní vlastnosti dokumentu**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| ** **|

## **Přístup a úprava vlastních vlastností**

Aspose.Slides pro Android pomocí Java také umožňuje vývojářům přistupovat k hodnotám vlastních vlastností. Níže je uveden příklad, který ukazuje, jak můžete přistupovat a upravovat všechny tyto vlastní vlastnosti pro prezentaci.

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
    
        // Upravit hodnoty vlastních vlastností
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Uložte prezentaci do souboru
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Tento příklad upravuje vlastní vlastnosti [PPTX](https://docs.fileformat.com/presentation/pptx/) prezentace. Následující obrázky ukazují vlastní vlastnosti prezentace před a po úpravě:

|**Vlastní vlastnosti před úpravou**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| ** **|

|**Vlastní vlastnosti po úpravě**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| ** **|

## **Pokročilé vlastnosti dokumentu**

{{% alert color="info" title="Poznámka" %}}
Nové metody [ReadDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), a [WriteBindedPresentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) byly přidány do [IPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo), logika setteru vlastnosti [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) byla změněna.
{{% /alert %}} 

Tyto dvě nové metody byly přidány do rozhraní [IPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo). Poskytují rychlý přístup k vlastnostem dokumentu a umožňují měnit a aktualizovat vlastnosti bez načítání celé prezentace.

Typický scénář načtení vlastností, změny některé hodnoty a aktualizace dokumentu lze implementovat následujícím způsobem:

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

Existuje další způsob, jak použít vlastnosti konkrétní prezentace jako šablonu pro aktualizaci vlastností v jiných prezentacích:

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

## **Nastavit jazyk pro kontrolu pravopisu**

Aspose.Slides poskytuje vlastnost LanguageId (vystavenou třídou PortionFormat), která umožňuje nastavit jazyk pro kontrolu pravopisu v dokumentu PowerPoint. Jazyk pro kontrolu pravopisu je jazyk, pro který jsou v PowerPointu kontrolovány pravopis a gramatika.

Tento Java kód ukazuje, jak nastavit jazyk pro kontrolu pravopisu v PowerPoint:

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

    portionFormat.setLanguageId("zh-CN"); // nastavte Id jazyka pro kontrolu pravopisu

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavit výchozí jazyk**

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

    // Zkontroluje jazyk první části
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ukázkový příklad**

Vyzkoušejte online aplikaci [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata), abyste viděli, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## **Často kladené otázky**

**Jak mohu odstranit zabudovanou vlastnost z prezentace?**

Zabudované vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Nicméně můžete buď změnit jejich hodnoty, nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost předem odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu přistupovat k vlastnostem prezentace bez úplného načtení prezentace?**

Ano. Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) a poté [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) k načtení uložených metadat dokumentu bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/). Viz [Build a Lightweight Presentation Inventory](/slides/cs/androidjava/examine-presentation/) pro úplný příklad reportování a omezení specifických formátů.