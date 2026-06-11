---
title: Konwertuj prezentacje PowerPoint do XPS na Androidzie
linktitle: PowerPoint do XPS
type: docs
weight: 70
url: /pl/androidjava/convert-powerpoint-to-xps/
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
- Android
- Java
- Aspose.Slides
description: "Konwertuj PowerPoint PPT/PPTX do wysokiej jakości, niezależnego od platformy XPS w Javie przy użyciu Aspose.Slides dla Androida. Otrzymaj instrukcję krok po kroku oraz przykładowy kod."
---
## **Przegląd**

Aspose.Slides umożliwia konwersję prezentacji PowerPoint do XPS poprzez zapisanie pliku PPT lub PPTX w formacie XPS. Ten artykuł wyjaśnia, kiedy format XPS może być przydatny i pokazuje, jak wykonać konwersję przy użyciu Aspose.Slides z domyślnymi ustawieniami lub niestandardowymi ustawieniami [XpsOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xpsoptions/) .

## **O XPS**

Microsoft opracował [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternatywę dla [PDF](https://docs.fileformat.com/pdf/). Umożliwia drukowanie zawartości poprzez wygenerowanie pliku bardzo podobnego do PDF. Format XPS oparty jest na XML. Układ lub struktura pliku XPS pozostaje taka sama na wszystkich systemach operacyjnych i drukarkach. 

## **Kiedy używać formatu Microsoft XPS**

{{% alert color="primary" %}} 

Aby zobaczyć, jak Aspose.Slides konwertuje prezentację PPT lub PPTX do formatu XPS, możesz sprawdzić [tę darmową aplikację do konwersji online](https://products.aspose.app/slides/pl/conversion). 

{{% /alert %}} 

Jeśli chcesz obniżyć koszty przechowywania, możesz przekonwertować swoją prezentację Microsoft PowerPoint do formatu XPS. W ten sposób będzie łatwiej zapisywać, udostępniać i drukować dokumenty. 

Microsoft nadal zapewnia silne wsparcie dla XPS w systemie Windows (nawet w Windows 10), więc możesz rozważyć zapisywanie plików w tym formacie. Jeśli pracujesz z Windows 8.1, Windows 8, Windows 7 i Windows Vista, XPS może być w rzeczywistości najlepszą opcją dla niektórych operacji. 

- **Windows 8** używa formatu OXPS (Open XPS) dla plików XPS. OXPS jest ustandaryzowaną wersją oryginalnego formatu XPS. Windows 8 zapewnia lepsze wsparcie dla plików XPS niż dla plików PDF. 
  - **XPS:** Wbudowana przeglądarka/odczytarka XPS i możliwość drukowania do XPS dostępna. 
  - **PDF:** Dostępny czytnik PDF, ale brak możliwości drukowania do PDF. 

- **Windows 7 i Windows Vista** używają oryginalnego formatu XPS. Te systemy operacyjne również zapewniają lepsze wsparcie dla plików XPS niż dla PDF. 
  - **XPS:** Wbudowana przeglądarka XPS i możliwość drukowania do XPS dostępna. 
  - **PDF:** Brak czytnika PDF. Brak możliwości drukowania do PDF. 

|<p>**Wejście PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Wyjście XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ostatecznie wprowadził obsługę drukowania w formacie PDF za pomocą funkcji Drukuj do PDF w systemie Windows 10. Wcześniej od użytkowników oczekiwano drukowania dokumentów przy użyciu formatu XPS. 

## **Konwersja XPS przy użyciu Aspose.Slides**

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/androidjava/) dla języka Java możesz użyć metody [**Save**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation), aby przekonwertować całą prezentację na dokument XPS.

Podczas konwertowania prezentacji do XPS musisz zapisać prezentację przy użyciu jednej z następujących konfiguracji:

- Domyślne ustawienia (bez [**XPSOptions**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xpsoptions))
- Niestandardowe ustawienia (z [**XPSOptions**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xpsoptions))

### **Konwertowanie prezentacji do XPS przy użyciu domyślnych ustawień**

Ten przykładowy kod w języku Java pokazuje, jak przekonwertować prezentację na dokument XPS przy użyciu standardowych ustawień:

```java
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Zapis prezentacji do dokumentu XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Konwertowanie prezentacji do XPS przy użyciu niestandardowych ustawień**

Ten przykładowy kod pokazuje, jak przekonwertować prezentację na dokument XPS przy użyciu niestandardowych ustawień w języku Java:

```java
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Utwórz obiekt klasy TiffOptions
    XpsOptions options = new XpsOptions();

    // Zapisz pliki Meta jako PNG
    options.setSaveMetafilesAsPng(true);

    // Zapisz prezentację do dokumentu XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę zapisać XPS do strumienia zamiast do pliku?**

Tak — Aspose.Slides pozwala eksportować bezpośrednio do strumienia, co jest idealne dla interfejsów API sieciowych, potoków po stronie serwera lub każdego scenariusza, w którym chcesz przesłać XPS bez korzystania z systemu plików.

**Czy ukryte slajdy są przenoszone do XPS i czy mogę je wykluczyć?**

Domyślnie renderowane są tylko zwykłe (widoczne) slajdy. Możesz [uwzględnić lub wykluczyć ukryte slajdy](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) za pomocą [ustawień eksportu](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xpsoptions/) przed zapisem do XPS, co zapewnia, że wynik zawiera dokładnie te strony, które zamierzasz.