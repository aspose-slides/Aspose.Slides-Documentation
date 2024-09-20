---
title: Коннектор
type: docs
weight: 10
url: /cpp/connector/
keywords: "Соединять формы, коннекторы, формы PowerPoint, презентация PowerPoint, C++, CPP, Aspose.Slides для C++"
description: "Соединение форм PowerPoint на C++"
---

Коннектор PowerPoint — это специальная линия, которая соединяет или связывает две формы и остается прикрепленной к формам, даже когда они перемещаются или изменяются на слайде.

Коннекторы обычно соединены с *точками соединения* (зелеными точками), которые по умолчанию присутствуют на всех формах. Точки соединения появляются, когда курсор приближается к ним.

*Точки коррекции* (оранжевые точки), которые существуют только на определенных коннекторах, используются для изменения позиций и форм коннекторов.

## **Типы Коннекторов**

В PowerPoint вы можете использовать прямые, локтевые (угловые) и изогнутые коннекторы.

Aspose.Slides предоставляет следующие коннекторы:

| Коннектор                      | Изображение                                                    | Количество точек коррекции |
| ------------------------------ | -------------------------------------------------------------- | --------------------------- |
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

## **Соединение форм с помощью коннекторов**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) на слайд с помощью метода `AddAutoShape`, предоставленного объектом `Shapes`.
1. Добавьте коннектор с помощью метода `AddConnector`, предоставленного объектом `Shapes`, указав тип коннектора.
1. Соедините формы с помощью коннектора.
1. Вызовите метод `Reroute`, чтобы применить кратчайший путь соединения.
1. Сохраните презентацию.

Этот код на C++ показывает, как добавить коннектор (изогнутый коннектор) между двумя формами (эллипс и прямоугольник):

```c++
// Путь к каталогу документов.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Загружает нужную презентацию
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Получает доступ к первому слайду
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Получает доступ к коллекции форм для определенного слайда
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Добавляет эллипс
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Добавляет прямоугольник
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Добавляет коннектор к коллеции форм слайда
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Соединяет формы с помощью коннектора
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// Вызывает reroute, который устанавливает автоматический кратчайший путь между формами
	connector->Reroute();

	// Сохраняет презентацию
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Метод `connector->Reroute` перенаправляет коннектор и заставляет его занять кратчайший возможный путь между формами. Для достижения своей цели метод может изменить точки `StartShapeConnectionSiteIndex` и `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Указать точку соединения**

Если вы хотите, чтобы коннектор связывал две формы с помощью конкретных точек на формах, вы должны указать свои предпочтительные точки соединения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape) на слайд с помощью метода `AddAutoShape`, предоставленного объектом `Shapes`.
1. Добавьте коннектор с помощью метода `AddConnector`, предоставленного объектом `Shapes`, указав тип коннектора.
1. Соедините формы с помощью коннектора.
1. Установите ваши предпочтительные точки соединения на формах.
1. Сохраните презентацию.

Этот код на C++ демонстрирует операцию, где указана предпочтительная точка соединения:

```c++
// Путь к каталогу документов.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Загружает нужную презентацию
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Получает доступ к первому слайду
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Получает доступ к коллекции форм для определенного слайда
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Добавляет эллипс
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Добавляет прямоугольник
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Добавляет коннектор к коллекции форм слайда
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Соединяет формы с помощью коннектора
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);

	// Устанавливает индекс предпочтительной точки соединения на эллипсе
	int wantedIndex = 6;

	// Проверяет, меньше ли предпочтительный индекс максимального количества индексов соединений
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Устанавливает предпочтительную точку соединения на эллипсе
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// Сохраняет презентацию
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Регулировка точки коннектора**

Вы можете регулировать существующий коннектор через его точки коррекции. Только коннекторы с точками коррекции могут быть изменены таким образом. См. таблицу под **[Типы коннекторов.](/slides/cpp/connector/#types-of-connectors)** 

#### **Простой случай**

Рассмотрим случай, когда коннектор между двумя формами (A и B) проходит через третью форму (C):

![connector-obstruction](connector-obstruction.png)

Код:

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

Чтобы избежать или обойти третью форму, мы можем отрегулировать коннектор, переместив его вертикальную линию влево следующим образом:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **Сложные случаи** 

Для выполнения более сложных настроек вы должны учитывать следующие моменты:

* Регулируемая точка коннектора тесно связана с формулой, которая вычисляет и определяет ее местоположение. Поэтому изменения в расположении точки могут изменить форму коннектора.
* Точки коррекции коннектора определены в строгом порядке в массиве. Точки коррекции нумеруются от стартовой точки коннектора до его конечной.
* Значения точек коррекции отражают процент ширины/высоты формы коннектора. 
  * Форма ограничена стартовой и конечной точками коннектора, умноженными на 1000. 
  * Первая точка, вторая точка и третья точка определяют процент от ширины, процент от высоты и процент от ширины (снова) соответственно.
* Для расчетов, которые определяют координаты точек коррекции у коннектора, необходимо учитывать вращение коннектора и его отражение. **Примечание**: угол вращения для всех коннекторов, показанных в разделе **[Типы коннекторов](/slides/cpp/connector/#types-of-connectors)**, равен 0.

#### **Случай 1**

Рассмотрим случай, когда два объекта текстового фрейма связаны друг с другом через коннектор:

![connector-shape-complex](connector-shape-complex.png)

Код:

```c++
// Инстанцирует класс презентации, который представляет файл PPTX
auto pres = System::MakeObject<Presentation>();
// Получает первый слайд в презентации
auto slide = pres->get_Slides()->idx_get(0);
// Получает формы с первого слайда
auto shapes = slide->get_Shapes();
// Добавляет формы, которые будут соединены через коннектор
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"От");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"К");
// Добавляет коннектор
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Указывает направление коннектора
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Указывает толщину линии коннектора
lineFormat->set_Width(3);
// Указывает цвет коннектора
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Соединяет формы с помощью коннектора
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Получает точки коррекции для коннектора
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**Коррекция**

Мы можем изменить значения точек коррекции коннектора, увеличив соответствующие ширину и высоту на 20% и 200% соответственно:

```c++
// Изменяет значения точек коррекции
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Результат:

![connector-adjusted-1](connector-adjusted-1.png)

Чтобы определить модель, позволяющую определять координаты и форму отдельных частей коннектора, давайте создадим форму, которая соответствует горизонтальному компоненту коннектора в точке connector.Adjustments[0]:

```c++
// Рисует вертикальный компонент коннектора
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

Результат:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую операцию настройки коннектора, используя базовые принципы. В обычных ситуациях вам нужно учитывать вращение и отображение коннектора (которые задаются через connector.Rotation, connector.Frame.FlipH и connector.Frame.FlipV). Теперь мы продемонстрируем этот процесс.

Сначала давайте добавим новый объект текстового фрейма (**К**) на слайд (для соединения) и создадим новый (зеленый) коннектор, который соединит его с уже созданными объектами.

```c++
// Создает новый объект связывания
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"К 1");
// Создает новый коннектор
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Соединяет объекты с помощью вновь созданного коннектора
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Получает точки коррекции коннектора
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Изменяет значения точек коррекции
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Результат:

![connector-adjusted-3](connector-adjusted-3.png)

Во-вторых, давайте создадим форму, которая будет соответствовать горизонтальному компоненту коннектора, проходящему через новую точку коррекции коннектора connector.Adjustments[0]. Мы будем использовать значения из данных о коннекторе для connector.Rotation, connector.Frame.FlipH и connector.Frame.FlipV и применим популярную формулу преобразования координат для вращения вокруг заданной точки x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

В нашем случае угол вращения объекта составляет 90 градусов, и коннектор отображается вертикально, поэтому вот соответствующий код:

```c++

```

Результат:

![connector-adjusted-4](connector-adjusted-4.png)

Мы продемонстрировали расчеты, связанные с простыми настройками и сложными точками коррекции (точками коррекции с углами вращения). Используя приобретенные знания, вы можете разработать свою модель (или написать код), чтобы получить объект `GraphicsPath` или даже установить значения точек коррекции коннектора на основе конкретных координат слайда.

## **Нахождение угла линий коннектора**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к форме линии коннектора.
1. Используйте ширину линии, высоту, высоту рамки формы и ширину рамки формы для вычисления угла.

Этот код на C++ демонстрирует операцию, в которой мы рассчитали угол для формы линии коннектора:

```c++
void ConnectorLineAngle()
{

	// Путь к каталогу документов.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Загружает желаемую презентацию
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Получает доступ к первому слайду
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// Получает доступ к коллекции форм слайдов
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