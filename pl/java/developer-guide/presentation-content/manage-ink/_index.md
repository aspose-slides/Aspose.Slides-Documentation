---
title: "Zarządzaj obiektami atramentu w prezentacji w Javie"
linktitle: "Zarządzaj atramentem"
type: docs
weight: 95
url: /pl/java/manage-ink/
keywords:
- "atrament"
- "obiekt atramentu"
- "ślad atramentu"
- "zarządzaj atramentem"
- "rysuj atrament"
- "rysowanie"
- "PowerPoint"
- "prezentacja"
- "Java"
- "Aspose.Slides"
description: "Zarządzaj obiektami atramentu w PowerPoint — twórz, edytuj i stylizuj cyfrowy atrament za pomocą Aspose.Slides dla Javy. Pobierz przykłady kodu dla śladów, koloru i rozmiaru pędzla."
---
## **Wprowadzenie**

PowerPoint udostępnia funkcję atramentu, umożliwiającą rysowanie nietypowych kształtów, które mogą być używane do podkreślania innych obiektów, pokazywania połączeń i procesów oraz przyciągania uwagi do konkretnych elementów na slajdzie.  

Aspose.Slides dostarcza wszystkie typy Atramentu (np. klasa [Ink](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ink/)), których potrzebujesz do tworzenia i zarządzania obiektami atramentowymi.  

## **Różnice między zwykłymi obiektami a obiektami atramentowymi**

Obiekty na slajdzie PowerPoint są zazwyczaj reprezentowane przez obiekty kształtu. Obiekt kształtu, w najprostszej formie, jest kontenerem definiującym obszar samego obiektu (jego ramkę) oraz jego właściwości. Obejmuje to rozmiar obszaru kontenera, kształt kontenera, tło kontenera itd. Więcej informacji można znaleźć w sekcji [Shape Layout Format](https://docs.aspose.com/slides/pl/java/shape-manipulations/#access-layout-formats-for-shape).

Jednak gdy PowerPoint obsługuje obiekt atramentowy, ignoruje wszystkie właściwości ramki obiektu (kontenera) z wyjątkiem jego rozmiaru. Rozmiar obszaru kontenera jest określany przez standardowe wartości `width` i `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Ślady atramentu**

Ślad jest podstawowym elementem lub standardem używanym do rejestrowania trajektorii pióra, gdy użytkownik pisze cyfrowym atramentem. Ślady to zapisy opisujące ciągi połączonych punktów.  

Najprostsza forma kodowania określa współrzędne X i Y każdego punktu próbki. Gdy wszystkie połączone punkty zostaną wyrenderowane, powstaje obraz podobny do tego:

![ink_powerpoint2](ink_powerpoint2.png)

## **Właściwości pędzla do rysowania**

Możesz użyć pędzla do rysowania linii łączących punkty elementów śladu. Pędzel ma własny kolor i rozmiar, odpowiadające właściwościom `Brush.Color` i `Brush.Size`.  

### **Ustaw kolor pędzla atramentowego**

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

### **Ustaw rozmiar pędzla atramentowego** 

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

Zazwyczaj szerokość i wysokość pędzla nie są takie same, dlatego PowerPoint nie wyświetla rozmiaru pędzla (sekcja danych jest przygaszona). Jednak gdy szerokość i wysokość pędzla są równe, PowerPoint wyświetla jego rozmiar w ten sposób:

![ink_powerpoint3](ink_powerpoint3.png)

Dla przejrzystości zwiększmy wysokość obiektu atramentowego i przyjrzyjmy się istotnym wymiarom: 

![ink_powerpoint4](ink_powerpoint4.png)

Kontener (ramka) nie uwzględnia rozmiaru pędzli — zawsze zakłada, że grubość linii jest zerowa (zobacz ostatni obraz).  

Dlatego, aby określić widoczny obszar całego obiektu atramentowego, musimy wziąć pod uwagę rozmiar pędzla obiektów śladu. W tym przypadku docelowy obiekt (obiekt śladu odręcznego tekstu) został skalowany do rozmiaru kontenera (ramki). Gdy rozmiar kontenera (ramki) się zmienia, rozmiar pędzla pozostaje stały i odwrotnie.  

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zachowuje się w ten sam sposób przy obsłudze tekstów:

![ink_powerpoint6](ink_powerpoint6.png)

**Dalsza lektura**

* Aby przeczytać o kształtach ogólnie, zobacz sekcję [PowerPoint Shapes](https://docs.aspose.com/slides/pl/java/powerpoint-shapes/).  
* Aby uzyskać więcej informacji o wartościach efektywnych, zobacz [Shape Effective Properties](https://docs.aspose.com/slides/pl/java/shape-effective-properties/#getting-effective-font-height-value).