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
- Vestavěné vlastnosti
- Vlastní vlastnosti
- Rozšířené vlastnosti
- Správa vlastností
- Úprava vlastností
- Metadata dokumentu
- Úprava metadat
- Jazyk korektury
- Výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Zvládněte vlastnosti prezentace v Aspose.Slides pro Android přes Java a zefektivněte vyhledávání, značkování a pracovní postup ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Vestavěné** a **Vlastní**. Oba tyto typy vlastností lze snadno přistupovat a spravovat pomocí API Aspose.Slides.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím rozhraní [IDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties/). Instance tohoto rozhraní je vrácena metodou [Presentation.getDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getDocumentProperties--). Následující příklady ukazují, jak číst, měnit a spravovat tyto vlastnosti.

{{% alert color="info" %}} 

Upozorňujeme, že pole **Application** a **AppVersion** nelze měnit. Aspose.Slides je přepisuje při každém uložení, takže uložená prezentace vždy uvádí název produktu Aspose.Slides a verzi knihovny, která ji vytvořila. Jakákoli hodnota předaná metodě `setNameOfApplication` je při zápisu prezentace zahozena.

{{% /alert %}} 

## **Vlastnosti dokumentu v PowerPointu**

Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentací. Stačí kliknout na ikonu Office a poté na položku nabídky **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007, jak je ukázáno níže:

|**Vybrání položky nabídky Advanced Properties**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Po výběru položky **Advanced Properties** se zobrazí dialog, který umožňuje spravovat vlastnosti dokumentu souboru PowerPoint, jak je ukázáno na obrázku níže:

|**Dialog Vlastností**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
V výše uvedeném **Dialogu Vlastností** můžete vidět, že existuje mnoho záložek, jako jsou **General**, **Summary**, **Statistics**, **Contents** a **Custom**. Všechny tyto záložky umožňují konfigurovat různé typy informací souvisejících se soubory PowerPoint. Záložka **Custom** slouží k správě vlastních vlastností souborů PowerPoint.

## **Práce s vlastnostmi dokumentu pomocí Aspose.Slides pro Android přes Java**

Jak jsme již dříve popisovali, Aspose.Slides pro Android přes Java podporuje dva typy vlastností dokumentu, a to **Vestavěné** a **Vlastní** vlastnosti. Vývojáři tak mohou přistupovat k oběma typům vlastností pomocí API Aspose.Slides pro Android přes Java. Aspose.Slides pro Android přes Java poskytuje třídu [IDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties) která představuje vlastnosti dokumentu spojené s souborem prezentace prostřednictvím vlastnosti **Presentation.DocumentProperties**.

Vývojáři mohou pomocí vlastnosti **IDocumentProperties**, která je vystavena objektem [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation), přistupovat k vlastnostem dokumentu souborů prezentace, jak je popsáno níže:

## **Přístup k vestavěným vlastnostem**

Tyto vlastnosti, které jsou vystaveny objektem [IDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties) zahrnují: **Creator** (Autor), **Description**, **Keywords**, **Created** (Datum vytvoření), **Modified** (Datum úpravy), **Printed** (Datum posledního tisku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Je sdíleno mezi různými producenty?), **PresentationFormat**, **Subject** a **Title**

```java
import com.aspose.slides.*;

// Vytvořte instanci třídy Presentation, která představuje prezentaci
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt IDocumentProperties přidružený k prezentaci
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

## **Úprava vestavěných vlastností**

Úprava vestavěných vlastností souborů prezentace je stejně snadná jako jejich přístup. Jednoduše můžete přiřadit řetězcovou hodnotu libovolné požadované vlastnosti a hodnota vlastnosti bude změněna. V níže uvedeném příkladu jsme ukázali, jak lze upravit vestavěné vlastnosti dokumentu prezentace pomocí Aspose.Slides pro Android přes Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt IDocumentProperties přidružený k prezentaci
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

Tento příklad mění vestavěné vlastnosti prezentace, které lze zobrazit níže:

|**Vestavěné vlastnosti dokumentu po úpravě**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Přidání vlastních vlastností dokumentu**

Aspose.Slides pro Android přes Java také umožňuje vývojářům přidávat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže uvedený příklad přidá tři vlastní vlastnosti, poté vyhledá název uložený na indexu 2 a tuto vlastnost odstraní, takže uložená prezentace si ponechá dvě z nich. Vlastní vlastnosti jsou indexovány v abecedním pořadí, nikoli v pořadí, v jakém byly přidány.

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

|**Přidané vlastní vlastnosti dokumentu**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Přístup a úprava vlastních vlastností**

Aspose.Slides pro Android přes Java také umožňuje vývojářům přistupovat k hodnotám vlastních vlastností. Níže je uveden příklad, který ukazuje, jak můžete přistupovat a měnit všechny tyto vlastní vlastnosti pro prezentaci.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Vytvořte odkaz na objekt DocumentProperties přidružený k prezentaci
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

Tento příklad mění vlastní vlastnosti [PPTX ](https://docs.fileformat.com/presentation/pptx/) prezentace. Následující obrázky ukazují vlastní vlastnosti prezentace před a po úpravě:

|**Vlastní vlastnosti před úpravou**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Vlastní vlastnosti po úpravě**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Rozšířené vlastnosti dokumentu**

{{% alert color="info" %}} 

Byly přidány nové metody [ReadDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), a [WriteBindedPresentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) do rozhraní [IPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentationInfo), logika nastaviteli vlastnosti [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) byla změněna.

{{% /alert %}} 

Tyto dvě nové metody byly přidány do rozhraní [IPresentationInfo]. Poskytují rychlý přístup k vlastnostem dokumentu a umožňují měnit a aktualizovat vlastnosti bez načítání celé prezentace.

Typický scénář – načíst vlastnosti, změnit některou hodnotu a aktualizovat dokument – lze implementovat následujícím způsobem:

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

Existuje další způsob, jak použít vlastnosti konkrétní prezentace jako šablonu pro aktualizaci vlastností v dalších prezentacích:

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

Novou šablonu lze vytvořit od začátku a poté použít k aktualizaci více prezentací:

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

## **Nastavení jazykové kontroly**

Aspose.Slides poskytuje vlastnost LanguageId (zpřístupněnou třídou PortionFormat), která umožňuje nastavit jazyk korektury pro dokument PowerPoint. Jazyk korektury je jazyk, pro který jsou v PowerPointu kontrolovány pravopis a gramatika.

Tento Java kód ukazuje, jak nastavit jazyk korektury pro PowerPoint:

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

    portionFormat.setLanguageId("zh-CN"); // nastavte Id jazykové korektury

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

## **Ukázkový příklad**

Vyzkoušejte online aplikaci [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata) pro zobrazení, jak pracovat s vlastnostmi dokumentu pomocí Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## ***Často kladené dotazy**

### Jak mohu odstranit vestavěnou vlastnost z prezentace?

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdný řetězec, pokud to konkrétní vlastnost umožňuje.

### Co se stane, když přidám vlastní vlastnost, která již existuje?

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost předem odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

### Mohu získat přístup k vlastnostem prezentace bez úplného načtení prezentace?

Ano, můžete přistupovat k vlastnostem prezentace bez úplného načtení prezentace pomocí metody `getPresentationInfo` ze třídy [PresentationFactory](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationfactory/) . Poté využijte metodu `readDocumentProperties` poskytovanou rozhraním [IPresentationInfo](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationinfo/) , abyste vlastnosti načetli efektivně, ušetřili paměť a zlepšili výkon.