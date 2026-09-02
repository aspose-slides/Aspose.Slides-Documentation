---
title: Prezentációs tulajdonságok kezelése Androidon
linktitle: Prezentációs tulajdonságok
type: docs
weight: 70
url: /hu/androidjava/presentation-properties/
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
- Android
- Java
- Aspose.Slides
description: "Kezelje a prezentációs tulajdonságokat az Aspose.Slides for Android via Java segítségével, és egyszerűsítse a keresést, a márkajelzést és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípus könnyen elérhető és kezelhető az Aspose.Slides API segítségével.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentumtulajdonságokkal a [IDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/) felületen keresztül dolgozzon. Ennek a felületnek egy példányát a [Presentation.getDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) metódus adja vissza. Az alábbi példák bemutatják, hogyan olvashatók, módosíthatók és kezelhetők ezek a tulajdonságok.

{{% alert color="info" title="Megjegyzés" %}}
Felhívjuk a figyelmet, hogy a **Application** és **AppVersion** mezőket nem lehet módosítani. Az Aspose.Slides minden mentéskor felülírja ezeket, ezért egy mentett prezentáció mindig az Aspose.Slides termék nevét és a létrehozó könyvtár verzióját jelzi. A `setNameOfApplication`-nek átadott bármely érték elvetésre kerül a prezentáció írásakor.
{{% /alert %}} 

## **Dokumentumtulajdonságok a PowerPointban**

A Microsoft PowerPoint 2007 lehetővé teszi a prezentáció fájlok dokumentumtulajdonságainak kezelését. Csak kattintson az Office ikonra, majd a **Prepare | Properties | Advanced Properties** menüpontra, ahogy az alább látható:

|**Az Advanced Properties menüpont kiválasztása**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)||

Az **Advanced Properties** menüpont kiválasztása után megjelenik egy párbeszédablak, amely lehetővé teszi a PowerPoint fájl dokumentumtulajdonságainak kezelését, az alábbi ábrán látható módon:

|**Tulajdonságok párbeszédablak**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)||

A fenti **Properties Dialog** ablakban látható, hogy számos lapfül van, például **General**, **Summary**, **Statistics**, **Contents** és **Custom**. Ezek a lapfülek lehetővé teszik a PowerPoint fájlokkal kapcsolatos különféle információk beállítását. A **Custom** lap a PowerPoint fájlok egyéni tulajdonságainak kezelésére szolgál.

Dokumentumtulajdonságok kezelése az Aspose.Slides for Android via Java használatával

Amint korábban leírtuk, az Aspose.Slides for Android via Java kétféle dokumentumtulajdonságot támogat, amelyek a **Built-in** és **Custom** tulajdonságok. Így a fejlesztők mindkét típusú tulajdonsághoz hozzáférhetnek az Aspose.Slides for Android via Java API használatával. Az Aspose.Slides for Android via Java egy [IDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties) osztályt biztosít, amely a prezentáció fájlhoz kapcsolódó dokumentumtulajdonságokat képviseli a **Presentation.DocumentProperties** tulajdonságon keresztül.

A fejlesztők a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) objektum által biztosított **IDocumentProperties** tulajdonságot használhatják a prezentáció fájlok dokumentumtulajdonságainak eléréséhez, az alábbiakban leírt módon:

## **Beépített tulajdonságok elérése**

Az [IDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties) objektum által elérhető tulajdonságok közé tartozik: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **Keywords**, **SharedDoc** (Közös több gyártó között?), **PresentationFormat**, **Subject** és **Title**

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely a prezentációt képviseli
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

A prezentáció fájlok beépített tulajdonságainak módosítása ugyanolyan egyszerű, mint azok elérése. Egyszerűen egy karakterlánc értéket adhat meg a kívánt tulajdonságnak, és az érték módosul. Az alábbi példában bemutattuk, hogyan módosíthatjuk a beépített dokumentumtulajdonságokat az Aspose.Slides for Android via Java használatával.

```java
import com.aspose.slides.*;

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

Ez a példa módosítja a prezentáció beépített tulajdonságait, melyek az alább láthatók:

|**Beépített dokumentumtulajdonságok módosítás után**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)||

## **Egyéni dokumentumtulajdonságok hozzáadása**

Az Aspose.Slides for Android via Java lehetővé teszi a fejlesztők számára egyéni értékek hozzáadását a prezentáció dokumentumtulajdonságaihoz. Az alábbi példa három egyéni tulajdonságot ad hozzá, majd a 2. indexen tárolt nevet keresi meg és eltávolítja azt, így a mentett prezentációban kettő marad. Az egyéni tulajdonságok betűrendben vannak indexelve, nem a hozzáadás sorrendje szerint.

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

|**Egyéni dokumentumtulajdonságok hozzáadva**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)||

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides for Android via Java lehetővé teszi a fejlesztők számára az egyéni tulajdonságok értékeinek elérését is. Az alábbi példa bemutatja, hogyan érheti el és módosíthatja ezeket az egyéni tulajdonságokat egy prezentációban.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hozzon létre egy hivatkozást a Presentation-hez társított DocumentProperties objektumra
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Egyéni tulajdonságok hozzáférése és módosítása
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

Ez a példa módosítja a [PPTX](https://docs.fileformat.com/presentation/pptx/) prezentáció egyéni tulajdonságait. Az alábbi ábrák a módosítás előtti és utáni egyéni tulajdonságokat mutatják:

|**Egyéni tulajdonságok módosítás előtt**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)||

|**Egyéni tulajdonságok módosítás után**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)||

## **Speciális dokumentumtulajdonságok**

{{% alert color="info" title="Megjegyzés" %}}
Új módszerek, a [ReadDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), a [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), és a [WriteBindedPresentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) lettek hozzáadva az [IPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo) felülethez, a [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) tulajdonság beállítójának logikája megváltozott.
{{% /alert %}}

Az újonnan bevezetett [ReadDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) és [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) metódusok az [IPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo) felülethez lettek hozzáadva. Ezek gyors hozzáférést biztosítanak a dokumentumtulajdonságokhoz, és lehetővé teszik azok módosítását és frissítését anélkül, hogy a teljes prezentációt betöltenénk.

A tipikus forgatókönyv, ahol betöltjük a tulajdonságokat, módosítunk egy értéket, majd frissítjük a dokumentumot, az alábbi módon valósítható meg:

```java
import com.aspose.slides.*;

// Olvassa be a prezentáció információit
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// Lekéri a jelenlegi tulajdonságokat
IDocumentProperties props = info.readDocumentProperties();

// állítsa be az Author és Title mezők új értékeit
props.setAuthor("New Author");
props.setTitle("New Title");

// Frissítse a prezentációt új értékekkel
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Létezik egy másik mód is, ahol egy adott prezentáció tulajdonságait sablonként használjuk a többi prezentáció tulajdonságainak frissítésére:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Helyesírás-ellenőrzési nyelv beállítása**

Az Aspose.Slides a LanguageId tulajdonságot (a PortionFormat osztály által biztosított) kínálja, amely lehetővé teszi a PowerPoint dokumentum helyesírás-ellenőrzési nyelvének beállítását. A helyesírás-ellenőrzési nyelv az a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Ez a Java kód megmutatja, hogyan állítható be a helyesírás-ellenőrzési nyelv egy PowerPointhoz:

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

    portionFormat.setLanguageId("zh-CN"); // állítsa be a helyesírás-ellenőrzési nyelv azonosítóját

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Ez a Java kód bemutatja, hogyan állítható be az alapértelmezett nyelv egy teljes PowerPoint prezentációhoz:

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

Próbálja ki az [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API-n keresztül:

[![PowerPoint metaadatok megtekintése és szerkesztése](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban módosíthatja értéküket vagy üresre állíthatja őket, ha az adott tulajdonság megengedi.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő érték felülíródik az újjal. Nem szükséges előzetesen eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**El tudom-e érni a prezentáció tulajdonságait anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) metódust, majd a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) segítségével olvassa el a tárolt dokumentum metaadatokat anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt hozna létre. Tekintse meg a [Könnyű prezentációs leltár felépítése](/slides/hu/androidjava/examine-presentation/) cikket egy teljes jelentési példáért és a formátumspecifikus korlátozásokért.