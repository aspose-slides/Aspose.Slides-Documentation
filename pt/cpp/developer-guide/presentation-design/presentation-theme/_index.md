---
title: Gerenciar Temas de Apresentação em C++
linktitle: Tema da Apresentação
type: docs
weight: 10
url: /pt/cpp/presentation-theme/
keywords:
- Tema PowerPoint
- Tema de apresentação
- Tema de slide
- Definir tema
- Alterar tema
- Gerenciar tema
- Tema externo
- THMX
- Cor do tema
- Paleta adicional
- Fonte do tema
- Estilo do tema
- Efeito do tema
- PowerPoint
- OpenDocument
- Apresentação
- C++
- Aspose.Slides
description: "Temas principais de apresentação no Aspose.Slides para C++ para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define um conjunto coordenado de cores, fontes, estilos de plano de fundo, preenchimentos, linhas e efeitos. Objetos sensíveis ao tema referem‑se a essas definições compartilhadas em vez de armazenar cada propriedade visual como um valor fixo, de modo que uma mudança de tema possa atualizar muitos objetos de uma só vez.

No Aspose.Slides, o tema ao nível da apresentação está disponível através de [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/). Uma apresentação também pode conter substituições de tema em níveis inferiores. Um mestre pode substituir o tema da apresentação através de [MasterThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), enquanto um layout ou um slide individual pode usar [IOverrideThemeManager::get_OverrideTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). Na prática, o tema efetivo de um slide é resolvido por meio desta cadeia de herança: tema da apresentação, substituição do mestre, substituição do layout e substituição do slide.

![Componentes do tema: cores, fontes, estilos de plano de fundo e efeitos](theme-constituents.png)

As seções abaixo mostram os fluxos de trabalho de tema mais comuns: inspecionar um tema, alterar cores e fontes, copiar ou aplicar um tema, atualizar estilos de plano de fundo e efeitos e ler valores efetivos após a herança e as substituições terem sido resolvidas.

## **Inspecionar um Tema**

O objeto [MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/) expõe os métodos [get_ColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) e [get_FormatScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Inspecionar essas coleções antes de alterá‑las é especialmente útil quando uma apresentação vem de uma fonte externa, pois o número e o conteúdo das entradas de estilo podem variar.

O exemplo a seguir lê as propriedades principais do tema e relata quantos estilos de plano de fundo, preenchimento, linha e efeito estão armazenados no tema:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

Se um arquivo usar vários mestres, não presuma que todo slide tenha o mesmo tema efetivo. Inspecione o mestre associado ao slide e use o fluxo de trabalho de tema efetivo mostrado mais adiante neste artigo quando houver substituições de layout ou de slide.

## **Alterar Cores do Tema**

Preenchimentos, linhas e textos sensíveis ao tema podem referir‑se a uma cor lógica da enumeração [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/). Quando você altera a entrada correspondente no [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) do tema, todos os objetos que ainda referenciam aquela cor do tema são resolvidos contra o novo valor. Objetos que usam uma cor RGB direta não são alterados por uma atualização de cor do tema.

O exemplo completo a seguir cria uma forma que usa `Accent4`, altera a cor `Accent4` do tema para vermelho, salva a apresentação, a reabre e imprime a cor de preenchimento efetiva:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

Como o retângulo continua ligado a `Accent4`, sua cor visível torna‑se vermelha após a mudança do tema. Se você substituir a cor do esquema por uma cor direta na forma, alterações posteriores em `Accent4` não afetarão mais esse preenchimento.

### **Usar Cores da Paleta Adicional**

O PowerPoint deriva variantes mais claras e mais escuras de uma cor de tema aplicando transformações de cor. O Aspose.Slides expõe essas transformações através de [ColorTransformOperation](https://reference.aspose.com/slides/cpp/aspose.slides/colortransformoperation/).

![Cores principais do tema e cores mais claras e mais escuras geradas a partir da paleta adicional](additional-palette-colors.png)

**1** – Cores principais do tema.

**2** – Variantes mais claras e mais escuras produzidas a partir das cores principais do tema.

O exemplo a seguir cria seis retângulos baseados em `Accent4`, aplica transformações de luminância a cinco deles e salva o resultado:

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

Essas variantes permanecem baseadas na cor do tema. Se `Accent4` mudar posteriormente, as cores transformadas são recalculadas a partir do novo valor de `Accent4`.

### **Mapear Valores de `SchemeColor` para Slots de `IColorScheme`**

A enumeração [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/) usa `Text1`, `Background1`, `Text2` e `Background2`, enquanto [IColorScheme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/icolorscheme/) expõe os mesmos slots do tema como `Dark1`, `Light1`, `Dark2` e `Light2`. O mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Esses são nomes alternativos para os mesmos slots do tema; não são valores convertidos dinamicamente de uma forma para outra.

## **Alterar Fontes do Tema**

Um esquema de fontes do tema contém um conjunto de fontes principal para títulos e um conjunto de fontes secundário para o corpo do texto. Os métodos [FontScheme::get_Major](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_major/) e [FontScheme::get_Minor](https://reference.aspose.com/slides/cpp/aspose.slides.theme/fontscheme/get_minor/) expõem esses conjuntos.

Identificadores de fontes de tema compatíveis com o PowerPoint podem ser usados na formatação de texto:

* `+mn-lt` – Fonte do Corpo Latin (Minor Latin Font)
* `+mj-lt` – Fonte do Título Latin (Major Latin Font)
* `+mn-ea` – Fonte do Corpo East Asian (Minor East Asian Font)
* `+mj-ea` – Fonte do Título East Asian (Major East Asian Font)
* `+mn-cs` – Fonte do Corpo Complex Script (Minor Complex Script Font)
* `+mj-cs` – Fonte do Título Complex Script (Major Complex Script Font)

O exemplo a seguir cria um título que usa a fonte Latin principal do tema e uma linha de corpo que usa a fonte Latin secundária do tema. Em seguida, altera as fontes do tema e salva o resultado:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

O título segue a fonte principal e o texto do corpo segue a fonte secundária. Texto que possui um nome de fonte explícito em vez de um identificador de tema não mudará automaticamente quando o esquema de fontes do tema for alterado.

As coleções de fontes principal e secundária também podem conter mapeamentos de fontes para sistemas de escrita individuais, como Cirílico, Árabe, Japonês, Georgiano e Thaana. Para inspecionar, adicionar, substituir ou remover esses mapeamentos, veja [Script-Specific Theme Fonts](/slides/pt/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Para obter mais informações sobre fontes em apresentações, consulte [PowerPoint Fonts](/slides/pt/cpp/powerpoint-fonts/).
{{% /alert %}}

### **Resolver Referências de Fonte do Tema**

Ao inspecionar texto, [IFontData::get_FontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/get_fontname/) pode conter uma referência de tema como `+mn-lt` em vez de um nome de família de fonte. Chame [IFontData::GetFontName](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/getfontname/) com o [IThemeEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeeffectivedata/) apropriado para resolver essa referência. Os prefixos `+mj` e `+mn` selecionam os conjuntos de fontes principal e secundário; os sufixos `-lt`, `-ea` e `-cs` selecionam, respectivamente, suas fontes Latin, East Asian e Complex Script.

Obtenha o tema efetivo através de [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) no objeto cujo tema se aplica ao texto inspecionado. Para texto comum em um slide, use `slide->CreateThemeEffective()` para que o contexto inclua o tema herdado desse slide e as substituições locais. Ao inspecionar um layout ou mestre, use o próprio tema efetivo. Não presuma que o tema do primeiro mestre se aplica a todos os slides.

O exemplo a seguir cria uma porção de texto que referencia explicitamente a fonte Latin secundária. Ele inicializa um esquema de fontes de slide através de [IOverrideTheme::InitFontSchemeFromInherited](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) e define as famílias Latin principal e secundária como `Arial` e `Calibri`, tornando o resultado reproduzível sem um arquivo de entrada.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto theme = slide->get_ThemeManager()->get_OverrideTheme();
theme->InitFontSchemeFromInherited();
theme->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Arial"));
theme->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Calibri"));

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 60.0f);
shape->get_TextFrame()->set_Text(u"Text using the minor theme font");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

auto font = portion->get_PortionFormat()->get_LatinFont();
auto effectiveTheme = slide->CreateThemeEffective();
auto resolvedFontName = font->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", font->get_FontName(), resolvedFontName);

auto explicitFont = MakeObject<FontData>(u"Verdana");
auto explicitFontName = explicitFont->GetFontName(effectiveTheme);
Console::WriteLine(u"{0} -> {1}", explicitFont->get_FontName(), explicitFontName);
```

A saída é `+mn-lt -> Calibri` seguida de `Verdana -> Verdana`. A referência armazenada permanece inalterada, enquanto um nome de família explícito é retornado como está. Se a porção usasse `+mj-lt`, resolveria para `Arial` neste tema.

Resolver uma referência de tema identifica a família de fontes especificada pelo tema. Não verifica a disponibilidade da fonte nem determina o arquivo de fonte realmente usado após substituição ou fallback de glifos durante a renderização. Consulte [Font Selection Sequence](/slides/pt/cpp/font-selection-sequence/) e [Font Substitution](/slides/pt/cpp/font-substitution/) para essas etapas separadas.

## **Copiar ou Aplicar um Tema**

Os fluxos de trabalho abaixo resolvem diferentes problemas relacionados a temas.

### **Aplicar um Tema Externo aos Slides Dependentes de um Mestre**

Use [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) quando você possui um arquivo de tema do PowerPoint (`.thmx`) e deseja restilizar todos os slides que dependem de um mestre específico. Selecione o mestre da coleção [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/), e passe o caminho do arquivo de tema para o método.

O método realiza as seguintes operações:

1. Cria um novo slide mestre com base no mestre selecionado.  
2. Aplica o tema externo ao novo mestre.  
3. Atribui o novo mestre a todos os slides que anteriormente dependiam do mestre selecionado.  
4. Retorna o recém‑criado [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/).

O exemplo a seguir aplica um tema externo aos slides que dependem do primeiro mestre e salva a apresentação:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);

auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");
Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());

presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

Um tema inválido, corrompido ou não suportado pode gerar [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) ou uma de suas subclasses relacionadas a formato. Valide os caminhos fornecidos pelos usuários, trate falhas de acesso ao sistema de arquivos e salve a apresentação somente após o tema ter sido aplicado com sucesso.

Apenas os slides que dependiam do mestre selecionado são reatribuídos. Slides associados a outros mestres mantêm seus mestres e temas existentes. Cores, fontes, preenchimentos, linhas, planos de fundo e efeitos sensíveis ao tema são resolvidos em relação ao tema externo. Cores, fontes, preenchimentos e outras formatações atribuídas diretamente podem permanecer inalterados. Substituições ao nível de layout e slide também podem ter precedência sobre valores herdados do novo mestre.

O tema pode fazer referência a fontes que não estão disponíveis no ambiente de tempo de execução. Para renderização e exportação consistentes, instale as fontes necessárias, forneça‑as por meio de [fontes customizadas](/slides/pt/cpp/custom-font/), ou configure [substituição de fontes](/slides/pt/cpp/font-substitution/).

Este é um fluxo de trabalho direto ao nível do mestre: o método aceita um caminho de arquivo `.thmx` e não requer a criação manual de substituições de tema ao nível de slide ou layout.

### **Aplicar Temas Externos Diferentes em uma Apresentação com Múltiplos Mestres**

Quando o mestre relevante não é conhecido com antecedência, obtenha‑o a partir de um slide representativo através de [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) e [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_masterslide/). Armazene as referências originais dos mestres antes de aplicar quaisquer temas, pois cada chamada cria outro mestre na apresentação.

O exemplo a seguir usa slides de duas seções para localizar seus mestres e aplica um tema externo diferente a cada grupo:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());

        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

A primeira chamada afeta somente os slides que dependiam de `firstGroupMaster`, e a segunda chamada afeta somente os slides que dependiam de `secondGroupMaster`. Slides pertencentes a qualquer outro mestre não são restilizados.

### **Preservar um Tema de Origem ao Mover Slides**

Se quiser mover um slide para outra apresentação e preservar seu design original, clone o mestre de origem na apresentação de destino com [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/), então clone o slide com [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) e o mestre clonado. Isso transporta o mestre, seus layouts e o tema associado juntos.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");

auto sourceSlide = source->get_Slide(0);

auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);

target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

Este é o fluxo de trabalho recomendado quando o slide de origem deve permanecer idêntico no destino. Clonar apenas o conteúdo sobre um mestre de destino não relacionado pode mudar cores, fontes, planos de fundo e efeitos definidos pelo tema.

### **Aplicar Valores de Tema a um Slide Existente**

Se o slide de destino precisar permanecer no mestre e layout atuais, inicialize uma substituição ao nível do slide a partir do tema de origem. Os métodos [OverrideTheme::InitColorSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) e [OverrideTheme::InitFormatSchemeFrom](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) copiam os três principais componentes do tema para a substituição.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);

auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());

target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

Isso altera o tema usado por aquele slide sem mudar o tema herdado por outros slides. Para remover a substituição local e voltar aos valores herdados, chame [OverrideTheme::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.theme/overridetheme/clear/).

### **Aplicar uma Substituição de Tema a um Layout**

Uma substituição ao nível de layout se aplica aos slides que usam esse layout, a menos que um slide específico tenha sua própria substituição. Os mesmos métodos de inicialização podem ser usados através do [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) do layout:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);

auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());

target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

Use um tema ao nível de mestre ou apresentação quando muitos layouts e slides devem compartilhar o mesmo design base, uma substituição de layout quando uma família de layouts precisa de estilização diferente e uma substituição de slide apenas para exceções reais. Substituições excessivas ao nível de slide dificultam previsões de mudanças globais de tema posteriores.

## **Atualizar Estilos de Plano de Fundo do Tema**

Os preenchimentos de plano de fundo do tema são armazenados em [FormatScheme::get_BackgroundFillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). O PowerPoint pode apresentar mais opções de plano de fundo em sua UI do que o número de definições de preenchimento armazenadas nessa coleção, pois a UI pode combinar preenchimentos de tema com cores de tema e outras referências de estilo.

![Galeria de estilos de plano de fundo do PowerPoint para um tema de apresentação](presentation-design_8.png)

Antes de usar um estilo de plano de fundo, inspecione a coleção armazenada e o atual [Background::get_StyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` usa `0` para nenhum preenchimento temático; valores positivos são referências de estilo de plano de fundo temático. Isso difere de indexar diretamente uma coleção C++ com `idx_get(0)`, onde `0` significa o primeiro item armazenado. Não presuma que toda apresentação contenha o mesmo número de estilos de preenchimento de plano de fundo.

O exemplo a seguir relata a contagem de preenchimentos de plano de fundo disponíveis, atribui uma referência de plano de fundo temático ao primeiro mestre e salva a apresentação:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);

    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

O resultado visível depende da entrada de tema referenciada pelo mestre e de quaisquer substituições de plano de fundo no layout ou nível de slide. Se um slide usar seu próprio plano de fundo, mudar apenas o plano de fundo do mestre pode não alterar esse slide. Use [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) quando precisar conhecer o plano de fundo final após a aplicação da herança.

{{% alert color="warning" title="Warning" %}}
Não trate `StyleIndex` como um índice de coleção base 0. Também evite codificar um número de estilo de um arquivo e presumir que ele terá a mesma aparência em outro arquivo; as definições de estilo de tema são específicas da apresentação.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Para formatação direta de plano de fundo e herança de plano de fundo, veja [Presentation Background](/slides/pt/cpp/presentation-background/).
{{% /alert %}}

## **Atualizar Efeitos do Tema**

Um esquema de formato do tema contém coleções separadas de [FormatScheme::get_FillStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_linestyles/) e [FormatScheme::get_EffectStyles](https://reference.aspose.com/slides/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Temas típicos de Office costumam conter três entradas principais que correspondem visualmente a formatações sutil, moderada e intensa, mas o código deve inspecionar cada coleção em vez de presumir uma contagem fixa.

![Efeitos de tema sutis, moderados e intensos aplicados à mesma forma](presentation-design_10.png)

Ao acessar essas coleções em C++, o índice da coleção é base 0: `idx_get(0)` é o primeiro estilo armazenado e `idx_get(2)` é o terceiro. Os índices de referência de estilo de uma forma são um conceito separado, exposto por [IShapeStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/). Modificar um estilo de tema afeta as formas que referenciam esse estilo; formas com formatação direta podem permanecer inalteradas.

O exemplo a seguir verifica se as entradas de estilo necessárias existem, altera o primeiro estilo de linha, altera o terceiro estilo de preenchimento, habilita uma sombra externa no terceiro estilo de efeito e salva o resultado:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

Para formas que referenciam esses slots, o primeiro estilo de linha do tema torna‑se vermelho, o terceiro estilo de preenchimento do tema torna‑se verde floresta sólido, e o terceiro estilo de efeito ganha uma sombra externa com distância de 10 pontos. O resultado visual exato ainda depende de quais slots de estilo cada forma referencia e se a formatação direta sobrescreve o tema.

![Estilos de efeito do tema após a alteração de linha, preenchimento e sombra](presentation-design_11.png)

## **Selecionar Estilos de Preenchimento e Linha do Tema para uma Forma**

Uma forma pode selecionar seu preenchimento e contorno independentemente através de [IShapeStyle::set_FillStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_fillstyleindex/) e [IShapeStyle::set_LineStyleIndex](https://reference.aspose.com/slides/cpp/aspose.slides/ishapestyle/set_linestyleindex/). Para ambos os setters, o índice `1` seleciona a primeira entrada na respectiva coleção de tema (`idx_get(0)`), e o índice `2` seleciona a segunda entrada.

O exemplo a seguir configura dois estilos de preenchimento (dourado e azul celeste) e dois estilos de linha (azul escuro em 6 pt e vermelho escuro em 12 pt) no tema padrão de uma nova apresentação. Ele salva o slide em três estágios para que você possa comparar os resultados no PowerPoint.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeStyle.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto styles = presentation->get_MasterTheme()->get_FormatScheme();

auto goldFill = styles->get_FillStyles()->idx_get(0);
goldFill->set_FillType(FillType::Solid);
goldFill->get_SolidFillColor()->set_Color(Color::get_Gold());
auto blueFill = styles->get_FillStyles()->idx_get(1);
blueFill->set_FillType(FillType::Solid);
blueFill->get_SolidFillColor()->set_Color(Color::get_SkyBlue());

auto thinLine = styles->get_LineStyles()->idx_get(0);
thinLine->get_FillFormat()->set_FillType(FillType::Solid);
thinLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
thinLine->set_Width(6.0);
auto thickLine = styles->get_LineStyles()->idx_get(1);
thickLine->get_FillFormat()->set_FillType(FillType::Solid);
thickLine->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkRed());
thickLine->set_Width(12.0);

auto shapes = presentation->get_Slide(0)->get_Shapes();
auto left = shapes->AddAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
auto right = shapes->AddAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
auto leftStyle = left->get_ShapeStyle();
auto rightStyle = right->get_ShapeStyle();
leftStyle->set_FillStyleIndex(1);
rightStyle->set_FillStyleIndex(2);
leftStyle->set_LineStyleIndex(1);
rightStyle->set_LineStyleIndex(1);
presentation->Save(u"01-initial.pptx", SaveFormat::Pptx);

rightStyle->set_LineStyleIndex(2);
presentation->Save(u"02-line-changed.pptx", SaveFormat::Pptx);

goldFill->get_SolidFillColor()->set_Color(Color::get_SeaGreen());
presentation->Save(u"03-theme-changed.pptx", SaveFormat::Pptx);
```

| Estilos iniciais | Alterar o contorno da direita | Editar o primeiro preenchimento do tema |
|:---:|:---:|:---:|
| ![Retângulos dourado e azul‑celeste com contornos finos azul‑escuro correspondentes](theme-style-initial.png) | ![O retângulo azul‑celeste agora tem um contorno vermelho escuro espesso](theme-style-line-changed.png) | ![O retângulo à esquerda agora está verde e ambos os contornos permanecem inalterados](theme-style-fill-changed.png) |

Selecionar um estilo de linha diferente altera apenas o contorno do retângulo da direita. Editar o primeiro preenchimento do tema atualiza todas as formas que o utilizam. Aqui, apenas o retângulo à esquerda fica verde.

Em uma forma existente, uma cor de preenchimento local, cor de linha ou espessura de linha pode sobrescrever essa parte do estilo do tema. Se a mudança de índice de estilo não produzir efeito visível, verifique a [formatação direta](/slides/pt/cpp/shape-formatting/) da forma.

## **Determinar se um Preenchimento Sólido Efetivo Usa uma Cor de Tema**

Um preenchimento pode ser armazenado diretamente em um objeto ou herdado de um parágrafo, layout, mestre, estilo de tema ou outro nível de formatação. Chame [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/) para resolver essa hierarquia em um objeto imutável [IFillFormatEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/). Primeiro verifique [IFillFormatEffectiveData::get_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_filltype/). Só quando for `FillType::Solid` você deve ler as propriedades do preenchimento sólido.

Para um preenchimento sólido, [IFillFormatEffectiveData::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillcolor/) devolve o valor RGB final renderizado após herança, busca no tema e aplicação de transformações de cor. [IFillFormatEffectiveData::get_SolidFillSchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformateffectivedata/get_solidfillschemecolor/) devolve o slot lógico correspondente de [SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/schemecolor/), como `Text1` ou `Accent6`. Um valor `SchemeColor::NotDefined` indica que o preenchimento sólido efetivo não se baseia em uma cor de esquema. Em um fluxo onde preenchimentos são cores de tema ou cores RGB diretas, esse valor identifica um preenchimento RGB direto.

Não use apenas o valor local de [IColorFormat::get_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_schemecolor/) para classificar um preenchimento. Por exemplo, uma porção de texto pode não ter um esquema de cor definido localmente, portanto seu valor local é `NotDefined`, enquanto seu preenchimento efetivo herda uma cor de tema e resolve para `Text1` ou `Accent6`. Por outro lado, `get_SolidFillSchemeColor` informa qual slot lógico do tema produziu a cor efetiva, mas não indica se esse slot veio do objeto, parágrafo, layout, mestre ou outro nível da hierarquia de formatação.

O exemplo a seguir carrega uma apresentação, audita os preenchimentos de formas e de porções de texto, imprime cada valor RGB final e a cor de esquema associada, e sinaliza preenchimentos sólidos que não acompanharão alterações nas cores do tema:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto auditFill = [](const String& objectName, const SharedPtr<IFillFormat>& localFill)
{
    auto effectiveFill = localFill->GetEffective();

    if (effectiveFill->get_FillType() != FillType::Solid)
    {
        Console::WriteLine(u"{0}: fill type = {1}; not a solid fill.", objectName, effectiveFill->get_FillType());
        return;
    }

    auto rgb = effectiveFill->get_SolidFillColor();
    auto effectiveSchemeColor = effectiveFill->get_SolidFillSchemeColor();
    auto localSchemeColor = localFill->get_SolidFillColor()->get_SchemeColor();

    Console::WriteLine(u"{0}: RGB = #{1:X2}{2:X2}{3:X2}", objectName, rgb.get_R(), rgb.get_G(), rgb.get_B());
    Console::WriteLine(u"{0}: local scheme = {1}, effective scheme = {2}", objectName, localSchemeColor, effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor::NotDefined)
    {
        Console::WriteLine(u"{0}: direct RGB or another non-scheme fill; audit as theme-independent.", objectName);
    }
    else
    {
        Console::WriteLine(u"{0}: theme-dependent through {1}.", objectName, effectiveSchemeColor);
    }
};

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int32_t slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    auto shapeCount = slide->get_Shapes()->get_Count();
    for (int32_t shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        auto shapeName = String::Format(u"Slide {0}, shape {1}", slideIndex + 1, shapeIndex + 1);
        auditFill(shapeName, shape->get_FillFormat());

        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
            for (int32_t paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                auto paragraph = textFrame->get_Paragraph(paragraphIndex);

                auto portionCount = paragraph->get_Portions()->get_Count();
                for (int32_t portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    auto portion = paragraph->get_Portion(portionIndex);
                    auto portionName = String::Format(u"{0}, paragraph {1}, portion {2}", shapeName, paragraphIndex + 1, portionIndex + 1);
                    auditFill(portionName, portion->get_PortionFormat()->get_FillFormat());
                }
            }
        }
    }
}
```

O ramo `NotDefined` fornece uma lista de auditoria de preenchimentos sólidos que não responderão a mudanças nos slots de cor do tema. Revise esses objetos quando uma apresentação precisar seguir uma nova paleta de marca. O valor RGB relatado ainda mostra a aparência atual, enquanto o valor de esquema explica se essa aparência está conectada ao tema.

Objetos de formato efetivo são instantâneos. Após alterar o tema da apresentação, uma substituição de tema ou qualquer formatação herdada, chame `GetEffective` novamente e leia um novo objeto `IFillFormatEffectiveData` antes de comparar ou relatar cores.

## **Ler Valores Efetivos do Tema**

Objetos de tema bruto indicam o que está definido em um determinado nível. Valores efetivos indicam o que um slide ou forma realmente usa após a herança e as substituições locais terem sido resolvidas. Para um slide, chame [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Para um plano de fundo, use [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/), e para um preenchimento, use [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/).

O exemplo a seguir lê o tema efetivo, o plano de fundo e o primeiro preenchimento de forma de um slide:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

Use dados efetivos para diagnóstico de renderização, validação e comparações. Se você inspecionar apenas [Presentation::get_MasterTheme](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_mastertheme/), pode perder um mestre, layout, slide ou substituição de forma que altere a aparência final.

## **FAQ**

**Aplicar um tema externo afeta todos os slides da apresentação?**

Não. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) reatribui apenas os slides que dependem do mestre selecionado. Slides que usam outros mestres mantêm seus temas existentes.

**Posso aplicar um tema a um único slide sem mudar o mestre?**

Sim. Use o [IOverrideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ioverridethememanager/) do slide e inicialize seu tema de substituição. A mudança permanece local ao slide; os demais slides continuam a herdar seus temas existentes.

**Qual é a maneira mais segura de transportar um tema de uma apresentação para outra?**

Ao mover um slide e preservar sua aparência de origem, clone o mestre de origem no destino e clone o slide com esse mestre usando [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslidecollection/addclone/) e [ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/). Isso mantém o mestre, os layouts e o tema juntos.

**Como posso ver os valores efetivos após herança e substituições?**

Use [IThemeable::CreateThemeEffective](https://reference.aspose.com/slides/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) para um slide ou layout de tema e os métodos de dados efetivos correspondentes para objetos de formato, como [Background::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/background/geteffective/) e [FillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/geteffective/). Essas APIs retornam os valores resolvidos após a aplicação de herança e substituições.