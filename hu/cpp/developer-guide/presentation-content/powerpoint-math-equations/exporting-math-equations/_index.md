---
title: Matematikai egyenletek exportálása prezentációkból C++-ban
linktitle: Egyenletek exportálása
type: docs
weight: 30
url: /hu/cpp/exporting-math-equations/
keywords:
- matematikai egyenletek exportálása
- MathML
- LaTeX
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Exportálja zökkenőmentesen a matematikai egyenleteket PowerPointból MathML-be az Aspose.Slides for C++ segítségével – őrizze meg a formázást és növelje a kompatibilitást."
---
## **Bevezetés**

Az Aspose.Slides for C++ lehetővé teszi, hogy matematikai egyenleteket exportáljon prezentációkból. Például előfordulhat, hogy ki kell nyernie a diákon lévő matematikai egyenleteket (egy adott prezentációból), és egy másik programban vagy platformon fel kell használni őket.

{{% alert color="primary" %}} 
Exportálhatja az egyenleteket MathML-be, egy népszerű formátumba vagy szabványba a matematikai egyenletek és hasonló tartalom számára, amelyet a weben és sok alkalmazásban láthat. 
{{% /alert %}}

## **Mentse a matematikai egyenleteket MathML-ként**

Míg az emberek könnyen írják a kódot bizonyos egyenletformátumokhoz, például a LaTeX-hez, nehezen tudják megírni a MathML kódját, mivel az utóbbit az alkalmazásoknak automatikusan kell generálniuk. A programok könnyen olvassák és elemezik a MathML-t, mert kódja XML-ben van, így a MathML-t gyakran használják kimeneti és nyomtatási formátumként sok területen. 

Ez a példakód megmutatja, hogyan exportálhat egy matematikai egyenletet egy prezentációból MathML-be: 

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

**Mi pontosan exportálódik MathML-be – egy bekezdés vagy egy önálló képletblokk?**

Exportálhat egy teljes matematikai bekezdést ([MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathparagraph/)) vagy egy önálló blokkot ([MathBlock](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathblock/)) MathML-be. Mindkét típus biztosít egy módszert a MathML írásához.

**Hogyan tudom megállapítani, hogy egy dián lévő objektum matematikai képlet-e a szokványos szöveg vagy kép helyett?**

A képlet egy [MathPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathportion/)-ban él, és rendelkezik egy [MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathparagraph/)-al. A képek és a szabályos szövegrészek, amelyek nem tartalmaznak [MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathparagraph/)-t, nem exportálható képletek.

**Honnan származik a MathML egy prezentációban – PowerPoint‑specifikus vagy szabványos?**

Az export a szabványos MathML-t (XML) célozza. Az Aspose a Presentation MathML-t használja – a szabvány prezentációs részhalmazát –, amelyet széles körben használnak az alkalmazások és a web.

**Támogatott-e a képletek exportálása táblázatokban, SmartArt‑ban, csoportokban stb.?**

Igen, ha ezek az objektumok szövegrészeket tartalmaznak [MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathparagraph/)-ral (azaz valódi PowerPoint képletekkel), akkor exportálódnak. Ha egy képlet képként van beágyazva, az nem.

**Módosítja a MathML‑be exportálás az eredeti prezentációt?**

Nem. A MathML írása a képlet tartalmának sorosítása; nem módosítja a prezentációfájlt.