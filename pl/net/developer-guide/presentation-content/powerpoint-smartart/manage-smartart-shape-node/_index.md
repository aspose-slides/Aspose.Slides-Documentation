---
title: Zarządzanie węzłami kształtu SmartArt w prezentacjach w .NET
linktitle: Węzeł kształtu SmartArt
type: docs
weight: 30
url: /pl/net/manage-smartart-shape-node/
keywords:
- Węzeł SmartArt
- Węzeł podrzędny
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
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj węzłami kształtu SmartArt w plikach PPT i PPTX przy użyciu Aspose.Slides for .NET. Uzyskaj przejrzyste przykłady kodu i wskazówki ułatwiające tworzenie prezentacji."
---
## **Przegląd**

Grafiki SmartArt w prezentacjach PowerPoint są organizowane za pomocą węzłów zawierających tekst i definiujących strukturę diagramu. Aspose.Slides pozwala programowo pracować z tymi węzłami SmartArt: dodawać nowe węzły i węzły podrzędne, wstawiać węzły podrzędne w określonej pozycji, uzyskiwać dostęp do istniejących węzłów oraz odczytywać ich tekst, poziom i pozycję.

Ten artykuł wyjaśnia, jak zarządzać węzłami kształtów SmartArt. Pokazuje, jak usuwać węzły, pracować z węzłami podrzędnymi według indeksu lub pozycji, zmienić węzeł asystenta na węzeł normalny, dostosować pozycję, rozmiar i obrót kształtów węzła SmartArt, ustawić format wypełnienia węzła oraz wygenerować miniaturę węzła podrzędnego SmartArt.

## **Dodawanie węzła SmartArt**
Aspose.Slides for .NET udostępnia najprostsze API do zarządzania kształtami SmartArt w najłatwiejszy sposób. Poniższy przykładowy kod pomoże dodać węzeł i węzeł podrzędny wewnątrz kształtu SmartArt.

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) i wczytaj prezentację zawierającą kształt SmartArt.  
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.  
- Przejdź przez wszystkie kształty na pierwszym slajdzie.  
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli tak jest.  
- Dodaj nowy węzeł do kolekcji NodeCollection kształtu SmartArt i ustaw tekst w TextFrame.  
- Następnie dodaj węzeł podrzędny do nowo dodanego węzła SmartArt i ustaw tekst w TextFrame.  
- Zapisz prezentację.

```c#
// Wczytaj żądaną prezentację
Presentation pres = new Presentation("AddNodes.pptx");

// Przejdź przez wszystkie kształty na pierwszym slajdzie
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Sprawdź, czy kształt jest typu SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Rzutuj kształt na SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Dodawanie nowego węzła SmartArt
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Dodawanie tekstu
        TemNode.TextFrame.Text = "Test";

        // Dodawanie nowego węzła podrzędnego w węźle nadrzędnym. Zostanie on dodany na końcu kolekcji
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Dodawanie tekstu
        newNode.TextFrame.Text = "New Node Added";
    }
}

// Zapisywanie prezentacji
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Dodawanie węzła SmartArt w określonej pozycji**
W poniższym przykładowym kodzie wyjaśniamy, jak dodać węzły podrzędne należące do poszczególnych węzłów kształtu SmartArt w wybranej pozycji.

- Utwórz instancję klasy `Presentation`.  
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.  
- Dodaj kształt SmartArt typu StackedList na wybranym slajdzie.  
- Uzyskaj dostęp do pierwszego węzła w dodanym kształcie SmartArt.  
- Następnie dodaj węzeł podrzędny do wybranego węzła w pozycji 2 i ustaw jego tekst.  
- Zapisz prezentację.

```c#
// Tworzenie instancji prezentacji
Presentation pres = new Presentation();

// Dostęp do slajdu prezentacji
ISlide slide = pres.Slides[0];

// Dodaj Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Uzyskiwanie dostępu do węzła SmartArt o indeksie 0
ISmartArtNode node = smart.AllNodes[0];

// Dodawanie nowego węzła podrzędnego w pozycji 2 w węźle nadrzędnym
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Dodaj tekst
chNode.TextFrame.Text = "Sample Text Added";

// Zapisz prezentację
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Dostęp do węzła SmartArt**
Poniższy przykładowy kod pomoże uzyskać dostęp do węzłów wewnątrz kształtu SmartArt. Należy pamiętać, że nie można zmienić właściwości LayoutType SmartArt, ponieważ jest ona tylko do odczytu i ustawia się ją jedynie podczas dodawania kształtu SmartArt.

- Utwórz instancję klasy `Presentation` i wczytaj prezentację zawierającą kształt SmartArt.  
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.  
- Przejdź przez wszystkie kształty na pierwszym slajdzie.  
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli tak jest.  
- Przejdź przez wszystkie węzły wewnątrz kształtu SmartArt.  
- Uzyskaj dostęp i wyświetl informacje, takie jak pozycja węzła SmartArt, poziom oraz tekst.

```c#
  // Wczytaj żądaną prezentację
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Przejdź przez wszystkie kształty na pierwszym slajdzie
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Sprawdź, czy kształt jest typu SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Rzutuj kształt na SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Przejdź przez wszystkie węzły w SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Uzyskiwanie dostępu do węzła SmartArt o indeksie i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Wyświetlanie parametrów węzła SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
```

## **Dostęp do węzła podrzędnego SmartArt**
Poniższy przykładowy kod pomoże uzyskać dostęp do węzłów podrzędnych należących do poszczególnych węzłów kształtu SmartArt.

- Utwórz instancję klasy PresentationEx i wczytaj prezentację zawierającą kształt SmartArt.  
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.  
- Przejdź przez wszystkie kształty na pierwszym slajdzie.  
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArtEx, jeśli tak jest.  
- Przejdź przez wszystkie węzły wewnątrz kształtu SmartArt.  
- Dla każdego wybranego węzła kształtu SmartArt przejdź przez wszystkie węzły podrzędne w danym węźle.  
- Uzyskaj dostęp i wyświetl informacje, takie jak pozycja węzła podrzędnego, poziom oraz tekst.

```c#
// Wczytaj żądaną prezentację
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Przejdź przez wszystkie kształty na pierwszym slajdzie
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Sprawdź, czy kształt jest typu SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Rzutuj kształt na SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Przejdź przez wszystkie węzły w SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Uzyskiwanie dostępu do węzła SmartArt o indeksie i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Przechodzenie przez węzły podrzędne w węźle SmartArt o indeksie i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Uzyskiwanie dostępu do węzła podrzędnego w węźle SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Wyświetlanie parametrów węzła podrzędnego SmartArt
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```

## **Dostęp do węzła podrzędnego SmartArt w określonej pozycji**
W tym przykładzie nauczymy się uzyskiwać dostęp do węzłów podrzędnych w wybranej pozycji, należących do poszczególnych węzłów kształtu SmartArt.

- Utwórz instancję klasy `Presentation`.  
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.  
- Dodaj kształt SmartArt typu StackedList.  
- Uzyskaj dostęp do dodanego kształtu SmartArt.  
- Uzyskaj dostęp do węzła o indeksie 0 w tym kształcie SmartArt.  
- Następnie uzyskaj dostęp do węzła podrzędnego w pozycji 1 dla wybranego węzła SmartArt, używając metody GetNodeByPosition().  
- Uzyskaj dostęp i wyświetl informacje, takie jak pozycja węzła podrzędnego, poziom oraz tekst.

```c#
 // Utwórz instancję prezentacji
 Presentation pres = new Presentation();

 // Dostęp do pierwszego slajdu
 ISlide slide = pres.Slides[0];

 // Dodawanie kształtu SmartArt na pierwszym slajdzie
 ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

 // Uzyskiwanie dostępu do węzła SmartArt o indeksie 0
 ISmartArtNode node = smart.AllNodes[0];

 // Uzyskiwanie dostępu do węzła podrzędnego w pozycji 1 w węźle nadrzędnym
 int position = 1;
 SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

 // Wyświetlanie parametrów węzła podrzędnego SmartArt
 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
 Console.WriteLine(outString);
```

## **Usuwanie węzła SmartArt**
W tym przykładzie nauczymy się usuwać węzły wewnątrz kształtu SmartArt.

- Utwórz instancję klasy `Presentation` i wczytaj prezentację zawierającą kształt SmartArt.  
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.  
- Przejdź przez wszystkie kształty na pierwszym slajdzie.  
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli tak jest.  
- Sprawdź, czy SmartArt ma więcej niż 0 węzłów.  
- Wybierz węzeł SmartArt do usunięcia.  
- Następnie usuń wybrany węzeł, używając metody RemoveNode().  
- Zapisz prezentację.

```c#
// Wczytaj żądaną prezentację
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Przejdź przez wszystkie kształty na pierwszym slajdzie
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Sprawdź, czy kształt jest typu SmartArt
        if (shape is ISmartArt)
        {
            // Rzutuj kształt na SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Uzyskiwanie dostępu do węzła SmartArt o indeksie 0
                ISmartArtNode node = smart.AllNodes[0];

                // Usuwanie wybranego węzła
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Zapisz prezentację
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Usuwanie węzła SmartArt w określonej pozycji**
W tym przykładzie nauczymy się usuwać węzły wewnątrz kształtu SmartArt w wybranej pozycji.

- Utwórz instancję klasy `Presentation` i wczytaj prezentację zawierającą kształt SmartArt.  
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.  
- Przejdź przez wszystkie kształty na pierwszym slajdzie.  
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli tak jest.  
- Wybierz węzeł kształtu SmartArt o indeksie 0.  
- Następnie sprawdź, czy wybrany węzeł SmartArt ma więcej niż 2 węzły podrzędne.  
- Usuń węzeł w pozycji 1, używając metody RemoveNodeByPosition().  
- Zapisz prezentację.

```c#
 // Wczytaj żądaną prezentację             
 Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

 // Przejdź przez wszystkie kształty na pierwszym slajdzie
 foreach (IShape shape in pres.Slides[0].Shapes)
 {
     // Sprawdź, czy kształt jest typu SmartArt
     if (shape is Aspose.Slides.SmartArt.SmartArt)
     {
         // Rzutuj kształt na SmartArt
         Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

         if (smart.AllNodes.Count > 0)
         {
             // Uzyskiwanie dostępu do węzła SmartArt o indeksie 0
             Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

             if (node.ChildNodes.Count >= 2)
             {
                 // Usuwanie węzła podrzędnego w pozycji 1
                 ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
             }

         }
     }
 }

 // Zapisz prezentację
 pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Ustawienie niestandardowej pozycji dla węzła podrzędnego w obiekcie SmartArt**
Aspose.Slides for .NET obsługuje teraz ustawianie właściwości X i Y kształtu SmartArt. Poniższy fragment kodu pokazuje, jak ustawić niestandardową pozycję, rozmiar i obrót kształtu SmartArt; należy również pamiętać, że dodawanie nowych węzłów powoduje przeliczenie pozycji i rozmiarów wszystkich węzłów.

```c#
// Wczytaj żądaną prezentację
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Przesuń kształt SmartArt na nową pozycję
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Zmień szerokości kształtu SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Zmień wysokość kształtu SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Zmień obrót kształtu SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```

## **Sprawdzanie węzła asystenta**
W poniższym przykładowym kodzie badamy, jak zidentyfikować węzły asystenta w kolekcji węzłów SmartArt i jak je zmieniać.

- Utwórz instancję klasy PresentationEx i wczytaj prezentację zawierającą kształt SmartArt.  
- Uzyskaj referencję do drugiego slajdu, używając jego indeksu.  
- Przejdź przez wszystkie kształty na pierwszym slajdzie.  
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArtEx, jeśli tak jest.  
- Przejdź przez wszystkie węzły kształtu SmartArt i sprawdź, czy są węzłami asystenta.  
- Zmień status węzła asystenta na węzeł normalny.  
- Zapisz prezentację.

```c#
// Tworzenie instancji prezentacji
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Przejdź przez wszystkie kształty na pierwszym slajdzie
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Sprawdź, czy kształt jest typu SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Rzutuj kształt na SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Przechodzenie przez wszystkie węzły kształtu SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Sprawdź, czy węzeł jest węzłem asystenta
                if (node.IsAssistant)
                {
                    // Ustawianie węzła asystenta na false i przekształcenie go w węzeł normalny
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Zapisz prezentację
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Ustawienie formatu wypełnienia węzła**
Aspose.Slides for .NET umożliwia dodawanie niestandardowych kształtów SmartArt i ustawianie ich formatów wypełnienia. Ten artykuł wyjaśnia, jak tworzyć i uzyskiwać dostęp do kształtów SmartArt oraz jak ustawiać ich format wypełnienia przy użyciu Aspose.Slides for .NET.

Proszę wykonać następujące kroki:

- Utwórz instancję klasy `Presentation`.  
- Uzyskaj referencję do slajdu, używając jego indeksu.  
- Dodaj kształt SmartArt, określając jego LayoutType.  
- Ustaw FillFormat dla węzłów kształtu SmartArt.  
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

```c#
using (Presentation presentation = new Presentation())
{
    // Dostęp do slajdu
    ISlide slide = presentation.Slides[0];

    // Dodawanie kształtu SmartArt i węzłów
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Ustawianie koloru wypełnienia węzła
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Zapisywanie prezentacji
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```

## **Generowanie miniatury węzła podrzędnego SmartArt**
Programiści mogą wygenerować miniaturę węzła podrzędnego SmartArt, postępując według poniższych kroków:

1. Utwórz instancję klasy `Presentation`, która reprezentuje plik PPTX.  
2. Dodaj SmartArt.  
3. Uzyskaj referencję do węzła, używając jego indeksu.  
4. Pobierz obraz miniatury.  
5. Zapisz obraz miniatury w wybranym formacie graficznym.

Przykład poniżej generuje miniaturę węzła podrzędnego SmartArt

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```

## **FAQ**

**Czy obsługiwane są animacje SmartArt?**

Tak. SmartArt jest traktowany jak zwykły kształt, więc można [zastosować standardowe animacje](/slides/pl/net/shape-animation/) (wejścia, wyjścia, podkreślenia, ścieżki ruchu) i dostosować ich czas. W razie potrzeby można także animować kształty wewnątrz węzłów SmartArt.

**Jak niezawodnie zlokalizować konkretny SmartArt na slajdzie, gdy jego wewnętrzny identyfikator jest nieznany?**

Użyj i wyszukuj po [alternatywnym tekście]https://reference.aspose.com/slides/pl/net/aspose.slides/shape/alternativetext/. Ustawienie charakterystycznego AltText w SmartArt umożliwia jego programowe odnalezienie bez polegania na wewnętrznych identyfikatorach.

**Czy wygląd SmartArt zostanie zachowany przy konwersji prezentacji do PDF?**

Tak. Aspose.Slides renderuje SmartArt z wysoką wiernością wizualną podczas [eksportu do PDF](/slides/pl/net/convert-powerpoint-to-pdf/), zachowując układ, kolory i efekty.

**Czy mogę wyodrębnić obraz całego SmartArt (do podglądów lub raportów)?**

Tak. Można renderować kształt SmartArt do [formatów rastrowych]https://reference.aspose.com/slides/pl/net/aspose.slides/shape/getimage/ lub do [SVG]https://reference.aspose.com/slides/pl/net/aspose.slides/shape/writeassvg/ w celu uzyskania skalowalnego wektora, co jest przydatne przy miniaturach, raportach lub użyciu w sieci.