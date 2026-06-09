---
title: Gerenciar Conectores em Apresentações Usando C++
linktitle: Conector
type: docs
weight: 10
url: /pt/cpp/connector/
keywords:
- conector
- tipo de conector
- ponto de conector
- linha de conector
- ângulo do conector
- conectar formas
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Capacite aplicativos C++ a desenhar, conectar e roteirizar automaticamente linhas em slides do PowerPoint—obtenha controle total sobre conectores retos, de cotovelo e curvos."
---
## **Introdução**

Um conector do PowerPoint é uma linha especial que conecta ou liga duas formas juntas e permanece anexado às formas mesmo quando elas são movidas ou reposicionadas em um slide determinado. 

Os conectores normalmente são conectados a *pontos de conexão* (pontos verdes), que existem em todas as formas por padrão. Os pontos de conexão aparecem quando o cursor se aproxima deles.

*Pontos de ajuste* (pontos laranja), que existem apenas em certos conectores, são usados para modificar as posições e formas dos conectores.

## **Tipos de Conectores**

No PowerPoint, você pode usar conectores retos, de cotovelo (angulados) e curvos. 

Aspose.Slides fornece esses conectores:

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

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation/).
2. Obtenha a referência de um slide por meio de seu índice.
3. Adicione duas [AutoShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.auto_shape) ao slide usando o método `AddAutoShape` exposto pelo objeto `Shapes`.
4. Adicione um conector usando o método `AddConnector` exposto pelo objeto `Shapes` definindo o tipo de conector.
5. Conecte as formas usando o conector.
6. Chame o método `Reroute` para aplicar o caminho de conexão mais curto.
7. Salve a apresentação. 

Este código C++ mostra como adicionar um conector (um conector dobrado) entre duas formas (uma elipse e um retângulo):

```c++
// O caminho para o diretório de documentos.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Carrega a apresentação desejada
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Acessa o primeiro slide
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Acessa a coleção de formas de um slide específico
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Adiciona uma forma automática Elipse
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Adiciona uma forma automática Retângulo
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Adiciona uma forma de conector à coleção de formas do slide
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Conecta as formas usando o conector
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// Chama reroute que define o caminho automático mais curto entre as formas
	connector->Reroute();
	
	// Salva a apresentação
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


{{%  alert title="NOTE"  color="warning"   %}} 

O método `connector->Reroute` reconfigura um conector e o força a percorrer o caminho mais curto possível entre as formas. Para atingir seu objetivo, o método pode alterar os pontos `StartShapeConnectionSiteIndex` e `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Especificar um Ponto de Conexão**

Se você quiser que um conector ligue duas formas usando pontos específicos nas formas, deve especificar seus pontos de conexão preferidos desta maneira:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation/).
2. Obtenha a referência de um slide por meio de seu índice.
3. Adicione duas [AutoShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.auto_shape) ao slide usando o método `AddAutoShape` exposto pelo objeto `Shapes`.
4. Adicione um conector usando o método `AddConnector` exposto pelo objeto `Shapes` definindo o tipo de conector.
5. Conecte as formas usando o conector. 
6. Defina seus pontos de conexão preferidos nas formas. 
7. Salve a apresentação.

Este código C++ demonstra uma operação em que um ponto de conexão preferido é especificado:

```c++
	// O caminho para o diretório de documentos.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Carrega a apresentação desejada
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Acessa o primeiro slide
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Acessa a coleção de formas de um slide específico
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Adiciona uma forma automática Elipse
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Adiciona uma forma automática Retângulo
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Adiciona uma forma de conector à coleção de formas do slide
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Conecta as formas usando o conector
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// Define o índice do ponto de conexão preferido na forma Elipse
	int wantedIndex = 6;

	// Verifica se o índice preferido é menor que o número máximo de índices de pontos de conexão
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Define o ponto de conexão preferido na forma automática Elipse
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// Salva a apresentação
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ajustar um Ponto de Conector**

Você pode ajustar um conector existente através de seus pontos de ajuste. Apenas conectores com pontos de ajuste podem ser alterados dessa forma. Veja a tabela em **[Tipos de conectores.](/slides/pt/cpp/connector/#types-of-connectors)** 

### **Caso Simples**

Considere um caso em que um conector entre duas formas (A e B) passa por uma terceira forma (C):

![connector-obstruction](connector-obstruction.png)

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shapes = slide->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 300.0f, 150.0f, 150.0f, 75.0f);
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 400.0f, 100.0f, 50.0f);
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 70.0f, 30.0f);

auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20.0f, 20.0f, 400.0f, 300.0f);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_StartShapeConnectionSiteIndex(2);
```

Para evitar ou contornar a terceira forma, podemos ajustar o conector movendo sua linha vertical para a esquerda desta maneira:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **Casos Complexos** 

Para realizar ajustes mais complicados, você deve levar em conta as seguintes questões:

* O ponto ajustável de um conector está fortemente ligado a uma fórmula que calcula e determina sua posição. Portanto, alterações na localização do ponto podem modificar a forma do conector.
* Os pontos de ajuste de um conector são definidos em uma ordem estrita em um array. Os pontos de ajuste são numerados do ponto inicial ao ponto final do conector.
* Os valores dos pontos de ajuste refletem a porcentagem da largura/altura da forma do conector. 
  * A forma é limitada pelos pontos de início e fim do conector multiplicados por 1000. 
  * O primeiro ponto, o segundo ponto e o terceiro ponto definem, respectivamente, a porcentagem da largura, a porcentagem da altura e a porcentagem da largura (novamente). 
* Para cálculos que determinam as coordenadas dos pontos de ajuste de um conector, você deve levar em conta a rotação do conector e sua reflexão. **Observação** que o ângulo de rotação para todos os conectores mostrados em **[Tipos de conectores](/slides/pt/cpp/connector/#types-of-connectors)** é 0.

#### **Caso 1**

Considere um caso em que dois objetos de quadro de texto são ligados entre si por meio de um conector:

![connector-shape-complex](connector-shape-complex.png)

```c++
// Instancia uma classe de apresentação que representa um arquivo PPTX
auto pres = System::MakeObject<Presentation>();
// Obtém o primeiro slide da apresentação
auto slide = pres->get_Slides()->idx_get(0);
// Obtém as formas do primeiro slide
auto shapes = slide->get_Shapes();
// Adiciona formas que serão unidas por meio de um conector
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// Adiciona um conector
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Especifica a direção do conector
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Especifica a espessura da linha do conector
lineFormat->set_Width(3);
// Especifica a cor do conector
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Liga as formas juntas com o conector
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Obtém os pontos de ajuste do conector
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**Ajuste**

Podemos mudar os valores dos pontos de ajuste do conector aumentando a porcentagem correspondente de largura e altura em 20% e 200%, respectivamente:

```c++
// Altera os valores dos pontos de ajuste
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

![connector-adjusted-1](connector-adjusted-1.png)

Para definir um modelo que nos permita determinar as coordenadas e a forma das partes individuais do conector, vamos criar uma forma que corresponda ao componente horizontal do conector no ponto `connector.Adjustments[0]`:

```c++
// Desenha o componente vertical do conector
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

![connector-adjusted-2](connector-adjusted-2.png)

#### **Caso 2**

No **Caso 1**, demonstramos uma operação simples de ajuste de conector usando princípios básicos. Em situações normais, você deve levar em conta a rotação do conector e sua exibição (que são definidas por `connector.Rotation`, `connector.Frame.FlipH` e `connector.Frame.FlipV`). Agora demonstraremos o processo.

Primeiro, vamos adicionar um novo objeto de quadro de texto (**Para 1**) ao slide (para fins de conexão) e criar um novo conector (verde) que o conecte aos objetos que já criamos.

```c++
// Cria um novo objeto de vínculo
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// Cria um novo conector
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Conecta objetos usando o conector recém-criado
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Obtém os pontos de ajuste do conector
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Altera os valores dos pontos de ajuste
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

![connector-adjusted-3](connector-adjusted-3.png)

Segundo, vamos criar uma forma que corresponderá ao componente horizontal do conector que passa pelo ponto de ajuste do novo conector `connector.Adjustments[0]`. Usaremos os valores dos dados do conector para `connector.Rotation`, `connector.Frame.FlipH` e `connector.Frame.FlipV` e aplicaremos a conhecida fórmula de conversão de coordenadas para rotação em torno de um ponto x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

No nosso caso, o ângulo de rotação do objeto é 90 graus e o conector é exibido verticalmente, portanto este é o código correspondente:

```c++

```

![connector-adjusted-4](connector-adjusted-4.png)

Demonstramos cálculos envolvendo ajustes simples e pontos de ajuste complicados (pontos de ajuste com ângulos de rotação). Usando o conhecimento adquirido, você pode desenvolver seu próprio modelo (ou escrever um código) para obter um objeto `GraphicsPath` ou mesmo definir os valores dos pontos de ajuste de um conector com base em coordenadas específicas do slide.

## **Encontrar o Ângulo das Linhas de Conector**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation/).
2. Obtenha a referência de um slide por meio de seu índice.
3. Acesse a forma da linha do conector.
4. Use a largura, altura, altura da moldura da forma e largura da moldura da forma para calcular o ângulo.

```c++
void ConnectorLineAngle()
{

	// O caminho para o diretório de documentos.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Carrega a apresentação desejada
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Acessa o primeiro slide
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// Acessa a coleção de formas dos slides
		System::SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(i);

		if (System::ObjectExt::Is<AutoShape>(shape))
		{
			SharedPtr<AutoShape> aShape = ExplicitCast<Aspose::Slides::AutoShape>(shape);
			if (aShape->get_ShapeType() == ShapeType::Line)
			{
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(), aShape->get_Frame()->get_FlipV());

			}
		}

		else if (System::ObjectExt::Is<Connector>(shape))
		{
				SharedPtr<Connector> aShape = ExplicitCast<Aspose::Slides::Connector>(shape);
//				dir = getDirection(aShape->get_Width(), aShape->get_Height(), Convert::ToBoolean(aShape->get_Frame()->get_FlipH()), Convert::ToBoolean(aShape->get_Frame()->get_FlipV()));
				dir = getDirection(aShape->get_Width(), aShape->get_Height(), aShape->get_Frame()->get_FlipH(),aShape->get_Frame()->get_FlipV());
		}

		Console::WriteLine(dir);
	
	}


}
//double ConnectorLineAngle::getDirection(float w, float h, NullableBool flipH, NullableBool flipV)
double getDirection(float w, float h, Aspose::Slides::NullableBool flipH, Aspose::Slides::NullableBool flipV)
{
	float endLineX = w;

	if (flipH == NullableBool::True)
		endLineX= endLineX * -1;
	else
		endLineX=endLineX *  1;
	//float endLineX = w * (flipH ? -1 : 1);
	float endLineY = h;
	if (flipV == NullableBool::True)
		endLineY = endLineY * -1;
	else
		endLineY = endLineY *  1;
	//float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```

## **FAQ**

**Como posso saber se um conector pode ser "colado" a uma forma específica?**

Verifique se a forma expõe [pontos de conexão](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shape/get_connectionsitecount/). Se não houver nenhum ou a contagem for zero, a colagem não está disponível; nesse caso, use pontos finais livres e posicione‑os manualmente. É prudente verificar a contagem de pontos antes de anexar.

**O que acontece com um conector se eu excluir uma das formas conectadas?**

Suas extremidades serão desanexadas; o conector permanece no slide como uma linha ordinária com início/fim livres. Você pode excluí‑lo ou reatribuir as conexões e, se necessário, [re‑rotear](https://reference.aspose.com/slides/pt/cpp/aspose.slides/connector/reroute/).

**As ligações do conector são preservadas ao copiar um slide para outra apresentação?**

Geralmente sim, desde que as formas de destino também sejam copiadas. Se o slide for inserido em outro arquivo sem as formas conectadas, as extremidades tornam‑se livres e será necessário reanexá‑las.