---
title: Zarządzaj obiektami tuszu w prezentacji w C++
linktitle: Zarządzaj tuszem
type: docs
weight: 95
url: /pl/cpp/manage-ink/
keywords:
- tusz
- obiekt tuszu
- ślad tuszu
- zarządzaj tuszem
- rysuj tusz
- rysowanie
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj obiektami tuszu PowerPoint — twórz, edytuj i stylizuj cyfrowy tusz przy użyciu Aspose.Slides dla C++. Pobierz przykłady kodu dla śladów, koloru i rozmiaru pędzla."
---
## **Wprowadzenie**

PowerPoint udostępnia funkcję tuszu, pozwalającą rysować niestandardowe kształty, które mogą być używane do podkreślania innych obiektów, pokazywania połączeń i procesów oraz zwracania uwagi na konkretne elementy na slajdzie. 

Aspose.Slides udostępnia interfejs [Aspose.Slides.Ink](https://reference.aspose.com/slides/pl/cpp/aspose.slides.ink/), który zawiera typy niezbędne do tworzenia i zarządzania obiektami tuszu. 

## **Różnice między zwykłymi obiektami a obiektami tuszu**

Obiekty na slajdzie PowerPointa są zazwyczaj reprezentowane przez obiekty kształtu. Obiekt kształtu, w najprostszej formie, jest kontenerem definiującym obszar samego obiektu (jego ramkę) wraz z jego właściwościami. Do nich należą rozmiar obszaru kontenera, kształt kontenera, tło kontenera itp. Po więcej informacji zobacz [Shape Layout Format](https://docs.aspose.com/slides/pl/cpp/shape-manipulations/#access-layout-formats-for-shape).

Jednak gdy PowerPoint obsługuje obiekt tuszu, ignoruje wszystkie właściwości ramki obiektu (kontenera) z wyjątkiem jego rozmiaru. Rozmiar obszaru kontenera jest określany przez standardowe wartości `width` i `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Ślady Inkshape**

Ślad jest podstawowym elementem lub standardem używanym do rejestrowania trajektorii pióra, gdy użytkownik pisze cyfrowym tuszem. Ślady są nagraniami opisującymi sekwencje połączonych punktów. 

Najprostsza forma kodowania podaje współrzędne X i Y każdego punktu próbki. Gdy wszystkie połączone punkty zostaną wyrenderowane, powstaje obraz podobny do tego:

![ink_powerpoint2](ink_powerpoint2.png)

## **Właściwości pędzla do rysowania**

Możesz użyć pędzla do rysowania linii łączących punkty elementów śladu. Pędzel ma własny kolor i rozmiar, odpowiadające właściwościom `Brush.Color` i `Brush.Size`. 

### **Ustaw kolor pędzla tuszu**

Ten kod C++ pokazuje, jak ustawić kolor pędzla:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **Ustaw rozmiar pędzla tuszu** 

Ten kod C++ pokazuje, jak ustawić rozmiar pędzla:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

Zazwyczaj szerokość i wysokość pędzla nie są sobie równe, więc PowerPoint nie wyświetla rozmiaru pędzla (sekcja danych jest przygaszona). Jednak gdy szerokość i wysokość pędzla są równe, PowerPoint wyświetla jego rozmiar w ten sposób:

![ink_powerpoint3](ink_powerpoint3.png)

Dla przejrzystości zwiększmy wysokość obiektu tuszu i przeanalizujmy ważne wymiary: 

![ink_powerpoint4](ink_powerpoint4.png)

Kontener (ramka) nie uwzględnia rozmiaru pędzli — zawsze zakłada, że grubość linii wynosi zero (zobacz ostatni obraz). 

Dlatego, aby określić widoczny obszar całego obiektu tuszu, musimy uwzględnić rozmiar pędzla obiektów śladu. Tutaj docelowy obiekt (obiekt śladu odręcznego tekstu) został skalowany do rozmiaru kontenera (ramki). Gdy rozmiar kontenera (ramki) się zmienia, rozmiar pędzla pozostaje stały i odwrotnie. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zachowuje się tak samo podczas obsługi tekstu:

![ink_powerpoint6](ink_powerpoint6.png)

**Dalsza lektura**

* Aby przeczytać o kształtach ogólnie, zobacz sekcję [PowerPoint Shapes](https://docs.aspose.com/slides/pl/cpp/powerpoint-shapes/). 
* Po więcej informacji o wartościach efektywnych, zobacz [Shape Effective Properties](https://docs.aspose.com/slides/pl/cpp/shape-effective-properties/#get-effective-font-height-value).