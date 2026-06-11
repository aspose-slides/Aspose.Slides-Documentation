---
title: Konwertuj prezentacje PowerPoint do XPS w .NET
linktitle: PowerPoint do XPS
type: docs
weight: 70
url: /pl/net/convert-powerpoint-to-xps/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do XPS
- prezentacja do XPS
- slajd do XPS
- PPT do XPS
- PPTX do XPS
- zapisz PPT jako XPS
- zapisz PPTX jako XPS
- eksportuj PPT do XPS
- eksportuj PPTX do XPS
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Konwertuj pliki PowerPoint PPT/PPTX na wysokiej jakości, niezależny od platformy XPS w .NET przy użyciu Aspose.Slides. Uzyskaj przewodnik krok po kroku oraz przykładowy kod C#."
---
## **Przegląd**

Aspose.Slides umożliwia konwersję prezentacji PowerPoint do formatu XPS poprzez zapis pliku PPT lub PPTX w formacie XPS. Ten artykuł wyjaśnia, kiedy format XPS może być przydatny i pokazuje, jak wykonać konwersję przy użyciu Aspose.Slides, korzystając z domyślnych ustawień lub niestandardowych ustawień [XpsOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/xpsoptions/).

## **O XPS**

Microsoft opracował [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternatywę dla [PDF](https://docs.fileformat.com/pdf/). Umożliwia on drukowanie treści poprzez wygenerowanie pliku bardzo podobnego do PDF. Format XPS opiera się na XML. Układ lub struktura pliku XPS pozostaje taka sama na wszystkich systemach operacyjnych i drukarkach. 

## **Kiedy używać formatu Microsoft XPS**

{{% alert color="primary" %}} 

Aby zobaczyć, jak Aspose.Slides konwertuje prezentację PPT lub PPTX do formatu XPS, możesz sprawdzić [tę darmową aplikację konwertera online](https://products.aspose.app/slides/pl/conversion). 

{{% /alert %}} 

Jeśli chcesz zmniejszyć koszty przechowywania, możesz przekonwertować swoją prezentację Microsoft PowerPoint do formatu XPS. Dzięki temu łatwiej będzie zapisywać, udostępniać i drukować dokumenty. 

Microsoft nadal zapewnia silne wsparcie dla XPS w systemie Windows (nawet w Windows 10), więc warto rozważyć zapisywanie plików w tym formacie. Jeśli pracujesz z Windows 8.1, Windows 8, Windows 7 lub Windows Vista, XPS może być najlepszą opcją dla niektórych operacji. 

- **Windows 8** używa formatu OXPS (Open XPS) dla plików XPS. OXPS jest ustandaryzowaną wersją oryginalnego formatu XPS. Windows 8 zapewnia lepsze wsparcie dla plików XPS niż dla plików PDF. 
  - **XPS:** Wbudowana przeglądarka/odczytywacz XPS i dostępna funkcja drukowania do XPS. 
  - **PDF:** Dostępny czytnik PDF, ale brak funkcji drukowania do PDF. 

- **Windows 7 i Windows Vista** używają oryginalnego formatu XPS. Te systemy operacyjne również zapewniają lepsze wsparcie dla plików XPS niż dla plików PDF. 
  - **XPS:** Wbudowana przeglądarka XPS i dostępna funkcja drukowania do XPS. 
  - **PDF:** Brak czytnika PDF. Brak funkcji drukowania do PDF. 

|<p>**Wejście PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Wyjście XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ostatecznie wprowadził obsługę operacji drukowania w formacie PDF poprzez funkcję Drukuj do PDF w Windows 10. Wcześniej użytkownicy byli zmuszeni drukować dokumenty za pośrednictwem formatu XPS. 

## **Konwersja XPS za pomocą Aspose.Slides**

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/net/) dla .NET możesz użyć metody [**Save**](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/methods/save/index) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation), aby przekonwertować całą prezentację na dokument XPS. 

Podczas konwersji prezentacji do XPS musisz zapisać prezentację, używając jednego z tych ustawień:

- Ustawienia domyślne (bez [**XPSOptions**](https://reference.aspose.com/slides/pl/net/aspose.slides.export/xpsoptions))
- Ustawienia niestandardowe (z [**XPSOptions**](https://reference.aspose.com/slides/pl/net/aspose.slides.export/xpsoptions))

### **Konwertuj prezentacje do XPS przy użyciu ustawień domyślnych**

Ten przykładowy kod w C# pokazuje, jak przekonwertować prezentację na dokument XPS przy użyciu standardowych ustawień:

```c#
 // Utwórz obiekt Presentation, który reprezentuje plik prezentacji
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Zapisywanie prezentacji do dokumentu XPS
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **Konwertuj prezentacje do XPS przy użyciu ustawień niestandardowych**

Ten przykładowy kod pokazuje, jak przekonwertować prezentację na dokument XPS przy użyciu niestandardowych ustawień w C#:

```c#
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Utwórz instancję klasy XpsOptions
    XpsOptions options = new XpsOptions();

    // Zapisz metafile jako PNG
    options.SaveMetafilesAsPng = true;

    // Zapisz prezentację do dokumentu XPS
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **FAQ**

**Czy mogę zapisać XPS do strumienia zamiast do pliku?**

Tak — Aspose.Slides umożliwia eksport bezpośrednio do strumienia, co jest idealne dla interfejsów API sieciowych, potoków po stronie serwera lub każdego scenariusza, w którym chcesz przesłać XPS bez korzystania z systemu plików.

**Czy ukryte slajdy są przenoszone do XPS i czy mogę je wykluczyć?**

Domyślnie renderowane są tylko zwykłe (widoczne) slajdy. Możesz [dołączyć lub wykluczyć ukryte slajdy](https://reference.aspose.com/slides/pl/net/aspose.slides.export/xpsoptions/showhiddenslides/) poprzez [ustawienia eksportu](https://reference.aspose.com/slides/pl/net/aspose.slides.export/xpsoptions/) przed zapisaniem do XPS, zapewniając, że wynik zawiera dokładnie te strony, które zamierzasz.