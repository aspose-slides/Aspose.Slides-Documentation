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
description: "Domine os temas de apresentação no Aspose.Slides para C++ para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define as propriedades dos elementos de design. Quando você seleciona um tema de apresentação, está essencialmente escolhendo um conjunto específico de elementos visuais e suas propriedades.

No PowerPoint, um tema compreende cores, [fontes](/slides/pt/cpp/powerpoint-fonts/), [estilos de plano de fundo](/slides/pt/cpp/presentation-background/) e efeitos.

![theme-constituents](theme-constituents.png)

## **Alterar Cor do Tema**

Um tema do PowerPoint usa um conjunto específico de cores para diferentes elementos em um slide. Se você não gostar das cores, pode alterá‑as aplicando novas cores ao tema. Para permitir que você selecione uma nova cor de tema, o Aspose.Slides fornece valores na enumeração [SchemeColor](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

Este código C++ mostra como alterar a cor de destaque de um tema:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

Você pode determinar o valor efetivo da cor resultante desta forma:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Cor [A=255, R=128, G=100, B=162])
```

Para demonstrar ainda mais a operação de mudança de cor, criamos outro elemento e atribuímos a ele a cor de destaque (da operação inicial). Em seguida, alteramos a cor no tema:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

A nova cor é aplicada automaticamente em ambos os elementos.

### **Definir Cor do Tema a partir de uma Paleta Adicional**

Quando você aplica transformações de luminância à cor principal do tema(1), cores da paleta adicional(2) são formadas. Você pode então definir e obter essas cores de tema. 

![additional-palette-colors](additional-palette-colors.png)

**1**‑ Cores principais do tema

**2**‑ Cores da paleta adicional.

Este código C++ demonstra uma operação onde as cores da paleta adicional são obtidas a partir da cor principal do tema e então usadas em formas:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Realce 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Realce 4, mais claro 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Realce 4, mais claro 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Realce 4, mais claro 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Realce 4, mais escuro 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Realce 4, mais escuro 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **Mapear `SchemeColor` para Cores `IColorScheme`**

Ao trabalhar com [SchemeColor](https://reference.aspose.com/slides/pt/cpp/aspose.slides/schemecolor/), você pode notar que ele contém os seguintes valores de cor de tema:

`Background1`, `Background2`, `Text1` e `Text2`.

Entretanto, `Presentation::get_MasterTheme()::get_ColorScheme()` devolve um [IColorScheme](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/icolorscheme/), que expõe as cores correspondentes como:

`Dark1`, `Dark2`, `Light1` e `Light2`.

Essa diferença está apenas no nome. Esses valores referem‑se aos mesmos slots de cor de tema e o mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Não há conversão dinâmica entre `Text`/`Background` e `Dark`/`Light`. Elas são simplesmente nomes alternativos para as mesmas cores de tema.

Essa diferença de nomenclatura vem da terminologia do Microsoft Office. Versões mais antigas do Office usavam `Dark 1`, `Light 1`, `Dark 2` e `Light 2`, enquanto versões mais recentes da interface exibem os mesmos slots como `Text 1`, `Background 1`, `Text 2` e `Background 2`.

## **Alterar Fonte do Tema**

Para permitir que você selecione fontes para temas e outros propósitos, o Aspose.Slides usa estes identificadores especiais (semelhantes aos usados no PowerPoint):

* **+mn-lt** — Fonte do Corpo Latin (Minor Latin Font)
* **+mj-lt** — Fonte de Cabeçalho Latin (Major Latin Font)
* **+mn-ea** — Fonte do Corpo East Asian (Minor East Asian Font)
* **+mj-ea** — Fonte do Corpo East Asian (Major East Asian Font)

Este código C++ mostra como atribuir a fonte Latin a um elemento do tema:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

Este código C++ mostra como mudar a fonte do tema da apresentação:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

A fonte em todas as caixas de texto será atualizada.

{{% alert color="primary" title="DICA" %}} 
Você pode querer ver [fontes do PowerPoint](/slides/pt/cpp/powerpoint-fonts/).
{{% /alert %}}

## **Alterar Estilo de Plano de Fundo do Tema**

Por padrão, o aplicativo PowerPoint fornece 12 planos de fundo predefinidos, mas apenas 3 desses 12 são salvos em uma apresentação típica. 

![todo:image_alt_text](presentation-design_8.png)

Por exemplo, depois de salvar uma apresentação no aplicativo PowerPoint, você pode executar este código C++ para descobrir o número de planos de fundo predefinidos na apresentação:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
Usando a propriedade [BackgroundFillStyles](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) da classe [FormatScheme](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.theme.i_format_scheme/), você pode adicionar ou acessar o estilo de plano de fundo em um tema do PowerPoint. 
{{% /alert %}}

Este código C++ mostra como definir o plano de fundo para uma apresentação:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**Guia de índice**: 0 indica sem preenchimento. O índice inicia em 1.

{{% alert color="primary" title="DICA" %}} 
Você pode querer ver [plano de fundo do PowerPoint](/slides/pt/cpp/presentation-background/).
{{% /alert %}}

## **Alterar Efeito do Tema**

Um tema do PowerPoint geralmente contém 3 valores para cada array de estilo. Esses arrays são combinados nesses 3 efeitos: sutil, moderado e intenso. Por exemplo, este é o resultado quando os efeitos são aplicados a uma forma específica:

![todo:image_alt_text](presentation-design_10.png)

Usando 3 propriedades ([FillStyles](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) da classe [FormatScheme](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.theme.i_format_scheme/) você pode mudar os elementos de um tema (de forma ainda mais flexível que as opções do PowerPoint).

Este código C++ mostra como mudar um efeito de tema alterando partes dos elementos:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

As alterações resultantes em cor de preenchimento, tipo de preenchimento, efeito de sombra, etc.:

![todo:image_alt_text](presentation-design_11.png)

## **Perguntas Frequentes**

**Posso aplicar um tema a um único slide sem alterar o mestre?**

Sim. O Aspose.Slides oferece substituições de tema a nível de slide, permitindo aplicar um tema local apenas a esse slide enquanto mantém o tema mestre intacto (via o [SlideThemeManager](https://reference.aspose.com/slides/pt/cpp/aspose.slides.theme/slidethememanager/)).

**Qual é a maneira mais segura de transferir um tema de uma apresentação para outra?**

[Clonar slides](/slides/pt/cpp/clone-slides/) juntamente com seu mestre para a apresentação de destino. Isso preserva o mestre original, os layouts e o tema associado, mantendo a aparência consistente.

**Como posso ver os valores “efetivos” após toda a herança e sobrescritas?**

Use as visualizações ["effective"](/slides/pt/cpp/shape-effective-properties/) da API para tema/cor/fonte/efeito. Elas retornam as propriedades resolvidas e finais após aplicar o mestre mais quaisquer sobrescritas locais.