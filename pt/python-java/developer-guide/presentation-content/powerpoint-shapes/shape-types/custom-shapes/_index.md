---
title: Personalizar Formas de Apresentação em Python via Java
linktitle: Forma Personalizada
type: docs
weight: 20
url: /pt/python-java/custom-shape/
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
- Python
- Aspose.Slides
description: "Criar e personalizar formas em apresentações PowerPoint com Aspose.Slides para Python via Java: caminhos de geometria, cantos curvos, formas compostas."
---
## **Visão geral**

Este artigo explica como personalizar formas de apresentação no Aspose.Slides editando a geometria da forma através de pontos de edição e caminhos de geometria. Ele demonstra como trabalhar com [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) para modificar formas existentes, executar operações básicas de edição de caminho, adicionar ou remover pontos e aplicar a geometria atualizada de volta a uma forma.

Ele também demonstra como criar formas personalizadas e compostas, construir formas com cantos curvos, determinar se a geometria de uma forma está fechada, inspecionar elementos da forma e converter contornos de texto Java AWT em caminhos de geometria.

## **Alterar uma Forma Usando Pontos de Edição**

No PowerPoint, você pode usar **Edit Points** para modificar um quadrado:

* Mover um canto para dentro ou para fora.
* Ajustar a curvatura em um ponto.
* Adicionar novos pontos.

Editar pontos permite que você modifique o contorno de uma forma ou use uma forma existente como base para uma nova.

## **Dicas de Edição de Formas**

![overview_image](custom_shape_0.png)

Ao editar formas do PowerPoint, lembre‑se destes conceitos:

* Uma forma (ou seu caminho) pode ser fechada ou aberta.
* O caminho de uma forma consiste em pontos de ancoragem conectados por segmentos.
* Um segmento pode ser reto ou curvo. Os pontos de ancoragem e as alças de controle determinam sua forma.
* Os pontos de ancoragem podem ser pontos de canto, pontos retos ou pontos suaves:
  * Em um ponto de canto, os segmentos adjacentes podem se encontrar em um ângulo.
  * Em um ponto suave, as duas alças de controle estão alinhadas e equidistantes do ponto de ancoragem.
  * Em um ponto reto, as duas alças de controle estão alinhadas, mas podem ter distâncias diferentes do ponto de ancoragem.
* Mover os pontos de ancoragem ou ajustar suas alças altera o contorno da forma.

Para editar formas do PowerPoint através de pontos de edição, **Aspose.Slides** fornece a classe [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* Uma instância de [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) representa um caminho de geometria do objeto [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* Para obter o [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) a partir da instância de [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/), você pode usar o método [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* Para definir o [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) de uma forma, você pode usar estes métodos: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) para formas com um único caminho e [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) para formas com múltiplos caminhos.
* Para adicionar segmentos, você pode usar os métodos sob [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* Usando os métodos [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) e [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode), você pode definir a aparência de um caminho de geometria.
* Usando o método [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData), você pode recuperar o caminho de geometria de um [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) como um array de segmentos de caminho.
* Para acessar opções adicionais de personalização da geometria de forma, você pode ler um [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) através de seu [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) e reproduzir os segmentos em um [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Operações Simples de Edição**

Use os seguintes métodos para editar um caminho de geometria. Sobrecargas que aceitam um índice inserem um segmento naquela posição baseada em zero no array de segmentos do caminho.

| Operação | Método |
| --- | --- |
| Anexar ou inserir uma linha reta. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Anexar ou inserir uma curva cúbica Bézier com dois pontos de controle e um ponto final. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Anexar ou inserir uma curva quadrática Bézier com um ponto de controle e um ponto final. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Anexar um arco elíptico com as dimensões e ângulos especificados em graus. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Fechar a figura atual conectando seu ponto final ao ponto inicial. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Definir o ponto inicial de uma figura. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Remover um segmento em um índice baseado em zero. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Adicionar Pontos Personalizados a uma Forma**

Este exemplo insere dois pontos em uma forma retangular usando [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) e aplica o caminho editado com [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). As coordenadas são locais à forma: ambos os novos pontos estão no seu centro, 100 pontos da esquerda e 50 pontos do topo. Os índices de segmento 1 e 4 os posicionam nas bordas superior e inferior, puxando essas bordas para dentro.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **Remover Pontos de uma Forma**

Este exemplo altera um contorno em forma de coração removendo o segmento no índice baseado em zero 2 com [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). Aplicar o caminho modificado com [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) atualiza o contorno da forma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Criar uma Forma Personalizada**

Este exemplo constrói uma estrela de cinco pontas com [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). Raios externos e internos alternados de 100 e 50 pontos definem as pontas e as reentrâncias; um passo de 72 graus espaça as cinco pontas uniformemente. O caminho é fechado com [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) e aplicado a uma forma retangular usando [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), substituindo seu contorno.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **Criar uma Forma Personalizada Composta**

Este exemplo define dois objetos [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) fechados para o terço superior e inferior de uma forma. Aplicar ambos os caminhos com [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) cria uma única forma composta com um espaço atravessando seu terço central.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **Criar uma Forma Personalizada com Cantos Curvos**

Este exemplo combina segmentos retos com [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) para criar uma forma com cantos curvos para dentro. Cada tamanho de canto define a largura e altura do arco em points, e o varrimento de -90 graus desenha um quarto de elipse no sentido anti‑horário. O caminho concluído é aplicado com [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), e a apresentação é salva no formato PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    
    shape.setGeometryPath(geometry_path)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Descobrir Se a Geometria de uma Forma Está Fechada**

O ajudante a seguir verifica se cada caminho de geometria não vazio termina com um segmento de fechamento. Ele lê [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) e compara o comando do segmento final [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) com [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Retorna `False` quando não há caminhos não vazios. Isso verifica o comando final de cada caminho; não inspeciona cada subfigura dentro de um caminho. O exemplo imprime `True` para um retângulo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **Inspecionar Comandos de Caminho de Geometria**

Baixe [contour.pptx](contour.pptx) e coloque‑o no diretório de trabalho da aplicação. A primeira forma no primeiro slide tem uma borda superior reta, uma curva cúbica Bézier e uma borda de fechamento reta. Use [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) para ler os caminhos da forma e [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) para ler os segmentos de cada caminho na ordem de desenho. Para cada segmento, [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) identifica o comando e determina como interpretar os valores retornados por [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

A forma está posicionada em (200, 100) points no slide. As coordenadas relatadas são locais à forma, com (0, 0) no canto superior esquerdo, x aumentando para a direita e y aumentando para baixo. O segmento de fechamento retorna ao ponto inicial sem coordenadas adicionais.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![Forma do PowerPoint com uma borda superior reta, uma borda curva do canto superior direito ao canto inferior esquerdo e uma borda esquerda reta](contour.png)

## **Extrair e Inspecionar Elementos de Forma**

Use [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) para inspecionar uma forma existente como elementos que contêm pontos de caminho e tipos de ponto. Converta cada elemento retornado para [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) com `jpype.JObject` para recuperar as matrizes de pontos e tipos através dos métodos [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) e [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). Essa representação é útil para análise de contorno ou passagem de geometria para ferramentas de desenho personalizadas.

O exemplo abre input.pptx, encontra a primeira forma de geometria diretamente no primeiro slide e imprime seus segmentos de caminho. Use uma apresentação contendo uma forma com segmentos retos e curvos para ver ambos os tipos de saída. Ele não procura dentro de grupos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Manter o tipo de segmento, excluindo bandeiras.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consumir ambos os pontos de controle e o ponto final.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

As matrizes correspondem por índice: `points[i]` é um ponto e `types[i]` descreve seu papel. O tipo `0` inicia uma figura, e o tipo `1` desenha uma linha do ponto anterior ao ponto atual. Um segmento cúbico Bézier inicia no ponto final anterior e usa três entradas consecutivas de tipo `3`: dois pontos de controle seguidos do novo ponto final. O loop consome essas três entradas juntas e verifica o ponto final para fechamento.

Os tipos de ponto também contêm flags. Mascare com `0x07` para identificar o tipo de segmento e teste `0x80` separadamente para detectar um subcaminho fechado. Por exemplo, `129` (`0x81`) significa um ponto final de linha que fecha um subcaminho, e `131` (`0x83`) significa um ponto final Bézier que fecha um. Java armazena essas flags em bytes assinados; a máscara preserva os valores de bits pretendidos. Comparar o valor bruto apenas com `1` ou `3` perderia esses casos. Outras flags, como traço (`0x10`) e marcador (`0x20`), não alteram o tipo base do segmento.

**Coordenadas e transformações.** Os points são medidos em points (1/72 polegada), com X aumentando para a direita e Y aumentando para baixo. Para uma forma não agrupada, as coordenadas extraídas já incluem a posição retornada por [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) e [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) e refletem sua largura e altura atuais. Por exemplo, um retângulo não rotacionado em `(100, 200)` com tamanho `120 × 80` tem limites de contorno `(100, 200)`–`(220, 280)`. Não adicione a posição da forma novamente. Subtraia seu X e Y para obter coordenadas relativas ao seu quadro não rotacionado.

Os pontos extraídos não aplicam a rotação da forma, retornada por [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation), ou reflexões horizontal e vertical. Para reproduzir o contorno exibido, aplique essas transformações ao redor do centro da forma. Para formas agrupadas, também considere o mapeamento de coordenadas do grupo e as transformações; não presuma que os pontos extraídos sejam as coordenadas finais renderizadas no slide ou aplique uma translação ou escala duas vezes se já estiver refletida no quadro do filho.

**Inspeção versus edição.** As matrizes extraídas descrevem o contorno; alterá‑las não atualiza a forma original. Escolha esta abordagem quando sua análise ou código de desenho precisar de arrays de ponto/tipo. Use [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) quando precisar de comandos de geometria no sistema de coordenadas local da forma ou quiser editar sua geometria. Aplique caminhos editados através de [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) ou [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Converter uma Forma Java AWT para GeometryPath**

Este exemplo combina um contorno retangular com texto convertido em geometria. O método [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) do contorno desativa seu preenchimento. Um [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) cria o contorno do texto em um [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Seu [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) fornece segmentos de movimento, linha, quadrático, cúbico e fechamento, que o exemplo reproduz em um [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

O texto usa uma fonte Arial de 40 points. O contorno é deslocado 20 points horizontalmente e posicionado com seu topo visual 10 points abaixo da borda superior da forma. O caminho do texto é preenchido, enquanto o retângulo original permanece como contorno. Aplicar ambos os caminhos com [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) produz uma única forma contendo o retângulo e o texto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Obter o caminho de geometria da forma.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Criar um novo caminho gráfico com texto.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # Converter o caminho gráfico em um caminho de geometria.
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # Aplicar o caminho de texto juntamente com o caminho de geometria original.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**O que acontecerá ao preenchimento e ao contorno após substituir a geometria?**

O estilo permanece na forma; apenas o contorno muda. O preenchimento e o contorno são aplicados automaticamente à nova geometria.

**Como rotacionar corretamente uma forma personalizada juntamente com sua geometria?**

Use o método [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) da forma; a geometria gira com a forma porque está vinculada ao próprio sistema de coordenadas da forma.

**Posso converter uma forma personalizada em uma imagem para "travar" o resultado?**

Sim. Exporte a área de [slide](/slides/pt/python-java/convert-powerpoint-to-png/) necessária ou a própria [shape](/slides/pt/python-java/create-shape-thumbnails/) para um formato raster; isso simplifica o trabalho posterior com geometrias complexas.