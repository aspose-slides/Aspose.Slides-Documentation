---
title: Personalizar formas de apresentação em C++
linktitle: Forma personalizada
type: docs
weight: 20
url: /pt/cpp/custom-shape/
keywords:
- forma personalizada
- adicionar forma
- criar forma
- alterar forma
- geometria da forma
- caminho de geometria
- pontos do caminho
- editar pontos
- adicionar ponto
- remover ponto
- operação de edição
- canto curvo
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Criar e personalizar formas em apresentações PowerPoint com Aspose.Slides para C++: caminhos de geometria, cantos curvos, formas compostas."
---
## **Visão geral**

Este artigo explica como personalizar formas de apresentação no Aspose.Slides editando a geometria da forma por meio de pontos de edição e caminhos de geometria. Ele mostra como trabalhar com [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) e [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) para modificar formas existentes, executar operações básicas de edição de caminho, adicionar ou remover pontos e aplicar a geometria atualizada de volta a uma forma.

Ele também demonstra como criar formas personalizadas e compostas, construir formas com cantos curvos e determinar se a geometria de uma forma está fechada.

## **Alterar uma forma usando pontos de edição**

No PowerPoint, você pode usar **Pontos de edição** para modificar um quadrado:

* Mover um canto para dentro ou para fora.
* Ajustar a curvatura em um ponto.
* Adicionar novos pontos.

Editar pontos permite modificar o contorno de uma forma ou usar uma forma existente como base para uma nova.

## **Dicas de edição de forma**

![imagem_visão_geral](custom_shape_0.png)

Ao editar formas do PowerPoint, mantenha estes conceitos em mente:

* Uma forma (ou seu caminho) pode ser fechada ou aberta.
* O caminho de uma forma consiste em pontos de ancoragem conectados por segmentos.
* Um segmento pode ser reto ou curvo. Pontos de ancoragem e alças de controle determinam sua forma.
* Pontos de ancoragem existem como pontos de canto, pontos retos ou pontos suaves:
  * Em um ponto de canto, os segmentos adjacentes podem se encontrar em um ângulo.
  * Em um ponto suave, as duas alças de controle estão alinhadas e equidistantes do ponto de ancoragem.
  * Em um ponto reto, as duas alças de controle estão alinhadas, mas podem ter distâncias diferentes do ponto de ancoragem.
* Mover pontos de ancoragem ou ajustar suas alças altera o contorno da forma.

Para editar formas do PowerPoint por meio de pontos de edição, **Aspose.Slides** fornece a classe [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) e a interface [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Uma [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) representa um caminho de geometria do objeto [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* Para obter o [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) a partir da instância [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/), você pode usar o método [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* Para definir o [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) para uma forma, você pode usar estes métodos: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) para formas com um único caminho e [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) para formas com múltiplos caminhos.
* Para adicionar segmentos, você pode usar os métodos em [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* Usando os métodos [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) e [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/), você pode definir a aparência de um caminho de geometria.
* Usando o método [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/), você pode obter o caminho de geometria de um [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) como um array de segmentos de caminho.

## **Operações simples de edição**

Use os seguintes métodos para editar um caminho de geometria. Sobrecargas que aceitam um índice inserem um segmento naquela posição baseada em zero no array de segmentos do caminho.

| Operação | Método |
| --- | --- |
| Adicionar ou inserir uma linha reta. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Adicionar ou inserir uma curva Bézier cúbica com dois pontos de controle e um ponto final. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Adicionar ou inserir uma curva Bézier quadrática com um ponto de controle e um ponto final. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Adicionar um arco elíptico com as dimensões e ângulos especificados em graus. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Fechar a figura atual conectando seu ponto final ao ponto inicial. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Definir o ponto inicial de uma figura. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Remover um segmento em um índice baseado em zero. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Adicionar pontos personalizados a uma forma**

Este exemplo insere dois pontos em uma forma retangular usando [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) e aplica o caminho editado com [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). As coordenadas são locais à forma: ambos os novos pontos ficam em seu centro, 100 pontos da esquerda e 50 pontos do topo. Os índices de segmento 1 e 4 os posicionam nas bordas superior e inferior, puxando essas bordas para dentro.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto geometryPath = shape->GetGeometryPaths()->idx_get(0);
geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);

shape->SetGeometryPath(geometryPath);
```

![imagem_exemplo1](custom_shape_1.png)

## **Remover pontos de uma forma**

Este exemplo altera o contorno de uma forma em forma de coração removendo o segmento no índice baseado em zero 2 com [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Aplicar o caminho modificado com [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) atualiza o contorno da forma.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f);

auto path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);

shape->SetGeometryPath(path);
```
![imagem_exemplo2](custom_shape_2.png)

## **Criar uma forma personalizada**

Este exemplo constrói uma estrela de cinco pontas com [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Raios externos e internos alternados de 100 e 50 pontos definem as pontas e as entalhes; um passo de 72 graus espaça as cinco pontas uniformemente. O caminho é fechado com [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) e aplicado a uma forma retangular usando [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), substituindo seu contorno.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/math.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto points = System::MakeObject<List<PointF>>();

auto outerRadius = 100.0f;
auto innerRadius = 50.0f;
auto angleStep = 72;

for (auto angle = -90; angle < 270; angle += angleStep)
{
    auto radians = angle * (Math::PI / 180.f);
    auto x = outerRadius * Math::Cos(radians);
    auto y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math::Cos(radians);
    y = innerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

auto starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (auto i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, outerRadius * 2, outerRadius * 2);
shape->SetGeometryPath(starPath);
```
![imagem_exemplo3](custom_shape_3.png)

## **Criar uma forma personalizada composta**

Este exemplo define dois [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) fechados para o terço superior e inferior de uma forma. Aplicar ambos os caminhos com [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) cria uma única forma composta com uma lacuna no terço central.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto topPath = System::MakeObject<GeometryPath>();
topPath->MoveTo(0.0f, 0.0f);
topPath->LineTo(shape->get_Width(), 0.0f);
topPath->LineTo(shape->get_Width(), shape->get_Height() / 3);
topPath->LineTo(0.0f, shape->get_Height() / 3);
topPath->CloseFigure();

auto bottomPath = System::MakeObject<GeometryPath>();
bottomPath->MoveTo(0.0f, shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```
![imagem_exemplo4](custom_shape_4.png)

## **Criar uma forma personalizada com cantos curvos**

Este exemplo combina segmentos retos com [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) para criar uma forma com cantos curvados para dentro. Cada tamanho de canto define a largura e altura do arco em pontos, e o arco de -90 graus desenha um quarto de elipse no sentido anti‑horário. O caminho concluído é aplicado com [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), e a apresentação é salva no formato PPTX.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto shapeX = 20.f;
auto shapeY = 20.f;
auto shapeWidth = 300.f;
auto shapeHeight = 200.f;

auto leftTopSize = 50.f;
auto rightTopSize = 20.f;
auto rightBottomSize = 40.f;
auto leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto topLeft = PointF(leftTopSize, 0.0f);
auto topRight = PointF(shapeWidth - rightTopSize, 0.0f);
auto rightBottom = PointF(shapeWidth, shapeHeight - rightBottomSize);
auto bottomLeft = PointF(leftBottomSize, shapeHeight);
auto leftTop = PointF(0.0f, leftTopSize);

auto geometryPath = System::MakeObject<GeometryPath>();
geometryPath->MoveTo(topLeft);
geometryPath->LineTo(topRight);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(rightBottom);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(bottomLeft);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(leftTop);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);
geometryPath->CloseFigure();

shape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Descobrir se a geometria de uma forma está fechada**

O helper a seguir verifica se todo caminho de geometria não vazio termina com um segmento de fechamento. Ele lê [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) e compara o [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) final com [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Retorna falso quando não há caminhos não vazios. Essa verificação olha apenas o comando final de cada caminho; não inspeciona cada sub‑figura dentro de um caminho. O exemplo imprime `True` para um retângulo.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IPathSegment.h>
#include <DOM/PathCommandType.h>

using namespace Aspose::Slides;
using namespace System;

auto isGeometryClosed = [](SharedPtr<IGeometryShape> geometryShape)
{
    auto hasNonemptyPath = false;
    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto segments = geometryPath->get_PathData();
        if (segments->get_Length() == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        auto lastSegment = segments->idx_get(segments->get_Length() - 1);
        if (lastSegment->get_PathCommand() != PathCommandType::Close)
        {
            return false;
        }
    }
    return hasNonemptyPath;
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
Console::WriteLine(isGeometryClosed(shape));
```

## **Inspecionar comandos de caminho de geometria**

Baixe [contour.pptx](contour.pptx) e coloque‑o no diretório de trabalho da aplicação. A primeira forma no primeiro slide tem uma borda superior reta, uma curva Bézier cúbica e uma borda de fechamento reta. Use [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) para ler seus caminhos. Para cada caminho, [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) devolve os segmentos na ordem de desenho. O comando devolvido por [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) determina como interpretar os valores devolvidos por [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/).

```cpp
#include <DOM/IGeometryPath.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IPathSegment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/PathCommandType.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"contour.pptx");

auto shape = ExplicitCast<IGeometryShape>(presentation->get_Slide(0)->get_Shape(0));
auto paths = shape->GetGeometryPaths();

for (auto i = 0; i < paths->get_Length(); ++i)
{
    auto segments = paths->idx_get(i)->get_PathData();
    for (auto j = 0; j < segments->get_Length(); ++j)
    {
        auto segment = segments->idx_get(j);
        auto command = segment->get_PathCommand();
        auto data = segment->get_SegmentData();
        String detail;
        switch (command)
        {
            case PathCommandType::MoveTo:
            case PathCommandType::LineTo:
                detail = String::Format(u"destination=({0}, {1})", data->idx_get(0), data->idx_get(1));
                break;
            case PathCommandType::CubicBezierTo:
                detail = String::Format(u"control1=({0}, {1}) control2=({2}, {3}) end=({4}, {5})", data);
                break;
            case PathCommandType::Close:
                detail = u"no coordinates";
                break;
            default:
            {
                auto values = MakeArray<String>(data->get_Length());
                for (auto k = 0; k < data->get_Length(); ++k)
                {
                    values->idx_set(k, String::Format(u"{0}", data->idx_get(k)));
                }
                detail = String::Format(u"raw=[{0}]", String::Join(u", ", values));
                break;
            }
        }
        Console::WriteLine(u"Path {0}, segment {1}: {2} {3}", i, j, Enum<PathCommandType>::GetName(command), detail);
    }
}
```

A forma está em (200, 100) pontos no slide. Os pontos relatados são locais à forma, com (0, 0) no canto superior esquerdo, x aumentando para a direita e y aumentando para baixo. O segmento de fechamento retorna ao ponto inicial sem coordenadas adicionais.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![Forma do PowerPoint com uma borda superior reta, uma borda curva do canto superior direito ao inferior esquerdo e uma borda esquerda reta](contour.png)

## **Extrair e inspecionar elementos de forma**

Use [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) para inspecionar uma forma existente como elementos contendo pontos de caminho e tipos de ponto. Converta cada [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) retornado para [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) para ler os arrays devolvidos por [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) e [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). Essa representação é útil para análise de contorno ou passagem de geometria para ferramentas de desenho personalizadas.

O exemplo abre uma apresentação, encontra a primeira forma de geometria diretamente no primeiro slide e imprime seus segmentos de caminho. Use uma apresentação contendo uma forma com segmentos retos e curvos para ver ambos os tipos de saída. Não procura dentro de grupos.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IShapeElement.h>
#include <DOM/ShapeElement.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IGeometryShape> shape;
for (auto&& candidate : slide->get_Shapes())
{
    shape = AsCast<IGeometryShape>(candidate);
    if (shape != nullptr)
    {
        break;
    }
}
if (shape == nullptr)
{
    Console::WriteLine(u"No geometry shape found on the first slide.");
    return;
}

for (auto&& element : shape->CreateShapeElements())
{
    auto shapeElement = ExplicitCast<ShapeElement>(element);
    auto points = shapeElement->get_PathPoints();
    auto types = shapeElement->get_PathTypes();
    Console::WriteLine(u"Shape element:");

    for (auto i = 0; i < points->get_Length(); i++)
    {
        auto pointType = types[i] & 0x07; // Mantenha o tipo de segmento, excluindo flags.
        switch (pointType)
        {
            case 0:
                Console::WriteLine(u"Start figure at {0}", points[i]);
                break;
            case 1:
                Console::WriteLine(u"Line to {0}", points[i]);
                break;
            case 3:
                Console::WriteLine(u"Cubic Bezier: controls {0}, {1}; end {2}", points[i], points[i + 1], points[i + 2]);
                i += 2; // Consuma ambos os pontos de controle e o ponto final.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

Os arrays correspondem por índice: `points[i]` é um ponto e `types[i]` descreve seu papel. Tipo `0` inicia uma figura, e tipo `1` desenha uma linha do ponto anterior ao ponto atual. Um segmento Bézier cúbico inicia no ponto final anterior e usa três entradas consecutivas de tipo `3`: dois pontos de controle seguidos do novo ponto final. O laço consome essas três entradas juntas e verifica o ponto final para fechamento.

Tipos de ponto também contêm bandeiras. Use a máscara `0x07` para identificar o tipo de segmento e teste `0x80` separadamente para detectar um subcaminho fechado. Por exemplo, `129` (`0x81`) significa um ponto final de linha que fecha um subcaminho, e `131` (`0x83`) significa um ponto final Bézier que fecha um. Comparar o valor bruto apenas com `1` ou `3` perderia esses casos. Outras bandeiras, como traço (`0x10`) e marcador (`0x20`), não alteram o tipo básico do segmento.

**Coordenadas e transformações.** Os pontos são medidos em pontos (1/72 polegada), com X aumentando para a direita e Y aumentando para baixo. Para uma forma não agrupada, as coordenadas extraídas já incluem a posição devolvida por [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) e [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) e refletem sua largura e altura atuais. Por exemplo, um retângulo não rotacionado em `(100, 200)` com tamanho `120 × 80` tem limites de contorno `(100, 200)`–`(220, 280)`. Não adicione novamente a posição da forma. Subtraia seu X e Y para obter coordenadas relativas ao seu quadro não rotacionado.

Os pontos extraídos não aplicam a rotação definida por [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) nem inversões horizontais e verticais. Para reproduzir o contorno exibido, aplique essas transformações ao redor do centro da forma. Para formas agrupadas, também considere o mapeamento de coordenadas do grupo e as transformações; não presuma que os pontos extraídos são as coordenadas finais renderizadas no slide nem aplique a mesma translação ou escala duas vezes se já estiver refletida na moldura do filho.

**Inspeção versus edição.** Os arrays extraídos descrevem o contorno; alterá‑los não atualiza a forma original. Use essa abordagem quando sua análise ou código de desenho precisar de arrays de ponto/tipo. Use [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) quando precisar de comandos de geometria no sistema de coordenadas local da forma ou quiser editar sua geometria. Aplique caminhos editados através de [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) ou [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **Converter GeometryPath para GraphicsPath**

A API pública atual do Aspose.Slides para C++ não expõe conversões entre caminhos de geometria e caminhos gráficos. Para inspecionar um contorno, use elementos de forma como descrito acima. Para editar uma forma, use caminhos de geometria e aplique os caminhos atualizados à forma.

## **Perguntas frequentes**

**O que acontecerá com o preenchimento e o contorno depois de substituir a geometria?**

O estilo permanece na forma; apenas o contorno muda. O preenchimento e o contorno são aplicados automaticamente à nova geometria.

**Como girar corretamente uma forma personalizada juntamente com sua geometria?**

Use o método da forma [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/); a geometria gira com a forma porque está vinculada ao próprio sistema de coordenadas da forma.

**Posso converter uma forma personalizada em uma imagem para “travar” o resultado?**

Sim. Exporte a área do [slide](/slides/pt/cpp/convert-powerpoint-to-png/) ou a própria [forma](/slides/pt/cpp/shape-thumbnails/) para um formato raster; isso simplifica o trabalho posterior com geometrias complexas.