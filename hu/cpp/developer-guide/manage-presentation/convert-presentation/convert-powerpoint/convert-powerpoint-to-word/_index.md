---
title: PowerPoint bemutatók Word dokumentumokká konvertálása C++-ban
linktitle: PowerPoint Word-be
type: docs
weight: 110
url: /hu/cpp/convert-powerpoint-to-word/
keywords:
- PowerPoint konvertálása
- bemutató konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint Word-re
- bemutató Word-re
- dia Word-re
- PPT Word-re
- PPTX Word-re
- PowerPoint DOCX-re
- bemutató DOCX-re
- dia DOCX-re
- PPT DOCX-re
- PPTX DOCX-re
- PowerPoint DOC-re
- bemutató DOC-re
- dia DOC-re
- PPT DOC-re
- PPTX DOC-re
- PPT mentése DOCX-ként
- PPTX mentése DOCX-ként
- PPT exportálása DOCX-be
- PPTX exportálása DOCX-be
- C++
- Aspose.Slides
description: "PowerPoint PPT és PPTX diák konvertálása szerkeszthető Word dokumentumokká C++-ban az Aspose.Slides használatával, a pontos elrendezés, képek és formázás megőrzésével."
---
## **Bevezetés**

Ha új módon szeretné felhasználni egy bemutató (PPT vagy PPTX) szöveges tartalmát vagy információit, előnyös lehet a bemutató Word formátumba (DOC vagy DOCX) konvertálása. 

* A Microsoft PowerPoint-hez képest a Microsoft Word alkalmazás jobban fel van szerelve eszközökkel vagy funkciókkal a tartalomhoz. 
* A Word szerkesztő funkcióin túl további előnyöket kínál a fejlett együttműködés, nyomtatás és megosztás funkciója. 

{{% alert color="info" %}} 

Érdemes kipróbálni a [**Presentation to Word Online Converter**](https://products.aspose.app/slides/hu/conversion/ppt-to-word) szolgáltatásunkat, hogy lássa, mit nyerhet a diák szöveges tartalmának kezeléséből. 

{{% /alert %}} 

## **Aspose.Slides és Aspose.Words**

PowerPoint fájl (PPTX vagy PPT) Word formátumba (DOCX vagy DOCX) konvertálásához szüksége van mind a [Aspose.Slides for C++](https://products.aspose.com/slides/hu/cpp/) és a [Aspose.Words for C++](https://products.aspose.com/words/cpp/) termékekre. 

Az önálló API-ként elérhető [Aspose.Slides](https://products.aspose.app/slides) C++-ra funkciókat biztosít, amelyek lehetővé teszik a szövegek kivonását a bemutatókból. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) egy fejlett dokumentumfeldolgozó API, amely lehetővé teszi az alkalmazások számára, hogy dokumentumokat generáljanak, módosítsanak, konvertáljanak, megjelenítsenek, nyomtassanak, és egyéb feladatokat végezzenek a Microsoft Word használata nélkül. 

## **PowerPoint bemutató konvertálása Word dokumentummá**

Használja ezt a kódrészletet a PowerPoint Word formátumba konvertálásához:

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // létrehozza a dia képét bájtos tömb adatfolyamként
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

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

doc->Save(u"output.docx");
presentation->Dispose();
```

## **GYIK**

### Milyen összetevőket kell telepíteni a PowerPoint és OpenDocument bemutatók Word dokumentummá konvertálásához?

Csak a megfelelő [Aspose.Slides for C++](https://releases.aspose.com/slides/hu/cpp/) és [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) csomagokat kell hozzáadnia a projekthez. Mindkét könyvtár önálló API-ként működik, és nem szükséges a Microsoft Office telepítése. 

### Támogatottak-e minden PowerPoint és OpenDocument bemutatóformátum?

Az Aspose.Slides [támogatja az összes bemutatóformátumot](/slides/hu/cpp/supported-file-formats/), beleértve a PPT, PPTX, ODP és egyéb gyakori fájltípusokat. Ez biztosítja, hogy a Microsoft PowerPoint különböző verzióiban létrehozott bemutatókkal is dolgozhasson.