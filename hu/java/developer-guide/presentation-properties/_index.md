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
- speciális tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- helyesírás-ellenőrzési nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Mestere a prezentációs tulajdonságoknak az Aspose.Slides for Java-ban, és egyszerűsítse a keresést, márkaépítést és munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípus egyszerűen elérhető és kezelhető az Aspose.Slides API használatával.

Az Aspose.Slides lehetővé teszi, hogy a bemutató dokumentumtulajdonságokkal a [IDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/) interfészen keresztül dolgozzon. Ennek az interfésznek egy példánya a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getDocumentProperties--) metódus segítségével érhető el. A következő példák bemutatják, hogyan olvashatók, módosíthatók és kezelhetők ezek a tulajdonságok.

{{% alert color="primary" %}} 
Kérjük vegye figyelembe, hogy a **Application** és **Producer** mezők nem módosíthatók, mivel ezek a mezők mindig az „Aspose Ltd.” és az „Aspose.Slides for Java x.x.x” értékeket jelenítik meg.
{{% /alert %}} 

## **Dokumentumtulajdonságok a PowerPointban**

Az Microsoft PowerPoint 2007 lehetővé teszi a prezentáció fájlok dokumentumtulajdonságainak kezelését. Ehhez csak kattintania kell az Office ikonra, majd a **Prepare | Properties | Advanced Properties** menüpontot a Microsoft PowerPoint 2007-ben, ahogy az alább látható:

|**Az Advanced Properties menüpont kiválasztása**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Az **Advanced Properties** menüpont kiválasztása után egy párbeszédablak jelenik meg, amely lehetővé teszi a PowerPoint fájl dokumentumtulajdonságainak kezelését, az alábbi ábrán látható módon:

|**Tulajdonságok párbeszédablak**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
A fenti **Tulajdonságok párbeszédablakban** látható, hogy több lapfül is található, mint például **General**, **Summary**, **Statistics**, **Contents** és **Custom**. Ezek a lapfülek különféle információk beállítását teszik lehetővé a PowerPoint fájlokkal kapcsolatban. A **Custom** lapot a PowerPoint fájlok egyéni tulajdonságainak kezelésére használják.

## **Dokumentumtulajdonságok kezelése az Aspose.Slides for Java segítségével**

Ahogyan korábban leírtuk, az Aspose.Slides for Java kétféle dokumentumtulajdonságot támogat: **Beépített** és **Egyéni** tulajdonságokat. Így a fejlesztők mindkét típusú tulajdonsághoz hozzáférhetnek az Aspose.Slides for Java API használatával. Az Aspose.Slides for Java egy [IDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties) osztályt biztosít, amely a prezentáció fájlhoz kapcsolódó dokumentumtulajdonságokat képviseli a **Presentation.DocumentProperties** tulajdonság révén.

A fejlesztők a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) objektum által nyújtott **IDocumentProperties** tulajdonságot használva érhetik el a prezentáció fájlok dokumentumtulajdonságait a következő módon:

## **Beépített tulajdonságok elérése**

Az [IDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties) objektum által nyújtott tulajdonságok a következők: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **Keywords**, **SharedDoc** (Közös‑e több producerekkel?), **PresentationFormat**, **Subject** és **Title**.

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

A prezentáció fájlok beépített tulajdonságainak módosítása ugyanolyan egyszerű, mint azok elérése. Egyszerűen hozzárendelhet egy karakterlánc értéket a kívánt tulajdonsághoz, és a tulajdonság értéke módosul. Az alábbi példában bemutatjuk, hogyan módosíthatjuk a beépített dokumentumtulajdonságokat az Aspose.Slides for Java használatával.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a Presentation-hez kapcsolódó IDocumentProperties objektumra
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

Ez a példa módosítja a prezentáció beépített tulajdonságait, amelyek az alább láthatók:

|**Beépített dokumentumtulajdonságok módosítás után**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Egyéni dokumentumtulajdonságok hozzáadása**

Az Aspose.Slides for Java azt is lehetővé teszi, hogy a fejlesztők egyéni értékeket adjanak a prezentáció dokumentumtulajdonságaihoz. Az alábbi példa bemutatja, hogyan állíthatók be az egyéni tulajdonságok egy prezentációhoz.

```java
Presentation pres = new Presentation();
try {
    // Dokumentum tulajdonságok lekérése
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Egyéni tulajdonságok hozzáadása
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Tulajdonságnév lekérése adott indexen
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Kiválasztott tulajdonság eltávolítása
    dProps.removeCustomProperty(getPropertyName);
    
    // Prezentáció mentése
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Egyéni dokumentumtulajdonságok hozzáadva**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides for Java azt is lehetővé teszi, hogy a fejlesztők hozzáférjenek az egyéni tulajdonságok értékeihez. Az alábbi példa bemutatja, hogyan érheti el és módosíthatja ezeket az egyéni tulajdonságokat egy prezentációban.

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
    
        // Egyéni tulajdonságok értékeinek módosítása
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Mentse a prezentációt egy fájlba
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ez a példa módosítja a [PPTX ](https://docs.fileformat.com/presentation/pptx/) prezentáció egyéni tulajdonságait. Az alábbi ábrák a prezentáció egyéni tulajdonságait mutatják módosítás előtt és után:

|**Egyéni tulajdonságok módosítás előtt**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Egyéni tulajdonságok módosítás után**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Speciális dokumentumtulajdonságok**

{{% alert color="primary" %}} 
Új módszerek, a [ReadDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), a [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), és a [WriteBindedPresentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) kerülték hozzáadásra a [IPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo) interfészhez, a [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) tulajdonság beállítójának logikája megváltozott.
{{% /alert %}} 

Az újonnan hozzáadott két módszer, a [ReadDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) és az [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) a [IPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo) interfészhez került. Ezek gyors hozzáférést biztosítanak a dokumentumtulajdonságokhoz, és lehetővé teszik azok módosítását és frissítését anélkül, hogy az egész prezentációt betöltenénk.

A tipikus forgatókönyv, amely során betölti a tulajdonságokat, megváltoztat egy értéket, majd frissíti a dokumentumot, a következő módon valósítható meg:

```java
// a prezentáció információinak olvasása
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// a jelenlegi tulajdonságok lekérése
IDocumentProperties props = info.readDocumentProperties();

// az Author és Title mezők új értékeinek beállítása
props.setAuthor("New Author");
props.setTitle("New Title");

// a prezentáció frissítése új értékekkel
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Létezik egy másik mód is, ahol egy adott prezentáció tulajdonságait sablonként használva frissítheti más prezentációk tulajdonságait:

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

Új sablon hozható létre a semmiből, majd használható több prezentáció frissítésére:

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

## **Helyesírás‑ellenőrzési nyelv beállítása**

Az Aspose.Slides a LanguageId tulajdonságot (a PortionFormat osztály által biztosítva) biztosítja, amely lehetővé teszi a PowerPoint dokumentum helyesírás‑ellenőrzési nyelvének beállítását. A helyesírás‑ellenőrzési nyelv az a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Ez a Java kód bemutatja, hogyan állítható be a PowerPoint helyesírás‑ellenőrzési nyelve: xxx Miért hiányzik a LanguageId a Java PortionFormat osztályból?

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

    portionFormat.setLanguageId("zh-CN"); // a helyesírás-ellenőrzési nyelv azonosítójának beállítása

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Ez a Java kód bemutatja, hogyan állítható be az alapértelmezett nyelv a teljes PowerPoint prezentációhoz:

```java
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

Próbálja ki az [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API segítségével:

[![PowerPoint metaadatok megtekintése és szerkesztése](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## ***GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részét képezik, és nem távolíthatók el teljesen. Azonban megváltoztathatja azok értékét, vagy üresre állíthatja őket, ha az adott tulajdonság ezt megengedi.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő érték felül lesz írva az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Hozzáférhetek a prezentáció tulajdonságaihoz anélkül, hogy teljesen betölteném a prezentációt?**

Igen, a prezentáció tulajdonságaihoz anélkül is hozzáférhet, hogy teljesen betöltené a prezentációt, a [PresentationFactory](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/) osztály `getPresentationInfo` metódusának használatával. Ezután a [IPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/) interfész `readDocumentProperties` metódusát használva hatékonyan olvashatja be a tulajdonságokat, ezzel memóriát takarítva meg és javítva a teljesítményt.