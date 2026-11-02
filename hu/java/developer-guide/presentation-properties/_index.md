---
title: Prezentáció tulajdonságok kezelése Java-ban
linktitle: Prezentáció tulajdonságok
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
- ellenőrző nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Kezelje a prezentáció tulajdonságait az Aspose.Slides for Java-ban, és egyszerűsítse a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for Java **beépített** és **egyéni** dokumentumtulajdonságokat támogat. Ezekkel a tulajdonságokkal olvashatja és frissítheti a prezentáció metaadatait, például a szerzőt, a címet és a felhasználó által megadott értékeket.

Az Aspose.Slides a prezentáció dokumentumtulajdonságokkal való munka során a [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) interfészt használja. Ennek az interfésznek egy példányát a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) adja vissza. Az alábbi példák bemutatják, hogyan olvassa, módosítsa és kezelje ezeket a tulajdonságokat.

{{% alert color="info" title="Megjegyzés" %}}

Az Aspose.Slides a mentéskor kezeli az alkalmazás- és gyártómetaadatokat; ezek a mezők azonosítják a kimenetet létrehozó szoftvert.

{{% /alert %}}

## **Prezentáció Tulajdonságainak Kezelése**

A dokumentumtulajdonságok leíró információkat tárolnak a prezentáció tartalma mellett. Két kategóriába sorolhatók:

- **Beépített tulajdonságok** szabványos metaadatokat tartalmaznak, például a címet, a szerzőt és a dokumentum statisztikákat.
- **Egyéni tulajdonságok** felhasználó által megadott név/érték párokat tárolnak.

Az Aspose.Slides for Java mindkét kategóriához hozzáférést biztosít. PowerPointban válassza a **Fájl → Info → Tulajdonságok → Speciális tulajdonságok** menüpontot a dokumentum metaadatainak megtekintéséhez. A párbeszédablak információkat csoportosít fülek szerint, mint például **Összegzés**, **Statisztika**, **Tartalom** és **Egyéni**. Az **Egyéni** fülön kezelheti a felhasználó által definiált tulajdonságokat.

## **Nyilvános Tulajdonságok Olvasása Titkosított Prezentációból**

A megnyitási jelszó általában védi a prezentáció tartalmát és a dokumentumtulajdonságokat is. Ha a prezentációt úgy titkosítják, hogy a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) értéke `false`, a dokumentumtulajdonságok nyilvánosak maradnak. Ezután egy alkalmazás a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) `true` értékkel hívásával a nyilvános metaadatot a megnyitási jelszó megadása nélkül is beolvashatja.

A [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) szabályozza, hogy az Aspose.Slides mit tölt be; semmit sem fejti vissza. Ha a tulajdonságok a titkosítás részét képezték, a jelszó nélküli betöltés hibát eredményez. Ha a prezentáció nincs titkosítva, az opciót figyelmen kívül hagyják, és a teljes prezentáció betöltődik.

A példa egy olyan titkosított prezentációt igényel, amelynek a dokumentumtulajdonságai nyilvánosak maradtak. Ellenőrzi a betöltési módot a [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) segítségével, majd beolvassa a beépített tulajdonságokat a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) módszerrel:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Ebben a módban a diatartalom nem töltődik be. Diák, mesterdiák, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak minden művelet előtt, amely a teljes prezentációs objektummodellt igényli, ellenőrizniük kell a [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) állapotát.

{{% alert color="warning" title="Figyelmeztetés" %}}
A nyilvános metaadatok felfedhetik a szerző neveket, címeket, tárgyakat, kulcsszavakat, céginformációkat, megjegyzéseket és egyéni értékeket. Érzékeny tulajdonságokat titkosítson együtt a prezentációval. Csak akkor hagyja nyilvánosként, ha indexelés, osztályozás, keresés vagy dokumentumkezelő rendszernek kifejezett szüksége van rá jelszó nélkül.
{{% /alert %}}

## **Titkosított Prezentáció Tulajdonságainak Frissítése**

Egy titkosított PPTX fájl esetén a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) `true` értékkel betöltött prezentáció a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja menteni a módosított tulajdonságokat ebből a metaadat‑csak objektumból, mivel a nyilvános tulajdonságoknak összhangban kell lenniük a titkosított prezentációban tárolt adatokkal. A frissítéshez ezért a megfelelő megnyitási jelszó és a teljes betöltés szükséges.

A példa egy olyan titkosított PPTX prezentációt igényel, amelynek a dokumentumtulajdonságai nyilvánosak, és ismert a megnyitási jelszó. A teljes prezentációt a [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) segítségével nyitja meg, frissíti a nyilvános beépített tulajdonságokat, és elmenti az eredményt. Ezután a [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) segítségével ellenőrzi, hogy a titkosítás megmaradt‑e, és újra megnyitja a nyilvános metaadatot jelszó nélkül a új értékek ellenőrzéséhez:

```java
import com.aspose.slides.IDocumentProperties;
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
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");

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

Ha egy alkalmazás nem kap engedélyt a prezentáció tartalmának visszafejtésére vagy betöltésére, a titkosított PPTX fájl nyilvános tulajdonságait csak olvashatóként kell kezelni.

## **Beépített Tulajdonságok Elérése**

Az [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) interfész a beépített metaadatokat getter metódusokkal teszi elérhetővé, többek között a [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--), a [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--) és a [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--) metódusokkal. Ez a példa egy meglévő prezentációt nyit meg, és a konzolra írja a tárolt metaadatokat. Az értékek a bemeneti prezentációtól függenek; egyes mezők üresek lehetnek.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Beépített Tulajdonságok Módosítása**

A beépített metaadatok frissítéséhez használja a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) által visszaadott objektum setter metódusait. Ez a példa egy meglévő prezentációt nyit meg, meghívja a [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), a [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), a [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), a [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-) és a [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) metódusokat, majd a [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) segítségével elmenti a frissített prezentációt. A mentett PPTX tartalmazza az új metaadatokat.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A Hiperhivatkozás Alapjának Kezelése**

Az [IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) visszaadja a dokumentumszintű alapot a relatív hiperhivatkozásokhoz. Az [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) használatával módosítható vagy törölhető. Ez akkor hasznos, ha egy prezentációt és a kapcsolódó fájlokat más helyre akarja áthelyezni. Ez különbözik az egyes hiperhivatkozások [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) értékétől: az alap módosítása nem írja felül a mentett hivatkozási címeket, és nem változtatja meg az abszolút célokat.

A példa egy olyan prezentációt igényel, amely tartalmaz egy relatív hivatkozást (például `target.html`) és egy abszolút hivatkozást (például `https://example.org/absolute.html`). A meglévő alapot beolvassa, új alapcímre állítja, elmenti és újra megnyitja a prezentációt az érték ellenőrzéséhez. Ezután egy üres karakterlánccal törli az alapot, és egy külön fájlban ellenőrzi az üres értéket. Cserélje a példában szereplő alapcímet a saját kapcsolt fájljai helyére.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

A két ellenőrző üzenetnek `true`‑t kell kiírnia. Az alap törlése nem érinti az egyes hiperhivatkozások címét.

Egy relatív hivatkozás a `target.pptx` fájlra a `old/target.pptx`‑t nyitotta meg, amikor az alap a `old` mappára mutatott. Az alap `new` mappára történő módosítása, a mentés és a prezentáció újbóli megnyitása után ugyanaz a hivatkozás a `new/target.pptx`‑t nyitja meg. Egy abszolút hivatkozás továbbra is ugyanazt a fájlt nyitja. Tesztelje a relatív hivatkozásokat PowerPointban a prezentáció áthelyezése vagy az alap módosítása előtt és után.

## **Egyéni Prezentációs Tulajdonságok Hozzáadása**

Az egyéni tulajdonságok olyan metaadatot tárolnak, amelyhez nincs megfelelő beépített mező. Az [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) metódus lehetővé teszi, hogy egy tulajdonságnév alapján értéket rendeljünk hozzá. Ez a példa egy prezentációt hoz létre, két szöveges értéket és egy egész verziószámot ad hozzá, majd a [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) segítségével menti a prezentációt. Egy már létező névhez érték hozzárendelése felülírja a tulajdonság korábbi értékét.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Egyéni Tulajdonságok Elérése és Módosítása**

Ez a példa egy olyan prezentációt nyit meg, amely egyéni tulajdonságokat tartalmaz, és a [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) segítségével iterál rajtuk. A [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) nulla‑alapú indexet fogad, és visszaadja a [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) által használt nevet. A példa kiírja minden eredeti nevet és értéket, minden értéket számozott szövegre cserél függetlenül az eredeti típusától, majd elmenti a változtatásokat. Ha nincsenek egyéni tulajdonságok, a ciklus nem hajt végre módosítást.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Élő Példa**

Próbálja ki az online alkalmazást [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata), amely megmutatja, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API‑val:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot a prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket, vagy ha a konkrét tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő érték felül lesz írva az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti annak értékét.

**Elérhetem a prezentáció tulajdonságait anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) metódust, majd a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) segítségével olvassa be a tárolt dokumentum metaadatait anélkül, hogy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) példányt hozna létre. Tekintse meg a [Build a Lightweight Presentation Inventory](/slides/hu/java/examine-presentation/) cikket egy teljes jelentési példa és formátumspecifikus korlátozások megtekintéséhez.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból a megnyitási jelszó nélkül?**

Igen. A prezentációt úgy kell titkosítani, hogy a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) `false` értékkel legyen meghívva, és a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) `true` értékkel kell betölteni.

**Frissíthetek egy titkosított PPTX fájlt csak a dokumentumtulajdonságok‑betöltés módjában?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak összhangban kell lenniük, ezért egy titkosított PPTX fájl frissítéséhez a teljes prezentációt a helyes megnyitási jelszóval kell betölteni.