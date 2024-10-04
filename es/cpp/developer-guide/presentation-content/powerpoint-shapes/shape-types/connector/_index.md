---
title: Conector
type: docs
weight: 10
url: /es/cpp/connector/
keywords: "Conectar formas, conectores, formas de PowerPoint, presentación de PowerPoint, C++, CPP, Aspose.Slides para C++"
description: "Conectar formas de PowerPoint en C++"
---

Un conector de PowerPoint es una línea especial que conecta o vincula dos formas y se mantiene adherido a las formas incluso cuando se mueven o se reubican en una diapositiva dada. 

Los conectores suelen estar conectados a *puntos de conexión* (puntos verdes), que existen en todas las formas de forma predeterminada. Los puntos de conexión aparecen cuando un cursor se acerca a ellos.

Los *puntos de ajuste* (puntos naranjas), que existen solo en ciertos conectores, se utilizan para modificar las posiciones y formas de los conectores.

## **Tipos de Conectores**

En PowerPoint, puedes utilizar conectores rectos, en ángulo y curvados.

Aspose.Slides proporciona estos conectores:

| Conector                      | Imagen                                                        | Número de puntos de ajuste |
| ----------------------------- | ------------------------------------------------------------ | -------------------------- |
| `ShapeType.Line`              | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                          |
| `ShapeType.StraightConnector1`| ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                          |
| `ShapeType.BentConnector2`    | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                          |
| `ShapeType.BentConnector3`    | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                          |
| `ShapeType.BentConnector4`    | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                          |
| `ShapeType.BentConnector5`    | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                          |
| `ShapeType.CurvedConnector2`  | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                          |
| `ShapeType.CurvedConnector3`  | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                          |
| `ShapeType.CurvedConnector4`  | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                          |
| `ShapeType.CurvedConnector5`  | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                          |

## **Conectar Formas Usando Conectores**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega dos [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) a la diapositiva utilizando el método `AddAutoShape` expuesto por el objeto `Shapes`.
1. Agrega un conector utilizando el método `AddConnector` expuesto por el objeto `Shapes` definiendo el tipo de conector.
1. Conecta las formas usando el conector.
1. Llama al método `Reroute` para aplicar el camino de conexión más corto.
1. Guarda la presentación.

Este código C++ te muestra cómo agregar un conector (un conector doblado) entre dos formas (una elipse y un rectángulo):

```c++
// La ruta al directorio de documentos.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Carga la presentación deseada
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accede a la primera diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Accede a la colección de formas de una diapositiva específica
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Agrega una forma de elipse
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Agrega una forma de rectángulo
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Agrega una forma de conector a la colección de formas de la diapositiva
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Conecta las formas usando el conector
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);

	// Llama a reroute que establece el camino automático más corto entre formas
	connector->Reroute();
	
	// Guarda la presentación
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="NOTA" color="warning" %}} 

El método `connector->Reroute` vuelve a enrutar un conector y lo obliga a tomar el camino más corto posible entre las formas. Para lograr su objetivo, el método puede cambiar los puntos `StartShapeConnectionSiteIndex` y `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Especificar Punto de Conexión**

Si deseas que un conector vincule dos formas utilizando puntos específicos en las formas, debes especificar tus puntos de conexión preferidos de esta manera:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega dos [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) a la diapositiva utilizando el método `AddAutoShape` expuesto por el objeto `Shapes`.
1. Agrega un conector utilizando el método `AddConnector` expuesto por el objeto `Shapes` definiendo el tipo de conector.
1. Conecta las formas usando el conector.
1. Establece tus puntos de conexión preferidos en las formas.
1. Guarda la presentación.

Este código C++ demuestra una operación en la que se especifica un punto de conexión preferido:

```c++
// La ruta al directorio de documentos.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Carga la presentación deseada
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Accede a la primera diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Accede a la colección de formas de una diapositiva específica
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Agrega una forma de elipse
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Agrega una forma de rectángulo
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Agrega una forma de conector a la colección de formas de la diapositiva
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Conecta las formas usando el conector
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);

	// Establece el índice del punto de conexión preferido en la forma de elipse
	int wantedIndex = 6;

	// Verifica si el índice preferido es menor que el conteo máximo de índices de sitio
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Establece el punto de conexión preferido en la forma de elipse
		connector->set_StartShapeConnectionSiteIndex(wantedIndex);
	}

	// Guarda la presentación
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ajustar Punto de Conector**

Puedes ajustar un conector existente a través de sus puntos de ajuste. Solo los conectores con puntos de ajuste pueden ser alterados de esta manera. Consulta la tabla bajo **[Tipos de conectores.](/slides/es/cpp/connector/#types-of-connectors)** 

#### **Caso Simple**

Considera un caso en el que un conector entre dos formas (A y B) pasa a través de una tercera forma (C):

![connector-obstruction](connector-obstruction.png)

Código:

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

Para evitar o eludir la tercera forma, podemos ajustar el conector moviendo su línea vertical hacia la izquierda de esta manera:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **Casos Complejos** 

Para realizar ajustes más complicados, debes tener en cuenta estas cosas:

* Un punto ajustable de un conector está fuertemente vinculado a una fórmula que calcula y determina su posición. Por lo tanto, los cambios en la ubicación del punto pueden alterar la forma del conector.
* Los puntos de ajuste de un conector están definidos en un orden estricto en un array. Los puntos de ajuste están numerados desde el punto de inicio del conector hasta su final.
* Los valores de los puntos de ajuste reflejan el porcentaje del ancho/altura de la forma de un conector. 
  * La forma está limitada por los puntos de inicio y final del conector multiplicados por 1000. 
  * El primer punto, el segundo punto y el tercer punto definen el porcentaje del ancho, el porcentaje de la altura y el porcentaje del ancho (de nuevo), respectivamente.
* Para los cálculos que determinan las coordenadas de los puntos de ajuste de un conector, debes tener en cuenta la rotación del conector y su reflejo. **Nota** que el ángulo de rotación para todos los conectores mostrados bajo **[Tipos de conectores](/slides/es/cpp/connector/#types-of-connectors)** es 0.

#### **Caso 1**

Considera un caso en el que dos objetos de cuadro de texto están vinculados entre sí a través de un conector:

![connector-shape-complex](connector-shape-complex.png)

Código:

```c++
// Instancia una clase de presentación que representa un archivo PPTX
auto pres = System::MakeObject<Presentation>();
// Obtiene la primera diapositiva en la presentación
auto slide = pres->get_Slides()->idx_get(0);
// Obtiene formas de la primera diapositiva
auto shapes = slide->get_Shapes();
// Agrega formas que se unirán a través de un conector
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"Desde");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"Para");
// Agrega un conector
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Especifica la dirección del conector
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Especifica el grosor de la línea del conector
lineFormat->set_Width(3);
// Especifica el color del conector
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Vincula las formas juntas con el conector
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Obtiene los puntos de ajuste para el conector
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**Ajuste**

Podemos cambiar los valores de los puntos de ajuste del conector aumentando el porcentaje de ancho y altura correspondiente en un 20% y 200%, respectivamente:

```c++
// Cambia los valores de los puntos de ajuste
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

El resultado:

![connector-adjusted-1](connector-adjusted-1.png)

Para definir un modelo que nos permita determinar las coordenadas y la forma de las partes individuales del conector, vamos a crear una forma que corresponda al componente horizontal del conector en el punto connector.Adjustments[0]:

```c++
// Dibuja el componente vertical del conector
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

El resultado:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Caso 2**

En **Caso 1**, demostramos una operación de ajuste de conector simple utilizando principios básicos. En situaciones normales, debes tener en cuenta la rotación del conector y su visualización (que están establecidas por connector.Rotation, connector.Frame.FlipH y connector.Frame.FlipV). Ahora demostraremos el proceso.

Primero, agreguemos un nuevo objeto de cuadro de texto (**Para 1**) a la diapositiva (con fines de conexión) y creemos un nuevo conector (verde) que lo conecte a los objetos que ya hemos creado.

```c++
// Crea un nuevo objeto de unión
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"Para 1");
// Crea un nuevo conector
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Conecta objetos usando el nuevo conector creado
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Obtiene los puntos de ajuste del conector
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Cambia los valores de los puntos de ajuste
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

El resultado:

![connector-adjusted-3](connector-adjusted-3.png)

En segundo lugar, vamos a crear una forma que corresponderá al componente horizontal del conector que pasa a través del nuevo punto de ajuste del conector connector.Adjustments[0]. Usaremos los valores de los datos del conector para connector.Rotation, connector.Frame.FlipH y connector.Frame.FlipV y aplicaremos la popular fórmula de conversión de coordenadas para rotación en torno a un punto dado x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

En nuestro caso, el ángulo de rotación del objeto es de 90 grados y el conector se muestra verticalmente, por lo que este es el código correspondiente:

```c++
// Tu código aquí
```

El resultado:

![connector-adjusted-4](connector-adjusted-4.png)

Demostramos cálculos que involucran ajustes simples y puntos de ajuste complicados (puntos de ajuste con ángulos de rotación). Utilizando el conocimiento adquirido, puedes desarrollar tu propio modelo (o escribir un código) para obtener un objeto `GraphicsPath` o incluso establecer los valores de los puntos de ajuste de un conector basados en coordenadas específicas de la diapositiva.

## **Encontrar el Ángulo de las Líneas del Conector**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Accede a la forma de línea del conector.
1. Usa el ancho de la línea, la altura, la altura del marco de la forma y el ancho del marco de la forma para calcular el ángulo.

Este código C++ demuestra una operación en la que calculamos el ángulo para una forma de línea del conector:

```c++
void ConnectorLineAngle()
{

	// La ruta al directorio de documentos.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Carga la presentación deseada
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Accede a la primera diapositiva
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// Accede a la colección de formas de las diapositivas
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
//	float endLineY = h * (flipV ? -1 : 1);
	float endYAxisX = 0;
	float endYAxisY = h;
	double angle = (Math::Atan2(endYAxisY, endYAxisX) - Math::Atan2(endLineY, endLineX));
	if (angle < 0) angle += 2 * Math::PI;
	return angle * 180.0 / Math::PI;
}
```