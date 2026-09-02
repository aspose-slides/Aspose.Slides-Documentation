---
title: Prezentációs információk lekérése és frissítése Java-ban
linktitle: Prezentációs információk
type: docs
weight: 30
url: /hu/java/examine-presentation/
keywords:
- prezentáció formátuma
- prezentáció tulajdonságai
- dokumentum tulajdonságai
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok módosítása
- tulajdonságok szerkesztése
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel a diákat, a szerkezetet és a metaadatokat PowerPoint és OpenDocument prezentációkban Java használatával a gyorsabb betekintés és az intelligensebb tartalom-auditok érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet megvizsgálni a prezentációs információkat az Aspose.Slides-ban. Elmagyarázza, hogyan határozható meg egy prezentáció aktuális formátuma a teljes fájl betöltése nélkül, hogyan olvashatók el a dokumentum tulajdonságai, és hogyan frissíthetők azok szükség esetén.

A példák a [PresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationinfo/) és a [DocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/documentproperties/) API-kon alapulnak, és tipikus műveleteket mutatnak be a prezentáció metaadatainak kezelésére.

## **Ellenőrizze a bemutató formátumát**

Mielőtt dolgozna egy prezentáción, érdemes megtudni, hogy jelenleg milyen formátumban (PPT, PPTX, ODP és egyebek) van a bemutató.

A prezentáció formátuma betöltés nélkül ellenőrizhető. Íme egy Java példa:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **A bemutató tulajdonságainak lekérdezése**

Ez a Java kód megmutatja, hogyan lehet lekérdezni a prezentáció tulajdonságait (információk a bemutatóról):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Érdemes megtekinteni a [DocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/documentproperties/#DocumentProperties--) osztályban található tulajdonságokat.

## **A bemutató tulajdonságainak frissítése**

Az Aspose.Slides a [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) metódust kínálja, amely lehetővé teszi a prezentáció tulajdonságainak módosítását.

Tegyük fel, hogy van egy PowerPoint prezentációnk az alábbi dokumentumtulajdonságokkal.

![A PowerPoint bemutató eredeti dokumentumtulajdonságai](input_properties.png)

Ez a kódrészlet megmutatja, hogyan szerkeszthetünk néhány prezentáció tulajdonságot:

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

A dokumentumtulajdonságok módosításának eredménye alább látható.

![A PowerPoint bemutató módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

További információkért a prezentációról és annak biztonsági attribútumairól a következő linkek lehetnek hasznosak:

- [Password-Protect Presentations](/slides/hu/java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hu/java/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűtípusok be vannak-e ágyazva, és melyek azok?**

Keresse a [embedded-font információkat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) a prezentáció szintjén, majd hasonlítsa össze ezeket a bejegyzéseket a [valóban használt betűtípusok](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsmanager/#getFonts--) halmazával, hogy azonosítsa, mely betűtípusok kritikusak a rendereléshez.

**Hogyan tudom gyorsan megállapítani, hogy a fájl tartalmaz rejtett diákat, és ha igen, hányat?**

Iteráljon a [slide collection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidecollection/) elemein, és ellenőrizze minden dia [visibility flag](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slide/#getHidden--) értékét.

**Felismerhetem-e, hogy egyéni diaméret és tájolás van-e használatban, és eltérnek-e az alapértelmezettektől?**

Igen. Hasonlítsa össze a jelenlegi [slide size](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSlideSize--) és tájolás értékét a szabványos előbeállításokkal; ez segít előre jelezni a nyomtatási és export viselkedését.

**Van-e gyors módja annak, hogy lássam, a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Járja be az összes [chart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chart/) elemet, ellenőrizze a [data source](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getDataSourceType--) típusát, és jegyezze fel, hogy az adat belső vagy link alapú, beleértve a törött hivatkozásokat is.

**Hogyan tudom felmérni a 'nehéz' diákat, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Minden diánál számolja meg az objektumok számát, és keressen nagy képeket, átlátszóságot, árnyékokat, animációkat, valamint multimédiát; adjon hozzá egy durva összetettségi pontszámot, hogy jelölje a potenciális teljesítményproblémákat.