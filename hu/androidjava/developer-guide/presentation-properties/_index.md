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
- egyedi tulajdonságok
- haladó tulajdonságok
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
description: "Kezelje a prezentáció tulajdonságait az Aspose.Slides for Android via Java segítségével, és egyszerűsítse a keresést, a márkázást és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java támogatja a **beépített** és **egyedi** dokumentumtulajdonságokat. Használja ezeket a tulajdonságokat a bemutató metaadatainak olvasásához és frissítéséhez, például a szerző, a cím és a felhasználó által meghatározott értékek esetén.

Az Aspose.Slides lehetővé teszi a bemutató dokumentumtulajdonságokkal való munkát a [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) interfészen keresztül. Ennek az interfésznek egy példánya a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) metódusával érhető el. A következő példák bemutatják, hogyan lehet olvasni, módosítani és kezelni ezeket a tulajdonságokat.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides kezeli az alkalmazás- és gyártói metaadatokat a prezentációk mentésekor; ezek a mezők azonosítják a kimenetet létrehozó szoftvert.
{{% /alert %}}

## **A prezentáció tulajdonságainak kezelése**

A dokumentumtulajdonságok leíró információkat tárolnak a bemutató tartalma mellett. Két kategóriába sorolhatók:

- **Beépített tulajdonságok** szabványos metaadatokat tartalmaznak, például a címet, a szerzőt és a dokumentum statisztikákat.
- **Egyedi tulajdonságok** felhasználó által meghatározott név/érték párokat tárolnak.

Az Aspose.Slides for Android via Java hozzáférést biztosít mindkét kategóriához. A PowerPointban válassza a **File → Info → Properties → Advanced Properties** menüpontot a dokumentum metaadatainak megtekintéséhez. A párbeszédpanel az információkat olyan fülekre csoportosítja, mint a **Summary**, **Statistics**, **Contents** és **Custom**. Használja a **Custom** fület a felhasználó által definiált tulajdonságok kezeléséhez.

## **Nyilvános tulajdonságok olvasása titkosított prezentációból**

A megnyitási jelszó általában védi a prezentáció tartalmát és a dokumentumtulajdonságokat is. Ha egy prezentációt a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) `false` értékkel hívás után titkosítanak, a dokumentumtulajdonságai nyilvánosak maradnak. Egy alkalmazás ezután a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) `true` értékkel hívásával olvashatja a nyilvános metaadatokat a megnyitási jelszó megadása nélkül.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) szabályozza, hogy az Aspose.Slides mit tölt be; semmit sem titkosít vissza. Ha a tulajdonságok a titkosítás részei voltak, a jelszó nélkül történő betöltés sikertelen. Ha a prezentáció nincs titkosítva, az opciót figyelmen kívül hagyják, és a teljes prezentáció betöltődik.

A példához egy olyan titkosított prezentációra van szükség, amelynek dokumentumtulajdonságai nyilvánosak maradtak. A betöltési módot az [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) ellenőrzi, majd a beépített tulajdonságokat a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) segítségével olvassa:

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

Ebben a módban a dia tartalma nem töltődik be. A diák, mesterdiák, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem állnak rendelkezésre. Az alkalmazásoknak mindig ellenőrizniük kell az [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) metódust, mielőtt olyan műveletet hajtanának végre, amely a teljes prezentációs objektummodellt igényli.

{{% alert color="warning" title="Warning" %}}
A nyilvános metaadatok felfedhetik a szerző neveket, címeket, tárgyakat, kulcsszavakat, vállalati információkat, megjegyzéseket és egyedi értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Csak akkor hagyja nyilvánosan, ha az indexelés, besorolás, keresés vagy dokumentumkezelő rendszereknek kifejezett igénye van a jelszó nélküli hozzáféréshez.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) `true` értékkel hívás után betöltött prezentáció a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja menteni a módosított tulajdonságokat ebből a csak metaadatokat tartalmazó objektumból, mivel a nyilvános tulajdonságoknak következetesnek kell maradniuk a titkosított prezentáción belüli megfelelő adatokkal. Ennek frissítéséhez ezért a helyes megnyitási jelszó és a teljes betöltés szükséges.

A példához egy olyan titkosított PPTX prezentációra van szükség, amelynek dokumentumtulajdonságai nyilvánosak, és a megnyitási jelszó ismert. A teljes prezentációt a [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) segítségével nyitja meg, frissíti a nyilvános beépített tulajdonságokat, majd menti az eredményt. Ezután a [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) használatával ellenőrzi, hogy a titkosítás megmaradt, és a nyilvános metaadatokat jelszó nélkül nyitja újra a új értékek ellenőrzéséhez:

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

Ha egy alkalmazásnak nem engedélyezett a prezentáció tartalmának visszafejtése vagy betöltése, akkor egy titkosított PPTX fájl nyilvános tulajdonságait csak olvashatóként kell kezelnie.

## **Beépített tulajdonságok elérése**

Az [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) interfész getter metódusokkal teszi elérhetővé a beépített metaadatokat, beleértve a [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--) és a [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--) metódusokat. Ez a példa megnyit egy meglévő prezentációt, és kiírja a tárolt metaadatait a konzolra. Az értékek a bemeneti prezentációtól függenek; egyes mezők üresek lehetnek.

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

### **Verziószám és szerkesztési idő jelentése**

Ahhoz, hogy egy sort jelentsenek a mappában lévő minden PPTX fájlhoz, amelyet az Android alkalmazás olvasni tud, hívja a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) metódust, hogy a [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) objektumot a diák betöltése nélkül olvassa. Az Android via Java API a szerkesztési időt ezredmásodpercben adja vissza. Cserélje le a minta mappautat a saját fájljai útvonalára. A példa a időt órákra, percekre és másodpercekre formázza, napokkal a 24 órán vagy annál hosszabb időtartamok esetén.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.File;
import java.util.Locale;

File folder = new File("/path/to/presentations");
File[] files = folder.listFiles();
if (files == null) {
    System.out.println("Cannot list files in " + folder);
} else {
    System.out.println("File | RevisionNumber | TotalEditingTime");
    for (File file : files) {
        if (!file.isFile() || !file.getName().toLowerCase(Locale.ROOT).endsWith(".pptx")) {
            continue;
        }
        IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(file.getAbsolutePath());
        IDocumentProperties properties = info.readDocumentProperties();
        long totalSeconds = (long) properties.getTotalEditingTime() / 1000;
        long days = totalSeconds / 86400;
        String time = String.format(Locale.ROOT, "%02d:%02d:%02d", totalSeconds / 3600 % 24, totalSeconds / 60 % 60, totalSeconds % 60);
        String editingTime = days > 0 ? days + "." + time : time;
        System.out.printf(Locale.ROOT, "%s | %d | %s%n", file.getName(), properties.getRevisionNumber(), editingTime);
    }
}
```

Egy, 1 nap, 2 óra és 5 perc szerkesztési idővel rögzített prezentáció esetén a jelentés a következő kimenetet mutatja.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getRevisionNumber--) egy értéket olvas, amelyet az alkalmazások a [setRevisionNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setRevisionNumber-int-) segítségével módosíthatnak. A verziószám önmagában nem határozza meg, hogy hányszor mentették a prezentációt, vagy nem állítja helyre annak verziótörténetét.

[getTotalEditingTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTotalEditingTime--) a fájlban rögzített szerkesztési időt olvassa. A `00:00:00` érték azt jelenti, hogy a tárolt idő nulla, még akkor is, ha valaki szerkesztette a prezentációt.

## **Beépített tulajdonságok módosítása**

A beépített metaadatok frissítéséhez használja a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--) által visszaadott objektum setter metódusait. Ez a példa megnyit egy meglévő prezentációt, meghívja a [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-) és [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) metódusokat, majd a [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) segítségével menti a frissített prezentációt. A mentett PPTX tartalmazza az új metaadatokat.

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

## **A hivatkozási alap kezelésése**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) visszaadja a dokumentumszintű alapot a relatív hivatkozásokhoz. A [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) segítségével módosíthatja vagy törölheti azt. Ez hasznos, ha egy prezentációt és a kapcsolódó fájljait egy másik helyre mozgatja. Ez különálló az egyedi hivatkozás [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) metódusától: az alap módosítása nem írja felül a tárolt hivatkozási címeket, és nem változtatja meg a abszolút célokat.

A példához egy olyan prezentációra van szükség, amely tartalmaz egy relatív hivatkozást, például `target.html`, és egy abszolút hivatkozást, például `https://example.org/absolute.html`. A példa beolvassa a meglévő alapot, egy új alapcímet állít be, majd menti és újra megnyitja a prezentációt az érték ellenőrzéséhez. Ezután egy üres karakterlánccal törli az alapot, és egy külön mentett fájlban ellenőrzi az üres értéket. Cserélje le a példában szereplő alapcímet a saját kapcsolt fájljai helyére.

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

A két ellenőrző üzenetnek `true`-t kell kiíratnia. Az alap törlése nem érinti az egyedi hivatkozási címeket.

Egy relatív `target.pptx` hivatkozás `old/target.pptx`-t nyitott meg, amikor az alap a `old` mappára mutatott. Az alap `new` mappára való módosítása, a mentés és a prezentáció újranyitása után ugyanaz a hivatkozás `new/target.pptx`-t nyitott meg. Egy abszolút hivatkozás továbbra is ugyanazt a fájlt nyitotta meg. Tesztelje a relatív hivatkozásait a PowerPointban a prezentáció mozgatása vagy az alap megváltoztatása előtt és után.

## **Egyedi prezentációtulajdonságok hozzáadása**

Az egyedi tulajdonságok olyan metaadatokat tárolnak, amelyekhez nincs megfelelő beépített mező. A [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) metódus lehetővé teszi az érték hozzárendelését a tulajdonság nevéhez. Ez a példa létrehoz egy prezentációt, két szöveges értéket és egy egész verzióértéket ad hozzá, majd a [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) segítségével menti a prezentációt. Egy meglévő névhez érték hozzárendelése felülírja a tulajdonság értékét.

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

## **Egyedi tulajdonságok elérése és módosítása**

Ez a példa megnyit egy olyan prezentációt, amely egyedi tulajdonságokat tartalmaz, és a [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) segítségével iterálja őket. A [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) nulla alapú indexet fogad, és visszaadja azt a nevet, amelyet az [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) használ. A példa kiírja minden eredeti nevet és értéket, minden értéket egy számozott sztringre cserél, függetlenül az eredeti típustól, majd menti a módosításokat. Ha nincsenek egyedi tulajdonságok, a ciklus nem hajt végre változtatást.

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

Próbálja ki a [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) online alkalmazást, hogy lássa, hogyan lehet a dokumentumtulajdonságokkal dolgozni az Aspose.Slides API segítségével:

[![Nézet és PowerPoint metaadatok szerkesztése](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban megváltoztathatja értéküket, vagy ha a konkrét tulajdonság engedi, üresre állíthatja.

**Mi történik, ha olyan egyedi tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyedi tulajdonságot ad hozzá, amely már létezik, a meglévő értéke felülíródik az újjal. Nem szükséges előzetesen eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Hozzáférhetek a prezentáció tulajdonságaihoz anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) metódust, majd a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)‑t a tárolt dokumentum metaadatok olvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) példányt hozna létre. Tekintse meg a [Könnyűsúlyú prezentációs leltár felépítése](/slides/hu/androidjava/examine-presentation/) oldalt a teljes jelentési példához és a formátum-specifikus korlátozásokhoz.

**Olvashatom a titkosított prezentáció nyilvános tulajdonságait a megnyitási jelszó nélkül?**

Igen. A prezentációt úgy kell titkosítani, hogy a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) `false` értékkel legyen meghívva, majd a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) `true` értékkel betöltve legyen.

**Frissíthetek egy titkosított PPTX fájlt csak a dokumentumtulajdonságok módon?**

Nem. A nyilvános és titkosított tulajdonság adatoknak konzisztensnek kell maradniuk, ezért egy titkosított PPTX fájl frissítéséhez a teljes prezentációt a megfelelő megnyitási jelszóval kell betölteni.