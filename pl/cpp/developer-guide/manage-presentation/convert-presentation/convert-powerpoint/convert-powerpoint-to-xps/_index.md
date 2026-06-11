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
description: "Konwertuj PowerPoint PPT/PPTX do wysokiej jakości, niezależnego od platformy XPS w C++ przy użyciu Aspose.Slides. Uzyskaj krok po kroku instrukcję i przykładowy kod."
---
## **Przegląd**

Aspose.Slides umożliwia konwertowanie prezentacji PowerPoint do XPS poprzez zapisanie pliku PPT lub PPTX w formacie XPS. Ten artykuł wyjaśnia, kiedy format XPS może być przydatny oraz pokazuje, jak wykonać konwersję przy użyciu Aspose.Slides, korzystając z ustawień domyślnych lub niestandardowych ustawień [XpsOptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/xpsoptions/).

## **O XPS**

Microsoft opracował [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternatywę dla [PDF](https://docs.fileformat.com/pdf/). Umożliwia drukowanie treści poprzez wygenerowanie pliku bardzo podobnego do PDF. Format XPS oparty jest na XML. Układ lub struktura pliku XPS pozostaje taka sama na wszystkich systemach operacyjnych i drukarkach. 

## **Kiedy używać formatu Microsoft XPS**

{{% alert color="primary" %}} 

Aby zobaczyć, jak Aspose.Slides konwertuje prezentację PPT lub PPTX na format XPS, możesz sprawdzić [tę darmową aplikację do konwersji online](https://products.aspose.app/slides/pl/conversion). 

{{% /alert %}} 

Jeśli chcesz zmniejszyć koszty przechowywania, możesz przekonwertować swoją prezentację Microsoft PowerPoint do formatu XPS. Dzięki temu łatwiej będzie zapisywać, udostępniać i drukować dokumenty. 

Microsoft nadal intensywnie wspiera XPS w systemie Windows (nawet w Windows 10), więc warto rozważyć zapisywanie plików w tym formacie. Jeśli pracujesz z Windows 8.1, Windows 8, Windows 7 lub Windows Vista, XPS może być najlepszą opcją w niektórych scenariuszach. 

- **Windows 8** używa formatu OXPS (Open XPS) dla plików XPS. OXPS jest ustandaryzowaną wersją pierwotnego formatu XPS. Windows 8 zapewnia lepsze wsparcie dla plików XPS niż dla plików PDF. 
  - **XPS:** wbudowany podglądacz/odczytacz XPS oraz funkcja drukowania do XPS dostępna. 
  - **PDF:** dostępny czytnik PDF, ale brak funkcji drukowania do PDF. 

- **Windows 7 i Windows Vista** używają oryginalnego formatu XPS. Te systemy operacyjne również zapewniają lepsze wsparcie dla plików XPS niż dla PDF‑ów. 
  - **XPS:** wbudowany podglądacz XPS i funkcja drukowania do XPS dostępna. 
  - **PDF:** brak czytnika PDF. Brak funkcji drukowania do PDF. 

|<p>**Wejście PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Wyjście XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ostatecznie wprowadził obsługę drukowania do PDF za pomocą funkcji Print to PDF w Windows 10. Wcześniej użytkownicy musieli drukować dokumenty przy użyciu formatu XPS. 

## **Konwersja XPS przy użyciu Aspose.Slides**

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/cpp/) dla C++ możesz użyć metody [**Save**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation), aby przekonwertować całą prezentację na dokument XPS. 

Podczas konwertowania prezentacji do XPS należy zapisać prezentację przy użyciu jednej z następujących opcji:

- Ustawienia domyślne (bez [**XPSOptions**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.xps_options))
- Ustawienia niestandardowe (z [**XPSOptions**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.export.xps_options))

### **Konwertuj prezentacje do XPS przy użyciu ustawień domyślnych**

Ten przykładowy kod w C++ pokazuje, jak przekonwertować prezentację na dokument XPS przy użyciu standardowych ustawień:

``` cpp
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Zapis prezentacji do dokumentu XPS
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Konwertuj prezentacje do XPS przy użyciu ustawień niestandardowych**

Ten przykładowy kod pokazuje, jak przekonwertować prezentację na dokument XPS przy użyciu ustawień niestandardowych w C++:

``` cpp
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Utwórz obiekt klasy TiffOptions
auto options = System::MakeObject<XpsOptions>();

// Zapisz pliki Meta jako PNG
options->set_SaveMetafilesAsPng(true);

// Zapisz prezentację do dokumentu XPS
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **FAQ**

**Czy mogę zapisać XPS do strumienia zamiast do pliku?**

Tak — Aspose.Slides pozwala eksportować bezpośrednio do strumienia, co jest idealne dla interfejsów API sieciowych, potoków po stronie serwera lub dowolnego scenariusza, w którym chcesz przesłać XPS bez zapisywania go na dysku.

**Czy ukryte slajdy są przenoszone do XPS i czy mogę je wykluczyć?**

Domyślnie renderowane są tylko zwykłe (widoczne) slajdy. Możesz [uwzględnić lub wykluczyć ukryte slajdy](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) poprzez [ustawienia eksportu](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/xpsoptions/) przed zapisaniem do XPS, zapewniając, że wynikowy dokument zawiera dokładnie te strony, które zamierzasz.