---
title: Wyodrębnianie obiektów Flash z prezentacji na Androidzie
linktitle: Flash
type: docs
weight: 10
url: /pl/androidjava/flash/
keywords:
- wyodrębnić flash
- obiekt flash
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak wyodrębniać obiekty Flash z slajdów PowerPoint i OpenDocument w Javie przy użyciu Aspose.Slides dla Androida, kompletnych przykładów kodu i najlepszych praktyk."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak wyodrębnić obiekty Flash z prezentacji przy użyciu Aspose.Slides. Pokazuje, jak znaleźć kontrolkę Flash po nazwie w kolekcji kontroli slajdu i pracować z osadzonymi danymi obiektu SWF.

## **Wyodrębnianie obiektów Flash z prezentacji**

Aspose.Slides for Android via Java udostępnia funkcję wyodrębniania obiektów flash z prezentacji. Możesz uzyskać dostęp do kontrolki flash po nazwie i wyodrębnić ją z prezentacji, w tym przechowywać dane obiektu SWF.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jakie formaty prezentacji są obsługiwane przy wyodrębnianiu treści Flash?**

[Aspose.Slides supports](/slides/pl/androidjava/supported-file-formats/) główne formaty PowerPoint, takie jak PPT i PPTX, ponieważ może ładować te kontenery i uzyskiwać dostęp do ich kontroli, w tym elementów ActiveX związanych z Flash.

**Czy mogę przekonwertować prezentację z Flash na HTML5 i zachować interaktywność Flash?**

Nie. Aspose.Slides nie wykonuje zawartości SWF ani nie konwertuje jej interaktywności. Chociaż eksport do [HTML](/slides/pl/androidjava/convert-powerpoint-to-html/)/[HTML5](/slides/pl/androidjava/export-to-html5/) jest obsługiwany, Flash nie będzie odtwarzany w nowoczesnych przeglądarkach z powodu zakończenia wsparcia. Zalecaną ścieżką jest zastąpienie Flash alternatywami, takimi jak wideo lub animacje HTML5, przed eksportem.

**Z perspektywy bezpieczeństwa, czy Aspose.Slides wykonuje pliki SWF podczas odczytu prezentacji?**

Nie. Aspose.Slides traktuje Flash jako binarne dane osadzone w pliku i nie wykonuje zawartości SWF podczas przetwarzania.

**Jak powinienem obsługiwać prezentacje, które zawierają Flash wraz z innymi osadzonymi plikami przez OLE?**

Aspose.Slides obsługuje [extracting embedded OLE objects](/slides/pl/androidjava/manage-ole/), więc możesz przetwarzać całą powiązaną zawartość osadzoną w jednym przebiegu, obsługując kontrolki Flash i inne dokumenty osadzone przez OLE razem.