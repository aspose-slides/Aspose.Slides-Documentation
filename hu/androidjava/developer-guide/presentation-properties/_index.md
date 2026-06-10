---
title: Prezentáció tulajdonságok kezelése Androidon
linktitle: Prezentáció tulajdonságok
type: docs
weight: 70
url: /hu/androidjava/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságok
- dokumentum tulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- speciális tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- helyesírási nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Mesteri prezentáció tulajdonságok az Aspose.Slides for Android via Java-ban, és egyszerűsítse a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípust egyszerűen elérheti és kezelheti az Aspose.Slides API segítségével.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentumtulajdonságaival a [IDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/) felületen keresztül dolgozzon. Ennek a felületnek egy példányát a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) metódus adja vissza. A következő példák bemutatják, hogyan olvashatók, módosíthatók és kezelhetők ezek a tulajdonságok.

{{% alert color="primary" %}} 
Kérjük, vegye figyelembe, hogy a **Application** és **Producer** mezők nem módosíthatók, mivel ezek a mezők mindig az "Aspose Ltd." és az "Aspose.Slides for Android via Java x.x.x" értékeket jelenítik meg.
{{% /alert %}} 

## **Dokumentumtulajdonságok a PowerPointban**

A Microsoft PowerPoint 2007 lehetővé teszi a prezentáció fájlok dokumentumtulajdonságainak kezelését. Mindössze annyit kell tennie, hogy rákattint az Office ikonra, majd a **Prepare | Properties | Advanced Properties** menüpontra a Microsoft PowerPoint 2007-ben, ahogyan az alább látható:

|**Az Advanced Properties menüpont kiválasztása**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Miután kiválasztja a **Advanced Properties** menüpontot, megjelenik egy párbeszédablak, amely lehetővé teszi a PowerPoint fájl dokumentumtulajdonságainak kezelését, ahogyan az alábbi ábrán látható:

|**Tulajdonságok párbeszédablak**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Az előző **Tulajdonságok párbeszédablak**-ban látható, hogy számos lapon vannak, mint a **General**, **Summary**, **Statistics**, **Contents** és **Custom**. Ezek a lapok lehetővé teszik a PowerPoint fájlokhoz kapcsolódó különféle információk konfigurálását. A **Custom** lapot a PowerPoint fájlok egyéni tulajdonságainak kezelésére használják.

Dolgozás a dokumentumtulajdonságokkal az Aspose.Slides for Android via Java használatával

Ahogy korábban leírtuk, az Aspose.Slides for Android via Java kétféle dokumentumtulajdonságot támogat, amelyek a **Beépített** és **Egyéni** tulajdonságok. Így a fejlesztők mindkét fajta tulajdonsághoz hozzáférhetnek az Aspose.Slides for Android via Java API használatával. Az Aspose.Slides for Android via Java egy [IDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties) osztályt biztosít, amely a prezentáció fájlhoz tartozó dokumentumtulajdonságokat képviseli a **Presentation.DocumentProperties** tulajdonságon keresztül.

A fejlesztők a **Presentation** objektum által kiérzett **IDocumentProperties** tulajdonságot használhatják a prezentáció fájlok dokumentumtulajdonságainak eléréséhez, ahogyan alább le van írva:

## **Beépített tulajdonságok elérése**

Az [IDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties) objektum által biztosított tulajdonságok a következők: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **SharedDoc** (Megosztott több producer között?), **PresentationFormat**, **Subject** és **Title**

```java
// Példányosítsa a Presentation osztályt, amely a prezentációt képviseli
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a Presentation-hez kapcsolódó IDocumentProperties objektumra
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Jelenítse meg a beépített tulajdonságokat
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

## **Beépített tulajdonságok módosítása**

A prezentáció fájlok beépített tulajdonságainak módosítása ugyanolyan egyszerű, mint azok elérése. Egyszerűen egy karakterlánc értéket rendelhet a kívánt tulajdonsághoz, és a tulajdonság értéke módosulni fog. Az alább bemutatott példában demonstráltuk, hogyan módosíthatjuk a prezentáció fájl beépített dokumentumtulajdonságait az Aspose.Slides for Android via Java használatával.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a Presentation-hez kapcsolódó IDocumentProperties objektumra
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Állítsa be a beépített tulajdonságokat
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Mentse a prezentációt egy fájlba
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ez a példa módosítja a prezentáció beépített tulajdonságait, amely a lenti ábrán látható:

|**Beépített dokumentumtulajdonságok módosítás után**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Egyéni dokumentumtulajdonságok hozzáadása**

Az Aspose.Slides for Android via Java lehetővé teszi a fejlesztők számára egyéni értékek hozzáadását a prezentáció dokumentumtulajdonságaihoz is. Az alábbi példában látható, hogyan állítható be a prezentáció egyéni tulajdonságai.

```java
Presentation pres = new Presentation();
try {
    // Dokumentumtulajdonságok lekérdezése
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Egyéni tulajdonságok hozzáadása
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Tulajdonság nevének lekérése adott indexen
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Kiválasztott tulajdonság eltávolítása
    dProps.removeCustomProperty(getPropertyName);
    
    // Prezentáció mentése
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Egyéni dokumentumtulajdonságok hozzáadva**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides for Android via Java lehetővé teszi a fejlesztők számára az egyéni tulajdonságok értékeinek elérését is. Az alábbi példa bemutatja, hogyan férhet hozzá és módosíthatja ezeket az egyéni tulajdonságokat egy prezentációban.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a Presentation-hez kapcsolódó DocumentProperties objektumra
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Egyéni tulajdonságok elérése és módosítása
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Egyéni tulajdonságok nevének és értékének megjelenítése
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Egyéni tulajdonságok értékének módosítása
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Prezentáció mentése egy fájlba
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ez a példa módosítja a [PPTX ](https://docs.fileformat.com/presentation/pptx/) prezentáció egyéni tulajdonságait. A következő ábrák mutatják a prezentáció egyéni tulajdonságait módosítás előtt és után:

|**Egyéni tulajdonságok módosítás előtt**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Egyéni tulajdonságok módosítás után**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Speciális dokumentumtulajdonságok**

{{% alert color="primary" %}} 
Új módszerek: [ReadDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), és [WriteBindedPresentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) lettek hozzáadva az [IPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo) felülethez, a [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) tulajdonság beállítójának logikája megváltozott.
{{% /alert %}} 

Az újonnan hozzáadott két módszer – a [ReadDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) és a [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) – segít gyors hozzáférést biztosítani a dokumentumtulajdonságokhoz, és lehetővé teszik a tulajdonságok módosítását és frissítését a teljes prezentáció betöltése nélkül.

A tipikus forgatókönyv, amelyben betölti a tulajdonságokat, módosít egy értéket, majd frissíti a dokumentumot, a következőképpen valósítható meg:

```java
// Olvassa be a prezentáció információit
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// Szerezze be a jelenlegi tulajdonságokat
IDocumentProperties props = info.readDocumentProperties();

// Állítsa be az Author és Title mezők új értékeit
props.setAuthor("New Author");
props.setTitle("New Title");

// Frissítse a prezentációt új értékekkel
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Létezik egy másik mód is arra, hogy egy adott prezentáció tulajdonságait sablonként használja más prezentációk tulajdonságainak frissítéséhez:

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

Új sablon hozható létre a semmiből, majd több prezentáció frissítésére használható:

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

## **Helyesírási nyelv beállítása**

Az Aspose.Slides a LanguageId tulajdonságot (amely a PortionFormat osztályon keresztül érhető el) biztosítja, hogy beállíthassa a helyesírási nyelvet egy PowerPoint dokumentumhoz. A helyesírási nyelv az a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Ez a Java kód megmutatja, hogyan kell beállítani a helyesírási nyelvet egy PowerPointban: xxx Why is LanguageId missing from Java PortionFormat class?

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

    portionFormat.setLanguageId("zh-CN"); // a helyesírási nyelv azonosítójának beállítása

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Ez a Java kód megmutatja, hogyan kell beállítani az alapértelmezett nyelvet egy teljes PowerPoint prezentációhoz:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Új téglalap alakzat hozzáadása szöveggel
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Ellenőrzi az első szakasz nyelvét
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Élő példa**

Próbálja ki a [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API-n keresztül:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## ***GYIK**

**Hogyan tudok egy beépített tulajdonságot eltávolítani egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, ezért nem lehet őket teljesen eltávolítani. Azonban megváltoztathatja az értéküket, vagy ha az adott tulajdonság engedi, üresre állíthatja őket.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő értéke felül lesz írva az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Elérhetem a prezentáció tulajdonságait anélkül, hogy teljesen betölteném a prezentációt?**

Igen, a prezentáció tulajdonságait a prezentáció teljes betöltése nélkül is elérheti a `getPresentationInfo` metódus használatával a [PresentationFactory](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationfactory/) osztályból. Ezután használja a [IPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/) interfész `readDocumentProperties` metódusát a tulajdonságok hatékony kiolvasásához, ami memóriát takarít meg és javítja a teljesítményt.