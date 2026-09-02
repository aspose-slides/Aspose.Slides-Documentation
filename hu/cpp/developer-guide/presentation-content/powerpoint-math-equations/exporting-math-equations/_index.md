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
description: "Exportálja a matematikai egyenleteket PowerPoint-prezentációkból közvetlenül LaTeX-be vagy MathML-be az Aspose.Slides for C++ használatával."
---
## **Bevezetés**

Az Aspose.Slides for C++ lehetővé teszi, hogy matematikai egyenleteket exportáljon prezentációkból. Például szükség lehet a diákon (egy adott prezentációból) található matematikai egyenletek kinyerésére, és azok felhasználására egy másik programban vagy platformon. 

{{% alert color="primary" %}} 

Az egyenleteket közvetlenül exportálhatja LaTeX-be vagy MathML-be, amely egy népszerű szabvány a weben és számos alkalmazásban használt matematikai tartalomhoz.

{{% /alert %}}

## **Matematikai egyenletek exportálása LaTeX-be**

Az Aspose.Slides közvetlenül átalakíthat egy PowerPoint matematikai egyenletet LaTeX-be; közbenső MathML-fájlra és külső konverterre nincs szükség. A matematikai egyenlet egy szövegdobozban van tárolva, mint egy [IMathPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathportion/). Használja a [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) metódust egy [IMathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathparagraph/) lekéréséhez, majd hívja a [IMathParagraph::ToLatex](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathparagraph/tolatex/) metódust. A módszer egy karakterláncot ad vissza, amelyet menthet, megjeleníthet, elküldhet egy másik alkalmazásnak vagy további feldolgozásra használhat.

A következő példa minden szövegdobozt vizsgál minden dián, megtalálja az összes matematikai részt, és minden egyenletet egy külön `.tex` fájlba ír:

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/getalltextboxes/) visszaadja a dián talált összes szövegdobozt. Az [IMathPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/imathportion/) típusellenőrzés megkülönbözteti a valódi szerkeszthető egyenleteket a szokásos szövegtől és képektől.

A LaTeX motorok és dokumentumsablonok nem minden esetben támogatják ugyanazokat a parancsokat, csomagokat vagy Unicode karaktereket. Tesztelje a visszaadott karakterláncot a alkalmazása által használt LaTeX motorral. Ha egy szimbólum vagy Office Math elemnek nincs megfelelő ábrázolása az adott környezetben, cserélje le a visszaadott karakterláncban egy projektspecifikus parancsra, vagy hagyja ki az egyenletet, és jegyezze fel a problémát felülvizsgálatra.

## **Matematikai egyenletek mentése MathML-be**

Míg az emberek könnyen írják meg néhány egyenlet formátum kódját, például a LaTeX-et, nehezebben tudják megírni a MathML kódját, mivel azt utóbbit alkalmazásoknak automatikusan kell generálniuk. A programok könnyen olvassák és elemezik a MathML-t, mivel annak kódja XML-ben van, így a MathML gyakran használt kimeneti és nyomtatási formátum számos területen. 

Ez a mintakód megmutatja, hogyan exportálhat egy matematikai egyenletet egy prezentációból MathML-be:

``` cpp
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

**Mi pontosan kerül exportálásra MathML-be – egy bekezdés vagy egy egyedi képletblokk?**

Exportálhat egy teljes matematikai bekezdést ([MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathparagraph/)) vagy egy egyedi blokkot ([MathBlock](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathblock/)) MathML-be. Mindkét típus rendelkezik egy módszerrel, amely MathML-be ír.

**Hogyan tudom megállapítani, hogy egy dián lévő objektum matematikai képlet-e a szokásos szöveg vagy kép helyett?**

Egy képlet egy [MathPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathportion/)‑ban található, és rendelkezik egy [MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathparagraph/)‑val. A képek és a szokásos szövegrészek, amelyek nem rendelkeznek [MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathparagraph/)‑val, nem exportálható képletek.

**Honnan származik a MathML egy prezentációban – PowerPoint‑specifikus vagy szabványos?**

Az export a szabványos MathML‑t (XML) célozza. Az Aspose a Presentation MathML‑t használja – a szabvány prezentációs részhalmazát –, amely széles körben elterjedt az alkalmazásokban és a weben.

**Támogatott-e a képletek exportálása táblázatokban, SmartArt‑ban, csoportokban stb.?**

Igen, ha ezek az objektumok olyan szövegrészeket tartalmaznak, amelyek rendelkeznek [MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathparagraph/)‑val (azaz valódi PowerPoint képletek), akkor exportálásra kerülnek. Ha a képlet képként van beágyazva, az nem.

**Módosítja a MathML-be exportálás az eredeti prezentációt?**

Nem. A MathML írása a képlet tartalmának sorosítása; nem módosítja a prezentációfájlt.