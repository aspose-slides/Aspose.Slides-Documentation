---
title: Zarządzanie węzłami kształtu SmartArt w prezentacjach na Androidzie
linktitle: Węzeł kształtu SmartArt
type: docs
weight: 30
url: /pl/androidjava/manage-smartart-shape-node/
keywords:
- węzeł SmartArt
- węzeł podrzędny
- dodaj węzeł
- pozycja węzła
- uzyskaj dostęp do węzła
- usuń węzeł
- niestandardowa pozycja
- węzeł asystenta
- format wypełnienia
- renderowanie węzła
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zarządzaj węzłami kształtu SmartArt w plikach PPT i PPTX za pomocą Aspose.Slides dla Androida. Uzyskaj przejrzyste przykłady kodu Java i wskazówki ułatwiające tworzenie prezentacji."
---
## **Przegląd**

Grafiki SmartArt w prezentacjach PowerPoint są organizowane za pomocą węzłów, które zawierają tekst i definiują strukturę diagramu. Aspose.Slides umożliwia programowe operowanie na tych węzłach SmartArt: dodawanie nowych węzłów i węzłów podrzędnych, wstawianie węzłów podrzędnych w określonej pozycji, dostęp do istniejących węzłów oraz odczytywanie ich tekstu, poziomu i pozycji.

Ten artykuł wyjaśnia, jak zarządzać węzłami kształtów SmartArt. Pokazuje, jak usuwać węzły, pracować z węzłami podrzędnymi według indeksu lub pozycji, zmienić węzeł asystenta na węzeł zwykły, dostosować pozycję, rozmiar i obrót kształtów węzłów SmartArt, ustawić formaty wypełnienia węzłów oraz wygenerować miniaturę obrazu dla węzła podrzędnego SmartArt.

## **Dodaj węzeł SmartArt**
Aspose.Slides for Android via Java udostępnia najprostsze API do zarządzania kształtami SmartArt w najłatwiejszy sposób. Poniższy przykładowy kod pomoże dodać węzeł i węzeł podrzędny wewnątrz kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) i załaduj prezentację z kształtem SmartArt.
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty na pierwszym slajdzie.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt), jeśli jest SmartArt.
1. [Add a new Node](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) w kształcie SmartArt [**NodeCollection**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) i ustaw tekst w TextFrame.
1. Teraz, [Add](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**Child Node**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) w nowo dodanym węźle [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt) i ustaw tekst w TextFrame
1. Zapisz prezentację.

```java
// Załaduj żądaną prezentację
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
    
            // Dodawanie nowego węzła podrzędnego w węźle nadrzędnym. Zostanie dodany na końcu kolekcji
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
W poniższym przykładzie kodu wyjaśniono, jak dodać węzły podrzędne należące do odpowiednich węzłów kształtu SmartArt w określonej pozycji.

1. Utwórz instancję klasy Presentation.
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Dodaj kształt [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArt) typu [**StackedList**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszego węzła w dodanym kształcie SmartArt
1. Teraz dodaj [**Child Node**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) dla wybranego [**Node**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtNode) na pozycji 2 i ustaw jego tekst.
1. Zapisz prezentację

```java
// Tworzenie instancji prezentacji
Presentation pres = new Presentation();
try {
    // Dostęp do slajdu prezentacji
    ISlide slide = pres.getSlides().get_Item(0);

    // Dodaj Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Dostęp do węzła SmartArt o indeksie 0
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

## **Uzyskaj dostęp do węzła SmartArt**
Poniższy przykładowy kod pomoże uzyskać dostęp do węzłów wewnątrz kształtu SmartArt. Należy pamiętać, że nie można zmienić właściwości LayoutType SmartArt, ponieważ jest ona tylko do odczytu i jest ustawiana wyłącznie przy dodawaniu kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) i załaduj prezentację z kształtem SmartArt.
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty na pierwszym slajdzie.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt), jeśli jest SmartArt.
1. Przejdź przez wszystkie [**Nodes**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArt#getAllNodes--) wewnątrz kształtu SmartArt.
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
                // Uzyskiwanie dostępu do węzła SmartArt o indeksie i
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

## **Uzyskaj dostęp do węzła podrzędnego SmartArt**
Poniższy przykładowy kod pomoże uzyskać dostęp do węzłów podrzędnych należących do odpowiednich węzłów kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) i załaduj prezentację z kształtem SmartArt.
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty na pierwszym slajdzie.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt), jeśli jest SmartArt.
1. Przejdź przez wszystkie [**Nodes**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArt#getAllNodes--) wewnątrz kształtu SmartArt.
1. Dla każdego wybranego [**Node**] kształtu SmartArt, przejdź przez wszystkie [**Child Nodes**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) wewnątrz danego węzła.
1. Uzyskaj dostęp i wyświetl informacje, takie jak pozycja [**Child Node**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) , poziom i tekst.

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
                // Uzyskiwanie dostępu do węzła SmartArt o indeksie i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Przechodzenie przez węzły podrzędne w węźle SmartArt o indeksie i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Uzyskiwanie dostępu do węzła podrzędnego w węźle SmartArt
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

## **Uzyskaj dostęp do węzła podrzędnego SmartArt w określonej pozycji**
W tym przykładzie nauczymy się uzyskiwać dostęp do węzłów podrzędnych w określonej pozycji należących do odpowiednich węzłów kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) .
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Dodaj kształt SmartArt typu [**StackedList**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList).
1. Uzyskaj dostęp do dodanego kształtu SmartArt.
1. Uzyskaj dostęp do węzła o indeksie 0 w wybranym kształcie SmartArt.
1. Teraz uzyskaj dostęp do [**Child Node**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) na pozycji 1 dla wybranego węzła SmartArt, używając metody **get_Item()**.
1. Uzyskaj dostęp i wyświetl informacje, takie jak pozycja [**Child Node**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) , poziom i tekst.

```java
// Utwórz instancję prezentacji
Presentation pres = new Presentation();
try {
    // Dostęp do pierwszego slajdu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Dodawanie kształtu SmartArt na pierwszym slajdzie
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Uzyskiwanie dostępu do węzła SmartArt o indeksie 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Uzyskiwanie dostępu do węzła podrzędnego na pozycji 1 w węźle nadrzędnym
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Wyświetlanie parametrów węzła podrzędnego SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Usuń węzeł SmartArt**
W tym przykładzie nauczymy się usuwać węzły wewnątrz kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) i załaduj prezentację z kształtem SmartArt.
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty na pierwszym slajdzie.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt), jeśli jest SmartArt.
1. Sprawdź, czy [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt) ma więcej niż 0 węzłów.
1. Wybierz węzeł SmartArt, który ma zostać usunięty.
1. Teraz usuń wybrany węzeł, używając metody [**RemoveNode**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).
1. Zapisz prezentację.

```java
// Załaduj żądaną prezentację
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
                // Uzyskiwanie dostępu do węzła SmartArt o indeksie 0
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
W tym przykładzie nauczymy się usuwać węzły wewnątrz kształtu SmartArt w konkretnej pozycji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) i załaduj prezentację z kształtem SmartArt.
1. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty na pierwszym slajdzie.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt), jeśli jest SmartArt.
1. Wybierz węzeł kształtu SmartArt o indeksie 0.
1. Teraz sprawdź, czy wybrany węzeł SmartArt ma więcej niż 2 węzły podrzędne.
1. Teraz usuń węzeł na **Position 1** za pomocą metody [**RemoveNode**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).
1. Zapisz prezentację.

```java
// Załaduj żądaną prezentację
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
                // Uzyskiwanie dostępu do węzła SmartArt o indeksie 0
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
Teraz Aspose.Slides for Android via Java obsługuje ustawianie właściwości [SmartArtShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShape#setX-float-) i [Y](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShape#setY-float-). Poniższy fragment kodu pokazuje, jak ustawić niestandardową pozycję, rozmiar i obrót SmartArtShape; należy również zauważyć, że dodawanie nowych węzłów powoduje przeliczenie pozycji i rozmiarów wszystkich węzłów. Dzięki ustawieniom niestandardowej pozycji użytkownik może dostosować węzły do własnych wymagań.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Przenieś kształt SmartArt na nową pozycję
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

## **Sprawdź węzeł asystenta**
{{% alert color="primary" %}} 

W tym artykule przyjrzymy się bliżej funkcjom kształtów SmartArt dodawanych do slajdów prezentacji programowo przy użyciu Aspose.Slides for Android via Java.

{{% /alert %}} 

Do naszych badań w różnych sekcjach tego artykułu użyjemy następującego źródłowego kształtu SmartArt.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Rysunek: źródłowy kształt SmartArt na slajdzie**|

W poniższym przykładzie kodu zbadamy, jak zidentyfikować **węzły asystenta** w kolekcji węzłów SmartArt i jak je zmienić.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) i załaduj prezentację z kształtem SmartArt.
1. Uzyskaj referencję do drugiego slajdu, używając jego indeksu.
1. Przejdź przez wszystkie kształty na pierwszym slajdzie.
1. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt), jeśli jest SmartArt.
1. Przejdź przez wszystkie węzły w kształcie SmartArt i sprawdź, czy są [**Assistant Nodes**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).
1. Zmieni status węzła asystenta na węzeł normalny.
1. Zapisz prezentację.

```java
// Tworzenie instancji prezentacji
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Przechodzenie przez wszystkie kształty na pierwszym slajdzie
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Rzutuj kształt na SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Przechodzenie przez wszystkie węzły kształtu SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Sprawdź, czy węzeł jest węzłem asystenta
                if (node.isAssistant()) 
                {
                    // Ustawienie węzła asystenta na false i przekształcenie go w węzeł normalny
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
|**Rysunek: zmienione węzły asystenta w kształcie SmartArt na slajdzie**|

## **Ustaw format wypełnienia węzła**
Aspose.Slides for Android via Java umożliwia dodawanie niestandardowych kształtów SmartArt i ustawianie ich formatu wypełnienia. Ten artykuł wyjaśnia, jak tworzyć i uzyskiwać dostęp do kształtów SmartArt oraz jak ustawiać ich format wypełnienia przy użyciu Aspose.Slides for Android via Java.

Proszę wykonać następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj kształt [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt), ustawiając jego [**LayoutType**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Ustaw [**FillFormat**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShape#getFillFormat--) dla węzłów kształtu SmartArt.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
// Utwórz instancję prezentacji
Presentation pres = new Presentation();
try {
    // Dostęp do slajdu
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

## **Wygeneruj miniaturę węzła podrzędnego SmartArt**
Programiści mogą wygenerować miniaturę węzła podrzędnego SmartArt, postępując zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. [Add SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Uzyskaj referencję do węzła, używając jego indeksu
1. Pobierz obraz miniatury.
1. Zapisz obraz miniatury w wybranym formacie obrazu.

```java
// Utwórz klasę Presentation reprezentującą plik PPTX 
Presentation pres = new Presentation();
try {
    // Dodaj SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Uzyskaj referencję do węzła za pomocą jego indeksu  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Pobierz miniaturę
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Zapisz miniaturę
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

**Czy animacje SmartArt są obsługiwane?**

Tak. SmartArt jest traktowany jako zwykły kształt, więc możesz [zastosować standardowe animacje](/slides/pl/androidjava/shape-animation/) (wejścia, wyjścia, podkreślenia, ścieżki ruchu) i dostosować ich czas. W razie potrzeby możesz również animować kształty wewnątrz węzłów SmartArt.

**Jak mogę niezawodnie zlokalizować konkretny SmartArt na slajdzie, jeśli jego wewnętrzny identyfikator jest nieznany?**

Przypisz i wyszukaj po [alternatywnym tekście](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getAlternativeText--). Ustawienie wyróżniającego się AltText w SmartArt pozwala znaleźć go programowo bez polegania na wewnętrznych identyfikatorach.

**Czy wygląd SmartArt zostanie zachowany przy konwersji prezentacji do PDF?**

Tak. Aspose.Slides renderuje SmartArt z wysoką wiernością wizualną podczas [eksportu do PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/), zachowując układ, kolory i efekty.

**Czy mogę wyodrębnić obraz całego SmartArt (do podglądów lub raportów)?**

Tak. Możesz renderować kształt SmartArt do [formatów rastrowych](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) lub do [SVG](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), co umożliwia uzyskanie skalowalnego wyjścia wektorowego, przydatnego do miniatur, raportów lub zastosowań internetowych.