---
title: Konwertuj prezentacje PowerPoint do XPS w C++
linktitle: PowerPoint do XPS
type: docs
weight: 70
url: /pl/cpp/convert-powerpoint-to-xps
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
- C++
- Aspose.Slides
description: "Konwertuj pliki PowerPoint PPT/PPTX na wysokiej jakości, niezależny od platformy XPS w C++ przy użyciu Aspose.Slides. Uzyskaj krok po kroku przewodnik i przykładowy kod."
---
## **Przegląd**

Aspose.Slides umożliwia konwersję prezentacji PowerPoint do formatu XPS poprzez zapis pliku PPT lub PPTX w formacie XPS. Ten artykuł wyjaśnia, kiedy format XPS może być przydatny i pokazuje, jak wykonać konwersję przy użyciu Aspose.Slides, wykorzystując domyślne ustawienia lub niestandardowe ustawienia [XpsOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/xpsoptions/).

## **O XPS**

Microsoft opracowało [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternatywę dla [PDF](https://docs.fileformat.com/pdf/). Umożliwia on drukowanie treści poprzez wygenerowanie pliku bardzo podobnego do PDF. Format XPS oparty jest na XML. Układ lub struktura pliku XPS pozostaje taka sama na wszystkich systemach operacyjnych i drukarkach.

## **Kiedy używać formatu Microsoft XPS**

{{% alert color="info" %}} 

Aby zobaczyć, jak Aspose.Slides konwertuje prezentację PPT lub PPTX do formatu XPS, możesz sprawdzić [tę darmową aplikację do konwersji online](https://products.aspose.app/slides/pl/conversion). 

{{% /alert %}} 

Jeśli chcesz obniżyć koszty przechowywania, możesz przekonwertować swoją prezentację Microsoft PowerPoint do formatu XPS. Dzięki temu łatwiej będzie zapisywać, udostępniać i drukować dokumenty. 

Microsoft nadal zapewnia silne wsparcie dla XPS w systemie Windows (nawet w Windows 10), więc warto rozważyć zapisywanie plików w tym formacie. Jeśli pracujesz z Windows 8.1, Windows 8, Windows 7 lub Windows Vista, XPS może być najlepszą opcją w niektórych operacjach. 

- **Windows 8** używa formatu OXPS (Open XPS) dla plików XPS. OXPS jest ustandaryzowaną wersją oryginalnego formatu XPS. Windows 8 zapewnia lepsze wsparcie dla plików XPS niż dla plików PDF. 
  - **XPS:** wbudowana przeglądarka/odczytywacz XPS oraz możliwość drukowania do XPS dostępna. 
  - **PDF:** dostępny odczytywacz PDF, ale brak funkcji drukowania do PDF. 

- **Windows 7 i Windows Vista** używają oryginalnego formatu XPS. Te systemy operacyjne również zapewniają lepsze wsparcie dla plików XPS niż dla PDF. 
  - **XPS:** wbudowana przeglądarka XPS oraz możliwość drukowania do XPS dostępna. 
  - **PDF:** brak odczytywacza PDF. Brak funkcji drukowania do PDF. 

|<p>**Wejście PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Wyjście XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ostatecznie wprowadził obsługę operacji drukowania w formacie PDF poprzez funkcję Drukuj do PDF w Windows 10. Wcześniej użytkownicy byli zobowiązani do drukowania dokumentów za pośrednictwem formatu XPS. 

## **Konwersja XPS przy użyciu Aspose.Slides**

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/cpp/) dla C++ możesz użyć metody [**Save**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation), aby przekonwertować całą prezentację na dokument XPS. 

Podczas konwersji prezentacji do XPS musisz zapisać prezentację, używając jednej z poniższych konfiguracji:

- Ustawienia domyślne (bez [**XPSOptions**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.xps_options))
- Ustawienia niestandardowe (z [**XPSOptions**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.xps_options))

### **Konwertuj prezentacje do XPS przy użyciu ustawień domyślnych**

Ten przykładowy kod w C++ pokazuje, jak przekonwertować prezentację na dokument XPS przy użyciu standardowych ustawień:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instantiate a Presentation object that represents a presentation file
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Saving the presentation to XPS document
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Konwertuj prezentacje do XPS przy użyciu ustawień niestandardowych**

Ten przykładowy kod pokazuje, jak przekonwertować prezentację na dokument XPS przy użyciu ustawień niestandardowych w C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Utwórz obiekt klasy XpsOptions
auto options = System::MakeObject<XpsOptions>();

// Zapisz Metafiles jako PNG
options->set_SaveMetafilesAsPng(true);

// Zapisz prezentację jako dokument XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **FAQ**

### Czy mogę zapisać XPS do strumienia zamiast do pliku?

Tak — Aspose.Slides umożliwia eksport bezpośrednio do strumienia, co jest idealne dla interfejsów API webowych, potoków po stronie serwera lub każdego scenariusza, w którym chcesz przesłać XPS bez użycia systemu plików.

### Czy ukryte slajdy są przenoszone do XPS i czy mogę je wykluczyć?

Domyślnie renderowane są tylko zwykłe (widoczne) slajdy. Możesz [włączyć lub wyłączyć ukryte slajdy](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) poprzez [ustawienia eksportu](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/xpsoptions/) przed zapisaniem do XPS, zapewniając, że wynik zawiera dokładnie te strony, które zamierzasz.