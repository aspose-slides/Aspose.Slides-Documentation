---
title: Prezentációs tulajdonságok kezelése Java-ban
linktitle: Prezentációs tulajdonságok
type: docs
weight: 70
url: /hu/java/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentációs tulajdonságok
- dokumentumtulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- haladó tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- helyesírás-ellenőrzés nyelve
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Kezelje a prezentációs tulajdonságokat az Aspose.Slides for Java-ban, és egyszerűsítse a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides kétféle dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípus könnyen elérhető és kezelhető az Aspose.Slides API-val.

Az Aspose.Slides lehetővé teszi, hogy a [IDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/) interfészen keresztül dolgozzon a bemutató dokumentumtulajdonságokkal. Az interfész egy példánya a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getDocumentProperties--) metódussal érhető el. Az alábbi példák bemutatják, hogyan olvashatja, módosíthatja és kezelheti ezeket a tulajdonságokat.

{{% alert color="info" title="Note" %}}
Felhívjuk a figyelmet, hogy a **Application** és **AppVersion** mezőket nem lehet módosítani. Az Aspose.Slides minden mentéskor felülírja ezeket, ezért egy mentett bemutató mindig azt jelzi, hogy „Aspose.Slides for Java”, és a könyvtár verzióját, amely azt előállította. A `setNameOfApplication`‑nek átadott értéket a bemutató írása során eldobja.
{{% /alert %}} 

## **Dokumentumtulajdonságok a PowerPointban**

Microsoft PowerPoint 2007 lehetővé teszi a bemutató fájlok dokumentumtulajdonságainak kezelését. Ehhez csak rá kell kattintani az Office ikonra, majd a **Prepare | Properties | Advanced Properties** menüpontot a Microsoft PowerPoint 2007-ben, ahogyan az alább látható:

|**Kiterjesztett tulajdonságok menüpont kiválasztása**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Miután kiválasztja a **Advanced Properties** menüpontot, megjelenik egy párbeszédablak, amely lehetővé teszi a PowerPoint fájl dokumentumtulajdonságainak kezelését, ahogy az alábbi ábrán látható:

|**Tulajdonságok párbeszédablak**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Az előző **Tulajdonságok párbeszédablakban** látható, hogy számos lapon található, például **General**, **Summary**, **Statistics**, **Contents** és **Custom**. Ezek a lapok különböző típusú információk beállítását teszik lehetővé a PowerPoint fájlokhoz kapcsolódóan. A **Custom** lapot a PowerPoint fájlok egyéni tulajdonságainak kezelésére használják.

Dokumentumtulajdonságok kezelése Aspose.Slides for Java használatával

Ahogyan korábban leírtuk, az Aspose.Slides for Java kétféle dokumentumtulajdonságot támogat, a **Beépített** és a **Egyéni** tulajdonságokat. Így a fejlesztők mindkét típusú tulajdonsághoz hozzáférhetnek az Aspose.Slides for Java API használatával. Az Aspose.Slides for Java egy [IDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties) osztályt biztosít, amely egy bemutató fájlhoz társított dokumentumtulajdonságokat reprezentál a **Presentation.DocumentProperties** tulajdonságon keresztül.

A fejlesztők a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) objektum által biztosított **IDocumentProperties** tulajdonságot használhatják a bemutató fájlok dokumentumtulajdonságainak eléréséhez, ahogy alább le van írva:

## **Beépített tulajdonságok elérése**

Ezeket a tulajdonságokat az [IDocumentProperties] objektum biztosítja, többek között: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **SharedDoc** (Megosztott‑e több producer között?), **PresentationFormat**, **Subject** és **Title**.

```java
import com.aspose.slides.*;

// Példányosítja a Presentation osztályt, amely a prezentációt képviseli
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Létrehoz egy hivatkozást a Presentation-hez tartozó IDocumentProperties objektumra
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Megjeleníti a beépített tulajdonságokat
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

A beépített tulajdonságok módosítása a hozzáférésükhöz hasonlóan egyszerű. Egyszerűen hozzárendelhet egy karakterlánc értéket a kívánt tulajdonsághoz, és a tulajdonság értéke módosul. Az alább bemutatott példában azt mutatjuk be, hogyan módosíthatja a prezentáció beépített dokumentumtulajdonságait az Aspose.Slides for Java használatával.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a Presentation-hez tartozó IDocumentProperties objektumra
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Állítsa be a beépített tulajdonságokat
    dp.setAuthor("Aspose.Slides for Java");
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

Ez a példa módosítja a prezentáció beépített tulajdonságait, mely az alábbiak szerint tekinthető meg:

|**Beépített dokumentumtulajdonságok módosítás után**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Egyéni dokumentumtulajdonságok hozzáadása**

Az Aspose.Slides for Java lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak a prezentáció dokumentumtulajdonságaihoz. Az alábbi példa három egyéni tulajdonságot ad hozzá, majd a 2‑es indexen tárolt nevet kikeresi és eltávolítja, így a mentett prezentáció csak kettőt tartalmaz. Az egyéni tulajdonságok betűrendben vannak indexálva, nem a hozzáadás sorrendjében.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Dokumentumtulajdonságok lekérése
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Egyéni tulajdonságok hozzáadása
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Tulajdonság nevének lekérése adott indexnél
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Kiválasztott tulajdonság eltávolítása
    dProps.removeCustomProperty(getPropertyName);
    
    // Prezentáció mentése
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Hozzáadott egyéni dokumentumtulajdonságok**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides for Java lehetővé teszi a fejlesztők számára, hogy elérjék az egyéni tulajdonságok értékeit. Az alább bemutatott példa azt mutatja, hogyan érheti el és módosíthatja ezeket az egyéni tulajdonságokat egy prezentációban.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a Presentation-hez tartozó DocumentProperties objektumra
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Egyéni tulajdonságok elérése és módosítása
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Egyéni tulajdonságok nevének és értékének megjelenítése
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Egyéni tulajdonságok értékeinek módosítása
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Mentse a prezentációt egy fájlba
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ez a példa módosítja a [PPTX](https://docs.fileformat.com/presentation/pptx/) prezentáció egyéni tulajdonságait. Az alábbi ábrák a prezentáció egyéni tulajdonságait mutatják módosítás előtt és után:

|**Egyéni tulajdonságok módosítás előtt**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Egyéni tulajdonságok módosítás után**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Haladó dokumentumtulajdonságok**

{{% alert color="info" title="Note" %}}
Új módszerek lettek hozzáadva: [ReadDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), és [WriteBindedPresentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-). A [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) tulajdonság beállítójának logikája megváltozott.
{{% /alert %}} 

A két új módszer, a [ReadDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) és az [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) a [IPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo) felülethez lett hozzáadva. Gyors hozzáférést biztosítanak a dokumentumtulajdonságokhoz, és lehetővé teszik azok módosítását anélkül, hogy a teljes prezentációt betöltenék.

A tipikus forgatókönyv a tulajdonságok betöltése, egy érték módosítása és a dokumentum frissítése a következő módon valósítható meg:

```java
import com.aspose.slides.*;

// a prezentáció információinak beolvasása
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Létezik egy másik módja is, hogy egy adott prezentáció tulajdonságait sablonként használja fel más prezentációk tulajdonságainak frissítésére:

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

Új sablon hozható létre a semmiből, majd több prezentáció frissítésére használható:

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

## **Helyesírás-ellenőrzés nyelvének beállítása**

Az Aspose.Slides a LanguageId tulajdonságot (amelyet a PortionFormat osztály biztosít) kínálja, hogy beállíthassa a PowerPoint dokumentum helyesírás-ellenőrzés nyelvét. A helyesírás-ellenőrzés nyelve a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

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

    portionFormat.setLanguageId("zh-CN"); // állítsa be a helyesírás-ellenőrzés nyelvének azonosítóját

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Ez a Java kód azt mutatja, hogyan állíthatja be az alapértelmezett nyelvet egy teljes PowerPoint prezentációhoz:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Új téglalap alakzat hozzáadása szöveggel
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Ellenőrzi az első rész nyelvét
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Élő példa**

Próbálja ki az online alkalmazást [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hu/metadata), hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API-n keresztül:

[![PowerPoint metaadatok megtekintése és szerkesztése](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot a bemutatóból?**

A beépített tulajdonságok a bemutató szerves részei, és nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket, vagy ha az adott tulajdonság engedi, beállíthatja őket üresre.

**Mi történik, ha már létező egyéni tulajdonságot adok hozzá?**

Ha már létező egyéni tulajdonságot ad hozzá, annak meglévő értéke felülíródik az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti annak értékét.

**Elérhetem a bemutató tulajdonságait a teljes bemutató betöltése nélkül?**

Igen. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) metódust, majd az [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) hívást a tárolt dokumentum metaadatainak beolvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/java/examine-presentation/) oldalt a teljes jelentési példáért és a formátumspecifikus korlátozásokért.