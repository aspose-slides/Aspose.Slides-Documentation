---
title: Zarządzanie łącznikami w prezentacjach przy użyciu C++
linktitle: Łącznik
type: docs
weight: 10
url: /pl/cpp/connector/
keywords:
- łącznik
- typ łącznika
- punkt łącznika
- linia łącznika
- kąt łącznika
- łączenie kształtów
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Umożliw aplikacjom C++ rysowanie, łączenie i automatyczne trasowanie linii w slajdach PowerPoint — uzyskaj pełną kontrolę nad prostymi, łokciowymi i krzywymi łącznikami."
---
## **Wprowadzenie**

Łącznik PowerPoint to specjalna linia, która łączy dwa kształty i pozostaje przyczepiona do kształtów, nawet gdy są one przesuwane lub przestawiane na danym slajdzie.  

Łączniki są zazwyczaj podłączane do *punktów połączenia* (zielonych kropek), które standardowo występują na wszystkich kształtach. Punkty połączenia pojawiają się, gdy kursor zbliży się do nich.  

*Punkty dopasowania* (pomarańczowe kropki), które występują tylko w niektórych łącznikach, służą do modyfikacji położenia i kształtu łączników.  

## **Typy łączników**

W programie PowerPoint można używać łączników prostych, łokciowych (kątowych) i krzywych.  

Aspose.Slides udostępnia następujące łączniki:

| Łącznik | Obraz | Liczba punktów dopasowania |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **Łączenie kształtów przy użyciu łączników**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation/) .
1. Uzyskaj odwołanie do slajdu poprzez jego indeks.
1. Dodaj dwa [AutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.auto_shape) do slajdu przy użyciu metody `AddAutoShape` udostępnionej przez obiekt `Shapes`.
1. Dodaj łącznik przy użyciu metody `AddConnector` udostępnionej przez obiekt `Shapes`, określając typ łącznika.
1. Połącz kształty przy użyciu łącznika. 
1. Wywołaj metodę `Reroute`, aby zastosować najkrótszą ścieżkę połączenia.
1. Zapisz prezentację. 

Ten kod C++ pokazuje, jak dodać łącznik (zgięty łącznik) między dwoma kształtami (elipsą i prostokątem):

```c++
	// Ścieżka do katalogu dokumentów.
	const String outPath = u"../out/ConnectShapesUsingConnectors_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Ładuje żądaną prezentację
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Uzyskuje dostęp do pierwszego slajdu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Uzyskuje dostęp do kolekcji kształtów dla określonego slajdu
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Dodaje automatyczny kształt elipsy
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Dodaje automatyczny kształt prostokąta
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);

	// Dodaje kształt łącznika do kolekcji kształtów slajdu
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

	// Łączy kształty przy użyciu łącznika
	connector->set_StartShapeConnectedTo ( ellipse);
	connector->set_EndShapeConnectedTo (rect);

	// Wywołuje Reroute, który ustawia automatyczną najkrótszą ścieżkę między kształtami
	connector->Reroute();
	
	// Zapisuje prezentację
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 

Metoda `connector->Reroute` przerysowuje łącznik i wymusza przyjęcie najkrótszej możliwej ścieżki pomiędzy kształtami. Aby osiągnąć ten cel, metoda może zmienić punkty `StartShapeConnectionSiteIndex` i `EndShapeConnectionSiteIndex`. 

{{% /alert %}} 

## **Określenie punktu połączenia**

Jeśli chcesz, aby łącznik połączył dwa kształty przy użyciu określonych punktów na kształtach, musisz określić preferowane punkty połączenia w następujący sposób:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation/) .
1. Uzyskaj odwołanie do slajdu poprzez jego indeks.
1. Dodaj dwa [AutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.auto_shape) do slajdu przy użyciu metody `AddAutoShape` udostępnionej przez obiekt `Shapes`.
1. Dodaj łącznik przy użyciu metody `AddConnector` udostępnionej przez obiekt `Shapes`, określając typ łącznika.
1. Połącz kształty przy użyciu łącznika. 
1. Ustaw preferowane punkty połączenia na kształtach. 
1. Zapisz prezentację.

Ten kod C++ demonstruje operację, w której określono preferowany punkt połączenia:

```c++
	// Ścieżka do katalogu dokumentów.
	const String outPath = u"../out/ConnectShapeUsingConnectionSite_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Ładuje żądaną prezentację
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Uzyskuje dostęp do pierwszego slajdu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Uzyskuje dostęp do kolekcji kształtów dla określonego slajdu
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Dodaje automatyczny kształt elipsy
	SharedPtr<IAutoShape> ellipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);

	// Dodaje automatyczny kształt prostokąta
	SharedPtr<IAutoShape> rect = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);

	// Dodaje kształt łącznika do kolekcji kształtów slajdu
	SharedPtr<IConnector> connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

	// Łączy kształty przy użyciu łącznika
	connector->set_StartShapeConnectedTo(ellipse);
	connector->set_EndShapeConnectedTo(rect);


	// Ustawia indeks preferowanego punktu połączenia na kształcie elipsy
	int wantedIndex = 6;

	// Sprawdza, czy preferowany indeks jest mniejszy niż maksymalna liczba punktów połączenia
	if (ellipse->get_ConnectionSiteCount() > wantedIndex)
	{
		// Ustawia preferowany punkt połączenia na automatycznym kształcie elipsy
		connector->set_StartShapeConnectionSiteIndex ( wantedIndex);
	}

	// Zapisuje prezentację
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Dostosowanie punktu łącznika**

Możesz dostosować istniejący łącznik poprzez jego punkty dopasowania. Tylko łączniki posiadające punkty dopasowania mogą być w ten sposób modyfikowane. Zobacz tabelę pod **[Types of connectors.](/slides/pl/cpp/connector/#types-of-connectors)** 

### **Przypadek prosty**

Rozważ sytuację, w której łącznik między dwoma kształtami (A i B) przechodzi przez trzeci kształt (C):

![przeszkoda-łącznika](connector-obstruction.png)

Kod:

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

Aby uniknąć lub ominąć trzeci kształt, możemy dostosować łącznik, przesuwając jego pionową linię w lewo w następujący sposób:

![przeszkoda-łącznika-naprawiona](connector-obstruction-fixed.png)

```c++
auto adj2 = connector->get_Adjustments()->idx_get(1);
adj2->set_RawValue(adj2->get_RawValue() + 10000);
```

### **Przypadki złożone** 

Aby wykonać bardziej skomplikowane regulacje, musisz wziąć pod uwagę następujące kwestie:

* Punkt regulacji łącznika jest ściśle powiązany z formułą, która oblicza i określa jego położenie. Dlatego zmiany położenia punktu mogą zmienić kształt łącznika.  
* Punkty dopasowania łącznika są definiowane w ścisłej kolejności w tablicy. Są numerowane od punktu początkowego łącznika do punktu końcowego.  
* Wartości punktów dopasowania odzwierciedlają procent szerokości/wysokości kształtu łącznika.  
  * Kształt jest ograniczony przez punkty początkowy i końcowy łącznika pomnożone przez 1000.  
  * Pierwszy, drugi i trzeci punkt określają odpowiednio procent szerokości, procent wysokości oraz ponownie procent szerokości.  
* Do obliczeń wyznaczających współrzędne punktów dopasowania łącznika musisz uwzględnić obrót łącznika oraz jego odbicie. **Note** że kąt obrotu dla wszystkich łączników pokazanych pod **[Types of connectors](/slides/pl/cpp/connector/#types-of-connectors)** wynosi 0.  

#### **Przypadek 1**

Rozważ sytuację, w której dwa obiekty ramki tekstowej są połączone łącznikiem:

![łącznik-kształt-złożony](connector-shape-complex.png)

Kod:

```c++
// Tworzy instancję klasy prezentacji, która reprezentuje plik PPTX
auto pres = System::MakeObject<Presentation>();
// Pobiera pierwszy slajd w prezentacji
auto slide = pres->get_Slides()->idx_get(0);
// Pobiera kształty z pierwszego slajdu
auto shapes = slide->get_Shapes();
// Dodaje kształty, które zostaną połączone za pomocą łącznika
auto shapeFrom = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 60.0f, 25.0f);
shapeFrom->get_TextFrame()->set_Text(u"From");
auto shapeTo = shapes->AddAutoShape(ShapeType::Rectangle, 500.0f, 100.0f, 60.0f, 25.0f);
shapeTo->get_TextFrame()->set_Text(u"To");
// Dodaje łącznik
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
auto lineFormat = connector->get_LineFormat();
// Określa kierunek łącznika
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
// Określa grubość linii łącznika
lineFormat->set_Width(3);
// Określa kolor łącznika
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Crimson());

// Łączy kształty razem przy użyciu łącznika
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(shapeTo);
connector->set_EndShapeConnectionSiteIndex(2);

// Pobiera punkty dopasowania dla łącznika
auto adjustments = connector->get_Adjustments();
auto adjValue_0 = adjustments->idx_get(0);
auto adjValue_1 = adjustments->idx_get(1);
```

**Dopasowanie**

Możemy zmienić wartości punktów dopasowania łącznika, zwiększając odpowiadające procenty szerokości i wysokości o 20 % i 200 % odpowiednio:

```c++
// Zmienia wartości punktów dopasowania
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Wynik:

![łączenie-ustawione-1](connector-adjusted-1.png)

Aby zdefiniować model umożliwiający określenie współrzędnych i kształtu poszczególnych części łącznika, utwórzmy kształt odpowiadający poziomej składnikowi łącznika w punkcie `connector.Adjustments[0]`:

```c++
// Rysuje pionowy komponent łącznika
float x = connector->get_X() + connector->get_Width() * adjValue_0->get_RawValue() / 100000;
float y = connector->get_Y();
float height = connector->get_Height() * adjValue_1->get_RawValue() / 100000;
shapes->AddAutoShape(ShapeType::Rectangle, x, y, 0.0f, height);
```

Wynik:

![łączenie-ustawione-2](connector-adjusted-2.png)

#### **Przypadek 2**

W **Przypadku 1** zademonstrowaliśmy prostą operację regulacji łącznika przy użyciu podstawowych zasad. W normalnych sytuacjach musisz uwzględnić obrót łącznika oraz jego wyświetlanie (ustawiane przez `connector.Rotation`, `connector.Frame.FlipH` i `connector.Frame.FlipV`). Poniżej przedstawiamy proces.

Najpierw dodajmy nowy obiekt ramki tekstowej (**To 1**) do slajdu (w celu połączenia) i utwórzmy nowy (zielony) łącznik, który połączy go z już istniejącymi obiektami.

```c++
// Tworzy nowy obiekt wiązania
auto shapeTo_1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 400.0f, 60.0f, 25.0f);
shapeTo_1->get_TextFrame()->set_Text(u"To 1");
// Tworzy nowy łącznik
connector = shapes->AddConnector(ShapeType::BentConnector4, 20.0f, 20.0f, 400.0f, 300.0f);
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
lineFormat->set_Width(3);
lineFillFormat->set_FillType(Aspose::Slides::FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_MediumAquamarine());
// Łączy obiekty przy użyciu nowo utworzonego łącznika
connector->set_StartShapeConnectedTo(shapeFrom);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(shapeTo_1);
connector->set_EndShapeConnectionSiteIndex(3);
// Pobiera punkty dopasowania łącznika
adjValue_0 = adjustments->idx_get(0);
adjValue_1 = adjustments->idx_get(1);
// Zmienia wartości punktów dopasowania
adjValue_0->set_RawValue(adjValue_0->get_RawValue() + 20000);
adjValue_1->set_RawValue(adjValue_1->get_RawValue() + 200000);
```

Wynik:

![łączenie-ustawione-3](connector-adjusted-3.png)

Następnie utwórzmy kształt odpowiadający poziomej składnikowi łącznika, który przechodzi przez nowy punkt regulacji `connector.Adjustments[0]`. Użyjemy wartości z danych łącznika dla `connector.Rotation`, `connector.Frame.FlipH` i `connector.Frame.FlipV` oraz zastosujemy popularną formułę przekształcania współrzędnych dla obrotu wokół punktu x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

W naszym przypadku kąt obrotu obiektu wynosi 90 stopni, a łącznik jest wyświetlany pionowo, więc kod wygląda następująco:

```c++

```

Wynik:

![łączenie-ustawione-4](connector-adjusted-4.png)

Zademonstrowaliśmy obliczenia obejmujące proste regulacje oraz skomplikowane punkty dopasowania (punkty z kątami obrotu). Korzystając z nabytej wiedzy, możesz opracować własny model (lub napisać kod) umożliwiający uzyskanie obiektu `GraphicsPath` lub nawet ustawienie wartości punktów dopasowania łącznika na podstawie konkretnych współrzędnych slajdu. 

## **Znajdowanie kąta linii łącznika**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation/) .
1. Uzyskaj odwołanie do slajdu poprzez jego indeks.
1. Uzyskaj dostęp do kształtu linii łącznika.
1. Użyj szerokości, wysokości, wysokości ramki kształtu i szerokości ramki kształtu, aby obliczyć kąt.

Ten kod C++ demonstruje operację, w której obliczyliśmy kąt linii łącznika:

```c++
void ConnectorLineAngle()
{

	// Ścieżka do katalogu dokumentów.
	const String outPath = u"../out/ConnectorLineAngle_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Ładuje żądaną prezentację
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Uzyskuje dostęp do pierwszego slajdu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	for (int i = 0; i < slide->get_Shapes()->get_Count(); i++)
	{
		double dir = 0.0;
		// Uzyskuje dostęp do kolekcji kształtów slajdu
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

**Jak mogę sprawdzić, czy łącznik może być „przyklejony” do konkretnego kształtu?**  

Sprawdź, czy kształt udostępnia [connection sites](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/get_connectionsitecount/). Jeśli nie ma żadnych lub liczba wynosi zero, przyklejanie nie jest dostępne; w takim wypadku użyj wolnych końcówek i ustaw je ręcznie. Warto sprawdzić liczbę miejsc przed dołączeniem.

**Co się stanie z łącznikiem, jeśli usunę jeden z połączonych kształtów?**  

Jego końce zostaną odłączone; łącznik pozostaje na slajdzie jako zwykła linia z wolnym początkiem i końcem. Możesz go usunąć lub ponownie przydzielić połączenia i w razie potrzeby [reroute](https://reference.aspose.com/slides/pl/cpp/aspose.slides/connector/reroute/).

**Czy powiązania łączników są zachowywane przy kopiowaniu slajdu do innej prezentacji?**  

Zasadniczo tak, pod warunkiem że kopiowane są również docelowe kształty. Jeśli slajd zostanie wstawiony do innego pliku bez połączonych kształtów, końce staną się wolne i będzie trzeba je ponownie podłączyć.