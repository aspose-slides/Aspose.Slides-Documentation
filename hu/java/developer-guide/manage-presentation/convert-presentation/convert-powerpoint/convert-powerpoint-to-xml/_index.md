---
title: PowerPoint-prezentációk konvertálása XML formátumba Java-ban
linktitle: PowerPoint XML-re
type: docs
weight: 145
url: /hu/java/convert-powerpoint-to-xml/
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
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk konvertálása PowerPoint XML fájlokra vagy adatfolyamokra Java-ban az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Java képes a PowerPoint‑prezentációkat a PowerPoint XML Presentation formátumba konvertálni. Az XML‑kimenet hasznos, ha szöveges ábrázolásra van szükség a prezentáció szerkezetének vizsgálatához, a generált dokumentumok hibaelhárításához, a kimenet automatizált tesztekben történő összehasonlításához, vagy egy olyan munkafolyamathoz való integráláshoz, amely XML‑t fogyaszt a prezentációcsomag helyett.

Használja a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) osztály `Xml` értékével. Az eredményt közvetlenül fájlba vagy adatfolyamba írhatja.

{{% alert color="info" title="Megjegyzés" %}}
`SaveFormat.Xml` egy PowerPoint XML Presentation‑t hoz létre. Nem bontja ki a PPTX csomagban tárolt egyes Office Open XML részeket. Ha a pontos PPTX‑csomagrészekre van szüksége, például a `ppt/presentation.xml` vagy az egyes diák XML‑fájlaira, vizsgálja meg közvetlenül a PPTX csomagot.
{{% /alert %}}

## **Prezentáció konvertálása XML‑fájlba**

Töltsön be egy forrás‑prezentációt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztállyal, majd adja meg a kimeneti útvonalat és a `SaveFormat.Xml` értéket a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódusnak. A forrás lehet bármely betöltésre támogatott prezentációformátum, például PPT, PPTX vagy ODP.

Az alábbi példa egy PPTX prezentációt XML‑fájllá konvertál:

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

## **XML kimenet írása adatfolyamba**

Használja a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) adatfolyam‑túlterhelést, ha az XML‑nek memóriában kell maradnia, vagy egy másik komponensnek kell átadni, például egy webszolgáltatásnak, tárolási szolgáltatónak vagy XML‑feldolgozó csővezetéknek. Az alábbi példa az eredményt egy [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html)‑ba írja, és a kapott XML‑t bájt‑tömbként kapja meg:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Az xmlData-t átadja a munkafolyamat következő komponensének.
} finally {
    presentation.dispose();
}
```

## **XML összehasonlítása a prezentáció‑ és exportformátumokkal**

Válassza ki a kimeneti formátumot attól függően, hogy hogyan lesz felhasználva az eredmény:

| Formátum | Kimenet | Tipikus használat |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML prezentáció | Strukturális vizsgálat, hibaelhárítás, generált kimenet összehasonlítása és XML‑alapú integráció |
| PPT (`.ppt`) | Örökölt bináris prezentációfájl | Kompatibilitás a régebbi PowerPoint munkafolyamatokkal |
| PPTX (`.pptx`) | Office Open XML csomag több részzel | Szokásos PowerPoint szerkesztés és prezentációcseré |
| PDF vagy TIFF | Rögzített elrendezésű oldalak vagy többoldalas kép | Megtekintés, nyomtatás és archiválás |
| PNG, JPEG vagy SVG | Egyedi dia renderelt ábrázolása | Miniatűrök, előnézetek és képeszközök |
| HTML vagy HTML5 | Web‑orientált prezentációkimenet | Böngészőben megtekintés és webes közzététel |

A PPT‑ és PPTX‑formátumoktól eltérően az XML‑kimenet elsősorban vizsgálatra és adat‑központú munkafolyamatokra szolgál. A PDF, TIFF, HTML és dia‑kép formátumoktól eltérően az XML a prezentáció adatait reprezentálja, nem rendereli a diákat oldal‑ vagy vizuális elemekként. A [támogatott fájlformátumok](/slides/hu/java/supported-file-formats/) táblázatban a PowerPoint XML Presentation csak mentési formátumként szerepel, ezért ne használja, ha a munkafolyamatnak vissza kell töltenie a kiexportált fájlt az Aspose.Slides‑be a további szerkesztéshez.

## **GYIK**

**Ugyanaz‑e a `SaveFormat.Xml`, mint egy PPTX fájl mentése?**

Nem. A PPTX egy több Office Open XML részt tartalmazó csomag, míg a `SaveFormat.Xml` egy PowerPoint XML prezentáció‑fájlt hoz létre.

**Menthetem az XML kimenetet anélkül, hogy fájlt hoznék létre a lemezen?**

Igen. Adj át egy írható adatfolyamot a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) metódusnak. Például egy [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) használható memória‑beli feldolgozáshoz.

**Betöltheti az Aspose.Slides a exportált XML fájlt újra?**

Nem. A PowerPoint XML Presentation jelenleg csak mentésre támogatott, betöltésre nem. Használjon PPTX‑et vagy más támogatott prezentációformátumot, ha körkörös szerkesztésre van szükség.

**A XML‑konverzió megjeleníti‑e minden diát oldalként vagy képként?**

Nem. Az XML‑konverzió strukturált prezentációs adatokat ír. Használjon PDF‑et vagy TIFF‑et oldal‑orientált kimenethez, illetve PNG‑t, JPEG‑t és SVG‑t egyedi dia‑képekhez.