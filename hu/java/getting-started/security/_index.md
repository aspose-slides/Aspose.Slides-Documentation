---
title: Biztonság
type: docs
weight: 160
url: /hu/java/security/
keywords:
- biztonság
- függőségek
- harmadik féltől származó komponensek
- Maven
- JAR aláírás
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tekintse át, hogyan dolgozza fel az Aspose.Slides for Java a prezentációkat, mit ad hozzá a projekt függőségeihez, hogyan ellenőrizhető a JAR fájl, és mely harmadik féltől származó komponenseket tartalmaz."
---
## **Bevezetés**

Ez a cikk összegyűjti azokat az információkat, amelyekre egy biztonsági felülvizsgálat során szükség van egy, az Aspose.Slides for Java‑t használó alkalmazás esetén: hogyan dolgozza fel a könyvtár a prezentációkat, mit ad hozzá a projekt függőségeihez, hogyan ellenőrizhető, hogy a JAR fájl az Aspose‑tól származik, és mely harmadik féltől származó komponenseket tartalmaz a JAR fájl.

## **Biztonság az Aspose.Slides‑ben**

Az Aspose a legjobb gyakorlatokat alkalmazza termékei fejlesztése során.

* Az Aspose.Slides for Java prezentációk létrehozására, módosítására és átalakítására szolgál. Nem futtat szkripteket a prezentációkban. Az Aspose.Slides elemezze a prezentáció szerkezetét, és lehetővé teszi, hogy a kódja az objektummodellel dolgozzon.
* Az Aspose.Slides egy olyan könyvtárként működik, amely dokumentumokat elemez és értelmez anélkül, hogy távoli kódot hajtana végre. Az összes Aspose termék a saját gépén fut. Nem továbbít adatokat az Aspose felé. Az egyetlen kivétel a [metered licensing](/slides/hu/java/metered-licensing/): ha ezt használja, csak az API‑használati adatai kerülnek feldolgozásra.
* Az Aspose komponensek ugyanabban a felhasználói kontextusban futnak, mint a szokásos alkalmazások. Ezért az Aspose komponensek nem jelentenek kockázatot a kritikus rendszererőforrásokra. Továbbá, amikor egy Aspose komponens dokumentumot nyit meg, a makrók nem futnak automatikusan.

## **Maven függőségek**

Az Aspose.Slides for Java Maven‑artifaktuma, `com.aspose:aspose-slides`, nem deklarál függőségeket: a POM‑fájlja csak az artifakt saját koordinátáit tartalmazza. Ha egy projektbe felveszi, a Maven csak ezt az egy JAR fájlt adja hozzá, semmi mást. Az összes artifakt felsorolásához, amelyet a projekt felold, beleértve a transzitív függőségeket, futtassa az alábbi parancsot a projekt mappájában:

```bash
mvn dependency:tree
```

A [Installation](/slides/hu/java/installation/) példában a kimenet csak az Aspose.Slides‑t mutatja függőségként:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **A JAR fájl ellenőrzése**

Az Aspose aláírja a JAR fájlt. Az aláírás ellenőrzéséhez futtassa a JDK‑ból a `jarsigner` eszközt abban a mappában, ahol a JAR fájl található:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

A parancs `jar verified.` üzenetet ír ki, ha az aláírás érvényes és egyetlen bejegyzés sem változott a fájl aláírása óta. Ez az üzenet nem tartalmazza a aláíró nevét. Annak megerősítéséhez, hogy az Aspose írta alá a fájlt, adja meg a `-verbose` és `-certs` kapcsolókat, és ellenőrizze, hogy a feladó tanúsítványa a `CN=ASPOSE PTY LTD` névre szól. Amikor a Maven letölti a JAR fájlt, ellenőrzi a repository által a fájl mellett közzétett SHA‑1 ellenőrző összeget is.

## **Harmadik féltől származó komponensek**

Az Aspose.Slides for Java harmadik féltől származó komponensekből származó kódot és adatot tartalmaz. Ezek a JAR fájl részei, nem különálló Maven artifaktok, ezért a `mvn dependency:tree` és más, Maven‑függőségeket olvasó eszközök nem sorolják fel őket. A JAR fájl a *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf* értesítést tartalmazza, amely felsorolja a komponenseket és azok licencét:

| Component | License stated in the notice |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | MIT‑style license |
| Mono | MIT license; some parts under other licenses that the notice lists |
| RSWOP.ICM color profile | Microsoft license terms |
| sRGB_v4_ICC_preference.icc color profile | ICC permission to use, copy, and distribute the unchanged file |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

Az értesítés kinyeréséhez a JAR fájlból futtassa a JDK‑ból a `jar` eszközt abban a mappában, ahol a JAR fájl található:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **GYIK**

**Használ-e az Aspose.Slides for Java külső csomagokat?**

Nincsenek Maven‑függőségei, ahogyan a [Maven Dependencies](#maven-dependencies) mutatja, de tartalmazza a [Third-Party Components](#third-party-components) részben felsorolt harmadik féltől származó komponenseket. A JAR fájlt és ezeket a komponenseket egyaránt vegye bele a biztonsági felülvizsgálatba.

**Szükség van-e hálózati kapcsolatra az Aspose.Slides for Java‑nál?**

Nem. A prezentációk létrehozása, mentése és renderelése hálózati kapcsolat nélkül működik. Az egyetlen adatot küldő funkció a [metered licensing](/slides/hu/java/metered-licensing/), amely az API‑használatot jelenti.

**Tartalmaz-e az Aspose.Slides for Java natív kódot?**

Nem. A JAR fájl csak Java osztályokat és erőforrásokat tartalmaz, ezért nem ad hozzá natív könyvtárakat az alkalmazásához. Linuxon a Java runtime betűtámogatásához a fontconfig könyvtárra és az operációs rendszer betűkészleteire van szükség; lásd a [System Requirements](/slides/hu/java/system-requirements/#linux) oldalt.