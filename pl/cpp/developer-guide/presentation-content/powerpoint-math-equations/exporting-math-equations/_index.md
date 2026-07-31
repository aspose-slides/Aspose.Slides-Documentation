---
title: Eksportowanie równań matematycznych z prezentacji w C++
linktitle: Eksport równań
type: docs
weight: 30
url: /pl/cpp/exporting-math-equations/
keywords:
- eksport równań matematycznych
- MathML
- LaTeX
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Odkryj płynny eksport równań matematycznych z PowerPoint do MathML przy użyciu Aspose.Slides for C++ — zachowaj formatowanie i zwiększ kompatybilność."
---
## **Wprowadzenie**

Aspose.Slides for C++ umożliwia eksportowanie równań matematycznych z prezentacji. Na przykład możesz potrzebować wyodrębnić równania matematyczne ze slajdów (z konkretnej prezentacji) i wykorzystać je w innym programie lub platformie. 

{{% alert color="primary" %}} 
Możesz eksportować równania do MathML, popularnego formatu lub standardu dla równań matematycznych i podobnych treści widocznych w internecie oraz w wielu aplikacjach. 
{{% /alert %}}

## **Zapisz równania matematyczne jako MathML**

Chociaż ludzie łatwo piszą kod dla niektórych formatów równań, takich jak LaTeX, mają trudności z pisaniem kodu dla MathML, ponieważ ten ostatni ma być generowany automatycznie przez aplikacje. Programy łatwo odczytują i analizują MathML, ponieważ jego kod jest w XML, więc MathML jest powszechnie używany jako format wyjściowy i drukarski w wielu dziedzinach. 

Ten przykładowy kod pokazuje, jak wyeksportować równanie matematyczne z prezentacji do MathML:
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

## **FAQ**

**Co dokładnie jest eksportowane do MathML — akapit czy pojedynczy blok formuły?**

Możesz wyeksportować cały akapit matematyczny ([MathParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/mathparagraph/)) lub pojedynczy blok ([MathBlock](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/mathblock/)) do MathML. Oba typy udostępniają metodę zapisu do MathML.

**Jak mogę stwierdzić, że obiekt na slajdzie jest formułą matematyczną, a nie zwykłym tekstem lub obrazem?**

Formuła znajduje się w [MathPortion](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/mathportion/) i posiada [MathParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/mathparagraph/). Obrazy oraz zwykłe fragmenty tekstu bez [MathParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/mathparagraph/) nie są eksportowalnymi formułami.

**Skąd pochodzi MathML w prezentacji — jest specyficzny dla PowerPointa czy jest standardem?**

Eksport jest skierowany do standardowego MathML (XML). Aspose używa Presentation MathML — podzestawu prezentacyjnego standardu, który jest szeroko stosowany w aplikacjach i w sieci.

**Czy eksportowanie formuł wewnątrz tabel, SmartArt, grup itp. jest obsługiwane?**

Tak, jeśli te obiekty zawierają fragmenty tekstu z [MathParagraph](https://reference.aspose.com/slides/pl/cpp/aspose.slides.mathtext/mathparagraph/) (czyli prawdziwe formuły PowerPoint), są eksportowane. Jeśli formuła jest osadzona jako obraz, nie jest.

**Czy eksport do MathML modyfikuje oryginalną prezentację?**

Nie. Zapisywanie MathML to serializacja zawartości formuły; nie modyfikuje pliku prezentacji.