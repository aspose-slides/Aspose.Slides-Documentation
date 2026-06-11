---
title: Zarządzanie obiektami tuszu w prezentacji na Androidzie
linktitle: Zarządzaj tuszem
type: docs
weight: 95
url: /pl/androidjava/manage-ink/
keywords:
- tusz
- obiekt tuszu
- ślad tuszu
- zarządzanie tuszem
- rysowanie tuszu
- rysowanie
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zarządzaj obiektami tuszu PowerPoint — twórz, edytuj i stylizuj cyfrowy tusz za pomocą Aspose.Slides dla Androida. Pobierz przykłady kodu Java dla śladów, koloru i rozmiaru pędzla."
---
## **Wprowadzenie**

PowerPoint udostępnia funkcję tuszu, pozwalającą rysować niestandardowe kształty, które można wykorzystać do podkreślania innych obiektów, pokazywania połączeń i procesów oraz zwrócenia uwagi na konkretne elementy na slajdzie.  

Aspose.Slides zapewnia wszystkie typy Ink (np. klasa [Ink](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ink/)), które są potrzebne do tworzenia i zarządzania obiektami tuszu.

## **Różnice między obiektami standardowymi a obiektami tuszu**

Obiekty na slajdzie PowerPoint są zazwyczaj reprezentowane przez obiekty kształtu. Obiekt kształtu, w najprostszej formie, jest pojemnikiem definiującym obszar samego obiektu (jego ramkę) wraz z jego właściwościami. Ostatnie obejmują rozmiar obszaru pojemnika, kształt pojemnika, tło pojemnika itp. Więcej informacji znajdziesz w sekcji [Shape Layout Format](https://docs.aspose.com/slides/pl/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Jednakże, gdy PowerPoint pracuje z obiektem tuszu, ignoruje wszystkie właściwości ramki obiektu (pojemnika) z wyjątkiem jego rozmiaru. Rozmiar obszaru pojemnika określany jest przez standardowe wartości `width` i `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Ślady Inkshape**

Ślad jest podstawowym elementem lub standardem służącym do rejestrowania trajektorii pióra, gdy użytkownik pisze cyfrowy tusz. Ślady to zapisy opisujące sekwencje połączonych punktów.  

Najprostsza forma kodowania określa współrzędne X i Y każdego punktu próbki. Gdy wszystkie połączone punkty zostaną wyrenderowane, powstaje obraz podobny do tego:

![ink_powerpoint2](ink_powerpoint2.png)

## **Właściwości pędzla do rysowania**

Możesz użyć pędzla do rysowania linii łączących punkty elementów śladu. Pędzel ma własny kolor i rozmiar, odpowiadające właściwościom `Brush.Color` i `Brush.Size`.

### **Ustaw kolor pędzla tuszu**

Ten kod Java pokazuje, jak ustawić kolor pędzla:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ustaw rozmiar pędzla tuszu**

Ten kod Java pokazuje, jak ustawić rozmiar pędzla:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```

Zazwyczaj szerokość i wysokość pędzla nie są równe, dlatego PowerPoint nie wyświetla rozmiaru pędzla (sekcja danych jest przyciemniona). Gdy jednak szerokość i wysokość pędzla są równe, PowerPoint wyświetla jego rozmiar w ten sposób:

![ink_powerpoint3](ink_powerpoint3.png)

Dla przejrzystości zwiększmy wysokość obiektu tuszu i przyjrzyjmy się istotnym wymiarom:

![ink_powerpoint4](ink_powerpoint4.png)

Pojemnik (ramka) nie uwzględnia rozmiaru pędzli – zawsze zakłada, że grubość linii wynosi zero (zobacz ostatni obraz).  

Dlatego, aby określić widoczny obszar całego obiektu tuszu, musimy uwzględnić rozmiar pędzla obiektów śladu. Tutaj docelowy obiekt (obiekt śladu odręcznego tekstu) został skalowany do rozmiaru pojemnika (ramki). Gdy rozmiar pojemnika (ramki) się zmienia, rozmiar pędzla pozostaje stały i odwrotnie.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint wykazuje takie samo zachowanie przy pracy z tekstami:

![ink_powerpoint6](ink_powerpoint6.png)

**Dalsza lektura**

* Aby przeczytać o kształtach ogólnie, zobacz sekcję [PowerPoint Shapes](https://docs.aspose.com/slides/pl/androidjava/powerpoint-shapes/).
* Aby uzyskać więcej informacji o wartościach skutecznych, zobacz [Shape Effective Properties](https://docs.aspose.com/slides/pl/androidjava/shape-effective-properties/#getting-effective-font-height-value).