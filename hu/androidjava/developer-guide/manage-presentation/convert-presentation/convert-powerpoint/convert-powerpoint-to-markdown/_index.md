---
title: PowerPoint prezentációk konvertálása Markdownra Androidon
linktitle: PowerPoint Markdownra
type: docs
weight: 140
url: /hu/androidjava/convert-powerpoint-to-markdown/
keywords:
- PowerPoint átalakítása
- prezentáció átalakítása
- dia átalakítása
- PPT átalakítása
- PPTX átalakítása
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
- exportPPTX MD-be
- PowerPoint
- prezentáció
- Markdown
- Android
- Java
- Aspose.Slides
description: "Konvertálja a PowerPoint diákat - PPT, PPTX - tiszta Markdownra az Androidra készült Aspose.Slides segítségével Java nyelven, automatizálja a dokumentációt és tartsa meg a formázást."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi a PowerPoint‑prezentációk Markdown formátumba történő konvertálását, ami hasznos lehet dokumentációs munkafolyamatoknál, statikus weboldalak generálásánál, tartalom migrációnál és verziókövetett szöveges kiadványnál. Az API közvetlen exportot támogat PPT és PPTX prezentációkból MD fájlokba, és további beállítási lehetőséget kínál arra, hogyan legyen a diák tartalma ábrázolva a létrehozott Markdown dokumentumban.

Exportálhatja a prezentációkat egyszerű Markdownként, választhat több Markdown‑variáns közül, például a CommonMark‑ból és a GitHub Flavored Markdown‑ból, valamint beállíthatja, hogyan kezelje a képeket az export során. Olyan prezentációk esetén, amelyek vizuális tartalmat tartalmaznak, az Aspose.Slides lehetővé teszi a képek külön mappába mentését, majd azok hivatkozását a generált Markdown fájlból.

Az Aspose.Slides támogatja a prezentáció‑Markdown konvertálást.

{{% alert color="warning" %}} 
A PowerPoint‑Markdown export **képek nélkül** történik alapértelmezés szerint. Ha olyan PowerPoint‑dokumentumot szeretne exportálni, amely képeket tartalmaz, be kell állítania a `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` értéket, illetve megadni a `BasePath`‑t, ahová a Markdown dokumentumban hivatkozott képek mentésre kerülnek.
{{% /alert %}} 

## **PowerPoint konvertálása Markdown formátumba**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból, amely a prezentáció objektumát képviseli.  
2. Használja a [Save ](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)metódust a objektum markdown fájlként való mentéséhez.

Ez a Java‑kód bemutatja, hogyan konvertálhat PowerPoint‑ot markdown formátumba:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint konvertálása Markdown‑variánsba**

Az Aspose.Slides lehetővé teszi a PowerPoint konvertálását markdown‑ba (alapvető szintaxissal), CommonMark‑ba, GitHub‑flavored markdown‑ba, Trello‑ba, XWiki‑ba, GitLab‑ba és még 17 egyéb markdown‑variánsba.

Ez a Java‑kód bemutatja, hogyan konvertálhat PowerPoint‑ot CommonMark‑ba:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

A támogatott 23 markdown‑variánst a [Flavor enumeráció](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/flavor/) tartalmazza a [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownsaveoptions/) osztályból.

## **Prezentáció képekkel rendelkező konvertálása Markdown‑ba**

A [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownsaveoptions/) osztály tulajdonságokat és felsorolásokat biztosít, amelyekkel bizonyos beállítások alkalmazhatók a keletkező markdown fájlra. Például a [MarkdownExportType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markdownexporttype/) enum beállítható olyan értékekre, amelyek meghatározzák, hogyan legyenek a képek megjelenítve vagy kezelve: `Sequential`, `TextOnly`, `Visual`.

### **Képek sorozatos konvertálása**

Ha azt szeretné, hogy a képek egymás után, egyenként jelenjenek meg a létrehozott markdownban, válassza a sorozatos (Sequential) beállítást. Ez a Java‑kód mutatja, hogyan konvertálhat egy képeket tartalmazó prezentációt markdown‑ba:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Képek vizuális konvertálása**

Ha azt szeretné, hogy a képek együtt jelenjenek meg a létrehozott markdownban, válassza a vizuális (Visual) opciót. Ebben az esetben a képek a alkalmazás aktuális könyvtárába mentődnek (és a markdown dokumentumban relativ útvonal kerül rájuk), vagy megadhatja a kívánt útvonalat és mappanevet.

Ez a Java‑kód demonstrálja a műveletet:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Megmaradnak-e a hiperhivatkozások a Markdown‑export során?**

Igen. A szöveg [hyperlinks](/slides/hu/androidjava/manage-hyperlinks/) standard Markdown‑hivatkozásként marad meg. A diák [transitions](/slides/hu/androidjava/slide-transition/) és [animations](/slides/hu/androidjava/powerpoint-animation/) nem kerülnek konvertálásra.

**Gyorsíthatom‑e a konvertálást többszálú futtatással?**

Fájlok szintjén párhuzamosíthatja, de [ne ossza meg](/slides/hu/androidjava/multithreading/) ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példányt szálak között. Használjon különálló példányokat vagy folyamatokat fájlonként a versengés elkerülése érdekében.

**Mi történik a képekkel – hol mentődnek, és relatív utak-e?**

[Images](/slides/hu/androidjava/image/) külön mappába exportálódnak, a Markdown fájl alapértelmezés szerint relatív útvonalakkal hivatkozik rájuk. A kimeneti alapút és az eszközmappa nevét konfigurálhatja, hogy előre meghatározott repozitárium‑struktúrát biztosítson.