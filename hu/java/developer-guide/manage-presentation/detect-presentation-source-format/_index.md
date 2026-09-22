---
title: Az eredeti bemutatóformátum meghatározása Java-ban
linktitle: Forrásformátum
type: docs
weight: 35
url: /hu/java/detect-presentation-source-format/
keywords:
- forrásformátum
- bemutató formátum felismerése
- PowerPoint
- OpenDocument
- bemutató
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Olvassa el egy betöltött bemutató eredeti formátumát Java-ban az Aspose.Slides for Java segítségével, hasonlítsa össze a detektálási API-kat, és kezelje a fájlokat, adatfolyamokat és a régi formátumokat."
---
## **Áttekintés**

A bemutató betöltése után hívja meg a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSourceFormat--) metódust, hogy meghatározza az eredeti formátumát. A metódus a [IPresentation.getSourceFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getSourceFormat--) felületen is elérhető. Használja, ha a további feldolgozás a jelenlegi példány betöltéséhez használt formátumtól függ.

A forrásformátum különbözik a kimeneti fájlhoz kiválasztott [SaveFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) formátumtól. Egy másik formátumba mentés nem változtatja meg a meglévő példány forrásformátumát.

## **Fájl forrásformátumának olvasása**

Ez a példa egy meglévő `sample.pptx` fájlt igényel. Betölti a fájlt, és a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSourceFormat--) segítségével választja ki az alkalmazás feldolgozási szabályát a fájlnév helyett. A bemeneti útvonalat megváltoztatva más formátumokat is kipróbálhat. A példa kiírja a kiválasztott szabályt; cserélje ki az üzeneteket saját alkalmazáslogikájára.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Támogatott értékek felismerése**

A [SourceFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sourceformat/) osztály egész számú konstansokat határoz meg, amelyek a következő bemutatóformátumokat különböztetik meg. Az alábbi kiterjesztések konvencionálisak, nem a tényleges eredeti fájlnévről szólnak.

| SourceFormat érték | Kiterjesztés | Formátum |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 bemutató |
| `Pptx` | `.pptx` | Office Open XML bemutató |
| `Pptm` | `.pptm` | Makrókkal ellátott Office Open XML bemutató |
| `Pps` | `.pps` | PowerPoint 97–2003 diavetítés |
| `Ppsx` | `.ppsx` | Office Open XML diavetítés |
| `Ppsm` | `.ppsm` | Makrókkal ellátott Office Open XML diavetítés |
| `Pot` | `.pot` | PowerPoint 97–2003 sablon |
| `Potx` | `.potx` | Office Open XML sablon |
| `Potm` | `.potm` | Makrókkal ellátott Office Open XML sablon |
| `Odp` | `.odp` | OpenDocument bemutató |
| `Otp` | `.otp` | OpenDocument bemutatósablon |
| `Fodp` | `.fodp` | Flat XML ODF bemutató |
| `Xml` | `.xml` | PowerPoint XML bemutató |

## **Forrásformátum olvasása egy adatfolyamból**

Ez a példa egy meglévő `sample.pps` fájlt igényel. A fájl bájtjainak memóriában lévő adatfolyamba olvasása azt a helyzetet modellezi, amikor a bemenet fájlnév nélkül érkezik, például adatbázisérték vagy feltöltött bájt tömb formájában. A [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) konstruktor csak az adatfolyamot kapja.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

A PPT, PPS és POT ugyanazt a bináris formátumot használja. Fájl útvonallal történő betöltés esetén a kiterjesztés segíthet megkülönböztetni a diavetítést vagy sablont. Fájlnév nélkül a régi PPS és POT tartalom `SourceFormat.Ppt`‑ként jelenhet meg; a fenti PPS példa kiírja a `SourceFormat.Ppt` egész értékét.

Ha az alkalmazásnak meg kell őriznie a különbséget, tartsa meg az eredeti fájlnevet vagy a részletmetaadatot külön. A kiterjesztés hasznos útmutató lehet ezeknél a régi altípusoknál, de nem szabad kizárólag erre alapozni a tetszőleges bemutatótartalom azonosítását.

## **Detektálás összehasonlítása betöltés előtt és után**

Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) és a [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) metódusokat, ha egy fájlt kell megvizsgálnia a teljes bemutatóobjektum modell betöltése előtt. Használja a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSourceFormat--) metódust, ha a példány már létezik.

Ez a példa `sample.pptx`‑et igényel, és kiírja a `LoadFormat.Pptx` illetve a `SourceFormat.Pptx` egész értékeit. Éles környezetben válassza a feldolgozási szakasznak megfelelő API‑t; egy már betöltött bemutató nem igényel második vizsgálatot csak a forrásformátum lekérdezéséhez.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Az eredmények különböző osztályok konstansaiból származnak: [LoadFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadformat/) és [SourceFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sourceformat/). Ne hasonlítsa össze a numerikus értékeiket, és ne feltételezze, hogy minden formátumnak azonos a detektálási eredménye. A PowerPoint XML betöltés előtt `LoadFormat.Unknown`, betöltés után pedig `SourceFormat.Xml`‑ként jelentkezhet.

## **Forrás- és kimeneti formátumok külön tartása**

Ez a példa `sample.pptx`‑et igényel, és `converted.odp`‑t ír ki. Kiírja a `SourceFormat.Pptx` egész értékét a mentés előtt és után is. Csak az ODP kimenetből újra betöltött példány jelenti `Odp`‑ként.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Az `new Presentation()`‑el nulláról létrehozott bemutató `SourceFormat.Pptx`‑ként jelentkezik. Nincs bemeneti fájl: ez az újonnan létrehozott példány alapértelmezett értéke, nem bizonyítja, hogy PPTX fájlt töltött be. Kövesse nyomon, hogy az alkalmazás létrehozta‑e vagy betöltötte‑e a példányt, ha ez a különbség számít.

## **Forrásformátum leképezése kiterjesztésre**

Ez a példa `sample.pptx`‑et igényel. Minden jelenleg támogatott [SourceFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/sourceformat/) értéket leképez egy konvencionális kiterjesztésre, a bemeneti fájlnév elemzése nélkül. A tartalék megoldás megakadályozza, hogy egy fel nem ismert értékhez automatikusan kiterjesztést rendeljünk.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Ez a leképezés nem konvertál fájlt, és nem állítja helyre a folyamatos betöltés során elveszett régi PPS/POT altípusokat. A tényleges mentéshez adja meg explicit módon a [SaveFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/)‑t, vagy használja a [Save Presentations in Their Original Format](/slides/hu/java/save-presentation/#save-presentations-in-their-original-format) példában bemutatott konverziót.

## **Formátumok ellenőrzése mentéssel és újranyitással**

Ez az önálló példa egy bemutatót hoz létre, és három fájlt ír a munkakönyvtárba, felülírva az azonos nevű fájlokat. Minden kimenetet újból megnyit mind útvonallal, mind memóriában lévő adatfolyammal. PPTX‑nél és ODP‑nél mindkét út jelenték a mentett formátumot. PPS‑nél a fájl útvonallal történő betöltés `Pps`‑t jelent, míg a fájlnév nélküli bájtok betöltése `Ppt`‑t.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Az alábbi táblázat összegzi a forrásformátum azonosítását a megfelelő kiterjesztésű bemutatókra. A nevek konstansokat jelölnek; a Java példák azok egész értékét írják ki:

| Mentett formátum | SourceFormat fájl útvonalból | SourceFormat névtelen adatfolyamból |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` megfelelően | Ugyanaz, mint fájl útvonal |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` megfelelően | Ugyanaz, mint fájl útvonal |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` megfelelően | Ugyanaz, mint fájl útvonal |
| ODP, OTP | `Odp`, `Otp` megfelelően | Ugyanaz, mint fájl útvonal |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

A PPS/POT tartalom névtelen adatfolyamban `Ppt`‑ként azonosítható. A táblázat a formátum azonosítását írja le, nem a minden bemutató tulajdonságának megőrzését a konverzió során.

## **GYIK**

**Megváltozik-e a forrásformátum, ha egy PPTX‑ből betöltött bemutatót ODP‑ként mentjük?**

Nem. A meglévő példány továbbra is `Pptx`‑ként jelentkezik. Az ODP‑ból betöltött példány `Odp`‑ként jelentkezik.

**Egy adatfolyam mindig meg tudja különböztetni a régi bemutatót, diavetítést és sablont?**

Nem. A PPT, PPS és POT ugyanazt a bináris formátumot használja. Ha ez a megkülönböztetés szükséges, tartsa meg a fájlnevet vagy a részletmetaadatot külön.

**Melyik API‑t használjam, ha a bemutató már be van töltve?**

Olvassa el a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSourceFormat--) metódust. Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)‑t a betöltés előtti vizsgálathoz.