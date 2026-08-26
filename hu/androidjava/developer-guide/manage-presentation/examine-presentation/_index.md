---
title: Androidon bemutató információk lekérése és frissítése
linktitle: Bemutató információk
type: docs
weight: 30
url: /hu/androidjava/examine-presentation/
keywords:
- bemutató formátum
- bemutató tulajdonságok
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
- bemutató
- Android
- Java
- Aspose.Slides
description: "Fedezze fel a diák, a szerkezet és a metaadatok részleteit PowerPoint és OpenDocument bemutatókban Java használatával, a gyorsabb betekintés és az okosabb tartalom-ellenőrzés érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet megvizsgálni a bemutató információit az Aspose.Slides-ban. Ismerteti, hogyan lehet meghatározni egy bemutató aktuális formátumát a teljes fájl betöltése nélkül, kiolvasni a dokumentum tulajdonságait, és szükség esetén frissíteni azokat.

A példák a [PresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationinfo/) és a [DocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/documentproperties/) API-kon alapulnak, és bemutatják a bemutató metaadatok kezelésének tipikus műveleteit.

## **Egy bemutató formátumának ellenőrzése**

Mielőtt egy bemutatóval dolgozna, érdemes megtudni, milyen formátumban (PPT, PPTX, ODP és egyéb) van a bemutató jelenleg.

Ellenőrizheti a bemutató formátumát a bemutató betöltése nélkül. Lásd ezt a Java kódot:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Bemutató tulajdonságok lekérése**

Ez a Java kód bemutatja, hogyan lehet lekérni a bemutató tulajdonságait (információk a bemutatóról):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

Érdemes megtekinteni a [a DocumentProperties alatti tulajdonságok](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) osztályt.

## **Bemutató tulajdonságok frissítése**

Az Aspose.Slides biztosítja a [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) metódust, amely lehetővé teszi a bemutató tulajdonságainak módosítását.

Tegyük fel, hogy van egy PowerPoint bemutató a lenti dokumentumtulajdonságokkal.

![Eredeti dokumentumtulajdonságok a PowerPoint bemutatóban](input_properties.png)

Ez a kódpélda bemutatja, hogyan lehet szerkeszteni bizonyos bemutató tulajdonságokat:

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

![Módosított dokumentumtulajdonságok a PowerPoint bemutatóban](output_properties.png)

## **Hasznos hivatkozások**

További információkért a bemutatóról és annak biztonsági attribútumairól, az alábbi hivatkozások lehetnek hasznosak:

- [Jelszóval védett prezentációk](/slides/hu/androidjava/password-protected-presentation/)
- [Írásvédett prezentációk](/slides/hu/androidjava/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűtípusok be vannak ágyazva, és melyek azok?**

Keresse a [beágyazott betűtípus információ](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) információkat a bemutató szintjén, majd hasonlítsa össze ezeket a bejegyzéseket a [valóban használt betűtípusok](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsmanager/#getFonts--) halmazával, hogy meghatározza, mely betűtípusok kritikusak a megjelenítéshez.

**Hogyan tudom gyorsan megállapítani, hogy a fájl tartalmaz rejtett dia-okat, és ha igen, hány darabot?**

Iteráljon a [slide collection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidecollection/) gyűjteményen, és ellenőrizze minden dia [visibility flag](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slide/#getHidden--) jelzőjét.

**Meg tudom-e határozni, hogy egyedi diaméret és tájolás van-e használatban, és eltérnek-e az alapértelmezettektől?**

Igen. Hasonlítsa össze a jelenlegi [slide size](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSlideSize--) és tájolást a standard előre beállítottakkal; ez segít előre jelezni a nyomtatás és export viselkedését.

**Van gyors módja annak, hogy lássam, a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Járja be az összes [charts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chart/) elemet, ellenőrizze a [data source](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) adatforrást, és vegye figyelembe, hogy az adat belső vagy hivatkozás‑alapú, beleértve a hibás hivatkozásokat is.

**Hogyan értékelhetem a 'nehéz' diákokat, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Minden dia esetén számolja meg az objektumok mennyiségét, és keressen nagy képeket, átlátszóságot, árnyékokat, animációkat és multimédiát; adjon hozzá egy durva komplexitási pontszámot, hogy jelölje a lehetséges teljesítménybeli szűk keresztmetszeteket.