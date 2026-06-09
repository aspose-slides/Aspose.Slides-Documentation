---
title: Formatar Formas do PowerPoint em C++
linktitle: Formatação de Formas
type: docs
weight: 20
url: /pt/cpp/shape-formatting/
keywords:
- formatar forma
- formatar linha
- formatar estilo de junção
- preenchimento em degradê
- preenchimento de padrão
- preenchimento com imagem
- preenchimento de textura
- preenchimento de cor sólida
- transparência da forma
- girar forma
- efeito de bisel 3D
- efeito de rotação 3D
- redefinir formatação
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: Aprenda a formatar formas do PowerPoint em C++ usando Aspose.Slides - defina estilos de preenchimento, linha e efeito para arquivos PPT, PPTX e ODP com precisão e controle total.
---
## **Introdução**

No PowerPoint, você pode adicionar formas aos slides. Como as formas são compostas por linhas, pode formatá‑las modificando ou aplicando efeitos aos seus contornos. Além disso, pode formatar formas especificando configurações que controlam como seus interiores são preenchidos.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ fornece interfaces e métodos que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar Linhas**

Usando Aspose.Slides, você pode especificar um estilo de linha personalizado para uma forma. Os passos a seguir descrevem o procedimento:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) ao slide.
1. Defina o [line style](https://reference.aspose.com/slides/pt/cpp/aspose.slides/linestyle/) da forma.
1. Defina a espessura da linha.
1. Defina o [dash style](https://reference.aspose.com/slides/pt/cpp/aspose.slides/linedashstyle/) da linha.
1. Defina a cor da linha para a forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O código a seguir demonstra como formatar um `AutoShape` retângulo:

```cpp
// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>();

// Obter o primeiro slide.
auto slide = presentation->get_Slide(0);

// Adicionar uma autoforma do tipo Retângulo.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Definir a cor de preenchimento para a forma retângulo.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Aplicar formatação às linhas do retângulo.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Definir a cor para a linha do retângulo.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Salvar o arquivo PPTX no disco.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The formatted lines in the presentation](formatted-lines.png)

## **Formatar Estilos de Junção**

Aqui estão as três opções de tipo de junção:

* Round
* Miter
* Bevel

Por padrão, quando o PowerPoint une duas linhas em um ângulo (como no canto de uma forma), ele usa a configuração **Round**. No entanto, se você estiver desenhando uma forma com ângulos agudos, pode preferir a opção **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

O código C++ a seguir demonstra como três retângulos (conforme a imagem acima) foram criados usando as configurações de junção Miter, Bevel e Round:

```cpp
// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>();

// Obter o primeiro slide.
auto slide = presentation->get_Slide(0);

// Adicionar três autoformas do tipo Retângulo.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Definir a cor de preenchimento para cada forma retângulo.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Definir a largura da linha.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Definir a cor para a linha de cada retângulo.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Definir o estilo de junção.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Adicionar texto a cada retângulo.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Salvar o arquivo PPTX no disco.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Preenchimento em Degradê**

No PowerPoint, Preenchimento em Degradê é uma opção de formatação que permite aplicar uma mescla contínua de cores a uma forma. Por exemplo, você pode aplicar duas ou mais cores de forma que uma se desvaneça gradualmente na outra.

Veja como aplicar um preenchimento em degradê a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/) da forma como `Gradient`.
1. Adicione suas duas cores preferidas com posições definidas usando os métodos `Add` da coleção de paradas de degradê exposta pela interface [IGradientFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/igradientformat/).
1. Salve a apresentação modificada como um arquivo PPTX.

O código C++ a seguir demonstra como aplicar um efeito de preenchimento em degradê a uma elipse:

```cpp
// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>();

// Obter o primeiro slide.
auto slide = presentation->get_Slide(0);

// Adicionar uma autoforma do tipo Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Aplicar formatação de degradê à elipse.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Definir a direção do degradê.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Adicionar duas paradas de degradê.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Salvar o arquivo PPTX no disco.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The ellipse with gradient fill](gradient-fill.png)

## **Preenchimento de Padrão**

No PowerPoint, Preenchimento de Padrão é uma opção de formatação que permite aplicar um desenho bicolor — como pontos, listras, cruzes ou quadriculados — a uma forma. Você pode escolher cores personalizadas para o primeiro plano e o plano de fundo do padrão.

Aspose.Slides oferece mais de 45 estilos de padrão predefinidos que podem ser aplicados a formas para melhorar o apelo visual de suas apresentações. Mesmo após selecionar um padrão predefinido, ainda é possível especificar as cores exatas que ele deve usar.

Veja como aplicar um preenchimento de padrão a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/) da forma como `Pattern`.
1. Escolha um estilo de padrão entre as opções predefinidas.
1. Defina a [Background Color](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipatternformat/get_backcolor/) do padrão.
1. Defina a [Foreground Color](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipatternformat/get_forecolor/) do padrão.
1. Salve a apresentação modificada como um arquivo PPTX.

O código C++ a seguir demonstra como aplicar um preenchimento de padrão a um retângulo:

```cpp
// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>();

// Obter o primeiro slide.
auto slide = presentation->get_Slide(0);

// Adicionar uma autoforma do tipo Retângulo.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Definir o tipo de preenchimento como Padrão.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Definir o estilo de padrão.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Definir as cores de fundo e de primeiro plano do padrão.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Salvar o arquivo PPTX no disco.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The rectangle with pattern fill](pattern-fill.png)

## **Preenchimento com Imagem**

No PowerPoint, Preenchimento com Imagem é uma opção de formatação que permite inserir uma imagem dentro de uma forma — usando efetivamente a imagem como plano de fundo da forma.

Veja como usar Aspose.Slides para aplicar um preenchimento com imagem a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/) da forma como `Picture`.
1. Defina o modo de preenchimento da imagem como `Tile` (ou outro modo preferido).
1. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) a partir da imagem que deseja usar.
1. Passe a imagem para o método `ISlidesPicture.set_Image`.
1. Salve a apresentação modificada como um arquivo PPTX.

Suponha que tenhamos um arquivo "lotus.png" com a seguinte imagem:

![The lotus picture](lotus.png)

O código C++ a seguir demonstra como preencher uma forma com a imagem:

```cpp
// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>();

// Obter o primeiro slide.
auto slide = presentation->get_Slide(0);

// Adicionar uma autoforma do tipo Retângulo.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Definir o tipo de preenchimento como Imagem.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Definir o modo de preenchimento da imagem.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Carregar uma imagem e adicioná-la aos recursos da apresentação.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Definir a imagem.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Salvar o arquivo PPTX no disco.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The shape with picture fill](picture-fill.png)

### **Imagem em Ladrilho como Textura**

Se quiser definir uma imagem em ladrilho como textura e personalizar o comportamento do ladrilhamento, pode usar os seguintes métodos da interface [IPictureFillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/) e da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Define o modo de preenchimento da imagem — `Tile` ou `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Especifica o alinhamento dos ladrilhos dentro da forma.
- [set_TileFlip](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Controla se o ladrilho é invertido horizontalmente, verticalmente ou em ambos.
- [set_TileOffsetX](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Define o deslocamento horizontal do ladrilho (em pontos) a partir da origem da forma.
- [set_TileOffsetY](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Define o deslocamento vertical do ladrilho (em pontos) a partir da origem da forma.
- [set_TileScaleX](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Define a escala horizontal do ladrilho em porcentagem.
- [set_TileScaleY](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Define a escala vertical do ladrilho em porcentagem.

O exemplo de código a seguir mostra como adicionar uma forma retângulo com preenchimento de imagem em ladrilho e configurar as opções de ladrilho:

```cpp
// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>();

// Obter o primeiro slide.
auto firstSlide = presentation->get_Slide(0);

// Adicionar uma autoforma do tipo Retângulo.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Definir o tipo de preenchimento da forma como Imagem.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Carregar a imagem e adicioná-la aos recursos da apresentação.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Atribuir a imagem à forma.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Configurar o modo de preenchimento da imagem e as propriedades de ladrilhamento.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Salvar o arquivo PPTX no disco.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The tile options](tile-options.png)

## **Preenchimento com Cor Sólida**

No PowerPoint, Preenchimento com Cor Sólida é uma opção de formatação que preenche uma forma com uma única cor uniforme. Essa cor de fundo simples é aplicada sem degradês, texturas ou padrões.

Para aplicar um preenchimento com cor sólida a uma forma usando Aspose.Slides, siga estes passos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/) da forma como `Solid`.
1. Atribua a cor de preenchimento desejada à forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O código C++ a seguir demonstra como aplicar um preenchimento de cor sólida a um retângulo em um slide PowerPoint:

```cpp
// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>();

// Obter o primeiro slide.
auto slide = presentation->get_Slide(0);

// Adicionar uma autoforma do tipo Retângulo.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Definir o tipo de preenchimento como Sólido.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Definir a cor de preenchimento.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Salvar o arquivo PPTX no disco.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The shape with solid color fill](solid-color-fill.png)

## **Definir Transparência**

No PowerPoint, ao aplicar um preenchimento sólido, em degradê, com imagem ou textura a formas, você também pode definir um nível de transparência para controlar a opacidade do preenchimento. Um valor de transparência mais alto torna a forma mais translúcida, permitindo que o plano de fundo ou objetos subjacentes fiquem parcialmente visíveis.

Aspose.Slides permite definir o nível de transparência ajustando o valor alfa na cor usada para o preenchimento. Veja como fazer isso:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/filltype/) como `Solid`.
1. Use `Color` para definir uma cor com transparência (o componente `alpha` controla a transparência).
1. Salve a apresentação.

O código C++ a seguir demonstra como aplicar uma cor de preenchimento transparente a um retângulo:

```cpp
// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>();

// Obter o primeiro slide.
auto slide = presentation->get_Slide(0);

// Adicionar uma autoforma de retângulo sólido.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Adicionar uma autoforma de retângulo transparente sobre a forma sólida.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Salvar o arquivo PPTX no disco.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The transparent shape](shape-transparency.png)

## **Girar Formas**

Aspose.Slides permite girar formas em apresentações PowerPoint. Isso pode ser útil ao posicionar elementos visuais com alinhamento ou requisitos de design específicos.

Para girar uma forma em um slide, siga estes passos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) ao slide.
1. Defina a propriedade de rotação da forma para o ângulo desejado.
1. Salve a apresentação.

O código C++ a seguir demonstra como girar uma forma em 5 graus:

```cpp
// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>();

// Obter o primeiro slide.
auto slide = presentation->get_Slide(0);

// Adicionar uma autoforma do tipo Retângulo.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Girar a forma em 5 graus.
shape->set_Rotation(5);

// Salvar o arquivo PPTX no disco.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The shape rotation](shape-rotation.png)

## **Adicionar Efeitos de Bisel 3D**

Aspose.Slides permite aplicar efeitos de bisel 3D a formas configurando suas propriedades [ThreeDFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/threedformat/).

Para adicionar efeitos de bisel 3D a uma forma, siga estes passos:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) ao slide.
1. Configure o [ThreeDFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/threedformat/) da forma para definir as configurações de bisel.
1. Salve a apresentação.

O código C++ a seguir mostra como aplicar efeitos de bisel 3D a uma forma:

```cpp
// Criar uma instância da classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Adicionar uma forma ao slide.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Definir as propriedades ThreeDFormat da forma.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Salvar a apresentação como um arquivo PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The 3D bevel effect](3D-bevel-effect.png)

## **Adicionar Efeitos de Rotação 3D**

Aspose.Slides permite aplicar efeitos de rotação 3D a formas configurando suas propriedades [ThreeDFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/threedformat/).

Para aplicar rotação 3D a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) ao slide.
1. Use [set_CameraType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icamera/set_cameratype/) e [set_LightType](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilightrig/set_lighttype/) para definir a rotação 3D.
1. Salve a apresentação.

O código C++ a seguir demonstra como aplicar efeitos de rotação 3D a uma forma:

```cpp
// Criar uma instância da classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Salvar a apresentação como um arquivo PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The 3D rotation effect](3D-rotation-effect.png)

## **Redefinir Formatação**

O código C++ a seguir mostra como redefinir a formatação de um slide e restaurar a posição, tamanho e formatação de todas as formas com marcadores de posição no [LayoutSlide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/layoutslide/) para suas configurações padrão:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Redefinir cada forma no slide que tem um marcador de posição no layout.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**A formatação de formas afeta o tamanho final do arquivo de apresentação?**

Apenas minimamente. Imagens e mídia incorporadas ocupam a maior parte do espaço do arquivo, enquanto parâmetros de forma como cores, efeitos e degradês são armazenados como metadados e praticamente não adicionam tamanho extra.

**Como posso detectar formas em um slide que compartilham a mesma formatação para agrupá‑las?**

Compare as principais propriedades de formatação de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, considere seus estilos como idênticos e agrupe logicamente essas formas, simplificando a gestão de estilos posteriormente.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilização em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um slide‑modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas necessárias e reaplique sua formatação onde for requerido.