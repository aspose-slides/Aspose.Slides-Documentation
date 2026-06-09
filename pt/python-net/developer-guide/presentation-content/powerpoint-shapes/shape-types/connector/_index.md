---
title: Gerenciar conectores em apresentações com Python
linktitle: Conector
type: docs
weight: 10
url: /pt/python-net/connector/
keywords:
- conector
- tipo de conector
- ponto de conexão
- linha de conector
- ângulo do conector
- conectar formas
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Capacite aplicativos Python a desenhar, conectar e roteirizar automaticamente linhas em slides PowerPoint e OpenDocument — obtenha controle total sobre conectores retos, em cotovelo e curvos."
---
## **Introdução**

Um conector do PowerPoint é uma linha especializada que liga duas formas e permanece anexada quando as formas são movidas ou reposicionadas em um slide. Os conectores se fixam em **pontos de conexão** (pontos verdes) nas formas. Os pontos de conexão aparecem quando o cursor se aproxima deles. **Alças de ajuste** (pontos amarelos), disponíveis em certos conectores, permitem modificar a posição e o formato de um conector.

## **Tipos de Conector**

No PowerPoint, você pode usar três tipos de conectores: reto, cotovelo (angulado) e curvo.

O Aspose.Slides oferece suporte aos seguintes tipos de conectores:

| Tipo de Conector | Imagem | Número de pontos de ajuste |
| ---------------- | ------ | --------------------------- |
| `ShapeType.LINE` | ![Line connector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Straight connector 1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![Bent connector 2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![Bent connector 3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![Bent connector 4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![Bent connector 5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![Curved connector 2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![Curved connector 3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![Curved connector 4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![Curved connector 5](shapetype.curvedconnector5.png) | 3 |

## **Conectar Formas com Conectores**

Esta seção demonstra como ligar formas com conectores no Aspose.Slides. Você adicionará um conector a um slide, anexará seu início e fim às formas alvo. Usar locais de conexão garante que o conector permaneça “colado” às formas mesmo quando elas são movidas ou redimensionadas.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência ao slide pelo seu índice.
1. Adicione dois objetos [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide usando o método `add_auto_shape` exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/).
1. Adicione um conector usando o método `add_connector` exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/) e especifique o tipo de conector.
1. Conecte as formas com o conector.
1. Chame o método `reroute` para aplicar o caminho de conexão mais curto.
1. Salve a apresentação.

```python
import aspose.slides as slides

# Instanciar a classe Presentation para criar um arquivo PPTX.
with slides.Presentation() as presentation:

    # Acessar a coleção de formas do primeiro slide.
    shapes = presentation.slides[0].shapes

    # Adicionar um AutoShape de elipse.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Adicionar um AutoShape de retângulo.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Adicionar um conector ao slide.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Conectar as formas com o conector.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Chamar reroute para definir o caminho mais curto.
    connector.reroute()

    # Salvar a apresentação.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
O método `connector.reroute` redireciona um conector, forçando-o a seguir o caminho mais curto possível entre as formas. Para isso, o método pode alterar os valores `start_shape_connection_site_index` e `end_shape_connection_site_index`.
{{% /alert %}}

## **Especificar Pontos de Conexão**

Esta seção explica como anexar um conector a um ponto de conexão específico em uma forma no Aspose.Slides. Ao direcionar locais de conexão precisos, você pode controlar o roteamento e o layout do conector, produzindo diagramas limpos e previsíveis em suas apresentações.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência ao slide pelo seu índice.
1. Adicione dois objetos [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) ao slide usando o método `add_auto_shape` exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/).
1. Adicione um conector usando o método `add_connector` exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/) e especifique o tipo de conector.
1. Conecte as formas com o conector.
1. Defina os pontos de conexão preferidos nas formas.
1. Salve a apresentação.

```python
import aspose.slides as slides

# Instanciar a classe Presentation para criar um arquivo PPTX.
with slides.Presentation() as presentation:

    # Acessar a coleção de formas do primeiro slide.
    shapes = presentation.slides[0].shapes

    # Adicionar um AutoShape de elipse.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Adicionar um AutoShape de retângulo.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Adicionar um conector à coleção de formas do slide.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Conectar as formas com o conector.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Definir o índice do site de conexão preferido na elipse.
    site_index = 6

    # Verificar se o índice preferido está dentro da contagem de sites disponível.
    if  ellipse.connection_site_count > site_index:
        # Atribuir o site de conexão preferido no AutoShape da elipse.
        connector.start_shape_connection_site_index = site_index

    # Salvar a apresentação.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajustar Pontos do Conector**

Você pode modificar conectores usando seus pontos de ajuste. Apenas conectores que expõem pontos de ajuste podem ser editados dessa forma. Para detalhes sobre quais conectores suportam ajustes, veja a tabela em [Connector Types](/slides/pt/python-net/connector/#connector-types).

### **Caso Simples**

Considere um caso em que um conector entre duas formas (A e B) intersecta uma terceira forma (C):

![Obstrução do conector](connector-obstruction.png)

Exemplo de código:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

Para evitar a terceira forma, ajuste o conector movendo seu segmento vertical para a esquerda:

![Obstrução de conector corrigida](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Casos Complexos**

Para ajustes mais avançados, considere o seguinte:

- O ponto ajustável de um conector é governado por uma fórmula que determina sua posição. Alterar esse ponto pode mudar a forma geral do conector.
- Os pontos de ajuste de um conector são armazenados em um array estritamente ordenado, numerado do início ao fim do conector.
- Os valores dos pontos de ajuste representam porcentagens da largura/altura da forma do conector.
  - A forma é limitada pelos pontos de início e fim do conector e escalada por 1000.
  - Os primeiros, segundo e terceiro pontos de ajuste representam, respectivamente: porcentagem da largura, porcentagem da altura e porcentagem da largura (novamente).
- Ao calcular as coordenadas dos pontos de ajuste, leve em conta a rotação e a reflexão do conector. **Nota:** Para todos os conectores listados em [Connector Types](/slides/pt/python-net/connector/#connector-types), o ângulo de rotação é 0.

#### **Caso 1**

Considere um caso em que dois objetos de quadro de texto são vinculados com um conector:

![Formas vinculadas](connector-shape-complex.png)

Exemplo de código:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar a classe Presentation para criar um arquivo PPTX.
with slides.Presentation() as presentation:

    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Obter o primeiro slide.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Adicionar um conector.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Definir a direção do conector.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Definir a cor do conector.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Definir a espessura da linha do conector.
    connector.line_format.width = 3

    # Vincular as formas com o conector.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Obter os pontos de ajuste do conector.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Ajuste**

Altere os valores dos pontos de ajuste do conector aumentando a porcentagem de largura em 20 % e a porcentagem de altura em 200 %, respectivamente:

```python
    # Alterar os valores dos pontos de ajuste.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

O resultado:

![Ajuste do conector 1](connector-adjusted-1.png)

Para definir um modelo que nos permita determinar as coordenadas e a forma dos segmentos do conector, crie uma forma que corresponda ao componente vertical do conector em `connector.adjustments[0]`:

```python
    # Desenhar o componente vertical do conector.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

O resultado:

![Ajuste do conector 2](connector-adjusted-2.png)

#### **Caso 2**

No **Caso 1**, demonstramos um ajuste simples de conector usando princípios básicos. Em cenários típicos, você deve considerar a rotação do conector e suas configurações de exibição (controladas por `connector.rotation`, `connector.frame.flip_h` e `connector.frame.flip_v`). Veja como o processo funciona.

Primeiro, adicione um novo objeto de quadro de texto (**To 1**) ao slide (para conexão) e crie um novo conector verde que o ligue aos objetos existentes.

```python
    # Criar um novo objeto de destino.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Criar um novo conector.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Conectar os objetos usando o conector recém-criado.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Obter os pontos de ajuste do conector.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Alterar os valores dos pontos de ajuste.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

O resultado:

![Ajuste do conector 3](connector-adjusted-3.png)

Segundo, crie uma forma que corresponda ao segmento **horizontal** do conector que passa pelo novo ponto de ajuste do conector, `connector.adjustments[0]`. Use os valores de `connector.rotation`, `connector.frame.flip_h` e `connector.frame.flip_v` e aplique a fórmula padrão de conversão de coordenadas para rotação em torno de um ponto `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

No nosso caso, o ângulo de rotação do objeto é 90 graus e o conector é exibido verticalmente, então o código correspondente é:

```python
    # Salvar as coordenadas do conector.
    x = connector.x
    y = connector.y
    
    # Corrigir as coordenadas do conector se ele estiver invertido.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Usar o valor do ponto de ajuste como coordenada.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Converter as coordenadas porque sin(90°) = 1 e cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Determinar a largura do segmento horizontal usando o valor do segundo ponto de ajuste.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

O resultado:

![Ajuste do conector 4](connector-adjusted-4.png)

Demonstramos cálculos envolvendo ajustes simples e pontos de ajuste mais complexos (aqueles que consideram rotação). Usando esse conhecimento, você pode desenvolver seu próprio modelo — ou escrever código — para obter um objeto `GraphicsPath` ou até mesmo definir os valores dos pontos de ajuste do conector com base em coordenadas específicas do slide.

## **Encontrar Ângulos de Linha do Conector**

Use o exemplo abaixo para determinar o ângulo das linhas de conector em um slide com Aspose.Slides. Você aprenderá a ler os pontos finais de um conector e calcular sua orientação para alinhar com precisão setas, rótulos e outras formas.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência ao slide pelo índice.
1. Acesse a forma de linha do conector.
1. Use a largura e altura da linha e a largura e altura da moldura da forma para calcular o ângulo.

O seguinte código Python demonstra como calcular o ângulo para uma forma de linha de conector:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **FAQ**

**Como posso saber se um conector pode ser “colado” a uma forma específica?**

Verifique se a forma expõe [pontos de conexão](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/connection_site_count/). Se não houver nenhum ou a contagem for zero, a colagem não está disponível; nesse caso, use pontos finais livres e posicione-os manualmente. É sensato verificar a contagem de sites antes de anexar.

**O que acontece com um conector se eu excluir uma das formas conectadas?**

Suas extremidades serão desacopladas; o conector permanece no slide como uma linha comum com início/fim livres. Você pode excluí-lo ou reatribuir as conexões e, se necessário, [reroute](https://reference.aspose.com/slides/pt/python-net/aspose.slides/connector/reroute/).

**As ligações de conectores são preservadas ao copiar um slide para outra apresentação?**

Geralmente sim, desde que as formas alvo também sejam copiadas. Se o slide for inserido em outro arquivo sem as formas conectadas, as extremidades se tornam livres e será preciso recolocá‑las.