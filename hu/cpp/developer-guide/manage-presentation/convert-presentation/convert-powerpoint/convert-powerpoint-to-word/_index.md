---
title: PowerPoint prezentációk Word dokumentumokká konvertálása C++-ban
linktitle: PowerPoint Word-be
type: docs
weight: 110
url: /hu/cpp/convert-powerpoint-to-word/
keywords:
- PowerPoint átalakítása
- prezentáció átalakítása
- dia átalakítása
- PPT átalakítása
- PPTX átalakítása
- PowerPoint Word-be
- prezentáció Word-be
- dia Word-be
- PPT Word-be
- PPTX Word-be
- PowerPoint DOCX-be
- prezentáció DOCX-be
- dia DOCX-be
- PPT DOCX-be
- PPTX DOCX-be
- PowerPoint DOC-be
- prezentáció DOC-be
- dia DOC-be
- PPT DOC-be
- PPTX DOC-be
- PPT mentése DOCX-ként
- PPTX mentése DOCX-ként
- PPT exportálása DOCX-be
- PPTX exportálása DOCX-be
- C++
- Aspose.Slides
description: "Konvertálja a PowerPoint PPT és PPTX diákot szerkeszthető Word dokumentumokká C++-ban az Aspose.Slides használatával, megőrizve a pontos elrendezést, képeket és formázást."
---
## **Bevezetés**

Ha a prezentáció (PPT vagy PPTX) szöveges tartalmát vagy információit új módon szeretné felhasználni, hasznos lehet a prezentációt Word (DOC vagy DOCX) formátumba konvertálni. 

* A Microsoft PowerPointhez képest a Microsoft Word alkalmazás több eszközzel vagy funkcióval rendelkezik a tartalom kezeléséhez. 
* A Word szerkesztési funkciói mellett a fejlett együttműködési, nyomtatási és megosztási lehetőségekből is profitálhat. 

{{% alert color="primary" %}} 

Érdemes lehet kipróbálni a mi [**Prezentáció Word Online Konvertáló**](https://products.aspose.app/slides/hu/conversion/ppt-to-word), hogy megnézze, milyen előnyökre tehet szert a diáktartalom szöveges feldolgozásával. 

{{% /alert %}} 

## **Aspose.Slides és Aspose.Words**

A PowerPoint fájl (PPTX vagy PPT) Word (DOC vagy DOCX) formátumba történő konvertálásához szükség van a [Aspose.Slides for C++](https://products.aspose.com/slides/hu/cpp/) és a [Aspose.Words for C++](https://products.aspose.com/words/cpp/) komponensekre. 

Az önálló API-ként működő [Aspose.Slides](https://products.aspose.app/slides) for C++ olyan funkciókat kínál, amelyek lehetővé teszik a szövegek kinyerését a prezentációkból. 

Az [Aspose.Words](https://docs.aspose.com/words/cpp/) egy fejlett dokumentumfeldolgozó API, amely lehetővé teszi az alkalmazások számára, hogy dokumentumokat generáljanak, módosítsanak, konvertáljanak, rendereljenek, nyomtassanak, és egyéb feladatokat hajtsanak végre a dokumentumokkal a Microsoft Word használata nélkül.

## **PowerPoint prezentáció konvertálása Word dokumentummá**

Használja ezt a kódrészletet a PowerPoint Word‑be konvertálásához:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // létrehozza és beszúrja a diaképét
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // beszúrja a dia szövegeit
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}
```

## **GYIK**

**Milyen összetevőket kell telepíteni a PowerPoint és OpenDocument prezentációk Word dokumentumokká konvertálásához?**

Csak a megfelelő csomagokat kell hozzáadnia a projektjéhez a [Aspose.Slides for C++](https://releases.aspose.com/slides/hu/cpp/) és a [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) számára. Mindkét könyvtár önálló API‑ként működik, és nem szükséges a Microsoft Office telepítése.

**Támogatottak‑e az összes PowerPoint és OpenDocument prezentációformátum?**

Az Aspose.Slides [minden prezentációformátumot támogat](/slides/hu/cpp/supported-file-formats/), beleértve a PPT, PPTX, ODP és más gyakori fájltípusokat. Ez biztosítja, hogy különböző Microsoft PowerPoint verziókkal készült prezentációkat is kezelni tudjon.