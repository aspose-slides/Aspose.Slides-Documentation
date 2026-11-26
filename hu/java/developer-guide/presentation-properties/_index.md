---
title: Prezentáció tulajdonságainak kezelése Java-ban
linktitle: Prezentáció tulajdonságok
type: docs
weight: 70
url: /hu/java/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságai
- dokumentumtulajdonságok
- beépített tulajdonságok
- egyedi tulajdonságok
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
description: "Az Aspose.Slides for Java fő prezentációs tulajdonságait kezelje, és optimalizálja a keresést, a márkajelzést és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for Java támogatja a **beépített** és **egyedi** dokumentumtulajdonságokat. Használja ezeket a tulajdonságokat a bemutató metaadatainak olvasására és frissítésére, például a szerző, a cím és a felhasználó által definiált értékek esetén.

Az Aspose.Slides lehetővé teszi, hogy a bemutató dokumentumtulajdonságokkal a [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) interfészen keresztül dolgozzon. Ennek az interfésznek egy példányát a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) adja vissza. A következő példák bemutatják, hogyan olvassa, módosítsa és kezelje ezeket a tulajdonságokat.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides kezeli az alkalmazás és a gyártó metaadatait a bemutatók mentésekor; ezek a mezők azonosítják a kimenetet létrehozó szoftvert.
{{% /alert %}}

## **A prezentáció tulajdonságainak kezelése**

A dokumentumtulajdonságok leíró információkat tárolnak a prezentáció tartalma mellett. Két kategóriába sorolhatók:

- **Beépített tulajdonságok** tartalmaznak standard metaadatokat, például a címet, a szerzőt és a dokumentum statisztikákat.
- **Egyedi tulajdonságok** tárolnak felhasználó által definiált név/érték párokat.

Az Aspose.Slides for Java hozzáférést biztosít mindkét kategóriához. A PowerPointban válassza a **File → Info → Properties → Advanced Properties** menüt a dokumentum metaadatainak megtekintéséhez. A párbeszédpanel információkat csoportosít a **Summary**, **Statistics**, **Contents**, és **Custom** fülekre. Az **Custom** fület használja a felhasználó által definiált tulajdonságok kezeléséhez.

## **Nyilvános tulajdonságok olvasása titkosított prezentációból**

A megnyitási jelszó általában a prezentáció tartalmát és a dokumentumtulajdonságokat is védi. Ha egy prezentációt a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) hívása `false` értékkel titkosítják, a dokumentumtulajdonságok nyilvánosak maradnak. Egy alkalmazás ezután a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) `true` értékkel hívásával olvashatja a nyilvános metaadatokat a megnyitási jelszó megadása nélkül.

A [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) szabályozza, hogy az Aspose.Slides mit tölt be; semmit sem fejti fel. Ha a tulajdonságok a titkosítás részei voltak, a jelszó nélkül történő betöltés sikertelen. Ha a prezentáció nincs titkosítva, a beállítás figyelmen kívül marad, és a teljes prezentáció betöltődik.

A példa egy titkosított prezentációt igényel, amelynek dokumentumtulajdonságai nyilvánosak maradtak. A betöltési módot a [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) segítségével ellenőrzi, majd a beépített tulajdonságokat a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) segítségével olvassa:
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

Ebben a módban a dia tartalma nem kerül betöltésre. A diák, mesterdiák, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) hívást, mielőtt olyan műveletet végeznek, amely a teljes prezentációs objektummodellt igényli.

{{% alert color="warning" title="Warning" %}}
A nyilvános metaadatok felfedhetik a szerző neveit, címeket, tárgyakat, kulcsszavakat, céginformációkat, megjegyzéseket és egyedi értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Hagyja őket nyilvánosan csak akkor, ha indexelés, osztályozás, keresés vagy dokumentumkezelő rendszereknek kifejezett igénye van a jelszó nélküli hozzáférésre.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) `true` értékkel történő hívása után betöltött prezentáció a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja menteni a módosított tulajdonságokat ebből a csak metaadatot tartalmazó objektumból, mivel a nyilvános tulajdonságoknak összhangban kell lenniük a titkosított prezentációban lévő adatokkal. Ezért a frissítéshez a helyes megnyitási jelszó és a teljes betöltés szükséges.

A példa egy nyilvános dokumentumtulajdonságokkal rendelkező titkosított PPTX prezentációt és egy ismert megnyitási jelszót igényel. A teljes prezentációt a [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) segítségével nyitja meg, frissíti a nyilvános beépített tulajdonságokat, és elmenti az eredményt. Ezután a [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) használatával ellenőrzi, hogy a titkosítás megmaradt, és jelszó nélkül újra megnyitja a nyilvános metaadatokat az új értékek ellenőrzéséhez:
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

Ha egy alkalmazás nem jogosult a prezentáció tartalmát visszafejteni vagy betölteni, a titkosított PPTX fájl nyilvános tulajdonságait csak olvashatóként kell kezelni.

## **Beépített tulajdonságok elérése**

Az [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) interfész getter metódusokkal teszi elérhetővé a beépített metaadatokat, többek között a [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--), a [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--), és a [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--) metódusokkal. Ez a példa egy meglévő prezentációt nyit meg, és a tárolt metaadatokat kiírja a konzolra. Az értékek a bemeneti prezentációtól függenek; egyes mezők üresek lehetnek.
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

### **A verziószám és a szerkesztési idő jelentése**

Ahhoz, hogy minden PPTX fájlhoz a `presentations` mappában egy sort jelentést készítsen, hívja meg a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) metódust, így a [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) lekérhető a diák szerkesztés nélküli betöltése nélkül. A Java API a szerkesztési időt ezredmásodpercben adja vissza. A példa órákra, percekre és másodpercre formázza, és 24 órán felül napokban is számolja.
```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.nio.file.DirectoryStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

System.out.println("File | RevisionNumber | TotalEditingTime");
try (DirectoryStream<Path> files = Files.newDirectoryStream(Paths.get("presentations"), "*.pptx")) {
    for (Path path : files) {
        if (!Files.isRegularFile(path)) {
            continue;
        }
        IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(path.toString());
        IDocumentProperties properties = info.readDocumentProperties();
        long totalSeconds = (long) properties.getTotalEditingTime() / 1000;
        long days = totalSeconds / 86400;
        String time = String.format("%02d:%02d:%02d", totalSeconds / 3600 % 24, totalSeconds / 60 % 60, totalSeconds % 60);
        String editingTime = days > 0 ? days + "." + time : time;
        System.out.printf("%s | %d | %s%n", path.getFileName(), properties.getRevisionNumber(), editingTime);
    }
}
```

Egy 1 nap, 2 óra és 5 perc szerkesztési idővel rendelkező prezentáció esetén a jelentés a következő kimenetet mutatja.
```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

A [getRevisionNumber](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getRevisionNumber--) beolvas egy értéket, amelyet az alkalmazások a [setRevisionNumber](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setRevisionNumber-int-) segítségével módosíthatnak. A verziószám önmagában nem határozza meg, hányszor mentették a prezentációt, vagy nem építi fel annak verziótörténetét.

A [getTotalEditingTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTotalEditingTime--) beolvassa a fájlban rögzített szerkesztési időt. A `00:00:00` érték azt jelenti, hogy a tárolt idő nulla, még akkor is, ha valaki szerkesztette a prezentációt.

## **Beépített tulajdonságok módosítása**

A beépített metaadatok frissítéséhez használja a setter metódusokat azon objektumon, amelyet a [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--) ad vissza. Ez a példa egy meglévő prezentációt nyit meg, meghívja a [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), a [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), a [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), a [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), és a [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-) metódusokat, majd a [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) segítségével elmenti a frissített prezentációt. Az elmentett PPTX tartalmazza az új metaadatokat.
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

## **A hiperhivatkozás alapjának kezelése**

Az [IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) visszaadja a dokumentumszintű alapot a relatív hiperhivatkozásokhoz. A [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) segítségével módosítható vagy törölhető. Ez akkor hasznos, amikor egy prezentációt és a hozzá tartozó fájlokat más helyre mozgatunk. Ez különbözik egy egyedi hiperhivatkozás [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) metódusától: az alap megváltoztatása nem írja át a tárolt hivatkozáscímeket, és nem módosítja az abszolút célpontokat.

A példa egy olyan prezentációt igényel, amely tartalmaz relatív hivatkozást, például `target.html`, és abszolút hivatkozást, például `https://example.org/absolute.html`. Beolvassa a meglévő alapot, új alapcímre állítja, majd elmenti és újra megnyitja a prezentációt az érték ellenőrzéséhez. Ezután egy üres karakterlánccal törli az alapot, és egy külön elmentett fájlban ellenőrzi az üres értéket. Cserélje le a példában szereplő alapcímet a saját hivatkozott fájljainak helyére.
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

A két ellenőrző üzenetnek `true` értéket kell kiírnia. Az alap törlése nem érinti az egyes hiperhivatkozások címét.

Egy relatív hivatkozás a `target.pptx` fájlra `old/target.pptx`-t nyitott meg, amikor az alap az `old` mappára mutatott. Az alap `new` mappára való módosítása, a mentés és a prezentáció újranyitása után ugyanaz a hivatkozás a `new/target.pptx`-t nyitotta meg. Egy abszolút hivatkozás továbbra is ugyanazt a fájlt nyitotta. Tesztelje a relatív hivatkozásait a PowerPointban a prezentáció mozgatása vagy az alap módosítása előtt és után.

## **Egyedi prezentációs tulajdonságok hozzáadása**

Az egyedi tulajdonságok olyan metaadatokat tárolnak, amelyekhez nincs megfelelő beépített mező. Az [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) metódus lehetővé teszi egy érték hozzárendelését tulajdonságnév szerint. Ez a példa egy prezentációt hoz létre, két szöveges értéket és egy egész verzióértéket ad hozzá, majd a [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) segítségével elmenti a prezentációt. Egy meglévő névhez való érték hozzárendelése felülírja a tulajdonság korábbi értékét.
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

Ez a példa egy egyedi tulajdonságokat tartalmazó prezentációt nyit meg, és a [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) segítségével iterálja őket. A [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) nullártalapú indexet fogad, és visszaadja a [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) által használt nevet. A példa kiírja minden eredeti nevet és értéket, minden értéket egy számozott karakterláncra cserél, függetlenül annak eredeti típusától, majd menti a módosításokat. Ha nincsenek egyedi tulajdonságok, a ciklus nem végez változtatást.
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

Próbálja ki a [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) online alkalmazást, hogy lássa, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API-val:
[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, ezért nem távolíthatók el teljesen. Azonban módosíthatja az értéküket, vagy ha az adott tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha egy már létező egyedi tulajdonságot adok hozzá?**

Ha egy már létező egyedi tulajdonságot ad hozzá, a meglévő érték felül lesz írva az újjal. Nem kell előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Elérhetem a prezentáció tulajdonságait anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) és ezután a [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) metódusokat, hogy a tárolt dokumentum metaadatokat beolvassa anélkül, hogy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) példányt hozna létre. Lásd a [Build a Lightweight Presentation Inventory](/slides/hu/java/examine-presentation/) cikket egy teljes jelentési példa és formátumspecifikus korlátozásokért.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból a megnyitási jelszó nélkül?**

Igen. A prezentációnak akkor kell titkosítva lennie, ha a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) `false` értékkel lett meghívva, és a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) `true` értékkel történő hívás után lett betöltve.

**Frissíthetek egy titkosított PPTX fájlt csak dokumentumtulajdonságok módjában?**

Nem. A nyilvános és a titkosított tulajdonságok adatai összhangban kell legyenek, ezért a titkosított PPTX fájl frissítéséhez a teljes prezentációt a megfelelő megnyitási jelszóval kell betölteni.