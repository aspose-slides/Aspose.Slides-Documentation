---
title: Criar e aplicar efeitos WordArt em C++
linktitle: WordArt
type: docs
weight: 110
url: /pt/cpp/wordart/
keywords:
- WordArt
- criar WordArt
- modelo WordArt
- efeito WordArt
- efeito de sombra
- efeito de exibição
- efeito de brilho
- transformação WordArt
- efeito 3D
- efeito de sombra externa
- efeito de sombra interna
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Crie e personalize efeitos WordArt no Aspose.Slides para C++. Este guia passo a passo ajuda desenvolvedores a aprimorar apresentações com texto profissional em C++."
---
## **Visão geral**

Os efeitos WordArt permitem que você adicione texto estilizado e visualmente atraente às suas apresentações do PowerPoint. Com Aspose.Slides, os desenvolvedores podem criar, personalizar e gerenciar WordArt programaticamente, assim como no Microsoft PowerPoint—sem necessidade de ter o Office instalado. Este artigo fornece uma visão geral sobre como trabalhar com WordArt, incluindo como aplicar transformações de texto, estilos de preenchimento, contornos, sombras e outras opções de formatação para tornar o conteúdo da sua apresentação mais expressivo e envolvente. O WordArt permite tratar o texto como um objeto gráfico. Ele consiste em efeitos ou modificações especiais aplicadas ao texto para torná‑lo mais atraente ou perceptível.

## **Criar um modelo WordArt simples e aplicá‑lo ao texto**

**Usando Aspose.Slides** 

Primeiro, criamos um texto simples usando este código C++: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Agora, definimos a altura da fonte do texto para um valor maior para que o efeito fique mais perceptível através deste código:

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Usando Microsoft PowerPoint**

Acesse o menu de efeitos WordArt no Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

No painel à direita, você pode escolher um efeito WordArt predefinido. No painel à esquerda, pode especificar as configurações para um novo WordArt. 

Estes são alguns dos parâmetros ou opções disponíveis:

![todo:image_alt_text](image-20200930114015-3.png)

**Usando Aspose.Slides**

Aqui, aplicamos a cor de padrão SmallGrid ao texto e adicionamos uma borda de texto preta com largura 1 usando este código:

``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

O texto resultante:

![todo:image_alt_text](image-20200930114108-4.png)

## **Aplicar outros efeitos WordArt**

**Usando Microsoft PowerPoint**

Pela interface do programa, você pode aplicar esses efeitos a um texto, bloco de texto, forma ou elemento similar:

![todo:image_alt_text](image-20200930114129-5.png)

Por exemplo, os efeitos Sombra, Reflexão e Brilho podem ser aplicados a um texto; os efeitos Formato 3D e Rotação 3D podem ser aplicados a um bloco de texto; a propriedade Borda Suave pode ser aplicada a um objeto Forma (ela ainda tem efeito quando nenhuma propriedade Formato 3D está definida). 

### **Aplicar efeitos de sombra ao texto**

Aqui, pretendemos definir as propriedades relacionadas apenas ao texto. Aplicamos o efeito de sombra ao texto usando este código em C++:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

A API Aspose.Slides oferece três tipos de sombras: OuterShadow, InnerShadow e PresetShadow. 

Com PresetShadow, você pode aplicar uma sombra ao texto (usando valores predefinidos). 

**Usando Microsoft PowerPoint**

No PowerPoint, você pode usar um tipo de sombra. Veja um exemplo:

![todo:image_alt_text](image-20200930114225-6.png)

**Usando Aspose.Slides**

O Aspose.Slides realmente permite aplicar dois tipos de sombra ao mesmo tempo: InnerShadow e PresetShadow.

**Observações:**

- Quando OuterShadow e PresetShadow são usados juntos, apenas o efeito OuterShadow é aplicado. 
- Se OuterShadow e InnerShadow forem usados simultaneamente, o efeito resultante ou aplicado depende da versão do PowerPoint. Por exemplo, no PowerPoint 2013 o efeito é dobrado. Mas no PowerPoint 2007 o efeito OuterShadow é aplicado. 

### **Aplicar efeitos de reflexão**

Adicionamos uma reflexão ao texto através deste exemplo de código em C++:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

### **Aplicar efeitos de brilho**

Aplicamos o efeito de brilho ao texto para fazê‑lo brilhar ou se destacar usando este código:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

O resultado da operação:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Você pode alterar os parâmetros de sombra, exibição e brilho. As propriedades dos efeitos são definidas separadamente para cada porção do texto. 

{{% /alert %}} 

### **Usar transformações no WordArt**

Usamos o método set_Transform (aplicado ao bloco inteiro de texto) através deste código:

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

O resultado:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Tanto o Microsoft PowerPoint quanto o Aspose.Slides para C++ fornecem um número determinado de tipos de transformação predefinidos. 

{{% /alert %}} 

**Usando PowerPoint**

Para acessar os tipos de transformação predefinidos, vá em: **Format**->**TextEffect**->**Transform**

**Usando Aspose.Slides**

Para selecionar um tipo de transformação, use o enum TextShapeType. 

### **Aplicar efeitos 3D ao texto e às formas**

Definimos um efeito 3D em uma forma de texto usando este código de exemplo:

``` cpp 
auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

O texto resultante e sua forma:

![todo:image_alt_text](image-20200930114816-9.png)

Aplicamos um efeito 3D ao texto com este código C++:

``` cpp 
auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

O resultado da operação:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

A aplicação de efeitos 3D a textos ou suas formas e as interações entre os efeitos baseiam‑se em determinadas regras. 

Considere uma cena para um texto e a forma que contém esse texto. O efeito 3D contém a representação do objeto 3D e a cena na qual o objeto foi colocado. 

- Quando a cena é definida tanto para a forma quanto para o texto, a cena da forma tem prioridade mais alta—a cena do texto é ignorada. 
- Quando a forma não possui sua própria cena, mas tem representação 3D, a cena do texto é usada. 
- Caso contrário—quando a forma originalmente não tem efeito 3D—ela permanece plana e o efeito 3D é aplicado apenas ao texto. 

Essas descrições estão relacionadas aos métodos ThreeDFormat.getLightRig() e ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Aplicar efeitos de sombra externa a formas**
O Aspose.Slides para C++ fornece as classes [**IOuterShadow**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.effects.i_outer_shadow) e [**IInnerShadow**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.effects.i_inner_shadow) que permitem aplicar efeitos de sombra a um texto contido em TextFrame. Siga estes passos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation). 
2. Obtenha a referência de um slide usando seu índice. 
3. Adicione uma AutoShape do tipo Rectangle ao slide. 
4. Acesse o TextFrame associado à AutoShape. 
5. Defina o FillType da AutoShape como NoFill. 
6. Instancie a classe OuterShadow 
7. Defina o BlurRadius da sombra. 
8. Defina a Direction da sombra 
9. Defina a Distance da sombra. 
10. Defina o RectanglelAlign como TopLeft. 
11. Defina o PresetColor da sombra como Black. 
12. Salve a apresentação como um arquivo PPTX. 

Este código de exemplo em C++—uma implementação dos passos acima—mostra como aplicar o efeito de sombra externa a um texto:

``` cpp
auto pres = System::MakeObject<Presentation>();
// Obtenha a referência do slide
auto sld = pres->get_Slides()->idx_get(0);

// Adicione um AutoShape do tipo Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Adicione TextFrame ao retângulo
ashp->AddTextFrame(u"Aspose TextBox");

// Desative o preenchimento da forma caso queiramos obter sombra do texto
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Adicione sombra externa e defina todos os parâmetros necessários
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Salve a apresentação no disco
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **Aplicar efeitos de sombra interna a formas**
Siga estes passos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation). 
2. Obtenha a referência do slide. 
3. Adicione uma AutoShape do tipo Rectangle. 
4. Ative InnerShadowEffect. 
5. Defina todos os parâmetros necessários. 
6. Defina o ColorType como Scheme. 
7. Defina a Scheme Color. 
8. Salve a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Este código de exemplo (baseado nos passos acima) mostra como adicionar um conector entre duas formas em C++:

``` cpp
auto presentation = System::MakeObject<Presentation>();
// Obtenha a referência de um slide
auto slide = presentation->get_Slides()->idx_get(0);

// Adicione um AutoShape do tipo Rectangle
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Adicione TextFrame ao retângulo
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Ative InnerShadowEffect    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Defina todos os parâmetros necessários
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// Defina ColorType como Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Defina Scheme Color
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Salve a apresentação
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso usar os efeitos WordArt com diferentes fontes ou scripts (por exemplo, árabe, chinês)?**

Sim, o Aspose.Slides oferece suporte a Unicode e funciona com todas as principais fontes e scripts. Os efeitos WordArt, como sombra, preenchimento e contorno, podem ser aplicados independentemente do idioma, embora a disponibilidade de fontes e a renderização possam depender das fontes do sistema.

**Posso aplicar efeitos WordArt a elementos do mestre de slides?**

Sim, você pode aplicar efeitos WordArt a formas nos slides mestres, incluindo espaços reservados para título, rodapés ou texto de plano de fundo. As alterações feitas no layout mestre serão refletidas em todos os slides associados.

**Os efeitos WordArt afetam o tamanho do arquivo da apresentação?**

Um pouco. Efeitos WordArt como sombras, brilhos e preenchimentos degradê podem aumentar ligeiramente o tamanho do arquivo devido ao metadado de formatação adicional, mas a diferença costuma ser insignificante.

**Posso visualizar o resultado dos efeitos WordArt sem salvar a apresentação?**

Sim, você pode renderizar slides que contêm WordArt em imagens (por exemplo, PNG, JPEG) usando o método `GetImage` das interfaces [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/) ou [ISlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islide/). Isso permite pré‑visualizar o resultado na memória ou na tela antes de salvar ou exportar a apresentação completa.