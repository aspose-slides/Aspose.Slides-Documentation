---
title: Konwertuj prezentacje PowerPoint do XPS w Pythonie
linktitle: PowerPoint do XPS
type: docs
weight: 70
url: /pl/python-net/convert-powerpoint-to-xps/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- PowerPoint do XPS
- prezentacja do XPS
- PPT do XPS
- PPTX do XPS
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Konwertuj PowerPoint PPT/PPTX na wysokiej jakości, niezależny od platformy XPS w Pythonie przy użyciu Aspose.Slides. Uzyskaj przewodnik krok po kroku oraz przykładowy kod."
---
## **Przegląd**

Aspose.Slides pozwala konwertować prezentacje PowerPoint do formatu XPS, zapisując plik PPT lub PPTX w formacie XPS. Ten artykuł wyjaśnia, kiedy format XPS może być przydatny i pokazuje, jak wykonać konwersję przy użyciu Aspose.Slides zarówno z ustawieniami domyślnymi, jak i własnymi ustawieniami [XpsOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/xpsoptions/).

## **O XPS**
Microsoft opracował [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternatywę dla [PDF](https://docs.fileformat.com/pdf/). Umożliwia drukowanie treści poprzez wygenerowanie pliku bardzo podobnego do PDF. Format XPS opiera się na XML. Układ lub struktura pliku XPS pozostaje taka sama na wszystkich systemach operacyjnych i drukarkach. 

## Kiedy używać formatu Microsoft XPS

{{% alert color="primary" %}} 

Aby zobaczyć, jak Aspose.Slides konwertuje prezentację PPT lub PPTX do formatu XPS, możesz wypróbować [tę darmową aplikację do konwersji online](https://products.aspose.app/slides/pl/conversion). 

{{% /alert %}} 

Jeśli chcesz zmniejszyć koszty przechowywania, możesz przekonwertować prezentację Microsoft PowerPoint do formatu XPS. Dzięki temu łatwiej będzie zapisywać, udostępniać i drukować dokumenty. 

Microsoft nadal zapewnia silne wsparcie dla XPS w systemie Windows (nawet w Windows 10), więc warto rozważyć zapisywanie plików w tym formacie. Jeśli pracujesz z Windows 8.1, Windows 8, Windows 7 i Windows Vista, XPS może być najlepszą opcją dla niektórych operacji. 

- **Windows 8** używa formatu OXPS (Open XPS) dla plików XPS. OXPS jest ustandaryzowaną wersją oryginalnego formatu XPS. Windows 8 zapewnia lepsze wsparcie dla plików XPS niż dla plików PDF. 
  - **XPS:** wbudowana przeglądarka/odczytywacz XPS oraz funkcja drukowania do XPS dostępna. 
  - **PDF:** dostępny czytnik PDF, ale brak funkcji drukowania do PDF. 

- **Windows 7 i Windows Vista** używają oryginalnego formatu XPS. Te systemy operacyjne również zapewniają lepsze wsparcie dla plików XPS niż dla PDF. 
  - **XPS:** wbudowana przeglądarka XPS oraz funkcja drukowania do XPS dostępna. 
  - **PDF:** brak czytnika PDF. Brak funkcji drukowania do PDF. 

|<p>**Wejście PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Wyjście XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft ostatecznie wprowadził obsługę operacji drukowania w PDF za pomocą funkcji Drukuj do PDF w Windows 10. Wcześniej użytkownicy musieli drukować dokumenty za pomocą formatu XPS. 

## Konwersja XPS przy użyciu Aspose.Slides

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/python-net/) dla .NET możesz użyć metody [**Save**](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides.presentation/) do konwersji całej prezentacji na dokument XPS. 

Podczas konwersji prezentacji do XPS, należy zapisać prezentację używając jednej z następujących ustawień:

- Ustawienia domyślne (bez [**XPSOptions**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/xpsoptions/))
- Ustawienia własne (z [**XPSOptions**](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/xpsoptions/))

### **Konwertowanie prezentacji do XPS przy użyciu ustawień domyślnych**

Poniższy przykładowy kod w języku Python pokazuje, jak skonwertować prezentację do dokumentu XPS przy użyciu standardowych ustawień:

```py
import aspose.slides as slides

# Utwórz obiekt Presentation, który reprezentuje plik prezentacji
pres = slides.Presentation("Convert_XPS.pptx")

# Zapisanie prezentacji do dokumentu XPS
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```


### **Konwertowanie prezentacji do XPS przy użyciu ustawień własnych**
Ten przykładowy kod pokazuje, jak skonwertować prezentację do dokumentu XPS przy użyciu własnych ustawień w języku Python:

```py
import aspose.slides as slides

# Utwórz obiekt Presentation, który reprezentuje plik prezentacji
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Utwórz instancję klasy TiffOptions
options = slides.export.XpsOptions()

# Zapisz MetaFiles jako PNG
options.save_metafiles_as_png = True

# Zapisz prezentację do dokumentu XPS
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **FAQ**

**Czy mogę zapisać XPS do strumienia zamiast do pliku?**

Tak—Aspose.Slides umożliwia eksport bezpośrednio do strumienia, co jest idealne dla interfejsów API sieciowych, potoków po stronie serwera lub każdej sytuacji, w której chcesz wysłać XPS bez zapisu na dysku.

**Czy ukryte slajdy są przenoszone do XPS i czy mogę je wykluczyć?**

Domyślnie renderowane są tylko zwykłe (widoczne) slajdy. Możesz [uwzględnić lub wykluczyć ukryte slajdy](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) poprzez [ustawienia eksportu](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/xpsoptions/) przed zapisaniem do XPS, zapewniając, że wynik zawiera dokładnie te strony, które chcesz.