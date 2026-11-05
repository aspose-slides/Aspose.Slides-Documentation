---
title: Formatar formas do PowerPoint em C++
linktitle: Formatação de forma
type: docs
weight: 20
url: /pt/cpp/shape-formatting/
keywords:
- formatar forma
- formatar linha
- efeito de esboço
- linha de forma esboçada
- formatar estilo de junção
- preenchimento gradiente
- preenchimento de padrão
- preenchimento de imagem
- preenchimento de textura
- preenchimento de cor sólida
- transparência da forma
- renderização de forma em preto e branco
- renderização de forma em escala de cinza
- rotacionar forma
- efeito de chanfrado 3D
- efeito de rotação 3D
- redefinir formatação
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a formatar formas do PowerPoint em C++ usando Aspose.Slides—defina estilos de preenchimento, linha e efeito para arquivos PPT e PPTX com precisão e controle total."
---
## **Introdução**

Formate formas no PowerPoint ajustando seus contornos, preenchimentos e efeitos. Aspose.Slides for C++ permite controlar essas configurações programaticamente, incluindo transparência, rotação e formatação 3D.

![Opções de formatação de forma no PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for C++ fornece interfaces e métodos que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar linhas**

Use [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) para controlar o contorno de uma forma. Este exemplo cria um retângulo sem preenchimento com um contorno azul tracejado. [ILineFormat::set_Style](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_style/) seleciona uma linha composta espessa‑fina, enquanto [ILineFormat::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) define sua largura para 7 pontos e [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) seleciona o padrão de tracejado.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![As linhas formatadas na apresentação](formatted-lines.png)

### **Definir padrões de tracejado de linha personalizados**

Use [ILineFormat::set_CustomDashPattern](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_customdashpattern/) quando os estilos de linha predefinidos não fornecem os comprimentos de traços e espaços que você precisa, por exemplo para contornos de marca ou diagramas técnicos. Atribuir um padrão altera automaticamente o estilo de traçado para [LineDashStyle::Custom](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/).

Entradas da matriz alternam entre comprimentos de traço e espaço, começando com um traço. Cada valor é um múltiplo da largura da linha: `{ 4, 2 }` com largura de 3 pontos produz um traço de 12 pontos seguido por um espaço de 6 pontos. Use pares de valores finitos e não negativos para definir segmentos completos de traço‑e‑espaço. O exemplo usa valores positivos para manter cada traço e espaço visíveis.

Este exemplo cria cinco linhas azuis com o mesmo comprimento e extremidades planas. As três primeiras comparam padrões com largura de 3 pontos. A quarta repete o primeiro padrão com o dobro da largura, dobrando tanto os comprimentos dos traços quanto dos espaços. A quinta alterna de um padrão personalizado para uma linha sólida.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(600, 300, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto patterns = std::array<ArrayPtr<float>, 5>{
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 1, 2 }),
    MakeArray<float>({ 6, 2, 1, 2 }),
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 4, 2 })
};

for (auto i = 0; i < patterns.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 50, 50 + i * 50, 500, 0);
    line->get_LineFormat()->set_Width(i == 3 ? 6 : 3);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_CapStyle(LineCapStyle::Flat);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_CustomDashPattern(patterns[i]);
}

// Return the last line to a solid style.
slide->get_Shape(4)->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);

presentation->Save(u"custom_dash_patterns.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para voltar a um estilo tracejado predefinido, passe [LineDashStyle::Dash](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) para [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/). O estilo selecionado controla a aparência da linha.

O resultado no PowerPoint, de cima para baixo: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; e **Solid, 3 pt**.

![Três padrões de traçado personalizados, uma linha mais larga usando o primeiro padrão e uma linha sólida no PowerPoint](custom-dash-patterns.png)

### **Definir extremidades de linha**

Use [ILineFormat::set_CapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_capstyle/) para definir as extremidades de uma linha aberta. A enumeração [LineCapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linecapstyle/) fornece três estilos de extremidade explícitos:

- `Flat`: O traço para no ponto final.
- `Round`: Uma extremidade semicircular estende-se além do ponto final em metade da largura da linha.
- `Square`: Uma extremidade quadrada estende-se além do ponto final em metade da largura da linha.

A enumeração também inclui `NotDefined`, que significa que nenhum estilo de extremidade foi atribuído explicitamente.

As extremidades são diferentes das pontas de seta, que adicionam símbolos às extremidades da linha, e das uniões, que controlam os cantos entre segmentos de linha. Este exemplo desabilita as pontas de seta através de [ILineFormat::set_BeginArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_beginarrowheadstyle/) e [ILineFormat::set_EndArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_endarrowheadstyle/) para que somente as formas das extremidades sejam comparadas.

O exemplo a seguir cria três linhas horizontais, de outro modo idênticas, com 20 pontos de largura. De cima para baixo, elas usam extremidades planas, arredondadas e quadradas. Seus pontos finais têm as mesmas coordenadas horizontais; as extremidades arredondadas e quadradas estendem-se 10 pontos além de cada ponto final.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 240, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto capStyles = std::array<LineCapStyle, 3>{ LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square };

for (auto i = 0; i < capStyles.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 100, 50 + i * 70, 300, 0);
    line->get_LineFormat()->set_Width(20);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);
    line->get_LineFormat()->set_CapStyle(capStyles[i]);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
}

presentation->Save(u"line_caps.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado no PowerPoint, de cima para baixo: **Flat**, **Round** e **Square**.

![Extremidades planas, arredondadas e quadradas em linhas espessas idênticas no PowerPoint](line-caps.png)

## **Aplicar efeitos de esboço às linhas da forma**

Um efeito de esboço faz a linha de uma forma parecer desenhada à mão. Use [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) para acessar as configurações da linha, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) para acessar as configurações de esboço e [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) para selecionar um valor da enumeração [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/).

O código C++ a seguir mostra como aplicar um efeito [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) , ler o valor atribuído explicitamente e remover o efeito com [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();
sketchFormat->set_SketchType(LineSketchType::Curved);
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

O valor retornado por [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) representa a configuração atribuída diretamente à forma. Se a formatação da linha puder ser herdada de um tema, slide mestre ou slide de layout, use [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), acesse [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) e leia [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). O valor efetivo reflete a formatação que realmente é aplicada após a resolução da herança. Este exemplo requer uma apresentação existente com ao menos uma forma no primeiro slide e imprime ambos os valores:

```cpp
#include <DOM/ILineFormat.h>
#include <DOM/ILineFormatEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISketchFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto lineFormat = shape->get_LineFormat();
auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);
presentation->Dispose();
```

## **Formatar estilos de junção**

Aqui estão as três opções de tipo de junção:

* Round
* Miter
* Bevel

O estilo de junção controla como dois segmentos de contorno se encontram em um canto. Use **Round** para cantos arredondados, **Miter** para cantos pontiagudos ou **Bevel** para cantos achatados.

![O estilo de junção na apresentação](join-style-powerpoint.png)

Este exemplo cria três retângulos pretos com contornos azuis de 15 pontos de largura. Ele define [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) para os valores miter, bevel e round da [LineJoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/), respectivamente, para comparar como os cantos são desenhados.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto miterShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto bevelShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto roundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

miterShape->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
bevelShape->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
roundShape->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

miterShape->get_LineFormat()->set_Width(15);
bevelShape->get_LineFormat()->set_Width(15);
roundShape->get_LineFormat()->set_Width(15);

miterShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
bevelShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
roundShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

miterShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
bevelShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
roundShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

miterShape->get_TextFrame()->set_Text(u"Miter Join Style");
bevelShape->get_TextFrame()->set_Text(u"Bevel Join Style");
roundShape->get_TextFrame()->set_Text(u"Round Join Style");

presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Limitar junções Miter em cantos pontiagudos**

Use [ILineFormat::set_MiterLimit](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_miterlimit/) com [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) definido como [LineJoinStyle::Miter](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/) para limitar o quão longe um canto pontiagudo pode se estender.

O limite é uma proporção entre a distância entre os cantos interno e externo da junção e a largura da linha. Por exemplo, um valor de `8` permite um comprimento miter de até oito vezes a largura da linha; não é uma medida em pontos. Se o canto exceder o limite, o PowerPoint usa uma junção chanfrada naquele canto. Um limite maior permite pontos mais agudos. A configuração afeta somente junções miter, e alterá‑la não tem efeito visível quando o canto permanece dentro dos limites.

Este exemplo cria dois triângulos idênticos, sem preenchimento, com contornos de 20 pontos de largura. O triângulo esquerdo usa um limite de `2` e o direito usa `8`. Cada triângulo tem 80 pontos de largura e 160 pontos de altura, proporcionando ao seu canto superior uma proporção comprimento‑miter/largura da linha de aproximadamente `4.12`. Consequentemente, o PowerPoint chanfra o ápice esquerdo e preserva o ápice direito.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 320, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto miterLimits = std::array<float, 2>{ 2.0f, 8.0f };

for (auto i = 0; i < miterLimits.size(); i++)
{
    auto triangle = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 90 + i * 240, 110, 80, 160);
    triangle->get_FillFormat()->set_FillType(FillType::NoFill);
    triangle->get_LineFormat()->set_Width(20);
    triangle->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    triangle->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    triangle->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
    triangle->get_LineFormat()->set_MiterLimit(miterLimits[i]);
}

presentation->Save(u"miter_limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado no PowerPoint: **Miter limit 2** à esquerda e **miter limit 8** à direita.

![Um ápice chanfrado com limite miter 2 e um ápice pontiagudo com limite miter 8 no PowerPoint](miter-limits.png)

## **Preenchimento gradiente**

Um preenchimento gradiente mistura cores ao longo de uma forma. Este exemplo preenche uma elipse com um gradiente linear em um ângulo de 45 graus, do vermelho ao roxo, usando [IFillFormat::get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_gradientformat/). O método [IGradientStopCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/igradientstopcollection/add/) posiciona as paradas de cor em 0 e 1, o início e o fim do gradiente. Limpar as paradas existentes garante que apenas essas duas cores sejam usadas.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);
shape->get_FillFormat()->get_GradientFormat()->set_LinearGradientAngle(45);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Clear();
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![A elipse com preenchimento gradiente](gradient-fill.png)

Se um gradiente parecer diferente em uma imagem exportada do que no PowerPoint, veja [Escolher um estilo de renderização de gradiente](/slides/pt/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Você pode selecionar um estilo de renderização sem alterar o preenchimento gradiente armazenado na apresentação.

### **Definir o ângulo do gradiente linear**

Use [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) para controlar a orientação de um preenchimento [GradientShape::Linear](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/). O ângulo é medido em graus e aumenta no sentido horário: `0` vai da esquerda para a direita, `90` de cima para baixo, `180` da direita para a esquerda e `270` de baixo para cima. Ângulos fracionários são suportados. Ângulos finitos fora de `[0, 360)` são normalizados para uma revolução; por exemplo, `-45` torna‑se `315` e `360` torna‑se `0`.

Este exemplo cria seis retângulos com paradas de cor vermelha, verde e azul idênticas nas posições `0`, `0.5` e `1`. A escala está desabilitada para que o ângulo possa ser comparado independentemente das proporções dos retângulos. Os ângulos, da esquerda para a direita, são `0`, `45` e `90` na primeira linha, e `135`, `180` e `270` na segunda linha.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto angles = std::array<float, 6>{ 0, 45, 90, 135, 180, 270 };

for (auto i = 0; i < angles.size(); i++)
{
    auto x = 30 + (i % 3) * 230;
    auto y = 30 + (i / 3) * 190;

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 200, 150);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::False);
    gradient->set_LinearGradientAngle(angles[i]);
}

presentation->Save(u"linear_gradient_angles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado no PowerPoint:

![Gradientes lineares em 0, 45 e 90 graus na linha superior, e 135, 180 e 270 graus na linha inferior](linear-gradient-angles.png)

### **Escalar um gradiente linear com a forma**

[IGradientFormat::set_LinearGradientScaled](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientscaled/) aceita um valor [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/). Defina‑o explicitamente como `False` para manter o ângulo geométrico do gradiente enquanto as proporções da forma mudam, ou como `True` para escalar o gradiente com a largura e altura da forma. Com a escala habilitada, o ângulo visível pode diferir do ângulo atribuído em uma forma não quadrada.

O exemplo a seguir usa um ângulo de `45` graus e as mesmas paradas de cor da comparação de ângulos. A coluna da esquerda usa `False`; a coluna da direita usa `True`. Cada coluna contém um retângulo largo acima de um retângulo alto. Ambos começam com as mesmas dimensões largas; alterar a largura e altura do segundo retângulo demonstra como o preenchimento responde ao redimensionamento sem mudar suas configurações de gradiente.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 460, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto scalingOptions = std::array<NullableBool, 2>{ NullableBool::False, NullableBool::True };

for (auto column = 0; column < scalingOptions.size(); column++)
{
    for (auto row = 0; row < 2; row++)
    {
        auto x = 30 + column * 360;
        auto y = row == 0 ? 30 : 150;

        auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 300, 90);
        shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
        shape->get_FillFormat()->set_FillType(FillType::Gradient);

        auto gradient = shape->get_FillFormat()->get_GradientFormat();
        gradient->set_GradientShape(GradientShape::Linear);
        gradient->get_GradientStops()->Clear();
        gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
        gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
        gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
        gradient->set_LinearGradientAngle(45);
        gradient->set_LinearGradientScaled(scalingOptions[column]);

        if (row == 1)
        {
            shape->set_Width(90);
            shape->set_Height(280);
        }
    }
}

presentation->Save(u"linear_gradient_scaling.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado no PowerPoint, com a escala desabilitada à esquerda e habilitada à direita:

![Retângulos largos e altos com gradiente de 45 graus, comparando LinearGradientScaled False à esquerda com True à direita](linear-gradient-scaling.png)

Com a escala desabilitada, as faixas de cor diagonais mantêm a mesma orientação em ambos os retângulos. Com a escala habilitada, as faixas se esticam com as proporções da forma. Isso ajuda a reproduzir o gradiente de um modelo ao adaptar uma forma a um tamanho diferente. Em um quadrado, habilitar a escala não altera a aparência deste gradiente de `45` graus.

Tanto o ângulo quanto as configurações de escala se aplicam a gradientes lineares. Eles não controlam preenchimentos [GradientShape::Radial ou GradientShape::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/).

### **Combinar o ângulo com a direção do gradiente**

[IGradientFormat::set_GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_gradientdirection/) seleciona um estilo de gradiente da enumeração [GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/gradientdirection/). Não é um substituto para um ângulo numérico. Para um gradiente linear, os estilos de canto podem mudar a área sobre a qual as cores são distribuídas sem alterar o ângulo atribuído através de [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/). Mantenha a direção inalterada ao comparar ângulos ou escala.

O exemplo a seguir aplica as mesmas configurações em ordens opostas. Os dois retângulos têm a mesma aparência: atribuir a direção antes ou depois do ângulo não altera o resultado.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30 + i * 140, 320, 100);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::True);

    if (i == 0)
    {
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
        gradient->set_LinearGradientAngle(30);
    }
    else
    {
        gradient->set_LinearGradientAngle(30);
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
    }
}

presentation->Save(u"linear_gradient_direction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Preenchimento com padrão**

Um preenchimento com padrão aplica um design de duas cores, como pontos, listras ou quadriculados. Este exemplo usa [IPatternFormat::set_PatternStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/set_patternstyle/) para selecionar um padrão de treliça. [IPatternFormat::get_BackColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) fornece o fundo cinza claro, e [IPatternFormat::get_ForeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) fornece a cor amarela do padrão.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Pattern);
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![O retângulo com preenchimento de padrão](pattern-fill.png)

## **Preenchimento com imagem**

Um preenchimento com imagem usa uma imagem dentro de uma forma. Este exemplo requer uma imagem local e usa [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) para carregá‑la na coleção de imagens da apresentação. Definir [IPictureFillFormat::set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) para o modo em mosaico repete a imagem dentro do retângulo. A imagem de origem usada aqui é mostrada abaixo:

![A imagem de lótus](lotus.png)

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

auto image = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(image);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(presentationImage);

presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
image->Dispose();
presentation->Dispose();
```

O resultado:

![A forma com preenchimento de imagem](picture-fill.png)

### **Mosaicar imagem como textura**

Se você quiser definir uma imagem em mosaico como textura e personalizar o comportamento do mosaico, pode usar os seguintes métodos da interface [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) e da classe [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Define o modo de preenchimento da imagem — `Tile` ou `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Especifica o alinhamento dos mosaicos dentro da forma.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Controla se o mosaico é invertido horizontalmente, verticalmente ou ambos.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Define o deslocamento horizontal do mosaico (em pontos) a partir da origem da forma.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Define o deslocamento vertical do mosaico (em pontos) a partir da origem da forma.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Define a escala horizontal do mosaico como porcentagem.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Define a escala vertical do mosaico como porcentagem.

Este exemplo requer uma imagem local e configura [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) para repeti‑la a 50% do seu tamanho original. Deslocamentos de −32 pontos deslocam os mosaicos horizontal e verticalmente; alinhamento inferior‑direito e inversão em ambas as direções determinam como a textura repetida é disposta.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);

auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
shape->get_FillFormat()->set_FillType(FillType::Picture);

auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);

auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

presentation->Save(u"tile.pptx", SaveFormat::Pptx);
sourceImage->Dispose();
presentation->Dispose();
```

O resultado:

![As opções de mosaico](tile-options.png)

## **Preenchimento sólido**

Um preenchimento sólido fornece à forma uma cor única e uniforme. Este exemplo define [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) para o modo de preenchimento sólido e atribui amarelo através de [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/), então salva o retângulo em uma apresentação.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![A forma com preenchimento de cor sólida](solid-color-fill.png)

### **Copiar cores preservando referências de tema**

Use [IColorFormat::CopyFrom](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/copyfrom/) para copiar uma definição de cor, incluindo seu tipo de cor, referência de tema e transformações. Isso é útil ao transferir a cor de preenchimento entre formas que devem continuar a seguir o tema da apresentação. O método copia somente a cor: não copia o tipo de preenchimento, o contorno ou outra formatação da forma. Defina explicitamente o tipo de preenchimento do destino com [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/).

Este exemplo cria três retângulos, da esquerda para a direita: a fonte, uma cópia sensível ao tema e uma cópia RGB fixa. A fonte usa [IColorFormat::set_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/set_schemecolor/) para referenciar a primeira cor de destaque e adiciona um matiz através de [IColorOperationCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icoloroperationcollection/add/). A cópia RGB usa a cor de preenchimento efetiva da fonte, de modo que os três inicialmente pareçam idênticos. Chamar [IColorFormat::set_Color](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/set_color/) define um valor RGB fixo e limpa quaisquer transformações de cor existentes.

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(660, 220, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

presentation->get_MasterTheme()->get_ColorScheme()->get_Accent1()->set_Color(Color::get_RoyalBlue());

auto source = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
auto themeCopy = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
auto rgbCopy = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

for (auto shape : { source, themeCopy, rgbCopy })
{
    shape->get_FillFormat()->set_FillType(FillType::Solid);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
}

auto sourceColor = source->get_FillFormat()->get_SolidFillColor();
sourceColor->set_SchemeColor(SchemeColor::Accent1);
sourceColor->get_ColorTransform()->Add(ColorTransformOperation::Tint, 0.75f);

themeCopy->get_FillFormat()->get_SolidFillColor()->CopyFrom(sourceColor);
auto effectiveFill = source->get_FillFormat()->GetEffective();
rgbCopy->get_FillFormat()->get_SolidFillColor()->set_Color(effectiveFill->get_SolidFillColor());

auto before = slide->GetImage(1.0f, 1.0f);
before->Save(u"color-copy-before.png", ImageFormat::Png);
before->Dispose();

// Theme references follow the new accent color; the fixed RGB value does not.
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent1()->set_Color(Color::get_OrangeRed());

auto after = slide->GetImage(1.0f, 1.0f);
after->Save(u"color-copy-after.png", ImageFormat::Png);
after->Dispose();
presentation->Save(u"copied_colors.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Antes da mudança de tema, todos os três preenchimentos correspondem:

![Fonte, destino CopyFrom e destino RGB fixo com preenchimentos azuis idênticos](color-copy-before.png)

Depois da mudança de tema, a fonte e a cópia sensível ao tema seguem a nova cor de destaque e mantêm seu matiz. A cópia RGB fixa permanece azul:

![Fonte e destino CopyFrom com preenchimentos laranja, enquanto o destino RGB fixo permanece azul](color-copy-after.png)

A definição copiada é independente da fonte. Alterar posteriormente a referência de tema da fonte, atribuir outra cor ou adicionar ou remover suas transformações não altera o destino. Uma mudança de tema ainda afeta ambas as formas porque cada uma refere‑se independentemente à mesma cor do tema.

Salvar e reabrir o PPTX preserva o tipo da cor copiada, disponível via [IColorFormat::get_ColorType](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_colortype/), sua referência de tema e a coleção de transformações retornada por [IColorFormat::get_ColorTransform](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_colortransform/); não transforma a definição em RGB.

Ao copiar entre diferentes contextos de tema, como apresentações com paletas de destaque distintas, a referência copiada é resolvida em relação ao tema do destino. A mesma referência e transformações podem, portanto, produzir uma cor visível diferente. Veja [Tema da Apresentação](/slides/pt/cpp/presentation-theme/) para mais informações sobre a configuração de cores de tema.

## **Usar o fundo do slide como preenchimento de forma**

Use [IAutoShape::set_UseBackgroundFill](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/set_usebackgroundfill/) quando uma forma deve corresponder ao fundo do slide, por exemplo em um modelo de apresentação. Defina [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) para [FillType::NotDefined](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) primeiro para remover qualquer preenchimento explícito. Com essa combinação, a forma usa o fundo do slide em vez do seu preenchimento de estilo. Ativar a flag sozinho não remove um preenchimento explícito existente.

Isso difere de [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/): o preenchimento de fundo cobre objetos atrás da forma com a área correspondente do fundo do slide, enquanto nenhum preenchimento deixa esses objetos visíveis. Um gradiente permanece alinhado ao slide em vez de reiniciar dentro de cada forma.

O exemplo a seguir cria um fundo mestre herdado pelo slide e coloca uma faixa magenta atrás de três retângulos. O retângulo esquerdo usa o fundo, o retângulo do meio não tem preenchimento e o retângulo direito alterna do preenchimento de fundo para um preenchimento laranja explícito.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

// Herda o gradiente do mestre.
slide->get_Background()->set_Type(BackgroundType::NotDefined);
slide->get_LayoutSlide()->get_Background()->set_Type(BackgroundType::NotDefined);
auto background = slide->get_LayoutSlide()->get_MasterSlide()->get_Background();
background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Gradient);
auto gradient = background->get_FillFormat()->get_GradientFormat();
gradient->set_GradientShape(GradientShape::Linear);
gradient->set_LinearGradientAngle(0);
gradient->get_GradientStops()->Clear();
gradient->get_GradientStops()->Add(0, Color::get_DarkBlue());
gradient->get_GradientStops()->Add(1, Color::get_LightSkyBlue());

// Adicione este objeto primeiro para que fique atrás dos retângulos.
auto band = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Magenta());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto backgroundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
backgroundShape->get_FillFormat()->set_FillType(FillType::NotDefined);
backgroundShape->set_UseBackgroundFill(true);

auto noFillShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
noFillShape->get_FillFormat()->set_FillType(FillType::NoFill);

auto explicitShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
explicitShape->get_FillFormat()->set_FillType(FillType::NotDefined);
explicitShape->set_UseBackgroundFill(true);

// Desabilite o preenchimento de fundo antes de aplicar um preenchimento explícito.
explicitShape->set_UseBackgroundFill(false);
explicitShape->get_FillFormat()->set_FillType(FillType::Solid);
explicitShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

presentation->Save(u"background_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado, da esquerda para a direita: **preenchimento de fundo**, **sem preenchimento** e **preenchimento explícito**. A faixa magenta é ocultada pelos retângulos esquerdo e direito, mas permanece visível através do retângulo do meio.

![Preenchimento de fundo, sem preenchimento e preenchimento laranja explícito sobre uma faixa magenta](background-fill.png)

O mesmo comportamento se aplica a um fundo definido diretamente no slide ou herdado de um layout. A forma usa o fundo resolvido do slide; o exemplo deixa os fundos do slide e do layout indefinidos para que o mestre o forneça.

## **Definir transparência**

Para um preenchimento sólido, o componente alfa da cor controla a opacidade: 0 é totalmente transparente e 255 é totalmente opaco. Este exemplo usa um valor alfa de 128 para um retângulo amarelo, tornando‑o aproximadamente 50% transparente para que o retângulo abaixo permaneça visível. A cor é atribuída através de [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/).

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const int alpha = 128;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, Color::get_Yellow()));

presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![A forma transparente](shape-transparency.png)

## **Rotacionar formas**

Use [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) para rotacionar uma forma no plano do slide. O ângulo é medido em graus; este exemplo rotaciona um retângulo 5 graus no sentido horário e salva a apresentação.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->set_Rotation(5);

presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![A rotação da forma](shape-rotation.png)

## **Adicionar efeitos de chanfrado 3D**

Use [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) para dar profundidade e bordas chanfradas a uma forma. Este exemplo cria uma elipse verde com contorno laranja, define [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) para 4 pontos e aplica um chanfrado superior circular com largura e altura de 6 pontos através de [IThreeDFormat::get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/). Uma câmera ortográfica de frente e iluminação de três pontos tornam o chanfrado visível.

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);
shape->get_ThreeDFormat()->set_Depth(4);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![O efeito de chanfrado 3D](3D-bevel-effect.png)

## **Adicionar efeitos de rotação 3D**

A visualização 3D de uma forma é controlada pelas configurações da sua câmera. Este exemplo usa [ICamera::SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) com ângulos de latitude, longitude e revolução de 40, 35 e 20 graus, respectivamente. Ele seleciona uma câmera isométrica através de [ICamera::set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) e iluminação equilibrada através de [ILightRig::set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/), então salva o retângulo formatado.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
autoShape->get_TextFrame()->set_Text(u"Hello, Aspose!");
autoShape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
autoShape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
autoShape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![O efeito de rotação 3D](3D-rotation-effect.png)

## **Controlar a renderização em preto e branco para formas**

O método [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) especifica como uma forma individual é renderizada quando uma apresentação é visualizada ou processada em modo preto e branco. Ele não habilita a exibição em preto e branco por si só, e não altera o preenchimento, a linha ou outra formatação da forma no modo de cor normal.

Use um valor da enumeração [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) para selecionar o comportamento desejado. Por exemplo, `Automatic` permite que o aplicativo de renderização escolha a conversão, `Gray` e `LightGray` usam coloração cinza, `BlackWhite` usa apenas preto e branco, `Black` e `White` forçam uma única cor, `Color` preserva a coloração normal, e `Hidden` omite a forma no modo preto e branco. `NotDefined` significa que nenhum modo de forma foi atribuído.

Este exemplo cria um retângulo laranja e define [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) como cinza. A forma salva preserva seu preenchimento laranja para exibição em cores normais e solicita coloração cinza de aplicativos que respeitam as configurações de exibição em preto e branco:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

No modo de cor normal, o retângulo mantém seu preenchimento laranja. Em um fluxo de trabalho de exibição em preto e branco, ele usa coloração cinza porque seu modo está definido como `Gray`. Isso permite que você preserve um slide em cores completas ao definir uma aparência distinta para impressão, visualização ou outros fluxos de trabalho que respeitam as configurações de exibição em preto e branco da apresentação.

## **Restaurar formatação**

Use [ISlide::Reset](https://reference.aspose.com/slides/cpp/aspose.slides/islide/reset/) para restaurar a posição, tamanho e formatação dos espaços reservados do slide a partir dos seus respectivos espaços reservados de layout. Este exemplo requer uma apresentação existente com espaços reservados vinculados ao layout e restaura cada slide antes de salvar. Formas sem espaços reservados de layout correspondentes não são restauradas.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Perguntas frequentes**

**A formatação de forma afeta o tamanho final do arquivo da apresentação?**

As cores, estilos de linha e configurações de efeito geralmente adicionam poucos dados em comparação com imagens e mídia incorporadas. Preenchimentos com imagem podem aumentar o tamanho do arquivo porque suas imagens são armazenadas na apresentação.

**Como posso detectar formas em um slide que compartilham formatação idêntica para que eu possa agrupá‑las?**

Compare as propriedades de formatação principais de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, trate seus estilos como idênticos e agrupe logicamente essas formas, o que simplifica o gerenciamento de estilos posterior.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilização em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um conjunto de slides modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas que precisar e reaplique sua formatação onde for necessário.