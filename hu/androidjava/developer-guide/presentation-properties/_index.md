---
title: "Prezentáció tulajdonságainak kezelése Androidon"
linktitle: "Prezentáció tulajdonságai"
type: docs
weight: 70
url: /hu/androidjava/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságok
- dokumentumtulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- speciális tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatai
- metaadatok szerkesztése
- ellenőrző nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Kezelje mesteri módon a prezentáció tulajdonságait az Aspose.Slides for Android via Java környezetben, és egyszerűsítse a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides két típusú dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. Mindkét tulajdonságtípust egyszerűen elérheti és kezelheti az Aspose.Slides API-val.

Az Aspose.Slides lehetővé teszi a prezentáció dokumentumtulajdonságokkal való munkát a [IDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties/) interfészen keresztül. Ennek az interfésznek egy példányát a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) adja vissza. A következő példák bemutatják, hogyan olvashatók, módosíthatók és kezelhetők ezek a tulajdonságok.

{{% alert color="info" title="Note" %}}
Kérjük, vegye figyelembe, hogy az **Application** és az **AppVersion** mezőket nem lehet módosítani. Az Aspose.Slides minden mentéskor felülírja ezeket, így egy mentett prezentáció mindig az Aspose.Slides termék nevét és a könyvtár verzióját jelzi, amelyből származik. A `setNameOfApplication`‑nek átadott értéket eldobja a prezentáció írásakor.
{{% /alert %}} 

## **Dokumentumtulajdonságok a PowerPointben**

A Microsoft PowerPoint 2007 lehetővé teszi a prezentáció fájlok dokumentumtulajdonságainak kezelését. Csak kattintson a Office ikonra, majd a **Prepare | Properties | Advanced Properties** menüpontra, ahogy az alább látható:

|**Az Speciális tulajdonságok menüpont kiválasztása**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

A **Speciális tulajdonságok** menüpont kiválasztása után megjelenik egy párbeszédpanel, amely lehetővé teszi a PowerPoint fájl dokumentumtulajdonságainak kezelését, ahogy az alábbi ábra mutatja:

|**Tulajdonságok párbeszédpanel**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Az említett **Tulajdonságok párbeszédpanel** számos lapot tartalmaz, például **General**, **Summary**, **Statistics**, **Contents** és **Custom**. Mindezek a lapok különféle információk konfigurálását teszik lehetővé a PowerPoint fájlokhoz. Az **Custom** lapot a PowerPoint fájlok egyéni tulajdonságainak kezelésére használják.

**Dokumentumtulajdonságok kezelése az Aspose.Slides for Android via Java segítségével**

Ahogy korábban ismertettük, az Aspose.Slides for Android via Java két fajta dokumentumtulajdonságot támogat: **Beépített** és **Egyéni**. A fejlesztők a két fajta tulajdonsághoz egyaránt hozzáférhetnek az Aspose.Slides for Android via Java API használatával. Az Aspose.Slides for Android via Java egy [IDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties) osztályt biztosít, amely a prezentáció fájlhoz kapcsolódó dokumentumtulajdonságokat képviseli a **Presentation.DocumentProperties** tulajdonságon keresztül.

A fejlesztők a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) objektum által biztosított **IDocumentProperties** tulajdonság segítségével érhetik el a prezentáció fájlok dokumentumtulajdonságait, ahogy alább le van írva:

## **Nyilvános tulajdonságok olvasása titkosított prezentációból**

A megnyitási jelszó általában a prezentáció tartalmát és a dokumentumtulajdonságokat egyaránt védi. Ha egy prezentációt úgy titkosítanak, hogy a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-)‑nek `false`‑t adnak, a dokumentumtulajdonságok nyilvánosak maradnak. Ezután egy alkalmazás a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-)‑nek `true`‑t adva a nyilvános metaadatokat olvashatja meg a megnyitási jelszó megadása nélkül.

A **document‑properties‑only** opció azt szabályozza, hogy az Aspose.Slides mit tölt be; semmit sem titkosít vissza. Ha a tulajdonságok be lettek vonva a titkosításba, a jelszó nélkül történő betöltés sikertelen. Ha a prezentáció nincs titkosítva, az opció figyelmen kívül marad, és a teljes prezentáció betöltődik.

Az alábbi példa a [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--)‑en keresztül ellenőrzi a betöltési módot, majd a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--)‑vel beolvassa a beépített tulajdonságokat:

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

Ebben a módban a dia tartalma nem kerül betöltésre. A diák, masterek, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) értékét, mielőtt olyan műveletet végeznének, amely a teljes objektummodellt igényli.

{{% alert color="warning" title="Warning" %}}
A nyilvános metaadatok felfedhetik a szerzők nevét, címeket, tárgyakat, kulcsszavakat, céginformációkat, megjegyzéseket és egyéni értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Csak akkor hagyja nyilvánosként, ha indexelés, osztályozás, keresés vagy dokumentumkezelő rendszereknek kifejezett igénye van a jelszó nélküli hozzáférésre.
{{% /alert %}}

## **Tulajdonságok frissítése titkosított prezentációban**

Titkosított PPTX fájl esetén a **document‑properties‑only** módban betöltött prezentáció célja a nyilvános metaadatok olvasása. Az Aspose.Slides nem tudja elmenteni a módosított tulajdonságokat ebből a csak‑metaadat objektumból, mert a nyilvános tulajdonságoknak összhangban kell lenniük a titkosított prezentáció megfelelő adataival. Ennek frissítése ezért a helyes megnyitási jelszót és a teljes betöltést igényli.

Az alábbi példa a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)‑el nyitja meg a prezentációt, frissíti a nyilvános beépített tulajdonságokat, majd elmenti az eredményt. Ezután a [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--)‑t használja annak ellenőrzésére, hogy a titkosítás megmaradt‑e, és jelszó nélkül újra megnyitja a nyilvános metaadatokat az új értékek ellenőrzéséhez:

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

Ha egy alkalmazás nem kap jogosultságot a prezentáció tartalmának visszafejtésére vagy betöltésére, a titkosított PPTX fájl nyilvános tulajdonságait csak olvashatóként kell kezelnie.

## **Beépített tulajdonságok elérése**

Az [IDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties) objektum által kiexponált tulajdonságok a következők: **Creator** (Szerző), **Description**, **Keywords**, **Created** (Létrehozás dátuma), **Modified** (Módosítás dátuma), **Printed** (Legutóbbi nyomtatás dátuma), **LastModifiedBy**, **SharedDoc** (Közös használatban van‑e?), **PresentationFormat**, **Subject** és **Title**.

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely a prezentációt képviseli
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hozzon létre hivatkozást a Presentation-hez kapcsolódó IDocumentProperties objektumra
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

A beépített tulajdonságok módosítása ugyanolyan egyszerű, mint elérésük. Egyszerűen egy karakterlánc értéket kell hozzárendelni a kívánt tulajdonsághoz, és a tulajdonság értéke módosulni fog. Az alábbi példában bemutatjuk, hogyan módosíthatjuk a prezentáció fájl beépített dokumentumtulajdonságait az Aspose.Slides for Android via Java segítségével.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hozzon létre hivatkozást a Presentation-hez kapcsolódó IDocumentProperties objektumra
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

Ez a példa módosítja a prezentáció beépített tulajdonságait, amint az alább látható:

|**Beépített dokumentumtulajdonságok módosítás után**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Egyéni dokumentumtulajdonságok hozzáadása**

Az Aspose.Slides for Android via Java lehetővé teszi a fejlesztők számára, hogy egyéni értékeket adjanak a prezentáció dokumentumtulajdonságaihoz. Az alábbi példa három egyéni tulajdonságot ad hozzá, majd a 2. indexen tárolt nevet lekérdezi és eltávolítja azt, így a mentett prezentáció két egyéni tulajdonságot tartalmaz. Az egyéni tulajdonságok ábécé sorrendben kerülnek indexelésre, nem pedig a hozzáadásuk sorrendjében.

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

Az Aspose.Slides for Android via Java szintén lehetővé teszi a fejlesztőknek, hogy hozzáférjenek az egyéni tulajdonságok értékeihez. Az alábbi példa megmutatja, hogyan érheti el és módosíthatja ezeket az egyéni tulajdonságokat egy prezentációban.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Hozzon létre hivatkozást a Presentation-hez kapcsolódó DocumentProperties objektumra
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

Ez a példa a [PPTX](https://docs.fileformat.com/presentation/pptx/) prezentáció egyéni tulajdonságait módosítja. Az alábbi ábrák a módosítás előtti és utáni állapotot mutatják:

|**Egyéni tulajdonságok módosítás előtt**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Egyéni tulajdonságok módosítás után**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Speciális dokumentumtulajdonságok**

{{% alert color="info" title="Note" %}}
Új módszerek: [ReadDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), és [WriteBindedPresentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) lettek hozzáadva az [IPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo) felülethez, a [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) tulajdonság‑setter logikája megváltozott.
{{% /alert %}}

A két új módszer, a **ReadDocumentProperties** és az **UpdateDocumentProperties**, az [IPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentationInfo) interfészhez került hozzáadásra. Gyors hozzáférést biztosítanak a dokumentumtulajdonságokhoz, és lehetővé teszik azok módosítását anélkül, hogy a teljes prezentációt be kellene tölteni.

A tipikus forgatókönyv: betölti a tulajdonságokat, módosít egy értéket, majd frissíti a dokumentumot a következő módon:

```java
import com.aspose.slides.*;

// a prezentáció információinak olvasása
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

Létezik egy másik módja is, hogy egy adott prezentáció tulajdonságait sablonként használja fel más prezentációk tulajdonságainak frissítéséhez:

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

Új sablon létrehozható a semmiből, majd több prezentáció frissítésére felhasználható:

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

## **Ellenőrző nyelv beállítása**

Az Aspose.Slides biztosítja a **LanguageId** tulajdonságot (a **PortionFormat** osztály által kiexponált) a PowerPoint dokumentum helyesírás- és nyelvellenőrzésének beállításához. A helyesírás‑ellenőrzési nyelv az a nyelv, amelynek helyesírását és nyelvtanát a PowerPoint ellenőrzi.

Ez a Java kód megmutatja, hogyan állíthatja be a helyesírás‑ellenőrzési nyelvet egy PowerPoint dokumentumhoz:

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

    portionFormat.setLanguageId("zh-CN"); // állítsa be a helyesírás-ellenőrzés nyelvének azonosítóját

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Ez a Java kód bemutatja, hogyan állíthatja be az alapértelmezett nyelvet a teljes PowerPoint prezentációhoz:

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

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/hu/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció elválaszthatatlan részei, ezért nem távolíthatók el teljesen. Azonban módosíthatja az értéküket, vagy ha a konkrét tulajdonság megengedi, beállíthatja őket üresre.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő érték felül lesz írva az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti az értéket.

**Elérhetem a prezentáció tulajdonságait anélkül, hogy a teljes prezentációt betölteném?**

Igen. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)‑et, majd a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)‑t a tárolt dokumentummetaadatok olvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/androidjava/examine-presentation/) oldalt a teljes jelentéshez és a formátumspecifikus korlátozásokhoz.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból a megnyitási jelszó nélkül?**

Igen. A dokumentumtulajdonság‑titkosítást le kell tiltani a prezentáció titkosítása előtt, és a prezentációt **document‑properties‑only** módban kell betölteni.

**Frissíthetek egy titkosított PPTX fájlt **document‑properties‑only** módban?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak összhangban kell lenniük, így egy titkosított PPTX fájl frissítése a megfelelő megnyitási jelszóval és a teljes betöltéssel lehetséges.