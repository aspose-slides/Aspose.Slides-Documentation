---
title: PDF dokumentumok szerkesztése JavaScriptben
linktitle: PDF szerkesztése
type: docs
weight: 65
url: /hu/nodejs-java/edit-pdf/
keywords:
- PDF szerkesztése
- PDF szöveg cseréje
- PDF PPTX-é
- PPTX PDF-é
- Node.js
- JavaScript
- Aspose.Slides
description: "PDF dokumentumok szerkesztése JavaScriptben az Aspose.Slidesba importálással, a szöveg cseréjével, és a módosított bemutató vissza mentésével PDF formátumba."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java lehetővé teszi PDF‑tartalom szerkesztését az oldalak diaként történő importálásával, a bemutató módosításával és visszaexportálásával PDF‑be. Ez a cikk egy egyszerű szövegcsere bemutatását tartalmazza. A bemutató memóriában marad, ezért a köztes PPTX fájl mentése nem kötelező.

## **Szöveg cseréje PDF‑ben**

Használja az [addFromPdf](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/#addFromPdf) metódust az oldalak importálásához, a [replaceText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#replaceText) metódust a szöveg frissítéséhez, és a [save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódust az eredmény exportálásához.

A következő példa azt várja, hogy az `input.pdf` tartalmazza a "Draft" szót szerkeszthető szövegként az importálás után. Lecseréli ezt a szót a "Final" értékre, és a `edited.pdf` fájlba írja. Az első dia törlése az importálás előtt megakadályoz egy extra üres oldalt a kimenetben. A keresés teljes szavakat egyező kis- és nagybetűvel talál; a `null` azt jelenti, hogy nincs szükség eredmény‑visszahívásra.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

További lehetőségekért tekintse meg a [Szöveg keresése és cseréje](/slides/hu/nodejs-java/search-and-replace-text/) és a [PowerPoint konvertálása PDF‑be](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/) oldalakat.

{{% alert color="info" title="Note" %}}
A szövegcsere az importált szövegen működik, nem a beolvasott képekben lévő szövegen. A konverzió befolyásolhatja az elrendezést és a formázást, ezért ellenőrizze a kimenetet, különösen ha a helyettesítő szöveg hosszabb az eredetinél.
{{% /alert %}}

## **GYIK**

**Szükséges PPTX fájlt menteni a PDF exportálása előtt?**

Nem. A bemutatót memóriában szerkesztheti és exportálhatja. PPTX másolatot csak akkor érdemes menteni, ha tovább szeretné szerkeszteni PowerPointban; lásd a [Prezentációk mentése](/slides/hu/nodejs-java/save-presentation/) oldalt.

**Miért maradhat egyes szövegek változatlanok?**

A példa pontosan a "Draft" teljes szavát egyezik a kis- és nagybetűkkel. Képként importált vagy különálló szövegkeretekre osztott szöveg nem feltétlenül egyezik a kereséssel. Ellenőrizze az importált tartalmat, és állítsa be a keresést a dokumentumhoz.