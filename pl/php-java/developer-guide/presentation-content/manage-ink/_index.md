---
title: Zrządzanie obiektami atramentu w prezentacji w PHP
linktitle: Zarządzaj atramentem
type: docs
weight: 95
url: /pl/php-java/manage-ink/
keywords:
- atrament
- obiekt atramentu
- ślad atramentu
- zarządzanie atramentem
- rysowanie atramentu
- rysowanie
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj obiektami atramentu w PowerPoint — twórz, edytuj i stylizuj cyfrowy atrament za pomocą Aspose.Slides dla PHP poprzez Java. Pobierz przykłady kodu dotyczące śladów, koloru pędzla i rozmiaru."
---
## **Wprowadzenie**

PowerPoint udostępnia funkcję atramentu, aby umożliwić rysowanie niestandardowych kształtów, które można wykorzystać do wyróżniania innych obiektów, pokazywania połączeń i procesów oraz przyciągania uwagi do konkretnych elementów na slajdzie. 

Aspose.Slides udostępnia wszystkie typy Ink (np. klasa [Ink](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ink/) ), które są potrzebne do tworzenia i zarządzania obiektami atramentu.

## **Różnice między zwykłymi obiektami a obiektami atramentu**

Obiekty na slajdzie PowerPoint są zazwyczaj reprezentowane przez obiekty kształtu. Obiekt kształtu, w najprostszej formie, jest kontenerem definiującym obszar samego obiektu (jego ramkę) wraz z jego właściwościami. Ostatnie obejmuje rozmiar obszaru kontenera, kształt kontenera, tło kontenera itp. Więcej informacji znajdziesz w [Shape Layout Format](https://docs.aspose.com/slides/pl/php-java/shape-manipulations/#access-layout-formats-for-shape).

Jednakże, gdy PowerPoint obsługuje obiekt atramentu, ignoruje wszystkie właściwości ramki obiektu (kontenera) poza jego rozmiarem. Rozmiar obszaru kontenera jest określany przez standardowe wartości `width` i `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Ślady Inkshape**

Ślad jest podstawowym elementem lub standardem używanym do rejestrowania trajektorii pióra, gdy użytkownik pisze atramentem cyfrowym. Ślady to zapisy opisujące ciągi połączonych punktów. 

Najprostsza forma kodowania określa współrzędne X i Y każdego punktu próbki. Gdy wszystkie połączone punkty zostaną wyrenderowane, tworzą obraz podobny do tego:

![ink_powerpoint2](ink_powerpoint2.png)

## **Właściwości pędzla do rysowania**

Możesz użyć pędzla do rysowania linii łączących punkty elementów śladu. Pędzel ma własny kolor i rozmiar, odpowiadające właściwościom `Brush.Color` i `Brush.Size`. 

### **Ustaw kolor pędzla atramentu**

Ten kod PHP pokazuje, jak ustawić kolor pędzla:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Ustaw rozmiar pędzla atramentu** 

Ten kod PHP pokazuje, jak ustawić rozmiar pędzla:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Zazwyczaj szerokość i wysokość pędzla nie są zgodne, więc PowerPoint nie wyświetla rozmiaru pędzla (sekcja danych jest przyciemniona). Jednak gdy szerokość i wysokość pędzla są identyczne, PowerPoint wyświetla jego rozmiar w następujący sposób:

![ink_powerpoint3](ink_powerpoint3.png)

Dla jasności zwiększmy wysokość obiektu atramentu i przyjrzyjmy się ważnym wymiarom: 

![ink_powerpoint4](ink_powerpoint4.png)

Kontener (ramka) nie uwzględnia rozmiaru pędzli — zawsze zakłada, że grubość linii wynosi zero (zobacz ostatni obraz). 

Dlatego, aby określić widoczny obszar całego obiektu atramentu, musimy uwzględnić rozmiar pędzla obiektów śladu. Tutaj docelowy obiekt (obiekt śladu ręcznie pisanego tekstu) został przeskalowany do rozmiaru kontenera (ramki). Gdy rozmiar kontenera (ramki) się zmienia, rozmiar pędzla pozostaje stały i odwrotnie. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint zachowuje się tak samo przy obsłudze tekstów:

![ink_powerpoint6](ink_powerpoint6.png)

**Dalsza lektura**

* Aby przeczytać o kształtach w ogóle, zobacz sekcję [PowerPoint Shapes](https://docs.aspose.com/slides/pl/php-java/powerpoint-shapes/).
* Po więcej informacji o wartościach efektywnych, zobacz [Shape Effective Properties](https://docs.aspose.com/slides/pl/php-java/shape-effective-properties/#getting-effective-font-height-value).