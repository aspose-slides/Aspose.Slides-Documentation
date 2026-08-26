---
title: Gerenciar Temas de Apresentação em C++
linktitle: Tema de Apresentação
type: docs
weight: 10
url: /pt/cpp/presentation-theme/
keywords:
- Tema PowerPoint
- tema de apresentação
- tema de slide
- definir tema
- alterar tema
- gerenciar tema
- tema externo
- THMX
- cor do tema
- paleta adicional
- fonte do tema
- estilo do tema
- efeito do tema
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Temas principais de apresentação no Aspose.Slides para C++ para criar, personalizar e converter arquivos PowerPoint com branding consistente."
---
## **Introdução**

Um tema de apresentação define um conjunto coordenado de cores, fontes, estilos de fundo, preenchimentos, linhas e efeitos. Objetos compatíveis com tema referem‑se a essas definições compartilhadas em vez de armazenar cada propriedade visual como um valor fixo, de modo que uma alteração de tema possa atualizar muitos objetos de uma só vez.

Em Aspose.Slides, o tema ao nível da apresentação está disponível através de [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_mastertheme/). Uma apresentação também pode conter substituições de tema em níveis inferiores. Um master pode substituir o tema da apresentação através de [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), enquanto um layout ou um slide individual pode usar [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). Na prática, o tema efetivo para um slide é resolvido por meio desta cadeia de herança: tema da apresentação, substituição do master, substituição do layout e substituição do slide.

![Componentes do tema: cores, fontes, estilos de fundo e efeitos](theme-constituents.png)

As seções abaixo mostram os fluxos de trabalho de tema mais comuns: inspecionar um tema, alterar cores e fontes, copiar ou aplicar um tema, atualizar estilos de fundo e efeito, e ler valores efetivos após herança e substituições terem sido resolvidas.

## **Inspecionar um Tema**

O objeto [MasterTheme](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/mastertheme/) expõe os métodos [get_ColorScheme()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) e [get_FormatScheme()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Inspecionar essas coleções antes de alterá‑las é especialmente útil quando uma apresentação provém de uma fonte externa, pois o número e o conteúdo das entradas de estilo podem variar.

O exemplo a seguir lê as principais propriedades do tema e informa quantos estilos de fundo, preenchimento, linha e efeito estão armazenados no tema:

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

Se um arquivo usa vários masters, não presuma que cada slide tenha o mesmo tema efetivo. Inspecione o master associado ao slide e use o fluxo de trabalho de tema efetivo mostrado mais adiante neste artigo quando substituições de layout ou slide puderem estar presentes.

## **Alterar Cores do Tema**

Preenchimentos, linhas e textos compatíveis com tema podem referir‑se a uma cor lógica da enumeração [SchemeColor](https://reference.aspose.com/slides/pt/cpp/aspose.slides/schemecolor/). Quando você altera a entrada correspondente em [IColorScheme](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/icolorscheme/), todos os objetos que ainda referenciam aquela cor de tema são resolvidos contra o novo valor. Objetos que usam uma cor RGB direta não são alterados por uma atualização de cor de tema.

O exemplo completo a seguir cria uma forma que usa `Accent4`, altera a cor `Accent4` do tema para vermelho, salva a apresentação, reabre‑a e imprime a cor de preenchimento efetiva:

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

Como o retângulo continua vinculado a `Accent4`, sua cor visível torna‑se vermelha após a mudança do tema. Se você substituir a cor do esquema por uma cor direta na forma, alterações posteriores a `Accent4` não afetarão mais esse preenchimento.

### **Usar Cores da Paleta Adicional**

O PowerPoint gera variantes mais claras e mais escuras a partir de uma cor de tema aplicando transformações de cor. Aspose.Slides expõe essas transformações por meio de [ColorTransformOperation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/colortransformoperation/).

![Cores principais do tema e cores mais claras e mais escuras geradas a partir da paleta adicional](additional-palette-colors.png)

**1** - Cores principais do tema.  
**2** - Variantes mais claras e mais escuras produzidas a partir das cores principais do tema.

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

Essas variantes permanecem baseadas na cor do tema. Se `Accent4` mudar mais tarde, as cores transformadas são recalculadas a partir do novo valor de `Accent4`.

### **Mapear Valores `SchemeColor` para Slots `IColorScheme`**

A enumeração [SchemeColor](https://reference.aspose.com/slides/pt/cpp/aspose.slides/schemecolor/) usa `Text1`, `Background1`, `Text2` e `Background2`, enquanto [IColorScheme](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/icolorscheme/) expõe os mesmos slots de tema como `Dark1`, `Light1`, `Dark2` e `Light2`. O mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

São nomes alternativos para os mesmos slots de tema; não são valores convertidos dinamicamente de uma forma para outra.

## **Alterar Fontes do Tema**

Um esquema de fontes do tema contém um conjunto de fontes principal para títulos e um conjunto de fontes secundário para o corpo do texto. Os métodos [FontScheme::get_Major()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/fontscheme/get_major/) e [FontScheme::get_Minor()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/fontscheme/get_minor/) expõem esses conjuntos.

Identificadores de fonte de tema compatíveis com PowerPoint podem ser usados na formatação de texto:

* `+mn-lt` - Fonte do corpo Latin (Minor Latin Font)
* `+mj-lt` - Fonte do título Latin (Major Latin Font)
* `+mn-ea` - Fonte do corpo East Asian (Minor East Asian Font)
* `+mj-ea` - Fonte do título East Asian (Major East Asian Font)

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

O título segue a fonte principal e o texto do corpo segue a fonte secundária. Texto que possui um nome de fonte explícito em vez de um identificador de tema não trocará automaticamente quando o esquema de fontes do tema mudar.

As coleções de fontes principal e secundária também podem conter mapeamentos de fonte para sistemas de escrita individuais, como cirílico, árabe, japonês, georgiano e thaana. Para inspecionar, adicionar, substituir ou remover esses mapeamentos, veja [Script‑Specific Theme Fonts](/slides/pt/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Para mais informações sobre fontes em apresentações, veja [PowerPoint Fonts](/slides/pt/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Copiar ou Aplicar um Tema**

Os fluxos de trabalho abaixo resolvem diferentes problemas relacionados a temas.

### **Aplicar um Tema Externo a Slides Dependentes de um Master**

Use [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) quando você tem um arquivo de tema PowerPoint (`.thmx`) e deseja restilizar todos os slides que dependem de um master específico. Selecione o master da coleção [Presentation::get_Masters](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_masters/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslidecollection/), e passe o caminho do arquivo de tema para o método.

O método realiza as seguintes operações:

1. Cria um novo slide master baseado no master selecionado.  
2. Aplica o tema externo ao novo master.  
3. Atribui o novo master a todos os slides que anteriormente dependiam do master selecionado.  
4. Retorna o recém‑criado [IMasterSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslide/).

O exemplo a seguir aplica um tema externo aos slides que dependem do primeiro master e salva a apresentação:

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

Um tema inválido, corrompido ou não suportado pode causar [PptxException](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pptxexception/) ou uma de suas subclasses relacionadas a formato. Valide os caminhos fornecidos pelos usuários, trate falhas de acesso ao sistema de arquivos e salve a apresentação somente após o tema ter sido aplicado com sucesso.

Somente os slides que dependiam do master selecionado são reatribuídos. Slides associados a outros masters mantêm seus masters e temas existentes. Cores, fontes, preenchimentos, linhas, fundos e efeitos compatíveis com tema são resolvidos contra o tema externo. Cores, fontes, preenchimentos e outras formatações atribuídas diretamente podem permanecer inalteradas. Substituições ao nível de layout e slide também podem prevalecer sobre valores herdados do novo master.

O tema pode referenciar fontes que não estão disponíveis no ambiente de tempo de execução. Para renderização e exportação consistentes, instale as fontes necessárias, forneça‑as através de [fontes personalizadas](/slides/pt/cpp/custom-font/), ou configure [substituição de fontes](/slides/pt/cpp/font-substitution/).

Este é um fluxo de trabalho direto ao nível de master: o método aceita um caminho de arquivo `.thmx` e não requer a criação manual de substituições de tema ao nível de slide ou layout.

### **Aplicar Temas Externos Diferentes em uma Apresentação com Múltiplos Masters**

Quando o master relevante não é conhecido antecipadamente, obtenha‑lo a partir de um slide representativo através de [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/get_layoutslide/) e [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilayoutslide/get_masterslide/). Armazene as referências originais aos masters antes de aplicar quaisquer temas, pois cada chamada cria outro master na apresentação.

O exemplo a seguir usa slides de duas seções para localizar seus masters e aplica um tema externo diferente a cada grupo:

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

A primeira chamada afeta somente os slides que dependiam de `firstGroupMaster`, e a segunda chamada afeta somente os slides que dependiam de `secondGroupMaster`. Slides pertencentes a qualquer outro master não são restilizados.

### **Preservar um Tema de Origem ao Mover Slides**

Se você deseja mover um slide para outra apresentação preservando seu design original, clone o master de origem na apresentação de destino com [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslidecollection/addclone/), depois clone o slide com [ISlideCollection::AddClone()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/) e o master clonado. Isso traz o master, seus layouts e o tema associado juntos.

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

Este é o fluxo de trabalho recomendado quando o slide de origem deve permanecer visualmente idêntico no destino. Clonar apenas o conteúdo para um master de destino não relacionado pode mudar cores, fontes, fundos e efeitos controlados por tema.

### **Aplicar Valores de Tema a um Slide Existente**

Se o slide de destino precisar permanecer no master e layout atuais, inicialize uma substituição ao nível de slide a partir do tema de origem. Os métodos [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) e [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) copiam os três principais componentes do tema para a substituição.

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

Isso altera o tema usado por aquele slide sem mudar o tema herdado por outros slides. Para remover a substituição local e voltar aos valores herdados, chame [OverrideTheme::Clear()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/overridetheme/clear/).

### **Aplicar uma Substituição de Tema a um Layout**

Uma substituição ao nível de layout aplica‑se a slides que usam esse layout, salvo se um slide particular possuir sua própria substituição. Os mesmos métodos de inicialização podem ser usados através do [IOverrideThemeManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/ioverridethememanager/) do layout:

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

Use um tema ao nível de master ou apresentação quando muitos layouts e slides devem compartilhar o mesmo design base, use uma substituição de layout quando uma família de layouts precisar de estilização diferente, e use uma substituição de slide apenas para exceções reais. Substituições excessivas ao nível de slide dificultam a previsão de mudanças globais de tema posteriores.

## **Atualizar Estilos de Fundo do Tema**

Os preenchimentos de fundo do tema são armazenados em [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). O PowerPoint pode apresentar mais opções de fundo em sua interface do que o número de definições de preenchimento realmente armazenadas nesta coleção, pois a UI pode combinar preenchimentos de tema com cores de tema e outras referências de estilo.

![Galeria de estilos de fundo do PowerPoint para um tema de apresentação](presentation-design_8.png)

Antes de usar um estilo de fundo, inspecione a coleção armazenada e o índice atual via [Background::get_StyleIndex()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` usa `0` para indicar nenhum preenchimento temático; valores positivos são referências a estilos de fundo temáticos. Isso difere da indexação direta de uma coleção C++ com `idx_get(0)`, onde `0` significa o primeiro item armazenado. Não presuma que cada apresentação contenha o mesmo número de estilos de preenchimento de fundo.

O exemplo a seguir relata a contagem de preenchimentos de fundo disponíveis, atribui uma referência de fundo temático ao primeiro master e salva a apresentação:

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

O resultado visível depende da entrada de tema referenciada pelo master e de quaisquer substituições de fundo no layout ou no slide. Se um slide usar seu próprio fundo, mudar apenas o fundo do master pode não alterar aquele slide. Use [Background::GetEffective()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/background/geteffective/) quando precisar conhecer o fundo final após a aplicação da herança.

{{% alert color="warning" title="Warning" %}}
Não trate `StyleIndex` como um índice baseado em zero de uma coleção. Também evite codificar um número de estilo de um arquivo e presumir que ele terá a mesma aparência em outro arquivo; definições de estilo de tema são específicas da apresentação.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Para formatação direta de fundo e herança de fundo, veja [Presentation Background](/slides/pt/cpp/presentation-background/).
{{% /alert %}}

## **Atualizar Efeitos do Tema**

Um esquema de formato de tema contém coleções separadas de [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/formatscheme/get_linestyles/) e [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Temas típicos do Office costumam conter três entradas principais que correspondem visualmente a formatações sutil, moderada e intensa, mas o código deve inspecionar cada coleção em vez de assumir uma contagem fixa.

![Efeitos sutis, moderados e intensos do tema aplicados à mesma forma](presentation-design_10.png)

Ao acessar essas coleções em C++, o índice da coleção é baseado em zero: `idx_get(0)` é o primeiro estilo armazenado e `idx_get(2)` é o terceiro. Os índices de referência de estilo de uma forma são um conceito separado, exposto por [IShapeStyle](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapestyle/). Modificar um estilo de tema afeta formas que referenciam aquele estilo; formas com formatação direta podem permanecer inalteradas.

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

![Estilos de efeito do tema após alterar linhas, preenchimento e sombra](presentation-design_11.png)

## **Ler Valores Efetivos do Tema**

Objetos de tema bruto informam o que está definido em um nível específico. Valores efetivos informam o que um slide ou forma realmente usa após herança e substituições locais serem resolvidas. Para um slide, chame [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Para um fundo, use [Background::GetEffective()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/background/geteffective/), e para um preenchimento, use [FillFormat::GetEffective()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/geteffective/).

O exemplo a seguir lê o tema efetivo, o fundo e o primeiro preenchimento de forma de um slide:

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

Use dados efetivos para diagnósticos de renderização, validação e comparações. Se você inspecionar apenas [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_mastertheme/), pode perder uma substituição de master, layout, slide ou forma que altere a aparência final.

## **FAQ**

**Aplicar um tema externo afeta todos os slides da apresentação?**

Não. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) reatribui somente os slides que dependem do master selecionado. Slides que usam outros masters mantêm seus temas existentes.

**Posso aplicar um tema a um único slide sem mudar o master?**

Sim. Use o [IOverrideThemeManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/ioverridethememanager/) do slide e inicialize seu tema de substituição. A mudança permanece local ao slide; outros slides continuam a herdar seus temas atuais.

**Qual é a maneira mais segura de transferir um tema de uma apresentação para outra?**

Ao mover um slide e preservar sua aparência original, clone o master de origem no destino e clone o slide com esse master usando [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/imasterslidecollection/addclone/) e [ISlideCollection::AddClone()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidecollection/addclone/). Isso mantém o master, os layouts e o tema juntos.

**Como posso ver os valores efetivos após herança e substituições?**

Use [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) para um slide ou layout de tema e os métodos de dados efetivos correspondentes para objetos de formato, como [Background::GetEffective()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/background/geteffective/) e [FillFormat::GetEffective()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/fillformat/geteffective/). Essas APIs retornam os valores resolvidos após a aplicação de herança e substituições.