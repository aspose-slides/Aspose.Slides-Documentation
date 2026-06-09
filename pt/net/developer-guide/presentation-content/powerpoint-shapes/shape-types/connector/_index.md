---
title: Gerenciar Conectores em Apresentações no .NET
linktitle: Conector
type: docs
weight: 10
url: /pt/net/connector/
keywords:
- conector
- tipo de conector
- ponto de conector
- linha de conector
- ângulo de conector
- conectar formas
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Capacite aplicativos .NET a desenhar, conectar e roteirizar automaticamente linhas em slides do PowerPoint—obtenha controle total sobre conectores retos, em cotovelo e curvos."
---
## **Introdução**

Um conector do PowerPoint é uma linha especial que conecta ou vincula duas formas e permanece anexada às formas mesmo quando elas são movidas ou reposicionadas em um slide específico. 

Os conectores geralmente são conectados a *pontos de conexão* (pontos verdes), que existem em todas as formas por padrão. Os pontos de conexão aparecem quando o cursor se aproxima deles.

*Pontos de ajuste* (pontos laranja), que existem apenas em certos conectores, são usados para modificar as posições e as formas dos conectores.

## **Tipos de Conectores**

No PowerPoint, você pode usar conectores retos, com cotovelo (angular) e curvos. 

O Aspose.Slides oferece estes conectores:

| Conector                      | Imagem                                                        | Número de pontos de ajuste |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Conectar Formas Usando Conectores**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Obtenha a referência de um slide por meio de seu índice.
1. Adicione duas [AutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/autoshape/) ao slide usando o método `AddAutoShape` exposto pelo objeto `Shapes`.
1. Adicione um conector usando o método `AddConnector` exposto pelo objeto `Shapes`, definindo o tipo de conector.
1. Conecte as formas usando o conector.
1. Chame o método `Reroute` para aplicar o caminho de conexão mais curto.
1. Salve a apresentação. 

Este código C# mostra como adicionar um conector (um conector dobrado) entre duas formas (uma elipse e um retângulo):

```c#
// Instancia uma classe de apresentação que representa um arquivo PPTX
using (Presentation input = new Presentation())
{                
    // Acessa a coleção de formas de um slide específico
    IShapeCollection shapes = input.Slides[0].Shapes;

    // Adiciona uma forma automática Elipse
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Adiciona uma forma automática Retângulo
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // Adiciona uma forma de conector à coleção de formas do slide
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // Conecta as formas usando o conector
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Chama reroute que define o caminho automático mais curto entre as formas
    connector.Reroute();

    // Salva a apresentação
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

O método `Connector.Reroute` redireciona um conector e força‑o a seguir o caminho mais curto possível entre as formas. Para alcançar esse objetivo, o método pode alterar os pontos `StartShapeConnectionSiteIndex` e `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Especificar um Ponto de Conexão**
Se você quiser que um conector ligue duas formas usando pontos específicos nas formas, deve especificar os pontos de conexão desejados desta maneira:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Obtenha a referência de um slide por meio de seu índice.
1. Adicione duas [AutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/autoshape/) ao slide usando o método `AddAutoShape` exposto pelo objeto `Shapes`.
1. Adicione um conector usando o método `AddConnector` exposto pelo objeto `Shapes`, definindo o tipo de conector.
1. Conecte as formas usando o conector. 
1. Defina seus pontos de conexão preferidos nas formas. 
1. Salve a apresentação.

Este código C# demonstra uma operação onde um ponto de conexão preferido é especificado:

```c#
// Instancia uma classe de apresentação que representa um arquivo PPTX
using (Presentation presentation = new Presentation())
{
    // Acessa a coleção de formas de um slide específico
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // Adiciona uma forma de conector à coleção de formas do slide
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // Adiciona uma forma automática Elipse
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // Adiciona uma forma automática Retângulo
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // Conecta as formas usando o conector
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // Define o índice do ponto de conexão preferido na forma Elipse
    uint wantedIndex = 6;

    // Verifica se o índice preferido é menor que a contagem máxima de pontos de conexão
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // Define o ponto de conexão preferido na autoshape Elipse
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // Salva a apresentação
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **Ajustar um Ponto de Conector**

Você pode ajustar um conector existente através dos seus pontos de ajuste. Apenas conectores com pontos de ajuste podem ser alterados dessa forma. Veja a tabela em **[Tipos de conectores.](/slides/pt/net/connector/#types-of-connectors)** 

### **Caso Simples**

Considere um caso em que um conector entre duas formas (A e B) passa por uma terceira forma (C):

![connector-obstruction](connector-obstruction.png)

Code:

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

Para evitar ou contornar a terceira forma, podemos ajustar o conector movendo sua linha vertical para a esquerda desta maneira:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **Casos Complexos** 

Para realizar ajustes mais complicados, você deve levar em conta os seguintes itens:

* O ponto ajustável de um conector está fortemente vinculado a uma fórmula que calcula e determina sua posição. Portanto, alterações na localização do ponto podem modificar a forma do conector.
* Os pontos de ajuste de um conector são definidos em uma ordem estrita em um array. Os pontos de ajuste são numerados do ponto inicial ao ponto final do conector.
* Os valores dos pontos de ajuste refletem a porcentagem da largura/altura da forma do conector. 
  * A forma é limitada pelos pontos inicial e final do conector multiplicados por 1000. 
  * O primeiro ponto, o segundo ponto e o terceiro ponto definem, respectivamente, a porcentagem da largura, a porcentagem da altura e novamente a porcentagem da largura.
* Para os cálculos que determinam as coordenadas dos pontos de ajuste de um conector, você deve levar em conta a rotação do conector e sua reflexão. **Observação** de que o ângulo de rotação para todos os conectores mostrados em **[Tipos de conectores](/slides/pt/net/connector/#types-of-connectors)** é 0.

#### **Caso 1**

Considere um caso em que dois objetos de caixa de texto são ligados entre si por meio de um conector:

![connector-shape-complex](connector-shape-complex.png)

Code:

```c#
// Instancia uma classe de apresentação que representa um arquivo PPTX
Presentation pres = new Presentation();
// Obtém o primeiro slide da apresentação
ISlide sld = pres.Slides[0];
// Adiciona formas que serão unidas por meio de um conector
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// Adiciona um conector
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// Especifica a direção do conector
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// Especifica a cor do conector
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// Especifica a espessura da linha do conector
connector.LineFormat.Width = 3;

// Conecta as formas usando o conector
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// Obtém os pontos de ajuste do conector
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**Ajuste**

Podemos alterar os valores dos pontos de ajuste do conector aumentando a porcentagem correspondente de largura e altura em 20% e 200%, respectivamente:

```c#
// Altera os valores dos pontos de ajuste
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

O resultado:

![connector-adjusted-1](connector-adjusted-1.png)

Para definir um modelo que nos permita determinar as coordenadas e a forma das partes individuais do conector, vamos criar uma forma que corresponde ao componente horizontal do conector no ponto connector.Adjustments[0]:

```c#
// Desenha o componente vertical do conector

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

O resultado:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Caso 2**

No **Caso 1**, demonstramos uma operação simples de ajuste de conector usando princípios básicos. Em situações normais, você deve levar em conta a rotação do conector e sua exibição (que são definidas por connector.Rotation, connector.Frame.FlipH e connector.Frame.FlipV). Agora demonstraremos o processo.

Primeiro, vamos adicionar um novo objeto de caixa de texto (**To 1**) ao slide (para fins de conexão) e criar um novo conector (verde) que o conecte aos objetos que já criamos.

```c#
// Cria um novo objeto de ligação
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// Cria um novo conector
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// Conecta objetos usando o conector recém-criado
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// Obtém os pontos de ajuste do conector
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// Altera os valores dos pontos de ajuste
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

O resultado:

![connector-adjusted-3](connector-adjusted-3.png)

Em segundo lugar, vamos criar uma forma que corresponderá ao componente horizontal do conector que passa pelo novo ponto de ajuste do conector connector.Adjustments[0]. Usaremos os valores dos dados do conector para connector.Rotation, connector.Frame.FlipH e connector.Frame.FlipV e aplicaremos a popular fórmula de conversão de coordenadas para rotação em torno de um ponto x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

Em nosso caso, o ângulo de rotação do objeto é 90 graus e o conector é exibido verticalmente, portanto este é o código correspondente:

```c#
// Salva as coordenadas do conector
x = connector.X;
y = connector.Y;
// Corrige as coordenadas do conector caso ele apareça
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// Usa o valor do ponto de ajuste como coordenada
x += connector.Width * adjValue_0.RawValue / 100000;
//  Converte as coordenadas já que Sin(90) = 1 e Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// Determina a largura do componente horizontal usando o valor do segundo ponto de ajuste
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

O resultado:

![connector-adjusted-4](connector-adjusted-4.png)

Demonstramos cálculos envolvendo ajustes simples e pontos de ajuste complicados (pontos de ajuste com ângulos de rotação). Com o conhecimento adquirido, você pode desenvolver seu próprio modelo (ou escrever um código) para obter um objeto `GraphicsPath` ou até mesmo definir os valores dos pontos de ajuste de um conector com base em coordenadas específicas do slide.

## **Encontrar o Ângulo das Linhas do Conector**
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Obtenha a referência de um slide por meio de seu índice.
1. Acesse a forma da linha do conector. 
1. Use a largura, altura da linha, altura do quadro da forma e largura do quadro da forma para calcular o ângulo.

Este código C# demonstra uma operação na qual calculamos o ângulo de uma forma de linha de conector:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **Perguntas Frequentes**

**Como posso saber se um conector pode ser "colado" a uma forma específica?**

Verifique se a forma expõe [pontos de conexão](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/connectionsitecount/). Se não houver nenhum ou a contagem for zero, a colagem não está disponível; nesse caso, use pontos finais livres e posicione‑os manualmente. É recomendável verificar a contagem de sites antes de anexar.

**O que acontece com um conector se eu excluir uma das formas conectadas?**

Suas extremidades serão desacopladas; o conector permanece no slide como uma linha comum com início/fim livres. Você pode excluí‑lo ou reatribuir as conexões e, se necessário, [redirecionar](https://reference.aspose.com/slides/pt/net/aspose.slides/connector/reroute/).

**As ligações dos conectores são preservadas ao copiar um slide para outra apresentação?**

Geralmente sim, desde que as formas de destino também sejam copiadas. Se o slide for inserido em outro arquivo sem as formas conectadas, as extremidades se tornam livres e será necessário reanexá‑las.