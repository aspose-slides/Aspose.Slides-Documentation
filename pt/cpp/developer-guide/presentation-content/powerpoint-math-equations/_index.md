---
title: Adicionar Equações Matemáticas a Apresentações do PowerPoint em C++
linktitle: Equações Matemáticas do PowerPoint
type: docs
weight: 80
url: /pt/cpp/powerpoint-math-equations/
keywords:
- equação matemática
- símbolo matemático
- fórmula matemática
- texto matemático
- adicionar equação matemática
- adicionar símbolo matemático
- adicionar fórmula matemática
- adicionar texto matemático
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Insira e edite equações matemáticas no PowerPoint PPT e PPTX com Aspose.Slides para C++, suportando OMML, controles de formatação e exemplos claros de código C++."
---
## **Visão geral**

O PowerPoint armazena equações como Office Math Markup Language (OMML). Com o Aspose.Slides for C++, você pode criar o mesmo tipo de conteúdo matemático programaticamente: frações, radicais, funções, limites, operadores n‑ários, matrizes, arrays e blocos de matemática formatados.

No PowerPoint, os usuários normalmente adicionam equações via **Inserir > Equação**:

![A guia Inserir do PowerPoint com o comando Equação selecionado](powerpoint-math-equations_1.png)

O resultado é texto matemático editável no slide:

![Um slide do PowerPoint contendo uma equação matemática editável](powerpoint-math-equations_2.png)

O Aspose.Slides constrói esse texto matemático por meio de três objetos principais:

- Uma forma matemática, criada com [AddMathShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shapecollection/), que contém a equação.
- [MathPortion](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathportion/) armazena o conteúdo matemático dentro da moldura de texto da forma.
- [MathParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathparagraph/) contém um ou mais objetos [MathBlock](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathblock/).

A maioria dos exemplos abaixo usa [MathematicalText](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathematicaltext/) e os métodos fluentes de [IMathElement](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/) para manter o código curto e legível.

Para cenários de exportação para MathML, veja [Export Math Equations from Presentations in C++](/slides/pt/cpp/exporting-math-equations/).

## **Criar uma equação**

Este exemplo cria uma forma matemática e adiciona o teorema de Pitágoras:

![A equação c² = a² + b²](powerpoint-math-equations_3.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equation = System::MakeObject<MathematicalText>(u"c")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));

mathParagraph->Add(equation);

presentation->Save(u"pythagorean-theorem.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}
`AddMathShape` cria uma forma que já contém um parágrafo matemático. Acesse o primeiro `MathPortion`, obtenha seu `MathParagraph` e adicione blocos ou elementos matemáticos a ele.
{{% /alert %}}

## **Adicionar frações**

Use `Divide` para criar uma fração. Você pode escolher um estilo de fração com [MathFractionTypes](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathfractiontypes/).

![Uma fração inclinada mostrando 1 dividido por x](powerpoint-math-equations_4.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"1")
        - >Divide(u"x", MathFractionTypes::Skewed);

mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

presentation->Save(u"fraction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para uma fração empilhada, use `MathFractionTypes::Bar`:

```cpp
auto stackedFraction = System::MakeObject<MathematicalText>(u"x + 1")->Divide(u"y - 1", MathFractionTypes::Bar);
```

## **Adicionar radicais**

Use `Radical` para criar uma raiz quadrada, cúbica ou outra raiz. O elemento atual torna‑se a base e o argumento torna‑se o grau.

![Uma expressão radical de n‑ésima raiz com x sob o sinal radical](powerpoint-math-equations_5.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto radical = System::MakeObject<MathematicalText>(u"x")
        - >Radical(u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(radical));

presentation->Save(u"radical.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Adicionar funções e limites**

Use `AsArgumentOfFunction` ou `Function` para funções como `sin(x)`, `log(x)` ou nomes de funções personalizados. Para limites, coloque `lim` em um [MathLimit](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathlimit/) ou use `SetLowerLimit`.

![O limite de x quando x tende ao infinito](powerpoint-math-equations_8.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto limit = System::MakeObject<MathematicalText>(u"lim")
        - >SetLowerLimit(u"x→∞")
        - >Function(u"x");

mathParagraph->Add(System::MakeObject<MathBlock>(limit));

presentation->Save(u"functions-and-limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para um nome de função personalizado, torne o nome da função o elemento atual:

```cpp
auto customFunction = System::MakeObject<MathematicalText>(u"f")->Function(u"x + 1");
```

## **Adicionar operadores n‑ários e integrais**

Use `Nary` para somatórios, uniões, interseções e outros operadores grandes. Use `Integral` para integrais. Ambos os métodos permitem definir limites inferior e superior.

![Um somatório com limites inferior e superior](powerpoint-math-equations_7.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto summationBase = System::MakeObject<MathematicalText>(u"x")
        - >SetSuperscript(u"k")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"n-k"));

auto summation = summationBase->Nary(MathNaryOperatorTypes::Summation, u"k=0", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(summation));

presentation->Save(u"nary-operators.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Operadores n‑ários são para grandes operadores com limites opcionais. Operadores simples como `+`, `-` e `=` geralmente são adicionados como `MathematicalText` e concatenados na expressão.

Para uma integral, use `Integral`:

```cpp
auto integralBase = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = integralBase->Integral(MathIntegralTypes::Simple, u"0", u"1");
```

## **Adicionar matrizes**

Use [MathMatrix](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathmatrix/) para linhas e colunas. Matrizes não incluem colchetes por padrão, portanto inclua a matriz entre parênteses, colchetes ou chaves quando necessário.

![Uma matriz matemática de duas linhas com uma célula vazia](powerpoint-math-equations_10.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto matrix = System::MakeObject<MathMatrix>(2, 3);
matrix->idx_set(0, 0, System::MakeObject<MathematicalText>(u"1"));
matrix->idx_set(0, 1, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 0, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 1, System::MakeObject<MathematicalText>(u"2"));
matrix->idx_set(1, 2, System::MakeObject<MathematicalText>(u"y"));

mathParagraph->Add(System::MakeObject<MathBlock>(matrix));

presentation->Save(u"matrix.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Adicionar arrays de equações**

Use `ToMathArray` quando precisar de equações alinhadas ou de uma pilha vertical de expressões.

![Um array matemático vertical com x acima de y](powerpoint-math-equations_11.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 140.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equationArray = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >ToMathArray();

mathParagraph->Add(System::MakeObject<MathBlock>(equationArray));

presentation->Save(u"equation-array.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Adicionar funções trigonométricas**

Use `AsArgumentOfFunction` quando o argumento for o elemento atual e o nome da função for conhecido.

![A função trigonométrica cos aplicada a 2x](powerpoint-math-equations_6.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto cosine = System::MakeObject<MathematicalText>(u"2x")
        - >AsArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

mathParagraph->Add(System::MakeObject<MathBlock>(cosine));

presentation->Save(u"trigonometric-function.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Adicionar subscritos e sobrescritos**

Use os auxiliares de subscrito e sobrescrito para índices e potências. Quando os índices devem aparecer ao lado esquerdo da base, use `SetSubSuperscriptOnTheLeft`.

![Um Y maiúsculo com subscrito esquerdo 1 e sobrescrito n](powerpoint-math-equations_9.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto scripts = System::MakeObject<MathematicalText>(u"Y")
        - >SetSubSuperscriptOnTheLeft(u"1", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(scripts));

presentation->Save(u"subscript-superscript.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Adicionar delimitadores**

Use `Enclose` para colocar uma expressão dentro de delimitadores. Você também pode definir um caractere separador para expressões delimitadas que contenham vários elementos.

![Uma expressão delimitadora contendo x, y e z separados por barras verticais](powerpoint-math-equations_13.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto delimiter = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >Join(u"z")
        - >Enclose(u'<', u'>', u'|');

mathParagraph->Add(System::MakeObject<MathBlock>(delimiter));

presentation->Save(u"delimiters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Adicionar uma caixa de borda**

Use `ToBorderBox` quando a própria equação deve ser enquadrada.

![Uma equação em caixa mostrando c² = b² + a²](powerpoint-math-equations_12.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto boxedEquation = System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"c")->SetSuperscript(u"2"))
        - >ToBorderBox();

mathParagraph->Add(System::MakeObject<MathBlock>(boxedEquation));

presentation->Save(u"border-box.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Agrupar termos**

Use `Group` para colocar um caractere de agrupamento acima ou abaixo de uma expressão. Adicione um limite para rotular os termos agrupados.

![A expressão x + y agrupada com o rótulo qualquer texto abaixo dela](powerpoint-math-equations_15.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto grouped = System::MakeObject<MathematicalText>(u"x + y")
        - >Group(u'\u23DF', MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >SetLowerLimit(u"any text");

mathParagraph->Add(System::MakeObject<MathBlock>(grouped));

presentation->Save(u"grouped-terms.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Formatar elementos matemáticos**

Use auxiliares de formatação somente onde eles clarificam a fórmula. Por exemplo, `Overbar` coloca uma barra acima de um elemento matemático.

![Uma expressão matemática ABC com uma barra superior](powerpoint-math-equations_14.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto overbar = System::MakeObject<MathematicalText>(u"ABC")->Overbar();

mathParagraph->Add(System::MakeObject<MathBlock>(overbar));

presentation->Save(u"overbar.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Referência rápida**

| Tarefa | API principal |
| --- | --- |
| Criar texto matemático | [MathematicalText](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathematicaltext/) |
| Combinar elementos | [IMathElement.Join](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/join/) |
| Criar frações | [IMathElement.Divide](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/divide/) |
| Adicionar sobrescrito ou subscrito | [SetSuperscript](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/setsubscript/) |
| Adicionar funções | [Function](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Adicionar radicais | [IMathElement.Radical](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/radical/) |
| Adicionar limites | [SetLowerLimit](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Adicionar scripts à esquerda | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Adicionar somatórios e integrais | [Nary](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/integral/) |
| Adicionar matrizes | [MathMatrix](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/mathmatrix/) |
| Adicionar arrays de equações | [ToMathArray](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/tomatharray/) |
| Adicionar delimitadores | [Enclose](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/enclose/) |
| Adicionar barras e bordas | [Overbar](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/toborderbox/) |
| Agrupar termos | [Group](https://reference.aspose.com/slides/pt/cpp/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Posso editar uma equação existente do PowerPoint?**

Sim. Abra a apresentação, encontre a forma que contém um `MathPortion`, obtenha seu `MathParagraph` e atualize os blocos matemáticos nesse parágrafo.

**As equações são salvas como matemática editável do PowerPoint?**

Sim. Ao salvar em PPTX, o Aspose.Slides grava a equação como conteúdo de matemática Office editável.

**Posso exportar equações para LaTeX?**

O Aspose.Slides exporta equações matemáticas para MathML. Se precisar de LaTeX, exporte primeiro para MathML e depois converta o MathML com uma ferramenta que suporte o dialeto LaTeX desejado.