---
title: PowerPoint prezentációk konvertálása Markdown-ba C++-ban
linktitle: PowerPoint Markdown-ba
type: docs
weight: 140
url: /hu/cpp/convert-powerpoint-to-markdown/
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
- PowerPoint mentése Markdown formátumban
- prezentáció mentése Markdown formátumban
- dia mentése Markdown formátumban
- PPT mentése MD formátumban
- PPTX mentése MD formátumban
- PPT exportálása MD-be
- PPTX exportálása MD-be
- PowerPoint
- prezentáció
- Markdown
- C++
- Aspose.Slides
description: "Konvertálja a PowerPoint diákot—PPT, PPTX—tiszta Markdown formátumba az Aspose.Slides for C++ segítségével, automatizálja a dokumentációt és megőrizze a formázást."
---
## **Bevezetés**

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint‑prezentációkat Markdown formátumba konvertálja, ami hasznos lehet dokumentációs munkafolyamatokhoz, statikus webhelyek generálásához, tartalom migrációhoz és verziókezelésű szövegközzétételhez. Az API közvetlen exportot támogat PPT és PPTX prezentációkból MD fájlokba, és további beállítási lehetőségeket nyújt a diák tartalmának a létrehozott Markdown‑dokumentumban való megjelenítésének szabályozásához.

Exportálhatja a prezentációkat egyszerű Markdown formátumban, választhat több Markdown‑változat közül, például a CommonMark‑ot és a GitHub Flavored Markdown‑ot, valamint beállíthatja, hogyan kezelje a képeket az exportálás során. A vizuális tartalmat tartalmazó prezentációk esetén az Aspose.Slides lehetővé teszi a képek külön mappába mentését és azok hivatkozását a generált Markdown‑fájlban.

{{% alert color="warning" %}} 

Alapértelmezés szerint a PowerPoint‑ról markdown‑export **képek nélkül** történik. Ha olyan PowerPoint‑dokumentumot szeretne exportálni, amely képeket tartalmaz, be kell állítania a `SaveOptions::MarkdownExportType::Visual)` értéket, és meg kell adnia a `BasePath`‑t, ahol a markdown‑dokumentumban hivatkozott képek mentésre kerülnek.

{{% /alert %}} 

## **PowerPoint konvertálása Markdown‑ba**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból, amely a prezentáció objektumot képviseli.
2. Használja a [Save ](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/#presentationsavesystemsharedptrexportxamlixamloptions-method)metódust a objektum markdown‑fájlként való mentéséhez.

Ez a C++ kód bemutatja, hogyan konvertálhatja a PowerPoint‑ot markdown formátumba:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.md", SaveFormat::Md);
```

## **PowerPoint konvertálása Markdown‑változatba**

Az Aspose.Slides lehetővé teszi a PowerPoint markdown (alap szintaxist tartalmazó), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab és további 17 markdown‑változatba való konvertálását.

Ez a C++ kód bemutatja, hogyan konvertálhatja a PowerPoint‑ot CommonMark‑ba: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_Flavor(Aspose::Slides::DOM::Export::Markdown::SaveOptions::Flavor::CommonMark);
pres->Save(u"pres.md", Aspose::Slides::Export::SaveFormat::Md, opt);
```

A támogatott 23 markdown‑változat a [Flavor enumeráció alatt listázva](https://reference.aspose.com/slides/hu/cpp/aspose.slides.dom.export.markdown.saveoptions/flavor/) a [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) osztályból.

## **Prezentáció konvertálása képekkel markdown‑ba**

A [MarkdownSaveOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) osztály tulajdonságokat és enumerációkat biztosít, amelyek lehetővé teszik bizonyos beállítások vagy opciók használatát a létrehozott markdown fájlhoz. A [MarkdownExportType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) enum például beállítható olyan értékekre, amelyek meghatározzák a képek megjelenítésének vagy kezelésének módját: `Sequential`, `TextOnly`, `Visual`.

### **Képek konvertálása sorban**

Ha azt szeretné, hogy a képek egyenként, egymás után jelenjenek meg a létrehozott markdown‑ban, a soros (sequential) opciót kell választania. Ez a C++ kód bemutatja, hogyan konvertálhat egy képeket tartalmazó prezentációt markdown‑ba:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<MarkdownSaveOptions> markdownSaveOptions = System::MakeObject<MarkdownSaveOptions>();

markdownSaveOptions->set_ShowHiddenSlides(true);
markdownSaveOptions->set_ShowSlideNumber(true);
markdownSaveOptions->set_Flavor(Flavor::Github);
markdownSaveOptions->set_ExportType(MarkdownExportType::Sequential);
markdownSaveOptions->set_NewLineType(NewLineType::Windows);

pres->Save(u"doc.md", System::MakeArray<int32_t>({1, 2, 3, 4, 5, 6, 7, 8, 9}), SaveFormat::Md, markdownSaveOptions);
```

### **Képek konvertálása vizuálisan**

Ha azt szeretné, hogy a képek együtt jelenjenek meg a létrehozott markdown‑ban, a vizuális (visual) opciót kell választania. Ebben az esetben a képek az alkalmazás aktuális könyvtárába kerülnek mentésre (és a markdown‑dokumentumban relatív útvonal jön létre számukra), vagy megadhatja a kívánt útvonalat és mappanevet.

Ez a C++ kód bemutatja a műveletet: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
const System::String outPath = u"x:\\documents";
auto opt = System::MakeObject<MarkdownSaveOptions>();
opt->set_ExportType(Aspose::Slides::DOM::Export::Markdown::SaveOptions::MarkdownExportType::Visual);
opt->set_ImagesSaveFolderName(u"md-images");
opt->set_BasePath(outPath);
pres->Save(System::IO::Path::Combine(outPath, u"pres.md"), Aspose::Slides::Export::SaveFormat::Md, opt);
```

## **GYIK**

**Megmaradnak a hiperhivatkozások a Markdown‑export során?**

Igen. A szöveg [hiperhivatkozások](/slides/hu/cpp/manage-hyperlinks/) megmarad standard Markdown‑hivatkozásként. A diák [átmenetei](/slides/hu/cpp/slide-transition/) és [animációi](/slides/hu/cpp/powerpoint-animation/) nem konvertálódnak.

**Gyorsíthatom a konverziót több szálon futtatva?**

Fájlok között párhuzamosítható, de [ne ossza meg](/slides/hu/cpp/multithreading/) ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt a szálak között. Használjon külön példányokat/folyamatokat fájlonként a versengés elkerülése érdekében.

**Mi történik a képekkel—hol mentődnek, és relatívak-e az útvonalak?**

[Képek](/slides/hu/cpp/image/) egy dedikált mappába exportálódik, a Markdown‑fájl pedig alapértelmezés szerint relatív útvonalakkal hivatkozik rájuk. A kiinduló útvonalat és az asset mappa nevét konfigurálhatja, hogy előre meghatározott tárolószerkezetet biztosítson.