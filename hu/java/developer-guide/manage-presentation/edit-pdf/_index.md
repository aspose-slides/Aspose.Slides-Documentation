---
title: PDF dokumentumok szerkesztése Java-ban
linktitle: PDF szerkesztése
type: docs
weight: 65
url: /hu/java/edit-pdf/
keywords:
- PDF szerkesztése
- PDF szöveg cseréje
- PDF PPTX-re
- PPTX PDF-re
- Java
- Aspose.Slides
description: "PDF dokumentumok szerkesztése Java-ban az Aspose.Slides-be történő importálással, a szöveg cseréjével, és a módosított prezentáció PDF-be mentésével."
---
## **Áttekintés**

Az Aspose.Slides for Java lehetővé teszi a PDF tartalom szerkesztését az oldalak diaként történő importálásával, a prezentáció módosításával, majd a vissza‑exportálással PDF‑be. Ez a cikk egy egyszerű szövegcserét mutat be. A prezentáció a memóriában marad, így egy köztes PPTX fájl mentése opcionális.

## **Szöveg cseréje PDF‑ben**

Használja a [addFromPdf](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) metódust az oldalak importálásához, a [replaceText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) metódust a szöveg frissítéséhez, és a [save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust az eredmény exportálásához.

Az alábbi példa azt feltételezi, hogy az `input.pdf` tartalmazza a „Draft” szót szerkeszthető szövegként az importálás után. A program ezt a szót „Final”‑re cseréli, és a `edited.pdf`‑t írja ki. Az első dia törlése az importálás előtt megakadályoz egy extra üres oldalt a kimenetben. A keresés teljes szavakat egyezik meg azonos betűmérettel; a `null` azt jelenti, hogy nincs szükség eredmény‑visszahívásra.

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

További beállításokért tekintse meg a [Search and Replace Text](/slides/hu/java/search-and-replace-text/) és a [Convert PowerPoint to PDF](/slides/hu/java/convert-powerpoint-to-pdf/) oldalakat.

{{% alert color="info" title="Note" %}}
A szövegcsere importált szövegen működik, nem a beolvasott képeken belüli szövegen. A konverzió befolyásolhatja az elrendezést és a formázást, ezért ellenőrizze a kimenetet, különösen ha a helyettesítő szöveg hosszabb az eredetinél.
{{% /alert %}}

## **GYIK**

**Szükséges-e PPTX fájlt menteni a PDF exportálása előtt?**

Nem. A prezentációt ugyanabban a memóriában szerkesztheti és exportálhatja. PPTX másolatot csak akkor érdemes menteni, ha továbbra is szeretné azt PowerPoint‑ban szerkeszteni; lásd a [Save Presentations](/slides/hu/java/save-presentation/) oldalt.

**Miért maradhat egyes szövegek változatlanul?**

A példa a „Draft” teljes szót pontos betűmérettel egyezteti. Az importált, képként vagy különböző szövegdobozokban megjelenő szöveg nem feltétlenül felel meg a keresésnek. Ellenőrizze az importált tartalmat, és állítsa be a keresést a dokumentumához.