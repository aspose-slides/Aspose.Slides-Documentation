---
title: "Prezentáció információk lekérése és frissítése Androidon"
linktitle: "Prezentáció információk"
type: docs
weight: 30
url: /hu/androidjava/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentumtulajdonságok
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
- Android
- Java
- Aspose.Slides
description: "Fedezze fel a diák, a szerkezet és a metaadatok a PowerPoint és OpenDocument prezentációkban Java használatával, a gyorsabb betekintés és az intelligensebb tartalom-ellenőrzés érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan ellenőrizhetők a prezentációs információk az Aspose.Slides-ban. Ismerteti, hogyan határozható meg egy prezentáció aktuális formátuma a teljes fájl betöltése nélkül, hogyan olvashatók a dokumentum tulajdonságai, és hogyan frissíthetők ezek a tulajdonságok szükség esetén.

A példák a [PresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationinfo/) és a [DocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/documentproperties/) API-kon alapulnak, és tipikus műveleteket mutatnak be a prezentáció metaadataival való munka során.

## **Ellenőrizze a prezentáció formátumát**

Mielőtt a prezentációval dolgozna, előfordulhat, hogy szeretné megtudni, milyen formátumban (PPT, PPTX, ODP és egyéb) van a prezentáció jelenleg.

A prezentáció formátumát betöltés nélkül is ellenőrizheti. Tekintse meg ezt a Java kódot:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **A prezentáció tulajdonságainak lekérése**

Ez a Java kód bemutatja, hogyan lehet lekérni a prezentáció tulajdonságait (információk a prezentációról):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ...
```

Érdekelheti a [DocumentProperties osztályban található tulajdonságok](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) listája.

## **A prezentáció tulajdonságainak frissítése**

Az Aspose.Slides biztosítja a [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) metódust, amely lehetővé teszi a prezentáció tulajdonságainak módosítását.

Tegyük fel, hogy van egy PowerPoint prezentáció, amelynek dokumentumtulajdonságai az alább láthatók.

![A PowerPoint prezentáció eredeti dokumentumtulajdonságai](input_properties.png)

Ez a kódrészlet bemutatja, hogyan szerkeszthet néhány prezentációs tulajdonságot:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

A dokumentumtulajdonságok módosításának eredményei az alább láthatók.

![A PowerPoint prezentáció módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

A prezentációval és annak biztonsági attribútumaival kapcsolatos további információkért hasznosak lehetnek ezek a hivatkozások:

- [Ellenőrzés, hogy a prezentáció titkosított-e](https://docs.aspose.com/slides/hu/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Ellenőrzés, hogy a prezentáció írásvédett (csak olvasható)](https://docs.aspose.com/slides/hu/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Ellenőrzés, hogy a prezentáció jelszóval védett-e a betöltés előtt](https://docs.aspose.com/slides/hu/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [A prezentáció védésére használt jelszó megerősítése](https://docs.aspose.com/slides/hu/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűkészletek be vannak-e ágyazva, és melyek azok?**  
Keresse meg a [beágyazott betűkészletek információját](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) a prezentáció szintjén, majd hasonlítsa össze ezeket a [ténylegesen a tartalomban használt betűkészletekkel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsmanager/#getFonts--) annak érdekében, hogy azonosítsa, mely betűkészletek kritikusak a megjelenítéshez.

**Hogyan tudom gyorsan megállapítani, hogy a fájl rejtett diákot tartalmaz-e, és ha igen, hány darabot?**  
Iteráljon a [dia gyűjteményen](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidecollection/) és ellenőrizze minden dia [láthatósági jelzőjét](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slide/#getHidden--).

**Felismerhető-e, hogy egyedi dia méret és tájolás van-e használatban, és eltérnek-e az alapértelmezettektől?**  
Igen. Hasonlítsa össze a jelenlegi [dia méretet](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSlideSize--) és tájolást a szabványos előbeállításokkal; ez segít előre jelezni a nyomtatási és exportálási viselkedést.

**Van gyors módja annak, hogy megállapítsam, a diagramok külső adatforrásokra hivatkoznak-e?**  
Igen. Járja be az összes [diagramot](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chart/), ellenőrizze azok [adatforrását](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getDataSourceType--), és vegye észre, hogy az adat belső vagy hivatkozáson alapul-e, beleértve a hibás hivatkozásokat is.

**Hogyan értékelhetem a 'nehéz' diákokat, amelyek lassíthatják a renderelést vagy a PDF exportot?**  
Minden diánál számolja meg az objektumok darabszámát, és keressen nagy képeket, átlátszóságot, árnyékokat, animációkat és multimédiát; adjon hozzá egy durva komplexitási pontszámot, hogy jelölje a lehetséges teljesítménybeli problémákat.