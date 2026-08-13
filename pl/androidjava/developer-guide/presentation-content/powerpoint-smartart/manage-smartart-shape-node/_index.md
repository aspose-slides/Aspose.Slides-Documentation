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
- dostęp do węzła
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
description: "Zarządzaj węzłami kształtu SmartArt w plikach PPT i PPTX przy użyciu Aspose.Slides dla Androida. Uzyskaj przejrzyste przykłady kodu Java oraz wskazówki ułatwiające tworzenie prezentacji."
---
## **Przegląd**

Grafiki SmartArt w prezentacjach PowerPoint są organizowane za pomocą węzłów zawierających tekst i definiujących strukturę diagramu. Aspose.Slides umożliwia programowe operowanie na tych węzłach SmartArt: dodawanie nowych węzłów i węzłów podrzędnych, wstawianie węzłów podrzędnych w określonej pozycji, dostęp do istniejących węzłów oraz odczytywanie ich tekstu, poziomu i pozycji.

Ten artykuł wyjaśnia, jak zarządzać węzłami kształtów SmartArt. Pokazuje, jak usuwać węzły, pracować z węzłami podrzędnymi według indeksu lub pozycji, zmienić węzeł asystenta na węzeł normalny, dostosować pozycję, rozmiar i obrót kształtów węzłów SmartArt, ustawić format wypełnienia węzła oraz wygenerować miniaturę węzła SmartArt.

## **Dodawanie węzła SmartArt**
Aspose.Slides for Android via Java udostępnia najprostsze API do zarządzania kształtami SmartArt w najłatwiejszy sposób. Poniższy przykładowy kod pomoże dodać węzeł i węzeł podrzędny wewnątrz kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) i wczytaj prezentację z kształtem SmartArt.  
2. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.  
3. Przejdź przez wszystkie kształty na pierwszym slajdzie.  
4. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt) i rzutuj wybrany kształt na [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt), jeśli jest to SmartArt.  
5. [Dodaj nowy węzeł](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) w kolekcji węzłów SmartArt **NodeCollection**([https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt#getAllNodes--]) i ustaw tekst w TextFrame.  
6. Następnie [dodaj](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) **węzeł podrzędny**([https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--]) do nowo dodanego węzła SmartArt i ustaw tekst w TextFrame.  
7. Zapisz prezentację.

```java
import com.aspose.slides.*;

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
    
            // Dodawanie nowego węzła podrzędnego do węzła nadrzędnego. Zostanie dodany na końcu kolekcji
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

## **Dodawanie węzła SmartArt w określonej pozycji**
W poniższym przykładowym kodzie wyjaśniono, jak dodać węzły podrzędne należące do odpowiednich węzłów kształtu SmartArt w określonej pozycji.

1. Utwórz instancję klasy [Presentation].  
2. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.  
3. Dodaj kształt SmartArt typu [**StackedList**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) na wybranym slajdzie.  
4. Uzyskaj dostęp do pierwszego węzła w dodanym kształcie SmartArt.  
5. Teraz dodaj **węzeł podrzędny**([https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--]) dla wybranego **węzła**([https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtNode]) na pozycji 2 i ustaw jego tekst.  
6. Zapisz prezentację.

```java
import com.aspose.slides.*;

// Tworzenie instancji prezentacji
Presentation pres = new Presentation();
try {
    // Dostęp do slajdu prezentacji
    ISlide slide = pres.getSlides().get_Item(0);

    // Dodaj IShape Smart Art
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
Poniższy przykładowy kod pomoże uzyskać dostęp do węzłów wewnątrz kształtu SmartArt. Należy pamiętać, że LayoutType SmartArt jest wybierany w momencie dodawania kształtu; zmiana go później metodą **setLayout** powoduje przebudowę całego diagramu, więc pozycje i rozmiary węzłów, które mogłeś ustawić, są przeliczane ponownie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) i wczytaj prezentację z kształtem SmartArt.  
2. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.  
3. Przejdź przez wszystkie kształty na pierwszym slajdzie.  
4. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt) i rzutuj go na [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt), jeśli jest to SmartArt.  
5. Przejdź przez wszystkie **węzły**([https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArt#getAllNodes--]) wewnątrz kształtu SmartArt.  
6. Uzyskaj dostęp i wyświetl informacje, takie jak pozycja węzła SmartArt, poziom i tekst.

```java
import com.aspose.slides.*;

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
                // Dostęp do węzła SmartArt o indeksie i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Wypisywanie parametrów węzła SmartArt
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

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) i wczytaj prezentację z kształtem SmartArt.  
2. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.  
3. Przejdź przez wszystkie kształty na pierwszym slajdzie.  
4. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt) i rzutuj go na [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt), jeśli jest to SmartArt.  
5. Przejdź przez wszystkie **węzły**([https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArt#getAllNodes--]) wewnątrz kształtu SmartArt.  
6. Dla każdego wybranego **węzła**([https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtNode]) przejdź przez wszystkie **węzły podrzędne**([https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--]) w danym węźle.  
7. Uzyskaj dostęp i wyświetl informacje, takie jak pozycja, poziom i tekst **węzła podrzędnego**([https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--]).

```java
import com.aspose.slides.*;

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
                // Dostęp do węzła SmartArt o indeksie i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Przeglądanie węzłów podrzędnych w węźle SmartArt o indeksie i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Dostęp do węzła podrzędnego w węźle SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Wypisywanie parametrów węzła podrzędnego SmartArt
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
W tym przykładzie nauczymy się uzyskiwać dostęp do węzłów podrzędnych w określonych pozycjach, należących do odpowiednich węzłów kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).  
2. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.  
3. Dodaj kształt SmartArt typu [**StackedList**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList).  
4. Uzyskaj dostęp do dodanego kształtu SmartArt.  
5. Uzyskaj dostęp do węzła o indeksie 0 w tym kształcie.  
6. Następnie uzyskaj dostęp do **węzła podrzędnego**([https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--]) na pozycji 1 dla wybranego węzła SmartArt, używając metody **get_Item()**.  
7. Wyświetl informacje, takie jak pozycja, poziom i tekst **węzła podrzędnego**([https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--]).

```java
import com.aspose.slides.*;

// Utwórz instancję prezentacji
Presentation pres = new Presentation();
try {
    // Dostęp do pierwszego slajdu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Dodawanie kształtu SmartArt na pierwszym slajdzie
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Dostęp do węzła SmartArt o indeksie 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Dostęp do węzła podrzędnego na pozycji 1 w węźle nadrzędnym
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Wyświetlanie parametrów węzła podrzędnego SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Usuwanie węzła SmartArt**
W tym przykładzie nauczymy się usuwać węzły wewnątrz kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) i wczytaj prezentację z kształtem SmartArt.  
2. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.  
3. Przejdź przez wszystkie kształty na pierwszym slajdzie.  
4. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt) i rzutuj go na [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt), jeśli jest to SmartArt.  
5. Sprawdź, czy [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt) zawiera więcej niż 0 węzłów.  
6. Wybierz węzeł SmartArt do usunięcia.  
7. Usuń wybrany węzeł, używając metody [**RemoveNode**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
8. Zapisz prezentację.

```java
import com.aspose.slides.*;

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
                // Dostęp do węzła SmartArt o indeksie 0
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

## **Usuwanie węzła SmartArt z określonej pozycji**
W tym przykładzie nauczymy się usuwać węzły wewnątrz kształtu SmartArt w określonej pozycji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) i wczytaj prezentację z kształtem SmartArt.  
2. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.  
3. Przejdź przez wszystkie kształty na pierwszym slajdzie.  
4. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt) i rzutuj go na [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt), jeśli jest to SmartArt.  
5. Wybierz węzeł kształtu SmartArt o indeksie 0.  
6. Sprawdź, czy wybrany węzeł SmartArt ma więcej niż 2 węzły podrzędne.  
7. Usuń węzeł na **pozycji 1**, używając metody [**RemoveNode**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
8. Zapisz prezentację.

```java
import com.aspose.slides.*;

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
                // Dostęp do węzła SmartArt o indeksie 0
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

## **Ustawienie własnej pozycji dla węzła podrzędnego w obiekcie SmartArt**
Aspose.Slides for Android via Java wspiera ustawianie właściwości [SmartArtShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtShape) **X**([https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShape#setX-float-]) i **Y**([https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShape#setY-float-]). Poniższy fragment kodu pokazuje, jak ustawić własną pozycję, rozmiar i obrót SmartArtShape; należy również pamiętać, że dodanie nowych węzłów powoduje przeliczenie pozycji i rozmiarów wszystkich węzłów. Dzięki własnym ustawieniom pozycji użytkownik może dostosować węzły do własnych wymagań.

```java
import com.aspose.slides.*;

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

## **Sprawdzanie węzła asystenta**
{{% alert color="info" %}} 

W tym artykule bliżej przyjrzymy się funkcjom kształtów SmartArt dodawanym programowo do slajdów prezentacji przy użyciu Aspose.Slides for Android via Java.

{{% /alert %}} 

Do badania użyjemy następującego źródłowego kształtu SmartArt w różnych sekcjach tego artykułu.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Rysunek: Źródłowy kształt SmartArt na slajdzie**|

W poniższym przykładowym kodzie zbadamy, jak identyfikować **węzły asystenta** w kolekcji węzłów SmartArt i jak je zmieniać.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) i wczytaj prezentację z kształtem SmartArt.  
2. Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.  
3. Przejdź przez wszystkie kształty na pierwszym slajdzie.  
4. Sprawdź, czy kształt jest typu [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt) i rzutuj go na [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt), jeśli jest to SmartArt.  
5. Przejdź przez wszystkie węzły w kształcie SmartArt i sprawdź, czy są to [**węzły asystenta**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).  
6. Zmień status węzła asystenta na węzeł normalny.  
7. Zapisz prezentację.

```java
import com.aspose.slides.*;

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
                // Sprawdź, czy węzeł jest węzłem asystenta
                if (node.isAssistant()) 
                {
                    // Ustawienie właściwości Assistant na false i przekształcenie w węzeł normalny
                    node.setAssistant(false);
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
|**Rysunek: Węzły asystenta zmienione w kształcie SmartArt na slajdzie**|

## **Ustawienie formatu wypełnienia węzła**
Aspose.Slides for Android via Java umożliwia dodawanie niestandardowych kształtów SmartArt i ustawianie ich formatu wypełnienia. Ten artykuł wyjaśnia, jak tworzyć i uzyskiwać dostęp do kształtów SmartArt oraz ustawiać ich format wypełnienia przy użyciu Aspose.Slides for Android via Java.

Proszę wykonać następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).  
2. Uzyskaj referencję do slajdu, używając jego indeksu.  
3. Dodaj kształt [SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArt), ustawiając jego [**LayoutType**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
4. Ustaw [**FillFormat**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShape#getFillFormat--) dla węzłów kształtu SmartArt.  
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Generowanie miniatury węzła SmartArt**
Programiści mogą wygenerować miniaturę węzła SmartArt, postępując zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).  
2. [Dodaj SmartArt](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
3. Uzyskaj referencję do węzła, używając jego indeksu.  
4. Pobierz obraz miniatury.  
5. Zapisz obraz miniatury w wybranym formacie graficznym.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Dodaj SmartArt
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Uzyskaj referencję do węzła, używając jego indeksu  
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

### Czy animacje SmartArt są obsługiwane?

Tak. SmartArt jest traktowany jak zwykły kształt, więc możesz [zastosować standardowe animacje](/slides/pl/androidjava/shape-animation/) (wejście, zakończenie, podkreślenie, ścieżki ruchu) i dostosować ich timing. W razie potrzeby można także animować kształty wewnątrz węzłów SmartArt.

### Jak mogę niezawodnie zlokalizować konkretny SmartArt na slajdzie, jeśli nie znam jego wewnętrznego identyfikatora?

Przypisz i wyszukuj po [alternatywnym tekście](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getAlternativeText--). Ustawiając charakterystyczny AltText na SmartArt, możesz go odnaleźć programowo, nie polegając na wewnętrznych identyfikatorach.

### Czy wygląd SmartArt zostanie zachowany przy konwersji prezentacji do PDF?

Tak. Aspose.Slides renderuje SmartArt z wysoką wiernością wizualną podczas [eksportu do PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/), zachowując układ, kolory i efekty.

### Czy mogę wyodrębnić obraz całego SmartArt (do podglądów lub raportów)?

Tak. Możesz renderować kształt SmartArt do [formatów rastrowych](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) lub do [SVG](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) dla wektorowego wyjścia, co nadaje się do miniatur, raportów lub zastosowań internetowych.