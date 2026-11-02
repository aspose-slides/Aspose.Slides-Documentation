---
title: Prezentáció tulajdonságainak kezelése Androidon
linktitle: Prezentáció tulajdonságai
type: docs
weight: 70
url: /hu/androidjava/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságok
- dokumentum tulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- haladó tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- ellenőrző nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Kezelje a prezentáció tulajdonságait az Aspose.Slides for Android via Java segítségével, és egyszerűsítse a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java támogatja a **beépített** és **egyéni** dokumentumtulajdonságokat. Ezeket a tulajdonságokat használhatja a prezentáció metaadatainak olvasására és frissítésére, például a szerzőre, címre és a felhasználó által meghatározott értékekre.

Az Aspose.Slides lehetővé teszi a prezentáció dokumentumtulajdonságokkal való munkát a [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) felületen keresztül. Ennek a felületnek egy példányát a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) adja vissza. Az alábbi példák bemutatják, hogyan lehet ezeket a tulajdonságokat olvasni, módosítani és kezelni.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides a mentéskor kezeli az alkalmazás- és gyártói metaadatokat; ezek a mezők azonosítják a kimenetet létrehozó szoftvert.
{{% /alert %}}

## **A prezentáció tulajdonságainak kezelése**

A dokumentumtulajdonságok leíró információkat tárolnak a prezentáció tartalma mellett. Két kategóriába sorolhatók:

- **Beépített tulajdonságok** szabványos metaadatokat tartalmaznak, mint a cím, szerző és a dokumentum statisztikái.
- **Egyéni tulajdonságok** felhasználó által meghatározott név/érték párokat tárolnak.

Az Aspose.Slides for Android via Java mindkét kategóriához hozzáférést biztosít. A PowerPointban válassza a **File → Info → Properties → Advanced Properties** menüpontot a dokumentum metaadatainak megtekintéséhez. A párbeszédablak információkat csoportosít fülekre, mint **Summary**, **Statistics**, **Contents** és **Custom**. Használja a **Custom** fület a felhasználó által meghatározott tulajdonságok kezeléséhez.

## **Nyilvános tulajdonságok olvasása titkosított prezentációból**

A megnyitási jelszó általában védi a prezentáció tartalmát és a dokumentumtulajdonságokat is. Ha a prezentációt úgy titkosítják, hogy a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) értéke `false`, a dokumentumtulajdonságok nyilvánosak maradnak. Ezután az alkalmazás hívhatja a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) metódust `true` értékkel, és a nyilvános metaadatokat a megnyitási jelszó megadása nélkül is olvashatja.

A [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) azt szabályozza, hogy az Aspose.Slides mit tölt be; semmit sem titkosít vissza. Ha a tulajdonságok a titkosítás részét képezték, a jelszó nélkül történő betöltés hibát eredményez. Ha a prezentáció nincs titkosítva, a beállítás figyelmen kívül marad, és a teljes prezentáció betöltődik.

A példához egy olyan titkosított prezentációra van szükség, amelynek dokumentumtulajdonságai nyilvánosak. A [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) metódussal ellenőrizzük a betöltési módot, majd a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) segítségével olvassuk a beépített tulajdonságokat:

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

Ebben a módban a dia tartalma nem kerül betöltésre. A diák, a főbb minta, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) értékét, mielőtt olyan műveletet végeznek, amely a teljes objektummodellt igényli.

{{% alert color="warning" title="Warning" %}}
A nyilvános metaadatok felfedhetik a szerző nevét, címét, tárgyát, kulcsszavait, céginformációit, megjegyzéseit és egyéni értékeit. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Csak olyan esetben hagyja nyilvánosnak, ha indexelés, osztályozás, keresés vagy dokumentumkezelő rendszereknek konkrétan szükségük van rá jelszó nélkül.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) `true` értékkel történő betöltése csak a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja menteni a módosított tulajdonságokat ebből a metaadat‑csak objektumból, mert a nyilvános tulajdonságoknak meg kell egyezniük a titkosított prezentációban tárolt adatokkal. A módosításhoz szükség van a helyes megnyitási jelszóra és a teljes betöltésre.

A példához egy nyilvános dokumentumtulajdonságokkal rendelkező titkosított PPTX‑re és egy ismert megnyitási jelszóra van szükség. A teljes prezentációt a [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) segítségével nyitjuk meg, frissítjük a nyilvános beépített tulajdonságokat, és mentjük az eredményt. Ezután a [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) metódussal ellenőrizzük, hogy a titkosítás megmaradt, és a nyilvános metaadatokat jelszó nélkül nyitjuk meg az új értékek ellenőrzéséhez:

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

Ha egy alkalmazás nem jogosult a prezentáció tartalmának visszafejtésére vagy betöltésére, a titkosított PPTX nyilvános tulajdonságait csak olvasási módban kezelheti.

## **Beépített tulajdonságok elérése**

Az [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) felület getter metódusokkal teszi elérhetővé a beépített metaadatokat, ideértve a [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--), a [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--) és a [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--) metódusokat. Ez a példa megnyit egy meglévő prezentációt és a konzolra írja a tárolt metaadatokat. Az értékek a bemeneti prezentációtól függenek; egyes mezők üresek lehetnek.

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

## **Beépített tulajdonságok módosítása**

A beépített metaadatok frissítéséhez használja a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) által visszaadott objektum setter metódusait. Ez a példa megnyit egy meglévő prezentációt, meghívja a [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), és [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) metódusokat, majd a [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) segítségével menti a frissített prezentációt. A mentett PPTX az új metaadatokat tartalmazza.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Android via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A Hyperlink Base kezelése**

Az [IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) visszaadja a dokumentumszintű bázist a relatív hiperhivatkozásokhoz. A [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) használatával módosítható vagy törölhető. Ez akkor hasznos, ha egy prezentációt és a hozzá tartozó fájlokat egy másik helyre mozgatja. Ez különálló az egyes hiperhivatkozások [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) metódusától: a bázis módosítása nem írja felül a tárolt linkcímeket, és nem változtatja meg a abszolút célokat.

A példa egy olyan prezentációt igényel, amely tartalmaz egy relatív linket (például `target.html`) és egy abszolút linket (például `https://example.org/absolute.html`). A meglévő bázist beolvassa, új báziscímet ad meg, majd menti és újra megnyitja a prezentációt az érték ellenőrzéséhez. Ezután egy üres karakterlánccal törli a bázist, és egy külön mentett fájlban ellenőrzi az üres értéket. Cserélje le a példában szereplő báziscímet a saját hivatkozási fájljai helyére.

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

A két ellenőrző üzenetnek `true`‑nak kell kiíródnia. A bázis törlése nem érinti az egyéni hiperhivatkozások címét.

Egy relatív link `target.pptx` a `old/target.pptx`‑t nyitotta meg, amikor a bázis az `old` mappára mutatott. A bázist a `new` mappára állítva, mentés után és újra megnyitáskor a link a `new/target.pptx`‑t nyitja meg. Egy abszolút link továbbra is ugyanazt a fájlt nyitja. Tesztelje a relatív hivatkozásokat a PowerPointban a prezentáció mozgatása vagy a bázis módosítása előtt és után.

## **Egyéni prezentációs tulajdonságok hozzáadása**

Az egyéni tulajdonságok olyan metaadatokat tárolnak, amelyekhez nincs megfelelő beépített mező. A [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) metódus lehetővé teszi egy érték hozzárendelését tulajdonságnév alapján. Ez a példa létrehozza a prezentációt, két szöveges értéket és egy egész szám‑verzióértéket ad hozzá, majd a [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) segítségével menti. Egy már létező névhez történő értékadás felülírja a meglévő tulajdonság értékét.

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

## **Egyéni tulajdonságok elérése és módosítása**

Ez a példa megnyit egy olyan prezentációt, amely egyéni tulajdonságokat tartalmaz, és a [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) segítségével iterál rajtuk. A [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) nullától kezdődő indexet fogad, és visszaadja a [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) által használt nevet. A példa minden eredeti nevet és értéket kiír, minden értéket egy számozott sztringgel helyettesít függetlenül az eredeti típustól, majd menti a változtatásokat. Ha nincsenek egyéni tulajdonságok, a ciklus nem hoz létre módosítást.

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

## **Élő példa**

Próbálja ki az online alkalmazást, a [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) segítségével, hogy megismerje a dokumentumtulajdonságokkal való munkát az Aspose.Slides API‑val:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot a prezentációból?**

A beépített tulajdonságok a prezentáció integrált részei, ezért nem távolíthatók el teljesen. Azonban módosíthatja az értéküket vagy üresre állíthatja őket, ha az adott tulajdonság ezt megengedi.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha egy már létező egyéni tulajdonságot ad hozzá, a meglévő érték felül lesz írva az újjal. Nem szükséges előzetesen eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti annak értékét.

**Elérhetem a prezentáció tulajdonságait a teljes prezentáció betöltése nélkül?**

Igen. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) metódust, majd a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) segítségével olvassa a tárolt dokumentum metaadatait anélkül, hogy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/androidjava/examine-presentation/) cikket a teljes jelentéskészítési példához és a formátumspecifikus korlátozásokért.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból a megnyitási jelszó nélkül?**

Igen. A prezentációt úgy kell titkosítani, hogy a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) `false` értékkel legyen meghívva, és a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) `true` értékkel történő betöltés után olvasható a nyilvános metaadat.

**Frissíthetem-e a titkosított PPTX‑fájlt dokumentum‑tulajdonság‑csak módba?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak konzisztensnek kell maradniuk, ezért egy titkosított PPTX‑fájl frissítéséhez a teljes prezentációt a megfelelő megnyitási jelszóval kell betölteni.