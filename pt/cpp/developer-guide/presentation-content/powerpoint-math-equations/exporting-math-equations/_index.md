---
title: Exportar Equações Matemáticas de Apresentações em C++
linktitle: Exportar Equações
type: docs
weight: 30
url: /pt/cpp/exporting-math-equations/
keywords:
- exportar equações matemáticas
- exportar equações para LaTeX
- PowerPoint para LaTeX
- MathML
- LaTeX
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Exporte equações matemáticas de apresentações PowerPoint para LaTeX ou MathML diretamente com Aspose.Slides para C++."
---
## **Introdução**

Aspose.Slides for C++ permite exportar equações matemáticas de apresentações. Por exemplo, pode ser necessário extrair as equações matemáticas dos slides (de uma apresentação específica) e usá‑las em outro programa ou plataforma. 

{{% alert color="primary" %}} 
Você pode exportar equações diretamente para LaTeX ou para MathML, um padrão popular para conteúdo matemático usado na web e em muitas aplicações.
{{% /alert %}}

## **Exportar Equações Matemáticas para LaTeX**

Aspose.Slides pode converter uma equação matemática do PowerPoint diretamente para LaTeX; não é necessário um arquivo MathML intermediário nem um conversor externo. Uma equação matemática é armazenada em um quadro de texto como um [IMathPortion](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathportion/). Use [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) para obter um [IMathParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathparagraph/), e então chame [IMathParagraph::ToLatex](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). O método retorna uma string que você pode salvar, exibir, enviar para outro aplicativo ou processar posteriormente.

O exemplo a seguir examina cada quadro de texto em cada slide, encontra todas as partes matemáticas e grava cada equação em um arquivo `.tex` separado:

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/pt/cpp/aspose.slides.util/slideutil/getalltextboxes/) retorna todos os quadros de texto encontrados em um slide. A verificação de tipo [IMathPortion](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathportion/) separa as verdadeiras equações editáveis de texto e imagens comuns.

Os mecanismos LaTeX e os modelos de documento nem todos suportam os mesmos comandos, pacotes ou caracteres Unicode. Teste a string retornada com o motor LaTeX usado pela sua aplicação. Se um símbolo ou elemento Office Math não tiver representação adequada naquele ambiente, substitua‑o na string retornada por um comando específico do projeto ou ignore a equação e registre o problema para revisão.

## **Salvar Equações Matemáticas como MathML**

Embora os humanos escrevam facilmente o código para alguns formatos de equação como LaTeX, eles têm dificuldade em escrever o código para MathML, pois este último deve ser gerado automaticamente por aplicativos. Programas leem e analisam MathML facilmente porque seu código está em XML, portanto MathML é comumente usado como formato de saída e impressão em muitas áreas. 

Este código de exemplo mostra como exportar uma equação matemática de uma apresentação para MathML:

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

**O que exatamente é exportado para MathML—um parágrafo ou um bloco de fórmula individual?**

Você pode exportar tanto um parágrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathparagraph/)) quanto um bloco individual ([MathBlock](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathblock/)) para MathML. Ambos os tipos fornecem um método para gravar em MathML.

**Como posso saber se um objeto em um slide é uma fórmula matemática em vez de texto comum ou uma imagem?**

Uma fórmula reside em um [MathPortion](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathportion/) e possui um [MathParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathparagraph/). Imagens e trechos de texto comuns sem um [MathParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathparagraph/) não são fórmulas exportáveis.

**De onde vem o MathML em uma apresentação—é específico do PowerPoint ou um padrão?**

A exportação tem como alvo o MathML padrão (XML). Aspose usa Presentation MathML—o subconjunto de apresentação do padrão—que é amplamente usado em aplicativos e na web.

**A exportação de fórmulas dentro de tabelas, SmartArt, grupos etc., é suportada?**

Sim, se esses objetos contiverem trechos de texto com um [MathParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathparagraph/) (ou seja, fórmulas genuínas do PowerPoint), eles são exportados. Se uma fórmula estiver incorporada como imagem, não será.

**Exportar para MathML modifica a apresentação original?**

Não. Gravar MathML é uma serialização do conteúdo da fórmula; não modifica o arquivo da apresentação.