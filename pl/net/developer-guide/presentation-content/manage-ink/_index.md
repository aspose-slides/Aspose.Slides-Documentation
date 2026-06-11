---
title: Zarządzanie obiektami atramentu w prezentacji w .NET
linktitle: Zarządzaj atramentem
type: docs
weight: 95
url: /pl/net/manage-ink/
keywords:
- atrament
- obiekt atramentu
- ślad atramentu
- zarządzaj atramentem
- rysuj atrament
- rysowanie
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj obiektami atramentu w PowerPoint — twórz, edytuj i stylizuj cyfrowy atrament przy użyciu Aspose.Slides dla .NET. Uzyskaj przykłady kodu dla śladów, koloru i rozmiaru pędzla."
---
## **Wstęp**

PowerPoint udostępnia funkcję atramentu, umożliwiając rysowanie nietypowych kształtów, które można wykorzystać do podkreślania innych obiektów, pokazywania połączeń i procesów oraz zwracania uwagi na konkretne elementy na slajdzie. 

Aspose.Slides udostępnia interfejs [Aspose.Slides.Ink](https://reference.aspose.com/slides/pl/net/aspose.slides.ink/), który zawiera typy potrzebne do tworzenia i zarządzania obiektami atramentu. 

## **Różnice między zwykłymi obiektami a obiektami atramentu**

Obiekty na slajdzie PowerPoint są zazwyczaj reprezentowane przez obiekty kształtu. Obiekt kształtu, w najprostszej formie, jest kontenerem definiującym obszar samego obiektu (jego ramkę) oraz jego właściwości. Do tych właściwości należą rozmiar obszaru kontenera, kształt kontenera, tło kontenera itp. Więcej informacji znajduje się w [Shape Layout Format](https://docs.aspose.com/slides/pl/net/shape-manipulations/#access-layout-formats-for-shape).

Jednak gdy PowerPoint ma do czynienia z obiektem atramentu, ignoruje wszystkie właściwości ramki obiektu (kontenera) z wyjątkiem jego rozmiaru. Rozmiar obszaru kontenera jest określany przez standardowe wartości `width` i `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Ślady Inkshape**

Ślad jest podstawowym elementem lub standardem używanym do rejestrowania trajektorii pióra, gdy użytkownik pisze cyfrowym atramentem. Ślady to nagrania opisujące sekwencje połączonych punktów. 

Najprostsza forma kodowania określa współrzędne X i Y każdego punktu próbki. Po wyrenderowaniu wszystkich połączonych punktów powstaje obraz podobny do tego:

![ink_powerpoint2](ink_powerpoint2.png)

## **Właściwości pędzla do rysowania**

Możesz użyć pędzla do rysowania linii łączących punkty elementów śladu. Pędzel ma własny kolor i rozmiar, odpowiadające właściwościom `Brush.Color` i `Brush.Size`. 

### **Ustaw kolor pędzla atramentu**

Ten kod C# pokazuje, jak ustawić kolor pędzla:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```

### **Ustaw rozmiar pędzla atramentu**

Ten kod C# pokazuje, jak ustawić rozmiar pędzla:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```

Zazwyczaj szerokość i wysokość pędzla nie są równe, więc PowerPoint nie wyświetla rozmiaru pędzla (sekcja danych jest przygaszona). Jednak gdy szerokość i wysokość pędzla są równe, PowerPoint wyświetla jego rozmiar w ten sposób:

![ink_powerpoint3](ink_powerpoint3.png)

Dla przejrzystości zwiększmy wysokość obiektu atramentu i przyjrzyjmy się ważnym wymiarom: 

![ink_powerpoint4](ink_powerpoint4.png)

Kontener (ramka) nie uwzględnia rozmiaru pędzli — zawsze zakłada, że grubość linii jest zerowa (zobacz ostatni obraz). 

W związku z tym, aby określić widoczny obszar całego obiektu atramentu, musimy uwzględnić rozmiar pędzla obiektów śladu. Tutaj docelowy obiekt (obiekt śladu odręcznego tekstu) został przeskalowany do rozmiaru kontenera (ramki). Gdy rozmiar kontenera (ramki) się zmienia, rozmiar pędzla pozostaje stały i odwrotnie. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint wykazuje to samo zachowanie przy pracy z tekstami:

![ink_powerpoint6](ink_powerpoint6.png)

**Dalsza lektura**

* Aby przeczytać o kształtach ogólnie, zobacz sekcję [PowerPoint Shapes](https://docs.aspose.com/slides/pl/net/powerpoint-shapes/). 
* Aby uzyskać więcej informacji o wartościach efektywnych, zobacz [Shape Effective Properties](https://docs.aspose.com/slides/pl/net/shape-effective-properties/#get-effective-font-height-value).