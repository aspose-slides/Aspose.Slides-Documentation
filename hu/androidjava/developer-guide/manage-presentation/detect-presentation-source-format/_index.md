---
title: "Az eredeti prezentáció formátumának meghatározása Androidon"
linktitle: "Forrásformátum"
type: docs
weight: 35
url: /hu/androidjava/detect-presentation-source-format/
keywords:
- "forrásformátum"
- "prezentáció formátumának felismerése"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "PPT"
- "PPTX"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Olvassa el egy betöltött prezentáció eredeti formátumát Androidon az Aspose.Slides for Android Java segítségével, hasonlítsa össze a detektálási API‑kat, és kezelje a fájlokat, adatfolyamokat és régi formátumokat."
---
## **Áttekintés**

Prezentáció betöltése után hívd meg a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSourceFormat--) metódust, hogy meghatározd annak eredeti formátumát. A metódus elérhető az [IPresentation.getSourceFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) útján is. Használd, ha a további feldolgozás a jelenlegi példány betöltési formátumától függ.

A forrásformátum különbözik a kimeneti fájlhoz kiválasztott [SaveFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/) formátumtól. Egy másik formátumba mentés nem változtatja meg a meglévő példány forrásformátumát.

A példák Java-t és fájlútvonalakat használnak. Androidon cseréld le a minta útvonalakat az alkalmazás által elérhető tároló útvonalakra, például az alkalmazás belső fájlkönyvtárára.

## **A fájl forrásformátumának olvasása**

Ez a példa egy meglévő `sample.pptx` fájlt igényel. A fájlt betölti, és az alkalmazásfeldolgozási politikát a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSourceFormat--) használatával választja ki, a fájlnév helyett. Módosítsd a bemeneti útvonalat más formátumok kipróbálásához. A példa kiírja a kiválasztott politikát; cseréld le az üzeneteket saját alkalmazáslogikádra.

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

## **A támogatott értékek felismerése**

A [SourceFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sourceformat/) osztály egész számú konstansokat definiál, amelyek megkülönböztetik a következő prezentációformátumokat. Az alábbi kiterjesztések hagyományosak, nem az eredeti fájlnév visszaállítása.

| SourceFormat érték | Kiterjesztés | Formátum |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 prezentáció |
| `Pptx` | `.pptx` | Office Open XML prezentáció |
| `Pptm` | `.pptm` | Makrókkal kibővített Office Open XML prezentáció |
| `Pps` | `.pps` | PowerPoint 97–2003 diavetítés |
| `Ppsx` | `.ppsx` | Office Open XML diavetítés |
| `Ppsm` | `.ppsm` | Makrókkal kibővített Office Open XML diavetítés |
| `Pot` | `.pot` | PowerPoint 97–2003 sablon |
| `Potx` | `.potx` | Office Open XML sablon |
| `Potm` | `.potm` | Makrókkal kibővített Office Open XML sablon |
| `Odp` | `.odp` | OpenDocument prezentáció |
| `Otp` | `.otp` | OpenDocument prezentációs sablon |
| `Fodp` | `.fodp` | Flat XML ODF prezentáció |
| `Xml` | `.xml` | PowerPoint XML prezentáció |

## **A forrásformátum olvasása adatfolyamból**

Ez a példa egy meglévő `sample.pps` fájlt igényel. A bájtok memóriás adatfolyamba olvasása olyan bemenetet modellez, amely fájlnév nélkül érkezik, például adatbázis értéket vagy feltöltött byte tömböt. A [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) konstruktor csak az adatfolyamot kapja.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
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

A PPT, PPS és POT ugyanazt az alapvető bináris formátumot használja. Fájlúton történő betöltéskor a kiterjesztés segíthet megkülönböztetni a diavetítést vagy a sablont. Fájlnév nélkül a régi PPS és POT tartalom `SourceFormat.Ppt`‑ként jelenthető; a fenti PPS példa kiírja a `SourceFormat.Ppt` egész számú értékét.

Ha az alkalmazásodnak meg kell őrizni a különbséget, tartsd meg az eredeti fájlnevet vagy az al‑típus metaadatot külön. A kiterjesztés hasznos útmutató ezekhez a régi al‑típusokhoz, de nem lehet egyetlen alapja a tetszőleges prezentációtartalom azonosításának.

## **Az észlelés összehasonlítása betöltés előtt és után**

Használd a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) és az [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) metódusokat, ha egy fájlt a teljes prezentációs objektummodell betöltése előtt kell megvizsgálnod. Használd a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSourceFormat--) metódust, ha a példány már létezik.

Ez a példa `sample.pptx`‑t igényel, és kiírja a `LoadFormat.Pptx` és `SourceFormat.Pptx` egész számú értékeit. Éles környezetben válaszd ki a feldolgozási szakaszodnak megfelelő API‑t; egy már betöltött prezentációnak nincs szüksége egy második vizsgálatra csak a forrásformátum lekérésére.

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

Az eredmények különböző osztályok konstansait használják: a [LoadFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadformat/) és a [SourceFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sourceformat/). Ne hasonlítsd össze a numerikus értékeiket, és ne feltételezd, hogy minden formátum azonos észlelési eredményt ad. A PowerPoint XML betöltés előtt `LoadFormat.Unknown`‑ként, betöltés után `SourceFormat.Xml`‑ként jelenthető.

## **A forrás- és kimeneti formátumok külön tartása**

Ez a példa `sample.pptx`‑t igényel, és `converted.odp`‑t ír. Kiírja a `SourceFormat.Pptx` egész számú értékét a mentés előtti és utáni állapotban is. Csak az ODP kimenetből betöltött új példány jelent `Odp`‑t.

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

Egy `new Presentation()`‑val nulláról létrehozott prezentáció `SourceFormat.Pptx`‑t jelent. Nincs bemeneti fájlja: ez az újonnan létrehozott példány alapértelmezett értéke, nem bizonyíték arra, hogy PPTX fájlt töltöttek be. Kövesd nyomon, hogy az alkalmazásod létrehozta vagy betöltötte a példányt, ha ez a különbség számít.

## **Forrásformátum leképezése kiterjesztésre**

A következő példa `sample.pptx`‑t igényel. Minden jelenleg támogatott [SourceFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/sourceformat/) értéket leképez egy hagyományos kiterjesztésre, a bemeneti fájlnév elemzése nélkül. A tartalék elkerüli, hogy egy fel nem ismert értékhez csendben kiterjesztést rendeljünk.

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

Ez a leképezés nem konvertál fájlt, és nem állítja vissza a stream betöltése során elveszett régi PPS/POT al‑típust. A tényleges mentéshez válassz explicit [SaveFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/)‑ot, vagy használd a [Save Presentations in Their Original Format](/slides/hu/androidjava/save-presentation/#save-presentations-in-their-original-format) példában látható konverziót.

## **Formátumok ellenőrzése mentéssel és újratöltéssel**

Ez az önálló példa egy prezentációt hoz létre, és három fájlt ír a munkakönyvtárba, felülírva az azonos nevű fájlokat. Mindegyik kimenetet újra megnyitja útvonal alapján és memóriás adatfolyamon keresztül is. PPTX és ODP esetén mindkét útvonal a mentett formátumot jelenti. PPS esetén a fájlúton történő betöltés `Pps`‑t jelent, míg a név nélküli adatfolyam betöltése `Ppt`‑t.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
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

Az alábbi táblázat összefoglalja a forrásformátum azonosítását a megfelelő kiterjesztésű prezentációk esetén. A nevek konstansokat jelölnek; a Java példák kiírják azok egész számú értékét:

| Mentett formátum | SourceFormat fájlúton | SourceFormat névtelen adatfolyamból |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Ugyanaz, mint a fájl útvonala |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Ugyanaz, mint a fájl útvonala |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Ugyanaz, mint a fájl útvonala |
| ODP, OTP | `Odp`, `Otp` respectively | Ugyanaz, mint a fájl útvonala |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

A PPS/POT tartalom névtelen adatfolyamok esetén `Ppt`‑ként azonosítható. A táblázat a formátumazonosítást írja le, nem minden prezentációs funkció megőrzését a konverzió során.

## **GYIK**

**A PPTX‑ből betöltött prezentáció ODP‑be mentése megváltoztatja a forrásformátumot?**

Nem. A meglévő példány továbbra is `Pptx`‑et jelent. A mentett ODP fájlból betöltött példány `Odp`‑t jelent.

**Egy adatfolyam mindig meg tudja különböztetni a régi prezentációt, diavetítést és sablont?**

Nem. A PPT, PPS és POT ugyanazt a bináris formátumot használja. Ha a különbség fontos, tartsd meg a fájlnevet vagy az al‑típus metaadatát külön.

**Melyik API‑t kell használni, ha a prezentáció már betöltődött?**

Olvasd a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSourceFormat--) metódust. Használd a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)‑t az betöltés előtti vizsgálathoz.