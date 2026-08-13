---
title: Bemutató tulajdonságok kezelése Androidon
linktitle: Bemutató tulajdonságok
type: docs
weight: 70
url: /hu/androidjava/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- bemutató tulajdonságok
- dokumentumtulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- speciális tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- javítási nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Kezelje a bemutató tulajdonságokat az Aspose.Slides for Android via Java segítségével, és egyszerűsítse a keresést, a márkaépítést és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides kétféle dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét típusú tulajdonsághoz egyszerűen hozzá lehet férni és kezelni lehet őket az Aspose.Slides API segítségével.

Az Aspose.Slides lehetővé teszi, hogy a bemutató dokumentumtulajdonságokkal az [IDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/) interfészen keresztül dolgozzon. Ennek az interfésznek egy példányát a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) metódus adja vissza. A következő példák bemutatják, hogyan lehet olvasni, módosítani és kezelni ezeket a tulajdonságokat.

{{% alert color="info" %}} 
Kérjük, vegye figyelembe, hogy a **Application** és **AppVersion** mezők nem módosíthatók. Az Aspose.Slides minden mentéskor felülírja ezeket, ezért egy mentett bemutató mindig az Aspose.Slides termék nevét és a könyvtár verzióját jelzi, amely létrehozta. A `setNameOfApplication`‑nek átadott érték el lesz vetve, amikor a bemutató kiírásra kerül.
{{% /alert %}} 

## **Dokumentumtulajdonságok a PowerPointban**

A Microsoft PowerPoint 2007 lehetővé teszi a bemutató fájlok dokumentumtulajdonságainak kezelését. Ehhez csak kattintson az Office ikonra, majd a **Prepare | Properties | Advanced Properties** menüpontra a Microsoft PowerPoint 2007‑ben, ahogy az alább látható.

|**Az Advanced Properties menüelem kiválasztása**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Az **Advanced Properties** menüelem kiválasztása után egy párbeszédablak jelenik meg, amely lehetővé teszi a PowerPoint fájl dokumentumtulajdonságainak kezelését, az alábbi ábrán látható módon:

|**Tulajdonságok párbeszédablak**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Az előző **Tulajdonságok párbeszédablakban** számos lapot láthat, például **General**, **Summary**, **Statistics**, **Contents** és **Custom**. Ezek a lapok különféle, a PowerPoint fájlokkal kapcsolatos információk beállítását teszik lehetővé. A **Custom** lapot a PowerPoint fájlok egyéni tulajdonságainak kezelésére használják.

## **Dokumentumtulajdonságok kezelése az Aspose.Slides for Android via Java használatával**

Ahogy korábban leírtuk, az Aspose.Slides for Android via Java kétféle dokumentumtulajdonságot támogat: **Beépített** és **Egyéni** tulajdonságokat. Így a fejlesztők mindkét típusú tulajdonsághoz hozzáférhetnek az Aspose.Slides for Android via Java API használatával. Az Aspose.Slides for Android via Java egy [IDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties) osztályt biztosít, amely a bemutató fájllal kapcsolatos dokumentumtulajdonságokat képviseli a **Presentation.DocumentProperties** tulajdonságon keresztül.

A fejlesztők a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) objektum által biztosított **IDocumentProperties** tulajdonságot használhatják a bemutató fájlok dokumentumtulajdonságainak eléréséhez, ahogyan azt alább bemutatjuk:

## **Beépített tulajdonságok elérése**

Ezek a tulajdonságok, amelyeket az [IDocumentProperties] objektum biztosít, a következők: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Utolsó nyomtatás dátuma), **LastModifiedBy**, **SharedDoc** (Megosztott-e különböző készítők között?), **PresentationFormat**, **Subject** és **Title**.

```java
import com.aspose.slides.*;

// Példányosítja a Presentation osztályt, amely a bemutatót képviseli
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Létrehoz egy hivatkozást a Presentation-hez kapcsolódó IDocumentProperties objektumra
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Kiírja a beépített tulajdonságokat
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

A bemutató fájlok beépített tulajdonságainak módosítása ugyanolyan egyszerű, mint azok elérése. Egyszerűen hozzárendelhet egy karakterlánc értéket a kívánt tulajdonsághoz, és a tulajdonság értéke módosul. Az alább bemutatott példában azt mutatjuk be, hogyan módosítható a bemutató fájl beépített dokumentumtulajdonságai az Aspose.Slides for Android via Java segítségével.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Létrehoz egy hivatkozást a Presentation-hez kapcsolódó IDocumentProperties objektumra
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Beállítja a beépített tulajdonságokat
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Mentse a bemutatót egy fájlba
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ez a példa módosítja a bemutató beépített tulajdonságait, amely az alább látható:

|**Beépített dokumentumtulajdonságok módosítás után**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Egyéni dokumentumtulajdonságok hozzáadása**

Az Aspose.Slides for Android via Java lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak a bemutató dokumentumtulajdonságaihoz. Az alábbi példa három egyéni tulajdonságot ad hozzá, majd a 2. indexen tárolt nevet keresi meg és eltávolítja azt, így a mentett bemutató csak két tulajdonságot tartalmaz. Az egyéni tulajdonságok betűrendben vannak indexelve, nem a hozzáadás sorrendjében.

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
    
    // Tulajdonság nevének lekérése adott indexen
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Kiválasztott tulajdonság eltávolítása
    dProps.removeCustomProperty(getPropertyName);
    
    // Bemutató mentése
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Hozzáadott egyéni dokumentumtulajdonságok**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides for Android via Java lehetővé teszi a fejlesztők számára az egyéni tulajdonságok értékeinek elérését is. Az alábbi példa azt mutatja, hogyan érhetők el és módosíthatók ezek az egyéni tulajdonságok egy bemutatóban.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Létrehoz egy hivatkozást a Presentation-hez kapcsolódó DocumentProperties objektumra
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Egyéni tulajdonságok elérése és módosítása
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Az egyéni tulajdonságok neveinek és értékeinek megjelenítése
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Az egyéni tulajdonságok értékeinek módosítása
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Mentse a bemutatót egy fájlba
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ez a példa módosítja a [PPTX](https://docs.fileformat.com/presentation/pptx/) bemutató egyéni tulajdonságait. Az alábbi ábrák a bemutató egyéni tulajdonságait mutatják módosítás előtt és után:

|**Egyéni tulajdonságok módosítás előtt**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Egyéni tulajdonságok módosítás után**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Speciális dokumentumtulajdonságok**

{{% alert color="info" %}} 
Új módszerek, a [ReadDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), a [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), és a [WriteBindedPresentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) került hozzáadásra a [IPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo) interfészhez, a [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) tulajdonságbeállító logikája módosult.
{{% /alert %}} 

A két új [ReadDocumentProperties] és [UpdateDocumentProperties] módszert hozzáadták a [IPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo) interfészhez. Ezek gyors hozzáférést biztosítanak a dokumentumtulajdonságokhoz, és lehetővé teszik azok módosítását és frissítését anélkül, hogy az egész bemutatót betöltenénk.

A tipikus forgatókönyv, amelyben betöltjük a tulajdonságokat, módosítunk egy értéket, majd frissítjük a dokumentumot, a következőképp valósítható meg:

```java
import com.aspose.slides.*;

// olvassa be a bemutató információit
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// szerezze meg a jelenlegi tulajdonságokat
IDocumentProperties props = info.readDocumentProperties();

// állítsa be a Szerző és Cím mezők új értékeit
props.setAuthor("New Author");
props.setTitle("New Title");

// frissítse a bemutatót új értékekkel
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Létezik egy másik mód is, amely egy adott bemutató tulajdonságait sablonként használja a többi bemutató tulajdonságainak frissítésére:

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

Egy új sablon létrehozható a semmiből, és azt felhasználhatjuk több bemutató frissítésére:

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

## **Javítási nyelv beállítása**

Az Aspose.Slides a LanguageId tulajdonságot (a PortionFormat osztály által elérhető) biztosítja, amely lehetővé teszi a PowerPoint dokumentum javítási nyelvének beállítását. A javítási nyelv az a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Ez a Java kód megmutatja, hogyan állítható be a javítási nyelv egy PowerPoint esetén:

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

    portionFormat.setLanguageId("zh-CN"); // állítsa be a javítási nyelv azonosítóját

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Ez a Java kód azt mutatja meg, hogyan állítható be az alapértelmezett nyelv egy teljes PowerPoint bemutatóhoz:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Új téglalap alakzatot ad hozzá szöveggel
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Ellenőrzi az első rész nyelvét
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Élő példa**

Próbálja ki az [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan lehet a dokumentumtulajdonságokkal dolgozni az Aspose.Slides API-n keresztül:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## ***GYIK**

### Hogyan távolítható el egy beépített tulajdonság egy bemutatóból?

A beépített tulajdonságok a bemutató szerves részét képezik, és nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket, vagy (ha a konkrét tulajdonság engedi) üresnek állíthatja őket.

### Mi történik, ha egy már létező egyéni tulajdonságot adok hozzá?

Ha egy már létező egyéni tulajdonságot ad hozzá, annak meglévő értéke felül lesz írva az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

### Elérhetem a bemutató tulajdonságait anélkül, hogy teljesen betölteném a bemutatót?

Igen, a bemutató tulajdonságait a teljes bemutató betöltése nélkül is elérheti a [PresentationFactory](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationfactory/) osztály `getPresentationInfo` metódusának használatával. Ezután a [IPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/) interfész `readDocumentProperties` metódusát használva hatékonyan olvashatja a tulajdonságokat, ezzel memóriát takarítva meg és javítva a teljesítményt.