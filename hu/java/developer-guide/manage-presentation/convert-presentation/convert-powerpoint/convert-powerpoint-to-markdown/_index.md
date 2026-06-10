---
title: PowerPoint prezentációk konvertálása Markdown-re Java-ban
linktitle: PowerPoint Markdown-re
type: docs
weight: 140
url: /hu/java/convert-powerpoint-to-markdown/
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
- PowerPoint mentése Markdown-ként
- prezentáció mentése Markdown-ként
- dia mentése Markdown-ként
- PPT mentése MD-ként
- PPTX mentése MD-ként
- PPT exportálása MD-be
- exportPPTX MD-be
- PowerPoint
- prezentáció
- Markdown
- Java
- Aspose.Slides
description: "Konvertálja a PowerPoint diákat—PPT, PPTX—tiszta Markdown formátumba az Aspose.Slides for Java segítségével, automatizálja a dokumentációt és megőrizze a formázást."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint‑prezentációkat Markdown formátumba konvertálja, ami hasznos lehet dokumentációs munkafolyamatokhoz, statikus webhelyek generálásához, tartalomátvitelhez és verziókövetett szöveges kiadványok közzétételéhez. Az API közvetlen exportálást támogat PPT és PPTX prezentációkból MD‑fájlokba, valamint további lehetőségeket biztosít a diák tartalmának a létrejövő Markdown‑dokumentumban való ábrázolásának szabályozásához.

Exportálhatja a prezentációkat egyszerű Markdown‑ként, választhat több Markdown‑változat közül, például a CommonMark‑ot és a GitHub Flavored Markdown‑ot, valamint beállíthatja, hogyan kezelje a képeket az exportálás során. A vizuális tartalmat tartalmazó prezentációk esetén az Aspose.Slides lehetővé teszi a képek külön mappába mentését, és azok hivatkozását a generált Markdown‑fájlban.

{{% alert color="warning" %}}
A PowerPoint‑markdown export **alapértelmezés szerint képek nélkül** történik. Ha olyan PowerPoint‑dokumentumot szeretne exportálni, amely képeket tartalmaz, használja a `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` metódust, valamint a `setBasePath`‑t, amely a markdown‑dokumentumban hivatkozott képek mentési helyét adja meg.
{{% /alert %}}

## **PowerPoint konvertálása Markdown‑ba**

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból, amely egy prezentációobjektumot képvisel.
2. Használja a [Mentés](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) metódust az objektum markdown‑fájlként való mentéséhez.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint konvertálása Markdown‑változatra**

Az Aspose.Slides lehetővé teszi a PowerPoint konvertálását markdown‑re (alapvető szintaxissal), CommonMark‑ra, GitHub‑flavored markdown‑ra, Trello‑ra, XWiki‑ra, GitLab‑ra és további 17 markdown‑változatra.

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

A 23 támogatott markdown‑változat [a Flavor felsorolásban felsorolt] https://reference.aspose.com/slides/hu/java/com.aspose.slides/flavor/ a [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownsaveoptions/) osztályból.

## **Képeket tartalmazó prezentáció konvertálása Markdown‑ba**

A [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownsaveoptions/) osztály tulajdonságokat és felsorolásokat biztosít, amelyekkel beállíthatja a létrejövő markdown‑fájl bizonyos opcióit. A [MarkdownExportType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markdownexporttype/) felsorolás például olyan értékekre állítható, amelyek meghatározzák, hogyan jelennek meg vagy kezelődnek a képek: `Sequential`, `TextOnly`, `Visual`.

### **Képek konvertálása sorban**

Ha a képek egymás után, egyenként szeretné, hogy megjelenjenek a markdown‑ban, válassza a sorban opciót. Ez a Java‑kód bemutatja, hogyan konvertáljon képeket tartalmazó prezentációt markdown‑ra:

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

Ha a képeket együtt szeretné megjeleníteni a markdown‑ban, válassza a vizuális opciót. Ebben az esetben a képek az alkalmazás aktuális könyvtárába mentődnek (és a markdown‑dokumentumban relatív útvonal jön létre), vagy megadhatja a kívánt útvonalat és mappanevet.

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

**Megmaradnak a hiperhivatkozások a Markdown‑export során?**

Igen. A szöveg [hiperláncok](/slides/hu/java/manage-hyperlinks/) megmarad standard Markdown‑linkként. A diák [átmenetei](/slides/hu/java/slide-transition/) és [animációi](/slides/hu/java/powerpoint-animation/) nem kerülnek konvertálásra.

**Gyorsíthatom a konvertálást több szálon futtatva?**

Fájlok között párhuzamosíthat, de [ne ossza meg](/slides/hu/java/multithreading/) ugyanazt a [Prezentáció](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példányt szálak között. Használjon különálló példányokat/folyamatokat fájlonként a versengés elkerülése érdekében.

**Mi történik a képekkel – hová mentődnek, és relatívak-e az útvonalak?**

[Képek](/slides/hu/java/image/) exportálásra kerülnek egy dedikált mappába, és a Markdown‑fájl alapértelmezés szerint relatív útvonalakkal hivatkozik rájuk. Konfigurálhatja a kimeneti alapútvonalat és az eszközmappa nevét a kiszámítható adattárstruktúra fenntartásához.