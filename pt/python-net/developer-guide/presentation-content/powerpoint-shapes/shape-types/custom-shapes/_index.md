---
title: Personalizar formas em apresentações com Python
linktitle: Forma personalizada
type: docs
weight: 20
url: /pt/python-net/custom-shape/
keywords:
- forma personalizada
- adicionar forma
- criar forma
- alterar forma
- geometria da forma
- caminho geométrico
- pontos do caminho
- editar pontos
- adicionar ponto
- remover ponto
- operação de edição
- canto curvo
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Crie e personalize formas em apresentações PowerPoint e OpenDocument com Aspose.Slides para Python via .NET: caminhos geométricos, cantos curvos, formas compostas."
---
## **Introdução**

Considere um quadrado. No PowerPoint, usando **Edit Points**, você pode:

* mover o canto de um quadrado para dentro ou para fora,
* ajustar a curvatura de um canto ou ponto,
* adicionar novos pontos ao quadrado,
* manipular seus pontos.

Você pode aplicar essas operações a qualquer forma. Com **Edit Points**, você pode modificar uma forma ou criar uma nova a partir de uma forma existente.

## **Dicas de Edição de Formas**

!["Edit Points" comando](custom_shape_0.png)

Antes de começar a editar formas do PowerPoint usando **Edit Points**, considere estas observações sobre formas:

* Uma forma (ou seu caminho) pode ser **fechada** ou **aberta**.
* Uma forma fechada não tem ponto de início ou fim; uma forma aberta tem um começo e um fim.
* Toda forma tem pelo menos dois pontos âncora conectados por segmentos de linha.
* Um segmento pode ser reto ou curvo; os pontos âncora determinam a natureza do segmento.
* Os pontos âncora podem ser **canto**, **suave**, ou **reto**:
  * Um ponto **canto** é onde dois segmentos retos se encontram em um ângulo.
  * Um ponto **suave** tem duas alças que são colineares, e os segmentos adjacentes formam uma curva suave. Nesse caso, ambas as alças têm a mesma distância do ponto âncora.
  * Um ponto **reto** também tem duas alças colineares, e os segmentos adjacentes formam uma curva suave. Nesse caso, as alças não precisam ter a mesma distância do ponto âncora.
* Ao mover ou editar pontos âncora (alterando assim os ângulos dos segmentos), você pode mudar a aparência da forma.

Para editar formas do PowerPoint, o Aspose.Slides fornece a classe [GeometryPath](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometrypath/) .

* Uma instância de [GeometryPath](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometrypath/) representa o caminho geométrico de um objeto [GeometryShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometryshape/) .
* Para obter o [GeometryPath](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometrypath/) a partir de uma instância de [GeometryShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometryshape/) , use o método [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometryshape/get_geometry_paths/) .
* Para definir o [GeometryPath](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometrypath/) para uma forma, use [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometryshape/set_geometry_path/) para *solid shapes* e [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometryshape/set_geometry_paths/) para *composite shapes* .
* Para adicionar segmentos, use os métodos de [GeometryPath](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometrypath/) .
* Use as propriedades [GeometryPath.stroke](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometrypath/stroke/) e [GeometryPath.fill_mode](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometrypath/fill_mode/) para controlar a aparência de um caminho geométrico.
* Use a propriedade [GeometryPath.path_data](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometrypath/path_data/) para obter o caminho geométrico de uma forma como um array de segmentos de caminho.

## **Operações Simples de Edição**

Os métodos a seguir são usados para operações simples de edição.

**Adicionar uma linha** ao final de um caminho:

```py
line_to(point)
line_to(x, y)
```

**Adicionar uma linha** em uma posição especificada em um caminho:

```py    
line_to(point, index)
line_to(x, y, index)
```

**Adicionar uma curva cúbica de Bézier** ao final de um caminho:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**Adicionar uma curva cúbica de Bézier** em uma posição especificada em um caminho:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**Adicionar uma curva quadrática de Bézier** ao final de um caminho:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**Adicionar uma curva quadrática de Bézier** em uma posição especificada em um caminho:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**Anexar um arco** a um caminho:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**Fechar a figura atual** em um caminho:

```py
close_figure()
```

**Definir a posição para o próximo ponto**:

```py
move_to(point)
move_to(x, y)
```

**Remover o segmento de caminho** em um índice especificado:

```py
remove_at(index)
```

## **Adicionar Pontos Personalizados a Formas**

Aqui você aprenderá como definir uma forma livre adicionando sua própria sequência de pontos. Ao especificar pontos ordenados e tipos de segmentos (reto ou curvo) e, opcionalmente, fechar o caminho, você pode desenhar gráficos personalizados precisos — polígonos, ícones, balões ou logotipos — diretamente em seus slides.

1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometryshape/) e defina seu [ShapeType.RECTANGLE](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapetype/) .
2. Obtenha uma instância de [GeometryPath](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometrypath/) a partir da forma.
3. Insira um novo ponto entre os dois pontos superiores do caminho.
4. Insira um novo ponto entre os dois pontos inferiores do caminho.
5. Aplique o caminho atualizado à forma.

O código Python a seguir demonstra como adicionar pontos personalizados a uma forma:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```

![Pontos personalizados](custom_shape_1.png)

##  **Remover Pontos de Formas**

Às vezes, uma forma personalizada contém pontos desnecessários que complicam sua geometria ou afetam sua renderização. Esta seção mostra como remover pontos específicos do caminho de uma forma para que você possa simplificar o contorno e obter resultados mais limpos e precisos.

1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometryshape/) e defina seu tipo [ShapeType.HEART](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapetype/) .
2. Obtenha uma instância de [GeometryPath](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometrypath/) a partir da forma.
3. Remova um segmento do caminho.
4. Aplique o caminho atualizado à forma.

O código Python a seguir demonstra como remover pontos de uma forma:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```

![Pontos removidos](custom_shape_2.png)

##  **Criar Formas Personalizadas**

Crie formas vetoriais sob medida definindo um [GeometryPath](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometrypath/) e compondo-o a partir de linhas, arcos e curvas Bézier. Esta seção mostra como construir uma geometria personalizada do zero e adicionar a forma resultante ao seu slide.

1. Calcule os pontos para a forma.
2. Crie uma instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometrypath/) .
3. Popule o caminho com os pontos.
4. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometryshape/) .
5. Aplique o caminho à forma.

O código Python a seguir demonstra como criar uma forma personalizada:

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Forma personalizada](custom_shape_3.png)

## **Criar Formas Personalizadas Compostas**

Criar uma forma personalizada composta permite combinar vários caminhos geométricos em uma única forma reutilizável em um slide. Defina e mescle esses caminhos para criar visuais complexos que vão além do conjunto padrão de formas.

1. Crie uma instância da classe [GeometryShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometryshape/) .
2. Crie a primeira instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometrypath/) .
3. Crie a segunda instância da classe [GeometryPath](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometrypath/) .
4. Aplique ambos os caminhos à forma.

O código Python a seguir demonstra como criar uma forma personalizada composta:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Forma composta](custom_shape_4.png)

## **Criar Formas Personalizadas com Cantos Curvos**

Esta seção mostra como desenhar uma forma personalizada com cantos suavemente curvos usando um caminho geométrico. Você combinará segmentos retos e arcos circulares para formar o contorno e adicionará a forma final ao seu slide.

O código Python a seguir demonstra como criar uma forma personalizada com cantos curvos:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```

![Cantos curvos](custom_shape_6.png)

## **Determinar se a Geometria de uma Forma está Fechada**

Uma forma fechada é definida como aquela em que todos os seus lados se conectam, formando um único contorno sem lacunas. Essa forma pode ser uma forma geométrica simples ou um contorno personalizado complexo. O exemplo de código a seguir mostra como verificar se a geometria de uma forma está fechada:

```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```

## **FAQ**

**O que acontecerá ao preenchimento e ao contorno após substituir a geometria?**

O estilo permanece na forma; apenas o contorno muda. O preenchimento e o contorno são aplicados automaticamente à nova geometria.

**Como rotacionar corretamente uma forma personalizada juntamente com sua geometria?**

Use a propriedade [rotation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/geometryshape/rotation/) da forma; a geometria gira com a forma porque está vinculada ao sistema de coordenadas da própria forma.

**Posso converter uma forma personalizada em uma imagem para "travar" o resultado?**

Sim. Exporte a área do [slide](/slides/pt/python-net/convert-powerpoint-to-png/) necessária ou a própria [forma](/slides/pt/python-net/create-shape-thumbnails/) para um formato raster; isso simplifica o trabalho posterior com geometrias complexas.