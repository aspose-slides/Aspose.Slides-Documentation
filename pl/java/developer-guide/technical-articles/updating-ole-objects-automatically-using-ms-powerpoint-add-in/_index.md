---
title: Aktualizacja obiektów OLE automatycznie przy użyciu dodatku PowerPoint
type: docs
weight: 10
url: /pl/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- obiekt OLE
- aktualizacja OLE
- automatycznie
- dodatek
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Poznaj sposób automatycznej aktualizacji wykresów i obiektów OLE w PowerPoint przy użyciu dodatku oraz Aspose.Slides for Java, zawierający praktyczny kod i wskazówki optymalizacyjne."
---
## **Wprowadzenie**

Jednym z najczęściej zadawanych pytań przez klientów Aspose.Slides for Java jest, jak tworzyć lub modyfikować edytowalne wykresy (lub inne obiekty OLE), aby były automatycznie aktualizowane po otwarciu prezentacji. Niestety PowerPoint nie obsługuje automatycznych makr w taki sam sposób, jak Excel i Word. Dostępne są jedynie makra `Auto_Open` i `Auto_Close`, które uruchamiają się automatycznie tylko z dodatkiem. Ten krótki poradnik techniczny pokazuje, jak to osiągnąć.

## **Automatyczna aktualizacja obiektów OLE**

Najpierw dostępnych jest kilka darmowych dodatków, które dodają funkcję makra Auto_Open do PowerPointa, na przykład [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) i [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Po zainstalowaniu jednego z tych dodatków, po prostu dodaj makro `Auto_Open()` (lub `OnPresentationOpen()`, jeśli używasz Event Generator) do szablonu prezentacji, jak pokazano poniżej:

```java
// Iteruj przez każdy slajd w prezentacji.
for (var oSlide : ActivePresentation.Slides) {
    // Iteruj przez wszystkie kształty na bieżącym slajdzie.
    for (var oShape : oSlide.Shapes) {
        // Sprawdź, czy kształt jest obiektem OLE.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // Znaleziono obiekt OLE. Pobierz jego referencję i zaktualizuj go.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // Teraz zakończ program serwera OLE.
            // To zwalnia pamięć i zapobiega problemom.
            // Ustaw oObject na Nothing, aby zwolnić obiekt.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```

Wszelkie zmiany w obiektach OLE wprowadzone przy użyciu Aspose.Slides for Java będą automatycznie aktualizowane, gdy PowerPoint otworzy prezentację. Jeśli masz wiele obiektów OLE i nie chcesz aktualizować ich wszystkich, po prostu dodaj niestandardowy znacznik do kształtów, które mają być przetworzone, i sprawdź go w makrze.