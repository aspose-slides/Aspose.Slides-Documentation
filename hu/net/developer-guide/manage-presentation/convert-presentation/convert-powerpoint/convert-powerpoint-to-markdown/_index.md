---
title: PowerPoint-prezentációk konvertálása Markdownra .NET-ben
linktitle: PowerPoint Markdownra
type: docs
weight: 140
url: /hu/net/convert-powerpoint-to-markdown/
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
- .NET
- C#
- Aspose.Slides
description: "Konvertálja a PowerPoint diák—PPT, PPTX—tiszta Markdownra az Aspose.Slides for .NET segítségével, automatizálja a dokumentációt és tartsa meg a formázást."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint‑prezentációkat Markdown‑ba konvertálja, ami hasznos lehet a dokumentációs munkafolyamatok, statikus weboldalak generálása, tartalom migráció és verzió‑kezelő szövegközzététel során. Az API közvetlen exportálást támogat PPT és PPTX prezentációkból MD fájlokba, és további beállításokat biztosít a diák tartalmának a létrehozott Markdown‑dokumentumban történő ábrázolásának vezérléséhez.

Exportálhatja a prezentációkat egyszerű Markdown‑ként, választhat több Markdown‑változat közül, például a CommonMark‑ot és a GitHub Flavored Markdown‑ot, valamint beállíthatja, hogyan kezelje a képeket az exportálás során. Az olyan prezentációk esetén, amelyek vizuális tartalmat tartalmaznak, az Aspose.Slides lehetővé teszi a képek külön mappába történő mentését és azok hivatkozását a generált Markdown‑fájlban.

{{% alert color="warning" %}}
A PowerPoint‑to‑Markdown export alapértelmezés szerint **képek nélkül** történik. Ha képeket tartalmazó PowerPoint‑dokumentumot szeretne exportálni, be kell állítania az `ExportType = MarkdownExportType.Visual` értéket, és meg kell adnia a `BasePath`‑t, ahová a Markdown‑dokumentumban hivatkozott képek mentésre kerülnek.
{{% /alert %}}

## **PowerPoint konvertálása Markdown‑ba**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, amely a prezentáció objektumot képviseli.
2. Használja a [Save ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/methods/save)metódust az objektum markdown‑fájlként történő mentéséhez.

Ez a C# kód bemutatja, hogyan konvertálható a PowerPoint Markdown‑ba:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **PowerPoint konvertálása Markdown‑variánsra**

Az Aspose.Slides lehetővé teszi a PowerPoint markdown‑ra (alapvető szintaxist tartalmazó), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab és további 17 markdown‑variánsra történő konvertálását.

Ez a C# kód bemutatja, hogyan konvertálható a PowerPoint CommonMark‑ra:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

A támogatott 23 markdown‑variánst a [Flavor enumerációban](https://reference.aspose.com/slides/hu/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) találja meg a [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) osztályból.

## **Prezentáció konvertálása képekkel Markdown‑ba**

A [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) osztály tulajdonságokat és enumerációkat biztosít, amelyek lehetővé teszik bizonyos beállítások vagy opciók használatát a létrehozott markdown‑fájlhoz. A [MarkdownExportType](https://reference.aspose.com/slides/hu/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) enum például beállítható olyan értékekre, amelyek meghatározzák a képek megjelenítésének vagy kezelésének módját: `Sequential`, `TextOnly`, `Visual`.

### **Képek konvertálása sorban**

Ha azt szeretné, hogy a képek egymás után, egyenként jelenjenek meg a létrehozott markdown‑ban, a soros (sequential) opciót kell választania. Ez a C# kód bemutatja, hogyan konvertálható egy képeket tartalmazó prezentáció markdown‑ra:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **Képek konvertálása vizuálisan**

Ha azt szeretné, hogy a képek együtt jelenjenek meg a létrehozott markdown‑ban, a vizuális (visual) opciót kell választania. Ebben az esetben a képek az alkalmazás aktuális könyvtárába lesznek mentve (és a markdown‑dokumentumban relatív útvonal épül ki hozzájuk), vagy megadhatja a kívánt útvonalat és mappanevet.

Ez a C# kód demonstrálja a műveletet:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```

## **FAQ**

**Megmaradnak a hiperhivatkozások a Markdown‑export során?**

Igen. A szöveg [hyperlinks](/slides/hu/net/manage-hyperlinks/) hiperhivatkozásai standard Markdown linkekként maradnak meg. A dia [transitions](/slides/hu/net/slide-transition/) és [animations](/slides/hu/net/powerpoint-animation/) nem kerülnek konvertálásra.

**Gyorsíthatom a konverziót több szálon való futtatással?**

Fájlok szintjén párhuzamosíthat, de [don’t share](/slides/hu/net/multithreading/) ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példányt a szálak között. Használjon különálló példányokat/folyamatokat fájlonként a versengés elkerülése érdekében.

**Mi történik a képekkel – hol mentődnek, és relatív útvonalak-e?**

[Images](/slides/hu/net/image/) egy dedikált mappába kerül exportálásra, és a Markdown‑fájl alapértelmezés szerint relatív útvonalakkal hivatkozik rájuk. A kiinduló (base) kimeneti útvonalat és az eszközmappa nevét konfigurálhatja, hogy előre látható tárolószerkezetet biztosítson.