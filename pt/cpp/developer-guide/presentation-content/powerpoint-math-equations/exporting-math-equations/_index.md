---
title: Exportar Equações Matemáticas de Apresentações em C++
linktitle: Exportar Equações
type: docs
weight: 30
url: /pt/cpp/exporting-math-equations/
keywords:
- exportar equações matemáticas
- MathML
- LaTeX
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Desbloqueie a exportação perfeita de equações matemáticas do PowerPoint para MathML usando Aspose.Slides para C++ — preserve a formatação e aumente a compatibilidade."
---
## **Introdução**

Aspose.Slides for C++ permite exportar equações matemáticas de apresentações. Por exemplo, pode ser necessário extrair as equações matemáticas dos slides (de uma apresentação específica) e usá-las em outro programa ou plataforma. 

{{% alert color="primary" %}} 

Você pode exportar equações para MathML, um formato ou padrão popular para equações matemáticas e conteúdo semelhante visto na web e em muitas aplicações. 

{{% /alert %}}

## **Salvar Equações Matemáticas como MathML**

Embora os humanos escrevam facilmente o código para alguns formatos de equação, como LaTeX, eles têm dificuldade em escrever o código para MathML, pois este último deve ser gerado automaticamente por aplicativos. Os programas leem e analisam MathML facilmente porque seu código está em XML, portanto MathML é comumente usado como formato de saída e impressão em muitas áreas. 

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

## **Perguntas Frequentes**

**O que exatamente é exportado para MathML—um parágrafo ou um bloco de fórmula individual?**

Você pode exportar tanto um parágrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathparagraph/)) quanto um bloco individual ([MathBlock](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathblock/)) para MathML. Ambos os tipos fornecem um método para gravar em MathML.

**Como posso identificar se um objeto em um slide é uma fórmula matemática em vez de texto comum ou uma imagem?**

Uma fórmula está em uma [MathPortion](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathportion/) e possui um [MathParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathparagraph/). Imagens e trechos de texto comuns sem um [MathParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathparagraph/) não são fórmulas exportáveis.

**De onde vem o MathML em uma apresentação—é específico do PowerPoint ou um padrão?**

A exportação tem como alvo o MathML padrão (XML). Aspose usa Presentation MathML—o subconjunto de apresentação do padrão—que é amplamente utilizado em diversas aplicações e na web.

**A exportação de fórmulas dentro de tabelas, SmartArt, grupos etc., é suportada?**

Sim, se esses objetos contiverem trechos de texto com um [MathParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathparagraph/) (ou seja, fórmulas reais do PowerPoint), eles são exportados. Se uma fórmula estiver incorporada como imagem, não será.

**A exportação para MathML modifica a apresentação original?**

Não. Gravar MathML é uma serialização do conteúdo da fórmula; isso não modifica o arquivo da apresentação.