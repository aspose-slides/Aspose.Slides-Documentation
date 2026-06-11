---
title: Zarządzanie węzłami kształtu SmartArt w prezentacjach przy użyciu Javy
linktitle: Węzeł kształtu SmartArt
type: docs
weight: 30
url: /pl/java/manage-smartart-shape-node/
keywords:
- Węzeł SmartArt
- Węzeł podrzędny
- Dodaj węzeł
- Pozycja węzła
- Dostęp do węzła
- Usuń węzeł
- Niestandardowa pozycja
- Węzeł pomocniczy
- Format wypełnienia
- Renderowanie węzła
- PowerPoint
- Prezentacja
- Java
- Aspose.Slides
description: "Zarządzaj węzłami kształtu SmartArt w plikach PPT i PPTX przy użyciu Aspose.Slides dla Javy. Otrzymaj przejrzyste przykłady kodu i wskazówki, aby usprawnić swoje prezentacje."
---
## **Przegląd**

Grafika SmartArt w prezentacjach PowerPoint jest organizowana za pomocą węzłów, które zawierają tekst i definiują strukturę diagramu. Aspose.Slides umożliwia programowe działanie na tych węzłach SmartArt: dodawanie nowych węzłów i węzłów podrzędnych, wstawianie węzłów podrzędnych w określonej pozycji, dostęp do istniejących węzłów oraz odczytywanie ich tekstu, poziomu i pozycji.

Ten artykuł wyjaśnia, jak zarządzać węzłami kształtu SmartArt. Pokazuje, jak usuwać węzły, pracować z węzłami podrzędnymi według indeksu lub pozycji, zmienić węzeł pomocniczy na zwykły węzeł, dostosować pozycję, rozmiar i obrót kształtów węzłów SmartArt, ustawić formaty wypełnienia węzła oraz wygenerować miniaturkę obrazu dla węzła podrzędnego SmartArt.

## **Dodaj węzeł SmartArt**
Aspose.Slides for Java udostępnia najprostsze API do zarządzania kształtami SmartArt w najłatwiejszy sposób. Poniższy przykładowy kod pomoże dodać węzeł i węzeł podrzędny wewnątrz kształtu SmartArt.

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) i załaduj prezentację z kształtem SmartArt.
1. Uzyskaj odwołanie do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty wewnątrz pierwszego slajdu.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt), jeśli jest to SmartArt.
1. [Dodaj nowy węzeł](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) w kształcie SmartArt [**NodeCollection**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt#getAllNodes--) i ustaw tekst w TextFrame.
1. Teraz, [Dodaj](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**Węzeł podrzędny**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArtNode#getChildNodes--) do nowo dodanego węzła [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt) i ustaw tekst w TextFrame.
1. Zapisz prezentację.

```java
// Wczytaj żądaną prezentację
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Przejdź przez wszystkie kształty na pierwszym slajdzie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape instanceof SmartArt) 
        {
            // Rzutuj kształt na SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Dodawanie nowego węzła SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Dodawanie tekstu
            TemNode.getTextFrame().setText("Test");
    
            // Dodawanie nowego węzła podrzędnego w węźle nadrzędnym. Zostanie on dodany na końcu kolekcji
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Dodawanie tekstu
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Zapisywanie prezentacji
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dodaj węzeł SmartArt w określonej pozycji**
W poniższym przykładowym kodzie wyjaśniono, jak dodać węzły podrzędne należące do odpowiednich węzłów kształtu SmartArt w określonej pozycji.

1. Utwórz instancję klasy Prezentacja.
1. Uzyskaj odwołanie do pierwszego slajdu, używając jego indeksu.
1. Dodaj kształt [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArt) typu [**StackedList**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArtLayoutType#StackedList) na uzyskanym slajdzie.
1. Uzyskaj dostęp do pierwszego węzła w dodanym kształcie SmartArt.
1. Teraz, dodaj [**Węzeł podrzędny**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArtNode#getChildNodes--) dla wybranego [**Węzła**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArtNode) na pozycji 2 i ustaw jego tekst.
1. Zapisz prezentację.

```java
// Tworzenie instancji prezentacji
Presentation pres = new Presentation();
try {
    // Uzyskaj dostęp do slajdu prezentacji
    ISlide slide = pres.getSlides().get_Item(0);

    // Dodaj Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Uzyskiwanie węzła SmartArt o indeksie 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Dodawanie nowego węzła podrzędnego na pozycji 2 w węźle nadrzędnym
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Dodaj tekst
    chNode.getTextFrame().setText("Sample Text Added");

    // Zapisz prezentację
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dostęp do węzła SmartArt**
Poniższy przykładowy kod pomoże uzyskać dostęp do węzłów wewnątrz kształtu SmartArt. Należy zauważyć, że nie można zmienić właściwości LayoutType SmartArt, ponieważ jest ona tylko do odczytu i jest ustawiana wyłącznie w momencie dodania kształtu SmartArt.

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation) i załaduj prezentację z kształtem SmartArt.
1. Uzyskaj odwołanie do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty wewnątrz pierwszego slajdu.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt), jeśli jest to SmartArt.
1. Przejdź przez wszystkie [**Węzły**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArt#getAllNodes--) wewnątrz kształtu SmartArt.
1. Uzyskaj dostęp i wyświetl informacje, takie jak pozycja węzła SmartArt, poziom i tekst.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Pobierz pierwszy slajd
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Przejdź przez wszystkie kształty na pierwszym slajdzie
    for (IShape shape : slide.getShapes()) 
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Rzutuj kształt na SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Przejdź przez wszystkie węzły wewnątrz SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Uzyskiwanie węzła SmartArt o indeksie i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Wyświetlanie parametrów węzła SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dostęp do węzła podrzędnego SmartArt**
Poniższy przykładowy kod pomoże uzyskać dostęp do węzłów podrzędnych należących do odpowiednich węzłów kształtu SmartArt.

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation) i załaduj prezentację z kształtem SmartArt.
1. Uzyskaj odwołanie do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty wewnątrz pierwszego slajdu.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt), jeśli jest to SmartArt.
1. Przejdź przez wszystkie [**Węzły**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArt#getAllNodes--) wewnątrz kształtu SmartArt.
1. Dla każdego wybranego węzła kształtu SmartArt [**Węzeł**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArtNode), przejdź przez wszystkie [**Węzły podrzędne**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArtNode#getChildNodes--) wewnątrz konkretnego węzła.
1. Uzyskaj dostęp i wyświetl informacje, takie jak [**Węzeł podrzędny**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArtNode#getChildNodes--) pozycja, poziom i tekst.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Pobierz pierwszy slajd
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Przejdź przez wszystkie kształty na pierwszym slajdzie
    for (IShape shape : slide.getShapes()) 
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Rzutuj kształt na SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Przejdź przez wszystkie węzły wewnątrz SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Uzyskiwanie węzła SmartArt o indeksie i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Przeglądanie węzłów podrzędnych w węźle SmartArt o indeksie i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Uzyskiwanie węzła podrzędnego w węźle SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Wyświetlanie parametrów węzła podrzędnego SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dostęp do węzła podrzędnego SmartArt w określonej pozycji**
W tym przykładzie dowiemy się, jak uzyskać dostęp do węzłów podrzędnych w określonej pozycji należących do odpowiednich węzłów kształtu SmartArt.

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation) .
1. Uzyskaj odwołanie do pierwszego slajdu, używając jego indeksu.
1. Dodaj kształt [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArt) typu [**StackedList**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArtLayoutType#StackedList).
1. Uzyskaj dostęp do dodanego kształtu SmartArt.
1. Uzyskaj dostęp do węzła o indeksie 0 w uzyskanym kształcie SmartArt.
1. Teraz uzyskaj dostęp do [**Węzła podrzędnego**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArtNode#getChildNodes--) na pozycji 1 w uzyskanym węźle SmartArt, używając metody **get_Item()**.
1. Uzyskaj dostęp i wyświetl informacje, takie jak [**Węzeł podrzędny**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArtNode#getChildNodes--) pozycja, poziom i tekst.

```java
// Utwórz instancję prezentacji
Presentation pres = new Presentation();
try {
    // Uzyskiwanie pierwszego slajdu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Dodawanie kształtu SmartArt na pierwszym slajdzie
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Uzyskiwanie węzła SmartArt o indeksie 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Uzyskiwanie węzła podrzędnego na pozycji 1 w węźle nadrzędnym
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Wyświetlanie parametrów węzła podrzędnego SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Usuń węzeł SmartArt**
W tym przykładzie dowiemy się, jak usunąć węzły wewnątrz kształtu SmartArt.

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation) i załaduj prezentację z kształtem SmartArt.
1. Uzyskaj odwołanie do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty wewnątrz pierwszego slajdu.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt), jeśli jest to SmartArt.
1. Sprawdź, czy [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt) ma więcej niż 0 węzłów.
1. Wybierz węzeł SmartArt, który ma zostać usunięty.
1. Teraz usuń wybrany węzeł, używając metody [**RemoveNode**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .
1. Zapisz prezentację.

```java
// Wczytaj żądaną prezentację
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Przejdź przez wszystkie kształty na pierwszym slajdzie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Rzutuj kształt na SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Uzyskiwanie węzła SmartArt o indeksie 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Usuwanie wybranego węzła
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Zapisz prezentację
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Usuń węzeł SmartArt z określonej pozycji**
W tym przykładzie dowiemy się, jak usunąć węzły wewnątrz kształtu SmartArt w konkretnej pozycji.

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation) i załaduj prezentację z kształtem SmartArt.
1. Uzyskaj odwołanie do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty wewnątrz pierwszego slajdu.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt), jeśli jest to SmartArt.
1. Wybierz węzeł kształtu SmartArt o indeksie 0.
1. Teraz sprawdź, czy wybrany węzeł SmartArt ma więcej niż 2 węzły podrzędne.
1. Teraz usuń węzeł na **Pozycji 1** za pomocą [**RemoveNode**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) .
1. Zapisz prezentację.

```java
// Wczytaj żądaną prezentację
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Przejdź przez wszystkie kształty na pierwszym slajdzie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape instanceof SmartArt) 
        {
            // Rzutuj kształt na SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Uzyskiwanie węzła SmartArt o indeksie 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Usuwanie węzła podrzędnego na pozycji 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Zapisz prezentację
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw niestandardową pozycję dla węzła podrzędnego w obiekcie SmartArt**
Teraz Aspose.Slides dla Java obsługuje ustawianie właściwości [SmartArtShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape#setX-float-) i [Y](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape#setY-float-). Poniższy fragment kodu pokazuje, jak ustawić niestandardową pozycję, rozmiar i obrót SmartArtShape; należy również zauważyć, że dodawanie nowych węzłów powoduje przeliczenie pozycji i rozmiarów wszystkich węzłów. Dzięki ustawieniom niestandardowej pozycji użytkownik może ustawić węzły zgodnie z wymaganiami.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Przesuń kształt SmartArt do nowej pozycji
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Zmień szerokość kształtu SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Zmień wysokość kształtu SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Zmień obrót kształtu SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Sprawdź węzeł pomocniczy**
{{% alert color="primary" %}} 
W tym artykule dokładniej przyjrzymy się funkcjom kształtów SmartArt dodawanym programowo do slajdów prezentacji przy użyciu Aspose.Slides dla Java.
{{% /alert %}} 

Do naszych badań w różnych sekcjach tego artykułu użyjemy następującego źródłowego kształtu SmartArt.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Rysunek: Źródłowy kształt SmartArt na slajdzie**|

W poniższym przykładowym kodzie zbadamy, jak zidentyfikować **węzły pomocnicze** w kolekcji węzłów SmartArt oraz jak je zmienić.

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation) i załaduj prezentację z kształtem SmartArt.
1. Uzyskaj odwołanie do drugiego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty wewnątrz tego slajdu.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt), jeśli jest to SmartArt.
1. Przejdź przez wszystkie węzły wewnątrz kształtu SmartArt i sprawdź, czy są [**Węzłami pomocniczymi**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArtNode#isAssistant--).
1. Zmień status węzła pomocniczego na zwykły węzeł.
1. Zapisz prezentację.

```java
// Tworzenie instancji prezentacji
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Przejdź przez wszystkie kształty na pierwszym slajdzie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Rzutuj kształt na SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Przeglądanie wszystkich węzłów kształtu SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Sprawdź, czy węzeł jest węzłem pomocniczym
                if (node.isAssistant()) 
                {
                    // Ustawienie węzła pomocniczego na false i przekształcenie go w zwykły węzeł
                    node.isAssistant();
                }
            }
        }
    }
    
    // Zapisz prezentację
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Rysunek: Zmienione węzły pomocnicze w kształcie SmartArt na slajdzie**|

## **Ustaw format wypełnienia węzła**
Aspose.Slides for Java umożliwia dodawanie niestandardowych kształtów SmartArt i ustawianie ich formatu wypełnienia. Ten artykuł wyjaśnia, jak tworzyć i uzyskiwać dostęp do kształtów SmartArt oraz ustawiać ich format wypełnienia przy użyciu Aspose.Slides for Java.

Postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
1. Uzyskaj odwołanie do slajdu, używając jego indeksu.
1. Dodaj kształt [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArt) ustawiając jego [**LayoutType**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Ustaw [**FillFormat**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape#getFillFormat--) dla węzłów kształtu SmartArt.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
// Utwórz instancję prezentacji
Presentation pres = new Presentation();
try {
    // Uzyskiwanie slajdu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Dodawanie kształtu SmartArt i węzłów
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Ustawianie koloru wypełnienia węzła
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Zapisz prezentację
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Generuj miniaturę węzła podrzędnego SmartArt**
Programiści mogą wygenerować miniaturę węzła podrzędnego SmartArt, postępując zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
1. Dodaj [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Uzyskaj odwołanie do węzła, używając jego indeksu.
1. Pobierz obraz miniatury.
1. Zapisz obraz miniatury w dowolnym wybranym formacie obrazu.

```java
// Utwórz instancję klasy Presentation reprezentującej plik PPTX
Presentation pres = new Presentation();
try {
    // Dodaj SmartArt
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Uzyskaj odwołanie do węzła, używając jego indeksu
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Pobierz miniaturkę
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Zapisz miniaturkę
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy animacja SmartArt jest obsługiwana?**

Tak. SmartArt jest traktowany jako zwykły kształt, więc możesz [zastosować standardowe animacje](/slides/pl/java/shape-animation/) (wejścia, wyjścia, podkreślenia, ścieżki ruchu) i dostosować ich timing. Możesz również animować kształty wewnątrz węzłów SmartArt w razie potrzeby.

**Jak mogę wiarygodnie zlokalizować konkretny SmartArt na slajdzie, jeśli jego wewnętrzne ID jest nieznane?**

Przypisz i wyszukuj po [alternatywnym tekście](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getAlternativeText--). Ustawienie charakterystycznego AltText w SmartArt umożliwia jego programowe odnalezienie bez polegania na wewnętrznych identyfikatorach.

**Czy wygląd SmartArt zostanie zachowany przy konwersji prezentacji do PDF?**

Tak. Aspose.Slides renderuje SmartArt z wysoką wiernością wizualną podczas [eksportu do PDF](/slides/pl/java/convert-powerpoint-to-pdf/), zachowując układ, kolory i efekty.

**Czy mogę wyodrębnić obraz całego SmartArt (do podglądów lub raportów)?**

Tak. Możesz renderować kształt SmartArt do [formatów rastrowych](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getImage-int-float-float-) lub do [SVG](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) dla skalowalnego wyjścia wektorowego, co czyni go odpowiednim do miniatur, raportów lub użycia w sieci.