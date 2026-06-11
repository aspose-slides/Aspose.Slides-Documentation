---
title: Zarządzanie obiektami tuszu w prezentacjach w JavaScript
linktitle: Zarządzaj tuszem
type: docs
weight: 95
url: /pl/nodejs-java/manage-ink/
keywords:
- tusz
- obiekt tuszu
- ślad tuszu
- zarządzanie tuszem
- rysowanie tuszu
- rysowanie
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj obiektami tuszu w PowerPoint — twórz, edytuj i stylizuj cyfrowy tusz przy użyciu Aspose.Slides dla Node.js. Uzyskaj przykłady kodu JavaScript dla śladów, koloru i rozmiaru pędzla."
---
## **Wstęp**

PowerPoint udostępnia funkcję tuszu, która pozwala rysować niestandardowe kształty, które można wykorzystać do podkreślania innych obiektów, pokazywania połączeń i procesów oraz zwrócenia uwagi na konkretne elementy na slajdzie. 

Aspose.Slides dostarcza wszystkie typy Ink (np. klasa [Ink](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ink/)), które są potrzebne do tworzenia i zarządzania obiektami tuszu.

## **Różnice między zwykłymi obiektami a obiektami tuszu**

Obiekty na slajdzie PowerPoint są zazwyczaj reprezentowane przez obiekty kształtu. Obiekt kształtu, w najprostszej formie, jest kontenerem definiującym obszar samego obiektu (jego ramkę) oraz jego właściwości. Do nich należą rozmiar obszaru kontenera, kształt kontenera, tło kontenera itp. Więcej informacji znajduje się w [Shape Layout Format](https://docs.aspose.com/slides/pl/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Jednak gdy PowerPoint obsługuje obiekt tuszu, ignoruje wszystkie właściwości ramki obiektu (kontenera) oprócz jego rozmiaru. Rozmiar obszaru kontenera jest określany przez standardowe wartości `width` i `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Ślady Inkshape**

Ślad jest podstawowym elementem lub standardem służącym do rejestrowania trajektorii pióra, gdy użytkownik pisze cyfrowym tuszem. Ślady to nagrania opisujące sekwencje połączonych punktów. 

Najprostsza forma kodowania określa współrzędne X i Y każdego punktu próbki. Po wyrenderowaniu wszystkich połączonych punktów powstaje obraz podobny do tego:

![ink_powerpoint2](ink_powerpoint2.png)

## **Właściwości pędzla do rysowania** 

Możesz użyć pędzla do rysowania linii łączących punkty elementów śladu. Pędzel ma własny kolor i rozmiar, odpowiadające metodom `Brush.setColor` i `Brush.setSize`. 

### **Ustaw kolor pędzla tuszu**

Ten kod JavaScript pokazuje, jak ustawić kolor pędzla:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ustaw rozmiar pędzla tuszu** 

Ten kod JavaScript pokazuje, jak ustawić rozmiar pędzla:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Zazwyczaj szerokość i wysokość pędzla nie są równe, więc PowerPoint nie wyświetla rozmiaru pędzla (sekcja danych jest przygaszona). Jednak gdy szerokość i wysokość pędzla są równe, PowerPoint wyświetla jego rozmiar w następujący sposób:

![ink_powerpoint3](ink_powerpoint3.png)

Dla przejrzystości zwiększmy wysokość obiektu tuszu i przyjrzyjmy się ważnym wymiarom: 

![ink_powerpoint4](ink_powerpoint4.png)

Kontener (ramka) nie uwzględnia rozmiaru pędzli – zawsze zakłada, że grubość linii wynosi zero (zobacz ostatni obraz). 

Dlatego, aby określić widoczny obszar całego obiektu tuszu, musimy wziąć pod uwagę rozmiar pędzla obiektów śladu. Tutaj docelowy obiekt (ślad odręcznego tekstu) został skalowany do rozmiaru kontenera (ramki). Gdy rozmiar kontenera (ramki) się zmienia, rozmiar pędzla pozostaje stały i odwrotnie. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint wykazuje to samo zachowanie przy obsłudze tekstów:

![ink_powerpoint6](ink_powerpoint6.png)

**Dalsza lektura**

* Aby dowiedzieć się więcej o kształtach w ogóle, zobacz sekcję [PowerPoint Shapes](https://docs.aspose.com/slides/pl/nodejs-java/powerpoint-shapes/).
* Aby uzyskać więcej informacji o wartościach efektywnych, zobacz [Shape Effective Properties](https://docs.aspose.com/slides/pl/nodejs-java/shape-effective-properties/#getting-effective-font-height-value).