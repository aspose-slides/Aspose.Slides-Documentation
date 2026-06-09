---
title: Criar Efeitos 3D em Apresentações Usando C++
linktitle: Apresentação 3D
type: docs
weight: 232
url: /pt/cpp/3d-presentation/
keywords:
- PowerPoint 3D
- apresentação 3D
- rotação 3D
- profundidade 3D
- extrusão 3D
- gradiente 3D
- texto 3D
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aplicar e renderizar efeitos 3D para formas e texto do PowerPoint em C++ com Aspose.Slides. Configurar câmera, iluminação, material, extrusão, preenchimentos e texto 3D."
---
## **Visão geral**

Aspose.Slides for C++ pode criar, editar, preservar e renderizar a formatação 3D no estilo PowerPoint para formas e texto. Este artigo abrange efeitos 3D como rotação, extrusão, chanfrados, iluminação, material, preenchimentos em gradiente ou imagem, e texto 3D.

{{% alert color="primary" %}}
Este artigo trata dos efeitos de formatação 3D em formas e texto do PowerPoint. Não se trata de inserir ou editar arquivos de modelo 3D independentes. Quando você exporta um slide para uma imagem, PDF ou HTML, o Aspose.Slides renderiza esses efeitos 3D na saída 2D exportada.
{{% /alert %}}

## **Conceitos de Formatação 3D**

Use a interface [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/) e o método [get_ThreeDFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/get_threedformat/) para aplicar formatação 3D a uma forma. O método retorna [IThreeDFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/), que controla a cena 3D para essa forma.

Para texto, use a interface [ITextFrameFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframeformat/) e o método [get_ThreeDFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframeformat/get_threedformat/) . Isso aplica formatação 3D ao quadro de texto em vez do corpo da forma.

Os métodos mais importantes são:

| Método | O que controla | Quando usar |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/get_camera/) | Ponto de vista, tipo de câmera predefinido, rotação, zoom e perspectiva. | Rotacione o objeto no espaço 3D ou corresponda a uma predefinição de rotação 3D do PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/get_lightrig/) | Predefinição de luz, direção e rotação da luz. | Altere como realces e sombras aparecem na superfície 3D. |
| [set_Material](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/set_material/) | Material da superfície, como plano, fosco, plástico ou metal. | Faça a mesma geometria parecer mais plana, suave, brilhante ou metálica. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Até onde a forma se estende para trás a partir da sua face frontal. | Transforme uma forma plana em um objeto 3D visivelmente espesso. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Cor das laterais extrudadas. | Torne a profundidade visível ou coordene a cor das laterais com o preenchimento frontal. |
| [set_Depth](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/set_depth/) | Profundidade 3D adicional usada pela formatação 3D do PowerPoint. | Ajuste fino da profundidade para formas ou texto, especialmente junto com as configurações de chanfrado e material. |
| [get_BevelTop](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/get_beveltop/) e [get_BevelBottom](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Bordas elevadas ou arredondadas nas faces frontal e traseira. | Adicione uma borda suavizada ou moldada em vez de uma face plana e afiada. |
| [get_ContourColor](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/get_contourcolor/) e [set_ContourWidth](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Contorno ao redor do objeto 3D. | Enfatize o limite do objeto na saída renderizada. |

## **Criar uma Forma 3D**

Uma forma geralmente precisa de quatro tipos de configurações antes de parecer convincentemente 3D:

- Configurações de câmera, pois a visualização frontal padrão pode ocultar a extrusão.
- Configurações de luz, pois a iluminação torna as faces e laterais legíveis.
- Configurações de material, pois a superfície afeta como a luz é renderizada.
- Configurações de extrusão ou profundidade, pois uma forma plana precisa de espessura.

O exemplo a seguir cria um retângulo, adiciona texto à sua face frontal, aplica formatação 3D, salva a apresentação como PPTX e renderiza o slide para uma imagem PNG.

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A imagem do slide renderizado mostra o retângulo como um bloco 3D espesso:

![Retângulo 3D azul renderizado com texto 3D branco na face frontal](img_01_01.png)

## **Rotacionar uma Forma com a Câmera**

No PowerPoint, a rotação 3D é configurada a partir do painel 3‑D Rotation. Os valores de rotação X, Y e Z correspondem à rotação que você define por meio da API de câmera.

![Painel 3‑D Rotation do PowerPoint com valores de rotação X, Y e Z destacados](img_02_01.png)

No Aspose.Slides, defina o tipo de câmera e a rotação através de [IThreeDFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/):

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

Use a câmera quando precisar mudar como o visualizador vê o objeto. Ela não altera a geometria 2D da forma no slide. Ela altera o ponto de vista 3D usado pelo PowerPoint e pelo Aspose.Slides ao renderizar.

## **Adicionar Extrusão e Profundidade**

A extrusão faz uma forma parecer espessa ao estendê‑la atrás da face frontal. No PowerPoint, o controle de profundidade define essa espessura visível, e o controle de cor define a cor das faces laterais.

![Controles de profundidade do PowerPoint mapeados para as propriedades de cor da extrusão e altura da extrusão](img_02_02.png)

Defina [set_ExtrusionHeight](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/set_extrusionheight/) para a espessura e [get_ExtrusionColor](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) para a cor das laterais:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Use [set_Depth](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/set_depth/) quando precisar trabalhar diretamente com o valor de profundidade do PowerPoint ou combinar profundidade com chanfrado, material e efeitos de texto. Em muitos cenários de forma, `set_ExtrusionHeight` é a configuração mais clara porque expressa diretamente a extrusão visível.

## **Usar Preenchimentos em Gradiente ou Imagem com Efeitos 3D**

A formatação 3D é independente do preenchimento da forma. Você pode aplicar uma cor sólida, gradiente, padrão ou preenchimento de imagem à face frontal e ainda usar as mesmas configurações de câmera, luz, material e extrusão.

Este exemplo aplica um preenchimento em gradiente à forma e uma cor de extrusão mais escura às laterais:

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

A saída renderizada mantém o gradiente na face frontal e renderiza a extrusão separadamente:

![Retângulo 3D renderizado com preenchimento gradiente azul‑para‑laranja e extrusão laranja](img_02_03.png)

Para usar um preenchimento de imagem, adicione a imagem à apresentação e atribua‑a ao preenchimento da forma:

```cpp
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

A imagem é renderizada na face frontal, enquanto a extrusão é renderizada como a superfície lateral 3D:

![Retângulo 3D renderizado com preenchimento fotográfico na face frontal e extrusão laranja](img_02_04.png)

## **Aplicar Formatação 3D ao Texto**

A formatação 3D da forma afeta o corpo da forma. A formatação 3D do texto afeta o quadro de texto. Isso é útil para efeitos semelhantes ao WordArt, onde as letras precisam de extrusão, material, iluminação e configurações de câmera.

O exemplo a seguir cria texto com preenchimento de padrão, aplica uma transformação WordArt e configura as definições 3D em [ITextFrameFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframeformat/):

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O texto é renderizado como letras 3D curvadas e extrudidas:

![Texto 3D renderizado com transformação WordArt arqueada, preenchimento de padrão laranja e extrusão escura](img_02_05.png)

## **Comportamento de Exportação e Renderização**

Aspose.Slides preserva a formatação 3D ao salvar em formatos PowerPoint como PPTX. Ao renderizar ou exportar para formatos de layout fixo, a cena 3D é rasterizada ou desenhada na saída como um resultado 2D. Isso ocorre ao renderizar slides para [PNG](/slides/pt/cpp/convert-powerpoint-to-png/), exportar para [PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/), exportar para [HTML](/slides/pt/cpp/convert-powerpoint-to-html/), ou gerar quadros para [video conversion](/slides/pt/cpp/convert-powerpoint-to-video/).

Tenha em mente os seguintes pontos:

- As imagens e PDFs exportados não são interativos. O objeto não pode ser rotacionado pelo visualizador após a exportação.
- A aparência final depende da combinação de câmera, rig de luz, material, extrusão, preenchimento e escala do slide.
- Se precisar inspecionar valores de formatação herdados ou baseados em tema, leia as [propriedades efetivas da forma](/slides/pt/cpp/shape-effective-properties/).
- Alguns formatos de saída não podem armazenar a formatação 3D editável do PowerPoint. Nesses formatos, o resultado visual é renderizado em vez de preservado como configurações 3D editáveis.

## **Perguntas Frequentes**

**O Aspose.Slides pode criar apresentações 3D interativas?**  
Aspose.Slides cria e renderiza efeitos 3D do PowerPoint para formas e texto. Ele não torna imagens, PDFs ou páginas HTML exportadas em cenas 3D interativas que o visualizador possa rotacionar. No PPTX, a formatação 3D permanece editável no PowerPoint quando o formato a suporta.

**Qual a diferença entre um modelo 3D e um efeito 3D?**  
Um modelo 3D é um objeto 3D separado inserido na apresentação. Um efeito 3D é formatação aplicada a uma forma ou texto PowerPoint regular, como rotação, extrusão, chanfrado, iluminação e material. Este artigo cobre efeitos 3D.

**Quais configurações são necessárias para que uma forma 3D seja visível?**  
No mínimo, defina uma rotação de câmera e either extrusão ou profundidade. Na prática, também configure um rig de luz e material para que as faces renderizadas tenham realces e sombras claros.

**Posso aplicar efeitos 3D tanto a formas quanto a texto?**  
Sim. Use [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/) para o corpo da forma e [ITextFrameFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframeformat/) para o texto.

**Os efeitos 3D aparecerão ao exportar para imagens, PDF, HTML ou quadros de vídeo?**  
Sim. Aspose.Slides renderiza efeitos 3D ao gerar imagens de slides, saída PDF, saída HTML e quadros usados para conversão de vídeo. A saída exportada contém a aparência renderizada, não um objeto 3D editável.

**Posso ler os valores 3D finais após a aplicação de herança e configurações de tema?**  
Sim. Use as APIs de formatação efetiva descritas em [Shape Effective Properties](/slides/pt/cpp/shape-effective-properties/) para ler a câmera final, rig de luz, chanfrado e valores 3D relacionados.