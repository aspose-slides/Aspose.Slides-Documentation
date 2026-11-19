---
title: Criar efeitos 3D em apresentações usando C++
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
description: "Aplique e renderize efeitos 3D para formas e texto do PowerPoint em C++ com Aspose.Slides. Configure câmera, iluminação, material, extrusão, preenchimentos e texto 3D."
---
## **Visão geral**

Aspose.Slides for C++ pode criar, editar, preservar e renderizar formatação 3D no estilo PowerPoint para formas e texto. Este artigo cobre efeitos 3D como rotação, extrusão, chanfros, iluminação, material, preenchimentos em gradiente ou imagem, e texto 3D.

{{% alert color="info" title="Note" %}}
Este artigo trata de efeitos de formatação 3D em formas e texto do PowerPoint. Não se trata de inserção ou edição de arquivos de modelo 3D independentes. Quando você exporta um slide para uma imagem, PDF ou HTML, o Aspose.Slides renderiza esses efeitos 3D na saída 2D exportada.
{{% /alert %}}

## **Conceitos de Formatação 3D**

Use o método [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) para aplicar formatação 3D a uma forma. O método retorna [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/), que controla a cena 3D para essa forma.

Para texto, use o método [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/). Isso aplica formatação 3D ao quadro de texto em vez do corpo da forma.

Os métodos mais importantes são:

| Method | What it controls | When to use it |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) | Ponto de vista, tipo de câmera predefinido, rotação, zoom e perspectiva. | Rotacione o objeto no espaço 3D ou corresponda a uma predefinição de rotação 3D do PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_lightrig/) | Predefinição de luz, direção e rotação da luz. | Altere como os realces e sombras aparecem na superfície 3D. |
| [set_Material](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_material/) | Material da superfície, como plano, fosco, plástico ou metal. | Faça a mesma geometria parecer mais plana, suave, brilhante ou metálica. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Quanto a forma se estende para trás a partir de sua face frontal. | Transforme uma forma plana em um objeto 3D visivelmente espesso. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Cor dos lados extrudados. | Torne a profundidade visível ou coordene a cor dos lados com o preenchimento frontal. |
| [set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) | Profundidade 3D adicional usada pela formatação 3D do PowerPoint. | Ajuste fino da profundidade para formas ou texto, especialmente combinado com configurações de chanfro e material. |
| [get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) and [get_BevelBottom](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Bordas elevadas ou arredondadas nas faces frontal e traseira. | Adicione uma borda suavizada ou moldada em vez de uma face plana e afiada. |
| [get_ContourColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_contourcolor/) and [set_ContourWidth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Contorno ao redor do objeto 3D. | Enfatize o contorno do objeto na saída renderizada. |

## **Criar uma Forma 3D**

Uma forma geralmente precisa de quatro tipos de configuração antes de parecer convincentemente 3D:

- Configurações de câmera, pois a visualização frontal padrão pode ocultar a extrusão.
- Configurações de iluminação, pois a luz torna as faces e os lados legíveis.
- Configurações de material, pois a superfície afeta como a luz é renderizada.
- Configurações de extrusão ou profundidade, pois uma forma plana precisa de espessura.

O exemplo a seguir cria um retângulo, adiciona texto à sua face frontal e aplica formatação 3D. Os valores de rotação da câmera estão em graus, e a altura da extrusão é 100 pontos. O exemplo renderiza o slide para uma imagem PNG com o dobro das dimensões padrão e salva a apresentação como PPTX.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
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

No PowerPoint, a rotação 3D é configurada a partir do painel Rotação 3-D. Os valores de rotação X, Y e Z correspondem à rotação definida através da API de câmera.

![Painel de Rotação 3-D do PowerPoint com valores de rotação X, Y e Z destacados](img_02_01.png)

Em Aspose.Slides, acesse a câmera através de [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/). Este exemplo cria um retângulo, seleciona uma visualização frontal ortográfica e define suas rotações X, Y e Z para 20, 30 e 40 graus, respectivamente. Ele configura a forma na memória sem salvar um arquivo:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);

presentation->Dispose();
```

Use a câmera quando precisar alterar como o visualizador vê o objeto. Ela não altera a geometria 2D da forma no slide. Ela altera o ponto de vista 3D usado pelo PowerPoint e pelo Aspose.Slides ao renderizar.

### **Copiar Orientação da Câmera de uma Forma Modelo**

Para corresponder à orientação da câmera de uma forma modelo, leia sua predefinição com [get_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/get_cameratype/) e aplique-a com [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/). O exemplo abre `template.pptx` e copia a orientação da câmera da primeira forma do primeiro slide para a segunda forma. Ambas as formas já possuem iluminação 3D, e a segunda forma não tem rotação de câmera explícita.

[GetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/getrotation/) devolve os ângulos em graus. O índice `0` é latitude, o índice `1` é longitude e o índice `2` é revolução. Passe os ângulos para [SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) nessa ordem. Se a origem não possuir rotação explícita, `GetRotation` retorna um ponteiro nulo, portanto deixe os ângulos da segunda forma não definidos. Uma rotação explícita de `(0, 0, 0)` devolve um array de três zeros e deve ser copiada.

```cpp
#include <DOM/ICamera.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

auto sourceCamera = slide->get_Shape(0)->get_ThreeDFormat()->get_Camera();
auto destinationCamera = slide->get_Shape(1)->get_ThreeDFormat()->get_Camera();

destinationCamera->set_CameraType(sourceCamera->get_CameraType());
auto angles = sourceCamera->GetRotation();
if (angles != nullptr)
{
    destinationCamera->SetRotation(angles[0], angles[1], angles[2]);
}

presentation->Save(u"camera-copy.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Quando você reabre `camera-copy.pptx` no PowerPoint, a seta à direita tem a mesma predefinição de câmera e rotação que o retângulo à esquerda. Ambas as formas usam a mesma iluminação e profundidade de extrusão.

![Um retângulo 3D azul e uma seta para a direita com orientação de câmera correspondente, vistos de cima e à direita](camera-orientation.png)

## **Adicionar Extrusão e Profundidade**

A extrusão faz uma forma parecer espessa estendendo-a por trás da face frontal. No PowerPoint, o controle de profundidade define essa espessura visível, e o controle de cor define a cor das faces laterais.

![Controles de profundidade do PowerPoint mapeados para as propriedades de cor da extrusão e altura da extrusão](img_02_02.png)

Defina [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) para a espessura e [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) para a cor dos lados. Este exemplo dá a um retângulo uma extrusão de 100 pontos com lados roxos e rotaciona a câmera para revelar sua espessura. Ele configura a forma na memória sem salvar um arquivo:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

O método [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) define a profundidade de uma forma 3D. O método [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) controla a altura do efeito de extrusão, como mostrado neste exemplo.

## **Usar Preenchimentos em Gradiente ou Imagem com Efeitos 3D**

A formatação 3D é independente do preenchimento da forma. Você pode aplicar uma cor sólida, gradiente, padrão ou preenchimento de imagem à face frontal e ainda usar as mesmas configurações de câmera, luz, material e extrusão.

Este exemplo aplica um gradiente de azul para laranja na face frontal e uma cor laranja escura à extrusão de 150 pontos. As paradas do gradiente em 0 e 100 marcam o início e o fim do gradiente. Os valores de rotação da câmera estão em graus. O slide é renderizado para uma imagem PNG com o dobro das dimensões padrão:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
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

Para usar um preenchimento de imagem, adicione a imagem à apresentação e atribua-a ao preenchimento da forma. Este exemplo requer um arquivo existente chamado "image.jpg" no diretório de trabalho. Ele estica a imagem para preencher o retângulo, aplica uma extrusão de 150 pontos e define a rotação da câmera em graus. Ele configura a forma na memória sem salvar ou renderizar um arquivo:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

A imagem é renderizada na face frontal, enquanto a extrusão é renderizada como a superfície lateral 3D:

![Retângulo 3D renderizado com preenchimento fotográfico na face frontal e extrusão laranja](img_02_04.png)

## **Aplicar Formatação 3D ao Texto**

A formatação 3D da forma afeta o corpo da forma. A formatação 3D do texto afeta o quadro de texto. Isso é útil para efeitos semelhantes ao WordArt, onde as próprias letras precisam de extrusão, material, iluminação e configurações de câmera.

O exemplo a seguir cria texto com um padrão de grade laranja e branco, aplica um arco ascendente e configura as definições 3D através de [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/). A altura e profundidade da extrusão estão em pontos, e a rotação da luz está em graus. O preenchimento e contorno da forma estão ocultos para que apenas o texto seja visível. O exemplo renderiza uma imagem PNG com o dobro das dimensões padrão do slide e salva a apresentação como PPTX:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
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

![Texto 3D renderizado com transformação arqueada de WordArt, preenchimento de padrão laranja e extrusão escura](img_02_05.png)

## **Manter Texto Plano em uma Forma 3D**

Para manter o texto legível enquanto preserva a aparência 3D de uma forma, chame [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_keeptextflat/) através de [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_textframeformat/). Quando o valor é `true`, o texto permanece fora da cena 3D. Quando é `false`, o texto participa da cena e segue sua orientação 3D.

Essa configuração não remove a formatação 3D da forma: sua câmera, iluminação, material e extrusão permanecem configurados através de [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/). Também é diferente da rotação comum. [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) rotaciona a forma no plano do slide, enquanto [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) controla a rotação personalizada do texto dentro de sua caixa delimitadora. Manter o texto fora da cena 3D não redefine nenhum desses ângulos.

O exemplo autônomo a seguir cria um retângulo azul com texto e o duplica ao lado do original. Ambas as formas têm a mesma formatação 3D; apenas a configuração de texto difere: `false` à esquerda e `true` à direita. Os ângulos da câmera estão em graus, e a altura da extrusão é 40 pontos. O exemplo salva a apresentação como PPTX e renderiza o slide de comparação para PNG com o dobro das dimensões padrão.

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

À esquerda, o texto segue a orientação 3D. À direita, ele permanece plano e mais fácil de ler. Ambos os retângulos mantêm a mesma extrusão visível e orientação 3D.

![Retângulos 3D lado a lado: KeepTextFlat é false à esquerda e true à direita](keep_text_flat.png)

## **Comportamento de Exportação e Renderização**

O Aspose.Slides preserva a formatação 3D ao salvar em formatos PowerPoint como PPTX. Ao renderizar ou exportar para formatos de layout fixo, a cena 3D é rasterizada ou desenhada na saída como um resultado 2D. Isso se aplica quando você renderiza slides para [PNG](/slides/pt/cpp/convert-powerpoint-to-png/), exporta para [PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/), exporta para [HTML](/slides/pt/cpp/convert-powerpoint-to-html/), ou gera quadros para [video conversion](/slides/pt/cpp/convert-powerpoint-to-video/).

- Imagens e PDFs exportados não são interativos. O objeto não pode ser rotacionado pelo visualizador após a exportação.
- A aparência final depende da combinação de câmera, conjunto de luzes, material, extrusão, preenchimento e dimensionamento do slide.
- Se precisar inspecionar valores de formatação herdados ou baseados em tema, leia as [effective shape properties](/slides/pt/cpp/shape-effective-properties/).
- Alguns formatos de saída não podem armazenar a formatação 3D editável do PowerPoint. Nesses formatos, o resultado visual é renderizado em vez de preservado como configurações 3D editáveis.

## **FAQ**

**O Aspose.Slides pode criar apresentações 3D interativas?**

O Aspose.Slides cria e renderiza efeitos 3D do PowerPoint para formas e texto. Ele não torna imagens, PDFs ou páginas HTML exportadas cenas 3D interativas que o visualizador possa girar. No PPTX, a formatação 3D permanece editável no PowerPoint onde o formato a suporta.

**Qual é a diferença entre um modelo 3D e um efeito 3D?**

Um modelo 3D é um objeto 3D separado inserido em uma apresentação. Um efeito 3D é formatação aplicada a uma forma ou texto padrão do PowerPoint, como rotação, extrusão, chanfro, iluminação e material. Este artigo cobre efeitos 3D.

**Quais configurações são necessárias para uma forma 3D visível?**

Como mínimo, defina uma rotação de câmera e extrusão ou profundidade. Na prática, também configure um conjunto de luzes e material para que as faces renderizadas tenham realces e sombras claros.

**Posso aplicar efeitos 3D tanto a formas quanto a texto?**

Sim. Use [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) para o corpo da forma e [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) para o texto.

**Os efeitos 3D aparecerão ao exportar para imagens, PDF, HTML ou quadros de vídeo?**

Sim. O Aspose.Slides renderiza efeitos 3D ao produzir imagens de slides, saída PDF, saída HTML e quadros usados para conversão de vídeo. A saída exportada contém a aparência renderizada, não um objeto 3D editável.

**Posso ler os valores finais de 3D após a aplicação de herança e configurações de tema?**

Sim. Use as APIs de formatação efetiva descritas em [Shape Effective Properties](/slides/pt/cpp/shape-effective-properties/) para ler a câmera final, conjunto de luzes, chanfro e valores 3D relacionados.