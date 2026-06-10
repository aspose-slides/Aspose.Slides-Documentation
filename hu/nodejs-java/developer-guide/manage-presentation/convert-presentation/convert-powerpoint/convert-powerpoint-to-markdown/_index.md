---
title: PowerPoint-prezentációk konvertálása Markdownra JavaScriptben
linktitle: PowerPoint Markdownra
type: docs
weight: 140
url: /hu/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint MD-re
- prezentáció MD-re
- dia MD-re
- PPT MD-re
- PPTX MD-re
- PowerPoint mentése Markdownként
- prezentáció mentése Markdownként
- dia mentése Markdownként
- PPT mentése MD-ként
- PPTX mentése MD-ként
- PPT exportálása MD-be
- PPTX exportálása MD-be
- PowerPoint
- prezentáció
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertálja a PowerPoint diákat JavaScript‑ben—PPT, PPTX—tiszta Markdownba az Aspose.Slides for Node.js segítségével Java‑on keresztül, automatizálja a dokumentációt és megőrizze a formázást."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi a PowerPoint‑prezentációk Markdown‑formátumba történő konvertálását, ami hasznos lehet dokumentációs munkafolyamatoknál, statikus weboldalak generálásánál, tartalom migrációnál és verzió‑kezelésű szövegközzétételnél. Az API közvetlen exportot támogat PPT és PPTX bemutatókból MD fájlokba, és további lehetőségeket kínál a diák tartalmának Markdown‑dokumentumban való ábrázolásának szabályozására.

Exportálhatja a bemutatókat egyszerű Markdown‑formátumba, választhat a CommonMark és a GitHub Flavored Markdown több változata közül, valamint beállíthatja, hogyan kezelje a képeket az export során. A vizuális tartalmat tartalmazó bemutatók esetén az Aspose.Slides lehetővé teszi a képek külön mappába mentését, és azok hivatkozását a létrehozott Markdown‑fájlban.

{{% alert color="warning" %}} 

A PowerPoint‑ról Markdown‑export **alapértelmezés szerint képek nélkül** történik. Ha olyan PowerPoint‑dokumentumot szeretne exportálni, amely képeket tartalmaz, hívja meg a `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` metódust, és állítsa be a `BasePath`‑t, ahová a Markdown‑dokumentumban hivatkozott képek mentésre kerülnek. 

{{% /alert %}} 

## **PowerPoint konvertálása Markdown‑re**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból a bemutató objektum reprezentálásához.  
2. Használja a [save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) metódust a objektum Markdown‑fájlként történő mentéséhez.

Ez a JavaScript‑kód bemutatja, hogyan konvertálja a PowerPoint‑ot Markdown‑re:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **PowerPoint konvertálása Markdown‑variánsra**

Az Aspose.Slides lehetővé teszi a PowerPoint konvertálását markdown‑ra (alapvető szintaxissal), CommonMark‑ra, GitHub‑flavored markdown‑ra, Trello, XWiki, GitLab és további 17 markdown‑variánsra.

Ez a JavaScript‑kód megmutatja, hogyan konvertálja a PowerPoint‑ot CommonMark‑ra:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

A támogatott 23 markdown‑variáns a [Flavor enumeration](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/flavor/) alatt van felsorolva a [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownsaveoptions/) osztályból.

## **Képeket tartalmazó bemutató konvertálása Markdown‑re**

A [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownsaveoptions/) osztály tulajdonságokat és enumerációkat biztosít, amelyekkel beállíthatja a létrehozandó markdown‑fájl bizonyos opcióit. A [MarkdownExportType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markdownexporttype/) enum például olyan értékekre állítható, amelyek meghatározzák, hogyan jelennek meg vagy kezelődnek a képek: `Sequential`, `TextOnly`, `Visual`.

### **Képek sorozatos konvertálása**

Ha azt szeretné, hogy a képek egymás után, különállóan jelenjenek meg a markdown‑dokumentumban, válassza a sorozatos opciót. Ez a JavaScript‑kód mutatja, hogyan konvertálja a képeket tartalmazó bemutatót markdown‑re:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Képek vizuális konvertálása**

Ha azt szeretné, hogy a képek együttesen jelenjenek meg a markdown‑dokumentumban, válassza a vizuális opciót. Ebben az esetben a képek az alkalmazás aktuális könyvtárába lesznek mentve (és relatív útvonal épül rájuk a markdown‑dokumentumban), vagy megadhatja a kívánt útvonalat és mappanevet.

Ez a JavaScript‑kód demonstrálja a műveletet:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Megmaradnak a hiperhivatkozások az exportálás után?**

Igen. A szöveg [hyperlinks](/slides/hu/nodejs-java/manage-hyperlinks/) szabványos Markdown‑hivatkozásként marad meg. A diák [transitions](/slides/hu/nodejs-java/slide-transition/) és [animations](/slides/hu/nodejs-java/powerpoint-animation/) nem konvertálódnak.

**Gyorsíthatom a konvertálást több szálon futtatva?**

Fájlok között párhuzamosítható, de ne [share](/slides/hu/nodejs-java/multithreading/) ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt szálak között. Használjon különálló példányokat vagy folyamatokat fájlonként a versengés elkerülése érdekében.

**Mi történik a képekkel – hová mentődnek, és relatív útvonalak-e?**

[Images](/slides/hu/nodejs-java/image/) dedikált mappába exportálódnak, a Markdown‑fájl pedig alapértelmezés szerint relatív útvonalakkal hivatkozik rájuk. Konfigurálhatja a kimeneti alapútvonalat és az eszközkönyvtár nevét a kiszámítható tárolóstruktúra fenntartása érdekében.