---
title: PowerPoint prezentációk konvertálása XML-be Java-ban
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
- prezentáció exportálása XML-re
- XML adatfolyam
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk konvertálása PowerPoint XML fájlokká vagy adatfolyamokká Java-ban az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Java képes PowerPoint előadásokat átalakítani a PowerPoint XML előformátumba. Az XML kimenet akkor hasznos, ha szöveges ábrázolásra van szükség a prezentáció szerkezetének ellenőrzéséhez, a létrehozott dokumentumok hibakereséséhez, a kimenet automatizált tesztekben történő összehasonlításához, vagy egy olyan munkafolyammal való integráláshoz, amely XML-t használ a prezentációcsomag helyett.

Használja a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust a [SaveFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/saveformat/) osztály `Xml` értékével. Az eredményt közvetlenül fájlba vagy adatfolyamba is írhatja.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` egy PowerPoint XML előformátumot hoz létre. Nem bontja ki a PPTX csomagban tárolt egyedi Office Open XML részeket. Ha a PPTX csomag pontos részeire van szüksége, például a `ppt/presentation.xml` vagy az egyes dia XML állományokra, vizsgálja meg közvetlenül a PPTX csomagot.
{{% /alert %}}

## **Prezentáció átalakítása XML fájlba**

Töltsön be egy forrás előadást a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztállyal, majd adja át a kimeneti útvonalat és a `SaveFormat.Xml` értéket a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódusnak. A forrás lehet bármely betöltésre támogatott előformátum, például PPT, PPTX vagy ODP.

A következő példa egy PPTX előadást alakít át XML fájlra:

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

## **XML kimenet írása adatfolyamra**

Használja a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) adatfolyam‑túlterhelését, amikor az XML-nek memóriában kell maradnia vagy egy másik komponensnek kell továbbítania, például egy webszolgáltatásnak, tárolási szolgáltatónak vagy XML-feldolgozó csővezetéknek. A következő példa az eredményt egy [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) objektumba írja, és a kapott XML-t bájt tömbként állítja elő:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Az xmlData átadása a munkafolyamat következő komponensének.
} finally {
    presentation.dispose();
}
```

## **XML összehasonlítása a prezentációs és export formátumokkal**

Válassza ki a kimeneti formátumot a végeredmény felhasználásának módja szerint:

| Formátum | Kimenet | Tipikus felhasználás |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML előformátum | Szerkezet ellenőrzése, hibakeresés, a generált kimenet összehasonlítása és XML-alapú integráció |
| PPT (`.ppt`) | Régi bináris prezentációs fájl | Kompatibilitás a régi PowerPoint munkafolyamatokkal |
| PPTX (`.pptx`) | Office Open XML csomag több részel | Szokásos PowerPoint szerkesztés és prezentációcsere |
| PDF vagy TIFF | Rögzített elrendezésű oldalak vagy többoldalas kép | Megtekintés, nyomtatás és archiválás |
| PNG, JPEG vagy SVG | Egyedi dia leképzett ábrázolása | Miniatűrök, előnézetek és kép‑eszközök |
| HTML vagy HTML5 | Web‑orientált prezentációs kimenet | Böngészőben való megjelenítés és webes közzététel |

A PPT és PPTX formátumokkal szemben az XML kimenet elsősorban ellenőrzésre és adat‑orientált munkafolyamatokra szolgál. A PDF, TIFF, HTML és dia‑képek formátumaival ellentétben a prezentáció adatait ábrázolja, nem pedig a diák oldal‑ vagy vizuális megjelenítését. A [támogatott fájlformátumok](/slides/hu/java/supported-file-formats/) táblázat felsorolja az összes formátumot, amelyet az Aspose.Slides be tud tölteni, importálni, menteni vagy renderelni.

## **GYIK**

**Ugyanaz-e a `SaveFormat.Xml`, mint egy PPTX fájl mentése?**

Nem. A PPTX egy több Office Open XML részt tartalmazó csomag, míg a `SaveFormat.Xml` egy PowerPoint XML előformátumú fájlt hoz létre.

**Menthetem az XML kimenetet anélkül, hogy a lemezen fájlt hoznék létre?**

Igen. Adjon át egy írható adatfolyamot a [Presentation.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) metódusnak. Például használjon egy [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) objektumot a memóriában történő feldolgozáshoz.

**Betöltheti az Aspose.Slides a korábban exportált XML fájlt?**

Igen. Adja át az XML fájlt vagy egy adatfolyamot a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) konstruktorának. A [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSourceFormat--) ezután `SourceFormat.Xml` értéket ad vissza. A [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) `LoadFormat.Unknown`‑t jelent ezen formátumra, ezért ne használja ennek meghatározására, hogy megnyitható‑e az XML fájl.

**Az XML konverzió minden diát oldal‑ vagy képként renderel?**

Nem. Az XML konverzió strukturált prezentációs adatot ír. Használjon PDF‑et vagy TIFF‑et oldal‑orientált kimenethez, illetve PNG‑t, JPEG‑t és SVG‑t egyedi diaképekhez.