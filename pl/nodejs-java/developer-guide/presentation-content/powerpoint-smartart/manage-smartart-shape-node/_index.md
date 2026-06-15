---
title: Zarządzaj węzłami kształtu SmartArt w prezentacjach przy użyciu JavaScript
linktitle: Węzeł kształtu SmartArt
type: docs
weight: 30
url: /pl/nodejs-java/manage-smartart-shape-node/
keywords:
- węzeł SmartArt
- węzeł podrzędny
- dodaj węzeł
- pozycja węzła
- dostęp do węzła
- usuń węzeł
- niestandardowa pozycja
- węzeł pomocniczy
- format wypełnienia
- renderowanie węzła
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj węzłami kształtu SmartArt w PPT i PPTX przy użyciu Aspose.Slides for Node.js. Uzyskaj przejrzyste przykłady kodu JavaScript i wskazówki usprawniające twoje prezentacje."
---
## **Przegląd**

Grafiki SmartArt w prezentacjach PowerPoint są organizowane za pomocą węzłów, które zawierają tekst i definiują strukturę diagramu. Aspose.Slides umożliwia programowe operowanie na tych węzłach SmartArt: dodawanie nowych węzłów i węzłów podrzędnych, wstawianie węzłów podrzędnych w określonej pozycji, dostęp do istniejących węzłów oraz odczytywanie ich tekstu, poziomu i pozycji.

Ten artykuł wyjaśnia, jak zarządzać węzłami kształtów SmartArt. Pokazuje, jak usuwać węzły, pracować z węzłami podrzędnymi według indeksu lub pozycji, zmienić węzeł pomocniczy na zwykły, dostosować pozycję, rozmiar i obrót kształtów węzłów SmartArt, ustawić formaty wypełnienia węzła oraz wygenerować miniaturę obrazu dla węzła podrzędnego SmartArt.

## **Dodawanie węzła SmartArt w prezentacji PowerPoint przy użyciu JavaScript**
Aspose.Slides for Node.js via Java udostępnia najprostsze API do zarządzania kształtami SmartArt w najłatwiejszy sposób. Poniższy przykładowy kod pomoże dodać węzeł i węzeł podrzędny wewnątrz kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) i wczytaj prezentację zawierającą kształt SmartArt.  
1. Uzyskaj odniesienie do pierwszego slajdu, używając jego indeksu.  
1. Przejdź przez wszystkie kształty znajdujące się na pierwszym slajdzie.  
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt), jeśli jest SmartArt.  
1. [Dodaj nowy węzeł](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) w kształcie SmartArt **NodeCollection** (https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt#getAllNodes--) i ustaw tekst w TextFrame.  
1. Teraz, [Dodaj](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) [**Child Node**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) w nowo dodanym węźle [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt) i ustaw tekst w TextFrame.  
1. Zapisz prezentację.

```javascript
// Załaduj żądaną prezentację
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Przejdź przez wszystkie kształty na pierwszym slajdzie
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Sprawdź, czy kształt jest typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Rzutuj kształt na SmartArt
            var smart = shape;
            // Dodawanie nowego węzła SmartArt
            var TemNode = smart.getAllNodes().addNode();
            // Dodawanie tekstu
            TemNode.getTextFrame().setText("Test");
            // Dodawanie nowego węzła podrzędnego w węźle nadrzędnym. Zostanie dodany na końcu kolekcji
            var newNode = TemNode.getChildNodes().addNode();
            // Dodawanie tekstu
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Zapisywanie prezentacji
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dodawanie węzła SmartArt w określonej pozycji**
W poniższym przykładowym kodzie wyjaśniono, jak dodać węzły podrzędne należące do odpowiednich węzłów kształtu SmartArt w określonej pozycji.

1. Utwórz instancję klasy Presentation.  
1. Uzyskaj odniesienie do pierwszego slajdu, używając jego indeksu.  
1. Dodaj kształt [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt) typu [**StackedList**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) na wybranym slajdzie.  
1. Uzyskaj dostęp do pierwszego węzła w dodanym kształcie SmartArt.  
1. Teraz, dodaj [**Child Node**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) dla wybranego [**Node**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtNode) na pozycji 2 i ustaw jego tekst.  
1. Zapisz prezentację.

```javascript
// Tworzenie instancji prezentacji
var pres = new aspose.slides.Presentation();
try {
    // Uzyskanie dostępu do slajdu prezentacji
    var slide = pres.getSlides().get_Item(0);
    // Dodaj Smart Art IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Dostęp do węzła SmartArt o indeksie 0
    var node = smart.getAllNodes().get_Item(0);
    // Dodawanie nowego węzła podrzędnego na pozycji 2 w węźle nadrzędnym
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Dodaj tekst
    chNode.getTextFrame().setText("Sample Text Added");
    // Zapisz prezentację
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dostęp do węzła SmartArt w prezentacji PowerPoint przy użyciu JavaScript**
Poniższy przykładowy kod pomoże uzyskać dostęp do węzłów wewnątrz kształtu SmartArt. Należy zauważyć, że nie można zmienić LayoutType SmartArt, ponieważ jest on tylko do odczytu i jest ustawiany wyłącznie w momencie dodania kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) i wczytaj prezentację zawierającą kształt SmartArt.  
1. Uzyskaj odniesienie do pierwszego slajdu, używając jego indeksu.  
1. Przejdź przez wszystkie kształty znajdujące się na pierwszym slajdzie.  
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt), jeśli jest SmartArt.  
1. Przejdź przez wszystkie [**Nodes**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt#getAllNodes--) wewnątrz kształtu SmartArt.  
1. Uzyskaj dostęp i wyświetl informacje, takie jak pozycja węzła SmartArt, poziom i tekst.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // Pobierz pierwszy slajd
    var slide = pres.getSlides().get_Item(0);
    // Przejdź przez wszystkie kształty na pierwszym slajdzie
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Sprawdź, czy kształt jest typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Rzutuj kształt na SmartArt
            var smart = shape;
            // Przejdź przez wszystkie węzły wewnątrz SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // Dostęp do węzła SmartArt o indeksie i
                var node = smart.getAllNodes().get_Item(j);
                // Wyświetlanie parametrów węzła SmartArt
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dostęp do węzła podrzędnego SmartArt**
Poniższy przykładowy kod pomoże uzyskać dostęp do węzłów podrzędnych należących do odpowiednich węzłów kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) i wczytaj prezentację zawierającą kształt SmartArt.  
1. Uzyskaj odniesienie do pierwszego slajdu, używając jego indeksu.  
1. Przejdź przez wszystkie kształty znajdujące się na pierwszym slajdzie.  
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt), jeśli jest SmartArt.  
1. Przejdź przez wszystkie [**Nodes**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt#getAllNodes--) wewnątrz kształtu SmartArt.  
1. Dla każdego wybranego [**Node**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtNode) kształtu SmartArt, przejdź przez wszystkie [**Child Nodes**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) wewnątrz konkretnego węzła.  
1. Uzyskaj dostęp i wyświetl informacje, takie jak pozycja, poziom i tekst [**Child Node**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--).

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // Pobierz pierwszy slajd
    var slide = pres.getSlides().get_Item(0);
    // Przejdź przez wszystkie kształty na pierwszym slajdzie
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Sprawdź, czy kształt jest typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Rzutuj kształt na SmartArt
            var smart = shape;
            // Przejdź przez wszystkie węzły wewnątrz SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // Dostęp do węzła SmartArt o indeksie i
                var node0 = smart.getAllNodes().get_Item(i);
                // Przechodzenie przez węzły podrzędne w węźle SmartArt o indeksie i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // Dostęp do węzła podrzędnego w węźle SmartArt
                    var node = node0.getChildNodes().get_Item(j);
                    // Wyświetlanie parametrów węzła podrzędnego SmartArt
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dostęp do węzła podrzędnego SmartArt w określonej pozycji**
W tym przykładzie nauczymy się uzyskiwać dostęp do węzłów podrzędnych w określonych pozycjach, należących do odpowiednich węzłów kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).  
1. Uzyskaj odniesienie do pierwszego slajdu, używając jego indeksu.  
1. Dodaj kształt SmartArt typu [**StackedList**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList).  
1. Uzyskaj dostęp do dodanego kształtu SmartArt.  
1. Uzyskaj dostęp do węzła o indeksie 0 w wybranym kształcie SmartArt.  
1. Teraz, uzyskaj dostęp do [**Child Node**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) na pozycji 1 dla wybranego węzła SmartArt, używając metody **get_Item()**.  
1. Uzyskaj dostęp i wyświetl informacje, takie jak pozycja, poziom i tekst [**Child Node**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--).

```javascript
// Utwórz instancję prezentacji
var pres = new aspose.slides.Presentation();
try {
    // Dostęp do pierwszego slajdu
    var slide = pres.getSlides().get_Item(0);
    // Dodawanie kształtu SmartArt na pierwszym slajdzie
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Dostęp do węzła SmartArt o indeksie 0
    var node = smart.getAllNodes().get_Item(0);
    // Dostęp do węzła podrzędnego na pozycji 1 w węźle nadrzędnym
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // Wyświetlanie parametrów węzła podrzędnego SmartArt
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Usuwanie węzła SmartArt w prezentacji PowerPoint przy użyciu JavaScript**
W tym przykładzie dowiemy się, jak usuwać węzły wewnątrz kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) i wczytaj prezentację zawierającą kształt SmartArt.  
1. Uzyskaj odniesienie do pierwszego slajdu, używając jego indeksu.  
1. Przejdź przez wszystkie kształty znajdujące się na pierwszym slajdzie.  
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt), jeśli jest SmartArt.  
1. Sprawdź, czy [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt) ma więcej niż 0 węzłów.  
1. Wybierz węzeł SmartArt do usunięcia.  
1. Teraz usuń wybrany węzeł, używając metody [**RemoveNode**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-).  
1. Zapisz prezentację.

```javascript
// Załaduj żądaną prezentację
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Przejdź przez wszystkie kształty na pierwszym slajdzie
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Sprawdź, czy kształt jest typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Rzutuj kształt na SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Dostęp do węzła SmartArt o indeksie 0
                var node = smart.getAllNodes().get_Item(0);
                // Usuwanie wybranego węzła
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Zapisz prezentację
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Usuwanie węzła SmartArt w określonej pozycji**
W tym przykładzie nauczymy się usuwać węzły wewnątrz kształtu SmartArt w określonej pozycji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) i wczytaj prezentację zawierającą kształt SmartArt.  
1. Uzyskaj odniesienie do pierwszego slajdu, używając jego indeksu.  
1. Przejdź przez wszystkie kształty znajdujące się na pierwszym slajdzie.  
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt), jeśli jest SmartArt.  
1. Wybierz węzeł kształtu SmartArt o indeksie 0.  
1. Teraz sprawdź, czy wybrany węzeł SmartArt posiada więcej niż 2 węzły podrzędne.  
1. Teraz usuń węzeł na **Pozycji 1** przy użyciu metody [**RemoveNode**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-).  
1. Zapisz prezentację.

```javascript
// Załaduj żądaną prezentację
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Przejdź przez wszystkie kształty w pierwszym slajdzie
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Sprawdź, czy kształt jest typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Rzutuj kształt na SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Dostęp do węzła SmartArt o indeksie 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // Usuwanie węzła podrzędnego na pozycji 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Zapisz prezentację
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustawienie niestandardowej pozycji dla węzła podrzędnego w SmartArt**
Teraz Aspose.Slides for Node.js via Java obsługuje ustawianie właściwości [SmartArtShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#setX-float-) i [Y](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#setY-float-). Poniższy fragment kodu pokazuje, jak ustawić niestandardową pozycję, rozmiar i obrót SmartArtShape; należy również zauważyć, że dodawanie nowych węzłów powoduje przeliczenie pozycji i rozmiarów wszystkich węzłów. Dzięki ustawieniom niestandardowej pozycji użytkownik może ustawić węzły zgodnie z wymaganiami.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Przenieś kształt SmartArt na nową pozycję
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // Zmień szerokości kształtu SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // Zmień wysokość kształtu SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // Zmień obrót kształtu SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Sprawdzenie węzła pomocniczego**
{{% alert color="primary" %}} 

W tym artykule bardziej zbadamy funkcje kształtów SmartArt dodawanych do slajdów prezentacji programowo przy użyciu Aspose.Slides for Node.js via Java.

{{% /alert %}} 

Do naszego badania w różnych sekcjach tego artykułu użyjemy następującego źródłowego kształtu SmartArt.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Rysunek: Źródłowy kształt SmartArt na slajdzie**|

W poniższym przykładowym kodzie zbadamy, jak zidentyfikować **Assistant Nodes** w kolekcji węzłów SmartArt i jak je zmienić.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) i wczytaj prezentację zawierającą kształt SmartArt.  
1. Uzyskaj odniesienie do drugiego slajdu, używając jego indeksu.  
1. Przejdź przez wszystkie kształty znajdujące się na pierwszym slajdzie.  
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt), jeśli jest SmartArt.  
1. Przejdź przez wszystkie węzły wewnątrz kształtu SmartArt i sprawdź, czy są [**Assistant Nodes**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtNode#isAssistant--).  
1. Zmień status węzła pomocniczego na węzeł normalny.  
1. Zapisz prezentację.

```javascript
// Tworzenie instancji prezentacji
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // Przejdź przez wszystkie kształty w pierwszym slajdzie
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Sprawdź, czy kształt jest typu SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Rzutuj kształt na SmartArt
            var smart = shape;
            // Przeglądanie wszystkich węzłów kształtu SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Sprawdź, czy węzeł jest węzłem pomocniczym
                if (node.isAssistant()) {
                    // Ustawienie węzła pomocniczego na false i zamiana go na węzeł normalny
                    node.isAssistant();
                }
            }
        }
    }
    // Zapisz prezentację
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Rysunek: Zmienione węzły pomocnicze w kształcie SmartArt na slajdzie**|

## **Ustaw format wypełnienia węzła**
Aspose.Slides for Node.js via Java umożliwia dodawanie niestandardowych kształtów SmartArt oraz ustawianie ich formatu wypełnienia. Ten artykuł wyjaśnia, jak tworzyć i uzyskiwać dostęp do kształtów SmartArt oraz ustawiać ich format wypełnienia przy użyciu Aspose.Slides for Node.js via Java.

Proszę wykonać poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).  
1. Uzyskaj odniesienie do slajdu, używając jego indeksu.  
1. Dodaj kształt [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArt) ustawiając jego [**LayoutType**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
1. Ustaw [**FillFormat**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getFillFormat--) dla węzłów kształtu SmartArt.  
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```javascript
// Utwórz instancję prezentacji
var pres = new aspose.slides.Presentation();
try {
    // Dostęp do slajdu
    var slide = pres.getSlides().get_Item(0);
    // Dodawanie kształtu SmartArt i węzłów
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Ustawianie koloru wypełnienia węzła
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // Zapisz prezentację
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Generowanie miniaturki węzła podrzędnego SmartArt**
Programiści mogą wygenerować miniaturkę węzła podrzędnego SmartArt, postępując według poniższych kroków:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).  
1. [Dodaj SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--).  
1. Uzyskaj odniesienie do węzła, używając jego indeksu.  
1. Pobierz obraz miniaturki.  
1. Zapisz obraz miniaturki w dowolnym pożądanym formacie obrazu.

```javascript
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Dodaj SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Uzyskaj odniesienie do węzła, używając jego indeksu
    var node = smart.getNodes().get_Item(1);
    // Pobierz miniaturkę
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Zapisz miniaturkę
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy animacje SmartArt są obsługiwane?**

Tak. SmartArt jest traktowany jako zwykły kształt, więc możesz [zastosować standardowe animacje](/slides/pl/nodejs-java/shape-animation/) (wejścia, wyjścia, podkreślenia, ścieżki ruchu) i dostosować czas. Możesz też animować kształty wewnątrz węzłów SmartArt, gdy jest to potrzebne.

**Jak mogę niezawodnie zlokalizować konkretny SmartArt na slajdzie, jeśli jego wewnętrzny identyfikator jest nieznany?**

Przypisz i wyszukuj po [alternative text](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getalternativetext/). Ustawienie wyróżniającego AltText w SmartArt pozwala go znaleźć bez polegania na wewnętrznych identyfikatorach.

**Czy wygląd SmartArt zostanie zachowany przy konwertowaniu prezentacji do PDF?**

Tak. Aspose.Slides renderuje SmartArt z wysoką wiernością wizualną podczas [PDF export](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/), zachowując układ, kolory i efekty.

**Czy mogę wyodrębnić obraz całego SmartArt (do podglądów lub raportów)?**

Tak. Możesz renderować kształt SmartArt do [raster formats](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getImage) lub do [SVG](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/writeassvg/) dla skalowalnego wyjścia wektorowego, co nadaje się do miniatur, raportów lub użycia w sieci.