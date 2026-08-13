---
title: Matematikai egyenletek exportálása prezentációkból C++-ban
linktitle: Egyenletek exportálása
type: docs
weight: 30
url: /hu/cpp/exporting-math-equations/
keywords:
- matematikai egyenletek exportálása
- egyenletek exportálása LaTeX-be
- PowerPoint LaTeX-be
- MathML
- LaTeX
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Matematikai egyenletek exportálása PowerPoint prezentációkból közvetlenül LaTeX vagy MathML formátumba az Aspose.Slides for C++ segítségével."
---
## **Bevezetés**

Az Aspose.Slides for C++ lehetővé teszi a matematikai egyenletek exportálását a bemutatókból. Például előfordulhat, hogy ki kell nyernie a diákon (egy adott bemutatóból) található matematikai egyenleteket, és egy másik programban vagy platformon fel kell használnia őket. 

{{% alert color="info" %}} 
Az egyenleteket közvetlenül exportálhatja LaTeX‑be vagy MathML‑be, egy népszerű szabvány, amelyet a weben és számos alkalmazásban használnak matematikai tartalomhoz.
{{% /alert %}}

## **Matematikai egyenletek exportálása LaTeX‑be**

Az Aspose.Slides közvetlenül képes PowerPoint matematikai egyenletet LaTeX‑be konvertálni; közbenső MathML fájlra vagy külső konverterre nincs szükség. Egy matematikai egyenlet szövegdobozban kerül tárolásra, mint egy [IMathPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathportion/). Használja a [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) metódust egy [IMathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathparagraph/) lekéréséhez, majd hívja meg a [IMathParagraph::ToLatex](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) metódust. A metódus egy karakterláncot ad vissza, amelyet menthet, megjeleníthet, egy másik alkalmazásnak elküldhet vagy tovább feldolgozhat.

A következő példa minden dián minden szövegdobozt vizsgál, megtalálja az összes matematikai részt, és minden egyenletet külön `.tex` fájlba ír:

```cpp
auto presentation = MakeObject<Presentation>(u"equations.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    int slideNumber = slideIndex + 1;
    int equationNumber = 1;
    auto textFrames = SlideUtil::GetAllTextBoxes(slide);

    for (const auto&& textFrame : textFrames)
    {
        for (const auto&& paragraph : textFrame->get_Paragraphs())
        {
            for (const auto&& portion : paragraph->get_Portions())
            {
                auto mathPortion = System::AsCast<IMathPortion>(portion);
                if (mathPortion == nullptr)
                    continue;

                auto mathParagraph = mathPortion->get_MathParagraph();
                auto latexPath = String::Format(u"slide_{0}_equation_{1}.tex", slideNumber, equationNumber);

                auto latexText = mathParagraph->ToLatex();
                File::WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}

presentation->Dispose();
```

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/getalltextboxes/) visszaadja az adott dián található összes szövegdobozt. A [IMathPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathportion/) típusellenőrzése megkülönbözteti a szerkeszthető egyenleteket a szokásos szövegtől és képektől.

A LaTeX motorok és dokumentumsablonok nem mind támogatják ugyanazokat a parancsokat, csomagokat vagy Unicode karaktereket. Tesztelje a visszaadott karakterláncot az alkalmazása által használható LaTeX motorral. Ha egy szimbólum vagy Office Math elem nem rendelkezik megfelelő ábrázolással abban a környezetben, cserélje ki a visszaadott karakterláncban egy projektspecifikus parancsra, vagy hagyja ki az egyenletet, és rögyezze a problémát az átnézéshez.

## **Matematikai egyenletek mentése MathML formátumban**

Miközben az emberek könnyen írnak kódot bizonyos egyenletformátumokhoz, például LaTeX‑hez, a MathML kódolása nehezebb, mivel azt általában alkalmazások generálják automatikusan. A programok könnyen olvassák és dolgozzák fel a MathML‑t, mert a kódja XML‑ben van, így a MathML gyakran használt kimeneti és nyomtatási formátum sok területen. 

Ez a mintakód megmutatja, hogyan exportálhat egy matematikai egyenletet egy bemutatóból MathML‑be:

``` cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathPortion.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::MathText;
using namespace System;
using namespace System::IO;

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **GYIK**

**Mi exportálódik pontosan MathML‑be – egy bekezdés vagy egy egyedi képletblokk?**

Exportálhat egy teljes matematikai bekezdést ([MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathparagraph/)) vagy egy egyedi blokkot ([MathBlock](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathblock/)) MathML‑be. Mindkét típus biztosít módszert a MathML‑be íráshoz.

**Hogyan tudom megállapítani, hogy egy dián lévő objektum matematikai képlet, és nem egyszerű szöveg vagy kép?**

Egy képlet egy [MathPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathportion/)-ban él, és rendelkezik egy [MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathparagraph/)-mal. Képek és egyszerű szövegrésszek [MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathparagraph/) nélkül nem exportálható képletek.

**Honnan származik a MathML egy bemutatóban – PowerPoint‑specifikus vagy szabványos?**

Az export a szabványos MathML‑t (XML) célozza. Az Aspose a Presentation MathML‑t használja – a szabvány prezentációs részhalmazát –, amely széles körben elterjedt alkalmazásokban és a weben.

**Támogatott-e a képletek exportálása táblázatokban, SmartArt‑ban, csoportokban stb.?**

Igen, ha ezekben az objektumokban olyan szövegrésszek vannak, amelyek [MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathparagraph/)-mal rendelkeznek (azaz valódi PowerPoint képletek), akkor exportálásra kerülnek. Ha egy képlet képként van beágyazva, nem kerül exportálásra.

**Módosítja-e a MathML‑be exportálás az eredeti bemutatót?**

Nem. A MathML írása a képlet tartalmának sorosítása; nem módosítja a bemutató fájlt.