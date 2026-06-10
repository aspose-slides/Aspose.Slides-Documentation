---
title: Prezentációs információk lekérése és frissítése Java-ban
linktitle: Prezentációs információk
type: docs
weight: 30
url: /hu/java/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentum tulajdonságok
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
description: "Fedezze fel a diák, a szerkezet és a metaadatok kezelését PowerPoint és OpenDocument prezentációkban Java segítségével a gyorsabb betekintés és az okosabb tartalomelemzés érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet ellenőrizni a prezentáció adatait az Aspose.Slides-ban. Ismerteti, hogyan lehet meghatározni egy prezentáció aktuális formátumát a teljes fájl betöltése nélkül, elolvasni a dokumentum tulajdonságait, és szükség esetén frissíteni ezeket a tulajdonságokat.

Az példák a [PresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationinfo/) és a [DocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/documentproperties/) API-ken alapulnak, és tipikus műveleteket mutatnak be a prezentáció metaadataival való munkához.

## **Egy prezentáció formátumának ellenőrzése**

Mielőtt dolgozna egy prezentáción, esetleg szeretné megtudni, milyen formátumban (PPT, PPTX, ODP és egyebek) van a prezentáció jelenleg.

Ellenőrizheti egy prezentáció formátumát a prezentáció betöltése nélkül. Lássa ezt a Java kódot:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Prezentáció tulajdonságok lekérése**

Ez a Java kód megmutatja, hogyan lehet lekérni a prezentáció tulajdonságait (információk a prezentációról):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ...
```

Érdemes megtekinteni a [DocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/documentproperties/#DocumentProperties--) osztály alatti tulajdonságokat.

## **Prezentáció tulajdonságok frissítése**

Aspose.Slides biztosítja a [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) metódust, amely lehetővé teszi a prezentáció tulajdonságainak módosítását.

Tegyük fel, hogy van egy PowerPoint prezentáció, amelynek a dokumentumtulajdonságai alább láthatók.

![A PowerPoint prezentáció eredeti dokumentumtulajdonságai](input_properties.png)

Ez a kódpélda megmutatja, hogyan lehet szerkeszteni néhány prezentáció tulajdonságot:

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

A dokumentumtulajdonságok módosításának eredményei alább láthatók.

![A PowerPoint prezentáció módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

További információkért egy prezentációról és annak biztonsági attribútumairól, ezek a hivatkozások lehetnek hasznosak:

- [A prezentáció titkosított-e ellenőrzése](https://docs.aspose.com/slides/hu/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [A prezentáció írásvédett (csak‑olvasás) állapotának ellenőrzése](https://docs.aspose.com/slides/hu/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [A prezentáció jelszóval védett-e betöltés előtt](https://docs.aspose.com/slides/hu/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [A prezentáció védelmére használt jelszó megerősítése](https://docs.aspose.com/slides/hu/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűkészletek be vannak-e ágyazva, és melyek azok?**

Keresse a [beágyazott betűkészlet információkat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) a prezentáció szintjén, majd hasonlítsa össze ezeket a [valóban a tartalommal használt betűkészletek](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsmanager/#getFonts--) halmazával, hogy azonosítsa, mely betűkészletek kritikusak a rendereléshez.

**Hogyan tudom gyorsan megállapítani, hogy a fájl rejtett diákot tartalmaz-e, és hány darab van belőlük?**

Iteráljon a [diakollekción](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidecollection/), és ellenőrizze minden dia [láthatósági jelzőjét](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slide/#getHidden--).

**Felderíthetem‑e, hogy egyedi dia méret és orientáció van‑e használatban, és eltérnek‑e az alapértelmezettektől?**

Igen. Hasonlítsa össze a jelenlegi [dia méretet](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSlideSize--) és orientációt a szabványos előbeállításokkal; ez segít előre jelezni a nyomtatás és az export viselkedését.

**Van gyors módja annak, hogy lássam, a diagramok külső adatforrásokra hivatkoznak‑e?**

Igen. Járja be az összes [diagramot](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chart/), ellenőrizze azok [adatforrását](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getDataSourceType--), és jegyezze fel, hogy az adat belső vagy link‑alapú, beleértve a törött hivatkozásokat is.

**Hogyan tudom felmérni a 'nehéz' diákot, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Minden diára számolja meg az objektumok mennyiségét, és keresse a nagy képeket, átlátszóságot, árnyékokat, animációkat és multimédiát; adjon hozzá egy durva komplexitási pontszámot a lehetséges teljesítmény‑szűk keresztülök jelzésére.