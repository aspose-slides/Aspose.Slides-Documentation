---
title: Tworzenie efektów 3D w prezentacjach przy użyciu C++
linktitle: Prezentacja 3D
type: docs
weight: 232
url: /pl/cpp/3d-presentation/
keywords:
- PowerPoint 3D
- prezentacja 3D
- obrót 3D
- głębia 3D
- ekstruzja 3D
- gradient 3D
- tekst 3D
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Zastosuj i renderuj efekty 3D dla kształtów i tekstu PowerPoint w C++ z Aspose.Slides. Skonfiguruj kamerę, oświetlenie, materiał, ekstruzję, wypełnienia i tekst 3D."
---
## **Przegląd**

Aspose.Slides dla C++ może tworzyć, edytować, zachowywać i renderować formatowanie 3D w stylu PowerPoint dla kształtów i tekstu. Ten artykuł opisuje efekty 3D takie jak obrót, ekstruzja, fazowanie, oświetlenie, materiał, wypełnienia gradientowe lub obrazkowe oraz tekst 3D.

{{% alert color="info" title="Note" %}}
Ten artykuł dotyczy efektów formatowania 3D na kształtach i tekście w programie PowerPoint. Nie dotyczy wstawiania ani edytowania samodzielnych plików modeli 3D. Gdy eksportujesz slajd do obrazu, PDF lub HTML, Aspose.Slides renderuje te efekty 3D w wyeksportowanym wyjściu 2D.
{{% /alert %}}

## **Koncepcje formatowania 3D**

Użyj metody [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) aby zastosować formatowanie 3D do kształtu. Metoda zwraca [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/), który kontroluje scenę 3D dla tego kształtu.

Dla tekstu użyj metody [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) . To stosuje formatowanie 3D do ramki tekstowej zamiast do korpusu kształtu.

Najważniejsze metody to:

| Metoda | Co kontroluje | Kiedy używać |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) | Punkt widzenia, wstępnie ustawiony typ kamery, obrót, zoom i perspektywa. | Obróć obiekt w przestrzeni 3D lub dopasuj do wstępnego ustawienia obrotu 3D w PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_lightrig/) | Wstępne ustawienie światła, kierunek i obrót światła. | Zmień sposób, w jaki podświetlenia i cienie pojawiają się na powierzchni 3D. |
| [set_Material](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_material/) | Materiał powierzchni, np. płaski, matowy, plastikowy lub metalowy. | Spraw, aby ta sama geometria wyglądała płasko, miękko, błyszcząco lub metalicznie. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Jak daleko kształt wyciąga się w tył od swojej przedniej powierzchni. | Przekształć płaski kształt w widocznie gruby obiekt 3D. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Kolor wyciągniętych boków. | Uczyń głębokość widoczną lub dopasuj kolor boków do wypełnienia przedniej strony. |
| [set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) | Dodatkowa głębokość 3D używana w formatowaniu 3D PowerPoint. | Dostosuj precyzyjnie głębokość dla kształtów lub tekstu, zwłaszcza w połączeniu z ustawieniami fazowania i materiału. |
| [get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) and [get_BevelBottom](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Uniesione lub zaokrąglone krawędzie na przedniej i tylnej powierzchni. | Dodaj zmiękczoną lub formowaną krawędź zamiast ostrej płaskiej powierzchni. |
| [get_ContourColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_contourcolor/) and [set_ContourWidth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Obrys wokół obiektu 3D. | Podkreśl granicę obiektu w renderowanym wyniku. |

## **Utworzenie kształtu 3D**

Kształt zwykle potrzebuje czterech rodzajów ustawień, zanim będzie wyglądał przekonująco 3D:

- Ustawienia kamery, ponieważ domyślny widok przedni może ukrywać ekstruzję.
- Ustawienia światła, ponieważ oświetlenie sprawia, że powierzchnie i boki są czytelne.
- Ustawienia materiału, ponieważ powierzchnia wpływa na sposób renderowania światła.
- Ustawienia ekstruzji lub głębokości, ponieważ płaski kształt potrzebuje grubości.

Następny przykład tworzy prostokąt, dodaje tekst na jego przedniej powierzchni i stosuje formatowanie 3D. Wartości obrotu kamery podane są w stopniach, a wysokość ekstruzji wynosi 100 punktów. Przykład renderuje slajd do obrazu PNG w dwukrotnie większych niż domyślne wymiary i zapisuje prezentację jako PPTX.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Renderowany obraz slajdu pokazuje prostokąt jako gruby blok 3D:

![Renderowany niebieski prostokąt 3D z białym tekstem 3D na przedniej powierzchni](img_01_01.png)

## **Obrócenie kształtu za pomocą kamery**

W programie PowerPoint obrót 3D konfiguruje się w panelu Obrót 3-D. Wartości obrotu X, Y i Z odpowiadają obrotowi ustawionemu za pomocą API kamery.

![Panel Obrót 3-D w PowerPoint z podświetlonymi wartościami obrotu X, Y i Z](img_02_01.png)

W Aspose.Slides dostęp do kamery uzyskuje się przez [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/). Ten przykład tworzy prostokąt, wybiera ortograficzny widok przedni i ustawia obroty X, Y i Z na 20, 30 i 40 stopni odpowiednio. Konfiguruje kształt w pamięci bez zapisywania pliku:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);

presentation->Dispose();
```

Użyj kamery, gdy musisz zmienić sposób, w jaki obserwator widzi obiekt. Nie zmienia to geometrii kształtu 2D na slajdzie. Zmienia to punkt widzenia 3D używany przez PowerPoint i przez Aspose.Slides przy renderowaniu.

### **Skopiowanie orientacji kamery z kształtu szablonu**

Aby dopasować orientację kamery kształtu szablonu, odczytaj jego preset za pomocą [get_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/get_cameratype/) i zastosuj go za pomocą [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/). Przykład otwiera `template.pptx` i kopiuje orientację kamery z pierwszego kształtu na pierwszym slajdzie do drugiego kształtu. Oba kształty mają już oświetlenie 3D, a drugi kształt nie ma explicite ustawionego obrotu kamery.

[GetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/getrotation/) zwraca kąty w stopniach. Indeks `0` to szerokość, indeks `1` to długość, a indeks `2` to obrót. Przekaż kąty do [SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) w tej kolejności. Jeśli źródło nie ma wyraźnego obrotu, `GetRotation` zwraca wskaźnik null, więc pozostaw kąty drugiego kształtu nieustawione. Wyraźny obrót `(0, 0, 0)` zwraca tablicę trzech zer i powinien zostać skopiowany.

```cpp
#include <DOM/ICamera.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

auto sourceCamera = slide->get_Shape(0)->get_ThreeDFormat()->get_Camera();
auto destinationCamera = slide->get_Shape(1)->get_ThreeDFormat()->get_Camera();

destinationCamera->set_CameraType(sourceCamera->get_CameraType());
auto angles = sourceCamera->GetRotation();
if (angles != nullptr)
{
    destinationCamera->SetRotation(angles[0], angles[1], angles[2]);
}

presentation->Save(u"camera-copy.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kiedy ponownie otworzysz `camera-copy.pptx` w programie PowerPoint, strzałka po prawej ma taki sam preset kamery i obrót jak prostokąt po lewej. Oba kształty używają tego samego oświetlenia i głębokości ekstruzji.

![Niebieski prostokąt 3D i strzałka w prawo z dopasowaną orientacją kamery, widziane z góry i z prawej strony](camera-orientation.png)

## **Dodanie ekstruzji i głębokości**

Ekstruzja sprawia, że kształt wygląda na gruby poprzez wydłużenie go za przednią powierzchnią. W PowerPoint kontrolka głębokości ustawia tę widoczną grubość, a kontrolka koloru ustawia kolor boków.

![Kontrolki głębokości w PowerPoint powiązane z właściwościami koloru ekstruzji i wysokości ekstruzji](img_02_02.png)

Ustaw [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) dla grubości i [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) dla koloru boków. Ten przykład nadaje prostokątowi ekstruzję 100 punktów z fioletowymi bokami i obraca kamerę, aby ukazać jego grubość. Konfiguruje kształt w pamięci bez zapisywania pliku:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

Metoda [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) ustawia głębokość kształtu 3D. Metoda [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) kontroluje wysokość efektu ekstruzji, jak pokazano w tym przykładzie.

## **Użycie wypełnie gradientowych lub obrazkowych z efektami 3D**

Formatowanie 3D jest niezależne od wypełnienia kształtu. Możesz zastosować jednolity kolor, gradient, wzór lub wypełnienie obrazkiem na przedniej powierzchni i nadal używać tych samych ustawień kamery, światła, materiału i ekstruzji.

Ten przykład stosuje gradient od niebieskiego do pomarańczowego na przedniej powierzchni oraz ciemnopomarańczowy kolor dla ekstruzji o wysokości 150 punktów. Punkty gradientu 0 i 100 oznaczają początek i koniec gradientu. Wartości obrotu kamery podane są w stopniach. Slajd renderowany jest do obrazu PNG w dwukrotnie większych niż domyślne wymiary:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

Renderowany wynik zachowuje gradient na przedniej powierzchni i renderuje ekstruzję osobno:

![Renderowany prostokąt 3D z gradientowym wypełnieniem od niebieskiego do pomarańczowego i pomarańczową ekstruzją](img_02_03.png)

Aby użyć wypełnienia obrazkiem, dodaj obraz do prezentacji i przypisz go jako wypełnienie kształtu. Ten przykład wymaga istniejącego pliku o nazwie "image.jpg" w katalogu roboczym. Rozciąga obraz, aby wypełnić prostokąt, stosuje ekstruzję 150 punktów i ustawia obrót kamery w stopniach. Konfiguruje kształt w pamięci bez zapisywania lub renderowania pliku:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

Obraz jest renderowany na przedniej powierzchni, podczas gdy ekstruzja jest renderowana jako 3D powierzchnia boczna:

![Renderowany prostokąt 3D z wypełnieniem zdjęciem na przedniej powierzchni i pomarańczową ekstruzją](img_02_04.png)

## **Zastosowanie formatowania 3D do tekstu**

Formatowanie 3D kształtu wpływa na korpus kształtu. Formatowanie 3D tekstu wpływa na ramkę tekstową. Jest to przydatne w efektach podobnych do WordArt, gdzie same litery wymagają ekstruzji, materiału, oświetlenia i ustawień kamery.

Poniższy przykład tworzy tekst z pomarańczowo-białym wzorem siatki, stosuje łuk skierowany w górę i konfiguruje ustawienia 3D poprzez [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/). Wysokość ekstruzji i głębokość podane są w punktach, a obrót światła w stopniach. Wypełnienie i obrys kształtu są ukryte, aby widoczny był tylko tekst. Przykład renderuje obraz PNG w dwukrotnie większych niż domyślne wymiary slajdu i zapisuje prezentację jako PPTX:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Tekst renderowany jest jako zakrzywione, wyciągnięte litery 3D:

![Renderowany tekst 3D z wygiętym przekształceniem WordArt, pomarańczowym wypełnieniem wzorem i ciemną ekstruzją](img_02_05.png)

## **Utrzymanie tekstu płaskiego na kształcie 3D**

Aby utrzymać czytelność tekstu przy zachowaniu wyglądu 3D kształtu, wywołaj [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_keeptextflat/) przez [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_textframeformat/). Gdy wartość jest `true`, tekst pozostaje poza sceną 3D. Gdy jest `false`, tekst uczestniczy w scenie i podąża za jej orientacją 3D.

To ustawienie nie usuwa formatowania 3D kształtu: jego kamera, oświetlenie, materiał i ekstruzja pozostają skonfigurowane poprzez [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/). Jest to także inne niż zwykły obrót. [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) obraca kształt w płaszczyźnie slajdu, natomiast [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) kontroluje własny obrót tekstu w jego ramce. Utrzymanie tekstu poza sceną 3D nie resetuje żadnego z tych kątów.

Poniższy samodzielny przykład tworzy niebieski prostokąt z tekstem i klonuje go obok oryginału. Oba kształty mają to samo formatowanie 3D; jedynie ustawienie tekstu różni się: `false` po lewej i `true` po prawej. Kąty kamery podane są w stopniach, a wysokość ekstruzji wynosi 40 punktów. Przykład zapisuje prezentację jako PPTX i renderuje slajd porównawczy do PNG w dwukrotnie większych niż domyślne wymiary.

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

Po lewej tekst podąża za orientacją 3D. Po prawej pozostaje płaski i łatwiejszy do odczytania. Oba prostokąty zachowują tę samą widoczną ekstruzję i orientację 3D.

![Prostokąty 3D obok siebie: KeepTextFlat jest false po lewej i true po prawej](keep_text_flat.png)

## **Zachowanie eksportu i renderowania**

Aspose.Slides zachowuje formatowanie 3D przy zapisywaniu do formatów PowerPoint, takich jak PPTX. Podczas renderowania lub eksportu do formatów o stałym układzie, scena 3D jest rastrowana lub rysowana w wyjściu jako wynik 2D. Dotyczy to renderowania slajdów do [PNG](/slides/pl/cpp/convert-powerpoint-to-png/), eksportu do [PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/), eksportu do [HTML](/slides/pl/cpp/convert-powerpoint-to-html/), lub generowania klatek do [video conversion](/slides/pl/cpp/convert-powerpoint-to-video/).

- Wyeksportowane obrazy i PDF nie są interaktywne. Obiekt nie może być obracany przez użytkownika po eksporcie.
- Ostateczny wygląd zależy od kombinacji kamery, zestawu świateł, materiału, ekstruzji, wypełnienia i skalowania slajdu.
- Jeśli potrzebujesz sprawdzić dziedziczone lub oparte na motywie wartości formatowania, przeczytaj [efektywne właściwości kształtu](/slides/pl/cpp/shape-effective-properties/).
- Niektóre formaty wyjściowe nie mogą przechowywać edytowalnego formatowania 3D PowerPoint. W tych formatach wynik wizualny jest renderowany, a nie zachowywany jako edytowalne ustawienia 3D.

## **FAQ**

**Czy Aspose.Slides może tworzyć interaktywne prezentacje 3D?**

Aspose.Slides tworzy i renderuje efekty 3D PowerPoint dla kształtów i tekstu. Nie tworzy interaktywnych scen 3D w wyeksportowanych obrazach, PDF-ach ani stronach HTML, które użytkownik mógłby obracać. W formacie PPTX formatowanie 3D pozostaje edytowalne w PowerPoint, jeśli format to umożliwia.

**Jaka jest różnica między modelem 3D a efektem 3D?**

Model 3D to osobny obiekt 3D wstawiany do prezentacji. Efekt 3D to formatowanie zastosowane do zwykłego kształtu lub tekstu PowerPoint, takie jak obrót, ekstruzja, fazowanie, oświetlenie i materiał. Ten artykuł opisuje efekty 3D.

**Jakie ustawienia są wymagane, aby kształt 3D był widoczny?**

Co najmniej, ustaw obrót kamery oraz ekstruzję lub głębokość. W praktyce ustaw także zestaw świateł i materiał, aby renderowane powierzchnie miały wyraźne podświetlenia i cienie.

**Czy mogę zastosować efekty 3D zarówno do kształtów, jak i do tekstu?**

Tak. Użyj [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) dla korpusu kształtu i [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) dla tekstu.

**Czy efekty 3D będą widoczne przy eksporcie do obrazów, PDF, HTML lub klatek wideo?**

Tak. Aspose.Slides renderuje efekty 3D przy tworzeniu obrazów slajdów, wyjścia PDF, wyjścia HTML oraz klatek używanych przy konwersji wideo. Wyeksportowany wynik zawiera renderowany wygląd, a nie edytowalny obiekt 3D.

**Czy mogę odczytać końcowe wartości 3D po zastosowaniu dziedziczenia i ustawień motywu?**

Tak. Użyj API formatowania opisanych w [Shape Effective Properties](/slides/pl/cpp/shape-effective-properties/), aby odczytać ostateczne wartości kamery, zestawu świateł, fazowania i powiązane wartości 3D.