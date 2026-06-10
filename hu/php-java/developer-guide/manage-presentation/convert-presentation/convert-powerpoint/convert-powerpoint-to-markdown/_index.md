---
title: PowerPoint prezentációk konvertálása Markdownba PHP‑ben
linktitle: PowerPoint Markdownba
type: docs
weight: 140
url: /hu/php-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint MD‑be
- prezentáció MD‑be
- dia MD‑be
- PPT MD‑be
- PPTX MD‑be
- PowerPoint mentése Markdownként
- prezentáció mentése Markdownként
- dia mentése Markdownként
- PPT mentése MD‑ként
- PPTX mentése MD‑ként
- PPT exportálása MD‑be
- PPTX exportálása MD‑be
- PowerPoint
- prezentáció
- Markdown
- PHP
- Aspose.Slides
description: "PowerPoint diák konvertálása — PPT, PPTX — tiszta Markdownra az Aspose.Slides for PHP segítségével Java-n keresztül, automatizálja a dokumentációt és megőrizze a formázást."
---
## **Bevezetés**

Aspose.Slides lehetővé teszi, hogy PowerPoint prezentációkat Markdown formátumba konvertáljon, ami hasznos lehet dokumentációs munkafolyamatokhoz, statikus weboldalak generálásához, tartalom migrációhoz és verziókezeltt szöveges kiadványok közzétételéhez. Az API közvetlen exportot támogat PPT és PPTX prezentációkból MD fájlokba, és további beállításokat kínál a diák tartalmának a létrejövő Markdown dokumentumban való megjelenítésének vezérlésére.

Exportálhatja a prezentációkat egyszerű Markdown formátumban, választhat több Markdown változat közül, például a CommonMark és a GitHub-flavored Markdown, és beállíthatja, hogyan kezelje a képeket az export során. Olyan prezentációk esetén, amelyek vizuális tartalmat tartalmaznak, az Aspose.Slides lehetővé teszi a képek külön mappába mentését és azok hivatkozását a generált Markdown fájlban.

{{% alert color="warning" %}}
PowerPoint‑to‑Markdown export alapértelmezés szerint **képek nélkül** történik. Ha képeket tartalmazó PowerPoint dokumentumot szeretne exportálni, be kell állítania az `ExportType = MarkdownExportType::Visual` értéket, és meg kell adnia a `BasePath`‑t, ahol a Markdown dokumentumban hivatkozott képek mentésre kerülnek.
{{% /alert %}}

## **Prezentáció konvertálása Markdown-ba**

Ez a szakasz bemutatja, hogyan konvertálja az Aspose.Slides a PowerPoint és OpenDocument prezentációkat (PPT, PPTX, ODP) tiszta Markdown formátumba, megőrizve az eredeti diák hierarchiáját, a szöveget és az alapformázást, így a tartalmat dokumentációban vagy verziókezelési munkafolyamatokban extra manuális erőfeszítés nélkül újra felhasználhatja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból a prezentáció ábrázolásához.
1. Használja a [save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) metódust a Markdown fájlként való exportáláshoz.

Ez a PHP kód bemutatja, hogyan lehet egy PowerPoint prezentációt Markdown formátumba konvertálni:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Prezentáció konvertálása Markdown változatra**

Az Aspose.Slides lehetővé teszi, hogy PowerPoint prezentációkat alapvető szintaxissal ellátott Markdown formátumba, valamint CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab és tizenhét egyéb Markdown változatba konvertáljon.

Az alábbi PHP kód bemutatja, hogyan lehet egy PowerPoint prezentációt CommonMark formátumba konvertálni:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

A 23 támogatott Markdown változat a [Flavor enumeration](https://reference.aspose.com/slides/hu/php-java/aspose.slides/flavor/) oldalon van felsorolva.

## **Prezentáció konvertálása képekkel Markdown-ba**

A [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownsaveoptions/) osztály olyan tulajdonságokat és felsorolásokat tesz elérhetővé, amelyekkel a létrejövő Markdown fájlt beállíthatja. Például a [MarkdownExportType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/markdownexporttype/) felsorolás meghatározza, hogyan kezelje a képeket: `Sequential`, `TextOnly` vagy `Visual`.

{{% alert color="warning" %}}
Alapértelmezés szerint a PowerPoint‑to‑Markdown export **nem tartalmaz képeket**. A képek beágyazásához hívja meg a `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` metódust, és állítsa be a `BasePath`‑t, amely meghatározza, hová kerülnek a Markdown fájlban hivatkozott képek mentése.
{{% /alert %}}

### **Képek konvertálása szekvenciálisan**

Ha azt szeretné, hogy a képek egymás után egyesével jelenjenek meg a létrejövő Markdownban, akkor a `Sequential` opciót kell választania. Az alábbi PHP kód bemutatja, hogyan lehet egy képeket tartalmazó prezentációt Markdown formátumba konvertálni:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **Képek konvertálása vizuálisan**

Ha azt szeretné, hogy a képek együtt jelenjenek meg a létrejövő Markdownban, akkor a `Visual` opciót kell választania. Ebben az esetben a képek az alkalmazás aktuális könyvtárába kerülnek mentésre (és a Markdown dokumentumban relatív útvonal jön létre számukra), vagy megadhatja a kívánt könyvtárat és mappanevet.

Az alábbi PHP kód mutatja be a műveletet:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **GYIK**

**Megmaradnak a hiperhivatkozások a Markdown export során?**

Igen. A szöveg [hyperlinks](/slides/hu/php-java/manage-hyperlinks/) standard Markdown linkekként kerül megőrzésre. A diák [transitions](/slides/hu/php-java/slide-transition/) és [animations](/slides/hu/php-java/powerpoint-animation/) nincsenek konvertálva.

**Gyorsíthatom a konvertálást több szálon való futtatással?**

A fájlok között párhuzamosíthat, de [don’t share](/slides/hu/php-java/multithreading/) ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példányt szálak között. Használjon külön példányokat/folyamatokat fájlonként az ütközések elkerülése érdekében.

**Mi történik a képekkel – hová kerülnek mentésre, és relatívak-e az útvonalak?**

A [Images](/slides/hu/php-java/image/) egy dedikált mappába exportálódik, és a Markdown fájl alapértelmezés szerint relatív útvonalakkal hivatkozik rájuk. Beállíthatja a kimeneti alapútvonalat és az eszközkönyvtár nevét, hogy egy előrelátható tárolószerkezetet tartson fenn.