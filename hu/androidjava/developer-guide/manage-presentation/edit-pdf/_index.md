---
title: PDF dokumentumok szerkesztése Androidon
linktitle: PDF szerkesztése
type: docs
weight: 65
url: /hu/androidjava/edit-pdf/
keywords:
- PDF szerkesztése
- PDF szöveg cseréje
- PDF -> PPTX
- PPTX -> PDF
- Android
- Java
- Aspose.Slides
description: "PDF dokumentumok szerkesztése Androidon Java-val, úgy, hogy importáljuk őket az Aspose.Slides-be, cseréljük a szöveget, és a módosított bemutatót vissza mentjük PDF-be."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java lehetővé teszi a PDF tartalom szerkesztését az oldalak diaként történő importálásával, a bemutató módosításával, majd a PDF-be való visszaexportálással. Ez a cikk egy egyszerű szövegcsere példáját mutatja be. A bemutató a memóriában marad, ezért a köztes PPTX fájl mentése opcionális.

## **PDF-ben lévő szöveg cseréje**

Használja a [addFromPdf](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) metódust az oldalak importálásához, a [replaceText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) metódust a szöveg frissítéséhez, és a [save](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust az eredmény exportálásához.

Az alábbi példában az `input.pdf` fájlnak a "Draft" szót tartalmaznia kell szerkeszthető szövegként az importálás után. A program ezt a szót "Final"-ra cseréli, és a `edited.pdf` fájlt írtja ki. Az importálás előtti kezdeti dia törlése megakadályoz egy extra üres oldalt a kimenetben. A keresés a teljes szavakat egyező betűesettel keresi; a `null` azt jelenti, hogy nincs szükség eredmény‑visszahívásra.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

További lehetőségekért tekintse meg a [Szöveg keresése és cseréje](/slides/hu/androidjava/search-and-replace-text/) és a [PowerPoint konvertálása PDF-be](/slides/hu/androidjava/convert-powerpoint-to-pdf/) oldalakat.

{{% alert color="info" title="Note" %}}
A szövegcsere importált szövegre működik, nem a beolvasott képekben lévő szövegre. A konvertálás befolyásolhatja a elrendezést és a formázást, ezért ellenőrizze a kimenetet, különösen ha a csere‑szöveg hosszabb, mint az eredeti.
{{% /alert %}}

## **GYIK**

**Szükséges PPTX-fájlt menteni a PDF exportálása előtt?**

Nem. A bemutatót szerkesztheti és exportálhatja közvetlenül a memóriában. PPTX másolatot csak akkor mentse, ha a PowerPoint‑ban is folytatni szeretné a szerkesztést; lásd a [Prezentációk mentése](/slides/hu/androidjava/save-presentation/).

**Miért maradhat néhány szöveg változatlan?**

A példa a teljes "Draft" szót pontos betűesettel keresi. A képként importált vagy különálló szövegkeretbe szplitelt szöveg nem feltétlenül egyezik a kereséssel. Ellenőrizze az importált tartalmat, és igazítsa a keresést a saját dokumentumához.