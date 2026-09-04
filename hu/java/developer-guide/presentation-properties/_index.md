---
title: Prezentáció tulajdonságainak kezelése Java-ban
linktitle: Prezentáció tulajdonságai
type: docs
weight: 70
url: /hu/java/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságok
- dokumentumtulajdonságok
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
description: "Kezelje a prezentáció tulajdonságait az Aspose.Slides for Java segítségével, és optimalizálja a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides kétféle dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípus könnyen elérhető és kezelhető az Aspose.Slides API segítségével.

Az Aspose.Slides lehetővé teszi a prezentáció dokumentumtulajdonságokkal való munkát a [IDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties/) felületen keresztül. Ennek a felületnek egy példányát a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getDocumentProperties--) adja vissza. Az alábbi példák bemutatják, hogyan olvashatók, módosíthatók és kezelhetők ezek a tulajdonságok.

{{% alert color="info" title="Note" %}}
Kérjük, vegye figyelembe, hogy az **Application** és **AppVersion** mezőket nem lehet módosítani. Az Aspose.Slides minden mentéskor felülírja ezeket, ezért egy mentett prezentáció mindig azt a jelentést adja, hogy „Aspose.Slides for Java” és a könyvtár verziója, amely előállította. A `setNameOfApplication`‑nek átadott értéket a prezentáció írása során eldobja.
{{% /alert %}}

## **Dokumentumtulajdonságok a PowerPointban**

A Microsoft PowerPoint 2007 lehetővé teszi a prezentáció fájlok dokumentumtulajdonságainak kezelését. Csak kattintson az Office ikonra, majd a **Prepare | Properties | Advanced Properties** menüpontokra, ahogy az alább látható:

|**Az Speciális tulajdonságok menüpont kiválasztása**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

A **Advanced Properties** menüpont kiválasztása után egy párbeszédablak jelenik meg, amely lehetővé teszi a PowerPoint fájl dokumentumtulajdonságainak kezelését, az alábbi ábrán látható módon:

|**Tulajdonságok párbeszédablak**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

A fenti **Tulajdonságok** párbeszédablakban számos lapot láthat, például **General**, **Summary**, **Statistics**, **Contents** és **Custom**. Ezek a lapok különböző információk konfigurálását teszik lehetővé a PowerPoint fájlokkal kapcsolatban. A **Custom** lapot a PowerPoint fájlok egyéni tulajdonságainak kezelésére használják.

### Dokumentumtulajdonságok kezelése az Aspose.Slides for Java használatával

Ahogy korábban leírtuk, az Aspose.Slides for Java kétféle dokumentumtulajdonságot támogat: **Beépített** és **Egyéni** tulajdonságokat. Így a fejlesztők mindkét típust elérhetik az Aspose.Slides for Java API‑val. Az Aspose.Slides for Java egy [IDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties) osztályt biztosít, amely a **Presentation.DocumentProperties** tulajdonságon keresztül reprezentálja egy prezentáció fájlhoz kapcsolódó dokumentumtulajdonságokat.

A fejlesztők a **IDocumentProperties** tulajdonságot a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) objektumon keresztül használhatják a prezentációs fájlok dokumentumtulajdonságainak eléréséhez, ahogyan az alább le van írva:

## **Nyilvános tulajdonságok olvasása titkosított prezentációból**

A megnyitási jelszó általában a prezentáció tartalmát és a dokumentumtulajdonságokat egyaránt védi. Ha egy prezentációt úgy titkosítanak, hogy a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) paramétere `false`, a dokumentumtulajdonságok nyilvánosak maradnak. Ezután az alkalmazás a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-)‑t `true`‑ra állítva olvashatja a nyilvános metaadatokat anélkül, hogy megadná a megnyitási jelszót.

A csak dokumentumtulajdonságok betöltését szabályozó beállítás azt határozza meg, hogy az Aspose.Slides mit tölt be; semmit nem fejti vissza. Ha a tulajdonságok titkosítási folyamatba kerültek, jelszó nélkül a betöltés sikertelen. Ha a prezentáció nincs titkosítva, a beállítás figyelmen kívül marad, és a teljes prezentáció betöltődik.

Az alábbi példa a [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) segítségével ellenőrzi a betöltési módot, majd a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getDocumentProperties--) segítségével beolvassa a beépített tulajdonságokat:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Ebben a módban a dia tartalma nem töltődik be. A diák, mesterek, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) állapotot, mielőtt olyan műveletet végeznének, amely a teljes prezentációs objektummodellhez fér hozzá.

{{% alert color="warning" title="Warning" %}}
A nyilvános metaadatok felfedhetik a szerzők nevét, címeit, tárgyát, kulcsszavait, vállalati információkat, megjegyzéseket és egyéni értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Csak akkor hagyja nyilvánosan, ha indexelés, osztályozás, keresés vagy dokumentumkezelő rendszereknek kifejezett igénye van a jelszó nélküli hozzáférésre.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a csak dokumentumtulajdonságok módjában betöltött prezentáció a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja elmenteni a módosított tulajdonságokat ebből a metaadat‑csak objektumból, mert a nyilvános tulajdonságoknak meg kell egyezniük a titkosított prezentációban lévő adatokkal. Frissítésükhöz ezért szükség van a helyes megnyitási jelszóra és a teljes betöltésre.

Az alábbi példa a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)‑vel nyitja meg a prezentációt, frissíti a nyilvános beépített tulajdonságokat, és elmenti az eredményt. Ezután a [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#isEncrypted--)‑t használja annak ellenőrzésére, hogy a titkosítás megmaradt‑e, és jelszó nélkül újra beolvassa a nyilvános metaadatokat a új értékek ellenőrzéséhez:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Ha egy alkalmazás nem kap engedélyt a prezentáció tartalmának visszafejtésére vagy betöltésére, a titkosított PPTX fájl nyilvános tulajdonságait csak olvasásra használhatja.

## **Beépített tulajdonságok elérése**

Az [IDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties) objektum által kiadott tulajdonságok a következők: **Creator** (Szerző), **Description** (Leírás), **Keywords** (Kulcsszavak), **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **SharedDoc** (Megosztott dokumentum?), **PresentationFormat**, **Subject** és **Title**.

```java
import com.aspose.slides.*;

// Példányosítja a Presentation osztályt, amely a prezentációt képviseli
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hivatkozás létrehozása a Presentation-hez tartozó IDocumentProperties objektumra
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // A beépített tulajdonságok megjelenítése
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

A beépített tulajdonságok módosítása ugyanolyan egyszerű, mint azok elérése. Egyszerűen egy karakterlánc értéket adhat bármely kívánt tulajdonsághoz, és a tulajdonság értéke módosul. Az alábbi példában bemutatjuk, hogyan módosíthatók a prezentáció fájl beépített dokumentumtulajdonságai az Aspose.Slides for Java használatával.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hivatkozás létrehozása a Presentation-hez tartozó IDocumentProperties objektumra
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // A beépített tulajdonságok beállítása
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

Ez a példa a prezentáció beépített tulajdonságait módosítja, amely az alábbiak szerint jelenik meg:

|**Beépített dokumentumtulajdonságok módosítás után**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Egyéni dokumentumtulajdonságok hozzáadása**

Az Aspose.Slides for Java lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak a prezentáció dokumentumtulajdonságaihoz. Az alábbi példa három egyéni tulajdonságot ad hozzá, majd a 2. indexen tárolt nevet lekérdezi és eltávolítja azt, így a mentett prezentáció csak kettőt tartalmaz. Az egyéni tulajdonságok betűrendben vannak indexelve, nem a felvételi sorrendben.

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
    
    // Tulajdonság nevének lekérése egy adott indexnél
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Kiválasztott tulajdonság eltávolítása
    dProps.removeCustomProperty(getPropertyName);
    
    // Prezentáció mentése
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Hozzáadott egyéni dokumentumtulajdonságok**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Egyéni tulajdonságok elérése és módosítása**

Az Aspose.Slides for Java emellett lehetővé teszi a fejlesztőknek, hogy hozzáférjenek az egyéni tulajdonságok értékeihez. Az alábbi példa megmutatja, hogyan érheti el és módosíthatja ezeket a tulajdonságokat egy prezentációban.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hivatkozás létrehozása a Presentation-hez tartozó DocumentProperties objektumra
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Egyéni tulajdonságok elérése és módosítása
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Egyéni tulajdonságok neveinek és értékeinek megjelenítése
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Egyéni tulajdonságok értékeinek módosítása
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Prezentáció mentése egy fájlba
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ez a példa a [PPTX](https://docs.fileformat.com/presentation/pptx/) prezentáció egyéni tulajdonságait módosítja. Az alábbi ábrák a prezentáció egyéni tulajdonságait mutatják módosítás előtt és után:

|**Egyéni tulajdonságok módosítás előtt**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Egyéni tulajdonságok módosítás után**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Speciális dokumentumtulajdonságok**

{{% alert color="info" title="Note" %}}
Új módszerek: [ReadDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), és [WriteBindedPresentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) lettek hozzáadva az [IPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo) interfészhez, az [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) tulajdonság‑setter logikája módosult.
{{% /alert %}}

Az új [ReadDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) és [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) módszerek az [IPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentationInfo) interfészhez lettek hozzáadva. Gyors hozzáférést biztosítanak a dokumentumtulajdonságokhoz, és lehetővé teszik azok módosítását a teljes prezentáció betöltése nélkül.

A tipikus forgatókönyv: betölti a tulajdonságokat, módosít egy értéket, és frissíti a dokumentumot a következő módon:

```java
import com.aspose.slides.*;

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

Egy másik módja annak, hogy egy adott prezentáció tulajdonságait sablonként használja más prezentációk tulajdonságainak frissítésére:

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

## **Helyesírási nyelv beállítása**

Az Aspose.Slides biztosítja a LanguageId tulajdonságot (a PortionFormat osztályon keresztül), amely lehetővé teszi a helyesírási nyelv beállítását egy PowerPoint dokumentumban. A helyesírási nyelv az, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Ez a Java‑kód megmutatja, hogyan állítható be a helyesírási nyelv egy PowerPoint dokumentumban:

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

Ez a Java‑kód megmutatja, hogyan állítható be az alapértelmezett nyelv egy egész PowerPoint prezentációra:

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

Próbálja ki a [**Aspose.Slides Metadata**](https://products.aspose.app/slides/hu/metadata) online alkalmazást, hogy lássa, hogyan lehet a dokumentumtulajdonságokkal dolgozni az Aspose.Slides API‑n keresztül:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## **FAQ**

**Hogyan lehet egy beépített tulajdonságot eltávolítani a prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és teljesen nem távolíthatók el. Azonban megváltoztathatja az értéküket, vagy üresre állíthatja, ha az adott tulajdonság ezt megengedi.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha már létező egyéni tulajdonságot ad hozzá, a meglévő érték felül lesz írva az újjal. Nem szükséges előzetesen eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti annak értékét.

**Elérhetők a prezentációs tulajdonságok anélkül, hogy a teljes prezentációt betölteném?**

Igen. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)‑t, majd a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)‑t a tárolt dokumentum‑metaadatok olvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/java/examine-presentation/) cikket a teljes jelentési példáért és a formátumspecifikus korlátokért.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból a megnyitási jelszó nélkül?**

Igen. A dokumentumtulajdonság‑titkosítást le kellett tiltani a prezentáció titkosítása előtt, és a prezentációt csak dokumentumtulajdonság‑csak módban kell betölteni.

**Frissíthetek egy titkosított PPTX fájlt dokumentumtulajdonság‑csak módban?**

Nem. A nyilvános és a titkosított tulajdonság‑adatoknak konzisztensnek kell maradniuk, ezért egy titkosított PPTX fájl frissítése a helyes megnyitási jelszóval és a teljes betöltéssel lehetséges.