---
title: "Matematikai egyenletek exportálása a bemutatókból C++-ban"
linktitle: "Egyenletek exportálása"
type: docs
weight: 30
url: /hu/cpp/exporting-math-equations/
keywords:
- "matematikai egyenletek exportálása"
- MathML
- LaTeX
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Zökkenőmentes exportálás a PowerPointból MathML-be a matematikai egyenletekhez az Aspose.Slides for C++ segítségével – megőrizze a formázást és növelje a kompatibilitást."
---
## **Bevezetés**

Az Aspose.Slides for C++ lehetővé teszi, hogy matematikai képleteket exportáljon a bemutatókból. Például előfordulhat, hogy ki szeretné nyerni a diák (egy adott bemutatóból) matematikai egyenleteit, és egy másik programban vagy platformon használja fel.

{{% alert color="primary" %}} 
Az egyenleteket exportálhatja MathML-be, egy népszerű formátumba vagy szabványba a matematikai egyenletek és hasonló tartalmak számára, amelyet a weben és számos alkalmazásban láthat. 
{{% /alert %}}

## **Matematikai egyenletek mentése MathML formátumba**

Míg az emberek könnyedén írják a kódot bizonyos egyenletformátumokhoz, például a LaTeX-hez, nehezebb nekik a MathML kódot megírni, mivel ezt utóbbit alkalmazásoknak automatikusan kell generálniuk. A programok könnyen olvassák és elemzik a MathML-t, mivel a kódja XML-ben van, így a MathML gyakran használatos kimeneti és nyomtatási formátumként sok területen. 

Ez a példa kód megmutatja, hogyan exportáljon egy matematikai egyenletet egy bemutatóból MathML-be:

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

**Mi kerül pontosan exportálásra MathML-be – egy bekezdés vagy egy önálló képletblokk?**

Exportálhat egy teljes matematikai bekezdést ([MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathparagraph/)) vagy egy önálló blokkot ([MathBlock](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathblock/)) MathML-be. Mindkét típus biztosít egy módszert a MathML írására.

**Hogyan deríthetem ki, hogy egy dián lévő objektum matematikai képlet-e, nem pedig egyszerű szöveg vagy kép?**

Egy képlet egy [MathPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathportion/) elemen belül él, és rendelkezik egy [MathParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides.mathtext/mathparagraph/) elemmel. Képek és egyszerű szövegrészek, amelyek nem tartalmaznak [MathParagraph]-t, nem exportálható képletek.

**Honnan származik a MathML egy bemutatóban – PowerPoint-specifikus vagy szabvány?**

Az export a szabványos MathML-re (XML) irányul. Az Aspose a Presentation MathML-t használja – a szabvány prezentációs részhalmazát –, amely széles körben elterjedt az alkalmazások és a web között.

**Támogatott-e a képletek exportálása táblákba, SmartArt-ba, csoportokba stb.?**

Igen, ha azok az objektumok szövegrészeket tartalmaznak [MathParagraph]-lel (azaz valódi PowerPoint képletek), exportálásra kerülnek. Ha egy képlet képként van beágyazva, akkor nem.

**Módosítja-e a MathML-be exportálás az eredeti bemutatót?**

Nem. A MathML írása a képlet tartalmának sorosítása; nem módosítja a bemutató fájlt.