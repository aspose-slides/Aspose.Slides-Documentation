---
title: PowerPoint-prezentációk XML-re konvertálása Androidon
linktitle: PowerPoint XML-re
type: docs
weight: 145
url: /hu/androidjava/convert-powerpoint-to-xml/
keywords:
- PowerPoint konvertálása XML-re
- prezentáció konvertálása XML-re
- PPT XML-re
- PPTX XML-re
- ODP XML-re
- PowerPoint XML prezentáció
- SaveFormat.Xml
- prezentáció mentése XML-ként
- prezentáció exportálása XML-be
- XML adatfolyam
- Android
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk konvertálása PowerPoint XML fájlokra vagy adatfolyamokra Androidon az Aspose.Slides segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java képes a PowerPoint-prezentációkat PowerPoint XML Presentation formátumba konvertálni. Az XML‑kimenet akkor hasznos, amikor szövegalapú ábrázolásra van szükség a prezentációs struktúra ellenőrzéséhez, a létrehozott dokumentumok hibakereséséhez, a kimenet összehasonlításához automatizált tesztekben, vagy egy olyan munkafolyamathoz való integráláshoz, amely XML‑t fogyaszt a prezentációcsomag helyett.

Használja a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust a [SaveFormat.Xml](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/#Xml) értékkel. Az eredményt közvetlenül fájlba vagy adatfolyamba írhatja.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` PowerPoint XML Presentation‑t hoz létre. Nem bontja ki az egyes Office Open XML részeket, amelyek egy PPTX csomagban tárolódnak. Ha a pontos PPTX csomagrészekre van szüksége, például a `ppt/presentation.xml` vagy az egyes dia XML‑fájlokra, akkor közvetlenül a PPTX csomagot vizsgálja meg.
{{% /alert %}}

## **Prezentáció konvertálása XML-fájlba**

Töltsön be egy forrásprezentációt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztállyal, majd adja át a kimeneti útvonalat és a [SaveFormat.Xml](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/saveformat/#Xml) értéket a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metódusnak. A forrás bármely betöltésre támogatott prezentációs formátum lehet, például PPT, PPTX vagy ODP.

Az alábbi példa egy PPTX prezentációt XML-fájlba konvertál:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **XML-kimenet írása adatfolyamba**

Használja a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) adatfolyam‑túlterhelését, amikor az XML‑nek memóriában kell maradnia vagy egy másik komponensnek, például webszolgáltatásnak, tárolószolgáltatónak vagy XML‑feldolgozó csővezetéknek kell továbbadni. Az alábbi példa az eredményt egy [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream)‑ba írja, és a generált XML‑t bájt‑tömbként kapja meg:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // Az xmlData-t átadja a munkafolyamat következő komponensének.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **XML összehasonlítása a prezentációs és export formátumokkal**

Válassza ki a kimeneti formátumot a végeredmény felhasználási módja szerint:

| Formátum | Kimenet | Tipikus használat |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML prezentáció | Struktúra ellenőrzése, hibakeresés, generált kimenet összehasonlítása és XML‑alapú integráció |
| PPT (`.ppt`) | Régi bináris prezentációs fájl | Kompatibilitás a régebbi PowerPoint munkafolyamatokkal |
| PPTX (`.pptx`) | Office Open XML csomag több részzel | Szokásos PowerPoint szerkesztés és prezentációcsere |
| PDF or TIFF | Rögzített elrendezésű oldalak vagy többoldalas kép | Megtekintés, nyomtatás és archiválás |
| PNG, JPEG, or SVG | Egyetlen dia megjelenített ábrázolása | Bélyegképek, előnézetek és kéveszközök |
| HTML or HTML5 | Web-orientált prezentációs kimenet | Böngészőben való megtekintés és webes publikálás |

A PPT és PPTX formátumokkal ellentétben az XML‑kimenet elsősorban ellenőrzésre és adatközpontú munkafolyamatokra szolgál. A PDF, TIFF, HTML és dia‑képfájl formátumokkal ellentétben ez a prezentáció adatát reprezentálja, nem a diák oldalakká vagy vizuális eszközökké való renderelését. A [supported file formats](/slides/hu/androidjava/supported-file-formats/) táblázat a PowerPoint XML Presentation‑t csak mentésre szánt formátumként sorolja fel, ezért ne használja, ha a munkafolyamatnak az exportált fájlt vissza kell tölteni az Aspose.Slides‑ba a további szerkesztéshez.

## **FAQ**

**A `SaveFormat.Xml` ugyanaz, mint egy PPTX fájl mentése?**

Nem. A PPTX egy több Office Open XML részt tartalmazó csomag, míg a `SaveFormat.Xml` egy PowerPoint XML Presentation fájlt hoz létre.

**Menthetem az XML‑kimenetet anélkül, hogy fájlt hoznék létre a lemezen?**

Igen. Adjon át egy írható adatfolyamot a [Presentation.save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) metódusnak. Például használjon egy [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream)‑t a memória‑beli feldolgozáshoz.

**Képes az Aspose.Slides betölteni az exportált XML‑fájlt ismét?**

Nem. A PowerPoint XML Presentation jelenleg csak mentésre támogatott, betöltésre nem. Használjon PPTX‑et vagy más támogatott prezentációs formátumot, ha körkörös szerkesztésre van szükség.

**Az XML‑konvertálás minden diát oldalra vagy képre renderel?**

Nem. Az XML‑konvertálás strukturált prezentációs adatot ír. Használjon PDF‑et vagy TIFF‑et oldal‑orientált kimenethez, vagy PNG‑t, JPEG‑t és SVG‑t egyes dia‑képekhez.