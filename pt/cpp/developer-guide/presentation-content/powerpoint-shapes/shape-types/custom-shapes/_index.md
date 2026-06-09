---
title: Personalizar Formas de Apresentação em C++
linktitle: Forma Personalizada
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
- pontos de edição
- adicionar ponto
- remover ponto
- operação de edição
- canto curvo
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Crie e personalize formas em apresentações PowerPoint com Aspose.Slides para C++: caminhos de geometria, cantos curvos, formas compostas."
---
## **Visão geral**

Este artigo explica como personalizar formas de apresentação no Aspose.Slides editando a geometria da forma por meio de pontos de edição e caminhos de geometria. Ele demonstra como trabalhar com `GeometryPath` e `IGeometryPath` para modificar formas existentes, executar operações básicas de edição de caminho, adicionar ou remover pontos e aplicar a geometria atualizada de volta a uma forma.

## **Alterar uma Forma Usando Pontos de Edição**
Considere um quadrado. No PowerPoint, usando **pontos de edição**, você pode

* mover o canto do quadrado para dentro ou para fora
* especificar a curvatura de um canto ou ponto
* adicionar novos pontos ao quadrado
* manipular pontos no quadrado, etc.

Basicamente, você pode executar as tarefas descritas em qualquer forma. Usando pontos de edição, você pode alterar uma forma ou criar uma nova forma a partir de uma forma existente.

## **Dicas para Edição de Formas**

![imagem_visão_geral](custom_shape_0.png)

Antes de começar a editar formas do PowerPoint por meio de pontos de edição, considere os seguintes aspectos sobre formas:

* Uma forma (ou seu caminho) pode ser fechada ou aberta.
* Quando uma forma está fechada, não possui ponto inicial ou final. Quando uma forma está aberta, tem um início e um fim. 
* Todas as formas consistem em, no mínimo, 2 pontos de ancoragem ligados entre si por linhas.
* Uma linha pode ser reta ou curva. Os pontos de ancoragem determinam a natureza da linha. 
* Pontos de ancoragem podem ser pontos de canto, pontos retos ou pontos suaves:
  * Um ponto de canto é um ponto onde 2 linhas retas se unem em um ângulo. 
  * Um ponto suave é um ponto onde 2 alças existem em uma linha reta e os segmentos da linha se juntam em uma curva suave. Nesse caso, todas as alças ficam separadas do ponto de ancoragem por uma distância igual. 
  * Um ponto reto é um ponto onde 2 alças existem em uma linha reta e os segmentos da linha se juntam em uma curva suave. Nesse caso, as alças não precisam estar separadas do ponto de ancoragem por uma distância igual. 
* Ao mover ou editar pontos de ancoragem (o que altera o ângulo das linhas), você pode mudar a aparência de uma forma.

Para editar formas do PowerPoint por meio de pontos de edição, **Aspose.Slides** fornece a classe [**GeometryPath**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.geometry_path) e a interface [**IGeometryPath**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_geometry_path).

* Uma instância de [GeometryPath](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.geometry_path) representa o caminho de geometria do objeto [IGeometryShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_geometry_shape). 
* Para obter o `GeometryPath` a partir da instância `IGeometryShape`, você pode usar o método [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1). 
* Para definir o `GeometryPath` de uma forma, você pode usar estes métodos: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) para *formas sólidas* e [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) para *formas compostas*.
* Para adicionar segmentos, você pode usar os métodos da interface [IGeometryPath](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_geometry_path). 
* Usando os métodos [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) e [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7), você pode definir a aparência de um caminho de geometria.
* Usando o método [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca), você pode recuperar o caminho de geometria de um `GeometryShape` como um array de segmentos de caminho. 
* Para acessar opções adicionais de personalização da geometria da forma, você pode converter [GeometryPath](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.geometry_path) para [GraphicsPath](https://reference.aspose.com/slides/pt/cpp/class/system.drawing.drawing2_d.graphics_path).
* Use os métodos [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) e [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (da classe [ShapeUtil](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.util.shape_util)) para converter [GeometryPath](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.geometry_path) em [GraphicsPath](https://reference.aspose.com/slides/pt/cpp/class/system.drawing.drawing2_d.graphics_path) e vice‑versa. 

## **Operações Simples de Edição**

Este código C++ mostra como

**Adicionar uma linha** ao final de um caminho

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Adicionar uma linha** em uma posição especificada no caminho:

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**Adicionar uma curva cúbica de Bézier** ao final de um caminho:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Adicionar uma curva cúbica de Bézier** na posição especificada do caminho:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**Adicionar uma curva quadrática de Bézier** ao final de um caminho:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Adicionar uma curva quadrática de Bézier** a uma posição especificada no caminho:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**Anexar um arco** ao caminho:

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Fechar a figura atual** de um caminho:

``` cpp
void CloseFigure();
```
**Definir a posição do próximo ponto**:

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Remover o segmento de caminho** em um índice determinado:

``` cpp
void RemoveAt(int32_t index);
```

## **Adicionar Pontos Personalizados a uma Forma**
1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.geometry_shape) e defina o tipo [ShapeType.Rectangle](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. Obtenha uma instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.geometry_path) a partir da forma.  
3. Adicione um novo ponto entre os dois pontos superiores do caminho.  
4. Adicione um novo ponto entre os dois pontos inferiores do caminho.  
5. Aplique o caminho à forma.

Este código C++ mostra como adicionar pontos personalizados a uma forma:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath = shape->GetGeometryPaths()->idx_get(0);

geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);
shape->SetGeometryPath(geometryPath);
```

![exemplo1_imagem](custom_shape_1.png)

## **Remover Pontos de uma Forma**

1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.geometry_shape) e defina o tipo [ShapeType.Heart](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).  
2. Obtenha uma instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.geometry_path) a partir da forma.  
3. Remova o segmento do caminho.  
4. Aplique o caminho à forma.

Este código C++ mostra como remover pontos de uma forma:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```

![exemplo2_imagem](custom_shape_2.png)

## **Criar uma Forma Personalizada**

1. Calcule os pontos da forma.  
2. Crie uma instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.geometry_path).  
3. Preencha o caminho com os pontos.  
4. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.geometry_shape).  
5. Aplique o caminho à forma.

Este código C++ mostra como criar uma forma personalizada:

``` cpp
SharedPtr<List<PointF>> points = System::MakeObject<List<PointF>>();

float R = 100.0f, r = 50.0f;
int32_t step = 72;

for (int32_t angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math::PI / 180.f);
    double x = outerRadius * Math::Cos(radians);
    double y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + step / 2) / 180.0;
    x = innerRadiusr * Math::Cos(radians);
    y = innerRadiusr * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

SharedPtr<GeometryPath> starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (int32_t i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, R * 2, R * 2));

shape->SetGeometryPath(starPath);
```

![exemplo3_imagem](custom_shape_3.png)


## **Criar uma Forma Personalizada Composta**

1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.geometry_shape).  
2. Crie a primeira instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.geometry_path).  
3. Crie a segunda instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.geometry_path).  
4. Aplique os caminhos à forma.

Este código C++ mostra como criar uma forma personalizada composta:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath0 = System::MakeObject<GeometryPath>();
geometryPath0->MoveTo(0.0f, 0.0f);
geometryPath0->LineTo(shape->get_Width(), 0.0f);
geometryPath0->LineTo(shape->get_Width(), shape->get_Height() / 3);
geometryPath0->LineTo(0.0f, shape->get_Height() / 3);
geometryPath0->CloseFigure();

SharedPtr<IGeometryPath> geometryPath1 = System::MakeObject<GeometryPath>();
geometryPath1->MoveTo(0.0f, shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height());
geometryPath1->LineTo(0.0f, shape->get_Height());
geometryPath1->CloseFigure();

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ geometryPath0, geometryPath1 }));
```

![exemplo4_imagem](custom_shape_4.png)

## **Criar uma Forma Personalizada com Cantos Curvos**

Este código C++ mostra como criar uma forma personalizada com cantos curvos (inward):

```cpp
float shapeX = 20.f;
float shapeY = 20.f;
float shapeWidth = 300.f;
float shapeHeight = 200.f;

float leftTopSize = 50.f;
float rightTopSize = 20.f;
float rightBottomSize = 40.f;
float leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();

auto childShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto geometryPath = System::MakeObject<GeometryPath>();

PointF point1(leftTopSize, 0.0f);
PointF point2(shapeWidth - rightTopSize, 0.0f);
PointF point3(shapeWidth, shapeHeight - rightBottomSize);
PointF point4(leftBottomSize, shapeHeight);
PointF point5(0.0f, leftTopSize);

geometryPath->MoveTo(point1);
geometryPath->LineTo(point2);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(point3);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(point4);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(point5);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);

geometryPath->CloseFigure();

childShape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Descobrir Se a Geometria de uma Forma Está Fechada**

Uma forma fechada é definida como aquela em que todos os lados se conectam, formando um único contorno sem lacunas. Essa forma pode ser um simples contorno geométrico ou um delineamento personalizado complexo. O exemplo de código a seguir demonstra como verificar se a geometria de uma forma está fechada:

```cpp
bool IsGeometryClosed(SharedPtr<IGeometryShape> geometryShape)
{
    bool isClosed = false;

    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto dataLength = geometryPath->get_PathData()->get_Length();
        if (dataLength == 0)
            continue;

        auto lastSegment = geometryPath->get_PathData()[dataLength - 1];
        isClosed = lastSegment->get_PathCommand() == PathCommandType::Close;

        if (!isClosed)
            return false;
    }

    return isClosed;
}
```

## **Converter GeometryPath para GraphicsPath** 

1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.geometry_shape).  
2. Crie uma instância da classe [GraphicsPath](https://reference.aspose.com/slides/pt/cpp/class/system.drawing.drawing2_d.graphics_path) do namespace [System.Drawing.Drawing2D](https://reference.aspose.com/slides/pt/cpp/namespace/system.drawing.drawing2_d).  
3. Converta a instância de [GraphicsPath](https://reference.aspose.com/slides/pt/cpp/class/system.drawing.drawing2_d.graphics_path) para a instância de [GeometryPath](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.geometry_path) usando a classe [ShapeUtil](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.util.shape_util).  
4. Aplique os caminhos à forma.

Este código C++ — implementação dos passos acima — demonstra o processo de conversão de **GeometryPath** para **GraphicsPath**:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"Text in shape", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```

![exemplo5_imagem](custom_shape_5.png)

## **FAQ**

**O que acontecerá com o preenchimento e o contorno após substituir a geometria?**

O estilo permanece associado à forma; somente o contorno muda. O preenchimento e o contorno são aplicados automaticamente à nova geometria.

**Como girar corretamente uma forma personalizada junto com sua geometria?**

Use a propriedade [rotation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/set_rotation/) da forma; a geometria gira com a forma porque está vinculada ao próprio sistema de coordenadas da forma.

**Posso converter uma forma personalizada em uma imagem para “travar” o resultado?**

Sim. Exporte a área do [slide](/slides/pt/cpp/convert-powerpoint-to-png/) necessária ou o próprio [shape](/slides/pt/cpp/create-shape-thumbnails/) para um formato raster; isso simplifica o trabalho posterior com geometrias pesadas.