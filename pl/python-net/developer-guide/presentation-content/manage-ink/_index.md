---
title: Zarządzanie obiektami atramentu w prezentacjach przy użyciu Pythona
linktitle: Zarządzaj atramentem
type: docs
weight: 95
url: /pl/python-net/manage-ink/
keywords:
- atrament
- obiekt atramentu
- ślad atramentu
- zarządzaj atramentem
- rysuj atrament
- rysowanie
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj obiektami atramentu w PowerPoint — twórz, edytuj i stylizuj cyfrowy atrament przy użyciu Aspose.Slides dla Pythona w .NET. Uzyskaj przykłady kodu dla śladów, koloru i rozmiaru pędzla."
---
## **Wprowadzenie**

PowerPoint udostępnia funkcję atramentu, pozwalającą rysować niestandardowe figury, które mogą być używane do podświetlania innych obiektów, pokazywania połączeń i procesów oraz zwracania uwagi na konkretne elementy na slajdzie.  

Aspose.Slides udostępnia przestrzeń nazw [aspose.slides.ink](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ink/), która zawiera typy niezbędne do tworzenia i zarządzania obiektami atramentu.  

## **Różnice między standardowymi obiektami a obiektami atramentu**

Obiekty na slajdzie PowerPoint są zazwyczaj reprezentowane przez obiekty kształtu. Obiekt kształtu, w najprostszej formie, jest kontenerem definiującym obszar samego obiektu (jego ramkę) wraz z jego właściwościami. Do nich należą rozmiar obszaru kontenera, kształt kontenera, tło kontenera itp. Po więcej informacji zobacz [Shape Layout Format](https://docs.aspose.com/slides/pl/python-net/shape-manipulations/#access-layout-formats-for-shape).  

Jednakże, gdy PowerPoint obsługuje obiekt atramentu, ignoruje wszystkie właściwości ramki obiektu (kontenera) z wyjątkiem jego rozmiaru. Rozmiar obszaru kontenera jest określany przez standardowe wartości `width` i `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Ślady Inkshape**

Ślad jest podstawowym elementem lub standardem używanym do rejestrowania trajektorii pióra, gdy użytkownik pisze cyfrowym atramentem. Ślady to zapisy opisujące sekwencje połączonych punktów.  

Najprostsza forma kodowania określa współrzędne X i Y każdego punktu próbkowego. Gdy wszystkie połączone punkty zostaną wyrenderowane, powstaje obraz podobny do tego:

![ink_powerpoint2](ink_powerpoint2.png)

## **Właściwości pędzla do rysowania**

Możesz użyć pędzla do rysowania linii łączących punkty elementów śladu. Pędzel ma własny kolor i rozmiar, odpowiadające właściwościom `Brush.color` i `Brush.size`.  

### **Ustaw kolor pędzla atramentu**

Ten kod w Pythonie pokazuje, jak ustawić kolor pędzla:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **Ustaw rozmiar pędzla atramentu**

Ten kod w Pythonie pokazuje, jak ustawić rozmiar pędzla:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

Zazwyczaj szerokość i wysokość pędzla nie są równe, więc PowerPoint nie wyświetla rozmiaru pędzla (sekcja danych jest przyciemniona). Jednak gdy szerokość i wysokość pędzla są równe, PowerPoint wyświetla jego rozmiar w ten sposób:

![ink_powerpoint3](ink_powerpoint3.png)

Dla przejrzystości zwiększmy wysokość obiektu atramentu i przeanalizujmy ważne wymiary:

![ink_powerpoint4](ink_powerpoint4.png)

Kontener (ramka) nie uwzględnia rozmiaru pędzli – zawsze zakłada, że grubość linii wynosi zero (zobacz ostatni obraz).  

Dlatego, aby określić widoczny obszar całego obiektu atramentu, musimy wziąć pod uwagę rozmiar pędzla obiektów śladu. W tym przypadku docelowy obiekt (obiekt śladu odręcznego tekstu) został przeskalowany do rozmiaru kontenera (ramki). Gdy rozmiar kontenera (ramki) się zmienia, rozmiar pędzla pozostaje stały i odwrotnie.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zachowuje się podobnie przy obsłudze tekstów:

![ink_powerpoint6](ink_powerpoint6.png)

**Dalsza lektura**

* Aby dowiedzieć się więcej o kształtach w ogóle, zobacz sekcję [PowerPoint Shapes](https://docs.aspose.com/slides/pl/python-net/powerpoint-shapes/).  
* Po więcej informacji o wartościach efektywnych zobacz [Shape Effective Properties](https://docs.aspose.com/slides/pl/python-net/shape-effective-properties/#get-effective-font-height-value).