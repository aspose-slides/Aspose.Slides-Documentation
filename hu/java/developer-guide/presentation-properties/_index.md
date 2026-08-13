---
title: Manage Presentation Properties in Java
linktitle: Presentation Properties
type: docs
weight: 70
url: /hu/java/presentation-properties/
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
- Java
- Aspose.Slides
description: "Mesteri módon kezelje a prezentáció tulajdonságokat az Aspose.Slides for Java-ban, és egyszerűsítse a keresést, a márkaépítést és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentum tulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípust egyszerűen el lehet érni és kezelni az Aspose.Slides API segítségével.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentum tulajdonságaival a [IDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/) interfészen keresztül dolgozzon. Ennek az interfésznek egy példányát a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getDocumentProperties--) metódus adja vissza. A következő példák bemutatják, hogyan lehet olvasni, módosítani és kezelni ezeket a tulajdonságokat.

{{% alert color="info" %}} 
Felhívjuk a figyelmet, hogy a **Application** és **AppVersion** mezők nem módosíthatók. Az Aspose.Slides minden mentéskor felülírja ezeket, így egy mentett prezentáció mindig a “Aspose.Slides for Java” értéket és a azt előállító könyvtár verzióját jelzi. A `setNameOfApplication`‑nek átadott bármely értéket eldobja a prezentáció írásakor.
{{% /alert %}} 

## **Dokumentum tulajdonságok a PowerPointban**

Az Microsoft PowerPoint 2007 lehetővé teszi a prezentáció fájlok dokumentumtulajdonságainak kezelését. Csak kattintson az Office ikonra, majd válassza a **Prepare | Properties | Advanced Properties** menüpontot a Microsoft PowerPoint 2007-ben, ahogyan az alábbiakban látható:

|**Advanced Properties menüpont kiválasztása**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Az **Advanced Properties** menüpont kiválasztása után egy párbeszédablak jelenik meg, amely lehetővé teszi a PowerPoint fájl dokumentumtulajdonságainak kezelését, az alábbi ábrán látható módon:

|**Tulajdonságok párbeszédablak**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

A fenti **Properties Dialog**-ban látható, hogy számos lapfül létezik, például **General**, **Summary**, **Statistics**, **Contents** és **Custom**. Ezek a lapfülek különféle, a PowerPoint fájlokra vonatkozó információk konfigurálását teszik lehetővé. A **Custom** lap a PowerPoint fájlok egyéni tulajdonságainak kezelésére szolgál.

## **Dokumentum tulajdonságok kezelése az Aspose.Slides for Java segítségével**

Amint korábban leírtuk, az Aspose.Slides for Java kétféle dokumentumtulajdonságot támogat: **Beépített** és **Egyéni** tulajdonságokat. Így a fejlesztők mindkét típusú tulajdonsághoz hozzáférhetnek az Aspose.Slides for Java API használatával. Az Aspose.Slides for Java egy [IDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties) osztályt biztosít, amely a **Presentation.DocumentProperties** tulajdonságon keresztül képviseli a prezentáció fájlhoz kapcsolódó dokumentumtulajdonságokat.

A fejlesztők a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) objektum által nyújtott **IDocumentProperties** tulajdonság segítségével érhetik el a prezentáció fájlok dokumentumtulajdonságait, amint az alább le van írva:

## **Beépített tulajdonságok elérése**

Az [IDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties) objektum által elérhető tulajdonságok a következők: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Utolsó nyomtatás dátuma), **LastModifiedBy**, **SharedDoc** (Megosztott különböző producerek között?), **PresentationFormat**, **Subject** és **Title**

```java
import com.aspose.slides.*;

// Példányosítsa a bemutatót képviselő Presentation osztályt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a Presentation-hez társított IDocumentProperties objektumra
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

A prezentáció fájlok beépített tulajdonságainak módosítása ugyanolyan egyszerű, mint azok elérése. Egyszerűen egy karakterlánc értéket rendelhet bármely kívánt tulajdonsághoz, és a tulajdonság értéke módosul. Az alábbi példában bemutattuk, hogyan módosíthatók a prezentáció fájl beépített dokumentumtulajdonságai az Aspose.Slides for Java használatával.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a Presentation-hez társított IDocumentProperties objektumra
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Állítsa be a beépített tulajdonságokat
    dp.setAuthor("Aspose.Slides for Java");
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

Ez a példa módosítja a prezentáció beépített tulajdonságait, amelyek az alábbiakban láthatók:

|**Beépített dokumentumtulajdonságok módosítás után**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Egyéni dokumentumtulajdonságok hozzáadása**

Az Aspose.Slides for Java lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak a prezentáció dokumentumtulajdonságaihoz is. Az alábbi példa három egyéni tulajdonságot ad hozzá, majd a 2. indexen tárolt nevet lekérdezi és eltávolítja azt, így a mentett prezentáció csak kettőt tartalmaz. Az egyéni tulajdonságok betűrendben vannak indexelve, nem az hozzáadás sorrendjében.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Dokumentum tulajdonságok lekérése
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Egyéni tulajdonságok hozzáadása
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Tulajdonság neve lekérése adott indexen
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Kiválasztott tulajdonság eltávolítása
    dProps.removeCustomProperty(getPropertyName);
    
    // Prezentáció mentése
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Hozzáadott egyéni dokumentumtulajdonságok**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides for Java lehetővé teszi a fejlesztők számára az egyéni tulajdonságok értékeinek elérését is. Az alábbi példa bemutatja, hogyan érhetők el és módosíthatók ezek az egyéni tulajdonságok egy prezentációban.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a Presentation-hez társított DocumentProperties objektumra
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Egyéni tulajdonságok elérése és módosítása
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Egyéni tulajdonságok neveinek és értékeinek megjelenítése
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

|**Egyéni tulajdonságok módosítás előtt**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Egyéni tulajdonságok módosítás után**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Speciális dokumentumtulajdonságok**

{{% alert color="info" %}} 
Új módszerek [ReadDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), és [WriteBindedPresentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) lettek hozzáadva a [IPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo) interfészhez, a [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) tulajdonság beállítójának logikája megváltozott.
{{% /alert %}} 

A két új módszer, a [ReadDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) és a [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), hozzá lett adva a [IPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo) interfészhez. Ezek gyors hozzáférést biztosítanak a dokumentumtulajdonságokhoz, és lehetővé teszik azok módosítását és frissítését anélkül, hogy teljes prezentációt betöltenénk.

A tipikus forgatókönyv, ahol betöltjük a tulajdonságokat, módosítunk egy értéket, majd frissítjük a dokumentumot, a következő módon valósítható meg:

```java
import com.aspose.slides.*;

// olvassa be a prezentáció információit
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

Van egy másik mód is, ahol egy adott prezentáció tulajdonságait sablonként használva frissíthetők más prezentációk tulajdonságai:

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

Egy új sablon létrehozható a semmiből, majd több prezentáció frissítésére is használható:

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

## **Helyesírási nyelv beállítása**

Az Aspose.Slides a LanguageId (a PortionFormat osztály által biztosított) tulajdonságot biztosítja, amely lehetővé teszi a PowerPoint dokumentum helyesírási nyelvének beállítását. A helyesírási nyelv az a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Ez a Java kód megmutatja, hogyan állítható be a PowerPoint helyesírási nyelve:

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

    portionFormat.setLanguageId("zh-CN"); // állítsa be a helyesírási nyelv azonosítóját

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Ez a Java kód megmutatja, hogyan állítható be az alapértelmezett nyelv egy teljes PowerPoint prezentációhoz:

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

Próbálja ki a [**Aspose.Slides Metaadatok**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API-n keresztül:

[![PowerPoint metaadatok megtekintése és szerkesztése](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## ***GYIK**

### Hogyan távolíthatok el egy beépített tulajdonságot a prezentációból?

Beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban módosíthatja az értéküket, vagy ha a konkrét tulajdonság megengedi, üresre állíthatja őket.

### Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő értéke felülíródik az újjal. Nem szükséges előzetesen eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

### Hozzáférhetek a prezentáció tulajdonságaihoz a teljes prezentáció betöltése nélkül?

Igen, a prezentáció tulajdonságaihoz hozzá lehet férni a teljes prezentáció betöltése nélkül a [PresentationFactory](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/) osztály `getPresentationInfo` metódusának használatával. Ezután a [IPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/) interfész által biztosított `readDocumentProperties` metódust használva hatékonyan olvashatók a tulajdonságok, így memória takarítható meg és a teljesítmény javítható.