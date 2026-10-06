---
title: Zarządzanie SmartArt w prezentacjach PowerPoint w .NET
linktitle: Zarządzaj SmartArt
type: docs
weight: 10
url: /pl/net/manage-smartart/
keywords:
- SmartArt
- tekst SmartArt
- typ układu
- ukryta właściwość
- diagram organizacyjny
- diagram organizacyjny ze zdjęciem
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i edytować SmartArt w programie PowerPoint za pomocą Aspose.Slides dla .NET, wykorzystując przejrzyste przykłady kodu C#, które przyspieszają projektowanie slajdów i automatyzację."
---
## **Przegląd**

SmartArt to diagram PowerPoint składający się z węzłów, kształtów węzłów i układu. Dzięki Aspose.Slides for .NET możesz tworzyć SmartArt, odczytywać tekst z jego węzłów, zmieniać jego układ, sprawdzać ukryte węzły, konfigurować układy wykresów organizacyjnych i tworzyć wykresy organizacyjne ze zdjęciami.

## **Pobieranie tekstu z obiektu SmartArt**

Węzeł SmartArt może zawierać jeden lub więcej kształtów. Aby odczytać tekst z kształtów węzła, iteruj przez [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/), a następnie odczytaj [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) zwrócony przez [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/).

Przykład wymaga prezentacji z co najmniej jednym slajdem i obiektem SmartArt jako pierwszym kształtem na tym slajdzie. Wypisuje każdą dostępną ramkę tekstową na konsolę.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **Zmiana typu układu obiektu SmartArt**

Układ SmartArt kontroluje sposób rozmieszczenia i połączenia węzłów. Poniższy przykład tworzy obiekt SmartArt z wartością `BasicBlockList` typu [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/), zmienia ją na wartość `BasicProcess` i zapisuje prezentację. Pozycja i rozmiar przekazywane do [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) są mierzone w punktach. Ustaw [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/), aby zmienić układ.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **Sprawdzenie, czy węzeł SmartArt jest ukryty**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) wskazuje, czy węzeł jest ukryty w modelu danych SmartArt. Ukryte węzły mogą istnieć w strukturze, nawet gdy wybrany układ nie wyświetla ich jako widoczne elementy diagramu.

Poniższy przykład dodaje węzeł do obiektu SmartArt, który używa wartości `RadialCycle` typu [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/), i sprawdza stan ukrycia dodanego węzła. Wypisuje komunikat, jeśli węzeł jest ukryty, i zapisuje diagram.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **Pobieranie lub ustawianie układu wykresu organizacyjnego**

W diagramach SmartArt używających układu wykresu organizacyjnego, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) określa, jak węzły podrzędne są rozmieszczane pod węzłem nadrzędnym. Na przykład możesz ustawić, aby węzły podrzędne zwisały po lewej, prawej lub po obu stronach, w zależności od wybranego [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/).

Poniższy przykład tworzy wykres organizacyjny i ustawia układ pierwszego węzła na wartość `LeftHanging` typu [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/). Indeks zerowy `0` wybiera pierwszy węzeł najwyższego poziomu; jego węzły podrzędne używają wybranego rozmieszczenia. Zmieniona prezentacja jest następnie zapisywana.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **Utworzenie wykresu organizacyjnego ze zdjęciem**

Wykres organizacyjny ze zdjęciem to układ SmartArt przeznaczony do diagramów hierarchii zawierających miejsca na obrazy. Użyj wartości `PictureOrganizationChart` typu [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) przy dodawaniu obiektu SmartArt do slajdu. Ten przykład zapisuje diagram z miejscami na obrazy; nie wypełnia tych miejsc obrazami.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **Konwersja starszych diagramów na grupy kształtów**

Podczas modernizacji istniejącej prezentacji może być konieczna aktualizacja wykresu organizacyjnego utworzonego pierwotnie w PowerPoint 97–2003. Aspose.Slides reprezentuje te starsze diagramy jako obiekty [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/). Użyj [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/), aby przekształcić diagram w grupę kształtów, co umożliwia edytowanie poszczególnych elementów wizualnych. Szczegóły znajdziesz w [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/).

Konwersja dodaje nową grupę do kolekcji kształtów bez usuwania oryginalnego diagramu. Po pomyślnej konwersji usuń oryginał za pomocą [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) , aby uniknąć duplikacji treści. Zbierz starsze diagramy w tablicę przed ich konwersją, aby dodawanie i usuwanie kształtów nie zakłócało iteracji.

Poniższy przykład otwiera prezentację, przeszukuje każdy slajd, konwertuje diagramy na grupy kształtów i zapisuje zaktualizowaną prezentację jako PPTX.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

Zapisana prezentacja zawiera edytowalne grupy kształtów zamiast skonwertowanych starszych diagramów, bez pozostawionych oryginalnych diagramów. Otwórz plik PPTX w programie PowerPoint, aby edytować poszczególne elementy w każdej grupie, takie jak tekst, wypełnienie czy pozycję.

## **FAQ**

**Czy SmartArt obsługuje odbicie lustrzane lub odwrócenie dla języków RTL?**

Tak. Właściwość [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) zmienia kierunek diagramu z lewej‑na‑prawą na prawą‑na‑lewej lub odwrotnie, gdy wybrany układ SmartArt obsługuje odwrócenie.

**Jak mogę skopiować SmartArt na ten sam slajd lub do innej prezentacji, zachowując formatowanie?**

Możesz [klonować kształt SmartArt](/slides/pl/net/shape-manipulations/) za pomocą [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) lub [klonować cały slajd](/slides/pl/net/clone-slides/) zawierający SmartArt. Oba podejścia zachowują rozmiar, pozycję i formatowanie.

**Jak renderować SmartArt do obrazu rastrowego w celu podglądu lub eksportu do sieci?**

[Renderuj slajd](/slides/pl/net/convert-powerpoint-to-png/) lub całą prezentację do PNG lub JPEG. SmartArt jest renderowany jako część slajdu.

**Jak mogę znaleźć konkretny obiekt SmartArt na slajdzie, jeśli jest ich kilka?**

Ustaw charakterystyczną wartość [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) lub [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) w kształcie SmartArt, poszukaj tej wartości w [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), a następnie sprawdź, czy pasujący kształt jest obiektem [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/).