---
title: Automatyczna aktualizacja obiektów OLE przy użyciu dodatku PowerPoint
type: docs
weight: 10
url: /pl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- obiekt OLE
- aktualizacja OLE
- automatycznie
- dodatek
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Odkryj, jak automatycznie aktualizować wykresy i obiekty OLE w PowerPoint przy użyciu dodatku i Aspose.Slides for .NET, z praktycznym kodem i wskazówkami optymalizacji."
---
## **Wstęp**

Jednym z najczęstszych pytań zadawanych przez klientów Aspose.Slides for .NET jest, jak utworzyć lub zmodyfikować edytowalne wykresy (lub inne obiekty OLE), aby aktualizowały się automatycznie po otwarciu prezentacji. Niestety PowerPoint nie obsługuje automatycznych makr w taki sam sposób, jak Excel i Word. Jedynymi dostępnymi makrami są `Auto_Open` i `Auto_Close`, i działają automatycznie tylko z dodatkiem. Ten krótki techniczny tip pokazuje, jak to osiągnąć.

## **Automatyczna aktualizacja obiektów OLE**

Najpierw dostępne są różne darmowe dodatki, które dodają funkcję makra Auto_Open do PowerPoint, na przykład [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) i [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Po zainstalowaniu jednego z tych dodatków, po prostu dodaj makro `Auto_Open()` (lub `OnPresentationOpen()`, jeśli używasz Event Generator) do szablonu prezentacji, jak pokazano poniżej:

```cs
public void Auto_Open()
{
    // Iteruj przez każdy slajd w prezentacji.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // Iteruj przez wszystkie kształty na bieżącym slajdzie.
        foreach (var oShape in oSlide.Shapes)
        {
            // Sprawdź, czy kształt jest obiektem OLE.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // Znaleziono obiekt OLE. Pobierz jego referencję i zaktualizuj go.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Teraz zakończ program serwera OLE.
                // Zwolni to pamięć i zapobiega problemom.
                // Ponadto ustaw oObject na Nothing, aby zwolnić obiekt.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

Wszelkie zmiany w obiektach OLE przy użyciu Aspose.Slides for .NET będą automatycznie aktualizowane, gdy PowerPoint otworzy prezentację. Jeśli masz wiele obiektów OLE i nie chcesz ich wszystkich aktualizować, po prostu dodaj niestandardowy znacznik do kształtów, które trzeba przetworzyć i sprawdź go w makrze.